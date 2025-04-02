Imports System.Data.SqlClient
Public Class cls_horas_Trabajo
    Dim Conexion As New clsConexion
    Public Function Entrada(ByVal Fecha As DateTime, ByVal Hora_entrada As DateTime, ByVal sucursal As Integer)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("INSERT INTO [Usuarios].[dbo].[horas_trabajo_bodega] " & _
                                        "([Fecha],[Hora_entrada],sucursal) " & _
                                        "VALUES (@Fecha,@Hora_entrada,@sucursal)", ActualizarConexion)
        miComando.Parameters.AddWithValue("@Fecha", Fecha)
        miComando.Parameters.AddWithValue("@Hora_entrada", Hora_entrada)
        miComando.Parameters.AddWithValue("@sucursal", sucursal)
        ActualizarConexion.Open()
        miComando.ExecuteNonQuery()
        ActualizarConexion.Close()
        Return True
    End Function

    Public Function Salida(ByVal Fecha As DateTime, ByVal Hora_salida As DateTime, ByVal sucursal As Integer)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("UPDATE [Usuarios].[dbo].[horas_trabajo_bodega] " & _
                                        "SET [Hora_salida] = @Hora_salida, [Id] = 1 " & _
                                        "WHERE Fecha = @fecha and Id is null and sucursal = @sucursal", ActualizarConexion)
        miComando.Parameters.AddWithValue("@Fecha", Fecha)
        miComando.Parameters.AddWithValue("@Hora_salida", Hora_salida)
        miComando.Parameters.AddWithValue("@sucursal", sucursal)
        ActualizarConexion.Open()
        miComando.ExecuteNonQuery()
        ActualizarConexion.Close()
        Return True
    End Function

    Public Function dia(ByVal fecha As Date)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT REPLACE(REPLACE(sucursal,'1','SRC'),'2','SPS') AS SUCURSAL, CONVERT(VARCHAR,Fecha,103)AS DIA, CONVERT(VARCHAR,Hora_entrada,8) " & _
                                        "AS ENTRADA, CONVERT(VARCHAR,Hora_salida,8) AS SALIDA " & _
                                        "FROM horas_trabajo_bodega WHERE Fecha = @fecha", ActualizarConexion)
        ActualizarConexion.Open()
        Dim AdaptadorDeDatos As New SqlDataAdapter(miComando)
        miComando.Parameters.AddWithValue("@fecha", fecha)
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
