Imports Disar.data

Public Class FrmConfigPaletizado
    Dim CantidadAnterior As Decimal
    Dim CantidadNueva As Decimal
    Dim Almacen As Integer

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click
        Dim dt As New DataTable
        dt.Rows.Clear()
        dt.Columns.Add("ID")
        dt.Columns.Add("Nombre")
        dt.Columns.Add("P_Anterior")
        dt.Columns.Add("P_Nuevo")

        For Each row As DataGridViewRow In grdPaletizado.Rows
            dt.Rows.Add(row.Cells(0).Value, row.Cells(1).Value, row.Cells(2).Value, row.Cells(3).Value)
        Next

        If grdPaletizado.RowCount > 0 Then
            If TextAnterior.Text <> TextNuevo.Text Then
                Dim a = MsgBox("La cantidad de tarimas disponibles anterior y la especificada no coinciden, ¿Desea guardar los cambios de igual forma?", MsgBoxStyle.YesNo, "Atención")
                If a = MsgBoxResult.Yes Then
                    Dim db As New clsInventarios

                    Try
                        Dim s As String
                        s = db.ModificaPaletizado(dt, _Inicio.lblUsuario.Text, Almacen)
                        If s = "correcto" Then
                            MsgBox("Paletizado cambiado exitosamente", MsgBoxStyle.Information)
                        End If
                        Me.Close()
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                End If
            Else
                Dim db As New clsInventarios

                Try
                    Dim s As String
                    s = db.ModificaPaletizado(dt, _Inicio.lblUsuario.Text, Almacen)
                    If s = "correcto" Then
                        MsgBox("Paletizado cambiado exitosamente", MsgBoxStyle.Information)
                    End If
                    Me.Close()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If

        End If

    End Sub

    Private Sub BtnFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFiltrar.Click
        grdPaletizado.Rows.Clear()
        CantidadAnterior = 0
        If CmbAlmacen.Text = "SRC" Then
            Almacen = 1
        ElseIf CmbAlmacen.Text = "SPS" Then
            Almacen = 2
        ElseIf CmbAlmacen.Text = "Tocoa" Then
            Almacen = 6
        Else
            Almacen = 0
        End If
        Dim db As New clsInventarios
        Dim dt As New DataTable
        dt = db.ListaPaletizado(Almacen)
        Try
            For i As Integer = 0 To dt.Rows.Count
                grdPaletizado.Rows.Add(dt(i)(0), dt(i)(1), dt(i)(2), dt(i)(2))
            Next
        Catch ex As Exception
        End Try

        For Each row As DataGridViewRow In grdPaletizado.Rows
            CantidadAnterior += Val(row.Cells(2).Value)
            row.Cells(2).Style.ForeColor = Color.SlateGray
        Next
        TextAnterior.Text = CantidadAnterior
        TextNuevo.Text = CantidadAnterior
    End Sub

    Private Sub FrmConfigPaletizado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Dock = DockStyle.Fill
    End Sub

    Private Sub grdPaletizado_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdPaletizado.CellEndEdit
        CantidadNueva = 0
        For Each row As DataGridViewRow In grdPaletizado.Rows
            CantidadNueva += Val(row.Cells(3).Value)
        Next
        TextNuevo.Text = CantidadNueva
    End Sub
End Class