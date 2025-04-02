Imports Disar.data

Public Class Frm_Carga_Productos_AGRO

    Public PROV As Integer
    Public CLAVE As String
    Public DESCRIPCION As String

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Carga()
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Try
            CLAVE = DataGridView1.CurrentRow.Cells(0).Value
            DESCRIPCION = DataGridView1.CurrentRow.Cells(1).Value
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Frm_Carga_Productos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Text = ""
        Carga()
    End Sub

    Sub Carga()
        Dim db As New cls_compras_pedidos
        DataGridView1.DataSource = db.BuscaProductos(TextBox1.Text, PROV, "SR AGRO")
    End Sub
End Class