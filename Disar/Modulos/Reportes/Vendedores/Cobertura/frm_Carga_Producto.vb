Imports Disar.data

Public Class frm_Carga_Producto
    Public ID As String
    Public Nombre As String

    Private Sub TextBusca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBusca.TextChanged
        Dim db As New ClsProductos
        DataProductos.DataSource = db.FiltraProductos(TextBusca.Text)
    End Sub

    Private Sub frm_Carga_Producto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim db As New ClsProductos
        DataProductos.DataSource = db.TodosProductos
    End Sub

    Private Sub DataProductos_CellContentDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataProductos.CellContentDoubleClick
        ID = DataProductos.CurrentRow.Cells(0).Value
        Nombre = DataProductos.CurrentRow.Cells(1).Value
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class