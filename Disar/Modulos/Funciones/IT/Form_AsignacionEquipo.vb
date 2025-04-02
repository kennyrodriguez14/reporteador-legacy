Imports Disar.data

Public Class Form_AsignacionEquipo

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.CheckState = CheckState.Checked Then
            DateTimePicker1.Enabled = True
        Else
            DateTimePicker1.Enabled = False
        End If
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        Dim db As New clsInventarioIT
        Dim Lim As String
        If CheckBox1.CheckState = CheckState.Checked Then
            Lim = "S"
        Else
            Lim = "N"
        End If
        Try
            Dim b As String
            b = db.NuevaDevolAlmacen(Num.Text, Today.Date)

            Dim s As String
            s = db.NuevaAsignacion(Num.Text, TextRecibe.Text, TextNombreRecibe.Text, Today.Date, Lim, DateTimePicker1.Value, "Asignado", TextAccesorios.Text, TextObsevaciones.Text, TextEntrega.Text, ComboBox1.Text)

            If s = "s" Then
                MsgBox("Asignación completa")
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                MsgBox(s)
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Dispose()
    End Sub

    Private Sub TextRecibe_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextRecibe.Enter
        Frm_Personal.ShowDialog()
        If Frm_Personal.DialogResult = Windows.Forms.DialogResult.OK Then
            TextRecibe.Text = Frm_Personal.X
            TextNombreRecibe.Text = Frm_Personal.N
        End If
    End Sub

    Private Sub Form_AsignacionEquipo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Estado As String = FrmDetallesEquipo.TextAsignacion.Text
        Num.Text = FrmDetallesEquipo.Numero.Text
    End Sub
End Class