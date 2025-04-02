Imports System.Data.SqlClient

Public Class cls_sell_out_general
    Dim Conexion As New clsconexion_consumo
    Dim ConexionSR As New clsconexion_sr_agro
    Dim ConexionDIMOSA As New cls_conexion_DIMOSA
    Dim ConexionOPL As New cls_conexionOPL

    Public Function getDatos(ByVal INICIO As Date, ByVal FIN As Date, ByVal LINEA As Integer) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_sell_out_general", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.Date)).Value = INICIO
        miComando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.Date)).Value = FIN
        miComando.Parameters.Add(New SqlParameter("@LINEA", SqlDbType.VarChar)).Value = LINEA
        miComando.CommandTimeout = 5000
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

    Public Function getDatos_Costos(ByVal INICIO As Date, ByVal FIN As Date, ByVal LINEA As Integer) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_sell_out_general_costo", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.Date)).Value = INICIO
        miComando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.Date)).Value = FIN
        miComando.Parameters.Add(New SqlParameter("@LINEA", SqlDbType.VarChar)).Value = LINEA
        miComando.CommandTimeout = 7000
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

    Public Function getDatos_CostosSrAgro(ByVal INICIO As Date, ByVal FIN As Date, ByVal PROVEEDOR As Integer) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionSR.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_sell_out_general_costo", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.Date)).Value = INICIO
        miComando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.Date)).Value = FIN
        miComando.Parameters.Add(New SqlParameter("@PROVEEDOR", SqlDbType.VarChar)).Value = PROVEEDOR
        miComando.CommandTimeout = 5000
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

    Public Function getDatos_CostosDimosa(ByVal INICIO As Date, ByVal FIN As Date, ByVal LINEA As Integer) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionDIMOSA.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_sell_out_general_costo", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.Date)).Value = INICIO
        miComando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.Date)).Value = FIN
        miComando.Parameters.Add(New SqlParameter("@LINEA", SqlDbType.VarChar)).Value = LINEA
        miComando.CommandTimeout = 5000
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


    Public Function getDatosDIMOSA(ByVal INICIO As Date, ByVal FIN As Date, ByVal LINEA As Integer) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionDIMOSA.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_sell_out_general", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.Date)).Value = INICIO
        miComando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.Date)).Value = FIN
        miComando.Parameters.Add(New SqlParameter("@LINEA", SqlDbType.VarChar)).Value = LINEA
        miComando.CommandTimeout = 5000
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

    Public Function getDatosOPL(ByVal INICIO As Date, ByVal FIN As Date, ByVal LINEA As Integer) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionOPL.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_sell_out_general", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.Date)).Value = INICIO
        miComando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.Date)).Value = FIN
        miComando.Parameters.Add(New SqlParameter("@LINEA", SqlDbType.VarChar)).Value = LINEA
        miComando.CommandTimeout = 5000
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

    Public Function sell_out_quintales(ByVal INICIO As Date, ByVal FIN As Date, ByVal LINEA As String, ByVal TIPO As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_sell_out_general_quintales", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.Date)).Value = INICIO
        miComando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.Date)).Value = FIN
        miComando.Parameters.Add(New SqlParameter("@LINEA", SqlDbType.VarChar)).Value = LINEA
        miComando.Parameters.Add(New SqlParameter("@TIPO", SqlDbType.VarChar)).Value = TIPO
        miComando.CommandTimeout = 5000
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

    Public Function Llenar_cmb() As DataView
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim AdaptadorDeDatos As New SqlDataAdapter("SELECT '-1' AS ID, 'TODOS' AS PROVEEDOR UNION ALL SELECT CLAVE AS ID, LTRIM(CLAVE)+'-'+LOWER(NOMBRE) AS PROVEEDOR FROM dbo.PROV05 ", ActualizarConexion)
        ActualizarConexion.Open()
        Dim ds As New DataSet
        Dim dv As New DataView
        Try
            AdaptadorDeDatos.Fill(ds, "PROV05")
            If ds.Tables("PROV05").Rows.Count > 0 Then
                dv = New DataView(ds.Tables("PROV05"))
            End If
        Catch ex As SqlException
            MsgBox("Hay problemas de Conexión: " + ex.Message, MsgBoxStyle.Critical)
        End Try
        ActualizarConexion.Close()
        Return dv
    End Function

    Public Function Llenar_cmb_DIMOSA() As DataView
        Dim ActualizarConexion As New SqlConnection(ConexionDIMOSA.CadenaSQL())
        Dim AdaptadorDeDatos As New SqlDataAdapter("SELECT '-1' AS ID, 'TODOS' AS PROVEEDOR UNION ALL SELECT CLAVE AS ID, LTRIM(CLAVE)+'-'+LOWER(NOMBRE) AS PROVEEDOR FROM dbo.PROV06 ", ActualizarConexion)
        ActualizarConexion.Open()
        Dim ds As New DataSet
        Dim dv As New DataView
        Try
            AdaptadorDeDatos.Fill(ds, "PROV06")
            If ds.Tables("PROV06").Rows.Count > 0 Then
                dv = New DataView(ds.Tables("PROV06"))
            End If
        Catch ex As SqlException
            MsgBox("Hay problemas de Conexión: " + ex.Message, MsgBoxStyle.Critical)
        End Try
        ActualizarConexion.Close()
        Return dv
    End Function

    Public Function Llenar_cmb_opl() As DataView
        Dim ActualizarConexion As New SqlConnection(ConexionOPL.CadenaSQL())
        Dim AdaptadorDeDatos As New SqlDataAdapter("SELECT '-1' AS ID, 'TODOS' AS PROVEEDOR UNION ALL SELECT CLAVE AS ID, LTRIM(CLAVE)+'-'+LOWER(NOMBRE) AS PROVEEDOR FROM dbo.PROV08 ", ActualizarConexion)
        ActualizarConexion.Open()
        Dim ds As New DataSet
        Dim dv As New DataView
        Try
            AdaptadorDeDatos.Fill(ds, "PROV06")
            If ds.Tables("PROV06").Rows.Count > 0 Then
                dv = New DataView(ds.Tables("PROV06"))
            End If
        Catch ex As SqlException
            MsgBox("Hay problemas de Conexión: " + ex.Message, MsgBoxStyle.Critical)
        End Try
        ActualizarConexion.Close()
        Return dv
    End Function

    Public Function Llenar_cmb_agro() As DataView
        Dim ActualizarConexion As New SqlConnection(ConexionSR.CadenaSQL())
        Dim AdaptadorDeDatos As New SqlDataAdapter("SELECT '-1' AS ID, 'TODOS' AS PROVEEDOR UNION ALL SELECT CLAVE AS ID, LTRIM(CLAVE)+'-'+LOWER(NOMBRE) AS PROVEEDOR FROM dbo.PROV02 ", ActualizarConexion)
        ActualizarConexion.Open()
        Dim ds As New DataSet
        Dim dv As New DataView
        Try
            AdaptadorDeDatos.Fill(ds, "PROV05")
            If ds.Tables("PROV05").Rows.Count > 0 Then
                dv = New DataView(ds.Tables("PROV05"))
            End If
        Catch ex As SqlException
            MsgBox("Hay problemas de Conexión: " + ex.Message, MsgBoxStyle.Critical)
        End Try
        ActualizarConexion.Close()
        Return dv
    End Function

    Public Function getSellOutSRAGRO(ByVal INICIO As Date, ByVal FIN As Date, ByVal PROVEEDOR As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionSR.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_sell_out_general", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.Date)).Value = INICIO
        miComando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.Date)).Value = FIN
        miComando.Parameters.Add(New SqlParameter("@PROVEEDOR", SqlDbType.VarChar)).Value = PROVEEDOR
        miComando.CommandTimeout = 5000
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

    Public Function colombina(ByVal INICIO As Date, ByVal FIN As Date) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_sell_out_colombina", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.Date)).Value = INICIO
        miComando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.Date)).Value = FIN
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

    Public Function nestle(ByVal INICIO As Date, ByVal FIN As Date, ByVal LINEA As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_sell_out_general_nestle", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.Date)).Value = INICIO
        miComando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.Date)).Value = FIN
        miComando.Parameters.Add(New SqlParameter("@LINEA", SqlDbType.VarChar)).Value = LINEA
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

    Public Function Mondelez(ByVal INICIO As Date, ByVal FIN As Date) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("SELLOUT_MONDE", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.Date)).Value = INICIO
        miComando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.Date)).Value = FIN

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

    Public Function FiltarInformacionVendedor(ByVal INICIO As Date, ByVal FIN As Date, ByVal LINEA As Integer) As DataTable

        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_sell_out_general_resumen_vendedores", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.Date)).Value = INICIO
        miComando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.Date)).Value = FIN
        miComando.Parameters.Add(New SqlParameter("@LINEA", SqlDbType.VarChar)).Value = LINEA
        miComando.CommandTimeout = 5000
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

    Public Function get_datos_so_rentabilidad(ByVal INICIO As Date, ByVal FIN As Date) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_so_rentabilidad", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.Date)).Value = INICIO
        miComando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.Date)).Value = FIN
        miComando.CommandTimeout = 5000
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

    Public Function ArchivosMondelez(ByVal INICIO As Date, ByVal FIN As Date, ByVal Tipo As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("SELLOUT_MONDE_ARCHIVOS", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@F1", SqlDbType.Date)).Value = INICIO.Date
        miComando.Parameters.Add(New SqlParameter("@F2", SqlDbType.Date)).Value = FIN.Date
        miComando.Parameters.Add(New SqlParameter("@TIPO", SqlDbType.VarChar)).Value = Tipo

        miComando.CommandTimeout = 10000
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
