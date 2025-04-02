Imports System.Data.SqlClient

Public Class ClsMatinalAgro

    Dim Conexion As New clsconexion_sr_agro
    Dim ConexionUsuario As New clsConexion
     
    Public Function MuestraVendedores() As DataView
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim AdaptadorDeDatos As New SqlDataAdapter("SELECT        CVE_VEND, UPPER(NOMBRE) AS VENDEDOR, CLASIFIC " & _
        " FROM VEND02 WHERE CVE_VEND IN ('   21', '   28', '   30', '   35', '   31', '  104', '  108')", ActualizarConexion)
        ActualizarConexion.Open()
        Dim ds As New DataSet
        Dim dv As New DataView
        Try
            AdaptadorDeDatos.Fill(ds, "User")
            If ds.Tables("User").Rows.Count > 0 Then
                dv = New DataView(ds.Tables("User"))
            End If
        Catch ex As SqlException
            MsgBox("Hay problemas de Conexión: " + ex.Message, MsgBoxStyle.Critical)
        End Try
        ActualizarConexion.Close()
        Return dv
    End Function

    Public Function MuestraVendedoresMatinal() As DataView
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim AdaptadorDeDatos As New SqlDataAdapter("SELECT        dbo.VEND02.CVE_VEND, UPPER(dbo.VEND02.NOMBRE) AS VENDEDOR, dbo.VEND02.CLASIFIC, Usuarios.dbo.Matinal_SRAgro_Segmentos.TIPO " & _
                                                   " FROM            dbo.VEND02 INNER JOIN " & _
                                                   " Usuarios.dbo.Matinal_SRAgro_Segmentos ON Usuarios.dbo.Matinal_SRAgro_Segmentos.VENDEDOR = dbo.VEND02.CVE_VEND COLLATE MODERN_SPANISH_CI_AS " & _
                                                   " WHERE        (dbo.VEND02.CVE_VEND IN ('   21', '   28', '   30', '   35', '   31', '  104', '  108'))", ActualizarConexion)
        ActualizarConexion.Open()
        Dim ds As New DataSet
        Dim dv As New DataView
        Try
            AdaptadorDeDatos.Fill(ds, "User")
            If ds.Tables("User").Rows.Count > 0 Then
                dv = New DataView(ds.Tables("User"))
            End If
        Catch ex As SqlException
            MsgBox("Hay problemas de Conexión: " + ex.Message, MsgBoxStyle.Critical)
        End Try
        ActualizarConexion.Close()
        Return dv
    End Function

    Public Function Pantallas(ByVal Vendedor As Integer) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionUsuario.CadenaSQL())

        Dim miComando As New SqlCommand("dsr_matinal_sr_agro", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure

        miComando.Parameters.AddWithValue("@PANTALLA", "")
        miComando.Parameters.AddWithValue("@VENDEDOR", Vendedor)
        miComando.Parameters.AddWithValue("@MES", "")
        miComando.Parameters.AddWithValue("@AÑO", "")
        miComando.Parameters.AddWithValue("@TIPO", "PANTALLAS")

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

    Public Function CargaMetas(ByVal Vendedor As String, ByVal PANTALLA As String, ByVal MES As Integer, ByVal AÑO As Integer) As DataTable

        Dim ActualizarConexion As New SqlConnection(ConexionUsuario.CadenaSQL())

        Dim miComando As New SqlCommand("dsr_matinal_sr_agro", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.AddWithValue("@PANTALLA", PANTALLA)
        miComando.Parameters.AddWithValue("@VENDEDOR", Vendedor)
        miComando.Parameters.AddWithValue("@MES", MES)
        miComando.Parameters.AddWithValue("@AÑO", AÑO)
        miComando.Parameters.AddWithValue("@TIPO", "METAS")

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

    Public Function CargaMetasGenerales(ByVal MES As Integer, ByVal AÑO As Integer) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionUsuario.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT SEGMENTO, PANTALLA, SUM(META) AS 'META', TIPO, '' AS REAL, '' AS '%', '' AS 'META DIARIA', '' AS DESAFIO, '' AS 'REAL DIARIO' " & _
        "         FROM dbo.Matinal_SRAgro_Meta " & _
        " WHERE (MES = @MES) AND (AÑO = @AÑO) " & _
        " GROUP BY SEGMENTO, PANTALLA, TIPO ORDER BY PANTALLA", ActualizarConexion)


        miComando.Parameters.AddWithValue("@MES", MES)
        miComando.Parameters.AddWithValue("@AÑO", AÑO)

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

    Public Function CargaMetaVolumen(ByVal MES As Integer, ByVal AÑO As Integer, ByVal Vendedor As Integer) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionUsuario.CadenaSQL())

        Dim miComando As New SqlCommand(" SELECT META  FROM Matinal_SRAgro_Meta " & _
                                        " WHERE (MES = @MES) AND (AÑO = @AÑO) AND (SEGMENTO LIKE 'VOLUMEN%') AND (CVE_VEND = @VENDEDOR) ", ActualizarConexion)

        miComando.Parameters.AddWithValue("@MES", MES)
        miComando.Parameters.AddWithValue("@AÑO", AÑO)
        miComando.Parameters.AddWithValue("@VENDEDOR", Vendedor)

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

    Public Function LlenaInfo_QQ_TM(ByVal FECHA As Date, ByVal FECHA2 As Date, ByVal VENDEDOR As Integer, ByVal PANTALLA As String, ByVal SUBPANTALA As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        'MsgBox(FECHA & vbNewLine & FECHA2 & vbNewLine & VENDEDOR & vbNewLine & PANTALLA & vbNewLine & SUBPANTALA)
        Dim miComando As New SqlCommand("MATINAL", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure

        miComando.Parameters.AddWithValue("@FECHA_INI", FECHA.Date)
        miComando.Parameters.AddWithValue("@FECHA_FIN", FECHA2.Date)
        miComando.Parameters.AddWithValue("@VENDEDOR", VENDEDOR)
        miComando.Parameters.AddWithValue("@TIPO", PANTALLA)
        miComando.Parameters.AddWithValue("@SUBTIPO", SUBPANTALA)

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

    Public Function CargaMetasEditar(ByVal Vendedor As String, ByVal PANTALLA As String, ByVal MES As Integer, ByVal AÑO As Integer) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionUsuario.CadenaSQL())

        Dim miComando As New SqlCommand(" SELECT SEGMENTO, META, TIPO FROM Matinal_SRAgro_Meta WHERE CVE_VEND = @VENDEDOR AND PANTALLA = @PANTALLA AND MES = @MES AND AÑO = @AÑO ", ActualizarConexion)

        miComando.Parameters.AddWithValue("@VENDEDOR", Vendedor)
        miComando.Parameters.AddWithValue("@PANTALLA", PANTALLA)
        miComando.Parameters.AddWithValue("@MES", MES)
        miComando.Parameters.AddWithValue("@AÑO", AÑO)

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

    Public Function NuevaPantalla(ByVal Pantalla As String, ByVal Vendedor As String)

        Dim ActualizarConexion As New SqlConnection(ConexionUsuario.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand
            'Guarda nueva marca

            miComando = New SqlCommand("INSERT INTO   Matinal_SRAgro_Pantallas " & _
            " (VENDEDOR, PANTALLA) " & _
            " VALUES (@VENDEDOR, @PANTALLA)", ActualizarConexion)

            miComando.Parameters.AddWithValue("@VENDEDOR", Vendedor)
            miComando.Parameters.AddWithValue("@PANTALLA", Pantalla)

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

    Public Function NuevoSegmento(ByVal Segmento As String, ByVal Pantalla As String, ByVal Vendedor As Integer, ByVal Meta As Decimal, ByVal Tipo As String, ByVal MES As Integer, ByVal AÑO As Integer)

        Dim ActualizarConexion As New SqlConnection(ConexionUsuario.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand
            'Guarda nueva marca

            miComando = New SqlCommand("INSERT INTO  Matinal_SRAgro_Meta " & _
            " (CVE_VEND, SEGMENTO, PANTALLA, META, TIPO, MES, AÑO ) " & _
            " VALUES (@CVE_VEND, @SEGMENTO, @PANTALLA, @META, @TIPO, @MES, @AÑO)", ActualizarConexion)

            miComando.Parameters.AddWithValue("@CVE_VEND", Vendedor)
            miComando.Parameters.AddWithValue("@SEGMENTO", Segmento)
            miComando.Parameters.AddWithValue("@PANTALLA", Pantalla)
            miComando.Parameters.AddWithValue("@META", Meta)
            miComando.Parameters.AddWithValue("@TIPO", Tipo)
            miComando.Parameters.AddWithValue("@MES", MES)
            miComando.Parameters.AddWithValue("@AÑO", AÑO)

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

    Public Function EliminaPantalla(ByVal Pantalla As String, ByVal Vendedor As String)

        Dim ActualizarConexion As New SqlConnection(ConexionUsuario.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand
            'Guarda nueva marca

            miComando = New SqlCommand("DELETE FROM Matinal_SRAgro_Pantallas " & _
            " WHERE (VENDEDOR = @VENDEDOR AND PANTALLA = @PANTALLA) ", ActualizarConexion)

            miComando.Parameters.AddWithValue("@VENDEDOR", Vendedor)
            miComando.Parameters.AddWithValue("@PANTALLA", Pantalla)

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

    Public Function EliminaSegmento(ByVal Pantalla As String, ByVal Vendedor As String, ByVal Segmento As String, ByVal MES As Integer, ByVal AÑO As Integer)

        Dim ActualizarConexion As New SqlConnection(ConexionUsuario.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand
            'Guarda nueva marca

            miComando = New SqlCommand("DELETE FROM Matinal_SRAgro_Meta " & _
            " WHERE (CVE_VEND = @VENDEDOR AND PANTALLA = @PANTALLA) AND SEGMENTO = @SEGMENTO AND MES = @MES AND AÑO = @AÑO ", ActualizarConexion)

            miComando.Parameters.AddWithValue("@VENDEDOR", Vendedor)
            miComando.Parameters.AddWithValue("@PANTALLA", Pantalla)
            miComando.Parameters.AddWithValue("@SEGMENTO", Segmento)
            miComando.Parameters.AddWithValue("@MES", MES)
            miComando.Parameters.AddWithValue("@AÑO", AÑO)


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

    Public Function CARGASEGMENTOS(ByVal PANTALLA As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand(" SELECT DISTINCT LTRIM(RTRIM(UPPER(CAMPLIB3))) AS MEDICION " & _
                                        " FROM INVE_CLIB02 WHERE (UPPER(CAMPLIB2) = @PANTALLA) UNION ALL SELECT @PANTALLA AS MEDICION ", ActualizarConexion)

        miComando.Parameters.AddWithValue("@PANTALLA", PANTALLA)

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

End Class

