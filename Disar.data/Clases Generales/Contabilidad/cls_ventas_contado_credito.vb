Imports System.Data.SqlClient
Public Class cls_ventas_contado_credito
    Dim Conexion As New clsconexion_consumo
    Dim Conexion2 As New clsconexion_sr_agro
    Public Function Reporte(ByVal fecha1 As Date, ByVal fecha2 As Date, ByVal ALMACEN As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_detalle_ventas_contado_credito", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.Date)).Value = fecha1
        miComando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.Date)).Value = fecha2
        miComando.Parameters.Add(New SqlParameter("@ALMACEN", SqlDbType.VarChar)).Value = ALMACEN
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

    Public Function auditoria_promos(ByVal FECHA As Date, ByVal CVE_DOC As String, ByVal ALMACEN As String, ByVal TIPO As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_auditoria_promociones", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@ALMACEN", SqlDbType.Int)).Value = ALMACEN
        miComando.Parameters.Add(New SqlParameter("@FECHA", SqlDbType.Date)).Value = FECHA
        miComando.Parameters.Add(New SqlParameter("@CVE_DOC", SqlDbType.VarChar)).Value = CVE_DOC
        miComando.Parameters.Add(New SqlParameter("@TIPO", SqlDbType.VarChar)).Value = TIPO
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


    Public Function Reporte_sragro(ByVal fecha1 As Date, ByVal fecha2 As Date, ByVal ALMACEN As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_detalle_ventas_contado_credito", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.Date)).Value = fecha1
        miComando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.Date)).Value = fecha2
        miComando.Parameters.Add(New SqlParameter("@ALMACEN", SqlDbType.VarChar)).Value = ALMACEN
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
