Imports Disar.data
Public Class frm_facturas_SRAGRO
    Public factura, tipo As String
    Public almacen As Integer
    Public fecha As DateTime, fecha_entrega As DateTime
    Dim conexion As New cls_descuentos_tacticos_sragro
    Public codigo_cliente, cliente, con_credito, codigo_vendedor, vendedor As String
    Private Sub frm_facturas_SRAGRO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
    End Sub
    Private Sub grd_lista_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grd_lista.DoubleClick
        Try
            factura = grd_lista.CurrentRow.Cells(0).Value
            tipo = grd_lista.CurrentRow.Cells(2).Value
            fecha = grd_lista.CurrentRow.Cells(1).Value
            fecha_entrega = grd_lista.CurrentRow.Cells(3).Value
            almacen = grd_lista.CurrentRow.Cells(4).Value
            codigo_cliente = grd_lista.CurrentRow.Cells(5).Value
            cliente = grd_lista.CurrentRow.Cells(6).Value
            con_credito = grd_lista.CurrentRow.Cells(7).Value

            If grd_lista.CurrentRow.Cells(8).Value Is DBNull.Value Then
                codigo_vendedor = ""
            Else
                codigo_vendedor = grd_lista.CurrentRow.Cells(8).Value
            End If

            If grd_lista.CurrentRow.Cells(8).Value Is DBNull.Value Then
                vendedor = ""
            Else
                vendedor = grd_lista.CurrentRow.Cells(9).Value
            End If
            DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txt_codigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_codigo.TextChanged
        cargar()
    End Sub

    Sub cargar()
        Try
            grd_lista.DataSource = conexion.listar_facturas(txt_codigo.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class