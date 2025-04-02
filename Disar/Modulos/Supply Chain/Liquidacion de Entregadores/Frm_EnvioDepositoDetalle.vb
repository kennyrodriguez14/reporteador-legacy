Imports Disar.data

Public Class Frm_EnvioDepositoDetalle

    Public Tipo As String

    Private Sub btnEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnviar.Click
        Dim db As New ClsEfectividad

        If Tipo = "SAN RAFAEL" Then
            Dim Cta As String = ""
            Dim Tip_Pol As String = ""
            'MsgBox(N_Almacen.Text)
            If TextTipo.Text = "Cobro" Then
                Cta = "110400100000000000004"
            Else
                If N_Almacen.Text = 2 Then
                    Cta = "110100200000000000004"
                ElseIf N_Almacen.Text = 1 Then
                    Cta = "110100500000000000004"
                ElseIf N_Almacen.Text = 3 Then
                    Cta = "110100300000000000004"
                ElseIf N_Almacen.Text = 4 Then
                    Cta = "110100700000000000004"
                End If
            End If

            If N_Almacen.Text = 2 Then
                Tip_Pol = "Ig"
            ElseIf N_Almacen.Text = 1 Then
                Tip_Pol = "Yv"
            ElseIf N_Almacen.Text = 3 Then
                Tip_Pol = "Jc"
            ElseIf N_Almacen.Text = 4 Then
                Tip_Pol = "TI"
            End If

            Dim dt_contabilizar As New DataTable
            dt_contabilizar.Columns.Add("CUENTA")
            dt_contabilizar.Columns.Add("VALOR")
            dt_contabilizar.Columns.Add("TIPO")
            Dim fila As DataRow
            fila = dt_contabilizar.NewRow
            fila("CUENTA") = Cta
            fila("VALOR") = TextTotalAutorizado.Text
            fila("TIPO") = "H"
            dt_contabilizar.Rows.Add(fila)

            'Cuenta Banco
            fila = dt_contabilizar.NewRow
            fila("CUENTA") = "110200700000000000004"
            fila("VALOR") = TextTotalAutorizado.Text
            fila("TIPO") = "D"
            dt_contabilizar.Rows.Add(fila)

            Dim s As String = ""

            s = db.InsertaDepositoBanco(TextLiquidacion.Text, TextTotalAutorizado.Text, TextEntregadorNombre.Text, TextDeposito.Text, _Inicio.lblUsuario.Text, TextFecha.Text, Convert.ToDateTime(TextFecha.Text).Month, Convert.ToDateTime(TextFecha.Text).Year, Tip_Pol, TextTipo.Text, "", TextRuta.Text, dt_contabilizar)
            If s = "correcto" Then
                MsgBox("Se ha enviado el depósito exitosamente", MsgBoxStyle.Information)
                EnvioDepositos.BtnBuscar.PerformClick()
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                MsgBox(s)
            End If
        End If

    End Sub

End Class