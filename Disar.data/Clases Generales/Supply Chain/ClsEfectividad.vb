Imports System.Data.SqlClient
Imports System.Text

Public Class ClsEfectividad
    Dim Conexion As New clsconexion_consumo
    Dim Conexion2 As New clsConexion
    Dim ConexionDimosa As New cls_conexion_DIMOSA
    Dim ConexionOPL As New cls_conexionOPL
    Dim Conexion3 As New cls_conexion_descuentos_tacticos
    Dim ConexionDescDimosa As New cls_conexion_descuentos_tacticos_dimosa
    Dim ConexionDescAgro As New cls_conexion_descuentos_tacticos_sragro
    Dim Conexion4 As New cls_conexion_sip
    Dim Conexion5 As New cls_conexion_sip_dimosa
    Dim Conexion6OPL As New cls_conexionSipOPL
    Dim ConexionCC As New clsConexion_Centro_Costos


    Public Function Entregadores(ByVal Sucursal As Integer, ByVal Empresa As String)
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())

        Dim miComando As New SqlCommand
        If Empresa = "SAN RAFAEL" Or Empresa = "DIMOSA" Or Empresa = "OPL" Then
            If Sucursal = 0 Then
                miComando = New SqlCommand("SELECT EntregadorCodigo, EntregadorNombre, EntregadorSucursal, Vehiculo, Identidad, Num_almacen " &
                                            "FROM Entregadores", ActualizarConexion)
            Else
                miComando = New SqlCommand("SELECT EntregadorCodigo, EntregadorNombre, EntregadorSucursal, Vehiculo, Identidad, Num_almacen " &
                                        " FROM Entregadores where Num_almacen = @ID ", ActualizarConexion)
                miComando.Parameters.AddWithValue("@ID", Sucursal)
            End If
        Else
            If Sucursal = 0 Then
                miComando = New SqlCommand("SELECT EntregadorCodigo, EntregadorNombre, EntregadorSucursal, Vehiculo, Identidad, Num_almacen " & _
                                            "FROM Entregadores", ActualizarConexion)
            Else
                miComando = New SqlCommand("SELECT EntregadorCodigo, EntregadorNombre, EntregadorSucursal, Vehiculo, Identidad, Num_almacen " & _
                                        " FROM Entregadores where num_almacen_sr_agro = @ID ", ActualizarConexion)
                miComando.Parameters.AddWithValue("@ID", Sucursal)
            End If
        End If

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

    Public Function RutaDeFactura(ByVal Factura As String)
        Dim ActualizarConexion As New SqlConnection(Conexion4.CadenaSQL())

        Dim miComando As New SqlCommand
         
        miComando = New SqlCommand("SELECT  LOTE_RUTA FROM LOTES WHERE (DOC_INI <= @Factura) AND (DOC_FIN >= @Factura) ", ActualizarConexion)
        miComando.Parameters.AddWithValue("@Factura", Factura)




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

    Public Function FiltrarEntregadores(ByVal Almacen As Integer)
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT EntregadorCodigo, EntregadorNombre, EntregadorSucursal, Vehiculo, Identidad, Num_almacen " & _
                                        "FROM Entregadores WHERE Num_almacen = @Almacen", ActualizarConexion)

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

    Public Function Vehiculos()
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT     VehiculoId, VehiculoDescripcion, Sucursal " & _
                                        " FROM         Vehiculos_Entregadores", ActualizarConexion)

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

    Public Function FiltrarVehiculos(ByVal Almacen As Integer)
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT     VehiculoId, VehiculoDescripcion, Sucursal " & _
                                        " FROM         Vehiculos_Entregadores WHERE Sucursal = @Sucursal", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Sucursal", Almacen)

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

    Public Function Reporte(ByVal FECHA_INI As Date, ByVal FECHA_FIN As Date, ByVal TIPO As String, ByVal FILTRO As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("efectividad_diaria", ActualizarConexion)

        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.AddWithValue("@FECHA_INI", FECHA_INI)
        miComando.Parameters.AddWithValue("@FECHA_FIN", FECHA_FIN)
        miComando.Parameters.AddWithValue("@TIPO", TIPO)
        miComando.Parameters.AddWithValue("@FILTRO", FILTRO)

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


    ''''''''''''''''''''''''''''''''''''
    ''''''''''''''''''''''''''''''''''''
    ''''''''''''''''''''''''''''''''''''
    ''''''Sistema de Liquidaciones''''''
    ''''''''''''''''''''''''''''''''''''
    ''''''''''''''''''''''''''''''''''''
    ''''''''''''''''''''''''''''''''''''


    Public Function VerificarLiquidación(ByVal ENTREGADOR As Integer, ByVal Fecha1 As Date, ByVal Fecha2 As Date, ByVal Tipo As String, ByVal Usuario As String, ByVal Empresa As String)
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim miComando
        If Usuario = "No" Then
            miComando = New SqlCommand("SELECT Numero, ISNULL(Estado, 'Sin Iniciar') AS Estado, Completado, Hora, Fecha, ISNULL(Ruta,0), ISNULL(Num_Facturas,0) " & _
        " FROM Liq_Encabezado  WHERE Entregador = @Entregador AND Fecha = @Fecha And Tipo = @Tipo AND ESTADO <> 'Completa' And Empresa = @Empresa", ActualizarConexion)
            miComando.Parameters.AddWithValue("@Entregador", ENTREGADOR)
            miComando.Parameters.AddWithValue("@Tipo", Tipo)
            miComando.Parameters.AddWithValue("@Fecha", Today.Date)
            miComando.Parameters.AddWithValue("@Empresa", Empresa)
        Else
            miComando = New SqlCommand("SELECT Numero, ISNULL(Estado, 'Sin Iniciar') AS Estado, Completado, Hora, Fecha, ISNULL(Ruta,0), ISNULL(Num_Facturas,0) " & _
        " FROM Liq_Encabezado  WHERE Entregador = @Entregador AND FechaLiquidacion1 = @Fecha1 AND FechaLiquidacion2 = @Fecha2 And Tipo = @Tipo AND ESTADO = 'Completa' And Empresa = @Empresa ", ActualizarConexion)
            miComando.Parameters.AddWithValue("@Entregador", ENTREGADOR)
            miComando.Parameters.AddWithValue("@Tipo", Tipo)
            miComando.Parameters.AddWithValue("@Fecha1", Fecha1.Date)
            miComando.Parameters.AddWithValue("@Fecha2", Fecha2.Date)
            miComando.Parameters.AddWithValue("@Empresa", Empresa)
        End If

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

    Public Function VerificarRuta(ByVal Numero As Integer)
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT Ruta FROM Liq_Encabezado WHERE Numero = @Numero", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Numero", Numero)

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

    Public Function Almacen(ByVal ENTREGADOR As Integer)
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT  EntregadorSucursal " & _
                                        "FROM Entregadores WHERE EntregadorCodigo = @Entrega", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Entrega", ENTREGADOR)

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

    Public Function NombreUsuario(ByVal User As String)
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT UsuarioNombre FROM  [User] WHERE UsuarioNick = @Usuario", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Usuario", User)

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

    Public Function Rutas(ByVal Sucursal)
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT   RutaID, Ruta, Sucursal  FROM Liq_Rutas WHERE Sucursal = @Sucursal ORDER BY RUTA", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Sucursal", Sucursal)

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

    Public Function RutasDIMOSA(ByVal Sucursal)
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT   RutaID, Ruta, Sucursal  FROM Liq_Rutas_DIMOSA WHERE Sucursal = @Sucursal ORDER BY RUTA", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Sucursal", Sucursal)

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

    Public Function FechaHora() As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT  CONVERT(char(10), GETDATE(), 103) AS FECHA, CONVERT(char(10), GETDATE(), 108) AS HORA", ActualizarConexion)



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

    Public Function NuevaLiquidacion(ByVal Entregador As Integer, ByVal Fecha As Date, ByVal Hora As String, ByVal Tipo As String, ByVal FechaLiquidacion1 As Date, ByVal FechaLiquidacion2 As Date, ByVal Empresa As String, ByVal INICIORUTA As String, ByVal FINRUTA As String)

        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand
            'Guarda nueva marca


            Dim NumBita As Integer = 0
            Dim DtBita As New DataTable
            Dim QueryBita As String
            QueryBita = "SELECT MAX (Numero) FROM Liq_Encabezado"
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
            miComando = New SqlCommand("INSERT INTO Liq_Encabezado" & _
                                         " (Numero, Entregador, Completado, Hora, Fecha, Tipo, FechaLiquidacion1, FechaLiquidacion2, Empresa, INICIO, FINAL) " & _
                                         " VALUES (@Numero, @Entregador, @Completado, @Hora, @Fecha, @Tipo, @FechaLiquidacion1, @FechaLiquidacion2, @Empresa, @INICIO, @FINAL)", ActualizarConexion)
            miComando.Parameters.AddWithValue("@Numero", NumBita)
            miComando.Parameters.AddWithValue("@Entregador", Entregador)
            miComando.Parameters.AddWithValue("@Tipo", Tipo)
            miComando.Parameters.AddWithValue("@Completado", 0)
            miComando.Parameters.AddWithValue("@Hora", Hora)
            miComando.Parameters.AddWithValue("@Fecha", Fecha)
            miComando.Parameters.AddWithValue("@FechaLiquidacion1", FechaLiquidacion1)
            miComando.Parameters.AddWithValue("@FechaLiquidacion2", FechaLiquidacion2)
            miComando.Parameters.AddWithValue("@Empresa", Empresa)
            miComando.Parameters.AddWithValue("@INICIO", INICIORUTA)
            miComando.Parameters.AddWithValue("@FINAL", FINRUTA)


            miComando.Transaction = transaccion_sql
            miComando.ExecuteNonQuery()

            transaccion_sql.Commit()
            ActualizarConexion.Close()
            Return NumBita
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

    Public Function Pantalla1(ByVal Numero As Integer, ByVal Ruta As Integer, ByVal FechaVenta As Date, ByVal FechaFacturado As Date, ByVal FechaCobro As Date, ByVal NFac As String, ByVal dt As DataTable, ByVal Vehiculo As Integer, ByVal Kilometraje As Decimal)

        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand

            miComando = New SqlCommand(" UPDATE Liq_Encabezado " & _
                                         " SET Ruta = @Ruta, Fecha_Venta = @Fecha_Venta, Fecha_Facturado = @Fecha_Facturado, Fecha_Cobro = @Fecha_Cobro, Num_Facturas = @Num_Facturas, Estado = @Estado, Completado = @Completado, Vehiculo = @Vehiculo, Kilometraje = @Kilometraje " & _
                                         " WHERE Numero = @Numero", ActualizarConexion)
            miComando.Parameters.AddWithValue("@Numero", Numero)
            miComando.Parameters.AddWithValue("@Ruta", Ruta)
            miComando.Parameters.AddWithValue("@Fecha_Venta", FechaVenta.Date)
            miComando.Parameters.AddWithValue("@Fecha_Facturado", FechaFacturado.Date)
            miComando.Parameters.AddWithValue("@Fecha_Cobro", FechaCobro.Date)
            miComando.Parameters.AddWithValue("@Num_Facturas", NFac)
            miComando.Parameters.AddWithValue("@Estado", "Iniciada")
            miComando.Parameters.AddWithValue("@Completado", 1)
            miComando.Parameters.AddWithValue("@Vehiculo", Vehiculo)
            miComando.Parameters.AddWithValue("@Kilometraje", Kilometraje)

            miComando.Transaction = transaccion_sql
            miComando.ExecuteNonQuery()

            For a As Integer = 0 To dt.Rows.Count - 1
                If Not IsDBNull(dt(a)(0)) Then
                    If dt(a)(0) <> "" Then
                        miComando = New SqlCommand(" INSERT INTO Liq_Rangos " & _
                                                 " (Liq_ID, Liq_Desde, Liq_Hasta) " & _
                                                 " VALUES(@Liq_ID, @Liq_Desde, @Liq_Hasta) ", ActualizarConexion)
                        miComando.Parameters.AddWithValue("@Liq_ID", Numero)
                        miComando.Parameters.AddWithValue("@Liq_Desde", dt(a)(0))
                        miComando.Parameters.AddWithValue("@Liq_Hasta", dt(a)(1))

                        miComando.Transaction = transaccion_sql
                        miComando.ExecuteNonQuery()
                    End If
                End If
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

    Public Function Pantalla2(ByVal Numero As Integer, ByVal dt As DataTable, ByVal Total As Decimal, ByVal Deposito As String)

        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand

            miComando = New SqlCommand(" UPDATE Liq_Encabezado " & _
                                         " SET Completado = 2 " & _
                                         " WHERE Numero = " & Numero & "", ActualizarConexion)

            miComando.Transaction = transaccion_sql
            miComando.ExecuteNonQuery()

            miComando = New SqlCommand(" INSERT INTO Liq_Arqueo " & _
                                         " (Numero, L500, L100, L50, L20, L10, L5, L2, L1, C50, C20, C10, C5, Deposito, Total) " & _
                                         " VALUES (@Numero, @L500, @L100, @L50, @L20, @L10, @L5, @L2, @L1, @C50, @C20, @C10, @C5, @Deposito, @Total)", ActualizarConexion)

            miComando.Parameters.AddWithValue("@Numero", Numero)
            miComando.Parameters.AddWithValue("@L500", dt(0)(0))
            miComando.Parameters.AddWithValue("@L100", dt(1)(0))
            miComando.Parameters.AddWithValue("@L50", dt(2)(0))
            miComando.Parameters.AddWithValue("@L20", dt(3)(0))
            miComando.Parameters.AddWithValue("@L10", dt(4)(0))
            miComando.Parameters.AddWithValue("@L5", dt(5)(0))
            miComando.Parameters.AddWithValue("@L2", dt(6)(0))
            miComando.Parameters.AddWithValue("@L1", dt(7)(0))
            miComando.Parameters.AddWithValue("@C50", dt(8)(0))
            miComando.Parameters.AddWithValue("@C20", dt(9)(0))
            miComando.Parameters.AddWithValue("@C10", dt(10)(0))
            miComando.Parameters.AddWithValue("@C5", dt(11)(0))
            miComando.Parameters.AddWithValue("@Total", Total)
            miComando.Parameters.AddWithValue("@Deposito", Deposito)

            miComando.Transaction = transaccion_sql
            miComando.ExecuteNonQuery()

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

    Public Function Pantalla3(ByVal Numero As Integer, ByVal dt As DataTable, ByVal Galones As Decimal, ByVal km As Decimal)

        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand

            miComando = New SqlCommand(" UPDATE Liq_Encabezado " & _
                                         " SET Completado = 3, GalonesCombustible = @Galones,  Kilometraje = @Kilometraje  " & _
                                         " WHERE Numero = " & Numero & "", ActualizarConexion)
            miComando.Parameters.AddWithValue("@Galones", Galones)
            miComando.Parameters.AddWithValue("@Kilometraje", km)

            miComando.Transaction = transaccion_sql
            miComando.ExecuteNonQuery()

            For index As Integer = 0 To dt.Rows.Count - 1

                If Not IsDBNull(dt.Rows(index)(6)) Then

                    Dim NumBita As Integer = 0
                    Dim DtBita As New DataTable
                    Dim QueryBita As String
                    QueryBita = "SELECT MAX (NumeroGasto) FROM Liq_Gastos"
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

                    miComando = New SqlCommand(" INSERT INTO Liq_Gastos " & _
                                     " (Numero, NumeroGasto, TipoGasto, NombreGasto, Num_Factura, Negocio, Valor, Cantidad, ValorTotal) " & _
                                     " VALUES (@Numero, @NumeroGasto, @TipoGasto, @NombreGasto, @Num_Factura, @Negocio, @Valor, @Cantidad, @ValorTotal)", ActualizarConexion)

                    miComando.Parameters.AddWithValue("@Numero", Numero)
                    miComando.Parameters.AddWithValue("@NumeroGasto", NumBita)
                    miComando.Parameters.AddWithValue("@TipoGasto", dt(index)(2))
                    miComando.Parameters.AddWithValue("@NombreGasto", dt(index)(3))
                    miComando.Parameters.AddWithValue("@Num_Factura", dt(index)(4))
                    miComando.Parameters.AddWithValue("@Negocio", dt(index)(5))
                    miComando.Parameters.AddWithValue("@Valor", dt(index)(6))
                    miComando.Parameters.AddWithValue("@Cantidad", dt(index)(7))
                    miComando.Parameters.AddWithValue("@ValorTotal", dt(index)(8))

                    miComando.Transaction = transaccion_sql
                    miComando.ExecuteNonQuery()
                End If
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

    Public Function Pantalla4(ByVal Numero As Integer, ByVal dt As DataTable)

        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand

            miComando = New SqlCommand(" UPDATE Liq_Encabezado " & _
                                         " SET Completado = 4 " & _
                                         " WHERE Numero = " & Numero & "", ActualizarConexion)

            miComando.Transaction = transaccion_sql
            miComando.ExecuteNonQuery()
            For index As Integer = 0 To dt.Rows.Count - 1
                If Not IsDBNull(dt.Rows(index)(3)) Then
                    Dim NumBita As Integer = 0
                    Dim DtBita As New DataTable
                    Dim QueryBita As String
                    QueryBita = "SELECT MAX (Cheque_Numero) FROM Liq_Cheques"
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

                    miComando = New SqlCommand(" INSERT INTO Liq_Cheques " & _
                                     " (Numero, Cheque_Numero, NombreNegocio, Numero_Cheque, Numero_Factura, Valor, Banco) " & _
                                     " VALUES (@Numero, @Cheque_Numero, @NombreNegocio, @Numero_Cheque, @Numero_Factura, @Valor, @Banco)", ActualizarConexion)

                    miComando.Parameters.AddWithValue("@Numero", Numero)
                    miComando.Parameters.AddWithValue("@Cheque_Numero", NumBita)
                    miComando.Parameters.AddWithValue("@NombreNegocio", dt(index)(2))
                    miComando.Parameters.AddWithValue("@Numero_Cheque", dt(index)(3))
                    miComando.Parameters.AddWithValue("@Numero_Factura", dt(index)(4))
                    miComando.Parameters.AddWithValue("@Valor", dt(index)(5))
                    miComando.Parameters.AddWithValue("@Banco", dt(index)(6))

                    miComando.Transaction = transaccion_sql
                    miComando.ExecuteNonQuery()
                End If
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

    Public Function Detalle_Credito_Cobro(ByVal Numero As Integer, ByVal Tipo As String, ByVal dt As DataTable)

        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand

            miComando = New SqlCommand(" UPDATE Liq_Encabezado " & _
                                         " SET Completado = 4 " & _
                                         " WHERE Numero = " & Numero & "", ActualizarConexion)

            miComando.Transaction = transaccion_sql
            miComando.ExecuteNonQuery()
            For index As Integer = 0 To dt.Rows.Count - 1
                If Not IsDBNull(dt.Rows(index)(3)) Then
                    miComando = New SqlCommand(" INSERT INTO  Liq_Detalle_CredCob " & _
                                     " (Liq_Numero, Liq_Tipo, Codigo_Cliente, Nombre_Negocio, Factura, Valor) " & _
                                     " VALUES (@Liq_Numero, @Liq_Tipo, @Codigo_Cliente, @Nombre_Negocio, @Factura, @Valor)", ActualizarConexion)

                    miComando.Parameters.AddWithValue("@Liq_Numero", Numero)
                    miComando.Parameters.AddWithValue("@Liq_Tipo", Tipo)

                    miComando.Parameters.AddWithValue("@Codigo_Cliente", dt(index)(0))
                    miComando.Parameters.AddWithValue("@Nombre_Negocio", dt(index)(1))
                    miComando.Parameters.AddWithValue("@Factura", dt(index)(2))
                    miComando.Parameters.AddWithValue("@Valor", dt(index)(3))

                    miComando.Transaction = transaccion_sql
                    miComando.ExecuteNonQuery()
                End If
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

    Public Function CargaArqueo(ByVal Numero As Integer)
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT        Numero, ISNULL(L500,0), ISNULL(L100,0),ISNULL(L50,0), ISNULL(L20,0), ISNULL(L10,0), ISNULL(L5,0), ISNULL(L2,0), ISNULL(L1,0), ISNULL(C50,0), ISNULL(C20,0), ISNULL(C10,0), ISNULL(C5,0), ISNULL(Deposito,''), Total " & _
        " FROM Liq_Arqueo " & _
        " WHERE NUMERO = @Numero", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Numero", Numero)

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

    Public Function CargaDetallesCredito(ByVal Numero As Integer)
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT Codigo_Cliente AS 'CODIGO CLIENTE', Nombre_Negocio AS 'NOMBRE DEL NEGOCIO', Factura AS 'Nº FACT', Valor AS 'VALOR' " & _
        " FROM Liq_Detalle_CredCob " & _
        " WHERE Liq_Numero = @Numero", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Numero", Numero)

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

    Public Function CargaCheques(ByVal Numero As Integer)
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT Numero, Cheque_Numero, NombreNegocio, Numero_Cheque, Numero_Factura, Valor, Banco " & _
                                        " FROM Liq_Cheques WHERE Numero = @Numero", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Numero", Numero)

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

    Public Function CargaGastos(ByVal Numero As Integer)
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim miComando As New SqlCommand(" SELECT Numero, NumeroGasto, TipoGasto, NombreGasto, Num_Factura, Negocio, Valor, Cantidad, ValorTotal " & _
                                        " FROM Liq_Gastos WHERE Numero = @Numero", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Numero", Numero)

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

    Public Function NotasCredito(ByVal Entregador As Integer, ByVal Fecha As Date, ByVal Tipo As String, ByVal Fecha2 As Date)
        Dim Op As String = "="
        If Tipo = "Contado" Then
            Op = ">"
        End If
        If Tipo = "Crédito" Then
            Op = "="
        End If
        Dim ActualizarConexion As New SqlConnection(Conexion3.CadenaSQL())
        Dim miComando As New SqlCommand(" SELECT        SUM(dbo.encabezados.IMPORTE) AS NC " & _
                                        " FROM            dbo.encabezados INNER JOIN " & _
                                        " SAE60Empre05.dbo.FACTF05 ON SAE60Empre05.dbo.FACTF05.CVE_DOC = dbo.encabezados.FACTURA COLLATE Latin1_General_Bin " & _
                                        " WHERE        (SAE60Empre05.dbo.FACTF05.FECHA_DOC >= @Fecha) AND (SAE60Empre05.dbo.FACTF05.FECHA_DOC <= @Fecha2) AND (SAE60Empre05.dbo.FACTF05.CONDICION = @Entregador) AND (SAE60Empre05.dbo.FACTF05.PRIMERPAGO " & Op & " 0 ) AND (ISNULL(dbo.encabezados.ESTADO_SAE, 'A') <> 'C')", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Entregador", Entregador)
        miComando.Parameters.AddWithValue("@Fecha", Fecha)
        miComando.Parameters.AddWithValue("@Fecha2", Fecha2)

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

    Public Function NotasCreditoDimosa(ByVal Entregador As Integer, ByVal Fecha As Date, ByVal Tipo As String, ByVal Fecha2 As Date)
        Dim Op As String = "="
        If Tipo = "Contado" Then
            Op = ">"
        End If
        If Tipo = "Crédito" Then
            Op = "="
        End If
        Dim ActualizarConexion As New SqlConnection(ConexionDescDimosa.CadenaSQL())
        Dim miComando As New SqlCommand(" SELECT        SUM(dbo.encabezados.IMPORTE) AS NC " & _
                                        " FROM            dbo.encabezados INNER JOIN " & _
                                        " SAE60Empre06.dbo.FACTF06 ON SAE60Empre06.dbo.FACTF06.CVE_DOC = dbo.encabezados.FACTURA COLLATE Latin1_General_Bin " & _
                                        " WHERE        (SAE60Empre06.dbo.FACTF06.FECHA_DOC >= @Fecha) AND (SAE60Empre06.dbo.FACTF06.FECHA_DOC <= @Fecha2) AND (SAE60Empre06.dbo.FACTF06.CONDICION = @Entregador) AND (SAE60Empre06.dbo.FACTF06.PRIMERPAGO " & Op & " 0 ) AND (ISNULL(dbo.encabezados.ESTADO_SAE, 'A') <> 'C')", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Entregador", Entregador)
        miComando.Parameters.AddWithValue("@Fecha", Fecha)
        miComando.Parameters.AddWithValue("@Fecha2", Fecha2)

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

    Public Function NotasCreditoAgro(ByVal Entregador As Integer, ByVal Fecha As Date, ByVal Tipo As String, ByVal Fecha2 As Date)
        Dim Op As String = "="
        If Tipo = "Contado" Then
            Op = ">"
        End If
        If Tipo = "Crédito" Then
            Op = "="
        End If
        Dim ActualizarConexion As New SqlConnection(ConexionDescAgro.CadenaSQL())
        Dim miComando As New SqlCommand(" SELECT        SUM(dbo.encabezados.IMPORTE) AS NC " & _
                                        " FROM            dbo.encabezados INNER JOIN " & _
                                        " SAE60Empre02.dbo.FACTF02 ON SAE60Empre02.dbo.FACTF02.CVE_DOC = dbo.encabezados.FACTURA COLLATE Latin1_General_Bin " & _
                                        " WHERE        (SAE60Empre02.dbo.FACTF02.FECHA_DOC >= @Fecha) AND (SAE60Empre02.dbo.FACTF02.FECHA_DOC <= @Fecha2) AND (SAE60Empre02.dbo.FACTF02.CONDICION = @Entregador) AND (SAE60Empre02.dbo.FACTF02.PRIMERPAGO " & Op & " 0 ) (ISNULL(dbo.encabezados.ESTADO_SAE, 'A') <> 'C')", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Entregador", Entregador)
        miComando.Parameters.AddWithValue("@Fecha", Fecha)
        miComando.Parameters.AddWithValue("@Fecha2", Fecha2)

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

    Public Function Pantalla5(ByVal Numero As Integer, ByVal dt As DataTable, ByVal Hora As String, ByVal DepositoFinal As String)

        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try

            Dim miComando2 As New SqlCommand

            miComando2 = New SqlCommand(" UPDATE Liq_Arqueo " & _
                                         " SET Deposito = @Deposito " & _
                                         " WHERE Numero = " & Numero & "", ActualizarConexion)

            miComando2.Parameters.AddWithValue("@Deposito", DepositoFinal)

            miComando2.Transaction = transaccion_sql
            miComando2.ExecuteNonQuery()

            Dim miComando As New SqlCommand

            miComando = New SqlCommand(" UPDATE Liq_Encabezado " & _
                                         " SET Completado = 5, Estado = 'Completa', HoraFinal = @HoraFinal " & _
                                         " WHERE Numero = " & Numero & "", ActualizarConexion)

            miComando.Parameters.AddWithValue("@HoraFinal", Hora)

            miComando.Transaction = transaccion_sql
            miComando.ExecuteNonQuery()
            For index As Integer = 0 To dt.Rows.Count - 1
                If Not IsDBNull(dt.Rows(index)(0)) Then
                    Dim NumBita As Integer = 0
                    Dim DtBita As New DataTable
                    Dim QueryBita As String
                    QueryBita = "SELECT MAX (NumeroDetalle) FROM Liq_Detalle"
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

                    miComando = New SqlCommand(" INSERT INTO Liq_Detalle " & _
                                     " (Numero, NumeroDetalle, Detalle, Documento, Monto) " & _
                                     " VALUES (@Numero, @NumeroDetalle, @Detalle, @Documento, @Monto)", ActualizarConexion)

                    miComando.Parameters.AddWithValue("@Numero", Numero)
                    miComando.Parameters.AddWithValue("@NumeroDetalle", NumBita)
                    miComando.Parameters.AddWithValue("@Detalle", dt(index)(0))
                    miComando.Parameters.AddWithValue("@Documento", dt(index)(1))
                    miComando.Parameters.AddWithValue("@Monto", dt(index)(2))

                    miComando.Transaction = transaccion_sql
                    miComando.ExecuteNonQuery()
                End If
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

    Public Function EdicionPantalla5(ByVal Numero As Integer, ByVal dt As DataTable, ByVal Hora As String, ByVal DepositoFinal As String)

        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try

            Dim miComando2 As New SqlCommand

            Dim NumBita2 As Integer = 0
            Dim DtBita2 As New DataTable
            Dim QueryBita2 As String
            QueryBita2 = "SELECT * FROM Liq_Detalle WHERE Numero = @Numero"
            Dim CMDQueryBita2 As New SqlCommand(QueryBita2, ActualizarConexion)
            CMDQueryBita2.Parameters.AddWithValue("@Numero", Numero)

            Dim AdaptadorBita2 As New SqlDataAdapter(CMDQueryBita2)
            CMDQueryBita2.Transaction = transaccion_sql
            AdaptadorBita2.Fill(DtBita2)

            If DtBita2.Rows.Count > 0 Then
                If Not IsDBNull(DtBita2.Rows(0)(0)) Then
                    NumBita2 = 1
                End If
            End If

            If NumBita2 <> 0 Then
                miComando2 = New SqlCommand(" DELETE FROM Liq_Detalle " & _
                                             " WHERE  Numero = @Numero " & _
                                             " ", ActualizarConexion)

                miComando2.Parameters.AddWithValue("@Numero", Numero)

                miComando2.Transaction = transaccion_sql
                miComando2.ExecuteNonQuery()

            End If

            Dim miComando As New SqlCommand

            miComando = New SqlCommand(" UPDATE Liq_Encabezado " & _
                                         " SET Completado = 5, Estado = 'Completa', HoraFinal = @HoraFinal " & _
                                         " WHERE Numero = " & Numero & "", ActualizarConexion)

            miComando.Parameters.AddWithValue("@HoraFinal", Hora)

            miComando.Transaction = transaccion_sql
            miComando.ExecuteNonQuery()
            For index As Integer = 0 To dt.Rows.Count - 1
                If Not IsDBNull(dt.Rows(index)(0)) Then
                    Dim NumBita As Integer = 0
                    Dim DtBita As New DataTable
                    Dim QueryBita As String
                    QueryBita = "SELECT MAX (NumeroDetalle) FROM Liq_Detalle"
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

                    miComando = New SqlCommand(" INSERT INTO Liq_Detalle " & _
                                     " (Numero, NumeroDetalle, Detalle, Documento, Monto) " & _
                                     " VALUES (@Numero, @NumeroDetalle, @Detalle, @Documento, @Monto)", ActualizarConexion)

                    miComando.Parameters.AddWithValue("@Numero", Numero)
                    miComando.Parameters.AddWithValue("@NumeroDetalle", NumBita)
                    miComando.Parameters.AddWithValue("@Detalle", dt(index)(0))
                    miComando.Parameters.AddWithValue("@Documento", dt(index)(1))
                    miComando.Parameters.AddWithValue("@Monto", dt(index)(2))

                    miComando.Transaction = transaccion_sql
                    miComando.ExecuteNonQuery()
                End If
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

    Public Function SeleccionaRuta(ByVal Entregador As Integer, ByVal Fecha As Date)
        Dim ActualizarConexion As New SqlConnection(Conexion4.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT LOTE_RUTA, LOTE_VEHICULOID FROM LOTES WHERE    " & _
                                        "(LOTE_FECHA_FACT = @Fec1) AND (LOTE_ENTREGADORID = @ID) ", ActualizarConexion)

        miComando.Parameters.AddWithValue("@ID", Entregador)
        miComando.Parameters.AddWithValue("@Fec1", Fecha)

        ActualizarConexion.Open()
        Dim AdaptadorDeDatos As New SqlDataAdapter(miComando)
        Dim dt As New DataTable
        Try
            AdaptadorDeDatos.Fill(dt)
            ActualizarConexion.Close()
        Catch ex As SqlException
            'MsgBox("Hay un problema con la conexión a los datos " & ex.Message, MsgBoxStyle.Critical)
            ActualizarConexion.Close()
        End Try
        Return dt
    End Function

    Public Function SeleccionaRutaDIMOSA(ByVal Entregador As Integer, ByVal Fecha As Date)
        Dim ActualizarConexion As New SqlConnection(Conexion5.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT LOTE_RUTA, LOTE_VEHICULOID FROM LOTES WHERE    " & _
                                        "(LOTE_FECHA_FACT = @Fec1) AND (LOTE_ENTREGADORID = @ID) ", ActualizarConexion)

        miComando.Parameters.AddWithValue("@ID", Entregador)
        miComando.Parameters.AddWithValue("@Fec1", Fecha)

        ActualizarConexion.Open()
        Dim AdaptadorDeDatos As New SqlDataAdapter(miComando)
        Dim dt As New DataTable
        Try
            AdaptadorDeDatos.Fill(dt)
            ActualizarConexion.Close()
        Catch ex As SqlException
            'MsgBox("Hay un problema con la conexión a los datos " & ex.Message, MsgBoxStyle.Critical)
            ActualizarConexion.Close()
        End Try
        Return dt
    End Function

    Public Function SeleccionaRutaOPL(ByVal Entregador As Integer, ByVal Fecha As Date)
        Dim ActualizarConexion As New SqlConnection(Conexion6OPL.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT LOTE_RUTA, LOTE_VEHICULOID FROM LOTES WHERE    " & _
                                        "(LOTE_FECHA_FACT = @Fec1) AND (LOTE_ENTREGADORID = @ID) ", ActualizarConexion)

        miComando.Parameters.AddWithValue("@ID", Entregador)
        miComando.Parameters.AddWithValue("@Fec1", Fecha)

        ActualizarConexion.Open()
        Dim AdaptadorDeDatos As New SqlDataAdapter(miComando)
        Dim dt As New DataTable
        Try
            AdaptadorDeDatos.Fill(dt)
            ActualizarConexion.Close()
        Catch ex As SqlException
            'MsgBox("Hay un problema con la conexión a los datos " & ex.Message, MsgBoxStyle.Critical)
            ActualizarConexion.Close()
        End Try
        Return dt
    End Function


    Public Function SeleccionarFacturas(ByVal Entregador As Integer, ByVal Fecha1 As Date, ByVal Fecha2 As Date, ByVal Busca As String, ByVal Empresa As String)
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim miComando As New SqlCommand
        If Empresa = "SAN RAFAEL" Then
            miComando = New SqlCommand("SELECT        SAE60Empre05.dbo.FACTF05.CVE_DOC, SAE60Empre05.dbo.CLIE05.CLAVE, SAE60Empre05.dbo.CLIE05.NOMBRE, SAE60Empre05.dbo.FACTF05.IMPORTE " & _
            " FROM            SAE60Empre05.dbo.CLIE05 INNER JOIN  SAE60Empre05.dbo.FACTF05 ON SAE60Empre05.dbo.CLIE05.CLAVE = SAE60Empre05.dbo.FACTF05.CVE_CLPV " & _
            "   WHERE        (SAE60Empre05.dbo.FACTF05.FECHA_DOC >= @Fecha1) AND (SAE60Empre05.dbo.FACTF05.CONDICION = @Entregador) AND (SAE60Empre05.dbo.FACTF05.FECHA_DOC <= @Fecha2) AND (SAE60Empre05.dbo.CLIE05.NOMBRE LIKE '%" & Busca & "%') ", ActualizarConexion)
        ElseIf Empresa = "DIMOSA" Then
            miComando = New SqlCommand("SELECT        SAE60Empre06.dbo.FACTF06.CVE_DOC, SAE60Empre06.dbo.CLIE06.CLAVE, SAE60Empre06.dbo.CLIE06.NOMBRE, SAE60Empre06.dbo.FACTF06.IMPORTE " & _
            " FROM            SAE60Empre06.dbo.CLIE06 INNER JOIN  SAE60Empre06.dbo.FACTF06 ON SAE60Empre06.dbo.CLIE06.CLAVE = SAE60Empre06.dbo.FACTF06.CVE_CLPV " & _
            "   WHERE        (SAE60Empre06.dbo.FACTF06.FECHA_DOC >= @Fecha1) AND (SAE60Empre06.dbo.FACTF06.CONDICION = @Entregador) AND (SAE60Empre06.dbo.FACTF06.FECHA_DOC <= @Fecha2) AND (SAE60Empre06.dbo.CLIE06.NOMBRE LIKE '%" & Busca & "%') ", ActualizarConexion)
        Else
            miComando = New SqlCommand("SELECT        SAE60Empre02.dbo.FACTF02.CVE_DOC, SAE60Empre02.dbo.CLIE02.CLAVE, SAE60Empre02.dbo.CLIE02.NOMBRE, SAE60Empre02.dbo.FACTF02.IMPORTE " & _
            " FROM            SAE60Empre02.dbo.CLIE02 INNER JOIN  SAE60Empre02.dbo.FACTF02 ON SAE60Empre02.dbo.CLIE02.CLAVE = SAE60Empre02.dbo.FACTF02.CVE_CLPV " & _
            "   WHERE        (SAE60Empre02.dbo.FACTF02.FECHA_DOC >= @Fecha1) AND (SAE60Empre02.dbo.FACTF02.CONDICION = @Entregador) AND (SAE60Empre02.dbo.FACTF02.FECHA_DOC <= @Fecha2) AND (SAE60Empre02.dbo.CLIE02.NOMBRE LIKE '%" & Busca & "%') ", ActualizarConexion)
        End If
        miComando.Parameters.AddWithValue("@Entregador", Entregador)
        miComando.Parameters.AddWithValue("@Fecha1", Fecha1)
        miComando.Parameters.AddWithValue("@Fecha2", Fecha1)

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

    Public Function CargaLiquidaciones(ByVal Fechaini As Date, ByVal FechaFin As Date, ByVal Empresa As Integer, ByVal eMPRE As String)
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim miComando As New SqlCommand
        If Empresa = 0 Then
            miComando = New SqlCommand("SELECT dbo.Liq_Encabezado.Numero AS 'Nº Liquidación', dbo.Liq_Encabezado.Entregador, dbo.Entregadores.EntregadorNombre AS 'Entregador ', REPLACE(Identidad, '-', '') AS IDENTIDAD, " & _
                         " dbo.Liq_Encabezado.Tipo AS 'Tipo de Liquidación', SUM(dbo.Liq_Gastos.ValorTotal) AS 'Total de Gastos', dbo.Liq_Encabezado.Fecha, dbo.Liq_Encabezado.Fecha_Facturado AS 'Fecha de Facturación', dbo.Liq_Rutas.Ruta, ISNULL(CONVERT(VARCHAR(MAX), " & _
                         " CASE dbo.Liq_Encabezado.Validado WHEN 1 THEN 'REVISADOS' END), 'SIN REVISAR') AS 'GASTOS', Hora as 'Inicio', HoraFinal as 'Final' FROM            dbo.Liq_Encabezado INNER JOIN " & _
                         " dbo.Liq_Gastos ON dbo.Liq_Encabezado.Numero = dbo.Liq_Gastos.Numero INNER JOIN " & _
                         " dbo.Entregadores ON dbo.Liq_Encabezado.Entregador = dbo.Entregadores.EntregadorCodigo FULL OUTER JOIN " & _
                         " dbo.Liq_Rutas ON dbo.Liq_Encabezado.Ruta = dbo.Liq_Rutas.RutaID WHERE dbo.Liq_Encabezado.Fecha_Facturado >= @FechaIni AND dbo.Liq_Encabezado.Fecha_Facturado <= @FechaFin and dbo.Liq_Encabezado.Estado = 'Completa' " & _
                         " GROUP BY dbo.Liq_Encabezado.Numero, dbo.Liq_Encabezado.Entregador, dbo.Entregadores.EntregadorNombre, dbo.Entregadores.Identidad, dbo.Liq_Encabezado.Fecha, dbo.Liq_Rutas.Ruta, " & _
                         " dbo.Liq_Encabezado.Validado, dbo.Liq_Encabezado.Tipo, dbo.Liq_Encabezado.Fecha_Facturado, Hora, HoraFinal", ActualizarConexion)
        Else
            miComando = New SqlCommand("SELECT dbo.Liq_Encabezado.Numero AS 'Nº Liquidación', dbo.Liq_Encabezado.Entregador, dbo.Entregadores.EntregadorNombre AS 'Entregador ', REPLACE(Identidad, '-', '') AS IDENTIDAD, " & _
                         " dbo.Liq_Encabezado.Tipo AS 'Tipo de Liquidación', SUM(dbo.Liq_Gastos.ValorTotal) AS 'Total de Gastos', dbo.Liq_Encabezado.Fecha, dbo.Liq_Encabezado.Fecha_Facturado AS 'Fecha de Facturación', dbo.Liq_Rutas.Ruta, ISNULL(CONVERT(VARCHAR(MAX), " & _
                         " CASE dbo.Liq_Encabezado.Validado WHEN 1 THEN 'REVISADOS' END), 'SIN REVISAR') AS 'GASTOS',Hora as 'Inicio', HoraFinal as 'Final' FROM            dbo.Liq_Encabezado INNER JOIN " & _
                         " dbo.Liq_Gastos ON dbo.Liq_Encabezado.Numero = dbo.Liq_Gastos.Numero INNER JOIN " & _
                         " dbo.Entregadores ON dbo.Liq_Encabezado.Entregador = dbo.Entregadores.EntregadorCodigo FULL OUTER JOIN " & _
                         " dbo.Liq_Rutas ON dbo.Liq_Encabezado.Ruta = dbo.Liq_Rutas.RutaID WHERE dbo.Liq_Encabezado.Fecha_Facturado >= @FechaIni AND dbo.Liq_Encabezado.Fecha_Facturado <= @FechaFin AND dbo.Liq_Encabezado.Estado = 'Completa' and dbo.Entregadores.Num_almacen = @Almacen " & _
                         " GROUP BY dbo.Liq_Encabezado.Numero, dbo.Liq_Encabezado.Entregador, dbo.Entregadores.EntregadorNombre, dbo.Entregadores.Identidad, dbo.Liq_Encabezado.Fecha, dbo.Liq_Rutas.Ruta, " & _
                         " dbo.Liq_Encabezado.Validado, dbo.Liq_Encabezado.Tipo, dbo.Liq_Encabezado.Fecha_Facturado, Hora, HoraFinal", ActualizarConexion)

            miComando.Parameters.AddWithValue("@Almacen", Empresa)
        End If

        ActualizarConexion.Open()
        miComando.Parameters.AddWithValue("@Fechaini", Fechaini.Date)
        miComando.Parameters.AddWithValue("@FechaFin", FechaFin.Date)
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

    Public Function Porcentaje(ByVal Fecha As Date, ByVal CVE_PEDI As String)
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())

        Dim Query = New StringBuilder()
        Query.Append("SELECT ID,EMPLEADO,(CASE WHEN PORCENTAJE<0 THEN 0 ELSE PORCENTAJE END) AS PORCENTAJE,VENTA,COSTO FROM   ")
        Query.Append("(SELECT ID,EMPLEADO, ROUND(VENTA/(SELECT SUM(VENTA) FROM (SELECT (SELECT TOP(1) EMPLEADOID FROM CENTRALCOSTO.dbo.EMPLEADO  ")
        Query.Append("WHERE CODIGO_SAE = CVE_VEND COLLATE MODERN_SPANISH_CI_AS) AS ID, ROUND(SUM((CANT*PREC) - (CANT*PREC*DESC1/100)),2) AS VENTA FROM ")
        Query.Append("SAE60Empre05.dbo.FACTF05 F INNER JOIN SAE60Empre05.dbo.PAR_FACTF05 PF ON F.CVE_DOC = PF.CVE_DOC  WHERE CVE_PEDI = @CVE_PEDI   ")
        Query.Append("AND FECHA_DOC = @FECHA_DOC GROUP BY CVE_VEND ) A WHERE ID IS NOT NULL)*100,4) AS PORCENTAJE, (CASE WHEN VENTA < 0 THEN 0 ELSE VENTA END)  ")
        Query.Append("AS VENTA,  (CASE WHEN COSTO < 0 THEN 0 ELSE COSTO END) AS COSTO  ")
        Query.Append("FROM (  SELECT (SELECT EMPLEADOID FROM CENTRALCOSTO.dbo.EMPLEADO WHERE CODIGO_SAE = CVE_VEND COLLATE MODERN_SPANISH_CI_AS AND EMPRESA_AFEC = 'SAN RAFAEL'  ")
        Query.Append("COLLATE MODERN_SPANISH_CI_AS) AS ID, (SELECT EMPLEADONOMBRE FROM CENTRALCOSTO.dbo.EMPLEADO WHERE CODIGO_SAE = CVE_VEND  ")
        Query.Append("COLLATE MODERN_SPANISH_CI_AS AND EMPRESA_AFEC = 'SAN RAFAEL' COLLATE MODERN_SPANISH_CI_AS) AS EMPLEADO,   ")
        Query.Append("ROUND(SUM((CANT*PREC) - (CANT*PREC*DESC1/100)),2) AS VENTA, ROUND(SUM(CANT*COST),2) AS COSTO   ")
        Query.Append("FROM SAE60Empre05.dbo.FACTF05 F INNER JOIN SAE60Empre05.dbo.PAR_FACTF05 PF ON F.CVE_DOC = PF.CVE_DOC    ")
        Query.Append("WHERE	CVE_PEDI = @CVE_PEDI AND FECHA_DOC = @FECHA_DOC ")
        Query.Append("GROUP BY CVE_VEND   ")
        Query.Append(") A ")
        Query.Append("WHERE ID IS NOT NULL ) B ")

        Dim miComando As New SqlCommand(Query.ToString, ActualizarConexion)

        ActualizarConexion.Open()
        miComando.Parameters.AddWithValue("@FECHA_DOC", Fecha.Date)
        miComando.Parameters.AddWithValue("@CVE_PEDI", CVE_PEDI)
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

    Public Function CargaCostos(ByVal Liquidacion As Integer)
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim miComando As New SqlCommand(" SELECT Numero, TipoGasto, NombreGasto, Num_Factura as 'Nº Factura', Negocio, ValorTotal, ValorTotal AS 'Autorizado a CC' " & _
                                        " FROM Liq_Gastos WHERE NUMERO = @Liquidacion ORDER BY CASE WHEN NOMBREGASTO = 'Transporte Entregador Pre-Autorizado' THEN 1 WHEN NOMBREGASTO = 'Gastos de Representación' THEN 1 WHEN NOMBREGASTO = 'Transporte Autorizado por Supervisor' THEN 2 " & _
                      " WHEN NOMBREGASTO = 'Transporte Auxiliar' THEN 3 WHEN NOMBREGASTO = 'Gasto Externo' THEN 3 WHEN NOMBREGASTO = 'Alimentación' THEN 4 WHEN NOMBREGASTO = 'SubTotal Hotel' THEN 5 WHEN NOMBREGASTO = 'ISV 15% Hotel' THEN 6  " & _
                      " WHEN NOMBREGASTO = 'ISV 4% Hotel' THEN 7 WHEN NOMBREGASTO = 'Impuestos Municipales' THEN 8 WHEN NOMBREGASTO = 'Impuesto de Guerra' THEN 9 WHEN NOMBREGASTO = 'Peaje' THEN 10 " & _
                      " WHEN NOMBREGASTO = 'Reparación de llantas' THEN 11 WHEN NOMBREGASTO = 'Reengauche de llantas' THEN 12 WHEN NOMBREGASTO = 'Lubricantes' THEN 13 WHEN NOMBREGASTO = 'Combustible' THEN 14 " & _
                      " WHEN NOMBREGASTO = 'Alquiler de Trocos' THEN 15 ELSE 16 END ", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Liquidacion", Liquidacion)

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

    Public Function CargaCostosVarios(ByVal Fecha As Date, ByVal Entregador As Integer)
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim miComando As New SqlCommand(" SELECT     1 AS Numero, dbo.Liq_Gastos.TipoGasto, dbo.Liq_Gastos.NombreGasto, '' AS 'Nº Factura', '' AS 'Negocio', SUM(dbo.Liq_Gastos.ValorTotal) AS 'ValorTotal', " & _
                      " SUM(dbo.Liq_Gastos.ValorTotal) AS 'Autorizado a CC' " & _
                      " FROM         dbo.Liq_Gastos INNER JOIN " & _
                      " dbo.Liq_Encabezado ON dbo.Liq_Gastos.Numero = dbo.Liq_Encabezado.Numero " & _
                      " WHERE     (dbo.Liq_Encabezado.Fecha = @Fecha) AND (dbo.Liq_Encabezado.Entregador = @Entregador) AND (dbo.Liq_Encabezado.Estado = 'Completa') " & _
                      " GROUP BY dbo.Liq_Encabezado.Fecha, dbo.Liq_Gastos.TipoGasto, dbo.Liq_Gastos.NombreGasto " & _
                      " ORDER BY CASE WHEN NOMBREGASTO = 'Transporte Entregador Pre-Autorizado' THEN 1 WHEN NOMBREGASTO = 'Gastos de Representación' THEN 1 WHEN NOMBREGASTO = 'Transporte Autorizado por Supervisor' THEN 2 " & _
                      " WHEN NOMBREGASTO = 'Transporte Auxiliar' THEN 3 WHEN NOMBREGASTO = 'Gasto Externo' THEN 3 WHEN NOMBREGASTO = 'Alimentación' THEN 4 WHEN NOMBREGASTO = 'SubTotal Hotel' THEN 5 WHEN NOMBREGASTO = 'ISV 15% Hotel' THEN 6  " & _
                      " WHEN NOMBREGASTO = 'ISV 4% Hotel' THEN 7 WHEN NOMBREGASTO = 'Impuestos Municipales' THEN 8 WHEN NOMBREGASTO = 'Impuesto de Guerra' THEN 9 WHEN NOMBREGASTO = 'Peaje' THEN 10 " & _
                      " WHEN NOMBREGASTO = 'Reparación de llantas' THEN 11 WHEN NOMBREGASTO = 'Reengauche de llantas' THEN 12 WHEN NOMBREGASTO = 'Lubricantes' THEN 13 WHEN NOMBREGASTO = 'Combustible' THEN 14 " & _
                      " WHEN NOMBREGASTO = 'Alquiler de Trocos' THEN 15 ELSE 16 END " & _
                      " ", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Entregador", Entregador)
        miComando.Parameters.AddWithValue("@Fecha", Fecha)

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

    Public Function CargaVehiculo(ByVal Entregador As Integer, ByVal Fecha As Date)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand(" SELECT TOP (1) CVE_PEDI FROM dbo.FACTF05 WHERE (FECHA_DOC = @Fecha) AND (CONDICION = @ENTREGADOR) ", ActualizarConexion)

        miComando.Parameters.AddWithValue("@ENTREGADOR", Entregador)
        miComando.Parameters.AddWithValue("@Fecha", Fecha.Date)

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

    Public Function precios_combustible(ByVal almacen As Integer)
        Dim conexion = New SqlConnection(ConexionCC.CadenaSQL)
        conexion.Open()

        Dim dt = New DataTable()
        Dim Query = New StringBuilder()

        Query.Append("SELECT PRECIO AS 'PRECIO LITRO', ULT_FECHA AS 'ULTIMA MODIFICACION', ALMACEN AS CODIGO, dbo.ALMACENES.ALMACENNOMBRE AS ALMACEN, PRECIO_GAL AS 'PRECIO GALON' ")
        Query.Append("FROM PREC_COMBU INNER JOIN  dbo.ALMACENES ON dbo.ALMACENES.ALMACENID = dbo.PREC_COMBU.ALMACEN ")
        Query.Append("WHERE ALMACENID = @ALMACEN OR @ALMACEN = -1 ")

        Dim comando = New SqlCommand(Query.ToString(), conexion)
        comando.Parameters.AddWithValue("@ALMACEN", almacen)

        Dim adaptador = New SqlDataAdapter(comando)
        adaptador.Fill(dt)

        conexion.Close()

        Return dt
    End Function

    Public Function DatosEntregador(ByVal Entregador As String)
        Dim ActualizarConexion As New SqlConnection(ConexionCC.CadenaSQL())
        Dim miComando As New SqlCommand(" SELECT EMPLEADOID, DEPTOID, EMPRESA_AFEC, ALMACEN " & _
                                        " FROM    EMPLEADO WHERE (EMPLEADOID = @ID)", ActualizarConexion)

        miComando.Parameters.AddWithValue("@ID", Entregador)
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

    Public Function CargaEnviosBancos(ByVal Fecha As Date, ByVal Almacen As String)

        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim Comando As String
        If Almacen = 0 Then
            Comando = " SELECT dbo.Liq_Encabezado.Numero AS 'Nº Liquidación', dbo.Liq_Encabezado.Entregador AS ID, dbo.Entregadores.EntregadorNombre AS 'Entregador', dbo.Liq_Arqueo.Deposito, dbo.Liq_Arqueo.Total, " & _
                         " dbo.Liq_Rutas.Ruta, dbo.Liq_Encabezado.Fecha_Facturado AS 'Fecha de Facturación', Tipo, Entregadores.Num_almacen as 'Almacén',  dbo.Liq_Encabezado.Empresa" & _
                         " FROM            dbo.Liq_Arqueo INNER JOIN dbo.Liq_Encabezado ON dbo.Liq_Arqueo.Numero = dbo.Liq_Encabezado.Numero INNER JOIN " & _
                         " dbo.Liq_Rutas ON dbo.Liq_Encabezado.Ruta = dbo.Liq_Rutas.RutaID INNER JOIN " & _
                         " dbo.Entregadores ON dbo.Liq_Encabezado.Entregador = dbo.Entregadores.EntregadorCodigo " & _
                         " WHERE (dbo.Liq_Encabezado.Deposito IS NULL) and dbo.Liq_Encabezado.Fecha_Facturado = @Fecha AND Estado = 'Completa' "
        Else
            Comando = " SELECT dbo.Liq_Encabezado.Numero AS 'Nº Liquidación', dbo.Liq_Encabezado.Entregador AS ID, dbo.Entregadores.EntregadorNombre AS 'Entregador', dbo.Liq_Arqueo.Deposito, dbo.Liq_Arqueo.Total, " & _
                         " dbo.Liq_Rutas.Ruta, dbo.Liq_Encabezado.Fecha_Facturado AS 'Fecha de Facturación', Tipo, Entregadores.Num_almacen as 'Almacén',  dbo.Liq_Encabezado.Empresa " & _
                         " FROM            dbo.Liq_Arqueo INNER JOIN dbo.Liq_Encabezado ON dbo.Liq_Arqueo.Numero = dbo.Liq_Encabezado.Numero INNER JOIN " & _
                         " dbo.Liq_Rutas ON dbo.Liq_Encabezado.Ruta = dbo.Liq_Rutas.RutaID INNER JOIN " & _
                         " dbo.Entregadores ON dbo.Liq_Encabezado.Entregador = dbo.Entregadores.EntregadorCodigo " & _
                         " WHERE (dbo.Liq_Encabezado.Deposito IS NULL) and dbo.Liq_Encabezado.Fecha_Facturado = @Fecha and Entregadores.Num_almacen = @Almacen and Estado = 'Completa'"
        End If
        Dim miComando As New SqlCommand(Comando, ActualizarConexion)

        miComando.Parameters.AddWithValue("@Fecha", Fecha.Date)
        miComando.Parameters.AddWithValue("@Almacen",  almacen)

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

    Public Function CargaEnviosBancosDepositosClientes(ByVal Fecha As Date, ByVal Almacen As String)

        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim Comando As String
        If Almacen = 0 Then
            Comando = " SELECT        dbo.Liq_Encabezado.Numero AS 'Nº Liquidación', dbo.Liq_Encabezado.Entregador AS ID, dbo.Entregadores.EntregadorNombre AS 'Entregador', ISNULL(dbo.Liq_Detalle.Documento,'') AS Deposito, " & _
                      " dbo.Liq_Detalle.Monto AS Total, dbo.Liq_Rutas.Ruta, dbo.Liq_Encabezado.Fecha_Facturado AS 'Fecha de Facturación', dbo.Liq_Encabezado.Tipo, dbo.Entregadores.Num_almacen AS 'Almacén', " & _
                      " dbo.Liq_Encabezado.Empresa, dbo.Liq_Detalle.Detalle AS 'Banco Deposito' " & _
                      " FROM            dbo.Liq_Encabezado INNER JOIN " & _
                      " dbo.Liq_Rutas ON dbo.Liq_Encabezado.Ruta = dbo.Liq_Rutas.RutaID INNER JOIN " & _
                      " dbo.Entregadores ON dbo.Liq_Encabezado.Entregador = dbo.Entregadores.EntregadorCodigo INNER JOIN " & _
                      " dbo.Liq_Detalle ON dbo.Liq_Encabezado.Numero = dbo.Liq_Detalle.Numero " & _
                      " WHERE        (dbo.Liq_Encabezado.Deposito IS NULL) AND (dbo.Liq_Encabezado.Fecha_Facturado = @Fecha) AND (dbo.Liq_Encabezado.Estado = 'Completa') AND (dbo.Liq_Detalle.Detalle IN ('Depósito Occidente', " & _
                      " 'Los Trabajadores', 'Davivienda', 'Bac Honduras', 'Depósito Atlántida')) AND (ISNULL(dbo.Liq_Detalle.Monto, 0) > 0) "
        Else
            Comando = " SELECT        dbo.Liq_Encabezado.Numero AS 'Nº Liquidación', dbo.Liq_Encabezado.Entregador AS ID, dbo.Entregadores.EntregadorNombre AS 'Entregador', ISNULL(dbo.Liq_Detalle.Documento,'') AS Deposito, " & _
                      " dbo.Liq_Detalle.Monto AS Total, dbo.Liq_Rutas.Ruta, dbo.Liq_Encabezado.Fecha_Facturado AS 'Fecha de Facturación', dbo.Liq_Encabezado.Tipo, dbo.Entregadores.Num_almacen AS 'Almacén', " & _
                      " dbo.Liq_Encabezado.Empresa, dbo.Liq_Detalle.Detalle AS 'Banco Deposito' " & _
                      " FROM            dbo.Liq_Encabezado INNER JOIN " & _
                      " dbo.Liq_Rutas ON dbo.Liq_Encabezado.Ruta = dbo.Liq_Rutas.RutaID INNER JOIN " & _
                      " dbo.Entregadores ON dbo.Liq_Encabezado.Entregador = dbo.Entregadores.EntregadorCodigo INNER JOIN " & _
                      " dbo.Liq_Detalle ON dbo.Liq_Encabezado.Numero = dbo.Liq_Detalle.Numero " & _
                      " WHERE        (dbo.Liq_Encabezado.Deposito IS NULL) AND (dbo.Liq_Encabezado.Fecha_Facturado = @Fecha) AND (dbo.Liq_Encabezado.Estado = 'Completa') AND (dbo.Liq_Detalle.Detalle IN ('Depósito Occidente', " & _
                      " 'Los Trabajadores', 'Davivienda', 'Bac Honduras', 'Depósito Atlántida')) AND (ISNULL(dbo.Liq_Detalle.Monto, 0) > 0) AND Entregadores.Num_almacen = @Almacen  "
        End If
        Dim miComando As New SqlCommand(Comando, ActualizarConexion)

        miComando.Parameters.AddWithValue("@Fecha", Fecha.Date)
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

    Public Function ins_gasto_entrega(ByVal usuario As String, ByVal dtEmpleados As DataTable, _
                                    ByVal EMP_COI As String, ByVal DEPTO_COI As Integer, ByVal SUCURSAL_COI As Integer, ByVal Fecha As Date, _
                                    ByVal Ruta As String, ByVal Alimentacion As String, ByVal Hotel As Decimal, ByVal Vehiculo As Integer, ByVal TransAuxiliar As Decimal, _
                                    ByVal ImpMunicipal As Decimal, ByVal ImpGuerra As Decimal, ByVal Peaje As Decimal, ByVal RepLlantas As Decimal, ByVal PrecComb As Decimal, ByVal RencLlantas As Decimal, _
                                    ByVal ISVHotel As Decimal, ByVal Lubricantes As Decimal, ByVal Comb As Decimal, ByVal trocos As Decimal, ByVal Taxi As Decimal, ByVal Total As Decimal, ByVal ValISV4 As Decimal, ByVal ValISV15 As Decimal, _
                                    ByVal SubTotalHotel As Decimal, ByVal CodigoEntregador As Integer, ByVal Identidad As String, ByVal Vehiculares As Decimal)
        Dim transaccion As SqlTransaction
        Dim conexion = New SqlConnection(ConexionCC.CadenaSQL)
        conexion.Open()
        transaccion = conexion.BeginTransaction()
        Try

            Dim sb = New StringBuilder()
            sb.Append("INSERT INTO [CENTRALCOSTO].[dbo].[REG_GASTOS_ENT] ")
            sb.Append("       ([EMPLEADOID],[FECHA],[DESCRIPCION],[VAL_ALI],[VAL_HOTEL],[VEHICULOID],[TRANS_AUXILIAR] ")
            sb.Append("       ,[IMP_MUNICIPAL],[IMP_GUERRA],[PEAJE],[ESTADO],[HORA_INI],[HORA_FIN],[REP_LLANTAS] ")
            sb.Append("       ,[PREC_COMBU],[RENC_LLANTAS], [ISV_HOTEL],[LUBRICANTES],[COMBUSTIBLE],[ALQUILER_TROCOS] ")
            sb.Append("       ,[TAXI],[TOTAL],[VAL_ISV4],[VAL_ISV15],SUBTOTAL_HOTEL,[EMP_COI],[DEPTO_COI],[SUCURSAL_COI], [GASTOS_VEHICULARES]) ")
            sb.Append(" VALUES ")
            sb.Append("       (@EMPLEADOID,@FECHA,@DESCRIPCION,@VAL_ALI,@VAL_HOTEL,@VEHICULOID,@TRANS_AUXILIAR ")
            sb.Append("       ,@IMP_MUNICIPAL,@IMP_GUERRA,@PEAJE,@ESTADO,@HORA_INI,@HORA_FIN,@REP_LLANTAS,@PREC_COMBU ")
            sb.Append("       ,@RENC_LLANTAS,@ISV_HOTEL,@LUBRICANTES,@COMBUSTIBLE,@ALQUILER_TROCOS,@TAXI,@TOTAL,@VAL_ISV4 ")
            sb.Append("       ,@VAL_ISV15,@SUBTOTAL_HOTEL,@EMP_COI,@DEPTO_COI,@SUCURSAL_COI, @GASTOS_VEHICULARES)")
            Dim comando = New SqlCommand(sb.ToString(), conexion)


            comando.Parameters.AddWithValue("@EMPLEADOID", Identidad)
            comando.Parameters.AddWithValue("@FECHA", Convert.ToDateTime(Fecha))
            comando.Parameters.AddWithValue("@DESCRIPCION", Ruta)
            comando.Parameters.AddWithValue("@VAL_ALI", Alimentacion)
            comando.Parameters.AddWithValue("@VAL_HOTEL", Hotel)
            comando.Parameters.AddWithValue("@VEHICULOID", Vehiculo)
            comando.Parameters.AddWithValue("@TRANS_AUXILIAR", TransAuxiliar)
            comando.Parameters.AddWithValue("@IMP_MUNICIPAL", ImpMunicipal)
            comando.Parameters.AddWithValue("@IMP_GUERRA", ImpGuerra)
            comando.Parameters.AddWithValue("@PEAJE", Peaje)
            comando.Parameters.AddWithValue("@ESTADO", 0)
            comando.Parameters.AddWithValue("@HORA_INI", "06:00")
            comando.Parameters.AddWithValue("@HORA_FIN", "18:00")
            comando.Parameters.AddWithValue("@REP_LLANTAS", RepLlantas)
            comando.Parameters.AddWithValue("@PREC_COMBU", PrecComb)
            comando.Parameters.AddWithValue("@RENC_LLANTAS", RencLlantas)
            comando.Parameters.AddWithValue("@ISV_HOTEL", ISVHotel)
            comando.Parameters.AddWithValue("@LUBRICANTES", Lubricantes)
            comando.Parameters.AddWithValue("@COMBUSTIBLE", Comb)
            comando.Parameters.AddWithValue("@ALQUILER_TROCOS", trocos)
            comando.Parameters.AddWithValue("@TAXI", Taxi)
            comando.Parameters.AddWithValue("@TOTAL", Total)
            comando.Parameters.AddWithValue("@VAL_ISV4", ValISV4)
            comando.Parameters.AddWithValue("@VAL_ISV15", ValISV15)
            comando.Parameters.AddWithValue("@SUBTOTAL_HOTEL", SubTotalHotel)
            comando.Parameters.AddWithValue("@EMP_COI", EMP_COI)
            comando.Parameters.AddWithValue("@DEPTO_COI", DEPTO_COI)
            comando.Parameters.AddWithValue("@SUCURSAL_COI", SUCURSAL_COI)
            comando.Parameters.AddWithValue("@GASTOS_VEHICULARES", Vehiculares)

            comando.Transaction = transaccion
            comando.ExecuteNonQuery()


            Dim select_gastoid = New StringBuilder()
            Dim dt_gastoid = New DataTable()
            select_gastoid.Append("SELECT MAX([GASTOID]) FROM [CENTRALCOSTO].[dbo].[REG_GASTOS_ENT]")
            Dim comando_select_gastoid = New SqlCommand(select_gastoid.ToString(), conexion)
            comando_select_gastoid.Transaction = transaccion
            Dim adaptador = New SqlDataAdapter(comando_select_gastoid)
            adaptador.Fill(dt_gastoid)
            Dim gastoid As Integer
            gastoid = dt_gastoid.Rows(0)(0)

            Dim sb3 = New StringBuilder()
            sb3.Append("UPDATE Usuarios.dbo.Liq_Encabezado SET Usuarios.dbo.Liq_Encabezado.Validado = 1, Usuarios.dbo.Liq_Encabezado.GastoID = @GastoID WHERE Usuarios.dbo.Liq_Encabezado.Entregador = @Entregador and Fecha_Facturado = @Fecha ")

            Dim comando3 = New SqlCommand(sb3.ToString(), conexion)
            comando3.Parameters.AddWithValue("@Entregador", CodigoEntregador)
            comando3.Parameters.AddWithValue("@Fecha", Fecha)
            comando3.Parameters.AddWithValue("@GastoID", gastoid)

            comando3.Transaction = transaccion
            comando3.ExecuteNonQuery()

            'MsgBox(Identidad)

            'MsgBox(dtEmpleados.Rows.Count - 1)
            For index3 = 0 To dtEmpleados.Rows.Count - 1
                Dim query2 = New StringBuilder()
                query2.Append("INSERT INTO [CENTRALCOSTO].[dbo].[REG_GASTOS_ENT_ENLACE] ")
                query2.Append("([EMPLEADOID],[PORCENTAJE],[GASTOENLAZADO],[VENTA],[COSTO]) ")
                query2.Append("VALUES ")
                query2.Append("(@EMPLEADOID,@PORCENTAJE,@GASTOENLAZADO,@VENTA,@COSTO)")

                Dim comando2 As New SqlCommand(query2.ToString, conexion)

                comando2.Parameters.AddWithValue("@GASTOENLAZADO", gastoid)
                comando2.Parameters.AddWithValue("@EMPLEADOID", dtEmpleados(index3)(0))
                comando2.Parameters.AddWithValue("@PORCENTAJE", dtEmpleados(index3)(2))
                comando2.Parameters.AddWithValue("@VENTA", dtEmpleados(index3)(3))
                comando2.Parameters.AddWithValue("@COSTO", dtEmpleados(index3)(4))
                comando2.Transaction = transaccion
                comando2.ExecuteNonQuery()
            Next


            Dim ins_bitacora As New cls_bitacora_reporteador
            ins_bitacora.RegistraBitacora(Now, usuario, "REGISTRO GASTOS DE ENTREGA", "Supply Chain", "Ingreso de Gastos " & Identidad & " - " & Fecha)

            transaccion.Commit()
            conexion.Close()
            Return "correcto"
        Catch ex As Exception
            transaccion.Rollback()
            conexion.Close()
            Dim tamaño As Integer = Convert.ToString(ex.StackTrace).Length
            Dim posicion As Integer = InStrRev(Convert.ToString(ex.StackTrace), "línea") - 1
            Dim inicial As Integer = tamaño - posicion
            Dim linea_error As String = Convert.ToString(ex.StackTrace).Substring(tamaño - inicial, inicial)
            Return "Error: " & ex.Message & " " & linea_error
        End Try
    End Function

    Public Function InsertaDepositoBanco(ByVal Liquidacion As Integer, ByVal Monto As Decimal, ByVal EntregadorNombre As String, _
                                         ByVal NumeroDeposito As String, ByVal Usuario As String, ByVal fecha_coi As Date, ByVal nmes As Integer, _
                                         ByVal nyear As Integer, ByVal tipo_poliza As String, ByVal TipoLiquidacion As String, ByVal Rango As String, _
                                         ByVal Ruta As String, ByVal dt_cuentas_poliza As DataTable)
        Dim transaccion As SqlTransaction
        Dim conexion = New SqlConnection(Conexion2.CadenaSQL)
        conexion.Open()
        transaccion = conexion.BeginTransaction()

        Dim empresa_coi As String = "08"
        Dim Cuenta As String = 7
        '"110200700000000000004"

        Dim TOTAL As Decimal = Monto
        Try

            Dim sb = New StringBuilder()
            sb.Append("UPDATE  Liq_Encabezado ")
            sb.Append(" SET Deposito = @Deposito, MontoDeposito = @Monto WHERE Numero = @Numero ")
            Dim comando = New SqlCommand(sb.ToString(), conexion)


            comando.Parameters.AddWithValue("@Deposito", NumeroDeposito)
            comando.Parameters.AddWithValue("@Monto", Monto)
            comando.Parameters.AddWithValue("@Numero", Liquidacion)

            comando.Transaction = transaccion
            comando.ExecuteNonQuery()


            Dim select_gastoid = New StringBuilder()
            Dim dt_gastoid = New DataTable()
            select_gastoid.Append("SELECT [BAN40EMPRE05].[dbo].[CONTROLREGMOV].[MOVIMIENTOS] FROM [BAN40EMPRE05].[dbo].[CONTROLREGMOV] WHERE [BAN40EMPRE05].[dbo].[CONTROLREGMOV].[CUENTA] = 7 ")
            Dim comando_select_gastoid = New SqlCommand(select_gastoid.ToString(), conexion)
            comando_select_gastoid.Transaction = transaccion
            Dim adaptador = New SqlDataAdapter(comando_select_gastoid)
            adaptador.Fill(dt_gastoid)
            Dim gastoid As Integer
            gastoid = dt_gastoid.Rows(0)(0)

            Dim year_short As Integer
            year_short = Convert.ToInt32((fecha_coi.Year.ToString()).Substring(2, 2))

            Dim cero_poliza As String = ""
            If (nmes.ToString().Length < 2) Then
                cero_poliza = "0"
            End If

            'seleccionar el num de poliza
            Dim num_poliz As String = ""
            Dim qx_num_pol = New StringBuilder()
            qx_num_pol.Append("SELECT [FOLIO" + cero_poliza + nmes.ToString + "] ")
            qx_num_pol.Append(" FROM COI70Empre" + empresa_coi + ".dbo.FOLIOS" + empresa_coi + " ")
            qx_num_pol.Append(" WHERE (TIPPOL = @TIPO_POLI) AND (EJERCICIO = @EJERCICIO) ")
            Dim cmd_num_pol = New SqlCommand(qx_num_pol.ToString(), conexion)
            cmd_num_pol.Transaction = transaccion
            cmd_num_pol.Parameters.AddWithValue("@TIPO_POLI", tipo_poliza)
            cmd_num_pol.Parameters.AddWithValue("@EJERCICIO", nyear)
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

            'encabezado de la poliza
            Dim qx_polizas = New StringBuilder()
            qx_polizas.Append("INSERT INTO [COI70Empre" + empresa_coi + "].[dbo].[POLIZAS" + year_short.ToString + empresa_coi + "] ")
            qx_polizas.Append("([TIPO_POLI],[NUM_POLIZ],[PERIODO],[EJERCICIO],[FECHA_POL],[CONCEP_PO] ")
            qx_polizas.Append(",[NUM_PART],[LOGAUDITA],[CONTABILIZ],[NUMPARCUA],[TIENEDOCUMENTOS] ")
            qx_polizas.Append(",[PROCCONTAB],[ORIGEN],[UUID],[ESPOLIZAPRIVADA]) ")
            qx_polizas.Append("VALUES ")
            qx_polizas.Append("(@TIPO_POLI,@NUM_POLIZ,@PERIODO,@EJERCICIO,@FECHA_POL,@CONCEP_PO,@NUM_PART ")
            qx_polizas.Append(",@LOGAUDITA,@CONTABILIZ,@NUMPARCUA,@TIENEDOCUMENTOS,@PROCCONTAB,@ORIGEN ")
            qx_polizas.Append(",@UUID,@ESPOLIZAPRIVADA) ")
            Dim cmd_polizas = New SqlCommand(qx_polizas.ToString(), conexion)
            cmd_polizas.Transaction = transaccion
            cmd_polizas.Parameters.AddWithValue("TIPO_POLI", tipo_poliza)
            cmd_polizas.Parameters.AddWithValue("NUM_POLIZ", num_poliz)
            cmd_polizas.Parameters.AddWithValue("PERIODO", nmes)
            cmd_polizas.Parameters.AddWithValue("EJERCICIO", nyear)
            cmd_polizas.Parameters.AddWithValue("FECHA_POL", fecha_coi)
            cmd_polizas.Parameters.AddWithValue("@CONCEP_PO", "EFE-" & NumeroDeposito & " FACT " & Rango & " " & TipoLiquidacion & "/" & EntregadorNombre & "/" & Ruta)
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
                qx_catalogo_cuentas.Append("SELECT NUM_CTA, CTA_PAPA, NIVEL FROM COI70Empre" + empresa_coi + ".dbo.CUENTAS" & Convert.ToString(year_short) & empresa_coi & " WHERE NUM_CTA = @CTA ")
                Dim cmd_catalogo_cuentas = New SqlCommand(qx_catalogo_cuentas.ToString(), conexion)
                cmd_catalogo_cuentas.Parameters.AddWithValue("@CTA", dt_cuentas_poliza.Rows(index)(0))
                cmd_catalogo_cuentas.Transaction = transaccion
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
                        qx_cuenta_rel.Append("SELECT NUM_CTA, CTA_PAPA, NIVEL FROM COI70Empre" + empresa_coi + ".dbo.CUENTAS" & Convert.ToString(year_short) & empresa_coi & " WHERE NUM_CTA = '" + cta_papa + "'")
                        Dim cmd_cuenta_rel = New SqlCommand(qx_cuenta_rel.ToString(), conexion)
                        cmd_cuenta_rel.Transaction = transaccion
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
                            qx_actualiza_saldos.Append(" UPDATE [COI70Empre" + empresa_coi + "].[dbo].[SALDOS" & Convert.ToString(year_short) & empresa_coi & "] ")

                            If dt_cuentas_poliza.Rows(index)(2) = "D" Then
                                qx_actualiza_saldos.Append("   SET [CARGO" + cero_poliza + nmes.ToString + "] = [CARGO" + cero_poliza + nmes.ToString + "] + @VALOR ")
                            ElseIf dt_cuentas_poliza.Rows(index)(2) = "H" Then
                                qx_actualiza_saldos.Append("   SET [ABONO" + cero_poliza + nmes.ToString + "] = [ABONO" + cero_poliza + nmes.ToString + "] + @VALOR ")
                            End If
                            qx_actualiza_saldos.Append(" WHERE [NUM_CTA] = @NUM_CTA AND [EJERCICIO] = @EJERCICIO ")
                            Dim cmd_actualiza_saldos = New SqlCommand(qx_actualiza_saldos.ToString(), conexion)
                            cmd_actualiza_saldos.Transaction = transaccion
                            cmd_actualiza_saldos.Parameters.AddWithValue("@NUM_CTA", cuentas_afectadas(i))
                            cmd_actualiza_saldos.Parameters.AddWithValue("@EJERCICIO", nyear)
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
                qx_auxiliares.Append("INSERT INTO [COI70Empre" + empresa_coi + "].[dbo].[AUXILIAR" + year_short.ToString + empresa_coi + "] ")
                qx_auxiliares.Append("   ([TIPO_POLI],[NUM_POLIZ],[NUM_PART],[PERIODO],[EJERCICIO] ")
                qx_auxiliares.Append("   ,[NUM_CTA],[FECHA_POL],[CONCEP_PO],[DEBE_HABER],[MONTOMOV] ")
                qx_auxiliares.Append("   ,[NUMDEPTO],[TIPCAMBIO],[CONTRAPAR],[ORDEN],[CCOSTOS] ")
                qx_auxiliares.Append("   ,[CGRUPOS],[IDINFADIPAR],[IDUUID]) ")
                qx_auxiliares.Append("VALUES ")
                qx_auxiliares.Append("   (@TIPO_POLI, @NUM_POLIZ , @NUM_PART, @PERIODO, @EJERCICIO ")
                qx_auxiliares.Append("   , @NUM_CTA , @FECHA_POL, @CONCEP_PO, @DEBE_HABER,@MONTOMOV ")
                qx_auxiliares.Append("   , @NUMDEPTO, @TIPCAMBIO, @CONTRAPAR, @ORDEN, @CCOSTOS ")
                qx_auxiliares.Append("   ,@CGRUPOS,@IDINFADIPAR,@IDUUID)")
                Dim cmd_ins_auxiliares = New SqlCommand(qx_auxiliares.ToString(), conexion)
                cmd_ins_auxiliares.Transaction = transaccion
                cmd_ins_auxiliares.Parameters.AddWithValue("@TIPO_POLI", tipo_poliza)
                cmd_ins_auxiliares.Parameters.AddWithValue("@NUM_POLIZ", num_poliz)
                cmd_ins_auxiliares.Parameters.AddWithValue("@EJERCICIO", nyear)
                cmd_ins_auxiliares.Parameters.AddWithValue("@NUM_PART", index + 1)
                cmd_ins_auxiliares.Parameters.AddWithValue("@PERIODO", nmes)
                cmd_ins_auxiliares.Parameters.AddWithValue("@NUM_CTA", dt_cuentas_poliza.Rows(index)(0))
                cmd_ins_auxiliares.Parameters.AddWithValue("@FECHA_POL", fecha_coi)
                cmd_ins_auxiliares.Parameters.AddWithValue("@CONCEP_PO", "Dep Liq " & Liquidacion & " - " & NumeroDeposito)
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
            qx_upd_folios.Append("UPDATE [COI70Empre" + empresa_coi + "].[dbo].[FOLIOS" + empresa_coi + "] ")
            qx_upd_folios.Append("SET [FOLIO" + cero_poliza + nmes.ToString + "] = [FOLIO" + cero_poliza + nmes.ToString + "] + 1 ")
            qx_upd_folios.Append(" WHERE (TIPPOL = @TIPO_POLI) AND (EJERCICIO = @EJERCICIO) ")
            Dim cmd_upd_folios = New SqlCommand(qx_upd_folios.ToString(), conexion)
            cmd_upd_folios.Transaction = transaccion
            cmd_upd_folios.Parameters.AddWithValue("@TIPO_POLI", tipo_poliza)
            cmd_upd_folios.Parameters.AddWithValue("@EJERCICIO", nyear)
            cmd_upd_folios.Transaction = transaccion
            cmd_upd_folios.ExecuteNonQuery()


            'interfaz en banco'
            Dim nombre_tabla As String = ""
            If Cuenta.Length > 1 Then
                nombre_tabla = Cuenta
            Else
                nombre_tabla = "0" & Cuenta
            End If

            Dim dt_tabla_control_reg_mov As New DataTable
            Dim query_control_reg_mov As New StringBuilder
            query_control_reg_mov.Append("SELECT CUENTA, MOVIMIENTOS, PARTIDAS, MONEDA FROM BAN40EMPRE" + empresa_banco + ".dbo.CONTROLREGMOV CT ")
            query_control_reg_mov.Append("INNER JOIN  BAN40EMPRE" + empresa_banco + ".dbo.CTAS C ON C.NUM_REG = CT.CUENTA  WHERE CUENTA = @CUENTA ")
            Dim comando_control_reg_mov As New SqlCommand(query_control_reg_mov.ToString, conexion)
            comando_control_reg_mov.Parameters.AddWithValue("@CUENTA", 7)
            comando_control_reg_mov.Transaction = transaccion
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

            Dim comando_movs As New SqlCommand(query_movs.ToString, conexion)
            comando_movs.Parameters.AddWithValue("@NUM_REG", num_reg)
            Dim ConcBan As String
            If TipoLiquidacion = "COBRO" Then
                ConcBan = "DES"
            Else
                ConcBan = "DEO"
            End If
            comando_movs.Parameters.AddWithValue("@CVE_CONCEP", ConcBan)
            comando_movs.Parameters.AddWithValue("@CON_PART", 1)
            comando_movs.Parameters.AddWithValue("@NUM_CHEQUE", 0)
            If EntregadorNombre.Length >= 20 Then
                EntregadorNombre = EntregadorNombre.Substring(0, 19)
            End If
            comando_movs.Parameters.AddWithValue("@REF1", EntregadorNombre)
            comando_movs.Parameters.AddWithValue("@REF2", NumeroDeposito)
            comando_movs.Parameters.AddWithValue("@STATUS", "R")
            comando_movs.Parameters.AddWithValue("@FECHA", fecha_coi)
            comando_movs.Parameters.AddWithValue("@F_COBRO", fecha_coi)
            comando_movs.Parameters.AddWithValue("@BAND_PRN", "N")
            comando_movs.Parameters.AddWithValue("@BAND_CONT", "N")
            comando_movs.Parameters.AddWithValue("@ACT_SAE", "N")
            comando_movs.Parameters.AddWithValue("@NUM_POL", num_poliz)
            comando_movs.Parameters.AddWithValue("@TIP_POL", tipo_poliza)
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
            comando_movs.Parameters.AddWithValue("@FECHA_POL", fecha_coi)
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
            comando_movs.Transaction = transaccion
            comando_movs.ExecuteNonQuery()

            'ACTUALIZAR NUMEROS DE MOVIMIENTOS
            Dim query_num_movs As New StringBuilder
            query_num_movs.Append("UPDATE BAN40EMPRE05.dbo.CONTROLREGMOV SET MOVIMIENTOS = MOVIMIENTOS + 1 WHERE (CUENTA = 7) ")
            Dim comando_num_movs As New SqlCommand(query_num_movs.ToString, conexion)

            comando_num_movs.Transaction = transaccion
            comando_num_movs.ExecuteNonQuery()
            ' fin interfaz banco

            'B


            Dim ins_bitacora As New cls_bitacora_reporteador
            ins_bitacora.RegistraBitacora(Now, Usuario, "Envío de depósito a bancos", "Supply Chain", "Envío de depósito: " & NumeroDeposito & " - Monto: " & Monto)

            transaccion.Commit()
            conexion.Close()
            Return "correcto"
        Catch ex As Exception
            transaccion.Rollback()
            conexion.Close()
            Dim tamaño As Integer = Convert.ToString(ex.StackTrace).Length
            Dim posicion As Integer = InStrRev(Convert.ToString(ex.StackTrace), "línea") - 1
            Dim inicial As Integer = tamaño - posicion
            Dim linea_error As String = Convert.ToString(ex.StackTrace).Substring(tamaño - inicial, inicial)
            Return "Error: " & ex.Message & " " & linea_error
        End Try
    End Function

    Public Function InsertaDepositoCliente(ByVal Liquidacion As Integer, ByVal Monto As Decimal, ByVal EntregadorNombre As String, _
                                         ByVal NumeroDeposito As String, ByVal Usuario As String, ByVal fecha_coi As Date, ByVal nmes As Integer, _
                                         ByVal nyear As Integer, ByVal tipo_poliza As String, ByVal TipoLiquidacion As String, ByVal Rango As String, _
                                         ByVal Ruta As String, ByVal dt_cuentas_poliza As DataTable, ByVal Detalle As String)
        Dim transaccion As SqlTransaction
        Dim conexion = New SqlConnection(Conexion2.CadenaSQL)
        conexion.Open()
        transaccion = conexion.BeginTransaction()

        Dim empresa_coi As String = "08"
        Dim Cuenta As String = 7
        '"110200700000000000004"

        Dim TOTAL As Decimal = Monto
        Try

            Dim sb = New StringBuilder()
            sb.Append("UPDATE  Liq_Detalle ")
            sb.Append(" SET Estado = 1 WHERE Numero = @Numero and Detalle = @Detalle")
            Dim comando = New SqlCommand(sb.ToString(), conexion)

            comando.Parameters.AddWithValue("@Deposito", NumeroDeposito)
            comando.Parameters.AddWithValue("@Monto", Monto)
            comando.Parameters.AddWithValue("@Numero", Liquidacion)
            comando.Parameters.AddWithValue("@Detalle", Detalle)

            comando.Transaction = transaccion
            comando.ExecuteNonQuery()


            Dim select_gastoid = New StringBuilder()
            Dim dt_gastoid = New DataTable()
            select_gastoid.Append("SELECT [BAN40EMPRE05].[dbo].[CONTROLREGMOV].[MOVIMIENTOS] FROM [BAN40EMPRE05].[dbo].[CONTROLREGMOV] WHERE [BAN40EMPRE05].[dbo].[CONTROLREGMOV].[CUENTA] = 7 ")
            Dim comando_select_gastoid = New SqlCommand(select_gastoid.ToString(), conexion)
            comando_select_gastoid.Transaction = transaccion
            Dim adaptador = New SqlDataAdapter(comando_select_gastoid)
            adaptador.Fill(dt_gastoid)
            Dim gastoid As Integer
            gastoid = dt_gastoid.Rows(0)(0)

            Dim year_short As Integer
            year_short = Convert.ToInt32((fecha_coi.Year.ToString()).Substring(2, 2))

            Dim cero_poliza As String = ""
            If (nmes.ToString().Length < 2) Then
                cero_poliza = "0"
            End If

            'seleccionar el num de poliza
            Dim num_poliz As String = ""
            Dim qx_num_pol = New StringBuilder()
            qx_num_pol.Append("SELECT [FOLIO" + cero_poliza + nmes.ToString + "] ")
            qx_num_pol.Append(" FROM COI70Empre" + empresa_coi + ".dbo.FOLIOS" + empresa_coi + " ")
            qx_num_pol.Append(" WHERE (TIPPOL = @TIPO_POLI) AND (EJERCICIO = @EJERCICIO) ")
            Dim cmd_num_pol = New SqlCommand(qx_num_pol.ToString(), conexion)
            cmd_num_pol.Transaction = transaccion
            cmd_num_pol.Parameters.AddWithValue("@TIPO_POLI", tipo_poliza)
            cmd_num_pol.Parameters.AddWithValue("@EJERCICIO", nyear)
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

            'encabezado de la poliza
            Dim qx_polizas = New StringBuilder()
            qx_polizas.Append("INSERT INTO [COI70Empre" + empresa_coi + "].[dbo].[POLIZAS" + year_short.ToString + empresa_coi + "] ")
            qx_polizas.Append("([TIPO_POLI],[NUM_POLIZ],[PERIODO],[EJERCICIO],[FECHA_POL],[CONCEP_PO] ")
            qx_polizas.Append(",[NUM_PART],[LOGAUDITA],[CONTABILIZ],[NUMPARCUA],[TIENEDOCUMENTOS] ")
            qx_polizas.Append(",[PROCCONTAB],[ORIGEN],[UUID],[ESPOLIZAPRIVADA]) ")
            qx_polizas.Append("VALUES ")
            qx_polizas.Append("(@TIPO_POLI,@NUM_POLIZ,@PERIODO,@EJERCICIO,@FECHA_POL,@CONCEP_PO,@NUM_PART ")
            qx_polizas.Append(",@LOGAUDITA,@CONTABILIZ,@NUMPARCUA,@TIENEDOCUMENTOS,@PROCCONTAB,@ORIGEN ")
            qx_polizas.Append(",@UUID,@ESPOLIZAPRIVADA) ")
            Dim cmd_polizas = New SqlCommand(qx_polizas.ToString(), conexion)
            cmd_polizas.Transaction = transaccion
            cmd_polizas.Parameters.AddWithValue("TIPO_POLI", tipo_poliza)
            cmd_polizas.Parameters.AddWithValue("NUM_POLIZ", num_poliz)
            cmd_polizas.Parameters.AddWithValue("PERIODO", nmes)
            cmd_polizas.Parameters.AddWithValue("EJERCICIO", nyear)
            cmd_polizas.Parameters.AddWithValue("FECHA_POL", fecha_coi)
            cmd_polizas.Parameters.AddWithValue("@CONCEP_PO", "EFE-" & NumeroDeposito & " FACT " & Rango & " " & TipoLiquidacion & "/" & EntregadorNombre & "/" & Ruta)
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
                qx_catalogo_cuentas.Append("SELECT NUM_CTA, CTA_PAPA, NIVEL FROM COI70Empre" + empresa_coi + ".dbo.CUENTAS" & Convert.ToString(year_short) & empresa_coi & " WHERE NUM_CTA = @CTA ")
                Dim cmd_catalogo_cuentas = New SqlCommand(qx_catalogo_cuentas.ToString(), conexion)
                cmd_catalogo_cuentas.Parameters.AddWithValue("@CTA", dt_cuentas_poliza.Rows(index)(0))
                cmd_catalogo_cuentas.Transaction = transaccion
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
                        qx_cuenta_rel.Append("SELECT NUM_CTA, CTA_PAPA, NIVEL FROM COI70Empre" + empresa_coi + ".dbo.CUENTAS" & Convert.ToString(year_short) & empresa_coi & " WHERE NUM_CTA = '" + cta_papa + "'")
                        Dim cmd_cuenta_rel = New SqlCommand(qx_cuenta_rel.ToString(), conexion)
                        cmd_cuenta_rel.Transaction = transaccion
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
                            qx_actualiza_saldos.Append(" UPDATE [COI70Empre" + empresa_coi + "].[dbo].[SALDOS" & Convert.ToString(year_short) & empresa_coi & "] ")

                            If dt_cuentas_poliza.Rows(index)(2) = "D" Then
                                qx_actualiza_saldos.Append("   SET [CARGO" + cero_poliza + nmes.ToString + "] = [CARGO" + cero_poliza + nmes.ToString + "] + @VALOR ")
                            ElseIf dt_cuentas_poliza.Rows(index)(2) = "H" Then
                                qx_actualiza_saldos.Append("   SET [ABONO" + cero_poliza + nmes.ToString + "] = [ABONO" + cero_poliza + nmes.ToString + "] + @VALOR ")
                            End If
                            qx_actualiza_saldos.Append(" WHERE [NUM_CTA] = @NUM_CTA AND [EJERCICIO] = @EJERCICIO ")
                            Dim cmd_actualiza_saldos = New SqlCommand(qx_actualiza_saldos.ToString(), conexion)
                            cmd_actualiza_saldos.Transaction = transaccion
                            cmd_actualiza_saldos.Parameters.AddWithValue("@NUM_CTA", cuentas_afectadas(i))
                            cmd_actualiza_saldos.Parameters.AddWithValue("@EJERCICIO", nyear)
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
                qx_auxiliares.Append("INSERT INTO [COI70Empre" + empresa_coi + "].[dbo].[AUXILIAR" + year_short.ToString + empresa_coi + "] ")
                qx_auxiliares.Append("   ([TIPO_POLI],[NUM_POLIZ],[NUM_PART],[PERIODO],[EJERCICIO] ")
                qx_auxiliares.Append("   ,[NUM_CTA],[FECHA_POL],[CONCEP_PO],[DEBE_HABER],[MONTOMOV] ")
                qx_auxiliares.Append("   ,[NUMDEPTO],[TIPCAMBIO],[CONTRAPAR],[ORDEN],[CCOSTOS] ")
                qx_auxiliares.Append("   ,[CGRUPOS],[IDINFADIPAR],[IDUUID]) ")
                qx_auxiliares.Append("VALUES ")
                qx_auxiliares.Append("   (@TIPO_POLI, @NUM_POLIZ , @NUM_PART, @PERIODO, @EJERCICIO ")
                qx_auxiliares.Append("   , @NUM_CTA , @FECHA_POL, @CONCEP_PO, @DEBE_HABER,@MONTOMOV ")
                qx_auxiliares.Append("   , @NUMDEPTO, @TIPCAMBIO, @CONTRAPAR, @ORDEN, @CCOSTOS ")
                qx_auxiliares.Append("   ,@CGRUPOS,@IDINFADIPAR,@IDUUID)")
                Dim cmd_ins_auxiliares = New SqlCommand(qx_auxiliares.ToString(), conexion)
                cmd_ins_auxiliares.Transaction = transaccion
                cmd_ins_auxiliares.Parameters.AddWithValue("@TIPO_POLI", tipo_poliza)
                cmd_ins_auxiliares.Parameters.AddWithValue("@NUM_POLIZ", num_poliz)
                cmd_ins_auxiliares.Parameters.AddWithValue("@EJERCICIO", nyear)
                cmd_ins_auxiliares.Parameters.AddWithValue("@NUM_PART", index + 1)
                cmd_ins_auxiliares.Parameters.AddWithValue("@PERIODO", nmes)
                cmd_ins_auxiliares.Parameters.AddWithValue("@NUM_CTA", dt_cuentas_poliza.Rows(index)(0))
                cmd_ins_auxiliares.Parameters.AddWithValue("@FECHA_POL", fecha_coi)
                cmd_ins_auxiliares.Parameters.AddWithValue("@CONCEP_PO", "Dep Liq " & Liquidacion & " - " & NumeroDeposito)
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
            qx_upd_folios.Append("UPDATE [COI70Empre" + empresa_coi + "].[dbo].[FOLIOS" + empresa_coi + "] ")
            qx_upd_folios.Append("SET [FOLIO" + cero_poliza + nmes.ToString + "] = [FOLIO" + cero_poliza + nmes.ToString + "] + 1 ")
            qx_upd_folios.Append(" WHERE (TIPPOL = @TIPO_POLI) AND (EJERCICIO = @EJERCICIO) ")
            Dim cmd_upd_folios = New SqlCommand(qx_upd_folios.ToString(), conexion)
            cmd_upd_folios.Transaction = transaccion
            cmd_upd_folios.Parameters.AddWithValue("@TIPO_POLI", tipo_poliza)
            cmd_upd_folios.Parameters.AddWithValue("@EJERCICIO", nyear)
            cmd_upd_folios.Transaction = transaccion
            cmd_upd_folios.ExecuteNonQuery()


            'interfaz en banco'
            Dim nombre_tabla As String = ""
            If Cuenta.Length > 1 Then
                nombre_tabla = Cuenta
            Else
                nombre_tabla = "0" & Cuenta
            End If

            Dim dt_tabla_control_reg_mov As New DataTable
            Dim query_control_reg_mov As New StringBuilder
            query_control_reg_mov.Append("SELECT CUENTA, MOVIMIENTOS, PARTIDAS, MONEDA FROM BAN40EMPRE" + empresa_banco + ".dbo.CONTROLREGMOV CT ")
            query_control_reg_mov.Append("INNER JOIN  BAN40EMPRE" + empresa_banco + ".dbo.CTAS C ON C.NUM_REG = CT.CUENTA  WHERE CUENTA = @CUENTA ")
            Dim comando_control_reg_mov As New SqlCommand(query_control_reg_mov.ToString, conexion)
            comando_control_reg_mov.Parameters.AddWithValue("@CUENTA", 7)
            comando_control_reg_mov.Transaction = transaccion
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

            Dim comando_movs As New SqlCommand(query_movs.ToString, conexion)
            comando_movs.Parameters.AddWithValue("@NUM_REG", num_reg)
            Dim ConcBan As String
            If TipoLiquidacion = "COBRO" Then
                ConcBan = "DES"
            Else
                ConcBan = "DEO"
            End If
            comando_movs.Parameters.AddWithValue("@CVE_CONCEP", ConcBan)
            comando_movs.Parameters.AddWithValue("@CON_PART", 0)
            comando_movs.Parameters.AddWithValue("@NUM_CHEQUE", 0)
            If EntregadorNombre.Length >= 20 Then
                EntregadorNombre = EntregadorNombre.Substring(0, 19)
            End If
            comando_movs.Parameters.AddWithValue("@REF1", EntregadorNombre)
            comando_movs.Parameters.AddWithValue("@REF2", NumeroDeposito)
            comando_movs.Parameters.AddWithValue("@STATUS", "R")
            comando_movs.Parameters.AddWithValue("@FECHA", fecha_coi)
            comando_movs.Parameters.AddWithValue("@F_COBRO", fecha_coi)
            comando_movs.Parameters.AddWithValue("@BAND_PRN", "N")
            comando_movs.Parameters.AddWithValue("@BAND_CONT", "N")
            comando_movs.Parameters.AddWithValue("@ACT_SAE", "N")
            comando_movs.Parameters.AddWithValue("@NUM_POL", num_poliz)
            comando_movs.Parameters.AddWithValue("@TIP_POL", tipo_poliza)
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
            comando_movs.Parameters.AddWithValue("@FECHA_POL", fecha_coi)
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
            comando_movs.Transaction = transaccion
            comando_movs.ExecuteNonQuery()

            'ACTUALIZAR NUMEROS DE MOVIMIENTOS
            Dim query_num_movs As New StringBuilder
            query_num_movs.Append("UPDATE BAN40EMPRE05.dbo.CONTROLREGMOV SET MOVIMIENTOS = MOVIMIENTOS + 1 WHERE (CUENTA = 7) ")
            Dim comando_num_movs As New SqlCommand(query_num_movs.ToString, conexion)

            comando_num_movs.Transaction = transaccion
            comando_num_movs.ExecuteNonQuery()
            ' fin interfaz banco




            'B


            Dim ins_bitacora As New cls_bitacora_reporteador
            ins_bitacora.RegistraBitacora(Now, Usuario, "Envío de depósito a bancos", "Supply Chain", "Envío de depósito: " & NumeroDeposito & " - Monto: " & Monto)

            transaccion.Commit()
            conexion.Close()
            Return "correcto"
        Catch ex As Exception
            transaccion.Rollback()
            conexion.Close()
            Dim tamaño As Integer = Convert.ToString(ex.StackTrace).Length
            Dim posicion As Integer = InStrRev(Convert.ToString(ex.StackTrace), "línea") - 1
            Dim inicial As Integer = tamaño - posicion
            Dim linea_error As String = Convert.ToString(ex.StackTrace).Substring(tamaño - inicial, inicial)
            Return "Error: " & ex.Message & " " & linea_error
        End Try
    End Function

    Public Function CargaNombreCliente(ByVal Cliente As String)
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim miComando As New SqlCommand(" SELECT SAE60Empre05.dbo.CLIE05.NOMBRE FROM SAE60Empre05.dbo.CLIE05 WHERE LTRIM(SAE60Empre05.dbo.CLIE05.CLAVE) = @clave", ActualizarConexion)

        miComando.Parameters.AddWithValue("@clave", RTrim(LTrim(Cliente)))

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

    Public Function CargaNombreClienteAgro(ByVal Cliente As String)
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim miComando As New SqlCommand(" SELECT SAE60Empre02.dbo.CLIE02.NOMBRE FROM SAE60Empre02.dbo.CLIE02 WHERE LTRIM(SAE60Empre02.dbo.CLIE02.CLAVE) = @clave", ActualizarConexion)

        miComando.Parameters.AddWithValue("@clave", RTrim(LTrim(Cliente)))

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

    Public Function CargaNombreClienteDIMOSA(ByVal Cliente As String)
        Dim ActualizarConexion As New SqlConnection(ConexionDimosa.CadenaSQL())
        Dim miComando As New SqlCommand(" SELECT SAE60Empre06.dbo.CLIE06.NOMBRE FROM SAE60Empre06.dbo.CLIE06 WHERE LTRIM(SAE60Empre06.dbo.CLIE06.CLAVE) = @clave", ActualizarConexion)

        miComando.Parameters.AddWithValue("@clave", RTrim(LTrim(Cliente)))

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

    ''''''''''''''''''''''''''''''''''''
    ''''''''''''''''''''''''''''''''''''
    ''''''''''''''''''''''''''''''''''''
    '''''''''COMISIONES ENTREGA'''''''''
    ''''''''''''''''''''''''''''''''''''
    ''''''''''''''''''''''''''''''''''''
    ''''''''''''''''''''''''''''''''''''

    Public Function ComisionesEntregador(ByVal FECHA_INI As Date, ByVal FECHA_FIN As Date, ByVal TIPO As String, ByVal FILTRO As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("rptn_Comisiones_Entregadores", ActualizarConexion)

        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.AddWithValue("@FECHA_INI", FECHA_INI)
        miComando.Parameters.AddWithValue("@FECHA_FIN", FECHA_FIN)
        miComando.Parameters.AddWithValue("@TIPO", TIPO)
        miComando.Parameters.AddWithValue("@FILTRO", FILTRO)

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

    Public Function VerificaPantalla2(ByVal Numero As Integer)

        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand

            Dim NumBita As Integer = 0
            Dim DtBita As New DataTable
            Dim QueryBita As String
            QueryBita = "SELECT * FROM Liq_Arqueo WHERE Numero = @Numero"
            Dim CMDQueryBita As New SqlCommand(QueryBita, ActualizarConexion)
            CMDQueryBita.Parameters.AddWithValue("@Numero", Numero)

            Dim AdaptadorBita As New SqlDataAdapter(CMDQueryBita)
            CMDQueryBita.Transaction = transaccion_sql
            AdaptadorBita.Fill(DtBita)

            If DtBita.Rows.Count > 0 Then
                If Not IsDBNull(DtBita.Rows(0)(0)) Then
                    NumBita = 1
                End If
            End If

            If NumBita <> 0 Then
                miComando = New SqlCommand(" DELETE FROM Liq_Arqueo " & _
                                             " WHERE  Numero = @Numero " & _
                                             " ", ActualizarConexion)

                miComando.Parameters.AddWithValue("@Numero", Numero)

                miComando.Transaction = transaccion_sql
                miComando.ExecuteNonQuery()
                transaccion_sql.Commit()
            End If
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

    Public Function VerificaPantalla3(ByVal Numero As Integer)

        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand

            Dim NumBita As Integer = 0
            Dim DtBita As New DataTable
            Dim QueryBita As String
            QueryBita = "SELECT * FROM Liq_Gastos WHERE Numero = @Numero"
            Dim CMDQueryBita As New SqlCommand(QueryBita, ActualizarConexion)
            CMDQueryBita.Parameters.AddWithValue("@Numero", Numero)

            Dim AdaptadorBita As New SqlDataAdapter(CMDQueryBita)
            CMDQueryBita.Transaction = transaccion_sql
            AdaptadorBita.Fill(DtBita)

            If DtBita.Rows.Count > 0 Then
                If Not IsDBNull(DtBita.Rows(0)(0)) Then
                    NumBita = 1
                End If
            End If

            If NumBita <> 0 Then
                miComando = New SqlCommand(" DELETE FROM Liq_Gastos " & _
                                             " WHERE  Numero = @Numero " & _
                                             " ", ActualizarConexion)

                miComando.Parameters.AddWithValue("@Numero", Numero)

                miComando.Transaction = transaccion_sql
                miComando.ExecuteNonQuery()
                transaccion_sql.Commit()
            End If
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

    Public Function VerificaPantalla4(ByVal Numero As Integer)

        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand

            Dim NumBita As Integer = 0
            Dim DtBita As New DataTable
            Dim QueryBita As String
            QueryBita = "SELECT * FROM Liq_Cheques WHERE Numero = @Numero"
            Dim CMDQueryBita As New SqlCommand(QueryBita, ActualizarConexion)
            CMDQueryBita.Parameters.AddWithValue("@Numero", Numero)

            Dim AdaptadorBita As New SqlDataAdapter(CMDQueryBita)
            CMDQueryBita.Transaction = transaccion_sql
            AdaptadorBita.Fill(DtBita)

            If DtBita.Rows.Count > 0 Then
                If Not IsDBNull(DtBita.Rows(0)(0)) Then
                    NumBita = 1
                End If
            End If

            If NumBita <> 0 Then
                miComando = New SqlCommand(" DELETE FROM Liq_Cheques " & _
                                             " WHERE  Numero = @Numero " & _
                                             " ", ActualizarConexion)

                miComando.Parameters.AddWithValue("@Numero", Numero)

                miComando.Transaction = transaccion_sql
                miComando.ExecuteNonQuery()
                transaccion_sql.Commit()
            End If
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

    Public Function VerificaPantalla5(ByVal Numero As Integer)

        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand

            Dim NumBita As Integer = 0
            Dim DtBita As New DataTable
            Dim QueryBita As String
            QueryBita = "SELECT * FROM Liq_Detalle WHERE Numero = @Numero"
            Dim CMDQueryBita As New SqlCommand(QueryBita, ActualizarConexion)
            CMDQueryBita.Parameters.AddWithValue("@Numero", Numero)

            Dim AdaptadorBita As New SqlDataAdapter(CMDQueryBita)
            CMDQueryBita.Transaction = transaccion_sql
            AdaptadorBita.Fill(DtBita)

            If DtBita.Rows.Count > 0 Then
                If Not IsDBNull(DtBita.Rows(0)(0)) Then
                    NumBita = 1
                End If
            End If

            If NumBita <> 0 Then
                miComando = New SqlCommand(" DELETE FROM Liq_Detalle " & _
                                             " WHERE  Numero = @Numero " & _
                                             " ", ActualizarConexion)

                miComando.Parameters.AddWithValue("@Numero", Numero)

                miComando.Transaction = transaccion_sql
                miComando.ExecuteNonQuery()
                transaccion_sql.Commit()
            End If
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

    Public Function VerificaDetallesCredito(ByVal Numero As Integer)

        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand

            Dim NumBita As Integer = 0
            Dim DtBita As New DataTable
            Dim QueryBita As String
            QueryBita = "SELECT * FROM Liq_Detalle_CredCob WHERE Liq_Numero = @Numero"
            Dim CMDQueryBita As New SqlCommand(QueryBita, ActualizarConexion)
            CMDQueryBita.Parameters.AddWithValue("@Numero", Numero)

            Dim AdaptadorBita As New SqlDataAdapter(CMDQueryBita)
            CMDQueryBita.Transaction = transaccion_sql
            AdaptadorBita.Fill(DtBita)

            If DtBita.Rows.Count > 0 Then
                If Not IsDBNull(DtBita.Rows(0)(0)) Then
                    NumBita = 1
                End If
            End If

            If NumBita <> 0 Then
                miComando = New SqlCommand(" DELETE FROM  Liq_Detalle_CredCob " & _
                                             " WHERE  Liq_Numero = @Numero " & _
                                             " ", ActualizarConexion)

                miComando.Parameters.AddWithValue("@Numero", Numero)

                miComando.Transaction = transaccion_sql
                miComando.ExecuteNonQuery()
                transaccion_sql.Commit()
            End If
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

    Public Function ObtieneNC(ByVal Numero As Integer)

        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand

            Dim NumBita As Integer = 0
            Dim DtBita As New DataTable
            Dim QueryBita As String
            QueryBita = "SELECT Monto FROM Liq_Detalle WHERE Numero = @Numero and Detalle = 'N/c'"
            Dim CMDQueryBita As New SqlCommand(QueryBita, ActualizarConexion)
            CMDQueryBita.Parameters.AddWithValue("@Numero", Numero)

            Dim AdaptadorBita As New SqlDataAdapter(CMDQueryBita)
            CMDQueryBita.Transaction = transaccion_sql
            AdaptadorBita.Fill(DtBita)

            ActualizarConexion.Close()
            Return DtBita
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

    Public Function EliminaLiquidacion(ByVal Numero As Integer, ByVal Usuario As String)

        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand

            miComando = New SqlCommand(" UPDATE Liq_Encabezado " & _
                                         " SET Estado = 'Elimianda' " & _
                                         " WHERE Numero = " & Numero & "", ActualizarConexion)

            miComando.Transaction = transaccion_sql
            miComando.ExecuteNonQuery()

            Dim conexion_bita As New cls_bitacora_reporteador
            conexion_bita.RegistraBitacora(Now, Usuario, "Eliminó Liquidación", "SUPPLY CHAIN", "Liquidación Nº " & Numero)


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

    Public Function ObtieneDetalleGasto(ByVal Numero As Integer, ByVal Detalle As String)

        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand

            Dim NumBita As Integer = 0
            Dim DtBita As New DataTable
            Dim QueryBita As String
            QueryBita = "SELECT Monto FROM Liq_Detalle WHERE Numero = @Numero and Detalle = @Detalle"
            Dim CMDQueryBita As New SqlCommand(QueryBita, ActualizarConexion)
            CMDQueryBita.Parameters.AddWithValue("@Numero", Numero)
            CMDQueryBita.Parameters.AddWithValue("@Detalle", Detalle)

            Dim AdaptadorBita As New SqlDataAdapter(CMDQueryBita)
            CMDQueryBita.Transaction = transaccion_sql
            AdaptadorBita.Fill(DtBita)

            ActualizarConexion.Close()
            Return DtBita
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

End Class
