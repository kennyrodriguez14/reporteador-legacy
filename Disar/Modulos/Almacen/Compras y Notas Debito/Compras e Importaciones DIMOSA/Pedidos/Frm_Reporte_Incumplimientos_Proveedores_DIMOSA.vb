Imports Disar.data

Public Class Frm_Reporte_Incumplimientos_Proveedores_DIMOSA

    Sub LlenarAlmacenes()
        Dim db As New cls_compras_pedidos
        ComboAlmacen.DataSource = db.CargarAlmacenes("DIMOSA")
        ComboAlmacen.ValueMember = "CVE_ALM"
        ComboAlmacen.DisplayMember = "DESCR"
    End Sub

    Sub LLenaProveedores()
        Dim db As New cls_compras_pedidos
        ComboProv.DataSource = db.CargaProveedores("DIMOSA")
        ComboProv.ValueMember = "CLAVE"
        ComboProv.DisplayMember = "NOMBRE"
    End Sub

    Private Sub Frm_Reporte_Incumplimientos_Proveedores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LLenaProveedores()
        LlenarAlmacenes()
    End Sub

    Private Sub BtnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGenerar.Click
        Dim db As New cls_compras_pedidos
        DataDatos.DataSource = db.CargaIncumplimientos(ComboProv.SelectedValue, ComboAlmacen.SelectedValue, DateTimePicker1.Value, DateTimePicker2.Value, "DIMOSA")
    End Sub

End Class