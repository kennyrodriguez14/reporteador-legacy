Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class Clas_conexion_biometrico

    Dim ConexionUsuarios As New clsConexion

    Public Function Muestra()
        Dim conn As New System.Data.OleDb.OleDbConnection()

        conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\att2000.mdb;" & _
"Persist Security Info=False;"
        Try
            conn.Open()
            Return ("SI")
        Catch ex As Exception
            MsgBox("Failed to connect to data source")
            Return "Falló"
        End Try
        conn.Close()

    End Function

    Public Function CadenaSQL() As String
        Return "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & System.AppDomain.CurrentDomain.BaseDirectory() & "\att2000.mdb;Persist Security Info=False;"
    End Function

    Public Function CadenaSQLSPS() As String
        Return "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & System.AppDomain.CurrentDomain.BaseDirectory() & "\att2000SPS.mdb;Persist Security Info=False;"
    End Function

    Public Function CadenaSQLTGU() As String
        Return "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & System.AppDomain.CurrentDomain.BaseDirectory() & "\att2000TGU.mdb;Persist Security Info=False;"
    End Function

    Public Function CargarDatos(ByVal FechaInicio As Date, ByVal FechaFin As Date) As DataView
        Dim ActualizarConexion As New OleDbConnection(CadenaSQL())
        ActualizarConexion.Open()
        FechaFin = FechaFin.AddDays(1)

        Dim St As String
        Dim vueltas As Integer = 1
        'Dim FechaLimite = FechaInicio.Date
        'While FechaLimite <= FechaFin
        St = " SELECT USERINFO.NAME AS NOMBRE, CHECKINOUT.CHECKTIME AS TIEMPO " & _
" FROM CHECKINOUT INNER JOIN USERINFO ON USERINFO.UserID = CHECKINOUT.UserID WHERE " & _
"  CHECKINOUT.CHECKTIME >= @Fecha1 AND CHECKINOUT.CHECKTIME <= DATEADD('d'," & vueltas & " ,@Fecha2) AND CHECKINOUT.USERID IN (28, 22, 17, 29, 33, 34, 155, 30, 108, 97, 96, 95, 89, 82, 81, 57) "

        'vueltas += 1
        'FechaLimite = FechaLimite.AddDays(1)
        'If FechaLimite <= FechaFin Then
        ' St = St & " Union ALL "
        'End If
        'End While

        Dim Comando As New OleDbCommand(St, ActualizarConexion)

        Comando.Parameters.Add(New OleDbParameter("@Fecha1", OleDbType.Date)).Value = FechaInicio.Date
        Comando.Parameters.Add(New OleDbParameter("@Fecha2", OleDbType.Date)).Value = FechaFin.Date

        Dim AdaptadorDeDatos As New OleDbDataAdapter(Comando)
        Dim ds As New DataSet
        Dim dv As New DataView
        Try
            AdaptadorDeDatos.Fill(ds, "Inve")
            If ds.Tables("Inve").Rows.Count > 0 Then
                dv = New DataView(ds.Tables("Inve"))
            End If
        Catch ex As OleDbException
            MsgBox("Hay problemas de Conexión: " + ex.Message, MsgBoxStyle.Critical)

        End Try
        ActualizarConexion.Close()
        Return dv

    End Function

    Public Function CargarNombres(ByVal FechaInicio As Date, ByVal FechaFin As Date) As DataView
        Dim ActualizarConexion As New OleDbConnection(CadenaSQL())
        ActualizarConexion.Open()
        FechaFin = FechaFin.AddDays(1)

        Dim St As String = ""
        Dim vueltas As Integer = 1
        Dim FechaLimite = FechaInicio.Date
        St = " SELECT DISTINCT USERINFO.NAME AS NOMBRE " & _
    " FROM CHECKINOUT INNER JOIN USERINFO ON USERINFO.UserID = CHECKINOUT.UserID WHERE " & _
    "  CHECKINOUT.CHECKTIME >= @Fecha1 AND CHECKINOUT.CHECKTIME <= DATEADD('d'," & vueltas & " ,@Fecha2) AND CHECKINOUT.USERID IN (17, 22, 28, 29, 30, 33, 34, 57, 81, 82, 89, 95, 96, 97, 108, 155) "

        Dim Comando As New OleDbCommand(St, ActualizarConexion)

        Comando.Parameters.Add(New OleDbParameter("@Fecha1", OleDbType.Date)).Value = FechaInicio.Date
        Comando.Parameters.Add(New OleDbParameter("@Fecha2", OleDbType.Date)).Value = FechaFin.Date

        Dim AdaptadorDeDatos As New OleDbDataAdapter(Comando)
        Dim ds As New DataSet
        Dim dv As New DataView
        Try
            AdaptadorDeDatos.Fill(ds, "Inve")
            If ds.Tables("Inve").Rows.Count > 0 Then
                dv = New DataView(ds.Tables("Inve"))
            End If
        Catch ex As OleDbException
            MsgBox("Hay problemas de Conexión: " + ex.Message, MsgBoxStyle.Critical)

        End Try
        ActualizarConexion.Close()
        Return dv

    End Function

    Public Function TODOSDatos(ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal Sucursal As String) As DataView
        Dim ActualizarConexion As New OleDbConnection(CadenaSQL())
        If Sucursal = "SPS" Then
            ActualizarConexion = New OleDbConnection(CadenaSQLSPS())
        End If
        If Sucursal = "TEGUCIGALPA" Then
            ActualizarConexion = New OleDbConnection(CadenaSQLTGU())
        End If
        ActualizarConexion.Open()
        FechaFin = FechaFin.AddDays(1)

        Dim St As String
        Dim vueltas As Integer = 1
        'Dim FechaLimite = FechaInicio.Date
        'While FechaLimite <= FechaFin
        St = " SELECT USERINFO.NAME AS NOMBRE, CHECKINOUT.CHECKTIME AS TIEMPO " & _
" FROM CHECKINOUT INNER JOIN USERINFO ON USERINFO.UserID = CHECKINOUT.UserID WHERE " & _
"  CHECKINOUT.CHECKTIME >= @Fecha1 AND CHECKINOUT.CHECKTIME <= DATEADD('d'," & vueltas & " ,@Fecha2) "

        'vueltas += 1
        'FechaLimite = FechaLimite.AddDays(1)
        'If FechaLimite <= FechaFin Then
        ' St = St & " Union ALL "
        'End If
        'End While

        Dim Comando As New OleDbCommand(St, ActualizarConexion)

        Comando.Parameters.Add(New OleDbParameter("@Fecha1", OleDbType.Date)).Value = FechaInicio.Date
        Comando.Parameters.Add(New OleDbParameter("@Fecha2", OleDbType.Date)).Value = FechaFin.Date

        Dim AdaptadorDeDatos As New OleDbDataAdapter(Comando)
        Dim ds As New DataSet
        Dim dv As New DataView
        Try
            AdaptadorDeDatos.Fill(ds, "Inve")
            If ds.Tables("Inve").Rows.Count > 0 Then
                dv = New DataView(ds.Tables("Inve"))
            End If
        Catch ex As OleDbException
            MsgBox("Hay problemas de Conexión: " + ex.Message, MsgBoxStyle.Critical)

        End Try
        ActualizarConexion.Close()
        Return dv

    End Function

    Public Function TodosNombres(ByVal Sucursal As String) As DataView
        Dim ActualizarConexion As New SqlConnection(ConexionUsuarios.CadenaSQL())
        ActualizarConexion.Open()
        Dim AdaptadorDeDatos As New SqlDataAdapter("SELECT ID, Nombre FROM Biometrico WHERE Sucursal = '" & Sucursal & "' AND Departamento NOT LIKE '%OFICINA%' ORDER BY NOMBRE ", ActualizarConexion)
        Dim ds As New DataSet
        Dim dv As New DataView
        Try
            AdaptadorDeDatos.Fill(ds, "Vendedores")
            If ds.Tables("Vendedores").Rows.Count > 0 Then
                dv = New DataView(ds.Tables("Vendedores"))
            End If
        Catch ex As SqlException
            'MsgBox("Hay problemas de Conexión: " + ex.Message, MsgBoxStyle.Critical)

        End Try
        ActualizarConexion.Close()
        Return dv
    End Function

    Public Function HorasTrabajadas(ByVal FechaInicio As Date, ByVal ID As Integer, ByVal Tipo As String) As DataView
        Dim ActualizarConexion As New OleDbConnection(CadenaSQL())
        ActualizarConexion.Open()
        Dim FechaFin = FechaInicio.AddDays(1)

        Dim St As String
        Dim vueltas As Integer = 1
        Dim FechaFinal As Date = DateAdd(DateInterval.Day, 1, FechaInicio.Date)
        'While FechaLimite <= FechaFin
        If Tipo = "I" Then
            St = " SELECT TOP 1 CHECKINOUT.CHECKTIME, CHECKINOUT.USERID FROM CHECKINOUT " & _
            "WHERE (((CHECKINOUT.CHECKTIME) Between @Fecha1 And @Fecha2) AND ((CHECKINOUT.USERID)=@ID)); "
        Else
            St = " SELECT TOP 1 CHECKINOUT.CHECKTIME AS TIEMPO " & _
" FROM CHECKINOUT  WHERE " & _
"  CHECKINOUT.CHECKTIME Between @Fecha1 AND @Fecha2 AND CHECKINOUT.USERID LIKE @ID ORDER BY CHECKINOUT.CHECKTIME DESC "
        End If

        'vueltas += 1
        'FechaLimite = FechaLimite.AddDays(1)
        'If FechaLimite <= FechaFin Then
        ' St = St & " Union ALL "
        'End If
        'End While

        Dim Comando As New OleDbCommand(St, ActualizarConexion)

        Comando.Parameters.AddWithValue("@Fecha1", FechaInicio.Date)
        Comando.Parameters.AddWithValue("@Fecha2", FechaFin.Date)
        Comando.Parameters.AddWithValue("@ID", ID)

        Dim AdaptadorDeDatos As New OleDbDataAdapter(Comando)
        Dim ds As New DataSet
        Dim dv As New DataView
        Try
            AdaptadorDeDatos.Fill(ds, "Inve")
            If ds.Tables("Inve").Rows.Count > 0 Then
                dv = New DataView(ds.Tables("Inve"))
            End If
        Catch ex As OleDbException
            MsgBox("Hay problemas de Conexión: " + ex.Message, MsgBoxStyle.Critical)

        End Try
        ActualizarConexion.Close()
        Return dv

    End Function

    Public Function HorasTrabajadasSQL(ByVal FechaInicio As Date, ByVal ID As Integer, ByVal Tipo As String, ByVal Tabla As String) As DataView
        Dim ActualizarConexion As New SqlConnection(ConexionUsuarios.CadenaSQL())
        ActualizarConexion.Open()

        Dim FechaFin = FechaInicio.AddDays(1)
        Dim St As String

        If Tipo = "I" Then
            St = " SELECT TOP 1 CHECKTIME AS TIEMPO FROM " & Tabla & " " & _
            "WHERE (CHECKTIME >= @Fecha1) And (CHECKTIME <= @Fecha2) AND (USERID = @ID) ORDER BY CHECKTIME "
        Else
            St = " SELECT TOP 1 CHECKTIME AS TIEMPO " & _
            " FROM " & Tabla & "  WHERE " & _
            " (CHECKTIME >= @Fecha1) AND (CHECKTIME <= @Fecha2) AND (USERID = @ID) ORDER BY CHECKTIME DESC"
        End If

        Dim Comando As New SqlCommand(St, ActualizarConexion)

        Comando.Parameters.AddWithValue("@Fecha1", FechaInicio.Date)
        Comando.Parameters.AddWithValue("@Fecha2", FechaFin.Date)
        Comando.Parameters.AddWithValue("@ID", ID)

        Dim AdaptadorDeDatos As New SqlDataAdapter(Comando)
        Dim ds As New DataSet
        Dim dv As New DataView
        Try
            AdaptadorDeDatos.Fill(ds, "Vendedores")
            If ds.Tables("Vendedores").Rows.Count > 0 Then
                dv = New DataView(ds.Tables("Vendedores"))
            End If
        Catch ex As SqlException
            MsgBox("Hay problemas de Conexión: " + ex.Message, MsgBoxStyle.Critical)

        End Try
        ActualizarConexion.Close()
        Return dv
    End Function

    Public Function CargaNombresDepartamento(ByVal Sucursal As String, ByVal Departamento As String) As DataView
        Dim ActualizarConexion As New SqlConnection(ConexionUsuarios.CadenaSQL())
        ActualizarConexion.Open()
        Dim AdaptadorDeDatos As New SqlDataAdapter("SELECT ID, Nombre FROM Biometrico WHERE Sucursal = '" & Sucursal & "' AND Departamento = '" & Departamento & "' ORDER BY NOMBRE ", ActualizarConexion)
        Dim ds As New DataSet
        Dim dv As New DataView
        Try
            AdaptadorDeDatos.Fill(ds, "Vendedores")
            If ds.Tables("Vendedores").Rows.Count > 0 Then
                dv = New DataView(ds.Tables("Vendedores"))
            End If
        Catch ex As SqlException
            'MsgBox("Hay problemas de Conexión: " + ex.Message, MsgBoxStyle.Critical)

        End Try
        ActualizarConexion.Close()
        Return dv
    End Function

    Public Function Revisar(ByVal Sucursal As String, ByVal Departamento As String, ByVal Usuario As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionUsuarios.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT     UsuarioNick, Departamento, Sucursal " & _
        " FROM Usuarios_Departamento  WHERE     (UsuarioNick = '" & Usuario & "') AND (Departamento = '" & Departamento & "') AND (Sucursal = '" & Sucursal & "') OR " & _
        "              (UsuarioNick = '" & Usuario & "') AND (Departamento = 'Todos') AND (Sucursal = '" & Sucursal & "')", ActualizarConexion)

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

    Public Function Departamentos() As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionUsuarios.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT        'Todos' AS Departamento UNION ALL SELECT DISTINCT Departamento " & _
                                        " FROM            Biometrico", ActualizarConexion)

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
