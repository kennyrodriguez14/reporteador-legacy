Imports System.Text
Imports Disar.data
Imports System.Data.SqlClient

Public Class cls_compras_pedidos
    Dim conexion As New clsconexion_consumo
    Dim conexionDIMOSA As New cls_conexion_DIMOSA
    Dim conexionAGRO As New clsconexion_sr_agro
    Dim conexionAs As New clsConexion
    Dim conexionDT As New cls_conexion_descuentos_tacticos

    Public Function CargarAlmacenes(ByVal Empresa As String) As DataTable
        Dim conexion_sql As New SqlConnection(conexion.CadenaSQL)
        Dim query As New StringBuilder
        Try
            If Empresa = "SAN RAFAEL" Then
                query.Append("SELECT CVE_ALM, DESCR FROM ALMACENES05 ")
            ElseIf Empresa = "DIMOSA" Then
                query.Append("SELECT SAE60Empre06.dbo.ALMACENES06.CVE_ALM, SAE60Empre06.dbo.ALMACENES06.DESCR FROM SAE60Empre06.dbo.ALMACENES06 ")
            ElseIf Empresa = "SR AGRO" Then
                query.Append("SELECT SAE60EMPRE02.dbo.ALMACENES02.CVE_ALM, SAE60EMPRE02.dbo.ALMACENES02.DESCR FROM SAE60EMPRE02.dbo.ALMACENES02 ")
            End If

            conexion_sql.Open()
            Dim micomando As New SqlCommand(query.ToString, conexion_sql)
            Dim dt As New DataTable
            Dim adaptador As New SqlDataAdapter(micomando)
            adaptador.Fill(dt)
            conexion_sql.Close()
            Return dt
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function

    Public Function CargaPedidos(ByVal Fecha1 As Date, ByVal Fecha2 As Date, ByVal Almacen As Integer, ByVal Empresa As String) As DataTable
        Dim conexion_sql As New SqlConnection(conexionAs.CadenaSQL)
        Dim query As New StringBuilder
        Try
            query.Append("SELECT ID, Fecha, ProvID as 'Num Prov', Prov as Proveedor, Solicita as 'Solicitud enviada por', Almacen , Estado, Tipo as 'Tipo de Compra', UsuarioCompra as 'Usuario realiza compra', FechaCompra as 'Fecha de Compra' FROM dbo.Pedido_Proveedor WHERE Fecha >= @Fecha1 and Fecha <= @Fecha2 and Almacen = @Almacen and Empresa = @Empresa")
            conexion_sql.Open()
            Dim micomando As New SqlCommand(query.ToString, conexion_sql)

            micomando.Parameters.AddWithValue("@Fecha1", Fecha1)
            micomando.Parameters.AddWithValue("@Fecha2", Fecha2)
            micomando.Parameters.AddWithValue("@Almacen", Almacen)
            micomando.Parameters.AddWithValue("@Empresa", Empresa)

            Dim dt As New DataTable
            Dim adaptador As New SqlDataAdapter(micomando)

            adaptador.Fill(dt)
            conexion_sql.Close()

            Return dt

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function

    Public Function BuscaProductos(ByVal Busqueda As String, ByVal Prov As String, ByVal Empresa As String) As DataTable

        Dim conexion_sql As New SqlConnection(conexion.CadenaSQL)

        If Empresa = "SAN RAFAEL" Then
            conexion_sql = New SqlConnection(conexion.CadenaSQL)
        ElseIf Empresa = "DIMOSA" Then
            conexion_sql = New SqlConnection(conexionDIMOSA.CadenaSQL)
        ElseIf Empresa = "SR AGRO" Then
            conexion_sql = New SqlConnection(conexionAGRO.CadenaSQL)
        End If

        Dim query As New StringBuilder
        Try
            If Empresa = "SAN RAFAEL" Then
                query.Append("SELECT CVE_ART, DESCR FROM INVE05 WHERE CVE_ART = '" & Busqueda.ToUpper & "' AND LTRIM(LIN_PROD) = LTRIM(@LINEA) or DESCR LIKE '%" & Busqueda.ToUpper & "%' AND LTRIM(LIN_PROD) = LTRIM(@LINEA) ")
            ElseIf Empresa = "DIMOSA" Then
                query.Append("SELECT CVE_ART, DESCR FROM INVE06 WHERE CVE_ART = '" & Busqueda.ToUpper & "' AND LTRIM(LIN_PROD) = LTRIM(@LINEA) or DESCR LIKE '%" & Busqueda.ToUpper & "%' AND LTRIM(LIN_PROD) = LTRIM(@LINEA) ")
            ElseIf Empresa = "SR AGRO" Then
                query.Append("SELECT CVE_ART, DESCR FROM INVE02 WHERE CVE_ART = '" & Busqueda.ToUpper & "' AND LTRIM(LIN_PROD) = LTRIM(@LINEA) or DESCR LIKE '%" & Busqueda.ToUpper & "%' AND LTRIM(LIN_PROD) = LTRIM(@LINEA) ")
            End If

            conexion_sql.Open()
            Dim micomando As New SqlCommand(query.ToString, conexion_sql)
            micomando.Parameters.AddWithValue("@LINEA", Prov)
            Dim dt As New DataTable
            Dim adaptador As New SqlDataAdapter(micomando)
            adaptador.Fill(dt)
            conexion_sql.Close()
            Return dt
        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Public Function CargaProveedores(ByVal Empresa As String) As DataTable
        Dim conexion_sql As New SqlConnection(conexion.CadenaSQL)

        If Empresa = "SAN RAFAEL" Then
            conexion_sql = New SqlConnection(conexion.CadenaSQL)
        ElseIf Empresa = "DIMOSA" Then
            conexion_sql = New SqlConnection(conexionDIMOSA.CadenaSQL)
        ElseIf Empresa = "SR AGRO" Then
            conexion_sql = New SqlConnection(conexionAGRO.CadenaSQL)
        End If

        Dim query As New StringBuilder
        Try

            If Empresa = "SAN RAFAEL" Then
                query.Append("SELECT CLAVE, CASE CLAVE WHEN '       43' THEN 'DCASA' ELSE NOMBRE END AS NOMBRE  FROM PROV05 WHERE (STATUS = 'A') AND (CLASIFIC = 'P') ORDER BY NOMBRE ")
            ElseIf Empresa = "DIMOSA" Then
                query.Append("SELECT CLAVE, CASE CLAVE WHEN '       43' THEN 'DCASA' ELSE NOMBRE END AS NOMBRE  FROM PROV06 WHERE (STATUS = 'A') AND (CLASIFIC = 'P') ORDER BY NOMBRE ")
            ElseIf Empresa = "SR AGRO" Then
                query.Append("SELECT CLAVE, NOMBRE  FROM PROV02 WHERE (STATUS = 'A') AND (CLASIFIC = 'P') ORDER BY NOMBRE ")
            End If

            conexion_sql.Open()

            Dim micomando As New SqlCommand(query.ToString, conexion_sql)
            Dim dt As New DataTable

            Dim adaptador As New SqlDataAdapter(micomando)
            adaptador.Fill(dt)
            conexion_sql.Close()
            Return dt
        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Public Function NuevoRegistro(ByVal ProveedorID As String, ByVal Proveedor As String, ByVal Solicitante As String, ByVal dt As DataTable, ByVal Tipo As String, ByVal Empresa As String)

        Dim ActualizarConexion As New SqlConnection(conexionAs.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand
            Dim ID As Integer = 0

            Dim DtBita As New DataTable
            Dim QueryBita As String
            QueryBita = "SELECT MAX (ID) FROM Pedido_Proveedor"
            Dim CMDQueryBita As New SqlCommand(QueryBita, ActualizarConexion)
            Dim AdaptadorBita As New SqlDataAdapter(CMDQueryBita)
            CMDQueryBita.Transaction = transaccion_sql
            AdaptadorBita.Fill(DtBita)

            If DtBita.Rows.Count > 0 Then
                If Not IsDBNull(DtBita.Rows(0)(0)) Then
                    ID = DtBita.Rows(0)(0)
                End If
            End If

            ID += 1

            miComando = New SqlCommand("INSERT INTO Pedido_Proveedor " & _
                                         "(ID, Fecha, ProvID, Prov, Solicita, Estado, Tipo, Almacen, Empresa ) " & _
                                         " VALUES( @ID, @Fecha, @ProvID, @Prov, @Solicita, @Estado, @Tipo, @Almacen, @Empresa )", ActualizarConexion)

            miComando.Parameters.AddWithValue("@ID", ID)
            miComando.Parameters.AddWithValue("@Fecha", Today.Date)
            miComando.Parameters.AddWithValue("@ProvID", ProveedorID)
            miComando.Parameters.AddWithValue("@Prov", Proveedor)
            miComando.Parameters.AddWithValue("@Solicita", Solicitante)
            miComando.Parameters.AddWithValue("@Estado", "PENDIENTE")
            miComando.Parameters.AddWithValue("@Tipo", Tipo)
            miComando.Parameters.AddWithValue("@Almacen", dt(0)(3))
            miComando.Parameters.AddWithValue("@Empresa", Empresa)

            miComando.Transaction = transaccion_sql
            miComando.ExecuteNonQuery()

            For index As Integer = 0 To dt.Rows.Count - 1

                Dim Costo As Decimal = 0
                Dim DtCosto As New DataTable
                Dim QueryCosto As String = ""
                If Empresa = "SAN RAFAEL" Then
                    QueryCosto = "SELECT ULT_COSTO FROM SAE60EMPRE05.dbo.INVE05 WHERE CVE_ART = @CVE_ART"
                ElseIf Empresa = "DIMOSA" Then
                    QueryCosto = "SELECT ULT_COSTO FROM SAE60EMPRE06.dbo.INVE06 WHERE CVE_ART = @CVE_ART"
                ElseIf Empresa = "SR AGRO" Then
                    QueryCosto = "SELECT ULT_COSTO FROM SAE60EMPRE02.dbo.INVE02 WHERE CVE_ART = @CVE_ART"
                End If

                Dim CMDQueryCosto As New SqlCommand(QueryCosto, ActualizarConexion)
                CMDQueryCosto.Parameters.AddWithValue("@CVE_ART", dt(index)(0))
                Dim AdaptadorCosto As New SqlDataAdapter(CMDQueryCosto)
                CMDQueryCosto.Transaction = transaccion_sql
                AdaptadorCosto.Fill(DtCosto)

                If DtCosto.Rows.Count > 0 Then
                    If Not IsDBNull(DtCosto.Rows(0)(0)) Then
                        Costo = DtCosto.Rows(0)(0)
                    End If
                End If


                Dim miComandoPartidas As New SqlCommand
                miComandoPartidas = New SqlCommand("INSERT INTO Pedido_Proveedor_Partidas " & _
                                         "(PedidoID, Partida, CveProducto, DescProducto, Cantidad, Almacen, UltimoCosto ) " & _
                                         " VALUES(  @PedidoID, @Partida, @CveProducto, @DescProducto, @Cantidad, @Almacen, @UltimoCosto )", ActualizarConexion)

                miComandoPartidas.Parameters.AddWithValue("@PedidoID", ID)
                miComandoPartidas.Parameters.AddWithValue("@Partida", index + 1)
                miComandoPartidas.Parameters.AddWithValue("@CveProducto", dt(index)(0))
                miComandoPartidas.Parameters.AddWithValue("@DescProducto", dt(index)(1))
                miComandoPartidas.Parameters.AddWithValue("@Cantidad", dt(index)(2))
                miComandoPartidas.Parameters.AddWithValue("@Almacen", dt(index)(3))
                miComandoPartidas.Parameters.AddWithValue("@UltimoCosto", Costo)

                miComandoPartidas.Transaction = transaccion_sql
                miComandoPartidas.ExecuteNonQuery()


            Next


            transaccion_sql.Commit()
            ActualizarConexion.Close()
            Return ID
        Catch ex As Exception

            transaccion_sql.Rollback()
            ActualizarConexion.Close()
            Dim tamaño As Integer = Convert.ToString(ex.StackTrace).Length
            Dim posicion As Integer = InStrRev(Convert.ToString(ex.StackTrace), "línea") - 1
            Dim inicial As Integer = tamaño - posicion
            Dim linea_error As String = Convert.ToString(ex.StackTrace).Substring(tamaño - inicial, inicial)
            Return "Error: " & ex.Message & " " & linea_error
            'MsgBox("Error: " & ex.Message & " " & linea_error)
        End Try

    End Function

    Public Function CambiarCorreos(ByVal ProveedorID As String, ByVal Proveedor As String, ByVal Empresa As String, ByVal Correos As DataTable, ByVal Usuario As String)

        Dim ActualizarConexion As New SqlConnection(conexionAs.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand
            Dim ID As Integer = 0

            miComando = New SqlCommand("DELETE FROM Pedido_Proveedor_Correo WHERE LTRIM(PROV) = LTRIM(@PROV) AND Empresa = @EMPRESA ", ActualizarConexion)

            miComando.Parameters.AddWithValue("@PROV", LTrim(ProveedorID))
            miComando.Parameters.AddWithValue("@Empresa", Empresa)

            miComando.Transaction = transaccion_sql
            miComando.ExecuteNonQuery()

            For index As Integer = 0 To Correos.Rows.Count - 2
                Dim miComandoPartidas As New SqlCommand

                miComandoPartidas = New SqlCommand("INSERT INTO Pedido_Proveedor_Correo " & _
                                         "(Prov, Correo, Tipo, Empresa) " & _
                                         " VALUES (Ltrim(@Prov), @Correo, @Tipo, @Empresa)", ActualizarConexion)


                Dim Tipo As String
                Tipo = Correos(index)(1)
                If Tipo = "Principal" Then
                    Tipo = "O"
                Else
                    Tipo = "C"
                End If
                miComandoPartidas.Parameters.AddWithValue("@Prov", ProveedorID)
                miComandoPartidas.Parameters.AddWithValue("@Correo", Correos(index)(0))
                miComandoPartidas.Parameters.AddWithValue("@Tipo", Tipo)
                miComandoPartidas.Parameters.AddWithValue("@Empresa", Empresa)

                miComandoPartidas.Transaction = transaccion_sql
                miComandoPartidas.ExecuteNonQuery()
            Next


            transaccion_sql.Commit()
            ActualizarConexion.Close()
            Return "S"
        Catch ex As Exception

            transaccion_sql.Rollback()
            ActualizarConexion.Close()
            Dim tamaño As Integer = Convert.ToString(ex.StackTrace).Length
            Dim posicion As Integer = InStrRev(Convert.ToString(ex.StackTrace), "línea") - 1
            Dim inicial As Integer = tamaño - posicion
            Dim linea_error As String = Convert.ToString(ex.StackTrace).Substring(tamaño - inicial, inicial)
            Return "Error: " & ex.Message & " " & linea_error
            'MsgBox("Error: " & ex.Message & " " & linea_error)
        End Try

    End Function

    Public Function CargaCorreos(ByVal Prov As String, ByVal Tipo As String, ByVal Empresa As String) As DataTable
        Dim conexion_sql As New SqlConnection(conexionAs.CadenaSQL)
        Dim query As New StringBuilder
        Try
            query.Append("SELECT Correo FROM Pedido_Proveedor_Correo WHERE LTRIM(PROV) = LTRIM(@PROV) AND TIPO = @TIPO AND EMPRESA = @EMPRESA ")
            conexion_sql.Open()

            Dim micomando As New SqlCommand(query.ToString, conexion_sql)
            micomando.Parameters.AddWithValue("@PROV", Prov)
            micomando.Parameters.AddWithValue("@TIPO", Tipo)
            micomando.Parameters.AddWithValue("@EMPRESA", Empresa)

            Dim dt As New DataTable

            Dim adaptador As New SqlDataAdapter(micomando)
            adaptador.Fill(dt)
            conexion_sql.Close()
            Return dt
        Catch ex As Exception
            'MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function

    Public Function CargarPartidasPedido(ByVal ID As Integer, ByVal Almacen As Integer) As DataTable
        Dim conexion_sql As New SqlConnection(conexionAs.CadenaSQL)
        Dim query As New StringBuilder
        Try
            query.Append(" SELECT Partida, CveProducto as 'CVE Producto', DescProducto as 'Descripción', " & _
                         " Cantidad, UltimoCosto as 'Último Costo'," & _
                         " CASE @Almacen " & _
                         " WHEN 1 THEN  SAE60EMPRE05.dbo.INVE_CLIB05.CAMPLIB8 " & _
                         " WHEN 2 THEN  SAE60EMPRE05.dbo.INVE_CLIB05.CAMPLIB11 " & _
                         " WHEN 3 THEN  SAE60EMPRE05.dbo.INVE_CLIB05.CAMPLIB12 " & _
                         " WHEN 4 THEN  SAE60EMPRE05.dbo.INVE_CLIB05.CAMPLIB18 " & _
                         " END AS 'Ubicación', ISNULL(CantidadRecibida,CANTIDAD) as 'Cantidad Recibida', ISNULL(CantidadDevuelta,0) as 'Cantidad Devuelta', Almacen " & _
                         " FROM Pedido_Proveedor_Partidas inner join " & _
                         " SAE60EMPRE05.dbo.INVE_CLIB05 ON SAE60EMPRE05.dbo.INVE_CLIB05.CVE_PROD = CveProducto COLLATE Modern_Spanish_CI_AS " & _
                         " WHERE (PedidoID = @ID) order by dbo.Pedido_Proveedor_Partidas.Partida")
            conexion_sql.Open()
            Dim micomando As New SqlCommand(query.ToString, conexion_sql)
            micomando.Parameters.AddWithValue("@Almacen", Almacen)
            micomando.Parameters.AddWithValue("@ID", ID)
            Dim dt As New DataTable
            Dim adaptador As New SqlDataAdapter(micomando)
            adaptador.Fill(dt)
            conexion_sql.Close()
            Return dt
        Catch ex As Exception
            'MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function

    Public Function CargarPartidasPedidoDIMOSA(ByVal ID As Integer, ByVal Almacen As Integer) As DataTable
        Dim conexion_sql As New SqlConnection(conexionAs.CadenaSQL)
        Dim query As New StringBuilder
        Try
            query.Append(" SELECT Partida, CveProducto as 'CVE Producto', DescProducto as 'Descripción', " & _
                         " Cantidad, UltimoCosto as 'Último Costo'," & _
                         " CASE @Almacen " & _
                         " WHEN 1 THEN  SAE60EMPRE06.dbo.INVE_CLIB06.CAMPLIB8 " & _
                         " WHEN 2 THEN  SAE60EMPRE06.dbo.INVE_CLIB06.CAMPLIB11 " & _
                         " WHEN 3 THEN  SAE60EMPRE06.dbo.INVE_CLIB06.CAMPLIB12 " & _
                         " WHEN 4 THEN  SAE60EMPRE06.dbo.INVE_CLIB06.CAMPLIB18 " & _
                         " END AS 'Ubicación', ISNULL(CantidadRecibida,CANTIDAD) as 'Cantidad Recibida', ISNULL(CantidadDevuelta,0) as 'Cantidad Devuelta', Almacen " & _
                         " FROM Pedido_Proveedor_Partidas inner join " & _
                         " SAE60EMPRE06.dbo.INVE_CLIB06 ON SAE60EMPRE06.dbo.INVE_CLIB06.CVE_PROD = CveProducto COLLATE Modern_Spanish_CI_AS " & _
                         " WHERE (PedidoID = @ID) order by dbo.Pedido_Proveedor_Partidas.Partida")
            conexion_sql.Open()
            Dim micomando As New SqlCommand(query.ToString, conexion_sql)
            micomando.Parameters.AddWithValue("@Almacen", Almacen)
            micomando.Parameters.AddWithValue("@ID", ID)
            Dim dt As New DataTable
            Dim adaptador As New SqlDataAdapter(micomando)
            adaptador.Fill(dt)
            conexion_sql.Close()
            Return dt
        Catch ex As Exception
            'MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function

    Public Function CancelarPedido(ByVal ID As Integer, ByVal Usuario As String)

        Dim ActualizarConexion As New SqlConnection(conexionAs.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand
            miComando = New SqlCommand("UPDATE Pedido_Proveedor " & _
                                         " SET Estado = 'PEDIDO CANCELADO' , FechaCompra = @Fecha, UsuarioCompra = @UsuarioCompra " & _
                                         " WHERE ID = @ID ", ActualizarConexion)

            miComando.Parameters.AddWithValue("@ID", ID)
            miComando.Parameters.AddWithValue("@Fecha", Today.Date)
            miComando.Parameters.AddWithValue("@UsuarioCompra", Usuario)

            miComando.Transaction = transaccion_sql
            miComando.ExecuteNonQuery()

            Dim miComandoPartidas As New SqlCommand
            miComandoPartidas = New SqlCommand(" UPDATE Pedido_Proveedor_Partidas " & _
                                     " SET CantidadRecibida = 0, CantidadDevuelta = 0 " & _
                                     " WHERE PedidoId = @ID", ActualizarConexion)

            miComandoPartidas.Parameters.AddWithValue("@ID", ID)
           
            miComandoPartidas.Transaction = transaccion_sql
            miComandoPartidas.ExecuteNonQuery()


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
            ' MsgBox("Error: " & ex.Message & " " & linea_error)
        End Try

    End Function

    Public Function CompletaPedido(ByVal ID As Integer, ByVal Usuario As String, ByVal dt As DataTable)

        Dim ActualizarConexion As New SqlConnection(conexionAs.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand
            miComando = New SqlCommand("UPDATE Pedido_Proveedor " & _
                                         " SET Estado = 'EN PROCESO' , FechaCompra = @Fecha, UsuarioCompra = @UsuarioCompra " & _
                                         " WHERE ID = @ID ", ActualizarConexion)

            miComando.Parameters.AddWithValue("@ID", ID)
            miComando.Parameters.AddWithValue("@Fecha", Today.Date)
            miComando.Parameters.AddWithValue("@UsuarioCompra", Usuario)

            miComando.Transaction = transaccion_sql
            miComando.ExecuteNonQuery()

            'For a As Integer = 0 To dt.Rows.Count - 1
            '    Dim miComandoPartidas As New SqlCommand
            '    miComandoPartidas = New SqlCommand(" UPDATE Pedido_Proveedor_Partidas " & _
            '                             " SET CantidadRecibida = @Cantidad, CantidadDevuelta = @Devuelto " & _
            '                             " WHERE PedidoId = @ID and Partida = @Partida ", ActualizarConexion)
            '    miComandoPartidas.Parameters.AddWithValue("@ID", ID)
            '    miComandoPartidas.Parameters.AddWithValue("@Partida", dt.Rows(a)(0))
            '    miComandoPartidas.Parameters.AddWithValue("@Cantidad", dt.Rows(a)(6))
            '    miComandoPartidas.Parameters.AddWithValue("@Devuelto", dt.Rows(a)(7))
            '    miComandoPartidas.Transaction = transaccion_sql
            '    miComandoPartidas.ExecuteNonQuery()
            'Next

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
            'MsgBox("Error: " & ex.Message & " " & linea_error)
        End Try

    End Function

    Public Function Carga_Detalle_Producto(ByVal BUSCAR As String, ByVal PROVEEDOR As String) As DataTable
        Dim query As New StringBuilder
        Dim miconexion As New SqlConnection(conexionDT.CadenaSQL)
        query.Append("SELECT I.CVE_ART AS 'CODIGO PRODUCTO', I.DESCR AS 'PRODUCTO',  ")
        query.Append("I.FAC_CONV AS 'FACTOR CONVERSION', PN.PRECIO_NEG AS 'PRECIO NEGOCIADO', ISV.IMPUESTO4 AS ISV, I.UNI_MED, I.PESO, I.CON_LOTE, ")
        query.Append(" PROV.CVE_PROV ")
        query.Append("FROM SAE60EMPRE05.dbo.INVE05 I INNER JOIN nd_precios_negociados PN ON PN.CVE_ART = I.CVE_ART ")
        query.Append("COLLATE MODERN_SPANISH_CI_AS INNER JOIN SAE60Empre05.dbo.IMPU05 ISV ON I.CVE_ESQIMPU = ISV.CVE_ESQIMPU ")
        query.Append("INNER JOIN SAE60Empre05.dbo.PRVPROD05 PROV ON PROV.CVE_ART = I.CVE_ART FULL OUTER JOIN SAE60Empre05.dbo.INVE_CLIB05 CL ON ")
        query.Append("I.CVE_ART = CL.CVE_PROD ")
        query.Append("WHERE I.STATUS = 'A' AND I.CVE_ART = @BUSCAR")
        query.Append(" ")
        Dim micomando As New SqlCommand(query.ToString, miconexion)
        miconexion.Open()
        micomando.Parameters.AddWithValue("@BUSCAR", BUSCAR)
        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        miconexion.Close()
        Return dt
    End Function

    Public Function CargaIncumplimientos(ByVal PROVEEDOR As String, ByVal Almacen As Integer, ByVal Fecha1 As Date, ByVal Fecha2 As Date, ByVal Empresa As String) As DataTable
        Dim query As New StringBuilder
        Dim miconexion As New SqlConnection(conexionAs.CadenaSQL)
        query.Append(" SELECT  dbo.Pedido_Proveedor_Partidas.PedidoID AS 'PEDIDO', dbo.Pedido_Proveedor_Partidas.Partida AS PARTIDA, dbo.Pedido_Proveedor.ProvID AS 'Nº PROVEEDOR', dbo.Pedido_Proveedor.Prov AS PROVEEDOR, dbo.Pedido_Proveedor.Almacen AS ALMACEN,  " & _
                     " dbo.Pedido_Proveedor_Partidas.CveProducto AS 'CVE PRODUCTO', dbo.Pedido_Proveedor_Partidas.DescProducto AS DESCRIPCION, dbo.Pedido_Proveedor_Partidas.Cantidad AS CANTIDAD, dbo.Pedido_Proveedor_Partidas.CantidadRecibida AS 'CANTIDAD RECIBIDA', " & _
                     " dbo.Pedido_Proveedor_Partidas.CantidadDevuelta AS 'CANTIDAD DEVUELTA'" & _
                     " FROM dbo.Pedido_Proveedor INNER JOIN " & _
                     " dbo.Pedido_Proveedor_Partidas ON dbo.Pedido_Proveedor.ID = dbo.Pedido_Proveedor_Partidas.PedidoID ")
        query.Append(" WHERE FECHA >= @Fecha1 And FECHA <= @Fecha2 AND Pedido_Proveedor.Almacen = @Almacen AND dbo.Pedido_Proveedor.EMPRESA = @EMPRESA AND (ProvID = @PROVEEDOR OR @PROVEEDOR = -1) ")
        Dim micomando As New SqlCommand(query.ToString, miconexion)
        miconexion.Open()
        micomando.Parameters.AddWithValue("@Fecha1", Fecha1)
        micomando.Parameters.AddWithValue("@Fecha2", Fecha2)
        micomando.Parameters.AddWithValue("@EMPRESA", Empresa)
        micomando.Parameters.AddWithValue("@Almacen", Almacen)
        micomando.Parameters.AddWithValue("@PROVEEDOR", PROVEEDOR)

        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        miconexion.Close()
        Return dt
    End Function

    Public Function CargaInfoPedido(ByVal Numero As Integer, ByVal Empresa As String) As DataTable
        Dim query As New StringBuilder
        Dim miconexion As New SqlConnection(conexionAs.CadenaSQL)
        query.Append(" SELECT  dbo.Pedido_Proveedor_Partidas.PedidoID AS PEDIDO, dbo.Pedido_Proveedor_Partidas.Partida AS PARTIDA, dbo.Pedido_Proveedor.ProvID AS 'Nº PROVEEDOR', dbo.Pedido_Proveedor.Prov AS PROVEEDOR, dbo.Pedido_Proveedor.Almacen AS ALMACEN,  " & _
                     " dbo.Pedido_Proveedor_Partidas.CveProducto AS 'CVE PRODUCTO', dbo.Pedido_Proveedor_Partidas.DescProducto AS DESCRIPCION, dbo.Pedido_Proveedor_Partidas.Cantidad AS CANTIDAD, ISNULL(dbo.Pedido_Proveedor_Partidas.CantidadRecibida,0) AS 'CANTIDAD RECIBIDA', " & _
                     " ISNULL(dbo.Pedido_Proveedor_Partidas.CantidadDevuelta,0) AS 'CANTIDAD DEVUELTA' " & _
                     " FROM            dbo.Pedido_Proveedor INNER JOIN " & _
                     " dbo.Pedido_Proveedor_Partidas ON dbo.Pedido_Proveedor.ID = dbo.Pedido_Proveedor_Partidas.PedidoID ")
        query.Append(" WHERE dbo.Pedido_Proveedor_Partidas.PedidoID = @PedidoID AND Pedido_Proveedor.Empresa = @Empresa ORDER BY dbo.Pedido_Proveedor_Partidas.Partida ")
        Dim micomando As New SqlCommand(query.ToString, miconexion)
        miconexion.Open()
        micomando.Parameters.AddWithValue("@PedidoID", Numero)
        micomando.Parameters.AddWithValue("@Empresa", Empresa)


        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        miconexion.Close()
        Return dt
    End Function

    Public Function CargaCodigoProveedor(ByVal Producto As String) As DataTable
        Dim query As New StringBuilder
        Dim miconexion As New SqlConnection(conexion.CadenaSQL)
        query.Append(" SELECT ISNULL(CAMPLIB1,'') FROM INVE_CLIB05 WHERE (CVE_PROD = @PRODUCTO) ")
        Dim micomando As New SqlCommand(query.ToString, miconexion)
        miconexion.Open()

        micomando.Parameters.AddWithValue("@PRODUCTO", Producto)
        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        miconexion.Close()
        Return dt
    End Function

    Public Function CargaCodigoProveedorDimosa(ByVal Producto As String) As DataTable
        Dim query As New StringBuilder
        Dim miconexion As New SqlConnection(conexionDIMOSA.CadenaSQL)
        query.Append(" SELECT ISNULL(CAMPLIB1,'') FROM INVE_CLIB06 WHERE (CVE_PROD = @PRODUCTO) ")
        Dim micomando As New SqlCommand(query.ToString, miconexion)
        miconexion.Open()

        micomando.Parameters.AddWithValue("@PRODUCTO", Producto)
        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        miconexion.Close()
        Return dt
    End Function

    Public Function CargaCodigoProveedorAgro(ByVal Producto As String) As DataTable
        Dim query As New StringBuilder
        Dim miconexion As New SqlConnection(conexionAGRO.CadenaSQL)
        query.Append(" SELECT ISNULL(CAMPLIB1,'') FROM INVE_CLIB02 WHERE (CVE_PROD = @PRODUCTO) ")
        Dim micomando As New SqlCommand(query.ToString, miconexion)
        miconexion.Open()

        micomando.Parameters.AddWithValue("@PRODUCTO", Producto)
        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        miconexion.Close()
        Return dt
    End Function

    Public Function GuardaPartidaPedido(ByVal ID As Integer, ByVal Usuario As String, ByVal Art As String, ByVal Cantidad As Integer)

        Dim ActualizarConexion As New SqlConnection(conexionAs.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try

            Dim miComandoPartidas As New SqlCommand
            miComandoPartidas = New SqlCommand(" UPDATE Pedido_Proveedor_Partidas " & _
                                     " SET CantidadRecibida = ISNULL(CantidadRecibida,0) + @Cantidad " & _
                                     " WHERE PedidoId = @ID and CveProducto = @Partida ", ActualizarConexion)
            miComandoPartidas.Parameters.AddWithValue("@ID", ID)
            miComandoPartidas.Parameters.AddWithValue("@Partida", Art)
            miComandoPartidas.Parameters.AddWithValue("@Cantidad", Cantidad)
            miComandoPartidas.Transaction = transaccion_sql
            miComandoPartidas.ExecuteNonQuery()


            Dim miComandoPartidas2 As New SqlCommand
            miComandoPartidas2 = New SqlCommand(" INSERT into Pedido_Proveedor_Movimiento " & _
                                     " (PedidoID, Cantidad, Fecha, Usuario, CveProducto) " & _
                                     " VALUES(@PedidoID, @Cantidad, @Fecha, @Usuario, @Art) ", ActualizarConexion)

            miComandoPartidas2.Parameters.AddWithValue("@PedidoID", ID)
            miComandoPartidas2.Parameters.AddWithValue("@Cantidad", Cantidad)
            miComandoPartidas2.Parameters.AddWithValue("@Fecha", Today.Date)
            miComandoPartidas2.Parameters.AddWithValue("@Art", Art)
            miComandoPartidas2.Parameters.AddWithValue("@Usuario", Usuario)
            miComandoPartidas2.Transaction = transaccion_sql
            miComandoPartidas2.ExecuteNonQuery()

            Dim miComando As New SqlCommand
            miComando = New SqlCommand("UPDATE Pedido_Proveedor " & _
                                         " SET Estado = 'COMPRA REALIZADA' , FechaCompra = @Fecha, UsuarioCompra = @UsuarioCompra " & _
                                         " WHERE ID = @ID ", ActualizarConexion)

            miComando.Parameters.AddWithValue("@ID", ID)
            miComando.Parameters.AddWithValue("@Fecha", Today.Date)
            miComando.Parameters.AddWithValue("@UsuarioCompra", Usuario)

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
            'MsgBox("Error: " & ex.Message & " " & linea_error)
        End Try

    End Function

    'Public Function GuardaCorreosProveedor(ByVal ID As Integer, ByVal Usuario As String, ByVal Empresa As String)

    '    Dim ActualizarConexion As New SqlConnection(conexionAs.CadenaSQL())
    '    Dim transaccion_sql As SqlTransaction

    '    ActualizarConexion.Open()
    '    transaccion_sql = ActualizarConexion.BeginTransaction

    '    Try

    '        Dim miComandoPartidas As New SqlCommand
    '        miComandoPartidas = New SqlCommand(" UPDATE Pedido_Proveedor_Partidas " & _
    '                                 " SET CantidadRecibida = ISNULL(CantidadRecibida,0) + @Cantidad " & _
    '                                 " WHERE PedidoId = @ID and CveProducto = @Partida ", ActualizarConexion)
    '        miComandoPartidas.Parameters.AddWithValue("@ID", ID)
    '        miComandoPartidas.Parameters.AddWithValue("@Partida", Art)
    '        miComandoPartidas.Parameters.AddWithValue("@Cantidad", Cantidad)
    '        miComandoPartidas.Transaction = transaccion_sql
    '        miComandoPartidas.ExecuteNonQuery()


    '        Dim miComandoPartidas2 As New SqlCommand
    '        miComandoPartidas2 = New SqlCommand(" INSERT into Pedido_Proveedor_Movimiento " & _
    '                                 " (PedidoID, Cantidad, Fecha, Usuario, CveProducto) " & _
    '                                 " VALUES(@PedidoID, @Cantidad, @Fecha, @Usuario, @Art) ", ActualizarConexion)

    '        miComandoPartidas2.Parameters.AddWithValue("@PedidoID", ID)
    '        miComandoPartidas2.Parameters.AddWithValue("@Cantidad", Cantidad)
    '        miComandoPartidas2.Parameters.AddWithValue("@Fecha", Today.Date)
    '        miComandoPartidas2.Parameters.AddWithValue("@Art", Art)
    '        miComandoPartidas2.Parameters.AddWithValue("@Usuario", Usuario)
    '        miComandoPartidas2.Transaction = transaccion_sql
    '        miComandoPartidas2.ExecuteNonQuery()

    '        Dim miComando As New SqlCommand
    '        miComando = New SqlCommand("UPDATE Pedido_Proveedor " & _
    '                                     " SET Estado = 'COMPRA REALIZADA' , FechaCompra = @Fecha, UsuarioCompra = @UsuarioCompra " & _
    '                                     " WHERE ID = @ID ", ActualizarConexion)

    '        miComando.Parameters.AddWithValue("@ID", ID)
    '        miComando.Parameters.AddWithValue("@Fecha", Today.Date)
    '        miComando.Parameters.AddWithValue("@UsuarioCompra", Usuario)

    '        miComando.Transaction = transaccion_sql
    '        miComando.ExecuteNonQuery()

    '        transaccion_sql.Commit()
    '        ActualizarConexion.Close()
    '        Return "s"
    '    Catch ex As Exception
    '        transaccion_sql.Rollback()
    '        ActualizarConexion.Close()
    '        Dim tamaño As Integer = Convert.ToString(ex.StackTrace).Length
    '        Dim posicion As Integer = InStrRev(Convert.ToString(ex.StackTrace), "línea") - 1
    '        Dim inicial As Integer = tamaño - posicion
    '        Dim linea_error As String = Convert.ToString(ex.StackTrace).Substring(tamaño - inicial, inicial)
    '        Return "Error: " & ex.Message & " " & linea_error
    '        'MsgBox("Error: " & ex.Message & " " & linea_error)
    '    End Try

    'End Function

End Class