Imports Disar.data

Public Class FrmBitacoraEventos

    Dim style As Microsoft.Office.Interop.Excel.Style

    Private Sub FrmBitacoraEventos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim conexion_bita As New cls_bitacora_reporteador
            conexion_bita.RegistraBitacora(Now, _Inicio.lblUsuario.Text, "Ingresó a Bitácora Electrónica de Eventos", "REPORTES", _
                                      "Fecha: " & DateTime.Now)
        Catch ex As Exception
        End Try
        LlenaVehiculos()
        LlenaCategorias()
    End Sub

    Sub LlenaVehiculos()
        Dim db As New ClsBitacoraEventos
        ComboVehiculo.DataSource = db.MuestraTodosVehiculos
        ComboVehiculo.DisplayMember = "VehiculoDescripcion"
        ComboVehiculo.ValueMember = "VehiculoID"
    End Sub

    Sub LlenaCategorias()
        Dim db As New ClsBitacoraEventos
        ComboCategoria.DataSource = db.MuestraTodasCategorias
        ComboCategoria.DisplayMember = "BECat_Desc"
        ComboCategoria.ValueMember = "BECat_ID"
    End Sub

    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        If FrmRegistroEvento.Visible = True Then
            FrmRegistroEvento.BringToFront()
        Else
            'FrmRegistroEvento.MdiParent = _Inicio
            FrmRegistroEvento.ShowDialog()
        End If
    End Sub

    Private Sub BtnFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFiltrar.Click
        Dim db As New ClsBitacoraEventos

        If ComboCategoria.SelectedValue = 0 Then

            If ComboVehiculo.SelectedValue = 0 Then
                Try
                    DataGridView1.DataSource = db.MuestraTodosEventos(DateTimePicker1.Value, DateTimePicker2.Value)
                Catch ex As Exception
                End Try
            Else
                Try
                    DataGridView1.DataSource = db.MuestraEventosVehiculo(ComboVehiculo.SelectedValue, DateTimePicker1.Value, DateTimePicker2.Value)
                Catch ex As Exception
                End Try
            End If
        Else
            If ComboVehiculo.SelectedValue = 0 Then
                Try
                    DataGridView1.DataSource = db.MuestraEventosCategoria(ComboCategoria.SelectedValue, DateTimePicker1.Value, DateTimePicker2.Value)
                Catch ex As Exception
                End Try
            Else
                Try
                    DataGridView1.DataSource = db.MuestraEventosVehiculoCat(ComboVehiculo.SelectedValue, ComboCategoria.SelectedValue, DateTimePicker1.Value, DateTimePicker2.Value)
                Catch ex As Exception
                End Try
            End If
        End If
        Try
            DataGridView1.Columns(1).Visible = False
            DataGridView1.Columns(3).Visible = False
            'DataGridView1.Columns(7).Visible = False

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExportar.Click
        If DataGridView1.RowCount > 0 Then
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

            For c As Integer = 0 To DataGridView1.Columns.Count - 1
                If DataGridView1.Columns(c).Visible = True Then
                    wSheet.Cells(2, c + 1).value = DataGridView1.Columns(c).HeaderText
                    wSheet.Cells(2, c + 1).Style = "Estilo"
                End If
            Next
            For r As Integer = 0 To DataGridView1.RowCount - 1
                For c As Integer = 0 To DataGridView1.Columns.Count - 1
                    If DataGridView1.Columns(c).Visible = True Then
                        wSheet.Cells(r + 3, c + 1).value = DataGridView1.Item(c, r).Value
                        wSheet.Cells(r + 3, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                        wSheet.Cells(r + 3, c + 1).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                        wSheet.Cells(r + 3, c + 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                        If DataGridView1.Rows(r).Cells(1).Value = "" Then
                            wSheet.Cells(r + 3, 2).Value = "-"
                            wSheet.Cells(r + 3, c + 1).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Beige)
                            'wSheet.Cells(r + 3, c + 1).Interior.Color = System.Drawing.ColorTranslator.ToOle(DataDatos.Rows(r).DefaultCellStyle.BackColor)
                        End If
                    End If
                Next
            Next


            wSheet.Cells.Range("A1:F1").Merge()
            wSheet.Cells.Range("A1:F1").Borders.LineStyle = BorderStyle.FixedSingle
            wSheet.Cells.Range("A1:F1").Value = " Bitácora Electrónica de Eventos "
            wSheet.Cells.Range("A1:F1").Style = "Estilo"

            wSheet.Columns.AutoFit()
            excel.Visible = True
            excel.Quit()
        End If
    End Sub

End Class