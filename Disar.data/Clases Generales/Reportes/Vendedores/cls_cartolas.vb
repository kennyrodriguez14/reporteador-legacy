Imports System.Data.SqlClient
Public Class cls_cartolas
    Dim Conexion As New clsconexion_consumo
    Public Function GenerarCartola(ByVal DESDE As Date, ByVal HASTA As Date, ByVal SUCURSAL As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("rptn_libro_rutas", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@AÑO_INI", SqlDbType.Date)).Value = DESDE
        miComando.Parameters.Add(New SqlParameter("@AÑO_FIN", SqlDbType.Date)).Value = HASTA
        miComando.Parameters.Add(New SqlParameter("@SUCURSAL", SqlDbType.VarChar)).Value = SUCURSAL
        miComando.CommandTimeout = 1000
        ActualizarConexion.Open()
        Dim AdaptadorDeDatos As New SqlDataAdapter(miComando)
        Dim dt As New DataTable
        Try
            AdaptadorDeDatos.Fill(dt)
            ActualizarConexion.Close()
        Catch ex As SqlException
            MsgBox("Hay un problema con la conexión a los datos " & ex.Message, MsgBoxStyle.Critical)
            ActualizarConexion.Close()
        End Try
        Return dt
    End Function
End Class
