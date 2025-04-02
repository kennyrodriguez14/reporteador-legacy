Imports Disar.data

Public Class ayuda_clientes
    Dim conexion As New clsayudaClientes
    Public Empresa As String
    Private Sub ayuda_clientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtBusqueda.Text = ""
        If Empresa = "SAN RAFAEL" Then
            grdClientes.DataSource = conexion.helper(txtBusqueda.Text.ToUpper, txtBusqueda.Text.ToUpper)
        Else
            grdClientes.DataSource = conexion.helper_dimosa(txtBusqueda.Text.ToUpper, txtBusqueda.Text.ToUpper)
        End If

    End Sub

    Private Sub txtBusqueda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBusqueda.TextChanged
        If Empresa = "SAN RAFAEL" Then
            grdClientes.DataSource = conexion.helper(txtBusqueda.Text.ToUpper, txtBusqueda.Text.ToUpper)
        Else
            grdClientes.DataSource = conexion.helper_dimosa(txtBusqueda.Text.ToUpper, txtBusqueda.Text.ToUpper)
        End If
    End Sub

    Private Sub grdClientes_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdClientes.CellMouseDoubleClick
        frmProductosAveriados.codigo.Text = grdClientes.CurrentRow.Cells(0).Value
        frmProductosAveriados.nombre.Text = grdClientes.CurrentRow.Cells(1).Value
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class