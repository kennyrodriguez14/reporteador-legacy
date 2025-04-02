Imports Disar.data
Imports System.IO
Public Class General
    Dim Conexion As New clsColgate
    Dim ColumnaNueva As New DataGridViewTextBoxColumn
    Dim dtSinVenta As New DataTable
    Dim dtVendedoresBloqueados As New DataTable
    Dim TotalSinVenta As Integer = 0

    Sub Cargar()
        Try
            GridGeneral.Columns.Clear()
        Catch ex As Exception
        End Try
        Try
            GridGeneral.DataSource = Conexion.General(f1.Value.Date, f2.Value.Date, "N")
        Catch ex As Exception
            MsgBox("Error al cargar los archivos " + ex.ToString)
        End Try
    End Sub

    Private Sub _btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnGenerar.Click
        Cargar()
    End Sub

    Private Sub ExportarAExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportarAExcelToolStripMenuItem.Click
        frmGuardarArchivo.Formulario = "ColgateGeneral"
        frmGuardarArchivo.MdiParent = _Inicio
        frmGuardarArchivo.Visible = True
    End Sub

    Sub exportarTXT(ByVal Ruta As String)
        Dim sFile As String = Ruta & "\Colgate " & Now.Day & "-" & Now.Month & "-" & Now.Year & ".xls "
        Dim _Line As String = Nothing
        Try
            If File.Exists(sFile) = True Then
                My.Computer.FileSystem.DeleteFile(sFile, FileIO.UIOption.OnlyErrorDialogs, _
                 FileIO.RecycleOption.DeletePermanently, FileIO.UICancelOption.DoNothing)
            End If
            Dim swFile As StreamWriter = New StreamWriter(sFile, True, System.Text.Encoding.Default)
            With GridGeneral

                _Line = .Columns(0).HeaderText & vbTab & _
                            .Columns(1).HeaderText & vbTab & _
                            .Columns(2).HeaderText & vbTab & _
                            .Columns(3).HeaderText & vbTab & _
                            .Columns(4).HeaderText & vbTab & _
                            .Columns(5).HeaderText & vbTab & _
                            .Columns(6).HeaderText & vbTab & _
                            .Columns(7).HeaderText & vbTab & _
                            .Columns(8).HeaderText & vbTab & _
                            .Columns(9).HeaderText & vbTab & _
                            .Columns(10).HeaderText & vbTab & _
                            .Columns(11).HeaderText & vbTab & _
                            .Columns(12).HeaderText & vbTab & _
                            .Columns(13).HeaderText & vbTab & _
                            .Columns(14).HeaderText & vbTab & _
                            .Columns(15).HeaderText & vbTab & _
                            .Columns(16).HeaderText & vbTab & _
                            .Columns(17).HeaderText & vbTab & _
                            .Columns(18).HeaderText & vbTab & _
                            .Columns(19).HeaderText & vbTab & _
                            .Columns(20).HeaderText 
                swFile.WriteLine(_Line)

                For i = 0 To .RowCount - 1
                    _Line = .Rows(i).Cells(0).Value & vbTab & _
                            .Rows(i).Cells(1).Value & vbTab & _
                            .Rows(i).Cells(2).Value & vbTab & _
                            .Rows(i).Cells(3).Value & vbTab & _
                            .Rows(i).Cells(4).Value & vbTab & _
                            .Rows(i).Cells(5).Value & vbTab & _
                            .Rows(i).Cells(6).Value & vbTab & _
                            .Rows(i).Cells(7).Value & vbTab & _
                            .Rows(i).Cells(8).Value & vbTab & _
                            .Rows(i).Cells(9).Value & vbTab & _
                            .Rows(i).Cells(10).Value & vbTab & _
                            .Rows(i).Cells(11).Value & vbTab & _
                            .Rows(i).Cells(12).Value & vbTab & _
                            .Rows(i).Cells(13).Value & vbTab & _
                            .Rows(i).Cells(14).Value & vbTab & _
                            .Rows(i).Cells(15).Value & vbTab & _
                            .Rows(i).Cells(16).Value & vbTab & _
                            .Rows(i).Cells(17).Value & vbTab & _
                            .Rows(i).Cells(18).Value & vbTab & _
                            .Rows(i).Cells(19).Value & vbTab & _
                            .Rows(i).Cells(20).Value 
                    swFile.WriteLine(_Line)
                Next
            End With
            'swFile = System.Text.Encoding.Default
            swFile.Close()
            Process.Start(sFile)
        Catch ex As Exception
            MessageBox.Show("Error" + ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

      

        'MsgBox("Vendedores bloqueados: " & dtVendedoresBloqueados.Rows.Count & ". Clientes sin venta: " & dtSinVenta.Rows.Count)

        Dim Fila As Integer = 0
        For Each row As DataGridViewRow In GridGeneral.Rows
            For i As Integer = 0 To dtVendedoresBloqueados.Rows.Count

                Dim VendedorBloqueado As Integer = 0
                Try
                    VendedorBloqueado = dtVendedoresBloqueados(i)(0)
                Catch ex As Exception
                End Try

                Dim Cliente = row.Cells(8).Value

                If VendedorBloqueado = row.Cells(4).Value Then
                    Try
                        row.Cells("Sustituido").Value = Cliente
                        row.Cells(2).Value = "Tegucigalpa"
                        row.Cells(4).Value = dtSinVenta(Fila)(4)
                        row.Cells(5).Value = dtSinVenta(Fila)(5)
                        row.Cells(10).Value = dtSinVenta(Fila)(2)
                        row.Cells(11).Value = dtSinVenta(Fila)(3)
                        row.Cells(8).Value = dtSinVenta(Fila)(0)
                        row.Cells(9).Value = dtSinVenta(Fila)(1)
                        Fila += 1
                        If Fila = TotalSinVenta Then
                            Fila = 1
                        End If
                    Catch ex As Exception
                    End Try
                End If

            Next
        Next

    End Sub

    Private Sub BtnGenerarTeg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGenerarTeg.Click

        Try
            GridGeneral.Columns.Clear()
        Catch ex As Exception
        End Try
        Try
            GridGeneral.DataSource = Conexion.General_TGU(f1.Value.Date, f2.Value.Date, "N")
        Catch ex As Exception
            MsgBox("Error al cargar los archivos " + ex.ToString)
        End Try
        Try
            ColumnaNueva.HeaderText = "Sustituido"
            ColumnaNueva.Name = "Sustituido"
        Catch ex As Exception
        End Try
        dtVendedoresBloqueados = Conexion.VendedoresBloq
        dtSinVenta = Conexion.SinVenta(f1.Value, f2.Value)


        TotalSinVenta = dtSinVenta.Rows.Count

        Try
            GridGeneral.Columns.Add(ColumnaNueva)
        Catch ex As Exception
        End Try
    End Sub
End Class