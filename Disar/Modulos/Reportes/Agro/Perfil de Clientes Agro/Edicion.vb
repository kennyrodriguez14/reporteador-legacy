Imports Disar.Data

Public Class Edicion
    Dim Prod As New ClsFunciones

    Private Sub Edicion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If Not IsDBNull(Clientes_Agro.DataClientes.CurrentRow.Cells(0).Value) Then
                TextClaveCliente.Text = Clientes_Agro.DataClientes.CurrentRow.Cells(0).Value
            End If
            If Not IsDBNull(Clientes_Agro.DataClientes.CurrentRow.Cells(1).Value) Then
                TextNombreCliente.Text = Clientes_Agro.DataClientes.CurrentRow.Cells(1).Value
            End If
            If Not IsDBNull(Clientes_Agro.DataClientes.CurrentRow.Cells(3).Value) Then
                TextUbicacion.Text = Clientes_Agro.DataClientes.CurrentRow.Cells(3).Value
            End If
            If Not IsDBNull(Clientes_Agro.DataClientes.CurrentRow.Cells(4).Value) Then
                TextIDRTN.Text = Clientes_Agro.DataClientes.CurrentRow.Cells(4).Value
            End If

            If Not IsDBNull(Clientes_Agro.DataClientes.CurrentRow.Cells(10).Value) Then
                TextCultivos.Text = Clientes_Agro.DataClientes.CurrentRow.Cells(10).Value
            End If
            If Not IsDBNull(Clientes_Agro.DataClientes.CurrentRow.Cells(11).Value) Then
                TextManzanas.Text = Clientes_Agro.DataClientes.CurrentRow.Cells(11).Value
            End If
            If Not IsDBNull(Clientes_Agro.DataClientes.CurrentRow.Cells(12).Value) Then
                TextTipoGranja.Text = Clientes_Agro.DataClientes.CurrentRow.Cells(12).Value
            End If
            If Not IsDBNull(Clientes_Agro.DataClientes.CurrentRow.Cells(13).Value) Then
                TextAnimales.Text = Clientes_Agro.DataClientes.CurrentRow.Cells(13).Value
            End If
            If Not IsDBNull(Clientes_Agro.DataClientes.CurrentRow.Cells(14).Value) Then
                TextTieneMascota.Text = Clientes_Agro.DataClientes.CurrentRow.Cells(14).Value
            End If
            If Not IsDBNull(Clientes_Agro.DataClientes.CurrentRow.Cells(15).Value) Then
                TextAgroservicio.Text = Clientes_Agro.DataClientes.CurrentRow.Cells(15).Value
            End If
            If Not IsDBNull(Clientes_Agro.DataClientes.CurrentRow.Cells(16).Value) Then
                TextPorque.Text = Clientes_Agro.DataClientes.CurrentRow.Cells(16).Value
            End If
            If Not IsDBNull(Clientes_Agro.DataClientes.CurrentRow.Cells(17).Value) Then
                TextMarcas.Text = Clientes_Agro.DataClientes.CurrentRow.Cells(17).Value
            End If

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub BtnGuarda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuarda.Click
        Try
            Prod.ModificaCampos(TextClaveCliente.Text.ToUpper, TextCultivos.Text.ToUpper, TextManzanas.Text.ToUpper, TextTipoGranja.Text.ToUpper, TextAnimales.Text.ToUpper, TextTieneMascota.Text, TextAgroservicio.Text.ToUpper, TextPorque.Text.ToUpper, TextMarcas.Text.ToUpper)
            Prod.InsertaBitacora("Modificación de Cliente", TextClaveCliente.Text.ToUpper, _Inicio.Status_Usuarios.Text)
            MsgBox("Registro guardado.", MsgBoxStyle.Information, "Aviso")
            Clientes_Agro.Actualizarclientes()
            For a As Integer = 0 To Clientes_Agro.DataClientes.RowCount - 1
                If Clientes_Agro.DataClientes.Rows(a).Cells(0).Value = TextClaveCliente.Text Then
                    Clientes_Agro.DataClientes.CurrentCell = Clientes_Agro.DataClientes(1, a)
                End If
            Next
            Me.Close()
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub

End Class