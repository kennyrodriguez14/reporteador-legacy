Imports System.Data.SqlClient
Public Class cls_ventas_por_proveedor

    Dim Conexion As New clsconexion_consumo
    Dim Conexion2 As New cls_conexion_DIMOSA
    Dim Conexion3 As New clsconexion_sr_agro

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
        miComando.CommandTimeout = 2000
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

    Public Function ListaProveedoresSPS() As DataTable
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
        miComando.CommandTimeout = 2000
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
        miComando.CommandTimeout = 2000
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

    Public Function VentasCategoria(ByVal Almacen As Integer, ByVal Fecha1 As Date, ByVal Fecha2 As Date) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("Ventas_Categoria", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.AddWithValue("@Almacen", Almacen)
        miComando.Parameters.AddWithValue("@FechaDesde", Fecha1)
        miComando.Parameters.AddWithValue("@FechaHasta", Fecha2)
        miComando.CommandTimeout = 2000
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

    Public Function ListaAlmacenes() As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand(" SELECT CVE_ALM as CLAVE, DESCR as NOMBRE" & _
                                        " FROM   ALMACENES05", ActualizarConexion)

        miComando.CommandTimeout = 2000
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

    Public Function GenerarDatosDimosa(ByVal M1I As Date, ByVal M1F As Date, ByVal M2I As Date, ByVal M2F As Date, ByVal M3I As Date, ByVal M3F As Date, ByVal SUCURSAL As String _
                                 , ByVal DIAST As Integer, ByVal DIASM As Integer, ByVal Almacen As Integer) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_ventas_por_proveedor_AUT", ActualizarConexion)
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
        miComando.Parameters.Add(New SqlParameter("@ALM", SqlDbType.VarChar)).Value = Almacen
        miComando.CommandTimeout = 2000
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

    Public Function GenerarDatosAgro(ByVal M1I As Date, ByVal M1F As Date, ByVal M2I As Date, ByVal M2F As Date, ByVal M3I As Date, ByVal M3F As Date, ByVal SUCURSAL As String _
                                 , ByVal DIAST As Integer, ByVal DIASM As Integer, ByVal Almacen As Integer) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion3.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_ventas_por_proveedor_AUT", ActualizarConexion)
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
        miComando.Parameters.Add(New SqlParameter("@ALM", SqlDbType.VarChar)).Value = Almacen
        miComando.CommandTimeout = 2000
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

