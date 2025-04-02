Imports Disar.data
Imports System.IO

Public Class Frm_OtrasSolicitudes

    Private Sub BtnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGenerar.Click
        Dim db As New ClsBitacoraEventos

        Try
            DataDatos.DataSource = db.SMuestraSolicitudesNoVehicularesRango(DInicio.Value, Final.Value)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DataDatos_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataDatos.CellDoubleClick
        FrmVistaSolicitudes.Num.Text = DataDatos.CurrentRow.Cells(0).Value
        ActualizaImagen()
        FrmVistaSolicitudes.ShowDialog()
    End Sub

    Sub ActualizaImagen()
        Try
            Dim DB As New ClsBitacoraEventos
            Data_Imagenes.DataSource = DB.SMuestraImagen(DataDatos.CurrentRow.Cells(0).Value)

            Dim Foto As Byte() = CType(Data_Imagenes.CurrentRow.Cells(5).Value, Byte())
            Dim Memoria As New MemoryStream(Foto)
            FrmVistaSolicitudes.Imagen.Image = Image.FromStream(Memoria)
            If Not IsDBNull(Data_Imagenes.Rows(0).Cells(1).Value) Then
                FrmVistaSolicitudes.TextVehiculo.Text = Data_Imagenes.Rows(0).Cells(1).Value
                If FrmVistaSolicitudes.TextVehiculo.Text = 1000 Then
                    FrmVistaSolicitudes.TextVehiculo.Visible = False
                End If
            End If
            If Not IsDBNull(Data_Imagenes.Rows(0).Cells(3).Value) Then
                FrmVistaSolicitudes.TextFecha.Text = Data_Imagenes.Rows(0).Cells(3).Value
            End If
            If Not IsDBNull(Data_Imagenes.Rows(0).Cells(4).Value) Then
                FrmVistaSolicitudes.TextDescripcion.Text = Data_Imagenes.Rows(0).Cells(4).Value
            End If
            If Not IsDBNull(Data_Imagenes.Rows(0).Cells(6).Value) Then
                FrmVistaSolicitudes.TextSolicitante.Text = Data_Imagenes.Rows(0).Cells(6).Value
            End If
            If Not IsDBNull(Data_Imagenes.Rows(0).Cells(7).Value) Then
                FrmVistaSolicitudes.TextEstado.Text = Data_Imagenes.Rows(0).Cells(7).Value
                If Data_Imagenes.Rows(0).Cells(7).Value = "Pendiente" Then
                    FrmVistaSolicitudes.BtnCompletar.Enabled = True
                Else
                    FrmVistaSolicitudes.BtnCompletar.Enabled = False
                End If
            End If
            If Not IsDBNull(Data_Imagenes.Rows(0).Cells(9).Value) Then
                FrmVistaSolicitudes.TextFechaRevision.Text = Data_Imagenes.Rows(0).Cells(9).Value
            End If
            If Not IsDBNull(Data_Imagenes.Rows(0).Cells(10).Value) Then
                FrmVistaSolicitudes.TextFechaConfirmacion.Text = Data_Imagenes.Rows(0).Cells(10).Value
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
 
End Class