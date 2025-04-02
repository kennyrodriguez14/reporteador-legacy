Imports Disar.data

Public Class frm_nd_compras_nacionales

    Dim conexion As New cls_notas_debito
    Dim style As Microsoft.Office.Interop.Excel.Style

    Private Sub frm_nd_compras_nacionales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar()
    End Sub

    Sub cargar()
        Try
            grd_lista_remisiones.DataSource = conexion.listar_compras_locales(cmb_fecha_ini.Value.Date, cmb_fecha_fin.Value.Date)
            grd_lista_remisiones.Columns(5).Visible = False
            grd_lista_remisiones.Columns(7).Visible = False
            grd_lista_remisiones.Columns(8).Visible = False
            grd_lista_remisiones.Columns(9).Visible = False
            grd_lista_remisiones.Columns(10).Visible = False

            grd_lista_remisiones.Columns(14).Visible = False
            grd_lista_remisiones.Columns(15).Visible = False
            grd_lista_remisiones.Columns(16).Visible = False
            grd_lista_remisiones.Columns(17).Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        cargar()
    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        frm_orden_compra_nacional.Close()
        frm_orden_compra_nacional.modo = "nuevo"
        frm_orden_compra_nacional.ShowDialog()
        cargar()
    End Sub

    Private Sub btn_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar.Click
        Try
            Dim result As String = ""
            If grd_lista_remisiones.CurrentRow.Cells(12).Value = "ENVIADA" Then
                MessageBox.Show("La compra ya fue enviada a SAE, no se puede eliminar", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Else
                If MessageBox.Show("¿Desea eliminar la compra " + grd_lista_remisiones.CurrentRow.Cells(0).Value, "Confirmacion", _
                                          MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    result = conexion.eliminar_compra(grd_lista_remisiones.CurrentRow.Cells(0).Value)
                    If result = "correcto" Then
                        MessageBox.Show("Compra eliminada", "Datos Eliminados", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show(result)
                    End If
                End If
            End If
            cargar()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub btn_debito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_debito.Click
        Try
            frm_nd_ajuste.Close()
            frm_nd_ajuste.COMPRA = grd_lista_remisiones.CurrentRow.Cells(0).Value
            frm_nd_ajuste.tipo = "nacional"
            frm_nd_ajuste.txt_proveedor.Text = grd_lista_remisiones.CurrentRow.Cells(2).Value
            frm_nd_ajuste.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub btn_credito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_credito.Click
        Try
            frm_nd_credito.Close()
            frm_nd_credito.COMPRA = grd_lista_remisiones.CurrentRow.Cells(0).Value
            frm_nd_credito.tipo = "nacional"
            frm_nd_credito.txt_proveedor.Text = grd_lista_remisiones.CurrentRow.Cells(2).Value
            frm_nd_credito.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub grd_lista_remisiones_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grd_lista_remisiones.DoubleClick
        frm_orden_compra_nacional.Close()
        frm_orden_compra_nacional.modo = "vista"
        vista_datos()
    End Sub

    Sub vista_datos()
        Try
            frm_orden_compra_nacional.get_almacen()
            frm_orden_compra_nacional.codigo_compra = grd_lista_remisiones.CurrentRow.Cells(0).Value
            frm_orden_compra_nacional.CompraSAE = grd_lista_remisiones.CurrentRow.Cells("CODIGO SAE").Value
            frm_orden_compra_nacional.txt_codigo_proveedor.Text = grd_lista_remisiones.CurrentRow.Cells(1).Value
            frm_orden_compra_nacional.txt_nombre_proveedor.Text = grd_lista_remisiones.CurrentRow.Cells(2).Value
            frm_orden_compra_nacional.cmb_sucursal.SelectedValue = grd_lista_remisiones.CurrentRow.Cells(3).Value
            frm_orden_compra_nacional.txt_referencia_proveedor.Text = grd_lista_remisiones.CurrentRow.Cells(4).Value
            frm_orden_compra_nacional.txt_rfc.Text = grd_lista_remisiones.CurrentRow.Cells(5).Value
            frm_orden_compra_nacional.cmb_fecha_documento.Value = grd_lista_remisiones.CurrentRow.Cells(6).Value
            frm_orden_compra_nacional.txt_descuento_general.Text = grd_lista_remisiones.CurrentRow.Cells(7).Value
            frm_orden_compra_nacional.txt_subtotal_final.Text = grd_lista_remisiones.CurrentRow.Cells(8).Value
            frm_orden_compra_nacional.txt_descuento_final.Text = grd_lista_remisiones.CurrentRow.Cells(9).Value
            frm_orden_compra_nacional.txt_isv_final.Text = grd_lista_remisiones.CurrentRow.Cells(10).Value
            frm_orden_compra_nacional.txt_total_final.Text = grd_lista_remisiones.CurrentRow.Cells(11).Value
            frm_orden_compra_nacional.txt_subtotalmostrador.Text = grd_lista_remisiones.CurrentRow.Cells(14).Value
            frm_orden_compra_nacional.txt_descuento_mostrador.Text = grd_lista_remisiones.CurrentRow.Cells(15).Value
            frm_orden_compra_nacional.txt_isvmostrador.Text = grd_lista_remisiones.CurrentRow.Cells(16).Value
            frm_orden_compra_nacional.txt_totalmostrador.Text = grd_lista_remisiones.CurrentRow.Cells(17).Value
            If grd_lista_remisiones.CurrentRow.Cells(18).Value Is DBNull.Value Then
            Else
                If grd_lista_remisiones.CurrentRow.Cells(18).Value <> "" Then
                    frm_importaciones.txt_lote.Text = grd_lista_remisiones.CurrentRow.Cells(18).Value
                    frm_importaciones.cmb_fecha_vencimiento.Value = grd_lista_remisiones.CurrentRow.Cells(19).Value
                    frm_importaciones.cmb_lote.Checked = True
                End If
            End If
            frm_orden_compra_nacional.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub


    Private Sub btn_modificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_modificar.Click
        Try
            If grd_lista_remisiones.CurrentRow.Cells(12).Value = "ENVIADA" Then
                MessageBox.Show("La compra ya fue enviada a SAE, no se puede Modificar", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Else
                frm_orden_compra_nacional.Close()
                frm_orden_compra_nacional.modo = "modificar"
                vista_datos()
                cargar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub BtnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExportar.Click
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

        For c As Integer = 0 To grd_lista_remisiones.Columns.Count - 1
            wSheet.Cells(2, c + 1).value = grd_lista_remisiones.Columns(c).HeaderText
            wSheet.Cells(2, c + 1).Style = "Estilo"
        Next
        For r As Integer = 0 To grd_lista_remisiones.RowCount - 1
            For c As Integer = 0 To grd_lista_remisiones.Columns.Count - 1
                If grd_lista_remisiones.Columns(c).Visible = True Then
                    wSheet.Cells(r + 3, c + 1).value = (grd_lista_remisiones.Rows(r).Cells(c).Value.ToString)
                    wSheet.Cells(r + 3, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    wSheet.Cells(r + 3, c + 1).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                End If
            Next
        Next

        wSheet.Range("R1").EntireColumn.Delete()
        wSheet.Range("Q1").EntireColumn.Delete()
        wSheet.Range("P1").EntireColumn.Delete()
        wSheet.Range("O1").EntireColumn.Delete()

        wSheet.Range("K1").EntireColumn.Delete()
        wSheet.Range("J1").EntireColumn.Delete()
        wSheet.Range("I1").EntireColumn.Delete()
        wSheet.Range("H1").EntireColumn.Delete()

        wSheet.Range("F1").EntireColumn.Delete()

        wSheet.Cells.Range("A1:L1").Merge()
        wSheet.Cells.Range("A1:L1").Borders.LineStyle = BorderStyle.FixedSingle
        wSheet.Cells.Range("A1:L1").Value = " Reporte de Compras Nacionales "
        wSheet.Cells.Range("A1:L1").Style = "Estilo"

        wSheet.Columns.AutoFit()
        excel.Visible = True
        excel.Quit()
    End Sub

End Class