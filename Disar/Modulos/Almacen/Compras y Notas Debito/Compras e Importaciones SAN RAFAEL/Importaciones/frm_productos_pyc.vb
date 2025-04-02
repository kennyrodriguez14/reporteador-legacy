Imports Disar.data
Public Class frm_productos_pyc
    Dim conexion_notas_debito As New cls_notas_debito
    Public usuario_id As Integer
    Public usuario_name As String
    Dim precio_anterior As String = 0

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        grp_ingreso.Visible = False
        grp_precios_productos.Visible = True
        Try
            Dim var_error As String = ""
            var_error = conexion_notas_debito.insertar_productopyc(txt_codigo.Text, txt_descripcion.Text, _Inicio.lblId.Text, _Inicio.lblUsuario.Text)
            If var_error = "correcto" Then
                MessageBox.Show("Producto agregado correctamente")
                enviarCorreo("Se agregó un nuevo producto que aplica a PYC Codigo: " & txt_codigo.Text.ToString() & " Producto: " & txt_descripcion.Text)
                cargar()
            Else
                MessageBox.Show("Error al agregar producto" + var_error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub enviarCorreo(ByVal contenido_mensaje As String)
        Try
            Dim SMTP As String = "mail.sanrafaelhn.com"
            Dim db As New clsReuniones
            Dim dt As New DataTable
            dt = db.Correo(_Inicio.lblUsuario.Text)
            Dim Usuario As String = "kenny.rodriguez@sanrafaelhn.com"
            'Usuario = dt(0)(0)
            Dim Contraseña As String = "krodriguez14"

            Dim Puerto As Integer = 25
            Dim correo As New System.Net.Mail.MailMessage()
            Dim Servidor As New System.Net.Mail.SmtpClient
            Dim Acceso As New System.Net.Mail.SmtpAccess

            Dim Contenido As String = ""
            Contenido = contenido_mensaje
            Dim Asunto As String = "Producto PYC"

            correo.From = New System.Net.Mail.MailAddress(Usuario)
            correo.Subject = Asunto

            'Dim query As String = "SELECT correo FROM nd_importaciones_correos_pyc"
            'For Each row As DataGridViewRow In DataParticipantes.Rows

            '    Dim mail As String = ""
            '    Dim dtCorreo As New DataTable
            '    Try
            '        dtCorreo.Rows.Clear()
            '    Catch ex As Exception
            '    End Try

            '    dtCorreo = db.Correo(row.Cells(0).Value)
            '    Try
            '        mail = dtCorreo(0)(0)
            '    Catch ex As Exception
            '    End Try

            '    If mail <> "" Then
            '        correo.To.Add(mail)
            '    End If

            'Next

            correo.To.Add("kenny.rodriguez@sanrafaelhn.com")
            correo.Body = Contenido
            Servidor.Host = SMTP
            Servidor.Port = Puerto

            Servidor.EnableSsl = False

            Servidor.Credentials = New System.Net.NetworkCredential(Usuario, Contraseña)

            Servidor.Send(correo)
            MessageBox.Show("El correo se envió exitosamente.", "Envío", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub frm_productos_pyc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar()
    End Sub

    Sub cargar()
        Try
            grid.DataSource = conexion_notas_debito.select_pyc()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        grp_ingreso.Visible = True
        grp_precios_productos.Visible = False
    End Sub

    Private Sub btn_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar.Click
        Try
            If MessageBox.Show("¿Está seguro de eliminar el producto " + grid.CurrentRow.Cells(1).Value + " de PYC?", "Confirmación", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Dim var_error As String = ""
                var_error = conexion_notas_debito.eliminar_productopyc(txt_codigo.Text, txt_descripcion.Text, _Inicio.lblId.Text, _Inicio.lblUsuario.Text)
                If var_error = "correcto" Then
                    MessageBox.Show("Producto eliminado correctamente")
                    enviarCorreo("Se elimino un producto que aplica a PYC Codigo: " & grid.CurrentRow.Cells(0).Value & " Producto: " & grid.CurrentRow.Cells(1).Value)
                    cargar()
                Else
                    MessageBox.Show("Error al eliminar el producto" + var_error)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        grp_ingreso.Visible = False
        grp_precios_productos.Visible = True
    End Sub

    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        If ayuda_producto_malas_cargas.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txt_codigo.Text = ayuda_producto_malas_cargas.grdProducto.CurrentRow.Cells(0).Value
            txt_descripcion.Text = ayuda_producto_malas_cargas.grdProducto.CurrentRow.Cells(1).Value
        End If
    End Sub
End Class