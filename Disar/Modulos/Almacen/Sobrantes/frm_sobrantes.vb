Imports Disar.data

Public Class frm_sobrantes
    Dim conexion As New cls_Sobrantes
    Dim Clase As New cls_reporte_carga
    Private Sub NuevoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevoToolStripMenuItem.Click
        'limpiar()
        'filtro.Visible = False
        'grdDatos.Visible = False
        'ingreso.Visible = True
        frm_sobrante_formatofactura.Close()
        frm_sobrante_formatofactura.ShowDialog()
    End Sub

    Sub limpiar()
        txtcantidad.Text = ""
        txtcodigo_apartado.Text = ""
        txtdescripcion1.Text = ""
        txtObservacion.Text = ""
        txtRuta.Text = ""
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        filtro.Visible = True
        grdDatos.Visible = True
        ingreso.Visible = False
        guardar()
        cargar()
    End Sub

    Sub guardar()
        Try
            conexion.Insert(cmbDia.Value.Date, txtcodigo_apartado.Text, Val(txtcantidad.Text), txtRuta.Text, cmbEntregador.SelectedValue, txtObservacion.Text, cmb_almacen.SelectedValue, "", Cbox_Sucursal.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        filtro.Visible = True
        grdDatos.Visible = True
        ingreso.Visible = False
    End Sub

    Private Sub frm_sobrantes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cbox_Sucursal.Text = "SAN RAFAEL"
        Cargar_almacen()
        cargar()
        llenar_cmb()
    End Sub

    Sub llenar_cmb()
        cmbEntregador.DataSource = conexion.llenar_combobox("")
        cmbEntregador.ValueMember = "ID"
        cmbEntregador.DisplayMember = "NOMBRE"
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        frm_ayuda_productos_general.ShowDialog()
        txtcodigo_apartado.Text = frm_ayuda_productos_general.codigo
        txtdescripcion1.Text = frm_ayuda_productos_general.descripcion
    End Sub

    Sub cargar()
        Try
            If Cbox_Sucursal.Text = "SAN RAFAEL" Then
                grdDatos.DataSource = conexion.listar(inicio.Value.Date, fin.Value.Date, cmb_sucursal.SelectedValue)
            ElseIf Cbox_Sucursal.Text = "DIMOSA" Then
                grdDatos.DataSource = conexion.listarDimosa(inicio.Value.Date, fin.Value.Date, cmb_sucursal.SelectedValue)
            ElseIf Cbox_Sucursal.Text = "SR AGRO" Then
                grdDatos.DataSource = conexion.listarSrAgro(inicio.Value.Date, fin.Value.Date, cmb_sucursal.SelectedValue)
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        cargar()
    End Sub

    Sub Cargar_almacen()

        If Cbox_Sucursal.Text = "SAN RAFAEL" Then

            cmb_almacen.DataSource = Clase.getAlmacen(0, 0, "CONSUMO", Now, "", "ALM", 1)
            cmb_almacen.ValueMember = "ID"
            cmb_almacen.DisplayMember = "ALMACEN"
            cmb_sucursal.DataSource = Clase.getAlmacen(0, 0, "CONSUMO", Now, "", "ALM", 1)
            cmb_sucursal.ValueMember = "ID"
            cmb_sucursal.DisplayMember = "ALMACEN"
        ElseIf Cbox_Sucursal.Text = "DIMOSA" Then

            cmb_almacen.DataSource = Clase.getAlmacen(0, 0, "DIMOSA", Now, "", "ALM", 1)
            cmb_almacen.ValueMember = "ID"
            cmb_almacen.DisplayMember = "ALMACEN"

            cmb_sucursal.DataSource = Clase.getAlmacen(0, 0, "DIMOSA", Now, "", "ALM", 1)
            cmb_sucursal.ValueMember = "ID"
            cmb_sucursal.DisplayMember = "ALMACEN"

        ElseIf Cbox_Sucursal.Text = "SR AGRO" Then

            cmb_almacen.DataSource = Clase.getAlmacen(0, 0, "SR AGRO", Now, "", "ALM", 1)
            cmb_almacen.ValueMember = "ID"
            cmb_almacen.DisplayMember = "ALMACEN"

            cmb_sucursal.DataSource = Clase.getAlmacen(0, 0, "SR AGRO", Now, "", "ALM", 1)
            cmb_sucursal.ValueMember = "ID"
            cmb_sucursal.DisplayMember = "ALMACEN"
        End If




    End Sub

    Private Sub CambiarStatusToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CambiarStatusToolStripMenuItem.Click
        If frm_verificacion.ShowDialog = Windows.Forms.DialogResult.OK Then
            Try
                conexion.CambiarVerificacion(grdDatos.CurrentRow.Cells(0).Value, frm_verificacion.Codigo)
                MessageBox.Show("!Verificacion Correcta!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cargar()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Cbox_Sucursal_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbox_Sucursal.SelectedIndexChanged
        Cargar_almacen()
    End Sub
End Class