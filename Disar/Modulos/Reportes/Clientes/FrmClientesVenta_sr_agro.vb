Imports Disar.data
Imports System.IO

Public Class FrmClientesVenta_sr_agro

    Dim style As Microsoft.Office.Interop.Excel.Style

    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click

        'Dim conexion_bita As New cls_bitacora_reporteador
        'conexion_bita.RegistraBitacora(Now, _Inicio.lblUsuario.Text, "Generó reporte " & ComboBox1.Text & " " & ComboBox2.Text, "REPORTES", _
        '                          "Fecha: " & DateTime.Now)

        If ComboBox1.Text = "Venta Perdida y Venta Baja" Then
            Dim db As New ClsClientes_sr_agro

            Try
                DataDatos.Rows.Clear()
            Catch ex As Exception
            End Try

            DataDatos.Columns.Clear()
            DataDatos.DataSource = Nothing

            DataDatos.DataSource = db.VentaPerdidaVentas(Convert.ToDateTime("01-01-" & DateTimePicker1.Value.Year - 1), Convert.ToDateTime("31-12-" & DateTimePicker1.Value.Year - 1), "AÑO_NUEVO", "")

            Dim NumeroMes As Integer
            NumeroMes = DateTimePicker1.Value.Month
            DataDatos.Columns(DataDatos.ColumnCount - 1).HeaderText = DataDatos.Columns(DataDatos.ColumnCount - 1).HeaderText & " Promedio " & DateTimePicker2.Value.Year - 1
            For A As Integer = 1 To NumeroMes
                Dim Columna As New TabPage
                Columna.Text = MonthName(A).ToUpper & " " & DateTimePicker1.Value.Year
                Columna.Name = MonthName(A).ToUpper
                TabControl1.TabPages.Add(Columna)

                Dim DG As New DataGridView
                DG.Name = Columna.Name

                DG.Width = DataDatos.Width
                DG.Height = DataDatos.Height
                DG.Location = New Point(1, 1)
                DG.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells

                Columna.Controls.Add(DG)

                With DG.ColumnHeadersDefaultCellStyle
                    .BackColor = Color.Navy
                    .ForeColor = Color.White
                    .Font = New Font(DG.Font, FontStyle.Bold)
                End With

                DG.Dock = DockStyle.Fill

                'MsgBox(New DateTime(DateTimePicker1.Value.Year, A, DateTime.DaysInMonth(DateTimePicker1.Value.Year, A)))
                'For Each row As DataGridViewRow In DataDatos.Rows
                '    Try
                '        Dim dt As New DataTable
                Dim ds As New ClsClientes
                'DG.DataSource = ds.VentaPerdidaVentas(Convert.ToDateTime("01-" & A & "-" & DateTimePicker1.Value.Year), New DateTime(DateTimePicker1.Value.Year, A, DateTime.DaysInMonth(DateTimePicker1.Value.Year, A)), "NEW", 0, ComboVendedor.SelectedValue)
                '        Dim C As String = dt(0)(4).ToString
                '        row.Cells(DataDatos.ColumnCount - 1).Value = C
                '    Catch ex As Exception
                '    End Try
                'Next
            Next

            Try
                Dim Columna As New TabPage
                Columna.Text = "DETALLES"
                Columna.Name = "DIFERENCIA"
                TabControl1.TabPages.Add(Columna)

                Dim DG As New DataGridView
                DG.Name = Columna.Name & "DG"

                DG.Width = DataDatos.Width
                DG.Height = DataDatos.Height
                DG.Location = New Point(1, 1)
                Columna.Controls.Add(DG)

                With DG.ColumnHeadersDefaultCellStyle
                    .BackColor = Color.Navy
                    .ForeColor = Color.White
                    .Font = New Font(DG.Font, FontStyle.Bold)
                End With

                DG.Dock = DockStyle.Fill

                Dim ColumnaClave As New DataGridViewTextBoxColumn
                ColumnaClave.Name = "Clave"
                ColumnaClave.HeaderText = "Clave"
                Dim ColumnaNombre As New DataGridViewTextBoxColumn
                ColumnaNombre.Name = "NOMBRE"
                ColumnaNombre.HeaderText = "NOMBRE"
                Dim ColumnaVendedor As New DataGridViewTextBoxColumn
                ColumnaVendedor.Name = "VENDEDOR"
                ColumnaVendedor.HeaderText = "VENDEDOR"
                Dim ColumnaDIFERENCIA As New DataGridViewTextBoxColumn
                ColumnaDIFERENCIA.Name = "DIFERENCIA VENTAS"
                ColumnaDIFERENCIA.HeaderText = "DIFERENCIA VENTAS"
                Dim ColumnaDetalles As New DataGridViewTextBoxColumn
                ColumnaDetalles.Name = "DETALLE"
                ColumnaDetalles.HeaderText = "DETALLE"

                Try
                    DG.Columns.Clear()
                    DG.Columns.Add(ColumnaClave)
                    DG.Columns.Add(ColumnaNombre)
                    DG.Columns.Add(ColumnaVendedor)
                    DG.Columns.Add(ColumnaDIFERENCIA)
                    DG.Columns.Add(ColumnaDetalles)

                    Dim DIF As Decimal = 0
                    For Each DatosMes As DataGridView In TabControl1.TabPages(TabControl1.TabPages.Count - 2).Controls
                        For Each row As DataGridViewRow In DatosMes.Rows
                            DIF = Val(row.Cells(3).Value) - Val(DataDatos.Rows(row.Index).Cells(3).Value)

                            Dim Det As String = ""
                            If row.Cells(3).Value = 0 Then
                                Det = "Venta Perdida"
                            Else
                                If DIF = 0 Then
                                    Det = ""
                                ElseIf DIF > 0 Then
                                    Det = "Venta Alta"
                                Else
                                    Det = "Venta Baja"
                                End If
                            End If

                            DG.Rows.Add(row.Cells(0).Value, row.Cells(1).Value, row.Cells(2).Value, DIF, Det)
                        Next
                    Next
                Catch ex As Exception
                End Try
                DG.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
            Catch ex As Exception
            End Try


        ElseIf ComboBox1.Text = "Clientes Nuevos" Then
            If ComboBox2.Text = "Detalle Por Vendedor" Then
                Dim db As New ClsClientes_sr_agro
                Dim dtSup As New DataTable
                dtSup.Rows.Clear()
                Try
                    DataReportes2.Rows.Clear()
                    DataReportes2.Columns.Clear()
                Catch ex As Exception

                End Try
                Try
                    DataReportes2.DataSource = Nothing
                Catch ex As Exception

                End Try

                Dim Columna1 As New DataGridViewImageColumn
                Columna1.Name = "ColImagen"
                Columna1.HeaderText = ""
                Dim Columna2 As New DataGridViewTextBoxColumn
                Columna2.Name = "ColCodigo"
                Columna2.HeaderText = "Codigo"
                Dim Columna3 As New DataGridViewTextBoxColumn
                Columna3.Name = "ColNombre"
                Columna3.HeaderText = "Supervisor/Vendedor"
                Columna3.DividerWidth = 3
                Dim Columna4 As New DataGridViewTextBoxColumn
                Columna4.Name = "ColSupervisor"
                Columna4.HeaderText = "Supervisor"
                Columna4.Visible = False
                Dim Columna5 As New DataGridViewTextBoxColumn
                Columna5.Name = "EstadoColumna"
                Columna5.HeaderText = "Estado"
                Columna5.Visible = False

                DataReportes2.Columns.Add(Columna1)
                DataReportes2.Columns.Add(Columna2)
                DataReportes2.Columns.Add(Columna3)
                DataReportes2.Columns.Add(Columna4)
                DataReportes2.Columns.Add(Columna5)

                dtSup = db.Supervisores()
                For i As Integer = 0 To dtSup.Rows.Count - 1
                    'DataReportes2.Rows.Add(My.Resources.Badge_plus_32, dtSup(i)(0), dtSup(i)(1), "")
                    DataReportes2.Rows.Add(My.Resources.Bullet_Toggle_Minus_32, dtSup(i)(0), dtSup(i)(1), "", "Abierto")
                    Dim dtVend As New DataTable
                    dtVend.Rows.Clear()
                    dtVend = db.Vendedores(dtSup(i)(0))
                    For z As Integer = 0 To dtVend.Rows.Count - 1
                        DataReportes2.Rows.Add(My.Resources.BK, dtVend(z)(0), dtVend(z)(1), dtSup(i)(0), "")
                    Next
                Next

                MesesClientesNuevos()
            End If
            If ComboBox2.Text = "Listado de Clientes Creados" Then
                Dim db As New ClsClientes_sr_agro
                DataReportes2.DataSource = Nothing
                DataReportes2.Rows.Clear()
                DataReportes2.Columns.Clear()
                DataReportes2.DataSource = db.ClientesNuevos(DateTimePicker1.Value, DateTimePicker2.Value)
            End If
            If ComboBox2.Text = "Listado de Clientes Suspendidos" Then
                Dim db As New ClsClientes_sr_agro
                DataReportes2.DataSource = Nothing
                DataReportes2.Rows.Clear()
                DataReportes2.Columns.Clear()
                DataReportes2.DataSource = db.ClientesSuspendidos(DateTimePicker1.Value, DateTimePicker2.Value)
            End If
            FormatoGrid()
        Else

            ''''
            ''''
            ''''Clientes por ruta
            ''''
            ''''
            Dim db As New ClsClientes_sr_agro
            Dim dtSup As New DataTable
            dtSup.Rows.Clear()
            Try
                DataReportes2.Rows.Clear()
                DataReportes2.Columns.Clear()
            Catch ex As Exception

            End Try
            Try
                DataReportes2.DataSource = Nothing
            Catch ex As Exception

            End Try

            Dim Columna1 As New DataGridViewImageColumn
            Columna1.Name = "ColImagen"
            Columna1.HeaderText = ""
            Dim Columna2 As New DataGridViewTextBoxColumn
            Columna2.Name = "ColCodigo"
            Columna2.HeaderText = "Codigo"
            Dim Columna3 As New DataGridViewTextBoxColumn
            Columna3.Name = "ColNombre"
            Columna3.HeaderText = "Supervisor/Vendedor"
            Columna3.DividerWidth = 3
            Dim Columna4 As New DataGridViewTextBoxColumn
            Columna4.Name = "ColSupervisor"
            Columna4.HeaderText = "Supervisor"
            Columna4.Visible = False
            Dim Columna5 As New DataGridViewTextBoxColumn
            Columna5.Name = "EstadoColumna"
            Columna5.HeaderText = "Estado"
            Columna5.Visible = False

            DataReportes2.Columns.Add(Columna1)
            DataReportes2.Columns.Add(Columna2)
            DataReportes2.Columns.Add(Columna3)
            DataReportes2.Columns.Add(Columna4)
            DataReportes2.Columns.Add(Columna5)

            dtSup = db.Supervisores()
            For i As Integer = 0 To dtSup.Rows.Count - 1
                'DataReportes2.Rows.Add(My.Resources.Badge_plus_32, dtSup(i)(0), dtSup(i)(1), "")
                DataReportes2.Rows.Add(My.Resources.Bullet_Toggle_Minus_32, dtSup(i)(0), dtSup(i)(1), "", "Abierto")
                Dim dtVend As New DataTable
                dtVend.Rows.Clear()
                dtVend = db.Vendedores(dtSup(i)(0))
                For z As Integer = 0 To dtVend.Rows.Count - 1
                    DataReportes2.Rows.Add(My.Resources.BK, dtVend(z)(0), dtVend(z)(1), dtSup(i)(0), "")
                Next
            Next

            MesesClientesRuta()
            FormatoGrid()
        End If
    End Sub

    Sub FormatoGrid()
        With Me.DataReportes2
            .BorderStyle = BorderStyle.None
            .CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical
            .RowHeadersBorderStyle = _
                DataGridViewHeaderBorderStyle.Single
            .ColumnHeadersBorderStyle = _
                DataGridViewHeaderBorderStyle.Single
            '.Columns(6).DividerWidth = 3
            '.Columns(6).ce()
        End With
    End Sub

    Private Sub FrmClientesVenta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox1.SelectedItem = "Venta Perdida y Venta Baja"
        DateTimePicker1.Value = New DateTime(DateTimePicker1.Value.Year, DateTimePicker1.Value.Month, 1)
        Try
            DateTimePicker2.Value = New DateTime(DateTimePicker1.Value.Year, DateTimePicker1.Value.Month, DateTime.DaysInMonth(DateTimePicker2.Value.Year, DateTimePicker2.Value.Month))
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Exportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Exportar.Click
        If ComboBox1.Text = "Venta Perdida y Venta Baja" Then
            If DataDatos.RowCount > 0 Then
                Try
                    'Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
                    'Dim wBook As Microsoft.Office.Interop.Excel.Workbook
                    'Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
                    'wBook = excel.Workbooks.Add()
                    'wSheet = wBook.ActiveSheet()

                    'style = wSheet.Application.ActiveWorkbook.Styles.Add("Estilo")
                    'style.Font.Bold = True
                    'style.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                    'style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.SteelBlue)
                    'style.Font.Size = 11
                    'style.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                    'style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

                    'wSheet.Cells.Range("A1:F1").Merge()
                    'wSheet.Cells.Range("A1:F1").Borders.LineStyle = BorderStyle.FixedSingle
                    'wSheet.Cells.Range("A1:F1").Value = " Reporte de Clientes - [Venta Perdida - Venta Baja] "
                    'wSheet.Cells.Range("A1:F1").Style = "Estilo"

                    'For c As Integer = 0 To DataDatos.Columns.Count - 1
                    '    wSheet.Cells(2, c + 1).value = DataDatos.Columns(c).HeaderText
                    '    wSheet.Cells(2, c + 1).Style = "Estilo"
                    'Next
                    'For r As Integer = 0 To DataDatos.RowCount - 1
                    '    For c As Integer = 0 To DataDatos.Columns.Count - 1
                    '        wSheet.Cells(r + 3, c + 1).value = DataDatos.Item(c, r).Value
                    '        wSheet.Cells(r + 3, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    '        wSheet.Cells(r + 3, c + 1).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                    '        wSheet.Cells(r + 3, c + 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                    '        'wSheet.Cells(r + 3, c + 1).Interior.Color = System.Drawing.ColorTranslator.ToOle(DataDatos.Rows(r).DefaultCellStyle.BackColor)
                    '    Next
                    'Next
                    'wSheet.Columns.AutoFit()
                    'excel.Visible = True
                    'excel.Quit()
                    frmGuardarArchivo.Formulario = "Venta_Perdida_Venta_Baja"
                    frmGuardarArchivo.MdiParent = _Inicio
                    frmGuardarArchivo.Visible = True
                Catch ex As Exception
                    MessageBox.Show("Error al Exportar " + ex.ToString, "Problemas", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            End If
        ElseIf ComboBox1.Text = "Clientes Nuevos" Then
            If ComboBox2.Text = "Detalle Por Vendedor" Then
                If DataReportes2.RowCount > 0 Then
                    Try
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

                        For c As Integer = 1 To DataReportes2.Columns.Count - 1
                            wSheet.Cells(2, c + 1).value = DataReportes2.Columns(c).HeaderText
                            wSheet.Cells(2, c + 1).Style = "Estilo"
                        Next
                        For r As Integer = 0 To DataReportes2.RowCount - 1
                            For c As Integer = 1 To DataReportes2.Columns.Count - 1
                                wSheet.Cells(r + 3, c + 1).value = DataReportes2.Item(c, r).Value
                                wSheet.Cells(r + 3, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                                wSheet.Cells(r + 3, c + 1).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                                wSheet.Cells(r + 3, c + 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                                'wSheet.Cells(r + 3, c + 1).Interior.Color = System.Drawing.ColorTranslator.ToOle(DataDatos.Rows(r).DefaultCellStyle.BackColor)
                            Next
                        Next
                        wSheet.Range("E1").EntireColumn.Delete()
                        wSheet.Range("A1").EntireColumn.Delete()

                        wSheet.Cells.Range("A1:J1").Merge()
                        wSheet.Cells.Range("A1:J1").Borders.LineStyle = BorderStyle.FixedSingle
                        wSheet.Cells.Range("A1:J1").Value = " Reporte de Clientes - [" & ComboBox1.Text & "] "
                        wSheet.Cells.Range("A1:J1").Style = "Estilo"

                        wSheet.Columns.AutoFit()
                        excel.Visible = True
                        excel.Quit()
                    Catch ex As Exception
                        MessageBox.Show("Error al Exportar " + ex.ToString, "Problemas", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            Else
                If DataReportes2.RowCount > 0 Then
                    Try
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

                        wSheet.Cells.Range("A1:J1").Merge()
                        wSheet.Cells.Range("A1:J1").Borders.LineStyle = BorderStyle.FixedSingle
                        wSheet.Cells.Range("A1:J1").Value = " Reporte de Clientes - [" & ComboBox1.Text & "] "
                        wSheet.Cells.Range("A1:J1").Style = "Estilo"

                        For c As Integer = 0 To DataReportes2.Columns.Count - 1
                            wSheet.Cells(2, c + 1).value = DataReportes2.Columns(c).HeaderText
                            wSheet.Cells(2, c + 1).Style = "Estilo"
                        Next
                        For r As Integer = 0 To DataReportes2.RowCount - 1
                            For c As Integer = 0 To DataReportes2.Columns.Count - 1
                                wSheet.Cells(r + 3, c + 1).value = DataReportes2.Item(c, r).Value
                                wSheet.Cells(r + 3, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                                wSheet.Cells(r + 3, c + 1).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                                wSheet.Cells(r + 3, c + 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                                'wSheet.Cells(r + 3, c + 1).Interior.Color = System.Drawing.ColorTranslator.ToOle(DataDatos.Rows(r).DefaultCellStyle.BackColor)
                            Next
                        Next
                        wSheet.Columns.AutoFit()
                        excel.Visible = True
                        excel.Quit()
                    Catch ex As Exception
                        MessageBox.Show("Error al Exportar " + ex.ToString, "Problemas", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            End If
        Else
            If DataReportes2.RowCount > 0 Then
                Try
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


                    For c As Integer = 1 To DataReportes2.Columns.Count - 1
                        wSheet.Cells(2, c + 1).value = DataReportes2.Columns(c).HeaderText
                        wSheet.Cells(2, c + 1).Style = "Estilo"
                    Next
                    For r As Integer = 0 To DataReportes2.RowCount - 1
                        For c As Integer = 1 To DataReportes2.Columns.Count - 1
                            wSheet.Cells(r + 3, c + 1).value = DataReportes2.Item(c, r).Value
                            wSheet.Cells(r + 3, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                            wSheet.Cells(r + 3, c + 1).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                            wSheet.Cells(r + 3, c + 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                            'wSheet.Cells(r + 3, c + 1).Interior.Color = System.Drawing.ColorTranslator.ToOle(DataDatos.Rows(r).DefaultCellStyle.BackColor)
                        Next
                    Next
                    wSheet.Range("E1").EntireColumn.Delete()
                    wSheet.Range("A1").EntireColumn.Delete()

                    wSheet.Cells.Range("A1:J1").Merge()
                    wSheet.Cells.Range("A1:J1").Borders.LineStyle = BorderStyle.FixedSingle
                    wSheet.Cells.Range("A1:J1").Value = " Reporte de Clientes - [" & ComboBox1.Text & "] "
                    wSheet.Cells.Range("A1:J1").Style = "Estilo"

                    wSheet.Columns.AutoFit()
                    excel.Visible = True
                    excel.Quit()
                Catch ex As Exception
                    MessageBox.Show("Error al Exportar " + ex.ToString, "Problemas", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text = "Venta Perdida y Venta Baja" Then
            Label2.Visible = True
            Label3.Visible = True
            DateTimePicker1.Visible = True
            Label2.Text = "Ventas Desde"
            TabControl1.Visible = True
            DataReportes2.Visible = False
            ComboBox2.Visible = False
        ElseIf ComboBox1.Text = "Clientes Nuevos" Then
            Label2.Visible = True
            Label3.Visible = False
            DateTimePicker1.Visible = True
            Label2.Text = "Clientes Desde"
            TabControl1.Visible = False
            DataReportes2.Visible = True
            ComboBox2.Visible = True
        Else
            Label2.Visible = True
            Label3.Visible = True
            Label2.Text = "Desde"
            TabControl1.Visible = False
            DataReportes2.Visible = True
            ComboBox2.Visible = False
        End If
    End Sub

    Private Sub DataReportes2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataReportes2.CellClick

        If e.ColumnIndex = 0 Then
            Try

                If Not IsNumeric(DataReportes2.CurrentRow.Cells("ColSupervisor").Value) Then
                    If DataReportes2.CurrentRow.Cells("ColSupervisor").Value = "" Then
                        If DataReportes2.CurrentRow.Cells("EstadoColumna").Value = "Abierto" Then
                            For Each row As DataGridViewRow In DataReportes2.Rows
                                If Val(row.Cells("ColSupervisor").Value) = Val(DataReportes2.CurrentRow.Cells(1).Value) Then
                                    row.Visible = False
                                    DataReportes2.CurrentRow.Cells("EstadoColumna").Value = "Cerrado"
                                    DataReportes2.CurrentRow.Cells(0).Value = My.Resources.Badge_plus_32
                                End If
                            Next
                        Else
                            For Each row As DataGridViewRow In DataReportes2.Rows
                                If Val(row.Cells("ColSupervisor").Value) = Val(DataReportes2.CurrentRow.Cells(1).Value) Then
                                    row.Visible = True
                                    DataReportes2.CurrentRow.Cells("EstadoColumna").Value = "Abierto"
                                    DataReportes2.CurrentRow.Cells(0).Value = My.Resources.Bullet_Toggle_Minus_32
                                End If
                            Next
                        End If
                    End If
                End If

            Catch ex As Exception
                'MsgBox(ex.Message)
            End Try
        End If


    End Sub

    Private Sub DataReportes2_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataReportes2.CellDoubleClick
        Try

            If Not IsNumeric(DataReportes2.CurrentRow.Cells("ColSupervisor").Value) Then
                If DataReportes2.CurrentRow.Cells("ColSupervisor").Value = "" Then
                    If DataReportes2.CurrentRow.Cells("EstadoColumna").Value = "Abierto" Then
                        For Each row As DataGridViewRow In DataReportes2.Rows
                            If Val(row.Cells("ColSupervisor").Value) = Val(DataReportes2.CurrentRow.Cells(1).Value) Then
                                row.Visible = False
                                DataReportes2.CurrentRow.Cells("EstadoColumna").Value = "Cerrado"
                                DataReportes2.CurrentRow.Cells(0).Value = My.Resources.Badge_plus_32
                            End If
                        Next
                    Else
                        For Each row As DataGridViewRow In DataReportes2.Rows
                            If Val(row.Cells("ColSupervisor").Value) = Val(DataReportes2.CurrentRow.Cells(1).Value) Then
                                row.Visible = True
                                DataReportes2.CurrentRow.Cells("EstadoColumna").Value = "Abierto"
                                DataReportes2.CurrentRow.Cells(0).Value = My.Resources.Bullet_Toggle_Minus_32
                            End If
                        Next
                    End If
                End If
            End If

        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Sub MesesClientesNuevos()
        Dim NumeroMes, NumeroMesFinal As Integer
        NumeroMes = DateTimePicker1.Value.Month
        NumeroMesFinal = DateTimePicker2.Value.Month

        For A As Integer = NumeroMes To NumeroMesFinal

            Dim Columna As New DataGridViewTextBoxColumn
            Columna.HeaderText = "Clientes Creados " & MonthName(A).ToUpper
            Columna.Name = "C" & MonthName(A).ToUpper
            DataReportes2.Columns.Add(Columna)

            'Funcion Creados
            For Each row As DataGridViewRow In DataReportes2.Rows
                If IsNumeric(row.Cells("ColSupervisor").Value) Then
                    Dim db As New ClsClientes_sr_agro
                    Dim dtc As New DataTable
                    dtc.Rows.Clear()
                    Dim C As Integer = 0
                    If A = DateTimePicker1.Value.Month Then
                        dtc = db.ClientesNuevosCantidad(DateTimePicker1.Value, New DateTime(DateTimePicker2.Value.Year, A, DateTime.DaysInMonth(DateTimePicker2.Value.Year, A)), row.Cells(1).Value)
                        C = dtc(0)(0)
                    ElseIf A = DateTimePicker2.Value.Month Then
                        dtc = db.ClientesNuevosCantidad(Convert.ToDateTime("01-" & A & "-" & DateTimePicker1.Value.Year), DateTimePicker2.Value, row.Cells(1).Value)
                        C = dtc(0)(0)
                    Else
                        dtc = db.ClientesNuevosCantidad(Convert.ToDateTime("01-" & A & "-" & DateTimePicker1.Value.Year), New DateTime(DateTimePicker2.Value.Year, A, DateTime.DaysInMonth(DateTimePicker2.Value.Year, A)), row.Cells(1).Value)
                        C = dtc(0)(0)
                    End If
                    row.Cells(DataReportes2.ColumnCount - 1).Value = C
                End If
            Next

            Dim Columna2 As New DataGridViewTextBoxColumn
            Columna2.HeaderText = "Clientes Suspendidos " & MonthName(A).ToUpper
            Columna2.Name = "S" & MonthName(A).ToUpper
            DataReportes2.Columns.Add(Columna2)

            For Each row As DataGridViewRow In DataReportes2.Rows
                If IsNumeric(row.Cells("ColSupervisor").Value) Then
                    Dim db As New ClsClientes_sr_agro
                    Dim dts As New DataTable
                    dts.Rows.Clear()
                    Dim C As Integer = 0
                    If A = DateTimePicker1.Value.Month Then
                        dts = db.ClientesSuspendidosCantidad(DateTimePicker1.Value, New DateTime(DateTimePicker2.Value.Year, A, DateTime.DaysInMonth(DateTimePicker2.Value.Year, A)), row.Cells(1).Value)
                        C = dts(0)(0)
                    ElseIf A = DateTimePicker2.Value.Month Then
                        dts = db.ClientesSuspendidosCantidad(Convert.ToDateTime("01-" & A & "-" & DateTimePicker1.Value.Year), DateTimePicker2.Value, row.Cells(1).Value)
                        C = dts(0)(0)
                    Else
                        dts = db.ClientesSuspendidosCantidad(Convert.ToDateTime("01-" & A & "-" & DateTimePicker1.Value.Year), New DateTime(DateTimePicker2.Value.Year, A, DateTime.DaysInMonth(DateTimePicker2.Value.Year, A)), row.Cells(1).Value)
                        C = dts(0)(0)
                    End If
                    row.Cells(DataReportes2.ColumnCount - 1).Value = C
                End If
            Next

            Dim Columna3 As New DataGridViewTextBoxColumn
            Columna3.HeaderText = "Clientes Nuevos " & MonthName(A).ToUpper
            Columna3.Name = "N" & MonthName(A).ToUpper
            Columna3.DividerWidth = 3
            DataReportes2.Columns.Add(Columna3)

            For Each row As DataGridViewRow In DataReportes2.Rows
                If Not IsNumeric(row.Cells("ColSupervisor").Value) Then
                    Dim Contador As Integer
                    Contador = 0
                    Dim ContadorSuspendidos As Integer
                    ContadorSuspendidos = 0

                    row.DefaultCellStyle.BackColor = Color.SteelBlue

                    For Each row2 As DataGridViewRow In DataReportes2.Rows
                        If IsNumeric(row2.Cells("ColSupervisor").Value) Then
                            If row2.Cells("ColSupervisor").Value = row.Cells("ColCodigo").Value Then
                                Contador += row2.Cells(DataReportes2.ColumnCount - 3).Value
                                ContadorSuspendidos += row2.Cells(DataReportes2.ColumnCount - 2).Value
                            End If
                        End If
                    Next
                    row.Cells(DataReportes2.ColumnCount - 3).Value = Contador
                    row.Cells(DataReportes2.ColumnCount - 2).Value = ContadorSuspendidos
                End If
                row.Cells(DataReportes2.ColumnCount - 1).Value = row.Cells(DataReportes2.ColumnCount - 3).Value - row.Cells(DataReportes2.ColumnCount - 2).Value
            Next
        Next

        DataReportes2.Columns(0).Frozen = True
        DataReportes2.Columns(1).Frozen = True
        DataReportes2.Columns(2).Frozen = True
        DataReportes2.Columns(3).Frozen = True

        For Each column As DataGridViewColumn In DataReportes2.Columns
            column.SortMode = DataGridViewColumnSortMode.NotSortable
        Next

    End Sub

    Sub MesesClientesRuta()
        Dim NumeroMes, NumeroMesFinal As Integer
        NumeroMes = DateTimePicker1.Value.Month
        NumeroMesFinal = DateTimePicker2.Value.Month

        For A As Integer = NumeroMes To NumeroMesFinal

            Dim Columna As New DataGridViewTextBoxColumn
            Columna.HeaderText = "Universo - " & MonthName(A).ToUpper
            Columna.Name = "U" & MonthName(A).ToUpper
            DataReportes2.Columns.Add(Columna)

            'Funcion Creados
            For Each row As DataGridViewRow In DataReportes2.Rows
                If IsNumeric(row.Cells("ColSupervisor").Value) Then
                    Dim db As New ClsClientes_sr_agro
                    Dim dtc As New DataTable
                    dtc.Rows.Clear()
                    Dim C As Integer = 0
                    If A = DateTimePicker1.Value.Month Then
                        dtc = db.ClientesActivosMes(DateTimePicker1.Value, New DateTime(DateTimePicker2.Value.Year, A, DateTime.DaysInMonth(DateTimePicker2.Value.Year, A)), row.Cells(1).Value)
                        C = dtc(0)(0)
                    ElseIf A = DateTimePicker2.Value.Month Then
                        dtc = db.ClientesActivosMes(Convert.ToDateTime("01-" & A & "-" & DateTimePicker1.Value.Year), DateTimePicker2.Value, row.Cells(1).Value)
                        C = dtc(0)(0)
                    Else
                        dtc = db.ClientesActivosMes(Convert.ToDateTime("01-" & A & "-" & DateTimePicker1.Value.Year), New DateTime(DateTimePicker2.Value.Year, A, DateTime.DaysInMonth(DateTimePicker2.Value.Year, A)), row.Cells(1).Value)
                        C = dtc(0)(0)
                    End If
                    row.Cells(DataReportes2.ColumnCount - 1).Value = C
                End If
            Next

            Dim Columna2 As New DataGridViewTextBoxColumn
            Columna2.HeaderText = "Ideal - " & MonthName(A).ToUpper
            Columna2.Name = "I" & MonthName(A).ToUpper
            DataReportes2.Columns.Add(Columna2)

            For Each row As DataGridViewRow In DataReportes2.Rows
                If IsNumeric(row.Cells("ColSupervisor").Value) Then
                    Dim db As New ClsClientes_sr_agro
                    Dim dts As New DataTable
                    dts.Rows.Clear()
                    Dim C As Integer = 0
                    dts = db.ClientesIdeales(DateTimePicker1.Value.Year, A, row.Cells(1).Value)
                    Try
                        C = dts(0)(3)
                    Catch ex As Exception
                    End Try
                    row.Cells(DataReportes2.ColumnCount - 1).Value = C
                End If
            Next

            Dim Columna3 As New DataGridViewTextBoxColumn
            Columna3.HeaderText = "GAP - " & MonthName(A).ToUpper
            Columna3.Name = "G" & MonthName(A).ToUpper
            Columna3.DividerWidth = 3
            DataReportes2.Columns.Add(Columna3)

            For Each row As DataGridViewRow In DataReportes2.Rows
                If Not IsNumeric(row.Cells("ColSupervisor").Value) Then
                    Dim Contador As Integer
                    Contador = 0
                    Dim ContadorSuspendidos As Integer
                    ContadorSuspendidos = 0

                    row.DefaultCellStyle.BackColor = Color.SteelBlue

                    For Each row2 As DataGridViewRow In DataReportes2.Rows
                        If IsNumeric(row2.Cells("ColSupervisor").Value) Then
                            If row2.Cells("ColSupervisor").Value = row.Cells("ColCodigo").Value Then
                                Contador += row2.Cells(DataReportes2.ColumnCount - 3).Value
                                ContadorSuspendidos += row2.Cells(DataReportes2.ColumnCount - 2).Value
                            End If
                        End If
                    Next
                    row.Cells(DataReportes2.ColumnCount - 3).Value = Contador
                    row.Cells(DataReportes2.ColumnCount - 2).Value = ContadorSuspendidos
                End If
                row.Cells(DataReportes2.ColumnCount - 1).Value = row.Cells(DataReportes2.ColumnCount - 3).Value - row.Cells(DataReportes2.ColumnCount - 2).Value
            Next
        Next

        DataReportes2.Columns(0).Frozen = True
        DataReportes2.Columns(1).Frozen = True
        DataReportes2.Columns(2).Frozen = True
        DataReportes2.Columns(3).Frozen = True

        For Each column As DataGridViewColumn In DataReportes2.Columns
            column.SortMode = DataGridViewColumnSortMode.NotSortable
        Next

    End Sub

    Sub exportarTXT(ByVal Ruta As String)
        Dim sFile As String = Ruta & "\Vp_VbConsolidado" & Now.Day & "-" & Now.Month & "-" & Now.Year & ".xls "
        Dim _Line As String = Nothing
        Try
            If File.Exists(sFile) = True Then
                My.Computer.FileSystem.DeleteFile(sFile, FileIO.UIOption.OnlyErrorDialogs, _
                                                  FileIO.RecycleOption.DeletePermanently, FileIO.UICancelOption.DoNothing)
            End If
            Dim swFile As StreamWriter = New StreamWriter(sFile, True, System.Text.Encoding.Default)

            '_Line = "Año Anterior"
            'swFile.WriteLine(_Line)
            '_Line = ""

            For Each column As DataGridViewColumn In DataDatos.Columns
                _Line = _Line & column.HeaderText & vbTab
            Next
            For a As Integer = 1 To TabControl1.TabPages.Count - 1
                For Each DatosMes As DataGridView In TabControl1.TabPages(a).Controls
                    For Each column As DataGridViewColumn In DatosMes.Columns
                        If column.Index = 3 Then
                            _Line = _Line & TabControl1.TabPages(a).Name & vbTab
                        End If
                    Next
                Next
            Next
            _Line = _Line & "DETALLE" & vbTab

            swFile.WriteLine(_Line)

            For i = 0 To DataDatos.RowCount - 1
                _Line = ""
                For Each column As DataGridViewColumn In DataDatos.Columns
                    _Line = _Line & DataDatos.Rows(i).Cells(column.Index).Value & vbTab
                Next
                For a As Integer = 1 To TabControl1.TabPages.Count - 1
                    For Each DatosMes As DataGridView In TabControl1.TabPages(a).Controls
                        For Each column As DataGridViewColumn In DatosMes.Columns
                            If column.Index >= 3 Then
                                _Line = _Line & DatosMes.Rows(i).Cells(column.Index).Value & vbTab
                            End If
                        Next
                    Next
                Next

                swFile.WriteLine(_Line)

            Next
            _Line = ""
            swFile.WriteLine(_Line)
            swFile.WriteLine(_Line)

            'For a As Integer = 1 To TabControl1.TabPages.Count - 1
            '    For Each DatosMes As DataGridView In TabControl1.TabPages(a).Controls

            '        swFile.WriteLine(_Line)
            '        swFile.WriteLine(_Line)
            '        _Line = TabControl1.TabPages(a).Name
            '        swFile.WriteLine(_Line)
            '        _Line = ""
            '        swFile.WriteLine(_Line)

            '        For Each column As DataGridViewColumn In DatosMes.Columns
            '            _Line = _Line & column.HeaderText & vbTab
            '        Next
            '        swFile.WriteLine(_Line)

            '        For i = 0 To DatosMes.RowCount - 1
            '            _Line = ""
            '            For Each column As DataGridViewColumn In DatosMes.Columns
            '                _Line = _Line & DataDatos.Rows(i).Cells(column.Index).Value & vbTab
            '            Next
            '            swFile.WriteLine(_Line)
            '        Next
            '    Next
            'Next

            'swFile = System.Text.Encoding.Default
            swFile.Close()
            Process.Start(sFile)
        Catch ex As Exception
            MessageBox.Show("Error" + ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


End Class