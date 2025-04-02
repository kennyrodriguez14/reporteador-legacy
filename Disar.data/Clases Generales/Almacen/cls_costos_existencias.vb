
Imports System.Data.SqlClient
Imports System.Text
Imports Disar.data


Public Class cls_costos_existencias
    Dim Conexion As New clsconexion_sr_agro
    Dim ConexionConsumo As New clsconexion_consumo
    Dim ConexionDIMOSA As New cls_conexion_DIMOSA

    Public Function costos_existencias(ByVal Fin As Date) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_costos_existencias", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure

        miComando.Parameters.Add(New SqlParameter("@FECHA", SqlDbType.Date)).Value = Fin

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

    Public Function costos_existencias_Consumo(ByVal Fin As Date) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionConsumo.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_costos_existencias", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.CommandTimeout = 2000

        miComando.Parameters.Add(New SqlParameter("@FECHA", SqlDbType.Date)).Value = Fin

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

    Public Function costos_existencias_DIMOSA(ByVal Fin As Date) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionDIMOSA.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_costos_existencias", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.CommandTimeout = 2000

        miComando.Parameters.Add(New SqlParameter("@FECHA", SqlDbType.Date)).Value = Fin

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
