Imports System.Data.SqlClient

Public Class ClsFunciones
    Dim Conexion As New clsconexion_sr_agro
    Dim ConexionUsuario As New clsConexion

    Public Function MuestraClientes() As DataView
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim AdaptadorDeDatos As New SqlDataAdapter("SELECT dbo.CLIE02.CLAVE, dbo.CLIE02.NOMBRE, dbo.CLIE02.STATUS, dbo.CLIE02.LOCALIDAD, dbo.CLIE02.ESTADO as 'ID / RTN', dbo.CLIE02.CLASIFIC AS 'LISTAS DE PRECIOS', dbo.CLIE_CLIB02.CAMPLIB3 AS 'DÍA DE VISITA', dbo.CLIE02.FCH_ULTCOM as 'ÚLTIMA COMPRA', dbo.CLIE02.CVE_VEND as 'ID VENDEDOR', dbo.VEND02.NOMBRE as 'VENDEDOR'," & _
                      " dbo.CLIE_CLIB02.CAMPLIB10 AS CULTIVOS, dbo.CLIE_CLIB02.CAMPLIB11 AS '# MANZANAS', dbo.CLIE_CLIB02.CAMPLIB12 AS 'TIPO DE GRANJA', dbo.CLIE_CLIB02.CAMPLIB13 AS '# ANIMALES', " & _
                      " dbo.CLIE_CLIB02.CAMPLIB14 AS 'TIENE MASCOTA', dbo.CLIE_CLIB02.CAMPLIB15 AS 'AGROSERVICIO MAS VISITADO', dbo.CLIE_CLIB02.CAMPLIB16 AS '¿POR QUÉ?', " & _
                      " dbo.CLIE_CLIB02.CAMPLIB17 AS 'MARCAS DE FERTILIZANTES QUE UTILIZA', dbo.CLIE02.CALLE as 'DIRECCIÓN', TELEFONO as 'TELÉFONO' " & _
                      " FROM   dbo.VEND02 INNER JOIN dbo.CLIE02 ON dbo.VEND02.CVE_VEND = dbo.CLIE02.CVE_VEND INNER JOIN dbo.CLIE_CLIB02 ON dbo.CLIE02.CLAVE = dbo.CLIE_CLIB02.CVE_CLIE" & _
                      " WHERE dbo.CLIE02.STATUS <> 'S' AND dbo.CLIE02.CVE_VEND <> '  100'", ActualizarConexion)
        ActualizarConexion.Open()
        Dim ds As New DataSet
        Dim dv As New DataView
        Try
            AdaptadorDeDatos.Fill(ds, "User")
            If ds.Tables("User").Rows.Count > 0 Then
                dv = New DataView(ds.Tables("User"))
            End If
        Catch ex As SqlException
            MsgBox("Hay problemas de Conexión: " + ex.Message, MsgBoxStyle.Critical)
        End Try
        ActualizarConexion.Close()
        Return dv
    End Function

    Public Function MuestraClientesVENDEDOR(ByVal Vendedor As String) As DataView
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim AdaptadorDeDatos As New SqlDataAdapter("SELECT dbo.CLIE02.CLAVE, dbo.CLIE02.NOMBRE, dbo.CLIE02.STATUS, dbo.CLIE02.LOCALIDAD, dbo.CLIE02.ESTADO as 'ID / RTN', dbo.CLIE02.CLASIFIC AS 'LISTAS DE PRECIOS', dbo.CLIE_CLIB02.CAMPLIB3 AS 'DÍA DE VISITA', dbo.CLIE02.FCH_ULTCOM as 'ÚLTIMA COMPRA', dbo.CLIE02.CVE_VEND as 'ID VENDEDOR', dbo.VEND02.NOMBRE as 'VENDEDOR'," & _
                      " dbo.CLIE_CLIB02.CAMPLIB10 AS CULTIVOS, dbo.CLIE_CLIB02.CAMPLIB11 AS '# MANZANAS', dbo.CLIE_CLIB02.CAMPLIB12 AS 'TIPO DE GRANJA', dbo.CLIE_CLIB02.CAMPLIB13 AS '# ANIMALES', " & _
                      " dbo.CLIE_CLIB02.CAMPLIB14 AS 'TIENE MASCOTA', dbo.CLIE_CLIB02.CAMPLIB15 AS 'AGROSERVICIO MAS VISITADO', dbo.CLIE_CLIB02.CAMPLIB16 AS '¿POR QUÉ?', " & _
                      " dbo.CLIE_CLIB02.CAMPLIB17 AS 'MARCAS DE FERTILIZANTES QUE UTILIZA', dbo.CLIE02.CALLE as 'DIRECCIÓN', TELEFONO as 'TELÉFONO' " & _
                      " FROM   dbo.VEND02 INNER JOIN dbo.CLIE02 ON dbo.VEND02.CVE_VEND = dbo.CLIE02.CVE_VEND INNER JOIN dbo.CLIE_CLIB02 ON dbo.CLIE02.CLAVE = dbo.CLIE_CLIB02.CVE_CLIE" & _
                      " WHERE dbo.CLIE02.STATUS <> 'S' AND dbo.VEND02.NOMBRE = '" & Vendedor & "'", ActualizarConexion)
        ActualizarConexion.Open()
        Dim ds As New DataSet
        Dim dv As New DataView
        Try
            AdaptadorDeDatos.Fill(ds, "User")
            If ds.Tables("User").Rows.Count > 0 Then
                dv = New DataView(ds.Tables("User"))
            End If
        Catch ex As SqlException
            MsgBox("Hay problemas de Conexión: " + ex.Message, MsgBoxStyle.Critical)
        End Try
        ActualizarConexion.Close()
        Return dv
    End Function

    Public Function MuestraClientesDIA(ByVal Dia As String) As DataView
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim AdaptadorDeDatos As New SqlDataAdapter("SELECT dbo.CLIE02.CLAVE, dbo.CLIE02.NOMBRE, dbo.CLIE02.STATUS, dbo.CLIE02.LOCALIDAD, dbo.CLIE02.ESTADO as 'ID / RTN', dbo.CLIE02.CLASIFIC AS 'LISTAS DE PRECIOS', dbo.CLIE_CLIB02.CAMPLIB3 AS 'DÍA DE VISITA', dbo.CLIE02.FCH_ULTCOM as 'ÚLTIMA COMPRA', dbo.CLIE02.CVE_VEND as 'ID VENDEDOR', dbo.VEND02.NOMBRE as 'VENDEDOR'," & _
                      " dbo.CLIE_CLIB02.CAMPLIB10 AS CULTIVOS, dbo.CLIE_CLIB02.CAMPLIB11 AS '# MANZANAS', dbo.CLIE_CLIB02.CAMPLIB12 AS 'TIPO DE GRANJA', dbo.CLIE_CLIB02.CAMPLIB13 AS '# ANIMALES', " & _
                      " dbo.CLIE_CLIB02.CAMPLIB14 AS 'TIENE MASCOTA', dbo.CLIE_CLIB02.CAMPLIB15 AS 'AGROSERVICIO MAS VISITADO', dbo.CLIE_CLIB02.CAMPLIB16 AS '¿POR QUÉ?', " & _
                      " dbo.CLIE_CLIB02.CAMPLIB17 AS 'MARCAS DE FERTILIZANTES QUE UTILIZA', dbo.CLIE02.CALLE as 'DIRECCIÓN', TELEFONO as 'TELÉFONO' " & _
                      " FROM   dbo.VEND02 INNER JOIN dbo.CLIE02 ON dbo.VEND02.CVE_VEND = dbo.CLIE02.CVE_VEND INNER JOIN dbo.CLIE_CLIB02 ON dbo.CLIE02.CLAVE = dbo.CLIE_CLIB02.CVE_CLIE" & _
                      " WHERE dbo.CLIE02.STATUS <> 'S' AND CLIE_CLIB02.CAMPLIB3 LIKE '%" & LTrim(RTrim(Dia)) & "%' ", ActualizarConexion)
        ActualizarConexion.Open()
        Dim ds As New DataSet
        Dim dv As New DataView
        Try
            AdaptadorDeDatos.Fill(ds, "User")
            If ds.Tables("User").Rows.Count > 0 Then
                dv = New DataView(ds.Tables("User"))
            End If
        Catch ex As SqlException
            MsgBox("Hay problemas de Conexión: " + ex.Message, MsgBoxStyle.Critical)
        End Try
        ActualizarConexion.Close()
        Return dv
    End Function

    Public Function BuscaClientes(ByVal Busqueda As String) As DataView
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim AdaptadorDeDatos As New SqlDataAdapter("SELECT dbo.CLIE02.CLAVE, dbo.CLIE02.NOMBRE, dbo.CLIE02.STATUS, dbo.CLIE02.LOCALIDAD, dbo.CLIE02.ESTADO as 'ID / RTN', dbo.CLIE02.CLASIFIC AS 'LISTAS DE PRECIOS', dbo.CLIE_CLIB02.CAMPLIB3 AS 'DÍA DE VISITA', dbo.CLIE02.FCH_ULTCOM as 'ÚLTIMA COMPRA', dbo.CLIE02.CVE_VEND as 'ID VENDEDOR', dbo.VEND02.NOMBRE as 'VENDEDOR'," & _
                      " dbo.CLIE_CLIB02.CAMPLIB10 AS CULTIVOS, dbo.CLIE_CLIB02.CAMPLIB11 AS '# MANZANAS', dbo.CLIE_CLIB02.CAMPLIB12 AS 'TIPO DE GRANJA', dbo.CLIE_CLIB02.CAMPLIB13 AS '# ANIMALES', " & _
                      " dbo.CLIE_CLIB02.CAMPLIB14 AS 'TIENE MASCOTA', dbo.CLIE_CLIB02.CAMPLIB15 AS 'AGROSERVICIO MAS VISITADO', dbo.CLIE_CLIB02.CAMPLIB16 AS '¿POR QUÉ?', " & _
                      " dbo.CLIE_CLIB02.CAMPLIB17 AS 'MARCAS DE FERTILIZANTES QUE UTILIZA', dbo.CLIE02.CALLE as 'DIRECCIÓN', TELEFONO as 'TELÉFONO' " & _
                      " FROM   dbo.VEND02 INNER JOIN dbo.CLIE02 ON dbo.VEND02.CVE_VEND = dbo.CLIE02.CVE_VEND INNER JOIN dbo.CLIE_CLIB02 ON dbo.CLIE02.CLAVE = dbo.CLIE_CLIB02.CVE_CLIE WHERE LTRIM(dbo.CLIE02.CLAVE) = '" & LTrim(RTrim(Busqueda)) & "' AND dbo.CLIE02.STATUS <> 'S' AND dbo.CLIE02.CVE_VEND <> '  100' OR dbo.CLIE02.NOMBRE LIKE '%" & LTrim(RTrim(Busqueda.ToUpper)) & "%' " & _
                      " AND dbo.CLIE02.STATUS <> 'S' AND dbo.CLIE02.CVE_VEND <> '  100' OR dbo.CLIE02.ESTADO LIKE '" & LTrim(RTrim(Busqueda)) & "' AND dbo.CLIE02.STATUS <> 'S' AND dbo.CLIE02.CVE_VEND <> '  100'", ActualizarConexion)
        ActualizarConexion.Open()
        Dim ds As New DataSet
        Dim dv As New DataView
        Try
            AdaptadorDeDatos.Fill(ds, "User")
            If ds.Tables("User").Rows.Count > 0 Then
                dv = New DataView(ds.Tables("User"))
            End If
        Catch ex As SqlException
            MsgBox("Hay problemas de Conexión: " + ex.Message, MsgBoxStyle.Critical)
        End Try
        ActualizarConexion.Close()
        Return dv
    End Function

    Public Function ModificaCampos(ByVal Cliente As String, ByVal Cultivos As String, ByVal Manzanas As String, ByVal TipoGranja As String, ByVal NumAnimales As String, ByVal TieneMascota As String, ByVal Agro As String, ByVal PorQue As String, ByVal Marca As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("UPDATE CLIE_CLIB02 " & _
                                        " SET dbo.CLIE_CLIB02.CAMPLIB10 = @CAMPLIB10, dbo.CLIE_CLIB02.CAMPLIB11 = @CAMPLIB11, dbo.CLIE_CLIB02.CAMPLIB12 = @CAMPLIB12, dbo.CLIE_CLIB02.CAMPLIB13 = @CAMPLIB13, " & _
                                        " dbo.CLIE_CLIB02.CAMPLIB14 = @CAMPLIB14, dbo.CLIE_CLIB02.CAMPLIB15 = @CAMPLIB15, dbo.CLIE_CLIB02.CAMPLIB16 = @CAMPLIB16, dbo.CLIE_CLIB02.CAMPLIB17 = @CAMPLIB17" & _
                                        " WHERE CVE_CLIE = @CVE_CLIE", ActualizarConexion)
        miComando.Parameters.AddWithValue("@CVE_CLIE", Cliente)
        miComando.Parameters.AddWithValue("@CAMPLIB10", Cultivos)
        miComando.Parameters.AddWithValue("@CAMPLIB11", Manzanas)
        miComando.Parameters.AddWithValue("@CAMPLIB12", TipoGranja)
        miComando.Parameters.AddWithValue("@CAMPLIB13", NumAnimales)
        miComando.Parameters.AddWithValue("@CAMPLIB14", TieneMascota)
        miComando.Parameters.AddWithValue("@CAMPLIB15", Agro)
        miComando.Parameters.AddWithValue("@CAMPLIB16", PorQue)
        miComando.Parameters.AddWithValue("@CAMPLIB17", Marca)
        ActualizarConexion.Open()
        miComando.ExecuteNonQuery()
        ActualizarConexion.Close()
        Return True
    End Function

    Public Function BuscaFacturas(ByVal Cliente As String, ByVal Cantidad As Integer) As DataView
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim AdaptadorDeDatos As New SqlDataAdapter("SELECT  TOP(" & Cantidad & ") CVE_DOC AS 'FACTURA', FECHA_DOC AS 'FECHA DEL DOCUMENTO', CAN_TOT AS SUBTOTAL, " & _
                      " IMP_TOT4 as 'IMPUESTO TOTAL', DES_TOT as 'DESCUENTO TOTAL', " & _
                      " CASE WHEN CONTADO = 'S' then 'CONTADO' else 'CREDITO' END AS 'TIPO DE PAGO' , IMPORTE as 'TOTAL IMPORTE', DOC_SIG AS '# DE DEVOLUCION'" & _
                      " FROM FACTF02 WHERE CVE_CLPV = '" & Cliente & "' AND ENLAZADO <> 'T'ORDER BY FECHA_DOC DESC", ActualizarConexion)
        ActualizarConexion.Open()
        Dim ds As New DataSet
        Dim dv As New DataView
        Try
            AdaptadorDeDatos.Fill(ds, "User")
            If ds.Tables("User").Rows.Count > 0 Then
                dv = New DataView(ds.Tables("User"))
            End If
        Catch ex As SqlException
            MsgBox("Hay problemas de Conexión: " + ex.Message, MsgBoxStyle.Critical)
        End Try
        ActualizarConexion.Close()
        Return dv
    End Function

    Public Function BuscaDetalles(ByVal Factura As String) As DataView
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim AdaptadorDeDatos As New SqlDataAdapter("SELECT dbo.PAR_FACTF02.CVE_ART as 'CLAVE PRODUCTO', dbo.INVE02.DESCR as 'DESCRIPCIÓN', UPPER(dbo.INVE_CLIB02.CAMPLIB2) AS 'TIPO', dbo.PAR_FACTF02.CANT as 'CANTIDAD', dbo.PAR_FACTF02.PREC as 'PRECIO', CANT*PREC AS SUBTOTAL,  " & _
                      " dbo.PAR_FACTF02.COST as 'COSTO', dbo.PAR_FACTF02.IMPU4 as 'IMPUESTO', dbo.PAR_FACTF02.TOTIMP4 as 'TOTAL IMPUESTO', dbo.PAR_FACTF02.DESC1 as '% DESCUENTO', dbo.PAR_FACTF02.TOT_PARTIDA as 'IMPORTE TOTAL' " & _
                      " FROM dbo.PAR_FACTF02 INNER JOIN dbo.INVE02 ON dbo.PAR_FACTF02.CVE_ART = dbo.INVE02.CVE_ART INNER JOIN  dbo.INVE_CLIB02 ON dbo.INVE02.CVE_ART = dbo.INVE_CLIB02.CVE_PROD " & _
                      " WHERE dbo.PAR_FACTF02.CVE_DOC = '" & Factura & "' ", ActualizarConexion)
        ActualizarConexion.Open()
        Dim ds As New DataSet
        Dim dv As New DataView
        Try
            AdaptadorDeDatos.Fill(ds, "User")
            If ds.Tables("User").Rows.Count > 0 Then
                dv = New DataView(ds.Tables("User"))
            End If
        Catch ex As SqlException
            MsgBox("Hay problemas de Conexión: " + ex.Message, MsgBoxStyle.Critical)
        End Try
        ActualizarConexion.Close()
        Return dv
    End Function

    Public Function InsertaBitacora(ByVal Cambio As String, ByVal Clave As String, ByVal USUARIO As String)
        Dim ActualizarConexion As New SqlConnection(ConexionUsuario.CadenaSQL())
        Dim miComando As New SqlCommand("INSERT INTO CLI_PROD_BITA " & _
                                        " (Bit_Cambio, Bit_Clave, Bit_Fecha, Bit_Usuario) " & _
                                        " VALUES (@Bit_Cambio, @Bit_Clave, @Bit_Fecha, @Bit_Usuario) ", ActualizarConexion)
        miComando.Parameters.AddWithValue("@Bit_Cambio", Cambio)
        miComando.Parameters.AddWithValue("@Bit_Clave", Clave)
        miComando.Parameters.AddWithValue("@Bit_Fecha", Now)
        miComando.Parameters.AddWithValue("@Bit_Usuario", USUARIO)

        ActualizarConexion.Open()
        miComando.ExecuteNonQuery()
        ActualizarConexion.Close()
        Return True
    End Function

    Public Function BuscaDevoluciones(ByVal Factura As String) As DataView
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim AdaptadorDeDatos As New SqlDataAdapter("SELECT IMPORTE,IMP_TOT4,STATUS FROM FACTD02 WHERE CVE_DOC = '" & Factura & "'", ActualizarConexion)
        ActualizarConexion.Open()
        Dim ds As New DataSet
        Dim dv As New DataView
        Try
            AdaptadorDeDatos.Fill(ds, "User")
            If ds.Tables("User").Rows.Count > 0 Then
                dv = New DataView(ds.Tables("User"))
            End If
        Catch ex As SqlException
            MsgBox("Hay problemas de Conexión: " + ex.Message, MsgBoxStyle.Critical)
        End Try
        ActualizarConexion.Close()
        Return dv
    End Function

    Public Function BuscaDevolucionesProducto(ByVal Factura As String, ByVal Producto As String) As DataView
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim AdaptadorDeDatos As New SqlDataAdapter("SELECT TOT_PARTIDA, TOTIMP4, CANT  FROM PAR_FACTD02 WHERE CVE_DOC = '" & Factura & "' AND CVE_ART = '" & Producto & "'", ActualizarConexion)
        ActualizarConexion.Open()
        Dim ds As New DataSet
        Dim dv As New DataView
        Try
            AdaptadorDeDatos.Fill(ds, "User")
            If ds.Tables("User").Rows.Count > 0 Then
                dv = New DataView(ds.Tables("User"))
            End If
        Catch ex As SqlException
            MsgBox("Hay problemas de Conexión: " + ex.Message, MsgBoxStyle.Critical)
        End Try
        ActualizarConexion.Close()
        Return dv
    End Function

    Public Function MuestraDetalleUnProducto(ByVal Producto As String, ByVal CLiente As String, ByVal Fecha1 As Date, ByVal Fecha2 As Date) As DataView
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim AdaptadorDeDatos As New SqlDataAdapter("SELECT dbo.FACTF02.CVE_DOC as 'Factura', dbo.FACTF02.FECHA_DOC as 'Fecha', dbo.PAR_FACTF02.CVE_ART as 'Clave de Producto', dbo.INVE02.DESCR as 'Producto', dbo.PAR_FACTF02.CANT as 'Cantidad', dbo.PAR_FACTF02.PREC as 'Precio', (CANT*PREC) AS Subtotal, dbo.PAR_FACTF02.DESC1 as '% De Descuento', (CANT*PREC) - ((CANT*PREC)*(DESC1/100)) as 'Total antes de ISV'" & _
                                                   "FROM dbo.FACTF02 INNER JOIN dbo.PAR_FACTF02 ON dbo.FACTF02.CVE_DOC = dbo.PAR_FACTF02.CVE_DOC INNER JOIN dbo.INVE02 ON dbo.PAR_FACTF02.CVE_ART = dbo.INVE02.CVE_ART WHERE dbo.FACTF02.CVE_CLPV = '" & CLiente & "' AND dbo.PAR_FACTF02.CVE_ART = '" & Producto & "' AND dbo.FACTF02.ENLAZADO <> 'T' AND dbo.FACTF02.FECHA_DOC >= '" & Fecha1.Date & "' AND dbo.FACTF02.FECHA_DOC <= '" & Fecha2.Date & "' ORDER BY dbo.FACTF02.FECHA_DOC DESC", ActualizarConexion)
        ActualizarConexion.Open()
        Dim ds As New DataSet
        Dim dv As New DataView
        Try
            AdaptadorDeDatos.Fill(ds, "User")
            If ds.Tables("User").Rows.Count > 0 Then
                dv = New DataView(ds.Tables("User"))
            End If
        Catch ex As SqlException
            MsgBox("Hay problemas de Conexión: " + ex.Message, MsgBoxStyle.Critical)
        End Try
        ActualizarConexion.Close()
        Return dv
    End Function

    Public Function BuscaFacturasRangoFecha(ByVal Cliente As String, ByVal FechaInicial As Date, ByVal FechaFinal As Date) As DataView
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim AdaptadorDeDatos As New SqlDataAdapter("SELECT  CVE_DOC AS 'FACTURA', FECHA_DOC AS 'FECHA DEL DOCUMENTO', CAN_TOT AS SUBTOTAL, " & _
                      " IMP_TOT4 as 'IMPUESTO TOTAL', DES_TOT as 'DESCUENTO TOTAL', " & _
                      " CASE WHEN CONTADO = 'S' then 'CONTADO' else 'CREDITO' END AS 'TIPO DE PAGO' , IMPORTE as 'TOTAL IMPORTE', DOC_SIG AS '# DE DEVOLUCION'" & _
                      " FROM FACTF02 WHERE CVE_CLPV = '" & Cliente & "' AND ENLAZADO <> 'T' AND FECHA_DOC >= '" & FechaInicial.Date & "' AND FECHA_DOC <= '" & FechaFinal.Date & "' ORDER BY FECHA_DOC DESC", ActualizarConexion)
        ActualizarConexion.Open()
        Dim ds As New DataSet
        Dim dv As New DataView
        Try
            AdaptadorDeDatos.Fill(ds, "User")
            If ds.Tables("User").Rows.Count > 0 Then
                dv = New DataView(ds.Tables("User"))
            End If
        Catch ex As SqlException
            MsgBox("Hay problemas de Conexión: " + ex.Message, MsgBoxStyle.Critical)
        End Try
        ActualizarConexion.Close()
        Return dv
    End Function

    Public Function MuestraVendedores() As DataView
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim AdaptadorDeDatos As New SqlDataAdapter("SELECT CVE_VEND, NOMBRE FROM dbo.VEND02 WHERE CORREOE <> 'NE@NE' OR CORREOE IS NULL ORDER BY NOMBRE ASC", ActualizarConexion)
        ActualizarConexion.Open()
        Dim ds As New DataSet
        Dim dv As New DataView
        Try
            AdaptadorDeDatos.Fill(ds, "User")
            If ds.Tables("User").Rows.Count > 0 Then
                dv = New DataView(ds.Tables("User"))
            End If
        Catch ex As SqlException
            MsgBox("Hay problemas de Conexión: " + ex.Message, MsgBoxStyle.Critical)
        End Try
        ActualizarConexion.Close()
        Return dv
    End Function

End Class

