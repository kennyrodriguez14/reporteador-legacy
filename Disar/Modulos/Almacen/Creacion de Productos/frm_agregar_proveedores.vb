Imports Disar.data

Public Class frm_agregar_proveedores
    Dim conexion As New cls_nuevo_prod_prov

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub frm_agregar_proveedores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            cmb_empresa.SelectedItem = "SAN RAFAEL"
            txt_forma_pago.SelectedItem = "Transferencia"
            txt_tipo_pago.SelectedItem = "Proveedor Nacional"
            cmb_clasificacion.SelectedItem = "Proveedor"
            cmb_tipo.SelectedItem = "Local"

            txt_codigo.Text = conexion.SELEC(cmb_empresa.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        Try
            Dim dt_parametros As New DataTable
            dt_parametros.Columns.Add("@CLAVE")
            dt_parametros.Columns.Add("@NOMBRE")
            dt_parametros.Columns.Add("@RFC")
            dt_parametros.Columns.Add("@CALLE")
            dt_parametros.Columns.Add("@COLONIA")
            dt_parametros.Columns.Add("@CODIGO")
            dt_parametros.Columns.Add("@LOCALIDAD")
            dt_parametros.Columns.Add("@MUNICIPIO")
            dt_parametros.Columns.Add("@ESTADO")
            dt_parametros.Columns.Add("@NACIONALIDAD")
            dt_parametros.Columns.Add("@TELEFONO")
            dt_parametros.Columns.Add("@CLASIFIC")
            dt_parametros.Columns.Add("@FAX")
            dt_parametros.Columns.Add("@PAG_WEB")
            dt_parametros.Columns.Add("@CURP")
            dt_parametros.Columns.Add("@CON_CREDITO")
            dt_parametros.Columns.Add("@DIASCRED")
            dt_parametros.Columns.Add("@LIMCRED")
            dt_parametros.Columns.Add("@CAI")
            dt_parametros.Columns.Add("@RANGO")
            dt_parametros.Columns.Add("@FECHA")
            dt_parametros.Columns.Add("@RTN")
            dt_parametros.Columns.Add("@PAIS")
            dt_parametros.Columns.Add("@FORMA_PAGO")
            dt_parametros.Columns.Add("@TIPO_TERCERO")
            dt_parametros.Columns.Add("@CONTACTO_PAGO")
            dt_parametros.Columns.Add("@CONTACTO_COMPRA")

            Dim con_credito As String = "", dias_credito As String = ""
            Dim limite_cred As Double = 0
            If txt_manejo_credito.Checked = True Then
                con_credito = "S"
                dias_credito = txt_dias_credito.Value
                limite_cred = txt_limite_credito.Text
            Else
                con_credito = "N"
                dias_credito = 0
                limite_cred = 0
            End If

            Dim codigo_nuevo As String = ""
            Dim ceros As String = ""
            For index As Integer = 0 To (9 - txt_codigo.Text.Length)
                ceros += " "
            Next
            codigo_nuevo = ceros + txt_codigo.Text

            dt_parametros.Rows.Add(codigo_nuevo, txt_nombre.Text, TextDepartamento.Text, txt_calle.Text, txt_municipio.Text, _
                                   DBNull.Value, txt_municipio.Text, DBNull.Value, DBNull.Value, cmb_tipo.Text, txt_telefono.Text, _
                                   cmb_clasificacion.Text.Substring(0, 1), txt_telefono.Text, txt_contacto_compra.Text, DBNull.Value, _
                                   con_credito, dias_credito, limite_cred, txt_cai.Text, txt_rango.Text, txt_fecha_limite.Value, txt_rtn.Text, _
                                   txt_pais.Text, txt_forma_pago.Text, txt_tipo_pago.Text, txt_contacto_pago.Text, txt_contacto_compra.Text)
            Dim resultado As String = ""
            resultado = conexion.Insert(cmb_empresa.Text, dt_parametros, _Inicio.lblUsuario.Text)
            If resultado = "correcto" Then
                Me.Close()
            Else
                MessageBox.Show(resultado)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txt_manejo_credito_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_manejo_credito.CheckedChanged
        Try
            If txt_manejo_credito.Checked = True Then
                txt_limite_credito.Enabled = True
                txt_dias_credito.Enabled = True
            Else
                txt_limite_credito.Enabled = False
                txt_dias_credito.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Me.Close()
    End Sub

    Private Sub cmb_empresa_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_empresa.SelectedIndexChanged
        Try
            txt_codigo.Text = conexion.SELEC(cmb_empresa.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class