Imports System.Data.SqlClient

Public Class clsayudaProductos

    Dim Conexion As New clsconexion_consumo
    Dim Conexion2 As New clsconexion_sr_agro
    Dim ConexionDimosa As New cls_conexion_DIMOSA

    Public Function helper(ByVal CLAVE As String, ByVal NOMBRE As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT CVE_ART, DESCR, ULT_COSTO " & _
                                        "FROM dbo.INVE05 " & _
                                        "WHERE  (UPPER(DESCR) LIKE '%" + NOMBRE + "%') OR CVE_ART = '" + NOMBRE + "'", ActualizarConexion)
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

    Public Function helper_agro(ByVal CLAVE As String, ByVal NOMBRE As String)
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT CVE_ART, DESCR, ULT_COSTO " & _
                                        "FROM dbo.INVE02 " & _
                                        "WHERE  (UPPER(DESCR) LIKE '%" + NOMBRE + "%')", ActualizarConexion)
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

    Public Function helper_dimosa(ByVal CLAVE As String, ByVal NOMBRE As String)
        Dim ActualizarConexion As New SqlConnection(ConexionDimosa.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT CVE_ART, DESCR, ULT_COSTO " & _
                                        "FROM dbo.INVE06 " & _
                                        "WHERE  (UPPER(DESCR) LIKE '%" + NOMBRE + "%') OR CVE_ART = '" + NOMBRE + "'", ActualizarConexion)
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

    Public Function codigo_sap(ByVal CLAVE As String, ByVal NOMBRE As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT IV_CL.CAMPLIB1 AS [CODIGO SAP], IV.DESCR AS [PRODUCTO] " & _
                                        "FROM dbo.INVE05 IV INNER JOIN " & _
                                        "dbo.INVE_CLIB05 IV_CL ON IV.CVE_ART = IV_CL.CVE_PROD " & _
                                        "WHERE  IV_CL.CAMPLIB1 <> ''  AND IV_CL.CAMPLIB1 IS NOT NULL AND UPPER(IV.DESCR) LIKE '%" + NOMBRE + "%'", ActualizarConexion)
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

    Public Function codigo_sap_dimosa(ByVal CLAVE As String, ByVal NOMBRE As String)
        Dim ActualizarConexion As New SqlConnection(ConexionDimosa.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT IV_CL.CAMPLIB1 AS [CODIGO SAP], IV.DESCR AS [PRODUCTO] " & _
                                        "FROM dbo.INVE06 IV INNER JOIN " & _
                                        "dbo.INVE_CLIB06 IV_CL ON IV.CVE_ART = IV_CL.CVE_PROD " & _
                                        "WHERE  IV_CL.CAMPLIB1 <> ''  AND IV_CL.CAMPLIB1 IS NOT NULL AND UPPER(IV.DESCR) LIKE '%" + NOMBRE + "%'", ActualizarConexion)
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

    Public Function helper_precio(ByVal CLAVE As String, ByVal NOMBRE As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT IV.CVE_ART, IV.DESCR, PP.PRECIO, ISNULL(C.IMPUESTO4, 0) AS ISV, ULT_COSTO  " & _
                                        "FROM dbo.INVE05 IV INNER JOIN dbo.PRECIO_X_PROD05 PP ON IV.CVE_ART = PP.CVE_ART " & _
                                        "INNER JOIN dbo.IMPU05 C ON IV.CVE_ESQIMPU = C.CVE_ESQIMPU " & _
                                        "WHERE PP.CVE_PRECIO = 1 AND (UPPER(DESCR) LIKE '%" + NOMBRE + "%')", ActualizarConexion)
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

    Public Function helper_precio_dimosa(ByVal CLAVE As String, ByVal NOMBRE As String)
        Dim ActualizarConexion As New SqlConnection(ConexionDimosa.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT IV.CVE_ART, IV.DESCR, PP.PRECIO, ISNULL(C.IMPUESTO4, 0) AS ISV, ULT_COSTO  " & _
                                        "FROM dbo.INVE06 IV INNER JOIN dbo.PRECIO_X_PROD06 PP ON IV.CVE_ART = PP.CVE_ART " & _
                                        "INNER JOIN dbo.IMPU06 C ON IV.CVE_ESQIMPU = C.CVE_ESQIMPU " & _
                                        "WHERE PP.CVE_PRECIO = 1 AND (UPPER(DESCR) LIKE '%" + NOMBRE + "%')", ActualizarConexion)
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
