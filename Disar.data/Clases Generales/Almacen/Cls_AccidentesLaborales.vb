Imports Disar.data
Imports System.Data.SqlClient

Public Class Cls_AccidentesLaborales

    Dim Conexion As New clsConexion

    Public Function ObtieneRegistros(ByVal Fecha1 As Date, ByVal Fecha2 As Date, ByVal Almacen As Integer)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT  Acc_ID As 'Nº de Registro', Descripcion As 'Descripción', Colaborador, Fecha, Hora FROM tb_count WHERE Fecha >= @Fecha1 and Fecha <= @Fecha2 AND Almacen = @Almacen", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Fecha1", Fecha1.Date)
        miComando.Parameters.AddWithValue("@Fecha2", Fecha2.Date)
        miComando.Parameters.AddWithValue("@Almacen", Almacen)

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

    Public Function NuevoEventoProgramado(ByVal Fecha As Date, ByVal Hora As TimeSpan, ByVal Descripcion As String, ByVal Colaborador As String, ByVal Almacen As Integer)

        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand

            Dim NumBita As Integer = 0
            Dim DtBita As New DataTable
            Dim QueryBita As String
            QueryBita = "SELECT MAX (Acc_ID) FROM tb_count"
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
            miComando = New SqlCommand("INSERT INTO tb_count " & _
                                         " (Acc_ID, Descripcion, Colaborador, Fecha, Hora, Almacen) " & _
                                         " VALUES (@Acc_ID, @Descripcion, @Colaborador, @Fecha, @Hora, @Almacen)", ActualizarConexion)

            miComando.Parameters.AddWithValue("@Acc_ID", NumBita)
            miComando.Parameters.AddWithValue("@Descripcion", Descripcion)
            miComando.Parameters.AddWithValue("@Colaborador", Colaborador)
            miComando.Parameters.AddWithValue("@Fecha", Fecha.Date)
            miComando.Parameters.AddWithValue("@Hora", Hora)
            miComando.Parameters.AddWithValue("@Almacen", Almacen)

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

End Class
