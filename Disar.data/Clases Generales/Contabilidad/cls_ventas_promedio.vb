Imports System.Data.SqlClient
Public Class cls_ventas_promedio
    Dim Conexion_SAE As New clsconexion_consumo

    Public Function Datos(ByVal Ini As Date, ByVal Fin As Date, ByVal ALMACEN As String, ByVal SUCURSAL As String, ByVal LIMITE As Integer) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion_SAE.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_ventas_promedio", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.DateTime)).Value = Ini
        miComando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.DateTime)).Value = Fin
        miComando.Parameters.Add(New SqlParameter("@ALMACEN", SqlDbType.VarChar)).Value = ALMACEN
        miComando.Parameters.Add(New SqlParameter("@SUCURSAL", SqlDbType.VarChar)).Value = SUCURSAL
        miComando.Parameters.Add(New SqlParameter("@LIMITE", SqlDbType.Int)).Value = LIMITE

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




