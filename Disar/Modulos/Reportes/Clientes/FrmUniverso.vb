Imports Disar.data 
Imports System.IO

Public Class FrmUniverso

    Dim style As Microsoft.Office.Interop.Excel.Style

    Private Sub FrmUniverso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            ComboBox1.Items.Clear()
            If _Inicio.SANRAFAEL = 1 Then
                ComboBox1.Items.Add("SAN RAFAEL")
            End If
            If _Inicio.DIMOSA = 1 Then
                ComboBox1.Items.Add("DIMOSA")
            End If
            If _Inicio.AGRO = 1 Then
                ComboBox1.Items.Add("SR AGRO")
            End If
            If _Inicio.OPL = 1 Then
                ComboBox1.Items.Add("OPL")
            End If
            ComboBox1.SelectedIndex = 0
            CargaVendedores()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim db As New ClsClientes
        DataUniverso.DataSource = db.CARGA_Universo(ComboBox1.Text, ComboVendedores.SelectedValue)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        frmGuardarArchivo.Formulario = "Universo"
        frmGuardarArchivo.MdiParent = _Inicio
        frmGuardarArchivo.Visible = True
    End Sub

    Sub Exportar()
        Try
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()
            wSheet.Name = "Universo de Clientes"

            style = wSheet.Application.ActiveWorkbook.Styles.Add("Reportes")
            style.Font.Bold = True
            style.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            style.Font.Size = 11
            style.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter


            For c As Integer = 0 To DataUniverso.Columns.Count - 1
                wSheet.Cells(2, c + 1).value = DataUniverso.Columns(c).HeaderText
                wSheet.Cells(2, c + 1).Style = "Reportes"
            Next
            For r As Integer = 0 To DataUniverso.RowCount - 1
                For c As Integer = 0 To DataUniverso.Columns.Count - 1
                    wSheet.Cells(r + 3, c + 1).value = DataUniverso.Item(c, r).Value
                    wSheet.Cells(r + 3, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                Next
            Next
            wSheet.Columns.AutoFit()
            excel.Visible = True
            excel.Quit()
        Catch ex As Exception
            MessageBox.Show("Error al Exportar " + ex.ToString, "Problemas", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub CargaVendedores()
        Dim db As New ClsClientes
        ComboVendedores.DataSource = db.Vendedores_Universo(ComboBox1.Text)
        ComboVendedores.ValueMember = "CVE_VEND"
        ComboVendedores.DisplayMember = "NOMBRE"
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        CargaVendedores()
    End Sub

    Sub exportarTXT(ByVal Ruta As String)
        Dim sFile As String = Ruta & "\Universo_" & ComboBox1.Text & Now.Day & "-" & Now.Month & "-" & Now.Year & ".xls "
        Dim _Line As String = Nothing
        Try
            If File.Exists(sFile) = True Then
                My.Computer.FileSystem.DeleteFile(sFile, FileIO.UIOption.OnlyErrorDialogs, _
                                                  FileIO.RecycleOption.DeletePermanently, FileIO.UICancelOption.DoNothing)
            End If
            Dim swFile As StreamWriter = New StreamWriter(sFile, True, System.Text.Encoding.Default)
            With DataUniverso
                For col As Integer = 0 To DataUniverso.Columns.Count - 1
                    _Line += .Columns(col).HeaderText & vbTab
                Next
                swFile.WriteLine(_Line)
                _Line = ""
                For lin As Integer = 0 To DataUniverso.Rows.Count - 1
                    For col As Integer = 0 To DataUniverso.Columns.Count - 1
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

End Class