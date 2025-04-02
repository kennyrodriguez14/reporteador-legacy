Imports System.Data.SqlClient
Public Class clsVentasProveedorAgro
    Dim Conexion As New clsconexion_sr_agro

    Public Function GenerarDatos(ByVal M1I As Date, ByVal M1F As Date, ByVal M2I As Date, ByVal M2F As Date, ByVal M3I As Date, ByVal M3F As Date, ByVal SUCURSAL As String _
                                 , ByVal DIAST As Integer, ByVal DIASM As Integer) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_ventas_por_proveedor", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@MES1_INI", SqlDbType.Date)).Value = M1I
        miComando.Parameters.Add(New SqlParameter("@MES1_FIN", SqlDbType.Date)).Value = M1F

        miComando.Parameters.Add(New SqlParameter("@MES2_INI", SqlDbType.Date)).Value = M2I
        miComando.Parameters.Add(New SqlParameter("@MES2_FIN", SqlDbType.Date)).Value = M2F

        miComando.Parameters.Add(New SqlParameter("@MES3_INI", SqlDbType.Date)).Value = M3I
        miComando.Parameters.Add(New SqlParameter("@MES3_FIN", SqlDbType.Date)).Value = M3F

        miComando.Parameters.Add(New SqlParameter("@DIAST", SqlDbType.Int)).Value = DIAST
        miComando.Parameters.Add(New SqlParameter("@DIASM", SqlDbType.Int)).Value = DIASM

        miComando.Parameters.Add(New SqlParameter("@SUCURSAL", SqlDbType.VarChar)).Value = SUCURSAL

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

    Public Function ListaProveedoresAGROSRC() As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_ventas_por_proveedor", ActualizarConexion)
        miComando.Parameters.Add(New SqlParameter("@MES1_INI", SqlDbType.Date)).Value = DBNull.Value
        miComando.Parameters.Add(New SqlParameter("@MES1_FIN", SqlDbType.Date)).Value = DBNull.Value
        miComando.Parameters.Add(New SqlParameter("@MES2_INI", SqlDbType.Date)).Value = DBNull.Value
        miComando.Parameters.Add(New SqlParameter("@MES2_FIN", SqlDbType.Date)).Value = DBNull.Value
        miComando.Parameters.Add(New SqlParameter("@MES3_INI", SqlDbType.Date)).Value = DBNull.Value
        miComando.Parameters.Add(New SqlParameter("@MES3_FIN", SqlDbType.Date)).Value = DBNull.Value
        miComando.Parameters.Add(New SqlParameter("@DIAST", SqlDbType.Int)).Value = DBNull.Value
        miComando.Parameters.Add(New SqlParameter("@DIASM", SqlDbType.Int)).Value = DBNull.Value
        miComando.Parameters.Add(New SqlParameter("@SUCURSAL", SqlDbType.VarChar)).Value = "lista_proveedores"
        miComando.CommandType = CommandType.StoredProcedure

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

    Public Function ListaProveedoresSRC() As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_ventas_por_proveedor", ActualizarConexion)
        miComando.Parameters.Add(New SqlParameter("@MES1_INI", SqlDbType.Date)).Value = DBNull.Value
        miComando.Parameters.Add(New SqlParameter("@MES1_FIN", SqlDbType.Date)).Value = DBNull.Value
        miComando.Parameters.Add(New SqlParameter("@MES2_INI", SqlDbType.Date)).Value = DBNull.Value
        miComando.Parameters.Add(New SqlParameter("@MES2_FIN", SqlDbType.Date)).Value = DBNull.Value
        miComando.Parameters.Add(New SqlParameter("@MES3_INI", SqlDbType.Date)).Value = DBNull.Value
        miComando.Parameters.Add(New SqlParameter("@MES3_FIN", SqlDbType.Date)).Value = DBNull.Value
        miComando.Parameters.Add(New SqlParameter("@DIAST", SqlDbType.Int)).Value = DBNull.Value
        miComando.Parameters.Add(New SqlParameter("@DIASM", SqlDbType.Int)).Value = DBNull.Value
        miComando.Parameters.Add(New SqlParameter("@SUCURSAL", SqlDbType.VarChar)).Value = "lista_proveedores"
        miComando.CommandType = CommandType.StoredProcedure

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



