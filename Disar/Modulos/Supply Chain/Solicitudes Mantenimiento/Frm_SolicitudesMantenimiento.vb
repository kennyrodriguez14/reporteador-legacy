Imports Disar.data
Imports System.IO

Public Class Frm_SolicitudesMantenimiento

    Dim style As Microsoft.Office.Interop.Excel.Style

    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        FrmNuevaSolicitudMecanica.ShowDialog()
    End Sub

    Private Sub BtnFiltra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFiltra.Click
        Try
            Dim conexion_bita As New cls_bitacora_reporteador
            conexion_bita.RegistraBitacora(Now, _Inicio.lblUsuario.Text, "Generó reporte de solicitudes de mantenimiento", "Supply Chain", _
                                      "Fecha: " & DateTime.Now)
        Catch ex As Exception
        End Try
        Dim db As New ClsBitacoraEventos
        Try
            DataDatos.DataSource = db.SMuestraSolicitudes(DtpInicio.Value, DtpTermina.Value, _Inicio.lblUsuario.Text)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExportar.Click
        If DataDatos.RowCount > 0 Then
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()

            style = wSheet.Application.ActiveWorkbook.Styles.Add("Estilo")
            style.Font.Bold = True
            style.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.SteelBlue)
            style.Font.Size = 11
            style.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            wSheet.Cells.Range("A1:G1").Merge()
            wSheet.Cells.Range("A1:G1").Borders.LineStyle = BorderStyle.FixedSingle
            wSheet.Cells.Range("A1:G1").Value = " Reporte de Solicitudes de Mantenimiento Vehicular " & FrmCentro_Mantenimiento.DataDatos.CurrentRow.Cells("ColN").Value
            wSheet.Cells.Range("A1:G1").Style = "Estilo"

            For c As Integer = 0 To DataDatos.Columns.Count - 1
                wSheet.Cells(2, c + 1).value = DataDatos.Columns(c).HeaderText
                wSheet.Cells(2, c + 1).Style = "Estilo"
            Next

            For r As Integer = 0 To DataDatos.RowCount - 1
                For c As Integer = 0 To DataDatos.Columns.Count - 1
                    wSheet.Cells(r + 3, c + 1).value = DataDatos.Item(c, r).Value
                    wSheet.Cells(r + 3, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    wSheet.Cells(r + 3, c + 1).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                    wSheet.Cells(r + 3, c + 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                Next
            Next

            wSheet.Columns.AutoFit()
            excel.Visible = True
            excel.Quit()
        End If
    End Sub

    Private Sub DataDatos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataDatos.CellDoubleClick
        BtnVerificar.PerformClick()
    End Sub

    Private Sub BtnVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVer.Click
        Try
            FrmVistaSolicitudes.Num.Text = DataDatos.CurrentRow.Cells(0).Value
            ActualizaImagen()
            FrmVistaSolicitudes.ShowDialog()
        Catch ex As Exception
        End Try

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
                FrmVistaSolicitudes.BtnCompletar.Enabled = False
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
 
    Private Sub BtnVerificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVerificar.Click
        If DataDatos.RowCount > 0 Then
            If DataDatos.CurrentRow.Cells("Estado").Value = "Completa" Then
                Dim S = MsgBox("¿Está seguro que desea marcar como verificada esta tarea?", MsgBoxStyle.YesNo, "Confirmación de Cambio de estado")
                If S = MsgBoxResult.Yes Then
                    Dim Fecha As Date
                    Dim dt As New DataTable
                    Try
                        dt.Rows.Clear()
                    Catch ex As Exception
                    End Try

                    Dim da As New ClsRegistroAgro
                    Dim db As New ClsBitacoraEventos

                    dt = da.get_Fecha
                    Fecha = dt(0)(0)

                    Dim Ax = db.SActualizaEv("Verificada", DataDatos.CurrentRow.Cells(0).Value, Fecha, Fecha)
                    If Ax = "S" Then
                        MsgBox("Se ha cambiado el estado de la tarea a 'Verificada'", MsgBoxStyle.Information, "Cambio de estado")
                        BtnFiltra.PerformClick()
                    End If
                End If
            Else
                MsgBox("No se puede verificar una tarea que aún no se marca como completa.", MsgBoxStyle.Critical, "Aviso")
            End If
        End If

    End Sub

    Private Sub Frm_SolicitudesMantenimiento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim db As New ClsBitacoraEventos
            Dim dt As New DataTable
            dt.Rows.Clear()
            dt = db.SPENDIENTES("Completa")
            Dim Contador As Integer = dt(0)(0)
            LAviso.Text = "Usted tiene " & Contador & " solicitudes por verificar."
            If Contador > 0 Then
                LAviso.Visible = True
            Else
                LAviso.Visible = False
            End If
            BtnFiltra.PerformClick()
        Catch ex As Exception
        End Try
    End Sub
End Class