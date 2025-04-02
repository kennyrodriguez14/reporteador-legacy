Imports System.Data.SqlClient
Public Class cls_punto_reorden
    Dim Conexion As New clsconexion_consumo

    Dim ConexionDimosa As New cls_conexion_DIMOSA
    Dim ConexionOpl As New cls_conexionOPL
    Dim Conexion2 As New clsconexion_sr_agro

    Public Function punto_reorden(ByVal FECHA_FIN As Date, ByVal DIAS As Integer) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_punto_reorden", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@FECHA_FINAL", SqlDbType.Date)).Value = FECHA_FIN
        miComando.Parameters.Add(New SqlParameter("@DIAS", SqlDbType.Int)).Value = DIAS
        miComando.CommandTimeout = 2000
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

    Public Function punto_reorden_dimosa(ByVal FECHA_FIN As Date, ByVal DIAS As Integer) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionDimosa.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_punto_reorden_resumen", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@FECHA_FINAL", SqlDbType.Date)).Value = FECHA_FIN
        miComando.Parameters.Add(New SqlParameter("@DIAS", SqlDbType.Int)).Value = DIAS
        miComando.CommandTimeout = 2000
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

    Public Function punto_reorden_OPL(ByVal FECHA_FIN As Date, ByVal DIAS As Integer) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionOpl.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_punto_reorden_resumen", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@FECHA_FINAL", SqlDbType.Date)).Value = FECHA_FIN
        miComando.Parameters.Add(New SqlParameter("@DIAS", SqlDbType.Int)).Value = DIAS
        miComando.CommandTimeout = 2000
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

    Public Function punto_reorden_detalle(ByVal FECHA_FIN As Date, ByVal DIAS As Integer) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_punto_reorden_resumen", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@FECHA_FINAL", SqlDbType.Date)).Value = FECHA_FIN
        miComando.Parameters.Add(New SqlParameter("@DIAS", SqlDbType.Int)).Value = DIAS
        miComando.CommandTimeout = 2000
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

    Public Function punto_reorden_detalle_dimosa(ByVal FECHA_FIN As Date, ByVal DIAS As Integer) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionDimosa.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_punto_reorden", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@FECHA_FINAL", SqlDbType.Date)).Value = FECHA_FIN
        miComando.Parameters.Add(New SqlParameter("@DIAS", SqlDbType.Int)).Value = DIAS
        miComando.CommandTimeout = 2000
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

    Public Function punto_reorden_detalle_OPL(ByVal FECHA_FIN As Date, ByVal DIAS As Integer) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionOpl.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_punto_reorden", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@FECHA_FINAL", SqlDbType.Date)).Value = FECHA_FIN
        miComando.Parameters.Add(New SqlParameter("@DIAS", SqlDbType.Int)).Value = DIAS
        miComando.CommandTimeout = 2000
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

    Public Function punto_reorden_sr_agro(ByVal FECHA_FIN As Date, ByVal DIAS As Integer) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_punto_reorden", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@FECHA_FINAL", SqlDbType.Date)).Value = FECHA_FIN
        miComando.Parameters.Add(New SqlParameter("@DIAS", SqlDbType.Int)).Value = DIAS
        miComando.CommandTimeout = 2000
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

    Public Function punto_reorden_sr_agro_detalle(ByVal FECHA_FIN As Date, ByVal DIAS As Integer) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_punto_reorden_resuemn", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@FECHA_FINAL", SqlDbType.Date)).Value = FECHA_FIN
        miComando.Parameters.Add(New SqlParameter("@DIAS", SqlDbType.Int)).Value = DIAS
        miComando.CommandTimeout = 2000
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
