Imports System.Data.SqlClient

Public Class ClsClientes_sr_agro
    Dim Conexion As New clsconexion_sr_agro
    Dim ConexionUsuario As New clsConexion

    Public Function VentaPerdidaVentas(ByVal Fecha1 As Date, ByVal Fecha2 As Date, ByVal Tipo As String, ByVal Clie As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("rptn_ventas_filtro", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.CommandTimeout = 5000
        miComando.Parameters.AddWithValue("@AÑO_INI", Fecha1.Date)
        miComando.Parameters.AddWithValue("@AÑO_FIN", Fecha2.Date)
        miComando.Parameters.AddWithValue("@TIPO", Tipo)
        miComando.Parameters.AddWithValue("@CLIE", Clie)

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

    Public Function ClientesNuevos(ByVal Fecha1 As Date, ByVal Fecha2 As Date)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim AdaptadorDeDatos As New SqlDataAdapter("SELECT dbo.CLIE02.CLAVE, dbo.CLIE02.NOMBRE, dbo.CLIE02.PAG_WEB AS 'PROPIETARIO', dbo.CLIE02.ESTADO AS 'ID/RTN', dbo.CLIE02.TELEFONO, dbo.CLIE02.FAX AS 'TIPO', " & _
                       " dbo.VEND02.NOMBRE AS VENDEDOR, dbo.CLIE_CLIB02.CAMPLIB23 AS 'FECHA DE CREACION', dbo.CLIE02.RFC AS DEPARTAMENTO, dbo.CLIE02.MUNICIPIO " & _
                       " FROM         dbo.CLIE02 INNER JOIN dbo.VEND02 ON dbo.CLIE02.CVE_VEND = dbo.VEND02.CVE_VEND INNER JOIN " & _
                       " dbo.CLIE_CLIB02 ON dbo.CLIE02.CLAVE = dbo.CLIE_CLIB02.CVE_CLIE WHERE (Convert(date,dbo.CLIE_CLIB02.CAMPLIB23) >= '" & Fecha1.Date & "') AND (Convert(date,dbo.CLIE_CLIB02.CAMPLIB23) <= '" & Fecha2.Date & "') ", ActualizarConexion)
        ActualizarConexion.Open()
        Dim ds As New DataSet
        Dim dt As New DataTable
        Try
            AdaptadorDeDatos.Fill(ds, "User")
            If ds.Tables("User").Rows.Count > 0 Then
                AdaptadorDeDatos.Fill(dt)
            End If
        Catch ex As SqlException
            MsgBox("Hay problemas de Conexión: " + ex.Message, MsgBoxStyle.Critical)
        End Try
        ActualizarConexion.Close()
        Return dt
    End Function

    Public Function ClientesSuspendidos(ByVal Fecha1 As Date, ByVal Fecha2 As Date)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim AdaptadorDeDatos As New SqlDataAdapter("SELECT dbo.CLIE02.CLAVE, dbo.CLIE02.NOMBRE, dbo.CLIE02.PAG_WEB AS 'PROPIETARIO', dbo.CLIE02.ESTADO AS 'ID/RTN', dbo.CLIE02.TELEFONO, dbo.CLIE02.FAX AS 'TIPO', " & _
                       " dbo.VEND02.NOMBRE AS VENDEDOR, dbo.CLIE_CLIB02.CAMPLIB23 AS 'FECHA DE CREACION', dbo.CLIE_CLIB02.CAMPLIB20 AS 'FECHA DE BAJA', dbo.CLIE02.RFC AS DEPARTAMENTO, dbo.CLIE02.MUNICIPIO " & _
                       " FROM         dbo.CLIE02 INNER JOIN dbo.VEND02 ON dbo.CLIE02.CVE_VEND = dbo.VEND02.CVE_VEND INNER JOIN " & _
                       " dbo.CLIE_CLIB02 ON dbo.CLIE02.CLAVE = dbo.CLIE_CLIB02.CVE_CLIE WHERE (Convert(date,dbo.CLIE_CLIB02.CAMPLIB20) >= '" & Fecha1.Date & "') AND (Convert(date,dbo.CLIE_CLIB02.CAMPLIB20) <= '" & Fecha2.Date & "') ", ActualizarConexion)
        ActualizarConexion.Open()
        Dim ds As New DataSet
        Dim dt As New DataTable
        Try
            AdaptadorDeDatos.Fill(ds, "User")
            If ds.Tables("User").Rows.Count > 0 Then
                AdaptadorDeDatos.Fill(dt)
            End If
        Catch ex As SqlException
            MsgBox("Hay problemas de Conexión: " + ex.Message, MsgBoxStyle.Critical)
        End Try
        ActualizarConexion.Close()
        Return dt
    End Function

    Public Function ClientesNuevosCantidad(ByVal Fecha1 As Date, ByVal Fecha2 As Date, ByVal Vendedor As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim AdaptadorDeDatos As New SqlDataAdapter("SELECT COUNT(dbo.CLIE02.CLAVE) " & _
                       " FROM dbo.CLIE02 INNER JOIN dbo.VEND02 ON dbo.CLIE02.CVE_VEND = dbo.VEND02.CVE_VEND INNER JOIN " & _
                       " dbo.CLIE_CLIB02 ON dbo.CLIE02.CLAVE = dbo.CLIE_CLIB02.CVE_CLIE WHERE (Convert(date,dbo.CLIE_CLIB02.CAMPLIB23) >= '" & Fecha1.Date & "') AND (Convert(date,dbo.CLIE_CLIB02.CAMPLIB23) <= '" & Fecha2.Date & "') AND (dbo.CLIE02.CVE_VEND = '" & Vendedor & "')", ActualizarConexion)
        ActualizarConexion.Open()
        Dim ds As New DataSet
        Dim dt As New DataTable
        Try
            AdaptadorDeDatos.Fill(ds, "User")
            If ds.Tables("User").Rows.Count > 0 Then
                AdaptadorDeDatos.Fill(dt)
            End If
        Catch ex As SqlException
            MsgBox("Hay problemas de Conexión: " + ex.Message, MsgBoxStyle.Critical)
        End Try
        ActualizarConexion.Close()
        Return dt
    End Function

    Public Function ClientesSuspendidosCantidad(ByVal Fecha1 As Date, ByVal Fecha2 As Date, ByVal Vendedor As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim AdaptadorDeDatos As New SqlDataAdapter("SELECT COUNT(dbo.CLIE02.CLAVE) " & _
                       " FROM dbo.CLIE02 INNER JOIN dbo.VEND02 ON dbo.CLIE02.CVE_VEND = dbo.VEND02.CVE_VEND INNER JOIN " & _
                       " dbo.CLIE_CLIB02 ON dbo.CLIE02.CLAVE = dbo.CLIE_CLIB02.CVE_CLIE WHERE (Convert(date,dbo.CLIE_CLIB02.CAMPLIB20) >= '" & Fecha1.Date & "') AND (Convert(date,dbo.CLIE_CLIB02.CAMPLIB20) <= '" & Fecha2.Date & "') AND (Ltrim(dbo.CLIE_CLIB02.CAMPLIB21) = '" & LTrim(Vendedor) & "')", ActualizarConexion)
        ActualizarConexion.Open()
        Dim ds As New DataSet
        Dim dt As New DataTable
        Try
            AdaptadorDeDatos.Fill(ds, "User")
            If ds.Tables("User").Rows.Count > 0 Then
                AdaptadorDeDatos.Fill(dt)
            End If
        Catch ex As SqlException
            MsgBox("Hay problemas de Conexión: " + ex.Message, MsgBoxStyle.Critical)
        End Try
        ActualizarConexion.Close()
        Return dt
    End Function

    Public Function ClientesActivosMes(ByVal Fecha1 As Date, ByVal Fecha2 As Date, ByVal Vendedor As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim AdaptadorDeDatos As New SqlDataAdapter("SELECT COUNT(dbo.CLIE_CLIB02.CVE_CLIE) AS Expr1 FROM dbo.CLIE_CLIB02 INNER JOIN dbo.CLIE02 ON dbo.CLIE_CLIB02.CVE_CLIE = dbo.CLIE02.CLAVE " & _
                       " WHERE (dbo.CLIE02.CVE_VEND = '" & Vendedor & "') AND (dbo.CLIE_CLIB02.CAMPLIB23 <= '" & Fecha2.Date & "') OR " & _
                       " (dbo.CLIE02.CVE_VEND = '" & Vendedor & "') AND (dbo.CLIE_CLIB02.CAMPLIB23 IS NULL) OR " & _
                       " (dbo.CLIE_CLIB02.CAMPLIB20 >= '" & Fecha2.Date & "') AND (LTRIM(dbo.CLIE_CLIB02.CAMPLIB21) LIKE '%" & Vendedor & "')", ActualizarConexion)
        '(dbo.CLIE02.STATUS = 'A') AND 
        ActualizarConexion.Open()
        Dim ds As New DataSet
        Dim dt As New DataTable
        Try
            AdaptadorDeDatos.Fill(ds, "User")
            If ds.Tables("User").Rows.Count > 0 Then
                AdaptadorDeDatos.Fill(dt)
            End If
        Catch ex As SqlException
            MsgBox("Hay problemas de Conexión: " + ex.Message, MsgBoxStyle.Critical)
        End Try
        ActualizarConexion.Close()
        Return dt
    End Function

    Public Function Supervisores()
        Dim ActualizarConexion As New SqlConnection(ConexionUsuario.CadenaSQL())

        Dim AdaptadorDeDatos As New SqlDataAdapter(" SELECT CODIGO_SUPERVISOR As ID, SUPERVISOR, CLASIFIC, ALMACEN " & _
                                                    " FROM  dbo.Supervisores_agro", ActualizarConexion)
        ActualizarConexion.Open()
        Dim ds As New DataSet
        Dim dt As New DataTable
        Try
            AdaptadorDeDatos.Fill(ds, "User")
            If ds.Tables("User").Rows.Count > 0 Then
                AdaptadorDeDatos.Fill(dt)
            End If
        Catch ex As SqlException
            MsgBox("Hay problemas de Conexión: " + ex.Message, MsgBoxStyle.Critical)
        End Try
        ActualizarConexion.Close()
        Return dt
    End Function

    Public Function Vendedores(ByVal Supervisor As Integer)
        Dim ActualizarConexion As New SqlConnection(ConexionUsuario.CadenaSQL())

        Dim AdaptadorDeDatos As New SqlDataAdapter(" SELECT     dbo.Supervisor_Vendedor_agro.CVE_VEND, SAE60Empre02.dbo.VEND02.NOMBRE, dbo.Supervisor_Vendedor_agro.SUPERVISOR " & _
                                                    " FROM dbo.Supervisor_Vendedor_agro INNER JOIN dbo.Supervisores ON dbo.Supervisor_Vendedor_agro.SUPERVISOR = dbo.Supervisores.CODIGO_SUPERVISOR INNER JOIN " & _
                                                    " SAE60Empre02.dbo.VEND02 ON dbo.Supervisor_Vendedor_agro.CVE_VEND = SAE60Empre02.dbo.VEND02.CVE_VEND COLLATE MODERN_SPANISH_CI_AS WHERE     (dbo.Supervisor_Vendedor_agro.SUPERVISOR = " & Supervisor & ")", ActualizarConexion)
        ActualizarConexion.Open()
        Dim ds As New DataSet
        Dim dt As New DataTable
        Try
            AdaptadorDeDatos.Fill(ds, "User")
            If ds.Tables("User").Rows.Count > 0 Then
                AdaptadorDeDatos.Fill(dt)
            End If
        Catch ex As SqlException
            MsgBox("Hay problemas de Conexión: " + ex.Message, MsgBoxStyle.Critical)
        End Try
        ActualizarConexion.Close()
        Return dt
    End Function


    Public Function ClientesVendedor()
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim AdaptadorDeDatos As New SqlDataAdapter("SELECT     TOP (100) PERCENT dbo.CLIE02.CLAVE, dbo.CLIE02.NOMBRE, dbo.CLIE02.PAG_WEB AS 'PROPIETARIO', dbo.CLIE02.ESTADO AS 'ID/RTN', dbo.CLIE02.STATUS, " & _
            "   dbo.CLIE02.FAX AS 'TIPO', dbo.VEND02.NOMBRE AS VENDEDOR, dbo.CLIE_CLIB02.CAMPLIB23 AS 'FECHA DE CREACIOIN', dbo.CLIE02.RFC AS DEPARTAMENTO, " & _
            "   dbo.CLIE02.MUNICIPIO  FROM         dbo.CLIE02 INNER JOIN  dbo.VEND02 ON dbo.CLIE02.CVE_VEND = dbo.VEND02.CVE_VEND INNER JOIN " & _
            "   dbo.CLIE_CLIB02 ON dbo.CLIE02.CLAVE = dbo.CLIE_CLIB02.CVE_CLIE WHERE     (dbo.CLIE02.STATUS = 'A') ORDER BY VENDEDOR", ActualizarConexion)
        ActualizarConexion.Open()
        Dim ds As New DataSet
        Dim dt As New DataTable
        Try
            AdaptadorDeDatos.Fill(ds, "User")
            If ds.Tables("User").Rows.Count > 0 Then
                AdaptadorDeDatos.Fill(dt)
            End If
        Catch ex As SqlException
            MsgBox("Hay problemas de Conexión: " + ex.Message, MsgBoxStyle.Critical)
        End Try
        ActualizarConexion.Close()
        Return dt
    End Function

    Public Function Pareto(ByVal Fecha1 As Date, ByVal Fecha2 As Date)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim AdaptadorDeDatos As New SqlDataAdapter("SELECT TOP (100) PERCENT dbo.CLIE02.CLAVE, dbo.CLIE02.STATUS, dbo.CLIE02.NOMBRE as 'NOMBRE CLIENTE', dbo.CLIE02.PAG_WEB as 'CONTACTO', dbo.CLIE02.TELEFONO, dbo.VEND02.NOMBRE AS VENDEDOR, dbo.CLIE_CLIB02.CAMPLIB19, " & _
                      " SUM(dbo.FACTF02.IMPORTE) AS VENTAS FROM  dbo.CLIE02 INNER JOIN  dbo.VEND02 ON dbo.CLIE02.CVE_VEND = dbo.VEND02.CVE_VEND INNER JOIN " & _
                      " dbo.CLIE_CLIB02 ON dbo.CLIE02.CLAVE = dbo.CLIE_CLIB02.CVE_CLIE INNER JOIN  dbo.FACTF02 ON dbo.CLIE02.CLAVE = dbo.FACTF02.CVE_CLPV WHERE (dbo.FACTF02.FECHA_DOC >= '" & Fecha1.Date & "' AND dbo.FACTF02.FECHA_DOC <= '" & Fecha2.Date & "') " & _
                      " GROUP BY dbo.CLIE02.CLAVE, dbo.CLIE02.STATUS, dbo.CLIE02.NOMBRE, dbo.VEND02.NOMBRE, dbo.CLIE_CLIB02.CAMPLIB19, dbo.CLIE02.PAG_WEB, dbo.CLIE02.TELEFONO ORDER BY VENTAS DESC", ActualizarConexion)
        ActualizarConexion.Open()
        Dim ds As New DataSet
        Dim dt As New DataTable
        Try
            AdaptadorDeDatos.Fill(ds, "User")
            If ds.Tables("User").Rows.Count > 0 Then
                AdaptadorDeDatos.Fill(dt)
            End If
        Catch ex As SqlException
            MsgBox("Hay problemas de Conexión: " + ex.Message, MsgBoxStyle.Critical)
        End Try
        ActualizarConexion.Close()
        Return dt
    End Function

    Public Function ClientesIdeales(ByVal Año As Integer, ByVal Mes As Integer, ByVal Vendedor As String)
        Dim ActualizarConexion As New SqlConnection(ConexionUsuario.CadenaSQL())

        Dim AdaptadorDeDatos As New SqlDataAdapter(" SELECT VENDEDOR_ID, MES, AÑO, IDEAL " & _
                                                   " FROM IDEAL_CLIENTES_SR_AGRO WHERE MES = " & Mes & " AND AÑO = " & Año & " AND LTRIM(RTRIM(VENDEDOR_ID)) = '" & LTrim(RTrim(Vendedor)) & "' ", ActualizarConexion)
        ActualizarConexion.Open()
        Dim ds As New DataSet
        Dim dt As New DataTable
        Try
            AdaptadorDeDatos.Fill(ds, "User")
            If ds.Tables("User").Rows.Count > 0 Then
                AdaptadorDeDatos.Fill(dt)
            End If
        Catch ex As SqlException
            MsgBox("Hay problemas de Conexión: " + ex.Message, MsgBoxStyle.Critical)
        End Try
        ActualizarConexion.Close()
        'MsgBox(dt(0)(3))
        Return dt
    End Function
End Class
