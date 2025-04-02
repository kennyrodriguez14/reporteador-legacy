Imports System.IO
Imports Disar.data
Public Class Rentabilidad_por_Producto
    Dim Conexion As New cls_rentabilidad
    Dim Style As Microsoft.Office.Interop.Excel.Style

    Private Sub Rentabilidad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        _cmbSucursal.SelectedItem = "SRC"
    End Sub

    Private Sub _btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnGenerar.Click
        Cargar()
    End Sub

    Sub Cargar()
        Try
            If _cmbSucursal.SelectedItem = "SRC" Then
                If cmbvendedor.SelectedValue = "TODOS" Then
                    If cmbproveedor.SelectedValue = "TODOS" Then
                        _GridRentabilidad.DataSource = Conexion.GenerarResumen(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, "CONSUMO_PRODUCTOS", 1, "TODOS", "1", 2)
                    Else
                        _GridRentabilidad.DataSource = Conexion.GenerarResumen(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, "CONSUMO_PRODUCTOS", 1, "PROVEEDOR", cmbproveedor.SelectedValue, 2)
                    End If
                Else
                    If cmbproveedor.SelectedValue = "TODOS" Then
                        _GridRentabilidad.DataSource = Conexion.GenerarResumen(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, "CONSUMO_PRODUCTOS", cmbvendedor.SelectedValue, "VENDEDOR", "1", 2)
                    Else
                        _GridRentabilidad.DataSource = Conexion.GenerarResumen(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, "CONSUMO_PRODUCTOS", cmbvendedor.SelectedValue, "AMBOS", cmbproveedor.SelectedValue, 2)
                    End If
                End If
            End If

            'If _cmbSucursal.SelectedItem = "MOVIL SRC 3" Then
            '    If cmbvendedor.SelectedValue = "TODOS" Then
            '        If cmbproveedor.SelectedValue = "TODOS" Then
            '            _GridRentabilidad.DataSource = Conexion.GenerarResumen(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, "CONSUMO_PRODUCTOS", 1, "TODOS", "1", 3)
            '        Else
            '            _GridRentabilidad.DataSource = Conexion.GenerarResumen(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, "CONSUMO_PRODUCTOS", 1, "PROVEEDOR", cmbproveedor.SelectedValue, 3)
            '        End If
            '    Else
            '        If cmbproveedor.SelectedValue = "TODOS" Then
            '            _GridRentabilidad.DataSource = Conexion.GenerarResumen(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, "CONSUMO_PRODUCTOS", cmbvendedor.SelectedValue, "VENDEDOR", "1", 3)
            '        Else
            '            _GridRentabilidad.DataSource = Conexion.GenerarResumen(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, "CONSUMO_PRODUCTOS", cmbvendedor.SelectedValue, "AMBOS", cmbproveedor.SelectedValue, 3)
            '        End If
            '    End If
            'End If

            If _cmbSucursal.SelectedItem = "SPS" Then
                If cmbvendedor.SelectedValue = "TODOS" Then
                    If cmbproveedor.SelectedValue = "TODOS" Then
                        _GridRentabilidad.DataSource = Conexion.GenerarResumen(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, "CONSUMO_PRODUCTOS", 1, "TODOS", "1", 1)
                    Else
                        _GridRentabilidad.DataSource = Conexion.GenerarResumen(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, "CONSUMO_PRODUCTOS", 1, "PROVEEDOR", cmbproveedor.SelectedValue, 1)
                    End If
                Else
                    If cmbproveedor.SelectedValue = "TODOS" Then
                        _GridRentabilidad.DataSource = Conexion.GenerarResumen(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, "CONSUMO_PRODUCTOS", cmbvendedor.SelectedValue, "VENDEDOR", "1", 1)
                    Else
                        _GridRentabilidad.DataSource = Conexion.GenerarResumen(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, "CONSUMO_PRODUCTOS", cmbvendedor.SelectedValue, "AMBOS", cmbproveedor.SelectedValue, 1)
                    End If
                End If
            End If

            If _cmbSucursal.SelectedItem = "Tocoa" Then
                If cmbvendedor.SelectedValue = "TODOS" Then
                    If cmbproveedor.SelectedValue = "TODOS" Then
                        _GridRentabilidad.DataSource = Conexion.GenerarResumen(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, "CONSUMO_PRODUCTOS", 1, "TODOS", "1", 3)
                    Else
                        _GridRentabilidad.DataSource = Conexion.GenerarResumen(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, "CONSUMO_PRODUCTOS", 1, "PROVEEDOR", cmbproveedor.SelectedValue, 3)
                    End If
                Else
                    If cmbproveedor.SelectedValue = "TODOS" Then
                        _GridRentabilidad.DataSource = Conexion.GenerarResumen(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, "CONSUMO_PRODUCTOS", cmbvendedor.SelectedValue, "VENDEDOR", "1", 3)
                    Else
                        _GridRentabilidad.DataSource = Conexion.GenerarResumen(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, "CONSUMO_PRODUCTOS", cmbvendedor.SelectedValue, "AMBOS", cmbproveedor.SelectedValue, 3)
                    End If
                End If
            End If

            If _cmbSucursal.SelectedItem = "Tegucigalpa" Then
                If cmbvendedor.SelectedValue = "TODOS" Then
                    If cmbproveedor.SelectedValue = "TODOS" Then
                        _GridRentabilidad.DataSource = Conexion.GenerarResumen(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, "CONSUMO_PRODUCTOS", 1, "TODOS", "1", 4)
                    Else
                        _GridRentabilidad.DataSource = Conexion.GenerarResumen(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, "CONSUMO_PRODUCTOS", 1, "PROVEEDOR", cmbproveedor.SelectedValue, 4)
                    End If
                Else
                    If cmbproveedor.SelectedValue = "TODOS" Then
                        _GridRentabilidad.DataSource = Conexion.GenerarResumen(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, "CONSUMO_PRODUCTOS", cmbvendedor.SelectedValue, "VENDEDOR", "1", 4)
                    Else
                        _GridRentabilidad.DataSource = Conexion.GenerarResumen(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, "CONSUMO_PRODUCTOS", cmbvendedor.SelectedValue, "AMBOS", cmbproveedor.SelectedValue, 4)
                    End If
                End If
            End If

            If _cmbSucursal.SelectedItem = "CONSUMO" Then
                If cmbvendedor.SelectedValue = "TODOS" Then
                    If cmbproveedor.SelectedValue = "TODOS" Then
                        _GridRentabilidad.DataSource = Conexion.GenerarResumen(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, "CONSUMO_PRODUCTOS", 1, "TODOS", "1", -1)
                    Else
                        _GridRentabilidad.DataSource = Conexion.GenerarResumen(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, "CONSUMO_PRODUCTOS", 1, "PROVEEDOR", cmbproveedor.SelectedValue, -1)
                    End If
                Else
                    If cmbproveedor.SelectedValue = "TODOS" Then
                        _GridRentabilidad.DataSource = Conexion.GenerarResumen(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, "CONSUMO_PRODUCTOS", cmbvendedor.SelectedValue, "VENDEDOR", "1", -1)
                    Else
                        _GridRentabilidad.DataSource = Conexion.GenerarResumen(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, "CONSUMO_PRODUCTOS", cmbvendedor.SelectedValue, "AMBOS", cmbproveedor.SelectedValue, -1)
                    End If
                End If
            End If

            If _cmbSucursal.SelectedItem = "SR AGRO" Then
                If cmbvendedor.SelectedValue = "TODOS" Then
                    If cmbproveedor.SelectedValue = "TODOS" Then
                        _GridRentabilidad.DataSource = Conexion.GenerarResumen(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, "AGRO08_PRODUCTOS", 1, "TODOS", "1", 2)
                    Else
                        _GridRentabilidad.DataSource = Conexion.GenerarResumen(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, "AGRO08_PRODUCTOS", 1, "PROVEEDOR", cmbproveedor.SelectedValue, 2)
                    End If
                Else
                    If cmbproveedor.SelectedValue = "TODOS" Then
                        _GridRentabilidad.DataSource = Conexion.GenerarResumen(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, "AGRO08_PRODUCTOS", cmbvendedor.SelectedValue, "VENDEDOR", "1", 2)
                    Else
                        _GridRentabilidad.DataSource = Conexion.GenerarResumen(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, "AGRO08_PRODUCTOS", cmbvendedor.SelectedValue, "AMBOS", cmbproveedor.SelectedValue, 2)
                    End If
                End If
            End If
            
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ExportarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        'Exportar()
        frmGuardarArchivo.Formulario = "Rentabilidad_2"
        frmGuardarArchivo.Visible = True
    End Sub

    Sub exportarTXT(ByVal Ruta As String)
        'Dim sFile As String = "C:\Reportes\Resumen Anual\Resumen.xls" 'Ruta.Text & "\Inventry4.txt"
        Dim sFile As String = Ruta & "\Rentabilidad " & Now.Day & "-" & Now.Month & "-" & Now.Year & ".xls "
        Dim _Line As String = Nothing
        Try
            If File.Exists(sFile) = True Then
                My.Computer.FileSystem.DeleteFile(sFile, FileIO.UIOption.OnlyErrorDialogs, _
                                                  FileIO.RecycleOption.DeletePermanently, FileIO.UICancelOption.DoNothing)
            End If
            Dim swFile As StreamWriter = New StreamWriter(sFile, True, System.Text.Encoding.Default)
            With _GridRentabilidad

                _Line = .Columns(0).HeaderText & vbTab & _
                        .Columns(1).HeaderText & vbTab & _
                        .Columns(2).HeaderText & vbTab & _
                        .Columns(3).HeaderText & vbTab & _
                        .Columns(4).HeaderText & vbTab & _
                        .Columns(5).HeaderText & vbTab & _
                        .Columns(6).HeaderText & vbTab & _
                        .Columns(7).HeaderText & vbTab & _
                        .Columns(8).HeaderText & vbTab & _
                        .Columns(9).HeaderText
                swFile.WriteLine(_Line)

                For i = 0 To .RowCount - 1
                    _Line = .Rows(i).Cells(0).Value & vbTab & _
                            .Rows(i).Cells(1).Value & vbTab & _
                            .Rows(i).Cells(2).Value & vbTab & _
                            .Rows(i).Cells(3).Value & vbTab & _
                            .Rows(i).Cells(4).Value & vbTab & _
                            .Rows(i).Cells(5).Value & vbTab & _
                            .Rows(i).Cells(6).Value & vbTab & _
                            .Rows(i).Cells(7).Value & vbTab & _
                            .Rows(i).Cells(8).Value & vbTab & _
                            .Rows(i).Cells(9).Value
                    swFile.WriteLine(_Line)
                Next
            End With
            'swFile = System.Text.Encoding.Default
            swFile.Close()
            Process.Start(sFile)
        Catch ex As Exception
            MessageBox.Show("Error" + ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub _cmbSucursal_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _cmbSucursal.SelectedIndexChanged
        If _cmbSucursal.SelectedItem = "SRC" Then
            cmbvendedor.DataSource = Conexion.CargarVendedores(_cmbFechai.Value.Date, _cmbFechai.Value.Date, "VendedoresConsumo", 1, "", 1, 1)
            cmbvendedor.ValueMember = "ID"
            cmbvendedor.DisplayMember = "Nombre"

            cmbproveedor.DataSource = Conexion.CargarVendedores(_cmbFechai.Value.Date, _cmbFechai.Value.Date, "ProveedoresConsumo", 1, "", 1, 1)
            cmbproveedor.ValueMember = "ID"
            cmbproveedor.DisplayMember = "Nombre"
        End If
        If _cmbSucursal.SelectedItem = "SPS" Then
            cmbvendedor.DataSource = Conexion.CargarVendedores(_cmbFechai.Value.Date, _cmbFechai.Value.Date, "VendedoresConsumo", 1, "", 1, 1)
            cmbvendedor.ValueMember = "ID"
            cmbvendedor.DisplayMember = "Nombre"

            cmbproveedor.DataSource = Conexion.CargarVendedores(_cmbFechai.Value.Date, _cmbFechai.Value.Date, "ProveedoresConsumo", 1, "", 1, 1)
            cmbproveedor.ValueMember = "ID"
            cmbproveedor.DisplayMember = "Nombre"
        End If
        If _cmbSucursal.SelectedItem = "AGRO08" Then
            cmbvendedor.DataSource = Conexion.CargarVendedores(_cmbFechai.Value.Date, _cmbFechai.Value.Date, "Vendedores_sr_agro", 1, "", 1, 1)
            cmbvendedor.ValueMember = "ID"
            cmbvendedor.DisplayMember = "Nombre"

            cmbproveedor.DataSource = Conexion.CargarVendedores(_cmbFechai.Value.Date, _cmbFechai.Value.Date, "ProveedoresAgro08", 1, "", 1, 1)
            cmbproveedor.ValueMember = "ID"
            cmbproveedor.DisplayMember = "Nombre"
        End If
    End Sub

    Sub Exportar()
        Try
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()

            Style = wSheet.Application.ActiveWorkbook.Styles.Add("Reportes")
            Style.Font.Bold = True
            Style.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            Style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            Style.Font.Size = 11
            Style.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            wSheet.Cells.Range("A1:G1").Merge()
            wSheet.Cells.Range("A1:G1").Borders.LineStyle = BorderStyle.FixedSingle
            wSheet.Cells.Range("A1:G1").Value = "Rentabilidad del  " + _cmbFechai.Value.Date + "  al  " + _cmbFechaf.Value.Date
            wSheet.Cells.Range("A1:G1").Style = "Reportes"

            For c As Integer = 0 To _GridRentabilidad.Columns.Count - 1
                wSheet.Cells(2, c + 1).value = _GridRentabilidad.Columns(c).HeaderText
                wSheet.Cells(2, c + 1).Style = "Reportes"
            Next
            For r As Integer = 0 To _GridRentabilidad.RowCount - 1
                For c As Integer = 0 To _GridRentabilidad.Columns.Count - 1
                    wSheet.Cells(r + 3, c + 1).value = _GridRentabilidad.Item(c, r).Value
                    wSheet.Cells(r + 3, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
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