Imports System.Data.SqlClient
Public Class cls_ayuda_rutas
    Dim Conexion As New clsConexion

    Public Function Listado()
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT RUTA_ID AS CODIGO, RUTA_DES AS [NOMBRE DE LA RUTA] " & _
                                        "FROM TAB_RUTAS ", ActualizarConexion)
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

    Public Function BuscarNombre(ByVal NOMBRE As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT RUTA_ID AS CODIGO, RUTA_DES AS [NOMBRE DE LA RUTA] " & _
                                        "FROM TAB_RUTAS " & _
                                        "WHERE (RUTA_DES LIKE '%" + NOMBRE + "%') ", ActualizarConexion)
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

    Public Function InsertRutas(ByVal RUTA As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("INSERT INTO [Usuarios].[dbo].[TAB_RUTAS] " & _
                                        "([RUTA_DES]) VALUES (@RUTA_DES)", ActualizarConexion)

        miComando.Parameters.AddWithValue("@RUTA_DES", RUTA)
        ActualizarConexion.Open()
        Try
            miComando.ExecuteNonQuery()
            ActualizarConexion.Close()
            Return True
        Catch ex As SqlException
            MsgBox("Hay un problema con la conexión a los datos " & ex.Message, MsgBoxStyle.Critical)
            ActualizarConexion.Close()
            Return False
        End Try
    End Function

    Public Function UpdateRutas(ByVal ID As Integer, ByVal RUTA As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("UPDATE TAB_RUTAS " & _
                                        "SET [RUTA_DES] = @RUTA_DES WHERE RUTA_ID = @RUTA_ID", ActualizarConexion)
        miComando.Parameters.AddWithValue("@RUTA_ID", ID)
        miComando.Parameters.AddWithValue("@RUTA_DES", RUTA)
        ActualizarConexion.Open()
        Try
            miComando.ExecuteNonQuery()
            ActualizarConexion.Close()
            Return True
        Catch ex As SqlException
            MsgBox("Hay un problema con la conexión a los datos " & ex.Message, MsgBoxStyle.Critical)
            ActualizarConexion.Close()
            Return False
        End Try
    End Function

    Public Function BuscarRUTAS_SIP(ByVal RUTAID As String, ByVal RUTA As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT  L.LOTE_ID AS CODIGO, L.LOTE_RUTA AS RUTA, L.LOTE_FECHA AS FECHA, " & _
                                        "E.EntregadorNombre AS ENTREGADOR, LOTE_PESO AS PESO, LOTE_NUM_PEDI AS PEDIDOS, " & _
                                        " LOTE_MONTO AS MONTO,LOTE_VEHICULOID AS VEHICULO " & _
                                        "FROM PEDIDOSHH02.dbo.LOTES L INNER JOIN Usuarios.dbo.Entregadores E ON " & _
                                        "CONVERT(INT,L.LOTE_ENTREGADORID) = CONVERT(INT,E.EntregadorCodigo) " & _
                                        "INNER JOIN PEDIDOSHH02.dbo.ALMACENES A ON L.LOTE_ALMACEN = A.ALMACEN_ID " & _
                                        "WHERE CONVERT(VARCHAR,LOTE_ID) = @LOTE_ID OR UPPER(LOTE_RUTA) LIKE '%' + @RUTA + '%' ", ActualizarConexion)
        miComando.Parameters.AddWithValue("@LOTE_ID", RUTAID)
        miComando.Parameters.AddWithValue("@RUTA", RUTA)
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

    Public Function Detalle_RutasSIP(ByVal RUTAID As Integer)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT P.CVE_CLIE AS CLIENTE, CL.NOMBRE, (CASE WHEN ROUND(SUM(PP.CANT*IV.PESO),2) >0 THEN ROUND(SUM(PP.CANT*IV.PESO),2) ELSE 1 END) AS PESO, '' AS LLEGADA, '' AS SALIDA " & _
                                        "FROM PEDIDOSHH02.dbo.PEDI02 P INNER JOIN SAE60Empre01.dbo.CLIE01 CL ON P.CVE_CLIE = CL.CLAVE " & _
                                        "COLLATE MODERN_SPANISH_CI_AS INNER JOIN PEDIDOSHH02.dbo.PAR_PEDI02 PP ON P.PEDIDO_ID = PP.PEDIDO_ID " & _
                                        "AND P.FECHA = PP.FECHA AND P.CVE_VEND = PP.CVE_VENDEDOR AND P.CVE_CLIE = PP.CVE_CLIE " & _
                                        "LEFT OUTER JOIN PEDIDOSHH02.dbo.LOTES_PEDIDOS ON P.FECHA = PEDIDOSHH02.dbo.LOTES_PEDIDOS.FECHA AND " & _
                                        "P.PEDIDO_ID = PEDIDOSHH02.dbo.LOTES_PEDIDOS.PEDIDO_ID And P.CVE_VEND = PEDIDOSHH02.dbo.LOTES_PEDIDOS.CVE_VEND " & _
                                        "AND P.CVE_CLIE = PEDIDOSHH02.dbo.LOTES_PEDIDOS.CVE_CLIE INNER JOIN SAE60Empre01.dbo.INVE01 IV " & _
                                        "ON IV.CVE_ART = PP.CVE_ART COLLATE MODERN_SPANISH_CI_AS " & _
                                        "WHERE(PEDIDOSHH02.dbo.LOTES_PEDIDOS.LOTE_ID = @LOTE_ID) " & _
                                        "GROUP BY P.CVE_CLIE,CL.NOMBRE", ActualizarConexion)
        miComando.Parameters.AddWithValue("@LOTE_ID", RUTAID)
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
