Imports Disar.data
Public Class Login
    Dim Con As New clsSeguridad
    Dim Ingreso As Integer = 0
    Dim bloqueado As Integer = 0

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Try
            If txtUsuario.Text = "" Or txtPass.Text = "" Then
                MsgBox("Campos Vacios", MsgBoxStyle.Critical, "Error")
            Else
                For i As Integer = 0 To gridUsuarios.RowCount - 1
                    If txtUsuario.Text = gridUsuarios.Rows(i).Cells(1).Value Then
                        If txtPass.Text = gridUsuarios.Rows(i).Cells(2).Value Then
                            If gridUsuarios.Rows(i).Cells(3).Value = "Bloqueado" Then
                                MsgBox("Usuario Bloqueado", MsgBoxStyle.Critical, "Error")
                                bloqueado = 1
                            Else
                                _Inicio.lblId.Text = gridUsuarios.Rows(i).Cells(0).Value
                                _Inicio.lblPass.Text = gridUsuarios.Rows(i).Cells(2).Value
                                _Inicio.Departamento = gridUsuarios.Rows(i).Cells(5).Value
                                _Inicio.AceptaRemisiones = gridUsuarios.Rows(i).Cells(6).Value
                                _Inicio.lbl_usuario_tipo.Text = gridUsuarios.Rows(i).Cells(4).Value
                                i = gridUsuarios.RowCount - 1
                                Ingreso = 1
                                _Inicio.Status_Usuarios.Text = txtUsuario.Text
                                _Inicio.Status_Usuarios.Visible = True
                                _Inicio.lblUsuario.Text = txtUsuario.Text
                                _Inicio.BarraMenu.Visible = True

                                Try
                                    Con.Status(txtUsuario.Text, 1, Now, _Inicio.IP)
                                Catch ex As Exception
                                    MsgBox(ex.Message)
                                End Try
                                'Me.Close()
                                Me.DialogResult = Windows.Forms.DialogResult.OK
                            End If
                        Else
                            txtPass.Text = ""
                            Ingreso = 0
                        End If
                    Else
                        txtPass.Focus()
                    End If
                Next
                If Ingreso = 0 And bloqueado <> 1 Then
                    MsgBox("Usuario o Contraseña Incorrectos", MsgBoxStyle.Critical, "Error")
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
        _Inicio.Close()
    End Sub

    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cargar()
    End Sub

    Sub Cargar()
        Try
            gridUsuarios.DataSource = Con.ListarUsuarios
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Class
