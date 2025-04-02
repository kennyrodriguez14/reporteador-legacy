Imports Disar.data
Imports System.IO

Public Class FormKardex

    Private Sub BtnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGenerar.Click
        Dim db As New cls_libro_ventas
        DataDatos.DataSource = db.Kardex(DateTimePicker1.Value, DateTimePicker2.Value, ComboBox1.Text)
    End Sub

    Private Sub BtnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExcel.Click
        frmGuardarArchivo.Formulario = "kardex"
        frmGuardarArchivo.MdiParent = _Inicio
        frmGuardarArchivo.Visible = True
    End Sub

    Sub exportarTXT(ByVal Ruta As String)
        Dim sFile As String = Ruta & "\Libro_De_Ventas" & Now.Day & "-" & Now.Month & "-" & Now.Year & ".xls "
        Dim _Line As String = Nothing
        Try
            If File.Exists(sFile) = True Then
                My.Computer.FileSystem.DeleteFile(sFile, FileIO.UIOption.OnlyErrorDialogs, _
                                                  FileIO.RecycleOption.DeletePermanently, FileIO.UICancelOption.DoNothing)
            End If
            Dim swFile As StreamWriter = New StreamWriter(sFile, True, System.Text.Encoding.Default)
            With DataDatos

                For index As Integer = 0 To .Columns.Count - 1
                    If (index = .Columns.Count - 1) Then
                        _Line += .Columns(index).HeaderText
                    Else
                        _Line += .Columns(index).HeaderText & vbTab
                    End If
                Next


                swFile.WriteLine(_Line)
                _Line = ""
                For i = 0 To .RowCount - 1
                    For index As Integer = 0 To .Columns.Count - 1
                        
                        _Line += .Rows(i).Cells(index).Value & vbTab

                    Next

                    swFile.WriteLine(_Line)
                    _Line = ""
                Next
            End With
            'swFile = System.Text.Encoding.Default
            swFile.Close()
            Process.Start(sFile)
        Catch ex As Exception
            MessageBox.Show("Error" + ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class