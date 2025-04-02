Imports System.Data.SqlClient

Public Class cls_cuadro_ventas_diarias
    Dim Conexion As New clsconexion_consumo

    Public Function Ventas(ByVal INICIO As Date, ByVal FIN As Date, ByVal SUCURSAL As String, ByVal DIAS_M As Double, ByVal DIAS_T As Double) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_cuadro_ventas_diarias", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.CommandTimeout = 5000
        miComando.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.Date)).Value = INICIO
        miComando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.Date)).Value = FIN
        miComando.Parameters.Add(New SqlParameter("@SUCURSAL", SqlDbType.VarChar)).Value = SUCURSAL
        miComando.Parameters.Add(New SqlParameter("@DIAS_M", SqlDbType.Float)).Value = DIAS_M
        miComando.Parameters.Add(New SqlParameter("@DIAS_T", SqlDbType.Float)).Value = DIAS_T
        ActualizarConexion.Open()
        Dim AdaptadorDeDatos As New SqlDataAdapter(miComando)
        Dim dt As New DataTable
        Try
            AdaptadorDeDatos.Fill(dt)
            ActualizarConexion.Close()
        Catch ex As SqlException
            MsgBox("Hay un problema con la conexión a los datos " & ex.Message & SUCURSAL, MsgBoxStyle.Critical)
            ActualizarConexion.Close()
        End Try
        Return dt
    End Function

    Public Function Desglose(ByVal INICIO As Date, ByVal FIN As Date, ByVal SUCURSAL As String, ByVal DIAS_M As Double, ByVal DIAS_T As Double) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_cuadro_ventas_diarias", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.CommandTimeout = 5000
        miComando.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.Date)).Value = INICIO
        miComando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.Date)).Value = FIN
        miComando.Parameters.Add(New SqlParameter("@SUCURSAL", SqlDbType.VarChar)).Value = SUCURSAL
        miComando.Parameters.Add(New SqlParameter("@DIAS_M", SqlDbType.Float)).Value = DIAS_M
        miComando.Parameters.Add(New SqlParameter("@DIAS_T", SqlDbType.Float)).Value = DIAS_T
        ActualizarConexion.Open()
        Dim AdaptadorDeDatos As New SqlDataAdapter(miComando)
        Dim dt As New DataTable
        Try
            AdaptadorDeDatos.Fill(dt)
            ActualizarConexion.Close()
        Catch ex As SqlException
            MsgBox("Hay un problema con la conexión a los datos " & ex.Message & SUCURSAL, MsgBoxStyle.Critical)
            ActualizarConexion.Close()
        End Try
        Return dt
    End Function
End Class
