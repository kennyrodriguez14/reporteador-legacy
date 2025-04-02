Imports Disar.data
Imports System.IO
Public Class frm_sell_out_rentabilidad

    Dim conexion As New cls_sell_out_general

    Private Sub _btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnGenerar.Click
        Try
            GridGeneral.DataSource = conexion.get_datos_so_rentabilidad(f1.Value.Date, f2.Value.Date)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub exportarTXT(ByVal Ruta As String)
        Dim sFile As String = Ruta & "\Sell_Out_Rentabilidad" & Now.Day & "-" & Now.Month & "-" & Now.Year & ".xls "
        Dim _Line As String = Nothing
        Try
            If File.Exists(sFile) = True Then
                My.Computer.FileSystem.DeleteFile(sFile, FileIO.UIOption.OnlyErrorDialogs, _
                                                  FileIO.RecycleOption.DeletePermanently, FileIO.UICancelOption.DoNothing)
            End If
            Dim swFile As StreamWriter = New StreamWriter(sFile, True, System.Text.Encoding.Default)
            With GridGeneral
                For col As Integer = 0 To GridGeneral.Columns.Count - 1
                    _Line += .Columns(col).HeaderText & vbTab
                Next
                swFile.WriteLine(_Line)
                _Line = ""
                For lin As Integer = 0 To GridGeneral.Rows.Count - 1
                    For col As Integer = 0 To GridGeneral.Columns.Count - 1
                        _Line += .Rows(lin).Cells(col).Value & vbTab
                    Next
                    swFile.WriteLine(_Line)
                    _Line = ""
                Next
            End With
            swFile.Close()
            Process.Start(sFile)
        Catch ex As Exception
            MessageBox.Show("Error" + ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        frmGuardarArchivo.Formulario = "sell_out_rentabilidad"
        frmGuardarArchivo.MdiParent = _Inicio
        frmGuardarArchivo.Visible = True
    End Sub

    Private Sub frm_sell_out_rentabilidad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class