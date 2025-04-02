Imports Disar.data
Imports System.IO

Public Class comisiones_detallado
    Dim Conexion As New clsComisiones
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        'Exportar()
        frmGuardarArchivo.Formulario = "Comisiones_Detallado"
        frmGuardarArchivo.MdiParent = _Inicio
        frmGuardarArchivo.Visible = True
    End Sub

    Sub Exportar()
        Try
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet, wSheet3 As Microsoft.Office.Interop.Excel.Worksheet
            Dim wSheet2 As Microsoft.Office.Interop.Excel.Worksheet

            wBook = excel.Workbooks.Add()

            wSheet2 = wBook.ActiveSheet
            wSheet2.Name = "Mayoreo"

            wSheet2.Cells.Range("A1:H1").Merge()
            wSheet2.Cells.Range("A1:H1").Borders.LineStyle = BorderStyle.FixedSingle
            wSheet2.Cells.Range("A1:H1").Value = "COMISIONES del" + _cmbFechai.Value.Date + " al " + _cmbFechaf.Value.Date
            wSheet2.Cells.Range("A1:H1").Font.Bold = True
            wSheet2.Cells.Range("A1:H1").Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            wSheet2.Cells.Range("A1:H1").Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            wSheet2.Cells.Range("A1:H1").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet2.Cells.Range("A1:H1").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            For c As Integer = 0 To grd_comisiones_mayoreo.Columns.Count - 1
                wSheet2.Cells(2, c + 1).value = grd_comisiones_mayoreo.Columns(c).HeaderText
                wSheet2.Cells(2, c + 1).Font.Bold = True
                wSheet2.Cells(2, c + 1).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                wSheet2.Cells(2, c + 1).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            Next
            For r As Integer = 0 To grd_comisiones_mayoreo.RowCount - 1
                For c As Integer = 0 To grd_comisiones_mayoreo.Columns.Count - 1
                    wSheet2.Cells(r + 3, c + 1).value = grd_comisiones_mayoreo.Item(c, r).Value
                    wSheet2.Cells(r + 3, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                Next
            Next
            wSheet2.Columns.AutoFit()

            wSheet = wBook.Sheets.Add()
            wSheet.Name = "Detalle"
            wSheet.Cells.Range("A1:H1").Merge()
            wSheet.Cells.Range("A1:H1").Borders.LineStyle = BorderStyle.FixedSingle
            wSheet.Cells.Range("A1:H1").Value = "COMISIONES del" + _cmbFechai.Value.Date + " al " + _cmbFechaf.Value.Date
            wSheet.Cells.Range("A1:H1").Font.Bold = True
            wSheet.Cells.Range("A1:H1").Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            wSheet.Cells.Range("A1:H1").Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            wSheet.Cells.Range("A1:H1").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet.Cells.Range("A1:H1").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            For c As Integer = 0 To gridComisiones_detalle.Columns.Count - 1
                wSheet.Cells(2, c + 1).value = gridComisiones_detalle.Columns(c).HeaderText
                wSheet.Cells(2, c + 1).Font.Bold = True
                wSheet.Cells(2, c + 1).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                wSheet.Cells(2, c + 1).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            Next
            For r As Integer = 0 To gridComisiones_detalle.RowCount - 1
                For c As Integer = 0 To gridComisiones_detalle.Columns.Count - 1
                    wSheet.Cells(r + 3, c + 1).value = gridComisiones_detalle.Item(c, r).Value
                    wSheet.Cells(r + 3, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                Next
            Next
            wSheet.Columns.AutoFit()

            wSheet3 = wBook.Sheets.Add()
            wSheet3.Name = "SR Agro"
            wSheet3.Cells.Range("A1:H1").Merge()
            wSheet3.Cells.Range("A1:H1").Borders.LineStyle = BorderStyle.FixedSingle
            wSheet3.Cells.Range("A1:H1").Value = "COMISIONES del" + _cmbFechai.Value.Date + " al " + _cmbFechaf.Value.Date
            wSheet3.Cells.Range("A1:H1").Font.Bold = True
            wSheet3.Cells.Range("A1:H1").Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            wSheet3.Cells.Range("A1:H1").Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            wSheet3.Cells.Range("A1:H1").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet3.Cells.Range("A1:H1").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            For c As Integer = 0 To grd_sr_agro.Columns.Count - 1
                wSheet3.Cells(2, c + 1).value = grd_sr_agro.Columns(c).HeaderText
                wSheet3.Cells(2, c + 1).Font.Bold = True
                wSheet3.Cells(2, c + 1).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                wSheet3.Cells(2, c + 1).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            Next
            For r As Integer = 0 To grd_sr_agro.RowCount - 1
                For c As Integer = 0 To grd_sr_agro.Columns.Count - 1
                    wSheet3.Cells(r + 3, c + 1).value = grd_sr_agro.Item(c, r).Value
                    wSheet3.Cells(r + 3, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                Next
            Next
            wSheet3.Columns.AutoFit()


            excel.Visible = True
            excel.Quit()
        Catch ex As Exception
            MessageBox.Show("Error al Exportar " + ex.ToString, "Problemas", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub _btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnGenerar.Click
        Try
            gridComisiones_detalle.DataSource = Conexion.Comisiones(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, _
                                                                    "DETALLADO_DET", cmb_almacen.SelectedValue)
            grd_comisiones_mayoreo.DataSource = Conexion.Comisiones(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, _
                                                                    "DETALLADO_MAY", cmb_almacen.SelectedValue)
            grd_sr_agro.DataSource = Conexion.Comisiones(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, "DETALLADO_SR_AGRO", _
                                                         cmb_almacen.SelectedValue)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub comisiones_detallado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_sucursal()
    End Sub

    Sub cargar_sucursal()
        Try
            cmb_almacen.DataSource = Conexion.Comisiones(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, "SUCURSAL", 1)
            cmb_almacen.ValueMember = "ID"
            cmb_almacen.DisplayMember = "ALMACEN"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub exportarTXT1(ByVal Ruta As String)
        Dim sFile As String = Ruta & "\Comisiones_Detalle" & Now.Day & "-" & Now.Month & "-" & Now.Year & ".xls "
        Dim _Line As String = Nothing
        Try
            If File.Exists(sFile) = True Then
                My.Computer.FileSystem.DeleteFile(sFile, FileIO.UIOption.OnlyErrorDialogs, _
                                                  FileIO.RecycleOption.DeletePermanently, FileIO.UICancelOption.DoNothing)
            End If
            Dim swFile As StreamWriter = New StreamWriter(sFile, True, System.Text.Encoding.Default)
            With gridComisiones_detalle

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
    Sub exportarTXT2(ByVal Ruta As String)
        Dim sFile As String = Ruta & "\Comisiones_Mayoreo" & Now.Day & "-" & Now.Month & "-" & Now.Year & ".xls "
        Dim _Line As String = Nothing
        Try
            If File.Exists(sFile) = True Then
                My.Computer.FileSystem.DeleteFile(sFile, FileIO.UIOption.OnlyErrorDialogs, _
                                                  FileIO.RecycleOption.DeletePermanently, FileIO.UICancelOption.DoNothing)
            End If
            Dim swFile As StreamWriter = New StreamWriter(sFile, True, System.Text.Encoding.Default)
            With grd_comisiones_mayoreo

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
    Sub exportarTXT3(ByVal Ruta As String)
        Dim sFile As String = Ruta & "\Comisiones_SRAGRO" & Now.Day & "-" & Now.Month & "-" & Now.Year & ".xls "
        Dim _Line As String = Nothing
        Try
            If File.Exists(sFile) = True Then
                My.Computer.FileSystem.DeleteFile(sFile, FileIO.UIOption.OnlyErrorDialogs, _
                                                  FileIO.RecycleOption.DeletePermanently, FileIO.UICancelOption.DoNothing)
            End If
            Dim swFile As StreamWriter = New StreamWriter(sFile, True, System.Text.Encoding.Default)
            With grd_sr_agro

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