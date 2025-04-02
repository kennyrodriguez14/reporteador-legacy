Imports Disar.data
Imports System.Reflection
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO
Imports System.Data.OleDb

Public Class frm_NuevoPedido

    Dim direccion_archivo = ""
    Dim Adjunto = ""

    Private Sub Agregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Agregar.Click
        Try
            If IsNumeric(TextCantidad.Text) And TextCantidad.Text <> "" And TextProducto.Text <> "" Then
                Dim db As New cls_compras_pedidos
                Dim dt As New DataTable
                dt = db.CargaCodigoProveedor(TextProducto.Text)

                DataDatos.Rows.Add(TextProducto.Text, TextNombreProducto.Text, TextCantidad.Text, comboAlmacen.SelectedValue, dt(0)(0))

                ComboProv.Enabled = False

                TextCantidad.Text = ""
            Else
                MsgBox("Debe seleccionar un producto e ingresar una cantidad válida para poder agregar un registro")
            End If
        Catch ex As Exception
        End Try


    End Sub

    Private Sub frm_NuevoPedido_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LlenarAlmacenes()
        LLenaProveedores()
        Limpia()
    End Sub

    Sub Limpia()
        ComboProv.Enabled = True

        TextProducto.Text = ""
        TextNombreProducto.Text = ""
        TextCantidad.Text = ""
        ComboBox1.SelectedIndex = 0
    End Sub

    Sub LlenarAlmacenes()
        Dim db As New cls_compras_pedidos
        comboAlmacen.DataSource = db.CargarAlmacenes("SAN RAFAEL")
        comboAlmacen.ValueMember = "CVE_ALM"
        comboAlmacen.DisplayMember = "DESCR"
    End Sub

    Sub LLenaProveedores()
        Dim db As New cls_compras_pedidos
        ComboProv.DataSource = db.CargaProveedores("SAN RAFAEL")
        ComboProv.ValueMember = "CLAVE"
        ComboProv.DisplayMember = "NOMBRE"
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            DataDatos.Rows.RemoveAt(DataDatos.CurrentRow.Index)
        Catch ex As Exception
        End Try
        If DataDatos.RowCount <= 0 Then
            Limpia()
        End If
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub BtnCargaProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCargaProducto.Click
        Frm_Carga_Productos.PROV = ComboProv.SelectedValue
        If Frm_Carga_Productos.ShowDialog = Windows.Forms.DialogResult.OK Then
            TextProducto.Text = Frm_Carga_Productos.CLAVE
            TextNombreProducto.Text = Frm_Carga_Productos.DESCRIPCION
        End If
    End Sub

    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click

        If DataDatos.Rows.Count > 0 Then

            Dim db As New cls_compras_pedidos
            Try
                Dim SMTP As String = "gator2024.hostgator.com"
                Dim Usuario As String = "compras@sanrafaelhn.com"
                Dim Contraseña As String = "Compras100"

                Dim Contenido As String = ""

                Contenido &= "<h4> Buen día, </h4>"
                Contenido &= "<h4> Se adjuntan las siguientes órdenes para ser entregadas en las diferentes sucursales, su apoyo con la entrega en los días correspondientes. </h4>"
                Contenido &= "<h4> Favor presentar impresa la orden de compra junto con la factura a la hora de entregar el producto. Gracias.  </h4>"
                ExportarPDF()


                Dim Asunto As String = "Pedido de " & ComboProv.Text & " " & Today.Date.Day & Today.Date.Month & Today.Date.Year

                Dim Puerto As Integer = 26
                Dim correo As New System.Net.Mail.MailMessage()
                Dim Servidor As New System.Net.Mail.SmtpClient

                correo.From = New System.Net.Mail.MailAddress(Usuario)
                correo.Subject = Asunto

                Dim dtPrincipal As New DataTable
                Dim dtCopias As New DataTable

                dtPrincipal = db.CargaCorreos(ComboProv.SelectedValue, "O", "SAN RAFAEL")
                dtCopias = db.CargaCorreos(ComboProv.SelectedValue, "C", "SAN RAFAEL")

                For X = 0 To dtPrincipal.Rows.Count - 1
                    correo.To.Add(dtPrincipal(X)(0))
                Next
                For X = 0 To dtCopias.Rows.Count - 1
                    correo.CC.Add(dtCopias(X)(0))
                Next
                correo.IsBodyHtml = True
                correo.Body = Contenido

                Servidor.Host = SMTP
                Servidor.Port = Puerto
                Servidor.EnableSsl = False


                For a As Integer = 1 To 4

                    If a = 1 Then
                        Contenido &= "<h4> SAN PEDRO SULA </h4>"
                    ElseIf a = 2 Then
                        Contenido &= "<h4> SANTA ROSA DE COPÁN </h4>"
                    ElseIf a = 3 Then
                        Contenido &= "<h4> SABÁ </h4>"
                    ElseIf a = 4 Then
                        Contenido &= "<h4> TEGUCIGALPA </h4>"
                    End If


                    DataDatos.Sort(DataDatos.Columns(3), System.ComponentModel.ListSortDirection.Ascending)


                    Dim dt As New DataTable

                    For Each column As DataGridViewColumn In DataDatos.Columns
                        dt.Columns.Add(column.HeaderText)
                    Next

                    For Each row As DataGridViewRow In DataDatos.Rows
                        If a = row.Cells(3).Value Then
                            dt.Rows.Add(row.Cells(0).Value, row.Cells(1).Value, row.Cells(2).Value, row.Cells(3).Value, row.Cells(4).Value)
                        End If
                    Next


                    If dt.Rows.Count > 0 Then
                        Dim s = db.NuevoRegistro(ComboProv.SelectedValue, ComboProv.Text, _Inicio.lblUsuario.Text, dt, ComboBox1.Text, "SAN RAFAEL")
                        frm_pedidos_proveedores.actualizar()
                        If IsNumeric(s) Then
                            Try
                                ImprimirRemision_DISAR(s, dt, a)
                                'MsgBox(Adjunto)
                                Dim data As New System.Net.Mail.Attachment(Adjunto)
                                correo.Attachments.Add(data)
                            Catch ex As Exception
                                MsgBox("No se logró adjuntar archivo al correo", MsgBoxStyle.Information, "Error de envío")
                            End Try
                        Else
                            MsgBox(s)
                        End If
                    End If
                Next

                Servidor.Credentials = New System.Net.NetworkCredential(Usuario, Contraseña)
                Servidor.Send(correo)

                Me.Close()
            Catch ex As Exception
                MessageBox.Show("No se logró enviar correo " + ex.Message, "Correo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MsgBox("No se ha cargado ninguna fila. No se puede enviar un pedido vacío al proveedor.", MsgBoxStyle.Critical, "Atención")
        End If
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

        Using stream As New FileStream(direccion_archivo & "Pedido " & ComboProv.Text & " Numero " & Numero & ".pdf", FileMode.Create)
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
            Dim cell As New PdfPCell(New Phrase("DISTRIBUIDORA SAN RAFAEL S. DE R.L. DE C.V. " & vbCrLf & _
                            "Pedido a Proveedor: " & ComboProv.Text, FontFactory.GetFont("arial", 12, Font.Bold, Color.BLACK)))
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

            Adjunto = direccion_archivo & "Pedido " & ComboProv.Text & " Numero " & Numero & ".pdf"
            'Process.Start(direccion_archivo & "Pedido " & ComboProv.Text & " Numero " & Numero & ".pdf")
        End Using

    End Sub

    Private Sub BtnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExcel.Click
        Dim openFD As New OpenFileDialog()
        With openFD
            .Title = "Seleccionar archivos"
            .Filter = "Archivos Excel(*.xls;*.xlsx)|*.xls;*xlsx|Todos los archivos(*.*)|*.*"
            .Multiselect = False
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                'DataDatos.Columns.Clear()
                ImportExcellToDataGridView(.FileName, DataDatos)
            End If
        End With
    End Sub

    Public Function ImportExcellToDataGridView(ByRef path As String, ByVal Datagrid As DataGridView)
        Try
            Dim stConexion As String = ("Provider=Microsoft.ACE.OLEDB.12.0;" & ("Data Source=" & (path & ";Extended Properties=""Excel 12.0;Xml;HDR=YES;IMEX=2"";" & "")))
            Dim cnConex As New OleDbConnection(stConexion)
            Dim Cmd As New OleDbCommand("Select * From [Calculo$]")
            Dim Ds As New DataSet
            Dim Da As New OleDbDataAdapter
            Dim Dt As New DataTable
            cnConex.Open()
            Cmd.Connection = cnConex
            Da.SelectCommand = Cmd
            Da.Fill(Ds)
            Dt = Ds.Tables(0)
            'Datagrid.Columns.Clear()
            For a As Integer = 0 To Dt.Rows.Count - 1
                If IsNumeric(Dt(a)(22)) Then
                    Dim Total As Decimal = Dt(a)(22)
                    Dim Entero = Int(Total)
                    Dim Dec As Decimal = Total - Entero
                    Dim Valor As Integer = Dt(a)(22)

                    If Dec = 0.5 Then
                        Valor = Math.Ceiling(Total)
                    Else
                        Valor = Math.Round(Total)
                    End If

                    DataDatos.Rows.Add(Dt(a)(2), Dt(a)(3), Valor, Dt(a)(0), Dt(a)(4))
                End If
            Next
            'Datagrid.DataSource = Dt
        Catch ex As Exception
            MsgBox("" & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return True
    End Function

    Private Sub BtnDestinatarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDestinatarios.Click
        Form_DestinatariosProveedores.Empresa = "SAN RAFAEL"
        Form_DestinatariosProveedores.Proveedor = ComboProv.SelectedValue

        Form_DestinatariosProveedores.TextEmpresa.Text = "SAN RAFAEL"
        Form_DestinatariosProveedores.TextProveedorID.Text = ComboProv.SelectedValue
        Form_DestinatariosProveedores.TextProveedor.Text = ComboProv.Text

        Form_DestinatariosProveedores.DataGridView1.Rows.Clear()

        Dim db As New cls_compras_pedidos

        Dim dtPrincipal As New DataTable
        Dim dtCopias As New DataTable

        dtPrincipal = db.CargaCorreos(ComboProv.SelectedValue, "O", "SAN RAFAEL")
        dtCopias = db.CargaCorreos(ComboProv.SelectedValue, "C", "SAN RAFAEL")

        For A As Integer = 0 To dtPrincipal.Rows.Count - 1
            Form_DestinatariosProveedores.DataGridView1.Rows.Add(dtPrincipal(A)(0), "Principal")
        Next
        For A As Integer = 0 To dtCopias.Rows.Count - 1
            Form_DestinatariosProveedores.DataGridView1.Rows.Add(dtCopias(A)(0), "Copia")
        Next
        Form_DestinatariosProveedores.ShowDialog()
    End Sub

End Class