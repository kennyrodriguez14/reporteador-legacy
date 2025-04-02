Imports Disar.data

Public Class FormAgregarRepuesto

    Public Repuesto As String
    Public Cantidad As Integer
    Public Costo As Decimal

    Private Sub DataDatos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataDatos.CellDoubleClick
        GroupBox1.Visible = True
    End Sub

    Private Sub Guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Guardar.Click
        GroupBox1.Visible = False
        Repuesto = DataDatos.CurrentRow.Cells(0).Value
        Cantidad = Cant.Value
        Costo = DataDatos.CurrentRow.Cells(2).Value * Cant.Value
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub FormAgregarRepuesto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim db As New ClsOrdenTrabajoVehicular
            DataDatos.DataSource = db.Repuestos
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TextBusca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBusca.TextChanged
        Try
            Try
                Dim db As New ClsOrdenTrabajoVehicular
                DataDatos.DataSource = db.RepuestosBusca(TextBusca.Text)
            Catch ex As Exception
            End Try
        Catch ex As Exception
        End Try
    End Sub
End Class