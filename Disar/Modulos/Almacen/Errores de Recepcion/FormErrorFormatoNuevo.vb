Imports Disar.data

Public Class FormErrorFormatoNuevo
    Dim conexion As New clsRecurrencias
    Dim Clase As New cls_reporte_carga
    Dim Sucursal As String
    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        guardar()
        Me.Close()
    End Sub

    Private Sub grdFactura_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdFactura.CellClick
        If grdFactura.RowCount > 1 Then
            cmb_almacen.Enabled = False
            cmb_empresa.Enabled = False

        Else
            cmb_almacen.Enabled = True
            cmb_empresa.Enabled = True

        End If
        Try
            frm_ayuda_productos_malas_cargas.Empresa = cmb_empresa.Text
        Catch ex As Exception
        End Try
        If e.ColumnIndex = btn_codigo_reporte.Index Then
            If frm_ayuda_productos_malas_cargas.ShowDialog = Windows.Forms.DialogResult.OK Then
                grdFactura.CurrentRow.Cells(1).Value = frm_ayuda_productos_malas_cargas.Codigo
                grdFactura.CurrentRow.Cells(2).Value = frm_ayuda_productos_malas_cargas.Descripcion
            End If
        End If

        If e.ColumnIndex = btn_codigocargado.Index Then
            If frm_ayuda_productos_malas_cargas.ShowDialog = Windows.Forms.DialogResult.OK Then
                grdFactura.CurrentRow.Cells(4).Value = frm_ayuda_productos_malas_cargas.Codigo
                grdFactura.CurrentRow.Cells(5).Value = frm_ayuda_productos_malas_cargas.Descripcion
            End If
        End If

        If cmb_almacen.SelectedValue = 1 Then
            Sucursal = "SPS"
        ElseIf cmb_almacen.SelectedValue = 2 Then
            Sucursal = "SRC"
        ElseIf cmb_almacen.SelectedValue = 3 Then
            Sucursal = "3"
        ElseIf cmb_almacen.SelectedValue = 4 Then
            Sucursal = "4"
        End If
        frm_encargados.Sucursal = Sucursal

        If e.ColumnIndex = btn_encargado.Index Then
            If frm_encargados.ShowDialog = Windows.Forms.DialogResult.OK Then
                grdFactura.CurrentRow.Cells(7).Value = frm_encargados.Id
            End If
        End If

        If e.ColumnIndex = btn_solucion.Index Then
            If frm_solucion_recurrencias.ShowDialog = Windows.Forms.DialogResult.OK Then
                grdFactura.CurrentRow.Cells(9).Value = frm_solucion_recurrencias.Codigo
                grdFactura.CurrentRow.Cells(10).Value = frm_solucion_recurrencias.Descripcion
                grdFactura.CurrentRow.Cells(12).Value = cmb_empresa.SelectedValue
            End If

        End If
    End Sub

    Private Sub frm_recurrencias_formato_nuevo_factura_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmb_empresa.Text = "SAN RAFAEL"
        Cargar_almacen()
    End Sub

    Sub Cargar_almacen()

        If cmb_empresa.Text = "SAN RAFAEL" Then
            grdFactura.Rows().Clear()


            cmb_almacen.DataSource = Clase.getAlmacen(0, 0, "CONSUMO", Now, "", "ALM", 1)
            cmb_almacen.ValueMember = "ID"
            cmb_almacen.DisplayMember = "ALMACEN"

            Dim db As New clsRecurrencias
            ComboBox1.DataSource = db.ProveedoresSanRafael()
            ComboBox1.ValueMember = "CLAVE"
            ComboBox1.DisplayMember = "NOMBRE"

        ElseIf cmb_empresa.Text = "DIMOSA" Then
            grdFactura.Rows().Clear()
            cmb_almacen.DataSource = Clase.getAlmacen(0, 0, "DIMOSA", Now, "", "ALM", 1)
            cmb_almacen.ValueMember = "ID"
            cmb_almacen.DisplayMember = "ALMACEN"

            Dim db As New clsRecurrencias
            ComboBox1.DataSource = db.ProveedoresDIMOSA()
            ComboBox1.ValueMember = "CLAVE"
            ComboBox1.DisplayMember = "NOMBRE"

        End If
    End Sub

    Sub guardar()
        '  Try
        For index As Integer = 0 To grdFactura.Rows.Count - 1
            If grdFactura.Rows(index).Cells(1).Value <> "" Then
                conexion.InsertErrorProv(cmbFecha.Value.Date, grdFactura.Rows(index).Cells(1).Value, grdFactura.Rows(index).Cells(4).Value _
                                , grdFactura.Rows(index).Cells(7).Value, grdFactura.Rows(index).Cells(9).Value, grdFactura.Rows(index).Cells(11).Value, cmb_almacen.SelectedValue, cmb_empresa.Text, ComboBox1.SelectedValue, ComboBox1.Text)
            End If
        Next
        '  MessageBox.Show("Datos Guardados Exitosamente")
        '   Catch ex As Exception
        '  MessageBox.Show(ex.Message)
        '  End Try
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Me.Close()
    End Sub



    Private Sub cmb_empresa_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_empresa.SelectedIndexChanged
        Cargar_almacen()

    End Sub

End Class