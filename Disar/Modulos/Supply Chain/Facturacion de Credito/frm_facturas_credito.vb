Imports Disar.data
Public Class frm_facturas_credito
    Dim conexion As New cls_facturacion_creditos
    Dim tmp_subtotal As Double = 0
    Dim tmp_descuento As Double = 0
    Dim tmp_isv As Double = 0
    Dim tmp_total As Double = 0

    Private Sub btn_cargar_cliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cargar_cliente.Click
        frm_lista_clientes.ShowDialog()
    End Sub

    Private Sub btn_cargar_productos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cargar_productos.Click
        frm_lista_productos.ShowDialog()
    End Sub

    Sub new_linea(ByVal cantidad As Integer, ByVal codigo As String, ByVal descripcion As String, ByVal precio As Double, ByVal ISV As Double, ByVal costo As Double)
        grid_factura.Rows.Add(cantidad, codigo, descripcion, precio, 0, 0, 0, ISV, 0, 0, costo)
    End Sub

    Private Sub grid_factura_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_factura.CellEndEdit
        Try
            tmp_subtotal = 0
            tmp_descuento = 0
            tmp_isv = 0
            tmp_total = 0
            For index As Integer = 0 To grid_factura.RowCount - 1
                Dim descuento As Double = 0
                Dim subtotal As Double = 0
                Dim isv As Double = 0
                Dim total As Double = 0

                If grid_factura.Rows(index).Cells(1).Value <> "" Then
                    subtotal = grid_factura.Rows(index).Cells(0).Value * grid_factura.Rows(index).Cells(3).Value
                    descuento = subtotal * grid_factura.Rows(index).Cells(5).Value / 100
                    isv = (subtotal - descuento) * grid_factura.Rows(index).Cells(7).Value / 100
                    total = subtotal - descuento + isv

                    grid_factura.Rows(index).Cells(4).Value = subtotal
                    grid_factura.Rows(index).Cells(6).Value = descuento
                    grid_factura.Rows(index).Cells(8).Value = isv
                    grid_factura.Rows(index).Cells(9).Value = total

                    tmp_subtotal = FormatNumber(tmp_subtotal + subtotal, 2)
                    tmp_descuento = FormatNumber(tmp_descuento + descuento)
                    tmp_isv = FormatNumber(tmp_isv + isv)
                    tmp_total = FormatNumber(tmp_total + total)
                End If
            Next
            txtsubtotal.Text = tmp_subtotal
            txtdescuento.Text = tmp_descuento
            txtisv.Text = tmp_isv
            txttotal.Text = tmp_total

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        Try
            If lbl_codigo.Text <> "" And grid_factura.RowCount - 1 > 0 Then
                conexion.Insertar_Encabezados(txt_num_factura.Text, lbl_codigo.Text, txt_cve_vend.Text, cmb_fecha.Value, cmb_fecha.Value, _
           cmb_fecha.Value, cmb_fecha.Value, txtsubtotal.Text, txtisv.Text, txtdescuento.Text, cmb_almacen.SelectedValue, cmb_fecha.Value, txttotal.Text)

                For index As Integer = 0 To grid_factura.Rows.Count - 1
                    conexion.Insertar_Detalle(txt_num_factura.Text, index + 1, grid_factura.Rows(index).Cells(1).Value, grid_factura.Rows(index).Cells(0).Value, _
                    grid_factura.Rows(index).Cells(3).Value, grid_factura.Rows(index).Cells(10).Value, grid_factura.Rows(index).Cells(7).Value, grid_factura.Rows(index).Cells(5).Value, _
                    grid_factura.Rows(index).Cells(9).Value)
                Next
                MessageBox.Show("Datos Guardados Correctamente")

                grid_factura.Rows.Clear()
                txt_cve_vend.Text = ""
                txt_num_factura.Text = ""
                txtdescuento.Text = ""
                txtisv.Text = ""
                txtsubtotal.Text = ""
                txttotal.Text = ""
                lbl_clientes.Text = ""
                lbl_codigo.Text = ""

                Me.Close()
            Else
                MessageBox.Show("Informacion en blanco")
            End If
           
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub frm_facturas_credito_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            cmb_almacen.DataSource = conexion.getAlmacen(0, 0, "CONSUMO", Now, "", "ALM", 1)
            cmb_almacen.ValueMember = "ID"
            cmb_almacen.DisplayMember = "ALMACEN"

            If conexion.GetId Is DBNull.Value Or conexion.GetId <= 0 Then
                txt_num_factura.Text = 1
            Else
                txt_num_factura.Text = conexion.GetId
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class