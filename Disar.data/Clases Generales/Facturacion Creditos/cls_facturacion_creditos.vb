Imports System.Data.SqlClient
Public Class cls_facturacion_creditos
    Dim Conexion As New clsConexion
    Dim Conexion2 As New clsconexion_consumo

    Public Function Insertar_Encabezados(ByVal num_factura As String, ByVal codigo_cliente As String, ByVal vendedor As String _
        , ByVal Fecha_doc As Date, ByVal fecha_ent As Date, ByVal fecha_ven As Date, ByVal fecha_cancela As Date, _
        ByVal can_tot As Double, ByVal imp_tot4 As Double, ByVal des_tot As Double, ByVal num_alma As Integer, ByVal fecha_elab As Date _
        , ByVal importe As Double)

        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("INSERT INTO [Usuarios].[dbo].[Encabezado_Facturas_Credito] ([CVE_DOC],[CVE_CLPV],[CVE_VEND],[FECHA_DOC], " & _
        "[FECHA_ENT],[FECHA_VEN],[FECHA_CANCELA],[CAN_TOT],[IMP_TOT4],[DES_TOT],[NUM_ALMA],[FECHAELAB],[IMPORTE],[METODODEPAGO]) " & _
        " VALUES (@CVE_DOC,@CVE_CLPV,@CVE_VEND,@FECHA_DOC,@FECHA_ENT,@FECHA_VEN,@FECHA_CANCELA, " & _
        "@CAN_TOT,@IMP_TOT4,@DES_TOT,@NUM_ALMA,@FECHAELAB,@IMPORTE,@METODODEPAGO)", ActualizarConexion)
        miComando.Parameters.AddWithValue("@CVE_DOC", num_factura)
        miComando.Parameters.AddWithValue("@CVE_CLPV", codigo_cliente)
        miComando.Parameters.AddWithValue("@CVE_VEND", vendedor)
        miComando.Parameters.AddWithValue("@FECHA_DOC", Fecha_doc)
        miComando.Parameters.AddWithValue("@FECHA_ENT", fecha_ent)
        miComando.Parameters.AddWithValue("@FECHA_VEN", fecha_ven)
        miComando.Parameters.AddWithValue("@FECHA_CANCELA", fecha_cancela)
        miComando.Parameters.AddWithValue("@CAN_TOT", can_tot)
        miComando.Parameters.AddWithValue("@IMP_TOT4", imp_tot4)
        miComando.Parameters.AddWithValue("@DES_TOT", des_tot)
        miComando.Parameters.AddWithValue("@NUM_ALMA", num_alma)
        miComando.Parameters.AddWithValue("@FECHAELAB", fecha_elab)
        miComando.Parameters.AddWithValue("@IMPORTE", importe)
        miComando.Parameters.AddWithValue("@METODODEPAGO", "")

        ActualizarConexion.Open()
        Try
            miComando.ExecuteNonQuery()
            ActualizarConexion.Close()
            Return True
        Catch ex As Exception
            ActualizarConexion.Close()
            Return False
        End Try
    End Function

    Public Function Insertar_Detalle(ByVal CVE_DOC As String, ByVal NUM_PAR As Integer, ByVal CVE_ART As String, _
                                     ByVal CANT As Double, ByVal PREC As Double, ByVal COST As Double, ByVal TOTIMP4 As Double, _
                                      ByVal DESC1 As Double, ByVal TOT_PARTIDA As Double)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("INSERT INTO [Usuarios].[dbo].[Partida_Facturas_Credito] " & _
           "([CVE_DOC],[NUM_PAR],[CVE_ART],[CANT],[PREC],[COST],[TOTIMP4],[DESC1],[TOT_PARTIDA]) " & _
            "VALUES (@CVE_DOC,@NUM_PAR,@CVE_ART,@CANT,@PREC,@COST,@TOTIMP4,@DESC1,@TOT_PARTIDA)", ActualizarConexion)
        miComando.Parameters.AddWithValue("@CVE_DOC", CVE_DOC)
        miComando.Parameters.AddWithValue("@NUM_PAR", NUM_PAR)
        miComando.Parameters.AddWithValue("@CVE_ART", CVE_ART)
        miComando.Parameters.AddWithValue("@CANT", CANT)
        miComando.Parameters.AddWithValue("@PREC", PREC)
        miComando.Parameters.AddWithValue("@COST", COST)
        miComando.Parameters.AddWithValue("@TOTIMP4", TOTIMP4)
        miComando.Parameters.AddWithValue("@DESC1", DESC1)
        miComando.Parameters.AddWithValue("@TOT_PARTIDA", TOT_PARTIDA)

        ActualizarConexion.Open()
        Try
            miComando.ExecuteNonQuery()
            ActualizarConexion.Close()
            Return True
        Catch ex As Exception
            ActualizarConexion.Close()
            Return False
        End Try
    End Function

    Public Function GetId()
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT MAX(ISNULL(CVE_DOC, 0) + 1) AS Codigo FROM dbo.Encabezado_Facturas_Credito", ActualizarConexion)

        ActualizarConexion.Open()
        Dim AdaptadorDeDatos As New SqlDataAdapter(miComando)
        Dim dt As New DataTable
        Try
            AdaptadorDeDatos.Fill(dt)
            ActualizarConexion.Close()
        Catch ex As SqlException
            MsgBox("Hay un problema con la conexión a los datos " & ex.Message, MsgBoxStyle.Critical)
        End Try
        If dt.Rows(0).Item(0) Is DBNull.Value Then
            Return 0
        Else
            Return dt.Rows(0).Item(0)
        End If
    End Function

    Public Function getAlmacen(ByVal DESDE As String, ByVal HASTA As String, ByVal SUCURSAL As String, ByVal FECHA As DateTime, _
                               ByVal CREDITO As String, ByVal TIPO As String, ByVal ALMACEN As Integer) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_reporte_carga_normal", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@DESDE", SqlDbType.Int)).Value = DESDE
        miComando.Parameters.Add(New SqlParameter("@HASTA", SqlDbType.Int)).Value = HASTA
        miComando.Parameters.Add(New SqlParameter("@SUCURSAL", SqlDbType.VarChar)).Value = SUCURSAL
        miComando.Parameters.Add(New SqlParameter("@FECHA", SqlDbType.DateTime)).Value = FECHA
        miComando.Parameters.Add(New SqlParameter("@CREDITO", SqlDbType.VarChar)).Value = CREDITO
        miComando.Parameters.Add(New SqlParameter("@TIPO", SqlDbType.VarChar)).Value = TIPO
        miComando.Parameters.Add(New SqlParameter("@ALMACEN", SqlDbType.Int)).Value = ALMACEN

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

    Public Function Encabezados(ByVal fecha As Date, ByVal almacen As Integer)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT CVE_DOC AS FACTURA, CVE_CLPV AS CODIGO, CL.NOMBRE AS CLIENTE, V.NOMBRE AS VENDEDOR, " & _
        "CONVERT(VARCHAR,FC.FECHA_DOC,103) AS FECHA, ALM.DESCR AS ALMACEN, IMPORTE AS IMPORTE, " & _
        " CONVERT(VARCHAR, CONVERT(MONEY,DES_TOT),1),CONVERT(VARCHAR, CONVERT(MONEY,CAN_TOT),1) ,CONVERT(VARCHAR, CONVERT(MONEY,IMP_TOT4),1) " & _
        "FROM Encabezado_Facturas_Credito FC INNER JOIN SAE60Empre05.dbo.CLIE05 CL ON FC.CVE_CLPV = CL.CLAVE COLLATE MODERN_SPANISH_CI_AS " & _
        "INNER JOIN SAE60Empre05.dbo.VEND05 V ON FC.CVE_VEND = V.CVE_VEND COLLATE MODERN_SPANISH_CI_AS " & _
        "INNER JOIN SAE60Empre05.dbo.ALMACENES05 ALM ON ALM.CVE_ALM = FC.NUM_ALMA " & _
        "WHERE CONVERT(VARCHAR,FC.FECHA_DOC,103) = CONVERT(VARCHAR,@FECHA,103) AND FC.NUM_ALMA = @ALMACEN", ActualizarConexion)

        ActualizarConexion.Open()
        miComando.Parameters.AddWithValue("@FECHA", fecha)
        miComando.Parameters.AddWithValue("@ALMACEN", almacen)
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

    Public Function Partidas(ByVal CVE_DOC As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT CANT,PF.CVE_ART, IV.DESCR AS DESCRIPCION,CONVERT(VARCHAR, CONVERT(MONEY,PREC),1) AS PREC ,  " & _
        "CONVERT(VARCHAR, CONVERT(MONEY,(CANT*PREC)),1) AS SUBTOTAL, CONVERT(VARCHAR, CONVERT(MONEY,(CANT*PREC*DESC1/100)),1) AS DES ,  " & _
        "CONVERT(VARCHAR, CONVERT(MONEY,((CANT*PREC-(CANT*PREC*DESC1/100))*TOTIMP4/100)),1) AS ISV, " & _
        "CONVERT(VARCHAR, CONVERT(MONEY,TOT_PARTIDA),1) AS TOT_PARTIDA " & _
        "FROM Partida_Facturas_Credito PF INNER JOIN SAE60Empre05.dbo.INVE05 IV ON IV.CVE_ART = PF.CVE_ART " & _
        "WHERE CVE_DOC = @CVE_DOC", ActualizarConexion)

        ActualizarConexion.Open()
        miComando.Parameters.AddWithValue("@CVE_DOC", CVE_DOC)
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
