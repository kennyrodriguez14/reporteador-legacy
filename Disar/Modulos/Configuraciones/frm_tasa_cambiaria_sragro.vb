Imports Disar.data

Public Class frm_tasa_cambiaria_sragro
    Dim conexion As New cls_descuentos_tacticos
    Private Sub btn_cambiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cambiar.Click
        Dim resultado As String = ""
        Try
            resultado = conexion.actualizar_tasa_sr_agro(txt_nueva_tasa.Text, Now, grd_presupuestos.CurrentRow.Cells(0).Value)

            If resultado = "correcto" Then
                cargar()

                Dim conexion As New cls_bitacora_reporteador
                conexion.RegistraBitacora(Now, _Inicio.lblUsuario.Text, "Cambio de Tasa Cambiaria SR Agro", "Importaciones", _
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
            grd_presupuestos.DataSource = conexion.lista_tasa_cambiaria_sragro
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub grd_presupuestos_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grd_presupuestos.CellMouseDoubleClick
        Try
            txt_nueva_tasa.Text = grd_presupuestos.CurrentRow.Cells(2).Value
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub frm_tasa_cambiaria_sragro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar()
    End Sub
End Class