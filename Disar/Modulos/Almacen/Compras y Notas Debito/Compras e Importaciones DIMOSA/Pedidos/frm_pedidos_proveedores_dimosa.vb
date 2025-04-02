Imports Disar.data

Public Class frm_pedidos_proveedores_dimosa

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Actualizar()
    End Sub

    Private Sub BtnNueva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNueva.Click
        If frm_NuevoPedido_Dimosa.Visible = True Then
            frm_NuevoPedido_Dimosa.BringToFront()
        Else
            frm_NuevoPedido_Dimosa.Show()
        End If
    End Sub

    Private Sub frm_pedidos_proveedores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LlenarAlmacenes()
        Try
            If _Inicio.Multiples = 1 Then
                ComboBox1.Enabled = True
            Else
                ComboBox1.Enabled = False
            End If
            ComboBox1.SelectedValue = _Inicio.Almacen
        Catch ex As Exception
        End Try
        Actualizar()
    End Sub

    Sub LlenarAlmacenes()
        Dim db As New cls_compras_pedidos
        ComboBox1.DataSource = db.CargarAlmacenes("DIMOSA")
        ComboBox1.ValueMember = "CVE_ALM"
        ComboBox1.DisplayMember = "DESCR"
    End Sub

    Sub Actualizar()
        Try
            Dim db As New cls_compras_pedidos
            DataPedidos.DataSource = db.CargaPedidos(DateTimePicker1.Value.Date, DateTimePicker2.Value.Date, ComboBox1.SelectedValue, "DIMOSA")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DataPedidos_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataPedidos.CellDoubleClick

        Frm_Completar_Orden_Pedido_DIMOSA.Close()

        Frm_Completar_Orden_Pedido_DIMOSA.TextNumero.Text = DataPedidos.CurrentRow.Cells(0).Value
        Frm_Completar_Orden_Pedido_DIMOSA.TextFechaSol.Text = DataPedidos.CurrentRow.Cells(1).Value
        Frm_Completar_Orden_Pedido_DIMOSA.TextNumProv.Text = DataPedidos.CurrentRow.Cells(2).Value
        Frm_Completar_Orden_Pedido_DIMOSA.TextProveedor.Text = DataPedidos.CurrentRow.Cells(3).Value
        Frm_Completar_Orden_Pedido_DIMOSA.TextSolicitante.Text = DataPedidos.CurrentRow.Cells(4).Value
        Frm_Completar_Orden_Pedido_DIMOSA.TextAlmacen.Text = DataPedidos.CurrentRow.Cells(5).Value
        If DataPedidos.CurrentRow.Cells(5).Value = 1 Then
            Frm_Completar_Orden_Pedido_DIMOSA.TextDescripcionSucursal.Text = "San Pedro Sula"
        ElseIf DataPedidos.CurrentRow.Cells(5).Value = 2 Then
            Frm_Completar_Orden_Pedido_DIMOSA.TextDescripcionSucursal.Text = "Santa Rosa de Copán"
        ElseIf DataPedidos.CurrentRow.Cells(5).Value = 3 Then
            Frm_Completar_Orden_Pedido_DIMOSA.TextDescripcionSucursal.Text = "Sabá"
        Else
            Frm_Completar_Orden_Pedido_DIMOSA.TextDescripcionSucursal.Text = "Tegucigalpa"
        End If
        Frm_Completar_Orden_Pedido_DIMOSA.TextEstado.Text = DataPedidos.CurrentRow.Cells(6).Value
        Frm_Completar_Orden_Pedido_DIMOSA.TextTipo.Text = DataPedidos.CurrentRow.Cells(7).Value
        If Not IsDBNull(DataPedidos.CurrentRow.Cells(8).Value) Then
            Frm_Completar_Orden_Pedido_DIMOSA.TextCompra.Text = DataPedidos.CurrentRow.Cells(8).Value
        Else
            Frm_Completar_Orden_Pedido_DIMOSA.TextCompra.Text = "Compra Pendiente"
        End If
        If Not IsDBNull(DataPedidos.CurrentRow.Cells(9).Value) Then
            Frm_Completar_Orden_Pedido_DIMOSA.TextFechaCompra.Text = DataPedidos.CurrentRow.Cells(9).Value
        Else
            Frm_Completar_Orden_Pedido_DIMOSA.TextFechaCompra.Text = "Compra Pendiente"
        End If

        Try
            Dim db As New cls_compras_pedidos
            Frm_Completar_Orden_Pedido_DIMOSA.DataPedidos.DataSource = db.CargarPartidasPedidoDIMOSA(DataPedidos.CurrentRow.Cells(0).Value, DataPedidos.CurrentRow.Cells(5).Value)
            Dim columnas As Integer
            If DataPedidos.CurrentRow.Cells(6).Value = "PENDIENTE" Then
                columnas = Frm_Completar_Orden_Pedido.DataPedidos.ColumnCount - 3
                'Frm_Completar_Orden_Pedido.btn_aceptar.Enabled = True
                Frm_Completar_Orden_Pedido_DIMOSA.BtnCancelar.Enabled = True
            Else
                columnas = Frm_Completar_Orden_Pedido.DataPedidos.ColumnCount - 1
                'Frm_Completar_Orden_Pedido.btn_aceptar.Enabled = False
                Frm_Completar_Orden_Pedido_DIMOSA.BtnCancelar.Enabled = False
            End If
            For a As Integer = 0 To columnas
                Frm_Completar_Orden_Pedido_DIMOSA.DataPedidos.Columns(a).ReadOnly = True
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Frm_Completar_Orden_Pedido_DIMOSA.MdiParent = _Inicio
        Frm_Completar_Orden_Pedido_DIMOSA.Show()

    End Sub

    Private Sub BtnReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReporte.Click
        Frm_Reporte_Incumplimientos_Proveedores_DIMOSA.MdiParent = _Inicio
        Frm_Reporte_Incumplimientos_Proveedores_DIMOSA.Show()
    End Sub

End Class