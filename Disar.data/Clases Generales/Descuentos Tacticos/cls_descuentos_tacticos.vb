Imports System.Text
Imports System.Data.SqlClient

Public Class cls_descuentos_tacticos
    Dim conexion As New cls_conexion_descuentos_tacticos
    Dim conexion_dimosa As New cls_conexion_descuentos_tacticos_dimosa
    Dim conexion_sr_agro As New cls_conexion_descuentos_tacticos_sragro
    Dim conexion_consumo As New clsconexion_consumo
    Dim conexion_consumo_dimosa As New cls_conexion_DIMOSA
    Dim conexion_coi_san_rafael As New clsconexion_coi_consumo
    Dim conexion_coi_dimosa As New clsconexion_coi_dimosa
    Dim conexion_coi_opl As New clsConexion_coi_opl
    Dim conexion_coi_sr_agro As New clsconexion_coi_sr_agro
    Dim conexion_FLOTA As New ClsConexion_Flota
    Dim conexion_usuarios As New clsConexion
    Dim conexion_OPL As New cls_conexionOPL
    Dim conexion_Descuentos_Opl As New cls_descuentos_tacticos_opl
    Public Function listar_proveedor()
        Dim query As New StringBuilder()
        Dim ActualizarConexion As New SqlConnection(conexion_consumo.CadenaSQL())
        query.Append("SELECT CLAVE, NOMBRE ")
        query.Append("FROM PROV05 ")
        query.Append("WHERE STATUS = 'A'")

        Dim micomando As New SqlCommand(query.ToString, ActualizarConexion)
        ActualizarConexion.Open()
        Dim AdaptadordeDatos As New SqlDataAdapter(micomando)
        Dim dt As New DataTable

        AdaptadordeDatos.Fill(dt)
        ActualizarConexion.Close()
        Return dt
    End Function

    Public Function resumen_nc_dv(ByVal INI As Date, ByVal FIN As Date, ByVal ALMACEN As Integer, ByVal EMPRESA As String, ByVal Entregador As Integer)
        Dim actualizarconexion As New SqlConnection(conexion_consumo.CadenaSQL)
        Dim micomando As New SqlCommand("rptn_resumen_nc_dv", actualizarconexion)
        micomando.CommandType = CommandType.StoredProcedure
        micomando.Parameters.AddWithValue("@INI", INI)
        micomando.Parameters.AddWithValue("@FIN", FIN)
        micomando.Parameters.AddWithValue("@ALMACEN", ALMACEN)
        micomando.Parameters.AddWithValue("@EMPRESA", EMPRESA)
        micomando.Parameters.AddWithValue("@Entregador", Entregador)
        actualizarconexion.Open()
        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        actualizarconexion.Close()
        Return dt
    End Function

    Public Function listar_proveedor_dimosa()
        Dim query As New StringBuilder()
        Dim ActualizarConexion As New SqlConnection(conexion_consumo_dimosa.CadenaSQL())
        query.Append("SELECT CLAVE, NOMBRE ")
        query.Append("FROM PROV06 ")
        query.Append("WHERE STATUS = 'A'")

        Dim micomando As New SqlCommand(query.ToString, ActualizarConexion)
        ActualizarConexion.Open()
        Dim AdaptadordeDatos As New SqlDataAdapter(micomando)
        Dim dt As New DataTable

        AdaptadordeDatos.Fill(dt)
        ActualizarConexion.Close()
        Return dt
    End Function

    Public Function Insertar(ByVal año As Integer, ByVal mes As Integer, ByVal proveedor As String, _
                             ByVal valor As Double, ByVal restante As Double, ByVal status As String)
        Dim resultado As String = ""
        Dim query As New StringBuilder()
        Dim ActualizarConexion As New SqlConnection(conexion.CadenaSQL())
        query.Append("INSERT INTO [tactical_discount_SanRafael].[dbo].[presupuestos] ")
        query.Append("([AñoId],[MesId],[ProveedorId],[Valor],[Restante],[Status]) ")
        query.Append("VALUES (@AñoId,@MesId,@ProveedorId,@Valor,@Restante,@Status) ")

        Dim micomando As New SqlCommand(query.ToString, ActualizarConexion)
        ActualizarConexion.Open()
        micomando.Parameters.AddWithValue("@AñoId", año)
        micomando.Parameters.AddWithValue("@MesId", mes)
        micomando.Parameters.AddWithValue("@ProveedorId", proveedor)
        micomando.Parameters.AddWithValue("@Valor", valor)
        micomando.Parameters.AddWithValue("@Restante", restante)
        micomando.Parameters.AddWithValue("@Status", status)

        Try
            micomando.ExecuteNonQuery()
            resultado = "correcto"
        Catch ex As Exception
            resultado = ex.Message
        End Try
        ActualizarConexion.Close()
        Return resultado
    End Function

    Public Function InsertarDimosa(ByVal año As Integer, ByVal mes As Integer, ByVal proveedor As String, _
                             ByVal valor As Double, ByVal restante As Double, ByVal status As String)
        Dim resultado As String = ""
        Dim query As New StringBuilder()
        Dim ActualizarConexion As New SqlConnection(conexion_dimosa.CadenaSQL())
        query.Append("INSERT INTO [tactical_discount_Dimosa].[dbo].[presupuestos] ")
        query.Append("([AñoId],[MesId],[ProveedorId],[Valor],[Restante],[Status]) ")
        query.Append("VALUES (@AñoId,@MesId,@ProveedorId,@Valor,@Restante,@Status) ")

        Dim micomando As New SqlCommand(query.ToString, ActualizarConexion)
        ActualizarConexion.Open()
        micomando.Parameters.AddWithValue("@AñoId", año)
        micomando.Parameters.AddWithValue("@MesId", mes)
        micomando.Parameters.AddWithValue("@ProveedorId", proveedor)
        micomando.Parameters.AddWithValue("@Valor", valor)
        micomando.Parameters.AddWithValue("@Restante", restante)
        micomando.Parameters.AddWithValue("@Status", status)

        Try
            micomando.ExecuteNonQuery()
            resultado = "correcto"
        Catch ex As Exception
            resultado = ex.Message
        End Try
        ActualizarConexion.Close()
        Return resultado
    End Function

    Public Function listar_presupuestos(ByVal AÑO_ACTUAL As Integer, ByVal MES_ACTUAL As Integer, ByVal AÑO_ANTE As Integer, ByVal MES_ANTE As Integer)
        Dim query As New StringBuilder()
        Dim actualizarconexion = New SqlConnection(conexion.CadenaSQL())
        query.Append("resumen_presupuestos")
        Dim micomando As New SqlCommand(query.ToString, actualizarconexion)
        micomando.CommandType = CommandType.StoredProcedure
        actualizarconexion.Open()
        micomando.Parameters.AddWithValue("@AÑO_ACTUAL", AÑO_ACTUAL)
        micomando.Parameters.AddWithValue("@MES_ACTUAL", MES_ACTUAL)
        micomando.Parameters.AddWithValue("@AÑO_ANTE", AÑO_ANTE)
        micomando.Parameters.AddWithValue("@MES_ANTE", MES_ANTE)
        micomando.CommandTimeout = 2000
        Dim adaptadordedatos As New SqlDataAdapter(micomando)
        Dim dt As New DataTable
        adaptadordedatos.Fill(dt)
        actualizarconexion.Close()
        Return dt
    End Function

    Public Function listar_presupuestosDimosa(ByVal AÑO_ACTUAL As Integer, ByVal MES_ACTUAL As Integer, ByVal AÑO_ANTE As Integer, ByVal MES_ANTE As Integer)
        Dim query As New StringBuilder()
        Dim actualizarconexion = New SqlConnection(conexion_dimosa.CadenaSQL())
        query.Append("resumen_presupuestos")
        Dim micomando As New SqlCommand(query.ToString, actualizarconexion)
        micomando.CommandType = CommandType.StoredProcedure
        actualizarconexion.Open()
        micomando.Parameters.AddWithValue("@AÑO_ACTUAL", AÑO_ACTUAL)
        micomando.Parameters.AddWithValue("@MES_ACTUAL", MES_ACTUAL)
        micomando.Parameters.AddWithValue("@AÑO_ANTE", AÑO_ANTE)
        micomando.Parameters.AddWithValue("@MES_ANTE", MES_ANTE)
        micomando.CommandTimeout = 2000
        Dim adaptadordedatos As New SqlDataAdapter(micomando)
        Dim dt As New DataTable
        adaptadordedatos.Fill(dt)
        actualizarconexion.Close()
        Return dt
    End Function

    Public Function listar_presupuestosOPL(ByVal AÑO_ACTUAL As Integer, ByVal MES_ACTUAL As Integer, ByVal AÑO_ANTE As Integer, ByVal MES_ANTE As Integer)
        Dim query As New StringBuilder()
        Dim actualizarconexion = New SqlConnection(conexion_Descuentos_Opl.CadenaSQL())
        query.Append("resumen_presupuestos")
        Dim micomando As New SqlCommand(query.ToString, actualizarconexion)
        micomando.CommandType = CommandType.StoredProcedure
        actualizarconexion.Open()
        micomando.Parameters.AddWithValue("@AÑO_ACTUAL", AÑO_ACTUAL)
        micomando.Parameters.AddWithValue("@MES_ACTUAL", MES_ACTUAL)
        micomando.Parameters.AddWithValue("@AÑO_ANTE", AÑO_ANTE)
        micomando.Parameters.AddWithValue("@MES_ANTE", MES_ANTE)
        micomando.CommandTimeout = 2000
        Dim adaptadordedatos As New SqlDataAdapter(micomando)
        Dim dt As New DataTable
        adaptadordedatos.Fill(dt)
        actualizarconexion.Close()
        Return dt
    End Function

    Public Function Actualizar(ByVal valor As Double, ByVal restante As Double, ByVal status As String, _
                               ByVal Añoid As Integer, ByVal Mesid As Integer, ByVal ProveedorId As String)
        Dim query As New StringBuilder
        Dim actualizarconexion As New SqlConnection(conexion.CadenaSQL)
        Dim resultado As String
        query.Append("UPDATE [tactical_discount_SanRafael].[dbo].[presupuestos] ")
        query.Append("SET  [Valor] = [Valor] + @Valor,[Restante] = [Restante] + @Valor,[Status] = @Status ")
        query.Append("WHERE [AñoId] = @AñoId AND [MesId] = @MesId AND [ProveedorId] = @ProveedorId ")

        Dim micomando As New SqlCommand(query.ToString, actualizarconexion)
        actualizarconexion.Open()
        micomando.Parameters.AddWithValue("@Valor", valor)
        micomando.Parameters.AddWithValue("@Restante", restante)
        micomando.Parameters.AddWithValue("@Status", status)
        micomando.Parameters.AddWithValue("@AñoId", AñoId)
        micomando.Parameters.AddWithValue("@MesId", MesId)
        micomando.Parameters.AddWithValue("@ProveedorId", ProveedorId)

        Try
            micomando.ExecuteNonQuery()
            resultado = "correcto"
        Catch ex As Exception
            resultado = ex.Message
        End Try

        actualizarconexion.Close()
        Return resultado
    End Function

    Public Function ActualizarDimosa(ByVal valor As Double, ByVal restante As Double, ByVal status As String, _
                               ByVal Añoid As Integer, ByVal Mesid As Integer, ByVal ProveedorId As String)
        Dim query As New StringBuilder
        Dim actualizarconexion As New SqlConnection(conexion_dimosa.CadenaSQL)
        Dim resultado As String
        query.Append("UPDATE [tactical_discount_dimosa].[dbo].[presupuestos] ")
        query.Append("SET  [Valor] = [Valor] + @Valor,[Restante] = [Restante] + @Valor,[Status] = @Status ")
        query.Append("WHERE [AñoId] = @AñoId AND [MesId] = @MesId AND [ProveedorId] = @ProveedorId ")

        Dim micomando As New SqlCommand(query.ToString, actualizarconexion)
        actualizarconexion.Open()
        micomando.Parameters.AddWithValue("@Valor", valor)
        micomando.Parameters.AddWithValue("@Restante", restante)
        micomando.Parameters.AddWithValue("@Status", status)
        micomando.Parameters.AddWithValue("@AñoId", Añoid)
        micomando.Parameters.AddWithValue("@MesId", Mesid)
        micomando.Parameters.AddWithValue("@ProveedorId", ProveedorId)

        Try
            micomando.ExecuteNonQuery()
            resultado = "correcto"
        Catch ex As Exception
            resultado = ex.Message
        End Try

        actualizarconexion.Close()
        Return resultado
    End Function

    Public Function eliminar(ByVal Añoid As Integer, ByVal Mesid As Integer, ByVal ProveedorId As String)
        Dim query As New StringBuilder
        Dim actualizarconexion As New SqlConnection(conexion.CadenaSQL)
        Dim resultado As String

        query.Append("DELETE FROM [tactical_discount_SanRafael].[dbo].[presupuestos] ")
        query.Append("WHERE [AñoId] = @AñoId AND [MesId] = @MesId AND [ProveedorId] = @ProveedorId")

        Dim micomando As New SqlCommand(query.ToString, actualizarconexion)
        actualizarconexion.Open()
        micomando.Parameters.AddWithValue("@AñoId", Añoid)
        micomando.Parameters.AddWithValue("@MesId", Mesid)
        micomando.Parameters.AddWithValue("@ProveedorId", ProveedorId)

        Try
            micomando.ExecuteNonQuery()
            resultado = "correcto"
        Catch ex As Exception
            resultado = ex.Message
        End Try
        actualizarconexion.Close()
        Return resultado
    End Function

    Public Function eliminarDimosa(ByVal Añoid As Integer, ByVal Mesid As Integer, ByVal ProveedorId As String)
        Dim query As New StringBuilder
        Dim actualizarconexion As New SqlConnection(conexion_dimosa.CadenaSQL)
        Dim resultado As String

        query.Append("DELETE FROM [tactical_discount_dimosa].[dbo].[presupuestos] ")
        query.Append("WHERE [AñoId] = @AñoId AND [MesId] = @MesId AND [ProveedorId] = @ProveedorId")

        Dim micomando As New SqlCommand(query.ToString, actualizarconexion)
        actualizarconexion.Open()
        micomando.Parameters.AddWithValue("@AñoId", Añoid)
        micomando.Parameters.AddWithValue("@MesId", Mesid)
        micomando.Parameters.AddWithValue("@ProveedorId", ProveedorId)

        Try
            micomando.ExecuteNonQuery()
            resultado = "correcto"
        Catch ex As Exception
            resultado = ex.Message
        End Try
        actualizarconexion.Close()
        Return resultado
    End Function

    Public Function ListarAlmacenes()
        Dim actualizarconexion As New SqlConnection(conexion_consumo.CadenaSQL)
        Dim query As New StringBuilder

        query.Append("SELECT CVE_ALM AS 'ID', DESCR AS 'ALMACEN' ")
        query.Append("FROM SAE60Empre05.dbo.ALMACENES05 UNION ALL SELECT -1 AS ID, 'TODAS' AS ALMACEN ")

        Dim micomando As New SqlCommand(query.ToString, actualizarconexion)
        actualizarconexion.Open()
        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable

        adaptador.Fill(dt)
        actualizarconexion.Close()
        Return dt
    End Function

    Public Function ListarAlmacenesDimosa()
        Dim actualizarconexion As New SqlConnection(conexion_consumo_dimosa.CadenaSQL)
        Dim query As New StringBuilder

        query.Append("SELECT CVE_ALM AS 'ID', DESCR AS 'ALMACEN' ")
        query.Append("FROM SAE60Empre06.dbo.ALMACENES06 UNION ALL SELECT -1 AS ID, 'TODAS' AS ALMACEN ")

        Dim micomando As New SqlCommand(query.ToString, actualizarconexion)
        actualizarconexion.Open()
        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable

        adaptador.Fill(dt)
        actualizarconexion.Close()
        Return dt
    End Function

    Public Function ListarAlmacenesOPL()
        Dim actualizarconexion As New SqlConnection(conexion_OPL.CadenaSQL)
        Dim query As New StringBuilder

        query.Append("SELECT CVE_ALM AS 'ID', DESCR AS 'ALMACEN' ")
        query.Append("FROM SAE60Empre08.dbo.ALMACENES08 UNION ALL SELECT -1 AS ID, 'TODAS' AS ALMACEN ")

        Dim micomando As New SqlCommand(query.ToString, actualizarconexion)
        actualizarconexion.Open()
        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable

        adaptador.Fill(dt)
        actualizarconexion.Close()
        Return dt
    End Function

    Public Function ListarAlmacenes_para_resumen()
        Dim actualizarconexion As New SqlConnection(conexion_consumo.CadenaSQL)
        Dim query As New StringBuilder

        query.Append("SELECT -1 AS 'ID', 'TODAS' AS 'ALMACEN' UNION ALL ")
        query.Append("SELECT CVE_ALM AS 'ID', DESCR AS 'ALMACEN' ")
        query.Append("FROM SAE60Empre05.dbo.ALMACENES05 ")

        Dim micomando As New SqlCommand(query.ToString, actualizarconexion)
        actualizarconexion.Open()
        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable

        adaptador.Fill(dt)
        actualizarconexion.Close()
        Return dt
    End Function

    Public Function ListarAlmacenes_para_resumen_dimosa()
        Dim actualizarconexion As New SqlConnection(conexion_consumo_dimosa.CadenaSQL)
        Dim query As New StringBuilder

        query.Append("SELECT -1 AS 'ID', 'TODAS' AS 'ALMACEN' UNION ALL ")
        query.Append("SELECT CVE_ALM AS 'ID', DESCR AS 'ALMACEN' ")
        query.Append("FROM SAE60Empre06.dbo.ALMACENES06 ")

        Dim micomando As New SqlCommand(query.ToString, actualizarconexion)
        actualizarconexion.Open()
        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable

        adaptador.Fill(dt)
        actualizarconexion.Close()
        Return dt
    End Function

    Public Function ListarAlmacenes_para_resumen_opl()
        Dim actualizarconexion As New SqlConnection(conexion_OPL.CadenaSQL)
        Dim query As New StringBuilder

        query.Append("SELECT -1 AS 'ID', 'TODAS' AS 'ALMACEN' UNION ALL ")
        query.Append("SELECT CVE_ALM AS 'ID', DESCR AS 'ALMACEN' ")
        query.Append("FROM SAE60Empre08.dbo.ALMACENES08 ")

        Dim micomando As New SqlCommand(query.ToString, actualizarconexion)
        actualizarconexion.Open()
        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable

        adaptador.Fill(dt)
        actualizarconexion.Close()
        Return dt
    End Function

    Public Function ListarDescuentos_encabezados(ByVal FECHA As Date, ByVal ALMACEN As Integer)
        Dim actualizarconexion As New SqlConnection(conexion.CadenaSQL)
        Dim query As New StringBuilder

        query.Append("SELECT E.CODIGO AS [Num Reg], E.CLIENTE AS [Codigo de Cliente],CL.NOMBRE AS [Cliente], ")
        query.Append("E.FACTURA AS [Nº Factura],E.ALMACEN AS [Codigo de Almacen], REPLACE(A.DESCR,'Almacén ','') AS [Almacen], E.TIPO AS [Tipo], ")
        query.Append(" E.IMPORTE AS [Monto],E.ESTADO AS [Estado], E.FECHA AS [Fecha], DOC_NC AS 'Num NC', REPLACE(ESTADO_SAE,'C','CANCELADA') ")
        query.Append(" AS 'ESTADO EN SAE', ISNULL((SELECT CTLPOL FROM SAE60Empre05.dbo.FACTD05 WHERE CVE_DOC = DOC_NC COLLATE MODERN_SPANISH_CI_AS),0) AS INTERFACE ")
        query.Append("FROM encabezados E INNER JOIN SAE60Empre05.dbo.CLIE05 CL ON CL.CLAVE = E.CLIENTE ")
        query.Append("COLLATE MODERN_SPANISH_CI_AS INNER JOIN SAE60Empre05.dbo.ALMACENES05 A ON E.ALMACEN = A.CVE_ALM ")
        query.Append("WHERE CONVERT(DATE,E.FECHA,103) = CONVERT(DATE,@FECHA,103) AND E.ALMACEN =@ALMACEN  ")

        Dim micomando As New SqlCommand(query.ToString, actualizarconexion)
        actualizarconexion.Open()
        micomando.Parameters.AddWithValue("@FECHA", FECHA)
        micomando.Parameters.AddWithValue("@ALMACEN", ALMACEN)

        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable

        adaptador.Fill(dt)
        actualizarconexion.Close()
        Return dt
    End Function

    Public Function ListarDescuentos_encabezados_dimosa(ByVal FECHA As Date, ByVal ALMACEN As Integer)
        Dim actualizarconexion As New SqlConnection(conexion_dimosa.CadenaSQL)
        Dim query As New StringBuilder

        query.Append("SELECT E.CODIGO AS [Num Reg], E.CLIENTE AS [Codigo de Cliente],CL.NOMBRE AS [Cliente], ")
        query.Append("E.FACTURA AS [Nº Factura],E.ALMACEN AS [Codigo de Almacen], REPLACE(A.DESCR,'Almacén ','') AS [Almacen], E.TIPO AS [Tipo], ")
        query.Append(" E.IMPORTE AS [Monto],E.ESTADO AS [Estado], E.FECHA AS [Fecha], DOC_NC AS 'Num NC', REPLACE(ESTADO_SAE,'C','CANCELADA') ")
        query.Append(" AS 'ESTADO EN SAE', ISNULL((SELECT CTLPOL FROM SAE60Empre06.dbo.FACTD06 WHERE CVE_DOC = DOC_NC COLLATE MODERN_SPANISH_CI_AS),0) AS INTERFACE ")
        query.Append("FROM encabezados E INNER JOIN SAE60Empre06.dbo.CLIE06 CL ON CL.CLAVE = E.CLIENTE ")
        query.Append("COLLATE MODERN_SPANISH_CI_AS INNER JOIN SAE60Empre06.dbo.ALMACENES06 A ON E.ALMACEN = A.CVE_ALM ")
        query.Append("WHERE CONVERT(DATE,E.FECHA,103) = CONVERT(DATE,@FECHA,103) AND E.ALMACEN =@ALMACEN  ")

        Dim micomando As New SqlCommand(query.ToString, actualizarconexion)
        actualizarconexion.Open()
        micomando.Parameters.AddWithValue("@FECHA", FECHA)
        micomando.Parameters.AddWithValue("@ALMACEN", ALMACEN)

        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable

        adaptador.Fill(dt)
        actualizarconexion.Close()
        Return dt
    End Function

    Public Function ListarDescuentos_encabezados_OPL(ByVal FECHA As Date, ByVal ALMACEN As Integer)
        Dim actualizarconexion As New SqlConnection(conexion_Descuentos_Opl.CadenaSQL)
        Dim query As New StringBuilder

        query.Append("SELECT E.CODIGO AS [Num Reg], E.CLIENTE AS [Codigo de Cliente],CL.NOMBRE AS [Cliente], ")
        query.Append("E.FACTURA AS [Nº Factura],E.ALMACEN AS [Codigo de Almacen], REPLACE(A.DESCR,'Almacén ','') AS [Almacen], E.TIPO AS [Tipo], ")
        query.Append(" E.IMPORTE AS [Monto],E.ESTADO AS [Estado], E.FECHA AS [Fecha], DOC_NC AS 'Num NC', REPLACE(ESTADO_SAE,'C','CANCELADA') ")
        query.Append(" AS 'ESTADO EN SAE', ISNULL((SELECT CTLPOL FROM SAE60Empre08.dbo.FACTD08 WHERE CVE_DOC = DOC_NC COLLATE MODERN_SPANISH_CI_AS),0) AS INTERFACE ")
        query.Append("FROM encabezados E INNER JOIN SAE60Empre08.dbo.CLIE08 CL ON CL.CLAVE = E.CLIENTE ")
        query.Append("COLLATE MODERN_SPANISH_CI_AS INNER JOIN SAE60Empre08.dbo.ALMACENES08 A ON E.ALMACEN = A.CVE_ALM ")
        query.Append("WHERE CONVERT(DATE,E.FECHA,103) = CONVERT(DATE,@FECHA,103) AND E.ALMACEN =@ALMACEN  ")

        Dim micomando As New SqlCommand(query.ToString, actualizarconexion)
        actualizarconexion.Open()
        micomando.Parameters.AddWithValue("@FECHA", FECHA)
        micomando.Parameters.AddWithValue("@ALMACEN", ALMACEN)

        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable

        adaptador.Fill(dt)
        actualizarconexion.Close()
        Return dt
    End Function

    Public Function Listarctlpol(ByVal CTLPOL As Integer)
        Dim actualizarconexion As New SqlConnection(conexion.CadenaSQL)
        Dim query As New StringBuilder

        query.Append("SELECT TIPOPOL, NUMPOL, FECHAPOL,STATUS FROM SAE60Empre05.dbo.INTCOI05 WHERE CTLPOL = @CTLPOL")

        Dim micomando As New SqlCommand(query.ToString, actualizarconexion)
        actualizarconexion.Open()
        micomando.Parameters.AddWithValue("@CTLPOL", CTLPOL)

        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable

        adaptador.Fill(dt)
        actualizarconexion.Close()
        Return dt
    End Function

    Public Function Listarctlpol_dimosa(ByVal CTLPOL As Integer)
        Dim actualizarconexion As New SqlConnection(conexion_dimosa.CadenaSQL)
        Dim query As New StringBuilder

        query.Append("SELECT TIPOPOL, NUMPOL, FECHAPOL,STATUS FROM SAE60Empre06.dbo.INTCOI06 WHERE CTLPOL = @CTLPOL")

        Dim micomando As New SqlCommand(query.ToString, actualizarconexion)
        actualizarconexion.Open()
        micomando.Parameters.AddWithValue("@CTLPOL", CTLPOL)

        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable

        adaptador.Fill(dt)
        actualizarconexion.Close()
        Return dt
    End Function

    Public Function Listarctlpol_opl(ByVal CTLPOL As Integer)
        Dim actualizarconexion As New SqlConnection(conexion_dimosa.CadenaSQL)
        Dim query As New StringBuilder

        query.Append("SELECT TIPOPOL, NUMPOL, FECHAPOL,STATUS FROM SAE60Empre08.dbo.INTCOI08 WHERE CTLPOL = @CTLPOL")

        Dim micomando As New SqlCommand(query.ToString, actualizarconexion)
        actualizarconexion.Open()
        micomando.Parameters.AddWithValue("@CTLPOL", CTLPOL)

        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable

        adaptador.Fill(dt)
        actualizarconexion.Close()
        Return dt
    End Function

    Public Function listar_ctlpol(ByVal NC As String)
        Dim actualizarconexion As New SqlConnection(conexion.CadenaSQL)
        Dim query As New StringBuilder

        query.Append("SELECT CTLPOL FROM SAE60Empre05.dbo.FACTD05 WHERE CVE_DOC = @NC COLLATE MODERN_SPANISH_CI_AS")

        Dim micomando As New SqlCommand(query.ToString, actualizarconexion)
        actualizarconexion.Open()
        micomando.Parameters.AddWithValue("@NC", NC)

        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable

        adaptador.Fill(dt)
        actualizarconexion.Close()
        If dt.Rows.Count > 0 Then
            Return dt.Rows(0)(0)
        Else
            Return "0"
        End If
    End Function

    Public Function listar_ctlpol_dimosa(ByVal NC As String)
        Dim actualizarconexion As New SqlConnection(conexion.CadenaSQL)
        Dim query As New StringBuilder

        query.Append("SELECT CTLPOL FROM SAE60Empre06.dbo.FACTD06 WHERE CVE_DOC = @NC COLLATE MODERN_SPANISH_CI_AS")

        Dim micomando As New SqlCommand(query.ToString, actualizarconexion)
        actualizarconexion.Open()
        micomando.Parameters.AddWithValue("@NC", NC)

        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable

        adaptador.Fill(dt)
        actualizarconexion.Close()
        If dt.Rows.Count > 0 Then
            Return dt.Rows(0)(0)
        Else
            Return "0"
        End If
    End Function

    Public Function listar_ctlpol_opl(ByVal NC As String)
        Dim actualizarconexion As New SqlConnection(conexion.CadenaSQL)
        Dim query As New StringBuilder

        query.Append("SELECT CTLPOL FROM SAE60Empre08.dbo.FACTD08 WHERE CVE_DOC = @NC COLLATE MODERN_SPANISH_CI_AS")

        Dim micomando As New SqlCommand(query.ToString, actualizarconexion)
        actualizarconexion.Open()
        micomando.Parameters.AddWithValue("@NC", NC)

        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable

        adaptador.Fill(dt)
        actualizarconexion.Close()
        If dt.Rows.Count > 0 Then
            Return dt.Rows(0)(0)
        Else
            Return "0"
        End If
    End Function

    Public Function listar_ctlpol_concepto31(ByVal NC As String, ByVal DOC2 As String)
        Dim actualizarconexion As New SqlConnection(conexion.CadenaSQL)
        Dim query As New StringBuilder

        query.Append("SELECT ISNULL(CTLPOL,0) FROM SAE60Empre05.dbo.CUEN_DET05 WHERE (DOCTO = @NC COLLATE MODERN_SPANISH_CI_AS) AND NUM_CPTO = 31")

        Dim micomando As New SqlCommand(query.ToString, actualizarconexion)
        actualizarconexion.Open()
        micomando.Parameters.AddWithValue("@NC", NC)
        micomando.Parameters.AddWithValue("@DOC2", DOC2)

        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable

        adaptador.Fill(dt)
        actualizarconexion.Close()
        If dt.Rows.Count > 0 Then
            Return dt.Rows(0)(0)
        Else
            Return "0"
        End If
    End Function

    Public Function listar_ctlpol_concepto31_dimosa(ByVal NC As String, ByVal DOC2 As String)
        Dim actualizarconexion As New SqlConnection(conexion.CadenaSQL)
        Dim query As New StringBuilder

        query.Append("SELECT ISNULL(CTLPOL,0) FROM SAE60Empre06.dbo.CUEN_DET06 WHERE (DOCTO = @NC COLLATE MODERN_SPANISH_CI_AS) AND NUM_CPTO = 31")

        Dim micomando As New SqlCommand(query.ToString, actualizarconexion)
        actualizarconexion.Open()
        micomando.Parameters.AddWithValue("@NC", NC)
        micomando.Parameters.AddWithValue("@DOC2", DOC2)

        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable

        adaptador.Fill(dt)
        actualizarconexion.Close()
        If dt.Rows.Count > 0 Then
            Return dt.Rows(0)(0)
        Else
            Return "0"
        End If
    End Function

    Public Function listar_ctlpol_concepto31_opl(ByVal NC As String, ByVal DOC2 As String)
        Dim actualizarconexion As New SqlConnection(conexion.CadenaSQL)
        Dim query As New StringBuilder

        query.Append("SELECT ISNULL(CTLPOL,0) FROM SAE60Empre08.dbo.CUEN_DET08 WHERE (DOCTO = @NC COLLATE MODERN_SPANISH_CI_AS) AND NUM_CPTO = 31")

        Dim micomando As New SqlCommand(query.ToString, actualizarconexion)
        actualizarconexion.Open()
        micomando.Parameters.AddWithValue("@NC", NC)
        micomando.Parameters.AddWithValue("@DOC2", DOC2)

        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable

        adaptador.Fill(dt)
        actualizarconexion.Close()
        If dt.Rows.Count > 0 Then
            Return dt.Rows(0)(0)
        Else
            Return "0"
        End If
    End Function

    Public Function Listardoctos_pol(ByVal CTLPOL As Integer)
        Dim actualizarconexion As New SqlConnection(conexion.CadenaSQL)
        Dim query As New StringBuilder

        query.Append("SELECT CVE_DOC AS 'NOTA DE CREDITO',FECHA_DOC AS FECHA,DOC_ANT AS FACTURA FROM SAE60Empre05.dbo.FACTD05 WHERE CTLPOL = @CTLPOL ")

        Dim micomando As New SqlCommand(query.ToString, actualizarconexion)
        actualizarconexion.Open()
        micomando.Parameters.AddWithValue("@CTLPOL", CTLPOL)

        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable

        adaptador.Fill(dt)
        actualizarconexion.Close()
        Return dt
    End Function

    Public Function Listardoctos_pol_dimosa(ByVal CTLPOL As Integer)
        Dim actualizarconexion As New SqlConnection(conexion.CadenaSQL)
        Dim query As New StringBuilder

        query.Append("SELECT CVE_DOC AS 'NOTA DE CREDITO',FECHA_DOC AS FECHA,DOC_ANT AS FACTURA FROM SAE60Empre06.dbo.FACTD06 WHERE CTLPOL = @CTLPOL ")

        Dim micomando As New SqlCommand(query.ToString, actualizarconexion)
        actualizarconexion.Open()
        micomando.Parameters.AddWithValue("@CTLPOL", CTLPOL)

        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable

        adaptador.Fill(dt)
        actualizarconexion.Close()
        Return dt
    End Function

    Public Function Listardoctos_pol_opl(ByVal CTLPOL As Integer)
        Dim actualizarconexion As New SqlConnection(conexion.CadenaSQL)
        Dim query As New StringBuilder

        query.Append("SELECT CVE_DOC AS 'NOTA DE CREDITO',FECHA_DOC AS FECHA,DOC_ANT AS FACTURA FROM SAE60Empre08.dbo.FACTD08 WHERE CTLPOL = @CTLPOL ")

        Dim micomando As New SqlCommand(query.ToString, actualizarconexion)
        actualizarconexion.Open()
        micomando.Parameters.AddWithValue("@CTLPOL", CTLPOL)

        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable

        adaptador.Fill(dt)
        actualizarconexion.Close()
        Return dt
    End Function

    Public Function Listardoctos_pol_C31(ByVal CTLPOL As Integer)
        Dim actualizarconexion As New SqlConnection(conexion.CadenaSQL)
        Dim query As New StringBuilder

        query.Append("SELECT REFER AS 'NOTA DE CREDITO',DOCTO,FECHA_APLI, IMPORTE FROM SAE60Empre05.dbo.CUEN_DET05 WHERE CTLPOL = @CTLPOL AND NUM_CPTO = 31 ")

        Dim micomando As New SqlCommand(query.ToString, actualizarconexion)
        actualizarconexion.Open()
        micomando.Parameters.AddWithValue("@CTLPOL", CTLPOL)

        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable

        adaptador.Fill(dt)
        actualizarconexion.Close()
        Return dt
    End Function

    Public Function Listardoctos_pol_C31_dimosa(ByVal CTLPOL As Integer)
        Dim actualizarconexion As New SqlConnection(conexion.CadenaSQL)
        Dim query As New StringBuilder

        query.Append("SELECT REFER AS 'NOTA DE CREDITO',DOCTO,FECHA_APLI, IMPORTE FROM SAE60Empre06.dbo.CUEN_DET06 WHERE CTLPOL = @CTLPOL AND NUM_CPTO = 31 ")

        Dim micomando As New SqlCommand(query.ToString, actualizarconexion)
        actualizarconexion.Open()
        micomando.Parameters.AddWithValue("@CTLPOL", CTLPOL)

        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable

        adaptador.Fill(dt)
        actualizarconexion.Close()
        Return dt
    End Function

    Public Function Listardoctos_pol_C31_opl(ByVal CTLPOL As Integer)
        Dim actualizarconexion As New SqlConnection(conexion.CadenaSQL)
        Dim query As New StringBuilder

        query.Append("SELECT REFER AS 'NOTA DE CREDITO',DOCTO,FECHA_APLI, IMPORTE FROM SAE60Empre08.dbo.CUEN_DET08 WHERE CTLPOL = @CTLPOL AND NUM_CPTO = 31 ")

        Dim micomando As New SqlCommand(query.ToString, actualizarconexion)
        actualizarconexion.Open()
        micomando.Parameters.AddWithValue("@CTLPOL", CTLPOL)

        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable

        adaptador.Fill(dt)
        actualizarconexion.Close()
        Return dt
    End Function

    Public Function Listardoctos_pol_C31_sr_agro(ByVal CTLPOL As Integer)
        Dim actualizarconexion As New SqlConnection(conexion.CadenaSQL)
        Dim query As New StringBuilder

        query.Append("SELECT REFER AS 'NOTA DE CREDITO',DOCTO,FECHA_APLI, IMPORTE FROM SAE60Empre02.dbo.CUEN_DET02 WHERE CTLPOL = @CTLPOL AND NUM_CPTO = 31 ")

        Dim micomando As New SqlCommand(query.ToString, actualizarconexion)
        actualizarconexion.Open()
        micomando.Parameters.AddWithValue("@CTLPOL", CTLPOL)

        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable

        adaptador.Fill(dt)
        actualizarconexion.Close()
        Return dt
    End Function

    Public Function seleccionar_poliza_coi(ByVal num_poliz As String, ByVal nyear As Integer, ByVal nmes As Integer, ByVal tipo_poliza As String)
        Dim actualizarconexion As New SqlConnection(conexion_coi_san_rafael.CadenaSQL)
        Dim year_short As Integer
        year_short = Convert.ToInt32((nyear.ToString()).Substring(2, 2))
        Dim qx_auxiliares = New StringBuilder()
        qx_auxiliares.Append("SELECT TIPO_POLI AS TIPO, NUM_POLIZ AS NO, NUM_PART AS ID, NUM_CTA AS CTA, FECHA_POL AS FECHA, ")
        qx_auxiliares.Append("CONCEP_PO AS CONCEPTO, DEBE_HABER AS SIGNO, MONTOMOV AS MONTO ")
        qx_auxiliares.Append("FROM [COI70Empre08].[dbo].[AUXILIAR" + year_short.ToString() + "08] ")
        qx_auxiliares.Append("WHERE	(TIPO_POLI = @TIPO_POLI) AND (LTRIM(NUM_POLIZ) = LTRIM(@NUM_POLIZ)) ")
        qx_auxiliares.Append("AND (PERIODO = @PERIODO) AND (EJERCICIO = @EJERCICIO) ")

        Dim cmd_ins_auxiliares = New SqlCommand(qx_auxiliares.ToString(), actualizarconexion)

        cmd_ins_auxiliares.Parameters.AddWithValue("@TIPO_POLI", tipo_poliza)
        cmd_ins_auxiliares.Parameters.AddWithValue("@NUM_POLIZ", num_poliz)
        cmd_ins_auxiliares.Parameters.AddWithValue("@EJERCICIO", nyear)
        cmd_ins_auxiliares.Parameters.AddWithValue("@PERIODO", nmes)
        Dim adaptador = New SqlDataAdapter(cmd_ins_auxiliares)
        Dim tabla As New DataTable
        adaptador.Fill(tabla)
        Return tabla
    End Function

    Public Function seleccionar_poliza_coi_dimosa(ByVal num_poliz As String, ByVal nyear As Integer, ByVal nmes As Integer, ByVal tipo_poliza As String)
        Dim actualizarconexion As New SqlConnection(conexion_coi_dimosa.CadenaSQL)
        Dim year_short As Integer
        year_short = Convert.ToInt32((nyear.ToString()).Substring(2, 2))
        Dim qx_auxiliares = New StringBuilder()
        qx_auxiliares.Append("SELECT TIPO_POLI AS TIPO, NUM_POLIZ AS NO, NUM_PART AS ID, NUM_CTA AS CTA, FECHA_POL AS FECHA, ")
        qx_auxiliares.Append("CONCEP_PO AS CONCEPTO, DEBE_HABER AS SIGNO, MONTOMOV AS MONTO ")
        qx_auxiliares.Append("FROM [COI70Empre09].[dbo].[AUXILIAR" + year_short.ToString() + "09] ")
        qx_auxiliares.Append("WHERE	(TIPO_POLI = @TIPO_POLI) AND (LTRIM(NUM_POLIZ) = LTRIM(@NUM_POLIZ)) ")
        qx_auxiliares.Append("AND (PERIODO = @PERIODO) AND (EJERCICIO = @EJERCICIO) ")

        Dim cmd_ins_auxiliares = New SqlCommand(qx_auxiliares.ToString(), actualizarconexion)

        cmd_ins_auxiliares.Parameters.AddWithValue("@TIPO_POLI", tipo_poliza)
        cmd_ins_auxiliares.Parameters.AddWithValue("@NUM_POLIZ", num_poliz)
        cmd_ins_auxiliares.Parameters.AddWithValue("@EJERCICIO", nyear)
        cmd_ins_auxiliares.Parameters.AddWithValue("@PERIODO", nmes)
        Dim adaptador = New SqlDataAdapter(cmd_ins_auxiliares)
        Dim tabla As New DataTable
        adaptador.Fill(tabla)
        Return tabla
    End Function

    Public Function seleccionar_poliza_coi_opl(ByVal num_poliz As String, ByVal nyear As Integer, ByVal nmes As Integer, ByVal tipo_poliza As String)
        Dim actualizarconexion As New SqlConnection(conexion_coi_opl.CadenaSQL)
        Dim year_short As Integer
        year_short = Convert.ToInt32((nyear.ToString()).Substring(2, 2))
        Dim qx_auxiliares = New StringBuilder()
        qx_auxiliares.Append("SELECT TIPO_POLI AS TIPO, NUM_POLIZ AS NO, NUM_PART AS ID, NUM_CTA AS CTA, FECHA_POL AS FECHA, ")
        qx_auxiliares.Append("CONCEP_PO AS CONCEPTO, DEBE_HABER AS SIGNO, MONTOMOV AS MONTO ")
        qx_auxiliares.Append("FROM [COI70Empre10].[dbo].[AUXILIAR" + year_short.ToString() + "10] ")
        qx_auxiliares.Append("WHERE	(TIPO_POLI = @TIPO_POLI) AND (LTRIM(NUM_POLIZ) = LTRIM(@NUM_POLIZ)) ")
        qx_auxiliares.Append("AND (PERIODO = @PERIODO) AND (EJERCICIO = @EJERCICIO) ")

        Dim cmd_ins_auxiliares = New SqlCommand(qx_auxiliares.ToString(), actualizarconexion)

        cmd_ins_auxiliares.Parameters.AddWithValue("@TIPO_POLI", tipo_poliza)
        cmd_ins_auxiliares.Parameters.AddWithValue("@NUM_POLIZ", num_poliz)
        cmd_ins_auxiliares.Parameters.AddWithValue("@EJERCICIO", nyear)
        cmd_ins_auxiliares.Parameters.AddWithValue("@PERIODO", nmes)
        Dim adaptador = New SqlDataAdapter(cmd_ins_auxiliares)
        Dim tabla As New DataTable
        adaptador.Fill(tabla)
        Return tabla
    End Function

    Public Function ListarDescuentos_administracion(ByVal FECHA_INI As Date, ByVal FECHA_FIN As Date, ByVal ALMACEN As Integer)
        Dim actualizarconexion As New SqlConnection(conexion.CadenaSQL)
        Dim query As New StringBuilder

        Dim micomando As New SqlCommand("des_tac_resumen_admon", actualizarconexion)
        micomando.CommandType = CommandType.StoredProcedure
        actualizarconexion.Open()
        micomando.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.Date)).Value = FECHA_INI
        micomando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.Date)).Value = FECHA_FIN
        micomando.Parameters.Add(New SqlParameter("@ALMACEN", SqlDbType.Int)).Value = ALMACEN

        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable

        adaptador.Fill(dt)
        actualizarconexion.Close()
        Return dt
    End Function

    Public Function ListarDescuentos_administracion_dimosa(ByVal FECHA_INI As Date, ByVal FECHA_FIN As Date, ByVal ALMACEN As Integer)
        Dim actualizarconexion As New SqlConnection(conexion_dimosa.CadenaSQL)
        Dim query As New StringBuilder

        Dim micomando As New SqlCommand("des_tac_resumen_admon", actualizarconexion)
        micomando.CommandType = CommandType.StoredProcedure
        actualizarconexion.Open()
        micomando.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.Date)).Value = FECHA_INI
        micomando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.Date)).Value = FECHA_FIN
        micomando.Parameters.Add(New SqlParameter("@ALMACEN", SqlDbType.Int)).Value = ALMACEN

        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable

        adaptador.Fill(dt)
        actualizarconexion.Close()
        Return dt
    End Function

    Public Function ListarDescuentos_administracion_OPL(ByVal FECHA_INI As Date, ByVal FECHA_FIN As Date, ByVal ALMACEN As Integer)
        Dim actualizarconexion As New SqlConnection(conexion_Descuentos_Opl.CadenaSQL)
        Dim query As New StringBuilder

        Dim micomando As New SqlCommand("des_tac_resumen_admon", actualizarconexion)
        micomando.CommandType = CommandType.StoredProcedure
        actualizarconexion.Open()
        micomando.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.Date)).Value = FECHA_INI
        micomando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.Date)).Value = FECHA_FIN
        micomando.Parameters.Add(New SqlParameter("@ALMACEN", SqlDbType.Int)).Value = ALMACEN

        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable

        adaptador.Fill(dt)
        actualizarconexion.Close()
        Return dt
    End Function

    Public Function Listar_Clientes(ByVal BUSCAR As String)
        Dim query As New StringBuilder
        Dim miconexion As New SqlConnection(conexion_consumo.CadenaSQL())
        query.Append("SELECT C.CLAVE, ISNULL(C.NOMBRE,''), V.CVE_VEND, ISNULL(V.NOMBRE,'') AS VENDEDOR, ISNULL(RFC,'') AS DEPTO, ISNULL(CON_CREDITO,'') ")
        query.Append("FROM CLIE05 C INNER JOIN VEND05 V ON ")
        query.Append("C.CVE_VEND = V.CVE_VEND ")
        query.Append("WHERE (C.NOMBRE LIKE '%'+ @BUSCAR + '%' OR CLAVE LIKE '%'+ @BUSCAR +'%') ")
        query.Append(" AND C.STATUS <> 'S' AND C.CVE_VEND <> '  100'")
        Dim micomando As New SqlCommand(query.ToString, miconexion)
        miconexion.Open()
        micomando.Parameters.AddWithValue("@BUSCAR", BUSCAR)
        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        miconexion.Close()
        Return dt
    End Function

    Public Function Listar_Clientes_FLOTA(ByVal BUSCAR As String)
        Dim query As New StringBuilder
        Dim miconexion As New SqlConnection(conexion_FLOTA.CadenaSQL())
        query.Append("SELECT C.CLAVE, ISNULL(C.NOMBRE,''), V.CVE_VEND, ISNULL(V.NOMBRE,'') AS VENDEDOR, ISNULL(RFC,'') AS DEPTO, ISNULL(CON_CREDITO,'') ")
        query.Append("FROM CLIE07 C INNER JOIN VEND07 V ON ")
        query.Append("C.CVE_VEND = V.CVE_VEND ")
        query.Append("WHERE (C.NOMBRE LIKE '%'+ @BUSCAR + '%' OR CLAVE LIKE '%'+ @BUSCAR +'%') ")
        'query.Append(" AND C.STATUS <> 'S' AND C.CVE_VEND <> '  100'")
        Dim micomando As New SqlCommand(query.ToString, miconexion)
        miconexion.Open()
        micomando.Parameters.AddWithValue("@BUSCAR", BUSCAR)
        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        miconexion.Close()
        Return dt
    End Function

    Public Function Listar_ClientesDIMOSA(ByVal BUSCAR As String)
        Dim query As New StringBuilder
        Dim miconexion As New SqlConnection(conexion_consumo_dimosa.CadenaSQL())
        query.Append("SELECT C.CLAVE, ISNULL(C.NOMBRE,''), V.CVE_VEND, ISNULL(V.NOMBRE,'') AS VENDEDOR, ISNULL(RFC,'') AS DEPTO, ISNULL(CON_CREDITO,'') ")
        query.Append("FROM CLIE06 C INNER JOIN VEND06 V ON ")
        query.Append("C.CVE_VEND = V.CVE_VEND ")
        query.Append("WHERE (C.NOMBRE LIKE '%'+ @BUSCAR + '%' OR CLAVE LIKE '%'+ @BUSCAR +'%') ")
        query.Append(" AND C.STATUS <> 'S' AND C.CVE_VEND <> '  100'")
        Dim micomando As New SqlCommand(query.ToString, miconexion)
        miconexion.Open()
        micomando.Parameters.AddWithValue("@BUSCAR", BUSCAR)
        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        miconexion.Close()
        Return dt
    End Function

    Public Function Listar_ClientesOPL(ByVal BUSCAR As String)
        Dim query As New StringBuilder
        Dim miconexion As New SqlConnection(conexion_consumo_dimosa.CadenaSQL())
        query.Append("SELECT C.CLAVE, ISNULL(C.NOMBRE,''), V.CVE_VEND, ISNULL(V.NOMBRE,'') AS VENDEDOR, ISNULL(RFC,'') AS DEPTO, ISNULL(CON_CREDITO,'') ")
        query.Append("FROM SAE60EMPRE08.dbo.CLIE08 C INNER JOIN SAE60EMPRE08.dbo.VEND08 V ON ")
        query.Append("C.CVE_VEND = V.CVE_VEND ")
        query.Append("WHERE (C.NOMBRE LIKE '%'+ @BUSCAR + '%' OR CLAVE LIKE '%'+ @BUSCAR +'%') ")
        query.Append(" AND C.STATUS <> 'S' AND C.CVE_VEND <> '  100'")
        Dim micomando As New SqlCommand(query.ToString, miconexion)
        miconexion.Open()
        micomando.Parameters.AddWithValue("@BUSCAR", BUSCAR)
        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        miconexion.Close()
        Return dt
    End Function

    Public Function listar_facturas(ByVal clave As String)
        Dim miconexion As New SqlConnection(conexion_dimosa.CadenaSQL)
        Dim comando As New SqlCommand("lista_facturas_5", miconexion)
        comando.CommandType = CommandType.StoredProcedure
        miconexion.Open()
        comando.Parameters.Add(New SqlParameter("@CLAVE", SqlDbType.VarChar)).Value = clave
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        miconexion.Close()
        Return dt
    End Function

    Public Function listar_facturasDimosa(ByVal clave As String)
        Dim miconexion As New SqlConnection(conexion_dimosa.CadenaSQL)
        Dim comando As New SqlCommand("lista_facturas_5", miconexion)
        comando.CommandType = CommandType.StoredProcedure
        miconexion.Open()
        comando.Parameters.Add(New SqlParameter("@CLAVE", SqlDbType.VarChar)).Value = clave
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        miconexion.Close()
        Return dt
    End Function

    Public Function listar_facturasOPL(ByVal clave As String)
        Dim miconexion As New SqlConnection(conexion_Descuentos_Opl.CadenaSQL)
        Dim comando As New SqlCommand("lista_facturas_5", miconexion)
        comando.CommandType = CommandType.StoredProcedure
        miconexion.Open()
        comando.Parameters.Add(New SqlParameter("@CLAVE", SqlDbType.VarChar)).Value = clave
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        miconexion.Close()
        Return dt
    End Function

    Public Function folio_facturacion()
        Dim miconexion As New SqlConnection(conexion.CadenaSQL)
        Dim comando As New SqlCommand("SELECT SERIE AS FOLIO FROM SAE60Empre05.dbo.FOLIOSF05 WHERE TIP_DOC = 'F' ORDER BY FECH_ULT_DOC DESC", miconexion)
        miconexion.Open()
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        miconexion.Close()
        Return dt
    End Function

    Public Function folio_facturacionDimosa()
        Dim miconexion As New SqlConnection(conexion.CadenaSQL)
        Dim comando As New SqlCommand("SELECT SERIE AS FOLIO FROM SAE60Empre06.dbo.FOLIOSF06 WHERE TIP_DOC = 'F' ORDER BY FECH_ULT_DOC DESC", miconexion)
        miconexion.Open()
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        miconexion.Close()
        Return dt
    End Function

    Public Function folio_facturacionOPL()
        Dim miconexion As New SqlConnection(conexion.CadenaSQL)
        Dim comando As New SqlCommand("SELECT SERIE AS FOLIO FROM SAE60Empre08.dbo.FOLIOSF08 WHERE TIP_DOC = 'F' ORDER BY FECH_ULT_DOC DESC", miconexion)
        miconexion.Open()
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        miconexion.Close()
        Return dt
    End Function


    Public Function listar_facturas_top1(ByVal clave As String)
        Dim miconexion As New SqlConnection(conexion.CadenaSQL)
        Dim comando As New SqlCommand("lista_facturas_3", miconexion)
        comando.CommandType = CommandType.StoredProcedure
        miconexion.Open()
        comando.Parameters.Add(New SqlParameter("@CLAVE", SqlDbType.VarChar)).Value = clave
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        miconexion.Close()
        Return dt
    End Function

    Public Function listar_facturas_top1_dimosa(ByVal clave As String)
        Dim miconexion As New SqlConnection(conexion_dimosa.CadenaSQL)
        Dim comando As New SqlCommand("lista_facturas_3", miconexion)
        comando.CommandType = CommandType.StoredProcedure
        miconexion.Open()
        comando.Parameters.Add(New SqlParameter("@CLAVE", SqlDbType.VarChar)).Value = clave
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        miconexion.Close()
        Return dt
    End Function

    Public Function listar_facturas_top1_OPL(ByVal clave As String)
        Dim miconexion As New SqlConnection(conexion_Descuentos_Opl.CadenaSQL)
        Dim comando As New SqlCommand("lista_facturas_3", miconexion)
        comando.CommandType = CommandType.StoredProcedure
        miconexion.Open()
        comando.Parameters.Add(New SqlParameter("@CLAVE", SqlDbType.VarChar)).Value = clave
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        miconexion.Close()
        Return dt
    End Function


    Public Function listar_conceptos()
        Dim query As New StringBuilder
        Dim miconexion As New SqlConnection(conexion.CadenaSQL)
        query.Append("SELECT ConceptoId AS ID, Descripcion AS DESCRIPCION ")
        query.Append("FROM conceptos")

        Dim micomando As New SqlCommand(query.ToString, miconexion)
        miconexion.Open()
        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        miconexion.Close()
        Return dt
    End Function

    Public Function listar_conceptos_dimosa()
        Dim query As New StringBuilder
        Dim miconexion As New SqlConnection(conexion_dimosa.CadenaSQL)
        query.Append("SELECT ConceptoId AS ID, Descripcion AS DESCRIPCION ")
        query.Append("FROM conceptos")

        Dim micomando As New SqlCommand(query.ToString, miconexion)
        miconexion.Open()
        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        miconexion.Close()
        Return dt
    End Function

    Public Function listar_conceptos_opl()
        Dim query As New StringBuilder
        Dim miconexion As New SqlConnection(conexion_Descuentos_Opl.CadenaSQL)
        query.Append("SELECT ConceptoId AS ID, Descripcion AS DESCRIPCION ")
        query.Append("FROM conceptos")

        Dim micomando As New SqlCommand(query.ToString, miconexion)
        miconexion.Open()
        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        miconexion.Close()
        Return dt
    End Function

    Public Function listar_productos(ByVal BUSCAR As String) As DataTable
        Dim query As New StringBuilder
        Dim miconexion As New SqlConnection(conexion_consumo.CadenaSQL)
        query.Append("SELECT I.CVE_ART AS 'CODIGO PRODUCTO', I.DESCR AS 'PRODUCTO', ")
        query.Append("P.CLAVE AS 'CODIGO PROVEEDOR', P.NOMBRE AS 'PROVEEDOR' ")
        query.Append("FROM INVE05 I FULL OUTER JOIN  PRVPROD05 PP ON PP.CVE_ART = I.CVE_ART  ")
        query.Append("FULL OUTER JOIN PROV05 P ON PP.CVE_PROV = P.CLAVE ")
        query.Append("WHERE I.STATUS = 'A' AND (I.CVE_ART LIKE '%' + @BUSCAR + '%' OR I.DESCR LIKE '%' + @BUSCAR + '%')")

        Dim micomando As New SqlCommand(query.ToString, miconexion)
        miconexion.Open()
        micomando.Parameters.AddWithValue("@BUSCAR", BUSCAR)

        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        miconexion.Close()
        Return dt
    End Function

    Public Function listar_productos_OPL(ByVal BUSCAR As String) As DataTable
        Dim query As New StringBuilder
        Dim miconexion As New SqlConnection(conexion_OPL.CadenaSQL)
        query.Append("SELECT I.CVE_ART AS 'CODIGO PRODUCTO', I.DESCR AS 'PRODUCTO', ")
        query.Append("P.CLAVE AS 'CODIGO PROVEEDOR', P.NOMBRE AS 'PROVEEDOR' ")
        query.Append("FROM INVE08 I FULL OUTER JOIN  PRVPROD08 PP ON PP.CVE_ART = I.CVE_ART  ")
        query.Append("FULL OUTER JOIN PROV08 P ON PP.CVE_PROV = P.CLAVE ")
        query.Append("WHERE I.STATUS = 'A' AND (I.CVE_ART LIKE '%' + @BUSCAR + '%' OR I.DESCR LIKE '%' + @BUSCAR + '%')")

        Dim micomando As New SqlCommand(query.ToString, miconexion)
        miconexion.Open()
        micomando.Parameters.AddWithValue("@BUSCAR", BUSCAR)

        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        miconexion.Close()
        Return dt
    End Function

    Public Function listar_productosDIMOSA(ByVal BUSCAR As String) As DataTable
        Dim query As New StringBuilder
        Dim miconexion As New SqlConnection(conexion_consumo_dimosa.CadenaSQL)
        query.Append("SELECT I.CVE_ART AS 'CODIGO PRODUCTO', I.DESCR AS 'PRODUCTO', ")
        query.Append("P.CLAVE AS 'CODIGO PROVEEDOR', P.NOMBRE AS 'PROVEEDOR' ")
        query.Append("FROM INVE06 I FULL OUTER JOIN  PRVPROD06 PP ON PP.CVE_ART = I.CVE_ART  ")
        query.Append("FULL OUTER JOIN PROV06 P ON PP.CVE_PROV = P.CLAVE ")
        query.Append("WHERE I.STATUS = 'A' AND (I.CVE_ART LIKE '%' + @BUSCAR + '%' OR I.DESCR LIKE '%' + @BUSCAR + '%')")

        Dim micomando As New SqlCommand(query.ToString, miconexion)
        miconexion.Open()
        micomando.Parameters.AddWithValue("@BUSCAR", BUSCAR)

        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        miconexion.Close()
        Return dt
    End Function

    Public Function listar_productos_nota_credito_individual(ByVal BUSCAR As String) As DataTable
        Dim query As New StringBuilder
        Dim miconexion As New SqlConnection(conexion_consumo.CadenaSQL)
        query.Append("SELECT I.CVE_ART AS 'CODIGO PRODUCTO', I.DESCR AS 'PRODUCTO', ")
        query.Append("P.CLAVE AS 'CODIGO PROVEEDOR', P.NOMBRE AS 'PROVEEDOR', IMPUESTO4 AS 'IMPUESTO' ")
        query.Append("FROM INVE05 I FULL OUTER JOIN  PRVPROD05 PP ON PP.CVE_ART = I.CVE_ART INNER JOIN IMPU05 ISV ON ISV.CVE_ESQIMPU = I.CVE_ESQIMPU ")
        query.Append("FULL OUTER JOIN PROV05 P ON PP.CVE_PROV = P.CLAVE ")
        query.Append("WHERE I.STATUS = 'A' AND (I.CVE_ART LIKE '%' + @BUSCAR + '%' OR I.DESCR LIKE '%' + @BUSCAR + '%')")

        Dim micomando As New SqlCommand(query.ToString, miconexion)
        miconexion.Open()
        micomando.Parameters.AddWithValue("@BUSCAR", BUSCAR)

        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        miconexion.Close()
        Return dt
    End Function

    Public Function listar_productos_nota_credito_individualDIMOSA(ByVal BUSCAR As String) As DataTable
        Dim query As New StringBuilder
        Dim miconexion As New SqlConnection(conexion_consumo_dimosa.CadenaSQL)
        query.Append("SELECT I.CVE_ART AS 'CODIGO PRODUCTO', I.DESCR AS 'PRODUCTO', ")
        query.Append("P.CLAVE AS 'CODIGO PROVEEDOR', P.NOMBRE AS 'PROVEEDOR', IMPUESTO4 AS 'IMPUESTO' ")
        query.Append("FROM INVE06 I FULL OUTER JOIN  PRVPROD06 PP ON PP.CVE_ART = I.CVE_ART INNER JOIN IMPU06 ISV ON ISV.CVE_ESQIMPU = I.CVE_ESQIMPU ")
        query.Append("FULL OUTER JOIN PROV06 P ON PP.CVE_PROV = P.CLAVE ")
        query.Append("WHERE I.STATUS = 'A' AND (I.CVE_ART LIKE '%' + @BUSCAR + '%' OR I.DESCR LIKE '%' + @BUSCAR + '%')")

        Dim micomando As New SqlCommand(query.ToString, miconexion)
        miconexion.Open()
        micomando.Parameters.AddWithValue("@BUSCAR", BUSCAR)

        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        miconexion.Close()
        Return dt
    End Function


    Public Function listar_productos_nota_credito_individualopl(ByVal BUSCAR As String) As DataTable
        Dim query As New StringBuilder
        Dim miconexion As New SqlConnection(conexion_OPL.CadenaSQL)
        query.Append("SELECT I.CVE_ART AS 'CODIGO PRODUCTO', I.DESCR AS 'PRODUCTO', ")
        query.Append("P.CLAVE AS 'CODIGO PROVEEDOR', P.NOMBRE AS 'PROVEEDOR', IMPUESTO4 AS 'IMPUESTO' ")
        query.Append("FROM INVE08 I FULL OUTER JOIN  PRVPROD08 PP ON PP.CVE_ART = I.CVE_ART INNER JOIN IMPU08 ISV ON ISV.CVE_ESQIMPU = I.CVE_ESQIMPU ")
        query.Append("FULL OUTER JOIN PROV08 P ON PP.CVE_PROV = P.CLAVE ")
        query.Append("WHERE I.STATUS = 'A' AND (I.CVE_ART LIKE '%' + @BUSCAR + '%' OR I.DESCR LIKE '%' + @BUSCAR + '%')")

        Dim micomando As New SqlCommand(query.ToString, miconexion)
        miconexion.Open()
        micomando.Parameters.AddWithValue("@BUSCAR", BUSCAR)

        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        miconexion.Close()
        Return dt
    End Function

    Public Function Valor_Restante(ByVal PROVEEDOR As String, ByVal AÑO As Integer, ByVal MES As Integer) As Double
        Dim query As New StringBuilder
        query.Append("SELECT Restante ")
        query.Append("FROM presupuestos ")
        query.Append("WHERE (AñoId = @AÑO) AND (MesId = @MES) AND (ProveedorId = @PROVEEDOR) AND (Status = 'ALTA')")
        Dim miconexion As New SqlConnection(conexion.CadenaSQL)
        Dim micomando As New SqlCommand(query.ToString, miconexion)
        miconexion.Open()
        micomando.Parameters.AddWithValue("@AÑO", AÑO)
        micomando.Parameters.AddWithValue("@MES", MES)
        micomando.Parameters.AddWithValue("@PROVEEDOR", PROVEEDOR)

        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        miconexion.Close()
        Dim restante As Double = 0

        If dt.Rows.Count <= 0 Then
            restante = 0
        Else
            restante = dt.Rows(0)(0)
        End If
        Return restante
    End Function

    Public Function Valor_Restante_dimosa(ByVal PROVEEDOR As String, ByVal AÑO As Integer, ByVal MES As Integer) As Double
        Dim query As New StringBuilder
        query.Append("SELECT Restante ")
        query.Append("FROM presupuestos ")
        query.Append("WHERE (AñoId = @AÑO) AND (MesId = @MES) AND (ProveedorId = @PROVEEDOR) AND (Status = 'ALTA')")
        Dim miconexion As New SqlConnection(conexion_dimosa.CadenaSQL)
        Dim micomando As New SqlCommand(query.ToString, miconexion)
        miconexion.Open()
        micomando.Parameters.AddWithValue("@AÑO", AÑO)
        micomando.Parameters.AddWithValue("@MES", MES)
        micomando.Parameters.AddWithValue("@PROVEEDOR", PROVEEDOR)

        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        miconexion.Close()
        Dim restante As Double = 0

        If dt.Rows.Count <= 0 Then
            restante = 0
        Else
            restante = dt.Rows(0)(0)
        End If
        Return restante
    End Function

    Public Function Valor_Restante_opl(ByVal PROVEEDOR As String, ByVal AÑO As Integer, ByVal MES As Integer) As Double
        Dim query As New StringBuilder
        query.Append("SELECT Restante ")
        query.Append("FROM presupuestos ")
        query.Append("WHERE (AñoId = @AÑO) AND (MesId = @MES) AND (ProveedorId = @PROVEEDOR) AND (Status = 'ALTA')")
        Dim miconexion As New SqlConnection(conexion_Descuentos_Opl.CadenaSQL)
        Dim micomando As New SqlCommand(query.ToString, miconexion)
        miconexion.Open()
        micomando.Parameters.AddWithValue("@AÑO", AÑO)
        micomando.Parameters.AddWithValue("@MES", MES)
        micomando.Parameters.AddWithValue("@PROVEEDOR", PROVEEDOR)

        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        miconexion.Close()
        Dim restante As Double = 0

        If dt.Rows.Count <= 0 Then
            restante = 0
        Else
            restante = dt.Rows(0)(0)
        End If
        Return restante
    End Function

    Public Function guardar_datos_envio_sae(ByVal dt_encabezado As DataTable, ByVal dt_partida As DataTable, ByVal RFC As String, _
                    ByVal dt_parfactd As DataTable, ByVal sub_total As Double, ByVal tot_isv As Double, ByVal fecha_entrega As DateTime, ByVal fecha_doc As Date) As String
        Dim mitransacion As SqlTransaction
        Dim miconexion As New SqlConnection(conexion.CadenaSQL)
        Dim variable_error As String = ""
        miconexion.Open()
        mitransacion = miconexion.BeginTransaction
        Try
            Dim query_folios As New StringBuilder
            query_folios.Append("SELECT FOLIO + CONVERT(VARCHAR, ULT_DOC + 1) AS DOCTO, SERIE, TIPO ")
            query_folios.Append("FROM folios ")
            query_folios.Append("WHERE NUM_ALMA = @ALMACEN ")

            Dim comand_folio As New SqlCommand(query_folios.ToString, miconexion)
            comand_folio.Parameters.AddWithValue("@ALMACEN", dt_encabezado.Rows(0)(3))
            comand_folio.Transaction = mitransacion
            Dim adaptador_folios As New SqlDataAdapter(comand_folio)
            Dim dt_folios As New DataTable
            adaptador_folios.Fill(dt_folios)

            Dim docto As String
            Dim serie_local As String = ""
            Dim tipo_camplib20 As String = ""
            docto = dt_folios.Rows(0)(0)
            serie_local = dt_folios.Rows(0)(1)

            If dt_encabezado.Rows(0)(4) = "CREDITO" Then
                tipo_camplib20 = "N" + dt_folios.Rows(0)(2)
            Else
                tipo_camplib20 = "D" + dt_folios.Rows(0)(2)
            End If

            For i As Integer = 0 To dt_partida.Rows.Count - 1
                Dim query As New StringBuilder
                query.Append("UPDATE presupuestos ")
                query.Append("SET Restante = Restante - @VALOR ")
                query.Append("WHERE AñoId = @AÑO AND MesId = @MES AND ProveedorId = @PROVEEDOR")

                Dim micomando As New SqlCommand(query.ToString, miconexion)
                micomando.Parameters.AddWithValue("@VALOR", dt_partida.Rows(i)(3))
                micomando.Parameters.AddWithValue("@AÑO", Convert.ToDateTime(dt_encabezado.Rows(0)(7)).Year)
                micomando.Parameters.AddWithValue("@MES", Convert.ToDateTime(dt_encabezado.Rows(0)(7)).Month)
                micomando.Parameters.AddWithValue("@PROVEEDOR", dt_partida.Rows(i)(4))
                micomando.Transaction = mitransacion
                micomando.ExecuteNonQuery()

                Dim query3 As New StringBuilder
                query3.Append("INSERT INTO [tactical_discount_SanRafael].[dbo].[partidas] ")
                query3.Append("([CODIGO],[NUM_PART],[CVE_ART],[CANTIDAD],[MONTO],[PROVEEDOR],[CONCEPTO],[ISV],[SUBTOTAL],[CONCEPTO_PROVEEDOR]) ")
                query3.Append("VALUES(@CODIGO, @NUM_PART, @CVE_ART, @CANTIDAD, @MONTO,@PROVEEDOR,@CONCEPTO,@ISV,@SUBTOTAL,@CONCEPTO_PROVEEDOR) ")

                Dim micomando3 As New SqlCommand(query3.ToString, miconexion)
                micomando3.Parameters.AddWithValue("@CODIGO", docto)
                micomando3.Parameters.AddWithValue("@NUM_PART", dt_partida.Rows(i)(0))
                micomando3.Parameters.AddWithValue("@CVE_ART", dt_partida.Rows(i)(1))
                micomando3.Parameters.AddWithValue("@CANTIDAD", dt_partida.Rows(i)(2))
                micomando3.Parameters.AddWithValue("@MONTO", dt_partida.Rows(i)(3))
                micomando3.Parameters.AddWithValue("@PROVEEDOR", dt_partida.Rows(i)(4))
                micomando3.Parameters.AddWithValue("@CONCEPTO", dt_partida.Rows(i)(5))
                micomando3.Parameters.AddWithValue("@ISV", dt_partida.Rows(i)(6))
                micomando3.Parameters.AddWithValue("@SUBTOTAL", dt_partida.Rows(i)(7))
                micomando3.Parameters.AddWithValue("@CONCEPTO_PROVEEDOR", dt_partida.Rows(i)(8))
                micomando3.Transaction = mitransacion
                micomando3.ExecuteNonQuery()
            Next

            Dim upd_folios As New StringBuilder
            upd_folios.Append("UPDATE [folios]  ")
            upd_folios.Append("SET [ULT_DOC] = ULT_DOC + 1 ")
            upd_folios.Append("WHERE NUM_ALMA = @ALMACEN ")
            Dim comand_upd_folio As New SqlCommand(upd_folios.ToString, miconexion)
            comand_upd_folio.Parameters.AddWithValue("@ALMACEN", dt_encabezado.Rows(0)(3))
            comand_upd_folio.Transaction = mitransacion
            comand_upd_folio.ExecuteNonQuery()

            'ENVIO A SAE
            Dim _query_docto As New StringBuilder
            _query_docto.Append("SELECT SERIE,(ULT_DOC + 1)  ")
            _query_docto.Append("FROM [SAE60Empre05].[dbo].FOLIOSF05 ")
            _query_docto.Append("WHERE SERIE = @SERIE")
            Dim _cmd_docto As New SqlCommand(_query_docto.ToString, miconexion)
            _cmd_docto.Parameters.AddWithValue("@SERIE", serie_local)
            _cmd_docto.Transaction = mitransacion
            Dim adaptador_docto As New SqlDataAdapter(_cmd_docto)
            Dim dt_docto As New DataTable
            adaptador_docto.Fill(dt_docto)

            Dim serie As String = ""
            Dim ult_doc As Integer = 0
            Dim documento As String = ""
            serie = dt_docto.Rows(0)(0)
            ult_doc = dt_docto.Rows(0)(1)
            Dim ceros As String = ""
            For cont As Integer = 1 To 8 - Convert.ToString(ult_doc).Length
                ceros += "0"
            Next


            documento = serie + ceros + Convert.ToString(ult_doc)

            Dim _query_GETBITA As New StringBuilder
            _query_GETBITA.Append("SELECT ULT_CVE + 1   ")
            _query_GETBITA.Append("FROM [SAE60Empre05].[dbo].[TBLCONTROL05] ")
            _query_GETBITA.Append("WHERE ([ID_TABLA] = 62)")
            Dim _cmd_GETBITA As New SqlCommand(_query_GETBITA.ToString, miconexion)
            _cmd_GETBITA.Transaction = mitransacion
            Dim adaptador_BITA As New SqlDataAdapter(_cmd_GETBITA)
            Dim dt_GETBITA As New DataTable
            adaptador_BITA.Fill(dt_GETBITA)

            Dim _query_factd As New StringBuilder
            _query_factd.Append("INSERT INTO [SAE60Empre05].[dbo].[FACTD05] ")
            _query_factd.Append(" ([TIP_DOC],[CVE_DOC],[CVE_CLPV],[STATUS],[CVE_VEND],[CVE_PEDI] ")
            _query_factd.Append("  ,[FECHA_DOC],[FECHA_ENT],[FECHA_VEN],[CAN_TOT] ,[IMP_TOT1], [IMP_TOT2], ")
            _query_factd.Append("[IMP_TOT3],[IMP_TOT4],[DES_TOT],[DES_FIN],[COM_TOT] ,[CONDICION],[CVE_OBS], ")
            _query_factd.Append("[NUM_ALMA],[ACT_CXC],[ACT_COI],[ENLAZADO],[TIP_DOC_E],[NUM_MONED],[TIPCAMB], ")
            _query_factd.Append("[NUM_PAGOS],[FECHAELAB],[PRIMERPAGO],[RFC],[CTLPOL],[ESCFD],[AUTORIZA],[SERIE], ")
            _query_factd.Append("[FOLIO],[AUTOANIO],[DAT_ENVIO],[CONTADO],[DAT_MOSTR],[CVE_BITA],[BLOQ],[FORMAENVIO], ")
            _query_factd.Append("[DES_FIN_PORC],[DES_TOT_PORC],[IMPORTE],[TIP_DOC_ANT],[DOC_ANT]) ")
            _query_factd.Append("VALUES ")
            _query_factd.Append("('D',@CVE_DOC,@CVE_CLPV,'O',@CVE_VEND,0,@FECHA_DOC,@FECHA_ENT,@FECHA_VEN, @CAN_TOT, ")
            _query_factd.Append("0,0,0,@IMP_TOT4,0,0,0,0,0, @NUM_ALMA,'S','N','O','F',1,1,1,@FECHAELAB,0,@RFC, ")
            _query_factd.Append("0,'N',@AUTORIZA,@SERIE,@FOLIO,@AUTOANIO,0,'N',0,@CVE_BITA,'N',0,0,0,@IMPORTE, ")
            _query_factd.Append("'F', @DOC_ANT)")

            Dim cmd_factd As New SqlCommand(_query_factd.ToString, miconexion)
            cmd_factd.Parameters.AddWithValue("@CVE_DOC", documento)
            cmd_factd.Parameters.AddWithValue("@CVE_CLPV", dt_encabezado.Rows(0)(2))
            cmd_factd.Parameters.AddWithValue("@CVE_VEND", dt_encabezado.Rows(0)(0))
            cmd_factd.Parameters.AddWithValue("@FECHA_DOC", fecha_doc)
            cmd_factd.Parameters.AddWithValue("@FECHA_ENT", fecha_entrega)
            cmd_factd.Parameters.AddWithValue("@FECHA_VEN", fecha_doc)
            cmd_factd.Parameters.AddWithValue("@CAN_TOT", sub_total)
            cmd_factd.Parameters.AddWithValue("@IMP_TOT4", tot_isv)
            cmd_factd.Parameters.AddWithValue("@NUM_ALMA", dt_encabezado.Rows(0)(3))
            cmd_factd.Parameters.AddWithValue("@FECHAELAB", Now.Date)
            cmd_factd.Parameters.AddWithValue("@RFC", RFC)
            cmd_factd.Parameters.AddWithValue("@AUTORIZA", Convert.ToDateTime(dt_encabezado.Rows(0)(7)).Year)
            cmd_factd.Parameters.AddWithValue("@SERIE", serie)
            cmd_factd.Parameters.AddWithValue("@FOLIO", ult_doc)
            cmd_factd.Parameters.AddWithValue("@AUTOANIO", Convert.ToDateTime(dt_encabezado.Rows(0)(7)).Year)
            cmd_factd.Parameters.AddWithValue("@CVE_BITA", dt_GETBITA.Rows(0)(0))
            cmd_factd.Parameters.AddWithValue("@IMPORTE", Convert.ToDouble(dt_encabezado.Rows(0)(5)))
            cmd_factd.Parameters.AddWithValue("@DOC_ANT", dt_encabezado.Rows(0)(1))
            cmd_factd.Transaction = mitransacion
            cmd_factd.ExecuteNonQuery()

            Dim query2 As New StringBuilder
            query2.Append("INSERT INTO [tactical_discount_SanRafael].[dbo].[encabezados] ")
            query2.Append("([CODIGO],[VENDEDOR],[FACTURA],[CLIENTE],[ALMACEN],[TIPO],[IMPORTE], ")
            query2.Append("[ESTADO],[FECHA],[FECHA_SAE],[RFC],[FECHA_ENTREGA],[CAMPLIB20],[DOC_NC]) ")
            query2.Append("VALUES (@CODIGO,@VENDEDOR,@FACTURA,@CLIENTE,@ALMACEN,@TIPO,@IMPORTE, ")
            query2.Append("@ESTADO,@FECHA,@FECHA_SAE,@RFC,@FECHA_ENTREGA,@CAMPLIB20,@DOC_NC) ")
            Dim micomando2 As New SqlCommand(query2.ToString, miconexion)
            micomando2.Parameters.AddWithValue("@CODIGO", docto)
            micomando2.Parameters.AddWithValue("@VENDEDOR", dt_encabezado.Rows(0)(0))
            micomando2.Parameters.AddWithValue("@FACTURA", dt_encabezado.Rows(0)(1))
            micomando2.Parameters.AddWithValue("@CLIENTE", dt_encabezado.Rows(0)(2))
            micomando2.Parameters.AddWithValue("@ALMACEN", dt_encabezado.Rows(0)(3))
            micomando2.Parameters.AddWithValue("@TIPO", dt_encabezado.Rows(0)(4))
            micomando2.Parameters.AddWithValue("@IMPORTE", dt_encabezado.Rows(0)(5))
            micomando2.Parameters.AddWithValue("@ESTADO", "ENVIADO")
            micomando2.Parameters.AddWithValue("@FECHA", Convert.ToDateTime(dt_encabezado.Rows(0)(7)).Date)
            micomando2.Parameters.AddWithValue("@FECHA_SAE", fecha_doc)
            micomando2.Parameters.AddWithValue("@RFC", RFC)
            micomando2.Parameters.AddWithValue("@FECHA_ENTREGA", fecha_entrega)
            micomando2.Parameters.AddWithValue("@CAMPLIB20", tipo_camplib20)
            micomando2.Parameters.AddWithValue("@DOC_NC", documento)
            micomando2.Transaction = mitransacion
            micomando2.ExecuteNonQuery()

            Dim _query_ins_bita As New StringBuilder
            _query_ins_bita.Append("INSERT INTO [SAE60Empre05].[dbo].[BITA05]  ")
            _query_ins_bita.Append("(CVE_BITA,[CVE_CLIE],[CVE_CAMPANIA],[CVE_ACTIVIDAD] ")
            _query_ins_bita.Append(",[FECHAHORA],[CVE_USUARIO],[OBSERVACIONES],[STATUS],[NOM_USUARIO]) ")
            _query_ins_bita.Append("VALUES ")
            _query_ins_bita.Append("(@CVE_BITA,@CVE_CLIE,@CVE_CAMPANIA,@CVE_ACTIVIDAD,@FECHAHORA ")
            _query_ins_bita.Append(",@CVE_USUARIO,@OBSERVACIONES,@STATUS,@NOM_USUARIO) ")
            Dim _cmd_ins_bita As New SqlCommand(_query_ins_bita.ToString, miconexion)

            _cmd_ins_bita.Parameters.AddWithValue("@CVE_BITA", dt_GETBITA.Rows(0)(0))
            _cmd_ins_bita.Parameters.AddWithValue("@CVE_CLIE", dt_encabezado.Rows(0)(2))
            _cmd_ins_bita.Parameters.AddWithValue("@CVE_CAMPANIA", "_SAE_")
            _cmd_ins_bita.Parameters.AddWithValue("@CVE_ACTIVIDAD", "    6")
            _cmd_ins_bita.Parameters.AddWithValue("@FECHAHORA", DateTime.Now)
            _cmd_ins_bita.Parameters.AddWithValue("@CVE_USUARIO", 0)
            _cmd_ins_bita.Parameters.AddWithValue("@OBSERVACIONES", "No.[" & documento & "] L " & Convert.ToDouble(dt_encabezado.Rows(0)(5)))
            _cmd_ins_bita.Parameters.AddWithValue("@STATUS", "F")
            _cmd_ins_bita.Parameters.AddWithValue("@NOM_USUARIO", "nc-rpt")
            _cmd_ins_bita.Transaction = mitransacion
            _cmd_ins_bita.ExecuteNonQuery()

            Dim _query_factd_clib As New StringBuilder
            _query_factd_clib.Append("INSERT INTO [SAE60Empre05].[dbo].[FACTD_CLIB05] ")
            _query_factd_clib.Append("([CLAVE_DOC],[CAMPLIB20]) ")
            _query_factd_clib.Append("VALUES(@CLAVE_DOC, @CAMPLIB20) ")
            Dim _cmd_factd_clib As New SqlCommand(_query_factd_clib.ToString, miconexion)
            _cmd_factd_clib.Parameters.AddWithValue("@CLAVE_DOC", documento)
            _cmd_factd_clib.Parameters.AddWithValue("@CAMPLIB20", tipo_camplib20)
            _cmd_factd_clib.Transaction = mitransacion
            _cmd_factd_clib.ExecuteNonQuery()

            Dim _query_clie As New StringBuilder
            _query_clie.Append("UPDATE [SAE60Empre05].[dbo].[CLIE05] ")
            _query_clie.Append("SET [SALDO] = SALDO - @VALOR ")
            _query_clie.Append("WHERE ([CLAVE] = @CLAVE)")
            Dim _cmd_clie As New SqlCommand(_query_clie.ToString, miconexion)
            _cmd_clie.Parameters.AddWithValue("@VALOR", dt_encabezado.Rows(0)(5))
            _cmd_clie.Parameters.AddWithValue("@CLAVE", dt_encabezado.Rows(0)(2))
            _cmd_clie.Transaction = mitransacion
            _cmd_clie.ExecuteNonQuery()

            Dim _query_cuendet As New StringBuilder
            _query_cuendet.Append("INSERT INTO [SAE60Empre05].[dbo].[CUEN_DET05] ")
            _query_cuendet.Append("([CVE_CLIE],[REFER],[ID_MOV],[NUM_CPTO],[NUM_CARGO] ")
            _query_cuendet.Append(",[CVE_OBS],[NO_FACTURA],[DOCTO],[IMPORTE],[FECHA_APLI],[FECHA_VENC] ")
            _query_cuendet.Append(",[STRCVEVEND],[NUM_MONED],[TCAMBIO],[IMPMON_EXT],[FECHAELAB] ")
            _query_cuendet.Append(",[TIPO_MOV],[SIGNO],[USUARIO] ")
            _query_cuendet.Append(",[NO_PARTIDA],[AFEC_COI]) ")
            _query_cuendet.Append(" VALUES ")
            _query_cuendet.Append("(@CVE_CLIE,@REFER,1,12,1,0,@NO_FACTURA,@DOCTO ")
            _query_cuendet.Append(",@IMPORTE,@FECHA_APLI,@FECHA_VENC,@STRCVEVEND,1,1, ")
            _query_cuendet.Append(" @IMPMON_EXT, @FECHAELAB, 'A', -1,0,1,'A')")

            Dim _cmd_cuendet As New SqlCommand(_query_cuendet.ToString, miconexion)
            _cmd_cuendet.Parameters.AddWithValue("@CVE_CLIE", dt_encabezado.Rows(0)(2))
            _cmd_cuendet.Parameters.AddWithValue("@REFER", dt_encabezado.Rows(0)(1))
            _cmd_cuendet.Parameters.AddWithValue("@NO_FACTURA", dt_encabezado.Rows(0)(1))
            _cmd_cuendet.Parameters.AddWithValue("@DOCTO", documento)
            _cmd_cuendet.Parameters.AddWithValue("@IMPORTE", dt_encabezado.Rows(0)(5))
            _cmd_cuendet.Parameters.AddWithValue("@FECHA_APLI", fecha_doc)
            _cmd_cuendet.Parameters.AddWithValue("@FECHA_VENC", fecha_doc)
            _cmd_cuendet.Parameters.AddWithValue("@STRCVEVEND", dt_encabezado.Rows(0)(0))
            _cmd_cuendet.Parameters.AddWithValue("@IMPMON_EXT", dt_encabezado.Rows(0)(5))
            _cmd_cuendet.Parameters.AddWithValue("@FECHAELAB", Now.Date)
            _cmd_cuendet.Transaction = mitransacion
            _cmd_cuendet.ExecuteNonQuery()

            If dt_encabezado.Rows(0)(4) = "CONTADO" Then
                Dim _query_clie_CARGOXDEV As New StringBuilder
                _query_clie_CARGOXDEV.Append("UPDATE [SAE60Empre05].[dbo].[CLIE05] ")
                _query_clie_CARGOXDEV.Append("SET [SALDO] = SALDO + @VALOR ")
                _query_clie_CARGOXDEV.Append("WHERE ([CLAVE] = @CLAVE)")
                Dim _cmd_clie_CARGOXDEV As New SqlCommand(_query_clie_CARGOXDEV.ToString, miconexion)
                _cmd_clie_CARGOXDEV.Parameters.AddWithValue("@VALOR", dt_encabezado.Rows(0)(5))
                _cmd_clie_CARGOXDEV.Parameters.AddWithValue("@CLAVE", dt_encabezado.Rows(0)(2))
                _cmd_clie_CARGOXDEV.Transaction = mitransacion
                _cmd_clie_CARGOXDEV.ExecuteNonQuery()

                Dim _query_cuendet_CARGOXDEV As New StringBuilder
                _query_cuendet_CARGOXDEV.Append("INSERT INTO [SAE60Empre05].[dbo].[CUEN_DET05] ")
                _query_cuendet_CARGOXDEV.Append("([CVE_CLIE],[REFER],[ID_MOV],[NUM_CPTO],[NUM_CARGO] ")
                _query_cuendet_CARGOXDEV.Append(",[CVE_OBS],[NO_FACTURA],[DOCTO],[IMPORTE],[FECHA_APLI],[FECHA_VENC] ")
                _query_cuendet_CARGOXDEV.Append(",[STRCVEVEND],[NUM_MONED],[TCAMBIO],[IMPMON_EXT],[FECHAELAB] ")
                _query_cuendet_CARGOXDEV.Append(",[TIPO_MOV],[SIGNO],[USUARIO] ")
                _query_cuendet_CARGOXDEV.Append(",[NO_PARTIDA],[AFEC_COI]) ")
                _query_cuendet_CARGOXDEV.Append(" VALUES ")
                _query_cuendet_CARGOXDEV.Append("(@CVE_CLIE,@REFER,1,31,1,0,@NO_FACTURA,@DOCTO ")
                _query_cuendet_CARGOXDEV.Append(",@IMPORTE,@FECHA_APLI,@FECHA_VENC,@STRCVEVEND,1,1, ")
                _query_cuendet_CARGOXDEV.Append(" @IMPMON_EXT, @FECHAELAB, 'C', 1,0,2,'')")

                Dim _cmd_cuendet_CARGOXDEV As New SqlCommand(_query_cuendet_CARGOXDEV.ToString, miconexion)
                _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@CVE_CLIE", dt_encabezado.Rows(0)(2))
                _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@REFER", dt_encabezado.Rows(0)(1))
                _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@NO_FACTURA", dt_encabezado.Rows(0)(1))
                _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@DOCTO", documento) '"NC" & ult_doc)
                _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@IMPORTE", dt_encabezado.Rows(0)(5))
                _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@FECHA_APLI", fecha_doc)
                _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@FECHA_VENC", fecha_doc)
                _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@STRCVEVEND", dt_encabezado.Rows(0)(0))
                _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@IMPMON_EXT", dt_encabezado.Rows(0)(5))
                _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@FECHAELAB", Now.Date)
                _cmd_cuendet_CARGOXDEV.Transaction = mitransacion
                _cmd_cuendet_CARGOXDEV.ExecuteNonQuery()

                Dim _query_ins_bita_cargoxdev As New StringBuilder
                _query_ins_bita_cargoxdev.Append("INSERT INTO [SAE60Empre05].[dbo].[BITA05]  ")
                _query_ins_bita_cargoxdev.Append("(CVE_BITA,[CVE_CLIE],[CVE_CAMPANIA],[CVE_ACTIVIDAD] ")
                _query_ins_bita_cargoxdev.Append(",[FECHAHORA],[CVE_USUARIO],[OBSERVACIONES],[STATUS],[NOM_USUARIO]) ")
                _query_ins_bita_cargoxdev.Append("VALUES ")
                _query_ins_bita_cargoxdev.Append("(@CVE_BITA,@CVE_CLIE,@CVE_CAMPANIA,@CVE_ACTIVIDAD,@FECHAHORA ")
                _query_ins_bita_cargoxdev.Append(",@CVE_USUARIO,@OBSERVACIONES,@STATUS,@NOM_USUARIO) ")
                Dim _cmd_ins_bita_cargoxdev As New SqlCommand(_query_ins_bita_cargoxdev.ToString, miconexion)

                _cmd_ins_bita_cargoxdev.Parameters.AddWithValue("@CVE_BITA", dt_GETBITA.Rows(0)(0) + 1)
                _cmd_ins_bita_cargoxdev.Parameters.AddWithValue("@CVE_CLIE", dt_encabezado.Rows(0)(2))
                _cmd_ins_bita_cargoxdev.Parameters.AddWithValue("@CVE_CAMPANIA", "_SAE_")
                _cmd_ins_bita_cargoxdev.Parameters.AddWithValue("@CVE_ACTIVIDAD", "   12")
                _cmd_ins_bita_cargoxdev.Parameters.AddWithValue("@FECHAHORA", DateTime.Now)
                _cmd_ins_bita_cargoxdev.Parameters.AddWithValue("@CVE_USUARIO", 0)
                _cmd_ins_bita_cargoxdev.Parameters.AddWithValue("@OBSERVACIONES", "No.[] L " & Convert.ToDouble(dt_encabezado.Rows(0)(5)))
                _cmd_ins_bita_cargoxdev.Parameters.AddWithValue("@STATUS", "F")
                _cmd_ins_bita_cargoxdev.Parameters.AddWithValue("@NOM_USUARIO", "nc-rpt")
                _cmd_ins_bita_cargoxdev.Transaction = mitransacion
                _cmd_ins_bita_cargoxdev.ExecuteNonQuery()

                Dim _query_control2_cargoxdev As New StringBuilder
                _query_control2_cargoxdev.Append("UPDATE [SAE60Empre05].[dbo].[TBLCONTROL05] ")
                _query_control2_cargoxdev.Append(" SET [ULT_CVE] = ULT_CVE + 1 ")
                _query_control2_cargoxdev.Append("WHERE [ID_TABLA] = 62 ")
                Dim _cmd_control2_cargoxdev As New SqlCommand(_query_control2_cargoxdev.ToString, miconexion)
                _cmd_control2_cargoxdev.Transaction = mitransacion
                _cmd_control2_cargoxdev.ExecuteNonQuery()
            End If

            'PARTIDAS DEL DOCUMENTO
            For index As Integer = 0 To dt_parfactd.Rows.Count - 1
                'debe ir en cada partida
                Dim _query_doctosig As New StringBuilder

                _query_doctosig.Append("INSERT INTO [SAE60Empre05].[dbo].[DOCTOSIGF05] ")
                _query_doctosig.Append("([TIP_DOC],[CVE_DOC],[ANT_SIG],[TIP_DOC_E] ")
                _query_doctosig.Append(",[CVE_DOC_E],[PARTIDA],[PART_E],[CANT_E]) ")
                _query_doctosig.Append("VALUES ")
                _query_doctosig.Append("('D',@CVE_DOC,'A', 'F',@CVE_DOC_E,@PARTIDA,0,0)")
                Dim _cmd_doctosig As New SqlCommand(_query_doctosig.ToString, miconexion)
                _cmd_doctosig.Parameters.AddWithValue("@CVE_DOC", documento)
                _cmd_doctosig.Parameters.AddWithValue("@CVE_DOC_E", dt_encabezado.Rows(0)(1))
                _cmd_doctosig.Parameters.AddWithValue("@PARTIDA", index + 1)
                _cmd_doctosig.Transaction = mitransacion
                _cmd_doctosig.ExecuteNonQuery()

                Dim _query_par_factd As New StringBuilder
                _query_par_factd.Append("INSERT INTO [SAE60Empre05].[dbo].[PAR_FACTD05] ")
                _query_par_factd.Append("           ([CVE_DOC],[NUM_PAR],[CVE_ART],[CANT],[PXS],[PREC] ")
                _query_par_factd.Append("           ,[COST],[IMPU1],[IMPU2],[IMPU3],[IMPU4],[IMP1APLA] ")
                _query_par_factd.Append("           ,[IMP2APLA],[IMP3APLA],[IMP4APLA],[TOTIMP1],[TOTIMP2] ")
                _query_par_factd.Append("           ,[TOTIMP3],[TOTIMP4],[DESC1],[DESC2],[DESC3],[COMI] ")
                _query_par_factd.Append("           ,[APAR],[ACT_INV],[NUM_ALM],[TIP_CAM] ")
                _query_par_factd.Append("           ,[UNI_VENTA],[TIPO_PROD],[CVE_OBS],[REG_SERIE],[E_LTPD] ")
                _query_par_factd.Append("           ,[TIPO_ELEM],[NUM_MOV],[TOT_PARTIDA],[IMPRIMIR]) ")
                _query_par_factd.Append("VALUES    (@CVE_DOC,@NUM_PAR,@CVE_ART,@CANT,@PXS,@PREC,0,0,0, ")
                _query_par_factd.Append("           0,@IMPU4,0,0,0,0,0, 0,0,@TOTIMP4,0,0,0,0,0,'S',@NUM_ALM, ")
                _query_par_factd.Append("           1,@UNI_VENTA,'S',0,0,0,'N',0,@TOT_PARTIDA,'S')")
                Dim _cmd_par_factd As New SqlCommand(_query_par_factd.ToString, miconexion)
                _cmd_par_factd.Parameters.AddWithValue("@CVE_DOC", documento)
                _cmd_par_factd.Parameters.AddWithValue("@NUM_PAR", index + 1)
                _cmd_par_factd.Parameters.AddWithValue("@CVE_ART", dt_parfactd.Rows(index)(0))
                _cmd_par_factd.Parameters.AddWithValue("@CANT", dt_parfactd.Rows(index)(1))
                _cmd_par_factd.Parameters.AddWithValue("@PXS", dt_parfactd.Rows(index)(2))
                _cmd_par_factd.Parameters.AddWithValue("@PREC", dt_parfactd.Rows(index)(3))
                _cmd_par_factd.Parameters.AddWithValue("@IMPU4", dt_parfactd.Rows(index)(4))
                _cmd_par_factd.Parameters.AddWithValue("@TOTIMP4", dt_parfactd.Rows(index)(5))
                _cmd_par_factd.Parameters.AddWithValue("@NUM_ALM", dt_encabezado.Rows(0)(3))
                _cmd_par_factd.Parameters.AddWithValue("@UNI_VENTA", dt_parfactd.Rows(index)(6))
                _cmd_par_factd.Parameters.AddWithValue("@TOT_PARTIDA", dt_parfactd.Rows(index)(7))
                _cmd_par_factd.Transaction = mitransacion
                _cmd_par_factd.ExecuteNonQuery()

                Dim _query_par_factd_clib As New StringBuilder
                _query_par_factd_clib.Append("INSERT INTO [SAE60Empre05].[dbo].[PAR_FACTD_CLIB05] ")
                _query_par_factd_clib.Append("([CLAVE_DOC],[NUM_PART]) ")
                _query_par_factd_clib.Append("VALUES(@CLAVE_DOC, @NUM_PART)")
                Dim _cmd_par_factd_clib As New SqlCommand(_query_par_factd_clib.ToString, miconexion)
                _cmd_par_factd_clib.Parameters.AddWithValue("@CLAVE_DOC", documento)
                _cmd_par_factd_clib.Parameters.AddWithValue("@NUM_PART", index + 1)
                _cmd_par_factd_clib.Transaction = mitransacion
                _cmd_par_factd_clib.ExecuteNonQuery()
            Next

            Dim _query_control1 As New StringBuilder
            _query_control1.Append("UPDATE [SAE60Empre05].[dbo].[TBLCONTROL05] ")
            _query_control1.Append(" SET [ULT_CVE] = ULT_CVE + 1 ")
            _query_control1.Append("WHERE [ID_TABLA] = 32 ")
            Dim _cmd_control1 As New SqlCommand(_query_control1.ToString, miconexion)
            _cmd_control1.Transaction = mitransacion
            _cmd_control1.ExecuteNonQuery()

            Dim _query_control2 As New StringBuilder
            _query_control2.Append("UPDATE [SAE60Empre05].[dbo].[TBLCONTROL05] ")
            _query_control2.Append(" SET [ULT_CVE] = ULT_CVE + 1 ")
            _query_control2.Append("WHERE [ID_TABLA] = 62 ")
            Dim _cmd_control2 As New SqlCommand(_query_control2.ToString, miconexion)
            _cmd_control2.Transaction = mitransacion
            _cmd_control2.ExecuteNonQuery()

            Dim _query_foliosf As New StringBuilder
            _query_foliosf.Append("UPDATE [SAE60Empre05].[dbo].[FOLIOSF05] ")
            _query_foliosf.Append(" SET [ULT_DOC] = ULT_DOC +1 ")
            _query_foliosf.Append("WHERE [SERIE] = @SERIE")
            Dim _cmd_foliosf As New SqlCommand(_query_foliosf.ToString, miconexion)
            _cmd_foliosf.Parameters.AddWithValue("@SERIE", serie)
            _cmd_foliosf.Transaction = mitransacion
            _cmd_foliosf.ExecuteNonQuery()

            mitransacion.Commit()
            miconexion.Close()
            variable_error = "correcto"

        Catch ex As Exception
            mitransacion.Rollback()
            miconexion.Close()
            variable_error = ex.Message
        End Try

        Return variable_error
    End Function

    Public Function guardar_datos_envio_sae_dimosa(ByVal dt_encabezado As DataTable, ByVal dt_partida As DataTable, ByVal RFC As String, _
                    ByVal dt_parfactd As DataTable, ByVal sub_total As Double, ByVal tot_isv As Double, ByVal fecha_entrega As DateTime, ByVal fecha_doc As Date) As String
        Dim mitransacion As SqlTransaction
        Dim miconexion As New SqlConnection(conexion_dimosa.CadenaSQL)
        Dim variable_error As String = ""
        miconexion.Open()
        mitransacion = miconexion.BeginTransaction
        Try
            Dim query_folios As New StringBuilder
            query_folios.Append("SELECT FOLIO + CONVERT(VARCHAR, ULT_DOC + 1) AS DOCTO, SERIE, TIPO ")
            query_folios.Append("FROM folios ")
            query_folios.Append("WHERE NUM_ALMA = @ALMACEN ")

            Dim comand_folio As New SqlCommand(query_folios.ToString, miconexion)
            comand_folio.Parameters.AddWithValue("@ALMACEN", dt_encabezado.Rows(0)(3))
            comand_folio.Transaction = mitransacion
            Dim adaptador_folios As New SqlDataAdapter(comand_folio)
            Dim dt_folios As New DataTable
            adaptador_folios.Fill(dt_folios)

            Dim docto As String
            Dim serie_local As String = ""
            Dim tipo_camplib20 As String = ""
            docto = dt_folios.Rows(0)(0)
            serie_local = dt_folios.Rows(0)(1)

            If dt_encabezado.Rows(0)(4) = "CREDITO" Then
                tipo_camplib20 = "N" + dt_folios.Rows(0)(2)
            Else
                tipo_camplib20 = "D" + dt_folios.Rows(0)(2)
            End If

            For i As Integer = 0 To dt_partida.Rows.Count - 1
                Dim query As New StringBuilder
                query.Append("UPDATE presupuestos ")
                query.Append("SET Restante = Restante - @VALOR ")
                query.Append("WHERE AñoId = @AÑO AND MesId = @MES AND ProveedorId = @PROVEEDOR")

                Dim micomando As New SqlCommand(query.ToString, miconexion)
                micomando.Parameters.AddWithValue("@VALOR", dt_partida.Rows(i)(3))
                micomando.Parameters.AddWithValue("@AÑO", Convert.ToDateTime(dt_encabezado.Rows(0)(7)).Year)
                micomando.Parameters.AddWithValue("@MES", Convert.ToDateTime(dt_encabezado.Rows(0)(7)).Month)
                micomando.Parameters.AddWithValue("@PROVEEDOR", dt_partida.Rows(i)(4))
                micomando.Transaction = mitransacion
                micomando.ExecuteNonQuery()

                Dim query3 As New StringBuilder
                query3.Append("INSERT INTO [tactical_discount_dimosa].[dbo].[partidas] ")
                query3.Append("([CODIGO],[NUM_PART],[CVE_ART],[CANTIDAD],[MONTO],[PROVEEDOR],[CONCEPTO],[ISV],[SUBTOTAL],[CONCEPTO_PROVEEDOR]) ")
                query3.Append("VALUES(@CODIGO, @NUM_PART, @CVE_ART, @CANTIDAD, @MONTO,@PROVEEDOR,@CONCEPTO,@ISV,@SUBTOTAL,@CONCEPTO_PROVEEDOR) ")

                Dim micomando3 As New SqlCommand(query3.ToString, miconexion)
                micomando3.Parameters.AddWithValue("@CODIGO", docto)
                micomando3.Parameters.AddWithValue("@NUM_PART", dt_partida.Rows(i)(0))
                micomando3.Parameters.AddWithValue("@CVE_ART", dt_partida.Rows(i)(1))
                micomando3.Parameters.AddWithValue("@CANTIDAD", dt_partida.Rows(i)(2))
                micomando3.Parameters.AddWithValue("@MONTO", dt_partida.Rows(i)(3))
                micomando3.Parameters.AddWithValue("@PROVEEDOR", dt_partida.Rows(i)(4))
                micomando3.Parameters.AddWithValue("@CONCEPTO", dt_partida.Rows(i)(5))
                micomando3.Parameters.AddWithValue("@ISV", dt_partida.Rows(i)(6))
                micomando3.Parameters.AddWithValue("@SUBTOTAL", dt_partida.Rows(i)(7))
                micomando3.Parameters.AddWithValue("@CONCEPTO_PROVEEDOR", dt_partida.Rows(i)(8))
                micomando3.Transaction = mitransacion
                micomando3.ExecuteNonQuery()
            Next

            Dim upd_folios As New StringBuilder
            upd_folios.Append("UPDATE [folios]  ")
            upd_folios.Append("SET [ULT_DOC] = ULT_DOC + 1 ")
            upd_folios.Append("WHERE NUM_ALMA = @ALMACEN ")
            Dim comand_upd_folio As New SqlCommand(upd_folios.ToString, miconexion)
            comand_upd_folio.Parameters.AddWithValue("@ALMACEN", dt_encabezado.Rows(0)(3))
            comand_upd_folio.Transaction = mitransacion
            comand_upd_folio.ExecuteNonQuery()

            'ENVIO A SAE
            Dim _query_docto As New StringBuilder
            _query_docto.Append("SELECT SERIE,(ULT_DOC + 1)  ")
            _query_docto.Append("FROM [SAE60Empre06].[dbo].FOLIOSF06 ")
            _query_docto.Append("WHERE SERIE = @SERIE")
            Dim _cmd_docto As New SqlCommand(_query_docto.ToString, miconexion)
            _cmd_docto.Parameters.AddWithValue("@SERIE", serie_local)
            _cmd_docto.Transaction = mitransacion
            Dim adaptador_docto As New SqlDataAdapter(_cmd_docto)
            Dim dt_docto As New DataTable
            adaptador_docto.Fill(dt_docto)

            Dim serie As String = ""
            Dim ult_doc As Integer = 0
            Dim documento As String = ""
            serie = dt_docto.Rows(0)(0)
            ult_doc = dt_docto.Rows(0)(1)
            Dim ceros As String = ""
            For cont As Integer = 1 To 8 - Convert.ToString(ult_doc).Length
                ceros += "0"
            Next


            documento = serie + ceros + Convert.ToString(ult_doc)

            Dim _query_GETBITA As New StringBuilder
            _query_GETBITA.Append("SELECT ULT_CVE + 1   ")
            _query_GETBITA.Append("FROM [SAE60Empre06].[dbo].[TBLCONTROL06] ")
            _query_GETBITA.Append("WHERE ([ID_TABLA] = 62)")
            Dim _cmd_GETBITA As New SqlCommand(_query_GETBITA.ToString, miconexion)
            _cmd_GETBITA.Transaction = mitransacion
            Dim adaptador_BITA As New SqlDataAdapter(_cmd_GETBITA)
            Dim dt_GETBITA As New DataTable
            adaptador_BITA.Fill(dt_GETBITA)

            Dim _query_factd As New StringBuilder
            _query_factd.Append("INSERT INTO [SAE60Empre06].[dbo].[FACTD06] ")
            _query_factd.Append(" ([TIP_DOC],[CVE_DOC],[CVE_CLPV],[STATUS],[CVE_VEND],[CVE_PEDI] ")
            _query_factd.Append("  ,[FECHA_DOC],[FECHA_ENT],[FECHA_VEN],[CAN_TOT] ,[IMP_TOT1], [IMP_TOT2], ")
            _query_factd.Append("[IMP_TOT3],[IMP_TOT4],[DES_TOT],[DES_FIN],[COM_TOT] ,[CONDICION],[CVE_OBS], ")
            _query_factd.Append("[NUM_ALMA],[ACT_CXC],[ACT_COI],[ENLAZADO],[TIP_DOC_E],[NUM_MONED],[TIPCAMB], ")
            _query_factd.Append("[NUM_PAGOS],[FECHAELAB],[PRIMERPAGO],[RFC],[CTLPOL],[ESCFD],[AUTORIZA],[SERIE], ")
            _query_factd.Append("[FOLIO],[AUTOANIO],[DAT_ENVIO],[CONTADO],[DAT_MOSTR],[CVE_BITA],[BLOQ],[FORMAENVIO], ")
            _query_factd.Append("[DES_FIN_PORC],[DES_TOT_PORC],[IMPORTE],[TIP_DOC_ANT],[DOC_ANT]) ")
            _query_factd.Append("VALUES ")
            _query_factd.Append("('D',@CVE_DOC,@CVE_CLPV,'O',@CVE_VEND,0,@FECHA_DOC,@FECHA_ENT,@FECHA_VEN, @CAN_TOT, ")
            _query_factd.Append("0,0,0,@IMP_TOT4,0,0,0,0,0, @NUM_ALMA,'S','N','O','F',1,1,1,@FECHAELAB,0,@RFC, ")
            _query_factd.Append("0,'N',@AUTORIZA,@SERIE,@FOLIO,@AUTOANIO,0,'N',0,@CVE_BITA,'N',0,0,0,@IMPORTE, ")
            _query_factd.Append("'F', @DOC_ANT)")

            Dim cmd_factd As New SqlCommand(_query_factd.ToString, miconexion)
            cmd_factd.Parameters.AddWithValue("@CVE_DOC", documento)
            cmd_factd.Parameters.AddWithValue("@CVE_CLPV", dt_encabezado.Rows(0)(2))
            cmd_factd.Parameters.AddWithValue("@CVE_VEND", dt_encabezado.Rows(0)(0))
            cmd_factd.Parameters.AddWithValue("@FECHA_DOC", fecha_doc)
            cmd_factd.Parameters.AddWithValue("@FECHA_ENT", fecha_entrega)
            cmd_factd.Parameters.AddWithValue("@FECHA_VEN", fecha_doc)
            cmd_factd.Parameters.AddWithValue("@CAN_TOT", sub_total)
            cmd_factd.Parameters.AddWithValue("@IMP_TOT4", tot_isv)
            cmd_factd.Parameters.AddWithValue("@NUM_ALMA", dt_encabezado.Rows(0)(3))
            cmd_factd.Parameters.AddWithValue("@FECHAELAB", Now.Date)
            cmd_factd.Parameters.AddWithValue("@RFC", RFC)
            cmd_factd.Parameters.AddWithValue("@AUTORIZA", Convert.ToDateTime(dt_encabezado.Rows(0)(7)).Year)
            cmd_factd.Parameters.AddWithValue("@SERIE", serie)
            cmd_factd.Parameters.AddWithValue("@FOLIO", ult_doc)
            cmd_factd.Parameters.AddWithValue("@AUTOANIO", Convert.ToDateTime(dt_encabezado.Rows(0)(7)).Year)
            cmd_factd.Parameters.AddWithValue("@CVE_BITA", dt_GETBITA.Rows(0)(0))
            cmd_factd.Parameters.AddWithValue("@IMPORTE", Convert.ToDouble(dt_encabezado.Rows(0)(5)))
            cmd_factd.Parameters.AddWithValue("@DOC_ANT", dt_encabezado.Rows(0)(1))
            cmd_factd.Transaction = mitransacion
            cmd_factd.ExecuteNonQuery()

            Dim query2 As New StringBuilder
            query2.Append("INSERT INTO [tactical_discount_dimosa].[dbo].[encabezados] ")
            query2.Append("([CODIGO],[VENDEDOR],[FACTURA],[CLIENTE],[ALMACEN],[TIPO],[IMPORTE], ")
            query2.Append("[ESTADO],[FECHA],[FECHA_SAE],[RFC],[FECHA_ENTREGA],[CAMPLIB20],[DOC_NC]) ")
            query2.Append("VALUES (@CODIGO,@VENDEDOR,@FACTURA,@CLIENTE,@ALMACEN,@TIPO,@IMPORTE, ")
            query2.Append("@ESTADO,@FECHA,@FECHA_SAE,@RFC,@FECHA_ENTREGA,@CAMPLIB20,@DOC_NC) ")
            Dim micomando2 As New SqlCommand(query2.ToString, miconexion)
            micomando2.Parameters.AddWithValue("@CODIGO", docto)
            micomando2.Parameters.AddWithValue("@VENDEDOR", dt_encabezado.Rows(0)(0))
            micomando2.Parameters.AddWithValue("@FACTURA", dt_encabezado.Rows(0)(1))
            micomando2.Parameters.AddWithValue("@CLIENTE", dt_encabezado.Rows(0)(2))
            micomando2.Parameters.AddWithValue("@ALMACEN", dt_encabezado.Rows(0)(3))
            micomando2.Parameters.AddWithValue("@TIPO", dt_encabezado.Rows(0)(4))
            micomando2.Parameters.AddWithValue("@IMPORTE", dt_encabezado.Rows(0)(5))
            micomando2.Parameters.AddWithValue("@ESTADO", "ENVIADO")
            micomando2.Parameters.AddWithValue("@FECHA", Convert.ToDateTime(dt_encabezado.Rows(0)(7)).Date)
            micomando2.Parameters.AddWithValue("@FECHA_SAE", fecha_doc)
            micomando2.Parameters.AddWithValue("@RFC", RFC)
            micomando2.Parameters.AddWithValue("@FECHA_ENTREGA", fecha_entrega)
            micomando2.Parameters.AddWithValue("@CAMPLIB20", tipo_camplib20)
            micomando2.Parameters.AddWithValue("@DOC_NC", documento)
            micomando2.Transaction = mitransacion
            micomando2.ExecuteNonQuery()

            Dim _query_ins_bita As New StringBuilder
            _query_ins_bita.Append("INSERT INTO [SAE60Empre06].[dbo].[BITA06]  ")
            _query_ins_bita.Append("(CVE_BITA,[CVE_CLIE],[CVE_CAMPANIA],[CVE_ACTIVIDAD] ")
            _query_ins_bita.Append(",[FECHAHORA],[CVE_USUARIO],[OBSERVACIONES],[STATUS],[NOM_USUARIO]) ")
            _query_ins_bita.Append("VALUES ")
            _query_ins_bita.Append("(@CVE_BITA,@CVE_CLIE,@CVE_CAMPANIA,@CVE_ACTIVIDAD,@FECHAHORA ")
            _query_ins_bita.Append(",@CVE_USUARIO,@OBSERVACIONES,@STATUS,@NOM_USUARIO) ")
            Dim _cmd_ins_bita As New SqlCommand(_query_ins_bita.ToString, miconexion)

            _cmd_ins_bita.Parameters.AddWithValue("@CVE_BITA", dt_GETBITA.Rows(0)(0))
            _cmd_ins_bita.Parameters.AddWithValue("@CVE_CLIE", dt_encabezado.Rows(0)(2))
            _cmd_ins_bita.Parameters.AddWithValue("@CVE_CAMPANIA", "_SAE_")
            _cmd_ins_bita.Parameters.AddWithValue("@CVE_ACTIVIDAD", "    6")
            _cmd_ins_bita.Parameters.AddWithValue("@FECHAHORA", DateTime.Now)
            _cmd_ins_bita.Parameters.AddWithValue("@CVE_USUARIO", 0)
            _cmd_ins_bita.Parameters.AddWithValue("@OBSERVACIONES", "No.[" & documento & "] L " & Convert.ToDouble(dt_encabezado.Rows(0)(5)))
            _cmd_ins_bita.Parameters.AddWithValue("@STATUS", "F")
            _cmd_ins_bita.Parameters.AddWithValue("@NOM_USUARIO", "nc-rpt")
            _cmd_ins_bita.Transaction = mitransacion
            _cmd_ins_bita.ExecuteNonQuery()

            Dim _query_factd_clib As New StringBuilder
            _query_factd_clib.Append("INSERT INTO [SAE60Empre06].[dbo].[FACTD_CLIB06] ")
            _query_factd_clib.Append("([CLAVE_DOC],[CAMPLIB20]) ")
            _query_factd_clib.Append("VALUES(@CLAVE_DOC, @CAMPLIB20) ")
            Dim _cmd_factd_clib As New SqlCommand(_query_factd_clib.ToString, miconexion)
            _cmd_factd_clib.Parameters.AddWithValue("@CLAVE_DOC", documento)
            _cmd_factd_clib.Parameters.AddWithValue("@CAMPLIB20", tipo_camplib20)
            _cmd_factd_clib.Transaction = mitransacion
            _cmd_factd_clib.ExecuteNonQuery()

            Dim _query_clie As New StringBuilder
            _query_clie.Append("UPDATE [SAE60Empre06].[dbo].[CLIE06] ")
            _query_clie.Append("SET [SALDO] = SALDO - @VALOR ")
            _query_clie.Append("WHERE ([CLAVE] = @CLAVE)")
            Dim _cmd_clie As New SqlCommand(_query_clie.ToString, miconexion)
            _cmd_clie.Parameters.AddWithValue("@VALOR", dt_encabezado.Rows(0)(5))
            _cmd_clie.Parameters.AddWithValue("@CLAVE", dt_encabezado.Rows(0)(2))
            _cmd_clie.Transaction = mitransacion
            _cmd_clie.ExecuteNonQuery()

            Dim _query_cuendet As New StringBuilder
            _query_cuendet.Append("INSERT INTO [SAE60Empre06].[dbo].[CUEN_DET06] ")
            _query_cuendet.Append("([CVE_CLIE],[REFER],[ID_MOV],[NUM_CPTO],[NUM_CARGO] ")
            _query_cuendet.Append(",[CVE_OBS],[NO_FACTURA],[DOCTO],[IMPORTE],[FECHA_APLI],[FECHA_VENC] ")
            _query_cuendet.Append(",[STRCVEVEND],[NUM_MONED],[TCAMBIO],[IMPMON_EXT],[FECHAELAB] ")
            _query_cuendet.Append(",[TIPO_MOV],[SIGNO],[USUARIO] ")
            _query_cuendet.Append(",[NO_PARTIDA],[AFEC_COI]) ")
            _query_cuendet.Append(" VALUES ")
            _query_cuendet.Append("(@CVE_CLIE,@REFER,1,12,1,0,@NO_FACTURA,@DOCTO ")
            _query_cuendet.Append(",@IMPORTE,@FECHA_APLI,@FECHA_VENC,@STRCVEVEND,1,1, ")
            _query_cuendet.Append(" @IMPMON_EXT, @FECHAELAB, 'A', -1,0,1,'A')")

            Dim _cmd_cuendet As New SqlCommand(_query_cuendet.ToString, miconexion)
            _cmd_cuendet.Parameters.AddWithValue("@CVE_CLIE", dt_encabezado.Rows(0)(2))
            _cmd_cuendet.Parameters.AddWithValue("@REFER", dt_encabezado.Rows(0)(1))
            _cmd_cuendet.Parameters.AddWithValue("@NO_FACTURA", dt_encabezado.Rows(0)(1))
            _cmd_cuendet.Parameters.AddWithValue("@DOCTO", documento)
            _cmd_cuendet.Parameters.AddWithValue("@IMPORTE", dt_encabezado.Rows(0)(5))
            _cmd_cuendet.Parameters.AddWithValue("@FECHA_APLI", fecha_doc)
            _cmd_cuendet.Parameters.AddWithValue("@FECHA_VENC", fecha_doc)
            _cmd_cuendet.Parameters.AddWithValue("@STRCVEVEND", dt_encabezado.Rows(0)(0))
            _cmd_cuendet.Parameters.AddWithValue("@IMPMON_EXT", dt_encabezado.Rows(0)(5))
            _cmd_cuendet.Parameters.AddWithValue("@FECHAELAB", Now.Date)
            _cmd_cuendet.Transaction = mitransacion
            _cmd_cuendet.ExecuteNonQuery()

            If dt_encabezado.Rows(0)(4) = "CONTADO" Then
                Dim _query_clie_CARGOXDEV As New StringBuilder
                _query_clie_CARGOXDEV.Append("UPDATE [SAE60Empre06].[dbo].[CLIE06] ")
                _query_clie_CARGOXDEV.Append("SET [SALDO] = SALDO + @VALOR ")
                _query_clie_CARGOXDEV.Append("WHERE ([CLAVE] = @CLAVE)")
                Dim _cmd_clie_CARGOXDEV As New SqlCommand(_query_clie_CARGOXDEV.ToString, miconexion)
                _cmd_clie_CARGOXDEV.Parameters.AddWithValue("@VALOR", dt_encabezado.Rows(0)(5))
                _cmd_clie_CARGOXDEV.Parameters.AddWithValue("@CLAVE", dt_encabezado.Rows(0)(2))
                _cmd_clie_CARGOXDEV.Transaction = mitransacion
                _cmd_clie_CARGOXDEV.ExecuteNonQuery()

                Dim _query_cuendet_CARGOXDEV As New StringBuilder
                _query_cuendet_CARGOXDEV.Append("INSERT INTO [SAE60Empre06].[dbo].[CUEN_DET06] ")
                _query_cuendet_CARGOXDEV.Append("([CVE_CLIE],[REFER],[ID_MOV],[NUM_CPTO],[NUM_CARGO] ")
                _query_cuendet_CARGOXDEV.Append(",[CVE_OBS],[NO_FACTURA],[DOCTO],[IMPORTE],[FECHA_APLI],[FECHA_VENC] ")
                _query_cuendet_CARGOXDEV.Append(",[STRCVEVEND],[NUM_MONED],[TCAMBIO],[IMPMON_EXT],[FECHAELAB] ")
                _query_cuendet_CARGOXDEV.Append(",[TIPO_MOV],[SIGNO],[USUARIO] ")
                _query_cuendet_CARGOXDEV.Append(",[NO_PARTIDA],[AFEC_COI]) ")
                _query_cuendet_CARGOXDEV.Append(" VALUES ")
                _query_cuendet_CARGOXDEV.Append("(@CVE_CLIE,@REFER,1,31,1,0,@NO_FACTURA,@DOCTO ")
                _query_cuendet_CARGOXDEV.Append(",@IMPORTE,@FECHA_APLI,@FECHA_VENC,@STRCVEVEND,1,1, ")
                _query_cuendet_CARGOXDEV.Append(" @IMPMON_EXT, @FECHAELAB, 'C', 1,0,2,'')")

                Dim _cmd_cuendet_CARGOXDEV As New SqlCommand(_query_cuendet_CARGOXDEV.ToString, miconexion)
                _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@CVE_CLIE", dt_encabezado.Rows(0)(2))
                _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@REFER", dt_encabezado.Rows(0)(1))
                _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@NO_FACTURA", dt_encabezado.Rows(0)(1))
                _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@DOCTO", documento) '"NC" & ult_doc)
                _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@IMPORTE", dt_encabezado.Rows(0)(5))
                _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@FECHA_APLI", fecha_doc)
                _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@FECHA_VENC", fecha_doc)
                _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@STRCVEVEND", dt_encabezado.Rows(0)(0))
                _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@IMPMON_EXT", dt_encabezado.Rows(0)(5))
                _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@FECHAELAB", Now.Date)
                _cmd_cuendet_CARGOXDEV.Transaction = mitransacion
                _cmd_cuendet_CARGOXDEV.ExecuteNonQuery()

                Dim _query_ins_bita_cargoxdev As New StringBuilder
                _query_ins_bita_cargoxdev.Append("INSERT INTO [SAE60Empre06].[dbo].[BITA06]  ")
                _query_ins_bita_cargoxdev.Append("(CVE_BITA,[CVE_CLIE],[CVE_CAMPANIA],[CVE_ACTIVIDAD] ")
                _query_ins_bita_cargoxdev.Append(",[FECHAHORA],[CVE_USUARIO],[OBSERVACIONES],[STATUS],[NOM_USUARIO]) ")
                _query_ins_bita_cargoxdev.Append("VALUES ")
                _query_ins_bita_cargoxdev.Append("(@CVE_BITA,@CVE_CLIE,@CVE_CAMPANIA,@CVE_ACTIVIDAD,@FECHAHORA ")
                _query_ins_bita_cargoxdev.Append(",@CVE_USUARIO,@OBSERVACIONES,@STATUS,@NOM_USUARIO) ")
                Dim _cmd_ins_bita_cargoxdev As New SqlCommand(_query_ins_bita_cargoxdev.ToString, miconexion)

                _cmd_ins_bita_cargoxdev.Parameters.AddWithValue("@CVE_BITA", dt_GETBITA.Rows(0)(0) + 1)
                _cmd_ins_bita_cargoxdev.Parameters.AddWithValue("@CVE_CLIE", dt_encabezado.Rows(0)(2))
                _cmd_ins_bita_cargoxdev.Parameters.AddWithValue("@CVE_CAMPANIA", "_SAE_")
                _cmd_ins_bita_cargoxdev.Parameters.AddWithValue("@CVE_ACTIVIDAD", "   12")
                _cmd_ins_bita_cargoxdev.Parameters.AddWithValue("@FECHAHORA", DateTime.Now)
                _cmd_ins_bita_cargoxdev.Parameters.AddWithValue("@CVE_USUARIO", 0)
                _cmd_ins_bita_cargoxdev.Parameters.AddWithValue("@OBSERVACIONES", "No.[] L " & Convert.ToDouble(dt_encabezado.Rows(0)(5)))
                _cmd_ins_bita_cargoxdev.Parameters.AddWithValue("@STATUS", "F")
                _cmd_ins_bita_cargoxdev.Parameters.AddWithValue("@NOM_USUARIO", "nc-rpt")
                _cmd_ins_bita_cargoxdev.Transaction = mitransacion
                _cmd_ins_bita_cargoxdev.ExecuteNonQuery()

                Dim _query_control2_cargoxdev As New StringBuilder
                _query_control2_cargoxdev.Append("UPDATE [SAE60Empre06].[dbo].[TBLCONTROL06] ")
                _query_control2_cargoxdev.Append(" SET [ULT_CVE] = ULT_CVE + 1 ")
                _query_control2_cargoxdev.Append("WHERE [ID_TABLA] = 62 ")
                Dim _cmd_control2_cargoxdev As New SqlCommand(_query_control2_cargoxdev.ToString, miconexion)
                _cmd_control2_cargoxdev.Transaction = mitransacion
                _cmd_control2_cargoxdev.ExecuteNonQuery()
            End If

            'PARTIDAS DEL DOCUMENTO
            For index As Integer = 0 To dt_parfactd.Rows.Count - 1
                'debe ir en cada partida
                Dim _query_doctosig As New StringBuilder

                _query_doctosig.Append("INSERT INTO [SAE60Empre06].[dbo].[DOCTOSIGF06] ")
                _query_doctosig.Append("([TIP_DOC],[CVE_DOC],[ANT_SIG],[TIP_DOC_E] ")
                _query_doctosig.Append(",[CVE_DOC_E],[PARTIDA],[PART_E],[CANT_E]) ")
                _query_doctosig.Append("VALUES ")
                _query_doctosig.Append("('D',@CVE_DOC,'A', 'F',@CVE_DOC_E,@PARTIDA,0,0)")
                Dim _cmd_doctosig As New SqlCommand(_query_doctosig.ToString, miconexion)
                _cmd_doctosig.Parameters.AddWithValue("@CVE_DOC", documento)
                _cmd_doctosig.Parameters.AddWithValue("@CVE_DOC_E", dt_encabezado.Rows(0)(1))
                _cmd_doctosig.Parameters.AddWithValue("@PARTIDA", index + 1)
                _cmd_doctosig.Transaction = mitransacion
                _cmd_doctosig.ExecuteNonQuery()

                Dim _query_par_factd As New StringBuilder
                _query_par_factd.Append("INSERT INTO [SAE60Empre06].[dbo].[PAR_FACTD06] ")
                _query_par_factd.Append("           ([CVE_DOC],[NUM_PAR],[CVE_ART],[CANT],[PXS],[PREC] ")
                _query_par_factd.Append("           ,[COST],[IMPU1],[IMPU2],[IMPU3],[IMPU4],[IMP1APLA] ")
                _query_par_factd.Append("           ,[IMP2APLA],[IMP3APLA],[IMP4APLA],[TOTIMP1],[TOTIMP2] ")
                _query_par_factd.Append("           ,[TOTIMP3],[TOTIMP4],[DESC1],[DESC2],[DESC3],[COMI] ")
                _query_par_factd.Append("           ,[APAR],[ACT_INV],[NUM_ALM],[TIP_CAM] ")
                _query_par_factd.Append("           ,[UNI_VENTA],[TIPO_PROD],[CVE_OBS],[REG_SERIE],[E_LTPD] ")
                _query_par_factd.Append("           ,[TIPO_ELEM],[NUM_MOV],[TOT_PARTIDA],[IMPRIMIR]) ")
                _query_par_factd.Append("VALUES    (@CVE_DOC,@NUM_PAR,@CVE_ART,@CANT,@PXS,@PREC,0,0,0, ")
                _query_par_factd.Append("           0,@IMPU4,0,0,0,0,0, 0,0,@TOTIMP4,0,0,0,0,0,'S',@NUM_ALM, ")
                _query_par_factd.Append("           1,@UNI_VENTA,'S',0,0,0,'N',0,@TOT_PARTIDA,'S')")
                Dim _cmd_par_factd As New SqlCommand(_query_par_factd.ToString, miconexion)
                _cmd_par_factd.Parameters.AddWithValue("@CVE_DOC", documento)
                _cmd_par_factd.Parameters.AddWithValue("@NUM_PAR", index + 1)
                _cmd_par_factd.Parameters.AddWithValue("@CVE_ART", dt_parfactd.Rows(index)(0))
                _cmd_par_factd.Parameters.AddWithValue("@CANT", dt_parfactd.Rows(index)(1))
                _cmd_par_factd.Parameters.AddWithValue("@PXS", dt_parfactd.Rows(index)(2))
                _cmd_par_factd.Parameters.AddWithValue("@PREC", dt_parfactd.Rows(index)(3))
                _cmd_par_factd.Parameters.AddWithValue("@IMPU4", dt_parfactd.Rows(index)(4))
                _cmd_par_factd.Parameters.AddWithValue("@TOTIMP4", dt_parfactd.Rows(index)(5))
                _cmd_par_factd.Parameters.AddWithValue("@NUM_ALM", dt_encabezado.Rows(0)(3))
                _cmd_par_factd.Parameters.AddWithValue("@UNI_VENTA", dt_parfactd.Rows(index)(6))
                _cmd_par_factd.Parameters.AddWithValue("@TOT_PARTIDA", dt_parfactd.Rows(index)(7))
                _cmd_par_factd.Transaction = mitransacion
                _cmd_par_factd.ExecuteNonQuery()

                Dim _query_par_factd_clib As New StringBuilder
                _query_par_factd_clib.Append("INSERT INTO [SAE60Empre06].[dbo].[PAR_FACTD_CLIB06] ")
                _query_par_factd_clib.Append("([CLAVE_DOC],[NUM_PART]) ")
                _query_par_factd_clib.Append("VALUES(@CLAVE_DOC, @NUM_PART)")
                Dim _cmd_par_factd_clib As New SqlCommand(_query_par_factd_clib.ToString, miconexion)
                _cmd_par_factd_clib.Parameters.AddWithValue("@CLAVE_DOC", documento)
                _cmd_par_factd_clib.Parameters.AddWithValue("@NUM_PART", index + 1)
                _cmd_par_factd_clib.Transaction = mitransacion
                _cmd_par_factd_clib.ExecuteNonQuery()
            Next

            Dim _query_control1 As New StringBuilder
            _query_control1.Append("UPDATE [SAE60Empre06].[dbo].[TBLCONTROL06] ")
            _query_control1.Append(" SET [ULT_CVE] = ULT_CVE + 1 ")
            _query_control1.Append("WHERE [ID_TABLA] = 32 ")
            Dim _cmd_control1 As New SqlCommand(_query_control1.ToString, miconexion)
            _cmd_control1.Transaction = mitransacion
            _cmd_control1.ExecuteNonQuery()

            Dim _query_control2 As New StringBuilder
            _query_control2.Append("UPDATE [SAE60Empre06].[dbo].[TBLCONTROL06] ")
            _query_control2.Append(" SET [ULT_CVE] = ULT_CVE + 1 ")
            _query_control2.Append("WHERE [ID_TABLA] = 62 ")
            Dim _cmd_control2 As New SqlCommand(_query_control2.ToString, miconexion)
            _cmd_control2.Transaction = mitransacion
            _cmd_control2.ExecuteNonQuery()

            Dim _query_foliosf As New StringBuilder
            _query_foliosf.Append("UPDATE [SAE60Empre06].[dbo].[FOLIOSF06] ")
            _query_foliosf.Append(" SET [ULT_DOC] = ULT_DOC +1 ")
            _query_foliosf.Append("WHERE [SERIE] = @SERIE")
            Dim _cmd_foliosf As New SqlCommand(_query_foliosf.ToString, miconexion)
            _cmd_foliosf.Parameters.AddWithValue("@SERIE", serie)
            _cmd_foliosf.Transaction = mitransacion
            _cmd_foliosf.ExecuteNonQuery()

            mitransacion.Commit()
            miconexion.Close()
            variable_error = "correcto"

        Catch ex As Exception
            mitransacion.Rollback()
            miconexion.Close()
            variable_error = ex.Message
        End Try

        Return variable_error
    End Function

    Public Function guardar_datos_envio_sae_opl(ByVal dt_encabezado As DataTable, ByVal dt_partida As DataTable, ByVal RFC As String,
                    ByVal dt_parfactd As DataTable, ByVal sub_total As Double, ByVal tot_isv As Double, ByVal fecha_entrega As DateTime, ByVal fecha_doc As Date) As String
        Dim mitransacion As SqlTransaction
        Dim miconexion As New SqlConnection(conexion_Descuentos_Opl.CadenaSQL)
        Dim variable_error As String = ""
        miconexion.Open()
        mitransacion = miconexion.BeginTransaction
        Try
            Dim query_folios As New StringBuilder
            query_folios.Append("SELECT FOLIO + CONVERT(VARCHAR, ULT_DOC + 1) AS DOCTO, SERIE, TIPO ")
            query_folios.Append("FROM folios ")
            query_folios.Append("WHERE NUM_ALMA = @ALMACEN ")

            Dim comand_folio As New SqlCommand(query_folios.ToString, miconexion)
            comand_folio.Parameters.AddWithValue("@ALMACEN", dt_encabezado.Rows(0)(3))
            comand_folio.Transaction = mitransacion
            Dim adaptador_folios As New SqlDataAdapter(comand_folio)
            Dim dt_folios As New DataTable
            adaptador_folios.Fill(dt_folios)

            Dim docto As String
            Dim serie_local As String = ""
            Dim tipo_camplib20 As String = ""
            docto = dt_folios.Rows(0)(0)
            serie_local = dt_folios.Rows(0)(1)

            If dt_encabezado.Rows(0)(4) = "CREDITO" Then
                tipo_camplib20 = "N" + dt_folios.Rows(0)(2)
            Else
                tipo_camplib20 = "D" + dt_folios.Rows(0)(2)
            End If

            For i As Integer = 0 To dt_partida.Rows.Count - 1
                Dim query As New StringBuilder
                query.Append("UPDATE presupuestos ")
                query.Append("SET Restante = Restante - @VALOR ")
                query.Append("WHERE AñoId = @AÑO AND MesId = @MES AND ProveedorId = @PROVEEDOR")

                Dim micomando As New SqlCommand(query.ToString, miconexion)
                micomando.Parameters.AddWithValue("@VALOR", dt_partida.Rows(i)(3))
                micomando.Parameters.AddWithValue("@AÑO", Convert.ToDateTime(dt_encabezado.Rows(0)(7)).Year)
                micomando.Parameters.AddWithValue("@MES", Convert.ToDateTime(dt_encabezado.Rows(0)(7)).Month)
                micomando.Parameters.AddWithValue("@PROVEEDOR", dt_partida.Rows(i)(4))
                micomando.Transaction = mitransacion
                micomando.ExecuteNonQuery()

                Dim query3 As New StringBuilder
                query3.Append("INSERT INTO [tactical_discount_opl].[dbo].[partidas] ")
                query3.Append("([CODIGO],[NUM_PART],[CVE_ART],[CANTIDAD],[MONTO],[PROVEEDOR],[CONCEPTO],[ISV],[SUBTOTAL],[CONCEPTO_PROVEEDOR]) ")
                query3.Append("VALUES(@CODIGO, @NUM_PART, @CVE_ART, @CANTIDAD, @MONTO,@PROVEEDOR,@CONCEPTO,@ISV,@SUBTOTAL,@CONCEPTO_PROVEEDOR) ")

                Dim micomando3 As New SqlCommand(query3.ToString, miconexion)
                micomando3.Parameters.AddWithValue("@CODIGO", docto)
                micomando3.Parameters.AddWithValue("@NUM_PART", dt_partida.Rows(i)(0))
                micomando3.Parameters.AddWithValue("@CVE_ART", dt_partida.Rows(i)(1))
                micomando3.Parameters.AddWithValue("@CANTIDAD", dt_partida.Rows(i)(2))
                micomando3.Parameters.AddWithValue("@MONTO", dt_partida.Rows(i)(3))
                micomando3.Parameters.AddWithValue("@PROVEEDOR", dt_partida.Rows(i)(4))
                micomando3.Parameters.AddWithValue("@CONCEPTO", dt_partida.Rows(i)(5))
                micomando3.Parameters.AddWithValue("@ISV", dt_partida.Rows(i)(6))
                micomando3.Parameters.AddWithValue("@SUBTOTAL", dt_partida.Rows(i)(7))
                micomando3.Parameters.AddWithValue("@CONCEPTO_PROVEEDOR", dt_partida.Rows(i)(8))
                micomando3.Transaction = mitransacion
                micomando3.ExecuteNonQuery()
            Next

            Dim upd_folios As New StringBuilder
            upd_folios.Append("UPDATE [folios]  ")
            upd_folios.Append("SET [ULT_DOC] = ULT_DOC + 1 ")
            upd_folios.Append("WHERE NUM_ALMA = @ALMACEN ")
            Dim comand_upd_folio As New SqlCommand(upd_folios.ToString, miconexion)
            comand_upd_folio.Parameters.AddWithValue("@ALMACEN", dt_encabezado.Rows(0)(3))
            comand_upd_folio.Transaction = mitransacion
            comand_upd_folio.ExecuteNonQuery()

            'ENVIO A SAE
            Dim _query_docto As New StringBuilder
            _query_docto.Append("SELECT SERIE,(ULT_DOC + 1)  ")
            _query_docto.Append("FROM [SAE60Empre08].[dbo].FOLIOSF08 ")
            _query_docto.Append("WHERE SERIE = @SERIE")
            Dim _cmd_docto As New SqlCommand(_query_docto.ToString, miconexion)
            _cmd_docto.Parameters.AddWithValue("@SERIE", serie_local)
            _cmd_docto.Transaction = mitransacion
            Dim adaptador_docto As New SqlDataAdapter(_cmd_docto)
            Dim dt_docto As New DataTable
            adaptador_docto.Fill(dt_docto)

            Dim serie As String = ""
            Dim ult_doc As Integer = 0
            Dim documento As String = ""
            serie = dt_docto.Rows(0)(0)
            ult_doc = dt_docto.Rows(0)(1)
            Dim ceros As String = ""
            For cont As Integer = 1 To 8 - Convert.ToString(ult_doc).Length
                ceros += "0"
            Next


            documento = serie + ceros + Convert.ToString(ult_doc)

            Dim _query_GETBITA As New StringBuilder
            _query_GETBITA.Append("SELECT ULT_CVE + 1   ")
            _query_GETBITA.Append("FROM [SAE60Empre08].[dbo].[TBLCONTROL08] ")
            _query_GETBITA.Append("WHERE ([ID_TABLA] = 62)")
            Dim _cmd_GETBITA As New SqlCommand(_query_GETBITA.ToString, miconexion)
            _cmd_GETBITA.Transaction = mitransacion
            Dim adaptador_BITA As New SqlDataAdapter(_cmd_GETBITA)
            Dim dt_GETBITA As New DataTable
            adaptador_BITA.Fill(dt_GETBITA)

            Dim _query_factd As New StringBuilder
            _query_factd.Append("INSERT INTO [SAE60Empre08].[dbo].[FACTD08] ")
            _query_factd.Append(" ([TIP_DOC],[CVE_DOC],[CVE_CLPV],[STATUS],[CVE_VEND],[CVE_PEDI] ")
            _query_factd.Append("  ,[FECHA_DOC],[FECHA_ENT],[FECHA_VEN],[CAN_TOT] ,[IMP_TOT1], [IMP_TOT2], ")
            _query_factd.Append("[IMP_TOT3],[IMP_TOT4],[DES_TOT],[DES_FIN],[COM_TOT] ,[CONDICION],[CVE_OBS], ")
            _query_factd.Append("[NUM_ALMA],[ACT_CXC],[ACT_COI],[ENLAZADO],[TIP_DOC_E],[NUM_MONED],[TIPCAMB], ")
            _query_factd.Append("[NUM_PAGOS],[FECHAELAB],[PRIMERPAGO],[RFC],[CTLPOL],[ESCFD],[AUTORIZA],[SERIE], ")
            _query_factd.Append("[FOLIO],[AUTOANIO],[DAT_ENVIO],[CONTADO],[DAT_MOSTR],[CVE_BITA],[BLOQ],[FORMAENVIO], ")
            _query_factd.Append("[DES_FIN_PORC],[DES_TOT_PORC],[IMPORTE],[TIP_DOC_ANT],[DOC_ANT]) ")
            _query_factd.Append("VALUES ")
            _query_factd.Append("('D',@CVE_DOC,@CVE_CLPV,'O',@CVE_VEND,0,@FECHA_DOC,@FECHA_ENT,@FECHA_VEN, @CAN_TOT, ")
            _query_factd.Append("0,0,0,@IMP_TOT4,0,0,0,0,0, @NUM_ALMA,'S','N','O','F',1,1,1,@FECHAELAB,0,@RFC, ")
            _query_factd.Append("0,'N',@AUTORIZA,@SERIE,@FOLIO,@AUTOANIO,0,'N',0,@CVE_BITA,'N',0,0,0,@IMPORTE, ")
            _query_factd.Append("'F', @DOC_ANT)")

            Dim cmd_factd As New SqlCommand(_query_factd.ToString, miconexion)
            cmd_factd.Parameters.AddWithValue("@CVE_DOC", documento)
            cmd_factd.Parameters.AddWithValue("@CVE_CLPV", dt_encabezado.Rows(0)(2))
            cmd_factd.Parameters.AddWithValue("@CVE_VEND", dt_encabezado.Rows(0)(0))
            cmd_factd.Parameters.AddWithValue("@FECHA_DOC", fecha_doc)
            cmd_factd.Parameters.AddWithValue("@FECHA_ENT", fecha_entrega)
            cmd_factd.Parameters.AddWithValue("@FECHA_VEN", fecha_doc)
            cmd_factd.Parameters.AddWithValue("@CAN_TOT", sub_total)
            cmd_factd.Parameters.AddWithValue("@IMP_TOT4", tot_isv)
            cmd_factd.Parameters.AddWithValue("@NUM_ALMA", dt_encabezado.Rows(0)(3))
            cmd_factd.Parameters.AddWithValue("@FECHAELAB", Now.Date)
            cmd_factd.Parameters.AddWithValue("@RFC", RFC)
            cmd_factd.Parameters.AddWithValue("@AUTORIZA", Convert.ToDateTime(dt_encabezado.Rows(0)(7)).Year)
            cmd_factd.Parameters.AddWithValue("@SERIE", serie)
            cmd_factd.Parameters.AddWithValue("@FOLIO", ult_doc)
            cmd_factd.Parameters.AddWithValue("@AUTOANIO", Convert.ToDateTime(dt_encabezado.Rows(0)(7)).Year)
            cmd_factd.Parameters.AddWithValue("@CVE_BITA", dt_GETBITA.Rows(0)(0))
            cmd_factd.Parameters.AddWithValue("@IMPORTE", Convert.ToDouble(dt_encabezado.Rows(0)(5)))
            cmd_factd.Parameters.AddWithValue("@DOC_ANT", dt_encabezado.Rows(0)(1))
            cmd_factd.Transaction = mitransacion
            cmd_factd.ExecuteNonQuery()

            Dim query2 As New StringBuilder
            query2.Append("INSERT INTO [tactical_discount_opl].[dbo].[encabezados] ")
            query2.Append("([CODIGO],[VENDEDOR],[FACTURA],[CLIENTE],[ALMACEN],[TIPO],[IMPORTE], ")
            query2.Append("[ESTADO],[FECHA],[FECHA_SAE],[RFC],[FECHA_ENTREGA],[CAMPLIB20],[DOC_NC]) ")
            query2.Append("VALUES (@CODIGO,@VENDEDOR,@FACTURA,@CLIENTE,@ALMACEN,@TIPO,@IMPORTE, ")
            query2.Append("@ESTADO,@FECHA,@FECHA_SAE,@RFC,@FECHA_ENTREGA,@CAMPLIB20,@DOC_NC) ")
            Dim micomando2 As New SqlCommand(query2.ToString, miconexion)
            micomando2.Parameters.AddWithValue("@CODIGO", docto)
            micomando2.Parameters.AddWithValue("@VENDEDOR", dt_encabezado.Rows(0)(0))
            micomando2.Parameters.AddWithValue("@FACTURA", dt_encabezado.Rows(0)(1))
            micomando2.Parameters.AddWithValue("@CLIENTE", dt_encabezado.Rows(0)(2))
            micomando2.Parameters.AddWithValue("@ALMACEN", dt_encabezado.Rows(0)(3))
            micomando2.Parameters.AddWithValue("@TIPO", dt_encabezado.Rows(0)(4))
            micomando2.Parameters.AddWithValue("@IMPORTE", dt_encabezado.Rows(0)(5))
            micomando2.Parameters.AddWithValue("@ESTADO", "ENVIADO")
            micomando2.Parameters.AddWithValue("@FECHA", Convert.ToDateTime(dt_encabezado.Rows(0)(7)).Date)
            micomando2.Parameters.AddWithValue("@FECHA_SAE", fecha_doc)
            micomando2.Parameters.AddWithValue("@RFC", RFC)
            micomando2.Parameters.AddWithValue("@FECHA_ENTREGA", fecha_entrega)
            micomando2.Parameters.AddWithValue("@CAMPLIB20", tipo_camplib20)
            micomando2.Parameters.AddWithValue("@DOC_NC", documento)
            micomando2.Transaction = mitransacion
            micomando2.ExecuteNonQuery()

            Dim _query_ins_bita As New StringBuilder
            _query_ins_bita.Append("INSERT INTO [SAE60Empre08].[dbo].[BITA08]  ")
            _query_ins_bita.Append("(CVE_BITA,[CVE_CLIE],[CVE_CAMPANIA],[CVE_ACTIVIDAD] ")
            _query_ins_bita.Append(",[FECHAHORA],[CVE_USUARIO],[OBSERVACIONES],[STATUS],[NOM_USUARIO]) ")
            _query_ins_bita.Append("VALUES ")
            _query_ins_bita.Append("(@CVE_BITA,@CVE_CLIE,@CVE_CAMPANIA,@CVE_ACTIVIDAD,@FECHAHORA ")
            _query_ins_bita.Append(",@CVE_USUARIO,@OBSERVACIONES,@STATUS,@NOM_USUARIO) ")
            Dim _cmd_ins_bita As New SqlCommand(_query_ins_bita.ToString, miconexion)

            _cmd_ins_bita.Parameters.AddWithValue("@CVE_BITA", dt_GETBITA.Rows(0)(0))
            _cmd_ins_bita.Parameters.AddWithValue("@CVE_CLIE", dt_encabezado.Rows(0)(2))
            _cmd_ins_bita.Parameters.AddWithValue("@CVE_CAMPANIA", "_SAE_")
            _cmd_ins_bita.Parameters.AddWithValue("@CVE_ACTIVIDAD", "    6")
            _cmd_ins_bita.Parameters.AddWithValue("@FECHAHORA", DateTime.Now)
            _cmd_ins_bita.Parameters.AddWithValue("@CVE_USUARIO", 0)
            _cmd_ins_bita.Parameters.AddWithValue("@OBSERVACIONES", "No.[" & documento & "] L " & Convert.ToDouble(dt_encabezado.Rows(0)(5)))
            _cmd_ins_bita.Parameters.AddWithValue("@STATUS", "F")
            _cmd_ins_bita.Parameters.AddWithValue("@NOM_USUARIO", "nc-rpt")
            _cmd_ins_bita.Transaction = mitransacion
            _cmd_ins_bita.ExecuteNonQuery()

            Dim _query_factd_clib As New StringBuilder
            _query_factd_clib.Append("INSERT INTO [SAE60Empre08].[dbo].[FACTD_CLIB08] ")
            _query_factd_clib.Append("([CLAVE_DOC],[CAMPLIB20]) ")
            _query_factd_clib.Append("VALUES(@CLAVE_DOC, @CAMPLIB20) ")
            Dim _cmd_factd_clib As New SqlCommand(_query_factd_clib.ToString, miconexion)
            _cmd_factd_clib.Parameters.AddWithValue("@CLAVE_DOC", documento)
            _cmd_factd_clib.Parameters.AddWithValue("@CAMPLIB20", tipo_camplib20)
            _cmd_factd_clib.Transaction = mitransacion
            _cmd_factd_clib.ExecuteNonQuery()

            Dim _query_clie As New StringBuilder
            _query_clie.Append("UPDATE [SAE60Empre08].[dbo].[CLIE08] ")
            _query_clie.Append("SET [SALDO] = SALDO - @VALOR ")
            _query_clie.Append("WHERE ([CLAVE] = @CLAVE)")
            Dim _cmd_clie As New SqlCommand(_query_clie.ToString, miconexion)
            _cmd_clie.Parameters.AddWithValue("@VALOR", dt_encabezado.Rows(0)(5))
            _cmd_clie.Parameters.AddWithValue("@CLAVE", dt_encabezado.Rows(0)(2))
            _cmd_clie.Transaction = mitransacion
            _cmd_clie.ExecuteNonQuery()

            Dim _query_cuendet As New StringBuilder
            _query_cuendet.Append("INSERT INTO [SAE60Empre08].[dbo].[CUEN_DET08] ")
            _query_cuendet.Append("([CVE_CLIE],[REFER],[ID_MOV],[NUM_CPTO],[NUM_CARGO] ")
            _query_cuendet.Append(",[CVE_OBS],[NO_FACTURA],[DOCTO],[IMPORTE],[FECHA_APLI],[FECHA_VENC] ")
            _query_cuendet.Append(",[STRCVEVEND],[NUM_MONED],[TCAMBIO],[IMPMON_EXT],[FECHAELAB] ")
            _query_cuendet.Append(",[TIPO_MOV],[SIGNO],[USUARIO] ")
            _query_cuendet.Append(",[NO_PARTIDA],[AFEC_COI]) ")
            _query_cuendet.Append(" VALUES ")
            _query_cuendet.Append("(@CVE_CLIE,@REFER,1,12,1,0,@NO_FACTURA,@DOCTO ")
            _query_cuendet.Append(",@IMPORTE,@FECHA_APLI,@FECHA_VENC,@STRCVEVEND,1,1, ")
            _query_cuendet.Append(" @IMPMON_EXT, @FECHAELAB, 'A', -1,0,1,'A')")

            Dim _cmd_cuendet As New SqlCommand(_query_cuendet.ToString, miconexion)
            _cmd_cuendet.Parameters.AddWithValue("@CVE_CLIE", dt_encabezado.Rows(0)(2))
            _cmd_cuendet.Parameters.AddWithValue("@REFER", dt_encabezado.Rows(0)(1))
            _cmd_cuendet.Parameters.AddWithValue("@NO_FACTURA", dt_encabezado.Rows(0)(1))
            _cmd_cuendet.Parameters.AddWithValue("@DOCTO", documento)
            _cmd_cuendet.Parameters.AddWithValue("@IMPORTE", dt_encabezado.Rows(0)(5))
            _cmd_cuendet.Parameters.AddWithValue("@FECHA_APLI", fecha_doc)
            _cmd_cuendet.Parameters.AddWithValue("@FECHA_VENC", fecha_doc)
            _cmd_cuendet.Parameters.AddWithValue("@STRCVEVEND", dt_encabezado.Rows(0)(0))
            _cmd_cuendet.Parameters.AddWithValue("@IMPMON_EXT", dt_encabezado.Rows(0)(5))
            _cmd_cuendet.Parameters.AddWithValue("@FECHAELAB", Now.Date)
            _cmd_cuendet.Transaction = mitransacion
            _cmd_cuendet.ExecuteNonQuery()

            If dt_encabezado.Rows(0)(4) = "CONTADO" Then
                Dim _query_clie_CARGOXDEV As New StringBuilder
                _query_clie_CARGOXDEV.Append("UPDATE [SAE60Empre08].[dbo].[CLIE08] ")
                _query_clie_CARGOXDEV.Append("SET [SALDO] = SALDO + @VALOR ")
                _query_clie_CARGOXDEV.Append("WHERE ([CLAVE] = @CLAVE)")
                Dim _cmd_clie_CARGOXDEV As New SqlCommand(_query_clie_CARGOXDEV.ToString, miconexion)
                _cmd_clie_CARGOXDEV.Parameters.AddWithValue("@VALOR", dt_encabezado.Rows(0)(5))
                _cmd_clie_CARGOXDEV.Parameters.AddWithValue("@CLAVE", dt_encabezado.Rows(0)(2))
                _cmd_clie_CARGOXDEV.Transaction = mitransacion
                _cmd_clie_CARGOXDEV.ExecuteNonQuery()

                Dim _query_cuendet_CARGOXDEV As New StringBuilder
                _query_cuendet_CARGOXDEV.Append("INSERT INTO [SAE60Empre08].[dbo].[CUEN_DET08] ")
                _query_cuendet_CARGOXDEV.Append("([CVE_CLIE],[REFER],[ID_MOV],[NUM_CPTO],[NUM_CARGO] ")
                _query_cuendet_CARGOXDEV.Append(",[CVE_OBS],[NO_FACTURA],[DOCTO],[IMPORTE],[FECHA_APLI],[FECHA_VENC] ")
                _query_cuendet_CARGOXDEV.Append(",[STRCVEVEND],[NUM_MONED],[TCAMBIO],[IMPMON_EXT],[FECHAELAB] ")
                _query_cuendet_CARGOXDEV.Append(",[TIPO_MOV],[SIGNO],[USUARIO] ")
                _query_cuendet_CARGOXDEV.Append(",[NO_PARTIDA],[AFEC_COI]) ")
                _query_cuendet_CARGOXDEV.Append(" VALUES ")
                _query_cuendet_CARGOXDEV.Append("(@CVE_CLIE,@REFER,1,31,1,0,@NO_FACTURA,@DOCTO ")
                _query_cuendet_CARGOXDEV.Append(",@IMPORTE,@FECHA_APLI,@FECHA_VENC,@STRCVEVEND,1,1, ")
                _query_cuendet_CARGOXDEV.Append(" @IMPMON_EXT, @FECHAELAB, 'C', 1,0,2,'')")

                Dim _cmd_cuendet_CARGOXDEV As New SqlCommand(_query_cuendet_CARGOXDEV.ToString, miconexion)
                _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@CVE_CLIE", dt_encabezado.Rows(0)(2))
                _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@REFER", dt_encabezado.Rows(0)(1))
                _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@NO_FACTURA", dt_encabezado.Rows(0)(1))
                _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@DOCTO", documento) '"NC" & ult_doc)
                _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@IMPORTE", dt_encabezado.Rows(0)(5))
                _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@FECHA_APLI", fecha_doc)
                _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@FECHA_VENC", fecha_doc)
                _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@STRCVEVEND", dt_encabezado.Rows(0)(0))
                _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@IMPMON_EXT", dt_encabezado.Rows(0)(5))
                _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@FECHAELAB", Now.Date)
                _cmd_cuendet_CARGOXDEV.Transaction = mitransacion
                _cmd_cuendet_CARGOXDEV.ExecuteNonQuery()

                Dim _query_ins_bita_cargoxdev As New StringBuilder
                _query_ins_bita_cargoxdev.Append("INSERT INTO [SAE60Empre08].[dbo].[BITA08]  ")
                _query_ins_bita_cargoxdev.Append("(CVE_BITA,[CVE_CLIE],[CVE_CAMPANIA],[CVE_ACTIVIDAD] ")
                _query_ins_bita_cargoxdev.Append(",[FECHAHORA],[CVE_USUARIO],[OBSERVACIONES],[STATUS],[NOM_USUARIO]) ")
                _query_ins_bita_cargoxdev.Append("VALUES ")
                _query_ins_bita_cargoxdev.Append("(@CVE_BITA,@CVE_CLIE,@CVE_CAMPANIA,@CVE_ACTIVIDAD,@FECHAHORA ")
                _query_ins_bita_cargoxdev.Append(",@CVE_USUARIO,@OBSERVACIONES,@STATUS,@NOM_USUARIO) ")
                Dim _cmd_ins_bita_cargoxdev As New SqlCommand(_query_ins_bita_cargoxdev.ToString, miconexion)

                _cmd_ins_bita_cargoxdev.Parameters.AddWithValue("@CVE_BITA", dt_GETBITA.Rows(0)(0) + 1)
                _cmd_ins_bita_cargoxdev.Parameters.AddWithValue("@CVE_CLIE", dt_encabezado.Rows(0)(2))
                _cmd_ins_bita_cargoxdev.Parameters.AddWithValue("@CVE_CAMPANIA", "_SAE_")
                _cmd_ins_bita_cargoxdev.Parameters.AddWithValue("@CVE_ACTIVIDAD", "   12")
                _cmd_ins_bita_cargoxdev.Parameters.AddWithValue("@FECHAHORA", DateTime.Now)
                _cmd_ins_bita_cargoxdev.Parameters.AddWithValue("@CVE_USUARIO", 0)
                _cmd_ins_bita_cargoxdev.Parameters.AddWithValue("@OBSERVACIONES", "No.[] L " & Convert.ToDouble(dt_encabezado.Rows(0)(5)))
                _cmd_ins_bita_cargoxdev.Parameters.AddWithValue("@STATUS", "F")
                _cmd_ins_bita_cargoxdev.Parameters.AddWithValue("@NOM_USUARIO", "nc-rpt")
                _cmd_ins_bita_cargoxdev.Transaction = mitransacion
                _cmd_ins_bita_cargoxdev.ExecuteNonQuery()

                Dim _query_control2_cargoxdev As New StringBuilder
                _query_control2_cargoxdev.Append("UPDATE [SAE60Empre08].[dbo].[TBLCONTROL08] ")
                _query_control2_cargoxdev.Append(" SET [ULT_CVE] = ULT_CVE + 1 ")
                _query_control2_cargoxdev.Append("WHERE [ID_TABLA] = 62 ")
                Dim _cmd_control2_cargoxdev As New SqlCommand(_query_control2_cargoxdev.ToString, miconexion)
                _cmd_control2_cargoxdev.Transaction = mitransacion
                _cmd_control2_cargoxdev.ExecuteNonQuery()
            End If

            'PARTIDAS DEL DOCUMENTO
            For index As Integer = 0 To dt_parfactd.Rows.Count - 1
                'debe ir en cada partida
                Dim _query_doctosig As New StringBuilder

                _query_doctosig.Append("INSERT INTO [SAE60Empre08].[dbo].[DOCTOSIGF08] ")
                _query_doctosig.Append("([TIP_DOC],[CVE_DOC],[ANT_SIG],[TIP_DOC_E] ")
                _query_doctosig.Append(",[CVE_DOC_E],[PARTIDA],[PART_E],[CANT_E]) ")
                _query_doctosig.Append("VALUES ")
                _query_doctosig.Append("('D',@CVE_DOC,'A', 'F',@CVE_DOC_E,@PARTIDA,0,0)")
                Dim _cmd_doctosig As New SqlCommand(_query_doctosig.ToString, miconexion)
                _cmd_doctosig.Parameters.AddWithValue("@CVE_DOC", documento)
                _cmd_doctosig.Parameters.AddWithValue("@CVE_DOC_E", dt_encabezado.Rows(0)(1))
                _cmd_doctosig.Parameters.AddWithValue("@PARTIDA", index + 1)
                _cmd_doctosig.Transaction = mitransacion
                _cmd_doctosig.ExecuteNonQuery()

                Dim _query_par_factd As New StringBuilder
                _query_par_factd.Append("INSERT INTO [SAE60Empre08].[dbo].[PAR_FACTD08] ")
                _query_par_factd.Append("           ([CVE_DOC],[NUM_PAR],[CVE_ART],[CANT],[PXS],[PREC] ")
                _query_par_factd.Append("           ,[COST],[IMPU1],[IMPU2],[IMPU3],[IMPU4],[IMP1APLA] ")
                _query_par_factd.Append("           ,[IMP2APLA],[IMP3APLA],[IMP4APLA],[TOTIMP1],[TOTIMP2] ")
                _query_par_factd.Append("           ,[TOTIMP3],[TOTIMP4],[DESC1],[DESC2],[DESC3],[COMI] ")
                _query_par_factd.Append("           ,[APAR],[ACT_INV],[NUM_ALM],[TIP_CAM] ")
                _query_par_factd.Append("           ,[UNI_VENTA],[TIPO_PROD],[CVE_OBS],[REG_SERIE],[E_LTPD] ")
                _query_par_factd.Append("           ,[TIPO_ELEM],[NUM_MOV],[TOT_PARTIDA],[IMPRIMIR]) ")
                _query_par_factd.Append("VALUES    (@CVE_DOC,@NUM_PAR,@CVE_ART,@CANT,@PXS,@PREC,0,0,0, ")
                _query_par_factd.Append("           0,@IMPU4,0,0,0,0,0, 0,0,@TOTIMP4,0,0,0,0,0,'S',@NUM_ALM, ")
                _query_par_factd.Append("           1,@UNI_VENTA,'S',0,0,0,'N',0,@TOT_PARTIDA,'S')")
                Dim _cmd_par_factd As New SqlCommand(_query_par_factd.ToString, miconexion)
                _cmd_par_factd.Parameters.AddWithValue("@CVE_DOC", documento)
                _cmd_par_factd.Parameters.AddWithValue("@NUM_PAR", index + 1)
                _cmd_par_factd.Parameters.AddWithValue("@CVE_ART", dt_parfactd.Rows(index)(0))
                _cmd_par_factd.Parameters.AddWithValue("@CANT", dt_parfactd.Rows(index)(1))
                _cmd_par_factd.Parameters.AddWithValue("@PXS", dt_parfactd.Rows(index)(2))
                _cmd_par_factd.Parameters.AddWithValue("@PREC", dt_parfactd.Rows(index)(3))
                _cmd_par_factd.Parameters.AddWithValue("@IMPU4", dt_parfactd.Rows(index)(4))
                _cmd_par_factd.Parameters.AddWithValue("@TOTIMP4", dt_parfactd.Rows(index)(5))
                _cmd_par_factd.Parameters.AddWithValue("@NUM_ALM", dt_encabezado.Rows(0)(3))
                _cmd_par_factd.Parameters.AddWithValue("@UNI_VENTA", dt_parfactd.Rows(index)(6))
                _cmd_par_factd.Parameters.AddWithValue("@TOT_PARTIDA", dt_parfactd.Rows(index)(7))
                _cmd_par_factd.Transaction = mitransacion
                _cmd_par_factd.ExecuteNonQuery()

                Dim _query_par_factd_clib As New StringBuilder
                _query_par_factd_clib.Append("INSERT INTO [SAE60Empre08].[dbo].[PAR_FACTD_CLIB08] ")
                _query_par_factd_clib.Append("([CLAVE_DOC],[NUM_PART]) ")
                _query_par_factd_clib.Append("VALUES(@CLAVE_DOC, @NUM_PART)")
                Dim _cmd_par_factd_clib As New SqlCommand(_query_par_factd_clib.ToString, miconexion)
                _cmd_par_factd_clib.Parameters.AddWithValue("@CLAVE_DOC", documento)
                _cmd_par_factd_clib.Parameters.AddWithValue("@NUM_PART", index + 1)
                _cmd_par_factd_clib.Transaction = mitransacion
                _cmd_par_factd_clib.ExecuteNonQuery()
            Next

            Dim _query_control1 As New StringBuilder
            _query_control1.Append("UPDATE [SAE60Empre08].[dbo].[TBLCONTROL08] ")
            _query_control1.Append(" SET [ULT_CVE] = ULT_CVE + 1 ")
            _query_control1.Append("WHERE [ID_TABLA] = 32 ")
            Dim _cmd_control1 As New SqlCommand(_query_control1.ToString, miconexion)
            _cmd_control1.Transaction = mitransacion
            _cmd_control1.ExecuteNonQuery()

            Dim _query_control2 As New StringBuilder
            _query_control2.Append("UPDATE [SAE60Empre08].[dbo].[TBLCONTROL08] ")
            _query_control2.Append(" SET [ULT_CVE] = ULT_CVE + 1 ")
            _query_control2.Append("WHERE [ID_TABLA] = 62 ")
            Dim _cmd_control2 As New SqlCommand(_query_control2.ToString, miconexion)
            _cmd_control2.Transaction = mitransacion
            _cmd_control2.ExecuteNonQuery()

            Dim _query_foliosf As New StringBuilder
            _query_foliosf.Append("UPDATE [SAE60Empre08].[dbo].[FOLIOSF08] ")
            _query_foliosf.Append(" SET [ULT_DOC] = ULT_DOC +1 ")
            _query_foliosf.Append("WHERE [SERIE] = @SERIE")
            Dim _cmd_foliosf As New SqlCommand(_query_foliosf.ToString, miconexion)
            _cmd_foliosf.Parameters.AddWithValue("@SERIE", serie)
            _cmd_foliosf.Transaction = mitransacion
            _cmd_foliosf.ExecuteNonQuery()

            mitransacion.Commit()
            miconexion.Close()
            variable_error = "correcto"

        Catch ex As Exception
            mitransacion.Rollback()
            miconexion.Close()
            variable_error = ex.Message
        End Try

        Return variable_error
    End Function

    Public Function get_fecha_limite() As Date
        Dim query As New StringBuilder
        query.Append("SELECT FECHALIMDEMOV ")
        query.Append("FROM SAE60Empre05.dbo.PARAM_CLIENTES05 ")
        Dim miconexion As New SqlConnection(conexion.CadenaSQL)
        Dim micomando As New SqlCommand(query.ToString, miconexion)
        miconexion.Open()

        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        miconexion.Close()
        Dim fecha_limite As Date

        If dt.Rows.Count <= 0 Then
            fecha_limite = Now.Date.AddDays(1)
        Else
            fecha_limite = dt.Rows(0)(0)
        End If
        Return fecha_limite
    End Function

    Public Function get_fecha_limite_dimosa() As Date
        Dim query As New StringBuilder
        query.Append("SELECT FECHALIMDEMOV ")
        query.Append("FROM SAE60Empre06.dbo.PARAM_CLIENTES06 ")
        Dim miconexion As New SqlConnection(conexion_dimosa.CadenaSQL)
        Dim micomando As New SqlCommand(query.ToString, miconexion)
        miconexion.Open()

        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        miconexion.Close()
        Dim fecha_limite As Date

        If dt.Rows.Count <= 0 Then
            fecha_limite = Now.Date.AddDays(1)
        Else
            fecha_limite = dt.Rows(0)(0)
        End If
        Return fecha_limite
    End Function

    Public Function guardar_datos_local(ByVal dt_encabezado As DataTable, ByVal dt_partida As DataTable, ByVal RFC As String, _
                    ByVal dt_parfactd As DataTable, ByVal sub_total As Double, ByVal tot_isv As Double, _
                    ByVal fecha_entrega As DateTime, ByVal fecha_doc As Date) As String
        Dim mitransacion As SqlTransaction
        Dim miconexion As New SqlConnection(conexion.CadenaSQL)
        Dim variable_error As String = ""
        miconexion.Open()
        mitransacion = miconexion.BeginTransaction
        Try
            Dim query_folios As New StringBuilder
            query_folios.Append("SELECT FOLIO + CONVERT(VARCHAR, ULT_DOC + 1) AS DOCTO, SERIE, TIPO ")
            query_folios.Append("FROM folios ")
            query_folios.Append("WHERE NUM_ALMA = @ALMACEN ")

            Dim comand_folio As New SqlCommand(query_folios.ToString, miconexion)
            comand_folio.Parameters.AddWithValue("@ALMACEN", dt_encabezado.Rows(0)(3))
            comand_folio.Transaction = mitransacion
            Dim adaptador_folios As New SqlDataAdapter(comand_folio)
            Dim dt_folios As New DataTable
            adaptador_folios.Fill(dt_folios)

            Dim docto As String
            Dim serie_local As String = ""
            Dim tipo_camplib20 As String = ""
            docto = dt_folios.Rows(0)(0)
            serie_local = dt_folios.Rows(0)(1)

            If dt_encabezado.Rows(0)(4) = "CREDITO" Then
                tipo_camplib20 = "N" + dt_folios.Rows(0)(2)
            Else
                tipo_camplib20 = "D" + dt_folios.Rows(0)(2)
            End If


            Dim query2 As New StringBuilder
            query2.Append("INSERT INTO [tactical_discount_SanRafael].[dbo].[encabezados] ")
            query2.Append("([CODIGO],[VENDEDOR],[FACTURA],[CLIENTE],[ALMACEN],[TIPO],[IMPORTE], ")
            query2.Append("[ESTADO],[FECHA],[FECHA_SAE],[RFC],[FECHA_ENTREGA],[CAMPLIB20]) ")
            query2.Append("VALUES (@CODIGO,@VENDEDOR,@FACTURA,@CLIENTE,@ALMACEN,@TIPO,@IMPORTE,@ESTADO,@FECHA,@FECHA_SAE,@RFC,@FECHA_ENTREGA,@CAMPLIB20) ")

            Dim micomando2 As New SqlCommand(query2.ToString, miconexion)
            micomando2.Parameters.AddWithValue("@CODIGO", docto)
            micomando2.Parameters.AddWithValue("@VENDEDOR", dt_encabezado.Rows(0)(0))
            micomando2.Parameters.AddWithValue("@FACTURA", dt_encabezado.Rows(0)(1))
            micomando2.Parameters.AddWithValue("@CLIENTE", dt_encabezado.Rows(0)(2))
            micomando2.Parameters.AddWithValue("@ALMACEN", dt_encabezado.Rows(0)(3))
            micomando2.Parameters.AddWithValue("@TIPO", dt_encabezado.Rows(0)(4))
            micomando2.Parameters.AddWithValue("@IMPORTE", dt_encabezado.Rows(0)(5))
            micomando2.Parameters.AddWithValue("@ESTADO", "SIN ENVIAR")
            micomando2.Parameters.AddWithValue("@FECHA", Convert.ToDateTime(dt_encabezado.Rows(0)(7)).Date)


            micomando2.Parameters.AddWithValue("@FECHA_SAE", fecha_doc)
            micomando2.Parameters.AddWithValue("@RFC", RFC)
            micomando2.Parameters.AddWithValue("@FECHA_ENTREGA", fecha_entrega)
            micomando2.Parameters.AddWithValue("@CAMPLIB20", tipo_camplib20)

            micomando2.Transaction = mitransacion
            micomando2.ExecuteNonQuery()


            For i As Integer = 0 To dt_partida.Rows.Count - 1
                Dim query As New StringBuilder
                query.Append("UPDATE presupuestos ")
                query.Append("SET Restante = Restante - @VALOR ")
                query.Append("WHERE AñoId = @AÑO AND MesId = @MES AND ProveedorId = @PROVEEDOR")

                Dim micomando As New SqlCommand(query.ToString, miconexion)
                micomando.Parameters.AddWithValue("@VALOR", dt_partida.Rows(i)(3))
                micomando.Parameters.AddWithValue("@AÑO", Convert.ToDateTime(dt_encabezado.Rows(0)(7)).Year)
                micomando.Parameters.AddWithValue("@MES", Convert.ToDateTime(dt_encabezado.Rows(0)(7)).Month)
                micomando.Parameters.AddWithValue("@PROVEEDOR", dt_partida.Rows(i)(4))
                micomando.Transaction = mitransacion
                micomando.ExecuteNonQuery()

                Dim query3 As New StringBuilder
                query3.Append("INSERT INTO [tactical_discount_SanRafael].[dbo].[partidas] ")
                query3.Append("([CODIGO],[NUM_PART],[CVE_ART],[CANTIDAD],[MONTO],[PROVEEDOR],[CONCEPTO],[ISV],[SUBTOTAL],[CONCEPTO_PROVEEDOR]) ")
                query3.Append("VALUES(@CODIGO, @NUM_PART, @CVE_ART, @CANTIDAD, @MONTO,@PROVEEDOR,@CONCEPTO,@ISV,@SUBTOTAL,@CONCEPTO_PROVEEDOR) ")

                Dim micomando3 As New SqlCommand(query3.ToString, miconexion)
                micomando3.Parameters.AddWithValue("@CODIGO", docto)
                micomando3.Parameters.AddWithValue("@NUM_PART", dt_partida.Rows(i)(0))
                micomando3.Parameters.AddWithValue("@CVE_ART", dt_partida.Rows(i)(1))
                micomando3.Parameters.AddWithValue("@CANTIDAD", dt_partida.Rows(i)(2))
                micomando3.Parameters.AddWithValue("@MONTO", dt_partida.Rows(i)(3))
                micomando3.Parameters.AddWithValue("@PROVEEDOR", dt_partida.Rows(i)(4))
                micomando3.Parameters.AddWithValue("@CONCEPTO", dt_partida.Rows(i)(5))
                micomando3.Parameters.AddWithValue("@ISV", dt_partida.Rows(i)(6))
                micomando3.Parameters.AddWithValue("@SUBTOTAL", dt_partida.Rows(i)(7))
                micomando3.Parameters.AddWithValue("@CONCEPTO_PROVEEDOR", dt_partida.Rows(i)(8))
                micomando3.Transaction = mitransacion
                micomando3.ExecuteNonQuery()
            Next

            Dim upd_folios As New StringBuilder
            upd_folios.Append("UPDATE [folios]  ")
            upd_folios.Append("SET [ULT_DOC] = ULT_DOC + 1 ")
            upd_folios.Append("WHERE NUM_ALMA = @ALMACEN ")
            Dim comand_upd_folio As New SqlCommand(upd_folios.ToString, miconexion)
            comand_upd_folio.Parameters.AddWithValue("@ALMACEN", dt_encabezado.Rows(0)(3))
            comand_upd_folio.Transaction = mitransacion
            comand_upd_folio.ExecuteNonQuery()
            mitransacion.Commit()
            miconexion.Close()
            variable_error = "correcto"

        Catch ex As Exception
            mitransacion.Rollback()
            miconexion.Close()
            variable_error = ex.Message
        End Try

        Return variable_error
    End Function

    Public Function guardar_datos_local_dimosa(ByVal dt_encabezado As DataTable, ByVal dt_partida As DataTable, ByVal RFC As String, _
                    ByVal dt_parfactd As DataTable, ByVal sub_total As Double, ByVal tot_isv As Double, _
                    ByVal fecha_entrega As DateTime, ByVal fecha_doc As Date) As String
        Dim mitransacion As SqlTransaction
        Dim miconexion As New SqlConnection(conexion_dimosa.CadenaSQL)
        Dim variable_error As String = ""
        miconexion.Open()
        mitransacion = miconexion.BeginTransaction
        Try
            Dim query_folios As New StringBuilder
            query_folios.Append("SELECT FOLIO + CONVERT(VARCHAR, ULT_DOC + 1) AS DOCTO, SERIE, TIPO ")
            query_folios.Append("FROM folios ")
            query_folios.Append("WHERE NUM_ALMA = @ALMACEN ")

            Dim comand_folio As New SqlCommand(query_folios.ToString, miconexion)
            comand_folio.Parameters.AddWithValue("@ALMACEN", dt_encabezado.Rows(0)(3))
            comand_folio.Transaction = mitransacion
            Dim adaptador_folios As New SqlDataAdapter(comand_folio)
            Dim dt_folios As New DataTable
            adaptador_folios.Fill(dt_folios)

            Dim docto As String
            Dim serie_local As String = ""
            Dim tipo_camplib20 As String = ""
            docto = dt_folios.Rows(0)(0)
            serie_local = dt_folios.Rows(0)(1)

            If dt_encabezado.Rows(0)(4) = "CREDITO" Then
                tipo_camplib20 = "N" + dt_folios.Rows(0)(2)
            Else
                tipo_camplib20 = "D" + dt_folios.Rows(0)(2)
            End If


            Dim query2 As New StringBuilder
            query2.Append("INSERT INTO [tactical_discount_dimosa].[dbo].[encabezados] ")
            query2.Append("([CODIGO],[VENDEDOR],[FACTURA],[CLIENTE],[ALMACEN],[TIPO],[IMPORTE], ")
            query2.Append("[ESTADO],[FECHA],[FECHA_SAE],[RFC],[FECHA_ENTREGA],[CAMPLIB20]) ")
            query2.Append("VALUES (@CODIGO,@VENDEDOR,@FACTURA,@CLIENTE,@ALMACEN,@TIPO,@IMPORTE,@ESTADO,@FECHA,@FECHA_SAE,@RFC,@FECHA_ENTREGA,@CAMPLIB20) ")

            Dim micomando2 As New SqlCommand(query2.ToString, miconexion)
            micomando2.Parameters.AddWithValue("@CODIGO", docto)
            micomando2.Parameters.AddWithValue("@VENDEDOR", dt_encabezado.Rows(0)(0))
            micomando2.Parameters.AddWithValue("@FACTURA", dt_encabezado.Rows(0)(1))
            micomando2.Parameters.AddWithValue("@CLIENTE", dt_encabezado.Rows(0)(2))
            micomando2.Parameters.AddWithValue("@ALMACEN", dt_encabezado.Rows(0)(3))
            micomando2.Parameters.AddWithValue("@TIPO", dt_encabezado.Rows(0)(4))
            micomando2.Parameters.AddWithValue("@IMPORTE", dt_encabezado.Rows(0)(5))
            micomando2.Parameters.AddWithValue("@ESTADO", "SIN ENVIAR")
            micomando2.Parameters.AddWithValue("@FECHA", Convert.ToDateTime(dt_encabezado.Rows(0)(7)).Date)


            micomando2.Parameters.AddWithValue("@FECHA_SAE", fecha_doc)
            micomando2.Parameters.AddWithValue("@RFC", RFC)
            micomando2.Parameters.AddWithValue("@FECHA_ENTREGA", fecha_entrega)
            micomando2.Parameters.AddWithValue("@CAMPLIB20", tipo_camplib20)

            micomando2.Transaction = mitransacion
            micomando2.ExecuteNonQuery()


            For i As Integer = 0 To dt_partida.Rows.Count - 1
                Dim query As New StringBuilder
                query.Append("UPDATE presupuestos ")
                query.Append("SET Restante = Restante - @VALOR ")
                query.Append("WHERE AñoId = @AÑO AND MesId = @MES AND ProveedorId = @PROVEEDOR")

                Dim micomando As New SqlCommand(query.ToString, miconexion)
                micomando.Parameters.AddWithValue("@VALOR", dt_partida.Rows(i)(3))
                micomando.Parameters.AddWithValue("@AÑO", Convert.ToDateTime(dt_encabezado.Rows(0)(7)).Year)
                micomando.Parameters.AddWithValue("@MES", Convert.ToDateTime(dt_encabezado.Rows(0)(7)).Month)
                micomando.Parameters.AddWithValue("@PROVEEDOR", dt_partida.Rows(i)(4))
                micomando.Transaction = mitransacion
                micomando.ExecuteNonQuery()

                Dim query3 As New StringBuilder
                query3.Append("INSERT INTO [tactical_discount_dimosa].[dbo].[partidas] ")
                query3.Append("([CODIGO],[NUM_PART],[CVE_ART],[CANTIDAD],[MONTO],[PROVEEDOR],[CONCEPTO],[ISV],[SUBTOTAL],[CONCEPTO_PROVEEDOR]) ")
                query3.Append("VALUES(@CODIGO, @NUM_PART, @CVE_ART, @CANTIDAD, @MONTO,@PROVEEDOR,@CONCEPTO,@ISV,@SUBTOTAL,@CONCEPTO_PROVEEDOR) ")

                Dim micomando3 As New SqlCommand(query3.ToString, miconexion)
                micomando3.Parameters.AddWithValue("@CODIGO", docto)
                micomando3.Parameters.AddWithValue("@NUM_PART", dt_partida.Rows(i)(0))
                micomando3.Parameters.AddWithValue("@CVE_ART", dt_partida.Rows(i)(1))
                micomando3.Parameters.AddWithValue("@CANTIDAD", dt_partida.Rows(i)(2))
                micomando3.Parameters.AddWithValue("@MONTO", dt_partida.Rows(i)(3))
                micomando3.Parameters.AddWithValue("@PROVEEDOR", dt_partida.Rows(i)(4))
                micomando3.Parameters.AddWithValue("@CONCEPTO", dt_partida.Rows(i)(5))
                micomando3.Parameters.AddWithValue("@ISV", dt_partida.Rows(i)(6))
                micomando3.Parameters.AddWithValue("@SUBTOTAL", dt_partida.Rows(i)(7))
                micomando3.Parameters.AddWithValue("@CONCEPTO_PROVEEDOR", dt_partida.Rows(i)(8))
                micomando3.Transaction = mitransacion
                micomando3.ExecuteNonQuery()
            Next

            Dim upd_folios As New StringBuilder
            upd_folios.Append("UPDATE [folios]  ")
            upd_folios.Append("SET [ULT_DOC] = ULT_DOC + 1 ")
            upd_folios.Append("WHERE NUM_ALMA = @ALMACEN ")
            Dim comand_upd_folio As New SqlCommand(upd_folios.ToString, miconexion)
            comand_upd_folio.Parameters.AddWithValue("@ALMACEN", dt_encabezado.Rows(0)(3))
            comand_upd_folio.Transaction = mitransacion
            comand_upd_folio.ExecuteNonQuery()
            mitransacion.Commit()
            miconexion.Close()
            variable_error = "correcto"

        Catch ex As Exception
            mitransacion.Rollback()
            miconexion.Close()
            variable_error = ex.Message
        End Try

        Return variable_error
    End Function


    Public Function guardar_datos_local_opl(ByVal dt_encabezado As DataTable, ByVal dt_partida As DataTable, ByVal RFC As String,
                    ByVal dt_parfactd As DataTable, ByVal sub_total As Double, ByVal tot_isv As Double,
                    ByVal fecha_entrega As DateTime, ByVal fecha_doc As Date) As String
        Dim mitransacion As SqlTransaction
        Dim miconexion As New SqlConnection(conexion_Descuentos_Opl.CadenaSQL)
        Dim variable_error As String = ""
        miconexion.Open()
        mitransacion = miconexion.BeginTransaction
        Try
            Dim query_folios As New StringBuilder
            query_folios.Append("SELECT FOLIO + CONVERT(VARCHAR, ULT_DOC + 1) AS DOCTO, SERIE, TIPO ")
            query_folios.Append("FROM folios ")
            query_folios.Append("WHERE NUM_ALMA = @ALMACEN ")

            Dim comand_folio As New SqlCommand(query_folios.ToString, miconexion)
            comand_folio.Parameters.AddWithValue("@ALMACEN", dt_encabezado.Rows(0)(3))
            comand_folio.Transaction = mitransacion
            Dim adaptador_folios As New SqlDataAdapter(comand_folio)
            Dim dt_folios As New DataTable
            adaptador_folios.Fill(dt_folios)

            Dim docto As String
            Dim serie_local As String = ""
            Dim tipo_camplib20 As String = ""
            docto = dt_folios.Rows(0)(0)
            serie_local = dt_folios.Rows(0)(1)

            If dt_encabezado.Rows(0)(4) = "CREDITO" Then
                tipo_camplib20 = "N" + dt_folios.Rows(0)(2)
            Else
                tipo_camplib20 = "D" + dt_folios.Rows(0)(2)
            End If


            Dim query2 As New StringBuilder
            query2.Append("INSERT INTO [tactical_discount_opl].[dbo].[encabezados] ")
            query2.Append("([CODIGO],[VENDEDOR],[FACTURA],[CLIENTE],[ALMACEN],[TIPO],[IMPORTE], ")
            query2.Append("[ESTADO],[FECHA],[FECHA_SAE],[RFC],[FECHA_ENTREGA],[CAMPLIB20]) ")
            query2.Append("VALUES (@CODIGO,@VENDEDOR,@FACTURA,@CLIENTE,@ALMACEN,@TIPO,@IMPORTE,@ESTADO,@FECHA,@FECHA_SAE,@RFC,@FECHA_ENTREGA,@CAMPLIB20) ")

            Dim micomando2 As New SqlCommand(query2.ToString, miconexion)
            micomando2.Parameters.AddWithValue("@CODIGO", docto)
            micomando2.Parameters.AddWithValue("@VENDEDOR", dt_encabezado.Rows(0)(0))
            micomando2.Parameters.AddWithValue("@FACTURA", dt_encabezado.Rows(0)(1))
            micomando2.Parameters.AddWithValue("@CLIENTE", dt_encabezado.Rows(0)(2))
            micomando2.Parameters.AddWithValue("@ALMACEN", dt_encabezado.Rows(0)(3))
            micomando2.Parameters.AddWithValue("@TIPO", dt_encabezado.Rows(0)(4))
            micomando2.Parameters.AddWithValue("@IMPORTE", dt_encabezado.Rows(0)(5))
            micomando2.Parameters.AddWithValue("@ESTADO", "SIN ENVIAR")
            micomando2.Parameters.AddWithValue("@FECHA", Convert.ToDateTime(dt_encabezado.Rows(0)(7)).Date)


            micomando2.Parameters.AddWithValue("@FECHA_SAE", fecha_doc)
            micomando2.Parameters.AddWithValue("@RFC", RFC)
            micomando2.Parameters.AddWithValue("@FECHA_ENTREGA", fecha_entrega)
            micomando2.Parameters.AddWithValue("@CAMPLIB20", tipo_camplib20)

            micomando2.Transaction = mitransacion
            micomando2.ExecuteNonQuery()


            For i As Integer = 0 To dt_partida.Rows.Count - 1
                Dim query As New StringBuilder
                query.Append("UPDATE presupuestos ")
                query.Append("SET Restante = Restante - @VALOR ")
                query.Append("WHERE AñoId = @AÑO AND MesId = @MES AND ProveedorId = @PROVEEDOR")

                Dim micomando As New SqlCommand(query.ToString, miconexion)
                micomando.Parameters.AddWithValue("@VALOR", dt_partida.Rows(i)(3))
                micomando.Parameters.AddWithValue("@AÑO", Convert.ToDateTime(dt_encabezado.Rows(0)(7)).Year)
                micomando.Parameters.AddWithValue("@MES", Convert.ToDateTime(dt_encabezado.Rows(0)(7)).Month)
                micomando.Parameters.AddWithValue("@PROVEEDOR", dt_partida.Rows(i)(4))
                micomando.Transaction = mitransacion
                micomando.ExecuteNonQuery()

                Dim query3 As New StringBuilder
                query3.Append("INSERT INTO [tactical_discount_opl].[dbo].[partidas] ")
                query3.Append("([CODIGO],[NUM_PART],[CVE_ART],[CANTIDAD],[MONTO],[PROVEEDOR],[CONCEPTO],[ISV],[SUBTOTAL],[CONCEPTO_PROVEEDOR]) ")
                query3.Append("VALUES(@CODIGO, @NUM_PART, @CVE_ART, @CANTIDAD, @MONTO,@PROVEEDOR,@CONCEPTO,@ISV,@SUBTOTAL,@CONCEPTO_PROVEEDOR) ")

                Dim micomando3 As New SqlCommand(query3.ToString, miconexion)
                micomando3.Parameters.AddWithValue("@CODIGO", docto)
                micomando3.Parameters.AddWithValue("@NUM_PART", dt_partida.Rows(i)(0))
                micomando3.Parameters.AddWithValue("@CVE_ART", dt_partida.Rows(i)(1))
                micomando3.Parameters.AddWithValue("@CANTIDAD", dt_partida.Rows(i)(2))
                micomando3.Parameters.AddWithValue("@MONTO", dt_partida.Rows(i)(3))
                micomando3.Parameters.AddWithValue("@PROVEEDOR", dt_partida.Rows(i)(4))
                micomando3.Parameters.AddWithValue("@CONCEPTO", dt_partida.Rows(i)(5))
                micomando3.Parameters.AddWithValue("@ISV", dt_partida.Rows(i)(6))
                micomando3.Parameters.AddWithValue("@SUBTOTAL", dt_partida.Rows(i)(7))
                micomando3.Parameters.AddWithValue("@CONCEPTO_PROVEEDOR", dt_partida.Rows(i)(8))
                micomando3.Transaction = mitransacion
                micomando3.ExecuteNonQuery()
            Next

            Dim upd_folios As New StringBuilder
            upd_folios.Append("UPDATE [folios]  ")
            upd_folios.Append("SET [ULT_DOC] = ULT_DOC + 1 ")
            upd_folios.Append("WHERE NUM_ALMA = @ALMACEN ")
            Dim comand_upd_folio As New SqlCommand(upd_folios.ToString, miconexion)
            comand_upd_folio.Parameters.AddWithValue("@ALMACEN", dt_encabezado.Rows(0)(3))
            comand_upd_folio.Transaction = mitransacion
            comand_upd_folio.ExecuteNonQuery()
            mitransacion.Commit()
            miconexion.Close()
            variable_error = "correcto"

        Catch ex As Exception
            mitransacion.Rollback()
            miconexion.Close()
            variable_error = ex.Message
        End Try

        Return variable_error
    End Function

    Public Function get_estado_nc(ByVal CVE_DOC As String) As DataTable
        Dim query As New StringBuilder
        query.Append("SELECT STATUS, ISNULL(CTLPOL,0) FROM SAE60Empre05.dbo.FACTD05 WHERE (CVE_DOC = @CVE_DOC)")
        Dim miconexion As New SqlConnection(conexion.CadenaSQL)
        Dim micomando As New SqlCommand(query.ToString, miconexion)
        micomando.Parameters.AddWithValue("@CVE_DOC", CVE_DOC)
        miconexion.Open()
        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        miconexion.Close()
        Return dt
    End Function

    Public Function get_estado_nc_dimosa(ByVal CVE_DOC As String) As DataTable
        Dim query As New StringBuilder
        query.Append("SELECT STATUS, ISNULL(CTLPOL,0) FROM SAE60Empre06.dbo.FACTD06 WHERE (CVE_DOC = @CVE_DOC)")
        Dim miconexion As New SqlConnection(conexion_dimosa.CadenaSQL)
        Dim micomando As New SqlCommand(query.ToString, miconexion)
        micomando.Parameters.AddWithValue("@CVE_DOC", CVE_DOC)
        miconexion.Open()
        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        miconexion.Close()
        Return dt
    End Function

    Public Function get_estado_nc_opl(ByVal CVE_DOC As String) As DataTable
        Dim query As New StringBuilder
        query.Append("SELECT STATUS, ISNULL(CTLPOL,0) FROM SAE60Empre08.dbo.FACTD08 WHERE (CVE_DOC = @CVE_DOC)")
        Dim miconexion As New SqlConnection(conexion_dimosa.CadenaSQL)
        Dim micomando As New SqlCommand(query.ToString, miconexion)
        micomando.Parameters.AddWithValue("@CVE_DOC", CVE_DOC)
        miconexion.Open()
        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        miconexion.Close()
        Return dt
    End Function

    Public Function eliminar_nc_sae(ByVal CVE_DOC As String, ByVal CLIENTE As String, ByVal MONTO As Double, ByVal CODIGO_LOCAL As String, _
                                    ByVal TIPO As String, ByVal DOCUMENTO2 As String, ByVal ctlpol As String, ByVal num_poliz As String, _
                                    ByVal nyear As Integer, ByVal nmes As Integer, ByVal tipo_poliza As String, ByVal tabla As DataTable, _
                                    ByVal tiene_interface As String, ByVal contabilizado As String, ByVal FACTURA As String, ByVal USUARIO As String, _
                                    ByVal tiene_interface_c31 As String, ByVal ctlpol_C31 As String, ByVal nyear_C31 As Integer, _
                                    ByVal nmes_C31 As Integer, ByVal contabilizado_C31 As String, ByVal tipo_poliza_C31 As String, _
                                    ByVal tabla_C31 As DataTable, ByVal num_poliz_C31 As String)
        Dim mitransacion As SqlTransaction
        Dim miconexion As New SqlConnection(conexion.CadenaSQL)

        Dim mitransaccion_coi As SqlTransaction
        Dim miconexion_coi As New SqlConnection(conexion_coi_san_rafael.CadenaSQL)

        Dim variable_error As String = ""
        miconexion.Open()
        miconexion_coi.Open()

        mitransacion = miconexion.BeginTransaction
        mitransaccion_coi = miconexion_coi.BeginTransaction

        Try
            Dim query2 As New StringBuilder
            query2.Append("UPDATE SAE60Empre05.dbo.FACTD05 SET [STATUS] = 'C' WHERE CVE_DOC = @CVE_DOC")
            Dim micomando2 As New SqlCommand(query2.ToString, miconexion)
            micomando2.Parameters.AddWithValue("@CVE_DOC", CVE_DOC)
            micomando2.Transaction = mitransacion
            micomando2.ExecuteNonQuery()

            Dim query4 As New StringBuilder
            query4.Append("DELETE FROM SAE60Empre05.dbo.CUEN_DET05 WHERE DOCTO = @DOCTO AND NUM_CPTO = 12 ")
            Dim micomando4 As New SqlCommand(query4.ToString, miconexion)
            micomando4.Parameters.AddWithValue("@DOCTO", CVE_DOC)
            micomando4.Transaction = mitransacion
            micomando4.ExecuteNonQuery()

            If TIPO.ToUpper = "CONTADO" Then
                Dim query5 As New StringBuilder
                query5.Append("DELETE FROM SAE60Empre05.dbo.CUEN_DET05 WHERE DOCTO = @DOCTO AND NUM_CPTO = 31 ")
                Dim micomando5 As New SqlCommand(query5.ToString, miconexion)
                micomando5.Parameters.AddWithValue("@DOCTO", CVE_DOC)
                micomando5.Transaction = mitransacion
                micomando5.ExecuteNonQuery()

                'Dim query510 As New StringBuilder
                'query510.Append("DELETE FROM SAE60Empre05.dbo.CUEN_DET05 WHERE DOCTO = @DOCTO AND NUM_CPTO = 31 ")
                'Dim micomando510 As New SqlCommand(query5.ToString, miconexion)
                'micomando510.Parameters.AddWithValue("@DOCTO", DOCUMENTO2)
                'micomando510.Transaction = mitransacion
                'micomando510.ExecuteNonQuery()

                'quitar concepto 31'
                If tiene_interface_c31 = "Si" Then
                    'eliminar interface en SAE
                    Dim qx_int_coi_C31 = New StringBuilder()
                    qx_int_coi_C31.Append("DELETE FROM [SAE60Empre05].[dbo].[INTCOI05] WHERE CTLPOL = @CTLPOL ")
                    Dim cmd_int_coi_C31 = New SqlCommand(qx_int_coi_C31.ToString(), miconexion)
                    cmd_int_coi_C31.Transaction = mitransacion
                    cmd_int_coi_C31.Parameters.AddWithValue("@CTLPOL", ctlpol_C31)
                    cmd_int_coi_C31.ExecuteNonQuery()

                    'desenlazar doctos de la interface
                    Dim qx_factd_C31 = New StringBuilder()
                    qx_factd_C31.Append(" UPDATE [SAE60Empre05].[dbo].[CUEN_DET05] SET CTLPOL = 0, AFEC_COI = '' WHERE CTLPOL = @CTLPOL ")
                    Dim cmd_factd_C31 = New SqlCommand(qx_factd_C31.ToString(), miconexion)
                    cmd_factd_C31.Transaction = mitransacion
                    cmd_factd_C31.Parameters.AddWithValue("@CTLPOL", ctlpol_C31)
                    cmd_factd_C31.ExecuteNonQuery()

                    If contabilizado_C31 = "Si" Then

                        Dim year_short_C31 As Integer
                        year_short_C31 = Convert.ToInt32((nyear_C31.ToString()).Substring(2, 2))

                        Dim cero_C31 As String = ""
                        If (nmes_C31.ToString().Length < 2) Then
                            cero_C31 = "0"
                        End If
                        'encabezado de la poliza
                        Dim qx_polizas_C31 = New StringBuilder()
                        qx_polizas_C31.Append("UPDATE [COI70Empre08].[dbo].[POLIZAS" + year_short_C31.ToString + "08] ")
                        qx_polizas_C31.Append("   SET [CONCEP_PO] = @CONCEP_PO ")
                        qx_polizas_C31.Append("WHERE  [TIPO_POLI] = @TIPO_POLI AND LTRIM([NUM_POLIZ]) = @NUM_POLIZ ")
                        qx_polizas_C31.Append("   AND [PERIODO] = @PERIODO AND [EJERCICIO] = @EJERCICIO AND [ORIGEN] = @ORIGEN ")
                        Dim cmd_polizas_C31 = New SqlCommand(qx_polizas_C31.ToString(), miconexion_coi)
                        cmd_polizas_C31.Transaction = mitransaccion_coi
                        cmd_polizas_C31.Parameters.AddWithValue("@CONCEP_PO", "Nula")
                        cmd_polizas_C31.Parameters.AddWithValue("@TIPO_POLI", tipo_poliza_C31)
                        cmd_polizas_C31.Parameters.AddWithValue("@NUM_POLIZ", num_poliz_C31)
                        cmd_polizas_C31.Parameters.AddWithValue("@PERIODO", nmes_C31)
                        cmd_polizas_C31.Parameters.AddWithValue("@EJERCICIO", nyear_C31)
                        cmd_polizas_C31.Parameters.AddWithValue("@ORIGEN", "CC COI")
                        cmd_polizas_C31.ExecuteNonQuery()

                        For index = 0 To tabla_C31.Rows.Count - 1
                            'seleccionar la cuenta base
                            Dim qx_catalogo_cuentas = New StringBuilder()
                            qx_catalogo_cuentas.Append("SELECT NUM_CTA, CTA_PAPA, NIVEL FROM CUENTAS" & Convert.ToString(year_short_C31) & "08 WHERE NUM_CTA = @CTA ")
                            Dim cmd_catalogo_cuentas = New SqlCommand(qx_catalogo_cuentas.ToString(), miconexion_coi)
                            cmd_catalogo_cuentas.Parameters.AddWithValue("@CTA", tabla_C31.Rows(index)(3))
                            cmd_catalogo_cuentas.Transaction = mitransaccion_coi
                            Dim adaptador_catalogo_cuentas = New SqlDataAdapter(cmd_catalogo_cuentas)
                            Dim dt_catalogo_cuentas = New DataTable()
                            adaptador_catalogo_cuentas.Fill(dt_catalogo_cuentas)

                            Dim cta_papa As String = ""
                            If dt_catalogo_cuentas.Rows.Count > 0 Then
                                cta_papa = Convert.ToString(dt_catalogo_cuentas.Rows(0)(1))

                                Dim cuentas_afectadas(Convert.ToInt32(dt_catalogo_cuentas.Rows(0)(2))) As String
                                cuentas_afectadas(0) = Convert.ToString(dt_catalogo_cuentas.Rows(0)(0))
                                cuentas_afectadas(1) = cta_papa

                                'seleccionar la raiz de las cuentas que se afectan
                                For i = 0 To Convert.ToInt32(dt_catalogo_cuentas.Rows(0)(2))
                                    Dim qx_cuenta_rel = New StringBuilder()
                                    qx_cuenta_rel.Append("SELECT NUM_CTA, CTA_PAPA, NIVEL FROM CUENTAS" & Convert.ToString(year_short_C31) & "08 WHERE NUM_CTA = '" + cta_papa + "'")
                                    Dim cmd_cuenta_rel = New SqlCommand(qx_cuenta_rel.ToString(), miconexion_coi)
                                    cmd_cuenta_rel.Transaction = mitransaccion_coi
                                    Dim adaptador_cuenta_rel = New SqlDataAdapter(cmd_cuenta_rel)
                                    Dim dt_cuenta_rel = New DataTable()
                                    adaptador_cuenta_rel.Fill(dt_cuenta_rel)
                                    Try
                                        cta_papa = Convert.ToString(dt_cuenta_rel.Rows(0)(1))
                                        cuentas_afectadas(2 + i) = cta_papa
                                    Catch ex As Exception

                                    End Try
                                Next

                                Try
                                    For i = 0 To cuentas_afectadas.Length - 1
                                        Dim qx_actualiza_saldos = New StringBuilder()
                                        qx_actualiza_saldos.Append(" UPDATE [COI70Empre08].[dbo].[SALDOS" & Convert.ToString(year_short_C31) & "08] ")

                                        If tabla_C31.Rows(index)(6) = "D" Then
                                            qx_actualiza_saldos.Append("   SET [CARGO" + cero_C31 + nmes_C31.ToString + "] = [CARGO" + cero_C31 + nmes_C31.ToString + "] - @VALOR ")
                                        ElseIf tabla_C31.Rows(index)(6) = "H" Then
                                            qx_actualiza_saldos.Append("   SET [ABONO" + cero_C31 + nmes_C31.ToString + "] = [ABONO" + cero_C31 + nmes_C31.ToString + "] - @VALOR ")
                                        End If
                                        qx_actualiza_saldos.Append(" WHERE [NUM_CTA] = @NUM_CTA AND [EJERCICIO] = @EJERCICIO ")
                                        Dim cmd_actualiza_saldos = New SqlCommand(qx_actualiza_saldos.ToString(), miconexion_coi)
                                        cmd_actualiza_saldos.Transaction = mitransaccion_coi
                                        cmd_actualiza_saldos.Parameters.AddWithValue("@NUM_CTA", cuentas_afectadas(i))
                                        cmd_actualiza_saldos.Parameters.AddWithValue("@EJERCICIO", nyear_C31)
                                        cmd_actualiza_saldos.Parameters.AddWithValue("@VALOR", Convert.ToDouble(tabla_C31.Rows(index)(7)))
                                        cmd_actualiza_saldos.ExecuteNonQuery()
                                    Next
                                Catch ex As Exception

                                End Try
                                'actualizar saldos de las cuentas
                                'fin de catalogo de cuentas a afectar
                                'fin seleccion de cuentas raiz
                            End If

                            'partidas de la poliza
                            Dim qx_auxiliares = New StringBuilder()
                            qx_auxiliares.Append("UPDATE [COI70Empre08].[dbo].[AUXILIAR" + year_short_C31.ToString + "08] ")
                            qx_auxiliares.Append("SET [MONTOMOV] = 0 ")
                            qx_auxiliares.Append("WHERE [TIPO_POLI] = @TIPO_POLI AND [NUM_POLIZ] = @NUM_POLIZ ")
                            qx_auxiliares.Append("AND [NUM_PART] = @NUM_PART AND [PERIODO] = @PERIODO ")
                            qx_auxiliares.Append("AND [EJERCICIO] = @EJERCICIO AND [NUM_CTA] = @NUM_CTA ")
                            qx_auxiliares.Append("AND [FECHA_POL] = @FECHA_POL ")

                            Dim cmd_ins_auxiliares = New SqlCommand(qx_auxiliares.ToString(), miconexion_coi)
                            cmd_ins_auxiliares.Transaction = mitransaccion_coi
                            cmd_ins_auxiliares.Parameters.AddWithValue("@TIPO_POLI", tabla_C31.Rows(index)(0))
                            cmd_ins_auxiliares.Parameters.AddWithValue("@NUM_POLIZ", tabla_C31.Rows(index)(1))
                            cmd_ins_auxiliares.Parameters.AddWithValue("@NUM_PART", tabla_C31.Rows(index)(2))
                            cmd_ins_auxiliares.Parameters.AddWithValue("@PERIODO", nmes_C31)
                            cmd_ins_auxiliares.Parameters.AddWithValue("@EJERCICIO", nyear_C31)
                            cmd_ins_auxiliares.Parameters.AddWithValue("@NUM_CTA", tabla_C31.Rows(index)(3))
                            cmd_ins_auxiliares.Parameters.AddWithValue("@FECHA_POL", tabla_C31.Rows(index)(4))
                            cmd_ins_auxiliares.ExecuteNonQuery()
                            ' fin partidas de la poliza
                        Next
                    End If
                End If
                'fin de quitar concepto 31'

            Else
                Dim query3 As New StringBuilder
                query3.Append("UPDATE SAE60Empre05.dbo.CLIE05 SET [SALDO] = SALDO + @MONTO WHERE [CLAVE] = @CLAVE")
                Dim micomando3 As New SqlCommand(query3.ToString, miconexion)
                micomando3.Parameters.AddWithValue("@CLAVE", CLIENTE)
                micomando3.Parameters.AddWithValue("@MONTO", MONTO)
                micomando3.Transaction = mitransacion
                micomando3.ExecuteNonQuery()
            End If

            Dim query6 As New StringBuilder
            query6.Append("UPDATE [dbo].[encabezados] SET [ESTADO_SAE] = @ESTADO_SAE WHERE [CODIGO] = @CODIGO AND [DOC_NC] = @DOC_NC")
            Dim micomando6 As New SqlCommand(query6.ToString, miconexion)
            micomando6.Parameters.AddWithValue("@DOC_NC", CVE_DOC)
            micomando6.Parameters.AddWithValue("@CODIGO", CODIGO_LOCAL)
            micomando6.Parameters.AddWithValue("@ESTADO_SAE", "C")
            micomando6.Transaction = mitransacion
            micomando6.ExecuteNonQuery()

            If tiene_interface = "Si" Then
                'eliminar interface en SAE
                Dim qx_int_coi = New StringBuilder()
                qx_int_coi.Append("DELETE FROM [SAE60Empre05].[dbo].[INTCOI05] WHERE CTLPOL = @CTLPOL ")
                Dim cmd_int_coi = New SqlCommand(qx_int_coi.ToString(), miconexion)
                cmd_int_coi.Transaction = mitransacion
                cmd_int_coi.Parameters.AddWithValue("@CTLPOL", ctlpol)
                cmd_int_coi.ExecuteNonQuery()

                'desenlazar doctos de la interface
                Dim qx_factd = New StringBuilder()
                qx_factd.Append(" UPDATE [SAE60Empre05].[dbo].[FACTD05] SET	CTLPOL = 0, ACT_COI = '' WHERE CTLPOL = @CTLPOL ")
                Dim cmd_factd = New SqlCommand(qx_factd.ToString(), miconexion)
                cmd_factd.Transaction = mitransacion
                cmd_factd.Parameters.AddWithValue("@CTLPOL", ctlpol)
                cmd_factd.ExecuteNonQuery()

                If contabilizado = "Si" Then

                    Dim year_short As Integer
                    year_short = Convert.ToInt32((nyear.ToString()).Substring(2, 2))

                    Dim cero As String = ""
                    If (nmes.ToString().Length < 2) Then
                        cero = "0"
                    End If
                    'encabezado de la poliza
                    Dim qx_polizas = New StringBuilder()
                    qx_polizas.Append("UPDATE [COI70Empre08].[dbo].[POLIZAS" + year_short.ToString + "08] ")
                    qx_polizas.Append("   SET [CONCEP_PO] = @CONCEP_PO ")
                    qx_polizas.Append("WHERE  [TIPO_POLI] = @TIPO_POLI AND LTRIM([NUM_POLIZ]) = @NUM_POLIZ ")
                    qx_polizas.Append("   AND [PERIODO] = @PERIODO AND [EJERCICIO] = @EJERCICIO AND [ORIGEN] = @ORIGEN ")
                    Dim cmd_polizas = New SqlCommand(qx_polizas.ToString(), miconexion_coi)
                    cmd_polizas.Transaction = mitransaccion_coi
                    cmd_polizas.Parameters.AddWithValue("@CONCEP_PO", "Nula")
                    cmd_polizas.Parameters.AddWithValue("@TIPO_POLI", tipo_poliza)
                    cmd_polizas.Parameters.AddWithValue("@NUM_POLIZ", num_poliz)
                    cmd_polizas.Parameters.AddWithValue("@PERIODO", nmes)
                    cmd_polizas.Parameters.AddWithValue("@EJERCICIO", nyear)
                    cmd_polizas.Parameters.AddWithValue("@ORIGEN", "CC COI")
                    cmd_polizas.ExecuteNonQuery()

                    For index = 0 To tabla.Rows.Count - 1
                        'seleccionar la cuenta base
                        Dim qx_catalogo_cuentas = New StringBuilder()
                        qx_catalogo_cuentas.Append("SELECT NUM_CTA, CTA_PAPA, NIVEL FROM CUENTAS" & Convert.ToString(year_short) & "08 WHERE NUM_CTA = @CTA ")
                        Dim cmd_catalogo_cuentas = New SqlCommand(qx_catalogo_cuentas.ToString(), miconexion_coi)
                        cmd_catalogo_cuentas.Parameters.AddWithValue("@CTA", tabla.Rows(index)(3))
                        cmd_catalogo_cuentas.Transaction = mitransaccion_coi
                        Dim adaptador_catalogo_cuentas = New SqlDataAdapter(cmd_catalogo_cuentas)
                        Dim dt_catalogo_cuentas = New DataTable()
                        adaptador_catalogo_cuentas.Fill(dt_catalogo_cuentas)

                        Dim cta_papa As String = ""
                        If dt_catalogo_cuentas.Rows.Count > 0 Then
                            cta_papa = Convert.ToString(dt_catalogo_cuentas.Rows(0)(1))

                            Dim cuentas_afectadas(Convert.ToInt32(dt_catalogo_cuentas.Rows(0)(2))) As String
                            cuentas_afectadas(0) = Convert.ToString(dt_catalogo_cuentas.Rows(0)(0))
                            cuentas_afectadas(1) = cta_papa

                            'seleccionar la raiz de las cuentas que se afectan
                            For i = 0 To Convert.ToInt32(dt_catalogo_cuentas.Rows(0)(2))
                                Dim qx_cuenta_rel = New StringBuilder()
                                qx_cuenta_rel.Append("SELECT NUM_CTA, CTA_PAPA, NIVEL FROM CUENTAS" & Convert.ToString(year_short) & "08 WHERE NUM_CTA = '" + cta_papa + "'")
                                Dim cmd_cuenta_rel = New SqlCommand(qx_cuenta_rel.ToString(), miconexion_coi)
                                cmd_cuenta_rel.Transaction = mitransaccion_coi
                                Dim adaptador_cuenta_rel = New SqlDataAdapter(cmd_cuenta_rel)
                                Dim dt_cuenta_rel = New DataTable()
                                adaptador_cuenta_rel.Fill(dt_cuenta_rel)
                                Try
                                    cta_papa = Convert.ToString(dt_cuenta_rel.Rows(0)(1))
                                    cuentas_afectadas(2 + i) = cta_papa
                                Catch ex As Exception

                                End Try
                            Next

                            Try
                                For i = 0 To cuentas_afectadas.Length - 1
                                    Dim qx_actualiza_saldos = New StringBuilder()
                                    qx_actualiza_saldos.Append(" UPDATE [COI70Empre08].[dbo].[SALDOS" & Convert.ToString(year_short) & "08] ")

                                    If tabla.Rows(index)(6) = "D" Then
                                        qx_actualiza_saldos.Append("   SET [CARGO" + cero + nmes.ToString + "] = [CARGO" + cero + nmes.ToString + "] - @VALOR ")
                                    ElseIf tabla.Rows(index)(6) = "H" Then
                                        qx_actualiza_saldos.Append("   SET [ABONO" + cero + nmes.ToString + "] = [ABONO" + cero + nmes.ToString + "] - @VALOR ")
                                    End If
                                    qx_actualiza_saldos.Append(" WHERE [NUM_CTA] = @NUM_CTA AND [EJERCICIO] = @EJERCICIO ")
                                    Dim cmd_actualiza_saldos = New SqlCommand(qx_actualiza_saldos.ToString(), miconexion_coi)
                                    cmd_actualiza_saldos.Transaction = mitransaccion_coi
                                    cmd_actualiza_saldos.Parameters.AddWithValue("@NUM_CTA", cuentas_afectadas(i))
                                    cmd_actualiza_saldos.Parameters.AddWithValue("@EJERCICIO", nyear)
                                    cmd_actualiza_saldos.Parameters.AddWithValue("@VALOR", Convert.ToDouble(tabla.Rows(index)(7)))
                                    cmd_actualiza_saldos.ExecuteNonQuery()
                                Next
                            Catch ex As Exception

                            End Try
                            'actualizar saldos de las cuentas
                            'fin de catalogo de cuentas a afectar
                            'fin seleccion de cuentas raiz
                        End If

                        'partidas de la poliza
                        Dim qx_auxiliares = New StringBuilder()
                        qx_auxiliares.Append("UPDATE [COI70Empre08].[dbo].[AUXILIAR" + year_short.ToString + "08] ")
                        qx_auxiliares.Append("SET [MONTOMOV] = 0 ")
                        qx_auxiliares.Append("WHERE [TIPO_POLI] = @TIPO_POLI AND [NUM_POLIZ] = @NUM_POLIZ ")
                        qx_auxiliares.Append("AND [NUM_PART] = @NUM_PART AND [PERIODO] = @PERIODO ")
                        qx_auxiliares.Append("AND [EJERCICIO] = @EJERCICIO AND [NUM_CTA] = @NUM_CTA ")
                        qx_auxiliares.Append("AND [FECHA_POL] = @FECHA_POL ")

                        Dim cmd_ins_auxiliares = New SqlCommand(qx_auxiliares.ToString(), miconexion_coi)
                        cmd_ins_auxiliares.Transaction = mitransaccion_coi
                        cmd_ins_auxiliares.Parameters.AddWithValue("@TIPO_POLI", tabla.Rows(index)(0))
                        cmd_ins_auxiliares.Parameters.AddWithValue("@NUM_POLIZ", tabla.Rows(index)(1))
                        cmd_ins_auxiliares.Parameters.AddWithValue("@NUM_PART", tabla.Rows(index)(2))
                        cmd_ins_auxiliares.Parameters.AddWithValue("@PERIODO", nmes)
                        cmd_ins_auxiliares.Parameters.AddWithValue("@EJERCICIO", nyear)
                        cmd_ins_auxiliares.Parameters.AddWithValue("@NUM_CTA", tabla.Rows(index)(3))
                        cmd_ins_auxiliares.Parameters.AddWithValue("@FECHA_POL", tabla.Rows(index)(4))
                        cmd_ins_auxiliares.ExecuteNonQuery()
                        ' fin partidas de la poliza
                    Next
                End If
            End If

            Dim query As New StringBuilder
            query.Append("INSERT INTO [Usuarios].[dbo].[tb_ctrl_int] ")
            query.Append(" ([FECHA],[USUARIO],[OBSERVACION],[MODULO],[ACCION]) ")
            query.Append(" VALUES (@FECHA,@USUARIO,@OBSERVACION,@MODULO,@ACCION) ")

            Dim miComando_bita As New SqlCommand(query.ToString, miconexion)
            miComando_bita.Transaction = mitransacion
            miComando_bita.Parameters.AddWithValue("@FECHA", Now)
            miComando_bita.Parameters.AddWithValue("@USUARIO", USUARIO)
            miComando_bita.Parameters.AddWithValue("@OBSERVACION", "Cancelo Nota de Credito")
            miComando_bita.Parameters.AddWithValue("@MODULO", "Notas de Credito")
            Dim DESCRIPCION As String = ""
            DESCRIPCION = " Nº de Credito: " + CVE_DOC + " Nº Factura: " + FACTURA + " Nº Local: " + CODIGO_LOCAL + " Ctlpol: " + ctlpol + _
            " Poliza:" + tipo_poliza + num_poliz.ToString
            miComando_bita.Parameters.AddWithValue("@ACCION", DESCRIPCION)
            miComando_bita.ExecuteNonQuery()

            mitransacion.Commit()
            mitransaccion_coi.Commit()

            miconexion.Close()
            miconexion_coi.Close()

            Return "correcto"
        Catch ex As Exception
            mitransacion.Rollback()
            mitransaccion_coi.Rollback()
            miconexion.Close()
            miconexion_coi.Close()
            Return ex.Message
        End Try
    End Function

    Public Function eliminar_nc_sae_dimosa(ByVal CVE_DOC As String, ByVal CLIENTE As String, ByVal MONTO As Double, ByVal CODIGO_LOCAL As String, _
                                    ByVal TIPO As String, ByVal DOCUMENTO2 As String, ByVal ctlpol As String, ByVal num_poliz As String, _
                                    ByVal nyear As Integer, ByVal nmes As Integer, ByVal tipo_poliza As String, ByVal tabla As DataTable, _
                                    ByVal tiene_interface As String, ByVal contabilizado As String, ByVal FACTURA As String, ByVal USUARIO As String, _
                                    ByVal tiene_interface_c31 As String, ByVal ctlpol_C31 As String, ByVal nyear_C31 As Integer, _
                                    ByVal nmes_C31 As Integer, ByVal contabilizado_C31 As String, ByVal tipo_poliza_C31 As String, _
                                    ByVal tabla_C31 As DataTable, ByVal num_poliz_C31 As String)

        Dim mitransacion As SqlTransaction
        Dim miconexion As New SqlConnection(conexion_dimosa.CadenaSQL)

        Dim mitransaccion_coi As SqlTransaction
        Dim miconexion_coi As New SqlConnection(conexion_coi_dimosa.CadenaSQL)

        Dim variable_error As String = ""
        miconexion.Open()
        miconexion_coi.Open()

        mitransacion = miconexion.BeginTransaction
        mitransaccion_coi = miconexion_coi.BeginTransaction

        Try
            Dim query2 As New StringBuilder
            query2.Append("UPDATE SAE60Empre06.dbo.FACTD06 SET [STATUS] = 'C' WHERE CVE_DOC = @CVE_DOC")
            Dim micomando2 As New SqlCommand(query2.ToString, miconexion)
            micomando2.Parameters.AddWithValue("@CVE_DOC", CVE_DOC)
            micomando2.Transaction = mitransacion
            micomando2.ExecuteNonQuery()

            Dim query4 As New StringBuilder
            query4.Append("DELETE FROM SAE60Empre06.dbo.CUEN_DET06 WHERE DOCTO = @DOCTO AND NUM_CPTO = 12 ")
            Dim micomando4 As New SqlCommand(query4.ToString, miconexion)
            micomando4.Parameters.AddWithValue("@DOCTO", CVE_DOC)
            micomando4.Transaction = mitransacion
            micomando4.ExecuteNonQuery()

            If TIPO.ToUpper = "CONTADO" Then
                Dim query5 As New StringBuilder
                query5.Append("DELETE FROM SAE60Empre06.dbo.CUEN_DET06 WHERE DOCTO = @DOCTO AND NUM_CPTO = 31 ")
                Dim micomando5 As New SqlCommand(query5.ToString, miconexion)
                micomando5.Parameters.AddWithValue("@DOCTO", CVE_DOC)
                micomando5.Transaction = mitransacion
                micomando5.ExecuteNonQuery()

                'Dim query510 As New StringBuilder
                'query510.Append("DELETE FROM SAE60Empre05.dbo.CUEN_DET05 WHERE DOCTO = @DOCTO AND NUM_CPTO = 31 ")
                'Dim micomando510 As New SqlCommand(query5.ToString, miconexion)
                'micomando510.Parameters.AddWithValue("@DOCTO", DOCUMENTO2)
                'micomando510.Transaction = mitransacion
                'micomando510.ExecuteNonQuery()

                'quitar concepto 31'
                If tiene_interface_c31 = "Si" Then
                    'eliminar interface en SAE
                    Dim qx_int_coi_C31 = New StringBuilder()
                    qx_int_coi_C31.Append("DELETE FROM [SAE60Empre06].[dbo].[INTCOI06] WHERE CTLPOL = @CTLPOL ")
                    Dim cmd_int_coi_C31 = New SqlCommand(qx_int_coi_C31.ToString(), miconexion)
                    cmd_int_coi_C31.Transaction = mitransacion
                    cmd_int_coi_C31.Parameters.AddWithValue("@CTLPOL", ctlpol_C31)
                    cmd_int_coi_C31.ExecuteNonQuery()

                    'desenlazar doctos de la interface
                    Dim qx_factd_C31 = New StringBuilder()
                    qx_factd_C31.Append(" UPDATE [SAE60Empre06].[dbo].[CUEN_DET06] SET CTLPOL = 0, AFEC_COI = '' WHERE CTLPOL = @CTLPOL ")
                    Dim cmd_factd_C31 = New SqlCommand(qx_factd_C31.ToString(), miconexion)
                    cmd_factd_C31.Transaction = mitransacion
                    cmd_factd_C31.Parameters.AddWithValue("@CTLPOL", ctlpol_C31)
                    cmd_factd_C31.ExecuteNonQuery()

                    If contabilizado_C31 = "Si" Then

                        Dim year_short_C31 As Integer
                        year_short_C31 = Convert.ToInt32((nyear_C31.ToString()).Substring(2, 2))

                        Dim cero_C31 As String = ""
                        If (nmes_C31.ToString().Length < 2) Then
                            cero_C31 = "0"
                        End If
                        'encabezado de la poliza
                        Dim qx_polizas_C31 = New StringBuilder()
                        qx_polizas_C31.Append("UPDATE [COI70Empre09].[dbo].[POLIZAS" + year_short_C31.ToString + "09] ")
                        qx_polizas_C31.Append("   SET [CONCEP_PO] = @CONCEP_PO ")
                        qx_polizas_C31.Append("WHERE  [TIPO_POLI] = @TIPO_POLI AND LTRIM([NUM_POLIZ]) = @NUM_POLIZ ")
                        qx_polizas_C31.Append("   AND [PERIODO] = @PERIODO AND [EJERCICIO] = @EJERCICIO AND [ORIGEN] = @ORIGEN ")
                        Dim cmd_polizas_C31 = New SqlCommand(qx_polizas_C31.ToString(), miconexion_coi)
                        cmd_polizas_C31.Transaction = mitransaccion_coi
                        cmd_polizas_C31.Parameters.AddWithValue("@CONCEP_PO", "Nula")
                        cmd_polizas_C31.Parameters.AddWithValue("@TIPO_POLI", tipo_poliza_C31)
                        cmd_polizas_C31.Parameters.AddWithValue("@NUM_POLIZ", num_poliz_C31)
                        cmd_polizas_C31.Parameters.AddWithValue("@PERIODO", nmes_C31)
                        cmd_polizas_C31.Parameters.AddWithValue("@EJERCICIO", nyear_C31)
                        cmd_polizas_C31.Parameters.AddWithValue("@ORIGEN", "CC COI")
                        cmd_polizas_C31.ExecuteNonQuery()

                        For index = 0 To tabla_C31.Rows.Count - 1
                            'seleccionar la cuenta base
                            Dim qx_catalogo_cuentas = New StringBuilder()
                            qx_catalogo_cuentas.Append("SELECT NUM_CTA, CTA_PAPA, NIVEL FROM CUENTAS" & Convert.ToString(year_short_C31) & "09 WHERE NUM_CTA = @CTA ")
                            Dim cmd_catalogo_cuentas = New SqlCommand(qx_catalogo_cuentas.ToString(), miconexion_coi)
                            cmd_catalogo_cuentas.Parameters.AddWithValue("@CTA", tabla_C31.Rows(index)(3))
                            cmd_catalogo_cuentas.Transaction = mitransaccion_coi
                            Dim adaptador_catalogo_cuentas = New SqlDataAdapter(cmd_catalogo_cuentas)
                            Dim dt_catalogo_cuentas = New DataTable()
                            adaptador_catalogo_cuentas.Fill(dt_catalogo_cuentas)

                            Dim cta_papa As String = ""
                            If dt_catalogo_cuentas.Rows.Count > 0 Then
                                cta_papa = Convert.ToString(dt_catalogo_cuentas.Rows(0)(1))

                                Dim cuentas_afectadas(Convert.ToInt32(dt_catalogo_cuentas.Rows(0)(2))) As String
                                cuentas_afectadas(0) = Convert.ToString(dt_catalogo_cuentas.Rows(0)(0))
                                cuentas_afectadas(1) = cta_papa

                                'seleccionar la raiz de las cuentas que se afectan
                                For i = 0 To Convert.ToInt32(dt_catalogo_cuentas.Rows(0)(2))
                                    Dim qx_cuenta_rel = New StringBuilder()
                                    qx_cuenta_rel.Append("SELECT NUM_CTA, CTA_PAPA, NIVEL FROM CUENTAS" & Convert.ToString(year_short_C31) & "09 WHERE NUM_CTA = '" + cta_papa + "'")
                                    Dim cmd_cuenta_rel = New SqlCommand(qx_cuenta_rel.ToString(), miconexion_coi)
                                    cmd_cuenta_rel.Transaction = mitransaccion_coi
                                    Dim adaptador_cuenta_rel = New SqlDataAdapter(cmd_cuenta_rel)
                                    Dim dt_cuenta_rel = New DataTable()
                                    adaptador_cuenta_rel.Fill(dt_cuenta_rel)
                                    Try
                                        cta_papa = Convert.ToString(dt_cuenta_rel.Rows(0)(1))
                                        cuentas_afectadas(2 + i) = cta_papa
                                    Catch ex As Exception

                                    End Try
                                Next

                                Try
                                    For i = 0 To cuentas_afectadas.Length - 1
                                        Dim qx_actualiza_saldos = New StringBuilder()
                                        qx_actualiza_saldos.Append(" UPDATE [COI70Empre09].[dbo].[SALDOS" & Convert.ToString(year_short_C31) & "09] ")

                                        If tabla_C31.Rows(index)(6) = "D" Then
                                            qx_actualiza_saldos.Append("   SET [CARGO" + cero_C31 + nmes_C31.ToString + "] = [CARGO" + cero_C31 + nmes_C31.ToString + "] - @VALOR ")
                                        ElseIf tabla_C31.Rows(index)(6) = "H" Then
                                            qx_actualiza_saldos.Append("   SET [ABONO" + cero_C31 + nmes_C31.ToString + "] = [ABONO" + cero_C31 + nmes_C31.ToString + "] - @VALOR ")
                                        End If
                                        qx_actualiza_saldos.Append(" WHERE [NUM_CTA] = @NUM_CTA AND [EJERCICIO] = @EJERCICIO ")
                                        Dim cmd_actualiza_saldos = New SqlCommand(qx_actualiza_saldos.ToString(), miconexion_coi)
                                        cmd_actualiza_saldos.Transaction = mitransaccion_coi
                                        cmd_actualiza_saldos.Parameters.AddWithValue("@NUM_CTA", cuentas_afectadas(i))
                                        cmd_actualiza_saldos.Parameters.AddWithValue("@EJERCICIO", nyear_C31)
                                        cmd_actualiza_saldos.Parameters.AddWithValue("@VALOR", Convert.ToDouble(tabla_C31.Rows(index)(7)))
                                        cmd_actualiza_saldos.ExecuteNonQuery()
                                    Next
                                Catch ex As Exception

                                End Try
                                'actualizar saldos de las cuentas
                                'fin de catalogo de cuentas a afectar
                                'fin seleccion de cuentas raiz
                            End If

                            'partidas de la poliza
                            Dim qx_auxiliares = New StringBuilder()
                            qx_auxiliares.Append("UPDATE [COI70Empre09].[dbo].[AUXILIAR" + year_short_C31.ToString + "09] ")
                            qx_auxiliares.Append("SET [MONTOMOV] = 0 ")
                            qx_auxiliares.Append("WHERE [TIPO_POLI] = @TIPO_POLI AND [NUM_POLIZ] = @NUM_POLIZ ")
                            qx_auxiliares.Append("AND [NUM_PART] = @NUM_PART AND [PERIODO] = @PERIODO ")
                            qx_auxiliares.Append("AND [EJERCICIO] = @EJERCICIO AND [NUM_CTA] = @NUM_CTA ")
                            qx_auxiliares.Append("AND [FECHA_POL] = @FECHA_POL ")

                            Dim cmd_ins_auxiliares = New SqlCommand(qx_auxiliares.ToString(), miconexion_coi)
                            cmd_ins_auxiliares.Transaction = mitransaccion_coi
                            cmd_ins_auxiliares.Parameters.AddWithValue("@TIPO_POLI", tabla_C31.Rows(index)(0))
                            cmd_ins_auxiliares.Parameters.AddWithValue("@NUM_POLIZ", tabla_C31.Rows(index)(1))
                            cmd_ins_auxiliares.Parameters.AddWithValue("@NUM_PART", tabla_C31.Rows(index)(2))
                            cmd_ins_auxiliares.Parameters.AddWithValue("@PERIODO", nmes_C31)
                            cmd_ins_auxiliares.Parameters.AddWithValue("@EJERCICIO", nyear_C31)
                            cmd_ins_auxiliares.Parameters.AddWithValue("@NUM_CTA", tabla_C31.Rows(index)(3))
                            cmd_ins_auxiliares.Parameters.AddWithValue("@FECHA_POL", tabla_C31.Rows(index)(4))
                            cmd_ins_auxiliares.ExecuteNonQuery()
                            ' fin partidas de la poliza
                        Next
                    End If
                End If
                'fin de quitar concepto 31'

            Else
                Dim query3 As New StringBuilder
                query3.Append("UPDATE SAE60Empre06.dbo.CLIE06 SET [SALDO] = SALDO + @MONTO WHERE [CLAVE] = @CLAVE")
                Dim micomando3 As New SqlCommand(query3.ToString, miconexion)
                micomando3.Parameters.AddWithValue("@CLAVE", CLIENTE)
                micomando3.Parameters.AddWithValue("@MONTO", MONTO)
                micomando3.Transaction = mitransacion
                micomando3.ExecuteNonQuery()
            End If

            Dim query6 As New StringBuilder
            query6.Append("UPDATE [dbo].[encabezados] SET [ESTADO_SAE] = @ESTADO_SAE WHERE [CODIGO] = @CODIGO AND [DOC_NC] = @DOC_NC")
            Dim micomando6 As New SqlCommand(query6.ToString, miconexion)
            micomando6.Parameters.AddWithValue("@DOC_NC", CVE_DOC)
            micomando6.Parameters.AddWithValue("@CODIGO", CODIGO_LOCAL)
            micomando6.Parameters.AddWithValue("@ESTADO_SAE", "C")
            micomando6.Transaction = mitransacion
            micomando6.ExecuteNonQuery()

            If tiene_interface = "Si" Then
                'eliminar interface en SAE
                Dim qx_int_coi = New StringBuilder()
                qx_int_coi.Append("DELETE FROM [SAE60Empre06].[dbo].[INTCOI06] WHERE CTLPOL = @CTLPOL ")
                Dim cmd_int_coi = New SqlCommand(qx_int_coi.ToString(), miconexion)
                cmd_int_coi.Transaction = mitransacion
                cmd_int_coi.Parameters.AddWithValue("@CTLPOL", ctlpol)
                cmd_int_coi.ExecuteNonQuery()

                'desenlazar doctos de la interface
                Dim qx_factd = New StringBuilder()
                qx_factd.Append(" UPDATE [SAE60Empre06].[dbo].[FACTD06] SET	CTLPOL = 0, ACT_COI = '' WHERE CTLPOL = @CTLPOL ")
                Dim cmd_factd = New SqlCommand(qx_factd.ToString(), miconexion)
                cmd_factd.Transaction = mitransacion
                cmd_factd.Parameters.AddWithValue("@CTLPOL", ctlpol)
                cmd_factd.ExecuteNonQuery()

                If contabilizado = "Si" Then

                    Dim year_short As Integer
                    year_short = Convert.ToInt32((nyear.ToString()).Substring(2, 2))

                    Dim cero As String = ""
                    If (nmes.ToString().Length < 2) Then
                        cero = "0"
                    End If
                    'encabezado de la poliza
                    Dim qx_polizas = New StringBuilder()
                    qx_polizas.Append("UPDATE [COI70Empre09].[dbo].[POLIZAS" + year_short.ToString + "09] ")
                    qx_polizas.Append("   SET [CONCEP_PO] = @CONCEP_PO ")
                    qx_polizas.Append("WHERE  [TIPO_POLI] = @TIPO_POLI AND LTRIM([NUM_POLIZ]) = @NUM_POLIZ ")
                    qx_polizas.Append("   AND [PERIODO] = @PERIODO AND [EJERCICIO] = @EJERCICIO AND [ORIGEN] = @ORIGEN ")
                    Dim cmd_polizas = New SqlCommand(qx_polizas.ToString(), miconexion_coi)
                    cmd_polizas.Transaction = mitransaccion_coi
                    cmd_polizas.Parameters.AddWithValue("@CONCEP_PO", "Nula")
                    cmd_polizas.Parameters.AddWithValue("@TIPO_POLI", tipo_poliza)
                    cmd_polizas.Parameters.AddWithValue("@NUM_POLIZ", num_poliz)
                    cmd_polizas.Parameters.AddWithValue("@PERIODO", nmes)
                    cmd_polizas.Parameters.AddWithValue("@EJERCICIO", nyear)
                    cmd_polizas.Parameters.AddWithValue("@ORIGEN", "CC COI")
                    cmd_polizas.ExecuteNonQuery()

                    For index = 0 To tabla.Rows.Count - 1
                        'seleccionar la cuenta base
                        Dim qx_catalogo_cuentas = New StringBuilder()
                        qx_catalogo_cuentas.Append("SELECT NUM_CTA, CTA_PAPA, NIVEL FROM CUENTAS" & Convert.ToString(year_short) & "09 WHERE NUM_CTA = @CTA ")
                        Dim cmd_catalogo_cuentas = New SqlCommand(qx_catalogo_cuentas.ToString(), miconexion_coi)
                        cmd_catalogo_cuentas.Parameters.AddWithValue("@CTA", tabla.Rows(index)(3))
                        cmd_catalogo_cuentas.Transaction = mitransaccion_coi
                        Dim adaptador_catalogo_cuentas = New SqlDataAdapter(cmd_catalogo_cuentas)
                        Dim dt_catalogo_cuentas = New DataTable()
                        adaptador_catalogo_cuentas.Fill(dt_catalogo_cuentas)

                        Dim cta_papa As String = ""
                        If dt_catalogo_cuentas.Rows.Count > 0 Then
                            cta_papa = Convert.ToString(dt_catalogo_cuentas.Rows(0)(1))

                            Dim cuentas_afectadas(Convert.ToInt32(dt_catalogo_cuentas.Rows(0)(2))) As String
                            cuentas_afectadas(0) = Convert.ToString(dt_catalogo_cuentas.Rows(0)(0))
                            cuentas_afectadas(1) = cta_papa

                            'seleccionar la raiz de las cuentas que se afectan
                            For i = 0 To Convert.ToInt32(dt_catalogo_cuentas.Rows(0)(2))
                                Dim qx_cuenta_rel = New StringBuilder()
                                qx_cuenta_rel.Append("SELECT NUM_CTA, CTA_PAPA, NIVEL FROM CUENTAS" & Convert.ToString(year_short) & "09 WHERE NUM_CTA = '" + cta_papa + "'")
                                Dim cmd_cuenta_rel = New SqlCommand(qx_cuenta_rel.ToString(), miconexion_coi)
                                cmd_cuenta_rel.Transaction = mitransaccion_coi
                                Dim adaptador_cuenta_rel = New SqlDataAdapter(cmd_cuenta_rel)
                                Dim dt_cuenta_rel = New DataTable()
                                adaptador_cuenta_rel.Fill(dt_cuenta_rel)
                                Try
                                    cta_papa = Convert.ToString(dt_cuenta_rel.Rows(0)(1))
                                    cuentas_afectadas(2 + i) = cta_papa
                                Catch ex As Exception

                                End Try
                            Next

                            Try
                                For i = 0 To cuentas_afectadas.Length - 1
                                    Dim qx_actualiza_saldos = New StringBuilder()
                                    qx_actualiza_saldos.Append(" UPDATE [COI70Empre09].[dbo].[SALDOS" & Convert.ToString(year_short) & "09] ")

                                    If tabla.Rows(index)(6) = "D" Then
                                        qx_actualiza_saldos.Append("   SET [CARGO" + cero + nmes.ToString + "] = [CARGO" + cero + nmes.ToString + "] - @VALOR ")
                                    ElseIf tabla.Rows(index)(6) = "H" Then
                                        qx_actualiza_saldos.Append("   SET [ABONO" + cero + nmes.ToString + "] = [ABONO" + cero + nmes.ToString + "] - @VALOR ")
                                    End If
                                    qx_actualiza_saldos.Append(" WHERE [NUM_CTA] = @NUM_CTA AND [EJERCICIO] = @EJERCICIO ")
                                    Dim cmd_actualiza_saldos = New SqlCommand(qx_actualiza_saldos.ToString(), miconexion_coi)
                                    cmd_actualiza_saldos.Transaction = mitransaccion_coi
                                    cmd_actualiza_saldos.Parameters.AddWithValue("@NUM_CTA", cuentas_afectadas(i))
                                    cmd_actualiza_saldos.Parameters.AddWithValue("@EJERCICIO", nyear)
                                    cmd_actualiza_saldos.Parameters.AddWithValue("@VALOR", Convert.ToDouble(tabla.Rows(index)(7)))
                                    cmd_actualiza_saldos.ExecuteNonQuery()
                                Next
                            Catch ex As Exception

                            End Try
                            'actualizar saldos de las cuentas
                            'fin de catalogo de cuentas a afectar
                            'fin seleccion de cuentas raiz
                        End If

                        'partidas de la poliza
                        Dim qx_auxiliares = New StringBuilder()
                        qx_auxiliares.Append("UPDATE [COI70Empre09].[dbo].[AUXILIAR" + year_short.ToString + "09] ")
                        qx_auxiliares.Append("SET [MONTOMOV] = 0 ")
                        qx_auxiliares.Append("WHERE [TIPO_POLI] = @TIPO_POLI AND [NUM_POLIZ] = @NUM_POLIZ ")
                        qx_auxiliares.Append("AND [NUM_PART] = @NUM_PART AND [PERIODO] = @PERIODO ")
                        qx_auxiliares.Append("AND [EJERCICIO] = @EJERCICIO AND [NUM_CTA] = @NUM_CTA ")
                        qx_auxiliares.Append("AND [FECHA_POL] = @FECHA_POL ")

                        Dim cmd_ins_auxiliares = New SqlCommand(qx_auxiliares.ToString(), miconexion_coi)
                        cmd_ins_auxiliares.Transaction = mitransaccion_coi
                        cmd_ins_auxiliares.Parameters.AddWithValue("@TIPO_POLI", tabla.Rows(index)(0))
                        cmd_ins_auxiliares.Parameters.AddWithValue("@NUM_POLIZ", tabla.Rows(index)(1))
                        cmd_ins_auxiliares.Parameters.AddWithValue("@NUM_PART", tabla.Rows(index)(2))
                        cmd_ins_auxiliares.Parameters.AddWithValue("@PERIODO", nmes)
                        cmd_ins_auxiliares.Parameters.AddWithValue("@EJERCICIO", nyear)
                        cmd_ins_auxiliares.Parameters.AddWithValue("@NUM_CTA", tabla.Rows(index)(3))
                        cmd_ins_auxiliares.Parameters.AddWithValue("@FECHA_POL", tabla.Rows(index)(4))
                        cmd_ins_auxiliares.ExecuteNonQuery()
                        ' fin partidas de la poliza
                    Next
                End If
            End If

            Dim query As New StringBuilder
            query.Append("INSERT INTO [Usuarios].[dbo].[tb_ctrl_int] ")
            query.Append(" ([FECHA],[USUARIO],[OBSERVACION],[MODULO],[ACCION]) ")
            query.Append(" VALUES (@FECHA,@USUARIO,@OBSERVACION,@MODULO,@ACCION) ")

            Dim miComando_bita As New SqlCommand(query.ToString, miconexion)
            miComando_bita.Transaction = mitransacion
            miComando_bita.Parameters.AddWithValue("@FECHA", Now)
            miComando_bita.Parameters.AddWithValue("@USUARIO", USUARIO)
            miComando_bita.Parameters.AddWithValue("@OBSERVACION", "Cancelo Nota de Credito DIMOSA")
            miComando_bita.Parameters.AddWithValue("@MODULO", "Notas de Credito")
            Dim DESCRIPCION As String = ""
            DESCRIPCION = " Nº de Credito: " + CVE_DOC + " Nº Factura: " + FACTURA + " Nº Local: " + CODIGO_LOCAL + " Ctlpol: " + ctlpol + _
            " Poliza:" + tipo_poliza + num_poliz.ToString
            miComando_bita.Parameters.AddWithValue("@ACCION", DESCRIPCION)
            miComando_bita.ExecuteNonQuery()

            mitransacion.Commit()
            mitransaccion_coi.Commit()

            miconexion.Close()
            miconexion_coi.Close()

            Return "correcto"
        Catch ex As Exception
            mitransacion.Rollback()
            mitransaccion_coi.Rollback()
            miconexion.Close()
            miconexion_coi.Close()
            Dim tamaño As Integer = Convert.ToString(ex.StackTrace).Length
            Dim posicion As Integer = InStrRev(Convert.ToString(ex.StackTrace), "línea") - 1
            Dim inicial As Integer = tamaño - posicion
            Dim linea_error As String = Convert.ToString(ex.StackTrace).Substring(tamaño - inicial, inicial)
            Return ex.Message & linea_error
        End Try
    End Function

    Public Function eliminar_nc_sae_opl(ByVal CVE_DOC As String, ByVal CLIENTE As String, ByVal MONTO As Double, ByVal CODIGO_LOCAL As String,
                                    ByVal TIPO As String, ByVal DOCUMENTO2 As String, ByVal ctlpol As String, ByVal num_poliz As String,
                                    ByVal nyear As Integer, ByVal nmes As Integer, ByVal tipo_poliza As String, ByVal tabla As DataTable,
                                    ByVal tiene_interface As String, ByVal contabilizado As String, ByVal FACTURA As String, ByVal USUARIO As String,
                                    ByVal tiene_interface_c31 As String, ByVal ctlpol_C31 As String, ByVal nyear_C31 As Integer,
                                    ByVal nmes_C31 As Integer, ByVal contabilizado_C31 As String, ByVal tipo_poliza_C31 As String,
                                    ByVal tabla_C31 As DataTable, ByVal num_poliz_C31 As String)

        Dim mitransacion As SqlTransaction
        Dim miconexion As New SqlConnection(conexion_Descuentos_Opl.CadenaSQL)

        Dim mitransaccion_coi As SqlTransaction
        Dim miconexion_coi As New SqlConnection(conexion_coi_opl.CadenaSQL)

        Dim variable_error As String = ""
        miconexion.Open()
        miconexion_coi.Open()

        mitransacion = miconexion.BeginTransaction
        mitransaccion_coi = miconexion_coi.BeginTransaction

        Try
            Dim query2 As New StringBuilder
            query2.Append("UPDATE SAE60Empre08.dbo.FACTD08 SET [STATUS] = 'C' WHERE CVE_DOC = @CVE_DOC")
            Dim micomando2 As New SqlCommand(query2.ToString, miconexion)
            micomando2.Parameters.AddWithValue("@CVE_DOC", CVE_DOC)
            micomando2.Transaction = mitransacion
            micomando2.ExecuteNonQuery()

            Dim query4 As New StringBuilder
            query4.Append("DELETE FROM SAE60Empre08.dbo.CUEN_DET08 WHERE DOCTO = @DOCTO AND NUM_CPTO = 12 ")
            Dim micomando4 As New SqlCommand(query4.ToString, miconexion)
            micomando4.Parameters.AddWithValue("@DOCTO", CVE_DOC)
            micomando4.Transaction = mitransacion
            micomando4.ExecuteNonQuery()

            If TIPO.ToUpper = "CONTADO" Then
                Dim query5 As New StringBuilder
                query5.Append("DELETE FROM SAE60Empre08.dbo.CUEN_DET08 WHERE DOCTO = @DOCTO AND NUM_CPTO = 31 ")
                Dim micomando5 As New SqlCommand(query5.ToString, miconexion)
                micomando5.Parameters.AddWithValue("@DOCTO", CVE_DOC)
                micomando5.Transaction = mitransacion
                micomando5.ExecuteNonQuery()

                'Dim query510 As New StringBuilder
                'query510.Append("DELETE FROM SAE60Empre05.dbo.CUEN_DET05 WHERE DOCTO = @DOCTO AND NUM_CPTO = 31 ")
                'Dim micomando510 As New SqlCommand(query5.ToString, miconexion)
                'micomando510.Parameters.AddWithValue("@DOCTO", DOCUMENTO2)
                'micomando510.Transaction = mitransacion
                'micomando510.ExecuteNonQuery()

                'quitar concepto 31'
                If tiene_interface_c31 = "Si" Then
                    'eliminar interface en SAE
                    Dim qx_int_coi_C31 = New StringBuilder()
                    qx_int_coi_C31.Append("DELETE FROM [SAE60Empre08].[dbo].[INTCOI08] WHERE CTLPOL = @CTLPOL ")
                    Dim cmd_int_coi_C31 = New SqlCommand(qx_int_coi_C31.ToString(), miconexion)
                    cmd_int_coi_C31.Transaction = mitransacion
                    cmd_int_coi_C31.Parameters.AddWithValue("@CTLPOL", ctlpol_C31)
                    cmd_int_coi_C31.ExecuteNonQuery()

                    'desenlazar doctos de la interface
                    Dim qx_factd_C31 = New StringBuilder()
                    qx_factd_C31.Append(" UPDATE [SAE60Empre08].[dbo].[CUEN_DET08] SET CTLPOL = 0, AFEC_COI = '' WHERE CTLPOL = @CTLPOL ")
                    Dim cmd_factd_C31 = New SqlCommand(qx_factd_C31.ToString(), miconexion)
                    cmd_factd_C31.Transaction = mitransacion
                    cmd_factd_C31.Parameters.AddWithValue("@CTLPOL", ctlpol_C31)
                    cmd_factd_C31.ExecuteNonQuery()

                    If contabilizado_C31 = "Si" Then

                        Dim year_short_C31 As Integer
                        year_short_C31 = Convert.ToInt32((nyear_C31.ToString()).Substring(2, 2))

                        Dim cero_C31 As String = ""
                        If (nmes_C31.ToString().Length < 2) Then
                            cero_C31 = "0"
                        End If
                        'encabezado de la poliza
                        Dim qx_polizas_C31 = New StringBuilder()
                        qx_polizas_C31.Append("UPDATE [COI70Empre10].[dbo].[POLIZAS" + year_short_C31.ToString + "10] ")
                        qx_polizas_C31.Append("   SET [CONCEP_PO] = @CONCEP_PO ")
                        qx_polizas_C31.Append("WHERE  [TIPO_POLI] = @TIPO_POLI AND LTRIM([NUM_POLIZ]) = @NUM_POLIZ ")
                        qx_polizas_C31.Append("   AND [PERIODO] = @PERIODO AND [EJERCICIO] = @EJERCICIO AND [ORIGEN] = @ORIGEN ")
                        Dim cmd_polizas_C31 = New SqlCommand(qx_polizas_C31.ToString(), miconexion_coi)
                        cmd_polizas_C31.Transaction = mitransaccion_coi
                        cmd_polizas_C31.Parameters.AddWithValue("@CONCEP_PO", "Nula")
                        cmd_polizas_C31.Parameters.AddWithValue("@TIPO_POLI", tipo_poliza_C31)
                        cmd_polizas_C31.Parameters.AddWithValue("@NUM_POLIZ", num_poliz_C31)
                        cmd_polizas_C31.Parameters.AddWithValue("@PERIODO", nmes_C31)
                        cmd_polizas_C31.Parameters.AddWithValue("@EJERCICIO", nyear_C31)
                        cmd_polizas_C31.Parameters.AddWithValue("@ORIGEN", "CC COI")
                        cmd_polizas_C31.ExecuteNonQuery()

                        For index = 0 To tabla_C31.Rows.Count - 1
                            'seleccionar la cuenta base
                            Dim qx_catalogo_cuentas = New StringBuilder()
                            qx_catalogo_cuentas.Append("SELECT NUM_CTA, CTA_PAPA, NIVEL FROM CUENTAS" & Convert.ToString(year_short_C31) & "10 WHERE NUM_CTA = @CTA ")
                            Dim cmd_catalogo_cuentas = New SqlCommand(qx_catalogo_cuentas.ToString(), miconexion_coi)
                            cmd_catalogo_cuentas.Parameters.AddWithValue("@CTA", tabla_C31.Rows(index)(3))
                            cmd_catalogo_cuentas.Transaction = mitransaccion_coi
                            Dim adaptador_catalogo_cuentas = New SqlDataAdapter(cmd_catalogo_cuentas)
                            Dim dt_catalogo_cuentas = New DataTable()
                            adaptador_catalogo_cuentas.Fill(dt_catalogo_cuentas)

                            Dim cta_papa As String = ""
                            If dt_catalogo_cuentas.Rows.Count > 0 Then
                                cta_papa = Convert.ToString(dt_catalogo_cuentas.Rows(0)(1))

                                Dim cuentas_afectadas(Convert.ToInt32(dt_catalogo_cuentas.Rows(0)(2))) As String
                                cuentas_afectadas(0) = Convert.ToString(dt_catalogo_cuentas.Rows(0)(0))
                                cuentas_afectadas(1) = cta_papa

                                'seleccionar la raiz de las cuentas que se afectan
                                For i = 0 To Convert.ToInt32(dt_catalogo_cuentas.Rows(0)(2))
                                    Dim qx_cuenta_rel = New StringBuilder()
                                    qx_cuenta_rel.Append("SELECT NUM_CTA, CTA_PAPA, NIVEL FROM CUENTAS" & Convert.ToString(year_short_C31) & "10 WHERE NUM_CTA = '" + cta_papa + "'")
                                    Dim cmd_cuenta_rel = New SqlCommand(qx_cuenta_rel.ToString(), miconexion_coi)
                                    cmd_cuenta_rel.Transaction = mitransaccion_coi
                                    Dim adaptador_cuenta_rel = New SqlDataAdapter(cmd_cuenta_rel)
                                    Dim dt_cuenta_rel = New DataTable()
                                    adaptador_cuenta_rel.Fill(dt_cuenta_rel)
                                    Try
                                        cta_papa = Convert.ToString(dt_cuenta_rel.Rows(0)(1))
                                        cuentas_afectadas(2 + i) = cta_papa
                                    Catch ex As Exception

                                    End Try
                                Next

                                Try
                                    For i = 0 To cuentas_afectadas.Length - 1
                                        Dim qx_actualiza_saldos = New StringBuilder()
                                        qx_actualiza_saldos.Append(" UPDATE [COI70Empre10].[dbo].[SALDOS" & Convert.ToString(year_short_C31) & "10] ")

                                        If tabla_C31.Rows(index)(6) = "D" Then
                                            qx_actualiza_saldos.Append("   SET [CARGO" + cero_C31 + nmes_C31.ToString + "] = [CARGO" + cero_C31 + nmes_C31.ToString + "] - @VALOR ")
                                        ElseIf tabla_C31.Rows(index)(6) = "H" Then
                                            qx_actualiza_saldos.Append("   SET [ABONO" + cero_C31 + nmes_C31.ToString + "] = [ABONO" + cero_C31 + nmes_C31.ToString + "] - @VALOR ")
                                        End If
                                        qx_actualiza_saldos.Append(" WHERE [NUM_CTA] = @NUM_CTA AND [EJERCICIO] = @EJERCICIO ")
                                        Dim cmd_actualiza_saldos = New SqlCommand(qx_actualiza_saldos.ToString(), miconexion_coi)
                                        cmd_actualiza_saldos.Transaction = mitransaccion_coi
                                        cmd_actualiza_saldos.Parameters.AddWithValue("@NUM_CTA", cuentas_afectadas(i))
                                        cmd_actualiza_saldos.Parameters.AddWithValue("@EJERCICIO", nyear_C31)
                                        cmd_actualiza_saldos.Parameters.AddWithValue("@VALOR", Convert.ToDouble(tabla_C31.Rows(index)(7)))
                                        cmd_actualiza_saldos.ExecuteNonQuery()
                                    Next
                                Catch ex As Exception

                                End Try
                                'actualizar saldos de las cuentas
                                'fin de catalogo de cuentas a afectar
                                'fin seleccion de cuentas raiz
                            End If

                            'partidas de la poliza
                            Dim qx_auxiliares = New StringBuilder()
                            qx_auxiliares.Append("UPDATE [COI70Empre10].[dbo].[AUXILIAR" + year_short_C31.ToString + "10] ")
                            qx_auxiliares.Append("SET [MONTOMOV] = 0 ")
                            qx_auxiliares.Append("WHERE [TIPO_POLI] = @TIPO_POLI AND [NUM_POLIZ] = @NUM_POLIZ ")
                            qx_auxiliares.Append("AND [NUM_PART] = @NUM_PART AND [PERIODO] = @PERIODO ")
                            qx_auxiliares.Append("AND [EJERCICIO] = @EJERCICIO AND [NUM_CTA] = @NUM_CTA ")
                            qx_auxiliares.Append("AND [FECHA_POL] = @FECHA_POL ")

                            Dim cmd_ins_auxiliares = New SqlCommand(qx_auxiliares.ToString(), miconexion_coi)
                            cmd_ins_auxiliares.Transaction = mitransaccion_coi
                            cmd_ins_auxiliares.Parameters.AddWithValue("@TIPO_POLI", tabla_C31.Rows(index)(0))
                            cmd_ins_auxiliares.Parameters.AddWithValue("@NUM_POLIZ", tabla_C31.Rows(index)(1))
                            cmd_ins_auxiliares.Parameters.AddWithValue("@NUM_PART", tabla_C31.Rows(index)(2))
                            cmd_ins_auxiliares.Parameters.AddWithValue("@PERIODO", nmes_C31)
                            cmd_ins_auxiliares.Parameters.AddWithValue("@EJERCICIO", nyear_C31)
                            cmd_ins_auxiliares.Parameters.AddWithValue("@NUM_CTA", tabla_C31.Rows(index)(3))
                            cmd_ins_auxiliares.Parameters.AddWithValue("@FECHA_POL", tabla_C31.Rows(index)(4))
                            cmd_ins_auxiliares.ExecuteNonQuery()
                            ' fin partidas de la poliza
                        Next
                    End If
                End If
                'fin de quitar concepto 31'

            Else
                Dim query3 As New StringBuilder
                query3.Append("UPDATE SAE60Empre08.dbo.CLIE08 SET [SALDO] = SALDO + @MONTO WHERE [CLAVE] = @CLAVE")
                Dim micomando3 As New SqlCommand(query3.ToString, miconexion)
                micomando3.Parameters.AddWithValue("@CLAVE", CLIENTE)
                micomando3.Parameters.AddWithValue("@MONTO", MONTO)
                micomando3.Transaction = mitransacion
                micomando3.ExecuteNonQuery()
            End If

            Dim query6 As New StringBuilder
            query6.Append("UPDATE [dbo].[encabezados] SET [ESTADO_SAE] = @ESTADO_SAE WHERE [CODIGO] = @CODIGO AND [DOC_NC] = @DOC_NC")
            Dim micomando6 As New SqlCommand(query6.ToString, miconexion)
            micomando6.Parameters.AddWithValue("@DOC_NC", CVE_DOC)
            micomando6.Parameters.AddWithValue("@CODIGO", CODIGO_LOCAL)
            micomando6.Parameters.AddWithValue("@ESTADO_SAE", "C")
            micomando6.Transaction = mitransacion
            micomando6.ExecuteNonQuery()

            If tiene_interface = "Si" Then
                'eliminar interface en SAE
                Dim qx_int_coi = New StringBuilder()
                qx_int_coi.Append("DELETE FROM [SAE60Empre08].[dbo].[INTCOI08] WHERE CTLPOL = @CTLPOL ")
                Dim cmd_int_coi = New SqlCommand(qx_int_coi.ToString(), miconexion)
                cmd_int_coi.Transaction = mitransacion
                cmd_int_coi.Parameters.AddWithValue("@CTLPOL", ctlpol)
                cmd_int_coi.ExecuteNonQuery()

                'desenlazar doctos de la interface
                Dim qx_factd = New StringBuilder()
                qx_factd.Append(" UPDATE [SAE60Empre08].[dbo].[FACTD08] SET	CTLPOL = 0, ACT_COI = '' WHERE CTLPOL = @CTLPOL ")
                Dim cmd_factd = New SqlCommand(qx_factd.ToString(), miconexion)
                cmd_factd.Transaction = mitransacion
                cmd_factd.Parameters.AddWithValue("@CTLPOL", ctlpol)
                cmd_factd.ExecuteNonQuery()

                If contabilizado = "Si" Then

                    Dim year_short As Integer
                    year_short = Convert.ToInt32((nyear.ToString()).Substring(2, 2))

                    Dim cero As String = ""
                    If (nmes.ToString().Length < 2) Then
                        cero = "0"
                    End If
                    'encabezado de la poliza
                    Dim qx_polizas = New StringBuilder()
                    qx_polizas.Append("UPDATE [COI70Empre10].[dbo].[POLIZAS" + year_short.ToString + "10] ")
                    qx_polizas.Append("   SET [CONCEP_PO] = @CONCEP_PO ")
                    qx_polizas.Append("WHERE  [TIPO_POLI] = @TIPO_POLI AND LTRIM([NUM_POLIZ]) = @NUM_POLIZ ")
                    qx_polizas.Append("   AND [PERIODO] = @PERIODO AND [EJERCICIO] = @EJERCICIO AND [ORIGEN] = @ORIGEN ")
                    Dim cmd_polizas = New SqlCommand(qx_polizas.ToString(), miconexion_coi)
                    cmd_polizas.Transaction = mitransaccion_coi
                    cmd_polizas.Parameters.AddWithValue("@CONCEP_PO", "Nula")
                    cmd_polizas.Parameters.AddWithValue("@TIPO_POLI", tipo_poliza)
                    cmd_polizas.Parameters.AddWithValue("@NUM_POLIZ", num_poliz)
                    cmd_polizas.Parameters.AddWithValue("@PERIODO", nmes)
                    cmd_polizas.Parameters.AddWithValue("@EJERCICIO", nyear)
                    cmd_polizas.Parameters.AddWithValue("@ORIGEN", "CC COI")
                    cmd_polizas.ExecuteNonQuery()

                    For index = 0 To tabla.Rows.Count - 1
                        'seleccionar la cuenta base
                        Dim qx_catalogo_cuentas = New StringBuilder()
                        qx_catalogo_cuentas.Append("SELECT NUM_CTA, CTA_PAPA, NIVEL FROM CUENTAS" & Convert.ToString(year_short) & "10 WHERE NUM_CTA = @CTA ")
                        Dim cmd_catalogo_cuentas = New SqlCommand(qx_catalogo_cuentas.ToString(), miconexion_coi)
                        cmd_catalogo_cuentas.Parameters.AddWithValue("@CTA", tabla.Rows(index)(3))
                        cmd_catalogo_cuentas.Transaction = mitransaccion_coi
                        Dim adaptador_catalogo_cuentas = New SqlDataAdapter(cmd_catalogo_cuentas)
                        Dim dt_catalogo_cuentas = New DataTable()
                        adaptador_catalogo_cuentas.Fill(dt_catalogo_cuentas)

                        Dim cta_papa As String = ""
                        If dt_catalogo_cuentas.Rows.Count > 0 Then
                            cta_papa = Convert.ToString(dt_catalogo_cuentas.Rows(0)(1))

                            Dim cuentas_afectadas(Convert.ToInt32(dt_catalogo_cuentas.Rows(0)(2))) As String
                            cuentas_afectadas(0) = Convert.ToString(dt_catalogo_cuentas.Rows(0)(0))
                            cuentas_afectadas(1) = cta_papa

                            'seleccionar la raiz de las cuentas que se afectan
                            For i = 0 To Convert.ToInt32(dt_catalogo_cuentas.Rows(0)(2))
                                Dim qx_cuenta_rel = New StringBuilder()
                                qx_cuenta_rel.Append("SELECT NUM_CTA, CTA_PAPA, NIVEL FROM CUENTAS" & Convert.ToString(year_short) & "10 WHERE NUM_CTA = '" + cta_papa + "'")
                                Dim cmd_cuenta_rel = New SqlCommand(qx_cuenta_rel.ToString(), miconexion_coi)
                                cmd_cuenta_rel.Transaction = mitransaccion_coi
                                Dim adaptador_cuenta_rel = New SqlDataAdapter(cmd_cuenta_rel)
                                Dim dt_cuenta_rel = New DataTable()
                                adaptador_cuenta_rel.Fill(dt_cuenta_rel)
                                Try
                                    cta_papa = Convert.ToString(dt_cuenta_rel.Rows(0)(1))
                                    cuentas_afectadas(2 + i) = cta_papa
                                Catch ex As Exception

                                End Try
                            Next

                            Try
                                For i = 0 To cuentas_afectadas.Length - 1
                                    Dim qx_actualiza_saldos = New StringBuilder()
                                    qx_actualiza_saldos.Append(" UPDATE [COI70Empre10].[dbo].[SALDOS" & Convert.ToString(year_short) & "10] ")

                                    If tabla.Rows(index)(6) = "D" Then
                                        qx_actualiza_saldos.Append("   SET [CARGO" + cero + nmes.ToString + "] = [CARGO" + cero + nmes.ToString + "] - @VALOR ")
                                    ElseIf tabla.Rows(index)(6) = "H" Then
                                        qx_actualiza_saldos.Append("   SET [ABONO" + cero + nmes.ToString + "] = [ABONO" + cero + nmes.ToString + "] - @VALOR ")
                                    End If
                                    qx_actualiza_saldos.Append(" WHERE [NUM_CTA] = @NUM_CTA AND [EJERCICIO] = @EJERCICIO ")
                                    Dim cmd_actualiza_saldos = New SqlCommand(qx_actualiza_saldos.ToString(), miconexion_coi)
                                    cmd_actualiza_saldos.Transaction = mitransaccion_coi
                                    cmd_actualiza_saldos.Parameters.AddWithValue("@NUM_CTA", cuentas_afectadas(i))
                                    cmd_actualiza_saldos.Parameters.AddWithValue("@EJERCICIO", nyear)
                                    cmd_actualiza_saldos.Parameters.AddWithValue("@VALOR", Convert.ToDouble(tabla.Rows(index)(7)))
                                    cmd_actualiza_saldos.ExecuteNonQuery()
                                Next
                            Catch ex As Exception

                            End Try
                            'actualizar saldos de las cuentas
                            'fin de catalogo de cuentas a afectar
                            'fin seleccion de cuentas raiz
                        End If

                        'partidas de la poliza
                        Dim qx_auxiliares = New StringBuilder()
                        qx_auxiliares.Append("UPDATE [COI70Empre10].[dbo].[AUXILIAR" + year_short.ToString + "10] ")
                        qx_auxiliares.Append("SET [MONTOMOV] = 0 ")
                        qx_auxiliares.Append("WHERE [TIPO_POLI] = @TIPO_POLI AND [NUM_POLIZ] = @NUM_POLIZ ")
                        qx_auxiliares.Append("AND [NUM_PART] = @NUM_PART AND [PERIODO] = @PERIODO ")
                        qx_auxiliares.Append("AND [EJERCICIO] = @EJERCICIO AND [NUM_CTA] = @NUM_CTA ")
                        qx_auxiliares.Append("AND [FECHA_POL] = @FECHA_POL ")

                        Dim cmd_ins_auxiliares = New SqlCommand(qx_auxiliares.ToString(), miconexion_coi)
                        cmd_ins_auxiliares.Transaction = mitransaccion_coi
                        cmd_ins_auxiliares.Parameters.AddWithValue("@TIPO_POLI", tabla.Rows(index)(0))
                        cmd_ins_auxiliares.Parameters.AddWithValue("@NUM_POLIZ", tabla.Rows(index)(1))
                        cmd_ins_auxiliares.Parameters.AddWithValue("@NUM_PART", tabla.Rows(index)(2))
                        cmd_ins_auxiliares.Parameters.AddWithValue("@PERIODO", nmes)
                        cmd_ins_auxiliares.Parameters.AddWithValue("@EJERCICIO", nyear)
                        cmd_ins_auxiliares.Parameters.AddWithValue("@NUM_CTA", tabla.Rows(index)(3))
                        cmd_ins_auxiliares.Parameters.AddWithValue("@FECHA_POL", tabla.Rows(index)(4))
                        cmd_ins_auxiliares.ExecuteNonQuery()
                        ' fin partidas de la poliza
                    Next
                End If
            End If

            Dim query As New StringBuilder
            query.Append("INSERT INTO [Usuarios].[dbo].[tb_ctrl_int] ")
            query.Append(" ([FECHA],[USUARIO],[OBSERVACION],[MODULO],[ACCION]) ")
            query.Append(" VALUES (@FECHA,@USUARIO,@OBSERVACION,@MODULO,@ACCION) ")

            Dim miComando_bita As New SqlCommand(query.ToString, miconexion)
            miComando_bita.Transaction = mitransacion
            miComando_bita.Parameters.AddWithValue("@FECHA", Now)
            miComando_bita.Parameters.AddWithValue("@USUARIO", USUARIO)
            miComando_bita.Parameters.AddWithValue("@OBSERVACION", "Cancelo Nota de Credito OPL")
            miComando_bita.Parameters.AddWithValue("@MODULO", "Notas de Credito")
            Dim DESCRIPCION As String = ""
            DESCRIPCION = " Nº de Credito: " + CVE_DOC + " Nº Factura: " + FACTURA + " Nº Local: " + CODIGO_LOCAL + " Ctlpol: " + ctlpol +
            " Poliza:" + tipo_poliza + num_poliz.ToString
            miComando_bita.Parameters.AddWithValue("@ACCION", DESCRIPCION)
            miComando_bita.ExecuteNonQuery()

            mitransacion.Commit()
            mitransaccion_coi.Commit()

            miconexion.Close()
            miconexion_coi.Close()

            Return "correcto"
        Catch ex As Exception
            mitransacion.Rollback()
            mitransaccion_coi.Rollback()
            miconexion.Close()
            miconexion_coi.Close()
            Dim tamaño As Integer = Convert.ToString(ex.StackTrace).Length
            Dim posicion As Integer = InStrRev(Convert.ToString(ex.StackTrace), "línea") - 1
            Dim inicial As Integer = tamaño - posicion
            Dim linea_error As String = Convert.ToString(ex.StackTrace).Substring(tamaño - inicial, inicial)
            Return ex.Message & linea_error
        End Try
    End Function

    Public Function hacer_envio_sae(ByVal dt_encabezado As DataTable, ByVal dt_partida As DataTable, ByVal RFC As String, _
                   ByVal dt_parfactd As DataTable, ByVal sub_total As Double, ByVal tot_isv As Double, _
                   ByVal fecha_entrega As DateTime, ByVal fecha_doc As Date, ByVal num_registro As String) As String
        Dim mitransacion As SqlTransaction
        Dim miconexion As New SqlConnection(conexion.CadenaSQL)
        Dim variable_error As String = ""
        miconexion.Open()
        mitransacion = miconexion.BeginTransaction
        Try
            Dim query_folios As New StringBuilder
            query_folios.Append("SELECT FOLIO + CONVERT(VARCHAR, ULT_DOC + 1) AS DOCTO, SERIE, TIPO ")
            query_folios.Append("FROM folios ")
            query_folios.Append("WHERE NUM_ALMA = @ALMACEN ")

            Dim comand_folio As New SqlCommand(query_folios.ToString, miconexion)
            comand_folio.Parameters.AddWithValue("@ALMACEN", dt_encabezado.Rows(0)(3))
            comand_folio.Transaction = mitransacion
            Dim adaptador_folios As New SqlDataAdapter(comand_folio)
            Dim dt_folios As New DataTable
            adaptador_folios.Fill(dt_folios)

            Dim docto As String
            Dim serie_local As String = ""
            Dim tipo_camplib20 As String = ""
            docto = dt_folios.Rows(0)(0)
            serie_local = dt_folios.Rows(0)(1)

            If dt_encabezado.Rows(0)(4) = "CREDITO" Then
                tipo_camplib20 = "N" + dt_folios.Rows(0)(2)
            Else
                tipo_camplib20 = "D" + dt_folios.Rows(0)(2)
            End If

            'ENVIO A SAE
            Dim _query_docto As New StringBuilder
            _query_docto.Append("SELECT SERIE,(ULT_DOC + 1)  ")
            _query_docto.Append("FROM [SAE60Empre05].[dbo].FOLIOSF05 ")
            _query_docto.Append("WHERE SERIE = @SERIE")
            Dim _cmd_docto As New SqlCommand(_query_docto.ToString, miconexion)
            _cmd_docto.Parameters.AddWithValue("@SERIE", serie_local)
            _cmd_docto.Transaction = mitransacion
            Dim adaptador_docto As New SqlDataAdapter(_cmd_docto)
            Dim dt_docto As New DataTable
            adaptador_docto.Fill(dt_docto)

            Dim serie As String = ""
            Dim ult_doc As Integer = 0
            Dim documento As String = ""
            serie = dt_docto.Rows(0)(0)
            ult_doc = dt_docto.Rows(0)(1)
            Dim ceros As String = ""
            For cont As Integer = 1 To 8 - Convert.ToString(ult_doc).Length
                ceros += "0"
            Next
            documento = serie + ceros + Convert.ToString(ult_doc)
            Dim _query_GETBITA As New StringBuilder
            _query_GETBITA.Append("SELECT ULT_CVE + 1   ")
            _query_GETBITA.Append("FROM [SAE60Empre05].[dbo].[TBLCONTROL05] ")
            _query_GETBITA.Append("WHERE ([ID_TABLA] = 62)")
            Dim _cmd_GETBITA As New SqlCommand(_query_GETBITA.ToString, miconexion)
            _cmd_GETBITA.Transaction = mitransacion
            Dim adaptador_BITA As New SqlDataAdapter(_cmd_GETBITA)
            Dim dt_GETBITA As New DataTable
            adaptador_BITA.Fill(dt_GETBITA)

            Dim _query_factd As New StringBuilder
            _query_factd.Append("INSERT INTO [SAE60Empre05].[dbo].[FACTD05] ")
            _query_factd.Append(" ([TIP_DOC],[CVE_DOC],[CVE_CLPV],[STATUS],[CVE_VEND],[CVE_PEDI] ")
            _query_factd.Append("  ,[FECHA_DOC],[FECHA_ENT],[FECHA_VEN],[CAN_TOT] ,[IMP_TOT1], [IMP_TOT2], ")
            _query_factd.Append("[IMP_TOT3],[IMP_TOT4],[DES_TOT],[DES_FIN],[COM_TOT] ,[CONDICION],[CVE_OBS], ")
            _query_factd.Append("[NUM_ALMA],[ACT_CXC],[ACT_COI],[ENLAZADO],[TIP_DOC_E],[NUM_MONED],[TIPCAMB], ")
            _query_factd.Append("[NUM_PAGOS],[FECHAELAB],[PRIMERPAGO],[RFC],[CTLPOL],[ESCFD],[AUTORIZA],[SERIE], ")
            _query_factd.Append("[FOLIO],[AUTOANIO],[DAT_ENVIO],[CONTADO],[DAT_MOSTR],[CVE_BITA],[BLOQ],[FORMAENVIO], ")
            _query_factd.Append("[DES_FIN_PORC],[DES_TOT_PORC],[IMPORTE],[TIP_DOC_ANT],[DOC_ANT]) ")
            _query_factd.Append("VALUES ")
            _query_factd.Append("('D',@CVE_DOC,@CVE_CLPV,'O',@CVE_VEND,0,@FECHA_DOC,@FECHA_ENT,@FECHA_VEN, @CAN_TOT, ")
            _query_factd.Append("0,0,0,@IMP_TOT4,0,0,0,0,0, @NUM_ALMA,'S','N','O','F',1,1,1,@FECHAELAB,0,@RFC, ")
            _query_factd.Append("0,'N',@AUTORIZA,@SERIE,@FOLIO,@AUTOANIO,0,'N',0,@CVE_BITA,'N',0,0,0,@IMPORTE, ")
            _query_factd.Append("'F', @DOC_ANT)")

            Dim cmd_factd As New SqlCommand(_query_factd.ToString, miconexion)
            cmd_factd.Parameters.AddWithValue("@CVE_DOC", documento)
            cmd_factd.Parameters.AddWithValue("@CVE_CLPV", dt_encabezado.Rows(0)(2))
            cmd_factd.Parameters.AddWithValue("@CVE_VEND", dt_encabezado.Rows(0)(0))
            cmd_factd.Parameters.AddWithValue("@FECHA_DOC", fecha_doc)
            cmd_factd.Parameters.AddWithValue("@FECHA_ENT", fecha_entrega)
            cmd_factd.Parameters.AddWithValue("@FECHA_VEN", fecha_doc)
            cmd_factd.Parameters.AddWithValue("@CAN_TOT", sub_total)
            cmd_factd.Parameters.AddWithValue("@IMP_TOT4", tot_isv)
            cmd_factd.Parameters.AddWithValue("@NUM_ALMA", dt_encabezado.Rows(0)(3))
            cmd_factd.Parameters.AddWithValue("@FECHAELAB", Now.Date)
            cmd_factd.Parameters.AddWithValue("@RFC", RFC)
            cmd_factd.Parameters.AddWithValue("@AUTORIZA", Convert.ToDateTime(dt_encabezado.Rows(0)(7)).Year)
            cmd_factd.Parameters.AddWithValue("@SERIE", serie)
            cmd_factd.Parameters.AddWithValue("@FOLIO", ult_doc)
            cmd_factd.Parameters.AddWithValue("@AUTOANIO", Convert.ToDateTime(dt_encabezado.Rows(0)(7)).Year)
            cmd_factd.Parameters.AddWithValue("@CVE_BITA", dt_GETBITA.Rows(0)(0))
            cmd_factd.Parameters.AddWithValue("@IMPORTE", Convert.ToDouble(dt_encabezado.Rows(0)(5)))
            cmd_factd.Parameters.AddWithValue("@DOC_ANT", dt_encabezado.Rows(0)(1))
            cmd_factd.Transaction = mitransacion
            cmd_factd.ExecuteNonQuery()

            Dim query2 As New StringBuilder
            query2.Append("UPDATE [tactical_discount_SanRafael].[dbo].[encabezados] ")
            query2.Append("SET [ESTADO] = 'ENVIADO', [DOC_NC] = @DOC_NC ")
            query2.Append("WHERE CODIGO = @CODIGO ")

            Dim micomando2 As New SqlCommand(query2.ToString, miconexion)
            micomando2.Parameters.AddWithValue("@CODIGO", num_registro)
            micomando2.Parameters.AddWithValue("@DOC_NC", documento)
            micomando2.Transaction = mitransacion
            micomando2.ExecuteNonQuery()

            Dim _query_ins_bita As New StringBuilder
            _query_ins_bita.Append("INSERT INTO [SAE60Empre05].[dbo].[BITA05]  ")
            _query_ins_bita.Append("(CVE_BITA,[CVE_CLIE],[CVE_CAMPANIA],[CVE_ACTIVIDAD] ")
            _query_ins_bita.Append(",[FECHAHORA],[CVE_USUARIO],[OBSERVACIONES],[STATUS],[NOM_USUARIO]) ")
            _query_ins_bita.Append("VALUES ")
            _query_ins_bita.Append("(@CVE_BITA,@CVE_CLIE,@CVE_CAMPANIA,@CVE_ACTIVIDAD,@FECHAHORA ")
            _query_ins_bita.Append(",@CVE_USUARIO,@OBSERVACIONES,@STATUS,@NOM_USUARIO) ")
            Dim _cmd_ins_bita As New SqlCommand(_query_ins_bita.ToString, miconexion)

            _cmd_ins_bita.Parameters.AddWithValue("@CVE_BITA", dt_GETBITA.Rows(0)(0))
            _cmd_ins_bita.Parameters.AddWithValue("@CVE_CLIE", dt_encabezado.Rows(0)(2))
            _cmd_ins_bita.Parameters.AddWithValue("@CVE_CAMPANIA", "_SAE_")
            _cmd_ins_bita.Parameters.AddWithValue("@CVE_ACTIVIDAD", "   12")
            _cmd_ins_bita.Parameters.AddWithValue("@FECHAHORA", DateTime.Now)
            _cmd_ins_bita.Parameters.AddWithValue("@CVE_USUARIO", 0)
            _cmd_ins_bita.Parameters.AddWithValue("@OBSERVACIONES", "No.[] L " & Convert.ToDouble(dt_encabezado.Rows(0)(5)))
            _cmd_ins_bita.Parameters.AddWithValue("@STATUS", "F")
            _cmd_ins_bita.Parameters.AddWithValue("@NOM_USUARIO", "nc-rpt")
            _cmd_ins_bita.Transaction = mitransacion
            _cmd_ins_bita.ExecuteNonQuery()

            Dim _query_factd_clib As New StringBuilder
            _query_factd_clib.Append("INSERT INTO [SAE60Empre05].[dbo].[FACTD_CLIB05] ")
            _query_factd_clib.Append("([CLAVE_DOC],[CAMPLIB20]) ")
            _query_factd_clib.Append("VALUES(@CLAVE_DOC, @CAMPLIB20) ")
            Dim _cmd_factd_clib As New SqlCommand(_query_factd_clib.ToString, miconexion)
            _cmd_factd_clib.Parameters.AddWithValue("@CLAVE_DOC", documento)
            _cmd_factd_clib.Parameters.AddWithValue("@CAMPLIB20", tipo_camplib20)
            _cmd_factd_clib.Transaction = mitransacion
            _cmd_factd_clib.ExecuteNonQuery()

            Dim _query_clie As New StringBuilder
            _query_clie.Append("UPDATE [SAE60Empre05].[dbo].[CLIE05] ")
            _query_clie.Append("SET [SALDO] = SALDO - @VALOR ")
            _query_clie.Append("WHERE ([CLAVE] = @CLAVE)")
            Dim _cmd_clie As New SqlCommand(_query_clie.ToString, miconexion)
            _cmd_clie.Parameters.AddWithValue("@VALOR", dt_encabezado.Rows(0)(5))
            _cmd_clie.Parameters.AddWithValue("@CLAVE", dt_encabezado.Rows(0)(2))
            _cmd_clie.Transaction = mitransacion
            _cmd_clie.ExecuteNonQuery()

            Dim _query_cuendet As New StringBuilder
            _query_cuendet.Append("INSERT INTO [SAE60Empre05].[dbo].[CUEN_DET05] ")
            _query_cuendet.Append("([CVE_CLIE],[REFER],[ID_MOV],[NUM_CPTO],[NUM_CARGO] ")
            _query_cuendet.Append(",[CVE_OBS],[NO_FACTURA],[DOCTO],[IMPORTE],[FECHA_APLI],[FECHA_VENC] ")
            _query_cuendet.Append(",[STRCVEVEND],[NUM_MONED],[TCAMBIO],[IMPMON_EXT],[FECHAELAB] ")
            _query_cuendet.Append(",[TIPO_MOV],[SIGNO],[USUARIO] ")
            _query_cuendet.Append(",[NO_PARTIDA],[AFEC_COI]) ")
            _query_cuendet.Append(" VALUES ")
            _query_cuendet.Append("(@CVE_CLIE,@REFER,1,12,1,0,@NO_FACTURA,@DOCTO ")
            _query_cuendet.Append(",@IMPORTE,@FECHA_APLI,@FECHA_VENC,@STRCVEVEND,1,1, ")
            _query_cuendet.Append(" @IMPMON_EXT, @FECHAELAB, 'A', -1,0,1,'A')")

            Dim _cmd_cuendet As New SqlCommand(_query_cuendet.ToString, miconexion)
            _cmd_cuendet.Parameters.AddWithValue("@CVE_CLIE", dt_encabezado.Rows(0)(2))
            _cmd_cuendet.Parameters.AddWithValue("@REFER", dt_encabezado.Rows(0)(1))
            _cmd_cuendet.Parameters.AddWithValue("@NO_FACTURA", dt_encabezado.Rows(0)(1))
            _cmd_cuendet.Parameters.AddWithValue("@DOCTO", documento)
            _cmd_cuendet.Parameters.AddWithValue("@IMPORTE", dt_encabezado.Rows(0)(5))
            _cmd_cuendet.Parameters.AddWithValue("@FECHA_APLI", fecha_doc)
            _cmd_cuendet.Parameters.AddWithValue("@FECHA_VENC", fecha_doc)
            _cmd_cuendet.Parameters.AddWithValue("@STRCVEVEND", dt_encabezado.Rows(0)(0))
            _cmd_cuendet.Parameters.AddWithValue("@IMPMON_EXT", dt_encabezado.Rows(0)(5))
            _cmd_cuendet.Parameters.AddWithValue("@FECHAELAB", Now.Date)
            _cmd_cuendet.Transaction = mitransacion
            _cmd_cuendet.ExecuteNonQuery()

            If dt_encabezado.Rows(0)(4) = "CONTADO" Then
                Dim _query_clie_CARGOXDEV As New StringBuilder
                _query_clie_CARGOXDEV.Append("UPDATE [SAE60Empre05].[dbo].[CLIE05] ")
                _query_clie_CARGOXDEV.Append("SET [SALDO] = SALDO + @VALOR ")
                _query_clie_CARGOXDEV.Append("WHERE ([CLAVE] = @CLAVE)")
                Dim _cmd_clie_CARGOXDEV As New SqlCommand(_query_clie_CARGOXDEV.ToString, miconexion)
                _cmd_clie_CARGOXDEV.Parameters.AddWithValue("@VALOR", dt_encabezado.Rows(0)(5))
                _cmd_clie_CARGOXDEV.Parameters.AddWithValue("@CLAVE", dt_encabezado.Rows(0)(2))
                _cmd_clie_CARGOXDEV.Transaction = mitransacion
                _cmd_clie_CARGOXDEV.ExecuteNonQuery()

                Dim _query_cuendet_CARGOXDEV As New StringBuilder
                _query_cuendet_CARGOXDEV.Append("INSERT INTO [SAE60Empre05].[dbo].[CUEN_DET05] ")
                _query_cuendet_CARGOXDEV.Append("([CVE_CLIE],[REFER],[ID_MOV],[NUM_CPTO],[NUM_CARGO] ")
                _query_cuendet_CARGOXDEV.Append(",[CVE_OBS],[NO_FACTURA],[DOCTO],[IMPORTE],[FECHA_APLI],[FECHA_VENC] ")
                _query_cuendet_CARGOXDEV.Append(",[STRCVEVEND],[NUM_MONED],[TCAMBIO],[IMPMON_EXT],[FECHAELAB] ")
                _query_cuendet_CARGOXDEV.Append(",[TIPO_MOV],[SIGNO],[USUARIO] ")
                _query_cuendet_CARGOXDEV.Append(",[NO_PARTIDA],[AFEC_COI]) ")
                _query_cuendet_CARGOXDEV.Append(" VALUES ")
                _query_cuendet_CARGOXDEV.Append("(@CVE_CLIE,@REFER,1,31,1,0,@NO_FACTURA,@DOCTO ")
                _query_cuendet_CARGOXDEV.Append(",@IMPORTE,@FECHA_APLI,@FECHA_VENC,@STRCVEVEND,1,1, ")
                _query_cuendet_CARGOXDEV.Append(" @IMPMON_EXT, @FECHAELAB, 'C', 1,0,2,'')")

                Dim _cmd_cuendet_CARGOXDEV As New SqlCommand(_query_cuendet_CARGOXDEV.ToString, miconexion)
                _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@CVE_CLIE", dt_encabezado.Rows(0)(2))
                _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@REFER", dt_encabezado.Rows(0)(1))
                _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@NO_FACTURA", dt_encabezado.Rows(0)(1))
                _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@DOCTO", documento) '"NC" & ult_doc)
                _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@IMPORTE", dt_encabezado.Rows(0)(5))
                _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@FECHA_APLI", fecha_doc)
                _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@FECHA_VENC", fecha_doc)
                _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@STRCVEVEND", dt_encabezado.Rows(0)(0))
                _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@IMPMON_EXT", dt_encabezado.Rows(0)(5))
                _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@FECHAELAB", Now.Date)
                _cmd_cuendet_CARGOXDEV.Transaction = mitransacion
                _cmd_cuendet_CARGOXDEV.ExecuteNonQuery()

                Dim _query_ins_bita_cargoxdev As New StringBuilder
                _query_ins_bita_cargoxdev.Append("INSERT INTO [SAE60Empre05].[dbo].[BITA05]  ")
                _query_ins_bita_cargoxdev.Append("(CVE_BITA,[CVE_CLIE],[CVE_CAMPANIA],[CVE_ACTIVIDAD] ")
                _query_ins_bita_cargoxdev.Append(",[FECHAHORA],[CVE_USUARIO],[OBSERVACIONES],[STATUS],[NOM_USUARIO]) ")
                _query_ins_bita_cargoxdev.Append("VALUES ")
                _query_ins_bita_cargoxdev.Append("(@CVE_BITA,@CVE_CLIE,@CVE_CAMPANIA,@CVE_ACTIVIDAD,@FECHAHORA ")
                _query_ins_bita_cargoxdev.Append(",@CVE_USUARIO,@OBSERVACIONES,@STATUS,@NOM_USUARIO) ")
                Dim _cmd_ins_bita_cargoxdev As New SqlCommand(_query_ins_bita_cargoxdev.ToString, miconexion)

                _cmd_ins_bita_cargoxdev.Parameters.AddWithValue("@CVE_BITA", dt_GETBITA.Rows(0)(0) + 1)
                _cmd_ins_bita_cargoxdev.Parameters.AddWithValue("@CVE_CLIE", dt_encabezado.Rows(0)(2))
                _cmd_ins_bita_cargoxdev.Parameters.AddWithValue("@CVE_CAMPANIA", "_SAE_")
                _cmd_ins_bita_cargoxdev.Parameters.AddWithValue("@CVE_ACTIVIDAD", "    6")
                _cmd_ins_bita_cargoxdev.Parameters.AddWithValue("@FECHAHORA", DateTime.Now)
                _cmd_ins_bita_cargoxdev.Parameters.AddWithValue("@CVE_USUARIO", 0)
                _cmd_ins_bita_cargoxdev.Parameters.AddWithValue("@OBSERVACIONES", "No.[" & documento & "] L " & Convert.ToDouble(dt_encabezado.Rows(0)(5)))
                _cmd_ins_bita_cargoxdev.Parameters.AddWithValue("@STATUS", "F")
                _cmd_ins_bita_cargoxdev.Parameters.AddWithValue("@NOM_USUARIO", "nc-rpt")
                _cmd_ins_bita_cargoxdev.Transaction = mitransacion
                _cmd_ins_bita_cargoxdev.ExecuteNonQuery()

                Dim _query_control2_cargoxdev As New StringBuilder
                _query_control2_cargoxdev.Append("UPDATE [SAE60Empre05].[dbo].[TBLCONTROL05] ")
                _query_control2_cargoxdev.Append(" SET [ULT_CVE] = ULT_CVE + 1 ")
                _query_control2_cargoxdev.Append("WHERE [ID_TABLA] = 62 ")
                Dim _cmd_control2_cargoxdev As New SqlCommand(_query_control2_cargoxdev.ToString, miconexion)
                _cmd_control2_cargoxdev.Transaction = mitransacion
                _cmd_control2_cargoxdev.ExecuteNonQuery()
            End If

            'PARTIDAS DEL DOCUMENTO
            For index As Integer = 0 To dt_parfactd.Rows.Count - 1
                'debe ir en cada partida
                Dim _query_doctosig As New StringBuilder

                _query_doctosig.Append("INSERT INTO [SAE60Empre05].[dbo].[DOCTOSIGF05] ")
                _query_doctosig.Append("([TIP_DOC],[CVE_DOC],[ANT_SIG],[TIP_DOC_E] ")
                _query_doctosig.Append(",[CVE_DOC_E],[PARTIDA],[PART_E],[CANT_E]) ")
                _query_doctosig.Append("VALUES ")
                _query_doctosig.Append("('D',@CVE_DOC,'A', 'F',@CVE_DOC_E,@PARTIDA,0,0)")
                Dim _cmd_doctosig As New SqlCommand(_query_doctosig.ToString, miconexion)
                _cmd_doctosig.Parameters.AddWithValue("@CVE_DOC", documento)
                _cmd_doctosig.Parameters.AddWithValue("@CVE_DOC_E", dt_encabezado.Rows(0)(1))
                _cmd_doctosig.Parameters.AddWithValue("@PARTIDA", index + 1)
                _cmd_doctosig.Transaction = mitransacion
                _cmd_doctosig.ExecuteNonQuery()

                Dim _query_par_factd As New StringBuilder
                _query_par_factd.Append("INSERT INTO [SAE60Empre05].[dbo].[PAR_FACTD05] ")
                _query_par_factd.Append("           ([CVE_DOC],[NUM_PAR],[CVE_ART],[CANT],[PXS],[PREC] ")
                _query_par_factd.Append("           ,[COST],[IMPU1],[IMPU2],[IMPU3],[IMPU4],[IMP1APLA] ")
                _query_par_factd.Append("           ,[IMP2APLA],[IMP3APLA],[IMP4APLA],[TOTIMP1],[TOTIMP2] ")
                _query_par_factd.Append("           ,[TOTIMP3],[TOTIMP4],[DESC1],[DESC2],[DESC3],[COMI] ")
                _query_par_factd.Append("           ,[APAR],[ACT_INV],[NUM_ALM],[TIP_CAM] ")
                _query_par_factd.Append("           ,[UNI_VENTA],[TIPO_PROD],[CVE_OBS],[REG_SERIE],[E_LTPD] ")
                _query_par_factd.Append("           ,[TIPO_ELEM],[NUM_MOV],[TOT_PARTIDA],[IMPRIMIR]) ")
                _query_par_factd.Append("VALUES    (@CVE_DOC,@NUM_PAR,@CVE_ART,@CANT,@PXS,@PREC,0,0,0, ")
                _query_par_factd.Append("           0,@IMPU4,0,0,0,0,0, 0,0,@TOTIMP4,0,0,0,0,0,'S',@NUM_ALM, ")
                _query_par_factd.Append("           1,@UNI_VENTA,'S',0,0,0,'N',0,@TOT_PARTIDA,'S')")
                Dim _cmd_par_factd As New SqlCommand(_query_par_factd.ToString, miconexion)
                _cmd_par_factd.Parameters.AddWithValue("@CVE_DOC", documento)
                _cmd_par_factd.Parameters.AddWithValue("@NUM_PAR", index + 1)
                _cmd_par_factd.Parameters.AddWithValue("@CVE_ART", dt_parfactd.Rows(index)(0))
                _cmd_par_factd.Parameters.AddWithValue("@CANT", dt_parfactd.Rows(index)(1))
                _cmd_par_factd.Parameters.AddWithValue("@PXS", dt_parfactd.Rows(index)(2))
                _cmd_par_factd.Parameters.AddWithValue("@PREC", dt_parfactd.Rows(index)(3))
                _cmd_par_factd.Parameters.AddWithValue("@IMPU4", dt_parfactd.Rows(index)(4))
                _cmd_par_factd.Parameters.AddWithValue("@TOTIMP4", dt_parfactd.Rows(index)(5))
                _cmd_par_factd.Parameters.AddWithValue("@NUM_ALM", dt_encabezado.Rows(0)(3))
                _cmd_par_factd.Parameters.AddWithValue("@UNI_VENTA", dt_parfactd.Rows(index)(6))
                _cmd_par_factd.Parameters.AddWithValue("@TOT_PARTIDA", dt_parfactd.Rows(index)(7))
                _cmd_par_factd.Transaction = mitransacion
                _cmd_par_factd.ExecuteNonQuery()

                Dim _query_par_factd_clib As New StringBuilder
                _query_par_factd_clib.Append("INSERT INTO [SAE60Empre05].[dbo].[PAR_FACTD_CLIB05] ")
                _query_par_factd_clib.Append("([CLAVE_DOC],[NUM_PART]) ")
                _query_par_factd_clib.Append("VALUES(@CLAVE_DOC, @NUM_PART)")
                Dim _cmd_par_factd_clib As New SqlCommand(_query_par_factd_clib.ToString, miconexion)
                _cmd_par_factd_clib.Parameters.AddWithValue("@CLAVE_DOC", documento)
                _cmd_par_factd_clib.Parameters.AddWithValue("@NUM_PART", index + 1)
                _cmd_par_factd_clib.Transaction = mitransacion
                _cmd_par_factd_clib.ExecuteNonQuery()
            Next

            Dim _query_control1 As New StringBuilder
            _query_control1.Append("UPDATE [SAE60Empre05].[dbo].[TBLCONTROL05] ")
            _query_control1.Append(" SET [ULT_CVE] = ULT_CVE + 1 ")
            _query_control1.Append("WHERE [ID_TABLA] = 32 ")
            Dim _cmd_control1 As New SqlCommand(_query_control1.ToString, miconexion)
            _cmd_control1.Transaction = mitransacion
            _cmd_control1.ExecuteNonQuery()

            Dim _query_control2 As New StringBuilder
            _query_control2.Append("UPDATE [SAE60Empre05].[dbo].[TBLCONTROL05] ")
            _query_control2.Append(" SET [ULT_CVE] = ULT_CVE + 1 ")
            _query_control2.Append("WHERE [ID_TABLA] = 62 ")
            Dim _cmd_control2 As New SqlCommand(_query_control2.ToString, miconexion)
            _cmd_control2.Transaction = mitransacion
            _cmd_control2.ExecuteNonQuery()

            Dim _query_foliosf As New StringBuilder
            _query_foliosf.Append("UPDATE [SAE60Empre05].[dbo].[FOLIOSF05] ")
            _query_foliosf.Append(" SET [ULT_DOC] = ULT_DOC +1 ")
            _query_foliosf.Append("WHERE [SERIE] = @SERIE")
            Dim _cmd_foliosf As New SqlCommand(_query_foliosf.ToString, miconexion)
            _cmd_foliosf.Parameters.AddWithValue("@SERIE", serie)
            _cmd_foliosf.Transaction = mitransacion
            _cmd_foliosf.ExecuteNonQuery()

            mitransacion.Commit()
            miconexion.Close()
            variable_error = "correcto"

        Catch ex As Exception
            mitransacion.Rollback()
            miconexion.Close()
            variable_error = ex.Message
        End Try

        Return variable_error
    End Function

    Public Function hacer_envio_sae_dimosa(ByVal dt_encabezado As DataTable, ByVal dt_partida As DataTable, ByVal RFC As String, _
                   ByVal dt_parfactd As DataTable, ByVal sub_total As Double, ByVal tot_isv As Double, _
                   ByVal fecha_entrega As DateTime, ByVal fecha_doc As Date, ByVal num_registro As String) As String
        Dim mitransacion As SqlTransaction
        Dim miconexion As New SqlConnection(conexion_dimosa.CadenaSQL)
        Dim variable_error As String = ""
        miconexion.Open()
        mitransacion = miconexion.BeginTransaction
        Try
            Dim query_folios As New StringBuilder
            query_folios.Append("SELECT FOLIO + CONVERT(VARCHAR, ULT_DOC + 1) AS DOCTO, SERIE, TIPO ")
            query_folios.Append("FROM folios ")
            query_folios.Append("WHERE NUM_ALMA = @ALMACEN ")

            Dim comand_folio As New SqlCommand(query_folios.ToString, miconexion)
            comand_folio.Parameters.AddWithValue("@ALMACEN", dt_encabezado.Rows(0)(3))
            comand_folio.Transaction = mitransacion
            Dim adaptador_folios As New SqlDataAdapter(comand_folio)
            Dim dt_folios As New DataTable
            adaptador_folios.Fill(dt_folios)

            Dim docto As String
            Dim serie_local As String = ""
            Dim tipo_camplib20 As String = ""
            docto = dt_folios.Rows(0)(0)
            serie_local = dt_folios.Rows(0)(1)

            If dt_encabezado.Rows(0)(4) = "CREDITO" Then
                tipo_camplib20 = "N" + dt_folios.Rows(0)(2)
            Else
                tipo_camplib20 = "D" + dt_folios.Rows(0)(2)
            End If

            'ENVIO A SAE
            Dim _query_docto As New StringBuilder
            _query_docto.Append("SELECT SERIE,(ULT_DOC + 1)  ")
            _query_docto.Append("FROM [SAE60Empre06].[dbo].FOLIOSF06 ")
            _query_docto.Append("WHERE SERIE = @SERIE")
            Dim _cmd_docto As New SqlCommand(_query_docto.ToString, miconexion)
            _cmd_docto.Parameters.AddWithValue("@SERIE", serie_local)
            _cmd_docto.Transaction = mitransacion
            Dim adaptador_docto As New SqlDataAdapter(_cmd_docto)
            Dim dt_docto As New DataTable
            adaptador_docto.Fill(dt_docto)

            Dim serie As String = ""
            Dim ult_doc As Integer = 0
            Dim documento As String = ""
            serie = dt_docto.Rows(0)(0)
            ult_doc = dt_docto.Rows(0)(1)
            Dim ceros As String = ""
            For cont As Integer = 1 To 8 - Convert.ToString(ult_doc).Length
                ceros += "0"
            Next
            documento = serie + ceros + Convert.ToString(ult_doc)
            Dim _query_GETBITA As New StringBuilder
            _query_GETBITA.Append("SELECT ULT_CVE + 1   ")
            _query_GETBITA.Append("FROM [SAE60Empre06].[dbo].[TBLCONTROL06] ")
            _query_GETBITA.Append("WHERE ([ID_TABLA] = 62)")
            Dim _cmd_GETBITA As New SqlCommand(_query_GETBITA.ToString, miconexion)
            _cmd_GETBITA.Transaction = mitransacion
            Dim adaptador_BITA As New SqlDataAdapter(_cmd_GETBITA)
            Dim dt_GETBITA As New DataTable
            adaptador_BITA.Fill(dt_GETBITA)

            Dim _query_factd As New StringBuilder
            _query_factd.Append("INSERT INTO [SAE60Empre06].[dbo].[FACTD06] ")
            _query_factd.Append(" ([TIP_DOC],[CVE_DOC],[CVE_CLPV],[STATUS],[CVE_VEND],[CVE_PEDI] ")
            _query_factd.Append("  ,[FECHA_DOC],[FECHA_ENT],[FECHA_VEN],[CAN_TOT] ,[IMP_TOT1], [IMP_TOT2], ")
            _query_factd.Append("[IMP_TOT3],[IMP_TOT4],[DES_TOT],[DES_FIN],[COM_TOT] ,[CONDICION],[CVE_OBS], ")
            _query_factd.Append("[NUM_ALMA],[ACT_CXC],[ACT_COI],[ENLAZADO],[TIP_DOC_E],[NUM_MONED],[TIPCAMB], ")
            _query_factd.Append("[NUM_PAGOS],[FECHAELAB],[PRIMERPAGO],[RFC],[CTLPOL],[ESCFD],[AUTORIZA],[SERIE], ")
            _query_factd.Append("[FOLIO],[AUTOANIO],[DAT_ENVIO],[CONTADO],[DAT_MOSTR],[CVE_BITA],[BLOQ],[FORMAENVIO], ")
            _query_factd.Append("[DES_FIN_PORC],[DES_TOT_PORC],[IMPORTE],[TIP_DOC_ANT],[DOC_ANT]) ")
            _query_factd.Append("VALUES ")
            _query_factd.Append("('D',@CVE_DOC,@CVE_CLPV,'O',@CVE_VEND,0,@FECHA_DOC,@FECHA_ENT,@FECHA_VEN, @CAN_TOT, ")
            _query_factd.Append("0,0,0,@IMP_TOT4,0,0,0,0,0, @NUM_ALMA,'S','N','O','F',1,1,1,@FECHAELAB,0,@RFC, ")
            _query_factd.Append("0,'N',@AUTORIZA,@SERIE,@FOLIO,@AUTOANIO,0,'N',0,@CVE_BITA,'N',0,0,0,@IMPORTE, ")
            _query_factd.Append("'F', @DOC_ANT)")

            Dim cmd_factd As New SqlCommand(_query_factd.ToString, miconexion)
            cmd_factd.Parameters.AddWithValue("@CVE_DOC", documento)
            cmd_factd.Parameters.AddWithValue("@CVE_CLPV", dt_encabezado.Rows(0)(2))
            cmd_factd.Parameters.AddWithValue("@CVE_VEND", dt_encabezado.Rows(0)(0))
            cmd_factd.Parameters.AddWithValue("@FECHA_DOC", fecha_doc)
            cmd_factd.Parameters.AddWithValue("@FECHA_ENT", fecha_entrega)
            cmd_factd.Parameters.AddWithValue("@FECHA_VEN", fecha_doc)
            cmd_factd.Parameters.AddWithValue("@CAN_TOT", sub_total)
            cmd_factd.Parameters.AddWithValue("@IMP_TOT4", tot_isv)
            cmd_factd.Parameters.AddWithValue("@NUM_ALMA", dt_encabezado.Rows(0)(3))
            cmd_factd.Parameters.AddWithValue("@FECHAELAB", Now.Date)
            cmd_factd.Parameters.AddWithValue("@RFC", RFC)
            cmd_factd.Parameters.AddWithValue("@AUTORIZA", Convert.ToDateTime(dt_encabezado.Rows(0)(7)).Year)
            cmd_factd.Parameters.AddWithValue("@SERIE", serie)
            cmd_factd.Parameters.AddWithValue("@FOLIO", ult_doc)
            cmd_factd.Parameters.AddWithValue("@AUTOANIO", Convert.ToDateTime(dt_encabezado.Rows(0)(7)).Year)
            cmd_factd.Parameters.AddWithValue("@CVE_BITA", dt_GETBITA.Rows(0)(0))
            cmd_factd.Parameters.AddWithValue("@IMPORTE", Convert.ToDouble(dt_encabezado.Rows(0)(5)))
            cmd_factd.Parameters.AddWithValue("@DOC_ANT", dt_encabezado.Rows(0)(1))
            cmd_factd.Transaction = mitransacion
            cmd_factd.ExecuteNonQuery()

            Dim query2 As New StringBuilder
            query2.Append("UPDATE [tactical_discount_DIMOSA].[dbo].[encabezados] ")
            query2.Append("SET [ESTADO] = 'ENVIADO', [DOC_NC] = @DOC_NC ")
            query2.Append("WHERE CODIGO = @CODIGO ")

            Dim micomando2 As New SqlCommand(query2.ToString, miconexion)
            micomando2.Parameters.AddWithValue("@CODIGO", num_registro)
            micomando2.Parameters.AddWithValue("@DOC_NC", documento)
            micomando2.Transaction = mitransacion
            micomando2.ExecuteNonQuery()

            Dim _query_ins_bita As New StringBuilder
            _query_ins_bita.Append("INSERT INTO [SAE60Empre06].[dbo].[BITA06]  ")
            _query_ins_bita.Append("(CVE_BITA,[CVE_CLIE],[CVE_CAMPANIA],[CVE_ACTIVIDAD] ")
            _query_ins_bita.Append(",[FECHAHORA],[CVE_USUARIO],[OBSERVACIONES],[STATUS],[NOM_USUARIO]) ")
            _query_ins_bita.Append("VALUES ")
            _query_ins_bita.Append("(@CVE_BITA,@CVE_CLIE,@CVE_CAMPANIA,@CVE_ACTIVIDAD,@FECHAHORA ")
            _query_ins_bita.Append(",@CVE_USUARIO,@OBSERVACIONES,@STATUS,@NOM_USUARIO) ")
            Dim _cmd_ins_bita As New SqlCommand(_query_ins_bita.ToString, miconexion)

            _cmd_ins_bita.Parameters.AddWithValue("@CVE_BITA", dt_GETBITA.Rows(0)(0))
            _cmd_ins_bita.Parameters.AddWithValue("@CVE_CLIE", dt_encabezado.Rows(0)(2))
            _cmd_ins_bita.Parameters.AddWithValue("@CVE_CAMPANIA", "_SAE_")
            _cmd_ins_bita.Parameters.AddWithValue("@CVE_ACTIVIDAD", "   12")
            _cmd_ins_bita.Parameters.AddWithValue("@FECHAHORA", DateTime.Now)
            _cmd_ins_bita.Parameters.AddWithValue("@CVE_USUARIO", 0)
            _cmd_ins_bita.Parameters.AddWithValue("@OBSERVACIONES", "No.[] L " & Convert.ToDouble(dt_encabezado.Rows(0)(5)))
            _cmd_ins_bita.Parameters.AddWithValue("@STATUS", "F")
            _cmd_ins_bita.Parameters.AddWithValue("@NOM_USUARIO", "nc-rpt")
            _cmd_ins_bita.Transaction = mitransacion
            _cmd_ins_bita.ExecuteNonQuery()

            Dim _query_factd_clib As New StringBuilder
            _query_factd_clib.Append("INSERT INTO [SAE60Empre06].[dbo].[FACTD_CLIB06] ")
            _query_factd_clib.Append("([CLAVE_DOC],[CAMPLIB20]) ")
            _query_factd_clib.Append("VALUES(@CLAVE_DOC, @CAMPLIB20) ")
            Dim _cmd_factd_clib As New SqlCommand(_query_factd_clib.ToString, miconexion)
            _cmd_factd_clib.Parameters.AddWithValue("@CLAVE_DOC", documento)
            _cmd_factd_clib.Parameters.AddWithValue("@CAMPLIB20", tipo_camplib20)
            _cmd_factd_clib.Transaction = mitransacion
            _cmd_factd_clib.ExecuteNonQuery()

            Dim _query_clie As New StringBuilder
            _query_clie.Append("UPDATE [SAE60Empre06].[dbo].[CLIE06] ")
            _query_clie.Append("SET [SALDO] = SALDO - @VALOR ")
            _query_clie.Append("WHERE ([CLAVE] = @CLAVE)")
            Dim _cmd_clie As New SqlCommand(_query_clie.ToString, miconexion)
            _cmd_clie.Parameters.AddWithValue("@VALOR", dt_encabezado.Rows(0)(5))
            _cmd_clie.Parameters.AddWithValue("@CLAVE", dt_encabezado.Rows(0)(2))
            _cmd_clie.Transaction = mitransacion
            _cmd_clie.ExecuteNonQuery()

            Dim _query_cuendet As New StringBuilder
            _query_cuendet.Append("INSERT INTO [SAE60Empre06].[dbo].[CUEN_DET06] ")
            _query_cuendet.Append("([CVE_CLIE],[REFER],[ID_MOV],[NUM_CPTO],[NUM_CARGO] ")
            _query_cuendet.Append(",[CVE_OBS],[NO_FACTURA],[DOCTO],[IMPORTE],[FECHA_APLI],[FECHA_VENC] ")
            _query_cuendet.Append(",[STRCVEVEND],[NUM_MONED],[TCAMBIO],[IMPMON_EXT],[FECHAELAB] ")
            _query_cuendet.Append(",[TIPO_MOV],[SIGNO],[USUARIO] ")
            _query_cuendet.Append(",[NO_PARTIDA],[AFEC_COI]) ")
            _query_cuendet.Append(" VALUES ")
            _query_cuendet.Append("(@CVE_CLIE,@REFER,1,12,1,0,@NO_FACTURA,@DOCTO ")
            _query_cuendet.Append(",@IMPORTE,@FECHA_APLI,@FECHA_VENC,@STRCVEVEND,1,1, ")
            _query_cuendet.Append(" @IMPMON_EXT, @FECHAELAB, 'A', -1,0,1,'A')")

            Dim _cmd_cuendet As New SqlCommand(_query_cuendet.ToString, miconexion)
            _cmd_cuendet.Parameters.AddWithValue("@CVE_CLIE", dt_encabezado.Rows(0)(2))
            _cmd_cuendet.Parameters.AddWithValue("@REFER", dt_encabezado.Rows(0)(1))
            _cmd_cuendet.Parameters.AddWithValue("@NO_FACTURA", dt_encabezado.Rows(0)(1))
            _cmd_cuendet.Parameters.AddWithValue("@DOCTO", documento)
            _cmd_cuendet.Parameters.AddWithValue("@IMPORTE", dt_encabezado.Rows(0)(5))
            _cmd_cuendet.Parameters.AddWithValue("@FECHA_APLI", fecha_doc)
            _cmd_cuendet.Parameters.AddWithValue("@FECHA_VENC", fecha_doc)
            _cmd_cuendet.Parameters.AddWithValue("@STRCVEVEND", dt_encabezado.Rows(0)(0))
            _cmd_cuendet.Parameters.AddWithValue("@IMPMON_EXT", dt_encabezado.Rows(0)(5))
            _cmd_cuendet.Parameters.AddWithValue("@FECHAELAB", Now.Date)
            _cmd_cuendet.Transaction = mitransacion
            _cmd_cuendet.ExecuteNonQuery()

            If dt_encabezado.Rows(0)(4) = "CONTADO" Then
                Dim _query_clie_CARGOXDEV As New StringBuilder
                _query_clie_CARGOXDEV.Append("UPDATE [SAE60Empre06].[dbo].[CLIE06] ")
                _query_clie_CARGOXDEV.Append("SET [SALDO] = SALDO + @VALOR ")
                _query_clie_CARGOXDEV.Append("WHERE ([CLAVE] = @CLAVE)")
                Dim _cmd_clie_CARGOXDEV As New SqlCommand(_query_clie_CARGOXDEV.ToString, miconexion)
                _cmd_clie_CARGOXDEV.Parameters.AddWithValue("@VALOR", dt_encabezado.Rows(0)(5))
                _cmd_clie_CARGOXDEV.Parameters.AddWithValue("@CLAVE", dt_encabezado.Rows(0)(2))
                _cmd_clie_CARGOXDEV.Transaction = mitransacion
                _cmd_clie_CARGOXDEV.ExecuteNonQuery()

                Dim _query_cuendet_CARGOXDEV As New StringBuilder
                _query_cuendet_CARGOXDEV.Append("INSERT INTO [SAE60Empre06].[dbo].[CUEN_DET06] ")
                _query_cuendet_CARGOXDEV.Append("([CVE_CLIE],[REFER],[ID_MOV],[NUM_CPTO],[NUM_CARGO] ")
                _query_cuendet_CARGOXDEV.Append(",[CVE_OBS],[NO_FACTURA],[DOCTO],[IMPORTE],[FECHA_APLI],[FECHA_VENC] ")
                _query_cuendet_CARGOXDEV.Append(",[STRCVEVEND],[NUM_MONED],[TCAMBIO],[IMPMON_EXT],[FECHAELAB] ")
                _query_cuendet_CARGOXDEV.Append(",[TIPO_MOV],[SIGNO],[USUARIO] ")
                _query_cuendet_CARGOXDEV.Append(",[NO_PARTIDA],[AFEC_COI]) ")
                _query_cuendet_CARGOXDEV.Append(" VALUES ")
                _query_cuendet_CARGOXDEV.Append("(@CVE_CLIE,@REFER,1,31,1,0,@NO_FACTURA,@DOCTO ")
                _query_cuendet_CARGOXDEV.Append(",@IMPORTE,@FECHA_APLI,@FECHA_VENC,@STRCVEVEND,1,1, ")
                _query_cuendet_CARGOXDEV.Append(" @IMPMON_EXT, @FECHAELAB, 'C', 1,0,2,'')")

                Dim _cmd_cuendet_CARGOXDEV As New SqlCommand(_query_cuendet_CARGOXDEV.ToString, miconexion)
                _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@CVE_CLIE", dt_encabezado.Rows(0)(2))
                _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@REFER", dt_encabezado.Rows(0)(1))
                _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@NO_FACTURA", dt_encabezado.Rows(0)(1))
                _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@DOCTO", documento) '"NC" & ult_doc)
                _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@IMPORTE", dt_encabezado.Rows(0)(5))
                _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@FECHA_APLI", fecha_doc)
                _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@FECHA_VENC", fecha_doc)
                _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@STRCVEVEND", dt_encabezado.Rows(0)(0))
                _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@IMPMON_EXT", dt_encabezado.Rows(0)(5))
                _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@FECHAELAB", Now.Date)
                _cmd_cuendet_CARGOXDEV.Transaction = mitransacion
                _cmd_cuendet_CARGOXDEV.ExecuteNonQuery()

                Dim _query_ins_bita_cargoxdev As New StringBuilder
                _query_ins_bita_cargoxdev.Append("INSERT INTO [SAE60Empre06].[dbo].[BITA06]  ")
                _query_ins_bita_cargoxdev.Append("(CVE_BITA,[CVE_CLIE],[CVE_CAMPANIA],[CVE_ACTIVIDAD] ")
                _query_ins_bita_cargoxdev.Append(",[FECHAHORA],[CVE_USUARIO],[OBSERVACIONES],[STATUS],[NOM_USUARIO]) ")
                _query_ins_bita_cargoxdev.Append("VALUES ")
                _query_ins_bita_cargoxdev.Append("(@CVE_BITA,@CVE_CLIE,@CVE_CAMPANIA,@CVE_ACTIVIDAD,@FECHAHORA ")
                _query_ins_bita_cargoxdev.Append(",@CVE_USUARIO,@OBSERVACIONES,@STATUS,@NOM_USUARIO) ")
                Dim _cmd_ins_bita_cargoxdev As New SqlCommand(_query_ins_bita_cargoxdev.ToString, miconexion)

                _cmd_ins_bita_cargoxdev.Parameters.AddWithValue("@CVE_BITA", dt_GETBITA.Rows(0)(0) + 1)
                _cmd_ins_bita_cargoxdev.Parameters.AddWithValue("@CVE_CLIE", dt_encabezado.Rows(0)(2))
                _cmd_ins_bita_cargoxdev.Parameters.AddWithValue("@CVE_CAMPANIA", "_SAE_")
                _cmd_ins_bita_cargoxdev.Parameters.AddWithValue("@CVE_ACTIVIDAD", "    6")
                _cmd_ins_bita_cargoxdev.Parameters.AddWithValue("@FECHAHORA", DateTime.Now)
                _cmd_ins_bita_cargoxdev.Parameters.AddWithValue("@CVE_USUARIO", 0)
                _cmd_ins_bita_cargoxdev.Parameters.AddWithValue("@OBSERVACIONES", "No.[" & documento & "] L " & Convert.ToDouble(dt_encabezado.Rows(0)(5)))
                _cmd_ins_bita_cargoxdev.Parameters.AddWithValue("@STATUS", "F")
                _cmd_ins_bita_cargoxdev.Parameters.AddWithValue("@NOM_USUARIO", "nc-rpt")
                _cmd_ins_bita_cargoxdev.Transaction = mitransacion
                _cmd_ins_bita_cargoxdev.ExecuteNonQuery()

                Dim _query_control2_cargoxdev As New StringBuilder
                _query_control2_cargoxdev.Append("UPDATE [SAE60Empre06].[dbo].[TBLCONTROL06] ")
                _query_control2_cargoxdev.Append(" SET [ULT_CVE] = ULT_CVE + 1 ")
                _query_control2_cargoxdev.Append("WHERE [ID_TABLA] = 62 ")
                Dim _cmd_control2_cargoxdev As New SqlCommand(_query_control2_cargoxdev.ToString, miconexion)
                _cmd_control2_cargoxdev.Transaction = mitransacion
                _cmd_control2_cargoxdev.ExecuteNonQuery()
            End If

            'PARTIDAS DEL DOCUMENTO
            For index As Integer = 0 To dt_parfactd.Rows.Count - 1
                'debe ir en cada partida
                Dim _query_doctosig As New StringBuilder

                _query_doctosig.Append("INSERT INTO [SAE60Empre06].[dbo].[DOCTOSIGF06] ")
                _query_doctosig.Append("([TIP_DOC],[CVE_DOC],[ANT_SIG],[TIP_DOC_E] ")
                _query_doctosig.Append(",[CVE_DOC_E],[PARTIDA],[PART_E],[CANT_E]) ")
                _query_doctosig.Append("VALUES ")
                _query_doctosig.Append("('D',@CVE_DOC,'A', 'F',@CVE_DOC_E,@PARTIDA,0,0)")
                Dim _cmd_doctosig As New SqlCommand(_query_doctosig.ToString, miconexion)
                _cmd_doctosig.Parameters.AddWithValue("@CVE_DOC", documento)
                _cmd_doctosig.Parameters.AddWithValue("@CVE_DOC_E", dt_encabezado.Rows(0)(1))
                _cmd_doctosig.Parameters.AddWithValue("@PARTIDA", index + 1)
                _cmd_doctosig.Transaction = mitransacion
                _cmd_doctosig.ExecuteNonQuery()

                Dim _query_par_factd As New StringBuilder
                _query_par_factd.Append("INSERT INTO [SAE60Empre06].[dbo].[PAR_FACTD06] ")
                _query_par_factd.Append("           ([CVE_DOC],[NUM_PAR],[CVE_ART],[CANT],[PXS],[PREC] ")
                _query_par_factd.Append("           ,[COST],[IMPU1],[IMPU2],[IMPU3],[IMPU4],[IMP1APLA] ")
                _query_par_factd.Append("           ,[IMP2APLA],[IMP3APLA],[IMP4APLA],[TOTIMP1],[TOTIMP2] ")
                _query_par_factd.Append("           ,[TOTIMP3],[TOTIMP4],[DESC1],[DESC2],[DESC3],[COMI] ")
                _query_par_factd.Append("           ,[APAR],[ACT_INV],[NUM_ALM],[TIP_CAM] ")
                _query_par_factd.Append("           ,[UNI_VENTA],[TIPO_PROD],[CVE_OBS],[REG_SERIE],[E_LTPD] ")
                _query_par_factd.Append("           ,[TIPO_ELEM],[NUM_MOV],[TOT_PARTIDA],[IMPRIMIR]) ")
                _query_par_factd.Append("VALUES    (@CVE_DOC,@NUM_PAR,@CVE_ART,@CANT,@PXS,@PREC,0,0,0, ")
                _query_par_factd.Append("           0,@IMPU4,0,0,0,0,0, 0,0,@TOTIMP4,0,0,0,0,0,'S',@NUM_ALM, ")
                _query_par_factd.Append("           1,@UNI_VENTA,'S',0,0,0,'N',0,@TOT_PARTIDA,'S')")
                Dim _cmd_par_factd As New SqlCommand(_query_par_factd.ToString, miconexion)
                _cmd_par_factd.Parameters.AddWithValue("@CVE_DOC", documento)
                _cmd_par_factd.Parameters.AddWithValue("@NUM_PAR", index + 1)
                _cmd_par_factd.Parameters.AddWithValue("@CVE_ART", dt_parfactd.Rows(index)(0))
                _cmd_par_factd.Parameters.AddWithValue("@CANT", dt_parfactd.Rows(index)(1))
                _cmd_par_factd.Parameters.AddWithValue("@PXS", dt_parfactd.Rows(index)(2))
                _cmd_par_factd.Parameters.AddWithValue("@PREC", dt_parfactd.Rows(index)(3))
                _cmd_par_factd.Parameters.AddWithValue("@IMPU4", dt_parfactd.Rows(index)(4))
                _cmd_par_factd.Parameters.AddWithValue("@TOTIMP4", dt_parfactd.Rows(index)(5))
                _cmd_par_factd.Parameters.AddWithValue("@NUM_ALM", dt_encabezado.Rows(0)(3))
                _cmd_par_factd.Parameters.AddWithValue("@UNI_VENTA", dt_parfactd.Rows(index)(6))
                _cmd_par_factd.Parameters.AddWithValue("@TOT_PARTIDA", dt_parfactd.Rows(index)(7))
                _cmd_par_factd.Transaction = mitransacion
                _cmd_par_factd.ExecuteNonQuery()

                Dim _query_par_factd_clib As New StringBuilder
                _query_par_factd_clib.Append("INSERT INTO [SAE60Empre06].[dbo].[PAR_FACTD_CLIB06] ")
                _query_par_factd_clib.Append("([CLAVE_DOC],[NUM_PART]) ")
                _query_par_factd_clib.Append("VALUES(@CLAVE_DOC, @NUM_PART)")
                Dim _cmd_par_factd_clib As New SqlCommand(_query_par_factd_clib.ToString, miconexion)
                _cmd_par_factd_clib.Parameters.AddWithValue("@CLAVE_DOC", documento)
                _cmd_par_factd_clib.Parameters.AddWithValue("@NUM_PART", index + 1)
                _cmd_par_factd_clib.Transaction = mitransacion
                _cmd_par_factd_clib.ExecuteNonQuery()
            Next

            Dim _query_control1 As New StringBuilder
            _query_control1.Append("UPDATE [SAE60Empre06].[dbo].[TBLCONTROL06] ")
            _query_control1.Append(" SET [ULT_CVE] = ULT_CVE + 1 ")
            _query_control1.Append("WHERE [ID_TABLA] = 32 ")
            Dim _cmd_control1 As New SqlCommand(_query_control1.ToString, miconexion)
            _cmd_control1.Transaction = mitransacion
            _cmd_control1.ExecuteNonQuery()

            Dim _query_control2 As New StringBuilder
            _query_control2.Append("UPDATE [SAE60Empre06].[dbo].[TBLCONTROL06] ")
            _query_control2.Append(" SET [ULT_CVE] = ULT_CVE + 1 ")
            _query_control2.Append("WHERE [ID_TABLA] = 62 ")
            Dim _cmd_control2 As New SqlCommand(_query_control2.ToString, miconexion)
            _cmd_control2.Transaction = mitransacion
            _cmd_control2.ExecuteNonQuery()

            Dim _query_foliosf As New StringBuilder
            _query_foliosf.Append("UPDATE [SAE60Empre06].[dbo].[FOLIOSF06] ")
            _query_foliosf.Append(" SET [ULT_DOC] = ULT_DOC +1 ")
            _query_foliosf.Append("WHERE [SERIE] = @SERIE")
            Dim _cmd_foliosf As New SqlCommand(_query_foliosf.ToString, miconexion)
            _cmd_foliosf.Parameters.AddWithValue("@SERIE", serie)
            _cmd_foliosf.Transaction = mitransacion
            _cmd_foliosf.ExecuteNonQuery()

            mitransacion.Commit()
            miconexion.Close()
            variable_error = "correcto"

        Catch ex As Exception
            mitransacion.Rollback()
            miconexion.Close()
            variable_error = ex.Message
        End Try

        Return variable_error
    End Function


    Public Function hacer_envio_sae_opl(ByVal dt_encabezado As DataTable, ByVal dt_partida As DataTable, ByVal RFC As String,
                   ByVal dt_parfactd As DataTable, ByVal sub_total As Double, ByVal tot_isv As Double,
                   ByVal fecha_entrega As DateTime, ByVal fecha_doc As Date, ByVal num_registro As String) As String
        Dim mitransacion As SqlTransaction
        Dim miconexion As New SqlConnection(conexion_Descuentos_Opl.CadenaSQL)
        Dim variable_error As String = ""
        miconexion.Open()
        mitransacion = miconexion.BeginTransaction
        Try
            Dim query_folios As New StringBuilder
            query_folios.Append("SELECT FOLIO + CONVERT(VARCHAR, ULT_DOC + 1) AS DOCTO, SERIE, TIPO ")
            query_folios.Append("FROM folios ")
            query_folios.Append("WHERE NUM_ALMA = @ALMACEN ")

            Dim comand_folio As New SqlCommand(query_folios.ToString, miconexion)
            comand_folio.Parameters.AddWithValue("@ALMACEN", dt_encabezado.Rows(0)(3))
            comand_folio.Transaction = mitransacion
            Dim adaptador_folios As New SqlDataAdapter(comand_folio)
            Dim dt_folios As New DataTable
            adaptador_folios.Fill(dt_folios)

            Dim docto As String
            Dim serie_local As String = ""
            Dim tipo_camplib20 As String = ""
            docto = dt_folios.Rows(0)(0)
            serie_local = dt_folios.Rows(0)(1)

            If dt_encabezado.Rows(0)(4) = "CREDITO" Then
                tipo_camplib20 = "N" + dt_folios.Rows(0)(2)
            Else
                tipo_camplib20 = "D" + dt_folios.Rows(0)(2)
            End If

            'ENVIO A SAE
            Dim _query_docto As New StringBuilder
            _query_docto.Append("SELECT SERIE,(ULT_DOC + 1)  ")
            _query_docto.Append("FROM [SAE60Empre08].[dbo].FOLIOSF08 ")
            _query_docto.Append("WHERE SERIE = @SERIE")
            Dim _cmd_docto As New SqlCommand(_query_docto.ToString, miconexion)
            _cmd_docto.Parameters.AddWithValue("@SERIE", serie_local)
            _cmd_docto.Transaction = mitransacion
            Dim adaptador_docto As New SqlDataAdapter(_cmd_docto)
            Dim dt_docto As New DataTable
            adaptador_docto.Fill(dt_docto)

            Dim serie As String = ""
            Dim ult_doc As Integer = 0
            Dim documento As String = ""
            serie = dt_docto.Rows(0)(0)
            ult_doc = dt_docto.Rows(0)(1)
            Dim ceros As String = ""
            For cont As Integer = 1 To 8 - Convert.ToString(ult_doc).Length
                ceros += "0"
            Next
            documento = serie + ceros + Convert.ToString(ult_doc)
            Dim _query_GETBITA As New StringBuilder
            _query_GETBITA.Append("SELECT ULT_CVE + 1   ")
            _query_GETBITA.Append("FROM [SAE60Empre08].[dbo].[TBLCONTROL08] ")
            _query_GETBITA.Append("WHERE ([ID_TABLA] = 62)")
            Dim _cmd_GETBITA As New SqlCommand(_query_GETBITA.ToString, miconexion)
            _cmd_GETBITA.Transaction = mitransacion
            Dim adaptador_BITA As New SqlDataAdapter(_cmd_GETBITA)
            Dim dt_GETBITA As New DataTable
            adaptador_BITA.Fill(dt_GETBITA)

            Dim _query_factd As New StringBuilder
            _query_factd.Append("INSERT INTO [SAE60Empre08].[dbo].[FACTD08] ")
            _query_factd.Append(" ([TIP_DOC],[CVE_DOC],[CVE_CLPV],[STATUS],[CVE_VEND],[CVE_PEDI] ")
            _query_factd.Append("  ,[FECHA_DOC],[FECHA_ENT],[FECHA_VEN],[CAN_TOT] ,[IMP_TOT1], [IMP_TOT2], ")
            _query_factd.Append("[IMP_TOT3],[IMP_TOT4],[DES_TOT],[DES_FIN],[COM_TOT] ,[CONDICION],[CVE_OBS], ")
            _query_factd.Append("[NUM_ALMA],[ACT_CXC],[ACT_COI],[ENLAZADO],[TIP_DOC_E],[NUM_MONED],[TIPCAMB], ")
            _query_factd.Append("[NUM_PAGOS],[FECHAELAB],[PRIMERPAGO],[RFC],[CTLPOL],[ESCFD],[AUTORIZA],[SERIE], ")
            _query_factd.Append("[FOLIO],[AUTOANIO],[DAT_ENVIO],[CONTADO],[DAT_MOSTR],[CVE_BITA],[BLOQ],[FORMAENVIO], ")
            _query_factd.Append("[DES_FIN_PORC],[DES_TOT_PORC],[IMPORTE],[TIP_DOC_ANT],[DOC_ANT]) ")
            _query_factd.Append("VALUES ")
            _query_factd.Append("('D',@CVE_DOC,@CVE_CLPV,'O',@CVE_VEND,0,@FECHA_DOC,@FECHA_ENT,@FECHA_VEN, @CAN_TOT, ")
            _query_factd.Append("0,0,0,@IMP_TOT4,0,0,0,0,0, @NUM_ALMA,'S','N','O','F',1,1,1,@FECHAELAB,0,@RFC, ")
            _query_factd.Append("0,'N',@AUTORIZA,@SERIE,@FOLIO,@AUTOANIO,0,'N',0,@CVE_BITA,'N',0,0,0,@IMPORTE, ")
            _query_factd.Append("'F', @DOC_ANT)")

            Dim cmd_factd As New SqlCommand(_query_factd.ToString, miconexion)
            cmd_factd.Parameters.AddWithValue("@CVE_DOC", documento)
            cmd_factd.Parameters.AddWithValue("@CVE_CLPV", dt_encabezado.Rows(0)(2))
            cmd_factd.Parameters.AddWithValue("@CVE_VEND", dt_encabezado.Rows(0)(0))
            cmd_factd.Parameters.AddWithValue("@FECHA_DOC", fecha_doc)
            cmd_factd.Parameters.AddWithValue("@FECHA_ENT", fecha_entrega)
            cmd_factd.Parameters.AddWithValue("@FECHA_VEN", fecha_doc)
            cmd_factd.Parameters.AddWithValue("@CAN_TOT", sub_total)
            cmd_factd.Parameters.AddWithValue("@IMP_TOT4", tot_isv)
            cmd_factd.Parameters.AddWithValue("@NUM_ALMA", dt_encabezado.Rows(0)(3))
            cmd_factd.Parameters.AddWithValue("@FECHAELAB", Now.Date)
            cmd_factd.Parameters.AddWithValue("@RFC", RFC)
            cmd_factd.Parameters.AddWithValue("@AUTORIZA", Convert.ToDateTime(dt_encabezado.Rows(0)(7)).Year)
            cmd_factd.Parameters.AddWithValue("@SERIE", serie)
            cmd_factd.Parameters.AddWithValue("@FOLIO", ult_doc)
            cmd_factd.Parameters.AddWithValue("@AUTOANIO", Convert.ToDateTime(dt_encabezado.Rows(0)(7)).Year)
            cmd_factd.Parameters.AddWithValue("@CVE_BITA", dt_GETBITA.Rows(0)(0))
            cmd_factd.Parameters.AddWithValue("@IMPORTE", Convert.ToDouble(dt_encabezado.Rows(0)(5)))
            cmd_factd.Parameters.AddWithValue("@DOC_ANT", dt_encabezado.Rows(0)(1))
            cmd_factd.Transaction = mitransacion
            cmd_factd.ExecuteNonQuery()

            Dim query2 As New StringBuilder
            query2.Append("UPDATE [tactical_discount_OPL].[dbo].[encabezados] ")
            query2.Append("SET [ESTADO] = 'ENVIADO', [DOC_NC] = @DOC_NC ")
            query2.Append("WHERE CODIGO = @CODIGO ")

            Dim micomando2 As New SqlCommand(query2.ToString, miconexion)
            micomando2.Parameters.AddWithValue("@CODIGO", num_registro)
            micomando2.Parameters.AddWithValue("@DOC_NC", documento)
            micomando2.Transaction = mitransacion
            micomando2.ExecuteNonQuery()

            Dim _query_ins_bita As New StringBuilder
            _query_ins_bita.Append("INSERT INTO [SAE60Empre08].[dbo].[BITA08]  ")
            _query_ins_bita.Append("(CVE_BITA,[CVE_CLIE],[CVE_CAMPANIA],[CVE_ACTIVIDAD] ")
            _query_ins_bita.Append(",[FECHAHORA],[CVE_USUARIO],[OBSERVACIONES],[STATUS],[NOM_USUARIO]) ")
            _query_ins_bita.Append("VALUES ")
            _query_ins_bita.Append("(@CVE_BITA,@CVE_CLIE,@CVE_CAMPANIA,@CVE_ACTIVIDAD,@FECHAHORA ")
            _query_ins_bita.Append(",@CVE_USUARIO,@OBSERVACIONES,@STATUS,@NOM_USUARIO) ")
            Dim _cmd_ins_bita As New SqlCommand(_query_ins_bita.ToString, miconexion)

            _cmd_ins_bita.Parameters.AddWithValue("@CVE_BITA", dt_GETBITA.Rows(0)(0))
            _cmd_ins_bita.Parameters.AddWithValue("@CVE_CLIE", dt_encabezado.Rows(0)(2))
            _cmd_ins_bita.Parameters.AddWithValue("@CVE_CAMPANIA", "_SAE_")
            _cmd_ins_bita.Parameters.AddWithValue("@CVE_ACTIVIDAD", "   12")
            _cmd_ins_bita.Parameters.AddWithValue("@FECHAHORA", DateTime.Now)
            _cmd_ins_bita.Parameters.AddWithValue("@CVE_USUARIO", 0)
            _cmd_ins_bita.Parameters.AddWithValue("@OBSERVACIONES", "No.[] L " & Convert.ToDouble(dt_encabezado.Rows(0)(5)))
            _cmd_ins_bita.Parameters.AddWithValue("@STATUS", "F")
            _cmd_ins_bita.Parameters.AddWithValue("@NOM_USUARIO", "nc-rpt")
            _cmd_ins_bita.Transaction = mitransacion
            _cmd_ins_bita.ExecuteNonQuery()

            Dim _query_factd_clib As New StringBuilder
            _query_factd_clib.Append("INSERT INTO [SAE60Empre08].[dbo].[FACTD_CLIB08] ")
            _query_factd_clib.Append("([CLAVE_DOC],[CAMPLIB20]) ")
            _query_factd_clib.Append("VALUES(@CLAVE_DOC, @CAMPLIB20) ")
            Dim _cmd_factd_clib As New SqlCommand(_query_factd_clib.ToString, miconexion)
            _cmd_factd_clib.Parameters.AddWithValue("@CLAVE_DOC", documento)
            _cmd_factd_clib.Parameters.AddWithValue("@CAMPLIB20", tipo_camplib20)
            _cmd_factd_clib.Transaction = mitransacion
            _cmd_factd_clib.ExecuteNonQuery()

            Dim _query_clie As New StringBuilder
            _query_clie.Append("UPDATE [SAE60Empre08].[dbo].[CLIE08] ")
            _query_clie.Append("SET [SALDO] = SALDO - @VALOR ")
            _query_clie.Append("WHERE ([CLAVE] = @CLAVE)")
            Dim _cmd_clie As New SqlCommand(_query_clie.ToString, miconexion)
            _cmd_clie.Parameters.AddWithValue("@VALOR", dt_encabezado.Rows(0)(5))
            _cmd_clie.Parameters.AddWithValue("@CLAVE", dt_encabezado.Rows(0)(2))
            _cmd_clie.Transaction = mitransacion
            _cmd_clie.ExecuteNonQuery()

            Dim _query_cuendet As New StringBuilder
            _query_cuendet.Append("INSERT INTO [SAE60Empre08].[dbo].[CUEN_DET08] ")
            _query_cuendet.Append("([CVE_CLIE],[REFER],[ID_MOV],[NUM_CPTO],[NUM_CARGO] ")
            _query_cuendet.Append(",[CVE_OBS],[NO_FACTURA],[DOCTO],[IMPORTE],[FECHA_APLI],[FECHA_VENC] ")
            _query_cuendet.Append(",[STRCVEVEND],[NUM_MONED],[TCAMBIO],[IMPMON_EXT],[FECHAELAB] ")
            _query_cuendet.Append(",[TIPO_MOV],[SIGNO],[USUARIO] ")
            _query_cuendet.Append(",[NO_PARTIDA],[AFEC_COI]) ")
            _query_cuendet.Append(" VALUES ")
            _query_cuendet.Append("(@CVE_CLIE,@REFER,1,12,1,0,@NO_FACTURA,@DOCTO ")
            _query_cuendet.Append(",@IMPORTE,@FECHA_APLI,@FECHA_VENC,@STRCVEVEND,1,1, ")
            _query_cuendet.Append(" @IMPMON_EXT, @FECHAELAB, 'A', -1,0,1,'A')")

            Dim _cmd_cuendet As New SqlCommand(_query_cuendet.ToString, miconexion)
            _cmd_cuendet.Parameters.AddWithValue("@CVE_CLIE", dt_encabezado.Rows(0)(2))
            _cmd_cuendet.Parameters.AddWithValue("@REFER", dt_encabezado.Rows(0)(1))
            _cmd_cuendet.Parameters.AddWithValue("@NO_FACTURA", dt_encabezado.Rows(0)(1))
            _cmd_cuendet.Parameters.AddWithValue("@DOCTO", documento)
            _cmd_cuendet.Parameters.AddWithValue("@IMPORTE", dt_encabezado.Rows(0)(5))
            _cmd_cuendet.Parameters.AddWithValue("@FECHA_APLI", fecha_doc)
            _cmd_cuendet.Parameters.AddWithValue("@FECHA_VENC", fecha_doc)
            _cmd_cuendet.Parameters.AddWithValue("@STRCVEVEND", dt_encabezado.Rows(0)(0))
            _cmd_cuendet.Parameters.AddWithValue("@IMPMON_EXT", dt_encabezado.Rows(0)(5))
            _cmd_cuendet.Parameters.AddWithValue("@FECHAELAB", Now.Date)
            _cmd_cuendet.Transaction = mitransacion
            _cmd_cuendet.ExecuteNonQuery()

            If dt_encabezado.Rows(0)(4) = "CONTADO" Then
                Dim _query_clie_CARGOXDEV As New StringBuilder
                _query_clie_CARGOXDEV.Append("UPDATE [SAE60Empre08].[dbo].[CLIE08] ")
                _query_clie_CARGOXDEV.Append("SET [SALDO] = SALDO + @VALOR ")
                _query_clie_CARGOXDEV.Append("WHERE ([CLAVE] = @CLAVE)")
                Dim _cmd_clie_CARGOXDEV As New SqlCommand(_query_clie_CARGOXDEV.ToString, miconexion)
                _cmd_clie_CARGOXDEV.Parameters.AddWithValue("@VALOR", dt_encabezado.Rows(0)(5))
                _cmd_clie_CARGOXDEV.Parameters.AddWithValue("@CLAVE", dt_encabezado.Rows(0)(2))
                _cmd_clie_CARGOXDEV.Transaction = mitransacion
                _cmd_clie_CARGOXDEV.ExecuteNonQuery()

                Dim _query_cuendet_CARGOXDEV As New StringBuilder
                _query_cuendet_CARGOXDEV.Append("INSERT INTO [SAE60Empre08].[dbo].[CUEN_DET08] ")
                _query_cuendet_CARGOXDEV.Append("([CVE_CLIE],[REFER],[ID_MOV],[NUM_CPTO],[NUM_CARGO] ")
                _query_cuendet_CARGOXDEV.Append(",[CVE_OBS],[NO_FACTURA],[DOCTO],[IMPORTE],[FECHA_APLI],[FECHA_VENC] ")
                _query_cuendet_CARGOXDEV.Append(",[STRCVEVEND],[NUM_MONED],[TCAMBIO],[IMPMON_EXT],[FECHAELAB] ")
                _query_cuendet_CARGOXDEV.Append(",[TIPO_MOV],[SIGNO],[USUARIO] ")
                _query_cuendet_CARGOXDEV.Append(",[NO_PARTIDA],[AFEC_COI]) ")
                _query_cuendet_CARGOXDEV.Append(" VALUES ")
                _query_cuendet_CARGOXDEV.Append("(@CVE_CLIE,@REFER,1,31,1,0,@NO_FACTURA,@DOCTO ")
                _query_cuendet_CARGOXDEV.Append(",@IMPORTE,@FECHA_APLI,@FECHA_VENC,@STRCVEVEND,1,1, ")
                _query_cuendet_CARGOXDEV.Append(" @IMPMON_EXT, @FECHAELAB, 'C', 1,0,2,'')")

                Dim _cmd_cuendet_CARGOXDEV As New SqlCommand(_query_cuendet_CARGOXDEV.ToString, miconexion)
                _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@CVE_CLIE", dt_encabezado.Rows(0)(2))
                _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@REFER", dt_encabezado.Rows(0)(1))
                _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@NO_FACTURA", dt_encabezado.Rows(0)(1))
                _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@DOCTO", documento) '"NC" & ult_doc)
                _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@IMPORTE", dt_encabezado.Rows(0)(5))
                _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@FECHA_APLI", fecha_doc)
                _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@FECHA_VENC", fecha_doc)
                _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@STRCVEVEND", dt_encabezado.Rows(0)(0))
                _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@IMPMON_EXT", dt_encabezado.Rows(0)(5))
                _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@FECHAELAB", Now.Date)
                _cmd_cuendet_CARGOXDEV.Transaction = mitransacion
                _cmd_cuendet_CARGOXDEV.ExecuteNonQuery()

                Dim _query_ins_bita_cargoxdev As New StringBuilder
                _query_ins_bita_cargoxdev.Append("INSERT INTO [SAE60Empre08].[dbo].[BITA08]  ")
                _query_ins_bita_cargoxdev.Append("(CVE_BITA,[CVE_CLIE],[CVE_CAMPANIA],[CVE_ACTIVIDAD] ")
                _query_ins_bita_cargoxdev.Append(",[FECHAHORA],[CVE_USUARIO],[OBSERVACIONES],[STATUS],[NOM_USUARIO]) ")
                _query_ins_bita_cargoxdev.Append("VALUES ")
                _query_ins_bita_cargoxdev.Append("(@CVE_BITA,@CVE_CLIE,@CVE_CAMPANIA,@CVE_ACTIVIDAD,@FECHAHORA ")
                _query_ins_bita_cargoxdev.Append(",@CVE_USUARIO,@OBSERVACIONES,@STATUS,@NOM_USUARIO) ")
                Dim _cmd_ins_bita_cargoxdev As New SqlCommand(_query_ins_bita_cargoxdev.ToString, miconexion)

                _cmd_ins_bita_cargoxdev.Parameters.AddWithValue("@CVE_BITA", dt_GETBITA.Rows(0)(0) + 1)
                _cmd_ins_bita_cargoxdev.Parameters.AddWithValue("@CVE_CLIE", dt_encabezado.Rows(0)(2))
                _cmd_ins_bita_cargoxdev.Parameters.AddWithValue("@CVE_CAMPANIA", "_SAE_")
                _cmd_ins_bita_cargoxdev.Parameters.AddWithValue("@CVE_ACTIVIDAD", "    6")
                _cmd_ins_bita_cargoxdev.Parameters.AddWithValue("@FECHAHORA", DateTime.Now)
                _cmd_ins_bita_cargoxdev.Parameters.AddWithValue("@CVE_USUARIO", 0)
                _cmd_ins_bita_cargoxdev.Parameters.AddWithValue("@OBSERVACIONES", "No.[" & documento & "] L " & Convert.ToDouble(dt_encabezado.Rows(0)(5)))
                _cmd_ins_bita_cargoxdev.Parameters.AddWithValue("@STATUS", "F")
                _cmd_ins_bita_cargoxdev.Parameters.AddWithValue("@NOM_USUARIO", "nc-rpt")
                _cmd_ins_bita_cargoxdev.Transaction = mitransacion
                _cmd_ins_bita_cargoxdev.ExecuteNonQuery()

                Dim _query_control2_cargoxdev As New StringBuilder
                _query_control2_cargoxdev.Append("UPDATE [SAE60Empre08].[dbo].[TBLCONTROL08] ")
                _query_control2_cargoxdev.Append(" SET [ULT_CVE] = ULT_CVE + 1 ")
                _query_control2_cargoxdev.Append("WHERE [ID_TABLA] = 62 ")
                Dim _cmd_control2_cargoxdev As New SqlCommand(_query_control2_cargoxdev.ToString, miconexion)
                _cmd_control2_cargoxdev.Transaction = mitransacion
                _cmd_control2_cargoxdev.ExecuteNonQuery()
            End If

            'PARTIDAS DEL DOCUMENTO
            For index As Integer = 0 To dt_parfactd.Rows.Count - 1
                'debe ir en cada partida
                Dim _query_doctosig As New StringBuilder

                _query_doctosig.Append("INSERT INTO [SAE60Empre08].[dbo].[DOCTOSIGF08] ")
                _query_doctosig.Append("([TIP_DOC],[CVE_DOC],[ANT_SIG],[TIP_DOC_E] ")
                _query_doctosig.Append(",[CVE_DOC_E],[PARTIDA],[PART_E],[CANT_E]) ")
                _query_doctosig.Append("VALUES ")
                _query_doctosig.Append("('D',@CVE_DOC,'A', 'F',@CVE_DOC_E,@PARTIDA,0,0)")
                Dim _cmd_doctosig As New SqlCommand(_query_doctosig.ToString, miconexion)
                _cmd_doctosig.Parameters.AddWithValue("@CVE_DOC", documento)
                _cmd_doctosig.Parameters.AddWithValue("@CVE_DOC_E", dt_encabezado.Rows(0)(1))
                _cmd_doctosig.Parameters.AddWithValue("@PARTIDA", index + 1)
                _cmd_doctosig.Transaction = mitransacion
                _cmd_doctosig.ExecuteNonQuery()

                Dim _query_par_factd As New StringBuilder
                _query_par_factd.Append("INSERT INTO [SAE60Empre08].[dbo].[PAR_FACTD08] ")
                _query_par_factd.Append("           ([CVE_DOC],[NUM_PAR],[CVE_ART],[CANT],[PXS],[PREC] ")
                _query_par_factd.Append("           ,[COST],[IMPU1],[IMPU2],[IMPU3],[IMPU4],[IMP1APLA] ")
                _query_par_factd.Append("           ,[IMP2APLA],[IMP3APLA],[IMP4APLA],[TOTIMP1],[TOTIMP2] ")
                _query_par_factd.Append("           ,[TOTIMP3],[TOTIMP4],[DESC1],[DESC2],[DESC3],[COMI] ")
                _query_par_factd.Append("           ,[APAR],[ACT_INV],[NUM_ALM],[TIP_CAM] ")
                _query_par_factd.Append("           ,[UNI_VENTA],[TIPO_PROD],[CVE_OBS],[REG_SERIE],[E_LTPD] ")
                _query_par_factd.Append("           ,[TIPO_ELEM],[NUM_MOV],[TOT_PARTIDA],[IMPRIMIR]) ")
                _query_par_factd.Append("VALUES    (@CVE_DOC,@NUM_PAR,@CVE_ART,@CANT,@PXS,@PREC,0,0,0, ")
                _query_par_factd.Append("           0,@IMPU4,0,0,0,0,0, 0,0,@TOTIMP4,0,0,0,0,0,'S',@NUM_ALM, ")
                _query_par_factd.Append("           1,@UNI_VENTA,'S',0,0,0,'N',0,@TOT_PARTIDA,'S')")
                Dim _cmd_par_factd As New SqlCommand(_query_par_factd.ToString, miconexion)
                _cmd_par_factd.Parameters.AddWithValue("@CVE_DOC", documento)
                _cmd_par_factd.Parameters.AddWithValue("@NUM_PAR", index + 1)
                _cmd_par_factd.Parameters.AddWithValue("@CVE_ART", dt_parfactd.Rows(index)(0))
                _cmd_par_factd.Parameters.AddWithValue("@CANT", dt_parfactd.Rows(index)(1))
                _cmd_par_factd.Parameters.AddWithValue("@PXS", dt_parfactd.Rows(index)(2))
                _cmd_par_factd.Parameters.AddWithValue("@PREC", dt_parfactd.Rows(index)(3))
                _cmd_par_factd.Parameters.AddWithValue("@IMPU4", dt_parfactd.Rows(index)(4))
                _cmd_par_factd.Parameters.AddWithValue("@TOTIMP4", dt_parfactd.Rows(index)(5))
                _cmd_par_factd.Parameters.AddWithValue("@NUM_ALM", dt_encabezado.Rows(0)(3))
                _cmd_par_factd.Parameters.AddWithValue("@UNI_VENTA", dt_parfactd.Rows(index)(6))
                _cmd_par_factd.Parameters.AddWithValue("@TOT_PARTIDA", dt_parfactd.Rows(index)(7))
                _cmd_par_factd.Transaction = mitransacion
                _cmd_par_factd.ExecuteNonQuery()

                Dim _query_par_factd_clib As New StringBuilder
                _query_par_factd_clib.Append("INSERT INTO [SAE60Empre08].[dbo].[PAR_FACTD_CLIB08] ")
                _query_par_factd_clib.Append("([CLAVE_DOC],[NUM_PART]) ")
                _query_par_factd_clib.Append("VALUES(@CLAVE_DOC, @NUM_PART)")
                Dim _cmd_par_factd_clib As New SqlCommand(_query_par_factd_clib.ToString, miconexion)
                _cmd_par_factd_clib.Parameters.AddWithValue("@CLAVE_DOC", documento)
                _cmd_par_factd_clib.Parameters.AddWithValue("@NUM_PART", index + 1)
                _cmd_par_factd_clib.Transaction = mitransacion
                _cmd_par_factd_clib.ExecuteNonQuery()
            Next

            Dim _query_control1 As New StringBuilder
            _query_control1.Append("UPDATE [SAE60Empre08].[dbo].[TBLCONTROL08] ")
            _query_control1.Append(" SET [ULT_CVE] = ULT_CVE + 1 ")
            _query_control1.Append("WHERE [ID_TABLA] = 32 ")
            Dim _cmd_control1 As New SqlCommand(_query_control1.ToString, miconexion)
            _cmd_control1.Transaction = mitransacion
            _cmd_control1.ExecuteNonQuery()

            Dim _query_control2 As New StringBuilder
            _query_control2.Append("UPDATE [SAE60Empre08].[dbo].[TBLCONTROL08] ")
            _query_control2.Append(" SET [ULT_CVE] = ULT_CVE + 1 ")
            _query_control2.Append("WHERE [ID_TABLA] = 62 ")
            Dim _cmd_control2 As New SqlCommand(_query_control2.ToString, miconexion)
            _cmd_control2.Transaction = mitransacion
            _cmd_control2.ExecuteNonQuery()

            Dim _query_foliosf As New StringBuilder
            _query_foliosf.Append("UPDATE [SAE60Empre08].[dbo].[FOLIOSF08] ")
            _query_foliosf.Append(" SET [ULT_DOC] = ULT_DOC +1 ")
            _query_foliosf.Append("WHERE [SERIE] = @SERIE")
            Dim _cmd_foliosf As New SqlCommand(_query_foliosf.ToString, miconexion)
            _cmd_foliosf.Parameters.AddWithValue("@SERIE", serie)
            _cmd_foliosf.Transaction = mitransacion
            _cmd_foliosf.ExecuteNonQuery()

            mitransacion.Commit()
            miconexion.Close()
            variable_error = "correcto"

        Catch ex As Exception
            mitransacion.Rollback()
            miconexion.Close()
            variable_error = ex.Message
        End Try

        Return variable_error
    End Function

    Public Function delete_descuento_tactico(ByVal DOCTO As String, ByVal fecha_descuento As Date)
        Dim miconexion As New SqlConnection(conexion.CadenaSQL)
        Dim mitransaccion As SqlTransaction
        miconexion.Open()
        mitransaccion = miconexion.BeginTransaction

        Try
            Dim query_e As New StringBuilder
            query_e.Append("DELETE FROM [tactical_discount_SanRafael].[dbo].[encabezados] ")
            query_e.Append("WHERE CODIGO = @DOCTO")
            Dim micomando_e As New SqlCommand(query_e.ToString, miconexion)
            micomando_e.Parameters.AddWithValue("@DOCTO", DOCTO)
            micomando_e.Transaction = mitransaccion
            micomando_e.ExecuteNonQuery()

            Dim query As New StringBuilder
            query.Append("SELECT MONTO,PROVEEDOR ")
            query.Append("FROM partidas ")
            query.Append("WHERE (CODIGO = @CODIGO) ")
            Dim micomando As New SqlCommand(query.ToString, miconexion)
            micomando.Transaction = mitransaccion
            micomando.Parameters.AddWithValue("@CODIGO", DOCTO)
            Dim adaptador As New SqlDataAdapter(micomando)
            Dim dt As New DataTable
            adaptador.Fill(dt)

            For index As Integer = 0 To dt.Rows.Count - 1
                Dim query_presupuestos As New StringBuilder
                query_presupuestos.Append("UPDATE presupuestos ")
                query_presupuestos.Append("SET Restante = Restante + @VALOR ")
                query_presupuestos.Append("WHERE AñoId = @AÑO AND MesId = @MES AND ProveedorId = @PROVEEDOR")

                Dim micomando_presupuesto As New SqlCommand(query_presupuestos.ToString, miconexion)
                micomando_presupuesto.Parameters.AddWithValue("@VALOR", dt.Rows(0)(0))
                micomando_presupuesto.Parameters.AddWithValue("@AÑO", fecha_descuento.Year)
                micomando_presupuesto.Parameters.AddWithValue("@MES", fecha_descuento.Month)
                micomando_presupuesto.Parameters.AddWithValue("@PROVEEDOR", dt.Rows(0)(1))
                micomando_presupuesto.Transaction = mitransaccion
                micomando_presupuesto.ExecuteNonQuery()
            Next

            Dim query_p As New StringBuilder
            query_p.Append("DELETE FROM [tactical_discount_SanRafael].[dbo].[partidas] ")
            query_p.Append("WHERE CODIGO = @DOCTO ")
            Dim micomando_p As New SqlCommand(query_p.ToString, miconexion)
            micomando_p.Parameters.AddWithValue("@DOCTO", DOCTO)
            micomando_p.Transaction = mitransaccion
            micomando_p.ExecuteNonQuery()

            mitransaccion.Commit()
            miconexion.Close()
            Return "correcto"
        Catch ex As Exception
            mitransaccion.Rollback()
            miconexion.Close()
            Return ex.Message
        End Try
    End Function

    Public Function delete_descuento_tactico_dimosa(ByVal DOCTO As String, ByVal fecha_descuento As Date)
        Dim miconexion As New SqlConnection(conexion_dimosa.CadenaSQL)
        Dim mitransaccion As SqlTransaction
        miconexion.Open()
        mitransaccion = miconexion.BeginTransaction

        Try
            Dim query_e As New StringBuilder
            query_e.Append("DELETE FROM [tactical_discount_Dimosa].[dbo].[encabezados] ")
            query_e.Append("WHERE CODIGO = @DOCTO")
            Dim micomando_e As New SqlCommand(query_e.ToString, miconexion)
            micomando_e.Parameters.AddWithValue("@DOCTO", DOCTO)
            micomando_e.Transaction = mitransaccion
            micomando_e.ExecuteNonQuery()

            Dim query As New StringBuilder
            query.Append("SELECT MONTO,PROVEEDOR ")
            query.Append("FROM partidas ")
            query.Append("WHERE (CODIGO = @CODIGO) ")
            Dim micomando As New SqlCommand(query.ToString, miconexion)
            micomando.Transaction = mitransaccion
            micomando.Parameters.AddWithValue("@CODIGO", DOCTO)
            Dim adaptador As New SqlDataAdapter(micomando)
            Dim dt As New DataTable
            adaptador.Fill(dt)

            For index As Integer = 0 To dt.Rows.Count - 1
                Dim query_presupuestos As New StringBuilder
                query_presupuestos.Append("UPDATE presupuestos ")
                query_presupuestos.Append("SET Restante = Restante + @VALOR ")
                query_presupuestos.Append("WHERE AñoId = @AÑO AND MesId = @MES AND ProveedorId = @PROVEEDOR")

                Dim micomando_presupuesto As New SqlCommand(query_presupuestos.ToString, miconexion)
                micomando_presupuesto.Parameters.AddWithValue("@VALOR", dt.Rows(0)(0))
                micomando_presupuesto.Parameters.AddWithValue("@AÑO", fecha_descuento.Year)
                micomando_presupuesto.Parameters.AddWithValue("@MES", fecha_descuento.Month)
                micomando_presupuesto.Parameters.AddWithValue("@PROVEEDOR", dt.Rows(0)(1))
                micomando_presupuesto.Transaction = mitransaccion
                micomando_presupuesto.ExecuteNonQuery()
            Next

            Dim query_p As New StringBuilder
            query_p.Append("DELETE FROM [tactical_discount_Dimosa].[dbo].[partidas] ")
            query_p.Append("WHERE CODIGO = @DOCTO ")
            Dim micomando_p As New SqlCommand(query_p.ToString, miconexion)
            micomando_p.Parameters.AddWithValue("@DOCTO", DOCTO)
            micomando_p.Transaction = mitransaccion
            micomando_p.ExecuteNonQuery()

            mitransaccion.Commit()
            miconexion.Close()
            Return "correcto"
        Catch ex As Exception
            mitransaccion.Rollback()
            miconexion.Close()
            Return ex.Message
        End Try
    End Function

    Public Function delete_descuento_tactico_opl(ByVal DOCTO As String, ByVal fecha_descuento As Date)
        Dim miconexion As New SqlConnection(conexion_Descuentos_Opl.CadenaSQL)
        Dim mitransaccion As SqlTransaction
        miconexion.Open()
        mitransaccion = miconexion.BeginTransaction

        Try
            Dim query_e As New StringBuilder
            query_e.Append("DELETE FROM [tactical_discount_OPL].[dbo].[encabezados] ")
            query_e.Append("WHERE CODIGO = @DOCTO")
            Dim micomando_e As New SqlCommand(query_e.ToString, miconexion)
            micomando_e.Parameters.AddWithValue("@DOCTO", DOCTO)
            micomando_e.Transaction = mitransaccion
            micomando_e.ExecuteNonQuery()

            Dim query As New StringBuilder
            query.Append("SELECT MONTO,PROVEEDOR ")
            query.Append("FROM partidas ")
            query.Append("WHERE (CODIGO = @CODIGO) ")
            Dim micomando As New SqlCommand(query.ToString, miconexion)
            micomando.Transaction = mitransaccion
            micomando.Parameters.AddWithValue("@CODIGO", DOCTO)
            Dim adaptador As New SqlDataAdapter(micomando)
            Dim dt As New DataTable
            adaptador.Fill(dt)

            For index As Integer = 0 To dt.Rows.Count - 1
                Dim query_presupuestos As New StringBuilder
                query_presupuestos.Append("UPDATE presupuestos ")
                query_presupuestos.Append("SET Restante = Restante + @VALOR ")
                query_presupuestos.Append("WHERE AñoId = @AÑO AND MesId = @MES AND ProveedorId = @PROVEEDOR")

                Dim micomando_presupuesto As New SqlCommand(query_presupuestos.ToString, miconexion)
                micomando_presupuesto.Parameters.AddWithValue("@VALOR", dt.Rows(0)(0))
                micomando_presupuesto.Parameters.AddWithValue("@AÑO", fecha_descuento.Year)
                micomando_presupuesto.Parameters.AddWithValue("@MES", fecha_descuento.Month)
                micomando_presupuesto.Parameters.AddWithValue("@PROVEEDOR", dt.Rows(0)(1))
                micomando_presupuesto.Transaction = mitransaccion
                micomando_presupuesto.ExecuteNonQuery()
            Next

            Dim query_p As New StringBuilder
            query_p.Append("DELETE FROM [tactical_discount_OPL].[dbo].[partidas] ")
            query_p.Append("WHERE CODIGO = @DOCTO ")
            Dim micomando_p As New SqlCommand(query_p.ToString, miconexion)
            micomando_p.Parameters.AddWithValue("@DOCTO", DOCTO)
            micomando_p.Transaction = mitransaccion
            micomando_p.ExecuteNonQuery()

            mitransaccion.Commit()
            miconexion.Close()
            Return "correcto"
        Catch ex As Exception
            mitransaccion.Rollback()
            miconexion.Close()
            Return ex.Message
        End Try
    End Function

    Public Function listar_partida(ByVal CODIGO As String) As DataTable
        Dim query As New StringBuilder
        query.Append("SELECT CVE_ART, CANTIDAD, MONTO, ")
        query.Append("PROVEEDOR,CONCEPTO,ISV,SUBTOTAL FROM partidas ")
        query.Append("WHERE (CODIGO = @CODIGO) ")
        Dim miconexion As New SqlConnection(conexion.CadenaSQL)
        miconexion.Open()
        Dim micomando As New SqlCommand(query.ToString, miconexion)
        micomando.Parameters.AddWithValue("@CODIGO", CODIGO)
        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        miconexion.Close()
        Return dt
    End Function

    Public Function listar_partida_dimosa(ByVal CODIGO As String) As DataTable
        Dim query As New StringBuilder
        query.Append("SELECT CVE_ART, CANTIDAD, MONTO, ")
        query.Append("PROVEEDOR,CONCEPTO,ISV,SUBTOTAL FROM partidas ")
        query.Append("WHERE (CODIGO = @CODIGO) ")
        Dim miconexion As New SqlConnection(conexion_dimosa.CadenaSQL)
        miconexion.Open()
        Dim micomando As New SqlCommand(query.ToString, miconexion)
        micomando.Parameters.AddWithValue("@CODIGO", CODIGO)
        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        miconexion.Close()
        Return dt
    End Function



    Public Function listar_partida_OPL(ByVal CODIGO As String) As DataTable
        Dim query As New StringBuilder
        query.Append("SELECT CVE_ART, CANTIDAD, MONTO, ")
        query.Append("PROVEEDOR,CONCEPTO,ISV,SUBTOTAL FROM partidas ")
        query.Append("WHERE (CODIGO = @CODIGO) ")
        Dim miconexion As New SqlConnection(conexion_Descuentos_Opl.CadenaSQL)
        miconexion.Open()
        Dim micomando As New SqlCommand(query.ToString, miconexion)
        micomando.Parameters.AddWithValue("@CODIGO", CODIGO)
        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        miconexion.Close()
        Return dt
    End Function

    Public Function listar_datos_adicionales(ByVal CODIGO As String) As DataTable
        Dim query As New StringBuilder
        query.Append("SELECT FECHA_SAE, RFC, FECHA_ENTREGA, CAMPLIB20, ALMACEN, ESTADO,VENDEDOR ")
        query.Append("FROM encabezados ")
        query.Append("WHERE (CODIGO = @CODIGO) ")
        Dim miconexion As New SqlConnection(conexion.CadenaSQL)
        miconexion.Open()
        Dim micomando As New SqlCommand(query.ToString, miconexion)
        micomando.Parameters.AddWithValue("@CODIGO", CODIGO)
        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        miconexion.Close()
        Return dt
    End Function

    Public Function listar_datos_adicionales_dimosa(ByVal CODIGO As String) As DataTable
        Dim query As New StringBuilder
        query.Append("SELECT FECHA_SAE, RFC, FECHA_ENTREGA, CAMPLIB20, ALMACEN, ESTADO,VENDEDOR ")
        query.Append("FROM encabezados ")
        query.Append("WHERE (CODIGO = @CODIGO) ")
        Dim miconexion As New SqlConnection(conexion_dimosa.CadenaSQL)
        miconexion.Open()
        Dim micomando As New SqlCommand(query.ToString, miconexion)
        micomando.Parameters.AddWithValue("@CODIGO", CODIGO)
        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        miconexion.Close()
        Return dt
    End Function

    Public Function listar_datos_adicionales_opl(ByVal CODIGO As String) As DataTable
        Dim query As New StringBuilder
        query.Append("SELECT FECHA_SAE, RFC, FECHA_ENTREGA, CAMPLIB20, ALMACEN, ESTADO,VENDEDOR ")
        query.Append("FROM encabezados ")
        query.Append("WHERE (CODIGO = @CODIGO) ")
        Dim miconexion As New SqlConnection(conexion_Descuentos_Opl.CadenaSQL)
        miconexion.Open()
        Dim micomando As New SqlCommand(query.ToString, miconexion)
        micomando.Parameters.AddWithValue("@CODIGO", CODIGO)
        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        miconexion.Close()
        Return dt
    End Function

    Public Function productos_factura(ByVal DOCTO As String) As DataTable
        Dim query As New StringBuilder
        query.Append("SELECT IV.CVE_ART AS CODIGO, IV.DESCR AS PRODUCTO, PF.CANT AS CANTIDAD, ")
        query.Append("PV.CLAVE AS COD_PROVEEDOR, PV.NOMBRE AS PROVEEDOR, ISV.IMPUESTO4 AS ISV, ")
        query.Append("(PF.CANT*PF.PREC-(PF.CANT*PF.PREC*(PF.DESC1/100))+PF.TOTIMP4) AS IMPORTE ")
        query.Append("FROM dbo.PAR_FACTF05 PF INNER JOIN dbo.INVE05 IV ON PF.CVE_ART = IV.CVE_ART ")
        query.Append("INNER JOIN dbo.PRVPROD05 PVPR ON PF.CVE_ART = PVPR.CVE_ART INNER JOIN ")
        query.Append("dbo.PROV05 PV ON PVPR.CVE_PROV = PV.CLAVE INNER JOIN IMPU05 ISV ")
        query.Append("ON ISV.CVE_ESQIMPU = IV.CVE_ESQIMPU ")
        query.Append("WHERE (PF.CVE_DOC = @DOCTO) ")
        Dim miconexion As New SqlConnection(conexion_consumo.CadenaSQL)
        miconexion.Open()
        Dim micomando As New SqlCommand(query.ToString, miconexion)
        micomando.Parameters.AddWithValue("@DOCTO", DOCTO)
        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        miconexion.Close()
        Return dt
    End Function

    Public Function productos_factura_dimosa(ByVal DOCTO As String) As DataTable
        Dim query As New StringBuilder
        query.Append("SELECT IV.CVE_ART AS CODIGO, IV.DESCR AS PRODUCTO, PF.CANT AS CANTIDAD, ")
        query.Append("PV.CLAVE AS COD_PROVEEDOR, PV.NOMBRE AS PROVEEDOR, ISV.IMPUESTO4 AS ISV, ")
        query.Append("(PF.CANT*PF.PREC-(PF.CANT*PF.PREC*(PF.DESC1/100))+PF.TOTIMP4) AS IMPORTE ")
        query.Append("FROM dbo.PAR_FACTF06 PF INNER JOIN dbo.INVE06 IV ON PF.CVE_ART = IV.CVE_ART ")
        query.Append("INNER JOIN dbo.PRVPROD06 PVPR ON PF.CVE_ART = PVPR.CVE_ART INNER JOIN ")
        query.Append("dbo.PROV06 PV ON PVPR.CVE_PROV = PV.CLAVE INNER JOIN IMPU06 ISV ")
        query.Append("ON ISV.CVE_ESQIMPU = IV.CVE_ESQIMPU ")
        query.Append("WHERE (PF.CVE_DOC = @DOCTO) ")
        Dim miconexion As New SqlConnection(conexion_consumo_dimosa.CadenaSQL)
        miconexion.Open()
        Dim micomando As New SqlCommand(query.ToString, miconexion)
        micomando.Parameters.AddWithValue("@DOCTO", DOCTO)
        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        miconexion.Close()
        Return dt
    End Function

    Public Function productos_factura_opl(ByVal DOCTO As String) As DataTable
        Dim query As New StringBuilder
        query.Append("SELECT IV.CVE_ART AS CODIGO, IV.DESCR AS PRODUCTO, PF.CANT AS CANTIDAD, ")
        query.Append("PV.CLAVE AS COD_PROVEEDOR, PV.NOMBRE AS PROVEEDOR, ISV.IMPUESTO4 AS ISV, ")
        query.Append("(PF.CANT*PF.PREC-(PF.CANT*PF.PREC*(PF.DESC1/100))+PF.TOTIMP4) AS IMPORTE ")
        query.Append("FROM dbo.PAR_FACTF08 PF INNER JOIN dbo.INVE08 IV ON PF.CVE_ART = IV.CVE_ART ")
        query.Append("INNER JOIN dbo.PRVPROD08 PVPR ON PF.CVE_ART = PVPR.CVE_ART INNER JOIN ")
        query.Append("dbo.PROV08 PV ON PVPR.CVE_PROV = PV.CLAVE INNER JOIN IMPU08 ISV ")
        query.Append("ON ISV.CVE_ESQIMPU = IV.CVE_ESQIMPU ")
        query.Append("WHERE (PF.CVE_DOC = @DOCTO) ")
        Dim miconexion As New SqlConnection(conexion_OPL.CadenaSQL)
        miconexion.Open()
        Dim micomando As New SqlCommand(query.ToString, miconexion)
        micomando.Parameters.AddWithValue("@DOCTO", DOCTO)
        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        miconexion.Close()
        Return dt
    End Function

    Public Function reporte_resumen(ByVal FECHA_INI As Date, ByVal FECHA_FIN As Date, ByVal ALMACEN As Integer)
        Dim actualizarconexion As New SqlConnection(conexion.CadenaSQL)
        Dim micomando As New SqlCommand("des_tac_resumen", actualizarconexion)
        micomando.CommandType = CommandType.StoredProcedure
        micomando.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.Date)).Value = FECHA_INI
        micomando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.Date)).Value = FECHA_FIN
        micomando.Parameters.Add(New SqlParameter("@ALMACEN", SqlDbType.Int)).Value = ALMACEN
        actualizarconexion.Open()
        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        actualizarconexion.Close()
        Return dt
    End Function

    Public Function reporte_resumen_dimosa(ByVal FECHA_INI As Date, ByVal FECHA_FIN As Date, ByVal ALMACEN As Integer)
        Dim actualizarconexion As New SqlConnection(conexion_dimosa.CadenaSQL)
        Dim micomando As New SqlCommand("des_tac_resumen", actualizarconexion)
        micomando.CommandType = CommandType.StoredProcedure
        micomando.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.Date)).Value = FECHA_INI
        micomando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.Date)).Value = FECHA_FIN
        micomando.Parameters.Add(New SqlParameter("@ALMACEN", SqlDbType.Int)).Value = ALMACEN
        actualizarconexion.Open()
        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        actualizarconexion.Close()
        Return dt
    End Function

    Public Function reporte_resumen_opl(ByVal FECHA_INI As Date, ByVal FECHA_FIN As Date, ByVal ALMACEN As Integer)
        Dim actualizarconexion As New SqlConnection(conexion_Descuentos_Opl.CadenaSQL)
        Dim micomando As New SqlCommand("des_tac_resumen", actualizarconexion)
        micomando.CommandType = CommandType.StoredProcedure
        micomando.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.Date)).Value = FECHA_INI
        micomando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.Date)).Value = FECHA_FIN
        micomando.Parameters.Add(New SqlParameter("@ALMACEN", SqlDbType.Int)).Value = ALMACEN
        actualizarconexion.Open()
        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        actualizarconexion.Close()
        Return dt
    End Function

    Public Function listar_conceptos_proveedor() As DataTable
        Dim actualizar_conexion As New SqlConnection(conexion.CadenaSQL)
        Dim miquery As New StringBuilder
        miquery.Append("SELECT concepto_prov_id AS ID, concepto_proveedor AS CON ")
        miquery.Append("FROM concepto_proveedor")
        actualizar_conexion.Open()
        Dim micomando As New SqlCommand(miquery.ToString, actualizar_conexion)
        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        actualizar_conexion.Close()
        Return dt
    End Function

    Public Function listar_conceptos_proveedor_dimosa() As DataTable
        Dim actualizar_conexion As New SqlConnection(conexion_dimosa.CadenaSQL)
        Dim miquery As New StringBuilder
        miquery.Append("SELECT concepto_prov_id AS ID, concepto_proveedor AS CON ")
        miquery.Append("FROM concepto_proveedor")
        actualizar_conexion.Open()
        Dim micomando As New SqlCommand(miquery.ToString, actualizar_conexion)
        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        actualizar_conexion.Close()
        Return dt
    End Function

    Public Function listar_conceptos_proveedor_opl() As DataTable
        Dim actualizar_conexion As New SqlConnection(conexion_Descuentos_Opl.CadenaSQL)
        Dim miquery As New StringBuilder
        miquery.Append("SELECT concepto_prov_id AS ID, concepto_proveedor AS CON ")
        miquery.Append("FROM concepto_proveedor")
        actualizar_conexion.Open()
        Dim micomando As New SqlCommand(miquery.ToString, actualizar_conexion)
        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        actualizar_conexion.Close()
        Return dt
    End Function

    Public Function ListarDescuentos_administracion_concepto_proveedor(ByVal FECHA_INI As Date, ByVal FECHA_FIN As Date, ByVal ALMACEN As Integer)
        Dim actualizarconexion As New SqlConnection(conexion.CadenaSQL)
        Dim micomando As New SqlCommand("des_tac_resumen_concepto_proveedor", actualizarconexion)
        micomando.CommandType = CommandType.StoredProcedure
        micomando.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.Date)).Value = FECHA_INI
        micomando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.Date)).Value = FECHA_FIN
        micomando.Parameters.Add(New SqlParameter("@ALMACEN", SqlDbType.Int)).Value = ALMACEN
        actualizarconexion.Open()

        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable

        adaptador.Fill(dt)
        actualizarconexion.Close()
        Return dt
    End Function

    Public Function ListarDescuentos_administracion_concepto_proveedor_dimosa(ByVal FECHA_INI As Date, ByVal FECHA_FIN As Date, ByVal ALMACEN As Integer)
        Dim actualizarconexion As New SqlConnection(conexion_dimosa.CadenaSQL)
        Dim micomando As New SqlCommand("des_tac_resumen_concepto_proveedor", actualizarconexion)
        micomando.CommandType = CommandType.StoredProcedure
        micomando.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.Date)).Value = FECHA_INI
        micomando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.Date)).Value = FECHA_FIN
        micomando.Parameters.Add(New SqlParameter("@ALMACEN", SqlDbType.Int)).Value = ALMACEN
        actualizarconexion.Open()

        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable

        adaptador.Fill(dt)
        actualizarconexion.Close()
        Return dt
    End Function

    Public Function ListarDescuentos_administracion_concepto_proveedor_opl(ByVal FECHA_INI As Date, ByVal FECHA_FIN As Date, ByVal ALMACEN As Integer)
        Dim actualizarconexion As New SqlConnection(conexion_Descuentos_Opl.CadenaSQL)
        Dim micomando As New SqlCommand("des_tac_resumen_concepto_proveedor", actualizarconexion)
        micomando.CommandType = CommandType.StoredProcedure
        micomando.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.Date)).Value = FECHA_INI
        micomando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.Date)).Value = FECHA_FIN
        micomando.Parameters.Add(New SqlParameter("@ALMACEN", SqlDbType.Int)).Value = ALMACEN
        actualizarconexion.Open()

        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable

        adaptador.Fill(dt)
        actualizarconexion.Close()
        Return dt
    End Function

    Public Function reporte_nc_por_descuento(ByVal INI As String, ByVal FIN As String, ByVal ALMACEN As Integer, _
                                             ByVal TIPO As String, ByVal EMPRESA As String, ByVal FECHA As Date)
        Dim actualizarconexion As New SqlConnection(conexion_consumo.CadenaSQL)
        Dim micomando As New SqlCommand("rptn_nc_por_descuento", actualizarconexion)
        micomando.CommandType = CommandType.StoredProcedure
        micomando.Parameters.Add(New SqlParameter("@INI", SqlDbType.VarChar)).Value = INI
        micomando.Parameters.Add(New SqlParameter("@FIN", SqlDbType.VarChar)).Value = FIN
        micomando.Parameters.Add(New SqlParameter("@ALMACEN", SqlDbType.Int)).Value = ALMACEN
        micomando.Parameters.Add(New SqlParameter("@TIPO", SqlDbType.VarChar)).Value = TIPO
        micomando.Parameters.Add(New SqlParameter("@EMPRESA", SqlDbType.VarChar)).Value = EMPRESA
        micomando.Parameters.Add(New SqlParameter("@FECHA", SqlDbType.Date)).Value = FECHA
        actualizarconexion.Open()
        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable

        adaptador.Fill(dt)
        actualizarconexion.Close()
        Return dt
    End Function

    Public Function reporte_nc_por_descuento_dimosa(ByVal INI As String, ByVal FIN As String, ByVal ALMACEN As Integer, _
                                             ByVal TIPO As String, ByVal EMPRESA As String, ByVal FECHA As Date)
        Dim actualizarconexion As New SqlConnection(conexion_consumo_dimosa.CadenaSQL)
        Dim micomando As New SqlCommand("rptn_nc_por_descuento", actualizarconexion)
        micomando.CommandType = CommandType.StoredProcedure
        micomando.Parameters.Add(New SqlParameter("@INI", SqlDbType.VarChar)).Value = INI
        micomando.Parameters.Add(New SqlParameter("@FIN", SqlDbType.VarChar)).Value = FIN
        micomando.Parameters.Add(New SqlParameter("@ALMACEN", SqlDbType.Int)).Value = ALMACEN
        micomando.Parameters.Add(New SqlParameter("@TIPO", SqlDbType.VarChar)).Value = TIPO
        micomando.Parameters.Add(New SqlParameter("@EMPRESA", SqlDbType.VarChar)).Value = EMPRESA
        micomando.Parameters.Add(New SqlParameter("@FECHA", SqlDbType.Date)).Value = FECHA
        actualizarconexion.Open()
        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable

        adaptador.Fill(dt)
        actualizarconexion.Close()
        Return dt
    End Function

    Public Function reporte_devoluciones(ByVal INI As String, ByVal FIN As String, ByVal ALMACEN As Integer, _
                                             ByVal TIPO As String, ByVal EMPRESA As String, ByVal FECHA As Date)
        Dim actualizarconexion As New SqlConnection(conexion_consumo.CadenaSQL)
        Dim micomando As New SqlCommand("rptn_devoluciones_contabilidad", actualizarconexion)
        micomando.CommandType = CommandType.StoredProcedure
        micomando.Parameters.Add(New SqlParameter("@INI", SqlDbType.VarChar)).Value = INI
        micomando.Parameters.Add(New SqlParameter("@FIN", SqlDbType.VarChar)).Value = FIN
        micomando.Parameters.Add(New SqlParameter("@ALMACEN", SqlDbType.Int)).Value = ALMACEN
        micomando.Parameters.Add(New SqlParameter("@TIPO", SqlDbType.VarChar)).Value = TIPO
        micomando.Parameters.Add(New SqlParameter("@EMPRESA", SqlDbType.VarChar)).Value = EMPRESA
        micomando.Parameters.Add(New SqlParameter("@FECHA", SqlDbType.Date)).Value = FECHA
        actualizarconexion.Open()
        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable

        adaptador.Fill(dt)
        actualizarconexion.Close()
        Return dt
    End Function

    Public Function reporte_devoluciones_dimosa(ByVal INI As String, ByVal FIN As String, ByVal ALMACEN As Integer, _
                                             ByVal TIPO As String, ByVal EMPRESA As String, ByVal FECHA As Date)
        Dim actualizarconexion As New SqlConnection(conexion_consumo_dimosa.CadenaSQL)
        Dim micomando As New SqlCommand("rptn_devoluciones_contabilidad", actualizarconexion)
        micomando.CommandType = CommandType.StoredProcedure
        micomando.Parameters.Add(New SqlParameter("@INI", SqlDbType.VarChar)).Value = INI
        micomando.Parameters.Add(New SqlParameter("@FIN", SqlDbType.VarChar)).Value = FIN
        micomando.Parameters.Add(New SqlParameter("@ALMACEN", SqlDbType.Int)).Value = ALMACEN
        micomando.Parameters.Add(New SqlParameter("@TIPO", SqlDbType.VarChar)).Value = TIPO
        micomando.Parameters.Add(New SqlParameter("@EMPRESA", SqlDbType.VarChar)).Value = EMPRESA
        micomando.Parameters.Add(New SqlParameter("@FECHA", SqlDbType.Date)).Value = FECHA
        actualizarconexion.Open()
        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable

        adaptador.Fill(dt)
        actualizarconexion.Close()
        Return dt
    End Function

    Public Function reporte_nc_por_descuento_empresa(ByVal TIPO As String)
        Dim actualizarconexion As New SqlConnection(conexion_consumo.CadenaSQL)
        Dim micomando As New SqlCommand("rptn_nc_por_descuento", actualizarconexion)
        micomando.CommandType = CommandType.StoredProcedure
        micomando.Parameters.Add(New SqlParameter("@INI", SqlDbType.VarChar)).Value = DBNull.Value
        micomando.Parameters.Add(New SqlParameter("@FIN", SqlDbType.VarChar)).Value = DBNull.Value
        micomando.Parameters.Add(New SqlParameter("@ALMACEN", SqlDbType.Int)).Value = DBNull.Value
        micomando.Parameters.Add(New SqlParameter("@TIPO", SqlDbType.VarChar)).Value = TIPO
        micomando.Parameters.Add(New SqlParameter("@EMPRESA", SqlDbType.VarChar)).Value = DBNull.Value
        micomando.Parameters.Add(New SqlParameter("@FECHA", SqlDbType.Date)).Value = DBNull.Value
        actualizarconexion.Open()
        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable

        adaptador.Fill(dt)
        actualizarconexion.Close()
        Return dt
    End Function

    Public Function reporte_devoluciones_empresa(ByVal TIPO As String)
        Dim actualizarconexion As New SqlConnection(conexion_consumo.CadenaSQL)
        Dim micomando As New SqlCommand("rptn_devoluciones_contabilidad", actualizarconexion)
        micomando.CommandType = CommandType.StoredProcedure
        micomando.Parameters.Add(New SqlParameter("@INI", SqlDbType.VarChar)).Value = DBNull.Value
        micomando.Parameters.Add(New SqlParameter("@FIN", SqlDbType.VarChar)).Value = DBNull.Value
        micomando.Parameters.Add(New SqlParameter("@ALMACEN", SqlDbType.Int)).Value = DBNull.Value
        micomando.Parameters.Add(New SqlParameter("@TIPO", SqlDbType.VarChar)).Value = TIPO
        micomando.Parameters.Add(New SqlParameter("@EMPRESA", SqlDbType.VarChar)).Value = DBNull.Value
        micomando.Parameters.Add(New SqlParameter("@FECHA", SqlDbType.Date)).Value = DBNull.Value
        actualizarconexion.Open()
        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable

        adaptador.Fill(dt)
        actualizarconexion.Close()
        Return dt
    End Function

    Public Function reporte_devoluciones_empresa_dimosa(ByVal TIPO As String)
        Dim actualizarconexion As New SqlConnection(conexion_consumo_dimosa.CadenaSQL)
        Dim micomando As New SqlCommand("rptn_devoluciones_contabilidad", actualizarconexion)
        micomando.CommandType = CommandType.StoredProcedure
        micomando.Parameters.Add(New SqlParameter("@INI", SqlDbType.VarChar)).Value = DBNull.Value
        micomando.Parameters.Add(New SqlParameter("@FIN", SqlDbType.VarChar)).Value = DBNull.Value
        micomando.Parameters.Add(New SqlParameter("@ALMACEN", SqlDbType.Int)).Value = DBNull.Value
        micomando.Parameters.Add(New SqlParameter("@TIPO", SqlDbType.VarChar)).Value = TIPO
        micomando.Parameters.Add(New SqlParameter("@EMPRESA", SqlDbType.VarChar)).Value = DBNull.Value
        micomando.Parameters.Add(New SqlParameter("@FECHA", SqlDbType.Date)).Value = DBNull.Value
        actualizarconexion.Open()
        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable

        adaptador.Fill(dt)
        actualizarconexion.Close()
        Return dt
    End Function

    Public Function reporte_nc_por_descuento_almacen(ByVal TIPO As String, ByVal EMPRESA As String)
        Dim actualizarconexion As New SqlConnection(conexion_consumo.CadenaSQL)
        Dim micomando As New SqlCommand("rptn_nc_por_descuento", actualizarconexion)
        micomando.CommandType = CommandType.StoredProcedure
        micomando.Parameters.Add(New SqlParameter("@INI", SqlDbType.VarChar)).Value = DBNull.Value
        micomando.Parameters.Add(New SqlParameter("@FIN", SqlDbType.VarChar)).Value = DBNull.Value
        micomando.Parameters.Add(New SqlParameter("@ALMACEN", SqlDbType.Int)).Value = DBNull.Value
        micomando.Parameters.Add(New SqlParameter("@TIPO", SqlDbType.VarChar)).Value = TIPO
        micomando.Parameters.Add(New SqlParameter("@EMPRESA", SqlDbType.VarChar)).Value = EMPRESA
        micomando.Parameters.Add(New SqlParameter("@FECHA", SqlDbType.Date)).Value = DBNull.Value
        actualizarconexion.Open()
        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable

        adaptador.Fill(dt)
        actualizarconexion.Close()
        Return dt
    End Function

    Public Function reporte_nc_por_descuento_almacen_dimosa(ByVal TIPO As String, ByVal EMPRESA As String)
        Dim actualizarconexion As New SqlConnection(conexion_consumo_dimosa.CadenaSQL)
        Dim micomando As New SqlCommand("rptn_nc_por_descuento", actualizarconexion)
        micomando.CommandType = CommandType.StoredProcedure
        micomando.Parameters.Add(New SqlParameter("@INI", SqlDbType.VarChar)).Value = DBNull.Value
        micomando.Parameters.Add(New SqlParameter("@FIN", SqlDbType.VarChar)).Value = DBNull.Value
        micomando.Parameters.Add(New SqlParameter("@ALMACEN", SqlDbType.Int)).Value = DBNull.Value
        micomando.Parameters.Add(New SqlParameter("@TIPO", SqlDbType.VarChar)).Value = TIPO
        micomando.Parameters.Add(New SqlParameter("@EMPRESA", SqlDbType.VarChar)).Value = EMPRESA
        micomando.Parameters.Add(New SqlParameter("@FECHA", SqlDbType.Date)).Value = DBNull.Value
        actualizarconexion.Open()
        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable

        adaptador.Fill(dt)
        actualizarconexion.Close()
        Return dt
    End Function

    Public Function reporte_devoluciones_almacen(ByVal TIPO As String, ByVal EMPRESA As String)
        Dim actualizarconexion As New SqlConnection(conexion_consumo.CadenaSQL)
        Dim micomando As New SqlCommand("rptn_devoluciones_contabilidad", actualizarconexion)
        micomando.CommandType = CommandType.StoredProcedure
        micomando.Parameters.Add(New SqlParameter("@INI", SqlDbType.VarChar)).Value = DBNull.Value
        micomando.Parameters.Add(New SqlParameter("@FIN", SqlDbType.VarChar)).Value = DBNull.Value
        micomando.Parameters.Add(New SqlParameter("@ALMACEN", SqlDbType.Int)).Value = DBNull.Value
        micomando.Parameters.Add(New SqlParameter("@TIPO", SqlDbType.VarChar)).Value = TIPO
        micomando.Parameters.Add(New SqlParameter("@EMPRESA", SqlDbType.VarChar)).Value = EMPRESA
        micomando.Parameters.Add(New SqlParameter("@FECHA", SqlDbType.Date)).Value = DBNull.Value
        actualizarconexion.Open()
        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable

        adaptador.Fill(dt)
        actualizarconexion.Close()
        Return dt
    End Function

    Public Function reporte_devoluciones_almacen_dimosa(ByVal TIPO As String, ByVal EMPRESA As String)
        Dim actualizarconexion As New SqlConnection(conexion_consumo_dimosa.CadenaSQL)
        Dim micomando As New SqlCommand("rptn_devoluciones_contabilidad", actualizarconexion)
        micomando.CommandType = CommandType.StoredProcedure
        micomando.Parameters.Add(New SqlParameter("@INI", SqlDbType.VarChar)).Value = DBNull.Value
        micomando.Parameters.Add(New SqlParameter("@FIN", SqlDbType.VarChar)).Value = DBNull.Value
        micomando.Parameters.Add(New SqlParameter("@ALMACEN", SqlDbType.Int)).Value = DBNull.Value
        micomando.Parameters.Add(New SqlParameter("@TIPO", SqlDbType.VarChar)).Value = TIPO
        micomando.Parameters.Add(New SqlParameter("@EMPRESA", SqlDbType.VarChar)).Value = EMPRESA
        micomando.Parameters.Add(New SqlParameter("@FECHA", SqlDbType.Date)).Value = DBNull.Value
        actualizarconexion.Open()
        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable

        adaptador.Fill(dt)
        actualizarconexion.Close()
        Return dt
    End Function

    Public Function reporte_nc_por_descuento_serie(ByVal ALMACEN As Integer,ByVal TIPO As String, ByVal EMPRESA As String)
        Dim actualizarconexion As New SqlConnection(conexion_consumo.CadenaSQL)
        Dim micomando As New SqlCommand("rptn_nc_por_descuento", actualizarconexion)
        micomando.CommandType = CommandType.StoredProcedure
        micomando.Parameters.Add(New SqlParameter("@INI", SqlDbType.VarChar)).Value = DBNull.Value
        micomando.Parameters.Add(New SqlParameter("@FIN", SqlDbType.VarChar)).Value = DBNull.Value
        micomando.Parameters.Add(New SqlParameter("@ALMACEN", SqlDbType.Int)).Value = ALMACEN
        micomando.Parameters.Add(New SqlParameter("@TIPO", SqlDbType.VarChar)).Value = TIPO
        micomando.Parameters.Add(New SqlParameter("@EMPRESA", SqlDbType.VarChar)).Value = EMPRESA
        micomando.Parameters.Add(New SqlParameter("@FECHA", SqlDbType.Date)).Value = DBNull.Value
        actualizarconexion.Open()
        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable

        adaptador.Fill(dt)
        actualizarconexion.Close()
        Return dt
    End Function

    Public Function reporte_nc_por_descuento_serie_dimosa(ByVal ALMACEN As Integer, ByVal TIPO As String, ByVal EMPRESA As String)
        Dim actualizarconexion As New SqlConnection(conexion_consumo_dimosa.CadenaSQL)
        Dim micomando As New SqlCommand("rptn_nc_por_descuento", actualizarconexion)
        micomando.CommandType = CommandType.StoredProcedure
        micomando.Parameters.Add(New SqlParameter("@INI", SqlDbType.VarChar)).Value = DBNull.Value
        micomando.Parameters.Add(New SqlParameter("@FIN", SqlDbType.VarChar)).Value = DBNull.Value
        micomando.Parameters.Add(New SqlParameter("@ALMACEN", SqlDbType.Int)).Value = ALMACEN
        micomando.Parameters.Add(New SqlParameter("@TIPO", SqlDbType.VarChar)).Value = TIPO
        micomando.Parameters.Add(New SqlParameter("@EMPRESA", SqlDbType.VarChar)).Value = EMPRESA
        micomando.Parameters.Add(New SqlParameter("@FECHA", SqlDbType.Date)).Value = DBNull.Value
        actualizarconexion.Open()
        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable

        adaptador.Fill(dt)
        actualizarconexion.Close()
        Return dt
    End Function

    Public Function reporte_devoluciones_serie(ByVal ALMACEN As Integer, ByVal TIPO As String, ByVal EMPRESA As String)
        Dim actualizarconexion As New SqlConnection(conexion_consumo.CadenaSQL)
        Dim micomando As New SqlCommand("rptn_devoluciones_contabilidad", actualizarconexion)
        micomando.CommandType = CommandType.StoredProcedure
        micomando.Parameters.Add(New SqlParameter("@INI", SqlDbType.VarChar)).Value = DBNull.Value
        micomando.Parameters.Add(New SqlParameter("@FIN", SqlDbType.VarChar)).Value = DBNull.Value
        micomando.Parameters.Add(New SqlParameter("@ALMACEN", SqlDbType.Int)).Value = ALMACEN
        micomando.Parameters.Add(New SqlParameter("@TIPO", SqlDbType.VarChar)).Value = TIPO
        micomando.Parameters.Add(New SqlParameter("@EMPRESA", SqlDbType.VarChar)).Value = EMPRESA
        micomando.Parameters.Add(New SqlParameter("@FECHA", SqlDbType.Date)).Value = DBNull.Value
        actualizarconexion.Open()
        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable

        adaptador.Fill(dt)
        actualizarconexion.Close()
        Return dt
    End Function

    Public Function reporte_devoluciones_serie_dimosa(ByVal ALMACEN As Integer, ByVal TIPO As String, ByVal EMPRESA As String)
        Dim actualizarconexion As New SqlConnection(conexion_consumo_dimosa.CadenaSQL)
        Dim micomando As New SqlCommand("rptn_devoluciones_contabilidad", actualizarconexion)
        micomando.CommandType = CommandType.StoredProcedure
        micomando.Parameters.Add(New SqlParameter("@INI", SqlDbType.VarChar)).Value = DBNull.Value
        micomando.Parameters.Add(New SqlParameter("@FIN", SqlDbType.VarChar)).Value = DBNull.Value
        micomando.Parameters.Add(New SqlParameter("@ALMACEN", SqlDbType.Int)).Value = ALMACEN
        micomando.Parameters.Add(New SqlParameter("@TIPO", SqlDbType.VarChar)).Value = TIPO
        micomando.Parameters.Add(New SqlParameter("@EMPRESA", SqlDbType.VarChar)).Value = EMPRESA
        micomando.Parameters.Add(New SqlParameter("@FECHA", SqlDbType.Date)).Value = DBNull.Value
        actualizarconexion.Open()
        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable

        adaptador.Fill(dt)
        actualizarconexion.Close()
        Return dt
    End Function

    Public Function lista_tasa_cambiaria_Disar()
        Dim query As New StringBuilder()
        Dim ActualizarConexion As New SqlConnection(conexion.CadenaSQL())
        query.Append("SELECT Id, Descripcion, Tasa, Pertenece, Modificacion ")
        query.Append("FROM nd_tasa_cambio")
        Dim micomando As New SqlCommand(query.ToString, ActualizarConexion)
        ActualizarConexion.Open()
        Dim AdaptadordeDatos As New SqlDataAdapter(micomando)
        Dim dt As New DataTable
        AdaptadordeDatos.Fill(dt)
        ActualizarConexion.Close()
        Return dt
    End Function

    Public Function lista_tasa_cambiaria_Disar_dimosa()
        Dim query As New StringBuilder()
        Dim ActualizarConexion As New SqlConnection(conexion_dimosa.CadenaSQL())
        query.Append("SELECT Id, Descripcion, Tasa, Pertenece, Modificacion ")
        query.Append("FROM nd_tasa_cambio")
        Dim micomando As New SqlCommand(query.ToString, ActualizarConexion)
        ActualizarConexion.Open()
        Dim AdaptadordeDatos As New SqlDataAdapter(micomando)
        Dim dt As New DataTable
        AdaptadordeDatos.Fill(dt)
        ActualizarConexion.Close()
        Return dt
    End Function

    Public Function lista_tasa_cambiaria_sragro()
        Dim query As New StringBuilder()
        Dim ActualizarConexion As New SqlConnection(conexion_sr_agro.CadenaSQL())
        query.Append("SELECT Id, Descripcion, Tasa, Pertenece, Modificacion ")
        query.Append("FROM nd_tasa_cambio")
        Dim micomando As New SqlCommand(query.ToString, ActualizarConexion)
        ActualizarConexion.Open()
        Dim AdaptadordeDatos As New SqlDataAdapter(micomando)
        Dim dt As New DataTable
        AdaptadordeDatos.Fill(dt)
        ActualizarConexion.Close()
        Return dt
    End Function

    Public Function actualizar_tasa_disar(ByVal tasa As Double, ByVal modificacion As Date, ByVal id As Integer)
        Dim ActualizarConexion As New SqlConnection(conexion.CadenaSQL())
        ActualizarConexion.Open()
        Try
            Dim query_presupuestos As New StringBuilder
            query_presupuestos.Append("UPDATE [tactical_discount_SanRafael].[dbo].[nd_tasa_cambio] ")
            query_presupuestos.Append("SET [Tasa] = @Tasa ,[Modificacion] = @Modificacion ")
            query_presupuestos.Append("WHERE [Id] = @Id ")

            Dim micomando_presupuesto As New SqlCommand(query_presupuestos.ToString, ActualizarConexion)
            micomando_presupuesto.Parameters.AddWithValue("@Tasa", tasa)
            micomando_presupuesto.Parameters.AddWithValue("@Modificacion", modificacion)
            micomando_presupuesto.Parameters.AddWithValue("@Id", id)
            micomando_presupuesto.ExecuteNonQuery()
            ActualizarConexion.Close()
            Return "correcto"
        Catch ex As Exception
            ActualizarConexion.Close()
            Return ex.Message
        End Try
    End Function

    Public Function actualizar_tasa_sr_agro(ByVal tasa As Double, ByVal modificacion As Date, ByVal id As Integer)
        Dim ActualizarConexion As New SqlConnection(conexion_sr_agro.CadenaSQL())
        ActualizarConexion.Open()
        Try
            Dim query_presupuestos As New StringBuilder
            query_presupuestos.Append("UPDATE [tactical_discount_sragro].[dbo].[nd_tasa_cambio] ")
            query_presupuestos.Append("SET [Tasa] = @Tasa ,[Modificacion] = @Modificacion ")
            query_presupuestos.Append("WHERE [Id] = @Id ")

            Dim micomando_presupuesto As New SqlCommand(query_presupuestos.ToString, ActualizarConexion)
            micomando_presupuesto.Parameters.AddWithValue("@Tasa", tasa)
            micomando_presupuesto.Parameters.AddWithValue("@Modificacion", modificacion)
            micomando_presupuesto.Parameters.AddWithValue("@Id", id)
            micomando_presupuesto.ExecuteNonQuery()
            ActualizarConexion.Close()
            Return "correcto"
        Catch ex As Exception
            ActualizarConexion.Close()
            Return ex.Message
        End Try
    End Function

    Public Function listar_ctlpol_sr_agro(ByVal NC As String)
        Dim actualizarconexion As New SqlConnection(conexion.CadenaSQL)
        Dim query As New StringBuilder

        query.Append("SELECT CTLPOL FROM SAE60Empre02.dbo.FACTD02 WHERE CVE_DOC = @NC COLLATE MODERN_SPANISH_CI_AS")

        Dim micomando As New SqlCommand(query.ToString, actualizarconexion)
        actualizarconexion.Open()
        micomando.Parameters.AddWithValue("@NC", NC)

        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable

        adaptador.Fill(dt)
        actualizarconexion.Close()
        If dt.Rows.Count > 0 Then
            Return dt.Rows(0)(0)
        Else
            Return "0"
        End If
    End Function

    Public Function Listardoctos_pol_sr_agro(ByVal CTLPOL As Integer)
        Dim actualizarconexion As New SqlConnection(conexion.CadenaSQL)
        Dim query As New StringBuilder

        query.Append("SELECT CVE_DOC AS 'NOTA DE CREDITO',FECHA_DOC AS FECHA,DOC_ANT AS FACTURA FROM SAE60Empre02.dbo.FACTD02 WHERE CTLPOL = @CTLPOL ")

        Dim micomando As New SqlCommand(query.ToString, actualizarconexion)
        actualizarconexion.Open()
        micomando.Parameters.AddWithValue("@CTLPOL", CTLPOL)

        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable

        adaptador.Fill(dt)
        actualizarconexion.Close()
        Return dt
    End Function

    Public Function listar_ctlpol_concepto31_sr_agro(ByVal NC As String)
        Dim actualizarconexion As New SqlConnection(conexion.CadenaSQL)
        Dim query As New StringBuilder

        query.Append("SELECT ISNULL(CTLPOL,0) FROM SAE60Empre02.dbo.CUEN_DET02 WHERE (DOCTO = @NC COLLATE MODERN_SPANISH_CI_AS) AND NUM_CPTO = 31")

        Dim micomando As New SqlCommand(query.ToString, actualizarconexion)
        actualizarconexion.Open()
        micomando.Parameters.AddWithValue("@NC", NC)

        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable

        adaptador.Fill(dt)
        actualizarconexion.Close()
        If dt.Rows.Count > 0 Then
            Return dt.Rows(0)(0)
        Else
            Return "0"
        End If
    End Function

    Public Function seleccionar_poliza_coi_sr_agro(ByVal num_poliz As String, ByVal nyear As Integer, ByVal nmes As Integer, ByVal tipo_poliza As String)
        Dim actualizarconexion As New SqlConnection(conexion_coi_san_rafael.CadenaSQL)
        Dim year_short As Integer
        year_short = Convert.ToInt32((nyear.ToString()).Substring(2, 2))
        Dim qx_auxiliares = New StringBuilder()
        qx_auxiliares.Append("SELECT TIPO_POLI AS TIPO, NUM_POLIZ AS NO, NUM_PART AS ID, NUM_CTA AS CTA, FECHA_POL AS FECHA, ")
        qx_auxiliares.Append("CONCEP_PO AS CONCEPTO, DEBE_HABER AS SIGNO, MONTOMOV AS MONTO ")
        qx_auxiliares.Append("FROM [COI70Empre06].[dbo].[AUXILIAR" + year_short.ToString() + "06] ")
        qx_auxiliares.Append("WHERE	(TIPO_POLI = @TIPO_POLI) AND (LTRIM(NUM_POLIZ) = LTRIM(@NUM_POLIZ)) ")
        qx_auxiliares.Append("AND (PERIODO = @PERIODO) AND (EJERCICIO = @EJERCICIO) ")

        Dim cmd_ins_auxiliares = New SqlCommand(qx_auxiliares.ToString(), actualizarconexion)

        cmd_ins_auxiliares.Parameters.AddWithValue("@TIPO_POLI", tipo_poliza)
        cmd_ins_auxiliares.Parameters.AddWithValue("@NUM_POLIZ", num_poliz)
        cmd_ins_auxiliares.Parameters.AddWithValue("@EJERCICIO", nyear)
        cmd_ins_auxiliares.Parameters.AddWithValue("@PERIODO", nmes)
        Dim adaptador = New SqlDataAdapter(cmd_ins_auxiliares)
        Dim tabla As New DataTable
        adaptador.Fill(tabla)
        Return tabla
    End Function

    Public Function eliminar_nc_sae_sr_agro(ByVal CVE_DOC As String, ByVal CLIENTE As String, ByVal MONTO As Double, ByVal CODIGO_LOCAL As String, _
                                    ByVal TIPO As String, ByVal DOCUMENTO2 As String, ByVal ctlpol As String, ByVal num_poliz As String, _
                                    ByVal nyear As Integer, ByVal nmes As Integer, ByVal tipo_poliza As String, ByVal tabla As DataTable, _
                                    ByVal tiene_interface As String, ByVal contabilizado As String, ByVal FACTURA As String, ByVal USUARIO As String, _
                                    ByVal tiene_interface_c31 As String, ByVal ctlpol_C31 As String, ByVal nyear_C31 As Integer, _
                                    ByVal nmes_C31 As Integer, ByVal contabilizado_C31 As String, ByVal tipo_poliza_C31 As String, _
                                    ByVal tabla_C31 As DataTable, ByVal num_poliz_C31 As String)
        Dim mitransacion As SqlTransaction
        Dim miconexion As New SqlConnection(conexion.CadenaSQL)

        Dim mitransaccion_coi As SqlTransaction
        Dim miconexion_coi As New SqlConnection(conexion_coi_sr_agro.CadenaSQL)

        Dim variable_error As String = ""
        miconexion.Open()
        miconexion_coi.Open()

        mitransacion = miconexion.BeginTransaction
        mitransaccion_coi = miconexion_coi.BeginTransaction

        Try
            Dim query2 As New StringBuilder
            query2.Append("UPDATE SAE60Empre02.dbo.FACTD02 SET [STATUS] = 'C' WHERE CVE_DOC = @CVE_DOC")
            Dim micomando2 As New SqlCommand(query2.ToString, miconexion)
            micomando2.Parameters.AddWithValue("@CVE_DOC", CVE_DOC)
            micomando2.Transaction = mitransacion
            micomando2.ExecuteNonQuery()

            Dim query4 As New StringBuilder
            query4.Append("DELETE FROM SAE60Empre02.dbo.CUEN_DET02 WHERE DOCTO = @DOCTO AND NUM_CPTO = 12 ")
            Dim micomando4 As New SqlCommand(query4.ToString, miconexion)
            micomando4.Parameters.AddWithValue("@DOCTO", CVE_DOC)
            micomando4.Transaction = mitransacion
            micomando4.ExecuteNonQuery()

            If TIPO.ToUpper = "CONTADO" Then
                Dim query5 As New StringBuilder
                query5.Append("DELETE FROM SAE60Empre02.dbo.CUEN_DET02 WHERE DOCTO = @DOCTO AND NUM_CPTO = 31 ")
                Dim micomando5 As New SqlCommand(query5.ToString, miconexion)
                micomando5.Parameters.AddWithValue("@DOCTO", CVE_DOC)
                micomando5.Transaction = mitransacion
                micomando5.ExecuteNonQuery()

                'Dim query510 As New StringBuilder
                'query510.Append("DELETE FROM SAE60Empre02.dbo.CUEN_DET02 WHERE DOCTO = @DOCTO AND NUM_CPTO = 31 ")
                'Dim micomando510 As New SqlCommand(query5.ToString, miconexion)
                'micomando510.Parameters.AddWithValue("@DOCTO", DOCUMENTO2)
                'micomando510.Transaction = mitransacion
                'micomando510.ExecuteNonQuery()

                'quitar concepto 31'
                If tiene_interface_c31 = "Si" Then
                    'eliminar interface en SAE
                    Dim qx_int_coi_C31 = New StringBuilder()
                    qx_int_coi_C31.Append("DELETE FROM [SAE60Empre02].[dbo].[INTCOI02] WHERE CTLPOL = @CTLPOL ")
                    Dim cmd_int_coi_C31 = New SqlCommand(qx_int_coi_C31.ToString(), miconexion)
                    cmd_int_coi_C31.Transaction = mitransacion
                    cmd_int_coi_C31.Parameters.AddWithValue("@CTLPOL", ctlpol_C31)
                    cmd_int_coi_C31.ExecuteNonQuery()

                    'desenlazar doctos de la interface
                    Dim qx_factd_C31 = New StringBuilder()
                    qx_factd_C31.Append(" UPDATE [SAE60Empre02].[dbo].[CUEN_DET02] SET CTLPOL = 0, AFEC_COI = '' WHERE CTLPOL = @CTLPOL ")
                    Dim cmd_factd_C31 = New SqlCommand(qx_factd_C31.ToString(), miconexion)
                    cmd_factd_C31.Transaction = mitransacion
                    cmd_factd_C31.Parameters.AddWithValue("@CTLPOL", ctlpol_C31)
                    cmd_factd_C31.ExecuteNonQuery()

                    If contabilizado_C31 = "Si" Then

                        Dim year_short_C31 As Integer
                        year_short_C31 = Convert.ToInt32((nyear_C31.ToString()).Substring(2, 2))

                        Dim cero_C31 As String = ""
                        If (nmes_C31.ToString().Length < 2) Then
                            cero_C31 = "0"
                        End If
                        'encabezado de la poliza
                        Dim qx_polizas_C31 = New StringBuilder()
                        qx_polizas_C31.Append("UPDATE [COI70Empre06].[dbo].[POLIZAS" + year_short_C31.ToString + "06] ")
                        qx_polizas_C31.Append("   SET [CONCEP_PO] = @CONCEP_PO ")
                        qx_polizas_C31.Append("WHERE  [TIPO_POLI] = @TIPO_POLI AND LTRIM([NUM_POLIZ]) = @NUM_POLIZ ")
                        qx_polizas_C31.Append("   AND [PERIODO] = @PERIODO AND [EJERCICIO] = @EJERCICIO AND [ORIGEN] = @ORIGEN ")
                        Dim cmd_polizas_C31 = New SqlCommand(qx_polizas_C31.ToString(), miconexion_coi)
                        cmd_polizas_C31.Transaction = mitransaccion_coi
                        cmd_polizas_C31.Parameters.AddWithValue("@CONCEP_PO", "Nula")
                        cmd_polizas_C31.Parameters.AddWithValue("@TIPO_POLI", tipo_poliza_C31)
                        cmd_polizas_C31.Parameters.AddWithValue("@NUM_POLIZ", num_poliz_C31)
                        cmd_polizas_C31.Parameters.AddWithValue("@PERIODO", nmes_C31)
                        cmd_polizas_C31.Parameters.AddWithValue("@EJERCICIO", nyear_C31)
                        cmd_polizas_C31.Parameters.AddWithValue("@ORIGEN", "CC COI")
                        cmd_polizas_C31.ExecuteNonQuery()

                        For index = 0 To tabla_C31.Rows.Count - 1
                            'seleccionar la cuenta base
                            Dim qx_catalogo_cuentas = New StringBuilder()
                            qx_catalogo_cuentas.Append("SELECT NUM_CTA, CTA_PAPA, NIVEL FROM CUENTAS" & Convert.ToString(year_short_C31) & "06 WHERE NUM_CTA = @CTA ")
                            Dim cmd_catalogo_cuentas = New SqlCommand(qx_catalogo_cuentas.ToString(), miconexion_coi)
                            cmd_catalogo_cuentas.Parameters.AddWithValue("@CTA", tabla_C31.Rows(index)(3))
                            cmd_catalogo_cuentas.Transaction = mitransaccion_coi
                            Dim adaptador_catalogo_cuentas = New SqlDataAdapter(cmd_catalogo_cuentas)
                            Dim dt_catalogo_cuentas = New DataTable()
                            adaptador_catalogo_cuentas.Fill(dt_catalogo_cuentas)

                            Dim cta_papa As String = ""
                            If dt_catalogo_cuentas.Rows.Count > 0 Then
                                cta_papa = Convert.ToString(dt_catalogo_cuentas.Rows(0)(1))

                                Dim cuentas_afectadas(Convert.ToInt32(dt_catalogo_cuentas.Rows(0)(2))) As String
                                cuentas_afectadas(0) = Convert.ToString(dt_catalogo_cuentas.Rows(0)(0))
                                cuentas_afectadas(1) = cta_papa

                                'seleccionar la raiz de las cuentas que se afectan
                                For i = 0 To Convert.ToInt32(dt_catalogo_cuentas.Rows(0)(2))
                                    Dim qx_cuenta_rel = New StringBuilder()
                                    qx_cuenta_rel.Append("SELECT NUM_CTA, CTA_PAPA, NIVEL FROM CUENTAS" & Convert.ToString(year_short_C31) & "06 WHERE NUM_CTA = '" + cta_papa + "'")
                                    Dim cmd_cuenta_rel = New SqlCommand(qx_cuenta_rel.ToString(), miconexion_coi)
                                    cmd_cuenta_rel.Transaction = mitransaccion_coi
                                    Dim adaptador_cuenta_rel = New SqlDataAdapter(cmd_cuenta_rel)
                                    Dim dt_cuenta_rel = New DataTable()
                                    adaptador_cuenta_rel.Fill(dt_cuenta_rel)
                                    Try
                                        cta_papa = Convert.ToString(dt_cuenta_rel.Rows(0)(1))
                                        cuentas_afectadas(2 + i) = cta_papa
                                    Catch ex As Exception

                                    End Try
                                Next

                                Try
                                    For i = 0 To cuentas_afectadas.Length - 1
                                        Dim qx_actualiza_saldos = New StringBuilder()
                                        qx_actualiza_saldos.Append(" UPDATE [COI70Empre06].[dbo].[SALDOS" & Convert.ToString(year_short_C31) & "06] ")

                                        If tabla_C31.Rows(index)(6) = "D" Then
                                            qx_actualiza_saldos.Append("   SET [CARGO" + cero_C31 + nmes_C31.ToString + "] = [CARGO" + cero_C31 + nmes_C31.ToString + "] - @VALOR ")
                                        ElseIf tabla_C31.Rows(index)(6) = "H" Then
                                            qx_actualiza_saldos.Append("   SET [ABONO" + cero_C31 + nmes_C31.ToString + "] = [ABONO" + cero_C31 + nmes_C31.ToString + "] - @VALOR ")
                                        End If
                                        qx_actualiza_saldos.Append(" WHERE [NUM_CTA] = @NUM_CTA AND [EJERCICIO] = @EJERCICIO ")
                                        Dim cmd_actualiza_saldos = New SqlCommand(qx_actualiza_saldos.ToString(), miconexion_coi)
                                        cmd_actualiza_saldos.Transaction = mitransaccion_coi
                                        cmd_actualiza_saldos.Parameters.AddWithValue("@NUM_CTA", cuentas_afectadas(i))
                                        cmd_actualiza_saldos.Parameters.AddWithValue("@EJERCICIO", nyear_C31)
                                        cmd_actualiza_saldos.Parameters.AddWithValue("@VALOR", Convert.ToDouble(tabla_C31.Rows(index)(7)))
                                        cmd_actualiza_saldos.ExecuteNonQuery()
                                    Next
                                Catch ex As Exception

                                End Try
                                'actualizar saldos de las cuentas
                                'fin de catalogo de cuentas a afectar
                                'fin seleccion de cuentas raiz
                            End If

                            'partidas de la poliza
                            Dim qx_auxiliares = New StringBuilder()
                            qx_auxiliares.Append("UPDATE [COI70Empre06].[dbo].[AUXILIAR" + year_short_C31.ToString + "06] ")
                            qx_auxiliares.Append("SET [MONTOMOV] = 0 ")
                            qx_auxiliares.Append("WHERE [TIPO_POLI] = @TIPO_POLI AND [NUM_POLIZ] = @NUM_POLIZ ")
                            qx_auxiliares.Append("AND [NUM_PART] = @NUM_PART AND [PERIODO] = @PERIODO ")
                            qx_auxiliares.Append("AND [EJERCICIO] = @EJERCICIO AND [NUM_CTA] = @NUM_CTA ")
                            qx_auxiliares.Append("AND [FECHA_POL] = @FECHA_POL ")

                            Dim cmd_ins_auxiliares = New SqlCommand(qx_auxiliares.ToString(), miconexion_coi)
                            cmd_ins_auxiliares.Transaction = mitransaccion_coi
                            cmd_ins_auxiliares.Parameters.AddWithValue("@TIPO_POLI", tabla_C31.Rows(index)(0))
                            cmd_ins_auxiliares.Parameters.AddWithValue("@NUM_POLIZ", tabla_C31.Rows(index)(1))
                            cmd_ins_auxiliares.Parameters.AddWithValue("@NUM_PART", tabla_C31.Rows(index)(2))
                            cmd_ins_auxiliares.Parameters.AddWithValue("@PERIODO", nmes_C31)
                            cmd_ins_auxiliares.Parameters.AddWithValue("@EJERCICIO", nyear_C31)
                            cmd_ins_auxiliares.Parameters.AddWithValue("@NUM_CTA", tabla_C31.Rows(index)(3))
                            cmd_ins_auxiliares.Parameters.AddWithValue("@FECHA_POL", tabla_C31.Rows(index)(4))
                            cmd_ins_auxiliares.ExecuteNonQuery()
                            ' fin partidas de la poliza
                        Next
                    End If
                End If
                'fin de quitar concepto 31'


            Else
                Dim query3 As New StringBuilder
                query3.Append("UPDATE SAE60Empre02.dbo.CLIE02 SET [SALDO] = SALDO + @MONTO WHERE [CLAVE] = @CLAVE")
                Dim micomando3 As New SqlCommand(query3.ToString, miconexion)
                micomando3.Parameters.AddWithValue("@CLAVE", CLIENTE)
                micomando3.Parameters.AddWithValue("@MONTO", MONTO)
                micomando3.Transaction = mitransacion
                micomando3.ExecuteNonQuery()
            End If

            Dim query6 As New StringBuilder
            query6.Append("UPDATE [tactical_discount_sragro].[dbo].[encabezados] SET [ESTADO_SAE] = @ESTADO_SAE WHERE [CODIGO] = @CODIGO AND [DOC_NC] = @DOC_NC")
            Dim micomando6 As New SqlCommand(query6.ToString, miconexion)
            micomando6.Parameters.AddWithValue("@DOC_NC", CVE_DOC)
            micomando6.Parameters.AddWithValue("@CODIGO", CODIGO_LOCAL)
            micomando6.Parameters.AddWithValue("@ESTADO_SAE", "C")
            micomando6.Transaction = mitransacion
            micomando6.ExecuteNonQuery()

            If tiene_interface = "Si" Then
                'eliminar interface en SAE
                Dim qx_int_coi = New StringBuilder()
                qx_int_coi.Append("DELETE FROM [SAE60Empre02].[dbo].[INTCOI02] WHERE CTLPOL = @CTLPOL ")
                Dim cmd_int_coi = New SqlCommand(qx_int_coi.ToString(), miconexion)
                cmd_int_coi.Transaction = mitransacion
                cmd_int_coi.Parameters.AddWithValue("@CTLPOL", ctlpol)
                cmd_int_coi.ExecuteNonQuery()

                'desenlazar doctos de la interface
                Dim qx_factd = New StringBuilder()
                qx_factd.Append(" UPDATE [SAE60Empre02].[dbo].[FACTD02] SET	CTLPOL = 0, ACT_COI = '' WHERE CTLPOL = @CTLPOL ")
                Dim cmd_factd = New SqlCommand(qx_factd.ToString(), miconexion)
                cmd_factd.Transaction = mitransacion
                cmd_factd.Parameters.AddWithValue("@CTLPOL", ctlpol)
                cmd_factd.ExecuteNonQuery()

                If contabilizado = "Si" Then

                    Dim year_short As Integer
                    year_short = Convert.ToInt32((nyear.ToString()).Substring(2, 2))

                    Dim cero As String = ""
                    If (nmes.ToString().Length < 2) Then
                        cero = "0"
                    End If
                    'encabezado de la poliza
                    Dim qx_polizas = New StringBuilder()
                    qx_polizas.Append("UPDATE [COI70Empre06].[dbo].[POLIZAS" + year_short.ToString + "06] ")
                    qx_polizas.Append("   SET [CONCEP_PO] = @CONCEP_PO ")
                    qx_polizas.Append("WHERE  [TIPO_POLI] = @TIPO_POLI AND LTRIM([NUM_POLIZ]) = @NUM_POLIZ ")
                    qx_polizas.Append("   AND [PERIODO] = @PERIODO AND [EJERCICIO] = @EJERCICIO AND [ORIGEN] = @ORIGEN ")
                    Dim cmd_polizas = New SqlCommand(qx_polizas.ToString(), miconexion_coi)
                    cmd_polizas.Transaction = mitransaccion_coi
                    cmd_polizas.Parameters.AddWithValue("@CONCEP_PO", "Nula")
                    cmd_polizas.Parameters.AddWithValue("@TIPO_POLI", tipo_poliza)
                    cmd_polizas.Parameters.AddWithValue("@NUM_POLIZ", num_poliz)
                    cmd_polizas.Parameters.AddWithValue("@PERIODO", nmes)
                    cmd_polizas.Parameters.AddWithValue("@EJERCICIO", nyear)
                    cmd_polizas.Parameters.AddWithValue("@ORIGEN", "CC COI")
                    cmd_polizas.ExecuteNonQuery()

                    For index = 0 To tabla.Rows.Count - 1

                        'seleccionar la cuenta base
                        Dim qx_catalogo_cuentas = New StringBuilder()
                        qx_catalogo_cuentas.Append("SELECT NUM_CTA, CTA_PAPA, NIVEL FROM CUENTAS" & Convert.ToString(year_short) & "06 WHERE NUM_CTA = @CTA ")
                        Dim cmd_catalogo_cuentas = New SqlCommand(qx_catalogo_cuentas.ToString(), miconexion_coi)
                        cmd_catalogo_cuentas.Parameters.AddWithValue("@CTA", tabla.Rows(index)(3))
                        cmd_catalogo_cuentas.Transaction = mitransaccion_coi
                        Dim adaptador_catalogo_cuentas = New SqlDataAdapter(cmd_catalogo_cuentas)
                        Dim dt_catalogo_cuentas = New DataTable()
                        adaptador_catalogo_cuentas.Fill(dt_catalogo_cuentas)

                        Dim cta_papa As String = ""
                        If dt_catalogo_cuentas.Rows.Count > 0 Then
                            cta_papa = Convert.ToString(dt_catalogo_cuentas.Rows(0)(1))

                            Dim cuentas_afectadas(Convert.ToInt32(dt_catalogo_cuentas.Rows(0)(2))) As String
                            cuentas_afectadas(0) = Convert.ToString(dt_catalogo_cuentas.Rows(0)(0))
                            cuentas_afectadas(1) = cta_papa

                            'seleccionar la raiz de las cuentas que se afectan
                            For i = 0 To Convert.ToInt32(dt_catalogo_cuentas.Rows(0)(2))
                                Dim qx_cuenta_rel = New StringBuilder()
                                qx_cuenta_rel.Append("SELECT NUM_CTA, CTA_PAPA, NIVEL FROM CUENTAS" & Convert.ToString(year_short) & "06 WHERE NUM_CTA = '" + cta_papa + "'")
                                Dim cmd_cuenta_rel = New SqlCommand(qx_cuenta_rel.ToString(), miconexion_coi)
                                cmd_cuenta_rel.Transaction = mitransaccion_coi
                                Dim adaptador_cuenta_rel = New SqlDataAdapter(cmd_cuenta_rel)
                                Dim dt_cuenta_rel = New DataTable()
                                adaptador_cuenta_rel.Fill(dt_cuenta_rel)
                                Try
                                    cta_papa = Convert.ToString(dt_cuenta_rel.Rows(0)(1))
                                    cuentas_afectadas(2 + i) = cta_papa
                                Catch ex As Exception

                                End Try
                            Next

                            Try
                                For i = 0 To cuentas_afectadas.Length - 1
                                    Dim qx_actualiza_saldos = New StringBuilder()
                                    qx_actualiza_saldos.Append(" UPDATE [COI70Empre06].[dbo].[SALDOS" & Convert.ToString(year_short) & "06] ")

                                    If tabla.Rows(index)(6) = "D" Then
                                        qx_actualiza_saldos.Append("   SET [CARGO" + cero + nmes.ToString + "] = [CARGO" + cero + nmes.ToString + "] - @VALOR ")
                                    ElseIf tabla.Rows(index)(6) = "H" Then
                                        qx_actualiza_saldos.Append("   SET [ABONO" + cero + nmes.ToString + "] = [ABONO" + cero + nmes.ToString + "] - @VALOR ")
                                    End If
                                    qx_actualiza_saldos.Append(" WHERE [NUM_CTA] = @NUM_CTA AND [EJERCICIO] = @EJERCICIO ")
                                    Dim cmd_actualiza_saldos = New SqlCommand(qx_actualiza_saldos.ToString(), miconexion_coi)
                                    cmd_actualiza_saldos.Transaction = mitransaccion_coi
                                    cmd_actualiza_saldos.Parameters.AddWithValue("@NUM_CTA", cuentas_afectadas(i))
                                    cmd_actualiza_saldos.Parameters.AddWithValue("@EJERCICIO", nyear)
                                    cmd_actualiza_saldos.Parameters.AddWithValue("@VALOR", Convert.ToDouble(tabla.Rows(index)(7)))
                                    cmd_actualiza_saldos.ExecuteNonQuery()
                                Next
                            Catch ex As Exception

                            End Try
                            'actualizar saldos de las cuentas
                            'fin de catalogo de cuentas a afectar
                            'fin seleccion de cuentas raiz
                        End If

                        'partidas de la poliza
                        Dim qx_auxiliares = New StringBuilder()
                        qx_auxiliares.Append("UPDATE [COI70Empre06].[dbo].[AUXILIAR" + year_short.ToString + "06] ")
                        qx_auxiliares.Append("SET [MONTOMOV] = 0 ")
                        qx_auxiliares.Append("WHERE [TIPO_POLI] = @TIPO_POLI AND [NUM_POLIZ] = @NUM_POLIZ ")
                        qx_auxiliares.Append("AND [NUM_PART] = @NUM_PART AND [PERIODO] = @PERIODO ")
                        qx_auxiliares.Append("AND [EJERCICIO] = @EJERCICIO AND [NUM_CTA] = @NUM_CTA ")
                        qx_auxiliares.Append("AND [FECHA_POL] = @FECHA_POL ")

                        Dim cmd_ins_auxiliares = New SqlCommand(qx_auxiliares.ToString(), miconexion_coi)
                        cmd_ins_auxiliares.Transaction = mitransaccion_coi
                        cmd_ins_auxiliares.Parameters.AddWithValue("@TIPO_POLI", tabla.Rows(index)(0))
                        cmd_ins_auxiliares.Parameters.AddWithValue("@NUM_POLIZ", tabla.Rows(index)(1))
                        cmd_ins_auxiliares.Parameters.AddWithValue("@NUM_PART", tabla.Rows(index)(2))
                        cmd_ins_auxiliares.Parameters.AddWithValue("@PERIODO", nmes)
                        cmd_ins_auxiliares.Parameters.AddWithValue("@EJERCICIO", nyear)
                        cmd_ins_auxiliares.Parameters.AddWithValue("@NUM_CTA", tabla.Rows(index)(3))
                        cmd_ins_auxiliares.Parameters.AddWithValue("@FECHA_POL", tabla.Rows(index)(4))
                        cmd_ins_auxiliares.ExecuteNonQuery()
                        ' fin partidas de la poliza
                    Next
                End If
            End If

            Dim query As New StringBuilder
            query.Append("INSERT INTO [Usuarios].[dbo].[tb_ctrl_int] ")
            query.Append(" ([FECHA],[USUARIO],[OBSERVACION],[MODULO],[ACCION]) ")
            query.Append(" VALUES (@FECHA,@USUARIO,@OBSERVACION,@MODULO,@ACCION) ")

            Dim miComando_bita As New SqlCommand(query.ToString, miconexion)
            miComando_bita.Transaction = mitransacion
            miComando_bita.Parameters.AddWithValue("@FECHA", Now)
            miComando_bita.Parameters.AddWithValue("@USUARIO", USUARIO)
            miComando_bita.Parameters.AddWithValue("@OBSERVACION", "Cancelo Nota de Credito")
            miComando_bita.Parameters.AddWithValue("@MODULO", "Notas de Credito")
            Dim DESCRIPCION As String = ""
            DESCRIPCION = " Nº de Credito: " + CVE_DOC + " Nº Factura: " + FACTURA + " Nº Local: " + CODIGO_LOCAL + " Ctlpol: " + ctlpol + _
            " Poliza:" + tipo_poliza + num_poliz.ToString
            miComando_bita.Parameters.AddWithValue("@ACCION", DESCRIPCION)
            miComando_bita.ExecuteNonQuery()

            mitransacion.Commit()
            mitransaccion_coi.Commit()

            miconexion.Close()
            miconexion_coi.Close()

            Return "correcto"
        Catch ex As Exception
            mitransacion.Rollback()
            mitransaccion_coi.Rollback()
            miconexion.Close()
            miconexion_coi.Close()
            Return ex.Message
        End Try
    End Function

    Public Function get_estado_nc_sr_agro(ByVal CVE_DOC As String) As DataTable
        Dim query As New StringBuilder
        query.Append("SELECT STATUS, ISNULL(CTLPOL,0) FROM SAE60Empre02.dbo.FACTD02 WHERE (CVE_DOC = @CVE_DOC)")
        Dim miconexion As New SqlConnection(conexion.CadenaSQL)
        Dim micomando As New SqlCommand(query.ToString, miconexion)
        micomando.Parameters.AddWithValue("@CVE_DOC", CVE_DOC)
        miconexion.Open()
        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        miconexion.Close()
        Return dt
    End Function

    Public Function Listarctlpol_sr_agro(ByVal CTLPOL As Integer)
        Dim actualizarconexion As New SqlConnection(conexion.CadenaSQL)
        Dim query As New StringBuilder

        query.Append("SELECT TIPOPOL, NUMPOL, FECHAPOL,STATUS FROM SAE60Empre02.dbo.INTCOI02 WHERE CTLPOL = @CTLPOL")

        Dim micomando As New SqlCommand(query.ToString, actualizarconexion)
        actualizarconexion.Open()
        micomando.Parameters.AddWithValue("@CTLPOL", CTLPOL)

        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable

        adaptador.Fill(dt)
        actualizarconexion.Close()
        Return dt
    End Function


    Public Function folio_DocumentosFiscales(ByVal FOLIO As String)

        Dim miconexion As New SqlConnection(conexion_usuarios.CadenaSQL)

        Dim comando As New SqlCommand("Select Almacen FROM Documentos  WHERE (Serie = @FOLIO) AND (Empresa = 'SAN RAFAEL')", miconexion)
        miconexion.Open()
        comando.Parameters.AddWithValue("@FOLIO", FOLIO)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        miconexion.Close()
        Return dt
    End Function

    Public Function folio_DocumentosFiscalesDimosa(ByVal FOLIO As String)

        Dim miconexion As New SqlConnection(conexion_usuarios.CadenaSQL)

        Dim comando As New SqlCommand("Select Almacen FROM Documentos  WHERE (Serie = @FOLIO) AND (Empresa = 'Dimosa')", miconexion)
        miconexion.Open()
        comando.Parameters.AddWithValue("@FOLIO", FOLIO)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        miconexion.Close()
        Return dt
    End Function


    Public Function folio_DocumentosFiscalesOPL(ByVal FOLIO As String)

        Dim miconexion As New SqlConnection(conexion_usuarios.CadenaSQL)

        Dim comando As New SqlCommand("Select Almacen FROM Documentos  WHERE (Serie = @FOLIO) AND (Empresa = 'OPL')", miconexion)
        miconexion.Open()
        comando.Parameters.AddWithValue("@FOLIO", FOLIO)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        miconexion.Close()
        Return dt
    End Function


End Class