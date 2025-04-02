Imports Disar.data
Public Class frm_lista_importaciones_sragro
    Dim conexion As New cls_notas_debito_SRAGRO
    Dim style As Microsoft.Office.Interop.Excel.Style

    Sub cargar()
        Try
            grd_lista_remisiones.DataSource = conexion.listar_importaciones_locales(cmb_fecha_ini.Value.Date, cmb_fecha_fin.Value.Date)
            grd_lista_remisiones.Columns(5).Visible = False
            grd_lista_remisiones.Columns(7).Visible = False
            grd_lista_remisiones.Columns(8).Visible = False
            grd_lista_remisiones.Columns(9).Visible = False
            grd_lista_remisiones.Columns(10).Visible = False
            grd_lista_remisiones.Columns(15).Visible = False
            grd_lista_remisiones.Columns(16).Visible = False
            grd_lista_remisiones.Columns(17).Visible = False
            grd_lista_remisiones.Columns(18).Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        frm_importaciones_sragro.Close()
        frm_importaciones_sragro.modo = "nuevo"
        frm_importaciones_sragro.ShowDialog()
        cargar()
    End Sub

    Private Sub btn_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar.Click
        Try
            Dim result As String = ""
            If grd_lista_remisiones.CurrentRow.Cells(12).Value = "ENVIADA" Then
                MessageBox.Show("La Importacion ya fue enviada a SAE, no se puede eliminar", "Informacion", _
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Else
                If MessageBox.Show("¿Desea eliminar la Importacion " + grd_lista_remisiones.CurrentRow.Cells(0).Value, "Confirmacion", _
                                          MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    result = conexion.eliminar_importacion(grd_lista_remisiones.CurrentRow.Cells(0).Value)
                    If result = "correcto" Then
                        MessageBox.Show("Compra eliminada", "Datos Eliminados", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show(result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    End If
                End If
            End If
            cargar()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cargar()
    End Sub

    Private Sub btn_debito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_debito.Click
        Try
            frm_nd_ajuste_sragro.Close()
            frm_nd_ajuste_sragro.COMPRA = grd_lista_remisiones.CurrentRow.Cells(0).Value
            frm_nd_ajuste_sragro.txt_proveedor.Text = grd_lista_remisiones.CurrentRow.Cells(2).Value
            frm_nd_ajuste_sragro.tipo = "importacion"
            frm_nd_ajuste_sragro.tasa = grd_lista_remisiones.CurrentRow.Cells(13).Value
            frm_nd_ajuste_sragro.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub btn_credito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_credito.Click
        Try
            frm_nd_credito_sragro.Close()
            frm_nd_credito_sragro.COMPRA = grd_lista_remisiones.CurrentRow.Cells(0).Value
            frm_nd_credito_sragro.tipo = "importacion"
            frm_nd_credito_sragro.tasa = grd_lista_remisiones.CurrentRow.Cells(13).Value
            frm_nd_credito_sragro.txt_proveedor.Text = grd_lista_remisiones.CurrentRow.Cells(2).Value
            frm_nd_credito_sragro.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub btn_modificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_modificar.Click
        Try
            If grd_lista_remisiones.CurrentRow.Cells(12).Value = "ENVIADO" Then
                MessageBox.Show("La Importacion ya fue enviada a SAE, no se puede Modificar", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Else
                frm_importaciones_sragro.Close()
                frm_importaciones_sragro.modo = "modificar"
                vista_datos()
                cargar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Sub vista_datos()
        Try
            frm_importaciones_sragro.get_almacen()
            frm_importaciones_sragro.codigo_compra = grd_lista_remisiones.CurrentRow.Cells(0).Value
            frm_importaciones_sragro.txt_codigo_proveedor.Text = grd_lista_remisiones.CurrentRow.Cells(1).Value
            frm_importaciones_sragro.txt_nombre_proveedor.Text = grd_lista_remisiones.CurrentRow.Cells(2).Value
            frm_importaciones_sragro.cmb_sucursal.SelectedValue = grd_lista_remisiones.CurrentRow.Cells(3).Value
            frm_importaciones_sragro.txt_referencia_proveedor.Text = grd_lista_remisiones.CurrentRow.Cells(4).Value
            frm_importaciones_sragro.txt_rfc.Text = grd_lista_remisiones.CurrentRow.Cells(5).Value
            frm_importaciones_sragro.cmb_fecha_documento.Value = grd_lista_remisiones.CurrentRow.Cells(6).Value
            frm_importaciones_sragro.txt_descuento_general.Text = grd_lista_remisiones.CurrentRow.Cells(7).Value
            frm_importaciones_sragro.txt_tasa_pactada.Text = grd_lista_remisiones.CurrentRow.Cells(13).Value
            frm_importaciones_sragro.txt_flete.Text = grd_lista_remisiones.CurrentRow.Cells(15).Value
            frm_importaciones_sragro.txt_seguro.Text = grd_lista_remisiones.CurrentRow.Cells(16).Value
            frm_importaciones_sragro.txt_pyc.Text = grd_lista_remisiones.CurrentRow.Cells(17).Value
            frm_importaciones_sragro.txt_honorarios.Text = grd_lista_remisiones.CurrentRow.Cells(18).Value
            frm_importaciones_sragro.subtotal_recibido = grd_lista_remisiones.CurrentRow.Cells(8).Value
            frm_importaciones_sragro.descuento_recibido = grd_lista_remisiones.CurrentRow.Cells(9).Value
            frm_importaciones_sragro.isv_recibido = grd_lista_remisiones.CurrentRow.Cells(10).Value
            frm_importaciones_sragro.total_recibido = grd_lista_remisiones.CurrentRow.Cells(11).Value
            frm_importaciones_sragro.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub grd_lista_remisiones_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grd_lista_remisiones.DoubleClick
        frm_importaciones_sragro.Close()
        frm_importaciones_sragro.modo = "vista"
        vista_datos()
    End Sub

    Private Sub frm_lista_importaciones_sragro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar()
    End Sub

    Private Sub BtnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

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
            If grd_lista_remisiones.Columns(c).Visible = True Then
                wSheet.Cells(2, c + 1).value = grd_lista_remisiones.Columns(c).HeaderText
                wSheet.Cells(2, c + 1).Style = "Estilo"
            End If
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

        wSheet.Range("K1").EntireColumn.Delete()
        wSheet.Range("J1").EntireColumn.Delete()
        wSheet.Range("I1").EntireColumn.Delete()
        wSheet.Range("H1").EntireColumn.Delete()
        wSheet.Range("F1").EntireColumn.Delete()

        wSheet.Cells.Range("A1:J1").Merge()
        wSheet.Cells.Range("A1:J1").Borders.LineStyle = BorderStyle.FixedSingle
        wSheet.Cells.Range("A1:J1").Value = " Reporte de Importaciones SR AGRO "
        wSheet.Cells.Range("A1:J1").Style = "Estilo"

        wSheet.Columns.AutoFit()
        excel.Visible = True
        excel.Quit()

    End Sub

    Private Sub btn_aceptar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        cargar()
    End Sub
End Class