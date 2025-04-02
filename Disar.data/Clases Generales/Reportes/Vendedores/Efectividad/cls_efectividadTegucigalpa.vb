Imports System.Data.SqlClient
Public Class cls_efectividadTegucigalpa
    Dim Conexion As New clsconexion_consumo

    Public Function Efectivos(ByVal Fecha As Date, ByVal Clave As Integer) As DataView
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim sSQL As String = "SELECT  DISTINCT FACTF05.CVE_CLPV, FACTF05.FECHA_DOC " & _
                             "FROM dbo.FACTF05 " & _
                             "WHERE (FECHA_DOC = @Fecha) and (CVE_VEND=@Clave) and NUM_ALMA =4"
        Dim miComando As New SqlCommand(sSQL, ActualizarConexion)
        miComando.Parameters.AddWithValue("@Fecha", Fecha)
        miComando.Parameters.AddWithValue("@Clave", Clave)
        ActualizarConexion.Open()

        Dim AdaptadorDeDatos As New SqlDataAdapter(miComando)
        Dim ds As New DataSet
        Dim dv As DataView = Nothing

        Try
            AdaptadorDeDatos.Fill(ds, "FACTF05")
            If ds.Tables("FACTF05").Rows.Count > 0 Then
                dv = New DataView(ds.Tables("FACTF05"))
            End If
            ActualizarConexion.Close()
        Catch ex As SqlException
            MsgBox("Hay un problema con la conexión a los datos 1" & ex.Message, MsgBoxStyle.Critical)
            ActualizarConexion.Close()
        End Try
        Return dv
    End Function

    Public Function EfectivosMenores30(ByVal Fecha As Date, ByVal Clave As Integer) As DataView
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim sSQL As String = "SELECT  DISTINCT FACTF05.CVE_CLPV, FACTF05.FECHA_DOC " & _
                             "FROM dbo.FACTF05 " & _
                             "WHERE (FECHA_DOC = @Fecha) and (CVE_VEND=@Clave) and NUM_ALMA =4 AND IMPORTE < 30000"
        Dim miComando As New SqlCommand(sSQL, ActualizarConexion)
        miComando.Parameters.AddWithValue("@Fecha", Fecha)
        miComando.Parameters.AddWithValue("@Clave", Clave)
        ActualizarConexion.Open()

        Dim AdaptadorDeDatos As New SqlDataAdapter(miComando)
        Dim ds As New DataSet
        Dim dv As DataView = Nothing

        Try
            AdaptadorDeDatos.Fill(ds, "FACTF05")
            If ds.Tables("FACTF05").Rows.Count > 0 Then
                dv = New DataView(ds.Tables("FACTF05"))
            End If
            ActualizarConexion.Close()
        Catch ex As SqlException
            MsgBox("Hay un problema con la conexión a los datos 1" & ex.Message, MsgBoxStyle.Critical)
            ActualizarConexion.Close()
        End Try
        Return dv
    End Function

    Public Function Visitados(ByVal Vendedor As Integer, ByVal Dia As String) As DataView
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim sSQL As String = "SELECT count(dbo.CLIE05.CLAVE) FROM dbo.CLIE05 INNER JOIN dbo.VEND05 ON dbo.CLIE05.CVE_VEND = dbo.VEND05.CVE_VEND LEFT OUTER JOIN dbo.CLIE_CLIB05 ON dbo.CLIE05.CLAVE = dbo.CLIE_CLIB05.CVE_CLIE WHERE (dbo.CLIE05.CVE_VEND =@Vendedor) and (dbo.CLIE_CLIB05.CAMPLIB3 = @Dia OR dbo.CLIE_CLIB05.CAMPLIB3 = SUBSTRING(@Dia, 1, LEN(@Dia) - 2))  and  (dbo.CLIE05.STATUS <> 'S') "
        Dim miComando As New SqlCommand(sSQL, ActualizarConexion)
        miComando.Parameters.AddWithValue("@Vendedor", Vendedor)
        miComando.Parameters.AddWithValue("@Dia", Dia)
        ActualizarConexion.Open()

        Dim AdaptadorDeDatos As New SqlDataAdapter(miComando)
        Dim ds As New DataSet
        Dim dv As DataView = Nothing

        Try
            AdaptadorDeDatos.Fill(ds, "dbo.CLIE05")
            If ds.Tables("dbo.CLIE05").Rows.Count > 0 Then
                dv = New DataView(ds.Tables("dbo.CLIE05"))

            End If
            ActualizarConexion.Close()
        Catch ex As SqlException
            MsgBox("Hay un problema con la conexión a los datos 2" & ex.Message, MsgBoxStyle.Critical)
            ActualizarConexion.Close()
        End Try
        Return dv
    End Function

    Public Function EfectivosRangoFechas(ByVal Fecha As Date, ByVal Fecha2 As Date, ByVal Clave As Integer) As DataView
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim sSQL As String = "SELECT DISTINCT TOP (100) PERCENT CVE_CLPV, FECHA_DOC  " & _
                             "FROM dbo.FACTF05 " & _
                             "WHERE (FECHA_DOC >= @Fecha) AND (CVE_VEND=@Clave) AND (FECHA_DOC <= @Fecha2) and NUM_ALMA =4"
        Dim miComando As New SqlCommand(sSQL, ActualizarConexion)
        miComando.Parameters.AddWithValue("@Fecha", Fecha)
        miComando.Parameters.AddWithValue("@Fecha2", Fecha2)
        miComando.Parameters.AddWithValue("@Clave", Clave)
        ActualizarConexion.Open()

        Dim AdaptadorDeDatos As New SqlDataAdapter(miComando)
        Dim ds As New DataSet
        Dim dv As DataView = Nothing

        Try
            AdaptadorDeDatos.Fill(ds, "FACTF05")
            If ds.Tables("FACTF05").Rows.Count > 0 Then
                dv = New DataView(ds.Tables("FACTF05"))
            End If
            ActualizarConexion.Close()
        Catch ex As SqlException
            MsgBox("Hay un problema con la conexión a los datos 3" & ex.Message, MsgBoxStyle.Critical)
            ActualizarConexion.Close()
        End Try
        Return dv
    End Function

    Public Function EfectivosRangoFechasMenores30(ByVal Fecha As Date, ByVal Fecha2 As Date, ByVal Clave As Integer) As DataView
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim sSQL As String = "SELECT DISTINCT TOP (100) PERCENT CVE_CLPV, FECHA_DOC  " & _
                             "FROM dbo.FACTF05 " & _
                             "WHERE (FECHA_DOC >= @Fecha) AND (CVE_VEND=@Clave) AND (FECHA_DOC <= @Fecha2) and NUM_ALMA =4 AND IMPORTE < 30000"
        Dim miComando As New SqlCommand(sSQL, ActualizarConexion)
        miComando.Parameters.AddWithValue("@Fecha", Fecha)
        miComando.Parameters.AddWithValue("@Fecha2", Fecha2)
        miComando.Parameters.AddWithValue("@Clave", Clave)
        ActualizarConexion.Open()

        Dim AdaptadorDeDatos As New SqlDataAdapter(miComando)
        Dim ds As New DataSet
        Dim dv As DataView = Nothing

        Try
            AdaptadorDeDatos.Fill(ds, "FACTF05")
            If ds.Tables("FACTF05").Rows.Count > 0 Then
                dv = New DataView(ds.Tables("FACTF05"))
            End If
            ActualizarConexion.Close()
        Catch ex As SqlException
            MsgBox("Hay un problema con la conexión a los datos 3" & ex.Message, MsgBoxStyle.Critical)
            ActualizarConexion.Close()
        End Try
        Return dv
    End Function

    Public Function VisitadosRangoFechas(ByVal Vendedor As Integer, ByVal Dia As String, ByVal Dia2 As String, ByVal Dia3 As String) As DataView
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim sSQL As String = "SELECT count(dbo.CLIE05.CLAVE) FROM dbo.CLIE05 INNER JOIN dbo.VEND05 " & _
                    "ON dbo.CLIE05.CVE_VEND = dbo.VEND05.CVE_VEND LEFT OUTER JOIN dbo.CLIE_CLIB05 " & _
                    "ON dbo.CLIE05.CLAVE = dbo.CLIE_CLIB05.CVE_CLIE WHERE (dbo.CLIE05.CVE_VEND =@Vendedor) and " & _
                    "((dbo.CLIE_CLIB05.CAMPLIB3 = @Dia) or (dbo.CLIE_CLIB05.CAMPLIB3 = @Dia2) or (dbo.CLIE_CLIB05.CAMPLIB3 = @Dia3))  and  (dbo.CLIE05.STATUS <> 'S') "
        Dim miComando As New SqlCommand(sSQL, ActualizarConexion)
        miComando.Parameters.AddWithValue("@Vendedor", Vendedor)
        miComando.Parameters.AddWithValue("@Dia", Dia)
        miComando.Parameters.AddWithValue("@Dia2", Dia2)
        miComando.Parameters.AddWithValue("@Dia3", Dia3)
        ActualizarConexion.Open()

        Dim AdaptadorDeDatos As New SqlDataAdapter(miComando)
        Dim ds As New DataSet
        Dim dv As DataView = Nothing

        Try
            AdaptadorDeDatos.Fill(ds, "dbo.CLIE05")
            If ds.Tables("dbo.CLIE05").Rows.Count > 0 Then
                dv = New DataView(ds.Tables("dbo.CLIE05"))

            End If
            ActualizarConexion.Close()
        Catch ex As SqlException
            MsgBox("Hay un problema con la conexión a los datos 4" & ex.Message, MsgBoxStyle.Critical)
            ActualizarConexion.Close()
        End Try
        Return dv
    End Function

    Public Function NotasCDiarias(ByVal Fecha As Date, ByVal Clave As Integer)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim sSQL As String = "Select DISTINCT(dbo.FACTD05.CVE_CLPV) " & _
                            "FROM  dbo.PAR_FACTD05 LEFT OUTER JOIN " & _
                            "dbo.INVE05 ON dbo.PAR_FACTD05.CVE_ART = dbo.INVE05.CVE_ART INNER JOIN " & _
                            "dbo.FACTD05 ON dbo.PAR_FACTD05.CVE_DOC = dbo.FACTD05.CVE_DOC LEFT OUTER JOIN " & _
                            "dbo.VEND05 ON dbo.FACTD05.CVE_VEND = dbo.VEND05.CVE_VEND LEFT OUTER JOIN " & _
                            "dbo.CLIE05 ON dbo.FACTD05.CVE_CLPV = dbo.CLIE05.CLAVE " & _
                            " WHERE (dbo.FACTD05.FECHA_DOC = @Fecha) AND (dbo.FACTD05.CVE_VEND = @Clave) AND " & _
                            "(dbo.FACTD05.SERIE = 'N') AND (dbo.FACTD05.STATUS <>'C') AND (dbo.FACTD05.FECHA_ENT < dbo.FACTD05.FECHA_DOC) and NUM_ALMA=4"
        Dim miComando As New SqlCommand(sSQL, ActualizarConexion)
        miComando.Parameters.AddWithValue("@Fecha", Fecha.Date)
        miComando.Parameters.AddWithValue("@Clave", Clave)
        ActualizarConexion.Open()

        Dim AdaptadorDeDatos As New SqlDataAdapter(miComando)
        Dim ds As New DataSet
        Dim dv As DataView = Nothing

        Try
            AdaptadorDeDatos.Fill(ds, "FACTD05")
            If ds.Tables("FACTD05").Rows.Count > 0 Then
                dv = New DataView(ds.Tables("FACTD05"))
            End If
            ActualizarConexion.Close()
        Catch ex As SqlException
            MsgBox("Hay un problema con la conexión a los datos 5" & ex.Message, MsgBoxStyle.Critical)
            ActualizarConexion.Close()
        End Try
        Return dv
    End Function

    Public Function NotasCredito(ByVal Fecha As Date, ByVal Fecha2 As Date, ByVal Clave As Integer) As DataView
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim sSQL As String = "Select DISTINCT(dbo.FACTD05.CVE_CLPV) " & _
        "FROM  dbo.PAR_FACTD05 LEFT OUTER JOIN " & _
        "dbo.INVE05 ON dbo.PAR_FACTD05.CVE_ART = dbo.INVE05.CVE_ART INNER JOIN " & _
        "dbo.FACTD05 ON dbo.PAR_FACTD05.CVE_DOC = dbo.FACTD05.CVE_DOC LEFT OUTER JOIN " & _
        "dbo.VEND05 ON dbo.FACTD05.CVE_VEND = dbo.VEND05.CVE_VEND LEFT OUTER JOIN " & _
        "dbo.CLIE05 ON dbo.FACTD05.CVE_CLPV = dbo.CLIE05.CLAVE " & _
        " WHERE (dbo.FACTD05.FECHA_DOC >= @Fecha) AND (dbo.FACTD05.CVE_VEND = @Clave) AND " & _
        "(dbo.FACTD05.FECHA_DOC <= @Fecha2) AND (dbo.FACTD05.SERIE = 'N') AND (dbo.FACTD05.STATUS <>'C') AND (dbo.FACTD05.FECHA_ENT < dbo.FACTD05.FECHA_DOC) and NUM_ALMA=4"

        Dim miComando As New SqlCommand(sSQL, ActualizarConexion)
        miComando.Parameters.AddWithValue("@Fecha", Fecha.Date)
        miComando.Parameters.AddWithValue("@Fecha2", Fecha2.Date)
        miComando.Parameters.AddWithValue("@Clave", Clave)
        ActualizarConexion.Open()
        Dim AdaptadorDeDatos As New SqlDataAdapter(miComando)
        Dim ds As New DataSet
        Dim dv As DataView = Nothing
        Try
            AdaptadorDeDatos.Fill(ds, "dbo.PAR_FACTD05")
            If ds.Tables("dbo.PAR_FACTD05").Rows.Count > 0 Then
                dv = New DataView(ds.Tables("dbo.PAR_FACTD05"))
            End If
            ActualizarConexion.Close()
        Catch ex As SqlException
            MsgBox("Hay un problema con la conexión a los datos 4 " & ex.Message, MsgBoxStyle.Critical)
            ActualizarConexion.Close()
        End Try
        Return dv
    End Function
End Class
