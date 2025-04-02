Imports Disar.data
Public Class frm_productos_precios_neg_dimosa
    Dim conexion As New cls_notas_debito
    Public codigo, producto As String
    Public fac_conv, precio_neg, isv_por As Double, peso As Double
    Public proveedor As String, uni_entrada As String
    Public almacen As Integer
    Public con_lote As String
    Private Sub frm_productos_precios_neg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar()
    End Sub


    Sub cargar()
        Try
            grd_lista.DataSource = conexion.listar_productos_DIMOSA(txt_busqueda.Text, proveedor)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txt_busqueda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_busqueda.TextChanged
        cargar()
    End Sub

    Private Sub grd_lista_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grd_lista.DoubleClick
        Try
            aceptar_producto()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub frm_productos_precios_neg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress

        If Asc(e.KeyChar) = Keys.Enter Then
            aceptar_producto()
        End If

    End Sub

    Private Sub grd_lista_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grd_lista.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            aceptar_producto()
        End If
    End Sub

    Private Sub txt_busqueda_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_busqueda.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            aceptar_producto()
        End If
    End Sub

    Sub aceptar_producto()
        Dim dt As New DataTable
        dt = conexion.valida_productos_DIMOSA(grd_lista.CurrentRow.Cells(0).Value, almacen)
        Dim validar As Integer = 0
        validar = dt.Rows(0)(0)


        If grd_lista.CurrentRow.Cells(8).Value <> proveedor Then
            MessageBox.Show("El producto que esta ingresando no pertenece al proveedor seleccionado")
        End If


        If validar < 1 Then
            MessageBox.Show("El producto Seleccionado no esta asignado al Almacen " & almacen, "Producto no Asignado", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
        Else
            codigo = grd_lista.CurrentRow.Cells(0).Value
            producto = grd_lista.CurrentRow.Cells(1).Value
            fac_conv = grd_lista.CurrentRow.Cells(2).Value
            precio_neg = grd_lista.CurrentRow.Cells(3).Value
            isv_por = grd_lista.CurrentRow.Cells(4).Value
            uni_entrada = grd_lista.CurrentRow.Cells(5).Value
            peso = grd_lista.CurrentRow.Cells(6).Value
            con_lote = grd_lista.CurrentRow.Cells(7).Value
            DialogResult = Windows.Forms.DialogResult.OK
        End If
    End Sub
End Class