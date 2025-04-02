Imports Disar.data
Public Class frm_verificacion
    Public Codigo As String
    Public Descripcion As String
    Dim conexion As New cls_Sobrantes
    Private Sub frm_verificacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        grdProducto.DataSource = conexion.verificacion
    End Sub

    Private Sub grdProducto_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdProducto.CellDoubleClick
        Codigo = grdProducto.CurrentRow.Cells(0).Value
        Descripcion = grdProducto.CurrentRow.Cells(1).Value
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class

