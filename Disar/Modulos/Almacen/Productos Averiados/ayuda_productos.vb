Imports Disar.data

Public Class ayuda_producto_malas_cargas

    Dim conexion As New clsayudaProductos
    Public Empresa As String

    Private Sub txtBusqueda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBusqueda.TextChanged
        If Empresa = "SAN RAFAEL" Then
            grdProducto.DataSource = conexion.helper(Val(txtBusqueda.Text), txtBusqueda.Text.ToUpper)
        Else
            grdProducto.DataSource = conexion.helper_dimosa(Val(txtBusqueda.Text), txtBusqueda.Text.ToUpper)
        End If

    End Sub

    Private Sub ayuda_productos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtBusqueda.Text = ""
        If Empresa = "SAN RAFAEL" Then
            grdProducto.DataSource = conexion.helper(Val(txtBusqueda.Text), txtBusqueda.Text.ToUpper)
        Else
            grdProducto.DataSource = conexion.helper_dimosa(Val(txtBusqueda.Text), txtBusqueda.Text.ToUpper)
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            frmProductosAveriados.new_linea(grdProducto.CurrentRow.Cells(0).Value, grdProducto.CurrentRow.Cells(1).Value, grdProducto.CurrentRow.Cells(2).Value)
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub grdProducto_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdProducto.DoubleClick
        Try
            frmProductosAveriados.new_linea(grdProducto.CurrentRow.Cells(0).Value, grdProducto.CurrentRow.Cells(1).Value, grdProducto.CurrentRow.Cells(2).Value)
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ayuda_producto_malas_cargas_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If
    End Sub

End Class