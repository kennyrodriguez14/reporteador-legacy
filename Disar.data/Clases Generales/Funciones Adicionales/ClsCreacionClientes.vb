Imports Disar.data
Imports System.Data.SqlClient
Imports System.Text

Public Class ClsCreacionClientes
    Dim Conexion As New clsConexion
    Dim ConexionSIP As New cls_conexion_sip
    Dim ConexionSIPDIMOSA As New cls_conexion_sip
    Dim Conexion2 As New clsconexion_consumo
    Dim ConexionDIMOSA As New cls_conexion_DIMOSA
    Dim ConexionOPL As New cls_conexionOPL
    Dim ConexionAgro As New clsconexion_sr_agro

    Public Function VerCategorias()
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT Tipo, Nestle, Colgate, Interno FROM  Fax_SanRafael ORDER BY Tipo", ActualizarConexion)


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

    Public Function VerUnaCategorias(ByVal Cat As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT Tipo, Nestle, Colgate, Interno FROM  Fax_SanRafael Where Tipo = @Tipo ORDER BY Tipo ", ActualizarConexion)
        miComando.Parameters.AddWithValue("@Tipo", Cat)

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

    Public Function VerVENDEDORES()
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT     CVE_VEND, NOMBRE  FROM         VEND05 WHERE     (STATUS = 'A') ORDER BY NOMBRE", ActualizarConexion)


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

    Public Function VerVENDEDORESDIMOSA()
        Dim ActualizarConexion As New SqlConnection(ConexionDIMOSA.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT     CVE_VEND, NOMBRE  FROM         VEND06 WHERE     (STATUS = 'A') ORDER BY NOMBRE", ActualizarConexion)


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

    Public Function VerVENDEDORESOPL()
        Dim ActualizarConexion As New SqlConnection(ConexionDIMOSA.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT     CVE_VEND, NOMBRE  FROM         SAE60EMPRE08.dbo.VEND08 WHERE     (STATUS = 'A') ORDER BY NOMBRE", ActualizarConexion)


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

    Public Function ListarClientes()
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT Tipo, Nestle, Colgate, Interno FROM  Fax_SanRafael ORDER BY Tipo", ActualizarConexion)


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

    Public Function VerTodosClientes()
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT TOP(200)dbo.CLIE05.CLAVE, dbo.CLIE05.NOMBRE, ISNULL(dbo.CLIE05.PAG_WEB,'') AS PROPIETARIO, ISNULL(dbo.CLIE05.RFC,'') AS DEPARTAMENTO, ISNULL(dbo.CLIE05.LOCALIDAD,'') AS MUNICIPIO, " & _
        "              ISNULL(dbo.CLIE05.CALLE,'') AS DIRECCION, ISNULL(dbo.CLIE05.COLONIA,'') AS COLONIA, ISNULL(dbo.CLIE05.ESTADO,'') AS ESTADO, dbo.CLIE05.TELEFONO, dbo.CLIE05.CLASIFIC, dbo.CLIE05.FAX, " & _
        "              dbo.CLIE05.CVE_VEND AS 'CLAVE VENDEDOR', dbo.VEND05.NOMBRE AS VENDEDOR, dbo.CLIE_CLIB05.CAMPLIB1 AS 'TIPO DE PAGO', " & _
        "              dbo.CLIE_CLIB05.CAMPLIB3 AS 'DIA DE VISITA', dbo.CLIE_CLIB05.CAMPLIB7 AS 'NESTLE', dbo.CLIE_CLIB05.CAMPLIB8 AS 'COLGATE', " & _
        "              dbo.CLIE_CLIB05.CAMPLIB14 AS 'LONG (X)', dbo.CLIE_CLIB05.CAMPLIB15 AS 'LAT (Y)', dbo.CLIE_CLIB05.CAMPLIB17 AS 'FECHA CREACIÓN', FCH_ULTCOM AS 'ULTIMA COMPRA', ISNULL(dbo.CLIE_CLIB05.CAMPLIB32,'NO') AS 'CERTIFICACION COORDENADAS' " & _
        " FROM         dbo.VEND05 INNER JOIN dbo.CLIE05 ON dbo.VEND05.CVE_VEND = dbo.CLIE05.CVE_VEND INNER JOIN  dbo.CLIE_CLIB05 ON dbo.CLIE05.CLAVE = dbo.CLIE_CLIB05.CVE_CLIE ORDER BY dbo.CLIE05.CLAVE DESC", ActualizarConexion)


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

    Public Function VerTodosClientesDIMOSA()
        Dim ActualizarConexion As New SqlConnection(ConexionDIMOSA.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT TOP(200)dbo.CLIE06.CLAVE, dbo.CLIE06.NOMBRE, dbo.CLIE06.PAG_WEB AS PROPIETARIO, dbo.CLIE06.RFC AS DEPARTAMENTO, dbo.CLIE06.LOCALIDAD AS MUNICIPIO, " &
        "              dbo.CLIE06.CALLE AS DIRECCION, dbo.CLIE06.COLONIA, dbo.CLIE06.ESTADO, dbo.CLIE06.TELEFONO, dbo.CLIE06.CLASIFIC, dbo.CLIE06.FAX, " &
        "              dbo.CLIE06.CVE_VEND AS 'CLAVE VENDEDOR', dbo.VEND06.NOMBRE AS VENDEDOR, dbo.CLIE_CLIB06.CAMPLIB1 AS 'TIPO DE PAGO', " &
        "              dbo.CLIE_CLIB06.CAMPLIB3 AS 'DIA DE VISITA', dbo.CLIE_CLIB06.CAMPLIB7 AS 'NESTLE', dbo.CLIE_CLIB06.CAMPLIB8 AS 'COLGATE', " &
        "              dbo.CLIE_CLIB06.CAMPLIB14 AS 'LONG (X)', dbo.CLIE_CLIB06.CAMPLIB15 AS 'LAT (Y)', dbo.CLIE_CLIB06.CAMPLIB17 AS 'FECHA CREACIÓN', FCH_ULTCOM AS 'ULTIMA COMPRA',  ISNULL(dbo.CLIE_CLIB06.CAMPLIB32,'NO') AS 'CERTIFICACION COORDENADAS' " &
        " FROM         dbo.VEND06 INNER JOIN dbo.CLIE06 ON dbo.VEND06.CVE_VEND = dbo.CLIE06.CVE_VEND INNER JOIN  dbo.CLIE_CLIB06 ON dbo.CLIE06.CLAVE = dbo.CLIE_CLIB06.CVE_CLIE ORDER BY dbo.CLIE06.CLAVE DESC", ActualizarConexion)


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

    Public Function VerTodosClientesOPL()
        Dim ActualizarConexion As New SqlConnection(ConexionOPL.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT TOP(200)dbo.CLIE08.CLAVE, dbo.CLIE08.NOMBRE, dbo.CLIE08.PAG_WEB AS PROPIETARIO, dbo.CLIE08.RFC AS DEPARTAMENTO, dbo.CLIE08.LOCALIDAD AS MUNICIPIO, " &
        "              dbo.CLIE08.CALLE AS DIRECCION, dbo.CLIE08.COLONIA, dbo.CLIE08.ESTADO, dbo.CLIE08.TELEFONO, dbo.CLIE08.CLASIFIC, dbo.CLIE08.FAX, " &
        "              dbo.CLIE08.CVE_VEND AS 'CLAVE VENDEDOR', dbo.VEND08.NOMBRE AS VENDEDOR, dbo.CLIE_CLIB08.CAMPLIB1 AS 'TIPO DE PAGO', " &
        "              dbo.CLIE_CLIB08.CAMPLIB3 AS 'DIA DE VISITA', dbo.CLIE_CLIB08.CAMPLIB7 AS 'NESTLE', dbo.CLIE_CLIB08.CAMPLIB8 AS 'COLGATE', " &
        "              dbo.CLIE_CLIB08.CAMPLIB14 AS 'LONG (X)', dbo.CLIE_CLIB08.CAMPLIB15 AS 'LAT (Y)', dbo.CLIE_CLIB08.CAMPLIB17 AS 'FECHA CREACIÓN', FCH_ULTCOM AS 'ULTIMA COMPRA',  ISNULL(dbo.CLIE_CLIB08.CAMPLIB32,'NO') AS 'CERTIFICACION COORDENADAS', CAMPLIB2 AS 'CODIGO OPL', CAMPLIB11 AS 'EMPRESA OPL'  " &
        " FROM         dbo.VEND08 INNER JOIN dbo.CLIE08 ON dbo.VEND08.CVE_VEND = dbo.CLIE08.CVE_VEND INNER JOIN  dbo.CLIE_CLIB08 ON dbo.CLIE08.CLAVE = dbo.CLIE_CLIB08.CVE_CLIE ORDER BY dbo.CLIE08.CLAVE DESC", ActualizarConexion)


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

    Public Function VerTodosClientesAgro()
        Dim ActualizarConexion As New SqlConnection(ConexionAgro.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT TOP(200)dbo.CLIE02.CLAVE, dbo.CLIE02.NOMBRE, ISNULL(dbo.CLIE02.PAG_WEB,'') AS PROPIETARIO, ISNULL(dbo.CLIE02.RFC,'') AS DEPARTAMENTO, ISNULL(dbo.CLIE02.LOCALIDAD,'') AS MUNICIPIO, " & _
        "              ISNULL(dbo.CLIE02.CALLE,'') AS DIRECCION, ISNULL(dbo.CLIE02.COLONIA,'') AS COLONIA, ISNULL(dbo.CLIE02.ESTADO,'') AS ESTADO, dbo.CLIE02.TELEFONO, dbo.CLIE02.CLASIFIC, dbo.CLIE02.FAX, " & _
        "              dbo.CLIE02.CVE_VEND AS 'CLAVE VENDEDOR', dbo.VEND02.NOMBRE AS VENDEDOR, dbo.CLIE_CLIB02.CAMPLIB1 AS 'TIPO DE PAGO', " & _
        "              dbo.CLIE_CLIB02.CAMPLIB3 AS 'DIA DE VISITA', " & _
        "              dbo.CLIE_CLIB02.CAMPLIB21 AS 'LONG (X)', dbo.CLIE_CLIB02.CAMPLIB22 AS 'LAT (Y)', dbo.CLIE_CLIB02.CAMPLIB23 AS 'FECHA CREACIÓN', FCH_ULTCOM AS 'ULTIMA COMPRA', ISNULL(dbo.CLIE_CLIB02.CAMPLIB27,'NO') AS 'CERTIFICACION COORDENADAS' " & _
        " FROM         dbo.VEND02 INNER JOIN dbo.CLIE02 ON dbo.VEND02.CVE_VEND = dbo.CLIE02.CVE_VEND INNER JOIN  dbo.CLIE_CLIB02 ON dbo.CLIE02.CLAVE = dbo.CLIE_CLIB02.CVE_CLIE ORDER BY dbo.CLIE02.CLAVE DESC", ActualizarConexion)


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

    Public Function VerBuscaClientes(ByVal Busca As String)
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT dbo.CLIE05.CLAVE, dbo.CLIE05.NOMBRE, dbo.CLIE05.PAG_WEB AS PROPIETARIO, dbo.CLIE05.RFC AS DEPARTAMENTO, dbo.CLIE05.LOCALIDAD AS MUNICIPIO, " & _
        "              dbo.CLIE05.CALLE AS DIRECCION, dbo.CLIE05.COLONIA, dbo.CLIE05.ESTADO, dbo.CLIE05.TELEFONO, dbo.CLIE05.CLASIFIC, dbo.CLIE05.FAX, " & _
        "              dbo.CLIE05.CVE_VEND AS 'CLAVE VENDEDOR', dbo.VEND05.NOMBRE AS VENDEDOR, dbo.CLIE_CLIB05.CAMPLIB1 AS 'TIPO DE PAGO', " & _
        "              dbo.CLIE_CLIB05.CAMPLIB3 AS 'DIA DE VISITA', dbo.CLIE_CLIB05.CAMPLIB7 AS 'NESTLE', dbo.CLIE_CLIB05.CAMPLIB8 AS 'COLGATE', " & _
        "              dbo.CLIE_CLIB05.CAMPLIB14 AS 'LONG (X)', dbo.CLIE_CLIB05.CAMPLIB15 AS 'LAT (Y)', dbo.CLIE_CLIB05.CAMPLIB17 AS 'FECHA CREACIÓN', FCH_ULTCOM AS 'ULTIMA COMPRA', ISNULL(dbo.CLIE_CLIB05.CAMPLIB32,'NO') AS 'CERTIFICACION COORDENADAS' " & _
        " FROM         dbo.VEND05 INNER JOIN dbo.CLIE05 ON dbo.VEND05.CVE_VEND = dbo.CLIE05.CVE_VEND INNER JOIN  dbo.CLIE_CLIB05 ON dbo.CLIE05.CLAVE = dbo.CLIE_CLIB05.CVE_CLIE " & _
        " WHERE CLIE05.NOMBRE LIKE '%" & LTrim(RTrim(Busca)) & "%' OR LTRIM(dbo.CLIE05.CLAVE) = Ltrim(@CLAVE)  ", ActualizarConexion)

        miComando.Parameters.AddWithValue("@CLAVE", Busca)

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

    Public Function VerBuscaClientesDIMOSA(ByVal Busca As String)
        Dim ActualizarConexion As New SqlConnection(ConexionDIMOSA.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT dbo.CLIE06.CLAVE, dbo.CLIE06.NOMBRE, dbo.CLIE06.PAG_WEB AS PROPIETARIO, dbo.CLIE06.RFC AS DEPARTAMENTO, dbo.CLIE06.LOCALIDAD AS MUNICIPIO, " &
        "              dbo.CLIE06.CALLE AS DIRECCION, dbo.CLIE06.COLONIA, dbo.CLIE06.ESTADO, dbo.CLIE06.TELEFONO, dbo.CLIE06.CLASIFIC, dbo.CLIE06.FAX, " &
        "              dbo.CLIE06.CVE_VEND AS 'CLAVE VENDEDOR', dbo.VEND06.NOMBRE AS VENDEDOR, dbo.CLIE_CLIB06.CAMPLIB1 AS 'TIPO DE PAGO', " &
        "              dbo.CLIE_CLIB06.CAMPLIB3 AS 'DIA DE VISITA', dbo.CLIE_CLIB06.CAMPLIB7 AS 'NESTLE', dbo.CLIE_CLIB06.CAMPLIB8 AS 'COLGATE', " &
        "              dbo.CLIE_CLIB06.CAMPLIB14 AS 'LONG (X)', dbo.CLIE_CLIB06.CAMPLIB15 AS 'LAT (Y)', dbo.CLIE_CLIB06.CAMPLIB17 AS 'FECHA CREACIÓN', FCH_ULTCOM AS 'ULTIMA COMPRA', ISNULL(dbo.CLIE_CLIB06.CAMPLIB32,'NO') AS 'CERTIFICACION COORDENADAS' " &
        " FROM         dbo.VEND06 INNER JOIN dbo.CLIE06 ON dbo.VEND06.CVE_VEND = dbo.CLIE06.CVE_VEND INNER JOIN  dbo.CLIE_CLIB06 ON dbo.CLIE06.CLAVE = dbo.CLIE_CLIB06.CVE_CLIE " &
        " WHERE CLIE06.NOMBRE LIKE '%" & LTrim(RTrim(Busca)) & "%' OR LTRIM(dbo.CLIE06.CLAVE) = @CLAVE ", ActualizarConexion)

        miComando.Parameters.AddWithValue("@CLAVE", Busca)

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

    Public Function VerBuscaClientesOPL(ByVal Busca As String)
        Dim ActualizarConexion As New SqlConnection(ConexionOPL.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT dbo.CLIE08.CLAVE, dbo.CLIE08.NOMBRE, dbo.CLIE08.PAG_WEB AS PROPIETARIO, dbo.CLIE08.RFC AS DEPARTAMENTO, dbo.CLIE08.LOCALIDAD AS MUNICIPIO, " &
        "              dbo.CLIE08.CALLE AS DIRECCION, dbo.CLIE08.COLONIA, dbo.CLIE08.ESTADO, dbo.CLIE08.TELEFONO, dbo.CLIE08.CLASIFIC, dbo.CLIE08.FAX, " &
        "              dbo.CLIE08.CVE_VEND AS 'CLAVE VENDEDOR', dbo.VEND08.NOMBRE AS VENDEDOR, dbo.CLIE_CLIB08.CAMPLIB1 AS 'TIPO DE PAGO', " &
        "              dbo.CLIE_CLIB08.CAMPLIB3 AS 'DIA DE VISITA', dbo.CLIE_CLIB08.CAMPLIB7 AS 'NESTLE', dbo.CLIE_CLIB08.CAMPLIB8 AS 'COLGATE', " &
        "              dbo.CLIE_CLIB08.CAMPLIB14 AS 'LONG (X)', dbo.CLIE_CLIB08.CAMPLIB15 AS 'LAT (Y)', dbo.CLIE_CLIB08.CAMPLIB17 AS 'FECHA CREACIÓN', FCH_ULTCOM AS 'ULTIMA COMPRA', ISNULL(dbo.CLIE_CLIB08.CAMPLIB32,'NO') AS 'CERTIFICACION COORDENADAS', CAMPLIB2 AS 'CODIGO OPL', CAMPLIB11 AS 'EMPRESA OPL'   " &
        " FROM         dbo.VEND08 INNER JOIN dbo.CLIE08 ON dbo.VEND08.CVE_VEND = dbo.CLIE08.CVE_VEND INNER JOIN  dbo.CLIE_CLIB08 ON dbo.CLIE08.CLAVE = dbo.CLIE_CLIB08.CVE_CLIE " &
        " WHERE CLIE08.NOMBRE LIKE '%" & LTrim(RTrim(Busca)) & "%' OR LTRIM(dbo.CLIE08.CLAVE) = @CLAVE OR LTRIM(dbo.CLIE_CLIB08.CAMPLIB2) = @CLAVE ", ActualizarConexion)

        miComando.Parameters.AddWithValue("@CLAVE", Busca)

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

    Public Function VerBuscaClientesAgro(ByVal Busca As String)
        Dim ActualizarConexion As New SqlConnection(ConexionAgro.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT dbo.CLIE02.CLAVE, dbo.CLIE02.NOMBRE, dbo.CLIE02.PAG_WEB AS PROPIETARIO, dbo.CLIE02.RFC AS DEPARTAMENTO, dbo.CLIE02.LOCALIDAD AS MUNICIPIO, " & _
        "              dbo.CLIE02.CALLE AS DIRECCION, dbo.CLIE02.COLONIA, dbo.CLIE02.ESTADO, dbo.CLIE02.TELEFONO, dbo.CLIE02.CLASIFIC, dbo.CLIE02.FAX, " & _
        "              dbo.CLIE02.CVE_VEND AS 'CLAVE VENDEDOR', dbo.VEND02.NOMBRE AS VENDEDOR, dbo.CLIE_CLIB02.CAMPLIB1 AS 'TIPO DE PAGO', " & _
        "              dbo.CLIE_CLIB02.CAMPLIB3 AS 'DIA DE VISITA', " & _
        "              dbo.CLIE_CLIB02.CAMPLIB21 AS 'LONG (X)', dbo.CLIE_CLIB02.CAMPLIB22 AS 'LAT (Y)', dbo.CLIE_CLIB02.CAMPLIB23 AS 'FECHA CREACIÓN', FCH_ULTCOM AS 'ULTIMA COMPRA', ISNULL(dbo.CLIE_CLIB02.CAMPLIB27,'NO') AS 'CERTIFICACION COORDENADAS' " & _
        " FROM         dbo.VEND02 INNER JOIN dbo.CLIE02 ON dbo.VEND02.CVE_VEND = dbo.CLIE02.CVE_VEND INNER JOIN  dbo.CLIE_CLIB02 ON dbo.CLIE02.CLAVE = dbo.CLIE_CLIB02.CVE_CLIE " & _
        " WHERE CLIE02.NOMBRE LIKE '%" & LTrim(RTrim(Busca)) & "%' OR LTRIM(dbo.CLIE02.CLAVE) = Ltrim(@CLAVE) ", ActualizarConexion)

        miComando.Parameters.AddWithValue("@CLAVE", Busca)

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

    Public Function VALIDACLIENTE(ByVal Busca As Integer)
        Dim ActualizarConexion As New SqlConnection(ConexionDIMOSA.CadenaSQL())
        Dim miComando As New SqlCommand(" SELECT        dbo.CLIE06.CLAVE, dbo.CLIE06.NOMBRE, dbo.CLIE_CLIB06.CAMPLIB2 FROM dbo.CLIE06 INNER JOIN " & _
                                        " dbo.CLIE_CLIB06 ON dbo.CLIE06.CLAVE = dbo.CLIE_CLIB06.CVE_CLIE WHERE (REPLACE(REPLACE(dbo.CLIE_CLIB06.CAMPLIB2, 'R', ''), 'S', '') = @CLAVE)", ActualizarConexion)

        miComando.Parameters.AddWithValue("@CLAVE", Busca)

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

    Public Function NuevoCliente(ByVal CLAVE As String, ByVal NOMBRE As String, ByVal PAG_WEB As String, ByVal RFC As String, ByVal MUNICIPIO As String, ByVal CALLE As String, ByVal COLONIA As String, ByVal ESTADO As String, ByVal TELEFONO As String, ByVal CLASIFIC As String, ByVal FAX As String, ByVal CVE_VEND As String, ByVal VENDEDOR As String, ByVal TIPOPAGO As String, ByVal VISITA As String, ByVal NESTLE As String, ByVal COLGATE As String, ByVal LON As String, ByVal LAT As String, ByVal FECHACreacion As Date, ByVal CLASIFICA As String, ByVal FiltroNestle As String, ByVal FiltroCargill As String)

        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand
            'Guarda nueva marca

            Dim NumBita As Integer = 0
            Dim DtBita As New DataTable
            Dim QueryBita As String
            QueryBita = "SELECT  MAX(dbo.CLIE05.CLAVE)  FROM dbo.CLIE05 WHERE dbo.CLIE05.CLAVE <> 'MOSTR' AND dbo.CLIE05.CLAVE <> '     99999'"
            Dim CMDQueryBita As New SqlCommand(QueryBita, ActualizarConexion)
            Dim AdaptadorBita As New SqlDataAdapter(CMDQueryBita)
            CMDQueryBita.Transaction = transaccion_sql
            AdaptadorBita.Fill(DtBita)

            If DtBita.Rows.Count > 0 Then
                If Not IsDBNull(DtBita.Rows(0)(0)) Then
                    NumBita = DtBita.Rows(0)(0)
                End If
            End If
            NumBita += 1

            Dim X As String = NumBita.ToString
            For a As Integer = X.Length To 9
                X = " " & X
            Next
            Dim Fecha As Date = Today.Date
            Dim DtFecha As New DataTable
            Dim QueryFecha As String
            QueryFecha = " SELECT GETDATE() as FECHA"
            Dim CMDQueryFecha As New SqlCommand(QueryFecha, ActualizarConexion)
            Dim AdaptadorFecha As New SqlDataAdapter(CMDQueryFecha)
            CMDQueryFecha.Transaction = transaccion_sql
            AdaptadorFecha.Fill(DtBita)

            If DtFecha.Rows.Count > 0 Then
                If Not IsDBNull(DtFecha.Rows(0)(0)) Then
                    Fecha = DtFecha.Rows(0)(0)
                End If
            End If

            Dim MATRIZ As String = ""
            Dim DtMATRIZ As New DataTable
            Dim QueryMATRIZ As String = ""
            QueryMATRIZ = " Select Max(MATRIZ) From CLIE05 Where MATRIZ <>'MOSTR' AND MATRIZ <> 'DINOR' AND MATRIZ <> 'D2'"
            Dim CMDQueryMATRIZ As New SqlCommand(QueryMATRIZ, ActualizarConexion)
            Dim AdaptadorMATRIZ As New SqlDataAdapter(CMDQueryMATRIZ)
            CMDQueryMATRIZ.Transaction = transaccion_sql
            AdaptadorFecha.Fill(DtMATRIZ)

            If DtMATRIZ.Rows.Count > 0 Then
                If Not IsDBNull(DtMATRIZ.Rows(0)(0)) Then
                    MATRIZ = DtMATRIZ.Rows(0)(0)
                End If
            End If

            miComando = New SqlCommand("INSERT INTO SAE60Empre05.dbo.CLIE05" & _
                                         " ( CLAVE, STATUS, NOMBRE, RFC, CALLE,   NUMEXT,  COLONIA, CODIGO, LOCALIDAD, ESTADO, " & _
                      " TELEFONO, CLASIFIC, FAX, PAG_WEB,  IMPRIR, MAIL, NIVELSEC, ENVIOSILEN,  " & _
                      " CON_CREDITO, DIASCRED, LIMCRED, SALDO, LISTA_PREC, CVE_BITA, ULT_PAGOD, ULT_PAGOM, ULT_PAGOF, DESCUENTO, ULT_VENTAD, ULT_COMPM,  " & _
                      " FCH_ULTCOM, VENTAS, CVE_VEND, CVE_OBS, TIPO_EMPRESA, PROSPECTO,  " & _
                      " DES_IMPU1, DES_IMPU2, " & _
                      " DES_IMPU3, DES_IMPU4, DES_PER, LAT_GENERAL, LON_GENERAL, LAT_ENVIO, LON_ENVIO) " & _
                                         " VALUES ( @CLAVE, @STATUS, @NOMBRE, @RFC, @CALLE,  @NUMEXT,   @COLONIA, @CODIGO, @LOCALIDAD, @ESTADO, " & _
                      " @TELEFONO, @CLASIFIC, @FAX, @PAG_WEB, @IMPRIR, @MAIL, @NIVELSEC, @ENVIOSILEN,  " & _
                      " @CON_CREDITO, @DIASCRED, @LIMCRED, @SALDO, @LISTA_PREC, @CVE_BITA, @ULT_PAGOD, @ULT_PAGOM, @ULT_PAGOF, @DESCUENTO, @ULT_VENTAD, @ULT_COMPM, " & _
                      " @FCH_ULTCOM, @VENTAS, @CVE_VEND, @CVE_OBS, @TIPO_EMPRESA, @PROSPECTO, " & _
                      " @DES_IMPU1, @DES_IMPU2, " & _
                      " @DES_IMPU3, @DES_IMPU4, @DES_PER, @LAT_GENERAL, @LON_GENERAL, @LAT_ENVIO, @LON_ENVIO)", ActualizarConexion)

            miComando.Parameters.AddWithValue("@CLAVE", X)
            miComando.Parameters.AddWithValue("@STATUS", "A")
            miComando.Parameters.AddWithValue("@NOMBRE", NOMBRE & " (" & MUNICIPIO & ")")
            miComando.Parameters.AddWithValue("@RFC", RFC)
            miComando.Parameters.AddWithValue("@CALLE", CALLE)
            miComando.Parameters.AddWithValue("@NUMEXT", "A")

            miComando.Parameters.AddWithValue("@COLONIA", COLONIA)
            miComando.Parameters.AddWithValue("@CODIGO", 1)
            miComando.Parameters.AddWithValue("@LOCALIDAD", MUNICIPIO)

            miComando.Parameters.AddWithValue("@ESTADO", ESTADO)
            miComando.Parameters.AddWithValue("@TELEFONO", TELEFONO)

            miComando.Parameters.AddWithValue("@CLASIFIC", CLASIFIC)
            miComando.Parameters.AddWithValue("@FAX", FAX)
            miComando.Parameters.AddWithValue("@PAG_WEB", PAG_WEB)

            miComando.Parameters.AddWithValue("@IMPRIR", "S")
            miComando.Parameters.AddWithValue("@MAIL", "N")
            miComando.Parameters.AddWithValue("@NIVELSEC", 0)
            miComando.Parameters.AddWithValue("@ENVIOSILEN", "N")

            miComando.Parameters.AddWithValue("@CON_CREDITO", "N")
            miComando.Parameters.AddWithValue("@DIASCRED", 0)
            miComando.Parameters.AddWithValue("@LIMCRED", 0)

            miComando.Parameters.AddWithValue("@SALDO", 0)
            miComando.Parameters.AddWithValue("@LISTA_PREC", DBNull.Value)
            miComando.Parameters.AddWithValue("@CVE_BITA", DBNull.Value)
            miComando.Parameters.AddWithValue("@ULT_PAGOD", DBNull.Value)
            miComando.Parameters.AddWithValue("@ULT_PAGOM", 0)
            miComando.Parameters.AddWithValue("@ULT_PAGOF", DBNull.Value)
            miComando.Parameters.AddWithValue("@DESCUENTO", 0)
            miComando.Parameters.AddWithValue("@ULT_VENTAD", DBNull.Value)
            miComando.Parameters.AddWithValue("@ULT_COMPM", 0)
            miComando.Parameters.AddWithValue("@FCH_ULTCOM", DBNull.Value)
            miComando.Parameters.AddWithValue("@VENTAS", 0)
            miComando.Parameters.AddWithValue("@CVE_VEND", VENDEDOR)
            miComando.Parameters.AddWithValue("@CVE_OBS", 0)
            miComando.Parameters.AddWithValue("@TIPO_EMPRESA", "M")
            'miComando.Parameters.AddWithValue("@MATRIZ", MATRIZ)
            miComando.Parameters.AddWithValue("@PROSPECTO", "N")

            miComando.Parameters.AddWithValue("@DES_IMPU1", "N")
            miComando.Parameters.AddWithValue("@DES_IMPU2", "N")
            miComando.Parameters.AddWithValue("@DES_IMPU3", "N")
            miComando.Parameters.AddWithValue("@DES_IMPU4", "N")
            miComando.Parameters.AddWithValue("@DES_PER", "N")
            miComando.Parameters.AddWithValue("@LAT_GENERAL", 0)
            miComando.Parameters.AddWithValue("@LON_GENERAL", 0)
            miComando.Parameters.AddWithValue("@LAT_ENVIO", DBNull.Value)
            miComando.Parameters.AddWithValue("@LON_ENVIO", DBNull.Value)

            miComando.Transaction = transaccion_sql
            miComando.ExecuteNonQuery()

            miComando = New SqlCommand("INSERT INTO SAE60Empre05.dbo.CLIE_CLIB05" & _
                                        " (CVE_CLIE, CAMPLIB1, CAMPLIB2, CAMPLIB3, CAMPLIB7, CAMPLIB8, CAMPLIB14, CAMPLIB15, CAMPLIB17, CAMPLIB18, CAMPLIB22) " & _
                                        " VALUES (@CVE_CLIE, @CAMPLIB1, @CAMPLIB2, @CAMPLIB3, @CAMPLIB7, @CAMPLIB8, @CAMPLIB14, @CAMPLIB15, @CAMPLIB17, @CAMPLIB18, @CAMPLIB22)", ActualizarConexion)

            miComando.Parameters.AddWithValue("@CVE_CLIE", X)
            miComando.Parameters.AddWithValue("@CAMPLIB1", "CONTADO")
            miComando.Parameters.AddWithValue("@CAMPLIB2", "R")
            miComando.Parameters.AddWithValue("@CAMPLIB3", VISITA)
            miComando.Parameters.AddWithValue("@CAMPLIB7", NESTLE)
            miComando.Parameters.AddWithValue("@CAMPLIB8", COLGATE)
            miComando.Parameters.AddWithValue("@CAMPLIB14", LON)
            miComando.Parameters.AddWithValue("@CAMPLIB15", LAT)
            miComando.Parameters.AddWithValue("@CAMPLIB17", FECHACreacion.Date)
            miComando.Parameters.AddWithValue("@CAMPLIB18", FiltroNestle)
            miComando.Parameters.AddWithValue("@CAMPLIB22", FiltroCargill)

            miComando.Transaction = transaccion_sql
            miComando.ExecuteNonQuery()


            transaccion_sql.Commit()
            ActualizarConexion.Close()
            Return X
        Catch ex As Exception
            transaccion_sql.Rollback()
            ActualizarConexion.Close()
            Dim tamaño As Integer = Convert.ToString(ex.StackTrace).Length
            Dim posicion As Integer = InStrRev(Convert.ToString(ex.StackTrace), "línea") - 1
            Dim inicial As Integer = tamaño - posicion
            Dim linea_error As String = Convert.ToString(ex.StackTrace).Substring(tamaño - inicial, inicial)
            Return "Error: " & ex.Message & " " & linea_error
        End Try

    End Function

    Public Function NuevoClienteDIMOSA(ByVal CLAVE As String, ByVal NOMBRE As String, ByVal PAG_WEB As String, ByVal RFC As String, ByVal MUNICIPIO As String, ByVal CALLE As String, ByVal COLONIA As String, ByVal ESTADO As String, ByVal TELEFONO As String, ByVal CLASIFIC As String, ByVal FAX As String, ByVal CVE_VEND As String, ByVal VENDEDOR As String, ByVal TIPOPAGO As String, ByVal VISITA As String, ByVal NESTLE As String, ByVal COLGATE As String, ByVal LON As String, ByVal LAT As String, ByVal FECHACreacion As Date, ByVal CLASIFICA As String, ByVal FiltroNestle As String, ByVal FiltroCargill As String, ByVal Carga As String)

        Dim ActualizarConexion As New SqlConnection(ConexionDIMOSA.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        'Dim DUPLICADO As Integer = 0

        'Dim miComandoA As New SqlCommand
        'Dim NumBitaA As Integer = 0
        'Dim DtBitaA As New DataTable
        'Dim QueryBitaA As String
        'QueryBitaA = "SELECT CVE_CLIE, CAMPLIB1, CAMPLIB2, CAMPLIB3, LTRIM(REPLACE(REPLACE(CAMPLIB2, 'R', ''), 'S', '')) AS NUMERO FROM CLIE_CLIB06 WHERE (LTRIM(REPLACE(REPLACE(CAMPLIB2, 'R', ''), 'S', '')) = @ID)"
        'Dim CMDQueryBitaA As New SqlCommand(QueryBitaA, ActualizarConexion)
        'Dim AdaptadorBitaA As New SqlDataAdapter(CMDQueryBitaA)
        'CMDQueryBitaA.Transaction = transaccion_sql
        'AdaptadorBitaA.Fill(DtBitaA)

        'If DtBitaA.Rows.Count > 0 Then
        '    If Not IsDBNull(DtBitaA.Rows(0)(4)) Then
        '        DUPLICADO = DtBitaA.Rows(0)(4)
        '    End If
        'End If


        'If DUPLICADO = 0 Then
        Try
            Dim miComando As New SqlCommand
            'Guarda nueva marca

            Dim NumBita As Integer = 0
            Dim DtBita As New DataTable
            Dim QueryBita As String
            QueryBita = "SELECT  MAX(dbo.CLIE06.CLAVE)  FROM dbo.CLIE06 WHERE dbo.CLIE06.CLAVE <> 'MOSTR' AND dbo.CLIE06.CLAVE <> '     99999'"
            Dim CMDQueryBita As New SqlCommand(QueryBita, ActualizarConexion)
            Dim AdaptadorBita As New SqlDataAdapter(CMDQueryBita)
            CMDQueryBita.Transaction = transaccion_sql
            AdaptadorBita.Fill(DtBita)

            If DtBita.Rows.Count > 0 Then
                If Not IsDBNull(DtBita.Rows(0)(0)) Then
                    NumBita = DtBita.Rows(0)(0)
                End If
            End If
            NumBita += 1

            Dim X As String = NumBita.ToString
            For a As Integer = X.Length To 9
                X = " " & X
            Next
            Dim Fecha As Date = Today.Date
            Dim DtFecha As New DataTable
            Dim QueryFecha As String
            QueryFecha = " SELECT GETDATE() as FECHA"
            Dim CMDQueryFecha As New SqlCommand(QueryFecha, ActualizarConexion)
            Dim AdaptadorFecha As New SqlDataAdapter(CMDQueryFecha)
            CMDQueryFecha.Transaction = transaccion_sql
            AdaptadorFecha.Fill(DtBita)

            If DtFecha.Rows.Count > 0 Then
                If Not IsDBNull(DtFecha.Rows(0)(0)) Then
                    Fecha = DtFecha.Rows(0)(0)
                End If
            End If

            Dim MATRIZ As String = ""
            Dim DtMATRIZ As New DataTable
            Dim QueryMATRIZ As String = ""
            QueryMATRIZ = " Select Max(MATRIZ) From CLIE06 Where MATRIZ <>'MOSTR' AND MATRIZ <> 'DINOR' AND MATRIZ <> 'D2'"
            Dim CMDQueryMATRIZ As New SqlCommand(QueryMATRIZ, ActualizarConexion)
            Dim AdaptadorMATRIZ As New SqlDataAdapter(CMDQueryMATRIZ)
            CMDQueryMATRIZ.Transaction = transaccion_sql
            AdaptadorFecha.Fill(DtMATRIZ)

            If DtMATRIZ.Rows.Count > 0 Then
                If Not IsDBNull(DtMATRIZ.Rows(0)(0)) Then
                    MATRIZ = DtMATRIZ.Rows(0)(0)
                End If
            End If

            miComando = New SqlCommand("INSERT INTO SAE60Empre06.dbo.CLIE06" & _
                                         " ( CLAVE, STATUS, NOMBRE, RFC, CALLE,   NUMEXT,  COLONIA, CODIGO, LOCALIDAD, ESTADO, " & _
                      " TELEFONO, CLASIFIC, FAX, PAG_WEB,  IMPRIR, MAIL, NIVELSEC, ENVIOSILEN,  " & _
                      " CON_CREDITO, DIASCRED, LIMCRED, SALDO, LISTA_PREC, CVE_BITA, ULT_PAGOD, ULT_PAGOM, ULT_PAGOF, DESCUENTO, ULT_VENTAD, ULT_COMPM,  " & _
                      " FCH_ULTCOM, VENTAS, CVE_VEND, CVE_OBS, TIPO_EMPRESA, PROSPECTO,  " & _
                      " DES_IMPU1, DES_IMPU2, " & _
                      " DES_IMPU3, DES_IMPU4, DES_PER, LAT_GENERAL, LON_GENERAL, LAT_ENVIO, LON_ENVIO) " & _
                                         " VALUES ( @CLAVE, @STATUS, @NOMBRE, @RFC, @CALLE,  @NUMEXT,   @COLONIA, @CODIGO, @LOCALIDAD, @ESTADO, " & _
                      " @TELEFONO, @CLASIFIC, @FAX, @PAG_WEB, @IMPRIR, @MAIL, @NIVELSEC, @ENVIOSILEN,  " & _
                      " @CON_CREDITO, @DIASCRED, @LIMCRED, @SALDO, @LISTA_PREC, @CVE_BITA, @ULT_PAGOD, @ULT_PAGOM, @ULT_PAGOF, @DESCUENTO, @ULT_VENTAD, @ULT_COMPM, " & _
                      " @FCH_ULTCOM, @VENTAS, @CVE_VEND, @CVE_OBS, @TIPO_EMPRESA, @PROSPECTO, " & _
                      " @DES_IMPU1, @DES_IMPU2, " & _
                      " @DES_IMPU3, @DES_IMPU4, @DES_PER, @LAT_GENERAL, @LON_GENERAL, @LAT_ENVIO, @LON_ENVIO)", ActualizarConexion)

            miComando.Parameters.AddWithValue("@CLAVE", X)
            miComando.Parameters.AddWithValue("@STATUS", "A")
            If Carga = "" Then
                miComando.Parameters.AddWithValue("@NOMBRE", NOMBRE & " (" & MUNICIPIO & ")")
            Else
                miComando.Parameters.AddWithValue("@NOMBRE", NOMBRE)
            End If

            miComando.Parameters.AddWithValue("@RFC", RFC)
            miComando.Parameters.AddWithValue("@CALLE", CALLE)
            miComando.Parameters.AddWithValue("@NUMEXT", "A")

            miComando.Parameters.AddWithValue("@COLONIA", COLONIA)
            miComando.Parameters.AddWithValue("@CODIGO", 1)
            miComando.Parameters.AddWithValue("@LOCALIDAD", MUNICIPIO)

            miComando.Parameters.AddWithValue("@ESTADO", ESTADO)
            miComando.Parameters.AddWithValue("@TELEFONO", TELEFONO)

            miComando.Parameters.AddWithValue("@CLASIFIC", CLASIFIC)
            miComando.Parameters.AddWithValue("@FAX", FAX)
            miComando.Parameters.AddWithValue("@PAG_WEB", PAG_WEB)

            miComando.Parameters.AddWithValue("@IMPRIR", "S")
            miComando.Parameters.AddWithValue("@MAIL", "N")
            miComando.Parameters.AddWithValue("@NIVELSEC", 0)
            miComando.Parameters.AddWithValue("@ENVIOSILEN", "N")

            miComando.Parameters.AddWithValue("@CON_CREDITO", "N")
            miComando.Parameters.AddWithValue("@DIASCRED", 0)
            miComando.Parameters.AddWithValue("@LIMCRED", 0)

            miComando.Parameters.AddWithValue("@SALDO", 0)
            miComando.Parameters.AddWithValue("@LISTA_PREC", DBNull.Value)
            miComando.Parameters.AddWithValue("@CVE_BITA", DBNull.Value)
            miComando.Parameters.AddWithValue("@ULT_PAGOD", DBNull.Value)
            miComando.Parameters.AddWithValue("@ULT_PAGOM", 0)
            miComando.Parameters.AddWithValue("@ULT_PAGOF", DBNull.Value)
            miComando.Parameters.AddWithValue("@DESCUENTO", 0)
            miComando.Parameters.AddWithValue("@ULT_VENTAD", DBNull.Value)
            miComando.Parameters.AddWithValue("@ULT_COMPM", 0)
            miComando.Parameters.AddWithValue("@FCH_ULTCOM", DBNull.Value)
            miComando.Parameters.AddWithValue("@VENTAS", 0)
            miComando.Parameters.AddWithValue("@CVE_VEND", VENDEDOR)
            miComando.Parameters.AddWithValue("@CVE_OBS", 0)
            miComando.Parameters.AddWithValue("@TIPO_EMPRESA", "M")
            'miComando.Parameters.AddWithValue("@MATRIZ", MATRIZ)
            miComando.Parameters.AddWithValue("@PROSPECTO", "N")

            miComando.Parameters.AddWithValue("@DES_IMPU1", "N")
            miComando.Parameters.AddWithValue("@DES_IMPU2", "N")
            miComando.Parameters.AddWithValue("@DES_IMPU3", "N")
            miComando.Parameters.AddWithValue("@DES_IMPU4", "N")
            miComando.Parameters.AddWithValue("@DES_PER", "N")
            miComando.Parameters.AddWithValue("@LAT_GENERAL", 0)
            miComando.Parameters.AddWithValue("@LON_GENERAL", 0)
            miComando.Parameters.AddWithValue("@LAT_ENVIO", DBNull.Value)
            miComando.Parameters.AddWithValue("@LON_ENVIO", DBNull.Value)

            miComando.Transaction = transaccion_sql
            miComando.ExecuteNonQuery()

            miComando = New SqlCommand("INSERT INTO SAE60Empre06.dbo.CLIE_CLIB06" & _
                                        " (CVE_CLIE, CAMPLIB1, CAMPLIB2, CAMPLIB3, CAMPLIB7, CAMPLIB8, CAMPLIB14, CAMPLIB15, CAMPLIB17, CAMPLIB18, CAMPLIB22) " & _
                                        " VALUES (@CVE_CLIE, @CAMPLIB1, @CAMPLIB2, @CAMPLIB3, @CAMPLIB7, @CAMPLIB8, @CAMPLIB14, @CAMPLIB15, @CAMPLIB17, @CAMPLIB18, @CAMPLIB22)", ActualizarConexion)

            miComando.Parameters.AddWithValue("@CVE_CLIE", X)
            miComando.Parameters.AddWithValue("@CAMPLIB1", "CONTADO")
            If Carga = "" Then
                miComando.Parameters.AddWithValue("@CAMPLIB2", "R")
            Else
                miComando.Parameters.AddWithValue("@CAMPLIB2", "R" & Carga)
            End If

            miComando.Parameters.AddWithValue("@CAMPLIB3", VISITA)
            miComando.Parameters.AddWithValue("@CAMPLIB7", NESTLE)
            miComando.Parameters.AddWithValue("@CAMPLIB8", COLGATE)
            miComando.Parameters.AddWithValue("@CAMPLIB14", LON)
            miComando.Parameters.AddWithValue("@CAMPLIB15", LAT)
            miComando.Parameters.AddWithValue("@CAMPLIB17", FECHACreacion.Date)
            miComando.Parameters.AddWithValue("@CAMPLIB18", FiltroNestle)
            miComando.Parameters.AddWithValue("@CAMPLIB22", FiltroCargill)

            miComando.Transaction = transaccion_sql
            miComando.ExecuteNonQuery()


            transaccion_sql.Commit()
            ActualizarConexion.Close()
            Return X
        Catch ex As Exception
            transaccion_sql.Rollback()
            ActualizarConexion.Close()
            Dim tamaño As Integer = Convert.ToString(ex.StackTrace).Length
            Dim posicion As Integer = InStrRev(Convert.ToString(ex.StackTrace), "línea") - 1
            Dim inicial As Integer = tamaño - posicion
            Dim linea_error As String = Convert.ToString(ex.StackTrace).Substring(tamaño - inicial, inicial)
            Return "Error: " & ex.Message & " " & linea_error
        End Try
        'Else
        'transaccion_sql.Rollback()
        'ActualizarConexion.Close()
        'Return ("El cliente ya se encuentra creado en DIMOSA")
        'End If

    End Function

    Public Function NuevoClienteOPL(ByVal CLAVE As String, ByVal NOMBRE As String, ByVal PAG_WEB As String, ByVal RFC As String, ByVal MUNICIPIO As String, ByVal CALLE As String, ByVal COLONIA As String, ByVal ESTADO As String, ByVal TELEFONO As String, ByVal CLASIFIC As String, ByVal FAX As String, ByVal CVE_VEND As String, ByVal VENDEDOR As String, ByVal TIPOPAGO As String, ByVal VISITA As String, ByVal NESTLE As String, ByVal COLGATE As String, ByVal LON As String, ByVal LAT As String, ByVal FECHACreacion As Date, ByVal CLASIFICA As String, ByVal FiltroNestle As String, ByVal FiltroCargill As String, ByVal Carga As String, ByVal CODIGO As String, ByVal EMPRESA As String)

        Dim ActualizarConexion As New SqlConnection(ConexionOPL.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        'Dim DUPLICADO As Integer = 0

        'Dim miComandoA As New SqlCommand
        'Dim NumBitaA As Integer = 0
        'Dim DtBitaA As New DataTable
        'Dim QueryBitaA As String
        'QueryBitaA = "SELECT CVE_CLIE, CAMPLIB1, CAMPLIB2, CAMPLIB3, LTRIM(REPLACE(REPLACE(CAMPLIB2, 'R', ''), 'S', '')) AS NUMERO FROM CLIE_CLIB08 WHERE (LTRIM(REPLACE(REPLACE(CAMPLIB2, 'R', ''), 'S', '')) = @ID)"
        'Dim CMDQueryBitaA As New SqlCommand(QueryBitaA, ActualizarConexion)
        'Dim AdaptadorBitaA As New SqlDataAdapter(CMDQueryBitaA)
        'CMDQueryBitaA.Transaction = transaccion_sql
        'AdaptadorBitaA.Fill(DtBitaA)

        'If DtBitaA.Rows.Count > 0 Then
        '    If Not IsDBNull(DtBitaA.Rows(0)(4)) Then
        '        DUPLICADO = DtBitaA.Rows(0)(4)
        '    End If
        'End If


        'If DUPLICADO = 0 Then
        Try
            Dim miComando As New SqlCommand
            'Guarda nueva marca

            Dim NumBita As Integer = 0
            Dim DtBita As New DataTable
            Dim QueryBita As String
            QueryBita = "SELECT  MAX(dbo.CLIE08.CLAVE)  FROM dbo.CLIE08 WHERE dbo.CLIE08.CLAVE <> 'MOSTR' AND dbo.CLIE08.CLAVE <> '     99999'"
            Dim CMDQueryBita As New SqlCommand(QueryBita, ActualizarConexion)
            Dim AdaptadorBita As New SqlDataAdapter(CMDQueryBita)
            CMDQueryBita.Transaction = transaccion_sql
            AdaptadorBita.Fill(DtBita)

            If DtBita.Rows.Count > 0 Then
                If Not IsDBNull(DtBita.Rows(0)(0)) Then
                    NumBita = DtBita.Rows(0)(0)
                End If
            End If
            NumBita += 1

            Dim X As String = NumBita.ToString
            For a As Integer = X.Length To 9
                X = " " & X
            Next
            Dim Fecha As Date = Today.Date
            Dim DtFecha As New DataTable
            Dim QueryFecha As String
            QueryFecha = " SELECT GETDATE() as FECHA"
            Dim CMDQueryFecha As New SqlCommand(QueryFecha, ActualizarConexion)
            Dim AdaptadorFecha As New SqlDataAdapter(CMDQueryFecha)
            CMDQueryFecha.Transaction = transaccion_sql
            AdaptadorFecha.Fill(DtBita)

            If DtFecha.Rows.Count > 0 Then
                If Not IsDBNull(DtFecha.Rows(0)(0)) Then
                    Fecha = DtFecha.Rows(0)(0)
                End If
            End If

            Dim MATRIZ As String = ""
            Dim DtMATRIZ As New DataTable
            Dim QueryMATRIZ As String = ""
            QueryMATRIZ = " Select Max(MATRIZ) From CLIE08 Where MATRIZ <>'MOSTR' AND MATRIZ <> 'DINOR' AND MATRIZ <> 'D2'"
            Dim CMDQueryMATRIZ As New SqlCommand(QueryMATRIZ, ActualizarConexion)
            Dim AdaptadorMATRIZ As New SqlDataAdapter(CMDQueryMATRIZ)
            CMDQueryMATRIZ.Transaction = transaccion_sql
            AdaptadorFecha.Fill(DtMATRIZ)

            If DtMATRIZ.Rows.Count > 0 Then
                If Not IsDBNull(DtMATRIZ.Rows(0)(0)) Then
                    MATRIZ = DtMATRIZ.Rows(0)(0)
                End If
            End If

            miComando = New SqlCommand("INSERT INTO SAE60Empre08.dbo.CLIE08" &
                                         " ( CLAVE, STATUS, NOMBRE, RFC, CALLE,   NUMEXT,  COLONIA, CODIGO, LOCALIDAD, ESTADO, " &
                      " TELEFONO, CLASIFIC, FAX, PAG_WEB,  IMPRIR, MAIL, NIVELSEC, ENVIOSILEN,  " &
                      " CON_CREDITO, DIASCRED, LIMCRED, SALDO, LISTA_PREC, CVE_BITA, ULT_PAGOD, ULT_PAGOM, ULT_PAGOF, DESCUENTO, ULT_VENTAD, ULT_COMPM,  " &
                      " FCH_ULTCOM, VENTAS, CVE_VEND, CVE_OBS, TIPO_EMPRESA, PROSPECTO,  " &
                      " DES_IMPU1, DES_IMPU2, " &
                      " DES_IMPU3, DES_IMPU4, DES_PER, LAT_GENERAL, LON_GENERAL, LAT_ENVIO, LON_ENVIO) " &
                                         " VALUES ( @CLAVE, @STATUS, @NOMBRE, @RFC, @CALLE,  @NUMEXT,   @COLONIA, @CODIGO, @LOCALIDAD, @ESTADO, " &
                      " @TELEFONO, @CLASIFIC, @FAX, @PAG_WEB, @IMPRIR, @MAIL, @NIVELSEC, @ENVIOSILEN,  " &
                      " @CON_CREDITO, @DIASCRED, @LIMCRED, @SALDO, @LISTA_PREC, @CVE_BITA, @ULT_PAGOD, @ULT_PAGOM, @ULT_PAGOF, @DESCUENTO, @ULT_VENTAD, @ULT_COMPM, " &
                      " @FCH_ULTCOM, @VENTAS, @CVE_VEND, @CVE_OBS, @TIPO_EMPRESA, @PROSPECTO, " &
                      " @DES_IMPU1, @DES_IMPU2, " &
                      " @DES_IMPU3, @DES_IMPU4, @DES_PER, @LAT_GENERAL, @LON_GENERAL, @LAT_ENVIO, @LON_ENVIO)", ActualizarConexion)

            miComando.Parameters.AddWithValue("@CLAVE", X)
            miComando.Parameters.AddWithValue("@STATUS", "A")
            If Carga = "" Then
                miComando.Parameters.AddWithValue("@NOMBRE", NOMBRE & " (" & MUNICIPIO & ")")
            Else
                miComando.Parameters.AddWithValue("@NOMBRE", NOMBRE)
            End If

            miComando.Parameters.AddWithValue("@RFC", RFC)
            miComando.Parameters.AddWithValue("@CALLE", CALLE)
            miComando.Parameters.AddWithValue("@NUMEXT", "A")

            miComando.Parameters.AddWithValue("@COLONIA", COLONIA)
            miComando.Parameters.AddWithValue("@CODIGO", 1)
            miComando.Parameters.AddWithValue("@LOCALIDAD", MUNICIPIO)

            miComando.Parameters.AddWithValue("@ESTADO", ESTADO)
            miComando.Parameters.AddWithValue("@TELEFONO", TELEFONO)

            miComando.Parameters.AddWithValue("@CLASIFIC", CLASIFIC)
            miComando.Parameters.AddWithValue("@FAX", FAX)
            miComando.Parameters.AddWithValue("@PAG_WEB", PAG_WEB)

            miComando.Parameters.AddWithValue("@IMPRIR", "S")
            miComando.Parameters.AddWithValue("@MAIL", "N")
            miComando.Parameters.AddWithValue("@NIVELSEC", 0)
            miComando.Parameters.AddWithValue("@ENVIOSILEN", "N")

            miComando.Parameters.AddWithValue("@CON_CREDITO", "N")
            miComando.Parameters.AddWithValue("@DIASCRED", 0)
            miComando.Parameters.AddWithValue("@LIMCRED", 0)

            miComando.Parameters.AddWithValue("@SALDO", 0)
            miComando.Parameters.AddWithValue("@LISTA_PREC", DBNull.Value)
            miComando.Parameters.AddWithValue("@CVE_BITA", DBNull.Value)
            miComando.Parameters.AddWithValue("@ULT_PAGOD", DBNull.Value)
            miComando.Parameters.AddWithValue("@ULT_PAGOM", 0)
            miComando.Parameters.AddWithValue("@ULT_PAGOF", DBNull.Value)
            miComando.Parameters.AddWithValue("@DESCUENTO", 0)
            miComando.Parameters.AddWithValue("@ULT_VENTAD", DBNull.Value)
            miComando.Parameters.AddWithValue("@ULT_COMPM", 0)
            miComando.Parameters.AddWithValue("@FCH_ULTCOM", DBNull.Value)
            miComando.Parameters.AddWithValue("@VENTAS", 0)
            miComando.Parameters.AddWithValue("@CVE_VEND", VENDEDOR)
            miComando.Parameters.AddWithValue("@CVE_OBS", 0)
            miComando.Parameters.AddWithValue("@TIPO_EMPRESA", "M")
            'miComando.Parameters.AddWithValue("@MATRIZ", MATRIZ)
            miComando.Parameters.AddWithValue("@PROSPECTO", "N")

            miComando.Parameters.AddWithValue("@DES_IMPU1", "N")
            miComando.Parameters.AddWithValue("@DES_IMPU2", "N")
            miComando.Parameters.AddWithValue("@DES_IMPU3", "N")
            miComando.Parameters.AddWithValue("@DES_IMPU4", "N")
            miComando.Parameters.AddWithValue("@DES_PER", "N")
            miComando.Parameters.AddWithValue("@LAT_GENERAL", 0)
            miComando.Parameters.AddWithValue("@LON_GENERAL", 0)
            miComando.Parameters.AddWithValue("@LAT_ENVIO", DBNull.Value)
            miComando.Parameters.AddWithValue("@LON_ENVIO", DBNull.Value)

            miComando.Transaction = transaccion_sql
            miComando.ExecuteNonQuery()

            miComando = New SqlCommand("INSERT INTO SAE60Empre08.dbo.CLIE_CLIB08" &
                                        " (CVE_CLIE, CAMPLIB1, CAMPLIB2, CAMPLIB3, CAMPLIB7, CAMPLIB8, CAMPLIB14, CAMPLIB15, CAMPLIB17, CAMPLIB18, CAMPLIB22, CAMPLIB11) " &
                                        " VALUES (@CVE_CLIE, @CAMPLIB1, @CAMPLIB2, @CAMPLIB3, @CAMPLIB7, @CAMPLIB8, @CAMPLIB14, @CAMPLIB15, @CAMPLIB17, @CAMPLIB18, @CAMPLIB22, @CAMPLIB11)", ActualizarConexion)

            miComando.Parameters.AddWithValue("@CVE_CLIE", X)
            miComando.Parameters.AddWithValue("@CAMPLIB1", "CONTADO")
            miComando.Parameters.AddWithValue("@CAMPLIB2", CODIGO)
            miComando.Parameters.AddWithValue("@CAMPLIB11", EMPRESA)

            miComando.Parameters.AddWithValue("@CAMPLIB3", VISITA)
            miComando.Parameters.AddWithValue("@CAMPLIB7", NESTLE)
            miComando.Parameters.AddWithValue("@CAMPLIB8", COLGATE)
            miComando.Parameters.AddWithValue("@CAMPLIB14", LON)
            miComando.Parameters.AddWithValue("@CAMPLIB15", LAT)
            miComando.Parameters.AddWithValue("@CAMPLIB17", FECHACreacion.Date)
            miComando.Parameters.AddWithValue("@CAMPLIB18", FiltroNestle)
            miComando.Parameters.AddWithValue("@CAMPLIB22", FiltroCargill)

            miComando.Transaction = transaccion_sql
            miComando.ExecuteNonQuery()


            transaccion_sql.Commit()
            ActualizarConexion.Close()
            Return X
        Catch ex As Exception
            transaccion_sql.Rollback()
            ActualizarConexion.Close()
            Dim tamaño As Integer = Convert.ToString(ex.StackTrace).Length
            Dim posicion As Integer = InStrRev(Convert.ToString(ex.StackTrace), "línea") - 1
            Dim inicial As Integer = tamaño - posicion
            Dim linea_error As String = Convert.ToString(ex.StackTrace).Substring(tamaño - inicial, inicial)
            Return "Error: " & ex.Message & " " & linea_error
        End Try
        'Else
        'transaccion_sql.Rollback()
        'ActualizarConexion.Close()
        'Return ("El cliente ya se encuentra creado en DIMOSA")
        'End If

    End Function


    Public Function NuevoClienteSantaRosa(ByVal CLAVE As String, ByVal NOMBRE As String, ByVal PAG_WEB As String, ByVal RFC As String, ByVal MUNICIPIO As String, ByVal CALLE As String, ByVal COLONIA As String, ByVal ESTADO As String, ByVal TELEFONO As String, ByVal CLASIFIC As String, ByVal FAX As String, ByVal CVE_VEND As String, ByVal VENDEDOR As String, ByVal TIPOPAGO As String, ByVal VISITA As String, ByVal NESTLE As String, ByVal COLGATE As String, ByVal LON As String, ByVal LAT As String, ByVal FECHACreacion As Date, ByVal CLASIFICA As String, ByVal FiltroNestle As String, ByVal FiltroCargill As String)

        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand
            'Guarda nueva marca

            Dim NumBita As Integer = 0
            Dim DtBita As New DataTable
            Dim QueryBita As String
            QueryBita = "SELECT  MIN(SAE60Empre05.dbo.CLIE05.CLAVE)  FROM SAE60Empre05.dbo.CLIE05 WHERE SAE60Empre05.dbo.CLIE05.NOMBRE = '' and CLIE05.STATUS = 'S'"
            Dim CMDQueryBita As New SqlCommand(QueryBita, ActualizarConexion)
            Dim AdaptadorBita As New SqlDataAdapter(CMDQueryBita)
            CMDQueryBita.Transaction = transaccion_sql
            AdaptadorBita.Fill(DtBita)

            If DtBita.Rows.Count > 0 Then
                If Not IsDBNull(DtBita.Rows(0)(0)) Then
                    NumBita = DtBita.Rows(0)(0)
                End If
            End If


            Dim X As String = NumBita.ToString
            For a As Integer = X.Length To 9
                X = " " & X
            Next
            Dim Fecha As Date = Today.Date
            Dim DtFecha As New DataTable
            Dim QueryFecha As String
            QueryFecha = " SELECT GETDATE() as FECHA"
            Dim CMDQueryFecha As New SqlCommand(QueryFecha, ActualizarConexion)
            Dim AdaptadorFecha As New SqlDataAdapter(CMDQueryFecha)
            CMDQueryFecha.Transaction = transaccion_sql
            AdaptadorFecha.Fill(DtBita)

            If DtFecha.Rows.Count > 0 Then
                If Not IsDBNull(DtFecha.Rows(0)(0)) Then
                    Fecha = DtFecha.Rows(0)(0)
                End If
            End If

            Dim MATRIZ As String = ""
            Dim DtMATRIZ As New DataTable
            Dim QueryMATRIZ As String = ""
            QueryMATRIZ = " Select Max(MATRIZ) From CLIE05 Where MATRIZ <>'MOSTR' AND MATRIZ <> 'DINOR' AND MATRIZ <> 'D2'"
            Dim CMDQueryMATRIZ As New SqlCommand(QueryMATRIZ, ActualizarConexion)
            Dim AdaptadorMATRIZ As New SqlDataAdapter(CMDQueryMATRIZ)
            CMDQueryMATRIZ.Transaction = transaccion_sql
            AdaptadorFecha.Fill(DtMATRIZ)

            If DtMATRIZ.Rows.Count > 0 Then
                If Not IsDBNull(DtMATRIZ.Rows(0)(0)) Then
                    MATRIZ = DtMATRIZ.Rows(0)(0)
                End If
            End If

            miComando = New SqlCommand("UPDATE SAE60Empre05.dbo.CLIE05" & _
                                         " SET  STATUS = @STATUS, NOMBRE = @NOMBRE, RFC = @RFC, CALLE = @CALLE,NUMEXT = @NUMEXT, COLONIA = @COLONIA, CODIGO = @CODIGO, LOCALIDAD = @LOCALIDAD, ESTADO = @ESTADO, " & _
                      " TELEFONO = @TELEFONO, CLASIFIC = @CLASIFIC, FAX = @FAX, PAG_WEB = @PAG_WEB,  IMPRIR = @IMPRIR, MAIL = @MAIL, NIVELSEC = @NIVELSEC, ENVIOSILEN = @ENVIOSILEN,  " & _
                      " CON_CREDITO = @CON_CREDITO, DIASCRED = @DIASCRED, LIMCRED = @LIMCRED, SALDO = @SALDO, LISTA_PREC = @LISTA_PREC, CVE_BITA = @CVE_BITA, ULT_PAGOD = @ULT_PAGOD, ULT_PAGOM = @ULT_PAGOM, ULT_PAGOF = @ULT_PAGOF, DESCUENTO = @DESCUENTO, ULT_VENTAD = @ULT_VENTAD, ULT_COMPM = @ULT_COMPM,  " & _
                      " FCH_ULTCOM = @FCH_ULTCOM, VENTAS = @VENTAS, CVE_VEND = @CVE_VEND, CVE_OBS = @CVE_OBS, TIPO_EMPRESA = @TIPO_EMPRESA, PROSPECTO = @PROSPECTO,  " & _
                      " DES_IMPU1 = @DES_IMPU1, DES_IMPU2 = @DES_IMPU2, " & _
                      " DES_IMPU3 = @DES_IMPU3, DES_IMPU4 = @DES_IMPU4, DES_PER = @DES_PER, LAT_GENERAL = @LAT_GENERAL, LON_GENERAL = @LON_GENERAL, LAT_ENVIO = @LAT_ENVIO, LON_ENVIO = @LON_ENVIO WHERE CLAVE = @CLAVE ", ActualizarConexion)

            miComando.Parameters.AddWithValue("@CLAVE", X)
            miComando.Parameters.AddWithValue("@STATUS", "A")
            miComando.Parameters.AddWithValue("@NOMBRE", NOMBRE & " (" & MUNICIPIO & ")")
            miComando.Parameters.AddWithValue("@RFC", RFC)
            miComando.Parameters.AddWithValue("@CALLE", CALLE)
            miComando.Parameters.AddWithValue("@NUMEXT", "A")

            miComando.Parameters.AddWithValue("@COLONIA", COLONIA)
            miComando.Parameters.AddWithValue("@CODIGO", 1)
            miComando.Parameters.AddWithValue("@LOCALIDAD", MUNICIPIO)

            miComando.Parameters.AddWithValue("@ESTADO", ESTADO)
            miComando.Parameters.AddWithValue("@TELEFONO", TELEFONO)

            miComando.Parameters.AddWithValue("@CLASIFIC", CLASIFIC)
            miComando.Parameters.AddWithValue("@FAX", FAX)
            miComando.Parameters.AddWithValue("@PAG_WEB", PAG_WEB)

            miComando.Parameters.AddWithValue("@IMPRIR", "S")
            miComando.Parameters.AddWithValue("@MAIL", "N")
            miComando.Parameters.AddWithValue("@NIVELSEC", 0)
            miComando.Parameters.AddWithValue("@ENVIOSILEN", "N")

            miComando.Parameters.AddWithValue("@CON_CREDITO", "N")
            miComando.Parameters.AddWithValue("@DIASCRED", 0)
            miComando.Parameters.AddWithValue("@LIMCRED", 0)

            miComando.Parameters.AddWithValue("@SALDO", 0)
            miComando.Parameters.AddWithValue("@LISTA_PREC", DBNull.Value)
            miComando.Parameters.AddWithValue("@CVE_BITA", DBNull.Value)
            miComando.Parameters.AddWithValue("@ULT_PAGOD", DBNull.Value)
            miComando.Parameters.AddWithValue("@ULT_PAGOM", 0)
            miComando.Parameters.AddWithValue("@ULT_PAGOF", DBNull.Value)
            miComando.Parameters.AddWithValue("@DESCUENTO", 0)
            miComando.Parameters.AddWithValue("@ULT_VENTAD", DBNull.Value)
            miComando.Parameters.AddWithValue("@ULT_COMPM", 0)
            miComando.Parameters.AddWithValue("@FCH_ULTCOM", DBNull.Value)
            miComando.Parameters.AddWithValue("@VENTAS", 0)
            miComando.Parameters.AddWithValue("@CVE_VEND", VENDEDOR)
            miComando.Parameters.AddWithValue("@CVE_OBS", 0)
            miComando.Parameters.AddWithValue("@TIPO_EMPRESA", "M")
            'miComando.Parameters.AddWithValue("@MATRIZ", MATRIZ)
            miComando.Parameters.AddWithValue("@PROSPECTO", "N")

            miComando.Parameters.AddWithValue("@DES_IMPU1", "N")
            miComando.Parameters.AddWithValue("@DES_IMPU2", "N")
            miComando.Parameters.AddWithValue("@DES_IMPU3", "N")
            miComando.Parameters.AddWithValue("@DES_IMPU4", "N")
            miComando.Parameters.AddWithValue("@DES_PER", "N")
            miComando.Parameters.AddWithValue("@LAT_GENERAL", 0)
            miComando.Parameters.AddWithValue("@LON_GENERAL", 0)
            miComando.Parameters.AddWithValue("@LAT_ENVIO", DBNull.Value)
            miComando.Parameters.AddWithValue("@LON_ENVIO", DBNull.Value)

            miComando.Transaction = transaccion_sql
            miComando.ExecuteNonQuery()

            miComando = New SqlCommand("UPDATE SAE60Empre05.dbo.CLIE_CLIB05" & _
                                        " SET CAMPLIB1 = @CAMPLIB1, CAMPLIB2 = @CAMPLIB2, CAMPLIB3 = @CAMPLIB3, CAMPLIB7 = @CAMPLIB7, CAMPLIB8 = @CAMPLIB8, CAMPLIB14 = @CAMPLIB14, CAMPLIB15 = @CAMPLIB15, CAMPLIB17 = @CAMPLIB17, CAMPLIB18 = @CAMPLIB18, CAMPLIB22 = @CAMPLIB22 WHERE CVE_CLIE = @CVE_CLIE" & _
                                        "", ActualizarConexion)

            miComando.Parameters.AddWithValue("@CVE_CLIE", X)
            miComando.Parameters.AddWithValue("@CAMPLIB1", "CONTADO")
            miComando.Parameters.AddWithValue("@CAMPLIB2", "R")
            miComando.Parameters.AddWithValue("@CAMPLIB3", VISITA)
            miComando.Parameters.AddWithValue("@CAMPLIB7", NESTLE)
            miComando.Parameters.AddWithValue("@CAMPLIB8", COLGATE)
            miComando.Parameters.AddWithValue("@CAMPLIB14", LON)
            miComando.Parameters.AddWithValue("@CAMPLIB15", LAT)
            miComando.Parameters.AddWithValue("@CAMPLIB17", FECHACreacion.Date)
            miComando.Parameters.AddWithValue("@CAMPLIB18", FiltroNestle)
            miComando.Parameters.AddWithValue("@CAMPLIB22", FiltroCargill)

            miComando.Transaction = transaccion_sql
            miComando.ExecuteNonQuery()

            transaccion_sql.Commit()
            ActualizarConexion.Close()
            Return X
        Catch ex As Exception
            transaccion_sql.Rollback()
            ActualizarConexion.Close()
            Dim tamaño As Integer = Convert.ToString(ex.StackTrace).Length
            Dim posicion As Integer = InStrRev(Convert.ToString(ex.StackTrace), "línea") - 1
            Dim inicial As Integer = tamaño - posicion
            Dim linea_error As String = Convert.ToString(ex.StackTrace).Substring(tamaño - inicial, inicial)
            Return "Error: " & ex.Message & " " & linea_error
        End Try

    End Function

    Public Function TipoVendedor(ByVal Vendedor As String)
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT    PedidosHH_SANRAFAEL.dbo.USUARIOS.TIPO, dbo.VEND05.CORREOE " & _
                                        " FROM            dbo.VEND05 INNER JOIN " & _
                                        " PedidosHH_SANRAFAEL.dbo.USUARIOS ON PedidosHH_SANRAFAEL.dbo.USUARIOS.CVE_VEND = dbo.VEND05.CVE_VEND COLLATE MODERN_SPANISH_CI_AS WHERE dbo.VEND05.CVE_VEND = @Vendedor", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Vendedor", Vendedor)

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

    Public Function TipoVendedorDIMOSA(ByVal Vendedor As String)
        Dim ActualizarConexion As New SqlConnection(ConexionDIMOSA.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT   PedidosHH_DIMOSA.dbo.USUARIOS.TIPO, dbo.VEND06.CORREOE " & _
                                        " FROM            dbo.VEND06 INNER JOIN " & _
                                        " PedidosHH_DIMOSA.dbo.USUARIOS ON PedidosHH_DIMOSA.dbo.USUARIOS.CVE_VEND = dbo.VEND06.CVE_VEND COLLATE MODERN_SPANISH_CI_AS WHERE dbo.VEND06.CVE_VEND = @Vendedor", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Vendedor", Vendedor)

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

    Public Function SuspenderCliente(ByVal CLAVE As String, ByVal CVE_VEND As String)

        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand
            'Guarda nueva marca

            miComando = New SqlCommand("UPDATE SAE60Empre05.dbo.CLIE05" & _
                                         " SET CVE_VEND = '  100', STATUS = 'S' WHERE CLAVE = @CLIENTE ", ActualizarConexion)


            miComando.Parameters.AddWithValue("@CLIENTE", CLAVE)


            miComando.Transaction = transaccion_sql
            miComando.ExecuteNonQuery()

            miComando = New SqlCommand(" UPDATE SAE60Empre05.dbo.CLIE_CLIB05" & _
                                        " SET CAMPLIB20 = @FECHA, CAMPLIB21 = @VENDEDOR WHERE CVE_CLIE = @CLIENTE", ActualizarConexion)

            miComando.Parameters.AddWithValue("@CLIENTE", CLAVE)
            miComando.Parameters.AddWithValue("@FECHA", Today.Date)
            miComando.Parameters.AddWithValue("@VENDEDOR", Trim(CVE_VEND))

     
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
        End Try

    End Function

    Public Function ReactivarCliente(ByVal CLAVE As String)

        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try


            Dim Vendedor As String = ""
            Dim DtMATRIZ As New DataTable
            Dim QueryMATRIZ As String = ""
            QueryMATRIZ = " SELECT SAE60Empre05.dbo.CLIE_CLIB05.CAMPLIB21 From SAE60Empre05.dbo.CLIE_CLIB05 WHERE SAE60Empre05.dbo.CLIE_CLIB05.CVE_CLIE = @CLIENTE "
            Dim CMDQueryMATRIZ As New SqlCommand(QueryMATRIZ, ActualizarConexion)
            CMDQueryMATRIZ.Parameters.AddWithValue("@CLIENTE", CLAVE)
            Dim AdaptadorMATRIZ As New SqlDataAdapter(CMDQueryMATRIZ)
            CMDQueryMATRIZ.Transaction = transaccion_sql
            AdaptadorMATRIZ.Fill(DtMATRIZ)
            If DtMATRIZ.Rows.Count > 0 Then
                If Not IsDBNull(DtMATRIZ.Rows(0)(0)) Then
                    Vendedor = DtMATRIZ.Rows(0)(0)
                End If
            End If

            Try
                For X As Integer = Vendedor.Length To 4
                    Vendedor = " " & Vendedor
                Next
            Catch ex As Exception
            End Try

            Dim miComando As New SqlCommand
            miComando = New SqlCommand("UPDATE SAE60Empre05.dbo.CLIE05" & _
                                         " SET CVE_VEND = @Vendedor, STATUS = 'A' WHERE CLAVE = @CLIENTE ", ActualizarConexion)
            miComando.Parameters.AddWithValue("@CLIENTE", CLAVE)
            miComando.Parameters.AddWithValue("@Vendedor", Vendedor)
            miComando.Transaction = transaccion_sql
            miComando.ExecuteNonQuery()

            miComando = New SqlCommand(" UPDATE SAE60Empre05.dbo.CLIE_CLIB05" & _
                                        " SET CAMPLIB20 = @FECHA, CAMPLIB21 = @VENDEDOR WHERE CVE_CLIE = @CLIENTE", ActualizarConexion)
            miComando.Parameters.AddWithValue("@CLIENTE", CLAVE)
            miComando.Parameters.AddWithValue("@FECHA", DBNull.Value)
            miComando.Parameters.AddWithValue("@VENDEDOR", DBNull.Value)
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
        End Try

    End Function

    Public Function SuspenderClienteDIMOSA(ByVal CLAVE As String, ByVal CVE_VEND As String)

        Dim ActualizarConexion As New SqlConnection(ConexionDIMOSA.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand
            'Guarda nueva marca

            miComando = New SqlCommand("UPDATE SAE60Empre06.dbo.CLIE06" & _
                                         " SET CVE_VEND = '  100', STATUS = 'S' WHERE CLAVE = @CLIENTE ", ActualizarConexion)


            miComando.Parameters.AddWithValue("@CLIENTE", CLAVE)


            miComando.Transaction = transaccion_sql
            miComando.ExecuteNonQuery()

            miComando = New SqlCommand(" UPDATE SAE60Empre06.dbo.CLIE_CLIB06" & _
                                        " SET CAMPLIB20 = @FECHA, CAMPLIB21 = @VENDEDOR WHERE CVE_CLIE = @CLIENTE", ActualizarConexion)

            miComando.Parameters.AddWithValue("@CLIENTE", CLAVE)
            miComando.Parameters.AddWithValue("@FECHA", Today.Date)
            miComando.Parameters.AddWithValue("@VENDEDOR", Trim(CVE_VEND))


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
        End Try

    End Function

    Public Function ReactivarClienteDimosa(ByVal CLAVE As String)

        Dim ActualizarConexion As New SqlConnection(ConexionDIMOSA.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim Vendedor As String = ""
            Dim DtMATRIZ As New DataTable
            Dim QueryMATRIZ As String = ""
            QueryMATRIZ = " SELECT SAE60Empre06.dbo.CLIE_CLIB06.CAMPLIB21 From SAE60Empre06.dbo.CLIE_CLIB06 WHERE SAE60Empre06.dbo.CLIE_CLIB06.CVE_CLIE = @CLIENTE "
            Dim CMDQueryMATRIZ As New SqlCommand(QueryMATRIZ, ActualizarConexion)
            CMDQueryMATRIZ.Parameters.AddWithValue("@CLIENTE", CLAVE)
            Dim AdaptadorMATRIZ As New SqlDataAdapter(CMDQueryMATRIZ)
            CMDQueryMATRIZ.Transaction = transaccion_sql
            AdaptadorMATRIZ.Fill(DtMATRIZ)
            If DtMATRIZ.Rows.Count > 0 Then
                If Not IsDBNull(DtMATRIZ.Rows(0)(0)) Then
                    Vendedor = DtMATRIZ.Rows(0)(0)
                End If
            End If

            Try
                For X As Integer = Vendedor.Length To 4
                    Vendedor = " " & Vendedor
                Next
            Catch ex As Exception
            End Try

            Dim miComando As New SqlCommand
            miComando = New SqlCommand("UPDATE SAE60Empre06.dbo.CLIE06" & _
                                         " SET CVE_VEND = @Vendedor, STATUS = 'A' WHERE CLAVE = @CLIENTE ", ActualizarConexion)
            miComando.Parameters.AddWithValue("@CLIENTE", CLAVE)
            miComando.Parameters.AddWithValue("@Vendedor", Vendedor)
            miComando.Transaction = transaccion_sql
            miComando.ExecuteNonQuery()

            miComando = New SqlCommand(" UPDATE SAE60Empre06.dbo.CLIE_CLIB06" & _
                                        " SET CAMPLIB20 = @FECHA, CAMPLIB21 = @VENDEDOR WHERE CVE_CLIE = @CLIENTE", ActualizarConexion)
            miComando.Parameters.AddWithValue("@CLIENTE", CLAVE)
            miComando.Parameters.AddWithValue("@FECHA", DBNull.Value)
            miComando.Parameters.AddWithValue("@VENDEDOR", DBNull.Value)
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
        End Try

    End Function

    Public Function ModificarCliente(ByVal CLAVE As String, ByVal NOMBRE As String, ByVal PAG_WEB As String, ByVal CALLE As String, ByVal COLONIA As String, ByVal ESTADO As String, ByVal TELEFONO As String, ByVal VISITA As String, ByVal LON As String, ByVal LAT As String, ByVal Municipio As String, ByVal Departamento As String, ByVal Vendedor As String)

        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand
            'Guarda nueva marca

            miComando = New SqlCommand("UPDATE SAE60Empre05.dbo.CLIE05" & _
                      " SET CALLE = @CALLE, COLONIA = @COLONIA,  ESTADO = @ESTADO, " & _
                      " TELEFONO = @TELEFONO,  PAG_WEB = @PAG_WEB, RFC = @RFC, LOCALIDAD = @LOCALIDAD, NOMBRE = @NOMBRE, CVE_VEND = @CVE_VEND " & _
                      "  WHERE CLAVE = @CLAVE ", ActualizarConexion)

            miComando.Parameters.AddWithValue("@CLAVE", CLAVE)
            miComando.Parameters.AddWithValue("@CALLE", CALLE)

            miComando.Parameters.AddWithValue("@COLONIA", COLONIA)


            miComando.Parameters.AddWithValue("@ESTADO", ESTADO)
            miComando.Parameters.AddWithValue("@TELEFONO", TELEFONO)

            miComando.Parameters.AddWithValue("@PAG_WEB", PAG_WEB)

            miComando.Parameters.AddWithValue("@RFC", Departamento)
            miComando.Parameters.AddWithValue("@LOCALIDAD", Municipio)
            miComando.Parameters.AddWithValue("@NOMBRE", NOMBRE)

            miComando.Parameters.AddWithValue("@CVE_VEND", VENDEDOR)

            miComando.Transaction = transaccion_sql
            miComando.ExecuteNonQuery()

            miComando = New SqlCommand("UPDATE SAE60Empre05.dbo.CLIE_CLIB05" & _
                                        " SET CAMPLIB3 = @CAMPLIB3, CAMPLIB14 = @CAMPLIB14, CAMPLIB15 = @CAMPLIB15 WHERE CVE_CLIE = @CVE_CLIE" & _
                                        "", ActualizarConexion)

            miComando.Parameters.AddWithValue("@CVE_CLIE", CLAVE)

            miComando.Parameters.AddWithValue("@CAMPLIB3", VISITA)

            miComando.Parameters.AddWithValue("@CAMPLIB14", LON)
            miComando.Parameters.AddWithValue("@CAMPLIB15", LAT)

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
        End Try

    End Function

    Public Function ModificarClienteDIMOSA(ByVal CLAVE As String, ByVal NOMBRE As String, ByVal PAG_WEB As String, ByVal CALLE As String, ByVal COLONIA As String, ByVal ESTADO As String, ByVal TELEFONO As String, ByVal VISITA As String, ByVal LON As String, ByVal LAT As String, ByVal DEPARTAMENTO As String, ByVal MUNICIPIO As String, ByVal VENDEDOR As String)

        Dim ActualizarConexion As New SqlConnection(ConexionDIMOSA.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand
            'Guarda nueva marca

            miComando = New SqlCommand("UPDATE SAE60Empre06.dbo.CLIE06 SET " & _
                      " CALLE = @CALLE, COLONIA = @COLONIA,  ESTADO = @ESTADO, " & _
                      " TELEFONO = @TELEFONO,  PAG_WEB = @PAG_WEB, RFC = @RFC, LOCALIDAD = @LOCALIDAD, NOMBRE = @NOMBRE, CVE_VEND = @CVE_VEND  " & _
                      "  WHERE CLAVE = @CLAVE ", ActualizarConexion)

            miComando.Parameters.AddWithValue("@CLAVE", CLAVE)
            miComando.Parameters.AddWithValue("@CALLE", CALLE)

            miComando.Parameters.AddWithValue("@COLONIA", COLONIA)


            miComando.Parameters.AddWithValue("@ESTADO", ESTADO)
            miComando.Parameters.AddWithValue("@TELEFONO", TELEFONO)

            miComando.Parameters.AddWithValue("@PAG_WEB", PAG_WEB)

            miComando.Parameters.AddWithValue("@RFC", DEPARTAMENTO)
            miComando.Parameters.AddWithValue("@LOCALIDAD", MUNICIPIO)
            miComando.Parameters.AddWithValue("@NOMBRE", NOMBRE)

            miComando.Parameters.AddWithValue("@CVE_VEND", VENDEDOR)


            miComando.Transaction = transaccion_sql
            miComando.ExecuteNonQuery()

            miComando = New SqlCommand("UPDATE SAE60Empre06.dbo.CLIE_CLIB06" & _
                                        " SET CAMPLIB3 = @CAMPLIB3, CAMPLIB14 = @CAMPLIB14, CAMPLIB15 = @CAMPLIB15 WHERE CVE_CLIE = @CVE_CLIE" & _
                                        "", ActualizarConexion)

            miComando.Parameters.AddWithValue("@CVE_CLIE", CLAVE)

            miComando.Parameters.AddWithValue("@CAMPLIB3", VISITA)

            miComando.Parameters.AddWithValue("@CAMPLIB14", LON)
            miComando.Parameters.AddWithValue("@CAMPLIB15", LAT)

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
        End Try

    End Function


    Public Function ModificarClienteOPL(ByVal CLAVE As String, ByVal NOMBRE As String, ByVal PAG_WEB As String, ByVal CALLE As String, ByVal COLONIA As String, ByVal ESTADO As String, ByVal TELEFONO As String, ByVal VISITA As String, ByVal LON As String, ByVal LAT As String, ByVal DEPARTAMENTO As String, ByVal MUNICIPIO As String, ByVal VENDEDOR As String)

        Dim ActualizarConexion As New SqlConnection(ConexionOPL.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand
            'Guarda nueva marca

            miComando = New SqlCommand("UPDATE SAE60Empre08.dbo.CLIE08 SET " &
                      " CALLE = @CALLE, COLONIA = @COLONIA,  ESTADO = @ESTADO, " &
                      " TELEFONO = @TELEFONO,  PAG_WEB = @PAG_WEB, RFC = @RFC, LOCALIDAD = @LOCALIDAD, NOMBRE = @NOMBRE, CVE_VEND = @CVE_VEND  " &
                      "  WHERE CLAVE = @CLAVE ", ActualizarConexion)

            miComando.Parameters.AddWithValue("@CLAVE", CLAVE)
            miComando.Parameters.AddWithValue("@CALLE", CALLE)

            miComando.Parameters.AddWithValue("@COLONIA", COLONIA)


            miComando.Parameters.AddWithValue("@ESTADO", ESTADO)
            miComando.Parameters.AddWithValue("@TELEFONO", TELEFONO)

            miComando.Parameters.AddWithValue("@PAG_WEB", PAG_WEB)

            miComando.Parameters.AddWithValue("@RFC", DEPARTAMENTO)
            miComando.Parameters.AddWithValue("@LOCALIDAD", MUNICIPIO)
            miComando.Parameters.AddWithValue("@NOMBRE", NOMBRE)

            miComando.Parameters.AddWithValue("@CVE_VEND", VENDEDOR)


            miComando.Transaction = transaccion_sql
            miComando.ExecuteNonQuery()

            miComando = New SqlCommand("UPDATE SAE60Empre08.dbo.CLIE_CLIB08" &
                                        " SET CAMPLIB3 = @CAMPLIB3, CAMPLIB14 = @CAMPLIB14, CAMPLIB15 = @CAMPLIB15 WHERE CVE_CLIE = @CVE_CLIE" &
                                        "", ActualizarConexion)

            miComando.Parameters.AddWithValue("@CVE_CLIE", CLAVE)

            miComando.Parameters.AddWithValue("@CAMPLIB3", VISITA)

            miComando.Parameters.AddWithValue("@CAMPLIB14", LON)
            miComando.Parameters.AddWithValue("@CAMPLIB15", LAT)

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
        End Try

    End Function


    Public Function VerificarCoordenadas(ByVal CLAVE As String)

        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand
            'Guarda nueva marca

            miComando = New SqlCommand(" UPDATE SAE60Empre05.dbo.CLIE_CLIB05" &
                                        " SET CAMPLIB32 = 'SI' WHERE CVE_CLIE = @CLIENTE", ActualizarConexion)

            miComando.Parameters.AddWithValue("@CLIENTE", CLAVE)
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
        End Try

    End Function

    Public Function VerificarCoordenadasDIMOSA(ByVal CLAVE As String)

        Dim ActualizarConexion As New SqlConnection(ConexionDIMOSA.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand
            'Guarda nueva marca

            miComando = New SqlCommand(" UPDATE SAE60Empre06.dbo.CLIE_CLIB06" & _
                                        " SET CAMPLIB32 = 'SI' WHERE CVE_CLIE = @CLIENTE", ActualizarConexion)

            miComando.Parameters.AddWithValue("@CLIENTE", CLAVE)
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
        End Try

    End Function

    Public Function VerificarCoordenadasAGRO(ByVal CLAVE As String)

        Dim ActualizarConexion As New SqlConnection(ConexionAgro.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand
            'Guarda nueva marca

            miComando = New SqlCommand(" UPDATE SAE60Empre02.dbo.CLIE_CLIB02" & _
                                        " SET CAMPLIB27 = 'SI' WHERE CVE_CLIE = @CLIENTE", ActualizarConexion)

            miComando.Parameters.AddWithValue("@CLIENTE", CLAVE)
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
        End Try

    End Function

End Class
