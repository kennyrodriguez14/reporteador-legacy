Imports System.Data.SqlClient
Public Class cls_Sobrantes
    Dim Conexion As New clsConexion

    Public Function Insert(ByVal Fecha As DateTime, ByVal Codigo As String, ByVal Cantidad As Double, ByVal Ruta As String, _
                           ByVal Entregador As Integer, ByVal Observacion As String, ByVal sucursal As Integer, ByVal Verificacion As String, ByVal Empresa As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("INSERT INTO [Usuarios].[dbo].[Sobrantes] " & _
                                        "([Fecha],[Codigo],[Cantidad],[Ruta],[Entregador],[Observacion],sucursal,Verificacion, Empresa) " & _
                                        "VALUES (@Fecha,@Codigo,@Cantidad,@Ruta,@Entregador,@Observacion,@sucursal,@Verificacion,@Empresa) ", ActualizarConexion)
        miComando.Parameters.AddWithValue("@Fecha", Fecha)
        miComando.Parameters.AddWithValue("@Codigo", Codigo)
        miComando.Parameters.AddWithValue("@Cantidad", Cantidad)
        miComando.Parameters.AddWithValue("@Ruta", Ruta)
        miComando.Parameters.AddWithValue("@Entregador", Entregador)
        miComando.Parameters.AddWithValue("@Observacion", Observacion)
        miComando.Parameters.AddWithValue("@sucursal", sucursal)
        miComando.Parameters.AddWithValue("@Verificacion", Verificacion)
        miComando.Parameters.AddWithValue("@Empresa", Empresa)
        ActualizarConexion.Open()
        miComando.ExecuteNonQuery()
        ActualizarConexion.Close()
        Return True
    End Function

    Public Function llenar_combobox(ByVal EntregadorSucursal As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT EntregadorCodigo AS ID, EntregadorNombre AS NOMBRE " & _
                                        "FROM Entregadores Where EntregadorSucursal = @EntregadorSucursal", ActualizarConexion)
        ActualizarConexion.Open()
        miComando.Parameters.AddWithValue("@EntregadorSucursal", EntregadorSucursal)
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


    Public Function llenar_comboboxAgro(ByVal EntregadorSucursal As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT EntregadorCodigo AS ID, EntregadorNombre AS NOMBRE " & _
                                        "FROM Entregadores Where num_almacen_sr_agro = @EntregadorSucursal", ActualizarConexion)
        ActualizarConexion.Open()
        miComando.Parameters.AddWithValue("@EntregadorSucursal", EntregadorSucursal)
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

    Public Function listar(ByVal fecha As Date, ByVal fecha2 As Date, ByVal sucursal As Integer)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT  so.Id, so.Fecha, so.Codigo, iv.DESCR AS Producto, so.Cantidad, " & _
                                        " so.Ruta, en.EntregadorNombre AS Entregador, so.Observacion, dbo.BODEGA_VERIFICACION_SOBRANTES.Verificacion " & _
                                        "FROM dbo.Sobrantes so INNER JOIN dbo.Entregadores en ON so.Entregador = en.EntregadorCodigo " & _
                                        "LEFT OUTER JOIN SAE60Empre05.dbo.INVE05 iv ON so.Codigo = iv.CVE_ART  " & _
                                        "COLLATE MODERN_SPANISH_CI_AS LEFT OUTER JOIN dbo.BODEGA_VERIFICACION_SOBRANTES ON so.Verificacion = BODEGA_VERIFICACION_SOBRANTES.Id " & _
                                        "WHERE	so.Fecha >= @fecha AND so.Fecha <= @fecha2 and so.sucursal = @sucursal AND so.Empresa = 'SAN RAFAEL'", ActualizarConexion)
        ActualizarConexion.Open()
        miComando.Parameters.AddWithValue("@fecha", fecha)
        miComando.Parameters.AddWithValue("@fecha2", fecha2)
        miComando.Parameters.AddWithValue("@sucursal", sucursal)
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



    Public Function listarDimosa(ByVal fecha As Date, ByVal fecha2 As Date, ByVal sucursal As Integer)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT  so.Id, so.Fecha, so.Codigo, iv.DESCR AS Producto, so.Cantidad, " & _
                                        " so.Ruta, en.EntregadorNombre AS Entregador, so.Observacion, dbo.BODEGA_VERIFICACION_SOBRANTES.Verificacion " & _
                                        "FROM dbo.Sobrantes so INNER JOIN dbo.Entregadores en ON so.Entregador = en.EntregadorCodigo " & _
                                        "LEFT OUTER JOIN SAE60Empre06.dbo.INVE06 iv ON so.Codigo = iv.CVE_ART  " & _
                                        "COLLATE MODERN_SPANISH_CI_AS LEFT OUTER JOIN dbo.BODEGA_VERIFICACION_SOBRANTES ON so.Verificacion = BODEGA_VERIFICACION_SOBRANTES.Id " & _
                                        "WHERE	so.Fecha >= @fecha AND so.Fecha <= @fecha2 and so.sucursal = @sucursal AND so.Empresa = 'DIMOSA'", ActualizarConexion)
        ActualizarConexion.Open()
        miComando.Parameters.AddWithValue("@fecha", fecha)
        miComando.Parameters.AddWithValue("@fecha2", fecha2)
        miComando.Parameters.AddWithValue("@sucursal", sucursal)
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



    Public Function listarSrAgro(ByVal fecha As Date, ByVal fecha2 As Date, ByVal sucursal As Integer)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT  so.Id, so.Fecha, so.Codigo, iv.DESCR AS Producto, so.Cantidad, " & _
                                        " so.Ruta, en.EntregadorNombre AS Entregador, so.Observacion, dbo.BODEGA_VERIFICACION_SOBRANTES.Verificacion " & _
                                        "FROM dbo.Sobrantes so INNER JOIN dbo.Entregadores en ON so.Entregador = en.EntregadorCodigo " & _
                                        "LEFT OUTER JOIN SAE60Empre02.dbo.INVE02 iv ON so.Codigo = iv.CVE_ART  " & _
                                        "COLLATE MODERN_SPANISH_CI_AS LEFT OUTER JOIN dbo.BODEGA_VERIFICACION_SOBRANTES ON so.Verificacion = BODEGA_VERIFICACION_SOBRANTES.Id " & _
                                        "WHERE	so.Fecha >= @fecha AND so.Fecha <= @fecha2 and so.sucursal = @sucursal AND so.Empresa = 'SR AGRO'", ActualizarConexion)
        ActualizarConexion.Open()
        miComando.Parameters.AddWithValue("@fecha", fecha)
        miComando.Parameters.AddWithValue("@fecha2", fecha2)
        miComando.Parameters.AddWithValue("@sucursal", sucursal)
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

    Public Function verificacion()
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT Id, Verificacion " & _
                                        "FROM BODEGA_VERIFICACION_SOBRANTES", ActualizarConexion)
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

    Public Function CambiarVerificacion(ByVal Id As Integer, ByVal Verificacion As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())



        Dim miComando As New SqlCommand("UPDATE [Usuarios].[dbo].[Sobrantes] " & _
                                        "SET [Verificacion] = @Verificacion " & _
                                        "WHERE id =@id", ActualizarConexion)
        miComando.Parameters.AddWithValue("@id", Id)
        miComando.Parameters.AddWithValue("@Verificacion", Verificacion)
        ActualizarConexion.Open()
        miComando.ExecuteNonQuery()
        ActualizarConexion.Close()
        Return True
    End Function
End Class

