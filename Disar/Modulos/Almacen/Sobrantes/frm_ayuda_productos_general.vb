Imports Disar.data

Public Class frm_ayuda_productos_general
    Dim conexion As New clsayudaProductos_agro
    Public codigo, descripcion As String
    Private Sub frm_ayuda_productos_general_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtBusqueda.Text = ""
        grdProducto.DataSource = conexion.helper(Val(txtBusqueda.Text), txtBusqueda.Text.ToUpper)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        codigo = grdProducto.CurrentRow.Cells(0).Value
        descripcion = grdProducto.CurrentRow.Cells(1).Value
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub txtBusqueda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBusqueda.TextChanged
        grdProducto.DataSource = conexion.helper(Val(txtBusqueda.Text), txtBusqueda.Text.ToUpper)
    End Sub
End Class