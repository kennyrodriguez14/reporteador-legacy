Imports Disar.data

Public Class frm_agregar_productos
    Dim conexion As New cls_nuevo_prod_prov
    Dim dt_mult As New DataTable

    Private Sub frm_agregar_proveedores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dt_mult.Columns.Add("CODIGO")
        dt_mult.Columns.Add("ALMACEN")

        entrada.SelectedItem = "cj"
        salida.SelectedItem = "pz"
        costeo.SelectedItem = "Promedio"
        equema.SelectedItem = "15%"
        cmb_empresa.SelectedItem = "SAN RAFAEL"
        cargar_lineas()
        cargar_proveedor()

        cargar_categoria()
        cargar_megacategoria()
        cargar_subcategoria()
        cargar_almacenes()
    End Sub

    Private Sub cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cancelar.Click
        Me.Close()
    End Sub

    Sub cargar_lineas()
        Try
            linea.DataSource = conexion.LISTAR_LINEAS(cmb_empresa.SelectedItem, txt_buscar_linea.Text)
            linea.ValueMember = "CVE_LIN"
            linea.DisplayMember = "DESC_LIN"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub cargar_proveedor()
        Try
            proveedor.DataSource = conexion.LISTAR_PROVEEDOR(cmb_empresa.SelectedItem, txt_buscar_proveedor.Text)
            proveedor.ValueMember = "CLAVE"
            proveedor.DisplayMember = "NOMBRE"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub cargar_almacenes()
        Try
            cmb_almacen.DataSource = conexion.LISTAR_ALMACENES(cmb_empresa.SelectedItem, txt_buscar_proveedor.Text)
            cmb_almacen.ValueMember = "CLAVE"
            cmb_almacen.DisplayMember = "ALMACEN"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub cargar_categoria()
        Try
            categoria.DataSource = conexion.LISTAR_CATEGORIA(cmb_empresa.SelectedItem)
            categoria.ValueMember = "C"
            categoria.DisplayMember = "C"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub cargar_subcategoria()
        Try
            subcategoria.DataSource = conexion.LISTAR_SUBCATEGORIA(cmb_empresa.SelectedItem)
            subcategoria.ValueMember = "C"
            subcategoria.DisplayMember = "C"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub cargar_megacategoria()
        Try
            megacategoria.DataSource = conexion.LISTAR_MEGACATEGORIA(cmb_empresa.SelectedItem)
            megacategoria.ValueMember = "C"
            megacategoria.DisplayMember = "C"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles aceptar.Click
        Dim resultado As String = ""
        Dim dt_precios As New DataTable
        dt_precios.Columns.Add("id")
        dt_precios.Columns.Add("valor")

        dt_precios.Rows.Add(1, Val(precio.Text))
        dt_precios.Rows.Add(4, Val(lista2.Text))
        dt_precios.Rows.Add(5, Val(lista3.Text))
        dt_precios.Rows.Add(6, Val(lista4.Text))
        dt_precios.Rows.Add(7, Val(lista5.Text))
        dt_precios.Rows.Add(8, Val(precio_teg.Text))

        Dim esquema As Integer = 0
        If equema.SelectedItem = "15%" Then
            esquema = 1
        Else
            esquema = 2
        End If

        Dim strcon_lote As String = ""

        If con_lote.Checked = True Then
            strcon_lote = "S"
        Else
            strcon_lote = "N"
        End If

        resultado = conexion.Insert_prod(cmb_empresa.SelectedItem.ToString(), codigo.Text, alterno.Text, paletizado_src.Text, _
                                         paletizado_sps.Text, ubicacion_sps.Text, cod_barra.Text, codigo_barra_cj.Text, _
                                         ubicacion_src.Text, ubicacion_tocoa.Text, categoria.Text, subcategoria.SelectedValue, _
                                         paletizado_sr_agro.Text, ubicacion_tegus.Text, megacategoria.Text, dt_precios, _
                                         descripcion.Text, proveedor.SelectedValue, linea.SelectedValue, entrada.Text, _
                                         Val(unidad_empaque.Text), salida.Text, Val(factor.Text), strcon_lote, Val(peso.Text), _
                                         Val(volumen.Text), esquema, dt_mult, _Inicio.lblUsuario.Text)
        If resultado = "correcto" Then
            Me.Close()
        Else
            MessageBox.Show(resultado)
        End If
    End Sub

    Private Sub txt_buscar_linea_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_buscar_linea.TextChanged
        cargar_lineas()
    End Sub

    Private Sub txt_buscar_proveedor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_buscar_proveedor.TextChanged
        cargar_proveedor()
    End Sub

    Private Sub cmb_empresa_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_empresa.SelectedIndexChanged
        cargar_lineas()
        cargar_proveedor()

        cargar_categoria()
        cargar_megacategoria()
        cargar_subcategoria()
        cargar_almacenes()
    End Sub

    Private Sub btn_agregar_multi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar_multi.Click
        Dim pasa As Integer = 0
        For index As Integer = 0 To dt_mult.Rows.Count - 1
            If dt_mult.Rows(index)(0) = cmb_almacen.SelectedValue Then
                MessageBox.Show("El almacén ya está seleccionado")
                pasa += 1
            Else
                pasa += 0
            End If
        Next

        If pasa <= 0 Then
            dt_mult.Rows.Add(cmb_almacen.SelectedValue, cmb_almacen.Text)
        End If

        grd_multialmacen.DataSource = dt_mult
    End Sub
End Class