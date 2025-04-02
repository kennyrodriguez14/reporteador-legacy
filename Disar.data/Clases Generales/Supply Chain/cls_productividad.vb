Imports System.Data.SqlClient

Public Class cls_productividad
    Dim Conexion As New clsconexion_consumo

    Public Function ProductividadFacturacion(ByVal DESDE As DateTime, ByVal HASTA As DateTime, ByVal SUCURSAL As String, ByVal CODIGO As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("rptn_efectividad_facturacion", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.DateTime)).Value = DESDE
        miComando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.DateTime)).Value = HASTA
        miComando.Parameters.Add(New SqlParameter("@SUCURSAL", SqlDbType.VarChar)).Value = SUCURSAL
        miComando.Parameters.Add(New SqlParameter("@COD", SqlDbType.VarChar)).Value = CODIGO
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
