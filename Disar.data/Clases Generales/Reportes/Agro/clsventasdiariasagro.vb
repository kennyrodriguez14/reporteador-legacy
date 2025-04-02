Imports System.Data.SqlClient

Public Class clsventasdiariasagro
    Dim Conexion As New clsconexion_consumo
    Dim Conexion2 As New clsconexion_sr_agro


    Public Function Ventas(ByVal DESDE As Date, ByVal HASTA As Date, ByVal SUCURSAL As String, ByVal DIT As Integer, ByVal DIAM As Integer) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("VentasDiariasAgro", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@AÑO_INI", SqlDbType.Date)).Value = DESDE
        miComando.Parameters.Add(New SqlParameter("@AÑO_FIN", SqlDbType.Date)).Value = HASTA
        miComando.Parameters.Add(New SqlParameter("@SUCURSAL", SqlDbType.VarChar)).Value = SUCURSAL
        miComando.Parameters.Add(New SqlParameter("@DIAST", SqlDbType.Int)).Value = DIT
        miComando.Parameters.Add(New SqlParameter("@DIASM", SqlDbType.Int)).Value = DIAM
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

    Public Function Quintales(ByVal Inicio As Date, ByVal Fin As Date, ByVal Reporte As String, ByVal Linea As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())

        Dim miComando As New SqlCommand("dsr_quintales_mensuales", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@AÑO_INI", SqlDbType.Date)).Value = Inicio
        miComando.Parameters.Add(New SqlParameter("@AÑO_FIN", SqlDbType.Date)).Value = Fin
        miComando.Parameters.Add(New SqlParameter("@REPORTE", SqlDbType.VarChar)).Value = Reporte
        miComando.Parameters.Add(New SqlParameter("@LINEA", SqlDbType.VarChar)).Value = Linea

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
