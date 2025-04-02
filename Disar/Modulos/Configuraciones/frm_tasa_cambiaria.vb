Imports Disar.data

Public Class frm_tasa_cambiaria
    Dim conexion As New cls_descuentos_tacticos
    Private Sub btn_cambiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cambiar.Click
        Dim resultado As String = ""
        Try
            resultado = conexion.actualizar_tasa_disar(txt_nueva_tasa.Text, Now, grd_presupuestos.CurrentRow.Cells(0).Value)

            If resultado = "correcto" Then
                cargar()

                Dim conexion As New cls_bitacora_reporteador
                conexion.RegistraBitacora(Now, _Inicio.lblUsuario.Text, "Cambio de Tasa Cambiaria DISAR", "Importaciones", _
                                          "Precio Nuevo: " + txt_nueva_tasa.Text)
                txt_nueva_tasa.Text = ""
            Else
                MessageBox.Show(resultado)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        cargar()
    End Sub

    Sub cargar()
        Try
            grd_presupuestos.DataSource = conexion.lista_tasa_cambiaria_Disar()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub frm_tasa_cambiaria_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar()
    End Sub

    Private Sub grd_presupuestos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grd_presupuestos.CellContentClick
        Try
            txt_nueva_tasa.Text = grd_presupuestos.CurrentRow.Cells(2).Value
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class