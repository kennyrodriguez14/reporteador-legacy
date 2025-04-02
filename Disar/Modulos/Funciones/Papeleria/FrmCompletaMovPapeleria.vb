Imports Disar.data
Imports System.Reflection
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO

Public Class FrmCompletaMovPapeleria

    Public Direccion_archivo

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        Dim dt As New DataTable
        Dim db As New ClsPapeleria

        For Each column As DataGridViewColumn In DataDatos.Columns
            dt.Columns.Add(column.HeaderText)
        Next
        For Each Row As DataGridViewRow In DataDatos.Rows
            dt.Rows.Add(Row.Cells(0).Value, Row.Cells(1).Value, Row.Cells(2).Value)
        Next

        Dim s = db.CompletarMovimiento(TextID.Text, ComboAlmacen.Text, TextNickSolicitante.Text, _Inicio.lblUsuario.Text, dt, Today.Date)

        If s = "correcto" Then
            MsgBox("Se completó la solicitud exitosamente.", MsgBoxStyle.Information, "Solicitud Completada")
            ExportarPDF()
            GuardarPDF()
        End If
        
    End Sub

    Sub ExportarPDF()
        Try
            FolderBrowserDialog1.Description = "Guardar Solicitud de Préstamo"
            If FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                Direccion_archivo = FolderBrowserDialog1.SelectedPath + "\"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub GuardarPDF()

        Dim tabla_encabezado As New PdfPTable(3)
        tabla_encabezado.DefaultCell.Padding = 3
        tabla_encabezado.DefaultCell.BorderColor = Color.White
        tabla_encabezado.HorizontalAlignment = Element.ALIGN_CENTER
        tabla_encabezado.WidthPercentage = (500 / 5.1F)
        tabla_encabezado.SetWidths(New Integer() {2, 4, 2})

        Dim tabla_sub_encabezado As New PdfPTable(2)
        tabla_sub_encabezado.DefaultCell.Padding = 3
        tabla_sub_encabezado.DefaultCell.BorderColor = Color.White
        tabla_sub_encabezado.HorizontalAlignment = Element.ALIGN_CENTER
        tabla_sub_encabezado.WidthPercentage = (400 / 5.23F)
        tabla_sub_encabezado.SetWidths(New Integer() {1, 10})
        tabla_sub_encabezado.SpacingBefore = 20

        Dim tabla_grilla As New PdfPTable(4)
        tabla_grilla.DefaultCell.Padding = 3
        tabla_grilla.WidthPercentage = 30
        tabla_grilla.HorizontalAlignment = Element.ALIGN_LEFT
        tabla_grilla.DefaultCell.BorderWidth = 1
        tabla_grilla.WidthPercentage = (480 / 5.23F)

        tabla_grilla.SetWidths(New Integer() {1, 1, 3, 2})
        tabla_grilla.SpacingBefore = 5

        'Exporting to PDF
        If Direccion_archivo = "" Then
            Direccion_archivo = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\"
            'If Not Directory.Exists(direccion_archivo) Then
            '    Directory.CreateDirectory(direccion_archivo)
            'End If
        End If
        Dim Sucursal As String = ""

        Using stream As New FileStream(Direccion_archivo & "Papeleria " & Today.Date.Day & "-" & Today.Date.Month & "-" & Today.Date.Year & ".pdf", FileMode.Create)
            Dim pdfDoc As New Document(PageSize.LETTER, 10, 10, 10, 20)
            PdfWriter.GetInstance(pdfDoc, stream)
            pdfDoc.Open()

            Dim logo As Image
            Dim recurso As String = My.Computer.FileSystem.CurrentDirectory

            If ComboAlmacen.Text = "SR AGRO SRC" Then
                logo = Image.GetInstance(recurso & "\Resources\SR AGRO LOGO.jpg")
            Else
                logo = Image.GetInstance(recurso & "\Resources\DISTRIBUIDORA_SAN_RAFAEL.png")
            End If


            Dim Fecha As Integer
            Fecha = pdfDoc.AddCreationDate
            tabla_encabezado.AddCell(logo)

            Dim cell As New PdfPCell(New Phrase("" & vbNewLine & " DISTRIBUIDORA SAN RAFAEL " & vbNewLine & _
                            " MOVIMIENTOS DE PAPELERIA " & vbNewLine & " ALMACEN: " & ComboAlmacen.Text, FontFactory.GetFont("arial", 12, Font.Bold, Color.BLACK)))
            cell.BorderColor = Color.WHITE
            cell.HorizontalAlignment = Element.ALIGN_CENTER

            tabla_encabezado.AddCell(cell)
            tabla_encabezado.AddCell("" & vbNewLine & "Fecha: " & Today.Date & vbNewLine & vbNewLine)
            tabla_encabezado.AddCell("")
            tabla_encabezado.AddCell("" & vbNewLine & vbNewLine)
            tabla_encabezado.AddCell("" & vbNewLine & vbNewLine)
            tabla_encabezado.AddCell("" & vbNewLine & vbNewLine)

            tabla_sub_encabezado.AddCell("")

            Dim cell2 As New PdfPCell(New Phrase("Firma Recibido: ____________________    Firma Entregado: ____________________", FontFactory.GetFont("arial", 10, Font.Bold, Color.BLACK)))
            cell2.BorderColor = Color.WHITE
            cell2.HorizontalAlignment = Element.ALIGN_CENTER


            tabla_sub_encabezado.AddCell(cell2)
            'tabla_sub_encabezado.AddCell("")
            Dim cell_sangria_contenido As New PdfPCell(New Phrase(""))
            cell_sangria_contenido.BorderColor = Color.WHITE

            tabla_grilla.AddCell(cell_sangria_contenido)

            For a As Integer = 0 To DataDatos.Columns.Count - 1
                Dim cell_encabezado As New PdfPCell(New Phrase(DataDatos.Columns(a).HeaderText, FontFactory.GetFont("arial", 9, Font.Bold, Color.BLACK)))
                cell_encabezado.BackgroundColor = Color.GRAY
                tabla_grilla.AddCell(cell_encabezado)
            Next

            For Each row As Windows.Forms.DataGridViewRow In DataDatos.Rows
                tabla_grilla.AddCell(cell_sangria_contenido)
                For Each column As Windows.Forms.DataGridViewColumn In DataDatos.Columns
                    tabla_grilla.AddCell(New Phrase(Convert.ToString(row.Cells(column.Index).Value), FontFactory.GetFont("arial", 9, Font.Bold, Color.BLACK)))
                Next
            Next

            pdfDoc.Add(tabla_encabezado)
            pdfDoc.Add(tabla_grilla)
            pdfDoc.Add(tabla_sub_encabezado)

            pdfDoc.Close()
            stream.Close()

            'Adjunto = Direccion_archivo & "Pedido " & ComboProv.Text & " Numero " & Numero & ".pdf"
            Process.Start(Direccion_archivo & "Papeleria " & Today.Date.Day & "-" & Today.Date.Month & "-" & Today.Date.Year & ".pdf")
        End Using

    End Sub
End Class