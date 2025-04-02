Imports Disar.data
Imports System.IO
Imports System.Data
Imports System.Reflection
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class Frm_Asignaciones

    Dim direccion_archivo = ""

    Private Sub Frm_Asignaciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LlenarCategorias()
        LlenarDatos()
    End Sub

    Sub LlenarCategorias()
        Try
            Dim db As New clsInventarioIT
            ComboCat.DataSource = db.VerCategoriasBusqueda
            ComboCat.DisplayMember = "CategoriaNombre"
            ComboCat.ValueMember = "CategoriaID"
            ComboCat.SelectedItem = Nothing
        Catch ex As Exception
        End Try
    End Sub

    Sub LlenarDatos()
        Try
            Dim db As New clsInventarioIT
            DataDatos.DataSource = db.VerAsignaciones
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TextBuscar_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBuscar.KeyDown
        If e.KeyData = Keys.Enter Then
            Try
                Dim db As New clsInventarioIT
                DataDatos.DataSource = db.BuscarAsignaciones(TextBuscar.Text)
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub ComboCat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboCat.SelectedIndexChanged
        If ComboCat.Text = "Todas" Then
            LlenarDatos()
        Else
            Try
                Dim db As New clsInventarioIT
                DataDatos.DataSource = db.FiltrarAsignacionesPorTipo(ComboCat.SelectedValue)
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub DataDatos_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataDatos.CellDoubleClick
        BtnHoja.PerformClick()
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Exportar()
    End Sub

    Sub Exportar()
        Try
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet
            wSheet.Cells.Range("A1:M1").Merge()
            wSheet.Cells.Range("A1:M1").Value = "INVENTARIO DE EQUIPO [SISTEMAS Y TECNOLOGÍA] - ASIGNACIONES "
            wSheet.Cells.Range("A1:M1").Font.Color = System.Drawing.ColorTranslator.ToOle(Drawing.Color.Black)
            wSheet.Cells.Range("A1:M1").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet.Cells.Range("A1:M1").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            wSheet.Cells.Range("A1:M1").Font.Bold = True
            For c As Integer = 0 To DataDatos.Columns.Count - 1
                wSheet.Cells(2, c + 1).value = DataDatos.Columns(c).HeaderText
                wSheet.Cells(2, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
            Next
            For r As Integer = 0 To DataDatos.RowCount - 1
                For c As Integer = 0 To DataDatos.Columns.Count - 1
                    wSheet.Cells(r + 3, c + 1).value = DataDatos.Item(c, r).Value
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

    Private Sub BtnHoja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnHoja.Click
        Try
            FolderBrowserDialog1.Description = "Guardar Remision"
            If FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                direccion_archivo = FolderBrowserDialog1.SelectedPath + "\"
            End If

            ImprimirRemision_DISAR()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub ImprimirRemision_DISAR()

        Dim tabla_encabezado As New PdfPTable(3)
        tabla_encabezado.DefaultCell.Padding = 3
        tabla_encabezado.DefaultCell.BorderColor = Color.White
        tabla_encabezado.HorizontalAlignment = Element.ALIGN_CENTER
        tabla_encabezado.WidthPercentage = (500 / 5.1F)
        tabla_encabezado.SetWidths(New Integer() {1, 4, 1})
        tabla_encabezado.SpacingAfter = 20

        Dim tabla_sub_encabezado As New PdfPTable(3)
        tabla_sub_encabezado.DefaultCell.Padding = 3
        tabla_sub_encabezado.DefaultCell.BorderColor = Color.White
        tabla_sub_encabezado.HorizontalAlignment = Element.ALIGN_CENTER
        tabla_sub_encabezado.WidthPercentage = (400 / 5.23F)
        tabla_sub_encabezado.SetWidths(New Integer() {4, 0, 2})

        Dim tabla_transportista As New PdfPTable(3)
        tabla_transportista.DefaultCell.Padding = 3
        tabla_transportista.DefaultCell.BorderColor = Color.White
        tabla_transportista.HorizontalAlignment = Element.ALIGN_CENTER
        tabla_transportista.WidthPercentage = (400 / 5.23F)
        tabla_transportista.SetWidths(New Integer() {1, 4, 1})

        Dim tabla_motivo As New PdfPTable(5)
        tabla_motivo.DefaultCell.Padding = 3
        tabla_motivo.HorizontalAlignment = Element.ALIGN_CENTER
        tabla_motivo.WidthPercentage = (385 / 5.23F)
        tabla_motivo.SetWidths(New Integer() {1, 4, 1, 1, 2})
        tabla_motivo.SpacingBefore = 20

        Dim tabla_datos_adicionales As New PdfPTable(2)
        tabla_datos_adicionales.DefaultCell.Padding = 3
        tabla_datos_adicionales.DefaultCell.BorderColor = Color.White
        tabla_datos_adicionales.HorizontalAlignment = Element.ALIGN_CENTER
        tabla_datos_adicionales.WidthPercentage = (385 / 5.23F)
        tabla_datos_adicionales.SetWidths(New Integer() {1, 5})
        tabla_datos_adicionales.SpacingBefore = 20

        Dim tabla_fimas As New PdfPTable(2)
        tabla_fimas.DefaultCell.Padding = 3
        tabla_fimas.DefaultCell.BorderColor = Color.White
        tabla_fimas.HorizontalAlignment = Element.ALIGN_CENTER
        tabla_fimas.WidthPercentage = (300 / 5.23F)
        tabla_fimas.SetWidths(New Integer() {1, 1})
        tabla_fimas.SpacingBefore = 120

        'Exporting to PDF
        If direccion_archivo = "" Then
            direccion_archivo = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\"
            'If Not Directory.Exists(direccion_archivo) Then
            '    Directory.CreateDirectory(direccion_archivo)
            'End If
        End If

        Using stream As New FileStream(direccion_archivo & "Hoja de Entrega " & DataDatos.CurrentRow.Cells(0).Value & ".pdf", FileMode.Create)
            Dim pdfDoc As New Document(PageSize.A2, 10.0F, 10.0F, 10.0F, 0.0F)
            PdfWriter.GetInstance(pdfDoc, stream)
            pdfDoc.Open()

            Dim logo As Image
            Dim recurso As String = My.Computer.FileSystem.CurrentDirectory
            logo = Image.GetInstance(recurso & "\Resources\DISTRIBUIDORA_SAN_RAFAEL.png")
            tabla_encabezado.AddCell(logo)
            Dim cell As New PdfPCell(New Phrase("DISTRIBUIDORA SAN RAFAEL S. de R.L. de C.V. " & vbCrLf & _
                            "Formulario de Transferencia de Equipo  " & vbCrLf & _
                            "Departamento de I.T. ", FontFactory.GetFont("arial", 20, Font.Bold, Color.BLACK)))
            cell.BorderColor = Color.WHITE
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tabla_encabezado.AddCell(cell)
            tabla_encabezado.AddCell(New Phrase("No. Transferencia: " & vbCrLf & _
                            DataDatos.CurrentRow.Cells(0).Value, FontFactory.GetFont("arial", 18, Font.Bold, Color.RED)))

            tabla_sub_encabezado.AddCell(New Phrase("Fecha de Impresión: " & Today.Date, FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))
            tabla_sub_encabezado.AddCell("")
            tabla_sub_encabezado.AddCell("")
            tabla_sub_encabezado.AddCell(New Phrase("Nombre de quien entrega:     " & DataDatos.CurrentRow.Cells("Persona que entregó").Value & vbCrLf & "Departamento:         " & "Sistemas y Tecnología" & vbCrLf & _
                                         "" & "", FontFactory.GetFont("arial", 16, Font.Bold, Color.BLACK)))
            tabla_sub_encabezado.AddCell("")
            tabla_sub_encabezado.AddCell(New Phrase("Nombre de quien recibe: " & DataDatos.CurrentRow.Cells("Asignado a").Value & vbCrLf & "Departamento: " & DataDatos.CurrentRow.Cells("Departamento").Value, FontFactory.GetFont("arial", 16, Font.Bold, Color.BLACK)))
            'tabla_sub_encabezado.AddCell(New Phrase("Departamento:    " & "" & vbCrLf & "RTN:         " & "" & vbCrLf & _
            '                            "" & "", FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))

            tabla_sub_encabezado.AddCell("")
            tabla_sub_encabezado.AddCell(New Phrase("Fecha de entrega: " & vbCrLf & DataDatos.CurrentRow.Cells("Fecha").Value, FontFactory.GetFont("arial", 14, Font.Bold, Color.BLACK)))

            tabla_sub_encabezado.AddCell(New Phrase("Límite: " & vbCrLf & DataDatos.CurrentRow.Cells("Límite Fecha").Value, FontFactory.GetFont("arial", 14, Font.Bold, Color.BLACK)))

            tabla_transportista.AddCell("")
            tabla_transportista.AddCell(New Phrase("      " & "" & vbCrLf & _
                                        "      " & "" & vbCrLf & _
                                        "      " & "" & vbCrLf & _
                                        "      " & "", FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))
            tabla_transportista.AddCell("      ")



            Dim cell_motivo As New PdfPCell(New Phrase("Motivo: ", FontFactory.GetFont("arial", 16, Font.Bold, Color.BLACK)))
            cell_motivo.BackgroundColor = Color.GRAY
            tabla_motivo.AddCell(cell_motivo)

            Dim cell_motivo_des As New PdfPCell(New Phrase("", FontFactory.GetFont("arial", 16, Font.Bold, Color.BLACK)))
            cell_motivo_des.BackgroundColor = Color.GRAY
            tabla_motivo.AddCell(cell_motivo_des)

            Dim cell_motivo_sangria As New PdfPCell(New Phrase(""))
            cell_motivo_sangria.BorderColor = Color.WHITE
            tabla_motivo.AddCell(cell_motivo_sangria)

            Dim cell_peso_titulo As New PdfPCell(New Phrase("Peso Total: ", FontFactory.GetFont("arial", 16, Font.Bold, Color.BLACK)))
            cell_peso_titulo.BackgroundColor = Color.GRAY
            tabla_motivo.AddCell(cell_peso_titulo)

            Dim cell_peso_valor As New PdfPCell(New Phrase("", FontFactory.GetFont("arial", 16, Font.Bold, Color.BLACK)))
            cell_peso_valor.BackgroundColor = Color.GRAY
            tabla_motivo.AddCell(cell_peso_valor)

            tabla_datos_adicionales.AddCell("Rango: ")
            tabla_datos_adicionales.AddCell("")

            tabla_datos_adicionales.AddCell("Fecha limite impresión: ")
            tabla_datos_adicionales.AddCell("")

            tabla_datos_adicionales.AddCell("Original Destinatario")
            tabla_datos_adicionales.AddCell("")
            tabla_datos_adicionales.AddCell("Copia1	Remitente")
            tabla_datos_adicionales.AddCell("")
            tabla_datos_adicionales.AddCell("Copia2	DEI")
            tabla_datos_adicionales.AddCell("")

            tabla_fimas.AddCell("                    ____________________________________")
            tabla_fimas.AddCell("                    ____________________________________")
            tabla_fimas.AddCell("                                            Firma remitente       ")
            tabla_fimas.AddCell("                                             Firma destino        ")

            pdfDoc.Add(tabla_encabezado)
            pdfDoc.Add(tabla_sub_encabezado)
            pdfDoc.Add(tabla_transportista)
            pdfDoc.Add(tabla_motivo)
            pdfDoc.Add(tabla_fimas)
            pdfDoc.Add(tabla_datos_adicionales)
            pdfDoc.Close()
            stream.Close()

            Process.Start(direccion_archivo & "Hoja de Entrega " & DataDatos.CurrentRow.Cells(0).Value & ".pdf")
        End Using
    End Sub

End Class