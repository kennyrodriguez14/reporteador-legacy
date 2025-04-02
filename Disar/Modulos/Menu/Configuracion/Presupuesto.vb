Imports Disar.data
Public Class Presupuesto
    Dim Conexion As New clsPresupuestos
    Dim edit As String
    Private Sub Presupuesto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cargar()
    End Sub

    Sub Cargar()
        Try
            GridPresupuestos.DataSource = Conexion.ListarPresupuestos("TODOS")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        txtid.Enabled = True
        txtid.Text = ""
        txtnom.Text = ""
        txtpre.Text = ""
        txtsucu.Text = ""
        edit = "ins"
        Editar.Visible = True
        Lista.Visible = False
    End Sub

    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        txtid.Text = GridPresupuestos.CurrentRow.Cells(0).Value
        txtnom.Text = GridPresupuestos.CurrentRow.Cells(1).Value
        txtpre.Text = GridPresupuestos.CurrentRow.Cells(2).Value
        txtsucu.Text = GridPresupuestos.CurrentRow.Cells(3).Value
        edit = "upd"
        Editar.Visible = True
        Lista.Visible = False
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Editar.Visible = False
        Lista.Visible = True

        If txtnom.Text = "" Or txtpre.Text = "" Or txtid.Text = "" Or txtsucu.Text = "" Then
            MsgBox("No puede dejar ningun campo en Blanco", MsgBoxStyle.Critical, "Error")
        Else
            If edit = "ins" Then
                Try
                    Conexion.Nuevo(txtid.Text, txtnom.Text, txtpre.Text, txtsucu.Text)
                    GridPresupuestos.DataSource = Conexion.ListarPresupuestos("TODOS")
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            ElseIf edit = "upd" Then
                Try
                    Conexion.Modificar(txtid.Text, txtnom.Text, txtpre.Text, txtsucu.Text)
                    GridPresupuestos.DataSource = Conexion.ListarPresupuestos("TODOS")
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
End Class