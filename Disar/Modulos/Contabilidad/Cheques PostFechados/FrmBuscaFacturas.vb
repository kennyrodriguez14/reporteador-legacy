Imports Disar.data

Public Class FrmBuscaFacturas
    Public Fact As String
    Public Fecha As Date
    Public Monto As Decimal
    Public Saldo As Decimal
    Public Abonos As Decimal

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Try
            Fact = DataGridView1.CurrentRow.Cells("Documento").Value
            Fecha = DataGridView1.CurrentRow.Cells("Fecha").Value
            Monto = DataGridView1.CurrentRow.Cells("Importe").Value
            Abonos = DataGridView1.CurrentRow.Cells("Pagos").Value
            Saldo = DataGridView1.CurrentRow.Cells("Importe").Value - DataGridView1.CurrentRow.Cells("Pagos").Value
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FrmBuscaFacturas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ActualizaCreditos()
    End Sub

    Sub ActualizaCreditos()
        Dim db As New ClsCheques
        DataGridView1.DataSource = db.Saldos(FrmNuevoCheque.TxtClienteClave.Text)
    End Sub

    Private Sub DateFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateFecha.ValueChanged
        For Each row As DataGridViewRow In DataGridView1.Rows
            'Si el contenido de la columna coinside con el valor del TextBox
            If CDate(row.Cells("Fecha").Value.date) = CDate(DateFecha.Value.Date) Then
                'Selecciono fila y abandono bucle
                DataGridView1.CurrentCell = DataGridView1(0, row.Index)
                row.Selected = True
                Exit For
            End If
        Next
    End Sub
End Class