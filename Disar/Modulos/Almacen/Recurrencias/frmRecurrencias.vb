Imports Disar.data

Public Class frmRecurrencias
    Dim conexion As New clsRecurrencias
    Dim combo_encargado As New clsMalasCargas
    Dim soluciones As New clsSoluciones
    Dim Clase As New cls_reporte_carga
    Private Sub NuevoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevoToolStripMenuItem.Click
        frm_recurrencias_formato_nuevo_factura.Close()
        frm_recurrencias_formato_nuevo_factura.ShowDialog()
        'Limpiar()
        'ingreso.Visible = True
        'grdDatos.Visible = False
        'filtro.Visible = False
    End Sub

    Sub Limpiar()
        txtcantidad.Text = ""
        txtcodigo_apartado.Text = ""
        txtcodigo_reportado.Text = ""
        txtdescripcion1.Text = ""
        txtdescripcion2.Text = ""
    End Sub


    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        ingreso.Visible = False
        grdDatos.Visible = True
        filtro.Visible = True
        Guardar()
        cargar()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        ingreso.Visible = False
        grdDatos.Visible = True
        filtro.Visible = True
    End Sub

    Sub Guardar()
        Try
            conexion.Insert(cmbDia.Value.Date, cmbResponsable.SelectedValue, Val(txtcantidad.Text), txtcodigo_apartado.Text, txtcodigo_reportado.Text, cmbSolucion.SelectedValue, cmb_almacen_ins.SelectedValue, Cbox_Sucursal.SelectedValue)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        frm_ayuda_productos_sap.ShowDialog()
        txtcodigo_apartado.Text = frm_ayuda_productos_sap.sap
        txtdescripcion1.Text = frm_ayuda_productos_sap.des
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        frm_ayuda_productos_sap.ShowDialog()
        txtcodigo_reportado.Text = frm_ayuda_productos_sap.sap
        txtdescripcion2.Text = frm_ayuda_productos_sap.des
    End Sub

    Private Sub frmRecurrencias_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cbox_Sucursal.Text = "SAN RAFAEL"
        cargar()
        Cargar_almacen()
        llenar_cmb()
        llenar_cmb_soluciones()
    End Sub

    Sub cargar()
        Try
            If Cbox_Sucursal.Text = "SAN RAFAEL" Then
                grdDatos.DataSource = conexion.GetDatos(inicio.Value.Date, fin.Value.Date, cmb_sucursal_rpt.SelectedValue)
            ElseIf Cbox_Sucursal.Text = "DIMOSA" Then
                grdDatos.DataSource = conexion.GetDatosDimosa(inicio.Value.Date, fin.Value.Date, cmb_sucursal_rpt.SelectedValue)
            ElseIf Cbox_Sucursal.Text = "OPL" Then
                grdDatos.DataSource = conexion.GetDatosOPL(inicio.Value.Date, fin.Value.Date, cmb_sucursal_rpt.SelectedValue)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub llenar_cmb()
        cmbResponsable.DataSource = combo_encargado.llenar_combobox
        cmbResponsable.ValueMember = "ID"
        cmbResponsable.DisplayMember = "NOMBRE"
    End Sub

    Sub llenar_cmb_soluciones()
        cmbSolucion.DataSource = soluciones.llenar_soluciones()
        cmbSolucion.ValueMember = "ID"
        cmbSolucion.DisplayMember = "DESCRIPCION"
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        cargar()
    End Sub

    Sub Cargar_almacen()
        If Cbox_Sucursal.Text = "SAN RAFAEL" Then

            cmb_almacen_ins.DataSource = Clase.getAlmacen(0, 0, "CONSUMO", Now, "", "ALM", 1)
            cmb_almacen_ins.ValueMember = "ID"
            cmb_almacen_ins.DisplayMember = "ALMACEN"
            cmb_sucursal_rpt.DataSource = Clase.getAlmacen(0, 0, "CONSUMO", Now, "", "ALM", 1)
            cmb_sucursal_rpt.ValueMember = "ID"
            cmb_sucursal_rpt.DisplayMember = "ALMACEN"
        ElseIf Cbox_Sucursal.Text = "DIMOSA" Then

            cmb_almacen_ins.DataSource = Clase.getAlmacen(0, 0, "DIMOSA", Now, "", "ALM", 1)
            cmb_almacen_ins.ValueMember = "ID"
            cmb_almacen_ins.DisplayMember = "ALMACEN"

            cmb_sucursal_rpt.DataSource = Clase.getAlmacen(0, 0, "DIMOSA", Now, "", "ALM", 1)
            cmb_sucursal_rpt.ValueMember = "ID"
            cmb_sucursal_rpt.DisplayMember = "ALMACEN"

        ElseIf Cbox_Sucursal.Text = "OPL" Then

            cmb_almacen_ins.DataSource = Clase.getAlmacen(0, 0, "OPL", Now, "", "ALM", 1)
            cmb_almacen_ins.ValueMember = "ID"
            cmb_almacen_ins.DisplayMember = "ALMACEN"

            cmb_sucursal_rpt.DataSource = Clase.getAlmacen(0, 0, "OPL", Now, "", "ALM", 1)
            cmb_sucursal_rpt.ValueMember = "ID"
            cmb_sucursal_rpt.DisplayMember = "ALMACEN"
        End If

    End Sub

    Private Sub Cbox_Sucursal_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbox_Sucursal.SelectedIndexChanged
        Cargar_almacen()

    End Sub


End Class