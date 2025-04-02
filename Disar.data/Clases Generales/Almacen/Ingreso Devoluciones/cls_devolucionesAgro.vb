Imports System.Text
Imports System.Data.SqlClient

Public Class cls_devolucionesAgro

    Dim conexion As New cls_conexion_descuentos_tacticos_sragro
    Dim conexion_consumo As New clsconexion_sr_agro
    Dim conexion_usuario As New clsConexion

    Public Function ListarAlmacenes_para_resumen()
        Dim actualizarconexion As New SqlConnection(conexion_consumo.CadenaSQL)
        Dim query As New StringBuilder

        query.Append("SELECT -1 AS 'ID', 'TODAS' AS 'ALMACEN' UNION ALL ")
        query.Append("SELECT CVE_ALM AS 'ID', DESCR AS 'ALMACEN' ")
        query.Append("FROM SAE60Empre02.dbo.ALMACENES02 ")

        Dim micomando As New SqlCommand(query.ToString, actualizarconexion)
        actualizarconexion.Open()
        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable

        adaptador.Fill(dt)
        actualizarconexion.Close()
        Return dt
    End Function

    Public Function listar_conceptos()
        Dim actualizarconexion As New SqlConnection(conexion.CadenaSQL)
        Dim query As New StringBuilder

        query.Append("rptn_listar_conceptos")

        Dim micomando As New SqlCommand(query.ToString, actualizarconexion)
        actualizarconexion.Open()
        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable

        adaptador.Fill(dt)
        actualizarconexion.Close()
        Return dt
    End Function

    Public Function listar_facturas_devoluciones(ByVal clave As String)
        Dim miconexion As New SqlConnection(conexion.CadenaSQL)
        Dim comando As New SqlCommand("lista_facturas_devoluciones", miconexion)
        comando.CommandType = CommandType.StoredProcedure
        miconexion.Open()
        comando.Parameters.Add(New SqlParameter("@CLAVE", SqlDbType.VarChar)).Value = clave
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        miconexion.Close()
        Return dt
    End Function

    'devoluciones
    Public Function guardar_datos_local(ByVal dt_encabezado As DataTable, ByVal dt_partida As DataTable) As String
        Dim mitransacion As SqlTransaction
        Dim miconexion As New SqlConnection(conexion.CadenaSQL)
        Dim variable_error As String = ""
        miconexion.Open()
        mitransacion = miconexion.BeginTransaction
        Try
            Dim query_folios As New StringBuilder
            query_folios.Append("SELECT FOLIO + CONVERT(VARCHAR, ULT_DOC + 1) AS DOCTO, SERIE, TIPO ")
            query_folios.Append("FROM devol_folios ")
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

            If dt_encabezado.Rows(0)(1) = "CREDITO" Then
                tipo_camplib20 = "C" + dt_folios.Rows(0)(2)
            Else
                tipo_camplib20 = "E" + dt_folios.Rows(0)(2)
            End If

            Dim query2 As New StringBuilder
            query2.Append("INSERT INTO [tactical_discount_sragro].[dbo].[devol_encabezados] ")
            query2.Append("([CVE_INTERNA],[CVE_CLIE],[TIPO_PAGO],[CVE_VEND],[ALMACEN],[N_FACTURA],[FECHA_SAE] ")
            query2.Append(",[FECHA_ELABORACION],[CONCEPTO],[CVE_ENTREGADOR],[VEHICULO],[ENLAZADO],[ESTADO],[TIPO_CAMPLIB],[SERIE] ")
            query2.Append(",[FECHA_DOC],[FECHA_ENT],[FECHA_VEN],[CONDICION],[RFC],[AUTORIZA],[FOLIO],[AUTOANIO]) ")
            query2.Append("VALUES ")
            query2.Append("(@CVE_INTERNA,@CVE_CLIE,@TIPO_PAGO,@CVE_VEND,@ALMACEN,@N_FACTURA,@FECHA_SAE ")
            query2.Append(",@FECHA_ELABORACION,@CONCEPTO,@CVE_ENTREGADOR,@VEHICULO,@ENLAZADO,@ESTADO,@TIPO_CAMPLIB,@SERIE ")
            query2.Append(",@FECHA_DOC,@FECHA_ENT,@FECHA_VEN,@CONDICION,@RFC,@AUTORIZA,@FOLIO,@AUTOANIO) ")

            Dim micomando2 As New SqlCommand(query2.ToString, miconexion)
            micomando2.Parameters.AddWithValue("@CVE_INTERNA", docto)
            micomando2.Parameters.AddWithValue("@CVE_CLIE", dt_encabezado.Rows(0)(0))
            micomando2.Parameters.AddWithValue("@TIPO_PAGO", dt_encabezado.Rows(0)(1))
            micomando2.Parameters.AddWithValue("@CVE_VEND", dt_encabezado.Rows(0)(2))
            micomando2.Parameters.AddWithValue("@ALMACEN", dt_encabezado.Rows(0)(3))
            micomando2.Parameters.AddWithValue("@N_FACTURA", dt_encabezado.Rows(0)(4))
            micomando2.Parameters.AddWithValue("@FECHA_SAE", Convert.ToDateTime(dt_encabezado.Rows(0)(5)).Date)
            micomando2.Parameters.AddWithValue("@FECHA_ELABORACION", Convert.ToDateTime(dt_encabezado.Rows(0)(6)))
            micomando2.Parameters.AddWithValue("@CONCEPTO", dt_encabezado.Rows(0)(7))
            micomando2.Parameters.AddWithValue("@CVE_ENTREGADOR", dt_encabezado.Rows(0)(8))
            micomando2.Parameters.AddWithValue("@VEHICULO", dt_encabezado.Rows(0)(9))
            micomando2.Parameters.AddWithValue("@ENLAZADO", dt_encabezado.Rows(0)(10))
            micomando2.Parameters.AddWithValue("@ESTADO", "PENDIENTE")
            micomando2.Parameters.AddWithValue("@TIPO_CAMPLIB", tipo_camplib20)
            micomando2.Parameters.AddWithValue("@SERIE", serie_local)

            micomando2.Parameters.AddWithValue("@FECHA_DOC", Convert.ToDateTime(dt_encabezado.Rows(0)(5)).Date)
            micomando2.Parameters.AddWithValue("@FECHA_ENT", Convert.ToDateTime(dt_encabezado.Rows(0)(11)).Date)
            micomando2.Parameters.AddWithValue("@FECHA_VEN", Convert.ToDateTime(dt_encabezado.Rows(0)(12)).Date)
            micomando2.Parameters.AddWithValue("@CONDICION", dt_encabezado.Rows(0)(13))
            micomando2.Parameters.AddWithValue("@RFC", dt_encabezado.Rows(0)(14))
            micomando2.Parameters.AddWithValue("@AUTORIZA", dt_encabezado.Rows(0)(15))
            micomando2.Parameters.AddWithValue("@FOLIO", dt_encabezado.Rows(0)(16))
            micomando2.Parameters.AddWithValue("@AUTOANIO", dt_encabezado.Rows(0)(17))

            micomando2.Transaction = mitransacion
            micomando2.ExecuteNonQuery()

            For i As Integer = 0 To dt_partida.Rows.Count - 1
                Dim query3 As New StringBuilder
                query3.Append("INSERT INTO [tactical_discount_sragro].[dbo].[devol_partidas] ")
                query3.Append("([CVE_INTERNA],[NUM_PAR],[CVE_ART],[CANTIDAD], [PXRS], ")
                query3.Append("[PREC],[COST],[IMPU4],[DESC1], [NUM_ALM],[POLIT_APLI], ")
                query3.Append("[UNI_VENTA], [E_LTPD], [NUM_MOV], [FACT_CONV], [CON_LOTE])  ")
                query3.Append("VALUES(@CVE_INTERNA, @NUM_PAR, @CVE_ART, @CANTIDAD, @PXRS, ")
                query3.Append("@PREC,@COST,@IMPU4,@DESC1, @NUM_ALM,@POLIT_APLI, ")
                query3.Append("@UNI_VENTA, @E_LTPD, @NUM_MOV, @FACT_CONV, @CON_LOTE)  ")

                Dim micomando3 As New SqlCommand(query3.ToString, miconexion)
                micomando3.Parameters.AddWithValue("@CVE_INTERNA", docto)
                micomando3.Parameters.AddWithValue("@NUM_PAR", dt_partida.Rows(i)(0))
                micomando3.Parameters.AddWithValue("@CVE_ART", dt_partida.Rows(i)(1))
                micomando3.Parameters.AddWithValue("@CANTIDAD", Convert.ToDouble(dt_partida.Rows(i)(2)))
                micomando3.Parameters.AddWithValue("@PXRS", Convert.ToDouble(dt_partida.Rows(i)(3)))
                micomando3.Parameters.AddWithValue("@PREC", Convert.ToDouble(dt_partida.Rows(i)(4)))
                micomando3.Parameters.AddWithValue("@COST", Convert.ToDouble(dt_partida.Rows(i)(5)))
                micomando3.Parameters.AddWithValue("@IMPU4", Convert.ToDouble(dt_partida.Rows(i)(6)))
                micomando3.Parameters.AddWithValue("@DESC1", Convert.ToDouble(dt_partida.Rows(i)(7)))
                micomando3.Parameters.AddWithValue("@NUM_ALM", Convert.ToInt32(dt_partida.Rows(i)(8)))
                micomando3.Parameters.AddWithValue("@POLIT_APLI", Convert.ToString(dt_partida.Rows(i)(9)))
                micomando3.Parameters.AddWithValue("@UNI_VENTA", Convert.ToString(dt_partida.Rows(i)(10)))
                micomando3.Parameters.AddWithValue("@E_LTPD", Convert.ToInt32(dt_partida.Rows(i)(11)))
                micomando3.Parameters.AddWithValue("@NUM_MOV", dt_partida.Rows(i)(12))
                micomando3.Parameters.AddWithValue("@FACT_CONV", dt_partida.Rows(i)(13))
                micomando3.Parameters.AddWithValue("@CON_LOTE", Convert.ToString(dt_partida.Rows(i)(14)))

                micomando3.Transaction = mitransacion
                micomando3.ExecuteNonQuery()
            Next

            Dim upd_folios As New StringBuilder
            upd_folios.Append("UPDATE [devol_folios]  ")
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

            Dim tamaño As Integer = Convert.ToString(ex.StackTrace).Length
            Dim posicion As Integer = InStrRev(Convert.ToString(ex.StackTrace), "línea") - 1
            Dim inicial As Integer = tamaño - posicion
            Dim linea_error As String = Convert.ToString(ex.StackTrace).Substring(tamaño - inicial, inicial)
            variable_error = ex.Message + " --> " + linea_error
        End Try
        Return variable_error
    End Function

    Public Function productos_factura(ByVal DOCTO As String) As DataTable
        Dim query As New StringBuilder
        query.Append("SELECT PF.NUM_PAR, IV.CVE_ART AS CODIGO, IV.DESCR AS PRODUCTO, PF.CANT AS CANTIDAD, ")
        query.Append("PF.PREC,PF.COST,PF.IMPU4,DESC1,NUM_ALM,POLIT_APLI,UNI_VENTA,E_LTPD,NUM_MOV, ")
        query.Append("IV.FAC_CONV,IV.CON_LOTE ")
        query.Append("FROM dbo.PAR_FACTF02 PF INNER JOIN dbo.INVE02 IV ON PF.CVE_ART = IV.CVE_ART ")
        query.Append("INNER JOIN IMPU02 ISV ON ISV.CVE_ESQIMPU = IV.CVE_ESQIMPU ")
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

    Public Function get_fecha_limite() As Date
        Dim query As New StringBuilder
        query.Append("SELECT FCHCIERREDOCTOS ")
        query.Append("FROM SAE60EMPRE02.dbo.PARAM_FACTURA02 ")
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

    Public Function modificar_devolucion(ByVal dt_encabezado As DataTable, ByVal dt_partida As DataTable, ByVal docto As String) As String
        Dim mitransacion As SqlTransaction
        Dim miconexion As New SqlConnection(conexion.CadenaSQL)
        Dim variable_error As String = ""
        miconexion.Open()
        mitransacion = miconexion.BeginTransaction
        Try
            Dim query_delete As New StringBuilder
            query_delete.Append("DELETE FROM [tactical_discount_sragro].[dbo].[devol_partidas] ")
            query_delete.Append("WHERE CVE_INTERNA = @CVE_INTERNA ")

            Dim micomando_delete As New SqlCommand(query_delete.ToString, miconexion)
            micomando_delete.Parameters.AddWithValue("@CVE_INTERNA", docto)
            micomando_delete.Transaction = mitransacion
            micomando_delete.ExecuteNonQuery()

            For i As Integer = 0 To dt_partida.Rows.Count - 1
                Dim query3 As New StringBuilder
                query3.Append("INSERT INTO [tactical_discount_sragro].[dbo].[devol_partidas] ")
                query3.Append("([CVE_INTERNA],[NUM_PAR],[CVE_ART],[CANTIDAD]) ")
                query3.Append("VALUES(@CVE_INTERNA, @NUM_PAR, @CVE_ART, @CANTIDAD) ")

                Dim micomando3 As New SqlCommand(query3.ToString, miconexion)
                micomando3.Parameters.AddWithValue("@CVE_INTERNA", docto)
                micomando3.Parameters.AddWithValue("@NUM_PAR", dt_partida.Rows(i)(0))
                micomando3.Parameters.AddWithValue("@CVE_ART", dt_partida.Rows(i)(1))
                micomando3.Parameters.AddWithValue("@CANTIDAD", Convert.ToDouble(dt_partida.Rows(i)(2)))
                micomando3.Transaction = mitransacion
                micomando3.ExecuteNonQuery()
            Next

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

    Public Function eliminar_devolucion(ByVal docto As String) As String
        Dim mitransacion As SqlTransaction
        Dim miconexion As New SqlConnection(conexion.CadenaSQL)
        Dim variable_error As String = ""
        miconexion.Open()
        mitransacion = miconexion.BeginTransaction
        Try
            Dim query3 As New StringBuilder
            query3.Append("DELETE FROM [tactical_discount_sragro].[dbo].[devol_encabezados] ")
            query3.Append("WHERE CVE_INTERNA = @CVE_INTERNA ")

            Dim micomando3 As New SqlCommand(query3.ToString, miconexion)
            micomando3.Parameters.AddWithValue("@CVE_INTERNA", docto)
            micomando3.Transaction = mitransacion
            micomando3.ExecuteNonQuery()

            Dim query_delete As New StringBuilder
            query_delete.Append("DELETE FROM [tactical_discount_sragro].[dbo].[devol_partidas] ")
            query_delete.Append("WHERE CVE_INTERNA = @CVE_INTERNA ")

            Dim micomando_delete As New SqlCommand(query_delete.ToString, miconexion)
            micomando_delete.Parameters.AddWithValue("@CVE_INTERNA", docto)
            micomando_delete.Transaction = mitransacion
            micomando_delete.ExecuteNonQuery()

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

    Public Function lista_encabezados_devoluciones(ByVal FECHA_INI As Date, ByVal ALMACEN As Integer, ByVal TIPO As String _
                                                   , ByVal RANGO_INI As String, ByVal RANGO_FIN As String, ByVal CVE_ART As String)
        Dim actualizarconexion As New SqlConnection(conexion.CadenaSQL)
        Dim micomando As New SqlCommand("rptn_devoluciones_reporteador", actualizarconexion)
        micomando.CommandType = CommandType.StoredProcedure
        micomando.CommandTimeout = 2000
        micomando.Parameters.Add(New SqlParameter("@ALMACEN", SqlDbType.Int)).Value = ALMACEN
        micomando.Parameters.Add(New SqlParameter("@FECHA_SAE", SqlDbType.Date)).Value = FECHA_INI
        micomando.Parameters.Add(New SqlParameter("@TIPO", SqlDbType.VarChar)).Value = TIPO
        micomando.Parameters.Add(New SqlParameter("@RANGO_INI", SqlDbType.VarChar)).Value = RANGO_INI
        micomando.Parameters.Add(New SqlParameter("@RANGO_FIN", SqlDbType.VarChar)).Value = RANGO_FIN
        micomando.Parameters.Add(New SqlParameter("@CVE_ART", SqlDbType.VarChar)).Value = CVE_ART
        actualizarconexion.Open()

        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable

        adaptador.Fill(dt)
        actualizarconexion.Close()
        Return dt
    End Function

    Public Function ListarAlmacenes()
        Dim actualizarconexion As New SqlConnection(conexion_consumo.CadenaSQL)
        Dim query As New StringBuilder

        query.Append("SELECT CVE_ALM AS 'ID', DESCR AS 'ALMACEN' ")
        query.Append("FROM SAE60Empre02.dbo.ALMACENES02 UNION ALL SELECT -1 AS ID, 'TODAS' AS ALMACEN ")

        Dim micomando As New SqlCommand(query.ToString, actualizarconexion)
        actualizarconexion.Open()
        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable

        adaptador.Fill(dt)
        actualizarconexion.Close()
        Return dt
    End Function

    Public Function ListarAlmacenes2()
        Dim actualizarconexion As New SqlConnection(conexion_consumo.CadenaSQL)
        Dim query As New StringBuilder

        query.Append("SELECT CVE_ALM AS 'ID', DESCR AS 'ALMACEN' ")
        query.Append("FROM SAE60Empre02.dbo.ALMACENES02 WHERE CVE_ALM NOT IN (15) ")

        Dim micomando As New SqlCommand(query.ToString, actualizarconexion)
        actualizarconexion.Open()
        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable

        adaptador.Fill(dt)
        actualizarconexion.Close()
        Return dt
    End Function

    Public Function modificar_detalle_productos(ByVal dt_productos As DataTable, ByVal cve_art As String) As String
        Dim mitransacion As SqlTransaction
        Dim miconexion As New SqlConnection(conexion.CadenaSQL)
        Dim variable_error As String = ""
        miconexion.Open()
        mitransacion = miconexion.BeginTransaction
        Try
            For i As Integer = 0 To dt_productos.Rows.Count - 1
                Dim query_upd_partidas As New StringBuilder
                query_upd_partidas.Append("UPDATE [tactical_discount_sragro].[dbo].[devol_partidas] ")
                query_upd_partidas.Append(" SET [CANTIDAD] = @CANTIDAD ")
                query_upd_partidas.Append(" WHERE [CVE_INTERNA] = @CVE_INTERNA AND ")
                query_upd_partidas.Append(" [NUM_PAR] = @NUM_PAR AND [CVE_ART] = @CVE_ART ")

                Dim micomando_upd_partidas As New SqlCommand(query_upd_partidas.ToString, miconexion)

                micomando_upd_partidas.Parameters.AddWithValue("@CVE_INTERNA", dt_productos.Rows(i)(0))
                micomando_upd_partidas.Parameters.AddWithValue("@NUM_PAR", dt_productos.Rows(i)(3))
                micomando_upd_partidas.Parameters.AddWithValue("@CVE_ART", cve_art)
                micomando_upd_partidas.Parameters.AddWithValue("@CANTIDAD", dt_productos.Rows(i)(4))

                micomando_upd_partidas.Transaction = mitransacion
                micomando_upd_partidas.ExecuteNonQuery()
            Next

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

    Public Function validar_devos_enviadas(ByVal ALMACEN As Integer, ByVal FECHA As Date, ByVal RANGOI As String _
                                     , ByVal RANGOF As String)
        Dim actualizarconexion As New SqlConnection(conexion.CadenaSQL)
        Dim query As New StringBuilder

        query.Append("SELECT    CVE_INTERNA AS 'Codigo Interno' ")
        query.Append("FROM	    [tactical_discount_sragro].[dbo].[devol_encabezados] devol  ")
        query.Append("WHERE	    (ALMACEN = @ALMACEN) AND CONVERT(DATE,FECHA_SAE) = @FECHA ")
        query.Append("	        AND devol.ESTADO = 'ENVIADA' AND N_FACTURA >= @RANGOI  ")
        query.Append("	        AND N_FACTURA <= @RANGOF ")
        Dim micomando As New SqlCommand(query.ToString, actualizarconexion)
        micomando.Parameters.AddWithValue("@ALMACEN", ALMACEN)
        micomando.Parameters.AddWithValue("@FECHA", FECHA)
        micomando.Parameters.AddWithValue("@RANGOI", RANGOI)
        micomando.Parameters.AddWithValue("@RANGOF", RANGOF)
        actualizarconexion.Open()
        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable

        adaptador.Fill(dt)
        actualizarconexion.Close()
        Return dt
    End Function

    Public Function guardar_recepcion_SAE(ByVal dt_encabezados As DataTable, ByVal rango_ini As String, ByVal rango_fin As String, _
                                          ByVal fecha As Date, ByVal almacen As Integer, ByVal usuario As String) As String
        Dim mitransacion As SqlTransaction
        Dim miconexion As New SqlConnection(conexion.CadenaSQL)
        Dim variable_error As String = ""
        miconexion.Open()
        mitransacion = miconexion.BeginTransaction
        Dim documento_ini As String = ""
        Dim documento_fin As String = ""

        Try

            For i As Integer = 0 To dt_encabezados.Rows.Count - 1
                'cambiar de estado a las devoluciones locales
                Dim query_upd_encabezado As New StringBuilder
                query_upd_encabezado.Append("UPDATE [tactical_discount_sragro].[dbo].[devol_encabezados] ")
                query_upd_encabezado.Append("SET [ESTADO] = 'ENVIADA' ")
                query_upd_encabezado.Append("WHERE [CVE_INTERNA] = @CVE_INTERNA")
                Dim micomando_upd_encabezado As New SqlCommand(query_upd_encabezado.ToString, miconexion)
                micomando_upd_encabezado.Parameters.AddWithValue("@CVE_INTERNA", dt_encabezados.Rows(i)(0))
                micomando_upd_encabezado.Transaction = mitransacion
                micomando_upd_encabezado.ExecuteNonQuery()

                'ENVIO A SAE
                Dim _query_docto As New StringBuilder
                _query_docto.Append("SELECT SERIE,(ULT_DOC + 1)  ")
                _query_docto.Append("FROM [SAE60Empre02].[dbo].FOLIOSF02 ")
                _query_docto.Append("WHERE SERIE = @SERIE")
                Dim _cmd_docto As New SqlCommand(_query_docto.ToString, miconexion)
                _cmd_docto.Parameters.AddWithValue("@SERIE", dt_encabezados.Rows(i)(16))
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

                If i = 0 Then
                    documento_ini = documento
                End If

                ''''encabezados
                Dim _query_GETBITA As New StringBuilder
                _query_GETBITA.Append("SELECT ULT_CVE + 1   ")
                _query_GETBITA.Append("FROM [SAE60Empre02].[dbo].[TBLCONTROL02] ")
                _query_GETBITA.Append("WHERE ([ID_TABLA] = 62)")
                Dim _cmd_GETBITA As New SqlCommand(_query_GETBITA.ToString, miconexion)
                _cmd_GETBITA.Transaction = mitransacion
                Dim adaptador_BITA As New SqlDataAdapter(_cmd_GETBITA)
                Dim dt_GETBITA As New DataTable
                adaptador_BITA.Fill(dt_GETBITA)

                'cargar datos de la factura
                Dim query_datos_factura As New StringBuilder
                query_datos_factura.Append("SELECT ST, DESCUENTO, ISV, (ST - DESCUENTO + ISV) AS TOTAL,CVE_VEND, ")
                query_datos_factura.Append("VEHICULO,FECHA_DOC, FECHA_ENT, FECHA_VEN, CONDICION, almacen,  ")
                query_datos_factura.Append("RFC, AUTORIZA, serie, FOLIO, AUTOANIO FROM (	")
                query_datos_factura.Append("SELECT SUM(ST) AS ST, SUM(ST*DESC1/100) AS DESCUENTO, ")
                query_datos_factura.Append("SUM((ST-(ST*DESC1/100)) * IMPU4/100) AS ISV, CVE_VEND,CVE_ENTREGADOR, ")
                query_datos_factura.Append("FECHA_DOC,	FECHA_ENT, FECHA_VEN,CONDICION,ALMACEN,RFC,AUTORIZA, ")
                query_datos_factura.Append("serie, FOLIO, AUTOANIO,VEHICULO ")
                query_datos_factura.Append("FROM  ( SELECT (DVP.CANTIDAD*DVP.PREC) AS ST, DVP.DESC1,DVP.IMPU4, ")
                query_datos_factura.Append("CVE_VEND,CVE_ENTREGADOR,FECHA_DOC, FECHA_ENT, FECHA_VEN, CONDICION, ")
                query_datos_factura.Append("almacen, RFC, AUTORIZA, serie, FOLIO, AUTOANIO,VEHICULO ")
                query_datos_factura.Append("FROM dbo.devol_encabezados AS DVE INNER JOIN dbo.devol_partidas DVP ON ")
                query_datos_factura.Append("DVE.CVE_INTERNA = DVP.CVE_INTERNA ")
                query_datos_factura.Append("WHERE DVE.N_FACTURA = @N_FACTURA) A ")
                query_datos_factura.Append("GROUP BY CVE_VEND,CVE_ENTREGADOR,FECHA_DOC,FECHA_ENT, FECHA_VEN, ")
                query_datos_factura.Append("CONDICION,ALMACEN,RFC,AUTORIZA, SERIE, FOLIO, AUTOANIO,VEHICULO ) FINAL")

                Dim cmd_select_DATOS_FACT As New SqlCommand(query_datos_factura.ToString, miconexion)
                cmd_select_DATOS_FACT.Parameters.AddWithValue("@N_FACTURA", dt_encabezados.Rows(i)(1))
                cmd_select_DATOS_FACT.Transaction = mitransacion
                Dim adaptador_select_DATOS_FACT As New SqlDataAdapter(cmd_select_DATOS_FACT)
                Dim dt_tabla_datos_factura As New DataTable
                adaptador_select_DATOS_FACT.Fill(dt_tabla_datos_factura)

                'AGREGAR LA OBSERVACION
                Dim _query_get_MOTIVO As New StringBuilder
                _query_get_MOTIVO.Append("SELECT ULT_CVE + 1   ")
                _query_get_MOTIVO.Append("FROM [SAE60Empre02].[dbo].[TBLCONTROL02] ")
                _query_get_MOTIVO.Append("WHERE ([ID_TABLA] = 56)")
                Dim _cmd_GETMOTIVO As New SqlCommand(_query_get_MOTIVO.ToString, miconexion)
                _cmd_GETMOTIVO.Transaction = mitransacion
                Dim adaptador_MOTIVO As New SqlDataAdapter(_cmd_GETMOTIVO)
                Dim dt_GETMOTIVO As New DataTable
                adaptador_MOTIVO.Fill(dt_GETMOTIVO)

                Dim _query_INSERTMOTIVO As New StringBuilder
                _query_INSERTMOTIVO.Append("INSERT INTO [SAE60Empre02].[dbo].[OBS_DOCF02] ")
                _query_INSERTMOTIVO.Append("([CVE_OBS],[STR_OBS]) VALUES (@CVE_OBS,@STR_OBS) ")

                Dim cmd_INSERT_MOTIVO As New SqlCommand(_query_INSERTMOTIVO.ToString, miconexion)
                cmd_INSERT_MOTIVO.Parameters.AddWithValue("@CVE_OBS", dt_GETMOTIVO.Rows(0)(0))
                cmd_INSERT_MOTIVO.Parameters.AddWithValue("@STR_OBS", dt_encabezados.Rows(i)(17))
                cmd_INSERT_MOTIVO.Transaction = mitransacion
                cmd_INSERT_MOTIVO.ExecuteNonQuery()

                Dim _query_factd As New StringBuilder
                _query_factd.Append("INSERT INTO [SAE60Empre02].[dbo].[FACTD02] ")
                _query_factd.Append("([TIP_DOC],[CVE_DOC],[CVE_CLPV],[STATUS],[CVE_VEND],[CVE_PEDI],[FECHA_DOC] ")
                _query_factd.Append(",[FECHA_ENT],[FECHA_VEN],[CAN_TOT],[IMP_TOT1],[IMP_TOT2]")
                _query_factd.Append(",[IMP_TOT3],[IMP_TOT4],[DES_TOT],[DES_FIN],[COM_TOT],[CONDICION],[CVE_OBS] ")
                _query_factd.Append(",[NUM_ALMA],[ACT_CXC],[ACT_COI],[ENLAZADO],[TIP_DOC_E],[NUM_MONED],[TIPCAMB] ")
                _query_factd.Append(",[NUM_PAGOS],[FECHAELAB],[PRIMERPAGO],[RFC],[CTLPOL],[ESCFD],[AUTORIZA],[SERIE] ")
                _query_factd.Append(",[FOLIO],[AUTOANIO],[DAT_ENVIO],[CONTADO],[DAT_MOSTR],[CVE_BITA],[BLOQ],[FORMAENVIO] ")
                _query_factd.Append(",[DES_FIN_PORC],[DES_TOT_PORC],[IMPORTE],[COM_TOT_PORC],[TIP_DOC_ANT],[DOC_ANT]) ")
                _query_factd.Append("VALUES ")
                _query_factd.Append("('D',@CVE_DOC,@CVE_CLPV,'O',@CVE_VEND,@CVE_PEDI,@FECHA_DOC ")
                _query_factd.Append(",@FECHA_ENT,@FECHA_VEN,@CAN_TOT,0,0 ,0 ,@IMP_TOT4 ,@DES_TOT,0,0,@CONDICION, ")
                _query_factd.Append("@CVE_OBS,@NUM_ALMA,'S','N','O','F',1,1 ,1,@FECHAELAB,0,@RFC,0,'N',@AUTORIZA,@SERIE ")
                _query_factd.Append(",@FOLIO,@AUTOANIO,0,'N',0,@CVE_BITA,'N',0 ")
                _query_factd.Append(",0,0,@IMPORTE,0,'F',@DOC_ANT) ")

                Dim cmd_factd As New SqlCommand(_query_factd.ToString, miconexion)
                cmd_factd.Parameters.AddWithValue("@CVE_DOC", documento)
                cmd_factd.Parameters.AddWithValue("@CVE_CLPV", dt_encabezados.Rows(i)(3))
                cmd_factd.Parameters.AddWithValue("@CVE_VEND", dt_tabla_datos_factura.Rows(0)(4))
                cmd_factd.Parameters.AddWithValue("@CVE_PEDI", dt_tabla_datos_factura.Rows(0)(5))
                cmd_factd.Parameters.AddWithValue("@FECHA_DOC", dt_tabla_datos_factura.Rows(0)(6))
                cmd_factd.Parameters.AddWithValue("@FECHA_ENT", dt_tabla_datos_factura.Rows(0)(7))
                cmd_factd.Parameters.AddWithValue("@FECHA_VEN", dt_tabla_datos_factura.Rows(0)(8))
                cmd_factd.Parameters.AddWithValue("@CAN_TOT", dt_tabla_datos_factura.Rows(0)(0))
                cmd_factd.Parameters.AddWithValue("@IMP_TOT4", dt_tabla_datos_factura.Rows(0)(2))
                cmd_factd.Parameters.AddWithValue("@DES_TOT", dt_tabla_datos_factura.Rows(0)(1))
                cmd_factd.Parameters.AddWithValue("@CONDICION", dt_tabla_datos_factura.Rows(0)(9))
                cmd_factd.Parameters.AddWithValue("@CVE_OBS", dt_GETMOTIVO.Rows(0)(0))
                cmd_factd.Parameters.AddWithValue("@NUM_ALMA", dt_tabla_datos_factura.Rows(0)(10))
                cmd_factd.Parameters.AddWithValue("@FECHAELAB", Now.Date)
                cmd_factd.Parameters.AddWithValue("@RFC", dt_tabla_datos_factura.Rows(0)(11))
                cmd_factd.Parameters.AddWithValue("@AUTORIZA", dt_tabla_datos_factura.Rows(0)(12))
                cmd_factd.Parameters.AddWithValue("@SERIE", dt_tabla_datos_factura.Rows(0)(13))
                cmd_factd.Parameters.AddWithValue("@FOLIO", dt_tabla_datos_factura.Rows(0)(14))
                cmd_factd.Parameters.AddWithValue("@AUTOANIO", dt_tabla_datos_factura.Rows(0)(15))
                cmd_factd.Parameters.AddWithValue("@CVE_BITA", dt_GETBITA.Rows(0)(0))
                cmd_factd.Parameters.AddWithValue("@IMPORTE", dt_tabla_datos_factura.Rows(0)(3))
                cmd_factd.Parameters.AddWithValue("@DOC_ANT", dt_encabezados.Rows(i)(1))
                cmd_factd.Transaction = mitransacion
                cmd_factd.ExecuteNonQuery()

                Dim _query_UPD_FACTF As New StringBuilder
                _query_UPD_FACTF.Append("UPDATE [SAE60Empre02].[dbo].[FACTF02] ")
                _query_UPD_FACTF.Append("SET [ENLAZADO] = @ENLAZADO, [TIP_DOC_E] = 'D', ")
                _query_UPD_FACTF.Append("[TIP_DOC_SIG] = 'D', [DOC_SIG] = @DOC_SIG ")
                _query_UPD_FACTF.Append("WHERE [CVE_DOC] = @CVE_DOC ")
                Dim cmd_UPD_FACTF As New SqlCommand(_query_UPD_FACTF.ToString, miconexion)
                cmd_UPD_FACTF.Parameters.AddWithValue("@ENLAZADO", dt_encabezados.Rows(i)(14).ToString.Substring(0, 1))
                cmd_UPD_FACTF.Parameters.AddWithValue("@DOC_SIG", documento)
                cmd_UPD_FACTF.Parameters.AddWithValue("@CVE_DOC", dt_encabezados.Rows(i)(1))
                cmd_UPD_FACTF.Transaction = mitransacion
                cmd_UPD_FACTF.ExecuteNonQuery()

                Dim _query_ins_bita As New StringBuilder
                _query_ins_bita.Append("INSERT INTO [SAE60Empre02].[dbo].[BITA02]  ")
                _query_ins_bita.Append("(CVE_BITA,[CVE_CLIE],[CVE_CAMPANIA],[CVE_ACTIVIDAD] ")
                _query_ins_bita.Append(",[FECHAHORA],[CVE_USUARIO],[OBSERVACIONES],[STATUS],[NOM_USUARIO]) ")
                _query_ins_bita.Append("VALUES ")
                _query_ins_bita.Append("(@CVE_BITA,@CVE_CLIE,@CVE_CAMPANIA,@CVE_ACTIVIDAD,@FECHAHORA ")
                _query_ins_bita.Append(",@CVE_USUARIO,@OBSERVACIONES,@STATUS,@NOM_USUARIO) ")
                Dim _cmd_ins_bita As New SqlCommand(_query_ins_bita.ToString, miconexion)

                _cmd_ins_bita.Parameters.AddWithValue("@CVE_BITA", dt_GETBITA.Rows(0)(0))
                _cmd_ins_bita.Parameters.AddWithValue("@CVE_CLIE", dt_encabezados.Rows(i)(3))
                _cmd_ins_bita.Parameters.AddWithValue("@CVE_CAMPANIA", "_SAE_")
                _cmd_ins_bita.Parameters.AddWithValue("@CVE_ACTIVIDAD", "    6")
                _cmd_ins_bita.Parameters.AddWithValue("@FECHAHORA", DateTime.Now)
                _cmd_ins_bita.Parameters.AddWithValue("@CVE_USUARIO", 0)
                _cmd_ins_bita.Parameters.AddWithValue("@OBSERVACIONES", "No.[" & documento & "] L " & dt_tabla_datos_factura.Rows(0)(3))
                _cmd_ins_bita.Parameters.AddWithValue("@STATUS", "F")

                If usuario.Length > 15 Then
                    _cmd_ins_bita.Parameters.AddWithValue("@NOM_USUARIO", usuario.Substring(1, 15))
                Else
                    _cmd_ins_bita.Parameters.AddWithValue("@NOM_USUARIO", usuario)
                End If

                _cmd_ins_bita.Transaction = mitransacion
                _cmd_ins_bita.ExecuteNonQuery()

                Dim _query_factd_clib As New StringBuilder
                _query_factd_clib.Append("INSERT INTO [SAE60Empre02].[dbo].[FACTD_CLIB02] ")
                _query_factd_clib.Append("([CLAVE_DOC],[CAMPLIB20]) ")
                _query_factd_clib.Append("VALUES(@CLAVE_DOC, @CAMPLIB20) ")
                Dim _cmd_factd_clib As New SqlCommand(_query_factd_clib.ToString, miconexion)
                _cmd_factd_clib.Parameters.AddWithValue("@CLAVE_DOC", documento)
                _cmd_factd_clib.Parameters.AddWithValue("@CAMPLIB20", dt_encabezados.Rows(i)(15))
                _cmd_factd_clib.Transaction = mitransacion
                _cmd_factd_clib.ExecuteNonQuery()

                Dim _query_cuendet As New StringBuilder
                _query_cuendet.Append("INSERT INTO [SAE60Empre02].[dbo].[CUEN_DET02] ")
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
                _cmd_cuendet.Parameters.AddWithValue("@CVE_CLIE", dt_encabezados.Rows(i)(3))
                _cmd_cuendet.Parameters.AddWithValue("@REFER", dt_encabezados.Rows(i)(1))
                _cmd_cuendet.Parameters.AddWithValue("@NO_FACTURA", dt_encabezados.Rows(i)(1))
                _cmd_cuendet.Parameters.AddWithValue("@DOCTO", documento)
                _cmd_cuendet.Parameters.AddWithValue("@IMPORTE", dt_tabla_datos_factura.Rows(0)(3))
                _cmd_cuendet.Parameters.AddWithValue("@FECHA_APLI", dt_tabla_datos_factura.Rows(0)(6))
                _cmd_cuendet.Parameters.AddWithValue("@FECHA_VENC", dt_tabla_datos_factura.Rows(0)(8))
                _cmd_cuendet.Parameters.AddWithValue("@STRCVEVEND", dt_tabla_datos_factura.Rows(0)(4))
                _cmd_cuendet.Parameters.AddWithValue("@IMPMON_EXT", dt_tabla_datos_factura.Rows(0)(3))
                _cmd_cuendet.Parameters.AddWithValue("@FECHAELAB", Now.Date)
                _cmd_cuendet.Transaction = mitransacion
                _cmd_cuendet.ExecuteNonQuery()

                If dt_encabezados.Rows(i)(5) = "CONTADO" Then

                    Dim _query_cuendet_CARGOXDEV As New StringBuilder
                    _query_cuendet_CARGOXDEV.Append("INSERT INTO [SAE60Empre02].[dbo].[CUEN_DET02] ")
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
                    _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@CVE_CLIE", dt_encabezados.Rows(i)(3))
                    _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@REFER", dt_encabezados.Rows(i)(1))
                    _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@NO_FACTURA", dt_encabezados.Rows(i)(1))
                    _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@DOCTO", documento)
                    _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@IMPORTE", dt_tabla_datos_factura.Rows(0)(3))
                    _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@FECHA_APLI", dt_tabla_datos_factura.Rows(0)(6))
                    _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@FECHA_VENC", dt_tabla_datos_factura.Rows(0)(8))
                    _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@STRCVEVEND", dt_tabla_datos_factura.Rows(0)(4))
                    _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@IMPMON_EXT", dt_tabla_datos_factura.Rows(0)(3))
                    _cmd_cuendet_CARGOXDEV.Parameters.AddWithValue("@FECHAELAB", Now.Date)
                    _cmd_cuendet_CARGOXDEV.Transaction = mitransacion
                    _cmd_cuendet_CARGOXDEV.ExecuteNonQuery()

                    Dim _query_ins_bita_cargoxdev As New StringBuilder
                    _query_ins_bita_cargoxdev.Append("INSERT INTO [SAE60Empre02].[dbo].[BITA02]  ")
                    _query_ins_bita_cargoxdev.Append("(CVE_BITA,[CVE_CLIE],[CVE_CAMPANIA],[CVE_ACTIVIDAD] ")
                    _query_ins_bita_cargoxdev.Append(",[FECHAHORA],[CVE_USUARIO],[OBSERVACIONES],[STATUS],[NOM_USUARIO]) ")
                    _query_ins_bita_cargoxdev.Append("VALUES ")
                    _query_ins_bita_cargoxdev.Append("(@CVE_BITA,@CVE_CLIE,@CVE_CAMPANIA,@CVE_ACTIVIDAD,@FECHAHORA ")
                    _query_ins_bita_cargoxdev.Append(",@CVE_USUARIO,@OBSERVACIONES,@STATUS,@NOM_USUARIO) ")
                    Dim _cmd_ins_bita_cargoxdev As New SqlCommand(_query_ins_bita_cargoxdev.ToString, miconexion)

                    _cmd_ins_bita_cargoxdev.Parameters.AddWithValue("@CVE_BITA", dt_GETBITA.Rows(0)(0) + 1)
                    _cmd_ins_bita_cargoxdev.Parameters.AddWithValue("@CVE_CLIE", dt_encabezados.Rows(i)(3))
                    _cmd_ins_bita_cargoxdev.Parameters.AddWithValue("@CVE_CAMPANIA", "_SAE_")
                    _cmd_ins_bita_cargoxdev.Parameters.AddWithValue("@CVE_ACTIVIDAD", "   12")
                    _cmd_ins_bita_cargoxdev.Parameters.AddWithValue("@FECHAHORA", DateTime.Now)
                    _cmd_ins_bita_cargoxdev.Parameters.AddWithValue("@CVE_USUARIO", 0)
                    _cmd_ins_bita_cargoxdev.Parameters.AddWithValue("@OBSERVACIONES", "No.[] L " & dt_tabla_datos_factura.Rows(0)(3))
                    _cmd_ins_bita_cargoxdev.Parameters.AddWithValue("@STATUS", "F")
                    _cmd_ins_bita_cargoxdev.Parameters.AddWithValue("@NOM_USUARIO", "dvo-rpt")
                    _cmd_ins_bita_cargoxdev.Transaction = mitransacion
                    _cmd_ins_bita_cargoxdev.ExecuteNonQuery()

                    Dim _query_control2_cargoxdev As New StringBuilder
                    _query_control2_cargoxdev.Append("UPDATE [SAE60Empre02].[dbo].[TBLCONTROL02] ")
                    _query_control2_cargoxdev.Append(" SET [ULT_CVE] = ULT_CVE + 1 ")
                    _query_control2_cargoxdev.Append("WHERE [ID_TABLA] = 62 ")
                    Dim _cmd_control2_cargoxdev As New SqlCommand(_query_control2_cargoxdev.ToString, miconexion)
                    _cmd_control2_cargoxdev.Transaction = mitransacion
                    _cmd_control2_cargoxdev.ExecuteNonQuery()
                Else
                    Dim _query_clie As New StringBuilder
                    _query_clie.Append("UPDATE [SAE60Empre02].[dbo].[CLIE02] ")
                    _query_clie.Append("SET [SALDO] = SALDO - @VALOR ")
                    _query_clie.Append("WHERE ([CLAVE] = @CLAVE)")
                    Dim _cmd_clie As New SqlCommand(_query_clie.ToString, miconexion)
                    _cmd_clie.Parameters.AddWithValue("@VALOR", dt_tabla_datos_factura.Rows(0)(3))
                    _cmd_clie.Parameters.AddWithValue("@CLAVE", dt_encabezados.Rows(i)(3))
                    _cmd_clie.Transaction = mitransacion
                    _cmd_clie.ExecuteNonQuery()
                End If
                ' fin de encabezados

                'SELECCIONAR LAS PARTIDAS DE LA FACTURA CON BASE EN LA DEVOLUCION
                Dim query_select_partidas_devoluciones As New StringBuilder
                query_select_partidas_devoluciones.Append("SELECT	DVP.CVE_ART, DVP.CANTIDAD, DVP.PREC,DVP.COST,DVP.IMPU4, ")
                query_select_partidas_devoluciones.Append("(((DVP.CANTIDAD*DVP.PREC)- ((DVP.CANTIDAD*DVP.PREC)*DVP.DESC1/100)) ")
                query_select_partidas_devoluciones.Append("*DVP.IMPU4/100) AS TOTIMP4, DVP.DESC1, DVP.NUM_ALM, DVP.POLIT_APLI, ")
                query_select_partidas_devoluciones.Append("DVP.UNI_VENTA, DVP.E_LTPD, DVP.NUM_MOV, (DVP.CANTIDAD*DVP.PREC) AS ")
                query_select_partidas_devoluciones.Append("TOT_PARTIDA, DVP.FACT_CONV, DVP.CON_LOTE ")
                query_select_partidas_devoluciones.Append("FROM	dbo.devol_encabezados AS DVE INNER JOIN dbo.devol_partidas DVP ")
                query_select_partidas_devoluciones.Append("ON DVE.CVE_INTERNA = DVP.CVE_INTERNA COLLATE MODERN_SPANISH_CI_AS ")
                query_select_partidas_devoluciones.Append("WHERE DVE.CVE_INTERNA = @CVE_INTERNA ")

                Dim cmd_select_partidas_devoluciones As New SqlCommand(query_select_partidas_devoluciones.ToString, miconexion)
                cmd_select_partidas_devoluciones.Parameters.AddWithValue("@CVE_INTERNA", dt_encabezados.Rows(i)(0))
                cmd_select_partidas_devoluciones.CommandTimeout = 2000
                cmd_select_partidas_devoluciones.Transaction = mitransacion
                Dim adaptador_select_partidas_devoluciones As New SqlDataAdapter(cmd_select_partidas_devoluciones)
                Dim dt_select_partidas_devoluciones As New DataTable
                adaptador_select_partidas_devoluciones.Fill(dt_select_partidas_devoluciones)

                For index_partidas_devolucion As Integer = 0 To dt_select_partidas_devoluciones.Rows.Count - 1
                    Dim correlativo_lote As Integer = 0

                    'Definir si es producto o servicio
                    Dim DTtipo As New DataTable
                    Dim Tipo As String
                    Tipo = "P"
                    Dim query_Tipo As New StringBuilder
                    query_Tipo.Append(" SELECT TIPO_ELE FROM SAE60Empre02.dbo.INVE02 WHERE (CVE_ART = @ART) ")
                    Dim cmd_select_Tipo As New SqlCommand(query_Tipo.ToString, miconexion)
                    cmd_select_Tipo.Parameters.AddWithValue("@ART", dt_select_partidas_devoluciones.Rows(index_partidas_devolucion)(0))
                    cmd_select_Tipo.Transaction = mitransacion
                    Dim adaptador_select_Tipo As New SqlDataAdapter(cmd_select_Tipo)
                    Dim dt_select_Tipo As New DataTable
                    adaptador_select_Tipo.Fill(DTtipo)
                    Tipo = DTtipo(0)(0)

                    'validar lotes
                    If dt_select_partidas_devoluciones.Rows(index_partidas_devolucion)(14) = "S" Then
                        Dim query_select_LOTE As New StringBuilder
                        query_select_LOTE.Append(" SELECT REG_LTPD, PXRS FROM SAE60Empre02.dbo.ENLACE_LTPD02 WHERE E_LTPD = @LOTE")
                        Dim cmd_select_LOTE As New SqlCommand(query_select_LOTE.ToString, miconexion)
                        cmd_select_LOTE.Parameters.AddWithValue("@LOTE", dt_select_partidas_devoluciones.Rows(index_partidas_devolucion)(10))
                        cmd_select_LOTE.Transaction = mitransacion
                        Dim adaptador_select_LOTE As New SqlDataAdapter(cmd_select_LOTE)
                        Dim dt_select_LOTE As New DataTable
                        adaptador_select_LOTE.Fill(dt_select_LOTE)

                        Dim query_ltpd As New StringBuilder
                        query_ltpd.Append("UPDATE [SAE60Empre02].[dbo].[LTPD02] ")
                        query_ltpd.Append("SET [CANTIDAD] = [CANTIDAD] + @CANTIDAD ")
                        query_ltpd.Append("WHERE [CVE_ART] = @CVE_ART AND [CVE_ALM] = @CVE_ALM ")
                        query_ltpd.Append(" AND [REG_LTPD] = @REG_LTPD ")
                        Dim comando_ltpd As New SqlCommand(query_ltpd.ToString, miconexion)
                        comando_ltpd.Parameters.AddWithValue("@CVE_ART", dt_select_partidas_devoluciones.Rows(index_partidas_devolucion)(0))
                        comando_ltpd.Parameters.AddWithValue("@CANTIDAD", dt_select_partidas_devoluciones.Rows(index_partidas_devolucion)(1))
                        comando_ltpd.Parameters.AddWithValue("@CVE_ALM", dt_tabla_datos_factura.Rows(0)(10))
                        If dt_select_LOTE.Rows.Count > 0 Then
                            comando_ltpd.Parameters.AddWithValue("@REG_LTPD", dt_select_LOTE.Rows(0)(0))
                        Else
                            comando_ltpd.Parameters.AddWithValue("@REG_LTPD", 0)
                        End If

                        comando_ltpd.Transaction = mitransacion
                        comando_ltpd.ExecuteNonQuery()

                        Dim query_correlativo_lotes As New StringBuilder
                        query_correlativo_lotes.Append("SELECT (ULT_CVE + 1) AS ULT_CVE FROM SAE60Empre02.dbo.TBLCONTROL02 WHERE (ID_TABLA = 67) ")
                        Dim cmd_correlativo_lote As New SqlCommand(query_correlativo_lotes.ToString, miconexion)
                        cmd_correlativo_lote.Transaction = mitransacion
                        Dim adaptador_correlativo_lote As New SqlDataAdapter(cmd_correlativo_lote)
                        Dim dt_correlativo_lote As New DataTable
                        adaptador_correlativo_lote.Fill(dt_correlativo_lote)
                        correlativo_lote = dt_correlativo_lote.Rows(0)(0)

                        Dim query_UPD_enlace_ltpd As New StringBuilder
                        query_UPD_enlace_ltpd.Append("UPDATE [SAE60Empre02].[dbo].[ENLACE_LTPD02] ")

                        If dt_select_LOTE.Rows.Count > 0 Then
                            If dt_select_partidas_devoluciones.Rows(index_partidas_devolucion)(1) > dt_select_LOTE.Rows(0)(1) Then
                                query_UPD_enlace_ltpd.Append("SET [PXRS] = 0 ")
                            Else
                                query_UPD_enlace_ltpd.Append("SET [PXRS] = [PXRS] - @CANTIDAD ")
                            End If
                        Else
                            query_UPD_enlace_ltpd.Append("SET [PXRS] = [PXRS] - @CANTIDAD ")
                        End If

                        query_UPD_enlace_ltpd.Append("WHERE [E_LTPD] = @E_LTPD ")
                        Dim comando_UPD_enlace_ltpd As New SqlCommand(query_UPD_enlace_ltpd.ToString, miconexion)
                        comando_UPD_enlace_ltpd.Parameters.AddWithValue("@E_LTPD", dt_select_partidas_devoluciones.Rows(index_partidas_devolucion)(10))
                        comando_UPD_enlace_ltpd.Parameters.AddWithValue("@CANTIDAD", dt_select_partidas_devoluciones.Rows(index_partidas_devolucion)(1))
                        comando_UPD_enlace_ltpd.Transaction = mitransacion
                        comando_UPD_enlace_ltpd.ExecuteNonQuery()

                        Dim query_enlace_ltpd As New StringBuilder
                        query_enlace_ltpd.Append("INSERT INTO [SAE60Empre02].[dbo].[ENLACE_LTPD02] ")
                        query_enlace_ltpd.Append("   ([E_LTPD],[REG_LTPD],[CANTIDAD],[PXRS]) ")
                        query_enlace_ltpd.Append("VALUES ")
                        query_enlace_ltpd.Append("   (@E_LTPD,@REG_LTPD, @CANTIDAD,@PXRS)")
                        Dim comando_enlace_ltpd As New SqlCommand(query_enlace_ltpd.ToString, miconexion)
                        comando_enlace_ltpd.Parameters.AddWithValue("@E_LTPD", correlativo_lote)

                        If dt_select_LOTE.Rows.Count > 0 Then
                            comando_enlace_ltpd.Parameters.AddWithValue("@REG_LTPD", dt_select_LOTE.Rows(0)(0))
                        Else
                            comando_enlace_ltpd.Parameters.AddWithValue("@REG_LTPD", 0)
                        End If

                        comando_enlace_ltpd.Parameters.AddWithValue("@CANTIDAD", dt_select_partidas_devoluciones.Rows(index_partidas_devolucion)(1))
                        comando_enlace_ltpd.Parameters.AddWithValue("@PXRS", dt_select_partidas_devoluciones.Rows(index_partidas_devolucion)(1))
                        comando_enlace_ltpd.Transaction = mitransacion
                        comando_enlace_ltpd.ExecuteNonQuery()
                    End If
                    'fin validar lotes

                    'debe ir en cada partida
                    Dim _query_doctosig As New StringBuilder
                    _query_doctosig.Append("INSERT INTO [SAE60Empre02].[dbo].[DOCTOSIGF02] ")
                    _query_doctosig.Append("([TIP_DOC],[CVE_DOC],[ANT_SIG],[TIP_DOC_E] ")
                    _query_doctosig.Append(",[CVE_DOC_E],[PARTIDA],[PART_E],[CANT_E]) ")
                    _query_doctosig.Append("VALUES ")
                    _query_doctosig.Append("('D',@CVE_DOC,'A', 'F',@CVE_DOC_E,@PARTIDA,0,0)")
                    Dim _cmd_doctosig As New SqlCommand(_query_doctosig.ToString, miconexion)
                    _cmd_doctosig.Parameters.AddWithValue("@CVE_DOC", documento)
                    _cmd_doctosig.Parameters.AddWithValue("@CVE_DOC_E", dt_encabezados.Rows(i)(1))
                    _cmd_doctosig.Parameters.AddWithValue("@PARTIDA", index_partidas_devolucion + 1)
                    _cmd_doctosig.Transaction = mitransacion
                    _cmd_doctosig.ExecuteNonQuery()

                    Dim _query_doctosig2 As New StringBuilder

                    _query_doctosig2.Append("INSERT INTO [SAE60Empre02].[dbo].[DOCTOSIGF02] ")
                    _query_doctosig2.Append("([TIP_DOC],[CVE_DOC],[ANT_SIG],[TIP_DOC_E] ")
                    _query_doctosig2.Append(",[CVE_DOC_E],[PARTIDA],[PART_E],[CANT_E]) ")
                    _query_doctosig2.Append("VALUES ")
                    _query_doctosig2.Append("('F',@CVE_DOC,'A', 'D',@CVE_DOC_E,@PARTIDA,0,0)")
                    Dim _cmd_doctosig2 As New SqlCommand(_query_doctosig2.ToString, miconexion)
                    _cmd_doctosig2.Parameters.AddWithValue("@CVE_DOC", dt_encabezados.Rows(i)(1))
                    _cmd_doctosig2.Parameters.AddWithValue("@CVE_DOC_E", documento)
                    _cmd_doctosig2.Parameters.AddWithValue("@PARTIDA", index_partidas_devolucion + 1)
                    _cmd_doctosig2.Transaction = mitransacion
                    _cmd_doctosig2.ExecuteNonQuery()

                    Dim _query_par_factd As New StringBuilder

                    _query_par_factd.Append("INSERT INTO [SAE60Empre02].[dbo].[PAR_FACTD02] ")
                    _query_par_factd.Append("([CVE_DOC],[NUM_PAR],[CVE_ART],[CANT],[PXS],[PREC],[COST],[IMPU1],[IMPU2] ")
                    _query_par_factd.Append(",[IMPU3],[IMPU4],[IMP1APLA],[IMP2APLA],[IMP3APLA],[IMP4APLA],[TOTIMP1], ")
                    _query_par_factd.Append("[TOTIMP2],[TOTIMP3],[TOTIMP4],[DESC1],[DESC2],[DESC3],[COMI],[APAR],[ACT_INV] ")
                    _query_par_factd.Append(",[NUM_ALM],[POLIT_APLI],[TIP_CAM],[UNI_VENTA],[TIPO_PROD],[CVE_OBS],[REG_SERIE], ")
                    _query_par_factd.Append("[E_LTPD],[TIPO_ELEM],[NUM_MOV],[TOT_PARTIDA],[IMPRIMIR]) ")
                    _query_par_factd.Append("VALUES  ")
                    _query_par_factd.Append("(@CVE_DOC, @NUM_PAR, @CVE_ART, @CANT, @PXS, @PREC, @COST, 0, 0, 0, ")
                    _query_par_factd.Append("@IMPU4, 0, 0, 0, 0, 0, 0, 0, @TOTIMP4, ")
                    _query_par_factd.Append("@DESC1, 0, 0, 0, 0, 'S', @NUM_ALM, @POLIT_APLI, 1, @UNI_VENTA,'P', 0,0, @E_LTPD,  ")
                    _query_par_factd.Append("'N', ((SELECT ULT_CVE + 1 FROM SAE60EMPRE02.dbo.TBLCONTROL02 WHERE (ID_TABLA = 44))), @TOT_PARTIDA, 'S') ")

                    Dim _cmd_par_factd As New SqlCommand(_query_par_factd.ToString, miconexion)
                    _cmd_par_factd.Parameters.AddWithValue("@CVE_DOC", documento)
                    _cmd_par_factd.Parameters.AddWithValue("@NUM_PAR", index_partidas_devolucion + 1)
                    _cmd_par_factd.Parameters.AddWithValue("@CVE_ART", dt_select_partidas_devoluciones.Rows(index_partidas_devolucion)(0))
                    _cmd_par_factd.Parameters.AddWithValue("@CANT", dt_select_partidas_devoluciones.Rows(index_partidas_devolucion)(1))
                    _cmd_par_factd.Parameters.AddWithValue("@PXS", dt_select_partidas_devoluciones.Rows(index_partidas_devolucion)(1))
                    _cmd_par_factd.Parameters.AddWithValue("@PREC", dt_select_partidas_devoluciones.Rows(index_partidas_devolucion)(2))
                    _cmd_par_factd.Parameters.AddWithValue("@COST", dt_select_partidas_devoluciones.Rows(index_partidas_devolucion)(3))
                    _cmd_par_factd.Parameters.AddWithValue("@IMPU4", dt_select_partidas_devoluciones.Rows(index_partidas_devolucion)(4))
                    _cmd_par_factd.Parameters.AddWithValue("@TOTIMP4", dt_select_partidas_devoluciones.Rows(index_partidas_devolucion)(5))
                    _cmd_par_factd.Parameters.AddWithValue("@DESC1", dt_select_partidas_devoluciones.Rows(index_partidas_devolucion)(6))
                    _cmd_par_factd.Parameters.AddWithValue("@NUM_ALM", dt_select_partidas_devoluciones.Rows(index_partidas_devolucion)(7))
                    _cmd_par_factd.Parameters.AddWithValue("@POLIT_APLI", dt_select_partidas_devoluciones.Rows(index_partidas_devolucion)(8))
                    _cmd_par_factd.Parameters.AddWithValue("@UNI_VENTA", dt_select_partidas_devoluciones.Rows(index_partidas_devolucion)(9))
                    _cmd_par_factd.Parameters.AddWithValue("@E_LTPD", correlativo_lote)
                    _cmd_par_factd.Parameters.AddWithValue("@TOT_PARTIDA", dt_select_partidas_devoluciones.Rows(index_partidas_devolucion)(12))
                    _cmd_par_factd.Transaction = mitransacion
                    _cmd_par_factd.ExecuteNonQuery()

                    Dim _query_par_factd_clib As New StringBuilder
                    _query_par_factd_clib.Append("INSERT INTO [SAE60Empre02].[dbo].[PAR_FACTD_CLIB02] ")
                    _query_par_factd_clib.Append("([CLAVE_DOC],[NUM_PART]) ")
                    _query_par_factd_clib.Append("VALUES(@CLAVE_DOC, @NUM_PART)")
                    Dim _cmd_par_factd_clib As New SqlCommand(_query_par_factd_clib.ToString, miconexion)
                    _cmd_par_factd_clib.Parameters.AddWithValue("@CLAVE_DOC", documento)
                    _cmd_par_factd_clib.Parameters.AddWithValue("@NUM_PART", index_partidas_devolucion + 1)
                    _cmd_par_factd_clib.Transaction = mitransacion
                    _cmd_par_factd_clib.ExecuteNonQuery()


                    Dim query_costo_prom As New StringBuilder
                    query_costo_prom.Append("SELECT ISNULL(EXIST,0),ISNULL(COSTO_PROM,0) FROM SAE60EMPRE02.dbo.INVE02 WHERE CVE_ART = @CVE_ART")
                    Dim comando_costo_prom As New SqlCommand(query_costo_prom.ToString, miconexion)
                    comando_costo_prom.Parameters.AddWithValue("@CVE_ART", dt_select_partidas_devoluciones.Rows(index_partidas_devolucion)(0))
                    comando_costo_prom.Transaction = mitransacion
                    Dim adaptador_costo As New SqlDataAdapter(comando_costo_prom)
                    Dim dt_costo_prom As New DataTable
                    Dim existencias_viejas As Double = 0, costo_prom_viejo As Double = 0
                    adaptador_costo.Fill(dt_costo_prom)
                    existencias_viejas = dt_costo_prom.Rows(0)(0)
                    costo_prom_viejo = dt_costo_prom.Rows(0)(1)

                    Dim costo_prom_nuevo As Double = 0
                    costo_prom_nuevo = ((existencias_viejas * costo_prom_viejo) + (dt_select_partidas_devoluciones.Rows(index_partidas_devolucion)(1)) _
                                        * dt_select_partidas_devoluciones.Rows(index_partidas_devolucion)(3)) / (existencias_viejas + _
                                            dt_select_partidas_devoluciones.Rows(index_partidas_devolucion)(1))

                    'Cambia cantidades en inventario solo si es Producto, si es Servicio no completa esta parte.
                    If Tipo = "P" Then
                        Dim _query_inve As New StringBuilder
                        _query_inve.Append("UPDATE SAE60EMPRE02.dbo.INVE02 ")
                        _query_inve.Append("SET [EXIST] = (EXIST + @NUEVA_EXISTENCIA), ")
                        _query_inve.Append("[VTAS_ANL_C] = (VTAS_ANL_C-@VTAS_ANL_C),[VTAS_ANL_M] = (VTAS_ANL_M-@VTAS_ANL_M), ")
                        _query_inve.Append("COSTO_PROM = @COSTO_PROM, ULT_COSTO = @ULT_COSTO ")
                        _query_inve.Append("WHERE [CVE_ART] = @CVE_ART ")
                        Dim comando_update_inve As New SqlCommand(_query_inve.ToString(), miconexion)
                        comando_update_inve.Parameters.AddWithValue("@NUEVA_EXISTENCIA", _
                                                                    dt_select_partidas_devoluciones.Rows(index_partidas_devolucion)(1))
                        comando_update_inve.Parameters.AddWithValue("@VTAS_ANL_C", dt_select_partidas_devoluciones.Rows(index_partidas_devolucion)(1))
                        comando_update_inve.Parameters.AddWithValue("@VTAS_ANL_M", dt_select_partidas_devoluciones.Rows(index_partidas_devolucion)(12))
                        comando_update_inve.Parameters.AddWithValue("@CVE_ART", dt_select_partidas_devoluciones.Rows(index_partidas_devolucion)(0))
                        comando_update_inve.Parameters.AddWithValue("@COSTO_PROM", costo_prom_nuevo)
                        comando_update_inve.Parameters.AddWithValue("@ULT_COSTO", dt_select_partidas_devoluciones.Rows(index_partidas_devolucion)(3))
                        comando_update_inve.Transaction = mitransacion
                        comando_update_inve.ExecuteNonQuery()

                        Dim _query_upda_mult As New StringBuilder
                        _query_upda_mult.Append("UPDATE SAE60EMPRE02.dbo.MULT02 ")
                        _query_upda_mult.Append("SET [EXIST] = (EXIST + @NUEVA_EXISTENCIA) ")
                        _query_upda_mult.Append("WHERE  [CVE_ART] = @CVE_ART AND [CVE_ALM] = @CVE_ALM ")
                        Dim comando_upd_mult As New SqlCommand(_query_upda_mult.ToString, miconexion)
                        comando_upd_mult.Parameters.AddWithValue("@NUEVA_EXISTENCIA", dt_select_partidas_devoluciones.Rows(index_partidas_devolucion)(1))
                        comando_upd_mult.Parameters.AddWithValue("@CVE_ART", dt_select_partidas_devoluciones.Rows(index_partidas_devolucion)(0))
                        comando_upd_mult.Parameters.AddWithValue("@CVE_ALM", dt_tabla_datos_factura.Rows(0)(10))
                        comando_upd_mult.Transaction = mitransacion
                        comando_upd_mult.ExecuteNonQuery()

                        Dim _query_minve As New StringBuilder
                        _query_minve.Append("INSERT INTO [SAE60Empre02].[dbo].[MINVE02] ")
                        _query_minve.Append("([CVE_ART],[ALMACEN],[NUM_MOV],[CVE_CPTO],[FECHA_DOCU],[TIPO_DOC] ")
                        _query_minve.Append(",[REFER],[CLAVE_CLPV],[VEND],[CANT],[CANT_COST],[PRECIO],[COSTO] ")
                        _query_minve.Append(",[REG_SERIE],[UNI_VENTA],[E_LTPD],[EXIST_G] ")
                        _query_minve.Append(",[EXISTENCIA],[FACTOR_CON],[FECHAELAB],[CTLPOL],[CVE_FOLIO] ")
                        _query_minve.Append(",[SIGNO],[COSTEADO],[COSTO_PROM_INI],[COSTO_PROM_FIN],[COSTO_PROM_GRAL] ")
                        _query_minve.Append(",[DESDE_INVE],[MOV_ENLAZADO]) ")
                        _query_minve.Append("VALUES ")
                        _query_minve.Append("(@CVE_ART,@ALMACEN,((SELECT ULT_CVE + 1 FROM SAE60EMPRE02.dbo.TBLCONTROL02 WHERE (ID_TABLA = 44))) ")
                        _query_minve.Append(",2,@FECHA_DOCU,'D',@REFER,@CLAVE_CLPV,@VEND ")
                        _query_minve.Append(",@CANT,0,@PRECIO,@COSTO,0,@UNI_VENTA,@E_LTPD, ")
                        _query_minve.Append(" ((SELECT EXIST FROM SAE60EMPRE02.dbo.INVE02 WHERE (CVE_ART = @CVE_ART))), ")
                        _query_minve.Append("((SELECT EXIST FROM SAE60EMPRE02.dbo.MULT02 WHERE (CVE_ART = @CVE_ART) AND CVE_ALM = @ALMACEN)), ")
                        _query_minve.Append("@FACTOR_CON,@FECHAELAB,0,(SELECT ULT_CVE+1 FROM SAE60EMPRE02.dbo.TBLCONTROL02 WHERE (ID_TABLA = 32)),1,'S', ")
                        _query_minve.Append("@COSTO_PROM_INI,@COSTO_PROM_FIN,@COSTO_PROM_GRAL,'N',@MOV_ENLAZADO) ")

                        Dim _cmd_query_minve As New SqlCommand(_query_minve.ToString, miconexion)

                        _cmd_query_minve.Parameters.AddWithValue("@CVE_ART", dt_select_partidas_devoluciones.Rows(index_partidas_devolucion)(0))
                        _cmd_query_minve.Parameters.AddWithValue("@ALMACEN", almacen)
                        _cmd_query_minve.Parameters.AddWithValue("@FECHA_DOCU", dt_tabla_datos_factura.Rows(0)(6))
                        _cmd_query_minve.Parameters.AddWithValue("@REFER", documento)
                        _cmd_query_minve.Parameters.AddWithValue("@CLAVE_CLPV", dt_encabezados.Rows(i)(3))
                        _cmd_query_minve.Parameters.AddWithValue("@VEND", dt_tabla_datos_factura.Rows(0)(4))
                        _cmd_query_minve.Parameters.AddWithValue("@CANT", dt_select_partidas_devoluciones.Rows(index_partidas_devolucion)(1))
                        _cmd_query_minve.Parameters.AddWithValue("@PRECIO", dt_select_partidas_devoluciones.Rows(index_partidas_devolucion)(2))
                        _cmd_query_minve.Parameters.AddWithValue("@COSTO", dt_select_partidas_devoluciones.Rows(index_partidas_devolucion)(3))
                        _cmd_query_minve.Parameters.AddWithValue("@UNI_VENTA", dt_select_partidas_devoluciones.Rows(index_partidas_devolucion)(9))
                        _cmd_query_minve.Parameters.AddWithValue("@E_LTPD", correlativo_lote)
                        _cmd_query_minve.Parameters.AddWithValue("@FACTOR_CON", dt_select_partidas_devoluciones.Rows(index_partidas_devolucion)(13))
                        _cmd_query_minve.Parameters.AddWithValue("@COSTO_PROM_INI", costo_prom_viejo)
                        _cmd_query_minve.Parameters.AddWithValue("@COSTO_PROM_FIN", costo_prom_nuevo)
                        _cmd_query_minve.Parameters.AddWithValue("@COSTO_PROM_GRAL", costo_prom_nuevo)
                        _cmd_query_minve.Parameters.AddWithValue("@FECHAELAB", Now.Date)
                        _cmd_query_minve.Parameters.AddWithValue("@MOV_ENLAZADO", dt_select_partidas_devoluciones.Rows(index_partidas_devolucion)(11))
                        _cmd_query_minve.Transaction = mitransacion
                        _cmd_query_minve.ExecuteNonQuery()

                        'actualizar los numeros de movimientos al inventario
                        Dim query_update_tabla_control_44 As New StringBuilder
                        query_update_tabla_control_44.Append("UPDATE SAE60EMPRE02.dbo.TBLCONTROL02 ")
                        query_update_tabla_control_44.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                        query_update_tabla_control_44.Append("WHERE (ID_TABLA = 44) ")
                        Dim micomando_upd_tabla_control44 As New SqlCommand(query_update_tabla_control_44.ToString, miconexion)
                        micomando_upd_tabla_control44.Transaction = mitransacion
                        micomando_upd_tabla_control44.ExecuteNonQuery()

                        'actualizar los numeros de FOLIOS al inventario
                        Dim query_update_tabla_control_32 As New StringBuilder
                        query_update_tabla_control_32.Append("UPDATE SAE60EMPRE02.dbo.TBLCONTROL02 ")
                        query_update_tabla_control_32.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                        query_update_tabla_control_32.Append("WHERE (ID_TABLA = 32) ")
                        Dim micomando_upd_tabla_control32 As New SqlCommand(query_update_tabla_control_32.ToString, miconexion)
                        micomando_upd_tabla_control32.Transaction = mitransacion
                        micomando_upd_tabla_control32.ExecuteNonQuery()

                        'actualizar los correlativos de los lotes
                        Dim query_upd_correlativo_lote As New StringBuilder
                        query_upd_correlativo_lote.Append("UPDATE [SAE60Empre02].[dbo].[TBLCONTROL02] ")
                        query_upd_correlativo_lote.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                        query_upd_correlativo_lote.Append("WHERE([ID_TABLA] = 67)")
                        Dim comando_upd_correlativo_lote As New SqlCommand(query_upd_correlativo_lote.ToString, miconexion)
                        comando_upd_correlativo_lote.Transaction = mitransacion
                        comando_upd_correlativo_lote.ExecuteNonQuery()
                    End If
                Next

                Dim _query_foliosf As New StringBuilder
                _query_foliosf.Append("UPDATE [SAE60Empre02].[dbo].[FOLIOSF02] ")
                _query_foliosf.Append(" SET [ULT_DOC] = ULT_DOC +1 ")
                _query_foliosf.Append("WHERE [SERIE] = @SERIE")
                Dim _cmd_foliosf As New SqlCommand(_query_foliosf.ToString, miconexion)
                _cmd_foliosf.Parameters.AddWithValue("@SERIE", serie)
                _cmd_foliosf.Transaction = mitransacion
                _cmd_foliosf.ExecuteNonQuery()

                Dim _query_control2 As New StringBuilder
                _query_control2.Append("UPDATE [SAE60Empre02].[dbo].[TBLCONTROL02] ")
                _query_control2.Append(" SET [ULT_CVE] = ULT_CVE + 1 ")
                _query_control2.Append("WHERE [ID_TABLA] = 62 ")
                Dim _cmd_control2 As New SqlCommand(_query_control2.ToString, miconexion)
                _cmd_control2.Transaction = mitransacion
                _cmd_control2.ExecuteNonQuery()

                Dim _query_control3 As New StringBuilder
                _query_control3.Append("UPDATE [SAE60Empre02].[dbo].[TBLCONTROL02] ")
                _query_control3.Append(" SET [ULT_CVE] = ULT_CVE + 1 ")
                _query_control3.Append("WHERE [ID_TABLA] = 56 ")
                Dim _cmd_control3 As New SqlCommand(_query_control3.ToString, miconexion)
                _cmd_control3.Transaction = mitransacion
                _cmd_control3.ExecuteNonQuery()

                documento_fin = documento

            Next

            'informacion LOCAL
            Dim query_ins_recepcion As New StringBuilder
            query_ins_recepcion.Append("INSERT INTO [tactical_discount_sragro].[dbo].[devol_recepciones] ")
            query_ins_recepcion.Append("       ([RANGO_INI],[RANGO_FIN],[FECHA],[ALMACEN],[DEVOINI],[DEVOFIN]) ")
            query_ins_recepcion.Append(" VALUES (@RANGO_INI,@RANGO_FIN,@FECHA,@ALMACEN,@DEVOINI,@DEVOFIN) ")
            Dim comando_ins_recepcion As New SqlCommand(query_ins_recepcion.ToString, miconexion)
            comando_ins_recepcion.Parameters.AddWithValue("@RANGO_INI", rango_ini)
            comando_ins_recepcion.Parameters.AddWithValue("@RANGO_FIN", rango_fin)
            comando_ins_recepcion.Parameters.AddWithValue("@FECHA", fecha)
            comando_ins_recepcion.Parameters.AddWithValue("@ALMACEN", almacen)
            comando_ins_recepcion.Parameters.AddWithValue("@DEVOINI", documento_ini)
            comando_ins_recepcion.Parameters.AddWithValue("@DEVOFIN", documento_fin)
            comando_ins_recepcion.Transaction = mitransacion
            comando_ins_recepcion.ExecuteNonQuery()

            mitransacion.Commit()
            miconexion.Close()
            variable_error = "correcto"

        Catch ex As Exception
            mitransacion.Rollback()
            miconexion.Close()

            Dim tamaño As Integer = Convert.ToString(ex.StackTrace).Length
            Dim posicion As Integer = InStrRev(Convert.ToString(ex.StackTrace), "línea") - 1
            Dim inicial As Integer = tamaño - posicion
            Dim linea_error As String = Convert.ToString(ex.StackTrace).Substring(tamaño - inicial, inicial)

            variable_error = ex.Message + " --> " + linea_error
        End Try
        Return variable_error
    End Function

    Public Function Listarfolios(ByVal ALMACEN As Integer)
        Dim actualizarconexion As New SqlConnection(conexion.CadenaSQL)
        Dim query As New StringBuilder
        If ALMACEN <> 1 Then
            query.Append("SELECT REPLACE(REPLACE(SERIE,'-001-06-','-001-01-'),'-004-06-','-004-01-') AS SERIE FROM devol_folios WHERE (NUM_ALMA = @NUM_ALMA)")
        Else
            query.Append("SELECT '04-001-01-' FROM devol_folios WHERE (NUM_ALMA = 1)")
        End If

        Dim micomando As New SqlCommand(query.ToString, actualizarconexion)
        micomando.Parameters.AddWithValue("@NUM_ALMA", ALMACEN)

        actualizarconexion.Open()
        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        actualizarconexion.Close()
        Return dt
    End Function

    Public Function Validar_devoluciones(ByVal FACTURA As String)
        Dim actualizarconexion As New SqlConnection(conexion.CadenaSQL)
        Dim query As New StringBuilder

        query.Append("SELECT CVE_INTERNA ")
        query.Append("FROM devol_encabezados ")
        query.Append("WHERE (N_FACTURA = @FACTURA)")
        Dim micomando As New SqlCommand(query.ToString, actualizarconexion)
        micomando.Parameters.AddWithValue("@FACTURA", FACTURA)

        actualizarconexion.Open()
        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        actualizarconexion.Close()
        Return dt
    End Function

    Public Function Detalle_Devoluciones(ByVal CLAVE As String)
        Dim actualizarconexion As New SqlConnection(conexion.CadenaSQL)
        Dim query As New StringBuilder

        query.Append("SELECT NUM_PAR, CVE_ART, CANTIDAD,PREC,COST,IMPU4,DESC1,NUM_ALM, ")
        query.Append("POLIT_APLI,UNI_VENTA,E_LTPD,NUM_MOV,FACT_CONV,CON_LOTE ")
        query.Append("FROM   devol_partidas ")
        query.Append("WHERE (CVE_INTERNA = @CLAVE)")
        Dim micomando As New SqlCommand(query.ToString, actualizarconexion)
        micomando.Parameters.AddWithValue("@CLAVE", CLAVE)

        actualizarconexion.Open()
        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        actualizarconexion.Close()
        Return dt
    End Function

End Class


