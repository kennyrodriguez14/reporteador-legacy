Imports Disar.data
Public Class Ingreso
    Dim Conexion As New clsIncumplimientos
    Private Sub btnAyuda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAyuda.Click
        Busqueda.MdiParent = _Inicio
        Busqueda.Visible = True
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            Conexion.InsertarProducto(txtCodigo.Text, txtCantidad.Text, txtCliente.Text, cmbFecha.Value)
            MessageBox.Show("Incumplimiento Ingresado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtCodigo.Text = ""
            txtCantidad.Text = ""
            txtCodigo.Focus()
        Catch ex As Exception
            MessageBox.Show("Error al insertar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class