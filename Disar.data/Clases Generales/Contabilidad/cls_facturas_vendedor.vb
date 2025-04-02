Imports System.Data.SqlClient

Public Class cls_facturas_vendedor
    Dim Conexion As New clsconexion_consumo

    Public Function Facturas_Vendedor(ByVal Ini As Date, ByVal Fin As Date, ByVal Almacen As Integer) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_detalle_facturas_vendedor", ActualizarConexion)
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
End Class
