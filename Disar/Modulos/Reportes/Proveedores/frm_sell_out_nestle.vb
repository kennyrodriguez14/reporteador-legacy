Imports Disar.data
Imports System.IO

Public Class frm_sell_out_nestle
    Dim conexion As New cls_sell_out_general
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        frmGuardarArchivo.Formulario = "sell_out_nestle"
        frmGuardarArchivo.MdiParent = _Inicio
        frmGuardarArchivo.Visible = True
    End Sub

    Private Sub _btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnGenerar.Click
        Try
            GridGeneral.DataSource = conexion.nestle(f1.Value.Date, f2.Value.Date, "0")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub exportarTXT(ByVal Ruta As String)
        Dim sFile As String = Ruta & "\Sell_Out_Nestle" & Now.Day & "-" & Now.Month & "-" & Now.Year & ".xls "
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
                            .Columns(20).HeaderText & vbTab & _
                            .Columns(21).HeaderText & vbTab & _
                            .Columns(22).HeaderText & vbTab & _
                            .Columns(23).HeaderText & vbTab & _
                            .Columns(24).HeaderText & vbTab & _
                            .Columns(25).HeaderText & vbTab & _
                            .Columns(26).HeaderText & vbTab & _
                            .Columns(27).HeaderText

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
                            .Rows(i).Cells(20).Value & vbTab & _
                            .Rows(i).Cells(21).Value & vbTab & _
                            .Rows(i).Cells(22).Value & vbTab & _
                            .Rows(i).Cells(23).Value & vbTab & _
                            .Rows(i).Cells(24).Value & vbTab & _
                            .Rows(i).Cells(25).Value & vbTab & _
                            .Rows(i).Cells(26).Value & vbTab & _
                            .Rows(i).Cells(27).Value
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

    Private Sub frm_sell_out_colombina_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class