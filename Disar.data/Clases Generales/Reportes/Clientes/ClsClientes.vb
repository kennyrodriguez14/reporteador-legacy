Imports System.Data.SqlClient


Public Class ClsClientes
    Dim Conexion As New clsconexion_consumo
    Dim ConexionDIMOSA As New cls_conexion_DIMOSA
    Dim ConexionAgro As New clsconexion_sr_agro
    Dim ConexionUsuario As New clsConexion

    Public Function VentaPerdidaVentas(ByVal Fecha1 As Date, ByVal Fecha2 As Date, ByVal Tipo As String, ByVal Clie As String, ByVal Vendedor As String, ByVal Genera As Integer)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand

        If Vendedor = "-1" Or Tipo = "RESUMEN_RIESGO" Then
            miComando = New SqlCommand("rptn_ventas_filtro_supervisor", ActualizarConexion)
            miComando.CommandType = CommandType.StoredProcedure
            miComando.CommandTimeout = 5000
            miComando.Parameters.AddWithValue("@AÑO_INI", Fecha1.Date)
            miComando.Parameters.AddWithValue("@AÑO_FIN", Fecha2.Date)
            miComando.Parameters.AddWithValue("@TIPO", Tipo)
            miComando.Parameters.AddWithValue("@CLIE", Clie)
            miComando.Parameters.AddWithValue("@VENDEDOR", Vendedor)
            miComando.Parameters.AddWithValue("@SUPERVISOR", Genera)

        Else
            miComando = New SqlCommand("rptn_ventas_filtro", ActualizarConexion)
            miComando.CommandType = CommandType.StoredProcedure
            miComando.CommandTimeout = 5000
            miComando.Parameters.AddWithValue("@AÑO_INI", Fecha1.Date)
            miComando.Parameters.AddWithValue("@AÑO_FIN", Fecha2.Date)
            miComando.Parameters.AddWithValue("@TIPO", Tipo)
            miComando.Parameters.AddWithValue("@CLIE", Clie)
            miComando.Parameters.AddWithValue("@VENDEDOR", Vendedor)
        End If
 

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

    Public Function VentaPerdidaVentasDimosa(ByVal Fecha1 As Date, ByVal Fecha2 As Date, ByVal Tipo As String, ByVal Clie As String, ByVal Vendedor As String, ByVal Genera As Integer)
        Dim ActualizarConexion As New SqlConnection(ConexionDIMOSA.CadenaSQL())
        Dim miComando As New SqlCommand

        If Vendedor = "-1" Or Tipo = "RESUMEN_RIESGO" Then
            miComando = New SqlCommand("rptn_ventas_filtro_supervisor", ActualizarConexion)
            miComando.CommandType = CommandType.StoredProcedure
            miComando.CommandTimeout = 5000
            miComando.Parameters.AddWithValue("@AÑO_INI", Fecha1.Date)
            miComando.Parameters.AddWithValue("@AÑO_FIN", Fecha2.Date)
            miComando.Parameters.AddWithValue("@TIPO", Tipo)
            miComando.Parameters.AddWithValue("@CLIE", Clie)
            miComando.Parameters.AddWithValue("@VENDEDOR", Vendedor)
            miComando.Parameters.AddWithValue("@SUPERVISOR", Genera)
        Else
            miComando = New SqlCommand("rptn_ventas_filtro", ActualizarConexion)
            miComando.CommandType = CommandType.StoredProcedure
            miComando.CommandTimeout = 5000
            miComando.Parameters.AddWithValue("@AÑO_INI", Fecha1.Date)
            miComando.Parameters.AddWithValue("@AÑO_FIN", Fecha2.Date)
            miComando.Parameters.AddWithValue("@TIPO", Tipo)
            miComando.Parameters.AddWithValue("@CLIE", Clie)
            miComando.Parameters.AddWithValue("@VENDEDOR", Vendedor)
        End If

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

    Public Function VentaPerdidaVentasAgro(ByVal Fecha1 As Date, ByVal Fecha2 As Date, ByVal Tipo As String, ByVal Clie As String, ByVal VENDEDOR As String, ByVal Genera As Integer)
        Dim ActualizarConexion As New SqlConnection(ConexionAgro.CadenaSQL())
        Dim miComando As New SqlCommand

         
        miComando = New SqlCommand("rptn_ventas_filtro", ActualizarConexion)
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

        Dim AdaptadorDeDatos As New SqlDataAdapter("SELECT dbo.CLIE05.CLAVE, dbo.CLIE05.NOMBRE, dbo.CLIE05.PAG_WEB AS 'PROPIETARIO', dbo.CLIE05.ESTADO AS 'ID/RTN', dbo.CLIE05.TELEFONO, dbo.CLIE05.FAX AS 'TIPO', " & _
                       " dbo.VEND05.NOMBRE AS VENDEDOR, dbo.CLIE_CLIB05.CAMPLIB17 AS 'FECHA DE CREACION', dbo.CLIE05.RFC AS DEPARTAMENTO, dbo.CLIE05.MUNICIPIO " & _
                       " FROM         dbo.CLIE05 INNER JOIN dbo.VEND05 ON dbo.CLIE05.CVE_VEND = dbo.VEND05.CVE_VEND INNER JOIN " & _
                       " dbo.CLIE_CLIB05 ON dbo.CLIE05.CLAVE = dbo.CLIE_CLIB05.CVE_CLIE WHERE (Convert(date,dbo.CLIE_CLIB05.CAMPLIB17) >= '" & Fecha1.Date & "') AND (Convert(date,dbo.CLIE_CLIB05.CAMPLIB17) <= '" & Fecha2.Date & "') ", ActualizarConexion)
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

        Dim AdaptadorDeDatos As New SqlDataAdapter("SELECT dbo.CLIE05.CLAVE, dbo.CLIE05.NOMBRE, dbo.CLIE05.PAG_WEB AS 'PROPIETARIO', dbo.CLIE05.ESTADO AS 'ID/RTN', dbo.CLIE05.TELEFONO, dbo.CLIE05.FAX AS 'TIPO', " & _
                       " dbo.VEND05.NOMBRE AS VENDEDOR, dbo.CLIE_CLIB05.CAMPLIB17 AS 'FECHA DE CREACION', dbo.CLIE_CLIB05.CAMPLIB20 AS 'FECHA DE BAJA', dbo.CLIE05.RFC AS DEPARTAMENTO, dbo.CLIE05.MUNICIPIO " & _
                       " FROM         dbo.CLIE05 INNER JOIN dbo.VEND05 ON dbo.CLIE05.CVE_VEND = dbo.VEND05.CVE_VEND INNER JOIN " & _
                       " dbo.CLIE_CLIB05 ON dbo.CLIE05.CLAVE = dbo.CLIE_CLIB05.CVE_CLIE WHERE (Convert(date,dbo.CLIE_CLIB05.CAMPLIB20) >= '" & Fecha1.Date & "') AND (Convert(date,dbo.CLIE_CLIB05.CAMPLIB20) <= '" & Fecha2.Date & "') ", ActualizarConexion)
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

        Dim AdaptadorDeDatos As New SqlDataAdapter("SELECT COUNT(dbo.CLIE05.CLAVE) " & _
                       " FROM dbo.CLIE05 INNER JOIN dbo.VEND05 ON dbo.CLIE05.CVE_VEND = dbo.VEND05.CVE_VEND INNER JOIN " & _
                       " dbo.CLIE_CLIB05 ON dbo.CLIE05.CLAVE = dbo.CLIE_CLIB05.CVE_CLIE WHERE (Convert(date,dbo.CLIE_CLIB05.CAMPLIB17) >= '" & Fecha1.Date & "') AND (Convert(date,dbo.CLIE_CLIB05.CAMPLIB17) <= '" & Fecha2.Date & "') AND (dbo.CLIE05.CVE_VEND = '" & Vendedor & "')", ActualizarConexion)
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

        Dim AdaptadorDeDatos As New SqlDataAdapter("SELECT COUNT(dbo.CLIE05.CLAVE) " & _
                       " FROM dbo.CLIE05 INNER JOIN dbo.VEND05 ON dbo.CLIE05.CVE_VEND = dbo.VEND05.CVE_VEND INNER JOIN " & _
                       " dbo.CLIE_CLIB05 ON dbo.CLIE05.CLAVE = dbo.CLIE_CLIB05.CVE_CLIE WHERE (Convert(date,dbo.CLIE_CLIB05.CAMPLIB20) >= '" & Fecha1.Date & "') AND (Convert(date,dbo.CLIE_CLIB05.CAMPLIB20) <= '" & Fecha2.Date & "') AND (Ltrim(dbo.CLIE_CLIB05.CAMPLIB21) = '" & LTrim(Vendedor) & "')", ActualizarConexion)
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

        Dim AdaptadorDeDatos As New SqlDataAdapter("SELECT COUNT(dbo.CLIE_CLIB05.CVE_CLIE) AS Expr1 FROM dbo.CLIE_CLIB05 INNER JOIN dbo.CLIE05 ON dbo.CLIE_CLIB05.CVE_CLIE = dbo.CLIE05.CLAVE " & _
                       " WHERE (dbo.CLIE05.CVE_VEND = '" & Vendedor & "') AND (dbo.CLIE_CLIB05.CAMPLIB17 <= '" & Fecha2.Date & "') OR " & _
                       " (dbo.CLIE05.CVE_VEND = '" & Vendedor & "') AND (dbo.CLIE_CLIB05.CAMPLIB17 IS NULL) OR " & _
                       " (dbo.CLIE_CLIB05.CAMPLIB20 >= '" & Fecha2.Date & "') AND (LTRIM(dbo.CLIE_CLIB05.CAMPLIB21) LIKE '%" & Vendedor & "')", ActualizarConexion)
        '(dbo.CLIE05.STATUS = 'A') AND 
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
                                                    " FROM  dbo.Supervisores", ActualizarConexion)
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

    Public Function SupervisoresDET(ByVal EMPRESA As String)
        Dim ActualizarConexion As New SqlConnection(ConexionUsuario.CadenaSQL())

        Dim Comando As New SqlCommand(" SELECT -1 as ID, 'TODOS' AS SUPERVISOR UNION ALL SELECT CODIGO_SUPERVISOR As ID, SUPERVISOR " & _
                                                    " FROM  dbo.Supervisores WHERE EMPRESA = @EMPRESA AND SUPERVISOR NOT LIKE '%DISPONIBLE%' AND SUPERVISOR NOT LIKE '%INACT%' AND SUPERVISOR NOT LIKE 'INACTIV%' AND SUPERVISOR NOT LIKE 'VENTAS%'", ActualizarConexion)
        Comando.Parameters.AddWithValue("@EMPRESA", EMPRESA)
        Dim AdaptadorDeDatos As New SqlDataAdapter(Comando)
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

    Public Function SupervisoresGeneral(ByVal EMPRESA As String)
        Dim ActualizarConexion As New SqlConnection(ConexionUsuario.CadenaSQL())

        Dim Comando As New SqlCommand("   SELECT CODIGO_SUPERVISOR As ID, SUPERVISOR " & _
                                                    " FROM  dbo.Supervisores WHERE EMPRESA = @EMPRESA AND SUPERVISOR NOT LIKE '%DISPONIBLE%' AND SUPERVISOR NOT LIKE '%INACT%' AND SUPERVISOR NOT LIKE 'INACTIV%' AND SUPERVISOR NOT LIKE 'VENTAS%'", ActualizarConexion)
        Comando.Parameters.AddWithValue("@EMPRESA", EMPRESA)
        Dim AdaptadorDeDatos As New SqlDataAdapter(Comando)
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

        Dim AdaptadorDeDatos As New SqlDataAdapter(" SELECT     dbo.Supervisor_Vendedor.CVE_VEND, SAE60Empre05.dbo.VEND05.NOMBRE, dbo.Supervisor_Vendedor.SUPERVISOR " & _
                                                    " FROM dbo.Supervisor_Vendedor INNER JOIN dbo.Supervisores ON dbo.Supervisor_Vendedor.SUPERVISOR = dbo.Supervisores.CODIGO_SUPERVISOR INNER JOIN " & _
                                                    " SAE60Empre05.dbo.VEND05 ON dbo.Supervisor_Vendedor.CVE_VEND = SAE60Empre05.dbo.VEND05.CVE_VEND COLLATE MODERN_SPANISH_CI_AS WHERE     (dbo.Supervisor_Vendedor.SUPERVISOR = " & Supervisor & ")", ActualizarConexion)
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

        Dim AdaptadorDeDatos As New SqlDataAdapter("SELECT     TOP (100) PERCENT dbo.CLIE05.CLAVE, dbo.CLIE05.NOMBRE, dbo.CLIE05.PAG_WEB AS 'PROPIETARIO', dbo.CLIE05.ESTADO AS 'ID/RTN', dbo.CLIE05.STATUS, " & _
"                      dbo.CLIE05.FAX AS 'TIPO', dbo.VEND05.NOMBRE AS VENDEDOR, dbo.CLIE_CLIB05.CAMPLIB17 AS 'FECHA DE CREACIOIN', dbo.CLIE05.RFC AS DEPARTAMENTO, " & _
"                      dbo.CLIE05.MUNICIPIO  FROM         dbo.CLIE05 INNER JOIN  dbo.VEND05 ON dbo.CLIE05.CVE_VEND = dbo.VEND05.CVE_VEND INNER JOIN " & _
"                      dbo.CLIE_CLIB05 ON dbo.CLIE05.CLAVE = dbo.CLIE_CLIB05.CVE_CLIE WHERE     (dbo.CLIE05.STATUS = 'A') ORDER BY VENDEDOR", ActualizarConexion)
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

        Dim AdaptadorDeDatos As New SqlDataAdapter("SELECT TOP (100) PERCENT dbo.CLIE05.CLAVE, dbo.CLIE05.STATUS, dbo.CLIE05.NOMBRE as 'NOMBRE CLIENTE', dbo.CLIE05.PAG_WEB as 'CONTACTO', dbo.CLIE05.TELEFONO, dbo.VEND05.NOMBRE AS VENDEDOR, dbo.CLIE_CLIB05.CAMPLIB19, " & _
                      " SUM(dbo.FACTF05.IMPORTE) AS VENTAS FROM  dbo.CLIE05 INNER JOIN  dbo.VEND05 ON dbo.CLIE05.CVE_VEND = dbo.VEND05.CVE_VEND INNER JOIN " & _
                      " dbo.CLIE_CLIB05 ON dbo.CLIE05.CLAVE = dbo.CLIE_CLIB05.CVE_CLIE INNER JOIN  dbo.FACTF05 ON dbo.CLIE05.CLAVE = dbo.FACTF05.CVE_CLPV WHERE (dbo.FACTF05.FECHA_DOC >= '" & Fecha1.Date & "' AND dbo.FACTF05.FECHA_DOC <= '" & Fecha2.Date & "') " & _
                      " GROUP BY dbo.CLIE05.CLAVE, dbo.CLIE05.STATUS, dbo.CLIE05.NOMBRE, dbo.VEND05.NOMBRE, dbo.CLIE_CLIB05.CAMPLIB19, dbo.CLIE05.PAG_WEB, dbo.CLIE05.TELEFONO ORDER BY VENTAS DESC", ActualizarConexion)
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

        Dim AdaptadorDeDatos As New SqlDataAdapter(" SELECT VENDEDOR_ID, MES, AÑO, IDEAL,  META_COBERTURA, META_EFECTIVIDAD, EFECTIVIDAD_TOTAL " & _
                                                   " FROM IDEAL_CLIENTES WHERE MES = " & Mes & " AND AÑO = " & Año & " AND LTRIM(RTRIM(VENDEDOR_ID)) = '" & LTrim(RTrim(Vendedor)) & "' ", ActualizarConexion)
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

    Public Function ClientesIdealesDIMOSA(ByVal Año As Integer, ByVal Mes As Integer, ByVal Vendedor As String)
        Dim ActualizarConexion As New SqlConnection(ConexionUsuario.CadenaSQL())

        Dim AdaptadorDeDatos As New SqlDataAdapter(" SELECT VENDEDOR_ID, MES, AÑO, IDEAL,  META_COBERTURA, META_EFECTIVIDAD, EFECTIVIDAD_TOTAL  " & _
                                                   " FROM IDEAL_CLIENTES_DIMOSA WHERE MES = " & Mes & " AND AÑO = " & Año & " AND LTRIM(RTRIM(VENDEDOR_ID)) = '" & LTrim(RTrim(Vendedor)) & "' ", ActualizarConexion)
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

    Public Function CargaCobros(ByVal Fecha As Date, ByVal Fecha2 As Date, ByVal Sucursal As String, ByVal EMPRESA As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("dsr_rptn_conbros", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@FECHACOBRO", SqlDbType.Date)).Value = Fecha
        miComando.Parameters.Add(New SqlParameter("@FECHACOBRO2", SqlDbType.Date)).Value = Fecha2
        miComando.Parameters.Add(New SqlParameter("@SUCURSAL", SqlDbType.VarChar)).Value = Sucursal
        miComando.Parameters.Add(New SqlParameter("@EMPRESA", SqlDbType.VarChar)).Value = EMPRESA
        ActualizarConexion.Open()
        Dim AdaptadorDeDatos As New SqlDataAdapter(miComando)
        Dim dt As New DataTable

        AdaptadorDeDatos.Fill(dt)
        ActualizarConexion.Close()
        Return dt
    End Function

    Public Function Vendedores_Universo(ByVal Empresa As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim AdaptadorDeDatos As New SqlDataAdapter
        If Empresa = "SAN RAFAEL" Then
            AdaptadorDeDatos = New SqlDataAdapter(" SELECT '-1' AS CVE_VEND, 'TODOS' AS NOMBRE UNION ALL SELECT SAE60EMPRE05.dbo.VEND05.CVE_VEND, SAE60Empre05.dbo.VEND05.NOMBRE " & _
                                                  " FROM SAE60Empre05.dbo.VEND05 ", ActualizarConexion)
        End If
        If Empresa = "DIMOSA" Then
            AdaptadorDeDatos = New SqlDataAdapter(" SELECT '-1' AS CVE_VEND, 'TODOS' AS NOMBRE UNION ALL SELECT SAE60EMPRE06.dbo.VEND06.CVE_VEND, SAE60Empre06.dbo.VEND06.NOMBRE " &
                                                  " FROM SAE60Empre06.dbo.VEND06 ", ActualizarConexion)
        End If
        If Empresa = "OPL" Then
            AdaptadorDeDatos = New SqlDataAdapter(" SELECT '-1' AS CVE_VEND, 'TODOS' AS NOMBRE UNION ALL SELECT SAE60EMPRE08.dbo.VEND08.CVE_VEND, SAE60Empre08.dbo.VEND08.NOMBRE " &
                                                  " FROM SAE60Empre08.dbo.VEND08 ", ActualizarConexion)
        End If
        If Empresa = "SR AGRO" Then
            AdaptadorDeDatos = New SqlDataAdapter(" SELECT '-1' AS CVE_VEND, 'TODOS' AS NOMBRE UNION ALL SELECT SAE60EMPRE02.dbo.VEND02.CVE_VEND, SAE60Empre02.dbo.VEND02.NOMBRE " & _
                                                  " FROM SAE60Empre02.dbo.VEND02 ", ActualizarConexion)
        End If
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

    Public Function CARGA_Universo(ByVal Empresa As String, ByVal Vendedor As Integer)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim AdaptadorDeDatos As New SqlDataAdapter
        Dim micomando As New SqlCommand
        If Empresa = "SAN RAFAEL" Then
            micomando = New SqlCommand(" SELECT        dbo.CLIE05.CLAVE, REPLACE(REPLACE(dbo.CLIE05.NOMBRE,CHAR(10),''),CHAR(13),'') AS NOMBRE, dbo.VEND05.CVE_VEND AS RUTA, dbo.VEND05.NOMBRE AS VENDEDOR, dbo.CLIE05.PAG_WEB AS PROPIETARIO, dbo.CLIE05.TELEFONO AS TELEFONO, dbo.CLIE05.RFC AS DEPARTAMENTO,  " &
                         " REPLACE(REPLACE(dbo.CLIE05.LOCALIDAD,CHAR(10),''),CHAR(13),'') AS MUNICIPIO, REPLACE(REPLACE(dbo.CLIE05.COLONIA,CHAR(10),''),CHAR(13),'') as COLONIA, REPLACE(REPLACE(dbo.CLIE05.CALLE,CHAR(10),''),CHAR(13),'') AS DIRECCION, dbo.CLIE_CLIB05.CAMPLIB14 AS LONG, dbo.CLIE_CLIB05.CAMPLIB15 AS LAT, CASE substring(CLIE05.CLASIFIC, 5, 1)  " &
                         " WHEN 'P' THEN 'SPS' WHEN 'R' THEN 'SRC' WHEN 'T' THEN 'SAB' WHEN 'G' THEN 'TGU' END AS SUCURSAL, ISNULL(dbo.CLIE_CLIB05.CAMPLIB3,'') AS 'VISITA', FCH_ULTCOM AS 'ULTIMA COMPRA', ISNULL(dbo.CLIE_CLIB05.CAMPLIB32, '') AS CERTIFICADO, CASE ISNULL(dbo.CLIE_CLIB05.CAMPLIB18,'') WHEN '' THEN '' ELSE 'BLOQUEADO' END AS 'FILTRO NESTLE', CASE ISNULL(dbo.CLIE_CLIB05.CAMPLIB33,'') WHEN '' THEN '' ELSE 'BLOQUEADO' END AS 'FILTRO BIC', CAMPLIB17 as 'FECHA CREACION' " &
                         " FROM            dbo.CLIE05 INNER JOIN dbo.VEND05 ON dbo.CLIE05.CVE_VEND = dbo.VEND05.CVE_VEND INNER JOIN " &
                         " dbo.CLIE_CLIB05 ON dbo.CLIE05.CLAVE = dbo.CLIE_CLIB05.CVE_CLIE WHERE dbo.CLIE05.CVE_VEND = @VENDEDOR OR (dbo.CLIE05.CVE_VEND <> '  100' and @VENDEDOR = -1) ", ActualizarConexion)
        End If
        If Empresa = "DIMOSA" Then
            micomando = New SqlCommand(" SELECT        SAE60EMPRE06.dbo.CLIE06.CLAVE,REPLACE(REPLACE(SAE60EMPRE06.dbo.CLIE06.NOMBRE,CHAR(10),''),CHAR(13),'') NOMBRE, SAE60EMPRE06.dbo.VEND06.CVE_VEND AS RUTA, SAE60EMPRE06.dbo.VEND06.NOMBRE AS VENDEDOR, SAE60EMPRE06.dbo.CLIE06.PAG_WEB AS PROPIETARIO, SAE60EMPRE06.dbo.CLIE06.TELEFONO AS TELEFONO, SAE60EMPRE06.dbo.CLIE06.RFC AS DEPARTAMENTO, " &
                         " REPLACE(REPLACE(SAE60EMPRE06.dbo.CLIE06.LOCALIDAD,CHAR(10),''),CHAR(13),'') AS MUNICIPIO, REPLACE(REPLACE(SAE60EMPRE06.dbo.CLIE06.COLONIA,CHAR(10),''),CHAR(13),'') as COLONIA, REPLACE(REPLACE(SAE60EMPRE06.dbo.CLIE06.CALLE,CHAR(10),''),CHAR(13),'') AS DIRECCION, SAE60EMPRE06.dbo.CLIE_CLIB06.CAMPLIB14 AS LONG, SAE60EMPRE06.dbo.CLIE_CLIB06.CAMPLIB15 AS LAT, CASE substring(SAE60EMPRE06.dbo.CLIE06.CLASIFIC, 5, 1)  " &
                         " WHEN 'P' THEN 'SPS' WHEN 'R' THEN 'SRC' WHEN 'T' THEN 'SAB' WHEN 'G' THEN 'TGU' END AS SUCURSAL, ISNULL(SAE60EMPRE06.dbo.CLIE_CLIB06.CAMPLIB3,'') AS 'VISITA', SAE60EMPRE06.dbo.CLIE06.FCH_ULTCOM AS 'ULTIMA COMPRA', ISNULL(SAE60EMPRE06.dbo.CLIE_CLIB06.CAMPLIB32, '') AS CERTIFICADO, CAMPLIB17 as 'FECHA CREACION' " &
                         " FROM            SAE60EMPRE06.dbo.CLIE06 INNER JOIN  SAE60EMPRE06.dbo.VEND06 ON SAE60EMPRE06.dbo.CLIE06.CVE_VEND = SAE60EMPRE06.dbo.VEND06.CVE_VEND INNER JOIN " &
                         " SAE60EMPRE06.dbo.CLIE_CLIB06 ON SAE60EMPRE06.dbo.CLIE06.CLAVE = SAE60EMPRE06.dbo.CLIE_CLIB06.CVE_CLIE WHERE SAE60EMPRE06.dbo.CLIE06.CVE_VEND = @VENDEDOR OR (SAE60EMPRE06.dbo.CLIE06.CVE_VEND <> '  100' and @VENDEDOR = -1) ", ActualizarConexion)
        End If
        If Empresa = "SR AGRO" Then
            micomando = New SqlCommand(" SELECT        Usuarios.dbo.Matinal_SRAgro_Clientes.Cliente AS [CLAVE CLIENTE], REPLACE(REPLACE(SAE60EMPRE02.dbo.CLIE02.NOMBRE,CHAR(10),''),CHAR(13),'') AS CLIENTE, Usuarios.dbo.Matinal_SRAgro_Clientes.Linea AS TIPO, SAE60EMPRE02.dbo.CLIE02.TELEFONO, " &
                         " Usuarios.dbo.Matinal_SRAgro_Clientes.VendedorAsignado AS [CLAVE VEND], SAE60Empre02.dbo.VEND02.NOMBRE AS VENDEDOR, SAE60Empre02.dbo.CLIE02.CLASIFIC,  " &
                         " SUBSTRING(SAE60Empre02.dbo.CLIE02.CLASIFIC, 1, 1) AS BALANCEADOS, SUBSTRING(SAE60Empre02.dbo.CLIE02.CLASIFIC, 2, 1) AS MASCOTAS, SUBSTRING(SAE60Empre02.dbo.CLIE02.CLASIFIC, 3, 1) " &
                         " AS FERTILIZANTES, SUBSTRING(SAE60Empre02.dbo.CLIE02.CLASIFIC, 4, 1) AS SACOS, SUBSTRING(SAE60Empre02.dbo.CLIE02.CLASIFIC, 5, 1) AS INSUMOS,  " &
                         " ISNULL(SAE60Empre02.dbo.CLIE_CLIB02.CAMPLIB22, '') AS X, ISNULL(SAE60Empre02.dbo.CLIE_CLIB02.CAMPLIB21, '') AS Y, CASE ISNULL(Usuarios.dbo.Matinal_SRAgro_Clientes.DIA, '') " &
                         " WHEN 1 THEN 'LUNES' WHEN 2 THEN 'MARTES' WHEN 3 THEN 'MIERCOLES' WHEN 4 THEN 'JUEVES' WHEN 5 THEN 'VIERNES' WHEN 6 THEN 'SABADO' ELSE '' END AS [DIA VISITA], " &
                         " ISNULL(Usuarios.dbo.Matinal_SRAgro_Clientes.FRECUENCIA, '') AS [FRECUENCIA VISITA (SEMANAS)],  SAE60Empre02.dbo.CLIE02.FCH_ULTCOM AS 'ULTIMA COMPRA',  ISNULL(SAE60Empre02.dbo.CLIE_CLIB02.CAMPLIB27, '') AS 'COORDENADAS CERTIFICADAS', CAMPLIB23 as 'FECHA CREACION' " &
                         " FROM            Usuarios.dbo.Matinal_SRAgro_Clientes INNER JOIN SAE60Empre02.dbo.CLIE02 ON LTRIM(SAE60Empre02.dbo.CLIE02.CLAVE) = LTRIM(Usuarios.dbo.Matinal_SRAgro_Clientes.Cliente) INNER JOIN " &
                         " SAE60Empre02.dbo.VEND02 ON LTRIM(SAE60Empre02.dbo.VEND02.CVE_VEND) = LTRIM(Usuarios.dbo.Matinal_SRAgro_Clientes.VendedorAsignado) INNER JOIN " &
                         " SAE60Empre02.dbo.CLIE_CLIB02 ON SAE60Empre02.dbo.CLIE_CLIB02.CVE_CLIE = SAE60Empre02.dbo.CLIE02.CLAVE WHERE Usuarios.dbo.Matinal_SRAgro_Clientes.VendedorAsignado = @VENDEDOR OR @VENDEDOR = -1 ", ActualizarConexion)
        End If
        If Empresa = "OPL" Then
            micomando = New SqlCommand(" SELECT        SAE60EMPRE08.dbo.CLIE08.CLAVE,REPLACE(REPLACE(SAE60EMPRE08.dbo.CLIE08.NOMBRE,CHAR(10),''),CHAR(13),'') NOMBRE, SAE60EMPRE08.dbo.VEND08.CVE_VEND AS RUTA, SAE60EMPRE08.dbo.VEND08.NOMBRE AS VENDEDOR, SAE60EMPRE08.dbo.CLIE08.PAG_WEB AS PROPIETARIO, SAE60EMPRE08.dbo.CLIE08.TELEFONO AS TELEFONO, SAE60EMPRE08.dbo.CLIE08.RFC AS DEPARTAMENTO, " &
                         " REPLACE(REPLACE(SAE60EMPRE08.dbo.CLIE08.LOCALIDAD,CHAR(10),''),CHAR(13),'') AS MUNICIPIO, REPLACE(REPLACE(SAE60EMPRE08.dbo.CLIE08.COLONIA,CHAR(10),''),CHAR(13),'') as COLONIA, REPLACE(REPLACE(SAE60EMPRE08.dbo.CLIE08.CALLE,CHAR(10),''),CHAR(13),'') AS DIRECCION, SAE60EMPRE08.dbo.CLIE_CLIB08.CAMPLIB14 AS LONG, SAE60EMPRE08.dbo.CLIE_CLIB08.CAMPLIB15 AS LAT, CASE substring(SAE60EMPRE08.dbo.CLIE08.CLASIFIC, 5, 1)  " &
                         " WHEN 'P' THEN 'SPS' WHEN 'R' THEN 'SRC' WHEN 'T' THEN 'SAB' WHEN 'G' THEN 'TGU' END AS SUCURSAL, ISNULL(SAE60EMPRE08.dbo.CLIE_CLIB08.CAMPLIB3,'') AS 'VISITA', SAE60EMPRE08.dbo.CLIE08.FCH_ULTCOM AS 'ULTIMA COMPRA', ISNULL(SAE60EMPRE08.dbo.CLIE_CLIB08.CAMPLIB32, '') AS CERTIFICADO, CAMPLIB17 as 'FECHA CREACION' " &
                         " FROM            SAE60EMPRE08.dbo.CLIE08 INNER JOIN  SAE60EMPRE08.dbo.VEND08 ON SAE60EMPRE08.dbo.CLIE08.CVE_VEND = SAE60EMPRE08.dbo.VEND08.CVE_VEND INNER JOIN " &
                         " SAE60EMPRE08.dbo.CLIE_CLIB08 ON SAE60EMPRE08.dbo.CLIE08.CLAVE = SAE60EMPRE08.dbo.CLIE_CLIB08.CVE_CLIE WHERE SAE60EMPRE08.dbo.CLIE08.CVE_VEND = @VENDEDOR OR (SAE60EMPRE08.dbo.CLIE08.CVE_VEND <> '  100' and @VENDEDOR = -1) ", ActualizarConexion)
        End If
        micomando.Parameters.AddWithValue("@VENDEDOR", Vendedor)
        AdaptadorDeDatos = New SqlDataAdapter(micomando)
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

    Public Function VentaClientesRiesgo(ByVal Fecha1 As Date, ByVal Fecha2 As Date, ByVal VENDEDOR As String, ByVal SUPERVISOR As Integer)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("rptn_clientes_riesgo_filtro", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.CommandTimeout = 5000
        miComando.Parameters.AddWithValue("@FECHA1", Fecha1.Date)
        miComando.Parameters.AddWithValue("@FECHA2", Fecha2.Date)
        miComando.Parameters.AddWithValue("@VENDEDOR", VENDEDOR)
        miComando.Parameters.AddWithValue("@SUPERVISOR", SUPERVISOR)

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

    Public Function VentaClientesRiesgoDIMOSA(ByVal Fecha1 As Date, ByVal Fecha2 As Date, ByVal VENDEDOR As String, ByVal SUPERVISOR As Integer)
        Dim ActualizarConexion As New SqlConnection(ConexionDIMOSA.CadenaSQL())
        Dim miComando As New SqlCommand("rptn_clientes_riesgo_filtro", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.CommandTimeout = 5000
        miComando.Parameters.AddWithValue("@FECHA1", Fecha1.Date)
        miComando.Parameters.AddWithValue("@FECHA2", Fecha2.Date)
        miComando.Parameters.AddWithValue("@VENDEDOR", VENDEDOR)
        miComando.Parameters.AddWithValue("@SUPERVISOR", SUPERVISOR)

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

    Public Function VentaClientesRiesgoAgro(ByVal Fecha1 As Date, ByVal Fecha2 As Date, ByVal VENDEDOR As String)
        Dim ActualizarConexion As New SqlConnection(ConexionAgro.CadenaSQL())
        Dim miComando As New SqlCommand("rptn_clientes_riesgo", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.CommandTimeout = 5000
        miComando.Parameters.AddWithValue("@FECHA1", Fecha1.Date)
        miComando.Parameters.AddWithValue("@FECHA2", Fecha2.Date)
        miComando.Parameters.AddWithValue("@VENDEDOR", VENDEDOR)

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

    Public Function NumeroClientesRiesgo(ByVal Vendedor As String, ByVal Empresa As String)
        Dim ActualizarConexion As New SqlConnection(ConexionUsuario.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT         META_CLIENTES_MENSUAL  " & _
                                        " FROM METAS_CLIENTES_RIESGO " & _
                                        " WHERE VENDEDOR = @VENDEDOR AND EMPRESA = @EMPRESA", ActualizarConexion)

        miComando.CommandTimeout = 5000
        miComando.Parameters.AddWithValue("@VENDEDOR", Vendedor)
        miComando.Parameters.AddWithValue("@EMPRESA", Empresa)

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

    Public Function VendedoresPorSupervisor(ByVal Supervisor As Integer, ByVal Empresa As String)
        Dim ActualizarConexion As New SqlConnection(ConexionUsuario.CadenaSQL())
        Dim AdaptadorDeDatos As New SqlDataAdapter

        If Empresa = "SAN RAFAEL" Then
            AdaptadorDeDatos = New SqlDataAdapter(" SELECT '-1' as CVE_VEND, 'TODOS' AS NOMBRE, 0 as SUPERVISOR UNION ALL SELECT dbo.Supervisor_Vendedor.CVE_VEND, SAE60Empre05.dbo.VEND05.NOMBRE, dbo.Supervisor_Vendedor.SUPERVISOR " & _
                                                    " FROM dbo.Supervisor_Vendedor INNER JOIN dbo.Supervisores ON dbo.Supervisor_Vendedor.SUPERVISOR = dbo.Supervisores.CODIGO_SUPERVISOR INNER JOIN " & _
                                                    " SAE60Empre05.dbo.VEND05 ON dbo.Supervisor_Vendedor.CVE_VEND = SAE60Empre05.dbo.VEND05.CVE_VEND COLLATE MODERN_SPANISH_CI_AS WHERE     (dbo.Supervisor_Vendedor.SUPERVISOR = " & Supervisor & ") and Supervisores.Empresa = '" & Empresa & "'", ActualizarConexion)
        End If
        If Empresa = "DIMOSA" Then
            AdaptadorDeDatos = New SqlDataAdapter(" SELECT '-1' as CVE_VEND, 'TODOS' AS NOMBRE, 0 AS SUPERVISOR UNION ALL SELECT dbo.Supervisor_Vendedor.CVE_VEND, SAE60Empre06.dbo.VEND06.NOMBRE, dbo.Supervisor_Vendedor.SUPERVISOR " & _
                                                    " FROM dbo.Supervisor_Vendedor INNER JOIN dbo.Supervisores ON dbo.Supervisor_Vendedor.SUPERVISOR = dbo.Supervisores.CODIGO_SUPERVISOR INNER JOIN " & _
                                                    " SAE60Empre06.dbo.VEND06 ON dbo.Supervisor_Vendedor.CVE_VEND = SAE60Empre06.dbo.VEND06.CVE_VEND COLLATE MODERN_SPANISH_CI_AS WHERE     (dbo.Supervisor_Vendedor.SUPERVISOR = " & Supervisor & ") and Supervisores.Empresa = '" & Empresa & "'", ActualizarConexion)
        End If
        
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

    Public Function VendedoresEMPRESA(ByVal Empresa As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim AdaptadorDeDatos As New SqlDataAdapter
        If Empresa = "SAN RAFAEL" Then
            AdaptadorDeDatos = New SqlDataAdapter(" SELECT SAE60EMPRE05.dbo.VEND05.CVE_VEND, SAE60Empre05.dbo.VEND05.NOMBRE " & _
                                                  " FROM SAE60Empre05.dbo.VEND05 ", ActualizarConexion)
        End If
        If Empresa = "DIMOSA" Then
            AdaptadorDeDatos = New SqlDataAdapter(" SELECT SAE60EMPRE06.dbo.VEND06.CVE_VEND, SAE60Empre06.dbo.VEND06.NOMBRE " & _
                                                  " FROM SAE60Empre06.dbo.VEND06 ", ActualizarConexion)
        End If
        If Empresa = "SR AGRO" Then
            AdaptadorDeDatos = New SqlDataAdapter(" SELECT SAE60EMPRE02.dbo.VEND02.CVE_VEND, SAE60Empre02.dbo.VEND02.NOMBRE " & _
                                                  " FROM SAE60Empre02.dbo.VEND02 ", ActualizarConexion)
        End If
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

End Class
