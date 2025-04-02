Imports System.Data.SqlClient

Public Class cls_reporte_de_productos_averiados

    Dim Conexion As New clsConexion

    Public Function Reporte(ByVal fecha1 As Date, ByVal fecha2 As Date, ByVal sucursal As Integer, ByVal Empresa As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("productos_averiados_reportes", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.Date)).Value = fecha1
        miComando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.Date)).Value = fecha2
        miComando.Parameters.Add(New SqlParameter("@sucursal", SqlDbType.Int)).Value = sucursal
        miComando.Parameters.Add(New SqlParameter("@Empresa", SqlDbType.VarChar)).Value = Empresa
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
