Imports Disar.data

Public Class FrmRechazaCheque

    Public Cheque As String
    Public ClienteClave As String
    Public Monto As Decimal

    Private Sub BtnRechazarPago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRechazarPago.Click
        Dim s As String
        Dim db As New ClsCheques
        Try
            s = db.RechazaCheque(Cheque, _Inicio.lblUsuario.Text, ComboBox1.Text, ComboBox1.SelectedValue, TextBox1.Text)
            If s = "SI" Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FrmRechazaCheque_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LCliente.Text = "Cliente: " & FrmChequesPrincipal.DataCheques.CurrentRow.Cells("Nombre Cliente").Value
        LMonto.Text = "Monto del cheque: " & FrmChequesPrincipal.DataCheques.CurrentRow.Cells("Monto").Value
        LCheque.Text = "Nº de Cheque: " & FrmChequesPrincipal.DataCheques.CurrentRow.Cells("Nº de Cheque").Value

        ClienteClave = FrmChequesPrincipal.DataCheques.CurrentRow.Cells("Clave Cliente").Value
        Monto = FrmChequesPrincipal.DataCheques.CurrentRow.Cells("Monto").Value
        Cheque = FrmChequesPrincipal.DataCheques.CurrentRow.Cells("Nº de Cheque").Value
        LlenaConcepto()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text = "OTRO CONCEPTO" Then
            TextBox1.Visible = True
        Else
            TextBox1.Visible = False
        End If
    End Sub

    Sub LlenaConcepto()
        Dim db As New ClsCheques
        Try
            ComboBox1.DataSource = db.Conceptos

            ComboBox1.ValueMember = "Concepto_ID"
            ComboBox1.DisplayMember = "Concepto_Nombre"
        Catch ex As Exception

        End Try
    End Sub

End Class