Public Class frmGuardarArchivo
    Public Formulario As String = ""
    Private Sub btnEspecificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEspecificar.Click
        Try
            With BuscarCarpeta
                .Reset()
                .Description = " Seleccionar una carpeta "
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                Dim ret As DialogResult = .ShowDialog
                If ret = Windows.Forms.DialogResult.OK Then
                    lblruta.Text = .SelectedPath
                End If
            End With
        Catch oe As Exception
            MsgBox(oe.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Formulario = "Resumen" Then
            Me.Visible = False
            Resumen.exportarTXT(lblruta.Text)
            Me.Close()
        ElseIf Formulario = "Rentabilidad" Then
            Me.Visible = False
            Rentabilidad.exportarTXT(lblruta.Text)
            Me.Close()
        ElseIf Formulario = "ColgateGeneral" Then
            Me.Visible = False
            General.exportarTXT(lblruta.Text)
            Me.Close()
        ElseIf Formulario = "Rentabilidad_2" Then
            Me.Visible = False
            Rentabilidad_por_Producto.exportarTXT(lblruta.Text)
            Me.Close()
        ElseIf Formulario = "Quala" Then
            Me.Visible = False
            Quala.exportarTXT(lblruta.Text)
            Me.Close()
        ElseIf Formulario = "Pivot" Then
            Me.Visible = False
            frm_pivot_ventas.exportarTXT(lblruta.Text)
            Me.Close()
        ElseIf Formulario = "sell_out_general" Then
            Me.Visible = False
            frm_sell_out_general.exportarTXT(lblruta.Text)
            Me.Close()
        ElseIf Formulario = "sell_out_general_quintales" Then
            Me.Visible = False
            frm_sell_out_quintales.exportarTXT(lblruta.Text)
            Me.Close()
        ElseIf Formulario = "sell_out_general_SRAGRO" Then
            Me.Visible = False
            frm_sell_out_general_sr_agro.exportarTXT(lblruta.Text)
            Me.Close()
        ElseIf Formulario = "sell_out_colombina" Then
            Me.Visible = False
            frm_sell_out_colombina.exportarTXT(lblruta.Text)
            Me.Close()
        ElseIf Formulario = "Venta_Perdida_Venta_Baja" Then
            Me.Visible = False
            FrmClientesVenta.exportarTXT(lblruta.Text)
            Me.Close()
        ElseIf Formulario = "Venta_Perdida_Venta_Baja_AGRO" Then
            Me.Visible = False
            FrmClientesVenta.exportarTXT_AGRO(lblruta.Text)
            Me.Close()
        ElseIf Formulario = "libro_ventas" Then
            Me.Visible = False
            frm_libro_ventas.exportarTXT(lblruta.Text)
            Me.Close()
        ElseIf Formulario = "kardex" Then
            Me.Visible = False
            FormKardex.exportarTXT(lblruta.Text)
            Me.Close()
        ElseIf Formulario = "Comisiones_Detallado" Then
            Me.Visible = False
            comisiones_detallado.exportarTXT1(lblruta.Text)
            comisiones_detallado.exportarTXT2(lblruta.Text)
            comisiones_detallado.exportarTXT3(lblruta.Text)
            Me.Close()
        ElseIf Formulario = "sell_out_nestle" Then
            Me.Visible = False
            frm_sell_out_nestle.exportarTXT(lblruta.Text)
            Me.Close()
        ElseIf Formulario = "sell_out_general_dimosa" Then
            Me.Visible = False
            frm_sell_out_general_dimosa.exportarTXT(lblruta.Text)
            Me.Close()
        ElseIf Formulario = "sell_out_rentabilidad" Then
            Me.Visible = False
            frm_sell_out_rentabilidad.exportarTXT(lblruta.Text)
            Me.Close()
        ElseIf Formulario = "sell_proveedor" Then
            Me.Visible = False
            frm_sell_out_general_proveedor.exportarTXT(lblruta.Text)
            Me.Close()
        ElseIf Formulario = "Universo" Then
            Me.Visible = False
            FrmUniverso.exportarTXT(lblruta.Text)
            Me.Close()
        ElseIf Formulario = "Clientes_Riesgo" Then
            Me.Visible = False
            FrmClientesVenta.exportarTXTClientes(lblruta.Text)
            Me.Close()
        ElseIf Formulario = "Resumen_Descuentos_Tacticos" Then
            Me.Visible = False
            frm_resumen_des_tac.exportarTXT(lblruta.Text)
            Me.Close()
        ElseIf Formulario = "Resumen_Descuentos_Tacticos_Dimosa" Then
            Me.Visible = False
            frm_resumen_des_tac_dimosa.exportarTXT(lblruta.Text)
            Me.Close()
        ElseIf Formulario = "sell_out_mondelez" Then
            Me.Visible = False
            Sellout_Mondelez.exportarTXT(lblruta.Text)
            Me.Close()
        ElseIf Formulario = "sell_out_mondelez2" Then
            Me.Visible = False
            Sellout_Mondelez.exportarTXT2(lblruta.Text)
            Me.Close()
        ElseIf Formulario = "sell_out_mondelez_archivos" Then
            Me.Visible = False
            Sellout_Mondelez.exportarArchivosMondelez(lblruta.Text)
            Me.Close()
        ElseIf Formulario = "Resumen_Descuentos_Tacticos_OPL" Then
            Me.Visible = False
            frm_resumen_des_tac_opl.exportarTXT(lblruta.Text)
            Me.Close()
        ElseIf Formulario = "sell_out_general_OPL" Then
            Me.Visible = False
            frm_sell_out_general_opl.exportarTXT(lblruta.Text)
            Me.Close()
        End If
    End Sub
End Class