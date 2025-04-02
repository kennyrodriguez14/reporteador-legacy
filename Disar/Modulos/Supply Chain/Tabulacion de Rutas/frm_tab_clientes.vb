Imports Disar.data
Public Class frm_tab_clientes
    Dim conexion As New cls_ayuda_clientes
    Private Sub frm_tab_clientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmb_tipo_busqueda.SelectedItem = "Nombre"
        cargar()
    End Sub

    Sub cargar()
        Try
            grd_clientes.DataSource = conexion.Listar()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txt_busqueda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_busqueda.TextChanged

        If cmb_tipo_busqueda.SelectedItem = "Nombre" Then
            Try
                grd_clientes.DataSource = conexion.BuscarNombre(txt_busqueda.Text)
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        ElseIf cmb_tipo_busqueda.SelectedItem = "Codigo" Then
            Try
                grd_clientes.DataSource = conexion.BuscarCodigo(txt_busqueda.Text)
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub grd_clientes_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grd_clientes.CellMouseDoubleClick
        frm_tabulacion_rutas.txt_codigo_cliente.Text = grd_clientes.CurrentRow.Cells(0).Value
        frm_tabulacion_rutas.txt_nombre_cliente.Text = grd_clientes.CurrentRow.Cells(1).Value
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class