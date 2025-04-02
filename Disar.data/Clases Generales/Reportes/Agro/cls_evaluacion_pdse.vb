Imports System.Data.SqlClient
Public Class cls_evaluacion_pdse
    Dim Conexion As New clsconexion_sr_agro
    Public Function VentasTotProd(ByVal INICIO As Date, ByVal FIN As Date, ByVal REPORTE As String, ByVal LINEA As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_eval_pdse", ActualizarConexion)
        miComando.CommandTimeout = 5000
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@REPORTE", SqlDbType.VarChar)).Value = REPORTE
        miComando.Parameters.Add(New SqlParameter("@AÑO_INI", SqlDbType.Date)).Value = INICIO
        miComando.Parameters.Add(New SqlParameter("@AÑO_FIN", SqlDbType.Date)).Value = FIN
        miComando.Parameters.Add(New SqlParameter("@LINEA", SqlDbType.VarChar)).Value = LINEA
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
