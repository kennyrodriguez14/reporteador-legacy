Imports Disar.data
Public Class frm_presupuestos_des_tac_sragro
    Dim modo As String
    Dim Conexion As New cls_descuentos_tacticos_sragro
    Private Sub frm_presupuestos_des_tac_sragro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmb_status.SelectedItem = "ALTA"
        listar()
    End Sub

    Sub cargar_proveedor()
        Try
            cmb_proveedor.DataSource = Conexion.listar_proveedor()
            cmb_proveedor.DisplayMember = "NOMBRE"
            cmb_proveedor.ValueMember = "CLAVE"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub NuevoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevoToolStripMenuItem.Click
        modo = "ins"
        cmb_status.Enabled = True
        cmb_año.Visible = True
        cmb_mes.Visible = True
        txt_año.Visible = False
        txt_mes.Visible = False
        cmb_proveedor.Enabled = True
        limpiar()
        ingreso()
    End Sub

    Sub ingreso()
        cargar_proveedor()
        grp_datos.Visible = True
        grd_presupuestos.Visible = False
    End Sub

    Sub listar()
        grp_datos.Visible = False
        grd_presupuestos.Visible = True
        Try
            grd_presupuestos.DataSource = Conexion.listar_presupuestos(cmb_fecha.Value.Year, cmb_fecha.Value.Month, _
                                                                       DateAdd(DateInterval.Month, -1, cmb_fecha.Value).Year, _
                                                                     DateAdd(DateInterval.Month, -1, cmb_fecha.Value).Month)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub limpiar()
        txt_valor.Text = ""
        txt_restante.Text = ""
    End Sub

    Private Sub ModificarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModificarToolStripMenuItem.Click
        Try
            modo = "upd"
            ingreso()
            cmb_proveedor.Enabled = False
            cmb_año.Visible = False
            cmb_mes.Visible = False
            txt_año.Visible = True
            txt_mes.Visible = True
            txt_año.Text = grd_presupuestos.CurrentRow.Cells(0).Value
            txt_mes.Text = grd_presupuestos.CurrentRow.Cells(1).Value
            cmb_proveedor.SelectedValue = grd_presupuestos.CurrentRow.Cells(2).Value
            txt_mes_id.Text = grd_presupuestos.CurrentRow.Cells(7).Value
            txt_valor.Text = grd_presupuestos.CurrentRow.Cells(4).Value
            txt_restante.Text = grd_presupuestos.CurrentRow.Cells(5).Value
            cmb_status.SelectedItem = grd_presupuestos.CurrentRow.Cells(6).Value
            txt_restante.Visible = False
            lbl_restante.Visible = False
            lbl_estado.Visible = False
            cmb_status.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        Dim resultado As String = ""
        If modo = "ins" Then
            resultado = Conexion.Insertar(cmb_año.Value.Year, cmb_mes.Value.Month, cmb_proveedor.SelectedValue, _
                                Val(txt_valor.Text), Val(txt_restante.Text), cmb_status.Text)
        ElseIf modo = "upd" Then
            resultado = Conexion.Actualizar(Val(txt_valor.Text), Val(txt_restante.Text), cmb_status.Text, txt_año.Text, txt_mes_id.Text, cmb_proveedor.SelectedValue)
        End If
        If resultado = "correcto" Then
            MessageBox.Show("Informacion almacenada correctamente", "¡Bien!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            MessageBox.Show(resultado, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End If
        listar()
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        listar()
        limpiar()
    End Sub

    Private Sub btn_generar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_generar.Click
        listar()
    End Sub

    Private Sub EliminarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EliminarToolStripMenuItem.Click
        If grd_presupuestos.CurrentRow.Cells(6).Value = "ALTA" Then
            MessageBox.Show("El presupuesto no se puede eliminar", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
        Else
            If MessageBox.Show("Desea eliminar el presupuesto del proveedor " + cmb_proveedor.Text, "Confirmacion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim resultado As String
                resultado = Conexion.eliminar(txt_año.Text, txt_mes_id.Text, cmb_proveedor.SelectedValue)
                If resultado = "correcto" Then
                    MessageBox.Show("Registro eliminado", "¡Bien!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Else
                    MessageBox.Show(resultado, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                End If
            End If
        End If
    End Sub

    Private Sub txt_valor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_valor.TextChanged
        txt_restante.Text = Val(txt_valor.Text)
    End Sub
End Class