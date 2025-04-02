Imports System.Data.SqlClient

Public Class clsMultialmacen
    Dim Conexion As New clsconexion_consumo
    Dim ConexionDimosa As New cls_conexion_DIMOSA

    Public Function GenerarDatos(ByVal Sucursal As String, ByVal linea As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("rptn_Multialmacen", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure

        miComando.Parameters.Add(New SqlParameter("@Sucursal", SqlDbType.VarChar)).Value = Sucursal
        miComando.Parameters.Add(New SqlParameter("@Linea", SqlDbType.VarChar)).Value = linea
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

    Public Function GenerarDatosDimosa(ByVal Sucursal As String, ByVal linea As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionDimosa.CadenaSQL())
        Dim miComando As New SqlCommand("rptn_Multialmacen", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure

        miComando.Parameters.Add(New SqlParameter("@Sucursal", SqlDbType.VarChar)).Value = Sucursal
        miComando.Parameters.Add(New SqlParameter("@Linea", SqlDbType.VarChar)).Value = linea
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

    Public Function CargaAlmacenesDimosa() As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionDimosa.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT CVE_ALM, DESCR FROM ALMACENES06", ActualizarConexion)

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
