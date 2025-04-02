Imports Disar.data
Public Class Envios
    Dim Con As New clsEnvios

    Private Sub Envios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cargar()
    End Sub

    Sub Cargar()
        Try
            GridEnvios.DataSource = Con.CargarEnvios
            GridEnvios.Columns(3).Visible = False
            GridEnvios.Columns(4).Visible = False
            GridEnvios.Columns(5).Visible = False
            GridEnvios.Columns(6).Visible = False
            GridEnvios.Columns(7).Visible = False
            GridEnvios.Columns(8).Visible = False
            GridEnvios.Columns(9).Visible = False
            GridEnvios.Columns(10).Visible = False
            GridEnvios.Columns(11).Visible = False
            GridEnvios.Columns(12).Visible = False
            GridEnvios.Columns(13).Visible = False
            GridEnvios.Columns(14).Visible = False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CerrarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CerrarToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub GridEnvios_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridEnvios.CellClick
        limpiar()
        Grid.Visible = False
        Modificar.Visible = True

        txtId.Text = GridEnvios.CurrentRow.Cells(0).Value
        txtFormu.Text = GridEnvios.CurrentRow.Cells(1).Value
        txtReporte.Text = GridEnvios.CurrentRow.Cells(2).Value
        txtEmisor.Text = GridEnvios.CurrentRow.Cells(3).Value
        txtReceptor.Text = GridEnvios.CurrentRow.Cells(4).Value
        txtCopia.Text = GridEnvios.CurrentRow.Cells(5).Value
        txtAsunto.Text = GridEnvios.CurrentRow.Cells(6).Value
        txtMensaje.Text = GridEnvios.CurrentRow.Cells(7).Value
        txtHora.Text = GridEnvios.CurrentRow.Cells(8).Value
        txtDescripcion.Text = GridEnvios.CurrentRow.Cells(9).Value
        txtDias.Text = GridEnvios.CurrentRow.Cells(10).Value
        txtServer.Text = GridEnvios.CurrentRow.Cells(11).Value
        txtPort.Text = GridEnvios.CurrentRow.Cells(12).Value
        cmbEstado.SelectedItem = GridEnvios.CurrentRow.Cells(13).Value
        txtContraseña.Text = GridEnvios.CurrentRow.Cells(14).Value
    End Sub

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        Datos.Enabled = True
        btnAceptar.Visible = True
        btnCancelar.Visible = True
        btnModificar.Visible = False
        btnAtras.Visible = False
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Datos.Enabled = False
        btnAceptar.Visible = False
        btnCancelar.Visible = False
        btnModificar.Visible = True
        btnAtras.Visible = True
        Guardar()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Datos.Enabled = False
        btnAceptar.Visible = False
        btnCancelar.Visible = False
        btnModificar.Visible = True
        btnAtras.Visible = True
    End Sub

    Sub Guardar()
        Try
            Con.Modificar(Val(txtId.Text), txtFormu.Text, txtReporte.Text, txtEmisor.Text, txtReceptor.Text, txtCopia.Text, _
                          txtAsunto.Text, txtMensaje.Text, txtHora.Text, txtDescripcion.Text, txtDias.Text, txtServer.Text, _
                          txtPort.Text, cmbEstado.SelectedItem, txtContraseña.Text)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnAtras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAtras.Click
        Cargar()
        Modificar.Visible = False
        Grid.Visible = True
    End Sub

    Sub limpiar()
        txtAsunto.Clear()
        txtContraseña.Clear()
        txtCopia.Clear()
        txtDescripcion.Clear()
        txtDias.Clear()
        txtEmisor.Clear()
        txtFormu.Clear()
        txtHora.Clear()
        txtId.Clear()
        txtMensaje.Clear()
        txtPort.Clear()
        txtReceptor.Clear()
        txtReporte.Clear()
        txtServer.Clear()
    End Sub
End Class