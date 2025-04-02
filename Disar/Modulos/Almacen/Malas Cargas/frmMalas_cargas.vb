Imports Disar.data
Public Class frmMalas_cargas
    Dim conexion As New clsMalasCargas
    Dim Clase As New cls_reporte_carga

    Private Sub NuevoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevoToolStripMenuItem.Click
        frm_malas_cargas_formato_factura.Close()
        frm_malas_cargas_formato_factura.ShowDialog()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        guardar()
        ingreso.Visible = False
        grdDatos.Visible = True
        filtro.Visible = True

        Try
            grdDatos.DataSource = conexion.Listar(inicio.Value.Date, fin.Value.Date, cmb_almacen.SelectedValue)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        ingreso.Visible = False
        grdDatos.Visible = True
        filtro.Visible = True
    End Sub

    Sub guardar()
        Try
            conexion.Insert(cmbDia.Value.Date, Val(txtcantidad.Text), txtcodigo_reporte.Text, txtcodigo_cargado.Text, cmbEncargado.SelectedValue, txtobservacion.Text, cmb_sucursal.SelectedValue)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub frmMalas_cargas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            llenar_cmb()
            Cargar_sucursal()
            Cargar_almacen()
            grdDatos.DataSource = conexion.Listar(inicio.Value.Date, fin.Value.Date, cmb_almacen.SelectedValue)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub llenar_cmb()
        cmbEncargado.DataSource = conexion.llenar_combobox
        cmbEncargado.ValueMember = "ID"
        cmbEncargado.DisplayMember = "NOMBRE"
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        frm_ayuda_productos_sap.ShowDialog()
        txtcodigo_reporte.Text = frm_ayuda_productos_sap.sap
        txtdescripcion1.Text = frm_ayuda_productos_sap.des
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        frm_ayuda_productos_sap.ShowDialog()
        txtcodigo_cargado.Text = frm_ayuda_productos_sap.sap
        txtdescripcion2.Text = frm_ayuda_productos_sap.des
    End Sub

    Sub limpiar()
        txtcantidad.Text = ""
        txtcodigo_cargado.Text = ""
        txtcodigo_reporte.Text = ""
        txtdescripcion1.Text = ""
        txtdescripcion2.Text = ""
        txtobservacion.Text = ""
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            grdDatos.DataSource = conexion.Listar(inicio.Value.Date, fin.Value.Date, cmb_almacen.SelectedValue)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub Cargar_sucursal()
        cmb_sucursal.DataSource = Clase.getAlmacen(0, 0, "CONSUMO", Now, "", "ALM", 1)
        cmb_sucursal.ValueMember = "ID"
        cmb_sucursal.DisplayMember = "ALMACEN"
    End Sub

    Sub Cargar_almacen()
        cmb_almacen.DataSource = Clase.getAlmacen(0, 0, "CONSUMO", Now, "", "ALM", 1)
        cmb_almacen.ValueMember = "ID"
        cmb_almacen.DisplayMember = "ALMACEN"
    End Sub


End Class