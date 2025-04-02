Imports Disar.data
Public Class frm_ayuda_productos_sap
    Dim conexion As New clsayudaProductos_agro
    Public sap, des As String
    Dim descripcion As String
    Private Sub frm_ayuda_productos_sap_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtBusqueda.Text = ""
        grdProducto.DataSource = conexion.codigo_sap(Val(txtBusqueda.Text), txtBusqueda.Text.ToUpper)
    End Sub

    Private Sub txtBusqueda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBusqueda.TextChanged
        grdProducto.DataSource = conexion.codigo_sap(Val(txtBusqueda.Text), txtBusqueda.Text.ToUpper)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        sap = grdProducto.CurrentRow.Cells(0).Value
        des = grdProducto.CurrentRow.Cells(1).Value
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class