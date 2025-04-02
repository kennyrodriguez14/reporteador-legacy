Imports Disar.data
Public Class frm_nd_folios
    Public ult_doc As Double
    Public almacen As Integer
    Public folio As String
    Dim conexion As New cls_notas_debito
    Private Sub frm_nd_folios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar()
    End Sub

    Sub cargar()
        Try
            grd_lista.DataSource = conexion.folios
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub grd_lista_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grd_lista.DoubleClick
        folio = grd_lista.CurrentRow.Cells(0).Value
        almacen = grd_lista.CurrentRow.Cells(1).Value
        ult_doc = grd_lista.CurrentRow.Cells(2).Value
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class