Imports Disar.data

Public Class frm_reporte_devoluciones_SRAgro

    Dim conexion As New cls_devolucionesAgro
    Dim documento As String = ""
    Dim documento2 As String = ""

    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        Try
            cargar_correlativos()
            grd_reporte.DataSource = conexion.lista_encabezados_devoluciones(cmb_fecha_ini.Value, cmb_sucursal.SelectedValue, _
                                                       "RESUMEN_DEVOLUCIONES_LIQ", documento, documento2, "")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub frm_reporte_devoluciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_almacen()
    End Sub

    Sub cargar_almacen()
        Try
            cmb_sucursal.DataSource = conexion.ListarAlmacenes2()
            cmb_sucursal.ValueMember = "ID"
            cmb_sucursal.DisplayMember = "ALMACEN"

            cargar_folios()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub cargar_folios()
        Try
            Dim tabla_folio As New System.Data.DataTable
            tabla_folio = conexion.Listarfolios(cmb_sucursal.SelectedValue)
            txt_folio.Text = tabla_folio.Rows(0)(0)
        Catch ex As Exception

        End Try
    End Sub

    Sub cargar_correlativos()
        Dim serie As String = ""
        Dim ult_doc As Integer = 0
        documento = ""
        serie = txt_folio.Text
        ult_doc = txt_factura_inicial.Text
        Dim ceros As String = ""
        For cont As Integer = 1 To 8 - Convert.ToString(ult_doc).Length
            ceros += "0"
        Next
        documento = serie + ceros + Convert.ToString(ult_doc)
        txt_factura_inicial.Text = Convert.ToString(ult_doc)
        'lbl_docini.Text = documento

        Dim serie2 As String = ""
        Dim ult_doc2 As Integer = 0
        documento2 = ""
        serie2 = txt_folio.Text
        ult_doc2 = txt_factura_final.Text
        Dim ceros2 As String = ""
        For cont As Integer = 1 To 8 - Convert.ToString(ult_doc2).Length
            ceros2 += "0"
        Next
        documento2 = serie2 + ceros2 + Convert.ToString(ult_doc2)
        txt_factura_final.Text = Convert.ToString(ult_doc2)
        'lbl_docfin.Text = documento2
    End Sub

    Private Sub cmb_sucursal_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_sucursal.SelectedIndexChanged
        cargar_folios()
    End Sub

End Class