Imports System.Data.SqlClient
Public Class clsayudaClientes
    Dim Conexion As New clsconexion_consumo
    Dim Conexion2 As New clsconexion_sr_agro
    Dim ConexionDimosa As New cls_conexion_DIMOSA

    Public Function helper(ByVal CLAVE As String, ByVal NOMBRE As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT CLAVE, NOMBRE, CVE_VEND " & _
                                        "FROM   dbo.CLIE05 " & _
                                        "WHERE  (UPPER(NOMBRE) LIKE '%" + NOMBRE + "%') OR (LTRIM(CLAVE) = '" & CLAVE & "')", ActualizarConexion)
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

    Public Function helper_dimosa(ByVal CLAVE As String, ByVal NOMBRE As String)
        Dim ActualizarConexion As New SqlConnection(ConexionDimosa.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT CLAVE, NOMBRE, CVE_VEND " & _
                                        "FROM   dbo.CLIE06 " & _
                                        "WHERE  (UPPER(NOMBRE) LIKE '%" + NOMBRE + "%') OR (LTRIM(CLAVE) = '" & CLAVE & "')", ActualizarConexion)
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

    Public Function helper_agro(ByVal CLAVE As String, ByVal NOMBRE As String)
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT CLAVE, NOMBRE, CVE_VEND " & _
                                        "FROM   dbo.CLIE02 " & _
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