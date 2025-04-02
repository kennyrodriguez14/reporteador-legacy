Imports Disar.data

Public Class frm_lista_clientes
    Dim conexion As New clsayudaClientes_agro
    Private Sub frm_lista_clientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtBusqueda.Text = ""
        grdClientes.DataSource = conexion.helper(Val(txtBusqueda.Text), txtBusqueda.Text.ToUpper)
    End Sub

    Private Sub txtBusqueda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBusqueda.TextChanged
        grdClientes.DataSource = conexion.helper(Val(txtBusqueda.Text), txtBusqueda.Text.ToUpper)
    End Sub

    Private Sub grdClientes_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdClientes.CellMouseDoubleClick
        frm_facturas_credito.lbl_codigo.Text = grdClientes.CurrentRow.Cells(0).Value
        frm_facturas_credito.lbl_clientes.Text = grdClientes.CurrentRow.Cells(1).Value
        frm_facturas_credito.txt_cve_vend.Text = grdClientes.CurrentRow.Cells(2).Value
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub grdClientes_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdClientes.CellContentClick

    End Sub
End Class