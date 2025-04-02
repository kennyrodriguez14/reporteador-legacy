Imports Disar.data
Public Class Presupuestos_Deptos
    Dim conexion As New clsPresupuestoXdepto
    Dim tipo As String = ""

    Private Sub Presupuestos_Deptos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Ver()
    End Sub

    Sub Ver()
        grpInsertar.Visible = False
        grpListado.Visible = True
        Cargar()
    End Sub

    Sub Ingreso()
        grpInsertar.Visible = True
        grpListado.Visible = False
        txtDepartamento.Focus()
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        tipo = "ins"
        Limpiar()
        Ingreso()
    End Sub

    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        tipo = "upd"
        Limpiar()
        txtCodigo.Text = gridPresupuestos.CurrentRow.Cells(0).Value
        txtDepartamento.Text = gridPresupuestos.CurrentRow.Cells(1).Value
        txtPresupuesto.Text = gridPresupuestos.CurrentRow.Cells(2).Value
        txtCuenta.Text = gridPresupuestos.CurrentRow.Cells(3).Value
        Ingreso()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If tipo = "ins" Then
            Try
                conexion.Nuevo(txtDepartamento.Text, Val(txtPresupuesto.Text), txtCuenta.Text)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        ElseIf tipo = "upd" Then
            Try
                conexion.Modificar(txtCodigo.Text, txtDepartamento.Text, Val(txtPresupuesto.Text), txtCuenta.Text)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
        tipo = ""
        Ver()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        tipo = ""
        Ver()
    End Sub

    Sub Limpiar()
        txtCodigo.Text = ""
        txtDepartamento.Text = ""
        txtPresupuesto.Text = ""
        txtCuenta.Text = ""
    End Sub

    Sub Cargar()
        Try
            gridPresupuestos.DataSource = conexion.Listar()
            gridPresupuestos.Columns(0).Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
       
        If MessageBox.Show("Desea Eliminar el Departamento " + gridPresupuestos.CurrentRow.Cells(1).Value, "Confirmacion", _
                           MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
            Try
                conexion.Eliminar(gridPresupuestos.CurrentRow.Cells(0).Value)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            Cargar()
        End If
    End Sub
End Class