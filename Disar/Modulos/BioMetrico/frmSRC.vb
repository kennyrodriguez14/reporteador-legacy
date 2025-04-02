Imports Disar.data

Public Class frmSRC


    Dim Tablas As New DataTable
    Dim Tablas2 As New DataTable
    Dim Tablas3 As New DataTable
    Dim TablaCompleta As New DataTable
    Dim Filas As DataRow = Tablas.NewRow

    Dim CantidadDias As Decimal

    'Dim CantidadRegistros(2) As Integer

    Dim style As Microsoft.Office.Interop.Excel.Style

    Private Sub FrmSalidasAlmacen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Dim db As New Clas_conexion_biometrico
        ComboDepartamento.DataSource = db.Departamentos
        ComboDepartamento.DisplayMember = "Departamento"
        ComboDepartamento.ValueMember = "Departamento"
    End Sub

    Private Sub BtnFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFiltro.Click
        Dim db As New Clas_conexion_biometrico

        Dim Revisar As New DataTable
        Try
            Revisar.Rows.Clear()
        Catch ex As Exception
        End Try

        Revisar = db.Revisar(ComboBox1.Text, ComboDepartamento.Text, _Inicio.lblUsuario.Text)

        If Revisar.Rows.Count > 0 Then

            Try
                DataCompleto.Columns.Clear()
                DataHora.Columns.Clear()
            Catch ex As Exception
            End Try

            Try
                'DataEntrada.DataSource = db.CargarDatos(DateTimePicker1.Value, DateTimePicker2.Value)
                'DataSalidas.DataSource = db.CargarSalidas(DateTimePicker1.Value, DateTimePicker2.Value)
                If ComboDepartamento.Text = "Todos" Then
                    DataCompleto.DataSource = db.TodosNombres(ComboBox1.Text)
                Else
                    DataCompleto.DataSource = db.CargaNombresDepartamento(ComboBox1.Text, ComboDepartamento.Text)
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Try
                If ComboDepartamento.Text = "Todos" Then
                    DataHora.DataSource = db.TodosNombres(ComboBox1.Text)
                Else
                    DataHora.DataSource = db.CargaNombresDepartamento(ComboBox1.Text, ComboDepartamento.Text)
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            Try
                ColumnasDias()
                ListarHoras()
            Catch ex As Exception
                MsgBox("Error" & ex.Message)
            End Try
        Else
            MsgBox("No tiene permiso para generar este reporte. Intente nuevamente con otros datos o pida acceso al departamento especificado.", MsgBoxStyle.Information, "Aviso")
        End If

    End Sub

    Sub ColumnasDias()

        'Tablas.Clear()
        'Tablas.Columns.Clear()
        'Tablas.Columns.Add("NOMBRE")
        'Tablas2.Clear()
        'Tablas2.Columns.Clear()
        'Tablas2.Columns.Add("NOMBRE")
        'Tablas3.Clear()
        'Tablas3.Columns.Clear()
        'Tablas3.Columns.Add("NOMBRE")
        'TablaCompleta.Clear()
        'TablaCompleta.Columns.Clear()
        'TablaCompleta.Columns.Add("NOMBRE")

        CantidadDias = 0

        For i As Integer = 0 To DateDiff(DateInterval.Day, DateTimePicker1.Value, DateTimePicker2.Value)
            If DateTimePicker1.Value.AddDays(i).Date.DayOfWeek <> DayOfWeek.Sunday Then
                'Tablas.Columns.Add(DateTimePicker1.Value.AddDays(i).Date)
                'Tablas2.Columns.Add(DateTimePicker1.Value.AddDays(i).Date)
                'Tablas3.Columns.Add(DateTimePicker1.Value.AddDays(i).Date)
                'TablaCompleta.Columns.Add(DateTimePicker1.Value.AddDays(i).Date)
                Dim Columna As New DataGridViewTextBoxColumn
                Dim Columna1 As New DataGridViewTextBoxColumn
                Columna.Name = "Entrada " & DateTimePicker1.Value.AddDays(i).Date
                Columna.HeaderText = "Entrada " & DateTimePicker1.Value.AddDays(i).Date
                Columna1.Name = "Salida " & DateTimePicker1.Value.AddDays(i).Date
                Columna1.HeaderText = "Salida " & DateTimePicker1.Value.AddDays(i).Date
                Dim Columna2 As New DataGridViewTextBoxColumn
                Columna2.Name = DateTimePicker1.Value.AddDays(i).Date
                Columna2.HeaderText = DateTimePicker1.Value.AddDays(i).Date

                If Convert.ToDateTime(Columna2.HeaderText).Date.DayOfWeek = DayOfWeek.Saturday Then
                    CantidadDias += 0.5
                Else
                    CantidadDias += 1
                End If

                DataCompleto.Columns.Add(Columna)
                DataCompleto.Columns.Add(Columna1)
                DataHora.Columns.Add(Columna2)
            End If
        Next

        Dim ColumnaFim As New DataGridViewTextBoxColumn
        ColumnaFim.Name = "Promedio"
        ColumnaFim.HeaderText = "Promedio"
        DataHora.Columns.Add(ColumnaFim)

        Dim ColumnaTarde As New DataGridViewTextBoxColumn
        ColumnaTarde.Name = "Tarde"
        ColumnaTarde.HeaderText = "Llegadas Tardías"
        DataHora.Columns.Add(ColumnaTarde)
        'DataTodas.DataSource = Tablas
        'DataGridView1.DataSource = Tablas2
        'DataHora.DataSource = Tablas3
        'DataCompleto.DataSource = TablaCompleta

        With Me.DataCompleto
            .BorderStyle = BorderStyle.None
            .CellBorderStyle = DataGridViewCellBorderStyle.Raised
            .RowHeadersBorderStyle = _
                DataGridViewHeaderBorderStyle.Raised
            .ColumnHeadersBorderStyle = _
                DataGridViewHeaderBorderStyle.Raised
            For Each column As DataGridViewColumn In DataCompleto.Columns
                If column.Index Mod 2 <> 0 Then
                    column.DividerWidth = 4
                Else
                    column.DividerWidth = 0
                End If
            Next
        End With

    End Sub


    Sub ListarHoras()

        Dim Tabla As String = ""

        If ComboBox1.Text = "SRC" Then
            Tabla = "att2000"
        ElseIf ComboBox1.Text = "SPS" Then
            Tabla = "att2000SPS"
        ElseIf ComboBox1.Text = "TEGUCIGALPA" Then
            Tabla = "att2000TGU"
        ElseIf ComboBox1.Text = "SR AGRO SRC" Then
            Tabla = "att2000AgroSRC"
        ElseIf ComboBox1.Text = "SABA" Then
            Tabla = "att2000SABA"
        End If

        'ReDim CantidadRegistros(DataCompleto.RowCount - 1)

        'Try
        '    Dim Conexion As New Clas_conexion_biometrico
        '    Dim Cont As Integer = 0
        '    GridVendedores.DataSource = Conexion.TODOSDatos(DateTimePicker1.Value, DateTimePicker2.Value, ComboBox1.Text)
        '    Cont = GridVendedores.RowCount - 1
        '    For Each row As DataGridViewRow In DataEntrada.Rows
        '        Tablas.Rows.Add(row.Cells(0).Value)
        '        Tablas2.Rows.Add(row.Cells(0).Value)
        '        Tablas3.Rows.Add(row.Cells(0).Value)
        '        TablaCompleta.Rows.Add(row.Cells(0).Value)
        '    Next
        '    DataTodas.DataSource = Tablas
        '    DataGridView1.DataSource = Tablas2
        '    DataHora.DataSource = Tablas3
        '    DataCompleto.DataSource = TablaCompleta
        'Catch ex As Exception
        '    MsgBox("Error al listar registros " & ex.Message)
        'End Try
        Dim db As New Clas_conexion_biometrico
        Dim Tipo As String = "I"
        For Each row As DataGridViewRow In DataCompleto.Rows

            'CantidadRegistros(row.Index) = 0

            Dim Vendedor As String = row.Cells(0).Value
            For Each column As DataGridViewColumn In DataCompleto.Columns
                If column.Index > 1 Then
                    Dim Fecha As Date
                    If column.Index Mod 2 = 0 Then
                        Fecha = Convert.ToDateTime(column.HeaderText.Substring(8, 10))
                        Tipo = "I"
                    Else
                        Fecha = Convert.ToDateTime(column.HeaderText.Substring(7, 10))
                        Tipo = "F"
                    End If

                    Try
                        row.Cells(column.Index).Value = Format(db.HorasTrabajadasSQL(Fecha, Vendedor, Tipo, Tabla)(0)(0), "HH:mm")
                        If Tipo = "I" And Format(db.HorasTrabajadasSQL(Fecha, Vendedor, Tipo, Tabla)(0)(0), "HH:mm") > "08:00" Then
                            row.Cells(column.Index).Style.BackColor = Color.DarkRed
                            row.Cells(column.Index).Style.ForeColor = Color.WhiteSmoke
                        End If
                    Catch ex As Exception
                    End Try
                End If
            Next
        Next

        Dim CantidadHoras As Decimal
        Dim Tarde As Integer
        For Each row As DataGridViewRow In DataHora.Rows
            CantidadHoras = 0
            Tarde = 0
            Dim Vendedor As String = row.Cells(0).Value
            For Each column As DataGridViewColumn In DataHora.Columns
                If column.HeaderText <> "Promedio" And column.HeaderText <> "Llegadas Tardías" Then
                    If column.Index > 1 Then
                        Dim Inicio As DateTime
                        Dim Final As DateTime
                        Dim a As Integer = 0
                        Try
                            Inicio = Format(db.HorasTrabajadasSQL(column.HeaderText, Vendedor, "I", Tabla)(0)(0), "HH:mm")
                            If Inicio > "08:00" Then
                                Tarde += 1
                            End If
                        Catch ex As Exception
                            a = 1
                        End Try
                        Try
                            Final = Format(db.HorasTrabajadasSQL(column.HeaderText, Vendedor, "F", Tabla)(0)(0), "HH:mm")
                        Catch ex As Exception
                            a = 1
                        End Try
                        If a = 0 Then
                            Dim Horas As Integer = DateDiff(DateInterval.Hour, Inicio, Final)
                            If Horas >= 8 Then
                                Horas -= 1
                            End If
                            CantidadHoras += Horas
                            row.Cells(column.Index).Value = Horas.ToString
                        Else
                            row.Cells(column.Index).Value = 0
                        End If
                    End If
                ElseIf column.HeaderText = "Promedio" Then
                    Dim Total As Decimal
                    Total = CantidadHoras / CantidadDias
                    row.Cells(column.Index).Value = Total
                End If
                If column.Index = DataHora.ColumnCount - 1 Then
                    row.Cells(column.Index).Value = Tarde
                End If
            Next
        Next

        DataCompleto.Columns(0).Frozen = True
        DataCompleto.Columns(1).Frozen = True
        DataHora.Columns(0).Frozen = True
        DataHora.Columns(1).Frozen = True
    End Sub

    Sub Exportar()
        Try
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()
            wSheet.Name = "Entradas y Salidas"

            style = wSheet.Application.ActiveWorkbook.Styles.Add("Estilo")
            style.Font.Bold = True
            style.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.SteelBlue)
            style.Font.Size = 11
            style.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            Dim filas As Integer = 1

            wSheet.Cells.Range("A1:E1").Merge()
            wSheet.Cells.Range("A1:E1").Borders.LineStyle = BorderStyle.FixedSingle
            wSheet.Cells.Range("A1:E1").Value = " Reporte de Entradas / Salidas " & ComboBox1.Text
            wSheet.Cells.Range("A1:E1").Style = "Estilo"

            filas += 1
            For c As Integer = 0 To DataCompleto.Columns.Count - 1

                If c = 0 Then
                    wSheet.Cells(filas, c + 1).value = DataCompleto.Columns(c).HeaderText.ToString
                    wSheet.Cells(filas, c + 1).Style = "Estilo"
                Else
                    wSheet.Cells(filas, c + 1).value = DataCompleto.Columns(c).HeaderText.ToString
                    wSheet.Cells(filas, c + 1).Style = "Estilo"
                End If
            Next
            For r As Integer = 0 To DataCompleto.RowCount - 1
                filas += 1
                For c As Integer = 0 To DataCompleto.Columns.Count - 1
                    'wSheet.Cells(0, c + 1).Style = "Estilo"
                    wSheet.Cells(filas, c + 1).value = DataCompleto.Item(c, r).Value
                    wSheet.Cells(filas, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    wSheet.Cells(filas, c + 1).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                    wSheet.Cells(filas, c + 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

                    If DataCompleto.Rows(r).Cells(c).Style.BackColor = Color.DarkRed Then
                        wSheet.Cells(filas, c + 1).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkRed)
                        wSheet.Cells(filas, c + 1).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                    End If

                Next
            Next

            'Exporte de Horas
            filas += 3
            Dim Asse = filas
            wSheet.Cells.Range("A" & filas & ":E" & filas & "").Merge()
            wSheet.Cells.Range("A" & filas & ":E" & filas & "").Borders.LineStyle = BorderStyle.FixedSingle
            wSheet.Cells.Range("A" & filas & ":E" & filas & "").Value = " Horas Trabajadas " & ComboBox1.Text
            wSheet.Cells.Range("A" & filas & ":E" & filas & "").Style = "Estilo"

            filas += 1
            For c As Integer = 0 To DataHora.Columns.Count - 1

                If c = 0 Then
                    wSheet.Cells(filas, c + 1).value = DataHora.Columns(c).HeaderText.ToString
                    wSheet.Cells(filas, c + 1).Style = "Estilo"
                Else
                    wSheet.Cells(filas, c + 1).value = " " & DataHora.Columns(c).HeaderText.ToString
                    wSheet.Cells(filas, c + 1).Style = "Estilo"

                End If
            Next
            For r As Integer = 0 To DataHora.RowCount - 1
                filas += 1
                For c As Integer = 0 To DataHora.Columns.Count - 1
                    wSheet.Cells(filas, c + 1).value = DataHora.Item(c, r).Value
                    wSheet.Cells(filas, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    wSheet.Cells(filas, c + 1).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                    wSheet.Cells(filas, c + 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                Next
            Next
            wSheet.Columns.AutoFit()
            excel.Visible = True
            excel.Quit()
        Catch ex As Exception
            MessageBox.Show("Error al Exportar " + ex.ToString, "Problemas", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Exportar()
    End Sub


End Class