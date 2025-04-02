Imports Disar.data
Public Class frm_solucion_recurrencias
    Public Codigo As String
    Public Descripcion As String
    Dim conexion As New clsRecurrencias

    Private Sub grdProducto_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdProducto.CellDoubleClick
        Codigo = grdProducto.CurrentRow.Cells(0).Value
        Descripcion = grdProducto.CurrentRow.Cells(1).Value
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub frm_solucion_recurrencias_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        grdProducto.DataSource = conexion.Soluciones()
    End Sub
End Class


