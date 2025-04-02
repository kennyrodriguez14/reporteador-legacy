Imports System.Data.SqlClient

Public Class cls_coberturas_SR_AGRO
    Dim Conexion As New clsconexion_sr_agro

    Public Function ListaUniverso() As DataView
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim sSQL As String = "SELECT (dbo.VEND02.CVE_VEND) AS CLAVE,(dbo.VEND02.NOMBRE) AS VENDEDOR,COUNT(dbo.VEND02.CVE_VEND) AS UNIVERSO " & _
        "FROM  dbo.VEND02 INNER JOIN dbo.CLIE02 ON dbo.VEND02.CVE_VEND = dbo.CLIE02.CVE_VEND  " & _
        "WHERE dbo.CLIE02.NOMBRE in (SELECT dbo.CLIE02.NOMBRE as Total FROM CLIE02 where " & _
        " CLIE02.CVE_VEND =  dbo.VEND02.CVE_VEND) AND CLIE02.CVE_VEND NOT IN ('  100') " & _
        "GROUP BY dbo.VEND02.CVE_VEND, dbo.VEND02.NOMBRE "

        Dim miComando As New SqlCommand(sSQL, ActualizarConexion)
        ActualizarConexion.Open()
        Dim AdaptadorDeDatos As New SqlDataAdapter(miComando)
        Dim ds As New DataSet
        Dim dv As DataView = Nothing
        Try
            AdaptadorDeDatos.Fill(ds, "VEND02")
            If ds.Tables("VEND02").Rows.Count > 0 Then
                dv = New DataView(ds.Tables("VEND02"))
            End If
            ActualizarConexion.Close()
        Catch ex As SqlException
            MsgBox("Hay un problema con la conexión a los datos 1 " & ex.Message, MsgBoxStyle.Critical)
            ActualizarConexion.Close()
        End Try
        Return dv
    End Function

    Public Function VentasXLinea(ByVal Fecha_Ini As Date, ByVal Fecha_Fin As Date, ByVal Linea As String, ByVal Clave As String, ByVal NUM_ALMA As Integer) As DataView
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim sSQL As String = "SELECT DISTINCT dbo.FACTF02.CVE_CLPV " & _
                             "FROM   dbo.PAR_FACTF02 INNER JOIN " & _
                             "dbo.FACTF02 ON dbo.PAR_FACTF02.CVE_DOC = dbo.FACTF02.CVE_DOC INNER JOIN " & _
                             "dbo.CLIE02 INNER JOIN dbo.VEND02 ON dbo.CLIE02.CVE_VEND = dbo.VEND02.CVE_VEND " & _
                             "ON dbo.FACTF02.CVE_CLPV = dbo.CLIE02.CLAVE INNER JOIN " & _
                             "dbo.INVE02 ON dbo.PAR_FACTF02.CVE_ART = dbo.INVE02.CVE_ART " & _
                             "WHERE (dbo.VEND02.CVE_VEND = @Clave) AND (dbo.INVE02.LIN_PROD = @Linea) AND " & _
                             "(dbo.FACTF02.FECHA_DOC >= @Inicio) AND " & _
                             "(dbo.FACTF02.FECHA_DOC <= @Fin) and (NUM_ALMA = @NUM_ALMA OR @NUM_ALMA = -1) "
        Dim miComando As New SqlCommand(sSQL, ActualizarConexion)
        miComando.Parameters.AddWithValue("@Inicio", Fecha_Ini)
        miComando.Parameters.AddWithValue("@Fin", Fecha_Fin)
        miComando.Parameters.AddWithValue("@Linea", Linea)
        miComando.Parameters.AddWithValue("@Clave", Clave)
        miComando.Parameters.AddWithValue("@NUM_ALMA", NUM_ALMA)
        ActualizarConexion.Open()
        Dim AdaptadorDeDatos As New SqlDataAdapter(miComando)
        Dim ds As New DataSet
        Dim dv As DataView = Nothing
        Try
            AdaptadorDeDatos.Fill(ds, "PAR_FACTF02")
            If ds.Tables("PAR_FACTF02").Rows.Count > 0 Then
                dv = New DataView(ds.Tables("PAR_FACTF02"))
            End If
            ActualizarConexion.Close()
        Catch ex As SqlException
            MsgBox("Hay un problema con la conexión a los datos 2 " & ex.Message, MsgBoxStyle.Critical)
            ActualizarConexion.Close()
        End Try
        Return dv
    End Function

    Public Function VentasXLineaOTROS(ByVal Fecha_Ini As Date, ByVal Fecha_Fin As Date, ByVal Clave As String, ByVal NUM_ALMA As Integer) As DataView
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim sSQL As String = "SELECT DISTINCT dbo.FACTF02.CVE_CLPV " & _
        "FROM dbo.PAR_FACTF02 INNER JOIN dbo.FACTF02 ON dbo.PAR_FACTF02.CVE_DOC = dbo.FACTF02.CVE_DOC INNER JOIN dbo.CLIE02 INNER JOIN " & _
        "dbo.VEND02 ON dbo.CLIE02.CVE_VEND = dbo.VEND02.CVE_VEND ON dbo.FACTF02.CVE_CLPV = dbo.CLIE02.CLAVE INNER JOIN " & _
        "dbo.INVE02 ON dbo.PAR_FACTF02.CVE_ART = dbo.INVE02.CVE_ART INNER JOIN dbo.PRVPROD02 ON dbo.INVE02.CVE_ART = dbo.PRVPROD02.CVE_ART " & _
        "WHERE (dbo.VEND02.CVE_VEND = @Clave) AND (dbo.FACTF02.FECHA_DOC >= @Inicio) AND " & _
        "(dbo.FACTF02.FECHA_DOC <= @Fin) AND (NUM_ALMA = @NUM_ALMA OR @NUM_ALMA = -1) "
        Dim miComando As New SqlCommand(sSQL, ActualizarConexion)
        miComando.Parameters.AddWithValue("@Inicio", Fecha_Ini)
        miComando.Parameters.AddWithValue("@Fin", Fecha_Fin)
        miComando.Parameters.AddWithValue("@Clave", Clave)
        miComando.Parameters.AddWithValue("@NUM_ALMA", NUM_ALMA)
        ActualizarConexion.Open()
        Dim AdaptadorDeDatos As New SqlDataAdapter(miComando)
        Dim ds As New DataSet
        Dim dv As DataView = Nothing
        Try
            AdaptadorDeDatos.Fill(ds, "PAR_FACTF02")
            If ds.Tables("PAR_FACTF02").Rows.Count > 0 Then
                dv = New DataView(ds.Tables("PAR_FACTF02"))
            End If
            ActualizarConexion.Close()
        Catch ex As SqlException
            MsgBox("Hay un problema con la conexión a los datos 4 " & ex.Message, MsgBoxStyle.Critical)
            ActualizarConexion.Close()
        End Try
        Return dv
    End Function

    Public Function listar_almacenes() As DataView
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim sSQL As String = "SELECT -1 AS CVE_ALM, 'TODOS' AS DESCR UNION ALL SELECT CVE_ALM, DESCR FROM ALMACENES02 "

        Dim miComando As New SqlCommand(sSQL, ActualizarConexion)
        ActualizarConexion.Open()
        Dim AdaptadorDeDatos As New SqlDataAdapter(miComando)
        Dim ds As New DataSet
        Dim dv As DataView = Nothing
        Try
            AdaptadorDeDatos.Fill(ds, "ALMACENES")
            If ds.Tables("ALMACENES").Rows.Count > 0 Then
                dv = New DataView(ds.Tables("ALMACENES"))
            End If
            ActualizarConexion.Close()
        Catch ex As SqlException
            MsgBox("Hay un problema con la conexión a los datos 4 " & ex.Message, MsgBoxStyle.Critical)
            ActualizarConexion.Close()
        End Try
        Return dv
    End Function
End Class

