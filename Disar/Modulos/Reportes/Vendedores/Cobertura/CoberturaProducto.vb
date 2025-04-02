Imports Disar.data
Public Class CoberturaProducto
    Dim CoberturaSRC As New cls_coberturas_src
    Dim CoberturaSPS As New cls_coberturas_sps
    Dim CoberturaTocoa As New cls_coberturas_tocoa
    Dim CoberturaTegucigalpa As New cls_coberturasTeg
    Dim ClaseGeneral As New Object
    Dim Tabla As New DataTable
    Dim Lineas As DataRow = Tabla.NewRow()
    Dim ini, fin As Date
    Dim Alma As Integer
    Dim Producto, Universo, UniversoGeneral, Otros As Integer
    Dim Productog, otrosg As Integer

    
    Dim style As Microsoft.Office.Interop.Excel.Style
    Dim nombre As String
    Dim activo As Integer = 0
    Private Sub Cobertura_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inicializardate()
        Me.MdiParent = _Inicio
        LlenarEncabezado()
        _cmbSucursal.SelectedItem = "SRC"
    End Sub

    'Boton para generar los datos
    Private Sub _btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnGenerar.Click
        Iniciar_Variables()
        ini = _cmbFechaInicial.Value.Date
        fin = _cmbFechaFinal.Value.Date
        limpiar()
        Try
            activo = 1
            _gridUniverso.DataSource = ClaseGeneral.ListaUniverso()
            If _cmbFechaFinal.Value.Date < _cmbFechaInicial.Value.Date Then
                MessageBox.Show("La Fecha Final no puede ser menor que la Fecha Inicial", "Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                _cmbFechaFinal.Focus()
            Else
                Dim dbx As New cls_coberturas_src
                For i As Integer = 0 To _gridUniverso.RowCount - 1
                    Lineas("CLAVE") = _gridUniverso.Rows(i).Cells(0).Value
                    Lineas("VENDEDOR") = _gridUniverso.Rows(i).Cells(1).Value
                    Lineas("UNIVERSO") = _gridUniverso.Rows(i).Cells(2).Value
                    Universo = _gridUniverso.Rows(i).Cells(2).Value

                    _gridVentas.DataSource = dbx.VentasXProd(ini, fin, TextProducto.Text, _gridUniverso.Rows(i).Cells(0).Value, Alma)
                    Producto = _gridVentas.RowCount


                    UniversoGeneral += Universo
                    Productog += Producto

                    Lineas(TextProducto.Text) = Producto
                     

                    Lineas("% " & TextProducto.Text) = Math.Round((Producto / Universo) * 100, 2)
                     
                    Tabla.Rows.Add(Lineas)
                    Lineas = Tabla.NewRow()
                Next

                Lineas("CLAVE") = "DISAR SRC"
                Lineas("VENDEDOR") = "TOTAL"
                Lineas("UNIVERSO") = UniversoGeneral

                Lineas(TextProducto.Text) = Productog

                Lineas("% " & TextProducto.Text) = Math.Round((Productog / UniversoGeneral) * 100, 2)
                 
                Tabla.Rows.Add(Lineas)
                Lineas = Tabla.NewRow()
            End If
            Me._GridCobertura.DataSource = Tabla
        Catch ex As Exception
            MessageBox.Show("Error al Generar " + ex.ToString, "Ha ocurrido un Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub Iniciar_Variables()
        UniversoGeneral = 0
        Productog = 0
    End Sub

    'Seleccion de la clase para sucursal
    Private Sub _cmbSucursal_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _cmbSucursal.SelectedIndexChanged
        If _cmbSucursal.SelectedItem = "SRC" Then
            ClaseGeneral = CoberturaSRC
            Alma = 2
        ElseIf _cmbSucursal.SelectedItem = "SPS" Then
            ClaseGeneral = CoberturaSPS
            Alma = 1
        ElseIf _cmbSucursal.SelectedItem = "Saba" Then
            ClaseGeneral = CoberturaTocoa
            Alma = 3
        ElseIf _cmbSucursal.SelectedItem = "Tegucigalpa" Then
            ClaseGeneral = CoberturaTegucigalpa
            Alma = 4
        End If
    End Sub

    'Subrutina para llenar las columnas de la tabla
    Sub LlenarEncabezado()
        Tabla.Columns.Add("CLAVE")
        Tabla.Columns.Add("VENDEDOR")
        Tabla.Columns.Add("UNIVERSO")
        'Tabla.Columns.Add("AMERICA FRESH")
        'Tabla.Columns.Add("GLOBAL PACK")
        'Tabla.Columns.Add("LIVSMART")
        'Tabla.Columns.Add("COMOSA")
        'Tabla.Columns.Add("CARGILL")
        'Tabla.Columns.Add("ZEPOL")
        'Tabla.Columns.Add("BIC")
        'Tabla.Columns.Add("COLGATE")
        'Tabla.Columns.Add("KC")
        'Tabla.Columns.Add("NESTLE")
        'Tabla.Columns.Add("COLOMBINA")
        'Tabla.Columns.Add("FOMPAC")
        'Tabla.Columns.Add("MAYAB")

        'Tabla.Columns.Add("DACASA")
        'Tabla.Columns.Add("QUALA")

        'Tabla.Columns.Add("TRINIDAD MATCH")
        'Tabla.Columns.Add("DCASA")

        'Tabla.Columns.Add("FARINTER")
        'Tabla.Columns.Add("PURINA")
        'Tabla.Columns.Add("GRUPO ALZA")


        'Tabla.Columns.Add("DISAR")

        'Tabla.Columns.Add("% AMERICA FRESH")
        'Tabla.Columns.Add("% GLOBAL PACK")
        'Tabla.Columns.Add("% LIVSMART")
        'Tabla.Columns.Add("% COMOSA")
        'Tabla.Columns.Add("% CARGILL")
        'Tabla.Columns.Add("% ZEPOL")
        'Tabla.Columns.Add("% BIC")
        'Tabla.Columns.Add("% COLGATE")
        'Tabla.Columns.Add("% KC")
        'Tabla.Columns.Add("% NESTLE")
        'Tabla.Columns.Add("% COLOMBINA")
        'Tabla.Columns.Add("% FOMPAC")
        'Tabla.Columns.Add("% MAYAB")

        'Tabla.Columns.Add("% DACASA")
        'Tabla.Columns.Add("% QUALA")

        'Tabla.Columns.Add("% TRINIDAD MATCH")
        'Tabla.Columns.Add("% DCASA")

        'Tabla.Columns.Add("% FARINTER")
        'Tabla.Columns.Add("% PURINA")
        'Tabla.Columns.Add("% GRUPO ALZA")


        'Tabla.Columns.Add("% DISAR")
    End Sub

    'Subrutina para limpiar los datos del grid
    Sub limpiar()
        For c = 0 To _GridCobertura.RowCount - 1
            Tabla.Clear()
        Next
    End Sub

    Private Sub CerrarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CerrarToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ExportarAExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportarAExcelToolStripMenuItem.Click
        Exportar()
    End Sub

    Sub Exportar()
        Try
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()
            wSheet.Name = "Hoja"
            style = wSheet.Application.ActiveWorkbook.Styles.Add("Reportes")
            style.Font.Bold = True
            style.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            style.Font.Size = 11
            style.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            wSheet.Cells.Range("A1:AE1").Merge()
            wSheet.Cells.Range("A1:AE1").Borders.LineStyle = BorderStyle.FixedSingle
            wSheet.Cells.Range("A1:AE1").Value = "Reporte de Coberturas del  " + _cmbFechaInicial.Value.Date + "  al  " + _cmbFechaFinal.Value.Date
            wSheet.Cells.Range("A1:AE1").Style = "Reportes"

            For c As Integer = 0 To _GridCobertura.Columns.Count - 1
                wSheet.Cells(2, c + 1).value = _GridCobertura.Columns(c).HeaderText
                wSheet.Cells(2, c + 1).Style = "Reportes"
            Next
            For r As Integer = 0 To _GridCobertura.RowCount - 1
                For c As Integer = 0 To _GridCobertura.Columns.Count - 1
                    wSheet.Cells(r + 3, c + 1).value = _GridCobertura.Item(c, r).Value
                    wSheet.Cells(r + 3, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    wSheet.Cells(r + 3, c + 1).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                    wSheet.Cells(r + 3, c + 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                Next
            Next
            wSheet.Columns.AutoFit()
            excel.Visible = True
            excel.Quit()
        Catch ex As Exception
            MessageBox.Show("Error al Exportar " + ex.ToString, "Problemas", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub EnviarACorreoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If activo = 1 Then
            CorreoAdjunto()
            Correo.DocAdjunto = "C:\Reportes\Coberturas\Reporte de Coberturas.XLSX"
            Correo._txtAsunto.Text = "Reporte de Coberturas de " + nombre
            Correo.Visible = True
        Else
            MsgBox("Aun no se han Generado los Datos", MsgBoxStyle.Information, "Informacion")
        End If

    End Sub

    Sub CorreoAdjunto()
        Try
            nombre = _cmbFechaInicial.Value.Date + " al " + _cmbFechaFinal.Value.Date
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()
            wSheet.Name = "Hoja"

            style = wSheet.Application.ActiveWorkbook.Styles.Add("Reportes")
            style.Font.Bold = True
            style.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            style.Font.Size = 14
            style.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            wSheet.Cells.Range("A1:O1").Merge()
            wSheet.Cells.Range("A1:O1").Borders.LineStyle = BorderStyle.FixedSingle
            wSheet.Cells.Range("A1:O1").Value = "Reporte de Coberturas del  " + _cmbFechaInicial.Value.Date + "  al  " + _cmbFechaFinal.Value.Date & " - Producto: " & TextProducto.Text
            wSheet.Cells.Range("A1:O1").Style = "Reportes"

            For c As Integer = 0 To _GridCobertura.Columns.Count - 1
                wSheet.Cells(2, c + 1).value = _GridCobertura.Columns(c).HeaderText
                wSheet.Cells(2, c + 1).Style = "Reportes"
            Next
            For r As Integer = 0 To _GridCobertura.RowCount - 1
                For c As Integer = 0 To _GridCobertura.Columns.Count - 1
                    wSheet.Cells(r + 3, c + 1).value = _GridCobertura.Item(c, r).Value
                    wSheet.Cells(r + 3, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    wSheet.Cells(r + 3, c + 1).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                    wSheet.Cells(r + 3, c + 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                Next
            Next
            wSheet.Columns.AutoFit()
            wBook.SaveAs("C:\Reportes\Coberturas\Reporte de Coberturas.XLSX")
            excel.Quit()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub inicializardate()
        _cmbFechaInicial.Value = 1 & "/" & Now.Month & "/" & Now.Year
        If Now.Day = 1 Then
            _cmbFechaFinal.Value = Today
        Else
            _cmbFechaFinal.Value = DateAdd(DateInterval.Day, -1, Now)
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        TextProducto.Text = ""
        TextProductoNombre.Text = ""
        If frm_Carga_Producto.ShowDialog = Windows.Forms.DialogResult.OK Then
            TextProducto.Text = frm_Carga_Producto.ID
            TextProductoNombre.Text = frm_Carga_Producto.Nombre
            Try
                Tabla.Rows.Clear()
            Catch ex As Exception
            End Try
            Try
                Tabla.Columns.Clear()
            Catch ex As Exception
            End Try
            LlenarEncabezado()
            Tabla.Columns.Add(TextProducto.Text)
            Tabla.Columns.Add("% " & TextProducto.Text)

        End If
    End Sub
End Class