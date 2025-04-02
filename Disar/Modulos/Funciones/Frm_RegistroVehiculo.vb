Imports Disar.data

Public Class Frm_RegistroVehiculo

    Public Genera As String

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGenerar.Click
        Llena()
    End Sub

    Private Sub Nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nuevo.Click
        GroupReg.Visible = True
        GroupTodo.Visible = False
    End Sub

    Private Sub Frm_RegistroVehiculo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GroupReg.Visible = False
        GroupTodo.Visible = True
        LlenaVehiculos()
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        Dim db As New ClsBitacoraEventos
        Try
            Dim s = db.VNuevoVehiculo(Today.Date, DateFecha.Value, ComboVehiculo.SelectedValue, TextEncargado.Text, TextKilometraje.Text, _Inicio.lblUsuario.Text, TextMotivo.Text)
            If s = "s" Then
                MsgBox("Registro almacenado exitosamente.", MsgBoxStyle.Information, "Guardado")
                Limpiar()
                GroupTodo.Visible = True
                GroupReg.Visible = False
                BtnGenerar.PerformClick()
            Else
                MsgBox(s)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Limpiar()
        GroupReg.Visible = False
        GroupTodo.Visible = True
    End Sub

    Sub Limpiar()
        TextEncargado.Text = ""
        TextMotivo.Text = ""
        DateFecha.Value = Today
        TextKilometraje.Text = ""
    End Sub

    Sub LlenaVehiculos()
        Dim db As New ClsBitacoraEventos
        ComboVehiculo.DataSource = db.VehiculosRep
        ComboVehiculo.ValueMember = "Nº"
        ComboVehiculo.DisplayMember = "DESCRIPCIÓN"
    End Sub

    Sub Llena()
        Dim db As New ClsBitacoraEventos
        Try
            If Genera = "U" Then
                DataDatos.DataSource = db.VMuestraViajes(Desde.Value, Hasta.Value, _Inicio.lblUsuario.Text)
            End If
            If Genera = "T" Then
                DataDatos.DataSource = db.VMuestraTodosViajesCompleto(Desde.Value, Hasta.Value)
            End If
        Catch ex As Exception
        End Try
    End Sub

End Class