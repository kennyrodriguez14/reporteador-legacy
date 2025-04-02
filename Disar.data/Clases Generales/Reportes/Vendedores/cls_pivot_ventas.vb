Imports System.Data.SqlClient

Public Class cls_pivot_ventas
    Dim Conexion As New clsconexion_consumo
    Public Function GetPivot(ByVal INICIO As Date, ByVal FIN As Date, ByVal ALMACEN As Integer, ByVal LINEA As String, ByVal TIPO As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_reporte_ventas_standard", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@FECHA_INICIO", SqlDbType.Date)).Value = INICIO
        miComando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.Date)).Value = FIN
        miComando.Parameters.Add(New SqlParameter("@ALMACEN", SqlDbType.Int)).Value = ALMACEN
        miComando.Parameters.Add(New SqlParameter("@LINEA", SqlDbType.VarChar)).Value = LINEA
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
End Class