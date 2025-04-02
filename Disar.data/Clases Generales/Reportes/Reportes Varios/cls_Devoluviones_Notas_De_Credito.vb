Imports System.Data.SqlClient
Public Class cls_Devoluviones_Notas_De_Credito
    Dim Conexion As New clsconexion_consumo
    Dim Conexion2 As New cls_conexion_DIMOSA
    Dim ConexionOPL As New cls_conexionOPL

    Public Function Devoluciones(ByVal DESDE As Date, ByVal HASTA As Date, ByVal SUCURSAL As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_devoluciones_descuentos", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.Date)).Value = DESDE
        miComando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.Date)).Value = HASTA
        miComando.Parameters.Add(New SqlParameter("@SUCURSAL", SqlDbType.VarChar)).Value = SUCURSAL
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

    Public Function DevolucionesOPL(ByVal DESDE As Date, ByVal HASTA As Date, ByVal SUCURSAL As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionOPL.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_devoluciones_descuentos", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.Date)).Value = DESDE
        miComando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.Date)).Value = HASTA
        miComando.Parameters.Add(New SqlParameter("@SUCURSAL", SqlDbType.VarChar)).Value = SUCURSAL
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

    Public Function DevolucionesDIMOSA(ByVal DESDE As Date, ByVal HASTA As Date, ByVal SUCURSAL As Integer) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_devoluciones_descuentos", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.Date)).Value = DESDE
        miComando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.Date)).Value = HASTA
        miComando.Parameters.Add(New SqlParameter("@ALMACEN", SqlDbType.Int)).Value = SUCURSAL
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


    Public Function Almacenes() As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT -1 as CVE_ALM, 'TODOS' AS DESCR UNION ALL SELECT CVE_ALM, DESCR  FROM ALMACENES06", ActualizarConexion)
        
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

    Public Function AlmacenesAA() As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT -1 as CVE_ALM, 'TODOS' AS DESCR UNION ALL SELECT CVE_ALM, DESCR  FROM ALMACENES06 UNION ALL SELECT 100 AS CVE_ALM, 'ALMACENES SANTA ROSA' AS DESCR UNION ALL SELECT 101 AS CVE_ALM, 'ALMACENES SPS' AS DESCR UNION ALL SELECT 102 AS CVE_ALM, 'ALMACENES SABA' AS DESCR ", ActualizarConexion)

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
