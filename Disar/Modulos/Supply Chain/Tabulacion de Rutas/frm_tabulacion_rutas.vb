Imports Disar.data
Public Class frm_tabulacion_rutas
    Dim conexion As New cls_guardar_tabulacion
    Private Sub btn_ayuda_ruta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ayuda_ruta.Click
        frm_tab_rutas.ShowDialog()
    End Sub

    Private Sub btn_ayuda_clientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ayuda_clientes.Click
        frm_tab_clientes.ShowDialog()
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Me.Close()
    End Sub

    Private Sub btn_agrega_grid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agrega_grid.Click
        Try
            If txt_codigo_cliente.Text = "" Then
                MessageBox.Show("Seleccione un cliente")
            Else
                grd_ingresar.Rows.Add(txt_codigo_cliente.Text, txt_nombre_cliente.Text, Val(txt_peso.Text), cmb_inicio_cliente.Value, cmb_fin_cliente.Value)
                txt_codigo_cliente.Text = ""
                txt_nombre_cliente.Text = ""
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_elimina_grid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_elimina_grid.Click
        Try
            grd_ingresar.Rows.RemoveAt(grd_ingresar.CurrentRow.Index)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        Try
            Dim dt As New DataTable
            For Each col As DataGridViewColumn In grd_ingresar.Columns
                Dim column As New DataColumn(col.Name, Type.GetType("System.String"))
                dt.Columns.Add(column)
            Next
            For Each viewRow As DataGridViewRow In grd_ingresar.Rows

                Dim row As DataRow = dt.NewRow()
                For Each col As DataGridViewColumn In grd_ingresar.Columns
                    Dim value As Object = viewRow.Cells(col.Name).Value
                    row.Item(col.Name) = If(value Is Nothing, DBNull.Value, value)
                Next col
                dt.Rows.Add(row)
            Next viewRow

            Dim confirmacion As String
            confirmacion = conexion.GUARDAR(txt_ruta.Text, Val(txt_id_ruta.Text), cmb_salida_hi.Value, cmb_salida_hf.Value, cmb_desayuno_hi.Value, cmb_desayuno_hf.Value _
                , cmb_almuerzo_hi.Value, cmb_almuerzo_hf.Value, cmb_llegada_hi.Value, cmb_llegada_hf.Value, cmb_devoluciones_hi.Value _
                , cmb_desayuno_hf.Value, cmb_liquidacion_hi.Value, cmb_liquidacion_hf.Value, dt)
            If confirmacion = "correcto" Then
                MessageBox.Show("Informacion Almacenada", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Me.Close()
            Else
                MessageBox.Show(confirmacion)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub frm_tabulacion_rutas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class