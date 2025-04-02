Imports Disar.data

Public Class frmProductosAveriados_agro
    Dim conexion As New clsProductosAveriados_agro
    Dim Clase As New cls_reporte_carga

    Private Sub frmProductosAveriados_agro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cargar_almacen()
        cargar()
    End Sub


    Sub cargar()
        Try
            grdProductosAveriados.DataSource = conexion.GetFacturas(cmFechaIni.Value.Date, cmbSuursal.SelectedValue)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub Cargar_almacen()
        cmb_almacen.DataSource = Clase.getAlmacen(0, 0, "SR AGRO", Now, "", "ALM", 1)
        cmb_almacen.ValueMember = "ID"
        cmb_almacen.DisplayMember = "ALMACEN"

        cmbSuursal.DataSource = Clase.getAlmacen(0, 0, "SR AGRO", Now, "", "ALM", 1)
        cmbSuursal.ValueMember = "ID"
        cmbSuursal.DisplayMember = "ALMACEN"
    End Sub

    Private Sub NuevoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevoToolStripMenuItem.Click
        grdFactura.Rows.Clear()
        codigo.Text = ""
        nombre.Text = ""
        grp_ingreso.Visible = True
        grdProductosAveriados.Visible = False
        filtro.Visible = False
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        cargar()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        grp_ingreso.Visible = False
        grdProductosAveriados.Visible = True
        filtro.Visible = True
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim id As Integer
        Try
            id = conexion.GetId()
            conexion.Insertar_Encabezados(id + 1, cmbFecha.Value.Date, codigo.Text, cmb_almacen.SelectedValue)
            For index As Integer = 0 To grdFactura.Rows.Count - 1
                conexion.Insertar_Detalle(id + 1, Convert.ToString(grdFactura.Rows(index).Cells(0).Value), grdFactura.Rows(index).Cells(3).Value, grdFactura.Rows(index).Cells(2).Value)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        grp_ingreso.Visible = False
        grdProductosAveriados.Visible = True
        filtro.Visible = True
        grdFactura.Rows.Clear()
        codigo.Text = ""
        nombre.Text = ""
        cargar()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        ayuda_clientes_agro.ShowDialog()
    End Sub

    Sub new_linea(ByVal codigo As String, ByVal descripcion As String, ByVal costo As Double)
        grdFactura.Rows.Add(codigo, descripcion, "", "", costo)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ayuda_productos_agro.ShowDialog()
    End Sub
End Class