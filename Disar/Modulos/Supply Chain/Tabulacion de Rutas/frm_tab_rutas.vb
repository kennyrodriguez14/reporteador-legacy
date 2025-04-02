Imports Disar.data
Public Class frm_tab_rutas
    Dim tipo As String
    Dim conexion As New cls_ayuda_rutas
    Private Sub frm_tab_rutas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar()
        listado()
    End Sub

    Private Sub NuevoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevoToolStripMenuItem.Click
        tipo = "ins"
        ingreso()
    End Sub

    Sub cargar()
        Try
            grd_rutas.DataSource = conexion.Listado()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub listado()
        group_listado.Visible = True
        group_ingreso.Visible = False
        txt_codigo_ruta.Text = ""
        txt_nombre_ruta.Text = ""
    End Sub

    Sub ingreso()
        group_listado.Visible = False
        group_ingreso.Visible = True
        txt_codigo_ruta.Text = ""
        txt_nombre_ruta.Text = ""
    End Sub

    Private Sub EditarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditarToolStripMenuItem.Click
        ingreso()
        txt_codigo_ruta.Text = grd_rutas.CurrentRow.Cells(0).Value
        txt_nombre_ruta.Text = grd_rutas.CurrentRow.Cells(1).Value
        tipo = "upd"
    End Sub

    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        If tipo = "ins" Then
            Try
                conexion.InsertRutas(txt_nombre_ruta.Text)
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        ElseIf tipo = "upd" Then
            Try
                conexion.UpdateRutas(txt_codigo_ruta.Text, txt_nombre_ruta.Text)
            Catch ex As Exception
                Throw ex
            End Try
        End If
        cargar()
        listado()
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        cargar()
        listado()
    End Sub

    Private Sub txt_busqueda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_busqueda.TextChanged
        Try
            grd_rutas.DataSource = conexion.BuscarNombre(txt_busqueda.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub grd_rutas_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grd_rutas.CellMouseDoubleClick
        frm_tabulacion_rutas.txt_id_ruta.Text = grd_rutas.CurrentRow.Cells(0).Value
        frm_tabulacion_rutas.txt_ruta.Text = grd_rutas.CurrentRow.Cells(1).Value
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class