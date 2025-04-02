Imports Disar.data
Public Class frm_nd_credito_sragro
    Dim conexion As New cls_notas_debito_SRAGRO
    Public COMPRA As String
    Public tipo As String
    Public tasa As Double
    Private Sub frm_nd_credito_sragro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar()
    End Sub

    Sub cargar()
        Try
            Dim dt As New DataTable
            dt = conexion.listar_ajuste(COMPRA, "CREDITO")
            txt_codigo_ajuste.Text = dt.Rows(0)(0)
            txt_codigo_proveedor.Text = dt.Rows(0)(1)
            txt_num_almacen.Text = dt.Rows(0)(2)
            txt_ref_proveedor.Text = dt.Rows(0)(3)
            cmb_fecha.Value = dt.Rows(0)(4)
            txt_compra_sae.Text = dt.Rows(0)(5)

            txt_subtotal.Text = dt.Rows(0)(6)
            txt_descuento.Text = dt.Rows(0)(7)
            txt_isv.Text = dt.Rows(0)(8)
            txt_total.Text = Math.Round(Val(txt_subtotal.Text) + Val(txt_isv.Text), 2)
            txt_compra_local.Text = dt.Rows(0)(10)
            grd_lista.DataSource = conexion.listar_ajuste_partidas(dt.Rows(0)(0))

        Catch ex As Exception
            'MessageBox.Show(ex.Message)
            Me.Close()
        End Try
    End Sub

    Sub Exportar()
        Try
            Dim estilo2 As Microsoft.Office.Interop.Excel.Style
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()

            estilo2 = wSheet.Application.ActiveWorkbook.Styles.Add("Estilo2")
            estilo2.Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.Black)
            estilo2.Font.Color = System.Drawing.ColorTranslator.ToOle(Color.White)
            estilo2.Font.Bold = True

            wSheet.Cells.Range("A2:C2").Merge()
            wSheet.Cells.Range("A2:C2").Value = "NOTA DE CREDITO"
            wSheet.Cells.Range("A2:C2").Font.Size = 16
            wSheet.Cells.Range("A2:C2").Font.Bold = True

            wSheet.Cells.Range("A3:C3").Merge()
            wSheet.Cells.Range("A3:C3").Value = "DISTRIBUIDORA SAN RAFAEL"
            wSheet.Cells.Range("A3:C3").Font.Size = 22
            wSheet.Cells.Range("A3:C3").Font.Bold = True

            wSheet.Cells.Range("A4:F4").Merge()
            wSheet.Cells.Range("A4:F4").Value = "PROVEEDOR: " + txt_proveedor.Text
            wSheet.Cells.Range("A4:F4").Font.Size = 8
            wSheet.Cells.Range("A4:F4").Font.Bold = True

            wSheet.Cells.Range("A5:C5").Merge()
            wSheet.Cells.Range("A5:C5").Value = "FECHA: " + cmb_fecha.Value.Date
            wSheet.Cells.Range("A5:C5").Font.Size = 8
            wSheet.Cells.Range("A5:C5").Font.Bold = True

            wSheet.Cells.Range("E5:F5").Merge()
            wSheet.Cells.Range("E5:F5").Value = "NUMERO DE FACTURA: "
            wSheet.Cells.Range("E5:F5").Font.Size = 8
            wSheet.Cells.Range("E5:F5").Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.Black)
            wSheet.Cells.Range("E5:F5").Font.Color = System.Drawing.ColorTranslator.ToOle(Color.White)
            wSheet.Cells.Range("E5:F5").Font.Bold = True

            wSheet.Cells.Range("G5:H5").Merge()
            wSheet.Cells.Range("G5:H5").Value = txt_ref_proveedor.Text
            wSheet.Cells.Range("G5:H5").Font.Size = 8
            wSheet.Cells.Range("G5:H5").Font.Bold = True

            wSheet.Cells(6, 2).value = "CONTACTO:"
            wSheet.Cells(6, 2).Font.Size = 8
            wSheet.Cells(6, 2).Font.Bold = True

            wSheet.Cells.Range("A7:I7").Merge()
            wSheet.Cells.Range("A7:I7").Value = "ESTIMADO PROVEEDOR, A CONTINUACION ESPECIFICAMOS EL MOTIVO Y MONTO POR LA CUAL SE ELABORA LA PRESENTE NOTA DE CREDITO:"
            wSheet.Cells.Range("A7:I7").Font.Size = 8
            wSheet.Cells.Range("A7:I7").Font.Bold = True

            For c As Integer = 0 To grd_lista.Columns.Count - 1
                wSheet.Cells(8, c + 1).value = grd_lista.Columns(c).HeaderText
                wSheet.Cells(8, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet.Cells(8, c + 1).Style = "Estilo2"

            Next
            Dim filas As Integer = 0
            For r As Integer = 0 To grd_lista.RowCount - 1
                For c As Integer = 0 To grd_lista.Columns.Count - 1
                    wSheet.Cells(r + 9, c + 1).value = grd_lista.Item(c, r).Value
                    wSheet.Cells(r + 9, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                Next
                filas = filas + 1
            Next
            filas = filas + 10

            If tipo = "importacion" Then
                wSheet.Cells.Range("G" & filas & ":G" & filas).Merge()
                wSheet.Cells.Range("G" & filas & ":G" & filas).Value = "TOTAL::::::::::"
                wSheet.Cells.Range("G" & filas & ":G" & filas).Font.Size = 8
                wSheet.Cells.Range("G" & filas & ":G" & filas).Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.Black)
                wSheet.Cells.Range("G" & filas & ":G" & filas).Font.Color = System.Drawing.ColorTranslator.ToOle(Color.White)
                wSheet.Cells.Range("G" & filas & ":G" & filas).Font.Bold = True

                wSheet.Cells.Range("H" & filas & ":H" & filas).Merge()
                wSheet.Cells.Range("H" & filas & ":H" & filas).Value = "L. " & txt_subtotal.Text
                wSheet.Cells.Range("H" & filas & ":H" & filas).Font.Size = 8
                wSheet.Cells.Range("H" & filas & ":H" & filas).Font.Bold = True
            Else
                wSheet.Cells.Range("G" & filas & ":G" & filas).Merge()
                wSheet.Cells.Range("G" & filas & ":G" & filas).Value = "SUB TOTAL::::::"
                wSheet.Cells.Range("G" & filas & ":G" & filas).Font.Size = 8
                wSheet.Cells.Range("G" & filas & ":G" & filas).Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.Black)
                wSheet.Cells.Range("G" & filas & ":G" & filas).Font.Color = System.Drawing.ColorTranslator.ToOle(Color.White)
                wSheet.Cells.Range("G" & filas & ":G" & filas).Font.Bold = True

                wSheet.Cells.Range("H" & filas & ":H" & filas).Merge()
                wSheet.Cells.Range("H" & filas & ":H" & filas).Value = "L. " & txt_subtotal.Text
                wSheet.Cells.Range("H" & filas & ":H" & filas).Font.Size = 8
                wSheet.Cells.Range("H" & filas & ":H" & filas).Font.Bold = True

                filas += 1
                'wSheet.Cells.Range("G" & filas & ":G" & filas).Merge()
                'wSheet.Cells.Range("G" & filas & ":G" & filas).Value = "DESCUENTO::::::"
                'wSheet.Cells.Range("G" & filas & ":G" & filas).Font.Size = 8
                'wSheet.Cells.Range("G" & filas & ":G" & filas).Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.Black)
                'wSheet.Cells.Range("G" & filas & ":G" & filas).Font.Color = System.Drawing.ColorTranslator.ToOle(Color.White)
                'wSheet.Cells.Range("G" & filas & ":G" & filas).Font.Bold = True

                'wSheet.Cells.Range("H" & filas & ":H" & filas).Merge()
                'wSheet.Cells.Range("H" & filas & ":H" & filas).Value = "L. " & txt_descuento.Text
                'wSheet.Cells.Range("H" & filas & ":H" & filas).Font.Size = 8
                'wSheet.Cells.Range("H" & filas & ":H" & filas).Font.Bold = True
                'filas += 1
                wSheet.Cells.Range("G" & filas & ":G" & filas).Merge()
                wSheet.Cells.Range("G" & filas & ":G" & filas).Value = "I.S.V::::::::::"
                wSheet.Cells.Range("G" & filas & ":G" & filas).Font.Size = 8
                wSheet.Cells.Range("G" & filas & ":G" & filas).Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.Black)
                wSheet.Cells.Range("G" & filas & ":G" & filas).Font.Color = System.Drawing.ColorTranslator.ToOle(Color.White)
                wSheet.Cells.Range("G" & filas & ":G" & filas).Font.Bold = True

                wSheet.Cells.Range("H" & filas & ":H" & filas).Merge()
                wSheet.Cells.Range("H" & filas & ":H" & filas).Value = "L. " & txt_isv.Text
                wSheet.Cells.Range("H" & filas & ":H" & filas).Font.Size = 8
                wSheet.Cells.Range("H" & filas & ":H" & filas).Font.Bold = True
                filas += 1
                wSheet.Cells.Range("G" & filas & ":G" & filas).Merge()
                wSheet.Cells.Range("G" & filas & ":G" & filas).Value = "TOTAL::::::::::"
                wSheet.Cells.Range("G" & filas & ":G" & filas).Font.Size = 8
                wSheet.Cells.Range("G" & filas & ":G" & filas).Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.Black)
                wSheet.Cells.Range("G" & filas & ":G" & filas).Font.Color = System.Drawing.ColorTranslator.ToOle(Color.White)
                wSheet.Cells.Range("G" & filas & ":G" & filas).Font.Bold = True

                wSheet.Cells.Range("H" & filas & ":H" & filas).Merge()
                wSheet.Cells.Range("H" & filas & ":H" & filas).Value = "L. " & txt_total.Text
                wSheet.Cells.Range("H" & filas & ":H" & filas).Font.Size = 8
                wSheet.Cells.Range("H" & filas & ":H" & filas).Font.Bold = True
            End If

            wSheet.Columns.AutoFit()
            excel.Visible = True
            excel.Quit()
        Catch ex As Exception
            MessageBox.Show("Error al Exportar " + ex.ToString, "Problemas", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btn_exportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar.Click
        Exportar()
    End Sub

    Private Sub ToolStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub
End Class