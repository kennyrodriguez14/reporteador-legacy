
Imports System.Data.SqlClient
Imports System.Text
Imports Disar.data

Public Class clsResumen_costos_Agro
    Dim Conexion As New clsconexion_sr_agro

    Public Function Resumen_Costos(ByVal Ini As Date, ByVal Fin As Date, ByVal Almacen As Integer) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_Resumen_Costos", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure

        miComando.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.Date)).Value = Ini
        miComando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.Date)).Value = Fin
        miComando.Parameters.Add(New SqlParameter("@ALMACEN", SqlDbType.Int)).Value = Almacen
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
        Dim dt As New DataTable
        Dim sql_con As New SqlConnection(Conexion.CadenaSQL)
        sql_con.Open()
        Dim query As New StringBuilder

        query.Append("SELECT  CVE_ALM, DESCR  FROM ALMACENES02 union Select 100, 'Todas' ")

        Dim comando As New SqlCommand(query.ToString, sql_con)
        Dim adaptador As New SqlDataAdapter(comando)
        adaptador.Fill(dt)

        sql_con.Close()
        Return dt

    End Function
End Class
