Imports System.IO
Imports System.Data
Imports System.Reflection
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports Disar.data

Public Class frm_guia_remision_detalles

    Dim direccion_archivo = ""
    Public rtn_remite As String = "", direccion_remite As String = "", rtn_destino As String = "", direccion_destino As String = ""
    Public rtn_transportista As String = "", marca As String = "", placa As String = "", rango As String = ""
    Public fecha_limite As Date
    Dim conexion As New cls_remisiones
    Dim fila As Integer
    Public CODREM As Integer, CODDEST As Integer
    Public TipoRemision As String


    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub NuevoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevoToolStripMenuItem.Click
        Try
            FolderBrowserDialog1.Description = "Guardar Remision"
            If FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK _
             Then
                direccion_archivo = FolderBrowserDialog1.SelectedPath + "\"
            End If

            If txt_empresa.Text = "CONSUMO" Or txt_empresa.Text = "DIMOSA" Or txt_empresa.Text = "FLOTA" Then
                ImprimirRemision_DISAR()
            ElseIf txt_empresa.Text = "SR AGRO" Then
                ImprimirRemision_SRAGRO()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub ImprimirRemision_DISAR()

        Dim tabla_encabezado As New PdfPTable(3)
        tabla_encabezado.DefaultCell.Padding = 3
        tabla_encabezado.DefaultCell.BorderColor = Color.WHITE
        tabla_encabezado.HorizontalAlignment = Element.ALIGN_CENTER
        tabla_encabezado.WidthPercentage = (500 / 5.1F)
        tabla_encabezado.SetWidths(New Integer() {1, 4, 1})
        tabla_encabezado.SpacingAfter = 20

        Dim tabla_sub_encabezado As New PdfPTable(3)
        tabla_sub_encabezado.DefaultCell.Padding = 3
        tabla_sub_encabezado.DefaultCell.BorderColor = Color.WHITE
        tabla_sub_encabezado.HorizontalAlignment = Element.ALIGN_CENTER
        tabla_sub_encabezado.WidthPercentage = (400 / 5.23F)
        tabla_sub_encabezado.SetWidths(New Integer() {4, 0, 2})

        Dim tabla_transportista As New PdfPTable(3)
        tabla_transportista.DefaultCell.Padding = 3
        tabla_transportista.DefaultCell.BorderColor = Color.WHITE
        tabla_transportista.HorizontalAlignment = Element.ALIGN_CENTER
        tabla_transportista.WidthPercentage = (400 / 5.23F)
        tabla_transportista.SetWidths(New Integer() {1, 4, 1})

        Dim tabla_grilla As New PdfPTable(grd_detalle.ColumnCount + 1)
        tabla_grilla.DefaultCell.Padding = 3
        tabla_grilla.WidthPercentage = 30
        tabla_grilla.HorizontalAlignment = Element.ALIGN_LEFT
        tabla_grilla.DefaultCell.BorderWidth = 1
        tabla_grilla.WidthPercentage = (480 / 5.23F)
        tabla_grilla.SetWidths(New Integer() {1, 1, 1, 5, 1, 1, 0, 1})
        tabla_grilla.SpacingBefore = 20

        Dim tabla_motivo As New PdfPTable(5)
        tabla_motivo.DefaultCell.Padding = 3
        tabla_motivo.HorizontalAlignment = Element.ALIGN_CENTER
        tabla_motivo.WidthPercentage = (385 / 5.23F)
        tabla_motivo.SetWidths(New Integer() {1, 4, 1, 1, 2})
        tabla_motivo.SpacingBefore = 20

        Dim tabla_datos_adicionales As New PdfPTable(2)
        tabla_datos_adicionales.DefaultCell.Padding = 3
        tabla_datos_adicionales.DefaultCell.BorderColor = Color.WHITE
        tabla_datos_adicionales.HorizontalAlignment = Element.ALIGN_CENTER
        tabla_datos_adicionales.WidthPercentage = (385 / 5.23F)
        tabla_datos_adicionales.SetWidths(New Integer() {1, 5})
        tabla_datos_adicionales.SpacingBefore = 20

        Dim tabla_fimas As New PdfPTable(2)
        tabla_fimas.DefaultCell.Padding = 3
        tabla_fimas.DefaultCell.BorderColor = Color.WHITE
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

        Using stream As New FileStream(direccion_archivo & "GuiaRemision " + txt_documento.Text + ".pdf", FileMode.Create)
            Dim pdfDoc As New Document(PageSize.A2, 10.0F, 10.0F, 10.0F, 0.0F)
            PdfWriter.GetInstance(pdfDoc, stream)
            pdfDoc.Open()

            Dim logo As Image
            Dim recurso As String = My.Computer.FileSystem.CurrentDirectory
            logo = Image.GetInstance(recurso & "\Resources\DISTRIBUIDORA_SAN_RAFAEL.png")
            If txt_empresa.Text = "DIMOSA" Then
                logo = Image.GetInstance(recurso & "\Resources\DIMOSA-26.png")
            End If
            tabla_encabezado.AddCell(logo)
            Dim cell As New PdfPCell(New Phrase("DISTRIBUIDORA SAN RAFAEL, S DE R.L. DE C.V. " & vbCrLf & _
                            "Bº Villa Belen a 500 metros UPN, Santa Rosa Copan.  " & vbCrLf & _
                            "Bº El Progeso, Santa Rosa Copan. " & vbCrLf & _
                            "Bº Villas del Rosario carretera circunvalacion, Gracias Lempira." & vbCrLf & _
                            "Bº Guadalupe, 1 Ave, entre 24 y 25 Calle, N. O. San Pedro Sula." & vbCrLf & _
                            "Bº Las Flores, entre 6 Y 7 Ave NE, entre 4 Y 5 Calle NE, Tocoa Colon" & vbCrLf & _
                            "RTN 16139011441906	" & vbCrLf & _
                            "info@sanrafaelhn.com " & vbCrLf & _
                            "Tel. 2509-0007", FontFactory.GetFont("arial", 20, Font.Bold, Color.BLACK)))
            If txt_empresa.Text = "DIMOSA" Then
                cell = New PdfPCell(New Phrase("DISTRIBUIDORA MODERNA S.A. DE C.V. " & vbCrLf & _
                           "Bº Guadalupe, Contiguo a Hilos y Mechas" & vbCrLf & _
                            "RTN 05019018030031	" & vbCrLf & _
                            "info@sanrafaelhn.com " & vbCrLf & _
                            "Tel. 2509-0007", FontFactory.GetFont("arial", 20, Font.Bold, Color.BLACK)))
            End If
            cell.BorderColor = Color.WHITE
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tabla_encabezado.AddCell(cell)
            tabla_encabezado.AddCell(New Phrase("Guia de Remision #: " & vbCrLf & _
                            txt_documento.Text, FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))

            tabla_sub_encabezado.AddCell(New Phrase("CAI: " & txt_cai.Text, FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))
            tabla_sub_encabezado.AddCell("")
            tabla_sub_encabezado.AddCell("")
            tabla_sub_encabezado.AddCell(New Phrase("Remite:     " & txt_remite.Text & vbCrLf & "RTN:         " & rtn_remite & vbCrLf & _
                                         "Direccion: " & direccion_remite, FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))
            tabla_sub_encabezado.AddCell("")
            tabla_sub_encabezado.AddCell(New Phrase("Fecha inicio de traslado: " & vbCrLf & cmb_fecha_inicio.Value.Date, FontFactory.GetFont("arial", 14, Font.Bold, Color.BLACK)))
            tabla_sub_encabezado.AddCell(New Phrase("Destino:    " & txt_destino.Text & vbCrLf & "RTN:         " & rtn_destino & vbCrLf & _
                                         "Direccion: " & direccion_destino, FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))
            tabla_sub_encabezado.AddCell("")
            tabla_sub_encabezado.AddCell(New Phrase("Fecha final de traslado: " & vbCrLf & cmb_fecha_final.Value.Date, FontFactory.GetFont("arial", 14, Font.Bold, Color.BLACK)))

            tabla_transportista.AddCell("")
            tabla_transportista.AddCell(New Phrase("    Transportista: " & txt_transportista.Text & vbCrLf & _
                                        "                 RTN: " & rtn_transportista & vbCrLf & _
                                        "Vehiculo Marca: " & marca & vbCrLf & _
                                        "              #Placa: " & placa, FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))
            tabla_transportista.AddCell("")

            Dim cell_sangria_titulo As New PdfPCell(New Phrase(""))
            cell_sangria_titulo.BorderColor = Color.WHITE
            tabla_grilla.AddCell(cell_sangria_titulo)
            For index As Integer = 0 To grd_detalle.ColumnCount - 1
                'If grd_detalle.Columns(index).HeaderText <> "CONLOTE" Then
                Dim cell_encabezado As New PdfPCell(New Phrase(grd_detalle.Columns(index).HeaderText.ToUpper, FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))
                cell_encabezado.BackgroundColor = Color.GRAY
                tabla_grilla.AddCell(cell_encabezado)
                'End If

            Next

            For i As Integer = 0 To grd_detalle.RowCount - 1
                Dim cell_sangria_contenido As New PdfPCell(New Phrase(""))
                cell_sangria_contenido.BorderColor = Color.WHITE
                tabla_grilla.AddCell(cell_sangria_contenido)
                For j As Integer = 0 To grd_detalle.ColumnCount - 1
                    'If grd_detalle.Columns(j).HeaderText <> "CONLOTE" Then
                    tabla_grilla.AddCell(New Phrase(Convert.ToString(grd_detalle.Rows(i).Cells(j).Value), FontFactory.GetFont("arial", 16, Font.Bold, Color.BLACK)))
                    'End If
                Next
            Next

            Dim cell_motivo As New PdfPCell(New Phrase("Motivo: ", FontFactory.GetFont("arial", 16, Font.Bold, Color.BLACK)))
            cell_motivo.BackgroundColor = Color.GRAY
            tabla_motivo.AddCell(cell_motivo)

            Dim cell_motivo_des As New PdfPCell(New Phrase(txt_motivo.Text, FontFactory.GetFont("arial", 16, Font.Bold, Color.BLACK)))
            cell_motivo_des.BackgroundColor = Color.GRAY
            tabla_motivo.AddCell(cell_motivo_des)

            Dim cell_motivo_sangria As New PdfPCell(New Phrase(""))
            cell_motivo_sangria.BorderColor = Color.WHITE
            tabla_motivo.AddCell(cell_motivo_sangria)

            Dim cell_peso_titulo As New PdfPCell(New Phrase("Peso Total: ", FontFactory.GetFont("arial", 16, Font.Bold, Color.BLACK)))
            cell_peso_titulo.BackgroundColor = Color.GRAY
            tabla_motivo.AddCell(cell_peso_titulo)

            Dim cell_peso_valor As New PdfPCell(New Phrase(txt_peso_total.Text, FontFactory.GetFont("arial", 16, Font.Bold, Color.BLACK)))
            cell_peso_valor.BackgroundColor = Color.GRAY
            tabla_motivo.AddCell(cell_peso_valor)

            tabla_datos_adicionales.AddCell("Rango: ")
            tabla_datos_adicionales.AddCell(rango)

            tabla_datos_adicionales.AddCell("Fecha limite impresión: ")
            tabla_datos_adicionales.AddCell(fecha_limite)

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
            pdfDoc.Add(tabla_grilla)
            pdfDoc.Add(tabla_motivo)
            pdfDoc.Add(tabla_fimas)
            pdfDoc.Add(tabla_datos_adicionales)
            pdfDoc.Close()
            stream.Close()

            Process.Start(direccion_archivo & "GuiaRemision " + txt_documento.Text + ".pdf")
        End Using
    End Sub

    Sub ImprimirRemision_SRAGRO()

        Dim tabla_encabezado As New PdfPTable(3)
        tabla_encabezado.DefaultCell.Padding = 3
        tabla_encabezado.DefaultCell.BorderColor = Color.WHITE
        tabla_encabezado.HorizontalAlignment = Element.ALIGN_CENTER
        tabla_encabezado.WidthPercentage = (500 / 5.1F)
        tabla_encabezado.SetWidths(New Integer() {1, 4, 1})
        tabla_encabezado.SpacingAfter = 20

        Dim tabla_sub_encabezado As New PdfPTable(3)
        tabla_sub_encabezado.DefaultCell.Padding = 3
        tabla_sub_encabezado.DefaultCell.BorderColor = Color.WHITE
        tabla_sub_encabezado.HorizontalAlignment = Element.ALIGN_CENTER
        tabla_sub_encabezado.WidthPercentage = (400 / 5.23F)
        tabla_sub_encabezado.SetWidths(New Integer() {4, 0, 2})

        Dim tabla_transportista As New PdfPTable(3)
        tabla_transportista.DefaultCell.Padding = 3
        tabla_transportista.DefaultCell.BorderColor = Color.WHITE
        tabla_transportista.HorizontalAlignment = Element.ALIGN_CENTER
        tabla_transportista.WidthPercentage = (400 / 5.23F)
        tabla_transportista.SetWidths(New Integer() {1, 4, 1})

        Dim tabla_grilla As New PdfPTable(grd_detalle.ColumnCount + 1)
        tabla_grilla.DefaultCell.Padding = 3
        tabla_grilla.WidthPercentage = 30
        tabla_grilla.HorizontalAlignment = Element.ALIGN_LEFT
        tabla_grilla.DefaultCell.BorderWidth = 1
        tabla_grilla.WidthPercentage = (480 / 5.23F)
        tabla_grilla.SetWidths(New Integer() {1, 1, 1, 5, 1, 1, 0, 1})
        tabla_grilla.SpacingBefore = 20

        Dim tabla_motivo As New PdfPTable(5)
        tabla_motivo.DefaultCell.Padding = 3
        tabla_motivo.HorizontalAlignment = Element.ALIGN_CENTER
        tabla_motivo.WidthPercentage = (385 / 5.23F)
        tabla_motivo.SetWidths(New Integer() {1, 4, 1, 1, 2})
        tabla_motivo.SpacingBefore = 20

        Dim tabla_datos_adicionales As New PdfPTable(2)
        tabla_datos_adicionales.DefaultCell.Padding = 3
        tabla_datos_adicionales.DefaultCell.BorderColor = Color.WHITE
        tabla_datos_adicionales.HorizontalAlignment = Element.ALIGN_CENTER
        tabla_datos_adicionales.WidthPercentage = (385 / 5.23F)
        tabla_datos_adicionales.SetWidths(New Integer() {1, 5})
        tabla_datos_adicionales.SpacingBefore = 20

        Dim tabla_fimas As New PdfPTable(2)
        tabla_fimas.DefaultCell.Padding = 3
        tabla_fimas.DefaultCell.BorderColor = Color.WHITE
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

        Using stream As New FileStream(direccion_archivo & "GuiaRemision " + txt_documento.Text + ".pdf", FileMode.Create)
            Dim pdfDoc As New Document(PageSize.A2, 10.0F, 10.0F, 10.0F, 0.0F)
            PdfWriter.GetInstance(pdfDoc, stream)
            pdfDoc.Open()

            Dim logo As Image
            Dim recurso As String = My.Computer.FileSystem.CurrentDirectory
            logo = Image.GetInstance(recurso & "\Resources\SR AGRO LOGO.jpg")
            tabla_encabezado.AddCell(logo)
            Dim cell As New PdfPCell(New Phrase("SR AGRO, S.A. DE C.V. " & vbCrLf & _
                            "Bª Villa Belen a 500 metros UPN, Santa Rosa Copan.  " & vbCrLf & _
                            "Bª El Progeso, Santa Rosa Copan. " & vbCrLf & _
                            "Bª Villas del Rosario carretera circunvalacion, Gracias Lempira." & vbCrLf & _
                            "RTN 05019014648142 " & vbCrLf & _
                            "www.agroservicioshn.com " & vbCrLf & _
                            "Tel. 2509-0007", FontFactory.GetFont("arial", 20, Font.Bold, Color.BLACK)))

            cell.BorderColor = Color.WHITE
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tabla_encabezado.AddCell(cell)
            tabla_encabezado.AddCell(New Phrase("Guia de Remision #: " & vbCrLf & _
                            txt_documento.Text, FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))

            tabla_sub_encabezado.AddCell(New Phrase("CAI: " & txt_cai.Text, FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))
            tabla_sub_encabezado.AddCell("")
            tabla_sub_encabezado.AddCell("")
            tabla_sub_encabezado.AddCell(New Phrase("Remite:     " & txt_remite.Text & vbCrLf & "RTN:         " & rtn_remite & vbCrLf & _
                                         "Direccion: " & direccion_remite, FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))
            tabla_sub_encabezado.AddCell("")
            tabla_sub_encabezado.AddCell(New Phrase("Fecha inicio de traslado: " & vbCrLf & cmb_fecha_inicio.Value.Date, FontFactory.GetFont("arial", 14, Font.Bold, Color.BLACK)))
            tabla_sub_encabezado.AddCell(New Phrase("Destino:    " & txt_destino.Text & vbCrLf & "RTN:         " & rtn_destino & vbCrLf & _
                                         "Direccion: " & direccion_destino, FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))
            tabla_sub_encabezado.AddCell("")
            tabla_sub_encabezado.AddCell(New Phrase("Fecha final de traslado: " & vbCrLf & cmb_fecha_final.Value.Date, FontFactory.GetFont("arial", 14, Font.Bold, Color.BLACK)))

            tabla_transportista.AddCell("")
            tabla_transportista.AddCell(New Phrase("    Transportista: " & txt_transportista.Text & vbCrLf & _
                                        "                 RTN: " & rtn_transportista & vbCrLf & _
                                        "Vehiculo Marca: " & marca & vbCrLf & _
                                        "              #Placa: " & placa, FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))
            tabla_transportista.AddCell("")

            Dim cell_sangria_titulo As New PdfPCell(New Phrase(""))
            cell_sangria_titulo.BorderColor = Color.WHITE
            tabla_grilla.AddCell(cell_sangria_titulo)
            For index As Integer = 0 To grd_detalle.ColumnCount - 1
                Dim cell_encabezado As New PdfPCell(New Phrase(grd_detalle.Columns(index).HeaderText.ToUpper, FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))
                cell_encabezado.BackgroundColor = Color.GRAY
                tabla_grilla.AddCell(cell_encabezado)
            Next

            For i As Integer = 0 To grd_detalle.RowCount - 1
                Dim cell_sangria_contenido As New PdfPCell(New Phrase(""))
                cell_sangria_contenido.BorderColor = Color.WHITE
                tabla_grilla.AddCell(cell_sangria_contenido)
                For j As Integer = 0 To grd_detalle.ColumnCount - 1
                    tabla_grilla.AddCell(New Phrase(Convert.ToString(grd_detalle.Rows(i).Cells(j).Value), FontFactory.GetFont("arial", 16, Font.Bold, Color.BLACK)))
                Next
            Next

            Dim cell_motivo As New PdfPCell(New Phrase("Motivo: ", FontFactory.GetFont("arial", 16, Font.Bold, Color.BLACK)))
            cell_motivo.BackgroundColor = Color.GRAY
            tabla_motivo.AddCell(cell_motivo)

            Dim cell_motivo_des As New PdfPCell(New Phrase(txt_motivo.Text, FontFactory.GetFont("arial", 16, Font.Bold, Color.BLACK)))
            cell_motivo_des.BackgroundColor = Color.GRAY
            tabla_motivo.AddCell(cell_motivo_des)

            Dim cell_motivo_sangria As New PdfPCell(New Phrase(""))
            cell_motivo_sangria.BorderColor = Color.WHITE
            tabla_motivo.AddCell(cell_motivo_sangria)

            Dim cell_peso_titulo As New PdfPCell(New Phrase("Peso Total: ", FontFactory.GetFont("arial", 16, Font.Bold, Color.BLACK)))
            cell_peso_titulo.BackgroundColor = Color.GRAY
            tabla_motivo.AddCell(cell_peso_titulo)

            Dim cell_peso_valor As New PdfPCell(New Phrase(txt_peso_total.Text, FontFactory.GetFont("arial", 16, Font.Bold, Color.BLACK)))
            cell_peso_valor.BackgroundColor = Color.GRAY
            tabla_motivo.AddCell(cell_peso_valor)

            tabla_datos_adicionales.AddCell("Rango: ")
            tabla_datos_adicionales.AddCell(rango)

            tabla_datos_adicionales.AddCell("Fecha limite impresión: ")
            tabla_datos_adicionales.AddCell(fecha_limite)

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
            pdfDoc.Add(tabla_grilla)
            pdfDoc.Add(tabla_motivo)
            pdfDoc.Add(tabla_fimas)
            pdfDoc.Add(tabla_datos_adicionales)
            pdfDoc.Close()
            stream.Close()

            Process.Start(direccion_archivo & "GuiaRemision " + txt_documento.Text + ".pdf")
        End Using
    End Sub

    Private Sub frm_guia_remision_detalles_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'grd_detalle.DataSource = Nothing
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
        Cargar_Detalle()

    End Sub

    Sub Cargar_Detalle()
        Try

            If TipoRemision = "Completar" Then
                grd_detalle.DataSource = conexion.remision_detalle(txt_documento.Text, frm_ListaRemisiones.Almacen)

                Dim ColumnaCantidad As New DataGridViewTextBoxColumn
                ColumnaCantidad.HeaderText = "CANTIDAD RECIBIDA"
                ColumnaCantidad.Name = "CANTIDAD RECIBIDA"
                grd_detalle.Columns.Add(ColumnaCantidad)

                grd_detalle.Columns(0).ReadOnly = True
                grd_detalle.Columns(1).ReadOnly = True
                grd_detalle.Columns(2).ReadOnly = True
                grd_detalle.Columns(3).ReadOnly = True
                grd_detalle.Columns(4).ReadOnly = True
                grd_detalle.Columns(5).ReadOnly = True
                grd_detalle.Columns("CANTIDAD RECIBIDA").ReadOnly = False

                For Each Row As DataGridViewRow In grd_detalle.Rows
                    grd_detalle.Rows(Row.Index).Cells(6).Value = grd_detalle.Rows(Row.Index).Cells(0).Value
                Next

            Else
                grd_detalle.DataSource = conexion.remision_detalle_con_Cantidad(txt_documento.Text, frm_ListaRemisiones.Almacen)
                grd_detalle.Columns(0).ReadOnly = True
                grd_detalle.Columns(1).ReadOnly = True
                grd_detalle.Columns(2).ReadOnly = True
                grd_detalle.Columns(3).ReadOnly = True
                grd_detalle.Columns(4).ReadOnly = True
                grd_detalle.Columns(5).ReadOnly = True
                grd_detalle.Columns(6).ReadOnly = True
                grd_detalle.Columns("CANTIDAD RECIBIDA").ReadOnly = True
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub grd_detalle_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grd_detalle.CellEndEdit
        If Convert.ToDecimal(grd_detalle.Rows(fila).Cells("CANTIDAD RECIBIDA").Value) > Convert.ToDecimal(grd_detalle.Rows(fila).Cells("CANTIDAD").Value) Then
            MsgBox("La cantidad recibida no puede ser mayor que la cantidad enviada en la remisión.", MsgBoxStyle.Information, "Error")
            grd_detalle.Rows(fila).Cells("CANTIDAD RECIBIDA").Value = grd_detalle.Rows(fila).Cells("CANTIDAD").Value
        End If

    End Sub

    Private Sub grd_detalle_CellBeginEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles grd_detalle.CellBeginEdit
        fila = grd_detalle.CurrentRow.Index
    End Sub

    Private Sub BtnCompletarRemision_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCompletarRemision.Click

        Dim TIPOREM As DataTable
        TIPOREM = conexion.DatosREMISION(txt_documento.Text, CODREM)

        Dim Estado = "COMPLETA"
        Dim StatusCompleto As Boolean = True
        Dim dt As New DataTable

        dt.Columns.Add("id_remision")
        dt.Columns.Add("remite")
        dt.Columns.Add("destino")

        Dim VerificaEstado As String = ""
        Dim dti As New DataTable
        Try
            dti.Rows.Clear()
        Catch ex As Exception
        End Try

        dti = conexion.RevisarEstado(CODDEST, txt_documento.Text)
        Try
            VerificaEstado = dti(0)(0)
        Catch ex As Exception
        End Try

        If VerificaEstado = "PENDIENTE" Then

            Dim fila As DataRow = dt.NewRow
            fila(0) = txt_documento.Text
            fila(1) = CODREM
            fila(2) = CODDEST

            dt.Rows.Add(fila)

            Dim dt2 As New DataTable
            dt2.Columns.Add("Cantidad")
            dt2.Columns.Add("...")
            dt2.Columns.Add("Codigo")
            dt2.Columns.Add("Descripcion")
            dt2.Columns.Add("Peso Unidad")
            dt2.Columns.Add("Peso Total")
            dt2.Columns.Add("Con Lote")
            dt2.Columns.Add("Cantidad Recibida")

            For Each Row As DataGridViewRow In grd_detalle.Rows
                If Row.Cells("CANTIDAD RECIBIDA").Value = "" Then
                    StatusCompleto = False
                    MsgBox("Debe llenar todos los campos de total recibido para poder completar la remisión.", MsgBoxStyle.Critical, "Error")
                End If
                If Row.Cells("CANTIDAD").Value <> Row.Cells("CANTIDAD RECIBIDA").Value Then
                    Estado = "COMPLETA (D)"
                End If
            Next

            'Dim a As String
            For j As Integer = 0 To grd_detalle.Rows.Count - 1
                If grd_detalle.Rows(j).Cells(2).Value = "" Then
                Else
                    Dim fila_detalle As DataRow = dt2.NewRow
                    fila_detalle("Cantidad") = grd_detalle.Rows(j).Cells("CANTIDAD").Value
                    fila_detalle("...") = ""
                    fila_detalle("Codigo") = grd_detalle.Rows(j).Cells("CODIGO").Value
                    fila_detalle("Descripcion") = grd_detalle.Rows(j).Cells("DESCRIPCION").Value
                    fila_detalle("Peso Unidad") = grd_detalle.Rows(j).Cells("P. UNDS").Value
                    fila_detalle("Peso Total") = grd_detalle.Rows(j).Cells("P. TOTAL").Value
                    fila_detalle("Con Lote") = grd_detalle.Rows(j).Cells("CONLOTE").Value
                    fila_detalle("Cantidad Recibida") = grd_detalle.Rows(j).Cells("CANTIDAD RECIBIDA").Value
                    'a += fila_detalle("Cantidad") & vbTab & fila_detalle("...") & vbTab & fila_detalle("Codigo") & vbTab & fila_detalle("Descripcion") & vbTab & fila_detalle("Peso Unidad") & vbTab & fila_detalle("Peso Total") & vbTab & fila_detalle("Con Lote") & vbTab & fila_detalle("Cantidad Recibida") & vbNewLine
                    dt2.Rows.Add(fila_detalle)
                End If
            Next

            'Prueba.Show()
            'Prueba.DataGridView1.DataSource = dt
            'Prueba.DataGridView2.DataSource = dt2

            If TIPOREM(0)(0) = "CONSUMO" Then
                If StatusCompleto = True Then
                    Dim a = conexion.COMPLETAR(dt, dt2, _Inicio.lblUsuario.Text, Estado, txt_documento.Text)
                    If a <> "correcto" Then
                        MsgBox("Error: " & a)
                    Else
                        MsgBox("Remisión aceptada exitosamente.", MsgBoxStyle.Information, "Remisión Completada")
                        frm_ListaRemisiones.cargar()
                        Me.Close()
                    End If
                End If
            End If

            If TIPOREM(0)(0) = "DIMOSA" Then
                If StatusCompleto = True Then
                    Dim a = conexion.COMPLETARDIMOSA(dt, dt2, _Inicio.lblUsuario.Text, Estado, txt_documento.Text)
                    If a <> "correcto" Then
                        MsgBox("Error: " & a)
                    Else
                        MsgBox("Remisión aceptada exitosamente.", MsgBoxStyle.Information, "Remisión Completada")
                        frm_ListaRemisiones.cargar()
                        Me.Close()
                    End If
                End If
            End If


            If TIPOREM(0)(0) = "SR AGRO" Then
                If StatusCompleto = True Then
                    Dim a = conexion.COMPLETARSRAGRO(dt, dt2, _Inicio.lblUsuario.Text, Estado, txt_documento.Text)
                    If a <> "correcto" Then
                        MsgBox("Error: " & a)
                    Else
                        MsgBox("Remisión aceptada exitosamente.", MsgBoxStyle.Information, "Remisión Completada")
                        frm_ListaRemisiones.cargar()
                        Me.Close()
                    End If
                End If
            End If

            If TIPOREM(0)(0) = "BIENES Y RECURSOS" Then
                If StatusCompleto = True Then
                    Dim a = conexion.COMPLETARBIENES(dt, dt2, _Inicio.lblUsuario.Text, Estado, txt_documento.Text)
                    If a <> "correcto" Then
                        MsgBox("Error: " & a)
                    Else
                        MsgBox("Remisión aceptada exitosamente.", MsgBoxStyle.Information, "Remisión Completada")
                        frm_ListaRemisiones.cargar()
                        Me.Close()
                    End If
                End If
            End If

            If TIPOREM(0)(0) = "FLOTA" Then
                If StatusCompleto = True Then
                    Dim a = conexion.COMPLETARFLOTA(dt, dt2, _Inicio.lblUsuario.Text, Estado, txt_documento.Text)
                    If a <> "correcto" Then
                        MsgBox("Error: " & a)
                    Else
                        MsgBox("Remisión aceptada exitosamente.", MsgBoxStyle.Information, "Remisión Completada")
                        frm_ListaRemisiones.cargar()
                        Me.Close()
                    End If
                End If
            End If

        Else
            MsgBox("Esta remisión ya fue aceptada por otro usuario.")
            frm_ListaRemisiones.cargar()
            Me.Close()
        End If

    End Sub

    Private Sub BtnDevolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDevolver.Click

        Dim TIPOREM As DataTable
        TIPOREM = conexion.DatosREMISION(txt_documento.Text, CODREM)

        Dim Estado = "COMPLETA"
        Dim StatusCompleto As Boolean = True
        Dim dt As New DataTable

        dt.Columns.Add("id_remision")
        dt.Columns.Add("remite")
        dt.Columns.Add("destino")

        Dim fila As DataRow = dt.NewRow
        fila(0) = txt_documento.Text
        fila(1) = CODREM
        fila(2) = CODDEST

        dt.Rows.Add(fila)

        Dim dt2 As New DataTable
        dt2.Columns.Add("Cantidad")
        dt2.Columns.Add("...")
        dt2.Columns.Add("Codigo")
        dt2.Columns.Add("Descripcion")
        dt2.Columns.Add("Peso Unidad")
        dt2.Columns.Add("Peso Total")
        dt2.Columns.Add("Con Lote")
        dt2.Columns.Add("Cantidad Recibida")

        Estado = "DEVUELTA"

        'Dim a As String
        For j As Integer = 0 To grd_detalle.Rows.Count - 1
            If grd_detalle.Rows(j).Cells(2).Value = "" Then
            Else
                Dim fila_detalle As DataRow = dt2.NewRow
                fila_detalle("Cantidad") = grd_detalle.Rows(j).Cells("CANTIDAD").Value
                fila_detalle("...") = ""
                fila_detalle("Codigo") = grd_detalle.Rows(j).Cells("CODIGO").Value
                fila_detalle("Descripcion") = grd_detalle.Rows(j).Cells("DESCRIPCION").Value
                fila_detalle("Peso Unidad") = grd_detalle.Rows(j).Cells("P. UNDS").Value
                fila_detalle("Peso Total") = grd_detalle.Rows(j).Cells("P. TOTAL").Value
                fila_detalle("Con Lote") = grd_detalle.Rows(j).Cells("CONLOTE").Value
                fila_detalle("Cantidad Recibida") = 0
                'a += fila_detalle("Cantidad") & vbTab & fila_detalle("...") & vbTab & fila_detalle("Codigo") & vbTab & fila_detalle("Descripcion") & vbTab & fila_detalle("Peso Unidad") & vbTab & fila_detalle("Peso Total") & vbTab & fila_detalle("Con Lote") & vbTab & fila_detalle("Cantidad Recibida") & vbNewLine
                dt2.Rows.Add(fila_detalle)
            End If
        Next

        'Prueba.Show()
        'Prueba.DataGridView1.DataSource = dt
        'Prueba.DataGridView2.DataSource = dt2

        If TIPOREM(0)(0) = "CONSUMO" Then
            If StatusCompleto = True Then
                Dim a = conexion.DEVOLVER(dt, dt2, _Inicio.lblUsuario.Text, Estado, txt_documento.Text)
                If a <> "correcto" Then
                    MsgBox("Error: " & a)
                Else
                    MsgBox("Remisión devuelta exitosamente.", MsgBoxStyle.Information, "Remisión Completada")
                    frm_ListaRemisiones.cargar()
                    Me.Close()
                End If
            End If
        End If

        If TIPOREM(0)(0) = "DIMOSA" Then
            If StatusCompleto = True Then
                Dim a = conexion.DEVOLVERDIMOSA(dt, dt2, _Inicio.lblUsuario.Text, Estado, txt_documento.Text)
                If a <> "correcto" Then
                    MsgBox("Error: " & a)
                Else
                    MsgBox("Remisión devuelta exitosamente.", MsgBoxStyle.Information, "Remisión Completada")
                    frm_ListaRemisiones.cargar()
                    Me.Close()
                End If
            End If
        End If
        If TIPOREM(0)(0) = "SR AGRO" Then
            If StatusCompleto = True Then
                Dim a = conexion.DEVOLVERSRAGRO(dt, dt2, _Inicio.lblUsuario.Text, Estado, txt_documento.Text)
                If a <> "correcto" Then
                    MsgBox("Error: " & a)
                Else
                    MsgBox("Remisión devuelta exitosamente.", MsgBoxStyle.Information, "Remisión Completada")
                    frm_ListaRemisiones.cargar()
                    Me.Close()
                End If
            End If
        End If
        If TIPOREM(0)(0) = "BIENES Y RECURSOS" Then
            If StatusCompleto = True Then
                Dim a = conexion.DEVOLVERBIENES(dt, dt2, _Inicio.lblUsuario.Text, Estado, txt_documento.Text)
                If a <> "correcto" Then
                    MsgBox("Error: " & a)
                Else
                    MsgBox("Remisión devuelta exitosamente.", MsgBoxStyle.Information, "Remisión Completada")
                    frm_ListaRemisiones.cargar()
                    Me.Close()
                End If
            End If
        End If
        If TIPOREM(0)(0) = "FLOTA" Then
            If StatusCompleto = True Then
                Dim a = conexion.DEVOLVERFLOTA(dt, dt2, _Inicio.lblUsuario.Text, Estado, txt_documento.Text)
                If a <> "correcto" Then
                    MsgBox("Error: " & a)
                Else
                    MsgBox("Remisión devuelta exitosamente.", MsgBoxStyle.Information, "Remisión Completada")
                    frm_ListaRemisiones.cargar()
                    Me.Close()
                End If
            End If
        End If
    End Sub

    Private Sub frm_guia_remision_detalles_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If TipoRemision = "Completar" Then
            grd_detalle.Columns.Clear()
        End If
    End Sub

End Class