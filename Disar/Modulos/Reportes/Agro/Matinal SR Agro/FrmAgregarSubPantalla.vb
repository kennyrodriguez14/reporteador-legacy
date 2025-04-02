Imports Disar.data
Public Class FrmAgregarSubPantalla

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        Dim db As New ClsMatinalAgro
        Dim Mes = ComboMes.SelectedIndex + 1
        Dim s = db.NuevoSegmento(TextMedicion.Text, Pantalla.Text, Vendedor.Text, TextCantidad.Text, ComboBox1.Text, Mes, NumericUpDown1.Value)
        If s = "s" Then
            FrmPresupuestosAgroMatinal.ActualizaPresupuestos()
            Me.Close()
        Else
            MsgBox(s)
        End If
    End Sub

 
    Private Sub FrmAgregarSubPantalla_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboMes.SelectedIndex = Today.Month - 1
        Dim db As New ClsMatinalAgro
        TextMedicion.DataSource = db.CARGASEGMENTOS(Pantalla.Text)
        TextMedicion.ValueMember = "MEDICION"
        TextMedicion.DisplayMember = "MEDICION"
    End Sub
 
End Class