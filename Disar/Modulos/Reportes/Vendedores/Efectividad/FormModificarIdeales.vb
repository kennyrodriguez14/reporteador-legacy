Imports Disar.data

Public Class FormModificarIdeales

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim DT As New DataTable
        DT.Columns.Add("VENDEDOR_ID")
        DT.Columns.Add("VENDEDOR")
        DT.Columns.Add("META")

        For Each row As DataGridViewRow In DataGridView1.Rows
            DT.Rows.Add(row.Cells(0).Value, row.Cells(1).Value, row.Cells(3).Value)
        Next

        Dim DB As New ClassVendedores
        Dim s = DB.GuardarIdealClientes(DT, DateTimePicker1.Value.Month, DateTimePicker1.Value.Year, _Inicio.lblUsuario.Text)

        If s = "s" Then
            MsgBox("Se guardó el nuevo ideal de clientes para los vendedores solicitados")
        Else
            MsgBox(s)
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim db As New ClassVendedores
        DataGridView1.DataSource = db.CargarIdealClientes(DateTimePicker1.Value.Month, DateTimePicker1.Value.Year)
        For a As Integer = 0 To DataGridView1.ColumnCount - 2
            DataGridView1.Columns(a).ReadOnly = True
        Next
    End Sub
End Class