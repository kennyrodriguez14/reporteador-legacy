Imports System.Data.SqlClient
Public Class clsayudaClientes_agro
    Dim Conexion As New clsconexion_consumo

    Public Function helper(ByVal CLAVE As String, ByVal NOMBRE As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT CLAVE, NOMBRE, CVE_VEND " & _
                                        "FROM   dbo.CLIE10 " & _
                                        "WHERE  (UPPER(NOMBRE) LIKE '%" + NOMBRE + "%')", ActualizarConexion)
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