Imports Disar.data

Public Class FrmRegistroEvento

    Private Sub ComboCategoria_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboCategoria.SelectedIndexChanged
        If ComboCategoria.Text = " NUEVA CATEGORIA" Then
            TextOtraCategoria.Visible = True
        Else
            TextOtraCategoria.Visible = False
        End If
    End Sub

    Sub LlenaVehiculos()
        Dim db As New ClsBitacoraEventos
        Try
            ComboVehiculo.DataSource = db.Vehiculos()
            ComboVehiculo.DisplayMember = "VehiculoDescripcion"
            ComboVehiculo.ValueMember = "VehiculoID"
            ComboVehiculo.SelectedItem = Nothing
        Catch ex As Exception
        End Try
    End Sub

    Sub LlenaCategorias()
        Dim db As New ClsBitacoraEventos
        Try
            ComboCategoria.DataSource = db.Categorias()
            ComboCategoria.DisplayMember = "BECat_Desc"
            ComboCategoria.ValueMember = "BECat_ID"
            ComboCategoria.SelectedItem = Nothing
        Catch ex As Exception
        End Try

    End Sub
     
    Private Sub FrmRegistroEvento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LlenaVehiculos()
        LlenaCategorias()
        TextEvento.Text = ""
        TextOtraCategoria.Text = ""
    End Sub

    Private Sub BtnCompletarRemision_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCompletarRemision.Click

        If TextEvento.Text <> "" And ComboCategoria.Text <> "" And ComboVehiculo.Text <> "" Then
            Dim db As New ClsBitacoraEventos

            Try
                Dim s As String = db.NuevoEvento(_Inicio.lblUsuario.Text, ComboCategoria.Text, ComboCategoria.SelectedValue, TextOtraCategoria.Text, ComboVehiculo.SelectedValue, TextEvento.Text, DateTimePicker1.Value, TextHerraientas.Text, Val(TextCostoAnomalia.Text))
                MsgBox(s)
                FrmBitacoraEventos.BtnFiltrar.PerformClick()
                Me.Close()
            Catch ex As Exception
            End Try
        Else
            MsgBox("Complete todos los campos correspondientes para poder continuar", MsgBoxStyle.Critical, "Atención")
        End If

    End Sub

  
End Class