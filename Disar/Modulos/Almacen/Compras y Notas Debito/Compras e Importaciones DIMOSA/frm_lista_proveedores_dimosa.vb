Imports Disar.data
Public Class frm_lista_proveedores_dimosa
    Dim conexion As New cls_notas_debito
    Public codigo, nombre, rfc As String
    Public cargill As String
    Private Sub frm_lista_proveedores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        grd_lista.Focus()
        If cargill = "S" Then
            cargar_cargill()
        Else
            cargar()
        End If
    End Sub

    Sub cargar()
        Try
            grd_lista.DataSource = conexion.mostrar_proveedores_DIMOSA(txt_busqueda.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub cargar_cargill()
        Try
            grd_lista.DataSource = conexion.mostrar_proveedores_CARGILL(txt_busqueda.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txt_busqueda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_busqueda.TextChanged
        Try
            grd_lista.DataSource = conexion.mostrar_proveedores_DIMOSA(txt_busqueda.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub grd_lista_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grd_lista.DoubleClick
        Try
            codigo = grd_lista.CurrentRow.Cells(0).Value
            nombre = grd_lista.CurrentRow.Cells(1).Value
            rfc = grd_lista.CurrentRow.Cells(2).Value
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txt_busqueda_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_busqueda.KeyPress
        Try
            If Asc(e.KeyChar) = Keys.Enter Then
                codigo = grd_lista.CurrentRow.Cells(0).Value
                nombre = grd_lista.CurrentRow.Cells(1).Value
                rfc = grd_lista.CurrentRow.Cells(2).Value
                DialogResult = Windows.Forms.DialogResult.OK
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grd_lista_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grd_lista.KeyDown

        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            codigo = grd_lista.CurrentRow.Cells(0).Value
            nombre = grd_lista.CurrentRow.Cells(1).Value
            rfc = grd_lista.CurrentRow.Cells(2).Value
            DialogResult = Windows.Forms.DialogResult.OK
        End If
    End Sub

    Private Sub frm_lista_proveedores_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            codigo = grd_lista.CurrentRow.Cells(0).Value
            nombre = grd_lista.CurrentRow.Cells(1).Value
            rfc = grd_lista.CurrentRow.Cells(2).Value
            DialogResult = Windows.Forms.DialogResult.OK
        End If
    End Sub
End Class