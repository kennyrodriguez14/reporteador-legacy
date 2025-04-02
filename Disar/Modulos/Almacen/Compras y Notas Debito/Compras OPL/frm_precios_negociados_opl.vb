Imports Disar.data
Public Class frm_precios_negociados_opl
    Dim conexion_notas_debito As New cls_notas_debito
    Public usuario_id As Integer
    Public usuario_name As String
    Dim precio_anterior As String = 0

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        grp_ingreso.Visible = False
        grp_filtros.Visible = True
        grp_precios_productos.Visible = True
        Try
            If txt_validador.Text = "ins" Then
                Dim var_error As String = ""
                var_error = conexion_notas_debito.insertar_precio_OPL(txt_codigo.Text, Val(txt_precio_negociado.Text), usuario_id, usuario_name, Now, precio_anterior)
                If var_error = "correcto" Then
                    MessageBox.Show("Precio actualizado")
                Else
                    MessageBox.Show("Error al actualizar precio" + var_error)
                End If
            Else
                Dim var_error As String = ""
                var_error = conexion_notas_debito.actualizar_precio_OPL(txt_codigo.Text, Val(txt_precio_negociado.Text), usuario_id, usuario_name, Now, precio_anterior)
                If var_error = "correcto" Then
                    MessageBox.Show("Precio actualizado")
                Else
                    MessageBox.Show("Error al actualizar precio" + var_error)
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        cargar()
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        grp_ingreso.Visible = False
        grp_filtros.Visible = True
        grp_precios_productos.Visible = True
    End Sub

    Private Sub grd_precios_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grd_precios.DoubleClick
        Try
            grp_ingreso.Visible = True
            grp_filtros.Visible = False
            grp_precios_productos.Visible = False

            txt_codigo.Text = grd_precios.CurrentRow.Cells(0).Value
            txt_descripcion.Text = grd_precios.CurrentRow.Cells(1).Value
            txt_precio_negociado.Text = grd_precios.CurrentRow.Cells(2).Value

            precio_anterior = grd_precios.CurrentRow.Cells(2).Value

            If grd_precios.CurrentRow.Cells(2).Value = "No asignado" Then
                txt_validador.Text = "ins"
            Else
                txt_validador.Text = "upd"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub frm_precios_negociados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_proveedores()
        cargar()
    End Sub

    Sub cargar_proveedores()
        Try
            cmb_proveedor.DataSource = conexion_notas_debito.cargar_proveedores_opl()
            cmb_proveedor.ValueMember = "CLAVE"
            cmb_proveedor.DisplayMember = "NOMBRE"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txt_buqueda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_buqueda.TextChanged
        Try
            cargar()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        Try
            cargar()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Sub cargar()
        Try
            grd_precios.DataSource = conexion_notas_debito.filtros_OPL(txt_buqueda.Text, cmb_proveedor.SelectedValue)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_exportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar.Click
        Exportar()
    End Sub

    Sub Exportar()
        Try
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet
            wSheet.Cells.Range("A1:C1").Merge()
            wSheet.Cells.Range("A1:C1").Value = " Lista de Precios Negociados "
            wSheet.Cells.Range("A1:C1").Font.Color = System.Drawing.ColorTranslator.ToOle(Color.Black)
            wSheet.Cells.Range("A1:C1").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet.Cells.Range("A1:C1").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            wSheet.Cells.Range("A1:C1").Font.Bold = True

            For c As Integer = 0 To grd_precios.Columns.Count - 1
                wSheet.Cells(2, c + 1).value = grd_precios.Columns(c).HeaderText
                wSheet.Cells(2, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
            Next
            For r As Integer = 0 To grd_precios.RowCount - 1
                For c As Integer = 0 To grd_precios.Columns.Count - 1
                    If c = 0 Then
                        wSheet.Cells(r + 3, c + 1).value = "" + grd_precios.Item(c, r).Value
                        wSheet.Cells(r + 3, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    Else
                        wSheet.Cells(r + 3, c + 1).value = grd_precios.Item(c, r).Value
                        wSheet.Cells(r + 3, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    End If
                Next
            Next
            wSheet.Columns.AutoFit()
            excel.Visible = True
            excel.Quit()
        Catch ex As Exception
            MessageBox.Show("Error " & ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class