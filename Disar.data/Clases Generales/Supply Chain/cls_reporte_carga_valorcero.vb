Imports System.Data.SqlClient

Public Class cls_reporte_carga_valorcero
    Dim Conexion As New clsconexion_consumo '_clsSRC
    Dim ConexionSIP As New cls_conexion_sip
    Dim ConexionSIPDIMOSA As New cls_conexion_sip_dimosa

    Public Function getAlmacen(ByVal DESDE As String, ByVal HASTA As String, ByVal SUCURSAL As String, ByVal FECHA As DateTime, _
                               ByVal CREDITO As String, ByVal TIPO As String, ByVal ALMACEN As Integer) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_reporte_carga_normal-TRABAJANDO", ActualizarConexion)
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

    Public Function RC(ByVal DESDE As String, ByVal HASTA As String, ByVal SUCURSAL As String, ByVal FECHA As DateTime, _
                       ByVal CREDITO As String, ByVal TIPO As String, ByVal ALMACEN As Integer) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_reporte_carga_normal-TRABAJANDO", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@DESDE", SqlDbType.VarChar)).Value = DESDE
        miComando.Parameters.Add(New SqlParameter("@HASTA", SqlDbType.VarChar)).Value = HASTA
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

    Public Function DatosEntrega(ByVal Factura1 As String, ByVal Factura2 As String) As DataTable
        'MsgBox(Factura1 & " " & Factura2)
        Dim ActualizarConexion As New SqlConnection(ConexionSIP.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT  LOTE_RUTA, LOTE_PESO, LOTE_MONTO, LOTE_VEHICULOID, NOMBRE,  FECHA_ENVIO_SAE FROM LOTES WHERE DOC_INI = '" & Factura1 & "' AND DOC_FIN = '" & Factura2 & "' ", ActualizarConexion)

        'miComando.Parameters.Add(New SqlParameter("@Fecha", SqlDbType.VarChar)).Value = Fecha

        'miComando.Parameters.Add(New SqlParameter("@Factura1", SqlDbType.VarChar)).Value = Factura1
        'miComando.Parameters.Add(New SqlParameter("@Factura2", SqlDbType.VarChar)).Value = Factura2


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

    Public Function DatosEntregaAGRO(ByVal Fecha As Date, ByVal Factura1 As String, ByVal Factura2 As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionSIP.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT  LOTE_RUTA, LOTE_PESO, LOTE_MONTO, LOTE_VEHICULOID, NOMBRE,  FECHA_ENVIO_SAE FROM PedidosHH_SR_AGRO.dbo.Lotes WHERE DOC_INI = '" & Factura1 & "' AND DOC_FIN = '" & Factura2 & "' ", ActualizarConexion)

        'miComando.Parameters.Add(New SqlParameter("@Fecha", SqlDbType.VarChar)).Value = Fecha

        'miComando.Parameters.Add(New SqlParameter("@Factura1", SqlDbType.VarChar)).Value = Factura1
        'miComando.Parameters.Add(New SqlParameter("@Factura2", SqlDbType.VarChar)).Value = Factura2


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

    Public Function DatosEntregaDIMOSA(ByVal Fecha As Date, ByVal Factura1 As String, ByVal Factura2 As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionSIPDIMOSA.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT  LOTE_RUTA, LOTE_PESO, LOTE_MONTO, LOTE_VEHICULOID, NOMBRE,  FECHA_ENVIO_SAE FROM LOTES WHERE DOC_INI = '" & Factura1 & "' AND DOC_FIN = '" & Factura2 & "' ", ActualizarConexion)

        'miComando.Parameters.Add(New SqlParameter("@Fecha", SqlDbType.VarChar)).Value = Fecha

        'miComando.Parameters.Add(New SqlParameter("@Factura1", SqlDbType.VarChar)).Value = Factura1
        'miComando.Parameters.Add(New SqlParameter("@Factura2", SqlDbType.VarChar)).Value = Factura2


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

    Public Function DatosEntregaOPL(ByVal Fecha As Date, ByVal Factura1 As String, ByVal Factura2 As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionSIPDIMOSA.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT  LOTE_RUTA, LOTE_PESO, LOTE_MONTO, LOTE_VEHICULOID, NOMBRE,  FECHA_ENVIO_SAE FROM PEDIDOSHH_OPL.dbo.LOTES WHERE DOC_INI = '" & Factura1 & "' AND DOC_FIN = '" & Factura2 & "' ", ActualizarConexion)

        'miComando.Parameters.Add(New SqlParameter("@Fecha", SqlDbType.VarChar)).Value = Fecha

        'miComando.Parameters.Add(New SqlParameter("@Factura1", SqlDbType.VarChar)).Value = Factura1
        'miComando.Parameters.Add(New SqlParameter("@Factura2", SqlDbType.VarChar)).Value = Factura2


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

    Public Function reporte_carga_acumulado(ByVal FECHA_INI As Date, ByVal FECHA_FIN As Date, ByVal TIPO As String, ByVal ALMACEN As Integer, ByVal SUCURSAL As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_reporte_carga_normal-TRABAJANDO", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.Date)).Value = FECHA_INI
        miComando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.Date)).Value = FECHA_FIN
        miComando.Parameters.Add(New SqlParameter("@TIPO", SqlDbType.VarChar)).Value = TIPO
        miComando.Parameters.Add(New SqlParameter("@ALMACEN", SqlDbType.Int)).Value = ALMACEN
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

    Public Function getFolioAgro(ByVal Almacen As Integer) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT FOLIO FROM PedidosHH_SR_AGRO.dbo.ALMACENES WHERE ALMACEN_ID = @ALMACEN", ActualizarConexion)

        miComando.Parameters.Add(New SqlParameter("@ALMACEN", SqlDbType.Int)).Value = Almacen

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

