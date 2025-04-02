Imports Disar.data

Public Class FrmDevolucionCompraNacional
    Public Compra As String
    Public CompraSAE As String
    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        Dim respuesta = MsgBox("Está seguro que desea guardar la devolución " & ComboTipo.Text & " de compra: " & Compra & "?", MsgBoxStyle.YesNo)
        If respuesta = MsgBoxResult.Yes Then
            Dim Tipo As String = ""

            If ComboTipo.Text = "PARCIAL" Then
                Tipo = "P"
            Else
                Tipo = "T"
            End If

            Dim db As New cls_notas_debito

            Dim dtEncabezados As New DataTable
            Dim dtPartidas As New DataTable

            For Each column As DataGridViewColumn In Grd_Partidas.Columns
                dtPartidas.Columns.Add(column.HeaderText)
            Next

            For Each row As DataGridViewRow In Grd_Partidas.Rows
                'dtPartidas.Rows.Add(row)
            Next


            dtEncabezados.Columns.Add("CVE_PROVEEDOR")  'S 0
            dtEncabezados.Columns.Add("PROVEEDOR")      'S 1
            dtEncabezados.Columns.Add("ALMACEN")        'S 2
            dtEncabezados.Columns.Add("REF_PROV")       'S 3
            dtEncabezados.Columns.Add("RFC")            'S 4
            dtEncabezados.Columns.Add("FECHA")          'S 5
            dtEncabezados.Columns.Add("DESCUENTO_POR")  'S 6
            dtEncabezados.Columns.Add("SUB_TOTAL")      'S 7
            dtEncabezados.Columns.Add("DESCUENTO_VAL")  'S 8
            dtEncabezados.Columns.Add("ISV_VAL")        'S 9
            dtEncabezados.Columns.Add("TOTAL")          'S 10
            dtEncabezados.Columns.Add("SUBTOTAL_MOST")  '  11
            dtEncabezados.Columns.Add("DESC_MOST")      'S 0
            dtEncabezados.Columns.Add("ISV_MOST")       'S 0
            dtEncabezados.Columns.Add("TOTAL_MOST")     'S 0
            dtEncabezados.Columns.Add("FLETE")          'S 0
            dtEncabezados.Columns.Add("LOTE")           'S 0
            dtEncabezados.Columns.Add("F_VENCIMIENTO")  'S today.date
            dtEncabezados.Columns.Add("CVE_COMPRA_REP") 'S 18

            dtEncabezados.Rows.Add(txt_codigo_proveedor.Text, txt_nombre_proveedor.Text, txt_almacen.Text, txt_referencia_proveedor.Text, txt_rfc.Text, Today.Date, txt_descuento_general.Text, txt_subtotal_final.Text, txt_descuento_final.Text, txt_isv_final.Text, txt_total_final.Text, 0, 0, 0, 0, 0, Today.Date, Compra)

            'MsgBox("compra " & Compra & vbNewLine & CompraSAE)
            Dim s = db.guardar_devolucion_scompra(dtEncabezados, dtPartidas, _Inicio.lblUsuario.Text, Tipo, CompraSAE)
        End If
        
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Me.Close()
    End Sub

    Private Sub ComboTipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboTipo.SelectedIndexChanged
        If ComboTipo.Text = "Parcial" Then
            Grd_Partidas.Columns("Devolucion").ReadOnly = False
        Else
            Grd_Partidas.Columns("Devolucion").ReadOnly = True
            For Each row As DataGridViewRow In Grd_Partidas.Rows
                row.Cells("Devolucion").Value = row.Cells(4).Value
            Next
        End If
        sumar_totales()
    End Sub

    Private Sub Grd_Partidas_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grd_Partidas.CellEndEdit
        If Grd_Partidas.Rows(e.RowIndex).Cells("Devolucion").Value >= Grd_Partidas.Rows(e.RowIndex).Cells("Cantidad").Value Then
            Grd_Partidas.Rows(e.RowIndex).Cells("Devolucion").Value = Grd_Partidas.Rows(e.RowIndex).Cells("Cantidad").Value
        End If
        sumar_totales()
    End Sub

    Sub sumar_totales()
        Dim subtotal As Double = 0, total As Double = 0, descuento As Double = 0, isv As Double = 0
        Dim total_mostrador As Double = 0, subtotal_mostrador As Double = 0, isv_mostrador As Double = 0, desc_mostrador As Double = 0

        For index As Integer = 0 To Grd_Partidas.RowCount - 1
            subtotal += (Grd_Partidas.Rows(index).Cells("Devolucion").Value * Grd_Partidas.Rows(index).Cells("PRECIO_FINAL").Value * Grd_Partidas.Rows(index).Cells("FACT_CONV").Value)
            descuento += (Val(Grd_Partidas.Rows(index).Cells("DESC_PROD").Value) / 100) * subtotal
            isv += (Val(Grd_Partidas.Rows(index).Cells("ISV_PROD").Value) / 100) * subtotal
            total += (subtotal - descuento) + isv
        Next
        txt_subtotal_final.Text = subtotal.ToString("N2")
        txt_descuento_final.Text = descuento.ToString("N2")
        txt_isv_final.Text = isv.ToString("N2")
        txt_total_final.Text = total.ToString("N2")
    End Sub
End Class