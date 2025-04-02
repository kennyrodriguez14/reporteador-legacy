Imports Disar.data

Public Class Frm_Efectividad

    Dim style As Microsoft.Office.Interop.Excel.Style
    Public Empr As Integer
    Private Sub ComboEd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboEd.SelectedIndexChanged
        ComboSucursal.SelectedIndex = 0
        If ComboEd.Text = "Entregador" Then
            Label2.Visible = True
            ComboFiltro.Visible = True
            Try
                Dim db As New ClsEfectividad
                ComboFiltro.DataSource = db.Entregadores(Empr, "SAN RAFAEL")
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
                    ComboFiltro.DataSource = db.Entregadores(Empr, "SAN RAFAEL")
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
                    DataConsumo.DataSource = db.Reporte(DateDesde.Value, DateHasta.Value, "SUC-CONSUMO", "")
                    DataAgro.DataSource = db.Reporte(DateDesde.Value, DateHasta.Value, "SUC-AGRO", "")
                    DataRemisiones.DataSource = db.Reporte(DateDesde.Value, DateHasta.Value, "SUC-REMISIONES", "")
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
                    DataConsumo.DataSource = db.Reporte(DateDesde.Value, DateHasta.Value, "SUC-CONSUMO-XALMACEN", Numero)
                    DataRemisiones.DataSource = db.Reporte(DateDesde.Value, DateHasta.Value, "SUC-REMISIONESXALMACEN", Numero)
                    If Numero = 2 Then
                        DataAgro.DataSource = db.Reporte(DateDesde.Value, DateHasta.Value, "SUC-AGRO-XALMACEN", Numero)
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
                DataConsumo.DataSource = db.Reporte(DateDesde.Value, DateHasta.Value, "ENT-CONSUMO", ComboFiltro.SelectedValue)
                DataAgro.DataSource = db.Reporte(DateDesde.Value, DateHasta.Value, "ENT-AGRO", ComboFiltro.SelectedValue)
                DataRemisiones.DataSource = db.Reporte(DateDesde.Value, DateHasta.Value, "ENT-REMISIONES", ComboFiltro.SelectedValue)
            Catch ex As Exception
            End Try
        ElseIf ComboEd.Text = "Vehículo" Then
            Try
                DataAgro.DataSource = Nothing
            Catch ex As Exception
            End Try
            Try
                DataConsumo.DataSource = db.Reporte(DateDesde.Value, DateHasta.Value, "VE-CONSUMO", ComboFiltro.SelectedValue)
                DataAgro.DataSource = db.Reporte(DateDesde.Value, DateHasta.Value, "VE-AGRO", ComboFiltro.SelectedValue)
                DataRemisiones.DataSource = db.Reporte(DateDesde.Value, DateHasta.Value, "VE-REMISIONES", ComboFiltro.SelectedValue)
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
        Dim wBook As Microsoft.Office.Interop.Excel.Workbook
        Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
        Dim wSheet2 As Microsoft.Office.Interop.Excel.Worksheet
        Dim wSheet3 As Microsoft.Office.Interop.Excel.Worksheet

        wBook = excel.Workbooks.Add()

        'CONSUMO
        wSheet3 = wBook.ActiveSheet()
        wSheet3.Name = "REMISIONES"

        style = wSheet3.Application.ActiveWorkbook.Styles.Add("Estilo")
        style.Font.Bold = True
        style.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
        style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.SteelBlue)
        style.Font.Size = 11
        style.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
        style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

        'REMISIONES
        wSheet3.Cells.Range("A1:K1").Merge()
        wSheet3.Cells.Range("A1:K1").Borders.LineStyle = BorderStyle.FixedSingle
        wSheet3.Cells.Range("A1:K1").Value = " REPORTE DE EFECTIVIDAD - REMISIONES"
        wSheet3.Cells.Range("A1:K1").Style = "Estilo"

        For c As Integer = 0 To DataRemisiones.Columns.Count - 1
            wSheet3.Cells(2, c + 1).value = DataRemisiones.Columns(c).HeaderText
            wSheet3.Cells(2, c + 1).Style = "Estilo"
        Next

        For r As Integer = 0 To DataRemisiones.RowCount - 1
            For c As Integer = 0 To DataRemisiones.Columns.Count - 1
                wSheet3.Cells(r + 3, c + 1).value = DataRemisiones.Item(c, r).Value
                wSheet3.Cells(r + 3, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet3.Cells(r + 3, c + 1).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            Next
        Next

        'AGRO
        wSheet2 = wBook.ActiveSheet()
        wSheet2 = wBook.Sheets.Add()
        wSheet2.Name = "AGRO"

        wSheet2.Cells.Range("A1:M1").Merge()
        wSheet2.Cells.Range("A1:M1").Borders.LineStyle = BorderStyle.FixedSingle
        wSheet2.Cells.Range("A1:M1").Value = " REPORTE DE EFECTIVIDAD - FACTURAS SR AGRO"
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
        wSheet.Cells.Range("A1:M1").Value = " REPORTE DE EFECTIVIDAD - FACTURAS CONSUMO"
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
        wSheet3.Columns.AutoFit()
        excel.Visible = True
        excel.Quit()

    End Sub

    Private Sub Frm_Efectividad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Empr = _Inicio.Almacen
        Catch ex As Exception
        End Try
    End Sub
End Class