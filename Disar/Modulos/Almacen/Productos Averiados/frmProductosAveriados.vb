Imports Disar.data

Public Class frmProductosAveriados
    Dim conexion As New clsProductosAveriados
    Dim Clase As New cls_reporte_carga


    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        ayuda_clientes.Empresa = ComboEmpresa.Text
        ayuda_clientes.ShowDialog()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim id As Integer
        Try
            id = conexion.GetId()
            conexion.Insertar_Encabezados(id + 1, cmbFecha.Value.Date, codigo.Text, cmb_almacen.SelectedValue, ComboEmpresa.Text)
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

    Sub new_linea(ByVal codigo As String, ByVal descripcion As String, ByVal costo As Double)
        grdFactura.Rows.Add(codigo, descripcion, "", "", costo)
    End Sub

    Private Sub NuevoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevoToolStripMenuItem.Click
        grdFactura.Rows.Clear()
        codigo.Text = ""
        nombre.Text = ""
        grp_ingreso.Visible = True
        grdProductosAveriados.Visible = False
        filtro.Visible = False
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        grp_ingreso.Visible = False
        grdProductosAveriados.Visible = True
        filtro.Visible = True
    End Sub

    Private Sub frmProductosAveriados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cargar_almacen()
        cargar()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        cargar()
    End Sub

    Sub cargar()
        Try
            If ComboEmp.Text = "SAN RAFAEL" Then
                grdProductosAveriados.DataSource = conexion.GetFacturas(cmFechaIni.Value.Date, cmbSuursal.SelectedValue)
            Else
                grdProductosAveriados.DataSource = conexion.GetFacturasDimosa(cmFechaIni.Value.Date, cmbSuursal.SelectedValue)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ayuda_producto_malas_cargas.Empresa = ComboEmpresa.Text
        ayuda_producto_malas_cargas.ShowDialog()
    End Sub

    Sub Cargar_almacen()
        If ComboEmpresa.Text = "SAN RAFAEL" Then
            cmb_almacen.DataSource = Clase.getAlmacen(0, 0, "CONSUMO", Now, "", "ALM", 1)
            cmb_almacen.ValueMember = "ID"
            cmb_almacen.DisplayMember = "ALMACEN"

            cmbSuursal.DataSource = Clase.getAlmacen(0, 0, "CONSUMO", Now, "", "ALM", 1)
            cmbSuursal.ValueMember = "ID"
            cmbSuursal.DisplayMember = "ALMACEN"
        Else
            cmb_almacen.DataSource = Clase.getAlmacen(0, 0, "DIMOSA", Now, "", "ALM", 1)
            cmb_almacen.ValueMember = "ID"
            cmb_almacen.DisplayMember = "ALMACEN"

            cmbSuursal.DataSource = Clase.getAlmacen(0, 0, "DIMOSA", Now, "", "ALM", 1)
            cmbSuursal.ValueMember = "ID"
            cmbSuursal.DisplayMember = "ALMACEN"
        End If
        
    End Sub

    Private Sub ComboEmpresa_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboEmpresa.SelectedIndexChanged
        Cargar_almacen()
    End Sub

    Private Sub ComboEmp_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboEmp.SelectedIndexChanged
        ComboEmpresa.SelectedIndex = ComboEmp.SelectedIndex
    End Sub
End Class