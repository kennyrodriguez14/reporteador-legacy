Imports System.Data.SqlClient

Public Class cls_reportes_varios
    Dim Conexion As New clsconexion_consumo
    Dim ConexionDimosa As New cls_conexion_DIMOSA
    Dim Conexion2 As New clsconexion_sr_agro
    Dim ConexionOPL As New cls_conexionOPL

    Public Function Reporte80_20(ByVal DESDE As Date, ByVal HASTA As Date, ByVal SUCURSAL As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_reportes_varios", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@AÑO_INI", SqlDbType.Date)).Value = DESDE
        miComando.Parameters.Add(New SqlParameter("@AÑO_FIN", SqlDbType.Date)).Value = HASTA
        miComando.Parameters.Add(New SqlParameter("@SUCURSAL", SqlDbType.VarChar)).Value = SUCURSAL
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

    Public Function ReporteFacturas(ByVal DESDE As Date, ByVal HASTA As Date, ByVal Tipo As String, ByVal DesdeString As String, ByVal HastaString As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim miComando As New SqlCommand
        If Tipo = "Fechas" Then
            miComando = New SqlCommand("SELECT        CVE_DOC AS Documento, CVE_CLPV AS Cliente, CASE ENLAZADO WHEN 'O' THEN 'Original' WHEN 'T' THEN 'Devuelta' WHEN 'P' THEN 'Dev. Parcial' END AS Estatus, CONVERT(varchar(20), FECHA_DOC, 103)  " & _
                                        " AS Fecha, CAN_TOT AS 'Importe', DES_TOT AS Descuento, IMP_TOT4 AS Impuesto, ROUND(IMPORTE, 2) AS Total " & _
                                        " FROM            dbo.FACTF02 WHERE        (FECHA_DOC >= @DESDE) AND (FECHA_DOC <= @HASTA) " & _
                                        "         union all" & _
                                        " SELECT 'TOTALES' AS DOCUMENTO, '' AS CLIENTE, '' AS ESTATUS, '' AS FECHA, round(SUM(CAN_TOT),2) AS 'Importe', round(SUM(DES_TOT),2) AS Descuento, round(SUM(IMP_TOT4),2) AS Impuesto, round(SUM(ROUND(IMPORTE, 2)),2) AS Total " & _
                                        " FROM            dbo.FACTF02 WHERE        (FECHA_DOC >= @DESDE) AND (FECHA_DOC <= @HASTA)  ", ActualizarConexion)

            miComando.Parameters.Add(New SqlParameter("@DESDE", SqlDbType.Date)).Value = DESDE
            miComando.Parameters.Add(New SqlParameter("@HASTA", SqlDbType.Date)).Value = HASTA
        Else
            miComando = New SqlCommand("SELECT        CVE_DOC AS Documento, CVE_CLPV AS Cliente, CASE ENLAZADO WHEN 'O' THEN 'Original' WHEN 'T' THEN 'Devuelta' WHEN 'P' THEN 'Dev. Parcial' END AS Estatus, CONVERT(varchar(20), FECHA_DOC, 103)  " & _
                                        " AS Fecha, CAN_TOT AS 'Importe', DES_TOT AS Descuento, IMP_TOT4 AS Impuesto, ROUND(IMPORTE, 2) AS Total " & _
                                        " FROM            dbo.FACTF02 WHERE        (CVE_DOC >= @DESDET) AND (CVE_DOC <= @DESDET) " & _
                                        "         union all" & _
                                        " SELECT 'TOTALES' AS DOCUMENTO, '' AS CLIENTE, '' AS ESTATUS, '' AS FECHA, round(SUM(CAN_TOT),2) AS 'Importe', round(SUM(DES_TOT),2) AS Descuento, round(SUM(IMP_TOT4),2) AS Impuesto, round(SUM(ROUND(IMPORTE, 2)),2) AS Total " & _
                                        " FROM            dbo.FACTF02 WHERE        (CVE_DOC >= @DESDET) AND (CVE_DOC <= @HASTAT)  ", ActualizarConexion)

            miComando.Parameters.Add(New SqlParameter("@DESDET", SqlDbType.VarChar)).Value = DesdeString
            miComando.Parameters.Add(New SqlParameter("@HASTAT", SqlDbType.VarChar)).Value = HastaString
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

    Public Function VentaPromedio(ByVal DESDE As Date, ByVal HASTA As Date, ByVal SUCURSAL As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_reportes_varios", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@AÑO_INI", SqlDbType.Date)).Value = DESDE
        miComando.Parameters.Add(New SqlParameter("@AÑO_FIN", SqlDbType.Date)).Value = HASTA
        miComando.Parameters.Add(New SqlParameter("@SUCURSAL", SqlDbType.VarChar)).Value = SUCURSAL
        miComando.CommandTimeout = 2000
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

    Public Function Quintales_Agro(ByVal DESDE As Date, ByVal HASTA As Date, ByVal SUCURSAL As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_reportes_varios", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@AÑO_INI", SqlDbType.Date)).Value = DESDE
        miComando.Parameters.Add(New SqlParameter("@AÑO_FIN", SqlDbType.Date)).Value = HASTA
        miComando.Parameters.Add(New SqlParameter("@SUCURSAL", SqlDbType.VarChar)).Value = SUCURSAL
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

    Public Function lista_de_sucursal() As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT -1 AS ID, 'TODAS' AS DES UNION ALL SELECT CVE_ALM,DESCR FROM ALMACENES05 ", ActualizarConexion)
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

    Public Function lista_de_sucursal_DIMOSA() As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionDimosa.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT -1 AS ID, 'TODAS' AS DES UNION ALL SELECT CVE_ALM,DESCR FROM ALMACENES06 ", ActualizarConexion)
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

    Public Function lista_de_sucursal_OPL() As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionDimosa.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT -1 AS ID, 'TODAS' AS DES UNION ALL SELECT CVE_ALM,DESCR FROM SAE60EMPRE08.dbo.ALMACENES08 ", ActualizarConexion)
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

    Public Function Devoluciones(ByVal DESDE As Date, ByVal HASTA As Date, ByVal SUCURSAL As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_devoluciones", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@AÑO_INI", SqlDbType.Date)).Value = DESDE
        miComando.Parameters.Add(New SqlParameter("@AÑO_FIN", SqlDbType.Date)).Value = HASTA
        miComando.Parameters.Add(New SqlParameter("@SUCURSAL", SqlDbType.VarChar)).Value = SUCURSAL
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

    Public Function Devoluciones_dimosa(ByVal DESDE As Date, ByVal HASTA As Date, ByVal SUCURSAL As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionDimosa.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_devoluciones", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@AÑO_INI", SqlDbType.Date)).Value = DESDE
        miComando.Parameters.Add(New SqlParameter("@AÑO_FIN", SqlDbType.Date)).Value = HASTA
        miComando.Parameters.Add(New SqlParameter("@SUCURSAL", SqlDbType.VarChar)).Value = SUCURSAL
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

    Public Function Devoluciones_OPL(ByVal DESDE As Date, ByVal HASTA As Date, ByVal SUCURSAL As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionOPL.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_devoluciones", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@AÑO_INI", SqlDbType.Date)).Value = DESDE
        miComando.Parameters.Add(New SqlParameter("@AÑO_FIN", SqlDbType.Date)).Value = HASTA
        miComando.Parameters.Add(New SqlParameter("@SUCURSAL", SqlDbType.VarChar)).Value = SUCURSAL
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

    Public Function Devoluciones_SRAGRO(ByVal DESDE As Date, ByVal HASTA As Date, ByVal SUCURSAL As Integer, ByVal TIPO As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_devoluciones", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@AÑO_INI", SqlDbType.Date)).Value = DESDE
        miComando.Parameters.Add(New SqlParameter("@AÑO_FIN", SqlDbType.Date)).Value = HASTA
        miComando.Parameters.Add(New SqlParameter("@ALMACEN", SqlDbType.Int)).Value = SUCURSAL
        miComando.Parameters.Add(New SqlParameter("@TIPO", SqlDbType.VarChar)).Value = TIPO
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
