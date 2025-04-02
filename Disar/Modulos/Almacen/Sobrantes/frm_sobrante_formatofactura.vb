Imports Disar.data

Public Class frm_sobrante_formatofactura
    Dim Clase As New cls_reporte_carga
    Dim conexion As New cls_Sobrantes
    Dim Sucursal As String
    Private Sub grdFactura_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdFactura.CellClick

        If grdFactura.RowCount > 1 Then
            cmb_almacen.Enabled = False
            cmb_empresa.Enabled = False

        Else
            cmb_almacen.Enabled = True
            cmb_empresa.Enabled = True

        End If

        If e.ColumnIndex = btn_producto.Index Then

            frm_ayuda_productos_malas_cargas.Empresa = cmb_empresa.Text
            If frm_ayuda_productos_malas_cargas.ShowDialog = Windows.Forms.DialogResult.OK Then
                grdFactura.CurrentRow.Cells(3).Value = frm_ayuda_productos_malas_cargas.Codigo
                grdFactura.CurrentRow.Cells(4).Value = frm_ayuda_productos_malas_cargas.Descripcion
            End If
        End If
        If cmb_empresa.Text = "SR AGRO" Then
            Sucursal = cmb_almacen.SelectedValue
        Else
            If cmb_almacen.SelectedValue = 1 Then
                Sucursal = "SPS"
            ElseIf cmb_almacen.SelectedValue = 2 Then
                Sucursal = "SRC"
            ElseIf cmb_almacen.SelectedValue = 3 Then
                Sucursal = "3"
            ElseIf cmb_almacen.SelectedValue = 4 Then
                Sucursal = "4"
            End If
        End If


        frm_entregadores.Sucursal = Sucursal
        If e.ColumnIndex = btn_entregador.Index Then
            frm_entregadores.Empresa = cmb_empresa.Text
            If frm_entregadores.ShowDialog = Windows.Forms.DialogResult.OK Then
                grdFactura.CurrentRow.Cells(8).Value = frm_entregadores.Codigo
            End If
        End If

        If e.ColumnIndex = btn_verificacion.Index Then
            If frm_verificacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                grdFactura.CurrentRow.Cells(11).Value = frm_verificacion.Codigo
            End If
        End If

        If e.ColumnIndex = btn_fecha.Index Then
            If frm_fecha.ShowDialog = Windows.Forms.DialogResult.OK Then
                grdFactura.CurrentRow.Cells(1).Value = frm_fecha.FECHA.Date

            End If
        End If
    End Sub

    Sub Cargar_almacen()

        If cmb_empresa.Text = "SAN RAFAEL" Then
            cmb_almacen.DataSource = Clase.getAlmacen(0, 0, "CONSUMO", Now, "", "ALM", 1)
            cmb_almacen.ValueMember = "ID"
            cmb_almacen.DisplayMember = "ALMACEN"

        ElseIf cmb_empresa.Text = "DIMOSA" Then
            cmb_almacen.DataSource = Clase.getAlmacen(0, 0, "DIMOSA", Now, "", "ALM", 1)
            cmb_almacen.ValueMember = "ID"
            cmb_almacen.DisplayMember = "ALMACEN"
        ElseIf cmb_empresa.Text = "SR AGRO" Then
            cmb_almacen.DataSource = Clase.getAlmacen(0, 0, "SR AGRO", Now, "", "ALM", 1)
            cmb_almacen.ValueMember = "ID"
            cmb_almacen.DisplayMember = "ALMACEN"

        End If






    End Sub

    Private Sub frm_sobrante_formatofactura_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmb_empresa.Text = "SAN RAFAEL"
        Cargar_almacen()
    End Sub

    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        Guardar()
        Me.Close()
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Me.Close()
    End Sub

    Sub guardar()
        'Try
        For index As Integer = 0 To grdFactura.Rows.Count - 1
            If grdFactura.Rows(index).Cells(3).Value <> "" Then
                conexion.Insert(grdFactura.Rows(index).Cells(1).Value, grdFactura.Rows(index).Cells(3).Value, grdFactura.Rows(index).Cells(5).Value, _
                grdFactura.Rows(index).Cells(6).Value, grdFactura.Rows(index).Cells(8).Value, grdFactura.Rows(index).Cells(9).Value, cmb_almacen.SelectedValue, _
                grdFactura.Rows(index).Cells(11).Value, cmb_empresa.Text)
            End If
        Next
        ' MessageBox.Show("Datos Guardados Exitosamente")
        ' Catch ex As Exception
        'MessageBox.Show(ex.Message)
        '  End Try
    End Sub

    Private Sub cmb_empresa_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_empresa.SelectedIndexChanged
        Cargar_almacen()
    End Sub
End Class