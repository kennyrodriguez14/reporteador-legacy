Imports Disar.data

Public Class frm_lista_importaciones

    Dim conexion As New cls_notas_debito
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
            grd_lista_remisiones.Columns(19).Visible = False
            grd_lista_remisiones.Columns(20).Visible = False
            grd_lista_remisiones.Columns(21).Visible = False
            grd_lista_remisiones.Columns(22).Visible = False
            grd_lista_remisiones.Columns(23).Visible = False
            grd_lista_remisiones.Columns(24).Visible = False
            grd_lista_remisiones.Columns(25).Visible = False
            grd_lista_remisiones.Columns(27).Visible = False
            grd_lista_remisiones.Columns(28).Visible = False
            grd_lista_remisiones.Columns(29).Visible = False
            grd_lista_remisiones.Columns(32).Visible = False
            grd_lista_remisiones.Columns(33).Visible = False
            grd_lista_remisiones.Columns(34).Visible = False
            grd_lista_remisiones.Columns(35).Visible = False
            grd_lista_remisiones.Columns(2).Width = 500
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        frm_importaciones.Close()
        frm_importaciones.modo = "nuevo"
        frm_importaciones.ShowDialog()
        cargar()
    End Sub

    Private Sub btn_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar.Click
        Try
            Dim result As String = ""
            If grd_lista_remisiones.CurrentRow.Cells(12).Value = "ENVIADO" Then
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

    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        cargar()
    End Sub

    Private Sub btn_debito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_debito.Click
        Try
            frm_nd_ajuste.Close()
            frm_nd_ajuste.COMPRA = grd_lista_remisiones.CurrentRow.Cells(0).Value
            frm_nd_ajuste.txt_proveedor.Text = grd_lista_remisiones.CurrentRow.Cells(2).Value
            frm_nd_ajuste.tipo = "importacion"
            frm_nd_ajuste.tasa = grd_lista_remisiones.CurrentRow.Cells(13).Value
            frm_nd_ajuste.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub btn_credito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_credito.Click
        Try
            frm_nd_credito.Close()
            frm_nd_credito.COMPRA = grd_lista_remisiones.CurrentRow.Cells(0).Value
            frm_nd_credito.tipo = "importacion"
            frm_nd_credito.tasa = grd_lista_remisiones.CurrentRow.Cells(13).Value
            frm_nd_credito.txt_proveedor.Text = grd_lista_remisiones.CurrentRow.Cells(2).Value
            frm_nd_credito.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub btn_modificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_modificar.Click
        Try
            If grd_lista_remisiones.CurrentRow.Cells(12).Value = "ENVIADA" Then
                MessageBox.Show("La Importacion ya fue enviada a SAE, no se puede Modificar", "Informacion", MessageBoxButtons.OK, _
                                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Else
                frm_importaciones.Close()
                frm_importaciones.modo = "modificar"
                vista_datos()
                cargar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Sub vista_datos()
        Try
            frm_importaciones.get_almacen()
            frm_importaciones.codigo_compra = grd_lista_remisiones.CurrentRow.Cells(0).Value
            frm_importaciones.txt_codigo_proveedor.Text = grd_lista_remisiones.CurrentRow.Cells(1).Value
            frm_importaciones.txt_nombre_proveedor.Text = grd_lista_remisiones.CurrentRow.Cells(2).Value
            frm_importaciones.cmb_sucursal.SelectedValue = grd_lista_remisiones.CurrentRow.Cells(3).Value
            frm_importaciones.txt_referencia_proveedor.Text = grd_lista_remisiones.CurrentRow.Cells(4).Value
            frm_importaciones.txt_rfc.Text = grd_lista_remisiones.CurrentRow.Cells(5).Value
            frm_importaciones.cmb_fecha_documento.Value = grd_lista_remisiones.CurrentRow.Cells(6).Value
            frm_importaciones.txt_descuento_general.Text = grd_lista_remisiones.CurrentRow.Cells(7).Value
            frm_importaciones.txt_tasa_pactada.Text = grd_lista_remisiones.CurrentRow.Cells(13).Value
            frm_importaciones.txt_flete.Text = grd_lista_remisiones.CurrentRow.Cells(15).Value
            frm_importaciones.txt_seguro.Text = grd_lista_remisiones.CurrentRow.Cells(16).Value
            frm_importaciones.txt_pyc.Text = grd_lista_remisiones.CurrentRow.Cells(17).Value
            frm_importaciones.txt_honorarios.Text = grd_lista_remisiones.CurrentRow.Cells(18).Value
            frm_importaciones.txt_parqueo_D.Text = grd_lista_remisiones.CurrentRow.Cells(21).Value
            frm_importaciones.txt_rev_des_carg_D.Text = grd_lista_remisiones.CurrentRow.Cells(22).Value
            frm_importaciones.txt_emision_gr_D.Text = grd_lista_remisiones.CurrentRow.Cells(23).Value
            frm_importaciones.txt_encomiendas_D.Text = grd_lista_remisiones.CurrentRow.Cells(24).Value
            frm_importaciones.txt_gastos_variables_d.Text = grd_lista_remisiones.CurrentRow.Cells(25).Value
            frm_importaciones.txt_numero_boletin.Text = grd_lista_remisiones.CurrentRow.Cells(26).Value
            frm_importaciones.cmb_otro_proveedores.SelectedValue = grd_lista_remisiones.CurrentRow.Cells(29).Value
            frm_importaciones.txt_servicio_tranporte_datos.Text = grd_lista_remisiones.CurrentRow.Cells(28).Value
            frm_importaciones.subtotal_recibido = grd_lista_remisiones.CurrentRow.Cells(8).Value
            frm_importaciones.descuento_recibido = grd_lista_remisiones.CurrentRow.Cells(9).Value
            frm_importaciones.isv_recibido = grd_lista_remisiones.CurrentRow.Cells(10).Value
            frm_importaciones.total_recibido = grd_lista_remisiones.CurrentRow.Cells(11).Value

            If grd_lista_remisiones.CurrentRow.Cells(29).Value Is DBNull.Value Or _
                 grd_lista_remisiones.CurrentRow.Cells(29).Value = "" Then
                frm_importaciones.cargar_otros_prov("       565")
            Else
                frm_importaciones.cargar_otros_prov(grd_lista_remisiones.CurrentRow.Cells(29).Value)
            End If

            If grd_lista_remisiones.CurrentRow.Cells(19).Value Is DBNull.Value Then
            Else
                If grd_lista_remisiones.CurrentRow.Cells(19).Value <> "" Then
                    frm_importaciones.txt_lote.Text = grd_lista_remisiones.CurrentRow.Cells(19).Value
                    frm_importaciones.cmb_fecha_vencimiento.Value = grd_lista_remisiones.CurrentRow.Cells(20).Value
                    frm_importaciones.cmb_lote.Checked = True
                End If
            End If

            frm_importaciones.txt_cliente_rastra.Text = grd_lista_remisiones.CurrentRow.Cells(30).Value
            frm_importaciones.txt_nombre_rastra.Text = grd_lista_remisiones.CurrentRow.Cells(31).Value
            frm_importaciones.txt_servicio_portuario.Text = grd_lista_remisiones.CurrentRow.Cells(32).Value
            frm_importaciones.txt_especies_fiscales.Text = grd_lista_remisiones.CurrentRow.Cells(33).Value
            frm_importaciones.txt_dai.Text = grd_lista_remisiones.CurrentRow.Cells(34).Value
            frm_importaciones.txt_ivz.Text = grd_lista_remisiones.CurrentRow.Cells(35).Value
            frm_importaciones.txt_cargo_livsmart.Text = grd_lista_remisiones.CurrentRow.Cells(36).Value
            frm_importaciones.txt_sel_d.Text = grd_lista_remisiones.CurrentRow.Cells(37).Value
            frm_importaciones.txt_id.Text = grd_lista_remisiones.CurrentRow.Cells(14).Value
            frm_importaciones.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub grd_lista_remisiones_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grd_lista_remisiones.DoubleClick
        frm_importaciones.Close()
        frm_importaciones.modo = "vista"
        vista_datos()
    End Sub

    Private Sub frm_lista_importaciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar()
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

        wSheet.Cells.Range("A1:H1").Merge()
        wSheet.Cells.Range("A1:H1").Borders.LineStyle = BorderStyle.FixedSingle
        wSheet.Cells.Range("A1:H1").Value = " Reporte de Registro SR Agro "
        wSheet.Cells.Range("A1:H1").Style = "Estilo"

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

        wSheet.Range("W1").EntireColumn.Delete()
        wSheet.Range("V1").EntireColumn.Delete()
        wSheet.Range("U1").EntireColumn.Delete()
        wSheet.Range("T1").EntireColumn.Delete()
        wSheet.Range("S1").EntireColumn.Delete()
        wSheet.Range("R1").EntireColumn.Delete()
        wSheet.Range("Q1").EntireColumn.Delete()
        wSheet.Range("P1").EntireColumn.Delete()

        wSheet.Range("K1").EntireColumn.Delete()
        wSheet.Range("J1").EntireColumn.Delete()
        wSheet.Range("I1").EntireColumn.Delete()
        wSheet.Range("H1").EntireColumn.Delete()

        wSheet.Range("F1").EntireColumn.Delete()

        wSheet.Cells.Range("A1:Q1").Merge()
        wSheet.Cells.Range("A1:Q1").Borders.LineStyle = BorderStyle.FixedSingle
        wSheet.Cells.Range("A1:Q1").Value = " Reporte de Importaciones "
        wSheet.Cells.Range("A1:Q1").Style = "Estilo"

        wSheet.Columns.AutoFit()
        excel.Visible = True
        excel.Quit()
    End Sub

    Private Sub btn_productos_pyc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_productos_pyc.Click
        frm_productos_pyc.ShowDialog()
    End Sub
End Class