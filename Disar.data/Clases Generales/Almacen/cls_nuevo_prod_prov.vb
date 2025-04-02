Imports System.Data.SqlClient
Imports System.Text

Public Class cls_nuevo_prod_prov
    Dim Conexion As New clsConexion
    Dim Conexion2 As New clsconexion_consumo


    Public Function Insert(ByVal empresa As String, ByVal dt As DataTable, ByVal usuario As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        ActualizarConexion.Open()
        Dim trasaccion As SqlTransaction
        trasaccion = ActualizarConexion.BeginTransaction
        Try
            Dim query As New StringBuilder
            Dim query2 As New StringBuilder
            Dim query4 As New StringBuilder

            If empresa = "SAN RAFAEL" Then
                query.Append("INSERT INTO [SAE60Empre05].[dbo].[PROV05] ")
                query2.Append("INSERT INTO  [SAE60Empre05].[dbo].[PROV_CLIB05] ")
                query4.Append("INSERT INTO [SAE60Empre05].[dbo].[CLIN05] ")
            ElseIf empresa = "SR AGRO" Then
                query.Append("INSERT INTO [SAE60Empre02].[dbo].[PROV02] ")
                query2.Append("INSERT INTO [SAE60Empre02].[dbo].[PROV_CLIB02] ")
                query4.Append("INSERT INTO [SAE60Empre02].[dbo].[CLIN02] ")
            ElseIf empresa = "DIMOSA" Then
                query.Append("INSERT INTO [SAE60Empre06].[dbo].[PROV06] ")
                query2.Append("INSERT INTO [SAE60Empre06].[dbo].[PROV_CLIB06] ")
                query4.Append("INSERT INTO [SAE60Empre06].[dbo].[CLIN06] ")
            End If

            query4.Append("([CVE_LIN],[DESC_LIN],[ESUNGPO],[CUENTA_COI],[STATUS]) ")
            query4.Append("VALUES (@CVE_LIN,@DESC_LIN,'N','','A') ")
            Dim miComando4 As New SqlCommand(query4.ToString(), ActualizarConexion)
            miComando4.Parameters.AddWithValue("@CVE_LIN", dt.Rows(0)(0).ToString().Trim())

            If dt.Rows(0)(1).ToString().Length > 19 Then
                miComando4.Parameters.AddWithValue("@DESC_LIN", dt.Rows(0)(1).ToString().Substring(0, 18))
            Else
                miComando4.Parameters.AddWithValue("@DESC_LIN", dt.Rows(0)(1))
            End If
            miComando4.Transaction = trasaccion
            miComando4.ExecuteNonQuery()

            query.Append("([CLAVE],[STATUS],[NOMBRE],[RFC],[CALLE],[NUMINT],[NUMEXT],[CRUZAMIENTOS],[CRUZAMIENTOS2],[COLONIA], ")
            query.Append("[CODIGO], [LOCALIDAD], [MUNICIPIO], [ESTADO], [CVE_PAIS], [NACIONALIDAD], [TELEFONO], [CLASIFIC], [FAX], [PAG_WEB], ")
            query.Append("[CURP], [CVE_ZONA], [CON_CREDITO], [DIASCRED], [LIMCRED], [CVE_BITA], [ULT_PAGOD], [ULT_PAGOM], [ULT_PAGOF], ")
            query.Append("[ULT_COMPD], [ULT_COMPM], [ULT_COMPF], [SALDO], [VENTAS], [DESCUENTO], [TIP_TERCERO], [TIP_OPERA], [CVE_OBS], ")
            query.Append("[CUENTA_CONTABLE], [FORMA_PAGO], [BENEFICIARIO], [TITULAR_CUENTA], [BANCO], [SUCURSAL_BANCO], [CUENTA_BANCO], ")
            query.Append("[CLABE],[DESC_OTROS],[IMPRIR],[MAIL],[NIVELSEC],[ENVIOSILEN],[EMAILPRED],[MODELO],[LAT],[LON]) ")
            query.Append("VALUES  ")
            query.Append("(@CLAVE,@STATUS,@NOMBRE,@RFC,@CALLE,@NUMINT,@NUMEXT,@CRUZAMIENTOS,@CRUZAMIENTOS2,@COLONIA,@CODIGO,@LOCALIDAD, ")
            query.Append("@MUNICIPIO,@ESTADO,@CVE_PAIS,@NACIONALIDAD,@TELEFONO,@CLASIFIC,@FAX,@PAG_WEB,@CURP,@CVE_ZONA,@CON_CREDITO,@DIASCRED, ")
            query.Append("@LIMCRED,@CVE_BITA,@ULT_PAGOD,@ULT_PAGOM,@ULT_PAGOF,@ULT_COMPD,@ULT_COMPM,@ULT_COMPF,@SALDO,@VENTAS,@DESCUENTO, ")
            query.Append("@TIP_TERCERO,@TIP_OPERA,@CVE_OBS,@CUENTA_CONTABLE,@FORMA_PAGO,@BENEFICIARIO,@TITULAR_CUENTA,@BANCO,@SUCURSAL_BANCO, ")
            query.Append("@CUENTA_BANCO,@CLABE,@DESC_OTROS,@IMPRIR,@MAIL,@NIVELSEC,@ENVIOSILEN,@EMAILPRED,@MODELO,@LAT,@LON)")

            Dim miComando As New SqlCommand(query.ToString(), ActualizarConexion)
            miComando.Parameters.AddWithValue("@CLAVE", dt.Rows(0)(0))
            miComando.Parameters.AddWithValue("@STATUS", "A")
            miComando.Parameters.AddWithValue("@NOMBRE", dt.Rows(0)(1))
            miComando.Parameters.AddWithValue("@RFC", dt.Rows(0)(2))
            miComando.Parameters.AddWithValue("@CALLE", dt.Rows(0)(3))
            miComando.Parameters.AddWithValue("@NUMINT", "")
            miComando.Parameters.AddWithValue("@NUMEXT", "")
            miComando.Parameters.AddWithValue("@CRUZAMIENTOS", "")
            miComando.Parameters.AddWithValue("@CRUZAMIENTOS2", "")
            miComando.Parameters.AddWithValue("@COLONIA", dt.Rows(0)(4))
            miComando.Parameters.AddWithValue("@CODIGO", dt.Rows(0)(5))
            miComando.Parameters.AddWithValue("@LOCALIDAD", dt.Rows(0)(6))
            miComando.Parameters.AddWithValue("@MUNICIPIO", dt.Rows(0)(7))
            miComando.Parameters.AddWithValue("@ESTADO", dt.Rows(0)(8))
            miComando.Parameters.AddWithValue("@CVE_PAIS", DBNull.Value)
            miComando.Parameters.AddWithValue("@NACIONALIDAD", dt.Rows(0)(9))
            miComando.Parameters.AddWithValue("@TELEFONO", dt.Rows(0)(10))
            miComando.Parameters.AddWithValue("@CLASIFIC", dt.Rows(0)(11))
            miComando.Parameters.AddWithValue("@FAX", dt.Rows(0)(12))
            miComando.Parameters.AddWithValue("@PAG_WEB", dt.Rows(0)(13))
            miComando.Parameters.AddWithValue("@CURP", dt.Rows(0)(14))
            miComando.Parameters.AddWithValue("@CVE_ZONA", DBNull.Value)
            miComando.Parameters.AddWithValue("@CON_CREDITO", dt.Rows(0)(15))
            miComando.Parameters.AddWithValue("@DIASCRED", dt.Rows(0)(16))
            miComando.Parameters.AddWithValue("@LIMCRED", dt.Rows(0)(17))
            miComando.Parameters.AddWithValue("@CVE_BITA", DBNull.Value)
            miComando.Parameters.AddWithValue("@ULT_PAGOD", DBNull.Value)
            miComando.Parameters.AddWithValue("@ULT_PAGOM", 0)
            miComando.Parameters.AddWithValue("@ULT_PAGOF", DBNull.Value)
            miComando.Parameters.AddWithValue("@ULT_COMPD", DBNull.Value)
            miComando.Parameters.AddWithValue("@ULT_COMPM", 0)
            miComando.Parameters.AddWithValue("@ULT_COMPF", DBNull.Value)
            miComando.Parameters.AddWithValue("@SALDO", 0)
            miComando.Parameters.AddWithValue("@VENTAS", 0)
            miComando.Parameters.AddWithValue("@DESCUENTO", 0)
            miComando.Parameters.AddWithValue("@TIP_TERCERO", 4)
            miComando.Parameters.AddWithValue("@TIP_OPERA", 85)
            miComando.Parameters.AddWithValue("@CVE_OBS", 0)
            miComando.Parameters.AddWithValue("@CUENTA_CONTABLE", DBNull.Value)
            miComando.Parameters.AddWithValue("@FORMA_PAGO", 0)
            miComando.Parameters.AddWithValue("@BENEFICIARIO", DBNull.Value)
            miComando.Parameters.AddWithValue("@TITULAR_CUENTA", DBNull.Value)
            miComando.Parameters.AddWithValue("@BANCO", -1)
            miComando.Parameters.AddWithValue("@SUCURSAL_BANCO", DBNull.Value)
            miComando.Parameters.AddWithValue("@CUENTA_BANCO", DBNull.Value)
            miComando.Parameters.AddWithValue("@CLABE", DBNull.Value)
            miComando.Parameters.AddWithValue("@DESC_OTROS", DBNull.Value)
            miComando.Parameters.AddWithValue("@IMPRIR", "S")
            miComando.Parameters.AddWithValue("@MAIL", DBNull.Value)
            miComando.Parameters.AddWithValue("@NIVELSEC", DBNull.Value)
            miComando.Parameters.AddWithValue("@ENVIOSILEN", DBNull.Value)
            miComando.Parameters.AddWithValue("@EMAILPRED", DBNull.Value)
            miComando.Parameters.AddWithValue("@MODELO", DBNull.Value)
            miComando.Parameters.AddWithValue("@LAT", 0)
            miComando.Parameters.AddWithValue("@LON", 0)
            miComando.Transaction = trasaccion
            miComando.ExecuteNonQuery()


            query2.Append("([CVE_PROV],[CAMPLIB8],[CAMPLIB9],[CAMPLIB10],[CAMPLIB11],[CAMPLIB12],[CAMPLIB13],[CAMPLIB14]) ")
            query2.Append("VALUES (@CVE_PROV,@CAMPLIB8,@CAMPLIB9,@CAMPLIB10,@CAMPLIB11,@CAMPLIB12,@CAMPLIB13,@CAMPLIB14) ")

            Dim miComando2 As New SqlCommand(query2.ToString(), ActualizarConexion)
            miComando2.Parameters.AddWithValue("@CVE_PROV", dt.Rows(0)(0))
            miComando2.Parameters.AddWithValue("@CAMPLIB8", dt.Rows(0)(15))
            miComando2.Parameters.AddWithValue("@CAMPLIB9", dt.Rows(0)(16))
            miComando2.Parameters.AddWithValue("@CAMPLIB10", dt.Rows(0)(18))
            miComando2.Parameters.AddWithValue("@CAMPLIB11", Convert.ToDateTime(dt.Rows(0)(20)))
            miComando2.Parameters.AddWithValue("@CAMPLIB12", dt.Rows(0)(19))
            miComando2.Parameters.AddWithValue("@CAMPLIB13", dt.Rows(0)(10))
            miComando2.Parameters.AddWithValue("@CAMPLIB14", DBNull.Value)
            miComando2.Transaction = trasaccion
            miComando2.ExecuteNonQuery()

            Dim query3 As New StringBuilder
            query3.Append("INSERT INTO [dbo].[PROV_NUEVOS] ")
            query3.Append("([codigo],[nombre],[calle],[departamento],[municipio],[rtn],[tipo],[pais],[manejo_credito],[dias_credito],[lim_credito] ")
            query3.Append(",[forma_pago],[tipo_tercero],[cai],[fecha_limite],[rango],[telefono],[clasificacion],[contacto_pago],[contacto_compra],[empresa],[usuario],[fecha_elab]) ")
            query3.Append("VALUES ")
            query3.Append("(@codigo,@nombre,@calle,@departamento,@municipio,@rtn,@tipo,@pais,@manejo_credito,@dias_credito,@lim_credito,@forma_pago ")
            query3.Append(",@tipo_tercero,@cai,@fecha_limite,@rango,@telefono,@clasificacion,@contacto_pago,@contacto_compra,@empresa,@usuario,@fecha_elab) ")
            Dim miComando3 As New SqlCommand(query3.ToString(), ActualizarConexion)
            miComando3.Parameters.AddWithValue("@codigo", dt.Rows(0)(0))
            miComando3.Parameters.AddWithValue("@nombre", dt.Rows(0)(1))
            miComando3.Parameters.AddWithValue("@calle", dt.Rows(0)(3))
            miComando3.Parameters.AddWithValue("@departamento", dt.Rows(0)(2))
            miComando3.Parameters.AddWithValue("@municipio", dt.Rows(0)(6))
            miComando3.Parameters.AddWithValue("@rtn", dt.Rows(0)(21))
            miComando3.Parameters.AddWithValue("@tipo", dt.Rows(0)(9))
            miComando3.Parameters.AddWithValue("@pais", dt.Rows(0)(22))
            miComando3.Parameters.AddWithValue("@manejo_credito", dt.Rows(0)(15))
            miComando3.Parameters.AddWithValue("@dias_credito", dt.Rows(0)(16))
            miComando3.Parameters.AddWithValue("@lim_credito", dt.Rows(0)(17))
            miComando3.Parameters.AddWithValue("@forma_pago", dt.Rows(0)(23))
            miComando3.Parameters.AddWithValue("@tipo_tercero", dt.Rows(0)(24))
            miComando3.Parameters.AddWithValue("@cai", dt.Rows(0)(18))
            miComando3.Parameters.AddWithValue("@fecha_limite", dt.Rows(0)(20))
            miComando3.Parameters.AddWithValue("@rango", dt.Rows(0)(19))
            miComando3.Parameters.AddWithValue("@telefono", dt.Rows(0)(10))
            miComando3.Parameters.AddWithValue("@clasificacion", dt.Rows(0)(11))
            miComando3.Parameters.AddWithValue("@contacto_pago", dt.Rows(0)(25))
            miComando3.Parameters.AddWithValue("@contacto_compra", dt.Rows(0)(26))
            miComando3.Parameters.AddWithValue("@empresa", empresa)
            miComando3.Parameters.AddWithValue("@usuario", usuario)
            miComando3.Parameters.AddWithValue("@fecha_elab", Now.Date)
            miComando3.Transaction = trasaccion

            miComando3.ExecuteNonQuery()
            trasaccion.Commit()
            ActualizarConexion.Close()
            Return "correcto"
        Catch ex As Exception
            trasaccion.Rollback()
            ActualizarConexion.Close()
            Return ex.Message
        End Try
    End Function

    Public Function SELEC(ByVal empresa As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        ActualizarConexion.Open()
        Dim query As New StringBuilder
        If empresa = "SAN RAFAEL" Then
            query.Append("SELECT MAX(CLAVE)+1  AS ID FROM SAE60Empre05.dbo.PROV05")
        ElseIf empresa = "SR AGRO" Then
            query.Append("SELECT MAX(CLAVE)+1  AS ID FROM SAE60Empre02.dbo.PROV02")
        ElseIf empresa = "DIMOSA" Then
            query.Append("SELECT MAX(CLAVE)+1  AS ID FROM SAE60Empre06.dbo.PROV06")
        End If

        Dim comando As New SqlCommand(query.ToString(), ActualizarConexion)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dt_sel As New DataTable
        adaptador.Fill(dt_sel)
        Return dt_sel.Rows(0)(0)
    End Function

    Public Function LISTAR_LINEAS(ByVal empresa As String, ByVal BUSCAR As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        ActualizarConexion.Open()
        Dim query As New StringBuilder
        If empresa = "SAN RAFAEL" Then
            query.Append("SELECT CVE_LIN, DESC_LIN FROM SAE60Empre05.dbo.CLIN05 WHERE (STATUS = 'A') ")
            query.Append("AND DESC_LIN LIKE '%' + @BUSCAR + '%'")
        ElseIf empresa = "SR AGRO" Then
            query.Append("SELECT CVE_LIN, DESC_LIN FROM SAE60Empre02.dbo.CLIN02 WHERE (STATUS = 'A') ")
            query.Append("AND DESC_LIN LIKE '%' + @BUSCAR + '%'")
        ElseIf empresa = "DIMOSA" Then
            query.Append("SELECT CVE_LIN, DESC_LIN FROM SAE60Empre06.dbo.CLIN06 WHERE (STATUS = 'A') ")
            query.Append("AND DESC_LIN LIKE '%' + @BUSCAR + '%'")
        End If

        Dim comando As New SqlCommand(query.ToString(), ActualizarConexion)
        comando.Parameters.AddWithValue("@BUSCAR", BUSCAR)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dt_sel As New DataTable
        adaptador.Fill(dt_sel)
        Return dt_sel
    End Function

    Public Function LISTAR_PROVEEDOR(ByVal empresa As String, ByVal BUSCAR As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        ActualizarConexion.Open()
        Dim query As New StringBuilder
        If empresa = "SAN RAFAEL" Then
            query.Append("SELECT CLAVE, NOMBRE FROM SAE60Empre05.dbo.PROV05 WHERE (STATUS = 'A') ")
            query.Append("AND NOMBRE LIKE '%' + @BUSCAR + '%'")
        ElseIf empresa = "SR AGRO" Then
            query.Append("SELECT CLAVE, NOMBRE FROM SAE60Empre02.dbo.PROV02 WHERE (STATUS = 'A') ")
            query.Append("AND NOMBRE LIKE '%' + @BUSCAR + '%'")
        ElseIf empresa = "DIMOSA" Then
            query.Append("SELECT CLAVE, NOMBRE FROM SAE60Empre06.dbo.PROV06 WHERE (STATUS = 'A') ")
            query.Append("AND NOMBRE LIKE '%' + @BUSCAR + '%'")
        End If

        Dim comando As New SqlCommand(query.ToString(), ActualizarConexion)
        comando.Parameters.AddWithValue("@BUSCAR", BUSCAR)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dt_sel As New DataTable
        adaptador.Fill(dt_sel)
        Return dt_sel
    End Function

    Public Function LISTAR_ALMACENES(ByVal empresa As String, ByVal BUSCAR As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        ActualizarConexion.Open()
        Dim query As New StringBuilder
        If empresa = "SAN RAFAEL" Then
            query.Append("SELECT CVE_ALM AS CLAVE, DESCR AS ALMACEN ")
            query.Append("FROM SAE60Empre05.dbo.ALMACENES05 ")
        ElseIf empresa = "SR AGRO" Then
            query.Append("SELECT CVE_ALM AS CLAVE, DESCR AS ALMACEN ")
            query.Append("FROM SAE60Empre02.dbo.ALMACENES02 ")
        ElseIf empresa = "DIMOSA" Then
            query.Append("SELECT CVE_ALM AS CLAVE, DESCR AS ALMACEN ")
            query.Append("FROM SAE60Empre06.dbo.ALMACENES06 ")
        End If

        Dim comando As New SqlCommand(query.ToString(), ActualizarConexion)
        comando.Parameters.AddWithValue("@BUSCAR", BUSCAR)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dt_sel As New DataTable
        adaptador.Fill(dt_sel)
        Return dt_sel
    End Function

    Public Function LISTAR_CATEGORIA(ByVal empresa As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        ActualizarConexion.Open()
        Dim query As New StringBuilder
        If empresa = "SAN RAFAEL" Then
            query.Append("SELECT DISTINCT CAMPLIB13 AS C FROM SAE60Empre05.dbo.INVE_CLIB05 WHERE ISNULL(CAMPLIB13,'0') <> '0' OR CAMPLIB13 <> '' ")
        ElseIf empresa = "SR AGRO" Then
            query.Append("SELECT DISTINCT CAMPLIB2 AS C FROM SAE60Empre02.dbo.INVE_CLIB02 WHERE ISNULL(CAMPLIB2,'0') <> '0' OR CAMPLIB2 <> '' ")
        ElseIf empresa = "DIMOSA" Then
            query.Append("SELECT DISTINCT CAMPLIB13 AS C FROM SAE60Empre06.dbo.INVE_CLIB06 WHERE ISNULL(CAMPLIB13,'0') <> '0' OR CAMPLIB13 <> '' ")
        End If

        Dim comando As New SqlCommand(query.ToString(), ActualizarConexion)

        Dim adaptador As New SqlDataAdapter(comando)
        Dim dt_sel As New DataTable
        adaptador.Fill(dt_sel)
        Return dt_sel
    End Function

    Public Function LISTAR_SUBCATEGORIA(ByVal empresa As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        ActualizarConexion.Open()
        Dim query As New StringBuilder
        If empresa = "SAN RAFAEL" Then
            query.Append("SELECT DISTINCT CAMPLIB14 AS C FROM SAE60Empre05.dbo.INVE_CLIB05 WHERE ISNULL(CAMPLIB14,'0') <> '0' OR CAMPLIB14 <> '' ")
        ElseIf empresa = "SR AGRO" Then
            query.Append("SELECT DISTINCT CAMPLIB3 AS C FROM SAE60Empre02.dbo.INVE_CLIB02  WHERE ISNULL(CAMPLIB3,'0') <> '0' OR CAMPLIB3 <> '' ")
        ElseIf empresa = "DIMOSA" Then
            query.Append("SELECT DISTINCT CAMPLIB14 AS C FROM SAE60Empre06.dbo.INVE_CLIB06  WHERE ISNULL(CAMPLIB14,'0') <> '0' OR CAMPLIB14 <> '' ")
        End If

        Dim comando As New SqlCommand(query.ToString(), ActualizarConexion)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dt_sel As New DataTable
        adaptador.Fill(dt_sel)
        Return dt_sel
    End Function

    Public Function LISTAR_MEGACATEGORIA(ByVal empresa As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        ActualizarConexion.Open()
        Dim query As New StringBuilder
        If empresa = "SAN RAFAEL" Then
            query.Append("SELECT DISTINCT CAMPLIB14 AS C FROM SAE60Empre05.dbo.INVE_CLIB05 WHERE ISNULL(CAMPLIB14,'0') <> '0' OR CAMPLIB14 <> ''  ")
        ElseIf empresa = "SR AGRO" Then
            query.Append("SELECT DISTINCT CAMPLIB7 AS C FROM SAE60Empre02.dbo.INVE_CLIB02 WHERE ISNULL(CAMPLIB7,'0') <> '0' OR CAMPLIB7 <> ''   ")
        ElseIf empresa = "DIMOSA" Then
            query.Append("SELECT DISTINCT CAMPLIB14 AS C FROM SAE60Empre06.dbo.INVE_CLIB06 WHERE ISNULL(CAMPLIB14,'0') <> '0' OR CAMPLIB14 <> ''   ")
        End If

        Dim comando As New SqlCommand(query.ToString(), ActualizarConexion)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dt_sel As New DataTable
        adaptador.Fill(dt_sel)
        Return dt_sel
    End Function

    Public Function Insert_prod(ByVal empresa As String, ByVal CODIGO As String, ByVal ALTERNO As String, _
                                ByVal PALETIZADO_SRC As String, ByVal PALETIZADO_SPS As String, ByVal UBICACION As String, _
                                ByVal CODIGO_BARRA As String, ByVal CODIGO_BARRA_CJ As String, ByVal UBICACION_SRC As String, _
                                ByVal UBICACION_TOCOA As String, ByVal CATEGORIA As String, ByVal SUB_CATEGORIA As String, _
                                ByVal PALETIZADO_AGRO As String, ByVal UBICACION_TEGUS As String, ByVal MEGACATEGORIA As String, _
                                ByVal dt_precio As DataTable, ByVal DESCRIPCION As String, ByVal COD_PROV As String, _
                                ByVal LINEA As String, ByVal ENTRADA As String, ByVal EMPAQUE As Integer, ByVal SALIDA As String, _
                                ByVal FACTOR As Integer, ByVal CON_LOTE As String, ByVal PESO As Double, ByVal VOLUMEN As Double, _
                                ByVal ESQUEMA As Integer, ByVal dt_mult As DataTable, ByVal usuario As String)

        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        ActualizarConexion.Open()
        Dim trasaccion As SqlTransaction
        trasaccion = ActualizarConexion.BeginTransaction
        Try
            If empresa = "SAN RAFAEL" Then
                Dim query1 As New StringBuilder
                query1.Append("INSERT INTO [SAE60Empre05].[dbo].[INVE_CLIB05] ")
                query1.Append("([CVE_PROD],[CAMPLIB1],[CAMPLIB2],[CAMPLIB3],[CAMPLIB4],[CAMPLIB5],[CAMPLIB6],[CAMPLIB7],[CAMPLIB8] ")
                query1.Append(",[CAMPLIB9],[CAMPLIB10],[CAMPLIB11],[CAMPLIB12],[CAMPLIB13],[CAMPLIB14],[CAMPLIB15],[CAMPLIB16],[CAMPLIB17],[CAMPLIB18]) ")
                query1.Append("VALUES ")
                query1.Append("(@CVE_PROD,@CAMPLIB1,@CAMPLIB2,@CAMPLIB3,@CAMPLIB4,@CAMPLIB5,@CAMPLIB6,@CAMPLIB7,@CAMPLIB8,@CAMPLIB9,@CAMPLIB10,@CAMPLIB11 ")
                query1.Append(",@CAMPLIB12,@CAMPLIB13,@CAMPLIB14,@CAMPLIB15,@CAMPLIB16,@CAMPLIB17,@CAMPLIB18) ")

                Dim comando_libres As New SqlCommand(query1.ToString, ActualizarConexion)
                comando_libres.Parameters.AddWithValue("@CVE_PROD", CODIGO)
                comando_libres.Parameters.AddWithValue("@CAMPLIB1", ALTERNO)
                comando_libres.Parameters.AddWithValue("@CAMPLIB2", "")
                comando_libres.Parameters.AddWithValue("@CAMPLIB3", "")
                comando_libres.Parameters.AddWithValue("@CAMPLIB4", PALETIZADO_SRC)
                comando_libres.Parameters.AddWithValue("@CAMPLIB5", PALETIZADO_SPS)
                comando_libres.Parameters.AddWithValue("@CAMPLIB6", "")
                comando_libres.Parameters.AddWithValue("@CAMPLIB7", "")
                comando_libres.Parameters.AddWithValue("@CAMPLIB8", UBICACION)
                comando_libres.Parameters.AddWithValue("@CAMPLIB9", CODIGO_BARRA)
                comando_libres.Parameters.AddWithValue("@CAMPLIB10", CODIGO_BARRA_CJ)
                comando_libres.Parameters.AddWithValue("@CAMPLIB11", UBICACION_SRC)
                comando_libres.Parameters.AddWithValue("@CAMPLIB12", UBICACION_TOCOA)
                comando_libres.Parameters.AddWithValue("@CAMPLIB13", CATEGORIA)
                comando_libres.Parameters.AddWithValue("@CAMPLIB14", SUB_CATEGORIA)
                comando_libres.Parameters.AddWithValue("@CAMPLIB15", "")
                comando_libres.Parameters.AddWithValue("@CAMPLIB16", "")
                comando_libres.Parameters.AddWithValue("@CAMPLIB17", PALETIZADO_AGRO)
                comando_libres.Parameters.AddWithValue("@CAMPLIB18", UBICACION_TEGUS)
                comando_libres.Transaction = trasaccion
                comando_libres.ExecuteNonQuery()

                For index As Integer = 0 To dt_precio.Rows.Count - 1
                    Dim query_precios As New StringBuilder
                    query_precios.Append("INSERT INTO [SAE60Empre05].[dbo].[PRECIO_X_PROD05] ")
                    query_precios.Append(" ([CVE_ART],[CVE_PRECIO],[PRECIO],[UUID],[VERSION_SINC]) ")
                    query_precios.Append("VALUES (@CVE_ART,@CVE_PRECIO,@PRECIO,@UUID,@VERSION_SINC) ")
                    Dim comando_precios = New SqlCommand(query_precios.ToString, ActualizarConexion)
                    comando_precios.Parameters.AddWithValue("@CVE_ART", CODIGO)
                    comando_precios.Parameters.AddWithValue("@CVE_PRECIO", dt_precio.Rows(index)(0))
                    comando_precios.Parameters.AddWithValue("@PRECIO", dt_precio.Rows(index)(1))
                    comando_precios.Parameters.AddWithValue("@UUID", "")
                    comando_precios.Parameters.AddWithValue("@VERSION_SINC", Now.Date)
                    comando_precios.Transaction = trasaccion
                    comando_precios.ExecuteNonQuery()
                Next

                Dim query_prov_prod As New StringBuilder
                query_prov_prod.Append("INSERT INTO [SAE60Empre05].[dbo].[PRVPROD05] ")
                query_prov_prod.Append(" ([CVE_ART],[CVE_PROV],[COSTO],[T_ENTREGA]) ")
                query_prov_prod.Append("VALUES (@CVE_ART,@CVE_PROV,@COSTO,@T_ENTREGA) ")
                Dim comando_prov_prod = New SqlCommand(query_prov_prod.ToString, ActualizarConexion)
                comando_prov_prod.Parameters.AddWithValue("@CVE_ART", CODIGO)
                comando_prov_prod.Parameters.AddWithValue("@CVE_PROV", COD_PROV)
                comando_prov_prod.Parameters.AddWithValue("@COSTO", 0)
                comando_prov_prod.Parameters.AddWithValue("@T_ENTREGA", 0)
                comando_prov_prod.Transaction = trasaccion
                comando_prov_prod.ExecuteNonQuery()

                Dim query As New StringBuilder
                query.Append("INSERT INTO [SAE60Empre05].[dbo].[INVE05] ")
                query.Append(" ([CVE_ART],[DESCR],[LIN_PROD],[CON_SERIE],[UNI_MED],[UNI_EMP],[CTRL_ALM],[TIEM_SURT],[STOCK_MIN] ")
                query.Append(",[STOCK_MAX],[TIP_COSTEO],[NUM_MON],[FCH_ULTCOM],[COMP_X_REC],[FCH_ULTVTA],[PEND_SURT],[EXIST] ")
                query.Append(",[COSTO_PROM],[ULT_COSTO],[CVE_OBS],[TIPO_ELE],[UNI_ALT],[FAC_CONV],[APART],[CON_LOTE],[CON_PEDIMENTO] ")
                query.Append(",[PESO],[VOLUMEN],[CVE_ESQIMPU],[CVE_BITA],[VTAS_ANL_C],[VTAS_ANL_M],[COMP_ANL_C],[COMP_ANL_M],[PREFIJO] ")
                query.Append(",[TALLA],[COLOR],[CUENT_CONT],[CVE_IMAGEN],[BLK_CST_EXT],[STATUS],[MAN_IEPS],[APL_MAN_IMP],[CUOTA_IEPS] ")
                query.Append(",[APL_MAN_IEPS],[UUID],[VERSION_SINC],[VERSION_SINC_FECHA_IMG]) ")
                query.Append("VALUES ")
                query.Append("(@CVE_ART,@DESCR,@LIN_PROD,@CON_SERIE,@UNI_MED,@UNI_EMP,@CTRL_ALM,@TIEM_SURT,@STOCK_MIN,@STOCK_MAX, ")
                query.Append("@TIP_COSTEO,@NUM_MON,@FCH_ULTCOM,@COMP_X_REC,@FCH_ULTVTA,@PEND_SURT,@EXIST,@COSTO_PROM,@ULT_COSTO, ")
                query.Append("@CVE_OBS,@TIPO_ELE,@UNI_ALT,@FAC_CONV,@APART,@CON_LOTE,@CON_PEDIMENTO,@PESO,@VOLUMEN,@CVE_ESQIMPU, ")
                query.Append("@CVE_BITA,@VTAS_ANL_C,@VTAS_ANL_M,@COMP_ANL_C,@COMP_ANL_M,@PREFIJO,@TALLA,@COLOR,@CUENT_CONT,@CVE_IMAGEN, ")
                query.Append("@BLK_CST_EXT,@STATUS,@MAN_IEPS,@APL_MAN_IMP,@CUOTA_IEPS,@APL_MAN_IEPS,@UUID,@VERSION_SINC, ")
                query.Append("@VERSION_SINC_FECHA_IMG)")
                Dim miComando As New SqlCommand(query.ToString(), ActualizarConexion)
                miComando.Parameters.AddWithValue("@CVE_ART", CODIGO)
                miComando.Parameters.AddWithValue("@DESCR", DESCRIPCION)
                miComando.Parameters.AddWithValue("@LIN_PROD", LINEA)
                miComando.Parameters.AddWithValue("@CON_SERIE", "N")
                miComando.Parameters.AddWithValue("@UNI_MED", ENTRADA)
                miComando.Parameters.AddWithValue("@UNI_EMP", EMPAQUE)
                miComando.Parameters.AddWithValue("@CTRL_ALM", "")
                miComando.Parameters.AddWithValue("@TIEM_SURT", 0)
                miComando.Parameters.AddWithValue("@STOCK_MIN", 0)
                miComando.Parameters.AddWithValue("@STOCK_MAX", 0)
                miComando.Parameters.AddWithValue("@TIP_COSTEO", "P")
                miComando.Parameters.AddWithValue("@NUM_MON", 1)
                miComando.Parameters.AddWithValue("@FCH_ULTCOM", DBNull.Value)
                miComando.Parameters.AddWithValue("@COMP_X_REC", 0)
                miComando.Parameters.AddWithValue("@FCH_ULTVTA", DBNull.Value)
                miComando.Parameters.AddWithValue("@PEND_SURT", 0)
                miComando.Parameters.AddWithValue("@EXIST", 0)
                miComando.Parameters.AddWithValue("@COSTO_PROM", 0)
                miComando.Parameters.AddWithValue("@ULT_COSTO", 0)
                miComando.Parameters.AddWithValue("@CVE_OBS", 0)
                miComando.Parameters.AddWithValue("@TIPO_ELE", "P")
                miComando.Parameters.AddWithValue("@UNI_ALT", SALIDA)
                miComando.Parameters.AddWithValue("@FAC_CONV", FACTOR)
                miComando.Parameters.AddWithValue("@APART", 0)
                miComando.Parameters.AddWithValue("@CON_LOTE", CON_LOTE)
                miComando.Parameters.AddWithValue("@CON_PEDIMENTO", "N")
                miComando.Parameters.AddWithValue("@PESO", PESO)
                miComando.Parameters.AddWithValue("@VOLUMEN", VOLUMEN)
                miComando.Parameters.AddWithValue("@CVE_ESQIMPU", ESQUEMA)
                miComando.Parameters.AddWithValue("@CVE_BITA", 0)
                miComando.Parameters.AddWithValue("@VTAS_ANL_C", 0)
                miComando.Parameters.AddWithValue("@VTAS_ANL_M", 0)
                miComando.Parameters.AddWithValue("@COMP_ANL_C", 0)
                miComando.Parameters.AddWithValue("@COMP_ANL_M", 0)
                miComando.Parameters.AddWithValue("@PREFIJO", DBNull.Value)
                miComando.Parameters.AddWithValue("@TALLA", DBNull.Value)
                miComando.Parameters.AddWithValue("@COLOR", DBNull.Value)
                miComando.Parameters.AddWithValue("@CUENT_CONT", DBNull.Value)
                miComando.Parameters.AddWithValue("@CVE_IMAGEN", "")
                miComando.Parameters.AddWithValue("@BLK_CST_EXT", "N")
                miComando.Parameters.AddWithValue("@STATUS", "A")
                miComando.Parameters.AddWithValue("@MAN_IEPS", "N")
                miComando.Parameters.AddWithValue("@APL_MAN_IMP", 1)
                miComando.Parameters.AddWithValue("@CUOTA_IEPS", 0)
                miComando.Parameters.AddWithValue("@APL_MAN_IEPS", "C")
                miComando.Parameters.AddWithValue("@UUID", DBNull.Value)
                miComando.Parameters.AddWithValue("@VERSION_SINC", DBNull.Value)
                miComando.Parameters.AddWithValue("@VERSION_SINC_FECHA_IMG", DBNull.Value)
                miComando.Transaction = trasaccion
                miComando.ExecuteNonQuery()

                For index As Integer = 0 To dt_mult.Rows.Count - 1
                    Dim query20 As New StringBuilder
                    query20.Append("INSERT INTO [SAE60Empre05].[dbo].[MULT05] ")
                    query20.Append("([CVE_ART],[CVE_ALM],[STATUS],[CTRL_ALM],[EXIST],[STOCK_MIN], ")
                    query20.Append("[STOCK_MAX],[COMP_X_REC],[UUID],[VERSION_SINC]) ")
                    query20.Append("VALUES ")
                    query20.Append("(@CVE_ART,@CVE_ALM,@STATUS,@CTRL_ALM,@EXIST,@STOCK_MIN ")
                    query20.Append(",@STOCK_MAX,@COMP_X_REC,@UUID,@VERSION_SINC) ")
                    Dim miComando20 As New SqlCommand(query20.ToString(), ActualizarConexion)
                    miComando20.Parameters.AddWithValue("@CVE_ART", CODIGO)
                    miComando20.Parameters.AddWithValue("@CVE_ALM", dt_mult.Rows(index)(0))
                    miComando20.Parameters.AddWithValue("@STATUS", "A")
                    miComando20.Parameters.AddWithValue("@CTRL_ALM", DBNull.Value)
                    miComando20.Parameters.AddWithValue("@EXIST", 0)
                    miComando20.Parameters.AddWithValue("@STOCK_MIN", 0)
                    miComando20.Parameters.AddWithValue("@STOCK_MAX", 0)
                    miComando20.Parameters.AddWithValue("@COMP_X_REC", 0)
                    miComando20.Parameters.AddWithValue("@UUID", "R")
                    miComando20.Parameters.AddWithValue("@VERSION_SINC", Now)
                    miComando20.Transaction = trasaccion
                    miComando20.ExecuteNonQuery()
                Next

            ElseIf empresa = "SR AGRO" Then
                Dim query1 As New StringBuilder
                query1.Append("INSERT INTO [SAE60Empre02].[dbo].[INVE_CLIB02] ")
                query1.Append("([CVE_PROD],[CAMPLIB1],[CAMPLIB2],[CAMPLIB3],[CAMPLIB4],[CAMPLIB5],[CAMPLIB6],[CAMPLIB7] ")
                query1.Append(",[CAMPLIB8],[CAMPLIB9],[CAMPLIB10],[CAMPLIB11],[CAMPLIB12]) ")
                query1.Append("VALUES ")
                query1.Append("(@CVE_PROD,@CAMPLIB1,@CAMPLIB2,@CAMPLIB3,@CAMPLIB4,@CAMPLIB5,@CAMPLIB6,@CAMPLIB7,@CAMPLIB8 ")
                query1.Append(",@CAMPLIB9,@CAMPLIB10,@CAMPLIB11,@CAMPLIB12) ")

                Dim comando_libres As New SqlCommand(query1.ToString, ActualizarConexion)
                comando_libres.Parameters.AddWithValue("@CVE_PROD", CODIGO)
                comando_libres.Parameters.AddWithValue("@CAMPLIB1", "")
                comando_libres.Parameters.AddWithValue("@CAMPLIB2", CATEGORIA)
                comando_libres.Parameters.AddWithValue("@CAMPLIB3", SUB_CATEGORIA)
                comando_libres.Parameters.AddWithValue("@CAMPLIB4", "")
                comando_libres.Parameters.AddWithValue("@CAMPLIB5", "")
                comando_libres.Parameters.AddWithValue("@CAMPLIB6", "")
                comando_libres.Parameters.AddWithValue("@CAMPLIB7", MEGACATEGORIA)
                comando_libres.Parameters.AddWithValue("@CAMPLIB8", "")
                comando_libres.Parameters.AddWithValue("@CAMPLIB9", "")
                comando_libres.Parameters.AddWithValue("@CAMPLIB10", "")
                comando_libres.Parameters.AddWithValue("@CAMPLIB11", "")
                comando_libres.Parameters.AddWithValue("@CAMPLIB12", "")
                comando_libres.Transaction = trasaccion
                comando_libres.ExecuteNonQuery()

                For index As Integer = 0 To dt_precio.Rows.Count - 1
                    Dim query_precios As New StringBuilder
                    query_precios.Append("INSERT INTO [SAE60Empre02].[dbo].[PRECIO_X_PROD02] ")
                    query_precios.Append(" ([CVE_ART],[CVE_PRECIO],[PRECIO],[UUID],[VERSION_SINC]) ")
                    query_precios.Append("VALUES (@CVE_ART,@CVE_PRECIO,@PRECIO,@UUID,@VERSION_SINC) ")
                    Dim comando_precios = New SqlCommand(query_precios.ToString, ActualizarConexion)
                    comando_precios.Parameters.AddWithValue("@CVE_ART", CODIGO)
                    comando_precios.Parameters.AddWithValue("@CVE_PRECIO", dt_precio.Rows(index)(0))
                    comando_precios.Parameters.AddWithValue("@PRECIO", dt_precio.Rows(index)(1))
                    comando_precios.Parameters.AddWithValue("@UUID", "")
                    comando_precios.Parameters.AddWithValue("@VERSION_SINC", Now.Date)
                    comando_precios.Transaction = trasaccion
                    comando_precios.ExecuteNonQuery()
                Next

                Dim query_prov_prod As New StringBuilder
                query_prov_prod.Append("INSERT INTO [SAE60Empre02].[dbo].[PRVPROD02] ")
                query_prov_prod.Append(" ([CVE_ART],[CVE_PROV],[COSTO],[T_ENTREGA]) ")
                query_prov_prod.Append("VALUES (@CVE_ART,@CVE_PROV,@COSTO,@T_ENTREGA) ")
                Dim comando_prov_prod = New SqlCommand(query_prov_prod.ToString, ActualizarConexion)
                comando_prov_prod.Parameters.AddWithValue("@CVE_ART", CODIGO)
                comando_prov_prod.Parameters.AddWithValue("@CVE_PROV", COD_PROV)
                comando_prov_prod.Parameters.AddWithValue("@COSTO", 0)
                comando_prov_prod.Parameters.AddWithValue("@T_ENTREGA", 0)
                comando_prov_prod.Transaction = trasaccion
                comando_prov_prod.ExecuteNonQuery()

                Dim query As New StringBuilder
                query.Append("INSERT INTO [SAE60Empre02].[dbo].[INVE02] ")
                query.Append(" ([CVE_ART],[DESCR],[LIN_PROD],[CON_SERIE],[UNI_MED],[UNI_EMP],[CTRL_ALM],[TIEM_SURT],[STOCK_MIN] ")
                query.Append(",[STOCK_MAX],[TIP_COSTEO],[NUM_MON],[FCH_ULTCOM],[COMP_X_REC],[FCH_ULTVTA],[PEND_SURT],[EXIST] ")
                query.Append(",[COSTO_PROM],[ULT_COSTO],[CVE_OBS],[TIPO_ELE],[UNI_ALT],[FAC_CONV],[APART],[CON_LOTE],[CON_PEDIMENTO] ")
                query.Append(",[PESO],[VOLUMEN],[CVE_ESQIMPU],[CVE_BITA],[VTAS_ANL_C],[VTAS_ANL_M],[COMP_ANL_C],[COMP_ANL_M],[PREFIJO] ")
                query.Append(",[TALLA],[COLOR],[CUENT_CONT],[CVE_IMAGEN],[BLK_CST_EXT],[STATUS],[MAN_IEPS],[APL_MAN_IMP],[CUOTA_IEPS] ")
                query.Append(",[APL_MAN_IEPS],[UUID],[VERSION_SINC],[VERSION_SINC_FECHA_IMG]) ")
                query.Append("VALUES ")
                query.Append("(@CVE_ART,@DESCR,@LIN_PROD,@CON_SERIE,@UNI_MED,@UNI_EMP,@CTRL_ALM,@TIEM_SURT,@STOCK_MIN,@STOCK_MAX, ")
                query.Append("@TIP_COSTEO,@NUM_MON,@FCH_ULTCOM,@COMP_X_REC,@FCH_ULTVTA,@PEND_SURT,@EXIST,@COSTO_PROM,@ULT_COSTO, ")
                query.Append("@CVE_OBS,@TIPO_ELE,@UNI_ALT,@FAC_CONV,@APART,@CON_LOTE,@CON_PEDIMENTO,@PESO,@VOLUMEN,@CVE_ESQIMPU, ")
                query.Append("@CVE_BITA,@VTAS_ANL_C,@VTAS_ANL_M,@COMP_ANL_C,@COMP_ANL_M,@PREFIJO,@TALLA,@COLOR,@CUENT_CONT,@CVE_IMAGEN, ")
                query.Append("@BLK_CST_EXT,@STATUS,@MAN_IEPS,@APL_MAN_IMP,@CUOTA_IEPS,@APL_MAN_IEPS,@UUID,@VERSION_SINC, ")
                query.Append("@VERSION_SINC_FECHA_IMG)")
                Dim miComando As New SqlCommand(query.ToString(), ActualizarConexion)
                miComando.Parameters.AddWithValue("@CVE_ART", CODIGO)
                miComando.Parameters.AddWithValue("@DESCR", DESCRIPCION)
                miComando.Parameters.AddWithValue("@LIN_PROD", LINEA)
                miComando.Parameters.AddWithValue("@CON_SERIE", "N")
                miComando.Parameters.AddWithValue("@UNI_MED", ENTRADA)
                miComando.Parameters.AddWithValue("@UNI_EMP", EMPAQUE)
                miComando.Parameters.AddWithValue("@CTRL_ALM", "")
                miComando.Parameters.AddWithValue("@TIEM_SURT", 0)
                miComando.Parameters.AddWithValue("@STOCK_MIN", 0)
                miComando.Parameters.AddWithValue("@STOCK_MAX", 0)
                miComando.Parameters.AddWithValue("@TIP_COSTEO", "P")
                miComando.Parameters.AddWithValue("@NUM_MON", 1)
                miComando.Parameters.AddWithValue("@FCH_ULTCOM", DBNull.Value)
                miComando.Parameters.AddWithValue("@COMP_X_REC", 0)
                miComando.Parameters.AddWithValue("@FCH_ULTVTA", DBNull.Value)
                miComando.Parameters.AddWithValue("@PEND_SURT", 0)
                miComando.Parameters.AddWithValue("@EXIST", 0)
                miComando.Parameters.AddWithValue("@COSTO_PROM", 0)
                miComando.Parameters.AddWithValue("@ULT_COSTO", 0)
                miComando.Parameters.AddWithValue("@CVE_OBS", 0)
                miComando.Parameters.AddWithValue("@TIPO_ELE", "P")
                miComando.Parameters.AddWithValue("@UNI_ALT", SALIDA)
                miComando.Parameters.AddWithValue("@FAC_CONV", FACTOR)
                miComando.Parameters.AddWithValue("@APART", 0)
                miComando.Parameters.AddWithValue("@CON_LOTE", CON_LOTE)
                miComando.Parameters.AddWithValue("@CON_PEDIMENTO", "N")
                miComando.Parameters.AddWithValue("@PESO", PESO)
                miComando.Parameters.AddWithValue("@VOLUMEN", VOLUMEN)
                miComando.Parameters.AddWithValue("@CVE_ESQIMPU", ESQUEMA)
                miComando.Parameters.AddWithValue("@CVE_BITA", 0)
                miComando.Parameters.AddWithValue("@VTAS_ANL_C", 0)
                miComando.Parameters.AddWithValue("@VTAS_ANL_M", 0)
                miComando.Parameters.AddWithValue("@COMP_ANL_C", 0)
                miComando.Parameters.AddWithValue("@COMP_ANL_M", 0)
                miComando.Parameters.AddWithValue("@PREFIJO", DBNull.Value)
                miComando.Parameters.AddWithValue("@TALLA", DBNull.Value)
                miComando.Parameters.AddWithValue("@COLOR", DBNull.Value)
                miComando.Parameters.AddWithValue("@CUENT_CONT", DBNull.Value)
                miComando.Parameters.AddWithValue("@CVE_IMAGEN", "")
                miComando.Parameters.AddWithValue("@BLK_CST_EXT", "N")
                miComando.Parameters.AddWithValue("@STATUS", "A")
                miComando.Parameters.AddWithValue("@MAN_IEPS", "N")
                miComando.Parameters.AddWithValue("@APL_MAN_IMP", 1)
                miComando.Parameters.AddWithValue("@CUOTA_IEPS", 0)
                miComando.Parameters.AddWithValue("@APL_MAN_IEPS", "C")
                miComando.Parameters.AddWithValue("@UUID", DBNull.Value)
                miComando.Parameters.AddWithValue("@VERSION_SINC", DBNull.Value)
                miComando.Parameters.AddWithValue("@VERSION_SINC_FECHA_IMG", DBNull.Value)
                miComando.Transaction = trasaccion
                miComando.ExecuteNonQuery()

                For index As Integer = 0 To dt_mult.Rows.Count - 1
                    Dim query20 As New StringBuilder
                    query20.Append("INSERT INTO [SAE60Empre02].[dbo].[MULT02] ")
                    query20.Append("([CVE_ART],[CVE_ALM],[STATUS],[CTRL_ALM],[EXIST],[STOCK_MIN], ")
                    query20.Append("[STOCK_MAX],[COMP_X_REC],[UUID],[VERSION_SINC]) ")
                    query20.Append("VALUES ")
                    query20.Append("(@CVE_ART,@CVE_ALM,@STATUS,@CTRL_ALM,@EXIST,@STOCK_MIN ")
                    query20.Append(",@STOCK_MAX,@COMP_X_REC,@UUID,@VERSION_SINC) ")
                    Dim miComando20 As New SqlCommand(query20.ToString(), ActualizarConexion)
                    miComando20.Parameters.AddWithValue("@CVE_ART", CODIGO)
                    miComando20.Parameters.AddWithValue("@CVE_ALM", dt_mult.Rows(index)(0))
                    miComando20.Parameters.AddWithValue("@STATUS", "A")
                    miComando20.Parameters.AddWithValue("@CTRL_ALM", DBNull.Value)
                    miComando20.Parameters.AddWithValue("@EXIST", 0)
                    miComando20.Parameters.AddWithValue("@STOCK_MIN", 0)
                    miComando20.Parameters.AddWithValue("@STOCK_MAX", 0)
                    miComando20.Parameters.AddWithValue("@COMP_X_REC", 0)
                    miComando20.Parameters.AddWithValue("@UUID", "R")
                    miComando20.Parameters.AddWithValue("@VERSION_SINC", Now)
                    miComando20.Transaction = trasaccion
                    miComando20.ExecuteNonQuery()
                Next
            ElseIf empresa = "DIMOSA" Then
                Dim query1 As New StringBuilder
                query1.Append("INSERT INTO [SAE60Empre06].[dbo].[INVE_CLIB06] ")
                query1.Append("([CVE_PROD],[CAMPLIB1],[CAMPLIB2],[CAMPLIB3],[CAMPLIB4],[CAMPLIB5],[CAMPLIB6],[CAMPLIB7],[CAMPLIB8] ")
                query1.Append(",[CAMPLIB9],[CAMPLIB10],[CAMPLIB11],[CAMPLIB12],[CAMPLIB13],[CAMPLIB14],[CAMPLIB15],[CAMPLIB16],[CAMPLIB17],[CAMPLIB18]) ")
                query1.Append("VALUES ")
                query1.Append("(@CVE_PROD,@CAMPLIB1,@CAMPLIB2,@CAMPLIB3,@CAMPLIB4,@CAMPLIB5,@CAMPLIB6,@CAMPLIB7,@CAMPLIB8,@CAMPLIB9,@CAMPLIB10,@CAMPLIB11 ")
                query1.Append(",@CAMPLIB12,@CAMPLIB13,@CAMPLIB14,@CAMPLIB15,@CAMPLIB16,@CAMPLIB17,@CAMPLIB18) ")

                Dim comando_libres As New SqlCommand(query1.ToString, ActualizarConexion)
                comando_libres.Parameters.AddWithValue("@CVE_PROD", CODIGO)
                comando_libres.Parameters.AddWithValue("@CAMPLIB1", ALTERNO)
                comando_libres.Parameters.AddWithValue("@CAMPLIB2", "")
                comando_libres.Parameters.AddWithValue("@CAMPLIB3", "")
                comando_libres.Parameters.AddWithValue("@CAMPLIB4", PALETIZADO_SRC)
                comando_libres.Parameters.AddWithValue("@CAMPLIB5", PALETIZADO_SPS)
                comando_libres.Parameters.AddWithValue("@CAMPLIB6", "")
                comando_libres.Parameters.AddWithValue("@CAMPLIB7", "")
                comando_libres.Parameters.AddWithValue("@CAMPLIB8", UBICACION)
                comando_libres.Parameters.AddWithValue("@CAMPLIB9", CODIGO_BARRA)
                comando_libres.Parameters.AddWithValue("@CAMPLIB10", CODIGO_BARRA_CJ)
                comando_libres.Parameters.AddWithValue("@CAMPLIB11", UBICACION_SRC)
                comando_libres.Parameters.AddWithValue("@CAMPLIB12", UBICACION_TOCOA)
                comando_libres.Parameters.AddWithValue("@CAMPLIB13", CATEGORIA)
                comando_libres.Parameters.AddWithValue("@CAMPLIB14", SUB_CATEGORIA)
                comando_libres.Parameters.AddWithValue("@CAMPLIB15", "")
                comando_libres.Parameters.AddWithValue("@CAMPLIB16", "")
                comando_libres.Parameters.AddWithValue("@CAMPLIB17", PALETIZADO_AGRO)
                comando_libres.Parameters.AddWithValue("@CAMPLIB18", UBICACION_TEGUS)
                comando_libres.Transaction = trasaccion
                comando_libres.ExecuteNonQuery()

                For index As Integer = 0 To dt_precio.Rows.Count - 1
                    Dim query_precios As New StringBuilder
                    query_precios.Append("INSERT INTO [SAE60Empre06].[dbo].[PRECIO_X_PROD06] ")
                    query_precios.Append(" ([CVE_ART],[CVE_PRECIO],[PRECIO],[UUID],[VERSION_SINC]) ")
                    query_precios.Append("VALUES (@CVE_ART,@CVE_PRECIO,@PRECIO,@UUID,@VERSION_SINC) ")
                    Dim comando_precios = New SqlCommand(query_precios.ToString, ActualizarConexion)
                    comando_precios.Parameters.AddWithValue("@CVE_ART", CODIGO)
                    comando_precios.Parameters.AddWithValue("@CVE_PRECIO", dt_precio.Rows(index)(0))
                    comando_precios.Parameters.AddWithValue("@PRECIO", dt_precio.Rows(index)(1))
                    comando_precios.Parameters.AddWithValue("@UUID", "")
                    comando_precios.Parameters.AddWithValue("@VERSION_SINC", Now.Date)
                    comando_precios.Transaction = trasaccion
                    comando_precios.ExecuteNonQuery()
                Next

                Dim query_prov_prod As New StringBuilder
                query_prov_prod.Append("INSERT INTO [SAE60Empre06].[dbo].[PRVPROD06] ")
                query_prov_prod.Append(" ([CVE_ART],[CVE_PROV],[COSTO],[T_ENTREGA]) ")
                query_prov_prod.Append("VALUES (@CVE_ART,@CVE_PROV,@COSTO,@T_ENTREGA) ")
                Dim comando_prov_prod = New SqlCommand(query_prov_prod.ToString, ActualizarConexion)
                comando_prov_prod.Parameters.AddWithValue("@CVE_ART", CODIGO)
                comando_prov_prod.Parameters.AddWithValue("@CVE_PROV", COD_PROV)
                comando_prov_prod.Parameters.AddWithValue("@COSTO", 0)
                comando_prov_prod.Parameters.AddWithValue("@T_ENTREGA", 0)
                comando_prov_prod.Transaction = trasaccion
                comando_prov_prod.ExecuteNonQuery()

                Dim query As New StringBuilder
                query.Append("INSERT INTO [SAE60Empre06].[dbo].[INVE06] ")
                query.Append(" ([CVE_ART],[DESCR],[LIN_PROD],[CON_SERIE],[UNI_MED],[UNI_EMP],[CTRL_ALM],[TIEM_SURT],[STOCK_MIN] ")
                query.Append(",[STOCK_MAX],[TIP_COSTEO],[NUM_MON],[FCH_ULTCOM],[COMP_X_REC],[FCH_ULTVTA],[PEND_SURT],[EXIST] ")
                query.Append(",[COSTO_PROM],[ULT_COSTO],[CVE_OBS],[TIPO_ELE],[UNI_ALT],[FAC_CONV],[APART],[CON_LOTE],[CON_PEDIMENTO] ")
                query.Append(",[PESO],[VOLUMEN],[CVE_ESQIMPU],[CVE_BITA],[VTAS_ANL_C],[VTAS_ANL_M],[COMP_ANL_C],[COMP_ANL_M],[PREFIJO] ")
                query.Append(",[TALLA],[COLOR],[CUENT_CONT],[CVE_IMAGEN],[BLK_CST_EXT],[STATUS],[MAN_IEPS],[APL_MAN_IMP],[CUOTA_IEPS] ")
                query.Append(",[APL_MAN_IEPS],[UUID],[VERSION_SINC],[VERSION_SINC_FECHA_IMG]) ")
                query.Append("VALUES ")
                query.Append("(@CVE_ART,@DESCR,@LIN_PROD,@CON_SERIE,@UNI_MED,@UNI_EMP,@CTRL_ALM,@TIEM_SURT,@STOCK_MIN,@STOCK_MAX, ")
                query.Append("@TIP_COSTEO,@NUM_MON,@FCH_ULTCOM,@COMP_X_REC,@FCH_ULTVTA,@PEND_SURT,@EXIST,@COSTO_PROM,@ULT_COSTO, ")
                query.Append("@CVE_OBS,@TIPO_ELE,@UNI_ALT,@FAC_CONV,@APART,@CON_LOTE,@CON_PEDIMENTO,@PESO,@VOLUMEN,@CVE_ESQIMPU, ")
                query.Append("@CVE_BITA,@VTAS_ANL_C,@VTAS_ANL_M,@COMP_ANL_C,@COMP_ANL_M,@PREFIJO,@TALLA,@COLOR,@CUENT_CONT,@CVE_IMAGEN, ")
                query.Append("@BLK_CST_EXT,@STATUS,@MAN_IEPS,@APL_MAN_IMP,@CUOTA_IEPS,@APL_MAN_IEPS,@UUID,@VERSION_SINC, ")
                query.Append("@VERSION_SINC_FECHA_IMG)")
                Dim miComando As New SqlCommand(query.ToString(), ActualizarConexion)
                miComando.Parameters.AddWithValue("@CVE_ART", CODIGO)
                miComando.Parameters.AddWithValue("@DESCR", DESCRIPCION)
                miComando.Parameters.AddWithValue("@LIN_PROD", LINEA)
                miComando.Parameters.AddWithValue("@CON_SERIE", "N")
                miComando.Parameters.AddWithValue("@UNI_MED", ENTRADA)
                miComando.Parameters.AddWithValue("@UNI_EMP", EMPAQUE)
                miComando.Parameters.AddWithValue("@CTRL_ALM", "")
                miComando.Parameters.AddWithValue("@TIEM_SURT", 0)
                miComando.Parameters.AddWithValue("@STOCK_MIN", 0)
                miComando.Parameters.AddWithValue("@STOCK_MAX", 0)
                miComando.Parameters.AddWithValue("@TIP_COSTEO", "P")
                miComando.Parameters.AddWithValue("@NUM_MON", 1)
                miComando.Parameters.AddWithValue("@FCH_ULTCOM", DBNull.Value)
                miComando.Parameters.AddWithValue("@COMP_X_REC", 0)
                miComando.Parameters.AddWithValue("@FCH_ULTVTA", DBNull.Value)
                miComando.Parameters.AddWithValue("@PEND_SURT", 0)
                miComando.Parameters.AddWithValue("@EXIST", 0)
                miComando.Parameters.AddWithValue("@COSTO_PROM", 0)
                miComando.Parameters.AddWithValue("@ULT_COSTO", 0)
                miComando.Parameters.AddWithValue("@CVE_OBS", 0)
                miComando.Parameters.AddWithValue("@TIPO_ELE", "P")
                miComando.Parameters.AddWithValue("@UNI_ALT", SALIDA)
                miComando.Parameters.AddWithValue("@FAC_CONV", FACTOR)
                miComando.Parameters.AddWithValue("@APART", 0)
                miComando.Parameters.AddWithValue("@CON_LOTE", CON_LOTE)
                miComando.Parameters.AddWithValue("@CON_PEDIMENTO", "N")
                miComando.Parameters.AddWithValue("@PESO", PESO)
                miComando.Parameters.AddWithValue("@VOLUMEN", VOLUMEN)
                miComando.Parameters.AddWithValue("@CVE_ESQIMPU", ESQUEMA)
                miComando.Parameters.AddWithValue("@CVE_BITA", 0)
                miComando.Parameters.AddWithValue("@VTAS_ANL_C", 0)
                miComando.Parameters.AddWithValue("@VTAS_ANL_M", 0)
                miComando.Parameters.AddWithValue("@COMP_ANL_C", 0)
                miComando.Parameters.AddWithValue("@COMP_ANL_M", 0)
                miComando.Parameters.AddWithValue("@PREFIJO", DBNull.Value)
                miComando.Parameters.AddWithValue("@TALLA", DBNull.Value)
                miComando.Parameters.AddWithValue("@COLOR", DBNull.Value)
                miComando.Parameters.AddWithValue("@CUENT_CONT", DBNull.Value)
                miComando.Parameters.AddWithValue("@CVE_IMAGEN", "")
                miComando.Parameters.AddWithValue("@BLK_CST_EXT", "N")
                miComando.Parameters.AddWithValue("@STATUS", "A")
                miComando.Parameters.AddWithValue("@MAN_IEPS", "N")
                miComando.Parameters.AddWithValue("@APL_MAN_IMP", 1)
                miComando.Parameters.AddWithValue("@CUOTA_IEPS", 0)
                miComando.Parameters.AddWithValue("@APL_MAN_IEPS", "C")
                miComando.Parameters.AddWithValue("@UUID", DBNull.Value)
                miComando.Parameters.AddWithValue("@VERSION_SINC", DBNull.Value)
                miComando.Parameters.AddWithValue("@VERSION_SINC_FECHA_IMG", DBNull.Value)
                miComando.Transaction = trasaccion
                miComando.ExecuteNonQuery()

                For index As Integer = 0 To dt_mult.Rows.Count - 1
                    Dim query20 As New StringBuilder
                    query20.Append("INSERT INTO [SAE60Empre06].[dbo].[MULT06] ")
                    query20.Append("([CVE_ART],[CVE_ALM],[STATUS],[CTRL_ALM],[EXIST],[STOCK_MIN], ")
                    query20.Append("[STOCK_MAX],[COMP_X_REC],[UUID],[VERSION_SINC]) ")
                    query20.Append("VALUES ")
                    query20.Append("(@CVE_ART,@CVE_ALM,@STATUS,@CTRL_ALM,@EXIST,@STOCK_MIN ")
                    query20.Append(",@STOCK_MAX,@COMP_X_REC,@UUID,@VERSION_SINC) ")
                    Dim miComando20 As New SqlCommand(query20.ToString(), ActualizarConexion)
                    miComando20.Parameters.AddWithValue("@CVE_ART", CODIGO)
                    miComando20.Parameters.AddWithValue("@CVE_ALM", dt_mult.Rows(index)(0))
                    miComando20.Parameters.AddWithValue("@STATUS", "A")
                    miComando20.Parameters.AddWithValue("@CTRL_ALM", DBNull.Value)
                    miComando20.Parameters.AddWithValue("@EXIST", 0)
                    miComando20.Parameters.AddWithValue("@STOCK_MIN", 0)
                    miComando20.Parameters.AddWithValue("@STOCK_MAX", 0)
                    miComando20.Parameters.AddWithValue("@COMP_X_REC", 0)
                    miComando20.Parameters.AddWithValue("@UUID", "R")
                    miComando20.Parameters.AddWithValue("@VERSION_SINC", Now)
                    miComando20.Transaction = trasaccion
                    miComando20.ExecuteNonQuery()
                Next
            End If

            Dim conexion_bita As New cls_bitacora_reporteador
            conexion_bita.RegistraBitacora(Now, usuario, "Creacion de Codigo de producto desde reporteador", "Supply Chain - Nuevo Producto", _
                                      "Fecha: " + Now + " Codigo: " + CODIGO + " Nombre: " + DESCRIPCION + " Empresa: " + empresa)

            trasaccion.Commit()
            ActualizarConexion.Close()
            Return "correcto"
        Catch EX As Exception
            trasaccion.Rollback()
            ActualizarConexion.Close()
            Return EX.ToString()
        End Try
    End Function
End Class
