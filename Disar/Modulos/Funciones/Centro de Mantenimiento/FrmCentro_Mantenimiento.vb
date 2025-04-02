Imports Disar.data
Imports System.IO

Public Class FrmCentro_Mantenimiento

    Dim MuestraPendientes As Boolean
    Dim Pendientes As String
    Dim style As Microsoft.Office.Interop.Excel.Style

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFiltra.Click
        Filtra()
        FormatoGrid()
    End Sub

    Sub Llena()
        Dim db As New ClsBitacoraEventos
        CmbCusuca.DataSource = db.TodosVehiculosRep
        CmbCusuca.ValueMember = "Nº"
        CmbCusuca.DisplayMember = "DESCRIPCIÓN"
    End Sub

    Sub LlenaSolicitudes()

        Dim db As New ClsBitacoraEventos
        Dim dt As New DataTable
        Try
            dt.Rows.Clear()
        Catch ex As Exception
        End Try
        dt = db.SMuestraSolicitudesNoVehiculares

        If dt.Rows.Count > 0 Then
            BtnSolicitudes.Image = My.Resources.Alert_32__1_
            BtnSolicitudes.Text = "Otras Solicitudes (" & dt.Rows.Count & ")"
        Else
            BtnSolicitudes.Image = My.Resources.Archivos
        End If

    End Sub

    Sub Filtra()

        Try
            DataDatos.Columns.Clear()
        Catch ex As Exception
        End Try
        Try
            DataDatos.Rows.Clear()
        Catch ex As Exception
        End Try

        Dim Columna1 As New DataGridViewImageColumn
        Columna1.Name = "ColImagen"
        Columna1.HeaderText = ""

        Dim Columna2 As New DataGridViewTextBoxColumn
        Columna2.Name = "ColN"
        Columna2.HeaderText = "Nº"

        Dim Columna3 As New DataGridViewTextBoxColumn
        Columna3.Name = "ColDesc"
        Columna3.HeaderText = "DESCRIPCIÓN"

        Dim Columna4 As New DataGridViewTextBoxColumn
        Columna4.Name = "ColEstado"
        Columna4.HeaderText = "ESTADO"

        Dim Columna5 As New DataGridViewTextBoxColumn
        Columna5.Name = "ColPlaca"
        Columna5.HeaderText = "PLACA"

        Dim Columna6 As New DataGridViewTextBoxColumn
        Columna6.Name = "ColMarca"
        Columna6.HeaderText = "MARCA"

        Dim Columna7 As New DataGridViewTextBoxColumn
        Columna7.Name = "ColModelo"
        Columna7.HeaderText = "MODELO"

        Dim Columna8 As New DataGridViewTextBoxColumn
        Columna8.Name = "ColSucursal"
        Columna8.HeaderText = "SUCURSAL"

        Dim Columna9 As New DataGridViewTextBoxColumn
        Columna9.Name = "ColDispM"
        Columna9.HeaderText = "DISPONIBILIDAD MECÁNICA"

        Dim Columna10 As New DataGridViewTextBoxColumn
        Columna10.Name = "ColDispD"
        Columna10.HeaderText = "DISPONIBILIDAD DISTRIBUCIÓN"

        Dim Columna11 As New DataGridViewTextBoxColumn
        Columna11.Name = "ColObs"
        Columna11.HeaderText = "OBSERVACIÓN"

        Dim Columna12 As New DataGridViewTextBoxColumn
        Columna12.Name = "EstadoColumna"
        Columna12.HeaderText = "EstadoC"
        Columna12.Visible = False

        Dim Columna13 As New DataGridViewTextBoxColumn
        Columna13.Name = "ColVehiculoAnexo"
        Columna13.HeaderText = "Vehiculo"
        Columna13.Visible = False

        Dim Columna14 As New DataGridViewTextBoxColumn
        Columna14.Name = "ColAB"
        Columna14.HeaderText = "AB"
        Columna14.Visible = False

        Dim Columna15 As New DataGridViewTextBoxColumn
        Columna15.Name = "ColKilometraje"
        Columna15.HeaderText = "ULTIMO KILOMETRAJE"

        Dim db As New ClsBitacoraEventos
        Dim dtVehiculos As New DataTable

        If CmbCusuca.Text = " TODOS" Then
            If RadioTodos.Checked = True Then
                dtVehiculos.Rows.Clear()
                dtVehiculos = db.VehiculosRep
            End If
            If RadioActivos.Checked = True Then
                dtVehiculos.Rows.Clear()
                dtVehiculos = db.VehiculosActivos
            End If
            If RadioMecanica.Checked = True Then
                dtVehiculos.Rows.Clear()
                dtVehiculos = db.VehiculosDispMecanica
            End If
            If RadioDistribucion.Checked = True Then
                dtVehiculos.Rows.Clear()
                dtVehiculos = db.VehiculosDispDistrib
            End If
        Else
            dtVehiculos.Rows.Clear()
            RadioTodos.Checked = True
            dtVehiculos = db.BuscaVehiculosRep(CmbCusuca.SelectedValue)
        End If

        DataDatos.Columns.Add(Columna1)
        DataDatos.Columns.Add(Columna2)
        DataDatos.Columns.Add(Columna3)
        DataDatos.Columns.Add(Columna4)
        DataDatos.Columns.Add(Columna5)
        DataDatos.Columns.Add(Columna6)
        DataDatos.Columns.Add(Columna7)
        DataDatos.Columns.Add(Columna8)
        DataDatos.Columns.Add(Columna9)
        DataDatos.Columns.Add(Columna10)
        DataDatos.Columns.Add(Columna11)
        DataDatos.Columns.Add(Columna12)
        DataDatos.Columns.Add(Columna13)
        DataDatos.Columns.Add(Columna14)
        DataDatos.Columns.Add(Columna15)

        DataDatos.DefaultCellStyle.WrapMode = DataGridViewTriState.True

        MuestraPendientes = False
        Pendientes = ""
        For i As Integer = 0 To dtVehiculos.Rows.Count - 1
            DataDatos.Rows.Add(My.Resources.Badge_plus_32, dtVehiculos(i)(0), dtVehiculos(i)(1), dtVehiculos(i)(2), dtVehiculos(i)(3), dtVehiculos(i)(4), dtVehiculos(i)(5), dtVehiculos(i)(6), dtVehiculos(i)(7), dtVehiculos(i)(8), dtVehiculos(i)(9), "Cerrado", "", "")
            Dim dKilometraje As New DataTable
            dKilometraje.Rows.Clear()
            dKilometraje = db.NCARGAKILOMETRAJE(DataDatos.Rows(DataDatos.RowCount - 1).Cells(1).Value)

            Dim APX As Integer = 0
            Try
                APX = dKilometraje(0)(1)
                DataDatos.Rows(DataDatos.RowCount - 1).Cells("ColKilometraje").Value = FormatNumber(APX)
            Catch ex As Exception
            End Try

            Dim dt2 As New DataTable
            dt2.Rows.Clear()
            Dim dt3 As New DataTable
            dt3.Rows.Clear()

            dt2 = db.FiltraEventos(dtVehiculos(i)(0))
            dt3 = db.SMuestraSolicitudesVehiculo(dtVehiculos(i)(0), "Pendiente")

            If dt2.Rows.Count > 0 Or dt3.Rows.Count > 0 Then
                DataDatos.Rows(DataDatos.RowCount - 1).Cells("ColAB").Value = 1
            Else
                DataDatos.Rows(DataDatos.RowCount - 1).Cells("ColAB").Value = 0
            End If

            If CheckTareas.CheckState = CheckState.Checked Then
                For z As Integer = 0 To dt2.Rows.Count - 1
                    Try

                        If Not IsDBNull(dt2(z)(3)) Then
                            DataDatos.Rows.Add(My.Resources.BK, "", dt2(z)(2), "Fecha: " & vbNewLine & dt2(z)(3), "Tiempo: " & vbNewLine & dt2(z)(7), "Estado:" & vbNewLine & dt2(z)(6), "", "", "", "", "", "", dt2(z)(1), dt2(z)(0))
                        Else
                            DataDatos.Rows.Add(My.Resources.BK, "", dt2(z)(2), "Fecha: " & vbNewLine & "Por Kilometraje", "Tiempo: " & vbNewLine & dt2(z)(7), "Estado:" & vbNewLine & dt2(z)(6), "", "", "", "", "", "", dt2(z)(1), dt2(z)(0), "KM requerido" & vbNewLine & dt2(z)(8))
                        End If

                        DataDatos.Rows(DataDatos.RowCount - 1).Visible = False

                        If Not IsDBNull(dt2(z)(3)) Then
                            If Convert.ToDateTime(dt2(z)(3)) <= Today Then
                                Pendientes = Pendientes + "Vehículo " & dt2(z)(1) & " - Pendiente: " & dt2(z)(2) & vbNewLine
                                If Convert.ToDateTime(dt2(z)(3)) = Today Then
                                    DataDatos.Rows(DataDatos.RowCount - 1).DefaultCellStyle.BackColor = Color.Khaki
                                Else
                                    DataDatos.Rows(DataDatos.RowCount - 1).DefaultCellStyle.BackColor = Color.IndianRed
                                    'DataDatos.Rows(DataDatos.RowCount - 1).DefaultCellStyle.ForeColor = Color.White
                                End If
                                MuestraPendientes = True
                            End If
                        End If

                        If IsDBNull(dt2(z)(3)) Then
                            'MsgBox((Val(dt2(z)(8)) - 100) & " " & DataDatos.Rows(DataDatos.RowCount - 2).Cells("ColKilometraje").Value)
                            If Val(dt2(z)(8)) >= (DataDatos.Rows(DataDatos.RowCount - 2).Cells("ColKilometraje").Value) Then
                                Pendientes = Pendientes + "Vehículo " & dt2(z)(1) & " - Pendiente: " & dt2(z)(2) & vbNewLine
                                'MsgBox(Val(dt2(z)(8)) & " " & (DataDatos.Rows(DataDatos.RowCount - 2).Cells("ColKilometraje").Value) + 100)
                                If Val(dt2(z)(8)) <= (DataDatos.Rows(DataDatos.RowCount - 2).Cells("ColKilometraje").Value) + 100 Then
                                    DataDatos.Rows(DataDatos.RowCount - 1).DefaultCellStyle.BackColor = Color.Khaki
                                End If
                                MuestraPendientes = True
                            End If
                            If Val(dt2(z)(8)) <= DataDatos.Rows(DataDatos.RowCount - 2).Cells("ColKilometraje").Value Then
                                Pendientes = Pendientes + "Vehículo " & dt2(z)(1) & " - Pendiente: " & dt2(z)(2) & vbNewLine
                                DataDatos.Rows(DataDatos.RowCount - 1).DefaultCellStyle.BackColor = Color.IndianRed
                                'DataDatos.Rows(DataDatos.RowCount - 1).DefaultCellStyle.ForeColor = Color.White
                                MuestraPendientes = True
                            End If
                        End If


                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                Next
            Else
                DataDatos.Rows(DataDatos.RowCount - 1).Cells("ColAB").Value = 0
            End If
            For x As Integer = 0 To dt3.Rows.Count - 1
                Try
                    DataDatos.Rows.Add(My.Resources.BK, "", dt3(x)(1), dt3(x)(3), dt3(x)(4), dt3(x)(5), dt3(x)(6), "", "", "", "", "Solicitud", dt3(x)(1), dt3(x)(0))
                    DataDatos.Rows(DataDatos.RowCount - 1).Visible = False
                Catch ex As Exception
                End Try
            Next
        Next

    End Sub
     
    Sub FormatoGrid()
        With Me.DataDatos
            .BorderStyle = BorderStyle.None
            .CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
            .RowHeadersBorderStyle = _
                DataGridViewHeaderBorderStyle.Single
            .ColumnHeadersBorderStyle = _
                DataGridViewHeaderBorderStyle.Single
            '.Columns(6).DividerWidth = 3
            '.Columns(6).ce()
        End With
        For Each column As DataGridViewColumn In DataDatos.Columns
            column.SortMode = DataGridViewColumnSortMode.NotSortable
        Next
        For Each row As DataGridViewRow In DataDatos.Rows
            If row.Cells(12).Value = "" Then
                row.DefaultCellStyle.BackColor = Color.WhiteSmoke
            End If
            If row.Cells("ColAB").Value = "0" Then
                row.Cells(0).Value = My.Resources.WS
            Else
                If row.Cells(12).Value = "" Then
                    row.DefaultCellStyle.BackColor = Color.Khaki
                End If
            End If
        Next

        If MuestraPendientes = True Then
            MsgBox(Pendientes, MsgBoxStyle.Information, "Eventos pendientes al día de hoy")
        End If
    End Sub

    Private Sub ToolTareas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolTareas.Click
        FrmNuevoEventoProgramado.ShowDialog()
    End Sub

    Private Sub FrmCentro_Mantenimiento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Llena()
        LlenaSolicitudes()
        RadioActivos.Checked = True
        Try
            Dim db As New ClsBitacoraEventos
            Dim dt As New DataTable
            dt.Rows.Clear()
            dt = db.SPENDIENTES("Pendiente")
            Dim Contador As Integer = dt(0)(0)
            LAviso.Text = "Usted tiene " & Contador & " solicitudes vehiculares por completar."
            If Contador > 0 Then
                LAviso.Visible = True
            Else
                LAviso.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DataReportes2_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataDatos.CellDoubleClick
        If DataDatos.CurrentRow.Cells("ColVehiculoAnexo").Value = "" Then
            Expandir_Contraer()
        Else
            If DataDatos.CurrentRow.Cells("colMarca").Value = "Estado:" & vbNewLine & "Pendiente" And DataDatos.CurrentRow.Cells("EstadoColumna").Value <> "Solicitud" Then
                Dim a = MsgBox("¿Desea cambiar el estado de esta tarea?", MsgBoxStyle.YesNo, "Cambio de Estado")
                If a = MsgBoxResult.Yes Then
                    FrmCambioEstado.ID = DataDatos.CurrentRow.Cells("ColAB").Value
                    FrmCambioEstado.ShowDialog()
                End If
            Else
                If DataDatos.CurrentRow.Cells("EstadoColumna").Value = "Solicitud" Then
                    FrmVistaSolicitudes.Num.Text = DataDatos.CurrentRow.Cells(13).Value
                    ActualizaImagen()
                    FrmVistaSolicitudes.ShowDialog()
                    'FrmVistaSolicitudes.BringToFront()
                End If
            End If

        End If

    End Sub

    Sub ActualizaImagen()
        Try
            Dim DB As New ClsBitacoraEventos
            Data_Imagenes.DataSource = DB.SMuestraImagen(DataDatos.CurrentRow.Cells(13).Value)

            Dim Foto As Byte() = CType(Data_Imagenes.CurrentRow.Cells(5).Value, Byte())
            Dim Memoria As New MemoryStream(Foto)
            FrmVistaSolicitudes.Imagen.Image = Image.FromStream(Memoria)
            If Not IsDBNull(Data_Imagenes.Rows(0).Cells(1).Value) Then
                FrmVistaSolicitudes.TextVehiculo.Text = Data_Imagenes.Rows(0).Cells(1).Value
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

    Sub Expandir_Contraer()
        Try

            If DataDatos.CurrentRow.Cells("ColVehiculoAnexo").Value = "" Then
                If DataDatos.CurrentRow.Cells("EstadoColumna").Value = "Abierto" Then
                    For Each row As DataGridViewRow In DataDatos.Rows
                        If Val(row.Cells("ColVehiculoAnexo").Value) = Val(DataDatos.CurrentRow.Cells(1).Value) Then
                            row.Visible = False
                            DataDatos.CurrentRow.Cells("EstadoColumna").Value = "Cerrado"
                            DataDatos.CurrentRow.Cells(0).Value = My.Resources.Badge_plus_32
                        End If
                    Next
                Else
                    For Each row As DataGridViewRow In DataDatos.Rows
                        If Val(row.Cells("ColVehiculoAnexo").Value) = Val(DataDatos.CurrentRow.Cells(1).Value) Then
                            row.Visible = True
                            DataDatos.CurrentRow.Cells("EstadoColumna").Value = "Abierto"
                            DataDatos.CurrentRow.Cells(0).Value = My.Resources.Bullet_Toggle_Minus_32
                        End If
                    Next
                End If
            End If

        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DataDatos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataDatos.CellClick
        If e.ColumnIndex = 0 Then
            Expandir_Contraer()
        End If
    End Sub

    Private Sub ToolStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStatus.Click
        If DataDatos.RowCount > 0 Then
            If DataDatos.CurrentRow.Cells("ColVehiculoAnexo").Value = "" Then
                If FrmCambioEstadoVehiculo.ShowDialog = Windows.Forms.DialogResult.OK Then
                    BtnFiltra.PerformClick()
                End If
            End If
        End If
    End Sub

    Private Sub ToolDetalles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolDetalles.Click
        If DataDatos.RowCount > 0 Then
            If DataDatos.CurrentRow.Cells("ColVehiculoAnexo").Value = "" Then
                FrmEstadoVehiculo.ShowDialog()
            End If
        End If
    End Sub

    Private Sub ToolImagenes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolImagenes.Click
        If DataDatos.RowCount > 0 Then
            If DataDatos.CurrentRow.Cells("ColVehiculoAnexo").Value = "" Then
                FrmCargaImagenes.Vehiculo.Text = DataDatos.CurrentRow.Cells(1).Value
                If FrmCargaImagenes.ShowDialog = Windows.Forms.DialogResult.OK Then
                    MsgBox("Imágenes guardadas exitosamente", MsgBoxStyle.Information, "Aviso")
                End If
            End If
        End If
    End Sub

    Private Sub ToolCosto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolCosto.Click
        FrmReporteGastos.ShowDialog()
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

            For c As Integer = 1 To DataDatos.Columns.Count - 1
                If DataDatos.Columns(c).Visible = True Then
                    wSheet.Cells(2, c + 1).value = DataDatos.Columns(c).HeaderText
                    wSheet.Cells(2, c + 1).Style = "Estilo"
                End If
            Next
            For r As Integer = 0 To DataDatos.RowCount - 1
                For c As Integer = 1 To DataDatos.Columns.Count - 1
                    If DataDatos.Columns(c).Visible = True Then
                        wSheet.Cells(r + 3, c + 1).value = DataDatos.Item(c, r).Value
                        wSheet.Cells(r + 3, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                        wSheet.Cells(r + 3, c + 1).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                        wSheet.Cells(r + 3, c + 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                        If DataDatos.Rows(r).Cells(1).Value = "" Then
                            wSheet.Cells(r + 3, 2).Value = "-"
                            wSheet.Cells(r + 3, c + 1).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Beige)
                            'wSheet.Cells(r + 3, c + 1).Interior.Color = System.Drawing.ColorTranslator.ToOle(DataDatos.Rows(r).DefaultCellStyle.BackColor)
                        End If
                    End If
                Next
            Next

            wSheet.Range("A1").EntireColumn.Delete()
            wSheet.Cells.Range("A1:J1").Merge()
            wSheet.Cells.Range("A1:J1").Borders.LineStyle = BorderStyle.FixedSingle
            wSheet.Cells.Range("A1:J1").Value = " Reporte de Vehículos "
            wSheet.Cells.Range("A1:J1").Style = "Estilo"

            wSheet.Columns.AutoFit()
            excel.Visible = True
            excel.Quit()
        End If
    End Sub

    Private Sub ToolPuntoReorden_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolPuntoReorden.Click
        FrmPuntoReordenVehiculos.ShowDialog()
    End Sub

    Private Sub ToolDispD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolDispD.Click
        Frm_DispD.Reporte.Text = "Disponibilidad Distribución"
        Frm_DispD.GroupBox2.Visible = True
        Frm_DispD.ShowDialog()
    End Sub

    Private Sub ToolDispM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolDispM.Click
        Frm_DispD.Reporte.Text = "Disponibilidad Mecánica"
        Frm_DispD.GroupBox2.Visible = False
        Frm_DispD.ShowDialog()
    End Sub

    Private Sub ToolTaller_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolTaller.Click
        FrmParosVehiculos.ShowDialog()
    End Sub

    Private Sub MantenimientoNoProgram_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MantenimientoNoProgram.Click
        If FrmMantenimientosImprevistos.Visible = True Then
            FrmMantenimientosImprevistos.BringToFront()
        Else
            FrmMantenimientosImprevistos.MdiParent = _Inicio
            FrmMantenimientosImprevistos.Show()
        End If
    End Sub

    Private Sub ToolVehiculos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolVehiculos.Click
        Try
            Frm_RegistroVehiculo.Genera = "T"
        Catch ex As Exception
        End Try
        If Frm_RegistroVehiculo.Visible = True Then
            Frm_RegistroVehiculo.BringToFront()
        Else
            Frm_RegistroVehiculo.MdiParent = _Inicio
            Frm_RegistroVehiculo.Show()
        End If
    End Sub

    Private Sub BtnSolicitudes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSolicitudes.Click
        Frm_OtrasSolicitudes.ShowDialog()
    End Sub

    Private Sub BtnOrdenes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOrdenes.Click
        FormOrdenesDeTrabajo.ShowDialog()
    End Sub
End Class