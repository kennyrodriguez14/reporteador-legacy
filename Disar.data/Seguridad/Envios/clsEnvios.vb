Imports System.Data.SqlClient
Public Class clsEnvios
    Dim Conexion As New clsConexion
    Public Function CargarEnvios() As DataView
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim AdaptadorDeDatos As New SqlDataAdapter("SELECT [IdReporte],[Formulario],[Reporte],[Envia],[Recibe],[Copia],[Asunto],[Mensaje],[Hora],[Descripcion],[DiasEnvio],[Servidor],[Puerto],[Estado],[Contraseña]" & _
                "FROM [Usuarios].[dbo].[Configuracion]", ActualizarConexion)
        Dim ds As New DataSet
        Dim dv As New DataView
        ActualizarConexion.Open()
        Try
            AdaptadorDeDatos.Fill(ds, "Configuracion")
            If ds.Tables("Configuracion").Rows.Count > 0 Then
                dv = New DataView(ds.Tables("Configuracion"))
            End If
        Catch ex As SqlException
            MsgBox("Hay problemas de Conexión: " + ex.Message, MsgBoxStyle.Critical)
        End Try
        ActualizarConexion.Close()
        Return dv
    End Function

    Public Function Modificar(ByVal Id As Integer, ByVal Formu As String, ByVal Repor As String, ByVal Envia As String, ByVal Recibe As String, _
                    ByVal Copia As String, ByVal Asunto As String, ByVal Mensaje As String, ByVal Hora As String, ByVal Descripcion As String, _
                    ByVal Dias As String, ByVal Server As String, ByVal port As String, ByVal Estado As String, ByVal pass As String) As Boolean
        Dim Fallo As Boolean = False
        Try
            Using CadenaConexion As New SqlConnection(Conexion.CadenaSQL())

                Const SQL As String = "UPDATE [Usuarios].[dbo].[Configuracion] " & _
                "SET [Formulario] = @formu,[Reporte] = @repor,[Envia] = @envia,[Recibe] = @recibe,[Copia] = @copia,[Asunto] = @asunto" & _
                ",[Mensaje] = @mensaje,[Hora] = @hora,[Descripcion] = @descripcion,[DiasEnvio] = @dias,[Servidor] = @server," & _
                "[Puerto] = @port,[Estado] = @estado,[Contraseña] = @pass " & _
                "WHERE  IdReporte = @id"

                Dim AddDatos As New SqlCommand(SQL, CadenaConexion)
                AddDatos.Parameters.AddWithValue("@id", Id)
                AddDatos.Parameters.AddWithValue("@formu", Formu)
                AddDatos.Parameters.AddWithValue("@repor", Repor)
                AddDatos.Parameters.AddWithValue("@envia", Envia)
                AddDatos.Parameters.AddWithValue("@recibe", Recibe)
                AddDatos.Parameters.AddWithValue("@copia", Copia)
                AddDatos.Parameters.AddWithValue("@asunto", Asunto)
                AddDatos.Parameters.AddWithValue("@mensaje", Mensaje)
                AddDatos.Parameters.AddWithValue("@hora", Hora)
                AddDatos.Parameters.AddWithValue("@descripcion", Descripcion)
                AddDatos.Parameters.AddWithValue("@dias", Dias)
                AddDatos.Parameters.AddWithValue("@server", Server)
                AddDatos.Parameters.AddWithValue("@port", port)
                AddDatos.Parameters.AddWithValue("@estado", Estado)
                AddDatos.Parameters.AddWithValue("@pass", pass)
                CadenaConexion.Open()
                AddDatos.ExecuteNonQuery()
                CadenaConexion.Close()
                Fallo = True
            End Using
            Return Fallo
        Catch SqlEX As SqlException
            MsgBox(SqlEX.Message)
            Return Fallo
        End Try
    End Function
End Class