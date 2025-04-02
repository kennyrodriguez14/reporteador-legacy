Imports Disar.data

Public Class frm_encargados
    Public Id As Integer
    Public Nombre As String
    Dim conexion As New clsMalasCargas
    Public Sucursal As String

    Private Sub frm_encargados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtBusqueda.Text = ""
        grdProducto.DataSource = conexion.ayuda_encargados(Val(txtBusqueda.Text), txtBusqueda.Text.ToUpper, Sucursal)
    End Sub

    Private Sub grdProducto_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdProducto.CellDoubleClick
        Id = grdProducto.CurrentRow.Cells(0).Value
        Nombre = grdProducto.CurrentRow.Cells(1).Value
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class