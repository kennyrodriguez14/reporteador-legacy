Imports Disar.data
Imports System.IO

Public Class FrmEstadoVehiculo

    Private Sub FrmEstadoVehiculo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim conexion_bita As New cls_bitacora_reporteador
        conexion_bita.RegistraBitacora(Now, _Inicio.lblUsuario.Text, "Generó reporte de detalles de vehículo", "Centro de Mantenimiento", _
                                  "Fecha: " & DateTime.Now)
        CargaInfo()
    End Sub

    Sub CargaInfo()
        Dim ce As New ClsBitacoraEventos
        Dim dt As New DataTable
        dt = ce.InfoVehiculo(FrmCentro_Mantenimiento.DataDatos.CurrentRow.Cells("ColN").Value)

        If dt.Rows.Count > 0 Then

            If Not IsDBNull(dt(0)(0)) Then
                TextID.Text = dt(0)(0)
            Else
                TextID.Text = ""
            End If
            If Not IsDBNull(dt(0)(1)) Then
                TextDescripción.Text = dt(0)(1)
            Else
                TextDescripción.Text = ""
            End If
            If Not IsDBNull(dt(0)(2)) Then
                TextEstado.Text = dt(0)(2)
            Else
                TextEstado.Text = ""
            End If
            If Not IsDBNull(dt(0)(3)) Then
                TextPlaca.Text = dt(0)(3)
            Else
                TextPlaca.Text = ""
            End If
            If Not IsDBNull(dt(0)(4)) Then
                TextMarca.Text = dt(0)(4)
            Else
                TextMarca.Text = ""
            End If
            If Not IsDBNull(dt(0)(5)) Then
                TextModelo.Text = dt(0)(5)
            Else
                TextModelo.Text = ""
            End If
            If Not IsDBNull(dt(0)(6)) Then
                TextSucursal.Text = dt(0)(6)
            Else
                TextSucursal.Text = ""
            End If
            If Not IsDBNull(dt(0)(7)) Then
                TextDisponibilidadM.Text = dt(0)(7)
            Else
                TextDisponibilidadM.Text = ""
            End If
            If Not IsDBNull(dt(0)(8)) Then
                TextDisponibilidadD.Text = dt(0)(8)
            Else
                TextDisponibilidadD.Text = ""
            End If
            If Not IsDBNull(dt(0)(9)) Then
                TextDetalle.Text = dt(0)(9)
            Else
                TextDetalle.Text = ""
            End If
            If Not IsDBNull(dt(0)(10)) Then
                TextCapacidadLibras.Text = dt(0)(10)
            Else
                TextCapacidadLibras.Text = ""
            End If
            If Not IsDBNull(dt(0)(11)) Then
                TextMonto.Text = dt(0)(11)
            Else
                TextMonto.Text = ""
            End If
            If Not IsDBNull(dt(0)(12)) Then
                TextCapacidadMaxima.Text = dt(0)(12)
            Else
                TextCapacidadMaxima.Text = ""
            End If
            If Not IsDBNull(dt(0)(13)) Then
                TextCubicaje.Text = dt(0)(13)
            Else
                TextCubicaje.Text = ""
            End If
            If Not IsDBNull(dt(0)(14)) Then
                TextDepto.Text = dt(0)(14)
            Else
                TextDepto.Text = ""
            End If
            If Not IsDBNull(dt(0)(15)) Then
                NChasis.Text = dt(0)(15)
            Else
                NChasis.Text = ""
            End If
            If Not IsDBNull(dt(0)(16)) Then
                NMotor.Text = dt(0)(16)
            Else
                NMotor.Text = ""
            End If
            If Not IsDBNull(dt(0)(17)) Then
                NEncargado.Text = dt(0)(17)
            Else
                NEncargado.Text = ""
            End If
        End If
        Try
            ActualizarImagenes()
            If Data_Imagenes.RowCount > 0 Then
                VisualizarImagen()
            End If
        Catch ex As Exception

        End Try


    End Sub

    Sub ActualizarImagenes()
        Dim db As New ClsBitacoraEventos
        Data_Imagenes.DataSource = db.MuestraGaleria(FrmCentro_Mantenimiento.DataDatos.CurrentRow.Cells("ColN").Value)
    End Sub

    Private Sub VisualizarImagen()
        Dim Foto As Byte() = CType(Data_Imagenes.CurrentRow.Cells(3).Value, Byte())
        Dim Memoria As New MemoryStream(Foto)
        Imagen.Image = Image.FromStream(Memoria)
        Desc.Text = Data_Imagenes.CurrentRow.Cells(2).Value
    End Sub

    Private Sub FrmEstadoVehiculo_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub

    Private Sub Btn_HistorialCk(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnHistorial.Click
        FrmHistorialEventos.ShowDialog()
    End Sub

    Private Sub BtnCambios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCambios.Click
        Frm_CambioDeEncargado.LVehiculo.Text = TextID.Text
        Frm_CambioDeEncargado.TextChasis.Text = NChasis.Text
        Frm_CambioDeEncargado.TextEncargado.Text = NEncargado.Text
        Frm_CambioDeEncargado.TextSerie.Text = NMotor.Text
        Frm_CambioDeEncargado.ShowDialog()
    End Sub

End Class
