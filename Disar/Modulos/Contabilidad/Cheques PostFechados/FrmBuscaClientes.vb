Imports Disar.data

Public Class FrmBuscaClientes

    Public ID As String
    Public Nombre As String

    Private Sub TextBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyValue = Keys.Enter Then
            Dim db As New ClsCheques
            Try
                DataGridView1.DataSource = db.BuscaClientes(TextBox1.Text)
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub FrmBuscaClientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim db As New ClsCheques
        Try
            DataGridView1.DataSource = db.Clientes
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        ID = DataGridView1.CurrentRow.Cells(0).Value
        Nombre = DataGridView1.CurrentRow.Cells(1).Value
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

End Class