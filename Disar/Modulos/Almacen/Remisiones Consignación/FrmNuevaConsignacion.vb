Imports Disar.data
Imports System.IO
Imports System.Data
Imports System.Reflection
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class FrmNuevaConsignacion

    Dim remisiones As New cls_remisiones
    Dim Consig As New ClsConsignaciones
    Dim productos As New cls_listado_productos
    Dim serie As String = "", documento As String = "", ceros As String = "", rango As String = "", rtn_transportista As String = ""
    Dim marca As String = "", placa As String = ""
    Dim fecha_limite As Date
    Dim validador = 0
    Dim validador2 As Integer = 0
    Dim direccion_archivo = ""
    Dim CAI As String = "", rtn_remite As String = "", direccion_remite As String = "", rtn_destino As String = "", direccion_destino As String = ""
    Dim CapacidadVehiculo As Decimal

    Private Sub dgv_detalles_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgv_detalles.KeyDown
        If dgv_detalles.CurrentCell.ColumnIndex = 1 Then
            If e.KeyCode = Keys.F2 Then
                frm_productos_almacen.Close()
                frm_productos_almacen.Almacen = lbl_almacen.Text
                frm_productos_almacen.Empresa = lbl_empresa.Text
                frm_productos_almacen.ShowDialog()
                cmb_remite.Enabled = False
            End If
        End If
    End Sub

    Private Sub frm_guia_remision_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_remitente()
        cargar_destino(cmb_remite.SelectedValue, lbl_empresa.Text)
        cargar_transportista()
        cargar_motivo()
        Cargar_Vehiculo()
        cargar_salidas()
        cargar_entradas()
        Try
            cmb_motivo.SelectedIndex = 1
        Catch ex As Exception

        End Try
    End Sub

    Sub cargar_remitente()
        Try
            cmb_remite.DataSource = remisiones.Remite(_Inicio.lblId.Text)
            cmb_remite.DisplayMember = "DESCRIPCION"
            cmb_remite.ValueMember = "SUCURSAL_ID"
            Dim dt As New DataTable
            dt = remisiones.DatosSucursal(cmb_remite.SelectedValue)
            lbl_empresa.Text = dt.Rows(0).Item(4)
            lbl_almacen.Text = dt.Rows(0).Item(5)
        Catch ex As Exception

        End Try
    End Sub

    Sub cargar_entradas()
        Try
            If lbl_empresa.Text = "CONSUMO" Then
                cmb_concepto_entrada.DataSource = remisiones.conceptos_entradas_disar()
                cmb_concepto_entrada.DisplayMember = "DESCRIPCION"
                cmb_concepto_entrada.ValueMember = "CONCEPTO"
                cmb_concepto_entrada.SelectedValue = 14
            ElseIf lbl_empresa.Text = "SR AGRO" Then
                cmb_concepto_entrada.DataSource = remisiones.conceptos_entradas_sragro()
                cmb_concepto_entrada.DisplayMember = "DESCRIPCION"
                cmb_concepto_entrada.ValueMember = "CONCEPTO"
                cmb_concepto_entrada.SelectedValue = 14
            End If
        Catch ex As Exception

        End Try
    End Sub

    Sub cargar_salidas()
        Try
            If lbl_empresa.Text = "CONSUMO" Then
                cmb_concepto_salida.DataSource = remisiones.conceptos_salidas_disar()
                cmb_concepto_salida.DisplayMember = "DESCRIPCION"
                cmb_concepto_salida.ValueMember = "CONCEPTO"
                cmb_concepto_salida.SelectedValue = 67
            ElseIf lbl_empresa.Text = "SR AGRO" Then
                cmb_concepto_salida.DataSource = remisiones.conceptos_salidas_sragro()
                cmb_concepto_salida.DisplayMember = "DESCRIPCION"
                cmb_concepto_salida.ValueMember = "CONCEPTO"
                cmb_concepto_salida.SelectedValue = 67
            End If
        Catch ex As Exception

        End Try
    End Sub

    Sub cargar_destino(ByVal SUCURSAL As Integer, ByVal EMPRESA As String)
        Try
            cmb_destino.DataSource = remisiones.Destino(SUCURSAL, EMPRESA)
            cmb_destino.DisplayMember = "DESCRIPCION"
            cmb_destino.ValueMember = "SUCURSAL_ID"

            Dim dt As New DataTable
            dt = remisiones.DatosSucursal(cmb_destino.SelectedValue)
            lbl_almacen_destino.Text = dt.Rows(0).Item(5)

        Catch ex As Exception

        End Try
    End Sub

    Sub cargar_transportista()
        Try
            cmb_transportista.DataSource = remisiones.Transportista()
            cmb_transportista.DisplayMember = "EntregadorNombre"
            cmb_transportista.ValueMember = "EntregadorCodigo"
        Catch ex As Exception

        End Try
    End Sub

    Sub cargar_transportista_filtro(ByVal NOMBRE As String)
        Try
            cmb_transportista.DataSource = remisiones.Transportista_Filtro(NOMBRE)
            cmb_transportista.DisplayMember = "EntregadorNombre"
            cmb_transportista.ValueMember = "EntregadorCodigo"
        Catch ex As Exception

        End Try
    End Sub

    Sub cargar_motivo()
        Try
            cmb_motivo.DataSource = remisiones.Motivo()
            cmb_motivo.DisplayMember = "MOTIVO_TIPO"
            cmb_motivo.ValueMember = "MOTIVO_ID"
        Catch ex As Exception

        End Try
    End Sub

    Sub Cargar_Vehiculo()
        Try
            cmb_vehiculo.DataSource = remisiones.Vehiculo()
            cmb_vehiculo.DisplayMember = "DESCRIPCION"
            cmb_vehiculo.ValueMember = "ID"
            cmb_vehiculo.SelectedValue = "1"
        Catch ex As Exception

        End Try

    End Sub

    Private Sub txt_buscar_transportista_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_buscar_transportista.TextChanged
        cargar_transportista_filtro(txt_buscar_transportista.Text)
    End Sub

    Private Sub cmb_remite_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_remite.SelectedIndexChanged
        Try
            cargar_destino(cmb_remite.SelectedValue, lbl_empresa.Text)
            Dim dt As New DataTable
            dt = remisiones.DatosSucursal(cmb_remite.SelectedValue)
            lbl_empresa.Text = dt.Rows(0).Item(4)
            lbl_almacen.Text = dt.Rows(0).Item(5)
            cargar_entradas()
            cargar_salidas()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btn__Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_.Click
        Me.Close()
    End Sub

    Private Sub dgv_detalles_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_detalles.CellContentClick
        If e.ColumnIndex = 1 Then
            frm_productos_almacen.Close()
            frm_productos_almacen.Almacen = lbl_almacen.Text
            frm_productos_almacen.Empresa = lbl_empresa.Text

            cmb_remite.Enabled = False

            If frm_productos_almacen.ShowDialog = Windows.Forms.DialogResult.OK Then
                dgv_detalles.CurrentRow.Cells(2).Value = frm_productos_almacen.columna1
                dgv_detalles.CurrentRow.Cells(3).Value = frm_productos_almacen.columna2
                dgv_detalles.CurrentRow.Cells(4).Value = frm_productos_almacen.columna3
                dgv_detalles.CurrentRow.Cells(6).Value = frm_productos_almacen.columna4
            End If
        End If
    End Sub

    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        validar_inventarios()
        validar_si_existe()
        Dim fallo As String = ""
        Try
            If TextClaveCliente.Text <> "" Then


                If Val(TxtViajes.Text) > 0 Then
                    If validador2 = 0 Then
                        If validador = 0 Then

                            get_docto()
                            datos_remite()
                            datos_destino()
                            datos_transportista()
                            datos_vehiculo()
                            Try
                                If fecha_limite.Date < Now.Date Or Convert.ToInt32(documento.Substring(11, 8)) > Convert.ToInt32(rango.Substring(34, 8)) Then
                                    MessageBox.Show("Se está imprimiendo fuera del rango limite favor contactarse con el administrador: Fecha Lim. " _
                                                    & fecha_limite.Date & " Rango " & rango.Substring(34, 8), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                End If
                            Catch ex As Exception
                            End Try

                            Dim dt As New DataTable

                            dt.Columns.Add("id_remision")
                            dt.Columns.Add("remite")
                            dt.Columns.Add("destino")
                            dt.Columns.Add("transportista")
                            dt.Columns.Add("vehiculo")
                            dt.Columns.Add("motivo")
                            dt.Columns.Add("fecha_inicio")
                            dt.Columns.Add("fecha_fin")
                            dt.Columns.Add("cai")
                            dt.Columns.Add("rango")
                            dt.Columns.Add("fecha_lim_imp")
                            dt.Columns.Add("peso_total")
                            dt.Columns.Add("concepto_salida")
                            dt.Columns.Add("concepto_entrada")
                            Dim fila As DataRow = dt.NewRow
                            fila(0) = documento
                            fila(1) = cmb_remite.SelectedValue
                            fila(2) = 0
                            fila(3) = cmb_transportista.SelectedValue
                            fila(4) = cmb_vehiculo.SelectedValue
                            fila(5) = cmb_motivo.SelectedValue
                            fila(6) = cmb_fecha_inicio.Value.Date
                            fila(7) = cmb_fecha_final.Value.Date
                            fila(8) = CAI
                            fila(9) = rango
                            fila(10) = fecha_limite
                            fila(11) = lbl_peso_total.Text
                            fila(12) = cmb_concepto_salida.SelectedValue
                            fila(13) = cmb_concepto_entrada.SelectedValue
                            dt.Rows.Add(fila)

                            Dim dt2 As New DataTable
                            For i As Integer = 0 To dgv_detalles.ColumnCount - 1
                                dt2.Columns.Add(dgv_detalles.Columns(i).HeaderText)
                            Next
                            For j As Integer = 0 To dgv_detalles.Rows.Count - 1
                                If dgv_detalles.Rows(j).Cells(2).Value = "" Then
                                Else
                                    Dim fila_detalle As DataRow = dt2.NewRow
                                    For h As Integer = 0 To dgv_detalles.ColumnCount - 1
                                        fila_detalle(dgv_detalles.Columns(h).HeaderText) = dgv_detalles.Rows(j).Cells(h).Value
                                    Next
                                    dt2.Rows.Add(fila_detalle)
                                End If
                            Next

                            Dim otro_transportista As Boolean = False
                            Dim otro_vehiculo As Boolean = False

                            If cmb_otro_transportista.Checked = True Then
                                otro_transportista = True
                            End If
                            If cmb_otro_vehiculo.Checked = True Then
                                otro_vehiculo = True
                            End If

                            If lbl_empresa.Text = "CONSUMO" Then
                                fallo = Consig.NUEVASOLICITUDPROD(dt, dt2, otro_transportista, otro_vehiculo, _txt_otro_transportista.Text, _
                                                        txt_rtn_otro_transportista.Text, txt_marca_vehiculo.Text, txt_nplaca_vehiculo.Text, _Inicio.lblUsuario.Text, Val(TxtViajes.Text), TxtViajesRecomendados.Text, TextClaveCliente.Text)
                            End If


                            If fallo = "correcto" Then
                                btn_aceptar.Enabled = False
                                FolderBrowserDialog1.Description = "Guardar Remision"
                                If FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK _
                                 Then
                                    direccion_archivo = FolderBrowserDialog1.SelectedPath + "\"
                                End If
                                If lbl_empresa.Text = "CONSUMO" Then
                                    ImprimirRemision_DISAR()
                                ElseIf lbl_empresa.Text = "SR AGRO" Then
                                    ImprimirRemision_SRAGRO()
                                End If
                                Me.Close()
                            Else
                                MessageBox.Show(fallo, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                            End If

                        Else
                        End If
                    End If
                Else
                    MsgBox("La cantidad de viajes no puede ser 0. Coloque un entero positivo en el campo 'Cantidad de Viajes' para continuar")
                End If
            Else
                MsgBox("Debe seleccionarse un cliente para poder continuar", MsgBoxStyle.Information, "Atención")
            End If
        Catch ex As Exception
            MessageBox.Show(fallo + " " + ex.Message)
        End Try
    End Sub

    Sub datos_remite()
        Dim tabla_remite As DataTable
        tabla_remite = remisiones.DatosEmpresa(cmb_remite.SelectedValue)
        rtn_remite = tabla_remite.Rows(0).Item(0)
        direccion_remite = tabla_remite.Rows(0).Item(1)
        CAI = tabla_remite.Rows(0).Item(2)
        rango = tabla_remite.Rows(0).Item(3)
        fecha_limite = tabla_remite.Rows(0).Item(4)
    End Sub

    Sub datos_destino()
        If cmb_otro_destino.Checked = True Then
            rtn_destino = txt_rtn.Text
            direccion_destino = txt_destino.Text
        Else
            Dim tabla_destino As DataTable
            tabla_destino = remisiones.DatosEmpresa(cmb_destino.SelectedValue)
            rtn_destino = tabla_destino.Rows(0).Item(0)
            direccion_destino = tabla_destino.Rows(0).Item(1)
        End If
    End Sub

    Sub datos_transportista()
        Dim tabla_transportista As DataTable
        tabla_transportista = remisiones.DatosTransportista(cmb_transportista.SelectedValue)
        rtn_transportista = tabla_transportista.Rows(0).Item(0)
    End Sub

    Sub datos_vehiculo()
        Dim tabla_vehiculo As DataTable
        tabla_vehiculo = remisiones.DatosVehiculo(cmb_vehiculo.SelectedValue)
        marca = tabla_vehiculo.Rows(0).Item(0)
        placa = tabla_vehiculo.Rows(0).Item(1)
    End Sub

    Sub get_docto()
        Dim folios As New DataTable
        serie = ""
        documento = ""
        ceros = ""

        folios = remisiones.FOLIO(cmb_remite.SelectedValue)
        serie = folios.Rows(0).Item(0)
        documento = folios.Rows(0).Item(1)

        If documento.Length = 8 Then
        Else
            For i As Integer = 1 To (8 - documento.Length)
                ceros += "0"
            Next
        End If
        documento = serie + ceros + documento
    End Sub

    Sub validar_inventarios()
        Dim existencia
        Dim cantidad_remision = 0
        Dim incumplimiento(dgv_detalles.RowCount - 1)
        validador = 0
        For i As Integer = 0 To dgv_detalles.RowCount - 1
            existencia = 0
            cantidad_remision = 0
            If dgv_detalles.Rows(i).Cells(2).Value <> "" Then

                If lbl_empresa.Text = "CONSUMO" Then
                    If dgv_detalles.Rows(i).Cells(6).Value = "S" Then
                        existencia = productos.ValidarExistencia_consumo(Val(lbl_almacen.Text), dgv_detalles.Rows(i).Cells(2).Value)
                    Else
                        existencia = productos.ValidarExistencia_consumo_inventario(Val(lbl_almacen.Text), dgv_detalles.Rows(i).Cells(2).Value)
                    End If

                    For j As Integer = 0 To dgv_detalles.RowCount - 1
                        If dgv_detalles.Rows(i).Cells(2).Value = dgv_detalles.Rows(j).Cells(2).Value Then
                            cantidad_remision += dgv_detalles.Rows(j).Cells(0).Value
                        End If
                    Next
                    If IsDBNull(existencia) Then
                        existencia = 0
                    End If
                    If cantidad_remision > existencia Then
                        incumplimiento(i) = dgv_detalles.Rows(i).Cells(3).Value
                    End If
                ElseIf lbl_empresa.Text = "SR AGRO" Then

                    If dgv_detalles.Rows(i).Cells(6).Value = "S" Then
                        existencia = productos.ValidarExistencia_sr_agro(Val(lbl_almacen.Text), dgv_detalles.Rows(i).Cells(2).Value)
                    Else
                        existencia = productos.ValidarExistencia_inventarios_sragro(Val(lbl_almacen.Text), dgv_detalles.Rows(i).Cells(2).Value)
                    End If

                    For j As Integer = 0 To dgv_detalles.RowCount - 1
                        If dgv_detalles.Rows(i).Cells(2).Value = dgv_detalles.Rows(j).Cells(2).Value Then
                            cantidad_remision += dgv_detalles.Rows(j).Cells(0).Value
                        End If
                    Next
                    If cantidad_remision > existencia Then
                        incumplimiento(i) = dgv_detalles.Rows(i).Cells(3).Value
                    End If
                End If
            End If
        Next

        For index As Integer = 0 To incumplimiento.Length - 1
            If incumplimiento(index) <> "" Then
                MessageBox.Show("La cantidad mayor a existencias en el poducto: " + incumplimiento(index))
                validador += 1
            End If
        Next

        For index As Integer = 0 To dgv_detalles.Rows.Count - 1

            If dgv_detalles.Rows(index).Cells(0).Value = "" Then
            Else
                If dgv_detalles.Rows(index).Cells(2).Value = "" Then
                    MessageBox.Show("debe seleccionar minimo un producto ")
                    validador += 1
                End If
            End If
        Next

        If dgv_detalles.Rows.Count - 1 = 0 Then
            MessageBox.Show("debe seleccionar minimo un producto ")
            validador += 1
        End If
    End Sub

    Sub validar_si_existe()
        validador2 = 0
        Dim no_existen(dgv_detalles.RowCount - 1)

        For i As Integer = 0 To dgv_detalles.RowCount - 1
            If dgv_detalles.Rows(i).Cells(2).Value <> "" Then
                If lbl_empresa.Text = "CONSUMO" Then
                    If productos.ValidarSIexiste_prod_CONSUMO(Val(lbl_almacen_destino.Text), dgv_detalles.Rows(i).Cells(2).Value) = True Then
                    Else
                        validador2 += 1
                        no_existen(i) = dgv_detalles.Rows(i).Cells(3).Value
                    End If
                ElseIf lbl_empresa.Text = "SR AGRO" Then
                    If productos.ValidarSIexiste_prod_SRAGRO(Val(lbl_almacen_destino.Text), dgv_detalles.Rows(i).Cells(2).Value) = True Then
                    Else
                        validador2 += 1
                        no_existen(i) = dgv_detalles.Rows(i).Cells(3).Value
                    End If
                End If
            End If
        Next
        For index As Integer = 0 To no_existen.Length - 1
            If no_existen(index) <> "" Then
                MessageBox.Show("El Producto: " + no_existen(index) + " no existe en el almacen de destino", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                validador += 1
            End If
        Next
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

        Dim tabla_grilla As New PdfPTable(dgv_detalles.ColumnCount)
        tabla_grilla.DefaultCell.Padding = 3
        tabla_grilla.WidthPercentage = 30
        tabla_grilla.HorizontalAlignment = Element.ALIGN_LEFT
        tabla_grilla.DefaultCell.BorderWidth = 1
        tabla_grilla.WidthPercentage = (480 / 5.23F)
        tabla_grilla.SetWidths(New Integer() {1, 1, 1, 5, 1, 1, 1})
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

        Using stream As New FileStream(direccion_archivo & "GuiaRemision " + documento + ".pdf", FileMode.Create)
            Dim pdfDoc As New Document(PageSize.A2, 10.0F, 10.0F, 10.0F, 0.0F)
            PdfWriter.GetInstance(pdfDoc, stream)
            pdfDoc.Open()

            Dim logo As Image
            Dim recurso As String = My.Computer.FileSystem.CurrentDirectory
            logo = Image.GetInstance(recurso & "\Resources\DISTRIBUIDORA_SAN_RAFAEL.png")
            tabla_encabezado.AddCell(logo)
            Dim cell As New PdfPCell(New Phrase("DISTRIBUIDORA SAN RAFAEL, S. DE R.L. de C.V. " & vbCrLf & _
                            "Bº Villa Belen a 500 metros UPN, Santa Rosa Copan.  " & vbCrLf & _
                            "Bº El Progeso, Santa Rosa Copan. " & vbCrLf & _
                            "Bº Villas del Rosario carretera circunvalacion, Gracias Lempira." & vbCrLf & _
                            "Bº Guadalupe, 1 Ave, entre 24 y 25 Calle, N. O. San Pedro Sula." & vbCrLf & _
                            "Bº Las Flores, entre 6 Y 7 Ave NE, entre 4 Y 5 Calle NE, Tocoa Colon" & vbCrLf & _
                            "RTN 16139011441906	" & vbCrLf & _
                            "info@disarhn.com " & vbCrLf & _
                            "Tel. 2509-0007", FontFactory.GetFont("arial", 20, Font.Bold, Color.BLACK)))
            cell.BorderColor = Color.WHITE
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tabla_encabezado.AddCell(cell)
            tabla_encabezado.AddCell(New Phrase("Guia de Remision #: " & vbCrLf & _
                            documento, FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))

            tabla_sub_encabezado.AddCell(New Phrase("CAI: " & CAI, FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))
            tabla_sub_encabezado.AddCell("")
            tabla_sub_encabezado.AddCell("")
            tabla_sub_encabezado.AddCell(New Phrase("Remite:     " & cmb_remite.Text & vbCrLf & "RTN:         " & rtn_remite & vbCrLf & _
                                         "Direccion: " & direccion_remite, FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))
            tabla_sub_encabezado.AddCell("")
            tabla_sub_encabezado.AddCell(New Phrase("Fecha inicio de traslado: " & vbCrLf & cmb_fecha_inicio.Value.Date, FontFactory.GetFont("arial", 14, Font.Bold, Color.BLACK)))

            Dim destino As String = ""
            If cmb_otro_destino.Checked = True Then
                destino = txt_destino.Text
            Else
                destino = cmb_destino.Text
            End If


            tabla_sub_encabezado.AddCell(New Phrase("Destino:    " & destino & vbCrLf & "RTN:         " & rtn_destino & vbCrLf & _
                                         "Direccion: " & direccion_destino, FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))
            tabla_sub_encabezado.AddCell("")
            tabla_sub_encabezado.AddCell(New Phrase("Fecha final de traslado: " & vbCrLf & cmb_fecha_final.Value.Date, FontFactory.GetFont("arial", 14, Font.Bold, Color.BLACK)))

            Dim transportista As String = ""
            Dim rtn_transportista_new As String = ""
            Dim marca_new As String = ""
            Dim placa_new As String = ""
            If cmb_otro_transportista.Checked = True Then
                transportista = txt_otro_transportista.Text
                rtn_transportista_new = txt_rtn_otro_transportista.Text
            Else
                transportista = cmb_transportista.Text
                rtn_transportista_new = rtn_transportista
            End If

            If cmb_otro_vehiculo.Checked = True Then
                marca_new = txt_marca_vehiculo.Text
                placa_new = txt_nplaca_vehiculo.Text
            Else
                marca_new = marca
                placa_new = placa
            End If

            tabla_transportista.AddCell("")
            tabla_transportista.AddCell(New Phrase("    Transportista: " & transportista & vbCrLf & _
                                        "                 RTN: " & rtn_transportista_new & vbCrLf & _
                                        " Vehiculo Marca: " & marca_new & vbCrLf & _
                                        "              #Placa: " & placa_new, FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))
            tabla_transportista.AddCell("")

            Dim cell_sangria_titulo As New PdfPCell(New Phrase(""))
            cell_sangria_titulo.BorderColor = Color.WHITE
            tabla_grilla.AddCell(cell_sangria_titulo)
            For index As Integer = 0 To dgv_detalles.ColumnCount - 1
                If index = 1 Then
                Else
                    Dim cell_encabezado As New PdfPCell(New Phrase(dgv_detalles.Columns(index).HeaderText.ToUpper, FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))
                    cell_encabezado.BackgroundColor = Color.GRAY
                    tabla_grilla.AddCell(cell_encabezado)
                End If
            Next

            For i As Integer = 0 To dgv_detalles.RowCount - 1
                Dim cell_sangria_contenido As New PdfPCell(New Phrase(""))
                cell_sangria_contenido.BorderColor = Color.WHITE
                tabla_grilla.AddCell(cell_sangria_contenido)
                For j As Integer = 0 To dgv_detalles.ColumnCount - 1
                    If j = 1 Then
                    Else
                        tabla_grilla.AddCell(New Phrase(Convert.ToString(dgv_detalles.Rows(i).Cells(j).Value), FontFactory.GetFont("arial", 16, Font.Bold, Color.BLACK)))
                    End If
                Next
            Next

            Dim cell_motivo As New PdfPCell(New Phrase("Motivo: ", FontFactory.GetFont("arial", 16, Font.Bold, Color.BLACK)))
            cell_motivo.BackgroundColor = Color.GRAY
            tabla_motivo.AddCell(cell_motivo)

            Dim cell_motivo_des As New PdfPCell(New Phrase(cmb_motivo.Text, FontFactory.GetFont("arial", 16, Font.Bold, Color.BLACK)))
            cell_motivo_des.BackgroundColor = Color.GRAY
            tabla_motivo.AddCell(cell_motivo_des)

            Dim cell_motivo_sangria As New PdfPCell(New Phrase(""))
            cell_motivo_sangria.BorderColor = Color.WHITE
            tabla_motivo.AddCell(cell_motivo_sangria)

            Dim cell_peso_titulo As New PdfPCell(New Phrase("Peso Total: ", FontFactory.GetFont("arial", 16, Font.Bold, Color.BLACK)))
            cell_peso_titulo.BackgroundColor = Color.GRAY
            tabla_motivo.AddCell(cell_peso_titulo)

            Dim cell_peso_valor As New PdfPCell(New Phrase(lbl_peso_total.Text, FontFactory.GetFont("arial", 16, Font.Bold, Color.BLACK)))
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

            Process.Start(direccion_archivo & "GuiaRemision " + documento + ".pdf")
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

        Dim tabla_grilla As New PdfPTable(dgv_detalles.ColumnCount)
        tabla_grilla.DefaultCell.Padding = 3
        tabla_grilla.WidthPercentage = 30
        tabla_grilla.HorizontalAlignment = Element.ALIGN_LEFT
        tabla_grilla.DefaultCell.BorderWidth = 1
        tabla_grilla.WidthPercentage = (480 / 5.23F)
        tabla_grilla.SetWidths(New Integer() {1, 1, 1, 5, 1, 1, 1})
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

        Using stream As New FileStream(direccion_archivo & "GuiaRemision " + documento + ".pdf", FileMode.Create)
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
                            documento, FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))

            tabla_sub_encabezado.AddCell(New Phrase("CAI: " & CAI, FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))
            tabla_sub_encabezado.AddCell("")
            tabla_sub_encabezado.AddCell("")
            tabla_sub_encabezado.AddCell(New Phrase("Remite:     " & cmb_remite.Text & vbCrLf & "RTN:         " & rtn_remite & vbCrLf & _
                                         "Direccion: " & direccion_remite, FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))
            tabla_sub_encabezado.AddCell("")
            tabla_sub_encabezado.AddCell(New Phrase("Fecha inicio de traslado: " & vbCrLf & cmb_fecha_inicio.Value.Date, FontFactory.GetFont("arial", 14, Font.Bold, Color.BLACK)))
            Dim destino As String = ""
            If cmb_otro_destino.Checked = True Then
                destino = txt_destino.Text
            Else
                destino = cmb_destino.Text
            End If
            tabla_sub_encabezado.AddCell(New Phrase("Destino:    " & destino & vbCrLf & "RTN:         " & rtn_destino & vbCrLf & _
                                         "Direccion: " & direccion_destino, FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))
            tabla_sub_encabezado.AddCell("")
            tabla_sub_encabezado.AddCell(New Phrase("Fecha final de traslado: " & vbCrLf & cmb_fecha_final.Value.Date, FontFactory.GetFont("arial", 14, Font.Bold, Color.BLACK)))

            Dim transportista As String = ""
            Dim rtn_transportista_new As String = ""
            Dim marca_new As String = ""
            Dim placa_new As String = ""
            If cmb_otro_transportista.Checked = True Then
                transportista = txt_otro_transportista.Text
                rtn_transportista_new = txt_rtn_otro_transportista.Text
            Else
                transportista = cmb_transportista.Text
                rtn_transportista_new = rtn_transportista
            End If

            If cmb_otro_vehiculo.Checked = True Then
                marca_new = txt_marca_vehiculo.Text
                placa_new = txt_nplaca_vehiculo.Text
            Else
                marca_new = marca
                placa_new = placa
            End If

            tabla_transportista.AddCell("")
            tabla_transportista.AddCell(New Phrase("    Transportista: " & transportista & vbCrLf & _
                                        "                 RTN: " & rtn_transportista_new & vbCrLf & _
                                        "Vehiculo Marca: " & marca_new & vbCrLf & _
                                        "              #Placa: " & placa_new, FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))
            tabla_transportista.AddCell("")

            Dim cell_sangria_titulo As New PdfPCell(New Phrase(""))
            cell_sangria_titulo.BorderColor = Color.WHITE
            tabla_grilla.AddCell(cell_sangria_titulo)
            For index As Integer = 0 To dgv_detalles.ColumnCount - 1
                If index = 1 Then
                Else
                    Dim cell_encabezado As New PdfPCell(New Phrase(dgv_detalles.Columns(index).HeaderText.ToUpper, FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))
                    cell_encabezado.BackgroundColor = Color.GRAY
                    tabla_grilla.AddCell(cell_encabezado)
                End If
            Next

            For i As Integer = 0 To dgv_detalles.RowCount - 1
                Dim cell_sangria_contenido As New PdfPCell(New Phrase(""))
                cell_sangria_contenido.BorderColor = Color.WHITE
                tabla_grilla.AddCell(cell_sangria_contenido)
                For j As Integer = 0 To dgv_detalles.ColumnCount - 1
                    If j = 1 Then
                    Else
                        tabla_grilla.AddCell(New Phrase(Convert.ToString(dgv_detalles.Rows(i).Cells(j).Value), FontFactory.GetFont("arial", 16, Font.Bold, Color.BLACK)))
                    End If
                Next
            Next

            Dim cell_motivo As New PdfPCell(New Phrase("Motivo: ", FontFactory.GetFont("arial", 16, Font.Bold, Color.BLACK)))
            cell_motivo.BackgroundColor = Color.GRAY
            tabla_motivo.AddCell(cell_motivo)

            Dim cell_motivo_des As New PdfPCell(New Phrase(cmb_motivo.Text, FontFactory.GetFont("arial", 16, Font.Bold, Color.BLACK)))
            cell_motivo_des.BackgroundColor = Color.GRAY
            tabla_motivo.AddCell(cell_motivo_des)

            Dim cell_motivo_sangria As New PdfPCell(New Phrase(""))
            cell_motivo_sangria.BorderColor = Color.WHITE
            tabla_motivo.AddCell(cell_motivo_sangria)

            Dim cell_peso_titulo As New PdfPCell(New Phrase("Peso Total: ", FontFactory.GetFont("arial", 16, Font.Bold, Color.BLACK)))
            cell_peso_titulo.BackgroundColor = Color.GRAY
            tabla_motivo.AddCell(cell_peso_titulo)

            Dim cell_peso_valor As New PdfPCell(New Phrase(lbl_peso_total.Text, FontFactory.GetFont("arial", 16, Font.Bold, Color.BLACK)))
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

            Process.Start(direccion_archivo & "GuiaRemision " + documento + ".pdf")
        End Using
    End Sub

    Private Sub cmb_fecha_final_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_fecha_final.ValueChanged
        If cmb_fecha_inicio.Value.Date > cmb_fecha_final.Value.Date Then
            MessageBox.Show("La fecha final debe ser mayor a la fecha inicial", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            cmb_fecha_final.Value = cmb_fecha_inicio.Value.Date
        End If
    End Sub

    Private Sub cmb_fecha_inicio_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_fecha_inicio.ValueChanged
        If cmb_fecha_inicio.Value.Date > cmb_fecha_final.Value.Date Then
            MessageBox.Show("La fecha Inicial debe ser menor a la fecha final", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            cmb_fecha_inicio.Value = cmb_fecha_final.Value.Date
        End If
    End Sub

    Private Sub cmb_otro_destino_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_otro_destino.CheckedChanged
        Try
            If cmb_otro_destino.Checked = True Then
                cmb_destino.DataSource = Nothing
                cmb_destino.Enabled = False
                datos_externos.Visible = True
            ElseIf cmb_otro_destino.Checked = False Then
                cargar_destino(cmb_remite.SelectedValue, lbl_empresa.Text)
                cmb_destino.Enabled = True
                datos_externos.Visible = False
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub lbl_empresa_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_empresa.TextChanged
        Try
            cargar_destino(cmb_remite.SelectedValue, lbl_empresa.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgv_detalles_CellBeginEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgv_detalles.CellBeginEdit
        calcular_peso()
    End Sub

    Private Sub dgv_detalles_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_detalles.CellEndEdit
        calcular_peso()
    End Sub

    Sub calcular_peso()
        Try
            Dim total As Double = 0
            For index As Integer = 0 To dgv_detalles.RowCount - 1
                dgv_detalles.Rows(index).Cells(5).Value = dgv_detalles.Rows(index).Cells(0).Value * dgv_detalles.Rows(index).Cells(4).Value
                total += dgv_detalles.Rows(index).Cells(5).Value
            Next
            lbl_peso_total.Text = FormatNumber(total, 2)

            If lbl_peso_total.Text <> "0.00" Then
                TxtViajesRecomendados.Text = (Val(lbl_peso_total.Text.Replace(",", "")) / Val(TxtVehiculoCapacidad.Text))
                TxtViajes.Text = Math.Ceiling(Val(TxtViajesRecomendados.Text))
            Else
                TxtViajesRecomendados.Text = "1"
            End If
            If TxtViajesRecomendados.Text = "Infinito" Then
                TxtViajesRecomendados.Text = "1"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgv_detalles_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_detalles.CellValueChanged
        calcular_peso()
    End Sub

    Private Sub cmb_otro_transportista_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_otro_transportista.CheckedChanged
        If cmb_otro_transportista.Checked = True Then
            cmb_transportista.Enabled = False
            pnl_transportista.Visible = True
        ElseIf cmb_otro_transportista.Checked = False Then
            cargar_transportista()
            cmb_transportista.Enabled = True
            pnl_transportista.Visible = False
        End If
    End Sub

    Private Sub cmb_otro_vehiculo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_otro_vehiculo.CheckedChanged
        If cmb_otro_vehiculo.Checked = True Then
            cmb_vehiculo.Enabled = False
            pnl_vehiculo.Visible = True
        ElseIf cmb_otro_vehiculo.Checked = False Then
            Cargar_Vehiculo()
            cmb_vehiculo.Enabled = True
            pnl_vehiculo.Visible = False
        End If
    End Sub

    Private Sub cmb_destino_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_destino.SelectedIndexChanged
        Try
            Dim dt As New DataTable
            dt = remisiones.DatosSucursal(cmb_destino.SelectedValue)
            lbl_almacen_destino.Text = dt.Rows(0).Item(5)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmb_vehiculo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_vehiculo.SelectedIndexChanged
        Try
            If Not IsDBNull(remisiones.VehiculoPeso(cmb_vehiculo.SelectedValue).rows(0).item("CAPACIDAD")) Then
                TxtVehiculoCapacidad.Text = remisiones.VehiculoPeso(cmb_vehiculo.SelectedValue).rows(0).item("CAPACIDAD")
            Else
                TxtVehiculoCapacidad.Text = ""
            End If
            If lbl_peso_total.Text <> "0.00" Then
                TxtViajesRecomendados.Text = (Val(lbl_peso_total.Text.Replace(",", "")) / Val(TxtVehiculoCapacidad.Text))
                TxtViajes.Text = Math.Ceiling(Val(TxtViajesRecomendados.Text))
            Else
                TxtViajesRecomendados.Text = "1"
            End If
            If TxtViajesRecomendados.Text = "Infinito" Then
                TxtViajesRecomendados.Text = "1"
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnBuscaCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscaCliente.Click
        If frm_clientes.ShowDialog = Windows.Forms.DialogResult.OK Then
            TextClaveCliente.Text = frm_clientes.codigo
            TextNombreCliente.Text = frm_clientes.cliente
        End If
    End Sub

End Class