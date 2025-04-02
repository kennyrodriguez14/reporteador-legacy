
Imports Disar.data
Public Class frm_camiones
    Public Id As Integer
    Public Nombre As String
    Dim conexion As New cls_carga_camiones_formatofactura
    Public Sucursal As Integer

    Private Sub frm_camiones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        grdProducto.DataSource = conexion.select_camion(Sucursal)
    End Sub

    Private Sub grdProducto_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdProducto.CellDoubleClick
        Id = grdProducto.CurrentRow.Cells(0).Value
        Nombre = grdProducto.CurrentRow.Cells(1).Value
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class
