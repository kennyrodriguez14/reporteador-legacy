Imports System.Data.SqlClient
Imports System.Text
Public Class ClsConsignaciones

    Dim CONSUMO As New clsconexion_consumo
    Dim Conexion As New clsConexion
    Dim DIMOSA As New cls_conexion_DIMOSA

    Public Function remision_encabezado(ByVal REMITE As Integer, ByVal INICIO As Date, ByVal FIN As Date)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("dsr_consignaciones_encabezado", ActualizarConexion)
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

        Dim miComando As New SqlCommand("dsr_consignaciones_encabezado_pendiente", ActualizarConexion)
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
                query_mult_salida.Append("UPDATE [SAE60Empre05].[dbo].[MULT05] ")
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
                query_inve.Append("UPDATE [SAE60Empre05].[dbo].[INVE05] ")
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
                    query.Append("FROM [SAE60Empre05].[dbo].[LTPD05] WHERE (STATUS = 'A') AND (CVE_ART = @CVE_ART) AND CVE_ALM = @CVE_ALM")
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
                        query_correlativo_lotes.Append("FROM [SAE60Empre05].[dbo].[TBLCONTROL05] ")
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
                comando_datos_inve.Parameters.AddWithValue("@CVE_ART", dt2.Rows(index).Item(2))
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
                query_control_num_mov.Append("UPDATE [SAE60Empre05].[dbo].[TBLCONTROL05] ")
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
            query_control_folio.Append("UPDATE [SAE60Empre05].[dbo].[TBLCONTROL05] ")
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

    Public Function NUEVASOLICITUDPRODDIMOSA(ByVal dt As DataTable, ByVal dt2 As DataTable, ByVal otro_transportista As Boolean, _
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
                query_mult_salida.Append("UPDATE [SAE60Empre06].[dbo].[MULT06] ")
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
                query_inve.Append("UPDATE [SAE60Empre06].[dbo].[INVE06] ")
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
                    query.Append("FROM [SAE60Empre06].[dbo].[LTPD06] WHERE (STATUS = 'A') AND (CVE_ART = @CVE_ART) AND CVE_ALM = @CVE_ALM")
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
                        query_correlativo_lotes.Append("FROM [SAE60Empre06].[dbo].[TBLCONTROL06] ")
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
                comando_datos_inve.Parameters.AddWithValue("@CVE_ART", dt2.Rows(index).Item(2))
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
                query_control_num_mov.Append("UPDATE [SAE60Empre06].[dbo].[TBLCONTROL06] ")
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
            query_control_folio.Append("UPDATE [SAE60Empre06].[dbo].[TBLCONTROL06] ")
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
                        query_datos_inve.Append("FROM [SAE60Empre05].[dbo].[INVE05] ")
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
                        query_mult_entrada.Append("UPDATE [SAE60Empre05].[dbo].[MULT05] ")
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
                        query_inve_entrada.Append("UPDATE [SAE60Empre05].[dbo].[INVE05] ")
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
                                        query_enlace_ltpd_ins_entrada.Append("INSERT INTO [SAE60Empre05].[dbo].[ENLACE_LTPD05] ")
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
                                        query_upd_ltpd.Append("UPDATE [SAE60Empre05].[dbo].[LTPD05] ")
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
                                        query_insertar_nuevo_lote.Append("INSERT INTO [SAE60Empre05].[dbo].[LTPD05] ")
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
                                        query_actualiza_autonumerico_ltpd.Append("UPDATE [SAE60Empre05].[dbo].[TBLCONTROL05] ")
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
                            query_actualiza_lotes.Append("UPDATE [SAE60Empre05].[dbo].[TBLCONTROL05] ")
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
                        query_control_num_mov_entrada.Append("UPDATE [SAE60Empre05].[dbo].[TBLCONTROL05] ")
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
                query_control_folio_DEV.Append("UPDATE [SAE60Empre05].[dbo].[TBLCONTROL05] ")
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

    Public Function DEVOLVERDIMOSA(ByVal dt As DataTable, ByVal dt2 As DataTable, ByVal usuario As String, ByVal Estado As String, ByVal Documento As String)

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
                        query_datos_inve.Append("FROM [SAE60Empre06].[dbo].[INVE06] ")
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
                        query_mult_entrada.Append("UPDATE [SAE60Empre06].[dbo].[MULT06] ")
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
                        query_inve_entrada.Append("UPDATE [SAE60Empre06].[dbo].[INVE06] ")
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
                                        query_enlace_ltpd_ins_entrada.Append("INSERT INTO [SAE60Empre06].[dbo].[ENLACE_LTPD06] ")
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
                                        query_upd_ltpd.Append("UPDATE [SAE60Empre06].[dbo].[LTPD06] ")
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
                                        query_insertar_nuevo_lote.Append("INSERT INTO [SAE60Empre06].[dbo].[LTPD06] ")
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
                                        query_actualiza_autonumerico_ltpd.Append("UPDATE [SAE60Empre06].[dbo].[TBLCONTROL06] ")
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
                            query_actualiza_lotes.Append("UPDATE [SAE60Empre06].[dbo].[TBLCONTROL06] ")
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
                        query_control_num_mov_entrada.Append("UPDATE [SAE60Empre06].[dbo].[TBLCONTROL06] ")
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
                query_control_folio_DEV.Append("UPDATE [SAE60Empre06].[dbo].[TBLCONTROL06] ")
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
            conexion_bita.RegistraBitacora(Now, usuario, "Devolvió Consignación DIMOSA", "ALMACEN", _
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
                        query_datos_inve.Append("FROM [SAE60Empre05].[dbo].[INVE05] ")
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
                        query_mult_entrada.Append("UPDATE [SAE60Empre05].[dbo].[MULT05] ")
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
                        query_inve_entrada.Append("UPDATE [SAE60Empre05].[dbo].[INVE05] ")
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
                                        query_enlace_ltpd_ins_entrada.Append("INSERT INTO [SAE60Empre05].[dbo].[ENLACE_LTPD05] ")
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
                                        query_upd_ltpd.Append("UPDATE [SAE60Empre05].[dbo].[LTPD05] ")
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
                                        query_insertar_nuevo_lote.Append("INSERT INTO [SAE60Empre05].[dbo].[LTPD05] ")
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
                                        query_actualiza_autonumerico_ltpd.Append("UPDATE [SAE60Empre05].[dbo].[TBLCONTROL05] ")
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
                            query_actualiza_lotes.Append("UPDATE [SAE60Empre05].[dbo].[TBLCONTROL05] ")
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
                        'MOTIVOENTRADA = 14
                        'If ds_entrada.Tables(0).Rows.Count > 0 Then
                        'MOTIVOENTRADA = Convert.ToInt32(ds_entrada.Tables(0).Rows(0)(0))
                        'Else
                        MOTIVOENTRADA = 14
                        'End If

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
                        query_control_num_mov_entrada.Append("UPDATE [SAE60Empre05].[dbo].[TBLCONTROL05] ")
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
                query_control_folio_DEV.Append("UPDATE [SAE60Empre05].[dbo].[TBLCONTROL05] ")
                query_control_folio_DEV.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                query_control_folio_DEV.Append("WHERE ([ID_TABLA] = 32) ")
                Dim comando_control_folio_DEV As New SqlCommand(query_control_folio_DEV.ToString, ActualizarConexion)
                comando_control_folio_DEV.Transaction = transaccion_sql
                comando_control_folio_DEV.ExecuteNonQuery()

            End If

            ''''''''''''''''''''
            'Inicio Facturacion'
            ''''''''''''''''''''

            Dim documento As String = ""
            Dim serie As String = ""
            If almacen_remite = 1 Then
                serie = "00-001-01-"
            ElseIf almacen_remite = 2 Then
                serie = "01-001-01-"
            ElseIf almacen_remite = 3 Then
                serie = "02-001-01-"
            ElseIf almacen_remite = 4 Then
                serie = "03-001-01"
            End If

            Dim ULTDOC As Integer = 0
            Dim dt_ULTDOC As New DataTable
            Dim query_ULTDOC As New StringBuilder
            query_ULTDOC.Append("SELECT ULT_DOC FROM SAE60EMPRE05.dbo.FOLIOSF05 WHERE (SERIE = @SERIE) ")
            Dim cmd_select_ULTDOC As New SqlCommand(query_ULTDOC.ToString, ActualizarConexion)
            cmd_select_ULTDOC.Parameters.AddWithValue("@SERIE", serie)
            Dim adaptador_ULTDOC As New SqlDataAdapter(cmd_select_ULTDOC)
            cmd_select_ULTDOC.Transaction = transaccion_sql
            adaptador_ULTDOC.Fill(dt_ULTDOC)
            ULTDOC = dt_ULTDOC(0)(0)

            Dim TOTALFACTURA As Decimal = 0
            Dim SubTotalFactura As Decimal = 0
            Dim ImpTot As Decimal = 0

            For a As Integer = 0 To dt2.Rows.Count - 1
                If dt2(a)(0) > "0" Then
                    Dim ImpInd As Decimal = dt2(a)(14)
                    ImpTot = ImpTot + ImpInd
                    SubTotalFactura = SubTotalFactura + dt2(a)(12)
                End If
            Next

            TOTALFACTURA = SubTotalFactura + ImpTot

            Dim dt_cliente As New DataTable
            Dim query_cliente As New StringBuilder
            query_cliente.Append(" SELECT CLAVE, NOMBRE, RFC, CALLE, NUMEXT, CRUZAMIENTOS, CRUZAMIENTOS2, COLONIA, CODIGO, LOCALIDAD, MUNICIPIO, ESTADO, PAIS, NACIONALIDAD, ")
            query_cliente.Append(" REFERDIR, TELEFONO, CLASIFIC, FAX, PAG_WEB, CURP, CVE_ZONA, IMPRIR, MAIL, NIVELSEC, ENVIOSILEN, EMAILPRED, DIAREV, DIAPAGO, CON_CREDITO, ")
            query_cliente.Append(" DIASCRED, LIMCRED, SALDO, LISTA_PREC, CVE_BITA, ULT_PAGOD, ULT_PAGOM, ULT_PAGOF, DESCUENTO, ULT_VENTAD, ULT_COMPM, FCH_ULTCOM, VENTAS, ")
            query_cliente.Append(" CVE_VEND, CVE_OBS, TIPO_EMPRESA FROM CLIE05 WHERE CLAVE = @CLAVE")

            Dim cmd_select_cliente As New SqlCommand(query_cliente.ToString, ActualizarConexionConsumo)
            cmd_select_cliente.Parameters.AddWithValue("@CLAVE", CLiente)
            Dim adaptador_cliente As New SqlDataAdapter(cmd_select_cliente)
            cmd_select_cliente.Transaction = transaccion_sqlConsumo
            adaptador_cliente.Fill(dt_cliente)

            Dim CveVend As String = dt_cliente(0)(42)


            Dim folio As Integer = ULTDOC
            Dim ceros As String = ""
            folio += 1
            For largo As Integer = 0 To (8 - Convert.ToString(folio).Length) - 1
                ceros += "0"
            Next
            documento = (serie & ceros) + Convert.ToString(folio)
            'inicio de las facturas del lote
            'campos libres de las facturas
            Dim sq_query_camplib As New StringBuilder()
            sq_query_camplib.Append("INSERT INTO FACTF_CLIB05 ([CLAVE_DOC],[CAMPLIB16],[CAMPLIB17],[CAMPLIB18],[CAMPLIB19]) ")
            sq_query_camplib.Append("VALUES (@CLAVE_DOC,@CAMPLIB16,@CAMPLIB17,@CAMPLIB18,@CAMPLIB19) ")
            Dim cmd_factf_clib As New SqlCommand(sq_query_camplib.ToString(), ActualizarConexionConsumo)
            cmd_factf_clib.Parameters.AddWithValue("@CLAVE_DOC", documento)
            cmd_factf_clib.Parameters.AddWithValue("@CAMPLIB16", Identidad)
            cmd_factf_clib.Parameters.AddWithValue("@CAMPLIB17", Entregador)
            cmd_factf_clib.Parameters.AddWithValue("@CAMPLIB18", Placa)
            cmd_factf_clib.Parameters.AddWithValue("@CAMPLIB19", Modelo)
            cmd_factf_clib.Transaction = transaccion_sqlConsumo
            cmd_factf_clib.ExecuteNonQuery()

            'ins de cuen m
            Dim sq_query_ins_cuen_m As New StringBuilder()
            sq_query_ins_cuen_m.Append("INSERT INTO CUEN_M05 ([CVE_CLIE],[REFER],[NUM_CPTO],[NUM_CARGO],[CVE_OBS],[NO_FACTURA] ")
            sq_query_ins_cuen_m.Append(",[DOCTO],[IMPORTE],[FECHA_APLI],[FECHA_VENC],[AFEC_COI],[STRCVEVEND],[NUM_MONED],[TCAMBIO] ")
            sq_query_ins_cuen_m.Append(",[IMPMON_EXT],[FECHAELAB],[TIPO_MOV],[SIGNO],[USUARIO],[ENTREGADA],[FECHA_ENTREGA],[STATUS]) ")
            sq_query_ins_cuen_m.Append("VALUES (@CVE_CLIE,@REFER,'1','1','0',@NO_FACTURA,@DOCTO,@IMPORTE,@FECHA_APLI,@FECHA_VENC,'A' ")
            sq_query_ins_cuen_m.Append(", @STRCVEVEND,'1','1',@IMPMON_EXT,@FECHAELAB,'C','1',@USUARIO,@ENTREGADA,@FECHA_ENTREGA,'A') ")
            Dim cmd_cuen_m As New SqlCommand(sq_query_ins_cuen_m.ToString(), ActualizarConexionConsumo)
            cmd_cuen_m.Parameters.AddWithValue("@CVE_CLIE", CLiente)
            cmd_cuen_m.Parameters.AddWithValue("@REFER", documento)
            cmd_cuen_m.Parameters.AddWithValue("@NO_FACTURA", documento)
            cmd_cuen_m.Parameters.AddWithValue("@DOCTO", documento)
            cmd_cuen_m.Parameters.AddWithValue("@IMPORTE", TOTALFACTURA)
            cmd_cuen_m.Parameters.AddWithValue("@FECHA_APLI", Today.Date)
            Dim fecha_venc As DateTime
            fecha_venc = Today.Date
            cmd_cuen_m.Parameters.AddWithValue("@FECHA_VENC", fecha_venc.[Date])
            cmd_cuen_m.Parameters.AddWithValue("@STRCVEVEND", CveVend)
            cmd_cuen_m.Parameters.AddWithValue("@IMPMON_EXT", TOTALFACTURA)
            cmd_cuen_m.Parameters.AddWithValue("@FECHAELAB", Today.Date)
            cmd_cuen_m.Parameters.AddWithValue("@USUARIO", "0")

            cmd_cuen_m.Parameters.AddWithValue("@ENTREGADA", "S")
            cmd_cuen_m.Parameters.AddWithValue("@FECHA_ENTREGA", Today.Date)

            cmd_cuen_m.Transaction = transaccion_sqlConsumo
            cmd_cuen_m.ExecuteNonQuery()
            'ins de cuen det solo cuando el tipo de pago es de contado
            Dim TipoPago = "Contado"
            If Convert.ToString(TipoPago) = "Contado" Then
                Dim sq_query_ins_cuen_det As New StringBuilder()
                sq_query_ins_cuen_det.Append("INSERT INTO CUEN_DET05 ([CVE_CLIE],[REFER],[ID_MOV],[NUM_CPTO],[NUM_CARGO],[CVE_OBS],")
                sq_query_ins_cuen_det.Append("[NO_FACTURA],[DOCTO],[IMPORTE],[FECHA_APLI],[FECHA_VENC],[STRCVEVEND],[NUM_MONED],[TCAMBIO], ")
                sq_query_ins_cuen_det.Append("[IMPMON_EXT],[FECHAELAB],[CTLPOL],[CVE_FOLIO],[TIPO_MOV],[SIGNO],[CVE_AUT],[USUARIO],[NO_PARTIDA]) ")
                sq_query_ins_cuen_det.Append("VALUES (@CVE_CLIE,@REFER,@ID_MOV,'10','1','0',@NO_FACTURA,'',@IMPORTE, @FECHA_APLI,@FECHA_VENC, ")
                sq_query_ins_cuen_det.Append("@STRCVEVEND,'1','1',@IMPMON_EXT,@FECHAELAB,'0',@CVE_FOLIO,'A','-1','0',@USUARIO,'1') ")
                Dim cmd_cuen_det As New SqlCommand(sq_query_ins_cuen_det.ToString(), ActualizarConexionConsumo)
                cmd_cuen_det.Parameters.AddWithValue("@CVE_CLIE", CLiente)
                cmd_cuen_det.Parameters.AddWithValue("@REFER", documento)
                cmd_cuen_det.Parameters.AddWithValue("@ID_MOV", "1")
                cmd_cuen_det.Parameters.AddWithValue("@NO_FACTURA", documento)
                cmd_cuen_det.Parameters.AddWithValue("@IMPORTE", TOTALFACTURA)
                cmd_cuen_det.Parameters.AddWithValue("@FECHA_APLI", Today.[Date])
                cmd_cuen_det.Parameters.AddWithValue("@FECHA_VENC", Today.[Date])
                cmd_cuen_det.Parameters.AddWithValue("@STRCVEVEND", CveVend)
                cmd_cuen_det.Parameters.AddWithValue("@IMPMON_EXT", TOTALFACTURA)
                cmd_cuen_det.Parameters.AddWithValue("@FECHAELAB", Today.Date)
                cmd_cuen_det.Parameters.AddWithValue("@CVE_FOLIO", folio)
                cmd_cuen_det.Parameters.AddWithValue("@USUARIO", 0)
                cmd_cuen_det.Transaction = transaccion_sqlConsumo
                cmd_cuen_det.ExecuteNonQuery()
            End If
            'ins de bitacora de los clientes
            Dim sq_query_ins_bita As New StringBuilder()
            sq_query_ins_bita.Append("INSERT INTO BITA05 ([CVE_BITA],[CVE_CLIE],[CVE_CAMPANIA],[CVE_ACTIVIDAD] ")
            sq_query_ins_bita.Append(",[FECHAHORA],[CVE_USUARIO],[OBSERVACIONES],[STATUS],[NOM_USUARIO]) ")
            sq_query_ins_bita.Append("VALUES ((SELECT ULT_CVE + 1 AS ULT_CVE FROM TBLCONTROL05 WHERE (ID_TABLA = 62)),@CVE_CLIE,")
            sq_query_ins_bita.Append("@CVE_CAMPANIA,@CVE_ACTIVIDAD,@FECHAHORA,@CVE_USUARIO,@OBSERVACIONES,@STATUS,@NOM_USUARIO) ")
            Dim cmd_bita As New SqlCommand(sq_query_ins_bita.ToString(), ActualizarConexionConsumo)
            cmd_bita.Parameters.AddWithValue("@CVE_CLIE", CLiente)
            cmd_bita.Parameters.AddWithValue("@CVE_CAMPANIA", "_SAE_")
            cmd_bita.Parameters.AddWithValue("@CVE_ACTIVIDAD", "    2")
            cmd_bita.Parameters.AddWithValue("@FECHAHORA", Today.Date)
            cmd_bita.Parameters.AddWithValue("@CVE_USUARIO", 0)
            cmd_bita.Parameters.AddWithValue("@OBSERVACIONES", (Convert.ToString("No.[") & documento) + "] L " & TOTALFACTURA)
            cmd_bita.Parameters.AddWithValue("@STATUS", "F")
            cmd_bita.Parameters.AddWithValue("@NOM_USUARIO", 0)
            cmd_bita.Transaction = transaccion_sqlConsumo
            cmd_bita.ExecuteNonQuery()

            'ins de encabezados de facturas
            Dim sq_query_ins_factf As New StringBuilder()
            sq_query_ins_factf.Append("INSERT INTO FACTF05 ([TIP_DOC],[CVE_DOC],[CVE_CLPV],[STATUS],[DAT_MOSTR],[CVE_VEND],[CVE_PEDI],")
            sq_query_ins_factf.Append("[FECHA_DOC] ,[FECHA_ENT],[FECHA_VEN],[CAN_TOT],[IMP_TOT1],[IMP_TOT2],[IMP_TOT3],[IMP_TOT4] ")
            sq_query_ins_factf.Append(",[DES_TOT],[DES_FIN],[COM_TOT],CONDICION,[CVE_OBS],[NUM_ALMA],[ACT_CXC],[ACT_COI],[ENLAZADO]" & vbTab)
            sq_query_ins_factf.Append(",[TIP_DOC_E],[NUM_MONED],[TIPCAMB],[NUM_PAGOS],[FECHAELAB],[PRIMERPAGO],[RFC],[CTLPOL],[ESCFD],")
            sq_query_ins_factf.Append("[AUTORIZA],[SERIE],[FOLIO],[AUTOANIO],[DAT_ENVIO],[CONTADO],[CVE_BITA],[BLOQ],[FORMAENVIO],[DES_FIN_PORC], ")
            sq_query_ins_factf.Append("[DES_TOT_PORC],[IMPORTE],[COM_TOT_PORC],[METODODEPAGO],[NUMCTAPAGO],[TIP_DOC_ANT],[DOC_ANT]) ")
            sq_query_ins_factf.Append("VALUES" & vbTab & "('F',@CVE_DOC,@CVE_CLPV,'O','0',@CVE_VEND,@CVE_PEDI,@FECHA_DOC,@FECHA_ENT,@FECHA_VEN,@CAN_TOT, ")
            sq_query_ins_factf.Append("'0','0','0',@IMP_TOT4,@DES_TOT,'0','0',@CONDICION,'0',@NUM_ALMA,'S','N','O','O','1','1','1',@FECHAELAB,")
            sq_query_ins_factf.Append("@PRIMERPAGO,@RFC,@CTLPOL,'N',@AUTORIZA,@SERIE,@FOLIO,@AUTOANIO,'0',@CONTADO,(SELECT ULT_CVE + 1 AS ULT_CVE")
            sq_query_ins_factf.Append(" FROM TBLCONTROL05 WHERE (ID_TABLA = 62)),'N','I','0',@DES_TOT_PORC,@IMPORTE,'0',@METODODEPAGO,'','','')")
            Dim cmd_factf As New SqlCommand(sq_query_ins_factf.ToString(), ActualizarConexionConsumo)
            cmd_factf.Parameters.AddWithValue("@CVE_DOC", documento)
            cmd_factf.Parameters.AddWithValue("@CVE_CLPV", CLiente)
            cmd_factf.Parameters.AddWithValue("@CVE_VEND", CveVend)
            cmd_factf.Parameters.AddWithValue("@CVE_PEDI", Vehiculo)
            cmd_factf.Parameters.AddWithValue("@FECHA_DOC", Today.[Date])
            cmd_factf.Parameters.AddWithValue("@FECHA_ENT", Today.[Date])
            Dim fecha_vencimiento_factura As DateTime
            fecha_vencimiento_factura = Today.Date
            If TipoPago = "Credito" Then
                fecha_vencimiento_factura = fecha_vencimiento_factura.AddDays(Convert.ToDouble((dt_cliente)(29)))
            End If
            cmd_factf.Parameters.AddWithValue("@FECHA_VEN", fecha_vencimiento_factura.[Date])
            cmd_factf.Parameters.AddWithValue("@CAN_TOT", SubTotalFactura)
            cmd_factf.Parameters.AddWithValue("@IMP_TOT4", ImpTot)
            cmd_factf.Parameters.AddWithValue("@DES_TOT", 0)
            cmd_factf.Parameters.AddWithValue("@CONDICION", ClaveEntregador)
            cmd_factf.Parameters.AddWithValue("@NUM_ALMA", almacen_remite)
            cmd_factf.Parameters.AddWithValue("@FECHAELAB", Today.Date)
            If TipoPago = "Credito" Then
                cmd_factf.Parameters.AddWithValue("@PRIMERPAGO", 0)
            Else
                cmd_factf.Parameters.AddWithValue("@PRIMERPAGO", TOTALFACTURA)
            End If
            cmd_factf.Parameters.AddWithValue("@RFC", dt_cliente(0)(2))
            cmd_factf.Parameters.AddWithValue("@CTLPOL", "")
            cmd_factf.Parameters.AddWithValue("@AUTORIZA", "")
            cmd_factf.Parameters.AddWithValue("@SERIE", serie)
            cmd_factf.Parameters.AddWithValue("@FOLIO", folio)
            cmd_factf.Parameters.AddWithValue("@AUTOANIO", "")
            If TipoPago = "Credito" Then
                cmd_factf.Parameters.AddWithValue("@CONTADO", "N")
            Else
                cmd_factf.Parameters.AddWithValue("@CONTADO", "S")
            End If
            cmd_factf.Parameters.AddWithValue("@DES_TOT_PORC", 0)
            cmd_factf.Parameters.AddWithValue("@IMPORTE", TOTALFACTURA)
            If TipoPago = "Credito" Then
                cmd_factf.Parameters.AddWithValue("@METODODEPAGO", "")
            Else
                cmd_factf.Parameters.AddWithValue("@METODODEPAGO", "Efectivo")
            End If
            cmd_factf.Transaction = transaccion_sqlConsumo
            cmd_factf.ExecuteNonQuery()

            'actualizar los correlativos de LA BITACORA
            Dim sq_query_up_tbc1 As New StringBuilder()
            sq_query_up_tbc1.Append("UPDATE TBLCONTROL05 SET [ULT_CVE] = ULT_CVE + 1 WHERE (ID_TABLA = 62)")
            Dim upd_correlativo_bita As New SqlCommand(sq_query_up_tbc1.ToString(), ActualizarConexionConsumo)
            upd_correlativo_bita.Transaction = transaccion_sqlConsumo
            upd_correlativo_bita.ExecuteNonQuery()

            'upd para actualizar saldos de clientes
            If Convert.ToString(TipoPago) = "Credito" Then
                Dim sq_query_up_clie As New StringBuilder()
                sq_query_up_clie.Append("UPDATE CLIE05 SET [SALDO] = (SALDO + @NUEVOSALDO),[ULT_VENTAD] = @ULT_VENTAD ")
                sq_query_up_clie.Append(",[ULT_COMPM] = @ULT_COMPM,[FCH_ULTCOM] = @FCH_ULTCOM, [VENTAS] = VENTAS + @VENTAS_NUEVAS ")
                sq_query_up_clie.Append("WHERE [CLAVE] = @CLAVE ")
                Dim cmd_upd_clie As New SqlCommand(sq_query_up_clie.ToString(), ActualizarConexionConsumo)
                cmd_upd_clie.Parameters.AddWithValue("@NUEVOSALDO", TOTALFACTURA)
                cmd_upd_clie.Parameters.AddWithValue("@ULT_VENTAD", documento)
                cmd_upd_clie.Parameters.AddWithValue("@ULT_COMPM", TOTALFACTURA)
                cmd_upd_clie.Parameters.AddWithValue("@FCH_ULTCOM", Today.[Date])
                cmd_upd_clie.Parameters.AddWithValue("@VENTAS_NUEVAS", TOTALFACTURA)
                cmd_upd_clie.Parameters.AddWithValue("@CLAVE", CLiente)
                cmd_upd_clie.Transaction = transaccion_sqlConsumo
                cmd_upd_clie.ExecuteNonQuery()
            Else
                Dim sq_query_up_clie2 As New StringBuilder()
                sq_query_up_clie2.Append("UPDATE CLIE05 SET [SALDO] = (SALDO + @NUEVOSALDO),[ULT_PAGOD] = @ULT_PAGOD,[ULT_PAGOM] = @ULT_PAGOM, ")
                sq_query_up_clie2.Append("[ULT_PAGOF] = @ULT_PAGOF, [ULT_VENTAD] = @ULT_VENTAD ,[ULT_COMPM] = @ULT_COMPM, ")
                sq_query_up_clie2.Append("[FCH_ULTCOM] = @FCH_ULTCOM, [VENTAS] = VENTAS + @VENTAS_NUEVAS WHERE [CLAVE] = @CLAVE ")
                Dim cmd_upd_clie As New SqlCommand(sq_query_up_clie2.ToString(), ActualizarConexionConsumo)
                cmd_upd_clie.Parameters.AddWithValue("@NUEVOSALDO", "0")
                cmd_upd_clie.Parameters.AddWithValue("@ULT_PAGOD", documento)
                cmd_upd_clie.Parameters.AddWithValue("@ULT_PAGOM", TOTALFACTURA)
                cmd_upd_clie.Parameters.AddWithValue("@ULT_PAGOF", Today.[Date])
                cmd_upd_clie.Parameters.AddWithValue("@ULT_VENTAD", documento)
                cmd_upd_clie.Parameters.AddWithValue("@ULT_COMPM", TOTALFACTURA)
                cmd_upd_clie.Parameters.AddWithValue("@FCH_ULTCOM", Today.[Date])
                cmd_upd_clie.Parameters.AddWithValue("@VENTAS_NUEVAS", TOTALFACTURA)
                cmd_upd_clie.Parameters.AddWithValue("@CLAVE", CLiente)
                cmd_upd_clie.Transaction = transaccion_sqlConsumo
                cmd_upd_clie.ExecuteNonQuery()
            End If
            'Partidas
            For contador_partidas As Integer = 0 To dt2.Rows.Count - 1
                Dim CantG As Decimal = dt2(contador_partidas)(7)
                Dim correlativo_lotes As Integer = 0
                If Convert.ToString(dt2.Rows(contador_partidas)(0)) = "" Then
                Else
                    ' inicio para actualizar los lotes
                    'seleccionar los lotes disponibles del sae
                    If Convert.ToString(dt2.Rows(contador_partidas)(0)) = "S" Then
                        Dim ds_lotes As New DataSet()
                        Dim cantidad As Double = 0, can_insertar As Double = 0
                        Dim sq_query_select_ltpd As New StringBuilder()
                        sq_query_select_ltpd.Append("SELECT LOTE, CVE_ALM, FCHCADUC, CANTIDAD, REG_LTPD FROM LTPD05 WHERE (STATUS = 'A') ")
                        sq_query_select_ltpd.Append(" AND (CVE_ART = @CVE_ART) AND CVE_ALM = @CVE_ALM AND (CANTIDAD > 0) AND ")
                        sq_query_select_ltpd.Append("(FCHCADUC > GETDATE() OR FCHCADUC IS NULL OR FCHCADUC = '') ORDER BY FCHCADUC ")
                        Dim cmd_select_lotes As New SqlCommand(sq_query_select_ltpd.ToString(), ActualizarConexionConsumo)
                        cmd_select_lotes.Parameters.AddWithValue("@CVE_ART", dt2(contador_partidas)(2))
                        cmd_select_lotes.Parameters.AddWithValue("@CVE_ALM", almacen_remite)
                        Dim Adaptador As New SqlDataAdapter(cmd_select_lotes)
                        cmd_select_lotes.Transaction = transaccion_sqlConsumo
                        Adaptador.Fill(ds_lotes, "Lotes")
                        cantidad = Convert.ToDouble(dt2.Rows(contador_partidas)(7))

                        For i As Integer = 0 To ds_lotes.Tables(0).Rows.Count - 1
                            'inicio de seleccinar el autonumerico de los enlace lotes
                            Dim ds_correlattivo_lotes As New DataSet()
                            Dim sq_query_select_correlativo_lt As New StringBuilder()
                            sq_query_select_correlativo_lt.Append("SELECT (ULT_CVE + 1) AS ULT_CVE FROM TBLCONTROL05 WHERE (ID_TABLA = 67) ")
                            Dim cmd_select_correlativo_enlace As New SqlCommand(sq_query_select_correlativo_lt.ToString(), ActualizarConexionConsumo)
                            Dim Adapenlace As New SqlDataAdapter(cmd_select_correlativo_enlace)
                            cmd_select_correlativo_enlace.Transaction = transaccion_sqlConsumo
                            Adapenlace.Fill(ds_correlattivo_lotes, "Lotes")
                            'fin de seleccionar el autonumerico de los enlace lotes
                            correlativo_lotes = Convert.ToInt32(ds_correlattivo_lotes.Tables(0).Rows(0)(0))

                            If Convert.ToDouble(ds_lotes.Tables(0).Rows(i)(3)) >= cantidad Then
                                can_insertar = cantidad
                                'hacer el enlace a los lotes
                                Dim sq_query_ins_enlace_ltp As New StringBuilder()
                                sq_query_ins_enlace_ltp.Append("INSERT INTO ENLACE_LTPD05 (E_LTPD,REG_LTPD,CANTIDAD,PXRS) ")
                                sq_query_ins_enlace_ltp.Append("VALUES (@E_LTPD,@REG_LTPD,@CANTIDAD,@PXRS) ")
                                Dim cmd_enlace_ltpd As New SqlCommand(sq_query_ins_enlace_ltp.ToString(), ActualizarConexionConsumo)
                                cmd_enlace_ltpd.Parameters.AddWithValue("@E_LTPD", correlativo_lotes)
                                cmd_enlace_ltpd.Parameters.AddWithValue("@REG_LTPD", Convert.ToInt32(ds_lotes.Tables(0).Rows(i)(4)))
                                cmd_enlace_ltpd.Parameters.AddWithValue("@CANTIDAD", cantidad)
                                cmd_enlace_ltpd.Parameters.AddWithValue("@PXRS", cantidad)
                                cmd_enlace_ltpd.Transaction = transaccion_sqlConsumo
                                cmd_enlace_ltpd.ExecuteNonQuery()
                                'actualizar las existencias en los lotes
                                Dim sq_query_upd_lt As New StringBuilder()
                                sq_query_upd_lt.Append("UPDATE LTPD05 SET [FCHULTMOV] = @FCHULTMOV ")
                                sq_query_upd_lt.Append(",[CANTIDAD] = (CANTIDAD - @NUEVA_CANTIDAD) ")
                                sq_query_upd_lt.Append("WHERE [CVE_ART] = @CVE_ART AND [LOTE] = @LOTE AND [CVE_ALM] = @CVE_ALM ")
                                Dim cmd_ltpd As New SqlCommand(sq_query_upd_lt.ToString(), ActualizarConexionConsumo)
                                cmd_ltpd.Parameters.AddWithValue("@FCHULTMOV", Today.Date)
                                cmd_ltpd.Parameters.AddWithValue("@NUEVA_CANTIDAD", cantidad)
                                cmd_ltpd.Parameters.AddWithValue("@CVE_ART", dt2(contador_partidas)(2))
                                cmd_ltpd.Parameters.AddWithValue("@LOTE", Convert.ToString(ds_lotes.Tables(0).Rows(i)(0)))
                                cmd_ltpd.Parameters.AddWithValue("@CVE_ALM", almacen_remite)
                                cmd_ltpd.Transaction = transaccion_sqlConsumo
                                cmd_ltpd.ExecuteNonQuery()
                                i = ds_lotes.Tables(0).Rows.Count
                            Else
                                can_insertar = (Convert.ToDouble(ds_lotes.Tables(0).Rows(i)(3)) - Convert.ToDouble(dt2(contador_partidas)(7))) + Convert.ToDouble(dt2(contador_partidas)(7))
                                'hacer el enlace a los lotes
                                Dim sq_query_ins_enlace_ltpd As New StringBuilder()
                                sq_query_ins_enlace_ltpd.Append("INSERT INTO ENLACE_LTPD05 (E_LTPD,REG_LTPD,CANTIDAD,PXRS) ")
                                sq_query_ins_enlace_ltpd.Append("VALUES (@E_LTPD,@REG_LTPD,@CANTIDAD,@PXRS) ")
                                Dim cmd_enlace_ltpd As New SqlCommand(sq_query_ins_enlace_ltpd.ToString(), ActualizarConexionConsumo)
                                cmd_enlace_ltpd.Parameters.AddWithValue("@E_LTPD", correlativo_lotes)
                                cmd_enlace_ltpd.Parameters.AddWithValue("@REG_LTPD", Convert.ToInt32(ds_lotes.Tables(0).Rows(i)(4)))
                                cmd_enlace_ltpd.Parameters.AddWithValue("@CANTIDAD", can_insertar)
                                cmd_enlace_ltpd.Parameters.AddWithValue("@PXRS", can_insertar)
                                cmd_enlace_ltpd.Transaction = transaccion_sqlConsumo
                                cmd_enlace_ltpd.ExecuteNonQuery()

                                'actualizar las existencias en los lotes
                                Dim sq_query_upd_ltd As New StringBuilder()
                                sq_query_upd_ltd.Append("UPDATE LTPD05 SET [FCHULTMOV] = @FCHULTMOV ,[CANTIDAD] = (CANTIDAD - @NUEVA_CANTIDAD) ")
                                sq_query_upd_ltd.Append("WHERE [CVE_ART] = @CVE_ART AND [LOTE] = @LOTE AND [CVE_ALM] = @CVE_ALM ")
                                Dim cmd_ltpd As New SqlCommand(sq_query_upd_ltd.ToString(), ActualizarConexionConsumo)
                                cmd_ltpd.Parameters.AddWithValue("@FCHULTMOV", Today.Date)
                                cmd_ltpd.Parameters.AddWithValue("@NUEVA_CANTIDAD", can_insertar)
                                cmd_ltpd.Parameters.AddWithValue("@CVE_ART", dt2(contador_partidas)(2))
                                cmd_ltpd.Parameters.AddWithValue("@LOTE", Convert.ToString(ds_lotes.Tables(0).Rows(i)(0)))
                                cmd_ltpd.Parameters.AddWithValue("@CVE_ALM", almacen_remite)
                                cmd_ltpd.Transaction = transaccion_sqlConsumo
                                cmd_ltpd.ExecuteNonQuery()
                                cantidad = cantidad - Convert.ToInt32(ds_lotes.Tables(0).Rows(i)(3))
                                can_insertar = cantidad
                            End If
                        Next
                        'actualizar los correlativos de los lotes
                        Dim sq_query_tbl_c2 As New StringBuilder()
                        sq_query_tbl_c2.Append("UPDATE TBLCONTROL05 SET [ULT_CVE] = ULT_CVE + 1 WHERE (ID_TABLA = 67) ")
                        Dim upd_correlativo_ltpd As New SqlCommand(sq_query_tbl_c2.ToString(), ActualizarConexionConsumo)
                        upd_correlativo_ltpd.Transaction = transaccion_sqlConsumo
                        upd_correlativo_ltpd.ExecuteNonQuery()
                    End If
                    'fin de actualizar los lotes
                    'upd para actualizar existencias de inventarios
                    Dim sq_query_upd_inv As New StringBuilder()
                    sq_query_upd_inv.Append("UPDATE SAE60Empre05.dbo.INVE05 SET [FCH_ULTVTA] = @FCH_ULTVTA,[EXIST] = (EXIST - @NUEVA_EXISTENCIA), ")
                    sq_query_upd_inv.Append("[VTAS_ANL_C] = (VTAS_ANL_C+@VTAS_ANL_C),[VTAS_ANL_M] = (VTAS_ANL_M+@VTAS_ANL_M) ")
                    sq_query_upd_inv.Append("WHERE [CVE_ART] = @CVE_ART ")
                    Dim cmd_upd_inve As New SqlCommand(sq_query_upd_inv.ToString(), ActualizarConexion)
                    cmd_upd_inve.Parameters.AddWithValue("@FCH_ULTVTA", Today.[Date])
                    cmd_upd_inve.Parameters.AddWithValue("@CVE_ART", dt2(contador_partidas)(2))
                    cmd_upd_inve.Parameters.AddWithValue("VTAS_ANL_M", "0")
                    cmd_upd_inve.Parameters.AddWithValue("@VTAS_ANL_C", dt2(contador_partidas)(7))
                    cmd_upd_inve.Parameters.AddWithValue("@NUEVA_EXISTENCIA", dt2(contador_partidas)(7))
                    cmd_upd_inve.Transaction = transaccion_sql
                    cmd_upd_inve.ExecuteNonQuery()
                    'upd para actualizar existencias de multialmacenes
                    'update MULT
                    Dim query_mult_entrada2 As New StringBuilder
                    query_mult_entrada2.Append("UPDATE [SAE60Empre05].[dbo].[MULT05] ")
                    query_mult_entrada2.Append("SET [EXIST] = ISNULL(EXIST,0) - @CANTIDAD ")
                    query_mult_entrada2.Append("WHERE [CVE_ART] = @CVE_ART AND [CVE_ALM] = @CVE_ALM ")
                    Dim comando_mult_entrada2 As New SqlCommand(query_mult_entrada2.ToString, ActualizarConexion)
                    comando_mult_entrada2.Parameters.AddWithValue("@CVE_ART", dt2.Rows(contador_partidas).Item(2))
                    comando_mult_entrada2.Parameters.AddWithValue("@CVE_ALM", almacen_remite)
                    comando_mult_entrada2.Parameters.AddWithValue("@CANTIDAD", dt2.Rows(contador_partidas).Item(7))
                    comando_mult_entrada2.Transaction = transaccion_sql
                    comando_mult_entrada2.ExecuteNonQuery()
                    'ins de encabezados de facturas
                    Dim sq_query_ins_par_factf As New StringBuilder()
                    sq_query_ins_par_factf.Append("INSERT INTO SAE60Empre05.dbo.PAR_FACTF05 ([CVE_DOC],[NUM_PAR],[CVE_ART],[CANT],[PXS],[PREC],[COST],[IMPU1],")
                    sq_query_ins_par_factf.Append("[IMPU2],[IMPU3],[IMPU4],[IMP1APLA],[IMP2APLA],[IMP3APLA],[IMP4APLA],[TOTIMP1],[TOTIMP2], ")
                    sq_query_ins_par_factf.Append("[TOTIMP3],[TOTIMP4],[DESC1],[DESC2],[DESC3],[COMI],[APAR],[ACT_INV],[NUM_ALM],[POLIT_APLI],")
                    sq_query_ins_par_factf.Append("[TIP_CAM],[UNI_VENTA],[TIPO_PROD],[CVE_OBS],[REG_SERIE],[E_LTPD],[TIPO_ELEM],[NUM_MOV], ")
                    sq_query_ins_par_factf.Append("[TOT_PARTIDA],[IMPRIMIR]) VALUES (@CVE_DOC,@NUM_PAR,@CVE_ART,@CANT,@PXS,@PREC,@COST,'0', ")
                    sq_query_ins_par_factf.Append("'0','0',@IMPU4,'0', '0','0','0','0','0','0',@TOTIMP4,@DESC1,'0','0','0','0','S',@NUM_ALM, ")
                    sq_query_ins_par_factf.Append("@POLIT_APLI,'1',@UNI_VENTA,'P','0','0',@E_LTPD, 'N',(SELECT ULT_CVE + 1 FROM ")
                    sq_query_ins_par_factf.Append(" SAE60Empre05.dbo.TBLCONTROL05 WHERE (ID_TABLA = 44)),@TOT_PARTIDA,'S') ")
                    Dim cmd_par_factf As New SqlCommand(sq_query_ins_par_factf.ToString(), ActualizarConexion)
                    cmd_par_factf.Parameters.AddWithValue("@CVE_DOC", documento)
                    cmd_par_factf.Parameters.AddWithValue("@NUM_PAR", contador_partidas + 1)
                    cmd_par_factf.Parameters.AddWithValue("@CVE_ART", dt2(contador_partidas)(2))
                    cmd_par_factf.Parameters.AddWithValue("@CANT", dt2(contador_partidas)(7))
                    cmd_par_factf.Parameters.AddWithValue("@PXS", dt2(contador_partidas)(7))
                    cmd_par_factf.Parameters.AddWithValue("@PREC", dt2(contador_partidas)(10))
                    cmd_par_factf.Parameters.AddWithValue("@COST", dt2(contador_partidas)(9))
                    cmd_par_factf.Parameters.AddWithValue("@CAN_TOT", dt2(contador_partidas)(12))
                    cmd_par_factf.Parameters.AddWithValue("@IMPU4", dt2(contador_partidas)(11))
                    cmd_par_factf.Parameters.AddWithValue("@TOTIMP4", dt2(contador_partidas)(14))
                    cmd_par_factf.Parameters.AddWithValue("@DESC1", 0)
                    cmd_par_factf.Parameters.AddWithValue("@NUM_ALM", almacen_remite)
                    cmd_par_factf.Parameters.AddWithValue("@POLIT_APLI", 0)
                    cmd_par_factf.Parameters.AddWithValue("@UNI_VENTA", dt2(contador_partidas)(8))

                    cmd_par_factf.Parameters.AddWithValue("@E_LTPD", correlativo_lotes)
                    cmd_par_factf.Parameters.AddWithValue("@TOT_PARTIDA", Val(dt2(contador_partidas)("SubTotal")))
                    cmd_par_factf.Transaction = transaccion_sql
                    cmd_par_factf.ExecuteNonQuery()

                    'actualizar los correlativos de los NUM MOV DE PARFACT
                    Dim sq_query_tab_c3 As New StringBuilder()
                    sq_query_tab_c3.Append("UPDATE SAE60Empre05.dbo.TBLCONTROL05 SET [ULT_CVE] = ULT_CVE + @ULT_CVE ")
                    sq_query_tab_c3.Append("WHERE (ID_TABLA = 44) ")
                    Dim upd_correlativo_num_mov_pf As New SqlCommand(sq_query_tab_c3.ToString(), ActualizarConexion)
                    upd_correlativo_num_mov_pf.Parameters.AddWithValue("@ULT_CVE", 1)
                    upd_correlativo_num_mov_pf.Transaction = transaccion_sql
                    upd_correlativo_num_mov_pf.ExecuteNonQuery()

                    'ins para minve
                    Dim sq_query_ins_minv As New StringBuilder()
                    sq_query_ins_minv.Append("INSERT INTO SAE60Empre05.dbo.MINVE05 ([CVE_ART],[ALMACEN],[NUM_MOV],[CVE_CPTO],[FECHA_DOCU],[TIPO_DOC],[REFER],")
                    sq_query_ins_minv.Append("[CLAVE_CLPV],[VEND],[CANT],[CANT_COST],[PRECIO],[COSTO],[REG_SERIE],[UNI_VENTA],[E_LTPD], ")
                    sq_query_ins_minv.Append("[EXISTENCIA],[FACTOR_CON],[FECHAELAB],[CVE_FOLIO],[SIGNO],[COSTEADO],[COSTO_PROM_INI], ")
                    sq_query_ins_minv.Append("[COSTO_PROM_FIN],[DESDE_INVE],[MOV_ENLAZADO]) VALUES (@CVE_ART,@ALMACEN, ")
                    sq_query_ins_minv.Append("(SELECT ULT_CVE FROM SAE60Empre05.dbo.TBLCONTROL05 WHERE (ID_TABLA = 44)),'51',@FECHA_DOCU,'F',@REFER,@CLAVE_CLPV, ")
                    sq_query_ins_minv.Append("@VEND,@CANT,'0',@PRECIO,@COSTO,'0',@UNI_VENTA,@E_LTPD, ((SELECT EXIST FROM SAE60Empre05.dbo.MULT05 WHERE ")
                    sq_query_ins_minv.Append(" (CVE_ART = @CVE_ART) AND CVE_ALM = @ALMACEN)),'1', @FECHAELAB,(SELECT ULT_CVE+1 FROM SAE60Empre05.dbo.TBLCONTROL05 ")
                    sq_query_ins_minv.Append(" WHERE (ID_TABLA = 32)),'-1','S', @COSTO_PROM_INI,@COSTO_PROM_FIN,'N','0') ")
                    Dim cmd_minve As New SqlCommand(sq_query_ins_minv.ToString(), ActualizarConexion)
                    cmd_minve.Parameters.AddWithValue("@CVE_ART", dt2(contador_partidas)(2))
                    cmd_minve.Parameters.AddWithValue("@ALMACEN", almacen_remite)
                    cmd_minve.Parameters.AddWithValue("@FECHA_DOCU", Today.Date)
                    cmd_minve.Parameters.AddWithValue("@REFER", documento)
                    cmd_minve.Parameters.AddWithValue("@CLAVE_CLPV", CLiente)
                    cmd_minve.Parameters.AddWithValue("@VEND", CveVend)
                    cmd_minve.Parameters.AddWithValue("@CANT", dt2(contador_partidas)(7))
                    cmd_minve.Parameters.AddWithValue("@PRECIO", dt2(contador_partidas)(10))
                    cmd_minve.Parameters.AddWithValue("@COSTO", dt2(contador_partidas)(9))
                    cmd_minve.Parameters.AddWithValue("@UNI_VENTA", dt2(contador_partidas)(8))
                    cmd_minve.Parameters.AddWithValue("@E_LTPD", correlativo_lotes)
                    cmd_minve.Parameters.AddWithValue("@FECHAELAB", Today.Date)
                    cmd_minve.Parameters.AddWithValue("@COSTO_PROM_INI", dt2(contador_partidas)(9))
                    cmd_minve.Parameters.AddWithValue("@COSTO_PROM_FIN", dt2(contador_partidas)(9))
                    cmd_minve.Transaction = transaccion_sql
                    cmd_minve.ExecuteNonQuery()
                    'actualizar los correlativos de los lotes
                    Dim sq_query_upd_tb_c4 As New StringBuilder()
                    sq_query_upd_tb_c4.Append("UPDATE TBLCONTROL05 SET [ULT_CVE] = ULT_CVE + 1 WHERE (ID_TABLA = 48) ")
                    Dim upd_correlativo_minve As New SqlCommand(sq_query_upd_tb_c4.ToString(), ActualizarConexionConsumo)
                    upd_correlativo_minve.Transaction = transaccion_sqlConsumo
                    upd_correlativo_minve.ExecuteNonQuery()

                    'actualizar los correlativos de los cve_folio en minve
                    Dim sq_query_tb_c5 As New StringBuilder()
                    sq_query_tb_c5.Append("UPDATE SAE60Empre05.dbo.TBLCONTROL05 SET [ULT_CVE] = ULT_CVE + 1 ")
                    sq_query_tb_c5.Append("WHERE (ID_TABLA = 32) ")
                    Dim upd_correlativo_cve_folio As New SqlCommand(sq_query_tb_c5.ToString(), ActualizarConexion)
                    upd_correlativo_cve_folio.Transaction = transaccion_sql
                    upd_correlativo_cve_folio.ExecuteNonQuery()
                End If
            Next
            'upd para actualizar los folios
            Dim sq_query_upd_folios As New StringBuilder()
            sq_query_upd_folios.Append("UPDATE FOLIOSF05 SET [ULT_DOC] = ULT_DOC + 1, [FECH_ULT_DOC] = @FECH_ULT_DOC ")
            sq_query_upd_folios.Append("WHERE [SERIE] = @SERIE AND [TIP_DOC] = @TIP_DOC ")
            Dim cmd_upd_foliosf As New SqlCommand(sq_query_upd_folios.ToString(), ActualizarConexionConsumo)
            cmd_upd_foliosf.Parameters.AddWithValue("@FECH_ULT_DOC", Today.[Date])
            cmd_upd_foliosf.Parameters.AddWithValue("@SERIE", serie)
            cmd_upd_foliosf.Parameters.AddWithValue("@TIP_DOC", "F")
            cmd_upd_foliosf.Transaction = transaccion_sqlConsumo
            'fin de las facturas del lote
            cmd_upd_foliosf.ExecuteNonQuery()



            '''''''''''''''''
            'Fin Facturación'
            '''''''''''''''''


            Dim conexion_bita As New cls_bitacora_reporteador
            conexion_bita.RegistraBitacora(Now, usuario, "Completó Consignación", "ALMACEN", _
                                      "Remisión: " & Doc & " - Factura: " & documento & " almacen:" & almacen_remite)

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

    Public Function COMPLETARDIMOSA(ByVal dt As DataTable, ByVal dt2 As DataTable, ByVal usuario As String, ByVal Estado As String, ByVal Doc As String, ByVal Identidad As String, ByVal Entregador As String, ByVal Placa As String, ByVal Modelo As String, ByVal CLiente As String, ByVal Vehiculo As String, ByVal ClaveEntregador As String)

        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim ActualizarConexionConsumo As New SqlConnection(DIMOSA.CadenaSQL())

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
                        query_datos_inve.Append("FROM [SAE60Empre06].[dbo].[INVE06] ")
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
                        query_mult_entrada.Append("UPDATE [SAE60Empre06].[dbo].[MULT06] ")
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
                        query_inve_entrada.Append("UPDATE [SAE60Empre06].[dbo].[INVE06] ")
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
                                        query_enlace_ltpd_ins_entrada.Append("INSERT INTO [SAE60Empre06].[dbo].[ENLACE_LTPD06] ")
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
                                        query_upd_ltpd.Append("UPDATE [SAE60Empre06].[dbo].[LTPD06] ")
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
                                        query_insertar_nuevo_lote.Append("INSERT INTO [SAE60Empre06].[dbo].[LTPD06] ")
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
                                        query_actualiza_autonumerico_ltpd.Append("UPDATE [SAE60Empre06].[dbo].[TBLCONTROL06] ")
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
                            query_actualiza_lotes.Append("UPDATE [SAE60Empre06].[dbo].[TBLCONTROL06] ")
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
                        'If ds_entrada.Tables(0).Rows.Count > 0 Then
                        'MOTIVOENTRADA = Convert.ToInt32(ds_entrada.Tables(0).Rows(0)(0))
                        'Else
                        MOTIVOENTRADA = 14
                        'End If

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
                        query_control_num_mov_entrada.Append("UPDATE [SAE60Empre06].[dbo].[TBLCONTROL06] ")
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
                query_control_folio_DEV.Append("UPDATE [SAE60Empre06].[dbo].[TBLCONTROL06] ")
                query_control_folio_DEV.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                query_control_folio_DEV.Append("WHERE ([ID_TABLA] = 32) ")
                Dim comando_control_folio_DEV As New SqlCommand(query_control_folio_DEV.ToString, ActualizarConexion)
                comando_control_folio_DEV.Transaction = transaccion_sql
                comando_control_folio_DEV.ExecuteNonQuery()

            End If

            ''''''''''''''''''''
            'Inicio Facturacion'
            ''''''''''''''''''''

            Dim documento As String = ""
            Dim serie As String = ""
            If almacen_remite = 1 Then
                serie = "00-005-01-"
            ElseIf almacen_remite = 2 Then
                serie = "02-003-01-"
            ElseIf almacen_remite = 3 Then
                serie = "01-005-01-"
            End If

            Dim ULTDOC As Integer = 0
            Dim dt_ULTDOC As New DataTable
            Dim query_ULTDOC As New StringBuilder
            query_ULTDOC.Append("SELECT ULT_DOC FROM SAE60EMPRE06.dbo.FOLIOSF06 WHERE (SERIE = @SERIE) ")
            Dim cmd_select_ULTDOC As New SqlCommand(query_ULTDOC.ToString, ActualizarConexion)
            cmd_select_ULTDOC.Parameters.AddWithValue("@SERIE", serie)
            Dim adaptador_ULTDOC As New SqlDataAdapter(cmd_select_ULTDOC)
            cmd_select_ULTDOC.Transaction = transaccion_sql
            adaptador_ULTDOC.Fill(dt_ULTDOC)
            ULTDOC = dt_ULTDOC(0)(0)

            Dim TOTALFACTURA As Decimal = 0
            Dim SubTotalFactura As Decimal = 0
            Dim ImpTot As Decimal = 0

            For a As Integer = 0 To dt2.Rows.Count - 1
                If dt2(a)(0) > "0" Then
                    Dim ImpInd As Decimal = dt2(a)(14)
                    ImpTot = ImpTot + ImpInd
                    SubTotalFactura = SubTotalFactura + dt2(a)(12)
                End If
            Next

            TOTALFACTURA = SubTotalFactura + ImpTot

            Dim dt_cliente As New DataTable
            Dim query_cliente As New StringBuilder
            query_cliente.Append(" SELECT CLAVE, NOMBRE, RFC, CALLE, NUMEXT, CRUZAMIENTOS, CRUZAMIENTOS2, COLONIA, CODIGO, LOCALIDAD, MUNICIPIO, ESTADO, PAIS, NACIONALIDAD, ")
            query_cliente.Append(" REFERDIR, TELEFONO, CLASIFIC, FAX, PAG_WEB, CURP, CVE_ZONA, IMPRIR, MAIL, NIVELSEC, ENVIOSILEN, EMAILPRED, DIAREV, DIAPAGO, CON_CREDITO, ")
            query_cliente.Append(" DIASCRED, LIMCRED, SALDO, LISTA_PREC, CVE_BITA, ULT_PAGOD, ULT_PAGOM, ULT_PAGOF, DESCUENTO, ULT_VENTAD, ULT_COMPM, FCH_ULTCOM, VENTAS, ")
            query_cliente.Append(" CVE_VEND, CVE_OBS, TIPO_EMPRESA FROM CLIE06 WHERE CLAVE = @CLAVE")

            Dim cmd_select_cliente As New SqlCommand(query_cliente.ToString, ActualizarConexionConsumo)
            cmd_select_cliente.Parameters.AddWithValue("@CLAVE", CLiente)
            Dim adaptador_cliente As New SqlDataAdapter(cmd_select_cliente)
            cmd_select_cliente.Transaction = transaccion_sqlConsumo
            adaptador_cliente.Fill(dt_cliente)

            Dim CveVend As String = dt_cliente(0)(42)


            Dim folio As Integer = ULTDOC
            Dim ceros As String = ""
            folio += 1
            For largo As Integer = 0 To (8 - Convert.ToString(folio).Length) - 1
                ceros += "0"
            Next
            documento = (serie & ceros) + Convert.ToString(folio)
            'inicio de las facturas del lote
            'campos libres de las facturas
            Dim sq_query_camplib As New StringBuilder()
            sq_query_camplib.Append("INSERT INTO FACTF_CLIB06 ([CLAVE_DOC],[CAMPLIB16],[CAMPLIB17],[CAMPLIB18],[CAMPLIB19]) ")
            sq_query_camplib.Append("VALUES (@CLAVE_DOC,@CAMPLIB16,@CAMPLIB17,@CAMPLIB18,@CAMPLIB19) ")
            Dim cmd_factf_clib As New SqlCommand(sq_query_camplib.ToString(), ActualizarConexionConsumo)
            cmd_factf_clib.Parameters.AddWithValue("@CLAVE_DOC", documento)
            cmd_factf_clib.Parameters.AddWithValue("@CAMPLIB16", Identidad)
            cmd_factf_clib.Parameters.AddWithValue("@CAMPLIB17", Entregador)
            cmd_factf_clib.Parameters.AddWithValue("@CAMPLIB18", Placa)
            cmd_factf_clib.Parameters.AddWithValue("@CAMPLIB19", Modelo)
            cmd_factf_clib.Transaction = transaccion_sqlConsumo
            cmd_factf_clib.ExecuteNonQuery()

            'ins de cuen m
            Dim sq_query_ins_cuen_m As New StringBuilder()
            sq_query_ins_cuen_m.Append("INSERT INTO CUEN_M06 ([CVE_CLIE],[REFER],[NUM_CPTO],[NUM_CARGO],[CVE_OBS],[NO_FACTURA] ")
            sq_query_ins_cuen_m.Append(",[DOCTO],[IMPORTE],[FECHA_APLI],[FECHA_VENC],[AFEC_COI],[STRCVEVEND],[NUM_MONED],[TCAMBIO] ")
            sq_query_ins_cuen_m.Append(",[IMPMON_EXT],[FECHAELAB],[TIPO_MOV],[SIGNO],[USUARIO],[ENTREGADA],[FECHA_ENTREGA],[STATUS]) ")
            sq_query_ins_cuen_m.Append("VALUES (@CVE_CLIE,@REFER,'1','1','0',@NO_FACTURA,@DOCTO,@IMPORTE,@FECHA_APLI,@FECHA_VENC,'A' ")
            sq_query_ins_cuen_m.Append(", @STRCVEVEND,'1','1',@IMPMON_EXT,@FECHAELAB,'C','1',@USUARIO,@ENTREGADA,@FECHA_ENTREGA,'A') ")
            Dim cmd_cuen_m As New SqlCommand(sq_query_ins_cuen_m.ToString(), ActualizarConexionConsumo)
            cmd_cuen_m.Parameters.AddWithValue("@CVE_CLIE", CLiente)
            cmd_cuen_m.Parameters.AddWithValue("@REFER", documento)
            cmd_cuen_m.Parameters.AddWithValue("@NO_FACTURA", documento)
            cmd_cuen_m.Parameters.AddWithValue("@DOCTO", documento)
            cmd_cuen_m.Parameters.AddWithValue("@IMPORTE", TOTALFACTURA)
            cmd_cuen_m.Parameters.AddWithValue("@FECHA_APLI", Today.Date)
            Dim fecha_venc As DateTime
            fecha_venc = Today.Date
            cmd_cuen_m.Parameters.AddWithValue("@FECHA_VENC", fecha_venc.[Date])
            cmd_cuen_m.Parameters.AddWithValue("@STRCVEVEND", CveVend)
            cmd_cuen_m.Parameters.AddWithValue("@IMPMON_EXT", TOTALFACTURA)
            cmd_cuen_m.Parameters.AddWithValue("@FECHAELAB", Today.Date)
            cmd_cuen_m.Parameters.AddWithValue("@USUARIO", "0")

            cmd_cuen_m.Parameters.AddWithValue("@ENTREGADA", "S")
            cmd_cuen_m.Parameters.AddWithValue("@FECHA_ENTREGA", Today.Date)

            cmd_cuen_m.Transaction = transaccion_sqlConsumo
            cmd_cuen_m.ExecuteNonQuery()
            'ins de cuen det solo cuando el tipo de pago es de contado
            Dim TipoPago = "Contado"
            If Convert.ToString(TipoPago) = "Contado" Then
                Dim sq_query_ins_cuen_det As New StringBuilder()
                sq_query_ins_cuen_det.Append("INSERT INTO CUEN_DET06 ([CVE_CLIE],[REFER],[ID_MOV],[NUM_CPTO],[NUM_CARGO],[CVE_OBS],")
                sq_query_ins_cuen_det.Append("[NO_FACTURA],[DOCTO],[IMPORTE],[FECHA_APLI],[FECHA_VENC],[STRCVEVEND],[NUM_MONED],[TCAMBIO], ")
                sq_query_ins_cuen_det.Append("[IMPMON_EXT],[FECHAELAB],[CTLPOL],[CVE_FOLIO],[TIPO_MOV],[SIGNO],[CVE_AUT],[USUARIO],[NO_PARTIDA]) ")
                sq_query_ins_cuen_det.Append("VALUES (@CVE_CLIE,@REFER,@ID_MOV,'10','1','0',@NO_FACTURA,'',@IMPORTE, @FECHA_APLI,@FECHA_VENC, ")
                sq_query_ins_cuen_det.Append("@STRCVEVEND,'1','1',@IMPMON_EXT,@FECHAELAB,'0',@CVE_FOLIO,'A','-1','0',@USUARIO,'1') ")
                Dim cmd_cuen_det As New SqlCommand(sq_query_ins_cuen_det.ToString(), ActualizarConexionConsumo)
                cmd_cuen_det.Parameters.AddWithValue("@CVE_CLIE", CLiente)
                cmd_cuen_det.Parameters.AddWithValue("@REFER", documento)
                cmd_cuen_det.Parameters.AddWithValue("@ID_MOV", "1")
                cmd_cuen_det.Parameters.AddWithValue("@NO_FACTURA", documento)
                cmd_cuen_det.Parameters.AddWithValue("@IMPORTE", TOTALFACTURA)
                cmd_cuen_det.Parameters.AddWithValue("@FECHA_APLI", Today.[Date])
                cmd_cuen_det.Parameters.AddWithValue("@FECHA_VENC", Today.[Date])
                cmd_cuen_det.Parameters.AddWithValue("@STRCVEVEND", CveVend)
                cmd_cuen_det.Parameters.AddWithValue("@IMPMON_EXT", TOTALFACTURA)
                cmd_cuen_det.Parameters.AddWithValue("@FECHAELAB", Today.Date)
                cmd_cuen_det.Parameters.AddWithValue("@CVE_FOLIO", folio)
                cmd_cuen_det.Parameters.AddWithValue("@USUARIO", 0)
                cmd_cuen_det.Transaction = transaccion_sqlConsumo
                cmd_cuen_det.ExecuteNonQuery()
            End If
            'ins de bitacora de los clientes
            Dim sq_query_ins_bita As New StringBuilder()
            sq_query_ins_bita.Append("INSERT INTO BITA06 ([CVE_BITA],[CVE_CLIE],[CVE_CAMPANIA],[CVE_ACTIVIDAD] ")
            sq_query_ins_bita.Append(",[FECHAHORA],[CVE_USUARIO],[OBSERVACIONES],[STATUS],[NOM_USUARIO]) ")
            sq_query_ins_bita.Append("VALUES ((SELECT ULT_CVE + 1 AS ULT_CVE FROM TBLCONTROL06 WHERE (ID_TABLA = 62)),@CVE_CLIE,")
            sq_query_ins_bita.Append("@CVE_CAMPANIA,@CVE_ACTIVIDAD,@FECHAHORA,@CVE_USUARIO,@OBSERVACIONES,@STATUS,@NOM_USUARIO) ")
            Dim cmd_bita As New SqlCommand(sq_query_ins_bita.ToString(), ActualizarConexionConsumo)
            cmd_bita.Parameters.AddWithValue("@CVE_CLIE", CLiente)
            cmd_bita.Parameters.AddWithValue("@CVE_CAMPANIA", "_SAE_")
            cmd_bita.Parameters.AddWithValue("@CVE_ACTIVIDAD", "    2")
            cmd_bita.Parameters.AddWithValue("@FECHAHORA", Today.Date)
            cmd_bita.Parameters.AddWithValue("@CVE_USUARIO", 0)
            cmd_bita.Parameters.AddWithValue("@OBSERVACIONES", (Convert.ToString("No.[") & documento) + "] L " & TOTALFACTURA)
            cmd_bita.Parameters.AddWithValue("@STATUS", "F")
            cmd_bita.Parameters.AddWithValue("@NOM_USUARIO", 0)
            cmd_bita.Transaction = transaccion_sqlConsumo
            cmd_bita.ExecuteNonQuery()

            'ins de encabezados de facturas
            Dim sq_query_ins_factf As New StringBuilder()
            sq_query_ins_factf.Append("INSERT INTO FACTF06 ([TIP_DOC],[CVE_DOC],[CVE_CLPV],[STATUS],[DAT_MOSTR],[CVE_VEND],[CVE_PEDI],")
            sq_query_ins_factf.Append("[FECHA_DOC] ,[FECHA_ENT],[FECHA_VEN],[CAN_TOT],[IMP_TOT1],[IMP_TOT2],[IMP_TOT3],[IMP_TOT4] ")
            sq_query_ins_factf.Append(",[DES_TOT],[DES_FIN],[COM_TOT],CONDICION,[CVE_OBS],[NUM_ALMA],[ACT_CXC],[ACT_COI],[ENLAZADO]" & vbTab)
            sq_query_ins_factf.Append(",[TIP_DOC_E],[NUM_MONED],[TIPCAMB],[NUM_PAGOS],[FECHAELAB],[PRIMERPAGO],[RFC],[CTLPOL],[ESCFD],")
            sq_query_ins_factf.Append("[AUTORIZA],[SERIE],[FOLIO],[AUTOANIO],[DAT_ENVIO],[CONTADO],[CVE_BITA],[BLOQ],[FORMAENVIO],[DES_FIN_PORC], ")
            sq_query_ins_factf.Append("[DES_TOT_PORC],[IMPORTE],[COM_TOT_PORC],[METODODEPAGO],[NUMCTAPAGO],[TIP_DOC_ANT],[DOC_ANT]) ")
            sq_query_ins_factf.Append("VALUES" & vbTab & "('F',@CVE_DOC,@CVE_CLPV,'O','0',@CVE_VEND,@CVE_PEDI,@FECHA_DOC,@FECHA_ENT,@FECHA_VEN,@CAN_TOT, ")
            sq_query_ins_factf.Append("'0','0','0',@IMP_TOT4,@DES_TOT,'0','0',@CONDICION,'0',@NUM_ALMA,'S','N','O','O','1','1','1',@FECHAELAB,")
            sq_query_ins_factf.Append("@PRIMERPAGO,@RFC,@CTLPOL,'N',@AUTORIZA,@SERIE,@FOLIO,@AUTOANIO,'0',@CONTADO,(SELECT ULT_CVE + 1 AS ULT_CVE")
            sq_query_ins_factf.Append(" FROM TBLCONTROL06 WHERE (ID_TABLA = 62)),'N','I','0',@DES_TOT_PORC,@IMPORTE,'0',@METODODEPAGO,'','','')")
            Dim cmd_factf As New SqlCommand(sq_query_ins_factf.ToString(), ActualizarConexionConsumo)
            cmd_factf.Parameters.AddWithValue("@CVE_DOC", documento)
            cmd_factf.Parameters.AddWithValue("@CVE_CLPV", CLiente)
            cmd_factf.Parameters.AddWithValue("@CVE_VEND", CveVend)
            cmd_factf.Parameters.AddWithValue("@CVE_PEDI", Vehiculo)
            cmd_factf.Parameters.AddWithValue("@FECHA_DOC", Today.[Date])
            cmd_factf.Parameters.AddWithValue("@FECHA_ENT", Today.[Date])
            Dim fecha_vencimiento_factura As DateTime
            fecha_vencimiento_factura = Today.Date
            If TipoPago = "Credito" Then
                fecha_vencimiento_factura = fecha_vencimiento_factura.AddDays(Convert.ToDouble((dt_cliente)(29)))
            End If
            cmd_factf.Parameters.AddWithValue("@FECHA_VEN", fecha_vencimiento_factura.[Date])
            cmd_factf.Parameters.AddWithValue("@CAN_TOT", SubTotalFactura)
            cmd_factf.Parameters.AddWithValue("@IMP_TOT4", ImpTot)
            cmd_factf.Parameters.AddWithValue("@DES_TOT", 0)
            cmd_factf.Parameters.AddWithValue("@CONDICION", ClaveEntregador)
            cmd_factf.Parameters.AddWithValue("@NUM_ALMA", almacen_remite)
            cmd_factf.Parameters.AddWithValue("@FECHAELAB", Today.Date)
            If TipoPago = "Credito" Then
                cmd_factf.Parameters.AddWithValue("@PRIMERPAGO", 0)
            Else
                cmd_factf.Parameters.AddWithValue("@PRIMERPAGO", TOTALFACTURA)
            End If
            cmd_factf.Parameters.AddWithValue("@RFC", dt_cliente(0)(2))
            cmd_factf.Parameters.AddWithValue("@CTLPOL", "")
            cmd_factf.Parameters.AddWithValue("@AUTORIZA", "")
            cmd_factf.Parameters.AddWithValue("@SERIE", serie)
            cmd_factf.Parameters.AddWithValue("@FOLIO", folio)
            cmd_factf.Parameters.AddWithValue("@AUTOANIO", "")
            If TipoPago = "Credito" Then
                cmd_factf.Parameters.AddWithValue("@CONTADO", "N")
            Else
                cmd_factf.Parameters.AddWithValue("@CONTADO", "S")
            End If
            cmd_factf.Parameters.AddWithValue("@DES_TOT_PORC", 0)
            cmd_factf.Parameters.AddWithValue("@IMPORTE", TOTALFACTURA)
            If TipoPago = "Credito" Then
                cmd_factf.Parameters.AddWithValue("@METODODEPAGO", "")
            Else
                cmd_factf.Parameters.AddWithValue("@METODODEPAGO", "Efectivo")
            End If
            cmd_factf.Transaction = transaccion_sqlConsumo
            cmd_factf.ExecuteNonQuery()

            'actualizar los correlativos de LA BITACORA
            Dim sq_query_up_tbc1 As New StringBuilder()
            sq_query_up_tbc1.Append("UPDATE TBLCONTROL06 SET [ULT_CVE] = ULT_CVE + 1 WHERE (ID_TABLA = 62)")
            Dim upd_correlativo_bita As New SqlCommand(sq_query_up_tbc1.ToString(), ActualizarConexionConsumo)
            upd_correlativo_bita.Transaction = transaccion_sqlConsumo
            upd_correlativo_bita.ExecuteNonQuery()

            'upd para actualizar saldos de clientes
            If Convert.ToString(TipoPago) = "Credito" Then
                Dim sq_query_up_clie As New StringBuilder()
                sq_query_up_clie.Append("UPDATE CLIE06 SET [SALDO] = (SALDO + @NUEVOSALDO),[ULT_VENTAD] = @ULT_VENTAD ")
                sq_query_up_clie.Append(",[ULT_COMPM] = @ULT_COMPM,[FCH_ULTCOM] = @FCH_ULTCOM, [VENTAS] = VENTAS + @VENTAS_NUEVAS ")
                sq_query_up_clie.Append("WHERE [CLAVE] = @CLAVE ")
                Dim cmd_upd_clie As New SqlCommand(sq_query_up_clie.ToString(), ActualizarConexionConsumo)
                cmd_upd_clie.Parameters.AddWithValue("@NUEVOSALDO", TOTALFACTURA)
                cmd_upd_clie.Parameters.AddWithValue("@ULT_VENTAD", documento)
                cmd_upd_clie.Parameters.AddWithValue("@ULT_COMPM", TOTALFACTURA)
                cmd_upd_clie.Parameters.AddWithValue("@FCH_ULTCOM", Today.[Date])
                cmd_upd_clie.Parameters.AddWithValue("@VENTAS_NUEVAS", TOTALFACTURA)
                cmd_upd_clie.Parameters.AddWithValue("@CLAVE", CLiente)
                cmd_upd_clie.Transaction = transaccion_sqlConsumo
                cmd_upd_clie.ExecuteNonQuery()
            Else
                Dim sq_query_up_clie2 As New StringBuilder()
                sq_query_up_clie2.Append("UPDATE CLIE06 SET [SALDO] = (SALDO + @NUEVOSALDO),[ULT_PAGOD] = @ULT_PAGOD,[ULT_PAGOM] = @ULT_PAGOM, ")
                sq_query_up_clie2.Append("[ULT_PAGOF] = @ULT_PAGOF, [ULT_VENTAD] = @ULT_VENTAD ,[ULT_COMPM] = @ULT_COMPM, ")
                sq_query_up_clie2.Append("[FCH_ULTCOM] = @FCH_ULTCOM, [VENTAS] = VENTAS + @VENTAS_NUEVAS WHERE [CLAVE] = @CLAVE ")
                Dim cmd_upd_clie As New SqlCommand(sq_query_up_clie2.ToString(), ActualizarConexionConsumo)
                cmd_upd_clie.Parameters.AddWithValue("@NUEVOSALDO", "0")
                cmd_upd_clie.Parameters.AddWithValue("@ULT_PAGOD", documento)
                cmd_upd_clie.Parameters.AddWithValue("@ULT_PAGOM", TOTALFACTURA)
                cmd_upd_clie.Parameters.AddWithValue("@ULT_PAGOF", Today.[Date])
                cmd_upd_clie.Parameters.AddWithValue("@ULT_VENTAD", documento)
                cmd_upd_clie.Parameters.AddWithValue("@ULT_COMPM", TOTALFACTURA)
                cmd_upd_clie.Parameters.AddWithValue("@FCH_ULTCOM", Today.[Date])
                cmd_upd_clie.Parameters.AddWithValue("@VENTAS_NUEVAS", TOTALFACTURA)
                cmd_upd_clie.Parameters.AddWithValue("@CLAVE", CLiente)
                cmd_upd_clie.Transaction = transaccion_sqlConsumo
                cmd_upd_clie.ExecuteNonQuery()
            End If
            'Partidas
            For contador_partidas As Integer = 0 To dt2.Rows.Count - 1
                Dim CantG As Decimal = dt2(contador_partidas)(7)
                Dim correlativo_lotes As Integer = 0
                If Convert.ToString(dt2.Rows(contador_partidas)(0)) = "" Then
                Else
                    ' inicio para actualizar los lotes
                    'seleccionar los lotes disponibles del sae
                    If Convert.ToString(dt2.Rows(contador_partidas)(0)) = "S" Then
                        Dim ds_lotes As New DataSet()
                        Dim cantidad As Double = 0, can_insertar As Double = 0
                        Dim sq_query_select_ltpd As New StringBuilder()
                        sq_query_select_ltpd.Append("SELECT LOTE, CVE_ALM, FCHCADUC, CANTIDAD, REG_LTPD FROM LTPD06 WHERE (STATUS = 'A') ")
                        sq_query_select_ltpd.Append(" AND (CVE_ART = @CVE_ART) AND CVE_ALM = @CVE_ALM AND (CANTIDAD > 0) AND ")
                        sq_query_select_ltpd.Append("(FCHCADUC > GETDATE() OR FCHCADUC IS NULL OR FCHCADUC = '') ORDER BY FCHCADUC ")
                        Dim cmd_select_lotes As New SqlCommand(sq_query_select_ltpd.ToString(), ActualizarConexionConsumo)
                        cmd_select_lotes.Parameters.AddWithValue("@CVE_ART", dt2(contador_partidas)(2))
                        cmd_select_lotes.Parameters.AddWithValue("@CVE_ALM", almacen_remite)
                        Dim Adaptador As New SqlDataAdapter(cmd_select_lotes)
                        cmd_select_lotes.Transaction = transaccion_sqlConsumo
                        Adaptador.Fill(ds_lotes, "Lotes")
                        cantidad = Convert.ToDouble(dt2.Rows(contador_partidas)(7))

                        For i As Integer = 0 To ds_lotes.Tables(0).Rows.Count - 1
                            'inicio de seleccinar el autonumerico de los enlace lotes
                            Dim ds_correlattivo_lotes As New DataSet()
                            Dim sq_query_select_correlativo_lt As New StringBuilder()
                            sq_query_select_correlativo_lt.Append("SELECT (ULT_CVE + 1) AS ULT_CVE FROM TBLCONTROL06 WHERE (ID_TABLA = 67) ")
                            Dim cmd_select_correlativo_enlace As New SqlCommand(sq_query_select_correlativo_lt.ToString(), ActualizarConexionConsumo)
                            Dim Adapenlace As New SqlDataAdapter(cmd_select_correlativo_enlace)
                            cmd_select_correlativo_enlace.Transaction = transaccion_sqlConsumo
                            Adapenlace.Fill(ds_correlattivo_lotes, "Lotes")
                            'fin de seleccionar el autonumerico de los enlace lotes
                            correlativo_lotes = Convert.ToInt32(ds_correlattivo_lotes.Tables(0).Rows(0)(0))

                            If Convert.ToDouble(ds_lotes.Tables(0).Rows(i)(3)) >= cantidad Then
                                can_insertar = cantidad
                                'hacer el enlace a los lotes
                                Dim sq_query_ins_enlace_ltp As New StringBuilder()
                                sq_query_ins_enlace_ltp.Append("INSERT INTO ENLACE_LTPD06 (E_LTPD,REG_LTPD,CANTIDAD,PXRS) ")
                                sq_query_ins_enlace_ltp.Append("VALUES (@E_LTPD,@REG_LTPD,@CANTIDAD,@PXRS) ")
                                Dim cmd_enlace_ltpd As New SqlCommand(sq_query_ins_enlace_ltp.ToString(), ActualizarConexionConsumo)
                                cmd_enlace_ltpd.Parameters.AddWithValue("@E_LTPD", correlativo_lotes)
                                cmd_enlace_ltpd.Parameters.AddWithValue("@REG_LTPD", Convert.ToInt32(ds_lotes.Tables(0).Rows(i)(4)))
                                cmd_enlace_ltpd.Parameters.AddWithValue("@CANTIDAD", cantidad)
                                cmd_enlace_ltpd.Parameters.AddWithValue("@PXRS", cantidad)
                                cmd_enlace_ltpd.Transaction = transaccion_sqlConsumo
                                cmd_enlace_ltpd.ExecuteNonQuery()
                                'actualizar las existencias en los lotes
                                Dim sq_query_upd_lt As New StringBuilder()
                                sq_query_upd_lt.Append("UPDATE LTPD06 SET [FCHULTMOV] = @FCHULTMOV ")
                                sq_query_upd_lt.Append(",[CANTIDAD] = (CANTIDAD - @NUEVA_CANTIDAD) ")
                                sq_query_upd_lt.Append("WHERE [CVE_ART] = @CVE_ART AND [LOTE] = @LOTE AND [CVE_ALM] = @CVE_ALM ")
                                Dim cmd_ltpd As New SqlCommand(sq_query_upd_lt.ToString(), ActualizarConexionConsumo)
                                cmd_ltpd.Parameters.AddWithValue("@FCHULTMOV", Today.Date)
                                cmd_ltpd.Parameters.AddWithValue("@NUEVA_CANTIDAD", cantidad)
                                cmd_ltpd.Parameters.AddWithValue("@CVE_ART", dt2(contador_partidas)(2))
                                cmd_ltpd.Parameters.AddWithValue("@LOTE", Convert.ToString(ds_lotes.Tables(0).Rows(i)(0)))
                                cmd_ltpd.Parameters.AddWithValue("@CVE_ALM", almacen_remite)
                                cmd_ltpd.Transaction = transaccion_sqlConsumo
                                cmd_ltpd.ExecuteNonQuery()
                                i = ds_lotes.Tables(0).Rows.Count
                            Else
                                can_insertar = (Convert.ToDouble(ds_lotes.Tables(0).Rows(i)(3)) - Convert.ToDouble(dt2(contador_partidas)(7))) + Convert.ToDouble(dt2(contador_partidas)(7))
                                'hacer el enlace a los lotes
                                Dim sq_query_ins_enlace_ltpd As New StringBuilder()
                                sq_query_ins_enlace_ltpd.Append("INSERT INTO ENLACE_LTPD06 (E_LTPD,REG_LTPD,CANTIDAD,PXRS) ")
                                sq_query_ins_enlace_ltpd.Append("VALUES (@E_LTPD,@REG_LTPD,@CANTIDAD,@PXRS) ")
                                Dim cmd_enlace_ltpd As New SqlCommand(sq_query_ins_enlace_ltpd.ToString(), ActualizarConexionConsumo)
                                cmd_enlace_ltpd.Parameters.AddWithValue("@E_LTPD", correlativo_lotes)
                                cmd_enlace_ltpd.Parameters.AddWithValue("@REG_LTPD", Convert.ToInt32(ds_lotes.Tables(0).Rows(i)(4)))
                                cmd_enlace_ltpd.Parameters.AddWithValue("@CANTIDAD", can_insertar)
                                cmd_enlace_ltpd.Parameters.AddWithValue("@PXRS", can_insertar)
                                cmd_enlace_ltpd.Transaction = transaccion_sqlConsumo
                                cmd_enlace_ltpd.ExecuteNonQuery()

                                'actualizar las existencias en los lotes
                                Dim sq_query_upd_ltd As New StringBuilder()
                                sq_query_upd_ltd.Append("UPDATE LTPD06 SET [FCHULTMOV] = @FCHULTMOV ,[CANTIDAD] = (CANTIDAD - @NUEVA_CANTIDAD) ")
                                sq_query_upd_ltd.Append("WHERE [CVE_ART] = @CVE_ART AND [LOTE] = @LOTE AND [CVE_ALM] = @CVE_ALM ")
                                Dim cmd_ltpd As New SqlCommand(sq_query_upd_ltd.ToString(), ActualizarConexionConsumo)
                                cmd_ltpd.Parameters.AddWithValue("@FCHULTMOV", Today.Date)
                                cmd_ltpd.Parameters.AddWithValue("@NUEVA_CANTIDAD", can_insertar)
                                cmd_ltpd.Parameters.AddWithValue("@CVE_ART", dt2(contador_partidas)(2))
                                cmd_ltpd.Parameters.AddWithValue("@LOTE", Convert.ToString(ds_lotes.Tables(0).Rows(i)(0)))
                                cmd_ltpd.Parameters.AddWithValue("@CVE_ALM", almacen_remite)
                                cmd_ltpd.Transaction = transaccion_sqlConsumo
                                cmd_ltpd.ExecuteNonQuery()
                                cantidad = cantidad - Convert.ToInt32(ds_lotes.Tables(0).Rows(i)(3))
                                can_insertar = cantidad
                            End If
                        Next
                        'actualizar los correlativos de los lotes
                        Dim sq_query_tbl_c2 As New StringBuilder()
                        sq_query_tbl_c2.Append("UPDATE TBLCONTROL06 SET [ULT_CVE] = ULT_CVE + 1 WHERE (ID_TABLA = 67) ")
                        Dim upd_correlativo_ltpd As New SqlCommand(sq_query_tbl_c2.ToString(), ActualizarConexionConsumo)
                        upd_correlativo_ltpd.Transaction = transaccion_sqlConsumo
                        upd_correlativo_ltpd.ExecuteNonQuery()
                    End If
                    'fin de actualizar los lotes
                    'upd para actualizar existencias de inventarios
                    Dim sq_query_upd_inv As New StringBuilder()
                    sq_query_upd_inv.Append("UPDATE SAE60Empre06.dbo.INVE06 SET [FCH_ULTVTA] = @FCH_ULTVTA,[EXIST] = (EXIST - @NUEVA_EXISTENCIA), ")
                    sq_query_upd_inv.Append("[VTAS_ANL_C] = (VTAS_ANL_C+@VTAS_ANL_C),[VTAS_ANL_M] = (VTAS_ANL_M+@VTAS_ANL_M) ")
                    sq_query_upd_inv.Append("WHERE [CVE_ART] = @CVE_ART ")
                    Dim cmd_upd_inve As New SqlCommand(sq_query_upd_inv.ToString(), ActualizarConexion)
                    cmd_upd_inve.Parameters.AddWithValue("@FCH_ULTVTA", Today.[Date])
                    cmd_upd_inve.Parameters.AddWithValue("@CVE_ART", dt2(contador_partidas)(2))
                    cmd_upd_inve.Parameters.AddWithValue("VTAS_ANL_M", "0")
                    cmd_upd_inve.Parameters.AddWithValue("@VTAS_ANL_C", dt2(contador_partidas)(7))
                    cmd_upd_inve.Parameters.AddWithValue("@NUEVA_EXISTENCIA", dt2(contador_partidas)(7))
                    cmd_upd_inve.Transaction = transaccion_sql
                    cmd_upd_inve.ExecuteNonQuery()
                    'upd para actualizar existencias de multialmacenes
                    'update MULT
                    Dim query_mult_entrada2 As New StringBuilder
                    query_mult_entrada2.Append("UPDATE [SAE60Empre06].[dbo].[MULT06] ")
                    query_mult_entrada2.Append("SET [EXIST] = ISNULL(EXIST,0) - @CANTIDAD ")
                    query_mult_entrada2.Append("WHERE [CVE_ART] = @CVE_ART AND [CVE_ALM] = @CVE_ALM ")
                    Dim comando_mult_entrada2 As New SqlCommand(query_mult_entrada2.ToString, ActualizarConexion)
                    comando_mult_entrada2.Parameters.AddWithValue("@CVE_ART", dt2.Rows(contador_partidas).Item(2))
                    comando_mult_entrada2.Parameters.AddWithValue("@CVE_ALM", almacen_remite)
                    comando_mult_entrada2.Parameters.AddWithValue("@CANTIDAD", dt2.Rows(contador_partidas).Item(7))
                    comando_mult_entrada2.Transaction = transaccion_sql
                    comando_mult_entrada2.ExecuteNonQuery()
                    'ins de encabezados de facturas
                    Dim sq_query_ins_par_factf As New StringBuilder()
                    sq_query_ins_par_factf.Append("INSERT INTO SAE60Empre06.dbo.PAR_FACTF06 ([CVE_DOC],[NUM_PAR],[CVE_ART],[CANT],[PXS],[PREC],[COST],[IMPU1],")
                    sq_query_ins_par_factf.Append("[IMPU2],[IMPU3],[IMPU4],[IMP1APLA],[IMP2APLA],[IMP3APLA],[IMP4APLA],[TOTIMP1],[TOTIMP2], ")
                    sq_query_ins_par_factf.Append("[TOTIMP3],[TOTIMP4],[DESC1],[DESC2],[DESC3],[COMI],[APAR],[ACT_INV],[NUM_ALM],[POLIT_APLI],")
                    sq_query_ins_par_factf.Append("[TIP_CAM],[UNI_VENTA],[TIPO_PROD],[CVE_OBS],[REG_SERIE],[E_LTPD],[TIPO_ELEM],[NUM_MOV], ")
                    sq_query_ins_par_factf.Append("[TOT_PARTIDA],[IMPRIMIR]) VALUES (@CVE_DOC,@NUM_PAR,@CVE_ART,@CANT,@PXS,@PREC,@COST,'0', ")
                    sq_query_ins_par_factf.Append("'0','0',@IMPU4,'0', '0','0','0','0','0','0',@TOTIMP4,@DESC1,'0','0','0','0','S',@NUM_ALM, ")
                    sq_query_ins_par_factf.Append("@POLIT_APLI,'1',@UNI_VENTA,'P','0','0',@E_LTPD, 'N',(SELECT ULT_CVE + 1 FROM ")
                    sq_query_ins_par_factf.Append(" SAE60Empre06.dbo.TBLCONTROL06 WHERE (ID_TABLA = 44)),@TOT_PARTIDA,'S') ")
                    Dim cmd_par_factf As New SqlCommand(sq_query_ins_par_factf.ToString(), ActualizarConexion)
                    cmd_par_factf.Parameters.AddWithValue("@CVE_DOC", documento)
                    cmd_par_factf.Parameters.AddWithValue("@NUM_PAR", contador_partidas + 1)
                    cmd_par_factf.Parameters.AddWithValue("@CVE_ART", dt2(contador_partidas)(2))
                    cmd_par_factf.Parameters.AddWithValue("@CANT", dt2(contador_partidas)(7))
                    cmd_par_factf.Parameters.AddWithValue("@PXS", dt2(contador_partidas)(7))
                    cmd_par_factf.Parameters.AddWithValue("@PREC", dt2(contador_partidas)(10))
                    cmd_par_factf.Parameters.AddWithValue("@COST", dt2(contador_partidas)(9))
                    cmd_par_factf.Parameters.AddWithValue("@CAN_TOT", dt2(contador_partidas)(12))
                    cmd_par_factf.Parameters.AddWithValue("@IMPU4", dt2(contador_partidas)(11))
                    cmd_par_factf.Parameters.AddWithValue("@TOTIMP4", dt2(contador_partidas)(14))
                    cmd_par_factf.Parameters.AddWithValue("@DESC1", 0)
                    cmd_par_factf.Parameters.AddWithValue("@NUM_ALM", almacen_remite)
                    cmd_par_factf.Parameters.AddWithValue("@POLIT_APLI", 0)
                    cmd_par_factf.Parameters.AddWithValue("@UNI_VENTA", dt2(contador_partidas)(8))

                    cmd_par_factf.Parameters.AddWithValue("@E_LTPD", correlativo_lotes)
                    cmd_par_factf.Parameters.AddWithValue("@TOT_PARTIDA", Val(dt2(contador_partidas)("SubTotal")))
                    cmd_par_factf.Transaction = transaccion_sql
                    cmd_par_factf.ExecuteNonQuery()

                    'actualizar los correlativos de los NUM MOV DE PARFACT
                    Dim sq_query_tab_c3 As New StringBuilder()
                    sq_query_tab_c3.Append("UPDATE SAE60Empre06.dbo.TBLCONTROL06 SET [ULT_CVE] = ULT_CVE + @ULT_CVE ")
                    sq_query_tab_c3.Append("WHERE (ID_TABLA = 44) ")
                    Dim upd_correlativo_num_mov_pf As New SqlCommand(sq_query_tab_c3.ToString(), ActualizarConexion)
                    upd_correlativo_num_mov_pf.Parameters.AddWithValue("@ULT_CVE", 1)
                    upd_correlativo_num_mov_pf.Transaction = transaccion_sql
                    upd_correlativo_num_mov_pf.ExecuteNonQuery()

                    'ins para minve
                    Dim sq_query_ins_minv As New StringBuilder()
                    sq_query_ins_minv.Append("INSERT INTO SAE60Empre06.dbo.MINVE06 ([CVE_ART],[ALMACEN],[NUM_MOV],[CVE_CPTO],[FECHA_DOCU],[TIPO_DOC],[REFER],")
                    sq_query_ins_minv.Append("[CLAVE_CLPV],[VEND],[CANT],[CANT_COST],[PRECIO],[COSTO],[REG_SERIE],[UNI_VENTA],[E_LTPD], ")
                    sq_query_ins_minv.Append("[EXISTENCIA],[FACTOR_CON],[FECHAELAB],[CVE_FOLIO],[SIGNO],[COSTEADO],[COSTO_PROM_INI], ")
                    sq_query_ins_minv.Append("[COSTO_PROM_FIN],[DESDE_INVE],[MOV_ENLAZADO]) VALUES (@CVE_ART,@ALMACEN, ")
                    sq_query_ins_minv.Append("(SELECT ULT_CVE FROM SAE60Empre06.dbo.TBLCONTROL06 WHERE (ID_TABLA = 44)),'51',@FECHA_DOCU,'F',@REFER,@CLAVE_CLPV, ")
                    sq_query_ins_minv.Append("@VEND,@CANT,'0',@PRECIO,@COSTO,'0',@UNI_VENTA,@E_LTPD, ((SELECT EXIST FROM SAE60Empre06.dbo.MULT06 WHERE ")
                    sq_query_ins_minv.Append(" (CVE_ART = @CVE_ART) AND CVE_ALM = @ALMACEN)),'1', @FECHAELAB,(SELECT ULT_CVE+1 FROM SAE60Empre06.dbo.TBLCONTROL06 ")
                    sq_query_ins_minv.Append(" WHERE (ID_TABLA = 32)),'-1','S', @COSTO_PROM_INI,@COSTO_PROM_FIN,'N','0') ")
                    Dim cmd_minve As New SqlCommand(sq_query_ins_minv.ToString(), ActualizarConexion)
                    cmd_minve.Parameters.AddWithValue("@CVE_ART", dt2(contador_partidas)(2))
                    cmd_minve.Parameters.AddWithValue("@ALMACEN", almacen_remite)
                    cmd_minve.Parameters.AddWithValue("@FECHA_DOCU", Today.Date)
                    cmd_minve.Parameters.AddWithValue("@REFER", documento)
                    cmd_minve.Parameters.AddWithValue("@CLAVE_CLPV", CLiente)
                    cmd_minve.Parameters.AddWithValue("@VEND", CveVend)
                    cmd_minve.Parameters.AddWithValue("@CANT", dt2(contador_partidas)(7))
                    cmd_minve.Parameters.AddWithValue("@PRECIO", dt2(contador_partidas)(10))
                    cmd_minve.Parameters.AddWithValue("@COSTO", dt2(contador_partidas)(9))
                    cmd_minve.Parameters.AddWithValue("@UNI_VENTA", dt2(contador_partidas)(8))
                    cmd_minve.Parameters.AddWithValue("@E_LTPD", correlativo_lotes)
                    cmd_minve.Parameters.AddWithValue("@FECHAELAB", Today.Date)
                    cmd_minve.Parameters.AddWithValue("@COSTO_PROM_INI", dt2(contador_partidas)(9))
                    cmd_minve.Parameters.AddWithValue("@COSTO_PROM_FIN", dt2(contador_partidas)(9))
                    cmd_minve.Transaction = transaccion_sql
                    cmd_minve.ExecuteNonQuery()
                    'actualizar los correlativos de los lotes
                    Dim sq_query_upd_tb_c4 As New StringBuilder()
                    sq_query_upd_tb_c4.Append("UPDATE TBLCONTROL06 SET [ULT_CVE] = ULT_CVE + 1 WHERE (ID_TABLA = 48) ")
                    Dim upd_correlativo_minve As New SqlCommand(sq_query_upd_tb_c4.ToString(), ActualizarConexionConsumo)
                    upd_correlativo_minve.Transaction = transaccion_sqlConsumo
                    upd_correlativo_minve.ExecuteNonQuery()

                    'actualizar los correlativos de los cve_folio en minve
                    Dim sq_query_tb_c5 As New StringBuilder()
                    sq_query_tb_c5.Append("UPDATE SAE60Empre06.dbo.TBLCONTROL06 SET [ULT_CVE] = ULT_CVE + 1 ")
                    sq_query_tb_c5.Append("WHERE (ID_TABLA = 32) ")
                    Dim upd_correlativo_cve_folio As New SqlCommand(sq_query_tb_c5.ToString(), ActualizarConexion)
                    upd_correlativo_cve_folio.Transaction = transaccion_sql
                    upd_correlativo_cve_folio.ExecuteNonQuery()
                End If
            Next
            'upd para actualizar los folios
            Dim sq_query_upd_folios As New StringBuilder()
            sq_query_upd_folios.Append("UPDATE FOLIOSF06 SET [ULT_DOC] = ULT_DOC + 1, [FECH_ULT_DOC] = @FECH_ULT_DOC ")
            sq_query_upd_folios.Append("WHERE [SERIE] = @SERIE AND [TIP_DOC] = @TIP_DOC ")
            Dim cmd_upd_foliosf As New SqlCommand(sq_query_upd_folios.ToString(), ActualizarConexionConsumo)
            cmd_upd_foliosf.Parameters.AddWithValue("@FECH_ULT_DOC", Today.[Date])
            cmd_upd_foliosf.Parameters.AddWithValue("@SERIE", serie)
            cmd_upd_foliosf.Parameters.AddWithValue("@TIP_DOC", "F")
            cmd_upd_foliosf.Transaction = transaccion_sqlConsumo
            'fin de las facturas del lote
            cmd_upd_foliosf.ExecuteNonQuery()



            '''''''''''''''''
            'Fin Facturación'
            '''''''''''''''''


            Dim conexion_bita As New cls_bitacora_reporteador
            conexion_bita.RegistraBitacora(Now, usuario, "Completó Consignación DIMOSA", "ALMACEN", _
                                      "Remisión: " & Doc & " - Factura: " & documento & " almacen:" & almacen_remite)

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

        Dim miComando As New SqlCommand("SELECT  SAE60Empre05.dbo.INVE05.CVE_ART, SAE60Empre05.dbo.INVE05.UNI_ALT, SAE60Empre05.dbo.INVE05.COSTO_PROM, " & _
        "        SAE60Empre05.dbo.PRECIO_X_PROD05.PRECIO, SAE60Empre05.dbo.IMPU05.IMPUESTO4 " & _
        " FROM         SAE60Empre05.dbo.INVE05 INNER JOIN " & _
        "                      SAE60Empre05.dbo.IMPU05 ON SAE60Empre05.dbo.INVE05.CVE_ESQIMPU = SAE60Empre05.dbo.IMPU05.CVE_ESQIMPU INNER JOIN " & _
        "                      SAE60Empre05.dbo.PRECIO_X_PROD05 ON SAE60Empre05.dbo.INVE05.CVE_ART = SAE60Empre05.dbo.PRECIO_X_PROD05.CVE_ART " & _
        "WHERE     (SAE60Empre05.dbo.PRECIO_X_PROD05.CVE_PRECIO = 1) AND SAE60Empre05.dbo.INVE05.CVE_ART = @Producto", ActualizarConexion)

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

    Public Function DatosProductoDIMOSA(ByVal Producto As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT  SAE60Empre06.dbo.INVE06.CVE_ART, SAE60Empre06.dbo.INVE06.UNI_ALT, SAE60Empre06.dbo.INVE06.COSTO_PROM, " & _
        "        SAE60Empre06.dbo.PRECIO_X_PROD06.PRECIO, SAE60Empre06.dbo.IMPU06.IMPUESTO4 " & _
        " FROM         SAE60Empre06.dbo.INVE06 INNER JOIN " & _
        "                      SAE60Empre06.dbo.IMPU06 ON SAE60Empre06.dbo.INVE06.CVE_ESQIMPU = SAE60Empre06.dbo.IMPU06.CVE_ESQIMPU INNER JOIN " & _
        "                      SAE60Empre06.dbo.PRECIO_X_PROD06 ON SAE60Empre06.dbo.INVE06.CVE_ART = SAE60Empre06.dbo.PRECIO_X_PROD06.CVE_ART " & _
        "WHERE     (SAE60Empre06.dbo.PRECIO_X_PROD06.CVE_PRECIO = 1) AND SAE60Empre06.dbo.INVE06.CVE_ART = @Producto", ActualizarConexion)

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
