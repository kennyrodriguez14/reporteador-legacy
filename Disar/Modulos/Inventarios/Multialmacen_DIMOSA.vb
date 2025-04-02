Imports Disar.data
Public Class Multialmacen_DIMOSA
    Dim Conexion As New clsMultialmacen
    
    Private Sub CerrarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CerrarToolStripMenuItem.Click
        Me.Close()
    End Sub
 
    Private Sub _btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnGenerar.Click
        Cargar()
    End Sub

    Sub Cargar()
        Dim almacen As String

        almacen = cmbsucursal.SelectedValue

        Try
            _gridmultialmacen.DataSource = Conexion.GenerarDatosDimosa(almacen, txtlinea.Text)
            formatearGrid()
        Catch ex As Exception
            MsgBox("Error al cargar los datos " + ex.ToString)
        End Try
    End Sub

    Sub formatearGrid()
        _gridmultialmacen.Columns(0).HeaderText = "Código Almacen"
        _gridmultialmacen.Columns(1).HeaderText = "Almacen"
        _gridmultialmacen.Columns(2).HeaderText = "Código Articulo"
        _gridmultialmacen.Columns(3).HeaderText = "Descripción"
        _gridmultialmacen.Columns(4).HeaderText = "Estatus"
        _gridmultialmacen.Columns(5).HeaderText = "Código Linea"
        _gridmultialmacen.Columns(6).HeaderText = "Linea"
        _gridmultialmacen.Columns(7).HeaderText = "Existencia"
        _gridmultialmacen.Columns(8).HeaderText = "Costo Promedio"
        _gridmultialmacen.Columns(9).HeaderText = "Código SAT"
        _gridmultialmacen.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        _gridmultialmacen.Columns(9).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        _gridmultialmacen.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        _gridmultialmacen.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill



    End Sub


    Private Sub ExportarAExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportarAExcelToolStripMenuItem.Click
        Try
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()
            wSheet.Cells.Range("A1:I1").Merge()
            wSheet.Cells.Range("A1:E1").Value = "Inventarios Generados el " + Now
            wSheet.Cells.Range("A1:E1").Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            wSheet.Cells.Range("A1:E1").Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            wSheet.Cells.Range("A1:E1").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet.Cells.Range("A1:E1").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            wSheet.Cells.Range("A1:E1").Font.Bold = True
            For c As Integer = 0 To _gridmultialmacen.Columns.Count - 1
                wSheet.Cells(2, c + 1).value = _gridmultialmacen.Columns(c).HeaderText
                wSheet.Cells(2, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
            Next
            For r As Integer = 0 To _gridmultialmacen.RowCount - 1
                For c As Integer = 0 To _gridmultialmacen.Columns.Count - 1
                    wSheet.Cells(r + 3, c + 1).value = _gridmultialmacen.Item(c, r).Value
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

    Private Sub Multialmacen_DIMOSA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargaAlmacenes()
    End Sub

    Sub cargaAlmacenes()
        Dim db As New clsMultialmacen
        Try
            cmbsucursal.DataSource = db.CargaAlmacenesDimosa()
            cmbsucursal.ValueMember = "CVE_ALM"
            cmbsucursal.DisplayMember = "DESCR"
        Catch ex As Exception

        End Try
    End Sub
End Class