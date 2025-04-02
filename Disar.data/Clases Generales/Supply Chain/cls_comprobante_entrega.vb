Imports System.Data.SqlClient

Public Class cls_comprobante_entrega
    Dim Conexion As New clsconexion_consumo

    Public Function CEntrega(ByVal Inicio As String, ByVal Fin As String, ByVal Sucursal As String, ByVal Fecha As DateTime) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("rptn_comprobante de entrega", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@CVE_INI", SqlDbType.VarChar)).Value = Inicio
        miComando.Parameters.Add(New SqlParameter("@CVE_FIN", SqlDbType.VarChar)).Value = Fin
        miComando.Parameters.Add(New SqlParameter("@SUCURSAL", SqlDbType.VarChar)).Value = Sucursal
        miComando.Parameters.Add(New SqlParameter("@FECHA", SqlDbType.DateTime)).Value = Fecha
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
