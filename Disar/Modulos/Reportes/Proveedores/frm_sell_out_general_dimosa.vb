Imports Disar.data
Imports System.IO
Public Class frm_sell_out_general_dimosa

    Dim conexion As New cls_sell_out_general
    Private Sub frm_sell_out_general_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        llenar_cmb()
    End Sub

    Sub llenar_cmb()
        cmb_linea.DataSource = conexion.Llenar_cmb_DIMOSA()
        cmb_linea.ValueMember = "ID"
        cmb_linea.DisplayMember = "PROVEEDOR"
    End Sub

    Private Sub _btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnGenerar.Click
        Try
            GridGeneral.DataSource = conexion.getDatosDIMOSA(f1.Value.Date, f2.Value.Date, cmb_linea.SelectedValue)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub exportarTXT(ByVal Ruta As String)
        Dim sFile As String = Ruta & "\Sell_Out_General_DIMOSA" & Now.Day & "-" & Now.Month & "-" & Now.Year & ".xls "
        Dim _Line As String = Nothing
        Try
            If File.Exists(sFile) = True Then
                My.Computer.FileSystem.DeleteFile(sFile, FileIO.UIOption.OnlyErrorDialogs, _
                                                  FileIO.RecycleOption.DeletePermanently, FileIO.UICancelOption.DoNothing)
            End If
            Dim swFile As StreamWriter = New StreamWriter(sFile, True, System.Text.Encoding.Default)
            With GridGeneral

                _Line = .Columns(0).HeaderText & vbTab &
                            .Columns(1).HeaderText & vbTab &
                            .Columns(2).HeaderText & vbTab &
                            .Columns(3).HeaderText & vbTab &
                            .Columns(4).HeaderText & vbTab &
                            .Columns(5).HeaderText & vbTab &
                            .Columns(6).HeaderText & vbTab &
                            .Columns(7).HeaderText & vbTab &
                            .Columns(8).HeaderText & vbTab &
                            .Columns(9).HeaderText & vbTab &
                            .Columns(10).HeaderText & vbTab &
                            .Columns(11).HeaderText & vbTab &
                            .Columns(12).HeaderText & vbTab &
                            .Columns(13).HeaderText & vbTab &
                            .Columns(14).HeaderText & vbTab &
                            .Columns(15).HeaderText & vbTab &
                            .Columns(16).HeaderText & vbTab &
                            .Columns(17).HeaderText & vbTab &
                            .Columns(18).HeaderText & vbTab &
                            .Columns(19).HeaderText & vbTab &
                            .Columns(20).HeaderText & vbTab &
                            .Columns(21).HeaderText & vbTab &
                            .Columns(22).HeaderText & vbTab &
                            .Columns(23).HeaderText & vbTab &
                            .Columns(24).HeaderText & vbTab &
                            .Columns(25).HeaderText & vbTab &
                            .Columns(26).HeaderText & vbTab &
                            .Columns(27).HeaderText & vbTab &
                            .Columns(28).HeaderText

                swFile.WriteLine(_Line)

                For i = 0 To .RowCount - 1
                    _Line = .Rows(i).Cells(0).Value & vbTab &
                            .Rows(i).Cells(1).Value & vbTab &
                            .Rows(i).Cells(2).Value & vbTab &
                            .Rows(i).Cells(3).Value & vbTab &
                            .Rows(i).Cells(4).Value & vbTab &
                            .Rows(i).Cells(5).Value & vbTab &
                            .Rows(i).Cells(6).Value & vbTab &
                            .Rows(i).Cells(7).Value & vbTab &
                            .Rows(i).Cells(8).Value & vbTab &
                            .Rows(i).Cells(9).Value & vbTab &
                            .Rows(i).Cells(10).Value & vbTab &
                            .Rows(i).Cells(11).Value & vbTab &
                            .Rows(i).Cells(12).Value & vbTab &
                            .Rows(i).Cells(13).Value & vbTab &
                            .Rows(i).Cells(14).Value & vbTab &
                            .Rows(i).Cells(15).Value & vbTab &
                            .Rows(i).Cells(16).Value & vbTab &
                            .Rows(i).Cells(17).Value & vbTab &
                            .Rows(i).Cells(18).Value & vbTab &
                            .Rows(i).Cells(19).Value & vbTab &
                            .Rows(i).Cells(20).Value & vbTab &
                            .Rows(i).Cells(21).Value & vbTab &
                            .Rows(i).Cells(22).Value & vbTab &
                            .Rows(i).Cells(23).Value & vbTab &
                            .Rows(i).Cells(24).Value & vbTab &
                            .Rows(i).Cells(25).Value & vbTab &
                            .Rows(i).Cells(26).Value & vbTab &
                            .Rows(i).Cells(27).Value & vbTab &
                                        .Rows(i).Cells(28).Value

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

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        frmGuardarArchivo.Formulario = "sell_out_general_dimosa"
        frmGuardarArchivo.MdiParent = _Inicio
        frmGuardarArchivo.Visible = True
    End Sub

End Class