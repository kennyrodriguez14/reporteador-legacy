Imports Disar.data
Imports System.IO
Public Class frm_pivot_ventas
    Dim Clase As New cls_reporte_carga
    Dim Clase2 As New cls_pivot_ventas
    Dim style, style2 As Microsoft.Office.Interop.Excel.Style
    Dim Tabla As New DataTable
    Dim TotalCan, TotalImp, TotaPes As Integer
    Dim Filas As DataRow = Tabla.NewRow
    Dim Activo As Integer = 0
    Dim Conexion As New cls_rentabilidad
    Private Sub frm_pivot_ventas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cargar_Almacen()
        Cargar_Linea()
    End Sub

    Sub Cargar_Almacen()
        cmbAlmacen.DataSource = Clase.getAlmacen(0, 0, "CONSUMO", Now, "", "ALM", 1)
        cmbAlmacen.ValueMember = "ID"
        cmbAlmacen.DisplayMember = "ALMACEN"
    End Sub

    Sub Cargar_Linea()
        cmb_linea.DataSource = Conexion.CargarProveedores(_cmbFechai.Value.Date, _cmbFechai.Value.Date, "ProveedoresConsumo", 1, "", 1, 1)
        cmb_linea.ValueMember = "ID"
        cmb_linea.DisplayMember = "Nombre"
    End Sub
    

    Sub Exportar()
        Try
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()

            For c As Integer = 0 To grd_pivot_ventas.Columns.Count - 1
                wSheet.Cells(1, c + 1).value = grd_pivot_ventas.Columns(c).HeaderText
            Next
            For r As Integer = 0 To grd_pivot_ventas.RowCount - 1
                For c As Integer = 0 To grd_pivot_ventas.Columns.Count - 1
                    wSheet.Cells(r + 2, c + 1).value = grd_pivot_ventas.Item(c, r).Value
                Next
            Next
            wSheet.Columns.AutoFit()
            excel.Visible = True
            excel.Quit()
        Catch ex As Exception
            MessageBox.Show("Error al Exportar " + ex.ToString, "Problemas", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub _btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnGenerar.Click
        Try
            grd_pivot_ventas.DataSource = Nothing
            If rdbtn_consolidado.Checked = True Then
                grd_pivot_ventas.DataSource = Clase2.GetPivot(_cmbFechai.Value, _cmbFechaf.Value, cmbAlmacen.SelectedValue, cmb_linea.SelectedValue, "CONSOLIDADO")
            ElseIf rdbtn_mensual.Checked = True Then
                grd_pivot_ventas.DataSource = Clase2.GetPivot(_cmbFechai.Value, _cmbFechaf.Value, cmbAlmacen.SelectedValue, cmb_linea.SelectedValue, "MENSUAL")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ExcelRapidoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelRapidoToolStripMenuItem.Click
        frmGuardarArchivo.Formulario = "Pivot"
        frmGuardarArchivo.Visible = True
    End Sub

    Private Sub ExcelNormalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelNormalToolStripMenuItem.Click
        Exportar()
    End Sub

    Sub exportarTXT(ByVal Ruta As String)
        'Dim sFile As String = "C:\Reportes\Resumen Anual\Resumen.xls" 'Ruta.Text & "\Inventry4.txt"
        Dim sFile As String = Ruta & "\PivotVentas " & Now.Day & "-" & Now.Month & "-" & Now.Year & ".xls "
        Dim _Line As String = Nothing
        Try
            If File.Exists(sFile) = True Then
                My.Computer.FileSystem.DeleteFile(sFile, FileIO.UIOption.OnlyErrorDialogs, _
                                                  FileIO.RecycleOption.DeletePermanently, FileIO.UICancelOption.DoNothing)
            End If
            Dim swFile As StreamWriter = New StreamWriter(sFile, True, System.Text.Encoding.Default)
            With grd_pivot_ventas

                For i As Integer = 0 To grd_pivot_ventas.ColumnCount - 1
                    _Line += .Columns(i).HeaderText & vbTab
                Next


                    '.Columns(1).HeaderText & vbTab & _
                    '.Columns(2).HeaderText & vbTab & _
                    '.Columns(3).HeaderText & vbTab & _
                    '.Columns(4).HeaderText & vbTab & _
                    '.Columns(5).HeaderText & vbTab & _
                    '.Columns(6).HeaderText & vbTab & _
                    '.Columns(7).HeaderText & vbTab & _
                    '.Columns(8).HeaderText & vbTab & _
                    '.Columns(9).HeaderText & vbTab & _
                    '.Columns(10).HeaderText & vbTab & _
                    '.Columns(11).HeaderText & vbTab & _
                    '.Columns(12).HeaderText & vbTab & _
                    '.Columns(13).HeaderText


                swFile.WriteLine(_Line)

                For i = 0 To .RowCount - 1
                    _Line = ""
                    For j As Integer = 0 To .ColumnCount - 1
                        _Line &= .Rows(i).Cells(j).Value & vbTab
                    Next

                    '_Line = .Rows(i).Cells(0).Value & vbTab & _
                    '        .Rows(i).Cells(1).Value & vbTab & _
                    '        .Rows(i).Cells(2).Value & vbTab & _
                    '        .Rows(i).Cells(3).Value & vbTab & _
                    '        .Rows(i).Cells(4).Value & vbTab & _
                    '        .Rows(i).Cells(5).Value & vbTab & _
                    '        .Rows(i).Cells(6).Value & vbTab & _
                    '        .Rows(i).Cells(7).Value & vbTab & _
                    '        .Rows(i).Cells(8).Value & vbTab & _
                    '        .Rows(i).Cells(9).Value & vbTab & _
                    '        .Rows(i).Cells(10).Value & vbTab & _
                    '        .Rows(i).Cells(11).Value & vbTab & _
                    '        .Rows(i).Cells(12).Value & vbTab & _
                    '        .Rows(i).Cells(13).Value
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

    Private Sub ToolStripDropDownButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripDropDownButton1.Click

    End Sub
End Class