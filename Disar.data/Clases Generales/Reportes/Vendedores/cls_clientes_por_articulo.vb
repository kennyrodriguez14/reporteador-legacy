Imports System.Data.SqlClient

Public Class cls_clientes_por_articulo
    Dim Conexion As New clsconexion_consumo

    Public Function GenerarDatos(ByVal F1 As Date, ByVal F2 As Date, ByVal COD As String, ByVal CLIENTE As String, _
                                 ByVal TB As String, ByVal SUCURSAL As Integer) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_clientes_por_producto", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.Date)).Value = F1
        miComando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.Date)).Value = F2
        miComando.Parameters.Add(New SqlParameter("@CODIGO", SqlDbType.VarChar)).Value = COD
        miComando.Parameters.Add(New SqlParameter("@CLIENTE", SqlDbType.VarChar)).Value = CLIENTE
        miComando.Parameters.Add(New SqlParameter("@TIPOBUSQUEDA", SqlDbType.VarChar)).Value = TB
        miComando.Parameters.Add(New SqlParameter("@SUCURSAL", SqlDbType.Int)).Value = SUCURSAL
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