Imports System.Data.SqlClient
Public Class cls_carga_camiones_formatofactura
    Dim Conexion As New clsConexion
    Dim Conexion2 As New clsconexion_consumo
    Public Function Encabezado(ByVal TransaccionId As Integer, ByVal sucursal As Integer, ByVal Fecha As Date, ByVal turno As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("INSERT INTO [Usuarios].[dbo].[BODEGA_CARGACAMIONES_ENCABEZADO] " & _
                                        " ([TransaccionId],[Sucursal],[Fecha],[Turno]) " & _
                                        " VALUES (@TransaccionId,@Sucursal,@Fecha,@Turno)", ActualizarConexion)
        miComando.Parameters.AddWithValue("@TransaccionId", TransaccionId)
        miComando.Parameters.AddWithValue("@Sucursal", sucursal)
        miComando.Parameters.AddWithValue("@Fecha", Fecha)
        miComando.Parameters.AddWithValue("@Turno", turno)
        miComando.CommandTimeout = 2000
        ActualizarConexion.Open()
        miComando.ExecuteNonQuery()
        ActualizarConexion.Close()
        Return True
    End Function

    Public Function Partidas(ByVal TransaccionId As Integer, ByVal PartidaId As Integer, ByVal Camion As String, ByVal FacturaInicial As String, _
        ByVal FecturaFinal As String, ByVal ReporteSacado As String, ByVal TiempoSacado As Double, ByVal TipoReporte As String, _
        ByVal ReporteChequeado As String, ByVal TiempoChequeado As Double, ByVal ReporteCargado As String, _
        ByVal TiempoCargado As Double, ByVal Observacion As String, ByVal Peso As Double)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("INSERT INTO [Usuarios].[dbo].[BODEGA_CARGACAMIONES_PARTIDAS] " & _
            "([TransaccionId],[PartidaId],[Camion],[FacturaInicial],[FecturaFinal] " & _
            ",[ReporteSacado],[TiempoSacado],[TipoReporte],[ReporteChequeado],[TiempoChequeado] " & _
            ",[ReporteCargado],[TiempoCargado],[Observacion],[Peso]) " & _
            "VALUES(@TransaccionId,@PartidaId,@Camion,@FacturaInicial,@FecturaFinal,@ReporteSacado, " & _
            "@TiempoSacado, @TipoReporte, @ReporteChequeado, @TiempoChequeado, @ReporteCargado, " & _
            "@TiempoCargado,@Observacion,@Peso) ", ActualizarConexion)
        miComando.Parameters.AddWithValue("@TransaccionId", TransaccionId)
        miComando.Parameters.AddWithValue("@PartidaId", PartidaId)
        miComando.Parameters.AddWithValue("@Camion", Camion)
        miComando.Parameters.AddWithValue("@FacturaInicial", FacturaInicial)
        miComando.Parameters.AddWithValue("@FecturaFinal", FecturaFinal)
        miComando.Parameters.AddWithValue("@ReporteSacado", ReporteSacado)
        miComando.Parameters.AddWithValue("@TiempoSacado", TiempoSacado)
        miComando.Parameters.AddWithValue("@TipoReporte", TipoReporte)
        miComando.Parameters.AddWithValue("@ReporteChequeado", ReporteChequeado)
        miComando.Parameters.AddWithValue("@TiempoChequeado", TiempoChequeado)
        miComando.Parameters.AddWithValue("@ReporteCargado", ReporteCargado)
        miComando.Parameters.AddWithValue("@TiempoCargado", TiempoCargado)
        If Observacion Is DBNull.Value Then
            Observacion = ""
        End If
        miComando.Parameters.AddWithValue("@Observacion", Observacion)
        miComando.Parameters.AddWithValue("@Peso", Peso)
        miComando.CommandTimeout = 2000
        ActualizarConexion.Open()
        miComando.ExecuteNonQuery()
        ActualizarConexion.Close()
        Return True
    End Function

    Public Function GetId()
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT MAX(ISNULL(TransaccionId, 0) + 1) AS Codigo FROM [Usuarios].[dbo].[BODEGA_CARGACAMIONES_ENCABEZADO]", ActualizarConexion)
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
        If dt.Rows(0).Item(0) Is DBNull.Value Then
            Return 0
        Else
            Return dt.Rows(0).Item(0)
        End If
    End Function

    Public Function getAlmacen(ByVal DESDE As String, ByVal HASTA As String, ByVal SUCURSAL As String, ByVal FECHA As DateTime, _
                              ByVal CREDITO As String, ByVal TIPO As String, ByVal ALMACEN As Integer) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim miComando As New SqlCommand("rptn_reporte_carga_normal", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@DESDE", SqlDbType.Int)).Value = DESDE
        miComando.Parameters.Add(New SqlParameter("@HASTA", SqlDbType.Int)).Value = HASTA
        miComando.Parameters.Add(New SqlParameter("@SUCURSAL", SqlDbType.VarChar)).Value = SUCURSAL
        miComando.Parameters.Add(New SqlParameter("@FECHA", SqlDbType.DateTime)).Value = FECHA
        miComando.Parameters.Add(New SqlParameter("@CREDITO", SqlDbType.VarChar)).Value = CREDITO
        miComando.Parameters.Add(New SqlParameter("@TIPO", SqlDbType.VarChar)).Value = TIPO
        miComando.Parameters.Add(New SqlParameter("@ALMACEN", SqlDbType.Int)).Value = ALMACEN
        ActualizarConexion.Open()
        miComando.CommandTimeout = 2000
        Dim AdaptadorDeDatos As New SqlDataAdapter(miComando)
        Dim dt As New DataTable
        Try
            AdaptadorDeDatos.Fill(dt)
            ActualizarConexion.Close()
        Catch ex As SqlException
            MsgBox("Hay un problema con la conexión a los datos " & ex.Message, MsgBoxStyle.Critical)
        End Try
        ActualizarConexion.Close()
        Return dt
    End Function

    Public Function select_tipo_reporte()
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT Id, Tipo_Reporte FROM Tipo_Reporte ", ActualizarConexion)
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

    Public Function select_camion(ByVal sucursal As Integer)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT VehiculoId, VehiculoDescripcion FROM Vehiculos_Entregadores Where Sucursal = @Sucursal ", ActualizarConexion)
        ActualizarConexion.Open()
        miComando.Parameters.AddWithValue("@Sucursal", sucursal)
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

    Public Function select_colaborador(ByVal sucursal As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT EncargadoID, Nombre FROM Encargados_Bodega Where Sucursal = @Sucursal", ActualizarConexion)
        ActualizarConexion.Open()
        miComando.Parameters.AddWithValue("@Sucursal", sucursal)
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

    Public Function get_encabezado(ByVal FECHA_INI As Date, ByVal FECHA_FIN As Date, ByVal ALMACEN As Integer)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT	TransaccionId AS Id, ALM.DESCR AS Sucursal, CONVERT(VARCHAR,Fecha,103) AS Fecha, Turno " & _
                                        "FROM	dbo.BODEGA_CARGACAMIONES_ENCABEZADO ENCA INNER JOIN " & _
                                        " SAE60Empre05.dbo.ALMACENES05 ALM ON ALM.CVE_ALM = ENCA.Sucursal " & _
                                        " WHERE Fecha >= @FECHA_INI AND Fecha <= @FECHA_FIN AND ALM.CVE_ALM = @ALMACEN", ActualizarConexion)
        ActualizarConexion.Open()
        miComando.Parameters.AddWithValue("@FECHA_INI", FECHA_INI)
        miComando.Parameters.AddWithValue("@FECHA_FIN", FECHA_FIN)
        miComando.Parameters.AddWithValue("@ALMACEN", ALMACEN)
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

    Public Function get_partidas(ByVal TransaccionId As Integer)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT Camion, FacturaInicial, FecturaFinal, ReporteSacado, TiempoSacado, TipoReporte, " & _
                                        "ReporteChequeado, TiempoChequeado, ReporteCargado, TiempoCargado, Observacion " & _
                                        "FROM  BODEGA_CARGACAMIONES_PARTIDAS " & _
                                        "WHERE TransaccionId = @TransaccionId", ActualizarConexion)
        ActualizarConexion.Open()
        miComando.Parameters.AddWithValue("@TransaccionId", TransaccionId)
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

    Public Function GetReporte(ByVal FECHA_INI As Date, ByVal FECHA_FIN As Date, ByVal ALMACEN As Integer, _
                               ByVal TIPO As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("dsr_BODEGA_CARGA_CAMIONES ", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.Date)).Value = FECHA_INI
        miComando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.Date)).Value = FECHA_FIN
        miComando.Parameters.Add(New SqlParameter("@ALMACEN", SqlDbType.Int)).Value = ALMACEN
        miComando.Parameters.Add(New SqlParameter("@TIPO", SqlDbType.VarChar)).Value = TIPO
        miComando.CommandTimeout = 5000
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
