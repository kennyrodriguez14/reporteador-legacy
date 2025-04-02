Imports Disar.data

Public Class FrmCambioEstadoVehiculo

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        Dim Estado As String
        Dim Mecanica As String
        Dim Distribucion As String

        If CheckActivo.CheckState = CheckState.Checked Then
            Estado = "Activo"
        Else
            Estado = "Inactivo"
        End If
        If CheckMecanica.CheckState = CheckState.Checked Then
            Mecanica = "Si"
        Else
            Mecanica = "No"
        End If
        If CheckDistrib.CheckState = CheckState.Checked Then
            Distribucion = "Si"
        Else
            Distribucion = "No"
        End If

        Dim db As New ClsBitacoraEventos
        Dim S = db.ActualizaVehiculo(ID.Text, Estado, Mecanica, Distribucion, TextObs.Text)
        If S = "S" Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If
    End Sub

    Private Sub FrmCambioEstadoVehiculo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ID.Text = FrmCentro_Mantenimiento.DataDatos.CurrentRow.Cells(1).Value
        Nombre.Text = FrmCentro_Mantenimiento.DataDatos.CurrentRow.Cells(2).Value
        Try
            If FrmCentro_Mantenimiento.DataDatos.CurrentRow.Cells(3).Value = "Activo" Then
                CheckActivo.CheckState = CheckState.Checked
            Else
                CheckActivo.CheckState = CheckState.Unchecked
            End If
            If FrmCentro_Mantenimiento.DataDatos.CurrentRow.Cells(8).Value = "Si" Then
                CheckMecanica.CheckState = CheckState.Checked
            Else
                CheckMecanica.CheckState = CheckState.Unchecked
            End If
            If FrmCentro_Mantenimiento.DataDatos.CurrentRow.Cells(9).Value = "Si" Then
                CheckDistrib.CheckState = CheckState.Checked
            Else
                CheckDistrib.CheckState = CheckState.Unchecked
            End If
            If Not IsDBNull(FrmCentro_Mantenimiento.DataDatos.CurrentRow.Cells(10).Value) Then
                TextObs.Text = FrmCentro_Mantenimiento.DataDatos.CurrentRow.Cells(10).Value
            Else
                TextObs.Text = ""
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FrmCambioEstadoVehiculo_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        FrmCentro_Mantenimiento.BringToFront()
        Me.Dispose()
    End Sub

End Class