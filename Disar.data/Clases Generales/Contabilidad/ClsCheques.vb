Imports System.Data.SqlClient
Imports System.Text

Public Class ClsCheques
    Dim Conexion As New clsconexion_consumo
    Dim Conexion2 As New clsConexion

    Public Function Saldos(ByVal Cliente As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("rptn_Fact_Pago_Pendiente", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@Cliente", SqlDbType.VarChar)).Value = Cliente
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

    Public Function Clientes()
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand(" SELECT CLAVE, NOMBRE, RFC, LOCALIDAD, CALLE, ESTADO, TELEFONO, PAG_WEB AS 'PROPIETARIO', CON_CREDITO as 'CRED', SALDO, ULT_PAGOM, ULT_PAGOF, STATUS " & _
        " FROM CLIE05 WITH (NOLOCK) WHERE STATUS = 'A'", ActualizarConexion)
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

    Public Function BuscaClientes(ByVal Busca As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand(" SELECT CLAVE, NOMBRE, RFC, LOCALIDAD, CALLE, ESTADO, TELEFONO, PAG_WEB AS 'PROPIETARIO', CON_CREDITO as 'CRED', SALDO, ULT_PAGOM, ULT_PAGOF, STATUS " & _
        " FROM CLIE05 WHERE STATUS = 'A' AND NOMBRE LIKE '%" & LTrim(RTrim(Busca.ToUpper)) & "%' OR ltrim(CLAVE) = '" & LTrim(RTrim(Busca)) & "'", ActualizarConexion)
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

    Public Function Bancos()
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand(" SELECT Banco_ID as Clave, Banco_Desc as Banco FROM Usuarios.dbo.Ck_Bancos " & _
        " UNION SELECT 1111 as Clave, 'OTRO' as Banco FROM Usuarios.dbo.Ck_Bancos ", ActualizarConexion)
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

    Public Function NuevoCheque(ByVal ChequeID As String, ByVal Usuario As String, ByVal BancoTexto As String, ByVal BancoID As Integer, ByVal Cuenta As String, ByVal ChequeFecha As Date, ByVal Monto As Decimal, ByVal Cliente As String, ByVal Facturas As DataTable, ByVal NumeroBanco As Integer, ByVal Empresa As String)

        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand

            'Selecciona número de pago a guardar
            Dim NuevoConc As Integer = 0


            miComando = New SqlCommand("INSERT INTO  Ck_Cheques" & _
                                         " (Cheque_ID, Banco_ID, Banco_Desc, Cheque_Fecha, Cheque_Vencimiento, Cheque_Monto, CVE_CLIE, Cheque_Status, Cuenta_Banco, NumeroBanco, Empresa) " & _
                                         " VALUES (@Cheque_ID, @Banco_ID, @Banco_Desc, @Cheque_Fecha, @Cheque_Vencimiento, @Cheque_Monto, @CVE_CLIE, @Cheque_Status, @Cuenta_Banco, @NumeroBanco, @Empresa)", ActualizarConexion)

            miComando.Parameters.AddWithValue("@Cheque_ID", ChequeID)
            miComando.Parameters.AddWithValue("@Banco_ID", BancoID)

            miComando.Parameters.AddWithValue("@Banco_Desc", BancoTexto)
            miComando.Parameters.AddWithValue("@Cheque_Fecha", Now.Date)
            miComando.Parameters.AddWithValue("@Cheque_Vencimiento", ChequeFecha)
            miComando.Parameters.AddWithValue("@Cheque_Monto", Monto)
            miComando.Parameters.AddWithValue("@CVE_CLIE", Cliente)
            miComando.Parameters.AddWithValue("@Cheque_Status", "Pendiente")

            miComando.Parameters.AddWithValue("@Cuenta_Banco", Cuenta)
            miComando.Parameters.AddWithValue("@NumeroBanco", NumeroBanco)
            miComando.Parameters.AddWithValue("@Empresa", "SAN RAFAEL")


            miComando.Transaction = transaccion_sql
            miComando.ExecuteNonQuery()


            For index As Integer = 0 To Facturas.Rows.Count - 1
                miComando = New SqlCommand("INSERT INTO Ck_Facturas" & _
                                         " (Cheque_ID, CVE_DOC, Monto, Abonos) " & _
                                         " VALUES (@Cheque_ID, @CVE_DOC, @Monto, @Abonos)", ActualizarConexion)

                miComando.Parameters.AddWithValue("@Cheque_ID", ChequeID)
                miComando.Parameters.AddWithValue("@CVE_DOC", Facturas(index)(0))
                miComando.Parameters.AddWithValue("@Monto", Facturas(index)(2))
                miComando.Parameters.AddWithValue("@Abonos", Facturas(index)(3))

                miComando.Transaction = transaccion_sql
                miComando.ExecuteNonQuery()
            Next


            Dim conexion_bita As New cls_bitacora_reporteador
            conexion_bita.RegistraBitacora(Now, Usuario, "Completó Envío a Bancos Crédito", "CONTABILIDAD", _
                                      "Fecha: " & Now.Date & " Documento: " & ChequeID)

            transaccion_sql.Commit()
            ActualizarConexion.Close()
            Return "SI"

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

    Public Function Cheques(ByVal Fecha1, ByVal Fecha2)
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())

        Dim miComando As New SqlCommand(" SELECT  dbo.Ck_Cheques.Cheque_ID as 'Nº de Documento', dbo.Ck_Cheques.CVE_CLIE as 'Clave Cliente', SAE60Empre05.dbo.CLIE05.NOMBRE as 'Nombre Cliente', dbo.Ck_Cheques.Banco_ID as 'N Banco', dbo.Ck_Cheques.Banco_Desc as Banco,  " & _
        " dbo.Ck_Cheques.Cheque_Fecha as 'Guardado en', dbo.Ck_Cheques.Cheque_Vencimiento as 'Vencimiento', dbo.Ck_Cheques.Cheque_Monto as 'Monto', dbo.Ck_Cheques.Cheque_Status as Estado" & _
        " FROM dbo.Ck_Cheques WITH (NOLOCK)INNER JOIN " & _
        " SAE60Empre05.dbo.CLIE05 WITH (NOLOCK) ON dbo.Ck_Cheques.CVE_CLIE = SAE60Empre05.dbo.CLIE05.CLAVE COLLATE Modern_Spanish_CI_AS WHERE dbo.Ck_Cheques.Cheque_Fecha >= @FechaInicio AND dbo.Ck_Cheques.Cheque_Fecha <= @FechaFin", ActualizarConexion)
        ActualizarConexion.Open()
        Dim AdaptadorDeDatos As New SqlDataAdapter(miComando)
        miComando.Parameters.AddWithValue("@FechaInicio", Fecha1.Date)
        miComando.Parameters.AddWithValue("@FechaFin", Fecha2.Date)
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

    Public Function ChequesEstado(ByVal Estado As String, ByVal Fecha1 As Date, ByVal Fecha2 As Date)
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())

        Dim miComando As New SqlCommand(" SELECT  dbo.Ck_Cheques.Cheque_ID as 'Nº de Documento', dbo.Ck_Cheques.CVE_CLIE as 'Clave Cliente', SAE60Empre05.dbo.CLIE05.NOMBRE as 'Nombre Cliente', dbo.Ck_Cheques.Banco_ID as 'N Banco', dbo.Ck_Cheques.Banco_Desc as Banco,  " & _
        " dbo.Ck_Cheques.Cheque_Fecha as 'Guardado en', dbo.Ck_Cheques.Cheque_Vencimiento as 'Vencimiento', dbo.Ck_Cheques.Cheque_Monto as 'Monto', dbo.Ck_Cheques.Cheque_Status as Estado" & _
        " FROM dbo.Ck_Cheques INNER JOIN " & _
        " SAE60Empre05.dbo.CLIE05 ON dbo.Ck_Cheques.CVE_CLIE = SAE60Empre05.dbo.CLIE05.CLAVE COLLATE Modern_Spanish_CI_AS WHERE dbo.Ck_Cheques.Cheque_Status = @Status AND dbo.Ck_Cheques.Cheque_Fecha >= @FechaInicio AND dbo.Ck_Cheques.Cheque_Fecha <= @FechaFin", ActualizarConexion)
        ActualizarConexion.Open()
        Dim Busca As String

        If Estado = "Pendientes" Then
            Busca = "Pendiente"
        ElseIf Estado = "Enviados a SAE" Then
            Busca = "Aprobado"
        Else
            Busca = "Rechazado"
        End If
        miComando.Parameters.AddWithValue("@FechaInicio", Fecha1.Date)
        miComando.Parameters.AddWithValue("@FechaFin", Fecha2.Date)
        miComando.Parameters.AddWithValue("@Status", Busca)

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

    Public Function CargaFacturasPorCheque(ByVal Cheque As String, ByVal Banco As Integer)
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())

        Dim miComando As New SqlCommand(" SELECT     dbo.Ck_Cheques.Cheque_ID, dbo.Ck_Facturas.CVE_DOC, dbo.Ck_Facturas.Monto, dbo.Ck_Facturas.Abonos, dbo.Ck_Facturas.PAGA, dbo.Ck_Cheques.Banco_ID " & _
                                        " FROM         dbo.Ck_Cheques INNER JOIN" & _
                                        " dbo.Ck_Facturas ON dbo.Ck_Cheques.Cheque_ID = dbo.Ck_Facturas.Cheque_ID WHERE dbo.Ck_Cheques.Cheque_ID = @Cheque and dbo.Ck_Cheques.Banco_ID = @Banco ", ActualizarConexion)
        ActualizarConexion.Open()
        miComando.Parameters.AddWithValue("@Cheque", Cheque)
        miComando.Parameters.AddWithValue("@Banco", Banco)

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

    Public Function AceptaCheque(ByVal ChequeID As String, ByVal Usuario As String, ByVal dtFacturas As DataTable, ByVal Fecha_Coi As Date, ByVal Cuenta As String, ByVal Empresa_Coi As String, ByVal dt_cuentas_poliza As DataTable, ByVal nMes As Integer, ByVal nYear As Integer, ByVal Tipo_Poliza As String, ByVal NombreCliente As String, ByVal numeroDeposito As String, ByVal TOTAL As Decimal, ByVal NUMEROBANCO As Integer)

        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand
            'Selecciona Número de partida

            For index As Integer = 0 To dtFacturas.Rows.Count - 1
                Dim NuevaPart As Integer = 0

                Dim DtMarca As New DataTable
                Dim Query As String
                Query = "SELECT MAX(SAE60Empre05.dbo.CUEN_DET05.NO_PARTIDA) FROM SAE60Empre05.dbo.CUEN_DET05 WHERE SAE60Empre05.dbo.CUEN_DET05.REFER = @DOC"
                Dim CMDQuery As New SqlCommand(Query, ActualizarConexion)

                CMDQuery.Parameters.AddWithValue("@DOC", dtFacturas(index)(0))

                Dim Adaptador1 As New SqlDataAdapter(CMDQuery)
                CMDQuery.Transaction = transaccion_sql
                Adaptador1.Fill(DtMarca)

                If DtMarca.Rows.Count > 0 Then
                    If Not IsDBNull(DtMarca.Rows(0)(0)) Then
                        NuevaPart = DtMarca.Rows(0)(0)
                    End If
                End If
                NuevaPart += 1

                'Actualiza monto pagado
                Dim query_control As New StringBuilder
                query_control.Append("UPDATE [Usuarios].[dbo].[Ck_Facturas] ")
                query_control.Append("SET [PAGA] = @PAGA ")
                query_control.Append("WHERE [Cheque_ID] = @CHEQUE AND [CVE_DOC] = @DOC ")
                Dim comando_control As New SqlCommand(query_control.ToString, ActualizarConexion)

                comando_control.Parameters.AddWithValue("@CHEQUE", ChequeID)
                comando_control.Parameters.AddWithValue("@DOC", dtFacturas(index)(0))
                comando_control.Parameters.AddWithValue("@PAGA", dtFacturas(index)(4))

                comando_control.Transaction = transaccion_sql
                comando_control.ExecuteNonQuery()

                'Actualiza status cheque
                Dim query_status As New StringBuilder
                query_status.Append("UPDATE [Usuarios].[dbo].[Ck_Cheques] ")
                query_status.Append("SET [Cheque_Status] = 'Aprobado' ")
                query_status.Append("WHERE [Cheque_ID] = @CHEQUE")
                Dim comando_status As New SqlCommand(query_status.ToString, ActualizarConexion)

                comando_status.Parameters.AddWithValue("@CHEQUE", ChequeID)


                comando_status.Transaction = transaccion_sql
                comando_status.ExecuteNonQuery()

                'Selecciona correlativo de bitácora

                Dim Bita As Integer = 0
                Dim DtBita As New DataTable
                Dim QueryBita As String
                QueryBita = "SELECT ULT_CVE FROM SAE60Empre05.dbo.TBLCONTROL05 WHERE SAE60Empre05.dbo.TBLCONTROL05.ID_TABLA = 62"
                Dim CMDQueryBita As New SqlCommand(QueryBita, ActualizarConexion)
                Dim AdaptadorBita As New SqlDataAdapter(CMDQueryBita)
                CMDQueryBita.Transaction = transaccion_sql
                AdaptadorBita.Fill(DtBita)

                If DtBita.Rows.Count > 0 Then
                    If Not IsDBNull(DtBita(0)(0)) Then
                        Bita = DtBita(0)(0)
                    End If
                End If
                Bita += 1

                'Selecciona Vendedor, Cliente
                Dim Vendedor As String = ""
                Dim Cliente As String = ""

                Dim DtFact As New DataTable
                Dim QueryFact As String
                QueryFact = "SELECT CVE_CLPV, CVE_VEND FROM SAE60Empre05.dbo.FACTF05 WHERE SAE60Empre05.dbo.FACTF05.CVE_DOC = @DOC"
                Dim CMDQueryFact As New SqlCommand(QueryFact, ActualizarConexion)
                CMDQueryFact.Parameters.AddWithValue("@DOC", dtFacturas(index)(0))
                Dim AdaptadorFAct As New SqlDataAdapter(CMDQueryFact)
                CMDQueryFact.Transaction = transaccion_sql
                AdaptadorFAct.Fill(DtFact)

                If DtFact.Rows.Count > 0 Then
                    Cliente = DtFact(0)(0)
                End If

                Dim DtFact2 As New DataTable
                Dim QueryFact2 As String
                QueryFact2 = "SELECT CVE_VEND FROM SAE60Empre05.dbo.FACTF05 WHERE SAE60Empre05.dbo.FACTF05.CVE_DOC = @DOC"
                Dim CMDQueryFact2 As New SqlCommand(QueryFact2, ActualizarConexion)
                CMDQueryFact2.Parameters.AddWithValue("@DOC", dtFacturas(index)(0))
                Dim AdaptadorFAct2 As New SqlDataAdapter(CMDQueryFact2)
                CMDQueryFact2.Transaction = transaccion_sql
                AdaptadorFAct2.Fill(DtFact)

                If DtFact2.Rows.Count > 0 Then
                    If Not IsDBNull(DtFact(0)(0)) Then
                        Vendedor = DtFact(0)(0)
                    Else
                        Vendedor = ""
                    End If
                End If

                'Actualiza Bitácora y correlativo

                'update num mov  
                Dim query_control_num_mov As New StringBuilder
                query_control_num_mov.Append("UPDATE [SAE60Empre05].[dbo].[TBLCONTROL05] ")
                query_control_num_mov.Append("SET [ULT_CVE] = ULT_CVE + 1 ")
                query_control_num_mov.Append("WHERE [ID_TABLA] = 62 ")
                Dim comando_control_num_mov As New SqlCommand(query_control_num_mov.ToString, ActualizarConexion)
                comando_control_num_mov.Transaction = transaccion_sql
                comando_control_num_mov.ExecuteNonQuery()

                miComando = New SqlCommand("INSERT INTO SAE60Empre05.dbo.BITA05" & _
                                            " (CVE_BITA, CVE_CLIE, CVE_CAMPANIA, CVE_ACTIVIDAD, FECHAHORA, CVE_USUARIO, OBSERVACIONES, STATUS, NOM_USUARIO) " & _
                                            " VALUES (@CVE_BITA, @CVE_CLIE, @CVE_CAMPANIA, @CVE_ACTIVIDAD, @FECHAHORA, @CVE_USUARIO, @OBSERVACIONES, @STATUS, @NOM_USUARIO) ", ActualizarConexion)

                miComando.Parameters.AddWithValue("@CVE_BITA", Bita)
                miComando.Parameters.AddWithValue("@CVE_CLIE", Cliente)
                miComando.Parameters.AddWithValue("@CVE_CAMPANIA", "_SAE_")
                miComando.Parameters.AddWithValue("@CVE_ACTIVIDAD", 12)
                miComando.Parameters.AddWithValue("@FECHAHORA", DateTime.Now)
                miComando.Parameters.AddWithValue("@CVE_USUARIO", "0")
                miComando.Parameters.AddWithValue("@OBSERVACIONES", "No. [            " & ChequeID & "] L " & dtFacturas(index)(4) & " ")
                miComando.Parameters.AddWithValue("@STATUS", "F")
                miComando.Parameters.AddWithValue("@NOM_USUARIO", Usuario)


                miComando.Transaction = transaccion_sql
                miComando.ExecuteNonQuery()


                'Inserta CUEN_DET

                miComando = New SqlCommand("INSERT INTO SAE60Empre05.dbo.CUEN_DET05" & _
                                            " (CVE_CLIE, REFER, ID_MOV, NUM_CPTO, NUM_CARGO, CVE_OBS, NO_FACTURA, DOCTO, IMPORTE, FECHA_APLI, FECHA_VENC, AFEC_COI, " & _
                                            " STRCVEVEND, NUM_MONED, TCAMBIO, IMPMON_EXT, FECHAELAB, CTLPOL, CVE_FOLIO, TIPO_MOV, CVE_BITA, SIGNO, CVE_AUT, USUARIO, OPERACIONPL, " & _
                                            " REF_SIST, NO_PARTIDA, REFBANCO_ORIGEN, REFBANCO_DEST, NUMCTAPAGO_ORIGEN, NUMCTAPAGO_DESTINO, NUMCHEQUE, BENEFICIARIO) " & _
                                            " VALUES (@CVE_CLIE, @REFER, @ID_MOV, @NUM_CPTO, @NUM_CARGO, @CVE_OBS, @NO_FACTURA, @DOCTO, @IMPORTE, @FECHA_APLI, @FECHA_VENC, @AFEC_COI, " & _
                                            " @STRCVEVEND, @NUM_MONED, @TCAMBIO, @IMPMON_EXT, @FECHAELAB, @CTLPOL, @CVE_FOLIO, @TIPO_MOV, @CVE_BITA, @SIGNO, @CVE_AUT, @USUARIO, @OPERACIONPL, " & _
                                            " @REF_SIST, @NO_PARTIDA, @REFBANCO_ORIGEN, @REFBANCO_DEST, @NUMCTAPAGO_ORIGEN, @NUMCTAPAGO_DESTINO, @NUMCHEQUE, @BENEFICIARIO) ", ActualizarConexion)

                miComando.Parameters.AddWithValue("@CVE_CLIE", Cliente)
                miComando.Parameters.AddWithValue("@REFER", dtFacturas(index)(0))
                miComando.Parameters.AddWithValue("@ID_MOV", 1)
                miComando.Parameters.AddWithValue("@NUM_CPTO", 11)
                miComando.Parameters.AddWithValue("@NUM_CARGO", 1)
                miComando.Parameters.AddWithValue("@CVE_OBS", 0)
                miComando.Parameters.AddWithValue("@NO_FACTURA", dtFacturas(index)(1))
                miComando.Parameters.AddWithValue("@DOCTO", ChequeID)
                miComando.Parameters.AddWithValue("@IMPORTE", dtFacturas(index)(4))
                miComando.Parameters.AddWithValue("@FECHA_APLI", Now.Date)
                miComando.Parameters.AddWithValue("@FECHA_VENC", Now.Date)
                miComando.Parameters.AddWithValue("@AFEC_COI", DBNull.Value)

                If Vendedor <> "" Then
                    miComando.Parameters.AddWithValue("@STRCVEVEND", Vendedor)
                Else
                    miComando.Parameters.AddWithValue("@STRCVEVEND", DBNull.Value)
                End If

                miComando.Parameters.AddWithValue("@NUM_MONED", 1)
                miComando.Parameters.AddWithValue("@TCAMBIO", 1)
                miComando.Parameters.AddWithValue("@IMPMON_EXT", dtFacturas(index)(4))
                miComando.Parameters.AddWithValue("@FECHAELAB", DateTime.Now)
                miComando.Parameters.AddWithValue("@CTLPOL", 0)
                miComando.Parameters.AddWithValue("@CVE_FOLIO", DBNull.Value)
                miComando.Parameters.AddWithValue("@TIPO_MOV", "A")
                miComando.Parameters.AddWithValue("@CVE_BITA", Bita)
                miComando.Parameters.AddWithValue("@SIGNO", "-1")
                miComando.Parameters.AddWithValue("@CVE_AUT", DBNull.Value)
                miComando.Parameters.AddWithValue("@USUARIO", 0)
                miComando.Parameters.AddWithValue("@OPERACIONPL", DBNull.Value)
                miComando.Parameters.AddWithValue("@REF_SIST", DBNull.Value)
                miComando.Parameters.AddWithValue("@NO_PARTIDA", NuevaPart)
                miComando.Parameters.AddWithValue("@REFBANCO_ORIGEN", DBNull.Value)
                miComando.Parameters.AddWithValue("@REFBANCO_DEST", DBNull.Value)
                miComando.Parameters.AddWithValue("@NUMCTAPAGO_ORIGEN", DBNull.Value)
                miComando.Parameters.AddWithValue("@NUMCTAPAGO_DESTINO", DBNull.Value)
                miComando.Parameters.AddWithValue("@NUMCHEQUE", DBNull.Value)
                miComando.Parameters.AddWithValue("@BENEFICIARIO", DBNull.Value)


                miComando.Transaction = transaccion_sql
                miComando.ExecuteNonQuery()

                'Actualiza Saldo del cliente
                'update num mov  
                Dim QuerySaldo As New StringBuilder
                QuerySaldo.Append("UPDATE [SAE60Empre05].[dbo].[CLIE05] ")
                QuerySaldo.Append("SET [SALDO] = SALDO - " & dtFacturas(index)(4) & " ")
                QuerySaldo.Append("WHERE [CLAVE] = @Cliente ")
                Dim ComandoSaldo As New SqlCommand(QuerySaldo.ToString, ActualizarConexion)
                ComandoSaldo.Parameters.AddWithValue("@Cliente", Cliente)
                ComandoSaldo.Transaction = transaccion_sql
                ComandoSaldo.ExecuteNonQuery()

            Next

            '' ENVIO COI Y BANCO

            Dim select_gastoid = New StringBuilder()
            Dim dt_gastoid = New DataTable()
            select_gastoid.Append("SELECT [BAN40EMPRE05].[dbo].[CONTROLREGMOV].[MOVIMIENTOS] FROM [BAN40EMPRE05].[dbo].[CONTROLREGMOV] WHERE [BAN40EMPRE05].[dbo].[CONTROLREGMOV].[CUENTA] = 7 ")
            Dim comando_select_gastoid = New SqlCommand(select_gastoid.ToString(), ActualizarConexion)
            comando_select_gastoid.Transaction = transaccion_sql
            Dim adaptador = New SqlDataAdapter(comando_select_gastoid)
            adaptador.Fill(dt_gastoid)
            Dim gastoid As Integer
            gastoid = dt_gastoid.Rows(0)(0)

            Dim year_short As Integer
            year_short = Convert.ToInt32((Fecha_Coi.Year.ToString()).Substring(2, 2))

            Dim cero_poliza As String = ""
            If (nMes.ToString().Length < 2) Then
                cero_poliza = "0"
            End If

            'seleccionar el num de poliza
            Dim num_poliz As String = ""
            Dim qx_num_pol = New StringBuilder()
            qx_num_pol.Append("SELECT [FOLIO" + cero_poliza + nMes.ToString + "] ")
            qx_num_pol.Append(" FROM COI70Empre" + Empresa_Coi + ".dbo.FOLIOS" + Empresa_Coi + " ")
            qx_num_pol.Append(" WHERE (TIPPOL = @TIPO_POLI) AND (EJERCICIO = @EJERCICIO) ")
            Dim cmd_num_pol = New SqlCommand(qx_num_pol.ToString(), ActualizarConexion)
            cmd_num_pol.Transaction = transaccion_sql
            cmd_num_pol.Parameters.AddWithValue("@TIPO_POLI", Tipo_Poliza)
            cmd_num_pol.Parameters.AddWithValue("@EJERCICIO", nYear)
            Dim adaptador_num_pol = New SqlDataAdapter(cmd_num_pol)
            Dim dt_num_pol = New DataTable()
            adaptador_num_pol.Fill(dt_num_pol)

            num_poliz = Convert.ToString(Convert.ToInt32(dt_num_pol.Rows(0)(0)) + 1)

            'A

            Dim empresa_banco As String = "05"
            Dim espacios As String = ""
            For i = 0 To 5 - num_poliz.Length - 1
                espacios += " "
            Next
            num_poliz = espacios + num_poliz

            Dim FAC As String
            If dtFacturas.Rows.Count > 1 Then
                FAC = "VARIAS"
            Else
                FAC = dtFacturas(0)(0)
            End If

            'encabezado de la poliza
            Dim qx_polizas = New StringBuilder()
            qx_polizas.Append("INSERT INTO [COI70Empre" + Empresa_Coi + "].[dbo].[POLIZAS" + year_short.ToString + Empresa_Coi + "] ")
            qx_polizas.Append("([TIPO_POLI],[NUM_POLIZ],[PERIODO],[EJERCICIO],[FECHA_POL],[CONCEP_PO] ")
            qx_polizas.Append(",[NUM_PART],[LOGAUDITA],[CONTABILIZ],[NUMPARCUA],[TIENEDOCUMENTOS] ")
            qx_polizas.Append(",[PROCCONTAB],[ORIGEN],[UUID],[ESPOLIZAPRIVADA]) ")
            qx_polizas.Append("VALUES ")
            qx_polizas.Append("(@TIPO_POLI,@NUM_POLIZ,@PERIODO,@EJERCICIO,@FECHA_POL,@CONCEP_PO,@NUM_PART ")
            qx_polizas.Append(",@LOGAUDITA,@CONTABILIZ,@NUMPARCUA,@TIENEDOCUMENTOS,@PROCCONTAB,@ORIGEN ")
            qx_polizas.Append(",@UUID,@ESPOLIZAPRIVADA) ")
            Dim cmd_polizas = New SqlCommand(qx_polizas.ToString(), ActualizarConexion)
            cmd_polizas.Transaction = transaccion_sql
            cmd_polizas.Parameters.AddWithValue("TIPO_POLI", Tipo_Poliza)
            cmd_polizas.Parameters.AddWithValue("NUM_POLIZ", num_poliz)
            cmd_polizas.Parameters.AddWithValue("PERIODO", nMes)
            cmd_polizas.Parameters.AddWithValue("EJERCICIO", nYear)
            cmd_polizas.Parameters.AddWithValue("FECHA_POL", Fecha_Coi)
            cmd_polizas.Parameters.AddWithValue("@CONCEP_PO", "EFE-" & numeroDeposito & " DEPOSITOS REP F-" & FAC & " " & NombreCliente)
            cmd_polizas.Parameters.AddWithValue("NUM_PART", 1)
            cmd_polizas.Parameters.AddWithValue("LOGAUDITA", "N")
            cmd_polizas.Parameters.AddWithValue("CONTABILIZ", "S")
            cmd_polizas.Parameters.AddWithValue("NUMPARCUA", 0)
            cmd_polizas.Parameters.AddWithValue("TIENEDOCUMENTOS", 0)
            cmd_polizas.Parameters.AddWithValue("PROCCONTAB", 0)
            cmd_polizas.Parameters.AddWithValue("ORIGEN", "REPORTEADOR")
            cmd_polizas.Parameters.AddWithValue("UUID", "")
            cmd_polizas.Parameters.AddWithValue("ESPOLIZAPRIVADA", 0)
            cmd_polizas.ExecuteNonQuery()

            'recorrer todas las cuentas que se agregaran a la poliza
            For index = 0 To dt_cuentas_poliza.Rows.Count - 1
                'seleccionar la cuenta base
                Dim qx_catalogo_cuentas = New StringBuilder()
                qx_catalogo_cuentas.Append("SELECT NUM_CTA, CTA_PAPA, NIVEL FROM COI70Empre" + Empresa_Coi + ".dbo.CUENTAS" & Convert.ToString(year_short) & Empresa_Coi & " WHERE NUM_CTA = @CTA ")
                Dim cmd_catalogo_cuentas = New SqlCommand(qx_catalogo_cuentas.ToString(), ActualizarConexion)
                cmd_catalogo_cuentas.Parameters.AddWithValue("@CTA", dt_cuentas_poliza.Rows(index)(0))
                cmd_catalogo_cuentas.Transaction = transaccion_sql
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
                        qx_cuenta_rel.Append("SELECT NUM_CTA, CTA_PAPA, NIVEL FROM COI70Empre" + Empresa_Coi + ".dbo.CUENTAS" & Convert.ToString(year_short) & Empresa_Coi & " WHERE NUM_CTA = '" + cta_papa + "'")
                        Dim cmd_cuenta_rel = New SqlCommand(qx_cuenta_rel.ToString(), ActualizarConexion)
                        cmd_cuenta_rel.Transaction = transaccion_sql
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
                            qx_actualiza_saldos.Append(" UPDATE [COI70Empre" + Empresa_Coi + "].[dbo].[SALDOS" & Convert.ToString(year_short) & Empresa_Coi & "] ")

                            If dt_cuentas_poliza.Rows(index)(2) = "D" Then
                                qx_actualiza_saldos.Append("   SET [CARGO" + cero_poliza + nMes.ToString + "] = [CARGO" + cero_poliza + nMes.ToString + "] + @VALOR ")
                            ElseIf dt_cuentas_poliza.Rows(index)(2) = "H" Then
                                qx_actualiza_saldos.Append("   SET [ABONO" + cero_poliza + nMes.ToString + "] = [ABONO" + cero_poliza + nMes.ToString + "] + @VALOR ")
                            End If
                            qx_actualiza_saldos.Append(" WHERE [NUM_CTA] = @NUM_CTA AND [EJERCICIO] = @EJERCICIO ")
                            Dim cmd_actualiza_saldos = New SqlCommand(qx_actualiza_saldos.ToString(), ActualizarConexion)
                            cmd_actualiza_saldos.Transaction = transaccion_sql
                            cmd_actualiza_saldos.Parameters.AddWithValue("@NUM_CTA", cuentas_afectadas(i))
                            cmd_actualiza_saldos.Parameters.AddWithValue("@EJERCICIO", nYear)
                            cmd_actualiza_saldos.Parameters.AddWithValue("@VALOR", Convert.ToDouble(dt_cuentas_poliza.Rows(index)(1)))
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
                qx_auxiliares.Append("INSERT INTO [COI70Empre" + Empresa_Coi + "].[dbo].[AUXILIAR" + year_short.ToString + Empresa_Coi + "] ")
                qx_auxiliares.Append("   ([TIPO_POLI],[NUM_POLIZ],[NUM_PART],[PERIODO],[EJERCICIO] ")
                qx_auxiliares.Append("   ,[NUM_CTA],[FECHA_POL],[CONCEP_PO],[DEBE_HABER],[MONTOMOV] ")
                qx_auxiliares.Append("   ,[NUMDEPTO],[TIPCAMBIO],[CONTRAPAR],[ORDEN],[CCOSTOS] ")
                qx_auxiliares.Append("   ,[CGRUPOS],[IDINFADIPAR],[IDUUID]) ")
                qx_auxiliares.Append("VALUES ")
                qx_auxiliares.Append("   (@TIPO_POLI, @NUM_POLIZ , @NUM_PART, @PERIODO, @EJERCICIO ")
                qx_auxiliares.Append("   , @NUM_CTA , @FECHA_POL, @CONCEP_PO, @DEBE_HABER,@MONTOMOV ")
                qx_auxiliares.Append("   , @NUMDEPTO, @TIPCAMBIO, @CONTRAPAR, @ORDEN, @CCOSTOS ")
                qx_auxiliares.Append("   ,@CGRUPOS,@IDINFADIPAR,@IDUUID)")
                Dim cmd_ins_auxiliares = New SqlCommand(qx_auxiliares.ToString(), ActualizarConexion)
                cmd_ins_auxiliares.Transaction = transaccion_sql
                cmd_ins_auxiliares.Parameters.AddWithValue("@TIPO_POLI", Tipo_Poliza)
                cmd_ins_auxiliares.Parameters.AddWithValue("@NUM_POLIZ", num_poliz)
                cmd_ins_auxiliares.Parameters.AddWithValue("@EJERCICIO", nYear)
                cmd_ins_auxiliares.Parameters.AddWithValue("@NUM_PART", index + 1)
                cmd_ins_auxiliares.Parameters.AddWithValue("@PERIODO", nMes)
                cmd_ins_auxiliares.Parameters.AddWithValue("@NUM_CTA", dt_cuentas_poliza.Rows(index)(0))
                cmd_ins_auxiliares.Parameters.AddWithValue("@FECHA_POL", Fecha_Coi)
                cmd_ins_auxiliares.Parameters.AddWithValue("@CONCEP_PO", "EFE-" & numeroDeposito & " DEPOSITOS REP F-" & FAC & " " & NombreCliente)
                cmd_ins_auxiliares.Parameters.AddWithValue("@DEBE_HABER", dt_cuentas_poliza.Rows(index)(2))
                cmd_ins_auxiliares.Parameters.AddWithValue("@MONTOMOV", dt_cuentas_poliza.Rows(index)(1))
                cmd_ins_auxiliares.Parameters.AddWithValue("@NUMDEPTO", 0)
                cmd_ins_auxiliares.Parameters.AddWithValue("@TIPCAMBIO", 1)
                cmd_ins_auxiliares.Parameters.AddWithValue("@CONTRAPAR", 0)
                cmd_ins_auxiliares.Parameters.AddWithValue("@ORDEN", 1)
                cmd_ins_auxiliares.Parameters.AddWithValue("@CCOSTOS", 0)
                cmd_ins_auxiliares.Parameters.AddWithValue("@CGRUPOS", 0)
                cmd_ins_auxiliares.Parameters.AddWithValue("@IDINFADIPAR", -1)
                cmd_ins_auxiliares.Parameters.AddWithValue("@IDUUID", -1)
                cmd_ins_auxiliares.ExecuteNonQuery()
                ' fin partidas de la poliza
            Next

            Dim qx_upd_folios = New StringBuilder()
            qx_upd_folios.Append("UPDATE [COI70Empre" + Empresa_Coi + "].[dbo].[FOLIOS" + Empresa_Coi + "] ")
            qx_upd_folios.Append("SET [FOLIO" + cero_poliza + nMes.ToString + "] = [FOLIO" + cero_poliza + nMes.ToString + "] + 1 ")
            qx_upd_folios.Append(" WHERE (TIPPOL = @TIPO_POLI) AND (EJERCICIO = @EJERCICIO) ")
            Dim cmd_upd_folios = New SqlCommand(qx_upd_folios.ToString(), ActualizarConexion)
            cmd_upd_folios.Transaction = transaccion_sql
            cmd_upd_folios.Parameters.AddWithValue("@TIPO_POLI", Tipo_Poliza)
            cmd_upd_folios.Parameters.AddWithValue("@EJERCICIO", nYear)
            cmd_upd_folios.Transaction = transaccion_sql
            cmd_upd_folios.ExecuteNonQuery()


            'interfaz en banco'
            Dim nombre_tabla As String = ""
            If Cuenta.Length > 1 Then
                nombre_tabla = Cuenta
            Else
                nombre_tabla = "0" & NUMEROBANCO
            End If

            Dim dt_tabla_control_reg_mov As New DataTable
            Dim query_control_reg_mov As New StringBuilder
            query_control_reg_mov.Append("SELECT CUENTA, MOVIMIENTOS, PARTIDAS, MONEDA FROM BAN40EMPRE" + empresa_banco + ".dbo.CONTROLREGMOV CT ")
            query_control_reg_mov.Append("INNER JOIN  BAN40EMPRE" + empresa_banco + ".dbo.CTAS C ON C.NUM_REG = CT.CUENTA  WHERE CUENTA = @CUENTA ")
            Dim comando_control_reg_mov As New SqlCommand(query_control_reg_mov.ToString, ActualizarConexion)
            comando_control_reg_mov.Parameters.AddWithValue("@CUENTA", NUMEROBANCO)
            comando_control_reg_mov.Transaction = transaccion_sql
            Dim adaptador_control_reg_mov = New SqlDataAdapter(comando_control_reg_mov)
            adaptador_control_reg_mov.Fill(dt_tabla_control_reg_mov)
            Dim num_reg As Integer = 0, part_reg As Integer = 0, moneda As Integer = 0
            num_reg = dt_tabla_control_reg_mov.Rows(0)(1) + 1
            part_reg = dt_tabla_control_reg_mov.Rows(0)(2) + 1
            moneda = dt_tabla_control_reg_mov.Rows(0)(3)

            'ENCABEZADO MOVS
            Dim query_movs As New StringBuilder
            query_movs.Append(" INSERT INTO [BAN40EMPRE" + empresa_banco + "].[dbo].[MOVS" + nombre_tabla + "] ")
            query_movs.Append("([NUM_REG],[CVE_CONCEP],[CON_PART],[NUM_CHEQUE],[REF1],[REF2],[STATUS],[FECHA],[F_COBRO],[BAND_PRN],[BAND_CONT], ")
            query_movs.Append("[ACT_SAE],[NUM_POL],[TIP_POL],[SAE_COI],[MONTO_TOT],[MONTO_IVA_TOT],[MONTO_EXT],[MONEDA],[T_CAMBIO],[HORA],[CLPV], ")
            query_movs.Append("[CTA_TRANSF],[FECHA_LIQ],[FECHA_POL],[CVE_INST],[MONDIFSAE],[TCAMBIOSAE],[RFC],[CONC_SAE],[SOLICIT],[TRANS_COI], ")
            query_movs.Append("[INTSAENOI],[X_OBSER],[FACTOR],[FORMAPAGO],[ANOMBREDE],[ASOCIADO],[CTA_CONTAB_ASOC],[REVISADO],[PRIORIDAD],[DOC_ASOC], ")
            query_movs.Append("[RESALTAR],[ANTICIPO],[IDTRANSF],[SUCURSAL],[CUENTA],[CLABE],[MULTI_CLPV],[CVE_BANCO_ASOC],[NUM_CONC_AUTO],[COI_DEPTO], ")
            query_movs.Append("[COI_CCOSTOS],[COI_PROYECTO]) ")
            query_movs.Append("VALUES ")
            query_movs.Append("(@NUM_REG,@CVE_CONCEP,@CON_PART,@NUM_CHEQUE,@REF1,@REF2,@STATUS,@FECHA,@F_COBRO,@BAND_PRN,@BAND_CONT,@ACT_SAE,@NUM_POL, ")
            query_movs.Append("@TIP_POL,@SAE_COI,@MONTO_TOT,@MONTO_IVA_TOT,@MONTO_EXT,@MONEDA,@T_CAMBIO,@HORA,@CLPV,@CTA_TRANSF,@FECHA_LIQ,@FECHA_POL, ")
            query_movs.Append("@CVE_INST,@MONDIFSAE,@TCAMBIOSAE,@RFC,@CONC_SAE,@SOLICIT,@TRANS_COI,@INTSAENOI,@X_OBSER,@FACTOR,@FORMAPAGO,@ANOMBREDE, ")
            query_movs.Append("@ASOCIADO,@CTA_CONTAB_ASOC,@REVISADO,@PRIORIDAD,@DOC_ASOC,@RESALTAR,@ANTICIPO,@IDTRANSF,@SUCURSAL,@CUENTA,@CLABE,@MULTI_CLPV, ")
            query_movs.Append("@CVE_BANCO_ASOC,@NUM_CONC_AUTO,@COI_DEPTO,@COI_CCOSTOS,@COI_PROYECTO) ")

            Dim comando_movs As New SqlCommand(query_movs.ToString, ActualizarConexion)
            comando_movs.Parameters.AddWithValue("@NUM_REG", num_reg)
            Dim ConcBan As String
            'If TipoLiquidacion = "COBRO" Then
            ConcBan = "DES"
            'Else
            'ConcBan = "DEO"
            'End If
            comando_movs.Parameters.AddWithValue("@CVE_CONCEP", ConcBan)
            comando_movs.Parameters.AddWithValue("@CON_PART", 0)
            comando_movs.Parameters.AddWithValue("@NUM_CHEQUE", 0)
            If NombreCliente.Length >= 20 Then
                NombreCliente = NombreCliente.Substring(0, 19)
            End If
            comando_movs.Parameters.AddWithValue("@REF1", numeroDeposito)
            comando_movs.Parameters.AddWithValue("@REF2", "")
            comando_movs.Parameters.AddWithValue("@STATUS", "R")
            comando_movs.Parameters.AddWithValue("@FECHA", Fecha_Coi)
            comando_movs.Parameters.AddWithValue("@F_COBRO", Fecha_Coi)
            comando_movs.Parameters.AddWithValue("@BAND_PRN", "N")
            comando_movs.Parameters.AddWithValue("@BAND_CONT", "N")
            comando_movs.Parameters.AddWithValue("@ACT_SAE", "N")
            comando_movs.Parameters.AddWithValue("@NUM_POL", num_poliz)
            comando_movs.Parameters.AddWithValue("@TIP_POL", Tipo_Poliza)
            comando_movs.Parameters.AddWithValue("@SAE_COI", 0)
            comando_movs.Parameters.AddWithValue("@MONTO_TOT", TOTAL)
            comando_movs.Parameters.AddWithValue("@MONTO_IVA_TOT", 0)
            comando_movs.Parameters.AddWithValue("@MONTO_EXT", TOTAL)
            comando_movs.Parameters.AddWithValue("@MONEDA", moneda)
            comando_movs.Parameters.AddWithValue("@T_CAMBIO", "1")
            comando_movs.Parameters.AddWithValue("@HORA", 0)
            comando_movs.Parameters.AddWithValue("@CLPV", "")
            comando_movs.Parameters.AddWithValue("@CTA_TRANSF", 0)
            comando_movs.Parameters.AddWithValue("@FECHA_LIQ", DBNull.Value)
            comando_movs.Parameters.AddWithValue("@FECHA_POL", Fecha_Coi)
            comando_movs.Parameters.AddWithValue("@CVE_INST", 0)
            comando_movs.Parameters.AddWithValue("@MONDIFSAE", DBNull.Value)
            comando_movs.Parameters.AddWithValue("@TCAMBIOSAE", "0")
            comando_movs.Parameters.AddWithValue("@RFC", "")
            comando_movs.Parameters.AddWithValue("@CONC_SAE", "")
            comando_movs.Parameters.AddWithValue("@SOLICIT", DBNull.Value)
            comando_movs.Parameters.AddWithValue("@TRANS_COI", "0")
            comando_movs.Parameters.AddWithValue("@INTSAENOI", "0")
            comando_movs.Parameters.AddWithValue("@X_OBSER", "")
            comando_movs.Parameters.AddWithValue("@FACTOR", "1")
            comando_movs.Parameters.AddWithValue("@FORMAPAGO", "3")
            comando_movs.Parameters.AddWithValue("@ANOMBREDE", "")
            comando_movs.Parameters.AddWithValue("@ASOCIADO", "B")
            comando_movs.Parameters.AddWithValue("@CTA_CONTAB_ASOC", DBNull.Value)
            comando_movs.Parameters.AddWithValue("@REVISADO", "0")
            comando_movs.Parameters.AddWithValue("@PRIORIDAD", "")
            comando_movs.Parameters.AddWithValue("@DOC_ASOC", 0)
            comando_movs.Parameters.AddWithValue("@RESALTAR", 0)
            comando_movs.Parameters.AddWithValue("@ANTICIPO", 0)
            comando_movs.Parameters.AddWithValue("@IDTRANSF", "")
            comando_movs.Parameters.AddWithValue("@SUCURSAL", "")
            comando_movs.Parameters.AddWithValue("@CUENTA", "")
            comando_movs.Parameters.AddWithValue("@CLABE", "")
            comando_movs.Parameters.AddWithValue("@MULTI_CLPV", "0")
            comando_movs.Parameters.AddWithValue("@CVE_BANCO_ASOC", "")
            comando_movs.Parameters.AddWithValue("@NUM_CONC_AUTO", 0)
            comando_movs.Parameters.AddWithValue("@COI_DEPTO", DBNull.Value)
            comando_movs.Parameters.AddWithValue("@COI_CCOSTOS", DBNull.Value)
            comando_movs.Parameters.AddWithValue("@COI_PROYECTO", DBNull.Value)
            comando_movs.Transaction = transaccion_sql
            comando_movs.ExecuteNonQuery()

            'ACTUALIZAR NUMEROS DE MOVIMIENTOS
            Dim query_num_movs As New StringBuilder
            query_num_movs.Append("UPDATE BAN40EMPRE05.dbo.CONTROLREGMOV SET MOVIMIENTOS = MOVIMIENTOS + 1 WHERE (CUENTA = @CUENTA) ")
            Dim comando_num_movs As New SqlCommand(query_num_movs.ToString, ActualizarConexion)
            comando_num_movs.Parameters.AddWithValue("@CUENTA", NUMEROBANCO)
            comando_num_movs.Transaction = transaccion_sql
            comando_num_movs.ExecuteNonQuery()
            ' fin interfaz banco



            ''
            ''
            ''

            Dim conexion_bita As New cls_bitacora_reporteador
            conexion_bita.RegistraBitacora(Now, Usuario, "Envio depósito SAE, Banco ", "CONTABILIDAD", _
                                      "Fecha: " & Now.Date & " Documento: " & ChequeID)

            transaccion_sql.Commit()
            ActualizarConexion.Close()
            Return "SI"

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

    Public Function RechazaCheque(ByVal ChequeID As String, ByVal Usuario As String, ByVal Concepto As String, ByVal ConceptoID As Integer, ByVal NuevoConcepto As String)

        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand
            'Selecciona Número de partida

            Dim NuevoConc As Integer = 0

            If Concepto = "OTRO CONCEPTO" Then
                Dim DtMarca As New DataTable
                Dim Query As String
                Query = "SELECT MAX(Concepto_ID) FROM Ck_ConceptoRechazo"
                Dim CMDQuery As New SqlCommand(Query, ActualizarConexion)

                Dim Adaptador As New SqlDataAdapter(CMDQuery)
                CMDQuery.Transaction = transaccion_sql
                Adaptador.Fill(DtMarca)

                If DtMarca.Rows.Count > 0 Then
                    If Not IsDBNull(DtMarca.Rows(0)(0)) Then
                        NuevoConc = DtMarca.Rows(0)(0)
                    End If
                End If
                NuevoConc += 1

                miComando = New SqlCommand("INSERT INTO Ck_ConceptoRechazo" & _
                                         " (Concepto_ID, Concepto_Nombre) " & _
                                         " VALUES (@Concepto_ID, @Concepto_Nombre)", ActualizarConexion)

                miComando.Parameters.AddWithValue("@Concepto_ID", ConceptoID)
                miComando.Parameters.AddWithValue("@Concepto_Nombre", NuevoConcepto)

                ConceptoID = NuevoConcepto
                Concepto = NuevoConcepto

                miComando.Transaction = transaccion_sql
                miComando.ExecuteNonQuery()

            End If
            'Actualiza status cheque
            Dim query_status As New StringBuilder
            query_status.Append("UPDATE [Usuarios].[dbo].[Ck_Cheques] ")
            query_status.Append("SET [Cheque_Status] = 'Rechazado', [CONCEPTOREC] = @Concepto ")
            query_status.Append("WHERE [Cheque_ID] = @CHEQUE")
            Dim comando_status As New SqlCommand(query_status.ToString, ActualizarConexion)

            comando_status.Parameters.AddWithValue("@CHEQUE", ChequeID)
            comando_status.Parameters.AddWithValue("@Concepto", Concepto)


            comando_status.Transaction = transaccion_sql
            comando_status.ExecuteNonQuery()


            Dim conexion_bita As New cls_bitacora_reporteador
            conexion_bita.RegistraBitacora(Now, Usuario, "Rechazó Cheque PostFechado ", "CONTABILIDAD", _
                                      "Fecha: " & Now.Date & " Documento: " & ChequeID)

            transaccion_sql.Commit()
            ActualizarConexion.Close()
            Return "SI"

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

    Public Function Conceptos()
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())

        Dim miComando As New SqlCommand(" SELECT  Concepto_ID, Concepto_Nombre FROM  Ck_ConceptoRechazo UNION  " & _
        " SELECT  11111 as Concepto_ID, 'OTRO CONCEPTO' as Concepto_Nombre FROM Ck_ConceptoRechazo ", ActualizarConexion)
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

    Public Function DetallesBanco(ByVal Banco As Integer, ByVal Empresa As String)
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())

        Dim miComando As New SqlCommand(" SELECT Banco_Desc, Empresa, Cuenta_COI, Cuenta_Banco, Numero_Cuenta_Banco " & _
                                        " FROM Ck_Bancos WHERE (Banco_ID = @Banco) and Empresa = @Empresa ", ActualizarConexion)
        ActualizarConexion.Open()
        Dim AdaptadorDeDatos As New SqlDataAdapter(miComando)
        miComando.Parameters.AddWithValue("@Banco", Banco)
        miComando.Parameters.AddWithValue("@Empresa", Empresa)
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

    Public Function DetallesCliente(ByVal Cliente As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand(" SELECT CASE substring(CLASIFIC, 5, 1) WHEN 'P' THEN 1 WHEN 'R' THEN 2 WHEN 'T' THEN 3 WHEN 'G' THEN 4 END AS ALMACEN " & _
                                        " FROM CLIE05 WHERE (LTRIM(CLAVE) = LTRIM(@CLIENTE)) ", ActualizarConexion)
        ActualizarConexion.Open()
        Dim AdaptadorDeDatos As New SqlDataAdapter(miComando)
        miComando.Parameters.AddWithValue("@CLIENTE", Cliente)

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
