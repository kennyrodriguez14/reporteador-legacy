Imports System.Data.SqlClient
Public Class cls_ventas_oficina
    Dim Conexion As New clsconexion_consumo
    Dim Dimosa As New cls_conexion_DIMOSA

    Public Function Ventas_Ofi(ByVal FECHA As Date) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_ventas_oficina", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@FECHA", SqlDbType.Date)).Value = FECHA

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

    Public Function Ventas_OfiDIMOSA(ByVal FECHA As Date) As DataTable
        Dim ActualizarConexion As New SqlConnection(Dimosa.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_ventas_oficina", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@FECHA", SqlDbType.Date)).Value = FECHA

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

   
