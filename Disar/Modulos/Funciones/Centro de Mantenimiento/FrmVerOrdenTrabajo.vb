Imports System.IO
Imports System.Data
Imports System.Reflection
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports Disar.data

Public Class FrmVerOrdenTrabajo

    Dim direccion_archivo = ""

    Private Sub BtnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExportar.Click
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

        Dim tabla_grilla As New PdfPTable(8)
        tabla_grilla.DefaultCell.Padding = 3
        tabla_grilla.WidthPercentage = 30
        tabla_grilla.HorizontalAlignment = Element.ALIGN_LEFT
        tabla_grilla.DefaultCell.BorderWidth = 1
        tabla_grilla.WidthPercentage = (480 / 5.23F)
        tabla_grilla.SetWidths(New Integer() {1, 1, 5, 1, 1, 1, 1, 1})
        tabla_grilla.SpacingBefore = 20

        Dim tabla_motivo As New PdfPTable(1)
        tabla_motivo.DefaultCell.Padding = 3
        tabla_motivo.HorizontalAlignment = Element.ALIGN_CENTER
        tabla_motivo.WidthPercentage = (385 / 5.23F)
        tabla_motivo.SetWidths(New Integer() {1})
        tabla_motivo.SpacingBefore = 20

        Dim tabla_datos_adicionales As New PdfPTable(1)
        tabla_datos_adicionales.DefaultCell.Padding = 3
        tabla_datos_adicionales.DefaultCell.BorderColor = Color.White
        tabla_datos_adicionales.HorizontalAlignment = Element.ALIGN_CENTER
        tabla_datos_adicionales.WidthPercentage = (385 / 5.23F)
        tabla_datos_adicionales.SetWidths(New Integer() {5})
        tabla_datos_adicionales.SpacingBefore = 20

        Dim tabla_fimas As New PdfPTable(3)
        tabla_fimas.DefaultCell.Padding = 3
        tabla_fimas.DefaultCell.BorderColor = Color.White
        tabla_fimas.HorizontalAlignment = Element.ALIGN_CENTER
        tabla_fimas.WidthPercentage = (300 / 5.23F)
        tabla_fimas.SetWidths(New Integer() {3, 3, 3})
        tabla_fimas.SpacingBefore = 120

        Dim tabla_fimas2 As New PdfPTable(3)
        tabla_fimas2.DefaultCell.Padding = 3
        tabla_fimas2.DefaultCell.BorderColor = Color.WHITE
        tabla_fimas2.HorizontalAlignment = Element.ALIGN_CENTER
        tabla_fimas2.WidthPercentage = (300 / 5.23F)
        tabla_fimas2.SetWidths(New Integer() {3, 3, 3})
        tabla_fimas2.SpacingBefore = 120

        'Exporting to PDF
        If direccion_archivo = "" Then
            direccion_archivo = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\"
            'If Not Directory.Exists(direccion_archivo) Then
            '    Directory.CreateDirectory(direccion_archivo)
            'End If
        End If

        Using stream As New FileStream(direccion_archivo & "Orden de Trabajo " & NumeroDeOrden.Text & ".pdf", FileMode.Create)
            Dim pdfDoc As New Document(PageSize.A2, 10.0F, 10.0F, 10.0F, 0.0F)
            PdfWriter.GetInstance(pdfDoc, stream)
            pdfDoc.Open()

            Dim logo As Image
            Dim recurso As String = My.Computer.FileSystem.CurrentDirectory
            logo = Image.GetInstance(recurso & "\Resources\DISTRIBUIDORA_SAN_RAFAEL.png")
            tabla_encabezado.AddCell(logo)
            Dim cell As New PdfPCell(New Phrase("DISTRIBUIDORA SAN RAFAEL S. de R.L. de C.V. " & vbCrLf & _
                            "Política y Procedimientos mantenimiento y reparación de vehículos  " & vbCrLf & _
                            "Mantenimiento: " & Orden.Text, FontFactory.GetFont("arial", 20, Font.Bold, Color.BLACK)))
            cell.BorderColor = Color.WHITE
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tabla_encabezado.AddCell(cell)
            tabla_encabezado.AddCell(New Phrase("Orden # " & NumeroDeOrden.Text & vbCrLf & _
                            "", FontFactory.GetFont("arial", 20, Font.Bold, Color.RED)))

            tabla_sub_encabezado.AddCell(New Phrase("Fecha: " & Today.Date, FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))
            tabla_sub_encabezado.AddCell("")
            tabla_sub_encabezado.AddCell("")
            tabla_sub_encabezado.AddCell(New Phrase("Vehículo:     " & TextVehiculo.Text & vbCrLf & "Kilometraje:         " & TextKilometraje.Text & vbCrLf & _
                                         "", FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))
            tabla_sub_encabezado.AddCell("")
            tabla_sub_encabezado.AddCell(New Phrase("Entrada: " & FechaIngreso.Text & " : " & HoraIngreso.Text & vbCrLf & "Salida:    " & FechaSalida.Text & " : " & HoraSalida.Text & vbCrLf, FontFactory.GetFont("arial", 14, Font.Bold, Color.BLACK)))

            Dim cell_sangria_titulo As New PdfPCell(New Phrase(""))
            cell_sangria_titulo.BorderColor = Color.WHITE
            tabla_grilla.AddCell(cell_sangria_titulo)
            For index As Integer = 0 To DataDatos.ColumnCount - 1
                'If grd_detalle.Columns(index).HeaderText <> "CONLOTE" Then
                Dim cell_encabezado As New PdfPCell(New Phrase(DataDatos.Columns(index).HeaderText.ToUpper, FontFactory.GetFont("arial", 16, Font.Bold, Color.WHITE)))
                cell_encabezado.BackgroundColor = Color.DARK_GRAY
                tabla_grilla.AddCell(cell_encabezado)
                'End If

            Next

            For i As Integer = 0 To DataDatos.RowCount - 1
                Dim cell_sangria_contenido As New PdfPCell(New Phrase(""))
                cell_sangria_contenido.BorderColor = Color.WHITE
                tabla_grilla.AddCell(cell_sangria_contenido)
                For j As Integer = 0 To DataDatos.ColumnCount - 1
                    'If grd_detalle.Columns(j).HeaderText <> "CONLOTE" Then
                    tabla_grilla.AddCell(New Phrase(Convert.ToString(DataDatos.Rows(i).Cells(j).Value), FontFactory.GetFont("arial", 16, Font.Bold, Color.BLACK)))
                    'End If
                Next
            Next

            Dim cell2 As New PdfPCell(New Phrase("" & vbCrLf & _
                            "", FontFactory.GetFont("arial", 20, Font.Bold, Color.BLACK)))
            cell2.BorderColor = Color.WHITE
            cell2.HorizontalAlignment = Element.ALIGN_CENTER

            tabla_motivo.AddCell(cell2)
            tabla_motivo.AddCell(cell2)
            tabla_motivo.AddCell(cell2)
            tabla_motivo.AddCell(cell2)
            tabla_motivo.AddCell(cell2)

            tabla_datos_adicionales.AddCell("Observaciones:" & vbCrLf & TextObservaciones.Text)

            tabla_fimas.AddCell("")
            tabla_fimas.AddCell("________________________________" & vbCrLf & "                 Firma Mantenimiento")
            tabla_fimas.AddCell("")

            tabla_fimas2.AddCell("________________________________" & vbCrLf & "              Gerente Operaciones")
            tabla_fimas2.AddCell("________________________________" & vbCrLf & "                   Contador Senior")
            tabla_fimas2.AddCell("________________________________" & vbCrLf & "                   Contador General")
            tabla_fimas2.AddCell("")
            tabla_fimas2.AddCell("")
            tabla_fimas2.AddCell("")
            tabla_fimas2.AddCell("")
            tabla_fimas2.AddCell("")
            tabla_fimas2.AddCell("")
            tabla_fimas2.AddCell("________________________________" & vbCrLf & "                   Contador General")
            tabla_fimas2.AddCell("________________________________" & vbCrLf & "                  Auditoría Interna")
            tabla_fimas2.AddCell("________________________________" & vbCrLf & "         Gerente de Talento Humano")

            pdfDoc.Add(tabla_motivo)
            pdfDoc.Add(tabla_encabezado)
            pdfDoc.Add(tabla_sub_encabezado)
            pdfDoc.Add(tabla_grilla)
            pdfDoc.Add(tabla_transportista)
            pdfDoc.Add(tabla_datos_adicionales)
            pdfDoc.Add(tabla_fimas)
            pdfDoc.Add(tabla_fimas2)

            pdfDoc.Close()
            stream.Close()

            Process.Start(direccion_archivo & "Orden de Trabajo " & NumeroDeOrden.Text & ".pdf")
        End Using
    End Sub
End Class