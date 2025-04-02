Imports Disar.data
Imports System.IO

Public Class Quala
    Dim Conexion As New clsFacturas
    Dim cmbox As New cls_ventas_por_proveedor
    Dim Style As Microsoft.Office.Interop.Excel.Style
    Private Sub Facturas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inicializardate()
        cmbSucursal.SelectedItem = "SRC"
        cmbLinea.SelectedValue = 27
    End Sub

    Private Sub _btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnGenerar.Click
        Try
            If ComboBox1.Text = "San Rafael" Then
                _gridFacturas.DataSource = Conexion.GenerarDatos(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, cmbLinea.SelectedValue, cmbSucursal.SelectedItem)
            Else
                _gridFacturas.DataSource = Conexion.GenerarDatosDimosa(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, cmbLinea.SelectedValue, cmbSucursal.SelectedItem)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub Lineas()
        If cmbSucursal.SelectedItem = "SRC" Then
            cmbLinea.DataSource = cmbox.ListaProveedoresSRC()
            cmbLinea.ValueMember = "CODIGO"
            cmbLinea.DisplayMember = "DESCRIPCION"
            cmbLinea.SelectedValue = 27
        ElseIf cmbSucursal.SelectedItem = "SPS" Then
            cmbLinea.DataSource = cmbox.ListaProveedoresSPS()
            cmbLinea.ValueMember = "CODIGO"
            cmbLinea.DisplayMember = "DESCRIPCION"
            cmbLinea.SelectedValue = 27
        End If
    End Sub

    Sub inicializardate()
        _cmbFechai.Value = 1 & "/" & Now.Month & "/" & Now.Year
        If Now.Day = 1 Then
            _cmbFechaf.Value = Today
        Else
            _cmbFechaf.Value = DateAdd(DateInterval.Day, -1, Now)
        End If
    End Sub

    Private Sub cmbSucursal_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSucursal.SelectedIndexChanged
        Lineas()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Exportar()
        'excel2()
    End Sub

    Sub Exportar()
        Try
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()

            style = wSheet.Application.ActiveWorkbook.Styles.Add("Reportes")
            style.Font.Bold = True
            style.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            style.Font.Size = 11
            style.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            wSheet.Range("A1:J1").Merge()
            wSheet.Range("A1:J1").Value = "VENTAS POR PRODUCTO DEL " + _cmbFechai.Value.Date + " AL " + _cmbFechaf.Value.Date
            wSheet.Range("A1:J1").Font.Bold = True
            wSheet.Range("A1:J1").Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            wSheet.Range("A1:J1").Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            wSheet.Range("A1:J1").Font.Size = 11

            For c As Integer = 0 To _gridFacturas.Columns.Count - 1
                wSheet.Cells(2, c + 1).value = _gridFacturas.Columns(c).HeaderText
                wSheet.Cells(2, c + 1).Style = "Reportes"
            Next
            For r As Integer = 0 To _gridFacturas.RowCount - 1
                For c As Integer = 0 To _gridFacturas.Columns.Count - 1
                    wSheet.Cells(r + 3, c + 1).value = _gridFacturas.Item(c, r).Value
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

    Sub excel2()
        If _gridFacturas.RowCount > 0 Then
            Dim dt As New DataTable
            dt = _gridFacturas.DataSource
            Dim save As New SaveFileDialog
            save.Filter = "Excel (*.xls)|*.xls"
            save.FileName = "VENTAS POR PRODUCTO DEL " + _cmbFechai.Value.Date + " AL " + _cmbFechaf.Value.Date & ".xls"
            If save.ShowDialog = Windows.Forms.DialogResult.OK Then
                'If Not IO.File.Exists(save.FileName) Then
                Dim fs As System.IO.FileStream
                Dim xtw As System.Xml.XmlTextWriter
                dt.TableName = "items"
                fs = New System.IO.FileStream(save.FileName, IO.FileMode.Create)
                xtw = New System.Xml.XmlTextWriter(fs, System.Text.Encoding.Unicode)
                xtw.WriteProcessingInstruction("xml", "version='1.0'")
                xtw.WriteProcessingInstruction("mso-application", "progid='Excel.Sheet'")
                dt.WriteXml(xtw)
                xtw.Close()
                MsgBox("Informacion Exportada Correctament")
            End If
        Else
            MsgBox("No hay datos para Exportar", MsgBoxStyle.Critical, "Verificar")
            Exit Sub
        End If
    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click
        frmGuardarArchivo.Formulario = "Quala"
        frmGuardarArchivo.Visible = True
    End Sub

    Sub exportarTXT(ByVal Ruta As String)
        'Dim sFile As String = "C:\Reportes\Resumen Anual\Resumen.xls" 'Ruta.Text & "\Inventry4.txt"
        Dim sFile As String = Ruta & "\Quala " & Now.Day & "-" & Now.Month & "-" & Now.Year & ".xls "
        Dim _Line As String = Nothing
        Try
            If File.Exists(sFile) = True Then
                My.Computer.FileSystem.DeleteFile(sFile, FileIO.UIOption.OnlyErrorDialogs, _
                                                  FileIO.RecycleOption.DeletePermanently, FileIO.UICancelOption.DoNothing)
            End If
            Dim swFile As StreamWriter = New StreamWriter(sFile, True, System.Text.Encoding.Default)
            With _gridFacturas

                _Line = .Columns(0).HeaderText & vbTab & _
                        .Columns(1).HeaderText & vbTab & _
                        .Columns(2).HeaderText & vbTab & _
                        .Columns(3).HeaderText & vbTab & _
                        .Columns(4).HeaderText & vbTab & _
                        .Columns(5).HeaderText & vbTab & _
                        .Columns(6).HeaderText & vbTab & _
                        .Columns(7).HeaderText & vbTab & _
                        .Columns(8).HeaderText & vbTab & _
                        .Columns(9).HeaderText
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
                            .Rows(i).Cells(9).Value
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
End Class