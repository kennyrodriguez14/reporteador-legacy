Imports System.Data.SqlClient

Public Class ClsRegistroAgro

    Dim Conexion As New clsConexion

    Public Function get_Hora()
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("Select CONVERT (time(7), GETDATE())", ActualizarConexion)
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

    Public Function get_Fecha()
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("Select CONVERT (date, GETDATE())", ActualizarConexion)
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

    Public Function NuevoEventoProgramado(ByVal Fecha As Date, ByVal Hora As TimeSpan, ByVal Motivo As String, ByVal Usuario As String, ByVal Ip As String)

        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand

            Dim NumBita As Integer = 0
            Dim DtBita As New DataTable
            Dim QueryBita As String
            QueryBita = "SELECT MAX (IdReg) FROM Registro_Agro"
            Dim CMDQueryBita As New SqlCommand(QueryBita, ActualizarConexion)
            Dim AdaptadorBita As New SqlDataAdapter(CMDQueryBita)
            CMDQueryBita.Transaction = transaccion_sql
            AdaptadorBita.Fill(DtBita)

            If DtBita.Rows.Count > 0 Then
                If Not IsDBNull(DtBita.Rows(0)(0)) Then
                    NumBita = DtBita.Rows(0)(0)
                End If
            End If
            NumBita += 1
            miComando = New SqlCommand("INSERT INTO Registro_Agro " & _
                                         " (IdReg, RegFecha, RegHora, RegMotivo, RegUsuario, RegIp) " & _
                                         " VALUES (@IdReg, @RegFecha, @RegHora, @RegMotivo, @RegUsuario, @RegIp)", ActualizarConexion)

            miComando.Parameters.AddWithValue("@IdReg", NumBita)
            miComando.Parameters.AddWithValue("@RegFecha", Fecha.Date)
            miComando.Parameters.AddWithValue("@RegHora", Hora)
            miComando.Parameters.AddWithValue("@RegMotivo", Motivo)
            miComando.Parameters.AddWithValue("@RegUsuario", Usuario)
            miComando.Parameters.AddWithValue("@RegIp", Ip)

            miComando.Transaction = transaccion_sql
            miComando.ExecuteNonQuery()

            transaccion_sql.Commit()
            ActualizarConexion.Close()
            Return "Se ha guardado el registro con éxito"

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

    Public Function ObtieneRegistros(ByVal Usuario As String, ByVal Fecha As Date)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT  IdReg AS 'Nº', RegFecha as FECHA, RegHora as HORA, RegMotivo AS MOTIVO, RegUsuario AS USUARIO , " & _
                                        " RegIp AS 'REGISTRADO DESDE' FROM Registro_Agro WHERE RegFecha = @FECHA AND RegUsuario = @USUARIO", ActualizarConexion)

        miComando.Parameters.AddWithValue("@FECHA", Fecha.Date)
        miComando.Parameters.AddWithValue("@USUARIO", Usuario)

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

    Public Function ObtenerUsuarios()
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT 'TODOS' AS RegUsuario UNION ALL SELECT DISTINCT RegUsuario FROM Registro_Agro", ActualizarConexion)

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

    Public Function ObtieneTodosRegistrosIndividual(ByVal Fecha As Date, ByVal Fecha2 As Date, ByVal Usuario As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT  IdReg AS 'Nº', RegUsuario AS USUARIO, RegFecha as FECHA, RegHora as HORA, RegMotivo AS MOTIVO, " & _
                                        " RegIp AS 'REGISTRADO DESDE' FROM Registro_Agro WHERE RegFecha >= @FECHA AND RegFecha <= @FECHA2 AND RegUsuario = @USUARIO", ActualizarConexion)

        miComando.Parameters.AddWithValue("@FECHA", Fecha.Date)
        miComando.Parameters.AddWithValue("@FECHA2", Fecha2.Date)
        miComando.Parameters.AddWithValue("@USUARIO", Usuario)

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

    Public Function ObtieneTodosRegistros(ByVal Fecha As Date, ByVal Fecha2 As Date)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT  IdReg AS 'Nº', RegUsuario AS USUARIO, RegFecha as FECHA, RegHora as HORA, RegMotivo AS MOTIVO, " & _
                                        " RegIp AS 'REGISTRADO DESDE' FROM Registro_Agro WHERE RegFecha >= @FECHA AND RegFecha <= @FECHA2", ActualizarConexion)

        miComando.Parameters.AddWithValue("@FECHA", Fecha.Date)
        miComando.Parameters.AddWithValue("@FECHA2", Fecha2.Date)

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

    Public Function get_Nombre(ByVal Usuario As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT  UsuarioNombre, mdl_rev FROM  [User] WHERE UsuarioNick = @USUARIO", ActualizarConexion)
        miComando.Parameters.AddWithValue("@USUARIO", Usuario)

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
