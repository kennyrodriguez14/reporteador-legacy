Imports System.Data.SqlClient
Imports System.Text

Public Class Cls_PromocionesInfo

    Dim Conexion As New clsconexion_consumo
    Dim ConexionDIMOSA As New cls_conexion_DIMOSA
    Dim ConexionAgro As New clsconexion_sr_agro
    Dim ConexionDiscount As New cls_conexion_descuentos_tacticos
    Dim ConexionDiscountDIMOSA As New cls_conexion_descuentos_tacticos_dimosa
    Dim ConexionDiscount2 As New cls_conexion_descuentos_tacticos_sragro
    Dim ConexionUsu As New clsConexion

    Public Function MostrarMovimientos(ByVal Empresa As String, ByVal Almacen As String, ByVal FechaInicio As Date, ByVal FechaFin As Date)


        Dim ActualizarConexion As New SqlConnection(ConexionUsu.CadenaSQL())
        Dim miComando
        If Empresa = "SAN RAFAEL" Or Empresa = "CONSUMO" Then
            miComando = New SqlCommand(" SELECT PROM_ID AS 'Nº', PROM_DETALLE as 'DETALLE', PROM_FECHA as 'FECHA', CVE_PRODUCTO as 'CLAVE PRODUCTO', PRODUCTO_UNIDAD AS 'UNIDAD PRODUCTO', PRODUCTO_CANTIDAD AS 'CANTIDAD PRODUCTO', CVE_PROM AS 'CLAVE PROMO', PROM_UNIDAD AS 'UNIDAD PROMO',  " & _
                                        " PROM_CANTIDAD AS 'CANTIDAD PROMO', EMPRESA, ALMACEN, CONCEPTO_PROV AS 'CONCEPTO PROVEEDOR' FROM PROMO_MOVIMIENTOS WHERE EMPRESA = 'SAN RAFAEL' AND ALMACEN = @ALMACEN AND CONVERT(DATETIME,CONVERT(varchar(10), PROM_FECHA, 103),103) >= @FECHA1 AND CONVERT(DATETIME,CONVERT(varchar(10), PROM_FECHA, 103),103) <= @FECHA2 OR  EMPRESA = 'CONSUMO' AND ALMACEN = @ALMACEN AND CONVERT(DATETIME,CONVERT(varchar(10), PROM_FECHA, 103),103) >= @FECHA1 AND CONVERT(DATETIME,CONVERT(varchar(10), PROM_FECHA, 103),103) <= @FECHA2 ORDER BY PROM_ID DESC", ActualizarConexion)
        Else
            miComando = New SqlCommand(" SELECT PROM_ID AS 'Nº', PROM_DETALLE as 'DETALLE', PROM_FECHA as 'FECHA', CVE_PRODUCTO as 'CLAVE PRODUCTO', PRODUCTO_UNIDAD AS 'UNIDAD PRODUCTO', PRODUCTO_CANTIDAD AS 'CANTIDAD PRODUCTO', CVE_PROM AS 'CLAVE PROMO', PROM_UNIDAD AS 'UNIDAD PROMO',  " & _
                                        " PROM_CANTIDAD AS 'CANTIDAD PROMO', EMPRESA, ALMACEN, CONCEPTO_PROV AS 'CONCEPTO PROVEEDOR' FROM PROMO_MOVIMIENTOS WHERE EMPRESA = @EMPRESA AND ALMACEN = @ALMACEN AND CONVERT(DATETIME,CONVERT(varchar(10), PROM_FECHA, 103),103) >= @FECHA1 AND CONVERT(DATETIME,CONVERT(varchar(10), PROM_FECHA, 103),103) <= @FECHA2 ORDER BY PROM_ID DESC", ActualizarConexion)
            miComando.Parameters.AddWithValue("@EMPRESA", Empresa)
        End If
        
        ActualizarConexion.Open()

        miComando.Parameters.AddWithValue("@ALMACEN", Almacen)
        miComando.Parameters.AddWithValue("@FECHA1", FechaInicio.Date)
        miComando.Parameters.AddWithValue("@FECHA2", FechaFin.Date)

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

    Public Function InformacionProd(ByVal Clave As String)

        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT LIN_PROD, UNI_MED, UNI_EMP, UNI_ALT, FAC_CONV  " & _
                                        "FROM dbo.INVE05 WHERE CVE_ART = @CVE_ART", ActualizarConexion)
        ActualizarConexion.Open()
        miComando.Parameters.AddWithValue("@CVE_ART", Clave)
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

    Public Function InformacionProdDimosa(ByVal Clave As String)

        Dim ActualizarConexion As New SqlConnection(ConexionDIMOSA.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT LIN_PROD, UNI_MED, UNI_EMP, UNI_ALT, FAC_CONV  " & _
                                        "FROM dbo.INVE06 WHERE CVE_ART = @CVE_ART", ActualizarConexion)
        ActualizarConexion.Open()
        miComando.Parameters.AddWithValue("@CVE_ART", Clave)
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

    Public Function InformacionAgro(ByVal Clave As String)

        Dim ActualizarConexion As New SqlConnection(ConexionAgro.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT LIN_PROD, UNI_MED, UNI_EMP, UNI_ALT, FAC_CONV  " & _
                                        "FROM dbo.INVE02 WHERE CVE_ART = @CVE_ART", ActualizarConexion)
        ActualizarConexion.Open()
        miComando.Parameters.AddWithValue("@CVE_ART", Clave)
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

    Public Function LlenaConceptos()

        Dim ActualizarConexion As New SqlConnection(ConexionDiscount.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT concepto_prov_id, concepto_proveedor, CVE_PROV " & _
                                        "FROM concepto_proveedor ", ActualizarConexion)
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

    Public Function LlenaConceptosDIMOSA()

        Dim ActualizarConexion As New SqlConnection(ConexionDiscountDIMOSA.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT concepto_prov_id, concepto_proveedor, CVE_PROV " & _
                                        "FROM concepto_proveedor ", ActualizarConexion)
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

    Public Function SeleccionaConcepto(ByVal Linea As String)

        Dim ActualizarConexion As New SqlConnection(ConexionDiscount.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT concepto_prov_id, concepto_proveedor, CVE_PROV " & _
                                        "FROM concepto_proveedor WHERE CVE_PROV = @CVE_PROV ", ActualizarConexion)
        ActualizarConexion.Open()

        miComando.Parameters.AddWithValue("@CVE_PROV", Linea)
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

    Public Function SeleccionaConceptoDIMOSA(ByVal Linea As String)

        Dim ActualizarConexion As New SqlConnection(ConexionDiscountDIMOSA.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT concepto_prov_id, concepto_proveedor, CVE_PROV " & _
                                        "FROM concepto_proveedor WHERE CVE_PROV = @CVE_PROV ", ActualizarConexion)
        ActualizarConexion.Open()

        miComando.Parameters.AddWithValue("@CVE_PROV", Linea)
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

    Public Function LlenaConceptosAgro()

        Dim ActualizarConexion As New SqlConnection(ConexionDiscount2.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT concepto_prov_id, concepto_proveedor, CVE_PROV " & _
                                        "FROM concepto_proveedor ", ActualizarConexion)
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

    Public Function SeleccionaConceptoAgro(ByVal Linea As String)

        Dim ActualizarConexion As New SqlConnection(ConexionDiscount2.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT concepto_prov_id, concepto_proveedor, CVE_PROV " & _
                                        "FROM concepto_proveedor WHERE CVE_PROV = @CVE_PROV ", ActualizarConexion)
        ActualizarConexion.Open()

        miComando.Parameters.AddWithValue("@CVE_PROV", Linea)
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

    Public Function GuardarPromociones(ByVal dt As DataTable, ByVal usuario As String, ByVal Empresa As String, ByVal Almacen As Integer)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim transaccion_sql As SqlTransaction
        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand

            For index As Integer = 0 To dt.Rows.Count - 1

                Dim UltimaClave As Integer = 0
                Dim dt_CVE As New DataTable
                Dim query_CVE As New StringBuilder
                query_CVE.Append("SELECT MAX([Usuarios].[dbo].[PROMO_MOVIMIENTOS].[PROM_ID]) FROM [Usuarios].[dbo].[PROMO_MOVIMIENTOS] ")

                Dim cmd_select_CVE As New SqlCommand(query_CVE.ToString, ActualizarConexion)
                Dim adaptador_CVE As New SqlDataAdapter(cmd_select_CVE)
                cmd_select_CVE.Transaction = transaccion_sql
                adaptador_CVE.Fill(dt_CVE)
                If Not IsDBNull(dt_CVE.Rows(0)(0)) Then
                    UltimaClave = dt_CVE.Rows(0)(0)
                End If

                miComando = New SqlCommand("INSERT INTO [Usuarios].[dbo].[PROMO_MOVIMIENTOS] " & _
                                             "([PROM_ID], [PROM_DETALLE], [PROM_FECHA], [CVE_PRODUCTO], [PRODUCTO_UNIDAD], [PRODUCTO_CANTIDAD], [CVE_PROM], [PROM_UNIDAD], [PROM_CANTIDAD], [CONCEPTO_PROV] ,[EMPRESA], [ALMACEN]) " & _
                                             "VALUES(@PROM_ID, @PROM_DETALLE, @PROM_FECHA, @CVE_PRODUCTO, @PRODUCTO_UNIDAD, @PRODUCTO_CANTIDAD, @CVE_PROM, @PROM_UNIDAD, @PROM_CANTIDAD, @CONCEPTO_PROV, @EMPRESA, @ALMACEN) ", ActualizarConexion)
                miComando.Parameters.AddWithValue("@PROM_ID", UltimaClave + 1)
                miComando.Parameters.AddWithValue("@PROM_DETALLE", dt.Rows(index).Item(0))
                miComando.Parameters.AddWithValue("@PROM_FECHA", DateTime.Now)
                miComando.Parameters.AddWithValue("@CVE_PRODUCTO", dt.Rows(index).Item(1))
                miComando.Parameters.AddWithValue("@PRODUCTO_UNIDAD", dt.Rows(index).Item(3))
                miComando.Parameters.AddWithValue("@PRODUCTO_CANTIDAD", dt.Rows(index).Item(2))
                miComando.Parameters.AddWithValue("@CVE_PROM", dt.Rows(index).Item(5))
                miComando.Parameters.AddWithValue("@PROM_UNIDAD", dt.Rows(index).Item(7))
                miComando.Parameters.AddWithValue("@PROM_CANTIDAD", dt.Rows(index).Item(6))
                miComando.Parameters.AddWithValue("@CONCEPTO_PROV", dt.Rows(index).Item(9))
                miComando.Parameters.AddWithValue("@EMPRESA", Empresa)
                miComando.Parameters.AddWithValue("@ALMACEN", Almacen)
                miComando.Transaction = transaccion_sql
                miComando.ExecuteNonQuery()

                ' registrar las salidas
                'update MULT
                Dim query_mult_salida As New StringBuilder
                query_mult_salida.Append("UPDATE [SAE60Empre05].[dbo].[MULT05] ")
                query_mult_salida.Append("SET [EXIST] = ISNULL(EXIST,0) - @CANTIDAD ")
                query_mult_salida.Append("WHERE [CVE_ART] = @CVE_ART AND [CVE_ALM] = @CVE_ALM ")
                Dim comando_mult_salida As New SqlCommand(query_mult_salida.ToString, ActualizarConexion)
                comando_mult_salida.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(1))
                comando_mult_salida.Parameters.AddWithValue("@CVE_ALM", Almacen)
                comando_mult_salida.Parameters.AddWithValue("@CANTIDAD", dt.Rows(index).Item(2))
                comando_mult_salida.Transaction = transaccion_sql
                comando_mult_salida.ExecuteNonQuery()

                'update INVE
                Dim query_inve As New StringBuilder
                query_inve.Append("UPDATE [SAE60Empre05].[dbo].[INVE05] ")
                query_inve.Append("SET [EXIST] = EXIST - @CANTIDAD ")
                query_inve.Append("WHERE [CVE_ART] = @CVE_ART ")
                Dim comando_inve_salida As New SqlCommand(query_inve.ToString, ActualizarConexion)
                comando_inve_salida.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(1))
                comando_inve_salida.Parameters.AddWithValue("@CANTIDAD", dt.Rows(index).Item(2))
                comando_inve_salida.Transaction = transaccion_sql
                comando_inve_salida.ExecuteNonQuery()

                'INICIO DE LOS LOTES

                Dim dt_lotes_crear As New DataTable
                dt_lotes_crear.Columns.Clear()
                dt_lotes_crear.Columns.Add("LOTE")
                dt_lotes_crear.Columns.Add("CANT")
                dt_lotes_crear.Columns.Add("PEDIMENTO")
                dt_lotes_crear.Columns.Add("FCHCADUC")
                dt_lotes_crear.Columns.Add("FCHADUANA")
                dt_lotes_crear.Columns.Add("NOM_ADUANA")
                dt_lotes_crear.Columns.Add("CVE_OBS")
                dt_lotes_crear.Columns.Add("CIUDAD")
                dt_lotes_crear.Columns.Add("FRONTERA")
                dt_lotes_crear.Columns.Add("FEC_PROD_LT")
                dt_lotes_crear.Columns.Add("GLN")
                Dim correlativo_lotes As Integer = 0
                dt_lotes_crear.Rows.Clear()
                If dt.Rows(index).Item(4) = "S" Then
                    Dim ds_lotes As New DataSet
                    Dim cantidad As Double = 0, can_insertar As Double = 0

                    Dim query As New StringBuilder
                    query.Append("SELECT LOTE, CVE_ALM, FCHCADUC, CANTIDAD, REG_LTPD,PEDIMENTO,FCHADUANA, ")
                    query.Append("NOM_ADUAN,CVE_OBS,CIUDAD,FRONTERA,FEC_PROD_LT, GLN ")
                    query.Append("FROM [SAE60Empre05].[dbo].[LTPD05] WHERE (STATUS = 'A') AND (CVE_ART = @CVE_ART) AND CVE_ALM = @CVE_ALM")
                    query.Append(" AND (CANTIDAD > 0) AND (FCHCADUC > GETDATE() OR FCHCADUC IS NULL OR FCHCADUC = '') ")
                    query.Append("ORDER BY FCHCADUC ")
                    Dim cmd_select_lotes As New SqlCommand(query.ToString, ActualizarConexion)
                    cmd_select_lotes.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(1))
                    cmd_select_lotes.Parameters.AddWithValue("@CVE_ALM", Almacen)
                    Dim adaptador As New SqlDataAdapter(cmd_select_lotes)
                    cmd_select_lotes.Transaction = transaccion_sql
                    adaptador.Fill(ds_lotes)
                    cantidad = Convert.ToDouble(dt.Rows(index).Item(2))

                    'for de los lotes
                    'MsgBox("Lotes de Salida " & ds_lotes.Tables(0).Rows.Count)
                    For index1 As Integer = 0 To ds_lotes.Tables(0).Rows.Count
                        correlativo_lotes = 0
                        'inicio de seleccinar el autonumerico de los enlace lotes
                        Dim ds_correlativo_lotes As New DataSet
                        Dim query_correlativo_lotes As New StringBuilder
                        query_correlativo_lotes.Append("SELECT (ULT_CVE + 1) AS ULT_CVE ")
                        query_correlativo_lotes.Append("FROM [SAE60Empre05].[dbo].[TBLCONTROL05] ")
                        query_correlativo_lotes.Append("WHERE (ID_TABLA = 67)")
                        Dim cmd_select_correlativo_enlace As New SqlCommand(query_correlativo_lotes.ToString, ActualizarConexion)
                        Dim adapenlace As New SqlDataAdapter(cmd_select_correlativo_enlace)
                        cmd_select_correlativo_enlace.Transaction = transaccion_sql
                        adapenlace.Fill(ds_correlativo_lotes)
                        'fin de seleccionar el autonumerico de los enlace lotes
                        correlativo_lotes = Convert.ToInt32(ds_correlativo_lotes.Tables(0).Rows(0)(0))

                        Dim NumeroLote As Integer = 0

                        If (ds_lotes.Tables(0).Rows.Count > 0) Then
                            NumeroLote = ds_lotes.Tables(0).Rows(index1)(3)
                        End If
                        'MsgBox("Numero Lote: " & NumeroLote & vbNewLine & " CANTIDAD: " & cantidad)
                        If NumeroLote >= cantidad Then
                            'MsgBox("NumeroLote > Cantidad")
                            'MsgBox("NumeroLote > Cantidad: Cantidad Insertar: " & cantidad)
                            can_insertar = cantidad
                            'hacer el enlace a los lotes
                            Dim query_enlace As New StringBuilder
                            query_enlace.Append("INSERT INTO [SAE60Empre05].[dbo].[ENLACE_LTPD05] ")
                            query_enlace.Append("(E_LTPD,REG_LTPD,CANTIDAD,PXRS) ")
                            query_enlace.Append("VALUES (@E_LTPD,@REG_LTPD,@CANTIDAD,@PXRS) ")
                            Dim cmd_enlace_ltp As New SqlCommand(query_enlace.ToString, ActualizarConexion)
                            cmd_enlace_ltp.Parameters.AddWithValue("@E_LTPD", correlativo_lotes)
                            cmd_enlace_ltp.Parameters.AddWithValue("@REG_LTPD", Convert.ToInt32(ds_lotes.Tables(0).Rows(index1)(4)))
                            cmd_enlace_ltp.Parameters.AddWithValue("@CANTIDAD", cantidad)
                            cmd_enlace_ltp.Parameters.AddWithValue("@PXRS", cantidad)
                            cmd_enlace_ltp.Transaction = transaccion_sql
                            cmd_enlace_ltp.ExecuteNonQuery()

                            Dim new_row As DataRow = dt_lotes_crear.NewRow
                            new_row(0) = Convert.ToString(ds_lotes.Tables(0).Rows(index1)(0))
                            new_row(1) = cantidad
                            new_row(2) = ds_lotes.Tables(0).Rows(index1)(5)
                            new_row(3) = ds_lotes.Tables(0).Rows(index1)(2)
                            new_row(4) = ds_lotes.Tables(0).Rows(index1)(6)
                            new_row(5) = ds_lotes.Tables(0).Rows(index1)(7)
                            new_row(6) = ds_lotes.Tables(0).Rows(index1)(8)
                            new_row(7) = ds_lotes.Tables(0).Rows(index1)(9)
                            new_row(8) = ds_lotes.Tables(0).Rows(index1)(10)
                            new_row(9) = ds_lotes.Tables(0).Rows(index1)(11)
                            new_row(10) = ds_lotes.Tables(0).Rows(index1)(12)

                            dt_lotes_crear.Rows.Add(new_row)

                            'MsgBox("fila recien agregada - lOTES a CREAR: " & dt_lotes_crear.Rows.Count & vbNewLine & new_row(0) & vbNewLine & new_row(10))
                            'actualizar las existencias de los lotes
                            Dim query_ltpd As New StringBuilder
                            query_ltpd.Append("UPDATE [SAE60Empre05].[dbo].[LTPD05] ")
                            query_ltpd.Append("SET [FCHULTMOV] = @FCHULTMOV, ")
                            query_ltpd.Append("[CANTIDAD] = (CANTIDAD - @NUEVA_CANTIDAD) ")
                            query_ltpd.Append("WHERE [CVE_ART] = @CVE_ART AND [LOTE] = @LOTE AND [CVE_ALM] = @CVE_ALM ")
                            Dim cmd_ltpd As New SqlCommand(query_ltpd.ToString, ActualizarConexion)
                            cmd_ltpd.Parameters.AddWithValue("@FCHULTMOV", Today.Date)
                            cmd_ltpd.Parameters.AddWithValue("@NUEVA_CANTIDAD", cantidad)
                            cmd_ltpd.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(1))
                            cmd_ltpd.Parameters.AddWithValue("@LOTE", Convert.ToString(ds_lotes.Tables(0).Rows(index1)(0)))
                            cmd_ltpd.Parameters.AddWithValue("@CVE_ALM", Almacen)
                            cmd_ltpd.Transaction = transaccion_sql
                            cmd_ltpd.ExecuteNonQuery()
                            index1 = ds_lotes.Tables(0).Rows.Count
                        Else
                            can_insertar = (Convert.ToDouble(NumeroLote) - Convert.ToDouble(dt.Rows(index).Item(2)) + Convert.ToDouble(dt.Rows(index).Item(2)))
                            'MsgBox("NumeroLote < Cantidad: Cantidad Insertar: " & can_insertar)

                            'hacer el enlace a los lotes
                            Dim query_enlace_ltpd_ins As New StringBuilder
                            query_enlace_ltpd_ins.Append("INSERT INTO [SAE60Empre05].[dbo].[ENLACE_LTPD05] ")
                            query_enlace_ltpd_ins.Append("(E_LTPD,REG_LTPD,CANTIDAD,PXRS) ")
                            query_enlace_ltpd_ins.Append("VALUES (@E_LTPD,@REG_LTPD,@CANTIDAD,@PXRS) ")
                            Dim cmd_enlace_ltpd_ins As New SqlCommand(query_enlace_ltpd_ins.ToString, ActualizarConexion)
                            cmd_enlace_ltpd_ins.Parameters.AddWithValue("@E_LTPD", correlativo_lotes)
                            cmd_enlace_ltpd_ins.Parameters.AddWithValue("@REG_LTPD", Convert.ToInt32(ds_lotes.Tables(0).Rows(index1)(4)))
                            cmd_enlace_ltpd_ins.Parameters.AddWithValue("@CANTIDAD", can_insertar)
                            cmd_enlace_ltpd_ins.Parameters.AddWithValue("@PXRS", can_insertar)
                            cmd_enlace_ltpd_ins.Transaction = transaccion_sql
                            cmd_enlace_ltpd_ins.ExecuteNonQuery()

                            Dim new_row As DataRow = dt_lotes_crear.NewRow
                            new_row(0) = Convert.ToString(ds_lotes.Tables(0).Rows(index1)(0))
                            new_row(1) = can_insertar
                            new_row(2) = ds_lotes.Tables(0).Rows(index1)(5)
                            new_row(3) = ds_lotes.Tables(0).Rows(index1)(2)
                            new_row(4) = ds_lotes.Tables(0).Rows(index1)(6)
                            new_row(5) = ds_lotes.Tables(0).Rows(index1)(7)
                            new_row(6) = ds_lotes.Tables(0).Rows(index1)(8)
                            new_row(7) = ds_lotes.Tables(0).Rows(index1)(9)
                            new_row(8) = ds_lotes.Tables(0).Rows(index1)(10)
                            new_row(9) = ds_lotes.Tables(0).Rows(index1)(11)
                            new_row(10) = ds_lotes.Tables(0).Rows(index1)(12)
                            dt_lotes_crear.Rows.Add(new_row)
                            'MsgBox("cREACION lOTES CREAR: " & dt_lotes_crear.Rows.Count)
                            Dim query_upd_ltpd As New StringBuilder
                            query_upd_ltpd.Append("UPDATE [SAE60Empre05].[dbo].[LTPD05] ")
                            query_upd_ltpd.Append("SET [FCHULTMOV] = @FCHULTMOV ")
                            query_upd_ltpd.Append(",[CANTIDAD] = (CANTIDAD - @NUEVA_CANTIDAD) ")
                            query_upd_ltpd.Append("WHERE [CVE_ART] = @CVE_ART AND [LOTE] = @LOTE AND [CVE_ALM] = @CVE_ALM ")
                            Dim cmd_ltpd_upd As New SqlCommand(query_upd_ltpd.ToString, ActualizarConexion)
                            cmd_ltpd_upd.Parameters.AddWithValue("@FCHULTMOV", Today.Date)
                            cmd_ltpd_upd.Parameters.AddWithValue("@NUEVA_CANTIDAD", can_insertar)
                            cmd_ltpd_upd.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(1))
                            cmd_ltpd_upd.Parameters.AddWithValue("@LOTE", Convert.ToString(ds_lotes.Tables(0).Rows(index1)(0)))
                            cmd_ltpd_upd.Parameters.AddWithValue("@CVE_ALM", Almacen)
                            cmd_ltpd_upd.Transaction = transaccion_sql
                            cmd_ltpd_upd.ExecuteNonQuery()
                            cantidad = cantidad - Convert.ToInt32(ds_lotes.Tables(0).Rows(index1)(3))
                            can_insertar = cantidad
                        End If
                    Next

                    'actualizar los correlativos de los lotes
                    Dim query_actualiza_lotes As New StringBuilder
                    query_actualiza_lotes.Append("UPDATE [SAE60Empre05].[dbo].[TBLCONTROL05] ")
                    query_actualiza_lotes.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                    query_actualiza_lotes.Append("WHERE (ID_TABLA = 67) ")
                    Dim cmd_upd_correlativo_lot As New SqlCommand(query_actualiza_lotes.ToString, ActualizarConexion)
                    cmd_upd_correlativo_lot.Transaction = transaccion_sql
                    cmd_upd_correlativo_lot.ExecuteNonQuery()

                End If
                'FIN DE LOS LOTES

                'select Datos INVE
                Dim query_datos_inve As New StringBuilder
                query_datos_inve.Append("SELECT ISNULL(COSTO_PROM,0), ISNULL(UNI_MED,''), ISNULL(FAC_CONV,1) ")
                query_datos_inve.Append("FROM [SAE60Empre05].[dbo].[INVE05] ")
                query_datos_inve.Append("WHERE CVE_ART = @CVE_ART")
                Dim comando_datos_inve As New SqlCommand(query_datos_inve.ToString, ActualizarConexion)
                comando_datos_inve.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(1))
                comando_datos_inve.Transaction = transaccion_sql
                Dim adaptador_datos_inve As New SqlDataAdapter(comando_datos_inve)
                Dim dt_datos_inve As New DataTable
                adaptador_datos_inve.Fill(dt_datos_inve)

                'insert MINVE
                Dim query_minve As New StringBuilder
                query_minve.Append("INSERT INTO [SAE60Empre05].[dbo].[MINVE05] ")
                query_minve.Append("   ([CVE_ART],[ALMACEN],[NUM_MOV],[CVE_CPTO],[FECHA_DOCU],[TIPO_DOC],[REFER], ")
                query_minve.Append("    [CANT],[CANT_COST],[PRECIO],[COSTO], ")
                query_minve.Append("    [REG_SERIE],[UNI_VENTA],[E_LTPD],[EXIST_G],[EXISTENCIA],[TIPO_PROD],[FACTOR_CON], ")
                query_minve.Append("    [FECHAELAB],[CVE_FOLIO],[SIGNO],[COSTEADO],[COSTO_PROM_INI], ")
                query_minve.Append("    [COSTO_PROM_FIN],[COSTO_PROM_GRAL],[DESDE_INVE],[MOV_ENLAZADO]) ")
                query_minve.Append("VALUES ")
                query_minve.Append("   (@CVE_ART,@ALMACEN,(SELECT ULT_CVE+1 FROM [SAE60Empre05].[dbo].[TBLCONTROL05] WHERE (ID_TABLA = 44)), ")
                query_minve.Append("    @CVE_CPTO,@FECHA_DOCU,'M',@REFER,@CANT,0,0,@COSTO,0, ")
                query_minve.Append("    @UNI_VENTA,@E_LTPD, ((SELECT ISNULL(EXIST,0) FROM [SAE60Empre05].[dbo].[INVE05] WHERE CVE_ART = @CVE_ART)), ")
                query_minve.Append("    ((SELECT EXIST FROM [SAE60Empre05].[dbo].[MULT05] WHERE (CVE_ART = @CVE_ART) AND CVE_ALM = @ALMACEN)), 'P',1, ")
                query_minve.Append("    @FECHAELAB, (SELECT ULT_CVE+1 FROM [SAE60Empre05].[dbo].[TBLCONTROL05] WHERE (ID_TABLA = 32)), -1, 'S', @COSTO_PROM_INI, ")
                query_minve.Append("    @COSTO_PROM_FIN, @COSTO_PROM_GRAL, 'S', 0) ")

                Dim comando_minve_salida As New SqlCommand(query_minve.ToString, ActualizarConexion)
                comando_minve_salida.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(1))
                comando_minve_salida.Parameters.AddWithValue("@ALMACEN", Almacen)
                comando_minve_salida.Parameters.AddWithValue("@CVE_CPTO", 63)
                comando_minve_salida.Parameters.AddWithValue("@FECHA_DOCU", Today.Date)
                comando_minve_salida.Parameters.AddWithValue("@REFER", "SP" & Today.Day.ToString & Today.Month.ToString & Today.Year.ToString & "-" & UltimaClave + 1)
                comando_minve_salida.Parameters.AddWithValue("@CANT", dt.Rows(index).Item(2))
                comando_minve_salida.Parameters.AddWithValue("@COSTO", dt_datos_inve.Rows(0)(0))
                comando_minve_salida.Parameters.AddWithValue("@UNI_VENTA", dt_datos_inve.Rows(0)(1))
                comando_minve_salida.Parameters.AddWithValue("@E_LTPD", correlativo_lotes)
                comando_minve_salida.Parameters.AddWithValue("@FECHAELAB", Today.Date)
                comando_minve_salida.Parameters.AddWithValue("@COSTO_PROM_INI", dt_datos_inve.Rows(0)(0))
                comando_minve_salida.Parameters.AddWithValue("@COSTO_PROM_FIN", dt_datos_inve.Rows(0)(0))
                comando_minve_salida.Parameters.AddWithValue("@COSTO_PROM_GRAL", dt_datos_inve.Rows(0)(0))
                comando_minve_salida.Transaction = transaccion_sql
                comando_minve_salida.ExecuteNonQuery()

                'update num mov minve
                Dim query_control_num_mov As New StringBuilder
                query_control_num_mov.Append("UPDATE [SAE60Empre05].[dbo].[TBLCONTROL05] ")
                query_control_num_mov.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                query_control_num_mov.Append("WHERE [ID_TABLA] = 44 ")
                Dim comando_control_num_mov As New SqlCommand(query_control_num_mov.ToString, ActualizarConexion)
                comando_control_num_mov.Transaction = transaccion_sql
                comando_control_num_mov.ExecuteNonQuery()

                'FIN DE REGISTRAR LAS SALIDAS

                'INICIO REGISTRAR LAS ENTRADAS
                'update MULT
                Dim query_mult_entrada As New StringBuilder
                query_mult_entrada.Append("UPDATE [SAE60Empre05].[dbo].[MULT05] ")
                query_mult_entrada.Append("SET [EXIST] = ISNULL(EXIST,0) + @CANTIDAD ")
                query_mult_entrada.Append("WHERE [CVE_ART] = @CVE_ART AND [CVE_ALM] = @CVE_ALM ")
                Dim comando_mult_entrada As New SqlCommand(query_mult_entrada.ToString, ActualizarConexion)
                comando_mult_entrada.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(5))
                comando_mult_entrada.Parameters.AddWithValue("@CVE_ALM", Almacen)
                comando_mult_entrada.Parameters.AddWithValue("@CANTIDAD", dt.Rows(index).Item(6))
                comando_mult_entrada.Transaction = transaccion_sql
                comando_mult_entrada.ExecuteNonQuery()

                'update INVE
                Dim query_inve_entrada As New StringBuilder
                query_inve_entrada.Append("UPDATE [SAE60Empre05].[dbo].[INVE05] ")
                query_inve_entrada.Append("SET [EXIST] = EXIST + @CANTIDAD ")
                query_inve_entrada.Append("WHERE [CVE_ART] = @CVE_ART ")
                Dim comando_inve_entrada As New SqlCommand(query_inve_entrada.ToString, ActualizarConexion)
                comando_inve_entrada.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(5))
                comando_inve_entrada.Parameters.AddWithValue("@CANTIDAD", dt.Rows(index).Item(6))
                comando_inve_entrada.Transaction = transaccion_sql
                comando_inve_entrada.ExecuteNonQuery()


                'INICIO DE LOS LOTES
                Dim correlativo_lotes_ENTRADA As Integer = 0
                If dt.Rows(index).Item(8) = "S" Then
                    'MsgBox("Lotes de Entrada " & dt_lotes_crear.Rows.Count - 1)
                    For index2 As Integer = 0 To dt_lotes_crear.Rows.Count - 1
                        correlativo_lotes_ENTRADA = 0
                        'inicio de seleccinar el autonumerico de los enlace lotes
                        Dim ds_correlativo_lotes As New DataSet
                        Dim query_correlativo_lotes As New StringBuilder
                        query_correlativo_lotes.Append("SELECT (ULT_CVE + 1) AS ULT_CVE ")
                        query_correlativo_lotes.Append("FROM [SAE60Empre05].[dbo].[TBLCONTROL05] ")
                        query_correlativo_lotes.Append("WHERE (ID_TABLA = 67)")
                        Dim cmd_select_correlativo_enlace As New SqlCommand(query_correlativo_lotes.ToString, ActualizarConexion)
                        Dim adapenlace As New SqlDataAdapter(cmd_select_correlativo_enlace)
                        cmd_select_correlativo_enlace.Transaction = transaccion_sql
                        adapenlace.Fill(ds_correlativo_lotes)
                        'fin de seleccionar el autonumerico de los enlace lotes
                        correlativo_lotes_ENTRADA = Convert.ToInt32(ds_correlativo_lotes.Tables(0).Rows(0)(0))

                        Dim query_valida_lote As New StringBuilder
                        query_valida_lote.Append("SELECT CVE_ART,LOTE,REG_LTPD ")
                        query_valida_lote.Append("FROM [SAE60Empre05].[dbo].[LTPD05] ")
                        query_valida_lote.Append("WHERE LOTE = @LOTE AND CVE_ALM = @ALMACEN AND CVE_ART = @CVE_ART ")
                        Dim cmd_valida_lote As New SqlCommand(query_valida_lote.ToString, ActualizarConexion)
                        cmd_valida_lote.Parameters.AddWithValue("@LOTE", dt_lotes_crear.Rows(index2)(0))
                        cmd_valida_lote.Parameters.AddWithValue("@ALMACEN", Almacen)
                        cmd_valida_lote.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(5))
                        cmd_valida_lote.Transaction = transaccion_sql
                        Dim adaptador_valida_lote As New SqlDataAdapter(cmd_valida_lote)
                        Dim dt_valida_lote As New DataTable
                        adaptador_valida_lote.Fill(dt_valida_lote)
                        If dt_valida_lote.Rows.Count > 0 Then
                            'si el lote existe
                            'hacer el enlace a los lotes

                            Dim X As Integer = 0
                            If dt.Rows(index).Item(6) <> dt.Rows(index).Item(2) Then
                                X = dt_lotes_crear.Rows(index2)(1) * dt_datos_inve.Rows(0)(2)
                            Else
                                X = dt_lotes_crear.Rows(index2)(1)
                            End If

                            Dim query_enlace_ltpd_ins_entrada As New StringBuilder
                            query_enlace_ltpd_ins_entrada.Append("INSERT INTO [SAE60Empre05].[dbo].[ENLACE_LTPD05] ")
                            query_enlace_ltpd_ins_entrada.Append("(E_LTPD,REG_LTPD,CANTIDAD,PXRS) ")
                            query_enlace_ltpd_ins_entrada.Append("VALUES (@E_LTPD,@REG_LTPD,@CANTIDAD,@PXRS) ")
                            Dim cmd_enlace_ltpd_ins_entrada As New SqlCommand(query_enlace_ltpd_ins_entrada.ToString, ActualizarConexion)
                            cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@E_LTPD", correlativo_lotes_ENTRADA)
                            cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@REG_LTPD", dt_valida_lote.Rows(0)(2))
                            cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@CANTIDAD", X)
                            cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@PXRS", X)
                            cmd_enlace_ltpd_ins_entrada.Transaction = transaccion_sql
                            cmd_enlace_ltpd_ins_entrada.ExecuteNonQuery()

                            Dim query_upd_ltpd As New StringBuilder
                            query_upd_ltpd.Append("UPDATE [SAE60Empre05].[dbo].[LTPD05] ")
                            query_upd_ltpd.Append("SET [FCHULTMOV] = @FCHULTMOV ")
                            query_upd_ltpd.Append(",[CANTIDAD] = (CANTIDAD + @NUEVA_CANTIDAD) ")
                            query_upd_ltpd.Append("WHERE [CVE_ART] = @CVE_ART AND [LOTE] = @LOTE AND [CVE_ALM] = @CVE_ALM ")
                            Dim cmd_ltpd_upd As New SqlCommand(query_upd_ltpd.ToString, ActualizarConexion)
                            cmd_ltpd_upd.Parameters.AddWithValue("@FCHULTMOV", Today.Date)
                            
                            cmd_ltpd_upd.Parameters.AddWithValue("@NUEVA_CANTIDAD", X)
                            cmd_ltpd_upd.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(5))
                            cmd_ltpd_upd.Parameters.AddWithValue("@LOTE", dt_valida_lote.Rows(0)(1))
                            cmd_ltpd_upd.Parameters.AddWithValue("@CVE_ALM", Almacen)
                            cmd_ltpd_upd.Transaction = transaccion_sql
                            cmd_ltpd_upd.ExecuteNonQuery()
                        Else
                            'si el lote NO existe
                            Dim nuevo_reg_ltpd As Integer = 0
                            'inicio de seleccinar el autonumerico de los lotes
                            Dim ds_nuevo_reg_ltpd As New DataSet
                            Dim query_nuevo_reg_ltpd2 As New StringBuilder
                            query_nuevo_reg_ltpd2.Append("SELECT (ULT_CVE + 1) AS ULT_CVE ")
                            query_nuevo_reg_ltpd2.Append("FROM [SAE60Empre05].[dbo].[TBLCONTROL05] ")
                            query_nuevo_reg_ltpd2.Append("WHERE (ID_TABLA = 48)")
                            Dim cmd_select_nuevo_reg_ltpd2 As New SqlCommand(query_nuevo_reg_ltpd2.ToString, ActualizarConexion)
                            Dim adapnuevo_reg_ltpd As New SqlDataAdapter(cmd_select_nuevo_reg_ltpd2)
                            cmd_select_nuevo_reg_ltpd2.Transaction = transaccion_sql
                            adapnuevo_reg_ltpd.Fill(ds_nuevo_reg_ltpd)
                            'fin de seleccionar el autonumerico de los lotes
                            nuevo_reg_ltpd = Convert.ToInt32(ds_nuevo_reg_ltpd.Tables(0).Rows(0)(0))

                            'hacer el enlace a los lotes
                            Dim query_enlace_ltpd_ins_entrada As New StringBuilder
                            query_enlace_ltpd_ins_entrada.Append("INSERT INTO [SAE60Empre05].[dbo].[ENLACE_LTPD05] ")
                            query_enlace_ltpd_ins_entrada.Append("(E_LTPD,REG_LTPD,CANTIDAD,PXRS) ")
                            query_enlace_ltpd_ins_entrada.Append("VALUES (@E_LTPD,@REG_LTPD,@CANTIDAD,@PXRS) ")
                            Dim cmd_enlace_ltpd_ins_entrada As New SqlCommand(query_enlace_ltpd_ins_entrada.ToString, ActualizarConexion)
                            cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@E_LTPD", correlativo_lotes_ENTRADA)
                            cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@REG_LTPD", nuevo_reg_ltpd)

                            Dim X As Integer = 0
                            If dt.Rows(index).Item(6) <> dt.Rows(index).Item(2) Then
                                X = dt_lotes_crear.Rows(index2)(1) * dt_datos_inve.Rows(0)(2)
                            Else
                                X = dt_lotes_crear.Rows(index2)(1)
                            End If

                            cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@CANTIDAD", X)
                            cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@PXRS", X)
                            cmd_enlace_ltpd_ins_entrada.Transaction = transaccion_sql
                            cmd_enlace_ltpd_ins_entrada.ExecuteNonQuery()
                            'insertar nuevo lote
                            Dim query_insertar_nuevo_lote As New StringBuilder
                            query_insertar_nuevo_lote.Append("INSERT INTO [SAE60Empre05].[dbo].[LTPD05] ")
                            query_insertar_nuevo_lote.Append("([CVE_ART],[LOTE],[PEDIMENTO],[CVE_ALM],[FCHCADUC],[FCHADUANA] ")
                            query_insertar_nuevo_lote.Append(",[FCHULTMOV],[NOM_ADUAN],[CANTIDAD],[REG_LTPD],[CVE_OBS] ")
                            query_insertar_nuevo_lote.Append(",[CIUDAD],[FRONTERA],[FEC_PROD_LT],[GLN],[STATUS]) ")
                            query_insertar_nuevo_lote.Append("VALUES ")
                            query_insertar_nuevo_lote.Append("(@CVE_ART,@LOTE,@PEDIMENTO,@CVE_ALM,@FCHCADUC,@FCHADUANA ")
                            query_insertar_nuevo_lote.Append(",@FCHULTMOV,@NOM_ADUAN,@CANTIDAD,@REG_LTPD,@CVE_OBS,@CIUDAD ")
                            query_insertar_nuevo_lote.Append(",@FRONTERA,@FEC_PROD_LT,@GLN,@STATUS)")
                            Dim cmd_insertar_nuevo_lote As New SqlCommand(query_insertar_nuevo_lote.ToString, ActualizarConexion)
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(5))
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@LOTE", dt_lotes_crear.Rows(index2)(0))
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@PEDIMENTO", dt_lotes_crear.Rows(index2)(2))
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@CVE_ALM", Almacen)

                            If IsDBNull(dt_lotes_crear.Rows(index2)(3)) = True Then
                                cmd_insertar_nuevo_lote.Parameters.AddWithValue("@FCHCADUC", DBNull.Value)
                            Else
                                cmd_insertar_nuevo_lote.Parameters.AddWithValue("@FCHCADUC", Convert.ToDateTime(dt_lotes_crear.Rows(index2)(3)))
                            End If

                            If IsDBNull(dt_lotes_crear.Rows(index2)(4)) = True Then
                                cmd_insertar_nuevo_lote.Parameters.AddWithValue("@FCHADUANA", DBNull.Value)
                            Else
                                cmd_insertar_nuevo_lote.Parameters.AddWithValue("@FCHADUANA", Convert.ToDateTime(dt_lotes_crear.Rows(index2)(4)))
                            End If

                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@FCHULTMOV", Today.Date)
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@NOM_ADUAN", dt_lotes_crear.Rows(index2)(5))
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@CANTIDAD", X)
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@REG_LTPD", nuevo_reg_ltpd)
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@CVE_OBS", dt_lotes_crear.Rows(index2)(6))
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@CIUDAD", dt_lotes_crear.Rows(index2)(7))
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@FRONTERA", dt_lotes_crear.Rows(index2)(8))
                            If IsDBNull(dt_lotes_crear.Rows(index2)(9)) = True Then
                                cmd_insertar_nuevo_lote.Parameters.AddWithValue("@FEC_PROD_LT", DBNull.Value)
                            Else
                                cmd_insertar_nuevo_lote.Parameters.AddWithValue("@FEC_PROD_LT", Convert.ToDateTime(dt_lotes_crear.Rows(index2)(9)))
                            End If
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@GLN", dt_lotes_crear.Rows(index2)(10))
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@STATUS", "A")
                            cmd_insertar_nuevo_lote.Transaction = transaccion_sql
                            cmd_insertar_nuevo_lote.ExecuteNonQuery()

                            'actualizar el autonumerico de lotes
                            Dim query_actualiza_autonumerico_ltpd As New StringBuilder
                            query_actualiza_autonumerico_ltpd.Append("UPDATE [SAE60Empre05].[dbo].[TBLCONTROL05] ")
                            query_actualiza_autonumerico_ltpd.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                            query_actualiza_autonumerico_ltpd.Append("WHERE (ID_TABLA = 48) ")
                            Dim cmd_upd_autonumerico_ltpd As New SqlCommand(query_actualiza_autonumerico_ltpd.ToString, ActualizarConexion)
                            cmd_upd_autonumerico_ltpd.Transaction = transaccion_sql
                            cmd_upd_autonumerico_ltpd.ExecuteNonQuery()

                        End If
                    Next

                    'actualizar los correlativos de enlace de lotes
                    Dim query_actualiza_lotes As New StringBuilder
                    query_actualiza_lotes.Append("UPDATE [SAE60Empre05].[dbo].[TBLCONTROL05] ")
                    query_actualiza_lotes.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                    query_actualiza_lotes.Append("WHERE (ID_TABLA = 67) ")
                    Dim cmd_upd_correlativo_lot As New SqlCommand(query_actualiza_lotes.ToString, ActualizarConexion)
                    cmd_upd_correlativo_lot.Transaction = transaccion_sql
                    cmd_upd_correlativo_lot.ExecuteNonQuery()
                End If

                'insert MINVE
                Dim query_minve_entrada As New StringBuilder
                query_minve_entrada.Append("INSERT INTO [SAE60Empre05].[dbo].[MINVE05] ")
                query_minve_entrada.Append("   ([CVE_ART],[ALMACEN],[NUM_MOV],[CVE_CPTO],[FECHA_DOCU],[TIPO_DOC],[REFER], ")
                query_minve_entrada.Append("    [CANT],[CANT_COST],[PRECIO],[COSTO], ")
                query_minve_entrada.Append("    [REG_SERIE],[UNI_VENTA],[E_LTPD],[EXIST_G],[EXISTENCIA],[TIPO_PROD],[FACTOR_CON], ")
                query_minve_entrada.Append("    [FECHAELAB],[CVE_FOLIO],[SIGNO],[COSTEADO],[COSTO_PROM_INI], ")
                query_minve_entrada.Append("    [COSTO_PROM_FIN],[COSTO_PROM_GRAL],[DESDE_INVE],[MOV_ENLAZADO]) ")
                query_minve_entrada.Append("VALUES ")
                query_minve_entrada.Append("   (@CVE_ART,@ALMACEN,(SELECT ULT_CVE+1 FROM [SAE60Empre05].[dbo].[TBLCONTROL05] WHERE (ID_TABLA = 44)), ")
                query_minve_entrada.Append("    @CVE_CPTO,@FECHA_DOCU,'M',@REFER,@CANT,0,0,@COSTO,0, ")
                query_minve_entrada.Append("    @UNI_VENTA,@E_LTPD, ((SELECT ISNULL(EXIST,0) FROM [SAE60Empre05].[dbo].[INVE05] WHERE CVE_ART = @CVE_ART)), ")
                query_minve_entrada.Append("    ((SELECT EXIST FROM [SAE60Empre05].[dbo].[MULT05] WHERE (CVE_ART = @CVE_ART) AND CVE_ALM = @ALMACEN)), 'P',1, ")
                query_minve_entrada.Append("    @FECHAELAB, (SELECT ULT_CVE+1 FROM [SAE60Empre05].[dbo].[TBLCONTROL05] WHERE (ID_TABLA = 32)), 1, 'S', @COSTO_PROM_INI, ")
                query_minve_entrada.Append("    @COSTO_PROM_FIN, @COSTO_PROM_GRAL, 'S', (SELECT ULT_CVE FROM [SAE60Empre05].[dbo].[TBLCONTROL05] WHERE (ID_TABLA = 44))) ")
                Dim comando_minve_entrada As New SqlCommand(query_minve_entrada.ToString, ActualizarConexion)
                comando_minve_entrada.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(5))
                comando_minve_entrada.Parameters.AddWithValue("@ALMACEN", Almacen)
                comando_minve_entrada.Parameters.AddWithValue("@CVE_CPTO", 11)
                comando_minve_entrada.Parameters.AddWithValue("@FECHA_DOCU", Today.Date)
                comando_minve_entrada.Parameters.AddWithValue("@REFER", "EP" & Today.Day.ToString & Today.Month.ToString & Today.Year.ToString & "-" & UltimaClave + 1)

                comando_minve_entrada.Parameters.AddWithValue("@CANT", dt.Rows(index).Item(6))
                comando_minve_entrada.Parameters.AddWithValue("@COSTO", 0)
                comando_minve_entrada.Parameters.AddWithValue("@UNI_VENTA", dt_datos_inve.Rows(0)(1))
                comando_minve_entrada.Parameters.AddWithValue("@E_LTPD", correlativo_lotes_ENTRADA)
                comando_minve_entrada.Parameters.AddWithValue("@FECHAELAB", Today.Date)
                comando_minve_entrada.Parameters.AddWithValue("@COSTO_PROM_INI", 0)
                comando_minve_entrada.Parameters.AddWithValue("@COSTO_PROM_FIN", 0)
                comando_minve_entrada.Parameters.AddWithValue("@COSTO_PROM_GRAL", 0)
                comando_minve_entrada.Transaction = transaccion_sql
                comando_minve_entrada.ExecuteNonQuery()

                'update num mov minve
                Dim query_control_num_mov_entrada As New StringBuilder
                query_control_num_mov_entrada.Append("UPDATE [SAE60Empre05].[dbo].[TBLCONTROL05] ")
                query_control_num_mov_entrada.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                query_control_num_mov_entrada.Append("WHERE [ID_TABLA] = 44 ")
                Dim comando_control_num_mov_entrada As New SqlCommand(query_control_num_mov_entrada.ToString, ActualizarConexion)
                comando_control_num_mov_entrada.Transaction = transaccion_sql
                comando_control_num_mov_entrada.ExecuteNonQuery()

                Try
                    Dim ExistenciaLotes As Integer = 0
                    Dim query_datos As New StringBuilder
                    query_datos.Append("SELECT     dbo.LTPD05.CVE_ART, ISNULL(SUM(dbo.LTPD05.CANTIDAD),0) AS 'EXISTENCIA_LOTE' ")
                    query_datos.Append("FROM dbo.LTPD05 INNER JOIN dbo.INVE05 ON dbo.LTPD05.CVE_ART = dbo.INVE05.CVE_ART   ")
                    query_datos.Append("WHERE   (dbo.LTPD05.CVE_ART = @CODIGO) AND LTPD05.CVE_ALM = @ALMACEN  AND ")
                    query_datos.Append("(dbo.LTPD05.STATUS = 'A') AND dbo.LTPD05.CANTIDAD > 0 AND (dbo.INVE05.CON_LOTE = 'S') GROUP BY dbo.LTPD05.CVE_ART")
                    Dim comando_datos As New SqlCommand(query_datos.ToString, ActualizarConexion)
                    comando_datos.Parameters.AddWithValue("@CODIGO", dt.Rows(index).Item(5))
                    comando_datos.Parameters.AddWithValue("@ALMACEN", Almacen)
                    comando_datos.Transaction = transaccion_sql
                    Dim adaptador_datos As New SqlDataAdapter(comando_datos)
                    Dim dt_datos_Lote As New DataTable
                    adaptador_datos.Fill(dt_datos_Lote)


                    Dim ExistenciaTotal As Integer = 0
                    Dim query_datos2 As New StringBuilder
                    query_datos2.Append("SELECT      dbo.MULT05.EXIST AS EXISTENCIA ")
                    query_datos2.Append("FROM dbo.MULT05 WHERE CVE_ART = @Producto AND CVE_ALM = @ALMACEN ")
                    Dim comando_datos2 As New SqlCommand(query_datos2.ToString, ActualizarConexion)
                    comando_datos2.Parameters.AddWithValue("@CODIGO", dt.Rows(index).Item(5))
                    comando_datos2.Parameters.AddWithValue("@ALMACEN", Almacen)
                    comando_datos2.Transaction = transaccion_sql
                    Dim adaptador_datos2 As New SqlDataAdapter(comando_datos2)
                    Dim dt_datos_Existencia As New DataTable
                    adaptador_datos.Fill(dt_datos_Existencia)

                    If ExistenciaLotes < ExistenciaTotal Then
                        '
                        Dim Diferencia As Integer = 0
                        Diferencia = ExistenciaTotal - ExistenciaLotes

                        'si el lote NO existe
                        Dim nuevo_reg_ltpd As Integer = 0
                        'inicio de seleccinar el autonumerico de los lotes
                        Dim ds_nuevo_reg_ltpd As New DataSet
                        Dim query_nuevo_reg_ltpd2 As New StringBuilder
                        query_nuevo_reg_ltpd2.Append("SELECT (ULT_CVE + 1) AS ULT_CVE ")
                        query_nuevo_reg_ltpd2.Append("FROM [SAE60Empre05].[dbo].[TBLCONTROL05] ")
                        query_nuevo_reg_ltpd2.Append("WHERE (ID_TABLA = 48)")
                        Dim cmd_select_nuevo_reg_ltpd2 As New SqlCommand(query_nuevo_reg_ltpd2.ToString, ActualizarConexion)
                        Dim adapnuevo_reg_ltpd As New SqlDataAdapter(cmd_select_nuevo_reg_ltpd2)
                        cmd_select_nuevo_reg_ltpd2.Transaction = transaccion_sql
                        adapnuevo_reg_ltpd.Fill(ds_nuevo_reg_ltpd)
                        'fin de seleccionar el autonumerico de los lotes
                        nuevo_reg_ltpd = Convert.ToInt32(ds_nuevo_reg_ltpd.Tables(0).Rows(0)(0))

                        'hacer el enlace a los lotes
                        Dim query_enlace_ltpd_ins_entrada As New StringBuilder
                        query_enlace_ltpd_ins_entrada.Append("INSERT INTO [SAE60Empre05].[dbo].[ENLACE_LTPD05] ")
                        query_enlace_ltpd_ins_entrada.Append("(E_LTPD,REG_LTPD,CANTIDAD,PXRS) ")
                        query_enlace_ltpd_ins_entrada.Append("VALUES (@E_LTPD,@REG_LTPD,@CANTIDAD,@PXRS) ")
                        Dim cmd_enlace_ltpd_ins_entrada As New SqlCommand(query_enlace_ltpd_ins_entrada.ToString, ActualizarConexion)
                        cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@E_LTPD", correlativo_lotes_ENTRADA)
                        cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@REG_LTPD", nuevo_reg_ltpd)
                        cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@CANTIDAD", Diferencia)
                        cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@PXRS", Diferencia)
                        cmd_enlace_ltpd_ins_entrada.Transaction = transaccion_sql
                        cmd_enlace_ltpd_ins_entrada.ExecuteNonQuery()
                        'insertar nuevo lote
                        Dim Pre As String = ""
                        If Almacen = 1 Then
                            Pre = "SPS"
                        ElseIf Almacen = 2 Then
                            Pre = "SRC"
                        ElseIf Almacen = 3 Then
                            Pre = "SB"
                        Else
                            Pre = "TG"
                        End If
                        Dim query_insertar_nuevo_lote As New StringBuilder
                        query_insertar_nuevo_lote.Append("INSERT INTO [SAE60Empre05].[dbo].[LTPD05] ")
                        query_insertar_nuevo_lote.Append("([CVE_ART],[LOTE],[PEDIMENTO],[CVE_ALM],[FCHCADUC],[FCHADUANA] ")
                        query_insertar_nuevo_lote.Append(",[FCHULTMOV],[NOM_ADUAN],[CANTIDAD],[REG_LTPD],[CVE_OBS] ")
                        query_insertar_nuevo_lote.Append(",[CIUDAD],[FRONTERA],[FEC_PROD_LT],[GLN],[STATUS]) ")
                        query_insertar_nuevo_lote.Append("VALUES ")
                        query_insertar_nuevo_lote.Append("(@CVE_ART,@LOTE,@PEDIMENTO,@CVE_ALM,@FCHCADUC,@FCHADUANA ")
                        query_insertar_nuevo_lote.Append(",@FCHULTMOV,@NOM_ADUAN,@CANTIDAD,@REG_LTPD,@CVE_OBS,@CIUDAD ")
                        query_insertar_nuevo_lote.Append(",@FRONTERA,@FEC_PROD_LT,@GLN,@STATUS)")
                        Dim cmd_insertar_nuevo_lote As New SqlCommand(query_insertar_nuevo_lote.ToString, ActualizarConexion)
                        cmd_insertar_nuevo_lote.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(5))
                        cmd_insertar_nuevo_lote.Parameters.AddWithValue("@LOTE", Pre & Today.Date.Year.ToString & Today.Date.Month.ToString & Today.Date.Date.ToString)
                        cmd_insertar_nuevo_lote.Parameters.AddWithValue("@PEDIMENTO", "")
                        cmd_insertar_nuevo_lote.Parameters.AddWithValue("@CVE_ALM", Almacen)
                        cmd_insertar_nuevo_lote.Parameters.AddWithValue("@FCHCADUC", DBNull.Value)
                        cmd_insertar_nuevo_lote.Parameters.AddWithValue("@FCHADUANA", DBNull.Value)

                        cmd_insertar_nuevo_lote.Parameters.AddWithValue("@FCHULTMOV", Today.Date)
                        cmd_insertar_nuevo_lote.Parameters.AddWithValue("@NOM_ADUAN", "")
                        cmd_insertar_nuevo_lote.Parameters.AddWithValue("@CANTIDAD", Diferencia)
                        cmd_insertar_nuevo_lote.Parameters.AddWithValue("@REG_LTPD", nuevo_reg_ltpd)
                        cmd_insertar_nuevo_lote.Parameters.AddWithValue("@CVE_OBS", 0)
                        cmd_insertar_nuevo_lote.Parameters.AddWithValue("@CIUDAD", "")
                        cmd_insertar_nuevo_lote.Parameters.AddWithValue("@FRONTERA", "")

                        cmd_insertar_nuevo_lote.Parameters.AddWithValue("@FEC_PROD_LT", DBNull.Value)

                        cmd_insertar_nuevo_lote.Parameters.AddWithValue("@GLN", "")
                        cmd_insertar_nuevo_lote.Parameters.AddWithValue("@STATUS", "A")
                        cmd_insertar_nuevo_lote.Transaction = transaccion_sql
                        cmd_insertar_nuevo_lote.ExecuteNonQuery()

                        'actualizar el autonumerico de lotes
                        Dim query_actualiza_autonumerico_ltpd As New StringBuilder
                        query_actualiza_autonumerico_ltpd.Append("UPDATE [SAE60Empre05].[dbo].[TBLCONTROL05] ")
                        query_actualiza_autonumerico_ltpd.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                        query_actualiza_autonumerico_ltpd.Append("WHERE (ID_TABLA = 48) ")
                        Dim cmd_upd_autonumerico_ltpd As New SqlCommand(query_actualiza_autonumerico_ltpd.ToString, ActualizarConexion)
                        cmd_upd_autonumerico_ltpd.Transaction = transaccion_sql
                        cmd_upd_autonumerico_ltpd.ExecuteNonQuery()
                        '
                    End If

                Catch ex As Exception
                    Dim tamaño2 As Integer = Convert.ToString(ex.StackTrace).Length
                    Dim posicion2 As Integer = InStrRev(Convert.ToString(ex.StackTrace), "línea") - 1
                    Dim inicial2 As Integer = tamaño2 - posicion2
                    Dim linea_error2 As String = Convert.ToString(ex.StackTrace).Substring(tamaño2 - inicial2, inicial2)
                    MsgBox("No se pudieron cuadrar los lotes de la promoción. " & ex.Message.ToString & " Error: " & linea_error2)
                End Try

            Next
            'FIN DE MOVIMIENTOS DEL SAE

            'update cve_folio minve
            Dim query_control_folio As New StringBuilder
            query_control_folio.Append("UPDATE [SAE60Empre05].[dbo].[TBLCONTROL05] ")
            query_control_folio.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
            query_control_folio.Append("WHERE ([ID_TABLA] = 32) ")
            Dim comando_control_folio As New SqlCommand(query_control_folio.ToString, ActualizarConexion)
            comando_control_folio.Transaction = transaccion_sql
            comando_control_folio.ExecuteNonQuery()

            Dim conexion_bita As New cls_bitacora_reporteador
            conexion_bita.RegistraBitacora(Now, usuario, "Realizó Traslado de Producto a Promoción", "ALMACEN", _
                                      "Fecha: " & DateTime.Now & " Cantidad de Productos: " & dt.Rows.Count & " Almacén:" & Almacen)



            transaccion_sql.Commit()
            ActualizarConexion.Close()
            Return "correcto"

        Catch ex As Exception
            Dim tamaño As Integer = Convert.ToString(ex.StackTrace).Length
            Dim posicion As Integer = InStrRev(Convert.ToString(ex.StackTrace), "línea") - 1
            Dim inicial As Integer = tamaño - posicion
            Dim linea_error As String = Convert.ToString(ex.StackTrace).Substring(tamaño - inicial, inicial)
            transaccion_sql.Rollback()
            ActualizarConexion.Close()
            Return ex.Message & " " & linea_error
        End Try
    End Function

    Public Function GuardarPromocionesAGRO(ByVal dt As DataTable, ByVal usuario As String, ByVal Empresa As String, ByVal Almacen As Integer)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim transaccion_sql As SqlTransaction
        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand



            For index As Integer = 0 To dt.Rows.Count - 1

                Dim UltimaClave As Integer = 0
                Dim dt_CVE As New DataTable
                Dim query_CVE As New StringBuilder
                query_CVE.Append("SELECT MAX([Usuarios].[dbo].[PROMO_MOVIMIENTOS].[PROM_ID]) FROM [Usuarios].[dbo].[PROMO_MOVIMIENTOS] ")

                Dim cmd_select_CVE As New SqlCommand(query_CVE.ToString, ActualizarConexion)
                Dim adaptador_CVE As New SqlDataAdapter(cmd_select_CVE)
                cmd_select_CVE.Transaction = transaccion_sql
                adaptador_CVE.Fill(dt_CVE)
                If Not IsDBNull(dt_CVE.Rows(0)(0)) Then
                    UltimaClave = dt_CVE.Rows(0)(0)
                End If

                miComando = New SqlCommand("INSERT INTO [Usuarios].[dbo].[PROMO_MOVIMIENTOS] " & _
                                             "([PROM_ID], [PROM_DETALLE], [PROM_FECHA], [CVE_PRODUCTO], [PRODUCTO_UNIDAD], [PRODUCTO_CANTIDAD], [CVE_PROM], [PROM_UNIDAD], [PROM_CANTIDAD], [CONCEPTO_PROV],[EMPRESA], [ALMACEN]) " & _
                                             "VALUES(@PROM_ID, @PROM_DETALLE, @PROM_FECHA, @CVE_PRODUCTO, @PRODUCTO_UNIDAD, @PRODUCTO_CANTIDAD, @CVE_PROM, @PROM_UNIDAD, @PROM_CANTIDAD, @CONCEPTO_PROV, @EMPRESA, @ALMACEN) ", ActualizarConexion)
                miComando.Parameters.AddWithValue("@PROM_ID", UltimaClave + 1)
                miComando.Parameters.AddWithValue("@PROM_DETALLE", dt.Rows(index).Item(0))
                miComando.Parameters.AddWithValue("@PROM_FECHA", DateTime.Now)
                miComando.Parameters.AddWithValue("@CVE_PRODUCTO", dt.Rows(index).Item(1))
                miComando.Parameters.AddWithValue("@PRODUCTO_UNIDAD", dt.Rows(index).Item(3))
                miComando.Parameters.AddWithValue("@PRODUCTO_CANTIDAD", dt.Rows(index).Item(2))
                miComando.Parameters.AddWithValue("@CVE_PROM", dt.Rows(index).Item(5))
                miComando.Parameters.AddWithValue("@PROM_UNIDAD", dt.Rows(index).Item(7))
                miComando.Parameters.AddWithValue("@PROM_CANTIDAD", dt.Rows(index).Item(6))
                miComando.Parameters.AddWithValue("@CONCEPTO_PROV", dt.Rows(index).Item(9))
                miComando.Parameters.AddWithValue("@EMPRESA", Empresa)
                miComando.Parameters.AddWithValue("@ALMACEN", Almacen)
                miComando.Transaction = transaccion_sql
                miComando.ExecuteNonQuery()

                ' registrar las salidas
                'update MULT
                Dim query_mult_salida As New StringBuilder
                query_mult_salida.Append("UPDATE [SAE60Empre02].[dbo].[MULT02] ")
                query_mult_salida.Append("SET [EXIST] = ISNULL(EXIST,0) - @CANTIDAD ")
                query_mult_salida.Append("WHERE [CVE_ART] = @CVE_ART AND [CVE_ALM] = @CVE_ALM ")
                Dim comando_mult_salida As New SqlCommand(query_mult_salida.ToString, ActualizarConexion)
                comando_mult_salida.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(1))
                comando_mult_salida.Parameters.AddWithValue("@CVE_ALM", Almacen)
                comando_mult_salida.Parameters.AddWithValue("@CANTIDAD", dt.Rows(index).Item(2))
                comando_mult_salida.Transaction = transaccion_sql
                comando_mult_salida.ExecuteNonQuery()

                'update INVE
                Dim query_inve As New StringBuilder
                query_inve.Append("UPDATE [SAE60Empre02].[dbo].[INVE02] ")
                query_inve.Append("SET [EXIST] = EXIST - @CANTIDAD ")
                query_inve.Append("WHERE [CVE_ART] = @CVE_ART ")
                Dim comando_inve_salida As New SqlCommand(query_inve.ToString, ActualizarConexion)
                comando_inve_salida.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(1))
                comando_inve_salida.Parameters.AddWithValue("@CANTIDAD", dt.Rows(index).Item(2))
                comando_inve_salida.Transaction = transaccion_sql
                comando_inve_salida.ExecuteNonQuery()

                'INICIO DE LOS LOTES

                Dim dt_lotes_crear As New DataTable
                dt_lotes_crear.Columns.Clear()
                dt_lotes_crear.Columns.Add("LOTE")
                dt_lotes_crear.Columns.Add("CANT")
                dt_lotes_crear.Columns.Add("PEDIMENTO")
                dt_lotes_crear.Columns.Add("FCHCADUC")
                dt_lotes_crear.Columns.Add("FCHADUANA")
                dt_lotes_crear.Columns.Add("NOM_ADUANA")
                dt_lotes_crear.Columns.Add("CVE_OBS")
                dt_lotes_crear.Columns.Add("CIUDAD")
                dt_lotes_crear.Columns.Add("FRONTERA")
                dt_lotes_crear.Columns.Add("FEC_PROD_LT")
                dt_lotes_crear.Columns.Add("GLN")
                Dim correlativo_lotes As Integer = 0
                dt_lotes_crear.Rows.Clear()
                If dt.Rows(index).Item(4) = "S" Then
                    Dim ds_lotes As New DataSet
                    Dim cantidad As Double = 0, can_insertar As Double = 0

                    Dim query As New StringBuilder
                    query.Append("SELECT LOTE, CVE_ALM, FCHCADUC, CANTIDAD, REG_LTPD,PEDIMENTO,FCHADUANA, ")
                    query.Append("NOM_ADUAN,CVE_OBS,CIUDAD,FRONTERA,FEC_PROD_LT, GLN ")
                    query.Append("FROM [SAE60Empre02].[dbo].[LTPD02] WHERE (STATUS = 'A') AND (CVE_ART = @CVE_ART) AND CVE_ALM = @CVE_ALM")
                    query.Append(" AND (CANTIDAD > 0) AND (FCHCADUC > GETDATE() OR FCHCADUC IS NULL OR FCHCADUC = '') ")
                    query.Append("ORDER BY FCHCADUC ")
                    Dim cmd_select_lotes As New SqlCommand(query.ToString, ActualizarConexion)
                    cmd_select_lotes.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(1))
                    cmd_select_lotes.Parameters.AddWithValue("@CVE_ALM", Almacen)
                    Dim adaptador As New SqlDataAdapter(cmd_select_lotes)
                    cmd_select_lotes.Transaction = transaccion_sql
                    adaptador.Fill(ds_lotes)
                    cantidad = Convert.ToDouble(dt.Rows(index).Item(2))

                    'for de los lotes
                    For index1 As Integer = 0 To ds_lotes.Tables(0).Rows.Count
                        'MsgBox("Lotes de Salida " & ds_lotes.Tables(0).Rows.Count)
                        correlativo_lotes = 0
                        'inicio de seleccinar el autonumerico de los enlace lotes
                        Dim ds_correlativo_lotes As New DataSet
                        Dim query_correlativo_lotes As New StringBuilder
                        query_correlativo_lotes.Append("SELECT (ULT_CVE + 1) AS ULT_CVE ")
                        query_correlativo_lotes.Append("FROM [SAE60Empre02].[dbo].[TBLCONTROL02] ")
                        query_correlativo_lotes.Append("WHERE (ID_TABLA = 67)")
                        Dim cmd_select_correlativo_enlace As New SqlCommand(query_correlativo_lotes.ToString, ActualizarConexion)
                        Dim adapenlace As New SqlDataAdapter(cmd_select_correlativo_enlace)
                        cmd_select_correlativo_enlace.Transaction = transaccion_sql
                        adapenlace.Fill(ds_correlativo_lotes)
                        'fin de seleccionar el autonumerico de los enlace lotes
                        correlativo_lotes = Convert.ToInt32(ds_correlativo_lotes.Tables(0).Rows(0)(0))

                        Dim NumeroLote As Integer = 0

                        If (ds_lotes.Tables(0).Rows.Count > 0) Then
                            NumeroLote = ds_lotes.Tables(0).Rows(index1)(3)
                        End If

                        If NumeroLote >= cantidad Then
                            can_insertar = cantidad
                            'hacer el enlace a los lotes
                            Dim query_enlace As New StringBuilder
                            query_enlace.Append("INSERT INTO [SAE60Empre02].[dbo].[ENLACE_LTPD02] ")
                            query_enlace.Append("(E_LTPD,REG_LTPD,CANTIDAD,PXRS) ")
                            query_enlace.Append("VALUES (@E_LTPD,@REG_LTPD,@CANTIDAD,@PXRS) ")
                            Dim cmd_enlace_ltp As New SqlCommand(query_enlace.ToString, ActualizarConexion)
                            cmd_enlace_ltp.Parameters.AddWithValue("@E_LTPD", correlativo_lotes)
                            cmd_enlace_ltp.Parameters.AddWithValue("@REG_LTPD", Convert.ToInt32(ds_lotes.Tables(0).Rows(index1)(4)))
                            cmd_enlace_ltp.Parameters.AddWithValue("@CANTIDAD", cantidad)
                            cmd_enlace_ltp.Parameters.AddWithValue("@PXRS", cantidad)
                            cmd_enlace_ltp.Transaction = transaccion_sql
                            cmd_enlace_ltp.ExecuteNonQuery()

                            Dim new_row As DataRow = dt_lotes_crear.NewRow
                            new_row(0) = Convert.ToString(ds_lotes.Tables(0).Rows(index1)(0))
                            new_row(1) = cantidad
                            new_row(2) = ds_lotes.Tables(0).Rows(index1)(5)
                            new_row(3) = ds_lotes.Tables(0).Rows(index1)(2)
                            new_row(4) = ds_lotes.Tables(0).Rows(index1)(6)
                            new_row(5) = ds_lotes.Tables(0).Rows(index1)(7)
                            new_row(6) = ds_lotes.Tables(0).Rows(index1)(8)
                            new_row(7) = ds_lotes.Tables(0).Rows(index1)(9)
                            new_row(8) = ds_lotes.Tables(0).Rows(index1)(10)
                            new_row(9) = ds_lotes.Tables(0).Rows(index1)(11)
                            new_row(10) = ds_lotes.Tables(0).Rows(index1)(12)
                            dt_lotes_crear.Rows.Add(new_row)

                            'actualizar las existencias de los lotes
                            Dim query_ltpd As New StringBuilder
                            query_ltpd.Append("UPDATE [SAE60Empre02].[dbo].[LTPD02] ")
                            query_ltpd.Append("SET [FCHULTMOV] = @FCHULTMOV ")
                            query_ltpd.Append(",[CANTIDAD] = (CANTIDAD - @NUEVA_CANTIDAD) ")
                            query_ltpd.Append("WHERE [CVE_ART] = @CVE_ART AND [LOTE] = @LOTE AND [CVE_ALM] = @CVE_ALM ")
                            Dim cmd_ltpd As New SqlCommand(query_ltpd.ToString, ActualizarConexion)
                            cmd_ltpd.Parameters.AddWithValue("@FCHULTMOV", Today.Date)
                            cmd_ltpd.Parameters.AddWithValue("@NUEVA_CANTIDAD", cantidad)
                            cmd_ltpd.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(1))
                            cmd_ltpd.Parameters.AddWithValue("@LOTE", Convert.ToString(ds_lotes.Tables(0).Rows(index1)(0)))
                            cmd_ltpd.Parameters.AddWithValue("@CVE_ALM", Almacen)
                            cmd_ltpd.Transaction = transaccion_sql
                            cmd_ltpd.ExecuteNonQuery()
                            index1 = ds_lotes.Tables(0).Rows.Count
                        Else
                            can_insertar = (Convert.ToDouble(NumeroLote) - Convert.ToDouble(dt.Rows(index).Item(2)) + Convert.ToDouble(dt.Rows(index).Item(2)))

                            'hacer el enlace a los lotes
                            Dim query_enlace_ltpd_ins As New StringBuilder
                            query_enlace_ltpd_ins.Append("INSERT INTO [SAE60Empre02].[dbo].[ENLACE_LTPD02] ")
                            query_enlace_ltpd_ins.Append("(E_LTPD,REG_LTPD,CANTIDAD,PXRS) ")
                            query_enlace_ltpd_ins.Append("VALUES (@E_LTPD,@REG_LTPD,@CANTIDAD,@PXRS) ")
                            Dim cmd_enlace_ltpd_ins As New SqlCommand(query_enlace_ltpd_ins.ToString, ActualizarConexion)
                            cmd_enlace_ltpd_ins.Parameters.AddWithValue("@E_LTPD", correlativo_lotes)
                            cmd_enlace_ltpd_ins.Parameters.AddWithValue("@REG_LTPD", Convert.ToInt32(ds_lotes.Tables(0).Rows(index1)(4)))
                            cmd_enlace_ltpd_ins.Parameters.AddWithValue("@CANTIDAD", can_insertar)
                            cmd_enlace_ltpd_ins.Parameters.AddWithValue("@PXRS", can_insertar)
                            cmd_enlace_ltpd_ins.Transaction = transaccion_sql
                            cmd_enlace_ltpd_ins.ExecuteNonQuery()

                            Dim new_row As DataRow = dt_lotes_crear.NewRow
                            new_row(0) = Convert.ToString(ds_lotes.Tables(0).Rows(index1)(0))
                            new_row(1) = can_insertar
                            new_row(2) = ds_lotes.Tables(0).Rows(index1)(5)
                            new_row(3) = ds_lotes.Tables(0).Rows(index1)(2)
                            new_row(4) = ds_lotes.Tables(0).Rows(index1)(6)
                            new_row(5) = ds_lotes.Tables(0).Rows(index1)(7)
                            new_row(6) = ds_lotes.Tables(0).Rows(index1)(8)
                            new_row(7) = ds_lotes.Tables(0).Rows(index1)(9)
                            new_row(8) = ds_lotes.Tables(0).Rows(index1)(10)
                            new_row(9) = ds_lotes.Tables(0).Rows(index1)(11)
                            new_row(10) = ds_lotes.Tables(0).Rows(index1)(12)
                            dt_lotes_crear.Rows.Add(new_row)

                            Dim query_upd_ltpd As New StringBuilder
                            query_upd_ltpd.Append("UPDATE [SAE60Empre02].[dbo].[LTPD02] ")
                            query_upd_ltpd.Append("SET [FCHULTMOV] = @FCHULTMOV ")
                            query_upd_ltpd.Append(",[CANTIDAD] = (CANTIDAD - @NUEVA_CANTIDAD) ")
                            query_upd_ltpd.Append("WHERE [CVE_ART] = @CVE_ART AND [LOTE] = @LOTE AND [CVE_ALM] = @CVE_ALM ")
                            Dim cmd_ltpd_upd As New SqlCommand(query_upd_ltpd.ToString, ActualizarConexion)
                            cmd_ltpd_upd.Parameters.AddWithValue("@FCHULTMOV", Convert.ToDateTime(dt.Rows(0).Item(6)))
                            cmd_ltpd_upd.Parameters.AddWithValue("@NUEVA_CANTIDAD", can_insertar)
                            cmd_ltpd_upd.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(1))
                            cmd_ltpd_upd.Parameters.AddWithValue("@LOTE", Convert.ToString(ds_lotes.Tables(0).Rows(index1)(0)))
                            cmd_ltpd_upd.Parameters.AddWithValue("@CVE_ALM", Almacen)
                            cmd_ltpd_upd.Transaction = transaccion_sql
                            cmd_ltpd_upd.ExecuteNonQuery()
                            cantidad = cantidad - Convert.ToInt32(ds_lotes.Tables(0).Rows(index1)(3))
                            can_insertar = cantidad
                        End If
                    Next

                    'actualizar los correlativos de los lotes
                    Dim query_actualiza_lotes As New StringBuilder
                    query_actualiza_lotes.Append("UPDATE [SAE60Empre02].[dbo].[TBLCONTROL02] ")
                    query_actualiza_lotes.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                    query_actualiza_lotes.Append("WHERE (ID_TABLA = 67) ")
                    Dim cmd_upd_correlativo_lot As New SqlCommand(query_actualiza_lotes.ToString, ActualizarConexion)
                    cmd_upd_correlativo_lot.Transaction = transaccion_sql
                    cmd_upd_correlativo_lot.ExecuteNonQuery()

                End If
                'FIN DE LOS LOTES

                'select Datos INVE
                Dim query_datos_inve As New StringBuilder
                query_datos_inve.Append("SELECT ISNULL(COSTO_PROM,0), ISNULL(UNI_MED,'') ")
                query_datos_inve.Append("FROM [SAE60Empre02].[dbo].[INVE02] ")
                query_datos_inve.Append("WHERE CVE_ART = @CVE_ART")
                Dim comando_datos_inve As New SqlCommand(query_datos_inve.ToString, ActualizarConexion)
                comando_datos_inve.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(1))
                comando_datos_inve.Transaction = transaccion_sql
                Dim adaptador_datos_inve As New SqlDataAdapter(comando_datos_inve)
                Dim dt_datos_inve As New DataTable
                adaptador_datos_inve.Fill(dt_datos_inve)

                'insert MINVE
                Dim query_minve As New StringBuilder
                query_minve.Append("INSERT INTO [SAE60Empre02].[dbo].[MINVE02] ")
                query_minve.Append("   ([CVE_ART],[ALMACEN],[NUM_MOV],[CVE_CPTO],[FECHA_DOCU],[TIPO_DOC],[REFER], ")
                query_minve.Append("    [CANT],[CANT_COST],[PRECIO],[COSTO], ")
                query_minve.Append("    [REG_SERIE],[UNI_VENTA],[E_LTPD],[EXIST_G],[EXISTENCIA],[TIPO_PROD],[FACTOR_CON], ")
                query_minve.Append("    [FECHAELAB],[CVE_FOLIO],[SIGNO],[COSTEADO],[COSTO_PROM_INI], ")
                query_minve.Append("    [COSTO_PROM_FIN],[COSTO_PROM_GRAL],[DESDE_INVE],[MOV_ENLAZADO]) ")
                query_minve.Append(" VALUES ")
                query_minve.Append("   (@CVE_ART,@ALMACEN,(SELECT ULT_CVE+1 FROM [SAE60Empre02].[dbo].[TBLCONTROL02] WHERE (ID_TABLA = 44)), ")
                query_minve.Append("    @CVE_CPTO,@FECHA_DOCU,'M',@REFER,@CANT,0,0,@COSTO,0, ")
                query_minve.Append("    @UNI_VENTA,@E_LTPD, ((SELECT ISNULL(EXIST,0) FROM [SAE60Empre02].[dbo].[INVE02] WHERE CVE_ART = @CVE_ART)), ")
                query_minve.Append("    ((SELECT EXIST FROM [SAE60Empre02].[dbo].[MULT02] WHERE (CVE_ART = @CVE_ART) AND CVE_ALM = @ALMACEN)), 'P',1, ")
                query_minve.Append("    @FECHAELAB, (SELECT ULT_CVE+1 FROM [SAE60Empre02].[dbo].[TBLCONTROL02] WHERE (ID_TABLA = 32)), -1, 'S', @COSTO_PROM_INI, ")
                query_minve.Append("    @COSTO_PROM_FIN, @COSTO_PROM_GRAL, 'S', 0) ")

                Dim comando_minve_salida As New SqlCommand(query_minve.ToString, ActualizarConexion)
                comando_minve_salida.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(1))
                comando_minve_salida.Parameters.AddWithValue("@ALMACEN", Almacen)
                comando_minve_salida.Parameters.AddWithValue("@CVE_CPTO", 63)
                comando_minve_salida.Parameters.AddWithValue("@FECHA_DOCU", Today.Date)
                comando_minve_salida.Parameters.AddWithValue("@REFER", "SP" & Today.Day.ToString & Today.Month.ToString & Today.Year.ToString & "-" & UltimaClave + 1)
                comando_minve_salida.Parameters.AddWithValue("@CANT", dt.Rows(index).Item(2))
                comando_minve_salida.Parameters.AddWithValue("@COSTO", dt_datos_inve.Rows(0)(0))
                comando_minve_salida.Parameters.AddWithValue("@UNI_VENTA", dt_datos_inve.Rows(0)(1))
                comando_minve_salida.Parameters.AddWithValue("@E_LTPD", correlativo_lotes)
                comando_minve_salida.Parameters.AddWithValue("@FECHAELAB", Today.Date)
                comando_minve_salida.Parameters.AddWithValue("@COSTO_PROM_INI", dt_datos_inve.Rows(0)(0))
                comando_minve_salida.Parameters.AddWithValue("@COSTO_PROM_FIN", dt_datos_inve.Rows(0)(0))
                comando_minve_salida.Parameters.AddWithValue("@COSTO_PROM_GRAL", dt_datos_inve.Rows(0)(0))
                comando_minve_salida.Transaction = transaccion_sql
                comando_minve_salida.ExecuteNonQuery()

                'update num mov minve
                Dim query_control_num_mov As New StringBuilder
                query_control_num_mov.Append("UPDATE [SAE60Empre02].[dbo].[TBLCONTROL02] ")
                query_control_num_mov.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                query_control_num_mov.Append("WHERE [ID_TABLA] = 44 ")
                Dim comando_control_num_mov As New SqlCommand(query_control_num_mov.ToString, ActualizarConexion)
                comando_control_num_mov.Transaction = transaccion_sql
                comando_control_num_mov.ExecuteNonQuery()

                'FIN DE REGISTRAR LAS SALIDAS

                'INICIO REGISTRAR LAS ENTRADAS
                'update MULT
                Dim query_mult_entrada As New StringBuilder
                query_mult_entrada.Append("UPDATE [SAE60Empre02].[dbo].[MULT02] ")
                query_mult_entrada.Append("SET [EXIST] = ISNULL(EXIST,0) + @CANTIDAD ")
                query_mult_entrada.Append("WHERE [CVE_ART] = @CVE_ART AND [CVE_ALM] = @CVE_ALM ")
                Dim comando_mult_entrada As New SqlCommand(query_mult_entrada.ToString, ActualizarConexion)
                comando_mult_entrada.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(5))
                comando_mult_entrada.Parameters.AddWithValue("@CVE_ALM", Almacen)
                comando_mult_entrada.Parameters.AddWithValue("@CANTIDAD", dt.Rows(index).Item(6))
                comando_mult_entrada.Transaction = transaccion_sql
                comando_mult_entrada.ExecuteNonQuery()

                'update INVE
                Dim query_inve_entrada As New StringBuilder
                query_inve_entrada.Append("UPDATE [SAE60Empre02].[dbo].[INVE02] ")
                query_inve_entrada.Append("SET [EXIST] = EXIST + @CANTIDAD ")
                query_inve_entrada.Append("WHERE [CVE_ART] = @CVE_ART ")
                Dim comando_inve_entrada As New SqlCommand(query_inve_entrada.ToString, ActualizarConexion)
                comando_inve_entrada.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(5))
                comando_inve_entrada.Parameters.AddWithValue("@CANTIDAD", dt.Rows(index).Item(6))
                comando_inve_entrada.Transaction = transaccion_sql
                comando_inve_entrada.ExecuteNonQuery()


                'INICIO DE LOS LOTES
                Dim correlativo_lotes_ENTRADA As Integer = 0
                If dt.Rows(index).Item(8) = "S" Then
                    For index2 As Integer = 0 To dt_lotes_crear.Rows.Count - 1

                        'MsgBox("Lotes de Entrada " & dt_lotes_crear.Rows.Count)

                        correlativo_lotes_ENTRADA = 0
                        'inicio de seleccinar el autonumerico de los enlace lotes
                        Dim ds_correlativo_lotes As New DataSet
                        Dim query_correlativo_lotes As New StringBuilder
                        query_correlativo_lotes.Append("SELECT (ULT_CVE + 1) AS ULT_CVE ")
                        query_correlativo_lotes.Append("FROM [SAE60Empre02].[dbo].[TBLCONTROL02] ")
                        query_correlativo_lotes.Append("WHERE (ID_TABLA = 67)")
                        Dim cmd_select_correlativo_enlace As New SqlCommand(query_correlativo_lotes.ToString, ActualizarConexion)
                        Dim adapenlace As New SqlDataAdapter(cmd_select_correlativo_enlace)
                        cmd_select_correlativo_enlace.Transaction = transaccion_sql
                        adapenlace.Fill(ds_correlativo_lotes)
                        'fin de seleccionar el autonumerico de los enlace lotes
                        correlativo_lotes_ENTRADA = Convert.ToInt32(ds_correlativo_lotes.Tables(0).Rows(0)(0))

                        Dim query_valida_lote As New StringBuilder
                        query_valida_lote.Append("SELECT CVE_ART,LOTE,REG_LTPD ")
                        query_valida_lote.Append("FROM [SAE60Empre02].[dbo].[LTPD02] ")
                        query_valida_lote.Append("WHERE LOTE = @LOTE AND CVE_ALM = @ALMACEN AND CVE_ART = @CVE_ART ")
                        Dim cmd_valida_lote As New SqlCommand(query_valida_lote.ToString, ActualizarConexion)
                        cmd_valida_lote.Parameters.AddWithValue("@LOTE", dt_lotes_crear.Rows(index2)(0))
                        cmd_valida_lote.Parameters.AddWithValue("@ALMACEN", Almacen)
                        cmd_valida_lote.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(5))
                        cmd_valida_lote.Transaction = transaccion_sql
                        Dim adaptador_valida_lote As New SqlDataAdapter(cmd_valida_lote)
                        Dim dt_valida_lote As New DataTable
                        adaptador_valida_lote.Fill(dt_valida_lote)

                        If dt_valida_lote.Rows.Count > 0 Then
                            'si el lote existe
                            'hacer el enlace a los lotes
                            Dim query_enlace_ltpd_ins_entrada As New StringBuilder
                            query_enlace_ltpd_ins_entrada.Append("INSERT INTO [SAE60Empre02].[dbo].[ENLACE_LTPD02] ")
                            query_enlace_ltpd_ins_entrada.Append("(E_LTPD,REG_LTPD,CANTIDAD,PXRS) ")
                            query_enlace_ltpd_ins_entrada.Append("VALUES (@E_LTPD,@REG_LTPD,@CANTIDAD,@PXRS) ")
                            Dim cmd_enlace_ltpd_ins_entrada As New SqlCommand(query_enlace_ltpd_ins_entrada.ToString, ActualizarConexion)
                            cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@E_LTPD", correlativo_lotes_ENTRADA)
                            cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@REG_LTPD", dt_valida_lote.Rows(0)(2))
                            cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@CANTIDAD", dt_lotes_crear.Rows(index2)(1))
                            cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@PXRS", dt_lotes_crear.Rows(index2)(1))
                            cmd_enlace_ltpd_ins_entrada.Transaction = transaccion_sql
                            cmd_enlace_ltpd_ins_entrada.ExecuteNonQuery()

                            Dim query_upd_ltpd As New StringBuilder
                            query_upd_ltpd.Append("UPDATE [SAE60Empre02].[dbo].[LTPD02] ")
                            query_upd_ltpd.Append("SET [FCHULTMOV] = @FCHULTMOV ")
                            query_upd_ltpd.Append(",[CANTIDAD] = (CANTIDAD + @NUEVA_CANTIDAD) ")
                            query_upd_ltpd.Append("WHERE [CVE_ART] = @CVE_ART AND [LOTE] = @LOTE AND [CVE_ALM] = @CVE_ALM ")
                            Dim cmd_ltpd_upd As New SqlCommand(query_upd_ltpd.ToString, ActualizarConexion)
                            cmd_ltpd_upd.Parameters.AddWithValue("@FCHULTMOV", Today.Date)
                            cmd_ltpd_upd.Parameters.AddWithValue("@NUEVA_CANTIDAD", dt_lotes_crear.Rows(index2)(1))
                            cmd_ltpd_upd.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(5))
                            cmd_ltpd_upd.Parameters.AddWithValue("@LOTE", dt_valida_lote.Rows(0)(1))
                            cmd_ltpd_upd.Parameters.AddWithValue("@CVE_ALM", Almacen)
                            cmd_ltpd_upd.Transaction = transaccion_sql
                            cmd_ltpd_upd.ExecuteNonQuery()
                        Else
                            'si el lote NO existe
                            Dim nuevo_reg_ltpd As Integer = 0
                            'inicio de seleccinar el autonumerico de los lotes
                            Dim ds_nuevo_reg_ltpd As New DataSet
                            Dim query_nuevo_reg_ltpd2 As New StringBuilder
                            query_nuevo_reg_ltpd2.Append("SELECT (ULT_CVE + 1) AS ULT_CVE ")
                            query_nuevo_reg_ltpd2.Append("FROM [SAE60Empre02].[dbo].[TBLCONTROL02] ")
                            query_nuevo_reg_ltpd2.Append("WHERE (ID_TABLA = 48)")
                            Dim cmd_select_nuevo_reg_ltpd2 As New SqlCommand(query_nuevo_reg_ltpd2.ToString, ActualizarConexion)
                            Dim adapnuevo_reg_ltpd As New SqlDataAdapter(cmd_select_nuevo_reg_ltpd2)
                            cmd_select_nuevo_reg_ltpd2.Transaction = transaccion_sql
                            adapnuevo_reg_ltpd.Fill(ds_nuevo_reg_ltpd)
                            'fin de seleccionar el autonumerico de los lotes
                            nuevo_reg_ltpd = Convert.ToInt32(ds_nuevo_reg_ltpd.Tables(0).Rows(0)(0))

                            'hacer el enlace a los lotes
                            Dim query_enlace_ltpd_ins_entrada As New StringBuilder
                            query_enlace_ltpd_ins_entrada.Append("INSERT INTO [SAE60Empre02].[dbo].[ENLACE_LTPD02] ")
                            query_enlace_ltpd_ins_entrada.Append("(E_LTPD,REG_LTPD,CANTIDAD,PXRS) ")
                            query_enlace_ltpd_ins_entrada.Append("VALUES (@E_LTPD,@REG_LTPD,@CANTIDAD,@PXRS) ")
                            Dim cmd_enlace_ltpd_ins_entrada As New SqlCommand(query_enlace_ltpd_ins_entrada.ToString, ActualizarConexion)
                            cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@E_LTPD", correlativo_lotes_ENTRADA)
                            cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@REG_LTPD", nuevo_reg_ltpd)
                            cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@CANTIDAD", dt_lotes_crear.Rows(index2)(1))
                            cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@PXRS", dt_lotes_crear.Rows(index2)(1))
                            cmd_enlace_ltpd_ins_entrada.Transaction = transaccion_sql
                            cmd_enlace_ltpd_ins_entrada.ExecuteNonQuery()
                            'insertar nuevo lote
                            Dim query_insertar_nuevo_lote As New StringBuilder
                            query_insertar_nuevo_lote.Append("INSERT INTO [SAE60Empre02].[dbo].[LTPD02] ")
                            query_insertar_nuevo_lote.Append("([CVE_ART],[LOTE],[PEDIMENTO],[CVE_ALM],[FCHCADUC],[FCHADUANA] ")
                            query_insertar_nuevo_lote.Append(",[FCHULTMOV],[NOM_ADUAN],[CANTIDAD],[REG_LTPD],[CVE_OBS] ")
                            query_insertar_nuevo_lote.Append(",[CIUDAD],[FRONTERA],[FEC_PROD_LT],[GLN],[STATUS]) ")
                            query_insertar_nuevo_lote.Append("VALUES ")
                            query_insertar_nuevo_lote.Append("(@CVE_ART,@LOTE,@PEDIMENTO,@CVE_ALM,@FCHCADUC,@FCHADUANA ")
                            query_insertar_nuevo_lote.Append(",@FCHULTMOV,@NOM_ADUAN,@CANTIDAD,@REG_LTPD,@CVE_OBS,@CIUDAD ")
                            query_insertar_nuevo_lote.Append(",@FRONTERA,@FEC_PROD_LT,@GLN,@STATUS)")
                            Dim cmd_insertar_nuevo_lote As New SqlCommand(query_insertar_nuevo_lote.ToString, ActualizarConexion)
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(5))
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@LOTE", dt_lotes_crear.Rows(index2)(0))
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@PEDIMENTO", dt_lotes_crear.Rows(index2)(2))
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@CVE_ALM", Almacen)

                            If IsDBNull(dt_lotes_crear.Rows(index2)(3)) = True Then
                                cmd_insertar_nuevo_lote.Parameters.AddWithValue("@FCHCADUC", DBNull.Value)
                            Else
                                cmd_insertar_nuevo_lote.Parameters.AddWithValue("@FCHCADUC", Convert.ToDateTime(dt_lotes_crear.Rows(index2)(3)))
                            End If

                            If IsDBNull(dt_lotes_crear.Rows(index2)(4)) = True Then
                                cmd_insertar_nuevo_lote.Parameters.AddWithValue("@FCHADUANA", DBNull.Value)
                            Else
                                cmd_insertar_nuevo_lote.Parameters.AddWithValue("@FCHADUANA", Convert.ToDateTime(dt_lotes_crear.Rows(index2)(4)))
                            End If

                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@FCHULTMOV", Today.Date)
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@NOM_ADUAN", dt_lotes_crear.Rows(index2)(5))
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@CANTIDAD", dt_lotes_crear.Rows(index2)(1))
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@REG_LTPD", nuevo_reg_ltpd)
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@CVE_OBS", dt_lotes_crear.Rows(index2)(6))
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@CIUDAD", dt_lotes_crear.Rows(index2)(7))
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@FRONTERA", dt_lotes_crear.Rows(index2)(8))
                            If IsDBNull(dt_lotes_crear.Rows(index2)(9)) = True Then
                                cmd_insertar_nuevo_lote.Parameters.AddWithValue("@FEC_PROD_LT", DBNull.Value)
                            Else
                                cmd_insertar_nuevo_lote.Parameters.AddWithValue("@FEC_PROD_LT", Convert.ToDateTime(dt_lotes_crear.Rows(index2)(9)))
                            End If
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@GLN", dt_lotes_crear.Rows(index2)(10))
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@STATUS", "A")
                            cmd_insertar_nuevo_lote.Transaction = transaccion_sql
                            cmd_insertar_nuevo_lote.ExecuteNonQuery()

                            'actualizar el autonumerico de lotes
                            Dim query_actualiza_autonumerico_ltpd As New StringBuilder
                            query_actualiza_autonumerico_ltpd.Append("UPDATE [SAE60Empre02].[dbo].[TBLCONTROL02] ")
                            query_actualiza_autonumerico_ltpd.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                            query_actualiza_autonumerico_ltpd.Append("WHERE (ID_TABLA = 48) ")
                            Dim cmd_upd_autonumerico_ltpd As New SqlCommand(query_actualiza_autonumerico_ltpd.ToString, ActualizarConexion)
                            cmd_upd_autonumerico_ltpd.Transaction = transaccion_sql
                            cmd_upd_autonumerico_ltpd.ExecuteNonQuery()

                        End If
                    Next

                    'actualizar los correlativos de enlace de lotes
                    Dim query_actualiza_lotes As New StringBuilder
                    query_actualiza_lotes.Append("UPDATE [SAE60Empre02].[dbo].[TBLCONTROL02] ")
                    query_actualiza_lotes.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                    query_actualiza_lotes.Append("WHERE (ID_TABLA = 67) ")
                    Dim cmd_upd_correlativo_lot As New SqlCommand(query_actualiza_lotes.ToString, ActualizarConexion)
                    cmd_upd_correlativo_lot.Transaction = transaccion_sql
                    cmd_upd_correlativo_lot.ExecuteNonQuery()
                End If

                'insert MINVE
                Dim query_minve_entrada As New StringBuilder
                query_minve_entrada.Append("INSERT INTO [SAE60Empre02].[dbo].[MINVE02] ")
                query_minve_entrada.Append("   ([CVE_ART],[ALMACEN],[NUM_MOV],[CVE_CPTO],[FECHA_DOCU],[TIPO_DOC],[REFER], ")
                query_minve_entrada.Append("    [CANT],[CANT_COST],[PRECIO],[COSTO], ")
                query_minve_entrada.Append("    [REG_SERIE],[UNI_VENTA],[E_LTPD],[EXIST_G],[EXISTENCIA],[TIPO_PROD],[FACTOR_CON], ")
                query_minve_entrada.Append("    [FECHAELAB],[CVE_FOLIO],[SIGNO],[COSTEADO],[COSTO_PROM_INI], ")
                query_minve_entrada.Append("    [COSTO_PROM_FIN],[COSTO_PROM_GRAL],[DESDE_INVE],[MOV_ENLAZADO]) ")
                query_minve_entrada.Append("VALUES ")
                query_minve_entrada.Append("   (@CVE_ART,@ALMACEN,(SELECT ULT_CVE+1 FROM [SAE60Empre02].[dbo].[TBLCONTROL02] WHERE (ID_TABLA = 44)), ")
                query_minve_entrada.Append("    @CVE_CPTO,@FECHA_DOCU,'M',@REFER,@CANT,0,0,@COSTO,0, ")
                query_minve_entrada.Append("    @UNI_VENTA,@E_LTPD, ((SELECT ISNULL(EXIST,0) FROM [SAE60Empre02].[dbo].[INVE02] WHERE CVE_ART = @CVE_ART)), ")
                query_minve_entrada.Append("    ((SELECT EXIST FROM [SAE60Empre02].[dbo].[MULT02] WHERE (CVE_ART = @CVE_ART) AND CVE_ALM = @ALMACEN)), 'P',1, ")
                query_minve_entrada.Append("    @FECHAELAB, (SELECT ULT_CVE+1 FROM [SAE60Empre02].[dbo].[TBLCONTROL02] WHERE (ID_TABLA = 32)), 1, 'S', @COSTO_PROM_INI, ")
                query_minve_entrada.Append("    @COSTO_PROM_FIN, @COSTO_PROM_GRAL, 'S', (SELECT ULT_CVE FROM [SAE60Empre02].[dbo].[TBLCONTROL02] WHERE (ID_TABLA = 44))) ")
                Dim comando_minve_entrada As New SqlCommand(query_minve_entrada.ToString, ActualizarConexion)
                comando_minve_entrada.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(5))
                comando_minve_entrada.Parameters.AddWithValue("@ALMACEN", Almacen)
                comando_minve_entrada.Parameters.AddWithValue("@CVE_CPTO", 11)
                comando_minve_entrada.Parameters.AddWithValue("@FECHA_DOCU", Today.Date)
                comando_minve_entrada.Parameters.AddWithValue("@REFER", "EP" & Today.Day.ToString & Today.Month.ToString & Today.Year.ToString & "-" & UltimaClave + 1)

                comando_minve_entrada.Parameters.AddWithValue("@CANT", dt.Rows(index).Item(6))
                comando_minve_entrada.Parameters.AddWithValue("@COSTO", 0)
                comando_minve_entrada.Parameters.AddWithValue("@UNI_VENTA", dt_datos_inve.Rows(0)(1))
                comando_minve_entrada.Parameters.AddWithValue("@E_LTPD", correlativo_lotes_ENTRADA)
                comando_minve_entrada.Parameters.AddWithValue("@FECHAELAB", Today.Date)
                comando_minve_entrada.Parameters.AddWithValue("@COSTO_PROM_INI", 0)
                comando_minve_entrada.Parameters.AddWithValue("@COSTO_PROM_FIN", 0)
                comando_minve_entrada.Parameters.AddWithValue("@COSTO_PROM_GRAL", 0)
                comando_minve_entrada.Transaction = transaccion_sql
                comando_minve_entrada.ExecuteNonQuery()

                'update num mov minve
                Dim query_control_num_mov_entrada As New StringBuilder
                query_control_num_mov_entrada.Append("UPDATE [SAE60Empre02].[dbo].[TBLCONTROL02] ")
                query_control_num_mov_entrada.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                query_control_num_mov_entrada.Append("WHERE [ID_TABLA] = 44 ")
                Dim comando_control_num_mov_entrada As New SqlCommand(query_control_num_mov_entrada.ToString, ActualizarConexion)
                comando_control_num_mov_entrada.Transaction = transaccion_sql
                comando_control_num_mov_entrada.ExecuteNonQuery()
            Next
            'FIN DE MOVIMIENTOS DEL SAE

            'update cve_folio minve
            Dim query_control_folio As New StringBuilder
            query_control_folio.Append("UPDATE [SAE60Empre02].[dbo].[TBLCONTROL02] ")
            query_control_folio.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
            query_control_folio.Append("WHERE ([ID_TABLA] = 32) ")
            Dim comando_control_folio As New SqlCommand(query_control_folio.ToString, ActualizarConexion)
            comando_control_folio.Transaction = transaccion_sql
            comando_control_folio.ExecuteNonQuery()

            Dim conexion_bita As New cls_bitacora_reporteador
            conexion_bita.RegistraBitacora(Now, usuario, "Realizó Traslado de Producto a Promoción en SR AGRO", "ALMACEN", _
                                      "Fecha: " & DateTime.Now & " Cantidad de Productos: " & dt.Rows.Count & " Almacén:" & Almacen)

            transaccion_sql.Commit()
            ActualizarConexion.Close()
            Return "correcto"

        Catch ex As Exception
            Dim tamaño As Integer = Convert.ToString(ex.StackTrace).Length
            Dim posicion As Integer = InStrRev(Convert.ToString(ex.StackTrace), "línea") - 1
            Dim inicial As Integer = tamaño - posicion
            Dim linea_error As String = Convert.ToString(ex.StackTrace).Substring(tamaño - inicial, inicial)
            transaccion_sql.Rollback()
            ActualizarConexion.Close()
            Return ex.Message & " " & linea_error
        End Try
    End Function

    Public Function GuardarPromocionesDIMOSA(ByVal dt As DataTable, ByVal usuario As String, ByVal Empresa As String, ByVal Almacen As Integer)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim transaccion_sql As SqlTransaction
        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand

            For index As Integer = 0 To dt.Rows.Count - 1

                Dim UltimaClave As Integer = 0
                Dim dt_CVE As New DataTable
                Dim query_CVE As New StringBuilder
                query_CVE.Append("SELECT MAX([Usuarios].[dbo].[PROMO_MOVIMIENTOS].[PROM_ID]) FROM [Usuarios].[dbo].[PROMO_MOVIMIENTOS] ")

                Dim cmd_select_CVE As New SqlCommand(query_CVE.ToString, ActualizarConexion)
                Dim adaptador_CVE As New SqlDataAdapter(cmd_select_CVE)
                cmd_select_CVE.Transaction = transaccion_sql
                adaptador_CVE.Fill(dt_CVE)
                If Not IsDBNull(dt_CVE.Rows(0)(0)) Then
                    UltimaClave = dt_CVE.Rows(0)(0)
                End If

                miComando = New SqlCommand("INSERT INTO [Usuarios].[dbo].[PROMO_MOVIMIENTOS] " & _
                                             "([PROM_ID], [PROM_DETALLE], [PROM_FECHA], [CVE_PRODUCTO], [PRODUCTO_UNIDAD], [PRODUCTO_CANTIDAD], [CVE_PROM], [PROM_UNIDAD], [PROM_CANTIDAD], [CONCEPTO_PROV] ,[EMPRESA], [ALMACEN]) " & _
                                             "VALUES(@PROM_ID, @PROM_DETALLE, @PROM_FECHA, @CVE_PRODUCTO, @PRODUCTO_UNIDAD, @PRODUCTO_CANTIDAD, @CVE_PROM, @PROM_UNIDAD, @PROM_CANTIDAD, @CONCEPTO_PROV, @EMPRESA, @ALMACEN) ", ActualizarConexion)
                miComando.Parameters.AddWithValue("@PROM_ID", UltimaClave + 1)
                miComando.Parameters.AddWithValue("@PROM_DETALLE", dt.Rows(index).Item(0))
                miComando.Parameters.AddWithValue("@PROM_FECHA", DateTime.Now)
                miComando.Parameters.AddWithValue("@CVE_PRODUCTO", dt.Rows(index).Item(1))
                miComando.Parameters.AddWithValue("@PRODUCTO_UNIDAD", dt.Rows(index).Item(3))
                miComando.Parameters.AddWithValue("@PRODUCTO_CANTIDAD", dt.Rows(index).Item(2))
                miComando.Parameters.AddWithValue("@CVE_PROM", dt.Rows(index).Item(5))
                miComando.Parameters.AddWithValue("@PROM_UNIDAD", dt.Rows(index).Item(7))
                miComando.Parameters.AddWithValue("@PROM_CANTIDAD", dt.Rows(index).Item(6))
                miComando.Parameters.AddWithValue("@CONCEPTO_PROV", dt.Rows(index).Item(9))
                miComando.Parameters.AddWithValue("@EMPRESA", Empresa)
                miComando.Parameters.AddWithValue("@ALMACEN", Almacen)
                miComando.Transaction = transaccion_sql
                miComando.ExecuteNonQuery()

                ' registrar las salidas
                'update MULT
                Dim query_mult_salida As New StringBuilder
                query_mult_salida.Append("UPDATE [SAE60Empre06].[dbo].[MULT06] ")
                query_mult_salida.Append("SET [EXIST] = ISNULL(EXIST,0) - @CANTIDAD ")
                query_mult_salida.Append("WHERE [CVE_ART] = @CVE_ART AND [CVE_ALM] = @CVE_ALM ")
                Dim comando_mult_salida As New SqlCommand(query_mult_salida.ToString, ActualizarConexion)
                comando_mult_salida.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(1))
                comando_mult_salida.Parameters.AddWithValue("@CVE_ALM", Almacen)
                comando_mult_salida.Parameters.AddWithValue("@CANTIDAD", dt.Rows(index).Item(2))
                comando_mult_salida.Transaction = transaccion_sql
                comando_mult_salida.ExecuteNonQuery()

                'update INVE
                Dim query_inve As New StringBuilder
                query_inve.Append("UPDATE [SAE60Empre06].[dbo].[INVE06] ")
                query_inve.Append("SET [EXIST] = EXIST - @CANTIDAD ")
                query_inve.Append("WHERE [CVE_ART] = @CVE_ART ")
                Dim comando_inve_salida As New SqlCommand(query_inve.ToString, ActualizarConexion)
                comando_inve_salida.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(1))
                comando_inve_salida.Parameters.AddWithValue("@CANTIDAD", dt.Rows(index).Item(2))
                comando_inve_salida.Transaction = transaccion_sql
                comando_inve_salida.ExecuteNonQuery()

                'INICIO DE LOS LOTES

                Dim dt_lotes_crear As New DataTable
                dt_lotes_crear.Columns.Clear()
                dt_lotes_crear.Columns.Add("LOTE")
                dt_lotes_crear.Columns.Add("CANT")
                dt_lotes_crear.Columns.Add("PEDIMENTO")
                dt_lotes_crear.Columns.Add("FCHCADUC")
                dt_lotes_crear.Columns.Add("FCHADUANA")
                dt_lotes_crear.Columns.Add("NOM_ADUANA")
                dt_lotes_crear.Columns.Add("CVE_OBS")
                dt_lotes_crear.Columns.Add("CIUDAD")
                dt_lotes_crear.Columns.Add("FRONTERA")
                dt_lotes_crear.Columns.Add("FEC_PROD_LT")
                dt_lotes_crear.Columns.Add("GLN")
                Dim correlativo_lotes As Integer = 0
                dt_lotes_crear.Rows.Clear()
                If dt.Rows(index).Item(4) = "S" Then
                    Dim ds_lotes As New DataSet
                    Dim cantidad As Double = 0, can_insertar As Double = 0

                    Dim query As New StringBuilder
                    query.Append("SELECT LOTE, CVE_ALM, FCHCADUC, CANTIDAD, REG_LTPD,PEDIMENTO,FCHADUANA, ")
                    query.Append("NOM_ADUAN,CVE_OBS,CIUDAD,FRONTERA,FEC_PROD_LT, GLN ")
                    query.Append("FROM [SAE60Empre06].[dbo].[LTPD06] WHERE (STATUS = 'A') AND (CVE_ART = @CVE_ART) AND CVE_ALM = @CVE_ALM")
                    query.Append(" AND (CANTIDAD > 0) AND (FCHCADUC > GETDATE() OR FCHCADUC IS NULL OR FCHCADUC = '') ")
                    query.Append("ORDER BY FCHCADUC ")
                    Dim cmd_select_lotes As New SqlCommand(query.ToString, ActualizarConexion)
                    cmd_select_lotes.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(1))
                    cmd_select_lotes.Parameters.AddWithValue("@CVE_ALM", Almacen)
                    Dim adaptador As New SqlDataAdapter(cmd_select_lotes)
                    cmd_select_lotes.Transaction = transaccion_sql
                    adaptador.Fill(ds_lotes)
                    cantidad = Convert.ToDouble(dt.Rows(index).Item(2))

                    'for de los lotes
                    'MsgBox("Lotes de Salida " & ds_lotes.Tables(0).Rows.Count)
                    For index1 As Integer = 0 To ds_lotes.Tables(0).Rows.Count
                        correlativo_lotes = 0
                        'inicio de seleccinar el autonumerico de los enlace lotes
                        Dim ds_correlativo_lotes As New DataSet
                        Dim query_correlativo_lotes As New StringBuilder
                        query_correlativo_lotes.Append("SELECT (ULT_CVE + 1) AS ULT_CVE ")
                        query_correlativo_lotes.Append("FROM [SAE60Empre06].[dbo].[TBLCONTROL06] ")
                        query_correlativo_lotes.Append("WHERE (ID_TABLA = 67)")
                        Dim cmd_select_correlativo_enlace As New SqlCommand(query_correlativo_lotes.ToString, ActualizarConexion)
                        Dim adapenlace As New SqlDataAdapter(cmd_select_correlativo_enlace)
                        cmd_select_correlativo_enlace.Transaction = transaccion_sql
                        adapenlace.Fill(ds_correlativo_lotes)
                        'fin de seleccionar el autonumerico de los enlace lotes
                        correlativo_lotes = Convert.ToInt32(ds_correlativo_lotes.Tables(0).Rows(0)(0))

                        Dim NumeroLote As Integer = 0

                        If (ds_lotes.Tables(0).Rows.Count > 0) Then
                            NumeroLote = ds_lotes.Tables(0).Rows(index1)(3)
                        End If
                        'MsgBox("Numero Lote: " & NumeroLote & vbNewLine & " CANTIDAD: " & cantidad)
                        If NumeroLote >= cantidad Then
                            'MsgBox("NumeroLote > Cantidad")
                            'MsgBox("NumeroLote > Cantidad: Cantidad Insertar: " & cantidad)
                            can_insertar = cantidad
                            'hacer el enlace a los lotes
                            Dim query_enlace As New StringBuilder
                            query_enlace.Append("INSERT INTO [SAE60Empre06].[dbo].[ENLACE_LTPD06] ")
                            query_enlace.Append("(E_LTPD,REG_LTPD,CANTIDAD,PXRS) ")
                            query_enlace.Append("VALUES (@E_LTPD,@REG_LTPD,@CANTIDAD,@PXRS) ")
                            Dim cmd_enlace_ltp As New SqlCommand(query_enlace.ToString, ActualizarConexion)
                            cmd_enlace_ltp.Parameters.AddWithValue("@E_LTPD", correlativo_lotes)
                            cmd_enlace_ltp.Parameters.AddWithValue("@REG_LTPD", Convert.ToInt32(ds_lotes.Tables(0).Rows(index1)(4)))
                            cmd_enlace_ltp.Parameters.AddWithValue("@CANTIDAD", cantidad)
                            cmd_enlace_ltp.Parameters.AddWithValue("@PXRS", cantidad)
                            cmd_enlace_ltp.Transaction = transaccion_sql
                            cmd_enlace_ltp.ExecuteNonQuery()

                            Dim new_row As DataRow = dt_lotes_crear.NewRow
                            new_row(0) = Convert.ToString(ds_lotes.Tables(0).Rows(index1)(0))
                            new_row(1) = cantidad
                            new_row(2) = ds_lotes.Tables(0).Rows(index1)(5)
                            new_row(3) = ds_lotes.Tables(0).Rows(index1)(2)
                            new_row(4) = ds_lotes.Tables(0).Rows(index1)(6)
                            new_row(5) = ds_lotes.Tables(0).Rows(index1)(7)
                            new_row(6) = ds_lotes.Tables(0).Rows(index1)(8)
                            new_row(7) = ds_lotes.Tables(0).Rows(index1)(9)
                            new_row(8) = ds_lotes.Tables(0).Rows(index1)(10)
                            new_row(9) = ds_lotes.Tables(0).Rows(index1)(11)
                            new_row(10) = ds_lotes.Tables(0).Rows(index1)(12)

                            dt_lotes_crear.Rows.Add(new_row)

                            'MsgBox("fila recien agregada - lOTES a CREAR: " & dt_lotes_crear.Rows.Count & vbNewLine & new_row(0) & vbNewLine & new_row(10))
                            'actualizar las existencias de los lotes
                            Dim query_ltpd As New StringBuilder
                            query_ltpd.Append("UPDATE [SAE60Empre06].[dbo].[LTPD06] ")
                            query_ltpd.Append("SET [FCHULTMOV] = @FCHULTMOV, ")
                            query_ltpd.Append("[CANTIDAD] = (CANTIDAD - @NUEVA_CANTIDAD) ")
                            query_ltpd.Append("WHERE [CVE_ART] = @CVE_ART AND [LOTE] = @LOTE AND [CVE_ALM] = @CVE_ALM ")
                            Dim cmd_ltpd As New SqlCommand(query_ltpd.ToString, ActualizarConexion)
                            cmd_ltpd.Parameters.AddWithValue("@FCHULTMOV", Today.Date)
                            cmd_ltpd.Parameters.AddWithValue("@NUEVA_CANTIDAD", cantidad)
                            cmd_ltpd.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(1))
                            cmd_ltpd.Parameters.AddWithValue("@LOTE", Convert.ToString(ds_lotes.Tables(0).Rows(index1)(0)))
                            cmd_ltpd.Parameters.AddWithValue("@CVE_ALM", Almacen)
                            cmd_ltpd.Transaction = transaccion_sql
                            cmd_ltpd.ExecuteNonQuery()
                            index1 = ds_lotes.Tables(0).Rows.Count
                        Else
                            can_insertar = (Convert.ToDouble(NumeroLote) - Convert.ToDouble(dt.Rows(index).Item(2)) + Convert.ToDouble(dt.Rows(index).Item(2)))
                            'MsgBox("NumeroLote < Cantidad: Cantidad Insertar: " & can_insertar)

                            'hacer el enlace a los lotes
                            Dim query_enlace_ltpd_ins As New StringBuilder
                            query_enlace_ltpd_ins.Append("INSERT INTO [SAE60Empre06].[dbo].[ENLACE_LTPD06] ")
                            query_enlace_ltpd_ins.Append("(E_LTPD,REG_LTPD,CANTIDAD,PXRS) ")
                            query_enlace_ltpd_ins.Append("VALUES (@E_LTPD,@REG_LTPD,@CANTIDAD,@PXRS) ")
                            Dim cmd_enlace_ltpd_ins As New SqlCommand(query_enlace_ltpd_ins.ToString, ActualizarConexion)
                            cmd_enlace_ltpd_ins.Parameters.AddWithValue("@E_LTPD", correlativo_lotes)
                            cmd_enlace_ltpd_ins.Parameters.AddWithValue("@REG_LTPD", Convert.ToInt32(ds_lotes.Tables(0).Rows(index1)(4)))
                            cmd_enlace_ltpd_ins.Parameters.AddWithValue("@CANTIDAD", can_insertar)
                            cmd_enlace_ltpd_ins.Parameters.AddWithValue("@PXRS", can_insertar)
                            cmd_enlace_ltpd_ins.Transaction = transaccion_sql
                            cmd_enlace_ltpd_ins.ExecuteNonQuery()

                            Dim new_row As DataRow = dt_lotes_crear.NewRow
                            new_row(0) = Convert.ToString(ds_lotes.Tables(0).Rows(index1)(0))
                            new_row(1) = can_insertar
                            new_row(2) = ds_lotes.Tables(0).Rows(index1)(5)
                            new_row(3) = ds_lotes.Tables(0).Rows(index1)(2)
                            new_row(4) = ds_lotes.Tables(0).Rows(index1)(6)
                            new_row(5) = ds_lotes.Tables(0).Rows(index1)(7)
                            new_row(6) = ds_lotes.Tables(0).Rows(index1)(8)
                            new_row(7) = ds_lotes.Tables(0).Rows(index1)(9)
                            new_row(8) = ds_lotes.Tables(0).Rows(index1)(10)
                            new_row(9) = ds_lotes.Tables(0).Rows(index1)(11)
                            new_row(10) = ds_lotes.Tables(0).Rows(index1)(12)
                            dt_lotes_crear.Rows.Add(new_row)
                            'MsgBox("cREACION lOTES CREAR: " & dt_lotes_crear.Rows.Count)
                            Dim query_upd_ltpd As New StringBuilder
                            query_upd_ltpd.Append("UPDATE [SAE60Empre06].[dbo].[LTPD06] ")
                            query_upd_ltpd.Append("SET [FCHULTMOV] = @FCHULTMOV ")
                            query_upd_ltpd.Append(",[CANTIDAD] = (CANTIDAD - @NUEVA_CANTIDAD) ")
                            query_upd_ltpd.Append("WHERE [CVE_ART] = @CVE_ART AND [LOTE] = @LOTE AND [CVE_ALM] = @CVE_ALM ")
                            Dim cmd_ltpd_upd As New SqlCommand(query_upd_ltpd.ToString, ActualizarConexion)
                            cmd_ltpd_upd.Parameters.AddWithValue("@FCHULTMOV", Today.Date)
                            cmd_ltpd_upd.Parameters.AddWithValue("@NUEVA_CANTIDAD", can_insertar)
                            cmd_ltpd_upd.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(1))
                            cmd_ltpd_upd.Parameters.AddWithValue("@LOTE", Convert.ToString(ds_lotes.Tables(0).Rows(index1)(0)))
                            cmd_ltpd_upd.Parameters.AddWithValue("@CVE_ALM", Almacen)
                            cmd_ltpd_upd.Transaction = transaccion_sql
                            cmd_ltpd_upd.ExecuteNonQuery()
                            cantidad = cantidad - Convert.ToInt32(ds_lotes.Tables(0).Rows(index1)(3))
                            can_insertar = cantidad
                        End If
                    Next

                    'actualizar los correlativos de los lotes
                    Dim query_actualiza_lotes As New StringBuilder
                    query_actualiza_lotes.Append("UPDATE [SAE60Empre06].[dbo].[TBLCONTROL06] ")
                    query_actualiza_lotes.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                    query_actualiza_lotes.Append("WHERE (ID_TABLA = 67) ")
                    Dim cmd_upd_correlativo_lot As New SqlCommand(query_actualiza_lotes.ToString, ActualizarConexion)
                    cmd_upd_correlativo_lot.Transaction = transaccion_sql
                    cmd_upd_correlativo_lot.ExecuteNonQuery()

                End If
                'FIN DE LOS LOTES

                'select Datos INVE
                Dim query_datos_inve As New StringBuilder
                query_datos_inve.Append("SELECT ISNULL(COSTO_PROM,0), ISNULL(UNI_MED,''), ISNULL(FAC_CONV,1) ")
                query_datos_inve.Append("FROM [SAE60Empre06].[dbo].[INVE06] ")
                query_datos_inve.Append("WHERE CVE_ART = @CVE_ART")
                Dim comando_datos_inve As New SqlCommand(query_datos_inve.ToString, ActualizarConexion)
                comando_datos_inve.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(1))
                comando_datos_inve.Transaction = transaccion_sql
                Dim adaptador_datos_inve As New SqlDataAdapter(comando_datos_inve)
                Dim dt_datos_inve As New DataTable
                adaptador_datos_inve.Fill(dt_datos_inve)

                'insert MINVE
                Dim query_minve As New StringBuilder
                query_minve.Append("INSERT INTO [SAE60Empre06].[dbo].[MINVE06] ")
                query_minve.Append("   ([CVE_ART],[ALMACEN],[NUM_MOV],[CVE_CPTO],[FECHA_DOCU],[TIPO_DOC],[REFER], ")
                query_minve.Append("    [CANT],[CANT_COST],[PRECIO],[COSTO], ")
                query_minve.Append("    [REG_SERIE],[UNI_VENTA],[E_LTPD],[EXIST_G],[EXISTENCIA],[TIPO_PROD],[FACTOR_CON], ")
                query_minve.Append("    [FECHAELAB],[CVE_FOLIO],[SIGNO],[COSTEADO],[COSTO_PROM_INI], ")
                query_minve.Append("    [COSTO_PROM_FIN],[COSTO_PROM_GRAL],[DESDE_INVE],[MOV_ENLAZADO]) ")
                query_minve.Append("VALUES ")
                query_minve.Append("   (@CVE_ART,@ALMACEN,(SELECT ULT_CVE+1 FROM [SAE60Empre06].[dbo].[TBLCONTROL06] WHERE (ID_TABLA = 44)), ")
                query_minve.Append("    @CVE_CPTO,@FECHA_DOCU,'M',@REFER,@CANT,0,0,@COSTO,0, ")
                query_minve.Append("    @UNI_VENTA,@E_LTPD, ((SELECT ISNULL(EXIST,0) FROM [SAE60Empre06].[dbo].[INVE06] WHERE CVE_ART = @CVE_ART)), ")
                query_minve.Append("    ((SELECT EXIST FROM [SAE60Empre06].[dbo].[MULT06] WHERE (CVE_ART = @CVE_ART) AND CVE_ALM = @ALMACEN)), 'P',1, ")
                query_minve.Append("    @FECHAELAB, (SELECT ULT_CVE+1 FROM [SAE60Empre06].[dbo].[TBLCONTROL06] WHERE (ID_TABLA = 32)), -1, 'S', @COSTO_PROM_INI, ")
                query_minve.Append("    @COSTO_PROM_FIN, @COSTO_PROM_GRAL, 'S', 0) ")

                Dim comando_minve_salida As New SqlCommand(query_minve.ToString, ActualizarConexion)
                comando_minve_salida.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(1))
                comando_minve_salida.Parameters.AddWithValue("@ALMACEN", Almacen)
                comando_minve_salida.Parameters.AddWithValue("@CVE_CPTO", 63)
                comando_minve_salida.Parameters.AddWithValue("@FECHA_DOCU", Today.Date)
                comando_minve_salida.Parameters.AddWithValue("@REFER", "SP" & Today.Day.ToString & Today.Month.ToString & Today.Year.ToString & "-" & UltimaClave + 1)
                comando_minve_salida.Parameters.AddWithValue("@CANT", dt.Rows(index).Item(2))
                comando_minve_salida.Parameters.AddWithValue("@COSTO", dt_datos_inve.Rows(0)(0))
                comando_minve_salida.Parameters.AddWithValue("@UNI_VENTA", dt_datos_inve.Rows(0)(1))
                comando_minve_salida.Parameters.AddWithValue("@E_LTPD", correlativo_lotes)
                comando_minve_salida.Parameters.AddWithValue("@FECHAELAB", Today.Date)
                comando_minve_salida.Parameters.AddWithValue("@COSTO_PROM_INI", dt_datos_inve.Rows(0)(0))
                comando_minve_salida.Parameters.AddWithValue("@COSTO_PROM_FIN", dt_datos_inve.Rows(0)(0))
                comando_minve_salida.Parameters.AddWithValue("@COSTO_PROM_GRAL", dt_datos_inve.Rows(0)(0))
                comando_minve_salida.Transaction = transaccion_sql
                comando_minve_salida.ExecuteNonQuery()

                'update num mov minve
                Dim query_control_num_mov As New StringBuilder
                query_control_num_mov.Append("UPDATE [SAE60Empre06].[dbo].[TBLCONTROL06] ")
                query_control_num_mov.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                query_control_num_mov.Append("WHERE [ID_TABLA] = 44 ")
                Dim comando_control_num_mov As New SqlCommand(query_control_num_mov.ToString, ActualizarConexion)
                comando_control_num_mov.Transaction = transaccion_sql
                comando_control_num_mov.ExecuteNonQuery()

                'FIN DE REGISTRAR LAS SALIDAS

                'INICIO REGISTRAR LAS ENTRADAS
                'update MULT
                Dim query_mult_entrada As New StringBuilder
                query_mult_entrada.Append("UPDATE [SAE60Empre06].[dbo].[MULT06] ")
                query_mult_entrada.Append("SET [EXIST] = ISNULL(EXIST,0) + @CANTIDAD ")
                query_mult_entrada.Append("WHERE [CVE_ART] = @CVE_ART AND [CVE_ALM] = @CVE_ALM ")
                Dim comando_mult_entrada As New SqlCommand(query_mult_entrada.ToString, ActualizarConexion)
                comando_mult_entrada.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(5))
                comando_mult_entrada.Parameters.AddWithValue("@CVE_ALM", Almacen)
                comando_mult_entrada.Parameters.AddWithValue("@CANTIDAD", dt.Rows(index).Item(6))
                comando_mult_entrada.Transaction = transaccion_sql
                comando_mult_entrada.ExecuteNonQuery()

                'update INVE
                Dim query_inve_entrada As New StringBuilder
                query_inve_entrada.Append("UPDATE [SAE60Empre06].[dbo].[INVE06] ")
                query_inve_entrada.Append("SET [EXIST] = EXIST + @CANTIDAD ")
                query_inve_entrada.Append("WHERE [CVE_ART] = @CVE_ART ")
                Dim comando_inve_entrada As New SqlCommand(query_inve_entrada.ToString, ActualizarConexion)
                comando_inve_entrada.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(5))
                comando_inve_entrada.Parameters.AddWithValue("@CANTIDAD", dt.Rows(index).Item(6))
                comando_inve_entrada.Transaction = transaccion_sql
                comando_inve_entrada.ExecuteNonQuery()


                'INICIO DE LOS LOTES
                Dim correlativo_lotes_ENTRADA As Integer = 0
                If dt.Rows(index).Item(8) = "S" Then
                    'MsgBox("Lotes de Entrada " & dt_lotes_crear.Rows.Count - 1)
                    For index2 As Integer = 0 To dt_lotes_crear.Rows.Count - 1
                        correlativo_lotes_ENTRADA = 0
                        'inicio de seleccinar el autonumerico de los enlace lotes
                        Dim ds_correlativo_lotes As New DataSet
                        Dim query_correlativo_lotes As New StringBuilder
                        query_correlativo_lotes.Append("SELECT (ULT_CVE + 1) AS ULT_CVE ")
                        query_correlativo_lotes.Append("FROM [SAE60Empre06].[dbo].[TBLCONTROL06] ")
                        query_correlativo_lotes.Append("WHERE (ID_TABLA = 67)")
                        Dim cmd_select_correlativo_enlace As New SqlCommand(query_correlativo_lotes.ToString, ActualizarConexion)
                        Dim adapenlace As New SqlDataAdapter(cmd_select_correlativo_enlace)
                        cmd_select_correlativo_enlace.Transaction = transaccion_sql
                        adapenlace.Fill(ds_correlativo_lotes)
                        'fin de seleccionar el autonumerico de los enlace lotes
                        correlativo_lotes_ENTRADA = Convert.ToInt32(ds_correlativo_lotes.Tables(0).Rows(0)(0))

                        Dim query_valida_lote As New StringBuilder
                        query_valida_lote.Append("SELECT CVE_ART,LOTE,REG_LTPD ")
                        query_valida_lote.Append("FROM [SAE60Empre06].[dbo].[LTPD06] ")
                        query_valida_lote.Append("WHERE LOTE = @LOTE AND CVE_ALM = @ALMACEN AND CVE_ART = @CVE_ART ")
                        Dim cmd_valida_lote As New SqlCommand(query_valida_lote.ToString, ActualizarConexion)
                        cmd_valida_lote.Parameters.AddWithValue("@LOTE", dt_lotes_crear.Rows(index2)(0))
                        cmd_valida_lote.Parameters.AddWithValue("@ALMACEN", Almacen)
                        cmd_valida_lote.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(5))
                        cmd_valida_lote.Transaction = transaccion_sql
                        Dim adaptador_valida_lote As New SqlDataAdapter(cmd_valida_lote)
                        Dim dt_valida_lote As New DataTable
                        adaptador_valida_lote.Fill(dt_valida_lote)
                        If dt_valida_lote.Rows.Count > 0 Then
                            'si el lote existe
                            'hacer el enlace a los lotes

                            Dim X As Integer = 0
                            If dt.Rows(index).Item(6) <> dt.Rows(index).Item(2) Then
                                X = dt_lotes_crear.Rows(index2)(1) * dt_datos_inve.Rows(0)(2)
                            Else
                                X = dt_lotes_crear.Rows(index2)(1)
                            End If

                            Dim query_enlace_ltpd_ins_entrada As New StringBuilder
                            query_enlace_ltpd_ins_entrada.Append("INSERT INTO [SAE60Empre06].[dbo].[ENLACE_LTPD06] ")
                            query_enlace_ltpd_ins_entrada.Append("(E_LTPD,REG_LTPD,CANTIDAD,PXRS) ")
                            query_enlace_ltpd_ins_entrada.Append("VALUES (@E_LTPD,@REG_LTPD,@CANTIDAD,@PXRS) ")
                            Dim cmd_enlace_ltpd_ins_entrada As New SqlCommand(query_enlace_ltpd_ins_entrada.ToString, ActualizarConexion)
                            cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@E_LTPD", correlativo_lotes_ENTRADA)
                            cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@REG_LTPD", dt_valida_lote.Rows(0)(2))
                            cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@CANTIDAD", X)
                            cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@PXRS", X)
                            cmd_enlace_ltpd_ins_entrada.Transaction = transaccion_sql
                            cmd_enlace_ltpd_ins_entrada.ExecuteNonQuery()

                            Dim query_upd_ltpd As New StringBuilder
                            query_upd_ltpd.Append("UPDATE [SAE60Empre06].[dbo].[LTPD06] ")
                            query_upd_ltpd.Append("SET [FCHULTMOV] = @FCHULTMOV ")
                            query_upd_ltpd.Append(",[CANTIDAD] = (CANTIDAD + @NUEVA_CANTIDAD) ")
                            query_upd_ltpd.Append("WHERE [CVE_ART] = @CVE_ART AND [LOTE] = @LOTE AND [CVE_ALM] = @CVE_ALM ")
                            Dim cmd_ltpd_upd As New SqlCommand(query_upd_ltpd.ToString, ActualizarConexion)
                            cmd_ltpd_upd.Parameters.AddWithValue("@FCHULTMOV", Today.Date)

                            cmd_ltpd_upd.Parameters.AddWithValue("@NUEVA_CANTIDAD", X)
                            cmd_ltpd_upd.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(5))
                            cmd_ltpd_upd.Parameters.AddWithValue("@LOTE", dt_valida_lote.Rows(0)(1))
                            cmd_ltpd_upd.Parameters.AddWithValue("@CVE_ALM", Almacen)
                            cmd_ltpd_upd.Transaction = transaccion_sql
                            cmd_ltpd_upd.ExecuteNonQuery()
                        Else
                            'si el lote NO existe
                            Dim nuevo_reg_ltpd As Integer = 0
                            'inicio de seleccinar el autonumerico de los lotes
                            Dim ds_nuevo_reg_ltpd As New DataSet
                            Dim query_nuevo_reg_ltpd2 As New StringBuilder
                            query_nuevo_reg_ltpd2.Append("SELECT (ULT_CVE + 1) AS ULT_CVE ")
                            query_nuevo_reg_ltpd2.Append("FROM [SAE60Empre06].[dbo].[TBLCONTROL06] ")
                            query_nuevo_reg_ltpd2.Append("WHERE (ID_TABLA = 48)")
                            Dim cmd_select_nuevo_reg_ltpd2 As New SqlCommand(query_nuevo_reg_ltpd2.ToString, ActualizarConexion)
                            Dim adapnuevo_reg_ltpd As New SqlDataAdapter(cmd_select_nuevo_reg_ltpd2)
                            cmd_select_nuevo_reg_ltpd2.Transaction = transaccion_sql
                            adapnuevo_reg_ltpd.Fill(ds_nuevo_reg_ltpd)
                            'fin de seleccionar el autonumerico de los lotes
                            nuevo_reg_ltpd = Convert.ToInt32(ds_nuevo_reg_ltpd.Tables(0).Rows(0)(0))

                            'hacer el enlace a los lotes
                            Dim query_enlace_ltpd_ins_entrada As New StringBuilder
                            query_enlace_ltpd_ins_entrada.Append("INSERT INTO [SAE60Empre06].[dbo].[ENLACE_LTPD06] ")
                            query_enlace_ltpd_ins_entrada.Append("(E_LTPD,REG_LTPD,CANTIDAD,PXRS) ")
                            query_enlace_ltpd_ins_entrada.Append("VALUES (@E_LTPD,@REG_LTPD,@CANTIDAD,@PXRS) ")
                            Dim cmd_enlace_ltpd_ins_entrada As New SqlCommand(query_enlace_ltpd_ins_entrada.ToString, ActualizarConexion)
                            cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@E_LTPD", correlativo_lotes_ENTRADA)
                            cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@REG_LTPD", nuevo_reg_ltpd)

                            Dim X As Integer = 0
                            If dt.Rows(index).Item(6) <> dt.Rows(index).Item(2) Then
                                X = dt_lotes_crear.Rows(index2)(1) * dt_datos_inve.Rows(0)(2)
                            Else
                                X = dt_lotes_crear.Rows(index2)(1)
                            End If

                            cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@CANTIDAD", X)
                            cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@PXRS", X)
                            cmd_enlace_ltpd_ins_entrada.Transaction = transaccion_sql
                            cmd_enlace_ltpd_ins_entrada.ExecuteNonQuery()
                            'insertar nuevo lote
                            Dim query_insertar_nuevo_lote As New StringBuilder
                            query_insertar_nuevo_lote.Append("INSERT INTO [SAE60Empre06].[dbo].[LTPD06] ")
                            query_insertar_nuevo_lote.Append("([CVE_ART],[LOTE],[PEDIMENTO],[CVE_ALM],[FCHCADUC],[FCHADUANA] ")
                            query_insertar_nuevo_lote.Append(",[FCHULTMOV],[NOM_ADUAN],[CANTIDAD],[REG_LTPD],[CVE_OBS] ")
                            query_insertar_nuevo_lote.Append(",[CIUDAD],[FRONTERA],[FEC_PROD_LT],[GLN],[STATUS]) ")
                            query_insertar_nuevo_lote.Append("VALUES ")
                            query_insertar_nuevo_lote.Append("(@CVE_ART,@LOTE,@PEDIMENTO,@CVE_ALM,@FCHCADUC,@FCHADUANA ")
                            query_insertar_nuevo_lote.Append(",@FCHULTMOV,@NOM_ADUAN,@CANTIDAD,@REG_LTPD,@CVE_OBS,@CIUDAD ")
                            query_insertar_nuevo_lote.Append(",@FRONTERA,@FEC_PROD_LT,@GLN,@STATUS)")
                            Dim cmd_insertar_nuevo_lote As New SqlCommand(query_insertar_nuevo_lote.ToString, ActualizarConexion)
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(5))
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@LOTE", dt_lotes_crear.Rows(index2)(0))
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@PEDIMENTO", dt_lotes_crear.Rows(index2)(2))
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@CVE_ALM", Almacen)

                            If IsDBNull(dt_lotes_crear.Rows(index2)(3)) = True Then
                                cmd_insertar_nuevo_lote.Parameters.AddWithValue("@FCHCADUC", DBNull.Value)
                            Else
                                cmd_insertar_nuevo_lote.Parameters.AddWithValue("@FCHCADUC", Convert.ToDateTime(dt_lotes_crear.Rows(index2)(3)))
                            End If

                            If IsDBNull(dt_lotes_crear.Rows(index2)(4)) = True Then
                                cmd_insertar_nuevo_lote.Parameters.AddWithValue("@FCHADUANA", DBNull.Value)
                            Else
                                cmd_insertar_nuevo_lote.Parameters.AddWithValue("@FCHADUANA", Convert.ToDateTime(dt_lotes_crear.Rows(index2)(4)))
                            End If

                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@FCHULTMOV", Today.Date)
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@NOM_ADUAN", dt_lotes_crear.Rows(index2)(5))
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@CANTIDAD", X)
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@REG_LTPD", nuevo_reg_ltpd)
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@CVE_OBS", dt_lotes_crear.Rows(index2)(6))
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@CIUDAD", dt_lotes_crear.Rows(index2)(7))
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@FRONTERA", dt_lotes_crear.Rows(index2)(8))
                            If IsDBNull(dt_lotes_crear.Rows(index2)(9)) = True Then
                                cmd_insertar_nuevo_lote.Parameters.AddWithValue("@FEC_PROD_LT", DBNull.Value)
                            Else
                                cmd_insertar_nuevo_lote.Parameters.AddWithValue("@FEC_PROD_LT", Convert.ToDateTime(dt_lotes_crear.Rows(index2)(9)))
                            End If
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@GLN", dt_lotes_crear.Rows(index2)(10))
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@STATUS", "A")
                            cmd_insertar_nuevo_lote.Transaction = transaccion_sql
                            cmd_insertar_nuevo_lote.ExecuteNonQuery()

                            'actualizar el autonumerico de lotes
                            Dim query_actualiza_autonumerico_ltpd As New StringBuilder
                            query_actualiza_autonumerico_ltpd.Append("UPDATE [SAE60Empre06].[dbo].[TBLCONTROL06] ")
                            query_actualiza_autonumerico_ltpd.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                            query_actualiza_autonumerico_ltpd.Append("WHERE (ID_TABLA = 48) ")
                            Dim cmd_upd_autonumerico_ltpd As New SqlCommand(query_actualiza_autonumerico_ltpd.ToString, ActualizarConexion)
                            cmd_upd_autonumerico_ltpd.Transaction = transaccion_sql
                            cmd_upd_autonumerico_ltpd.ExecuteNonQuery()

                        End If
                    Next

                    'actualizar los correlativos de enlace de lotes
                    Dim query_actualiza_lotes As New StringBuilder
                    query_actualiza_lotes.Append("UPDATE [SAE60Empre06].[dbo].[TBLCONTROL06] ")
                    query_actualiza_lotes.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                    query_actualiza_lotes.Append("WHERE (ID_TABLA = 67) ")
                    Dim cmd_upd_correlativo_lot As New SqlCommand(query_actualiza_lotes.ToString, ActualizarConexion)
                    cmd_upd_correlativo_lot.Transaction = transaccion_sql
                    cmd_upd_correlativo_lot.ExecuteNonQuery()
                End If

                'insert MINVE
                Dim query_minve_entrada As New StringBuilder
                query_minve_entrada.Append("INSERT INTO [SAE60Empre06].[dbo].[MINVE06] ")
                query_minve_entrada.Append("   ([CVE_ART],[ALMACEN],[NUM_MOV],[CVE_CPTO],[FECHA_DOCU],[TIPO_DOC],[REFER], ")
                query_minve_entrada.Append("    [CANT],[CANT_COST],[PRECIO],[COSTO], ")
                query_minve_entrada.Append("    [REG_SERIE],[UNI_VENTA],[E_LTPD],[EXIST_G],[EXISTENCIA],[TIPO_PROD],[FACTOR_CON], ")
                query_minve_entrada.Append("    [FECHAELAB],[CVE_FOLIO],[SIGNO],[COSTEADO],[COSTO_PROM_INI], ")
                query_minve_entrada.Append("    [COSTO_PROM_FIN],[COSTO_PROM_GRAL],[DESDE_INVE],[MOV_ENLAZADO]) ")
                query_minve_entrada.Append("VALUES ")
                query_minve_entrada.Append("   (@CVE_ART,@ALMACEN,(SELECT ULT_CVE+1 FROM [SAE60Empre06].[dbo].[TBLCONTROL06] WHERE (ID_TABLA = 44)), ")
                query_minve_entrada.Append("    @CVE_CPTO,@FECHA_DOCU,'M',@REFER,@CANT,0,0,@COSTO,0, ")
                query_minve_entrada.Append("    @UNI_VENTA,@E_LTPD, ((SELECT ISNULL(EXIST,0) FROM [SAE60Empre06].[dbo].[INVE06] WHERE CVE_ART = @CVE_ART)), ")
                query_minve_entrada.Append("    ((SELECT EXIST FROM [SAE60Empre06].[dbo].[MULT06] WHERE (CVE_ART = @CVE_ART) AND CVE_ALM = @ALMACEN)), 'P',1, ")
                query_minve_entrada.Append("    @FECHAELAB, (SELECT ULT_CVE+1 FROM [SAE60Empre06].[dbo].[TBLCONTROL06] WHERE (ID_TABLA = 32)), 1, 'S', @COSTO_PROM_INI, ")
                query_minve_entrada.Append("    @COSTO_PROM_FIN, @COSTO_PROM_GRAL, 'S', (SELECT ULT_CVE FROM [SAE60Empre06].[dbo].[TBLCONTROL06] WHERE (ID_TABLA = 44))) ")
                Dim comando_minve_entrada As New SqlCommand(query_minve_entrada.ToString, ActualizarConexion)
                comando_minve_entrada.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(5))
                comando_minve_entrada.Parameters.AddWithValue("@ALMACEN", Almacen)
                comando_minve_entrada.Parameters.AddWithValue("@CVE_CPTO", 11)
                comando_minve_entrada.Parameters.AddWithValue("@FECHA_DOCU", Today.Date)
                comando_minve_entrada.Parameters.AddWithValue("@REFER", "EP" & Today.Day.ToString & Today.Month.ToString & Today.Year.ToString & "-" & UltimaClave + 1)

                comando_minve_entrada.Parameters.AddWithValue("@CANT", dt.Rows(index).Item(6))
                comando_minve_entrada.Parameters.AddWithValue("@COSTO", 0)
                comando_minve_entrada.Parameters.AddWithValue("@UNI_VENTA", dt_datos_inve.Rows(0)(1))
                comando_minve_entrada.Parameters.AddWithValue("@E_LTPD", correlativo_lotes_ENTRADA)
                comando_minve_entrada.Parameters.AddWithValue("@FECHAELAB", Today.Date)
                comando_minve_entrada.Parameters.AddWithValue("@COSTO_PROM_INI", 0)
                comando_minve_entrada.Parameters.AddWithValue("@COSTO_PROM_FIN", 0)
                comando_minve_entrada.Parameters.AddWithValue("@COSTO_PROM_GRAL", 0)
                comando_minve_entrada.Transaction = transaccion_sql
                comando_minve_entrada.ExecuteNonQuery()

                'update num mov minve
                Dim query_control_num_mov_entrada As New StringBuilder
                query_control_num_mov_entrada.Append("UPDATE [SAE60Empre06].[dbo].[TBLCONTROL06] ")
                query_control_num_mov_entrada.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                query_control_num_mov_entrada.Append("WHERE [ID_TABLA] = 44 ")
                Dim comando_control_num_mov_entrada As New SqlCommand(query_control_num_mov_entrada.ToString, ActualizarConexion)
                comando_control_num_mov_entrada.Transaction = transaccion_sql
                comando_control_num_mov_entrada.ExecuteNonQuery()

                Try
                    Dim ExistenciaLotes As Integer = 0
                    Dim query_datos As New StringBuilder
                    query_datos.Append("SELECT     dbo.LTPD06.CVE_ART, ISNULL(SUM(dbo.LTPD06.CANTIDAD),0) AS 'EXISTENCIA_LOTE' ")
                    query_datos.Append("FROM dbo.LTPD06 INNER JOIN dbo.INVE06 ON dbo.LTPD06.CVE_ART = dbo.INVE06.CVE_ART   ")
                    query_datos.Append("WHERE   (dbo.LTPD06.CVE_ART = @CODIGO) AND LTPD06.CVE_ALM = @ALMACEN  AND ")
                    query_datos.Append("(dbo.LTPD06.STATUS = 'A') AND dbo.LTPD06.CANTIDAD > 0 AND (dbo.INVE06.CON_LOTE = 'S') GROUP BY dbo.LTPD06.CVE_ART")
                    Dim comando_datos As New SqlCommand(query_datos.ToString, ActualizarConexion)
                    comando_datos.Parameters.AddWithValue("@CODIGO", dt.Rows(index).Item(5))
                    comando_datos.Parameters.AddWithValue("@ALMACEN", Almacen)
                    comando_datos.Transaction = transaccion_sql
                    Dim adaptador_datos As New SqlDataAdapter(comando_datos)
                    Dim dt_datos_Lote As New DataTable
                    adaptador_datos.Fill(dt_datos_Lote)


                    Dim ExistenciaTotal As Integer = 0
                    Dim query_datos2 As New StringBuilder
                    query_datos2.Append("SELECT      dbo.MULT06.EXIST AS EXISTENCIA ")
                    query_datos2.Append("FROM dbo.MULT06 WHERE CVE_ART = @Producto AND CVE_ALM = @ALMACEN ")
                    Dim comando_datos2 As New SqlCommand(query_datos2.ToString, ActualizarConexion)
                    comando_datos2.Parameters.AddWithValue("@CODIGO", dt.Rows(index).Item(5))
                    comando_datos2.Parameters.AddWithValue("@ALMACEN", Almacen)
                    comando_datos2.Transaction = transaccion_sql
                    Dim adaptador_datos2 As New SqlDataAdapter(comando_datos2)
                    Dim dt_datos_Existencia As New DataTable
                    adaptador_datos.Fill(dt_datos_Existencia)

                    If ExistenciaLotes < ExistenciaTotal Then
                        '
                        Dim Diferencia As Integer = 0
                        Diferencia = ExistenciaTotal - ExistenciaLotes

                        'si el lote NO existe
                        Dim nuevo_reg_ltpd As Integer = 0
                        'inicio de seleccinar el autonumerico de los lotes
                        Dim ds_nuevo_reg_ltpd As New DataSet
                        Dim query_nuevo_reg_ltpd2 As New StringBuilder
                        query_nuevo_reg_ltpd2.Append("SELECT (ULT_CVE + 1) AS ULT_CVE ")
                        query_nuevo_reg_ltpd2.Append("FROM [SAE60Empre06].[dbo].[TBLCONTROL06] ")
                        query_nuevo_reg_ltpd2.Append("WHERE (ID_TABLA = 48)")
                        Dim cmd_select_nuevo_reg_ltpd2 As New SqlCommand(query_nuevo_reg_ltpd2.ToString, ActualizarConexion)
                        Dim adapnuevo_reg_ltpd As New SqlDataAdapter(cmd_select_nuevo_reg_ltpd2)
                        cmd_select_nuevo_reg_ltpd2.Transaction = transaccion_sql
                        adapnuevo_reg_ltpd.Fill(ds_nuevo_reg_ltpd)
                        'fin de seleccionar el autonumerico de los lotes
                        nuevo_reg_ltpd = Convert.ToInt32(ds_nuevo_reg_ltpd.Tables(0).Rows(0)(0))

                        'hacer el enlace a los lotes
                        Dim query_enlace_ltpd_ins_entrada As New StringBuilder
                        query_enlace_ltpd_ins_entrada.Append("INSERT INTO [SAE60Empre06].[dbo].[ENLACE_LTPD06] ")
                        query_enlace_ltpd_ins_entrada.Append("(E_LTPD,REG_LTPD,CANTIDAD,PXRS) ")
                        query_enlace_ltpd_ins_entrada.Append("VALUES (@E_LTPD,@REG_LTPD,@CANTIDAD,@PXRS) ")
                        Dim cmd_enlace_ltpd_ins_entrada As New SqlCommand(query_enlace_ltpd_ins_entrada.ToString, ActualizarConexion)
                        cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@E_LTPD", correlativo_lotes_ENTRADA)
                        cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@REG_LTPD", nuevo_reg_ltpd)
                        cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@CANTIDAD", Diferencia)
                        cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@PXRS", Diferencia)
                        cmd_enlace_ltpd_ins_entrada.Transaction = transaccion_sql
                        cmd_enlace_ltpd_ins_entrada.ExecuteNonQuery()
                        'insertar nuevo lote
                        Dim Pre As String = ""
                        If Almacen = 1 Then
                            Pre = "SPS"
                        ElseIf Almacen = 2 Then
                            Pre = "SRC"
                        ElseIf Almacen = 3 Then
                            Pre = "SB"
                        Else
                            Pre = "TG"
                        End If
                        Dim query_insertar_nuevo_lote As New StringBuilder
                        query_insertar_nuevo_lote.Append("INSERT INTO [SAE60Empre06].[dbo].[LTPD06] ")
                        query_insertar_nuevo_lote.Append("([CVE_ART],[LOTE],[PEDIMENTO],[CVE_ALM],[FCHCADUC],[FCHADUANA] ")
                        query_insertar_nuevo_lote.Append(",[FCHULTMOV],[NOM_ADUAN],[CANTIDAD],[REG_LTPD],[CVE_OBS] ")
                        query_insertar_nuevo_lote.Append(",[CIUDAD],[FRONTERA],[FEC_PROD_LT],[GLN],[STATUS]) ")
                        query_insertar_nuevo_lote.Append("VALUES ")
                        query_insertar_nuevo_lote.Append("(@CVE_ART,@LOTE,@PEDIMENTO,@CVE_ALM,@FCHCADUC,@FCHADUANA ")
                        query_insertar_nuevo_lote.Append(",@FCHULTMOV,@NOM_ADUAN,@CANTIDAD,@REG_LTPD,@CVE_OBS,@CIUDAD ")
                        query_insertar_nuevo_lote.Append(",@FRONTERA,@FEC_PROD_LT,@GLN,@STATUS)")
                        Dim cmd_insertar_nuevo_lote As New SqlCommand(query_insertar_nuevo_lote.ToString, ActualizarConexion)
                        cmd_insertar_nuevo_lote.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(5))
                        cmd_insertar_nuevo_lote.Parameters.AddWithValue("@LOTE", Pre & Today.Date.Year.ToString & Today.Date.Month.ToString & Today.Date.Date.ToString)
                        cmd_insertar_nuevo_lote.Parameters.AddWithValue("@PEDIMENTO", "")
                        cmd_insertar_nuevo_lote.Parameters.AddWithValue("@CVE_ALM", Almacen)
                        cmd_insertar_nuevo_lote.Parameters.AddWithValue("@FCHCADUC", DBNull.Value)
                        cmd_insertar_nuevo_lote.Parameters.AddWithValue("@FCHADUANA", DBNull.Value)

                        cmd_insertar_nuevo_lote.Parameters.AddWithValue("@FCHULTMOV", Today.Date)
                        cmd_insertar_nuevo_lote.Parameters.AddWithValue("@NOM_ADUAN", "")
                        cmd_insertar_nuevo_lote.Parameters.AddWithValue("@CANTIDAD", Diferencia)
                        cmd_insertar_nuevo_lote.Parameters.AddWithValue("@REG_LTPD", nuevo_reg_ltpd)
                        cmd_insertar_nuevo_lote.Parameters.AddWithValue("@CVE_OBS", 0)
                        cmd_insertar_nuevo_lote.Parameters.AddWithValue("@CIUDAD", "")
                        cmd_insertar_nuevo_lote.Parameters.AddWithValue("@FRONTERA", "")

                        cmd_insertar_nuevo_lote.Parameters.AddWithValue("@FEC_PROD_LT", DBNull.Value)

                        cmd_insertar_nuevo_lote.Parameters.AddWithValue("@GLN", "")
                        cmd_insertar_nuevo_lote.Parameters.AddWithValue("@STATUS", "A")
                        cmd_insertar_nuevo_lote.Transaction = transaccion_sql
                        cmd_insertar_nuevo_lote.ExecuteNonQuery()

                        'actualizar el autonumerico de lotes
                        Dim query_actualiza_autonumerico_ltpd As New StringBuilder
                        query_actualiza_autonumerico_ltpd.Append("UPDATE [SAE60Empre06].[dbo].[TBLCONTROL06] ")
                        query_actualiza_autonumerico_ltpd.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                        query_actualiza_autonumerico_ltpd.Append("WHERE (ID_TABLA = 48) ")
                        Dim cmd_upd_autonumerico_ltpd As New SqlCommand(query_actualiza_autonumerico_ltpd.ToString, ActualizarConexion)
                        cmd_upd_autonumerico_ltpd.Transaction = transaccion_sql
                        cmd_upd_autonumerico_ltpd.ExecuteNonQuery()
                        '
                    End If

                Catch ex As Exception
                    Dim tamaño2 As Integer = Convert.ToString(ex.StackTrace).Length
                    Dim posicion2 As Integer = InStrRev(Convert.ToString(ex.StackTrace), "línea") - 1
                    Dim inicial2 As Integer = tamaño2 - posicion2
                    Dim linea_error2 As String = Convert.ToString(ex.StackTrace).Substring(tamaño2 - inicial2, inicial2)
                    MsgBox("No se pudieron cuadrar los lotes de la promoción. " & ex.Message.ToString & " Error: " & linea_error2)
                End Try

            Next
            'FIN DE MOVIMIENTOS DEL SAE

            'update cve_folio minve
            Dim query_control_folio As New StringBuilder
            query_control_folio.Append("UPDATE [SAE60Empre06].[dbo].[TBLCONTROL06] ")
            query_control_folio.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
            query_control_folio.Append("WHERE ([ID_TABLA] = 32) ")
            Dim comando_control_folio As New SqlCommand(query_control_folio.ToString, ActualizarConexion)
            comando_control_folio.Transaction = transaccion_sql
            comando_control_folio.ExecuteNonQuery()

            Dim conexion_bita As New cls_bitacora_reporteador
            conexion_bita.RegistraBitacora(Now, usuario, "Realizó Traslado de Producto a Promoción DIMOSA", "ALMACEN", _
                                      "Fecha: " & DateTime.Now & " Cantidad de Productos: " & dt.Rows.Count & " Almacén:" & Almacen)



            transaccion_sql.Commit()
            ActualizarConexion.Close()
            Return "correcto"

        Catch ex As Exception
            Dim tamaño As Integer = Convert.ToString(ex.StackTrace).Length
            Dim posicion As Integer = InStrRev(Convert.ToString(ex.StackTrace), "línea") - 1
            Dim inicial As Integer = tamaño - posicion
            Dim linea_error As String = Convert.ToString(ex.StackTrace).Substring(tamaño - inicial, inicial)
            transaccion_sql.Rollback()
            ActualizarConexion.Close()
            Return ex.Message & " " & linea_error
        End Try
    End Function

    'Nuevas

    Public Function GuardarPromocionesAProducto(ByVal dt As DataTable, ByVal usuario As String, ByVal Empresa As String, ByVal Almacen As Integer)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim transaccion_sql As SqlTransaction
        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand

            For index As Integer = 0 To dt.Rows.Count - 1

                Dim UltimaClave As Integer = 0
                Dim dt_CVE As New DataTable
                Dim query_CVE As New StringBuilder
                query_CVE.Append("SELECT MAX([Usuarios].[dbo].[PROMO_MOVIMIENTOS].[PROM_ID]) FROM [Usuarios].[dbo].[PROMO_MOVIMIENTOS] ")

                Dim cmd_select_CVE As New SqlCommand(query_CVE.ToString, ActualizarConexion)
                Dim adaptador_CVE As New SqlDataAdapter(cmd_select_CVE)
                cmd_select_CVE.Transaction = transaccion_sql
                adaptador_CVE.Fill(dt_CVE)
                If Not IsDBNull(dt_CVE.Rows(0)(0)) Then
                    UltimaClave = dt_CVE.Rows(0)(0)
                End If

                miComando = New SqlCommand("INSERT INTO [Usuarios].[dbo].[PROMO_MOVIMIENTOS] " & _
                                             "([PROM_ID], [PROM_DETALLE], [PROM_FECHA], [CVE_PRODUCTO], [PRODUCTO_UNIDAD], [PRODUCTO_CANTIDAD], [CVE_PROM], [PROM_UNIDAD], [PROM_CANTIDAD], [CONCEPTO_PROV] ,[EMPRESA], [ALMACEN]) " & _
                                             "VALUES(@PROM_ID, @PROM_DETALLE, @PROM_FECHA, @CVE_PRODUCTO, @PRODUCTO_UNIDAD, @PRODUCTO_CANTIDAD, @CVE_PROM, @PROM_UNIDAD, @PROM_CANTIDAD, @CONCEPTO_PROV, @EMPRESA, @ALMACEN) ", ActualizarConexion)
                miComando.Parameters.AddWithValue("@PROM_ID", UltimaClave + 1)
                miComando.Parameters.AddWithValue("@PROM_DETALLE", dt.Rows(index).Item(0))
                miComando.Parameters.AddWithValue("@PROM_FECHA", Today.Date)
                miComando.Parameters.AddWithValue("@CVE_PRODUCTO", dt.Rows(index).Item(1))
                miComando.Parameters.AddWithValue("@PRODUCTO_UNIDAD", dt.Rows(index).Item(3))
                miComando.Parameters.AddWithValue("@PRODUCTO_CANTIDAD", dt.Rows(index).Item(2))
                miComando.Parameters.AddWithValue("@CVE_PROM", dt.Rows(index).Item(5))
                miComando.Parameters.AddWithValue("@PROM_UNIDAD", dt.Rows(index).Item(7))
                miComando.Parameters.AddWithValue("@PROM_CANTIDAD", dt.Rows(index).Item(6))
                miComando.Parameters.AddWithValue("@CONCEPTO_PROV", dt.Rows(index).Item(9))
                miComando.Parameters.AddWithValue("@EMPRESA", Empresa)
                miComando.Parameters.AddWithValue("@ALMACEN", Almacen)
                miComando.Transaction = transaccion_sql
                miComando.ExecuteNonQuery()

                ' registrar las salidas
                'update MULT
                Dim query_mult_salida As New StringBuilder
                query_mult_salida.Append("UPDATE [SAE60Empre05].[dbo].[MULT05] ")
                query_mult_salida.Append("SET [EXIST] = ISNULL(EXIST,0) - @CANTIDAD ")
                query_mult_salida.Append("WHERE [CVE_ART] = @CVE_ART AND [CVE_ALM] = @CVE_ALM ")
                Dim comando_mult_salida As New SqlCommand(query_mult_salida.ToString, ActualizarConexion)
                comando_mult_salida.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(1))
                comando_mult_salida.Parameters.AddWithValue("@CVE_ALM", Almacen)
                comando_mult_salida.Parameters.AddWithValue("@CANTIDAD", dt.Rows(index).Item(2))
                comando_mult_salida.Transaction = transaccion_sql
                comando_mult_salida.ExecuteNonQuery()

                'update INVE
                Dim query_inve As New StringBuilder
                query_inve.Append("UPDATE [SAE60Empre05].[dbo].[INVE05] ")
                query_inve.Append("SET [EXIST] = EXIST - @CANTIDAD ")
                query_inve.Append("WHERE [CVE_ART] = @CVE_ART ")
                Dim comando_inve_salida As New SqlCommand(query_inve.ToString, ActualizarConexion)
                comando_inve_salida.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(1))
                comando_inve_salida.Parameters.AddWithValue("@CANTIDAD", dt.Rows(index).Item(2))
                comando_inve_salida.Transaction = transaccion_sql
                comando_inve_salida.ExecuteNonQuery()

                'INICIO DE LOS LOTES

                Dim dt_lotes_crear As New DataTable
                dt_lotes_crear.Columns.Clear()
                dt_lotes_crear.Columns.Add("LOTE")
                dt_lotes_crear.Columns.Add("CANT")
                dt_lotes_crear.Columns.Add("PEDIMENTO")
                dt_lotes_crear.Columns.Add("FCHCADUC")
                dt_lotes_crear.Columns.Add("FCHADUANA")
                dt_lotes_crear.Columns.Add("NOM_ADUANA")
                dt_lotes_crear.Columns.Add("CVE_OBS")
                dt_lotes_crear.Columns.Add("CIUDAD")
                dt_lotes_crear.Columns.Add("FRONTERA")
                dt_lotes_crear.Columns.Add("FEC_PROD_LT")
                dt_lotes_crear.Columns.Add("GLN")
                Dim correlativo_lotes As Integer = 0
                dt_lotes_crear.Rows.Clear()
                If dt.Rows(index).Item(4) = "S" Then
                    Dim ds_lotes As New DataSet
                    Dim cantidad As Double = 0, can_insertar As Double = 0

                    Dim query As New StringBuilder
                    query.Append("SELECT LOTE, CVE_ALM, FCHCADUC, CANTIDAD, REG_LTPD,PEDIMENTO,FCHADUANA, ")
                    query.Append("NOM_ADUAN,CVE_OBS,CIUDAD,FRONTERA,FEC_PROD_LT, GLN ")
                    query.Append("FROM [SAE60Empre05].[dbo].[LTPD05] WHERE (STATUS = 'A') AND (CVE_ART = @CVE_ART) AND CVE_ALM = @CVE_ALM")
                    query.Append(" AND (CANTIDAD > 0) AND (FCHCADUC > GETDATE() OR FCHCADUC IS NULL OR FCHCADUC = '') ")
                    query.Append("ORDER BY FCHCADUC ")
                    Dim cmd_select_lotes As New SqlCommand(query.ToString, ActualizarConexion)
                    cmd_select_lotes.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(1))
                    cmd_select_lotes.Parameters.AddWithValue("@CVE_ALM", Almacen)
                    Dim adaptador As New SqlDataAdapter(cmd_select_lotes)
                    cmd_select_lotes.Transaction = transaccion_sql
                    adaptador.Fill(ds_lotes)
                    cantidad = Convert.ToDouble(dt.Rows(index).Item(2))

                    'for de los lotes
                    For index1 As Integer = 0 To ds_lotes.Tables(0).Rows.Count
                        correlativo_lotes = 0
                        'inicio de seleccinar el autonumerico de los enlace lotes
                        Dim ds_correlativo_lotes As New DataSet
                        Dim query_correlativo_lotes As New StringBuilder
                        query_correlativo_lotes.Append("SELECT (ULT_CVE + 1) AS ULT_CVE ")
                        query_correlativo_lotes.Append("FROM [SAE60Empre05].[dbo].[TBLCONTROL05] ")
                        query_correlativo_lotes.Append("WHERE (ID_TABLA = 67)")
                        Dim cmd_select_correlativo_enlace As New SqlCommand(query_correlativo_lotes.ToString, ActualizarConexion)
                        Dim adapenlace As New SqlDataAdapter(cmd_select_correlativo_enlace)
                        cmd_select_correlativo_enlace.Transaction = transaccion_sql
                        adapenlace.Fill(ds_correlativo_lotes)
                        'fin de seleccionar el autonumerico de los enlace lotes
                        correlativo_lotes = Convert.ToInt32(ds_correlativo_lotes.Tables(0).Rows(0)(0))

                        Dim NumeroLote As Integer = 0

                        If (ds_lotes.Tables(0).Rows.Count > 0) Then
                            NumeroLote = ds_lotes.Tables(0).Rows(index1)(3)
                        End If

                        If NumeroLote >= cantidad Then
                            can_insertar = cantidad
                            'hacer el enlace a los lotes
                            Dim query_enlace As New StringBuilder
                            query_enlace.Append("INSERT INTO [SAE60Empre05].[dbo].[ENLACE_LTPD05] ")
                            query_enlace.Append("(E_LTPD,REG_LTPD,CANTIDAD,PXRS) ")
                            query_enlace.Append("VALUES (@E_LTPD,@REG_LTPD,@CANTIDAD,@PXRS) ")
                            Dim cmd_enlace_ltp As New SqlCommand(query_enlace.ToString, ActualizarConexion)
                            cmd_enlace_ltp.Parameters.AddWithValue("@E_LTPD", correlativo_lotes)
                            cmd_enlace_ltp.Parameters.AddWithValue("@REG_LTPD", Convert.ToInt32(ds_lotes.Tables(0).Rows(index1)(4)))
                            cmd_enlace_ltp.Parameters.AddWithValue("@CANTIDAD", cantidad)
                            cmd_enlace_ltp.Parameters.AddWithValue("@PXRS", cantidad)
                            cmd_enlace_ltp.Transaction = transaccion_sql
                            cmd_enlace_ltp.ExecuteNonQuery()

                            Dim new_row As DataRow = dt_lotes_crear.NewRow
                            new_row(0) = Convert.ToString(ds_lotes.Tables(0).Rows(index1)(0))
                            new_row(1) = cantidad
                            new_row(2) = ds_lotes.Tables(0).Rows(index1)(5)
                            new_row(3) = ds_lotes.Tables(0).Rows(index1)(2)
                            new_row(4) = ds_lotes.Tables(0).Rows(index1)(6)
                            new_row(5) = ds_lotes.Tables(0).Rows(index1)(7)
                            new_row(6) = ds_lotes.Tables(0).Rows(index1)(8)
                            new_row(7) = ds_lotes.Tables(0).Rows(index1)(9)
                            new_row(8) = ds_lotes.Tables(0).Rows(index1)(10)
                            new_row(9) = ds_lotes.Tables(0).Rows(index1)(11)
                            new_row(10) = ds_lotes.Tables(0).Rows(index1)(12)
                            dt_lotes_crear.Rows.Add(new_row)

                            'actualizar las existencias de los lotes
                            Dim query_ltpd As New StringBuilder
                            query_ltpd.Append("UPDATE [SAE60Empre05].[dbo].[LTPD05] ")
                            query_ltpd.Append("SET [FCHULTMOV] = @FCHULTMOV ")
                            query_ltpd.Append(",[CANTIDAD] = (CANTIDAD - @NUEVA_CANTIDAD) ")
                            query_ltpd.Append("WHERE [CVE_ART] = @CVE_ART AND [LOTE] = @LOTE AND [CVE_ALM] = @CVE_ALM ")
                            Dim cmd_ltpd As New SqlCommand(query_ltpd.ToString, ActualizarConexion)
                            cmd_ltpd.Parameters.AddWithValue("@FCHULTMOV", Today.Date)
                            cmd_ltpd.Parameters.AddWithValue("@NUEVA_CANTIDAD", cantidad)
                            cmd_ltpd.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(1))
                            cmd_ltpd.Parameters.AddWithValue("@LOTE", Convert.ToString(ds_lotes.Tables(0).Rows(index1)(0)))
                            cmd_ltpd.Parameters.AddWithValue("@CVE_ALM", Almacen)
                            cmd_ltpd.Transaction = transaccion_sql
                            cmd_ltpd.ExecuteNonQuery()
                            index1 = ds_lotes.Tables(0).Rows.Count
                        Else
                            can_insertar = (Convert.ToDouble(NumeroLote) - Convert.ToDouble(dt.Rows(index).Item(2)) + Convert.ToDouble(dt.Rows(index).Item(2)))

                            'hacer el enlace a los lotes
                            Dim query_enlace_ltpd_ins As New StringBuilder
                            query_enlace_ltpd_ins.Append("INSERT INTO [SAE60Empre05].[dbo].[ENLACE_LTPD05] ")
                            query_enlace_ltpd_ins.Append("(E_LTPD,REG_LTPD,CANTIDAD,PXRS) ")
                            query_enlace_ltpd_ins.Append("VALUES (@E_LTPD,@REG_LTPD,@CANTIDAD,@PXRS) ")
                            Dim cmd_enlace_ltpd_ins As New SqlCommand(query_enlace_ltpd_ins.ToString, ActualizarConexion)
                            cmd_enlace_ltpd_ins.Parameters.AddWithValue("@E_LTPD", correlativo_lotes)
                            cmd_enlace_ltpd_ins.Parameters.AddWithValue("@REG_LTPD", Convert.ToInt32(ds_lotes.Tables(0).Rows(index1)(4)))
                            cmd_enlace_ltpd_ins.Parameters.AddWithValue("@CANTIDAD", can_insertar)
                            cmd_enlace_ltpd_ins.Parameters.AddWithValue("@PXRS", can_insertar)
                            cmd_enlace_ltpd_ins.Transaction = transaccion_sql
                            cmd_enlace_ltpd_ins.ExecuteNonQuery()

                            Dim new_row As DataRow = dt_lotes_crear.NewRow
                            new_row(0) = Convert.ToString(ds_lotes.Tables(0).Rows(index1)(0))
                            new_row(1) = can_insertar
                            new_row(2) = ds_lotes.Tables(0).Rows(index1)(5)
                            new_row(3) = ds_lotes.Tables(0).Rows(index1)(2)
                            new_row(4) = ds_lotes.Tables(0).Rows(index1)(6)
                            new_row(5) = ds_lotes.Tables(0).Rows(index1)(7)
                            new_row(6) = ds_lotes.Tables(0).Rows(index1)(8)
                            new_row(7) = ds_lotes.Tables(0).Rows(index1)(9)
                            new_row(8) = ds_lotes.Tables(0).Rows(index1)(10)
                            new_row(9) = ds_lotes.Tables(0).Rows(index1)(11)
                            new_row(10) = ds_lotes.Tables(0).Rows(index1)(12)
                            dt_lotes_crear.Rows.Add(new_row)

                            Dim query_upd_ltpd As New StringBuilder
                            query_upd_ltpd.Append("UPDATE [SAE60Empre05].[dbo].[LTPD05] ")
                            query_upd_ltpd.Append("SET [FCHULTMOV] = @FCHULTMOV ")
                            query_upd_ltpd.Append(",[CANTIDAD] = (CANTIDAD - @NUEVA_CANTIDAD) ")
                            query_upd_ltpd.Append("WHERE [CVE_ART] = @CVE_ART AND [LOTE] = @LOTE AND [CVE_ALM] = @CVE_ALM ")
                            Dim cmd_ltpd_upd As New SqlCommand(query_upd_ltpd.ToString, ActualizarConexion)
                            cmd_ltpd_upd.Parameters.AddWithValue("@FCHULTMOV", Today.Date)
                            cmd_ltpd_upd.Parameters.AddWithValue("@NUEVA_CANTIDAD", can_insertar)
                            cmd_ltpd_upd.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(1))
                            cmd_ltpd_upd.Parameters.AddWithValue("@LOTE", Convert.ToString(ds_lotes.Tables(0).Rows(index1)(0)))
                            cmd_ltpd_upd.Parameters.AddWithValue("@CVE_ALM", Almacen)
                            cmd_ltpd_upd.Transaction = transaccion_sql
                            cmd_ltpd_upd.ExecuteNonQuery()
                            cantidad = cantidad - Convert.ToInt32(ds_lotes.Tables(0).Rows(index1)(3))
                            can_insertar = cantidad
                        End If
                    Next

                    'actualizar los correlativos de los lotes
                    Dim query_actualiza_lotes As New StringBuilder
                    query_actualiza_lotes.Append("UPDATE [SAE60Empre05].[dbo].[TBLCONTROL05] ")
                    query_actualiza_lotes.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                    query_actualiza_lotes.Append("WHERE (ID_TABLA = 67) ")
                    Dim cmd_upd_correlativo_lot As New SqlCommand(query_actualiza_lotes.ToString, ActualizarConexion)
                    cmd_upd_correlativo_lot.Transaction = transaccion_sql
                    cmd_upd_correlativo_lot.ExecuteNonQuery()

                End If
                'FIN DE LOS LOTES

                'select Datos INVE
                Dim query_datos_inve As New StringBuilder
                query_datos_inve.Append("SELECT ISNULL(COSTO_PROM,0), ISNULL(UNI_MED,'') ")
                query_datos_inve.Append("FROM [SAE60Empre05].[dbo].[INVE05] ")
                query_datos_inve.Append("WHERE CVE_ART = @CVE_ART")
                Dim comando_datos_inve As New SqlCommand(query_datos_inve.ToString, ActualizarConexion)
                comando_datos_inve.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(5))
                comando_datos_inve.Transaction = transaccion_sql
                Dim adaptador_datos_inve As New SqlDataAdapter(comando_datos_inve)
                Dim dt_datos_inve As New DataTable
                adaptador_datos_inve.Fill(dt_datos_inve)

                'insert MINVE
                Dim query_minve As New StringBuilder
                query_minve.Append("INSERT INTO [SAE60Empre05].[dbo].[MINVE05] ")
                query_minve.Append("   ([CVE_ART],[ALMACEN],[NUM_MOV],[CVE_CPTO],[FECHA_DOCU],[TIPO_DOC],[REFER], ")
                query_minve.Append("    [CANT],[CANT_COST],[PRECIO],[COSTO], ")
                query_minve.Append("    [REG_SERIE],[UNI_VENTA],[E_LTPD],[EXIST_G],[EXISTENCIA],[TIPO_PROD],[FACTOR_CON], ")
                query_minve.Append("    [FECHAELAB],[CVE_FOLIO],[SIGNO],[COSTEADO],[COSTO_PROM_INI], ")
                query_minve.Append("    [COSTO_PROM_FIN],[COSTO_PROM_GRAL],[DESDE_INVE],[MOV_ENLAZADO]) ")
                query_minve.Append("VALUES ")
                query_minve.Append("   (@CVE_ART,@ALMACEN,(SELECT ULT_CVE+1 FROM [SAE60Empre05].[dbo].[TBLCONTROL05] WHERE (ID_TABLA = 44)), ")
                query_minve.Append("    @CVE_CPTO,@FECHA_DOCU,'M',@REFER,@CANT,0,0,@COSTO,0, ")
                query_minve.Append("    @UNI_VENTA,@E_LTPD, ((SELECT ISNULL(EXIST,0) FROM [SAE60Empre05].[dbo].[INVE05] WHERE CVE_ART = @CVE_ART)), ")
                query_minve.Append("    ((SELECT EXIST FROM [SAE60Empre05].[dbo].[MULT05] WHERE (CVE_ART = @CVE_ART) AND CVE_ALM = @ALMACEN)), 'P',1, ")
                query_minve.Append("    @FECHAELAB, (SELECT ULT_CVE+1 FROM [SAE60Empre05].[dbo].[TBLCONTROL05] WHERE (ID_TABLA = 32)), -1, 'S', @COSTO_PROM_INI, ")
                query_minve.Append("    @COSTO_PROM_FIN, @COSTO_PROM_GRAL, 'S', 0) ")

                Dim comando_minve_salida As New SqlCommand(query_minve.ToString, ActualizarConexion)
                comando_minve_salida.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(1))
                comando_minve_salida.Parameters.AddWithValue("@ALMACEN", Almacen)
                comando_minve_salida.Parameters.AddWithValue("@CVE_CPTO", 63)
                comando_minve_salida.Parameters.AddWithValue("@FECHA_DOCU", Today.Date)
                comando_minve_salida.Parameters.AddWithValue("@REFER", "SP" & Today.Day.ToString & Today.Month.ToString & Today.Year.ToString & "-" & UltimaClave + 1)
                comando_minve_salida.Parameters.AddWithValue("@CANT", dt.Rows(index).Item(2))
                comando_minve_salida.Parameters.AddWithValue("@COSTO", 0)
                comando_minve_salida.Parameters.AddWithValue("@UNI_VENTA", dt_datos_inve.Rows(0)(1))
                comando_minve_salida.Parameters.AddWithValue("@E_LTPD", correlativo_lotes)
                comando_minve_salida.Parameters.AddWithValue("@FECHAELAB", Today.Date)
                comando_minve_salida.Parameters.AddWithValue("@COSTO_PROM_INI", 0)
                comando_minve_salida.Parameters.AddWithValue("@COSTO_PROM_FIN", 0)
                comando_minve_salida.Parameters.AddWithValue("@COSTO_PROM_GRAL", 0)
                comando_minve_salida.Transaction = transaccion_sql
                comando_minve_salida.ExecuteNonQuery()

                'update num mov minve
                Dim query_control_num_mov As New StringBuilder
                query_control_num_mov.Append("UPDATE [SAE60Empre05].[dbo].[TBLCONTROL05] ")
                query_control_num_mov.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                query_control_num_mov.Append("WHERE [ID_TABLA] = 44 ")
                Dim comando_control_num_mov As New SqlCommand(query_control_num_mov.ToString, ActualizarConexion)
                comando_control_num_mov.Transaction = transaccion_sql
                comando_control_num_mov.ExecuteNonQuery()

                'FIN DE REGISTRAR LAS SALIDAS

                'INICIO REGISTRAR LAS ENTRADAS
                'update MULT
                Dim query_mult_entrada As New StringBuilder
                query_mult_entrada.Append("UPDATE [SAE60Empre05].[dbo].[MULT05] ")
                query_mult_entrada.Append("SET [EXIST] = ISNULL(EXIST,0) + @CANTIDAD ")
                query_mult_entrada.Append("WHERE [CVE_ART] = @CVE_ART AND [CVE_ALM] = @CVE_ALM ")
                Dim comando_mult_entrada As New SqlCommand(query_mult_entrada.ToString, ActualizarConexion)
                comando_mult_entrada.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(5))
                comando_mult_entrada.Parameters.AddWithValue("@CVE_ALM", Almacen)
                comando_mult_entrada.Parameters.AddWithValue("@CANTIDAD", dt.Rows(index).Item(6))
                comando_mult_entrada.Transaction = transaccion_sql
                comando_mult_entrada.ExecuteNonQuery()

                'update INVE
                Dim query_inve_entrada As New StringBuilder
                query_inve_entrada.Append("UPDATE [SAE60Empre05].[dbo].[INVE05] ")
                query_inve_entrada.Append("SET [EXIST] = EXIST + @CANTIDAD ")
                query_inve_entrada.Append("WHERE [CVE_ART] = @CVE_ART ")
                Dim comando_inve_entrada As New SqlCommand(query_inve_entrada.ToString, ActualizarConexion)
                comando_inve_entrada.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(5))
                comando_inve_entrada.Parameters.AddWithValue("@CANTIDAD", dt.Rows(index).Item(6))
                comando_inve_entrada.Transaction = transaccion_sql
                comando_inve_entrada.ExecuteNonQuery()


                'INICIO DE LOS LOTES
                Dim correlativo_lotes_ENTRADA As Integer = 0
                If dt.Rows(index).Item(8) = "S" Then
                    For index2 As Integer = 0 To dt_lotes_crear.Rows.Count - 1
                        correlativo_lotes_ENTRADA = 0
                        'inicio de seleccinar el autonumerico de los enlace lotes
                        Dim ds_correlativo_lotes As New DataSet
                        Dim query_correlativo_lotes As New StringBuilder
                        query_correlativo_lotes.Append("SELECT (ULT_CVE + 1) AS ULT_CVE ")
                        query_correlativo_lotes.Append("FROM [SAE60Empre05].[dbo].[TBLCONTROL05] ")
                        query_correlativo_lotes.Append("WHERE (ID_TABLA = 67)")
                        Dim cmd_select_correlativo_enlace As New SqlCommand(query_correlativo_lotes.ToString, ActualizarConexion)
                        Dim adapenlace As New SqlDataAdapter(cmd_select_correlativo_enlace)
                        cmd_select_correlativo_enlace.Transaction = transaccion_sql
                        adapenlace.Fill(ds_correlativo_lotes)
                        'fin de seleccionar el autonumerico de los enlace lotes
                        correlativo_lotes_ENTRADA = Convert.ToInt32(ds_correlativo_lotes.Tables(0).Rows(0)(0))

                        Dim query_valida_lote As New StringBuilder
                        query_valida_lote.Append("SELECT CVE_ART,LOTE,REG_LTPD ")
                        query_valida_lote.Append("FROM [SAE60Empre05].[dbo].[LTPD05] ")
                        query_valida_lote.Append("WHERE LOTE = @LOTE AND CVE_ALM = @ALMACEN AND CVE_ART = @CVE_ART ")
                        Dim cmd_valida_lote As New SqlCommand(query_valida_lote.ToString, ActualizarConexion)
                        cmd_valida_lote.Parameters.AddWithValue("@LOTE", dt_lotes_crear.Rows(index2)(0))
                        cmd_valida_lote.Parameters.AddWithValue("@ALMACEN", Almacen)
                        cmd_valida_lote.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(5))
                        cmd_valida_lote.Transaction = transaccion_sql
                        Dim adaptador_valida_lote As New SqlDataAdapter(cmd_valida_lote)
                        Dim dt_valida_lote As New DataTable
                        adaptador_valida_lote.Fill(dt_valida_lote)

                        If dt_valida_lote.Rows.Count > 0 Then
                            'si el lote existe
                            'hacer el enlace a los lotes
                            Dim query_enlace_ltpd_ins_entrada As New StringBuilder
                            query_enlace_ltpd_ins_entrada.Append("INSERT INTO [SAE60Empre05].[dbo].[ENLACE_LTPD05] ")
                            query_enlace_ltpd_ins_entrada.Append("(E_LTPD,REG_LTPD,CANTIDAD,PXRS) ")
                            query_enlace_ltpd_ins_entrada.Append("VALUES (@E_LTPD,@REG_LTPD,@CANTIDAD,@PXRS) ")
                            Dim cmd_enlace_ltpd_ins_entrada As New SqlCommand(query_enlace_ltpd_ins_entrada.ToString, ActualizarConexion)
                            cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@E_LTPD", correlativo_lotes_ENTRADA)
                            cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@REG_LTPD", dt_valida_lote.Rows(0)(2))
                            cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@CANTIDAD", dt_lotes_crear.Rows(index2)(1))
                            cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@PXRS", dt_lotes_crear.Rows(index2)(1))
                            cmd_enlace_ltpd_ins_entrada.Transaction = transaccion_sql
                            cmd_enlace_ltpd_ins_entrada.ExecuteNonQuery()

                            Dim query_upd_ltpd As New StringBuilder
                            query_upd_ltpd.Append("UPDATE [SAE60Empre05].[dbo].[LTPD05] ")
                            query_upd_ltpd.Append("SET [FCHULTMOV] = @FCHULTMOV ")
                            query_upd_ltpd.Append(",[CANTIDAD] = (CANTIDAD + @NUEVA_CANTIDAD) ")
                            query_upd_ltpd.Append("WHERE [CVE_ART] = @CVE_ART AND [LOTE] = @LOTE AND [CVE_ALM] = @CVE_ALM ")
                            Dim cmd_ltpd_upd As New SqlCommand(query_upd_ltpd.ToString, ActualizarConexion)
                            cmd_ltpd_upd.Parameters.AddWithValue("@FCHULTMOV", Today.Date)
                            cmd_ltpd_upd.Parameters.AddWithValue("@NUEVA_CANTIDAD", dt_lotes_crear.Rows(index2)(1))
                            cmd_ltpd_upd.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(5))
                            cmd_ltpd_upd.Parameters.AddWithValue("@LOTE", dt_valida_lote.Rows(0)(1))
                            cmd_ltpd_upd.Parameters.AddWithValue("@CVE_ALM", Almacen)
                            cmd_ltpd_upd.Transaction = transaccion_sql
                            cmd_ltpd_upd.ExecuteNonQuery()
                        Else
                            'si el lote NO existe
                            Dim nuevo_reg_ltpd As Integer = 0
                            'inicio de seleccinar el autonumerico de los lotes
                            Dim ds_nuevo_reg_ltpd As New DataSet
                            Dim query_nuevo_reg_ltpd2 As New StringBuilder
                            query_nuevo_reg_ltpd2.Append("SELECT (ULT_CVE + 1) AS ULT_CVE ")
                            query_nuevo_reg_ltpd2.Append("FROM [SAE60Empre05].[dbo].[TBLCONTROL05] ")
                            query_nuevo_reg_ltpd2.Append("WHERE (ID_TABLA = 48)")
                            Dim cmd_select_nuevo_reg_ltpd2 As New SqlCommand(query_nuevo_reg_ltpd2.ToString, ActualizarConexion)
                            Dim adapnuevo_reg_ltpd As New SqlDataAdapter(cmd_select_nuevo_reg_ltpd2)
                            cmd_select_nuevo_reg_ltpd2.Transaction = transaccion_sql
                            adapnuevo_reg_ltpd.Fill(ds_nuevo_reg_ltpd)
                            'fin de seleccionar el autonumerico de los lotes
                            nuevo_reg_ltpd = Convert.ToInt32(ds_nuevo_reg_ltpd.Tables(0).Rows(0)(0))

                            'hacer el enlace a los lotes
                            Dim query_enlace_ltpd_ins_entrada As New StringBuilder
                            query_enlace_ltpd_ins_entrada.Append("INSERT INTO [SAE60Empre05].[dbo].[ENLACE_LTPD05] ")
                            query_enlace_ltpd_ins_entrada.Append("(E_LTPD,REG_LTPD,CANTIDAD,PXRS) ")
                            query_enlace_ltpd_ins_entrada.Append("VALUES (@E_LTPD,@REG_LTPD,@CANTIDAD,@PXRS) ")
                            Dim cmd_enlace_ltpd_ins_entrada As New SqlCommand(query_enlace_ltpd_ins_entrada.ToString, ActualizarConexion)
                            cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@E_LTPD", correlativo_lotes_ENTRADA)
                            cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@REG_LTPD", nuevo_reg_ltpd)
                            cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@CANTIDAD", dt_lotes_crear.Rows(index2)(1))
                            cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@PXRS", dt_lotes_crear.Rows(index2)(1))
                            cmd_enlace_ltpd_ins_entrada.Transaction = transaccion_sql
                            cmd_enlace_ltpd_ins_entrada.ExecuteNonQuery()
                            'insertar nuevo lote
                            Dim query_insertar_nuevo_lote As New StringBuilder
                            query_insertar_nuevo_lote.Append("INSERT INTO [SAE60Empre05].[dbo].[LTPD05] ")
                            query_insertar_nuevo_lote.Append("([CVE_ART],[LOTE],[PEDIMENTO],[CVE_ALM],[FCHCADUC],[FCHADUANA] ")
                            query_insertar_nuevo_lote.Append(",[FCHULTMOV],[NOM_ADUAN],[CANTIDAD],[REG_LTPD],[CVE_OBS] ")
                            query_insertar_nuevo_lote.Append(",[CIUDAD],[FRONTERA],[FEC_PROD_LT],[GLN],[STATUS]) ")
                            query_insertar_nuevo_lote.Append("VALUES ")
                            query_insertar_nuevo_lote.Append("(@CVE_ART,@LOTE,@PEDIMENTO,@CVE_ALM,@FCHCADUC,@FCHADUANA ")
                            query_insertar_nuevo_lote.Append(",@FCHULTMOV,@NOM_ADUAN,@CANTIDAD,@REG_LTPD,@CVE_OBS,@CIUDAD ")
                            query_insertar_nuevo_lote.Append(",@FRONTERA,@FEC_PROD_LT,@GLN,@STATUS)")
                            Dim cmd_insertar_nuevo_lote As New SqlCommand(query_insertar_nuevo_lote.ToString, ActualizarConexion)
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(5))
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@LOTE", dt_lotes_crear.Rows(index2)(0))
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@PEDIMENTO", dt_lotes_crear.Rows(index2)(2))
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@CVE_ALM", Almacen)

                            If IsDBNull(dt_lotes_crear.Rows(index2)(3)) = True Then
                                cmd_insertar_nuevo_lote.Parameters.AddWithValue("@FCHCADUC", DBNull.Value)
                            Else
                                cmd_insertar_nuevo_lote.Parameters.AddWithValue("@FCHCADUC", Convert.ToDateTime(dt_lotes_crear.Rows(index2)(3)))
                            End If

                            If IsDBNull(dt_lotes_crear.Rows(index2)(4)) = True Then
                                cmd_insertar_nuevo_lote.Parameters.AddWithValue("@FCHADUANA", DBNull.Value)
                            Else
                                cmd_insertar_nuevo_lote.Parameters.AddWithValue("@FCHADUANA", Convert.ToDateTime(dt_lotes_crear.Rows(index2)(4)))
                            End If

                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@FCHULTMOV", Today.Date)
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@NOM_ADUAN", dt_lotes_crear.Rows(index2)(5))
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@CANTIDAD", dt_lotes_crear.Rows(index2)(1))
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@REG_LTPD", nuevo_reg_ltpd)
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@CVE_OBS", dt_lotes_crear.Rows(index2)(6))
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@CIUDAD", dt_lotes_crear.Rows(index2)(7))
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@FRONTERA", dt_lotes_crear.Rows(index2)(8))
                            If IsDBNull(dt_lotes_crear.Rows(index2)(9)) = True Then
                                cmd_insertar_nuevo_lote.Parameters.AddWithValue("@FEC_PROD_LT", DBNull.Value)
                            Else
                                cmd_insertar_nuevo_lote.Parameters.AddWithValue("@FEC_PROD_LT", Convert.ToDateTime(dt_lotes_crear.Rows(index2)(9)))
                            End If
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@GLN", dt_lotes_crear.Rows(index2)(10))
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@STATUS", "A")
                            cmd_insertar_nuevo_lote.Transaction = transaccion_sql
                            cmd_insertar_nuevo_lote.ExecuteNonQuery()

                            'actualizar el autonumerico de lotes
                            Dim query_actualiza_autonumerico_ltpd As New StringBuilder
                            query_actualiza_autonumerico_ltpd.Append("UPDATE [SAE60Empre05].[dbo].[TBLCONTROL05] ")
                            query_actualiza_autonumerico_ltpd.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                            query_actualiza_autonumerico_ltpd.Append("WHERE (ID_TABLA = 48) ")
                            Dim cmd_upd_autonumerico_ltpd As New SqlCommand(query_actualiza_autonumerico_ltpd.ToString, ActualizarConexion)
                            cmd_upd_autonumerico_ltpd.Transaction = transaccion_sql
                            cmd_upd_autonumerico_ltpd.ExecuteNonQuery()

                        End If
                    Next

                    'actualizar los correlativos de enlace de lotes
                    Dim query_actualiza_lotes As New StringBuilder
                    query_actualiza_lotes.Append("UPDATE [SAE60Empre05].[dbo].[TBLCONTROL05] ")
                    query_actualiza_lotes.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                    query_actualiza_lotes.Append("WHERE (ID_TABLA = 67) ")
                    Dim cmd_upd_correlativo_lot As New SqlCommand(query_actualiza_lotes.ToString, ActualizarConexion)
                    cmd_upd_correlativo_lot.Transaction = transaccion_sql
                    cmd_upd_correlativo_lot.ExecuteNonQuery()
                End If

                'insert MINVE
                Dim query_minve_entrada As New StringBuilder
                query_minve_entrada.Append("INSERT INTO [SAE60Empre05].[dbo].[MINVE05] ")
                query_minve_entrada.Append("   ([CVE_ART],[ALMACEN],[NUM_MOV],[CVE_CPTO],[FECHA_DOCU],[TIPO_DOC],[REFER], ")
                query_minve_entrada.Append("    [CANT],[CANT_COST],[PRECIO],[COSTO], ")
                query_minve_entrada.Append("    [REG_SERIE],[UNI_VENTA],[E_LTPD],[EXIST_G],[EXISTENCIA],[TIPO_PROD],[FACTOR_CON], ")
                query_minve_entrada.Append("    [FECHAELAB],[CVE_FOLIO],[SIGNO],[COSTEADO],[COSTO_PROM_INI], ")
                query_minve_entrada.Append("    [COSTO_PROM_FIN],[COSTO_PROM_GRAL],[DESDE_INVE],[MOV_ENLAZADO]) ")
                query_minve_entrada.Append("VALUES ")
                query_minve_entrada.Append("   (@CVE_ART,@ALMACEN,(SELECT ULT_CVE+1 FROM [SAE60Empre05].[dbo].[TBLCONTROL05] WHERE (ID_TABLA = 44)), ")
                query_minve_entrada.Append("    @CVE_CPTO,@FECHA_DOCU,'M',@REFER,@CANT,0,0,@COSTO,0, ")
                query_minve_entrada.Append("    @UNI_VENTA,@E_LTPD, ((SELECT ISNULL(EXIST,0) FROM [SAE60Empre05].[dbo].[INVE05] WHERE CVE_ART = @CVE_ART)), ")
                query_minve_entrada.Append("    ((SELECT EXIST FROM [SAE60Empre05].[dbo].[MULT05] WHERE (CVE_ART = @CVE_ART) AND CVE_ALM = @ALMACEN)), 'P',1, ")
                query_minve_entrada.Append("    @FECHAELAB, (SELECT ULT_CVE+1 FROM [SAE60Empre05].[dbo].[TBLCONTROL05] WHERE (ID_TABLA = 32)), 1, 'S', @COSTO_PROM_INI, ")
                query_minve_entrada.Append("    @COSTO_PROM_FIN, @COSTO_PROM_GRAL, 'S', (SELECT ULT_CVE FROM [SAE60Empre05].[dbo].[TBLCONTROL05] WHERE (ID_TABLA = 44))) ")
                Dim comando_minve_entrada As New SqlCommand(query_minve_entrada.ToString, ActualizarConexion)
                comando_minve_entrada.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(5))
                comando_minve_entrada.Parameters.AddWithValue("@ALMACEN", Almacen)
                comando_minve_entrada.Parameters.AddWithValue("@CVE_CPTO", 11)
                comando_minve_entrada.Parameters.AddWithValue("@FECHA_DOCU", Today.Date)
                comando_minve_entrada.Parameters.AddWithValue("@REFER", "EP" & Today.Day.ToString & Today.Month.ToString & Today.Year.ToString & "-" & UltimaClave + 1)

                comando_minve_entrada.Parameters.AddWithValue("@CANT", dt.Rows(index).Item(6))
                comando_minve_entrada.Parameters.AddWithValue("@COSTO", dt_datos_inve.Rows(0)(0))
                comando_minve_entrada.Parameters.AddWithValue("@UNI_VENTA", dt_datos_inve.Rows(0)(1))
                comando_minve_entrada.Parameters.AddWithValue("@E_LTPD", correlativo_lotes_ENTRADA)
                comando_minve_entrada.Parameters.AddWithValue("@FECHAELAB", Today.Date)
                comando_minve_entrada.Parameters.AddWithValue("@COSTO_PROM_INI", dt_datos_inve.Rows(0)(0))
                comando_minve_entrada.Parameters.AddWithValue("@COSTO_PROM_FIN", dt_datos_inve.Rows(0)(0))
                comando_minve_entrada.Parameters.AddWithValue("@COSTO_PROM_GRAL", dt_datos_inve.Rows(0)(0))
                comando_minve_entrada.Transaction = transaccion_sql
                comando_minve_entrada.ExecuteNonQuery()

                'update num mov minve
                Dim query_control_num_mov_entrada As New StringBuilder
                query_control_num_mov_entrada.Append("UPDATE [SAE60Empre05].[dbo].[TBLCONTROL05] ")
                query_control_num_mov_entrada.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                query_control_num_mov_entrada.Append("WHERE [ID_TABLA] = 44 ")
                Dim comando_control_num_mov_entrada As New SqlCommand(query_control_num_mov_entrada.ToString, ActualizarConexion)
                comando_control_num_mov_entrada.Transaction = transaccion_sql
                comando_control_num_mov_entrada.ExecuteNonQuery()
            Next
            'FIN DE MOVIMIENTOS DEL SAE

            'update cve_folio minve
            Dim query_control_folio As New StringBuilder
            query_control_folio.Append("UPDATE [SAE60Empre05].[dbo].[TBLCONTROL05] ")
            query_control_folio.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
            query_control_folio.Append("WHERE ([ID_TABLA] = 32) ")
            Dim comando_control_folio As New SqlCommand(query_control_folio.ToString, ActualizarConexion)
            comando_control_folio.Transaction = transaccion_sql
            comando_control_folio.ExecuteNonQuery()

            Dim conexion_bita As New cls_bitacora_reporteador
            conexion_bita.RegistraBitacora(Now, usuario, "Realizó Traslado de Producto a Promoción", "ALMACEN", _
                                      "Fecha: " & DateTime.Now & " Cantidad de Productos: " & dt.Rows.Count & " Almacén:" & Almacen)

            transaccion_sql.Commit()
            ActualizarConexion.Close()
            Return "correcto"

        Catch ex As Exception
            Dim tamaño As Integer = Convert.ToString(ex.StackTrace).Length
            Dim posicion As Integer = InStrRev(Convert.ToString(ex.StackTrace), "línea") - 1
            Dim inicial As Integer = tamaño - posicion
            Dim linea_error As String = Convert.ToString(ex.StackTrace).Substring(tamaño - inicial, inicial)
            transaccion_sql.Rollback()
            ActualizarConexion.Close()
            Return ex.Message & " " & linea_error
        End Try
    End Function

    Public Function GuardarPromocionesAProductoDIMOSA(ByVal dt As DataTable, ByVal usuario As String, ByVal Empresa As String, ByVal Almacen As Integer)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim transaccion_sql As SqlTransaction
        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand

            For index As Integer = 0 To dt.Rows.Count - 1

                Dim UltimaClave As Integer = 0
                Dim dt_CVE As New DataTable
                Dim query_CVE As New StringBuilder
                query_CVE.Append("SELECT MAX([Usuarios].[dbo].[PROMO_MOVIMIENTOS].[PROM_ID]) FROM [Usuarios].[dbo].[PROMO_MOVIMIENTOS] ")

                Dim cmd_select_CVE As New SqlCommand(query_CVE.ToString, ActualizarConexion)
                Dim adaptador_CVE As New SqlDataAdapter(cmd_select_CVE)
                cmd_select_CVE.Transaction = transaccion_sql
                adaptador_CVE.Fill(dt_CVE)
                If Not IsDBNull(dt_CVE.Rows(0)(0)) Then
                    UltimaClave = dt_CVE.Rows(0)(0)
                End If

                miComando = New SqlCommand("INSERT INTO [Usuarios].[dbo].[PROMO_MOVIMIENTOS] " & _
                                             "([PROM_ID], [PROM_DETALLE], [PROM_FECHA], [CVE_PRODUCTO], [PRODUCTO_UNIDAD], [PRODUCTO_CANTIDAD], [CVE_PROM], [PROM_UNIDAD], [PROM_CANTIDAD], [CONCEPTO_PROV] ,[EMPRESA], [ALMACEN]) " & _
                                             "VALUES(@PROM_ID, @PROM_DETALLE, @PROM_FECHA, @CVE_PRODUCTO, @PRODUCTO_UNIDAD, @PRODUCTO_CANTIDAD, @CVE_PROM, @PROM_UNIDAD, @PROM_CANTIDAD, @CONCEPTO_PROV, @EMPRESA, @ALMACEN) ", ActualizarConexion)
                miComando.Parameters.AddWithValue("@PROM_ID", UltimaClave + 1)
                miComando.Parameters.AddWithValue("@PROM_DETALLE", dt.Rows(index).Item(0))
                miComando.Parameters.AddWithValue("@PROM_FECHA", Today.Date)
                miComando.Parameters.AddWithValue("@CVE_PRODUCTO", dt.Rows(index).Item(1))
                miComando.Parameters.AddWithValue("@PRODUCTO_UNIDAD", dt.Rows(index).Item(3))
                miComando.Parameters.AddWithValue("@PRODUCTO_CANTIDAD", dt.Rows(index).Item(2))
                miComando.Parameters.AddWithValue("@CVE_PROM", dt.Rows(index).Item(5))
                miComando.Parameters.AddWithValue("@PROM_UNIDAD", dt.Rows(index).Item(7))
                miComando.Parameters.AddWithValue("@PROM_CANTIDAD", dt.Rows(index).Item(6))
                miComando.Parameters.AddWithValue("@CONCEPTO_PROV", dt.Rows(index).Item(9))
                miComando.Parameters.AddWithValue("@EMPRESA", Empresa)
                miComando.Parameters.AddWithValue("@ALMACEN", Almacen)
                miComando.Transaction = transaccion_sql
                miComando.ExecuteNonQuery()

                ' registrar las salidas
                'update MULT
                Dim query_mult_salida As New StringBuilder
                query_mult_salida.Append("UPDATE [SAE60Empre06].[dbo].[MULT06] ")
                query_mult_salida.Append("SET [EXIST] = ISNULL(EXIST,0) - @CANTIDAD ")
                query_mult_salida.Append("WHERE [CVE_ART] = @CVE_ART AND [CVE_ALM] = @CVE_ALM ")
                Dim comando_mult_salida As New SqlCommand(query_mult_salida.ToString, ActualizarConexion)
                comando_mult_salida.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(1))
                comando_mult_salida.Parameters.AddWithValue("@CVE_ALM", Almacen)
                comando_mult_salida.Parameters.AddWithValue("@CANTIDAD", dt.Rows(index).Item(2))
                comando_mult_salida.Transaction = transaccion_sql
                comando_mult_salida.ExecuteNonQuery()

                'update INVE
                Dim query_inve As New StringBuilder
                query_inve.Append("UPDATE [SAE60Empre06].[dbo].[INVE06] ")
                query_inve.Append("SET [EXIST] = EXIST - @CANTIDAD ")
                query_inve.Append("WHERE [CVE_ART] = @CVE_ART ")
                Dim comando_inve_salida As New SqlCommand(query_inve.ToString, ActualizarConexion)
                comando_inve_salida.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(1))
                comando_inve_salida.Parameters.AddWithValue("@CANTIDAD", dt.Rows(index).Item(2))
                comando_inve_salida.Transaction = transaccion_sql
                comando_inve_salida.ExecuteNonQuery()

                'INICIO DE LOS LOTES

                Dim dt_lotes_crear As New DataTable
                dt_lotes_crear.Columns.Clear()
                dt_lotes_crear.Columns.Add("LOTE")
                dt_lotes_crear.Columns.Add("CANT")
                dt_lotes_crear.Columns.Add("PEDIMENTO")
                dt_lotes_crear.Columns.Add("FCHCADUC")
                dt_lotes_crear.Columns.Add("FCHADUANA")
                dt_lotes_crear.Columns.Add("NOM_ADUANA")
                dt_lotes_crear.Columns.Add("CVE_OBS")
                dt_lotes_crear.Columns.Add("CIUDAD")
                dt_lotes_crear.Columns.Add("FRONTERA")
                dt_lotes_crear.Columns.Add("FEC_PROD_LT")
                dt_lotes_crear.Columns.Add("GLN")
                Dim correlativo_lotes As Integer = 0
                dt_lotes_crear.Rows.Clear()
                If dt.Rows(index).Item(4) = "S" Then
                    Dim ds_lotes As New DataSet
                    Dim cantidad As Double = 0, can_insertar As Double = 0

                    Dim query As New StringBuilder
                    query.Append("SELECT LOTE, CVE_ALM, FCHCADUC, CANTIDAD, REG_LTPD,PEDIMENTO,FCHADUANA, ")
                    query.Append("NOM_ADUAN,CVE_OBS,CIUDAD,FRONTERA,FEC_PROD_LT, GLN ")
                    query.Append("FROM [SAE60Empre06].[dbo].[LTPD06] WHERE (STATUS = 'A') AND (CVE_ART = @CVE_ART) AND CVE_ALM = @CVE_ALM")
                    query.Append(" AND (CANTIDAD > 0) AND (FCHCADUC > GETDATE() OR FCHCADUC IS NULL OR FCHCADUC = '') ")
                    query.Append("ORDER BY FCHCADUC ")
                    Dim cmd_select_lotes As New SqlCommand(query.ToString, ActualizarConexion)
                    cmd_select_lotes.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(1))
                    cmd_select_lotes.Parameters.AddWithValue("@CVE_ALM", Almacen)
                    Dim adaptador As New SqlDataAdapter(cmd_select_lotes)
                    cmd_select_lotes.Transaction = transaccion_sql
                    adaptador.Fill(ds_lotes)
                    cantidad = Convert.ToDouble(dt.Rows(index).Item(2))

                    'for de los lotes
                    For index1 As Integer = 0 To ds_lotes.Tables(0).Rows.Count
                        correlativo_lotes = 0
                        'inicio de seleccinar el autonumerico de los enlace lotes
                        Dim ds_correlativo_lotes As New DataSet
                        Dim query_correlativo_lotes As New StringBuilder
                        query_correlativo_lotes.Append("SELECT (ULT_CVE + 1) AS ULT_CVE ")
                        query_correlativo_lotes.Append("FROM [SAE60Empre06].[dbo].[TBLCONTROL06] ")
                        query_correlativo_lotes.Append("WHERE (ID_TABLA = 67)")
                        Dim cmd_select_correlativo_enlace As New SqlCommand(query_correlativo_lotes.ToString, ActualizarConexion)
                        Dim adapenlace As New SqlDataAdapter(cmd_select_correlativo_enlace)
                        cmd_select_correlativo_enlace.Transaction = transaccion_sql
                        adapenlace.Fill(ds_correlativo_lotes)
                        'fin de seleccionar el autonumerico de los enlace lotes
                        correlativo_lotes = Convert.ToInt32(ds_correlativo_lotes.Tables(0).Rows(0)(0))

                        Dim NumeroLote As Integer = 0

                        If (ds_lotes.Tables(0).Rows.Count > 0) Then
                            NumeroLote = ds_lotes.Tables(0).Rows(index1)(3)
                        End If

                        If NumeroLote >= cantidad Then
                            can_insertar = cantidad
                            'hacer el enlace a los lotes
                            Dim query_enlace As New StringBuilder
                            query_enlace.Append("INSERT INTO [SAE60Empre06].[dbo].[ENLACE_LTPD06] ")
                            query_enlace.Append("(E_LTPD,REG_LTPD,CANTIDAD,PXRS) ")
                            query_enlace.Append("VALUES (@E_LTPD,@REG_LTPD,@CANTIDAD,@PXRS) ")
                            Dim cmd_enlace_ltp As New SqlCommand(query_enlace.ToString, ActualizarConexion)
                            cmd_enlace_ltp.Parameters.AddWithValue("@E_LTPD", correlativo_lotes)
                            cmd_enlace_ltp.Parameters.AddWithValue("@REG_LTPD", Convert.ToInt32(ds_lotes.Tables(0).Rows(index1)(4)))
                            cmd_enlace_ltp.Parameters.AddWithValue("@CANTIDAD", cantidad)
                            cmd_enlace_ltp.Parameters.AddWithValue("@PXRS", cantidad)
                            cmd_enlace_ltp.Transaction = transaccion_sql
                            cmd_enlace_ltp.ExecuteNonQuery()

                            Dim new_row As DataRow = dt_lotes_crear.NewRow
                            new_row(0) = Convert.ToString(ds_lotes.Tables(0).Rows(index1)(0))
                            new_row(1) = cantidad
                            new_row(2) = ds_lotes.Tables(0).Rows(index1)(5)
                            new_row(3) = ds_lotes.Tables(0).Rows(index1)(2)
                            new_row(4) = ds_lotes.Tables(0).Rows(index1)(6)
                            new_row(5) = ds_lotes.Tables(0).Rows(index1)(7)
                            new_row(6) = ds_lotes.Tables(0).Rows(index1)(8)
                            new_row(7) = ds_lotes.Tables(0).Rows(index1)(9)
                            new_row(8) = ds_lotes.Tables(0).Rows(index1)(10)
                            new_row(9) = ds_lotes.Tables(0).Rows(index1)(11)
                            new_row(10) = ds_lotes.Tables(0).Rows(index1)(12)
                            dt_lotes_crear.Rows.Add(new_row)

                            'actualizar las existencias de los lotes
                            Dim query_ltpd As New StringBuilder
                            query_ltpd.Append("UPDATE [SAE60Empre06].[dbo].[LTPD06] ")
                            query_ltpd.Append("SET [FCHULTMOV] = @FCHULTMOV ")
                            query_ltpd.Append(",[CANTIDAD] = (CANTIDAD - @NUEVA_CANTIDAD) ")
                            query_ltpd.Append("WHERE [CVE_ART] = @CVE_ART AND [LOTE] = @LOTE AND [CVE_ALM] = @CVE_ALM ")
                            Dim cmd_ltpd As New SqlCommand(query_ltpd.ToString, ActualizarConexion)
                            cmd_ltpd.Parameters.AddWithValue("@FCHULTMOV", Today.Date)
                            cmd_ltpd.Parameters.AddWithValue("@NUEVA_CANTIDAD", cantidad)
                            cmd_ltpd.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(1))
                            cmd_ltpd.Parameters.AddWithValue("@LOTE", Convert.ToString(ds_lotes.Tables(0).Rows(index1)(0)))
                            cmd_ltpd.Parameters.AddWithValue("@CVE_ALM", Almacen)
                            cmd_ltpd.Transaction = transaccion_sql
                            cmd_ltpd.ExecuteNonQuery()
                            index1 = ds_lotes.Tables(0).Rows.Count
                        Else
                            can_insertar = (Convert.ToDouble(NumeroLote) - Convert.ToDouble(dt.Rows(index).Item(2)) + Convert.ToDouble(dt.Rows(index).Item(2)))

                            'hacer el enlace a los lotes
                            Dim query_enlace_ltpd_ins As New StringBuilder
                            query_enlace_ltpd_ins.Append("INSERT INTO [SAE60Empre06].[dbo].[ENLACE_LTPD06] ")
                            query_enlace_ltpd_ins.Append("(E_LTPD,REG_LTPD,CANTIDAD,PXRS) ")
                            query_enlace_ltpd_ins.Append("VALUES (@E_LTPD,@REG_LTPD,@CANTIDAD,@PXRS) ")
                            Dim cmd_enlace_ltpd_ins As New SqlCommand(query_enlace_ltpd_ins.ToString, ActualizarConexion)
                            cmd_enlace_ltpd_ins.Parameters.AddWithValue("@E_LTPD", correlativo_lotes)
                            cmd_enlace_ltpd_ins.Parameters.AddWithValue("@REG_LTPD", Convert.ToInt32(ds_lotes.Tables(0).Rows(index1)(4)))
                            cmd_enlace_ltpd_ins.Parameters.AddWithValue("@CANTIDAD", can_insertar)
                            cmd_enlace_ltpd_ins.Parameters.AddWithValue("@PXRS", can_insertar)
                            cmd_enlace_ltpd_ins.Transaction = transaccion_sql
                            cmd_enlace_ltpd_ins.ExecuteNonQuery()

                            Dim new_row As DataRow = dt_lotes_crear.NewRow
                            new_row(0) = Convert.ToString(ds_lotes.Tables(0).Rows(index1)(0))
                            new_row(1) = can_insertar
                            new_row(2) = ds_lotes.Tables(0).Rows(index1)(5)
                            new_row(3) = ds_lotes.Tables(0).Rows(index1)(2)
                            new_row(4) = ds_lotes.Tables(0).Rows(index1)(6)
                            new_row(5) = ds_lotes.Tables(0).Rows(index1)(7)
                            new_row(6) = ds_lotes.Tables(0).Rows(index1)(8)
                            new_row(7) = ds_lotes.Tables(0).Rows(index1)(9)
                            new_row(8) = ds_lotes.Tables(0).Rows(index1)(10)
                            new_row(9) = ds_lotes.Tables(0).Rows(index1)(11)
                            new_row(10) = ds_lotes.Tables(0).Rows(index1)(12)
                            dt_lotes_crear.Rows.Add(new_row)

                            Dim query_upd_ltpd As New StringBuilder
                            query_upd_ltpd.Append("UPDATE [SAE60Empre06].[dbo].[LTPD06] ")
                            query_upd_ltpd.Append("SET [FCHULTMOV] = @FCHULTMOV ")
                            query_upd_ltpd.Append(",[CANTIDAD] = (CANTIDAD - @NUEVA_CANTIDAD) ")
                            query_upd_ltpd.Append("WHERE [CVE_ART] = @CVE_ART AND [LOTE] = @LOTE AND [CVE_ALM] = @CVE_ALM ")
                            Dim cmd_ltpd_upd As New SqlCommand(query_upd_ltpd.ToString, ActualizarConexion)
                            cmd_ltpd_upd.Parameters.AddWithValue("@FCHULTMOV", Today.Date)
                            cmd_ltpd_upd.Parameters.AddWithValue("@NUEVA_CANTIDAD", can_insertar)
                            cmd_ltpd_upd.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(1))
                            cmd_ltpd_upd.Parameters.AddWithValue("@LOTE", Convert.ToString(ds_lotes.Tables(0).Rows(index1)(0)))
                            cmd_ltpd_upd.Parameters.AddWithValue("@CVE_ALM", Almacen)
                            cmd_ltpd_upd.Transaction = transaccion_sql
                            cmd_ltpd_upd.ExecuteNonQuery()
                            cantidad = cantidad - Convert.ToInt32(ds_lotes.Tables(0).Rows(index1)(3))
                            can_insertar = cantidad
                        End If
                    Next

                    'actualizar los correlativos de los lotes
                    Dim query_actualiza_lotes As New StringBuilder
                    query_actualiza_lotes.Append("UPDATE [SAE60Empre06].[dbo].[TBLCONTROL06] ")
                    query_actualiza_lotes.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                    query_actualiza_lotes.Append("WHERE (ID_TABLA = 67) ")
                    Dim cmd_upd_correlativo_lot As New SqlCommand(query_actualiza_lotes.ToString, ActualizarConexion)
                    cmd_upd_correlativo_lot.Transaction = transaccion_sql
                    cmd_upd_correlativo_lot.ExecuteNonQuery()

                End If
                'FIN DE LOS LOTES

                'select Datos INVE
                Dim query_datos_inve As New StringBuilder
                query_datos_inve.Append("SELECT ISNULL(COSTO_PROM,0), ISNULL(UNI_MED,'') ")
                query_datos_inve.Append("FROM [SAE60Empre06].[dbo].[INVE06] ")
                query_datos_inve.Append("WHERE CVE_ART = @CVE_ART")
                Dim comando_datos_inve As New SqlCommand(query_datos_inve.ToString, ActualizarConexion)
                comando_datos_inve.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(5))
                comando_datos_inve.Transaction = transaccion_sql
                Dim adaptador_datos_inve As New SqlDataAdapter(comando_datos_inve)
                Dim dt_datos_inve As New DataTable
                adaptador_datos_inve.Fill(dt_datos_inve)

                'insert MINVE
                Dim query_minve As New StringBuilder
                query_minve.Append("INSERT INTO [SAE60Empre06].[dbo].[MINVE06] ")
                query_minve.Append("   ([CVE_ART],[ALMACEN],[NUM_MOV],[CVE_CPTO],[FECHA_DOCU],[TIPO_DOC],[REFER], ")
                query_minve.Append("    [CANT],[CANT_COST],[PRECIO],[COSTO], ")
                query_minve.Append("    [REG_SERIE],[UNI_VENTA],[E_LTPD],[EXIST_G],[EXISTENCIA],[TIPO_PROD],[FACTOR_CON], ")
                query_minve.Append("    [FECHAELAB],[CVE_FOLIO],[SIGNO],[COSTEADO],[COSTO_PROM_INI], ")
                query_minve.Append("    [COSTO_PROM_FIN],[COSTO_PROM_GRAL],[DESDE_INVE],[MOV_ENLAZADO]) ")
                query_minve.Append("VALUES ")
                query_minve.Append("   (@CVE_ART,@ALMACEN,(SELECT ULT_CVE+1 FROM [SAE60Empre06].[dbo].[TBLCONTROL06] WHERE (ID_TABLA = 44)), ")
                query_minve.Append("    @CVE_CPTO,@FECHA_DOCU,'M',@REFER,@CANT,0,0,@COSTO,0, ")
                query_minve.Append("    @UNI_VENTA,@E_LTPD, ((SELECT ISNULL(EXIST,0) FROM [SAE60Empre06].[dbo].[INVE06] WHERE CVE_ART = @CVE_ART)), ")
                query_minve.Append("    ((SELECT EXIST FROM [SAE60Empre06].[dbo].[MULT06] WHERE (CVE_ART = @CVE_ART) AND CVE_ALM = @ALMACEN)), 'P',1, ")
                query_minve.Append("    @FECHAELAB, (SELECT ULT_CVE+1 FROM [SAE60Empre06].[dbo].[TBLCONTROL06] WHERE (ID_TABLA = 32)), -1, 'S', @COSTO_PROM_INI, ")
                query_minve.Append("    @COSTO_PROM_FIN, @COSTO_PROM_GRAL, 'S', 0) ")

                Dim comando_minve_salida As New SqlCommand(query_minve.ToString, ActualizarConexion)
                comando_minve_salida.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(1))
                comando_minve_salida.Parameters.AddWithValue("@ALMACEN", Almacen)
                comando_minve_salida.Parameters.AddWithValue("@CVE_CPTO", 63)
                comando_minve_salida.Parameters.AddWithValue("@FECHA_DOCU", Today.Date)
                comando_minve_salida.Parameters.AddWithValue("@REFER", "SP" & Today.Day.ToString & Today.Month.ToString & Today.Year.ToString & "-" & UltimaClave + 1)
                comando_minve_salida.Parameters.AddWithValue("@CANT", dt.Rows(index).Item(2))
                comando_minve_salida.Parameters.AddWithValue("@COSTO", 0)
                comando_minve_salida.Parameters.AddWithValue("@UNI_VENTA", dt_datos_inve.Rows(0)(1))
                comando_minve_salida.Parameters.AddWithValue("@E_LTPD", correlativo_lotes)
                comando_minve_salida.Parameters.AddWithValue("@FECHAELAB", Today.Date)
                comando_minve_salida.Parameters.AddWithValue("@COSTO_PROM_INI", 0)
                comando_minve_salida.Parameters.AddWithValue("@COSTO_PROM_FIN", 0)
                comando_minve_salida.Parameters.AddWithValue("@COSTO_PROM_GRAL", 0)
                comando_minve_salida.Transaction = transaccion_sql
                comando_minve_salida.ExecuteNonQuery()

                'update num mov minve
                Dim query_control_num_mov As New StringBuilder
                query_control_num_mov.Append("UPDATE [SAE60Empre06].[dbo].[TBLCONTROL06] ")
                query_control_num_mov.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                query_control_num_mov.Append("WHERE [ID_TABLA] = 44 ")
                Dim comando_control_num_mov As New SqlCommand(query_control_num_mov.ToString, ActualizarConexion)
                comando_control_num_mov.Transaction = transaccion_sql
                comando_control_num_mov.ExecuteNonQuery()

                'FIN DE REGISTRAR LAS SALIDAS

                'INICIO REGISTRAR LAS ENTRADAS
                'update MULT
                Dim query_mult_entrada As New StringBuilder
                query_mult_entrada.Append("UPDATE [SAE60Empre06].[dbo].[MULT06] ")
                query_mult_entrada.Append("SET [EXIST] = ISNULL(EXIST,0) + @CANTIDAD ")
                query_mult_entrada.Append("WHERE [CVE_ART] = @CVE_ART AND [CVE_ALM] = @CVE_ALM ")
                Dim comando_mult_entrada As New SqlCommand(query_mult_entrada.ToString, ActualizarConexion)
                comando_mult_entrada.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(5))
                comando_mult_entrada.Parameters.AddWithValue("@CVE_ALM", Almacen)
                comando_mult_entrada.Parameters.AddWithValue("@CANTIDAD", dt.Rows(index).Item(6))
                comando_mult_entrada.Transaction = transaccion_sql
                comando_mult_entrada.ExecuteNonQuery()

                'update INVE
                Dim query_inve_entrada As New StringBuilder
                query_inve_entrada.Append("UPDATE [SAE60Empre06].[dbo].[INVE06] ")
                query_inve_entrada.Append("SET [EXIST] = EXIST + @CANTIDAD ")
                query_inve_entrada.Append("WHERE [CVE_ART] = @CVE_ART ")
                Dim comando_inve_entrada As New SqlCommand(query_inve_entrada.ToString, ActualizarConexion)
                comando_inve_entrada.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(5))
                comando_inve_entrada.Parameters.AddWithValue("@CANTIDAD", dt.Rows(index).Item(6))
                comando_inve_entrada.Transaction = transaccion_sql
                comando_inve_entrada.ExecuteNonQuery()


                'INICIO DE LOS LOTES
                Dim correlativo_lotes_ENTRADA As Integer = 0
                If dt.Rows(index).Item(8) = "S" Then
                    For index2 As Integer = 0 To dt_lotes_crear.Rows.Count - 1
                        correlativo_lotes_ENTRADA = 0
                        'inicio de seleccinar el autonumerico de los enlace lotes
                        Dim ds_correlativo_lotes As New DataSet
                        Dim query_correlativo_lotes As New StringBuilder
                        query_correlativo_lotes.Append("SELECT (ULT_CVE + 1) AS ULT_CVE ")
                        query_correlativo_lotes.Append("FROM [SAE60Empre06].[dbo].[TBLCONTROL06] ")
                        query_correlativo_lotes.Append("WHERE (ID_TABLA = 67)")
                        Dim cmd_select_correlativo_enlace As New SqlCommand(query_correlativo_lotes.ToString, ActualizarConexion)
                        Dim adapenlace As New SqlDataAdapter(cmd_select_correlativo_enlace)
                        cmd_select_correlativo_enlace.Transaction = transaccion_sql
                        adapenlace.Fill(ds_correlativo_lotes)
                        'fin de seleccionar el autonumerico de los enlace lotes
                        correlativo_lotes_ENTRADA = Convert.ToInt32(ds_correlativo_lotes.Tables(0).Rows(0)(0))

                        Dim query_valida_lote As New StringBuilder
                        query_valida_lote.Append("SELECT CVE_ART,LOTE,REG_LTPD ")
                        query_valida_lote.Append("FROM [SAE60Empre06].[dbo].[LTPD06] ")
                        query_valida_lote.Append("WHERE LOTE = @LOTE AND CVE_ALM = @ALMACEN AND CVE_ART = @CVE_ART ")
                        Dim cmd_valida_lote As New SqlCommand(query_valida_lote.ToString, ActualizarConexion)
                        cmd_valida_lote.Parameters.AddWithValue("@LOTE", dt_lotes_crear.Rows(index2)(0))
                        cmd_valida_lote.Parameters.AddWithValue("@ALMACEN", Almacen)
                        cmd_valida_lote.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(5))
                        cmd_valida_lote.Transaction = transaccion_sql
                        Dim adaptador_valida_lote As New SqlDataAdapter(cmd_valida_lote)
                        Dim dt_valida_lote As New DataTable
                        adaptador_valida_lote.Fill(dt_valida_lote)

                        If dt_valida_lote.Rows.Count > 0 Then
                            'si el lote existe
                            'hacer el enlace a los lotes
                            Dim query_enlace_ltpd_ins_entrada As New StringBuilder
                            query_enlace_ltpd_ins_entrada.Append("INSERT INTO [SAE60Empre06].[dbo].[ENLACE_LTPD06] ")
                            query_enlace_ltpd_ins_entrada.Append("(E_LTPD,REG_LTPD,CANTIDAD,PXRS) ")
                            query_enlace_ltpd_ins_entrada.Append("VALUES (@E_LTPD,@REG_LTPD,@CANTIDAD,@PXRS) ")
                            Dim cmd_enlace_ltpd_ins_entrada As New SqlCommand(query_enlace_ltpd_ins_entrada.ToString, ActualizarConexion)
                            cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@E_LTPD", correlativo_lotes_ENTRADA)
                            cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@REG_LTPD", dt_valida_lote.Rows(0)(2))
                            cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@CANTIDAD", dt_lotes_crear.Rows(index2)(1))
                            cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@PXRS", dt_lotes_crear.Rows(index2)(1))
                            cmd_enlace_ltpd_ins_entrada.Transaction = transaccion_sql
                            cmd_enlace_ltpd_ins_entrada.ExecuteNonQuery()

                            Dim query_upd_ltpd As New StringBuilder
                            query_upd_ltpd.Append("UPDATE [SAE60Empre06].[dbo].[LTPD06] ")
                            query_upd_ltpd.Append("SET [FCHULTMOV] = @FCHULTMOV ")
                            query_upd_ltpd.Append(",[CANTIDAD] = (CANTIDAD + @NUEVA_CANTIDAD) ")
                            query_upd_ltpd.Append("WHERE [CVE_ART] = @CVE_ART AND [LOTE] = @LOTE AND [CVE_ALM] = @CVE_ALM ")
                            Dim cmd_ltpd_upd As New SqlCommand(query_upd_ltpd.ToString, ActualizarConexion)
                            cmd_ltpd_upd.Parameters.AddWithValue("@FCHULTMOV", Today.Date)
                            cmd_ltpd_upd.Parameters.AddWithValue("@NUEVA_CANTIDAD", dt_lotes_crear.Rows(index2)(1))
                            cmd_ltpd_upd.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(5))
                            cmd_ltpd_upd.Parameters.AddWithValue("@LOTE", dt_valida_lote.Rows(0)(1))
                            cmd_ltpd_upd.Parameters.AddWithValue("@CVE_ALM", Almacen)
                            cmd_ltpd_upd.Transaction = transaccion_sql
                            cmd_ltpd_upd.ExecuteNonQuery()
                        Else
                            'si el lote NO existe
                            Dim nuevo_reg_ltpd As Integer = 0
                            'inicio de seleccinar el autonumerico de los lotes
                            Dim ds_nuevo_reg_ltpd As New DataSet
                            Dim query_nuevo_reg_ltpd2 As New StringBuilder
                            query_nuevo_reg_ltpd2.Append("SELECT (ULT_CVE + 1) AS ULT_CVE ")
                            query_nuevo_reg_ltpd2.Append("FROM [SAE60Empre06].[dbo].[TBLCONTROL06] ")
                            query_nuevo_reg_ltpd2.Append("WHERE (ID_TABLA = 48)")
                            Dim cmd_select_nuevo_reg_ltpd2 As New SqlCommand(query_nuevo_reg_ltpd2.ToString, ActualizarConexion)
                            Dim adapnuevo_reg_ltpd As New SqlDataAdapter(cmd_select_nuevo_reg_ltpd2)
                            cmd_select_nuevo_reg_ltpd2.Transaction = transaccion_sql
                            adapnuevo_reg_ltpd.Fill(ds_nuevo_reg_ltpd)
                            'fin de seleccionar el autonumerico de los lotes
                            nuevo_reg_ltpd = Convert.ToInt32(ds_nuevo_reg_ltpd.Tables(0).Rows(0)(0))

                            'hacer el enlace a los lotes
                            Dim query_enlace_ltpd_ins_entrada As New StringBuilder
                            query_enlace_ltpd_ins_entrada.Append("INSERT INTO [SAE60Empre06].[dbo].[ENLACE_LTPD06] ")
                            query_enlace_ltpd_ins_entrada.Append("(E_LTPD,REG_LTPD,CANTIDAD,PXRS) ")
                            query_enlace_ltpd_ins_entrada.Append("VALUES (@E_LTPD,@REG_LTPD,@CANTIDAD,@PXRS) ")
                            Dim cmd_enlace_ltpd_ins_entrada As New SqlCommand(query_enlace_ltpd_ins_entrada.ToString, ActualizarConexion)
                            cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@E_LTPD", correlativo_lotes_ENTRADA)
                            cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@REG_LTPD", nuevo_reg_ltpd)
                            cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@CANTIDAD", dt_lotes_crear.Rows(index2)(1))
                            cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@PXRS", dt_lotes_crear.Rows(index2)(1))
                            cmd_enlace_ltpd_ins_entrada.Transaction = transaccion_sql
                            cmd_enlace_ltpd_ins_entrada.ExecuteNonQuery()
                            'insertar nuevo lote
                            Dim query_insertar_nuevo_lote As New StringBuilder
                            query_insertar_nuevo_lote.Append("INSERT INTO [SAE60Empre06].[dbo].[LTPD06] ")
                            query_insertar_nuevo_lote.Append("([CVE_ART],[LOTE],[PEDIMENTO],[CVE_ALM],[FCHCADUC],[FCHADUANA] ")
                            query_insertar_nuevo_lote.Append(",[FCHULTMOV],[NOM_ADUAN],[CANTIDAD],[REG_LTPD],[CVE_OBS] ")
                            query_insertar_nuevo_lote.Append(",[CIUDAD],[FRONTERA],[FEC_PROD_LT],[GLN],[STATUS]) ")
                            query_insertar_nuevo_lote.Append("VALUES ")
                            query_insertar_nuevo_lote.Append("(@CVE_ART,@LOTE,@PEDIMENTO,@CVE_ALM,@FCHCADUC,@FCHADUANA ")
                            query_insertar_nuevo_lote.Append(",@FCHULTMOV,@NOM_ADUAN,@CANTIDAD,@REG_LTPD,@CVE_OBS,@CIUDAD ")
                            query_insertar_nuevo_lote.Append(",@FRONTERA,@FEC_PROD_LT,@GLN,@STATUS)")
                            Dim cmd_insertar_nuevo_lote As New SqlCommand(query_insertar_nuevo_lote.ToString, ActualizarConexion)
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(5))
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@LOTE", dt_lotes_crear.Rows(index2)(0))
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@PEDIMENTO", dt_lotes_crear.Rows(index2)(2))
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@CVE_ALM", Almacen)

                            If IsDBNull(dt_lotes_crear.Rows(index2)(3)) = True Then
                                cmd_insertar_nuevo_lote.Parameters.AddWithValue("@FCHCADUC", DBNull.Value)
                            Else
                                cmd_insertar_nuevo_lote.Parameters.AddWithValue("@FCHCADUC", Convert.ToDateTime(dt_lotes_crear.Rows(index2)(3)))
                            End If

                            If IsDBNull(dt_lotes_crear.Rows(index2)(4)) = True Then
                                cmd_insertar_nuevo_lote.Parameters.AddWithValue("@FCHADUANA", DBNull.Value)
                            Else
                                cmd_insertar_nuevo_lote.Parameters.AddWithValue("@FCHADUANA", Convert.ToDateTime(dt_lotes_crear.Rows(index2)(4)))
                            End If

                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@FCHULTMOV", Today.Date)
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@NOM_ADUAN", dt_lotes_crear.Rows(index2)(5))
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@CANTIDAD", dt_lotes_crear.Rows(index2)(1))
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@REG_LTPD", nuevo_reg_ltpd)
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@CVE_OBS", dt_lotes_crear.Rows(index2)(6))
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@CIUDAD", dt_lotes_crear.Rows(index2)(7))
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@FRONTERA", dt_lotes_crear.Rows(index2)(8))
                            If IsDBNull(dt_lotes_crear.Rows(index2)(9)) = True Then
                                cmd_insertar_nuevo_lote.Parameters.AddWithValue("@FEC_PROD_LT", DBNull.Value)
                            Else
                                cmd_insertar_nuevo_lote.Parameters.AddWithValue("@FEC_PROD_LT", Convert.ToDateTime(dt_lotes_crear.Rows(index2)(9)))
                            End If
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@GLN", dt_lotes_crear.Rows(index2)(10))
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@STATUS", "A")
                            cmd_insertar_nuevo_lote.Transaction = transaccion_sql
                            cmd_insertar_nuevo_lote.ExecuteNonQuery()

                            'actualizar el autonumerico de lotes
                            Dim query_actualiza_autonumerico_ltpd As New StringBuilder
                            query_actualiza_autonumerico_ltpd.Append("UPDATE [SAE60Empre06].[dbo].[TBLCONTROL06] ")
                            query_actualiza_autonumerico_ltpd.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                            query_actualiza_autonumerico_ltpd.Append("WHERE (ID_TABLA = 48) ")
                            Dim cmd_upd_autonumerico_ltpd As New SqlCommand(query_actualiza_autonumerico_ltpd.ToString, ActualizarConexion)
                            cmd_upd_autonumerico_ltpd.Transaction = transaccion_sql
                            cmd_upd_autonumerico_ltpd.ExecuteNonQuery()

                        End If
                    Next

                    'actualizar los correlativos de enlace de lotes
                    Dim query_actualiza_lotes As New StringBuilder
                    query_actualiza_lotes.Append("UPDATE [SAE60Empre06].[dbo].[TBLCONTROL06] ")
                    query_actualiza_lotes.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                    query_actualiza_lotes.Append("WHERE (ID_TABLA = 67) ")
                    Dim cmd_upd_correlativo_lot As New SqlCommand(query_actualiza_lotes.ToString, ActualizarConexion)
                    cmd_upd_correlativo_lot.Transaction = transaccion_sql
                    cmd_upd_correlativo_lot.ExecuteNonQuery()
                End If

                'insert MINVE
                Dim query_minve_entrada As New StringBuilder
                query_minve_entrada.Append("INSERT INTO [SAE60Empre06].[dbo].[MINVE06] ")
                query_minve_entrada.Append("   ([CVE_ART],[ALMACEN],[NUM_MOV],[CVE_CPTO],[FECHA_DOCU],[TIPO_DOC],[REFER], ")
                query_minve_entrada.Append("    [CANT],[CANT_COST],[PRECIO],[COSTO], ")
                query_minve_entrada.Append("    [REG_SERIE],[UNI_VENTA],[E_LTPD],[EXIST_G],[EXISTENCIA],[TIPO_PROD],[FACTOR_CON], ")
                query_minve_entrada.Append("    [FECHAELAB],[CVE_FOLIO],[SIGNO],[COSTEADO],[COSTO_PROM_INI], ")
                query_minve_entrada.Append("    [COSTO_PROM_FIN],[COSTO_PROM_GRAL],[DESDE_INVE],[MOV_ENLAZADO]) ")
                query_minve_entrada.Append("VALUES ")
                query_minve_entrada.Append("   (@CVE_ART,@ALMACEN,(SELECT ULT_CVE+1 FROM [SAE60Empre06].[dbo].[TBLCONTROL06] WHERE (ID_TABLA = 44)), ")
                query_minve_entrada.Append("    @CVE_CPTO,@FECHA_DOCU,'M',@REFER,@CANT,0,0,@COSTO,0, ")
                query_minve_entrada.Append("    @UNI_VENTA,@E_LTPD, ((SELECT ISNULL(EXIST,0) FROM [SAE60Empre06].[dbo].[INVE06] WHERE CVE_ART = @CVE_ART)), ")
                query_minve_entrada.Append("    ((SELECT EXIST FROM [SAE60Empre06].[dbo].[MULT06] WHERE (CVE_ART = @CVE_ART) AND CVE_ALM = @ALMACEN)), 'P',1, ")
                query_minve_entrada.Append("    @FECHAELAB, (SELECT ULT_CVE+1 FROM [SAE60Empre06].[dbo].[TBLCONTROL06] WHERE (ID_TABLA = 32)), 1, 'S', @COSTO_PROM_INI, ")
                query_minve_entrada.Append("    @COSTO_PROM_FIN, @COSTO_PROM_GRAL, 'S', (SELECT ULT_CVE FROM [SAE60Empre06].[dbo].[TBLCONTROL06] WHERE (ID_TABLA = 44))) ")
                Dim comando_minve_entrada As New SqlCommand(query_minve_entrada.ToString, ActualizarConexion)
                comando_minve_entrada.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(5))
                comando_minve_entrada.Parameters.AddWithValue("@ALMACEN", Almacen)
                comando_minve_entrada.Parameters.AddWithValue("@CVE_CPTO", 11)
                comando_minve_entrada.Parameters.AddWithValue("@FECHA_DOCU", Today.Date)
                comando_minve_entrada.Parameters.AddWithValue("@REFER", "EP" & Today.Day.ToString & Today.Month.ToString & Today.Year.ToString & "-" & UltimaClave + 1)

                comando_minve_entrada.Parameters.AddWithValue("@CANT", dt.Rows(index).Item(6))
                comando_minve_entrada.Parameters.AddWithValue("@COSTO", dt_datos_inve.Rows(0)(0))
                comando_minve_entrada.Parameters.AddWithValue("@UNI_VENTA", dt_datos_inve.Rows(0)(1))
                comando_minve_entrada.Parameters.AddWithValue("@E_LTPD", correlativo_lotes_ENTRADA)
                comando_minve_entrada.Parameters.AddWithValue("@FECHAELAB", Today.Date)
                comando_minve_entrada.Parameters.AddWithValue("@COSTO_PROM_INI", dt_datos_inve.Rows(0)(0))
                comando_minve_entrada.Parameters.AddWithValue("@COSTO_PROM_FIN", dt_datos_inve.Rows(0)(0))
                comando_minve_entrada.Parameters.AddWithValue("@COSTO_PROM_GRAL", dt_datos_inve.Rows(0)(0))
                comando_minve_entrada.Transaction = transaccion_sql
                comando_minve_entrada.ExecuteNonQuery()

                'update num mov minve
                Dim query_control_num_mov_entrada As New StringBuilder
                query_control_num_mov_entrada.Append("UPDATE [SAE60Empre06].[dbo].[TBLCONTROL06] ")
                query_control_num_mov_entrada.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                query_control_num_mov_entrada.Append("WHERE [ID_TABLA] = 44 ")
                Dim comando_control_num_mov_entrada As New SqlCommand(query_control_num_mov_entrada.ToString, ActualizarConexion)
                comando_control_num_mov_entrada.Transaction = transaccion_sql
                comando_control_num_mov_entrada.ExecuteNonQuery()
            Next
            'FIN DE MOVIMIENTOS DEL SAE

            'update cve_folio minve
            Dim query_control_folio As New StringBuilder
            query_control_folio.Append("UPDATE [SAE60Empre06].[dbo].[TBLCONTROL06] ")
            query_control_folio.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
            query_control_folio.Append("WHERE ([ID_TABLA] = 32) ")
            Dim comando_control_folio As New SqlCommand(query_control_folio.ToString, ActualizarConexion)
            comando_control_folio.Transaction = transaccion_sql
            comando_control_folio.ExecuteNonQuery()

            Dim conexion_bita As New cls_bitacora_reporteador
            conexion_bita.RegistraBitacora(Now, usuario, "Realizó Traslado de Producto a Promoción", "ALMACEN", _
                                      "Fecha: " & DateTime.Now & " Cantidad de Productos: " & dt.Rows.Count & " Almacén:" & Almacen)

            transaccion_sql.Commit()
            ActualizarConexion.Close()
            Return "correcto"

        Catch ex As Exception
            Dim tamaño As Integer = Convert.ToString(ex.StackTrace).Length
            Dim posicion As Integer = InStrRev(Convert.ToString(ex.StackTrace), "línea") - 1
            Dim inicial As Integer = tamaño - posicion
            Dim linea_error As String = Convert.ToString(ex.StackTrace).Substring(tamaño - inicial, inicial)
            transaccion_sql.Rollback()
            ActualizarConexion.Close()
            Return ex.Message & " " & linea_error
        End Try
    End Function

    Public Function GuardarPromocionesAProductoAGRO(ByVal dt As DataTable, ByVal usuario As String, ByVal Empresa As String, ByVal Almacen As Integer)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim transaccion_sql As SqlTransaction
        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand



            For index As Integer = 0 To dt.Rows.Count - 1

                Dim UltimaClave As Integer = 0
                Dim dt_CVE As New DataTable
                Dim query_CVE As New StringBuilder
                query_CVE.Append("SELECT MAX([Usuarios].[dbo].[PROMO_MOVIMIENTOS].[PROM_ID]) FROM [Usuarios].[dbo].[PROMO_MOVIMIENTOS] ")

                Dim cmd_select_CVE As New SqlCommand(query_CVE.ToString, ActualizarConexion)
                Dim adaptador_CVE As New SqlDataAdapter(cmd_select_CVE)
                cmd_select_CVE.Transaction = transaccion_sql
                adaptador_CVE.Fill(dt_CVE)
                If Not IsDBNull(dt_CVE.Rows(0)(0)) Then
                    UltimaClave = dt_CVE.Rows(0)(0)
                End If

                miComando = New SqlCommand("INSERT INTO [Usuarios].[dbo].[PROMO_MOVIMIENTOS] " & _
                                             "([PROM_ID], [PROM_DETALLE], [PROM_FECHA], [CVE_PRODUCTO], [PRODUCTO_UNIDAD], [PRODUCTO_CANTIDAD], [CVE_PROM], [PROM_UNIDAD], [PROM_CANTIDAD], [CONCEPTO_PROV],[EMPRESA], [ALMACEN]) " & _
                                             "VALUES(@PROM_ID, @PROM_DETALLE, @PROM_FECHA, @CVE_PRODUCTO, @PRODUCTO_UNIDAD, @PRODUCTO_CANTIDAD, @CVE_PROM, @PROM_UNIDAD, @PROM_CANTIDAD, @CONCEPTO_PROV, @EMPRESA, @ALMACEN) ", ActualizarConexion)
                miComando.Parameters.AddWithValue("@PROM_ID", UltimaClave + 1)
                miComando.Parameters.AddWithValue("@PROM_DETALLE", dt.Rows(index).Item(0))
                miComando.Parameters.AddWithValue("@PROM_FECHA", Today.Date)
                miComando.Parameters.AddWithValue("@CVE_PRODUCTO", dt.Rows(index).Item(1))
                miComando.Parameters.AddWithValue("@PRODUCTO_UNIDAD", dt.Rows(index).Item(3))
                miComando.Parameters.AddWithValue("@PRODUCTO_CANTIDAD", dt.Rows(index).Item(2))
                miComando.Parameters.AddWithValue("@CVE_PROM", dt.Rows(index).Item(5))
                miComando.Parameters.AddWithValue("@PROM_UNIDAD", dt.Rows(index).Item(7))
                miComando.Parameters.AddWithValue("@PROM_CANTIDAD", dt.Rows(index).Item(6))
                miComando.Parameters.AddWithValue("@CONCEPTO_PROV", dt.Rows(index).Item(9))
                miComando.Parameters.AddWithValue("@EMPRESA", Empresa)
                miComando.Parameters.AddWithValue("@ALMACEN", Almacen)
                miComando.Transaction = transaccion_sql
                miComando.ExecuteNonQuery()

                ' registrar las salidas
                'update MULT
                Dim query_mult_salida As New StringBuilder
                query_mult_salida.Append("UPDATE [SAE60Empre02].[dbo].[MULT02] ")
                query_mult_salida.Append("SET [EXIST] = ISNULL(EXIST,0) - @CANTIDAD ")
                query_mult_salida.Append("WHERE [CVE_ART] = @CVE_ART AND [CVE_ALM] = @CVE_ALM ")
                Dim comando_mult_salida As New SqlCommand(query_mult_salida.ToString, ActualizarConexion)
                comando_mult_salida.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(1))
                comando_mult_salida.Parameters.AddWithValue("@CVE_ALM", Almacen)
                comando_mult_salida.Parameters.AddWithValue("@CANTIDAD", dt.Rows(index).Item(2))
                comando_mult_salida.Transaction = transaccion_sql
                comando_mult_salida.ExecuteNonQuery()

                'update INVE
                Dim query_inve As New StringBuilder
                query_inve.Append("UPDATE [SAE60Empre02].[dbo].[INVE02] ")
                query_inve.Append("SET [EXIST] = EXIST - @CANTIDAD ")
                query_inve.Append("WHERE [CVE_ART] = @CVE_ART ")
                Dim comando_inve_salida As New SqlCommand(query_inve.ToString, ActualizarConexion)
                comando_inve_salida.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(1))
                comando_inve_salida.Parameters.AddWithValue("@CANTIDAD", dt.Rows(index).Item(2))
                comando_inve_salida.Transaction = transaccion_sql
                comando_inve_salida.ExecuteNonQuery()

                'INICIO DE LOS LOTES

                Dim dt_lotes_crear As New DataTable
                dt_lotes_crear.Columns.Clear()
                dt_lotes_crear.Columns.Add("LOTE")
                dt_lotes_crear.Columns.Add("CANT")
                dt_lotes_crear.Columns.Add("PEDIMENTO")
                dt_lotes_crear.Columns.Add("FCHCADUC")
                dt_lotes_crear.Columns.Add("FCHADUANA")
                dt_lotes_crear.Columns.Add("NOM_ADUANA")
                dt_lotes_crear.Columns.Add("CVE_OBS")
                dt_lotes_crear.Columns.Add("CIUDAD")
                dt_lotes_crear.Columns.Add("FRONTERA")
                dt_lotes_crear.Columns.Add("FEC_PROD_LT")
                dt_lotes_crear.Columns.Add("GLN")
                Dim correlativo_lotes As Integer = 0
                dt_lotes_crear.Rows.Clear()
                If dt.Rows(index).Item(4) = "S" Then
                    Dim ds_lotes As New DataSet
                    Dim cantidad As Double = 0, can_insertar As Double = 0

                    Dim query As New StringBuilder
                    query.Append("SELECT LOTE, CVE_ALM, FCHCADUC, CANTIDAD, REG_LTPD,PEDIMENTO,FCHADUANA, ")
                    query.Append("NOM_ADUAN,CVE_OBS,CIUDAD,FRONTERA,FEC_PROD_LT, GLN ")
                    query.Append("FROM [SAE60Empre02].[dbo].[LTPD02] WHERE (STATUS = 'A') AND (CVE_ART = @CVE_ART) AND CVE_ALM = @CVE_ALM")
                    query.Append(" AND (CANTIDAD > 0) AND (FCHCADUC > GETDATE() OR FCHCADUC IS NULL OR FCHCADUC = '') ")
                    query.Append("ORDER BY FCHCADUC ")
                    Dim cmd_select_lotes As New SqlCommand(query.ToString, ActualizarConexion)
                    cmd_select_lotes.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(1))
                    cmd_select_lotes.Parameters.AddWithValue("@CVE_ALM", Almacen)
                    Dim adaptador As New SqlDataAdapter(cmd_select_lotes)
                    cmd_select_lotes.Transaction = transaccion_sql
                    adaptador.Fill(ds_lotes)
                    cantidad = Convert.ToDouble(dt.Rows(index).Item(2))

                    'for de los lotes
                    For index1 As Integer = 0 To ds_lotes.Tables(0).Rows.Count
                        correlativo_lotes = 0
                        'inicio de seleccinar el autonumerico de los enlace lotes
                        Dim ds_correlativo_lotes As New DataSet
                        Dim query_correlativo_lotes As New StringBuilder
                        query_correlativo_lotes.Append("SELECT (ULT_CVE + 1) AS ULT_CVE ")
                        query_correlativo_lotes.Append("FROM [SAE60Empre02].[dbo].[TBLCONTROL02] ")
                        query_correlativo_lotes.Append("WHERE (ID_TABLA = 67)")
                        Dim cmd_select_correlativo_enlace As New SqlCommand(query_correlativo_lotes.ToString, ActualizarConexion)
                        Dim adapenlace As New SqlDataAdapter(cmd_select_correlativo_enlace)
                        cmd_select_correlativo_enlace.Transaction = transaccion_sql
                        adapenlace.Fill(ds_correlativo_lotes)
                        'fin de seleccionar el autonumerico de los enlace lotes
                        correlativo_lotes = Convert.ToInt32(ds_correlativo_lotes.Tables(0).Rows(0)(0))

                        Dim NumeroLote As Integer = 0

                        If (ds_lotes.Tables(0).Rows.Count > 0) Then
                            NumeroLote = ds_lotes.Tables(0).Rows(index1)(3)
                        End If

                        If NumeroLote >= cantidad Then
                            can_insertar = cantidad
                            'hacer el enlace a los lotes
                            Dim query_enlace As New StringBuilder
                            query_enlace.Append("INSERT INTO [SAE60Empre02].[dbo].[ENLACE_LTPD02] ")
                            query_enlace.Append("(E_LTPD,REG_LTPD,CANTIDAD,PXRS) ")
                            query_enlace.Append("VALUES (@E_LTPD,@REG_LTPD,@CANTIDAD,@PXRS) ")
                            Dim cmd_enlace_ltp As New SqlCommand(query_enlace.ToString, ActualizarConexion)
                            cmd_enlace_ltp.Parameters.AddWithValue("@E_LTPD", correlativo_lotes)
                            cmd_enlace_ltp.Parameters.AddWithValue("@REG_LTPD", Convert.ToInt32(ds_lotes.Tables(0).Rows(index1)(4)))
                            cmd_enlace_ltp.Parameters.AddWithValue("@CANTIDAD", cantidad)
                            cmd_enlace_ltp.Parameters.AddWithValue("@PXRS", cantidad)
                            cmd_enlace_ltp.Transaction = transaccion_sql
                            cmd_enlace_ltp.ExecuteNonQuery()

                            Dim new_row As DataRow = dt_lotes_crear.NewRow
                            new_row(0) = Convert.ToString(ds_lotes.Tables(0).Rows(index1)(0))
                            new_row(1) = cantidad
                            new_row(2) = ds_lotes.Tables(0).Rows(index1)(5)
                            new_row(3) = ds_lotes.Tables(0).Rows(index1)(2)
                            new_row(4) = ds_lotes.Tables(0).Rows(index1)(6)
                            new_row(5) = ds_lotes.Tables(0).Rows(index1)(7)
                            new_row(6) = ds_lotes.Tables(0).Rows(index1)(8)
                            new_row(7) = ds_lotes.Tables(0).Rows(index1)(9)
                            new_row(8) = ds_lotes.Tables(0).Rows(index1)(10)
                            new_row(9) = ds_lotes.Tables(0).Rows(index1)(11)
                            new_row(10) = ds_lotes.Tables(0).Rows(index1)(12)
                            dt_lotes_crear.Rows.Add(new_row)

                            'actualizar las existencias de los lotes
                            Dim query_ltpd As New StringBuilder
                            query_ltpd.Append("UPDATE [SAE60Empre02].[dbo].[LTPD02] ")
                            query_ltpd.Append("SET [FCHULTMOV] = @FCHULTMOV ")
                            query_ltpd.Append(",[CANTIDAD] = (CANTIDAD - @NUEVA_CANTIDAD) ")
                            query_ltpd.Append("WHERE [CVE_ART] = @CVE_ART AND [LOTE] = @LOTE AND [CVE_ALM] = @CVE_ALM ")
                            Dim cmd_ltpd As New SqlCommand(query_ltpd.ToString, ActualizarConexion)
                            cmd_ltpd.Parameters.AddWithValue("@FCHULTMOV", Today.Date)
                            cmd_ltpd.Parameters.AddWithValue("@NUEVA_CANTIDAD", cantidad)
                            cmd_ltpd.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(1))
                            cmd_ltpd.Parameters.AddWithValue("@LOTE", Convert.ToString(ds_lotes.Tables(0).Rows(index1)(0)))
                            cmd_ltpd.Parameters.AddWithValue("@CVE_ALM", Almacen)
                            cmd_ltpd.Transaction = transaccion_sql
                            cmd_ltpd.ExecuteNonQuery()
                            index1 = ds_lotes.Tables(0).Rows.Count
                        Else
                            can_insertar = (Convert.ToDouble(NumeroLote) - Convert.ToDouble(dt.Rows(index).Item(2)) + Convert.ToDouble(dt.Rows(index).Item(2)))

                            'hacer el enlace a los lotes
                            Dim query_enlace_ltpd_ins As New StringBuilder
                            query_enlace_ltpd_ins.Append("INSERT INTO [SAE60Empre02].[dbo].[ENLACE_LTPD02] ")
                            query_enlace_ltpd_ins.Append("(E_LTPD,REG_LTPD,CANTIDAD,PXRS) ")
                            query_enlace_ltpd_ins.Append("VALUES (@E_LTPD,@REG_LTPD,@CANTIDAD,@PXRS) ")
                            Dim cmd_enlace_ltpd_ins As New SqlCommand(query_enlace_ltpd_ins.ToString, ActualizarConexion)
                            cmd_enlace_ltpd_ins.Parameters.AddWithValue("@E_LTPD", correlativo_lotes)
                            cmd_enlace_ltpd_ins.Parameters.AddWithValue("@REG_LTPD", Convert.ToInt32(ds_lotes.Tables(0).Rows(index1)(4)))
                            cmd_enlace_ltpd_ins.Parameters.AddWithValue("@CANTIDAD", can_insertar)
                            cmd_enlace_ltpd_ins.Parameters.AddWithValue("@PXRS", can_insertar)
                            cmd_enlace_ltpd_ins.Transaction = transaccion_sql
                            cmd_enlace_ltpd_ins.ExecuteNonQuery()

                            Dim new_row As DataRow = dt_lotes_crear.NewRow
                            new_row(0) = Convert.ToString(ds_lotes.Tables(0).Rows(index1)(0))
                            new_row(1) = can_insertar
                            new_row(2) = ds_lotes.Tables(0).Rows(index1)(5)
                            new_row(3) = ds_lotes.Tables(0).Rows(index1)(2)
                            new_row(4) = ds_lotes.Tables(0).Rows(index1)(6)
                            new_row(5) = ds_lotes.Tables(0).Rows(index1)(7)
                            new_row(6) = ds_lotes.Tables(0).Rows(index1)(8)
                            new_row(7) = ds_lotes.Tables(0).Rows(index1)(9)
                            new_row(8) = ds_lotes.Tables(0).Rows(index1)(10)
                            new_row(9) = ds_lotes.Tables(0).Rows(index1)(11)
                            new_row(10) = ds_lotes.Tables(0).Rows(index1)(12)
                            dt_lotes_crear.Rows.Add(new_row)

                            Dim query_upd_ltpd As New StringBuilder
                            query_upd_ltpd.Append("UPDATE [SAE60Empre02].[dbo].[LTPD02] ")
                            query_upd_ltpd.Append("SET [FCHULTMOV] = @FCHULTMOV ")
                            query_upd_ltpd.Append(",[CANTIDAD] = (CANTIDAD - @NUEVA_CANTIDAD) ")
                            query_upd_ltpd.Append("WHERE [CVE_ART] = @CVE_ART AND [LOTE] = @LOTE AND [CVE_ALM] = @CVE_ALM ")
                            Dim cmd_ltpd_upd As New SqlCommand(query_upd_ltpd.ToString, ActualizarConexion)
                            cmd_ltpd_upd.Parameters.AddWithValue("@FCHULTMOV", Convert.ToDateTime(dt.Rows(0).Item(6)))
                            cmd_ltpd_upd.Parameters.AddWithValue("@NUEVA_CANTIDAD", can_insertar)
                            cmd_ltpd_upd.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(1))
                            cmd_ltpd_upd.Parameters.AddWithValue("@LOTE", Convert.ToString(ds_lotes.Tables(0).Rows(index1)(0)))
                            cmd_ltpd_upd.Parameters.AddWithValue("@CVE_ALM", Almacen)
                            cmd_ltpd_upd.Transaction = transaccion_sql
                            cmd_ltpd_upd.ExecuteNonQuery()
                            cantidad = cantidad - Convert.ToInt32(ds_lotes.Tables(0).Rows(index1)(3))
                            can_insertar = cantidad
                        End If
                    Next

                    'actualizar los correlativos de los lotes
                    Dim query_actualiza_lotes As New StringBuilder
                    query_actualiza_lotes.Append("UPDATE [SAE60Empre02].[dbo].[TBLCONTROL02] ")
                    query_actualiza_lotes.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                    query_actualiza_lotes.Append("WHERE (ID_TABLA = 67) ")
                    Dim cmd_upd_correlativo_lot As New SqlCommand(query_actualiza_lotes.ToString, ActualizarConexion)
                    cmd_upd_correlativo_lot.Transaction = transaccion_sql
                    cmd_upd_correlativo_lot.ExecuteNonQuery()

                End If
                'FIN DE LOS LOTES

                'select Datos INVE
                Dim query_datos_inve As New StringBuilder
                query_datos_inve.Append("SELECT ISNULL(COSTO_PROM,0), ISNULL(UNI_MED,'') ")
                query_datos_inve.Append("FROM [SAE60Empre02].[dbo].[INVE02] ")
                query_datos_inve.Append("WHERE CVE_ART = @CVE_ART")
                Dim comando_datos_inve As New SqlCommand(query_datos_inve.ToString, ActualizarConexion)
                comando_datos_inve.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(5))
                comando_datos_inve.Transaction = transaccion_sql
                Dim adaptador_datos_inve As New SqlDataAdapter(comando_datos_inve)
                Dim dt_datos_inve As New DataTable
                adaptador_datos_inve.Fill(dt_datos_inve)

                'insert MINVE
                Dim query_minve As New StringBuilder
                query_minve.Append("INSERT INTO [SAE60Empre02].[dbo].[MINVE02] ")
                query_minve.Append("   ([CVE_ART],[ALMACEN],[NUM_MOV],[CVE_CPTO],[FECHA_DOCU],[TIPO_DOC],[REFER], ")
                query_minve.Append("    [CANT],[CANT_COST],[PRECIO],[COSTO], ")
                query_minve.Append("    [REG_SERIE],[UNI_VENTA],[E_LTPD],[EXIST_G],[EXISTENCIA],[TIPO_PROD],[FACTOR_CON], ")
                query_minve.Append("    [FECHAELAB],[CVE_FOLIO],[SIGNO],[COSTEADO],[COSTO_PROM_INI], ")
                query_minve.Append("    [COSTO_PROM_FIN],[COSTO_PROM_GRAL],[DESDE_INVE],[MOV_ENLAZADO]) ")
                query_minve.Append(" VALUES ")
                query_minve.Append("   (@CVE_ART,@ALMACEN,(SELECT ULT_CVE+1 FROM [SAE60Empre02].[dbo].[TBLCONTROL02] WHERE (ID_TABLA = 44)), ")
                query_minve.Append("    @CVE_CPTO,@FECHA_DOCU,'M',@REFER,@CANT,0,0,@COSTO,0, ")
                query_minve.Append("    @UNI_VENTA,@E_LTPD, ((SELECT ISNULL(EXIST,0) FROM [SAE60Empre02].[dbo].[INVE02] WHERE CVE_ART = @CVE_ART)), ")
                query_minve.Append("    ((SELECT EXIST FROM [SAE60Empre02].[dbo].[MULT02] WHERE (CVE_ART = @CVE_ART) AND CVE_ALM = @ALMACEN)), 'P',1, ")
                query_minve.Append("    @FECHAELAB, (SELECT ULT_CVE+1 FROM [SAE60Empre02].[dbo].[TBLCONTROL02] WHERE (ID_TABLA = 32)), -1, 'S', @COSTO_PROM_INI, ")
                query_minve.Append("    @COSTO_PROM_FIN, @COSTO_PROM_GRAL, 'S', 0) ")

                Dim comando_minve_salida As New SqlCommand(query_minve.ToString, ActualizarConexion)
                comando_minve_salida.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(1))
                comando_minve_salida.Parameters.AddWithValue("@ALMACEN", Almacen)
                comando_minve_salida.Parameters.AddWithValue("@CVE_CPTO", 63)
                comando_minve_salida.Parameters.AddWithValue("@FECHA_DOCU", Today.Date)
                comando_minve_salida.Parameters.AddWithValue("@REFER", "SP" & Today.Day.ToString & Today.Month.ToString & Today.Year.ToString & "-" & UltimaClave + 1)
                comando_minve_salida.Parameters.AddWithValue("@CANT", dt.Rows(index).Item(2))
                comando_minve_salida.Parameters.AddWithValue("@COSTO", 0)
                comando_minve_salida.Parameters.AddWithValue("@UNI_VENTA", dt_datos_inve.Rows(0)(1))
                comando_minve_salida.Parameters.AddWithValue("@E_LTPD", correlativo_lotes)
                comando_minve_salida.Parameters.AddWithValue("@FECHAELAB", Today.Date)
                comando_minve_salida.Parameters.AddWithValue("@COSTO_PROM_INI", 0)
                comando_minve_salida.Parameters.AddWithValue("@COSTO_PROM_FIN", 0)
                comando_minve_salida.Parameters.AddWithValue("@COSTO_PROM_GRAL", 0)
                comando_minve_salida.Transaction = transaccion_sql
                comando_minve_salida.ExecuteNonQuery()

                'update num mov minve
                Dim query_control_num_mov As New StringBuilder
                query_control_num_mov.Append("UPDATE [SAE60Empre02].[dbo].[TBLCONTROL02] ")
                query_control_num_mov.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                query_control_num_mov.Append("WHERE [ID_TABLA] = 44 ")
                Dim comando_control_num_mov As New SqlCommand(query_control_num_mov.ToString, ActualizarConexion)
                comando_control_num_mov.Transaction = transaccion_sql
                comando_control_num_mov.ExecuteNonQuery()

                'FIN DE REGISTRAR LAS SALIDAS

                'INICIO REGISTRAR LAS ENTRADAS
                'update MULT
                Dim query_mult_entrada As New StringBuilder
                query_mult_entrada.Append("UPDATE [SAE60Empre02].[dbo].[MULT02] ")
                query_mult_entrada.Append("SET [EXIST] = ISNULL(EXIST,0) + @CANTIDAD ")
                query_mult_entrada.Append("WHERE [CVE_ART] = @CVE_ART AND [CVE_ALM] = @CVE_ALM ")
                Dim comando_mult_entrada As New SqlCommand(query_mult_entrada.ToString, ActualizarConexion)
                comando_mult_entrada.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(5))
                comando_mult_entrada.Parameters.AddWithValue("@CVE_ALM", Almacen)
                comando_mult_entrada.Parameters.AddWithValue("@CANTIDAD", dt.Rows(index).Item(6))
                comando_mult_entrada.Transaction = transaccion_sql
                comando_mult_entrada.ExecuteNonQuery()

                'update INVE
                Dim query_inve_entrada As New StringBuilder
                query_inve_entrada.Append("UPDATE [SAE60Empre02].[dbo].[INVE02] ")
                query_inve_entrada.Append("SET [EXIST] = EXIST + @CANTIDAD ")
                query_inve_entrada.Append("WHERE [CVE_ART] = @CVE_ART ")
                Dim comando_inve_entrada As New SqlCommand(query_inve_entrada.ToString, ActualizarConexion)
                comando_inve_entrada.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(5))
                comando_inve_entrada.Parameters.AddWithValue("@CANTIDAD", dt.Rows(index).Item(6))
                comando_inve_entrada.Transaction = transaccion_sql
                comando_inve_entrada.ExecuteNonQuery()


                'INICIO DE LOS LOTES
                Dim correlativo_lotes_ENTRADA As Integer = 0
                If dt.Rows(index).Item(8) = "S" Then
                    For index2 As Integer = 0 To dt_lotes_crear.Rows.Count - 1
                        correlativo_lotes_ENTRADA = 0
                        'inicio de seleccinar el autonumerico de los enlace lotes
                        Dim ds_correlativo_lotes As New DataSet
                        Dim query_correlativo_lotes As New StringBuilder
                        query_correlativo_lotes.Append("SELECT (ULT_CVE + 1) AS ULT_CVE ")
                        query_correlativo_lotes.Append("FROM [SAE60Empre02].[dbo].[TBLCONTROL02] ")
                        query_correlativo_lotes.Append("WHERE (ID_TABLA = 67)")
                        Dim cmd_select_correlativo_enlace As New SqlCommand(query_correlativo_lotes.ToString, ActualizarConexion)
                        Dim adapenlace As New SqlDataAdapter(cmd_select_correlativo_enlace)
                        cmd_select_correlativo_enlace.Transaction = transaccion_sql
                        adapenlace.Fill(ds_correlativo_lotes)
                        'fin de seleccionar el autonumerico de los enlace lotes
                        correlativo_lotes_ENTRADA = Convert.ToInt32(ds_correlativo_lotes.Tables(0).Rows(0)(0))

                        Dim query_valida_lote As New StringBuilder
                        query_valida_lote.Append("SELECT CVE_ART,LOTE,REG_LTPD ")
                        query_valida_lote.Append("FROM [SAE60Empre02].[dbo].[LTPD02] ")
                        query_valida_lote.Append("WHERE LOTE = @LOTE AND CVE_ALM = @ALMACEN AND CVE_ART = @CVE_ART ")
                        Dim cmd_valida_lote As New SqlCommand(query_valida_lote.ToString, ActualizarConexion)
                        cmd_valida_lote.Parameters.AddWithValue("@LOTE", dt_lotes_crear.Rows(index2)(0))
                        cmd_valida_lote.Parameters.AddWithValue("@ALMACEN", Almacen)
                        cmd_valida_lote.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(5))
                        cmd_valida_lote.Transaction = transaccion_sql
                        Dim adaptador_valida_lote As New SqlDataAdapter(cmd_valida_lote)
                        Dim dt_valida_lote As New DataTable
                        adaptador_valida_lote.Fill(dt_valida_lote)

                        If dt_valida_lote.Rows.Count > 0 Then
                            'si el lote existe
                            'hacer el enlace a los lotes
                            Dim query_enlace_ltpd_ins_entrada As New StringBuilder
                            query_enlace_ltpd_ins_entrada.Append("INSERT INTO [SAE60Empre02].[dbo].[ENLACE_LTPD02] ")
                            query_enlace_ltpd_ins_entrada.Append("(E_LTPD,REG_LTPD,CANTIDAD,PXRS) ")
                            query_enlace_ltpd_ins_entrada.Append("VALUES (@E_LTPD,@REG_LTPD,@CANTIDAD,@PXRS) ")
                            Dim cmd_enlace_ltpd_ins_entrada As New SqlCommand(query_enlace_ltpd_ins_entrada.ToString, ActualizarConexion)
                            cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@E_LTPD", correlativo_lotes_ENTRADA)
                            cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@REG_LTPD", dt_valida_lote.Rows(0)(2))
                            cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@CANTIDAD", dt_lotes_crear.Rows(index2)(1))
                            cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@PXRS", dt_lotes_crear.Rows(index2)(1))
                            cmd_enlace_ltpd_ins_entrada.Transaction = transaccion_sql
                            cmd_enlace_ltpd_ins_entrada.ExecuteNonQuery()

                            Dim query_upd_ltpd As New StringBuilder
                            query_upd_ltpd.Append("UPDATE [SAE60Empre02].[dbo].[LTPD02] ")
                            query_upd_ltpd.Append("SET [FCHULTMOV] = @FCHULTMOV ")
                            query_upd_ltpd.Append(",[CANTIDAD] = (CANTIDAD + @NUEVA_CANTIDAD) ")
                            query_upd_ltpd.Append("WHERE [CVE_ART] = @CVE_ART AND [LOTE] = @LOTE AND [CVE_ALM] = @CVE_ALM ")
                            Dim cmd_ltpd_upd As New SqlCommand(query_upd_ltpd.ToString, ActualizarConexion)
                            cmd_ltpd_upd.Parameters.AddWithValue("@FCHULTMOV", Today.Date)
                            cmd_ltpd_upd.Parameters.AddWithValue("@NUEVA_CANTIDAD", dt_lotes_crear.Rows(index2)(1))
                            cmd_ltpd_upd.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(5))
                            cmd_ltpd_upd.Parameters.AddWithValue("@LOTE", dt_valida_lote.Rows(0)(1))
                            cmd_ltpd_upd.Parameters.AddWithValue("@CVE_ALM", Almacen)
                            cmd_ltpd_upd.Transaction = transaccion_sql
                            cmd_ltpd_upd.ExecuteNonQuery()
                        Else
                            'si el lote NO existe
                            Dim nuevo_reg_ltpd As Integer = 0
                            'inicio de seleccinar el autonumerico de los lotes
                            Dim ds_nuevo_reg_ltpd As New DataSet
                            Dim query_nuevo_reg_ltpd2 As New StringBuilder
                            query_nuevo_reg_ltpd2.Append("SELECT (ULT_CVE + 1) AS ULT_CVE ")
                            query_nuevo_reg_ltpd2.Append("FROM [SAE60Empre02].[dbo].[TBLCONTROL02] ")
                            query_nuevo_reg_ltpd2.Append("WHERE (ID_TABLA = 48)")
                            Dim cmd_select_nuevo_reg_ltpd2 As New SqlCommand(query_nuevo_reg_ltpd2.ToString, ActualizarConexion)
                            Dim adapnuevo_reg_ltpd As New SqlDataAdapter(cmd_select_nuevo_reg_ltpd2)
                            cmd_select_nuevo_reg_ltpd2.Transaction = transaccion_sql
                            adapnuevo_reg_ltpd.Fill(ds_nuevo_reg_ltpd)
                            'fin de seleccionar el autonumerico de los lotes
                            nuevo_reg_ltpd = Convert.ToInt32(ds_nuevo_reg_ltpd.Tables(0).Rows(0)(0))

                            'hacer el enlace a los lotes
                            Dim query_enlace_ltpd_ins_entrada As New StringBuilder
                            query_enlace_ltpd_ins_entrada.Append("INSERT INTO [SAE60Empre02].[dbo].[ENLACE_LTPD02] ")
                            query_enlace_ltpd_ins_entrada.Append("(E_LTPD,REG_LTPD,CANTIDAD,PXRS) ")
                            query_enlace_ltpd_ins_entrada.Append("VALUES (@E_LTPD,@REG_LTPD,@CANTIDAD,@PXRS) ")
                            Dim cmd_enlace_ltpd_ins_entrada As New SqlCommand(query_enlace_ltpd_ins_entrada.ToString, ActualizarConexion)
                            cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@E_LTPD", correlativo_lotes_ENTRADA)
                            cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@REG_LTPD", nuevo_reg_ltpd)
                            cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@CANTIDAD", dt_lotes_crear.Rows(index2)(1))
                            cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@PXRS", dt_lotes_crear.Rows(index2)(1))
                            cmd_enlace_ltpd_ins_entrada.Transaction = transaccion_sql
                            cmd_enlace_ltpd_ins_entrada.ExecuteNonQuery()
                            'insertar nuevo lote
                            Dim query_insertar_nuevo_lote As New StringBuilder
                            query_insertar_nuevo_lote.Append("INSERT INTO [SAE60Empre02].[dbo].[LTPD02] ")
                            query_insertar_nuevo_lote.Append("([CVE_ART],[LOTE],[PEDIMENTO],[CVE_ALM],[FCHCADUC],[FCHADUANA] ")
                            query_insertar_nuevo_lote.Append(",[FCHULTMOV],[NOM_ADUAN],[CANTIDAD],[REG_LTPD],[CVE_OBS] ")
                            query_insertar_nuevo_lote.Append(",[CIUDAD],[FRONTERA],[FEC_PROD_LT],[GLN],[STATUS]) ")
                            query_insertar_nuevo_lote.Append("VALUES ")
                            query_insertar_nuevo_lote.Append("(@CVE_ART,@LOTE,@PEDIMENTO,@CVE_ALM,@FCHCADUC,@FCHADUANA ")
                            query_insertar_nuevo_lote.Append(",@FCHULTMOV,@NOM_ADUAN,@CANTIDAD,@REG_LTPD,@CVE_OBS,@CIUDAD ")
                            query_insertar_nuevo_lote.Append(",@FRONTERA,@FEC_PROD_LT,@GLN,@STATUS)")
                            Dim cmd_insertar_nuevo_lote As New SqlCommand(query_insertar_nuevo_lote.ToString, ActualizarConexion)
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(5))
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@LOTE", dt_lotes_crear.Rows(index2)(0))
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@PEDIMENTO", dt_lotes_crear.Rows(index2)(2))
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@CVE_ALM", Almacen)

                            If IsDBNull(dt_lotes_crear.Rows(index2)(3)) = True Then
                                cmd_insertar_nuevo_lote.Parameters.AddWithValue("@FCHCADUC", DBNull.Value)
                            Else
                                cmd_insertar_nuevo_lote.Parameters.AddWithValue("@FCHCADUC", Convert.ToDateTime(dt_lotes_crear.Rows(index2)(3)))
                            End If

                            If IsDBNull(dt_lotes_crear.Rows(index2)(4)) = True Then
                                cmd_insertar_nuevo_lote.Parameters.AddWithValue("@FCHADUANA", DBNull.Value)
                            Else
                                cmd_insertar_nuevo_lote.Parameters.AddWithValue("@FCHADUANA", Convert.ToDateTime(dt_lotes_crear.Rows(index2)(4)))
                            End If

                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@FCHULTMOV", Today.Date)
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@NOM_ADUAN", dt_lotes_crear.Rows(index2)(5))
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@CANTIDAD", dt_lotes_crear.Rows(index2)(1))
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@REG_LTPD", nuevo_reg_ltpd)
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@CVE_OBS", dt_lotes_crear.Rows(index2)(6))
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@CIUDAD", dt_lotes_crear.Rows(index2)(7))
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@FRONTERA", dt_lotes_crear.Rows(index2)(8))
                            If IsDBNull(dt_lotes_crear.Rows(index2)(9)) = True Then
                                cmd_insertar_nuevo_lote.Parameters.AddWithValue("@FEC_PROD_LT", DBNull.Value)
                            Else
                                cmd_insertar_nuevo_lote.Parameters.AddWithValue("@FEC_PROD_LT", Convert.ToDateTime(dt_lotes_crear.Rows(index2)(9)))
                            End If
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@GLN", dt_lotes_crear.Rows(index2)(10))
                            cmd_insertar_nuevo_lote.Parameters.AddWithValue("@STATUS", "A")
                            cmd_insertar_nuevo_lote.Transaction = transaccion_sql
                            cmd_insertar_nuevo_lote.ExecuteNonQuery()

                            'actualizar el autonumerico de lotes
                            Dim query_actualiza_autonumerico_ltpd As New StringBuilder
                            query_actualiza_autonumerico_ltpd.Append("UPDATE [SAE60Empre02].[dbo].[TBLCONTROL02] ")
                            query_actualiza_autonumerico_ltpd.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                            query_actualiza_autonumerico_ltpd.Append("WHERE (ID_TABLA = 48) ")
                            Dim cmd_upd_autonumerico_ltpd As New SqlCommand(query_actualiza_autonumerico_ltpd.ToString, ActualizarConexion)
                            cmd_upd_autonumerico_ltpd.Transaction = transaccion_sql
                            cmd_upd_autonumerico_ltpd.ExecuteNonQuery()

                        End If
                    Next

                    'actualizar los correlativos de enlace de lotes
                    Dim query_actualiza_lotes As New StringBuilder
                    query_actualiza_lotes.Append("UPDATE [SAE60Empre02].[dbo].[TBLCONTROL02] ")
                    query_actualiza_lotes.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                    query_actualiza_lotes.Append("WHERE (ID_TABLA = 67) ")
                    Dim cmd_upd_correlativo_lot As New SqlCommand(query_actualiza_lotes.ToString, ActualizarConexion)
                    cmd_upd_correlativo_lot.Transaction = transaccion_sql
                    cmd_upd_correlativo_lot.ExecuteNonQuery()
                End If

                'insert MINVE
                Dim query_minve_entrada As New StringBuilder
                query_minve_entrada.Append("INSERT INTO [SAE60Empre02].[dbo].[MINVE02] ")
                query_minve_entrada.Append("   ([CVE_ART],[ALMACEN],[NUM_MOV],[CVE_CPTO],[FECHA_DOCU],[TIPO_DOC],[REFER], ")
                query_minve_entrada.Append("    [CANT],[CANT_COST],[PRECIO],[COSTO], ")
                query_minve_entrada.Append("    [REG_SERIE],[UNI_VENTA],[E_LTPD],[EXIST_G],[EXISTENCIA],[TIPO_PROD],[FACTOR_CON], ")
                query_minve_entrada.Append("    [FECHAELAB],[CVE_FOLIO],[SIGNO],[COSTEADO],[COSTO_PROM_INI], ")
                query_minve_entrada.Append("    [COSTO_PROM_FIN],[COSTO_PROM_GRAL],[DESDE_INVE],[MOV_ENLAZADO]) ")
                query_minve_entrada.Append("VALUES ")
                query_minve_entrada.Append("   (@CVE_ART,@ALMACEN,(SELECT ULT_CVE+1 FROM [SAE60Empre02].[dbo].[TBLCONTROL02] WHERE (ID_TABLA = 44)), ")
                query_minve_entrada.Append("    @CVE_CPTO,@FECHA_DOCU,'M',@REFER,@CANT,0,0,@COSTO,0, ")
                query_minve_entrada.Append("    @UNI_VENTA,@E_LTPD, ((SELECT ISNULL(EXIST,0) FROM [SAE60Empre02].[dbo].[INVE02] WHERE CVE_ART = @CVE_ART)), ")
                query_minve_entrada.Append("    ((SELECT EXIST FROM [SAE60Empre02].[dbo].[MULT02] WHERE (CVE_ART = @CVE_ART) AND CVE_ALM = @ALMACEN)), 'P',1, ")
                query_minve_entrada.Append("    @FECHAELAB, (SELECT ULT_CVE+1 FROM [SAE60Empre02].[dbo].[TBLCONTROL02] WHERE (ID_TABLA = 32)), 1, 'S', @COSTO_PROM_INI, ")
                query_minve_entrada.Append("    @COSTO_PROM_FIN, @COSTO_PROM_GRAL, 'S', (SELECT ULT_CVE FROM [SAE60Empre02].[dbo].[TBLCONTROL02] WHERE (ID_TABLA = 44))) ")
                Dim comando_minve_entrada As New SqlCommand(query_minve_entrada.ToString, ActualizarConexion)
                comando_minve_entrada.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(5))
                comando_minve_entrada.Parameters.AddWithValue("@ALMACEN", Almacen)
                comando_minve_entrada.Parameters.AddWithValue("@CVE_CPTO", 11)
                comando_minve_entrada.Parameters.AddWithValue("@FECHA_DOCU", Today.Date)
                comando_minve_entrada.Parameters.AddWithValue("@REFER", "EP" & Today.Day.ToString & Today.Month.ToString & Today.Year.ToString & "-" & UltimaClave + 1)

                comando_minve_entrada.Parameters.AddWithValue("@CANT", dt.Rows(index).Item(6))
                comando_minve_entrada.Parameters.AddWithValue("@COSTO", dt_datos_inve.Rows(0)(0))
                comando_minve_entrada.Parameters.AddWithValue("@UNI_VENTA", dt_datos_inve.Rows(0)(1))
                comando_minve_entrada.Parameters.AddWithValue("@E_LTPD", correlativo_lotes_ENTRADA)
                comando_minve_entrada.Parameters.AddWithValue("@FECHAELAB", Today.Date)
                comando_minve_entrada.Parameters.AddWithValue("@COSTO_PROM_INI", dt_datos_inve.Rows(0)(0))
                comando_minve_entrada.Parameters.AddWithValue("@COSTO_PROM_FIN", dt_datos_inve.Rows(0)(0))
                comando_minve_entrada.Parameters.AddWithValue("@COSTO_PROM_GRAL", dt_datos_inve.Rows(0)(0))
                comando_minve_entrada.Transaction = transaccion_sql
                comando_minve_entrada.ExecuteNonQuery()

                'update num mov minve
                Dim query_control_num_mov_entrada As New StringBuilder
                query_control_num_mov_entrada.Append("UPDATE [SAE60Empre02].[dbo].[TBLCONTROL02] ")
                query_control_num_mov_entrada.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                query_control_num_mov_entrada.Append("WHERE [ID_TABLA] = 44 ")
                Dim comando_control_num_mov_entrada As New SqlCommand(query_control_num_mov_entrada.ToString, ActualizarConexion)
                comando_control_num_mov_entrada.Transaction = transaccion_sql
                comando_control_num_mov_entrada.ExecuteNonQuery()
            Next
            'FIN DE MOVIMIENTOS DEL SAE

            'update cve_folio minve
            Dim query_control_folio As New StringBuilder
            query_control_folio.Append("UPDATE [SAE60Empre02].[dbo].[TBLCONTROL02] ")
            query_control_folio.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
            query_control_folio.Append("WHERE ([ID_TABLA] = 32) ")
            Dim comando_control_folio As New SqlCommand(query_control_folio.ToString, ActualizarConexion)
            comando_control_folio.Transaction = transaccion_sql
            comando_control_folio.ExecuteNonQuery()

            Dim conexion_bita As New cls_bitacora_reporteador
            conexion_bita.RegistraBitacora(Now, usuario, "Realizó Traslado de Producto a Promoción en SR AGRO", "ALMACEN", _
                                      "Fecha: " & DateTime.Now & " Cantidad de Productos: " & dt.Rows.Count & " Almacén:" & Almacen)

            transaccion_sql.Commit()
            ActualizarConexion.Close()
            Return "correcto"

        Catch ex As Exception
            Dim tamaño As Integer = Convert.ToString(ex.StackTrace).Length
            Dim posicion As Integer = InStrRev(Convert.ToString(ex.StackTrace), "línea") - 1
            Dim inicial As Integer = tamaño - posicion
            Dim linea_error As String = Convert.ToString(ex.StackTrace).Substring(tamaño - inicial, inicial)
            transaccion_sql.Rollback()
            ActualizarConexion.Close()
            Return ex.Message & " " & linea_error
        End Try
    End Function

    Public Function LlenaLotes(ByVal Almacen As Integer, ByVal Cadena As String)

        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT dbo.INVE05.CVE_ART as 'CLAVE', dbo.INVE05.DESCR AS 'DESCRIPCION', dbo.MULT05.EXIST AS 'EXISTENCIA REAL', (SELECT ISNULL(SUM(CANTIDAD), 0) AS Expr1 FROM dbo.LTPD05  " & _
        " WHERE (CVE_ART = dbo.INVE05.CVE_ART) AND (CVE_ALM = @Almacen) AND (STATUS = 'A')) AS 'EXISTENCIA LOTE' " & _
        " FROM dbo.INVE05 INNER JOIN dbo.MULT05 ON dbo.INVE05.CVE_ART = dbo.MULT05.CVE_ART WHERE (dbo.MULT05.CVE_ALM = @Almacen) AND dbo.INVE05.CVE_ART IN ( " & Cadena & ") ", ActualizarConexion)
        ActualizarConexion.Open()

        miComando.Parameters.AddWithValue("@Almacen", Almacen)

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

    Public Function LlenaLotesDIMOSA(ByVal Almacen As Integer, ByVal Cadena As String)

        Dim ActualizarConexion As New SqlConnection(ConexionDIMOSA.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT dbo.INVE06.CVE_ART as 'CLAVE', dbo.INVE06.DESCR AS 'DESCRIPCION', dbo.MULT06.EXIST AS 'EXISTENCIA REAL', (SELECT ISNULL(SUM(CANTIDAD), 0) AS Expr1 FROM dbo.LTPD06  " & _
        " WHERE (CVE_ART = dbo.INVE06.CVE_ART) AND (CVE_ALM = @Almacen) AND (STATUS = 'A')) AS 'EXISTENCIA LOTE' " & _
        " FROM dbo.INVE06 INNER JOIN dbo.MULT06 ON dbo.INVE06.CVE_ART = dbo.MULT06.CVE_ART WHERE (dbo.MULT06.CVE_ALM = @Almacen) AND dbo.INVE06.CVE_ART IN ( " & Cadena & ") ", ActualizarConexion)
        ActualizarConexion.Open()

        miComando.Parameters.AddWithValue("@Almacen", Almacen)

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

    Public Function LlenaLotesAgro(ByVal Almacen As Integer, ByVal Cadena As String)

        Dim ActualizarConexion As New SqlConnection(ConexionAgro.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT dbo.INVE02.CVE_ART as 'CLAVE', dbo.INVE02.DESCR AS 'DESCRIPCION', dbo.MULT02.EXIST AS 'EXISTENCIA REAL', (SELECT ISNULL(SUM(CANTIDAD), 0) AS Expr1 FROM dbo.LTPD02  " & _
        " WHERE (CVE_ART = dbo.INVE02.CVE_ART) AND (CVE_ALM = @Almacen) AND (STATUS = 'A')) AS 'EXISTENCIA LOTE' " & _
        " FROM dbo.INVE02 INNER JOIN dbo.MULT02 ON dbo.INVE02.CVE_ART = dbo.MULT02.CVE_ART WHERE (dbo.MULT02.CVE_ALM = @Almacen) AND dbo.INVE02.CVE_ART IN ( " & Cadena & ") ", ActualizarConexion)
        ActualizarConexion.Open()

        miComando.Parameters.AddWithValue("@Almacen", Almacen)

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
