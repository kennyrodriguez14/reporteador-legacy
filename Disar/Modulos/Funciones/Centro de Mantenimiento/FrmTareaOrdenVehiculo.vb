Imports Disar.data

Public Class FrmTareaOrdenVehiculo

    Public Orden As Integer
 
    Private Sub Guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Guardar.Click

        Dim db As New ClsOrdenTrabajoVehicular
        Dim s = db.NuevoEvento(ComboBox1.Text, ComboBox1.SelectedValue, Orden)
        MsgBox(s)
        If s = "Se ha guardado el registro con éxito" Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If
        
    End Sub

    Private Sub FrmTareaOrdenVehiculo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim db As New ClsOrdenTrabajoVehicular
        ComboBox1.DataSource = db.TareasOrdenes
        ComboBox1.ValueMember = "ID"
        ComboBox1.DisplayMember = "Descr"
    End Sub

End Class