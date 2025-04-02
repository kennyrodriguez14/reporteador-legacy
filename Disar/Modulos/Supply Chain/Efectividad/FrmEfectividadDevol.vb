Imports Disar.data

Public Class FrmEfectividadDevol
    Dim style As Microsoft.Office.Interop.Excel.Style
    Public Empre As Integer = 0
    Private Sub ComboEd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboEd.SelectedIndexChanged
        ComboSucursal.SelectedIndex = 0
        If ComboEd.Text = "Entregador" Then
            Label2.Visible = True
            ComboFiltro.Visible = True
            Try
                Empre = _Inicio.Almacen
            Catch ex As Exception
            End Try
            Try
                Dim db As New ClsEfectividad
                ComboFiltro.DataSource = db.Entregadores(Empre, "SAN RAFAEL")
                ComboFiltro.ValueMember = "EntregadorCodigo"
                ComboFiltro.DisplayMember = "EntregadorNombre"
            Catch ex As Exception
            End Try

        ElseIf ComboEd.Text = "Sucursal" Then
            ComboFiltro.Visible = False
            Label2.Visible = False
        ElseIf ComboEd.Text = "Vehículo" Then
            ComboFiltro.Visible = True
            Label2.Visible = True

            Try
                Dim db As New ClsEfectividad
                ComboFiltro.DataSource = db.Vehiculos
                ComboFiltro.ValueMember = "VehiculoId"
                ComboFiltro.DisplayMember = "VehiculoDescripcion"
            Catch ex As Exception
            End Try

        End If
    End Sub

    Private Sub ComboSucursal_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboSucursal.SelectedIndexChanged
        If ComboEd.Text = "Entregador" Then
            Dim Numero As Integer = 0
            If ComboSucursal.Text = "SPS" Then
                Numero = 1
            End If
            If ComboSucursal.Text = "SRC" Then
                Numero = 2
            End If
            If ComboSucursal.Text = "SABA" Then
                Numero = 3
            End If
            If ComboSucursal.Text = "TEGUCIGALPA" Then
                Numero = 4
            End If
            If ComboSucursal.Text = "TODAS" Then
                Numero = 0
            End If
            Try
                If ComboSucursal.Text = "TODAS" Then
                    Dim db As New ClsEfectividad
                    ComboFiltro.DataSource = db.Entregadores(Empre, "SAN RAFAEL")
                Else
                    Dim db As New ClsEfectividad
                    ComboFiltro.DataSource = db.FiltrarEntregadores(Numero)
                End If
            Catch ex As Exception
            End Try
        End If
        If ComboEd.Text = "Vehículo" Then
            Dim Numero As Integer = 0
            If ComboSucursal.Text = "SPS" Then
                Numero = 1
            End If
            If ComboSucursal.Text = "SRC" Then
                Numero = 2
            End If
            If ComboSucursal.Text = "SABA" Then
                Numero = 3
            End If
            If ComboSucursal.Text = "TEGUCIGALPA" Then
                Numero = 4
            End If
            If ComboSucursal.Text = "TODAS" Then
                Numero = 0
            End If
            Try
                If ComboSucursal.Text = "TODAS" Then
                    Dim db As New ClsEfectividad
                    ComboFiltro.DataSource = db.Vehiculos
                Else
                    Dim db As New ClsEfectividad
                    ComboFiltro.DataSource = db.FiltrarVehiculos(Numero)
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub BtnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGenerar.Click
        Dim Numero As Integer
        Dim db As New ClsEfectividad
        If ComboEd.Text = "Sucursal" Then

            If ComboSucursal.Text = "TODAS" Then
                Try
                    DataConsumo.DataSource = db.Reporte(DateDesde.Value, DateHasta.Value, "DEV-SUC-CONSUMO", "")
                    DataAgro.DataSource = db.Reporte(DateDesde.Value, DateHasta.Value, "DEV-SUC-AGRO", "")
                Catch ex As Exception
                End Try
            Else
                If ComboSucursal.Text = "SPS" Then
                    Numero = 1
                End If
                If ComboSucursal.Text = "SRC" Then
                    Numero = 2
                End If
                If ComboSucursal.Text = "SABA" Then
                    Numero = 3
                End If
                If ComboSucursal.Text = "TEGUCIGALPA" Then
                    Numero = 4
                End If

                Try
                    DataConsumo.DataSource = db.Reporte(DateDesde.Value, DateHasta.Value, "DEV-SUC-CONSUMO-XALMACEN", Numero)
                    If Numero = 2 Then
                        DataAgro.DataSource = db.Reporte(DateDesde.Value, DateHasta.Value, "DEV-SUC-AGRO-XALMACEN", Numero)
                    Else
                        DataAgro.DataSource = Nothing
                    End If
                Catch ex As Exception
                End Try
            End If
        ElseIf ComboEd.Text = "Entregador" Then
            Try
                DataAgro.DataSource = Nothing
            Catch ex As Exception
            End Try
            Try
                DataConsumo.DataSource = db.Reporte(DateDesde.Value, DateHasta.Value, "DEV-ENT-CONSUMO", ComboFiltro.SelectedValue)
                DataAgro.DataSource = db.Reporte(DateDesde.Value, DateHasta.Value, "DEV-ENT-AGRO", ComboFiltro.SelectedValue)
            Catch ex As Exception
            End Try
        ElseIf ComboEd.Text = "Vehículo" Then
            Try
                DataAgro.DataSource = Nothing
            Catch ex As Exception
            End Try
            Try
                DataConsumo.DataSource = db.Reporte(DateDesde.Value, DateHasta.Value, "DEV-VE-CONSUMO", ComboFiltro.SelectedValue)
                DataAgro.DataSource = db.Reporte(DateDesde.Value, DateHasta.Value, "DEV-VE-AGRO", ComboFiltro.SelectedValue)
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
        Dim wBook As Microsoft.Office.Interop.Excel.Workbook
        Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
        Dim wSheet2 As Microsoft.Office.Interop.Excel.Worksheet

        wBook = excel.Workbooks.Add()

        'AGRO
        wSheet2 = wBook.ActiveSheet()
        wSheet2.Name = "SR AGRO"
        
        style = wSheet2.Application.ActiveWorkbook.Styles.Add("Estilo")
        style.Font.Bold = True
        style.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
        style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.SteelBlue)
        style.Font.Size = 11
        style.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
        style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

        'AGRO

        wSheet2.Cells.Range("A1:M1").Merge()
        wSheet2.Cells.Range("A1:M1").Borders.LineStyle = BorderStyle.FixedSingle
        wSheet2.Cells.Range("A1:M1").Value = " REPORTE DE EFECTIVIDAD - DEVOLUCIONES SR AGRO"
        wSheet2.Cells.Range("A1:M1").Style = "Estilo"

        For c As Integer = 0 To DataAgro.Columns.Count - 1
            wSheet2.Cells(2, c + 1).value = DataAgro.Columns(c).HeaderText
            wSheet2.Cells(2, c + 1).Style = "Estilo"
        Next

        For r As Integer = 0 To DataAgro.RowCount - 1
            For c As Integer = 0 To DataAgro.Columns.Count - 1
                wSheet2.Cells(r + 3, c + 1).value = DataAgro.Item(c, r).Value
                wSheet2.Cells(r + 3, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet2.Cells(r + 3, c + 1).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            Next
        Next

        'CONSUMO
        wSheet = wBook.ActiveSheet()
        wSheet = wBook.Sheets.Add()
        wSheet.Name = "CONSUMO"

        wSheet.Cells.Range("A1:M1").Merge()
        wSheet.Cells.Range("A1:M1").Borders.LineStyle = BorderStyle.FixedSingle
        wSheet.Cells.Range("A1:M1").Value = " REPORTE DE EFECTIVIDAD - DEVOLUCIONES CONSUMO"
        wSheet.Cells.Range("A1:M1").Style = "Estilo"

        For c As Integer = 0 To DataConsumo.Columns.Count - 1
            wSheet.Cells(2, c + 1).value = DataConsumo.Columns(c).HeaderText
            wSheet.Cells(2, c + 1).Style = "Estilo"
        Next

        For r As Integer = 0 To DataConsumo.RowCount - 1
            For c As Integer = 0 To DataConsumo.Columns.Count - 1
                wSheet.Cells(r + 3, c + 1).value = DataConsumo.Item(c, r).Value
                wSheet.Cells(r + 3, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet.Cells(r + 3, c + 1).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            Next
        Next

        wSheet.Columns.AutoFit()
        wSheet2.Columns.AutoFit()

        excel.Visible = True
        excel.Quit()

    End Sub

    Private Sub FrmEfectividadDevol_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Empre = _Inicio.Almacen
        Catch ex As Exception

        End Try
    End Sub
End Class