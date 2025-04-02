Imports System.IO
Public Class Configuracion

    Private Sub btnCambiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCambiar.Click
        _grpDatos.Visible = True
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

    End Sub

    Private Sub Configuracion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cargar()
    End Sub

    Sub Cargar()
        Try
            Dim leer As New StreamReader("INIConfig.dll")
            Dim texto As String = ""
            Dim count As Integer = 5
            Dim split As String() = Nothing
            While (Not texto Is Nothing)
                texto = leer.ReadLine()
                If (Not texto Is Nothing) Then
                    split = texto.Split(New Char() {","}, count)
                    DataGridView1.Rows.Add(split(0), split(1), split(2), split(3), split(4))
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class