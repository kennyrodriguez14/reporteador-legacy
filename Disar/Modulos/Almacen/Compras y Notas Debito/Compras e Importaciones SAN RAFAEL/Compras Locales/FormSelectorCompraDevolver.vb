Imports Disar.data

Public Class FormSelectorCompraDevolver

    Public Tipo As String

    Dim conexion As New cls_notas_debito

    Public cve_compra = "", cve_prov = "", prov = "", fact = "", almacen = "", rfc = ""
    Public fecha = "", desc_por = "", subtotal = "", desc_val = "", isv_val = "", total = ""
    Public estado = "", n_fact_sae = "", sub_most = "", des_most = "", isv_most = "", refer_vesta = ""
    Public total_most = "", flete = "", lote = "", f_vencimiento = "", estado_com = "", otro_prov = ""
    Public tasa_cambio As Double = 0

    Private Sub frm_lista_compras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            ComboBox1.SelectedItem = "CODIGO SAE"
            TextBox1.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txt_busqueda_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        Try
            If e.KeyValue = Keys.Enter Then
                Button1.PerformClick()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cmb_tipo_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedValueChanged
        TextBox1.Text = ""
        TextBox1.Focus()
    End Sub

    Sub seleccionar()
        cve_compra = DataDatos.CurrentRow.Cells(0).Value
        cve_prov = DataDatos.CurrentRow.Cells(1).Value
        prov = DataDatos.CurrentRow.Cells(2).Value
        fact = DataDatos.CurrentRow.Cells(3).Value
        almacen = DataDatos.CurrentRow.Cells(4).Value
        rfc = DataDatos.CurrentRow.Cells(5).Value
        fecha = DataDatos.CurrentRow.Cells(6).Value
        desc_por = DataDatos.CurrentRow.Cells(7).Value
        subtotal = DataDatos.CurrentRow.Cells(8).Value
        desc_val = DataDatos.CurrentRow.Cells(9).Value
        isv_val = DataDatos.CurrentRow.Cells(10).Value
        total = DataDatos.CurrentRow.Cells(11).Value
        estado = DataDatos.CurrentRow.Cells(12).Value
        n_fact_sae = DataDatos.CurrentRow.Cells(13).Value
        sub_most = DataDatos.CurrentRow.Cells(14).Value
        des_most = DataDatos.CurrentRow.Cells(15).Value
        isv_most = DataDatos.CurrentRow.Cells(16).Value
        total_most = DataDatos.CurrentRow.Cells(17).Value
        flete = DataDatos.CurrentRow.Cells(18).Value
        lote = DataDatos.CurrentRow.Cells(19).Value
        f_vencimiento = DataDatos.CurrentRow.Cells(20).Value
        estado_com = DataDatos.CurrentRow.Cells(21).Value
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Sub seleccionar_importar()
        cve_compra = DataDatos.CurrentRow.Cells(0).Value
        cve_prov = DataDatos.CurrentRow.Cells(1).Value
        prov = DataDatos.CurrentRow.Cells(2).Value
        fact = DataDatos.CurrentRow.Cells(3).Value
        almacen = DataDatos.CurrentRow.Cells(4).Value
        rfc = DataDatos.CurrentRow.Cells(5).Value
        fecha = DataDatos.CurrentRow.Cells(6).Value
        desc_por = DataDatos.CurrentRow.Cells(7).Value
        subtotal = DataDatos.CurrentRow.Cells(8).Value
        desc_val = DataDatos.CurrentRow.Cells(9).Value
        isv_val = DataDatos.CurrentRow.Cells(10).Value
        total = DataDatos.CurrentRow.Cells(11).Value
        estado = DataDatos.CurrentRow.Cells(12).Value
        n_fact_sae = DataDatos.CurrentRow.Cells(13).Value
        lote = DataDatos.CurrentRow.Cells(15).Value
        f_vencimiento = DataDatos.CurrentRow.Cells(16).Value
        estado_com = DataDatos.CurrentRow.Cells(17).Value
        tasa_cambio = DataDatos.CurrentRow.Cells(18).Value
        refer_vesta = DataDatos.CurrentRow.Cells(19).Value
        otro_prov = DataDatos.CurrentRow.Cells(20).Value
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub DataDatos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataDatos.KeyDown
        Try
            If e.KeyValue = Keys.Enter Then
                If Tipo = "IMPORTACION" Then
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

    Private Sub DataDatos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataDatos.CellContentClick
        Try
            If Tipo = "IMPORTACION" Then
                seleccionar_importar()
            Else
                seleccionar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Tipo = "IMPORTACION" Then
            DataDatos.DataSource = conexion.lista_importaciones_devolver(TextBox1.Text, ComboBox1.Text)
            DataDatos.Columns(7).Visible = False
            DataDatos.Columns(8).Visible = False
            DataDatos.Columns(9).Visible = False
            DataDatos.Columns(10).Visible = False
            DataDatos.Columns(14).Visible = False
            DataDatos.Columns(15).Visible = False
            DataDatos.Columns(16).Visible = False
            DataDatos.Columns(17).Visible = False
            DataDatos.Columns(18).Visible = False

            If DataDatos.RowCount > 0 Then
                DataDatos.Focus()
            End If
        Else
            DataDatos.DataSource = conexion.lista_Compras_devolver(TextBox1.Text, ComboBox1.Text)
            DataDatos.Columns(4).Visible = False
            DataDatos.Columns(5).Visible = False
            DataDatos.Columns(6).Visible = False
            DataDatos.Columns(7).Visible = False
            DataDatos.Columns(8).Visible = False
            DataDatos.Columns(9).Visible = False
            DataDatos.Columns(10).Visible = False
            DataDatos.Columns(11).Visible = False
            DataDatos.Columns(12).Visible = False
            DataDatos.Columns(13).Visible = False
            DataDatos.Columns(14).Visible = False
            DataDatos.Columns(15).Visible = False
            DataDatos.Columns(16).Visible = False
            DataDatos.Columns(17).Visible = False
            DataDatos.Columns(18).Visible = False
            DataDatos.Columns(19).Visible = False
            DataDatos.Columns(20).Visible = False
            DataDatos.Columns(21).Visible = False

            If DataDatos.RowCount > 0 Then
                DataDatos.Focus()
            End If
        End If
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub
End Class