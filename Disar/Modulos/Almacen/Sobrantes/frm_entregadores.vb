Imports Disar.data
Public Class frm_entregadores
    Public Codigo As String
    Public Descripcion As String
    Dim conexion As New cls_Sobrantes
    Public Sucursal As String
    Public Empresa As String
    Private Sub frm_entregadores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Empresa = "SR AGRO" Then
            grdProducto.DataSource = conexion.llenar_comboboxAgro(Sucursal)
        Else
            grdProducto.DataSource = conexion.llenar_combobox(Sucursal)
        End If
    End Sub

    Private Sub grdProducto_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdProducto.CellDoubleClick
        Codigo = grdProducto.CurrentRow.Cells(0).Value
        Descripcion = grdProducto.CurrentRow.Cells(1).Value
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class
