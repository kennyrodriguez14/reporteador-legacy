Imports Disar.data

Public Class FrmModificarClientes
    Public Empresa As String

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        Dim db As New ClsCreacionClientes
        Dim s = ""
        If Empresa = "SAN RAFAEL" Then
            s = db.ModificarCliente(TextID.Text, TextNombre.Text, TextPropietario.Text, TextDireccion.Text, TextBarrio.Text, TextRTN.Text, TextTelefono.Text, TextDiaVisita.Text, TextLongitud.Text, TextLatitud.Text, TextMunicipio.Text, TextDepartamento.Text, ComboVendedor.SelectedValue)
        ElseIf Empresa = "DIMOSA" Then
            s = db.ModificarClienteDIMOSA(TextID.Text, TextNombre.Text, TextPropietario.Text, TextDireccion.Text, TextBarrio.Text, TextRTN.Text, TextTelefono.Text, TextDiaVisita.Text, TextLongitud.Text, TextLatitud.Text, TextDepartamento.Text, TextMunicipio.Text, ComboVendedor.SelectedValue)
        ElseIf Empresa = "OPL" Then
            s = db.ModificarClienteOPL(TextID.Text, TextNombre.Text, TextPropietario.Text, TextDireccion.Text, TextBarrio.Text, TextRTN.Text, TextTelefono.Text, TextDiaVisita.Text, TextLongitud.Text, TextLatitud.Text, TextDepartamento.Text, TextMunicipio.Text, ComboVendedor.SelectedValue)
        End If
        If s = "s" Then
            Dim Conexion_bita As New cls_bitacora_reporteador
            Conexion_bita.RegistraBitacora(Now, _Inicio.lblUsuario.Text, "Modificó cliente: " & TextID.Text & " - " & TextNombre.Text & " - " & Empresa, "Creación de Clientes", _
                                                  "Fecha: " & DateTime.Now)
            MsgBox("Cliente Modificado Exitosamente", MsgBoxStyle.Information, "Aviso")
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Else
            MsgBox(s)
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub TextMunicipio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextMunicipio.TextChanged
        Dim INICIO As Integer
        Dim FIN As Integer
        INICIO = TextNombre.Text.IndexOf("(")
        FIN = TextNombre.Text.IndexOf(")")

        TextNombre.SelectionStart = INICIO
        TextNombre.SelectionLength = FIN - INICIO

        TextNombre.SelectedText = "(" & TextMunicipio.Text
    End Sub

    Private Sub TextVendedor_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextVendedor.KeyDown
        If e.KeyData = Keys.Enter Then
            Try
                For X As Integer = TextVendedor.Text.Length To 4
                    TextVendedor.Text = " " & TextVendedor.Text
                Next
                ComboVendedor.SelectedValue = TextVendedor.Text
            Catch ex As Exception
            End Try
        End If
    End Sub

 
    Private Sub FrmModificarClientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If _Inicio.lblUsuario.Text = "Administrador" Or Empresa = "OPL" Then
            TextNombre.Enabled = True
            TextNombre.ReadOnly = False
        End If
    End Sub
End Class