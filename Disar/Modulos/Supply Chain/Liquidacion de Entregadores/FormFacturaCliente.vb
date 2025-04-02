Imports Disar.data

Public Class FormFacturaCliente
    Public Facturas As String = ""
    Public Cliente As String = ""
    Public Entregador As Integer
    Public Fecha1, Fecha2 As Date

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        Cliente = TextNegocio.Text
        Facturas = TextFacturas.Text
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub FormFacturaCliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBusca.Text = ""
        CargaFacturas()
    End Sub

    Sub CargaFacturas()
        Try
            Dim db As New ClsEfectividad

            DataGridView1.DataSource = db.SeleccionarFacturas(Entregador, Fecha1.Date, Fecha2.Date, TextBusca.Text, frmLiquidacion.ComboEmpresa.Text)

        Catch ex As Exception
        End Try
        
    End Sub

    Private Sub TextBusca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBusca.TextChanged
        CargaFacturas()
    End Sub

    Private Sub DataGridView1_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        BtnSeleccionar.PerformClick()
    End Sub

    Private Sub BtnSeleccionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSeleccionar.Click
        TextNegocio.Text = DataGridView1.CurrentRow.Cells("NOMBRE").Value
        TextFacturas.Text = DataGridView1.CurrentRow.Cells("CVE_DOC").Value
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TextNegocio.Text = ""
        TextFacturas.Text = ""
    End Sub
End Class