Imports Disar.data
Imports System.Data.SqlClient
Imports System.Text

Public Class clsReuniones

    Dim Conexion As New clsConexion

    Public Function NombreUsuario(ByVal User As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT UsuarioNombre FROM  [User] WHERE UsuarioNick = @Usuario", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Usuario", User)

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

    Public Function Sucursales(ByVal User As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT        Sucursal_ID, Sucursal_Nombre FROM            Reu_Sucursales ", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Usuario", User)

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

    Public Function FechaHora()
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT GETDATE() AS Fecha", ActualizarConexion)

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

    Public Function Reuniones(ByVal User As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT  dbo.Reu_General.ReuID AS 'Nº',   dbo.Reu_General.ReuNombre AS Reunion, dbo.Reu_General.ReuInicio AS Inicio, dbo.Reu_General.ReuFinal AS Final, dbo.[User].UsuarioNombre AS Responsable, dbo.Reu_General.ReuReponsable as ID, " & _
                      " dbo.Reu_General.ReuPeriodo AS Periodo,  REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(ReuDia, 1, 'Lunes'), 2, 'Martes'), 3, 'Miércoles'), 4, 'Jueves'), 5, 'Viernes'), 6, 'Sábado') AS Día, dbo.Reu_General.ReuFecha AS 'Última reunión', " & _
                      " dbo.Reu_General.ReuDetalle AS Detalle FROM         dbo.[User] INNER JOIN " & _
                      " dbo.Reu_General ON dbo.[User].UsuarioNick = dbo.Reu_General.ReuReponsable INNER JOIN " & _
                      " dbo.Reu_Particip ON dbo.Reu_General.ReuID = dbo.Reu_Particip.ReuID WHERE ((dbo.Reu_Particip.ReuEmpl = @Usuario) or (@Usuario = 'Administrador')) and ReuEstado = 'A'", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Usuario", User)

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

    Public Function TemasReunion(ByVal User As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT ReuTemaID as 'Nº', CONVERT(Varchar(MAX), DecryptByPassphrase('Disar2308', ReuTemaNombre)) as Tema FROM Reu_Temas  WHERE ReuID = @Reunion", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Reunion", User)

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

    Public Function ParticipantesReunion(ByVal Reunion As Integer)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT     dbo.Reu_Particip.ReuEmpl as ID, dbo.[User].UsuarioNombre as Participante, dbo.Reu_Particip.ReuFijo as 'Fijado/Agregado' " & _
                                        " FROM         dbo.Reu_Particip INNER JOIN " & _
                                        " dbo.[User] ON dbo.Reu_Particip.ReuEmpl = dbo.[User].UsuarioNick " & _
                                        " WHERE     (dbo.Reu_Particip.ReuID = @Reunion) AND (dbo.Reu_Particip.ReuFijo IN ('S', 'A')) ORDER BY dbo.[User].UsuarioNombre", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Reunion", Reunion)

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

    Public Function ParticipantesPendiente(ByVal Pendiente As Integer)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT        Reu_Asignaciones.Asignado as 'ID', [User].UsuarioNombre FROM Reu_Asignaciones INNER JOIN [User] ON Reu_Asignaciones.Asignado = [User].UsuarioNick " & _
                                        " WHERE        (Reu_Asignaciones.Estado = 'Pendiente') and Pendiente = @Pendiente ORDER BY [User].UsuarioNombre", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Pendiente", Pendiente)

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

    Public Function VerificaReunion(ByVal Reunion As Integer, ByVal Fecha As Date)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT     dbo.Reu_RegReuniones.Reu_Inicio  FROM    dbo.Reu_General INNER JOIN   dbo.Reu_RegReuniones ON dbo.Reu_General.ReuID = dbo.Reu_RegReuniones.Reu_ID WHERE (ReuFecha = @Fecha) And ReuID = @ID", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Fecha", Fecha.Date)
        miComando.Parameters.AddWithValue("@ID", Reunion)

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

    Public Function NuevaReunionRegistro(ByVal ReunionId As Integer, ByVal ReunionDescripcion As String, ByVal ReunionInicio As DateTime, ByVal Usuario As String)

        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand
            'Guarda nueva marca

            Dim NumBita As Integer = 0
            Dim DtBita As New DataTable
            Dim QueryBita As String
            QueryBita = "SELECT MAX (Reg_Num) FROM Reu_RegReuniones"
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
            miComando = New SqlCommand("INSERT INTO Reu_RegReuniones " & _
            " (Reg_Num, Reu_ID, Reu_Descripcion, Reu_Inicio, Reu_UsuarioInicio) " & _
            " VALUES (@Reg_Num, @Reu_ID, @Reu_Descripcion, @Reu_Inicio, @Reu_UsuarioInicio)", ActualizarConexion)

            miComando.Parameters.AddWithValue("@Reg_Num", NumBita)
            miComando.Parameters.AddWithValue("@Reu_ID", ReunionId)
            miComando.Parameters.AddWithValue("@Reu_Descripcion", ReunionDescripcion)
            miComando.Parameters.AddWithValue("@Reu_Inicio", ReunionInicio)
            miComando.Parameters.AddWithValue("@Reu_UsuarioInicio", Usuario)

            miComando.Transaction = transaccion_sql
            miComando.ExecuteNonQuery()

            miComando = New SqlCommand("UPDATE Reu_General " & _
            " SET ReuFecha = @ReuFecha " & _
            " WHERE ReuID = @ReuID", ActualizarConexion)

            miComando.Parameters.AddWithValue("@ReuID", ReunionId)
            miComando.Parameters.AddWithValue("@ReuFecha", ReunionInicio)

            miComando.Transaction = transaccion_sql
            miComando.ExecuteNonQuery()

            transaccion_sql.Commit()
            ActualizarConexion.Close()
            Return NumBita
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

    Public Function NuevoPendiente(ByVal Reu_NombrePendiente As String, ByVal Reu_DescripcionPendiente As String, ByVal Reu_TemaID As Integer, ByVal Reu_Fecha As DateTime, ByVal Reu_Asignado As String, ByVal Reu_Solicitante As String, ByVal Reu_Reunion As Integer, ByVal Reu_Registro As Integer, ByVal Fecha As Date, ByVal dta As DataTable)

        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand
            'Guarda nueva marca

            Dim NumBita As Integer = 0
            Dim DtBita As New DataTable
            Dim QueryBita As String
            QueryBita = "SELECT MAX (Reu_PendienteID) FROM Reu_Pendientes"
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
            miComando = New SqlCommand("INSERT INTO dbo.Reu_Pendientes " & _
            " (Reu_PendienteID, Reu_NombrePendiente, Reu_DescripcionPendiente, Reu_TemaID, Reu_Fecha, Reu_EstadoPend, Reu_Asignado, Reu_Solicitante, Reu_Reunion, Reu_Registro, EntregaPrevista) " & _
            " VALUES (@Reu_PendienteID,  EncryptByPassPhrase('Disar2308',@Reu_NombrePendiente) , EncryptByPassPhrase('Disar2308',@Reu_DescripcionPendiente), @Reu_TemaID, @Reu_Fecha, @Reu_EstadoPend, @Reu_Asignado, @Reu_Solicitante, @Reu_Reunion, @Reu_Registro, @EntregaPrevista)", ActualizarConexion)

            miComando.Parameters.AddWithValue("@Reu_PendienteID", NumBita)

            miComando.Parameters.Add("@Reu_NombrePendiente", SqlDbType.VarChar, 8000)
            miComando.Parameters("@Reu_NombrePendiente").Value = Reu_NombrePendiente

            miComando.Parameters.Add("@Reu_DescripcionPendiente", SqlDbType.VarChar, 8000)
            miComando.Parameters("@Reu_DescripcionPendiente").Value = Reu_DescripcionPendiente
            miComando.Parameters.AddWithValue("@Reu_TemaID", Reu_TemaID)
            miComando.Parameters.AddWithValue("@Reu_Fecha", Reu_Fecha)
            miComando.Parameters.AddWithValue("@Reu_EstadoPend", "Pendiente")
            miComando.Parameters.AddWithValue("@Reu_Asignado", dta(0)(0))
            miComando.Parameters.AddWithValue("@Reu_Solicitante", Reu_Solicitante)
            miComando.Parameters.AddWithValue("@Reu_Reunion", Reu_Reunion)
            miComando.Parameters.AddWithValue("@Reu_Registro", Reu_Registro)

            miComando.Parameters.AddWithValue("@EntregaPrevista", Fecha.Date)

            miComando.Transaction = transaccion_sql
            miComando.ExecuteNonQuery()

            For index As Integer = 0 To dta.Rows.Count - 1
                miComando = New SqlCommand("INSERT INTO dbo.Reu_Asignaciones " & _
            " (Pendiente, Asignado, Estado) " & _
            " VALUES (@Pendiente, @Asignado, @Estado)", ActualizarConexion)

                miComando.Parameters.AddWithValue("@Pendiente", NumBita)
                miComando.Parameters.AddWithValue("@Asignado", dta(index)(0))
                miComando.Parameters.AddWithValue("@Estado", "Pendiente")

                miComando.Transaction = transaccion_sql
                miComando.ExecuteNonQuery()
            Next

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

    Public Function MuestraPendientesReunion(ByVal Reunion As Integer)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand(" SELECT     dbo.Reu_Pendientes.Reu_PendienteID as ID, CONVERT(Varchar(MAX), DecryptByPassphrase('Disar2308', Reu_NombrePendiente)) as Nombre, CONVERT(Varchar(MAX),DecryptByPassphrase('Disar2308', Reu_DescripcionPendiente)) as Detalle, " & _
                      " dbo.Reu_Pendientes.Reu_TemaID as 'Nom', CONVERT(Varchar(MAX), DecryptByPassphrase('Disar2308', dbo.Reu_Temas.ReuTemaNombre)) as 'Tema', dbo.Reu_Pendientes.Reu_Fecha as Fecha, dbo.Reu_Pendientes.Reu_EstadoPend as Estado, " & _
                      " dbo.Reu_Pendientes.Reu_Asignado as Asignado, dbo.[User].UsuarioNombre as 'Asignado a', dbo.Reu_Pendientes.Reu_Solicitante as Solicitante, dbo.Reu_Pendientes.Reu_Reunion as Reunion, " & _
                      " dbo.Reu_Pendientes.Reu_Registro as 'Registro', CASE WHEN (DATEDIFF(Week, Reu_Fecha, GETDATE()) = 0) THEN CONVERT(Varchar, DATEDIFF(Day, Reu_Fecha, " & _
                      " GETDATE())) + ' días' ELSE CONVERT(Varchar, DATEDIFF(Week, Reu_Fecha, GETDATE())) + ' semanas' END AS Antiguedad, EntregaPrevista, CASE WHEN (EntregaPrevista <= GETDATE() AND Entrega IS NULL) THEN CASE WHEN (DATEDIFF(Week, Reu_Fecha, GETDATE()) = 0) THEN CONVERT(Varchar, DATEDIFF(Day, Reu_Fecha, GETDATE())) " & _
                      "   + ' días' ELSE CONVERT(Varchar, DATEDIFF(Week, EntregaPrevista, GETDATE())) + ' semanas' END ELSE '' END AS [VENCIDA DESDE] " & _
                      " FROM         dbo.Reu_Pendientes INNER JOIN dbo.[User] ON dbo.Reu_Pendientes.Reu_Asignado = dbo.[User].UsuarioNick INNER JOIN " & _
                      " dbo.Reu_Temas ON dbo.Reu_Pendientes.Reu_TemaID = dbo.Reu_Temas.ReuTemaID WHERE dbo.Reu_Pendientes.Reu_Reunion = @Reunion  And (Reu_EstadoPend = 'Pendiente' OR dbo.Reu_Pendientes.Reu_EstadoPend = 'En Seguimiento')", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Reunion", Reunion)

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

    Public Function MuestraTodosPendientesReunion()
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand(" SELECT     dbo.Reu_Pendientes.Reu_PendienteID AS ID, CONVERT(Varchar(MAX), DecryptByPassphrase('Disar2308', Reu_NombrePendiente)) AS Nombre,  CONVERT(Varchar(MAX), DecryptByPassphrase('Disar2308', Reu_DescripcionPendiente)) AS Detalle, " & _
                      " dbo.Reu_Pendientes.Reu_TemaID AS 'Nom', CONVERT(Varchar(MAX), DecryptByPassphrase('Disar2308', dbo.Reu_Temas.ReuTemaNombre))  AS 'Tema', dbo.Reu_Pendientes.Reu_Fecha AS Fecha, " & _
                      " dbo.Reu_Pendientes.Reu_EstadoPend AS Estado, dbo.Reu_Pendientes.Reu_Asignado AS Asignado, dbo.[User].UsuarioNombre AS 'Asignado a', " & _
                      " dbo.Reu_Pendientes.Reu_Solicitante AS Solicitante, dbo.Reu_Pendientes.Reu_Reunion AS Reunion, dbo.Reu_Pendientes.Reu_Registro AS 'Registro', " & _
                      " dbo.Reu_General.ReuNombre AS 'Solicitado en', CASE WHEN (DATEDIFF(Week, Reu_Fecha, GETDATE()) = 0) THEN CONVERT(Varchar, DATEDIFF(Day, Reu_Fecha, " & _
                      " GETDATE())) + ' días' ELSE CONVERT(Varchar, DATEDIFF(Week, Reu_Fecha, GETDATE())) + ' semanas' END AS Antiguedad, EntregaPrevista, CASE WHEN (EntregaPrevista <= GETDATE() AND Entrega IS NULL) THEN CASE WHEN (DATEDIFF(Week, Reu_Fecha, GETDATE()) = 0) THEN CONVERT(Varchar, DATEDIFF(Day, Reu_Fecha, GETDATE())) " & _
                      "   + ' días' ELSE CONVERT(Varchar, DATEDIFF(Week, EntregaPrevista, GETDATE())) + ' semanas' END ELSE '' END AS [VENCIDA DESDE] " & _
                      " FROM  dbo.Reu_Pendientes INNER JOIN " & _
                      " dbo.[User] ON dbo.Reu_Pendientes.Reu_Asignado = dbo.[User].UsuarioNick INNER JOIN " & _
                      " dbo.Reu_Temas ON dbo.Reu_Pendientes.Reu_TemaID = dbo.Reu_Temas.ReuTemaID INNER JOIN dbo.Reu_General ON dbo.Reu_Temas.ReuID = dbo.Reu_General.ReuID " & _
                      " WHERE     (dbo.Reu_Pendientes.Reu_EstadoPend = 'Pendiente') OR (dbo.Reu_Pendientes.Reu_EstadoPend = 'En Seguimiento')", ActualizarConexion)

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

    Public Function MuestraPendientesUsuario(ByVal Usuario As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand(" SELECT     dbo.Reu_Pendientes.Reu_PendienteID AS ID, CONVERT(Varchar(MAX), DecryptByPassphrase('Disar2308', dbo.Reu_Pendientes.Reu_NombrePendiente)) AS Nombre, " & _
                      " CONVERT(Varchar(MAX), DecryptByPassphrase('Disar2308', dbo.Reu_Pendientes.Reu_DescripcionPendiente)) AS Detalle, " & _
                      " dbo.Reu_Pendientes.Reu_TemaID AS 'Nom', CONVERT(Varchar(MAX), DecryptByPassphrase('Disar2308', dbo.Reu_Temas.ReuTemaNombre)) AS 'Tema', " & _
                      " dbo.Reu_Pendientes.Reu_Fecha AS Fecha, dbo.Reu_Pendientes.Reu_EstadoPend AS Estado, dbo.Reu_Pendientes.Reu_Asignado AS Asignado, " & _
                      " dbo.[User].UsuarioNombre AS 'Asignado a', dbo.Reu_Pendientes.Reu_Solicitante AS Solicitante, dbo.Reu_Pendientes.Reu_Reunion AS Reunion,  " & _
                      " dbo.Reu_Pendientes.Reu_Registro AS 'Registro', CASE WHEN (DATEDIFF(Week, Reu_Fecha, GETDATE()) = 0) THEN CONVERT(Varchar, DATEDIFF(Day, Reu_Fecha,  " & _
                      " GETDATE())) + ' días' ELSE CONVERT(Varchar, DATEDIFF(Week, Reu_Fecha, GETDATE())) + ' semanas' END AS Antiguedad, " & _
                      " dbo.Reu_Pendientes.EntregaPrevista FROM         dbo.Reu_Asignaciones INNER JOIN " & _
                      " dbo.Reu_Pendientes ON dbo.Reu_Asignaciones.Pendiente = dbo.Reu_Pendientes.Reu_PendienteID INNER JOIN " & _
                      " dbo.[User] ON dbo.Reu_Asignaciones.Asignado = dbo.[User].UsuarioNick INNER JOIN " & _
                      " dbo.Reu_Temas ON dbo.Reu_Pendientes.Reu_TemaID = dbo.Reu_Temas.ReuTemaID " & _
                      " WHERE     (dbo.Reu_Asignaciones.Asignado = @Usuario) AND (dbo.Reu_Asignaciones.Estado = 'Pendiente')", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Usuario", Usuario)

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

    Public Function ModificaEstadoPendiente(ByVal Pend As Integer, ByVal Estado As String, ByVal Fecha As Date, ByVal dt As DataTable)

        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand
            'Guarda nuevo
            'MsgBox("Filas: " & dt.Rows.Count)

            For a = 0 To dt.Rows.Count - 1

                Dim comando As String = "UPDATE Reu_Asignaciones  SET Estado = @Estado, Fecha = @Fecha " & _
                " WHERE Reu_Asignaciones.Pendiente = " & Pend & " AND Reu_Asignaciones.Asignado = '" & dt(a)(0) & "'"



                miComando = New SqlCommand(comando, ActualizarConexion)
                miComando.Parameters.AddWithValue("@Fecha", Today.Date)
                miComando.Parameters.AddWithValue("@Estado", Estado)

                'MsgBox(miComando.ToString)
                miComando.Transaction = transaccion_sql
                miComando.ExecuteNonQuery()

            Next

            Dim NumBita As Integer = 0
            Dim DtBita As New DataTable
            Dim QueryBita As String
            QueryBita = "SELECT Pendiente, Asignado, Estado FROM Reu_Asignaciones where estado = 'Pendiente' and Pendiente = @Pendiente"
            Dim CMDQueryBita As New SqlCommand(QueryBita, ActualizarConexion)
            CMDQueryBita.Parameters.AddWithValue("@Pendiente", Pend)
            Dim AdaptadorBita As New SqlDataAdapter(CMDQueryBita)
            CMDQueryBita.Transaction = transaccion_sql
            AdaptadorBita.Fill(DtBita)

            If DtBita.Rows.Count > 0 Then
                If Not IsDBNull(DtBita.Rows(0)(0)) Then
                    NumBita = 1
                End If
            End If

            If NumBita = 0 Then
                miComando = New SqlCommand("UPDATE Reu_Pendientes " & _
                " SET Reu_EstadoPend = @Estado, Entrega = @Fecha " & _
                " WHERE Reu_PendienteID = @Pendiente", ActualizarConexion)

                miComando.Parameters.AddWithValue("@Pendiente", Pend)
                miComando.Parameters.AddWithValue("@Estado", Estado)
                miComando.Parameters.AddWithValue("@Fecha", Fecha.Date)

                miComando.Transaction = transaccion_sql
                miComando.ExecuteNonQuery()
            End If

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

    Public Function TerminarReunion(ByVal dtParticipantes As DataTable, ByVal dtTareas As DataTable, ByVal Reu_Final As DateTime, ByVal Reu_Observaciones As String, ByVal Reu_UsuarioFinal As String, ByVal RegNum As Integer)

        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand
            'Guarda nueva marca

            For a As Integer = 0 To dtParticipantes.Rows.Count - 1

                Dim NumBita As Integer = 0
                Dim DtBita As New DataTable
                Dim QueryBita As String
                QueryBita = "SELECT MAX (Reu_ParticipacionID) FROM Reu_RegParticipacion"
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

                miComando = New SqlCommand("INSERT INTO Reu_RegParticipacion " & _
                " (Reu_ParticipacionID, Reu_RegNum, Reu_ParticipanteID, Reu_Medio, Reu_Asistencia, Reu_HoraAsistencia) " & _
                " VALUES (@Reu_ParticipacionID, @Reu_RegNum, @Reu_ParticipanteID, @Reu_Medio, @Reu_Asistencia, @Reu_HoraAsistencia)", ActualizarConexion)

                miComando.Parameters.AddWithValue("@Reu_ParticipacionID", NumBita)
                miComando.Parameters.AddWithValue("@Reu_RegNum", dtParticipantes(a)(1))
                miComando.Parameters.AddWithValue("@Reu_ParticipanteID", dtParticipantes(a)(2))
                miComando.Parameters.AddWithValue("@Reu_Medio", dtParticipantes(a)(3))
                miComando.Parameters.AddWithValue("@Reu_Asistencia", dtParticipantes(a)(4))
                miComando.Parameters.AddWithValue("@Reu_HoraAsistencia", dtParticipantes(a)(5))

                miComando.Transaction = transaccion_sql
                miComando.ExecuteNonQuery()
            Next

            For a As Integer = 0 To dtTareas.Rows.Count - 1

                Dim NumBita As Integer = 0
                Dim DtBita As New DataTable
                Dim QueryBita As String
                QueryBita = "SELECT MAX (Reu_RegTarea) FROM Reu_RegTareas"
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

                miComando = New SqlCommand("INSERT INTO Reu_RegTareas " & _
                " (Reu_RegTarea, Reu_RegID, Reu_Descripcion, Reu_TareaID, Reu_EstadoTarea) " & _
                " VALUES (@Reu_RegTarea, @Reu_RegID, @Reu_Descripcion, @Reu_TareaID, @Reu_EstadoTarea)", ActualizarConexion)

                miComando.Parameters.AddWithValue("@Reu_RegTarea", NumBita)
                miComando.Parameters.AddWithValue("@Reu_RegID", dtTareas(a)(1))
                miComando.Parameters.AddWithValue("@Reu_Descripcion", dtTareas(a)(2))
                miComando.Parameters.AddWithValue("@Reu_TareaID", dtTareas(a)(3))
                miComando.Parameters.AddWithValue("@Reu_EstadoTarea", dtTareas(a)(4))

                miComando.Transaction = transaccion_sql
                miComando.ExecuteNonQuery()
            Next


            miComando = New SqlCommand("UPDATE  Reu_RegReuniones " & _
            " SET Reu_Final = @Reu_Final, Reu_Observaciones = @Reu_Observaciones, Reu_UsuarioFinal = @Reu_UsuarioFinal " & _
            " WHERE Reg_Num = @Reg_Num", ActualizarConexion)

            miComando.Parameters.AddWithValue("@Reg_Num", RegNum)
            miComando.Parameters.AddWithValue("@Reu_Final", Reu_Final)
            miComando.Parameters.AddWithValue("@Reu_Observaciones", Reu_Observaciones)
            miComando.Parameters.AddWithValue("@Reu_UsuarioFinal", Reu_UsuarioFinal)

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

    Public Function ReunionesCombo(ByVal User As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT  '100' as 'Nº', 'Todas' as 'Reunion' UNION ALL SELECT dbo.Reu_General.ReuID AS 'Nº', dbo.Reu_General.ReuNombre AS Reunion  FROM  dbo.[User] INNER JOIN " & _
                      " dbo.Reu_General ON dbo.[User].UsuarioNick = dbo.Reu_General.ReuReponsable INNER JOIN " & _
                      " dbo.Reu_Particip ON dbo.Reu_General.ReuID = dbo.Reu_Particip.ReuID WHERE (dbo.Reu_Particip.ReuEmpl = @Usuario)", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Usuario", User)

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

    Public Function HistorialReuniones(ByVal User As String, ByVal Fecha As Date, ByVal Fecha2 As Date)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT  dbo.Reu_RegReuniones.Reg_Num as 'Nº', dbo.Reu_RegParticipacion.Reu_ParticipanteID AS ID, dbo.Reu_RegParticipacion.Reu_Asistencia AS Asistencia, dbo.Reu_RegParticipacion.Reu_Medio AS Medio, " & _
                      " dbo.Reu_General.ReuNombre AS Reunion, dbo.Reu_General.ReuFecha AS Fecha, dbo.Reu_General.ReuInicio AS 'Inicio Previsto', " & _
                      " dbo.Reu_General.ReuFinal AS 'Final Previsto', convert(char(8), Reu_Inicio, 108) AS Inicio, convert(char(8), Reu_Final, 108) AS Final, " & _
                      " dbo.Reu_RegReuniones.Reu_Observaciones AS Observaciones, dbo.Reu_General.ReuReponsable as 'Responsable' FROM         dbo.Reu_RegReuniones INNER JOIN " & _
                      " dbo.Reu_General ON dbo.Reu_RegReuniones.Reu_ID = dbo.Reu_General.ReuID INNER JOIN " & _
                      " dbo.Reu_RegParticipacion ON dbo.Reu_RegReuniones.Reg_Num = dbo.Reu_RegParticipacion.Reu_RegNum WHERE (dbo.Reu_RegParticipacion.Reu_ParticipanteID = @Usuario) AND (Reu_Inicio>= @Fecha1) AND (Reu_Inicio <= DATEADD(day,1,@Fecha2))", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Usuario", User)
        miComando.Parameters.AddWithValue("@Fecha1", Fecha.Date)
        miComando.Parameters.AddWithValue("@Fecha2", Fecha2.Date)

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

    Public Function HistorialTemas(ByVal Reunion As Integer)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand(" SELECT  CONVERT(Varchar(MAX), DecryptByPassphrase('Disar2308', dbo.Reu_Temas.ReuTemaNombre)) as Tema, dbo.Reu_RegTareas.Reu_EstadoTarea as Detalle " & _
                                        " FROM         dbo.Reu_RegTareas INNER JOIN dbo.Reu_RegReuniones ON dbo.Reu_RegTareas.Reu_RegID = dbo.Reu_RegReuniones.Reg_Num INNER JOIN " & _
                                        " dbo.Reu_Temas ON dbo.Reu_RegTareas.Reu_TareaID = dbo.Reu_Temas.ReuTemaID  WHERE (REG_NUM = @ID)", ActualizarConexion)

        miComando.Parameters.AddWithValue("@ID", Reunion)

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

    Public Function HistorialAsistencias(ByVal Reunion As Integer)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand(" SELECT     dbo.[User].UsuarioNombre as Nombre, dbo.Reu_RegParticipacion.Reu_Asistencia as Asistencia, dbo.Reu_RegParticipacion.Reu_Medio as Medio, dbo.Reu_RegParticipacion.Reu_HoraAsistencia as Hora" & _
                                        " FROM dbo.Reu_RegReuniones INNER JOIN dbo.Reu_RegParticipacion ON dbo.Reu_RegReuniones.Reg_Num = dbo.Reu_RegParticipacion.Reu_RegNum INNER JOIN " & _
                                        " dbo.[User] ON dbo.Reu_RegParticipacion.Reu_ParticipanteID = dbo.[User].UsuarioNick WHERE (dbo.Reu_RegReuniones.Reg_Num = @ID)", ActualizarConexion)

        miComando.Parameters.AddWithValue("@ID", Reunion)

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

    Public Function HistorialAsignaciones(ByVal Reunion As Integer)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand(" SELECT    Reu_PendienteID as 'Nº', CONVERT(Varchar(MAX), DecryptByPassphrase('Disar2308', Reu_NombrePendiente)) AS Asignacion, dbo.Reu_Pendientes.Reu_Fecha AS Fecha, dbo.Reu_Pendientes.Reu_EstadoPend AS Estado, " & _
                                        " dbo.Reu_Pendientes.Reu_Solicitante AS Solicitante, CONVERT(Varchar(MAX), DecryptByPassphrase('Disar2308', dbo.Reu_Temas.ReuTemaNombre)) AS Tema, dbo.[User].UsuarioNombre AS 'Asignado a', " & _
                                        " CONVERT(Varchar(MAX), DecryptByPassphrase('Disar2308', Reu_DescripcionPendiente)) AS Detalle, CASE WHEN (DATEDIFF(Week, Reu_Fecha, GETDATE()) = 0) THEN CONVERT(Varchar, DATEDIFF(Day, Reu_Fecha, " & _
                      " GETDATE())) + ' días' ELSE CONVERT(Varchar, DATEDIFF(Week, Reu_Fecha, GETDATE())) + ' semanas' END AS Antiguedad, ISNULL(CONVERT(VARCHAR,EntregaPrevista),'Agregar Fecha') as 'Entrega Prevista', Entrega " & _
                      " FROM dbo.Reu_Pendientes INNER JOIN dbo.Reu_RegReuniones ON dbo.Reu_Pendientes.Reu_Registro = dbo.Reu_RegReuniones.Reg_Num INNER JOIN " & _
                                        " dbo.Reu_Temas ON dbo.Reu_Pendientes.Reu_TemaID = dbo.Reu_Temas.ReuTemaID INNER JOIN dbo.[User] ON dbo.Reu_Pendientes.Reu_Asignado = dbo.[User].UsuarioNick WHERE (dbo.Reu_RegReuniones.Reg_Num = @ID)", ActualizarConexion)

        miComando.Parameters.AddWithValue("@ID", Reunion)

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

    Public Function Correo(ByVal User As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT Correo FROM [User] WHERE UsuarioNick = @Usuario", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Usuario", User)

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

    Public Function ModificarParticipante(ByVal Participante As String, ByVal Estado As String, ByVal Reunion As Integer)

        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand
            'Guarda nueva marca


            miComando = New SqlCommand("UPDATE Reu_Particip " & _
            " SET   ReuFijo = @Estado " & _
            " WHERE ReuID = @Reunion And ReuEmpl = @Participante", ActualizarConexion)

            miComando.Parameters.AddWithValue("@Participante", Participante)
            miComando.Parameters.AddWithValue("@Reunion", Reunion)
            miComando.Parameters.AddWithValue("@Estado", Estado)

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

    Public Function Usuarios()
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT     UsuarioNick, UsuarioNombre FROM [User] WHERE     (UsuarioNombre IS NOT NULL) AND (UsuarioNick <> 'Administrador') ORDER BY UsuarioNombre", ActualizarConexion)
         
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

    Public Function UsuariosFiltro(ByVal Usuario As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT UsuarioNick, UsuarioNombre FROM [User] WHERE     (UsuarioNombre IS NOT NULL) AND (UsuarioNick LIKE '%" & Usuario & "%') ORDER BY UsuarioNombre", ActualizarConexion)

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

    Public Function INSERTARParticipante(ByVal Participante As String, ByVal Estado As String, ByVal Reunion As Integer)

        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand
            'Guarda nueva marca


            miComando = New SqlCommand("INSERT INTO Reu_Particip " & _
            " (ReuID, ReuEmpl, ReuFijo) " & _
            " VALUES(@ReuID, @ReuEmpl, @ReuFijo)", ActualizarConexion)

            miComando.Parameters.AddWithValue("@ReuEmpl", Participante)
            miComando.Parameters.AddWithValue("@ReuID", Reunion)
            miComando.Parameters.AddWithValue("@ReuFijo", "A")

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

    Public Function AgregarDetalleNuevaReunion(ByVal ReunionId As Integer, ByVal ReunionDescripcion As String, ByVal ReunionInicio As String, ByVal ReunionFinal As String, ByVal Responsable As String, ByVal Usuario As String, ByVal Participantes As DataTable, ByVal Temas As DataTable, ByVal Detalle As String, ByVal Periodo As String, ByVal Dia As String)

        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand
            'Guarda nueva marca

            Dim NumBita As Integer = 0
            Dim DtBita As New DataTable
            Dim QueryBita As String
            QueryBita = "SELECT MAX (ReuID) FROM Reu_General"
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
            miComando = New SqlCommand("INSERT INTO Reu_General " & _
            " (ReuID, ReuNombre, ReuInicio, ReuFinal, ReuReponsable, ReuPeriodo, ReuDia,   ReuDetalle) " & _
            " VALUES (@ReuID, @ReuNombre, @ReuInicio, @ReuFinal, @ReuReponsable, @ReuPeriodo, @ReuDia, @ReuDetalle)", ActualizarConexion)

            miComando.Parameters.AddWithValue("@ReuID", NumBita)
            miComando.Parameters.AddWithValue("@ReuNombre", ReunionDescripcion)
            miComando.Parameters.AddWithValue("@ReuInicio", ReunionInicio)
            miComando.Parameters.AddWithValue("@ReuFinal", ReunionFinal)
            miComando.Parameters.AddWithValue("@ReuReponsable", Responsable)
            miComando.Parameters.AddWithValue("@ReuPeriodo", Periodo)
            miComando.Parameters.AddWithValue("@ReuDia", Dia)
            miComando.Parameters.AddWithValue("@ReuDetalle", Detalle)

            miComando.Transaction = transaccion_sql
            miComando.ExecuteNonQuery()

            For tar As Integer = 0 To Temas.Rows.Count - 1
                Dim NumBita2 As Integer = 0
                Dim DtBita2 As New DataTable
                Dim QueryBita2 As String
                QueryBita2 = "SELECT MAX (ReuTemaID) FROM Reu_Temas"
                Dim CMDQueryBita2 As New SqlCommand(QueryBita2, ActualizarConexion)
                Dim AdaptadorBita2 As New SqlDataAdapter(CMDQueryBita2)
                CMDQueryBita2.Transaction = transaccion_sql
                AdaptadorBita2.Fill(DtBita2)

                If DtBita2.Rows.Count > 0 Then
                    If Not IsDBNull(DtBita2.Rows(0)(0)) Then
                        NumBita2 = DtBita2.Rows(0)(0)
                    End If
                End If

                NumBita2 += 1
                miComando = New SqlCommand("INSERT INTO Reu_Temas " & _
                " (ReuTemaID, ReuTemaNombre, ReuID) " & _
                " VALUES (@ReuTemaID, EncryptByPassPhrase('Disar2308',@ReuTemaNombre), @ReuID)", ActualizarConexion)

                miComando.Parameters.AddWithValue("@ReuTemaID", NumBita2)
                miComando.Parameters.Add("@ReuTemaNombre", SqlDbType.VarChar, 8000)
                miComando.Parameters("@ReuTemaNombre").Value = Temas(tar)(0)
                miComando.Parameters.AddWithValue("@ReuID", NumBita)

                miComando.Transaction = transaccion_sql
                miComando.ExecuteNonQuery()
            Next

            For tar As Integer = 0 To Participantes.Rows.Count - 1
                Dim NumBita2 As Integer = 0
                Dim DtBita2 As New DataTable
                Dim QueryBita2 As String
                QueryBita2 = "SELECT MAX (ReuID) FROM Reu_Particip"
                Dim CMDQueryBita2 As New SqlCommand(QueryBita2, ActualizarConexion)
                Dim AdaptadorBita2 As New SqlDataAdapter(CMDQueryBita2)
                CMDQueryBita2.Transaction = transaccion_sql
                AdaptadorBita2.Fill(DtBita2)

                If DtBita2.Rows.Count > 0 Then
                    If Not IsDBNull(DtBita2.Rows(0)(0)) Then
                        NumBita2 = DtBita2.Rows(0)(0)
                    End If
                End If

                NumBita2 += 1
                miComando = New SqlCommand("INSERT INTO Reu_Particip " & _
                " (ReuID, ReuEmpl, ReuFijo) " & _
                " VALUES (@ReuID, @ReuEmpl, @ReuFijo)", ActualizarConexion)

                miComando.Parameters.AddWithValue("@ReuFijo", "S")
                miComando.Parameters.AddWithValue("@ReuEmpl", Participantes(tar)(0))
                miComando.Parameters.AddWithValue("@ReuID", NumBita)

                miComando.Transaction = transaccion_sql
                miComando.ExecuteNonQuery()
            Next
             
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

    Public Function CancelarReunion(ByVal Reunion As Integer, ByVal ReunionRegistro As Integer)

        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand
            'Guarda nueva marca

            miComando = New SqlCommand("UPDATE  Reu_General " & _
            " SET   ReuFecha = @Null" & _
            " WHERE ReuID = @Reunion", ActualizarConexion)

            miComando.Parameters.AddWithValue("@Reunion", Reunion)
            miComando.Parameters.AddWithValue("@Null", DBNull.Value)


            miComando.Transaction = transaccion_sql
            miComando.ExecuteNonQuery()

            'Elimina

            miComando = New SqlCommand("DELETE FROM Reu_RegReuniones" & _
              " WHERE Reg_Num = @Reg_Num", ActualizarConexion)

            miComando.Parameters.AddWithValue("@Reg_Num", ReunionRegistro)

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

    Public Function INSERTARTema(ByVal Tema As String, ByVal Reunion As Integer)

        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand
            'Guarda nueva marca


            Dim NumBita2 As Integer = 0
            Dim DtBita2 As New DataTable
            Dim QueryBita2 As String
            QueryBita2 = "SELECT MAX (ReuTemaID) FROM Reu_Temas"
            Dim CMDQueryBita2 As New SqlCommand(QueryBita2, ActualizarConexion)
            Dim AdaptadorBita2 As New SqlDataAdapter(CMDQueryBita2)
            CMDQueryBita2.Transaction = transaccion_sql
            AdaptadorBita2.Fill(DtBita2)

            If DtBita2.Rows.Count > 0 Then
                If Not IsDBNull(DtBita2.Rows(0)(0)) Then
                    NumBita2 = DtBita2.Rows(0)(0)
                End If
            End If

            NumBita2 += 1
            miComando = New SqlCommand("INSERT INTO Reu_Temas " & _
            " (ReuTemaID, ReuTemaNombre, ReuID) " & _
            " VALUES (@ReuTemaID, EncryptByPassPhrase('Disar2308',@ReuTemaNombre), @ReuID)", ActualizarConexion)

            miComando.Parameters.AddWithValue("@ReuTemaID", NumBita2)
            miComando.Parameters.Add("@ReuTemaNombre", SqlDbType.VarChar, 8000)
            miComando.Parameters("@ReuTemaNombre").Value = Tema
            miComando.Parameters.AddWithValue("@ReuID", Reunion)

            miComando.Transaction = transaccion_sql
            miComando.ExecuteNonQuery()
            transaccion_sql.Commit()
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

    Public Function ModificaPendiente(ByVal Pend As Integer, ByVal Fecha As Date)

        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand
            'Guarda nueva marca


            miComando = New SqlCommand("UPDATE Reu_Pendientes " & _
            " SET EntregaPrevista = @Fecha " & _
            " WHERE Reu_PendienteID = @Pendiente", ActualizarConexion)

            miComando.Parameters.AddWithValue("@Fecha", Fecha.Date)
            miComando.Parameters.AddWithValue("@Pendiente", Pend)

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

    Public Function ControlPendientes(ByVal Fecha1 As Date, ByVal Fecha2 As Date, ByVal Usuario As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand(" SELECT     dbo.Reu_Pendientes.Reu_PendienteID AS ID, CONVERT(Varchar(MAX), DecryptByPassphrase('Disar2308', dbo.Reu_Pendientes.Reu_NombrePendiente)) AS Nombre, " & _
                      " CONVERT(Varchar(MAX), DecryptByPassphrase('Disar2308', dbo.Reu_Pendientes.Reu_DescripcionPendiente)) AS Detalle, " & _
                      " dbo.Reu_Pendientes.Reu_TemaID AS 'Nom', CONVERT(Varchar(MAX), DecryptByPassphrase('Disar2308', dbo.Reu_Temas.ReuTemaNombre)) AS 'Tema', " & _
                      " dbo.Reu_Pendientes.Reu_Fecha AS Fecha, dbo.Reu_Pendientes.Reu_EstadoPend AS Estado, dbo.Reu_Pendientes.Reu_Asignado AS Asignado, " & _
                      " dbo.[User].UsuarioNombre AS 'Asignado a', dbo.Reu_Pendientes.Reu_Solicitante AS Solicitante, dbo.Reu_Pendientes.Reu_Reunion AS Reunion, " & _
                      " dbo.Reu_Pendientes.Reu_Registro AS 'Registro', dbo.Reu_General.ReuNombre AS 'Solicitado en', CASE WHEN (DATEDIFF(Week, Reu_Fecha, GETDATE()) = 0) " & _
                      " THEN CONVERT(Varchar, DATEDIFF(Day, Reu_Fecha, GETDATE())) + ' días' ELSE CONVERT(Varchar, DATEDIFF(Week, Reu_Fecha, GETDATE())) " & _
                      " + ' semanas' END AS Antiguedad, dbo.Reu_Pendientes.EntregaPrevista, dbo.Reu_General.ReuReponsable as Respon,  dbo.Reu_Pendientes.Entrega as 'Fecha de Entrega' " & _
                      " FROM         dbo.Reu_Pendientes INNER JOIN " & _
                      " dbo.[User] ON dbo.Reu_Pendientes.Reu_Asignado = dbo.[User].UsuarioNick INNER JOIN " & _
                      " dbo.Reu_Temas ON dbo.Reu_Pendientes.Reu_TemaID = dbo.Reu_Temas.ReuTemaID INNER JOIN " & _
                      " dbo.Reu_General ON dbo.Reu_Temas.ReuID = dbo.Reu_General.ReuID INNER JOIN " & _
                      " dbo.Reu_Particip ON dbo.Reu_Temas.ReuID = dbo.Reu_Particip.ReuID " & _
                      " WHERE     (dbo.Reu_Particip.ReuEmpl = @USuario) AND (dbo.Reu_Pendientes.Reu_Fecha >= @Fecha1) AND (dbo.Reu_Pendientes.Reu_Fecha <= @Fecha2)" & _
                      " ", ActualizarConexion)

        ActualizarConexion.Open()
        miComando.Parameters.AddWithValue("@Usuario", Usuario)
        miComando.Parameters.AddWithValue("@Fecha1", Fecha1.Date)
        miComando.Parameters.AddWithValue("@Fecha2", Fecha2.Date)
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

    Public Function ControlPendientesFiltrados(ByVal Fecha1 As Date, ByVal Fecha2 As Date, ByVal Usuario As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand(" SELECT     dbo.Reu_Pendientes.Reu_PendienteID AS ID, CONVERT(Varchar(MAX), DecryptByPassphrase('Disar2308', dbo.Reu_Pendientes.Reu_NombrePendiente)) AS Nombre, " & _
                      " CONVERT(Varchar(MAX), DecryptByPassphrase('Disar2308', dbo.Reu_Pendientes.Reu_DescripcionPendiente)) AS Detalle, " & _
                      " dbo.Reu_Pendientes.Reu_TemaID AS 'Nom', CONVERT(Varchar(MAX), DecryptByPassphrase('Disar2308', dbo.Reu_Temas.ReuTemaNombre)) AS 'Tema', " & _
                      " dbo.Reu_Pendientes.Reu_Fecha AS Fecha, dbo.Reu_Pendientes.Reu_EstadoPend AS Estado, dbo.Reu_Pendientes.Reu_Asignado AS Asignado, " & _
                      " dbo.[User].UsuarioNombre AS 'Asignado a', dbo.Reu_Pendientes.Reu_Solicitante AS Solicitante, dbo.Reu_Pendientes.Reu_Reunion AS Reunion, " & _
                      " dbo.Reu_Pendientes.Reu_Registro AS 'Registro', dbo.Reu_General.ReuNombre AS 'Solicitado en', CASE WHEN (DATEDIFF(Week, Reu_Fecha, GETDATE()) = 0) " & _
                      " THEN CONVERT(Varchar, DATEDIFF(Day, Reu_Fecha, GETDATE())) + ' días' ELSE CONVERT(Varchar, DATEDIFF(Week, Reu_Fecha, GETDATE())) " & _
                      " + ' semanas' END AS Antiguedad, dbo.Reu_Pendientes.EntregaPrevista, dbo.Reu_General.ReuReponsable as Respon " & _
                      " FROM         dbo.Reu_Pendientes INNER JOIN " & _
                      " dbo.[User] ON dbo.Reu_Pendientes.Reu_Asignado = dbo.[User].UsuarioNick INNER JOIN " & _
                      " dbo.Reu_Temas ON dbo.Reu_Pendientes.Reu_TemaID = dbo.Reu_Temas.ReuTemaID INNER JOIN " & _
                      " dbo.Reu_General ON dbo.Reu_Temas.ReuID = dbo.Reu_General.ReuID INNER JOIN " & _
                      " dbo.Reu_Particip ON dbo.Reu_Temas.ReuID = dbo.Reu_Particip.ReuID " & _
                      " WHERE     (dbo.Reu_Particip.ReuEmpl = @USuario) AND (dbo.Reu_Pendientes.Reu_Fecha >= @Fecha1) AND (dbo.Reu_Pendientes.Reu_Fecha <= @Fecha2) And dbo.Reu_Pendientes.Reu_EstadoPend = 'Pendiente'" & _
                      " ", ActualizarConexion)

        ActualizarConexion.Open()
        miComando.Parameters.AddWithValue("@Usuario", Usuario)
        miComando.Parameters.AddWithValue("@Fecha1", Fecha1.Date)
        miComando.Parameters.AddWithValue("@Fecha2", Fecha2.Date)
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

    Public Function ControlPendientesPorUsuario(ByVal Fecha1 As Date, ByVal Fecha2 As Date, ByVal Usuario As String, ByVal Asignado As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand(" SELECT     dbo.Reu_Pendientes.Reu_PendienteID AS ID, CONVERT(Varchar(MAX), DecryptByPassphrase('Disar2308', dbo.Reu_Pendientes.Reu_NombrePendiente)) AS Nombre, " & _
                      " CONVERT(Varchar(MAX), DecryptByPassphrase('Disar2308', dbo.Reu_Pendientes.Reu_DescripcionPendiente)) AS Detalle, " & _
                      " dbo.Reu_Pendientes.Reu_TemaID AS 'Nom', CONVERT(Varchar(MAX), DecryptByPassphrase('Disar2308', dbo.Reu_Temas.ReuTemaNombre)) AS 'Tema', " & _
                      " dbo.Reu_Pendientes.Reu_Fecha AS Fecha, dbo.Reu_Pendientes.Reu_EstadoPend AS Estado, dbo.Reu_Pendientes.Reu_Asignado AS Asignado, " & _
                      " dbo.[User].UsuarioNombre AS 'Asignado a', dbo.Reu_Pendientes.Reu_Solicitante AS Solicitante, dbo.Reu_Pendientes.Reu_Reunion AS Reunion, " & _
                      " dbo.Reu_Pendientes.Reu_Registro AS 'Registro', dbo.Reu_General.ReuNombre AS 'Solicitado en', CASE WHEN (DATEDIFF(Week, Reu_Fecha, GETDATE()) = 0) " & _
                      " THEN CONVERT(Varchar, DATEDIFF(Day, Reu_Fecha, GETDATE())) + ' días' ELSE CONVERT(Varchar, DATEDIFF(Week, Reu_Fecha, GETDATE())) " & _
                      " + ' semanas' END AS Antiguedad, dbo.Reu_Pendientes.EntregaPrevista, dbo.Reu_General.ReuReponsable as Respon,  dbo.Reu_Pendientes.Entrega as 'Fecha de Entrega' " & _
                      " FROM         dbo.Reu_Pendientes INNER JOIN " & _
                      " dbo.[User] ON dbo.Reu_Pendientes.Reu_Asignado = dbo.[User].UsuarioNick INNER JOIN " & _
                      " dbo.Reu_Temas ON dbo.Reu_Pendientes.Reu_TemaID = dbo.Reu_Temas.ReuTemaID INNER JOIN " & _
                      " dbo.Reu_General ON dbo.Reu_Temas.ReuID = dbo.Reu_General.ReuID INNER JOIN " & _
                      " dbo.Reu_Particip ON dbo.Reu_Temas.ReuID = dbo.Reu_Particip.ReuID " & _
                      " WHERE     (dbo.Reu_Particip.ReuEmpl = @USuario) AND (dbo.Reu_Pendientes.Reu_Fecha >= @Fecha1) AND (dbo.Reu_Pendientes.Reu_Fecha <= @Fecha2)" & _
                      " ", ActualizarConexion)

        ActualizarConexion.Open()
        miComando.Parameters.AddWithValue("@Usuario", Usuario)
        miComando.Parameters.AddWithValue("@Fecha1", Fecha1.Date)
        miComando.Parameters.AddWithValue("@Fecha2", Fecha2.Date)
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


    Public Function UsuariosXPendiente(ByVal ID As Integer)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT     dbo.[User].UsuarioNombre FROM dbo.Reu_Asignaciones INNER JOIN " & _
        " dbo.[User] ON dbo.Reu_Asignaciones.Asignado = dbo.[User].UsuarioNick WHERE (dbo.Reu_Asignaciones.Pendiente = @ID)" & _
        " ", ActualizarConexion)

        ActualizarConexion.Open()
        miComando.Parameters.AddWithValue("@ID", ID)
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

    Public Function UsuariosConPendientes()
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT . as Asignado, Todos as UsuarioNombre UNION ALL SELECT DISTINCT dbo.Reu_Asignaciones.Asignado, dbo.[User].UsuarioNombre " & _
                            " FROM         dbo.Reu_Asignaciones INNER JOIN " & _
                            " dbo.[User] ON dbo.Reu_Asignaciones.Asignado = dbo.[User].UsuarioNick" & _
                            " ", ActualizarConexion)

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
