Imports System.Data.SqlClient

Public Class cls_coberturas_sps
    Dim Conexion As New clsconexion_consumo

    Public Function ListaUniverso() As DataView
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim sSQL As String = "SELECT (dbo.VEND05.CVE_VEND) AS CLAVE,(dbo.VEND05.NOMBRE) AS VENDEDOR,COUNT(dbo.VEND05.CVE_VEND) AS UNIVERSO " & _
        "FROM  dbo.VEND05 INNER JOIN dbo.CLIE05 ON dbo.VEND05.CVE_VEND = dbo.CLIE05.CVE_VEND  " & _
        "WHERE dbo.CLIE05.NOMBRE in (SELECT dbo.CLIE05.NOMBRE as Total FROM CLIE05 where " & _
        " CLIE05.CVE_VEND =  dbo.VEND05.CVE_VEND) AND (dbo.VEND05.CORREOE = 'SP@S')  " & _
        "GROUP BY dbo.VEND05.CVE_VEND, dbo.VEND05.NOMBRE "

        Dim miComando As New SqlCommand(sSQL, ActualizarConexion)
        ActualizarConexion.Open()
        Dim AdaptadorDeDatos As New SqlDataAdapter(miComando)
        Dim ds As New DataSet
        Dim dv As DataView = Nothing
        Try
            AdaptadorDeDatos.Fill(ds, "VEND05")
            If ds.Tables("VEND05").Rows.Count > 0 Then
                dv = New DataView(ds.Tables("VEND05"))
            End If
            ActualizarConexion.Close()
        Catch ex As SqlException
            MsgBox("Hay un problema con la conexión a los datos 1 " & ex.Message, MsgBoxStyle.Critical)
            ActualizarConexion.Close()
        End Try
        Return dv
    End Function

    Public Function VentasXLinea(ByVal Fecha_Ini As Date, ByVal Fecha_Fin As Date, ByVal Linea As String, ByVal Clave As String) As DataView
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim sSQL As String = "SELECT        CVE_CLPV, sum(Expr1) as Suma " & _
        " FROM " & _
        "( " & _
        " SELECT        dbo.FACTF05.CVE_CLPV, SUM(dbo.PAR_FACTF05.PREC * dbo.PAR_FACTF05.CANT) AS Expr1  " & _
        " FROM            dbo.PAR_FACTF05 INNER JOIN  " & _
        " dbo.FACTF05 ON dbo.PAR_FACTF05.CVE_DOC = dbo.FACTF05.CVE_DOC INNER JOIN " & _
        " dbo.CLIE05 INNER JOIN " & _
        " dbo.VEND05 ON dbo.CLIE05.CVE_VEND = dbo.VEND05.CVE_VEND ON dbo.FACTF05.CVE_CLPV = dbo.CLIE05.CLAVE INNER JOIN " & _
        " dbo.INVE05 ON dbo.PAR_FACTF05.CVE_ART = dbo.INVE05.CVE_ART  " & _
        " WHERE        (ISNUMERIC(dbo.VEND05.CVE_VEND) = 1) AND (dbo.VEND05.CVE_VEND = @Clave) AND (dbo.INVE05.LIN_PROD = @Linea) AND (dbo.FACTF05.FECHA_DOC >= @Inicio) AND  " & _
        " (dbo.FACTF05.FECHA_DOC <= @Fin) AND (dbo.FACTF05.NUM_ALMA = 1)  " & _
        " GROUP BY dbo.FACTF05.CVE_CLPV  " & _
        " UNION ALL " & _
        " SELECT        dbo.FACTD05.CVE_CLPV, SUM(dbo.PAR_FACTD05.PREC * dbo.PAR_FACTD05.CANT * - 1) AS Expr1 " & _
        " FROM            dbo.PAR_FACTD05 INNER JOIN  " & _
        " dbo.FACTD05 ON dbo.PAR_FACTD05.CVE_DOC = dbo.FACTD05.CVE_DOC INNER JOIN  " & _
        " dbo.CLIE05 AS CLIE05_1 INNER JOIN " & _
        " dbo.VEND05 AS VEND05_1 ON CLIE05_1.CVE_VEND = VEND05_1.CVE_VEND ON dbo.FACTD05.CVE_CLPV = CLIE05_1.CLAVE INNER JOIN " & _
        " dbo.INVE05 AS INVE05_1 ON dbo.PAR_FACTD05.CVE_ART = INVE05_1.CVE_ART " & _
        " WHERE        (ISNUMERIC(VEND05_1.CVE_VEND) = 1) AND (VEND05_1.CVE_VEND = @Clave) AND (INVE05_1.LIN_PROD = @Linea) AND (dbo.FACTD05.FECHA_DOC >= @Inicio) AND " & _
        " (dbo.FACTD05.FECHA_DOC <= @Fin) AND (dbo.FACTD05.NUM_ALMA = 1) " & _
        " GROUP BY dbo.FACTD05.CVE_CLPV) AS derivedtbl_1 " & _
        " Group By CVE_CLPV 		 Having sum(Expr1) > 0"
        Dim miComando As New SqlCommand(sSQL, ActualizarConexion)
        miComando.Parameters.AddWithValue("@Inicio", Fecha_Ini)
        miComando.Parameters.AddWithValue("@Fin", Fecha_Fin)
        miComando.Parameters.AddWithValue("@Linea", Linea)
        miComando.Parameters.AddWithValue("@Clave", Clave)
        ActualizarConexion.Open()
        Dim AdaptadorDeDatos As New SqlDataAdapter(miComando)
        Dim ds As New DataSet
        Dim dv As DataView = Nothing
        Try
            AdaptadorDeDatos.Fill(ds, "PAR_FACTF05")
            If ds.Tables("PAR_FACTF05").Rows.Count > 0 Then
                dv = New DataView(ds.Tables("PAR_FACTF05"))
            End If
            ActualizarConexion.Close()
        Catch ex As SqlException
            MsgBox("Hay un problema con la conexión a los datos 2 " & ex.Message, MsgBoxStyle.Critical)
            ActualizarConexion.Close()
        End Try
        Return dv
    End Function

    Public Function VentasXLineaKC(ByVal Fecha_Ini As Date, ByVal Fecha_Fin As Date, ByVal Clave As String) As DataView
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim sSQL As String = "SELECT        CVE_CLPV, sum(Expr1) as Suma " & _
        " FROM " & _
        "( " & _
        " SELECT        dbo.FACTF05.CVE_CLPV, SUM(dbo.PAR_FACTF05.PREC * dbo.PAR_FACTF05.CANT) AS Expr1  " & _
        " FROM            dbo.PAR_FACTF05 INNER JOIN  " & _
        " dbo.FACTF05 ON dbo.PAR_FACTF05.CVE_DOC = dbo.FACTF05.CVE_DOC INNER JOIN " & _
        " dbo.CLIE05 INNER JOIN " & _
        " dbo.VEND05 ON dbo.CLIE05.CVE_VEND = dbo.VEND05.CVE_VEND ON dbo.FACTF05.CVE_CLPV = dbo.CLIE05.CLAVE INNER JOIN " & _
        " dbo.INVE05 ON dbo.PAR_FACTF05.CVE_ART = dbo.INVE05.CVE_ART  " & _
        " WHERE        (ISNUMERIC(dbo.VEND05.CVE_VEND) = 1) AND (dbo.VEND05.CVE_VEND = @Clave) AND (dbo.INVE05.LIN_PROD = 30) AND (dbo.FACTF05.FECHA_DOC >= @Inicio) AND  " & _
        " (dbo.FACTF05.FECHA_DOC <= @Fin) AND (dbo.FACTF05.NUM_ALMA = 1)  " & _
        " GROUP BY dbo.FACTF05.CVE_CLPV  " & _
        " UNION ALL " & _
        " SELECT        dbo.FACTD05.CVE_CLPV, SUM(dbo.PAR_FACTD05.PREC * dbo.PAR_FACTD05.CANT * - 1) AS Expr1 " & _
        " FROM            dbo.PAR_FACTD05 INNER JOIN  " & _
        " dbo.FACTD05 ON dbo.PAR_FACTD05.CVE_DOC = dbo.FACTD05.CVE_DOC INNER JOIN  " & _
        " dbo.CLIE05 AS CLIE05_1 INNER JOIN " & _
        " dbo.VEND05 AS VEND05_1 ON CLIE05_1.CVE_VEND = VEND05_1.CVE_VEND ON dbo.FACTD05.CVE_CLPV = CLIE05_1.CLAVE INNER JOIN " & _
        " dbo.INVE05 AS INVE05_1 ON dbo.PAR_FACTD05.CVE_ART = INVE05_1.CVE_ART " & _
        " WHERE        (ISNUMERIC(VEND05_1.CVE_VEND) = 1) AND (VEND05_1.CVE_VEND = @Clave) AND (INVE05_1.LIN_PROD = 30) AND (dbo.FACTD05.FECHA_DOC >= @Inicio) AND " & _
        " (dbo.FACTD05.FECHA_DOC <= @Fin) AND (dbo.FACTD05.NUM_ALMA = 1) " & _
        " GROUP BY dbo.FACTD05.CVE_CLPV) AS derivedtbl_1 " & _
        " Group By CVE_CLPV 		 Having sum(Expr1) > 0"
        Dim miComando As New SqlCommand(sSQL, ActualizarConexion)
        miComando.Parameters.AddWithValue("@Inicio", Fecha_Ini)
        miComando.Parameters.AddWithValue("@Fin", Fecha_Fin)
        miComando.Parameters.AddWithValue("@Clave", Clave)
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
            'MsgBox("Hay un problema con la conexión a los datos 3 " & ex.Message, MsgBoxStyle.Critical)
            ActualizarConexion.Close()
        End Try
        Return dv
    End Function

    Public Function VentasXLineaOTROS(ByVal Fecha_Ini As Date, ByVal Fecha_Fin As Date, ByVal Clave As String) As DataView
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim sSQL As String = "SELECT        CVE_CLPV, sum(Expr1) as Suma " & _
        " FROM " & _
        "( " & _
        " SELECT        dbo.FACTF05.CVE_CLPV, SUM(dbo.PAR_FACTF05.PREC * dbo.PAR_FACTF05.CANT) AS Expr1  " & _
        " FROM            dbo.PAR_FACTF05 INNER JOIN  " & _
        " dbo.FACTF05 ON dbo.PAR_FACTF05.CVE_DOC = dbo.FACTF05.CVE_DOC INNER JOIN " & _
        " dbo.CLIE05 INNER JOIN " & _
        " dbo.VEND05 ON dbo.CLIE05.CVE_VEND = dbo.VEND05.CVE_VEND ON dbo.FACTF05.CVE_CLPV = dbo.CLIE05.CLAVE INNER JOIN " & _
        " dbo.INVE05 ON dbo.PAR_FACTF05.CVE_ART = dbo.INVE05.CVE_ART  " & _
        " WHERE        (ISNUMERIC(dbo.VEND05.CVE_VEND) = 1) AND (dbo.VEND05.CVE_VEND = @Clave)   AND (dbo.FACTF05.FECHA_DOC >= @Inicio) AND  " & _
        " (dbo.FACTF05.FECHA_DOC <= @Fin) AND (dbo.FACTF05.NUM_ALMA = 1)  " & _
        " GROUP BY dbo.FACTF05.CVE_CLPV  " & _
        " UNION ALL " & _
        " SELECT        dbo.FACTD05.CVE_CLPV, SUM(dbo.PAR_FACTD05.PREC * dbo.PAR_FACTD05.CANT * - 1) AS Expr1 " & _
        " FROM            dbo.PAR_FACTD05 INNER JOIN  " & _
        " dbo.FACTD05 ON dbo.PAR_FACTD05.CVE_DOC = dbo.FACTD05.CVE_DOC INNER JOIN  " & _
        " dbo.CLIE05 AS CLIE05_1 INNER JOIN " & _
        " dbo.VEND05 AS VEND05_1 ON CLIE05_1.CVE_VEND = VEND05_1.CVE_VEND ON dbo.FACTD05.CVE_CLPV = CLIE05_1.CLAVE INNER JOIN " & _
        " dbo.INVE05 AS INVE05_1 ON dbo.PAR_FACTD05.CVE_ART = INVE05_1.CVE_ART " & _
        " WHERE        (ISNUMERIC(VEND05_1.CVE_VEND) = 1) AND (VEND05_1.CVE_VEND = @Clave)   AND (dbo.FACTD05.FECHA_DOC >= @Inicio) AND " & _
        " (dbo.FACTD05.FECHA_DOC <= @Fin) AND (dbo.FACTD05.NUM_ALMA = 1) " & _
        " GROUP BY dbo.FACTD05.CVE_CLPV) AS derivedtbl_1 " & _
        " Group By CVE_CLPV 		 Having sum(Expr1) > 0"
        Dim miComando As New SqlCommand(sSQL, ActualizarConexion)
        miComando.Parameters.AddWithValue("@Inicio", Fecha_Ini)
        miComando.Parameters.AddWithValue("@Fin", Fecha_Fin)
        miComando.Parameters.AddWithValue("@Clave", Clave)
        ActualizarConexion.Open()
        Dim AdaptadorDeDatos As New SqlDataAdapter(miComando)
        Dim ds As New DataSet
        Dim dv As DataView = Nothing
        Try
            AdaptadorDeDatos.Fill(ds, "PAR_FACTF05")
            If ds.Tables("PAR_FACTF05").Rows.Count > 0 Then
                dv = New DataView(ds.Tables("PAR_FACTF05"))
            End If
            ActualizarConexion.Close()
        Catch ex As SqlException
            MsgBox("Hay un problema con la conexión a los datos 4 " & ex.Message, MsgBoxStyle.Critical)
            ActualizarConexion.Close()
        End Try
        Return dv
    End Function
End Class

