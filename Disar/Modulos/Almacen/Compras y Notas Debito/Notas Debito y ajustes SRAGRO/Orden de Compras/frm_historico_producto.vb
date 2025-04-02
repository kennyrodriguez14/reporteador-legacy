Imports Disar.data

Public Class frm_historico_producto
    Public fecha As Date, fecha_ini As Date
    Dim conexion_notas_debito As New cls_notas_debito_SRAGRO
    Public proveedor As String, codigo As String, producto As String
    Public fac_conv As Int32, cantidad As Int32
    Public isv_por As Double, precio_neg As Double, peso As Double
    Public dias_habiles As Integer
    Public dias_autorizados As Integer
    Public almacen As Integer

    Private Sub grd_producto_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grd_producto.DoubleClick
        Try
            txt_codigo.Text = grd_producto.CurrentRow.Cells(0).Value
            If almacen = 1 Then
                txt_existencia_gracias.Text = 0
                txt_existencia_src.Text = grd_producto.CurrentRow.Cells(7).Value
                txt_existencia_cd.Text = grd_producto.CurrentRow.Cells(9).Value
                txt_existencia.Text = grd_producto.CurrentRow.Cells(7).Value + grd_producto.CurrentRow.Cells(9).Value
                Dim conexion_dia_inve As New cls_notas_debito_SRAGRO
                Try
                    txt_dias_inve.Text = Val(txt_existencia.Text) / conexion_dia_inve.dias_inventario(txt_codigo.Text, fecha, 1)
                Catch ex As Exception
                    txt_dias_inve.Text = 0
                End Try
            ElseIf almacen = 2 Then
                txt_existencia_gracias.Text = grd_producto.CurrentRow.Cells(8).Value
                txt_existencia_src.Text = 0
                txt_existencia_cd.Text = 0
                txt_existencia.Text = grd_producto.CurrentRow.Cells(8).Value
                Dim conexion_dia_inve As New cls_notas_debito_SRAGRO
                Try
                    txt_dias_inve.Text = Val(txt_existencia.Text) / conexion_dia_inve.dias_inventario(txt_codigo.Text, fecha, 2)
                Catch ex As Exception
                    txt_dias_inve.Text = 0
                End Try
            ElseIf almacen = 3 Then
                txt_existencia_gracias.Text = 0
                txt_existencia_src.Text = grd_producto.CurrentRow.Cells(7).Value
                txt_existencia_cd.Text = grd_producto.CurrentRow.Cells(9).Value
                txt_existencia.Text = grd_producto.CurrentRow.Cells(7).Value + grd_producto.CurrentRow.Cells(9).Value
                Dim conexion_dia_inve As New cls_notas_debito_SRAGRO
                Try
                    txt_dias_inve.Text = Val(txt_existencia.Text) / conexion_dia_inve.dias_inventario(txt_codigo.Text, fecha, 1)
                Catch ex As Exception
                    txt_dias_inve.Text = 0
                End Try
            End If

            txt_producto.Text = grd_producto.CurrentRow.Cells(1).Value
            txt_precio_neg.Text = grd_producto.CurrentRow.Cells(2).Value
            txt_dias_hab.Text = dias_habiles
            codigo = txt_codigo.Text
            producto = txt_producto.Text
            txt_dias_aut.Text = dias_autorizados
            cmb_uni.SelectedItem = "cj"
            If IsNumeric(grd_producto.CurrentRow.Cells(2).Value) Then
                precio_neg = grd_producto.CurrentRow.Cells(2).Value
            Else

            End If

            isv_por = grd_producto.CurrentRow.Cells(5).Value
            fac_conv = grd_producto.CurrentRow.Cells(6).Value

            fecha = "01/" & fecha.Month & "/" & fecha.Year
            fecha = fecha.AddDays(-1)
            fecha_ini = "01/" & fecha.AddMonths(-12).Month & "/" & fecha.AddMonths(-12).Year

            grd_precios.DataSource = conexion_notas_debito.historico_productos(fecha_ini, fecha, grd_producto.CurrentRow.Cells(0).Value)
            'Dim prom_anual As Double = 0
            Dim prom_trimeste As Double = 0
            For index As Integer = 0 To grd_precios.RowCount - 1
                'prom_anual += grd_precios.Rows(index).Cells(2).Value
                If index > (grd_precios.RowCount - 4) Then
                    prom_trimeste += grd_precios.Rows(index).Cells(2).Value
                End If
            Next
            'txt_dias_inve.Text = Math.Round(prom_anual / 12, 0)

            Try
                txt_sugtri.Text = Math.Round((Math.Round(prom_trimeste / 3, 0) / Val(txt_dias_hab.Text)) * Val(txt_dias_aut.Text), 0)
            Catch ex As Exception
                txt_sugtri.Text = 0
            End Try

            Try
                txt_pedido.Text = Val(txt_sugtri.Text) - Val(txt_existencia.Text)
            Catch ex As Exception
                txt_pedido.Text = 0
            End Try

            peso = grd_producto.CurrentRow.Cells(4).Value
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        informacion()
    End Sub

    Public Sub informacion()
        grp_filtros.Visible = False
        grp_datos_producto.Visible = True
    End Sub

    Private Sub grd_producto_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles grd_producto.KeyPress
        If e.KeyChar = Keys.Enter.ToString() Then
            informacion()
        End If
    End Sub

    Sub limpiar()
        txt_dias_hab.Text = ""
        txt_dias_aut.Text = ""
        txt_dias_inve.Text = ""
        txt_sugtri.Text = ""
        txt_existencia_gracias.Text = ""
        txt_existencia_src.Text = ""
        txt_existencia_cd.Text = ""
        txt_existencia.Text = ""
        txt_pedido.Text = ""
        txt_precio_neg.Text = ""
    End Sub

    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        Try
            cantidad = txt_pedido.Text
            Try
                If cantidad > 0 Then
                    If txt_codigo.Text = "" Or cantidad <= 0 Then
                        MessageBox.Show("Ingrese todos los datos del producto")
                    Else
                        Dim subtotal As Double = 0
                        Dim descuento As Double = 0
                        Dim isv As Double = 0
                        Dim total As Double = 0
                        If cmb_uni.SelectedItem = "cj" Then
                            subtotal = fac_conv * Val(txt_precio_neg.Text) * cantidad
                            descuento = subtotal * (Val(frm_orden_pedidos_sragro.txt_descuento_general.Text) / 100)
                            isv = (subtotal - descuento) * (isv_por / 100)
                            total = subtotal - descuento + isv
                        ElseIf cmb_uni.SelectedItem = "pz" Then
                            subtotal = Val(txt_precio_neg.Text) * cantidad
                            descuento = subtotal * (Val(frm_orden_pedidos_sragro.txt_descuento_general.Text) / 100)
                            isv = (subtotal - descuento) * (isv_por / 100)
                            total = subtotal - descuento + isv
                        End If
                        frm_orden_pedidos_sragro.grd_ingreso.Rows.Add(cmb_uni.SelectedItem, txt_codigo.Text, txt_producto.Text, fac_conv, _
                                             cantidad, Val(txt_precio_neg.Text), Val(frm_orden_pedidos_sragro.txt_descuento_general.Text), _
                                         isv_por, subtotal, descuento, isv, total, peso * cantidad)
                        frm_orden_pedidos_sragro.sumar_totales()
                        grp_filtros.Visible = True
                        grp_datos_producto.Visible = False
                        cargar()
                        limpiar()
                    End If
                Else
                    MessageBox.Show("Ingrese una cantidad mayor que 0")
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        grp_filtros.Visible = True
        grp_datos_producto.Visible = False
    End Sub

    Private Sub frm_historico_producto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar()
        calcular_dias_habiles()
    End Sub

    Private Sub txt_buqueda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_buqueda.TextChanged
        cargar()
    End Sub

    Sub cargar()
        Try
            Dim codigos_no_mostrar As String = ""

            If frm_orden_pedidos_sragro.grd_ingreso.Rows.Count > 0 Then
                codigos_no_mostrar = ""
            Else
                codigos_no_mostrar = "''"
            End If

            For index As Integer = 0 To frm_orden_pedidos_sragro.grd_ingreso.Rows.Count - 1
                codigos_no_mostrar += "'"
                codigos_no_mostrar += frm_orden_pedidos_sragro.grd_ingreso.Rows(index).Cells(1).Value
                If index = frm_orden_pedidos_sragro.grd_ingreso.Rows.Count - 1 Then
                    codigos_no_mostrar += "'"
                Else
                    codigos_no_mostrar += "',"
                End If
            Next
            grd_producto.DataSource = conexion_notas_debito.filtros(txt_buqueda.Text, proveedor, codigos_no_mostrar)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub frm_historico_producto_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If Asc(e.KeyChar) = Keys.Escape Then
            Form.ActiveForm.Close()
        End If
    End Sub

    Sub calcular_dias_habiles()
        Dim dias_tot As Integer = Date.DaysInMonth(Now.Year, Now.Month)

        Dim fecha As Date
        Dim tot_sabados As Integer
        For index As Integer = 1 To dias_tot
            fecha = Convert.ToDateTime(index & "/" & Now.Month & "/" & Now.Year)
            If fecha.DayOfWeek = DayOfWeek.Saturday Then
                tot_sabados += 1
            End If
        Next
        dias_habiles = dias_tot - tot_sabados
    End Sub
End Class