Imports System.Data.SqlClient
Public Class cls_bonificaciones
    Dim Conexion As New clsconexion_consumo
    Dim Conexion2 As New clsConexion
    Dim ConexionDIMOSA As New cls_conexion_DIMOSA

    Public Function rptn_bonos_nuevos(ByVal FECHA_INI As Date, ByVal FECHA_FIN As Date, ByVal CVE_VEND As String, ByVal TIPO As String, _
                                      ByVal EMPRESA As String, ByVal SUPERVISOR As Integer) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_reporte_bonos", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.AddWithValue("@FECHA_INI", FECHA_INI)
        miComando.Parameters.AddWithValue("@FECHA_FIN", FECHA_FIN)
        miComando.Parameters.AddWithValue("@CVE_VEND", CVE_VEND)
        miComando.Parameters.AddWithValue("@TIPO", TIPO)
        miComando.Parameters.AddWithValue("@EMPRESA", EMPRESA)
        miComando.Parameters.AddWithValue("@SUPERVISOR", SUPERVISOR)
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

    Public Function Bonificaciones_Ventas(ByVal FECHA_INI As Date, ByVal FECHA_FIN As Date, _
                                          ByVal CVE_VEND As String, ByVal TIPO As String, ByVal PORCENTAJE As Double, ByVal Empresa As String) As DataTable
        Dim ActualizarConexion As New SqlConnection
        If Empresa = "SAN RAFAEL" Then
            ActualizarConexion = New SqlConnection(Conexion.CadenaSQL())
        ElseIf Empresa = "DIMOSA" Then
            ActualizarConexion = New SqlConnection(ConexionDIMOSA.CadenaSQL())
        End If


        Dim miComando As New SqlCommand("rptn_bonificaciones_det_vendedor", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.Date)).Value = FECHA_INI
        miComando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.Date)).Value = FECHA_FIN
        miComando.Parameters.Add(New SqlParameter("@CVE_VEND", SqlDbType.VarChar)).Value = CVE_VEND
        miComando.Parameters.Add(New SqlParameter("@TIPO", SqlDbType.VarChar)).Value = TIPO
        miComando.Parameters.Add(New SqlParameter("@PORCENTAJE", SqlDbType.Float)).Value = PORCENTAJE
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

    Public Function VerCPE(ByVal Vendedor As String) As DataTable
        Dim ActualizarConexion As New SqlConnection

        ActualizarConexion = New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT        AFECTA_CPE  FROM           USUARIOS.dbo.supervisor_vendedor_jefe  WHERE        (CVE_VEND = @CVE_VEND)", ActualizarConexion)


        miComando.Parameters.Add(New SqlParameter("@CVE_VEND", SqlDbType.VarChar)).Value = Vendedor

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


    Public Function Bonificaciones_VentasMatinal(ByVal FECHA_INI As Date, ByVal FECHA_FIN As Date, _
                                          ByVal CVE_VEND As String, ByVal TIPO As String, ByVal PORCENTAJE As Double) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_matinal_det_vendedor", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.Date)).Value = FECHA_INI
        miComando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.Date)).Value = FECHA_FIN
        miComando.Parameters.Add(New SqlParameter("@CVE_VEND", SqlDbType.VarChar)).Value = CVE_VEND
        miComando.Parameters.Add(New SqlParameter("@TIPO", SqlDbType.VarChar)).Value = TIPO
        miComando.Parameters.Add(New SqlParameter("@PORCENTAJE", SqlDbType.Float)).Value = PORCENTAJE
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

    Public Function Bonificaciones_VentasMatinalDIMOSA(ByVal FECHA_INI As Date, ByVal FECHA_FIN As Date, _
                                          ByVal CVE_VEND As String, ByVal TIPO As String, ByVal PORCENTAJE As Double) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionDIMOSA.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_matinal_det_vendedor", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.Date)).Value = FECHA_INI
        miComando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.Date)).Value = FECHA_FIN
        miComando.Parameters.Add(New SqlParameter("@CVE_VEND", SqlDbType.VarChar)).Value = CVE_VEND
        miComando.Parameters.Add(New SqlParameter("@TIPO", SqlDbType.VarChar)).Value = TIPO
        miComando.Parameters.Add(New SqlParameter("@PORCENTAJE", SqlDbType.Float)).Value = PORCENTAJE
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

    Public Function Bonificaciones_Ventas_May(ByVal FECHA_INI As Date, ByVal FECHA_FIN As Date, _
                                          ByVal CVE_VEND As String, ByVal TIPO As String, ByVal PORCENTAJE As Double) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_bonificaciones_may_vendedor", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.Date)).Value = FECHA_INI
        miComando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.Date)).Value = FECHA_FIN
        miComando.Parameters.Add(New SqlParameter("@CVE_VEND", SqlDbType.VarChar)).Value = CVE_VEND
        miComando.Parameters.Add(New SqlParameter("@TIPO", SqlDbType.VarChar)).Value = TIPO
        miComando.Parameters.Add(New SqlParameter("@PORCENTAJE", SqlDbType.Float)).Value = PORCENTAJE
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

    Public Function Bonificaciones_Ventas_May_Super(ByVal FECHA_INI As Date, ByVal FECHA_FIN As Date, _
                                          ByVal CVE_VEND As String, ByVal TIPO As String, ByVal PORCENTAJE As Double, ByVal ALMACEN As Integer) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_bonificaciones_ventas_may_supervisor", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.Date)).Value = FECHA_INI
        miComando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.Date)).Value = FECHA_FIN
        miComando.Parameters.Add(New SqlParameter("@CVE_VEND", SqlDbType.VarChar)).Value = CVE_VEND
        miComando.Parameters.Add(New SqlParameter("@TIPO", SqlDbType.VarChar)).Value = TIPO
        miComando.Parameters.Add(New SqlParameter("@PORCENTAJE", SqlDbType.Float)).Value = PORCENTAJE
        miComando.Parameters.Add(New SqlParameter("@ALMACEN", SqlDbType.Int)).Value = ALMACEN
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

    Public Function Bonificaciones_Ventas_Det_Super(ByVal FECHA_INI As Date, ByVal FECHA_FIN As Date, _
                                          ByVal CVE_VEND As String, ByVal TIPO As String, ByVal PORCENTAJE As Double, ByVal ALMACEN As Integer) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_bonificaciones_ventas_det_supervisor", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.Date)).Value = FECHA_INI
        miComando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.Date)).Value = FECHA_FIN
        miComando.Parameters.Add(New SqlParameter("@CVE_VEND", SqlDbType.VarChar)).Value = CVE_VEND
        miComando.Parameters.Add(New SqlParameter("@TIPO", SqlDbType.VarChar)).Value = TIPO
        miComando.Parameters.Add(New SqlParameter("@PORCENTAJE", SqlDbType.Float)).Value = PORCENTAJE
        miComando.Parameters.Add(New SqlParameter("@ALMACEN", SqlDbType.Int)).Value = ALMACEN

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

    Public Function SUPERVISOR(ByVal Super As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT        dbo.Supervisores.SUPERVISOR " & _
        "FROM            dbo.Supervisor_Vendedor INNER JOIN " & _
         "                dbo.Supervisores ON dbo.Supervisor_Vendedor.SUPERVISOR = dbo.Supervisores.CODIGO_SUPERVISOR  WHERE CVE_VEND = @CVE_VEND", ActualizarConexion)

        miComando.Parameters.Add(New SqlParameter("@CVE_VEND", SqlDbType.VarChar)).Value = Super


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

