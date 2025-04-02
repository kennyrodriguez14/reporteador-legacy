Imports Disar.data
Public Class frmCarga_promedio_Camiones
    Dim conexion As New clsCarga_Promedio_Camiones
    Dim Clase As New cls_reporte_carga
    Private Sub frmCarga_promedio_Camiones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbTurno.SelectedItem = "Diurno"
        cargar()
        Cargar_almacen()
    End Sub

    Sub cargar()
        grdDatos.DataSource = conexion.SelectCarga(inicio.Value.Date, fin.Value.Date, cmb_sucursal.SelectedValue)
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            If MessageBox.Show("¿Las cantidades son correctas?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                conexion.Insertar_Camion(cmbDia.Value, cmbTurno.SelectedItem, txtPeso.Text, txtcantidad.Text, cmb_almacen.SelectedValue)
                txtcantidad.Text = ""
                txtPeso.Text = ""
                MessageBox.Show("Se almacenaron los datos", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        ingreso.Visible = False
        grdDatos.Visible = True
        filtro.Visible = True
    End Sub

    Private Sub NuevoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevoToolStripMenuItem.Click
        txtcantidad.Text = ""
        txtPeso.Text = ""
        grdDatos.Visible = False
        filtro.Visible = False
        ingreso.Visible = True
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        filtro.Visible = True
        ingreso.Visible = False
        grdDatos.Visible = True
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        cargar()
    End Sub

    Sub Cargar_almacen()
        cmb_almacen.DataSource = Clase.getAlmacen(0, 0, "CONSUMO", Now, "", "ALM", 1)
        cmb_almacen.ValueMember = "ID"
        cmb_almacen.DisplayMember = "ALMACEN"

        cmb_sucursal.DataSource = Clase.getAlmacen(0, 0, "CONSUMO", Now, "", "ALM", 1)
        cmb_sucursal.ValueMember = "ID"
        cmb_sucursal.DisplayMember = "ALMACEN"
    End Sub
End Class