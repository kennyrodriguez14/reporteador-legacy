Imports Disar.data
Public Class frm_facturas_dimosa
    Public codigo, factura, tipo, cod_cliente, cliente, cod_vendedor, vendedor, cod_entregador, entregador, vehiculo As String
    Public almacen As Integer
    Public fecha As DateTime, fecha_entrega As DateTime, fecha_ven As DateTime
    Dim conexion As New cls_descuentos_tacticos
    Public condicion As String, rfc As String, autoanio As String
    Public folio As Integer, autoriza As Integer
    Dim conexion_devoluciones As New cls_devoluciones

    Public con_credito As String
    Private Sub frm_facturas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            cmb_folio.DataSource = conexion.folio_facturacionDimosa()
            cmb_folio.ValueMember = "FOLIO"
            cmb_folio.DisplayMember = "FOLIO"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        txt_numero_factura.Focus()
        Try
            If con_credito = "S" Then
                grd_lista.DataSource = conexion.listar_facturasDimosa(codigo)
            ElseIf con_credito = "devolucion" Then
                lbl_factura.Visible = True
                txt_numero_factura.Visible = True
                txt_numero_factura.Focus()
            Else
                grd_lista.DataSource = conexion.listar_facturas_top1_dimosa(codigo)
            End If
            txt_numero_factura.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub grd_lista_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grd_lista.DoubleClick
        Try
            If con_credito = "devolucion" Then
                Dim validador As Integer = 0
                Dim tabla_valida As New DataTable
                Dim cone_dev As New cls_devoluciones
                Try
                    tabla_valida = cone_dev.Validar_devolucionesDIMOSA(grd_lista.CurrentRow.Cells(0).Value)
                    If tabla_valida.Rows.Count > 0 Then
                        validador = 1
                    End If
                Catch ex As Exception
                    validador = 1
                End Try

                If validador = 0 Then
                    factura = grd_lista.CurrentRow.Cells(0).Value
                    fecha = grd_lista.CurrentRow.Cells(1).Value
                    tipo = grd_lista.CurrentRow.Cells(2).Value
                    fecha_entrega = grd_lista.CurrentRow.Cells(3).Value
                    almacen = grd_lista.CurrentRow.Cells(4).Value
                    cod_cliente = grd_lista.CurrentRow.Cells(5).Value
                    cliente = grd_lista.CurrentRow.Cells(6).Value
                    cod_vendedor = grd_lista.CurrentRow.Cells(7).Value
                    vendedor = grd_lista.CurrentRow.Cells(8).Value
                    vehiculo = grd_lista.CurrentRow.Cells(9).Value
                    cod_entregador = grd_lista.CurrentRow.Cells(10).Value
                    entregador = grd_lista.CurrentRow.Cells(11).Value
                    fecha_ven = grd_lista.CurrentRow.Cells(12).Value
                    condicion = grd_lista.CurrentRow.Cells(13).Value
                    If Not IsDBNull(grd_lista.CurrentRow.Cells(14).Value) Then
                        rfc = grd_lista.CurrentRow.Cells(14).Value
                    Else
                        rfc = ""
                    End If

                    autoriza = grd_lista.CurrentRow.Cells(15).Value
                    folio = grd_lista.CurrentRow.Cells(16).Value
                    autoanio = grd_lista.CurrentRow.Cells(17).Value
                    DialogResult = Windows.Forms.DialogResult.OK
                ElseIf validador > 0 Then
                    MessageBox.Show("La Factura ya tiene devolucion")
                End If
            Else
                factura = grd_lista.CurrentRow.Cells(0).Value
                tipo = grd_lista.CurrentRow.Cells(2).Value
                fecha = grd_lista.CurrentRow.Cells(1).Value
                fecha_entrega = grd_lista.CurrentRow.Cells(3).Value
                almacen = grd_lista.CurrentRow.Cells(4).Value
                DialogResult = Windows.Forms.DialogResult.OK
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        Try
            Dim largo As Integer = 0
            largo = txt_numero_factura.Text.Length
            Dim cero As String = ""
            For index As Integer = 1 To 8 - largo
                cero += "0"
            Next
            Dim documento As String = ""

            documento = cmb_folio.SelectedValue + cero + txt_numero_factura.Text
            grd_lista.DataSource = conexion_devoluciones.listar_facturas_devolucionesDimosa(documento)
            grd_lista.Columns(3).Visible = False
            grd_lista.Columns(5).Visible = False
            grd_lista.Columns(7).Visible = False
            grd_lista.Columns(10).Visible = False
            txt_numero_factura.Focus()
            txt_numero_factura.Text = cero + txt_numero_factura.Text
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub cmb_folio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_folio.SelectedIndexChanged
        Dim sucursal As New DataTable
        If cmb_folio.Text = "System.Data.DataRowView" Then
            ''
        Else
            Try
                sucursal = conexion.folio_DocumentosFiscalesDimosa(cmb_folio.Text)
                txt_sucursal.Text = sucursal.Rows(0).Item(0).ToString
            Catch ex As Exception
                txt_sucursal.Text = ""
            End Try

        End If


    End Sub
End Class