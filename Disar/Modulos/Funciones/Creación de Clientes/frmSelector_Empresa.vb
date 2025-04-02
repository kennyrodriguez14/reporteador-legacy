Public Class frmSelector_Empresa

    Public Empresa As String

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Empresa = ComboBox1.Text
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub frmSelector_Empresa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ComboBox1.Items.Clear()
        If _Inicio.lbl_usuario_tipo.Text = "Logistica" Then
            ComboBox1.Items.Add("OPL")
        Else
            ComboBox1.Items.Add("SAN RAFAEL")
            ComboBox1.Items.Add("DIMOSA")
            ComboBox1.Items.Add("OPL")
        End If
        ComboBox1.SelectedIndex = 0
        ComboBox1.Focus()
    End Sub
 
   
End Class