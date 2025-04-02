Imports System.Data.SqlClient
Public Class clsMalasCargas
    Dim Conexion As New clsConexion
    Dim Conexion2 As New clsconexion_consumo
    Dim ConexionDimosa As New cls_conexion_DIMOSA

    Public Function Insert(ByVal Fecha As DateTime, ByVal Cantidad As Double, ByVal Codigo_Reporte As String, ByVal Codigo_Cargado As String, _
                           ByVal Encargado As Integer, ByVal Observacion As String, ByVal sucursal As Integer)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("INSERT INTO [Usuarios].[dbo].[Malas_Cargas] " & _
                                        "([Fecha],[Cantidad],[Codigo_Reporte],[Codigo_Cargado],[Encargado],[Observacion],sucursal) " & _
                                        " VALUES (@Fecha,@Cantidad,@Codigo_Reporte,@Codigo_Cargado,@Encargado,@Observacion,@sucursal)", ActualizarConexion)
        miComando.Parameters.AddWithValue("@Fecha", Fecha)
        miComando.Parameters.AddWithValue("@Cantidad", Cantidad)
        miComando.Parameters.AddWithValue("@Codigo_Reporte", Codigo_Reporte)
        miComando.Parameters.AddWithValue("@Codigo_Cargado", Codigo_Cargado)
        miComando.Parameters.AddWithValue("@Encargado", Encargado)
        miComando.Parameters.AddWithValue("@Observacion", Observacion)
        miComando.Parameters.AddWithValue("@sucursal", sucursal)
        ActualizarConexion.Open()
        miComando.ExecuteNonQuery()
        ActualizarConexion.Close()
        Return True
    End Function


    Public Function llenar_combobox()
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT EncargadoID AS ID, Nombre AS NOMBRE " & _
                                        "FROM Encargados_Bodega", ActualizarConexion)
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


    Public Function Listar(ByVal FECHA_INI As Date, ByVal FECHA_FIN As Date, ByVal sucursal As Integer)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT	REPLACE(REPLACE(Malas_Cargas.sucursal,1,'SRC'),2,'SPS') AS Sucursal,dbo.Malas_Cargas.Fecha, dbo.Malas_Cargas.Cantidad, dbo.Malas_Cargas.Codigo_Reporte AS [Codigo Reporte], " & _
         "IV.DESCR AS [Producto Reporte], dbo.Malas_Cargas.Codigo_Cargado AS [Codigo Cargado], IV2.DESCR AS [Producto Cargado],  " & _
         " dbo.Encargados_Bodega.Nombre AS Encargado, dbo.Malas_Cargas.Cantidad * ISNULL(LP.PRECIO,0) AS Valor " & _
                        "FROM dbo.Malas_Cargas INNER JOIN " & _
         "dbo.Encargados_Bodega ON dbo.Malas_Cargas.Encargado = dbo.Encargados_Bodega.EncargadoID INNER JOIN " & _
         "SAE60EMPRE05.dbo.INVE05 IV ON dbo.Malas_Cargas.Codigo_Reporte =IV.CVE_ART COLLATE Latin1_General_BIN INNER JOIN  " & _
         "SAE60EMPRE05.dbo.INVE05 IV2 ON dbo.Malas_Cargas.Codigo_Cargado =IV2.CVE_ART COLLATE Latin1_General_BIN  FULL OUTER JOIN  " & _
         "dbo.lista_productos LP ON dbo.Malas_Cargas.Codigo_Reporte COLLATE Latin1_General_BIN = LP.CVE_ART " & _
                        "WHERE     (dbo.Malas_Cargas.Fecha >= @FECHA_INI) AND (dbo.Malas_Cargas.Fecha <= @FECHA_FIN) AND (dbo.Malas_Cargas.sucursal =  @sucursal )", ActualizarConexion)
        ActualizarConexion.Open()
        Dim AdaptadorDeDatos As New SqlDataAdapter(miComando)
        miComando.Parameters.AddWithValue("@FECHA_INI", FECHA_INI)
        miComando.Parameters.AddWithValue("@FECHA_FIN", FECHA_FIN)
        miComando.Parameters.AddWithValue("@sucursal", sucursal)
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

    Public Function ayuda_productosDimosa(ByVal CLAVE As String, ByVal NOMBRE As String)
        Dim ActualizarConexion As New SqlConnection(ConexionDimosa.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT IV.CVE_ART AS [CODIGO], IV.DESCR AS [PRODUCTO] " & _
                                        "FROM dbo.INVE06 IV " & _
                                        "WHERE   UPPER(IV.DESCR) LIKE '%" + NOMBRE + "%'", ActualizarConexion)
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


    Public Function ayuda_productos(ByVal CLAVE As String, ByVal NOMBRE As String)
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT IV.CVE_ART AS [CODIGO], IV.DESCR AS [PRODUCTO] " & _
                                        "FROM dbo.INVE05 IV " & _
                                        "WHERE   UPPER(IV.DESCR) LIKE '%" + NOMBRE + "%'", ActualizarConexion)
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
    Public Function ayuda_encargados(ByVal CLAVE As String, ByVal NOMBRE As String, ByVal Sucursal As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())


        Dim miComando As New SqlCommand("SELECT EncargadoID AS Id, Nombre, Sucursal " & _
                                        " FROM Encargados_Bodega " & _
                                        "WHERE Nombre LIKE '%" + NOMBRE + "%' AND Sucursal = @Sucursal", ActualizarConexion)
        ActualizarConexion.Open()

        miComando.Parameters.AddWithValue("@Sucursal", Sucursal)
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





