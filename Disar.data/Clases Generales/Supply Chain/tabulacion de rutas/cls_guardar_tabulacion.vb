Imports System.Data.SqlClient

Public Class cls_guardar_tabulacion
    Dim Conexion As New clsConexion
    Public Function GUARDAR(ByVal NOMBRE As String, ByVal TAB_RUTA_ID As Integer, ByVal SALIDA_HI As DateTime _
                            , ByVal SALIDA_HF As DateTime, ByVal DESAYUNO_HI As DateTime, ByVal DESAYUNO_HF As DateTime _
                            , ByVal ALMUERZO_HI As DateTime, ByVal ALMUERZO_HF As DateTime, ByVal LLEGADA_HI As DateTime _
                            , ByVal LLEGADA_HF As DateTime, ByVal DEVOLUCIONES_HI As DateTime, ByVal DEVOLUCIONES_HF As DateTime _
                            , ByVal LIQUIDACION_HI As DateTime, ByVal LIQUIDACION_HF As DateTime, ByVal partidas As DataTable)

        Dim transaccion As SqlTransaction
        Dim sql_con As New SqlConnection(Conexion.CadenaSQL())
        sql_con.Open()
        transaccion = sql_con.BeginTransaction()
        Try
            Dim miComando As New SqlCommand("INSERT INTO [Usuarios].[dbo].[TAB_ENCABEZADOS] " & _
             " ([TAB_NOMBRE],[TAB_RUTA_ID],[SALIDA_HI],[SALIDA_HF],[DESAYUNO_HI],[DESAYUNO_HF],[ALMUERZO_HI],[ALMUERZO_HF] " & _
             " ,[LLEGADA_HI],[LLEGADA_HF],[DEVOLUCIONES_HI],[DEVOLUCIONES_HF],[LIQUIDACION_HI],[LIQUIDACION_HF]) " & _
             "VALUES (@TAB_NOMBRE,@TAB_RUTA_ID,@SALIDA_HI,@SALIDA_HF,@DESAYUNO_HI,@DESAYUNO_HF,@ALMUERZO_HI,@ALMUERZO_HF,@LLEGADA_HI " & _
             " ,@LLEGADA_HF,@DEVOLUCIONES_HI,@DEVOLUCIONES_HF,@LIQUIDACION_HI,@LIQUIDACION_HF) ", sql_con)

            miComando.Parameters.AddWithValue("@TAB_NOMBRE", NOMBRE)
            miComando.Parameters.AddWithValue("@TAB_RUTA_ID", TAB_RUTA_ID)
            miComando.Parameters.AddWithValue("@SALIDA_HI", SALIDA_HI)
            miComando.Parameters.AddWithValue("@SALIDA_HF", SALIDA_HF)
            miComando.Parameters.AddWithValue("@DESAYUNO_HI", DESAYUNO_HI)
            miComando.Parameters.AddWithValue("@DESAYUNO_HF", DESAYUNO_HF)
            miComando.Parameters.AddWithValue("@ALMUERZO_HI", ALMUERZO_HI)
            miComando.Parameters.AddWithValue("@ALMUERZO_HF", ALMUERZO_HF)
            miComando.Parameters.AddWithValue("@LLEGADA_HI", LLEGADA_HI)
            miComando.Parameters.AddWithValue("@LLEGADA_HF", LLEGADA_HF)
            miComando.Parameters.AddWithValue("@DEVOLUCIONES_HI", DEVOLUCIONES_HI)
            miComando.Parameters.AddWithValue("@DEVOLUCIONES_HF", DEVOLUCIONES_HF)
            miComando.Parameters.AddWithValue("@LIQUIDACION_HI", LIQUIDACION_HI)
            miComando.Parameters.AddWithValue("@LIQUIDACION_HF", LIQUIDACION_HF)
            miComando.Transaction = transaccion
            miComando.ExecuteNonQuery()

            For i As Integer = 0 To partidas.Rows.Count - 1
                Dim comando_partidas As New SqlCommand("INSERT INTO [Usuarios].[dbo].[TAB_PARTIDAS] " & _
                    "([TAB_RUTA_ID],[CLIENTE_ID],[PESO],[HORA_INI],[HORA_FIN],[TIEMPO_PROMEDIO]) " & _
                    "VALUES(@TAB_RUTA_ID, @CLIENTE_ID,@PESO, @HORA_INI, @HORA_FIN,@TIEMPO_PROMEDIO) ", sql_con)
                comando_partidas.Parameters.AddWithValue("@TAB_RUTA_ID", TAB_RUTA_ID)
                comando_partidas.Parameters.AddWithValue("@CLIENTE_ID", partidas.Rows(i).Item(0))
                comando_partidas.Parameters.AddWithValue("@PESO", Convert.ToDouble(partidas.Rows(i).Item(2)))

                Dim hora_ini As DateTime = Now
                Dim hora_fin As DateTime = Now
                If IsDate(partidas.Rows(i).Item(3)) = True Then
                    hora_ini = Convert.ToDateTime(partidas.Rows(i).Item(3))
                End If
                If IsDate(partidas.Rows(i).Item(4)) = True Then
                    hora_fin = Convert.ToDateTime(partidas.Rows(i).Item(4))
                End If

                comando_partidas.Parameters.AddWithValue("@HORA_INI", hora_ini)
                comando_partidas.Parameters.AddWithValue("@HORA_FIN", hora_fin)
                comando_partidas.Parameters.AddWithValue("@TIEMPO_PROMEDIO", DateDiff(DateInterval.Minute, _
                hora_ini, hora_fin) / Convert.ToDouble(partidas.Rows(i).Item(2)))

                comando_partidas.Transaction = transaccion
                comando_partidas.ExecuteNonQuery()
            Next

            transaccion.Commit()
            sql_con.Close()
            Return "correcto"
        Catch ex As Exception
            transaccion.Rollback()
            sql_con.Close()
            Return ex.Message
        End Try
    End Function

    Public Function ListarRutas(ByVal RUTA As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT dbo.TAB_ENCABEZADOS.TAB_NOMBRE AS RUTA, CONVERT(VARCHAR,dbo.TAB_ENCABEZADOS.SALIDA_HI,103) AS FECHA, " & _
                                        "RIGHT(CONVERT(DATETIME, dbo.TAB_ENCABEZADOS.SALIDA_HI, 108),8) AS SALIDA,  " & _
                                        "RIGHT(CONVERT(DATETIME, dbo.TAB_ENCABEZADOS.DESAYUNO_HI, 108),8) AS DESAYUNO,  " & _
                                        "RIGHT(CONVERT(DATETIME, dbo.TAB_ENCABEZADOS.ALMUERZO_HI, 108),8) AS ALMUERZO,  " & _
                                        "RIGHT(CONVERT(DATETIME, dbo.TAB_ENCABEZADOS.LLEGADA_HI, 108),8) AS LLEGADA,  " & _
                                        "RIGHT(CONVERT(DATETIME, dbo.TAB_ENCABEZADOS.DEVOLUCIONES_HI, 108),8) AS DEVOLUCIONES, " & _
                                        "RIGHT(CONVERT(DATETIME, dbo.TAB_ENCABEZADOS.LIQUIDACION_HI, 108),8) AS LIQUIDACION,  " & _
                                        "ROUND(CONVERT(FLOAT,DATEDIFF(MINUTE,dbo.TAB_ENCABEZADOS.SALIDA_HI,dbo.TAB_ENCABEZADOS.LIQUIDACION_HF))/60,3) AS [TIEMPO PROMEDIO HR], " & _
                                        "dbo.TAB_ENCABEZADOS.TAB_RUTA_ID AS CODIGO " & _
                                        "FROM dbo.TAB_ENCABEZADOS " & _
                                        "WHERE (dbo.TAB_ENCABEZADOS.TAB_NOMBRE LIKE '%" + RUTA.ToUpper + "%') ", ActualizarConexion)

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

    Public Function DetalleRutas(ByVal RUTA As String, ByVal FECHA As Date)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT CLIENTE_ID AS CODIGO, C.NOMBRE, " & _
                                        "RIGHT(CONVERT(DATETIME, HORA_INI, 108),8) AS LLEGADA, " & _
                                        "RIGHT(CONVERT(DATETIME, HORA_FIN, 108),8) AS SALIDA, DATEDIFF(MINUTE,HORA_INI,HORA_FIN) AS TIEMPO " & _
                                        "FROM TAB_PARTIDAS INNER JOIN SAE50Empre10.dbo.CLIE10 C ON C.CLAVE = CLIENTE_ID " & _
                                        "COLLATE MODERN_SPANISH_CI_AS WHERE TAB_PARTIDAS.TAB_RUTA_ID = @RUTA AND " & _
                                        "CONVERT(VARCHAR,TAB_PARTIDAS.HORA_INI,103) = CONVERT(VARCHAR,@FECHA,103) ", ActualizarConexion)
        miComando.Parameters.AddWithValue("@RUTA", RUTA)
        miComando.Parameters.AddWithValue("@FECHA", FECHA)
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

    Public Function reporte_rutas(ByVal RUTA As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("rptn_plantilla_tabulacion", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@RUTA", SqlDbType.VarChar)).Value = RUTA

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
