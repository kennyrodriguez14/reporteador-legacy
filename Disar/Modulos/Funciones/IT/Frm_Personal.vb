Imports Disar.data

Public Class Frm_Personal

    Public X As String
    Public N As String

    Private Sub Frm_Personal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim db As New clsInventarioIT
        Try
            DataDatos.DataSource = db.VerEmpleados
        Catch ex As Exception
        End Try
        TextBox1.Focus()
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Dim db As New clsInventarioIT
        Try
            DataDatos.DataSource = db.BuscarEmpleados(TextBox1.Text)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DataDatos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataDatos.CellDoubleClick
        X = DataDatos.CurrentRow.Cells(0).Value
        N = DataDatos.CurrentRow.Cells(1).Value
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Dispose()
    End Sub

    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click
        X = DataDatos.CurrentRow.Cells(0).Value
        N = DataDatos.CurrentRow.Cells(1).Value
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class