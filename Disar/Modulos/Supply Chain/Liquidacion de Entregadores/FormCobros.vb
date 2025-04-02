Imports Disar.data

Public Class FormCobros

    Private Sub BtnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGenerar.Click
        Try
            Pendientes.Columns.Clear()
        Catch ex As Exception
        End Try
        Dim Sucursal As String = ""
        If ComboSucursal.Text = "SPS" Then
            Sucursal = "P"
        ElseIf ComboSucursal.Text = "SRC" Then
            Sucursal = "R"
        ElseIf ComboSucursal.Text = "SABA" Then
            Sucursal = "T"
        ElseIf ComboSucursal.Text = "TGU" Then
            Sucursal = "G"
        End If
        Dim db As New ClsClientes

        Pendientes.DataSource = db.CargaCobros(DateCobro.Value, DateTimePicker1.Value, Sucursal, ComboEmpresa.Text)

        Try
            Dim A As New DataGridViewComboBoxColumn
            Dim dbx As New ClsEfectividad
            A.Name = "Entregador"
            A.HeaderText = "Entregador"
            Try
                A.DataSource = dbx.Entregadores(_Inicio.Almacen, ComboEmpresa.Text)
                A.ValueMember = "EntregadorNombre"
                A.DisplayMember = "EntregadorNombre"
            Catch ex2 As Exception
                MsgBox(ex2.Message)
            End Try

            Pendientes.Columns.Add(A)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        For a As Integer = 0 To Pendientes.ColumnCount - 2
            Pendientes.Columns(a).ReadOnly = True
        Next

    End Sub

    Private Sub FormCobros_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            ComboEmpresa.Items.Clear()
            If _Inicio.SANRAFAEL = 1 Then
                ComboEmpresa.Items.Add("SAN RAFAEL")
            End If
            If _Inicio.DIMOSA = 1 Then
                ComboEmpresa.Items.Add("DIMOSA")
            End If
            If _Inicio.AGRO = 1 Then
                ComboEmpresa.Items.Add("SR AGRO")
            End If
            ComboEmpresa.SelectedIndex = 0
        Catch ex As Exception
        End Try


        If _Inicio.Almacen = 1 Then
            ComboSucursal.SelectedItem = "SPS"
            ComboSucursal.Enabled = False
        ElseIf _Inicio.Almacen = 2 Then
            ComboSucursal.SelectedItem = "SRC"
            ComboSucursal.Enabled = False
        ElseIf _Inicio.Almacen = 3 Then
            ComboSucursal.SelectedItem = "SABA"
            ComboSucursal.Enabled = False
        ElseIf _Inicio.Almacen = 4 Then
            ComboSucursal.SelectedItem = "TGU"
            ComboSucursal.Enabled = False
        Else
            ComboSucursal.Enabled = True
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExportar.Click
        Exportar()
    End Sub

    Dim Style As Microsoft.Office.Interop.Excel.Style
    Dim Style2 As Microsoft.Office.Interop.Excel.Style
    Dim Style3 As Microsoft.Office.Interop.Excel.Style
    Dim Style4 As Microsoft.Office.Interop.Excel.Style

    Sub Exportar()
        'Try
        Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
        Dim wBook As Microsoft.Office.Interop.Excel.Workbook
        Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
        Dim wSheet2 As Microsoft.Office.Interop.Excel.Worksheet
        wBook = excel.Workbooks.Add()
        wSheet = wBook.ActiveSheet()
        wSheet.Name = "Todos"

        Style = wSheet.Application.ActiveWorkbook.Styles.Add("Reportes")
        Style.Font.Bold = True
        Style.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
        Style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
        Style.Font.Size = 11
        Style.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
        Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter


        Style2 = wSheet.Application.ActiveWorkbook.Styles.Add("Reportes2")
        Style2.Font.Bold = True
        Style2.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
        Style2.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
        Style2.Font.Size = 12
        Style2.Font.Name = "Agency FB"
        Style2.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
        Style2.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

        Style3 = wSheet.Application.ActiveWorkbook.Styles.Add("Reportes3")
        Style3.Font.Bold = True
        Style3.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)
        Style3.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
        Style3.Font.Size = 9.5
        Style3.Font.Name = "Agency FB"
        Style3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
        Style3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

        Style4 = wSheet.Application.ActiveWorkbook.Styles.Add("Reportes4")
        Style4.Font.Bold = False
        Style4.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
        Style4.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
        Style4.Font.Size = 9.5
        Style4.Font.Name = "Agency FB"


        wSheet.Range("A1:E1").Merge()
        wSheet.Range("A1:E1").Value = "FORMATO DE COBROS: " & ComboSucursal.Text & " - " & DateCobro.Value.Date
        wSheet.Range("A1:E1").Font.Bold = True
        wSheet.Range("A1:E1").Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
        wSheet.Range("A1:E1").Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
        wSheet.Range("A1:E1").Font.Size = 11
        wSheet.Range("A1:E1").Style = Style


        For c As Integer = 0 To Pendientes.Columns.Count - 1
            If c = 0 Or c = 1 Or c = 2 Or c = 3 Or c = 8 Then
                If c <> 8 Then
                    wSheet.Cells(2, c + 1).value = Pendientes.Columns(c).HeaderText
                    wSheet.Cells(2, c + 1).Style = "Reportes"
                Else
                    wSheet.Cells(2, 5).value = Pendientes.Columns(c).HeaderText
                    wSheet.Cells(2, 5).Style = "Reportes"
                End If

            End If
        Next

        For r As Integer = 0 To Pendientes.RowCount - 1
            For c As Integer = 0 To Pendientes.Columns.Count - 1
                If c = 0 Or c = 1 Or c = 2 Or c = 3 Or c = 8 Then
                    If c <> 8 Then
                        wSheet.Cells(r + 3, c + 1).value = Pendientes.Item(c, r).Value
                        wSheet.Cells(r + 3, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    Else
                        wSheet.Cells(r + 3, 5).value = Pendientes.Item(c, r).Value
                        wSheet.Cells(r + 3, 5).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    End If

                End If
            Next
        Next
        wSheet.Columns.AutoFit()



        wSheet2 = wBook.Sheets.Add()
        wSheet2.Name = "Detalle"



        Dim dtEntregadores As New DataTable
        dtEntregadores.Columns.Add("NOMBRE")
        dtEntregadores.Columns.Add("RUTA")


        Dim db As New ClsEfectividad
        Dim dt As New DataTable

        For Each row As DataGridViewRow In Pendientes.Rows
            Dim Ruta As String = ""

            If dtEntregadores.Rows.Count = 0 Then
                Try
                    dt = db.RutaDeFactura(row.Cells("FACTURA").Value)
                    Ruta = dt(0)(0)
                Catch ex As Exception
                End Try
                dtEntregadores.Rows.Add(row.Cells("Entregador").Value, Ruta)
            End If

            Dim Prueba As Integer = 0
            For a As Integer = 0 To dtEntregadores.Rows.Count - 1
                Prueba = 0
                If row.Cells("Entregador").Value = dtEntregadores(a)(0) Then
                    Prueba = 1
                End If
            Next

            Try
                If Prueba = 0 Then
                    dt = db.RutaDeFactura(row.Cells("FACTURA").Value)
                    Ruta = dt(0)(0)
                    dtEntregadores.Rows.Add(row.Cells("Entregador").Value, Ruta)
                End If
            Catch ex As Exception
            End Try

        Next

        Dim Fila As Integer = 0

        For a As Integer = 0 To dtEntregadores.Rows.Count - 1

            Fila += 1

            wSheet2.Range("A" & Fila & ":" & "E" & Fila).Merge()
            wSheet2.Range("A" & Fila & ":" & "E" & Fila).Value = "Fecha: " & DateCobro.Value.Date
            wSheet2.Range("A" & Fila & ":" & "E" & Fila).Style = Style2

            Fila += 1

            wSheet2.Range("A" & Fila & ":" & "E" & Fila).Merge()
            wSheet2.Range("A" & Fila & ":" & "E" & Fila).Value = "Ruta: " & dtEntregadores(a)(1)
            wSheet2.Range("A" & Fila & ":" & "E" & Fila).Style = Style2

            Fila += 1

            wSheet2.Range("A" & Fila & ":" & "E" & Fila).Merge()
            wSheet2.Range("A" & Fila & ":" & "E" & Fila).Value = "Entregador: " & dtEntregadores(a)(0)
            wSheet2.Range("A" & Fila & ":" & "E" & Fila).Style = Style2

            Fila += 1


            For c As Integer = 0 To Pendientes.Columns.Count - 1
                If c = 0 Or c = 1 Or c = 2 Or c = 8 Then
                    If c <> 8 Then
                        wSheet2.Cells(Fila, c + 1).value = Pendientes.Columns(c).HeaderText
                        wSheet2.Cells(Fila, c + 1).Style = "Reportes"
                    Else
                        wSheet2.Cells(Fila, 4).value = Pendientes.Columns(c).HeaderText
                        wSheet2.Cells(Fila, 4).Style = "Reportes"
                    End If
                End If
            Next
            wSheet2.Cells(Fila, 5).value = "Firma / Cliente"
            wSheet2.Cells(Fila, 5).Style = "Reportes"

            Fila += 1

            Dim Total As Decimal
            Total = 0


            For r As Integer = 0 To Pendientes.RowCount - 1
                Dim SiguienteFila As Boolean = False
                For c As Integer = 0 To Pendientes.Columns.Count - 1

                    If Pendientes.Rows(r).Cells("Entregador").Value = dtEntregadores.Rows(a)(0) Then

                        If c = 0 Or c = 1 Or c = 2 Or c = 8 Then
                            If c <> 8 Then
                                wSheet2.Cells(Fila, c + 1).value = Pendientes.Item(c, r).Value
                                wSheet2.Cells(Fila, c + 1).style = "Reportes4"
                                wSheet2.Cells(Fila, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)

                            Else
                                wSheet2.Cells(Fila, 4).value = Pendientes.Item(c, r).Value
                                wSheet2.Cells(Fila, 4).style = "Reportes4"
                                wSheet2.Cells(Fila, 4).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                                Total = Total + Pendientes.Rows(r).Cells(8).Value
                                wSheet2.Cells(Fila, 4).NumberFormat = "L. #,##0.00"
                            End If
                        End If

                        'MsgBox("Total : " & Total & vbNewLine & "Nuevo: " & Pendientes.Rows(r).Cells(8).Value)
                        SiguienteFila = True
                    End If

                Next
                If SiguienteFila = True Then
                    wSheet2.Cells(Fila, 5).value = " "
                    wSheet2.Cells(Fila, 5).style = "Reportes4"
                    wSheet2.Cells(Fila, 5).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    Fila += 1
                End If


            Next
            wSheet2.Cells(Fila, 3).value = "TOTAL"
            wSheet2.Cells(Fila, 4).value = Total
            wSheet2.Cells(Fila, 4).NumberFormat = "L. #,##0.00"
            wSheet2.Cells(Fila, 4).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
            Fila += 1

            wSheet2.Range("A" & Fila & ":" & "E" & Fila).Merge()
            wSheet2.Range("A" & Fila & ":" & "E" & Fila).Value = "Favor no recibir cheques postfechados"
            wSheet2.Range("A" & Fila & ":" & "E" & Fila).Style = Style3

            Fila += 1

            wSheet2.Range("A" & Fila & ":" & "E" & Fila).Merge()
            wSheet2.Range("A" & Fila & ":" & "E" & Fila).Value = "_______________________________"
            wSheet2.Range("A" & Fila & ":" & "E" & Fila).Style = Style2

            Fila += 1

            wSheet2.Range("A" & Fila & ":" & "E" & Fila).Merge()
            wSheet2.Range("A" & Fila & ":" & "E" & Fila).Value = "Firma Entregador"
            wSheet2.Range("A" & Fila & ":" & "E" & Fila).Style = Style2

            Fila += 1

        Next
        wSheet2.Columns.AutoFit()
        excel.Visible = True
        excel.Quit()
        'Catch ex As Exception
        '    MessageBox.Show("Error al Exportar " + ex.ToString, "Problemas", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try

    End Sub


    Private Sub Pendientes_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Pendientes.CellClick
        Try

            If e.ColumnIndex = 9 Then  ' <<<< Aquí pones el nº de columna del Combo
                Pendientes.BeginEdit(False)
                If Not IsNothing(Pendientes.EditingControl) Then

                    Dim cmb As ComboBox = Pendientes.EditingControl
                    cmb.DroppedDown = True

                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DateCobro_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateCobro.ValueChanged
        DateTimePicker1.Value = DateCobro.Value

    End Sub
End Class