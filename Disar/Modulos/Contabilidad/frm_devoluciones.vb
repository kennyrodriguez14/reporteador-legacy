Imports Disar.data

Public Class frm_devoluciones
    Dim conexion As New cls_descuentos_tacticos
    Private Sub frm_devoluciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_empresa()
        cargar_almacen()
        cargar_serie()
    End Sub

    Sub cargar_almacen()
        Try
            cmb_almacen.DataSource = conexion.reporte_devoluciones_almacen("ALMACEN", cmb_empresa.SelectedValue)
            cmb_almacen.ValueMember = "ID"
            cmb_almacen.DisplayMember = "ALMACEN"
        Catch ex As Exception

        End Try
    End Sub

    Sub cargar_empresa()
        cmb_empresa.DataSource = conexion.reporte_devoluciones_empresa("EMPRESA")
        cmb_empresa.ValueMember = "CODIGO"
        cmb_empresa.DisplayMember = "EMPRESA"
    End Sub

    Sub cargar_serie()
        Try
            txt_folio.Text = conexion.reporte_devoluciones_serie(cmb_almacen.SelectedValue, "SERIE", cmb_empresa.SelectedValue).Rows(0)(0)
        Catch ex As Exception
            txt_folio.Text = ""
        End Try
    End Sub

    Sub exportar()
        Try
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()

            Dim style As Microsoft.Office.Interop.Excel.Style
            style = wSheet.Application.ActiveWorkbook.Styles.Add("NewStyle")
            style.Font.Bold = True
            style.Font.Size = 11
            style.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            wSheet.Cells.Range("A1:M1").Merge()
            wSheet.Cells.Range("A1:M1").Value = "Distribuidora San Rafael, S. de R. L. de C. V. (SAN RAFAEL)"
            wSheet.Cells.Range("A1:M1").Style = "NewStyle"
            'wSheet.Cells.Range("A1:I1").Borders.LineStyle = BorderStyle.FixedSingle

            wSheet.Cells.Range("A2:M2").Merge()
            wSheet.Cells.Range("A2:M2").Value = "Telefono: 2509-0007"
            wSheet.Cells.Range("A2:M2").Style = "NewStyle"
            'wSheet.Cells.Range("A2:I2").Borders.LineStyle = BorderStyle.FixedSingle

            wSheet.Cells.Range("A3:M3").Merge()
            wSheet.Cells.Range("A3:M3").Value = "info@disarhn.com"
            wSheet.Cells.Range("A3:M3").Style = "NewStyle"
            'wSheet.Cells.Range("A3:I3").Borders.LineStyle = BorderStyle.FixedSingle

            wSheet.Cells.Range("A4:M4").Merge()
            wSheet.Cells.Range("A4:M4").Value = "RTN: 05019017934322"
            wSheet.Cells.Range("A4:M4").Style = "NewStyle"
            'wSheet.Cells.Range("A4:I4").Borders.LineStyle = BorderStyle.FixedSingle

            wSheet.Cells.Range("A5:M5").Merge()
            wSheet.Cells.Range("A5:M5").Value = "Reporte de Devoluciones fecha: " + cmb_fecha.Value.Date
            wSheet.Cells.Range("A5:M5").Style = "NewStyle"
            'wSheet.Cells.Range("A5:I5").Borders.LineStyle = BorderStyle.FixedSingle


            For c As Integer = 0 To grd_lista.Columns.Count - 1
                wSheet.Cells(7, c + 1).value = grd_lista.Columns(c).HeaderText
                wSheet.Cells(7, c + 1).Borders.LineStyle = BorderStyle.FixedSingle
                wSheet.Cells(7, c + 1).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                wSheet.Cells(7, c + 1).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                wSheet.Cells(7, c + 1).Font.Bold = True
                wSheet.Cells(7, c + 1).Font.Size = 11
            Next
            For r As Integer = 0 To grd_lista.RowCount - 1
                For c As Integer = 0 To grd_lista.Columns.Count - 1
                    wSheet.Cells(r + 8, c + 1).value = grd_lista.Item(c, r).Value
                    wSheet.Cells(r + 8, c + 1).Borders.LineStyle = BorderStyle.FixedSingle
                Next
            Next
            Dim indice As Integer = 0
            indice = grd_lista.RowCount + 8
            wSheet.Cells.Range("A" + indice.ToString + ":J" + indice.ToString).Merge()
            wSheet.Cells.Range("A" + indice.ToString + ":J" + indice.ToString).Value = "TOTAL DEVOLUCIONES DEL DIA " + cmb_fecha.Value.Date
            wSheet.Cells.Range("A" + indice.ToString + ":J" + indice.ToString).Style = "NewStyle"
            wSheet.Cells.Range("A" + indice.ToString + ":J" + indice.ToString).Borders.LineStyle = BorderStyle.FixedSingle

            Dim subtotal As Double = 0, isv As Double = 0, total As Double = 0
            For index As Integer = 0 To grd_lista.Rows.Count - 1
                subtotal += grd_lista.Rows(index).Cells("Sub Total").Value
                isv += grd_lista.Rows(index).Cells("Impuesto").Value
                total += grd_lista.Rows(index).Cells("Total DV").Value
            Next

            wSheet.Cells.Range("K" + indice.ToString).Merge()

            wSheet.Cells.Range("K" + indice.ToString).Value = subtotal.ToString("N2")
            wSheet.Cells.Range("K" + indice.ToString).Style = "NewStyle"
            wSheet.Cells.Range("K" + indice.ToString).Borders.LineStyle = BorderStyle.FixedSingle

            wSheet.Cells.Range("L" + indice.ToString).Merge()
            'wSheet.Cells.Range("H" + indice.ToString).Borders.LineStyle = BorderStyle.FixedSingle
            wSheet.Cells.Range("L" + indice.ToString).Value = isv.ToString("N2")
            wSheet.Cells.Range("L" + indice.ToString).Style = "NewStyle"
            wSheet.Cells.Range("L" + indice.ToString).Borders.LineStyle = BorderStyle.FixedSingle

            wSheet.Cells.Range("M" + indice.ToString).Merge()
            'wSheet.Cells.Range("I" + indice.ToString).Borders.LineStyle = BorderStyle.FixedSingle
            wSheet.Cells.Range("M" + indice.ToString).Value = total.ToString("N2")
            wSheet.Cells.Range("M" + indice.ToString).Style = "NewStyle"
            wSheet.Cells.Range("M" + indice.ToString).Borders.LineStyle = BorderStyle.FixedSingle

            wSheet.Columns.AutoFit()
            excel.Visible = True
            excel.Quit()
        Catch ex As Exception
            MessageBox.Show("Error al Exportar " + ex.ToString, "Problemas", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        Try
            Dim ceros As String = ""
            If txt_inicio.Text.Length < 8 Then
                For index As Integer = 1 To 8 - txt_inicio.Text.Length
                    ceros += "0"
                Next
            End If
            txt_ceros.Text = ceros

            Dim ceros2 As String = ""
            If txt_fin.Text.Length < 8 Then
                For index As Integer = 1 To 8 - txt_fin.Text.Length
                    ceros2 += "0"
                Next
            End If
            txt_ceros2.Text = ceros2
            grd_lista.DataSource = conexion.reporte_devoluciones(txt_folio.Text + txt_ceros.Text + txt_inicio.Text, txt_folio.Text + txt_ceros.Text + txt_fin.Text, _
                                                                cmb_almacen.SelectedValue, "NC_POR_DESC", cmb_empresa.SelectedValue, cmb_fecha.Value)
            grp_filtros.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_exportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar.Click
        exportar()
    End Sub

    Private Sub cmb_empresa_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_empresa.SelectedIndexChanged
        cargar_almacen()
    End Sub

    Private Sub cmb_almacen_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_almacen.SelectedIndexChanged
        cargar_serie()
    End Sub

    Private Sub btn_volver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_volver.Click
        grp_filtros.Enabled = True
    End Sub
End Class