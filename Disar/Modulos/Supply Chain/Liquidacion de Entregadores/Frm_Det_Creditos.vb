Imports Disar.data

Public Class Frm_Det_Creditos

    Private Sub BtnContinuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnContinuar.Click
        Dim ax = MsgBox("¿Terminó de registrar los detalles de la liquidación?", MsgBoxStyle.YesNo, "Registro de detalles")
        If ax = MsgBoxResult.Yes Then
            Dim dt As New DataTable
            Dim db As New ClsEfectividad

            Try
                dt.Columns.Clear()
            Catch ex As Exception
            End Try
            For Each column As DataGridViewColumn In Detalle.Columns
                dt.Columns.Add(column.HeaderText)
            Next
            Try
                dt.Rows.Clear()
            Catch ex As Exception
            End Try
            For Each row As DataGridViewRow In Detalle.Rows
                dt.Rows.Add(row.Cells(0).Value, row.Cells(1).Value, row.Cells(2).Value, row.Cells(3).Value)
            Next

            Try
                Dim s As String = ""
                s = db.Detalle_Credito_Cobro(Liquidacion.Text, Tipo.Text, dt)
                If s = "s" Then
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                Else
                    MsgBox(s)
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub Detalle_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Detalle.KeyDown
        If e.KeyCode = Keys.Delete Then
            Detalle.CurrentRow.Cells(Detalle.CurrentCell.ColumnIndex).Value = ""
        End If
    End Sub

    Private Sub Frm_Det_Creditos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim db As New ClsEfectividad
            Detalle.DataSource = db.CargaDetallesCredito(Liquidacion.Text)
            db.VerificaDetallesCredito(Liquidacion.Text)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Detalle_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Detalle.CellEndEdit
        If e.ColumnIndex = 0 Then
            Try
                Dim dt As New DataTable
                Dim db As New ClsEfectividad
                If frmLiquidacion.ComboEmpresa.Text = "SAN RAFAEL" Then
                    dt = db.CargaNombreCliente(Detalle.CurrentRow.Cells(0).Value)
                ElseIf frmLiquidacion.ComboEmpresa.Text = "DIMOSA" Then
                    dt = db.CargaNombreClienteDIMOSA(Detalle.CurrentRow.Cells(0).Value)
                Else
                    dt = db.CargaNombreClienteAgro(Detalle.CurrentRow.Cells(0).Value)
                End If

                Detalle.CurrentRow.Cells(1).Value = dt(0)(0)
            Catch ex As Exception
            End Try
        End If
    End Sub
End Class