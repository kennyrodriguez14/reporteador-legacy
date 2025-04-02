Imports Disar.data
Imports System.Net.Mime.MediaTypeNames

Public Class frm_detalle_factura
    Dim conexion As New cls_facturacion_creditos
    Private Sub frm_detalle_factura_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            grid_factura.DataSource = conexion.Partidas(txt_num_factura.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        Exportar()
    End Sub

    Sub Exportar()
        Try

            'Dim LibroTrabajo As Object
            'Dim Fichero As String

            'Fichero = "Escritorio\formato_factura.xlsx" 'con el path correspondiente 
            'LibroTrabajo = GetObject(Fichero)
            'LibroTrabajo.Application.Windows("formato_factura.xlsx").Visible = True




            'Dim XL As New Application 'Crea el objeto excel 
            'XL.Workbooks.Open("c:\subir_datos_excel.xls", , True) 'El true es para abrir el archivo en modo Solo lectura (False si lo quieres de otro modo) 
            'XL.Visible = True
            'XL.WindowState = xlMaximized 'Para que la ventana aparezca maximizada. 

            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            'Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet

            excel.Workbooks.Open("C:\Reportes\formato_factura.xlsx")
            'wBook = excel.Workbooks.Add()
            wSheet = excel.Sheets("Sheet1")


            wSheet.Cells.Range("C6:I6").Merge()
            wSheet.Cells.Range("C6:I6").Value = lbl_codigo.Text + " " + lbl_clientes.Text
            wSheet.Cells.Range("M3:M3").Value = txt_num_factura.Text
            wSheet.Cells.Range("M6:M6").Value = txtfecha.Text
            wSheet.Cells.Range("L11:L11").Value = txt_cve_vend.Text


            For r As Integer = 0 To grid_factura.RowCount - 1
                For c As Integer = 0 To grid_factura.Columns.Count - 1

                    If c = 0 Then
                        wSheet.Cells.Range("B" & r + 13 & ":" & "B" & r + 13).Value = grid_factura.Item(c, r).Value
                    End If

                    If c = 1 Then
                        wSheet.Cells.Range("C" & r + 13 & ":" & "C" & r + 13).Value = grid_factura.Item(c, r).Value
                    End If

                    If c = 2 Then
                        wSheet.Cells.Range("D" & r + 13 & ":" & "H" & r + 13).Merge()
                        wSheet.Cells.Range("D" & r + 13 & ":" & "H" & r + 13).Value = grid_factura.Item(c, r).Value
                        'wSheet.Cells.Range("D" & r + 13 & ":" & "H" & c + 5).Merge()
                        'wSheet.Cells.Range("D" & r + 13 & ":" & "H" & c + 5).Value = grid_factura.Item(c, r).Value

                        'wSheet.Cells(r + 13, c + 5).value = grid_factura.Item(c, r).Value
                        'wSheet.Cells(r + 13, c + 2).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    End If

                    If c = 3 Then
                        wSheet.Cells.Range("I" & r + 13 & ":" & "I" & r + 13).Value = grid_factura.Item(c, r).Value
                    End If
                    If c = 4 Then
                        wSheet.Cells.Range("J" & r + 13 & ":" & "J" & r + 13).Value = grid_factura.Item(c, r).Value
                    End If

                    If c = 5 Then
                        wSheet.Cells.Range("L" & r + 13 & ":" & "L" & r + 13).Value = grid_factura.Item(c, r).Value
                    End If

                    If c = 6 Then
                        wSheet.Cells.Range("M" & r + 13 & ":" & "M" & r + 13).Value = grid_factura.Item(c, r).Value
                    End If

                    If c = 7 Then
                        wSheet.Cells.Range("N" & r + 13 & ":" & "N" & r + 13).Value = grid_factura.Item(c, r).Value
                    End If
                Next
            Next
            Try

                Dim valor As Double
                valor = Math.Truncate(Val(txttotal.Text))
                wSheet.Cells.Range("B41:B41").Value = Num2Text(valor)
            Catch ex As Exception
            End Try

            wSheet.Cells.Range("N44:N44").Value = FormatCurrency(txtsubtotal.Text, 2)
            wSheet.Cells.Range("N45:N45").Value = FormatCurrency(txtdescuento.Text, 2)
            wSheet.Cells.Range("N46:N46").Value = FormatCurrency(txtisv.Text, 2)
            wSheet.Cells.Range("N47:N47").Value = FormatCurrency(txttotal.Text, 2)

            excel.Visible = True
            excel.WindowState = Microsoft.Office.Interop.Excel.XlWindowState.xlMaximized

            ''wSheet.Cells.Range("A1:G1").Value = "KM/G por Vehiculo del " + Inicio.Value.Date + " al " + Fin.Value.Date
            ''wSheet.Cells.Range("A1:G1").Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            ''wSheet.Cells.Range("A1:G1").Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            ''wSheet.Cells.Range("A1:G1").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            ''wSheet.Cells.Range("A1:G1").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            ''wSheet.Cells.Range("A1:G1").Font.Bold = True
            ''For c As Integer = 0 To grid_factura.Columns.Count - 1
            ''    wSheet.Cells(13, c + 1).value = grid_factura.Columns(c).HeaderText
            ''    wSheet.Cells(2, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
            ''    wSheet.Cells(2, c + 1).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            ''    wSheet.Cells(2, c + 1).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            ''Next
            
            'wSheet.Columns.AutoFit()
            'excel.Visible = True
            'excel.Quit()
        Catch ex As Exception
            MessageBox.Show("Error al Exportar " + ex.ToString, "Problemas", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Function Num2Text(ByVal value As Double) As String
        Try
            Select Case value
                Case 0 : Num2Text = "CERO"
                Case 1 : Num2Text = "UN"
                Case 2 : Num2Text = "DOS"
                Case 3 : Num2Text = "TRES"
                Case 4 : Num2Text = "CUATRO"
                Case 5 : Num2Text = "CINCO"
                Case 6 : Num2Text = "SEIS"
                Case 7 : Num2Text = "SIETE"
                Case 8 : Num2Text = "OCHO"
                Case 9 : Num2Text = "NUEVE"
                Case 10 : Num2Text = "DIEZ"
                Case 11 : Num2Text = "ONCE"
                Case 12 : Num2Text = "DOCE"
                Case 13 : Num2Text = "TRECE"
                Case 14 : Num2Text = "CATORCE"
                Case 15 : Num2Text = "QUINCE"
                Case Is < 20 : Num2Text = "DIECI" & Num2Text(value - 10)
                Case 20 : Num2Text = "VEINTE"
                Case Is < 30 : Num2Text = "VEINTI" & Num2Text(value - 20)
                Case 30 : Num2Text = "TREINTA"
                Case 40 : Num2Text = "CUARENTA"
                Case 50 : Num2Text = "CINCUENTA"
                Case 60 : Num2Text = "SESENTA"
                Case 70 : Num2Text = "SETENTA"
                Case 80 : Num2Text = "OCHENTA"
                Case 90 : Num2Text = "NOVENTA"
                Case Is < 100 : Num2Text = Num2Text(Int(value \ 10) * 10) & " Y " & Num2Text(value Mod 10)
                Case 100 : Num2Text = "CIEN"
                Case Is < 200 : Num2Text = "CIENTO " & Num2Text(value - 100)
                Case 200, 300, 400, 600, 800 : Num2Text = Num2Text(Int(value \ 100)) & "CIENTOS"
                Case 500 : Num2Text = "QUINIENTOS"
                Case 700 : Num2Text = "SETECIENTOS"
                Case 900 : Num2Text = "NOVECIENTOS"
                Case Is < 1000 : Num2Text = Num2Text(Int(value \ 100) * 100) & " " & Num2Text(value Mod 100)
                Case 1000 : Num2Text = "MIL"
                Case Is < 2000 : Num2Text = "MIL " & Num2Text(value Mod 1000)
                Case Is < 1000000 : Num2Text = Num2Text(Int(value \ 1000)) & " MIL"
                    If value Mod 1000 Then Num2Text = Num2Text & " " & Num2Text(value Mod 1000)
                Case 1000000 : Num2Text = "UN MILLON"
                Case Is < 2000000 : Num2Text = "UN MILLON " & Num2Text(value Mod 1000000)
                Case Is < 1000000000000.0# : Num2Text = Num2Text(Int(value / 1000000)) & " MILLONES "
                    If (value - Int(value / 1000000) * 1000000) Then Num2Text = Num2Text & " " & Num2Text(value - Int(value / 1000000) * 1000000)
                Case 1000000000000.0# : Num2Text = "UN BILLON"
                Case Is < 2000000000000.0# : Num2Text = "UN BILLON " & Num2Text(value - Int(value / 1000000000000.0#) * 1000000000000.0#)
                Case Else : Num2Text = Num2Text(Int(value / 1000000000000.0#)) & " BILLONES"
                    If (value - Int(value / 1000000000000.0#) * 1000000000000.0#) Then Num2Text = Num2Text & " " & Num2Text(value - Int(value / 1000000000000.0#) * 1000000000000.0#)
            End Select
        Catch ex As Exception
            Return ""
        End Try
    End Function
End Class