Imports System.Data.SqlClient

Public Class cls_inventarios
    Dim Conexion As New clsconexion_consumo
    Dim ConexionDimosa As New cls_conexion_DIMOSA
    Dim ConexionOPL As New cls_conexionOPL

    Public Function GenerarDatos(ByVal codigo As String, ByVal Nombre As String, ByVal Sucursal As String, ByVal Tipo As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("rptn_inventarios_ubicacion", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.CommandTimeout = 2000
        miComando.Parameters.Add(New SqlParameter("@CODIGO", SqlDbType.VarChar)).Value = codigo
        miComando.Parameters.Add(New SqlParameter("@NOMBRE", SqlDbType.VarChar)).Value = Nombre
        miComando.Parameters.Add(New SqlParameter("@SUCURSAL", SqlDbType.VarChar)).Value = Sucursal
        miComando.Parameters.Add(New SqlParameter("@TIPO", SqlDbType.VarChar)).Value = Tipo
        miComando.Parameters.Add(New SqlParameter("@ALMACEN", SqlDbType.Int)).Value = 1
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


    Public Function GenerarDatosOPL(ByVal codigo As String, ByVal Nombre As String, ByVal Sucursal As String, ByVal Tipo As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionOPL.CadenaSQL())
        Dim miComando As New SqlCommand("rptn_inventarios_ubicacion", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.CommandTimeout = 2000
        miComando.Parameters.Add(New SqlParameter("@CODIGO", SqlDbType.VarChar)).Value = codigo
        miComando.Parameters.Add(New SqlParameter("@NOMBRE", SqlDbType.VarChar)).Value = Nombre
        miComando.Parameters.Add(New SqlParameter("@SUCURSAL", SqlDbType.VarChar)).Value = Sucursal
        miComando.Parameters.Add(New SqlParameter("@TIPO", SqlDbType.VarChar)).Value = Tipo
        miComando.Parameters.Add(New SqlParameter("@ALMACEN", SqlDbType.Int)).Value = 1
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

    Public Function GenerarDatosDIMOSA(ByVal codigo As String, ByVal Nombre As String, ByVal Sucursal As String, ByVal Tipo As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionDimosa.CadenaSQL())
        Dim miComando As New SqlCommand("rptn_inventarios_Nuevo", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.CommandTimeout = 2000
        miComando.Parameters.Add(New SqlParameter("@CODIGO", SqlDbType.VarChar)).Value = codigo
        miComando.Parameters.Add(New SqlParameter("@NOMBRE", SqlDbType.VarChar)).Value = Nombre
        miComando.Parameters.Add(New SqlParameter("@SUCURSAL", SqlDbType.VarChar)).Value = Sucursal
        miComando.Parameters.Add(New SqlParameter("@TIPO", SqlDbType.VarChar)).Value = Tipo
        miComando.Parameters.Add(New SqlParameter("@ALMACEN", SqlDbType.Int)).Value = 1
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

    Public Function GenerarExistenciasLote(ByVal codigo As String, ByVal Nombre As String, ByVal Sucursal As String, ByVal Tipo As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("rptn_inventarios_lotes", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.CommandTimeout = 2000
        miComando.Parameters.Add(New SqlParameter("@CODIGO", SqlDbType.VarChar)).Value = codigo
        miComando.Parameters.Add(New SqlParameter("@NOMBRE", SqlDbType.VarChar)).Value = Nombre
        miComando.Parameters.Add(New SqlParameter("@SUCURSAL", SqlDbType.VarChar)).Value = Sucursal
        miComando.Parameters.Add(New SqlParameter("@TIPO", SqlDbType.VarChar)).Value = Tipo
        miComando.Parameters.Add(New SqlParameter("@ALMACEN", SqlDbType.Int)).Value = 1
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

    Public Function GenerarExistenciasLoteDimosa(ByVal codigo As String, ByVal Nombre As String, ByVal Sucursal As String, ByVal Tipo As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionDimosa.CadenaSQL())
        Dim miComando As New SqlCommand("rptn_inventarios_lotes", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.CommandTimeout = 2000
        miComando.Parameters.Add(New SqlParameter("@CODIGO", SqlDbType.VarChar)).Value = codigo
        miComando.Parameters.Add(New SqlParameter("@NOMBRE", SqlDbType.VarChar)).Value = Nombre
        miComando.Parameters.Add(New SqlParameter("@SUCURSAL", SqlDbType.VarChar)).Value = Sucursal
        miComando.Parameters.Add(New SqlParameter("@TIPO", SqlDbType.VarChar)).Value = Tipo
        miComando.Parameters.Add(New SqlParameter("@ALMACEN", SqlDbType.Int)).Value = Sucursal
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

    Public Function Dias_Inve(ByVal PROVEEDOR As Integer, ByVal FECHA As Date, ByVal SUCURSAL As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("rptn_dias_inventario", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@PROVEEDOR", SqlDbType.Int)).Value = PROVEEDOR
        miComando.Parameters.Add(New SqlParameter("@FECHA", SqlDbType.Date)).Value = FECHA
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

    Public Function Dias_InveDimosa(ByVal PROVEEDOR As Integer, ByVal FECHA As Date, ByVal SUCURSAL As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionDimosa.CadenaSQL())
        Dim miComando As New SqlCommand("rptn_dias_inventario", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@PROVEEDOR", SqlDbType.Int)).Value = PROVEEDOR
        miComando.Parameters.Add(New SqlParameter("@FECHA", SqlDbType.Date)).Value = FECHA
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

    Public Function ListaProveedores(ByVal PROVEEDOR As Integer, ByVal FECHA As Date, ByVal SUCURSAL As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("rptn_dias_inventario", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@PROVEEDOR", SqlDbType.Int)).Value = PROVEEDOR
        miComando.Parameters.Add(New SqlParameter("@FECHA", SqlDbType.Date)).Value = FECHA
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

    Public Function ListaProveedoresDimosa(ByVal PROVEEDOR As Integer, ByVal FECHA As Date, ByVal SUCURSAL As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionDimosa.CadenaSQL())
        Dim miComando As New SqlCommand("rptn_dias_inventario", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@PROVEEDOR", SqlDbType.Int)).Value = PROVEEDOR
        miComando.Parameters.Add(New SqlParameter("@FECHA", SqlDbType.Date)).Value = FECHA
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

    Public Function Pareto(ByVal Inicio As Date, ByVal Fin As Date, ByVal SUCURSAL As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("rptn_pareto_productos", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.Date)).Value = Inicio
        miComando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.Date)).Value = Fin
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

    Public Function ParetoDimosa(ByVal Inicio As Date, ByVal Fin As Date, ByVal SUCURSAL As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionDimosa.CadenaSQL())
        Dim miComando As New SqlCommand("rptn_pareto_productos", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.Date)).Value = Inicio
        miComando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.Date)).Value = Fin
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

End Class
