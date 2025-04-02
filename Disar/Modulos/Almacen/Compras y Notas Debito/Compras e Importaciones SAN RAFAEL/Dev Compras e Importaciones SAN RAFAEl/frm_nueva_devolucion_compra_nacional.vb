Public Class frm_nueva_devolucion_compra_nacional

    Private Sub frm_nueva_devolucion_compra_nacional_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FormSelectorCompraDevolver.Tipo = "NACIONAL"
        FormSelectorCompraDevolver.ShowDialog()
    End Sub
End Class