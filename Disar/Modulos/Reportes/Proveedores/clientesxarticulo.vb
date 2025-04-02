Imports Disar.data
Public Class clientesxarticulo
    Dim Dias As Integer
    Dim Fecha As Date
    Dim Conexion As New cls_clientes_por_articulo
    Dim Tablas As New DataTable
    Dim filas6 As DataRow = Tablas.NewRow()
    Dim Suma As Double

    Private Sub _btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnGenerar.Click
        Tablas.Clear()
        Tablas.Columns.Clear()
        Tablas.Columns.Add("CLIENTE")
        Tablas.Columns.Add("FECHA")
        Tablas.Columns.Add("ARTICULO")
        Tablas.Columns.Add("TOTAL")


        Try
            Suma = 0
            Dim almacen As Integer = 0
            If cmbSucursal.SelectedItem = "SRC" Then
                almacen = 2
            ElseIf cmbSucursal.SelectedItem = "SPS" Then
                almacen = 1
            ElseIf cmbSucursal.SelectedItem = "Saba" Then
                almacen = 3
            Else
                almacen = 4
            End If
            Grid.DataSource = Conexion.GenerarDatos(f1.Value.Date, f2.Value.Date, txtnombre.Text, txtnombre.Text.ToUpper, cmbTbusqueda.SelectedItem, almacen)
            For i As Integer = 0 To Grid.RowCount - 1
                If i = 0 Then
                    filas6("CLIENTE") = Grid.Rows(i).Cells(1).Value
                    filas6("FECHA") = Grid.Rows(i).Cells(3).Value
                    Suma = 0
                Else
                    If Grid.Rows(i).Cells(0).Value <> Grid.Rows(i - 1).Cells(0).Value Then
                        filas6("TOTAL") = Suma
                        Tablas.Rows.Add(filas6)
                        filas6 = Tablas.NewRow()

                        filas6("CLIENTE") = Grid.Rows(i).Cells(1).Value
                        filas6("FECHA") = Grid.Rows(i).Cells(3).Value
                        Suma = 0
                    ElseIf Grid.Rows(i).Cells(3).Value <> Grid.Rows(i - 1).Cells(3).Value Then
                        filas6("TOTAL") = Suma
                        Tablas.Rows.Add(filas6)
                        filas6 = Tablas.NewRow()
                        filas6("FECHA") = Grid.Rows(i).Cells(3).Value
                        Suma = 0
                    End If
                End If
                filas6("ARTICULO") = Grid.Rows(i).Cells(2).Value
                filas6("TOTAL") = Grid.Rows(i).Cells(4).Value
                Tablas.Rows.Add(filas6)
                filas6 = Tablas.NewRow()
                Suma += Grid.Rows(i).Cells(4).Value
                If i = Grid.RowCount - 1 Then
                    filas6("TOTAL") = Suma
                    Tablas.Rows.Add(filas6)
                    filas6 = Tablas.NewRow()
                End If
            Next
        Catch ex As Exception
            MsgBox("Error al cargar los datos " + ex.ToString)
        End Try
        Grid.DataSource = Tablas
    End Sub

    Private Sub clientesxarticulo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inicializardate()
        cmbSucursal.SelectedItem = "SPS"
        cmbTbusqueda.SelectedItem = "CODIGO"
    End Sub

    Sub inicializardate()
        f1.Value = 1 & "/" & Now.Month & "/" & Now.Year
        If Now.Day = 1 Then
            f2.Value = Today
        Else
            f2.Value = DateAdd(DateInterval.Day, -1, Now)
        End If
    End Sub

    Private Sub cmbTbusqueda_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTbusqueda.SelectedIndexChanged
        If cmbTbusqueda.SelectedItem = "TODOS" Then
            txtnombre.Enabled = False
            txtnombre.Text = ""
        Else
            txtnombre.Enabled = True
            txtnombre.Text = ""
        End If
    End Sub

    Private Sub ExportarAExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportarAExcelToolStripMenuItem.Click
        'Dinamic3()
        Exportar()
    End Sub

    Sub Exportar()
        Try
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()
            wSheet.Name = "Clientes por Articulo"
            'style = wSheet.Application.ActiveWorkbook.Styles.Add("Reportes")
            'style.Font.Bold = True
            'style.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            'style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            'style.Font.Size = 11
            'style.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            'style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            'wSheet.Cells.Range("A1:D8").Value = "REPORTE DE CAJAS DE LIVSMART AL " + _cmbFechaf.Value.Date
            'Clipboard.Clear()
            'Clipboard.SetData(System.Windows.Forms.DataFormats.Bitmap, Imagen.Image) 'imagen en picturebox Picture1 formato .bmp 
            'wSheet.Cells.Range("A1").Select()
            'Try
            'wSheet.Paste()
            'Catch ex As Exception
            'End Try
            For c As Integer = 0 To Grid.Columns.Count - 1
                wSheet.Cells(2, c + 1).value = Grid.Columns(c).HeaderText
                'wSheet.Cells(9, c + 1).Style = "Reportes"
                wSheet.Cells(2, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)

            Next
            For r As Integer = 0 To Grid.RowCount - 1
                For c As Integer = 0 To Grid.Columns.Count - 1
                    wSheet.Cells(r + 3, c + 1).value = Grid.Item(c, r).Value
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

    Private Sub CerrarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CerrarToolStripMenuItem.Click
        Me.Close()
    End Sub
End Class