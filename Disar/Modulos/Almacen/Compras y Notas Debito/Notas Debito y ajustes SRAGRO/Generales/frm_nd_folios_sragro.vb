Imports Disar.data
Public Class frm_nd_folios_sragro
    Public ult_doc As Double
    Public almacen As Integer
    Public folio As String
    Dim conexion As New cls_notas_debito_SRAGRO
    Private Sub frm_nd_folios_sragro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar()
    End Sub

    Sub cargar()
        Try
            grd_lista.DataSource = conexion.folios
            grd_lista.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub grd_lista_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grd_lista.DoubleClick
        seleccionar()
    End Sub

    Sub seleccionar()
        folio = grd_lista.CurrentRow.Cells(0).Value
        almacen = grd_lista.CurrentRow.Cells(1).Value
        ult_doc = grd_lista.CurrentRow.Cells(2).Value
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub grd_lista_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles grd_lista.KeyPress
       
    End Sub

    Private Sub grd_lista_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grd_lista.KeyDown
        If e.KeyCode = Keys.Enter Then
            seleccionar()
        End If
    End Sub

    Private Sub frm_nd_folios_sragro_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If Asc(e.KeyChar) = Keys.Escape Then
            Form.ActiveForm.Close()
        End If
    End Sub
End Class