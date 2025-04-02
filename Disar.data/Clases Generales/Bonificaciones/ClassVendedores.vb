Imports System.Data.SqlClient
Imports System.Text

Public Class ClassVendedores
    Dim Conexion As New clsconexion_consumo
    Dim Conexion2 As New cls_conexion_DIMOSA
    Dim ConexionUsuarios As New clsConexion


    Public Function CargarSupervisores_nuevos(ByVal Empresa As String) As DataView
        Dim ActualizarConexion As New SqlConnection(ConexionUsuarios.CadenaSQL())
        ActualizarConexion.Open()

        Dim query As New StringBuilder
        query.Append("SELECT CODIGO_SUPERVISOR as 'Código de Supervisor', SUPERVISOR as 'Nombre', ")
        query.Append(" Tipo as 'Clasificación', EMPRESA AS Empresa ")
        query.Append("FROM Supervisores WHERE ISNULL(ACTIVO_BONO,0) = 1 AND EMPRESA = '" & Empresa & "'")
        Dim AdaptadorDeDatos As New SqlDataAdapter(query.ToString(), ActualizarConexion)

        Dim ds As New DataSet
        Dim dv As New DataView
        Try
            AdaptadorDeDatos.Fill(ds, "Super")
            If ds.Tables("Super").Rows.Count > 0 Then
                dv = New DataView(ds.Tables("Super"))
            End If
        Catch ex As SqlException
            MsgBox("Hay problemas de Conexión: " + ex.Message, MsgBoxStyle.Critical)

        End Try
        ActualizarConexion.Close()
        Return dv
    End Function

    Public Function CargarVendedores(ByVal Empresa As String, ByVal TIPO As String) As DataView
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim ActualizarConexion2 As New SqlConnection(Conexion2.CadenaSQL())
        ActualizarConexion.Open()
        Dim AdaptadorDeDatos As New SqlDataAdapter

        If TIPO = "AMBOS" Then
            If Empresa = "SAN RAFAEL" Then
                AdaptadorDeDatos = New SqlDataAdapter("SELECT CVE_VEND AS 'Código de Vendedor', NOMBRE AS 'Nombre', STATUS AS 'Status', CLASIFIC AS 'Clasificación' FROM VEND05 WHERE (CLASIFIC = 'MAY' OR CLASIFIC = 'DET' OR CLASIFIC = 'KCP' OR CLASIFIC = 'V.Int') and UPPER(NOMBRE) NOT LIKE '%DISP%' ORDER BY Nombre ASC", ActualizarConexion)
            ElseIf Empresa = "DIMOSA" Then
                AdaptadorDeDatos = New SqlDataAdapter("SELECT CVE_VEND AS 'Código de Vendedor', NOMBRE AS 'Nombre', STATUS AS 'Status', CLASIFIC AS 'Clasificación' FROM VEND06 WHERE (CLASIFIC = 'MAY' OR CLASIFIC = 'DET' OR CLASIFIC = 'KCP' OR CLASIFIC = 'V.Int') and UPPER(NOMBRE) NOT LIKE '%DISP%' ORDER BY Nombre ASC", ActualizarConexion2)
            Else
                AdaptadorDeDatos = New SqlDataAdapter("SELECT        SAE60Empre02.dbo.VEND02.CVE_VEND, UPPER(SAE60Empre02.dbo.VEND02.NOMBRE) AS VENDEDOR, Usuarios.dbo.Matinal_SRAgro_Segmentos.TIPO, SAE60Empre02.dbo.VEND02.CLASIFIC AS 'Clasificación' " & _
                                                       " FROM            SAE60Empre02.dbo.VEND02 INNER JOIN " & _
                                                       " Usuarios.dbo.Matinal_SRAgro_Segmentos ON Usuarios.dbo.Matinal_SRAgro_Segmentos.VENDEDOR = SAE60Empre02.dbo.VEND02.CVE_VEND COLLATE MODERN_SPANISH_CI_AS " & _
                                                      " WHERE        (SAE60Empre02.dbo.VEND02.CVE_VEND IN ('   21', '   28', '   30', '   35', '   31', '  104', '  108')) ORDER BY SAE60Empre02.dbo.VEND02.NOMBRE ASC", ActualizarConexion)
            End If

        ElseIf TIPO = "DETALLE" Then
            If Empresa = "SAN RAFAEL" Then
                AdaptadorDeDatos = New SqlDataAdapter("SELECT CVE_VEND AS 'Código de Vendedor', NOMBRE AS 'Nombre', STATUS AS 'Status', CLASIFIC AS 'Clasificación' FROM VEND05 WHERE (CLASIFIC = 'DET' OR CLASIFIC = 'KCP' OR CLASIFIC = 'V.Int') and UPPER(NOMBRE) NOT LIKE '%DISP%' ORDER BY Nombre ASC", ActualizarConexion)
            ElseIf Empresa = "DIMOSA" Then
                AdaptadorDeDatos = New SqlDataAdapter("SELECT CVE_VEND AS 'Código de Vendedor', NOMBRE AS 'Nombre', STATUS AS 'Status', CLASIFIC AS 'Clasificación' FROM VEND06 WHERE (CLASIFIC = 'DET' OR CLASIFIC = 'KCP' OR CLASIFIC = 'V.Int') and UPPER(NOMBRE) NOT LIKE '%DISP%' ORDER BY Nombre ASC", ActualizarConexion2)
            Else
                AdaptadorDeDatos = New SqlDataAdapter("SELECT        SAE60Empre02.dbo.VEND02.CVE_VEND, UPPER(SAE60Empre02.dbo.VEND02.NOMBRE) AS VENDEDOR, Usuarios.dbo.Matinal_SRAgro_Segmentos.TIPO, SAE60Empre02.dbo.VEND02.CLASIFIC AS 'Clasificación' " & _
                                                       " FROM            SAE60Empre02.dbo.VEND02 INNER JOIN " & _
                                                       " Usuarios.dbo.Matinal_SRAgro_Segmentos ON Usuarios.dbo.Matinal_SRAgro_Segmentos.VENDEDOR = SAE60Empre02.dbo.VEND02.CVE_VEND COLLATE MODERN_SPANISH_CI_AS " & _
                                                      " WHERE        (SAE60Empre02.dbo.VEND02.CVE_VEND IN ('   21', '   28', '   30', '   35', '   31', '  104', '  108')) ORDER BY SAE60Empre02.dbo.VEND02.NOMBRE ASC", ActualizarConexion)
            End If
        Else
            If Empresa = "SAN RAFAEL" Then
                AdaptadorDeDatos = New SqlDataAdapter("SELECT CVE_VEND AS 'Código de Vendedor', NOMBRE AS 'Nombre', STATUS AS 'Status', CLASIFIC AS 'Clasificación' FROM VEND05 WHERE (CLASIFIC = 'MAY') and UPPER(NOMBRE) NOT LIKE '%DISP%' ORDER BY Nombre ASC", ActualizarConexion)
            ElseIf Empresa = "DIMOSA" Then
                AdaptadorDeDatos = New SqlDataAdapter("SELECT CVE_VEND AS 'Código de Vendedor', NOMBRE AS 'Nombre', STATUS AS 'Status', CLASIFIC AS 'Clasificación' FROM VEND06 WHERE (CLASIFIC = 'MAY') and UPPER(NOMBRE) NOT LIKE '%DISP%' ORDER BY Nombre ASC", ActualizarConexion2)
            Else
                AdaptadorDeDatos = New SqlDataAdapter("SELECT        SAE60Empre02.dbo.VEND02.CVE_VEND, UPPER(SAE60Empre02.dbo.VEND02.NOMBRE) AS VENDEDOR, Usuarios.dbo.Matinal_SRAgro_Segmentos.TIPO, SAE60Empre02.dbo.VEND02.CLASIFIC AS 'Clasificación' " & _
                                                       " FROM            SAE60Empre02.dbo.VEND02 INNER JOIN " & _
                                                       " Usuarios.dbo.Matinal_SRAgro_Segmentos ON Usuarios.dbo.Matinal_SRAgro_Segmentos.VENDEDOR = SAE60Empre02.dbo.VEND02.CVE_VEND COLLATE MODERN_SPANISH_CI_AS " & _
                                                      " WHERE        (SAE60Empre02.dbo.VEND02.CVE_VEND IN ('   21', '   28', '   30', '   35', '   31', '  104', '  108')) ORDER BY SAE60Empre02.dbo.VEND02.NOMBRE ASC", ActualizarConexion)
            End If
        End If

        Dim ds As New DataSet
        Dim dv As New DataView
        Try
            AdaptadorDeDatos.Fill(ds, "Vendedores")
            If ds.Tables("Vendedores").Rows.Count > 0 Then
                dv = New DataView(ds.Tables("Vendedores"))
            End If
        Catch ex As SqlException
            MsgBox("Hay problemas de Conexión: Prueba-" + ex.Message, MsgBoxStyle.Critical)

        End Try
        ActualizarConexion.Close()
        Return dv
    End Function

    Public Function CargarVendedoresPORSUPERVISOR(ByVal Supervisor As String, ByVal Empresa As String, ByVal Tipo As String) As DataView
        Dim ActualizarConexion As New SqlConnection(ConexionUsuarios.CadenaSQL())
        ActualizarConexion.Open()
        Dim AdaptadorDeDatos As New SqlDataAdapter

        If Tipo = "AMBOS" Then
            If Empresa = "SAN RAFAEL" Then
                AdaptadorDeDatos = New SqlDataAdapter("SELECT     TOP (100) PERCENT SAE60Empre05.dbo.VEND05.CVE_VEND as CODIGO, SAE60Empre05.dbo.VEND05.NOMBRE, SAE60Empre05.dbo.VEND05.STATUS," & _
        "SAE60Empre05.dbo.VEND05.CLASIFIC " & _
        " FROM         dbo.Supervisor_Vendedor INNER JOIN " & _
        " SAE60Empre05.dbo.VEND05 ON SAE60Empre05.dbo.VEND05.CVE_VEND = dbo.Supervisor_Vendedor.CVE_VEND COLLATE Latin1_General_BIN " & _
        " WHERE     (SAE60Empre05.dbo.VEND05.CLASIFIC = 'MAY') AND SUPERVISOR = '" & Supervisor & "' OR " & _
        "                      (SAE60Empre05.dbo.VEND05.CLASIFIC = 'DET') AND SUPERVISOR = '" & Supervisor & "' OR " & _
        "                      (SAE60Empre05.dbo.VEND05.CLASIFIC = 'KCP') AND SUPERVISOR = '" & Supervisor & "' OR " & _
        "                      (SAE60Empre05.dbo.VEND05.CLASIFIC = 'V.Int') AND SUPERVISOR = '" & Supervisor & "'" & _
        " ORDER BY SAE60Empre05.dbo.VEND05.NOMBRE", ActualizarConexion)
            Else
                AdaptadorDeDatos = New SqlDataAdapter("SELECT     TOP (100) PERCENT SAE60Empre06.dbo.VEND06.CVE_VEND as CODIGO, SAE60Empre06.dbo.VEND06.NOMBRE, SAE60Empre06.dbo.VEND06.STATUS," & _
        "SAE60Empre06.dbo.VEND06.CLASIFIC " & _
        " FROM         dbo.Supervisor_Vendedor INNER JOIN " & _
        " SAE60Empre06.dbo.VEND06 ON SAE60Empre06.dbo.VEND06.CVE_VEND = dbo.Supervisor_Vendedor.CVE_VEND COLLATE Latin1_General_BIN " & _
        " WHERE     (SAE60Empre06.dbo.VEND06.CLASIFIC = 'MAY') AND SUPERVISOR = '" & Supervisor & "' OR " & _
        "                      (SAE60Empre06.dbo.VEND06.CLASIFIC = 'DET') AND SUPERVISOR = '" & Supervisor & "' OR " & _
        "                      (SAE60Empre06.dbo.VEND06.CLASIFIC = 'KCP') AND SUPERVISOR = '" & Supervisor & "' OR " & _
        "                      (SAE60Empre06.dbo.VEND06.CLASIFIC = 'V.Int') AND SUPERVISOR = '" & Supervisor & "'" & _
        " ORDER BY SAE60Empre06.dbo.VEND06.NOMBRE", ActualizarConexion)
            End If
        ElseIf Tipo = "DETALLE" Then
            If Empresa = "SAN RAFAEL" Then
                AdaptadorDeDatos = New SqlDataAdapter("SELECT     TOP (100) PERCENT SAE60Empre05.dbo.VEND05.CVE_VEND as CODIGO, SAE60Empre05.dbo.VEND05.NOMBRE, SAE60Empre05.dbo.VEND05.STATUS," & _
        "SAE60Empre05.dbo.VEND05.CLASIFIC " & _
        " FROM         dbo.Supervisor_Vendedor INNER JOIN " & _
        " SAE60Empre05.dbo.VEND05 ON SAE60Empre05.dbo.VEND05.CVE_VEND = dbo.Supervisor_Vendedor.CVE_VEND COLLATE Latin1_General_BIN " & _
        " WHERE      " & _
        "                      (SAE60Empre05.dbo.VEND05.CLASIFIC = 'DET') AND SUPERVISOR = '" & Supervisor & "' OR " & _
        "                      (SAE60Empre05.dbo.VEND05.CLASIFIC = 'KCP') AND SUPERVISOR = '" & Supervisor & "' OR " & _
        "                      (SAE60Empre05.dbo.VEND05.CLASIFIC = 'V.Int') AND SUPERVISOR = '" & Supervisor & "'" & _
        " ORDER BY SAE60Empre05.dbo.VEND05.NOMBRE", ActualizarConexion)
            Else
                AdaptadorDeDatos = New SqlDataAdapter("SELECT     TOP (100) PERCENT SAE60Empre06.dbo.VEND06.CVE_VEND as CODIGO, SAE60Empre06.dbo.VEND06.NOMBRE, SAE60Empre06.dbo.VEND06.STATUS," & _
        "SAE60Empre06.dbo.VEND06.CLASIFIC " & _
        " FROM         dbo.Supervisor_Vendedor INNER JOIN " & _
        " SAE60Empre06.dbo.VEND06 ON SAE60Empre06.dbo.VEND06.CVE_VEND = dbo.Supervisor_Vendedor.CVE_VEND COLLATE Latin1_General_BIN " & _
        " WHERE       " & _
        "                      (SAE60Empre06.dbo.VEND06.CLASIFIC = 'DET') AND SUPERVISOR = '" & Supervisor & "' OR " & _
        "                      (SAE60Empre06.dbo.VEND06.CLASIFIC = 'KCP') AND SUPERVISOR = '" & Supervisor & "' OR " & _
        "                      (SAE60Empre06.dbo.VEND06.CLASIFIC = 'V.Int') AND SUPERVISOR = '" & Supervisor & "'" & _
        " ORDER BY SAE60Empre06.dbo.VEND06.NOMBRE", ActualizarConexion)
            End If
        Else
            If Empresa = "SAN RAFAEL" Then
                AdaptadorDeDatos = New SqlDataAdapter("SELECT     TOP (100) PERCENT SAE60Empre05.dbo.VEND05.CVE_VEND as CODIGO, SAE60Empre05.dbo.VEND05.NOMBRE, SAE60Empre05.dbo.VEND05.STATUS," & _
        "SAE60Empre05.dbo.VEND05.CLASIFIC " & _
        " FROM         dbo.Supervisor_Vendedor INNER JOIN " & _
        " SAE60Empre05.dbo.VEND05 ON SAE60Empre05.dbo.VEND05.CVE_VEND = dbo.Supervisor_Vendedor.CVE_VEND COLLATE Latin1_General_BIN " & _
        " WHERE      " & _
        "                      (SAE60Empre05.dbo.VEND05.CLASIFIC = 'MAY') AND SUPERVISOR = '" & Supervisor & "'  " & _
        " ORDER BY SAE60Empre05.dbo.VEND05.NOMBRE", ActualizarConexion)
            Else
                AdaptadorDeDatos = New SqlDataAdapter("SELECT     TOP (100) PERCENT SAE60Empre06.dbo.VEND06.CVE_VEND as CODIGO, SAE60Empre06.dbo.VEND06.NOMBRE, SAE60Empre06.dbo.VEND06.STATUS," & _
        "SAE60Empre06.dbo.VEND06.CLASIFIC " & _
        " FROM         dbo.Supervisor_Vendedor INNER JOIN " & _
        " SAE60Empre06.dbo.VEND06 ON SAE60Empre06.dbo.VEND06.CVE_VEND = dbo.Supervisor_Vendedor.CVE_VEND COLLATE Latin1_General_BIN " & _
        " WHERE       " & _
        "                      (SAE60Empre06.dbo.VEND06.CLASIFIC = 'MAY') AND SUPERVISOR = '" & Supervisor & "' " & _
        " ORDER BY SAE60Empre06.dbo.VEND06.NOMBRE", ActualizarConexion)
            End If
        End If
        

        Dim ds As New DataSet
        Dim dv As New DataView
        Try
            AdaptadorDeDatos.Fill(ds, "Vendedores")
            If ds.Tables("Vendedores").Rows.Count > 0 Then
                dv = New DataView(ds.Tables("Vendedores"))
            End If
        Catch ex As SqlException
            MsgBox("Hay problemas de Conexión: " + ex.Message, MsgBoxStyle.Critical)

        End Try
        ActualizarConexion.Close()
        Return dv
    End Function

    Public Function Insertar_ListaVendedores(ByVal Lista As String, ByVal Cod As String, ByVal Tipo As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("INSERT INTO [Usuarios].[dbo].[LIST_BONIFIC] " & _
                                        "(ListaNombre, CodigoListar, Tipo) " & _
                                        "VALUES (@ListaNombre, @CodigoListar, @Tipo) ", ActualizarConexion)

        miComando.Parameters.AddWithValue("@ListaNombre", Lista)
        miComando.Parameters.AddWithValue("@CodigoListar", Cod)
        miComando.Parameters.AddWithValue("@Tipo", Tipo)


        ActualizarConexion.Open()

        'Try
        miComando.ExecuteNonQuery()
        ActualizarConexion.Close()
        Return True
        'Catch ex As Exception
        'Return False

        'End Try
    End Function

    Public Function CargarListas() As DataView
        Dim ActualizarConexion As New SqlConnection(ConexionUsuarios.CadenaSQL())
        ActualizarConexion.Open()
        Dim AdaptadorDeDatos As New SqlDataAdapter("SELECT DISTINCT ListaNombre FROM LIST_BONIFIC", ActualizarConexion)
        Dim ds As New DataSet
        Dim dv As New DataView
        Try
            AdaptadorDeDatos.Fill(ds, "Vendedores")
            If ds.Tables("Vendedores").Rows.Count > 0 Then
                dv = New DataView(ds.Tables("Vendedores"))
            End If
        Catch ex As SqlException
            MsgBox("Hay problemas de Conexión: " + ex.Message, MsgBoxStyle.Critical)

        End Try
        ActualizarConexion.Close()
        Return dv
    End Function

    Public Function SeleccionarListas(ByVal Nombre As String) As DataView
        Dim ActualizarConexion As New SqlConnection(ConexionUsuarios.CadenaSQL())
        ActualizarConexion.Open()
        Dim AdaptadorDeDatos As New SqlDataAdapter("SELECT CodigoListar, Tipo FROM LIST_BONIFIC WHERE ListaNombre  = '" & RTrim(LTrim(Nombre)) & "'  ", ActualizarConexion)
        Dim ds As New DataSet
        Dim dv As New DataView
        Try
            AdaptadorDeDatos.Fill(ds, "Vendedores")
            If ds.Tables("Vendedores").Rows.Count > 0 Then
                dv = New DataView(ds.Tables("Vendedores"))
            End If
        Catch ex As SqlException
            MsgBox("Hay problemas de Conexión: " + ex.Message, MsgBoxStyle.Critical)

        End Try
        ActualizarConexion.Close()
        Return dv
    End Function

    Public Function CargarSupervisores(ByVal Empresa As String) As DataView
        Dim ActualizarConexion As New SqlConnection(ConexionUsuarios.CadenaSQL())
        ActualizarConexion.Open()
        Dim AdaptadorDeDatos As New SqlDataAdapter("SELECT CODIGO_SUPERVISOR as 'Código de Supervisor', SUPERVISOR as 'Nombre', CLASIFIC as 'Clasificación', ALMACEN as 'Almacén' FROM  Supervisores " & _
        " WHERE " & _
        " (USUARIOS.dbo.Supervisores.EMPRESA = '" & Empresa & "' or USUARIOS.dbo.Supervisores.EMPRESA = 'AMBAS') " & _
        " AND USUARIOS.dbo.Supervisores.SUPERVISOR NOT LIKE '%DISPO%'  " & _
        " AND USUARIOS.dbo.Supervisores.SUPERVISOR NOT LIKE '%SUSPEN%'  " & _
        " AND USUARIOS.dbo.Supervisores.SUPERVISOR NOT LIKE '%INAC%' " & _
        " AND USUARIOS.dbo.Supervisores.SUPERVISOR NOT LIKE '%OFIC%'", ActualizarConexion)
        Dim ds As New DataSet
        Dim dv As New DataView
        Try
            AdaptadorDeDatos.Fill(ds, "Super")
            If ds.Tables("Super").Rows.Count > 0 Then
                dv = New DataView(ds.Tables("Super"))
            End If
        Catch ex As SqlException
            MsgBox("Hay problemas de Conexión: " + ex.Message, MsgBoxStyle.Critical)

        End Try
        ActualizarConexion.Close()
        Return dv
    End Function

    Public Function CargarSupervisoresEmpresa(ByVal Empresa As String) As DataView
        Dim ActualizarConexion As New SqlConnection(ConexionUsuarios.CadenaSQL())
        ActualizarConexion.Open()
        Dim AdaptadorDeDatos As New SqlDataAdapter("SELECT CODIGO_SUPERVISOR as 'Código de Supervisor', SUPERVISOR as 'Nombre', CLASIFIC as 'Clasificación', ALMACEN as 'Almacén' FROM  Supervisores where Empresa = '" & Empresa & "' or Empresa = 'AMBAS'", ActualizarConexion)
        Dim ds As New DataSet
        Dim dv As New DataView
        Try
            AdaptadorDeDatos.Fill(ds, "Super")
            If ds.Tables("Super").Rows.Count > 0 Then
                dv = New DataView(ds.Tables("Super"))
            End If
        Catch ex As SqlException
            MsgBox("Hay problemas de Conexión: Supervisor - " + ex.Message, MsgBoxStyle.Critical)

        End Try
        ActualizarConexion.Close()
        Return dv
    End Function

    Public Function CargaMetas(ByVal Vendedor As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionUsuarios.CadenaSQL())

        Dim miComando As New SqlCommand(" SELECT     '' as LIN, 'VENTA' as PROVEEDOR, 0 as 'META MENSUAL', 'S' AS TIPO, '' AS REAL, '' as '%', '' as 'META DIARIA', '' AS DESAFIO, '' AS 'REAL DIARIO', '' AS Prueba UNION ALL " & _
"   SELECT     CODIGO_PROV as LIN, NOMBRE_PROV as PROVEEDOR, META as 'META MENSUAL', 'L' AS TIPO, '' AS REAL, '' as '%', '' as 'META DIARIA', '' AS DESAFIO, '' AS 'REAL DIARIO', CONVERT(VARCHAR(50), CAST(META AS MONEY), 1) AS Prueba " & _
        " FROM dbo.Matinal_Meta WHERE CVE_VEND = @ID  UNION ALL " & _
        " SELECT CODIGO_PROV AS LIN, PROV AS PROVEEDOR, ROUND(PESO,2) AS 'META MENSUAL', TIPO, '' AS REAL, '' as '%', '' as 'META DIARIA', '' AS DESAFIO, '' AS 'REAL DIARIO', CONVERT(VARCHAR,ROUND(PESO,2)) as Prueba FROM dbo.Matinal_MetaCJ  WHERE (CODIGO_VEND = @ID) ", ActualizarConexion)

        miComando.Parameters.AddWithValue("@ID", Vendedor)

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

    Public Function CargaMetasDIMOSA(ByVal Vendedor As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionUsuarios.CadenaSQL())

        Dim miComando As New SqlCommand(" SELECT     '' as LIN, 'VENTA' as PROVEEDOR, 0 as 'META MENSUAL', 'S' AS TIPO, '' AS REAL, '' as '%', '' as 'META DIARIA', '' AS DESAFIO, '' AS 'REAL DIARIO', '' AS Prueba UNION ALL " & _
"   SELECT     CODIGO_PROV as LIN, NOMBRE_PROV as PROVEEDOR, META as 'META MENSUAL', 'L' AS TIPO, '' AS REAL, '' as '%', '' as 'META DIARIA', '' AS DESAFIO, '' AS 'REAL DIARIO', CONVERT(VARCHAR(50), CAST(META AS MONEY), 1) AS Prueba " & _
        " FROM dbo.Matinal_Meta_DIMOSA WHERE CVE_VEND = @ID  UNION ALL " & _
        " SELECT CODIGO_PROV AS LIN, PROV AS PROVEEDOR, ROUND(PESO,2) AS 'META MENSUAL', TIPO, '' AS REAL, '' as '%', '' as 'META DIARIA', '' AS DESAFIO, '' AS 'REAL DIARIO', CONVERT(VARCHAR,ROUND(PESO,2)) as Prueba FROM dbo.Matinal_MetaCJ_DIMOSA  WHERE (CODIGO_VEND = @ID) ", ActualizarConexion)

        miComando.Parameters.AddWithValue("@ID", Vendedor)

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

    Public Function CargaMetasProductos(ByVal Vendedor As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionUsuarios.CadenaSQL())

        Dim miComando As New SqlCommand(" " & _
        " SELECT CODIGO_PROD as CLAVE, PROD as PRODUCTO, PESO as 'META MENSUAL', TIPO, '' AS REAL, '' as '%', '' as 'META DIARIA', '' AS DESAFIO, '' AS 'REAL DIARIO', CONVERT(VARCHAR(50), CAST(PESO AS MONEY), 1) AS Prueba, FechaDesde as 'CONTAR DESDE'  " & _
        " FROM dbo.Matinal_MetaXProducto WHERE CODIGO_VEND  = @ID and ACTIVO = 'S'", ActualizarConexion)

        miComando.Parameters.AddWithValue("@ID", Vendedor)

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

    Public Function CargaMetasProductosDIMOSA(ByVal Vendedor As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionUsuarios.CadenaSQL())

        Dim miComando As New SqlCommand(" " & _
        " SELECT CODIGO_PROD as CLAVE, PROD as PRODUCTO, PESO as 'META MENSUAL', TIPO, '' AS REAL, '' as '%', '' as 'META DIARIA', '' AS DESAFIO, '' AS 'REAL DIARIO', CONVERT(VARCHAR(50), CAST(PESO AS MONEY), 1) AS Prueba, FechaDesde as 'CONTAR DESDE'  " & _
        " FROM dbo.Matinal_MetaXProducto_DIMOSA WHERE CODIGO_VEND  = @ID and ACTIVO = 'S'", ActualizarConexion)

        miComando.Parameters.AddWithValue("@ID", Vendedor)

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

    Public Function VentasLps(ByVal FECHA_INI As Date, ByVal FECHA_FIN As Date, _
                                          ByVal CVE_VEND As String, ByVal LINEA As Integer) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_ventas_matinal", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.Date)).Value = FECHA_INI
        miComando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.Date)).Value = FECHA_FIN
        miComando.Parameters.Add(New SqlParameter("@VENDEDOR", SqlDbType.VarChar)).Value = CVE_VEND
        miComando.Parameters.Add(New SqlParameter("@LINEA", SqlDbType.Int)).Value = LINEA

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

    Public Function VentasLpsDIMOSA(ByVal FECHA_INI As Date, ByVal FECHA_FIN As Date, _
                                          ByVal CVE_VEND As String, ByVal LINEA As Integer) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_ventas_matinal", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.Date)).Value = FECHA_INI
        miComando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.Date)).Value = FECHA_FIN
        miComando.Parameters.Add(New SqlParameter("@VENDEDOR", SqlDbType.VarChar)).Value = CVE_VEND
        miComando.Parameters.Add(New SqlParameter("@LINEA", SqlDbType.Int)).Value = LINEA

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

    Public Function VentasLpsProducto(ByVal FECHA_INI As Date, ByVal FECHA_FIN As Date, _
                                          ByVal CVE_VEND As String, ByVal Producto As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_ventas_matinal_producto", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.Date)).Value = FECHA_INI
        miComando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.Date)).Value = FECHA_FIN
        miComando.Parameters.Add(New SqlParameter("@VENDEDOR", SqlDbType.VarChar)).Value = CVE_VEND
        miComando.Parameters.Add(New SqlParameter("@LINEA", SqlDbType.VarChar)).Value = Producto

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

    Public Function LineaMatinal(ByVal FECHA_INI As Date, ByVal FECHA_FIN As Date, ByVal CVE_VEND As String, ByVal LINEA As String, ByVal DIAS_TRABAJADOS As Integer, _
                                 ByVal DIAS_TOTALES As Integer, ByVal DIAS_RESTANTES As Integer, ByVal PROVEEDOR As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_ventas_matinal_nuevo", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure

        miComando.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.Date)).Value = FECHA_INI
        miComando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.Date)).Value = FECHA_FIN
        miComando.Parameters.Add(New SqlParameter("@CVE_VEND", SqlDbType.VarChar)).Value = CVE_VEND
        miComando.Parameters.Add(New SqlParameter("@LINEA", SqlDbType.VarChar)).Value = LINEA

        miComando.Parameters.Add(New SqlParameter("@DIAS_TOTALES", SqlDbType.Int)).Value = DIAS_TOTALES
        miComando.Parameters.Add(New SqlParameter("@DIAS_RESTANTES", SqlDbType.Int)).Value = DIAS_RESTANTES
        miComando.Parameters.Add(New SqlParameter("@DIAS_TRABAJADOS", SqlDbType.Int)).Value = DIAS_TRABAJADOS
        miComando.Parameters.Add(New SqlParameter("@PROVEEDOR", SqlDbType.VarChar)).Value = PROVEEDOR

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

    Public Function LineaMatinalDIMOSA(ByVal FECHA_INI As Date, ByVal FECHA_FIN As Date, ByVal CVE_VEND As String, ByVal LINEA As String, ByVal DIAS_TRABAJADOS As Integer, _
                                 ByVal DIAS_TOTALES As Integer, ByVal DIAS_RESTANTES As Integer, ByVal PROVEEDOR As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_ventas_matinal_nuevo", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure

        miComando.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.Date)).Value = FECHA_INI
        miComando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.Date)).Value = FECHA_FIN
        miComando.Parameters.Add(New SqlParameter("@CVE_VEND", SqlDbType.VarChar)).Value = CVE_VEND
        miComando.Parameters.Add(New SqlParameter("@LINEA", SqlDbType.VarChar)).Value = LINEA

        miComando.Parameters.Add(New SqlParameter("@DIAS_TOTALES", SqlDbType.Int)).Value = DIAS_TOTALES
        miComando.Parameters.Add(New SqlParameter("@DIAS_RESTANTES", SqlDbType.Int)).Value = DIAS_RESTANTES
        miComando.Parameters.Add(New SqlParameter("@DIAS_TRABAJADOS", SqlDbType.Int)).Value = DIAS_TRABAJADOS
        miComando.Parameters.Add(New SqlParameter("@PROVEEDOR", SqlDbType.VarChar)).Value = PROVEEDOR

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

    Public Function VentasLpsProductoDIMOSA(ByVal FECHA_INI As Date, ByVal FECHA_FIN As Date, _
                                          ByVal CVE_VEND As String, ByVal Producto As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_ventas_matinal_producto", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.Date)).Value = FECHA_INI
        miComando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.Date)).Value = FECHA_FIN
        miComando.Parameters.Add(New SqlParameter("@VENDEDOR", SqlDbType.VarChar)).Value = CVE_VEND
        miComando.Parameters.Add(New SqlParameter("@LINEA", SqlDbType.VarChar)).Value = Producto

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

    Public Function VentasCajas(ByVal FECHA_INI As Date, ByVal FECHA_FIN As Date, _
                                          ByVal CVE_VEND As String, ByVal LINEA As String, ByVal TIPO As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_ventas_cajas", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.Date)).Value = FECHA_INI
        miComando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.Date)).Value = FECHA_FIN
        miComando.Parameters.Add(New SqlParameter("@CVE_VEND", SqlDbType.VarChar)).Value = CVE_VEND
        miComando.Parameters.Add(New SqlParameter("@LINEA", SqlDbType.VarChar)).Value = LINEA
        miComando.Parameters.Add(New SqlParameter("@TIPO", SqlDbType.VarChar)).Value = TIPO

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

    Public Function VentasCajasDIMOSA(ByVal FECHA_INI As Date, ByVal FECHA_FIN As Date, _
                                          ByVal CVE_VEND As String, ByVal LINEA As String, ByVal TIPO As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_ventas_cajas", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.Date)).Value = FECHA_INI
        miComando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.Date)).Value = FECHA_FIN
        miComando.Parameters.Add(New SqlParameter("@CVE_VEND", SqlDbType.VarChar)).Value = CVE_VEND
        miComando.Parameters.Add(New SqlParameter("@LINEA", SqlDbType.VarChar)).Value = LINEA
        miComando.Parameters.Add(New SqlParameter("@TIPO", SqlDbType.VarChar)).Value = TIPO

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

    Public Function VentasCajasProducto(ByVal FECHA_INI As Date, ByVal FECHA_FIN As Date, _
                                          ByVal CVE_VEND As String, ByVal LINEA As String, ByVal TIPO As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_ventas_cajas_producto", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.Date)).Value = FECHA_INI
        miComando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.Date)).Value = FECHA_FIN
        miComando.Parameters.Add(New SqlParameter("@CVE_VEND", SqlDbType.VarChar)).Value = CVE_VEND
        miComando.Parameters.Add(New SqlParameter("@LINEA", SqlDbType.VarChar)).Value = LINEA
        miComando.Parameters.Add(New SqlParameter("@TIPO", SqlDbType.VarChar)).Value = TIPO

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

    Public Function VentasCajasProductoDIMOSA(ByVal FECHA_INI As Date, ByVal FECHA_FIN As Date, _
                                          ByVal CVE_VEND As String, ByVal LINEA As String, ByVal TIPO As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_ventas_cajas_producto", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.Date)).Value = FECHA_INI
        miComando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.Date)).Value = FECHA_FIN
        miComando.Parameters.Add(New SqlParameter("@CVE_VEND", SqlDbType.VarChar)).Value = CVE_VEND
        miComando.Parameters.Add(New SqlParameter("@LINEA", SqlDbType.VarChar)).Value = LINEA
        miComando.Parameters.Add(New SqlParameter("@TIPO", SqlDbType.VarChar)).Value = TIPO

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

    Public Function SeleccionaSupervisor(ByVal Vend As String, ByVal Empresa As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionUsuarios.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT     dbo.Supervisores.SUPERVISOR " & _
                                    " FROM         dbo.Supervisor_Vendedor INNER JOIN " & _
                                    " dbo.Supervisores ON dbo.Supervisor_Vendedor.SUPERVISOR = dbo.Supervisores.CODIGO_SUPERVISOR " & _
                                    " WHERE     (dbo.Supervisor_Vendedor.CVE_VEND = @Vendedor) and Supervisor_Vendedor.Supervisor_Actual = 'Si' And Empresa_Enlace = @Empresa", ActualizarConexion)

        miComando.Parameters.Add(New SqlParameter("@Vendedor", SqlDbType.VarChar)).Value = Vend
        miComando.Parameters.Add(New SqlParameter("@Empresa", SqlDbType.VarChar)).Value = Empresa

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

    Public Function CargarSupervisoresCombo(ByVal Empresa As String, ByVal Permiso As Integer) As DataTable

        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_ventas_matinal_nuevo", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure

        miComando.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.Date)).Value = Today.Date
        miComando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.Date)).Value = Today.Date
        miComando.Parameters.Add(New SqlParameter("@CVE_VEND", SqlDbType.VarChar)).Value = Permiso
        miComando.Parameters.Add(New SqlParameter("@LINEA", SqlDbType.VarChar)).Value = "SUPERVISORES"

        miComando.Parameters.Add(New SqlParameter("@DIAS_TOTALES", SqlDbType.Int)).Value = 1
        miComando.Parameters.Add(New SqlParameter("@DIAS_RESTANTES", SqlDbType.Int)).Value = 2
        miComando.Parameters.Add(New SqlParameter("@DIAS_TRABAJADOS", SqlDbType.Int)).Value = 3
        miComando.Parameters.Add(New SqlParameter("@PROVEEDOR", SqlDbType.VarChar)).Value = Empresa
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

    Public Function Permiso(ByVal Usuario As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionUsuarios.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT      Cve_Supervisor FROM         [User] WHERE UsuarioNick = @Usuario", ActualizarConexion)

        miComando.Parameters.Add(New SqlParameter("@Usuario", SqlDbType.VarChar)).Value = Usuario


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

    Public Function CargaMetasSupervisor(ByVal Supervisor As Integer) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionUsuarios.CadenaSQL())

        Dim miComando As New SqlCommand(" SELECT     '' as LIN, 'VENTA' as PROVEEDOR, 0 as 'META MENSUAL', 'S' AS TIPO, '' AS REAL, '' as '%', '' as 'META DIARIA', '' AS DESAFIO, '' AS 'REAL DIARIO', '' AS Prueba " & _
        " UNION ALL " & _
        " SELECT     dbo.Matinal_Meta.CODIGO_PROV AS LIN, dbo.Matinal_Meta.NOMBRE_PROV AS PROVEEDOR, ROUND(SUM(dbo.Matinal_Meta.META), 2) AS 'META MENSUAL', " & _
        " 'L' AS TIPO, '' AS REAL, '' AS '%', '' AS 'META DIARIA', '' AS DESAFIO, '' AS 'REAL DIARIO', CONVERT(VARCHAR(50), CAST(SUM(dbo.Matinal_Meta.META) AS MONEY), 1)  " & _
        " AS Prueba  FROM         dbo.Supervisor_Vendedor INNER JOIN " & _
        " dbo.Matinal_Meta ON dbo.Supervisor_Vendedor.CVE_VEND = dbo.Matinal_Meta.CVE_VEND INNER JOIN " & _
        " SAE60Empre05.dbo.VEND05 ON SAE60Empre05.dbo.VEND05.CVE_VEND = dbo.Matinal_Meta.CVE_VEND COLLATE Latin1_General_BIN " & _
        " WHERE     (dbo.Supervisor_Vendedor.SUPERVISOR = @ID) AND (SAE60Empre05.dbo.VEND05.CLASIFIC <> 'MAY') " & _
        " GROUP BY dbo.Matinal_Meta.CODIGO_PROV, dbo.Matinal_Meta.NOMBRE_PROV " & _
        " UNION ALL SELECT     dbo.Matinal_MetaCJ.CODIGO_PROV, dbo.Matinal_MetaCJ.PROV AS PROVEEDOR, ROUND(SUM(dbo.Matinal_MetaCJ.PESO), 2) AS 'META MENSUAL', " & _
        " dbo.Matinal_MetaCJ.TIPO, '' AS REAL, '' AS '%', '' AS 'META DIARIA', '' AS DESAFIO, '' AS 'REAL DIARIO', CONVERT(VARCHAR, " & _
        " ROUND(SUM(dbo.Matinal_MetaCJ.PESO), 2)) AS Prueba FROM         dbo.Supervisor_Vendedor INNER JOIN " & _
        " dbo.Matinal_MetaCJ ON dbo.Supervisor_Vendedor.CVE_VEND = dbo.Matinal_MetaCJ.CODIGO_VEND INNER JOIN " & _
        " SAE60Empre05.dbo.VEND05 ON SAE60Empre05.dbo.VEND05.CVE_VEND = dbo.Matinal_MetaCJ.CODIGO_VEND COLLATE Latin1_General_BIN " & _
        " WHERE     (dbo.Supervisor_Vendedor.SUPERVISOR = @ID) AND (SAE60Empre05.dbo.VEND05.CLASIFIC <> 'MAY') " & _
        " GROUP BY dbo.Matinal_MetaCJ.CODIGO_PROV, dbo.Matinal_MetaCJ.PROV, dbo.Matinal_MetaCJ.TIPO ", ActualizarConexion)

        miComando.Parameters.AddWithValue("@ID", Supervisor)

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

    Public Function CargaMetasSupervisorDIMOSA(ByVal Supervisor As Integer) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionUsuarios.CadenaSQL())

        Dim miComando As New SqlCommand(" SELECT     '' as LIN, 'VENTA' as PROVEEDOR, 0 as 'META MENSUAL', 'S' AS TIPO, '' AS REAL, '' as '%', '' as 'META DIARIA', '' AS DESAFIO, '' AS 'REAL DIARIO', '' AS Prueba " & _
        " UNION ALL " & _
        " SELECT     dbo.Matinal_Meta_DIMOSA.CODIGO_PROV AS LIN, dbo.Matinal_Meta_DIMOSA.NOMBRE_PROV AS PROVEEDOR, ROUND(SUM(dbo.Matinal_Meta_DIMOSA.META), 2) AS 'META MENSUAL', " & _
        " 'L' AS TIPO, '' AS REAL, '' AS '%', '' AS 'META DIARIA', '' AS DESAFIO, '' AS 'REAL DIARIO', CONVERT(VARCHAR(50), CAST(SUM(dbo.Matinal_Meta_DIMOSA.META) AS MONEY), 1)  " & _
        " AS Prueba  FROM         dbo.Supervisor_Vendedor INNER JOIN " & _
        " dbo.Matinal_Meta_DIMOSA ON dbo.Supervisor_Vendedor.CVE_VEND = dbo.Matinal_Meta_DIMOSA.CVE_VEND INNER JOIN " & _
        " SAE60Empre06.dbo.VEND06 ON SAE60Empre06.dbo.VEND06.CVE_VEND = dbo.Matinal_Meta_DIMOSA.CVE_VEND COLLATE Latin1_General_BIN " & _
        " WHERE     (dbo.Supervisor_Vendedor.SUPERVISOR = @ID) AND (SAE60Empre06.dbo.VEND06.CLASIFIC <> 'MAY') " & _
        " GROUP BY dbo.Matinal_Meta_DIMOSA.CODIGO_PROV, dbo.Matinal_Meta_DIMOSA.NOMBRE_PROV " & _
        " UNION ALL SELECT     dbo.Matinal_MetaCJ_DIMOSA.CODIGO_PROV, dbo.Matinal_MetaCJ_DIMOSA.PROV AS PROVEEDOR, ROUND(SUM(dbo.Matinal_MetaCJ_DIMOSA.PESO), 2) AS 'META MENSUAL', " & _
        " dbo.Matinal_MetaCJ_DIMOSA.TIPO, '' AS REAL, '' AS '%', '' AS 'META DIARIA', '' AS DESAFIO, '' AS 'REAL DIARIO', CONVERT(VARCHAR, " & _
        " ROUND(SUM(dbo.Matinal_MetaCJ_DIMOSA.PESO), 2)) AS Prueba FROM         dbo.Supervisor_Vendedor INNER JOIN " & _
        " dbo.Matinal_MetaCJ_DIMOSA ON dbo.Supervisor_Vendedor.CVE_VEND = dbo.Matinal_MetaCJ_DIMOSA.CODIGO_VEND INNER JOIN " & _
        " SAE60Empre06.dbo.VEND06 ON SAE60Empre06.dbo.VEND06.CVE_VEND = dbo.Matinal_MetaCJ_DIMOSA.CODIGO_VEND COLLATE Latin1_General_BIN " & _
        " WHERE     (dbo.Supervisor_Vendedor.SUPERVISOR = @ID) AND (SAE60Empre06.dbo.VEND06.CLASIFIC <> 'MAY') " & _
        " GROUP BY dbo.Matinal_MetaCJ_DIMOSA.CODIGO_PROV, dbo.Matinal_MetaCJ_DIMOSA.PROV, dbo.Matinal_MetaCJ_DIMOSA.TIPO ", ActualizarConexion)

        miComando.Parameters.AddWithValue("@ID", Supervisor)

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

    Public Function CargaMetasSupervisorPrincipal() As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionUsuarios.CadenaSQL())

        Dim miComando As New SqlCommand(" SELECT     '' as LIN, 'VENTA' as PROVEEDOR, 0 as 'META MENSUAL', 'S' AS TIPO, '' AS REAL, '' as '%', '' as 'META DIARIA', '' AS DESAFIO, '' AS 'REAL DIARIO', '' AS Prueba " & _
        " UNION ALL " & _
        " SELECT     dbo.Matinal_Meta.CODIGO_PROV AS LIN, dbo.Matinal_Meta.NOMBRE_PROV AS PROVEEDOR, ROUND(SUM(dbo.Matinal_Meta.META), 2) AS 'META MENSUAL', " & _
        " 'L' AS TIPO, '' AS REAL, '' AS '%', '' AS 'META DIARIA', '' AS DESAFIO, '' AS 'REAL DIARIO', CONVERT(VARCHAR(50), CAST(SUM(dbo.Matinal_Meta.META) AS MONEY),  " & _
        "              1) AS Prueba " & _
        " FROM         dbo.Supervisor_Vendedor INNER JOIN " & _
        "              dbo.Matinal_Meta ON dbo.Supervisor_Vendedor.CVE_VEND = dbo.Matinal_Meta.CVE_VEND " & _
        " GROUP BY dbo.Matinal_Meta.CODIGO_PROV, dbo.Matinal_Meta.NOMBRE_PROV " & _
        " UNION ALL SELECT     dbo.Matinal_MetaCJ.CODIGO_PROV, dbo.Matinal_MetaCJ.PROV AS PROVEEDOR, ROUND(SUM(dbo.Matinal_MetaCJ.PESO), 2) AS 'META MENSUAL', " & _
        " dbo.Matinal_MetaCJ.TIPO, '' AS REAL, '' AS '%', '' AS 'META DIARIA', '' AS DESAFIO, '' AS 'REAL DIARIO', CONVERT(VARCHAR, " & _
        " ROUND(SUM(dbo.Matinal_MetaCJ.PESO), 2)) AS Prueba " & _
        " FROM         dbo.Supervisor_Vendedor INNER JOIN " & _
        " dbo.Matinal_MetaCJ ON dbo.Supervisor_Vendedor.CVE_VEND = dbo.Matinal_MetaCJ.CODIGO_VEND " & _
        " GROUP BY dbo.Matinal_MetaCJ.CODIGO_PROV, dbo.Matinal_MetaCJ.PROV, dbo.Matinal_MetaCJ.TIPO ", ActualizarConexion)

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

    Public Function VendedoresNoMayoreo(ByVal Supervisor As Integer) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionUsuarios.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT     dbo.Supervisor_Vendedor.CVE_VEND " & _
                                        " FROM         dbo.Supervisor_Vendedor INNER JOIN " & _
                      " SAE60Empre05.dbo.VEND05 ON SAE60Empre05.dbo.VEND05.CVE_VEND = dbo.Supervisor_Vendedor.CVE_VEND COLLATE LATIN1_General_BIN " & _
"WHERE     (SAE60Empre05.dbo.VEND05.CLASIFIC <> 'MAY') AND (dbo.Supervisor_Vendedor.SUPERVISOR = @Supervisor) ", ActualizarConexion)

        miComando.Parameters.Add(New SqlParameter("@Supervisor", SqlDbType.Int)).Value = Supervisor


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

    Public Function VendedoresNoMayoreoDIMOSA(ByVal Supervisor As Integer) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionUsuarios.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT     dbo.Supervisor_Vendedor.CVE_VEND " & _
                                        " FROM         dbo.Supervisor_Vendedor INNER JOIN " & _
                      " SAE60Empre06.dbo.VEND06 ON SAE60Empre06.dbo.VEND06.CVE_VEND = dbo.Supervisor_Vendedor.CVE_VEND COLLATE LATIN1_General_BIN " & _
"WHERE     (SAE60Empre06.dbo.VEND06.CLASIFIC <> 'MAY') AND (dbo.Supervisor_Vendedor.SUPERVISOR = @Supervisor) ", ActualizarConexion)

        miComando.Parameters.Add(New SqlParameter("@Supervisor", SqlDbType.Int)).Value = Supervisor


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

    Public Function VendedoresGeneral() As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionUsuarios.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT     dbo.Supervisor_Vendedor.CVE_VEND " & _
            " FROM         dbo.Supervisor_Vendedor INNER JOIN " & _
            " SAE60Empre05.dbo.VEND05 ON SAE60Empre05.dbo.VEND05.CVE_VEND = dbo.Supervisor_Vendedor.CVE_VEND COLLATE LATIN1_General_BIN ", ActualizarConexion)




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

    Public Function VendedoresGeneralDIMOSA() As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionUsuarios.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT     dbo.Supervisor_Vendedor.CVE_VEND " & _
            " FROM         dbo.Supervisor_Vendedor INNER JOIN " & _
            " SAE60Empre06.dbo.VEND06 ON SAE60Empre06.dbo.VEND06.CVE_VEND = dbo.Supervisor_Vendedor.CVE_VEND COLLATE LATIN1_General_BIN ", ActualizarConexion)




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

    Public Function CargaProveedores(ByVal Empresa As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionUsuarios.CadenaSQL())

        Dim miComando As New SqlCommand
        If Empresa = "SAN RAFAEL" Then
            miComando = New SqlCommand("SELECT DISTINCT CODIGO_PROV, NOMBRE_PROV FROM Matinal_Meta ", ActualizarConexion)
        Else
            miComando = New SqlCommand("SELECT DISTINCT CODIGO_PROV, NOMBRE_PROV FROM Matinal_Meta_DIMOSA ", ActualizarConexion)
        End If


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

    Public Function CargaProveedoresCaja(ByVal Empresa As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionUsuarios.CadenaSQL())

        Dim miComando As New SqlCommand
        If Empresa = "SAN RAFAEL" Then
            miComando = New SqlCommand("SELECT DISTINCT CODIGO_PROV, PROV FROM Matinal_MetaCJ ", ActualizarConexion)
        Else
            miComando = New SqlCommand("SELECT DISTINCT CODIGO_PROV, PROV FROM Matinal_MetaCJ_DIMOSA ", ActualizarConexion)
        End If


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

    Public Function CargaProveedoresBono(ByVal Empresa As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionUsuarios.CadenaSQL())

        Dim miComando As New SqlCommand
        If Empresa = "SAN RAFAEL" Then
            miComando = New SqlCommand("SELECT DISTINCT CODIGO_PROVEEDOR, NOMBRE FROM Presupuestos_Vendedor_Proveedor ", ActualizarConexion)
        Else
            miComando = New SqlCommand("SELECT DISTINCT CODIGO_PROVEEDOR, NOMBRE FROM Presupuestos_Vendedor_Proveedor_dimosa ", ActualizarConexion)
        End If


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

    Public Function CargaVendedores(ByVal Empresa As String, ByVal SUCURSAL As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionUsuarios.CadenaSQL())

        Dim miComando As New SqlCommand

        If SUCURSAL = "TODAS" Then
            If Empresa = "SAN RAFAEL" Then
                miComando = New SqlCommand("SELECT DISTINCT " & _
                             " Matinal_Meta.CVE_VEND, UPPER(SAE60Empre05.dbo.VEND05.NOMBRE) AS NOMBRE,  " & _
                             " CASE CORREOE WHEN 'SP@S' THEN '1 SPS' WHEN 'SR@C' THEN '2 SRC' WHEN 'S@BA' THEN '3 SAB' WHEN 'TOC@A' THEN '3 SAB' WHEN 'TG@U' THEN '4 TGU' END AS SUCURSAL " & _
                             " FROM            Matinal_Meta INNER JOIN " & _
                             " SAE60Empre05.dbo.VEND05 ON SAE60Empre05.dbo.VEND05.CVE_VEND = Matinal_Meta.CVE_VEND COLLATE latin1_general_bin " & _
                             " ORDER BY sucursal ", ActualizarConexion)
            Else
                miComando = New SqlCommand("SELECT DISTINCT " & _
                             " Matinal_Meta_DIMOSA.CVE_VEND, UPPER(SAE60Empre06.dbo.VEND06.NOMBRE) AS NOMBRE,  " & _
                             " CASE CORREOE WHEN 'SP@S' THEN '1 SPS' WHEN 'SR@C' THEN '2 SRC' WHEN 'S@BA' THEN '3 SAB' WHEN 'TOC@A' THEN '3 SAB' WHEN 'TG@U' THEN '4 TGU' END AS SUCURSAL " & _
                             " FROM            Matinal_Meta_DIMOSA INNER JOIN " & _
                             " SAE60Empre06.dbo.VEND06 ON SAE60Empre06.dbo.VEND06.CVE_VEND = Matinal_Meta_DIMOSA.CVE_VEND COLLATE latin1_general_bin " & _
                             " ORDER BY sucursal ", ActualizarConexion)
            End If
        Else

            Dim A As String = ""

            If SUCURSAL = "SPS" Then
                A = "'SP@S'"
            ElseIf SUCURSAL = "SRC" Then
                A = "'SR@C'"
            ElseIf SUCURSAL = "SAB" Then
                A = "'S@BA','TOC@A' "
            ElseIf SUCURSAL = "TGU" Then
                A = "'TG@U'"
            End If

            If Empresa = "SAN RAFAEL" Then
                miComando = New SqlCommand("SELECT DISTINCT " & _
                             " Matinal_Meta.CVE_VEND, UPPER(SAE60Empre05.dbo.VEND05.NOMBRE) AS NOMBRE,  " & _
                             " CASE CORREOE WHEN 'SP@S' THEN '1 SPS' WHEN 'SR@C' THEN '2 SRC' WHEN 'S@BA' THEN '3 SAB' WHEN 'TOC@A' THEN '3 SAB' WHEN 'TG@U' THEN '4 TGU' END AS SUCURSAL " & _
                             " FROM            Matinal_Meta INNER JOIN " & _
                             " SAE60Empre05.dbo.VEND05 ON SAE60Empre05.dbo.VEND05.CVE_VEND = Matinal_Meta.CVE_VEND COLLATE latin1_general_bin WHERE CORREOE IN ( " & A & " )" & _
                             " ORDER BY sucursal ", ActualizarConexion)
            Else
                miComando = New SqlCommand("SELECT DISTINCT " & _
                             " Matinal_Meta_DIMOSA.CVE_VEND, UPPER(SAE60Empre06.dbo.VEND06.NOMBRE) AS NOMBRE,  " & _
                             " CASE CORREOE WHEN 'SP@S' THEN '1 SPS' WHEN 'SR@C' THEN '2 SRC' WHEN 'S@BA' THEN '3 SAB' WHEN 'TOC@A' THEN '3 SAB' WHEN 'TG@U' THEN '4 TGU' END AS SUCURSAL " & _
                             " FROM            Matinal_Meta_DIMOSA INNER JOIN " & _
                             " SAE60Empre06.dbo.VEND06 ON SAE60Empre06.dbo.VEND06.CVE_VEND = Matinal_Meta_DIMOSA.CVE_VEND COLLATE latin1_general_bin  WHERE CORREOE IN ( " & A & " ) " & _
                             " ORDER BY sucursal ", ActualizarConexion)
            End If

        End If



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

    Public Function CargaVendedoresBono(ByVal Empresa As String, ByVal SUCURSAL As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionUsuarios.CadenaSQL())

        Dim miComando As New SqlCommand

        If SUCURSAL = "TODAS" Then
            If Empresa = "SAN RAFAEL" Then
                miComando = New SqlCommand("SELECT DISTINCT " & _
                             " Presupuestos_Vendedor_Proveedor.CODIGO_VENDEDOR, UPPER(SAE60Empre05.dbo.VEND05.NOMBRE) AS NOMBRE,  " & _
                             " CASE CORREOE WHEN 'SP@S' THEN '1 SPS' WHEN 'SR@C' THEN '2 SRC' WHEN 'S@BA' THEN '3 SAB' WHEN 'TOC@A' THEN '3 SAB' WHEN 'TG@U' THEN '4 TGU' END AS SUCURSAL " & _
                             " FROM            Presupuestos_Vendedor_Proveedor INNER JOIN " & _
                             " SAE60Empre05.dbo.VEND05 ON SAE60Empre05.dbo.VEND05.CVE_VEND = Presupuestos_Vendedor_Proveedor.CODIGO_VENDEDOR COLLATE latin1_general_bin " & _
                             " ORDER BY sucursal ", ActualizarConexion)
            Else
                miComando = New SqlCommand("SELECT DISTINCT " & _
                             " Presupuestos_Vendedor_Proveedor_dimosa.CODIGO_VENDEDOR, UPPER(SAE60Empre06.dbo.VEND06.NOMBRE) AS NOMBRE,  " & _
                             " CASE CORREOE WHEN 'SP@S' THEN '1 SPS' WHEN 'SR@C' THEN '2 SRC' WHEN 'S@BA' THEN '3 SAB' WHEN 'TOC@A' THEN '3 SAB' WHEN 'TG@U' THEN '4 TGU' END AS SUCURSAL " & _
                             " FROM            Presupuestos_Vendedor_Proveedor_Dimosa INNER JOIN " & _
                             " SAE60Empre06.dbo.VEND06 ON SAE60Empre06.dbo.VEND06.CVE_VEND = Presupuestos_Vendedor_Proveedor_Dimosa.CODIGO_VENDEDOR COLLATE latin1_general_bin " & _
                             " ORDER BY sucursal ", ActualizarConexion)
            End If
        Else

            Dim A As String = ""

            If SUCURSAL = "SPS" Then
                A = "'SP@S'"
            ElseIf SUCURSAL = "SRC" Then
                A = "'SR@C'"
            ElseIf SUCURSAL = "SAB" Then
                A = "'S@BA','TOC@A' "
            ElseIf SUCURSAL = "TGU" Then
                A = "'TG@U'"
            End If

            If Empresa = "SAN RAFAEL" Then
                miComando = New SqlCommand("SELECT DISTINCT " & _
                             " Presupuestos_Vendedor_Proveedor.CODIGO_VENDEDOR, UPPER(SAE60Empre05.dbo.VEND05.NOMBRE) AS NOMBRE,  " & _
                             " CASE CORREOE WHEN 'SP@S' THEN '1 SPS' WHEN 'SR@C' THEN '2 SRC' WHEN 'S@BA' THEN '3 SAB' WHEN 'TOC@A' THEN '3 SAB' WHEN 'TG@U' THEN '4 TGU' END AS SUCURSAL " & _
                             " FROM            Presupuestos_Vendedor_Proveedor INNER JOIN " & _
                             " SAE60Empre05.dbo.VEND05 ON SAE60Empre05.dbo.VEND05.CVE_VEND = Presupuestos_Vendedor_Proveedor.CODIGO_VENDEDOR COLLATE latin1_general_bin WHERE CORREOE IN ( " & A & " )" & _
                             " ORDER BY sucursal ", ActualizarConexion)
            Else
                miComando = New SqlCommand("SELECT DISTINCT " & _
                             " Presupuestos_Vendedor_Proveedor_DIMOSA.CODIGO_VENDEDOR, UPPER(SAE60Empre06.dbo.VEND06.NOMBRE) AS NOMBRE,  " & _
                             " CASE CORREOE WHEN 'SP@S' THEN '1 SPS' WHEN 'SR@C' THEN '2 SRC' WHEN 'S@BA' THEN '3 SAB' WHEN 'TOC@A' THEN '3 SAB' WHEN 'TG@U' THEN '4 TGU' END AS SUCURSAL " & _
                             " FROM            Presupuestos_Vendedor_Proveedor_DIMOSA INNER JOIN " & _
                             " SAE60Empre06.dbo.VEND06 ON SAE60Empre06.dbo.VEND06.CVE_VEND = Presupuestos_Vendedor_Proveedor_DIMOSA.CODIGO_VENDEDOR COLLATE latin1_general_bin  WHERE CORREOE IN ( " & A & " ) " & _
                             " ORDER BY sucursal ", ActualizarConexion)
            End If

        End If



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

    Public Function CargaMetaInd(ByVal Empresa As String, ByVal Vendedor As String, ByVal Proveedor As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionUsuarios.CadenaSQL())

        Dim miComando As New SqlCommand
        If Empresa = "SAN RAFAEL" Then
            miComando = New SqlCommand(" SELECT META FROM Matinal_Meta WHERE CVE_VEND = @Vendedor AND CODIGO_PROV = @Proveedor ", ActualizarConexion)
        Else
            miComando = New SqlCommand(" SELECT META FROM Matinal_Meta_DIMOSA WHERE CVE_VEND = @Vendedor AND CODIGO_PROV = @Proveedor", ActualizarConexion)
        End If

        miComando.Parameters.AddWithValue("@Vendedor", Vendedor)
        miComando.Parameters.AddWithValue("@Proveedor", Proveedor)

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

    Public Function CargaMetaIndCajas(ByVal Empresa As String, ByVal Vendedor As String, ByVal Proveedor As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionUsuarios.CadenaSQL())

        Dim miComando As New SqlCommand
        If Empresa = "SAN RAFAEL" Then
            miComando = New SqlCommand(" SELECT PESO FROM Matinal_MetaCJ WHERE CODIGO_VEND = @Vendedor AND CODIGO_PROV = @Proveedor ", ActualizarConexion)
        Else
            miComando = New SqlCommand(" SELECT PESO FROM Matinal_MetaCJ_DIMOSA WHERE CODIGO_VEND = @Vendedor AND CODIGO_PROV = @Proveedor", ActualizarConexion)
        End If

        miComando.Parameters.AddWithValue("@Vendedor", Vendedor)
        miComando.Parameters.AddWithValue("@Proveedor", Proveedor)

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

    Public Function CargaMetaIndBono(ByVal Empresa As String, ByVal Vendedor As String, ByVal Proveedor As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionUsuarios.CadenaSQL())

        Dim miComando As New SqlCommand
        If Empresa = "SAN RAFAEL" Then
            miComando = New SqlCommand(" SELECT PRESUPUESTO FROM Presupuestos_Vendedor_Proveedor WHERE CODIGO_VENDEDOR = @Vendedor AND CODIGO_PROVEEDOR = @Proveedor ", ActualizarConexion)
        Else
            miComando = New SqlCommand(" SELECT PRESUPUESTO FROM Presupuestos_Vendedor_Proveedor_Dimosa WHERE CODIGO_VENDEDOR = @Vendedor AND CODIGO_PROVEEDOR = @Proveedor", ActualizarConexion)
        End If

        miComando.Parameters.AddWithValue("@Vendedor", Vendedor)
        miComando.Parameters.AddWithValue("@Proveedor", Proveedor)

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

    Public Function GuardaPresupuestosGenerales(ByVal Empresa As String, ByVal dtPresupuestos As DataTable, ByVal Usuario As String)

        Dim ActualizarConexion As New SqlConnection(ConexionUsuarios.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand
            'Guarda nueva marca
            If Empresa = "SAN RAFAEL" Then
                For a As Integer = 0 To dtPresupuestos.Rows.Count - 1

                    miComando = New SqlCommand(" UPDATE  Presupuestos_Matinal SET VendedorPresupuesto = @Meta WHERE VendedorID = @VENDEDOR ", ActualizarConexion)

                    miComando.Parameters.AddWithValue("@Meta", dtPresupuestos(a)(3))
                    miComando.Parameters.AddWithValue("@VENDEDOR", dtPresupuestos(a)(0))


                    miComando.Transaction = transaccion_sql
                    miComando.ExecuteNonQuery()
                Next

            Else
                For a As Integer = 0 To dtPresupuestos.Rows.Count - 1

                    miComando = New SqlCommand(" UPDATE  Presupuestos_Matinal_DIMOSA SET VendedorPresupuesto = @Meta WHERE VendedorID = @VENDEDOR ", ActualizarConexion)

                    miComando.Parameters.AddWithValue("@Meta", dtPresupuestos(a)(3))
                    miComando.Parameters.AddWithValue("@VENDEDOR", dtPresupuestos(a)(0))

                    miComando.Transaction = transaccion_sql
                    miComando.ExecuteNonQuery()
                Next
            End If
            transaccion_sql.Commit()


            Dim conexion_bita As New cls_bitacora_reporteador
            conexion_bita.RegistraBitacora(Now, Usuario, "Actualizó Presupuestos", "REPORTES", _
                                      "Cambio de Presupuestos Generales " & Empresa)

            ActualizarConexion.Close()
            Return "s"

        Catch ex As Exception
            transaccion_sql.Rollback()
            ActualizarConexion.Close()
            Dim tamaño As Integer = Convert.ToString(ex.StackTrace).Length
            Dim posicion As Integer = InStrRev(Convert.ToString(ex.StackTrace), "línea") - 1
            Dim inicial As Integer = tamaño - posicion
            Dim linea_error As String = Convert.ToString(ex.StackTrace).Substring(tamaño - inicial, inicial)
            Return "Error: " & ex.Message & " " & linea_error
        End Try

    End Function

    Public Function GuardaPresupuestosGeneralesBono(ByVal Empresa As String, ByVal dtPresupuestos As DataTable, ByVal Usuario As String)

        Dim ActualizarConexion As New SqlConnection(ConexionUsuarios.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand
            'Guarda nueva marca
            If Empresa = "SAN RAFAEL" Then
                For a As Integer = 0 To dtPresupuestos.Rows.Count - 1

                    miComando = New SqlCommand(" UPDATE  Presupuestos SET VendedorPresupuesto = @Meta WHERE VendedorID = @VENDEDOR ", ActualizarConexion)

                    miComando.Parameters.AddWithValue("@Meta", dtPresupuestos(a)(3))
                    miComando.Parameters.AddWithValue("@VENDEDOR", dtPresupuestos(a)(0))


                    miComando.Transaction = transaccion_sql
                    miComando.ExecuteNonQuery()
                Next

            Else
                For a As Integer = 0 To dtPresupuestos.Rows.Count - 1

                    miComando = New SqlCommand(" UPDATE  Presupuestos_Dimosa SET VendedorPresupuesto = @Meta WHERE VendedorID = @VENDEDOR ", ActualizarConexion)

                    miComando.Parameters.AddWithValue("@Meta", dtPresupuestos(a)(3))
                    miComando.Parameters.AddWithValue("@VENDEDOR", dtPresupuestos(a)(0))

                    miComando.Transaction = transaccion_sql
                    miComando.ExecuteNonQuery()
                Next
            End If
            transaccion_sql.Commit()


            Dim conexion_bita As New cls_bitacora_reporteador
            conexion_bita.RegistraBitacora(Now, Usuario, "Actualizó Presupuestos Bono", "REPORTES", _
                                      "Cambio de Presupuestos Generales " & Empresa)

            ActualizarConexion.Close()
            Return "s"

        Catch ex As Exception
            transaccion_sql.Rollback()
            ActualizarConexion.Close()
            Dim tamaño As Integer = Convert.ToString(ex.StackTrace).Length
            Dim posicion As Integer = InStrRev(Convert.ToString(ex.StackTrace), "línea") - 1
            Dim inicial As Integer = tamaño - posicion
            Dim linea_error As String = Convert.ToString(ex.StackTrace).Substring(tamaño - inicial, inicial)
            Return "Error: " & ex.Message & " " & linea_error
        End Try

    End Function

    Public Function GuardaPresupuestosProveedores(ByVal Empresa As String, ByVal dtPresupuestos As DataTable, ByVal Usuario As String)

        Dim ActualizarConexion As New SqlConnection(ConexionUsuarios.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand
            'Guarda nueva marca
            If Empresa = "SAN RAFAEL" Then
                For a As Integer = 0 To dtPresupuestos.Rows.Count - 1
                    For b As Integer = 3 To dtPresupuestos.Columns.Count - 1
                        miComando = New SqlCommand(" UPDATE Matinal_Meta SET META = @Meta WHERE CVE_VEND = @VENDEDOR AND CODIGO_PROV = @CODIGO_PROV", ActualizarConexion)

                        miComando.Parameters.AddWithValue("@Meta", dtPresupuestos(a)(b))
                        miComando.Parameters.AddWithValue("@VENDEDOR", dtPresupuestos(a)(0))
                        miComando.Parameters.AddWithValue("@CODIGO_PROV", dtPresupuestos.Columns(b).ColumnName)

                        miComando.Transaction = transaccion_sql
                        miComando.ExecuteNonQuery()
                    Next
                Next
            Else
                For a As Integer = 0 To dtPresupuestos.Rows.Count - 1
                    For b As Integer = 3 To dtPresupuestos.Columns.Count - 1
                        miComando = New SqlCommand(" UPDATE Matinal_Meta_DIMOSA SET META = @Meta WHERE CVE_VEND = @VENDEDOR AND CODIGO_PROV = @CODIGO_PROV", ActualizarConexion)

                        miComando.Parameters.AddWithValue("@Meta", dtPresupuestos(a)(b))
                        miComando.Parameters.AddWithValue("@VENDEDOR", dtPresupuestos(a)(0))
                        miComando.Parameters.AddWithValue("@CODIGO_PROV", dtPresupuestos.Columns(b).ColumnName)

                        miComando.Transaction = transaccion_sql
                        miComando.ExecuteNonQuery()
                    Next
                Next
            End If
            transaccion_sql.Commit()
            ActualizarConexion.Close()

            Dim conexion_bita As New cls_bitacora_reporteador
            conexion_bita.RegistraBitacora(Now, Usuario, "Actualizó Presupuestos", "REPORTES", _
                                      "Cambio de Presupuestos Por Proveedor " & Empresa)


            Return "s"

        Catch ex As Exception
            transaccion_sql.Rollback()
            ActualizarConexion.Close()
            Dim tamaño As Integer = Convert.ToString(ex.StackTrace).Length
            Dim posicion As Integer = InStrRev(Convert.ToString(ex.StackTrace), "línea") - 1
            Dim inicial As Integer = tamaño - posicion
            Dim linea_error As String = Convert.ToString(ex.StackTrace).Substring(tamaño - inicial, inicial)
            Return "Error: " & ex.Message & " " & linea_error
        End Try

    End Function

    Public Function GuardaPresupuestosCajas(ByVal Empresa As String, ByVal dtPresupuestos As DataTable, ByVal Usuario As String)

        Dim ActualizarConexion As New SqlConnection(ConexionUsuarios.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand
            'Guarda nueva marca
            If Empresa = "SAN RAFAEL" Then
                For a As Integer = 0 To dtPresupuestos.Rows.Count - 1
                    For b As Integer = 3 To dtPresupuestos.Columns.Count - 1
                        miComando = New SqlCommand(" UPDATE Matinal_MetaCJ SET PESO = @Meta WHERE CODIGO_VEND = @VENDEDOR AND CODIGO_PROV = @CODIGO_PROV", ActualizarConexion)

                        miComando.Parameters.AddWithValue("@Meta", dtPresupuestos(a)(b))
                        miComando.Parameters.AddWithValue("@VENDEDOR", dtPresupuestos(a)(0))
                        miComando.Parameters.AddWithValue("@CODIGO_PROV", dtPresupuestos.Columns(b).ColumnName)

                        miComando.Transaction = transaccion_sql
                        miComando.ExecuteNonQuery()
                    Next
                Next
            ElseIf Empresa = "DIMOSA" Then
                For a As Integer = 0 To dtPresupuestos.Rows.Count - 1
                    For b As Integer = 3 To dtPresupuestos.Columns.Count - 1
                        miComando = New SqlCommand(" UPDATE Matinal_MetaCJ_DIMOSA SET PEOS = @Meta WHERE CODIGO_VEND = @VENDEDOR AND CODIGO_PROV = @CODIGO_PROV", ActualizarConexion)

                        miComando.Parameters.AddWithValue("@Meta", dtPresupuestos(a)(b))
                        miComando.Parameters.AddWithValue("@VENDEDOR", dtPresupuestos(a)(0))
                        miComando.Parameters.AddWithValue("@CODIGO_PROV", dtPresupuestos.Columns(b).ColumnName)

                        miComando.Transaction = transaccion_sql
                        miComando.ExecuteNonQuery()
                    Next
                Next
            End If
            transaccion_sql.Commit()
            ActualizarConexion.Close()

            Dim conexion_bita As New cls_bitacora_reporteador
            conexion_bita.RegistraBitacora(Now, Usuario, "Actualizó Presupuestos", "REPORTES", _
                                      "Cambio de Presupuestos Por Proveedor " & Empresa)


            Return "s"

        Catch ex As Exception
            transaccion_sql.Rollback()
            ActualizarConexion.Close()
            Dim tamaño As Integer = Convert.ToString(ex.StackTrace).Length
            Dim posicion As Integer = InStrRev(Convert.ToString(ex.StackTrace), "línea") - 1
            Dim inicial As Integer = tamaño - posicion
            Dim linea_error As String = Convert.ToString(ex.StackTrace).Substring(tamaño - inicial, inicial)
            Return "Error: " & ex.Message & " " & linea_error
        End Try

    End Function

    Public Function GuardaPresupuestosProveedoresBono(ByVal Empresa As String, ByVal dtPresupuestos As DataTable, ByVal Usuario As String)

        Dim ActualizarConexion As New SqlConnection(ConexionUsuarios.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand
            'Guarda nueva marca
            If Empresa = "SAN RAFAEL" Then
                For a As Integer = 0 To dtPresupuestos.Rows.Count - 1
                    For b As Integer = 3 To dtPresupuestos.Columns.Count - 1
                        miComando = New SqlCommand(" UPDATE Presupuestos_Vendedor_Proveedor SET PRESUPUESTO = @Meta WHERE Codigo_Vendedor = @VENDEDOR AND CODIGO_PROVEEDOR = @CODIGO_PROV", ActualizarConexion)

                        miComando.Parameters.AddWithValue("@Meta", dtPresupuestos(a)(b))
                        miComando.Parameters.AddWithValue("@VENDEDOR", dtPresupuestos(a)(0))
                        miComando.Parameters.AddWithValue("@CODIGO_PROV", dtPresupuestos.Columns(b).ColumnName)

                        miComando.Transaction = transaccion_sql
                        miComando.ExecuteNonQuery()
                    Next
                Next
            ElseIf Empresa = "DIMOSA" Then
                For a As Integer = 0 To dtPresupuestos.Rows.Count - 1
                    For b As Integer = 3 To dtPresupuestos.Columns.Count - 1
                        miComando = New SqlCommand(" UPDATE Presupuestos_Vendedor_Proveedor_Dimosa SET PRESUPUESTO = @Meta WHERE CODIGO_VENDEDOR = @VENDEDOR AND CODIGO_PROVEEDOR = @CODIGO_PROV", ActualizarConexion)

                        miComando.Parameters.AddWithValue("@Meta", dtPresupuestos(a)(b))
                        miComando.Parameters.AddWithValue("@VENDEDOR", dtPresupuestos(a)(0))
                        miComando.Parameters.AddWithValue("@CODIGO_PROV", dtPresupuestos.Columns(b).ColumnName)

                        miComando.Transaction = transaccion_sql
                        miComando.ExecuteNonQuery()
                    Next
                Next
            End If
            transaccion_sql.Commit()
            ActualizarConexion.Close()

            Dim conexion_bita As New cls_bitacora_reporteador
            conexion_bita.RegistraBitacora(Now, Usuario, "Actualizó Presupuestos", "REPORTES", _
                                      "Cambio de Presupuestos Por Proveedor " & Empresa)


            Return "s"

        Catch ex As Exception
            transaccion_sql.Rollback()
            ActualizarConexion.Close()
            Dim tamaño As Integer = Convert.ToString(ex.StackTrace).Length
            Dim posicion As Integer = InStrRev(Convert.ToString(ex.StackTrace), "línea") - 1
            Dim inicial As Integer = tamaño - posicion
            Dim linea_error As String = Convert.ToString(ex.StackTrace).Substring(tamaño - inicial, inicial)
            Return "Error: " & ex.Message & " " & linea_error
        End Try

    End Function

    Public Function CargaVendedoresGeneral(ByVal Empresa As String, ByVal SUCURSAL As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionUsuarios.CadenaSQL())

        Dim miComando As New SqlCommand

        If SUCURSAL = "TODAS" Then
            If Empresa = "SAN RAFAEL" Then
                miComando = New SqlCommand("SELECT DISTINCT " & _
                             " Presupuestos_Matinal.VendedorId as ID, UPPER(SAE60Empre05.dbo.VEND05.NOMBRE) AS NOMBRE,  " & _
                             " CASE CORREOE WHEN 'SP@S' THEN '1 SPS' WHEN 'SR@C' THEN '2 SRC' WHEN 'S@BA' THEN '3 SAB' WHEN 'TOC@A' THEN '3 SAB' WHEN 'TG@U' THEN '4 TGU' END AS SUCURSAL, VendedorPresupuesto as PRESUPUESTO " & _
                             " FROM            Presupuestos_Matinal INNER JOIN " & _
                             " SAE60Empre05.dbo.VEND05 ON SAE60Empre05.dbo.VEND05.CVE_VEND = Presupuestos_Matinal.VendedorID COLLATE latin1_general_bin " & _
                             " ORDER BY sucursal ", ActualizarConexion)
            ElseIf Empresa = "DIMOSA" Then
                miComando = New SqlCommand("SELECT DISTINCT " & _
                             " Presupuestos_Matinal_Dimosa.VendedorID as ID, UPPER(SAE60Empre06.dbo.VEND06.NOMBRE) AS NOMBRE,  " & _
                             " CASE CORREOE WHEN 'SP@S' THEN '1 SPS' WHEN 'SR@C' THEN '2 SRC' WHEN 'S@BA' THEN '3 SAB' WHEN 'TOC@A' THEN '3 SAB' WHEN 'TG@U' THEN '4 TGU' END AS SUCURSAL, VendedorPresupuesto as PRESUPUESTO " & _
                             " FROM            Presupuestos_Matinal_Dimosa INNER JOIN " & _
                             " SAE60Empre06.dbo.VEND06 ON SAE60Empre06.dbo.VEND06.CVE_VEND = Presupuestos_Matinal_Dimosa.VendedorID COLLATE latin1_general_bin " & _
                             " ORDER BY sucursal ", ActualizarConexion)
            End If
        Else

            Dim A As String = ""

            If SUCURSAL = "SPS" Then
                A = "'SP@S'"
            ElseIf SUCURSAL = "SRC" Then
                A = "'SR@C'"
            ElseIf SUCURSAL = "SAB" Then
                A = "'S@BA','TOC@A' "
            ElseIf SUCURSAL = "TGU" Then
                A = "'TG@U'"
            End If

            If Empresa = "SAN RAFAEL" Then
                miComando = New SqlCommand("SELECT DISTINCT " & _
                             " Presupuestos_Matinal.VendedorID as ID, UPPER(SAE60Empre05.dbo.VEND05.NOMBRE) AS NOMBRE,  " & _
                             " CASE CORREOE WHEN 'SP@S' THEN '1 SPS' WHEN 'SR@C' THEN '2 SRC' WHEN 'S@BA' THEN '3 SAB' WHEN 'TOC@A' THEN '3 SAB' WHEN 'TG@U' THEN '4 TGU' END AS SUCURSAL, VendedorPresupuesto as PRESUPUESTO " & _
                             " FROM            Presupuestos_Matinal INNER JOIN " & _
                             " SAE60Empre05.dbo.VEND05 ON SAE60Empre05.dbo.VEND05.CVE_VEND = Presupuestos_Matinal.VendedorID COLLATE latin1_general_bin WHERE CORREOE IN ( " & A & " )" & _
                             " ORDER BY sucursal ", ActualizarConexion)
            Else
                miComando = New SqlCommand("SELECT DISTINCT " & _
                             " Presupuestos_Matinal_Dimosa.VendedorID as ID, UPPER(SAE60Empre06.dbo.VEND06.NOMBRE) AS NOMBRE,  " & _
                             " CASE CORREOE WHEN 'SP@S' THEN '1 SPS' WHEN 'SR@C' THEN '2 SRC' WHEN 'S@BA' THEN '3 SAB' WHEN 'TOC@A' THEN '3 SAB' WHEN 'TG@U' THEN '4 TGU' END AS SUCURSAL, VendedorPresupuesto as PRESUPUESTO " & _
                             " FROM            Presupuestos_Matinal_Dimosa INNER JOIN " & _
                             " SAE60Empre06.dbo.VEND06 ON SAE60Empre06.dbo.VEND06.CVE_VEND = Presupuestos_Matinal_Dimosa.VendedorID COLLATE latin1_general_bin  WHERE CORREOE IN ( " & A & " ) " & _
                             " ORDER BY sucursal ", ActualizarConexion)
            End If

        End If



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

    Public Function CargaVendedoresGeneralBono(ByVal Empresa As String, ByVal SUCURSAL As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionUsuarios.CadenaSQL())

        Dim miComando As New SqlCommand

        If SUCURSAL = "TODAS" Then
            If Empresa = "SAN RAFAEL" Then
                miComando = New SqlCommand("SELECT DISTINCT " & _
                             " Presupuestos.VendedorId as ID, UPPER(SAE60Empre05.dbo.VEND05.NOMBRE) AS NOMBRE,  " & _
                             " CASE CORREOE WHEN 'SP@S' THEN '1 SPS' WHEN 'SR@C' THEN '2 SRC' WHEN 'S@BA' THEN '3 SAB' WHEN 'TOC@A' THEN '3 SAB' WHEN 'TG@U' THEN '4 TGU' END AS SUCURSAL, VendedorPresupuesto as PRESUPUESTO " & _
                             " FROM            Presupuestos INNER JOIN " & _
                             " SAE60Empre05.dbo.VEND05 ON SAE60Empre05.dbo.VEND05.CVE_VEND = Presupuestos.VendedorID COLLATE latin1_general_bin " & _
                             " ORDER BY sucursal ", ActualizarConexion)
            Else
                miComando = New SqlCommand("SELECT DISTINCT " & _
                             " Presupuestos_Dimosa.VendedorID as ID, UPPER(SAE60Empre06.dbo.VEND06.NOMBRE) AS NOMBRE,  " & _
                             " CASE CORREOE WHEN 'SP@S' THEN '1 SPS' WHEN 'SR@C' THEN '2 SRC' WHEN 'S@BA' THEN '3 SAB' WHEN 'TOC@A' THEN '3 SAB' WHEN 'TG@U' THEN '4 TGU' END AS SUCURSAL, VendedorPresupuesto as PRESUPUESTO " & _
                             " FROM            Presupuestos_Dimosa INNER JOIN " & _
                             " SAE60Empre06.dbo.VEND06 ON SAE60Empre06.dbo.VEND06.CVE_VEND = Presupuestos_Dimosa.VendedorID COLLATE latin1_general_bin " & _
                             " ORDER BY sucursal ", ActualizarConexion)
            End If
        Else

            Dim A As String = ""

            If SUCURSAL = "SPS" Then
                A = "'SP@S'"
            ElseIf SUCURSAL = "SRC" Then
                A = "'SR@C'"
            ElseIf SUCURSAL = "SAB" Then
                A = "'S@BA','TOC@A' "
            ElseIf SUCURSAL = "TGU" Then
                A = "'TG@U'"
            End If

            If Empresa = "SAN RAFAEL" Then
                miComando = New SqlCommand("SELECT DISTINCT " & _
                             " Presupuestos.VendedorID as ID, UPPER(SAE60Empre05.dbo.VEND05.NOMBRE) AS NOMBRE,  " & _
                             " CASE CORREOE WHEN 'SP@S' THEN '1 SPS' WHEN 'SR@C' THEN '2 SRC' WHEN 'S@BA' THEN '3 SAB' WHEN 'TOC@A' THEN '3 SAB' WHEN 'TG@U' THEN '4 TGU' END AS SUCURSAL, VendedorPresupuesto as PRESUPUESTO " & _
                             " FROM            Presupuestos INNER JOIN " & _
                             " SAE60Empre05.dbo.VEND05 ON SAE60Empre05.dbo.VEND05.CVE_VEND = Presupuestos.VendedorID COLLATE latin1_general_bin WHERE CORREOE IN ( " & A & " )" & _
                             " ORDER BY sucursal ", ActualizarConexion)
            Else
                miComando = New SqlCommand("SELECT DISTINCT " & _
                             " Presupuestos_Matinal_Dimosa.VendedorID as ID, UPPER(SAE60Empre06.dbo.VEND06.NOMBRE) AS NOMBRE,  " & _
                             " CASE CORREOE WHEN 'SP@S' THEN '1 SPS' WHEN 'SR@C' THEN '2 SRC' WHEN 'S@BA' THEN '3 SAB' WHEN 'TOC@A' THEN '3 SAB' WHEN 'TG@U' THEN '4 TGU' END AS SUCURSAL, VendedorPresupuesto as PRESUPUESTO " & _
                             " FROM            Presupuestos_Dimosa INNER JOIN " & _
                             " SAE60Empre06.dbo.VEND06 ON SAE60Empre06.dbo.VEND06.CVE_VEND = Presupuestos_Dimosa.VendedorID COLLATE latin1_general_bin  WHERE CORREOE IN ( " & A & " ) " & _
                             " ORDER BY sucursal ", ActualizarConexion)
            End If

        End If



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

    Public Function CargaPresupuestosMatinalBono(ByVal Empresa As String, ByVal Usuario As String)

        Dim ActualizarConexion As New SqlConnection(ConexionUsuarios.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand
            'Guarda nueva marca
            If Empresa = "SAN RAFAEL" Then
                miComando = New SqlCommand(" UPDATE Presupuestos_vendedor_proveedor  " & _
                                           " SET Presupuestos_Vendedor_Proveedor.PRESUPUESTO = Matinal_Meta.Meta " & _
                                           " FROM Matinal_Meta " & _
                                           " WHERE Matinal_Meta.CVE_VEND = Presupuestos_Vendedor_Proveedor.CODIGO_VENDEDOR AND MATINAL_META.CODIGO_PROV = Presupuestos_Vendedor_Proveedor.CODIGO_PROVEEDOR", ActualizarConexion)
                miComando.Transaction = transaccion_sql
                miComando.ExecuteNonQuery()

                miComando = New SqlCommand(" UPDATE Presupuestos   " & _
                                           " SET Presupuestos.VendedorPresupuesto  = presupuestos_matinal.VendedorPresupuesto  " & _
                                           " FROM presupuestos_matinal " & _
                                           " WHERE presupuestos_matinal.VendedorID = Presupuestos.VendedorId", ActualizarConexion)
                miComando.Transaction = transaccion_sql
                miComando.ExecuteNonQuery()

                miComando = New SqlCommand(" UPDATE Presupuestos_vendedor_proveedor   " & _
                                           " SET Presupuestos_Vendedor_Proveedor.PRESUPUESTO = Matinal_MetaCJ.PESO " & _
                                           " FROM Matinal_MetaCJ WHERE Matinal_MetaCJ.CODIGO_VEND  = Presupuestos_Vendedor_Proveedor.CODIGO_VENDEDOR AND  " & _
                                           " MATINAL_METACJ.CODIGO_PROV = Presupuestos_Vendedor_Proveedor.CODIGO_PROVEEDOR", ActualizarConexion)
                miComando.Transaction = transaccion_sql
                miComando.ExecuteNonQuery()

            Else
                'miComando = New SqlCommand(" UPDATE Presupuestos_Vendedor_Proveedor_Dimosa SET PRESUPUESTO = @Meta WHERE CODIGO_VENDEDOR = @VENDEDOR AND CODIGO_PROVEEDOR = @CODIGO_PROV", ActualizarConexion)

                'miComando.Transaction = transaccion_sql
                'miComando.ExecuteNonQuery()
                
            End If
            transaccion_sql.Commit()
            ActualizarConexion.Close()

            Dim conexion_bita As New cls_bitacora_reporteador
            conexion_bita.RegistraBitacora(Now, Usuario, "Cargo Presupuesto de Matinal a Bono " & Empresa, "REPORTES", _
                                      "Cambio de Presupuestos Por Proveedor " & Empresa)


            Return "s"

        Catch ex As Exception
            transaccion_sql.Rollback()
            ActualizarConexion.Close()
            Dim tamaño As Integer = Convert.ToString(ex.StackTrace).Length
            Dim posicion As Integer = InStrRev(Convert.ToString(ex.StackTrace), "línea") - 1
            Dim inicial As Integer = tamaño - posicion
            Dim linea_error As String = Convert.ToString(ex.StackTrace).Substring(tamaño - inicial, inicial)
            Return "Error: " & ex.Message & " " & linea_error
        End Try

    End Function

    Public Function CargarIdealClientes(ByVal Mes As Integer, ByVal Año As Integer) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionUsuarios.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT        IDEAL_CLIENTES.VENDEDOR_ID, V.NOMBRE, CASE CORREOE WHEN 'SP@S' THEN '1 SPS' WHEN 'SR@C' THEN '2 SRC' WHEN 'S@BA' THEN '3 SAB' WHEN 'TOC@A' THEN '3 SAB' WHEN 'TG@U' THEN '4 TGU' END AS SUCURSAL, IDEAL_CLIENTES.IDEAL " & _
                                        " FROM            IDEAL_CLIENTES INNER JOIN " & _
                                        " SAE60Empre05.dbo.VEND05 AS V ON V.CVE_VEND = IDEAL_CLIENTES.VENDEDOR_ID COLLATE LATIN1_GENERAL_BIN " & _
                                        " WHERE        (IDEAL_CLIENTES.MES = @MES) AND (IDEAL_CLIENTES.AÑO = @AÑO) ", ActualizarConexion)

        miComando.Parameters.AddWithValue("@MES", Mes)
        miComando.Parameters.AddWithValue("@AÑO", Año)


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

    Public Function GuardarIdealClientes(ByVal dt As DataTable, ByVal Mes As Integer, ByVal Año As Integer, ByVal Usuario As String)

        Dim ActualizarConexion As New SqlConnection(ConexionUsuarios.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand
            'Guarda nueva marca

            For a As Integer = 0 To dt.Rows.Count - 1
                miComando = New SqlCommand(" UPDATE IDEAL_CLIENTES SET  IDEAL = @IDEAL " & _
                                           " WHERE  MES = @MES AND  AÑO = @AÑO AND VENDEDOR_ID = @VENDEDOR ", ActualizarConexion)

                miComando.Parameters.AddWithValue("@MES", Mes)
                miComando.Parameters.AddWithValue("@AÑO", Año)
                miComando.Parameters.AddWithValue("@VENDEDOR", dt(a)(0))
                miComando.Parameters.AddWithValue("@IDEAL", dt(a)(2))
                miComando.Transaction = transaccion_sql
                miComando.ExecuteNonQuery()
            Next

            transaccion_sql.Commit()
            ActualizarConexion.Close()

            Dim conexion_bita As New cls_bitacora_reporteador
            conexion_bita.RegistraBitacora(Now, Usuario, "Actualizó ideal de clientes", "REPORTES", _
                                      "Cambio de Presupuestos Por Proveedor ")


            Return "s"

        Catch ex As Exception
            transaccion_sql.Rollback()
            ActualizarConexion.Close()
            Dim tamaño As Integer = Convert.ToString(ex.StackTrace).Length
            Dim posicion As Integer = InStrRev(Convert.ToString(ex.StackTrace), "línea") - 1
            Dim inicial As Integer = tamaño - posicion
            Dim linea_error As String = Convert.ToString(ex.StackTrace).Substring(tamaño - inicial, inicial)
            Return "Error: " & ex.Message & " " & linea_error
        End Try

    End Function
End Class
