Imports System.Data.SqlClient

Public Class cls_almacen
    Dim Conexion As New clsconexion_consumo
    Dim Conexion2 As New clsconexion_sr_agro
    Dim ConexionDimosa As New cls_conexion_DIMOSA

    Public Function get_almacen()
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT -1 AS ID, 'TODAS' AS ALMACEN UNION ALL select CVE_ALM AS ID, DESCR AS ALMACEN from ALMACENES05", ActualizarConexion)
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

    Public Function get_almacen_Agro()
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT -1 AS ID, 'TODAS' AS ALMACEN UNION ALL select CVE_ALM AS ID, DESCR AS ALMACEN from ALMACENES02", ActualizarConexion)
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

    Public Function get_almacen_SIP()
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT CVE_ALM AS ID, DESCR AS ALMACEN from ALMACENES05", ActualizarConexion)
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

    Public Function get_Todosalmacen()
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT -1 AS ID, 'TODAS' AS ALMACEN", ActualizarConexion)
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

    Public Function get_almacenDimosa()
        Dim ActualizarConexion As New SqlConnection(ConexionDimosa.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT -1 AS ID, 'TODAS' AS ALMACEN UNION ALL select CVE_ALM AS ID, DESCR AS ALMACEN from ALMACENES06", ActualizarConexion)
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

    Public Function get_almacenOPL()
        Dim ActualizarConexion As New SqlConnection(ConexionDimosa.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT -1 AS ID, 'TODAS' AS ALMACEN UNION ALL select CVE_ALM AS ID, DESCR AS ALMACEN from SAE60EMPRE08.dbo.ALMACENES08", ActualizarConexion)
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
