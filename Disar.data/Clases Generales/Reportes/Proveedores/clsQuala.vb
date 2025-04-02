Imports System.Data.SqlClient

Public Class clsFacturas
    Dim Conexion As New clsconexion_consumo
    Dim Conexion2 As New cls_conexion_DIMOSA

    Public Function GenerarDatos(ByVal Inicio As Date, ByVal fin As Date, ByVal linea As String, ByVal SUCURSAL As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("rptn_ventas_quala", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.Date)).Value = Inicio
        miComando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.Date)).Value = fin
        miComando.Parameters.Add(New SqlParameter("@LINEA", SqlDbType.VarChar)).Value = linea
        miComando.Parameters.Add(New SqlParameter("@SUCURSAL", SqlDbType.VarChar)).Value = SUCURSAL
        ActualizarConexion.Open()
        Dim AdaptadorDeDatos As New SqlDataAdapter(miComando)
        Dim dt As New DataTable

        AdaptadorDeDatos.Fill(dt)
        ActualizarConexion.Close()
        Return dt
    End Function

    Public Function GenerarDatosDimosa(ByVal Inicio As Date, ByVal fin As Date, ByVal linea As String, ByVal SUCURSAL As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim miComando As New SqlCommand("rptn_ventas_quala", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.Date)).Value = Inicio
        miComando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.Date)).Value = fin
        miComando.Parameters.Add(New SqlParameter("@LINEA", SqlDbType.VarChar)).Value = linea
        miComando.Parameters.Add(New SqlParameter("@SUCURSAL", SqlDbType.VarChar)).Value = SUCURSAL
        ActualizarConexion.Open()
        Dim AdaptadorDeDatos As New SqlDataAdapter(miComando)
        Dim dt As New DataTable

        AdaptadorDeDatos.Fill(dt)
        ActualizarConexion.Close()
        Return dt
    End Function
End Class
