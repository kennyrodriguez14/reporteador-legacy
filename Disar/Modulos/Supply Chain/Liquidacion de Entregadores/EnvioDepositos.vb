Imports Disar.data

Public Class EnvioDepositos

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        Dim db As New ClsEfectividad
        Try
            If ComboBox1.Text = "Arqueos de Efectivo" Then
                DataDatos.DataSource = db.CargaEnviosBancos(DateTimePicker1.Value, _Inicio.Almacen)
            Else
                DataDatos.DataSource = db.CargaEnviosBancosDepositosClientes(DateTimePicker1.Value, _Inicio.Almacen)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEnviar.Click
        If ComboBox1.Text = "Arqueos de Efectivo" Then
            If DataDatos.RowCount > 0 Then
                Frm_EnvioDepositoDetalle.TextLiquidacion.Text = DataDatos.CurrentRow.Cells(0).Value
                Frm_EnvioDepositoDetalle.TextEntregadorID.Text = DataDatos.CurrentRow.Cells(1).Value
                Frm_EnvioDepositoDetalle.TextEntregadorNombre.Text = DataDatos.CurrentRow.Cells(2).Value
                Frm_EnvioDepositoDetalle.TextDeposito.Text = DataDatos.CurrentRow.Cells(3).Value
                Frm_EnvioDepositoDetalle.TextTotalIngresado.Text = DataDatos.CurrentRow.Cells(4).Value
                Frm_EnvioDepositoDetalle.TextTotalAutorizado.Text = DataDatos.CurrentRow.Cells(4).Value
                Frm_EnvioDepositoDetalle.TextRuta.Text = DataDatos.CurrentRow.Cells(5).Value
                Frm_EnvioDepositoDetalle.TextFecha.Text = DataDatos.CurrentRow.Cells(6).Value
                Frm_EnvioDepositoDetalle.TextTipo.Text = DataDatos.CurrentRow.Cells(7).Value
                Frm_EnvioDepositoDetalle.N_Almacen.Text = DataDatos.CurrentRow.Cells(8).Value
                Frm_EnvioDepositoDetalle.Tipo = DataDatos.CurrentRow.Cells(9).Value
                Frm_EnvioDepositoDetalle.ShowDialog()
            End If
        Else
            If DataDatos.RowCount > 0 Then
                Form_Envio_DepositosClientes.TextLiquidacion.Text = DataDatos.CurrentRow.Cells(0).Value
                Form_Envio_DepositosClientes.TextEntregadorID.Text = DataDatos.CurrentRow.Cells(1).Value
                Form_Envio_DepositosClientes.TextEntregadorNombre.Text = DataDatos.CurrentRow.Cells(2).Value
                Form_Envio_DepositosClientes.TextDeposito.Text = DataDatos.CurrentRow.Cells(3).Value
                Form_Envio_DepositosClientes.TextTotalIngresado.Text = DataDatos.CurrentRow.Cells(4).Value
                Form_Envio_DepositosClientes.TextTotalAutorizado.Text = DataDatos.CurrentRow.Cells(4).Value
                Form_Envio_DepositosClientes.TextRuta.Text = DataDatos.CurrentRow.Cells(5).Value
                Form_Envio_DepositosClientes.TextFecha.Text = DataDatos.CurrentRow.Cells(6).Value
                Form_Envio_DepositosClientes.TextTipo.Text = DataDatos.CurrentRow.Cells(7).Value
                Form_Envio_DepositosClientes.N_Almacen.Text = DataDatos.CurrentRow.Cells(8).Value
                Form_Envio_DepositosClientes.Tipo = DataDatos.CurrentRow.Cells(9).Value
                Form_Envio_DepositosClientes.TextBanco.Text = DataDatos.CurrentRow.Cells(10).Value
                Form_Envio_DepositosClientes.ShowDialog()
            End If
        End If
    End Sub

    Private Sub DataDatos_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataDatos.CellDoubleClick
        BtnEnviar.PerformClick()
    End Sub
End Class