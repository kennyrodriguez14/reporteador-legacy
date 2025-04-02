Imports System.Data.SqlClient
Imports System.Text
Public Class ClsConsignacionesFlota

    Dim CONSUMO As New ClsConexion_Flota
    Dim Conexion As New clsConexion

    Public Function remision_encabezado(ByVal REMITE As Integer, ByVal INICIO As Date, ByVal FIN As Date)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("dsr_consignaciones_encabezado_flota", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.AddWithValue("@REMITE", SqlDbType.Int).Value = REMITE
        miComando.Parameters.AddWithValue("@INICIO", SqlDbType.Date).Value = INICIO
        miComando.Parameters.AddWithValue("@FIN", SqlDbType.Date).Value = FIN

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

    Public Function FILTRARPENDIENTES(ByVal Almacen As Integer, ByVal Empresa As String, ByVal Usuario As Integer)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("dsr_consignaciones_encabezado_pendiente_flota", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.AddWithValue("@ALMACENRECIB", SqlDbType.Int).Value = Almacen
        miComando.Parameters.AddWithValue("@EMPRESA", SqlDbType.Int).Value = Empresa
        miComando.Parameters.AddWithValue("@USUARIO", SqlDbType.Int).Value = Usuario

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

    Public Function NUEVASOLICITUDPROD(ByVal dt As DataTable, ByVal dt2 As DataTable, ByVal otro_transportista As Boolean, _
                             ByVal otro_vehiculo As Boolean, ByVal new_transportista As String, ByVal rtn_otro_trans As String, _
                                    ByVal marca_vehiculo As String, ByVal placa_vehiculo As String, ByVal usuario As String, ByVal Viajes As Integer, ByVal ViajesR As Decimal, ByVal Cliente As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim transaccion_sql As SqlTransaction
        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction
        Try
            Dim miComando As New SqlCommand("INSERT INTO [Usuarios].[dbo].[GUIA_REMISION_ENCABEZADO_SANRAFAEL] " & _
                                                    " ([ID_REMISION],[REMITE],[DESTINO],[TRASPORTISTA],[VEHICULO], " & _
                                                    " [MOTIVO], [FECHA_INICIO],[FECHA_FIN],[CAI],[RANGO],[FECHA_LIM_IMP],[PESO], " & _
                                                    " [NOMBRE_TRANSP_EXT],[RTN_TRANSP_EXT],[MARCA_EXT],[NPLACA_EXT], [REMESTADO], [MTVOSALIDA], [MTVOENTRADA], [TIPOREM], [CANTVIAJES], [CANTVIAJESREC], [CONSIG_CLIENTE] ) " & _
                                                    "VALUES(@ID_REMISION,@REMITE,@DESTINO,@TRASPORTISTA,@VEHICULO, " & _
                                                    " @MOTIVO,@FECHA_INICIO,@FECHA_FIN,@CAI,@RANGO,@FECHA_LIM_IMP,@PESO,@NOMBRE_TRANSP_EXT " & _
                                                    " ,@RTN_TRANSP_EXT, @MARCA_EXT, @NPLACA_EXT, 'CONSIGNACION PEND', @MTVOSALIDA, @MTVOENTRADA, 'CONSIGNACION', @CANTVIAJES, @CANTVIAJESREC, @CONSIG_CLIENTE) ", ActualizarConexion)

            miComando.Parameters.AddWithValue("@ID_REMISION", dt.Rows(0).Item(0))
            miComando.Parameters.AddWithValue("@REMITE", dt.Rows(0).Item(1))
            miComando.Parameters.AddWithValue("@DESTINO", dt.Rows(0).Item(2))

            If otro_transportista = True Then
                miComando.Parameters.AddWithValue("@TRASPORTISTA", 0)
                miComando.Parameters.AddWithValue("@NOMBRE_TRANSP_EXT", new_transportista)
                miComando.Parameters.AddWithValue("@RTN_TRANSP_EXT", rtn_otro_trans)
            Else
                miComando.Parameters.AddWithValue("@TRASPORTISTA", dt.Rows(0).Item(3))
                miComando.Parameters.AddWithValue("@NOMBRE_TRANSP_EXT", DBNull.Value)
                miComando.Parameters.AddWithValue("@RTN_TRANSP_EXT", DBNull.Value)
            End If

            If otro_vehiculo = True Then
                miComando.Parameters.AddWithValue("@VEHICULO", 0)
                miComando.Parameters.AddWithValue("@MARCA_EXT", marca_vehiculo)
                miComando.Parameters.AddWithValue("@NPLACA_EXT", placa_vehiculo)
            Else
                miComando.Parameters.AddWithValue("@VEHICULO", dt.Rows(0).Item(4))
                miComando.Parameters.AddWithValue("@MARCA_EXT", DBNull.Value)
                miComando.Parameters.AddWithValue("@NPLACA_EXT", DBNull.Value)
            End If

            miComando.Parameters.AddWithValue("@MOTIVO", dt.Rows(0).Item(5))
            miComando.Parameters.AddWithValue("@FECHA_INICIO", Convert.ToDateTime(dt.Rows(0).Item(6)))
            miComando.Parameters.AddWithValue("@FECHA_FIN", Convert.ToDateTime(dt.Rows(0).Item(7)))
            miComando.Parameters.AddWithValue("@CAI", dt.Rows(0).Item(8))
            miComando.Parameters.AddWithValue("@RANGO", dt.Rows(0).Item(9))
            miComando.Parameters.AddWithValue("@FECHA_LIM_IMP", Convert.ToDateTime(dt.Rows(0).Item(10)))
            miComando.Parameters.AddWithValue("@PESO", Convert.ToDouble(dt.Rows(0).Item(11)))

            miComando.Parameters.AddWithValue("@MTVOSALIDA", Convert.ToDouble(dt.Rows(0).Item(12)))
            miComando.Parameters.AddWithValue("@MTVOENTRADA", Convert.ToDouble(dt.Rows(0).Item(13)))

            miComando.Parameters.AddWithValue("@CANTVIAJES", Viajes)
            miComando.Parameters.AddWithValue("@CANTVIAJESREC", ViajesR)
            miComando.Parameters.AddWithValue("@CONSIG_CLIENTE", Cliente)

            miComando.Transaction = transaccion_sql
            miComando.ExecuteNonQuery()


            For index As Integer = 0 To dt2.Rows.Count - 1
                miComando = New SqlCommand("INSERT INTO [Usuarios].[dbo].[GUIA_REMISION_PARTIDAS_SANRAFAEL] " & _
                                             "([ID_REMISION],[NUM_PART],[REMITE],[CANTIDAD],[CODIGO],[DESCRIPCION],[PESO_UNIT],[PESO_TOTAL],[CONLOTE]) " & _
                                             "VALUES(@ID_REMISION, @NUM_PART, @REMITE, @CANTIDAD, @CODIGO, @DESCRIPCION,@PESO_UNIT,@PESO_TOTAL, @CONLOTE) ", ActualizarConexion)
                miComando.Parameters.AddWithValue("@ID_REMISION", dt.Rows(0).Item(0))
                miComando.Parameters.AddWithValue("@REMITE", dt.Rows(0).Item(1))
                miComando.Parameters.AddWithValue("@NUM_PART", index + 1)
                miComando.Parameters.AddWithValue("@CANTIDAD", dt2.Rows(index).Item(0))
                miComando.Parameters.AddWithValue("@CODIGO", dt2.Rows(index).Item(2))
                miComando.Parameters.AddWithValue("@DESCRIPCION", dt2.Rows(index).Item(3))
                miComando.Parameters.AddWithValue("@PESO_UNIT", dt2.Rows(index).Item(4))
                miComando.Parameters.AddWithValue("@PESO_TOTAL", dt2.Rows(index).Item(5))
                miComando.Parameters.AddWithValue("@CONLOTE", dt2.Rows(index).Item(6))
                miComando.Transaction = transaccion_sql
                miComando.ExecuteNonQuery()
            Next

            miComando = New SqlCommand("UPDATE GUIA_REMISION_CORRELATIVOS_SANRAFAEL " & _
                                             "SET ULT_DOC = ULT_DOC + 1 " & _
                                             "WHERE REMITE_ID = @REMITE ", ActualizarConexion)
            miComando.Parameters.AddWithValue("@REMITE", dt.Rows(0).Item(1))
            miComando.Transaction = transaccion_sql
            miComando.ExecuteNonQuery()

            Dim almacen_remite As Integer = 0
            Dim dt_remite As New DataTable
            Dim query_REMITE As New StringBuilder
            query_REMITE.Append("SELECT NUM_ALMA FROM GUIA_REMISION_SUCURSAL WHERE (SUCURSAL_ID = @CVE_ALM) ")
            Dim cmd_select_REMITE As New SqlCommand(query_REMITE.ToString, ActualizarConexion)
            cmd_select_REMITE.Parameters.AddWithValue("@CVE_ALM", dt.Rows(0).Item(1))
            Dim adaptador_REMITE As New SqlDataAdapter(cmd_select_REMITE)
            cmd_select_REMITE.Transaction = transaccion_sql
            adaptador_REMITE.Fill(dt_remite)
            almacen_remite = dt_remite.Rows(0)(0)

            Dim almacen_destino As Integer = 0
            Dim dt_destino As New DataTable
            Dim query_destino As New StringBuilder
            query_destino.Append("SELECT NUM_ALMA FROM GUIA_REMISION_SUCURSAL WHERE (SUCURSAL_ID = @CVE_ALM) ")
            Dim cmd_select_DESTINO As New SqlCommand(query_destino.ToString, ActualizarConexion)
            cmd_select_DESTINO.Parameters.AddWithValue("@CVE_ALM", dt.Rows(0).Item(2))
            Dim adaptador_DESTINO As New SqlDataAdapter(cmd_select_DESTINO)
            cmd_select_DESTINO.Transaction = transaccion_sql
            adaptador_DESTINO.Fill(dt_destino)
            almacen_destino = almacen_remite

            'MOVIMIENTOS DEL SAE
            For index As Integer = 0 To dt2.Rows.Count - 1
                ' registrar las salidas
                'update MULT
                Dim query_mult_salida As New StringBuilder
                query_mult_salida.Append("UPDATE [SAE60Empre07].[dbo].[MULT07] ")
                query_mult_salida.Append("SET [EXIST] = ISNULL(EXIST,0) - @CANTIDAD ")
                query_mult_salida.Append("WHERE [CVE_ART] = @CVE_ART AND [CVE_ALM] = @CVE_ALM ")
                Dim comando_mult_salida As New SqlCommand(query_mult_salida.ToString, ActualizarConexion)
                comando_mult_salida.Parameters.AddWithValue("@CVE_ART", dt2.Rows(index).Item(2))
                comando_mult_salida.Parameters.AddWithValue("@CVE_ALM", almacen_remite)
                comando_mult_salida.Parameters.AddWithValue("@CANTIDAD", dt2.Rows(index).Item(0))
                comando_mult_salida.Transaction = transaccion_sql
                comando_mult_salida.ExecuteNonQuery()

                'update INVE
                Dim query_inve As New StringBuilder
                query_inve.Append("UPDATE [SAE60Empre07].[dbo].[INVE07] ")
                query_inve.Append("SET [EXIST] = EXIST - @CANTIDAD ")
                query_inve.Append("WHERE [CVE_ART] = @CVE_ART ")
                Dim comando_inve_salida As New SqlCommand(query_inve.ToString, ActualizarConexion)
                comando_inve_salida.Parameters.AddWithValue("@CVE_ART", dt2.Rows(index).Item(2))
                comando_inve_salida.Parameters.AddWithValue("@CANTIDAD", dt2.Rows(index).Item(0))
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
                If dt2.Rows(index).Item(6) = "S" Then
                    Dim ds_lotes As New DataSet
                    Dim cantidad As Double = 0, can_insertar As Double = 0

                    Dim query As New StringBuilder
                    query.Append("SELECT LOTE, CVE_ALM, FCHCADUC, CANTIDAD, REG_LTPD,PEDIMENTO,FCHADUANA, ")
                    query.Append("NOM_ADUAN,CVE_OBS,CIUDAD,FRONTERA,FEC_PROD_LT, GLN ")
                    query.Append("FROM [SAE60Empre07].[dbo].[LTPD07] WHERE (STATUS = 'A') AND (CVE_ART = @CVE_ART) AND CVE_ALM = @CVE_ALM")
                    query.Append(" AND (CANTIDAD > 0) AND (FCHCADUC > GETDATE() OR FCHCADUC IS NULL OR FCHCADUC = '') ")
                    query.Append("ORDER BY FCHCADUC ")
                    Dim cmd_select_lotes As New SqlCommand(query.ToString, ActualizarConexion)
                    cmd_select_lotes.Parameters.AddWithValue("@CVE_ART", dt2.Rows(index).Item(2))
                    cmd_select_lotes.Parameters.AddWithValue("@CVE_ALM", almacen_remite)
                    Dim adaptador As New SqlDataAdapter(cmd_select_lotes)
                    cmd_select_lotes.Transaction = transaccion_sql
                    adaptador.Fill(ds_lotes)
                    cantidad = Convert.ToDouble(dt2.Rows(index).Item(0))

                    'for de los lotes
                    For index1 As Integer = 0 To ds_lotes.Tables(0).Rows.Count - 1
                        correlativo_lotes = 0
                        'inicio de seleccinar el autonumerico de los enlace lotes
                        Dim ds_correlativo_lotes As New DataSet
                        Dim query_correlativo_lotes As New StringBuilder
                        query_correlativo_lotes.Append("SELECT (ULT_CVE + 1) AS ULT_CVE ")
                        query_correlativo_lotes.Append("FROM [SAE60Empre07].[dbo].[TBLCONTROL07] ")
                        query_correlativo_lotes.Append("WHERE (ID_TABLA = 67)")
                        Dim cmd_select_correlativo_enlace As New SqlCommand(query_correlativo_lotes.ToString, ActualizarConexion)
                        Dim adapenlace As New SqlDataAdapter(cmd_select_correlativo_enlace)
                        cmd_select_correlativo_enlace.Transaction = transaccion_sql
                        adapenlace.Fill(ds_correlativo_lotes)
                        'fin de seleccionar el autonumerico de los enlace lotes
                        correlativo_lotes = Convert.ToInt32(ds_correlativo_lotes.Tables(0).Rows(0)(0))

                        If Convert.ToInt32(ds_lotes.Tables(0).Rows(index1)(3)) >= cantidad Then
                            can_insertar = cantidad
                            'hacer el enlace a los lotes
                            Dim query_enlace As New StringBuilder
                            query_enlace.Append("INSERT INTO [SAE60Empre07].[dbo].[ENLACE_LTPD07] ")
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
                            query_ltpd.Append("UPDATE [SAE60Empre07].[dbo].[LTPD07] ")
                            query_ltpd.Append("SET [FCHULTMOV] = @FCHULTMOV ")
                            query_ltpd.Append(",[CANTIDAD] = (CANTIDAD - @NUEVA_CANTIDAD) ")
                            query_ltpd.Append("WHERE [CVE_ART] = @CVE_ART AND [LOTE] = @LOTE AND [CVE_ALM] = @CVE_ALM ")
                            Dim cmd_ltpd As New SqlCommand(query_ltpd.ToString, ActualizarConexion)
                            cmd_ltpd.Parameters.AddWithValue("@FCHULTMOV", Convert.ToDateTime(dt.Rows(0).Item(6)))
                            cmd_ltpd.Parameters.AddWithValue("@NUEVA_CANTIDAD", cantidad)
                            cmd_ltpd.Parameters.AddWithValue("@CVE_ART", dt2.Rows(index).Item(2))
                            cmd_ltpd.Parameters.AddWithValue("@LOTE", Convert.ToString(ds_lotes.Tables(0).Rows(index1)(0)))
                            cmd_ltpd.Parameters.AddWithValue("@CVE_ALM", almacen_remite)
                            cmd_ltpd.Transaction = transaccion_sql
                            cmd_ltpd.ExecuteNonQuery()
                            index1 = ds_lotes.Tables(0).Rows.Count

                        Else
                            can_insertar = (Convert.ToDouble(ds_lotes.Tables(0).Rows(index1)(3)) - Convert.ToDouble(dt2.Rows(index).Item(0)) + Convert.ToDouble(dt2.Rows(index).Item(0)))

                            'hacer el enlace a los lotes
                            Dim query_enlace_ltpd_ins As New StringBuilder
                            query_enlace_ltpd_ins.Append("INSERT INTO [SAE60Empre07].[dbo].[ENLACE_LTPD07] ")
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
                            query_upd_ltpd.Append("UPDATE [SAE60Empre07].[dbo].[LTPD07] ")
                            query_upd_ltpd.Append("SET [FCHULTMOV] = @FCHULTMOV ")
                            query_upd_ltpd.Append(",[CANTIDAD] = (CANTIDAD - @NUEVA_CANTIDAD) ")
                            query_upd_ltpd.Append("WHERE [CVE_ART] = @CVE_ART AND [LOTE] = @LOTE AND [CVE_ALM] = @CVE_ALM ")
                            Dim cmd_ltpd_upd As New SqlCommand(query_upd_ltpd.ToString, ActualizarConexion)
                            cmd_ltpd_upd.Parameters.AddWithValue("@FCHULTMOV", Convert.ToDateTime(dt.Rows(0).Item(6)))
                            cmd_ltpd_upd.Parameters.AddWithValue("@NUEVA_CANTIDAD", can_insertar)
                            cmd_ltpd_upd.Parameters.AddWithValue("@CVE_ART", dt2.Rows(index).Item(2))
                            cmd_ltpd_upd.Parameters.AddWithValue("@LOTE", Convert.ToString(ds_lotes.Tables(0).Rows(index1)(0)))
                            cmd_ltpd_upd.Parameters.AddWithValue("@CVE_ALM", almacen_remite)
                            cmd_ltpd_upd.Transaction = transaccion_sql
                            cmd_ltpd_upd.ExecuteNonQuery()
                            cantidad = cantidad - Convert.ToInt32(ds_lotes.Tables(0).Rows(index1)(3))
                            can_insertar = cantidad

                        End If
                    Next
                    For index2 As Integer = 0 To dt_lotes_crear.Rows.Count - 1

                        'Registro de Lote Temporal
                        Dim QueryLote As New StringBuilder
                        QueryLote.Append("INSERT INTO [Usuarios].[dbo].[GUIA_REMISION_LOTE_SANRAFAEL] ")
                        QueryLote.Append("(LOTE, CANT, PEDIMENTO, FCHCADUC, FCHADUANA, NOM_ADUANA, CVE_OBS, CIUDAD, FRONTERA, FEC_PROD_LT, GLN, REMISION, CODIGO) ")
                        QueryLote.Append("VALUES (@LOTE, @CANT, @PEDIMENTO, @FCHCADUC, @FCHADUANA, @NOM_ADUANA, @CVE_OBS, @CIUDAD, @FRONTERA, @FEC_PROD_LT, @GLN, @REMISION, @CODIGO) ")
                        Dim CMDLOTE As New SqlCommand(QueryLote.ToString, ActualizarConexion)
                        CMDLOTE.Parameters.AddWithValue("@LOTE", dt_lotes_crear(index2)(0))
                        CMDLOTE.Parameters.AddWithValue("@CANT", dt_lotes_crear(index2)(1))
                        CMDLOTE.Parameters.AddWithValue("@PEDIMENTO", dt_lotes_crear(index2)(2))
                        If Not IsDBNull(dt_lotes_crear(index2)(3)) Then
                            CMDLOTE.Parameters.AddWithValue("@FCHCADUC", Convert.ToDateTime(dt_lotes_crear(index2)(3)))
                        Else
                            CMDLOTE.Parameters.AddWithValue("@FCHCADUC", DBNull.Value)
                        End If
                        If Not IsDBNull(dt_lotes_crear(index2)(4)) Then
                            CMDLOTE.Parameters.AddWithValue("@FCHADUANA", Convert.ToDateTime(dt_lotes_crear(index2)(4)))
                        Else
                            CMDLOTE.Parameters.AddWithValue("@FCHADUANA", DBNull.Value)
                        End If

                        CMDLOTE.Parameters.AddWithValue("@NOM_ADUANA", dt_lotes_crear(index2)(5))
                        CMDLOTE.Parameters.AddWithValue("@CVE_OBS", dt_lotes_crear(index2)(6))
                        CMDLOTE.Parameters.AddWithValue("@CIUDAD", dt_lotes_crear(index2)(7))
                        CMDLOTE.Parameters.AddWithValue("@FRONTERA", dt_lotes_crear(index2)(8))
                        If Not IsDBNull(dt_lotes_crear(index2)(9)) Then
                            CMDLOTE.Parameters.AddWithValue("@FEC_PROD_LT", Convert.ToDateTime(dt_lotes_crear(index2)(9)))
                        Else
                            CMDLOTE.Parameters.AddWithValue("@FEC_PROD_LT", DBNull.Value)
                        End If

                        CMDLOTE.Parameters.AddWithValue("@GLN", dt_lotes_crear(index2)(10))
                        CMDLOTE.Parameters.AddWithValue("@REMISION", dt.Rows(0).Item(0))
                        CMDLOTE.Parameters.AddWithValue("@CODIGO", dt2.Rows(index).Item(2))
                        CMDLOTE.Parameters.AddWithValue("@FECHA_REMISION", Convert.ToDateTime(dt.Rows(0).Item(6)))

                        CMDLOTE.Transaction = transaccion_sql
                        CMDLOTE.ExecuteNonQuery()

                    Next

                    'actualizar los correlativos de los lotes
                    Dim query_actualiza_lotes As New StringBuilder
                    query_actualiza_lotes.Append("UPDATE [SAE60Empre07].[dbo].[TBLCONTROL07] ")
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
                query_datos_inve.Append("FROM [SAE60Empre07].[dbo].[INVE07] ")
                query_datos_inve.Append("WHERE CVE_ART = @CVE_ART")
                Dim comando_datos_inve As New SqlCommand(query_datos_inve.ToString, ActualizarConexion)
                comando_datos_inve.Parameters.AddWithValue("@CVE_ART", dt2.Rows(index).Item(2))
                comando_datos_inve.Transaction = transaccion_sql
                Dim adaptador_datos_inve As New SqlDataAdapter(comando_datos_inve)
                Dim dt_datos_inve As New DataTable
                adaptador_datos_inve.Fill(dt_datos_inve)

                'insert MINVE
                Dim query_minve As New StringBuilder
                query_minve.Append("INSERT INTO [SAE60Empre07].[dbo].[MINVE07] ")
                query_minve.Append("   ([CVE_ART],[ALMACEN],[NUM_MOV],[CVE_CPTO],[FECHA_DOCU],[TIPO_DOC],[REFER], ")
                query_minve.Append("    [CANT],[CANT_COST],[PRECIO],[COSTO], ")
                query_minve.Append("    [REG_SERIE],[UNI_VENTA],[E_LTPD],[EXIST_G],[EXISTENCIA],[TIPO_PROD],[FACTOR_CON], ")
                query_minve.Append("    [FECHAELAB],[CVE_FOLIO],[SIGNO],[COSTEADO],[COSTO_PROM_INI], ")
                query_minve.Append("    [COSTO_PROM_FIN],[COSTO_PROM_GRAL],[DESDE_INVE],[MOV_ENLAZADO]) ")
                query_minve.Append("VALUES ")
                query_minve.Append("   (@CVE_ART,@ALMACEN,(SELECT ULT_CVE+1 FROM [SAE60Empre07].[dbo].[TBLCONTROL07] WHERE (ID_TABLA = 44)), ")
                query_minve.Append("    @CVE_CPTO,@FECHA_DOCU,'M',@REFER,@CANT,0,0,@COSTO,0, ")
                query_minve.Append("    @UNI_VENTA,@E_LTPD, ((SELECT ISNULL(EXIST,0) FROM [SAE60Empre07].[dbo].[INVE07] WHERE CVE_ART = @CVE_ART)), ")
                query_minve.Append("    ((SELECT EXIST FROM [SAE60Empre07].[dbo].[MULT07] WHERE (CVE_ART = @CVE_ART) AND CVE_ALM = @ALMACEN)), 'P',1, ")
                query_minve.Append("    @FECHAELAB, (SELECT ULT_CVE+1 FROM [SAE60Empre07].[dbo].[TBLCONTROL07] WHERE (ID_TABLA = 32)), -1, 'S', @COSTO_PROM_INI, ")
                query_minve.Append("    @COSTO_PROM_FIN, @COSTO_PROM_GRAL, 'S', 0) ")

                Dim comando_minve_salida As New SqlCommand(query_minve.ToString, ActualizarConexion)
                comando_minve_salida.Parameters.AddWithValue("@CVE_ART", dt2.Rows(index).Item(2))
                comando_minve_salida.Parameters.AddWithValue("@ALMACEN", almacen_remite)
                comando_minve_salida.Parameters.AddWithValue("@CVE_CPTO", Convert.ToDouble(dt.Rows(0).Item(12)))
                comando_minve_salida.Parameters.AddWithValue("@FECHA_DOCU", Convert.ToDateTime(dt.Rows(0).Item(6)))
                comando_minve_salida.Parameters.AddWithValue("@REFER", dt.Rows(0).Item(0))
                comando_minve_salida.Parameters.AddWithValue("@CANT", dt2.Rows(index).Item(0))
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
                query_control_num_mov.Append("UPDATE [SAE60Empre07].[dbo].[TBLCONTROL07] ")
                query_control_num_mov.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                query_control_num_mov.Append("WHERE [ID_TABLA] = 44 ")
                Dim comando_control_num_mov As New SqlCommand(query_control_num_mov.ToString, ActualizarConexion)
                comando_control_num_mov.Transaction = transaccion_sql
                comando_control_num_mov.ExecuteNonQuery()

                'FIN DE REGISTRAR LAS SALIDAS

                ''''''

            Next
            'FIN DE MOVIMIENTOS DEL SAE

            '''''


            'update cve_folio minve
            Dim query_control_folio As New StringBuilder
            query_control_folio.Append("UPDATE [SAE60Empre07].[dbo].[TBLCONTROL07] ")
            query_control_folio.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
            query_control_folio.Append("WHERE ([ID_TABLA] = 32) ")
            Dim comando_control_folio As New SqlCommand(query_control_folio.ToString, ActualizarConexion)
            comando_control_folio.Transaction = transaccion_sql
            comando_control_folio.ExecuteNonQuery()

            Dim conexion_bita As New cls_bitacora_reporteador
            conexion_bita.RegistraBitacora(Now, usuario, "Genero Consignación (Remision)", "ALMACEN", _
                                      "Fecha: " & Convert.ToString(dt.Rows(0).Item(6)) & " Documento: " & dt.Rows(0).Item(0) & " almacen:" & almacen_remite)

            transaccion_sql.Commit()
            ActualizarConexion.Close()
            Return "correcto"

        Catch ex As Exception
            transaccion_sql.Rollback()
            Dim tamaño As Integer = Convert.ToString(ex.StackTrace).Length
            Dim posicion As Integer = InStrRev(Convert.ToString(ex.StackTrace), "línea") - 1
            Dim inicial As Integer = tamaño - posicion
            Dim linea_error As String = Convert.ToString(ex.StackTrace).Substring(tamaño - inicial, inicial)
            ActualizarConexion.Close()
            Return ex.Message & linea_error
        End Try
    End Function

    Public Function DEVOLVER(ByVal dt As DataTable, ByVal dt2 As DataTable, ByVal usuario As String, ByVal Estado As String, ByVal Documento As String)

        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()

        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand

            miComando = New SqlCommand("UPDATE GUIA_REMISION_ENCABEZADO_SANRAFAEL " & _
                                             "SET REMESTADO = @REMESTADO " & _
                                             "WHERE ID_REMISION = @ID_REMISION AND REMITE = @REMITE ", ActualizarConexion)
            miComando.Parameters.AddWithValue("@ID_REMISION", Documento)
            miComando.Parameters.AddWithValue("@REMITE", dt.Rows(0).Item(1))
            miComando.Parameters.AddWithValue("@REMESTADO", "CONSIGNACIÓN COMPLETA")
            miComando.Transaction = transaccion_sql
            miComando.ExecuteNonQuery()

            For index As Integer = 0 To dt2.Rows.Count - 1
                miComando = New SqlCommand("UPDATE GUIA_REMISION_PARTIDAS_SANRAFAEL " & _
                                             "SET CANT_RECIB = @CANT_RECIB " & _
                                             "WHERE ID_REMISION = @ID_REMISION AND NUM_PART = @NUM_PART AND REMITE = @REMITE", ActualizarConexion)
                miComando.Parameters.AddWithValue("@ID_REMISION", Documento)
                miComando.Parameters.AddWithValue("@CANT_RECIB", 0)
                miComando.Parameters.AddWithValue("@REMITE", dt.Rows(0).Item(1))
                miComando.Parameters.AddWithValue("@NUM_PART", index + 1)
                miComando.Transaction = transaccion_sql
                miComando.ExecuteNonQuery()
            Next

            If Estado <> "COMPLETA" Then
                For index As Integer = 0 To dt2.Rows.Count - 1
                    miComando = New SqlCommand("INSERT INTO [Usuarios].[dbo].[GUIA_REMISION_DEV_DET_SANRAFAEL] " & _
                                             "([ID_REMISION],[NUM_PART],[REMITE],[CANTIDAD],[CODIGO],[DESCRIPCION],[PESO_UNIT],[PESO_TOTAL],[CONLOTE], [CANT_RECIB], [CANT_DEVUELTA]) " & _
                                             "VALUES(@ID_REMISION, @NUM_PART, @REMITE, @CANTIDAD, @CODIGO, @DESCRIPCION,@PESO_UNIT,@PESO_TOTAL, @CONLOTE, @CANT_RECIB, @CANT_DEVUELTA) ", ActualizarConexion)
                    miComando.Parameters.AddWithValue("@ID_REMISION", Documento)
                    miComando.Parameters.AddWithValue("@REMITE", dt.Rows(0).Item(1))
                    miComando.Parameters.AddWithValue("@NUM_PART", index + 1)
                    miComando.Parameters.AddWithValue("@CANTIDAD", dt2.Rows(index).Item(0))
                    miComando.Parameters.AddWithValue("@CODIGO", dt2.Rows(index).Item(2))
                    miComando.Parameters.AddWithValue("@DESCRIPCION", dt2.Rows(index).Item(3))
                    miComando.Parameters.AddWithValue("@PESO_UNIT", dt2.Rows(index).Item(4))
                    miComando.Parameters.AddWithValue("@PESO_TOTAL", dt2.Rows(index).Item(5))
                    miComando.Parameters.AddWithValue("@CONLOTE", dt2.Rows(index).Item(6))
                    miComando.Parameters.AddWithValue("@CANT_RECIB", 0)
                    miComando.Parameters.AddWithValue("@CANT_DEVUELTA", dt2.Rows(index).Item(0))
                    miComando.Transaction = transaccion_sql
                    miComando.ExecuteNonQuery()
                Next
            End If

            Dim almacen_remite As Integer = 0
            Dim dt_remite As New DataTable
            Dim query_REMITE As New StringBuilder
            query_REMITE.Append("SELECT NUM_ALMA FROM GUIA_REMISION_SUCURSAL WHERE (SUCURSAL_ID = @CVE_ALM) ")
            Dim cmd_select_REMITE As New SqlCommand(query_REMITE.ToString, ActualizarConexion)
            cmd_select_REMITE.Parameters.AddWithValue("@CVE_ALM", dt.Rows(0).Item(1))
            Dim adaptador_REMITE As New SqlDataAdapter(cmd_select_REMITE)
            cmd_select_REMITE.Transaction = transaccion_sql
            adaptador_REMITE.Fill(dt_remite)
            almacen_remite = dt_remite.Rows(0)(0)

            Dim almacen_destino As Integer = 0
            Dim dt_destino As New DataTable
            Dim query_destino As New StringBuilder
            query_destino.Append("SELECT NUM_ALMA FROM GUIA_REMISION_SUCURSAL WHERE (SUCURSAL_ID = @CVE_ALM) ")
            Dim cmd_select_DESTINO As New SqlCommand(query_destino.ToString, ActualizarConexion)
            cmd_select_DESTINO.Parameters.AddWithValue("@CVE_ALM", dt.Rows(0).Item(2))
            Dim adaptador_DESTINO As New SqlDataAdapter(cmd_select_DESTINO)
            cmd_select_DESTINO.Transaction = transaccion_sql
            adaptador_DESTINO.Fill(dt_destino)
            almacen_destino = almacen_remite

            ''''
            'Inicio
            ''''
            If Estado <> "COMPLETA" Then
                'MOVIMIENTOS DEL SAE
                For index As Integer = 0 To dt2.Rows.Count - 1
                    If (dt2.Rows(index).Item(0) <> 0) Then
                        ' registrar las salidas

                        'update INVE

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
                        Dim RestanteDev As Decimal = dt2.Rows(index).Item(0)
                        Dim correlativo_lotes As Integer = 0
                        dt_lotes_crear.Rows.Clear()


                        'select Datos INVE
                        Dim query_datos_inve As New StringBuilder
                        query_datos_inve.Append("SELECT ISNULL(COSTO_PROM,0), ISNULL(UNI_MED,'') ")
                        query_datos_inve.Append("FROM [SAE60Empre07].[dbo].[INVE07] ")
                        query_datos_inve.Append("WHERE CVE_ART = @CVE_ART")
                        Dim comando_datos_inve As New SqlCommand(query_datos_inve.ToString, ActualizarConexion)
                        comando_datos_inve.Parameters.AddWithValue("@CVE_ART", dt2.Rows(index).Item(2))
                        comando_datos_inve.Transaction = transaccion_sql
                        Dim adaptador_datos_inve As New SqlDataAdapter(comando_datos_inve)
                        Dim dt_datos_inve As New DataTable
                        adaptador_datos_inve.Fill(dt_datos_inve)


                        'FIN DE REGISTRAR LAS SALIDAS

                        'INICIO REGISTRAR LAS ENTRADAS
                        'update MULT
                        Dim query_mult_entrada As New StringBuilder
                        query_mult_entrada.Append("UPDATE [SAE60Empre07].[dbo].[MULT07] ")
                        query_mult_entrada.Append("SET [EXIST] = ISNULL(EXIST,0) + @CANTIDAD ")
                        query_mult_entrada.Append("WHERE [CVE_ART] = @CVE_ART AND [CVE_ALM] = @CVE_ALM ")
                        Dim comando_mult_entrada As New SqlCommand(query_mult_entrada.ToString, ActualizarConexion)
                        comando_mult_entrada.Parameters.AddWithValue("@CVE_ART", dt2.Rows(index).Item(2))
                        comando_mult_entrada.Parameters.AddWithValue("@CVE_ALM", almacen_remite)
                        comando_mult_entrada.Parameters.AddWithValue("@CANTIDAD", dt2.Rows(index).Item(0))
                        comando_mult_entrada.Transaction = transaccion_sql
                        comando_mult_entrada.ExecuteNonQuery()

                        'update INVE
                        Dim query_inve_entrada As New StringBuilder
                        query_inve_entrada.Append("UPDATE [SAE60Empre07].[dbo].[INVE07] ")
                        query_inve_entrada.Append("SET [EXIST] = EXIST + @CANTIDAD ")
                        query_inve_entrada.Append("WHERE [CVE_ART] = @CVE_ART ")
                        Dim comando_inve_entrada As New SqlCommand(query_inve_entrada.ToString, ActualizarConexion)
                        comando_inve_entrada.Parameters.AddWithValue("@CVE_ART", dt2.Rows(index).Item(2))
                        comando_inve_entrada.Parameters.AddWithValue("@CANTIDAD", dt2.Rows(index).Item(0))
                        comando_inve_entrada.Transaction = transaccion_sql
                        comando_inve_entrada.ExecuteNonQuery()

                        'Flag
                        'Seleccionar los lotes a cargar
                        Dim QueryBuscaLotes As New StringBuilder
                        QueryBuscaLotes.Append("SELECT LOTE, CANT, PEDIMENTO, FCHCADUC, FCHADUANA, NOM_ADUANA, CVE_OBS, CIUDAD, FRONTERA, FEC_PROD_LT, GLN, REMISION, CODIGO, FECHA_REMISION ")
                        QueryBuscaLotes.Append("FROM [Usuarios].[dbo].[GUIA_REMISION_LOTE_SANRAFAEL] ")
                        QueryBuscaLotes.Append(" WHERE CODIGO = @CVE_ART AND REMISION = @REMISION")
                        Dim CMDBuscaLotes As New SqlCommand(QueryBuscaLotes.ToString, ActualizarConexion)

                        CMDBuscaLotes.Parameters.AddWithValue("@REMISION", Documento)
                        CMDBuscaLotes.Parameters.AddWithValue("@CVE_ART", dt2.Rows(index).Item(2))

                        CMDBuscaLotes.Transaction = transaccion_sql
                        Dim ADAPTADORBUSCALOTE As New SqlDataAdapter(CMDBuscaLotes)
                        ADAPTADORBUSCALOTE.Fill(dt_lotes_crear)
                        '



                        'INICIO DE LOS LOTES
                        Dim correlativo_lotes_ENTRADA As Integer = 0
                        If dt2.Rows(index).Item(6) = "S" Then
                            For index2 As Integer = 0 To dt_lotes_crear.Rows.Count - 1
                                If RestanteDev > 0 Then
                                    correlativo_lotes_ENTRADA = 0
                                    'inicio de seleccinar el autonumerico de los enlace lotes
                                    Dim ds_correlativo_lotes As New DataSet
                                    Dim query_correlativo_lotes As New StringBuilder
                                    query_correlativo_lotes.Append("SELECT (ULT_CVE + 1) AS ULT_CVE ")
                                    query_correlativo_lotes.Append("FROM [SAE60Empre07].[dbo].[TBLCONTROL07] ")
                                    query_correlativo_lotes.Append("WHERE (ID_TABLA = 67)")
                                    Dim cmd_select_correlativo_enlace As New SqlCommand(query_correlativo_lotes.ToString, ActualizarConexion)
                                    Dim adapenlace As New SqlDataAdapter(cmd_select_correlativo_enlace)
                                    cmd_select_correlativo_enlace.Transaction = transaccion_sql
                                    adapenlace.Fill(ds_correlativo_lotes)
                                    'fin de seleccionar el autonumerico de los enlace lotes
                                    correlativo_lotes_ENTRADA = Convert.ToInt32(ds_correlativo_lotes.Tables(0).Rows(0)(0))

                                    Dim query_valida_lote As New StringBuilder
                                    query_valida_lote.Append("SELECT CVE_ART,LOTE,REG_LTPD ")
                                    query_valida_lote.Append("FROM [SAE60Empre07].[dbo].[LTPD07] ")
                                    query_valida_lote.Append("WHERE LOTE = @LOTE AND CVE_ALM = @ALMACEN AND CVE_ART = @CVE_ART ")
                                    Dim cmd_valida_lote As New SqlCommand(query_valida_lote.ToString, ActualizarConexion)
                                    cmd_valida_lote.Parameters.AddWithValue("@LOTE", dt_lotes_crear.Rows(index2)(0))
                                    cmd_valida_lote.Parameters.AddWithValue("@ALMACEN", almacen_remite)
                                    cmd_valida_lote.Parameters.AddWithValue("@CVE_ART", dt2.Rows(index).Item(2))
                                    cmd_valida_lote.Transaction = transaccion_sql
                                    Dim adaptador_valida_lote As New SqlDataAdapter(cmd_valida_lote)
                                    Dim dt_valida_lote As New DataTable
                                    adaptador_valida_lote.Fill(dt_valida_lote)

                                    If dt_valida_lote.Rows.Count > 0 Then
                                        'si el lote existe
                                        'hacer el enlace a los lotes
                                        Dim query_enlace_ltpd_ins_entrada As New StringBuilder
                                        query_enlace_ltpd_ins_entrada.Append("INSERT INTO [SAE60Empre07].[dbo].[ENLACE_LTPD07] ")
                                        query_enlace_ltpd_ins_entrada.Append("(E_LTPD,REG_LTPD,CANTIDAD,PXRS) ")
                                        query_enlace_ltpd_ins_entrada.Append("VALUES (@E_LTPD,@REG_LTPD,@CANTIDAD,@PXRS) ")
                                        Dim cmd_enlace_ltpd_ins_entrada As New SqlCommand(query_enlace_ltpd_ins_entrada.ToString, ActualizarConexion)
                                        cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@E_LTPD", correlativo_lotes_ENTRADA)
                                        cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@REG_LTPD", dt_valida_lote.Rows(0)(2))
                                        Dim CantidadGuarda As Decimal = 0
                                        If dt_lotes_crear.Rows(index2)(1) > RestanteDev Then
                                            cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@CANTIDAD", RestanteDev)
                                            cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@PXRS", RestanteDev)
                                            CantidadGuarda = RestanteDev
                                            RestanteDev = 0
                                        Else
                                            cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@CANTIDAD", dt_lotes_crear.Rows(index2)(1))
                                            cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@PXRS", dt_lotes_crear.Rows(index2)(1))
                                            CantidadGuarda = dt_lotes_crear.Rows(index2)(1)
                                            RestanteDev -= dt_lotes_crear.Rows(index2)(1)
                                        End If

                                        cmd_enlace_ltpd_ins_entrada.Transaction = transaccion_sql
                                        cmd_enlace_ltpd_ins_entrada.ExecuteNonQuery()

                                        Dim query_upd_ltpd As New StringBuilder
                                        query_upd_ltpd.Append("UPDATE [SAE60Empre07].[dbo].[LTPD07] ")
                                        query_upd_ltpd.Append("SET [FCHULTMOV] = @FCHULTMOV ")
                                        query_upd_ltpd.Append(",[CANTIDAD] = (CANTIDAD + @NUEVA_CANTIDAD) ")
                                        query_upd_ltpd.Append("WHERE [CVE_ART] = @CVE_ART AND [LOTE] = @LOTE AND [CVE_ALM] = @CVE_ALM ")
                                        Dim cmd_ltpd_upd As New SqlCommand(query_upd_ltpd.ToString, ActualizarConexion)
                                        cmd_ltpd_upd.Parameters.AddWithValue("@FCHULTMOV", Today)
                                        cmd_ltpd_upd.Parameters.AddWithValue("@NUEVA_CANTIDAD", CantidadGuarda)
                                        cmd_ltpd_upd.Parameters.AddWithValue("@CVE_ART", dt2.Rows(index).Item(2))
                                        cmd_ltpd_upd.Parameters.AddWithValue("@LOTE", dt_valida_lote.Rows(0)(1))
                                        cmd_ltpd_upd.Parameters.AddWithValue("@CVE_ALM", almacen_remite)
                                        cmd_ltpd_upd.Transaction = transaccion_sql
                                        cmd_ltpd_upd.ExecuteNonQuery()
                                    Else
                                        'si el lote NO existe
                                        Dim nuevo_reg_ltpd As Integer = 0
                                        'inicio de seleccinar el autonumerico de los lotes
                                        Dim ds_nuevo_reg_ltpd As New DataSet
                                        Dim query_nuevo_reg_ltpd2 As New StringBuilder
                                        query_nuevo_reg_ltpd2.Append("SELECT (ULT_CVE + 1) AS ULT_CVE ")
                                        query_nuevo_reg_ltpd2.Append("FROM [SAE60Empre07].[dbo].[TBLCONTROL07] ")
                                        query_nuevo_reg_ltpd2.Append("WHERE (ID_TABLA = 48)")
                                        Dim cmd_select_nuevo_reg_ltpd2 As New SqlCommand(query_nuevo_reg_ltpd2.ToString, ActualizarConexion)
                                        Dim adapnuevo_reg_ltpd As New SqlDataAdapter(cmd_select_nuevo_reg_ltpd2)
                                        cmd_select_nuevo_reg_ltpd2.Transaction = transaccion_sql
                                        adapnuevo_reg_ltpd.Fill(ds_nuevo_reg_ltpd)
                                        'fin de seleccionar el autonumerico de los lotes
                                        nuevo_reg_ltpd = Convert.ToInt32(ds_nuevo_reg_ltpd.Tables(0).Rows(0)(0))

                                        'hacer el enlace a los lotes
                                        Dim query_enlace_ltpd_ins_entrada As New StringBuilder
                                        query_enlace_ltpd_ins_entrada.Append("INSERT INTO [SAE60Empre07].[dbo].[ENLACE_LTPD07] ")
                                        query_enlace_ltpd_ins_entrada.Append("(E_LTPD,REG_LTPD,CANTIDAD,PXRS) ")
                                        query_enlace_ltpd_ins_entrada.Append("VALUES (@E_LTPD,@REG_LTPD,@CANTIDAD,@PXRS) ")
                                        Dim cmd_enlace_ltpd_ins_entrada As New SqlCommand(query_enlace_ltpd_ins_entrada.ToString, ActualizarConexion)
                                        cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@E_LTPD", correlativo_lotes_ENTRADA)
                                        cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@REG_LTPD", nuevo_reg_ltpd)
                                        Dim CantidadGuarda As Decimal = 0
                                        If dt_lotes_crear.Rows(index2)(1) > RestanteDev Then
                                            cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@CANTIDAD", RestanteDev)
                                            cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@PXRS", RestanteDev)
                                            CantidadGuarda = RestanteDev
                                            RestanteDev -= 0
                                        Else
                                            cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@CANTIDAD", dt_lotes_crear.Rows(index2)(1))
                                            cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@PXRS", dt_lotes_crear.Rows(index2)(1))
                                            CantidadGuarda = dt_lotes_crear.Rows(index2)(1)
                                            RestanteDev -= dt_lotes_crear.Rows(index2)(1)
                                        End If

                                        cmd_enlace_ltpd_ins_entrada.Transaction = transaccion_sql
                                        cmd_enlace_ltpd_ins_entrada.ExecuteNonQuery()
                                        'insertar nuevo lote
                                        Dim query_insertar_nuevo_lote As New StringBuilder
                                        query_insertar_nuevo_lote.Append("INSERT INTO [SAE60Empre07].[dbo].[LTPD07] ")
                                        query_insertar_nuevo_lote.Append("([CVE_ART],[LOTE],[PEDIMENTO],[CVE_ALM],[FCHCADUC],[FCHADUANA] ")
                                        query_insertar_nuevo_lote.Append(",[FCHULTMOV],[NOM_ADUAN],[CANTIDAD],[REG_LTPD],[CVE_OBS] ")
                                        query_insertar_nuevo_lote.Append(",[CIUDAD],[FRONTERA],[FEC_PROD_LT],[GLN],[STATUS]) ")
                                        query_insertar_nuevo_lote.Append("VALUES ")
                                        query_insertar_nuevo_lote.Append("(@CVE_ART,@LOTE,@PEDIMENTO,@CVE_ALM,@FCHCADUC,@FCHADUANA ")
                                        query_insertar_nuevo_lote.Append(",@FCHULTMOV,@NOM_ADUAN,@CANTIDAD,@REG_LTPD,@CVE_OBS,@CIUDAD ")
                                        query_insertar_nuevo_lote.Append(",@FRONTERA,@FEC_PROD_LT,@GLN,@STATUS)")
                                        Dim cmd_insertar_nuevo_lote As New SqlCommand(query_insertar_nuevo_lote.ToString, ActualizarConexion)
                                        cmd_insertar_nuevo_lote.Parameters.AddWithValue("@CVE_ART", dt2.Rows(index).Item(2))
                                        cmd_insertar_nuevo_lote.Parameters.AddWithValue("@LOTE", dt_lotes_crear.Rows(index2)(0))
                                        cmd_insertar_nuevo_lote.Parameters.AddWithValue("@PEDIMENTO", dt_lotes_crear.Rows(index2)(2))
                                        cmd_insertar_nuevo_lote.Parameters.AddWithValue("@CVE_ALM", almacen_remite)

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
                                        cmd_insertar_nuevo_lote.Parameters.AddWithValue("@CANTIDAD", CantidadGuarda)
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
                                        query_actualiza_autonumerico_ltpd.Append("UPDATE [SAE60Empre07].[dbo].[TBLCONTROL07] ")
                                        query_actualiza_autonumerico_ltpd.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                                        query_actualiza_autonumerico_ltpd.Append("WHERE (ID_TABLA = 48) ")
                                        Dim cmd_upd_autonumerico_ltpd As New SqlCommand(query_actualiza_autonumerico_ltpd.ToString, ActualizarConexion)
                                        cmd_upd_autonumerico_ltpd.Transaction = transaccion_sql
                                        cmd_upd_autonumerico_ltpd.ExecuteNonQuery()

                                    End If
                                End If
                            Next

                            'actualizar los correlativos de enlace de lotes
                            Dim query_actualiza_lotes As New StringBuilder
                            query_actualiza_lotes.Append("UPDATE [SAE60Empre07].[dbo].[TBLCONTROL07] ")
                            query_actualiza_lotes.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                            query_actualiza_lotes.Append("WHERE (ID_TABLA = 67) ")
                            Dim cmd_upd_correlativo_lot As New SqlCommand(query_actualiza_lotes.ToString, ActualizarConexion)
                            cmd_upd_correlativo_lot.Transaction = transaccion_sql
                            cmd_upd_correlativo_lot.ExecuteNonQuery()
                        End If


                        'Seleccionar Motivo de Entrada
                        Dim ds_entrada As New DataSet
                        Dim query_entrada As New StringBuilder
                        query_entrada.Append("SELECT MTVOENTRADA ")
                        query_entrada.Append("FROM [Usuarios].[dbo].[GUIA_REMISION_ENCABEZADO_SANRAFAEL] ")
                        query_entrada.Append("WHERE (ID_REMISION = @ID_REMISION) AND (REMITE = @REMITE)")

                        Dim cmd_select_entrada As New SqlCommand(query_entrada.ToString, ActualizarConexion)
                        cmd_select_entrada.Parameters.AddWithValue("@ID_REMISION", Documento)
                        cmd_select_entrada.Parameters.AddWithValue("@REMITE", almacen_remite)

                        Dim adapentrada1 As New SqlDataAdapter(cmd_select_entrada)
                        cmd_select_entrada.Transaction = transaccion_sql
                        adapentrada1.Fill(ds_entrada)
                        Dim MOTIVOENTRADA
                        If ds_entrada.Tables(0).Rows.Count > 0 Then
                            MOTIVOENTRADA = Convert.ToInt32(ds_entrada.Tables(0).Rows(0)(0))
                        Else
                            MOTIVOENTRADA = 7
                        End If

                        'insert MINVE
                        Dim query_minve_entrada As New StringBuilder
                        query_minve_entrada.Append("INSERT INTO [SAE60Empre07].[dbo].[MINVE07] ")
                        query_minve_entrada.Append("   ([CVE_ART],[ALMACEN],[NUM_MOV],[CVE_CPTO],[FECHA_DOCU],[TIPO_DOC],[REFER], ")
                        query_minve_entrada.Append("    [CANT],[CANT_COST],[PRECIO],[COSTO], ")
                        query_minve_entrada.Append("    [REG_SERIE],[UNI_VENTA],[E_LTPD],[EXIST_G],[EXISTENCIA],[TIPO_PROD],[FACTOR_CON], ")
                        query_minve_entrada.Append("    [FECHAELAB],[CVE_FOLIO],[SIGNO],[COSTEADO],[COSTO_PROM_INI], ")
                        query_minve_entrada.Append("    [COSTO_PROM_FIN],[COSTO_PROM_GRAL],[DESDE_INVE],[MOV_ENLAZADO]) ")
                        query_minve_entrada.Append("VALUES ")
                        query_minve_entrada.Append("   (@CVE_ART,@ALMACEN,(SELECT ULT_CVE+1 FROM [SAE60Empre07].[dbo].[TBLCONTROL07] WHERE (ID_TABLA = 44)), ")
                        query_minve_entrada.Append("    @CVE_CPTO,@FECHA_DOCU,'M',@REFER,@CANT,0,0,@COSTO,0, ")
                        query_minve_entrada.Append("    @UNI_VENTA,@E_LTPD, ((SELECT ISNULL(EXIST,0) FROM [SAE60Empre07].[dbo].[INVE07] WHERE CVE_ART = @CVE_ART)), ")
                        query_minve_entrada.Append("    ((SELECT EXIST FROM [SAE60Empre07].[dbo].[MULT07] WHERE (CVE_ART = @CVE_ART) AND CVE_ALM = @ALMACEN)), 'P',1, ")
                        query_minve_entrada.Append("    @FECHAELAB, (SELECT ULT_CVE+1 FROM [SAE60Empre07].[dbo].[TBLCONTROL07] WHERE (ID_TABLA = 32)), 1, 'S', @COSTO_PROM_INI, ")
                        query_minve_entrada.Append("    @COSTO_PROM_FIN, @COSTO_PROM_GRAL, 'S', (SELECT ULT_CVE FROM [SAE60Empre07].[dbo].[TBLCONTROL07] WHERE (ID_TABLA = 44))) ")
                        Dim comando_minve_entrada As New SqlCommand(query_minve_entrada.ToString, ActualizarConexion)
                        comando_minve_entrada.Parameters.AddWithValue("@CVE_ART", dt2.Rows(index).Item(2))
                        comando_minve_entrada.Parameters.AddWithValue("@ALMACEN", almacen_remite)
                        comando_minve_entrada.Parameters.AddWithValue("@CVE_CPTO", MOTIVOENTRADA)
                        comando_minve_entrada.Parameters.AddWithValue("@FECHA_DOCU", Today.Date)
                        comando_minve_entrada.Parameters.AddWithValue("@REFER", Documento)
                        comando_minve_entrada.Parameters.AddWithValue("@CANT", dt2.Rows(index).Item(0))
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
                        query_control_num_mov_entrada.Append("UPDATE [SAE60Empre07].[dbo].[TBLCONTROL07] ")
                        query_control_num_mov_entrada.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                        query_control_num_mov_entrada.Append("WHERE [ID_TABLA] = 44 ")
                        Dim comando_control_num_mov_entrada As New SqlCommand(query_control_num_mov_entrada.ToString, ActualizarConexion)
                        comando_control_num_mov_entrada.Transaction = transaccion_sql
                        comando_control_num_mov_entrada.ExecuteNonQuery()
                    End If
                Next
                'FIN DE MOVIMIENTOS DEL SAE

                'update cve_folio minve
                Dim query_control_folio_DEV As New StringBuilder
                query_control_folio_DEV.Append("UPDATE [SAE60Empre07].[dbo].[TBLCONTROL07] ")
                query_control_folio_DEV.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                query_control_folio_DEV.Append("WHERE ([ID_TABLA] = 32) ")
                Dim comando_control_folio_DEV As New SqlCommand(query_control_folio_DEV.ToString, ActualizarConexion)
                comando_control_folio_DEV.Transaction = transaccion_sql
                comando_control_folio_DEV.ExecuteNonQuery()

            End If

            ''''
            'FIn
            ''''

            Dim conexion_bita As New cls_bitacora_reporteador
            conexion_bita.RegistraBitacora(Now, usuario, "Completó Consignación", "ALMACEN", _
                                      "Fecha: " & Convert.ToString(DateTime.Now) & " Documento: " & Documento & " almacen:" & almacen_remite)

            transaccion_sql.Commit()
            ActualizarConexion.Close()
            Return "correcto"

        Catch ex As Exception
            transaccion_sql.Rollback()
            Dim tamaño As Integer = Convert.ToString(ex.StackTrace).Length
            Dim posicion As Integer = InStrRev(Convert.ToString(ex.StackTrace), "línea") - 1
            Dim inicial As Integer = tamaño - posicion
            Dim linea_error As String = Convert.ToString(ex.StackTrace).Substring(tamaño - inicial, inicial)
            ActualizarConexion.Close()
            Return ex.Message & linea_error

        End Try
    End Function

    Public Function RevisarEstado(ByVal Almacen As Integer, ByVal Id As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT  REMESTADO FROM GUIA_REMISION_ENCABEZADO_SANRAFAEL WHERE ID_REMISION = @Id AND REMITE = @Almacen", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Almacen", SqlDbType.Int).Value = Almacen
        miComando.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = Id


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

    Public Function COMPLETAR(ByVal dt As DataTable, ByVal dt2 As DataTable, ByVal usuario As String, ByVal Estado As String, ByVal Doc As String, ByVal Identidad As String, ByVal Entregador As String, ByVal Placa As String, ByVal Modelo As String, ByVal CLiente As String, ByVal Vehiculo As String, ByVal ClaveEntregador As String)

        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim ActualizarConexionConsumo As New SqlConnection(CONSUMO.CadenaSQL())

        Dim transaccion_sql As SqlTransaction
        Dim transaccion_sqlConsumo As SqlTransaction

        ActualizarConexion.Open()
        ActualizarConexionConsumo.Open()

        transaccion_sql = ActualizarConexion.BeginTransaction
        transaccion_sqlConsumo = ActualizarConexionConsumo.BeginTransaction

        Try
            Dim miComando As New SqlCommand

            miComando = New SqlCommand("UPDATE GUIA_REMISION_ENCABEZADO_SANRAFAEL " & _
                                             "SET REMESTADO = @REMESTADO " & _
                                             "WHERE ID_REMISION = @ID_REMISION AND REMITE = @REMITE ", ActualizarConexion)
            miComando.Parameters.AddWithValue("@ID_REMISION", Doc)
            miComando.Parameters.AddWithValue("@REMITE", dt.Rows(0).Item(1))
            miComando.Parameters.AddWithValue("@REMESTADO", "CONSIGNACIÓN COMPLETA")
            miComando.Transaction = transaccion_sql
            miComando.ExecuteNonQuery()

            For index As Integer = 0 To dt2.Rows.Count - 1
                miComando = New SqlCommand("UPDATE GUIA_REMISION_PARTIDAS_SANRAFAEL " & _
                                             "SET CANT_RECIB = @CANT_RECIB " & _
                                             "WHERE ID_REMISION = @ID_REMISION AND NUM_PART = @NUM_PART AND REMITE = @REMITE", ActualizarConexion)
                miComando.Parameters.AddWithValue("@ID_REMISION", Doc)
                miComando.Parameters.AddWithValue("@CANT_RECIB", dt2.Rows(index)(7))
                miComando.Parameters.AddWithValue("@REMITE", dt.Rows(0).Item(1))
                miComando.Parameters.AddWithValue("@NUM_PART", index + 1)
                miComando.Transaction = transaccion_sql
                miComando.ExecuteNonQuery()
            Next

            If Estado <> "COMPLETA" Then
                For index As Integer = 0 To dt2.Rows.Count - 1
                    miComando = New SqlCommand("INSERT INTO [Usuarios].[dbo].[GUIA_REMISION_DEV_DET_SANRAFAEL] " & _
                                             "([ID_REMISION],[NUM_PART],[REMITE],[CANTIDAD],[CODIGO],[DESCRIPCION],[PESO_UNIT],[PESO_TOTAL],[CONLOTE], [CANT_RECIB], [CANT_DEVUELTA]) " & _
                                             "VALUES(@ID_REMISION, @NUM_PART, @REMITE, @CANTIDAD, @CODIGO, @DESCRIPCION,@PESO_UNIT,@PESO_TOTAL, @CONLOTE, @CANT_RECIB, @CANT_DEVUELTA) ", ActualizarConexion)
                    miComando.Parameters.AddWithValue("@ID_REMISION", Doc)
                    miComando.Parameters.AddWithValue("@REMITE", dt.Rows(0).Item(1))
                    miComando.Parameters.AddWithValue("@NUM_PART", index + 1)
                    miComando.Parameters.AddWithValue("@CANTIDAD", dt2.Rows(index).Item(0))
                    miComando.Parameters.AddWithValue("@CODIGO", dt2.Rows(index).Item(2))
                    miComando.Parameters.AddWithValue("@DESCRIPCION", dt2.Rows(index).Item(3))
                    miComando.Parameters.AddWithValue("@PESO_UNIT", dt2.Rows(index).Item(4))
                    miComando.Parameters.AddWithValue("@PESO_TOTAL", dt2.Rows(index).Item(5))
                    miComando.Parameters.AddWithValue("@CONLOTE", dt2.Rows(index).Item(6))
                    miComando.Parameters.AddWithValue("@CANT_RECIB", dt2.Rows(index).Item(7))
                    miComando.Parameters.AddWithValue("@CANT_DEVUELTA", dt2.Rows(index).Item(0) - dt2.Rows(index).Item(7))
                    miComando.Transaction = transaccion_sql
                    miComando.ExecuteNonQuery()
                Next
            End If


            Dim almacen_remite As Integer = 0
            Dim dt_remite As New DataTable
            Dim query_REMITE As New StringBuilder
            query_REMITE.Append("SELECT NUM_ALMA FROM GUIA_REMISION_SUCURSAL WHERE (SUCURSAL_ID = @CVE_ALM) ")
            Dim cmd_select_REMITE As New SqlCommand(query_REMITE.ToString, ActualizarConexion)
            cmd_select_REMITE.Parameters.AddWithValue("@CVE_ALM", dt.Rows(0).Item(1))
            Dim adaptador_REMITE As New SqlDataAdapter(cmd_select_REMITE)
            cmd_select_REMITE.Transaction = transaccion_sql
            adaptador_REMITE.Fill(dt_remite)
            almacen_remite = dt_remite.Rows(0)(0)

            Dim almacen_destino As Integer = 0
            Dim dt_destino As New DataTable
            Dim query_destino As New StringBuilder
            query_destino.Append("SELECT NUM_ALMA FROM GUIA_REMISION_SUCURSAL WHERE (SUCURSAL_ID = @CVE_ALM) ")
            Dim cmd_select_DESTINO As New SqlCommand(query_destino.ToString, ActualizarConexion)
            cmd_select_DESTINO.Parameters.AddWithValue("@CVE_ALM", dt.Rows(0).Item(2))
            Dim adaptador_DESTINO As New SqlDataAdapter(cmd_select_DESTINO)
            cmd_select_DESTINO.Transaction = transaccion_sql
            adaptador_DESTINO.Fill(dt_destino)
            almacen_destino = almacen_remite

            ''''
            'Inicio
            ''''
            If Estado <> "COMP" Then
                'MOVIMIENTOS DEL SAE
                For index As Integer = 0 To dt2.Rows.Count - 1
                    If (dt2.Rows(index).Item(0) <> 0) Then
                        ' registrar las salidas

                        'update INVE

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
                        Dim RestanteDev As Decimal = dt2.Rows(index).Item(0)
                        Dim correlativo_lotes As Integer = 0
                        dt_lotes_crear.Rows.Clear()


                        'select Datos INVE
                        Dim query_datos_inve As New StringBuilder
                        query_datos_inve.Append("SELECT ISNULL(COSTO_PROM,0), ISNULL(UNI_MED,'') ")
                        query_datos_inve.Append("FROM [SAE60Empre07].[dbo].[INVE07] ")
                        query_datos_inve.Append("WHERE CVE_ART = @CVE_ART")
                        Dim comando_datos_inve As New SqlCommand(query_datos_inve.ToString, ActualizarConexion)
                        comando_datos_inve.Parameters.AddWithValue("@CVE_ART", dt2.Rows(index).Item(2))
                        comando_datos_inve.Transaction = transaccion_sql
                        Dim adaptador_datos_inve As New SqlDataAdapter(comando_datos_inve)
                        Dim dt_datos_inve As New DataTable
                        adaptador_datos_inve.Fill(dt_datos_inve)


                        'FIN DE REGISTRAR LAS SALIDAS

                        'INICIO REGISTRAR LAS ENTRADAS
                        'update MULT
                        Dim query_mult_entrada As New StringBuilder
                        query_mult_entrada.Append("UPDATE [SAE60Empre07].[dbo].[MULT07] ")
                        query_mult_entrada.Append("SET [EXIST] = ISNULL(EXIST,0) + @CANTIDAD ")
                        query_mult_entrada.Append("WHERE [CVE_ART] = @CVE_ART AND [CVE_ALM] = @CVE_ALM ")
                        Dim comando_mult_entrada As New SqlCommand(query_mult_entrada.ToString, ActualizarConexion)
                        comando_mult_entrada.Parameters.AddWithValue("@CVE_ART", dt2.Rows(index).Item(2))
                        comando_mult_entrada.Parameters.AddWithValue("@CVE_ALM", almacen_remite)
                        comando_mult_entrada.Parameters.AddWithValue("@CANTIDAD", dt2.Rows(index).Item(0))
                        comando_mult_entrada.Transaction = transaccion_sql
                        comando_mult_entrada.ExecuteNonQuery()

                        'update INVE
                        Dim query_inve_entrada As New StringBuilder
                        query_inve_entrada.Append("UPDATE [SAE60Empre07].[dbo].[INVE07] ")
                        query_inve_entrada.Append("SET [EXIST] = EXIST + @CANTIDAD ")
                        query_inve_entrada.Append("WHERE [CVE_ART] = @CVE_ART ")
                        Dim comando_inve_entrada As New SqlCommand(query_inve_entrada.ToString, ActualizarConexion)
                        comando_inve_entrada.Parameters.AddWithValue("@CVE_ART", dt2.Rows(index).Item(2))
                        comando_inve_entrada.Parameters.AddWithValue("@CANTIDAD", dt2.Rows(index).Item(0))
                        comando_inve_entrada.Transaction = transaccion_sql
                        comando_inve_entrada.ExecuteNonQuery()

                        'Flag
                        'Seleccionar los lotes a cargar
                        Dim QueryBuscaLotes As New StringBuilder
                        QueryBuscaLotes.Append("SELECT LOTE, CANT, PEDIMENTO, FCHCADUC, FCHADUANA, NOM_ADUANA, CVE_OBS, CIUDAD, FRONTERA, FEC_PROD_LT, GLN, REMISION, CODIGO, FECHA_REMISION ")
                        QueryBuscaLotes.Append("FROM [Usuarios].[dbo].[GUIA_REMISION_LOTE_SANRAFAEL] ")
                        QueryBuscaLotes.Append(" WHERE CODIGO = @CVE_ART AND REMISION = @REMISION")
                        Dim CMDBuscaLotes As New SqlCommand(QueryBuscaLotes.ToString, ActualizarConexion)

                        CMDBuscaLotes.Parameters.AddWithValue("@REMISION", Doc)
                        CMDBuscaLotes.Parameters.AddWithValue("@CVE_ART", dt2.Rows(index).Item(2))

                        CMDBuscaLotes.Transaction = transaccion_sql
                        Dim ADAPTADORBUSCALOTE As New SqlDataAdapter(CMDBuscaLotes)
                        ADAPTADORBUSCALOTE.Fill(dt_lotes_crear)
                        '

                        'INICIO DE LOS LOTES
                        Dim correlativo_lotes_ENTRADA As Integer = 0
                        If dt2.Rows(index).Item(6) = "S" Then
                            For index2 As Integer = 0 To dt_lotes_crear.Rows.Count - 1
                                If RestanteDev > 0 Then
                                    correlativo_lotes_ENTRADA = 0
                                    'inicio de seleccinar el autonumerico de los enlace lotes
                                    Dim ds_correlativo_lotes As New DataSet
                                    Dim query_correlativo_lotes As New StringBuilder
                                    query_correlativo_lotes.Append("SELECT (ULT_CVE + 1) AS ULT_CVE ")
                                    query_correlativo_lotes.Append("FROM [SAE60Empre07].[dbo].[TBLCONTROL07] ")
                                    query_correlativo_lotes.Append("WHERE (ID_TABLA = 67)")
                                    Dim cmd_select_correlativo_enlace As New SqlCommand(query_correlativo_lotes.ToString, ActualizarConexion)
                                    Dim adapenlace As New SqlDataAdapter(cmd_select_correlativo_enlace)
                                    cmd_select_correlativo_enlace.Transaction = transaccion_sql
                                    adapenlace.Fill(ds_correlativo_lotes)
                                    'fin de seleccionar el autonumerico de los enlace lotes
                                    correlativo_lotes_ENTRADA = Convert.ToInt32(ds_correlativo_lotes.Tables(0).Rows(0)(0))

                                    Dim query_valida_lote As New StringBuilder
                                    query_valida_lote.Append("SELECT CVE_ART,LOTE,REG_LTPD ")
                                    query_valida_lote.Append("FROM [SAE60Empre07].[dbo].[LTPD07] ")
                                    query_valida_lote.Append("WHERE LOTE = @LOTE AND CVE_ALM = @ALMACEN AND CVE_ART = @CVE_ART ")
                                    Dim cmd_valida_lote As New SqlCommand(query_valida_lote.ToString, ActualizarConexion)
                                    cmd_valida_lote.Parameters.AddWithValue("@LOTE", dt_lotes_crear.Rows(index2)(0))
                                    cmd_valida_lote.Parameters.AddWithValue("@ALMACEN", almacen_remite)
                                    cmd_valida_lote.Parameters.AddWithValue("@CVE_ART", dt2.Rows(index).Item(2))
                                    cmd_valida_lote.Transaction = transaccion_sql
                                    Dim adaptador_valida_lote As New SqlDataAdapter(cmd_valida_lote)
                                    Dim dt_valida_lote As New DataTable
                                    adaptador_valida_lote.Fill(dt_valida_lote)

                                    If dt_valida_lote.Rows.Count > 0 Then
                                        'si el lote existe
                                        'hacer el enlace a los lotes
                                        Dim query_enlace_ltpd_ins_entrada As New StringBuilder
                                        query_enlace_ltpd_ins_entrada.Append("INSERT INTO [SAE60Empre07].[dbo].[ENLACE_LTPD07] ")
                                        query_enlace_ltpd_ins_entrada.Append("(E_LTPD,REG_LTPD,CANTIDAD,PXRS) ")
                                        query_enlace_ltpd_ins_entrada.Append("VALUES (@E_LTPD,@REG_LTPD,@CANTIDAD,@PXRS) ")
                                        Dim cmd_enlace_ltpd_ins_entrada As New SqlCommand(query_enlace_ltpd_ins_entrada.ToString, ActualizarConexion)
                                        cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@E_LTPD", correlativo_lotes_ENTRADA)
                                        cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@REG_LTPD", dt_valida_lote.Rows(0)(2))
                                        Dim CantidadGuarda As Decimal = 0
                                        If dt_lotes_crear.Rows(index2)(1) > RestanteDev Then
                                            cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@CANTIDAD", RestanteDev)
                                            cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@PXRS", RestanteDev)
                                            CantidadGuarda = RestanteDev
                                            RestanteDev = 0
                                        Else
                                            cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@CANTIDAD", dt_lotes_crear.Rows(index2)(1))
                                            cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@PXRS", dt_lotes_crear.Rows(index2)(1))
                                            CantidadGuarda = dt_lotes_crear.Rows(index2)(1)
                                            RestanteDev -= dt_lotes_crear.Rows(index2)(1)
                                        End If

                                        cmd_enlace_ltpd_ins_entrada.Transaction = transaccion_sql
                                        cmd_enlace_ltpd_ins_entrada.ExecuteNonQuery()

                                        Dim query_upd_ltpd As New StringBuilder
                                        query_upd_ltpd.Append("UPDATE [SAE60Empre07].[dbo].[LTPD07] ")
                                        query_upd_ltpd.Append("SET [FCHULTMOV] = @FCHULTMOV ")
                                        query_upd_ltpd.Append(",[CANTIDAD] = (CANTIDAD + @NUEVA_CANTIDAD) ")
                                        query_upd_ltpd.Append("WHERE [CVE_ART] = @CVE_ART AND [LOTE] = @LOTE AND [CVE_ALM] = @CVE_ALM ")
                                        Dim cmd_ltpd_upd As New SqlCommand(query_upd_ltpd.ToString, ActualizarConexion)
                                        cmd_ltpd_upd.Parameters.AddWithValue("@FCHULTMOV", Today)
                                        cmd_ltpd_upd.Parameters.AddWithValue("@NUEVA_CANTIDAD", CantidadGuarda)
                                        cmd_ltpd_upd.Parameters.AddWithValue("@CVE_ART", dt2.Rows(index).Item(2))
                                        cmd_ltpd_upd.Parameters.AddWithValue("@LOTE", dt_valida_lote.Rows(0)(1))
                                        cmd_ltpd_upd.Parameters.AddWithValue("@CVE_ALM", almacen_remite)
                                        cmd_ltpd_upd.Transaction = transaccion_sql
                                        cmd_ltpd_upd.ExecuteNonQuery()
                                    Else
                                        'si el lote NO existe
                                        Dim nuevo_reg_ltpd As Integer = 0
                                        'inicio de seleccinar el autonumerico de los lotes
                                        Dim ds_nuevo_reg_ltpd As New DataSet
                                        Dim query_nuevo_reg_ltpd2 As New StringBuilder
                                        query_nuevo_reg_ltpd2.Append("SELECT (ULT_CVE + 1) AS ULT_CVE ")
                                        query_nuevo_reg_ltpd2.Append("FROM [SAE60Empre07].[dbo].[TBLCONTROL07] ")
                                        query_nuevo_reg_ltpd2.Append("WHERE (ID_TABLA = 48)")
                                        Dim cmd_select_nuevo_reg_ltpd2 As New SqlCommand(query_nuevo_reg_ltpd2.ToString, ActualizarConexion)
                                        Dim adapnuevo_reg_ltpd As New SqlDataAdapter(cmd_select_nuevo_reg_ltpd2)
                                        cmd_select_nuevo_reg_ltpd2.Transaction = transaccion_sql
                                        adapnuevo_reg_ltpd.Fill(ds_nuevo_reg_ltpd)
                                        'fin de seleccionar el autonumerico de los lotes
                                        nuevo_reg_ltpd = Convert.ToInt32(ds_nuevo_reg_ltpd.Tables(0).Rows(0)(0))

                                        'hacer el enlace a los lotes
                                        Dim query_enlace_ltpd_ins_entrada As New StringBuilder
                                        query_enlace_ltpd_ins_entrada.Append("INSERT INTO [SAE60Empre07].[dbo].[ENLACE_LTPD07] ")
                                        query_enlace_ltpd_ins_entrada.Append("(E_LTPD,REG_LTPD,CANTIDAD,PXRS) ")
                                        query_enlace_ltpd_ins_entrada.Append("VALUES (@E_LTPD,@REG_LTPD,@CANTIDAD,@PXRS) ")
                                        Dim cmd_enlace_ltpd_ins_entrada As New SqlCommand(query_enlace_ltpd_ins_entrada.ToString, ActualizarConexion)
                                        cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@E_LTPD", correlativo_lotes_ENTRADA)
                                        cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@REG_LTPD", nuevo_reg_ltpd)
                                        Dim CantidadGuarda As Decimal = 0
                                        If dt_lotes_crear.Rows(index2)(1) > RestanteDev Then
                                            cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@CANTIDAD", RestanteDev)
                                            cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@PXRS", RestanteDev)
                                            CantidadGuarda = RestanteDev
                                            RestanteDev -= 0
                                        Else
                                            cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@CANTIDAD", dt_lotes_crear.Rows(index2)(1))
                                            cmd_enlace_ltpd_ins_entrada.Parameters.AddWithValue("@PXRS", dt_lotes_crear.Rows(index2)(1))
                                            CantidadGuarda = dt_lotes_crear.Rows(index2)(1)
                                            RestanteDev -= dt_lotes_crear.Rows(index2)(1)
                                        End If

                                        cmd_enlace_ltpd_ins_entrada.Transaction = transaccion_sql
                                        cmd_enlace_ltpd_ins_entrada.ExecuteNonQuery()
                                        'insertar nuevo lote
                                        Dim query_insertar_nuevo_lote As New StringBuilder
                                        query_insertar_nuevo_lote.Append("INSERT INTO [SAE60Empre07].[dbo].[LTPD07] ")
                                        query_insertar_nuevo_lote.Append("([CVE_ART],[LOTE],[PEDIMENTO],[CVE_ALM],[FCHCADUC],[FCHADUANA] ")
                                        query_insertar_nuevo_lote.Append(",[FCHULTMOV],[NOM_ADUAN],[CANTIDAD],[REG_LTPD],[CVE_OBS] ")
                                        query_insertar_nuevo_lote.Append(",[CIUDAD],[FRONTERA],[FEC_PROD_LT],[GLN],[STATUS]) ")
                                        query_insertar_nuevo_lote.Append("VALUES ")
                                        query_insertar_nuevo_lote.Append("(@CVE_ART,@LOTE,@PEDIMENTO,@CVE_ALM,@FCHCADUC,@FCHADUANA ")
                                        query_insertar_nuevo_lote.Append(",@FCHULTMOV,@NOM_ADUAN,@CANTIDAD,@REG_LTPD,@CVE_OBS,@CIUDAD ")
                                        query_insertar_nuevo_lote.Append(",@FRONTERA,@FEC_PROD_LT,@GLN,@STATUS)")
                                        Dim cmd_insertar_nuevo_lote As New SqlCommand(query_insertar_nuevo_lote.ToString, ActualizarConexion)
                                        cmd_insertar_nuevo_lote.Parameters.AddWithValue("@CVE_ART", dt2.Rows(index).Item(2))
                                        cmd_insertar_nuevo_lote.Parameters.AddWithValue("@LOTE", dt_lotes_crear.Rows(index2)(0))
                                        cmd_insertar_nuevo_lote.Parameters.AddWithValue("@PEDIMENTO", dt_lotes_crear.Rows(index2)(2))
                                        cmd_insertar_nuevo_lote.Parameters.AddWithValue("@CVE_ALM", almacen_remite)

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
                                        cmd_insertar_nuevo_lote.Parameters.AddWithValue("@CANTIDAD", CantidadGuarda)
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
                                        query_actualiza_autonumerico_ltpd.Append("UPDATE [SAE60Empre07].[dbo].[TBLCONTROL07] ")
                                        query_actualiza_autonumerico_ltpd.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                                        query_actualiza_autonumerico_ltpd.Append("WHERE (ID_TABLA = 48) ")
                                        Dim cmd_upd_autonumerico_ltpd As New SqlCommand(query_actualiza_autonumerico_ltpd.ToString, ActualizarConexion)
                                        cmd_upd_autonumerico_ltpd.Transaction = transaccion_sql
                                        cmd_upd_autonumerico_ltpd.ExecuteNonQuery()

                                    End If
                                End If
                            Next

                            'actualizar los correlativos de enlace de lotes
                            Dim query_actualiza_lotes As New StringBuilder
                            query_actualiza_lotes.Append("UPDATE [SAE60Empre07].[dbo].[TBLCONTROL07] ")
                            query_actualiza_lotes.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                            query_actualiza_lotes.Append("WHERE (ID_TABLA = 67) ")
                            Dim cmd_upd_correlativo_lot As New SqlCommand(query_actualiza_lotes.ToString, ActualizarConexion)
                            cmd_upd_correlativo_lot.Transaction = transaccion_sql
                            cmd_upd_correlativo_lot.ExecuteNonQuery()
                        End If


                        'Seleccionar Motivo de Entrada
                        Dim ds_entrada As New DataSet
                        Dim query_entrada As New StringBuilder
                        query_entrada.Append("SELECT MTVOENTRADA ")
                        query_entrada.Append("FROM [Usuarios].[dbo].[GUIA_REMISION_ENCABEZADO_SANRAFAEL] ")
                        query_entrada.Append("WHERE (ID_REMISION = @ID_REMISION) AND (REMITE = @REMITE)")

                        Dim cmd_select_entrada As New SqlCommand(query_entrada.ToString, ActualizarConexion)
                        cmd_select_entrada.Parameters.AddWithValue("@ID_REMISION", Doc)
                        cmd_select_entrada.Parameters.AddWithValue("@REMITE", almacen_remite)

                        Dim adapentrada1 As New SqlDataAdapter(cmd_select_entrada)
                        cmd_select_entrada.Transaction = transaccion_sql
                        adapentrada1.Fill(ds_entrada)
                        Dim MOTIVOENTRADA
                        If ds_entrada.Tables(0).Rows.Count > 0 Then
                            MOTIVOENTRADA = Convert.ToInt32(ds_entrada.Tables(0).Rows(0)(0))
                        Else
                            MOTIVOENTRADA = 7
                        End If

                        'insert MINVE
                        Dim query_minve_entrada As New StringBuilder
                        query_minve_entrada.Append("INSERT INTO [SAE60Empre07].[dbo].[MINVE07] ")
                        query_minve_entrada.Append("   ([CVE_ART],[ALMACEN],[NUM_MOV],[CVE_CPTO],[FECHA_DOCU],[TIPO_DOC],[REFER], ")
                        query_minve_entrada.Append("    [CANT],[CANT_COST],[PRECIO],[COSTO], ")
                        query_minve_entrada.Append("    [REG_SERIE],[UNI_VENTA],[E_LTPD],[EXIST_G],[EXISTENCIA],[TIPO_PROD],[FACTOR_CON], ")
                        query_minve_entrada.Append("    [FECHAELAB],[CVE_FOLIO],[SIGNO],[COSTEADO],[COSTO_PROM_INI], ")
                        query_minve_entrada.Append("    [COSTO_PROM_FIN],[COSTO_PROM_GRAL],[DESDE_INVE],[MOV_ENLAZADO]) ")
                        query_minve_entrada.Append("VALUES ")
                        query_minve_entrada.Append("   (@CVE_ART,@ALMACEN,(SELECT ULT_CVE+1 FROM [SAE60Empre07].[dbo].[TBLCONTROL07] WHERE (ID_TABLA = 44)), ")
                        query_minve_entrada.Append("    @CVE_CPTO,@FECHA_DOCU,'M',@REFER,@CANT,0,0,@COSTO,0, ")
                        query_minve_entrada.Append("    @UNI_VENTA,@E_LTPD, ((SELECT ISNULL(EXIST,0) FROM [SAE60Empre07].[dbo].[INVE07] WHERE CVE_ART = @CVE_ART)), ")
                        query_minve_entrada.Append("    ((SELECT EXIST FROM [SAE60Empre07].[dbo].[MULT07] WHERE (CVE_ART = @CVE_ART) AND CVE_ALM = @ALMACEN)), 'P',1, ")
                        query_minve_entrada.Append("    @FECHAELAB, (SELECT ULT_CVE+1 FROM [SAE60Empre07].[dbo].[TBLCONTROL07] WHERE (ID_TABLA = 32)), 1, 'S', @COSTO_PROM_INI, ")
                        query_minve_entrada.Append("    @COSTO_PROM_FIN, @COSTO_PROM_GRAL, 'S', (SELECT ULT_CVE FROM [SAE60Empre07].[dbo].[TBLCONTROL07] WHERE (ID_TABLA = 44))) ")
                        Dim comando_minve_entrada As New SqlCommand(query_minve_entrada.ToString, ActualizarConexion)
                        comando_minve_entrada.Parameters.AddWithValue("@CVE_ART", dt2.Rows(index).Item(2))
                        comando_minve_entrada.Parameters.AddWithValue("@ALMACEN", almacen_remite)
                        comando_minve_entrada.Parameters.AddWithValue("@CVE_CPTO", MOTIVOENTRADA)
                        comando_minve_entrada.Parameters.AddWithValue("@FECHA_DOCU", Today.Date)
                        comando_minve_entrada.Parameters.AddWithValue("@REFER", Doc)
                        comando_minve_entrada.Parameters.AddWithValue("@CANT", dt2.Rows(index).Item(0))
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
                        query_control_num_mov_entrada.Append("UPDATE [SAE60Empre07].[dbo].[TBLCONTROL07] ")
                        query_control_num_mov_entrada.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                        query_control_num_mov_entrada.Append("WHERE [ID_TABLA] = 44 ")
                        Dim comando_control_num_mov_entrada As New SqlCommand(query_control_num_mov_entrada.ToString, ActualizarConexion)
                        comando_control_num_mov_entrada.Transaction = transaccion_sql
                        comando_control_num_mov_entrada.ExecuteNonQuery()
                    End If
                Next
                'FIN DE MOVIMIENTOS DEL SAE

                'update cve_folio minve
                Dim query_control_folio_DEV As New StringBuilder
                query_control_folio_DEV.Append("UPDATE [SAE60Empre07].[dbo].[TBLCONTROL07] ")
                query_control_folio_DEV.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                query_control_folio_DEV.Append("WHERE ([ID_TABLA] = 32) ")
                Dim comando_control_folio_DEV As New SqlCommand(query_control_folio_DEV.ToString, ActualizarConexion)
                comando_control_folio_DEV.Transaction = transaccion_sql
                comando_control_folio_DEV.ExecuteNonQuery()

            End If

     
            

            Dim conexion_bita As New cls_bitacora_reporteador
            conexion_bita.RegistraBitacora(Now, usuario, "Completó Consignación Flota", "ALMACEN", _
                                      "Remisión: " & Doc & " almacen:" & almacen_remite)

            transaccion_sql.Commit()
            transaccion_sqlConsumo.Commit()
            ActualizarConexion.Close()
            ActualizarConexionConsumo.Close()
            Return "correcto"

        Catch ex As Exception
            transaccion_sql.Rollback()
            transaccion_sqlConsumo.Rollback()
            Dim tamaño As Integer = Convert.ToString(ex.StackTrace).Length
            Dim posicion As Integer = InStrRev(Convert.ToString(ex.StackTrace), "línea") - 1
            Dim inicial As Integer = tamaño - posicion
            Dim linea_error As String = Convert.ToString(ex.StackTrace).Substring(tamaño - inicial, inicial)
            ActualizarConexion.Close()
            ActualizarConexionConsumo.Close()
            Return ex.Message & linea_error
        End Try
    End Function

    Public Function DatosProducto(ByVal Producto As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT  SAE60Empre07.dbo.INVE07.CVE_ART, SAE60Empre07.dbo.INVE07.UNI_ALT, SAE60Empre07.dbo.INVE07.COSTO_PROM, " & _
        "        SAE60Empre07.dbo.PRECIO_X_PROD07.PRECIO, SAE60Empre07.dbo.IMPU07.IMPUESTO4 " & _
        " FROM         SAE60Empre07.dbo.INVE07 INNER JOIN " & _
        "                      SAE60Empre07.dbo.IMPU07 ON SAE60Empre07.dbo.INVE07.CVE_ESQIMPU = SAE60Empre07.dbo.IMPU07.CVE_ESQIMPU INNER JOIN " & _
        "                      SAE60Empre07.dbo.PRECIO_X_PROD07 ON SAE60Empre07.dbo.INVE07.CVE_ART = SAE60Empre07.dbo.PRECIO_X_PROD07.CVE_ART " & _
        "WHERE     (SAE60Empre07.dbo.PRECIO_X_PROD07.CVE_PRECIO = 1) AND SAE60Empre07.dbo.INVE07.CVE_ART = @Producto", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Producto", Producto)

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
