Imports Disar.data
Imports System.IO
Public Class Resumen
    Dim Conexion As New cls_resumen_anual
    Dim tipo As String
    Dim Fecha1, Fecha2 As Date
    Dim Mes As Integer
    Private Sub Resumen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbMes.SelectedItem = "Enero"
        _txtAño.Value = Now.Year()
        _cmbSucursal.SelectedItem = "Santa Rosa Copan"
        tipo = "Mensual"
    End Sub

    Private Sub _btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnGenerar.Click
        Cargar()
    End Sub

    Sub Cargar()
        If tipo = "Mensual" Then
            Fecha1 = Nothing
            Fecha2 = Nothing
            Mes = 0
            Mes = cmbMes.SelectedIndex + 1
            Fecha1 = 1 & "/" & Mes & "/" & _txtAño.Value
            Fecha2 = DateTime.DaysInMonth(_txtAño.Value, Mes) & "/" & Mes & "/" & _txtAño.Value
            Try
                _gridResumen.DataSource = Conexion.GenerarResumen(Fecha1, Fecha2, _cmbSucursal.SelectedItem)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        ElseIf tipo = "Fechas" Then
            Try
                _gridResumen.DataSource = Conexion.GenerarResumen(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, _cmbSucursal.SelectedItem)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub ExportarAExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Exportar()
    End Sub

    Sub Exportar()
        Try
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()
            wSheet.Name = "Resumen"
            For c As Integer = 0 To _gridResumen.Columns.Count - 1
                wSheet.Cells(2, c + 1).value = _gridResumen.Columns(c).HeaderText
            Next
            For r As Integer = 0 To _gridResumen.RowCount - 1
                For c As Integer = 0 To _gridResumen.Columns.Count - 1
                    wSheet.Cells(r + 3, c + 1).value = _gridResumen.Item(c, r).Value
                    wSheet.Cells(r + 3, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                Next
            Next
            wSheet.Columns.AutoFit()
            excel.Visible = True
            excel.Quit()
        Catch ex As Exception
            MessageBox.Show("Error " & ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Sub exportarTXT(ByVal Ruta As String)
        Dim sFile As String = Ruta & "\Resumen " & Now.Day & "-" & Now.Month & "-" & Now.Year & ".xls "
        Dim _Line As String = Nothing
        Try
            If File.Exists(sFile) = True Then
                My.Computer.FileSystem.DeleteFile(sFile, FileIO.UIOption.OnlyErrorDialogs, _
                                                  FileIO.RecycleOption.DeletePermanently, FileIO.UICancelOption.DoNothing)
            End If
            Dim swFile As StreamWriter = New StreamWriter(sFile, True, System.Text.Encoding.Default)
            With _gridResumen

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
                            .Columns(16).HeaderText
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
                            .Rows(i).Cells(16).Value
                    swFile.WriteLine(_Line)
                Next
            End With
            swFile.Close()
            Process.Start(sFile)
        Catch ex As Exception
            MessageBox.Show("Error" + ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ExportarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportarToolStripMenuItem.Click
        frmGuardarArchivo.MdiParent = _Inicio
        frmGuardarArchivo.Formulario = "Resumen"
        frmGuardarArchivo.Visible = True
    End Sub

    Private Sub MensualToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MensualToolStripMenuItem.Click
        grpMensual.Visible = True
        grpFechas.Visible = False
        tipo = "Mensual"
    End Sub

    Private Sub SeleccionarFechasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SeleccionarFechasToolStripMenuItem.Click
        grpMensual.Visible = False
        grpFechas.Visible = True
        tipo = "Fechas"
    End Sub

    Private Sub CerrarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CerrarToolStripMenuItem.Click
        Me.Close()
    End Sub
End Class