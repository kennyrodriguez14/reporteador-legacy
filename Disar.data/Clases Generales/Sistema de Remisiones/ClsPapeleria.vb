Imports System.Data.SqlClient
Imports System.Text

Public Class ClsPapeleria

    Dim BIENESYRECURSOS As New clsconexion_bienesyrecursos
    Dim Conexion As New clsConexion

    Public Function BuscarPapeleria(ByVal ALMACEN As Integer, ByVal DESCR As String)

        Dim ActualizarConexion As New SqlConnection(BIENESYRECURSOS.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT dbo.INVE03.CVE_ART AS CODIGO, dbo.INVE03.DESCR AS DESCRIPCION, " & _
                                        " dbo.MULT03.EXIST AS EXISTENCIA, ISNULL(dbo.INVE03.PESO,0),ISNULL(dbo.INVE03.CON_LOTE,'') " & _
                                        " FROM dbo.INVE03 INNER JOIN dbo.MULT03 ON dbo.INVE03.CVE_ART = dbo.MULT03.CVE_ART " & _
                                        " WHERE MULT03.CVE_ALM = @ALMACEN AND UPPER(INVE03.DESCR) LIKE '%' + @DESCR + '%' OR " & _
                                        " MULT03.CVE_ALM = @ALMACEN AND INVE03.CVE_ART LIKE @DESCR + '%' ", ActualizarConexion)

        miComando.Parameters.AddWithValue("@ALMACEN", ALMACEN)
        miComando.Parameters.AddWithValue("@DESCR", DESCR)
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

    Public Function NuevoMovimiento(ByVal Solicitante As String, ByVal dt As DataTable, ByVal Departamento As String, ByVal Almacen As Integer)

        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand
            'Guarda nueva marca

            Dim NumBita As Integer = 0
            Dim DtBita As New DataTable
            Dim QueryBita As String
            QueryBita = "SELECT  Isnull(MAX(MovID),0) FROM Papeleria_Solicitudes"
            Dim CMDQueryBita As New SqlCommand(QueryBita, ActualizarConexion)
            Dim AdaptadorBita As New SqlDataAdapter(CMDQueryBita)
            CMDQueryBita.Transaction = transaccion_sql
            AdaptadorBita.Fill(DtBita)

            If DtBita.Rows.Count > 0 Then
                If Not IsDBNull(DtBita.Rows(0)(0)) Then
                    NumBita = DtBita.Rows(0)(0)
                End If
            End If
            NumBita += 1

            Dim Fecha As Date = Today.Date
            Dim DtFecha As New DataTable
            Dim QueryFecha As String
            QueryFecha = " SELECT GETDATE() as FECHA"
            Dim CMDQueryFecha As New SqlCommand(QueryFecha, ActualizarConexion)
            Dim AdaptadorFecha As New SqlDataAdapter(CMDQueryFecha)
            CMDQueryFecha.Transaction = transaccion_sql
            AdaptadorFecha.Fill(DtBita)

            If DtFecha.Rows.Count > 0 Then
                If Not IsDBNull(DtFecha.Rows(0)(0)) Then
                    Fecha = DtFecha.Rows(0)(0)
                End If
            End If


            miComando = New SqlCommand("INSERT INTO Papeleria_Solicitudes (MovID, Solicitante, Estado, Fecha, Departamento, Almacen) " & _
                                       " VALUES(@MovID, @Solicitante, @Estado, @Fecha,  @Departamento, @Almacen ) ", ActualizarConexion)

            miComando.Parameters.AddWithValue("@MovID", NumBita)
            miComando.Parameters.AddWithValue("@Solicitante", Solicitante)
            miComando.Parameters.AddWithValue("@Estado", "Pendiente")
            miComando.Parameters.AddWithValue("@Fecha", Fecha)
            miComando.Parameters.AddWithValue("@Departamento", Departamento)
            miComando.Parameters.AddWithValue("@Almacen", Almacen)

            miComando.Transaction = transaccion_sql
            miComando.ExecuteNonQuery()


            For a As Integer = 0 To dt.Rows.Count - 1

                miComando = New SqlCommand("INSERT INTO Papeleria_Movimientos_Partidas (MovID, Cve_Prod, Descripcion, Cantidad) " & _
                                      " VALUES(@MovID, @Cve_Prod, @Descripcion, @Cantidad ) ", ActualizarConexion)

                miComando.Parameters.AddWithValue("@MovID", NumBita)
                miComando.Parameters.AddWithValue("@Cve_Prod", dt(a)(0))
                miComando.Parameters.AddWithValue("@Descripcion", dt(a)(1))
                miComando.Parameters.AddWithValue("@Cantidad", dt(a)(2))

                miComando.Transaction = transaccion_sql
                miComando.ExecuteNonQuery()

            Next

            transaccion_sql.Commit()
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

    Public Function CargarMovimientosPendientes()

        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT        dbo.Papeleria_Solicitudes.MovID, dbo.Papeleria_Solicitudes.Solicitante, dbo.[User].UsuarioNombre AS Nombre, dbo.Papeleria_Solicitudes.Estado, dbo.Papeleria_Solicitudes.Fecha, " & _
                         " dbo.Papeleria_Solicitudes.FechaAutorizado AS 'Fecha Autorización', dbo.Papeleria_Solicitudes.AutorizadoPor AS 'Autorizado Por', SAE60Empre03.dbo.CLIE03.CLAVE AS 'Clave Solicitante', " & _
                         "dbo.Papeleria_Solicitudes.Departamento, dbo.Papeleria_Solicitudes.Almacen " & _
                         "FROM            dbo.Papeleria_Solicitudes INNER JOIN " & _
                         " dbo.[User] ON dbo.Papeleria_Solicitudes.Solicitante = dbo.[User].UsuarioNick LEFT OUTER JOIN " & _
                         " SAE60Empre03.dbo.CLIE03 ON SAE60Empre03.dbo.CLIE03.NOMBRE = dbo.Papeleria_Solicitudes.Departamento COLLATE latin1_general_bin " & _
                         " WHERE        (dbo.Papeleria_Solicitudes.Estado = 'Pendiente') ", ActualizarConexion)
 
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

    Public Function CargarMovimientos(ByVal Fecha1 As Date, ByVal Fecha2 As Date, ByVal Almacen As Integer)

        Dim ActualizarConexion As New SqlConnection(BIENESYRECURSOS.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT        TOP (100) PERCENT dbo.MINVE03.NUM_MOV AS 'NUMERO', dbo.MINVE03.ALMACEN, dbo.ALMACENES03.DESCR, dbo.MINVE03.FECHA_DOCU AS FECHA, dbo.INVE03.CVE_ART AS 'CVE ART',  " & _
                         " dbo.INVE03.DESCR AS DESCRIPCION, dbo.MINVE03.CANT AS CANTIDAD, dbo.CLIE03.NOMBRE AS CLIENTE, dbo.MINVE03.CVE_CPTO AS 'CLAVE CONCEPTO', dbo.CONM03.DESCR AS 'DESCR CONCEPTO' " & _
                         " FROM  dbo.MINVE03 INNER JOIN dbo.INVE03 ON dbo.MINVE03.CVE_ART = dbo.INVE03.CVE_ART INNER JOIN dbo.CONM03 ON dbo.MINVE03.CVE_CPTO = dbo.CONM03.CVE_CPTO INNER JOIN " & _
                         " dbo.ALMACENES03 ON dbo.MINVE03.ALMACEN = dbo.ALMACENES03.CVE_ALM LEFT OUTER JOIN  dbo.CLIE03 ON dbo.MINVE03.CLAVE_CLPV = dbo.CLIE03.CLAVE " & _
                         " WHERE (dbo.MINVE03.CVE_CPTO IN (66, 10, 67)) AND (dbo.MINVE03.FECHA_DOCU BETWEEN @Fecha1 AND @Fecha2) AND (MINVE03.ALMACEN = @Almacen OR @Almacen = -1) ORDER BY FECHA ", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Fecha1", Fecha1.Date)
        miComando.Parameters.AddWithValue("@Fecha2", Fecha2.Date)
        miComando.Parameters.AddWithValue("@Almacen", Almacen)
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

    Public Function CargarPartidas(ByVal ID As Integer)

        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand(" SELECT   Cve_Prod, Descripcion, Cantidad " & _
                                        " FROM Papeleria_Movimientos_Partidas WHERE MovID = @ID", ActualizarConexion)

        miComando.Parameters.AddWithValue("@ID", ID)
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

    Public Function CompletarMovimiento(ByVal ID As Integer, ByVal Almacen As Integer, ByVal Cliente As String, ByVal Usuario As String, ByVal dt As DataTable, ByVal Fecha As Date)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim transaccion_sql As SqlTransaction
        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction
        Try

            Dim miComando As New SqlCommand("UPDATE [Usuarios].[dbo].[Papeleria_Solicitudes] " & _
                                                    " SET ESTADO = 'COMPLETA' WHERE MOVID = @ID ", ActualizarConexion)

            miComando.Parameters.AddWithValue("@ID", ID)

            miComando.Transaction = transaccion_sql
            miComando.ExecuteNonQuery()

            'MOVIMIENTOS DE SAE
            For index As Integer = 0 To dt.Rows.Count - 1
                'registra las salidas
                'update MULT
                Dim query_mult_salida As New StringBuilder
                query_mult_salida.Append("UPDATE [SAE60Empre03].[dbo].[MULT03] ")
                query_mult_salida.Append("SET [EXIST] = ISNULL(EXIST,0) - @CANTIDAD ")
                query_mult_salida.Append("WHERE [CVE_ART] = @CVE_ART AND [CVE_ALM] = @CVE_ALM ")
                Dim comando_mult_salida As New SqlCommand(query_mult_salida.ToString, ActualizarConexion)
                comando_mult_salida.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(0))
                comando_mult_salida.Parameters.AddWithValue("@CVE_ALM", Almacen)
                comando_mult_salida.Parameters.AddWithValue("@CANTIDAD", dt.Rows(index).Item(2))
                comando_mult_salida.Transaction = transaccion_sql
                comando_mult_salida.ExecuteNonQuery()

                'update INVE
                Dim query_inve As New StringBuilder
                query_inve.Append("UPDATE [SAE60Empre03].[dbo].[INVE03] ")
                query_inve.Append("SET [EXIST] = EXIST - @CANTIDAD ")
                query_inve.Append("WHERE [CVE_ART] = @CVE_ART ")
                Dim comando_inve_salida As New SqlCommand(query_inve.ToString, ActualizarConexion)
                comando_inve_salida.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(0))
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

                'select Datos INVE
                Dim query_datos_inve As New StringBuilder
                query_datos_inve.Append("SELECT ISNULL(COSTO_PROM,0), ISNULL(UNI_MED,'') ")
                query_datos_inve.Append("FROM [SAE60Empre03].[dbo].[INVE03] ")
                query_datos_inve.Append("WHERE CVE_ART = @CVE_ART")
                Dim comando_datos_inve As New SqlCommand(query_datos_inve.ToString, ActualizarConexion)
                comando_datos_inve.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(0))
                comando_datos_inve.Transaction = transaccion_sql
                Dim adaptador_datos_inve As New SqlDataAdapter(comando_datos_inve)
                Dim dt_datos_inve As New DataTable
                adaptador_datos_inve.Fill(dt_datos_inve)

                'insert MINVE
                Dim query_minve As New StringBuilder
                query_minve.Append("INSERT INTO [SAE60Empre03].[dbo].[MINVE03] ")
                query_minve.Append("   ([CVE_ART],[ALMACEN],[NUM_MOV],[CVE_CPTO],[FECHA_DOCU],[TIPO_DOC],[REFER], ")
                query_minve.Append("    [CANT],[CANT_COST],[PRECIO],[COSTO], ")
                query_minve.Append("    [REG_SERIE],[UNI_VENTA],[E_LTPD],[EXIST_G],[EXISTENCIA],[TIPO_PROD],[FACTOR_CON], ")
                query_minve.Append("    [FECHAELAB],[CVE_FOLIO],[SIGNO],[COSTEADO],[COSTO_PROM_INI], ")
                query_minve.Append("    [COSTO_PROM_FIN],[COSTO_PROM_GRAL],[DESDE_INVE],[MOV_ENLAZADO]) ")
                query_minve.Append("VALUES ")
                query_minve.Append("   (@CVE_ART,@ALMACEN,(SELECT ULT_CVE+1 FROM [SAE60Empre03].[dbo].[TBLCONTROL03] WHERE (ID_TABLA = 44)), ")
                query_minve.Append("    @CVE_CPTO,@FECHA_DOCU,'M',@REFER,@CANT,0,0,@COSTO,0, ")
                query_minve.Append("    @UNI_VENTA,@E_LTPD, ((SELECT ISNULL(EXIST,0) FROM [SAE60Empre03].[dbo].[INVE03] WHERE CVE_ART = @CVE_ART)), ")
                query_minve.Append("    ((SELECT EXIST FROM [SAE60Empre03].[dbo].[MULT03] WHERE (CVE_ART = @CVE_ART) AND CVE_ALM = @ALMACEN)), 'P',1, ")
                query_minve.Append("    @FECHAELAB, (SELECT ULT_CVE+1 FROM [SAE60Empre03].[dbo].[TBLCONTROL03] WHERE (ID_TABLA = 32)), -1, 'S', @COSTO_PROM_INI, ")
                query_minve.Append("    @COSTO_PROM_FIN, @COSTO_PROM_GRAL, 'S', 0) ")

                Dim comando_minve_salida As New SqlCommand(query_minve.ToString, ActualizarConexion)
                comando_minve_salida.Parameters.AddWithValue("@CVE_ART", dt.Rows(index).Item(0))
                comando_minve_salida.Parameters.AddWithValue("@ALMACEN", Almacen)
                comando_minve_salida.Parameters.AddWithValue("@CVE_CPTO", 66)
                comando_minve_salida.Parameters.AddWithValue("@FECHA_DOCU", Fecha.Date)
                comando_minve_salida.Parameters.AddWithValue("@REFER", "PAP_R_" & ID)
                comando_minve_salida.Parameters.AddWithValue("@CANT", dt.Rows(index).Item(2))
                comando_minve_salida.Parameters.AddWithValue("@COSTO", dt_datos_inve.Rows(0)(0))
                comando_minve_salida.Parameters.AddWithValue("@UNI_VENTA", dt_datos_inve.Rows(0)(1))
                comando_minve_salida.Parameters.AddWithValue("@E_LTPD", correlativo_lotes)
                comando_minve_salida.Parameters.AddWithValue("@FECHAELAB", Now.Date)
                comando_minve_salida.Parameters.AddWithValue("@COSTO_PROM_INI", dt_datos_inve.Rows(0)(0))
                comando_minve_salida.Parameters.AddWithValue("@COSTO_PROM_FIN", dt_datos_inve.Rows(0)(0))
                comando_minve_salida.Parameters.AddWithValue("@COSTO_PROM_GRAL", dt_datos_inve.Rows(0)(0))
                comando_minve_salida.Transaction = transaccion_sql
                comando_minve_salida.ExecuteNonQuery()

                'update num mov minve
                Dim query_control_num_mov As New StringBuilder
                query_control_num_mov.Append("UPDATE [SAE60Empre03].[dbo].[TBLCONTROL03] ")
                query_control_num_mov.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                query_control_num_mov.Append("WHERE [ID_TABLA] = 44 ")
                Dim comando_control_num_mov As New SqlCommand(query_control_num_mov.ToString, ActualizarConexion)
                comando_control_num_mov.Transaction = transaccion_sql
                comando_control_num_mov.ExecuteNonQuery()

                'FIN DE REGISTRAR LAS SALIDAS


            Next
            'FIN DE MOVIMIENTOS DEL SAE

            'update cve_folio minve
            Dim query_control_folio As New StringBuilder
            query_control_folio.Append("UPDATE [SAE60Empre03].[dbo].[TBLCONTROL03] ")
            query_control_folio.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
            query_control_folio.Append("WHERE ([ID_TABLA] = 32) ")
            Dim comando_control_folio As New SqlCommand(query_control_folio.ToString, ActualizarConexion)
            comando_control_folio.Transaction = transaccion_sql
            comando_control_folio.ExecuteNonQuery()

            Dim conexion_bita As New cls_bitacora_reporteador
            conexion_bita.RegistraBitacora(Now, Usuario, "Completó solicitud de Papelería", "FUNCIONES ADICIONALES", _
                                      "Fecha: " & Fecha & " Documento: " & ID & " almacen:" & Almacen)

            transaccion_sql.Commit()
            ActualizarConexion.Close()
            Return "correcto"

        Catch ex As Exception
            transaccion_sql.Rollback()
            ActualizarConexion.Close()
            Return ex.Message
        End Try
    End Function

End Class
