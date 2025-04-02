Imports System.Data
Imports Disar.data
Imports System.IO

Public Class FrmCargaImagenes

    Dim A As Integer
    Dim NumeroDocumento As Integer = 0
    Dim NumeroTotalDocumento As Integer = 0

    Dim TotalFilas As Integer
    Dim FilaActual As Integer

    Dim DataImagenes As DataView
    Public VistaDesde As String
    Private imgOriginal As Image

    Private Sub btnBuscaFotografías_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscaFotografías.Click
        GroupImagenes.Visible = False
        PictureFotos.Image = Nothing
        Dim Resultado As New DialogResult()
        Resultado = Dialog.ShowDialog
        A = 0
        Dim Resu As String

        While A = 0
            For Each Resu In Dialog.FileNames
                Dim loadedImage As Image = Image.FromFile(Resu)
                PictureFotos.Image = loadedImage

                Dim esperaTmp As Long = My.Computer.Clock.TickCount + (1 * 1000)

                While esperaTmp > My.Computer.Clock.TickCount
                    System.Windows.Forms.Application.DoEvents()
                End While
            Next Resu
        End While

    End Sub

    Private Sub PictureFotos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureFotos.Click
        A = 1
    End Sub

    Private Sub FrmCargaImagenes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
         
        GroupImagenes.Visible = True
        GroupImagenes.BringToFront()
        Try
            ActualizarImagenes()
            NumeroDocumento = 1
            NumeroTotalDocumento = Data_Imagenes.RowCount
            Contador.Text = NumeroDocumento & " de " & NumeroTotalDocumento
            If Data_Imagenes.RowCount > 0 Then
                Label1.Visible = False
                Dim Foto As Byte() = CType(Data_Imagenes.CurrentRow.Cells(3).Value, Byte())
                Dim Memoria As New MemoryStream(Foto)
                Imagen.Image = Image.FromStream(Memoria)
                imgOriginal = Imagen.Image
                TextDecc.Text = Data_Imagenes.CurrentRow.Cells(2).Value
            Else
                Label1.Visible = True
            End If
        Catch ex As Exception
        End Try
   
    End Sub

    Sub ActualizarImagenes()
        Dim db As New ClsBitacoraEventos
        Data_Imagenes.DataSource = db.MuestraGaleria(Vehiculo.Text)
    End Sub

    Private Sub VisualizarImagen()
        Dim Foto As Byte() = CType(Data_Imagenes.CurrentRow.Cells(3).Value, Byte())
        Dim Memoria As New MemoryStream(Foto)
        Imagen.Image = Image.FromStream(Memoria)
        imgOriginal = Imagen.Image
        TextDecc.Text = Data_Imagenes.CurrentRow.Cells(2).Value
    End Sub

    Private Sub Btn_Anterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Anterior.Click
        If Data_Imagenes.RowCount > 0 Then
            If TextDecc.Text <> "" Then
                Data_Imagenes.CurrentRow.Cells(2).Value = TextDecc.Text
                Try
                    Dim db As New ClsBitacoraEventos
                    db.ActualizaDescripcionGaleria(TextDecc.Text, Data_Imagenes.CurrentRow.Cells(0).Value)
                Catch ex As Exception
                End Try
            End If
            If NumeroDocumento > 1 Then
                NumeroDocumento -= 1
            Else
                NumeroDocumento = NumeroTotalDocumento
            End If

            TotalFilas = Data_Imagenes.RowCount
            FilaActual = Data_Imagenes.CurrentRow.Index.ToString
            If FilaActual = 0 Then
                Data_Imagenes.CurrentCell = Data_Imagenes.Rows(TotalFilas - 1).Cells(1)
            Else
                Data_Imagenes.CurrentCell = Data_Imagenes.Rows(FilaActual - 1).Cells(1)
            End If
            VisualizarImagen()
            Contador.Text = NumeroDocumento & " de " & NumeroTotalDocumento
        End If
    End Sub

    Private Sub Btn_Siguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Siguiente.Click
        If Data_Imagenes.RowCount > 0 Then

            If TextDecc.Text <> "" Then
                Data_Imagenes.CurrentRow.Cells(2).Value = TextDecc.Text
                Try
                    Dim db As New ClsBitacoraEventos
                    db.ActualizaDescripcionGaleria(TextDecc.Text, Data_Imagenes.CurrentRow.Cells(0).Value)
                Catch ex As Exception
                End Try
            End If

            If NumeroDocumento < NumeroTotalDocumento Then
                NumeroDocumento += 1
            Else
                NumeroDocumento = 1
            End If

            TotalFilas = Data_Imagenes.RowCount
            FilaActual = Data_Imagenes.CurrentRow.Index.ToString
            If FilaActual < TotalFilas - 1 Then
                Data_Imagenes.CurrentCell = Data_Imagenes.Rows(FilaActual + 1).Cells(1)
            Else
                Data_Imagenes.CurrentCell = Data_Imagenes.Rows(0).Cells(1)
            End If
            VisualizarImagen()
            Contador.Text = NumeroDocumento & " de " & NumeroTotalDocumento
        End If

    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        A = 1
        Dim db As New ClsBitacoraEventos
        Dim s As String

        If (PictureFotos.Image Is Nothing) Then
            MsgBox("Al menos una imagen es obligatoria, seleccione las imágenes y luego haga clic sobre el cuadro color verde para verificar sus imágenes.", MsgBoxStyle.Critical, "Error")
        Else
            Dim Resu As String
            Dim dtFotosGaleria As New DataTable
            dtFotosGaleria.Columns.Add("Memoria")
            dtFotosGaleria.Columns.Add("Descripcion")
            dtFotosGaleria.Columns("Memoria").DataType = System.Type.GetType("System.Byte[]")
            Dim Ax As Integer = 0
            For Each Resu In Dialog.FileNames
                Ax += 1
                Dim loadedImage As Image = Image.FromFile(Resu)
                PictureFotos.Image = loadedImage
                Dim Memoria As New System.IO.MemoryStream
                PictureFotos.Image.Save(Memoria, System.Drawing.Imaging.ImageFormat.Jpeg)

                dtFotosGaleria.Rows.Add(Memoria.GetBuffer, "Imagen " & Ax)

                Dim esperaTmp As Long = My.Computer.Clock.TickCount + (0.5 * 1000)
                While esperaTmp > My.Computer.Clock.TickCount
                    System.Windows.Forms.Application.DoEvents()
                End While
            Next Resu
            Try
                s = db.NuevasImagenes(Vehiculo.Text, "1", dtFotosGaleria, _Inicio.lblUsuario.Text)
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Imagen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Imagen.DoubleClick
        If Data_Imagenes.RowCount > 0 Then
            Try
                Dim A = MsgBox("¿Desea eliminar la imagen desplegada?", MsgBoxStyle.YesNo, "Vehículo " & Vehiculo.Text)
                If A = MsgBoxResult.Ok Then
                    Dim db As New ClsBitacoraEventos
                    db.BorraImagen(Data_Imagenes.CurrentRow.Cells(0).Value)
                    ActualizarImagenes()
                    NumeroDocumento = 1
                    NumeroTotalDocumento = Data_Imagenes.RowCount
                    Contador.Text = NumeroDocumento & " de " & NumeroTotalDocumento
                    Btn_Siguiente.PerformClick()
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub FrmCargaImagenes_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        FrmCentro_Mantenimiento.BringToFront()
        Me.Dispose()
    End Sub

 
End Class