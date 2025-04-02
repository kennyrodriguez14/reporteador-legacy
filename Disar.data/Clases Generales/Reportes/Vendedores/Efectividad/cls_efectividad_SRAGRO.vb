Imports System.Data.SqlClient
Public Class cls_efectividad_SRAGRO
    Dim Conexion As New clsconexion_sr_agro

    Public Function Efectivos(ByVal Fecha As Date, ByVal Clave As Integer) As DataView
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim sSQL As String = "SELECT  DISTINCT FACTF02.CVE_CLPV, FACTF02.FECHA_DOC " & _
                             "FROM dbo.FACTF02 " & _
                             "WHERE (FECHA_DOC = @Fecha) and (CVE_VEND=@Clave) "
        Dim miComando As New SqlCommand(sSQL, ActualizarConexion)
        miComando.Parameters.AddWithValue("@Fecha", Fecha)
        miComando.Parameters.AddWithValue("@Clave", Clave)
        ActualizarConexion.Open()

        Dim AdaptadorDeDatos As New SqlDataAdapter(miComando)
        Dim ds As New DataSet
        Dim dv As DataView = Nothing

        Try
            AdaptadorDeDatos.Fill(ds, "FACTF02")
            If ds.Tables("FACTF02").Rows.Count > 0 Then
                dv = New DataView(ds.Tables("FACTF02"))
            End If
            ActualizarConexion.Close()
        Catch ex As SqlException
            MsgBox("Hay un problema con la conexión a los datos 2" & ex.Message, MsgBoxStyle.Critical)
            ActualizarConexion.Close()
        End Try
        Return dv
    End Function

    Public Function EfectivosMenores30(ByVal Fecha As Date, ByVal Clave As Integer) As DataView
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim sSQL As String = "SELECT  DISTINCT FACTF02.CVE_CLPV, FACTF02.FECHA_DOC " & _
                             "FROM dbo.FACTF02 " & _
                             "WHERE (FECHA_DOC = @Fecha) and (CVE_VEND=@Clave)  AND (IMPORTE < 30000)"
        Dim miComando As New SqlCommand(sSQL, ActualizarConexion)
        miComando.Parameters.AddWithValue("@Fecha", Fecha)
        miComando.Parameters.AddWithValue("@Clave", Clave)
        ActualizarConexion.Open()

        Dim AdaptadorDeDatos As New SqlDataAdapter(miComando)
        Dim ds As New DataSet
        Dim dv As DataView = Nothing

        Try
            AdaptadorDeDatos.Fill(ds, "FACTF02")
            If ds.Tables("FACTF02").Rows.Count > 0 Then
                dv = New DataView(ds.Tables("FACTF02"))
            End If
            ActualizarConexion.Close()
        Catch ex As SqlException
            MsgBox("Hay un problema con la conexión a los datos 2" & ex.Message, MsgBoxStyle.Critical)
            ActualizarConexion.Close()
        End Try
        Return dv
    End Function

    Public Function Visitados(ByVal Vendedor As Integer, ByVal Dia As String) As DataView
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim sSQL As String = "SELECT count(dbo.CLIE02.CLAVE) FROM dbo.CLIE02 INNER JOIN dbo.VEND02 " & _
        "ON dbo.CLIE02.CVE_VEND = dbo.VEND02.CVE_VEND LEFT OUTER JOIN dbo.CLIE_CLIB02 ON " & _
        "dbo.CLIE02.CLAVE = dbo.CLIE_CLIB02.CVE_CLIE WHERE (dbo.CLIE02.CVE_VEND =@Vendedor) and " & _
        "(dbo.CLIE_CLIB02.CAMPLIB3 = @Dia) and  (dbo.CLIE02.STATUS <> 'S') "
        Dim miComando As New SqlCommand(sSQL, ActualizarConexion)
        miComando.Parameters.AddWithValue("@Vendedor", Vendedor)
        miComando.Parameters.AddWithValue("@Dia", Dia)
        ActualizarConexion.Open()

        Dim AdaptadorDeDatos As New SqlDataAdapter(miComando)
        Dim ds As New DataSet
        Dim dv As DataView = Nothing

        Try
            AdaptadorDeDatos.Fill(ds, "dbo.CLIE02")
            If ds.Tables("dbo.CLIE02").Rows.Count > 0 Then
                dv = New DataView(ds.Tables("dbo.CLIE02"))

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
        Dim sSQL As String = "SELECT DISTINCT TOP (100) PERCENT CVE_CLPV, FECHA_DOC " & _
                             "FROM dbo.FACTF02 " & _
                             "WHERE (FECHA_DOC >= @Fecha) AND (CVE_VEND=@Clave) AND (FECHA_DOC <= @Fecha2) "
        Dim miComando As New SqlCommand(sSQL, ActualizarConexion)
        miComando.Parameters.AddWithValue("@Fecha", Fecha)
        miComando.Parameters.AddWithValue("@Fecha2", Fecha2)
        miComando.Parameters.AddWithValue("@Clave", Clave)
        ActualizarConexion.Open()

        Dim AdaptadorDeDatos As New SqlDataAdapter(miComando)
        Dim ds As New DataSet
        Dim dv As DataView = Nothing

        Try
            AdaptadorDeDatos.Fill(ds, "FACTF02")
            If ds.Tables("FACTF02").Rows.Count > 0 Then
                dv = New DataView(ds.Tables("FACTF02"))
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
        Dim sSQL As String = "SELECT DISTINCT TOP (100) PERCENT CVE_CLPV, FECHA_DOC " & _
                             "FROM dbo.FACTF02 " & _
                             "WHERE (FECHA_DOC >= @Fecha) AND (CVE_VEND=@Clave) AND (FECHA_DOC <= @Fecha2) AND (IMPORTE < 30000)"
        Dim miComando As New SqlCommand(sSQL, ActualizarConexion)
        miComando.Parameters.AddWithValue("@Fecha", Fecha)
        miComando.Parameters.AddWithValue("@Fecha2", Fecha2)
        miComando.Parameters.AddWithValue("@Clave", Clave)
        ActualizarConexion.Open()

        Dim AdaptadorDeDatos As New SqlDataAdapter(miComando)
        Dim ds As New DataSet
        Dim dv As DataView = Nothing

        Try
            AdaptadorDeDatos.Fill(ds, "FACTF02")
            If ds.Tables("FACTF02").Rows.Count > 0 Then
                dv = New DataView(ds.Tables("FACTF02"))
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
        Dim sSQL As String = "SELECT count(dbo.CLIE02.CLAVE) FROM dbo.CLIE02 INNER JOIN dbo.VEND02 ON " & _
            "dbo.CLIE02.CVE_VEND = dbo.VEND02.CVE_VEND LEFT OUTER JOIN dbo.CLIE_CLIB02 ON dbo.CLIE02.CLAVE =  " & _
            "dbo.CLIE_CLIB02.CVE_CLIE WHERE (dbo.CLIE02.CVE_VEND =@Vendedor) and " & _
            "((dbo.CLIE_CLIB02.CAMPLIB3 = @Dia) or (dbo.CLIE_CLIB02.CAMPLIB3 = @Dia2) or (dbo.CLIE_CLIB02.CAMPLIB3 = @Dia3)) " & _
            " and  (dbo.CLIE02.STATUS <> 'S') "
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
            AdaptadorDeDatos.Fill(ds, "dbo.CLIE02")
            If ds.Tables("dbo.CLIE02").Rows.Count > 0 Then
                dv = New DataView(ds.Tables("dbo.CLIE02"))

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
        Dim sSQL As String = "Select DISTINCT(dbo.FACTD02.CVE_CLPV) " & _
                            "FROM  dbo.PAR_FACTD02 LEFT OUTER JOIN " & _
                            "dbo.INVE02 ON dbo.PAR_FACTD02.CVE_ART = dbo.INVE02.CVE_ART INNER JOIN " & _
                            "dbo.FACTD02 ON dbo.PAR_FACTD02.CVE_DOC = dbo.FACTD02.CVE_DOC LEFT OUTER JOIN " & _
                            "dbo.VEND02 ON dbo.FACTD02.CVE_VEND = dbo.VEND02.CVE_VEND LEFT OUTER JOIN " & _
                            "dbo.CLIE02 ON dbo.FACTD02.CVE_CLPV = dbo.CLIE02.CLAVE " & _
                            " WHERE (dbo.FACTD02.FECHA_DOC = @Fecha) AND (dbo.FACTD02.CVE_VEND = @Clave) AND " & _
                            "(dbo.FACTD02.SERIE = 'N') AND (dbo.FACTD02.STATUS <>'C') AND (dbo.FACTD02.FECHA_ENT < dbo.FACTD02.FECHA_DOC) "
        Dim miComando As New SqlCommand(sSQL, ActualizarConexion)
        miComando.Parameters.AddWithValue("@Fecha", Fecha.Date)
        miComando.Parameters.AddWithValue("@Clave", Clave)
        ActualizarConexion.Open()

        Dim AdaptadorDeDatos As New SqlDataAdapter(miComando)
        Dim ds As New DataSet
        Dim dv As DataView = Nothing

        Try
            AdaptadorDeDatos.Fill(ds, "FACTD02")
            If ds.Tables("FACTD02").Rows.Count > 0 Then
                dv = New DataView(ds.Tables("FACTD02"))
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
        Dim sSQL As String = "Select DISTINCT(dbo.FACTD02.CVE_CLPV) " & _
        "FROM  dbo.PAR_FACTD02 LEFT OUTER JOIN " & _
        "dbo.INVE02 ON dbo.PAR_FACTD02.CVE_ART = dbo.INVE02.CVE_ART INNER JOIN " & _
        "dbo.FACTD02 ON dbo.PAR_FACTD02.CVE_DOC = dbo.FACTD02.CVE_DOC LEFT OUTER JOIN " & _
        "dbo.VEND02 ON dbo.FACTD02.CVE_VEND = dbo.VEND02.CVE_VEND LEFT OUTER JOIN " & _
        "dbo.CLIE02 ON dbo.FACTD02.CVE_CLPV = dbo.CLIE02.CLAVE " & _
        " WHERE (dbo.FACTD02.FECHA_DOC >= @Fecha) AND (dbo.FACTD02.CVE_VEND = @Clave) AND " & _
        "(dbo.FACTD02.FECHA_DOC <= @Fecha2) AND (dbo.FACTD02.SERIE = 'N') AND (dbo.FACTD02.STATUS <>'C') " & _
        " AND (dbo.FACTD02.FECHA_ENT < dbo.FACTD02.FECHA_DOC) "

        Dim miComando As New SqlCommand(sSQL, ActualizarConexion)
        miComando.Parameters.AddWithValue("@Fecha", Fecha.Date)
        miComando.Parameters.AddWithValue("@Fecha2", Fecha2.Date)
        miComando.Parameters.AddWithValue("@Clave", Clave)
        ActualizarConexion.Open()
        Dim AdaptadorDeDatos As New SqlDataAdapter(miComando)
        Dim ds As New DataSet
        Dim dv As DataView = Nothing
        Try
            AdaptadorDeDatos.Fill(ds, "dbo.PAR_FACTD02")
            If ds.Tables("dbo.PAR_FACTD02").Rows.Count > 0 Then
                dv = New DataView(ds.Tables("dbo.PAR_FACTD02"))
            End If
            ActualizarConexion.Close()
        Catch ex As SqlException
            MsgBox("Hay un problema con la conexión a los datos 6" & ex.Message, MsgBoxStyle.Critical)
            ActualizarConexion.Close()
        End Try
        Return dv
    End Function

    Public Function NotasCreditoGeneral(ByVal Fecha As Date, ByVal Fecha2 As Date, ByVal Clave As Integer) As DataView
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim sSQL As String = "Select DISTINCT(dbo.FACTD02.CVE_CLPV) " & _
        "FROM  dbo.PAR_FACTD02 LEFT OUTER JOIN " & _
        "dbo.INVE02 ON dbo.PAR_FACTD02.CVE_ART = dbo.INVE02.CVE_ART INNER JOIN " & _
        "dbo.FACTD02 ON dbo.PAR_FACTD02.CVE_DOC = dbo.FACTD02.CVE_DOC LEFT OUTER JOIN " & _
        "dbo.VEND02 ON dbo.FACTD02.CVE_VEND = dbo.VEND02.CVE_VEND LEFT OUTER JOIN " & _
        "dbo.CLIE02 ON dbo.FACTD02.CVE_CLPV = dbo.CLIE02.CLAVE " & _
        " WHERE (dbo.FACTD02.FECHA_DOC >= @Fecha) AND (dbo.FACTD02.CVE_VEND = @Clave) AND " & _
        "(dbo.FACTD02.FECHA_DOC <= @Fecha2) AND (dbo.FACTD02.SERIE = 'N') AND (dbo.FACTD02.STATUS <>'C') AND (dbo.FACTD02.FECHA_ENT < dbo.FACTD02.FECHA_DOC)"

        Dim miComando As New SqlCommand(sSQL, ActualizarConexion)
        miComando.Parameters.AddWithValue("@Fecha", Fecha.Date)
        miComando.Parameters.AddWithValue("@Fecha2", Fecha2.Date)
        miComando.Parameters.AddWithValue("@Clave", Clave)
        ActualizarConexion.Open()
        Dim AdaptadorDeDatos As New SqlDataAdapter(miComando)
        Dim ds As New DataSet
        Dim dv As DataView = Nothing
        Try
            AdaptadorDeDatos.Fill(ds, "dbo.PAR_FACTD02")
            If ds.Tables("dbo.PAR_FACTD02").Rows.Count > 0 Then
                dv = New DataView(ds.Tables("dbo.PAR_FACTD02"))
            End If
            ActualizarConexion.Close()
        Catch ex As SqlException
            MsgBox("Hay un problema con la conexión a los datos 6" & ex.Message, MsgBoxStyle.Critical)
            ActualizarConexion.Close()
        End Try
        Return dv
    End Function

    Public Function EfectivosGeneral(ByVal Fecha As Date, ByVal Clave As Integer) As DataView
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim sSQL As String = "SELECT  DISTINCT FACTF02.CVE_CLPV, FACTF02.FECHA_DOC " & _
                             "FROM dbo.FACTF02 " & _
                             "WHERE (FECHA_DOC = @Fecha) and (CVE_VEND=@Clave)"
        Dim miComando As New SqlCommand(sSQL, ActualizarConexion)
        miComando.Parameters.AddWithValue("@Fecha", Fecha)
        miComando.Parameters.AddWithValue("@Clave", Clave)
        ActualizarConexion.Open()

        Dim AdaptadorDeDatos As New SqlDataAdapter(miComando)
        Dim ds As New DataSet
        Dim dv As DataView = Nothing

        Try
            AdaptadorDeDatos.Fill(ds, "FACTF02")
            If ds.Tables("FACTF02").Rows.Count > 0 Then
                dv = New DataView(ds.Tables("FACTF02"))
            End If
            ActualizarConexion.Close()
        Catch ex As SqlException
            MsgBox("Hay un problema con la conexión a los datos 2" & ex.Message, MsgBoxStyle.Critical)
            ActualizarConexion.Close()
        End Try
        Return dv
    End Function

    Public Function EfectivosRangoFechasGeneral(ByVal Fecha As Date, ByVal Fecha2 As Date, ByVal Clave As Integer) As DataView
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim sSQL As String = "SELECT DISTINCT TOP (100) PERCENT CVE_CLPV, FECHA_DOC " & _
                             "FROM dbo.FACTF02 " & _
                             "WHERE (FECHA_DOC >= @Fecha) AND (CVE_VEND=@Clave) AND (FECHA_DOC <= @Fecha2) "
        Dim miComando As New SqlCommand(sSQL, ActualizarConexion)
        miComando.Parameters.AddWithValue("@Fecha", Fecha)
        miComando.Parameters.AddWithValue("@Fecha2", Fecha2)
        miComando.Parameters.AddWithValue("@Clave", Clave)
        ActualizarConexion.Open()

        Dim AdaptadorDeDatos As New SqlDataAdapter(miComando)
        Dim ds As New DataSet
        Dim dv As DataView = Nothing

        Try
            AdaptadorDeDatos.Fill(ds, "FACTF02")
            If ds.Tables("FACTF02").Rows.Count > 0 Then
                dv = New DataView(ds.Tables("FACTF02"))
            End If
            ActualizarConexion.Close()
        Catch ex As SqlException
            MsgBox("Hay un problema con la conexión a los datos 3" & ex.Message, MsgBoxStyle.Critical)
            ActualizarConexion.Close()
        End Try
        Return dv
    End Function
End Class
