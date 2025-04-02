Imports Disar.data
Imports System.Data.SqlClient
Imports System.Text

Public Class ClsPromociones

    Dim Conexion As New clsconexion_consumo
    Dim Conexion2 As New clsconexion_sr_agro
    Dim Conexion3 As New cls_conexion_DIMOSA
    Dim Conexion4 As New cls_conexionOPL



    Public Function PromocionesSanRafael(ByVal fechaini As Date, ByVal fechafin As Date)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand(" SELECT     dbo.MINVE05.FECHA_DOCU AS FECHA, MONTH(dbo.MINVE05.FECHA_DOCU) AS MES, dbo.ALMACENES05.DESCR AS ALMACEN, dbo.MINVE05.CVE_ART AS CLAVE, " & _
                     " dbo.INVE05.DESCR AS DESCRIPCION, dbo.MINVE05.CVE_CPTO AS CLAVE_CON, dbo.CONM05.DESCR AS CONCEPTO, dbo.MINVE05.CANT AS CANTIDAD, " & _
                     " dbo.MINVE05.COSTO, dbo.MINVE05.CANT * dbo.MINVE05.COSTO AS COSTO_OPERADO, dbo.PRVPROD05.CVE_PROV AS CLAVE_PROV, " & _
                     " dbo.PROV05.NOMBRE AS PROVEEDOR " & _
                    " FROM         dbo.MINVE05 INNER JOIN  " & _
                     " dbo.ALMACENES05 ON dbo.MINVE05.ALMACEN = dbo.ALMACENES05.CVE_ALM INNER JOIN " & _
                      " dbo.INVE05 ON dbo.MINVE05.CVE_ART = dbo.INVE05.CVE_ART INNER JOIN " & _
                     " dbo.CONM05 ON dbo.MINVE05.CVE_CPTO = dbo.CONM05.CVE_CPTO LEFT OUTER JOIN " & _
                     " dbo.PROV05 LEFT OUTER JOIN " & _
                     " dbo.PRVPROD05 ON dbo.PROV05.CLAVE = dbo.PRVPROD05.CVE_PROV ON dbo.MINVE05.CVE_ART = dbo.PRVPROD05.CVE_ART " & _
                     " WHERE     (dbo.MINVE05.FECHA_DOCU >=  @fechaini AND dbo.MINVE05.FECHA_DOCU <= @fechafin AND (dbo.MINVE05.CVE_CPTO = '11' OR " & _
                     " dbo.MINVE05.CVE_CPTO = '63'))", ActualizarConexion)
        ActualizarConexion.Open()

        miComando.Parameters.AddWithValue("@fechaini", fechaini)
        miComando.Parameters.AddWithValue("@fechafin", fechafin)

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




    Public Function PromocionesSrAgro(ByVal fechaini As Date, ByVal fechafin As Date)
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())

        Dim miComando As New SqlCommand(" SELECT     CONVERT(DATE,dbo.MINVE02.FECHA_DOCU,104) AS FECHA, MONTH(dbo.MINVE02.FECHA_DOCU) AS MES, dbo.ALMACENES02.DESCR AS ALMACEN, dbo.MINVE02.CVE_ART AS CLAVE,  " & _
                     " dbo.INVE02.DESCR AS DESCRIPCION, dbo.MINVE02.CVE_CPTO AS CLAVE_CON, dbo.CONM02.DESCR AS CONCEPTO, dbo.MINVE02.CANT AS CANTIDAD,  " & _
                     " dbo.MINVE02.COSTO, dbo.MINVE02.CANT * dbo.MINVE02.COSTO AS COSTO_OPERADO, dbo.PRVPROD02.CVE_PROV AS CLAVE_PROV,  " & _
                     " dbo.PROV02.NOMBRE AS PROVEEDOR " & _
                     "   FROM         dbo.MINVE02 INNER JOIN " & _
                     " dbo.ALMACENES02 ON dbo.MINVE02.ALMACEN = dbo.ALMACENES02.CVE_ALM INNER JOIN  " & _
                     "  dbo.INVE02 ON dbo.MINVE02.CVE_ART = dbo.INVE02.CVE_ART INNER JOIN " & _
                     "  dbo.CONM02 ON dbo.MINVE02.CVE_CPTO = dbo.CONM02.CVE_CPTO LEFT OUTER JOIN  " & _
                     "  dbo.PROV02 LEFT OUTER JOIN " & _
                     " dbo.PRVPROD02 ON dbo.PROV02.CLAVE = dbo.PRVPROD02.CVE_PROV ON dbo.MINVE02.CVE_ART = dbo.PRVPROD02.CVE_ART  " & _
                     " WHERE     (dbo.MINVE02.FECHA_DOCU >= @fechaini AND dbo.MINVE02.FECHA_DOCU <= @fechafin AND (dbo.MINVE02.CVE_CPTO = '11' OR " & _
                     "  dbo.MINVE02.CVE_CPTO = '63')) ", ActualizarConexion)
        ActualizarConexion.Open()

        miComando.Parameters.AddWithValue("@fechaini", fechaini)
        miComando.Parameters.AddWithValue("@fechafin", fechafin)

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


    Public Function PromocionesDimosa(ByVal fechaini As Date, ByVal fechafin As Date)
        Dim ActualizarConexion As New SqlConnection(Conexion3.CadenaSQL())

        Dim miComando As New SqlCommand(" SELECT     CONVERT(DATE,dbo.MINVE06.FECHA_DOCU,104) AS FECHA, MONTH(dbo.MINVE06.FECHA_DOCU) AS MES, dbo.ALMACENES06.DESCR AS ALMACEN, dbo.MINVE06.CVE_ART AS CLAVE,  " &
                     " dbo.INVE06.DESCR AS DESCRIPCION, dbo.MINVE06.CVE_CPTO AS CLAVE_CON, dbo.CONM06.DESCR AS CONCEPTO, dbo.MINVE06.CANT AS CANTIDAD,  " &
                     " dbo.MINVE06.COSTO, dbo.MINVE06.CANT * dbo.MINVE06.COSTO AS COSTO_OPERADO, dbo.PRVPROD06.CVE_PROV AS CLAVE_PROV,  " &
                     " dbo.PROV06.NOMBRE AS PROVEEDOR " &
                     "   FROM         dbo.MINVE06 INNER JOIN " &
                     " dbo.ALMACENES06 ON dbo.MINVE06.ALMACEN = dbo.ALMACENES06.CVE_ALM INNER JOIN  " &
                     "  dbo.INVE06 ON dbo.MINVE06.CVE_ART = dbo.INVE06.CVE_ART INNER JOIN " &
                     "  dbo.CONM06 ON dbo.MINVE06.CVE_CPTO = dbo.CONM06.CVE_CPTO LEFT OUTER JOIN  " &
                     "  dbo.PROV06 LEFT OUTER JOIN " &
                     " dbo.PRVPROD06 ON dbo.PROV06.CLAVE = dbo.PRVPROD06.CVE_PROV ON dbo.MINVE06.CVE_ART = dbo.PRVPROD06.CVE_ART  " &
                     " WHERE     (dbo.MINVE06.FECHA_DOCU >= @fechaini AND dbo.MINVE06.FECHA_DOCU <= @fechafin AND (dbo.MINVE06.CVE_CPTO = '11' OR " &
                     "  dbo.MINVE06.CVE_CPTO = '63')) ", ActualizarConexion)
        ActualizarConexion.Open()

        miComando.Parameters.AddWithValue("@fechaini", fechaini)
        miComando.Parameters.AddWithValue("@fechafin", fechafin)

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

    Public Function PromocionesOPL(ByVal fechaini As Date, ByVal fechafin As Date)
        Dim ActualizarConexion As New SqlConnection(Conexion4.CadenaSQL())

        Dim miComando As New SqlCommand(" SELECT     CONVERT(DATE,dbo.MINVE08.FECHA_DOCU,104) AS FECHA, MONTH(dbo.MINVE08.FECHA_DOCU) AS MES, dbo.ALMACENES08.DESCR AS ALMACEN, dbo.MINVE08.CVE_ART AS CLAVE,  " &
                     " dbo.INVE08.DESCR AS DESCRIPCION, dbo.MINVE08.CVE_CPTO AS CLAVE_CON, dbo.CONM08.DESCR AS CONCEPTO, dbo.MINVE08.CANT AS CANTIDAD,  " &
                     " dbo.MINVE08.COSTO, dbo.MINVE08.CANT * dbo.MINVE08.COSTO AS COSTO_OPERADO, dbo.PRVPROD08.CVE_PROV AS CLAVE_PROV,  " &
                     " dbo.PROV08.NOMBRE AS PROVEEDOR " &
                     "   FROM         dbo.MINVE08 INNER JOIN " &
                     " dbo.ALMACENES08 ON dbo.MINVE08.ALMACEN = dbo.ALMACENES08.CVE_ALM INNER JOIN  " &
                     "  dbo.INVE08 ON dbo.MINVE08.CVE_ART = dbo.INVE08.CVE_ART INNER JOIN " &
                     "  dbo.CONM08 ON dbo.MINVE08.CVE_CPTO = dbo.CONM08.CVE_CPTO LEFT OUTER JOIN  " &
                     "  dbo.PROV08 LEFT OUTER JOIN " &
                     " dbo.PRVPROD08 ON dbo.PROV08.CLAVE = dbo.PRVPROD08.CVE_PROV ON dbo.MINVE08.CVE_ART = dbo.PRVPROD08.CVE_ART  " &
                     " WHERE     (dbo.MINVE08.FECHA_DOCU >= @fechaini AND dbo.MINVE08.FECHA_DOCU <= @fechafin AND (dbo.MINVE08.CVE_CPTO = '11' OR " &
                     "  dbo.MINVE08.CVE_CPTO = '63')) ", ActualizarConexion)
        ActualizarConexion.Open()

        miComando.Parameters.AddWithValue("@fechaini", fechaini)
        miComando.Parameters.AddWithValue("@fechafin", fechafin)

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
