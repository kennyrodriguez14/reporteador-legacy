Imports System.Data.SqlClient
Public Class clsRecurrencias

    Dim Conexion As New clsConexion
    Dim ConexionPROV As New clsconexion_SanRafael
    Dim ConexionPROVDIMOSA As New cls_conexion_DIMOSA

    Public Function Insert(ByVal Fecha As DateTime, ByVal Codigo_reportado As String, ByVal Codigo_apartado As String, ByVal Responsable As Integer, _
                            ByVal Solucion As Integer, ByVal Cantidad As Double, ByVal sucursal As Integer, ByVal Empresa As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("INSERT INTO [Usuarios].[dbo].[recurrencias_bodega] " & _
                                        "([Fecha],[Responsable],[Cantidad],[Codigo_apartado],[Codigo_reportado],[Solucion],sucursal,Empresa) " & _
                                        "VALUES (@Fecha,@Responsable,@Cantidad,@Codigo_apartado,@Codigo_reportado,@Solucion,@sucursal,@Empresa) ", ActualizarConexion)
        miComando.Parameters.AddWithValue("@Fecha", Fecha)
        miComando.Parameters.AddWithValue("@Responsable", Responsable)
        miComando.Parameters.AddWithValue("@Cantidad", Cantidad)
        miComando.Parameters.AddWithValue("@Codigo_apartado", Codigo_apartado)
        miComando.Parameters.AddWithValue("@Codigo_reportado", Codigo_reportado)
        miComando.Parameters.AddWithValue("@Solucion", Solucion)
        miComando.Parameters.AddWithValue("@sucursal", sucursal)
        miComando.Parameters.AddWithValue("@Empresa", Empresa)
        ActualizarConexion.Open()
        miComando.ExecuteNonQuery()
        ActualizarConexion.Close()
        Return True
    End Function

    Public Function InsertErrorProv(ByVal Fecha As DateTime, ByVal Codigo_reportado As String, ByVal Codigo_apartado As String, ByVal Responsable As Integer, _
                            ByVal Solucion As Integer, ByVal Cantidad As Double, ByVal sucursal As Integer, ByVal Empresa As String, ByVal Prov As String, ByVal ProvDetalle As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("INSERT INTO [Usuarios].[dbo].[Errores_Recepcion] " & _
                                        "([Fecha],[Responsable],[Cantidad],[Codigo_apartado],[Codigo_reportado],[Solucion],sucursal,Empresa, Cve_prov, Proveedor) " & _
                                        "VALUES (@Fecha,@Responsable,@Cantidad,@Codigo_apartado,@Codigo_reportado,@Solucion,@sucursal,@Empresa, @Cve_prov, @Proveedor) ", ActualizarConexion)
        miComando.Parameters.AddWithValue("@Fecha", Fecha)
        miComando.Parameters.AddWithValue("@Responsable", Responsable)
        miComando.Parameters.AddWithValue("@Cantidad", Cantidad)
        miComando.Parameters.AddWithValue("@Codigo_apartado", Codigo_apartado)
        miComando.Parameters.AddWithValue("@Codigo_reportado", Codigo_reportado)
        miComando.Parameters.AddWithValue("@Solucion", Solucion)
        miComando.Parameters.AddWithValue("@sucursal", sucursal)
        miComando.Parameters.AddWithValue("@Empresa", Empresa)
        miComando.Parameters.AddWithValue("@Cve_prov", Prov)
        miComando.Parameters.AddWithValue("@Proveedor", ProvDetalle)
        ActualizarConexion.Open()
        miComando.ExecuteNonQuery()
        ActualizarConexion.Close()
        Return True
    End Function

    Public Function GetDatos(ByVal fecha As Date, ByVal fecha2 As Date, ByVal sucursal As Integer)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT  REPLACE(REPLACE(REPLACE(REPLACE(dbo.recurrencias_bodega.sucursal,1,'SPS'),2,'SRC'),3,'SABA'),4,'TEGUS') AS Sucursal,dbo.recurrencias_bodega.Fecha, " & _
                                        "dbo.Encargados_Bodega.Nombre, dbo.recurrencias_bodega.Cantidad, " & _
                            "dbo.recurrencias_bodega.Codigo_apartado AS [Codigo Apartado], IV.DESCR AS [Producto Apartado],  " & _
                            "dbo.recurrencias_bodega.Codigo_reportado AS [Codigo Reportado], IV2.DESCR AS [Producto Reportado], " & _
                            "ROUND(IV.ULT_COSTO,2) AS Costo, ROUND((dbo.recurrencias_bodega.Cantidad*IV.ULT_COSTO),2) AS Total, " & _
                            "dbo.Soluciones_Bodega.SolucionDes AS Solucion " & _
                                        "FROM    dbo.recurrencias_bodega INNER JOIN " & _
                                  "dbo.Encargados_Bodega ON dbo.recurrencias_bodega.Responsable = dbo.Encargados_Bodega.EncargadoID INNER JOIN " & _
                                  "dbo.Soluciones_Bodega ON dbo.recurrencias_bodega.Solucion = dbo.Soluciones_Bodega.SolucionId INNER JOIN " & _
                                  "SAE60EMPRE05.dbo.INVE05 IV ON dbo.recurrencias_bodega.Codigo_apartado COLLATE Latin1_General_BIN = IV.CVE_ART INNER JOIN " & _
                                  "SAE60EMPRE05.dbo.INVE05 IV2 ON dbo.recurrencias_bodega.Codigo_reportado COLLATE Latin1_General_BIN = IV2.CVE_ART " & _
                                        " WHERE dbo.recurrencias_bodega.Fecha >= @fecha and dbo.recurrencias_bodega.Fecha <= @fecha2 and dbo.recurrencias_bodega.sucursal = @sucursal and Empresa = 'SAN RAFAEL'", ActualizarConexion)

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

    Public Function GetDatosDimosa(ByVal fecha As Date, ByVal fecha2 As Date, ByVal sucursal As Integer)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT  REPLACE(REPLACE(REPLACE(REPLACE(dbo.recurrencias_bodega.sucursal,1,'SPS'),2,'SRC'),3,'SABA'),4,'TEGUS') AS Sucursal,dbo.recurrencias_bodega.Fecha, " &
                                        "dbo.Encargados_Bodega.Nombre, dbo.recurrencias_bodega.Cantidad, " &
                            "dbo.recurrencias_bodega.Codigo_apartado AS [Codigo Apartado], IV.DESCR AS [Producto Apartado],  " &
                            "dbo.recurrencias_bodega.Codigo_reportado AS [Codigo Reportado], IV2.DESCR AS [Producto Reportado], " &
                            "ROUND(IV.ULT_COSTO,2) AS Costo, ROUND((dbo.recurrencias_bodega.Cantidad*IV.ULT_COSTO),2) AS Total, " &
                            "dbo.Soluciones_Bodega.SolucionDes AS Solucion " &
                                        "FROM    dbo.recurrencias_bodega INNER JOIN " &
                                  "dbo.Encargados_Bodega ON dbo.recurrencias_bodega.Responsable = dbo.Encargados_Bodega.EncargadoID INNER JOIN " &
                                  "dbo.Soluciones_Bodega ON dbo.recurrencias_bodega.Solucion = dbo.Soluciones_Bodega.SolucionId INNER JOIN " &
                                  "SAE60EMPRE06.dbo.INVE06 IV ON dbo.recurrencias_bodega.Codigo_apartado COLLATE Latin1_General_BIN = IV.CVE_ART INNER JOIN " &
                                  "SAE60EMPRE06.dbo.INVE06 IV2 ON dbo.recurrencias_bodega.Codigo_reportado COLLATE Latin1_General_BIN = IV2.CVE_ART " &
                                        " WHERE dbo.recurrencias_bodega.Fecha >= @fecha and dbo.recurrencias_bodega.Fecha <= @fecha2 and dbo.recurrencias_bodega.sucursal = @sucursal and Empresa = 'DIMOSA'", ActualizarConexion)

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

    Public Function GetDatosOPL(ByVal fecha As Date, ByVal fecha2 As Date, ByVal sucursal As Integer)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT  REPLACE(REPLACE(REPLACE(REPLACE(dbo.recurrencias_bodega.sucursal,1,'SPS'),2,'SRC'),3,'SABA'),4,'TEGUS') AS Sucursal,dbo.recurrencias_bodega.Fecha, " &
                                        "dbo.Encargados_Bodega.Nombre, dbo.recurrencias_bodega.Cantidad, " &
                            "dbo.recurrencias_bodega.Codigo_apartado AS [Codigo Apartado], IV.DESCR AS [Producto Apartado],  " &
                            "dbo.recurrencias_bodega.Codigo_reportado AS [Codigo Reportado], IV2.DESCR AS [Producto Reportado], " &
                            "ROUND(IV.ULT_COSTO,2) AS Costo, ROUND((dbo.recurrencias_bodega.Cantidad*IV.ULT_COSTO),2) AS Total, " &
                            "dbo.Soluciones_Bodega.SolucionDes AS Solucion " &
                                        "FROM    dbo.recurrencias_bodega INNER JOIN " &
                                  "dbo.Encargados_Bodega ON dbo.recurrencias_bodega.Responsable = dbo.Encargados_Bodega.EncargadoID INNER JOIN " &
                                  "dbo.Soluciones_Bodega ON dbo.recurrencias_bodega.Solucion = dbo.Soluciones_Bodega.SolucionId INNER JOIN " &
                                  "SAE60EMPRE08.dbo.INVE08 IV ON dbo.recurrencias_bodega.Codigo_apartado COLLATE Latin1_General_BIN = IV.CVE_ART INNER JOIN " &
                                  "SAE60EMPRE08.dbo.INVE08 IV2 ON dbo.recurrencias_bodega.Codigo_reportado COLLATE Latin1_General_BIN = IV2.CVE_ART " &
                                        " WHERE dbo.recurrencias_bodega.Fecha >= @fecha and dbo.recurrencias_bodega.Fecha <= @fecha2 and dbo.recurrencias_bodega.sucursal = @sucursal and Empresa = 'OPL'", ActualizarConexion)

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

    Public Function Soluciones()
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT SolucionId, SolucionDes " & _
                                        "FROM Soluciones_Bodega", ActualizarConexion)
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

    Public Function ProveedoresSanRafael()
        Dim ActualizarConexion As New SqlConnection(ConexionPROV.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT        CLAVE, NOMBRE  FROM            PROV05  WHERE        (STATUS = 'A') AND (CLASIFIC = 'P') ORDER BY NOMBRE ", ActualizarConexion)
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

    Public Function ProveedoresDIMOSA()
        Dim ActualizarConexion As New SqlConnection(ConexionPROVDIMOSA.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT        CLAVE, NOMBRE  FROM            PROV06  WHERE        (STATUS = 'A') AND (CLASIFIC = 'P') ORDER BY NOMBRE", ActualizarConexion)
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

    Public Function GetErrorRecepcion(ByVal fecha As Date, ByVal fecha2 As Date, ByVal sucursal As Integer)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT  REPLACE(REPLACE(REPLACE(REPLACE(dbo.Errores_Recepcion.sucursal,1,'SPS'),2,'SRC'),3,'SABA'),4,'TEGUS') AS Sucursal,dbo.Errores_Recepcion.Fecha, Cve_prov as 'Clave Prov', Proveedor, " & _
                                        "dbo.Encargados_Bodega.Nombre, dbo.Errores_Recepcion.Cantidad, " & _
                            "dbo.Errores_Recepcion.Codigo_apartado AS [Codigo Apartado], IV.DESCR AS [Producto Apartado],  " & _
                            "dbo.Errores_Recepcion.Codigo_reportado AS [Codigo Reportado], IV2.DESCR AS [Producto Reportado], " & _
                            "ROUND(IV.ULT_COSTO,2) AS Costo, ROUND((dbo.Errores_Recepcion.Cantidad * IV.ULT_COSTO),2) AS Total, " & _
                            "dbo.Soluciones_Bodega.SolucionDes AS Solucion " & _
                                        "FROM    dbo.Errores_Recepcion INNER JOIN " & _
                                  "dbo.Encargados_Bodega ON dbo.Errores_Recepcion.Responsable = dbo.Encargados_Bodega.EncargadoID INNER JOIN " & _
                                  "dbo.Soluciones_Bodega ON dbo.Errores_Recepcion.Solucion = dbo.Soluciones_Bodega.SolucionId INNER JOIN " & _
                                  "SAE60EMPRE05.dbo.INVE05 IV ON dbo.Errores_Recepcion.Codigo_apartado COLLATE Latin1_General_BIN = IV.CVE_ART INNER JOIN " & _
                                  "SAE60EMPRE05.dbo.INVE05 IV2 ON dbo.Errores_Recepcion.Codigo_reportado COLLATE Latin1_General_BIN = IV2.CVE_ART " & _
                                        " WHERE dbo.Errores_Recepcion.Fecha >= @fecha and dbo.Errores_Recepcion.Fecha <= @fecha2 and dbo.Errores_Recepcion.sucursal = @sucursal and Empresa = 'SAN RAFAEL'", ActualizarConexion)

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

    Public Function GetErrorRecepcionDimosa(ByVal fecha As Date, ByVal fecha2 As Date, ByVal sucursal As Integer)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT  REPLACE(REPLACE(REPLACE(REPLACE(dbo.Errores_Recepcion.sucursal,1,'SPS'),2,'SRC'),3,'SABA'),4,'TEGUS') AS Sucursal,dbo.Errores_Recepcion.Fecha, Cve_prov as 'Clave Prov', Proveedor,  " & _
                                        "dbo.Encargados_Bodega.Nombre, dbo.Errores_Recepcion.Cantidad, " & _
                            "dbo.Errores_Recepcion.Codigo_apartado AS [Codigo Apartado], IV.DESCR AS [Producto Apartado],  " & _
                            "dbo.Errores_Recepcion.Codigo_reportado AS [Codigo Reportado], IV2.DESCR AS [Producto Reportado], " & _
                            "ROUND(IV.ULT_COSTO,2) AS Costo, ROUND((dbo.Errores_Recepcion.Cantidad*IV.ULT_COSTO),2) AS Total, " & _
                            "dbo.Soluciones_Bodega.SolucionDes AS Solucion " & _
                                        "FROM    dbo.Errores_Recepcion INNER JOIN " & _
                                  "dbo.Encargados_Bodega ON dbo.Errores_Recepcion.Responsable = dbo.Encargados_Bodega.EncargadoID INNER JOIN " & _
                                  "dbo.Soluciones_Bodega ON dbo.Errores_Recepcion.Solucion = dbo.Soluciones_Bodega.SolucionId INNER JOIN " & _
                                  "SAE60EMPRE06.dbo.INVE06 IV ON dbo.Errores_Recepcion.Codigo_apartado COLLATE Latin1_General_BIN = IV.CVE_ART INNER JOIN " & _
                                  "SAE60EMPRE06.dbo.INVE06 IV2 ON dbo.Errores_Recepcion.Codigo_reportado COLLATE Latin1_General_BIN = IV2.CVE_ART " & _
                                        " WHERE dbo.Errores_Recepcion.Fecha >= @fecha and dbo.Errores_Recepcion.Fecha <= @fecha2 and dbo.Errores_Recepcion.sucursal = @sucursal and Empresa = 'DIMOSA'", ActualizarConexion)

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

End Class






