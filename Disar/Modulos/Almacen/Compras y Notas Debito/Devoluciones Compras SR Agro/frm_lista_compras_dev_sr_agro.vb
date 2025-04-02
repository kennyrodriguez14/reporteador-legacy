Imports Disar.data

Public Class frm_lista_compras_dev_sr_agro
    Dim conexion As New cls_notas_debito_SRAGRO
    Public tipo_compra As String
    Public cve_compra = "", cve_prov = "", prov = "", fact = "", almacen = "", rfc = ""
    Public fecha = "", desc_por = "", subtotal = "", desc_val = "", isv_val = "", total = ""
    Public estado = "", n_fact_sae = "", sub_most = "", des_most = "", isv_most = "", refer_vesta = ""
    Public total_most = "", flete = "", lote = "", f_vencimiento = "", estado_com = "", otro_prov = ""
    Public tasa_cambio As Double = 0
    Private Sub frm_lista_compras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            cmb_tipo.SelectedItem = "Codigo SAE"
            txt_busqueda.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txt_busqueda_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_busqueda.KeyDown
        Try
            If e.KeyValue = Keys.Enter Then
                If tipo_compra = "imp" Then
                    grd_lista.DataSource = conexion.lista_importaciones_devolver(txt_busqueda.Text, cmb_tipo.SelectedItem)
                    grd_lista.Columns(7).Visible = False
                    grd_lista.Columns(8).Visible = False
                    grd_lista.Columns(9).Visible = False
                    grd_lista.Columns(10).Visible = False
                    grd_lista.Columns(14).Visible = False
                    grd_lista.Columns(15).Visible = False
                    grd_lista.Columns(16).Visible = False
                    grd_lista.Columns(17).Visible = False
                    grd_lista.Columns(18).Visible = False

                    If grd_lista.RowCount > 0 Then
                        grd_lista.Focus()
                    End If
                Else
                    grd_lista.DataSource = conexion.lista_Compras_devolver(txt_busqueda.Text, cmb_tipo.SelectedItem)
                    grd_lista.Columns(4).Visible = False
                    grd_lista.Columns(5).Visible = False
                    grd_lista.Columns(6).Visible = False
                    grd_lista.Columns(7).Visible = False
                    grd_lista.Columns(8).Visible = False
                    grd_lista.Columns(9).Visible = False
                    grd_lista.Columns(10).Visible = False
                    grd_lista.Columns(11).Visible = False
                    grd_lista.Columns(12).Visible = False
                    grd_lista.Columns(13).Visible = False
                    grd_lista.Columns(14).Visible = False
                    grd_lista.Columns(15).Visible = False
                    grd_lista.Columns(16).Visible = False
                    grd_lista.Columns(17).Visible = False
                    grd_lista.Columns(18).Visible = False
                    grd_lista.Columns(19).Visible = False
                    grd_lista.Columns(20).Visible = False
                    grd_lista.Columns(21).Visible = False

                    If grd_lista.RowCount > 0 Then
                        grd_lista.Focus()
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cmb_tipo_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_tipo.SelectedValueChanged
        txt_busqueda.Text = ""
        txt_busqueda.Focus()
    End Sub

    Sub seleccionar()
        cve_compra = grd_lista.CurrentRow.Cells(0).Value
        cve_prov = grd_lista.CurrentRow.Cells(1).Value
        prov = grd_lista.CurrentRow.Cells(2).Value
        fact = grd_lista.CurrentRow.Cells(3).Value
        almacen = grd_lista.CurrentRow.Cells(4).Value
        rfc = grd_lista.CurrentRow.Cells(5).Value
        fecha = grd_lista.CurrentRow.Cells(6).Value
        desc_por = grd_lista.CurrentRow.Cells(7).Value
        subtotal = grd_lista.CurrentRow.Cells(8).Value
        desc_val = grd_lista.CurrentRow.Cells(9).Value
        isv_val = grd_lista.CurrentRow.Cells(10).Value
        total = grd_lista.CurrentRow.Cells(11).Value
        estado = grd_lista.CurrentRow.Cells(12).Value
        n_fact_sae = grd_lista.CurrentRow.Cells(13).Value
        sub_most = grd_lista.CurrentRow.Cells(14).Value
        des_most = grd_lista.CurrentRow.Cells(15).Value
        isv_most = grd_lista.CurrentRow.Cells(16).Value
        total_most = grd_lista.CurrentRow.Cells(17).Value
        flete = grd_lista.CurrentRow.Cells(18).Value
        lote = grd_lista.CurrentRow.Cells(19).Value
        f_vencimiento = grd_lista.CurrentRow.Cells(20).Value
        estado_com = grd_lista.CurrentRow.Cells(21).Value
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Sub seleccionar_importar()
        cve_compra = grd_lista.CurrentRow.Cells(0).Value
        cve_prov = grd_lista.CurrentRow.Cells(1).Value
        prov = grd_lista.CurrentRow.Cells(2).Value
        fact = grd_lista.CurrentRow.Cells(3).Value
        almacen = grd_lista.CurrentRow.Cells(4).Value
        rfc = grd_lista.CurrentRow.Cells(5).Value
        fecha = grd_lista.CurrentRow.Cells(6).Value
        desc_por = grd_lista.CurrentRow.Cells(7).Value
        subtotal = grd_lista.CurrentRow.Cells(8).Value
        desc_val = grd_lista.CurrentRow.Cells(9).Value
        isv_val = grd_lista.CurrentRow.Cells(10).Value
        total = grd_lista.CurrentRow.Cells(11).Value
        estado = grd_lista.CurrentRow.Cells(12).Value
        n_fact_sae = grd_lista.CurrentRow.Cells(13).Value
        lote = grd_lista.CurrentRow.Cells(15).Value
        f_vencimiento = grd_lista.CurrentRow.Cells(16).Value
        estado_com = grd_lista.CurrentRow.Cells(17).Value
        tasa_cambio = grd_lista.CurrentRow.Cells(18).Value
        refer_vesta = grd_lista.CurrentRow.Cells(19).Value
        otro_prov = grd_lista.CurrentRow.Cells(20).Value
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub grd_lista_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grd_lista.KeyDown
        Try
            If e.KeyValue = Keys.Enter Then
                If tipo_compra = "imp" Then
                    seleccionar_importar()
                Else
                    seleccionar()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub limpiar_variables()
        Try
            cve_compra = ""
            cve_prov = ""
            prov = ""
            fact = ""
            almacen = ""
            rfc = ""
            fecha = ""
            desc_por = ""
            subtotal = ""
            desc_val = ""
            isv_val = ""
            total = ""
            estado = ""
            n_fact_sae = ""
            sub_most = ""
            des_most = ""
            isv_most = ""
            total_most = ""
            flete = ""
            lote = ""
            f_vencimiento = ""
            estado_com = ""
            refer_vesta = ""
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub grd_lista_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grd_lista.CellContentClick
        Try
            If tipo_compra = "imp" Then
                seleccionar_importar()
            Else
                seleccionar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

   
End Class