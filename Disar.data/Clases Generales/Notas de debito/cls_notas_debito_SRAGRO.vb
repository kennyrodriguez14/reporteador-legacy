﻿Imports System.Text
Imports Disar.data
Imports System.Data.SqlClient

Public Class cls_notas_debito_SRAGRO
    Dim conexion As New cls_conexion_descuentos_tacticos_sragro
    Dim conexion_agro As New clsconexion_sr_agro
    Public Function listar_productos() As DataTable
        Dim conexion_sql As New SqlConnection(conexion.CadenaSQL)

        Dim query As New StringBuilder
        query.Append("SELECT I.CVE_ART AS 'Codigo', I.DESCR AS 'Producto', ")
        query.Append("ISNULL(CONVERT(VARCHAR,P.PRECIO_NEG),'No asignado') AS 'Precio Negociado' ")
        query.Append("FROM SAE60Empre02.dbo.INVE02 I FULL OUTER JOIN nd_precios_negociados P ")
        query.Append("ON P.CVE_ART = I.CVE_ART COLLATE MODERN_SPANISH_CI_AS ")
        query.Append("WHERE I.STATUS <> 'B' AND I.DESCR NOT LIKE 'ZDEV' ")

        conexion_sql.Open()
        Dim micomando As New SqlCommand(query.ToString, conexion_sql)

        Dim dt As New DataTable
        Dim adaptador As New SqlDataAdapter(micomando)
        adaptador.Fill(dt)

        conexion_sql.Close()
        Return dt
    End Function

    Public Function filtros(ByVal BUSCAR As String, ByVal BUSCAR_PROVEEDOR As String, ByVal codigos_no_mostrar As String) As DataTable
        Dim dt As New DataTable
        Dim sql_con As New SqlConnection(conexion.CadenaSQL)
        sql_con.Open()
        Dim query As New StringBuilder

        query.Append("SELECT I.CVE_ART AS 'Codigo', I.DESCR AS 'Producto', ")
        query.Append("ISNULL(CONVERT(VARCHAR,P.PRECIO_NEG),'No asignado') AS 'Precio Negociado', I.EXIST AS EXISTENCIA, I.PESO, ")
        query.Append(" ISV.IMPUESTO4 AS ISV, I.FAC_CONV AS FACTOR, ")

        query.Append(" ISNULL((SELECT EXIST FROM SAE60Empre02.dbo.MULT02 M WHERE M.CVE_ART = I.CVE_ART AND M.CVE_ALM = 1),0) AS SRC, ")
        query.Append(" ISNULL((SELECT EXIST FROM SAE60Empre02.dbo.MULT02 M WHERE M.CVE_ART = I.CVE_ART AND M.CVE_ALM = 2),0) AS GRACIAS, ")
        query.Append(" ISNULL((SELECT EXIST FROM SAE60Empre02.dbo.MULT02 M WHERE M.CVE_ART = I.CVE_ART AND M.CVE_ALM = 3),0) AS CD ")

        query.Append("FROM SAE60Empre02.dbo.INVE02 I FULL OUTER JOIN nd_precios_negociados P ")
        query.Append("ON P.CVE_ART = I.CVE_ART COLLATE MODERN_SPANISH_CI_AS ")
        query.Append("FULL OUTER JOIN SAE60Empre02.dbo.PRVPROD02 PP ON PP.CVE_ART = I.CVE_ART ")
        query.Append(" LEFT OUTER JOIN SAE60Empre02.dbo.IMPU02 ISV ON I.CVE_ESQIMPU = ISV.CVE_ESQIMPU ")
        query.Append("WHERE I.STATUS <> 'B' AND I.DESCR NOT LIKE 'ZDEV' AND I.DESCR NOT LIKE 'PRM%' ")
        query.Append("AND (I.DESCR LIKE '%'+ UPPER(@BUSCAR) + '%' OR I.CVE_ART LIKE '%'+ @BUSCAR + '%') AND ")
        query.Append("(CVE_PROV = @BUSCAR_PROVEEDOR OR @BUSCAR_PROVEEDOR = '-1') AND I.CVE_ART NOT IN (" + codigos_no_mostrar + ")")

        Dim comando As New SqlCommand(query.ToString, sql_con)
        comando.Parameters.AddWithValue("@BUSCAR", BUSCAR)
        comando.Parameters.AddWithValue("@BUSCAR_PROVEEDOR", BUSCAR_PROVEEDOR)
        Dim adaptador As New SqlDataAdapter(comando)
        adaptador.Fill(dt)
        Return dt
        sql_con.Close()
    End Function

    Public Function insertar_precio(ByVal CVE_ART As String, ByVal PRECIO_NEG As Double, ByVal usuarioid As Integer, _
                                    ByVal usuario_nombre As String, ByVal fecha_hora As DateTime, ByVal precio_anterior As String) As String
        Dim mitransaccion As SqlTransaction
        Dim conexion_sql As New SqlConnection(conexion.CadenaSQL)
        conexion_sql.Open()
        mitransaccion = conexion_sql.BeginTransaction
        Try
            Dim query As New StringBuilder
            Dim query_bita As New StringBuilder

            query.Append("INSERT INTO [tactical_discount_sragro].[dbo].[nd_precios_negociados] ")
            query.Append("([CVE_ART],[PRECIO_NEG]) ")
            query.Append("VALUES(@CVE_ART, @PRECIO_NEG) ")
            Dim micomando As New SqlCommand(query.ToString, conexion_sql)

            micomando.Parameters.AddWithValue("@CVE_ART", CVE_ART)
            micomando.Parameters.AddWithValue("@PRECIO_NEG", PRECIO_NEG)
            micomando.Transaction = mitransaccion
            micomando.ExecuteNonQuery()

            query_bita.Append("INSERT INTO [tactical_discount_sragro].[dbo].[nd_bita_precios] ")
            query_bita.Append(" ([usuario_id],[usuario_nombre],[fecha_hora] ")
            query_bita.Append(" ,[observacion],[cve_art],[precio_ant],[precio_nuevo]) ")
            query_bita.Append(" VALUES ")
            query_bita.Append(" (@usuario_id,@usuario_nombre,@fecha_hora ")
            query_bita.Append(" ,'agregar precio',@cve_art,@precio_ant,@precio_nuevo) ")

            Dim micomando2 As New SqlCommand(query_bita.ToString, conexion_sql)
            micomando2.Parameters.AddWithValue("@usuario_id", usuarioid)
            micomando2.Parameters.AddWithValue("@usuario_nombre", usuario_nombre)
            micomando2.Parameters.AddWithValue("@fecha_hora", fecha_hora)
            micomando2.Parameters.AddWithValue("@cve_art", CVE_ART)
            micomando2.Parameters.AddWithValue("@precio_ant", precio_anterior)
            micomando2.Parameters.AddWithValue("@precio_nuevo", PRECIO_NEG)
            micomando2.Transaction = mitransaccion
            micomando2.ExecuteNonQuery()

            mitransaccion.Commit()
            conexion_sql.Close()
            Return "correcto"

        Catch ex As Exception
            mitransaccion.Rollback()
            conexion_sql.Close()
            Return ex.Message
        End Try
    End Function

    Public Function actualizar_precio(ByVal CVE_ART As String, ByVal PRECIO_NEG As Double, ByVal usuarioid As Integer, _
                                    ByVal usuario_nombre As String, ByVal fecha_hora As DateTime, ByVal precio_anterior As String) As String
        Dim mitransaccion As SqlTransaction
        Dim conexion_sql As New SqlConnection(conexion.CadenaSQL)
        conexion_sql.Open()
        mitransaccion = conexion_sql.BeginTransaction
        Try

            Dim query As New StringBuilder
            Dim query_bita As New StringBuilder
            query.Append("UPDATE [tactical_discount_sragro].[dbo].[nd_precios_negociados] ")
            query.Append("SET [PRECIO_NEG] = @PRECIO_NEG ")
            query.Append("WHERE [CVE_ART] = @CVE_ART")

            Dim micomando As New SqlCommand(query.ToString, conexion_sql)

            micomando.Parameters.AddWithValue("@PRECIO_NEG", PRECIO_NEG)
            micomando.Parameters.AddWithValue("@CVE_ART", CVE_ART)
            micomando.Transaction = mitransaccion
            micomando.ExecuteNonQuery()

            query_bita.Append("INSERT INTO [tactical_discount_sragro].[dbo].[nd_bita_precios] ")
            query_bita.Append(" ([usuario_id],[usuario_nombre],[fecha_hora] ")
            query_bita.Append(" ,[observacion],[cve_art],[precio_ant],[precio_nuevo]) ")
            query_bita.Append(" VALUES ")
            query_bita.Append(" (@usuario_id,@usuario_nombre,@fecha_hora ")
            query_bita.Append(" ,'cambiar precio',@cve_art,@precio_ant,@precio_nuevo) ")

            Dim micomando2 As New SqlCommand(query_bita.ToString, conexion_sql)
            micomando2.Parameters.AddWithValue("@usuario_id", usuarioid)
            micomando2.Parameters.AddWithValue("@usuario_nombre", usuario_nombre)
            micomando2.Parameters.AddWithValue("@fecha_hora", fecha_hora)
            micomando2.Parameters.AddWithValue("@cve_art", CVE_ART)
            micomando2.Parameters.AddWithValue("@precio_ant", precio_anterior)
            micomando2.Parameters.AddWithValue("@precio_nuevo", PRECIO_NEG)
            micomando2.Transaction = mitransaccion
            micomando2.ExecuteNonQuery()

            mitransaccion.Commit()
            conexion_sql.Close()
            Return "correcto"

        Catch ex As Exception
            conexion_sql.Close()
            Return ex.Message
        End Try
    End Function

    Public Function cargar_proveedores() As DataTable
        Dim dt As New DataTable
        Dim query As New StringBuilder
        Dim sql_con As New SqlConnection(conexion.CadenaSQL)

        query.Append("SELECT '-1' AS CLAVE, 'Sin Filtro' AS NOMBRE ")
        query.Append("UNION ALL ")
        query.Append("SELECT CLAVE, NOMBRE ")
        query.Append("FROM SAE60Empre02.dbo.PROV02 ")
        sql_con.Open()
        Dim comando As New SqlCommand(query.ToString, sql_con)
        Dim adaptador As New SqlDataAdapter(comando)
        adaptador.Fill(dt)
        sql_con.Close()
        Return dt
    End Function

    Public Function select_productos_precio_neg() As DataTable
        Dim conexion_sql As New SqlConnection(conexion.CadenaSQL)
        conexion_sql.Open()
        Dim query As New StringBuilder
        query.Append("SELECT TD.[CVE_ART] AS CODIGO,IV.DESCR AS PRODUCTO,")
        query.Append("TD.[PRECIO_NEG] AS 'PRECIO NEGOCIADO' ")
        query.Append("FROM [tactical_discount_sragro].[dbo].[nd_precios_negociados] TD ")
        query.Append("INNER JOIN SAE60Empre02.dbo.INVE02 IV ")
        query.Append("ON IV.CVE_ART = TD.CVE_ART COLLATE MODERN_SPANISH_CI_AS")
        query.Append("WHERE TD.CVE_ART LIKE '%' + @buscar + '%' OR IV.DESCR LIKE '%' + @buscar + '%' ")

        Dim comando As New SqlCommand(query.ToString)
        Dim dt As New DataTable

        conexion_sql.Close()
        Return dt

    End Function

    Public Function guardar_orden_pedido(ByVal id_orden As String, ByVal cve_prov As String, ByVal nombre As String, _
                                         ByVal rfc As String, ByVal almacen As Integer, ByVal ref_prov As String, ByVal descuento_por As Double, _
                                         ByVal fecha As DateTime, ByVal estado As String, ByVal sub_total As Double, ByVal descuento As Double, _
                                         ByVal isv As Double, ByVal total As Double, ByVal dt_partidas As DataTable, ByVal FOLIO As String, _
                                         ByVal TIPO_VEHICULO As String) As String
        Dim con_sql As New SqlConnection(conexion.CadenaSQL)
        Dim mi_transaccion As SqlTransaction
        con_sql.Open()
        mi_transaccion = con_sql.BeginTransaction
        Try
            Dim query_e As New StringBuilder
            query_e.Append(" INSERT INTO [tactical_discount_sragro].[dbo].[nd_orden_compra_e] ")
            query_e.Append("    ([CVE_COMPRA],[CVE_PROVEEDOR],[PROVEEDOR],[ALMACEN],[REF_PROV],[RFC],[FECHA] ")
            query_e.Append("    ,[DESCUENTO_POR],[SUB_TOTAL],[DESCUENTO_VAL],[ISV_VAL],[TOTAL],[ESTADO],[SUBTOTAL_MOST] ")
            query_e.Append("    ,[DESC_MOST],[ISV_MOST],[TOTAL_MOST],[FLETE],[LOTE],[F_VENCIMIENTO]) ")
            query_e.Append(" VALUES ")
            query_e.Append("(@CVE_COMPRA,@CVE_PROVEEDOR,@PROVEEDOR,@ALMACEN,@REF_PROV,@RFC,@FECHA ")
            query_e.Append(",@DESCUENTO_POR,@SUB_TOTAL,@DESCUENTO_VAL,@ISV_VAL,@TOTAL,@ESTADO,@SUBTOTAL_MOST ")
            query_e.Append(",@DESC_MOST,@ISV_MOST,@TOTAL_MOST,@FLETE,@LOTE,@F_VENCIMIENTO) ")

            Dim comando_e As New SqlCommand(query_e.ToString, con_sql)
            comando_e.Parameters.AddWithValue("@CVE_COMPRA", id_orden)
            comando_e.Parameters.AddWithValue("@CVE_PROVEEDOR", cve_prov)
            comando_e.Parameters.AddWithValue("@PROVEEDOR", nombre)
            comando_e.Parameters.AddWithValue("@ALMACEN", almacen)
            comando_e.Parameters.AddWithValue("@REF_PROV", ref_prov)
            comando_e.Parameters.AddWithValue("@RFC", rfc)
            comando_e.Parameters.AddWithValue("@FECHA", fecha)
            comando_e.Parameters.AddWithValue("@DESCUENTO_POR", descuento_por)
            comando_e.Parameters.AddWithValue("@SUB_TOTAL", sub_total)
            comando_e.Parameters.AddWithValue("@DESCUENTO_VAL", descuento)
            comando_e.Parameters.AddWithValue("@ISV_VAL", isv)
            comando_e.Parameters.AddWithValue("@TOTAL", total)
            comando_e.Parameters.AddWithValue("@ESTADO", estado)
            comando_e.Parameters.AddWithValue("@SUBTOTAL_MOST", sub_total)
            comando_e.Parameters.AddWithValue("@DESC_MOST", descuento)
            comando_e.Parameters.AddWithValue("@ISV_MOST", isv)
            comando_e.Parameters.AddWithValue("@TOTAL_MOST", total)
            comando_e.Parameters.AddWithValue("@FLETE", 0)
            comando_e.Parameters.AddWithValue("@LOTE", "")
            comando_e.Parameters.AddWithValue("@F_VENCIMIENTO", "")
            comando_e.Parameters.AddWithValue("@TIPO_VEHICULO", TIPO_VEHICULO)

            comando_e.Transaction = mi_transaccion
            comando_e.ExecuteNonQuery()

            For index As Integer = 0 To dt_partidas.Rows.Count - 1
                Dim query_p As New StringBuilder
                query_p.Append("INSERT INTO [tactical_discount_sragro].[dbo].[nd_orden_compra_p]  ")
                query_p.Append("([CVE_COMPRA],[NUM_PART],[UNI],[CVE_ART],[PRODUCTO],[FACT_CONV],[CANTIDAD],[PRECIO_NEG] ")
                query_p.Append(",[PRECIO_FINAL],[DESC_PROD],[ISV_PROD],[SUB_TOTAL],[DESCUENTO],[ISV],[TOTAL_PARTIDA] ")
                query_p.Append(",[PRECIO_INSERTAR],[AJUSTE],[SUBTOTAL_MOST],[DESC_MOST],[ISV_MOST],[TOTAL_MOST],[PRECIO_NETO] ")
                query_p.Append(",[PESO],[CON_LOTE]) ")
                query_p.Append("VALUES ")
                query_p.Append("(@CVE_COMPRA,@NUM_PART,@UNI,@CVE_ART,@PRODUCTO,@FACT_CONV,@CANTIDAD,@PRECIO_NEG,@PRECIO_FINAL ")
                query_p.Append(",@DESC_PROD,@ISV_PROD,@SUB_TOTAL,@DESCUENTO,@ISV,@TOTAL_PARTIDA,@PRECIO_INSERTAR,@AJUSTE ")
                query_p.Append(",@SUBTOTAL_MOST,@DESC_MOST,@ISV_MOST,@TOTAL_MOST,@PRECIO_NETO,@PESO,@CON_LOTE)")
                Dim comando_p As New SqlCommand(query_p.ToString, con_sql)
                comando_p.Parameters.AddWithValue("@CVE_COMPRA", id_orden)
                comando_p.Parameters.AddWithValue("@NUM_PART", index + 1)
                comando_p.Parameters.AddWithValue("@UNI", dt_partidas.Rows(index)(0))
                comando_p.Parameters.AddWithValue("@CVE_ART", dt_partidas.Rows(index)(1))
                comando_p.Parameters.AddWithValue("@PRODUCTO", dt_partidas.Rows(index)(2))
                comando_p.Parameters.AddWithValue("@FACT_CONV", dt_partidas.Rows(index)(3))
                comando_p.Parameters.AddWithValue("@CANTIDAD", dt_partidas.Rows(index)(4))
                comando_p.Parameters.AddWithValue("@PRECIO_NEG", dt_partidas.Rows(index)(5))
                comando_p.Parameters.AddWithValue("@PRECIO_FINAL", dt_partidas.Rows(index)(5))
                comando_p.Parameters.AddWithValue("@DESC_PROD", dt_partidas.Rows(index)(6))
                comando_p.Parameters.AddWithValue("@ISV_PROD", dt_partidas.Rows(index)(7))
                comando_p.Parameters.AddWithValue("@SUB_TOTAL", dt_partidas.Rows(index)(8))
                comando_p.Parameters.AddWithValue("@DESCUENTO", dt_partidas.Rows(index)(9))
                comando_p.Parameters.AddWithValue("@ISV", dt_partidas.Rows(index)(10))
                comando_p.Parameters.AddWithValue("@TOTAL_PARTIDA", dt_partidas.Rows(index)(11))
                comando_p.Parameters.AddWithValue("@PRECIO_INSERTAR", dt_partidas.Rows(index)(5))
                comando_p.Parameters.AddWithValue("@AJUSTE", "")
                comando_p.Parameters.AddWithValue("@SUBTOTAL_MOST", dt_partidas.Rows(index)(8))
                comando_p.Parameters.AddWithValue("@DESC_MOST", dt_partidas.Rows(index)(9))
                comando_p.Parameters.AddWithValue("@ISV_MOST", dt_partidas.Rows(index)(7))
                comando_p.Parameters.AddWithValue("@TOTAL_MOST", dt_partidas.Rows(index)(11))
                comando_p.Parameters.AddWithValue("@PRECIO_NETO", dt_partidas.Rows(index)(5))
                comando_p.Parameters.AddWithValue("@PESO", dt_partidas.Rows(index)(12))
                comando_p.Parameters.AddWithValue("@CON_LOTE", "")
                comando_p.Transaction = mi_transaccion
                comando_p.ExecuteNonQuery()
            Next

            Dim query_folios As New StringBuilder
            query_folios.Append("UPDATE [tactical_discount_sragro].[dbo].[nd_folios] ")
            query_folios.Append("SET [ULT_DOC] = ULT_DOC + 1 ")
            query_folios.Append("WHERE [FOLIO] = @FOLIO")
            Dim comando_folios As New SqlCommand(query_folios.ToString, con_sql)
            comando_folios.Parameters.AddWithValue("@FOLIO", FOLIO)
            comando_folios.Transaction = mi_transaccion
            comando_folios.ExecuteNonQuery()

            mi_transaccion.Commit()
            con_sql.Close()
            Return "correcto"
        Catch ex As Exception
            mi_transaccion.Rollback()
            con_sql.Close()
            Return ex.Message
        End Try
    End Function

    Public Function mostrar_proveedores(ByVal buscar As String) As DataTable
        Dim dt As New DataTable
        Dim query As New StringBuilder
        Dim sql_con As New SqlConnection(conexion.CadenaSQL)

        query.Append("SELECT CLAVE, NOMBRE, ISNULL(RFC,'') AS RFC , ISNULL((SELECT DIAS_AUTORIZADOS FROM  ")
        query.Append(" tactical_discount_sragro.dbo.nd_orden_dias_aut WHERE CVE_PROV = CLAVE COLLATE MODERN_SPANISH_CI_AS),0) ")
        query.Append("FROM SAE60EMPRE02.dbo.PROV02 ")
        query.Append("WHERE STATUS = 'A' AND (LTRIM(CLAVE) = @BUSCAR OR NOMBRE LIKE '%' + UPPER(@BUSCAR) + '%') ")
        sql_con.Open()
        Dim comando As New SqlCommand(query.ToString, sql_con)
        comando.Parameters.AddWithValue("@BUSCAR", buscar)
        Dim adaptador As New SqlDataAdapter(comando)
        adaptador.Fill(dt)
        sql_con.Close()
        Return dt
    End Function

    Public Function mostrar_proveedores_CARGILL(ByVal buscar As String) As DataTable
        Dim dt As New DataTable
        Dim query As New StringBuilder
        Dim sql_con As New SqlConnection(conexion.CadenaSQL)

        query.Append("SELECT CLAVE, NOMBRE, ISNULL(RFC,'') AS RFC , ISNULL((SELECT DIAS_AUTORIZADOS FROM  ")
        query.Append(" tactical_discount_sragro.dbo.nd_orden_dias_aut WHERE CVE_PROV = CLAVE COLLATE MODERN_SPANISH_CI_AS),0) ")
        query.Append("FROM SAE60EMPRE02.dbo.PROV02 ")
        query.Append("WHERE STATUS = 'A' AND  (CLAVE = @BUSCAR OR NOMBRE LIKE '%' + UPPER(@BUSCAR) + '%') ")
        'CLAVE IN ('        23','        24') AND
        sql_con.Open()
        Dim comando As New SqlCommand(query.ToString, sql_con)
        comando.Parameters.AddWithValue("@BUSCAR", buscar)
        Dim adaptador As New SqlDataAdapter(comando)
        adaptador.Fill(dt)
        sql_con.Close()
        Return dt
    End Function

    Public Function historico_productos(ByVal fecha_ini As Date, ByVal fecha_fin As Date, ByVal cve_art As String) As DataTable
        Dim dt As New DataTable
        Dim query As New StringBuilder
        Dim sql_con As New SqlConnection(conexion_agro.CadenaSQL)

        query.Append("historico_productos")
        sql_con.Open()
        Dim comando As New SqlCommand(query.ToString, sql_con)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@FECHA_INI", fecha_ini)
        comando.Parameters.AddWithValue("@FECHA_FIN", fecha_fin)
        comando.Parameters.AddWithValue("@CVE_ART", cve_art)

        Dim adaptador As New SqlDataAdapter(comando)
        adaptador.Fill(dt)
        sql_con.Close()
        Return dt
    End Function



    Public Function ListarAlmacenes()
        Dim actualizarconexion As New SqlConnection(conexion.CadenaSQL)
        Dim query As New StringBuilder

        query.Append("SELECT CVE_ALM AS 'ID', DESCR AS 'ALMACEN' ")
        query.Append("FROM SAE60Empre02.dbo.ALMACENES02 WHERE CVE_ALM NOT IN (4,5,6,7)")

        Dim micomando As New SqlCommand(query.ToString, actualizarconexion)
        actualizarconexion.Open()
        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable

        adaptador.Fill(dt)
        actualizarconexion.Close()
        Return dt
    End Function

    Public Function listar_productos(ByVal BUSCAR As String, ByVal PROVEEDOR As String) As DataTable
        Dim query As New StringBuilder
        Dim miconexion As New SqlConnection(conexion.CadenaSQL)
        query.Append("SELECT I.CVE_ART AS 'CODIGO PRODUCTO', I.DESCR AS 'PRODUCTO',  ")
        query.Append("I.FAC_CONV AS 'FACTOR CONVERSION', PN.PRECIO_NEG AS 'PRECIO NEGOCIADO', ISV.IMPUESTO4 AS ISV, I.UNI_MED, I.PESO, I.CON_LOTE ")
        query.Append("FROM SAE60EMPRE02.dbo.INVE02 I INNER JOIN nd_precios_negociados PN ON PN.CVE_ART = I.CVE_ART ")
        query.Append("COLLATE MODERN_SPANISH_CI_AS INNER JOIN SAE60Empre02.dbo.IMPU02 ISV ON I.CVE_ESQIMPU = ISV.CVE_ESQIMPU ")
        query.Append("INNER JOIN SAE60Empre02.dbo.PRVPROD02 PROV ON PROV.CVE_ART = I.CVE_ART FULL OUTER JOIN SAE60Empre02.dbo.INVE_CLIB02 CL ON ")
        query.Append("I.CVE_ART = CL.CVE_PROD ")
        query.Append("WHERE I.STATUS = 'A' AND (I.CVE_ART LIKE '%' + @BUSCAR + '%' OR I.DESCR LIKE '%' + UPPER(@BUSCAR) + '%' ")
        query.Append("OR CL.CAMPLIB1 LIKE '%' + UPPER(@BUSCAR) + '%')")
        Dim micomando As New SqlCommand(query.ToString, miconexion)
        miconexion.Open()
        micomando.Parameters.AddWithValue("@BUSCAR", BUSCAR)
        micomando.Parameters.AddWithValue("@PROVEEDOR", PROVEEDOR)
        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        miconexion.Close()
        Return dt
    End Function

    Public Function valida_productos(ByVal CODIGO As String, ByVal ALMACEN As String) As DataTable
        Dim query As New StringBuilder
        Dim miconexion As New SqlConnection(conexion.CadenaSQL)
        query.Append("SELECT COUNT(CVE_ART) ")
        query.Append("FROM SAE60Empre02.dbo.MULT02 ")
        query.Append("WHERE CVE_ART = @CODIGO AND CVE_ALM = @ALMACEN ")
        Dim micomando As New SqlCommand(query.ToString, miconexion)
        miconexion.Open()
        micomando.Parameters.AddWithValue("@CODIGO", CODIGO)
        micomando.Parameters.AddWithValue("@ALMACEN", ALMACEN)
        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        miconexion.Close()
        Return dt
    End Function

    Public Function folios()
        Dim miconexion As New SqlConnection(conexion.CadenaSQL)
        miconexion.Open()
        Dim query As New StringBuilder
        query.Append("SELECT FOLIO, NUM_ALMA, ULT_DOC + 1 AS ULT_DOC ")
        query.Append("FROM nd_folios ")
        query.Append("WHERE TIPO = 'P'")
        Dim command As New SqlCommand(query.ToString, miconexion)
        Dim adaptador_sql As New SqlDataAdapter(command)
        Dim dt As New DataTable
        adaptador_sql.Fill(dt)

        miconexion.Close()
        Return dt

    End Function

    Public Function valida_numreg(ByVal orden As String) As Boolean
        Dim query As New StringBuilder
        Dim con_sql As New SqlConnection(conexion.CadenaSQL)
        con_sql.Open()
        query.Append("SELECT CVE_COMPRA ")
        query.Append("FROM nd_orden_compra_e ")
        query.Append("WHERE     (CVE_COMPRA = @orden) ")
        Dim command As New SqlCommand(query.ToString, con_sql)
        command.Parameters.AddWithValue("@orden", orden)
        Dim dt As New DataTable
        Dim adap As New SqlDataAdapter(command)
        adap.Fill(dt)

        If dt.Rows.Count > 0 Then
            con_sql.Close()
            Return True
        Else
            con_sql.Close()
            Return False
        End If

    End Function

    Public Function actualiza_num_reg(ByVal FOLIO As String)
        Dim query_folios As New StringBuilder
        Dim con_sql As New SqlConnection(conexion.CadenaSQL)
        con_sql.Open()
        query_folios.Append("UPDATE [tactical_discount_sragro].[dbo].[nd_folios] ")
        query_folios.Append("SET [ULT_DOC] = ULT_DOC + 1 ")
        query_folios.Append("WHERE [FOLIO] = @FOLIO")
        Dim comando_folios As New SqlCommand(query_folios.ToString, con_sql)
        comando_folios.Parameters.AddWithValue("@FOLIO", FOLIO)
        comando_folios.ExecuteNonQuery()
        con_sql.Close()
        Return 0
    End Function

    Public Function lista_ordenes_pedidos(ByVal INICIO As Date, ByVal FIN As Date)
        Dim query As New StringBuilder
        Dim con_sql As New SqlConnection(conexion.CadenaSQL)
        con_sql.Open()
        query.Append("SELECT CVE_COMPRA 'Nº', CVE_PROVEEDOR AS CODIGO, PROVEEDOR, ALMACEN, RFC, ")
        query.Append("FECHA, ESTADO, TOTAL_MOST AS TOTAL ")
        query.Append("FROM nd_orden_compra_e ")
        query.Append("WHERE	FECHA BETWEEN @INICIO AND @FIN")

        Dim comando As New SqlCommand(query.ToString, con_sql)
        comando.Parameters.AddWithValue("@INICIO", INICIO)
        comando.Parameters.AddWithValue("@FIN", FIN)

        Dim dt As New DataTable
        Dim adaptador As New SqlDataAdapter(comando)
        adaptador.Fill(dt)
        con_sql.Close()
        Return dt
    End Function

    Public Function eliminar_orden(ByVal orden As String) As String
        Dim con_sql As New SqlConnection(conexion.CadenaSQL)
        Dim min_transaccion As SqlTransaction
        con_sql.Open()

        min_transaccion = con_sql.BeginTransaction

        Try
            Dim query_e As New StringBuilder
            query_e.Append("DELETE FROM [tactical_discount_sragro].[dbo].[nd_orden_pedido_e] ")
            query_e.Append("WHERE id_orden = @orden")
            Dim comando As New SqlCommand(query_e.ToString, con_sql)
            comando.Parameters.AddWithValue("@orden", orden)
            comando.Transaction = min_transaccion
            comando.ExecuteNonQuery()

            Dim query_p As New StringBuilder

            query_p.Append("DELETE FROM [tactical_discount_sragro].[dbo].[nd_orden_pedido_p] ")
            query_p.Append("WHERE id_orden = @orden")
            Dim comando2 As New SqlCommand(query_p.ToString, con_sql)
            comando2.Parameters.AddWithValue("@orden", orden)
            comando2.Transaction = min_transaccion
            comando2.ExecuteNonQuery()

            min_transaccion.Commit()
            con_sql.Close()
            Return "correcto"
        Catch ex As Exception
            min_transaccion.Rollback()
            con_sql.Close()
            Return ex.Message
        End Try
    End Function

    Public Function detalles_ordenpedido(ByVal id As String)
        Dim query As New StringBuilder
        Dim con_sql As New SqlConnection(conexion.CadenaSQL)
        con_sql.Open()
        query.Append("SELECT uni, codigo, producto, factor_conversion, cantidad, precio_negociado, ")
        query.Append("descuento_por, isv_por, sub_total, descuento, isv, total ")
        query.Append("FROM nd_orden_pedido_p ")
        query.Append("WHERE id_orden = @id")

        Dim comando As New SqlCommand(query.ToString, con_sql)
        comando.Parameters.AddWithValue("@id", id)

        Dim dt As New DataTable
        Dim adaptador As New SqlDataAdapter(comando)
        adaptador.Fill(dt)
        con_sql.Close()
        Return dt
    End Function

    Public Function update_orden_pedido(ByVal id_orden As String, ByVal fecha As DateTime, ByVal sub_total As Double, ByVal descuento As Double, _
                                        ByVal isv As Double, ByVal total As Double, ByVal dt_partidas As DataTable) As String
        Dim con_sql As New SqlConnection(conexion.CadenaSQL)
        Dim mi_transaccion As SqlTransaction
        con_sql.Open()
        mi_transaccion = con_sql.BeginTransaction
        Try
            Dim query_e As New StringBuilder


            query_e.Append("UPDATE [tactical_discount_sragro].[dbo].[nd_orden_pedido_e] ")
            query_e.Append("SET [fecha] = @fecha,[sub_total] = @sub_total,[descuento] = @descuento ")
            query_e.Append(",[isv] = @isv,[total] = @total ")
            query_e.Append("WHERE id_orden = @id_orden ")

            Dim comando_e As New SqlCommand(query_e.ToString, con_sql)
            comando_e.Parameters.AddWithValue("@fecha", fecha)
            comando_e.Parameters.AddWithValue("@sub_total", sub_total)
            comando_e.Parameters.AddWithValue("@descuento", descuento)
            comando_e.Parameters.AddWithValue("@isv", isv)
            comando_e.Parameters.AddWithValue("@total", total)
            comando_e.Parameters.AddWithValue("@id_orden", id_orden)
            comando_e.Transaction = mi_transaccion
            comando_e.ExecuteNonQuery()

            Dim query_p_Delete As New StringBuilder

            query_p_Delete.Append("DELETE FROM [tactical_discount_sragro].[dbo].[nd_orden_pedido_p] ")
            query_p_Delete.Append("WHERE id_orden = @orden")
            Dim comando2 As New SqlCommand(query_p_Delete.ToString, con_sql)
            comando2.Parameters.AddWithValue("@orden", id_orden)
            comando2.Transaction = mi_transaccion
            comando2.ExecuteNonQuery()

            For index As Integer = 0 To dt_partidas.Rows.Count - 1
                Dim query_p As New StringBuilder
                query_p.Append("INSERT INTO [tactical_discount_sragro].[dbo].[nd_orden_pedido_p] ")
                query_p.Append("([id_orden],[num_part],[uni],[codigo],[producto],[factor_conversion], ")
                query_p.Append("[cantidad],[precio_negociado],[descuento_por],[isv_por],[sub_total] ")
                query_p.Append(",[descuento],[isv],[total]) ")
                query_p.Append("VALUES ")
                query_p.Append("(@id_orden,@num_part,@uni,@codigo,@producto,@factor_conversion,@cantidad, ")
                query_p.Append("@precio_negociado,@descuento_por,@isv_por,@sub_total,@descuento, ")
                query_p.Append("@isv,@total) ")
                Dim comando_p As New SqlCommand(query_p.ToString, con_sql)
                comando_p.Parameters.AddWithValue("@id_orden", id_orden)
                comando_p.Parameters.AddWithValue("@num_part", index + 1)
                comando_p.Parameters.AddWithValue("@uni", dt_partidas.Rows(index)(0))
                comando_p.Parameters.AddWithValue("@codigo", dt_partidas.Rows(index)(1))
                comando_p.Parameters.AddWithValue("@producto", dt_partidas.Rows(index)(2))
                comando_p.Parameters.AddWithValue("@factor_conversion", dt_partidas.Rows(index)(3))
                comando_p.Parameters.AddWithValue("@cantidad", dt_partidas.Rows(index)(4))
                comando_p.Parameters.AddWithValue("@precio_negociado", dt_partidas.Rows(index)(5))
                comando_p.Parameters.AddWithValue("@descuento_por", dt_partidas.Rows(index)(6))
                comando_p.Parameters.AddWithValue("@isv_por", dt_partidas.Rows(index)(7))
                comando_p.Parameters.AddWithValue("@sub_total", dt_partidas.Rows(index)(8))
                comando_p.Parameters.AddWithValue("@descuento", dt_partidas.Rows(index)(9))
                comando_p.Parameters.AddWithValue("@isv", dt_partidas.Rows(index)(10))
                comando_p.Parameters.AddWithValue("@total", dt_partidas.Rows(index)(11))
                comando_p.Transaction = mi_transaccion
                comando_p.ExecuteNonQuery()
            Next

            mi_transaccion.Commit()
            con_sql.Close()
            Return "correcto"
        Catch ex As Exception
            mi_transaccion.Rollback()
            con_sql.Close()
            Return ex.Message
        End Try
    End Function

    Public Function listar_compras_locales(ByVal INICIO As Date, ByVal FIN As Date) As DataTable
        Dim con_sql As New SqlConnection(conexion.CadenaSQL)
        con_sql.Open()
        Dim query_lista As New StringBuilder
        query_lista.Append("SELECT CVE_COMPRA AS 'CODIGO LOCAL', CVE_PROVEEDOR AS 'CODIGO PROVEEDOR', ")
        query_lista.Append("PROVEEDOR, ALMACEN, REF_PROV AS 'REF. PROVEEDOR', RFC, FECHA, DESCUENTO_POR, ")
        query_lista.Append("CONVERT(VARCHAR,CONVERT(MONEY,SUB_TOTAL),1),CONVERT(VARCHAR,CONVERT(MONEY,DESCUENTO_VAL),1), ")
        query_lista.Append("CONVERT(VARCHAR,CONVERT(MONEY,ISV_VAL),1), CONVERT(VARCHAR,CONVERT(MONEY,TOTAL),1) AS TOTAL,  ")
        query_lista.Append("ESTADO, N_FACTURA_SAE AS 'CODIGO SAE', CONVERT(VARCHAR,CONVERT(MONEY,SUBTOTAL_MOST),1)  ")
        query_lista.Append(",CONVERT(VARCHAR,CONVERT(MONEY,DESC_MOST),1),CONVERT(VARCHAR,CONVERT(MONEY,ISV_MOST),1),CONVERT(VARCHAR,CONVERT(MONEY,TOTAL_MOST),1) ")
        query_lista.Append("FROM nd_compras_e ")
        query_lista.Append("WHERE (FECHA BETWEEN @INICIO AND @FIN) AND CVE_PROVEEDOR NOT IN ('        23','        24')")
        Dim comando As New SqlCommand(query_lista.ToString, con_sql)
        comando.Parameters.AddWithValue("@INICIO", INICIO)
        comando.Parameters.AddWithValue("@FIN", FIN)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        con_sql.Close()
        Return dt
    End Function

    Public Function listar_compras_locales_cargill(ByVal INICIO As Date, ByVal FIN As Date) As DataTable
        Dim con_sql As New SqlConnection(conexion.CadenaSQL)
        con_sql.Open()
        Dim query_lista As New StringBuilder
        query_lista.Append("SELECT CVE_COMPRA AS 'CODIGO LOCAL', CVE_PROVEEDOR AS 'CODIGO PROVEEDOR', ")
        query_lista.Append("PROVEEDOR, ALMACEN, REF_PROV AS 'REF. PROVEEDOR', RFC, FECHA, DESCUENTO_POR, ")
        query_lista.Append("SUB_TOTAL,DESCUENTO_VAL,ISV_VAL, TOTAL,ESTADO, N_FACTURA_SAE AS 'CODIGO SAE', ")
        query_lista.Append("SUBTOTAL_MOST,DESC_MOST,ISV_MOST,TOTAL_MOST,FLETE, ISNULL(ISV_FLETE,0) AS ISV_FLETE, ISNULL(TOT_FLETE,0) AS TOT_FLETE  ")
        query_lista.Append("FROM nd_compras_e ")
        query_lista.Append("WHERE (FECHA BETWEEN @INICIO AND @FIN)  AND CVE_PROVEEDOR IN ('        23','        24')")
        Dim comando As New SqlCommand(query_lista.ToString, con_sql)
        comando.Parameters.AddWithValue("@INICIO", INICIO)
        comando.Parameters.AddWithValue("@FIN", FIN)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        con_sql.Close()
        Return dt
    End Function

    Public Function listar_importaciones_locales(ByVal INICIO As Date, ByVal FIN As Date) As DataTable
        Dim con_sql As New SqlConnection(conexion.CadenaSQL)
        con_sql.Open()
        Dim query_lista As New StringBuilder
        query_lista.Append("SELECT CVE_COMPRA AS 'CODIGO LOCAL', CVE_PROVEEDOR AS 'CODIGO PROVEEDOR', ")
        query_lista.Append("PROVEEDOR, ALMACEN, REF_PROV AS 'REF. PROVEEDOR', RFC, FECHA, DESCUENTO_POR, ")
        query_lista.Append("CONVERT(VARCHAR,CONVERT(MONEY,SUB_TOTAL),1),CONVERT(VARCHAR,CONVERT(MONEY,DESCUENTO_VAL),1), ")
        query_lista.Append("CONVERT(VARCHAR,CONVERT(MONEY,ISV_VAL),1), CONVERT(VARCHAR,CONVERT(MONEY,TOTAL),1) AS TOTAL,  ")
        query_lista.Append("ESTADO, TASA_CAMBIO,N_FACTURA_SAE AS 'CODIGO SAE',FLETE,SEGURO,PYC,HONORARIOS ")
        query_lista.Append("FROM nd_importaciones_e ")
        query_lista.Append("WHERE (FECHA BETWEEN @INICIO AND @FIN)")
        Dim comando As New SqlCommand(query_lista.ToString, con_sql)
        comando.Parameters.AddWithValue("@INICIO", INICIO)
        comando.Parameters.AddWithValue("@FIN", FIN)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        con_sql.Close()
        Return dt
    End Function

    Public Function listar_ajuste(ByVal COMPRA As String, ByVal TIPO As String) As DataTable
        Dim con_sql As New SqlConnection(conexion.CadenaSQL)
        con_sql.Open()
        Dim query_lista As New StringBuilder

        'query_lista.Append("SELECT ID_AJUSTE, CVE_PROVEEDOR, ALMACEN, REF_PROV, ")
        'query_lista.Append("FECHA, N_FACTURA, SUBTOTAL, DESCUENTO, ISV, TOTAL, COMPRA ")
        'query_lista.Append("FROM nd_ajuste_e ")

        query_lista.Append("SELECT ID_AJUSTE, CVE_PROVEEDOR, ALMACEN, REF_PROV, FECHA, N_FACTURA, ")
        query_lista.Append("ROUND((CASE WHEN COMPRA LIKE 'I%' THEN SUBTOTAL*ISNULL((SELECT TASA_CAMBIO FROM nd_importaciones_e ")
        query_lista.Append("WHERE CVE_COMPRA = COMPRA),0) ELSE SUBTOTAL END),2) AS SUBTOTAL, ")
        query_lista.Append("ROUND((CASE WHEN COMPRA LIKE 'I%' THEN DESCUENTO*ISNULL((SELECT TASA_CAMBIO FROM nd_importaciones_e ")
        query_lista.Append("WHERE CVE_COMPRA = COMPRA),0) ELSE DESCUENTO END),2) AS DESCUENTO, ")
        query_lista.Append("ROUND((CASE WHEN COMPRA LIKE 'I%' THEN ISV*ISNULL((SELECT TASA_CAMBIO FROM nd_importaciones_e  ")
        query_lista.Append("WHERE CVE_COMPRA = COMPRA),0) ELSE ISV END),2) AS ISV, ")
        query_lista.Append("ROUND((CASE WHEN COMPRA LIKE 'I%' THEN TOTAL*ISNULL((SELECT TASA_CAMBIO FROM nd_importaciones_e ")
        query_lista.Append("WHERE CVE_COMPRA = COMPRA),0) ELSE TOTAL END),2) AS TOTAL, ")
        query_lista.Append("COMPRA ")
        query_lista.Append("FROM nd_ajuste_e ")
        query_lista.Append("WHERE (COMPRA = @COMPRA) AND TIPO = @TIPO ")
        Dim comando As New SqlCommand(query_lista.ToString, con_sql)
        comando.Parameters.AddWithValue("@COMPRA", COMPRA)
        comando.Parameters.AddWithValue("@TIPO", TIPO)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        con_sql.Close()
        Return dt
    End Function

    Public Function listar_ajuste_partidas(ByVal AJUSTE As String) As DataTable
        Dim con_sql As New SqlConnection(conexion.CadenaSQL)
        con_sql.Open()
        Dim query_lista As New StringBuilder
        'query_lista.Append("SELECT CVE_ART AS Clave, DESCRIPCION AS Descripcion, MOTIVO AS Motivo, CANTIDAD AS Cantidad, ")
        'query_lista.Append("FECHA_INGRESO AS 'Fecha de ingreso', COSTO_ANTERIOR AS 'Costo anterior', COSTO_ACTUAL AS 'Costo actual', AJUSTE AS 'Ajuste' ")
        'query_lista.Append("FROM nd_ajuste_p ")

        query_lista.Append("SELECT CVE_ART AS Clave, DESCRIPCION AS Descripcion, MOTIVO AS Motivo, CANTIDAD AS Cantidad,  ")
        query_lista.Append("FECHA_INGRESO AS 'Fecha',   ")
        query_lista.Append("ROUND((CASE WHEN COMPRA LIKE 'I%' THEN COSTO_ANTERIOR*ISNULL((SELECT TASA_CAMBIO FROM nd_importaciones_e  ")
        query_lista.Append("WHERE CVE_COMPRA = COMPRA),0) ELSE COSTO_ANTERIOR END),8) AS 'Anterior',  ")
        query_lista.Append("ROUND((CASE WHEN COMPRA LIKE 'I%' THEN COSTO_ACTUAL*ISNULL((SELECT TASA_CAMBIO FROM nd_importaciones_e  ")
        query_lista.Append("WHERE CVE_COMPRA = COMPRA),0) ELSE COSTO_ACTUAL END),8) AS 'Actual',  ")
        query_lista.Append("ROUND((CASE WHEN COMPRA LIKE 'I%' THEN AJUSTE*ISNULL((SELECT TASA_CAMBIO FROM nd_importaciones_e  ")
        query_lista.Append("WHERE CVE_COMPRA = COMPRA),0) ELSE AJUSTE END),2) AS 'Ajuste' ")
        query_lista.Append("FROM nd_ajuste_p INNER JOIN nd_ajuste_e ON nd_ajuste_e.ID_AJUSTE = nd_ajuste_p.ID_AJUSTE ")
        query_lista.Append("WHERE nd_ajuste_p.ID_AJUSTE = @AJUSTE ")
        Dim comando As New SqlCommand(query_lista.ToString, con_sql)
        comando.Parameters.AddWithValue("@AJUSTE", AJUSTE)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        con_sql.Close()
        Return dt
    End Function

    Public Function eliminar_compra(ByVal COMPRA As String) As String
        Dim con_sql As New SqlConnection(conexion.CadenaSQL)
        Dim mitransaccion As SqlTransaction
        con_sql.Open()
        mitransaccion = con_sql.BeginTransaction

        Try
            Dim query_e As New StringBuilder
            Dim query_p As New StringBuilder

            query_e.Append("DELETE FROM [tactical_discount_sragro].[dbo].[nd_compras_e] ")
            query_e.Append("WHERE CVE_COMPRA = @CVE_COMPRA ")

            query_p.Append("DELETE FROM [tactical_discount_sragro].[dbo].[nd_compras_p] ")
            query_p.Append("WHERE CVE_COMPRA = @CVE_COMPRA")

            Dim comando_e As New SqlCommand(query_e.ToString, con_sql)
            comando_e.Parameters.AddWithValue("@CVE_COMPRA", COMPRA)
            comando_e.Transaction = mitransaccion
            comando_e.ExecuteNonQuery()

            Dim comando_p As New SqlCommand(query_p.ToString, con_sql)
            comando_p.Parameters.AddWithValue("@CVE_COMPRA", COMPRA)
            comando_p.Transaction = mitransaccion
            comando_p.ExecuteNonQuery()

            mitransaccion.Commit()
            con_sql.Close()
            Return "correcto"
        Catch ex As Exception
            mitransaccion.Rollback()
            con_sql.Close()
            Return ex.Message
        End Try
    End Function

    Public Function eliminar_importacion(ByVal COMPRA As String) As String
        Dim con_sql As New SqlConnection(conexion.CadenaSQL)
        Dim mitransaccion As SqlTransaction
        con_sql.Open()
        mitransaccion = con_sql.BeginTransaction

        Try
            Dim query_e As New StringBuilder
            Dim query_p As New StringBuilder

            query_e.Append("DELETE FROM [tactical_discount_sragro].[dbo].[nd_importaciones_e] ")
            query_e.Append("WHERE CVE_COMPRA = @CVE_COMPRA ")

            query_p.Append("DELETE FROM [tactical_discount_sragro].[dbo].[nd_importaciones_p] ")
            query_p.Append("WHERE CVE_COMPRA = @CVE_COMPRA")

            Dim comando_e As New SqlCommand(query_e.ToString, con_sql)
            comando_e.Parameters.AddWithValue("@CVE_COMPRA", COMPRA)
            comando_e.Transaction = mitransaccion
            comando_e.ExecuteNonQuery()

            Dim comando_p As New SqlCommand(query_p.ToString, con_sql)
            comando_p.Parameters.AddWithValue("@CVE_COMPRA", COMPRA)
            comando_p.Transaction = mitransaccion
            comando_p.ExecuteNonQuery()

            mitransaccion.Commit()
            con_sql.Close()
            Return "correcto"
        Catch ex As Exception
            mitransaccion.Rollback()
            con_sql.Close()
            Return ex.Message
        End Try
    End Function

    Public Function listar_tasa_cambio() As DataTable
        Dim con_sql As New SqlConnection(conexion.CadenaSQL)
        con_sql.Open()
        Dim query_lista As New StringBuilder
        query_lista.Append("SELECT Tasa ")
        query_lista.Append("FROM nd_tasa_cambio ")
        query_lista.Append("WHERE (Pertenece = 'Importaciones')")
        Dim comando As New SqlCommand(query_lista.ToString, con_sql)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        con_sql.Close()
        Return dt
    End Function

    Public Function modificar_importacion_local(ByVal dt_e As DataTable, ByVal dt_p As DataTable, ByVal CVE_COMPRA As String _
                                                , ByVal agente As String) As String
        Dim con_sql As New SqlConnection(conexion.CadenaSQL)
        Dim mi_transaccion As SqlTransaction
        con_sql.Open()
        mi_transaccion = con_sql.BeginTransaction

        Try
            Dim query_e_local As New StringBuilder
            query_e_local.Append("UPDATE [tactical_discount_sragro].[dbo].[nd_importaciones_e] ")
            query_e_local.Append("SET [REF_PROV] = @REF_PROV,[FECHA] = @FECHA, ")
            query_e_local.Append("[DESCUENTO_POR] = @DESCUENTO_POR,[SUB_TOTAL] = @SUB_TOTAL, ")
            query_e_local.Append("[DESCUENTO_VAL] = @DESCUENTO_VAL,[ISV_VAL] = @ISV_VAL ")
            query_e_local.Append(",[TOTAL] = @TOTAL, [FLETE] = @FLETE, [SEGURO] = @SEGURO ")
            query_e_local.Append(",[PYC] = @PYC, [HONORARIOS] = @HONORARIOS, [AGENTE] = @AGENTE, [FECHA_FACTURA] = @FECHA_FACTURA ")
            query_e_local.Append("WHERE CVE_COMPRA = @CVE_COMPRA")
            Dim comando_e_local As New SqlCommand(query_e_local.ToString, con_sql)
            comando_e_local.Parameters.AddWithValue("@CVE_COMPRA", CVE_COMPRA)
            comando_e_local.Parameters.AddWithValue("@REF_PROV", dt_e.Rows(0)(3))
            comando_e_local.Parameters.AddWithValue("@FECHA", Convert.ToDateTime(dt_e.Rows(0)(5)))
            comando_e_local.Parameters.AddWithValue("@DESCUENTO_POR", dt_e.Rows(0)(6))
            comando_e_local.Parameters.AddWithValue("@SUB_TOTAL", dt_e.Rows(0)(7))
            comando_e_local.Parameters.AddWithValue("@DESCUENTO_VAL", dt_e.Rows(0)(8))
            comando_e_local.Parameters.AddWithValue("@ISV_VAL", dt_e.Rows(0)(9))
            comando_e_local.Parameters.AddWithValue("@TOTAL", dt_e.Rows(0)(10))
            comando_e_local.Parameters.AddWithValue("@FLETE", dt_e.Rows(0)(14))
            comando_e_local.Parameters.AddWithValue("@SEGURO", dt_e.Rows(0)(15))
            comando_e_local.Parameters.AddWithValue("@PYC", dt_e.Rows(0)(16))
            comando_e_local.Parameters.AddWithValue("@HONORARIOS", dt_e.Rows(0)(17))
            comando_e_local.Parameters.AddWithValue("@AGENTE", agente)
            comando_e_local.Parameters.AddWithValue("@FECHA_FACTURA", Convert.ToDateTime(dt_e.Rows(0)(18)))
            comando_e_local.Transaction = mi_transaccion
            comando_e_local.ExecuteNonQuery()

            Dim query_e_local2 As New StringBuilder
            query_e_local2.Append("DELETE FROM [tactical_discount_sragro].[dbo].[nd_importaciones_p] ")
            query_e_local2.Append("WHERE CVE_COMPRA = @CVE_COMPRA")
            Dim comando_e_local2 As New SqlCommand(query_e_local2.ToString, con_sql)
            comando_e_local2.Parameters.AddWithValue("@CVE_COMPRA", CVE_COMPRA)
            comando_e_local2.Transaction = mi_transaccion
            comando_e_local2.ExecuteNonQuery()

            For index As Integer = 0 To dt_p.Rows.Count - 1
                Dim query_p_local As New StringBuilder
                query_p_local.Append("INSERT INTO [tactical_discount_sragro].[dbo].[nd_importaciones_p] ")
                query_p_local.Append("([CVE_COMPRA],[NUM_PART],[UNI],[CVE_ART],[PRODUCTO] ")
                query_p_local.Append(",[FACT_CONV],[CANTIDAD],[PRECIO_NEG],[PRECIO_FINAL],[PRECIO_NETO] ")
                query_p_local.Append(",[DESC_PROD],[ISV_PROD],[SUB_TOTAL],[DESCUENTO] ")
                query_p_local.Append(",[ISV],[TOTAL_PARTIDA],[PRECIO_INSERTAR],[AJUSTE],[HONORARIOS],[FLETE],[SEGURO],[PYC],[CON_LOTE]) ")
                query_p_local.Append("VALUES ")
                query_p_local.Append("(@CVE_COMPRA,@NUM_PART,@UNI,@CVE_ART,@PRODUCTO, ")
                query_p_local.Append("@FACT_CONV,@CANTIDAD,@PRECIO_NEG,@PRECIO_FINAL,@PRECIO_NETO, ")
                query_p_local.Append("@DESC_PROD,@ISV_PROD,@SUB_TOTAL,@DESCUENTO, ")
                query_p_local.Append("@ISV,@TOTAL_PARTIDA,@PRECIO_INSERTAR,@AJUSTE,@HONORARIOS,@FLETE,@SEGURO,@PYC,@CON_LOTE) ")
                Dim comando_p_local As New SqlCommand(query_p_local.ToString, con_sql)

                comando_p_local.Parameters.AddWithValue("@CVE_COMPRA", CVE_COMPRA)
                comando_p_local.Parameters.AddWithValue("@NUM_PART", index + 1)
                comando_p_local.Parameters.AddWithValue("@UNI", dt_p.Rows(index)(0))
                comando_p_local.Parameters.AddWithValue("@CVE_ART", dt_p.Rows(index)(1))
                comando_p_local.Parameters.AddWithValue("@PRODUCTO", dt_p.Rows(index)(2))
                comando_p_local.Parameters.AddWithValue("@FACT_CONV", dt_p.Rows(index)(3))
                comando_p_local.Parameters.AddWithValue("@CANTIDAD", Convert.ToDouble(dt_p.Rows(index)(4)))
                comando_p_local.Parameters.AddWithValue("@PRECIO_NEG", dt_p.Rows(index)(5))
                comando_p_local.Parameters.AddWithValue("@PRECIO_FINAL", dt_p.Rows(index)(6))
                comando_p_local.Parameters.AddWithValue("@PRECIO_NETO", dt_p.Rows(index)(7))
                comando_p_local.Parameters.AddWithValue("@DESC_PROD", dt_p.Rows(index)(8))
                comando_p_local.Parameters.AddWithValue("@ISV_PROD", dt_p.Rows(index)(9))
                comando_p_local.Parameters.AddWithValue("@SUB_TOTAL", Convert.ToDouble(dt_p.Rows(index)(10)))
                comando_p_local.Parameters.AddWithValue("@DESCUENTO", Convert.ToDouble(dt_p.Rows(index)(11)))
                comando_p_local.Parameters.AddWithValue("@ISV", Convert.ToDouble(dt_p.Rows(index)(12)))
                comando_p_local.Parameters.AddWithValue("@TOTAL_PARTIDA", Convert.ToDouble(dt_p.Rows(index)(13)))
                comando_p_local.Parameters.AddWithValue("@PRECIO_INSERTAR", dt_p.Rows(index)(14))
                comando_p_local.Parameters.AddWithValue("@AJUSTE", dt_p.Rows(index)(15))
                comando_p_local.Parameters.AddWithValue("@HONORARIOS", dt_p.Rows(index)(16))
                comando_p_local.Parameters.AddWithValue("@FLETE", dt_p.Rows(index)(17))
                comando_p_local.Parameters.AddWithValue("@SEGURO", dt_p.Rows(index)(18))
                comando_p_local.Parameters.AddWithValue("@PYC", dt_p.Rows(index)(19))
                comando_p_local.Parameters.AddWithValue("@CON_LOTE", dt_p.Rows(index)(20))
                comando_p_local.Transaction = mi_transaccion
                comando_p_local.ExecuteNonQuery()
            Next

            Dim query_upd_codigo As New StringBuilder
            query_upd_codigo.Append("UPDATE [tactical_discount_sragro].[dbo].[nd_folios] ")
            query_upd_codigo.Append("SET [ULT_DOC] = ULT_DOC + 1 ")
            query_upd_codigo.Append("WHERE ([NUM_ALMA] = @NUM_ALMA And [TIPO] = 'I') ")
            Dim comando_upd_codigo As New SqlCommand(query_upd_codigo.ToString, con_sql)
            comando_upd_codigo.Parameters.AddWithValue("@NUM_ALMA", dt_e.Rows(0)(2))
            comando_upd_codigo.Transaction = mi_transaccion
            comando_upd_codigo.ExecuteNonQuery()

            mi_transaccion.Commit()
            con_sql.Close()
            Return "correcto"
        Catch ex As Exception
            mi_transaccion.Rollback()
            con_sql.Close()
            Return ex.Message
        End Try
    End Function

    Public Function modificar_compras_local(ByVal dt_e As DataTable, ByVal dt_p As DataTable, ByVal CVE_COMPRA As String) As String
        Dim con_sql As New SqlConnection(conexion.CadenaSQL)
        Dim mi_transaccion As SqlTransaction
        con_sql.Open()
        mi_transaccion = con_sql.BeginTransaction

        Try
            Dim query_e_local As New StringBuilder
            query_e_local.Append("UPDATE [tactical_discount_sragro].[dbo].[nd_compras_e] ")
            query_e_local.Append("SET [REF_PROV] = @REF_PROV,[FECHA] = @FECHA ")
            query_e_local.Append(",[DESCUENTO_POR] = @DESCUENTO_POR,[SUB_TOTAL] = @SUB_TOTAL ")
            query_e_local.Append(",[DESCUENTO_VAL] = @DESCUENTO_VAL,[ISV_VAL] = @ISV_VAL ")
            query_e_local.Append(",[TOTAL] = @TOTAL,[ESTADO] = @ESTADO ")
            query_e_local.Append(",[SUBTOTAL_MOST] = @SUBTOTAL_MOST,[DESC_MOST] = @DESC_MOST ")
            query_e_local.Append(",[ISV_MOST] = @ISV_MOST,[TOTAL_MOST] = @TOTAL_MOST, [FECHA_FACTURA] = @FECHA_FACTURA ")
            query_e_local.Append("WHERE([CVE_COMPRA] = @CVE_COMPRA)")

            Dim comando_e_local As New SqlCommand(query_e_local.ToString, con_sql)
            comando_e_local.Parameters.AddWithValue("@CVE_COMPRA", CVE_COMPRA)
            comando_e_local.Parameters.AddWithValue("@REF_PROV", dt_e.Rows(0)(3))
            comando_e_local.Parameters.AddWithValue("@FECHA", Convert.ToDateTime(dt_e.Rows(0)(5)))
            comando_e_local.Parameters.AddWithValue("@DESCUENTO_POR", dt_e.Rows(0)(6))
            comando_e_local.Parameters.AddWithValue("@SUB_TOTAL", dt_e.Rows(0)(7))
            comando_e_local.Parameters.AddWithValue("@DESCUENTO_VAL", dt_e.Rows(0)(8))
            comando_e_local.Parameters.AddWithValue("@ISV_VAL", dt_e.Rows(0)(9))
            comando_e_local.Parameters.AddWithValue("@TOTAL", dt_e.Rows(0)(10))
            comando_e_local.Parameters.AddWithValue("@ESTADO", dt_e.Rows(0)(11))
            comando_e_local.Parameters.AddWithValue("@SUBTOTAL_MOST", dt_e.Rows(0)(12))
            comando_e_local.Parameters.AddWithValue("@DESC_MOST", dt_e.Rows(0)(13))
            comando_e_local.Parameters.AddWithValue("@ISV_MOST", dt_e.Rows(0)(14))
            comando_e_local.Parameters.AddWithValue("@TOTAL_MOST", dt_e.Rows(0)(15))
            comando_e_local.Parameters.AddWithValue("@FECHA_FACTURA", Convert.ToDateTime(dt_e.Rows(0)(16)))
            comando_e_local.Transaction = mi_transaccion
            comando_e_local.ExecuteNonQuery()

            Dim query_e_local2 As New StringBuilder
            query_e_local2.Append("DELETE FROM [tactical_discount_sragro].[dbo].[nd_compras_p] ")
            query_e_local2.Append("WHERE CVE_COMPRA = @CVE_COMPRA")
            Dim comando_e_local2 As New SqlCommand(query_e_local2.ToString, con_sql)
            comando_e_local2.Parameters.AddWithValue("@CVE_COMPRA", CVE_COMPRA)
            comando_e_local2.Transaction = mi_transaccion
            comando_e_local2.ExecuteNonQuery()

            For index As Integer = 0 To dt_p.Rows.Count - 1
                Dim query_p_local As New StringBuilder
                query_p_local.Append("INSERT INTO [tactical_discount_sragro].[dbo].[nd_compras_p] ")
                query_p_local.Append("([CVE_COMPRA],[NUM_PART],[UNI],[CVE_ART],[PRODUCTO] ")
                query_p_local.Append(",[FACT_CONV],[CANTIDAD],[PRECIO_NEG],[PRECIO_FINAL] ")
                query_p_local.Append(",[DESC_PROD],[ISV_PROD],[SUB_TOTAL],[DESCUENTO] ")
                query_p_local.Append(",[ISV],[TOTAL_PARTIDA],[PRECIO_INSERTAR],[AJUSTE], ")
                query_p_local.Append(" [SUBTOTAL_MOST],[DESC_MOST],[ISV_MOST],[TOTAL_MOST],[CON_LOTE]) ")
                query_p_local.Append("VALUES ")
                query_p_local.Append("(@CVE_COMPRA,@NUM_PART,@UNI,@CVE_ART,@PRODUCTO, ")
                query_p_local.Append("@FACT_CONV,@CANTIDAD,@PRECIO_NEG,@PRECIO_FINAL, ")
                query_p_local.Append("@DESC_PROD,@ISV_PROD,@SUB_TOTAL,@DESCUENTO, ")
                query_p_local.Append("@ISV,@TOTAL_PARTIDA,@PRECIO_INSERTAR,@AJUSTE, ")
                query_p_local.Append("@SUBTOTAL_MOST,@DESC_MOST,@ISV_MOST,@TOTAL_MOST,@CON_LOTE ) ")
                Dim comando_p_local As New SqlCommand(query_p_local.ToString, con_sql)

                comando_p_local.Parameters.AddWithValue("@CVE_COMPRA", CVE_COMPRA)
                comando_p_local.Parameters.AddWithValue("@NUM_PART", index + 1)
                comando_p_local.Parameters.AddWithValue("@UNI", dt_p.Rows(index)(0))
                comando_p_local.Parameters.AddWithValue("@CVE_ART", dt_p.Rows(index)(1))
                comando_p_local.Parameters.AddWithValue("@PRODUCTO", dt_p.Rows(index)(2))
                comando_p_local.Parameters.AddWithValue("@FACT_CONV", dt_p.Rows(index)(3))
                comando_p_local.Parameters.AddWithValue("@CANTIDAD", Convert.ToDouble(dt_p.Rows(index)(4)))
                comando_p_local.Parameters.AddWithValue("@PRECIO_NEG", dt_p.Rows(index)(5))
                comando_p_local.Parameters.AddWithValue("@PRECIO_FINAL", dt_p.Rows(index)(6))
                comando_p_local.Parameters.AddWithValue("@DESC_PROD", dt_p.Rows(index)(7))
                comando_p_local.Parameters.AddWithValue("@ISV_PROD", dt_p.Rows(index)(8))
                comando_p_local.Parameters.AddWithValue("@SUB_TOTAL", Convert.ToDouble(dt_p.Rows(index)(9)))
                comando_p_local.Parameters.AddWithValue("@DESCUENTO", Convert.ToDouble(dt_p.Rows(index)(10)))
                comando_p_local.Parameters.AddWithValue("@ISV", Convert.ToDouble(dt_p.Rows(index)(11)))
                comando_p_local.Parameters.AddWithValue("@TOTAL_PARTIDA", Convert.ToDouble(dt_p.Rows(index)(12)))
                comando_p_local.Parameters.AddWithValue("@PRECIO_INSERTAR", dt_p.Rows(index)(13))
                comando_p_local.Parameters.AddWithValue("@AJUSTE", dt_p.Rows(index)(14))
                comando_p_local.Parameters.AddWithValue("@SUBTOTAL_MOST", dt_p.Rows(index)(16))
                comando_p_local.Parameters.AddWithValue("@DESC_MOST", dt_p.Rows(index)(17))
                comando_p_local.Parameters.AddWithValue("@ISV_MOST", dt_p.Rows(index)(18))
                comando_p_local.Parameters.AddWithValue("@TOTAL_MOST", dt_p.Rows(index)(19))
                comando_p_local.Parameters.AddWithValue("@CON_LOTE", dt_p.Rows(index)(20))
                comando_p_local.Transaction = mi_transaccion
                comando_p_local.ExecuteNonQuery()
            Next
            mi_transaccion.Commit()
            con_sql.Close()
            Return "correcto"
        Catch ex As Exception
            mi_transaccion.Rollback()
            con_sql.Close()
            Return ex.Message
        End Try
    End Function

    Public Function listar_partidas_compras(ByVal CVE_COMPRA As String) As DataTable
        Dim con_sql As New SqlConnection(conexion.CadenaSQL)
        con_sql.Open()
        Dim query As New StringBuilder
        query.Append("SELECT UNI, CVE_ART, PRODUCTO, ")
        query.Append("FACT_CONV, CANTIDAD, PRECIO_NEG, PRECIO_FINAL, ")
        query.Append("DESC_PROD, ISV_PROD, SUB_TOTAL, DESCUENTO, ISV, ")
        query.Append("TOTAL_PARTIDA, PRECIO_INSERTAR, AJUSTE,ISNULL(SUBTOTAL_MOST,0),ISNULL(DESC_MOST,0),ISNULL(ISV_MOST,0),ISNULL(TOTAL_MOST,0),ISNULL(PRECIO_NETO,0),ISNULL(PESO,0), ISNULL(CON_LOTE,'S'), ISNULL(PORC_PP,0), ISNULL(DESCUENTO_PP,0), ISNULL(DESCUENTO_PP_MOSTR,0)  ")
        query.Append("FROM nd_compras_p ")
        query.Append("WHERE CVE_COMPRA = @CVE_COMPRA")
        Dim comando As New SqlCommand(query.ToString, con_sql)
        comando.Parameters.AddWithValue("@CVE_COMPRA", CVE_COMPRA)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        con_sql.Close()
        Return dt
    End Function

    Public Function listar_partidas_importaciones(ByVal CVE_COMPRA As String) As DataTable
        Dim con_sql As New SqlConnection(conexion.CadenaSQL)
        con_sql.Open()
        Dim query As New StringBuilder
        query.Append("SELECT UNI, CVE_ART, PRODUCTO, FACT_CONV, CANTIDAD, ")
        query.Append("PRECIO_NEG, PRECIO_FINAL, PRECIO_NETO, DESC_PROD, ISV_PROD, ")
        query.Append("SUB_TOTAL, DESCUENTO, ISV, TOTAL_PARTIDA, PRECIO_INSERTAR, AJUSTE,HONORARIOS,FLETE,SEGURO,PYC, ISNULL(CON_LOTE,'S') ")
        query.Append("FROM nd_importaciones_p ")
        query.Append("WHERE CVE_COMPRA = @CVE_COMPRA")
        Dim comando As New SqlCommand(query.ToString, con_sql)
        comando.Parameters.AddWithValue("@CVE_COMPRA", CVE_COMPRA)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        con_sql.Close()
        Return dt
    End Function

    Public Function guardar_compras_local_envio_SAE(ByVal dt_e As DataTable, ByVal dt_p As DataTable, _
                                                    ByVal conlote As String, ByVal lote As String, ByVal usuario As String) As String
        Dim sql_con As New SqlConnection(conexion.CadenaSQL)
        Dim mi_transaccion As SqlTransaction
        sql_con.Open()
        mi_transaccion = sql_con.BeginTransaction

        Try
            Dim query_codigo As New StringBuilder
            query_codigo.Append("SELECT FOLIO + CONVERT(VARCHAR, ULT_DOC + 1) AS CLAVE,FOLIO ")
            query_codigo.Append("FROM nd_folios ")
            query_codigo.Append("WHERE (NUM_ALMA = @ALMACEN) AND (TIPO = 'C')")
            Dim comando_codigo As New SqlCommand(query_codigo.ToString, sql_con)
            comando_codigo.Parameters.AddWithValue("@ALMACEN", dt_e.Rows(0)(2))
            comando_codigo.Transaction = mi_transaccion
            Dim dt As New DataTable
            Dim adaptador_codigo As New SqlDataAdapter(comando_codigo)
            adaptador_codigo.Fill(dt)
            Dim CVE_COMPRA As String = ""
            CVE_COMPRA = dt.Rows(0)(0)
            Dim serie_local As String = ""
            serie_local = dt.Rows(0)(1)

            Dim query_cve_docto As New StringBuilder
            query_cve_docto.Append("SELECT SERIE, ULT_DOC ")
            query_cve_docto.Append("FROM SAE60EMPRE02.dbo.FOLIOSC02 ")
            query_cve_docto.Append("WHERE (TIP_DOC = 'c') AND (SERIE = @SERIE) ")
            Dim comando_cve_docto As New SqlCommand(query_cve_docto.ToString, sql_con)
            comando_cve_docto.Parameters.AddWithValue("@SERIE", serie_local)
            comando_cve_docto.Transaction = mi_transaccion
            Dim adaptador_cve_docto As New SqlDataAdapter(comando_cve_docto)
            Dim dt_cve_docto As New DataTable
            adaptador_cve_docto.Fill(dt_cve_docto)
            Dim CVE_DOC As String = ""
            Dim serie As String = ""
            Dim folio As Integer
            serie = dt_cve_docto.Rows(0)(0)
            folio = dt_cve_docto.Rows(0)(1) + 1
            CVE_DOC = serie & folio

            Dim query_e_local As New StringBuilder
            query_e_local.Append("INSERT INTO [tactical_discount_sragro].[dbo].[nd_compras_e] ")
            query_e_local.Append("       ([CVE_COMPRA],[CVE_PROVEEDOR],[PROVEEDOR],[ALMACEN] ")
            query_e_local.Append("       ,[REF_PROV],[RFC],[FECHA],[DESCUENTO_POR],[SUB_TOTAL] ")
            query_e_local.Append("       ,[DESCUENTO_VAL],[ISV_VAL],[TOTAL],[ESTADO],[N_FACTURA_SAE], ")
            query_e_local.Append("        [SUBTOTAL_MOST],[DESC_MOST],[ISV_MOST],[TOTAL_MOST],[FECHA_FACTURA]) ")
            query_e_local.Append(" VALUES ")
            query_e_local.Append("       (@CVE_COMPRA,@CVE_PROVEEDOR,@PROVEEDOR,@ALMACEN ")
            query_e_local.Append("       ,@REF_PROV,@RFC,@FECHA,@DESCUENTO_POR,@SUB_TOTAL ")
            query_e_local.Append("       ,@DESCUENTO_VAL,@ISV_VAL,@TOTAL,@ESTADO,@N_FACTURA_SAE, ")
            query_e_local.Append("       @SUBTOTAL_MOST,@DESC_MOST,@ISV_MOST,@TOTAL_MOST,@FECHA_FACTURA)")
            Dim comando_e_local As New SqlCommand(query_e_local.ToString, sql_con)
            comando_e_local.Parameters.AddWithValue("@CVE_COMPRA", CVE_COMPRA)
            comando_e_local.Parameters.AddWithValue("@CVE_PROVEEDOR", dt_e.Rows(0)(0))
            comando_e_local.Parameters.AddWithValue("@PROVEEDOR", dt_e.Rows(0)(1))
            comando_e_local.Parameters.AddWithValue("@ALMACEN ", dt_e.Rows(0)(2))
            comando_e_local.Parameters.AddWithValue("@REF_PROV", dt_e.Rows(0)(3))
            comando_e_local.Parameters.AddWithValue("@RFC", dt_e.Rows(0)(4))
            comando_e_local.Parameters.AddWithValue("@FECHA", Convert.ToDateTime(dt_e.Rows(0)(5)))
            comando_e_local.Parameters.AddWithValue("@DESCUENTO_POR", dt_e.Rows(0)(6))
            comando_e_local.Parameters.AddWithValue("@SUB_TOTAL", dt_e.Rows(0)(7))
            comando_e_local.Parameters.AddWithValue("@DESCUENTO_VAL", dt_e.Rows(0)(8))
            comando_e_local.Parameters.AddWithValue("@ISV_VAL", dt_e.Rows(0)(9))
            comando_e_local.Parameters.AddWithValue("@TOTAL", dt_e.Rows(0)(10))
            comando_e_local.Parameters.AddWithValue("@ESTADO", "ENVIADA")
            comando_e_local.Parameters.AddWithValue("@N_FACTURA_SAE", CVE_DOC)
            comando_e_local.Parameters.AddWithValue("@SUBTOTAL_MOST", dt_e.Rows(0)(12))
            comando_e_local.Parameters.AddWithValue("@DESC_MOST", dt_e.Rows(0)(13))
            comando_e_local.Parameters.AddWithValue("@ISV_MOST", dt_e.Rows(0)(14))
            comando_e_local.Parameters.AddWithValue("@TOTAL_MOST", dt_e.Rows(0)(15))
            comando_e_local.Parameters.AddWithValue("@FECHA_FACTURA", Convert.ToDateTime(dt_e.Rows(0)(16)))
            comando_e_local.Transaction = mi_transaccion
            comando_e_local.ExecuteNonQuery()

            For index As Integer = 0 To dt_p.Rows.Count - 1
                Dim query_p_local As New StringBuilder
                query_p_local.Append("INSERT INTO [tactical_discount_sragro].[dbo].[nd_compras_p] ")
                query_p_local.Append("([CVE_COMPRA],[NUM_PART],[UNI],[CVE_ART],[PRODUCTO] ")
                query_p_local.Append(",[FACT_CONV],[CANTIDAD],[PRECIO_NEG],[PRECIO_FINAL] ")
                query_p_local.Append(",[DESC_PROD],[ISV_PROD],[SUB_TOTAL],[DESCUENTO] ")
                query_p_local.Append(",[ISV],[TOTAL_PARTIDA],[PRECIO_INSERTAR],[AJUSTE], ")
                query_p_local.Append("[SUBTOTAL_MOST],[DESC_MOST],[ISV_MOST],[TOTAL_MOST],[CON_LOTE]) ")
                query_p_local.Append("VALUES ")
                query_p_local.Append("(@CVE_COMPRA,@NUM_PART,@UNI,@CVE_ART,@PRODUCTO, ")
                query_p_local.Append("@FACT_CONV,@CANTIDAD,@PRECIO_NEG,@PRECIO_FINAL, ")
                query_p_local.Append("@DESC_PROD,@ISV_PROD,@SUB_TOTAL,@DESCUENTO, ")
                query_p_local.Append("@ISV,@TOTAL_PARTIDA,@PRECIO_INSERTAR,@AJUSTE, ")
                query_p_local.Append(" @SUBTOTAL_MOST, @DESC_MOST,@ISV_MOST,@TOTAL_MOST,@CON_LOTE) ")
                Dim comando_p_local As New SqlCommand(query_p_local.ToString, sql_con)

                comando_p_local.Parameters.AddWithValue("@CVE_COMPRA", CVE_COMPRA)
                comando_p_local.Parameters.AddWithValue("@NUM_PART", index + 1)
                comando_p_local.Parameters.AddWithValue("@UNI", dt_p.Rows(index)(0))
                comando_p_local.Parameters.AddWithValue("@CVE_ART", dt_p.Rows(index)(1))
                comando_p_local.Parameters.AddWithValue("@PRODUCTO", dt_p.Rows(index)(2))
                comando_p_local.Parameters.AddWithValue("@FACT_CONV", dt_p.Rows(index)(3))
                comando_p_local.Parameters.AddWithValue("@CANTIDAD", Convert.ToDouble(dt_p.Rows(index)(4)))
                comando_p_local.Parameters.AddWithValue("@PRECIO_NEG", dt_p.Rows(index)(5))
                comando_p_local.Parameters.AddWithValue("@PRECIO_FINAL", dt_p.Rows(index)(6))
                comando_p_local.Parameters.AddWithValue("@DESC_PROD", dt_p.Rows(index)(7))
                comando_p_local.Parameters.AddWithValue("@ISV_PROD", dt_p.Rows(index)(8))
                comando_p_local.Parameters.AddWithValue("@SUB_TOTAL", Convert.ToDouble(dt_p.Rows(index)(9)))
                comando_p_local.Parameters.AddWithValue("@DESCUENTO", Convert.ToDouble(dt_p.Rows(index)(10)))
                comando_p_local.Parameters.AddWithValue("@ISV", Convert.ToDouble(dt_p.Rows(index)(11)))
                comando_p_local.Parameters.AddWithValue("@TOTAL_PARTIDA", Convert.ToDouble(dt_p.Rows(index)(12)))
                comando_p_local.Parameters.AddWithValue("@PRECIO_INSERTAR", dt_p.Rows(index)(13))
                comando_p_local.Parameters.AddWithValue("@AJUSTE", dt_p.Rows(index)(14))
                comando_p_local.Parameters.AddWithValue("@SUBTOTAL_MOST", dt_p.Rows(index)(16))
                comando_p_local.Parameters.AddWithValue("@DESC_MOST", dt_p.Rows(index)(17))
                comando_p_local.Parameters.AddWithValue("@ISV_MOST", dt_p.Rows(index)(18))
                comando_p_local.Parameters.AddWithValue("@TOTAL_MOST", dt_p.Rows(index)(19))
                comando_p_local.Parameters.AddWithValue("@CON_LOTE", dt_p.Rows(index)(20))

                comando_p_local.Transaction = mi_transaccion
                comando_p_local.ExecuteNonQuery()
            Next

            Dim query_upd_codigo As New StringBuilder
            query_upd_codigo.Append("UPDATE [tactical_discount_sragro].[dbo].[nd_folios] ")
            query_upd_codigo.Append("SET [ULT_DOC] = ULT_DOC + 1 ")
            query_upd_codigo.Append("WHERE ([NUM_ALMA] = @NUM_ALMA And [TIPO] = 'C') ")
            Dim comando_upd_codigo As New SqlCommand(query_upd_codigo.ToString, sql_con)
            comando_upd_codigo.Parameters.AddWithValue("@NUM_ALMA", dt_e.Rows(0)(2))
            comando_upd_codigo.Transaction = mi_transaccion
            comando_upd_codigo.ExecuteNonQuery()

            'fin de las compras locales

            Dim ajuste As String = ""
            Dim debito As String = ""
            For index As Integer = 0 To dt_p.Rows.Count - 1
                If dt_p.Rows(index)(14) = "S" Then
                    ajuste = "S"
                End If

                If dt_p.Rows(index)(14) = "D" Then
                    debito = "D"
                End If
            Next

            ' registra los debito por producto
            If ajuste = "S" Then
                Dim query_folio_ajuste As New StringBuilder
                query_folio_ajuste.Append("SELECT FOLIO + CONVERT(VARCHAR, ULT_DOC + 1) AS ULT_DOC ")
                query_folio_ajuste.Append("FROM nd_folios ")
                query_folio_ajuste.Append("WHERE (TIPO = 'A') AND (NUM_ALMA = @ALMACEN)")
                Dim comando_folio_ajuste As New SqlCommand(query_folio_ajuste.ToString, sql_con)
                comando_folio_ajuste.Parameters.AddWithValue("@ALMACEN", dt_e.Rows(0)(2))
                comando_folio_ajuste.Transaction = mi_transaccion
                Dim dt_folio_ajuste As New DataTable
                Dim adaptador_folio_ajuste As New SqlDataAdapter(comando_folio_ajuste)
                adaptador_folio_ajuste.Fill(dt_folio_ajuste)

                Dim subtotal_ajuste_e As Double = 0, isv_ajuste_e As Double = 0, total_ajueste_e As Double = 0, descuento_ajuste_e As Double = 0
                For index As Integer = 0 To dt_p.Rows.Count - 1
                    If dt_p.Rows(index)(14) = "S" Then
                        Dim query_ajuste_p As New StringBuilder
                        query_ajuste_p.Append("INSERT INTO [tactical_discount_sragro].[dbo].[nd_ajuste_p] ")
                        query_ajuste_p.Append("([ID_AJUSTE],[NUM_PART],[CVE_ART],[DESCRIPCION],[MOTIVO],[CANTIDAD], ")
                        query_ajuste_p.Append("[FECHA_INGRESO],[COSTO_ANTERIOR],[COSTO_ACTUAL],[AJUSTE],[UNI]) ")
                        query_ajuste_p.Append("VALUES ")
                        query_ajuste_p.Append("(@ID_AJUSTE,@NUM_PART,@CVE_ART,@DESCRIPCION,@MOTIVO,@CANTIDAD, ")
                        query_ajuste_p.Append("@FECHA_INGRESO,@COSTO_ANTERIOR,@COSTO_ACTUAL,@AJUSTE,@UNI)")
                        Dim comando_ajuste_p As New SqlCommand(query_ajuste_p.ToString, sql_con)
                        comando_ajuste_p.Parameters.AddWithValue("@ID_AJUSTE", dt_folio_ajuste.Rows(0)(0))
                        comando_ajuste_p.Parameters.AddWithValue("@NUM_PART", index + 1)
                        comando_ajuste_p.Parameters.AddWithValue("@CVE_ART", dt_p.Rows(index)(1))
                        comando_ajuste_p.Parameters.AddWithValue("@DESCRIPCION", dt_p.Rows(index)(2))
                        comando_ajuste_p.Parameters.AddWithValue("@MOTIVO", "AJUSTE DE PRECIO")
                        comando_ajuste_p.Parameters.AddWithValue("@CANTIDAD", dt_p.Rows(index)(4))
                        comando_ajuste_p.Parameters.AddWithValue("@FECHA_INGRESO", Convert.ToDateTime(dt_e.Rows(0)(5)))
                        comando_ajuste_p.Parameters.AddWithValue("@COSTO_ANTERIOR", dt_p.Rows(index)(5))
                        comando_ajuste_p.Parameters.AddWithValue("@COSTO_ACTUAL", dt_p.Rows(index)(6))
                        Dim valor_ajuste As Double = 0

                        valor_ajuste = (Convert.ToDouble(dt_p.Rows(index)(4)) * Convert.ToDouble(dt_p.Rows(index)(6))) - (Convert.ToDouble(dt_p.Rows(index)(4)) * Convert.ToDouble(dt_p.Rows(index)(5)))
                        If dt_p.Rows(index)(0) = "cj" Then
                            valor_ajuste = valor_ajuste * Convert.ToDouble(dt_p.Rows(index)(3))
                        End If

                        comando_ajuste_p.Parameters.AddWithValue("@AJUSTE", valor_ajuste * -1)
                        comando_ajuste_p.Parameters.AddWithValue("@UNI", dt_p.Rows(index)(0))

                        subtotal_ajuste_e += valor_ajuste
                        descuento_ajuste_e += 0 'valor_ajuste * dt_p.Rows(index)(7) / 100
                        valor_ajuste = valor_ajuste - descuento_ajuste_e
                        isv_ajuste_e += valor_ajuste * dt_p.Rows(index)(8) / 100
                        comando_ajuste_p.Transaction = mi_transaccion
                        comando_ajuste_p.ExecuteNonQuery()
                    End If
                Next
                total_ajueste_e += subtotal_ajuste_e - descuento_ajuste_e + isv_ajuste_e

                Dim query_ajuste_e As New StringBuilder
                query_ajuste_e.Append("INSERT INTO [tactical_discount_sragro].[dbo].[nd_ajuste_e] ")
                query_ajuste_e.Append("([ID_AJUSTE],[CVE_PROVEEDOR],[ALMACEN],[REF_PROV]")
                query_ajuste_e.Append(",[FECHA],[N_FACTURA],[SUBTOTAL],[DESCUENTO],[ISV],[TOTAL],[COMPRA],[TIPO]) ")
                query_ajuste_e.Append("VALUES ")
                query_ajuste_e.Append("(@ID_AJUSTE,@CVE_PROVEEDOR,@ALMACEN,@REF_PROV,@FECHA, ")
                query_ajuste_e.Append("@N_FACTURA,@SUBTOTAL,@DESCUENTO,@ISV,@TOTAL,@COMPRA,@TIPO)")
                Dim comando_ajuste_e As New SqlCommand(query_ajuste_e.ToString, sql_con)
                comando_ajuste_e.Parameters.AddWithValue("@ID_AJUSTE", dt_folio_ajuste.Rows(0)(0))
                comando_ajuste_e.Parameters.AddWithValue("@CVE_PROVEEDOR", dt_e.Rows(0)(0))
                comando_ajuste_e.Parameters.AddWithValue("@ALMACEN", dt_e.Rows(0)(2))
                comando_ajuste_e.Parameters.AddWithValue("@REF_PROV", dt_e.Rows(0)(3))
                comando_ajuste_e.Parameters.AddWithValue("@FECHA", Convert.ToDateTime(dt_e.Rows(0)(5)))
                comando_ajuste_e.Parameters.AddWithValue("@N_FACTURA", CVE_DOC)
                comando_ajuste_e.Parameters.AddWithValue("@SUBTOTAL", subtotal_ajuste_e * -1)
                comando_ajuste_e.Parameters.AddWithValue("@DESCUENTO", 0) 'descuento_ajuste_e * -1)
                comando_ajuste_e.Parameters.AddWithValue("@ISV", isv_ajuste_e * -1)
                comando_ajuste_e.Parameters.AddWithValue("@TOTAL", total_ajueste_e * -1)
                comando_ajuste_e.Parameters.AddWithValue("@COMPRA", CVE_COMPRA)
                comando_ajuste_e.Parameters.AddWithValue("@TIPO", "DEBITO")
                comando_ajuste_e.Transaction = mi_transaccion
                comando_ajuste_e.ExecuteNonQuery()

                Dim query_upd_folio_ajuste As New StringBuilder
                query_upd_folio_ajuste.Append("UPDATE [tactical_discount_sragro].[dbo].[nd_folios] ")
                query_upd_folio_ajuste.Append("   SET [ULT_DOC] = ULT_DOC+1 ")
                query_upd_folio_ajuste.Append("WHERE [NUM_ALMA] = @NUM_ALMA AND TIPO = 'A' ")
                Dim comando_upd_folio_ajuste As New SqlCommand(query_upd_folio_ajuste.ToString, sql_con)
                comando_upd_folio_ajuste.Parameters.AddWithValue("@NUM_ALMA", dt_e.Rows(0)(2))
                comando_upd_folio_ajuste.Transaction = mi_transaccion
                comando_upd_folio_ajuste.ExecuteNonQuery()

            End If
            ' fn registra los debitos por producto

            Dim query_dias_cred As New StringBuilder
            query_dias_cred.Append("Select ISNULL(DIASCRED,0) ")
            query_dias_cred.Append("FROM SAE60EMPRE02.dbo.PROV02 ")
            query_dias_cred.Append("WHERE (CLAVE = @CLAVE) ")
            Dim comando_dias_cred As New SqlCommand(query_dias_cred.ToString, sql_con)
            comando_dias_cred.Parameters.AddWithValue("@CLAVE", dt_e.Rows(0)(0))
            comando_dias_cred.Transaction = mi_transaccion
            Dim adaptador_dias_cred As New SqlDataAdapter(comando_dias_cred)
            Dim dt_dias_cred As New DataTable
            adaptador_dias_cred.Fill(dt_dias_cred)
            Dim dias_cred As Integer = 0
            dias_cred = dt_dias_cred.Rows(0)(0)

            ' registra los creditos por producto
            If debito = "D" Then
                Dim query_folio_debito As New StringBuilder
                query_folio_debito.Append("SELECT FOLIO + CONVERT(VARCHAR, ULT_DOC + 1) AS ULT_DOC ")
                query_folio_debito.Append("FROM nd_folios ")
                query_folio_debito.Append("WHERE (TIPO = 'D') AND (NUM_ALMA = @ALMACEN)")
                Dim comando_folio_debito As New SqlCommand(query_folio_debito.ToString, sql_con)
                comando_folio_debito.Parameters.AddWithValue("@ALMACEN", dt_e.Rows(0)(2))
                comando_folio_debito.Transaction = mi_transaccion
                Dim dt_folio_debito As New DataTable
                Dim adaptador_folio_debito As New SqlDataAdapter(comando_folio_debito)
                adaptador_folio_debito.Fill(dt_folio_debito)

                Dim subtotal_debito_e As Double = 0, isv_debito_e As Double = 0, total_debito_e As Double = 0, descuento_debito_e As Double = 0
                For index As Integer = 0 To dt_p.Rows.Count - 1
                    If dt_p.Rows(index)(14) = "D" Then
                        Dim query_debito_p As New StringBuilder
                        query_debito_p.Append("INSERT INTO [tactical_discount_sragro].[dbo].[nd_ajuste_p] ")
                        query_debito_p.Append("([ID_AJUSTE],[NUM_PART],[CVE_ART],[DESCRIPCION],[MOTIVO],[CANTIDAD], ")
                        query_debito_p.Append("[FECHA_INGRESO],[COSTO_ANTERIOR],[COSTO_ACTUAL],[AJUSTE],[UNI]) ")
                        query_debito_p.Append("VALUES ")
                        query_debito_p.Append("(@ID_AJUSTE,@NUM_PART,@CVE_ART,@DESCRIPCION,@MOTIVO,@CANTIDAD, ")
                        query_debito_p.Append("@FECHA_INGRESO,@COSTO_ANTERIOR,@COSTO_ACTUAL,@AJUSTE,@UNI)")
                        Dim comando_debito_p As New SqlCommand(query_debito_p.ToString, sql_con)
                        comando_debito_p.Parameters.AddWithValue("@ID_AJUSTE", dt_folio_debito.Rows(0)(0))
                        comando_debito_p.Parameters.AddWithValue("@NUM_PART", index + 1)
                        comando_debito_p.Parameters.AddWithValue("@CVE_ART", dt_p.Rows(index)(1))
                        comando_debito_p.Parameters.AddWithValue("@DESCRIPCION", dt_p.Rows(index)(2))
                        comando_debito_p.Parameters.AddWithValue("@MOTIVO", "AJUSTE DE PRECIO")
                        comando_debito_p.Parameters.AddWithValue("@CANTIDAD", dt_p.Rows(index)(4))
                        comando_debito_p.Parameters.AddWithValue("@FECHA_INGRESO", Convert.ToDateTime(dt_e.Rows(0)(5)))
                        comando_debito_p.Parameters.AddWithValue("@COSTO_ANTERIOR", dt_p.Rows(index)(5))
                        comando_debito_p.Parameters.AddWithValue("@COSTO_ACTUAL", dt_p.Rows(index)(6))
                        Dim valor_ajuste As Double = 0
                        valor_ajuste = (Convert.ToDouble(dt_p.Rows(index)(4)) * Convert.ToDouble(dt_p.Rows(index)(6))) - (Convert.ToDouble(dt_p.Rows(index)(4)) * Convert.ToDouble(dt_p.Rows(index)(5)))
                        If dt_p.Rows(index)(0) = "cj" Then
                            valor_ajuste = valor_ajuste * Convert.ToDouble(dt_p.Rows(index)(3))
                        End If
                        comando_debito_p.Parameters.AddWithValue("@AJUSTE", Math.Abs(valor_ajuste))
                        comando_debito_p.Parameters.AddWithValue("@UNI", dt_p.Rows(index)(0))

                        subtotal_debito_e += valor_ajuste
                        descuento_debito_e += 0 'valor_ajuste * dt_p.Rows(index)(7) / 100
                        valor_ajuste = valor_ajuste - descuento_debito_e
                        isv_debito_e += valor_ajuste * dt_p.Rows(index)(8) / 100
                        comando_debito_p.Transaction = mi_transaccion
                        comando_debito_p.ExecuteNonQuery()
                    End If
                Next
                total_debito_e += subtotal_debito_e - descuento_debito_e + isv_debito_e

                Dim query_debito_e As New StringBuilder
                query_debito_e.Append("INSERT INTO [tactical_discount_sragro].[dbo].[nd_ajuste_e] ")
                query_debito_e.Append("([ID_AJUSTE],[CVE_PROVEEDOR],[ALMACEN],[REF_PROV]")
                query_debito_e.Append(",[FECHA],[N_FACTURA],[SUBTOTAL],[DESCUENTO],[ISV],[TOTAL],[COMPRA],[TIPO]) ")
                query_debito_e.Append("VALUES ")
                query_debito_e.Append("(@ID_AJUSTE,@CVE_PROVEEDOR,@ALMACEN,@REF_PROV,@FECHA, ")
                query_debito_e.Append("@N_FACTURA,@SUBTOTAL,@DESCUENTO,@ISV,@TOTAL,@COMPRA,@TIPO)")
                Dim comando_debito_e As New SqlCommand(query_debito_e.ToString, sql_con)
                comando_debito_e.Parameters.AddWithValue("@ID_AJUSTE", dt_folio_debito.Rows(0)(0))
                comando_debito_e.Parameters.AddWithValue("@CVE_PROVEEDOR", dt_e.Rows(0)(0))
                comando_debito_e.Parameters.AddWithValue("@ALMACEN", dt_e.Rows(0)(2))
                comando_debito_e.Parameters.AddWithValue("@REF_PROV", dt_e.Rows(0)(3))
                comando_debito_e.Parameters.AddWithValue("@FECHA", Convert.ToDateTime(dt_e.Rows(0)(5)))
                comando_debito_e.Parameters.AddWithValue("@N_FACTURA", CVE_DOC)
                comando_debito_e.Parameters.AddWithValue("@SUBTOTAL", Math.Abs(subtotal_debito_e))
                comando_debito_e.Parameters.AddWithValue("@DESCUENTO", 0) 'Math.Abs(descuento_debito_e))
                comando_debito_e.Parameters.AddWithValue("@ISV", Math.Abs(isv_debito_e))
                comando_debito_e.Parameters.AddWithValue("@TOTAL", Math.Abs(total_debito_e))
                comando_debito_e.Parameters.AddWithValue("@COMPRA", CVE_COMPRA)
                comando_debito_e.Parameters.AddWithValue("@TIPO", "CREDITO")
                comando_debito_e.Transaction = mi_transaccion
                comando_debito_e.ExecuteNonQuery()

                Dim query_upd_folio_ajuste As New StringBuilder
                query_upd_folio_ajuste.Append("UPDATE [tactical_discount_sragro].[dbo].[nd_folios] ")
                query_upd_folio_ajuste.Append("   SET [ULT_DOC] = ULT_DOC+1 ")
                query_upd_folio_ajuste.Append("WHERE [NUM_ALMA] = @NUM_ALMA AND TIPO = 'D' ")
                Dim comando_upd_folio_ajuste As New SqlCommand(query_upd_folio_ajuste.ToString, sql_con)
                comando_upd_folio_ajuste.Parameters.AddWithValue("@NUM_ALMA", dt_e.Rows(0)(2))
                comando_upd_folio_ajuste.Transaction = mi_transaccion
                comando_upd_folio_ajuste.ExecuteNonQuery()

                Dim query_opaga As New StringBuilder
                query_opaga.Append("INSERT INTO [SAE60Empre02].[dbo].[OPAGA02] ")
                query_opaga.Append("([CVE_OBS],[STR_OBS]) ")
                query_opaga.Append("VALUES ((SELECT ULT_CVE + 1 AS ULT_CVE FROM SAE60EMPRE02.dbo.TBLCONTROL02 WHERE (ID_TABLA = 21)),'NOTA DE CREDITO POR PRECIO MENOR DEL PROVEEDOR')")
                Dim comando_opaga As New SqlCommand(query_opaga.ToString, sql_con)
                comando_opaga.Transaction = mi_transaccion
                comando_opaga.ExecuteNonQuery()

                Dim query_paga_det As New StringBuilder
                query_paga_det.Append("INSERT INTO [SAE60Empre02].[dbo].[PAGA_DET02] ")
                query_paga_det.Append("([CVE_PROV],[REFER],[NUM_CPTO],[NUM_CARGO],[ID_MOV] ")
                query_paga_det.Append(",[CVE_OBS],[NO_FACTURA],[DOCTO],[IMPORTE],[FECHA_APLI],[FECHA_VENC] ")
                query_paga_det.Append(",[NUM_MONED],[TCAMBIO],[IMPMON_EXT],[FECHAELAB] ")
                query_paga_det.Append(",[TIPO_MOV],[SIGNO],[USUARIO] ")
                query_paga_det.Append(",[NO_PARTIDA]) ")
                query_paga_det.Append("VALUES ")
                query_paga_det.Append("(@CVE_PROV, @REFER, 29,1,1, (SELECT ULT_CVE + 1 AS ULT_CVE FROM SAE60EMPRE02.dbo.TBLCONTROL02 WHERE (ID_TABLA = 21)), ")
                query_paga_det.Append("@NO_FACTURA, @DOCTO, @IMPORTE, @FECHA_APLI, @FECHA_VENC, 1, ")
                query_paga_det.Append("1, @IMPMON_EXT, @FECHAELAB,'A', -1,0, 1) ")
                Dim comando_paga_det As New SqlCommand(query_paga_det.ToString, sql_con)
                comando_paga_det.Parameters.AddWithValue("@CVE_PROV", dt_e.Rows(0)(0))
                comando_paga_det.Parameters.AddWithValue("@REFER", CVE_DOC)
                comando_paga_det.Parameters.AddWithValue("@NO_FACTURA", CVE_DOC)
                comando_paga_det.Parameters.AddWithValue("@DOCTO", CVE_DOC)
                comando_paga_det.Parameters.AddWithValue("@IMPORTE", Math.Abs(total_debito_e))
                comando_paga_det.Parameters.AddWithValue("@FECHA_APLI", Convert.ToDateTime(dt_e.Rows(0)(5)))
                comando_paga_det.Parameters.AddWithValue("@FECHA_VENC", Convert.ToDateTime(dt_e.Rows(0)(5)).AddDays(dias_cred))
                comando_paga_det.Parameters.AddWithValue("@IMPMON_EXT", Math.Abs(total_debito_e))
                comando_paga_det.Parameters.AddWithValue("@FECHAELAB", Convert.ToDateTime(dt_e.Rows(0)(5)))
                comando_paga_det.Transaction = mi_transaccion
                comando_paga_det.ExecuteNonQuery()

                Dim query_upd_paga_det As New StringBuilder
                query_upd_paga_det.Append("UPDATE [SAE60Empre02].[dbo].[TBLCONTROL02] ")
                query_upd_paga_det.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                query_upd_paga_det.Append("WHERE ([ID_TABLA] = 21)")
                Dim comando_upd_paga_det As New SqlCommand(query_upd_paga_det.ToString, sql_con)
                comando_upd_paga_det.Transaction = mi_transaccion
                comando_upd_paga_det.ExecuteNonQuery()
            End If
            ' fin registra los creditos por producto

            'registrar envio a SAE

            Dim query_compc As New StringBuilder
            query_compc.Append("INSERT INTO [SAE60Empre02].[dbo].[COMPC02] ")
            query_compc.Append("([TIP_DOC],[CVE_DOC],[CVE_CLPV],[STATUS],[SU_REFER] ")
            query_compc.Append(",[FECHA_DOC],[FECHA_REC],[FECHA_PAG] ")
            query_compc.Append(",[CAN_TOT],[IMP_TOT1],[IMP_TOT2],[IMP_TOT3],[IMP_TOT4] ")
            query_compc.Append(",[DES_TOT],[DES_FIN],[TOT_IND],[OBS_COND],[CVE_OBS] ")
            query_compc.Append(",[NUM_ALMA],[ACT_CXP],[ACT_COI],[ENLAZADO],[TIP_DOC_E] ")
            query_compc.Append(",[NUM_MONED],[TIPCAMB],[NUM_PAGOS],[FECHAELAB] ")
            query_compc.Append(",[SERIE],[FOLIO],[CTLPOL],[ESCFD],[CONTADO],[BLOQ] ")
            query_compc.Append(",[DES_FIN_PORC],[DES_TOT_PORC],[IMPORTE],[TIP_DOC_ANT],[DOC_ANT]) ")
            query_compc.Append("VALUES ")
            query_compc.Append("('c', @CVE_DOC,@CVE_CLPV,'O',@SU_REFER,@FECHA_DOC ")
            query_compc.Append(",@FECHA_REC,@FECHA_PAG,@CAN_TOT,0,0,0,@IMP_TOT4,@DES_TOT,0,0 ")
            query_compc.Append(",'',0,@NUM_ALMA,'S','N','O','O',1,1,1,@FECHAELAB ")
            query_compc.Append(",@SERIE,@FOLIO,0,'N','N','N',0 ,@DES_TOT_PORC,@IMPORTE,'','' )")
            Dim comando_compc As New SqlCommand(query_compc.ToString, sql_con)
            comando_compc.Parameters.AddWithValue("@CVE_DOC", CVE_DOC)
            comando_compc.Parameters.AddWithValue("@CVE_CLPV", dt_e.Rows(0)(0))
            comando_compc.Parameters.AddWithValue("@SU_REFER", dt_e.Rows(0)(3))
            comando_compc.Parameters.AddWithValue("@FECHA_DOC", Convert.ToDateTime(dt_e.Rows(0)(5)))
            comando_compc.Parameters.AddWithValue("@FECHA_REC", Convert.ToDateTime(dt_e.Rows(0)(5)))
            comando_compc.Parameters.AddWithValue("@FECHA_PAG", Convert.ToDateTime(dt_e.Rows(0)(5)).AddDays(dias_cred)) 'Agregar dias de credito
            comando_compc.Parameters.AddWithValue("@CAN_TOT", dt_e.Rows(0)(7))
            comando_compc.Parameters.AddWithValue("@IMP_TOT4", dt_e.Rows(0)(9))
            comando_compc.Parameters.AddWithValue("@DES_TOT", dt_e.Rows(0)(8))
            comando_compc.Parameters.AddWithValue("@NUM_ALMA", dt_e.Rows(0)(2))
            comando_compc.Parameters.AddWithValue("@FECHAELAB", Now.Date)
            comando_compc.Parameters.AddWithValue("@SERIE", serie)
            comando_compc.Parameters.AddWithValue("@FOLIO", folio)
            comando_compc.Parameters.AddWithValue("@DES_TOT_PORC", dt_e.Rows(0)(6))
            comando_compc.Parameters.AddWithValue("@IMPORTE", dt_e.Rows(0)(10))
            comando_compc.Transaction = mi_transaccion
            comando_compc.ExecuteNonQuery()

            Dim query_compc_clib As New StringBuilder
            query_compc_clib.Append("INSERT INTO [SAE60Empre02].[dbo].[COMPC_CLIB02] ")
            query_compc_clib.Append(" ([CLAVE_DOC],[CAMPLIB1]) ")
            query_compc_clib.Append("VALUES (@CLAVE_DOC,@CAMPLIB1)")
            Dim comando_comp_clib As New SqlCommand(query_compc_clib.ToString, sql_con)
            comando_comp_clib.Parameters.AddWithValue("CLAVE_DOC", CVE_DOC)
            comando_comp_clib.Parameters.AddWithValue("@CAMPLIB1", Convert.ToDateTime(dt_e.Rows(0)(16)))
            comando_comp_clib.Transaction = mi_transaccion
            comando_comp_clib.ExecuteNonQuery()

            'inicio del for

            For index As Integer = 0 To dt_p.Rows.Count - 1
                Dim query_correlativo_lote As New StringBuilder
                query_correlativo_lote.Append("SELECT (ULT_CVE + 1) AS ULT_CVE ")
                query_correlativo_lote.Append("FROM SAE60EMPRE02.dbo.TBLCONTROL02 ")
                query_correlativo_lote.Append("WHERE (ID_TABLA = 67) ")
                Dim comando_correlativo_lote As New SqlCommand(query_correlativo_lote.ToString, sql_con)
                comando_correlativo_lote.Transaction = mi_transaccion
                Dim adaptador_correlativo_lote As New SqlDataAdapter(comando_correlativo_lote)
                Dim dt_correlativo_lote As New DataTable
                adaptador_correlativo_lote.Fill(dt_correlativo_lote)
                Dim correlativo_lote As Integer
                correlativo_lote = dt_correlativo_lote.Rows(0)(0)

                Dim query_par_compc As New StringBuilder
                query_par_compc.Append("INSERT INTO [SAE60Empre02].[dbo].[PAR_COMPC02] ")
                query_par_compc.Append("   ([CVE_DOC],[NUM_PAR],[CVE_ART],[CANT],[PXR],[PREC],[COST] ")
                query_par_compc.Append("   ,[IMPU1],[IMPU2],[IMPU3],[IMPU4],[IMP1APLA],[IMP2APLA],[IMP3APLA] ")
                query_par_compc.Append("   ,[IMP4APLA],[TOTIMP1],[TOTIMP2],[TOTIMP3],[TOTIMP4],[DESCU],[ACT_INV] ")
                query_par_compc.Append("   ,[TIP_CAM],[UNI_VENTA],[TIPO_ELEM],[TIPO_PROD],[CVE_OBS],[REG_SERIE] ")
                query_par_compc.Append("   ,[E_LTPD],[FACTCONV],[COST_DEV],[NUM_ALM],[MINDIRECTO],[NUM_MOV],[TOT_PARTIDA]) ")
                query_par_compc.Append("VALUES ")
                query_par_compc.Append("  (@CVE_DOC,@NUM_PAR,@CVE_ART, @CANT, @PXR, ISNULL((SELECT SAE60Empre02.dbo.PRECIO_X_PROD02.PRECIO ")
                query_par_compc.Append("FROM SAE60Empre02.dbo.INVE02 INNER JOIN SAE60Empre02.dbo.PRECIO_X_PROD02 ON ")
                query_par_compc.Append("SAE60Empre02.dbo.INVE02.CVE_ART = SAE60Empre02.dbo.PRECIO_X_PROD02.CVE_ART ")
                query_par_compc.Append("WHERE (SAE60Empre02.dbo.PRECIO_X_PROD02.CVE_PRECIO = 1) AND (SAE60Empre02.dbo.INVE02.CVE_ART = @CVE_ART)),0), @COST, 0, 0, 0, ")
                query_par_compc.Append("   @IMPU4, 0, 0, 0, 0, 0, 0, ")
                query_par_compc.Append("   0, @TOTIMP4, @DESCU, 'S', 1, @UNI_VENTA, 'N', ")
                query_par_compc.Append("   'P', 0,0,@E_LTPD,@FACTCONV, @COST_DEV, @NUM_ALM, ")
                query_par_compc.Append("   0, (SELECT ULT_CVE + 1 FROM SAE60EMPRE02.dbo.TBLCONTROL02 WHERE (ID_TABLA = 44)),@TOT_PARTIDA)")

                Dim comando_par_compc As New SqlCommand(query_par_compc.ToString, sql_con)
                comando_par_compc.Parameters.AddWithValue("@CVE_DOC", CVE_DOC)
                comando_par_compc.Parameters.AddWithValue("@NUM_PAR", index + 1)
                comando_par_compc.Parameters.AddWithValue("@CVE_ART", dt_p.Rows(index)(1))
                comando_par_compc.Parameters.AddWithValue("@CANT", Convert.ToDouble(dt_p.Rows(index)(4)))

                Dim cant_insertar As Double = 0
                Dim costo_insertar As Double = 0
                Dim factor_conversion As Integer = 0
                If dt_p.Rows(index)(0) = "cj" Then
                    cant_insertar = Convert.ToDouble(dt_p.Rows(index)(4)) * dt_p.Rows(index)(3)
                    costo_insertar = dt_p.Rows(index)(13) * dt_p.Rows(index)(3)
                    factor_conversion = dt_p.Rows(index)(3)
                ElseIf dt_p.Rows(index)(0) = "pz" Then
                    cant_insertar = Convert.ToDouble(dt_p.Rows(index)(4))
                    costo_insertar = dt_p.Rows(index)(13)
                    factor_conversion = 1
                End If

                comando_par_compc.Parameters.AddWithValue("@PXR", cant_insertar)
                comando_par_compc.Parameters.AddWithValue("@COST", costo_insertar)
                comando_par_compc.Parameters.AddWithValue("@IMPU4", dt_p.Rows(index)(8))
                comando_par_compc.Parameters.AddWithValue("@TOTIMP4", Convert.ToDouble(dt_p.Rows(index)(11)))
                comando_par_compc.Parameters.AddWithValue("@DESCU", 0) 'dt_p.Rows(index)(7))
                comando_par_compc.Parameters.AddWithValue("@UNI_VENTA", dt_p.Rows(index)(0))

                If dt_p.Rows(index)(20) = "S" Then
                    comando_par_compc.Parameters.AddWithValue("@E_LTPD", correlativo_lote)
                Else
                    comando_par_compc.Parameters.AddWithValue("@E_LTPD", 0)
                End If

                comando_par_compc.Parameters.AddWithValue("@FACTCONV", factor_conversion)
                comando_par_compc.Parameters.AddWithValue("@COST_DEV", dt_p.Rows(index)(13) * dt_p.Rows(index)(3))
                comando_par_compc.Parameters.AddWithValue("@NUM_ALM", dt_e.Rows(0)(2))
                comando_par_compc.Parameters.AddWithValue("@TOT_PARTIDA", Convert.ToDouble(dt_p.Rows(index)(12)) - Convert.ToDouble(dt_p.Rows(index)(11)))
                comando_par_compc.Transaction = mi_transaccion
                comando_par_compc.ExecuteNonQuery()

                Dim query_par_comp_clib As New StringBuilder
                query_par_comp_clib.Append("INSERT INTO [SAE60Empre02].[dbo].[PAR_COMPC_CLIB02] ")
                query_par_comp_clib.Append("   ([CLAVE_DOC],[NUM_PART]) ")
                query_par_comp_clib.Append("VALUES ")
                query_par_comp_clib.Append("   (@CLAVE_DOC,@NUM_PART) ")
                Dim comando_par_comp_clib As New SqlCommand(query_par_comp_clib.ToString, sql_con)
                comando_par_comp_clib.Parameters.AddWithValue("@CLAVE_DOC", CVE_DOC)
                comando_par_comp_clib.Parameters.AddWithValue("@NUM_PART", index + 1)
                comando_par_comp_clib.Transaction = mi_transaccion
                comando_par_comp_clib.ExecuteNonQuery()

                Dim query_costo_prom As New StringBuilder
                query_costo_prom.Append("SELECT ISNULL(EXIST,0),ISNULL(COSTO_PROM,0) FROM SAE60EMPRE02.dbo.INVE02 WHERE CVE_ART = @CVE_ART")
                Dim comando_costo_prom As New SqlCommand(query_costo_prom.ToString, sql_con)
                comando_costo_prom.Parameters.AddWithValue("@CVE_ART", dt_p.Rows(index)(1))
                comando_costo_prom.Transaction = mi_transaccion
                Dim adaptador_costo As New SqlDataAdapter(comando_costo_prom)
                Dim dt_costo_prom As New DataTable
                Dim existencias_viejas As Double = 0, costo_prom_viejo As Double = 0
                adaptador_costo.Fill(dt_costo_prom)
                existencias_viejas = dt_costo_prom.Rows(0)(0)
                costo_prom_viejo = dt_costo_prom.Rows(0)(1)

                Dim costo_prom_nuevo As Double = 0
                costo_prom_nuevo = ((existencias_viejas * costo_prom_viejo) + (cant_insertar * dt_p.Rows(index)(13))) / (existencias_viejas + cant_insertar)

                Dim query_upd_inve As New StringBuilder
                query_upd_inve.Append("UPDATE SAE60EMPRE02.dbo.INVE02 ")
                query_upd_inve.Append("SET [EXIST] = (EXIST + @NUEVA_EXISTENCIA), ")
                query_upd_inve.Append("FCH_ULTCOM = @FECHA_ULTCOM, COSTO_PROM = @COSTO_PROM, ULT_COSTO = @ULT_COSTO ")
                query_upd_inve.Append("WHERE [CVE_ART] = @CVE_ART ")
                Dim comando_upd_inve As New SqlCommand(query_upd_inve.ToString, sql_con)
                comando_upd_inve.Parameters.AddWithValue("@NUEVA_EXISTENCIA", cant_insertar)
                comando_upd_inve.Parameters.AddWithValue("@FECHA_ULTCOM", Now.Date)
                comando_upd_inve.Parameters.AddWithValue("@COSTO_PROM", costo_prom_nuevo)
                comando_upd_inve.Parameters.AddWithValue("@ULT_COSTO", dt_p.Rows(index)(13))
                comando_upd_inve.Parameters.AddWithValue("@CVE_ART", dt_p.Rows(index)(1))
                comando_upd_inve.Transaction = mi_transaccion
                comando_upd_inve.ExecuteNonQuery()

                Dim query_upd_mult As New StringBuilder
                query_upd_mult.Append("UPDATE SAE60EMPRE02.dbo.MULT02 ")
                query_upd_mult.Append("SET [EXIST] = (EXIST + @NUEVA_EXISTENCIA) ")
                query_upd_mult.Append("WHERE  [CVE_ART] = @CVE_ART AND [CVE_ALM] = @CVE_ALM ")
                Dim comando_upd_mult As New SqlCommand(query_upd_mult.ToString, sql_con)
                comando_upd_mult.Parameters.AddWithValue("@NUEVA_EXISTENCIA", cant_insertar)
                comando_upd_mult.Parameters.AddWithValue("@CVE_ART", dt_p.Rows(index)(1))
                comando_upd_mult.Parameters.AddWithValue("@CVE_ALM", dt_e.Rows(0)(2))
                comando_upd_mult.Transaction = mi_transaccion
                comando_upd_mult.ExecuteNonQuery()

                If dt_p.Rows(index)(20) = "S" Then
                    Dim query_reg_lote As New StringBuilder
                    query_reg_lote.Append("SELECT (ULT_CVE + 1) AS ULT_CVE ")
                    query_reg_lote.Append("FROM SAE60EMPRE02.dbo.TBLCONTROL02 ")
                    query_reg_lote.Append("WHERE (ID_TABLA = 48) ")
                    Dim comando_reg_lote As New SqlCommand(query_reg_lote.ToString, sql_con)
                    comando_reg_lote.Transaction = mi_transaccion
                    Dim adaptador_reg_lote As New SqlDataAdapter(comando_reg_lote)
                    Dim dt_reg_lote As New DataTable
                    adaptador_reg_lote.Fill(dt_reg_lote)
                    Dim reg_lote As Integer
                    reg_lote = dt_reg_lote.Rows(0)(0)

                    Dim query_ltpd As New StringBuilder
                    query_ltpd.Append("INSERT INTO [SAE60Empre02].[dbo].[LTPD02] ")
                    query_ltpd.Append("   ([CVE_ART],[LOTE],[PEDIMENTO],[CVE_ALM] ")
                    query_ltpd.Append("   ,[FCHULTMOV],[NOM_ADUAN],[CANTIDAD],[REG_LTPD],[CVE_OBS] ")
                    query_ltpd.Append("   ,[CIUDAD],[FRONTERA],[GLN],[STATUS]) ")
                    query_ltpd.Append("VALUES ")
                    query_ltpd.Append("   (@CVE_ART,@LOTE,'',@CVE_ALM,@FCHULTMOV, ")
                    query_ltpd.Append("'', @CANTIDAD, @REG_LTPD, 0, '', '', '','A')")
                    Dim comando_ltpd As New SqlCommand(query_ltpd.ToString, sql_con)
                    comando_ltpd.Parameters.AddWithValue("@CVE_ART", dt_p.Rows(index)(1))
                    Dim codigo_lote As String = ""

                    If conlote = "S" Then
                        codigo_lote = lote
                    Else
                        codigo_lote = CVE_DOC
                    End If

                    comando_ltpd.Parameters.AddWithValue("@LOTE", codigo_lote)
                    comando_ltpd.Parameters.AddWithValue("@CVE_ALM", dt_e.Rows(0)(2))
                    comando_ltpd.Parameters.AddWithValue("@FCHULTMOV", Now.Date)
                    comando_ltpd.Parameters.AddWithValue("@CANTIDAD", cant_insertar)
                    comando_ltpd.Parameters.AddWithValue("@REG_LTPD", reg_lote)
                    comando_ltpd.Transaction = mi_transaccion
                    comando_ltpd.ExecuteNonQuery()

                    Dim query_enlace_ltpd As New StringBuilder
                    query_enlace_ltpd.Append("INSERT INTO [SAE60Empre02].[dbo].[ENLACE_LTPD02] ")
                    query_enlace_ltpd.Append("   ([E_LTPD],[REG_LTPD],[CANTIDAD],[PXRS]) ")
                    query_enlace_ltpd.Append("VALUES ")
                    query_enlace_ltpd.Append("   (@E_LTPD,@REG_LTPD, @CANTIDAD,@PXRS)")
                    Dim comando_enlace_ltpd As New SqlCommand(query_enlace_ltpd.ToString, sql_con)
                    comando_enlace_ltpd.Parameters.AddWithValue("@E_LTPD", correlativo_lote)
                    comando_enlace_ltpd.Parameters.AddWithValue("@REG_LTPD", reg_lote)
                    comando_enlace_ltpd.Parameters.AddWithValue("@CANTIDAD", cant_insertar)
                    comando_enlace_ltpd.Parameters.AddWithValue("@PXRS", cant_insertar)
                    comando_enlace_ltpd.Transaction = mi_transaccion
                    comando_enlace_ltpd.ExecuteNonQuery()

                    Dim query_upd_correlativo_lote As New StringBuilder
                    query_upd_correlativo_lote.Append("UPDATE [SAE60Empre02].[dbo].[TBLCONTROL02] ")
                    query_upd_correlativo_lote.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                    query_upd_correlativo_lote.Append("WHERE([ID_TABLA] = 67)")
                    Dim comando_upd_correlativo_lote As New SqlCommand(query_upd_correlativo_lote.ToString, sql_con)
                    comando_upd_correlativo_lote.Transaction = mi_transaccion
                    comando_upd_correlativo_lote.ExecuteNonQuery()

                    Dim query_upd_reg_lote As New StringBuilder
                    query_upd_reg_lote.Append("UPDATE [SAE60Empre02].[dbo].[TBLCONTROL02] ")
                    query_upd_reg_lote.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                    query_upd_reg_lote.Append("WHERE([ID_TABLA] = 48)")
                    Dim comando_upd_reg_lote As New SqlCommand(query_upd_reg_lote.ToString, sql_con)
                    comando_upd_reg_lote.Transaction = mi_transaccion
                    comando_upd_reg_lote.ExecuteNonQuery()
                End If

                Dim query_minve As New StringBuilder
                query_minve.Append("INSERT INTO [SAE60Empre02].[dbo].[MINVE02] ")
                query_minve.Append("   ([CVE_ART],[ALMACEN],[NUM_MOV],[CVE_CPTO],[FECHA_DOCU] ")
                query_minve.Append("   ,[TIPO_DOC],[REFER],[CLAVE_CLPV],[VEND],[CANT],[CANT_COST] ")
                query_minve.Append("   ,[PRECIO],[COSTO],[REG_SERIE],[UNI_VENTA] ")
                query_minve.Append("   ,[E_LTPD],[EXIST_G],[EXISTENCIA],[FACTOR_CON] ")
                query_minve.Append("   ,[FECHAELAB],[CVE_FOLIO],[SIGNO],[COSTEADO],[COSTO_PROM_INI] ")
                query_minve.Append("   ,[COSTO_PROM_FIN],[COSTO_PROM_GRAL],[DESDE_INVE],[MOV_ENLAZADO]) ")
                query_minve.Append("VALUES ")
                query_minve.Append("   (@CVE_ART, @ALMACEN,(SELECT ULT_CVE+1 FROM SAE60EMPRE02.dbo.TBLCONTROL02 WHERE (ID_TABLA = 44)),1,@FECHA_DOCU, 'c', @REFER, ")
                query_minve.Append("   @CLAVE_CLPV, '',@CANT, 0, 0, @COSTO,  ")
                query_minve.Append("   0,@UNI_VENTA, @E_LTPD,@CANT+ISNULL((SELECT EXIST FROM SAE60EMPRE02.dbo.INVE02 WHERE (CVE_ART = @CVE_ART)),0), ((SELECT EXIST FROM SAE60EMPRE02.dbo.MULT02 WHERE (CVE_ART = @CVE_ART) AND CVE_ALM = @ALMACEN)), @FACTOR_CON, ")
                query_minve.Append("   @FECHAELAB, (SELECT ULT_CVE+1 FROM SAE60EMPRE02.dbo.TBLCONTROL02 WHERE (ID_TABLA = 32)),'1','S', @COSTO_PROM_INI,@COSTO_PROM_FIN, ")
                query_minve.Append("   @COSTO_PROM_GRAL,'N',0)")
                Dim comando_minve As New SqlCommand(query_minve.ToString, sql_con)
                comando_minve.Parameters.AddWithValue("@CVE_ART", dt_p.Rows(index)(1))
                comando_minve.Parameters.AddWithValue("@ALMACEN", dt_e.Rows(0)(2))
                comando_minve.Parameters.AddWithValue("@FECHA_DOCU", Convert.ToDateTime(dt_e.Rows(0)(5)))
                comando_minve.Parameters.AddWithValue("@REFER", CVE_DOC)
                comando_minve.Parameters.AddWithValue("@CLAVE_CLPV", dt_e.Rows(0)(0))
                comando_minve.Parameters.AddWithValue("@CANT", cant_insertar)
                comando_minve.Parameters.AddWithValue("@COSTO", dt_p.Rows(index)(13))
                comando_minve.Parameters.AddWithValue("@UNI_VENTA", dt_p.Rows(index)(0))
                If dt_p.Rows(index)(20) = "S" Then
                    comando_minve.Parameters.AddWithValue("@E_LTPD", correlativo_lote)
                Else
                    comando_minve.Parameters.AddWithValue("@E_LTPD", 0)
                End If

                comando_minve.Parameters.AddWithValue("@FACTOR_CON", factor_conversion)
                comando_minve.Parameters.AddWithValue("@FECHAELAB", Convert.ToDateTime(dt_e.Rows(0)(5)))
                comando_minve.Parameters.AddWithValue("@COSTO_PROM_INI", costo_prom_viejo)
                comando_minve.Parameters.AddWithValue("@COSTO_PROM_FIN", costo_prom_nuevo)
                comando_minve.Parameters.AddWithValue("@COSTO_PROM_GRAL", costo_prom_nuevo)
                comando_minve.Transaction = mi_transaccion
                comando_minve.ExecuteNonQuery()

                Dim query_num_mov_minve As New StringBuilder
                query_num_mov_minve.Append("UPDATE [SAE60Empre02].[dbo].[TBLCONTROL02] ")
                query_num_mov_minve.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                query_num_mov_minve.Append("WHERE ([ID_TABLA] = 44)")
                Dim comando_num_mov_minve As New SqlCommand(query_num_mov_minve.ToString, sql_con)
                comando_num_mov_minve.Transaction = mi_transaccion
                comando_num_mov_minve.ExecuteNonQuery()

                Dim query_upd_folio_minve As New StringBuilder
                query_upd_folio_minve.Append("UPDATE SAE60EMPRE02.dbo.TBLCONTROL02 ")
                query_upd_folio_minve.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                query_upd_folio_minve.Append("WHERE (ID_TABLA = 32) ")
                Dim comando_upd_folio_minve As New SqlCommand(query_upd_folio_minve.ToString, sql_con)
                comando_upd_folio_minve.Transaction = mi_transaccion
                comando_upd_folio_minve.ExecuteNonQuery()
            Next

            'fin del for

            Dim query_paga_m As New StringBuilder
            query_paga_m.Append("INSERT INTO [SAE60Empre02].[dbo].[PAGA_M02] ")
            query_paga_m.Append("   ([CVE_PROV],[REFER],[NUM_CARGO],[NUM_CPTO],[CVE_OBS] ")
            query_paga_m.Append("   ,[NO_FACTURA],[DOCTO],[IMPORTE],[FECHA_APLI],[FECHA_VENC],[AFEC_COI] ")
            query_paga_m.Append("   ,[NUM_MONED],[TCAMBIO],[IMPMON_EXT],[FECHAELAB],[TIPO_MOV] ")
            query_paga_m.Append("   ,[SIGNO],[USUARIO],[STATUS]) ")
            query_paga_m.Append("VALUES ")
            query_paga_m.Append("   (@CVE_PROV, @REFER, 1, 1, 0, @NO_FACTURA, ")
            query_paga_m.Append("   @DOCTO,@IMPORTE,@FECHA_APLI, @FECHA_VENC, 'A',1, 1, ")
            query_paga_m.Append("   @IMPMON_EXT,@FECHAELAB, 'C', 1, ")
            query_paga_m.Append("   @USUARIO, 'A')")
            Dim comando_paga_m As New SqlCommand(query_paga_m.ToString, sql_con)
            comando_paga_m.Parameters.AddWithValue("@CVE_PROV", dt_e.Rows(0)(0))
            comando_paga_m.Parameters.AddWithValue("@REFER", CVE_DOC)
            comando_paga_m.Parameters.AddWithValue("@DOCTO", CVE_DOC)
            comando_paga_m.Parameters.AddWithValue("@NO_FACTURA", dt_e.Rows(0)(3))
            comando_paga_m.Parameters.AddWithValue("@IMPORTE", dt_e.Rows(0)(10))
            comando_paga_m.Parameters.AddWithValue("@FECHA_APLI", Convert.ToDateTime(dt_e.Rows(0)(5)))
            comando_paga_m.Parameters.AddWithValue("@FECHA_VENC", Convert.ToDateTime(dt_e.Rows(0)(5)).AddDays(dias_cred))
            comando_paga_m.Parameters.AddWithValue("@IMPMON_EXT", dt_e.Rows(0)(10))
            comando_paga_m.Parameters.AddWithValue("@FECHAELAB", Convert.ToDateTime(dt_e.Rows(0)(5)))
            comando_paga_m.Parameters.AddWithValue("@USUARIO", 0)
            comando_paga_m.Transaction = mi_transaccion
            comando_paga_m.ExecuteNonQuery()

            Dim query_upd_prov As New StringBuilder
            query_upd_prov.Append("UPDATE [SAE60Empre02].[dbo].[PROV02] ")
            query_upd_prov.Append("SET [ULT_COMPD] = @ULT_COMPD ")
            query_upd_prov.Append(",[ULT_COMPM] =@ULT_COMPM ")
            query_upd_prov.Append(",[ULT_COMPF] =@ULT_COMPF ")
            query_upd_prov.Append(",[SALDO] = SALDO + @SALDO ")
            query_upd_prov.Append("WHERE([CLAVE] = @CLAVE)")
            Dim comando_upd_prov As New SqlCommand(query_upd_prov.ToString, sql_con)
            comando_upd_prov.Parameters.AddWithValue("@ULT_COMPD", CVE_DOC)
            comando_upd_prov.Parameters.AddWithValue("@ULT_COMPM", dt_e.Rows(0)(10))
            comando_upd_prov.Parameters.AddWithValue("@ULT_COMPF", Convert.ToDateTime(dt_e.Rows(0)(5)))
            comando_upd_prov.Parameters.AddWithValue("@SALDO", dt_e.Rows(0)(10))
            comando_upd_prov.Parameters.AddWithValue("@CLAVE", dt_e.Rows(0)(0))
            comando_upd_prov.Transaction = mi_transaccion
            comando_upd_prov.ExecuteNonQuery()

            Dim query_cve_docto_upd As New StringBuilder
            query_cve_docto_upd.Append("UPDATE [SAE60Empre02].[dbo].[FOLIOSC02] ")
            query_cve_docto_upd.Append("SET [ULT_DOC] = ULT_DOC + 1 , ")
            query_cve_docto_upd.Append("[FECH_ULT_DOC] = @FECH_ULT_DOC ")
            query_cve_docto_upd.Append("WHERE (TIP_DOC = 'c') AND (SERIE = @SERIE)")
            Dim comando_cve_docto_upd As New SqlCommand(query_cve_docto_upd.ToString, sql_con)
            comando_cve_docto_upd.Parameters.AddWithValue("@FECH_ULT_DOC", Convert.ToDateTime(dt_e.Rows(0)(5)))
            comando_cve_docto_upd.Parameters.AddWithValue("@SERIE", serie)
            comando_cve_docto_upd.Transaction = mi_transaccion
            comando_cve_docto_upd.ExecuteNonQuery()

            Dim conexion_bita As New cls_bitacora_reporteador
            conexion_bita.RegistraBitacora(Now, usuario, "Ingreso de Compra Nacional SR Agro", "COMPRAS", _
                                      "Fecha: " + Convert.ToDateTime(dt_e.Rows(0)(5)) + " Numero de Compra SAE: " + CVE_DOC + _
                                      " Numero de Compra Rep:" + CVE_COMPRA + " almacen:" + dt_e.Rows(0)(2))

            mi_transaccion.Commit()
            sql_con.Close()
            Return "correcto"
        Catch ex As Exception
            mi_transaccion.Rollback()
            sql_con.Close()
            Dim tamaño As Integer = Convert.ToString(ex.StackTrace).Length
            Dim posicion As Integer = InStrRev(Convert.ToString(ex.StackTrace), "línea") - 1
            Dim inicial As Integer = tamaño - posicion
            Dim linea_error As String = Convert.ToString(ex.StackTrace).Substring(tamaño - inicial, inicial)
            Return (ex.Message + " --> " + linea_error + " " + ex.ToString())
        End Try
    End Function
    'envio individual a SAE
    Public Function envio_individual_compras_SAE(ByVal dt_e As DataTable, ByVal dt_p As DataTable, ByVal CVE_COMPRA As String, _
                                                 ByVal conlote As String, ByVal lote As String, ByVal usuario As String) As String
        Dim sql_con As New SqlConnection(conexion.CadenaSQL)
        Dim mi_transaccion As SqlTransaction
        sql_con.Open()
        mi_transaccion = sql_con.BeginTransaction

        Try
            Dim query_codigo As New StringBuilder
            query_codigo.Append("SELECT FOLIO + CONVERT(VARCHAR, ULT_DOC + 1) AS CLAVE,FOLIO ")
            query_codigo.Append("FROM nd_folios ")
            query_codigo.Append("WHERE (NUM_ALMA = @ALMACEN) AND (TIPO = 'C')")
            Dim comando_codigo As New SqlCommand(query_codigo.ToString, sql_con)
            comando_codigo.Parameters.AddWithValue("@ALMACEN", dt_e.Rows(0)(2))
            comando_codigo.Transaction = mi_transaccion
            Dim dt As New DataTable
            Dim adaptador_codigo As New SqlDataAdapter(comando_codigo)
            adaptador_codigo.Fill(dt)
            Dim serie_local As String = ""
            serie_local = dt.Rows(0)(1)

            Dim query_cve_docto As New StringBuilder
            query_cve_docto.Append("SELECT SERIE, ULT_DOC ")
            query_cve_docto.Append("FROM SAE60EMPRE02.dbo.FOLIOSC02 ")
            query_cve_docto.Append("WHERE (TIP_DOC = 'c') AND (SERIE = @SERIE) ")
            Dim comando_cve_docto As New SqlCommand(query_cve_docto.ToString, sql_con)
            comando_cve_docto.Parameters.AddWithValue("@SERIE", serie_local)
            comando_cve_docto.Transaction = mi_transaccion
            Dim adaptador_cve_docto As New SqlDataAdapter(comando_cve_docto)
            Dim dt_cve_docto As New DataTable
            adaptador_cve_docto.Fill(dt_cve_docto)
            Dim CVE_DOC As String = ""
            Dim serie As String = ""
            Dim folio As Integer
            serie = dt_cve_docto.Rows(0)(0)
            folio = dt_cve_docto.Rows(0)(1) + 1
            CVE_DOC = serie & folio

            'CAMBIAR ESTADO DE COMPRA LOCAL
            Dim query_compra_local As New StringBuilder
            query_compra_local.Append("UPDATE [tactical_discount_sragro].[dbo].[nd_compras_e]")
            query_compra_local.Append("   SET [ESTADO] = 'ENVIADA'")
            query_compra_local.Append("      ,[N_FACTURA_SAE] = @N_FACTURA_SAE, [FECHA_FACTURA] = @FECHA_FACTURA ")
            query_compra_local.Append(" WHERE [CVE_COMPRA] = @CVE_COMPRA")
            Dim comando_local As New SqlCommand(query_compra_local.ToString, sql_con)
            comando_local.Parameters.AddWithValue("@N_FACTURA_SAE", CVE_DOC)
            comando_local.Parameters.AddWithValue("@CVE_COMPRA", CVE_COMPRA)
            comando_local.Parameters.AddWithValue("@FECHA_FACTURA", Convert.ToDateTime(dt_e.Rows(0)(16)))
            comando_local.Transaction = mi_transaccion
            comando_local.ExecuteNonQuery()
            'fin de las compras locales

            Dim ajuste As String = ""
            Dim debito As String = ""
            For index As Integer = 0 To dt_p.Rows.Count - 1
                If dt_p.Rows(index)(14) = "S" Then
                    ajuste = "S"
                End If

                If dt_p.Rows(index)(14) = "D" Then
                    debito = "D"
                End If
            Next

            ' registra los debito por producto
            If ajuste = "S" Then
                Dim query_folio_ajuste As New StringBuilder
                query_folio_ajuste.Append("SELECT FOLIO + CONVERT(VARCHAR, ULT_DOC + 1) AS ULT_DOC ")
                query_folio_ajuste.Append("FROM nd_folios ")
                query_folio_ajuste.Append("WHERE (TIPO = 'A') AND (NUM_ALMA = @ALMACEN)")
                Dim comando_folio_ajuste As New SqlCommand(query_folio_ajuste.ToString, sql_con)
                comando_folio_ajuste.Parameters.AddWithValue("@ALMACEN", dt_e.Rows(0)(2))
                comando_folio_ajuste.Transaction = mi_transaccion
                Dim dt_folio_ajuste As New DataTable
                Dim adaptador_folio_ajuste As New SqlDataAdapter(comando_folio_ajuste)
                adaptador_folio_ajuste.Fill(dt_folio_ajuste)

                Dim subtotal_ajuste_e As Double = 0, isv_ajuste_e As Double = 0, total_ajueste_e As Double = 0, descuento_ajuste_e As Double = 0
                For index As Integer = 0 To dt_p.Rows.Count - 1
                    If dt_p.Rows(index)(14) = "S" Then
                        Dim query_ajuste_p As New StringBuilder
                        query_ajuste_p.Append("INSERT INTO [tactical_discount_sragro].[dbo].[nd_ajuste_p] ")
                        query_ajuste_p.Append("([ID_AJUSTE],[NUM_PART],[CVE_ART],[DESCRIPCION],[MOTIVO],[CANTIDAD], ")
                        query_ajuste_p.Append("[FECHA_INGRESO],[COSTO_ANTERIOR],[COSTO_ACTUAL],[AJUSTE],[UNI]) ")
                        query_ajuste_p.Append("VALUES ")
                        query_ajuste_p.Append("(@ID_AJUSTE,@NUM_PART,@CVE_ART,@DESCRIPCION,@MOTIVO,@CANTIDAD, ")
                        query_ajuste_p.Append("@FECHA_INGRESO,@COSTO_ANTERIOR,@COSTO_ACTUAL,@AJUSTE,@UNI)")
                        Dim comando_ajuste_p As New SqlCommand(query_ajuste_p.ToString, sql_con)
                        comando_ajuste_p.Parameters.AddWithValue("@ID_AJUSTE", dt_folio_ajuste.Rows(0)(0))
                        comando_ajuste_p.Parameters.AddWithValue("@NUM_PART", index + 1)
                        comando_ajuste_p.Parameters.AddWithValue("@CVE_ART", dt_p.Rows(index)(1))
                        comando_ajuste_p.Parameters.AddWithValue("@DESCRIPCION", dt_p.Rows(index)(2))
                        comando_ajuste_p.Parameters.AddWithValue("@MOTIVO", "AJUSTE DE PRECIO")
                        comando_ajuste_p.Parameters.AddWithValue("@CANTIDAD", dt_p.Rows(index)(4))
                        comando_ajuste_p.Parameters.AddWithValue("@FECHA_INGRESO", Convert.ToDateTime(dt_e.Rows(0)(5)))
                        comando_ajuste_p.Parameters.AddWithValue("@COSTO_ANTERIOR", dt_p.Rows(index)(5))
                        comando_ajuste_p.Parameters.AddWithValue("@COSTO_ACTUAL", dt_p.Rows(index)(6))
                        Dim valor_ajuste As Double = 0

                        valor_ajuste = (Convert.ToDouble(dt_p.Rows(index)(4)) * Convert.ToDouble(dt_p.Rows(index)(6))) - (Convert.ToDouble(dt_p.Rows(index)(4)) * Convert.ToDouble(dt_p.Rows(index)(5)))
                        If dt_p.Rows(index)(0) = "cj" Then
                            valor_ajuste = valor_ajuste * Convert.ToDouble(dt_p.Rows(index)(3))
                        End If

                        comando_ajuste_p.Parameters.AddWithValue("@AJUSTE", valor_ajuste * -1)
                        comando_ajuste_p.Parameters.AddWithValue("@UNI", dt_p.Rows(index)(0))

                        subtotal_ajuste_e += valor_ajuste
                        descuento_ajuste_e += 0 'valor_ajuste '* dt_p.Rows(index)(7) / 100
                        valor_ajuste = valor_ajuste - descuento_ajuste_e
                        isv_ajuste_e += valor_ajuste * dt_p.Rows(index)(8) / 100
                        comando_ajuste_p.Transaction = mi_transaccion
                        comando_ajuste_p.ExecuteNonQuery()
                    End If
                Next
                total_ajueste_e += subtotal_ajuste_e - descuento_ajuste_e + isv_ajuste_e

                Dim query_ajuste_e As New StringBuilder
                query_ajuste_e.Append("INSERT INTO [tactical_discount_sragro].[dbo].[nd_ajuste_e] ")
                query_ajuste_e.Append("([ID_AJUSTE],[CVE_PROVEEDOR],[ALMACEN],[REF_PROV]")
                query_ajuste_e.Append(",[FECHA],[N_FACTURA],[SUBTOTAL],[DESCUENTO],[ISV],[TOTAL],[COMPRA],[TIPO]) ")
                query_ajuste_e.Append("VALUES ")
                query_ajuste_e.Append("(@ID_AJUSTE,@CVE_PROVEEDOR,@ALMACEN,@REF_PROV,@FECHA, ")
                query_ajuste_e.Append("@N_FACTURA,@SUBTOTAL,@DESCUENTO,@ISV,@TOTAL,@COMPRA,@TIPO)")
                Dim comando_ajuste_e As New SqlCommand(query_ajuste_e.ToString, sql_con)
                comando_ajuste_e.Parameters.AddWithValue("@ID_AJUSTE", dt_folio_ajuste.Rows(0)(0))
                comando_ajuste_e.Parameters.AddWithValue("@CVE_PROVEEDOR", dt_e.Rows(0)(0))
                comando_ajuste_e.Parameters.AddWithValue("@ALMACEN", dt_e.Rows(0)(2))
                comando_ajuste_e.Parameters.AddWithValue("@REF_PROV", dt_e.Rows(0)(3))
                comando_ajuste_e.Parameters.AddWithValue("@FECHA", Convert.ToDateTime(dt_e.Rows(0)(5)))
                comando_ajuste_e.Parameters.AddWithValue("@N_FACTURA", CVE_DOC)
                comando_ajuste_e.Parameters.AddWithValue("@SUBTOTAL", subtotal_ajuste_e * -1)
                comando_ajuste_e.Parameters.AddWithValue("@DESCUENTO", 0) ' descuento_ajuste_e * -1)
                comando_ajuste_e.Parameters.AddWithValue("@ISV", isv_ajuste_e * -1)
                comando_ajuste_e.Parameters.AddWithValue("@TOTAL", total_ajueste_e * -1)
                comando_ajuste_e.Parameters.AddWithValue("@COMPRA", CVE_COMPRA)
                comando_ajuste_e.Parameters.AddWithValue("@TIPO", "DEBITO")
                comando_ajuste_e.Transaction = mi_transaccion
                comando_ajuste_e.ExecuteNonQuery()

                Dim query_upd_folio_ajuste As New StringBuilder
                query_upd_folio_ajuste.Append("UPDATE [tactical_discount_sragro].[dbo].[nd_folios] ")
                query_upd_folio_ajuste.Append("   SET [ULT_DOC] = ULT_DOC+1 ")
                query_upd_folio_ajuste.Append("WHERE [NUM_ALMA] = @NUM_ALMA AND TIPO = 'A' ")
                Dim comando_upd_folio_ajuste As New SqlCommand(query_upd_folio_ajuste.ToString, sql_con)
                comando_upd_folio_ajuste.Parameters.AddWithValue("@NUM_ALMA", dt_e.Rows(0)(2))
                comando_upd_folio_ajuste.Transaction = mi_transaccion
                comando_upd_folio_ajuste.ExecuteNonQuery()

            End If
            ' fn registra los debitos por producto

            Dim query_dias_cred As New StringBuilder
            query_dias_cred.Append("Select ISNULL(DIASCRED,0) ")
            query_dias_cred.Append("FROM SAE60EMPRE02.dbo.PROV02 ")
            query_dias_cred.Append("WHERE (CLAVE = @CLAVE) ")
            Dim comando_dias_cred As New SqlCommand(query_dias_cred.ToString, sql_con)
            comando_dias_cred.Parameters.AddWithValue("@CLAVE", dt_e.Rows(0)(0))
            comando_dias_cred.Transaction = mi_transaccion
            Dim adaptador_dias_cred As New SqlDataAdapter(comando_dias_cred)
            Dim dt_dias_cred As New DataTable
            adaptador_dias_cred.Fill(dt_dias_cred)
            Dim dias_cred As Integer = 0
            dias_cred = dt_dias_cred.Rows(0)(0)

            ' registra los creditos por producto
            If debito = "D" Then
                Dim query_folio_debito As New StringBuilder
                query_folio_debito.Append("SELECT FOLIO + CONVERT(VARCHAR, ULT_DOC + 1) AS ULT_DOC ")
                query_folio_debito.Append("FROM nd_folios ")
                query_folio_debito.Append("WHERE (TIPO = 'D') AND (NUM_ALMA = @ALMACEN)")
                Dim comando_folio_debito As New SqlCommand(query_folio_debito.ToString, sql_con)
                comando_folio_debito.Parameters.AddWithValue("@ALMACEN", dt_e.Rows(0)(2))
                comando_folio_debito.Transaction = mi_transaccion
                Dim dt_folio_debito As New DataTable
                Dim adaptador_folio_debito As New SqlDataAdapter(comando_folio_debito)
                adaptador_folio_debito.Fill(dt_folio_debito)

                Dim subtotal_debito_e As Double = 0, isv_debito_e As Double = 0, total_debito_e As Double = 0, descuento_debito_e As Double = 0
                For index As Integer = 0 To dt_p.Rows.Count - 1
                    If dt_p.Rows(index)(14) = "D" Then
                        Dim query_debito_p As New StringBuilder
                        query_debito_p.Append("INSERT INTO [tactical_discount_sragro].[dbo].[nd_ajuste_p] ")
                        query_debito_p.Append("([ID_AJUSTE],[NUM_PART],[CVE_ART],[DESCRIPCION],[MOTIVO],[CANTIDAD], ")
                        query_debito_p.Append("[FECHA_INGRESO],[COSTO_ANTERIOR],[COSTO_ACTUAL],[AJUSTE],[UNI]) ")
                        query_debito_p.Append("VALUES ")
                        query_debito_p.Append("(@ID_AJUSTE,@NUM_PART,@CVE_ART,@DESCRIPCION,@MOTIVO,@CANTIDAD, ")
                        query_debito_p.Append("@FECHA_INGRESO,@COSTO_ANTERIOR,@COSTO_ACTUAL,@AJUSTE,@UNI)")
                        Dim comando_debito_p As New SqlCommand(query_debito_p.ToString, sql_con)
                        comando_debito_p.Parameters.AddWithValue("@ID_AJUSTE", dt_folio_debito.Rows(0)(0))
                        comando_debito_p.Parameters.AddWithValue("@NUM_PART", index + 1)
                        comando_debito_p.Parameters.AddWithValue("@CVE_ART", dt_p.Rows(index)(1))
                        comando_debito_p.Parameters.AddWithValue("@DESCRIPCION", dt_p.Rows(index)(2))
                        comando_debito_p.Parameters.AddWithValue("@MOTIVO", "AJUSTE DE PRECIO")
                        comando_debito_p.Parameters.AddWithValue("@CANTIDAD", dt_p.Rows(index)(4))
                        comando_debito_p.Parameters.AddWithValue("@FECHA_INGRESO", Convert.ToDateTime(dt_e.Rows(0)(5)))
                        comando_debito_p.Parameters.AddWithValue("@COSTO_ANTERIOR", dt_p.Rows(index)(5))
                        comando_debito_p.Parameters.AddWithValue("@COSTO_ACTUAL", dt_p.Rows(index)(6))
                        Dim valor_ajuste As Double = 0
                        valor_ajuste = (Convert.ToDouble(dt_p.Rows(index)(4)) * Convert.ToDouble(dt_p.Rows(index)(6))) - (Convert.ToDouble(dt_p.Rows(index)(4)) * Convert.ToDouble(dt_p.Rows(index)(5)))
                        If dt_p.Rows(index)(0) = "cj" Then
                            valor_ajuste = valor_ajuste * Convert.ToDouble(dt_p.Rows(index)(3))
                        End If
                        comando_debito_p.Parameters.AddWithValue("@AJUSTE", Math.Abs(valor_ajuste))
                        comando_debito_p.Parameters.AddWithValue("@UNI", dt_p.Rows(index)(0))

                        subtotal_debito_e += valor_ajuste
                        descuento_debito_e += 0 'valor_ajuste '* dt_p.Rows(index)(7) / 100
                        valor_ajuste = valor_ajuste - descuento_debito_e
                        isv_debito_e += valor_ajuste * dt_p.Rows(index)(8) / 100
                        comando_debito_p.Transaction = mi_transaccion
                        comando_debito_p.ExecuteNonQuery()
                    End If
                Next
                total_debito_e += subtotal_debito_e - descuento_debito_e + isv_debito_e

                Dim query_debito_e As New StringBuilder
                query_debito_e.Append("INSERT INTO [tactical_discount_sragro].[dbo].[nd_ajuste_e] ")
                query_debito_e.Append("([ID_AJUSTE],[CVE_PROVEEDOR],[ALMACEN],[REF_PROV]")
                query_debito_e.Append(",[FECHA],[N_FACTURA],[SUBTOTAL],[DESCUENTO],[ISV],[TOTAL],[COMPRA],[TIPO]) ")
                query_debito_e.Append("VALUES ")
                query_debito_e.Append("(@ID_AJUSTE,@CVE_PROVEEDOR,@ALMACEN,@REF_PROV,@FECHA, ")
                query_debito_e.Append("@N_FACTURA,@SUBTOTAL,@DESCUENTO,@ISV,@TOTAL,@COMPRA,@TIPO)")
                Dim comando_debito_e As New SqlCommand(query_debito_e.ToString, sql_con)
                comando_debito_e.Parameters.AddWithValue("@ID_AJUSTE", dt_folio_debito.Rows(0)(0))
                comando_debito_e.Parameters.AddWithValue("@CVE_PROVEEDOR", dt_e.Rows(0)(0))
                comando_debito_e.Parameters.AddWithValue("@ALMACEN", dt_e.Rows(0)(2))
                comando_debito_e.Parameters.AddWithValue("@REF_PROV", dt_e.Rows(0)(3))
                comando_debito_e.Parameters.AddWithValue("@FECHA", Convert.ToDateTime(dt_e.Rows(0)(5)))
                comando_debito_e.Parameters.AddWithValue("@N_FACTURA", CVE_DOC)
                comando_debito_e.Parameters.AddWithValue("@SUBTOTAL", Math.Abs(subtotal_debito_e))
                comando_debito_e.Parameters.AddWithValue("@DESCUENTO", 0) 'Math.Abs(descuento_debito_e))
                comando_debito_e.Parameters.AddWithValue("@ISV", Math.Abs(isv_debito_e))
                comando_debito_e.Parameters.AddWithValue("@TOTAL", Math.Abs(total_debito_e))
                comando_debito_e.Parameters.AddWithValue("@COMPRA", CVE_COMPRA)
                comando_debito_e.Parameters.AddWithValue("@TIPO", "CREDITO")
                comando_debito_e.Transaction = mi_transaccion
                comando_debito_e.ExecuteNonQuery()

                Dim query_upd_folio_ajuste As New StringBuilder
                query_upd_folio_ajuste.Append("UPDATE [tactical_discount_sragro].[dbo].[nd_folios] ")
                query_upd_folio_ajuste.Append("   SET [ULT_DOC] = ULT_DOC+1 ")
                query_upd_folio_ajuste.Append("WHERE [NUM_ALMA] = @NUM_ALMA AND TIPO = 'D' ")
                Dim comando_upd_folio_ajuste As New SqlCommand(query_upd_folio_ajuste.ToString, sql_con)
                comando_upd_folio_ajuste.Parameters.AddWithValue("@NUM_ALMA", dt_e.Rows(0)(2))
                comando_upd_folio_ajuste.Transaction = mi_transaccion
                comando_upd_folio_ajuste.ExecuteNonQuery()

                Dim query_opaga As New StringBuilder
                query_opaga.Append("INSERT INTO [SAE60Empre02].[dbo].[OPAGA02] ")
                query_opaga.Append("([CVE_OBS],[STR_OBS]) ")
                query_opaga.Append("VALUES ((SELECT ULT_CVE + 1 AS ULT_CVE FROM SAE60EMPRE02.dbo.TBLCONTROL02 WHERE (ID_TABLA = 21)),'NOTA DE CREDITO POR PRECIO MENOR DEL PROVEEDOR')")
                Dim comando_opaga As New SqlCommand(query_opaga.ToString, sql_con)
                comando_opaga.Transaction = mi_transaccion
                comando_opaga.ExecuteNonQuery()

                Dim query_paga_det As New StringBuilder
                query_paga_det.Append("INSERT INTO [SAE60Empre02].[dbo].[PAGA_DET02] ")
                query_paga_det.Append("([CVE_PROV],[REFER],[NUM_CPTO],[NUM_CARGO],[ID_MOV] ")
                query_paga_det.Append(",[CVE_OBS],[NO_FACTURA],[DOCTO],[IMPORTE],[FECHA_APLI],[FECHA_VENC] ")
                query_paga_det.Append(",[NUM_MONED],[TCAMBIO],[IMPMON_EXT],[FECHAELAB] ")
                query_paga_det.Append(",[TIPO_MOV],[SIGNO],[USUARIO] ")
                query_paga_det.Append(",[NO_PARTIDA]) ")
                query_paga_det.Append("VALUES ")
                query_paga_det.Append("(@CVE_PROV, @REFER, 29,1,1, (SELECT ULT_CVE + 1 AS ULT_CVE FROM SAE60EMPRE02.dbo.TBLCONTROL02 WHERE (ID_TABLA = 21)), ")
                query_paga_det.Append("@NO_FACTURA, @DOCTO, @IMPORTE, @FECHA_APLI, @FECHA_VENC, 1, ")
                query_paga_det.Append("1, @IMPMON_EXT, @FECHAELAB,'A', -1,0, 1) ")
                Dim comando_paga_det As New SqlCommand(query_paga_det.ToString, sql_con)
                comando_paga_det.Parameters.AddWithValue("@CVE_PROV", dt_e.Rows(0)(0))
                comando_paga_det.Parameters.AddWithValue("@REFER", CVE_DOC)
                comando_paga_det.Parameters.AddWithValue("@NO_FACTURA", CVE_DOC)
                comando_paga_det.Parameters.AddWithValue("@DOCTO", CVE_DOC)
                comando_paga_det.Parameters.AddWithValue("@IMPORTE", Math.Abs(total_debito_e))
                comando_paga_det.Parameters.AddWithValue("@FECHA_APLI", Convert.ToDateTime(dt_e.Rows(0)(5)))
                comando_paga_det.Parameters.AddWithValue("@FECHA_VENC", Convert.ToDateTime(dt_e.Rows(0)(5)).AddDays(dias_cred))
                comando_paga_det.Parameters.AddWithValue("@IMPMON_EXT", Math.Abs(total_debito_e))
                comando_paga_det.Parameters.AddWithValue("@FECHAELAB", Convert.ToDateTime(dt_e.Rows(0)(5)))
                comando_paga_det.Transaction = mi_transaccion
                comando_paga_det.ExecuteNonQuery()

                Dim query_upd_paga_det As New StringBuilder
                query_upd_paga_det.Append("UPDATE [SAE60Empre02].[dbo].[TBLCONTROL02] ")
                query_upd_paga_det.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                query_upd_paga_det.Append("WHERE ([ID_TABLA] = 21)")
                Dim comando_upd_paga_det As New SqlCommand(query_upd_paga_det.ToString, sql_con)
                comando_upd_paga_det.Transaction = mi_transaccion
                comando_upd_paga_det.ExecuteNonQuery()
            End If
            ' fin registra los creditos por producto

            'registrar envio a SAE

            Dim query_compc As New StringBuilder
            query_compc.Append("INSERT INTO [SAE60Empre02].[dbo].[COMPC02] ")
            query_compc.Append("([TIP_DOC],[CVE_DOC],[CVE_CLPV],[STATUS],[SU_REFER] ")
            query_compc.Append(",[FECHA_DOC],[FECHA_REC],[FECHA_PAG] ")
            query_compc.Append(",[CAN_TOT],[IMP_TOT1],[IMP_TOT2],[IMP_TOT3],[IMP_TOT4] ")
            query_compc.Append(",[DES_TOT],[DES_FIN],[TOT_IND],[OBS_COND],[CVE_OBS] ")
            query_compc.Append(",[NUM_ALMA],[ACT_CXP],[ACT_COI],[ENLAZADO],[TIP_DOC_E] ")
            query_compc.Append(",[NUM_MONED],[TIPCAMB],[NUM_PAGOS],[FECHAELAB] ")
            query_compc.Append(",[SERIE],[FOLIO],[CTLPOL],[ESCFD],[CONTADO],[BLOQ] ")
            query_compc.Append(",[DES_FIN_PORC],[DES_TOT_PORC],[IMPORTE],[TIP_DOC_ANT],[DOC_ANT]) ")
            query_compc.Append("VALUES ")
            query_compc.Append("('c', @CVE_DOC,@CVE_CLPV,'O',@SU_REFER,@FECHA_DOC ")
            query_compc.Append(",@FECHA_REC,@FECHA_PAG,@CAN_TOT,0,0,0,@IMP_TOT4,@DES_TOT,0,0 ")
            query_compc.Append(",'',0,@NUM_ALMA,'S','N','O','O',1,1,1,@FECHAELAB ")
            query_compc.Append(",@SERIE,@FOLIO,0,'N','N','N',0 ,@DES_TOT_PORC,@IMPORTE,'','' )")
            Dim comando_compc As New SqlCommand(query_compc.ToString, sql_con)
            comando_compc.Parameters.AddWithValue("@CVE_DOC", CVE_DOC)
            comando_compc.Parameters.AddWithValue("@CVE_CLPV", dt_e.Rows(0)(0))
            comando_compc.Parameters.AddWithValue("@SU_REFER", dt_e.Rows(0)(3))
            comando_compc.Parameters.AddWithValue("@FECHA_DOC", Convert.ToDateTime(dt_e.Rows(0)(5)))
            comando_compc.Parameters.AddWithValue("@FECHA_REC", Convert.ToDateTime(dt_e.Rows(0)(5)))
            comando_compc.Parameters.AddWithValue("@FECHA_PAG", Convert.ToDateTime(dt_e.Rows(0)(5)).AddDays(dias_cred)) 'Agregar dias de credito
            comando_compc.Parameters.AddWithValue("@CAN_TOT", dt_e.Rows(0)(7))
            comando_compc.Parameters.AddWithValue("@IMP_TOT4", dt_e.Rows(0)(9))
            comando_compc.Parameters.AddWithValue("@DES_TOT", dt_e.Rows(0)(8))
            comando_compc.Parameters.AddWithValue("@NUM_ALMA", dt_e.Rows(0)(2))
            comando_compc.Parameters.AddWithValue("@FECHAELAB", Now.Date)
            comando_compc.Parameters.AddWithValue("@SERIE", serie)
            comando_compc.Parameters.AddWithValue("@FOLIO", folio)
            comando_compc.Parameters.AddWithValue("@DES_TOT_PORC", dt_e.Rows(0)(6))
            comando_compc.Parameters.AddWithValue("@IMPORTE", dt_e.Rows(0)(10))
            comando_compc.Transaction = mi_transaccion
            comando_compc.ExecuteNonQuery()

            Dim query_compc_clib As New StringBuilder
            query_compc_clib.Append("INSERT INTO [SAE60Empre02].[dbo].[COMPC_CLIB02] ")
            query_compc_clib.Append(" ([CLAVE_DOC],[CAMPLIB1]) ")
            query_compc_clib.Append("VALUES (@CLAVE_DOC,@CAMPLIB1)")
            Dim comando_comp_clib As New SqlCommand(query_compc_clib.ToString, sql_con)
            comando_comp_clib.Parameters.AddWithValue("CLAVE_DOC", CVE_DOC)
            comando_comp_clib.Parameters.AddWithValue("@CAMPLIB1", Convert.ToDateTime(dt_e.Rows(0)(16)))
            comando_comp_clib.Transaction = mi_transaccion
            comando_comp_clib.ExecuteNonQuery()

            'inicio del for

            For index As Integer = 0 To dt_p.Rows.Count - 1
                Dim query_correlativo_lote As New StringBuilder
                query_correlativo_lote.Append("SELECT (ULT_CVE + 1) AS ULT_CVE ")
                query_correlativo_lote.Append("FROM SAE60EMPRE02.dbo.TBLCONTROL02 ")
                query_correlativo_lote.Append("WHERE (ID_TABLA = 67) ")
                Dim comando_correlativo_lote As New SqlCommand(query_correlativo_lote.ToString, sql_con)
                comando_correlativo_lote.Transaction = mi_transaccion
                Dim adaptador_correlativo_lote As New SqlDataAdapter(comando_correlativo_lote)
                Dim dt_correlativo_lote As New DataTable
                adaptador_correlativo_lote.Fill(dt_correlativo_lote)
                Dim correlativo_lote As Integer
                correlativo_lote = dt_correlativo_lote.Rows(0)(0)

                Dim query_par_compc As New StringBuilder
                query_par_compc.Append("INSERT INTO [SAE60Empre02].[dbo].[PAR_COMPC02] ")
                query_par_compc.Append("   ([CVE_DOC],[NUM_PAR],[CVE_ART],[CANT],[PXR],[PREC],[COST] ")
                query_par_compc.Append("   ,[IMPU1],[IMPU2],[IMPU3],[IMPU4],[IMP1APLA],[IMP2APLA],[IMP3APLA] ")
                query_par_compc.Append("   ,[IMP4APLA],[TOTIMP1],[TOTIMP2],[TOTIMP3],[TOTIMP4],[DESCU],[ACT_INV] ")
                query_par_compc.Append("   ,[TIP_CAM],[UNI_VENTA],[TIPO_ELEM],[TIPO_PROD],[CVE_OBS],[REG_SERIE] ")
                query_par_compc.Append("   ,[E_LTPD],[FACTCONV],[COST_DEV],[NUM_ALM],[MINDIRECTO],[NUM_MOV],[TOT_PARTIDA]) ")
                query_par_compc.Append("VALUES ")
                query_par_compc.Append("  (@CVE_DOC,@NUM_PAR,@CVE_ART, @CANT, @PXR, ISNULL((SELECT SAE60Empre02.dbo.PRECIO_X_PROD02.PRECIO ")
                query_par_compc.Append("FROM SAE60Empre02.dbo.INVE02 INNER JOIN SAE60Empre02.dbo.PRECIO_X_PROD02 ON ")
                query_par_compc.Append("SAE60Empre02.dbo.INVE02.CVE_ART = SAE60Empre02.dbo.PRECIO_X_PROD02.CVE_ART ")
                query_par_compc.Append("WHERE (SAE60Empre02.dbo.PRECIO_X_PROD02.CVE_PRECIO = 1) AND (SAE60Empre02.dbo.INVE02.CVE_ART = @CVE_ART)),0), @COST, 0, 0, 0, ")
                query_par_compc.Append("   @IMPU4, 0, 0, 0, 0, 0, 0, ")
                query_par_compc.Append("   0, @TOTIMP4, @DESCU, 'S', 1, @UNI_VENTA, 'N', ")
                query_par_compc.Append("   'P', 0,0,@E_LTPD,@FACTCONV, @COST_DEV, @NUM_ALM, ")
                query_par_compc.Append("   0, (SELECT ULT_CVE + 1 FROM SAE60EMPRE02.dbo.TBLCONTROL02 WHERE (ID_TABLA = 44)),@TOT_PARTIDA)")

                Dim comando_par_compc As New SqlCommand(query_par_compc.ToString, sql_con)
                comando_par_compc.Parameters.AddWithValue("@CVE_DOC", CVE_DOC)
                comando_par_compc.Parameters.AddWithValue("@NUM_PAR", index + 1)
                comando_par_compc.Parameters.AddWithValue("@CVE_ART", dt_p.Rows(index)(1))
                comando_par_compc.Parameters.AddWithValue("@CANT", Convert.ToDouble(dt_p.Rows(index)(4)))

                Dim cant_insertar As Double = 0
                Dim factor_conversion As Integer = 0
                Dim costo_insertar As Double = 0
                If dt_p.Rows(index)(0) = "cj" Then
                    cant_insertar = Convert.ToDouble(dt_p.Rows(index)(4)) * dt_p.Rows(index)(3)
                    costo_insertar = dt_p.Rows(index)(13) * dt_p.Rows(index)(3)
                    factor_conversion = dt_p.Rows(index)(3)
                ElseIf dt_p.Rows(index)(0) = "pz" Then
                    cant_insertar = Convert.ToDouble(dt_p.Rows(index)(4))
                    costo_insertar = dt_p.Rows(index)(13)
                    factor_conversion = 1
                End If

                comando_par_compc.Parameters.AddWithValue("@PXR", cant_insertar)
                comando_par_compc.Parameters.AddWithValue("@COST", costo_insertar)
                comando_par_compc.Parameters.AddWithValue("@IMPU4", dt_p.Rows(index)(8))
                comando_par_compc.Parameters.AddWithValue("@TOTIMP4", Convert.ToDouble(dt_p.Rows(index)(11)))
                comando_par_compc.Parameters.AddWithValue("@DESCU", 0) 'dt_p.Rows(index)(7))
                comando_par_compc.Parameters.AddWithValue("@UNI_VENTA", dt_p.Rows(index)(0))

                If dt_p.Rows(index)(20) = "S" Then
                    comando_par_compc.Parameters.AddWithValue("@E_LTPD", correlativo_lote)
                Else
                    comando_par_compc.Parameters.AddWithValue("@E_LTPD", 0)
                End If

                comando_par_compc.Parameters.AddWithValue("@FACTCONV", factor_conversion)
                comando_par_compc.Parameters.AddWithValue("@COST_DEV", dt_p.Rows(index)(13) * dt_p.Rows(index)(3))
                comando_par_compc.Parameters.AddWithValue("@NUM_ALM", dt_e.Rows(0)(2))
                comando_par_compc.Parameters.AddWithValue("@TOT_PARTIDA", Convert.ToDouble(dt_p.Rows(index)(12)) - Convert.ToDouble(dt_p.Rows(index)(11)))
                comando_par_compc.Transaction = mi_transaccion
                comando_par_compc.ExecuteNonQuery()

                Dim query_par_comp_clib As New StringBuilder
                query_par_comp_clib.Append("INSERT INTO [SAE60Empre02].[dbo].[PAR_COMPC_CLIB02] ")
                query_par_comp_clib.Append("   ([CLAVE_DOC],[NUM_PART]) ")
                query_par_comp_clib.Append("VALUES ")
                query_par_comp_clib.Append("   (@CLAVE_DOC,@NUM_PART) ")
                Dim comando_par_comp_clib As New SqlCommand(query_par_comp_clib.ToString, sql_con)
                comando_par_comp_clib.Parameters.AddWithValue("@CLAVE_DOC", CVE_DOC)
                comando_par_comp_clib.Parameters.AddWithValue("@NUM_PART", index + 1)
                comando_par_comp_clib.Transaction = mi_transaccion
                comando_par_comp_clib.ExecuteNonQuery()

                Dim query_costo_prom As New StringBuilder
                query_costo_prom.Append("SELECT ISNULL(EXIST,0),ISNULL(COSTO_PROM,0) FROM SAE60EMPRE02.dbo.INVE02 WHERE CVE_ART = @CVE_ART")
                Dim comando_costo_prom As New SqlCommand(query_costo_prom.ToString, sql_con)
                comando_costo_prom.Parameters.AddWithValue("@CVE_ART", dt_p.Rows(index)(1))
                comando_costo_prom.Transaction = mi_transaccion
                Dim adaptador_costo As New SqlDataAdapter(comando_costo_prom)
                Dim dt_costo_prom As New DataTable
                adaptador_costo.Fill(dt_costo_prom)
                Dim existencias_viejas As Double = 0, costo_prom_viejo As Double = 0
                existencias_viejas = dt_costo_prom.Rows(0)(0)
                costo_prom_viejo = dt_costo_prom.Rows(0)(1)

                Dim costo_prom_nuevo As Double = 0
                costo_prom_nuevo = ((existencias_viejas * costo_prom_viejo) + (cant_insertar * dt_p.Rows(index)(13))) / (existencias_viejas + cant_insertar)

                Dim query_upd_inve As New StringBuilder
                query_upd_inve.Append("UPDATE SAE60EMPRE02.dbo.INVE02 ")
                query_upd_inve.Append("SET [EXIST] = (EXIST + @NUEVA_EXISTENCIA), ")
                query_upd_inve.Append("FCH_ULTCOM = @FECHA_ULTCOM, COSTO_PROM = @COSTO_PROM, ULT_COSTO = @ULT_COSTO ")
                query_upd_inve.Append("WHERE [CVE_ART] = @CVE_ART ")
                Dim comando_upd_inve As New SqlCommand(query_upd_inve.ToString, sql_con)
                comando_upd_inve.Parameters.AddWithValue("@NUEVA_EXISTENCIA", cant_insertar)
                comando_upd_inve.Parameters.AddWithValue("@FECHA_ULTCOM", Now.Date)
                comando_upd_inve.Parameters.AddWithValue("@COSTO_PROM", costo_prom_nuevo)
                comando_upd_inve.Parameters.AddWithValue("@ULT_COSTO", dt_p.Rows(index)(13))
                comando_upd_inve.Parameters.AddWithValue("@CVE_ART", dt_p.Rows(index)(1))
                comando_upd_inve.Transaction = mi_transaccion
                comando_upd_inve.ExecuteNonQuery()

                Dim query_upd_mult As New StringBuilder
                query_upd_mult.Append("UPDATE SAE60EMPRE02.dbo.MULT02 ")
                query_upd_mult.Append("SET [EXIST] = (EXIST + @NUEVA_EXISTENCIA) ")
                query_upd_mult.Append("WHERE  [CVE_ART] = @CVE_ART AND [CVE_ALM] = @CVE_ALM ")
                Dim comando_upd_mult As New SqlCommand(query_upd_mult.ToString, sql_con)
                comando_upd_mult.Parameters.AddWithValue("@NUEVA_EXISTENCIA", cant_insertar)
                comando_upd_mult.Parameters.AddWithValue("@CVE_ART", dt_p.Rows(index)(1))
                comando_upd_mult.Parameters.AddWithValue("@CVE_ALM", dt_e.Rows(0)(2))
                comando_upd_mult.Transaction = mi_transaccion
                comando_upd_mult.ExecuteNonQuery()

                If dt_p.Rows(index)(20) = "S" Then
                    Dim query_reg_lote As New StringBuilder
                    query_reg_lote.Append("SELECT (ULT_CVE + 1) AS ULT_CVE ")
                    query_reg_lote.Append("FROM SAE60EMPRE02.dbo.TBLCONTROL02 ")
                    query_reg_lote.Append("WHERE (ID_TABLA = 48) ")
                    Dim comando_reg_lote As New SqlCommand(query_reg_lote.ToString, sql_con)
                    comando_reg_lote.Transaction = mi_transaccion
                    Dim adaptador_reg_lote As New SqlDataAdapter(comando_reg_lote)
                    Dim dt_reg_lote As New DataTable
                    adaptador_reg_lote.Fill(dt_reg_lote)
                    Dim reg_lote As Integer
                    reg_lote = dt_reg_lote.Rows(0)(0)

                    Dim query_ltpd As New StringBuilder
                    query_ltpd.Append("INSERT INTO [SAE60Empre02].[dbo].[LTPD02] ")
                    query_ltpd.Append("   ([CVE_ART],[LOTE],[PEDIMENTO],[CVE_ALM] ")
                    query_ltpd.Append("   ,[FCHULTMOV],[NOM_ADUAN],[CANTIDAD],[REG_LTPD],[CVE_OBS] ")
                    query_ltpd.Append("   ,[CIUDAD],[FRONTERA],[GLN],[STATUS]) ")
                    query_ltpd.Append("VALUES ")
                    query_ltpd.Append("   (@CVE_ART,@LOTE,'',@CVE_ALM,@FCHULTMOV, ")
                    query_ltpd.Append("'', @CANTIDAD, @REG_LTPD, 0, '', '', '','A')")
                    Dim comando_ltpd As New SqlCommand(query_ltpd.ToString, sql_con)
                    comando_ltpd.Parameters.AddWithValue("@CVE_ART", dt_p.Rows(index)(1))
                    Dim codigo_lote As String = ""

                    If conlote = "S" Then
                        codigo_lote = lote
                    Else
                        codigo_lote = CVE_DOC
                    End If

                    comando_ltpd.Parameters.AddWithValue("@LOTE", codigo_lote)
                    comando_ltpd.Parameters.AddWithValue("@CVE_ALM", dt_e.Rows(0)(2))
                    comando_ltpd.Parameters.AddWithValue("@FCHULTMOV", Now.Date)
                    comando_ltpd.Parameters.AddWithValue("@CANTIDAD", cant_insertar)
                    comando_ltpd.Parameters.AddWithValue("@REG_LTPD", reg_lote)
                    comando_ltpd.Transaction = mi_transaccion
                    comando_ltpd.ExecuteNonQuery()

                    Dim query_enlace_ltpd As New StringBuilder
                    query_enlace_ltpd.Append("INSERT INTO [SAE60Empre02].[dbo].[ENLACE_LTPD02] ")
                    query_enlace_ltpd.Append("   ([E_LTPD],[REG_LTPD],[CANTIDAD],[PXRS]) ")
                    query_enlace_ltpd.Append("VALUES ")
                    query_enlace_ltpd.Append("   (@E_LTPD,@REG_LTPD, @CANTIDAD,@PXRS)")
                    Dim comando_enlace_ltpd As New SqlCommand(query_enlace_ltpd.ToString, sql_con)
                    comando_enlace_ltpd.Parameters.AddWithValue("@E_LTPD", correlativo_lote)
                    comando_enlace_ltpd.Parameters.AddWithValue("@REG_LTPD", reg_lote)
                    comando_enlace_ltpd.Parameters.AddWithValue("@CANTIDAD", cant_insertar)
                    comando_enlace_ltpd.Parameters.AddWithValue("@PXRS", cant_insertar)
                    comando_enlace_ltpd.Transaction = mi_transaccion
                    comando_enlace_ltpd.ExecuteNonQuery()

                    Dim query_upd_correlativo_lote As New StringBuilder
                    query_upd_correlativo_lote.Append("UPDATE [SAE60Empre02].[dbo].[TBLCONTROL02] ")
                    query_upd_correlativo_lote.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                    query_upd_correlativo_lote.Append("WHERE([ID_TABLA] = 67)")
                    Dim comando_upd_correlativo_lote As New SqlCommand(query_upd_correlativo_lote.ToString, sql_con)
                    comando_upd_correlativo_lote.Transaction = mi_transaccion
                    comando_upd_correlativo_lote.ExecuteNonQuery()

                    Dim query_upd_reg_lote As New StringBuilder
                    query_upd_reg_lote.Append("UPDATE [SAE60Empre02].[dbo].[TBLCONTROL02] ")
                    query_upd_reg_lote.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                    query_upd_reg_lote.Append("WHERE([ID_TABLA] = 48)")
                    Dim comando_upd_reg_lote As New SqlCommand(query_upd_reg_lote.ToString, sql_con)
                    comando_upd_reg_lote.Transaction = mi_transaccion
                    comando_upd_reg_lote.ExecuteNonQuery()
                End If


                Dim query_minve As New StringBuilder
                query_minve.Append("INSERT INTO [SAE60Empre02].[dbo].[MINVE02] ")
                query_minve.Append("   ([CVE_ART],[ALMACEN],[NUM_MOV],[CVE_CPTO],[FECHA_DOCU] ")
                query_minve.Append("   ,[TIPO_DOC],[REFER],[CLAVE_CLPV],[VEND],[CANT],[CANT_COST] ")
                query_minve.Append("   ,[PRECIO],[COSTO],[REG_SERIE],[UNI_VENTA] ")
                query_minve.Append("   ,[E_LTPD],[EXIST_G],[EXISTENCIA],[FACTOR_CON] ")
                query_minve.Append("   ,[FECHAELAB],[CVE_FOLIO],[SIGNO],[COSTEADO],[COSTO_PROM_INI] ")
                query_minve.Append("   ,[COSTO_PROM_FIN],[COSTO_PROM_GRAL],[DESDE_INVE],[MOV_ENLAZADO]) ")
                query_minve.Append("VALUES ")
                query_minve.Append("   (@CVE_ART, @ALMACEN,(SELECT ULT_CVE+1 FROM SAE60EMPRE02.dbo.TBLCONTROL02 WHERE (ID_TABLA = 44)),1,@FECHA_DOCU, 'c', @REFER, ")
                query_minve.Append("   @CLAVE_CLPV, '',@CANT, 0, 0, @COSTO,  ")
                query_minve.Append("   0,@UNI_VENTA, @E_LTPD,@CANT+ISNULL((SELECT EXIST FROM SAE60EMPRE02.dbo.INVE02 WHERE (CVE_ART = @CVE_ART)),0), ((SELECT EXIST FROM SAE60EMPRE02.dbo.MULT02 WHERE (CVE_ART = @CVE_ART) AND CVE_ALM = @ALMACEN)), @FACTOR_CON, ")
                query_minve.Append("   @FECHAELAB, (SELECT ULT_CVE+1 FROM SAE60EMPRE02.dbo.TBLCONTROL02 WHERE (ID_TABLA = 32)),'1','S', @COSTO_PROM_INI,@COSTO_PROM_FIN, ")
                query_minve.Append("   @COSTO_PROM_GRAL,'N',0)")
                Dim comando_minve As New SqlCommand(query_minve.ToString, sql_con)
                comando_minve.Parameters.AddWithValue("@CVE_ART", dt_p.Rows(index)(1))
                comando_minve.Parameters.AddWithValue("@ALMACEN", dt_e.Rows(0)(2))
                comando_minve.Parameters.AddWithValue("@FECHA_DOCU", Convert.ToDateTime(dt_e.Rows(0)(5)))
                comando_minve.Parameters.AddWithValue("@REFER", CVE_DOC)
                comando_minve.Parameters.AddWithValue("@CLAVE_CLPV", dt_e.Rows(0)(0))
                comando_minve.Parameters.AddWithValue("@CANT", cant_insertar)
                comando_minve.Parameters.AddWithValue("@COSTO", dt_p.Rows(index)(13))
                comando_minve.Parameters.AddWithValue("@UNI_VENTA", dt_p.Rows(index)(0))
                If dt_p.Rows(index)(20) = "S" Then
                    comando_minve.Parameters.AddWithValue("@E_LTPD", correlativo_lote)
                Else
                    comando_minve.Parameters.AddWithValue("@E_LTPD", 0)
                End If

                comando_minve.Parameters.AddWithValue("@FACTOR_CON", factor_conversion)
                comando_minve.Parameters.AddWithValue("@FECHAELAB", Convert.ToDateTime(dt_e.Rows(0)(5)))
                comando_minve.Parameters.AddWithValue("@COSTO_PROM_INI", costo_prom_viejo)
                comando_minve.Parameters.AddWithValue("@COSTO_PROM_FIN", costo_prom_nuevo)
                comando_minve.Parameters.AddWithValue("@COSTO_PROM_GRAL", costo_prom_nuevo)
                comando_minve.Transaction = mi_transaccion
                comando_minve.ExecuteNonQuery()

                Dim query_num_mov_minve As New StringBuilder
                query_num_mov_minve.Append("UPDATE [SAE60Empre02].[dbo].[TBLCONTROL02] ")
                query_num_mov_minve.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                query_num_mov_minve.Append("WHERE ([ID_TABLA] = 44)")
                Dim comando_num_mov_minve As New SqlCommand(query_num_mov_minve.ToString, sql_con)
                comando_num_mov_minve.Transaction = mi_transaccion
                comando_num_mov_minve.ExecuteNonQuery()

                Dim query_upd_folio_minve As New StringBuilder
                query_upd_folio_minve.Append("UPDATE SAE60EMPRE02.dbo.TBLCONTROL02 ")
                query_upd_folio_minve.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                query_upd_folio_minve.Append("WHERE (ID_TABLA = 32) ")
                Dim comando_upd_folio_minve As New SqlCommand(query_upd_folio_minve.ToString, sql_con)
                comando_upd_folio_minve.Transaction = mi_transaccion
                comando_upd_folio_minve.ExecuteNonQuery()
            Next

            'fin del for

            Dim query_paga_m As New StringBuilder
            query_paga_m.Append("INSERT INTO [SAE60Empre02].[dbo].[PAGA_M02] ")
            query_paga_m.Append("   ([CVE_PROV],[REFER],[NUM_CARGO],[NUM_CPTO],[CVE_OBS] ")
            query_paga_m.Append("   ,[NO_FACTURA],[DOCTO],[IMPORTE],[FECHA_APLI],[FECHA_VENC],[AFEC_COI] ")
            query_paga_m.Append("   ,[NUM_MONED],[TCAMBIO],[IMPMON_EXT],[FECHAELAB],[TIPO_MOV] ")
            query_paga_m.Append("   ,[SIGNO],[USUARIO],[STATUS]) ")
            query_paga_m.Append("VALUES ")
            query_paga_m.Append("   (@CVE_PROV, @REFER, 1, 1, 0, @NO_FACTURA, ")
            query_paga_m.Append("   @DOCTO,@IMPORTE,@FECHA_APLI, @FECHA_VENC, 'A',1, 1, ")
            query_paga_m.Append("   @IMPMON_EXT,@FECHAELAB, 'C', 1, ")
            query_paga_m.Append("   @USUARIO, 'A')")
            Dim comando_paga_m As New SqlCommand(query_paga_m.ToString, sql_con)
            comando_paga_m.Parameters.AddWithValue("@CVE_PROV", dt_e.Rows(0)(0))
            comando_paga_m.Parameters.AddWithValue("@REFER", CVE_DOC)
            comando_paga_m.Parameters.AddWithValue("@DOCTO", CVE_DOC)
            comando_paga_m.Parameters.AddWithValue("@NO_FACTURA", dt_e.Rows(0)(3))
            comando_paga_m.Parameters.AddWithValue("@IMPORTE", dt_e.Rows(0)(10))
            comando_paga_m.Parameters.AddWithValue("@FECHA_APLI", Convert.ToDateTime(dt_e.Rows(0)(5)))
            comando_paga_m.Parameters.AddWithValue("@FECHA_VENC", Convert.ToDateTime(dt_e.Rows(0)(5)).AddDays(dias_cred))
            comando_paga_m.Parameters.AddWithValue("@IMPMON_EXT", dt_e.Rows(0)(10))
            comando_paga_m.Parameters.AddWithValue("@FECHAELAB", Convert.ToDateTime(dt_e.Rows(0)(5)))
            comando_paga_m.Parameters.AddWithValue("@USUARIO", 0)
            comando_paga_m.Transaction = mi_transaccion
            comando_paga_m.ExecuteNonQuery()

            Dim query_upd_prov As New StringBuilder
            query_upd_prov.Append("UPDATE [SAE60Empre02].[dbo].[PROV02] ")
            query_upd_prov.Append("SET [ULT_COMPD] = @ULT_COMPD ")
            query_upd_prov.Append(",[ULT_COMPM] =@ULT_COMPM ")
            query_upd_prov.Append(",[ULT_COMPF] =@ULT_COMPF ")
            query_upd_prov.Append(",[SALDO] = SALDO + @SALDO ")
            query_upd_prov.Append("WHERE([CLAVE] = @CLAVE)")
            Dim comando_upd_prov As New SqlCommand(query_upd_prov.ToString, sql_con)
            comando_upd_prov.Parameters.AddWithValue("@ULT_COMPD", CVE_DOC)
            comando_upd_prov.Parameters.AddWithValue("@ULT_COMPM", dt_e.Rows(0)(10))
            comando_upd_prov.Parameters.AddWithValue("@ULT_COMPF", Convert.ToDateTime(dt_e.Rows(0)(5)))
            comando_upd_prov.Parameters.AddWithValue("@SALDO", dt_e.Rows(0)(10))
            comando_upd_prov.Parameters.AddWithValue("@CLAVE", dt_e.Rows(0)(0))
            comando_upd_prov.Transaction = mi_transaccion
            comando_upd_prov.ExecuteNonQuery()

            Dim query_cve_docto_upd As New StringBuilder
            query_cve_docto_upd.Append("UPDATE [SAE60Empre02].[dbo].[FOLIOSC02] ")
            query_cve_docto_upd.Append("SET [ULT_DOC] = ULT_DOC + 1 , ")
            query_cve_docto_upd.Append("[FECH_ULT_DOC] = @FECH_ULT_DOC ")
            query_cve_docto_upd.Append("WHERE (TIP_DOC = 'c') AND (SERIE = @SERIE)")
            Dim comando_cve_docto_upd As New SqlCommand(query_cve_docto_upd.ToString, sql_con)
            comando_cve_docto_upd.Parameters.AddWithValue("@FECH_ULT_DOC", Convert.ToDateTime(dt_e.Rows(0)(5)))
            comando_cve_docto_upd.Parameters.AddWithValue("@SERIE", serie)
            comando_cve_docto_upd.Transaction = mi_transaccion
            comando_cve_docto_upd.ExecuteNonQuery()

            Dim conexion_bita As New cls_bitacora_reporteador
            conexion_bita.RegistraBitacora(Now, usuario, "Ingreso de Compra Nacional SR Agro", "COMPRAS", _
                                      "Fecha: " + Convert.ToDateTime(dt_e.Rows(0)(5)) + " Numero de Compra SAE: " + CVE_DOC + _
                                      " Numero de Compra Rep:" + CVE_COMPRA + " almacen:" + dt_e.Rows(0)(2))
            mi_transaccion.Commit()
            sql_con.Close()
            Return "correcto"
        Catch ex As Exception
            mi_transaccion.Rollback()
            sql_con.Close()
            Dim tamaño As Integer = Convert.ToString(ex.StackTrace).Length
            Dim posicion As Integer = InStrRev(Convert.ToString(ex.StackTrace), "línea") - 1
            Dim inicial As Integer = tamaño - posicion
            Dim linea_error As String = Convert.ToString(ex.StackTrace).Substring(tamaño - inicial, inicial)
            Return (ex.Message + " --> " + linea_error)
        End Try
    End Function

    Public Function guardar_compras_local(ByVal dt_e As DataTable, ByVal dt_p As DataTable) As String
        Dim sql_con As New SqlConnection(conexion.CadenaSQL)
        Dim mi_transaccion As SqlTransaction
        sql_con.Open()
        mi_transaccion = sql_con.BeginTransaction

        Try
            Dim query_codigo As New StringBuilder
            query_codigo.Append("SELECT FOLIO + CONVERT(VARCHAR, ULT_DOC + 1) AS CLAVE ")
            query_codigo.Append("FROM nd_folios ")
            query_codigo.Append("WHERE (NUM_ALMA = @ALMACEN) AND (TIPO = 'C')")
            Dim comando_codigo As New SqlCommand(query_codigo.ToString, sql_con)
            comando_codigo.Parameters.AddWithValue("@ALMACEN", dt_e.Rows(0)(2))
            comando_codigo.Transaction = mi_transaccion
            Dim dt As New DataTable
            Dim adaptador_codigo As New SqlDataAdapter(comando_codigo)
            adaptador_codigo.Fill(dt)
            Dim CVE_COMPRA As String = ""
            CVE_COMPRA = dt.Rows(0)(0)

            Dim query_e_local As New StringBuilder
            query_e_local.Append("INSERT INTO [tactical_discount_sragro].[dbo].[nd_compras_e] ")
            query_e_local.Append("       ([CVE_COMPRA],[CVE_PROVEEDOR],[PROVEEDOR],[ALMACEN],[REF_PROV], ")
            query_e_local.Append("       [RFC],[FECHA],[DESCUENTO_POR],[SUB_TOTAL],[DESCUENTO_VAL],[ISV_VAL], ")
            query_e_local.Append("       [TOTAL],[ESTADO],[SUBTOTAL_MOST],[DESC_MOST],[ISV_MOST],[TOTAL_MOST],[FECHA_FACTURA]) ")
            query_e_local.Append(" VALUES ")
            query_e_local.Append("       (@CVE_COMPRA,@CVE_PROVEEDOR,@PROVEEDOR,@ALMACEN ")
            query_e_local.Append("       ,@REF_PROV,@RFC,@FECHA,@DESCUENTO_POR,@SUB_TOTAL ")
            query_e_local.Append("       ,@DESCUENTO_VAL,@ISV_VAL,@TOTAL,@ESTADO ")
            query_e_local.Append("       ,@SUBTOTAL_MOST,@DESC_MOST,@ISV_MOST,@TOTAL_MOST,@FECHA_FACTURA)")

            Dim comando_e_local As New SqlCommand(query_e_local.ToString, sql_con)
            comando_e_local.Parameters.AddWithValue("@CVE_COMPRA", CVE_COMPRA)
            comando_e_local.Parameters.AddWithValue("@CVE_PROVEEDOR", dt_e.Rows(0)(0))
            comando_e_local.Parameters.AddWithValue("@PROVEEDOR", dt_e.Rows(0)(1))
            comando_e_local.Parameters.AddWithValue("@ALMACEN ", dt_e.Rows(0)(2))
            comando_e_local.Parameters.AddWithValue("@REF_PROV", dt_e.Rows(0)(3))
            comando_e_local.Parameters.AddWithValue("@RFC", dt_e.Rows(0)(4))
            comando_e_local.Parameters.AddWithValue("@FECHA", Convert.ToDateTime(dt_e.Rows(0)(5)))
            comando_e_local.Parameters.AddWithValue("@DESCUENTO_POR", dt_e.Rows(0)(6))
            comando_e_local.Parameters.AddWithValue("@SUB_TOTAL", dt_e.Rows(0)(7))
            comando_e_local.Parameters.AddWithValue("@DESCUENTO_VAL", dt_e.Rows(0)(8))
            comando_e_local.Parameters.AddWithValue("@ISV_VAL", dt_e.Rows(0)(9))
            comando_e_local.Parameters.AddWithValue("@TOTAL", dt_e.Rows(0)(10))
            comando_e_local.Parameters.AddWithValue("@ESTADO", dt_e.Rows(0)(11))
            comando_e_local.Parameters.AddWithValue("@SUBTOTAL_MOST", dt_e.Rows(0)(12))
            comando_e_local.Parameters.AddWithValue("@DESC_MOST", dt_e.Rows(0)(13))
            comando_e_local.Parameters.AddWithValue("@ISV_MOST", dt_e.Rows(0)(14))
            comando_e_local.Parameters.AddWithValue("@TOTAL_MOST", dt_e.Rows(0)(15))
            comando_e_local.Parameters.AddWithValue("@FECHA_FACTURA", Convert.ToDateTime(dt_e.Rows(0)(16)))
            comando_e_local.Transaction = mi_transaccion
            comando_e_local.ExecuteNonQuery()

            For index As Integer = 0 To dt_p.Rows.Count - 1
                Dim query_p_local As New StringBuilder
                query_p_local.Append("INSERT INTO [tactical_discount_sragro].[dbo].[nd_compras_p] ")
                query_p_local.Append("([CVE_COMPRA],[NUM_PART],[UNI],[CVE_ART],[PRODUCTO] ")
                query_p_local.Append(",[FACT_CONV],[CANTIDAD],[PRECIO_NEG],[PRECIO_FINAL] ")
                query_p_local.Append(",[DESC_PROD],[ISV_PROD],[SUB_TOTAL],[DESCUENTO] ")
                query_p_local.Append(",[ISV],[TOTAL_PARTIDA],[PRECIO_INSERTAR],[AJUSTE],  ")
                query_p_local.Append("[SUBTOTAL_MOST],[DESC_MOST],[ISV_MOST],[TOTAL_MOST],[CON_LOTE]) ")
                query_p_local.Append("VALUES ")
                query_p_local.Append("(@CVE_COMPRA,@NUM_PART,@UNI,@CVE_ART,@PRODUCTO, ")
                query_p_local.Append("@FACT_CONV,@CANTIDAD,@PRECIO_NEG,@PRECIO_FINAL, ")
                query_p_local.Append("@DESC_PROD,@ISV_PROD,@SUB_TOTAL,@DESCUENTO, ")
                query_p_local.Append("@ISV,@TOTAL_PARTIDA,@PRECIO_INSERTAR,@AJUSTE, ")
                query_p_local.Append(" @SUBTOTAL_MOST, @DESC_MOST,@ISV_MOST,@TOTAL_MOST,@CON_LOTE) ")
                Dim comando_p_local As New SqlCommand(query_p_local.ToString, sql_con)

                comando_p_local.Parameters.AddWithValue("@CVE_COMPRA", CVE_COMPRA)
                comando_p_local.Parameters.AddWithValue("@NUM_PART", index + 1)
                comando_p_local.Parameters.AddWithValue("@UNI", dt_p.Rows(index)(0))
                comando_p_local.Parameters.AddWithValue("@CVE_ART", dt_p.Rows(index)(1))
                comando_p_local.Parameters.AddWithValue("@PRODUCTO", dt_p.Rows(index)(2))
                comando_p_local.Parameters.AddWithValue("@FACT_CONV", dt_p.Rows(index)(3))
                comando_p_local.Parameters.AddWithValue("@CANTIDAD", Convert.ToDouble(dt_p.Rows(index)(4)))
                comando_p_local.Parameters.AddWithValue("@PRECIO_NEG", dt_p.Rows(index)(5))
                comando_p_local.Parameters.AddWithValue("@PRECIO_FINAL", dt_p.Rows(index)(6))
                comando_p_local.Parameters.AddWithValue("@DESC_PROD", dt_p.Rows(index)(7))
                comando_p_local.Parameters.AddWithValue("@ISV_PROD", dt_p.Rows(index)(8))
                comando_p_local.Parameters.AddWithValue("@SUB_TOTAL", Convert.ToDouble(dt_p.Rows(index)(9)))
                comando_p_local.Parameters.AddWithValue("@DESCUENTO", Convert.ToDouble(dt_p.Rows(index)(10)))
                comando_p_local.Parameters.AddWithValue("@ISV", Convert.ToDouble(dt_p.Rows(index)(11)))
                comando_p_local.Parameters.AddWithValue("@TOTAL_PARTIDA", Convert.ToDouble(dt_p.Rows(index)(12)))
                comando_p_local.Parameters.AddWithValue("@PRECIO_INSERTAR", dt_p.Rows(index)(13))
                comando_p_local.Parameters.AddWithValue("@AJUSTE", dt_p.Rows(index)(14))

                comando_p_local.Parameters.AddWithValue("@SUBTOTAL_MOST", dt_p.Rows(index)(16))
                comando_p_local.Parameters.AddWithValue("@DESC_MOST", dt_p.Rows(index)(17))
                comando_p_local.Parameters.AddWithValue("@ISV_MOST", dt_p.Rows(index)(18))
                comando_p_local.Parameters.AddWithValue("@TOTAL_MOST", dt_p.Rows(index)(19))
                comando_p_local.Parameters.AddWithValue("@CON_LOTE", dt_p.Rows(index)(20))
                comando_p_local.Transaction = mi_transaccion
                comando_p_local.ExecuteNonQuery()
            Next

            Dim query_upd_codigo As New StringBuilder
            query_upd_codigo.Append("UPDATE [tactical_discount_sragro].[dbo].[nd_folios] ")
            query_upd_codigo.Append("SET [ULT_DOC] = ULT_DOC + 1 ")
            query_upd_codigo.Append("WHERE ([NUM_ALMA] = @NUM_ALMA And [TIPO] = 'C') ")
            Dim comando_upd_codigo As New SqlCommand(query_upd_codigo.ToString, sql_con)
            comando_upd_codigo.Parameters.AddWithValue("@NUM_ALMA", dt_e.Rows(0)(2))
            comando_upd_codigo.Transaction = mi_transaccion
            comando_upd_codigo.ExecuteNonQuery()
            'fin de las compras locales
            mi_transaccion.Commit()
            sql_con.Close()
            Return "correcto"
        Catch ex As Exception
            mi_transaccion.Rollback()
            sql_con.Close()
            Dim tamaño As Integer = Convert.ToString(ex.StackTrace).Length
            Dim posicion As Integer = InStrRev(Convert.ToString(ex.StackTrace), "línea") - 1
            Dim inicial As Integer = tamaño - posicion
            Dim linea_error As String = Convert.ToString(ex.StackTrace).Substring(tamaño - inicial, inicial)
            Return (ex.Message + " --> " + linea_error)
        End Try
    End Function

    Public Function guardar_importacion_local(ByVal dt_e As DataTable, ByVal dt_p As DataTable, ByVal agente As String) As String
        Dim con_sql As New SqlConnection(conexion.CadenaSQL)
        Dim mi_transaccion As SqlTransaction
        con_sql.Open()
        mi_transaccion = con_sql.BeginTransaction

        Try
            Dim query_codigo As New StringBuilder
            query_codigo.Append("SELECT FOLIO + CONVERT(VARCHAR, ULT_DOC + 1) AS CLAVE ")
            query_codigo.Append("FROM nd_folios ")
            query_codigo.Append("WHERE (NUM_ALMA = @ALMACEN) AND (TIPO = 'I')")
            Dim comando_codigo As New SqlCommand(query_codigo.ToString, con_sql)
            comando_codigo.Parameters.AddWithValue("@ALMACEN", dt_e.Rows(0)(2))
            comando_codigo.Transaction = mi_transaccion
            Dim dt As New DataTable
            Dim adaptador_codigo As New SqlDataAdapter(comando_codigo)
            adaptador_codigo.Fill(dt)
            Dim CVE_COMPRA As String = ""
            CVE_COMPRA = dt.Rows(0)(0)

            Dim query_e_local As New StringBuilder
            query_e_local.Append("INSERT INTO [tactical_discount_sragro].[dbo].[nd_importaciones_e] ")
            query_e_local.Append("       ([CVE_COMPRA],[CVE_PROVEEDOR],[PROVEEDOR],[ALMACEN] ")
            query_e_local.Append("       ,[REF_PROV],[RFC],[FECHA],[DESCUENTO_POR],[SUB_TOTAL] ")
            query_e_local.Append("       ,[DESCUENTO_VAL],[ISV_VAL],[TOTAL],[ESTADO],[TASA_CAMBIO] ")
            query_e_local.Append("       ,[N_FACTURA_SAE], [FLETE],[SEGURO],[PYC],[HONORARIOS],[AGENTE],[FECHA_FACTURA]) ")
            query_e_local.Append(" VALUES ")
            query_e_local.Append("       (@CVE_COMPRA,@CVE_PROVEEDOR,@PROVEEDOR,@ALMACEN ")
            query_e_local.Append("       ,@REF_PROV,@RFC,@FECHA,@DESCUENTO_POR,@SUB_TOTAL ")
            query_e_local.Append("       ,@DESCUENTO_VAL,@ISV_VAL,@TOTAL,@ESTADO,@TASA_CAMBIO ")
            query_e_local.Append("       ,@N_FACTURA_SAE,@FLETE,@SEGURO,@PYC,@HONORARIOS,@AGENTE,@FECHA_FACTURA)")

            Dim comando_e_local As New SqlCommand(query_e_local.ToString, con_sql)
            comando_e_local.Parameters.AddWithValue("@CVE_COMPRA", CVE_COMPRA)
            comando_e_local.Parameters.AddWithValue("@CVE_PROVEEDOR", dt_e.Rows(0)(0))
            comando_e_local.Parameters.AddWithValue("@PROVEEDOR", dt_e.Rows(0)(1))
            comando_e_local.Parameters.AddWithValue("@ALMACEN ", dt_e.Rows(0)(2))
            comando_e_local.Parameters.AddWithValue("@REF_PROV", dt_e.Rows(0)(3))
            comando_e_local.Parameters.AddWithValue("@RFC", dt_e.Rows(0)(4))
            comando_e_local.Parameters.AddWithValue("@FECHA", Convert.ToDateTime(dt_e.Rows(0)(5)))
            comando_e_local.Parameters.AddWithValue("@DESCUENTO_POR", dt_e.Rows(0)(6))
            comando_e_local.Parameters.AddWithValue("@SUB_TOTAL", dt_e.Rows(0)(7))
            comando_e_local.Parameters.AddWithValue("@DESCUENTO_VAL", dt_e.Rows(0)(8))
            comando_e_local.Parameters.AddWithValue("@ISV_VAL", dt_e.Rows(0)(9))
            comando_e_local.Parameters.AddWithValue("@TOTAL", dt_e.Rows(0)(10))
            comando_e_local.Parameters.AddWithValue("@ESTADO", dt_e.Rows(0)(11))
            comando_e_local.Parameters.AddWithValue("@TASA_CAMBIO", dt_e.Rows(0)(12))
            comando_e_local.Parameters.AddWithValue("@N_FACTURA_SAE", "")
            comando_e_local.Parameters.AddWithValue("@FLETE", dt_e.Rows(0)(14))
            comando_e_local.Parameters.AddWithValue("@SEGURO", dt_e.Rows(0)(15))
            comando_e_local.Parameters.AddWithValue("@PYC", dt_e.Rows(0)(16))
            comando_e_local.Parameters.AddWithValue("@HONORARIOS", dt_e.Rows(0)(17))
            comando_e_local.Parameters.AddWithValue("@AGENTE", agente)
            comando_e_local.Parameters.AddWithValue("@FECHA_FACTURA", Convert.ToDateTime(dt_e.Rows(0)(18)))

            comando_e_local.Transaction = mi_transaccion
            comando_e_local.ExecuteNonQuery()

            For index As Integer = 0 To dt_p.Rows.Count - 1
                Dim query_p_local As New StringBuilder
                query_p_local.Append("INSERT INTO [tactical_discount_sragro].[dbo].[nd_importaciones_p] ")
                query_p_local.Append("([CVE_COMPRA],[NUM_PART],[UNI],[CVE_ART],[PRODUCTO] ")
                query_p_local.Append(",[FACT_CONV],[CANTIDAD],[PRECIO_NEG],[PRECIO_FINAL],[PRECIO_NETO] ")
                query_p_local.Append(",[DESC_PROD],[ISV_PROD],[SUB_TOTAL],[DESCUENTO] ")
                query_p_local.Append(",[ISV],[TOTAL_PARTIDA],[PRECIO_INSERTAR],[AJUSTE],[HONORARIOS],[FLETE],[SEGURO],[PYC],[CON_LOTE]) ")
                query_p_local.Append("VALUES ")
                query_p_local.Append("(@CVE_COMPRA,@NUM_PART,@UNI,@CVE_ART,@PRODUCTO, ")
                query_p_local.Append("@FACT_CONV,@CANTIDAD,@PRECIO_NEG,@PRECIO_FINAL,@PRECIO_NETO, ")
                query_p_local.Append("@DESC_PROD,@ISV_PROD,@SUB_TOTAL,@DESCUENTO, ")
                query_p_local.Append("@ISV,@TOTAL_PARTIDA,@PRECIO_INSERTAR,@AJUSTE,@HONORARIOS,@FLETE,@SEGURO,@PYC,@CON_LOTE) ")
                Dim comando_p_local As New SqlCommand(query_p_local.ToString, con_sql)

                comando_p_local.Parameters.AddWithValue("@CVE_COMPRA", CVE_COMPRA)
                comando_p_local.Parameters.AddWithValue("@NUM_PART", index + 1)
                comando_p_local.Parameters.AddWithValue("@UNI", dt_p.Rows(index)(0))
                comando_p_local.Parameters.AddWithValue("@CVE_ART", dt_p.Rows(index)(1))
                comando_p_local.Parameters.AddWithValue("@PRODUCTO", dt_p.Rows(index)(2))
                comando_p_local.Parameters.AddWithValue("@FACT_CONV", dt_p.Rows(index)(3))
                comando_p_local.Parameters.AddWithValue("@CANTIDAD", Convert.ToDouble(dt_p.Rows(index)(4)))
                comando_p_local.Parameters.AddWithValue("@PRECIO_NEG", dt_p.Rows(index)(5))
                comando_p_local.Parameters.AddWithValue("@PRECIO_FINAL", dt_p.Rows(index)(6))
                comando_p_local.Parameters.AddWithValue("@PRECIO_NETO", dt_p.Rows(index)(7))
                comando_p_local.Parameters.AddWithValue("@DESC_PROD", dt_p.Rows(index)(8))
                comando_p_local.Parameters.AddWithValue("@ISV_PROD", dt_p.Rows(index)(9))
                comando_p_local.Parameters.AddWithValue("@SUB_TOTAL", Convert.ToDouble(dt_p.Rows(index)(10)))
                comando_p_local.Parameters.AddWithValue("@DESCUENTO", Convert.ToDouble(dt_p.Rows(index)(11)))
                comando_p_local.Parameters.AddWithValue("@ISV", Convert.ToDouble(dt_p.Rows(index)(12)))
                comando_p_local.Parameters.AddWithValue("@TOTAL_PARTIDA", Convert.ToDouble(dt_p.Rows(index)(13)))
                comando_p_local.Parameters.AddWithValue("@PRECIO_INSERTAR", dt_p.Rows(index)(14))
                comando_p_local.Parameters.AddWithValue("@AJUSTE", dt_p.Rows(index)(15))
                comando_p_local.Parameters.AddWithValue("@HONORARIOS", dt_p.Rows(index)(16))
                comando_p_local.Parameters.AddWithValue("@FLETE", dt_p.Rows(index)(17))
                comando_p_local.Parameters.AddWithValue("@SEGURO", dt_p.Rows(index)(18))
                comando_p_local.Parameters.AddWithValue("@PYC", dt_p.Rows(index)(19))
                comando_p_local.Parameters.AddWithValue("@CON_LOTE", dt_p.Rows(index)(20))

                comando_p_local.Transaction = mi_transaccion
                comando_p_local.ExecuteNonQuery()
            Next

            Dim query_upd_codigo As New StringBuilder
            query_upd_codigo.Append("UPDATE [tactical_discount_sragro].[dbo].[nd_folios] ")
            query_upd_codigo.Append("SET [ULT_DOC] = ULT_DOC + 1 ")
            query_upd_codigo.Append("WHERE ([NUM_ALMA] = @NUM_ALMA And [TIPO] = 'I') ")
            Dim comando_upd_codigo As New SqlCommand(query_upd_codigo.ToString, con_sql)
            comando_upd_codigo.Parameters.AddWithValue("@NUM_ALMA", dt_e.Rows(0)(2))
            comando_upd_codigo.Transaction = mi_transaccion
            comando_upd_codigo.ExecuteNonQuery()
            'fin de las IMPORTACIONES locales
            mi_transaccion.Commit()
            con_sql.Close()
            Return "correcto"
        Catch ex As Exception
            mi_transaccion.Rollback()
            con_sql.Close()
            Dim tamaño As Integer = Convert.ToString(ex.StackTrace).Length
            Dim posicion As Integer = InStrRev(Convert.ToString(ex.StackTrace), "línea") - 1
            Dim inicial As Integer = tamaño - posicion
            Dim linea_error As String = Convert.ToString(ex.StackTrace).Substring(tamaño - inicial, inicial)
            Return (ex.Message + " --> " + linea_error)
        End Try
    End Function

    Public Function guardar_importacion_local_SAE(ByVal dt_e As DataTable, ByVal dt_p As DataTable, _
                                                  ByVal conlote As String, ByVal lote As String, ByVal usuario As String, ByVal agente As String) As String
        Dim sql_con As New SqlConnection(conexion.CadenaSQL)
        Dim mi_transaccion As SqlTransaction
        sql_con.Open()
        mi_transaccion = sql_con.BeginTransaction

        Try
            Dim query_codigo As New StringBuilder
            query_codigo.Append("SELECT FOLIO + CONVERT(VARCHAR, ULT_DOC + 1) AS CLAVE,SERIE ")
            query_codigo.Append("FROM nd_folios ")
            query_codigo.Append("WHERE (NUM_ALMA = @ALMACEN) AND (TIPO = 'I')")
            Dim comando_codigo As New SqlCommand(query_codigo.ToString, sql_con)
            comando_codigo.Parameters.AddWithValue("@ALMACEN", dt_e.Rows(0)(2))
            comando_codigo.Transaction = mi_transaccion
            Dim dt As New DataTable
            Dim adaptador_codigo As New SqlDataAdapter(comando_codigo)
            adaptador_codigo.Fill(dt)
            Dim CVE_COMPRA As String = ""
            Dim serie_local As String = ""
            CVE_COMPRA = dt.Rows(0)(0)
            serie_local = dt.Rows(0)(1)

            Dim query_cve_docto As New StringBuilder
            query_cve_docto.Append("SELECT SERIE, ULT_DOC ")
            query_cve_docto.Append("FROM SAE60EMPRE02.dbo.FOLIOSC02 ")
            query_cve_docto.Append("WHERE (TIP_DOC = 'c') AND (SERIE = @SERIE) ")
            Dim comando_cve_docto As New SqlCommand(query_cve_docto.ToString, sql_con)
            comando_cve_docto.Parameters.AddWithValue("@SERIE", serie_local)
            comando_cve_docto.Transaction = mi_transaccion
            Dim adaptador_cve_docto As New SqlDataAdapter(comando_cve_docto)
            Dim dt_cve_docto As New DataTable
            adaptador_cve_docto.Fill(dt_cve_docto)
            Dim CVE_DOC As String = ""
            Dim serie As String = ""
            Dim folio As Integer
            serie = dt_cve_docto.Rows(0)(0)
            folio = dt_cve_docto.Rows(0)(1) + 1
            CVE_DOC = serie & folio

            For index As Integer = 0 To dt_p.Rows.Count - 1
                Dim query_p_local As New StringBuilder
                query_p_local.Append("INSERT INTO [tactical_discount_sragro].[dbo].[nd_importaciones_p] ")
                query_p_local.Append("([CVE_COMPRA],[NUM_PART],[UNI],[CVE_ART],[PRODUCTO] ")
                query_p_local.Append(",[FACT_CONV],[CANTIDAD],[PRECIO_NEG],[PRECIO_FINAL],[PRECIO_NETO] ")
                query_p_local.Append(",[DESC_PROD],[ISV_PROD],[SUB_TOTAL],[DESCUENTO] ")
                query_p_local.Append(",[ISV],[TOTAL_PARTIDA],[PRECIO_INSERTAR],[AJUSTE],[HONORARIOS],[FLETE],[SEGURO],[PYC],[CON_LOTE]) ")
                query_p_local.Append("VALUES ")
                query_p_local.Append("(@CVE_COMPRA,@NUM_PART,@UNI,@CVE_ART,@PRODUCTO, ")
                query_p_local.Append("@FACT_CONV,@CANTIDAD,@PRECIO_NEG,@PRECIO_FINAL,@PRECIO_NETO, ")
                query_p_local.Append("@DESC_PROD,@ISV_PROD,@SUB_TOTAL,@DESCUENTO, ")
                query_p_local.Append("@ISV,@TOTAL_PARTIDA,@PRECIO_INSERTAR,@AJUSTE,@HONORARIOS,@FLETE,@SEGURO,@PYC,@CON_LOTE) ")
                Dim comando_p_local As New SqlCommand(query_p_local.ToString, sql_con)

                comando_p_local.Parameters.AddWithValue("@CVE_COMPRA", CVE_COMPRA)
                comando_p_local.Parameters.AddWithValue("@NUM_PART", index + 1)
                comando_p_local.Parameters.AddWithValue("@UNI", dt_p.Rows(index)(0))
                comando_p_local.Parameters.AddWithValue("@CVE_ART", dt_p.Rows(index)(1))
                comando_p_local.Parameters.AddWithValue("@PRODUCTO", dt_p.Rows(index)(2))
                comando_p_local.Parameters.AddWithValue("@FACT_CONV", dt_p.Rows(index)(3))
                comando_p_local.Parameters.AddWithValue("@CANTIDAD", Convert.ToDouble(dt_p.Rows(index)(4)))
                comando_p_local.Parameters.AddWithValue("@PRECIO_NEG", dt_p.Rows(index)(5))
                comando_p_local.Parameters.AddWithValue("@PRECIO_FINAL", dt_p.Rows(index)(6))
                comando_p_local.Parameters.AddWithValue("@PRECIO_NETO", dt_p.Rows(index)(7))
                comando_p_local.Parameters.AddWithValue("@DESC_PROD", dt_p.Rows(index)(8))
                comando_p_local.Parameters.AddWithValue("@ISV_PROD", dt_p.Rows(index)(9))
                comando_p_local.Parameters.AddWithValue("@SUB_TOTAL", Convert.ToDouble(dt_p.Rows(index)(10)))
                comando_p_local.Parameters.AddWithValue("@DESCUENTO", Convert.ToDouble(dt_p.Rows(index)(11)))
                comando_p_local.Parameters.AddWithValue("@ISV", Convert.ToDouble(dt_p.Rows(index)(12)))
                comando_p_local.Parameters.AddWithValue("@TOTAL_PARTIDA", Convert.ToDouble(dt_p.Rows(index)(13)))
                comando_p_local.Parameters.AddWithValue("@PRECIO_INSERTAR", dt_p.Rows(index)(14))
                comando_p_local.Parameters.AddWithValue("@AJUSTE", dt_p.Rows(index)(15))
                comando_p_local.Parameters.AddWithValue("@HONORARIOS", dt_p.Rows(index)(16))
                comando_p_local.Parameters.AddWithValue("@FLETE", dt_p.Rows(index)(17))
                comando_p_local.Parameters.AddWithValue("@SEGURO", dt_p.Rows(index)(18))
                comando_p_local.Parameters.AddWithValue("@PYC", dt_p.Rows(index)(19))
                comando_p_local.Parameters.AddWithValue("@CON_LOTE", dt_p.Rows(index)(20))
                comando_p_local.Transaction = mi_transaccion
                comando_p_local.ExecuteNonQuery()
            Next

            Dim query_upd_codigo As New StringBuilder
            query_upd_codigo.Append("UPDATE [tactical_discount_sragro].[dbo].[nd_folios] ")
            query_upd_codigo.Append("SET [ULT_DOC] = ULT_DOC + 1 ")
            query_upd_codigo.Append("WHERE ([NUM_ALMA] = @NUM_ALMA And [TIPO] = 'I') ")
            Dim comando_upd_codigo As New SqlCommand(query_upd_codigo.ToString, sql_con)
            comando_upd_codigo.Parameters.AddWithValue("@NUM_ALMA", dt_e.Rows(0)(2))
            comando_upd_codigo.Transaction = mi_transaccion
            comando_upd_codigo.ExecuteNonQuery()

            'fin de las IMPORTACIONES locales

            Dim ajuste As String = ""
            Dim debito As String = ""
            For index As Integer = 0 To dt_p.Rows.Count - 1
                If dt_p.Rows(index)(15) = "S" Then
                    ajuste = "S"
                End If

                If dt_p.Rows(index)(15) = "D" Then
                    debito = "D"
                End If
            Next

            ' registra los debito por producto
            If ajuste = "S" Then
                Dim query_folio_ajuste As New StringBuilder
                query_folio_ajuste.Append("SELECT FOLIO + CONVERT(VARCHAR, ULT_DOC + 1) AS ULT_DOC ")
                query_folio_ajuste.Append("FROM nd_folios ")
                query_folio_ajuste.Append("WHERE (TIPO = 'A') AND (NUM_ALMA = @ALMACEN)")
                Dim comando_folio_ajuste As New SqlCommand(query_folio_ajuste.ToString, sql_con)
                comando_folio_ajuste.Parameters.AddWithValue("@ALMACEN", dt_e.Rows(0)(2))
                comando_folio_ajuste.Transaction = mi_transaccion
                Dim dt_folio_ajuste As New DataTable
                Dim adaptador_folio_ajuste As New SqlDataAdapter(comando_folio_ajuste)
                adaptador_folio_ajuste.Fill(dt_folio_ajuste)

                Dim subtotal_ajuste_e As Double = 0, isv_ajuste_e As Double = 0, total_ajueste_e As Double = 0, descuento_ajuste_e As Double = 0
                For index As Integer = 0 To dt_p.Rows.Count - 1
                    If dt_p.Rows(index)(15) = "S" Then
                        Dim query_ajuste_p As New StringBuilder
                        query_ajuste_p.Append("INSERT INTO [tactical_discount_sragro].[dbo].[nd_ajuste_p] ")
                        query_ajuste_p.Append("([ID_AJUSTE],[NUM_PART],[CVE_ART],[DESCRIPCION],[MOTIVO],[CANTIDAD], ")
                        query_ajuste_p.Append("[FECHA_INGRESO],[COSTO_ANTERIOR],[COSTO_ACTUAL],[AJUSTE],[UNI]) ")
                        query_ajuste_p.Append("VALUES ")
                        query_ajuste_p.Append("(@ID_AJUSTE,@NUM_PART,@CVE_ART,@DESCRIPCION,@MOTIVO,@CANTIDAD, ")
                        query_ajuste_p.Append("@FECHA_INGRESO,@COSTO_ANTERIOR,@COSTO_ACTUAL,@AJUSTE,@UNI)")
                        Dim comando_ajuste_p As New SqlCommand(query_ajuste_p.ToString, sql_con)
                        comando_ajuste_p.Parameters.AddWithValue("@ID_AJUSTE", dt_folio_ajuste.Rows(0)(0))
                        comando_ajuste_p.Parameters.AddWithValue("@NUM_PART", index + 1)
                        comando_ajuste_p.Parameters.AddWithValue("@CVE_ART", dt_p.Rows(index)(1))
                        comando_ajuste_p.Parameters.AddWithValue("@DESCRIPCION", dt_p.Rows(index)(2))
                        comando_ajuste_p.Parameters.AddWithValue("@MOTIVO", "AJUSTE DE PRECIO")
                        comando_ajuste_p.Parameters.AddWithValue("@CANTIDAD", dt_p.Rows(index)(4))
                        comando_ajuste_p.Parameters.AddWithValue("@FECHA_INGRESO", Convert.ToDateTime(dt_e.Rows(0)(5)))
                        comando_ajuste_p.Parameters.AddWithValue("@COSTO_ANTERIOR", dt_p.Rows(index)(5))
                        comando_ajuste_p.Parameters.AddWithValue("@COSTO_ACTUAL", dt_p.Rows(index)(6))
                        Dim valor_ajuste As Double = 0
                        valor_ajuste = (Convert.ToDouble(dt_p.Rows(index)(4)) * Convert.ToDouble(dt_p.Rows(index)(6))) _
                        - (Convert.ToDouble(dt_p.Rows(index)(4)) * Convert.ToDouble(dt_p.Rows(index)(5)))
                        If dt_p.Rows(index)(0) = "cj" Then
                            valor_ajuste = valor_ajuste * Convert.ToDouble(dt_p.Rows(index)(3))
                        End If
                        comando_ajuste_p.Parameters.AddWithValue("@AJUSTE", valor_ajuste * -1)
                        comando_ajuste_p.Parameters.AddWithValue("@UNI", dt_p.Rows(index)(0))
                        subtotal_ajuste_e += valor_ajuste
                        descuento_ajuste_e += 0 'valor_ajuste '* dt_p.Rows(index)(8) / 100
                        valor_ajuste = valor_ajuste - descuento_ajuste_e
                        isv_ajuste_e += 0 'valor_ajuste * dt_p.Rows(index)(9) / 100
                        comando_ajuste_p.Transaction = mi_transaccion
                        comando_ajuste_p.ExecuteNonQuery()
                    End If
                Next
                total_ajueste_e += subtotal_ajuste_e - descuento_ajuste_e + isv_ajuste_e

                Dim query_ajuste_e As New StringBuilder
                query_ajuste_e.Append("INSERT INTO [tactical_discount_sragro].[dbo].[nd_ajuste_e] ")
                query_ajuste_e.Append("([ID_AJUSTE],[CVE_PROVEEDOR],[ALMACEN],[REF_PROV]")
                query_ajuste_e.Append(",[FECHA],[N_FACTURA],[SUBTOTAL],[DESCUENTO],[ISV],[TOTAL],[COMPRA],[TIPO]) ")
                query_ajuste_e.Append("VALUES ")
                query_ajuste_e.Append("(@ID_AJUSTE,@CVE_PROVEEDOR,@ALMACEN,@REF_PROV,@FECHA, ")
                query_ajuste_e.Append("@N_FACTURA,@SUBTOTAL,@DESCUENTO,@ISV,@TOTAL,@COMPRA,@TIPO)")
                Dim comando_ajuste_e As New SqlCommand(query_ajuste_e.ToString, sql_con)
                comando_ajuste_e.Parameters.AddWithValue("@ID_AJUSTE", dt_folio_ajuste.Rows(0)(0))
                comando_ajuste_e.Parameters.AddWithValue("@CVE_PROVEEDOR", dt_e.Rows(0)(0))
                comando_ajuste_e.Parameters.AddWithValue("@ALMACEN", dt_e.Rows(0)(2))
                comando_ajuste_e.Parameters.AddWithValue("@REF_PROV", dt_e.Rows(0)(3))
                comando_ajuste_e.Parameters.AddWithValue("@FECHA", Convert.ToDateTime(dt_e.Rows(0)(5)))
                comando_ajuste_e.Parameters.AddWithValue("@N_FACTURA", CVE_DOC)
                comando_ajuste_e.Parameters.AddWithValue("@SUBTOTAL", subtotal_ajuste_e * -1)
                comando_ajuste_e.Parameters.AddWithValue("@DESCUENTO", 0) 'descuento_ajuste_e * -1)
                comando_ajuste_e.Parameters.AddWithValue("@ISV", isv_ajuste_e * -1)
                comando_ajuste_e.Parameters.AddWithValue("@TOTAL", total_ajueste_e * -1)
                comando_ajuste_e.Parameters.AddWithValue("@COMPRA", CVE_COMPRA)
                comando_ajuste_e.Parameters.AddWithValue("@TIPO", "DEBITO")
                comando_ajuste_e.Transaction = mi_transaccion
                comando_ajuste_e.ExecuteNonQuery()

                Dim query_upd_folio_ajuste As New StringBuilder
                query_upd_folio_ajuste.Append("UPDATE [tactical_discount_sragro].[dbo].[nd_folios] ")
                query_upd_folio_ajuste.Append("   SET [ULT_DOC] = ULT_DOC+1 ")
                query_upd_folio_ajuste.Append("WHERE [NUM_ALMA] = @NUM_ALMA AND TIPO = 'A' ")
                Dim comando_upd_folio_ajuste As New SqlCommand(query_upd_folio_ajuste.ToString, sql_con)
                comando_upd_folio_ajuste.Parameters.AddWithValue("@NUM_ALMA", dt_e.Rows(0)(2))
                comando_upd_folio_ajuste.Transaction = mi_transaccion
                comando_upd_folio_ajuste.ExecuteNonQuery()

            End If
            ' fn registra los debitos por producto

            Dim query_dias_cred As New StringBuilder
            query_dias_cred.Append("Select ISNULL(DIASCRED,0) ")
            query_dias_cred.Append("FROM SAE60EMPRE02.dbo.PROV02 ")
            query_dias_cred.Append("WHERE (CLAVE = @CLAVE) ")
            Dim comando_dias_cred As New SqlCommand(query_dias_cred.ToString, sql_con)
            comando_dias_cred.Parameters.AddWithValue("@CLAVE", dt_e.Rows(0)(0))
            comando_dias_cred.Transaction = mi_transaccion
            Dim adaptador_dias_cred As New SqlDataAdapter(comando_dias_cred)
            Dim dt_dias_cred As New DataTable
            adaptador_dias_cred.Fill(dt_dias_cred)
            Dim dias_cred As Integer = 0
            dias_cred = dt_dias_cred.Rows(0)(0)

            ' registra los creditos por producto
            If debito = "D" Then
                Dim query_folio_debito As New StringBuilder
                query_folio_debito.Append("SELECT FOLIO + CONVERT(VARCHAR, ULT_DOC + 1) AS ULT_DOC ")
                query_folio_debito.Append("FROM nd_folios ")
                query_folio_debito.Append("WHERE (TIPO = 'D') AND (NUM_ALMA = @ALMACEN)")
                Dim comando_folio_debito As New SqlCommand(query_folio_debito.ToString, sql_con)
                comando_folio_debito.Parameters.AddWithValue("@ALMACEN", dt_e.Rows(0)(2))
                comando_folio_debito.Transaction = mi_transaccion
                Dim dt_folio_debito As New DataTable
                Dim adaptador_folio_debito As New SqlDataAdapter(comando_folio_debito)
                adaptador_folio_debito.Fill(dt_folio_debito)

                Dim subtotal_debito_e As Double = 0, isv_debito_e As Double = 0, total_debito_e As Double = 0, descuento_debito_e As Double = 0
                For index As Integer = 0 To dt_p.Rows.Count - 1
                    If dt_p.Rows(index)(15) = "D" Then
                        Dim query_debito_p As New StringBuilder
                        query_debito_p.Append("INSERT INTO [tactical_discount_sragro].[dbo].[nd_ajuste_p] ")
                        query_debito_p.Append("([ID_AJUSTE],[NUM_PART],[CVE_ART],[DESCRIPCION],[MOTIVO],[CANTIDAD], ")
                        query_debito_p.Append("[FECHA_INGRESO],[COSTO_ANTERIOR],[COSTO_ACTUAL],[AJUSTE],[UNI]) ")
                        query_debito_p.Append("VALUES ")
                        query_debito_p.Append("(@ID_AJUSTE,@NUM_PART,@CVE_ART,@DESCRIPCION,@MOTIVO,@CANTIDAD, ")
                        query_debito_p.Append("@FECHA_INGRESO,@COSTO_ANTERIOR,@COSTO_ACTUAL,@AJUSTE,@UNI)")
                        Dim comando_debito_p As New SqlCommand(query_debito_p.ToString, sql_con)
                        comando_debito_p.Parameters.AddWithValue("@ID_AJUSTE", dt_folio_debito.Rows(0)(0))
                        comando_debito_p.Parameters.AddWithValue("@NUM_PART", index + 1)
                        comando_debito_p.Parameters.AddWithValue("@CVE_ART", dt_p.Rows(index)(1))
                        comando_debito_p.Parameters.AddWithValue("@DESCRIPCION", dt_p.Rows(index)(2))
                        comando_debito_p.Parameters.AddWithValue("@MOTIVO", "AJUSTE DE PRECIO")
                        comando_debito_p.Parameters.AddWithValue("@CANTIDAD", dt_p.Rows(index)(4))
                        comando_debito_p.Parameters.AddWithValue("@FECHA_INGRESO", Convert.ToDateTime(dt_e.Rows(0)(5)))
                        comando_debito_p.Parameters.AddWithValue("@COSTO_ANTERIOR", dt_p.Rows(index)(5))
                        comando_debito_p.Parameters.AddWithValue("@COSTO_ACTUAL", dt_p.Rows(index)(6))
                        Dim valor_ajuste As Double = 0
                        valor_ajuste = (Convert.ToDouble(dt_p.Rows(index)(4)) * Convert.ToDouble(dt_p.Rows(index)(6))) _
                        - (Convert.ToDouble(dt_p.Rows(index)(4)) * Convert.ToDouble(dt_p.Rows(index)(5)))
                        If dt_p.Rows(index)(0) = "cj" Then
                            valor_ajuste = valor_ajuste * Convert.ToDouble(dt_p.Rows(index)(3))
                        End If
                        comando_debito_p.Parameters.AddWithValue("@AJUSTE", Math.Abs(valor_ajuste))
                        comando_debito_p.Parameters.AddWithValue("@UNI", dt_p.Rows(index)(0))

                        subtotal_debito_e += valor_ajuste
                        descuento_debito_e += 0 'valor_ajuste '* dt_p.Rows(index)(8) / 100
                        valor_ajuste = valor_ajuste - descuento_debito_e
                        isv_debito_e += 0 'valor_ajuste * dt_p.Rows(index)(9) / 100
                        comando_debito_p.Transaction = mi_transaccion
                        comando_debito_p.ExecuteNonQuery()
                    End If
                Next
                total_debito_e += subtotal_debito_e - descuento_debito_e + isv_debito_e

                Dim query_debito_e As New StringBuilder
                query_debito_e.Append("INSERT INTO [tactical_discount_sragro].[dbo].[nd_ajuste_e] ")
                query_debito_e.Append("([ID_AJUSTE],[CVE_PROVEEDOR],[ALMACEN],[REF_PROV]")
                query_debito_e.Append(",[FECHA],[N_FACTURA],[SUBTOTAL],[DESCUENTO],[ISV],[TOTAL],[COMPRA],[TIPO]) ")
                query_debito_e.Append("VALUES ")
                query_debito_e.Append("(@ID_AJUSTE,@CVE_PROVEEDOR,@ALMACEN,@REF_PROV,@FECHA, ")
                query_debito_e.Append("@N_FACTURA,@SUBTOTAL,@DESCUENTO,@ISV,@TOTAL,@COMPRA,@TIPO)")
                Dim comando_debito_e As New SqlCommand(query_debito_e.ToString, sql_con)
                comando_debito_e.Parameters.AddWithValue("@ID_AJUSTE", dt_folio_debito.Rows(0)(0))
                comando_debito_e.Parameters.AddWithValue("@CVE_PROVEEDOR", dt_e.Rows(0)(0))
                comando_debito_e.Parameters.AddWithValue("@ALMACEN", dt_e.Rows(0)(2))
                comando_debito_e.Parameters.AddWithValue("@REF_PROV", dt_e.Rows(0)(3))
                comando_debito_e.Parameters.AddWithValue("@FECHA", Convert.ToDateTime(dt_e.Rows(0)(5)))
                comando_debito_e.Parameters.AddWithValue("@N_FACTURA", CVE_DOC)
                comando_debito_e.Parameters.AddWithValue("@SUBTOTAL", Math.Abs(subtotal_debito_e))
                comando_debito_e.Parameters.AddWithValue("@DESCUENTO", 0) 'Math.Abs(descuento_debito_e))
                comando_debito_e.Parameters.AddWithValue("@ISV", Math.Abs(isv_debito_e))
                comando_debito_e.Parameters.AddWithValue("@TOTAL", Math.Abs(total_debito_e))
                comando_debito_e.Parameters.AddWithValue("@COMPRA", CVE_COMPRA)
                comando_debito_e.Parameters.AddWithValue("@TIPO", "CREDITO")
                comando_debito_e.Transaction = mi_transaccion
                comando_debito_e.ExecuteNonQuery()

                Dim query_upd_folio_ajuste As New StringBuilder
                query_upd_folio_ajuste.Append("UPDATE [tactical_discount_sragro].[dbo].[nd_folios] ")
                query_upd_folio_ajuste.Append("   SET [ULT_DOC] = ULT_DOC+1 ")
                query_upd_folio_ajuste.Append("WHERE [NUM_ALMA] = @NUM_ALMA AND TIPO = 'D' ")
                Dim comando_upd_folio_ajuste As New SqlCommand(query_upd_folio_ajuste.ToString, sql_con)
                comando_upd_folio_ajuste.Parameters.AddWithValue("@NUM_ALMA", dt_e.Rows(0)(2))
                comando_upd_folio_ajuste.Transaction = mi_transaccion
                comando_upd_folio_ajuste.ExecuteNonQuery()

                Dim query_opaga As New StringBuilder
                query_opaga.Append("INSERT INTO [SAE60Empre02].[dbo].[OPAGA02] ")
                query_opaga.Append("([CVE_OBS],[STR_OBS]) ")
                query_opaga.Append("VALUES ((SELECT ULT_CVE + 1 AS ULT_CVE FROM SAE60EMPRE02.dbo.TBLCONTROL02 ")
                query_opaga.Append(" WHERE (ID_TABLA = 21)),'NOTA DE CREDITO POR PRECIO MENOR DEL PROVEEDOR')")
                Dim comando_opaga As New SqlCommand(query_opaga.ToString, sql_con)
                comando_opaga.Transaction = mi_transaccion
                comando_opaga.ExecuteNonQuery()

                Dim query_paga_det As New StringBuilder
                query_paga_det.Append("INSERT INTO [SAE60Empre02].[dbo].[PAGA_DET02] ")
                query_paga_det.Append("([CVE_PROV],[REFER],[NUM_CPTO],[NUM_CARGO],[ID_MOV] ")
                query_paga_det.Append(",[CVE_OBS],[NO_FACTURA],[DOCTO],[IMPORTE],[FECHA_APLI],[FECHA_VENC] ")
                query_paga_det.Append(",[NUM_MONED],[TCAMBIO],[IMPMON_EXT],[FECHAELAB] ")
                query_paga_det.Append(",[TIPO_MOV],[SIGNO],[USUARIO] ")
                query_paga_det.Append(",[NO_PARTIDA]) ")
                query_paga_det.Append("VALUES ")
                query_paga_det.Append("(@CVE_PROV, @REFER, 29,1,1, (SELECT ULT_CVE + 1 AS ULT_CVE FROM ")
                query_paga_det.Append(" SAE60EMPRE02.dbo.TBLCONTROL02 WHERE (ID_TABLA = 21)), ")
                query_paga_det.Append("@NO_FACTURA, @DOCTO, @IMPORTE, @FECHA_APLI, @FECHA_VENC, 1, ")
                query_paga_det.Append("1, @IMPMON_EXT, @FECHAELAB,'A', -1,0, 1) ")
                Dim comando_paga_det As New SqlCommand(query_paga_det.ToString, sql_con)
                comando_paga_det.Parameters.AddWithValue("@CVE_PROV", dt_e.Rows(0)(0))
                comando_paga_det.Parameters.AddWithValue("@REFER", CVE_DOC)
                comando_paga_det.Parameters.AddWithValue("@NO_FACTURA", CVE_DOC)
                comando_paga_det.Parameters.AddWithValue("@DOCTO", CVE_DOC)
                comando_paga_det.Parameters.AddWithValue("@IMPORTE", (Math.Abs(subtotal_debito_e) - Math.Abs(descuento_debito_e)) * dt_e.Rows(0)(12))
                'Math.Abs(total_debito_e) * dt_e.Rows(0)(12))
                comando_paga_det.Parameters.AddWithValue("@FECHA_APLI", Convert.ToDateTime(dt_e.Rows(0)(5)))
                comando_paga_det.Parameters.AddWithValue("@FECHA_VENC", Convert.ToDateTime(dt_e.Rows(0)(5)).AddDays(dias_cred))
                comando_paga_det.Parameters.AddWithValue("@IMPMON_EXT", (Math.Abs(subtotal_debito_e) - Math.Abs(descuento_debito_e)) * dt_e.Rows(0)(12))
                comando_paga_det.Parameters.AddWithValue("@FECHAELAB", Convert.ToDateTime(dt_e.Rows(0)(5)))
                comando_paga_det.Transaction = mi_transaccion
                comando_paga_det.ExecuteNonQuery()

                Dim query_upd_paga_det As New StringBuilder
                query_upd_paga_det.Append("UPDATE [SAE60Empre02].[dbo].[TBLCONTROL02] ")
                query_upd_paga_det.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                query_upd_paga_det.Append("WHERE ([ID_TABLA] = 21)")
                Dim comando_upd_paga_det As New SqlCommand(query_upd_paga_det.ToString, sql_con)
                comando_upd_paga_det.Transaction = mi_transaccion
                comando_upd_paga_det.ExecuteNonQuery()

            End If
            ' fin registra los creditos por producto

            'registrar envio a SAE
            Dim query_compc As New StringBuilder
            query_compc.Append("INSERT INTO [SAE60Empre02].[dbo].[COMPC02] ")
            query_compc.Append("([TIP_DOC],[CVE_DOC],[CVE_CLPV],[STATUS],[SU_REFER] ")
            query_compc.Append(",[FECHA_DOC],[FECHA_REC],[FECHA_PAG] ")
            query_compc.Append(",[CAN_TOT],[IMP_TOT1],[IMP_TOT2],[IMP_TOT3],[IMP_TOT4] ")
            query_compc.Append(",[DES_TOT],[DES_FIN],[TOT_IND],[OBS_COND],[CVE_OBS] ")
            query_compc.Append(",[NUM_ALMA],[ACT_CXP],[ACT_COI],[ENLAZADO],[TIP_DOC_E] ")
            query_compc.Append(",[NUM_MONED],[TIPCAMB],[NUM_PAGOS],[FECHAELAB] ")
            query_compc.Append(",[SERIE],[FOLIO],[CTLPOL],[ESCFD],[CONTADO],[BLOQ] ")
            query_compc.Append(",[DES_FIN_PORC],[DES_TOT_PORC],[IMPORTE],[TIP_DOC_ANT],[DOC_ANT]) ")
            query_compc.Append("VALUES ")
            query_compc.Append("('c', @CVE_DOC,@CVE_CLPV,'O',@SU_REFER,@FECHA_DOC ")
            query_compc.Append(",@FECHA_REC,@FECHA_PAG,@CAN_TOT,0,0,0,@IMP_TOT4,@DES_TOT,0,0 ")
            query_compc.Append(",'',0,@NUM_ALMA,'S','N','O','O',1,1,1,@FECHAELAB ")
            query_compc.Append(",@SERIE,@FOLIO,0,'N','N','N',0 ,@DES_TOT_PORC,@IMPORTE,'','' )")
            Dim comando_compc As New SqlCommand(query_compc.ToString, sql_con)
            comando_compc.Parameters.AddWithValue("@CVE_DOC", CVE_DOC)
            comando_compc.Parameters.AddWithValue("@CVE_CLPV", dt_e.Rows(0)(0))
            comando_compc.Parameters.AddWithValue("@SU_REFER", dt_e.Rows(0)(3))
            comando_compc.Parameters.AddWithValue("@FECHA_DOC", Convert.ToDateTime(dt_e.Rows(0)(5)))
            comando_compc.Parameters.AddWithValue("@FECHA_REC", Convert.ToDateTime(dt_e.Rows(0)(5)))
            comando_compc.Parameters.AddWithValue("@FECHA_PAG", Convert.ToDateTime(dt_e.Rows(0)(5)).AddDays(dias_cred)) 'Agregar dias de credito
            comando_compc.Parameters.AddWithValue("@CAN_TOT", dt_e.Rows(0)(7) * dt_e.Rows(0)(12))
            comando_compc.Parameters.AddWithValue("@IMP_TOT4", 0) 'dt_e.Rows(0)(9) * dt_e.Rows(0)(12))
            comando_compc.Parameters.AddWithValue("@DES_TOT", dt_e.Rows(0)(8) * dt_e.Rows(0)(12))
            comando_compc.Parameters.AddWithValue("@NUM_ALMA", dt_e.Rows(0)(2))
            comando_compc.Parameters.AddWithValue("@FECHAELAB", Now.Date)
            comando_compc.Parameters.AddWithValue("@SERIE", serie)
            comando_compc.Parameters.AddWithValue("@FOLIO", folio)
            comando_compc.Parameters.AddWithValue("@DES_TOT_PORC", dt_e.Rows(0)(6))
            comando_compc.Parameters.AddWithValue("@IMPORTE", (dt_e.Rows(0)(7) - dt_e.Rows(0)(8)) * dt_e.Rows(0)(12)) 'dt_e.Rows(0)(10) * dt_e.Rows(0)(12))
            comando_compc.Transaction = mi_transaccion
            comando_compc.ExecuteNonQuery()

            Dim query_compc_clib As New StringBuilder
            query_compc_clib.Append("INSERT INTO [SAE60Empre02].[dbo].[COMPC_CLIB02] ")
            query_compc_clib.Append(" ([CLAVE_DOC],[CAMPLIB1]) ")
            query_compc_clib.Append("VALUES (@CLAVE_DOC,@CAMPLIB1)")
            Dim comando_comp_clib As New SqlCommand(query_compc_clib.ToString, sql_con)
            comando_comp_clib.Parameters.AddWithValue("CLAVE_DOC", CVE_DOC)
            comando_comp_clib.Parameters.AddWithValue("@CAMPLIB1", Convert.ToDateTime(dt_e.Rows(0)(18)))
            comando_comp_clib.Transaction = mi_transaccion
            comando_comp_clib.ExecuteNonQuery()

            'inicio del for

            For index As Integer = 0 To dt_p.Rows.Count - 1
                Dim query_correlativo_lote As New StringBuilder
                query_correlativo_lote.Append("SELECT (ULT_CVE + 1) AS ULT_CVE ")
                query_correlativo_lote.Append("FROM SAE60EMPRE02.dbo.TBLCONTROL02 ")
                query_correlativo_lote.Append("WHERE (ID_TABLA = 67) ")
                Dim comando_correlativo_lote As New SqlCommand(query_correlativo_lote.ToString, sql_con)
                comando_correlativo_lote.Transaction = mi_transaccion
                Dim adaptador_correlativo_lote As New SqlDataAdapter(comando_correlativo_lote)
                Dim dt_correlativo_lote As New DataTable
                adaptador_correlativo_lote.Fill(dt_correlativo_lote)
                Dim correlativo_lote As Integer
                correlativo_lote = dt_correlativo_lote.Rows(0)(0)

                Dim query_par_compc As New StringBuilder
                query_par_compc.Append("INSERT INTO [SAE60Empre02].[dbo].[PAR_COMPC02] ")
                query_par_compc.Append("   ([CVE_DOC],[NUM_PAR],[CVE_ART],[CANT],[PXR],[PREC],[COST] ")
                query_par_compc.Append("   ,[IMPU1],[IMPU2],[IMPU3],[IMPU4],[IMP1APLA],[IMP2APLA],[IMP3APLA] ")
                query_par_compc.Append("   ,[IMP4APLA],[TOTIMP1],[TOTIMP2],[TOTIMP3],[TOTIMP4],[DESCU],[ACT_INV] ")
                query_par_compc.Append("   ,[TIP_CAM],[UNI_VENTA],[TIPO_ELEM],[TIPO_PROD],[CVE_OBS],[REG_SERIE] ")
                query_par_compc.Append("   ,[E_LTPD],[FACTCONV],[COST_DEV],[NUM_ALM],[MINDIRECTO],[NUM_MOV],[TOT_PARTIDA]) ")
                query_par_compc.Append("VALUES ")
                query_par_compc.Append("  (@CVE_DOC,@NUM_PAR,@CVE_ART, @CANT, @PXR, ISNULL((SELECT SAE60Empre02.dbo.PRECIO_X_PROD02.PRECIO ")
                query_par_compc.Append("FROM SAE60Empre02.dbo.INVE02 INNER JOIN SAE60Empre02.dbo.PRECIO_X_PROD02 ON ")
                query_par_compc.Append("SAE60Empre02.dbo.INVE02.CVE_ART = SAE60Empre02.dbo.PRECIO_X_PROD02.CVE_ART ")
                query_par_compc.Append("WHERE (SAE60Empre02.dbo.PRECIO_X_PROD02.CVE_PRECIO = 1) AND ")
                query_par_compc.Append(" (SAE60Empre02.dbo.INVE02.CVE_ART = @CVE_ART)),0), @COST, 0, 0, 0, ")
                query_par_compc.Append("   @IMPU4, 0, 0, 0, 0, 0, 0, ")
                query_par_compc.Append("   0, @TOTIMP4, @DESCU, 'S', 1, @UNI_VENTA, 'N', ")
                query_par_compc.Append("   'P', 0,0,@E_LTPD,@FACTCONV, @COST_DEV, @NUM_ALM, ")
                query_par_compc.Append("   0, (SELECT ULT_CVE + 1 FROM SAE60EMPRE02.dbo.TBLCONTROL02 WHERE (ID_TABLA = 44)),@TOT_PARTIDA)")
                Dim comando_par_compc As New SqlCommand(query_par_compc.ToString, sql_con)
                comando_par_compc.Parameters.AddWithValue("@CVE_DOC", CVE_DOC)
                comando_par_compc.Parameters.AddWithValue("@NUM_PAR", index + 1)
                comando_par_compc.Parameters.AddWithValue("@CVE_ART", dt_p.Rows(index)(1))
                comando_par_compc.Parameters.AddWithValue("@CANT", Convert.ToDouble(dt_p.Rows(index)(4)))

                Dim cant_insertar As Double = 0
                Dim costo_insertar As Double = 0
                Dim factor_convesion As Integer = 0
                If dt_p.Rows(index)(0) = "cj" Then
                    cant_insertar = Convert.ToDouble(dt_p.Rows(index)(4)) * dt_p.Rows(index)(3)
                    factor_convesion = dt_p.Rows(index)(3)
                    costo_insertar = dt_p.Rows(index)(5) * dt_p.Rows(index)(3) * dt_e.Rows(0)(12)
                ElseIf dt_p.Rows(index)(0) = "pz" Then
                    cant_insertar = Convert.ToDouble(dt_p.Rows(index)(4))
                    costo_insertar = dt_p.Rows(index)(5) * dt_e.Rows(0)(12)
                    factor_convesion = 1
                End If

                comando_par_compc.Parameters.AddWithValue("@PXR", cant_insertar)
                comando_par_compc.Parameters.AddWithValue("@COST", costo_insertar)
                comando_par_compc.Parameters.AddWithValue("@IMPU4", 0) 'dt_p.Rows(index)(9))
                comando_par_compc.Parameters.AddWithValue("@TOTIMP4", 0) ' Convert.ToDouble(dt_p.Rows(index)(12)))
                comando_par_compc.Parameters.AddWithValue("@DESCU", dt_p.Rows(index)(8) * dt_e.Rows(0)(12))
                comando_par_compc.Parameters.AddWithValue("@UNI_VENTA", dt_p.Rows(index)(0))

                If dt_p.Rows(index)(20) = "S" Then
                    comando_par_compc.Parameters.AddWithValue("@E_LTPD", correlativo_lote)
                Else
                    comando_par_compc.Parameters.AddWithValue("@E_LTPD", 0)
                End If

                comando_par_compc.Parameters.AddWithValue("@FACTCONV", factor_convesion)
                comando_par_compc.Parameters.AddWithValue("@COST_DEV", dt_p.Rows(index)(5) * dt_p.Rows(index)(3) * dt_e.Rows(0)(12))
                comando_par_compc.Parameters.AddWithValue("@NUM_ALM", dt_e.Rows(0)(2))
                comando_par_compc.Parameters.AddWithValue("@TOT_PARTIDA", (Convert.ToDouble(dt_p.Rows(index)(4) * _
                                                                            dt_p.Rows(index)(5) * dt_p.Rows(index)(3)) * dt_e.Rows(0)(12)))
                comando_par_compc.Transaction = mi_transaccion
                comando_par_compc.ExecuteNonQuery()

                Dim query_par_comp_clib As New StringBuilder
                query_par_comp_clib.Append("INSERT INTO [SAE60Empre02].[dbo].[PAR_COMPC_CLIB02] ")
                query_par_comp_clib.Append("   ([CLAVE_DOC],[NUM_PART]) ")
                query_par_comp_clib.Append("VALUES ")
                query_par_comp_clib.Append("   (@CLAVE_DOC,@NUM_PART) ")
                Dim comando_par_comp_clib As New SqlCommand(query_par_comp_clib.ToString, sql_con)
                comando_par_comp_clib.Parameters.AddWithValue("@CLAVE_DOC", CVE_DOC)
                comando_par_comp_clib.Parameters.AddWithValue("@NUM_PART", index + 1)
                comando_par_comp_clib.Transaction = mi_transaccion
                comando_par_comp_clib.ExecuteNonQuery()

                Dim query_costo_prom As New StringBuilder
                query_costo_prom.Append("SELECT ISNULL(EXIST,0),ISNULL(COSTO_PROM,0) FROM SAE60EMPRE02.dbo.INVE02 WHERE CVE_ART = @CVE_ART")
                Dim comando_costo_prom As New SqlCommand(query_costo_prom.ToString, sql_con)
                comando_costo_prom.Parameters.AddWithValue("@CVE_ART", dt_p.Rows(index)(1))
                comando_costo_prom.Transaction = mi_transaccion
                Dim adaptador_costo As New SqlDataAdapter(comando_costo_prom)
                Dim dt_costo_prom As New DataTable
                adaptador_costo.Fill(dt_costo_prom)
                Dim existencias_viejas As Double = 0, costo_prom_viejo As Double = 0
                existencias_viejas = dt_costo_prom.Rows(0)(0)
                costo_prom_viejo = dt_costo_prom.Rows(0)(1)

                Dim costo_prom_nuevo As Double = 0
                costo_prom_nuevo = ((existencias_viejas * costo_prom_viejo) + (cant_insertar * (dt_p.Rows(index)(7) _
                                                                            * dt_e.Rows(0)(12)))) / (existencias_viejas + cant_insertar)

                Dim query_upd_inve As New StringBuilder
                query_upd_inve.Append("UPDATE SAE60EMPRE02.dbo.INVE02 ")
                query_upd_inve.Append("SET [EXIST] = (EXIST + @NUEVA_EXISTENCIA), ")
                query_upd_inve.Append("FCH_ULTCOM = @FECHA_ULTCOM, ")
                query_upd_inve.Append("[ULT_COSTO] = @ULT_COSTO, [COSTO_PROM] = @COSTO_PROM ")
                query_upd_inve.Append("WHERE [CVE_ART] = @CVE_ART ")
                Dim comando_upd_inve As New SqlCommand(query_upd_inve.ToString, sql_con)
                comando_upd_inve.Parameters.AddWithValue("@NUEVA_EXISTENCIA", cant_insertar)
                comando_upd_inve.Parameters.AddWithValue("@FECHA_ULTCOM", Now.Date)
                comando_upd_inve.Parameters.AddWithValue("@CVE_ART", dt_p.Rows(index)(1))
                comando_upd_inve.Parameters.AddWithValue("@ULT_COSTO", dt_p.Rows(index)(7) * dt_e.Rows(0)(12))
                comando_upd_inve.Parameters.AddWithValue("@COSTO_PROM", costo_prom_nuevo)

                comando_upd_inve.Transaction = mi_transaccion
                comando_upd_inve.ExecuteNonQuery()

                Dim query_upd_mult As New StringBuilder
                query_upd_mult.Append("UPDATE SAE60EMPRE02.dbo.MULT02 ")
                query_upd_mult.Append("SET [EXIST] = (EXIST + @NUEVA_EXISTENCIA) ")
                query_upd_mult.Append("WHERE  [CVE_ART] = @CVE_ART AND [CVE_ALM] = @CVE_ALM ")
                Dim comando_upd_mult As New SqlCommand(query_upd_mult.ToString, sql_con)
                comando_upd_mult.Parameters.AddWithValue("@NUEVA_EXISTENCIA", cant_insertar)
                comando_upd_mult.Parameters.AddWithValue("@CVE_ART", dt_p.Rows(index)(1))
                comando_upd_mult.Parameters.AddWithValue("@CVE_ALM", dt_e.Rows(0)(2))
                comando_upd_mult.Transaction = mi_transaccion
                comando_upd_mult.ExecuteNonQuery()

                If dt_p.Rows(index)(20) = "S" Then
                    Dim query_reg_lote As New StringBuilder
                    query_reg_lote.Append("SELECT (ULT_CVE + 1) AS ULT_CVE ")
                    query_reg_lote.Append("FROM SAE60EMPRE02.dbo.TBLCONTROL02 ")
                    query_reg_lote.Append("WHERE (ID_TABLA = 48) ")
                    Dim comando_reg_lote As New SqlCommand(query_reg_lote.ToString, sql_con)
                    comando_reg_lote.Transaction = mi_transaccion
                    Dim adaptador_reg_lote As New SqlDataAdapter(comando_reg_lote)
                    Dim dt_reg_lote As New DataTable
                    adaptador_reg_lote.Fill(dt_reg_lote)
                    Dim reg_lote As Integer
                    reg_lote = dt_reg_lote.Rows(0)(0)

                    Dim codigo_lote As String = ""
                    If conlote = "S" Then
                        codigo_lote = lote
                    Else
                        codigo_lote = CVE_DOC
                    End If

                    Dim query_ltpd As New StringBuilder
                    query_ltpd.Append("INSERT INTO [SAE60Empre02].[dbo].[LTPD02] ")
                    query_ltpd.Append("   ([CVE_ART],[LOTE],[PEDIMENTO],[CVE_ALM] ")
                    query_ltpd.Append("   ,[FCHULTMOV],[NOM_ADUAN],[CANTIDAD],[REG_LTPD],[CVE_OBS] ")
                    query_ltpd.Append("   ,[CIUDAD],[FRONTERA],[GLN],[STATUS]) ")
                    query_ltpd.Append("VALUES ")
                    query_ltpd.Append("   (@CVE_ART,@LOTE,'',@CVE_ALM,@FCHULTMOV, ")
                    query_ltpd.Append("'', @CANTIDAD, @REG_LTPD, 0, '', '', '','A')")
                    Dim comando_ltpd As New SqlCommand(query_ltpd.ToString, sql_con)
                    comando_ltpd.Parameters.AddWithValue("@CVE_ART", dt_p.Rows(index)(1))
                    comando_ltpd.Parameters.AddWithValue("@LOTE", codigo_lote)
                    comando_ltpd.Parameters.AddWithValue("@CVE_ALM", dt_e.Rows(0)(2))
                    comando_ltpd.Parameters.AddWithValue("@FCHULTMOV", Now.Date)
                    comando_ltpd.Parameters.AddWithValue("@CANTIDAD", cant_insertar)
                    comando_ltpd.Parameters.AddWithValue("@REG_LTPD", reg_lote)
                    comando_ltpd.Transaction = mi_transaccion
                    comando_ltpd.ExecuteNonQuery()

                    Dim query_enlace_ltpd As New StringBuilder
                    query_enlace_ltpd.Append("INSERT INTO [SAE60Empre02].[dbo].[ENLACE_LTPD02] ")
                    query_enlace_ltpd.Append("   ([E_LTPD],[REG_LTPD],[CANTIDAD],[PXRS]) ")
                    query_enlace_ltpd.Append("VALUES ")
                    query_enlace_ltpd.Append("   (@E_LTPD,@REG_LTPD, @CANTIDAD,@PXRS)")
                    Dim comando_enlace_ltpd As New SqlCommand(query_enlace_ltpd.ToString, sql_con)
                    comando_enlace_ltpd.Parameters.AddWithValue("@E_LTPD", correlativo_lote)
                    comando_enlace_ltpd.Parameters.AddWithValue("@REG_LTPD", reg_lote)
                    comando_enlace_ltpd.Parameters.AddWithValue("@CANTIDAD", cant_insertar)
                    comando_enlace_ltpd.Parameters.AddWithValue("@PXRS", cant_insertar)
                    comando_enlace_ltpd.Transaction = mi_transaccion
                    comando_enlace_ltpd.ExecuteNonQuery()

                    Dim query_upd_correlativo_lote As New StringBuilder
                    query_upd_correlativo_lote.Append("UPDATE [SAE60Empre02].[dbo].[TBLCONTROL02] ")
                    query_upd_correlativo_lote.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                    query_upd_correlativo_lote.Append("WHERE([ID_TABLA] = 67)")
                    Dim comando_upd_correlativo_lote As New SqlCommand(query_upd_correlativo_lote.ToString, sql_con)
                    comando_upd_correlativo_lote.Transaction = mi_transaccion
                    comando_upd_correlativo_lote.ExecuteNonQuery()

                    Dim query_upd_reg_lote As New StringBuilder
                    query_upd_reg_lote.Append("UPDATE [SAE60Empre02].[dbo].[TBLCONTROL02] ")
                    query_upd_reg_lote.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                    query_upd_reg_lote.Append("WHERE([ID_TABLA] = 48)")
                    Dim comando_upd_reg_lote As New SqlCommand(query_upd_reg_lote.ToString, sql_con)
                    comando_upd_reg_lote.Transaction = mi_transaccion
                    comando_upd_reg_lote.ExecuteNonQuery()
                End If

                Dim query_minve As New StringBuilder
                query_minve.Append("INSERT INTO [SAE60Empre02].[dbo].[MINVE02] ")
                query_minve.Append("   ([CVE_ART],[ALMACEN],[NUM_MOV],[CVE_CPTO],[FECHA_DOCU] ")
                query_minve.Append("   ,[TIPO_DOC],[REFER],[CLAVE_CLPV],[VEND],[CANT],[CANT_COST] ")
                query_minve.Append("   ,[PRECIO],[COSTO],[REG_SERIE],[UNI_VENTA] ")
                query_minve.Append("   ,[E_LTPD],[EXIST_G],[EXISTENCIA],[FACTOR_CON] ")
                query_minve.Append("   ,[FECHAELAB],[CVE_FOLIO],[SIGNO],[COSTEADO],[COSTO_PROM_INI] ")
                query_minve.Append("   ,[COSTO_PROM_FIN],[COSTO_PROM_GRAL],[DESDE_INVE],[MOV_ENLAZADO]) ")
                query_minve.Append("VALUES ")
                query_minve.Append("   (@CVE_ART, @ALMACEN,(SELECT ULT_CVE+1 FROM SAE60EMPRE02.dbo.TBLCONTROL02  ")
                query_minve.Append("   WHERE (ID_TABLA = 44)),1,@FECHA_DOCU, 'c', @REFER, ")
                query_minve.Append("   @CLAVE_CLPV, '',@CANT, 0, 0, @COSTO,  ")
                query_minve.Append("   0,@UNI_VENTA, @E_LTPD,@CANT+ISNULL((SELECT EXIST FROM SAE60EMPRE02.dbo.INVE02 ")
                query_minve.Append("   WHERE (CVE_ART = @CVE_ART)),0), ((SELECT EXIST FROM SAE60EMPRE02.dbo.MULT02 ")
                query_minve.Append("   WHERE (CVE_ART = @CVE_ART) AND CVE_ALM = @ALMACEN)), @FACTOR_CON, ")
                query_minve.Append("   @FECHAELAB, (SELECT ULT_CVE+1 FROM SAE60EMPRE02.dbo.TBLCONTROL02 ")
                query_minve.Append("   WHERE (ID_TABLA = 32)),'1','S', @COSTO_PROM_INI,@COSTO_PROM_FIN, ")
                query_minve.Append("   @COSTO_PROM_GRAL,'N',0)")
                Dim comando_minve As New SqlCommand(query_minve.ToString, sql_con)
                comando_minve.Parameters.AddWithValue("@CVE_ART", dt_p.Rows(index)(1))
                comando_minve.Parameters.AddWithValue("@ALMACEN", dt_e.Rows(0)(2))
                comando_minve.Parameters.AddWithValue("@FECHA_DOCU", Convert.ToDateTime(dt_e.Rows(0)(5)))
                comando_minve.Parameters.AddWithValue("@REFER", CVE_DOC)
                comando_minve.Parameters.AddWithValue("@CLAVE_CLPV", dt_e.Rows(0)(0))
                comando_minve.Parameters.AddWithValue("@CANT", cant_insertar)
                comando_minve.Parameters.AddWithValue("@COSTO", dt_p.Rows(index)(7) * dt_e.Rows(0)(12))
                comando_minve.Parameters.AddWithValue("@UNI_VENTA", dt_p.Rows(index)(0))
                If dt_p.Rows(index)(20) = "S" Then
                    comando_minve.Parameters.AddWithValue("@E_LTPD", correlativo_lote)
                Else
                    comando_minve.Parameters.AddWithValue("@E_LTPD", 0)
                End If
                comando_minve.Parameters.AddWithValue("@FACTOR_CON", factor_convesion)
                comando_minve.Parameters.AddWithValue("@FECHAELAB", Convert.ToDateTime(dt_e.Rows(0)(5)))
                comando_minve.Parameters.AddWithValue("@COSTO_PROM_INI", costo_prom_viejo)
                comando_minve.Parameters.AddWithValue("@COSTO_PROM_FIN", costo_prom_nuevo)
                comando_minve.Parameters.AddWithValue("@COSTO_PROM_GRAL", costo_prom_nuevo)
                comando_minve.Transaction = mi_transaccion
                comando_minve.ExecuteNonQuery()

                Dim query_num_mov_minve As New StringBuilder
                query_num_mov_minve.Append("UPDATE [SAE60Empre02].[dbo].[TBLCONTROL02] ")
                query_num_mov_minve.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                query_num_mov_minve.Append("WHERE([ID_TABLA] = 44)")
                Dim comando_num_mov_minve As New SqlCommand(query_num_mov_minve.ToString, sql_con)
                comando_num_mov_minve.Transaction = mi_transaccion
                comando_num_mov_minve.ExecuteNonQuery()

                Dim query_upd_folio_minve As New StringBuilder
                query_upd_folio_minve.Append("UPDATE SAE60EMPRE02.dbo.TBLCONTROL02 ")
                query_upd_folio_minve.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                query_upd_folio_minve.Append("WHERE (ID_TABLA = 32) ")
                Dim comando_upd_folio_minve As New SqlCommand(query_upd_folio_minve.ToString, sql_con)
                comando_upd_folio_minve.Transaction = mi_transaccion
                comando_upd_folio_minve.ExecuteNonQuery()
            Next

            'fin del for

            Dim query_paga_m As New StringBuilder
            query_paga_m.Append("INSERT INTO [SAE60Empre02].[dbo].[PAGA_M02] ")
            query_paga_m.Append("   ([CVE_PROV],[REFER],[NUM_CARGO],[NUM_CPTO],[CVE_OBS] ")
            query_paga_m.Append("   ,[NO_FACTURA],[DOCTO],[IMPORTE],[FECHA_APLI],[FECHA_VENC],[AFEC_COI] ")
            query_paga_m.Append("   ,[NUM_MONED],[TCAMBIO],[IMPMON_EXT],[FECHAELAB],[TIPO_MOV],[SIGNO],[USUARIO],[STATUS]) ")
            query_paga_m.Append("VALUES ")
            query_paga_m.Append("   (@CVE_PROV, @REFER, 1, 1, 0, @NO_FACTURA, ")
            query_paga_m.Append("   @DOCTO,@IMPORTE,@FECHA_APLI, @FECHA_VENC, 'A',1, 1, ")
            query_paga_m.Append("   @IMPMON_EXT,@FECHAELAB, 'C', 1, ")
            query_paga_m.Append("   @USUARIO, 'A')")
            Dim comando_paga_m As New SqlCommand(query_paga_m.ToString, sql_con)
            comando_paga_m.Parameters.AddWithValue("@CVE_PROV", dt_e.Rows(0)(0))
            comando_paga_m.Parameters.AddWithValue("@REFER", CVE_DOC)
            comando_paga_m.Parameters.AddWithValue("@DOCTO", CVE_DOC)
            comando_paga_m.Parameters.AddWithValue("@NO_FACTURA", dt_e.Rows(0)(3))
            comando_paga_m.Parameters.AddWithValue("@IMPORTE", dt_e.Rows(0)(7) * dt_e.Rows(0)(12))
            comando_paga_m.Parameters.AddWithValue("@FECHA_APLI", Convert.ToDateTime(dt_e.Rows(0)(5)))
            comando_paga_m.Parameters.AddWithValue("@FECHA_VENC", Convert.ToDateTime(dt_e.Rows(0)(5)).AddDays(dias_cred))
            comando_paga_m.Parameters.AddWithValue("@IMPMON_EXT", dt_e.Rows(0)(7) * dt_e.Rows(0)(12))
            comando_paga_m.Parameters.AddWithValue("@FECHAELAB", Convert.ToDateTime(dt_e.Rows(0)(5)))
            comando_paga_m.Parameters.AddWithValue("@USUARIO", 0)
            comando_paga_m.Transaction = mi_transaccion
            comando_paga_m.ExecuteNonQuery()

            'afectar cuenta VESTA CUSTOM

            Dim query_refer_vesta As New StringBuilder
            query_refer_vesta.Append("SELECT ULT_DOC+1 ")
            query_refer_vesta.Append("FROM SAE60EMPRE02.dbo.FOLIOSC02 WHERE (TIP_DOC = 'c') AND (SERIE = 'AC') ")
            Dim comando_refer_vesta As New SqlCommand(query_refer_vesta.ToString, sql_con)
            comando_refer_vesta.Transaction = mi_transaccion
            Dim dt_refer_vesta As New DataTable
            Dim adaptador_vesta As New SqlDataAdapter(comando_refer_vesta)
            adaptador_vesta.Fill(dt_refer_vesta)

            Dim query_paga_m_vesta As New StringBuilder
            query_paga_m_vesta.Append("INSERT INTO [SAE60Empre02].[dbo].[PAGA_M02] ")
            query_paga_m_vesta.Append("   ([CVE_PROV],[REFER],[NUM_CARGO],[NUM_CPTO],[CVE_OBS] ")
            query_paga_m_vesta.Append("   ,[NO_FACTURA],[DOCTO],[IMPORTE],[FECHA_APLI],[FECHA_VENC],[AFEC_COI] ")
            query_paga_m_vesta.Append("   ,[NUM_MONED],[TCAMBIO],[IMPMON_EXT],[FECHAELAB],[TIPO_MOV],[SIGNO],[USUARIO],[STATUS]) ")
            query_paga_m_vesta.Append("VALUES ")
            query_paga_m_vesta.Append("   (@CVE_PROV, @REFER, 1, 1, 0, @NO_FACTURA, ")
            query_paga_m_vesta.Append("   @DOCTO,@IMPORTE,@FECHA_APLI, @FECHA_VENC, '',1, 1, ")
            query_paga_m_vesta.Append("   @IMPMON_EXT,@FECHAELAB, 'C', 1, ")
            query_paga_m_vesta.Append("   @USUARIO, 'A')")
            Dim comando_paga_m_vesta As New SqlCommand(query_paga_m_vesta.ToString, sql_con)
            comando_paga_m_vesta.Parameters.AddWithValue("@CVE_PROV", agente)
            comando_paga_m_vesta.Parameters.AddWithValue("@REFER", "AC" & dt_refer_vesta.Rows(0)(0))
            comando_paga_m_vesta.Parameters.AddWithValue("@DOCTO", "AC" & dt_refer_vesta.Rows(0)(0))
            comando_paga_m_vesta.Parameters.AddWithValue("@NO_FACTURA", dt_e.Rows(0)(3))
            comando_paga_m_vesta.Parameters.AddWithValue("@IMPORTE", (Convert.ToDouble(dt_e.Rows(0)(9)) + Convert.ToDouble(dt_e.Rows(0)(14)) _
                                                                    + Convert.ToDouble(dt_e.Rows(0)(15)) + Convert.ToDouble(dt_e.Rows(0)(16)) _
                                                                    + Convert.ToDouble(dt_e.Rows(0)(17))) * Convert.ToDouble(dt_e.Rows(0)(12)))

            comando_paga_m_vesta.Parameters.AddWithValue("@FECHA_APLI", Convert.ToDateTime(dt_e.Rows(0)(5)))
            comando_paga_m_vesta.Parameters.AddWithValue("@FECHA_VENC", Convert.ToDateTime(dt_e.Rows(0)(5)).AddDays(dias_cred))
            comando_paga_m_vesta.Parameters.AddWithValue("@IMPMON_EXT", (Convert.ToDouble(dt_e.Rows(0)(9)) + Convert.ToDouble(dt_e.Rows(0)(14)) _
                                                                        + Convert.ToDouble(dt_e.Rows(0)(15)) + Convert.ToDouble(dt_e.Rows(0)(16)) + _
                                                                        Convert.ToDouble(dt_e.Rows(0)(17))) * Convert.ToDouble(dt_e.Rows(0)(12)))
            comando_paga_m_vesta.Parameters.AddWithValue("@FECHAELAB", Convert.ToDateTime(dt_e.Rows(0)(5)))
            comando_paga_m_vesta.Parameters.AddWithValue("@USUARIO", 0)
            comando_paga_m_vesta.Transaction = mi_transaccion
            comando_paga_m_vesta.ExecuteNonQuery()

            Dim query_upd_refer_vesta As New StringBuilder
            query_upd_refer_vesta.Append("UPDATE SAE60EMPRE02.dbo.FOLIOSC02 ")
            query_upd_refer_vesta.Append("SET ULT_DOC = (ULT_DOC + 1) WHERE (TIP_DOC = 'c') AND (SERIE = 'AC') ")
            Dim comando_upd_refer_vesta As New SqlCommand(query_upd_refer_vesta.ToString, sql_con)
            comando_upd_refer_vesta.Transaction = mi_transaccion
            comando_upd_refer_vesta.ExecuteNonQuery()

            Dim query_e_local As New StringBuilder
            query_e_local.Append("INSERT INTO [tactical_discount_sragro].[dbo].[nd_importaciones_e] ")
            query_e_local.Append("       ([CVE_COMPRA],[CVE_PROVEEDOR],[PROVEEDOR],[ALMACEN] ")
            query_e_local.Append("       ,[REF_PROV],[RFC],[FECHA],[DESCUENTO_POR],[SUB_TOTAL] ")
            query_e_local.Append("       ,[DESCUENTO_VAL],[ISV_VAL],[TOTAL],[ESTADO],[TASA_CAMBIO] ")
            query_e_local.Append("       ,[N_FACTURA_SAE], [FLETE],[SEGURO],[PYC],[HONORARIOS],[AGENTE],[ALTA_AGENTE],[FECHA_FACTURA]) ")
            query_e_local.Append(" VALUES ")
            query_e_local.Append("       (@CVE_COMPRA,@CVE_PROVEEDOR,@PROVEEDOR,@ALMACEN ")
            query_e_local.Append("       ,@REF_PROV,@RFC,@FECHA,@DESCUENTO_POR,@SUB_TOTAL ")
            query_e_local.Append("       ,@DESCUENTO_VAL,@ISV_VAL,@TOTAL,@ESTADO,@TASA_CAMBIO ")
            query_e_local.Append("       ,@N_FACTURA_SAE,@FLETE,@SEGURO,@PYC,@HONORARIOS,@AGENTE,@ALTA_AGENTE,@FECHA_FACTURA)")

            Dim comando_e_local As New SqlCommand(query_e_local.ToString, sql_con)
            comando_e_local.Parameters.AddWithValue("@CVE_COMPRA", CVE_COMPRA)
            comando_e_local.Parameters.AddWithValue("@CVE_PROVEEDOR", dt_e.Rows(0)(0))
            comando_e_local.Parameters.AddWithValue("@PROVEEDOR", dt_e.Rows(0)(1))
            comando_e_local.Parameters.AddWithValue("@ALMACEN ", dt_e.Rows(0)(2))
            comando_e_local.Parameters.AddWithValue("@REF_PROV", dt_e.Rows(0)(3))
            comando_e_local.Parameters.AddWithValue("@RFC", dt_e.Rows(0)(4))
            comando_e_local.Parameters.AddWithValue("@FECHA", Convert.ToDateTime(dt_e.Rows(0)(5)))
            comando_e_local.Parameters.AddWithValue("@DESCUENTO_POR", dt_e.Rows(0)(6))
            comando_e_local.Parameters.AddWithValue("@SUB_TOTAL", dt_e.Rows(0)(7))
            comando_e_local.Parameters.AddWithValue("@DESCUENTO_VAL", dt_e.Rows(0)(8))
            comando_e_local.Parameters.AddWithValue("@ISV_VAL", dt_e.Rows(0)(9))
            comando_e_local.Parameters.AddWithValue("@TOTAL", dt_e.Rows(0)(10))
            comando_e_local.Parameters.AddWithValue("@ESTADO", "ENVIADO")
            comando_e_local.Parameters.AddWithValue("@TASA_CAMBIO", dt_e.Rows(0)(12))
            comando_e_local.Parameters.AddWithValue("@N_FACTURA_SAE", CVE_DOC)
            comando_e_local.Parameters.AddWithValue("@FLETE", dt_e.Rows(0)(14))
            comando_e_local.Parameters.AddWithValue("@SEGURO", dt_e.Rows(0)(15))
            comando_e_local.Parameters.AddWithValue("@PYC", dt_e.Rows(0)(16))
            comando_e_local.Parameters.AddWithValue("@HONORARIOS", dt_e.Rows(0)(17))
            comando_e_local.Parameters.AddWithValue("@AGENTE", agente)
            comando_e_local.Parameters.AddWithValue("@ALTA_AGENTE", "AC" & dt_refer_vesta.Rows(0)(0))
            comando_e_local.Parameters.AddWithValue("@FECHA_FACTURA", Convert.ToDateTime(dt_e.Rows(0)(18)))
            comando_e_local.Transaction = mi_transaccion
            comando_e_local.ExecuteNonQuery()

            Dim query_upd_prov As New StringBuilder
            query_upd_prov.Append("UPDATE [SAE60Empre02].[dbo].[PROV02] ")
            query_upd_prov.Append("SET [ULT_COMPD] = @ULT_COMPD ")
            query_upd_prov.Append(",[ULT_COMPM] =@ULT_COMPM ")
            query_upd_prov.Append(",[ULT_COMPF] =@ULT_COMPF ")
            query_upd_prov.Append(",[SALDO] = SALDO + @SALDO ")
            query_upd_prov.Append("WHERE([CLAVE] = @CLAVE)")
            Dim comando_upd_prov As New SqlCommand(query_upd_prov.ToString, sql_con)
            comando_upd_prov.Parameters.AddWithValue("@ULT_COMPD", CVE_DOC)
            comando_upd_prov.Parameters.AddWithValue("@ULT_COMPM", dt_e.Rows(0)(7) * dt_e.Rows(0)(12))
            comando_upd_prov.Parameters.AddWithValue("@ULT_COMPF", Convert.ToDateTime(dt_e.Rows(0)(5)))
            comando_upd_prov.Parameters.AddWithValue("@SALDO", dt_e.Rows(0)(7) * dt_e.Rows(0)(12))
            comando_upd_prov.Parameters.AddWithValue("@CLAVE", dt_e.Rows(0)(0))
            comando_upd_prov.Transaction = mi_transaccion
            comando_upd_prov.ExecuteNonQuery()

            Dim query_cve_docto_upd As New StringBuilder
            query_cve_docto_upd.Append("UPDATE [SAE60Empre02].[dbo].[FOLIOSC02] ")
            query_cve_docto_upd.Append("SET [ULT_DOC] = ULT_DOC + 1 , ")
            query_cve_docto_upd.Append("[FECH_ULT_DOC] = @FECH_ULT_DOC ")
            query_cve_docto_upd.Append("WHERE (TIP_DOC = 'c') AND (SERIE = @SERIE)")
            Dim comando_cve_docto_upd As New SqlCommand(query_cve_docto_upd.ToString, sql_con)
            comando_cve_docto_upd.Parameters.AddWithValue("@FECH_ULT_DOC", Convert.ToDateTime(dt_e.Rows(0)(5)))
            comando_cve_docto_upd.Parameters.AddWithValue("@SERIE", serie)
            comando_cve_docto_upd.Transaction = mi_transaccion
            comando_cve_docto_upd.ExecuteNonQuery()

            Dim conexion_bita As New cls_bitacora_reporteador
            conexion_bita.RegistraBitacora(Now, usuario, "Ingreso de compra Cargill", "COMPRAS", _
                                      "Fecha: " + Convert.ToDateTime(dt_e.Rows(0)(5)) + " Numero de Compra SAE: " + CVE_DOC + _
                                      " Numero de Compra Rep:" + CVE_COMPRA + " almacen:" + dt_e.Rows(0)(2))

            mi_transaccion.Commit()
            sql_con.Close()
            Return "correcto"
        Catch ex As Exception
            mi_transaccion.Rollback()
            sql_con.Close()
            Dim tamaño As Integer = Convert.ToString(ex.StackTrace).Length
            Dim posicion As Integer = InStrRev(Convert.ToString(ex.StackTrace), "línea") - 1
            Dim inicial As Integer = tamaño - posicion
            Dim linea_error As String = Convert.ToString(ex.StackTrace).Substring(tamaño - inicial, inicial)
            Return (ex.Message + " --> " + linea_error)
        End Try
    End Function

    Public Function envio_individual_importacion_local(ByVal dt_e As DataTable, ByVal dt_p As DataTable, ByVal CVE_COMPRA As String, _
                                                       ByVal conlote As String, ByVal lote As String, ByVal usuario As String _
                                                       , ByVal agente As String) As String
        Dim sql_con As New SqlConnection(conexion.CadenaSQL)
        Dim mi_transaccion As SqlTransaction
        sql_con.Open()
        mi_transaccion = sql_con.BeginTransaction

        Try
            Dim query_codigo As New StringBuilder
            query_codigo.Append("SELECT FOLIO + CONVERT(VARCHAR, ULT_DOC + 1) AS CLAVE,SERIE ")
            query_codigo.Append("FROM nd_folios ")
            query_codigo.Append("WHERE (NUM_ALMA = @ALMACEN) AND (TIPO = 'I')")
            Dim comando_codigo As New SqlCommand(query_codigo.ToString, sql_con)
            comando_codigo.Parameters.AddWithValue("@ALMACEN", dt_e.Rows(0)(2))
            comando_codigo.Transaction = mi_transaccion
            Dim dt As New DataTable
            Dim adaptador_codigo As New SqlDataAdapter(comando_codigo)
            adaptador_codigo.Fill(dt)
            Dim serie_local As String = ""
            serie_local = dt.Rows(0)(1)

            Dim query_cve_docto As New StringBuilder
            query_cve_docto.Append("SELECT SERIE, ULT_DOC ")
            query_cve_docto.Append("FROM SAE60EMPRE02.dbo.FOLIOSC02 ")
            query_cve_docto.Append("WHERE (TIP_DOC = 'c') AND (SERIE = @SERIE) ")
            Dim comando_cve_docto As New SqlCommand(query_cve_docto.ToString, sql_con)
            comando_cve_docto.Parameters.AddWithValue("@SERIE", serie_local)
            comando_cve_docto.Transaction = mi_transaccion
            Dim adaptador_cve_docto As New SqlDataAdapter(comando_cve_docto)
            Dim dt_cve_docto As New DataTable
            adaptador_cve_docto.Fill(dt_cve_docto)
            Dim CVE_DOC As String = ""
            Dim serie As String = ""
            Dim folio As Integer
            serie = dt_cve_docto.Rows(0)(0)
            folio = dt_cve_docto.Rows(0)(1) + 1
            CVE_DOC = serie & folio

            Dim ajuste As String = ""
            Dim debito As String = ""
            For index As Integer = 0 To dt_p.Rows.Count - 1
                If dt_p.Rows(index)(15) = "S" Then
                    ajuste = "S"
                End If

                If dt_p.Rows(index)(15) = "D" Then
                    debito = "D"
                End If
            Next

            ' registra los debito por producto
            If ajuste = "S" Then
                Dim query_folio_ajuste As New StringBuilder
                query_folio_ajuste.Append("SELECT FOLIO + CONVERT(VARCHAR, ULT_DOC + 1) AS ULT_DOC ")
                query_folio_ajuste.Append("FROM nd_folios ")
                query_folio_ajuste.Append("WHERE (TIPO = 'A') AND (NUM_ALMA = @ALMACEN)")
                Dim comando_folio_ajuste As New SqlCommand(query_folio_ajuste.ToString, sql_con)
                comando_folio_ajuste.Parameters.AddWithValue("@ALMACEN", dt_e.Rows(0)(2))
                comando_folio_ajuste.Transaction = mi_transaccion
                Dim dt_folio_ajuste As New DataTable
                Dim adaptador_folio_ajuste As New SqlDataAdapter(comando_folio_ajuste)
                adaptador_folio_ajuste.Fill(dt_folio_ajuste)

                Dim subtotal_ajuste_e As Double = 0, isv_ajuste_e As Double = 0, total_ajueste_e As Double = 0, descuento_ajuste_e As Double = 0
                For index As Integer = 0 To dt_p.Rows.Count - 1
                    If dt_p.Rows(index)(15) = "S" Then
                        Dim query_ajuste_p As New StringBuilder
                        query_ajuste_p.Append("INSERT INTO [tactical_discount_sragro].[dbo].[nd_ajuste_p] ")
                        query_ajuste_p.Append("([ID_AJUSTE],[NUM_PART],[CVE_ART],[DESCRIPCION],[MOTIVO],[CANTIDAD], ")
                        query_ajuste_p.Append("[FECHA_INGRESO],[COSTO_ANTERIOR],[COSTO_ACTUAL],[AJUSTE],[UNI]) ")
                        query_ajuste_p.Append("VALUES ")
                        query_ajuste_p.Append("(@ID_AJUSTE,@NUM_PART,@CVE_ART,@DESCRIPCION,@MOTIVO,@CANTIDAD, ")
                        query_ajuste_p.Append("@FECHA_INGRESO,@COSTO_ANTERIOR,@COSTO_ACTUAL,@AJUSTE,@UNI)")
                        Dim comando_ajuste_p As New SqlCommand(query_ajuste_p.ToString, sql_con)
                        comando_ajuste_p.Parameters.AddWithValue("@ID_AJUSTE", dt_folio_ajuste.Rows(0)(0))
                        comando_ajuste_p.Parameters.AddWithValue("@NUM_PART", index + 1)
                        comando_ajuste_p.Parameters.AddWithValue("@CVE_ART", dt_p.Rows(index)(1))
                        comando_ajuste_p.Parameters.AddWithValue("@DESCRIPCION", dt_p.Rows(index)(2))
                        comando_ajuste_p.Parameters.AddWithValue("@MOTIVO", "AJUSTE DE PRECIO")
                        comando_ajuste_p.Parameters.AddWithValue("@CANTIDAD", dt_p.Rows(index)(4))
                        comando_ajuste_p.Parameters.AddWithValue("@FECHA_INGRESO", Convert.ToDateTime(dt_e.Rows(0)(5)))
                        comando_ajuste_p.Parameters.AddWithValue("@COSTO_ANTERIOR", dt_p.Rows(index)(5))
                        comando_ajuste_p.Parameters.AddWithValue("@COSTO_ACTUAL", dt_p.Rows(index)(6))
                        Dim valor_ajuste As Double = 0
                        valor_ajuste = (Convert.ToDouble(dt_p.Rows(index)(4)) * Convert.ToDouble(dt_p.Rows(index)(6))) - _
                        (Convert.ToDouble(dt_p.Rows(index)(4)) * Convert.ToDouble(dt_p.Rows(index)(5)))
                        If dt_p.Rows(index)(0) = "cj" Then
                            valor_ajuste = valor_ajuste * Convert.ToDouble(dt_p.Rows(index)(3))
                        End If
                        comando_ajuste_p.Parameters.AddWithValue("@AJUSTE", valor_ajuste * -1)
                        comando_ajuste_p.Parameters.AddWithValue("@UNI", dt_p.Rows(index)(0))
                        subtotal_ajuste_e += valor_ajuste
                        descuento_ajuste_e += 0 'valor_ajuste * dt_p.Rows(index)(8) / 100
                        valor_ajuste = valor_ajuste - descuento_ajuste_e
                        isv_ajuste_e += 0 'valor_ajuste * dt_p.Rows(index)(9) / 100
                        comando_ajuste_p.Transaction = mi_transaccion
                        comando_ajuste_p.ExecuteNonQuery()
                    End If
                Next
                total_ajueste_e += subtotal_ajuste_e - descuento_ajuste_e + isv_ajuste_e

                Dim query_ajuste_e As New StringBuilder
                query_ajuste_e.Append("INSERT INTO [tactical_discount_sragro].[dbo].[nd_ajuste_e] ")
                query_ajuste_e.Append("([ID_AJUSTE],[CVE_PROVEEDOR],[ALMACEN],[REF_PROV]")
                query_ajuste_e.Append(",[FECHA],[N_FACTURA],[SUBTOTAL],[DESCUENTO],[ISV],[TOTAL],[COMPRA],[TIPO]) ")
                query_ajuste_e.Append("VALUES ")
                query_ajuste_e.Append("(@ID_AJUSTE,@CVE_PROVEEDOR,@ALMACEN,@REF_PROV,@FECHA, ")
                query_ajuste_e.Append("@N_FACTURA,@SUBTOTAL,@DESCUENTO,@ISV,@TOTAL,@COMPRA,@TIPO)")
                Dim comando_ajuste_e As New SqlCommand(query_ajuste_e.ToString, sql_con)
                comando_ajuste_e.Parameters.AddWithValue("@ID_AJUSTE", dt_folio_ajuste.Rows(0)(0))
                comando_ajuste_e.Parameters.AddWithValue("@CVE_PROVEEDOR", dt_e.Rows(0)(0))
                comando_ajuste_e.Parameters.AddWithValue("@ALMACEN", dt_e.Rows(0)(2))
                comando_ajuste_e.Parameters.AddWithValue("@REF_PROV", dt_e.Rows(0)(3))
                comando_ajuste_e.Parameters.AddWithValue("@FECHA", Convert.ToDateTime(dt_e.Rows(0)(5)))
                comando_ajuste_e.Parameters.AddWithValue("@N_FACTURA", CVE_DOC)
                comando_ajuste_e.Parameters.AddWithValue("@SUBTOTAL", subtotal_ajuste_e * -1)
                comando_ajuste_e.Parameters.AddWithValue("@DESCUENTO", descuento_ajuste_e * -1)
                comando_ajuste_e.Parameters.AddWithValue("@ISV", isv_ajuste_e * -1)
                comando_ajuste_e.Parameters.AddWithValue("@TOTAL", total_ajueste_e * -1)
                comando_ajuste_e.Parameters.AddWithValue("@COMPRA", CVE_COMPRA)
                comando_ajuste_e.Parameters.AddWithValue("@TIPO", "DEBITO")
                comando_ajuste_e.Transaction = mi_transaccion
                comando_ajuste_e.ExecuteNonQuery()

                Dim query_upd_folio_ajuste As New StringBuilder
                query_upd_folio_ajuste.Append("UPDATE [tactical_discount_sragro].[dbo].[nd_folios] ")
                query_upd_folio_ajuste.Append("   SET [ULT_DOC] = ULT_DOC+1 ")
                query_upd_folio_ajuste.Append("WHERE [NUM_ALMA] = @NUM_ALMA AND TIPO = 'A' ")
                Dim comando_upd_folio_ajuste As New SqlCommand(query_upd_folio_ajuste.ToString, sql_con)
                comando_upd_folio_ajuste.Parameters.AddWithValue("@NUM_ALMA", dt_e.Rows(0)(2))
                comando_upd_folio_ajuste.Transaction = mi_transaccion
                comando_upd_folio_ajuste.ExecuteNonQuery()

            End If
            ' fn registra los debitos por producto

            Dim query_dias_cred As New StringBuilder
            query_dias_cred.Append("Select ISNULL(DIASCRED,0) ")
            query_dias_cred.Append("FROM SAE60EMPRE02.dbo.PROV02 ")
            query_dias_cred.Append("WHERE (CLAVE = @CLAVE) ")
            Dim comando_dias_cred As New SqlCommand(query_dias_cred.ToString, sql_con)
            comando_dias_cred.Parameters.AddWithValue("@CLAVE", dt_e.Rows(0)(0))
            comando_dias_cred.Transaction = mi_transaccion
            Dim adaptador_dias_cred As New SqlDataAdapter(comando_dias_cred)
            Dim dt_dias_cred As New DataTable
            adaptador_dias_cred.Fill(dt_dias_cred)
            Dim dias_cred As Integer = 0
            dias_cred = dt_dias_cred.Rows(0)(0)

            ' registra los creditos por producto
            If debito = "D" Then
                Dim query_folio_debito As New StringBuilder
                query_folio_debito.Append("SELECT FOLIO + CONVERT(VARCHAR, ULT_DOC + 1) AS ULT_DOC ")
                query_folio_debito.Append("FROM nd_folios ")
                query_folio_debito.Append("WHERE (TIPO = 'D') AND (NUM_ALMA = @ALMACEN)")
                Dim comando_folio_debito As New SqlCommand(query_folio_debito.ToString, sql_con)
                comando_folio_debito.Parameters.AddWithValue("@ALMACEN", dt_e.Rows(0)(2))
                comando_folio_debito.Transaction = mi_transaccion
                Dim dt_folio_debito As New DataTable
                Dim adaptador_folio_debito As New SqlDataAdapter(comando_folio_debito)
                adaptador_folio_debito.Fill(dt_folio_debito)

                Dim subtotal_debito_e As Double = 0, isv_debito_e As Double = 0, total_debito_e As Double = 0, descuento_debito_e As Double = 0
                For index As Integer = 0 To dt_p.Rows.Count - 1
                    If dt_p.Rows(index)(15) = "D" Then
                        Dim query_debito_p As New StringBuilder
                        query_debito_p.Append("INSERT INTO [tactical_discount_sragro].[dbo].[nd_ajuste_p] ")
                        query_debito_p.Append("([ID_AJUSTE],[NUM_PART],[CVE_ART],[DESCRIPCION],[MOTIVO],[CANTIDAD], ")
                        query_debito_p.Append("[FECHA_INGRESO],[COSTO_ANTERIOR],[COSTO_ACTUAL],[AJUSTE],[UNI]) ")
                        query_debito_p.Append("VALUES ")
                        query_debito_p.Append("(@ID_AJUSTE,@NUM_PART,@CVE_ART,@DESCRIPCION,@MOTIVO,@CANTIDAD, ")
                        query_debito_p.Append("@FECHA_INGRESO,@COSTO_ANTERIOR,@COSTO_ACTUAL,@AJUSTE,@UNI)")
                        Dim comando_debito_p As New SqlCommand(query_debito_p.ToString, sql_con)
                        comando_debito_p.Parameters.AddWithValue("@ID_AJUSTE", dt_folio_debito.Rows(0)(0))
                        comando_debito_p.Parameters.AddWithValue("@NUM_PART", index + 1)
                        comando_debito_p.Parameters.AddWithValue("@CVE_ART", dt_p.Rows(index)(1))
                        comando_debito_p.Parameters.AddWithValue("@DESCRIPCION", dt_p.Rows(index)(2))
                        comando_debito_p.Parameters.AddWithValue("@MOTIVO", "AJUSTE DE PRECIO")
                        comando_debito_p.Parameters.AddWithValue("@CANTIDAD", dt_p.Rows(index)(4))
                        comando_debito_p.Parameters.AddWithValue("@FECHA_INGRESO", Convert.ToDateTime(dt_e.Rows(0)(5)))
                        comando_debito_p.Parameters.AddWithValue("@COSTO_ANTERIOR", dt_p.Rows(index)(5))
                        comando_debito_p.Parameters.AddWithValue("@COSTO_ACTUAL", dt_p.Rows(index)(6))
                        Dim valor_ajuste As Double = 0
                        valor_ajuste = (Convert.ToDouble(dt_p.Rows(index)(4)) * Convert.ToDouble(dt_p.Rows(index)(6))) - _
                        (Convert.ToDouble(dt_p.Rows(index)(4)) * Convert.ToDouble(dt_p.Rows(index)(5)))
                        If dt_p.Rows(index)(0) = "cj" Then
                            valor_ajuste = valor_ajuste * Convert.ToDouble(dt_p.Rows(index)(3))
                        End If
                        comando_debito_p.Parameters.AddWithValue("@AJUSTE", Math.Abs(valor_ajuste))
                        comando_debito_p.Parameters.AddWithValue("@UNI", dt_p.Rows(index)(0))

                        subtotal_debito_e += valor_ajuste
                        descuento_debito_e += 0 'valor_ajuste * dt_p.Rows(index)(8) / 100
                        valor_ajuste = valor_ajuste - descuento_debito_e
                        isv_debito_e += valor_ajuste * dt_p.Rows(index)(9) / 100
                        comando_debito_p.Transaction = mi_transaccion
                        comando_debito_p.ExecuteNonQuery()
                    End If
                Next
                total_debito_e += subtotal_debito_e - descuento_debito_e + isv_debito_e

                Dim query_debito_e As New StringBuilder
                query_debito_e.Append("INSERT INTO [tactical_discount_sragro].[dbo].[nd_ajuste_e] ")
                query_debito_e.Append("([ID_AJUSTE],[CVE_PROVEEDOR],[ALMACEN],[REF_PROV]")
                query_debito_e.Append(",[FECHA],[N_FACTURA],[SUBTOTAL],[DESCUENTO],[ISV],[TOTAL],[COMPRA],[TIPO]) ")
                query_debito_e.Append("VALUES ")
                query_debito_e.Append("(@ID_AJUSTE,@CVE_PROVEEDOR,@ALMACEN,@REF_PROV,@FECHA, ")
                query_debito_e.Append("@N_FACTURA,@SUBTOTAL,@DESCUENTO,@ISV,@TOTAL,@COMPRA,@TIPO)")
                Dim comando_debito_e As New SqlCommand(query_debito_e.ToString, sql_con)
                comando_debito_e.Parameters.AddWithValue("@ID_AJUSTE", dt_folio_debito.Rows(0)(0))
                comando_debito_e.Parameters.AddWithValue("@CVE_PROVEEDOR", dt_e.Rows(0)(0))
                comando_debito_e.Parameters.AddWithValue("@ALMACEN", dt_e.Rows(0)(2))
                comando_debito_e.Parameters.AddWithValue("@REF_PROV", dt_e.Rows(0)(3))
                comando_debito_e.Parameters.AddWithValue("@FECHA", Convert.ToDateTime(dt_e.Rows(0)(5)))
                comando_debito_e.Parameters.AddWithValue("@N_FACTURA", CVE_DOC)
                comando_debito_e.Parameters.AddWithValue("@SUBTOTAL", Math.Abs(subtotal_debito_e))
                comando_debito_e.Parameters.AddWithValue("@DESCUENTO", 0) 'Math.Abs(descuento_debito_e))
                comando_debito_e.Parameters.AddWithValue("@ISV", Math.Abs(isv_debito_e))
                comando_debito_e.Parameters.AddWithValue("@TOTAL", Math.Abs(total_debito_e))
                comando_debito_e.Parameters.AddWithValue("@COMPRA", CVE_COMPRA)
                comando_debito_e.Parameters.AddWithValue("@TIPO", "CREDITO")
                comando_debito_e.Transaction = mi_transaccion
                comando_debito_e.ExecuteNonQuery()

                Dim query_upd_folio_ajuste As New StringBuilder
                query_upd_folio_ajuste.Append("UPDATE [tactical_discount_sragro].[dbo].[nd_folios] ")
                query_upd_folio_ajuste.Append("   SET [ULT_DOC] = ULT_DOC+1 ")
                query_upd_folio_ajuste.Append("WHERE [NUM_ALMA] = @NUM_ALMA AND TIPO = 'D' ")
                Dim comando_upd_folio_ajuste As New SqlCommand(query_upd_folio_ajuste.ToString, sql_con)
                comando_upd_folio_ajuste.Parameters.AddWithValue("@NUM_ALMA", dt_e.Rows(0)(2))
                comando_upd_folio_ajuste.Transaction = mi_transaccion
                comando_upd_folio_ajuste.ExecuteNonQuery()

                Dim query_opaga As New StringBuilder
                query_opaga.Append("INSERT INTO [SAE60Empre02].[dbo].[OPAGA02] ")
                query_opaga.Append("([CVE_OBS],[STR_OBS]) ")
                query_opaga.Append("VALUES ((SELECT ULT_CVE + 1 AS ULT_CVE FROM SAE60EMPRE02.dbo.TBLCONTROL02 WHERE (ID_TABLA = 21)),'NOTA DE CREDITO POR PRECIO MENOR DEL PROVEEDOR')")
                Dim comando_opaga As New SqlCommand(query_opaga.ToString, sql_con)
                comando_opaga.Transaction = mi_transaccion
                comando_opaga.ExecuteNonQuery()

                Dim query_paga_det As New StringBuilder
                query_paga_det.Append("INSERT INTO [SAE60Empre02].[dbo].[PAGA_DET02] ")
                query_paga_det.Append("([CVE_PROV],[REFER],[NUM_CPTO],[NUM_CARGO],[ID_MOV] ")
                query_paga_det.Append(",[CVE_OBS],[NO_FACTURA],[DOCTO],[IMPORTE],[FECHA_APLI],[FECHA_VENC] ")
                query_paga_det.Append(",[NUM_MONED],[TCAMBIO],[IMPMON_EXT],[FECHAELAB] ")
                query_paga_det.Append(",[TIPO_MOV],[SIGNO],[USUARIO] ")
                query_paga_det.Append(",[NO_PARTIDA]) ")
                query_paga_det.Append("VALUES ")
                query_paga_det.Append("(@CVE_PROV, @REFER, 29,1,1, (SELECT ULT_CVE + 1 AS ULT_CVE FROM SAE60EMPRE02.dbo.TBLCONTROL02 WHERE (ID_TABLA = 21)), ")
                query_paga_det.Append("@NO_FACTURA, @DOCTO, @IMPORTE, @FECHA_APLI, @FECHA_VENC, 1, ")
                query_paga_det.Append("1, @IMPMON_EXT, @FECHAELAB,'A', -1,0, 1) ")
                Dim comando_paga_det As New SqlCommand(query_paga_det.ToString, sql_con)
                comando_paga_det.Parameters.AddWithValue("@CVE_PROV", dt_e.Rows(0)(0))
                comando_paga_det.Parameters.AddWithValue("@REFER", CVE_DOC)
                comando_paga_det.Parameters.AddWithValue("@NO_FACTURA", CVE_DOC)
                comando_paga_det.Parameters.AddWithValue("@DOCTO", CVE_DOC)
                comando_paga_det.Parameters.AddWithValue("@IMPORTE", (Math.Abs(subtotal_debito_e) - Math.Abs(descuento_debito_e)) * dt_e.Rows(0)(12))
                comando_paga_det.Parameters.AddWithValue("@FECHA_APLI", Convert.ToDateTime(dt_e.Rows(0)(5)))
                comando_paga_det.Parameters.AddWithValue("@FECHA_VENC", Convert.ToDateTime(dt_e.Rows(0)(5)).AddDays(dias_cred))
                comando_paga_det.Parameters.AddWithValue("@IMPMON_EXT", (Math.Abs(subtotal_debito_e) - Math.Abs(descuento_debito_e)) * dt_e.Rows(0)(12))
                comando_paga_det.Parameters.AddWithValue("@FECHAELAB", Convert.ToDateTime(dt_e.Rows(0)(5)))
                comando_paga_det.Transaction = mi_transaccion
                comando_paga_det.ExecuteNonQuery()

                Dim query_upd_paga_det As New StringBuilder
                query_upd_paga_det.Append("UPDATE [SAE60Empre02].[dbo].[TBLCONTROL02] ")
                query_upd_paga_det.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                query_upd_paga_det.Append("WHERE ([ID_TABLA] = 21)")
                Dim comando_upd_paga_det As New SqlCommand(query_upd_paga_det.ToString, sql_con)
                comando_upd_paga_det.Transaction = mi_transaccion
                comando_upd_paga_det.ExecuteNonQuery()

            End If
            ' fin registra los creditos por producto

            'registrar envio a SAE
            Dim query_compc As New StringBuilder
            query_compc.Append("INSERT INTO [SAE60Empre02].[dbo].[COMPC02] ")
            query_compc.Append("([TIP_DOC],[CVE_DOC],[CVE_CLPV],[STATUS],[SU_REFER] ")
            query_compc.Append(",[FECHA_DOC],[FECHA_REC],[FECHA_PAG] ")
            query_compc.Append(",[CAN_TOT],[IMP_TOT1],[IMP_TOT2],[IMP_TOT3],[IMP_TOT4] ")
            query_compc.Append(",[DES_TOT],[DES_FIN],[TOT_IND],[OBS_COND],[CVE_OBS] ")
            query_compc.Append(",[NUM_ALMA],[ACT_CXP],[ACT_COI],[ENLAZADO],[TIP_DOC_E] ")
            query_compc.Append(",[NUM_MONED],[TIPCAMB],[NUM_PAGOS],[FECHAELAB] ")
            query_compc.Append(",[SERIE],[FOLIO],[CTLPOL],[ESCFD],[CONTADO],[BLOQ] ")
            query_compc.Append(",[DES_FIN_PORC],[DES_TOT_PORC],[IMPORTE],[TIP_DOC_ANT],[DOC_ANT]) ")
            query_compc.Append("VALUES ")
            query_compc.Append("('c', @CVE_DOC,@CVE_CLPV,'O',@SU_REFER,@FECHA_DOC ")
            query_compc.Append(",@FECHA_REC,@FECHA_PAG,@CAN_TOT,0,0,0,@IMP_TOT4,@DES_TOT,0,0 ")
            query_compc.Append(",'',0,@NUM_ALMA,'S','N','O','O',1,1,1,@FECHAELAB ")
            query_compc.Append(",@SERIE,@FOLIO,0,'N','N','N',0 ,@DES_TOT_PORC,@IMPORTE,'','' )")
            Dim comando_compc As New SqlCommand(query_compc.ToString, sql_con)
            comando_compc.Parameters.AddWithValue("@CVE_DOC", CVE_DOC)
            comando_compc.Parameters.AddWithValue("@CVE_CLPV", dt_e.Rows(0)(0))
            comando_compc.Parameters.AddWithValue("@SU_REFER", dt_e.Rows(0)(3))
            comando_compc.Parameters.AddWithValue("@FECHA_DOC", Convert.ToDateTime(dt_e.Rows(0)(5)))
            comando_compc.Parameters.AddWithValue("@FECHA_REC", Convert.ToDateTime(dt_e.Rows(0)(5)))
            comando_compc.Parameters.AddWithValue("@FECHA_PAG", Convert.ToDateTime(dt_e.Rows(0)(5)).AddDays(dias_cred)) 'Agregar dias de credito
            comando_compc.Parameters.AddWithValue("@CAN_TOT", dt_e.Rows(0)(7) * dt_e.Rows(0)(12))
            comando_compc.Parameters.AddWithValue("@IMP_TOT4", 0) 'dt_e.Rows(0)(9) * dt_e.Rows(0)(12))
            comando_compc.Parameters.AddWithValue("@DES_TOT", dt_e.Rows(0)(8) * dt_e.Rows(0)(12))
            comando_compc.Parameters.AddWithValue("@NUM_ALMA", dt_e.Rows(0)(2))
            comando_compc.Parameters.AddWithValue("@FECHAELAB", Now.Date)
            comando_compc.Parameters.AddWithValue("@SERIE", serie)
            comando_compc.Parameters.AddWithValue("@FOLIO", folio)
            comando_compc.Parameters.AddWithValue("@DES_TOT_PORC", dt_e.Rows(0)(6))
            comando_compc.Parameters.AddWithValue("@IMPORTE", ((dt_e.Rows(0)(7) - dt_e.Rows(0)(8)) * dt_e.Rows(0)(12)))
            comando_compc.Transaction = mi_transaccion
            comando_compc.ExecuteNonQuery()

            Dim query_compc_clib As New StringBuilder
            query_compc_clib.Append("INSERT INTO [SAE60Empre02].[dbo].[COMPC_CLIB02] ")
            query_compc_clib.Append(" ([CLAVE_DOC],[CAMPLIB1]) ")
            query_compc_clib.Append("VALUES (@CLAVE_DOC,@CAMPLIB1)")
            Dim comando_comp_clib As New SqlCommand(query_compc_clib.ToString, sql_con)
            comando_comp_clib.Parameters.AddWithValue("CLAVE_DOC", CVE_DOC)
            comando_comp_clib.Parameters.AddWithValue("@CAMPLIB1", Convert.ToDateTime(dt_e.Rows(0)(18)))
            comando_comp_clib.Transaction = mi_transaccion
            comando_comp_clib.ExecuteNonQuery()

            'inicio del for

            For index As Integer = 0 To dt_p.Rows.Count - 1
                Dim query_correlativo_lote As New StringBuilder
                query_correlativo_lote.Append("SELECT (ULT_CVE + 1) AS ULT_CVE ")
                query_correlativo_lote.Append("FROM SAE60EMPRE02.dbo.TBLCONTROL02 ")
                query_correlativo_lote.Append("WHERE (ID_TABLA = 67) ")
                Dim comando_correlativo_lote As New SqlCommand(query_correlativo_lote.ToString, sql_con)
                comando_correlativo_lote.Transaction = mi_transaccion
                Dim adaptador_correlativo_lote As New SqlDataAdapter(comando_correlativo_lote)
                Dim dt_correlativo_lote As New DataTable
                adaptador_correlativo_lote.Fill(dt_correlativo_lote)
                Dim correlativo_lote As Integer
                correlativo_lote = dt_correlativo_lote.Rows(0)(0)

                Dim query_par_compc As New StringBuilder
                query_par_compc.Append("INSERT INTO [SAE60Empre02].[dbo].[PAR_COMPC02] ")
                query_par_compc.Append("   ([CVE_DOC],[NUM_PAR],[CVE_ART],[CANT],[PXR],[PREC],[COST] ")
                query_par_compc.Append("   ,[IMPU1],[IMPU2],[IMPU3],[IMPU4],[IMP1APLA],[IMP2APLA],[IMP3APLA] ")
                query_par_compc.Append("   ,[IMP4APLA],[TOTIMP1],[TOTIMP2],[TOTIMP3],[TOTIMP4],[DESCU],[ACT_INV] ")
                query_par_compc.Append("   ,[TIP_CAM],[UNI_VENTA],[TIPO_ELEM],[TIPO_PROD],[CVE_OBS],[REG_SERIE] ")
                query_par_compc.Append("   ,[E_LTPD],[FACTCONV],[COST_DEV],[NUM_ALM],[MINDIRECTO],[NUM_MOV],[TOT_PARTIDA]) ")
                query_par_compc.Append("VALUES ")
                query_par_compc.Append("  (@CVE_DOC,@NUM_PAR,@CVE_ART, @CANT, @PXR, ISNULL((SELECT SAE60Empre02.dbo.PRECIO_X_PROD02.PRECIO ")
                query_par_compc.Append("FROM SAE60Empre02.dbo.INVE02 INNER JOIN SAE60Empre02.dbo.PRECIO_X_PROD02 ON ")
                query_par_compc.Append("SAE60Empre02.dbo.INVE02.CVE_ART = SAE60Empre02.dbo.PRECIO_X_PROD02.CVE_ART ")
                query_par_compc.Append("WHERE (SAE60Empre02.dbo.PRECIO_X_PROD02.CVE_PRECIO = 1) AND (SAE60Empre02.dbo.INVE02.CVE_ART = @CVE_ART)),0), @COST, 0, 0, 0, ")
                query_par_compc.Append("   @IMPU4, 0, 0, 0, 0, 0, 0, ")
                query_par_compc.Append("   0, @TOTIMP4, @DESCU, 'S', 1, @UNI_VENTA, 'N', ")
                query_par_compc.Append("   'P', 0,0,@E_LTPD,@FACTCONV, @COST_DEV, @NUM_ALM, ")
                query_par_compc.Append("   0, (SELECT ULT_CVE + 1 FROM SAE60EMPRE02.dbo.TBLCONTROL02 WHERE (ID_TABLA = 44)),@TOT_PARTIDA)")
                Dim comando_par_compc As New SqlCommand(query_par_compc.ToString, sql_con)
                comando_par_compc.Parameters.AddWithValue("@CVE_DOC", CVE_DOC)
                comando_par_compc.Parameters.AddWithValue("@NUM_PAR", index + 1)
                comando_par_compc.Parameters.AddWithValue("@CVE_ART", dt_p.Rows(index)(1))
                comando_par_compc.Parameters.AddWithValue("@CANT", Convert.ToDouble(dt_p.Rows(index)(4)))

                Dim cant_insertar As Double = 0
                Dim factor_conversion As Integer = 0
                Dim costo_insertar As Double = 0
                If dt_p.Rows(index)(0) = "cj" Then
                    cant_insertar = Convert.ToDouble(dt_p.Rows(index)(4)) * dt_p.Rows(index)(3)
                    factor_conversion = dt_p.Rows(index)(3)
                    costo_insertar = dt_p.Rows(index)(14) * dt_p.Rows(index)(3) * dt_e.Rows(0)(12)
                ElseIf dt_p.Rows(index)(0) = "pz" Then
                    cant_insertar = Convert.ToDouble(dt_p.Rows(index)(4))
                    costo_insertar = dt_p.Rows(index)(14) * dt_e.Rows(0)(12)
                    factor_conversion = 1
                End If

                comando_par_compc.Parameters.AddWithValue("@PXR", cant_insertar)
                comando_par_compc.Parameters.AddWithValue("@COST", costo_insertar)
                comando_par_compc.Parameters.AddWithValue("@IMPU4", 0) 'dt_p.Rows(index)(9))
                comando_par_compc.Parameters.AddWithValue("@TOTIMP4", 0) 'Convert.ToDouble(dt_p.Rows(index)(12)))
                comando_par_compc.Parameters.AddWithValue("@DESCU", dt_p.Rows(index)(8))
                comando_par_compc.Parameters.AddWithValue("@UNI_VENTA", dt_p.Rows(index)(0))

                If dt_p.Rows(index)(20) = "S" Then
                    comando_par_compc.Parameters.AddWithValue("@E_LTPD", correlativo_lote)
                Else
                    comando_par_compc.Parameters.AddWithValue("@E_LTPD", 0)
                End If

                comando_par_compc.Parameters.AddWithValue("@FACTCONV", factor_conversion)
                comando_par_compc.Parameters.AddWithValue("@COST_DEV", dt_p.Rows(index)(14) * dt_p.Rows(index)(3))
                comando_par_compc.Parameters.AddWithValue("@NUM_ALM", dt_e.Rows(0)(2))
                comando_par_compc.Parameters.AddWithValue("@TOT_PARTIDA", (Convert.ToDouble(dt_p.Rows(index)(4) * dt_p.Rows(index)(5) _
                                                                                            * dt_p.Rows(index)(3)) * dt_e.Rows(0)(12)))
                comando_par_compc.Transaction = mi_transaccion
                comando_par_compc.ExecuteNonQuery()

                Dim query_par_comp_clib As New StringBuilder
                query_par_comp_clib.Append("INSERT INTO [SAE60Empre02].[dbo].[PAR_COMPC_CLIB02] ")
                query_par_comp_clib.Append("   ([CLAVE_DOC],[NUM_PART]) ")
                query_par_comp_clib.Append("VALUES ")
                query_par_comp_clib.Append("   (@CLAVE_DOC,@NUM_PART) ")
                Dim comando_par_comp_clib As New SqlCommand(query_par_comp_clib.ToString, sql_con)
                comando_par_comp_clib.Parameters.AddWithValue("@CLAVE_DOC", CVE_DOC)
                comando_par_comp_clib.Parameters.AddWithValue("@NUM_PART", index + 1)
                comando_par_comp_clib.Transaction = mi_transaccion
                comando_par_comp_clib.ExecuteNonQuery()

                Dim query_costo_prom As New StringBuilder
                query_costo_prom.Append("SELECT ISNULL(EXIST,0),ISNULL(COSTO_PROM,0) FROM SAE60EMPRE02.dbo.INVE02 WHERE CVE_ART = @CVE_ART")
                Dim comando_costo_prom As New SqlCommand(query_costo_prom.ToString, sql_con)
                comando_costo_prom.Parameters.AddWithValue("@CVE_ART", dt_p.Rows(index)(1))
                comando_costo_prom.Transaction = mi_transaccion
                Dim adaptador_costo As New SqlDataAdapter(comando_costo_prom)
                Dim dt_costo_prom As New DataTable
                adaptador_costo.Fill(dt_costo_prom)
                Dim existencias_viejas As Double = 0, costo_prom_viejo As Double = 0
                existencias_viejas = dt_costo_prom.Rows(0)(0)
                costo_prom_viejo = dt_costo_prom.Rows(0)(1)

                Dim costo_prom_nuevo As Double = 0
                costo_prom_nuevo = ((existencias_viejas * costo_prom_viejo) + (cant_insertar * (dt_p.Rows(index)(7) * _
                                                                                    dt_e.Rows(0)(12)))) / (existencias_viejas + cant_insertar)


                Dim query_upd_inve As New StringBuilder
                query_upd_inve.Append("UPDATE SAE60EMPRE02.dbo.INVE02 ")
                query_upd_inve.Append("SET [EXIST] = (EXIST + @NUEVA_EXISTENCIA), ")
                query_upd_inve.Append("FCH_ULTCOM = @FECHA_ULTCOM, ")
                query_upd_inve.Append("[ULT_COSTO] = @ULT_COSTO, [COSTO_PROM] = @COSTO_PROM ")
                query_upd_inve.Append("WHERE [CVE_ART] = @CVE_ART ")
                Dim comando_upd_inve As New SqlCommand(query_upd_inve.ToString, sql_con)
                comando_upd_inve.Parameters.AddWithValue("@NUEVA_EXISTENCIA", cant_insertar)
                comando_upd_inve.Parameters.AddWithValue("@FECHA_ULTCOM", Now.Date)
                comando_upd_inve.Parameters.AddWithValue("@CVE_ART", dt_p.Rows(index)(1))
                comando_upd_inve.Parameters.AddWithValue("@ULT_COSTO", dt_p.Rows(index)(7) * dt_e.Rows(0)(12))
                comando_upd_inve.Parameters.AddWithValue("@COSTO_PROM", costo_prom_nuevo)

                comando_upd_inve.Transaction = mi_transaccion
                comando_upd_inve.ExecuteNonQuery()

                Dim query_upd_mult As New StringBuilder
                query_upd_mult.Append("UPDATE SAE60EMPRE02.dbo.MULT02 ")
                query_upd_mult.Append("SET [EXIST] = (EXIST + @NUEVA_EXISTENCIA) ")
                query_upd_mult.Append("WHERE  [CVE_ART] = @CVE_ART AND [CVE_ALM] = @CVE_ALM ")
                Dim comando_upd_mult As New SqlCommand(query_upd_mult.ToString, sql_con)
                comando_upd_mult.Parameters.AddWithValue("@NUEVA_EXISTENCIA", cant_insertar)
                comando_upd_mult.Parameters.AddWithValue("@CVE_ART", dt_p.Rows(index)(1))
                comando_upd_mult.Parameters.AddWithValue("@CVE_ALM", dt_e.Rows(0)(2))
                comando_upd_mult.Transaction = mi_transaccion
                comando_upd_mult.ExecuteNonQuery()

                If dt_p.Rows(index)(20) = "S" Then
                    Dim query_reg_lote As New StringBuilder
                    query_reg_lote.Append("SELECT (ULT_CVE + 1) AS ULT_CVE ")
                    query_reg_lote.Append("FROM SAE60EMPRE02.dbo.TBLCONTROL02 ")
                    query_reg_lote.Append("WHERE (ID_TABLA = 48) ")
                    Dim comando_reg_lote As New SqlCommand(query_reg_lote.ToString, sql_con)
                    comando_reg_lote.Transaction = mi_transaccion
                    Dim adaptador_reg_lote As New SqlDataAdapter(comando_reg_lote)
                    Dim dt_reg_lote As New DataTable
                    adaptador_reg_lote.Fill(dt_reg_lote)
                    Dim reg_lote As Integer
                    reg_lote = dt_reg_lote.Rows(0)(0)

                    Dim query_ltpd As New StringBuilder
                    query_ltpd.Append("INSERT INTO [SAE60Empre02].[dbo].[LTPD02] ")
                    query_ltpd.Append("   ([CVE_ART],[LOTE],[PEDIMENTO],[CVE_ALM] ")
                    query_ltpd.Append("   ,[FCHULTMOV],[NOM_ADUAN],[CANTIDAD],[REG_LTPD],[CVE_OBS] ")
                    query_ltpd.Append("   ,[CIUDAD],[FRONTERA],[GLN],[STATUS]) ")
                    query_ltpd.Append("VALUES ")
                    query_ltpd.Append("   (@CVE_ART,@LOTE,'',@CVE_ALM,@FCHULTMOV, ")
                    query_ltpd.Append("'', @CANTIDAD, @REG_LTPD, 0, '', '', '','A')")
                    Dim comando_ltpd As New SqlCommand(query_ltpd.ToString, sql_con)
                    comando_ltpd.Parameters.AddWithValue("@CVE_ART", dt_p.Rows(index)(1))

                    Dim codigo_lote As String = ""
                    If conlote = "S" Then
                        codigo_lote = lote
                    Else
                        codigo_lote = CVE_DOC
                    End If

                    comando_ltpd.Parameters.AddWithValue("@LOTE", codigo_lote)
                    comando_ltpd.Parameters.AddWithValue("@CVE_ALM", dt_e.Rows(0)(2))
                    comando_ltpd.Parameters.AddWithValue("@FCHULTMOV", Now.Date)
                    comando_ltpd.Parameters.AddWithValue("@CANTIDAD", cant_insertar)
                    comando_ltpd.Parameters.AddWithValue("@REG_LTPD", reg_lote)
                    comando_ltpd.Transaction = mi_transaccion
                    comando_ltpd.ExecuteNonQuery()

                    Dim query_enlace_ltpd As New StringBuilder
                    query_enlace_ltpd.Append("INSERT INTO [SAE60Empre02].[dbo].[ENLACE_LTPD02] ")
                    query_enlace_ltpd.Append("   ([E_LTPD],[REG_LTPD],[CANTIDAD],[PXRS]) ")
                    query_enlace_ltpd.Append("VALUES ")
                    query_enlace_ltpd.Append("   (@E_LTPD,@REG_LTPD, @CANTIDAD,@PXRS)")
                    Dim comando_enlace_ltpd As New SqlCommand(query_enlace_ltpd.ToString, sql_con)
                    comando_enlace_ltpd.Parameters.AddWithValue("@E_LTPD", correlativo_lote)
                    comando_enlace_ltpd.Parameters.AddWithValue("@REG_LTPD", reg_lote)
                    comando_enlace_ltpd.Parameters.AddWithValue("@CANTIDAD", cant_insertar)
                    comando_enlace_ltpd.Parameters.AddWithValue("@PXRS", cant_insertar)
                    comando_enlace_ltpd.Transaction = mi_transaccion
                    comando_enlace_ltpd.ExecuteNonQuery()

                    Dim query_upd_correlativo_lote As New StringBuilder
                    query_upd_correlativo_lote.Append("UPDATE [SAE60Empre02].[dbo].[TBLCONTROL02] ")
                    query_upd_correlativo_lote.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                    query_upd_correlativo_lote.Append("WHERE([ID_TABLA] = 67)")
                    Dim comando_upd_correlativo_lote As New SqlCommand(query_upd_correlativo_lote.ToString, sql_con)
                    comando_upd_correlativo_lote.Transaction = mi_transaccion
                    comando_upd_correlativo_lote.ExecuteNonQuery()

                    Dim query_upd_reg_lote As New StringBuilder
                    query_upd_reg_lote.Append("UPDATE [SAE60Empre02].[dbo].[TBLCONTROL02] ")
                    query_upd_reg_lote.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                    query_upd_reg_lote.Append("WHERE([ID_TABLA] = 48)")
                    Dim comando_upd_reg_lote As New SqlCommand(query_upd_reg_lote.ToString, sql_con)
                    comando_upd_reg_lote.Transaction = mi_transaccion
                    comando_upd_reg_lote.ExecuteNonQuery()
                End If


                Dim query_minve As New StringBuilder
                query_minve.Append("INSERT INTO [SAE60Empre02].[dbo].[MINVE02] ")
                query_minve.Append("   ([CVE_ART],[ALMACEN],[NUM_MOV],[CVE_CPTO],[FECHA_DOCU] ")
                query_minve.Append("   ,[TIPO_DOC],[REFER],[CLAVE_CLPV],[VEND],[CANT],[CANT_COST] ")
                query_minve.Append("   ,[PRECIO],[COSTO],[REG_SERIE],[UNI_VENTA] ")
                query_minve.Append("   ,[E_LTPD],[EXIST_G],[EXISTENCIA],[FACTOR_CON] ")
                query_minve.Append("   ,[FECHAELAB],[CVE_FOLIO],[SIGNO],[COSTEADO],[COSTO_PROM_INI] ")
                query_minve.Append("   ,[COSTO_PROM_FIN],[COSTO_PROM_GRAL],[DESDE_INVE],[MOV_ENLAZADO]) ")
                query_minve.Append("VALUES ")
                query_minve.Append("   (@CVE_ART, @ALMACEN,(SELECT ULT_CVE+1 FROM SAE60EMPRE02.dbo.TBLCONTROL02 WHERE (ID_TABLA = 44)),1,@FECHA_DOCU, 'c', @REFER, ")
                query_minve.Append("   @CLAVE_CLPV, '',@CANT, 0, 0, @COSTO,  ")
                query_minve.Append("   0,@UNI_VENTA, @E_LTPD,@CANT+ISNULL((SELECT EXIST FROM SAE60EMPRE02.dbo.INVE02 WHERE (CVE_ART = @CVE_ART)),0), ((SELECT EXIST FROM SAE60EMPRE02.dbo.MULT02 WHERE (CVE_ART = @CVE_ART) AND CVE_ALM = @ALMACEN)), @FACTOR_CON, ")
                query_minve.Append("   @FECHAELAB, (SELECT ULT_CVE+1 FROM SAE60EMPRE02.dbo.TBLCONTROL02 WHERE (ID_TABLA = 32)),'1','S', @COSTO_PROM_INI,@COSTO_PROM_FIN, ")
                query_minve.Append("   @COSTO_PROM_GRAL,'N',0)")
                Dim comando_minve As New SqlCommand(query_minve.ToString, sql_con)
                comando_minve.Parameters.AddWithValue("@CVE_ART", dt_p.Rows(index)(1))
                comando_minve.Parameters.AddWithValue("@ALMACEN", dt_e.Rows(0)(2))
                comando_minve.Parameters.AddWithValue("@FECHA_DOCU", Convert.ToDateTime(dt_e.Rows(0)(5)))
                comando_minve.Parameters.AddWithValue("@REFER", CVE_DOC)
                comando_minve.Parameters.AddWithValue("@CLAVE_CLPV", dt_e.Rows(0)(0))
                comando_minve.Parameters.AddWithValue("@CANT", cant_insertar)
                comando_minve.Parameters.AddWithValue("@COSTO", dt_p.Rows(index)(7) * dt_e.Rows(0)(12))
                comando_minve.Parameters.AddWithValue("@UNI_VENTA", dt_p.Rows(index)(0))
                If dt_p.Rows(index)(20) = "S" Then
                    comando_minve.Parameters.AddWithValue("@E_LTPD", correlativo_lote)
                Else
                    comando_minve.Parameters.AddWithValue("@E_LTPD", 0)
                End If

                comando_minve.Parameters.AddWithValue("@FACTOR_CON", factor_conversion)
                comando_minve.Parameters.AddWithValue("@FECHAELAB", Convert.ToDateTime(dt_e.Rows(0)(5)))
                comando_minve.Parameters.AddWithValue("@COSTO_PROM_INI", costo_prom_viejo)
                comando_minve.Parameters.AddWithValue("@COSTO_PROM_FIN", costo_prom_nuevo)
                comando_minve.Parameters.AddWithValue("@COSTO_PROM_GRAL", costo_prom_nuevo)
                comando_minve.Transaction = mi_transaccion
                comando_minve.ExecuteNonQuery()

                Dim query_num_mov_minve As New StringBuilder
                query_num_mov_minve.Append("UPDATE [SAE60Empre02].[dbo].[TBLCONTROL02] ")
                query_num_mov_minve.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                query_num_mov_minve.Append("WHERE([ID_TABLA] = 44)")
                Dim comando_num_mov_minve As New SqlCommand(query_num_mov_minve.ToString, sql_con)
                comando_num_mov_minve.Transaction = mi_transaccion
                comando_num_mov_minve.ExecuteNonQuery()

                Dim query_upd_folio_minve As New StringBuilder
                query_upd_folio_minve.Append("UPDATE SAE60EMPRE02.dbo.TBLCONTROL02 ")
                query_upd_folio_minve.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                query_upd_folio_minve.Append("WHERE (ID_TABLA = 32) ")
                Dim comando_upd_folio_minve As New SqlCommand(query_upd_folio_minve.ToString, sql_con)
                comando_upd_folio_minve.Transaction = mi_transaccion
                comando_upd_folio_minve.ExecuteNonQuery()
            Next
            'fin del for
            Dim query_paga_m As New StringBuilder
            query_paga_m.Append("INSERT INTO [SAE60Empre02].[dbo].[PAGA_M02] ")
            query_paga_m.Append("   ([CVE_PROV],[REFER],[NUM_CARGO],[NUM_CPTO],[CVE_OBS] ")
            query_paga_m.Append("   ,[NO_FACTURA],[DOCTO],[IMPORTE],[FECHA_APLI],[FECHA_VENC],[AFEC_COI] ")
            query_paga_m.Append("   ,[NUM_MONED],[TCAMBIO],[IMPMON_EXT],[FECHAELAB],[TIPO_MOV],[SIGNO],[USUARIO],[STATUS]) ")
            query_paga_m.Append("VALUES ")
            query_paga_m.Append("   (@CVE_PROV, @REFER, 1, 1, 0, @NO_FACTURA, ")
            query_paga_m.Append("   @DOCTO,@IMPORTE,@FECHA_APLI, @FECHA_VENC, 'A',1, 1, ")
            query_paga_m.Append("   @IMPMON_EXT,@FECHAELAB, 'C', 1, ")
            query_paga_m.Append("   @USUARIO, 'A')")
            Dim comando_paga_m As New SqlCommand(query_paga_m.ToString, sql_con)
            comando_paga_m.Parameters.AddWithValue("@CVE_PROV", dt_e.Rows(0)(0))
            comando_paga_m.Parameters.AddWithValue("@REFER", CVE_DOC)
            comando_paga_m.Parameters.AddWithValue("@DOCTO", CVE_DOC)
            comando_paga_m.Parameters.AddWithValue("@NO_FACTURA", dt_e.Rows(0)(3))
            comando_paga_m.Parameters.AddWithValue("@IMPORTE", dt_e.Rows(0)(7) * dt_e.Rows(0)(12))
            comando_paga_m.Parameters.AddWithValue("@FECHA_APLI", Convert.ToDateTime(dt_e.Rows(0)(5)))
            comando_paga_m.Parameters.AddWithValue("@FECHA_VENC", Convert.ToDateTime(dt_e.Rows(0)(5)).AddDays(dias_cred))
            comando_paga_m.Parameters.AddWithValue("@IMPMON_EXT", dt_e.Rows(0)(7) * dt_e.Rows(0)(12))
            comando_paga_m.Parameters.AddWithValue("@FECHAELAB", Convert.ToDateTime(dt_e.Rows(0)(5)))
            comando_paga_m.Parameters.AddWithValue("@USUARIO", 0)
            comando_paga_m.Transaction = mi_transaccion
            comando_paga_m.ExecuteNonQuery()
            'afectar cuenta VESTA CUSTOM

            Dim query_refer_vesta As New StringBuilder
            query_refer_vesta.Append(" SELECT (ULT_DOC + 1) ")
            query_refer_vesta.Append(" FROM SAE60EMPRE02.dbo.FOLIOSC02 WHERE (TIP_DOC = 'c') AND (SERIE = 'AC') ")
            Dim comando_refer_vesta As New SqlCommand(query_refer_vesta.ToString, sql_con)
            comando_refer_vesta.Transaction = mi_transaccion
            Dim dt_refer_vesta As New DataTable
            Dim adaptador_vesta As New SqlDataAdapter(comando_refer_vesta)
            adaptador_vesta.Fill(dt_refer_vesta)

            Dim query_paga_m_vesta As New StringBuilder
            query_paga_m_vesta.Append("INSERT INTO [SAE60Empre02].[dbo].[PAGA_M02] ")
            query_paga_m_vesta.Append("   ([CVE_PROV],[REFER],[NUM_CARGO],[NUM_CPTO],[CVE_OBS] ")
            query_paga_m_vesta.Append("   ,[NO_FACTURA],[DOCTO],[IMPORTE],[FECHA_APLI],[FECHA_VENC],[AFEC_COI] ")
            query_paga_m_vesta.Append("   ,[NUM_MONED],[TCAMBIO],[IMPMON_EXT],[FECHAELAB],[TIPO_MOV],[SIGNO],[USUARIO],[STATUS]) ")
            query_paga_m_vesta.Append("VALUES ")
            query_paga_m_vesta.Append("   (@CVE_PROV, @REFER, 1, 1, 0, @NO_FACTURA, ")
            query_paga_m_vesta.Append("   @DOCTO,@IMPORTE,@FECHA_APLI, @FECHA_VENC, '',1, 1, ")
            query_paga_m_vesta.Append("   @IMPMON_EXT,@FECHAELAB, 'C', 1, ")
            query_paga_m_vesta.Append("   @USUARIO, 'A')")
            Dim comando_paga_m_vesta As New SqlCommand(query_paga_m_vesta.ToString, sql_con)
            comando_paga_m_vesta.Parameters.AddWithValue("@CVE_PROV", agente)
            comando_paga_m_vesta.Parameters.AddWithValue("@REFER", "AC" & dt_refer_vesta.Rows(0)(0))
            comando_paga_m_vesta.Parameters.AddWithValue("@DOCTO", "AC" & dt_refer_vesta.Rows(0)(0))
            comando_paga_m_vesta.Parameters.AddWithValue("@NO_FACTURA", dt_e.Rows(0)(3))
            comando_paga_m_vesta.Parameters.AddWithValue("@IMPORTE", (Convert.ToDouble(dt_e.Rows(0)(9)) + Convert.ToDouble(dt_e.Rows(0)(14)) + Convert.ToDouble(dt_e.Rows(0)(15)) + Convert.ToDouble(dt_e.Rows(0)(16)) + Convert.ToDouble(dt_e.Rows(0)(17))) * Convert.ToDouble(dt_e.Rows(0)(12)))
            comando_paga_m_vesta.Parameters.AddWithValue("@FECHA_APLI", Convert.ToDateTime(dt_e.Rows(0)(5)))
            comando_paga_m_vesta.Parameters.AddWithValue("@FECHA_VENC", Convert.ToDateTime(dt_e.Rows(0)(5)).AddDays(dias_cred))
            comando_paga_m_vesta.Parameters.AddWithValue("@IMPMON_EXT", (Convert.ToDouble(dt_e.Rows(0)(9)) + Convert.ToDouble(dt_e.Rows(0)(14)) + Convert.ToDouble(dt_e.Rows(0)(15)) + Convert.ToDouble(dt_e.Rows(0)(16)) + Convert.ToDouble(dt_e.Rows(0)(17))) * Convert.ToDouble(dt_e.Rows(0)(12)))
            comando_paga_m_vesta.Parameters.AddWithValue("@FECHAELAB", Convert.ToDateTime(dt_e.Rows(0)(5)))
            comando_paga_m_vesta.Parameters.AddWithValue("@USUARIO", 0)
            comando_paga_m_vesta.Transaction = mi_transaccion
            comando_paga_m_vesta.ExecuteNonQuery()

            'CAMBIAR ESTADO DE COMPRA LOCAL
            Dim query_compra_local As New StringBuilder
            query_compra_local.Append("UPDATE [tactical_discount_sragro].[dbo].[nd_importaciones_e]")
            query_compra_local.Append("   SET [ESTADO] = 'ENVIADA' ,[N_FACTURA_SAE] = @N_FACTURA_SAE, [AGENTE] = @AGENTE, ")
            query_compra_local.Append("       [ALTA_AGENTE] = @ALTA_AGENTE, [FECHA_FACTURA] = @FECHA_FACTURA ")
            query_compra_local.Append(" WHERE [CVE_COMPRA] = @CVE_COMPRA")
            Dim comando_local As New SqlCommand(query_compra_local.ToString, sql_con)
            comando_local.Parameters.AddWithValue("@N_FACTURA_SAE", CVE_DOC)
            comando_local.Parameters.AddWithValue("@CVE_COMPRA", CVE_COMPRA)
            comando_local.Parameters.AddWithValue("@AGENTE", agente)
            comando_local.Parameters.AddWithValue("@ALTA_AGENTE", "AC" & dt_refer_vesta.Rows(0)(0))
            comando_local.Parameters.AddWithValue("@FECHA_FACTURA", Convert.ToDateTime(dt_e.Rows(0)(18)))
            comando_local.Transaction = mi_transaccion
            comando_local.ExecuteNonQuery()

            'fin de las IMPORTACIONES locales

            Dim query_upd_refer_vesta As New StringBuilder
            query_upd_refer_vesta.Append("UPDATE SAE60EMPRE02.dbo.FOLIOSC02 ")
            query_upd_refer_vesta.Append("SET ULT_DOC = (ULT_DOC + 1) WHERE (TIP_DOC = 'c') AND (SERIE = 'AC') ")
            Dim comando_upd_refer_vesta As New SqlCommand(query_upd_refer_vesta.ToString, sql_con)
            comando_upd_refer_vesta.Transaction = mi_transaccion
            comando_upd_refer_vesta.ExecuteNonQuery()

            Dim query_upd_prov As New StringBuilder
            query_upd_prov.Append("UPDATE [SAE60Empre02].[dbo].[PROV02] ")
            query_upd_prov.Append("SET [ULT_COMPD] = @ULT_COMPD ")
            query_upd_prov.Append(",[ULT_COMPM] =@ULT_COMPM ")
            query_upd_prov.Append(",[ULT_COMPF] =@ULT_COMPF ")
            query_upd_prov.Append(",[SALDO] = SALDO + @SALDO ")
            query_upd_prov.Append("WHERE([CLAVE] = @CLAVE)")
            Dim comando_upd_prov As New SqlCommand(query_upd_prov.ToString, sql_con)
            comando_upd_prov.Parameters.AddWithValue("@ULT_COMPD", CVE_DOC)
            comando_upd_prov.Parameters.AddWithValue("@ULT_COMPM", dt_e.Rows(0)(7) * dt_e.Rows(0)(12))
            comando_upd_prov.Parameters.AddWithValue("@ULT_COMPF", Convert.ToDateTime(dt_e.Rows(0)(5)))
            comando_upd_prov.Parameters.AddWithValue("@SALDO", dt_e.Rows(0)(7) * dt_e.Rows(0)(12))
            comando_upd_prov.Parameters.AddWithValue("@CLAVE", dt_e.Rows(0)(0))
            comando_upd_prov.Transaction = mi_transaccion
            comando_upd_prov.ExecuteNonQuery()

            Dim query_cve_docto_upd As New StringBuilder
            query_cve_docto_upd.Append("UPDATE [SAE60Empre02].[dbo].[FOLIOSC02] ")
            query_cve_docto_upd.Append("SET [ULT_DOC] = ULT_DOC + 1 , ")
            query_cve_docto_upd.Append("[FECH_ULT_DOC] = @FECH_ULT_DOC ")
            query_cve_docto_upd.Append("WHERE (TIP_DOC = 'c') AND (SERIE = @SERIE)")
            Dim comando_cve_docto_upd As New SqlCommand(query_cve_docto_upd.ToString, sql_con)
            comando_cve_docto_upd.Parameters.AddWithValue("@FECH_ULT_DOC", Convert.ToDateTime(dt_e.Rows(0)(5)))
            comando_cve_docto_upd.Parameters.AddWithValue("@SERIE", serie)
            comando_cve_docto_upd.Transaction = mi_transaccion
            comando_cve_docto_upd.ExecuteNonQuery()

            Dim conexion_bita As New cls_bitacora_reporteador
            conexion_bita.RegistraBitacora(Now, usuario, "Ingreso de Importacion SR Agro", "COMPRAS", _
                                      "Fecha: " + Convert.ToDateTime(dt_e.Rows(0)(5)) + " Numero de Compra SAE: " + CVE_DOC + _
                                      " Numero de Compra Rep:" + CVE_COMPRA + " almacen:" + dt_e.Rows(0)(2))

            mi_transaccion.Commit()
            sql_con.Close()
            Return "correcto"
        Catch ex As Exception
            mi_transaccion.Rollback()
            sql_con.Close()
            Dim tamaño As Integer = Convert.ToString(ex.StackTrace).Length
            Dim posicion As Integer = InStrRev(Convert.ToString(ex.StackTrace), "línea") - 1
            Dim inicial As Integer = tamaño - posicion
            Dim linea_error As String = Convert.ToString(ex.StackTrace).Substring(tamaño - inicial, inicial)
            Return (ex.Message + " --> " + linea_error)
        End Try
    End Function

    Public Function guardar_compras_local_envio_SAE_CARGILL(ByVal dt_e As DataTable, ByVal dt_p As DataTable, _
                                                                ByVal conlote As String, ByVal lote As String, ByVal usuario As String) As String
        Dim sql_con As New SqlConnection(conexion.CadenaSQL)
        Dim mi_transaccion As SqlTransaction
        sql_con.Open()
        mi_transaccion = sql_con.BeginTransaction

        Try
            Dim query_codigo As New StringBuilder
            query_codigo.Append("SELECT FOLIO + CONVERT(VARCHAR, ULT_DOC + 1) AS CLAVE,FOLIO ")
            query_codigo.Append("FROM nd_folios ")
            query_codigo.Append("WHERE (NUM_ALMA = @ALMACEN) AND (TIPO = 'C')")
            Dim comando_codigo As New SqlCommand(query_codigo.ToString, sql_con)
            comando_codigo.Parameters.AddWithValue("@ALMACEN", dt_e.Rows(0)(2))
            comando_codigo.Transaction = mi_transaccion
            Dim dt As New DataTable
            Dim adaptador_codigo As New SqlDataAdapter(comando_codigo)
            adaptador_codigo.Fill(dt)
            Dim CVE_COMPRA As String = ""
            CVE_COMPRA = dt.Rows(0)(0)
            Dim serie_local As String = ""
            serie_local = dt.Rows(0)(1)

            Dim query_cve_docto As New StringBuilder
            query_cve_docto.Append("SELECT SERIE, ULT_DOC ")
            query_cve_docto.Append("FROM SAE60EMPRE02.dbo.FOLIOSC02 ")
            query_cve_docto.Append("WHERE (TIP_DOC = 'c') AND (SERIE = @SERIE) ")
            Dim comando_cve_docto As New SqlCommand(query_cve_docto.ToString, sql_con)
            comando_cve_docto.Parameters.AddWithValue("@SERIE", serie_local)
            comando_cve_docto.Transaction = mi_transaccion
            Dim adaptador_cve_docto As New SqlDataAdapter(comando_cve_docto)
            Dim dt_cve_docto As New DataTable
            adaptador_cve_docto.Fill(dt_cve_docto)
            Dim CVE_DOC As String = ""
            Dim serie As String = ""
            Dim folio As Integer
            serie = dt_cve_docto.Rows(0)(0)
            folio = dt_cve_docto.Rows(0)(1) + 1
            CVE_DOC = serie & folio

            Dim query_e_local As New StringBuilder
            query_e_local.Append("INSERT INTO [tactical_discount_sragro].[dbo].[nd_compras_e] ")
            query_e_local.Append("       ([CVE_COMPRA],[CVE_PROVEEDOR],[PROVEEDOR],[ALMACEN],[REF_PROV],[RFC],[FECHA],[DESCUENTO_POR],[SUB_TOTAL] ")
            query_e_local.Append("        ,[DESCUENTO_VAL],[ISV_VAL],[TOTAL],[ESTADO],[N_FACTURA_SAE],[SUBTOTAL_MOST],[DESC_MOST],[ISV_MOST] ")
            query_e_local.Append("        ,[TOTAL_MOST],[FLETE], [NUMERO_FLETE],[FECHA_FACTURA], [ISV_FLETE],[TOT_FLETE]) ")
            query_e_local.Append(" VALUES ")
            query_e_local.Append("       (@CVE_COMPRA,@CVE_PROVEEDOR,@PROVEEDOR,@ALMACEN,@REF_PROV,@RFC,@FECHA,@DESCUENTO_POR,@SUB_TOTAL ")
            query_e_local.Append("       ,@DESCUENTO_VAL,@ISV_VAL,@TOTAL,@ESTADO,@N_FACTURA_SAE,@SUBTOTAL_MOST,@DESC_MOST,@ISV_MOST ")
            query_e_local.Append("       ,@TOTAL_MOST,@FLETE, @NUMERO_FLETE,@FECHA_FACTURA,@ISV_FLETE,@TOT_FLETE)")
            Dim comando_e_local As New SqlCommand(query_e_local.ToString, sql_con)
            comando_e_local.Parameters.AddWithValue("@CVE_COMPRA", CVE_COMPRA)
            comando_e_local.Parameters.AddWithValue("@CVE_PROVEEDOR", dt_e.Rows(0)(0))
            comando_e_local.Parameters.AddWithValue("@PROVEEDOR", dt_e.Rows(0)(1))
            comando_e_local.Parameters.AddWithValue("@ALMACEN ", dt_e.Rows(0)(2))
            comando_e_local.Parameters.AddWithValue("@REF_PROV", dt_e.Rows(0)(3))
            comando_e_local.Parameters.AddWithValue("@RFC", dt_e.Rows(0)(4))
            comando_e_local.Parameters.AddWithValue("@FECHA", Convert.ToDateTime(dt_e.Rows(0)(5)))
            comando_e_local.Parameters.AddWithValue("@DESCUENTO_POR", dt_e.Rows(0)(6))
            comando_e_local.Parameters.AddWithValue("@SUB_TOTAL", dt_e.Rows(0)(7))
            comando_e_local.Parameters.AddWithValue("@DESCUENTO_VAL", dt_e.Rows(0)(8))
            comando_e_local.Parameters.AddWithValue("@ISV_VAL", dt_e.Rows(0)(9))
            comando_e_local.Parameters.AddWithValue("@TOTAL", dt_e.Rows(0)(10))
            comando_e_local.Parameters.AddWithValue("@ESTADO", "ENVIADA")
            comando_e_local.Parameters.AddWithValue("@N_FACTURA_SAE", CVE_DOC)
            comando_e_local.Parameters.AddWithValue("@SUBTOTAL_MOST", dt_e.Rows(0)(12))
            comando_e_local.Parameters.AddWithValue("@DESC_MOST", dt_e.Rows(0)(13))
            comando_e_local.Parameters.AddWithValue("@ISV_MOST", dt_e.Rows(0)(14))
            comando_e_local.Parameters.AddWithValue("@TOTAL_MOST", dt_e.Rows(0)(15))
            comando_e_local.Parameters.AddWithValue("@FLETE", dt_e.Rows(0)(16))
            comando_e_local.Parameters.AddWithValue("@NUMERO_FLETE", dt_e.Rows(0)(17))
            comando_e_local.Parameters.AddWithValue("@FECHA_FACTURA", Convert.ToDateTime(dt_e.Rows(0)(18)))

            comando_e_local.Parameters.AddWithValue("@ISV_FLETE", dt_e.Rows(0)(19))
            comando_e_local.Parameters.AddWithValue("@TOT_FLETE", dt_e.Rows(0)(20))

            comando_e_local.Transaction = mi_transaccion
            comando_e_local.ExecuteNonQuery()

            For index As Integer = 0 To dt_p.Rows.Count - 1
                Dim query_p_local As New StringBuilder
                query_p_local.Append("INSERT INTO [tactical_discount_sragro].[dbo].[nd_compras_p] ")
                query_p_local.Append("([CVE_COMPRA],[NUM_PART],[UNI],[CVE_ART],[PRODUCTO] ")
                query_p_local.Append(",[FACT_CONV],[CANTIDAD],[PRECIO_NEG],[PRECIO_FINAL] ")
                query_p_local.Append(",[DESC_PROD],[ISV_PROD],[SUB_TOTAL],[DESCUENTO] ")
                query_p_local.Append(",[ISV],[TOTAL_PARTIDA],[PRECIO_INSERTAR],[AJUSTE], ")
                query_p_local.Append("[SUBTOTAL_MOST],[DESC_MOST],[ISV_MOST],[TOTAL_MOST],[PRECIO_NETO],[PESO],[CON_LOTE], [PORC_PP], [DESCUENTO_PP], [DESCUENTO_PP_MOSTR]) ")
                query_p_local.Append("VALUES ")
                query_p_local.Append("(@CVE_COMPRA,@NUM_PART,@UNI,@CVE_ART,@PRODUCTO, ")
                query_p_local.Append("@FACT_CONV,@CANTIDAD,@PRECIO_NEG,@PRECIO_FINAL, ")
                query_p_local.Append("@DESC_PROD,@ISV_PROD,@SUB_TOTAL,@DESCUENTO, ")
                query_p_local.Append("@ISV,@TOTAL_PARTIDA,@PRECIO_INSERTAR,@AJUSTE, ")
                query_p_local.Append(" @SUBTOTAL_MOST, @DESC_MOST,@ISV_MOST,@TOTAL_MOST,@PRECIO_NETO,@PESO,@CON_LOTE, @PORC_PP, @DESCUENTO_PP, @DESCUENTO_PP_MOSTR) ")
                Dim comando_p_local As New SqlCommand(query_p_local.ToString, sql_con)

                comando_p_local.Parameters.AddWithValue("@CVE_COMPRA", CVE_COMPRA)
                comando_p_local.Parameters.AddWithValue("@NUM_PART", index + 1)
                comando_p_local.Parameters.AddWithValue("@UNI", dt_p.Rows(index)(0))
                comando_p_local.Parameters.AddWithValue("@CVE_ART", dt_p.Rows(index)(1))
                comando_p_local.Parameters.AddWithValue("@PRODUCTO", dt_p.Rows(index)(2))
                comando_p_local.Parameters.AddWithValue("@FACT_CONV", dt_p.Rows(index)(3))
                comando_p_local.Parameters.AddWithValue("@CANTIDAD", Convert.ToDouble(dt_p.Rows(index)(4)))
                comando_p_local.Parameters.AddWithValue("@PRECIO_NEG", dt_p.Rows(index)(5))
                comando_p_local.Parameters.AddWithValue("@PRECIO_FINAL", dt_p.Rows(index)(6))
                comando_p_local.Parameters.AddWithValue("@DESC_PROD", dt_p.Rows(index)(7))
                comando_p_local.Parameters.AddWithValue("@ISV_PROD", dt_p.Rows(index)(8))
                comando_p_local.Parameters.AddWithValue("@SUB_TOTAL", Convert.ToDouble(dt_p.Rows(index)(9)))
                comando_p_local.Parameters.AddWithValue("@DESCUENTO", Convert.ToDouble(dt_p.Rows(index)(10)))
                comando_p_local.Parameters.AddWithValue("@ISV", Convert.ToDouble(dt_p.Rows(index)(11)))
                comando_p_local.Parameters.AddWithValue("@TOTAL_PARTIDA", Convert.ToDouble(dt_p.Rows(index)(12)))
                comando_p_local.Parameters.AddWithValue("@PRECIO_INSERTAR", dt_p.Rows(index)(13))
                comando_p_local.Parameters.AddWithValue("@AJUSTE", dt_p.Rows(index)(14))

                comando_p_local.Parameters.AddWithValue("@SUBTOTAL_MOST", dt_p.Rows(index)(16))
                comando_p_local.Parameters.AddWithValue("@DESC_MOST", dt_p.Rows(index)(17))
                comando_p_local.Parameters.AddWithValue("@ISV_MOST", dt_p.Rows(index)(18))
                comando_p_local.Parameters.AddWithValue("@TOTAL_MOST", dt_p.Rows(index)(19))
                comando_p_local.Parameters.AddWithValue("@PRECIO_NETO", dt_p.Rows(index)(20))
                comando_p_local.Parameters.AddWithValue("@PESO", dt_p.Rows(index)(21))
                comando_p_local.Parameters.AddWithValue("@CON_LOTE", dt_p.Rows(index)(22))

                comando_p_local.Parameters.AddWithValue("@PORC_PP", dt_p.Rows(index)(23))
                comando_p_local.Parameters.AddWithValue("@DESCUENTO_PP", dt_p.Rows(index)(24))
                comando_p_local.Parameters.AddWithValue("@DESCUENTO_PP_MOSTR", dt_p.Rows(index)(25))

                comando_p_local.Transaction = mi_transaccion
                comando_p_local.ExecuteNonQuery()
            Next

            Dim query_upd_codigo As New StringBuilder
            query_upd_codigo.Append("UPDATE [tactical_discount_sragro].[dbo].[nd_folios] ")
            query_upd_codigo.Append("SET [ULT_DOC] = ULT_DOC + 1 ")
            query_upd_codigo.Append("WHERE ([NUM_ALMA] = @NUM_ALMA And [TIPO] = 'C') ")
            Dim comando_upd_codigo As New SqlCommand(query_upd_codigo.ToString, sql_con)
            comando_upd_codigo.Parameters.AddWithValue("@NUM_ALMA", dt_e.Rows(0)(2))
            comando_upd_codigo.Transaction = mi_transaccion
            comando_upd_codigo.ExecuteNonQuery()

            'fin de las compras locales

            Dim ajuste As String = ""
            Dim debito As String = ""
            For index As Integer = 0 To dt_p.Rows.Count - 1
                If dt_p.Rows(index)(14) = "S" Then
                    ajuste = "S"
                End If

                If dt_p.Rows(index)(14) = "D" Then
                    debito = "D"
                End If
            Next

            ' registra los debito por producto
            If ajuste = "S" Then
                Dim query_folio_ajuste As New StringBuilder
                query_folio_ajuste.Append("SELECT FOLIO + CONVERT(VARCHAR, ULT_DOC + 1) AS ULT_DOC ")
                query_folio_ajuste.Append("FROM nd_folios ")
                query_folio_ajuste.Append("WHERE (TIPO = 'A') AND (NUM_ALMA = @ALMACEN)")
                Dim comando_folio_ajuste As New SqlCommand(query_folio_ajuste.ToString, sql_con)
                comando_folio_ajuste.Parameters.AddWithValue("@ALMACEN", dt_e.Rows(0)(2))
                comando_folio_ajuste.Transaction = mi_transaccion
                Dim dt_folio_ajuste As New DataTable
                Dim adaptador_folio_ajuste As New SqlDataAdapter(comando_folio_ajuste)
                adaptador_folio_ajuste.Fill(dt_folio_ajuste)

                Dim subtotal_ajuste_e As Double = 0, isv_ajuste_e As Double = 0, total_ajueste_e As Double = 0, descuento_ajuste_e As Double = 0
                For index As Integer = 0 To dt_p.Rows.Count - 1
                    If dt_p.Rows(index)(14) = "S" Then
                        Dim query_ajuste_p As New StringBuilder
                        query_ajuste_p.Append("INSERT INTO [tactical_discount_sragro].[dbo].[nd_ajuste_p] ")
                        query_ajuste_p.Append("([ID_AJUSTE],[NUM_PART],[CVE_ART],[DESCRIPCION],[MOTIVO],[CANTIDAD], ")
                        query_ajuste_p.Append("[FECHA_INGRESO],[COSTO_ANTERIOR],[COSTO_ACTUAL],[AJUSTE],[UNI]) ")
                        query_ajuste_p.Append("VALUES ")
                        query_ajuste_p.Append("(@ID_AJUSTE,@NUM_PART,@CVE_ART,@DESCRIPCION,@MOTIVO,@CANTIDAD, ")
                        query_ajuste_p.Append("@FECHA_INGRESO,@COSTO_ANTERIOR,@COSTO_ACTUAL,@AJUSTE,@UNI)")
                        Dim comando_ajuste_p As New SqlCommand(query_ajuste_p.ToString, sql_con)
                        comando_ajuste_p.Parameters.AddWithValue("@ID_AJUSTE", dt_folio_ajuste.Rows(0)(0))
                        comando_ajuste_p.Parameters.AddWithValue("@NUM_PART", index + 1)
                        comando_ajuste_p.Parameters.AddWithValue("@CVE_ART", dt_p.Rows(index)(1))
                        comando_ajuste_p.Parameters.AddWithValue("@DESCRIPCION", dt_p.Rows(index)(2))
                        comando_ajuste_p.Parameters.AddWithValue("@MOTIVO", "AJUSTE DE PRECIO")
                        comando_ajuste_p.Parameters.AddWithValue("@CANTIDAD", dt_p.Rows(index)(4))
                        comando_ajuste_p.Parameters.AddWithValue("@FECHA_INGRESO", Convert.ToDateTime(dt_e.Rows(0)(5)))
                        comando_ajuste_p.Parameters.AddWithValue("@COSTO_ANTERIOR", dt_p.Rows(index)(5))
                        comando_ajuste_p.Parameters.AddWithValue("@COSTO_ACTUAL", dt_p.Rows(index)(6))
                        Dim valor_ajuste As Double = 0

                        valor_ajuste = (Convert.ToDouble(dt_p.Rows(index)(4)) * Convert.ToDouble(dt_p.Rows(index)(6))) - (Convert.ToDouble(dt_p.Rows(index)(4)) * Convert.ToDouble(dt_p.Rows(index)(5)))
                        If dt_p.Rows(index)(0) = "cj" Then
                            valor_ajuste = valor_ajuste * Convert.ToDouble(dt_p.Rows(index)(3))
                        End If

                        comando_ajuste_p.Parameters.AddWithValue("@AJUSTE", valor_ajuste * -1)
                        comando_ajuste_p.Parameters.AddWithValue("@UNI", dt_p.Rows(index)(0))

                        subtotal_ajuste_e += valor_ajuste
                        descuento_ajuste_e += 0 'valor_ajuste * dt_p.Rows(index)(7) / 100
                        valor_ajuste = valor_ajuste - descuento_ajuste_e
                        isv_ajuste_e += valor_ajuste * dt_p.Rows(index)(8) / 100
                        comando_ajuste_p.Transaction = mi_transaccion
                        comando_ajuste_p.ExecuteNonQuery()
                    End If
                Next
                total_ajueste_e += subtotal_ajuste_e - descuento_ajuste_e + isv_ajuste_e

                Dim query_ajuste_e As New StringBuilder
                query_ajuste_e.Append("INSERT INTO [tactical_discount_sragro].[dbo].[nd_ajuste_e] ")
                query_ajuste_e.Append("([ID_AJUSTE],[CVE_PROVEEDOR],[ALMACEN],[REF_PROV]")
                query_ajuste_e.Append(",[FECHA],[N_FACTURA],[SUBTOTAL],[DESCUENTO],[ISV],[TOTAL],[COMPRA],[TIPO]) ")
                query_ajuste_e.Append("VALUES ")
                query_ajuste_e.Append("(@ID_AJUSTE,@CVE_PROVEEDOR,@ALMACEN,@REF_PROV,@FECHA, ")
                query_ajuste_e.Append("@N_FACTURA,@SUBTOTAL,@DESCUENTO,@ISV,@TOTAL,@COMPRA,@TIPO)")
                Dim comando_ajuste_e As New SqlCommand(query_ajuste_e.ToString, sql_con)
                comando_ajuste_e.Parameters.AddWithValue("@ID_AJUSTE", dt_folio_ajuste.Rows(0)(0))
                comando_ajuste_e.Parameters.AddWithValue("@CVE_PROVEEDOR", dt_e.Rows(0)(0))
                comando_ajuste_e.Parameters.AddWithValue("@ALMACEN", dt_e.Rows(0)(2))
                comando_ajuste_e.Parameters.AddWithValue("@REF_PROV", dt_e.Rows(0)(3))
                comando_ajuste_e.Parameters.AddWithValue("@FECHA", Convert.ToDateTime(dt_e.Rows(0)(5)))
                comando_ajuste_e.Parameters.AddWithValue("@N_FACTURA", CVE_DOC)
                comando_ajuste_e.Parameters.AddWithValue("@SUBTOTAL", subtotal_ajuste_e * -1)
                comando_ajuste_e.Parameters.AddWithValue("@DESCUENTO", 0) 'descuento_ajuste_e * -1)
                comando_ajuste_e.Parameters.AddWithValue("@ISV", isv_ajuste_e * -1)
                comando_ajuste_e.Parameters.AddWithValue("@TOTAL", total_ajueste_e * -1)
                comando_ajuste_e.Parameters.AddWithValue("@COMPRA", CVE_COMPRA)
                comando_ajuste_e.Parameters.AddWithValue("@TIPO", "DEBITO")
                comando_ajuste_e.Transaction = mi_transaccion
                comando_ajuste_e.ExecuteNonQuery()

                Dim query_upd_folio_ajuste As New StringBuilder
                query_upd_folio_ajuste.Append("UPDATE [tactical_discount_sragro].[dbo].[nd_folios] ")
                query_upd_folio_ajuste.Append("   SET [ULT_DOC] = ULT_DOC+1 ")
                query_upd_folio_ajuste.Append("WHERE [NUM_ALMA] = @NUM_ALMA AND TIPO = 'A' ")
                Dim comando_upd_folio_ajuste As New SqlCommand(query_upd_folio_ajuste.ToString, sql_con)
                comando_upd_folio_ajuste.Parameters.AddWithValue("@NUM_ALMA", dt_e.Rows(0)(2))
                comando_upd_folio_ajuste.Transaction = mi_transaccion
                comando_upd_folio_ajuste.ExecuteNonQuery()

            End If
            ' fn registra los debitos por producto

            Dim query_dias_cred As New StringBuilder
            query_dias_cred.Append("Select ISNULL(DIASCRED,0) ")
            query_dias_cred.Append("FROM SAE60EMPRE02.dbo.PROV02 ")
            query_dias_cred.Append("WHERE (CLAVE = @CLAVE) ")
            Dim comando_dias_cred As New SqlCommand(query_dias_cred.ToString, sql_con)
            comando_dias_cred.Parameters.AddWithValue("@CLAVE", dt_e.Rows(0)(0))
            comando_dias_cred.Transaction = mi_transaccion
            Dim adaptador_dias_cred As New SqlDataAdapter(comando_dias_cred)
            Dim dt_dias_cred As New DataTable
            adaptador_dias_cred.Fill(dt_dias_cred)
            Dim dias_cred As Integer = 0
            dias_cred = dt_dias_cred.Rows(0)(0)

            ' registra los creditos por producto
            If debito = "D" Then
                Dim query_folio_debito As New StringBuilder
                query_folio_debito.Append("SELECT FOLIO + CONVERT(VARCHAR, ULT_DOC + 1) AS ULT_DOC ")
                query_folio_debito.Append("FROM nd_folios ")
                query_folio_debito.Append("WHERE (TIPO = 'D') AND (NUM_ALMA = @ALMACEN)")
                Dim comando_folio_debito As New SqlCommand(query_folio_debito.ToString, sql_con)
                comando_folio_debito.Parameters.AddWithValue("@ALMACEN", dt_e.Rows(0)(2))
                comando_folio_debito.Transaction = mi_transaccion
                Dim dt_folio_debito As New DataTable
                Dim adaptador_folio_debito As New SqlDataAdapter(comando_folio_debito)
                adaptador_folio_debito.Fill(dt_folio_debito)

                Dim subtotal_debito_e As Double = 0, isv_debito_e As Double = 0, total_debito_e As Double = 0, descuento_debito_e As Double = 0
                For index As Integer = 0 To dt_p.Rows.Count - 1
                    If dt_p.Rows(index)(14) = "D" Then
                        Dim query_debito_p As New StringBuilder
                        query_debito_p.Append("INSERT INTO [tactical_discount_sragro].[dbo].[nd_ajuste_p] ")
                        query_debito_p.Append("([ID_AJUSTE],[NUM_PART],[CVE_ART],[DESCRIPCION],[MOTIVO],[CANTIDAD], ")
                        query_debito_p.Append("[FECHA_INGRESO],[COSTO_ANTERIOR],[COSTO_ACTUAL],[AJUSTE],[UNI]) ")
                        query_debito_p.Append("VALUES ")
                        query_debito_p.Append("(@ID_AJUSTE,@NUM_PART,@CVE_ART,@DESCRIPCION,@MOTIVO,@CANTIDAD, ")
                        query_debito_p.Append("@FECHA_INGRESO,@COSTO_ANTERIOR,@COSTO_ACTUAL,@AJUSTE,@UNI)")
                        Dim comando_debito_p As New SqlCommand(query_debito_p.ToString, sql_con)
                        comando_debito_p.Parameters.AddWithValue("@ID_AJUSTE", dt_folio_debito.Rows(0)(0))
                        comando_debito_p.Parameters.AddWithValue("@NUM_PART", index + 1)
                        comando_debito_p.Parameters.AddWithValue("@CVE_ART", dt_p.Rows(index)(1))
                        comando_debito_p.Parameters.AddWithValue("@DESCRIPCION", dt_p.Rows(index)(2))
                        comando_debito_p.Parameters.AddWithValue("@MOTIVO", "AJUSTE DE PRECIO")
                        comando_debito_p.Parameters.AddWithValue("@CANTIDAD", dt_p.Rows(index)(4))
                        comando_debito_p.Parameters.AddWithValue("@FECHA_INGRESO", Convert.ToDateTime(dt_e.Rows(0)(5)))
                        comando_debito_p.Parameters.AddWithValue("@COSTO_ANTERIOR", dt_p.Rows(index)(5))
                        comando_debito_p.Parameters.AddWithValue("@COSTO_ACTUAL", dt_p.Rows(index)(6))
                        Dim valor_ajuste As Double = 0
                        valor_ajuste = (Convert.ToDouble(dt_p.Rows(index)(4)) * Convert.ToDouble(dt_p.Rows(index)(6))) - (Convert.ToDouble(dt_p.Rows(index)(4)) * Convert.ToDouble(dt_p.Rows(index)(5)))
                        If dt_p.Rows(index)(0) = "cj" Then
                            valor_ajuste = valor_ajuste * Convert.ToDouble(dt_p.Rows(index)(3))
                        End If
                        comando_debito_p.Parameters.AddWithValue("@AJUSTE", Math.Abs(valor_ajuste))
                        comando_debito_p.Parameters.AddWithValue("@UNI", dt_p.Rows(index)(0))

                        subtotal_debito_e += valor_ajuste
                        descuento_debito_e += 0 'valor_ajuste * dt_p.Rows(index)(7) / 100
                        valor_ajuste = valor_ajuste - descuento_debito_e
                        isv_debito_e += valor_ajuste * dt_p.Rows(index)(8) / 100
                        comando_debito_p.Transaction = mi_transaccion
                        comando_debito_p.ExecuteNonQuery()
                    End If
                Next
                total_debito_e += subtotal_debito_e - descuento_debito_e + isv_debito_e

                Dim query_debito_e As New StringBuilder
                query_debito_e.Append("INSERT INTO [tactical_discount_sragro].[dbo].[nd_ajuste_e] ")
                query_debito_e.Append("([ID_AJUSTE],[CVE_PROVEEDOR],[ALMACEN],[REF_PROV]")
                query_debito_e.Append(",[FECHA],[N_FACTURA],[SUBTOTAL],[DESCUENTO],[ISV],[TOTAL],[COMPRA],[TIPO]) ")
                query_debito_e.Append("VALUES ")
                query_debito_e.Append("(@ID_AJUSTE,@CVE_PROVEEDOR,@ALMACEN,@REF_PROV,@FECHA, ")
                query_debito_e.Append("@N_FACTURA,@SUBTOTAL,@DESCUENTO,@ISV,@TOTAL,@COMPRA,@TIPO)")
                Dim comando_debito_e As New SqlCommand(query_debito_e.ToString, sql_con)
                comando_debito_e.Parameters.AddWithValue("@ID_AJUSTE", dt_folio_debito.Rows(0)(0))
                comando_debito_e.Parameters.AddWithValue("@CVE_PROVEEDOR", dt_e.Rows(0)(0))
                comando_debito_e.Parameters.AddWithValue("@ALMACEN", dt_e.Rows(0)(2))
                comando_debito_e.Parameters.AddWithValue("@REF_PROV", dt_e.Rows(0)(3))
                comando_debito_e.Parameters.AddWithValue("@FECHA", Convert.ToDateTime(dt_e.Rows(0)(5)))
                comando_debito_e.Parameters.AddWithValue("@N_FACTURA", CVE_DOC)
                comando_debito_e.Parameters.AddWithValue("@SUBTOTAL", Math.Abs(subtotal_debito_e))
                comando_debito_e.Parameters.AddWithValue("@DESCUENTO", 0) 'Math.Abs(descuento_debito_e))
                comando_debito_e.Parameters.AddWithValue("@ISV", Math.Abs(isv_debito_e))
                comando_debito_e.Parameters.AddWithValue("@TOTAL", Math.Abs(total_debito_e))
                comando_debito_e.Parameters.AddWithValue("@COMPRA", CVE_COMPRA)
                comando_debito_e.Parameters.AddWithValue("@TIPO", "CREDITO")
                comando_debito_e.Transaction = mi_transaccion
                comando_debito_e.ExecuteNonQuery()

                Dim query_upd_folio_ajuste As New StringBuilder
                query_upd_folio_ajuste.Append("UPDATE [tactical_discount_sragro].[dbo].[nd_folios] ")
                query_upd_folio_ajuste.Append("   SET [ULT_DOC] = ULT_DOC+1 ")
                query_upd_folio_ajuste.Append("WHERE [NUM_ALMA] = @NUM_ALMA AND TIPO = 'D' ")
                Dim comando_upd_folio_ajuste As New SqlCommand(query_upd_folio_ajuste.ToString, sql_con)
                comando_upd_folio_ajuste.Parameters.AddWithValue("@NUM_ALMA", dt_e.Rows(0)(2))
                comando_upd_folio_ajuste.Transaction = mi_transaccion
                comando_upd_folio_ajuste.ExecuteNonQuery()

                Dim query_opaga As New StringBuilder
                query_opaga.Append("INSERT INTO [SAE60Empre02].[dbo].[OPAGA02] ")
                query_opaga.Append("([CVE_OBS],[STR_OBS]) ")
                query_opaga.Append("VALUES ((SELECT ULT_CVE + 1 AS ULT_CVE FROM SAE60EMPRE02.dbo.TBLCONTROL02 WHERE (ID_TABLA = 21)),'NOTA DE CREDITO POR PRECIO MENOR DEL PROVEEDOR')")
                Dim comando_opaga As New SqlCommand(query_opaga.ToString, sql_con)
                comando_opaga.Transaction = mi_transaccion
                comando_opaga.ExecuteNonQuery()

                Dim query_paga_det As New StringBuilder
                query_paga_det.Append("INSERT INTO [SAE60Empre02].[dbo].[PAGA_DET02] ")
                query_paga_det.Append("([CVE_PROV],[REFER],[NUM_CPTO],[NUM_CARGO],[ID_MOV] ")
                query_paga_det.Append(",[CVE_OBS],[NO_FACTURA],[DOCTO],[IMPORTE],[FECHA_APLI],[FECHA_VENC] ")
                query_paga_det.Append(",[NUM_MONED],[TCAMBIO],[IMPMON_EXT],[FECHAELAB] ")
                query_paga_det.Append(",[TIPO_MOV],[SIGNO],[USUARIO] ")
                query_paga_det.Append(",[NO_PARTIDA]) ")
                query_paga_det.Append("VALUES ")
                query_paga_det.Append("(@CVE_PROV, @REFER, 29,1,1, (SELECT ULT_CVE + 1 AS ULT_CVE FROM SAE60EMPRE02.dbo.TBLCONTROL02 WHERE (ID_TABLA = 21)), ")
                query_paga_det.Append("@NO_FACTURA, @DOCTO, @IMPORTE, @FECHA_APLI, @FECHA_VENC, 1, ")
                query_paga_det.Append("1, @IMPMON_EXT, @FECHAELAB,'A', -1,0, 1) ")
                Dim comando_paga_det As New SqlCommand(query_paga_det.ToString, sql_con)
                comando_paga_det.Parameters.AddWithValue("@CVE_PROV", dt_e.Rows(0)(0))
                comando_paga_det.Parameters.AddWithValue("@REFER", CVE_DOC)
                comando_paga_det.Parameters.AddWithValue("@NO_FACTURA", CVE_DOC)
                comando_paga_det.Parameters.AddWithValue("@DOCTO", CVE_DOC)
                comando_paga_det.Parameters.AddWithValue("@IMPORTE", Math.Abs(total_debito_e))
                comando_paga_det.Parameters.AddWithValue("@FECHA_APLI", Convert.ToDateTime(dt_e.Rows(0)(5)))
                comando_paga_det.Parameters.AddWithValue("@FECHA_VENC", Convert.ToDateTime(dt_e.Rows(0)(5)).AddDays(dias_cred))
                comando_paga_det.Parameters.AddWithValue("@IMPMON_EXT", Math.Abs(total_debito_e))
                comando_paga_det.Parameters.AddWithValue("@FECHAELAB", Convert.ToDateTime(dt_e.Rows(0)(5)))
                comando_paga_det.Transaction = mi_transaccion
                comando_paga_det.ExecuteNonQuery()

                Dim query_upd_paga_det As New StringBuilder
                query_upd_paga_det.Append("UPDATE [SAE60Empre02].[dbo].[TBLCONTROL02] ")
                query_upd_paga_det.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                query_upd_paga_det.Append("WHERE ([ID_TABLA] = 21)")
                Dim comando_upd_paga_det As New SqlCommand(query_upd_paga_det.ToString, sql_con)
                comando_upd_paga_det.Transaction = mi_transaccion
                comando_upd_paga_det.ExecuteNonQuery()
            End If
            ' fin registra los creditos por producto

            'registrar envio a SAE

            Dim query_compc As New StringBuilder
            query_compc.Append("INSERT INTO [SAE60Empre02].[dbo].[COMPC02] ")
            query_compc.Append("([TIP_DOC],[CVE_DOC],[CVE_CLPV],[STATUS],[SU_REFER] ")
            query_compc.Append(",[FECHA_DOC],[FECHA_REC],[FECHA_PAG] ")
            query_compc.Append(",[CAN_TOT],[IMP_TOT1],[IMP_TOT2],[IMP_TOT3],[IMP_TOT4] ")
            query_compc.Append(",[DES_TOT],[DES_FIN],[TOT_IND],[OBS_COND],[CVE_OBS] ")
            query_compc.Append(",[NUM_ALMA],[ACT_CXP],[ACT_COI],[ENLAZADO],[TIP_DOC_E] ")
            query_compc.Append(",[NUM_MONED],[TIPCAMB],[NUM_PAGOS],[FECHAELAB] ")
            query_compc.Append(",[SERIE],[FOLIO],[CTLPOL],[ESCFD],[CONTADO],[BLOQ] ")
            query_compc.Append(",[DES_FIN_PORC],[DES_TOT_PORC],[IMPORTE],[TIP_DOC_ANT],[DOC_ANT]) ")
            query_compc.Append("VALUES ")
            query_compc.Append("('c', @CVE_DOC,@CVE_CLPV,'O',@SU_REFER,@FECHA_DOC ")
            query_compc.Append(",@FECHA_REC,@FECHA_PAG,@CAN_TOT,0,0,0,@IMP_TOT4,@DES_TOT,0,0 ")
            query_compc.Append(",'',0,@NUM_ALMA,'S','N','O','O',1,1,1,@FECHAELAB ")
            query_compc.Append(",@SERIE,@FOLIO,0,'N','N','N',0 ,@DES_TOT_PORC,@IMPORTE,'','' )")
            Dim comando_compc As New SqlCommand(query_compc.ToString, sql_con)
            comando_compc.Parameters.AddWithValue("@CVE_DOC", CVE_DOC)
            comando_compc.Parameters.AddWithValue("@CVE_CLPV", dt_e.Rows(0)(0))
            comando_compc.Parameters.AddWithValue("@SU_REFER", dt_e.Rows(0)(3))
            comando_compc.Parameters.AddWithValue("@FECHA_DOC", Convert.ToDateTime(dt_e.Rows(0)(5)))
            comando_compc.Parameters.AddWithValue("@FECHA_REC", Convert.ToDateTime(dt_e.Rows(0)(5)))
            comando_compc.Parameters.AddWithValue("@FECHA_PAG", Convert.ToDateTime(dt_e.Rows(0)(5)).AddDays(dias_cred)) 'Agregar dias de credito
            comando_compc.Parameters.AddWithValue("@CAN_TOT", dt_e.Rows(0)(7))
            comando_compc.Parameters.AddWithValue("@IMP_TOT4", dt_e.Rows(0)(9))
            comando_compc.Parameters.AddWithValue("@DES_TOT", dt_e.Rows(0)(8))
            comando_compc.Parameters.AddWithValue("@NUM_ALMA", dt_e.Rows(0)(2))
            comando_compc.Parameters.AddWithValue("@FECHAELAB", Now.Date)
            comando_compc.Parameters.AddWithValue("@SERIE", serie)
            comando_compc.Parameters.AddWithValue("@FOLIO", folio)
            comando_compc.Parameters.AddWithValue("@DES_TOT_PORC", dt_e.Rows(0)(6))
            comando_compc.Parameters.AddWithValue("@IMPORTE", dt_e.Rows(0)(10))
            comando_compc.Transaction = mi_transaccion
            comando_compc.ExecuteNonQuery()

            Dim query_compc_clib As New StringBuilder
            query_compc_clib.Append("INSERT INTO [SAE60Empre02].[dbo].[COMPC_CLIB02] ")
            query_compc_clib.Append(" ([CLAVE_DOC],[CAMPLIB1]) ")
            query_compc_clib.Append("VALUES (@CLAVE_DOC,@CAMPLIB1)")
            Dim comando_comp_clib As New SqlCommand(query_compc_clib.ToString, sql_con)
            comando_comp_clib.Parameters.AddWithValue("CLAVE_DOC", CVE_DOC)
            comando_comp_clib.Parameters.AddWithValue("@CAMPLIB1", Convert.ToDateTime(dt_e.Rows(0)(18)))
            comando_comp_clib.Transaction = mi_transaccion
            comando_comp_clib.ExecuteNonQuery()
            'inicio del for

            For index As Integer = 0 To dt_p.Rows.Count - 1
                Dim query_correlativo_lote As New StringBuilder
                query_correlativo_lote.Append("SELECT (ULT_CVE + 1) AS ULT_CVE ")
                query_correlativo_lote.Append("FROM SAE60EMPRE02.dbo.TBLCONTROL02 ")
                query_correlativo_lote.Append("WHERE (ID_TABLA = 67) ")
                Dim comando_correlativo_lote As New SqlCommand(query_correlativo_lote.ToString, sql_con)
                comando_correlativo_lote.Transaction = mi_transaccion
                Dim adaptador_correlativo_lote As New SqlDataAdapter(comando_correlativo_lote)
                Dim dt_correlativo_lote As New DataTable
                adaptador_correlativo_lote.Fill(dt_correlativo_lote)
                Dim correlativo_lote As Integer
                correlativo_lote = dt_correlativo_lote.Rows(0)(0)

                Dim query_par_compc As New StringBuilder
                query_par_compc.Append("INSERT INTO [SAE60Empre02].[dbo].[PAR_COMPC02] ")
                query_par_compc.Append("   ([CVE_DOC],[NUM_PAR],[CVE_ART],[CANT],[PXR],[PREC],[COST] ")
                query_par_compc.Append("   ,[IMPU1],[IMPU2],[IMPU3],[IMPU4],[IMP1APLA],[IMP2APLA],[IMP3APLA] ")
                query_par_compc.Append("   ,[IMP4APLA],[TOTIMP1],[TOTIMP2],[TOTIMP3],[TOTIMP4],[DESCU],[ACT_INV] ")
                query_par_compc.Append("   ,[TIP_CAM],[UNI_VENTA],[TIPO_ELEM],[TIPO_PROD],[CVE_OBS],[REG_SERIE] ")
                query_par_compc.Append("   ,[E_LTPD],[FACTCONV],[COST_DEV],[NUM_ALM],[MINDIRECTO],[NUM_MOV],[TOT_PARTIDA]) ")
                query_par_compc.Append("VALUES ")
                query_par_compc.Append("  (@CVE_DOC,@NUM_PAR,@CVE_ART, @CANT, @PXR, ISNULL((SELECT SAE60Empre02.dbo.PRECIO_X_PROD02.PRECIO ")
                query_par_compc.Append("FROM SAE60Empre02.dbo.INVE02 INNER JOIN SAE60Empre02.dbo.PRECIO_X_PROD02 ON ")
                query_par_compc.Append("SAE60Empre02.dbo.INVE02.CVE_ART = SAE60Empre02.dbo.PRECIO_X_PROD02.CVE_ART ")
                query_par_compc.Append("WHERE (SAE60Empre02.dbo.PRECIO_X_PROD02.CVE_PRECIO = 1) AND (SAE60Empre02.dbo.INVE02.CVE_ART = @CVE_ART)),0), @COST, 0, 0, 0, ")
                query_par_compc.Append("   @IMPU4, 0, 0, 0, 0, 0, 0, ")
                query_par_compc.Append("   0, @TOTIMP4, @DESCU, 'S', 1, @UNI_VENTA, 'N', ")
                query_par_compc.Append("   'P', 0,0,@E_LTPD,@FACTCONV, @COST_DEV, @NUM_ALM, ")
                query_par_compc.Append("   0, (SELECT ULT_CVE + 1 FROM SAE60EMPRE02.dbo.TBLCONTROL02 WHERE (ID_TABLA = 44)),@TOT_PARTIDA)")

                Dim comando_par_compc As New SqlCommand(query_par_compc.ToString, sql_con)
                comando_par_compc.Parameters.AddWithValue("@CVE_DOC", CVE_DOC)
                comando_par_compc.Parameters.AddWithValue("@NUM_PAR", index + 1)
                comando_par_compc.Parameters.AddWithValue("@CVE_ART", dt_p.Rows(index)(1))
                comando_par_compc.Parameters.AddWithValue("@CANT", Convert.ToDouble(dt_p.Rows(index)(4)))

                Dim cant_insertar As Double = 0
                Dim factor_conversion As Integer = 0
                Dim costo_insertar As Double = 0
                If dt_p.Rows(index)(0) = "cj" Then
                    cant_insertar = Convert.ToDouble(dt_p.Rows(index)(4)) * dt_p.Rows(index)(3)
                    factor_conversion = dt_p.Rows(index)(3)
                    costo_insertar = dt_p.Rows(index)(20) * dt_p.Rows(index)(3)
                ElseIf dt_p.Rows(index)(0) = "pz" Then
                    cant_insertar = Convert.ToDouble(dt_p.Rows(index)(4))
                    factor_conversion = 1
                    costo_insertar = dt_p.Rows(index)(20)
                End If

                comando_par_compc.Parameters.AddWithValue("@PXR", cant_insertar)
                comando_par_compc.Parameters.AddWithValue("@COST", costo_insertar)
                comando_par_compc.Parameters.AddWithValue("@IMPU4", dt_p.Rows(index)(8))
                comando_par_compc.Parameters.AddWithValue("@TOTIMP4", Convert.ToDouble(dt_p.Rows(index)(11)))
                comando_par_compc.Parameters.AddWithValue("@DESCU", 0) 'dt_p.Rows(index)(7))
                comando_par_compc.Parameters.AddWithValue("@UNI_VENTA", dt_p.Rows(index)(0))

                If dt_p.Rows(index)(22) = "S" Then
                    comando_par_compc.Parameters.AddWithValue("@E_LTPD", correlativo_lote)
                Else
                    comando_par_compc.Parameters.AddWithValue("@E_LTPD", 0)
                End If

                comando_par_compc.Parameters.AddWithValue("@FACTCONV", factor_conversion)
                comando_par_compc.Parameters.AddWithValue("@COST_DEV", dt_p.Rows(index)(20) * dt_p.Rows(index)(3))
                comando_par_compc.Parameters.AddWithValue("@NUM_ALM", dt_e.Rows(0)(2))
                comando_par_compc.Parameters.AddWithValue("@TOT_PARTIDA", (dt_p.Rows(index)(20) * dt_p.Rows(index)(3) * Convert.ToDouble(dt_p.Rows(index)(4))) - Convert.ToDouble(dt_p.Rows(index)(11)))
                comando_par_compc.Transaction = mi_transaccion
                comando_par_compc.ExecuteNonQuery()

                Dim query_par_comp_clib As New StringBuilder
                query_par_comp_clib.Append("INSERT INTO [SAE60Empre02].[dbo].[PAR_COMPC_CLIB02] ")
                query_par_comp_clib.Append("   ([CLAVE_DOC],[NUM_PART]) ")
                query_par_comp_clib.Append("VALUES ")
                query_par_comp_clib.Append("   (@CLAVE_DOC,@NUM_PART) ")
                Dim comando_par_comp_clib As New SqlCommand(query_par_comp_clib.ToString, sql_con)
                comando_par_comp_clib.Parameters.AddWithValue("@CLAVE_DOC", CVE_DOC)
                comando_par_comp_clib.Parameters.AddWithValue("@NUM_PART", index + 1)
                comando_par_comp_clib.Transaction = mi_transaccion
                comando_par_comp_clib.ExecuteNonQuery()

                Dim query_costo_prom As New StringBuilder
                query_costo_prom.Append("SELECT ISNULL(EXIST,0),ISNULL(COSTO_PROM,0) FROM SAE60EMPRE02.dbo.INVE02 WHERE CVE_ART = @CVE_ART")
                Dim comando_costo_prom As New SqlCommand(query_costo_prom.ToString, sql_con)
                comando_costo_prom.Parameters.AddWithValue("@CVE_ART", dt_p.Rows(index)(1))
                comando_costo_prom.Transaction = mi_transaccion
                Dim adaptador_costo As New SqlDataAdapter(comando_costo_prom)
                Dim dt_costo_prom As New DataTable
                adaptador_costo.Fill(dt_costo_prom)
                Dim existencias_viejas As Double = 0, costo_prom_viejo As Double = 0
                existencias_viejas = dt_costo_prom.Rows(0)(0)
                costo_prom_viejo = dt_costo_prom.Rows(0)(1)

                Dim costo_prom_nuevo As Double = 0
                costo_prom_nuevo = ((existencias_viejas * costo_prom_viejo) + (cant_insertar * (dt_p.Rows(index)(20)))) / (existencias_viejas + cant_insertar)


                Dim query_upd_inve As New StringBuilder
                query_upd_inve.Append("UPDATE SAE60EMPRE02.dbo.INVE02 ")
                query_upd_inve.Append("SET [EXIST] = (EXIST + @NUEVA_EXISTENCIA), ")
                query_upd_inve.Append("FCH_ULTCOM = @FECHA_ULTCOM, COSTO_PROM = @COSTO_PROM, ULT_COSTO = @ULT_COSTO ")
                query_upd_inve.Append("WHERE [CVE_ART] = @CVE_ART ")
                Dim comando_upd_inve As New SqlCommand(query_upd_inve.ToString, sql_con)
                comando_upd_inve.Parameters.AddWithValue("@NUEVA_EXISTENCIA", cant_insertar)
                comando_upd_inve.Parameters.AddWithValue("@FECHA_ULTCOM", Now.Date)
                comando_upd_inve.Parameters.AddWithValue("@CVE_ART", dt_p.Rows(index)(1))
                comando_upd_inve.Parameters.AddWithValue("@COSTO_PROM", costo_prom_nuevo)
                comando_upd_inve.Parameters.AddWithValue("@ULT_COSTO", dt_p.Rows(index)(20))
                comando_upd_inve.Transaction = mi_transaccion
                comando_upd_inve.ExecuteNonQuery()

                Dim query_upd_mult As New StringBuilder
                query_upd_mult.Append("UPDATE SAE60EMPRE02.dbo.MULT02 ")
                query_upd_mult.Append("SET [EXIST] = (EXIST + @NUEVA_EXISTENCIA) ")
                query_upd_mult.Append("WHERE  [CVE_ART] = @CVE_ART AND [CVE_ALM] = @CVE_ALM ")
                Dim comando_upd_mult As New SqlCommand(query_upd_mult.ToString, sql_con)
                comando_upd_mult.Parameters.AddWithValue("@NUEVA_EXISTENCIA", cant_insertar)
                comando_upd_mult.Parameters.AddWithValue("@CVE_ART", dt_p.Rows(index)(1))
                comando_upd_mult.Parameters.AddWithValue("@CVE_ALM", dt_e.Rows(0)(2))
                comando_upd_mult.Transaction = mi_transaccion
                comando_upd_mult.ExecuteNonQuery()

                If dt_p.Rows(index)(22) = "S" Then
                    Dim query_reg_lote As New StringBuilder
                    query_reg_lote.Append("SELECT (ULT_CVE + 1) AS ULT_CVE ")
                    query_reg_lote.Append("FROM SAE60EMPRE02.dbo.TBLCONTROL02 ")
                    query_reg_lote.Append("WHERE (ID_TABLA = 48) ")
                    Dim comando_reg_lote As New SqlCommand(query_reg_lote.ToString, sql_con)
                    comando_reg_lote.Transaction = mi_transaccion
                    Dim adaptador_reg_lote As New SqlDataAdapter(comando_reg_lote)
                    Dim dt_reg_lote As New DataTable
                    adaptador_reg_lote.Fill(dt_reg_lote)
                    Dim reg_lote As Integer
                    reg_lote = dt_reg_lote.Rows(0)(0)

                    Dim query_ltpd As New StringBuilder
                    query_ltpd.Append("INSERT INTO [SAE60Empre02].[dbo].[LTPD02] ")
                    query_ltpd.Append("   ([CVE_ART],[LOTE],[PEDIMENTO],[CVE_ALM] ")
                    query_ltpd.Append("   ,[FCHULTMOV],[NOM_ADUAN],[CANTIDAD],[REG_LTPD],[CVE_OBS] ")
                    query_ltpd.Append("   ,[CIUDAD],[FRONTERA],[GLN],[STATUS]) ")
                    query_ltpd.Append("VALUES ")
                    query_ltpd.Append("   (@CVE_ART,@LOTE,'',@CVE_ALM,@FCHULTMOV, ")
                    query_ltpd.Append("'', @CANTIDAD, @REG_LTPD, 0, '', '', '','A')")
                    Dim comando_ltpd As New SqlCommand(query_ltpd.ToString, sql_con)
                    comando_ltpd.Parameters.AddWithValue("@CVE_ART", dt_p.Rows(index)(1))
                    Dim codigo_lote As String = ""

                    If conlote = "S" Then
                        codigo_lote = lote
                    Else
                        codigo_lote = CVE_DOC
                    End If

                    comando_ltpd.Parameters.AddWithValue("@LOTE", codigo_lote)
                    comando_ltpd.Parameters.AddWithValue("@CVE_ALM", dt_e.Rows(0)(2))
                    comando_ltpd.Parameters.AddWithValue("@FCHULTMOV", Now.Date)
                    comando_ltpd.Parameters.AddWithValue("@CANTIDAD", cant_insertar)
                    comando_ltpd.Parameters.AddWithValue("@REG_LTPD", reg_lote)
                    comando_ltpd.Transaction = mi_transaccion
                    comando_ltpd.ExecuteNonQuery()

                    Dim query_enlace_ltpd As New StringBuilder
                    query_enlace_ltpd.Append("INSERT INTO [SAE60Empre02].[dbo].[ENLACE_LTPD02] ")
                    query_enlace_ltpd.Append("   ([E_LTPD],[REG_LTPD],[CANTIDAD],[PXRS]) ")
                    query_enlace_ltpd.Append("VALUES ")
                    query_enlace_ltpd.Append("   (@E_LTPD,@REG_LTPD, @CANTIDAD,@PXRS)")
                    Dim comando_enlace_ltpd As New SqlCommand(query_enlace_ltpd.ToString, sql_con)
                    comando_enlace_ltpd.Parameters.AddWithValue("@E_LTPD", correlativo_lote)
                    comando_enlace_ltpd.Parameters.AddWithValue("@REG_LTPD", reg_lote)
                    comando_enlace_ltpd.Parameters.AddWithValue("@CANTIDAD", cant_insertar)
                    comando_enlace_ltpd.Parameters.AddWithValue("@PXRS", cant_insertar)
                    comando_enlace_ltpd.Transaction = mi_transaccion
                    comando_enlace_ltpd.ExecuteNonQuery()

                    Dim query_upd_correlativo_lote As New StringBuilder
                    query_upd_correlativo_lote.Append("UPDATE [SAE60Empre02].[dbo].[TBLCONTROL02] ")
                    query_upd_correlativo_lote.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                    query_upd_correlativo_lote.Append("WHERE([ID_TABLA] = 67)")
                    Dim comando_upd_correlativo_lote As New SqlCommand(query_upd_correlativo_lote.ToString, sql_con)
                    comando_upd_correlativo_lote.Transaction = mi_transaccion
                    comando_upd_correlativo_lote.ExecuteNonQuery()

                    Dim query_upd_reg_lote As New StringBuilder
                    query_upd_reg_lote.Append("UPDATE [SAE60Empre02].[dbo].[TBLCONTROL02] ")
                    query_upd_reg_lote.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                    query_upd_reg_lote.Append("WHERE([ID_TABLA] = 48)")
                    Dim comando_upd_reg_lote As New SqlCommand(query_upd_reg_lote.ToString, sql_con)
                    comando_upd_reg_lote.Transaction = mi_transaccion
                    comando_upd_reg_lote.ExecuteNonQuery()
                End If


                Dim query_minve As New StringBuilder
                query_minve.Append("INSERT INTO [SAE60Empre02].[dbo].[MINVE02] ")
                query_minve.Append("   ([CVE_ART],[ALMACEN],[NUM_MOV],[CVE_CPTO],[FECHA_DOCU] ")
                query_minve.Append("   ,[TIPO_DOC],[REFER],[CLAVE_CLPV],[VEND],[CANT],[CANT_COST] ")
                query_minve.Append("   ,[PRECIO],[COSTO],[REG_SERIE],[UNI_VENTA] ")
                query_minve.Append("   ,[E_LTPD],[EXIST_G],[EXISTENCIA],[FACTOR_CON] ")
                query_minve.Append("   ,[FECHAELAB],[CVE_FOLIO],[SIGNO],[COSTEADO],[COSTO_PROM_INI] ")
                query_minve.Append("   ,[COSTO_PROM_FIN],[COSTO_PROM_GRAL],[DESDE_INVE],[MOV_ENLAZADO]) ")
                query_minve.Append("VALUES ")
                query_minve.Append("   (@CVE_ART, @ALMACEN,(SELECT ULT_CVE+1 FROM SAE60EMPRE02.dbo.TBLCONTROL02 WHERE (ID_TABLA = 44)),1,@FECHA_DOCU, 'c', @REFER, ")
                query_minve.Append("   @CLAVE_CLPV, '',@CANT, 0, 0, @COSTO,  ")
                query_minve.Append("   0,@UNI_VENTA, @E_LTPD,@CANT+ISNULL((SELECT EXIST FROM SAE60EMPRE02.dbo.INVE02 WHERE (CVE_ART = @CVE_ART)),0), ((SELECT EXIST FROM SAE60EMPRE02.dbo.MULT02 WHERE (CVE_ART = @CVE_ART) AND CVE_ALM = @ALMACEN)), @FACTOR_CON, ")
                query_minve.Append("   @FECHAELAB, (SELECT ULT_CVE+1 FROM SAE60EMPRE02.dbo.TBLCONTROL02 WHERE (ID_TABLA = 32)),'1','S', @COSTO_PROM_INI,@COSTO_PROM_FIN, ")
                query_minve.Append("   @COSTO_PROM_GRAL,'N',0)")
                Dim comando_minve As New SqlCommand(query_minve.ToString, sql_con)
                comando_minve.Parameters.AddWithValue("@CVE_ART", dt_p.Rows(index)(1))
                comando_minve.Parameters.AddWithValue("@ALMACEN", dt_e.Rows(0)(2))
                comando_minve.Parameters.AddWithValue("@FECHA_DOCU", Convert.ToDateTime(dt_e.Rows(0)(5)))
                comando_minve.Parameters.AddWithValue("@REFER", CVE_DOC)
                comando_minve.Parameters.AddWithValue("@CLAVE_CLPV", dt_e.Rows(0)(0))
                comando_minve.Parameters.AddWithValue("@CANT", cant_insertar)
                comando_minve.Parameters.AddWithValue("@COSTO", dt_p.Rows(index)(20))

                comando_minve.Parameters.AddWithValue("@UNI_VENTA", dt_p.Rows(index)(0))
                If dt_p.Rows(index)(22) = "S" Then
                    comando_minve.Parameters.AddWithValue("@E_LTPD", correlativo_lote)
                Else
                    comando_minve.Parameters.AddWithValue("@E_LTPD", 0)
                End If

                comando_minve.Parameters.AddWithValue("@FACTOR_CON", factor_conversion)
                comando_minve.Parameters.AddWithValue("@FECHAELAB", Convert.ToDateTime(dt_e.Rows(0)(5)))
                comando_minve.Parameters.AddWithValue("@COSTO_PROM_INI", costo_prom_viejo)
                comando_minve.Parameters.AddWithValue("@COSTO_PROM_FIN", costo_prom_nuevo)
                comando_minve.Parameters.AddWithValue("@COSTO_PROM_GRAL", costo_prom_nuevo)
                comando_minve.Transaction = mi_transaccion
                comando_minve.ExecuteNonQuery()

                Dim query_num_mov_minve As New StringBuilder
                query_num_mov_minve.Append("UPDATE [SAE60Empre02].[dbo].[TBLCONTROL02] ")
                query_num_mov_minve.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                query_num_mov_minve.Append("WHERE ([ID_TABLA] = 44)")
                Dim comando_num_mov_minve As New SqlCommand(query_num_mov_minve.ToString, sql_con)
                comando_num_mov_minve.Transaction = mi_transaccion
                comando_num_mov_minve.ExecuteNonQuery()

                Dim query_upd_folio_minve As New StringBuilder
                query_upd_folio_minve.Append("UPDATE SAE60EMPRE02.dbo.TBLCONTROL02 ")
                query_upd_folio_minve.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                query_upd_folio_minve.Append("WHERE (ID_TABLA = 32) ")
                Dim comando_upd_folio_minve As New SqlCommand(query_upd_folio_minve.ToString, sql_con)
                comando_upd_folio_minve.Transaction = mi_transaccion
                comando_upd_folio_minve.ExecuteNonQuery()
            Next

            'fin del for

            Dim query_paga_m As New StringBuilder
            query_paga_m.Append("INSERT INTO [SAE60Empre02].[dbo].[PAGA_M02] ")
            query_paga_m.Append("   ([CVE_PROV],[REFER],[NUM_CARGO],[NUM_CPTO],[CVE_OBS] ")
            query_paga_m.Append("   ,[NO_FACTURA],[DOCTO],[IMPORTE],[FECHA_APLI],[FECHA_VENC],[AFEC_COI] ")
            query_paga_m.Append("   ,[NUM_MONED],[TCAMBIO],[IMPMON_EXT],[FECHAELAB],[TIPO_MOV] ")
            query_paga_m.Append("   ,[SIGNO],[USUARIO],[STATUS]) ")
            query_paga_m.Append("VALUES ")
            query_paga_m.Append("   (@CVE_PROV, @REFER, 1, 1, 0, @NO_FACTURA, ")
            query_paga_m.Append("   @DOCTO,@IMPORTE,@FECHA_APLI, @FECHA_VENC, 'A',1, 1, ")
            query_paga_m.Append("   @IMPMON_EXT,@FECHAELAB, 'C', 1, ")
            query_paga_m.Append("   @USUARIO, 'A')")
            Dim comando_paga_m As New SqlCommand(query_paga_m.ToString, sql_con)
            comando_paga_m.Parameters.AddWithValue("@CVE_PROV", dt_e.Rows(0)(0))
            comando_paga_m.Parameters.AddWithValue("@REFER", CVE_DOC)
            comando_paga_m.Parameters.AddWithValue("@DOCTO", CVE_DOC)
            comando_paga_m.Parameters.AddWithValue("@NO_FACTURA", dt_e.Rows(0)(3))
            comando_paga_m.Parameters.AddWithValue("@IMPORTE", dt_e.Rows(0)(10))
            comando_paga_m.Parameters.AddWithValue("@FECHA_APLI", Convert.ToDateTime(dt_e.Rows(0)(5)))
            comando_paga_m.Parameters.AddWithValue("@FECHA_VENC", Convert.ToDateTime(dt_e.Rows(0)(5)).AddDays(dias_cred))
            comando_paga_m.Parameters.AddWithValue("@IMPMON_EXT", dt_e.Rows(0)(10))
            comando_paga_m.Parameters.AddWithValue("@FECHAELAB", Convert.ToDateTime(dt_e.Rows(0)(5)))
            comando_paga_m.Parameters.AddWithValue("@USUARIO", 0)
            comando_paga_m.Transaction = mi_transaccion
            comando_paga_m.ExecuteNonQuery()

            Dim query_upd_prov As New StringBuilder
            query_upd_prov.Append("UPDATE [SAE60Empre02].[dbo].[PROV02] ")
            query_upd_prov.Append("SET [ULT_COMPD] = @ULT_COMPD ")
            query_upd_prov.Append(",[ULT_COMPM] =@ULT_COMPM ")
            query_upd_prov.Append(",[ULT_COMPF] =@ULT_COMPF ")
            query_upd_prov.Append(",[SALDO] = SALDO + @SALDO ")
            query_upd_prov.Append("WHERE([CLAVE] = @CLAVE)")
            Dim comando_upd_prov As New SqlCommand(query_upd_prov.ToString, sql_con)
            comando_upd_prov.Parameters.AddWithValue("@ULT_COMPD", CVE_DOC)
            comando_upd_prov.Parameters.AddWithValue("@ULT_COMPM", dt_e.Rows(0)(10))
            comando_upd_prov.Parameters.AddWithValue("@ULT_COMPF", Convert.ToDateTime(dt_e.Rows(0)(5)))
            comando_upd_prov.Parameters.AddWithValue("@SALDO", dt_e.Rows(0)(10))
            comando_upd_prov.Parameters.AddWithValue("@CLAVE", dt_e.Rows(0)(0))
            comando_upd_prov.Transaction = mi_transaccion
            comando_upd_prov.ExecuteNonQuery()

            Dim query_cve_docto_upd As New StringBuilder
            query_cve_docto_upd.Append("UPDATE [SAE60Empre02].[dbo].[FOLIOSC02] ")
            query_cve_docto_upd.Append("SET [ULT_DOC] = ULT_DOC + 1 , ")
            query_cve_docto_upd.Append("[FECH_ULT_DOC] = @FECH_ULT_DOC ")
            query_cve_docto_upd.Append("WHERE (TIP_DOC = 'c') AND (SERIE = @SERIE)")
            Dim comando_cve_docto_upd As New SqlCommand(query_cve_docto_upd.ToString, sql_con)
            comando_cve_docto_upd.Parameters.AddWithValue("@FECH_ULT_DOC", Convert.ToDateTime(dt_e.Rows(0)(5)))
            comando_cve_docto_upd.Parameters.AddWithValue("@SERIE", serie)
            comando_cve_docto_upd.Transaction = mi_transaccion
            comando_cve_docto_upd.ExecuteNonQuery()

            Dim conexion_bita As New cls_bitacora_reporteador
            conexion_bita.RegistraBitacora(Now, usuario, "Ingreso de compra Cargill", "COMPRAS", _
                                      "Fecha: " + Convert.ToDateTime(dt_e.Rows(0)(5)) + " Numero de Compra SAE: " + CVE_DOC + _
                                      " Numero de Compra Rep:" + CVE_COMPRA + " almacen:" + dt_e.Rows(0)(2))

            mi_transaccion.Commit()
            sql_con.Close()
            Return "correcto"
        Catch ex As Exception
            mi_transaccion.Rollback()
            sql_con.Close()
            Dim tamaño As Integer = Convert.ToString(ex.StackTrace).Length
            Dim posicion As Integer = InStrRev(Convert.ToString(ex.StackTrace), "línea") - 1
            Dim inicial As Integer = tamaño - posicion
            Dim linea_error As String = Convert.ToString(ex.StackTrace).Substring(tamaño - inicial, inicial)
            Return (ex.Message + " --> " + linea_error)
        End Try
    End Function

    Public Function guardar_compras_local_CARGILL(ByVal dt_e As DataTable, ByVal dt_p As DataTable) As String
        Dim sql_con As New SqlConnection(conexion.CadenaSQL)
        Dim mi_transaccion As SqlTransaction
        sql_con.Open()
        mi_transaccion = sql_con.BeginTransaction

        Try
            Dim query_codigo As New StringBuilder
            query_codigo.Append("SELECT FOLIO + CONVERT(VARCHAR, ULT_DOC + 1) AS CLAVE ")
            query_codigo.Append("FROM nd_folios ")
            query_codigo.Append("WHERE (NUM_ALMA = @ALMACEN) AND (TIPO = 'C')")
            Dim comando_codigo As New SqlCommand(query_codigo.ToString, sql_con)
            comando_codigo.Parameters.AddWithValue("@ALMACEN", dt_e.Rows(0)(2))
            comando_codigo.Transaction = mi_transaccion
            Dim dt As New DataTable
            Dim adaptador_codigo As New SqlDataAdapter(comando_codigo)
            adaptador_codigo.Fill(dt)
            Dim CVE_COMPRA As String = ""
            CVE_COMPRA = dt.Rows(0)(0)

            Dim query_e_local As New StringBuilder
            query_e_local.Append("INSERT INTO [tactical_discount_sragro].[dbo].[nd_compras_e] ")
            query_e_local.Append("       ([CVE_COMPRA],[CVE_PROVEEDOR],[PROVEEDOR],[ALMACEN],[REF_PROV],[RFC],[FECHA],[DESCUENTO_POR],[SUB_TOTAL] ")
            query_e_local.Append("       ,[DESCUENTO_VAL],[ISV_VAL],[TOTAL],[ESTADO],[SUBTOTAL_MOST],[DESC_MOST],[ISV_MOST],[TOTAL_MOST] ")
            query_e_local.Append("       ,[FLETE], [NUMERO_FLETE],[FECHA_FACTURA],[ISV_FLETE],[TOT_FLETE]) ")
            query_e_local.Append(" VALUES ")
            query_e_local.Append("       (@CVE_COMPRA,@CVE_PROVEEDOR,@PROVEEDOR,@ALMACEN,@REF_PROV,@RFC,@FECHA,@DESCUENTO_POR,@SUB_TOTAL ")
            query_e_local.Append("       ,@DESCUENTO_VAL,@ISV_VAL,@TOTAL,@ESTADO,@SUBTOTAL_MOST,@DESC_MOST,@ISV_MOST,@TOTAL_MOST ")
            query_e_local.Append("       ,@FLETE, @NUMERO_FLETE,@FECHA_FACTURA,@ISV_FLETE,@TOT_FLETE)")
            Dim comando_e_local As New SqlCommand(query_e_local.ToString, sql_con)
            comando_e_local.Parameters.AddWithValue("@CVE_COMPRA", CVE_COMPRA)
            comando_e_local.Parameters.AddWithValue("@CVE_PROVEEDOR", dt_e.Rows(0)(0))
            comando_e_local.Parameters.AddWithValue("@PROVEEDOR", dt_e.Rows(0)(1))
            comando_e_local.Parameters.AddWithValue("@ALMACEN ", dt_e.Rows(0)(2))
            comando_e_local.Parameters.AddWithValue("@REF_PROV", dt_e.Rows(0)(3))
            comando_e_local.Parameters.AddWithValue("@RFC", dt_e.Rows(0)(4))
            comando_e_local.Parameters.AddWithValue("@FECHA", Convert.ToDateTime(dt_e.Rows(0)(5)))
            comando_e_local.Parameters.AddWithValue("@DESCUENTO_POR", dt_e.Rows(0)(6))
            comando_e_local.Parameters.AddWithValue("@SUB_TOTAL", dt_e.Rows(0)(7))
            comando_e_local.Parameters.AddWithValue("@DESCUENTO_VAL", dt_e.Rows(0)(8))
            comando_e_local.Parameters.AddWithValue("@ISV_VAL", dt_e.Rows(0)(9))
            comando_e_local.Parameters.AddWithValue("@TOTAL", dt_e.Rows(0)(10))
            comando_e_local.Parameters.AddWithValue("@ESTADO", dt_e.Rows(0)(11))
            comando_e_local.Parameters.AddWithValue("@SUBTOTAL_MOST", dt_e.Rows(0)(12))
            comando_e_local.Parameters.AddWithValue("@DESC_MOST", dt_e.Rows(0)(13))
            comando_e_local.Parameters.AddWithValue("@ISV_MOST", dt_e.Rows(0)(14))
            comando_e_local.Parameters.AddWithValue("@TOTAL_MOST", dt_e.Rows(0)(15))
            comando_e_local.Parameters.AddWithValue("@FLETE", dt_e.Rows(0)(16))
            comando_e_local.Parameters.AddWithValue("@NUMERO_FLETE", dt_e.Rows(0)(17))
            comando_e_local.Parameters.AddWithValue("@FECHA_FACTURA", Convert.ToDateTime(dt_e.Rows(0)(18)))

            comando_e_local.Parameters.AddWithValue("@ISV_FLETE", dt_e.Rows(0)(19))
            comando_e_local.Parameters.AddWithValue("@TOT_FLETE", dt_e.Rows(0)(20))

            comando_e_local.Transaction = mi_transaccion
            comando_e_local.ExecuteNonQuery()

            For index As Integer = 0 To dt_p.Rows.Count - 1
                Dim query_p_local As New StringBuilder
                query_p_local.Append("INSERT INTO [tactical_discount_sragro].[dbo].[nd_compras_p] ")
                query_p_local.Append("([CVE_COMPRA],[NUM_PART],[UNI],[CVE_ART],[PRODUCTO] ")
                query_p_local.Append(",[FACT_CONV],[CANTIDAD],[PRECIO_NEG],[PRECIO_FINAL] ")
                query_p_local.Append(",[DESC_PROD],[ISV_PROD],[SUB_TOTAL],[DESCUENTO] ")
                query_p_local.Append(",[ISV],[TOTAL_PARTIDA],[PRECIO_INSERTAR],[AJUSTE],  ")
                query_p_local.Append("[SUBTOTAL_MOST],[DESC_MOST],[ISV_MOST],[TOTAL_MOST],[PRECIO_NETO],[PESO],[CON_LOTE], [PORC_PP], [DESCUENTO_PP], [DESCUENTO_PP_MOSTR]) ")
                query_p_local.Append("VALUES ")
                query_p_local.Append("(@CVE_COMPRA,@NUM_PART,@UNI,@CVE_ART,@PRODUCTO, ")
                query_p_local.Append("@FACT_CONV,@CANTIDAD,@PRECIO_NEG,@PRECIO_FINAL, ")
                query_p_local.Append("@DESC_PROD,@ISV_PROD,@SUB_TOTAL,@DESCUENTO, ")
                query_p_local.Append("@ISV,@TOTAL_PARTIDA,@PRECIO_INSERTAR,@AJUSTE, ")
                query_p_local.Append(" @SUBTOTAL_MOST, @DESC_MOST,@ISV_MOST,@TOTAL_MOST,@PRECIO_NETO,@PESO,@CON_LOTE, @PORC_PP, @DESCUENTO_PP, @DESCUENTO_PP_MOSTR) ")
                Dim comando_p_local As New SqlCommand(query_p_local.ToString, sql_con)

                comando_p_local.Parameters.AddWithValue("@CVE_COMPRA", CVE_COMPRA)
                comando_p_local.Parameters.AddWithValue("@NUM_PART", index + 1)
                comando_p_local.Parameters.AddWithValue("@UNI", dt_p.Rows(index)(0))
                comando_p_local.Parameters.AddWithValue("@CVE_ART", dt_p.Rows(index)(1))
                comando_p_local.Parameters.AddWithValue("@PRODUCTO", dt_p.Rows(index)(2))
                comando_p_local.Parameters.AddWithValue("@FACT_CONV", dt_p.Rows(index)(3))
                comando_p_local.Parameters.AddWithValue("@CANTIDAD", Convert.ToDouble(dt_p.Rows(index)(4)))
                comando_p_local.Parameters.AddWithValue("@PRECIO_NEG", dt_p.Rows(index)(5))
                comando_p_local.Parameters.AddWithValue("@PRECIO_FINAL", dt_p.Rows(index)(6))
                comando_p_local.Parameters.AddWithValue("@DESC_PROD", dt_p.Rows(index)(7))
                comando_p_local.Parameters.AddWithValue("@ISV_PROD", dt_p.Rows(index)(8))
                comando_p_local.Parameters.AddWithValue("@SUB_TOTAL", Convert.ToDouble(dt_p.Rows(index)(9)))
                comando_p_local.Parameters.AddWithValue("@DESCUENTO", Convert.ToDouble(dt_p.Rows(index)(10)))
                comando_p_local.Parameters.AddWithValue("@ISV", Convert.ToDouble(dt_p.Rows(index)(11)))
                comando_p_local.Parameters.AddWithValue("@TOTAL_PARTIDA", Convert.ToDouble(dt_p.Rows(index)(12)))
                comando_p_local.Parameters.AddWithValue("@PRECIO_INSERTAR", dt_p.Rows(index)(13))
                comando_p_local.Parameters.AddWithValue("@AJUSTE", dt_p.Rows(index)(14))

                comando_p_local.Parameters.AddWithValue("@SUBTOTAL_MOST", dt_p.Rows(index)(16))
                comando_p_local.Parameters.AddWithValue("@DESC_MOST", dt_p.Rows(index)(17))
                comando_p_local.Parameters.AddWithValue("@ISV_MOST", dt_p.Rows(index)(18))
                comando_p_local.Parameters.AddWithValue("@TOTAL_MOST", dt_p.Rows(index)(19))
                comando_p_local.Parameters.AddWithValue("@PRECIO_NETO", dt_p.Rows(index)(20))
                comando_p_local.Parameters.AddWithValue("@PESO", dt_p.Rows(index)(21))
                comando_p_local.Parameters.AddWithValue("@CON_LOTE", dt_p.Rows(index)(22))

                comando_p_local.Parameters.AddWithValue("@PORC_PP", dt_p.Rows(index)(23))
                comando_p_local.Parameters.AddWithValue("@DESCUENTO_PP", dt_p.Rows(index)(24))
                comando_p_local.Parameters.AddWithValue("@DESCUENTO_PP_MOSTR", dt_p.Rows(index)(25))

                comando_p_local.Transaction = mi_transaccion
                comando_p_local.ExecuteNonQuery()
            Next

            Dim query_upd_codigo As New StringBuilder
            query_upd_codigo.Append("UPDATE [tactical_discount_sragro].[dbo].[nd_folios] ")
            query_upd_codigo.Append("SET [ULT_DOC] = ULT_DOC + 1 ")
            query_upd_codigo.Append("WHERE ([NUM_ALMA] = @NUM_ALMA And [TIPO] = 'C') ")
            Dim comando_upd_codigo As New SqlCommand(query_upd_codigo.ToString, sql_con)
            comando_upd_codigo.Parameters.AddWithValue("@NUM_ALMA", dt_e.Rows(0)(2))
            comando_upd_codigo.Transaction = mi_transaccion
            comando_upd_codigo.ExecuteNonQuery()
            'fin de las compras locales
            mi_transaccion.Commit()
            sql_con.Close()
            Return "correcto"
        Catch ex As Exception
            mi_transaccion.Rollback()
            sql_con.Close()
            Dim tamaño As Integer = Convert.ToString(ex.StackTrace).Length
            Dim posicion As Integer = InStrRev(Convert.ToString(ex.StackTrace), "línea") - 1
            Dim inicial As Integer = tamaño - posicion
            Dim linea_error As String = Convert.ToString(ex.StackTrace).Substring(tamaño - inicial, inicial)
            Return (ex.Message + " --> " + linea_error)
        End Try
    End Function

    Public Function envio_individual_compras_SAE_CARGILL(ByVal dt_e As DataTable, ByVal dt_p As DataTable, ByVal CVE_COMPRA As String, _
                                                         ByVal conlote As String, ByVal lote As String, ByVal usuario As String) As String
        Dim sql_con As New SqlConnection(conexion.CadenaSQL)
        Dim mi_transaccion As SqlTransaction
        sql_con.Open()
        mi_transaccion = sql_con.BeginTransaction

        Try
            Dim query_codigo As New StringBuilder
            query_codigo.Append("SELECT FOLIO + CONVERT(VARCHAR, ULT_DOC + 1) AS CLAVE,FOLIO ")
            query_codigo.Append("FROM nd_folios ")
            query_codigo.Append("WHERE (NUM_ALMA = @ALMACEN) AND (TIPO = 'C')")
            Dim comando_codigo As New SqlCommand(query_codigo.ToString, sql_con)
            comando_codigo.Parameters.AddWithValue("@ALMACEN", dt_e.Rows(0)(2))
            comando_codigo.Transaction = mi_transaccion
            Dim dt As New DataTable
            Dim adaptador_codigo As New SqlDataAdapter(comando_codigo)
            adaptador_codigo.Fill(dt)
            Dim serie_local As String = ""
            serie_local = dt.Rows(0)(1)

            Dim query_cve_docto As New StringBuilder
            query_cve_docto.Append("SELECT SERIE, ULT_DOC ")
            query_cve_docto.Append("FROM SAE60EMPRE02.dbo.FOLIOSC02 ")
            query_cve_docto.Append("WHERE (TIP_DOC = 'c') AND (SERIE = @SERIE) ")
            Dim comando_cve_docto As New SqlCommand(query_cve_docto.ToString, sql_con)
            comando_cve_docto.Parameters.AddWithValue("@SERIE", serie_local)
            comando_cve_docto.Transaction = mi_transaccion
            Dim adaptador_cve_docto As New SqlDataAdapter(comando_cve_docto)
            Dim dt_cve_docto As New DataTable
            adaptador_cve_docto.Fill(dt_cve_docto)
            Dim CVE_DOC As String = ""
            Dim serie As String = ""
            Dim folio As Integer
            serie = dt_cve_docto.Rows(0)(0)
            folio = dt_cve_docto.Rows(0)(1) + 1
            CVE_DOC = serie & folio

            'CAMBIAR ESTADO DE COMPRA LOCAL
            Dim query_compra_local As New StringBuilder
            query_compra_local.Append("UPDATE [tactical_discount_sragro].[dbo].[nd_compras_e]")
            query_compra_local.Append("   SET [ESTADO] = 'ENVIADA',[N_FACTURA_SAE] = @N_FACTURA_SAE, [FECHA_FACTURA] = @FECHA_FACTURA ")
            query_compra_local.Append("      ,[ISV_FLETE] = @ISV_FLETE,[TOT_FLETE] = @TOT_FLETE ")
            query_compra_local.Append(" WHERE [CVE_COMPRA] = @CVE_COMPRA")
            Dim comando_local As New SqlCommand(query_compra_local.ToString, sql_con)
            comando_local.Parameters.AddWithValue("@N_FACTURA_SAE", CVE_DOC)
            comando_local.Parameters.AddWithValue("@CVE_COMPRA", CVE_COMPRA)
            comando_local.Parameters.AddWithValue("@FECHA_FACTURA", Convert.ToDateTime(dt_e.Rows(0)(18)))

            comando_local.Parameters.AddWithValue("@ISV_FLETE", dt_e.Rows(0)(19))
            comando_local.Parameters.AddWithValue("@TOT_FLETE", dt_e.Rows(0)(20))

            comando_local.Transaction = mi_transaccion
            comando_local.ExecuteNonQuery()
            'fin de las compras locales

            Dim ajuste As String = ""
            Dim debito As String = ""
            For index As Integer = 0 To dt_p.Rows.Count - 1
                If dt_p.Rows(index)(14) = "S" Then
                    ajuste = "S"
                End If

                If dt_p.Rows(index)(14) = "D" Then
                    debito = "D"
                End If
            Next

            ' registra los debito por producto
            If ajuste = "S" Then
                Dim query_folio_ajuste As New StringBuilder
                query_folio_ajuste.Append("SELECT FOLIO + CONVERT(VARCHAR, ULT_DOC + 1) AS ULT_DOC ")
                query_folio_ajuste.Append("FROM nd_folios ")
                query_folio_ajuste.Append("WHERE (TIPO = 'A') AND (NUM_ALMA = @ALMACEN)")
                Dim comando_folio_ajuste As New SqlCommand(query_folio_ajuste.ToString, sql_con)
                comando_folio_ajuste.Parameters.AddWithValue("@ALMACEN", dt_e.Rows(0)(2))
                comando_folio_ajuste.Transaction = mi_transaccion
                Dim dt_folio_ajuste As New DataTable
                Dim adaptador_folio_ajuste As New SqlDataAdapter(comando_folio_ajuste)
                adaptador_folio_ajuste.Fill(dt_folio_ajuste)

                Dim subtotal_ajuste_e As Double = 0, isv_ajuste_e As Double = 0, total_ajueste_e As Double = 0, descuento_ajuste_e As Double = 0
                For index As Integer = 0 To dt_p.Rows.Count - 1
                    If dt_p.Rows(index)(14) = "S" Then
                        Dim query_ajuste_p As New StringBuilder
                        query_ajuste_p.Append("INSERT INTO [tactical_discount_sragro].[dbo].[nd_ajuste_p] ")
                        query_ajuste_p.Append("([ID_AJUSTE],[NUM_PART],[CVE_ART],[DESCRIPCION],[MOTIVO],[CANTIDAD], ")
                        query_ajuste_p.Append("[FECHA_INGRESO],[COSTO_ANTERIOR],[COSTO_ACTUAL],[AJUSTE],[UNI]) ")
                        query_ajuste_p.Append("VALUES ")
                        query_ajuste_p.Append("(@ID_AJUSTE,@NUM_PART,@CVE_ART,@DESCRIPCION,@MOTIVO,@CANTIDAD, ")
                        query_ajuste_p.Append("@FECHA_INGRESO,@COSTO_ANTERIOR,@COSTO_ACTUAL,@AJUSTE,@UNI)")
                        Dim comando_ajuste_p As New SqlCommand(query_ajuste_p.ToString, sql_con)
                        comando_ajuste_p.Parameters.AddWithValue("@ID_AJUSTE", dt_folio_ajuste.Rows(0)(0))
                        comando_ajuste_p.Parameters.AddWithValue("@NUM_PART", index + 1)
                        comando_ajuste_p.Parameters.AddWithValue("@CVE_ART", dt_p.Rows(index)(1))
                        comando_ajuste_p.Parameters.AddWithValue("@DESCRIPCION", dt_p.Rows(index)(2))
                        comando_ajuste_p.Parameters.AddWithValue("@MOTIVO", "AJUSTE DE PRECIO")
                        comando_ajuste_p.Parameters.AddWithValue("@CANTIDAD", dt_p.Rows(index)(4))
                        comando_ajuste_p.Parameters.AddWithValue("@FECHA_INGRESO", Convert.ToDateTime(dt_e.Rows(0)(5)))
                        comando_ajuste_p.Parameters.AddWithValue("@COSTO_ANTERIOR", dt_p.Rows(index)(5))
                        comando_ajuste_p.Parameters.AddWithValue("@COSTO_ACTUAL", dt_p.Rows(index)(6))
                        Dim valor_ajuste As Double = 0

                        valor_ajuste = (Convert.ToDouble(dt_p.Rows(index)(4)) * Convert.ToDouble(dt_p.Rows(index)(6))) - (Convert.ToDouble(dt_p.Rows(index)(4)) * Convert.ToDouble(dt_p.Rows(index)(5)))
                        If dt_p.Rows(index)(0) = "cj" Then
                            valor_ajuste = valor_ajuste * Convert.ToDouble(dt_p.Rows(index)(3))
                        End If

                        comando_ajuste_p.Parameters.AddWithValue("@AJUSTE", valor_ajuste * -1)
                        comando_ajuste_p.Parameters.AddWithValue("@UNI", dt_p.Rows(index)(0))

                        subtotal_ajuste_e += valor_ajuste
                        descuento_ajuste_e += 0 'valor_ajuste '* dt_p.Rows(index)(7) / 100
                        valor_ajuste = valor_ajuste - descuento_ajuste_e
                        isv_ajuste_e += valor_ajuste * dt_p.Rows(index)(8) / 100
                        comando_ajuste_p.Transaction = mi_transaccion
                        comando_ajuste_p.ExecuteNonQuery()
                    End If
                Next
                total_ajueste_e += subtotal_ajuste_e - descuento_ajuste_e + isv_ajuste_e

                Dim query_ajuste_e As New StringBuilder
                query_ajuste_e.Append("INSERT INTO [tactical_discount_sragro].[dbo].[nd_ajuste_e] ")
                query_ajuste_e.Append("([ID_AJUSTE],[CVE_PROVEEDOR],[ALMACEN],[REF_PROV]")
                query_ajuste_e.Append(",[FECHA],[N_FACTURA],[SUBTOTAL],[DESCUENTO],[ISV],[TOTAL],[COMPRA],[TIPO]) ")
                query_ajuste_e.Append("VALUES ")
                query_ajuste_e.Append("(@ID_AJUSTE,@CVE_PROVEEDOR,@ALMACEN,@REF_PROV,@FECHA, ")
                query_ajuste_e.Append("@N_FACTURA,@SUBTOTAL,@DESCUENTO,@ISV,@TOTAL,@COMPRA,@TIPO)")
                Dim comando_ajuste_e As New SqlCommand(query_ajuste_e.ToString, sql_con)
                comando_ajuste_e.Parameters.AddWithValue("@ID_AJUSTE", dt_folio_ajuste.Rows(0)(0))
                comando_ajuste_e.Parameters.AddWithValue("@CVE_PROVEEDOR", dt_e.Rows(0)(0))
                comando_ajuste_e.Parameters.AddWithValue("@ALMACEN", dt_e.Rows(0)(2))
                comando_ajuste_e.Parameters.AddWithValue("@REF_PROV", dt_e.Rows(0)(3))
                comando_ajuste_e.Parameters.AddWithValue("@FECHA", Convert.ToDateTime(dt_e.Rows(0)(5)))
                comando_ajuste_e.Parameters.AddWithValue("@N_FACTURA", CVE_DOC)
                comando_ajuste_e.Parameters.AddWithValue("@SUBTOTAL", subtotal_ajuste_e * -1)
                comando_ajuste_e.Parameters.AddWithValue("@DESCUENTO", 0) 'descuento_ajuste_e * -1)
                comando_ajuste_e.Parameters.AddWithValue("@ISV", isv_ajuste_e * -1)
                comando_ajuste_e.Parameters.AddWithValue("@TOTAL", total_ajueste_e * -1)
                comando_ajuste_e.Parameters.AddWithValue("@COMPRA", CVE_COMPRA)
                comando_ajuste_e.Parameters.AddWithValue("@TIPO", "DEBITO")
                comando_ajuste_e.Transaction = mi_transaccion
                comando_ajuste_e.ExecuteNonQuery()

                Dim query_upd_folio_ajuste As New StringBuilder
                query_upd_folio_ajuste.Append("UPDATE [tactical_discount_sragro].[dbo].[nd_folios] ")
                query_upd_folio_ajuste.Append("   SET [ULT_DOC] = ULT_DOC+1 ")
                query_upd_folio_ajuste.Append("WHERE [NUM_ALMA] = @NUM_ALMA AND TIPO = 'A' ")
                Dim comando_upd_folio_ajuste As New SqlCommand(query_upd_folio_ajuste.ToString, sql_con)
                comando_upd_folio_ajuste.Parameters.AddWithValue("@NUM_ALMA", dt_e.Rows(0)(2))
                comando_upd_folio_ajuste.Transaction = mi_transaccion
                comando_upd_folio_ajuste.ExecuteNonQuery()

            End If
            ' fn registra los debitos por producto

            Dim query_dias_cred As New StringBuilder
            query_dias_cred.Append("Select ISNULL(DIASCRED,0) ")
            query_dias_cred.Append("FROM SAE60EMPRE02.dbo.PROV02 ")
            query_dias_cred.Append("WHERE (CLAVE = @CLAVE) ")
            Dim comando_dias_cred As New SqlCommand(query_dias_cred.ToString, sql_con)
            comando_dias_cred.Parameters.AddWithValue("@CLAVE", dt_e.Rows(0)(0))
            comando_dias_cred.Transaction = mi_transaccion
            Dim adaptador_dias_cred As New SqlDataAdapter(comando_dias_cred)
            Dim dt_dias_cred As New DataTable
            adaptador_dias_cred.Fill(dt_dias_cred)
            Dim dias_cred As Integer = 0
            dias_cred = dt_dias_cred.Rows(0)(0)

            ' registra los creditos por producto
            If debito = "D" Then
                Dim query_folio_debito As New StringBuilder
                query_folio_debito.Append("SELECT FOLIO + CONVERT(VARCHAR, ULT_DOC + 1) AS ULT_DOC ")
                query_folio_debito.Append("FROM nd_folios ")
                query_folio_debito.Append("WHERE (TIPO = 'D') AND (NUM_ALMA = @ALMACEN)")
                Dim comando_folio_debito As New SqlCommand(query_folio_debito.ToString, sql_con)
                comando_folio_debito.Parameters.AddWithValue("@ALMACEN", dt_e.Rows(0)(2))
                comando_folio_debito.Transaction = mi_transaccion
                Dim dt_folio_debito As New DataTable
                Dim adaptador_folio_debito As New SqlDataAdapter(comando_folio_debito)
                adaptador_folio_debito.Fill(dt_folio_debito)

                Dim subtotal_debito_e As Double = 0, isv_debito_e As Double = 0, total_debito_e As Double = 0, descuento_debito_e As Double = 0
                For index As Integer = 0 To dt_p.Rows.Count - 1
                    If dt_p.Rows(index)(14) = "D" Then
                        Dim query_debito_p As New StringBuilder
                        query_debito_p.Append("INSERT INTO [tactical_discount_sragro].[dbo].[nd_ajuste_p] ")
                        query_debito_p.Append("([ID_AJUSTE],[NUM_PART],[CVE_ART],[DESCRIPCION],[MOTIVO],[CANTIDAD], ")
                        query_debito_p.Append("[FECHA_INGRESO],[COSTO_ANTERIOR],[COSTO_ACTUAL],[AJUSTE],[UNI]) ")
                        query_debito_p.Append("VALUES ")
                        query_debito_p.Append("(@ID_AJUSTE,@NUM_PART,@CVE_ART,@DESCRIPCION,@MOTIVO,@CANTIDAD, ")
                        query_debito_p.Append("@FECHA_INGRESO,@COSTO_ANTERIOR,@COSTO_ACTUAL,@AJUSTE,@UNI)")
                        Dim comando_debito_p As New SqlCommand(query_debito_p.ToString, sql_con)
                        comando_debito_p.Parameters.AddWithValue("@ID_AJUSTE", dt_folio_debito.Rows(0)(0))
                        comando_debito_p.Parameters.AddWithValue("@NUM_PART", index + 1)
                        comando_debito_p.Parameters.AddWithValue("@CVE_ART", dt_p.Rows(index)(1))
                        comando_debito_p.Parameters.AddWithValue("@DESCRIPCION", dt_p.Rows(index)(2))
                        comando_debito_p.Parameters.AddWithValue("@MOTIVO", "AJUSTE DE PRECIO")
                        comando_debito_p.Parameters.AddWithValue("@CANTIDAD", dt_p.Rows(index)(4))
                        comando_debito_p.Parameters.AddWithValue("@FECHA_INGRESO", Convert.ToDateTime(dt_e.Rows(0)(5)))
                        comando_debito_p.Parameters.AddWithValue("@COSTO_ANTERIOR", dt_p.Rows(index)(5))
                        comando_debito_p.Parameters.AddWithValue("@COSTO_ACTUAL", dt_p.Rows(index)(6))
                        Dim valor_ajuste As Double = 0
                        valor_ajuste = (Convert.ToDouble(dt_p.Rows(index)(4)) * Convert.ToDouble(dt_p.Rows(index)(6))) - (Convert.ToDouble(dt_p.Rows(index)(4)) * Convert.ToDouble(dt_p.Rows(index)(5)))
                        If dt_p.Rows(index)(0) = "cj" Then
                            valor_ajuste = valor_ajuste * Convert.ToDouble(dt_p.Rows(index)(3))
                        End If
                        comando_debito_p.Parameters.AddWithValue("@AJUSTE", Math.Abs(valor_ajuste))
                        comando_debito_p.Parameters.AddWithValue("@UNI", dt_p.Rows(index)(0))

                        subtotal_debito_e += valor_ajuste
                        descuento_debito_e += 0 'valor_ajuste '* dt_p.Rows(index)(7) / 100
                        valor_ajuste = valor_ajuste - descuento_debito_e
                        isv_debito_e += valor_ajuste * dt_p.Rows(index)(8) / 100
                        comando_debito_p.Transaction = mi_transaccion
                        comando_debito_p.ExecuteNonQuery()
                    End If
                Next
                total_debito_e += subtotal_debito_e - descuento_debito_e + isv_debito_e

                Dim query_debito_e As New StringBuilder
                query_debito_e.Append("INSERT INTO [tactical_discount_sragro].[dbo].[nd_ajuste_e] ")
                query_debito_e.Append("([ID_AJUSTE],[CVE_PROVEEDOR],[ALMACEN],[REF_PROV]")
                query_debito_e.Append(",[FECHA],[N_FACTURA],[SUBTOTAL],[DESCUENTO],[ISV],[TOTAL],[COMPRA],[TIPO]) ")
                query_debito_e.Append("VALUES ")
                query_debito_e.Append("(@ID_AJUSTE,@CVE_PROVEEDOR,@ALMACEN,@REF_PROV,@FECHA, ")
                query_debito_e.Append("@N_FACTURA,@SUBTOTAL,@DESCUENTO,@ISV,@TOTAL,@COMPRA,@TIPO)")
                Dim comando_debito_e As New SqlCommand(query_debito_e.ToString, sql_con)
                comando_debito_e.Parameters.AddWithValue("@ID_AJUSTE", dt_folio_debito.Rows(0)(0))
                comando_debito_e.Parameters.AddWithValue("@CVE_PROVEEDOR", dt_e.Rows(0)(0))
                comando_debito_e.Parameters.AddWithValue("@ALMACEN", dt_e.Rows(0)(2))
                comando_debito_e.Parameters.AddWithValue("@REF_PROV", dt_e.Rows(0)(3))
                comando_debito_e.Parameters.AddWithValue("@FECHA", Convert.ToDateTime(dt_e.Rows(0)(5)))
                comando_debito_e.Parameters.AddWithValue("@N_FACTURA", CVE_DOC)
                comando_debito_e.Parameters.AddWithValue("@SUBTOTAL", Math.Abs(subtotal_debito_e))
                comando_debito_e.Parameters.AddWithValue("@DESCUENTO", 0) ' Math.Abs(descuento_debito_e))
                comando_debito_e.Parameters.AddWithValue("@ISV", Math.Abs(isv_debito_e))
                comando_debito_e.Parameters.AddWithValue("@TOTAL", Math.Abs(total_debito_e))
                comando_debito_e.Parameters.AddWithValue("@COMPRA", CVE_COMPRA)
                comando_debito_e.Parameters.AddWithValue("@TIPO", "CREDITO")
                comando_debito_e.Transaction = mi_transaccion
                comando_debito_e.ExecuteNonQuery()

                Dim query_upd_folio_ajuste As New StringBuilder
                query_upd_folio_ajuste.Append("UPDATE [tactical_discount_sragro].[dbo].[nd_folios] ")
                query_upd_folio_ajuste.Append("   SET [ULT_DOC] = ULT_DOC+1 ")
                query_upd_folio_ajuste.Append("WHERE [NUM_ALMA] = @NUM_ALMA AND TIPO = 'D' ")
                Dim comando_upd_folio_ajuste As New SqlCommand(query_upd_folio_ajuste.ToString, sql_con)
                comando_upd_folio_ajuste.Parameters.AddWithValue("@NUM_ALMA", dt_e.Rows(0)(2))
                comando_upd_folio_ajuste.Transaction = mi_transaccion
                comando_upd_folio_ajuste.ExecuteNonQuery()

                Dim query_opaga As New StringBuilder
                query_opaga.Append("INSERT INTO [SAE60Empre02].[dbo].[OPAGA02] ")
                query_opaga.Append("([CVE_OBS],[STR_OBS]) ")
                query_opaga.Append("VALUES ((SELECT ULT_CVE + 1 AS ULT_CVE FROM SAE60EMPRE02.dbo.TBLCONTROL02 WHERE (ID_TABLA = 21)),'NOTA DE CREDITO POR PRECIO MENOR DEL PROVEEDOR')")
                Dim comando_opaga As New SqlCommand(query_opaga.ToString, sql_con)
                comando_opaga.Transaction = mi_transaccion
                comando_opaga.ExecuteNonQuery()

                Dim query_paga_det As New StringBuilder
                query_paga_det.Append("INSERT INTO [SAE60Empre02].[dbo].[PAGA_DET02] ")
                query_paga_det.Append("([CVE_PROV],[REFER],[NUM_CPTO],[NUM_CARGO],[ID_MOV] ")
                query_paga_det.Append(",[CVE_OBS],[NO_FACTURA],[DOCTO],[IMPORTE],[FECHA_APLI],[FECHA_VENC] ")
                query_paga_det.Append(",[NUM_MONED],[TCAMBIO],[IMPMON_EXT],[FECHAELAB] ")
                query_paga_det.Append(",[TIPO_MOV],[SIGNO],[USUARIO] ")
                query_paga_det.Append(",[NO_PARTIDA]) ")
                query_paga_det.Append("VALUES ")
                query_paga_det.Append("(@CVE_PROV, @REFER, 29,1,1, (SELECT ULT_CVE + 1 AS ULT_CVE FROM SAE60EMPRE02.dbo.TBLCONTROL02 WHERE (ID_TABLA = 21)), ")
                query_paga_det.Append("@NO_FACTURA, @DOCTO, @IMPORTE, @FECHA_APLI, @FECHA_VENC, 1, ")
                query_paga_det.Append("1, @IMPMON_EXT, @FECHAELAB,'A', -1,0, 1) ")
                Dim comando_paga_det As New SqlCommand(query_paga_det.ToString, sql_con)
                comando_paga_det.Parameters.AddWithValue("@CVE_PROV", dt_e.Rows(0)(0))
                comando_paga_det.Parameters.AddWithValue("@REFER", CVE_DOC)
                comando_paga_det.Parameters.AddWithValue("@NO_FACTURA", CVE_DOC)
                comando_paga_det.Parameters.AddWithValue("@DOCTO", CVE_DOC)
                comando_paga_det.Parameters.AddWithValue("@IMPORTE", Math.Abs(total_debito_e))
                comando_paga_det.Parameters.AddWithValue("@FECHA_APLI", Convert.ToDateTime(dt_e.Rows(0)(5)))
                comando_paga_det.Parameters.AddWithValue("@FECHA_VENC", Convert.ToDateTime(dt_e.Rows(0)(5)).AddDays(dias_cred))
                comando_paga_det.Parameters.AddWithValue("@IMPMON_EXT", Math.Abs(total_debito_e))
                comando_paga_det.Parameters.AddWithValue("@FECHAELAB", Convert.ToDateTime(dt_e.Rows(0)(5)))
                comando_paga_det.Transaction = mi_transaccion
                comando_paga_det.ExecuteNonQuery()

                Dim query_upd_paga_det As New StringBuilder
                query_upd_paga_det.Append("UPDATE [SAE60Empre02].[dbo].[TBLCONTROL02] ")
                query_upd_paga_det.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                query_upd_paga_det.Append("WHERE ([ID_TABLA] = 21)")
                Dim comando_upd_paga_det As New SqlCommand(query_upd_paga_det.ToString, sql_con)
                comando_upd_paga_det.Transaction = mi_transaccion
                comando_upd_paga_det.ExecuteNonQuery()
            End If
            ' fin registra los creditos por producto

            'registrar envio a SAE

            Dim query_compc As New StringBuilder
            query_compc.Append("INSERT INTO [SAE60Empre02].[dbo].[COMPC02] ")
            query_compc.Append("([TIP_DOC],[CVE_DOC],[CVE_CLPV],[STATUS],[SU_REFER] ")
            query_compc.Append(",[FECHA_DOC],[FECHA_REC],[FECHA_PAG] ")
            query_compc.Append(",[CAN_TOT],[IMP_TOT1],[IMP_TOT2],[IMP_TOT3],[IMP_TOT4] ")
            query_compc.Append(",[DES_TOT],[DES_FIN],[TOT_IND],[OBS_COND],[CVE_OBS] ")
            query_compc.Append(",[NUM_ALMA],[ACT_CXP],[ACT_COI],[ENLAZADO],[TIP_DOC_E] ")
            query_compc.Append(",[NUM_MONED],[TIPCAMB],[NUM_PAGOS],[FECHAELAB] ")
            query_compc.Append(",[SERIE],[FOLIO],[CTLPOL],[ESCFD],[CONTADO],[BLOQ] ")
            query_compc.Append(",[DES_FIN_PORC],[DES_TOT_PORC],[IMPORTE],[TIP_DOC_ANT],[DOC_ANT]) ")
            query_compc.Append("VALUES ")
            query_compc.Append("('c', @CVE_DOC,@CVE_CLPV,'O',@SU_REFER,@FECHA_DOC ")
            query_compc.Append(",@FECHA_REC,@FECHA_PAG,@CAN_TOT,0,0,0,@IMP_TOT4,@DES_TOT,0,0 ")
            query_compc.Append(",'',0,@NUM_ALMA,'S','N','O','O',1,1,1,@FECHAELAB ")
            query_compc.Append(",@SERIE,@FOLIO,0,'N','N','N',0 ,@DES_TOT_PORC,@IMPORTE,'','' )")
            Dim comando_compc As New SqlCommand(query_compc.ToString, sql_con)
            comando_compc.Parameters.AddWithValue("@CVE_DOC", CVE_DOC)
            comando_compc.Parameters.AddWithValue("@CVE_CLPV", dt_e.Rows(0)(0))
            comando_compc.Parameters.AddWithValue("@SU_REFER", dt_e.Rows(0)(3))
            comando_compc.Parameters.AddWithValue("@FECHA_DOC", Convert.ToDateTime(dt_e.Rows(0)(5)))
            comando_compc.Parameters.AddWithValue("@FECHA_REC", Convert.ToDateTime(dt_e.Rows(0)(5)))
            comando_compc.Parameters.AddWithValue("@FECHA_PAG", Convert.ToDateTime(dt_e.Rows(0)(5)).AddDays(dias_cred)) 'Agregar dias de credito
            comando_compc.Parameters.AddWithValue("@CAN_TOT", dt_e.Rows(0)(7))
            comando_compc.Parameters.AddWithValue("@IMP_TOT4", dt_e.Rows(0)(9))
            comando_compc.Parameters.AddWithValue("@DES_TOT", dt_e.Rows(0)(8))
            comando_compc.Parameters.AddWithValue("@NUM_ALMA", dt_e.Rows(0)(2))
            comando_compc.Parameters.AddWithValue("@FECHAELAB", Now.Date)
            comando_compc.Parameters.AddWithValue("@SERIE", serie)
            comando_compc.Parameters.AddWithValue("@FOLIO", folio)
            comando_compc.Parameters.AddWithValue("@DES_TOT_PORC", dt_e.Rows(0)(6))
            comando_compc.Parameters.AddWithValue("@IMPORTE", dt_e.Rows(0)(10))
            comando_compc.Transaction = mi_transaccion
            comando_compc.ExecuteNonQuery()

            Dim query_compc_clib As New StringBuilder
            query_compc_clib.Append("INSERT INTO [SAE60Empre02].[dbo].[COMPC_CLIB02] ")
            query_compc_clib.Append(" ([CLAVE_DOC],[CAMPLIB1]) ")
            query_compc_clib.Append("VALUES (@CLAVE_DOC,@CAMPLIB1)")
            Dim comando_comp_clib As New SqlCommand(query_compc_clib.ToString, sql_con)
            comando_comp_clib.Parameters.AddWithValue("CLAVE_DOC", CVE_DOC)
            comando_comp_clib.Parameters.AddWithValue("@CAMPLIB1", Convert.ToDateTime(dt_e.Rows(0)(18)))
            comando_comp_clib.Transaction = mi_transaccion
            comando_comp_clib.ExecuteNonQuery()

            'inicio del for

            For index As Integer = 0 To dt_p.Rows.Count - 1
                Dim query_correlativo_lote As New StringBuilder
                query_correlativo_lote.Append("SELECT (ULT_CVE + 1) AS ULT_CVE ")
                query_correlativo_lote.Append("FROM SAE60EMPRE02.dbo.TBLCONTROL02 ")
                query_correlativo_lote.Append("WHERE (ID_TABLA = 67) ")
                Dim comando_correlativo_lote As New SqlCommand(query_correlativo_lote.ToString, sql_con)
                comando_correlativo_lote.Transaction = mi_transaccion
                Dim adaptador_correlativo_lote As New SqlDataAdapter(comando_correlativo_lote)
                Dim dt_correlativo_lote As New DataTable
                adaptador_correlativo_lote.Fill(dt_correlativo_lote)
                Dim correlativo_lote As Integer
                correlativo_lote = dt_correlativo_lote.Rows(0)(0)

                Dim query_par_compc As New StringBuilder
                query_par_compc.Append("INSERT INTO [SAE60Empre02].[dbo].[PAR_COMPC02] ")
                query_par_compc.Append("   ([CVE_DOC],[NUM_PAR],[CVE_ART],[CANT],[PXR],[PREC],[COST] ")
                query_par_compc.Append("   ,[IMPU1],[IMPU2],[IMPU3],[IMPU4],[IMP1APLA],[IMP2APLA],[IMP3APLA] ")
                query_par_compc.Append("   ,[IMP4APLA],[TOTIMP1],[TOTIMP2],[TOTIMP3],[TOTIMP4],[DESCU],[ACT_INV] ")
                query_par_compc.Append("   ,[TIP_CAM],[UNI_VENTA],[TIPO_ELEM],[TIPO_PROD],[CVE_OBS],[REG_SERIE] ")
                query_par_compc.Append("   ,[E_LTPD],[FACTCONV],[COST_DEV],[NUM_ALM],[MINDIRECTO],[NUM_MOV],[TOT_PARTIDA]) ")
                query_par_compc.Append("VALUES ")
                query_par_compc.Append("  (@CVE_DOC,@NUM_PAR,@CVE_ART, @CANT, @PXR, ISNULL((SELECT SAE60Empre02.dbo.PRECIO_X_PROD02.PRECIO ")
                query_par_compc.Append("FROM SAE60Empre02.dbo.INVE02 INNER JOIN SAE60Empre02.dbo.PRECIO_X_PROD02 ON ")
                query_par_compc.Append("SAE60Empre02.dbo.INVE02.CVE_ART = SAE60Empre02.dbo.PRECIO_X_PROD02.CVE_ART ")
                query_par_compc.Append("WHERE (SAE60Empre02.dbo.PRECIO_X_PROD02.CVE_PRECIO = 1) AND (SAE60Empre02.dbo.INVE02.CVE_ART = @CVE_ART)),0), @COST, 0, 0, 0, ")
                query_par_compc.Append("   @IMPU4, 0, 0, 0, 0, 0, 0, ")
                query_par_compc.Append("   0, @TOTIMP4, @DESCU, 'S', 1, @UNI_VENTA, 'N', ")
                query_par_compc.Append("   'P', 0,0,@E_LTPD,@FACTCONV, @COST_DEV, @NUM_ALM, ")
                query_par_compc.Append("   0, (SELECT ULT_CVE + 1 FROM SAE60EMPRE02.dbo.TBLCONTROL02 WHERE (ID_TABLA = 44)),@TOT_PARTIDA)")

                Dim comando_par_compc As New SqlCommand(query_par_compc.ToString, sql_con)
                comando_par_compc.Parameters.AddWithValue("@CVE_DOC", CVE_DOC)
                comando_par_compc.Parameters.AddWithValue("@NUM_PAR", index + 1)
                comando_par_compc.Parameters.AddWithValue("@CVE_ART", dt_p.Rows(index)(1))
                comando_par_compc.Parameters.AddWithValue("@CANT", Convert.ToDouble(dt_p.Rows(index)(4)))

                Dim cant_insertar As Double = 0
                Dim factor_conversion As Integer = 0
                Dim costo_insertar As Double = 0
                If dt_p.Rows(index)(0) = "cj" Then
                    cant_insertar = Convert.ToDouble(dt_p.Rows(index)(4)) * dt_p.Rows(index)(3)
                    factor_conversion = dt_p.Rows(index)(3)
                    costo_insertar = dt_p.Rows(index)(20) * dt_p.Rows(index)(3)
                ElseIf dt_p.Rows(index)(0) = "pz" Then
                    cant_insertar = Convert.ToDouble(dt_p.Rows(index)(4))
                    factor_conversion = 1
                    costo_insertar = dt_p.Rows(index)(20)
                End If

                comando_par_compc.Parameters.AddWithValue("@PXR", cant_insertar)
                comando_par_compc.Parameters.AddWithValue("@COST", costo_insertar)
                comando_par_compc.Parameters.AddWithValue("@IMPU4", dt_p.Rows(index)(8))
                comando_par_compc.Parameters.AddWithValue("@TOTIMP4", Convert.ToDouble(dt_p.Rows(index)(11)))
                comando_par_compc.Parameters.AddWithValue("@DESCU", 0) 'dt_p.Rows(index)(7))
                comando_par_compc.Parameters.AddWithValue("@UNI_VENTA", dt_p.Rows(index)(0))
                comando_par_compc.Parameters.AddWithValue("@E_LTPD", correlativo_lote)
                comando_par_compc.Parameters.AddWithValue("@FACTCONV", factor_conversion)
                comando_par_compc.Parameters.AddWithValue("@COST_DEV", dt_p.Rows(index)(20) * dt_p.Rows(index)(3))
                comando_par_compc.Parameters.AddWithValue("@NUM_ALM", dt_e.Rows(0)(2))
                comando_par_compc.Parameters.AddWithValue("@TOT_PARTIDA", (dt_p.Rows(index)(20) * dt_p.Rows(index)(3) * Convert.ToDouble(dt_p.Rows(index)(4))) - Convert.ToDouble(dt_p.Rows(index)(11)))

                comando_par_compc.Transaction = mi_transaccion
                comando_par_compc.ExecuteNonQuery()

                Dim query_par_comp_clib As New StringBuilder
                query_par_comp_clib.Append("INSERT INTO [SAE60Empre02].[dbo].[PAR_COMPC_CLIB02] ")
                query_par_comp_clib.Append("   ([CLAVE_DOC],[NUM_PART]) ")
                query_par_comp_clib.Append("VALUES ")
                query_par_comp_clib.Append("   (@CLAVE_DOC,@NUM_PART) ")
                Dim comando_par_comp_clib As New SqlCommand(query_par_comp_clib.ToString, sql_con)
                comando_par_comp_clib.Parameters.AddWithValue("@CLAVE_DOC", CVE_DOC)
                comando_par_comp_clib.Parameters.AddWithValue("@NUM_PART", index + 1)
                comando_par_comp_clib.Transaction = mi_transaccion
                comando_par_comp_clib.ExecuteNonQuery()

                Dim query_costo_prom As New StringBuilder
                query_costo_prom.Append("SELECT ISNULL(EXIST,0),ISNULL(COSTO_PROM,0) FROM SAE60EMPRE02.dbo.INVE02 WHERE CVE_ART = @CVE_ART")
                Dim comando_costo_prom As New SqlCommand(query_costo_prom.ToString, sql_con)
                comando_costo_prom.Parameters.AddWithValue("@CVE_ART", dt_p.Rows(index)(1))
                comando_costo_prom.Transaction = mi_transaccion
                Dim adaptador_costo As New SqlDataAdapter(comando_costo_prom)
                Dim dt_costo_prom As New DataTable
                adaptador_costo.Fill(dt_costo_prom)
                Dim existencias_viejas As Double = 0, costo_prom_viejo As Double = 0
                existencias_viejas = dt_costo_prom.Rows(0)(0)
                costo_prom_viejo = dt_costo_prom.Rows(0)(1)

                Dim costo_prom_nuevo As Double = 0
                costo_prom_nuevo = ((existencias_viejas * costo_prom_viejo) + (cant_insertar * (dt_p.Rows(index)(20)))) / (existencias_viejas + cant_insertar)


                Dim query_upd_inve As New StringBuilder
                query_upd_inve.Append("UPDATE SAE60EMPRE02.dbo.INVE02 ")
                query_upd_inve.Append("SET [EXIST] = (EXIST + @NUEVA_EXISTENCIA), ")
                query_upd_inve.Append("FCH_ULTCOM = @FECHA_ULTCOM, COSTO_PROM = @COSTO_PROM, ULT_COSTO = @ULT_COSTO ")
                query_upd_inve.Append("WHERE [CVE_ART] = @CVE_ART ")
                Dim comando_upd_inve As New SqlCommand(query_upd_inve.ToString, sql_con)
                comando_upd_inve.Parameters.AddWithValue("@NUEVA_EXISTENCIA", cant_insertar)
                comando_upd_inve.Parameters.AddWithValue("@FECHA_ULTCOM", Now.Date)
                comando_upd_inve.Parameters.AddWithValue("@CVE_ART", dt_p.Rows(index)(1))
                comando_upd_inve.Parameters.AddWithValue("@COSTO_PROM", costo_prom_nuevo)
                comando_upd_inve.Parameters.AddWithValue("@ULT_COSTO", dt_p.Rows(index)(20))
                comando_upd_inve.Transaction = mi_transaccion
                comando_upd_inve.ExecuteNonQuery()

                Dim query_upd_mult As New StringBuilder
                query_upd_mult.Append("UPDATE SAE60EMPRE02.dbo.MULT02 ")
                query_upd_mult.Append("SET [EXIST] = (EXIST + @NUEVA_EXISTENCIA) ")
                query_upd_mult.Append("WHERE  [CVE_ART] = @CVE_ART AND [CVE_ALM] = @CVE_ALM ")
                Dim comando_upd_mult As New SqlCommand(query_upd_mult.ToString, sql_con)
                comando_upd_mult.Parameters.AddWithValue("@NUEVA_EXISTENCIA", cant_insertar)
                comando_upd_mult.Parameters.AddWithValue("@CVE_ART", dt_p.Rows(index)(1))
                comando_upd_mult.Parameters.AddWithValue("@CVE_ALM", dt_e.Rows(0)(2))
                comando_upd_mult.Transaction = mi_transaccion
                comando_upd_mult.ExecuteNonQuery()

                If dt_p.Rows(index)(22) = "S" Then
                    Dim query_reg_lote As New StringBuilder
                    query_reg_lote.Append("SELECT (ULT_CVE + 1) AS ULT_CVE ")
                    query_reg_lote.Append("FROM SAE60EMPRE02.dbo.TBLCONTROL02 ")
                    query_reg_lote.Append("WHERE (ID_TABLA = 48) ")
                    Dim comando_reg_lote As New SqlCommand(query_reg_lote.ToString, sql_con)
                    comando_reg_lote.Transaction = mi_transaccion
                    Dim adaptador_reg_lote As New SqlDataAdapter(comando_reg_lote)
                    Dim dt_reg_lote As New DataTable
                    adaptador_reg_lote.Fill(dt_reg_lote)
                    Dim reg_lote As Integer
                    reg_lote = dt_reg_lote.Rows(0)(0)

                    Dim query_ltpd As New StringBuilder
                    query_ltpd.Append("INSERT INTO [SAE60Empre02].[dbo].[LTPD02] ")
                    query_ltpd.Append("   ([CVE_ART],[LOTE],[PEDIMENTO],[CVE_ALM] ")
                    query_ltpd.Append("   ,[FCHULTMOV],[NOM_ADUAN],[CANTIDAD],[REG_LTPD],[CVE_OBS] ")
                    query_ltpd.Append("   ,[CIUDAD],[FRONTERA],[GLN],[STATUS]) ")
                    query_ltpd.Append("VALUES ")
                    query_ltpd.Append("   (@CVE_ART,@LOTE,'',@CVE_ALM,@FCHULTMOV, ")
                    query_ltpd.Append("'', @CANTIDAD, @REG_LTPD, 0, '', '', '','A')")
                    Dim comando_ltpd As New SqlCommand(query_ltpd.ToString, sql_con)
                    comando_ltpd.Parameters.AddWithValue("@CVE_ART", dt_p.Rows(index)(1))
                    Dim codigo_lote As String = ""

                    If conlote = "S" Then
                        codigo_lote = lote
                    Else
                        codigo_lote = CVE_DOC
                    End If

                    comando_ltpd.Parameters.AddWithValue("@LOTE", codigo_lote)
                    comando_ltpd.Parameters.AddWithValue("@CVE_ALM", dt_e.Rows(0)(2))
                    comando_ltpd.Parameters.AddWithValue("@FCHULTMOV", Now.Date)
                    comando_ltpd.Parameters.AddWithValue("@CANTIDAD", cant_insertar)
                    comando_ltpd.Parameters.AddWithValue("@REG_LTPD", reg_lote)
                    comando_ltpd.Transaction = mi_transaccion
                    comando_ltpd.ExecuteNonQuery()

                    Dim query_enlace_ltpd As New StringBuilder
                    query_enlace_ltpd.Append("INSERT INTO [SAE60Empre02].[dbo].[ENLACE_LTPD02] ")
                    query_enlace_ltpd.Append("   ([E_LTPD],[REG_LTPD],[CANTIDAD],[PXRS]) ")
                    query_enlace_ltpd.Append("VALUES ")
                    query_enlace_ltpd.Append("   (@E_LTPD,@REG_LTPD, @CANTIDAD,@PXRS)")
                    Dim comando_enlace_ltpd As New SqlCommand(query_enlace_ltpd.ToString, sql_con)
                    comando_enlace_ltpd.Parameters.AddWithValue("@E_LTPD", correlativo_lote)
                    comando_enlace_ltpd.Parameters.AddWithValue("@REG_LTPD", reg_lote)
                    comando_enlace_ltpd.Parameters.AddWithValue("@CANTIDAD", cant_insertar)
                    comando_enlace_ltpd.Parameters.AddWithValue("@PXRS", cant_insertar)
                    comando_enlace_ltpd.Transaction = mi_transaccion
                    comando_enlace_ltpd.ExecuteNonQuery()

                    Dim query_upd_correlativo_lote As New StringBuilder
                    query_upd_correlativo_lote.Append("UPDATE [SAE60Empre02].[dbo].[TBLCONTROL02] ")
                    query_upd_correlativo_lote.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                    query_upd_correlativo_lote.Append("WHERE([ID_TABLA] = 67)")
                    Dim comando_upd_correlativo_lote As New SqlCommand(query_upd_correlativo_lote.ToString, sql_con)
                    comando_upd_correlativo_lote.Transaction = mi_transaccion
                    comando_upd_correlativo_lote.ExecuteNonQuery()

                    Dim query_upd_reg_lote As New StringBuilder
                    query_upd_reg_lote.Append("UPDATE [SAE60Empre02].[dbo].[TBLCONTROL02] ")
                    query_upd_reg_lote.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                    query_upd_reg_lote.Append("WHERE([ID_TABLA] = 48)")
                    Dim comando_upd_reg_lote As New SqlCommand(query_upd_reg_lote.ToString, sql_con)
                    comando_upd_reg_lote.Transaction = mi_transaccion
                    comando_upd_reg_lote.ExecuteNonQuery()
                End If


                Dim query_minve As New StringBuilder
                query_minve.Append("INSERT INTO [SAE60Empre02].[dbo].[MINVE02] ")
                query_minve.Append("   ([CVE_ART],[ALMACEN],[NUM_MOV],[CVE_CPTO],[FECHA_DOCU] ")
                query_minve.Append("   ,[TIPO_DOC],[REFER],[CLAVE_CLPV],[VEND],[CANT],[CANT_COST] ")
                query_minve.Append("   ,[PRECIO],[COSTO],[REG_SERIE],[UNI_VENTA] ")
                query_minve.Append("   ,[E_LTPD],[EXIST_G],[EXISTENCIA],[FACTOR_CON] ")
                query_minve.Append("   ,[FECHAELAB],[CVE_FOLIO],[SIGNO],[COSTEADO],[COSTO_PROM_INI] ")
                query_minve.Append("   ,[COSTO_PROM_FIN],[COSTO_PROM_GRAL],[DESDE_INVE],[MOV_ENLAZADO]) ")
                query_minve.Append("VALUES ")
                query_minve.Append("   (@CVE_ART, @ALMACEN,(SELECT ULT_CVE+1 FROM SAE60EMPRE02.dbo.TBLCONTROL02 WHERE (ID_TABLA = 44)),1,@FECHA_DOCU, 'c', @REFER, ")
                query_minve.Append("   @CLAVE_CLPV, '',@CANT, 0, 0, @COSTO,  ")
                query_minve.Append("   0,@UNI_VENTA, @E_LTPD,@CANT+ISNULL((SELECT EXIST FROM SAE60EMPRE02.dbo.INVE02 WHERE (CVE_ART = @CVE_ART)),0), ((SELECT EXIST FROM SAE60EMPRE02.dbo.MULT02 WHERE (CVE_ART = @CVE_ART) AND CVE_ALM = @ALMACEN)), @FACTOR_CON, ")
                query_minve.Append("   @FECHAELAB, (SELECT ULT_CVE+1 FROM SAE60EMPRE02.dbo.TBLCONTROL02 WHERE (ID_TABLA = 32)),'1','S', @COSTO_PROM_INI,@COSTO_PROM_FIN, ")
                query_minve.Append("   @COSTO_PROM_GRAL,'N',0)")
                Dim comando_minve As New SqlCommand(query_minve.ToString, sql_con)
                comando_minve.Parameters.AddWithValue("@CVE_ART", dt_p.Rows(index)(1))
                comando_minve.Parameters.AddWithValue("@ALMACEN", dt_e.Rows(0)(2))
                comando_minve.Parameters.AddWithValue("@FECHA_DOCU", Convert.ToDateTime(dt_e.Rows(0)(5)))
                comando_minve.Parameters.AddWithValue("@REFER", CVE_DOC)
                comando_minve.Parameters.AddWithValue("@CLAVE_CLPV", dt_e.Rows(0)(0))
                comando_minve.Parameters.AddWithValue("@CANT", cant_insertar)
                comando_minve.Parameters.AddWithValue("@COSTO", dt_p.Rows(index)(20))
                comando_minve.Parameters.AddWithValue("@UNI_VENTA", dt_p.Rows(index)(0))
                If dt_p.Rows(index)(22) = "S" Then
                    comando_minve.Parameters.AddWithValue("@E_LTPD", correlativo_lote)
                Else
                    comando_minve.Parameters.AddWithValue("@E_LTPD", 0)
                End If

                comando_minve.Parameters.AddWithValue("@FACTOR_CON", dt_p.Rows(index)(3))
                comando_minve.Parameters.AddWithValue("@FECHAELAB", Convert.ToDateTime(dt_e.Rows(0)(5)))
                comando_minve.Parameters.AddWithValue("@COSTO_PROM_INI", costo_prom_viejo)
                comando_minve.Parameters.AddWithValue("@COSTO_PROM_FIN", costo_prom_nuevo)
                comando_minve.Parameters.AddWithValue("@COSTO_PROM_GRAL", costo_prom_nuevo)
                comando_minve.Transaction = mi_transaccion
                comando_minve.ExecuteNonQuery()

                Dim query_num_mov_minve As New StringBuilder
                query_num_mov_minve.Append("UPDATE [SAE60Empre02].[dbo].[TBLCONTROL02] ")
                query_num_mov_minve.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                query_num_mov_minve.Append("WHERE ([ID_TABLA] = 44)")
                Dim comando_num_mov_minve As New SqlCommand(query_num_mov_minve.ToString, sql_con)
                comando_num_mov_minve.Transaction = mi_transaccion
                comando_num_mov_minve.ExecuteNonQuery()

                Dim query_upd_folio_minve As New StringBuilder
                query_upd_folio_minve.Append("UPDATE SAE60EMPRE02.dbo.TBLCONTROL02 ")
                query_upd_folio_minve.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                query_upd_folio_minve.Append("WHERE (ID_TABLA = 32) ")
                Dim comando_upd_folio_minve As New SqlCommand(query_upd_folio_minve.ToString, sql_con)
                comando_upd_folio_minve.Transaction = mi_transaccion
                comando_upd_folio_minve.ExecuteNonQuery()
            Next

            'fin del for

            Dim query_paga_m As New StringBuilder
            query_paga_m.Append("INSERT INTO [SAE60Empre02].[dbo].[PAGA_M02] ")
            query_paga_m.Append("   ([CVE_PROV],[REFER],[NUM_CARGO],[NUM_CPTO],[CVE_OBS] ")
            query_paga_m.Append("   ,[NO_FACTURA],[DOCTO],[IMPORTE],[FECHA_APLI],[FECHA_VENC],[AFEC_COI] ")
            query_paga_m.Append("   ,[NUM_MONED],[TCAMBIO],[IMPMON_EXT],[FECHAELAB],[TIPO_MOV] ")
            query_paga_m.Append("   ,[SIGNO],[USUARIO],[STATUS]) ")
            query_paga_m.Append("VALUES ")
            query_paga_m.Append("   (@CVE_PROV, @REFER, 1, 1, 0, @NO_FACTURA, ")
            query_paga_m.Append("   @DOCTO,@IMPORTE,@FECHA_APLI, @FECHA_VENC, 'A',1, 1, ")
            query_paga_m.Append("   @IMPMON_EXT,@FECHAELAB, 'C', 1, ")
            query_paga_m.Append("   @USUARIO, 'A')")
            Dim comando_paga_m As New SqlCommand(query_paga_m.ToString, sql_con)
            comando_paga_m.Parameters.AddWithValue("@CVE_PROV", dt_e.Rows(0)(0))
            comando_paga_m.Parameters.AddWithValue("@REFER", CVE_DOC)
            comando_paga_m.Parameters.AddWithValue("@DOCTO", CVE_DOC)
            comando_paga_m.Parameters.AddWithValue("@NO_FACTURA", dt_e.Rows(0)(3))
            comando_paga_m.Parameters.AddWithValue("@IMPORTE", dt_e.Rows(0)(10))
            comando_paga_m.Parameters.AddWithValue("@FECHA_APLI", Convert.ToDateTime(dt_e.Rows(0)(5)))
            comando_paga_m.Parameters.AddWithValue("@FECHA_VENC", Convert.ToDateTime(dt_e.Rows(0)(5)).AddDays(dias_cred))
            comando_paga_m.Parameters.AddWithValue("@IMPMON_EXT", dt_e.Rows(0)(10))
            comando_paga_m.Parameters.AddWithValue("@FECHAELAB", Convert.ToDateTime(dt_e.Rows(0)(5)))
            comando_paga_m.Parameters.AddWithValue("@USUARIO", 0)
            comando_paga_m.Transaction = mi_transaccion
            comando_paga_m.ExecuteNonQuery()

            Dim query_upd_prov As New StringBuilder
            query_upd_prov.Append("UPDATE [SAE60Empre02].[dbo].[PROV02] ")
            query_upd_prov.Append("SET [ULT_COMPD] = @ULT_COMPD ")
            query_upd_prov.Append(",[ULT_COMPM] =@ULT_COMPM ")
            query_upd_prov.Append(",[ULT_COMPF] =@ULT_COMPF ")
            query_upd_prov.Append(",[SALDO] = SALDO + @SALDO ")
            query_upd_prov.Append("WHERE([CLAVE] = @CLAVE)")
            Dim comando_upd_prov As New SqlCommand(query_upd_prov.ToString, sql_con)
            comando_upd_prov.Parameters.AddWithValue("@ULT_COMPD", CVE_DOC)
            comando_upd_prov.Parameters.AddWithValue("@ULT_COMPM", dt_e.Rows(0)(10))
            comando_upd_prov.Parameters.AddWithValue("@ULT_COMPF", Convert.ToDateTime(dt_e.Rows(0)(5)))
            comando_upd_prov.Parameters.AddWithValue("@SALDO", dt_e.Rows(0)(10))
            comando_upd_prov.Parameters.AddWithValue("@CLAVE", dt_e.Rows(0)(0))
            comando_upd_prov.Transaction = mi_transaccion
            comando_upd_prov.ExecuteNonQuery()

            Dim query_cve_docto_upd As New StringBuilder
            query_cve_docto_upd.Append("UPDATE [SAE60Empre02].[dbo].[FOLIOSC02] ")
            query_cve_docto_upd.Append("SET [ULT_DOC] = ULT_DOC + 1 , ")
            query_cve_docto_upd.Append("[FECH_ULT_DOC] = @FECH_ULT_DOC ")
            query_cve_docto_upd.Append("WHERE (TIP_DOC = 'c') AND (SERIE = @SERIE)")
            Dim comando_cve_docto_upd As New SqlCommand(query_cve_docto_upd.ToString, sql_con)
            comando_cve_docto_upd.Parameters.AddWithValue("@FECH_ULT_DOC", Convert.ToDateTime(dt_e.Rows(0)(5)))
            comando_cve_docto_upd.Parameters.AddWithValue("@SERIE", serie)
            comando_cve_docto_upd.Transaction = mi_transaccion
            comando_cve_docto_upd.ExecuteNonQuery()

            Dim conexion_bita As New cls_bitacora_reporteador
            conexion_bita.RegistraBitacora(Now, usuario, "Ingreso de Compra Cargill SR Agro", "COMPRAS", _
                                      "Fecha: " + Convert.ToDateTime(dt_e.Rows(0)(5)) + " Numero de Compra SAE: " + CVE_DOC + _
                                      " Numero de Compra Rep:" + CVE_COMPRA + " almacen:" + dt_e.Rows(0)(2))

            mi_transaccion.Commit()
            sql_con.Close()
            Return "correcto"
        Catch ex As Exception
            mi_transaccion.Rollback()
            sql_con.Close()
            Dim tamaño As Integer = Convert.ToString(ex.StackTrace).Length
            Dim posicion As Integer = InStrRev(Convert.ToString(ex.StackTrace), "línea") - 1
            Dim inicial As Integer = tamaño - posicion
            Dim linea_error As String = Convert.ToString(ex.StackTrace).Substring(tamaño - inicial, inicial)
            Return (ex.Message + " --> " + linea_error)
        End Try
    End Function

    Public Function modificar_compras_CARGILL(ByVal dt_e As DataTable, ByVal dt_p As DataTable, ByVal CVE_COMPRA As String) As String
        Dim con_sql As New SqlConnection(conexion.CadenaSQL)
        Dim mi_transaccion As SqlTransaction
        con_sql.Open()
        mi_transaccion = con_sql.BeginTransaction

        Try
            Dim query_e_local As New StringBuilder
            query_e_local.Append("UPDATE [tactical_discount_sragro].[dbo].[nd_compras_e] ")
            query_e_local.Append("SET [REF_PROV] = @REF_PROV,[FECHA] = @FECHA,[DESCUENTO_POR] = @DESCUENTO_POR,[SUB_TOTAL] = @SUB_TOTAL ")
            query_e_local.Append(",[DESCUENTO_VAL] = @DESCUENTO_VAL,[ISV_VAL] = @ISV_VAL,[TOTAL] = @TOTAL,[ESTADO] = @ESTADO ")
            query_e_local.Append(",[SUBTOTAL_MOST] = @SUBTOTAL_MOST,[DESC_MOST] = @DESC_MOST,[ISV_MOST] = @ISV_MOST,[TOTAL_MOST] = @TOTAL_MOST ")
            query_e_local.Append(",[FLETE] = @FLETE, [FECHA_FACTURA] = @FECHA_FACTURA, [ISV_FLETE] = @ISV_FLETE, [TOT_FLETE] = @TOT_FLETE ")
            query_e_local.Append("WHERE([CVE_COMPRA] = @CVE_COMPRA)")

            Dim comando_e_local As New SqlCommand(query_e_local.ToString, con_sql)
            comando_e_local.Parameters.AddWithValue("@CVE_COMPRA", CVE_COMPRA)
            comando_e_local.Parameters.AddWithValue("@REF_PROV", dt_e.Rows(0)(3))
            comando_e_local.Parameters.AddWithValue("@FECHA", Convert.ToDateTime(dt_e.Rows(0)(5)))
            comando_e_local.Parameters.AddWithValue("@DESCUENTO_POR", dt_e.Rows(0)(6))
            comando_e_local.Parameters.AddWithValue("@SUB_TOTAL", dt_e.Rows(0)(7))
            comando_e_local.Parameters.AddWithValue("@DESCUENTO_VAL", dt_e.Rows(0)(8))
            comando_e_local.Parameters.AddWithValue("@ISV_VAL", dt_e.Rows(0)(9))
            comando_e_local.Parameters.AddWithValue("@TOTAL", dt_e.Rows(0)(10))
            comando_e_local.Parameters.AddWithValue("@ESTADO", dt_e.Rows(0)(11))
            comando_e_local.Parameters.AddWithValue("@SUBTOTAL_MOST", dt_e.Rows(0)(12))
            comando_e_local.Parameters.AddWithValue("@DESC_MOST", dt_e.Rows(0)(13))
            comando_e_local.Parameters.AddWithValue("@ISV_MOST", dt_e.Rows(0)(14))
            comando_e_local.Parameters.AddWithValue("@TOTAL_MOST", dt_e.Rows(0)(15))
            comando_e_local.Parameters.AddWithValue("@FLETE", dt_e.Rows(0)(16))
            comando_e_local.Parameters.AddWithValue("@FECHA_FACTURA", Convert.ToDateTime(dt_e.Rows(0)(18)))

            comando_e_local.Parameters.AddWithValue("@ISV_FLETE", dt_e.Rows(0)(19))
            comando_e_local.Parameters.AddWithValue("@TOT_FLETE", dt_e.Rows(0)(20))

            comando_e_local.Transaction = mi_transaccion
            comando_e_local.ExecuteNonQuery()

            Dim query_e_local2 As New StringBuilder
            query_e_local2.Append("DELETE FROM [tactical_discount_sragro].[dbo].[nd_compras_p] ")
            query_e_local2.Append("WHERE CVE_COMPRA = @CVE_COMPRA")
            Dim comando_e_local2 As New SqlCommand(query_e_local2.ToString, con_sql)
            comando_e_local2.Parameters.AddWithValue("@CVE_COMPRA", CVE_COMPRA)
            comando_e_local2.Transaction = mi_transaccion
            comando_e_local2.ExecuteNonQuery()

            For index As Integer = 0 To dt_p.Rows.Count - 1
                Dim query_p_local As New StringBuilder
                query_p_local.Append("INSERT INTO [tactical_discount_sragro].[dbo].[nd_compras_p] ")
                query_p_local.Append("([CVE_COMPRA],[NUM_PART],[UNI],[CVE_ART],[PRODUCTO] ")
                query_p_local.Append(",[FACT_CONV],[CANTIDAD],[PRECIO_NEG],[PRECIO_FINAL] ")
                query_p_local.Append(",[DESC_PROD],[ISV_PROD],[SUB_TOTAL],[DESCUENTO] ")
                query_p_local.Append(",[ISV],[TOTAL_PARTIDA],[PRECIO_INSERTAR],[AJUSTE], ")
                query_p_local.Append(" [SUBTOTAL_MOST],[DESC_MOST],[ISV_MOST],[TOTAL_MOST],[PRECIO_NETO],[PESO],[CON_LOTE], [PORC_PP], [DESCUENTO_PP], [DESCUENTO_PP_MOSTR]) ")
                query_p_local.Append("VALUES ")
                query_p_local.Append("(@CVE_COMPRA,@NUM_PART,@UNI,@CVE_ART,@PRODUCTO, ")
                query_p_local.Append("@FACT_CONV,@CANTIDAD,@PRECIO_NEG,@PRECIO_FINAL, ")
                query_p_local.Append("@DESC_PROD,@ISV_PROD,@SUB_TOTAL,@DESCUENTO, ")
                query_p_local.Append("@ISV,@TOTAL_PARTIDA,@PRECIO_INSERTAR,@AJUSTE, ")
                query_p_local.Append("@SUBTOTAL_MOST,@DESC_MOST,@ISV_MOST,@TOTAL_MOST,@PRECIO_NETO,@PESO,@CON_LOTE, @PORC_PP, @DESCUENTO_PP, @DESCUENTO_PP_MOSTR ) ")
                Dim comando_p_local As New SqlCommand(query_p_local.ToString, con_sql)

                comando_p_local.Parameters.AddWithValue("@CVE_COMPRA", CVE_COMPRA)
                comando_p_local.Parameters.AddWithValue("@NUM_PART", index + 1)
                comando_p_local.Parameters.AddWithValue("@UNI", dt_p.Rows(index)(0))
                comando_p_local.Parameters.AddWithValue("@CVE_ART", dt_p.Rows(index)(1))
                comando_p_local.Parameters.AddWithValue("@PRODUCTO", dt_p.Rows(index)(2))
                comando_p_local.Parameters.AddWithValue("@FACT_CONV", dt_p.Rows(index)(3))
                comando_p_local.Parameters.AddWithValue("@CANTIDAD", Convert.ToDouble(dt_p.Rows(index)(4)))
                comando_p_local.Parameters.AddWithValue("@PRECIO_NEG", dt_p.Rows(index)(5))
                comando_p_local.Parameters.AddWithValue("@PRECIO_FINAL", dt_p.Rows(index)(6))
                comando_p_local.Parameters.AddWithValue("@DESC_PROD", dt_p.Rows(index)(7))
                comando_p_local.Parameters.AddWithValue("@ISV_PROD", dt_p.Rows(index)(8))
                comando_p_local.Parameters.AddWithValue("@SUB_TOTAL", Convert.ToDouble(dt_p.Rows(index)(9)))
                comando_p_local.Parameters.AddWithValue("@DESCUENTO", Convert.ToDouble(dt_p.Rows(index)(10)))
                comando_p_local.Parameters.AddWithValue("@ISV", Convert.ToDouble(dt_p.Rows(index)(11)))
                comando_p_local.Parameters.AddWithValue("@TOTAL_PARTIDA", Convert.ToDouble(dt_p.Rows(index)(12)))
                comando_p_local.Parameters.AddWithValue("@PRECIO_INSERTAR", dt_p.Rows(index)(13))
                comando_p_local.Parameters.AddWithValue("@AJUSTE", dt_p.Rows(index)(14))
                comando_p_local.Parameters.AddWithValue("@SUBTOTAL_MOST", dt_p.Rows(index)(16))
                comando_p_local.Parameters.AddWithValue("@DESC_MOST", dt_p.Rows(index)(17))
                comando_p_local.Parameters.AddWithValue("@ISV_MOST", dt_p.Rows(index)(18))
                comando_p_local.Parameters.AddWithValue("@TOTAL_MOST", dt_p.Rows(index)(19))
                comando_p_local.Parameters.AddWithValue("@PRECIO_NETO", dt_p.Rows(index)(20))
                comando_p_local.Parameters.AddWithValue("@PESO", dt_p.Rows(index)(21))
                comando_p_local.Parameters.AddWithValue("@CON_LOTE", dt_p.Rows(index)(22))

                comando_p_local.Parameters.AddWithValue("@PORC_PP", dt_p.Rows(index)(23))
                comando_p_local.Parameters.AddWithValue("@DESCUENTO_PP", dt_p.Rows(index)(24))
                comando_p_local.Parameters.AddWithValue("@DESCUENTO_PP_MOSTR", dt_p.Rows(index)(25))

                comando_p_local.Transaction = mi_transaccion
                comando_p_local.ExecuteNonQuery()
            Next
            mi_transaccion.Commit()
            con_sql.Close()
            Return "correcto"
        Catch ex As Exception
            mi_transaccion.Rollback()
            con_sql.Close()
            Dim tamaño As Integer = Convert.ToString(ex.StackTrace).Length
            Dim posicion As Integer = InStrRev(Convert.ToString(ex.StackTrace), "línea") - 1
            Dim inicial As Integer = tamaño - posicion
            Dim linea_error As String = Convert.ToString(ex.StackTrace).Substring(tamaño - inicial, inicial)
            Return (ex.Message + " --> " + linea_error)
        End Try
    End Function

    Public Function resumen_debitosycreditos(ByVal FECHA_INI As Date, ByVal FECHA_FIN As Date, ByVal CVE_PROVEEDOR As String, ByVal TIPO As String) As DataTable
        Dim conexion_sql As New SqlConnection(conexion.CadenaSQL)
        conexion_sql.Open()
        Dim micomando As New SqlCommand("rptn_resumen_creditos_debitos", conexion_sql)
        micomando.CommandType = CommandType.StoredProcedure
        micomando.Parameters.AddWithValue("@FECHA_INI", FECHA_INI)
        micomando.Parameters.AddWithValue("@FECHA_FIN", FECHA_FIN)
        micomando.Parameters.AddWithValue("@CVE_PROVEEDOR", CVE_PROVEEDOR)
        micomando.Parameters.AddWithValue("@TIPO", TIPO)

        Dim dt As New DataTable
        Dim adaptador As New SqlDataAdapter(micomando)
        adaptador.Fill(dt)

        conexion_sql.Close()
        Return dt
    End Function

    Public Function lista_formato_balanceados(ByVal PRODUCTOS As String)
        Dim query As New StringBuilder
        Dim con_sql As New SqlConnection(conexion.CadenaSQL)
        con_sql.Open()
        query.Append("SELECT IV.CVE_ART, '', IV.PESO ,IV.DESCR, '' AS CANTIDAD, ISNULL(IV_CL.CAMPLIB3,'') AS LINEA ")
        query.Append("FROM SAE60Empre02.dbo.INVE02 IV INNER JOIN SAE60Empre02.dbo.INVE_CLIB02 IV_CL ON ")
        query.Append("	IV.CVE_ART = IV_CL.CVE_PROD WHERE IV.CVE_ART IN (" + PRODUCTOS + ")  ")

        Dim comando As New SqlCommand(query.ToString, con_sql)
        Dim dt As New DataTable
        Dim adaptador As New SqlDataAdapter(comando)
        adaptador.Fill(dt)

        con_sql.Close()
        Return dt
    End Function

  
    Public Function dias_inventario(ByVal CVE_ART As String, ByVal FECHA As Date, ByVal ALMACEN As Integer)
        Dim query As New StringBuilder
        Dim con_sql As New SqlConnection(conexion.CadenaSQL)
        con_sql.Open()
        query.Append("SELECT C.DIV AS [DIAS DE INVENTARIO ACTUAL] FROM (  ")
        query.Append(" SELECT B.CODIGO,B.EXISTENCIA, (CASE WHEN B.DIVI >0 THEN ((ROUND((B.SEMA/B.DIVI),0)/6)) ELSE 0 END) AS DIV  ")
        query.Append(" FROM( SELECT T.CODIGO, ROUND(T.EXISTENCIA,2,0) AS EXISTENCIA, ISNULL((ISNULL(T1.S1,0) + ISNULL(T2.S2,0)  ")
        query.Append(" + ISNULL(T3.S3,0)+ISNULL(T4.S4,0)),0) AS SEMA, ISNULL((CASE WHEN (ISNULL(COUNT(T1.S1),0)+ISNULL(COUNT(T2.S2),0) ")
        query.Append(" + ISNULL(COUNT(T3.S3),0)+ISNULL(COUNT(T4.S4),0)) <> 0 THEN ((ISNULL(COUNT(T1.S1),0)+ISNULL(COUNT(T2.S2),0) +  ")
        query.Append(" ISNULL(COUNT(T3.S3),0)+ISNULL(COUNT(T4.S4),0))) END),0)AS DIVI FROM ((SELECT INVE02.CVE_ART  AS CODIGO,  ")
        query.Append("MULT02.EXIST AS EXISTENCIA FROM SAE60Empre02.dbo.INVE02 LEFT JOIN SAE60Empre02.dbo.PRVPROD02 ON  ")
        query.Append("INVE02.CVE_ART =PRVPROD02.CVE_ART LEFT JOIN SAE60Empre02.dbo.MULT02 ON INVE02.CVE_ART = MULT02.CVE_ART  ")
        query.Append("WHERE MULT02.CVE_ALM = @ALMACEN) AS T LEFT JOIN (SELECT CVE_ART, SUM(CASE WHEN CVE_CPTO >=51 THEN MINVE02.CANT  ")
        query.Append("ELSE MINVE02.CANT*-1 END) AS S1 FROM SAE60Empre02.dbo.MINVE02 WHERE CVE_CPTO IN (2,4,51,56) AND  ")
        query.Append("SAE60Empre02.dbo.MINVE02.FECHA_DOCU BETWEEN convert(datetime, DATEADD ( day, -27 ,  @FECHA), 120)  ")
        query.Append("AND convert(datetime, DATEADD ( day, -21 ,  @FECHA), 120) AND ALMACEN = @ALMACEN GROUP BY CVE_ART ) AS T1  ")
        query.Append("ON T.CODIGO = T1.CVE_ART LEFT JOIN (SELECT CVE_ART, SUM(CASE WHEN CVE_CPTO >=51 THEN MINVE02.CANT  ")
        query.Append("ELSE MINVE02.CANT*-1 END) AS S2 FROM SAE60Empre02.dbo.MINVE02 WHERE CVE_CPTO IN (2,4,51,56) AND MINVE02.FECHA_DOCU BETWEEN  ")
        query.Append("convert(datetime, DATEADD ( day, -20 ,  @FECHA), 120) AND convert(datetime, DATEADD ( day, -14 ,  @FECHA), 120) AND  ")
        query.Append("ALMACEN = @ALMACEN GROUP BY CVE_ART) AS T2 ON T.CODIGO = T2.CVE_ART LEFT JOIN (SELECT CVE_ART, SUM(CASE WHEN CVE_CPTO >=51  ")
        query.Append("THEN MINVE02.CANT ELSE MINVE02.CANT*-1 END) AS S3 FROM SAE60Empre02.dbo.MINVE02 WHERE CVE_CPTO IN (2,4,51,56) AND  ")
        query.Append("MINVE02.FECHA_DOCU BETWEEN  convert(datetime, DATEADD ( day, -13 , @FECHA), 120) AND convert(datetime, DATEADD  ")
        query.Append("( day, -7 ,  @FECHA), 120) AND ALMACEN = @ALMACEN GROUP BY CVE_ART) AS T3 ON T.CODIGO = T3.CVE_ART	LEFT JOIN  ")
        query.Append("(SELECT CVE_ART, SUM(CASE WHEN CVE_CPTO >=51 THEN MINVE02.CANT ELSE MINVE02.CANT*-1 END) AS S4 FROM  SAE60Empre02.dbo.MINVE02  ")
        query.Append("WHERE CVE_CPTO IN (2,4,51,56) AND MINVE02.FECHA_DOCU BETWEEN  convert(datetime, DATEADD ( day, -6 ,  @FECHA), 120)  ")
        query.Append(" AND @FECHA AND ALMACEN = @ALMACEN GROUP BY CVE_ART) AS T4 ON T.CODIGO = T4.CVE_ART)  ")
        query.Append(" GROUP BY T.CODIGO,T.EXISTENCIA,T1.S1,T2.S2,T3.S3,T4.S4) B  ")
        query.Append(") C ")
        query.Append("WHERE CODIGO = @CVE_ART")

        Dim comando As New SqlCommand(query.ToString, con_sql)
        Dim dt As New DataTable
        Dim adaptador As New SqlDataAdapter(comando)
        comando.Parameters.AddWithValue("@CVE_ART", CVE_ART)
        comando.Parameters.AddWithValue("@FECHA", FECHA)
        comando.Parameters.AddWithValue("@ALMACEN", ALMACEN)
        adaptador.Fill(dt)
        con_sql.Close()

        Return dt.Rows(0)(0)

    End Function

    Public Function lista_devoluciones_compras_nacionales(ByVal FECHA_INI As Date, ByVal FECHA_FIN As Date) As DataTable
        Dim dt As New DataTable
        Dim sql_con As New SqlConnection(conexion.CadenaSQL)
        sql_con.Open()
        Dim query As New StringBuilder
        query.Append("SELECT CVE_DEVO AS CODIGO, CVE_PROVEEDOR AS 'CLAVE PROVEEDOR', PROVEEDOR AS 'NOMBRE DEL PROVEEDOR', ALMACEN, REF_PROV AS FACTURA, RFC, FECHA, ")
        query.Append(" DESCUENTO_POR AS '%DESCUENTO', SUB_TOTAL, DESCUENTO_VAL AS DESCUENTO, ISV_VAL AS ISV, TOTAL, ESTADO, N_FACTURA_SAE, ")
        query.Append(" SUBTOTAL_MOST, DES_MOST, ISV_MOST, TOTAL_MOST, FLETE, LOTE, F_VENCIMIENTO, CVE_COMPRA_REP AS 'COMPRA REPORTEADOR' ")
        query.Append("FROM  [tactical_discount_sragro].[dbo].nd_dev_compra_e ")
        query.Append("WHERE FECHA >= @FECHA_INI AND FECHA <= @FECHA_FIN ")

        Dim comando As New SqlCommand(query.ToString, sql_con)
        comando.Parameters.AddWithValue("@FECHA_INI", FECHA_INI)
        comando.Parameters.AddWithValue("@FECHA_FIN", FECHA_FIN)
        Dim adaptador As New SqlDataAdapter(comando)
        adaptador.Fill(dt)
        sql_con.Close()
        Return dt
    End Function

    Public Function lista_devoluciones_importaciones(ByVal FECHA_INI As Date, ByVal FECHA_FIN As Date) As DataTable
        Dim dt As New DataTable
        Dim sql_con As New SqlConnection(conexion.CadenaSQL)
        sql_con.Open()
        Dim query As New StringBuilder
        query.Append("SELECT CVE_COMPRA AS CODIGO, CVE_PROVEEDOR AS 'CLAVE PROVEEDOR', PROVEEDOR AS 'NOMBRE DEL PROVEEDOR', ")
        query.Append("ALMACEN, REF_PROV AS FACTURA, RFC, FECHA, DESCUENTO_POR AS '%DESCUENTO', SUB_TOTAL, DESCUENTO_VAL ")
        query.Append(" AS DESCUENTO, ISV_VAL AS ISV, TOTAL, ESTADO, N_FACTURA_SAE, FLETE, LOTE  FROM  [tactical_discount_sragro].[dbo].nd_dev_importaciones_e  ")
        query.Append("WHERE FECHA >= @FECHA_INI AND FECHA <= @FECHA_FIN ")

        Dim comando As New SqlCommand(query.ToString, sql_con)
        comando.Parameters.AddWithValue("@FECHA_INI", FECHA_INI)
        comando.Parameters.AddWithValue("@FECHA_FIN", FECHA_FIN)
        Dim adaptador As New SqlDataAdapter(comando)
        adaptador.Fill(dt)
        sql_con.Close()
        Return dt
    End Function

    Public Function lista_importaciones_devolver(ByVal BUSCAR As String, ByVal TIPO As String) As DataTable
        Dim dt As New DataTable
        Dim sql_con As New SqlConnection(conexion.CadenaSQL)
        sql_con.Open()
        Dim query As New StringBuilder

        If TIPO = "Codigo" Then
            query.Append("SELECT CVE_COMPRA AS COMPRA, CVE_PROVEEDOR AS 'CLAVE PROVEEDOR', PROVEEDOR, ")
            query.Append("REF_PROV AS 'FACTURA', ALMACEN,RFC, FECHA, DESCUENTO_POR, SUB_TOTAL, DESCUENTO_VAL,  ")
            query.Append("ISV_VAL, TOTAL, ESTADO, N_FACTURA_SAE, ISNULL(FLETE,0), ISNULL(LOTE,''), ISNULL(F_VENCIMIENTO,''), ")
            query.Append("ISNULL(ESTADO_COMPRA,''),TASA_CAMBIO, CLAVE_VESTA, OTRO_PROV  ")
            query.Append("FROM [tactical_discount_sragro].[dbo].nd_importaciones_e ")
            query.Append("WHERE  (CVE_COMPRA = @BUSCAR) AND (ESTADO_COMPRA IS NULL) ORDER BY FECHA DESC  ")
        ElseIf TIPO = "Descripcion" Then
            query.Append("SELECT CVE_COMPRA AS COMPRA, CVE_PROVEEDOR AS 'CLAVE PROVEEDOR', PROVEEDOR,  ")
            query.Append("REF_PROV AS 'FACTURA', ALMACEN,RFC, FECHA, DESCUENTO_POR, SUB_TOTAL, DESCUENTO_VAL,  ")
            query.Append("ISV_VAL, TOTAL, ESTADO, N_FACTURA_SAE, ISNULL(FLETE,0), ISNULL(LOTE,''), ISNULL(F_VENCIMIENTO,''), ")
            query.Append("ISNULL(ESTADO_COMPRA,''),TASA_CAMBIO, CLAVE_VESTA, OTRO_PROV   ")
            query.Append("FROM [tactical_discount_sragro].[dbo].nd_importaciones_e ")
            query.Append("WHERE  (PROVEEDOR LIKE '%' + @BUSCAR + '%') AND (ESTADO_COMPRA IS NULL) ORDER BY FECHA DESC")
        Else
            query.Append("SELECT CVE_COMPRA AS COMPRA, CVE_PROVEEDOR AS 'CLAVE PROVEEDOR', PROVEEDOR,  ")
            query.Append("REF_PROV AS 'FACTURA', ALMACEN,RFC, FECHA, DESCUENTO_POR, SUB_TOTAL, DESCUENTO_VAL,  ")
            query.Append("ISV_VAL, TOTAL, ESTADO, N_FACTURA_SAE, ISNULL(FLETE,0), ISNULL(LOTE,''), ISNULL(F_VENCIMIENTO,''), ")
            query.Append("ISNULL(ESTADO_COMPRA,''),TASA_CAMBIO, CLAVE_VESTA, OTRO_PROV   ")
            query.Append("FROM [tactical_discount_sragro].[dbo].nd_importaciones_e ")
            query.Append("WHERE  N_FACTURA_SAE = @BUSCAR AND (ESTADO_COMPRA IS NULL) ORDER BY FECHA DESC ")
        End If

        Dim comando As New SqlCommand(query.ToString, sql_con)
        comando.Parameters.AddWithValue("@BUSCAR", BUSCAR)
        Dim adaptador As New SqlDataAdapter(comando)
        adaptador.Fill(dt)
        sql_con.Close()
        Return dt
    End Function

    Public Function lista_Compras_devolver(ByVal BUSCAR As String, ByVal TIPO As String) As DataTable
        Dim dt As New DataTable
        Dim sql_con As New SqlConnection(conexion.CadenaSQL)
        sql_con.Open()
        Dim query As New StringBuilder

        If TIPO = "Codigo" Then
            query.Append("SELECT CVE_COMPRA AS COMPRA, CVE_PROVEEDOR AS 'CLAVE PROVEEDOR', PROVEEDOR, ")
            query.Append("       REF_PROV AS 'FACTURA', ALMACEN,RFC, FECHA, DESCUENTO_POR, SUB_TOTAL, DESCUENTO_VAL, ")
            query.Append("       ISV_VAL, TOTAL, ESTADO, N_FACTURA_SAE, SUBTOTAL_MOST, DESC_MOST, ISV_MOST, ")
            query.Append("       TOTAL_MOST, ISNULL(FLETE,0), ISNULL(LOTE,''), ISNULL(F_VENCIMIENTO,''), ISNULL(ESTADO_COMPRA,'') ")
            query.Append("FROM   [tactical_discount_sragro].[dbo].nd_compras_e ")
            query.Append("WHERE  (CVE_COMPRA = @BUSCAR) AND (ESTADO_COMPRA IS NULL) ORDER BY FECHA DESC ")
        ElseIf TIPO = "Descripcion" Then
            query.Append("SELECT CVE_COMPRA AS COMPRA, CVE_PROVEEDOR AS 'CLAVE PROVEEDOR', PROVEEDOR, ")
            query.Append("       REF_PROV AS 'FACTURA', ALMACEN,RFC, FECHA, DESCUENTO_POR, SUB_TOTAL, DESCUENTO_VAL, ")
            query.Append("       ISV_VAL, TOTAL, ESTADO, N_FACTURA_SAE, SUBTOTAL_MOST, DESC_MOST, ISV_MOST, ")
            query.Append("       TOTAL_MOST, ISNULL(FLETE,0), ISNULL(LOTE,''), ISNULL(F_VENCIMIENTO,''), ISNULL(ESTADO_COMPRA,'') ")
            query.Append("FROM   [tactical_discount_sragro].[dbo].nd_compras_e ")
            query.Append("WHERE  (PROVEEDOR LIKE '%' + @BUSCAR + '%') AND (ESTADO_COMPRA IS NULL) ORDER BY FECHA DESC ")
        Else
            query.Append("SELECT CVE_COMPRA AS COMPRA, CVE_PROVEEDOR AS 'CLAVE PROVEEDOR', PROVEEDOR, ")
            query.Append("       REF_PROV AS 'FACTURA', ALMACEN,RFC, FECHA, DESCUENTO_POR, SUB_TOTAL, DESCUENTO_VAL, ")
            query.Append("       ISV_VAL, TOTAL, ESTADO, N_FACTURA_SAE, SUBTOTAL_MOST, DESC_MOST, ISV_MOST, ")
            query.Append("       TOTAL_MOST, ISNULL(FLETE,0), ISNULL(LOTE,''), ISNULL(F_VENCIMIENTO,''), ISNULL(ESTADO_COMPRA,'') ")
            query.Append("FROM   [tactical_discount_sragro].[dbo].nd_compras_e ")
            query.Append("WHERE  N_FACTURA_SAE = @BUSCAR  AND (ESTADO_COMPRA IS NULL) ORDER BY FECHA DESC ")
        End If

        Dim comando As New SqlCommand(query.ToString, sql_con)
        comando.Parameters.AddWithValue("@BUSCAR", BUSCAR)
        Dim adaptador As New SqlDataAdapter(comando)
        adaptador.Fill(dt)
        sql_con.Close()
        Return dt
    End Function

    Public Function lista_partidas_devolver(ByVal CVE_COMPRA As String) As DataTable
        Dim dt As New DataTable
        Dim sql_con As New SqlConnection(conexion.CadenaSQL)
        sql_con.Open()
        Dim query As New StringBuilder
        query.Append("SELECT NUM_PART, UNI, P.CVE_ART, PRODUCTO, FACT_CONV AS 'FACTOR CONVERSION',CANTIDAD, CANTIDAD, ")
        query.Append("PRECIO_NEG AS 'PRECIO NEGOCIADO', PRECIO_FINAL AS 'PRECIO FINAL', DESC_PROD AS DESCUENTO, ISV_PROD AS ISV  ")
        query.Append(", P.SUB_TOTAL, DESCUENTO, ISV, TOTAL_PARTIDA AS TOTAL,PRECIO_INSERTAR, AJUSTE, ISNULL(P.SUBTOTAL_MOST,0), ")
        query.Append("ISNULL(P.DESC_MOST,0), ISNULL(P.ISV_MOST,0), ISNULL(P.TOTAL_MOST,0), ISNULL(PRECIO_NETO,0), ISNULL(P.PESO,0), ")
        query.Append("ISNULL(P.CON_LOTE,''), ISNULL(COSTO_PROM,0), ISNULL((SELECT E_LTPD FROM SAE60Empre02.dbo.PAR_COMPC02  ")
        query.Append("WHERE CVE_DOC = N_FACTURA_SAE COLLATE MODERN_SPANISH_CI_AS AND SAE60Empre02.dbo.PAR_COMPC02.CVE_ART = P.CVE_ART  ")
        query.Append("COLLATE MODERN_SPANISH_CI_AS AND SAE60Empre02.dbo.PAR_COMPC02.NUM_PAR = P.NUM_PART),0),ISNULL((SELECT NUM_MOV  ")
        query.Append("FROM SAE60Empre02.dbo.PAR_COMPC02 WHERE CVE_DOC = N_FACTURA_SAE COLLATE MODERN_SPANISH_CI_AS AND ")
        query.Append("SAE60Empre02.dbo.PAR_COMPC02.CVE_ART = P.CVE_ART COLLATE MODERN_SPANISH_CI_AS AND ")
        query.Append("SAE60Empre02.dbo.PAR_COMPC02.NUM_PAR = P.NUM_PART),0), AJUSTE ")
        query.Append("FROM  [tactical_discount_sragro].[dbo].nd_compras_p P INNER JOIN SAE60Empre02.dbo.INVE02 IV ON IV.CVE_ART = P.CVE_ART ")
        query.Append("COLLATE MODERN_SPANISH_CI_AS INNER JOIN [tactical_discount_sragro].[dbo].nd_compras_e C ON P.CVE_COMPRA = C.CVE_COMPRA ")
        query.Append(" WHERE (P.CVE_COMPRA = @CVE_COMPRA) ")

        Dim comando As New SqlCommand(query.ToString, sql_con)
        comando.Parameters.AddWithValue("@CVE_COMPRA", CVE_COMPRA)
        Dim adaptador As New SqlDataAdapter(comando)
        adaptador.Fill(dt)
        sql_con.Close()
        Return dt
    End Function

    Public Function guardar_devolucion_scompra(ByVal dt_encabezados As DataTable, ByVal dt_partidas As DataTable, _
                                                ByVal usuario As String, ByVal tipo_enlace As String) As String
        Dim mi_transaccion As SqlTransaction
        Dim sql_con As New SqlConnection(conexion.CadenaSQL)
        sql_con.Open()
        mi_transaccion = sql_con.BeginTransaction
        Dim valida_inventario As Boolean = True
        Dim codigos_bajos As String = "Existencias insuficientes en los codigo: "
        Try
            For index As Integer = 0 To dt_partidas.Rows.Count - 1

                Dim cant_insertar As Double = 0
                If dt_partidas.Rows(index)(1) = "cj" Then
                    cant_insertar = Convert.ToDouble(dt_partidas.Rows(index)(4)) * dt_partidas.Rows(index)(5)
                ElseIf dt_partidas.Rows(index)(1) = "pz" Then
                    cant_insertar = Convert.ToDouble(dt_partidas.Rows(index)(5))
                End If

                Dim query_consulta_mult As New StringBuilder
                query_consulta_mult.Append("SELECT EXIST FROM SAE60EMPRE02.dbo.MULT02 WHERE (CVE_ART = @CVE_ART) AND (CVE_ALM = @CVE_ALM) ")
                Dim comando_consulta_mult As New SqlCommand(query_consulta_mult.ToString, sql_con)
                comando_consulta_mult.Parameters.AddWithValue("@CVE_ART", dt_partidas.Rows(index)(2))
                comando_consulta_mult.Parameters.AddWithValue("@CVE_ALM", dt_encabezados.Rows(0)(2))
                comando_consulta_mult.Transaction = mi_transaccion
                Dim dt_exist_mult As New DataTable
                Dim adaptador_consulta_mult As New SqlDataAdapter(comando_consulta_mult)
                adaptador_consulta_mult.Fill(dt_exist_mult)

                If cant_insertar > dt_exist_mult.Rows(0)(0) Then
                    valida_inventario = False
                    codigos_bajos += dt_partidas.Rows(index)(2) + vbNewLine
                End If
            Next

            If valida_inventario = False Then
                Return codigos_bajos
            Else
                Dim query_codigo As New StringBuilder
                query_codigo.Append("SELECT FOLIO + CONVERT(VARCHAR, ULT_DOC + 1) AS CLAVE,FOLIO,SERIE ")
                query_codigo.Append("FROM [tactical_discount_sragro].[dbo].nd_folios ")
                query_codigo.Append("WHERE (NUM_ALMA = @ALMACEN) AND (TIPO = 'DEV')")
                Dim comando_codigo As New SqlCommand(query_codigo.ToString, sql_con)
                comando_codigo.Parameters.AddWithValue("@ALMACEN", dt_encabezados.Rows(0)(2))
                comando_codigo.Transaction = mi_transaccion
                Dim dt As New DataTable
                Dim adaptador_codigo As New SqlDataAdapter(comando_codigo)
                adaptador_codigo.Fill(dt)
                Dim CVE_COMPRA As String = ""
                CVE_COMPRA = dt.Rows(0)(0)
                Dim serie_local As String = ""
                serie_local = dt.Rows(0)(2)

                Dim query_cve_docto As New StringBuilder
                query_cve_docto.Append("SELECT SERIE, ULT_DOC ")
                query_cve_docto.Append("FROM SAE60EMPRE02.dbo.FOLIOSC02 ")
                query_cve_docto.Append("WHERE (TIP_DOC = 'd') AND (SERIE = @SERIE) ")
                Dim comando_cve_docto As New SqlCommand(query_cve_docto.ToString, sql_con)
                comando_cve_docto.Parameters.AddWithValue("@SERIE", serie_local)
                comando_cve_docto.Transaction = mi_transaccion
                Dim adaptador_cve_docto As New SqlDataAdapter(comando_cve_docto)
                Dim dt_cve_docto As New DataTable
                adaptador_cve_docto.Fill(dt_cve_docto)
                Dim CVE_DOC As String = ""
                Dim serie As String = ""
                Dim folio As Integer
                serie = dt_cve_docto.Rows(0)(0)
                folio = dt_cve_docto.Rows(0)(1) + 1
                CVE_DOC = serie & folio

                Dim query_e_local As New StringBuilder
                query_e_local.Append("INSERT INTO [tactical_discount_sragro].[dbo].[nd_dev_compra_e] ")
                query_e_local.Append("       ([CVE_DEVO],[CVE_PROVEEDOR],[PROVEEDOR],[ALMACEN],[REF_PROV] ,[RFC],[FECHA], ")
                query_e_local.Append("       [DESCUENTO_POR],[SUB_TOTAL],[DESCUENTO_VAL] ,[ISV_VAL],[TOTAL],[ESTADO], ")
                query_e_local.Append("       [N_FACTURA_SAE],[SUBTOTAL_MOST] ,[DES_MOST],[ISV_MOST],[TOTAL_MOST],[FLETE], ")
                query_e_local.Append("       [LOTE],[F_VENCIMIENTO],[CVE_COMPRA_REP]) ")
                query_e_local.Append(" VALUES ")
                query_e_local.Append("       (@CVE_DEVO,@CVE_PROVEEDOR,@PROVEEDOR,@ALMACEN,@REF_PROV ,@RFC,@FECHA,@DESCUENTO_POR, ")
                query_e_local.Append("       @SUB_TOTAL,@DESCUENTO_VAL,@ISV_VAL ,@TOTAL,@ESTADO,@N_FACTURA_SAE,@SUBTOTAL_MOST, ")
                query_e_local.Append("       @DESC_MOST,@ISV_MOST ,@TOTAL_MOST,@FLETE,@LOTE,@F_VENCIMIENTO,@CVE_COMPRA_REP) ")

                Dim comando_e_local As New SqlCommand(query_e_local.ToString, sql_con)
                comando_e_local.Parameters.AddWithValue("@CVE_DEVO", CVE_COMPRA)
                comando_e_local.Parameters.AddWithValue("@CVE_PROVEEDOR", dt_encabezados.Rows(0)(0))
                comando_e_local.Parameters.AddWithValue("@PROVEEDOR", dt_encabezados.Rows(0)(1))
                comando_e_local.Parameters.AddWithValue("@ALMACEN ", dt_encabezados.Rows(0)(2))
                comando_e_local.Parameters.AddWithValue("@REF_PROV", dt_encabezados.Rows(0)(3))
                comando_e_local.Parameters.AddWithValue("@RFC", dt_encabezados.Rows(0)(4))
                comando_e_local.Parameters.AddWithValue("@FECHA", Convert.ToDateTime(dt_encabezados.Rows(0)(5)))
                comando_e_local.Parameters.AddWithValue("@DESCUENTO_POR", dt_encabezados.Rows(0)(6))
                comando_e_local.Parameters.AddWithValue("@SUB_TOTAL", dt_encabezados.Rows(0)(7))
                comando_e_local.Parameters.AddWithValue("@DESCUENTO_VAL", dt_encabezados.Rows(0)(8))
                comando_e_local.Parameters.AddWithValue("@ISV_VAL", dt_encabezados.Rows(0)(9))
                comando_e_local.Parameters.AddWithValue("@TOTAL", dt_encabezados.Rows(0)(10))
                comando_e_local.Parameters.AddWithValue("@ESTADO", "ENVIADA")
                comando_e_local.Parameters.AddWithValue("@N_FACTURA_SAE", CVE_DOC)
                comando_e_local.Parameters.AddWithValue("@SUBTOTAL_MOST", dt_encabezados.Rows(0)(11))
                comando_e_local.Parameters.AddWithValue("@DESC_MOST", dt_encabezados.Rows(0)(12))
                comando_e_local.Parameters.AddWithValue("@ISV_MOST", dt_encabezados.Rows(0)(13))
                comando_e_local.Parameters.AddWithValue("@TOTAL_MOST", dt_encabezados.Rows(0)(14))
                comando_e_local.Parameters.AddWithValue("@FLETE", dt_encabezados.Rows(0)(15))
                comando_e_local.Parameters.AddWithValue("@LOTE", dt_encabezados.Rows(0)(16))
                comando_e_local.Parameters.AddWithValue("@F_VENCIMIENTO", Convert.ToDateTime(dt_encabezados.Rows(0)(17)))
                comando_e_local.Parameters.AddWithValue("@CVE_COMPRA_REP", dt_encabezados.Rows(0)(18))
                comando_e_local.Transaction = mi_transaccion
                comando_e_local.ExecuteNonQuery()

                Dim query_upd_compra As New StringBuilder
                query_upd_compra.Append("UPDATE [tactical_discount_sragro].[dbo].[nd_compras_e] ")
                query_upd_compra.Append(" SET [ESTADO_COMPRA] = 'DEVUELTA' ")
                query_upd_compra.Append("WHERE [CVE_COMPRA] = @CVE_DEVO ")
                Dim comando_upd_compra As New SqlCommand(query_upd_compra.ToString, sql_con)
                comando_upd_compra.Parameters.AddWithValue("@CVE_DEVO", dt_encabezados.Rows(0)(18))
                comando_upd_compra.Transaction = mi_transaccion
                comando_upd_compra.ExecuteNonQuery()

                For index As Integer = 0 To dt_partidas.Rows.Count - 1
                    Dim query2 As New StringBuilder
                    query2.Append("INSERT INTO [tactical_discount_sragro].[dbo].[nd_dev_compra_p] ")
                    query2.Append("([CVE_DEVO],[NUM_PART],[UNI],[CVE_ART],[PRODUCTO],[FACT_CONV],[CANTIDAD],[PRECIO_NEG], [PRECIO_FINAL], ")
                    query2.Append("[DESC_PROD],[ISV_PROD],[SUB_TOTAL],[DESCUENTO],[ISV],[TOTAL_PARTIDA], [PRECIO_INSERTAR],[AJUSTE], ")
                    query2.Append("[SUBTOTAL_MOST],[DESC_MOST] ,[ISV_MOST],[TOTAL_MOST], [PRECIO_NETO],[PESO],[CON_LOTE]) ")
                    query2.Append("VALUES ")
                    query2.Append("(@CVE_DEVO,@NUM_PART,@UNI,@CVE_ART,@PRODUCTO,@FACT_CONV,@CANTIDAD,@PRECIO_NEG ,@PRECIO_FINAL,@DESC_PROD, ")
                    query2.Append("@ISV_PROD,@SUB_TOTAL,@DESCUENTO,@ISV,@TOTAL_PARTIDA ,@PRECIO_INSERTAR,@AJUSTE,@SUBTOTAL_MOST,@DESC_MOST, ")
                    query2.Append("@ISV_MOST,@TOTAL_MOST ,@PRECIO_NETO,@PESO,@CON_LOTE)")

                    Dim micomando2 As New SqlCommand(query2.ToString, sql_con)
                    micomando2.Parameters.AddWithValue("@CVE_DEVO", CVE_COMPRA)
                    micomando2.Parameters.AddWithValue("@NUM_PART", dt_partidas.Rows(index)(0))
                    micomando2.Parameters.AddWithValue("@UNI", dt_partidas.Rows(index)(1))
                    micomando2.Parameters.AddWithValue("@CVE_ART", dt_partidas.Rows(index)(2))
                    micomando2.Parameters.AddWithValue("@PRODUCTO", dt_partidas.Rows(index)(3))
                    micomando2.Parameters.AddWithValue("@FACT_CONV", dt_partidas.Rows(index)(4))
                    micomando2.Parameters.AddWithValue("@CANTIDAD", dt_partidas.Rows(index)(5))
                    micomando2.Parameters.AddWithValue("@PRECIO_NEG", dt_partidas.Rows(index)(6))
                    micomando2.Parameters.AddWithValue("@PRECIO_FINAL", dt_partidas.Rows(index)(7))
                    micomando2.Parameters.AddWithValue("@DESC_PROD", dt_partidas.Rows(index)(8))
                    micomando2.Parameters.AddWithValue("@ISV_PROD", dt_partidas.Rows(index)(9))
                    micomando2.Parameters.AddWithValue("@SUB_TOTAL", dt_partidas.Rows(index)(10))
                    micomando2.Parameters.AddWithValue("@DESCUENTO", dt_partidas.Rows(index)(11))
                    micomando2.Parameters.AddWithValue("@ISV", dt_partidas.Rows(index)(12))
                    micomando2.Parameters.AddWithValue("@TOTAL_PARTIDA", dt_partidas.Rows(index)(13))
                    micomando2.Parameters.AddWithValue("@PRECIO_INSERTAR", dt_partidas.Rows(index)(14))
                    micomando2.Parameters.AddWithValue("@AJUSTE", dt_partidas.Rows(index)(15))
                    micomando2.Parameters.AddWithValue("@SUBTOTAL_MOST", dt_partidas.Rows(index)(16))
                    micomando2.Parameters.AddWithValue("@DESC_MOST", dt_partidas.Rows(index)(17))
                    micomando2.Parameters.AddWithValue("@ISV_MOST", dt_partidas.Rows(index)(18))
                    micomando2.Parameters.AddWithValue("@TOTAL_MOST", dt_partidas.Rows(index)(19))
                    micomando2.Parameters.AddWithValue("@PRECIO_NETO", dt_partidas.Rows(index)(20))
                    micomando2.Parameters.AddWithValue("@PESO", dt_partidas.Rows(index)(21))
                    micomando2.Parameters.AddWithValue("@CON_LOTE", dt_partidas.Rows(index)(22))
                    micomando2.Transaction = mi_transaccion
                    micomando2.ExecuteNonQuery()
                Next

                Dim query_upd_codigo As New StringBuilder
                query_upd_codigo.Append("UPDATE [tactical_discount_sragro].[dbo].[nd_folios] ")
                query_upd_codigo.Append("SET [ULT_DOC] = ULT_DOC + 1 ")
                query_upd_codigo.Append("WHERE ([NUM_ALMA] = @NUM_ALMA And [TIPO] = 'DEV') ")
                Dim comando_upd_codigo As New SqlCommand(query_upd_codigo.ToString, sql_con)
                comando_upd_codigo.Parameters.AddWithValue("@NUM_ALMA", dt_encabezados.Rows(0)(2))
                comando_upd_codigo.Transaction = mi_transaccion
                comando_upd_codigo.ExecuteNonQuery()

                'registrar envio a SAE
                Dim query_compc As New StringBuilder
                query_compc.Append("INSERT INTO [SAE60Empre02].[dbo].[COMPD02] ")
                query_compc.Append("([TIP_DOC],[CVE_DOC],[CVE_CLPV],[STATUS],[SU_REFER] ,[FECHA_DOC],[FECHA_REC],[FECHA_PAG] ,[CAN_TOT], ")
                query_compc.Append("[IMP_TOT1], [IMP_TOT2], [IMP_TOT3], [IMP_TOT4], [DES_TOT], [DES_FIN], [TOT_IND], [OBS_COND],[CVE_OBS] , ")
                query_compc.Append("[NUM_ALMA], [ACT_CXP], [ACT_COI], [ENLAZADO], [TIP_DOC_E], [NUM_MONED], [TIPCAMB],[NUM_PAGOS],[FECHAELAB] , ")
                query_compc.Append("[SERIE],[FOLIO],[CTLPOL],[ESCFD],[CONTADO],[BLOQ],[DES_FIN_PORC],[DES_TOT_PORC],[IMPORTE],[TIP_DOC_ANT],[DOC_ANT]) ")
                query_compc.Append("VALUES ")
                query_compc.Append("('c', @CVE_DOC,@CVE_CLPV,'O',@SU_REFER,@FECHA_DOC ,@FECHA_REC,@FECHA_PAG,@CAN_TOT,0,0,0, @IMP_TOT4,@DES_TOT,0,0 , ")
                query_compc.Append("'',0,@NUM_ALMA,'S','N',@PARCIAL,'O',1,1,1,@FECHAELAB ,@SERIE,@FOLIO,0,'N','N','N',0 ,@DES_TOT_PORC,@IMPORTE,'','' )")
                Dim comando_compc As New SqlCommand(query_compc.ToString, sql_con)
                comando_compc.Parameters.AddWithValue("@CVE_DOC", CVE_DOC)
                comando_compc.Parameters.AddWithValue("@CVE_CLPV", dt_encabezados.Rows(0)(0))
                comando_compc.Parameters.AddWithValue("@SU_REFER", dt_encabezados.Rows(0)(3))
                comando_compc.Parameters.AddWithValue("@FECHA_DOC", Convert.ToDateTime(dt_encabezados.Rows(0)(5)))
                comando_compc.Parameters.AddWithValue("@FECHA_REC", Convert.ToDateTime(dt_encabezados.Rows(0)(5)))
                comando_compc.Parameters.AddWithValue("@FECHA_PAG", Convert.ToDateTime(dt_encabezados.Rows(0)(5)))
                comando_compc.Parameters.AddWithValue("@CAN_TOT", dt_encabezados.Rows(0)(7))
                comando_compc.Parameters.AddWithValue("@IMP_TOT4", dt_encabezados.Rows(0)(9))
                comando_compc.Parameters.AddWithValue("@DES_TOT", dt_encabezados.Rows(0)(8))
                comando_compc.Parameters.AddWithValue("@NUM_ALMA", dt_encabezados.Rows(0)(2))
                comando_compc.Parameters.AddWithValue("@FECHAELAB", Now.Date)
                comando_compc.Parameters.AddWithValue("@SERIE", serie)
                comando_compc.Parameters.AddWithValue("@FOLIO", folio)
                comando_compc.Parameters.AddWithValue("@DES_TOT_PORC", dt_encabezados.Rows(0)(6))
                comando_compc.Parameters.AddWithValue("@IMPORTE", dt_encabezados.Rows(0)(10))
                comando_compc.Parameters.AddWithValue("@PARCIAL", tipo_enlace)
                comando_compc.Transaction = mi_transaccion
                comando_compc.ExecuteNonQuery()

                Dim query_compc_c As New StringBuilder
                query_compc_c.Append("UPDATE [SAE60Empre02].[dbo].[COMPC02] ")
                query_compc_c.Append("SET [TIP_DOC_SIG] = @TIP_DOC_SIG, [DOC_SIG] = DOC_SIG, ")
                query_compc_c.Append("[ENLAZADO] = @ENLAZADO, [TIP_DOC_E] = @TIP_DOC_E ")
                query_compc_c.Append("WHERE [CVE_DOC] = @CVE_DOC ")
                Dim comando_compc_c As New SqlCommand(query_compc_c.ToString, sql_con)
                comando_compc_c.Parameters.AddWithValue("@CVE_DOC", dt_encabezados.Rows(0)(19))
                comando_compc_c.Parameters.AddWithValue("@TIP_DOC_SIG", "d")
                comando_compc_c.Parameters.AddWithValue("@DOC_SIG", CVE_DOC)
                comando_compc_c.Parameters.AddWithValue("@ENLAZADO", tipo_enlace)
                comando_compc_c.Parameters.AddWithValue("@TIP_DOC_E", "d")
                comando_compc_c.Transaction = mi_transaccion
                comando_compc_c.ExecuteNonQuery()

                Dim query_compc_clib As New StringBuilder
                query_compc_clib.Append("INSERT INTO [SAE60Empre02].[dbo].[COMPD_CLIB02] ")
                query_compc_clib.Append(" ([CLAVE_DOC]) ")
                query_compc_clib.Append("VALUES (@CLAVE_DOC)")
                Dim comando_comp_clib As New SqlCommand(query_compc_clib.ToString, sql_con)
                comando_comp_clib.Parameters.AddWithValue("CLAVE_DOC", CVE_DOC)
                comando_comp_clib.Transaction = mi_transaccion
                comando_comp_clib.ExecuteNonQuery()

                'inicio del for
                For index As Integer = 0 To dt_partidas.Rows.Count - 1
                    Dim query_doctosigc As New StringBuilder
                    query_doctosigc.Append("INSERT INTO [SAE60Empre02].[dbo].[DOCTOSIGC02] ")
                    query_doctosigc.Append("([TIP_DOC],[CVE_DOC],[ANT_SIG],[TIP_DOC_E], [CVE_DOC_E],[PARTIDA],[PART_E],[CANT_E]) ")
                    query_doctosigc.Append(" VALUES ")
                    query_doctosigc.Append(" ('c',@CVE_DOC,'S','d', @CVE_DOC_E,@PARTIDA,@PART_E,@CANT_E)")
                    Dim comando_doctosigc As New SqlCommand(query_doctosigc.ToString, sql_con)
                    comando_doctosigc.Parameters.AddWithValue("@CVE_DOC", dt_encabezados.Rows(0)(19))
                    comando_doctosigc.Parameters.AddWithValue("@CVE_DOC_E", CVE_DOC)
                    comando_doctosigc.Parameters.AddWithValue("@PARTIDA", dt_partidas.Rows(index)(0))
                    comando_doctosigc.Parameters.AddWithValue("@PART_E", index)
                    comando_doctosigc.Parameters.AddWithValue("@CANT_E", dt_partidas.Rows(index)(5))
                    comando_doctosigc.Transaction = mi_transaccion
                    comando_doctosigc.ExecuteNonQuery()

                    Dim query_select_LOTE As New StringBuilder
                    query_select_LOTE.Append(" SELECT REG_LTPD, PXRS FROM SAE60Empre02.dbo.ENLACE_LTPD02 WHERE E_LTPD = @LOTE")
                    Dim cmd_select_LOTE As New SqlCommand(query_select_LOTE.ToString, sql_con)
                    cmd_select_LOTE.Parameters.AddWithValue("@LOTE", dt_partidas.Rows(index)(24))
                    cmd_select_LOTE.Transaction = mi_transaccion
                    Dim adaptador_select_LOTE As New SqlDataAdapter(cmd_select_LOTE)
                    Dim dt_select_LOTE As New DataTable
                    adaptador_select_LOTE.Fill(dt_select_LOTE)

                    'PENDIENTE DE CARGAR EL CORRELATIVO DEL LOTE
                    Dim query_par_compc As New StringBuilder
                    query_par_compc.Append("INSERT INTO [SAE60Empre02].[dbo].[PAR_COMPD02] ")
                    query_par_compc.Append("   ([CVE_DOC],[NUM_PAR],[CVE_ART],[CANT],[PXR],[PREC],[COST] ,[IMPU1],[IMPU2], [IMPU3], ")
                    query_par_compc.Append("    [IMPU4],[IMP1APLA],[IMP2APLA],[IMP3APLA],[IMP4APLA],[TOTIMP1],[TOTIMP2], [TOTIMP3], ")
                    query_par_compc.Append("    [TOTIMP4],[DESCU],[ACT_INV],[TIP_CAM],[UNI_VENTA],[TIPO_ELEM],[TIPO_PROD], [CVE_OBS], ")
                    query_par_compc.Append("    [REG_SERIE],[E_LTPD],[FACTCONV],[COST_DEV],[NUM_ALM],[MINDIRECTO], [NUM_MOV],[TOT_PARTIDA]) ")
                    query_par_compc.Append("VALUES ")
                    query_par_compc.Append("    (@CVE_DOC,@NUM_PAR,@CVE_ART, @CANT, @PXR, ISNULL((SELECT SAE60Empre02.dbo.PRECIO_X_PROD02.PRECIO ")
                    query_par_compc.Append("    FROM SAE60Empre02.dbo.INVE02 INNER JOIN SAE60Empre02.dbo.PRECIO_X_PROD02 ON ")
                    query_par_compc.Append("    SAE60Empre02.dbo.INVE02.CVE_ART = SAE60Empre02.dbo.PRECIO_X_PROD02.CVE_ART ")
                    query_par_compc.Append("    WHERE (SAE60Empre02.dbo.PRECIO_X_PROD02.CVE_PRECIO = 1) AND (SAE60Empre02.dbo.INVE02.CVE_ART = @CVE_ART) ")
                    query_par_compc.Append("    ),0), @COST, 0, 0, 0, @IMPU4, 0, 0, 0, 0, 0, 0, 0, @TOTIMP4, @DESCU, 'S', 1, @UNI_VENTA,'N', 'P', 0,0, ")
                    query_par_compc.Append("    @E_LTPD,@FACTCONV, @COST_DEV, @NUM_ALM, 0, (SELECT ULT_CVE + 1 FROM SAE60EMPRE02.dbo.TBLCONTROL02 ")
                    query_par_compc.Append("    WHERE (ID_TABLA = 44)),@TOT_PARTIDA)")

                    Dim comando_par_compc As New SqlCommand(query_par_compc.ToString, sql_con)
                    comando_par_compc.Parameters.AddWithValue("@CVE_DOC", CVE_DOC)
                    comando_par_compc.Parameters.AddWithValue("@NUM_PAR", index + 1)
                    comando_par_compc.Parameters.AddWithValue("@CVE_ART", dt_partidas.Rows(index)(2))
                    comando_par_compc.Parameters.AddWithValue("@CANT", Convert.ToDouble(dt_partidas.Rows(index)(5)))

                    Dim cant_insertar As Double = 0
                    Dim costo_insertar As Double = 0
                    Dim factor_conversion As Integer = 0
                    If dt_partidas.Rows(index)(1) = "cj" Then
                        cant_insertar = Convert.ToDouble(dt_partidas.Rows(index)(4)) * dt_partidas.Rows(index)(5)
                        costo_insertar = dt_partidas.Rows(index)(14) * dt_partidas.Rows(index)(4)
                        factor_conversion = dt_partidas.Rows(index)(4)
                    ElseIf dt_partidas.Rows(index)(1) = "pz" Then
                        cant_insertar = Convert.ToDouble(dt_partidas.Rows(index)(5))
                        costo_insertar = dt_partidas.Rows(index)(14)
                        factor_conversion = 1
                    End If

                    comando_par_compc.Parameters.AddWithValue("@PXR", cant_insertar)
                    comando_par_compc.Parameters.AddWithValue("@COST", costo_insertar)
                    comando_par_compc.Parameters.AddWithValue("@IMPU4", dt_partidas.Rows(index)(9))
                    comando_par_compc.Parameters.AddWithValue("@TOTIMP4", Convert.ToDouble(dt_partidas.Rows(index)(12)))
                    comando_par_compc.Parameters.AddWithValue("@DESCU", 0) 'dt_p.Rows(index)(7))
                    comando_par_compc.Parameters.AddWithValue("@UNI_VENTA", dt_partidas.Rows(index)(1))

                    If dt_partidas.Rows(index)(20) = "S" Then
                        comando_par_compc.Parameters.AddWithValue("@E_LTPD", dt_partidas.Rows(index)(24))
                    Else
                        comando_par_compc.Parameters.AddWithValue("@E_LTPD", 0)
                    End If

                    comando_par_compc.Parameters.AddWithValue("@FACTCONV", factor_conversion)
                    comando_par_compc.Parameters.AddWithValue("@COST_DEV", dt_partidas.Rows(index)(14) * dt_partidas.Rows(index)(4))
                    comando_par_compc.Parameters.AddWithValue("@NUM_ALM", dt_encabezados.Rows(0)(2))
                    comando_par_compc.Parameters.AddWithValue("@TOT_PARTIDA", Convert.ToDouble(dt_partidas.Rows(index)(13)) - Convert.ToDouble(dt_partidas.Rows(index)(12)))
                    comando_par_compc.Transaction = mi_transaccion
                    comando_par_compc.ExecuteNonQuery()

                    Dim query_par_comp_clib As New StringBuilder
                    query_par_comp_clib.Append("INSERT INTO [SAE60Empre02].[dbo].[PAR_COMPD_CLIB02] ")
                    query_par_comp_clib.Append("   ([CLAVE_DOC],[NUM_PART]) ")
                    query_par_comp_clib.Append("VALUES ")
                    query_par_comp_clib.Append("   (@CLAVE_DOC,@NUM_PART) ")
                    Dim comando_par_comp_clib As New SqlCommand(query_par_comp_clib.ToString, sql_con)
                    comando_par_comp_clib.Parameters.AddWithValue("@CLAVE_DOC", CVE_DOC)
                    comando_par_comp_clib.Parameters.AddWithValue("@NUM_PART", index + 1)
                    comando_par_comp_clib.Transaction = mi_transaccion
                    comando_par_comp_clib.ExecuteNonQuery()

                    Dim query_costo_prom As New StringBuilder
                    query_costo_prom.Append("SELECT ISNULL(EXIST,0),ISNULL(COSTO_PROM,0) FROM SAE60EMPRE02.dbo.INVE02 WHERE CVE_ART = @CVE_ART")
                    Dim comando_costo_prom As New SqlCommand(query_costo_prom.ToString, sql_con)
                    comando_costo_prom.Parameters.AddWithValue("@CVE_ART", dt_partidas.Rows(index)(2))
                    comando_costo_prom.Transaction = mi_transaccion

                    Dim adaptador_costo As New SqlDataAdapter(comando_costo_prom)
                    Dim dt_costo_prom As New DataTable

                    Dim existencias_viejas As Double = 0, costo_prom_viejo As Double = 0
                    adaptador_costo.Fill(dt_costo_prom)
                    existencias_viejas = dt_costo_prom.Rows(0)(0)
                    costo_prom_viejo = dt_costo_prom.Rows(0)(1)

                    Dim costo_prom_nuevo As Double = 0
                    costo_prom_nuevo = ((existencias_viejas * costo_prom_viejo) - (cant_insertar * dt_partidas.Rows(index)(14))) / (existencias_viejas - cant_insertar)

                    Dim query_upd_inve As New StringBuilder
                    query_upd_inve.Append("UPDATE SAE60EMPRE02.dbo.INVE02 ")
                    query_upd_inve.Append("SET [EXIST] = (EXIST - @NUEVA_EXISTENCIA), ")
                    query_upd_inve.Append("FCH_ULTCOM = @FECHA_ULTCOM, COSTO_PROM = @COSTO_PROM, ULT_COSTO = @ULT_COSTO ")
                    query_upd_inve.Append("WHERE [CVE_ART] = @CVE_ART ")
                    Dim comando_upd_inve As New SqlCommand(query_upd_inve.ToString, sql_con)
                    comando_upd_inve.Parameters.AddWithValue("@NUEVA_EXISTENCIA", cant_insertar)
                    comando_upd_inve.Parameters.AddWithValue("@FECHA_ULTCOM", Now.Date)
                    comando_upd_inve.Parameters.AddWithValue("@COSTO_PROM", costo_prom_nuevo)
                    comando_upd_inve.Parameters.AddWithValue("@ULT_COSTO", dt_partidas.Rows(index)(14))
                    comando_upd_inve.Parameters.AddWithValue("@CVE_ART", dt_partidas.Rows(index)(2))
                    comando_upd_inve.Transaction = mi_transaccion
                    comando_upd_inve.ExecuteNonQuery()

                    Dim query_upd_mult As New StringBuilder
                    query_upd_mult.Append("UPDATE SAE60EMPRE02.dbo.MULT02 ")
                    query_upd_mult.Append("SET [EXIST] = (EXIST - @NUEVA_EXISTENCIA) ")
                    query_upd_mult.Append("WHERE  [CVE_ART] = @CVE_ART AND [CVE_ALM] = @CVE_ALM ")
                    Dim comando_upd_mult As New SqlCommand(query_upd_mult.ToString, sql_con)
                    comando_upd_mult.Parameters.AddWithValue("@NUEVA_EXISTENCIA", cant_insertar)
                    comando_upd_mult.Parameters.AddWithValue("@CVE_ART", dt_partidas.Rows(index)(2))
                    comando_upd_mult.Parameters.AddWithValue("@CVE_ALM", dt_encabezados.Rows(0)(2))
                    comando_upd_mult.Transaction = mi_transaccion
                    comando_upd_mult.ExecuteNonQuery()

                    If dt_partidas.Rows(index)(22) = "S" Then
                        Dim query_reg_lote As New StringBuilder
                        query_reg_lote.Append("SELECT (ULT_CVE + 1) AS ULT_CVE ")
                        query_reg_lote.Append("FROM SAE60EMPRE02.dbo.TBLCONTROL02 ")
                        query_reg_lote.Append("WHERE (ID_TABLA = 67) ")
                        Dim comando_reg_lote As New SqlCommand(query_reg_lote.ToString, sql_con)
                        comando_reg_lote.Transaction = mi_transaccion
                        Dim adaptador_reg_lote As New SqlDataAdapter(comando_reg_lote)
                        Dim dt_reg_lote As New DataTable
                        adaptador_reg_lote.Fill(dt_reg_lote)
                        Dim reg_lote As Integer
                        reg_lote = dt_reg_lote.Rows(0)(0)

                        Dim query_ltpd As New StringBuilder
                        query_ltpd.Append("UPDATE [SAE60Empre02].[dbo].[LTPD02] ")
                        query_ltpd.Append("SET [CANTIDAD] = [CANTIDAD] - @CANTIDAD ")
                        query_ltpd.Append("WHERE [CVE_ART] = @CVE_ART AND [CVE_ALM] = @CVE_ALM ")
                        query_ltpd.Append(" AND [REG_LTPD] = @REG_LTPD ")
                        Dim comando_ltpd As New SqlCommand(query_ltpd.ToString, sql_con)
                        comando_ltpd.Parameters.AddWithValue("@CVE_ART", dt_partidas.Rows(index)(2))
                        comando_ltpd.Parameters.AddWithValue("@CANTIDAD", cant_insertar)
                        comando_ltpd.Parameters.AddWithValue("@CVE_ALM", dt_encabezados.Rows(0)(2))
                        If dt_select_LOTE.Rows.Count > 0 Then
                            comando_ltpd.Parameters.AddWithValue("@REG_LTPD", dt_select_LOTE.Rows(0)(0))
                        Else
                            comando_ltpd.Parameters.AddWithValue("@REG_LTPD", 0)
                        End If

                        comando_ltpd.Transaction = mi_transaccion
                        comando_ltpd.ExecuteNonQuery()

                        Dim query_UPD_enlace_ltpd As New StringBuilder
                        query_UPD_enlace_ltpd.Append("UPDATE [SAE60Empre02].[dbo].[ENLACE_LTPD02] ")

                        If dt_select_LOTE.Rows.Count > 0 Then
                            If cant_insertar > dt_select_LOTE.Rows(0)(1) Then
                                query_UPD_enlace_ltpd.Append("SET [PXRS] = 0 ")
                            Else
                                query_UPD_enlace_ltpd.Append("SET [PXRS] = [PXRS] - @CANTIDAD ")
                            End If
                        Else
                            query_UPD_enlace_ltpd.Append("SET [PXRS] = [PXRS] - @CANTIDAD ")
                        End If
                        query_UPD_enlace_ltpd.Append("WHERE [E_LTPD] = @E_LTPD ")
                        Dim comando_UPD_enlace_ltpd As New SqlCommand(query_UPD_enlace_ltpd.ToString, sql_con)
                        comando_UPD_enlace_ltpd.Parameters.AddWithValue("@E_LTPD", dt_partidas.Rows(index)(24))
                        comando_UPD_enlace_ltpd.Parameters.AddWithValue("@CANTIDAD", cant_insertar)
                        comando_UPD_enlace_ltpd.Transaction = mi_transaccion
                        comando_UPD_enlace_ltpd.ExecuteNonQuery()

                        Dim query_enlace_ltpd As New StringBuilder
                        query_enlace_ltpd.Append("INSERT INTO [SAE60Empre02].[dbo].[ENLACE_LTPD02] ")
                        query_enlace_ltpd.Append("   ([E_LTPD],[REG_LTPD],[CANTIDAD],[PXRS]) ")
                        query_enlace_ltpd.Append("VALUES ")
                        query_enlace_ltpd.Append("   (@E_LTPD,@REG_LTPD, @CANTIDAD,@PXRS)")
                        Dim comando_enlace_ltpd As New SqlCommand(query_enlace_ltpd.ToString, sql_con)
                        comando_enlace_ltpd.Parameters.AddWithValue("@E_LTPD", reg_lote)
                        If dt_select_LOTE.Rows.Count > 0 Then
                            comando_enlace_ltpd.Parameters.AddWithValue("@REG_LTPD", dt_select_LOTE.Rows(0)(0))
                        Else
                            comando_enlace_ltpd.Parameters.AddWithValue("@REG_LTPD", 0)
                        End If
                        comando_enlace_ltpd.Parameters.AddWithValue("@CANTIDAD", cant_insertar)
                        comando_enlace_ltpd.Parameters.AddWithValue("@PXRS", cant_insertar)
                        comando_enlace_ltpd.Transaction = mi_transaccion
                        comando_enlace_ltpd.ExecuteNonQuery()

                        Dim query_upd_correlativo_lote As New StringBuilder
                        query_upd_correlativo_lote.Append("UPDATE [SAE60Empre02].[dbo].[TBLCONTROL02] ")
                        query_upd_correlativo_lote.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                        query_upd_correlativo_lote.Append("WHERE([ID_TABLA] = 67)")
                        Dim comando_upd_correlativo_lote As New SqlCommand(query_upd_correlativo_lote.ToString, sql_con)
                        comando_upd_correlativo_lote.Transaction = mi_transaccion
                        comando_upd_correlativo_lote.ExecuteNonQuery()
                    End If

                    Dim query_minve As New StringBuilder
                    query_minve.Append("INSERT INTO [SAE60Empre02].[dbo].[MINVE02] ")
                    query_minve.Append("   ([CVE_ART],[ALMACEN],[NUM_MOV],[CVE_CPTO],[FECHA_DOCU],[TIPO_DOC],[REFER],[CLAVE_CLPV],[VEND],[CANT],[CANT_COST] , ")
                    query_minve.Append("   [PRECIO],[COSTO],[REG_SERIE],[UNI_VENTA] ,[E_LTPD],[EXIST_G], [EXISTENCIA],[FACTOR_CON] ,[FECHAELAB], ")
                    query_minve.Append("   [CVE_FOLIO],[SIGNO],[COSTEADO],[COSTO_PROM_INI],[COSTO_PROM_FIN],[COSTO_PROM_GRAL],[DESDE_INVE],[MOV_ENLAZADO])  ")
                    query_minve.Append("VALUES ")
                    query_minve.Append("   (@CVE_ART, @ALMACEN,(SELECT ULT_CVE+1 FROM SAE60EMPRE02.dbo.TBLCONTROL02 WHERE (ID_TABLA = 44)),52,@FECHA_DOCU, ")
                    query_minve.Append("   'd', @REFER, @CLAVE_CLPV, '',@CANT, 0, 0, @COSTO, 0,@UNI_VENTA, @E_LTPD,ISNULL((SELECT EXIST FROM SAE60EMPRE02.dbo.INVE02 ")
                    query_minve.Append("    WHERE (CVE_ART = @CVE_ART)),0) , ((SELECT EXIST FROM SAE60EMPRE02.dbo.MULT02 WHERE (CVE_ART = @CVE_ART) AND CVE_ALM = @ALMACEN)), ")
                    query_minve.Append("    @FACTOR_CON, @FECHAELAB, (SELECT ULT_CVE+1 FROM SAE60EMPRE02.dbo.TBLCONTROL02 WHERE (ID_TABLA = 32)),'-1','S', @COSTO_PROM_INI, ")
                    query_minve.Append("    @COSTO_PROM_FIN, @COSTO_PROM_GRAL,'N',@MOV_ENLAZADO)")

                    Dim comando_minve As New SqlCommand(query_minve.ToString, sql_con)

                    comando_minve.Parameters.AddWithValue("@CVE_ART", dt_partidas.Rows(index)(2))
                    comando_minve.Parameters.AddWithValue("@ALMACEN", dt_encabezados.Rows(0)(2))
                    comando_minve.Parameters.AddWithValue("@FECHA_DOCU", Convert.ToDateTime(dt_encabezados.Rows(0)(5)))
                    comando_minve.Parameters.AddWithValue("@REFER", CVE_DOC)
                    comando_minve.Parameters.AddWithValue("@CLAVE_CLPV", dt_encabezados.Rows(0)(0))
                    comando_minve.Parameters.AddWithValue("@CANT", cant_insertar)
                    comando_minve.Parameters.AddWithValue("@COSTO", dt_partidas.Rows(index)(23))
                    comando_minve.Parameters.AddWithValue("@UNI_VENTA", dt_partidas.Rows(index)(1))
                    If dt_partidas.Rows(index)(22) = "S" Then
                        comando_minve.Parameters.AddWithValue("@E_LTPD", dt_partidas.Rows(index)(24))
                    Else
                        comando_minve.Parameters.AddWithValue("@E_LTPD", 0)
                    End If
                    comando_minve.Parameters.AddWithValue("@FACTOR_CON", factor_conversion)
                    comando_minve.Parameters.AddWithValue("@FECHAELAB", Now.Date)
                    comando_minve.Parameters.AddWithValue("@COSTO_PROM_INI", costo_prom_viejo)
                    comando_minve.Parameters.AddWithValue("@COSTO_PROM_FIN", costo_prom_nuevo)
                    comando_minve.Parameters.AddWithValue("@COSTO_PROM_GRAL", costo_prom_nuevo)
                    comando_minve.Parameters.AddWithValue("@MOV_ENLAZADO", dt_partidas.Rows(index)(25))
                    comando_minve.Transaction = mi_transaccion
                    comando_minve.ExecuteNonQuery()

                    Dim query_num_mov_minve As New StringBuilder
                    query_num_mov_minve.Append("UPDATE [SAE60Empre02].[dbo].[TBLCONTROL02] ")
                    query_num_mov_minve.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                    query_num_mov_minve.Append("WHERE ([ID_TABLA] = 44)")
                    Dim comando_num_mov_minve As New SqlCommand(query_num_mov_minve.ToString, sql_con)
                    comando_num_mov_minve.Transaction = mi_transaccion
                    comando_num_mov_minve.ExecuteNonQuery()

                    Dim query_upd_folio_minve As New StringBuilder
                    query_upd_folio_minve.Append("UPDATE SAE60EMPRE02.dbo.TBLCONTROL02 ")
                    query_upd_folio_minve.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                    query_upd_folio_minve.Append("WHERE (ID_TABLA = 32) ")
                    Dim comando_upd_folio_minve As New SqlCommand(query_upd_folio_minve.ToString, sql_con)
                    comando_upd_folio_minve.Transaction = mi_transaccion
                    comando_upd_folio_minve.ExecuteNonQuery()
                Next
                'fin del for
                Dim query_paga_m As New StringBuilder
                query_paga_m.Append("INSERT INTO [SAE60Empre02].[dbo].[PAGA_DET02] ")
                query_paga_m.Append("   ([CVE_PROV],[REFER],[NUM_CPTO],[NUM_CARGO],[ID_MOV],[CVE_OBS],[NO_FACTURA],[DOCTO], [IMPORTE],[FECHA_APLI], ")
                query_paga_m.Append("    [FECHA_VENC], [AFEC_COI], [NUM_MONED], [TCAMBIO], [IMPMON_EXT], [FECHAELAB],[TIPO_MOV] ,[SIGNO],[USUARIO], ")
                query_paga_m.Append("    [NO_PARTIDA]) VALUES ")
                query_paga_m.Append("   (@CVE_PROV, @REFER, 8, 1,1, 0, @NO_FACTURA, @DOCTO,@IMPORTE,@FECHA_APLI, @FECHA_VENC, ")
                query_paga_m.Append("   'A',1, 1, @IMPMON_EXT,@FECHAELAB, 'A', -1, @USUARIO,@NO_PARTIDA)")

                Dim comando_paga_m As New SqlCommand(query_paga_m.ToString, sql_con)
                comando_paga_m.Parameters.AddWithValue("@CVE_PROV", dt_encabezados.Rows(0)(0))
                comando_paga_m.Parameters.AddWithValue("@REFER", dt_encabezados.Rows(0)(19))
                comando_paga_m.Parameters.AddWithValue("@DOCTO", CVE_DOC)
                comando_paga_m.Parameters.AddWithValue("@NO_FACTURA", dt_encabezados.Rows(0)(3))
                comando_paga_m.Parameters.AddWithValue("@IMPORTE", dt_encabezados.Rows(0)(10))
                comando_paga_m.Parameters.AddWithValue("@FECHA_APLI", Convert.ToDateTime(dt_encabezados.Rows(0)(5)))
                comando_paga_m.Parameters.AddWithValue("@FECHA_VENC", Convert.ToDateTime(dt_encabezados.Rows(0)(17)))
                comando_paga_m.Parameters.AddWithValue("@IMPMON_EXT", dt_encabezados.Rows(0)(10))
                comando_paga_m.Parameters.AddWithValue("@FECHAELAB", Now.Date)
                comando_paga_m.Parameters.AddWithValue("@USUARIO", 0)
                comando_paga_m.Parameters.AddWithValue("@NO_PARTIDA", 1)
                comando_paga_m.Transaction = mi_transaccion
                comando_paga_m.ExecuteNonQuery()

                Dim query_upd_prov As New StringBuilder
                query_upd_prov.Append("UPDATE [SAE60Empre02].[dbo].[PROV02] SET [SALDO] = SALDO - @SALDO ")
                query_upd_prov.Append("WHERE([CLAVE] = @CLAVE)")
                Dim comando_upd_prov As New SqlCommand(query_upd_prov.ToString, sql_con)
                comando_upd_prov.Parameters.AddWithValue("@SALDO", dt_encabezados.Rows(0)(10))
                comando_upd_prov.Parameters.AddWithValue("@CLAVE", dt_encabezados.Rows(0)(0))
                comando_upd_prov.Transaction = mi_transaccion
                comando_upd_prov.ExecuteNonQuery()

                Dim query_cve_docto_upd As New StringBuilder
                query_cve_docto_upd.Append("UPDATE [SAE60Empre02].[dbo].[FOLIOSC02] ")
                query_cve_docto_upd.Append("SET [ULT_DOC] = ULT_DOC + 1 , ")
                query_cve_docto_upd.Append("[FECH_ULT_DOC] = @FECH_ULT_DOC ")
                query_cve_docto_upd.Append("WHERE (TIP_DOC = 'd') AND (SERIE = @SERIE)")
                Dim comando_cve_docto_upd As New SqlCommand(query_cve_docto_upd.ToString, sql_con)
                comando_cve_docto_upd.Parameters.AddWithValue("@FECH_ULT_DOC", Convert.ToDateTime(dt_encabezados.Rows(0)(5)))
                comando_cve_docto_upd.Parameters.AddWithValue("@SERIE", serie)
                comando_cve_docto_upd.Transaction = mi_transaccion
                comando_cve_docto_upd.ExecuteNonQuery()

                Dim query_ajuste As New StringBuilder
                query_ajuste.Append("SELECT ID_AJUSTE FROM nd_ajuste_e WHERE COMPRA = @COMPRA ")
                Dim comando_ajuste As New SqlCommand(query_ajuste.ToString, sql_con)
                comando_ajuste.Parameters.AddWithValue("@COMPRA", dt_encabezados.Rows(0)(18))
                comando_ajuste.Transaction = mi_transaccion
                Dim adaptador_ajuste As New SqlDataAdapter(comando_ajuste)
                Dim dt_ajuste As New DataTable
                adaptador_ajuste.Fill(dt_ajuste)

                For index As Integer = 0 To dt_ajuste.Rows.Count - 1
                    Dim query_elimina_ajustes As New StringBuilder
                    query_elimina_ajustes.Append("DELETE FROM [tactical_discount_sr_agro].[dbo].[nd_ajuste_e] WHERE ID_AJUSTE = @ID_AJUSTE")
                    Dim comando_elimina_ajuste As New SqlCommand(query_elimina_ajustes.ToString, sql_con)
                    comando_elimina_ajuste.Parameters.AddWithValue("@ID_AJUSTE", dt_ajuste.Rows(index)(0))
                    comando_elimina_ajuste.Transaction = mi_transaccion
                    comando_elimina_ajuste.ExecuteNonQuery()

                    Dim query_elimina_ajustes_partidas As New StringBuilder
                    query_elimina_ajustes_partidas.Append("DELETE FROM [tactical_discount_sr_agro].[dbo].[nd_ajuste_p] WHERE ID_AJUSTE = @ID_AJUSTE")
                    Dim comando_elimina_ajuste_partida As New SqlCommand(query_elimina_ajustes_partidas.ToString, sql_con)
                    comando_elimina_ajuste_partida.Parameters.AddWithValue("@ID_AJUSTE", dt_ajuste.Rows(index)(0))
                    comando_elimina_ajuste_partida.Transaction = mi_transaccion
                    comando_elimina_ajuste_partida.ExecuteNonQuery()
                Next

                Dim query_elimina_creditos As New StringBuilder
                query_elimina_creditos.Append("DELETE FROM [SAE60Empre02].[dbo].[PAGA_DET02] ")
                query_elimina_creditos.Append("WHERE  NUM_CPTO = 29 AND REFER = @REFER ")
                query_elimina_creditos.Append("AND USUARIO = 0 AND CVE_PROV = @CVE_PROV ")
                Dim comando_elimina_creditos As New SqlCommand(query_elimina_creditos.ToString, sql_con)
                comando_elimina_creditos.Parameters.AddWithValue("@REFER", dt_encabezados.Rows(0)(19))
                comando_elimina_creditos.Parameters.AddWithValue("@CVE_PROV", dt_encabezados.Rows(0)(0))
                comando_elimina_creditos.Transaction = mi_transaccion
                comando_elimina_creditos.ExecuteNonQuery()

                If tipo_enlace = "P" Then
                    Dim ajuste As String = ""
                    Dim debito As String = ""
                    For index As Integer = 0 To dt_partidas.Rows.Count - 1
                        If dt_partidas.Rows(index)(26) = "S" Then
                            ajuste = "S"
                        End If

                        If dt_partidas.Rows(index)(26) = "D" Then
                            debito = "D"
                        End If
                    Next

                    ' registra los debito por producto
                    If ajuste = "S" Then
                        Dim query_folio_ajuste As New StringBuilder
                        query_folio_ajuste.Append("SELECT FOLIO + CONVERT(VARCHAR, ULT_DOC + 1) AS ULT_DOC ")
                        query_folio_ajuste.Append("FROM nd_folios ")
                        query_folio_ajuste.Append("WHERE (TIPO = 'A') AND (NUM_ALMA = @ALMACEN)")
                        Dim comando_folio_ajuste As New SqlCommand(query_folio_ajuste.ToString, sql_con)
                        comando_folio_ajuste.Parameters.AddWithValue("@ALMACEN", dt_encabezados.Rows(0)(2))
                        comando_folio_ajuste.Transaction = mi_transaccion
                        Dim dt_folio_ajuste As New DataTable
                        Dim adaptador_folio_ajuste As New SqlDataAdapter(comando_folio_ajuste)
                        adaptador_folio_ajuste.Fill(dt_folio_ajuste)

                        Dim subtotal_ajuste_e As Double = 0, isv_ajuste_e As Double = 0, total_ajueste_e As Double = 0, descuento_ajuste_e As Double = 0
                        For index As Integer = 0 To dt_partidas.Rows.Count - 1
                            If dt_partidas.Rows(index)(26) = "S" Then
                                Dim query_ajuste_p As New StringBuilder
                                query_ajuste_p.Append("INSERT INTO [tactical_discount_sr_agro].[dbo].[nd_ajuste_p] ")
                                query_ajuste_p.Append("([ID_AJUSTE],[NUM_PART],[CVE_ART],[DESCRIPCION],[MOTIVO],[CANTIDAD], ")
                                query_ajuste_p.Append("[FECHA_INGRESO],[COSTO_ANTERIOR],[COSTO_ACTUAL],[AJUSTE],[UNI]) ")
                                query_ajuste_p.Append("VALUES ")
                                query_ajuste_p.Append("(@ID_AJUSTE,@NUM_PART,@CVE_ART,@DESCRIPCION,@MOTIVO,@CANTIDAD, ")
                                query_ajuste_p.Append("@FECHA_INGRESO,@COSTO_ANTERIOR,@COSTO_ACTUAL,@AJUSTE,@UNI)")
                                Dim comando_ajuste_p As New SqlCommand(query_ajuste_p.ToString, sql_con)
                                comando_ajuste_p.Parameters.AddWithValue("@ID_AJUSTE", dt_folio_ajuste.Rows(0)(0))
                                comando_ajuste_p.Parameters.AddWithValue("@NUM_PART", index + 1)
                                comando_ajuste_p.Parameters.AddWithValue("@CVE_ART", dt_partidas.Rows(index)(2))
                                comando_ajuste_p.Parameters.AddWithValue("@DESCRIPCION", dt_partidas.Rows(index)(3))
                                comando_ajuste_p.Parameters.AddWithValue("@MOTIVO", "AJUSTE DE PRECIO")
                                comando_ajuste_p.Parameters.AddWithValue("@CANTIDAD", dt_partidas.Rows(index)(5))
                                comando_ajuste_p.Parameters.AddWithValue("@FECHA_INGRESO", Convert.ToDateTime(dt_encabezados.Rows(0)(5)))
                                comando_ajuste_p.Parameters.AddWithValue("@COSTO_ANTERIOR", dt_partidas.Rows(index)(6))
                                comando_ajuste_p.Parameters.AddWithValue("@COSTO_ACTUAL", dt_partidas.Rows(index)(7))
                                Dim valor_ajuste As Double = 0

                                valor_ajuste = (Convert.ToDouble(dt_partidas.Rows(index)(5)) * Convert.ToDouble(dt_partidas.Rows(index)(7))) - _
                                                (Convert.ToDouble(dt_partidas.Rows(index)(5)) * Convert.ToDouble(dt_partidas.Rows(index)(6)))
                                If dt_partidas.Rows(index)(1) = "cj" Then
                                    valor_ajuste = valor_ajuste * Convert.ToDouble(dt_partidas.Rows(index)(4))
                                End If

                                comando_ajuste_p.Parameters.AddWithValue("@AJUSTE", valor_ajuste * -1)
                                comando_ajuste_p.Parameters.AddWithValue("@UNI", dt_partidas.Rows(index)(1))

                                subtotal_ajuste_e += valor_ajuste
                                descuento_ajuste_e += 0 'valor_ajuste * dt_p.Rows(index)(7) / 100
                                valor_ajuste = valor_ajuste - descuento_ajuste_e
                                isv_ajuste_e += valor_ajuste * dt_partidas.Rows(index)(9) / 100
                                comando_ajuste_p.Transaction = mi_transaccion
                                comando_ajuste_p.ExecuteNonQuery()
                            End If
                        Next
                        total_ajueste_e += subtotal_ajuste_e - descuento_ajuste_e + isv_ajuste_e

                        Dim query_ajuste_e As New StringBuilder
                        query_ajuste_e.Append("INSERT INTO [tactical_discount_sr_agro].[dbo].[nd_ajuste_e] ")
                        query_ajuste_e.Append("([ID_AJUSTE],[CVE_PROVEEDOR],[ALMACEN],[REF_PROV]")
                        query_ajuste_e.Append(",[FECHA],[N_FACTURA],[SUBTOTAL],[DESCUENTO],[ISV],[TOTAL],[COMPRA],[TIPO]) ")
                        query_ajuste_e.Append("VALUES ")
                        query_ajuste_e.Append("(@ID_AJUSTE,@CVE_PROVEEDOR,@ALMACEN,@REF_PROV,@FECHA, ")
                        query_ajuste_e.Append("@N_FACTURA,@SUBTOTAL,@DESCUENTO,@ISV,@TOTAL,@COMPRA,@TIPO)")
                        Dim comando_ajuste_e As New SqlCommand(query_ajuste_e.ToString, sql_con)
                        comando_ajuste_e.Parameters.AddWithValue("@ID_AJUSTE", dt_folio_ajuste.Rows(0)(0))
                        comando_ajuste_e.Parameters.AddWithValue("@CVE_PROVEEDOR", dt_encabezados.Rows(0)(0))
                        comando_ajuste_e.Parameters.AddWithValue("@ALMACEN", dt_encabezados.Rows(0)(2))
                        comando_ajuste_e.Parameters.AddWithValue("@REF_PROV", dt_encabezados.Rows(0)(3))
                        comando_ajuste_e.Parameters.AddWithValue("@FECHA", Convert.ToDateTime(dt_encabezados.Rows(0)(5)))
                        comando_ajuste_e.Parameters.AddWithValue("@N_FACTURA", dt_encabezados.Rows(0)(19))
                        comando_ajuste_e.Parameters.AddWithValue("@SUBTOTAL", subtotal_ajuste_e * -1)
                        comando_ajuste_e.Parameters.AddWithValue("@DESCUENTO", descuento_ajuste_e * -1)
                        comando_ajuste_e.Parameters.AddWithValue("@ISV", isv_ajuste_e * -1)
                        comando_ajuste_e.Parameters.AddWithValue("@TOTAL", total_ajueste_e * -1)
                        comando_ajuste_e.Parameters.AddWithValue("@COMPRA", dt_encabezados.Rows(0)(18))
                        comando_ajuste_e.Parameters.AddWithValue("@TIPO", "DEBITO")
                        comando_ajuste_e.Transaction = mi_transaccion
                        comando_ajuste_e.ExecuteNonQuery()

                        Dim query_upd_folio_ajuste As New StringBuilder
                        query_upd_folio_ajuste.Append("UPDATE [tactical_discount_sr_agro].[dbo].[nd_folios] ")
                        query_upd_folio_ajuste.Append("   SET [ULT_DOC] = ULT_DOC+1 ")
                        query_upd_folio_ajuste.Append("WHERE [NUM_ALMA] = @NUM_ALMA AND TIPO = 'A' ")
                        Dim comando_upd_folio_ajuste As New SqlCommand(query_upd_folio_ajuste.ToString, sql_con)
                        comando_upd_folio_ajuste.Parameters.AddWithValue("@NUM_ALMA", dt_encabezados.Rows(0)(2))
                        comando_upd_folio_ajuste.Transaction = mi_transaccion
                        comando_upd_folio_ajuste.ExecuteNonQuery()

                    End If
                    ' fn registra los debitos por producto

                    ' registra los creditos por producto
                    If debito = "D" Then
                        Dim query_folio_debito As New StringBuilder
                        query_folio_debito.Append("SELECT FOLIO + CONVERT(VARCHAR, ULT_DOC + 1) AS ULT_DOC ")
                        query_folio_debito.Append("FROM nd_folios ")
                        query_folio_debito.Append("WHERE (TIPO = 'D') AND (NUM_ALMA = @ALMACEN)")
                        Dim comando_folio_debito As New SqlCommand(query_folio_debito.ToString, sql_con)
                        comando_folio_debito.Parameters.AddWithValue("@ALMACEN", dt_encabezados.Rows(0)(2))
                        comando_folio_debito.Transaction = mi_transaccion
                        Dim dt_folio_debito As New DataTable
                        Dim adaptador_folio_debito As New SqlDataAdapter(comando_folio_debito)
                        adaptador_folio_debito.Fill(dt_folio_debito)

                        Dim subtotal_debito_e As Double = 0, isv_debito_e As Double = 0, total_debito_e As Double = 0, descuento_debito_e As Double = 0
                        For index As Integer = 0 To dt_partidas.Rows.Count - 1
                            If dt_partidas.Rows(index)(26) = "D" Then
                                Dim query_debito_p As New StringBuilder
                                query_debito_p.Append("INSERT INTO [tactical_discount_sr_agro].[dbo].[nd_ajuste_p] ")
                                query_debito_p.Append("([ID_AJUSTE],[NUM_PART],[CVE_ART],[DESCRIPCION],[MOTIVO],[CANTIDAD], ")
                                query_debito_p.Append("[FECHA_INGRESO],[COSTO_ANTERIOR],[COSTO_ACTUAL],[AJUSTE],[UNI]) ")
                                query_debito_p.Append("VALUES ")
                                query_debito_p.Append("(@ID_AJUSTE,@NUM_PART,@CVE_ART,@DESCRIPCION,@MOTIVO,@CANTIDAD, ")
                                query_debito_p.Append("@FECHA_INGRESO,@COSTO_ANTERIOR,@COSTO_ACTUAL,@AJUSTE,@UNI)")
                                Dim comando_debito_p As New SqlCommand(query_debito_p.ToString, sql_con)
                                comando_debito_p.Parameters.AddWithValue("@ID_AJUSTE", dt_folio_debito.Rows(0)(0))
                                comando_debito_p.Parameters.AddWithValue("@NUM_PART", index + 1)
                                comando_debito_p.Parameters.AddWithValue("@CVE_ART", dt_partidas.Rows(index)(2))
                                comando_debito_p.Parameters.AddWithValue("@DESCRIPCION", dt_partidas.Rows(index)(3))
                                comando_debito_p.Parameters.AddWithValue("@MOTIVO", "AJUSTE DE PRECIO")
                                comando_debito_p.Parameters.AddWithValue("@CANTIDAD", dt_partidas.Rows(index)(27) - dt_partidas.Rows(index)(5))
                                comando_debito_p.Parameters.AddWithValue("@FECHA_INGRESO", Convert.ToDateTime(dt_encabezados.Rows(0)(5)))
                                comando_debito_p.Parameters.AddWithValue("@COSTO_ANTERIOR", dt_partidas.Rows(index)(6))
                                comando_debito_p.Parameters.AddWithValue("@COSTO_ACTUAL", dt_partidas.Rows(index)(7))
                                Dim valor_ajuste As Double = 0
                                valor_ajuste = (dt_partidas.Rows(index)(27) - Convert.ToDouble(dt_partidas.Rows(index)(5)) * Convert.ToDouble(dt_partidas.Rows(index)(6))) - _
                                               (dt_partidas.Rows(index)(27) - Convert.ToDouble(dt_partidas.Rows(index)(5)) * Convert.ToDouble(dt_partidas.Rows(index)(7)))
                                If dt_partidas.Rows(index)(1) = "cj" Then
                                    valor_ajuste = valor_ajuste * Convert.ToDouble(dt_partidas.Rows(index)(4))
                                End If
                                comando_debito_p.Parameters.AddWithValue("@AJUSTE", Math.Abs(valor_ajuste))
                                comando_debito_p.Parameters.AddWithValue("@UNI", dt_partidas.Rows(index)(1))

                                subtotal_debito_e += valor_ajuste
                                descuento_debito_e += 0 'valor_ajuste * dt_p.Rows(index)(7) / 100
                                valor_ajuste = valor_ajuste - descuento_debito_e
                                isv_debito_e += valor_ajuste * dt_partidas.Rows(index)(9) / 100
                                comando_debito_p.Transaction = mi_transaccion
                                comando_debito_p.ExecuteNonQuery()
                            End If
                        Next
                        total_debito_e += subtotal_debito_e - descuento_debito_e + isv_debito_e

                        Dim query_debito_e As New StringBuilder
                        query_debito_e.Append("INSERT INTO [tactical_discount_sr_agro].[dbo].[nd_ajuste_e] ")
                        query_debito_e.Append("([ID_AJUSTE],[CVE_PROVEEDOR],[ALMACEN],[REF_PROV]")
                        query_debito_e.Append(",[FECHA],[N_FACTURA],[SUBTOTAL],[DESCUENTO],[ISV],[TOTAL],[COMPRA],[TIPO]) ")
                        query_debito_e.Append("VALUES ")
                        query_debito_e.Append("(@ID_AJUSTE,@CVE_PROVEEDOR,@ALMACEN,@REF_PROV,@FECHA, ")
                        query_debito_e.Append("@N_FACTURA,@SUBTOTAL,@DESCUENTO,@ISV,@TOTAL,@COMPRA,@TIPO)")
                        Dim comando_debito_e As New SqlCommand(query_debito_e.ToString, sql_con)
                        comando_debito_e.Parameters.AddWithValue("@ID_AJUSTE", dt_folio_debito.Rows(0)(0))
                        comando_debito_e.Parameters.AddWithValue("@CVE_PROVEEDOR", dt_encabezados.Rows(0)(0))
                        comando_debito_e.Parameters.AddWithValue("@ALMACEN", dt_encabezados.Rows(0)(2))
                        comando_debito_e.Parameters.AddWithValue("@REF_PROV", dt_encabezados.Rows(0)(3))
                        comando_debito_e.Parameters.AddWithValue("@FECHA", Convert.ToDateTime(dt_encabezados.Rows(0)(5)))
                        comando_debito_e.Parameters.AddWithValue("@N_FACTURA", dt_encabezados.Rows(0)(19))
                        comando_debito_e.Parameters.AddWithValue("@SUBTOTAL", Math.Abs(subtotal_debito_e))
                        comando_debito_e.Parameters.AddWithValue("@DESCUENTO", Math.Abs(descuento_debito_e))
                        comando_debito_e.Parameters.AddWithValue("@ISV", Math.Abs(isv_debito_e))
                        comando_debito_e.Parameters.AddWithValue("@TOTAL", Math.Abs(total_debito_e))
                        comando_debito_e.Parameters.AddWithValue("@COMPRA", dt_encabezados.Rows(0)(18))
                        comando_debito_e.Parameters.AddWithValue("@TIPO", "CREDITO")
                        comando_debito_e.Transaction = mi_transaccion
                        comando_debito_e.ExecuteNonQuery()

                        Dim query_upd_folio_ajuste As New StringBuilder
                        query_upd_folio_ajuste.Append("UPDATE [tactical_discount_sr_agro].[dbo].[nd_folios] ")
                        query_upd_folio_ajuste.Append("   SET [ULT_DOC] = ULT_DOC+1 ")
                        query_upd_folio_ajuste.Append("WHERE [NUM_ALMA] = @NUM_ALMA AND TIPO = 'D' ")
                        Dim comando_upd_folio_ajuste As New SqlCommand(query_upd_folio_ajuste.ToString, sql_con)
                        comando_upd_folio_ajuste.Parameters.AddWithValue("@NUM_ALMA", dt_encabezados.Rows(0)(2))
                        comando_upd_folio_ajuste.Transaction = mi_transaccion
                        comando_upd_folio_ajuste.ExecuteNonQuery()

                        Dim query_opaga As New StringBuilder
                        query_opaga.Append("INSERT INTO [SAE60Empre02].[dbo].[OPAGA02] ")
                        query_opaga.Append("([CVE_OBS],[STR_OBS]) ")
                        query_opaga.Append("VALUES ((SELECT ULT_CVE + 1 AS ULT_CVE FROM SAE60EMPRE02.dbo.TBLCONTROL02 WHERE (ID_TABLA = 21)),'NOTA DE CREDITO POR PRECIO MENOR DEL PROVEEDOR')")
                        Dim comando_opaga As New SqlCommand(query_opaga.ToString, sql_con)
                        comando_opaga.Transaction = mi_transaccion
                        comando_opaga.ExecuteNonQuery()

                        Dim query_paga_det As New StringBuilder
                        query_paga_det.Append("INSERT INTO [SAE60Empre02].[dbo].[PAGA_DET02] ")
                        query_paga_det.Append("([CVE_PROV],[REFER],[NUM_CPTO],[NUM_CARGO],[ID_MOV] ")
                        query_paga_det.Append(",[CVE_OBS],[NO_FACTURA],[DOCTO],[IMPORTE],[FECHA_APLI],[FECHA_VENC] ")
                        query_paga_det.Append(",[NUM_MONED],[TCAMBIO],[IMPMON_EXT],[FECHAELAB] ")
                        query_paga_det.Append(",[TIPO_MOV],[SIGNO],[USUARIO] ")
                        query_paga_det.Append(",[NO_PARTIDA]) ")
                        query_paga_det.Append("VALUES ")
                        query_paga_det.Append("(@CVE_PROV, @REFER, 29,1,1, (SELECT ULT_CVE + 1 AS ULT_CVE FROM SAE60EMPRE02.dbo.TBLCONTROL02 WHERE (ID_TABLA = 21)), ")
                        query_paga_det.Append("@NO_FACTURA, @DOCTO, @IMPORTE, @FECHA_APLI, @FECHA_VENC, 1, ")
                        query_paga_det.Append("1, @IMPMON_EXT, @FECHAELAB,'A', -1,0, 1) ")
                        Dim comando_paga_det As New SqlCommand(query_paga_det.ToString, sql_con)
                        comando_paga_det.Parameters.AddWithValue("@CVE_PROV", dt_encabezados.Rows(0)(0))
                        comando_paga_det.Parameters.AddWithValue("@REFER", dt_encabezados.Rows(0)(19))
                        comando_paga_det.Parameters.AddWithValue("@NO_FACTURA", dt_encabezados.Rows(0)(19))
                        comando_paga_det.Parameters.AddWithValue("@DOCTO", dt_encabezados.Rows(0)(19))
                        comando_paga_det.Parameters.AddWithValue("@IMPORTE", Math.Abs(total_debito_e))
                        comando_paga_det.Parameters.AddWithValue("@FECHA_APLI", Convert.ToDateTime(dt_encabezados.Rows(0)(5)))
                        comando_paga_det.Parameters.AddWithValue("@FECHA_VENC", Convert.ToDateTime(dt_encabezados.Rows(0)(17)))
                        comando_paga_det.Parameters.AddWithValue("@IMPMON_EXT", Math.Abs(total_debito_e))
                        comando_paga_det.Parameters.AddWithValue("@FECHAELAB", Convert.ToDateTime(dt_encabezados.Rows(0)(5)))
                        comando_paga_det.Transaction = mi_transaccion
                        comando_paga_det.ExecuteNonQuery()

                        Dim query_upd_paga_det As New StringBuilder
                        query_upd_paga_det.Append("UPDATE [SAE60Empre02].[dbo].[TBLCONTROL02] ")
                        query_upd_paga_det.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                        query_upd_paga_det.Append("WHERE ([ID_TABLA] = 21)")
                        Dim comando_upd_paga_det As New SqlCommand(query_upd_paga_det.ToString, sql_con)
                        comando_upd_paga_det.Transaction = mi_transaccion
                        comando_upd_paga_det.ExecuteNonQuery()
                    End If
                    ' fin registra los creditos por producto

                End If

                Dim conexion_bita As New cls_bitacora_reporteador
                conexion_bita.RegistraBitacora(Now, usuario, "Ingreso Devolucion de Compra ", "COMPRAS", _
                                          "Fecha: " + Convert.ToDateTime(dt_encabezados.Rows(0)(5)) + " Numero de devolucion SAE: " + CVE_DOC + _
                                          " Numero de Compra Rep:" + CVE_COMPRA + " almacen:" + dt_encabezados.Rows(0)(2))

                mi_transaccion.Commit()
                sql_con.Close()
                Return "correcto"
            End If
        Catch ex As Exception
            mi_transaccion.Rollback()
            sql_con.Close()
            Dim tamaño As Integer = Convert.ToString(ex.StackTrace).Length
            Dim posicion As Integer = InStrRev(Convert.ToString(ex.StackTrace), "línea") - 1
            Dim inicial As Integer = tamaño - posicion
            Dim linea_error As String = Convert.ToString(ex.StackTrace).Substring(tamaño - inicial, inicial)
            Return (ex.Message + " --> " + linea_error)
        End Try
    End Function

    Public Function lista_partidas_devolver_importacion(ByVal CVE_COMPRA As String) As DataTable
        Dim dt As New DataTable
        Dim sql_con As New SqlConnection(conexion.CadenaSQL)
        sql_con.Open()
        Dim query As New StringBuilder
        query.Append("SELECT NUM_PART, UNI, P.CVE_ART, PRODUCTO, FACT_CONV AS 'FACTOR CONVERSION',CANTIDAD, CANTIDAD,   ")
        query.Append("PRECIO_NEG AS 'PRECIO NEGOCIADO', PRECIO_FINAL AS 'PRECIO FINAL', PRECIO_NETO, DESC_PROD AS DESCUENTO, ISV_PROD AS ISV    ")
        query.Append(", P.SUB_TOTAL, DESCUENTO, ISV, TOTAL_PARTIDA AS TOTAL,PRECIO_INSERTAR, AJUSTE, 0,   ")
        query.Append("0, 0, 0, ISNULL(PRECIO_NETO,0), 0,   ")
        query.Append("ISNULL(P.CON_LOTE,'') AS CONLOTE, ISNULL(COSTO_PROM,0) AS COSTO_PROM, ISNULL((SELECT E_LTPD FROM SAE60Empre02.dbo.PAR_COMPC02    ")
        query.Append("WHERE CVE_DOC = N_FACTURA_SAE COLLATE MODERN_SPANISH_CI_AS AND SAE60Empre02.dbo.PAR_COMPC02.CVE_ART = P.CVE_ART    ")
        query.Append("COLLATE MODERN_SPANISH_CI_AS AND SAE60Empre02.dbo.PAR_COMPC02.NUM_PAR = P.NUM_PART),0) AS E_LTPD,ISNULL((SELECT NUM_MOV    ")
        query.Append("FROM SAE60Empre02.dbo.PAR_COMPC02 WHERE CVE_DOC = N_FACTURA_SAE COLLATE MODERN_SPANISH_CI_AS AND   ")
        query.Append("SAE60Empre02.dbo.PAR_COMPC02.CVE_ART = P.CVE_ART COLLATE MODERN_SPANISH_CI_AS AND   ")
        query.Append("SAE60Empre02.dbo.PAR_COMPC02.NUM_PAR = P.NUM_PART),0) AS NUM_MOV ")
        query.Append("FROM   nd_importaciones_p P INNER JOIN SAE60Empre02.dbo.INVE02 IV ON IV.CVE_ART = P.CVE_ART ")
        query.Append("COLLATE MODERN_SPANISH_CI_AS INNER JOIN nd_importaciones_e C ON P.CVE_COMPRA = C.CVE_COMPRA     ")
        query.Append(" WHERE (P.CVE_COMPRA = @CVE_COMPRA) ")

        Dim comando As New SqlCommand(query.ToString, sql_con)
        comando.Parameters.AddWithValue("@CVE_COMPRA", CVE_COMPRA)
        Dim adaptador As New SqlDataAdapter(comando)
        adaptador.Fill(dt)
        sql_con.Close()
        Return dt
    End Function

    Public Function guardar_devolucion_simportacion(ByVal dt_encabezados As DataTable, ByVal dt_partidas As DataTable, _
                                                ByVal usuario As String, ByVal tipo_enlace As String) As String
        Dim mi_transaccion As SqlTransaction
        Dim sql_con As New SqlConnection(conexion.CadenaSQL)
        sql_con.Open()
        mi_transaccion = sql_con.BeginTransaction
        Dim valida_inventario As Boolean = True
        Dim codigos_bajos As String = "Existencias insuficientes en los codigo: "
        Try
            For index As Integer = 0 To dt_partidas.Rows.Count - 1

                Dim cant_insertar As Double = 0
                If dt_partidas.Rows(index)(1) = "cj" Then
                    cant_insertar = Convert.ToDouble(dt_partidas.Rows(index)(4)) * dt_partidas.Rows(index)(5)
                ElseIf dt_partidas.Rows(index)(1) = "pz" Then
                    cant_insertar = Convert.ToDouble(dt_partidas.Rows(index)(5))
                End If

                Dim query_consulta_mult As New StringBuilder
                query_consulta_mult.Append("SELECT EXIST FROM SAE60EMPRE02.dbo.MULT02 WHERE (CVE_ART = @CVE_ART) AND (CVE_ALM = @CVE_ALM) ")
                Dim comando_consulta_mult As New SqlCommand(query_consulta_mult.ToString, sql_con)
                comando_consulta_mult.Parameters.AddWithValue("@CVE_ART", dt_partidas.Rows(index)(2))
                comando_consulta_mult.Parameters.AddWithValue("@CVE_ALM", dt_encabezados.Rows(0)(2))
                comando_consulta_mult.Transaction = mi_transaccion
                Dim dt_exist_mult As New DataTable
                Dim adaptador_consulta_mult As New SqlDataAdapter(comando_consulta_mult)
                adaptador_consulta_mult.Fill(dt_exist_mult)

                If cant_insertar > dt_exist_mult.Rows(0)(0) Then
                    valida_inventario = False
                    codigos_bajos += dt_partidas.Rows(index)(2) + vbNewLine
                End If
            Next

            If valida_inventario = False Then
                Return codigos_bajos
            Else
                Dim query_codigo As New StringBuilder
                query_codigo.Append("SELECT FOLIO + CONVERT(VARCHAR, ULT_DOC + 1) AS CLAVE,FOLIO,SERIE ")
                query_codigo.Append("FROM nd_folios ")
                query_codigo.Append("WHERE (NUM_ALMA = @ALMACEN) AND (TIPO = 'DEV')")
                Dim comando_codigo As New SqlCommand(query_codigo.ToString, sql_con)
                comando_codigo.Parameters.AddWithValue("@ALMACEN", dt_encabezados.Rows(0)(2))
                comando_codigo.Transaction = mi_transaccion
                Dim dt As New DataTable
                Dim adaptador_codigo As New SqlDataAdapter(comando_codigo)
                adaptador_codigo.Fill(dt)
                Dim CVE_COMPRA As String = ""
                CVE_COMPRA = dt.Rows(0)(0)
                Dim serie_local As String = ""
                serie_local = dt.Rows(0)(2)

                Dim query_cve_docto As New StringBuilder
                query_cve_docto.Append("SELECT SERIE, ULT_DOC ")
                query_cve_docto.Append("FROM SAE60EMPRE02.dbo.FOLIOSC02 ")
                query_cve_docto.Append("WHERE (TIP_DOC = 'd') AND (SERIE = @SERIE) ")
                Dim comando_cve_docto As New SqlCommand(query_cve_docto.ToString, sql_con)
                comando_cve_docto.Parameters.AddWithValue("@SERIE", serie_local)
                comando_cve_docto.Transaction = mi_transaccion
                Dim adaptador_cve_docto As New SqlDataAdapter(comando_cve_docto)
                Dim dt_cve_docto As New DataTable
                adaptador_cve_docto.Fill(dt_cve_docto)
                Dim CVE_DOC As String = ""
                Dim serie As String = ""
                Dim folio As Integer
                serie = dt_cve_docto.Rows(0)(0)
                folio = dt_cve_docto.Rows(0)(1) + 1
                CVE_DOC = serie & folio

                Dim query_e_local As New StringBuilder
                query_e_local.Append("INSERT INTO [tactical_discount_sr_agro].[dbo].[nd_dev_importaciones_e] ")
                query_e_local.Append("([CVE_COMPRA],[CVE_PROVEEDOR],[PROVEEDOR],[ALMACEN],[REF_PROV],[RFC],[FECHA] ")
                query_e_local.Append(",[DESCUENTO_POR],[SUB_TOTAL],[DESCUENTO_VAL],[ISV_VAL],[TOTAL],[ESTADO] ")
                query_e_local.Append(",[TASA_CAMBIO],[N_FACTURA_SAE],[FLETE],[SEGURO],[PYC],[HONORARIOS],[LOTE] ")
                query_e_local.Append(",[F_VENCIMIENTO],[PARQUEO],[REV_DES_CARG],[EMISION_G_REMISION],[ENCOMIENDAS] ")
                query_e_local.Append(",[GASTOS_VARIABLES],[BOLETIN],[AGENCIA],[TDATOS],[OTRO_PROV],[N_COMPRA_REP]) ")
                query_e_local.Append("VALUES ")
                query_e_local.Append("(@CVE_COMPRA,@CVE_PROVEEDOR,@PROVEEDOR,@ALMACEN,@REF_PROV,@RFC,@FECHA ")
                query_e_local.Append(",@DESCUENTO_POR,@SUB_TOTAL,@DESCUENTO_VAL,@ISV_VAL,@TOTAL,@ESTADO,@TASA_CAMBIO ")
                query_e_local.Append(",@N_FACTURA_SAE,@FLETE,@SEGURO,@PYC,@HONORARIOS,@LOTE,@F_VENCIMIENTO,@PARQUEO ")
                query_e_local.Append(",@REV_DES_CARG,@EMISION_G_REMISION,@ENCOMIENDAS,@GASTOS_VARIABLES,@BOLETIN ")
                query_e_local.Append(",@AGENCIA,@TDATOS,@OTRO_PROV,@N_COMPRA_REP) ")

                Dim comando_e_local As New SqlCommand(query_e_local.ToString, sql_con)
                comando_e_local.Parameters.AddWithValue("@CVE_COMPRA", CVE_COMPRA)
                comando_e_local.Parameters.AddWithValue("@CVE_PROVEEDOR", dt_encabezados.Rows(0)(0))
                comando_e_local.Parameters.AddWithValue("@PROVEEDOR", dt_encabezados.Rows(0)(1))
                comando_e_local.Parameters.AddWithValue("@ALMACEN ", dt_encabezados.Rows(0)(2))
                comando_e_local.Parameters.AddWithValue("@REF_PROV", dt_encabezados.Rows(0)(3))
                comando_e_local.Parameters.AddWithValue("@RFC", dt_encabezados.Rows(0)(4))
                comando_e_local.Parameters.AddWithValue("@FECHA", Convert.ToDateTime(dt_encabezados.Rows(0)(5)))
                comando_e_local.Parameters.AddWithValue("@DESCUENTO_POR", dt_encabezados.Rows(0)(6))
                comando_e_local.Parameters.AddWithValue("@SUB_TOTAL", dt_encabezados.Rows(0)(7))
                comando_e_local.Parameters.AddWithValue("@DESCUENTO_VAL", dt_encabezados.Rows(0)(8))
                comando_e_local.Parameters.AddWithValue("@ISV_VAL", dt_encabezados.Rows(0)(9))
                comando_e_local.Parameters.AddWithValue("@TOTAL", dt_encabezados.Rows(0)(10))
                comando_e_local.Parameters.AddWithValue("@ESTADO", "ENVIADA")
                comando_e_local.Parameters.AddWithValue("@TASA_CAMBIO", dt_encabezados.Rows(0)(11))
                comando_e_local.Parameters.AddWithValue("@N_FACTURA_SAE", dt_encabezados.Rows(0)(12))
                comando_e_local.Parameters.AddWithValue("@FLETE", dt_encabezados.Rows(0)(13))
                comando_e_local.Parameters.AddWithValue("@SEGURO", dt_encabezados.Rows(0)(14))
                comando_e_local.Parameters.AddWithValue("@PYC", dt_encabezados.Rows(0)(15))
                comando_e_local.Parameters.AddWithValue("@HONORARIOS", dt_encabezados.Rows(0)(16))
                comando_e_local.Parameters.AddWithValue("@LOTE", dt_encabezados.Rows(0)(17))
                comando_e_local.Parameters.AddWithValue("@F_VENCIMIENTO", Convert.ToDateTime(dt_encabezados.Rows(0)(18)))
                comando_e_local.Parameters.AddWithValue("@PARQUEO", dt_encabezados.Rows(0)(19))
                comando_e_local.Parameters.AddWithValue("@REV_DES_CARG", dt_encabezados.Rows(0)(20))
                comando_e_local.Parameters.AddWithValue("@EMISION_G_REMISION", dt_encabezados.Rows(0)(21))
                comando_e_local.Parameters.AddWithValue("@ENCOMIENDAS", dt_encabezados.Rows(0)(22))
                comando_e_local.Parameters.AddWithValue("@GASTOS_VARIABLES", dt_encabezados.Rows(0)(23))
                comando_e_local.Parameters.AddWithValue("@BOLETIN", dt_encabezados.Rows(0)(24))
                comando_e_local.Parameters.AddWithValue("@AGENCIA", dt_encabezados.Rows(0)(25))
                comando_e_local.Parameters.AddWithValue("@TDATOS", dt_encabezados.Rows(0)(26))
                comando_e_local.Parameters.AddWithValue("@OTRO_PROV", dt_encabezados.Rows(0)(25))
                comando_e_local.Parameters.AddWithValue("@N_COMPRA_REP", dt_encabezados.Rows(0)(28))
                comando_e_local.Transaction = mi_transaccion
                comando_e_local.ExecuteNonQuery()

                Dim query_upd_compra As New StringBuilder
                query_upd_compra.Append("UPDATE [tactical_discount_sr_agro].[dbo].[nd_importaciones_e] ")
                query_upd_compra.Append(" SET [ESTADO_COMPRA] = 'DEVUELTA' ")
                query_upd_compra.Append("WHERE [CVE_COMPRA] = @CVE_DEVO ")
                Dim comando_upd_compra As New SqlCommand(query_upd_compra.ToString, sql_con)
                comando_upd_compra.Parameters.AddWithValue("@CVE_DEVO", dt_encabezados.Rows(0)(28))
                comando_upd_compra.Transaction = mi_transaccion
                comando_upd_compra.ExecuteNonQuery()

                For index As Integer = 0 To dt_partidas.Rows.Count - 1
                    Dim query2 As New StringBuilder
                    query2.Append("INSERT INTO [tactical_discount_sr_agro].[dbo].[nd_dev_importaciones_p] ")
                    query2.Append("([CVE_COMPRA],[NUM_PART],[UNI],[CVE_ART],[PRODUCTO],[FACT_CONV],[CANTIDAD] ")
                    query2.Append(",[PRECIO_NEG],[PRECIO_FINAL],[PRECIO_NETO],[DESC_PROD],[ISV_PROD],[SUB_TOTAL] ")
                    query2.Append(",[DESCUENTO],[ISV],[TOTAL_PARTIDA],[PRECIO_INSERTAR],[AJUSTE],[HONORARIOS] ")
                    query2.Append(",[FLETE],[SEGURO],[PYC],[PARQUEO],[REV_DES_CARG],[EMISION_G_REMISION],[ENCOMIENDAS] ")
                    query2.Append(",[CON_LOTE],[GASTOS_VARIABLES]) ")
                    query2.Append("VALUES ")
                    query2.Append("(@CVE_COMPRA,@NUM_PART,@UNI,@CVE_ART,@PRODUCTO,@FACT_CONV,@CANTIDAD,@PRECIO_NEG ")
                    query2.Append(",@PRECIO_FINAL,@PRECIO_NETO,@DESC_PROD,@ISV_PROD,@SUB_TOTAL,@DESCUENTO,@ISV ")
                    query2.Append(",@TOTAL_PARTIDA,@PRECIO_INSERTAR,@AJUSTE,@HONORARIOS,@FLETE,@SEGURO,@PYC,@PARQUEO ")
                    query2.Append(",@REV_DES_CARG,@EMISION_G_REMISION,@ENCOMIENDAS,@CON_LOTE,@GASTOS_VARIABLES)")

                    Dim micomando2 As New SqlCommand(query2.ToString, sql_con)
                    micomando2.Parameters.AddWithValue("@CVE_COMPRA", CVE_COMPRA)
                    micomando2.Parameters.AddWithValue("@NUM_PART", dt_partidas.Rows(index)(0))
                    micomando2.Parameters.AddWithValue("@UNI", dt_partidas.Rows(index)(1))
                    micomando2.Parameters.AddWithValue("@CVE_ART", dt_partidas.Rows(index)(2))
                    micomando2.Parameters.AddWithValue("@PRODUCTO", dt_partidas.Rows(index)(3))
                    micomando2.Parameters.AddWithValue("@FACT_CONV", dt_partidas.Rows(index)(4))
                    micomando2.Parameters.AddWithValue("@CANTIDAD", dt_partidas.Rows(index)(5))
                    micomando2.Parameters.AddWithValue("@PRECIO_NEG", dt_partidas.Rows(index)(6))
                    micomando2.Parameters.AddWithValue("@PRECIO_FINAL", dt_partidas.Rows(index)(7))
                    micomando2.Parameters.AddWithValue("@PRECIO_NETO", dt_partidas.Rows(index)(8))
                    micomando2.Parameters.AddWithValue("@DESC_PROD", dt_partidas.Rows(index)(9))
                    micomando2.Parameters.AddWithValue("@ISV_PROD", dt_partidas.Rows(index)(10))
                    micomando2.Parameters.AddWithValue("@SUB_TOTAL", dt_partidas.Rows(index)(11))
                    micomando2.Parameters.AddWithValue("@DESCUENTO", dt_partidas.Rows(index)(12))
                    micomando2.Parameters.AddWithValue("@ISV", dt_partidas.Rows(index)(13))
                    micomando2.Parameters.AddWithValue("@TOTAL_PARTIDA", dt_partidas.Rows(index)(14))
                    micomando2.Parameters.AddWithValue("@PRECIO_INSERTAR", dt_partidas.Rows(index)(15))
                    micomando2.Parameters.AddWithValue("@AJUSTE", dt_partidas.Rows(index)(16))
                    micomando2.Parameters.AddWithValue("@HONORARIOS", dt_partidas.Rows(index)(17))
                    micomando2.Parameters.AddWithValue("@FLETE", dt_partidas.Rows(index)(18))
                    micomando2.Parameters.AddWithValue("@SEGURO", dt_partidas.Rows(index)(19))
                    micomando2.Parameters.AddWithValue("@PYC", dt_partidas.Rows(index)(20))
                    micomando2.Parameters.AddWithValue("@PARQUEO", dt_partidas.Rows(index)(21))
                    micomando2.Parameters.AddWithValue("@REV_DES_CARG", dt_partidas.Rows(index)(22))
                    micomando2.Parameters.AddWithValue("@EMISION_G_REMISION", dt_partidas.Rows(index)(23))
                    micomando2.Parameters.AddWithValue("@ENCOMIENDAS", dt_partidas.Rows(index)(24))
                    micomando2.Parameters.AddWithValue("@CON_LOTE", dt_partidas.Rows(index)(25))
                    micomando2.Parameters.AddWithValue("@GASTOS_VARIABLES", dt_partidas.Rows(index)(26))
                    micomando2.Transaction = mi_transaccion
                    micomando2.ExecuteNonQuery()
                Next

                Dim query_upd_codigo As New StringBuilder
                query_upd_codigo.Append("UPDATE [tactical_discount_sr_agro].[dbo].[nd_folios] ")
                query_upd_codigo.Append("SET [ULT_DOC] = ULT_DOC + 1 ")
                query_upd_codigo.Append("WHERE ([NUM_ALMA] = @NUM_ALMA And [TIPO] = 'DEV') ")
                Dim comando_upd_codigo As New SqlCommand(query_upd_codigo.ToString, sql_con)
                comando_upd_codigo.Parameters.AddWithValue("@NUM_ALMA", dt_encabezados.Rows(0)(2))
                comando_upd_codigo.Transaction = mi_transaccion
                comando_upd_codigo.ExecuteNonQuery()

                'registrar envio a SAE
                Dim query_compc As New StringBuilder
                query_compc.Append("INSERT INTO [SAE60Empre02].[dbo].[COMPD02] ")
                query_compc.Append("([TIP_DOC],[CVE_DOC],[CVE_CLPV],[STATUS],[SU_REFER] ,[FECHA_DOC],[FECHA_REC],[FECHA_PAG] ,[CAN_TOT], ")
                query_compc.Append("[IMP_TOT1], [IMP_TOT2], [IMP_TOT3], [IMP_TOT4], [DES_TOT], [DES_FIN], [TOT_IND], [OBS_COND],[CVE_OBS] , ")
                query_compc.Append("[NUM_ALMA], [ACT_CXP], [ACT_COI], [ENLAZADO], [TIP_DOC_E], [NUM_MONED], [TIPCAMB],[NUM_PAGOS],[FECHAELAB] , ")
                query_compc.Append("[SERIE],[FOLIO],[CTLPOL],[ESCFD],[CONTADO],[BLOQ],[DES_FIN_PORC],[DES_TOT_PORC],[IMPORTE],[TIP_DOC_ANT],[DOC_ANT]) ")
                query_compc.Append("VALUES ")
                query_compc.Append("('c', @CVE_DOC,@CVE_CLPV,'O',@SU_REFER,@FECHA_DOC ,@FECHA_REC,@FECHA_PAG,@CAN_TOT,0,0,0, @IMP_TOT4,@DES_TOT,0,0 , ")
                query_compc.Append("'',0,@NUM_ALMA,'S','N',@PARCIAL,'O',1,1,1,@FECHAELAB ,@SERIE,@FOLIO,0,'N','N','N',0 ,@DES_TOT_PORC,@IMPORTE,'','' )")
                Dim comando_compc As New SqlCommand(query_compc.ToString, sql_con)
                comando_compc.Parameters.AddWithValue("@CVE_DOC", CVE_DOC)
                comando_compc.Parameters.AddWithValue("@CVE_CLPV", dt_encabezados.Rows(0)(0))
                comando_compc.Parameters.AddWithValue("@SU_REFER", dt_encabezados.Rows(0)(3))
                comando_compc.Parameters.AddWithValue("@FECHA_DOC", Convert.ToDateTime(dt_encabezados.Rows(0)(5)))
                comando_compc.Parameters.AddWithValue("@FECHA_REC", Convert.ToDateTime(dt_encabezados.Rows(0)(5)))
                comando_compc.Parameters.AddWithValue("@FECHA_PAG", Convert.ToDateTime(dt_encabezados.Rows(0)(5)))
                comando_compc.Parameters.AddWithValue("@CAN_TOT", dt_encabezados.Rows(0)(7) * dt_encabezados.Rows(0)(11))
                comando_compc.Parameters.AddWithValue("@IMP_TOT4", dt_encabezados.Rows(0)(9) * dt_encabezados.Rows(0)(11))
                comando_compc.Parameters.AddWithValue("@DES_TOT", dt_encabezados.Rows(0)(8) * dt_encabezados.Rows(0)(11))
                comando_compc.Parameters.AddWithValue("@NUM_ALMA", dt_encabezados.Rows(0)(2))
                comando_compc.Parameters.AddWithValue("@FECHAELAB", Now.Date)
                comando_compc.Parameters.AddWithValue("@SERIE", serie)
                comando_compc.Parameters.AddWithValue("@FOLIO", folio)
                comando_compc.Parameters.AddWithValue("@DES_TOT_PORC", dt_encabezados.Rows(0)(6))
                comando_compc.Parameters.AddWithValue("@IMPORTE", dt_encabezados.Rows(0)(10) * dt_encabezados.Rows(0)(11))
                comando_compc.Parameters.AddWithValue("@PARCIAL", tipo_enlace)
                comando_compc.Transaction = mi_transaccion
                comando_compc.ExecuteNonQuery()

                Dim query_compc_c As New StringBuilder
                query_compc_c.Append("UPDATE [SAE60Empre02].[dbo].[COMPC02] ")
                query_compc_c.Append("SET [TIP_DOC_SIG] = @TIP_DOC_SIG, [DOC_SIG] = DOC_SIG, ")
                query_compc_c.Append("[ENLAZADO] = @ENLAZADO, [TIP_DOC_E] = @TIP_DOC_E ")
                query_compc_c.Append("WHERE [CVE_DOC] = @CVE_DOC ")
                Dim comando_compc_c As New SqlCommand(query_compc_c.ToString, sql_con)
                comando_compc_c.Parameters.AddWithValue("@CVE_DOC", dt_encabezados.Rows(0)(12))
                comando_compc_c.Parameters.AddWithValue("@TIP_DOC_SIG", "d")
                comando_compc_c.Parameters.AddWithValue("@DOC_SIG", CVE_DOC)
                comando_compc_c.Parameters.AddWithValue("@ENLAZADO", tipo_enlace)
                comando_compc_c.Parameters.AddWithValue("@TIP_DOC_E", "c")
                comando_compc_c.Transaction = mi_transaccion
                comando_compc_c.ExecuteNonQuery()

                Dim query_compc_clib As New StringBuilder
                query_compc_clib.Append("INSERT INTO [SAE60Empre02].[dbo].[COMPD_CLIB02] ")
                query_compc_clib.Append(" ([CLAVE_DOC]) ")
                query_compc_clib.Append("VALUES (@CLAVE_DOC)")
                Dim comando_comp_clib As New SqlCommand(query_compc_clib.ToString, sql_con)
                comando_comp_clib.Parameters.AddWithValue("CLAVE_DOC", CVE_DOC)
                comando_comp_clib.Transaction = mi_transaccion
                comando_comp_clib.ExecuteNonQuery()

                'inicio del for
                For index As Integer = 0 To dt_partidas.Rows.Count - 1
                    Dim query_doctosigc As New StringBuilder
                    query_doctosigc.Append("INSERT INTO [SAE60Empre02].[dbo].[DOCTOSIGC02] ")
                    query_doctosigc.Append("([TIP_DOC],[CVE_DOC],[ANT_SIG],[TIP_DOC_E], [CVE_DOC_E],[PARTIDA],[PART_E],[CANT_E]) ")
                    query_doctosigc.Append(" VALUES ")
                    query_doctosigc.Append(" ('c',@CVE_DOC,'S','d', @CVE_DOC_E,@PARTIDA,@PART_E,@CANT_E)")
                    Dim comando_doctosigc As New SqlCommand(query_doctosigc.ToString, sql_con)
                    comando_doctosigc.Parameters.AddWithValue("@CVE_DOC", dt_encabezados.Rows(0)(28))
                    comando_doctosigc.Parameters.AddWithValue("@CVE_DOC_E", CVE_DOC)
                    comando_doctosigc.Parameters.AddWithValue("@PARTIDA", dt_partidas.Rows(index)(0))
                    comando_doctosigc.Parameters.AddWithValue("@PART_E", index)
                    comando_doctosigc.Parameters.AddWithValue("@CANT_E", dt_partidas.Rows(index)(5))
                    comando_doctosigc.Transaction = mi_transaccion
                    comando_doctosigc.ExecuteNonQuery()

                    Dim query_select_LOTE As New StringBuilder
                    query_select_LOTE.Append(" SELECT REG_LTPD, PXRS FROM SAE60Empre02.dbo.ENLACE_LTPD02 WHERE E_LTPD = @LOTE")
                    Dim cmd_select_LOTE As New SqlCommand(query_select_LOTE.ToString, sql_con)
                    cmd_select_LOTE.Parameters.AddWithValue("@LOTE", dt_partidas.Rows(index)(24))
                    cmd_select_LOTE.Transaction = mi_transaccion
                    Dim adaptador_select_LOTE As New SqlDataAdapter(cmd_select_LOTE)
                    Dim dt_select_LOTE As New DataTable
                    adaptador_select_LOTE.Fill(dt_select_LOTE)

                    'PENDIENTE DE CARGAR EL CORRELATIVO DEL LOTE
                    Dim query_par_compc As New StringBuilder
                    query_par_compc.Append("INSERT INTO [SAE60Empre02].[dbo].[PAR_COMPD02] ")
                    query_par_compc.Append("   ([CVE_DOC],[NUM_PAR],[CVE_ART],[CANT],[PXR],[PREC],[COST] ,[IMPU1],[IMPU2], [IMPU3], ")
                    query_par_compc.Append("    [IMPU4],[IMP1APLA],[IMP2APLA],[IMP3APLA],[IMP4APLA],[TOTIMP1],[TOTIMP2], [TOTIMP3], ")
                    query_par_compc.Append("    [TOTIMP4],[DESCU],[ACT_INV],[TIP_CAM],[UNI_VENTA],[TIPO_ELEM],[TIPO_PROD], [CVE_OBS], ")
                    query_par_compc.Append("    [REG_SERIE],[E_LTPD],[FACTCONV],[COST_DEV],[NUM_ALM],[MINDIRECTO], [NUM_MOV],[TOT_PARTIDA]) ")
                    query_par_compc.Append("VALUES ")
                    query_par_compc.Append("    (@CVE_DOC,@NUM_PAR,@CVE_ART, @CANT, @PXR, ISNULL((SELECT SAE60Empre02.dbo.PRECIO_X_PROD02.PRECIO ")
                    query_par_compc.Append("    FROM SAE60Empre02.dbo.INVE02 INNER JOIN SAE60Empre02.dbo.PRECIO_X_PROD02 ON ")
                    query_par_compc.Append("    SAE60Empre02.dbo.INVE02.CVE_ART = SAE60Empre02.dbo.PRECIO_X_PROD02.CVE_ART ")
                    query_par_compc.Append("    WHERE (SAE60Empre02.dbo.PRECIO_X_PROD02.CVE_PRECIO = 1) AND (SAE60Empre02.dbo.INVE02.CVE_ART = @CVE_ART) ")
                    query_par_compc.Append("    ),0), @COST, 0, 0, 0, @IMPU4, 0, 0, 0, 0, 0, 0, 0, @TOTIMP4, @DESCU, 'S', 1, @UNI_VENTA,'N', 'P', 0,0, ")
                    query_par_compc.Append("    @E_LTPD,@FACTCONV, @COST_DEV, @NUM_ALM, 0, (SELECT ULT_CVE + 1 FROM SAE60EMPRE02.dbo.TBLCONTROL02 ")
                    query_par_compc.Append("    WHERE (ID_TABLA = 44)),@TOT_PARTIDA)")

                    Dim comando_par_compc As New SqlCommand(query_par_compc.ToString, sql_con)
                    comando_par_compc.Parameters.AddWithValue("@CVE_DOC", CVE_DOC)
                    comando_par_compc.Parameters.AddWithValue("@NUM_PAR", index + 1)
                    comando_par_compc.Parameters.AddWithValue("@CVE_ART", dt_partidas.Rows(index)(2))
                    comando_par_compc.Parameters.AddWithValue("@CANT", Convert.ToDouble(dt_partidas.Rows(index)(5)))

                    Dim cant_insertar As Double = 0
                    Dim costo_insertar As Double = 0
                    Dim factor_conversion As Integer = 0
                    If dt_partidas.Rows(index)(1) = "cj" Then
                        cant_insertar = Convert.ToDouble(dt_partidas.Rows(index)(4)) * dt_partidas.Rows(index)(5)
                        costo_insertar = dt_partidas.Rows(index)(6) * dt_partidas.Rows(index)(4) * dt_encabezados.Rows(0)(11)
                        factor_conversion = dt_partidas.Rows(index)(4)
                    ElseIf dt_partidas.Rows(index)(1) = "pz" Then
                        cant_insertar = Convert.ToDouble(dt_partidas.Rows(index)(5))
                        costo_insertar = dt_partidas.Rows(index)(6) * dt_encabezados.Rows(0)(11)
                        factor_conversion = 1
                    End If

                    comando_par_compc.Parameters.AddWithValue("@PXR", cant_insertar)
                    comando_par_compc.Parameters.AddWithValue("@COST", costo_insertar)
                    comando_par_compc.Parameters.AddWithValue("@IMPU4", dt_partidas.Rows(index)(10))
                    comando_par_compc.Parameters.AddWithValue("@TOTIMP4", Convert.ToDouble(dt_partidas.Rows(index)(13)) * dt_encabezados.Rows(0)(11))
                    comando_par_compc.Parameters.AddWithValue("@DESCU", 0) 'dt_p.Rows(index)(7))
                    comando_par_compc.Parameters.AddWithValue("@UNI_VENTA", dt_partidas.Rows(index)(1))

                    If dt_partidas.Rows(index)(20) = "S" Then
                        comando_par_compc.Parameters.AddWithValue("@E_LTPD", dt_partidas.Rows(index)(27))
                    Else
                        comando_par_compc.Parameters.AddWithValue("@E_LTPD", 0)
                    End If

                    comando_par_compc.Parameters.AddWithValue("@FACTCONV", factor_conversion)
                    comando_par_compc.Parameters.AddWithValue("@COST_DEV", dt_partidas.Rows(index)(6) * dt_partidas.Rows(index)(4) * dt_encabezados.Rows(0)(11))
                    comando_par_compc.Parameters.AddWithValue("@NUM_ALM", dt_encabezados.Rows(0)(2))
                    comando_par_compc.Parameters.AddWithValue("@TOT_PARTIDA", (Convert.ToDouble(dt_partidas.Rows(index)(14)) - _
                                                                               Convert.ToDouble(dt_partidas.Rows(index)(13))) * dt_encabezados.Rows(0)(11))
                    comando_par_compc.Transaction = mi_transaccion
                    comando_par_compc.ExecuteNonQuery()

                    Dim query_par_comp_clib As New StringBuilder
                    query_par_comp_clib.Append("INSERT INTO [SAE60Empre02].[dbo].[PAR_COMPD_CLIB02] ")
                    query_par_comp_clib.Append("   ([CLAVE_DOC],[NUM_PART]) ")
                    query_par_comp_clib.Append("VALUES ")
                    query_par_comp_clib.Append("   (@CLAVE_DOC,@NUM_PART) ")
                    Dim comando_par_comp_clib As New SqlCommand(query_par_comp_clib.ToString, sql_con)
                    comando_par_comp_clib.Parameters.AddWithValue("@CLAVE_DOC", CVE_DOC)
                    comando_par_comp_clib.Parameters.AddWithValue("@NUM_PART", index + 1)
                    comando_par_comp_clib.Transaction = mi_transaccion
                    comando_par_comp_clib.ExecuteNonQuery()

                    Dim query_costo_prom As New StringBuilder
                    query_costo_prom.Append("SELECT ISNULL(EXIST,0),ISNULL(COSTO_PROM,0) FROM SAE60EMPRE02.dbo.INVE02 WHERE CVE_ART = @CVE_ART")
                    Dim comando_costo_prom As New SqlCommand(query_costo_prom.ToString, sql_con)
                    comando_costo_prom.Parameters.AddWithValue("@CVE_ART", dt_partidas.Rows(index)(2))
                    comando_costo_prom.Transaction = mi_transaccion

                    Dim adaptador_costo As New SqlDataAdapter(comando_costo_prom)
                    Dim dt_costo_prom As New DataTable

                    Dim existencias_viejas As Double = 0, costo_prom_viejo As Double = 0
                    adaptador_costo.Fill(dt_costo_prom)
                    existencias_viejas = dt_costo_prom.Rows(0)(0)
                    costo_prom_viejo = dt_costo_prom.Rows(0)(1)

                    Dim costo_prom_nuevo As Double = 0
                    costo_prom_nuevo = ((existencias_viejas * costo_prom_viejo) - (cant_insertar * dt_partidas.Rows(index)(6) * dt_encabezados.Rows(0)(11))) / (existencias_viejas - cant_insertar)

                    Dim query_upd_inve As New StringBuilder
                    query_upd_inve.Append("UPDATE SAE60EMPRE02.dbo.INVE02 ")
                    query_upd_inve.Append("SET [EXIST] = (EXIST - @NUEVA_EXISTENCIA), ")
                    query_upd_inve.Append("FCH_ULTCOM = @FECHA_ULTCOM, COSTO_PROM = @COSTO_PROM, ULT_COSTO = @ULT_COSTO ")
                    query_upd_inve.Append("WHERE [CVE_ART] = @CVE_ART ")
                    Dim comando_upd_inve As New SqlCommand(query_upd_inve.ToString, sql_con)
                    comando_upd_inve.Parameters.AddWithValue("@NUEVA_EXISTENCIA", cant_insertar)
                    comando_upd_inve.Parameters.AddWithValue("@FECHA_ULTCOM", Now.Date)
                    comando_upd_inve.Parameters.AddWithValue("@COSTO_PROM", costo_prom_nuevo)
                    comando_upd_inve.Parameters.AddWithValue("@ULT_COSTO", dt_partidas.Rows(index)(6) * dt_encabezados.Rows(index)(11))
                    comando_upd_inve.Parameters.AddWithValue("@CVE_ART", dt_partidas.Rows(index)(2))
                    comando_upd_inve.Transaction = mi_transaccion
                    comando_upd_inve.ExecuteNonQuery()

                    Dim query_upd_mult As New StringBuilder
                    query_upd_mult.Append("UPDATE SAE60EMPRE02.dbo.MULT02 ")
                    query_upd_mult.Append("SET [EXIST] = (EXIST - @NUEVA_EXISTENCIA) ")
                    query_upd_mult.Append("WHERE  [CVE_ART] = @CVE_ART AND [CVE_ALM] = @CVE_ALM ")
                    Dim comando_upd_mult As New SqlCommand(query_upd_mult.ToString, sql_con)
                    comando_upd_mult.Parameters.AddWithValue("@NUEVA_EXISTENCIA", cant_insertar)
                    comando_upd_mult.Parameters.AddWithValue("@CVE_ART", dt_partidas.Rows(index)(2))
                    comando_upd_mult.Parameters.AddWithValue("@CVE_ALM", dt_encabezados.Rows(0)(2))
                    comando_upd_mult.Transaction = mi_transaccion
                    comando_upd_mult.ExecuteNonQuery()

                    If dt_partidas.Rows(index)(22) = "S" Then
                        Dim query_reg_lote As New StringBuilder
                        query_reg_lote.Append("SELECT (ULT_CVE + 1) AS ULT_CVE ")
                        query_reg_lote.Append("FROM SAE60EMPRE02.dbo.TBLCONTROL02 ")
                        query_reg_lote.Append("WHERE (ID_TABLA = 67) ")
                        Dim comando_reg_lote As New SqlCommand(query_reg_lote.ToString, sql_con)
                        comando_reg_lote.Transaction = mi_transaccion
                        Dim adaptador_reg_lote As New SqlDataAdapter(comando_reg_lote)
                        Dim dt_reg_lote As New DataTable
                        adaptador_reg_lote.Fill(dt_reg_lote)
                        Dim reg_lote As Integer
                        reg_lote = dt_reg_lote.Rows(0)(0)

                        Dim query_ltpd As New StringBuilder
                        query_ltpd.Append("UPDATE [SAE60Empre02].[dbo].[LTPD02] ")
                        query_ltpd.Append("SET [CANTIDAD] = [CANTIDAD] - @CANTIDAD ")
                        query_ltpd.Append("WHERE [CVE_ART] = @CVE_ART AND [CVE_ALM] = @CVE_ALM ")
                        query_ltpd.Append(" AND [REG_LTPD] = @REG_LTPD ")
                        Dim comando_ltpd As New SqlCommand(query_ltpd.ToString, sql_con)
                        comando_ltpd.Parameters.AddWithValue("@CVE_ART", dt_partidas.Rows(index)(2))
                        comando_ltpd.Parameters.AddWithValue("@CANTIDAD", cant_insertar)
                        comando_ltpd.Parameters.AddWithValue("@CVE_ALM", dt_encabezados.Rows(0)(2))
                        If dt_select_LOTE.Rows.Count > 0 Then
                            comando_ltpd.Parameters.AddWithValue("@REG_LTPD", dt_select_LOTE.Rows(0)(0))
                        Else
                            comando_ltpd.Parameters.AddWithValue("@REG_LTPD", 0)
                        End If

                        comando_ltpd.Transaction = mi_transaccion
                        comando_ltpd.ExecuteNonQuery()

                        Dim query_UPD_enlace_ltpd As New StringBuilder
                        query_UPD_enlace_ltpd.Append("UPDATE [SAE60Empre02].[dbo].[ENLACE_LTPD02] ")

                        If dt_select_LOTE.Rows.Count > 0 Then
                            If cant_insertar > dt_select_LOTE.Rows(0)(1) Then
                                query_UPD_enlace_ltpd.Append("SET [PXRS] = 0 ")
                            Else
                                query_UPD_enlace_ltpd.Append("SET [PXRS] = [PXRS] - @CANTIDAD ")
                            End If
                        Else
                            query_UPD_enlace_ltpd.Append("SET [PXRS] = [PXRS] - @CANTIDAD ")
                        End If
                        query_UPD_enlace_ltpd.Append("WHERE [E_LTPD] = @E_LTPD ")
                        Dim comando_UPD_enlace_ltpd As New SqlCommand(query_UPD_enlace_ltpd.ToString, sql_con)
                        comando_UPD_enlace_ltpd.Parameters.AddWithValue("@E_LTPD", dt_partidas.Rows(index)(27))
                        comando_UPD_enlace_ltpd.Parameters.AddWithValue("@CANTIDAD", cant_insertar)
                        comando_UPD_enlace_ltpd.Transaction = mi_transaccion
                        comando_UPD_enlace_ltpd.ExecuteNonQuery()

                        Dim query_enlace_ltpd As New StringBuilder
                        query_enlace_ltpd.Append("INSERT INTO [SAE60Empre02].[dbo].[ENLACE_LTPD02] ")
                        query_enlace_ltpd.Append("   ([E_LTPD],[REG_LTPD],[CANTIDAD],[PXRS]) ")
                        query_enlace_ltpd.Append("VALUES ")
                        query_enlace_ltpd.Append("   (@E_LTPD,@REG_LTPD, @CANTIDAD,@PXRS)")
                        Dim comando_enlace_ltpd As New SqlCommand(query_enlace_ltpd.ToString, sql_con)
                        comando_enlace_ltpd.Parameters.AddWithValue("@E_LTPD", reg_lote)
                        If dt_select_LOTE.Rows.Count > 0 Then
                            comando_enlace_ltpd.Parameters.AddWithValue("@REG_LTPD", dt_select_LOTE.Rows(0)(0))
                        Else
                            comando_enlace_ltpd.Parameters.AddWithValue("@REG_LTPD", 0)
                        End If
                        comando_enlace_ltpd.Parameters.AddWithValue("@CANTIDAD", cant_insertar)
                        comando_enlace_ltpd.Parameters.AddWithValue("@PXRS", cant_insertar)
                        comando_enlace_ltpd.Transaction = mi_transaccion
                        comando_enlace_ltpd.ExecuteNonQuery()

                        Dim query_upd_correlativo_lote As New StringBuilder
                        query_upd_correlativo_lote.Append("UPDATE [SAE60Empre02].[dbo].[TBLCONTROL02] ")
                        query_upd_correlativo_lote.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                        query_upd_correlativo_lote.Append("WHERE([ID_TABLA] = 67)")
                        Dim comando_upd_correlativo_lote As New SqlCommand(query_upd_correlativo_lote.ToString, sql_con)
                        comando_upd_correlativo_lote.Transaction = mi_transaccion
                        comando_upd_correlativo_lote.ExecuteNonQuery()
                    End If

                    Dim query_minve As New StringBuilder
                    query_minve.Append("INSERT INTO [SAE60Empre02].[dbo].[MINVE02] ")
                    query_minve.Append("   ([CVE_ART],[ALMACEN],[NUM_MOV],[CVE_CPTO],[FECHA_DOCU],[TIPO_DOC],[REFER],[CLAVE_CLPV],[VEND],[CANT],[CANT_COST] , ")
                    query_minve.Append("   [PRECIO],[COSTO],[REG_SERIE],[UNI_VENTA] ,[E_LTPD],[EXIST_G], [EXISTENCIA],[FACTOR_CON] ,[FECHAELAB], ")
                    query_minve.Append("   [CVE_FOLIO],[SIGNO],[COSTEADO],[COSTO_PROM_INI],[COSTO_PROM_FIN],[COSTO_PROM_GRAL],[DESDE_INVE],[MOV_ENLAZADO])  ")
                    query_minve.Append("VALUES ")
                    query_minve.Append("   (@CVE_ART, @ALMACEN,(SELECT ULT_CVE+1 FROM SAE60EMPRE02.dbo.TBLCONTROL02 WHERE (ID_TABLA = 44)),52,@FECHA_DOCU, ")
                    query_minve.Append("   'd', @REFER, @CLAVE_CLPV, '',@CANT, 0, 0, @COSTO, 0,@UNI_VENTA, @E_LTPD,ISNULL((SELECT EXIST FROM SAE60EMPRE02.dbo.INVE02 ")
                    query_minve.Append("    WHERE (CVE_ART = @CVE_ART)),0) , ((SELECT EXIST FROM SAE60EMPRE02.dbo.MULT02 WHERE (CVE_ART = @CVE_ART) AND CVE_ALM = @ALMACEN)), ")
                    query_minve.Append("    @FACTOR_CON, @FECHAELAB, (SELECT ULT_CVE+1 FROM SAE60EMPRE02.dbo.TBLCONTROL02 WHERE (ID_TABLA = 32)),'-1','S', @COSTO_PROM_INI, ")
                    query_minve.Append("    @COSTO_PROM_FIN, @COSTO_PROM_GRAL,'N',@MOV_ENLAZADO)")

                    Dim comando_minve As New SqlCommand(query_minve.ToString, sql_con)

                    comando_minve.Parameters.AddWithValue("@CVE_ART", dt_partidas.Rows(index)(2))
                    comando_minve.Parameters.AddWithValue("@ALMACEN", dt_encabezados.Rows(0)(2))
                    comando_minve.Parameters.AddWithValue("@FECHA_DOCU", Convert.ToDateTime(dt_encabezados.Rows(0)(5)))
                    comando_minve.Parameters.AddWithValue("@REFER", CVE_DOC)
                    comando_minve.Parameters.AddWithValue("@CLAVE_CLPV", dt_encabezados.Rows(0)(0))
                    comando_minve.Parameters.AddWithValue("@CANT", cant_insertar)
                    comando_minve.Parameters.AddWithValue("@COSTO", dt_partidas.Rows(index)(6) * dt_encabezados.Rows(0)(11))
                    comando_minve.Parameters.AddWithValue("@UNI_VENTA", dt_partidas.Rows(index)(1))
                    If dt_partidas.Rows(index)(22) = "S" Then
                        comando_minve.Parameters.AddWithValue("@E_LTPD", dt_partidas.Rows(index)(27))
                    Else
                        comando_minve.Parameters.AddWithValue("@E_LTPD", 0)
                    End If
                    comando_minve.Parameters.AddWithValue("@FACTOR_CON", factor_conversion)
                    comando_minve.Parameters.AddWithValue("@FECHAELAB", Now.Date)
                    comando_minve.Parameters.AddWithValue("@COSTO_PROM_INI", costo_prom_viejo)
                    comando_minve.Parameters.AddWithValue("@COSTO_PROM_FIN", costo_prom_nuevo)
                    comando_minve.Parameters.AddWithValue("@COSTO_PROM_GRAL", costo_prom_nuevo)
                    comando_minve.Parameters.AddWithValue("@MOV_ENLAZADO", dt_partidas.Rows(index)(28))
                    comando_minve.Transaction = mi_transaccion
                    comando_minve.ExecuteNonQuery()

                    Dim query_num_mov_minve As New StringBuilder
                    query_num_mov_minve.Append("UPDATE [SAE60Empre02].[dbo].[TBLCONTROL02] ")
                    query_num_mov_minve.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                    query_num_mov_minve.Append("WHERE ([ID_TABLA] = 44)")
                    Dim comando_num_mov_minve As New SqlCommand(query_num_mov_minve.ToString, sql_con)
                    comando_num_mov_minve.Transaction = mi_transaccion
                    comando_num_mov_minve.ExecuteNonQuery()

                    Dim query_upd_folio_minve As New StringBuilder
                    query_upd_folio_minve.Append("UPDATE SAE60EMPRE02.dbo.TBLCONTROL02 ")
                    query_upd_folio_minve.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                    query_upd_folio_minve.Append("WHERE (ID_TABLA = 32) ")
                    Dim comando_upd_folio_minve As New SqlCommand(query_upd_folio_minve.ToString, sql_con)
                    comando_upd_folio_minve.Transaction = mi_transaccion
                    comando_upd_folio_minve.ExecuteNonQuery()
                Next
                'fin del for
                Dim query_paga_m As New StringBuilder
                query_paga_m.Append("INSERT INTO [SAE60Empre02].[dbo].[PAGA_DET02] ")
                query_paga_m.Append("   ([CVE_PROV],[REFER],[NUM_CPTO],[NUM_CARGO],[ID_MOV],[CVE_OBS],[NO_FACTURA],[DOCTO], [IMPORTE],[FECHA_APLI], ")
                query_paga_m.Append("    [FECHA_VENC], [AFEC_COI], [NUM_MONED], [TCAMBIO], [IMPMON_EXT], [FECHAELAB],[TIPO_MOV] ,[SIGNO],[USUARIO], ")
                query_paga_m.Append("    [NO_PARTIDA]) VALUES ")
                query_paga_m.Append("   (@CVE_PROV, @REFER, 8, 1,1, 0, @NO_FACTURA, @DOCTO,@IMPORTE,@FECHA_APLI, @FECHA_VENC, ")
                query_paga_m.Append("   'A',1, 1, @IMPMON_EXT,@FECHAELAB, 'A', -1, @USUARIO,@NO_PARTIDA)")

                Dim comando_paga_m As New SqlCommand(query_paga_m.ToString, sql_con)
                comando_paga_m.Parameters.AddWithValue("@CVE_PROV", dt_encabezados.Rows(0)(0))
                comando_paga_m.Parameters.AddWithValue("@REFER", dt_encabezados.Rows(0)(12))
                comando_paga_m.Parameters.AddWithValue("@DOCTO", CVE_DOC)
                comando_paga_m.Parameters.AddWithValue("@NO_FACTURA", dt_encabezados.Rows(0)(3))
                comando_paga_m.Parameters.AddWithValue("@IMPORTE", dt_encabezados.Rows(0)(10) * dt_encabezados.Rows(0)(11))
                comando_paga_m.Parameters.AddWithValue("@FECHA_APLI", Convert.ToDateTime(dt_encabezados.Rows(0)(5)))
                comando_paga_m.Parameters.AddWithValue("@FECHA_VENC", Convert.ToDateTime(dt_encabezados.Rows(0)(18)))
                comando_paga_m.Parameters.AddWithValue("@IMPMON_EXT", dt_encabezados.Rows(0)(10) * dt_encabezados.Rows(0)(11))
                comando_paga_m.Parameters.AddWithValue("@FECHAELAB", Now.Date)
                comando_paga_m.Parameters.AddWithValue("@USUARIO", 0)
                comando_paga_m.Parameters.AddWithValue("@NO_PARTIDA", 1)
                comando_paga_m.Transaction = mi_transaccion
                comando_paga_m.ExecuteNonQuery()

                Dim query_upd_prov As New StringBuilder
                query_upd_prov.Append("UPDATE [SAE60Empre02].[dbo].[PROV02] SET [SALDO] = SALDO - @SALDO ")
                query_upd_prov.Append("WHERE([CLAVE] = @CLAVE)")
                Dim comando_upd_prov As New SqlCommand(query_upd_prov.ToString, sql_con)
                comando_upd_prov.Parameters.AddWithValue("@SALDO", dt_encabezados.Rows(0)(10) * dt_encabezados.Rows(0)(11))
                comando_upd_prov.Parameters.AddWithValue("@CLAVE", dt_encabezados.Rows(0)(0))
                comando_upd_prov.Transaction = mi_transaccion
                comando_upd_prov.ExecuteNonQuery()

                Dim query_cve_docto_upd As New StringBuilder
                query_cve_docto_upd.Append("UPDATE [SAE60Empre02].[dbo].[FOLIOSC02] ")
                query_cve_docto_upd.Append("SET [ULT_DOC] = ULT_DOC + 1 , ")
                query_cve_docto_upd.Append("[FECH_ULT_DOC] = @FECH_ULT_DOC ")
                query_cve_docto_upd.Append("WHERE (TIP_DOC = 'd') AND (SERIE = @SERIE)")
                Dim comando_cve_docto_upd As New SqlCommand(query_cve_docto_upd.ToString, sql_con)
                comando_cve_docto_upd.Parameters.AddWithValue("@FECH_ULT_DOC", Convert.ToDateTime(dt_encabezados.Rows(0)(5)))
                comando_cve_docto_upd.Parameters.AddWithValue("@SERIE", serie)
                comando_cve_docto_upd.Transaction = mi_transaccion
                comando_cve_docto_upd.ExecuteNonQuery()

                Dim query_ajuste As New StringBuilder
                query_ajuste.Append("SELECT ID_AJUSTE FROM nd_ajuste_e WHERE COMPRA = @COMPRA ")
                Dim comando_ajuste As New SqlCommand(query_ajuste.ToString, sql_con)
                comando_ajuste.Parameters.AddWithValue("@COMPRA", dt_encabezados.Rows(0)(28))
                comando_ajuste.Transaction = mi_transaccion
                Dim adaptador_ajuste As New SqlDataAdapter(comando_ajuste)
                Dim dt_ajuste As New DataTable
                adaptador_ajuste.Fill(dt_ajuste)

                For index As Integer = 0 To dt_ajuste.Rows.Count - 1
                    Dim query_elimina_ajustes As New StringBuilder
                    query_elimina_ajustes.Append("DELETE FROM [tactical_discount_sr_agro].[dbo].[nd_ajuste_e] WHERE ID_AJUSTE = @ID_AJUSTE")
                    Dim comando_elimina_ajuste As New SqlCommand(query_elimina_ajustes.ToString, sql_con)
                    comando_elimina_ajuste.Parameters.AddWithValue("@ID_AJUSTE", dt_ajuste.Rows(index)(0))
                    comando_elimina_ajuste.Transaction = mi_transaccion
                    comando_elimina_ajuste.ExecuteNonQuery()

                    Dim query_elimina_ajustes_partidas As New StringBuilder
                    query_elimina_ajustes_partidas.Append("DELETE FROM [tactical_discount_sr_agro].[dbo].[nd_ajuste_p] WHERE ID_AJUSTE = @ID_AJUSTE")
                    Dim comando_elimina_ajuste_partida As New SqlCommand(query_elimina_ajustes_partidas.ToString, sql_con)
                    comando_elimina_ajuste_partida.Parameters.AddWithValue("@ID_AJUSTE", dt_ajuste.Rows(index)(0))
                    comando_elimina_ajuste_partida.Transaction = mi_transaccion
                    comando_elimina_ajuste_partida.ExecuteNonQuery()
                Next

                Dim query_elimina_creditos As New StringBuilder
                query_elimina_creditos.Append("DELETE FROM [SAE60Empre02].[dbo].[PAGA_DET02] ")
                query_elimina_creditos.Append("WHERE  NUM_CPTO = 29 AND REFER = @REFER ")
                query_elimina_creditos.Append("AND USUARIO = 0 AND CVE_PROV = @CVE_PROV ")
                Dim comando_elimina_creditos As New SqlCommand(query_elimina_creditos.ToString, sql_con)
                comando_elimina_creditos.Parameters.AddWithValue("@REFER", dt_encabezados.Rows(0)(12))
                comando_elimina_creditos.Parameters.AddWithValue("@CVE_PROV", dt_encabezados.Rows(0)(0))
                comando_elimina_creditos.Transaction = mi_transaccion
                comando_elimina_creditos.ExecuteNonQuery()


                If tipo_enlace = "T" Then
                    Dim query_elimina_vesta As New StringBuilder
                    query_elimina_vesta.Append("DELETE FROM [SAE60Empre02].[dbo].[PAGA_M02] ")
                    query_elimina_vesta.Append("WHERE  NUM_CPTO = 1 AND REFER = @REFER ")
                    query_elimina_vesta.Append("AND USUARIO = 0 AND CVE_PROV = @CVE_PROV ")
                    Dim comando_elimina_vesta As New SqlCommand(query_elimina_vesta.ToString, sql_con)
                    comando_elimina_vesta.Parameters.AddWithValue("@REFER", dt_encabezados.Rows(0)(29))
                    comando_elimina_vesta.Parameters.AddWithValue("@CVE_PROV", dt_encabezados.Rows(0)(27))
                    comando_elimina_vesta.Parameters.AddWithValue("@NO_FACTURA", dt_encabezados.Rows(0)(3))
                    comando_elimina_vesta.Transaction = mi_transaccion
                    comando_elimina_vesta.ExecuteNonQuery()
                End If

                If tipo_enlace = "P" Then
                    Dim ajuste As String = ""
                    Dim debito As String = ""
                    For index As Integer = 0 To dt_partidas.Rows.Count - 1
                        If dt_partidas.Rows(index)(26) = "S" Then
                            ajuste = "S"
                        End If

                        If dt_partidas.Rows(index)(26) = "D" Then
                            debito = "D"
                        End If
                    Next

                    ' registra los debito por producto
                    If ajuste = "S" Then
                        Dim query_folio_ajuste As New StringBuilder
                        query_folio_ajuste.Append("SELECT FOLIO + CONVERT(VARCHAR, ULT_DOC + 1) AS ULT_DOC ")
                        query_folio_ajuste.Append("FROM nd_folios ")
                        query_folio_ajuste.Append("WHERE (TIPO = 'A') AND (NUM_ALMA = @ALMACEN)")
                        Dim comando_folio_ajuste As New SqlCommand(query_folio_ajuste.ToString, sql_con)
                        comando_folio_ajuste.Parameters.AddWithValue("@ALMACEN", dt_encabezados.Rows(0)(2))
                        comando_folio_ajuste.Transaction = mi_transaccion
                        Dim dt_folio_ajuste As New DataTable
                        Dim adaptador_folio_ajuste As New SqlDataAdapter(comando_folio_ajuste)
                        adaptador_folio_ajuste.Fill(dt_folio_ajuste)

                        Dim subtotal_ajuste_e As Double = 0, isv_ajuste_e As Double = 0, total_ajueste_e As Double = 0, descuento_ajuste_e As Double = 0
                        For index As Integer = 0 To dt_partidas.Rows.Count - 1
                            If dt_partidas.Rows(index)(26) = "S" Then
                                Dim query_ajuste_p As New StringBuilder
                                query_ajuste_p.Append("INSERT INTO [tactical_discount_sr_agro].[dbo].[nd_ajuste_p] ")
                                query_ajuste_p.Append("([ID_AJUSTE],[NUM_PART],[CVE_ART],[DESCRIPCION],[MOTIVO],[CANTIDAD], ")
                                query_ajuste_p.Append("[FECHA_INGRESO],[COSTO_ANTERIOR],[COSTO_ACTUAL],[AJUSTE],[UNI]) ")
                                query_ajuste_p.Append("VALUES ")
                                query_ajuste_p.Append("(@ID_AJUSTE,@NUM_PART,@CVE_ART,@DESCRIPCION,@MOTIVO,@CANTIDAD, ")
                                query_ajuste_p.Append("@FECHA_INGRESO,@COSTO_ANTERIOR,@COSTO_ACTUAL,@AJUSTE,@UNI)")
                                Dim comando_ajuste_p As New SqlCommand(query_ajuste_p.ToString, sql_con)
                                comando_ajuste_p.Parameters.AddWithValue("@ID_AJUSTE", dt_folio_ajuste.Rows(0)(0))
                                comando_ajuste_p.Parameters.AddWithValue("@NUM_PART", index + 1)
                                comando_ajuste_p.Parameters.AddWithValue("@CVE_ART", dt_partidas.Rows(index)(2))
                                comando_ajuste_p.Parameters.AddWithValue("@DESCRIPCION", dt_partidas.Rows(index)(3))
                                comando_ajuste_p.Parameters.AddWithValue("@MOTIVO", "AJUSTE DE PRECIO")
                                comando_ajuste_p.Parameters.AddWithValue("@CANTIDAD", dt_partidas.Rows(index)(5))
                                comando_ajuste_p.Parameters.AddWithValue("@FECHA_INGRESO", Convert.ToDateTime(dt_encabezados.Rows(0)(5)))
                                comando_ajuste_p.Parameters.AddWithValue("@COSTO_ANTERIOR", dt_partidas.Rows(index)(6))
                                comando_ajuste_p.Parameters.AddWithValue("@COSTO_ACTUAL", dt_partidas.Rows(index)(7))
                                Dim valor_ajuste As Double = 0

                                valor_ajuste = (Convert.ToDouble(dt_partidas.Rows(index)(5)) * Convert.ToDouble(dt_partidas.Rows(index)(7))) - _
                                                (Convert.ToDouble(dt_partidas.Rows(index)(5)) * Convert.ToDouble(dt_partidas.Rows(index)(6)))
                                If dt_partidas.Rows(index)(1) = "cj" Then
                                    valor_ajuste = valor_ajuste * Convert.ToDouble(dt_partidas.Rows(index)(4))
                                End If

                                comando_ajuste_p.Parameters.AddWithValue("@AJUSTE", valor_ajuste * -1)
                                comando_ajuste_p.Parameters.AddWithValue("@UNI", dt_partidas.Rows(index)(1))

                                subtotal_ajuste_e += valor_ajuste
                                descuento_ajuste_e += 0 'valor_ajuste * dt_p.Rows(index)(7) / 100
                                valor_ajuste = valor_ajuste - descuento_ajuste_e
                                isv_ajuste_e += valor_ajuste * dt_partidas.Rows(index)(9) / 100
                                comando_ajuste_p.Transaction = mi_transaccion
                                comando_ajuste_p.ExecuteNonQuery()
                            End If
                        Next
                        total_ajueste_e += subtotal_ajuste_e - descuento_ajuste_e + isv_ajuste_e

                        Dim query_ajuste_e As New StringBuilder
                        query_ajuste_e.Append("INSERT INTO [tactical_discount_sr_agro].[dbo].[nd_ajuste_e] ")
                        query_ajuste_e.Append("([ID_AJUSTE],[CVE_PROVEEDOR],[ALMACEN],[REF_PROV]")
                        query_ajuste_e.Append(",[FECHA],[N_FACTURA],[SUBTOTAL],[DESCUENTO],[ISV],[TOTAL],[COMPRA],[TIPO]) ")
                        query_ajuste_e.Append("VALUES ")
                        query_ajuste_e.Append("(@ID_AJUSTE,@CVE_PROVEEDOR,@ALMACEN,@REF_PROV,@FECHA, ")
                        query_ajuste_e.Append("@N_FACTURA,@SUBTOTAL,@DESCUENTO,@ISV,@TOTAL,@COMPRA,@TIPO)")
                        Dim comando_ajuste_e As New SqlCommand(query_ajuste_e.ToString, sql_con)
                        comando_ajuste_e.Parameters.AddWithValue("@ID_AJUSTE", dt_folio_ajuste.Rows(0)(0))
                        comando_ajuste_e.Parameters.AddWithValue("@CVE_PROVEEDOR", dt_encabezados.Rows(0)(0))
                        comando_ajuste_e.Parameters.AddWithValue("@ALMACEN", dt_encabezados.Rows(0)(2))
                        comando_ajuste_e.Parameters.AddWithValue("@REF_PROV", dt_encabezados.Rows(0)(3))
                        comando_ajuste_e.Parameters.AddWithValue("@FECHA", Convert.ToDateTime(dt_encabezados.Rows(0)(5)))
                        comando_ajuste_e.Parameters.AddWithValue("@N_FACTURA", dt_encabezados.Rows(0)(3))
                        comando_ajuste_e.Parameters.AddWithValue("@SUBTOTAL", subtotal_ajuste_e * -1)
                        comando_ajuste_e.Parameters.AddWithValue("@DESCUENTO", 0) 'descuento_ajuste_e * -1)
                        comando_ajuste_e.Parameters.AddWithValue("@ISV", isv_ajuste_e * -1)
                        comando_ajuste_e.Parameters.AddWithValue("@TOTAL", total_ajueste_e * -1)
                        comando_ajuste_e.Parameters.AddWithValue("@COMPRA", dt_encabezados.Rows(0)(28))
                        comando_ajuste_e.Parameters.AddWithValue("@TIPO", "DEBITO")
                        comando_ajuste_e.Transaction = mi_transaccion
                        comando_ajuste_e.ExecuteNonQuery()

                        Dim query_upd_folio_ajuste As New StringBuilder
                        query_upd_folio_ajuste.Append("UPDATE [tactical_discount_sr_agro].[dbo].[nd_folios] ")
                        query_upd_folio_ajuste.Append("   SET [ULT_DOC] = ULT_DOC+1 ")
                        query_upd_folio_ajuste.Append("WHERE [NUM_ALMA] = @NUM_ALMA AND TIPO = 'A' ")
                        Dim comando_upd_folio_ajuste As New SqlCommand(query_upd_folio_ajuste.ToString, sql_con)
                        comando_upd_folio_ajuste.Parameters.AddWithValue("@NUM_ALMA", dt_encabezados.Rows(0)(2))
                        comando_upd_folio_ajuste.Transaction = mi_transaccion
                        comando_upd_folio_ajuste.ExecuteNonQuery()

                    End If
                    ' fn registra los debitos por producto

                    ' registra los creditos por producto
                    If debito = "D" Then
                        Dim query_folio_debito As New StringBuilder
                        query_folio_debito.Append("SELECT FOLIO + CONVERT(VARCHAR, ULT_DOC + 1) AS ULT_DOC ")
                        query_folio_debito.Append("FROM nd_folios ")
                        query_folio_debito.Append("WHERE (TIPO = 'D') AND (NUM_ALMA = @ALMACEN)")
                        Dim comando_folio_debito As New SqlCommand(query_folio_debito.ToString, sql_con)
                        comando_folio_debito.Parameters.AddWithValue("@ALMACEN", dt_encabezados.Rows(0)(2))
                        comando_folio_debito.Transaction = mi_transaccion
                        Dim dt_folio_debito As New DataTable
                        Dim adaptador_folio_debito As New SqlDataAdapter(comando_folio_debito)
                        adaptador_folio_debito.Fill(dt_folio_debito)

                        Dim subtotal_debito_e As Double = 0, isv_debito_e As Double = 0, total_debito_e As Double = 0, descuento_debito_e As Double = 0
                        For index As Integer = 0 To dt_partidas.Rows.Count - 1
                            If dt_partidas.Rows(index)(26) = "D" Then
                                Dim query_debito_p As New StringBuilder
                                query_debito_p.Append("INSERT INTO [tactical_discount_sr_agro].[dbo].[nd_ajuste_p] ")
                                query_debito_p.Append("([ID_AJUSTE],[NUM_PART],[CVE_ART],[DESCRIPCION],[MOTIVO],[CANTIDAD], ")
                                query_debito_p.Append("[FECHA_INGRESO],[COSTO_ANTERIOR],[COSTO_ACTUAL],[AJUSTE],[UNI]) ")
                                query_debito_p.Append("VALUES ")
                                query_debito_p.Append("(@ID_AJUSTE,@NUM_PART,@CVE_ART,@DESCRIPCION,@MOTIVO,@CANTIDAD, ")
                                query_debito_p.Append("@FECHA_INGRESO,@COSTO_ANTERIOR,@COSTO_ACTUAL,@AJUSTE,@UNI)")
                                Dim comando_debito_p As New SqlCommand(query_debito_p.ToString, sql_con)
                                comando_debito_p.Parameters.AddWithValue("@ID_AJUSTE", dt_folio_debito.Rows(0)(0))
                                comando_debito_p.Parameters.AddWithValue("@NUM_PART", index + 1)
                                comando_debito_p.Parameters.AddWithValue("@CVE_ART", dt_partidas.Rows(index)(2))
                                comando_debito_p.Parameters.AddWithValue("@DESCRIPCION", dt_partidas.Rows(index)(3))
                                comando_debito_p.Parameters.AddWithValue("@MOTIVO", "AJUSTE DE PRECIO")
                                comando_debito_p.Parameters.AddWithValue("@CANTIDAD", dt_partidas.Rows(index)(29) - dt_partidas.Rows(index)(5))
                                comando_debito_p.Parameters.AddWithValue("@FECHA_INGRESO", Convert.ToDateTime(dt_encabezados.Rows(0)(5)))
                                comando_debito_p.Parameters.AddWithValue("@COSTO_ANTERIOR", dt_partidas.Rows(index)(6))
                                comando_debito_p.Parameters.AddWithValue("@COSTO_ACTUAL", dt_partidas.Rows(index)(7))
                                Dim valor_ajuste As Double = 0
                                valor_ajuste = (dt_partidas.Rows(index)(29) - Convert.ToDouble(dt_partidas.Rows(index)(5)) * Convert.ToDouble(dt_partidas.Rows(index)(6))) - _
                                               (dt_partidas.Rows(index)(29) - Convert.ToDouble(dt_partidas.Rows(index)(5)) * Convert.ToDouble(dt_partidas.Rows(index)(7)))
                                If dt_partidas.Rows(index)(1) = "cj" Then
                                    valor_ajuste = valor_ajuste * Convert.ToDouble(dt_partidas.Rows(index)(4))
                                End If
                                comando_debito_p.Parameters.AddWithValue("@AJUSTE", Math.Abs(valor_ajuste))
                                comando_debito_p.Parameters.AddWithValue("@UNI", dt_partidas.Rows(index)(1))

                                subtotal_debito_e += valor_ajuste
                                descuento_debito_e += 0 'valor_ajuste * dt_p.Rows(index)(7) / 100
                                valor_ajuste = valor_ajuste - descuento_debito_e
                                isv_debito_e += valor_ajuste * dt_partidas.Rows(index)(9) / 100
                                comando_debito_p.Transaction = mi_transaccion
                                comando_debito_p.ExecuteNonQuery()
                            End If
                        Next
                        total_debito_e += subtotal_debito_e - descuento_debito_e + isv_debito_e

                        Dim query_debito_e As New StringBuilder
                        query_debito_e.Append("INSERT INTO [tactical_discount_sr_agro].[dbo].[nd_ajuste_e] ")
                        query_debito_e.Append("([ID_AJUSTE],[CVE_PROVEEDOR],[ALMACEN],[REF_PROV]")
                        query_debito_e.Append(",[FECHA],[N_FACTURA],[SUBTOTAL],[DESCUENTO],[ISV],[TOTAL],[COMPRA],[TIPO]) ")
                        query_debito_e.Append("VALUES ")
                        query_debito_e.Append("(@ID_AJUSTE,@CVE_PROVEEDOR,@ALMACEN,@REF_PROV,@FECHA, ")
                        query_debito_e.Append("@N_FACTURA,@SUBTOTAL,@DESCUENTO,@ISV,@TOTAL,@COMPRA,@TIPO)")
                        Dim comando_debito_e As New SqlCommand(query_debito_e.ToString, sql_con)
                        comando_debito_e.Parameters.AddWithValue("@ID_AJUSTE", dt_folio_debito.Rows(0)(0))
                        comando_debito_e.Parameters.AddWithValue("@CVE_PROVEEDOR", dt_encabezados.Rows(0)(0))
                        comando_debito_e.Parameters.AddWithValue("@ALMACEN", dt_encabezados.Rows(0)(2))
                        comando_debito_e.Parameters.AddWithValue("@REF_PROV", dt_encabezados.Rows(0)(3))
                        comando_debito_e.Parameters.AddWithValue("@FECHA", Convert.ToDateTime(dt_encabezados.Rows(0)(5)))
                        comando_debito_e.Parameters.AddWithValue("@N_FACTURA", dt_encabezados.Rows(0)(12))
                        comando_debito_e.Parameters.AddWithValue("@SUBTOTAL", Math.Abs(subtotal_debito_e))
                        comando_debito_e.Parameters.AddWithValue("@DESCUENTO", Math.Abs(descuento_debito_e))
                        comando_debito_e.Parameters.AddWithValue("@ISV", Math.Abs(isv_debito_e))
                        comando_debito_e.Parameters.AddWithValue("@TOTAL", Math.Abs(total_debito_e))
                        comando_debito_e.Parameters.AddWithValue("@COMPRA", dt_encabezados.Rows(0)(28))
                        comando_debito_e.Parameters.AddWithValue("@TIPO", "CREDITO")
                        comando_debito_e.Transaction = mi_transaccion
                        comando_debito_e.ExecuteNonQuery()

                        Dim query_upd_folio_ajuste As New StringBuilder
                        query_upd_folio_ajuste.Append("UPDATE [tactical_discount_sr_agro].[dbo].[nd_folios] ")
                        query_upd_folio_ajuste.Append("   SET [ULT_DOC] = ULT_DOC+1 ")
                        query_upd_folio_ajuste.Append("WHERE [NUM_ALMA] = @NUM_ALMA AND TIPO = 'D' ")
                        Dim comando_upd_folio_ajuste As New SqlCommand(query_upd_folio_ajuste.ToString, sql_con)
                        comando_upd_folio_ajuste.Parameters.AddWithValue("@NUM_ALMA", dt_encabezados.Rows(0)(2))
                        comando_upd_folio_ajuste.Transaction = mi_transaccion
                        comando_upd_folio_ajuste.ExecuteNonQuery()

                        Dim query_opaga As New StringBuilder
                        query_opaga.Append("INSERT INTO [SAE60Empre02].[dbo].[OPAGA02] ")
                        query_opaga.Append("([CVE_OBS],[STR_OBS]) ")
                        query_opaga.Append("VALUES ((SELECT ULT_CVE + 1 AS ULT_CVE FROM SAE60EMPRE02.dbo.TBLCONTROL02 WHERE (ID_TABLA = 21)),'NOTA DE CREDITO POR PRECIO MENOR DEL PROVEEDOR')")
                        Dim comando_opaga As New SqlCommand(query_opaga.ToString, sql_con)
                        comando_opaga.Transaction = mi_transaccion
                        comando_opaga.ExecuteNonQuery()

                        Dim query_paga_det As New StringBuilder
                        query_paga_det.Append("INSERT INTO [SAE60Empre02].[dbo].[PAGA_DET02] ")
                        query_paga_det.Append("([CVE_PROV],[REFER],[NUM_CPTO],[NUM_CARGO],[ID_MOV] ")
                        query_paga_det.Append(",[CVE_OBS],[NO_FACTURA],[DOCTO],[IMPORTE],[FECHA_APLI],[FECHA_VENC] ")
                        query_paga_det.Append(",[NUM_MONED],[TCAMBIO],[IMPMON_EXT],[FECHAELAB] ")
                        query_paga_det.Append(",[TIPO_MOV],[SIGNO],[USUARIO] ")
                        query_paga_det.Append(",[NO_PARTIDA]) ")
                        query_paga_det.Append("VALUES ")
                        query_paga_det.Append("(@CVE_PROV, @REFER, 29,1,1, (SELECT ULT_CVE + 1 AS ULT_CVE FROM SAE60EMPRE02.dbo.TBLCONTROL02 WHERE (ID_TABLA = 21)), ")
                        query_paga_det.Append("@NO_FACTURA, @DOCTO, @IMPORTE, @FECHA_APLI, @FECHA_VENC, 1, ")
                        query_paga_det.Append("1, @IMPMON_EXT, @FECHAELAB,'A', -1,0, 1) ")
                        Dim comando_paga_det As New SqlCommand(query_paga_det.ToString, sql_con)
                        comando_paga_det.Parameters.AddWithValue("@CVE_PROV", dt_encabezados.Rows(0)(0))
                        comando_paga_det.Parameters.AddWithValue("@REFER", dt_encabezados.Rows(0)(12))
                        comando_paga_det.Parameters.AddWithValue("@NO_FACTURA", dt_encabezados.Rows(0)(12))
                        comando_paga_det.Parameters.AddWithValue("@DOCTO", dt_encabezados.Rows(0)(12))
                        comando_paga_det.Parameters.AddWithValue("@IMPORTE", Math.Abs(total_debito_e) * dt_encabezados.Rows(0)(11))
                        comando_paga_det.Parameters.AddWithValue("@FECHA_APLI", Convert.ToDateTime(dt_encabezados.Rows(0)(5)))
                        comando_paga_det.Parameters.AddWithValue("@FECHA_VENC", Convert.ToDateTime(dt_encabezados.Rows(0)(18)))
                        comando_paga_det.Parameters.AddWithValue("@IMPMON_EXT", Math.Abs(total_debito_e))
                        comando_paga_det.Parameters.AddWithValue("@FECHAELAB", Convert.ToDateTime(dt_encabezados.Rows(0)(5)))
                        comando_paga_det.Transaction = mi_transaccion
                        comando_paga_det.ExecuteNonQuery()

                        Dim query_upd_paga_det As New StringBuilder
                        query_upd_paga_det.Append("UPDATE [SAE60Empre02].[dbo].[TBLCONTROL02] ")
                        query_upd_paga_det.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                        query_upd_paga_det.Append("WHERE ([ID_TABLA] = 21)")
                        Dim comando_upd_paga_det As New SqlCommand(query_upd_paga_det.ToString, sql_con)
                        comando_upd_paga_det.Transaction = mi_transaccion
                        comando_upd_paga_det.ExecuteNonQuery()
                    End If
                    ' fin registra los creditos por producto

                End If

                Dim conexion_bita As New cls_bitacora_reporteador
                conexion_bita.RegistraBitacora(Now, usuario, "Ingreso Devolucion de Compra ", "COMPRAS", _
                                          "Fecha: " + Convert.ToDateTime(dt_encabezados.Rows(0)(5)) + " Numero de devolucion SAE: " + CVE_DOC + _
                                          " Numero de Compra Rep:" + CVE_COMPRA + " almacen:" + dt_encabezados.Rows(0)(2))

                mi_transaccion.Commit()
                sql_con.Close()
                Return "correcto"
            End If
        Catch ex As Exception
            mi_transaccion.Rollback()
            sql_con.Close()
            Dim tamaño As Integer = Convert.ToString(ex.StackTrace).Length
            Dim posicion As Integer = InStrRev(Convert.ToString(ex.StackTrace), "línea") - 1
            Dim inicial As Integer = tamaño - posicion
            Dim linea_error As String = Convert.ToString(ex.StackTrace).Substring(tamaño - inicial, inicial)
            Return (ex.Message + " --> " + linea_error)
        End Try
    End Function
End Class
