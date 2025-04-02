Imports Disar.data
Public Class frm_Resumen_Costos_dimosa
    Dim conexion As New clsResumen_costos

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        Try

            grd_costos.DataSource = conexion.Resumen_CostosDimosa(cmb_F1.Value.Date, cmb_f2.Value.Date, cmbSucursal.SelectedValue)
            limpiar()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub frm_Resumen_Costos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbSucursal.DataSource = conexion.AlmacenesDIMOSA
        cmbSucursal.DisplayMember = "DESCR"
        cmbSucursal.ValueMember = "CVE_ALM"
        cmbSucursal.SelectedValue = 100
    End Sub

    Private Sub limpiar()
        Dim TotalEntradas As Double = 0
        Dim Totalsalidas As Double = 0

        txtTotalEntradas.Text = "0"
        txtTotalSalidas.Text = "0"
        If grd_costos.Rows.Count > 0 Then
            grd_costos.Columns(0).Visible = False

            For i = 0 To grd_costos.Rows.Count - 1
                If grd_costos.Rows(i).Cells(2).Value = "E" Then
                    TotalEntradas = TotalEntradas + grd_costos.Rows(i).Cells(3).Value
                    grd_costos.Rows(i).Cells(2).Value = "Entrada"
                Else
                    grd_costos.Rows(i).Cells(2).Value = "Salida"
                    Totalsalidas = Totalsalidas + grd_costos.Rows(i).Cells(3).Value
                End If
                txtTotalEntradas.Text = FormatNumber(TotalEntradas, 2)
                txtTotalSalidas.Text = FormatNumber(Totalsalidas, 2)

            Next
        End If


    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Exportar()
    End Sub

    Sub Exportar()
        Try
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            Dim entradas As Integer = 0
            Dim salidas As Integer = 0
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()

            For c As Integer = 0 To grd_costos.Rows.Count - 1
                If grd_costos.Rows(c).Cells(2).Value = "Entrada" Then
                    entradas = entradas + 1
                End If
                If grd_costos.Rows(c).Cells(2).Value = "Salida" Then
                    salidas = salidas + 1
                End If
            Next

            For c As Integer = 0 To grd_costos.Columns.Count - 1

                wSheet.Cells(2, c + 1).value = grd_costos.Columns(c).HeaderText
                wSheet.Cells(2, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
            Next

            For r As Integer = 0 To grd_costos.RowCount - 1
                ' MsgBox("contador" & r)
                For c As Integer = 0 To grd_costos.Columns.Count - 1

                    If grd_costos.Item(2, r).Value = "Entrada" Then
                        wSheet.Cells(r + 3, c + 1).value = grd_costos.Item(c, r).Value
                        wSheet.Cells(r + 3, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                        'MsgBox("entradas" & entradas)
                        If r + 1 = entradas Then

                            wSheet.Cells(r + 4, 2).value = "Total entradas"
                            wSheet.Cells(r + 4, 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                            wSheet.Cells(r + 4, 2).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                            wSheet.Cells(r + 4, 3).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                            wSheet.Cells(r + 4, 4).value = txtTotalEntradas.Text
                            wSheet.Cells(r + 4, 4).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)

                        End If
                    End If
                    If grd_costos.Item(2, r).Value = "Salida" Then
                        wSheet.Cells(r + 4, c + 1).value = grd_costos.Item(c, r).Value
                        wSheet.Cells(r + 4, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                        ' MsgBox("salidas" & salidas + entradas)


                        If r + 1 = entradas + salidas Then
                            wSheet.Cells(r + 5, 2).value = "Total Salidas"
                            wSheet.Cells(r + 5, 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                            wSheet.Cells(r + 5, 2).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                            wSheet.Cells(r + 5, 3).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                            wSheet.Cells(r + 5, 4).value = txtTotalSalidas.Text
                            wSheet.Cells(r + 5, 4).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)

                        End If
                    End If

                Next
            Next
            wSheet.Columns.AutoFit()
            excel.Visible = True
            excel.Quit()
        Catch ex As Exception
            MessageBox.Show("Error al Exportar " + ex.ToString, "Problemas", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


End Class