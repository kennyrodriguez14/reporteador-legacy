Imports System.Data.SqlClient

Public Class cls_reporte_carga
    Dim Conexion As New clsconexion_consumo
    Dim ConexionaGRO As New clsconexion_sr_agro
    Dim Conexion2 As New clsConexion
    Dim ConexionDimosa As New cls_conexion_DIMOSA
    Dim ConexionOPL As New cls_conexionOPL
    Dim ConexionDescuentosDimosa As New cls_conexion_descuentos_tacticos_dimosa
    Dim ConexionDescuentosOPL As New cls_descuentos_tacticos_opl
    Dim Conexion3 As New cls_conexion_descuentos_tacticos
    Dim Conexion4 As New cls_conexion_descuentos_tacticos_sragro




    Public Function getAlmacenDimosa(ByVal DESDE As String, ByVal HASTA As String, ByVal SUCURSAL As String, ByVal FECHA As DateTime, _
                               ByVal CREDITO As String, ByVal TIPO As String, ByVal ALMACEN As Integer) As DataTable
        Dim ActualizarConexion As New SqlConnection(conexionDimosa.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_reporte_carga_liquidacion-TRABAJANDO", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@DESDE", SqlDbType.Int)).Value = DESDE
        miComando.Parameters.Add(New SqlParameter("@HASTA", SqlDbType.Int)).Value = HASTA
        miComando.Parameters.Add(New SqlParameter("@SUCURSAL", SqlDbType.VarChar)).Value = SUCURSAL
        miComando.Parameters.Add(New SqlParameter("@FECHA", SqlDbType.DateTime)).Value = FECHA
        miComando.Parameters.Add(New SqlParameter("@CREDITO", SqlDbType.VarChar)).Value = CREDITO
        miComando.Parameters.Add(New SqlParameter("@TIPO", SqlDbType.VarChar)).Value = TIPO
        miComando.Parameters.Add(New SqlParameter("@ALMACEN", SqlDbType.Int)).Value = ALMACEN

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

    Public Function PermisoDumbar(ByVal Usuario As Integer, ByVal Permiso As Integer)
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT REPORTEID, USUARIOID FROM profiles_rel Where ReporteId = @ReporteID AND UsuarioId = @UsuarioID ", ActualizarConexion)
        miComando.Parameters.AddWithValue("@ReporteId", Permiso)
        miComando.Parameters.AddWithValue("@UsuarioId", Usuario)
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

    Public Function getAlmacen(ByVal DESDE As String, ByVal HASTA As String, ByVal SUCURSAL As String, ByVal FECHA As DateTime, _
                               ByVal CREDITO As String, ByVal TIPO As String, ByVal ALMACEN As Integer) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_reporte_carga_liquidacion-TRABAJANDO", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@DESDE", SqlDbType.Int)).Value = DESDE
        miComando.Parameters.Add(New SqlParameter("@HASTA", SqlDbType.Int)).Value = HASTA
        miComando.Parameters.Add(New SqlParameter("@SUCURSAL", SqlDbType.VarChar)).Value = SUCURSAL
        miComando.Parameters.Add(New SqlParameter("@FECHA", SqlDbType.DateTime)).Value = FECHA
        miComando.Parameters.Add(New SqlParameter("@CREDITO", SqlDbType.VarChar)).Value = CREDITO
        miComando.Parameters.Add(New SqlParameter("@TIPO", SqlDbType.VarChar)).Value = TIPO
        miComando.Parameters.Add(New SqlParameter("@ALMACEN", SqlDbType.Int)).Value = ALMACEN

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

    
    Public Function RC(ByVal DESDE As String, ByVal HASTA As String, ByVal SUCURSAL As String, ByVal FECHA As DateTime, _
                       ByVal CREDITO As String, ByVal TIPO As String, ByVal ALMACEN As Integer) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_reporte_carga_liquidacion-TRABAJANDO", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@DESDE", SqlDbType.VarChar)).Value = DESDE
        miComando.Parameters.Add(New SqlParameter("@HASTA", SqlDbType.VarChar)).Value = HASTA
        miComando.Parameters.Add(New SqlParameter("@SUCURSAL", SqlDbType.VarChar)).Value = SUCURSAL
        miComando.Parameters.Add(New SqlParameter("@FECHA", SqlDbType.DateTime)).Value = FECHA
        miComando.Parameters.Add(New SqlParameter("@CREDITO", SqlDbType.VarChar)).Value = CREDITO
        miComando.Parameters.Add(New SqlParameter("@TIPO", SqlDbType.VarChar)).Value = TIPO
        miComando.Parameters.Add(New SqlParameter("@ALMACEN", SqlDbType.Int)).Value = ALMACEN

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

    Public Function LOTESAGRO(ByVal PRODUCTO As String, ByVal ALMACEN As Integer) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT LOTE, FCHCADUC, CANTIDAD FROM LTPD02 WHERE (CVE_ART = @PRO) AND (STATUS = 'A') AND (CVE_ALM = 3) AND (CANTIDAD > 0) AND (FCHCADUC IS NOT NULL) ORDER BY FCHCADUC ", ActualizarConexion)

        miComando.Parameters.Add(New SqlParameter("@PRO", SqlDbType.VarChar)).Value = PRODUCTO
        miComando.Parameters.Add(New SqlParameter("@ALMACEN", SqlDbType.Int)).Value = ALMACEN

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


    Public Function RCDumbar(ByVal Entregador As String, ByVal Fecha As Date, ByVal Credito As String, ByVal TIPO As String, ByVal Fecha2 As Date) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_reporte_carga_liquidacion_Dumbar", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure

        miComando.Parameters.AddWithValue("@Entregador", Entregador)
        miComando.Parameters.AddWithValue("@Fecha", Fecha.Date)
        miComando.Parameters.AddWithValue("@Fecha2", Fecha2.Date)
        miComando.Parameters.AddWithValue("@CREDITO", Credito)
        miComando.Parameters.AddWithValue("@TIPO", TIPO)


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

    Public Function RCDumbarAgro(ByVal Entregador As String, ByVal Fecha As Date, ByVal Credito As String, ByVal TIPO As String, ByVal Fecha2 As Date) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionaGRO.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_reporte_carga_liquidacion_Dumbar", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure

        miComando.Parameters.AddWithValue("@Entregador", Entregador)
        miComando.Parameters.AddWithValue("@Fecha", Fecha.Date)
        miComando.Parameters.AddWithValue("@Fecha2", Fecha2.Date)
        miComando.Parameters.AddWithValue("@CREDITO", Credito)
        miComando.Parameters.AddWithValue("@TIPO", TIPO)


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

    Public Function RCDumbarDIMOSA(ByVal Entregador As String, ByVal Fecha As Date, ByVal Credito As String, ByVal TIPO As String, ByVal Fecha2 As Date) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionDimosa.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_reporte_carga_liquidacion_Dumbar", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure

        miComando.Parameters.AddWithValue("@Entregador", Entregador)
        miComando.Parameters.AddWithValue("@Fecha", Fecha.Date)
        miComando.Parameters.AddWithValue("@Fecha2", Fecha2.Date)
        miComando.Parameters.AddWithValue("@CREDITO", Credito)
        miComando.Parameters.AddWithValue("@TIPO", TIPO)


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

    Public Function RCDumbarOPL(ByVal Entregador As String, ByVal Fecha As Date, ByVal Credito As String, ByVal TIPO As String, ByVal Fecha2 As Date) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionOPL.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_reporte_carga_liquidacion_Dumbar", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure

        miComando.Parameters.AddWithValue("@Entregador", Entregador)
        miComando.Parameters.AddWithValue("@Fecha", Fecha.Date)
        miComando.Parameters.AddWithValue("@Fecha2", Fecha2.Date)
        miComando.Parameters.AddWithValue("@CREDITO", Credito)
        miComando.Parameters.AddWithValue("@TIPO", TIPO)


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

    Public Function RCDumbarRangos(ByVal D1 As String, ByVal D2 As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_reporte_carga_factura", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure

        miComando.Parameters.AddWithValue("@DOC1", D1)
        miComando.Parameters.AddWithValue("@DOC2", D2)


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

    Public Function RCDumbarRangosDimosa(ByVal D1 As String, ByVal D2 As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionDimosa.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_reporte_carga_factura", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure

        miComando.Parameters.AddWithValue("@DOC1", D1)
        miComando.Parameters.AddWithValue("@DOC2", D2)


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

    Public Function RCDumbarRangosOPL(ByVal D1 As String, ByVal D2 As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionOPL.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_reporte_carga_factura", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure

        miComando.Parameters.AddWithValue("@DOC1", D1)
        miComando.Parameters.AddWithValue("@DOC2", D2)


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


    Public Function RCDumbarRangosAgro(ByVal D1 As String, ByVal D2 As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionaGRO.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_reporte_carga_factura", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure

        miComando.Parameters.AddWithValue("@DOC1", D1)
        miComando.Parameters.AddWithValue("@DOC2", D2)


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

    Public Function RCDumbarFacturas(ByVal Entregador As String, ByVal Fecha As Date, ByVal Fecha2 As Date) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand(" SELECT     dbo.FACTF05.CVE_DOC AS FACTURA, dbo.FACTF05.CONDICION AS ENTREGADOR, ROUND(SUM((dbo.PAR_FACTF05.TOT_PARTIDA + dbo.PAR_FACTF05.TOTIMP4) " & _
                     " - dbo.PAR_FACTF05.TOT_PARTIDA * (dbo.PAR_FACTF05.DESC1 / 100)), 2) AS TOTAL, CASE  WHEN dbo.FACTF05.PRIMERPAGO = 0 THEN '' WHEN dbo.FACTF05.PRIMERPAGO > 0 THEN 'EFECTIVO' END AS 'METODODEPAGO' " & _
                     " FROM         dbo.FACTF05 INNER JOIN " & _
                     " dbo.PAR_FACTF05 ON dbo.FACTF05.CVE_DOC = dbo.PAR_FACTF05.CVE_DOC " & _
                     " WHERE     (dbo.FACTF05.CONDICION = @Condicion) AND (dbo.FACTF05.FECHA_DOC >= @Fecha) AND (dbo.FACTF05.FECHA_DOC <= @Fecha2) " & _
                     " GROUP BY dbo.FACTF05.CVE_DOC, dbo.FACTF05.CONDICION, dbo.FACTF05.PRIMERPAGO", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Condicion", Entregador)
        miComando.Parameters.AddWithValue("@Fecha", Fecha.Date)
        miComando.Parameters.AddWithValue("@Fecha2", Fecha2.Date)

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

    Public Function RCDumbarFacturasDimosa(ByVal Entregador As String, ByVal Fecha As Date, ByVal Fecha2 As Date) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionDimosa.CadenaSQL())

        Dim miComando As New SqlCommand(" SELECT     dbo.FACTF06.CVE_DOC AS FACTURA, dbo.FACTF06.CONDICION AS ENTREGADOR, ROUND(SUM((dbo.PAR_FACTF06.TOT_PARTIDA + dbo.PAR_FACTF06.TOTIMP4) " & _
                     " - dbo.PAR_FACTF06.TOT_PARTIDA * (dbo.PAR_FACTF06.DESC1 / 100)), 2) AS TOTAL, CASE  WHEN dbo.FACTF06.PRIMERPAGO = 0 THEN '' WHEN dbo.FACTF06.PRIMERPAGO > 0 THEN 'EFECTIVO' END AS 'METODODEPAGO' " & _
                     " FROM         dbo.FACTF06 INNER JOIN " & _
                     " dbo.PAR_FACTF06 ON dbo.FACTF06.CVE_DOC = dbo.PAR_FACTF06.CVE_DOC " & _
                     " WHERE     (dbo.FACTF06.CONDICION = @Condicion) AND (dbo.FACTF06.FECHA_DOC >= @Fecha) AND (dbo.FACTF06.FECHA_DOC <= @Fecha2) " & _
                     " GROUP BY dbo.FACTF06.CVE_DOC, dbo.FACTF06.CONDICION, dbo.FACTF06.PRIMERPAGO", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Condicion", Entregador)
        miComando.Parameters.AddWithValue("@Fecha", Fecha.Date)
        miComando.Parameters.AddWithValue("@Fecha2", Fecha2.Date)

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

    Public Function RCDumbarFacturasOPL(ByVal Entregador As String, ByVal Fecha As Date, ByVal Fecha2 As Date) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionOPL.CadenaSQL())

        Dim miComando As New SqlCommand(" SELECT     dbo.FACTF08.CVE_DOC AS FACTURA, dbo.FACTF08.CONDICION AS ENTREGADOR, ROUND(SUM((dbo.PAR_FACTF08.TOT_PARTIDA + dbo.PAR_FACTF08.TOTIMP4) " & _
                     " - dbo.PAR_FACTF08.TOT_PARTIDA * (dbo.PAR_FACTF08.DESC1 / 100)), 2) AS TOTAL, CASE  WHEN dbo.FACTF08.PRIMERPAGO = 0 THEN '' WHEN dbo.FACTF08.PRIMERPAGO > 0 THEN 'EFECTIVO' END AS 'METODODEPAGO' " & _
                     " FROM         dbo.FACTF08 INNER JOIN " & _
                     " dbo.PAR_FACTF08 ON dbo.FACTF08.CVE_DOC = dbo.PAR_FACTF08.CVE_DOC " & _
                     " WHERE     (dbo.FACTF08.CONDICION = @Condicion) AND (dbo.FACTF08.FECHA_DOC >= @Fecha) AND (dbo.FACTF08.FECHA_DOC <= @Fecha2) " & _
                     " GROUP BY dbo.FACTF08.CVE_DOC, dbo.FACTF08.CONDICION, dbo.FACTF08.PRIMERPAGO", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Condicion", Entregador)
        miComando.Parameters.AddWithValue("@Fecha", Fecha.Date)
        miComando.Parameters.AddWithValue("@Fecha2", Fecha2.Date)

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

    Public Function VerificaRangoGuardado(ByVal Inicio As String, ByVal Final As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())

        Dim miComando As New SqlCommand(" SELECT Liq_ID, Liq_Desde, Liq_Hasta FROM Liq_Rangos WHERE Liq_Desde = @Inicio and Liq_Hasta = @Fin ", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Inicio", Inicio)
        miComando.Parameters.AddWithValue("@Fin", Final)

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

    Public Function RCDumbarFacturasAgro(ByVal Entregador As String, ByVal Fecha As Date, ByVal Fecha2 As Date) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionaGRO.CadenaSQL())

        Dim miComando As New SqlCommand(" SELECT     dbo.FACTF02.CVE_DOC AS FACTURA, dbo.FACTF02.CONDICION AS ENTREGADOR, ROUND(SUM((dbo.PAR_FACTF02.TOT_PARTIDA + dbo.PAR_FACTF02.TOTIMP4) " & _
                     " - dbo.PAR_FACTF02.TOT_PARTIDA * (dbo.PAR_FACTF02.DESC1 / 100)), 2) AS TOTAL, CASE  WHEN dbo.FACTF02.PRIMERPAGO = 0 THEN '' WHEN dbo.FACTF02.PRIMERPAGO > 0 THEN 'EFECTIVO' END AS 'METODODEPAGO' " & _
                     " FROM         dbo.FACTF02 INNER JOIN " & _
                     " dbo.PAR_FACTF02 ON dbo.FACTF02.CVE_DOC = dbo.PAR_FACTF02.CVE_DOC " & _
                     " WHERE     (dbo.FACTF02.CONDICION = @Condicion) AND (dbo.FACTF02.FECHA_DOC >= @Fecha) AND (dbo.FACTF02.FECHA_DOC <= @Fecha2) " & _
                     " GROUP BY dbo.FACTF02.CVE_DOC, dbo.FACTF02.CONDICION, dbo.FACTF02.PRIMERPAGO", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Condicion", Entregador)
        miComando.Parameters.AddWithValue("@Fecha", Fecha.Date)
        miComando.Parameters.AddWithValue("@Fecha2", Fecha2.Date)

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

    Public Function RCDumbarTotales(ByVal Entregador As String, ByVal Factura1 As String, ByVal Factura2 As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("  SELECT     ROUND(SUM((dbo.PAR_FACTF05.TOT_PARTIDA + dbo.PAR_FACTF05.TOTIMP4) - dbo.PAR_FACTF05.TOT_PARTIDA * (dbo.PAR_FACTF05.DESC1 / 100)), 2) " & _
                                        "  AS TOTAL FROM         dbo.FACTF05 INNER JOIN  dbo.PAR_FACTF05 ON dbo.FACTF05.CVE_DOC = dbo.PAR_FACTF05.CVE_DOC " & _
                                        "  WHERE (dbo.FACTF05.CONDICION = @Condicion) AND (dbo.FACTF05.CVE_DOC >= @Factura1) AND (dbo.FACTF05.CVE_DOC <= @Factura2)", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Condicion", Entregador)
        miComando.Parameters.AddWithValue("@Factura1", Factura1)
        miComando.Parameters.AddWithValue("@Factura2", Factura2)

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

    Public Function RCDumbarTotalesDIMOSA(ByVal Entregador As String, ByVal Factura1 As String, ByVal Factura2 As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionDimosa.CadenaSQL())

        Dim miComando As New SqlCommand("  SELECT     ROUND(SUM((dbo.PAR_FACTF06.TOT_PARTIDA + dbo.PAR_FACTF06.TOTIMP4) - dbo.PAR_FACTF06.TOT_PARTIDA * (dbo.PAR_FACTF06.DESC1 / 100)), 2) " & _
                                        "  AS TOTAL FROM         dbo.FACTF06 INNER JOIN  dbo.PAR_FACTF06 ON dbo.FACTF06.CVE_DOC = dbo.PAR_FACTF06.CVE_DOC " & _
                                        "  WHERE (dbo.FACTF06.CONDICION = @Condicion) AND (dbo.FACTF06.CVE_DOC >= @Factura1) AND (dbo.FACTF06.CVE_DOC <= @Factura2)", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Condicion", Entregador)
        miComando.Parameters.AddWithValue("@Factura1", Factura1)
        miComando.Parameters.AddWithValue("@Factura2", Factura2)

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
    Public Function RCDumbarTotalesOPL(ByVal Entregador As String, ByVal Factura1 As String, ByVal Factura2 As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionOPL.CadenaSQL())

        Dim miComando As New SqlCommand("  SELECT     ROUND(SUM((dbo.PAR_FACTF08.TOT_PARTIDA + dbo.PAR_FACTF08.TOTIMP4) - dbo.PAR_FACTF08.TOT_PARTIDA * (dbo.PAR_FACTF08.DESC1 / 100)), 2) " & _
                                        "  AS TOTAL FROM         dbo.FACTF08 INNER JOIN  dbo.PAR_FACTF08 ON dbo.FACTF08.CVE_DOC = dbo.PAR_FACTF08.CVE_DOC " & _
                                        "  WHERE (dbo.FACTF08.CONDICION = @Condicion) AND (dbo.FACTF08.CVE_DOC >= @Factura1) AND (dbo.FACTF08.CVE_DOC <= @Factura2)", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Condicion", Entregador)
        miComando.Parameters.AddWithValue("@Factura1", Factura1)
        miComando.Parameters.AddWithValue("@Factura2", Factura2)

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

    Public Function RCDumbarTotalesAgro(ByVal Entregador As String, ByVal Factura1 As String, ByVal Factura2 As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionaGRO.CadenaSQL())

        Dim miComando As New SqlCommand("  SELECT     ROUND(SUM((dbo.PAR_FACTF02.TOT_PARTIDA + dbo.PAR_FACTF02.TOTIMP4) - dbo.PAR_FACTF02.TOT_PARTIDA * (dbo.PAR_FACTF02.DESC1 / 100)), 2) " & _
                                        "  AS TOTAL FROM         dbo.FACTF02 INNER JOIN  dbo.PAR_FACTF02 ON dbo.FACTF02.CVE_DOC = dbo.PAR_FACTF02.CVE_DOC " & _
                                        "  WHERE (dbo.FACTF02.CONDICION = @Condicion) AND (dbo.FACTF02.CVE_DOC >= @Factura1) AND (dbo.FACTF02.CVE_DOC <= @Factura2)", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Condicion", Entregador)
        miComando.Parameters.AddWithValue("@Factura1", Factura1)
        miComando.Parameters.AddWithValue("@Factura2", Factura2)

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

    Public Function RCDumbarDevoluciones(ByVal Entregador As String, ByVal Factura1 As String, ByVal Factura2 As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion3.CadenaSQL())

        Dim miComando As New SqlCommand("  SELECT     ROUND(SUM((dbo.devol_partidas.CANTIDAD * dbo.devol_partidas.PREC - (dbo.devol_partidas.CANTIDAD * dbo.devol_partidas.PREC) " & _
                      " * (dbo.devol_partidas.DESC1 / 100)) + (dbo.devol_partidas.CANTIDAD * dbo.devol_partidas.PREC - (dbo.devol_partidas.CANTIDAD * dbo.devol_partidas.PREC)  " & _
                      " * (dbo.devol_partidas.DESC1 / 100)) * dbo.devol_partidas.IMPU4 / 100), 2) AS Total " & _
                      " FROM         dbo.devol_encabezados INNER JOIN " & _
                      " dbo.devol_partidas ON dbo.devol_encabezados.CVE_INTERNA = dbo.devol_partidas.CVE_INTERNA " & _
                      "   WHERE     (dbo.devol_encabezados.N_FACTURA >= @Factura1) AND (dbo.devol_encabezados.N_FACTURA <= @Factura2) AND " & _
                      " (dbo.devol_encabezados.CVE_ENTREGADOR = @Entregador)", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Entregador", Entregador)
        miComando.Parameters.AddWithValue("@Factura1", Factura1)
        miComando.Parameters.AddWithValue("@Factura2", Factura2)

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

    Public Function RCDumbarDevolucionesDIMOSA(ByVal Entregador As String, ByVal Factura1 As String, ByVal Factura2 As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionDescuentosDimosa.CadenaSQL())

        Dim miComando As New SqlCommand("  SELECT     ROUND(SUM((dbo.devol_partidas.CANTIDAD * dbo.devol_partidas.PREC - (dbo.devol_partidas.CANTIDAD * dbo.devol_partidas.PREC) " & _
                      " * (dbo.devol_partidas.DESC1 / 100)) + (dbo.devol_partidas.CANTIDAD * dbo.devol_partidas.PREC - (dbo.devol_partidas.CANTIDAD * dbo.devol_partidas.PREC)  " & _
                      " * (dbo.devol_partidas.DESC1 / 100)) * dbo.devol_partidas.IMPU4 / 100), 2) AS Total " & _
                      " FROM         dbo.devol_encabezados INNER JOIN " & _
                      " dbo.devol_partidas ON dbo.devol_encabezados.CVE_INTERNA = dbo.devol_partidas.CVE_INTERNA " & _
                      "   WHERE     (dbo.devol_encabezados.N_FACTURA >= @Factura1) AND (dbo.devol_encabezados.N_FACTURA <= @Factura2) AND " & _
                      " (dbo.devol_encabezados.CVE_ENTREGADOR = @Entregador)", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Entregador", Entregador)
        miComando.Parameters.AddWithValue("@Factura1", Factura1)
        miComando.Parameters.AddWithValue("@Factura2", Factura2)

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

    Public Function RCDumbarDevolucionesOPL(ByVal Entregador As String, ByVal Factura1 As String, ByVal Factura2 As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionDescuentosOPL.CadenaSQL())

        Dim miComando As New SqlCommand("  SELECT     ROUND(SUM((dbo.devol_partidas.CANTIDAD * dbo.devol_partidas.PREC - (dbo.devol_partidas.CANTIDAD * dbo.devol_partidas.PREC) " & _
                      " * (dbo.devol_partidas.DESC1 / 100)) + (dbo.devol_partidas.CANTIDAD * dbo.devol_partidas.PREC - (dbo.devol_partidas.CANTIDAD * dbo.devol_partidas.PREC)  " & _
                      " * (dbo.devol_partidas.DESC1 / 100)) * dbo.devol_partidas.IMPU4 / 100), 2) AS Total " & _
                      " FROM         dbo.devol_encabezados INNER JOIN " & _
                      " dbo.devol_partidas ON dbo.devol_encabezados.CVE_INTERNA = dbo.devol_partidas.CVE_INTERNA " & _
                      "   WHERE     (dbo.devol_encabezados.N_FACTURA >= @Factura1) AND (dbo.devol_encabezados.N_FACTURA <= @Factura2) AND " & _
                      " (dbo.devol_encabezados.CVE_ENTREGADOR = @Entregador)", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Entregador", Entregador)
        miComando.Parameters.AddWithValue("@Factura1", Factura1)
        miComando.Parameters.AddWithValue("@Factura2", Factura2)

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

    Public Function RCDumbarDevolucionesAgro(ByVal Entregador As String, ByVal Factura1 As String, ByVal Factura2 As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion4.CadenaSQL())

        Dim miComando As New SqlCommand("  SELECT     ROUND(SUM((dbo.devol_partidas.CANTIDAD * dbo.devol_partidas.PREC - (dbo.devol_partidas.CANTIDAD * dbo.devol_partidas.PREC) " & _
                      " * (dbo.devol_partidas.DESC1 / 100)) + (dbo.devol_partidas.CANTIDAD * dbo.devol_partidas.PREC - (dbo.devol_partidas.CANTIDAD * dbo.devol_partidas.PREC)  " & _
                      " * (dbo.devol_partidas.DESC1 / 100)) * dbo.devol_partidas.IMPU4 / 100), 2) AS Total " & _
                      " FROM         dbo.devol_encabezados INNER JOIN " & _
                      " dbo.devol_partidas ON dbo.devol_encabezados.CVE_INTERNA = dbo.devol_partidas.CVE_INTERNA " & _
                      "   WHERE     (dbo.devol_encabezados.N_FACTURA >= @Factura1) AND (dbo.devol_encabezados.N_FACTURA <= @Factura2) AND " & _
                      " (dbo.devol_encabezados.CVE_ENTREGADOR = @Entregador)", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Entregador", Entregador)
        miComando.Parameters.AddWithValue("@Factura1", Factura1)
        miComando.Parameters.AddWithValue("@Factura2", Factura2)

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

    Public Function reporte_carga_acumulado(ByVal FECHA_INI As Date, ByVal FECHA_FIN As Date, ByVal TIPO As String, ByVal ALMACEN As Integer, ByVal SUCURSAL As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_reporte_carga_acumulado", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.Date)).Value = FECHA_INI
        miComando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.Date)).Value = FECHA_FIN
        miComando.Parameters.Add(New SqlParameter("@TIPO", SqlDbType.VarChar)).Value = TIPO
        miComando.Parameters.Add(New SqlParameter("@ALMACEN", SqlDbType.Int)).Value = ALMACEN
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

    Public Function RCDumbarFacturasContado(ByVal Entregador As String, ByVal Fecha As Date, ByVal Fecha2 As Date) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand(" SELECT     dbo.FACTF05.CVE_DOC AS FACTURA, dbo.FACTF05.CONDICION AS ENTREGADOR, ROUND(SUM((dbo.PAR_FACTF05.TOT_PARTIDA + dbo.PAR_FACTF05.TOTIMP4) " & _
                     " - dbo.PAR_FACTF05.TOT_PARTIDA * (dbo.PAR_FACTF05.DESC1 / 100)), 2) AS TOTAL, CASE  WHEN dbo.FACTF05.PRIMERPAGO = 0 THEN '' WHEN dbo.FACTF05.PRIMERPAGO > 0 THEN 'EFECTIVO' END AS 'METODODEPAGO' " & _
                     " FROM         dbo.FACTF05 INNER JOIN " & _
                     " dbo.PAR_FACTF05 ON dbo.FACTF05.CVE_DOC = dbo.PAR_FACTF05.CVE_DOC " & _
                     " WHERE     (dbo.FACTF05.CONDICION = @Condicion) AND (dbo.FACTF05.FECHA_DOC >= @Fecha) AND (dbo.FACTF05.FECHA_DOC <= @Fecha2) AND dbo.FACTF05.PRIMERPAGO > 0 " & _
                     " GROUP BY dbo.FACTF05.CVE_DOC, dbo.FACTF05.CONDICION, dbo.FACTF05.PRIMERPAGO order by FACTF05.CVE_DOC", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Condicion", Entregador)
        miComando.Parameters.AddWithValue("@Fecha", Fecha.Date)
        miComando.Parameters.AddWithValue("@Fecha2", Fecha2.Date)

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

    Public Function RCDumbarFacturasContadoDIMOSA(ByVal Entregador As String, ByVal Fecha As Date, ByVal Fecha2 As Date) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionDimosa.CadenaSQL())

        Dim miComando As New SqlCommand(" SELECT     dbo.FACTF06.CVE_DOC AS FACTURA, dbo.FACTF06.CONDICION AS ENTREGADOR, ROUND(SUM((dbo.PAR_FACTF06.TOT_PARTIDA + dbo.PAR_FACTF06.TOTIMP4) " & _
                     " - dbo.PAR_FACTF06.TOT_PARTIDA * (dbo.PAR_FACTF06.DESC1 / 100)), 2) AS TOTAL, CASE  WHEN dbo.FACTF06.PRIMERPAGO = 0 THEN '' WHEN dbo.FACTF06.PRIMERPAGO > 0 THEN 'EFECTIVO' END AS 'METODODEPAGO' " & _
                     " FROM         dbo.FACTF06 INNER JOIN " & _
                     " dbo.PAR_FACTF06 ON dbo.FACTF06.CVE_DOC = dbo.PAR_FACTF06.CVE_DOC " & _
                     " WHERE     (dbo.FACTF06.CONDICION = @Condicion) AND (dbo.FACTF06.FECHA_DOC >= @Fecha) AND (dbo.FACTF06.FECHA_DOC <= @Fecha2) AND dbo.FACTF06.PRIMERPAGO > 0 " & _
                     " GROUP BY dbo.FACTF06.CVE_DOC, dbo.FACTF06.CONDICION, dbo.FACTF06.PRIMERPAGO order by FACTF06.CVE_DOC", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Condicion", Entregador)
        miComando.Parameters.AddWithValue("@Fecha", Fecha.Date)
        miComando.Parameters.AddWithValue("@Fecha2", Fecha2.Date)

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

    Public Function RCDumbarFacturasContadoOPL(ByVal Entregador As String, ByVal Fecha As Date, ByVal Fecha2 As Date) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionOPL.CadenaSQL())

        Dim miComando As New SqlCommand(" SELECT     dbo.FACTF08.CVE_DOC AS FACTURA, dbo.FACTF08.CONDICION AS ENTREGADOR, ROUND(SUM((dbo.PAR_FACTF08.TOT_PARTIDA + dbo.PAR_FACTF08.TOTIMP4) " & _
                     " - dbo.PAR_FACTF08.TOT_PARTIDA * (dbo.PAR_FACTF08.DESC1 / 100)), 2) AS TOTAL, CASE  WHEN dbo.FACTF08.PRIMERPAGO = 0 THEN '' WHEN dbo.FACTF08.PRIMERPAGO > 0 THEN 'EFECTIVO' END AS 'METODODEPAGO' " & _
                     " FROM         dbo.FACTF08 INNER JOIN " & _
                     " dbo.PAR_FACTF08 ON dbo.FACTF08.CVE_DOC = dbo.PAR_FACTF08.CVE_DOC " & _
                     " WHERE     (dbo.FACTF08.CONDICION = @Condicion) AND (dbo.FACTF08.FECHA_DOC >= @Fecha) AND (dbo.FACTF08.FECHA_DOC <= @Fecha2) AND dbo.FACTF08.PRIMERPAGO > 0 " & _
                     " GROUP BY dbo.FACTF08.CVE_DOC, dbo.FACTF08.CONDICION, dbo.FACTF08.PRIMERPAGO order by FACTF08.CVE_DOC", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Condicion", Entregador)
        miComando.Parameters.AddWithValue("@Fecha", Fecha.Date)
        miComando.Parameters.AddWithValue("@Fecha2", Fecha2.Date)

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


    Public Function RCDumbarFacturasContadoAgro(ByVal Entregador As String, ByVal Fecha As Date, ByVal Fecha2 As Date) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionaGRO.CadenaSQL())

        Dim miComando As New SqlCommand(" SELECT     dbo.FACTF02.CVE_DOC AS FACTURA, dbo.FACTF02.CONDICION AS ENTREGADOR, ROUND(SUM((dbo.PAR_FACTF02.TOT_PARTIDA + dbo.PAR_FACTF02.TOTIMP4) " & _
                     " - dbo.PAR_FACTF02.TOT_PARTIDA * (dbo.PAR_FACTF02.DESC1 / 100)), 2) AS TOTAL, CASE  WHEN dbo.FACTF02.PRIMERPAGO = 0 THEN '' WHEN dbo.FACTF02.PRIMERPAGO > 0 THEN 'EFECTIVO' END AS 'METODODEPAGO' " & _
                     " FROM         dbo.FACTF02 INNER JOIN " & _
                     " dbo.PAR_FACTF02 ON dbo.FACTF02.CVE_DOC = dbo.PAR_FACTF02.CVE_DOC " & _
                     " WHERE     (dbo.FACTF02.CONDICION = @Condicion) AND (dbo.FACTF02.FECHA_DOC >= @Fecha) AND (dbo.FACTF02.FECHA_DOC <= @Fecha2) AND dbo.FACTF02.PRIMERPAGO > 0 " & _
                     " GROUP BY dbo.FACTF02.CVE_DOC, dbo.FACTF02.CONDICION, dbo.FACTF02.PRIMERPAGO order by FACTF02.CVE_DOC", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Condicion", Entregador)
        miComando.Parameters.AddWithValue("@Fecha", Fecha.Date)
        miComando.Parameters.AddWithValue("@Fecha2", Fecha2.Date)

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

    Public Function RCDumbarFacturasCredito(ByVal Entregador As String, ByVal Fecha As Date, ByVal Fecha2 As Date) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand(" SELECT     dbo.FACTF05.CVE_DOC AS FACTURA, dbo.FACTF05.CONDICION AS ENTREGADOR, ROUND(SUM((dbo.PAR_FACTF05.TOT_PARTIDA + dbo.PAR_FACTF05.TOTIMP4) " & _
                     " - dbo.PAR_FACTF05.TOT_PARTIDA * (dbo.PAR_FACTF05.DESC1 / 100)), 2) AS TOTAL, CASE  WHEN dbo.FACTF05.PRIMERPAGO = 0 THEN '' WHEN dbo.FACTF05.PRIMERPAGO > 0 THEN 'EFECTIVO' END AS 'METODODEPAGO' " & _
                     " FROM         dbo.FACTF05 INNER JOIN " & _
                     " dbo.PAR_FACTF05 ON dbo.FACTF05.CVE_DOC = dbo.PAR_FACTF05.CVE_DOC " & _
                     " WHERE     (dbo.FACTF05.CONDICION = @Condicion) AND (dbo.FACTF05.FECHA_DOC >= @Fecha) AND (dbo.FACTF05.FECHA_DOC <= @Fecha2) AND dbo.FACTF05.PRIMERPAGO = 0 " & _
                     " GROUP BY dbo.FACTF05.CVE_DOC, dbo.FACTF05.CONDICION, dbo.FACTF05.PRIMERPAGO order by FACTF05.CVE_DOC", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Condicion", Entregador)
        miComando.Parameters.AddWithValue("@Fecha", Fecha.Date)
        miComando.Parameters.AddWithValue("@Fecha2", Fecha2.Date)

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

    Public Function RCDumbarFacturasCreditoDIMOSA(ByVal Entregador As String, ByVal Fecha As Date, ByVal Fecha2 As Date) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionDimosa.CadenaSQL())

        Dim miComando As New SqlCommand(" SELECT     dbo.FACTF06.CVE_DOC AS FACTURA, dbo.FACTF06.CONDICION AS ENTREGADOR, ROUND(SUM((dbo.PAR_FACTF06.TOT_PARTIDA + dbo.PAR_FACTF06.TOTIMP4) " & _
                     " - dbo.PAR_FACTF06.TOT_PARTIDA * (dbo.PAR_FACTF06.DESC1 / 100)), 2) AS TOTAL, CASE  WHEN dbo.FACTF06.PRIMERPAGO = 0 THEN '' WHEN dbo.FACTF06.PRIMERPAGO > 0 THEN 'EFECTIVO' END AS 'METODODEPAGO' " & _
                     " FROM         dbo.FACTF06 INNER JOIN " & _
                     " dbo.PAR_FACTF06 ON dbo.FACTF06.CVE_DOC = dbo.PAR_FACTF06.CVE_DOC " & _
                     " WHERE     (dbo.FACTF06.CONDICION = @Condicion) AND (dbo.FACTF06.FECHA_DOC >= @Fecha) AND (dbo.FACTF06.FECHA_DOC <= @Fecha2) AND dbo.FACTF06.PRIMERPAGO = 0 " & _
                     " GROUP BY dbo.FACTF06.CVE_DOC, dbo.FACTF06.CONDICION, dbo.FACTF06.PRIMERPAGO order by FACTF06.CVE_DOC", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Condicion", Entregador)
        miComando.Parameters.AddWithValue("@Fecha", Fecha.Date)
        miComando.Parameters.AddWithValue("@Fecha2", Fecha2.Date)

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

    Public Function RCDumbarFacturasCreditoAgro(ByVal Entregador As String, ByVal Fecha As Date, ByVal Fecha2 As Date) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionaGRO.CadenaSQL())

        Dim miComando As New SqlCommand(" SELECT     dbo.FACTF02.CVE_DOC AS FACTURA, dbo.FACTF02.CONDICION AS ENTREGADOR, ROUND(SUM((dbo.PAR_FACTF02.TOT_PARTIDA + dbo.PAR_FACTF02.TOTIMP4) " & _
                     " - dbo.PAR_FACTF02.TOT_PARTIDA * (dbo.PAR_FACTF02.DESC1 / 100)), 2) AS TOTAL, CASE  WHEN dbo.FACTF02.PRIMERPAGO = 0 THEN '' WHEN dbo.FACTF02.PRIMERPAGO > 0 THEN 'EFECTIVO' END AS 'METODODEPAGO' " & _
                     " FROM         dbo.FACTF02 INNER JOIN " & _
                     " dbo.PAR_FACTF02 ON dbo.FACTF02.CVE_DOC = dbo.PAR_FACTF02.CVE_DOC " & _
                     " WHERE     (dbo.FACTF02.CONDICION = @Condicion) AND (dbo.FACTF02.FECHA_DOC >= @Fecha) AND (dbo.FACTF02.FECHA_DOC <= @Fecha2) AND dbo.FACTF02.PRIMERPAGO = 0 " & _
                     " GROUP BY dbo.FACTF02.CVE_DOC, dbo.FACTF02.CONDICION, dbo.FACTF02.PRIMERPAGO order by FACTF02.CVE_DOC", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Condicion", Entregador)
        miComando.Parameters.AddWithValue("@Fecha", Fecha.Date)
        miComando.Parameters.AddWithValue("@Fecha2", Fecha2.Date)

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

    Public Function CargarDevolucionesSRF(ByVal Entregador As String, ByVal Fecha As Date, ByVal Credito As String, ByVal TIPO As String, ByVal Fecha2 As Date, ByVal FACT1 As String, ByVal FACT2 As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand
        If TIPO = "DEV_CONT" Then
            miComando = New SqlCommand("SELECT        SUM((tactical_discount_SanRafael.dbo.devol_partidas.CANTIDAD * tactical_discount_SanRafael.dbo.devol_partidas.PREC - (tactical_discount_SanRafael.dbo.devol_partidas.CANTIDAD * tactical_discount_SanRafael.dbo.devol_partidas.PREC) " & _
                          " * (tactical_discount_SanRafael.dbo.devol_partidas.DESC1 / 100)) " & _
                         " + (tactical_discount_SanRafael.dbo.devol_partidas.CANTIDAD * tactical_discount_SanRafael.dbo.devol_partidas.PREC - (tactical_discount_SanRafael.dbo.devol_partidas.CANTIDAD * tactical_discount_SanRafael.dbo.devol_partidas.PREC) " & _
                          " * (tactical_discount_SanRafael.dbo.devol_partidas.DESC1 / 100)) * tactical_discount_SanRafael.dbo.devol_partidas.IMPU4 / 100) AS Total " & _
                        " FROM            tactical_discount_SanRafael.dbo.devol_encabezados INNER JOIN " & _
                         " tactical_discount_SanRafael.dbo.devol_partidas ON tactical_discount_SanRafael.dbo.devol_encabezados.CVE_INTERNA = tactical_discount_SanRafael.dbo.devol_partidas.CVE_INTERNA INNER JOIN " & _
                        " dbo.FACTF05 ON tactical_discount_SanRafael.dbo.devol_encabezados.N_FACTURA COLLATE Latin1_General_BIN = dbo.FACTF05.CVE_DOC " & _
                         " WHERE        (tactical_discount_SanRafael.dbo.devol_encabezados.CVE_ENTREGADOR = @Entregador) AND (tactical_discount_SanRafael.dbo.devol_encabezados.FECHA_DOC >= @Fecha) AND  " & _
                        " (tactical_discount_SanRafael.dbo.devol_encabezados.FECHA_DOC <= @Fecha2) AND (dbo.FACTF05.PRIMERPAGO > 0) AND tactical_discount_SanRafael.dbo.devol_encabezados.N_FACTURA >= @FACT1 AND tactical_discount_SanRafael.dbo.devol_encabezados.N_FACTURA <= @FACT2", ActualizarConexion)
        Else
            miComando = New SqlCommand("SELECT        SUM((tactical_discount_SanRafael.dbo.devol_partidas.CANTIDAD * tactical_discount_SanRafael.dbo.devol_partidas.PREC - (tactical_discount_SanRafael.dbo.devol_partidas.CANTIDAD * tactical_discount_SanRafael.dbo.devol_partidas.PREC) " & _
                          " * (tactical_discount_SanRafael.dbo.devol_partidas.DESC1 / 100)) " & _
                         " + (tactical_discount_SanRafael.dbo.devol_partidas.CANTIDAD * tactical_discount_SanRafael.dbo.devol_partidas.PREC - (tactical_discount_SanRafael.dbo.devol_partidas.CANTIDAD * tactical_discount_SanRafael.dbo.devol_partidas.PREC) " & _
                          " * (tactical_discount_SanRafael.dbo.devol_partidas.DESC1 / 100)) * tactical_discount_SanRafael.dbo.devol_partidas.IMPU4 / 100) AS Total " & _
                        " FROM            tactical_discount_SanRafael.dbo.devol_encabezados INNER JOIN " & _
                         " tactical_discount_SanRafael.dbo.devol_partidas ON tactical_discount_SanRafael.dbo.devol_encabezados.CVE_INTERNA = tactical_discount_SanRafael.dbo.devol_partidas.CVE_INTERNA INNER JOIN " & _
                        " dbo.FACTF05 ON tactical_discount_SanRafael.dbo.devol_encabezados.N_FACTURA COLLATE Latin1_General_BIN = dbo.FACTF05.CVE_DOC " & _
                         " WHERE        (tactical_discount_SanRafael.dbo.devol_encabezados.CVE_ENTREGADOR = @Entregador) AND (tactical_discount_SanRafael.dbo.devol_encabezados.FECHA_DOC >= @Fecha) AND  " & _
                        " (tactical_discount_SanRafael.dbo.devol_encabezados.FECHA_DOC <= @Fecha2) AND (dbo.FACTF05.PRIMERPAGO = 0) AND tactical_discount_SanRafael.dbo.devol_encabezados.N_FACTURA >= @FACT1 AND tactical_discount_SanRafael.dbo.devol_encabezados.N_FACTURA <= @FACT2", ActualizarConexion)
        End If

        miComando.Parameters.AddWithValue("@Entregador", Entregador)
        miComando.Parameters.AddWithValue("@Fecha", Fecha.Date)
        miComando.Parameters.AddWithValue("@Fecha2", Fecha2.Date)
        miComando.Parameters.AddWithValue("@CREDITO", Credito)
        miComando.Parameters.AddWithValue("@TIPO", TIPO)
        miComando.Parameters.AddWithValue("@FACT1", FACT1)
        miComando.Parameters.AddWithValue("@FACT2", FACT2)


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

    Public Function CargarDevolucionesSRA(ByVal Entregador As String, ByVal Fecha As Date, ByVal Credito As String, ByVal TIPO As String, ByVal Fecha2 As Date, ByVal FACT1 As String, ByVal FACT2 As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionaGRO.CadenaSQL())

        Dim miComando As New SqlCommand
        If TIPO = "DEV_CONT" Then
            miComando = New SqlCommand("SELECT        SUM((tactical_discount_sragro.dbo.devol_partidas.CANTIDAD * tactical_discount_sragro.dbo.devol_partidas.PREC - (tactical_discount_sragro.dbo.devol_partidas.CANTIDAD * tactical_discount_sragro.dbo.devol_partidas.PREC) " & _
                          " * (tactical_discount_sragro.dbo.devol_partidas.DESC1 / 100)) " & _
                         " + (tactical_discount_sragro.dbo.devol_partidas.CANTIDAD * tactical_discount_sragro.dbo.devol_partidas.PREC - (tactical_discount_sragro.dbo.devol_partidas.CANTIDAD * tactical_discount_sragro.dbo.devol_partidas.PREC) " & _
                          " * (tactical_discount_sragro.dbo.devol_partidas.DESC1 / 100)) * tactical_discount_sragro.dbo.devol_partidas.IMPU4 / 100) AS Total " & _
                        " FROM            tactical_discount_sragro.dbo.devol_encabezados INNER JOIN " & _
                         " tactical_discount_sragro.dbo.devol_partidas ON tactical_discount_sragro.dbo.devol_encabezados.CVE_INTERNA = tactical_discount_sragro.dbo.devol_partidas.CVE_INTERNA INNER JOIN " & _
                        " dbo.FACTF02 ON tactical_discount_sragro.dbo.devol_encabezados.N_FACTURA COLLATE Latin1_General_BIN = SAE60EMPRE02.dbo.FACTF02.CVE_DOC " & _
                         " WHERE        (tactical_discount_sragro.dbo.devol_encabezados.CVE_ENTREGADOR = @Entregador) AND (tactical_discount_sragro.dbo.devol_encabezados.FECHA_DOC >= @Fecha) AND  " & _
                        " (tactical_discount_sragro.dbo.devol_encabezados.FECHA_DOC <= @Fecha2) AND (SAE60EMPRE02.dbo.FACTF02.PRIMERPAGO > 0) AND tactical_discount_sragro.dbo.devol_encabezados.N_FACTURA >= @FACT1 AND tactical_discount_sragro.dbo.devol_encabezados.N_FACTURA <= @FACT2", ActualizarConexion)
        Else
            miComando = New SqlCommand("SELECT        SUM((tactical_discount_sragro.dbo.devol_partidas.CANTIDAD * tactical_discount_sragro.dbo.devol_partidas.PREC - (tactical_discount_sragro.dbo.devol_partidas.CANTIDAD * tactical_discount_sragro.dbo.devol_partidas.PREC) " & _
                          " * (tactical_discount_sragro.dbo.devol_partidas.DESC1 / 100)) " & _
                         " + (tactical_discount_sragro.dbo.devol_partidas.CANTIDAD * tactical_discount_sragro.dbo.devol_partidas.PREC - (tactical_discount_sragro.dbo.devol_partidas.CANTIDAD * tactical_discount_sragro.dbo.devol_partidas.PREC) " & _
                          " * (tactical_discount_sragro.dbo.devol_partidas.DESC1 / 100)) * tactical_discount_sragro.dbo.devol_partidas.IMPU4 / 100) AS Total " & _
                        " FROM            tactical_discount_sragro.dbo.devol_encabezados INNER JOIN " & _
                         " tactical_discount_sragro.dbo.devol_partidas ON tactical_discount_sragro.dbo.devol_encabezados.CVE_INTERNA = tactical_discount_sragro.dbo.devol_partidas.CVE_INTERNA INNER JOIN " & _
                        " dbo.FACTF02 ON tactical_discount_sragro.dbo.devol_encabezados.N_FACTURA COLLATE Latin1_General_BIN = SAE60EMPRE02.dbo.FACTF02.CVE_DOC " & _
                         " WHERE        (tactical_discount_sragro.dbo.devol_encabezados.CVE_ENTREGADOR = @Entregador) AND (tactical_discount_sragro.dbo.devol_encabezados.FECHA_DOC >= @Fecha) AND  " & _
                        " (tactical_discount_sragro.dbo.devol_encabezados.FECHA_DOC <= @Fecha2) AND (SAE60EMPRE02.dbo.FACTF02.PRIMERPAGO = 0) AND tactical_discount_sragro.dbo.devol_encabezados.N_FACTURA >= @FACT1 AND tactical_discount_sragro.dbo.devol_encabezados.N_FACTURA <= @FACT2", ActualizarConexion)
        End If

        miComando.Parameters.AddWithValue("@Entregador", Entregador)
        miComando.Parameters.AddWithValue("@Fecha", Fecha.Date)
        miComando.Parameters.AddWithValue("@Fecha2", Fecha2.Date)
        miComando.Parameters.AddWithValue("@CREDITO", Credito)
        miComando.Parameters.AddWithValue("@TIPO", TIPO)
        miComando.Parameters.AddWithValue("@FACT1", FACT1)
        miComando.Parameters.AddWithValue("@FACT2", FACT2)


        ActualizarConexion.Open()
        Dim AdaptadorDeDatos As New SqlDataAdapter(miComando)
        Dim dt As New DataTable
        Try
            AdaptadorDeDatos.Fill(dt)
            ActualizarConexion.Close()
        Catch ex As SqlException
            MsgBox("Hay un problema con la conexión a los datos::: " & ex.Message, MsgBoxStyle.Critical)
            ActualizarConexion.Close()
        End Try
        Return dt
    End Function

    Public Function CargarDevolucionesDIM(ByVal Entregador As String, ByVal Fecha As Date, ByVal Credito As String, ByVal TIPO As String, ByVal Fecha2 As Date, ByVal FACT1 As String, ByVal FACT2 As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionDimosa.CadenaSQL())

        Dim miComando As New SqlCommand
        If TIPO = "DEV_CONT" Then
            miComando = New SqlCommand("SELECT        SUM((tactical_discount_Dimosa.dbo.devol_partidas.CANTIDAD * tactical_discount_Dimosa.dbo.devol_partidas.PREC - (tactical_discount_Dimosa.dbo.devol_partidas.CANTIDAD * tactical_discount_Dimosa.dbo.devol_partidas.PREC) " & _
                          " * (tactical_discount_Dimosa.dbo.devol_partidas.DESC1 / 100)) " & _
                         " + (tactical_discount_Dimosa.dbo.devol_partidas.CANTIDAD * tactical_discount_Dimosa.dbo.devol_partidas.PREC - (tactical_discount_Dimosa.dbo.devol_partidas.CANTIDAD * tactical_discount_Dimosa.dbo.devol_partidas.PREC) " & _
                          " * (tactical_discount_Dimosa.dbo.devol_partidas.DESC1 / 100)) * tactical_discount_Dimosa.dbo.devol_partidas.IMPU4 / 100) AS Total " & _
                        " FROM            tactical_discount_Dimosa.dbo.devol_encabezados INNER JOIN " & _
                         " tactical_discount_Dimosa.dbo.devol_partidas ON tactical_discount_Dimosa.dbo.devol_encabezados.CVE_INTERNA = tactical_discount_Dimosa.dbo.devol_partidas.CVE_INTERNA INNER JOIN " & _
                        " dbo.FACTF06 ON tactical_discount_Dimosa.dbo.devol_encabezados.N_FACTURA COLLATE Latin1_General_BIN = dbo.FACTF06.CVE_DOC " & _
                         " WHERE        (tactical_discount_Dimosa.dbo.devol_encabezados.CVE_ENTREGADOR = @Entregador) AND (tactical_discount_Dimosa.dbo.devol_encabezados.FECHA_DOC >= @Fecha) AND  " & _
                        " (tactical_discount_Dimosa.dbo.devol_encabezados.FECHA_DOC <= @Fecha2) AND (dbo.FACTF06.PRIMERPAGO > 0) AND tactical_discount_Dimosa.dbo.devol_encabezados.N_FACTURA >= @FACT1 AND tactical_discount_Dimosa.dbo.devol_encabezados.N_FACTURA <= @FACT2", ActualizarConexion)
        Else
            miComando = New SqlCommand("SELECT        SUM((tactical_discount_Dimosa.dbo.devol_partidas.CANTIDAD * tactical_discount_Dimosa.dbo.devol_partidas.PREC - (tactical_discount_Dimosa.dbo.devol_partidas.CANTIDAD * tactical_discount_Dimosa.dbo.devol_partidas.PREC) " & _
                          " * (tactical_discount_Dimosa.dbo.devol_partidas.DESC1 / 100)) " & _
                         " + (tactical_discount_Dimosa.dbo.devol_partidas.CANTIDAD * tactical_discount_Dimosa.dbo.devol_partidas.PREC - (tactical_discount_Dimosa.dbo.devol_partidas.CANTIDAD * tactical_discount_Dimosa.dbo.devol_partidas.PREC) " & _
                          " * (tactical_discount_Dimosa.dbo.devol_partidas.DESC1 / 100)) * tactical_discount_Dimosa.dbo.devol_partidas.IMPU4 / 100) AS Total " & _
                        " FROM            tactical_discount_Dimosa.dbo.devol_encabezados INNER JOIN " & _
                         " tactical_discount_Dimosa.dbo.devol_partidas ON tactical_discount_Dimosa.dbo.devol_encabezados.CVE_INTERNA = tactical_discount_Dimosa.dbo.devol_partidas.CVE_INTERNA INNER JOIN " & _
                        " dbo.FACTF06 ON tactical_discount_Dimosa.dbo.devol_encabezados.N_FACTURA COLLATE Latin1_General_BIN = dbo.FACTF06.CVE_DOC " & _
                         " WHERE        (tactical_discount_Dimosa.dbo.devol_encabezados.CVE_ENTREGADOR = @Entregador) AND (tactical_discount_Dimosa.dbo.devol_encabezados.FECHA_DOC >= @Fecha) AND  " & _
                        " (tactical_discount_Dimosa.dbo.devol_encabezados.FECHA_DOC <= @Fecha2) AND (dbo.FACTF06.PRIMERPAGO = 0) AND tactical_discount_Dimosa.dbo.devol_encabezados.N_FACTURA >= @FACT1 AND tactical_discount_Dimosa.dbo.devol_encabezados.N_FACTURA <= @FACT2", ActualizarConexion)
        End If

        miComando.Parameters.AddWithValue("@Entregador", Entregador)
        miComando.Parameters.AddWithValue("@Fecha", Fecha.Date)
        miComando.Parameters.AddWithValue("@Fecha2", Fecha2.Date)
        miComando.Parameters.AddWithValue("@CREDITO", Credito)
        miComando.Parameters.AddWithValue("@TIPO", TIPO)
        miComando.Parameters.AddWithValue("@FACT1", FACT1)
        miComando.Parameters.AddWithValue("@FACT2", FACT2)


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

    Public Function CargarDevolucionesOPL(ByVal Entregador As String, ByVal Fecha As Date, ByVal Credito As String, ByVal TIPO As String, ByVal Fecha2 As Date, ByVal FACT1 As String, ByVal FACT2 As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionOPL.CadenaSQL())

        Dim miComando As New SqlCommand
        If TIPO = "DEV_CONT" Then
            miComando = New SqlCommand("SELECT        SUM((tactical_discount_OPL.dbo.devol_partidas.CANTIDAD * tactical_discount_OPL.dbo.devol_partidas.PREC - (tactical_discount_OPL.dbo.devol_partidas.CANTIDAD * tactical_discount_OPL.dbo.devol_partidas.PREC) " &
                          " * (tactical_discount_OPL.dbo.devol_partidas.DESC1 / 100)) " &
                         " + (tactical_discount_OPL.dbo.devol_partidas.CANTIDAD * tactical_discount_OPL.dbo.devol_partidas.PREC - (tactical_discount_OPL.dbo.devol_partidas.CANTIDAD * tactical_discount_OPL.dbo.devol_partidas.PREC) " &
                          " * (tactical_discount_OPL.dbo.devol_partidas.DESC1 / 100)) * tactical_discount_OPL.dbo.devol_partidas.IMPU4 / 100) AS Total " &
                        " FROM            tactical_discount_OPL.dbo.devol_encabezados INNER JOIN " &
                         " tactical_discount_OPL.dbo.devol_partidas ON tactical_discount_OPL.dbo.devol_encabezados.CVE_INTERNA = tactical_discount_OPL.dbo.devol_partidas.CVE_INTERNA INNER JOIN " &
                        " dbo.FACTF08 ON tactical_discount_OPL.dbo.devol_encabezados.N_FACTURA COLLATE Latin1_General_BIN = dbo.FACTF08.CVE_DOC " &
                         " WHERE        (tactical_discount_OPL.dbo.devol_encabezados.CVE_ENTREGADOR = @Entregador) AND (tactical_discount_OPL.dbo.devol_encabezados.FECHA_DOC >= @Fecha) AND  " &
                        " (tactical_discount_OPL.dbo.devol_encabezados.FECHA_DOC <= @Fecha2) AND (dbo.FACTF08.PRIMERPAGO > 0) AND tactical_discount_OPL.dbo.devol_encabezados.N_FACTURA >= @FACT1 AND tactical_discount_OPL.dbo.devol_encabezados.N_FACTURA <= @FACT2", ActualizarConexion)
        Else
            miComando = New SqlCommand("SELECT        SUM((tactical_discount_OPL.dbo.devol_partidas.CANTIDAD * tactical_discount_OPL.dbo.devol_partidas.PREC - (tactical_discount_OPL.dbo.devol_partidas.CANTIDAD * tactical_discount_OPL.dbo.devol_partidas.PREC) " &
                          " * (tactical_discount_OPL.dbo.devol_partidas.DESC1 / 100)) " &
                         " + (tactical_discount_OPL.dbo.devol_partidas.CANTIDAD * tactical_discount_OPL.dbo.devol_partidas.PREC - (tactical_discount_OPL.dbo.devol_partidas.CANTIDAD * tactical_discount_OPL.dbo.devol_partidas.PREC) " &
                          " * (tactical_discount_OPL.dbo.devol_partidas.DESC1 / 100)) * tactical_discount_OPL.dbo.devol_partidas.IMPU4 / 100) AS Total " &
                        " FROM            tactical_discount_OPL.dbo.devol_encabezados INNER JOIN " &
                         " tactical_discount_OPL.dbo.devol_partidas ON tactical_discount_OPL.dbo.devol_encabezados.CVE_INTERNA = tactical_discount_OPL.dbo.devol_partidas.CVE_INTERNA INNER JOIN " &
                        " dbo.FACTF08 ON tactical_discount_OPL.dbo.devol_encabezados.N_FACTURA COLLATE Latin1_General_BIN = dbo.FACTF08.CVE_DOC " &
                         " WHERE        (tactical_discount_OPL.dbo.devol_encabezados.CVE_ENTREGADOR = @Entregador) AND (tactical_discount_OPL.dbo.devol_encabezados.FECHA_DOC >= @Fecha) AND  " &
                        " (tactical_discount_OPL.dbo.devol_encabezados.FECHA_DOC <= @Fecha2) AND (dbo.FACTF08.PRIMERPAGO = 0) AND tactical_discount_OPL.dbo.devol_encabezados.N_FACTURA >= @FACT1 AND tactical_discount_OPL.dbo.devol_encabezados.N_FACTURA <= @FACT2", ActualizarConexion)
        End If

        miComando.Parameters.AddWithValue("@Entregador", Entregador)
        miComando.Parameters.AddWithValue("@Fecha", Fecha.Date)
        miComando.Parameters.AddWithValue("@Fecha2", Fecha2.Date)
        miComando.Parameters.AddWithValue("@CREDITO", Credito)
        miComando.Parameters.AddWithValue("@TIPO", TIPO)
        miComando.Parameters.AddWithValue("@FACT1", FACT1)
        miComando.Parameters.AddWithValue("@FACT2", FACT2)


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
