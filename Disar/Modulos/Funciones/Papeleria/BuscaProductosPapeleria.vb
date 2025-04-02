Imports Disar.data

Public Class BuscaProductosPapeleria

    Public Almacen As Integer
    Public Clave As String
    Public Producto As String
    Public Existencias As Decimal

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Dim db As New ClsPapeleria
        DataGridView1.DataSource = db.BuscarPapeleria(Almacen, TextBox1.Text)
    End Sub

    Private Sub BuscaProductosPapeleria_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim db As New ClsPapeleria
        DataGridView1.DataSource = db.BuscarPapeleria(Almacen, TextBox1.Text)
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Clave = DataGridView1.CurrentRow.Cells(0).Value
        Producto = DataGridView1.CurrentRow.Cells(1).Value
        Existencias = DataGridView1.CurrentRow.Cells(2).Value
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class