Imports Disar.data
Imports System.Reflection
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO

Public Class Frm_Completar_Orden_Pedido

    Dim direccion_archivo = ""

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Dim Resp = MsgBox("¿Está seguro de querer eliminar la solicitud de pedido a " & TextProveedor.Text & "?", MsgBoxStyle.YesNo, "Atención")
        If Resp = MsgBoxResult.Yes Then
            Dim db As New cls_compras_pedidos
            Dim s = db.CancelarPedido(Val(TextNumero.Text), _Inicio.lblUsuario.Text)
            If s = "s" Then
                LlenaDT()
                frm_pedidos_proveedores.Actualizar()
                Me.Close()
            Else
                MsgBox(s, MsgBoxStyle.Information, "Error")
            End If
        End If
    End Sub

    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        'Dim Resp = MsgBox("¿Desea procesar la compra de Compra: " & TextProveedor.Text & " desde el módulo de " & TextTipo.Text & "?", MsgBoxStyle.YesNo, "Atención")
        'If Resp = MsgBoxResult.Yes Then
        Dim dt As New DataTable
        For Each column As DataGridViewColumn In DataPedidos.Columns
            dt.Columns.Add(column.HeaderText)
        Next
        For Each row As DataGridViewRow In DataPedidos.Rows
            dt.Rows.Add(row.Cells(0).Value, row.Cells(1).Value, row.Cells(2).Value, row.Cells(3).Value, row.Cells(4).Value, row.Cells(5).Value, row.Cells(6).Value, row.Cells(7).Value)
        Next
        Dim db As New cls_compras_pedidos
        Dim s = db.CompletaPedido(Val(TextNumero.Text), _Inicio.lblUsuario.Text, dt)
        If s = "s" Then
            LlenaDT()
            frm_pedidos_proveedores.Actualizar()
        Else
            MsgBox(s, MsgBoxStyle.Information, "Error")
        End If
        'End If
    End Sub

    Private Sub Btn_Volver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Volver.Click
        Me.Close()
    End Sub

    Private Sub DataPedidos_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataPedidos.CellEndEdit
        If Val(DataPedidos.CurrentRow.Cells("Cantidad Recibida").Value) + Val(DataPedidos.CurrentRow.Cells("Cantidad Devuelta").Value) > DataPedidos.CurrentRow.Cells("Cantidad").Value Then
            MsgBox("La cantidad de compra y la cantidad devuelta no cuadran con lo solicitado.", MsgBoxStyle.Information, "Completar Orden de Pedido")
            DataPedidos.CurrentRow.Cells("Cantidad Recibida").Value = DataPedidos.CurrentRow.Cells("Cantidad").Value - DataPedidos.CurrentRow.Cells("Cantidad Devuelta").Value
        End If
    End Sub

    Sub LlenaDT()
        Dim dt As New DataTable
        For Each column As DataGridViewColumn In DataPedidos.Columns
            dt.Columns.Add(column.HeaderText)
        Next
        For Each Row As DataGridViewRow In DataPedidos.Rows
            dt.Rows.Add(Row.Cells(0).Value, Row.Cells(1).Value, Row.Cells(2).Value, Row.Cells(3).Value, Row.Cells(5).Value, Row.Cells(6).Value, Row.Cells(7).Value)
        Next

        ExportarPDF()
        ImprimirRemision_DISAR(Val(TextNumero.Text), dt, Val(TextAlmacen.Text))

    End Sub

    Sub ExportarPDF()
        Try
            FolderBrowserDialog1.Description = "Guardar Pedidos"
            If FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK _
             Then
                direccion_archivo = FolderBrowserDialog1.SelectedPath + "\"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub ImprimirRemision_DISAR(ByVal Numero As Integer, ByVal dt As DataTable, ByVal Almacen As Integer)

        Dim tabla_encabezado As New PdfPTable(3)
        tabla_encabezado.DefaultCell.Padding = 3
        tabla_encabezado.DefaultCell.BorderColor = Color.WHITE
        tabla_encabezado.HorizontalAlignment = Element.ALIGN_CENTER
        tabla_encabezado.WidthPercentage = (500 / 5.1F)
        tabla_encabezado.SetWidths(New Integer() {2, 4, 2})

        Dim tabla_sub_encabezado As New PdfPTable(3)
        tabla_sub_encabezado.DefaultCell.Padding = 3
        tabla_sub_encabezado.DefaultCell.BorderColor = Color.WHITE
        tabla_sub_encabezado.HorizontalAlignment = Element.ALIGN_LEFT
        tabla_sub_encabezado.WidthPercentage = (400 / 5.23F)
        tabla_sub_encabezado.SetWidths(New Integer() {1, 8, 2})

        Dim tabla_grilla As New PdfPTable(8)
        tabla_grilla.DefaultCell.Padding = 3
        tabla_grilla.WidthPercentage = 30
        tabla_grilla.HorizontalAlignment = Element.ALIGN_LEFT
        tabla_grilla.DefaultCell.BorderWidth = 1
        tabla_grilla.WidthPercentage = (480 / 5.23F)

        tabla_grilla.SetWidths(New Integer() {1, 2, 2, 5, 2, 2, 2, 2})
        tabla_grilla.SpacingBefore = 20

        'Exporting to PDF
        If direccion_archivo = "" Then
            direccion_archivo = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\"
            'If Not Directory.Exists(direccion_archivo) Then
            '    Directory.CreateDirectory(direccion_archivo)
            'End If
        End If
        Dim Sucursal As String = ""
        If Almacen = 1 Then
            Sucursal = "SAN PEDRO SULA"
        ElseIf Almacen = 2 Then
            Sucursal = "SANTA ROSA DE COPAN"
        ElseIf Almacen = 3 Then
            Sucursal = "SABA"
        ElseIf Almacen = 4 Then
            Sucursal = "TEGUCIGALPA"
        End If

        Using stream As New FileStream(direccion_archivo & "Recepcion " & TextProveedor.Text & " Numero " & Numero & ".pdf", FileMode.Create)
            Dim pdfDoc As New Document(PageSize.LETTER, 10, 10, 10, 20)
            PdfWriter.GetInstance(pdfDoc, stream)
            pdfDoc.Open()

            Dim logo As Image
            Dim recurso As String = My.Computer.FileSystem.CurrentDirectory

            logo = Image.GetInstance(recurso & "\Resources\DISTRIBUIDORA_SAN_RAFAEL.png")

            Dim fecha As Integer
            fecha = pdfDoc.AddCreationDate

            tabla_encabezado.AddCell(logo)
            tabla_encabezado.AddCell("" & vbNewLine & vbNewLine)
            tabla_encabezado.AddCell("" & vbNewLine & vbNewLine)
            tabla_encabezado.AddCell("" & vbNewLine & vbNewLine)
            Dim cell As New PdfPCell(New Phrase("DISTRIBUIDORA SAN RAFAEL, S. DE R.L. DE C.V. " & vbCrLf & _
                            "Recepción de Mercadería a Proveedor: " & TextProveedor.Text, FontFactory.GetFont("arial", 12, Font.Bold, Color.BLACK)))
            cell.BorderColor = Color.WHITE
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tabla_encabezado.AddCell(cell)
            tabla_encabezado.AddCell("" & vbNewLine & vbNewLine)

            tabla_sub_encabezado.AddCell("")
            Dim cell2 As New PdfPCell(New Phrase("Orden de Compra: " & Numero & vbNewLine & "Sucursal: " & Sucursal & vbNewLine & "Fecha: " & Today.Date, FontFactory.GetFont("arial", 10, Font.Bold, Color.BLACK)))
            cell2.BorderColor = Color.WHITE
            cell2.HorizontalAlignment = Element.ALIGN_LEFT
            tabla_sub_encabezado.AddCell(cell2)
            tabla_sub_encabezado.AddCell("Recibido por: " & vbNewLine & "Firma: ")

            Dim cell_sangria_contenido As New PdfPCell(New Phrase(""))
            cell_sangria_contenido.BorderColor = Color.WHITE
            tabla_grilla.AddCell(cell_sangria_contenido)


            Dim cell_encabezado0 As New PdfPCell(New Phrase("Nº", FontFactory.GetFont("arial", 9, Font.Bold, Color.BLACK)))
            cell_encabezado0.BackgroundColor = Color.GRAY
            tabla_grilla.AddCell(cell_encabezado0)

            Dim cell_encabezado As New PdfPCell(New Phrase("Clave", FontFactory.GetFont("arial", 9, Font.Bold, Color.BLACK)))
            cell_encabezado.BackgroundColor = Color.GRAY
            tabla_grilla.AddCell(cell_encabezado)
            Dim cell_encabezado2 As New PdfPCell(New Phrase("Producto", FontFactory.GetFont("arial", 9, Font.Bold, Color.BLACK)))
            cell_encabezado2.BackgroundColor = Color.GRAY
            tabla_grilla.AddCell(cell_encabezado2)

            Dim cell_encabezado4 As New PdfPCell(New Phrase("Ubicación", FontFactory.GetFont("arial", 9, Font.Bold, Color.BLACK)))
            cell_encabezado4.BackgroundColor = Color.GRAY
            tabla_grilla.AddCell(cell_encabezado4)

            Dim cell_encabezado3 As New PdfPCell(New Phrase("Fecha Vencimiento", FontFactory.GetFont("arial", 9, Font.Bold, Color.BLACK)))
            cell_encabezado3.BackgroundColor = Color.GRAY
            tabla_grilla.AddCell(cell_encabezado3)

            Dim cell_encabezado5 As New PdfPCell(New Phrase("Cantidad Recibida", FontFactory.GetFont("arial", 9, Font.Bold, Color.BLACK)))
            cell_encabezado5.BackgroundColor = Color.GRAY
            tabla_grilla.AddCell(cell_encabezado5)

            Dim cell_encabezado6 As New PdfPCell(New Phrase("Cantidad Devuelta", FontFactory.GetFont("arial", 9, Font.Bold, Color.BLACK)))
            cell_encabezado6.BackgroundColor = Color.GRAY
            tabla_grilla.AddCell(cell_encabezado6)


            For a As Integer = 0 To dt.Rows.Count - 1
                tabla_grilla.AddCell(cell_sangria_contenido)

                tabla_grilla.AddCell(New Phrase(Convert.ToString(dt(a)(0)), FontFactory.GetFont("arial", 9, Font.Bold, Color.BLACK)))
                tabla_grilla.AddCell(New Phrase(Convert.ToString(dt(a)(1)), FontFactory.GetFont("arial", 9, Font.Bold, Color.BLACK)))
                tabla_grilla.AddCell(New Phrase(Convert.ToString(dt(a)(2)), FontFactory.GetFont("arial", 9, Font.Bold, Color.BLACK)))
                tabla_grilla.AddCell(New Phrase(Convert.ToString(dt(a)(4)), FontFactory.GetFont("arial", 9, Font.Bold, Color.BLACK)))
                tabla_grilla.AddCell(New Phrase("", FontFactory.GetFont("arial", 9, Font.Bold, Color.BLACK)))
                tabla_grilla.AddCell(New Phrase("", FontFactory.GetFont("arial", 9, Font.Bold, Color.BLACK)))
                tabla_grilla.AddCell(New Phrase("", FontFactory.GetFont("arial", 9, Font.Bold, Color.BLACK)))
            Next

            pdfDoc.Add(tabla_encabezado)
            pdfDoc.Add(tabla_sub_encabezado)
            pdfDoc.Add(tabla_grilla)

            pdfDoc.Close()
            stream.Close()

            Process.Start(direccion_archivo & "Recepcion " & TextProveedor.Text & " Numero " & Numero & ".pdf")
        End Using

    End Sub

    Sub ReimprimirPedido(ByVal Numero As Integer, ByVal dt As DataTable, ByVal Almacen As Integer)

        Dim tabla_encabezado As New PdfPTable(3)
        tabla_encabezado.DefaultCell.Padding = 3
        tabla_encabezado.DefaultCell.BorderColor = Color.WHITE
        tabla_encabezado.HorizontalAlignment = Element.ALIGN_CENTER
        tabla_encabezado.WidthPercentage = (500 / 5.1F)
        tabla_encabezado.SetWidths(New Integer() {2, 4, 2})

        Dim tabla_sub_encabezado As New PdfPTable(3)
        tabla_sub_encabezado.DefaultCell.Padding = 3
        tabla_sub_encabezado.DefaultCell.BorderColor = Color.WHITE
        tabla_sub_encabezado.HorizontalAlignment = Element.ALIGN_LEFT
        tabla_sub_encabezado.WidthPercentage = (400 / 5.23F)
        tabla_sub_encabezado.SetWidths(New Integer() {1, 8, 2})

        Dim tabla_grilla As New PdfPTable(5)
        tabla_grilla.DefaultCell.Padding = 3
        tabla_grilla.WidthPercentage = 30
        tabla_grilla.HorizontalAlignment = Element.ALIGN_LEFT
        tabla_grilla.DefaultCell.BorderWidth = 1
        tabla_grilla.WidthPercentage = (480 / 5.23F)

        tabla_grilla.SetWidths(New Integer() {1, 3, 3, 5, 2})
        tabla_grilla.SpacingBefore = 20

        'Exporting to PDF
        If direccion_archivo = "" Then
            direccion_archivo = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\"
            'If Not Directory.Exists(direccion_archivo) Then
            '    Directory.CreateDirectory(direccion_archivo)
            'End If
        End If
        Dim Sucursal As String = ""
        If Almacen = 1 Then
            Sucursal = "SAN PEDRO SULA"
        ElseIf Almacen = 2 Then
            Sucursal = "SANTA ROSA DE COPAN"
        ElseIf Almacen = 3 Then
            Sucursal = "SABA"
        ElseIf Almacen = 4 Then
            Sucursal = "TEGUCIGALPA"
        End If

        Using stream As New FileStream(direccion_archivo & "Pedido " & Replace(TextProveedor.Text, "'", "") & " Numero " & Numero & ".pdf", FileMode.Create)
            Dim pdfDoc As New Document(PageSize.LETTER, 10, 10, 10, 20)
            PdfWriter.GetInstance(pdfDoc, stream)
            pdfDoc.Open()

            Dim logo As Image
            Dim recurso As String = My.Computer.FileSystem.CurrentDirectory

            logo = Image.GetInstance(recurso & "\Resources\DISTRIBUIDORA_SAN_RAFAEL.png")

            Dim fecha As Integer
            fecha = pdfDoc.AddCreationDate

            tabla_encabezado.AddCell(logo)
            tabla_encabezado.AddCell("" & vbNewLine & vbNewLine)
            tabla_encabezado.AddCell("" & vbNewLine & vbNewLine)
            tabla_encabezado.AddCell("" & vbNewLine & vbNewLine)
            Dim cell As New PdfPCell(New Phrase("DISTRIBUIDORA SAN RAFAEL, S. DE R.L. DE C.V. " & vbCrLf & _
                            "Recepción de Mercadería a Proveedor: " & TextProveedor.Text, FontFactory.GetFont("arial", 12, Font.Bold, Color.BLACK)))
            cell.BorderColor = Color.WHITE
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tabla_encabezado.AddCell(cell)
            tabla_encabezado.AddCell("" & vbNewLine & vbNewLine)

            tabla_sub_encabezado.AddCell("")
            Dim cell2 As New PdfPCell(New Phrase("Orden de Compra: " & Numero & vbNewLine & "Sucursal: " & Sucursal & vbNewLine & "Fecha: " & Today.Date, FontFactory.GetFont("arial", 10, Font.Bold, Color.BLACK)))
            cell2.BorderColor = Color.WHITE
            cell2.HorizontalAlignment = Element.ALIGN_LEFT
            tabla_sub_encabezado.AddCell(cell2)
            tabla_sub_encabezado.AddCell("")
            tabla_sub_encabezado.AddCell("")

            Dim cell_sangria_contenido As New PdfPCell(New Phrase(""))
            cell_sangria_contenido.BorderColor = Color.WHITE
            tabla_grilla.AddCell(cell_sangria_contenido)


            Dim cell_encabezado4 As New PdfPCell(New Phrase("Clave Proveedor", FontFactory.GetFont("arial", 9, Font.Bold, Color.BLACK)))
            cell_encabezado4.BackgroundColor = Color.GRAY
            tabla_grilla.AddCell(cell_encabezado4)
            Dim cell_encabezado As New PdfPCell(New Phrase("Clave Interna", FontFactory.GetFont("arial", 9, Font.Bold, Color.BLACK)))
            cell_encabezado.BackgroundColor = Color.GRAY
            tabla_grilla.AddCell(cell_encabezado)
            Dim cell_encabezado2 As New PdfPCell(New Phrase("Producto", FontFactory.GetFont("arial", 9, Font.Bold, Color.BLACK)))
            cell_encabezado2.BackgroundColor = Color.GRAY
            tabla_grilla.AddCell(cell_encabezado2)
            Dim cell_encabezado3 As New PdfPCell(New Phrase("Cantidad Solicitada", FontFactory.GetFont("arial", 9, Font.Bold, Color.BLACK)))
            cell_encabezado3.BackgroundColor = Color.GRAY
            tabla_grilla.AddCell(cell_encabezado3)



            For a As Integer = 0 To dt.Rows.Count - 1
                tabla_grilla.AddCell(cell_sangria_contenido)
                'For x As Integer = 0 To dt.Columns.Count - 2
                tabla_grilla.AddCell(New Phrase(Convert.ToString(dt(a)(4)), FontFactory.GetFont("arial", 9, Font.Bold, Color.BLACK)))
                tabla_grilla.AddCell(New Phrase(Convert.ToString(dt(a)(0)), FontFactory.GetFont("arial", 9, Font.Bold, Color.BLACK)))
                tabla_grilla.AddCell(New Phrase(Convert.ToString(dt(a)(1)), FontFactory.GetFont("arial", 9, Font.Bold, Color.BLACK)))
                tabla_grilla.AddCell(New Phrase(Convert.ToString(dt(a)(2)), FontFactory.GetFont("arial", 9, Font.Bold, Color.BLACK)))
                'tabla_grilla.AddCell(New Phrase(Convert.ToString(dt(a)(3)), FontFactory.GetFont("arial", 9, Font.Bold, Color.BLACK)))
                'Next
            Next

            pdfDoc.Add(tabla_encabezado)
            pdfDoc.Add(tabla_sub_encabezado)
            pdfDoc.Add(tabla_grilla)

            pdfDoc.Close()
            stream.Close()


            Process.Start(direccion_archivo & "Pedido " & Replace(TextProveedor.Text, "'", "") & " Numero " & Numero & ".pdf")
        End Using

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ExportarPDF()
        Dim dtx As New DataTable
        dtx.Columns.Add("ID")
        dtx.Columns.Add("NOMBRE")
        dtx.Columns.Add("CANTIDAD SOLICITADA")
        dtx.Columns.Add("ALMACEN")
        dtx.Columns.Add("CLAVE PROVEEDOR")
        Dim db As New cls_compras_pedidos
        For Each Row As DataGridViewRow In DataPedidos.Rows
            Dim dt As New DataTable
            dt = db.CargaCodigoProveedor(Row.Cells(1).Value)
            dtx.Rows.Add(Row.Cells(1).Value, Row.Cells(2).Value, Row.Cells(3).Value, TextAlmacen.Text, dt(0)(0))
        Next

        ReimprimirPedido(TextNumero.Text, dtx, TextAlmacen.Text)
    End Sub

     
End Class