Imports Disar.data

Public Class Usuarios
    Dim Con As New clsSeguridad
    Dim edit As String

    Private Sub Usuarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.BringToFront()

        cmbTipo.DataSource = Con.ListarTiposUsuarios("Tipos")
        cmbTipo.ValueMember = "ID"
        cmbTipo.DisplayMember = "TIPO"
        Cargar()
    End Sub

    Sub Cargar()
        Try
            gridUsuarios.DataSource = Con.ListarUsuarios
            gridUsuarios.Columns(2).Visible = False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub Buscar()
        Try
            gridUsuarios.DataSource = Con.BuscarUsuarios(TextBuscar.Text)
            gridUsuarios.Columns(2).Visible = False
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        txtPass.Enabled = True
        txtUser.Text = ""
        txtPass.Text = ""
        edit = "ins"
        cmbEstado.SelectedItem = "Activo"
        cmbTipo.SelectedItem = "Colaborador"
        Editar.Visible = True
        Lista.Visible = False
    End Sub

    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        txtNumReg.Text = gridUsuarios.CurrentRow.Cells(0).Value
        txtUser.Text = gridUsuarios.CurrentRow.Cells(1).Value
        txtPass.Text = gridUsuarios.CurrentRow.Cells(2).Value
        cmbEstado.SelectedItem = gridUsuarios.CurrentRow.Cells(3).Value
        cmbTipo.SelectedValue = gridUsuarios.CurrentRow.Cells(4).Value

        txtPass.Enabled = True
        edit = "upd"
        Editar.Visible = True
        Lista.Visible = False
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        Editar.Visible = False
        Lista.Visible = True

        If txtUser.Text = "" Or txtPass.Text = "" Then
            MsgBox("No puede dejar Nombre de Usuario o Contraseña en Blanco", MsgBoxStyle.Critical, "Error")
        Else
            If edit = "ins" Then
                Try
                    Con.Nuevo(txtUser.Text, txtPass.Text, cmbEstado.SelectedItem, cmbTipo.SelectedValue)
                    gridUsuarios.DataSource = Con.ListarUsuarios
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            ElseIf edit = "upd" Then
                Try
                    Con.Modificar(txtNumReg.Text, txtUser.Text, txtPass.Text, cmbEstado.SelectedItem, cmbTipo.SelectedValue)
                    gridUsuarios.DataSource = Con.ListarUsuarios
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Editar.Visible = False
        Lista.Visible = True
    End Sub

    Private Sub CerrarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CerrarToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub gridUsuarios_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gridUsuarios.DoubleClick
        frm_permisos.Close()
        frm_permisos.cod_usu = gridUsuarios.CurrentRow.Cells(0).Value
        frm_permisos.name_usu = gridUsuarios.CurrentRow.Cells(1).Value
        frm_permisos.ShowDialog()

    End Sub

    Private Sub TextBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBuscar.TextChanged
        Buscar()
    End Sub
End Class