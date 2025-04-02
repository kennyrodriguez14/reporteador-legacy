Imports System.Data.SqlClient
Public Class clsProductosAveriados
    Dim Conexion As New clsConexion

    Public Function Insertar_Encabezados(ByVal Codigo As Integer, ByVal Fecha As Date, ByVal Cliente As String, ByVal sucursal As Integer, ByVal Empresa As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("INSERT INTO [Usuarios].[dbo].[productos_averiados] " & _
                                        "([Codigo],[Fecha],[Cliente],sucursal, Empresa) " & _
                                        "VALUES(@Codigo,@Fecha,@Cliente,@sucursal, @Empresa) ", ActualizarConexion)
        miComando.Parameters.AddWithValue("@Codigo", Codigo)
        miComando.Parameters.AddWithValue("@Fecha", Fecha)
        miComando.Parameters.AddWithValue("@Cliente", Cliente)
        miComando.Parameters.AddWithValue("@sucursal", sucursal)
        miComando.Parameters.AddWithValue("@Empresa", Empresa)
        ActualizarConexion.Open()
        Try
            miComando.ExecuteNonQuery()
            ActualizarConexion.Close()
            Return True
        Catch ex As Exception
            ActualizarConexion.Close()
            Return False
        End Try
    End Function

    Public Function Insertar_Detalle(ByVal AveriadoId As Integer, ByVal cve_art As String, ByVal observacion As String, ByVal Cantidad As Double)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("INSERT INTO [Usuarios].[dbo].[productos_averiados_detalle] " & _
                                        "([AveriadoId],[cve_art],[observacion],[Cantidad]) " & _
                                        "VALUES (@AveriadoId,@cve_art,@observacion,@Cantidad)", ActualizarConexion)
        miComando.Parameters.AddWithValue("@AveriadoId", AveriadoId)
        miComando.Parameters.AddWithValue("@cve_art", cve_art)
        miComando.Parameters.AddWithValue("@observacion", observacion)
        miComando.Parameters.AddWithValue("@Cantidad", Cantidad)
        ActualizarConexion.Open()
        Try
            miComando.ExecuteNonQuery()
            ActualizarConexion.Close()
            Return True
        Catch ex As Exception
            ActualizarConexion.Close()
            Return False
        End Try
    End Function


    Public Function GetId()
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT MAX(Codigo) FROM [Usuarios].[dbo].[productos_averiados] ", ActualizarConexion)
        ActualizarConexion.Open()
        Dim AdaptadorDeDatos As New SqlDataAdapter(miComando)
        Dim dt As New DataTable
        Try
            AdaptadorDeDatos.Fill(dt)
            ActualizarConexion.Close()
        Catch ex As SqlException
            MsgBox("Hay un problema con la conexión a los datos " & ex.Message, MsgBoxStyle.Critical)
        End Try
        If dt.Rows(0).Item(0) Is DBNull.Value Then
            ActualizarConexion.Close()
            Return 0
        Else
            ActualizarConexion.Close()
            Return dt.Rows(0).Item(0)
        End If
    End Function

    Public Function GetFacturas(ByVal fecha As Date, ByVal sucursal As Integer)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT Codigo AS ID, Fecha AS FECHA, Cliente AS CLIENTE, B.NOMBRE " & _
                                        "FROM dbo.productos_averiados A LEFT OUTER JOIN SAE60Empre05.dbo.CLIE05 B ON A.Cliente = B.CLAVE " & _
                                        "COLLATE MODERN_SPANISH_CI_AS WHERE Fecha = @FECHA AND sucursal = @sucursal and (Empresa = 'SAN RAFAEL' or Empresa is null )", ActualizarConexion)
        ActualizarConexion.Open()
        miComando.Parameters.AddWithValue("@FECHA", fecha)
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

    Public Function GetFacturasDimosa(ByVal fecha As Date, ByVal sucursal As Integer)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT Codigo AS ID, Fecha AS FECHA, Cliente AS CLIENTE, B.NOMBRE " & _
                                        "FROM dbo.productos_averiados A LEFT OUTER JOIN SAE60Empre06.dbo.CLIE06 B ON A.Cliente = B.CLAVE " & _
                                        "COLLATE MODERN_SPANISH_CI_AS WHERE Fecha = @FECHA AND sucursal = @sucursal and (Empresa = 'DIMOSA')", ActualizarConexion)
        ActualizarConexion.Open()
        miComando.Parameters.AddWithValue("@FECHA", fecha)
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
End Class
