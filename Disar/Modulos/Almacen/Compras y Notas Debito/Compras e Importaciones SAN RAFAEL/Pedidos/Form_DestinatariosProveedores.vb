Imports Disar.data

Public Class Form_DestinatariosProveedores

    Public Empresa As String
    Public Proveedor As String

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim db As New cls_compras_pedidos
        Dim dt As New DataTable

        dt.Columns.Add("CORREO")
        dt.Columns.Add("TIPO")

        For Each ROW As DataGridViewRow In DataGridView1.Rows
            dt.Rows.Add(ROW.Cells(0).Value, ROW.Cells(1).Value)
        Next

        Dim s = db.CambiarCorreos(TextProveedorID.Text, TextProveedor.Text, TextEmpresa.Text, dt, _Inicio.lblUsuario.Text)
        If s = "S" Then
            MsgBox("Correos actualizados exitosamente")
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Else
            MsgBox("Error " & s)
        End If

    End Sub

End Class