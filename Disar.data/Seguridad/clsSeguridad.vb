Imports System.Data.SqlClient
Imports System.Text

Public Class clsSeguridad
    Dim Conexion As New clsConexion

    Public Function ListarUsuarios() As DataView
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim AdaptadorDeDatos As New SqlDataAdapter("SELECT [UsuarioId] as Id,[UsuarioNick] as Nick,[UsuarioPass] as Pass,[UsuarioEstado] as Estado,[UsuarioTipo] as Tipo, isnull(Departamento,'') as Departamento, ISNULL(AceptaRemisiones,0)  FROM [Usuarios].[dbo].[User]", ActualizarConexion)
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

    Public Function BuscarUsuarios(ByVal Usuario As String) As DataView
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim AdaptadorDeDatos As New SqlDataAdapter("SELECT [UsuarioId] as Id,[UsuarioNick] as Nick,[UsuarioPass] as Pass,[UsuarioEstado] as Estado,[UsuarioTipo] as Tipo  FROM [Usuarios].[dbo].[User] WHERE UsuarioNick Like '%" & Usuario & "%' or UsuarioNombre Like '%" & Usuario & "%'", ActualizarConexion)
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

    Public Function Nuevo(ByVal usu As String, ByVal pass As String, ByVal estado As String, ByVal tipo As String) As Boolean
        Dim Fallo As Boolean = False
        Try
            Using CadenaConexion As New SqlConnection(Conexion.CadenaSQL())
                Const SQL As String = "INSERT INTO [Usuarios].[dbo].[User] (UsuarioNick,UsuarioPass,UsuarioEstado,UsuarioTipo) VALUES(@Usuario,@UserPass,@Estado,@Tipo)"

                Dim AddDatos As New SqlCommand(SQL, CadenaConexion)
                AddDatos.Parameters.AddWithValue("@Usuario", usu)
                AddDatos.Parameters.AddWithValue("@UserPass", pass)
                AddDatos.Parameters.AddWithValue("@Estado", estado)
                AddDatos.Parameters.AddWithValue("@Tipo", tipo)
                CadenaConexion.Open()
                AddDatos.ExecuteNonQuery()
                CadenaConexion.Close()
                Fallo = True
            End Using
            Return Fallo
        Catch SqlEX As SqlException
            MsgBox(SqlEX.Message)
            Return Fallo
        End Try
    End Function

    Public Function Modificar(ByVal Id As Integer, ByVal usu As String, ByVal pass As String, ByVal estado As String, ByVal tipo As String) As Boolean
        Dim Fallo As Boolean = False
        Try
            Using CadenaConexion As New SqlConnection(Conexion.CadenaSQL())

                Const SQL As String = "UPDATE [Usuarios].[dbo].[User] SET [UsuarioNick] = @Usu,[UsuarioPass] =@Pass,[UsuarioEstado] =@UsuEstado,[UsuarioTipo] =@UsuTip WHERE UsuarioId =@Id"
                Dim AddDatos As New SqlCommand(SQL, CadenaConexion)
                AddDatos.Parameters.AddWithValue("@Id", Id)
                AddDatos.Parameters.AddWithValue("@Usu", usu)
                AddDatos.Parameters.AddWithValue("@Pass", pass)
                AddDatos.Parameters.AddWithValue("@UsuEstado", estado)
                AddDatos.Parameters.AddWithValue("@UsuTip", tipo)
                CadenaConexion.Open()
                AddDatos.ExecuteNonQuery()
                CadenaConexion.Close()
                Fallo = True
            End Using
            Return Fallo
        Catch SqlEX As SqlException
            Return Fallo
        End Try
    End Function

    Public Function CambiarPass(ByVal Id As Integer, ByVal pass As String) As Boolean
        Dim Fallo As Boolean = False
        Try
            Using CadenaConexion As New SqlConnection(Conexion.CadenaSQL())

                Const SQL As String = "UPDATE [Usuarios].[dbo].[User] SET [UsuarioPass] =@Pass WHERE UsuarioId =@Id"
                Dim AddDatos As New SqlCommand(SQL, CadenaConexion)
                AddDatos.Parameters.AddWithValue("@Id", Id)
                AddDatos.Parameters.AddWithValue("@Pass", pass)
                CadenaConexion.Open()
                AddDatos.ExecuteNonQuery()
                CadenaConexion.Close()
                Fallo = True
            End Using
            Return Fallo
        Catch SqlEX As SqlException
            Return Fallo
        End Try
    End Function

    Public Function ListarTiposUsuarios(ByVal SUCURSAL As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("ListadePresupuestos", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@SUCURSAL", SqlDbType.VarChar)).Value = SUCURSAL
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

    Public Function datosux(ByVal USUARIO As Integer) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim query As New StringBuilder
        query.Append("SELECT  ISNULL(mdl_reportes,0) AS M1, ISNULL(mdl_logistica,0) AS M2,ISNULL(mdl_contabilidad,0) AS M3, ")
        query.Append("	ISNULL(mdl_inventarios,0) AS M4,ISNULL(mdl_almacen,0) AS M5, ISNULL(mdl_pdse,0) AS M6, ")
        query.Append("	ISNULL(mdl_bonificaciones,0) AS M7,ISNULL(mdl_configuracion,0) AS M8,ISNULL(mdl_monitoreo,0) AS M9, ")
        query.Append("  ISNULL(Empresa,'') AS M10, ISNULL(REMALMACEN,0) as M11, ISNULL(mdl_adicional,0) as M12, ISNULL(Cancela_NC,'0') AS M13, ISNULL(PermisoDIMOSA,'0') as M14, ISNULL(PERMISOSANRAFAEL,0) as M15, ISNULL(PERMISOSRAgro,0) as M16, ISNULL(MultiplesSucursales,0) as M17, ISNULL(PERMISOOPL,0) as M18 ")
        query.Append("FROM    [User] ")
        query.Append("WHERE UsuarioId = @USUARIO")

        Dim miComando As New SqlCommand(query.ToString, ActualizarConexion)
        miComando.Parameters.AddWithValue("@USUARIO", USUARIO)
        ActualizarConexion.Open()

        Dim AdaptadorDeDatos As New SqlDataAdapter(miComando)
        Dim dt As New DataTable
        AdaptadorDeDatos.Fill(dt)
        ActualizarConexion.Close()
        Return dt
    End Function

    Public Function Permisos(ByVal USUARIO As Integer, ByVal MODULO As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim query As New StringBuilder
        query.Append("SELECT CODIGO, ID_MN, DESCRIPCION, MODULO, ")
        query.Append("(CASE WHEN (SELECT REPORTEID FROM profiles_rel  ")
        query.Append("WHERE REPORTEID = CODIGO AND USUARIOID = @USUARIO)  ")
        query.Append("IS NULL THEN 0 ELSE 1 END) AS ASIGNADO ")
        query.Append("FROM profiles_list WHERE MODULO = @MODULO ")

        Dim miComando As New SqlCommand(query.ToString, ActualizarConexion)
        miComando.Parameters.AddWithValue("@USUARIO", USUARIO)
        miComando.Parameters.AddWithValue("@MODULO", MODULO)
        ActualizarConexion.Open()

        Dim AdaptadorDeDatos As New SqlDataAdapter(miComando)
        Dim dt As New DataTable
        AdaptadorDeDatos.Fill(dt)
        ActualizarConexion.Close()
        Return dt
    End Function

    Public Function Carga_Permisos(ByVal USUARIO As Integer) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim query As New StringBuilder
        query.Append("SELECT dbo.profiles_list.ID_MN ")
        query.Append("FROM dbo.profiles_list INNER JOIN ")
        query.Append("dbo.profiles_rel ON dbo.profiles_list.CODIGO = dbo.profiles_rel.REPORTEID ")
        query.Append("WHERE (dbo.profiles_rel.USUARIOID = @USUARIO) ")

        Dim miComando As New SqlCommand(query.ToString, ActualizarConexion)
        miComando.Parameters.AddWithValue("@USUARIO", USUARIO)
        ActualizarConexion.Open()

        Dim AdaptadorDeDatos As New SqlDataAdapter(miComando)
        Dim dt As New DataTable
        AdaptadorDeDatos.Fill(dt)
        ActualizarConexion.Close()
        Return dt
    End Function

    Public Function actualizar_perfil(ByVal UsuarioId As Integer, ByVal mdl_reportes As Integer, ByVal mdl_logistica As Integer, _
                                      ByVal mdl_contabilidad As Integer, ByVal mdl_inventarios As Integer, ByVal mdl_almacen As Integer, _
                                      ByVal mdl_pdse As Integer, ByVal mdl_bonificaciones As Integer, ByVal mdl_configuracion As Integer, _
                                      ByVal mdl_monitoreo As Integer, ByVal mdl_adicional As Integer) As Boolean
        Dim Fallo As Boolean = False
        Try
            Using CadenaConexion As New SqlConnection(Conexion.CadenaSQL())
                Dim query As New StringBuilder
                query.Append("UPDATE [Usuarios].[dbo].[User] ")
                query.Append("SET [mdl_reportes] = @mdl_reportes ")
                query.Append("  ,[mdl_logistica] = @mdl_logistica ")
                query.Append("  ,[mdl_contabilidad] = @mdl_contabilidad ")
                query.Append("  ,[mdl_inventarios] = @mdl_inventarios ")
                query.Append("  ,[mdl_almacen] = @mdl_almacen ")
                query.Append("  ,[mdl_pdse] = @mdl_pdse ")
                query.Append("  ,[mdl_bonificaciones] = @mdl_bonificaciones ")
                query.Append("  ,[mdl_configuracion] = @mdl_configuracion, [mdl_monitoreo] = @mdl_monitoreo, [mdl_adicional] = @mdl_adicional ")
                query.Append("WHERE UsuarioId = @UsuarioId ")

                Dim AddDatos As New SqlCommand(query.ToString, CadenaConexion)
                AddDatos.Parameters.AddWithValue("@mdl_reportes", mdl_reportes)
                AddDatos.Parameters.AddWithValue("@mdl_logistica", mdl_logistica)
                AddDatos.Parameters.AddWithValue("@mdl_contabilidad", mdl_contabilidad)
                AddDatos.Parameters.AddWithValue("@mdl_inventarios", mdl_inventarios)
                AddDatos.Parameters.AddWithValue("@mdl_almacen", mdl_almacen)
                AddDatos.Parameters.AddWithValue("@mdl_pdse", mdl_pdse)
                AddDatos.Parameters.AddWithValue("@mdl_bonificaciones", mdl_bonificaciones)
                AddDatos.Parameters.AddWithValue("@mdl_configuracion", mdl_configuracion)
                AddDatos.Parameters.AddWithValue("@UsuarioId", UsuarioId)
                AddDatos.Parameters.AddWithValue("@mdl_monitoreo", mdl_monitoreo)
                AddDatos.Parameters.AddWithValue("@mdl_adicional", mdl_adicional)
                CadenaConexion.Open()
                AddDatos.ExecuteNonQuery()
                CadenaConexion.Close()
                Fallo = True
            End Using
            Return Fallo
        Catch SqlEX As SqlException
            Return Fallo
        End Try
    End Function

    Public Function asignar_perfil(ByVal USUARIOID As Integer, ByVal REPORTEID As Integer) As Boolean
        Dim Fallo As Boolean = False
        Try
            Using CadenaConexion As New SqlConnection(Conexion.CadenaSQL())
                Dim query As New StringBuilder
                query.Append("INSERT INTO [Usuarios].[dbo].[profiles_rel] ")
                query.Append("       ([REPORTEID],[USUARIOID]) ")
                query.Append(" VALUES (@REPORTEID,@USUARIOID)")

                Dim AddDatos As New SqlCommand(query.ToString, CadenaConexion)
                AddDatos.Parameters.AddWithValue("@USUARIOID", USUARIOID)
                AddDatos.Parameters.AddWithValue("@REPORTEID", REPORTEID)
                CadenaConexion.Open()
                AddDatos.ExecuteNonQuery()
                CadenaConexion.Close()
                Fallo = True
            End Using
            Return Fallo
        Catch SqlEX As SqlException
            Return Fallo
        End Try
    End Function

    Public Function clear_perfil(ByVal USUARIOID As Integer) As Boolean
        Dim Fallo As Boolean = False
        Try
            Using CadenaConexion As New SqlConnection(Conexion.CadenaSQL())
                Dim query As New StringBuilder
                query.Append("DELETE FROM [Usuarios].[dbo].[profiles_rel] ")
                query.Append("WHERE USUARIOID = @USUARIOID ")

                Dim AddDatos As New SqlCommand(query.ToString, CadenaConexion)
                AddDatos.Parameters.AddWithValue("@USUARIOID", USUARIOID)
                CadenaConexion.Open()
                AddDatos.ExecuteNonQuery()
                CadenaConexion.Close()
                Fallo = True
            End Using
            Return Fallo
        Catch SqlEX As SqlException
            Return Fallo
        End Try
    End Function

    Public Function Status(ByVal usu As String, ByVal Estado As Integer, ByVal Version As String, ByVal Ip As String) As Boolean
        Dim Fallo As Boolean = False
        Try
            Using CadenaConexion As New SqlConnection(Conexion.CadenaSQL())

                Const SQL As String = "UPDATE [Usuarios].[dbo].[User] SET [En_Linea] = @Estado, [Version] = @Version, [IP] = @IP WHERE UsuarioNick = @Nick"
                Dim AddDatos As New SqlCommand(SQL, CadenaConexion)
                AddDatos.Parameters.AddWithValue("@Nick", usu)
                AddDatos.Parameters.AddWithValue("@IP", Ip)
                If Estado = 0 Then
                    AddDatos.Parameters.AddWithValue("@Estado", DBNull.Value)
                Else
                    AddDatos.Parameters.AddWithValue("@Estado", Estado)
                End If

                AddDatos.Parameters.AddWithValue("@Version", Version)
                CadenaConexion.Open()
                AddDatos.ExecuteNonQuery()
                CadenaConexion.Close()
                Fallo = True
            End Using
            Return Fallo
        Catch SqlEX As SqlException
            Return Fallo
        End Try
    End Function

    Public Function En_Linea() As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim query As New StringBuilder
        query.Append("SELECT        UsuarioId AS ID, UsuarioNick AS Nick, UsuarioNombre AS Nombre, CASE WHEN ISNULL(En_Linea, 0) = 1 THEN 'Conectado' ELSE 'Desconectado' END AS 'Estado de Conexión', " & _
                     " Version AS 'Última Versión Utilizada', IP FROM [User] ")

        Dim miComando As New SqlCommand(query.ToString, ActualizarConexion)

        ActualizarConexion.Open()

        Dim AdaptadorDeDatos As New SqlDataAdapter(miComando)
        Dim dt As New DataTable
        AdaptadorDeDatos.Fill(dt)
        ActualizarConexion.Close()
        Return dt
    End Function

    Public Function Actualizando() As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim query As New StringBuilder
        query.Append("SELECT        Sistema, Status ")
        query.Append("FROM Sistemas_Status WITH (NOLOCK)  ")
        query.Append("WHERE        (Sistema = 'Reporteador') AND (Status = 1) ")

        Dim dt As New DataTable
        Try
            Dim miComando As New SqlCommand(query.ToString, ActualizarConexion)
            ActualizarConexion.Open()
            Dim AdaptadorDeDatos As New SqlDataAdapter(miComando)
            AdaptadorDeDatos.Fill(dt)
            ActualizarConexion.Close()
        Catch ex As Exception
            dt.Rows.Clear()
        End Try
        Return dt
    End Function

    
    Public Function ContadorReporte(ByVal reporte As String, ByVal usuario As String) As Boolean
        Dim Fallo As Boolean = False
        Try
            Using CadenaConexion As New SqlConnection(Conexion.CadenaSQL())

                Const SQL As String = "UPDATE [Usuarios].[dbo].[profiles_list] SET [Contador] = ISNULL(Contador,0) + 1, [ULT_FECHA] = @Fecha, [ULT_USUARIO] = @Usuario WHERE [ID_MN] = @Reporte"
                Dim AddDatos As New SqlCommand(SQL, CadenaConexion)

                AddDatos.Parameters.AddWithValue("@Reporte", reporte)
                AddDatos.Parameters.AddWithValue("@Fecha", Today.Date)
                AddDatos.Parameters.AddWithValue("@Usuario", usuario)

                CadenaConexion.Open()
                AddDatos.ExecuteNonQuery()
                CadenaConexion.Close()
                Fallo = True
            End Using
            Return Fallo
        Catch SqlEX As SqlException
            MsgBox(SqlEX.Message)
            Return Fallo
        End Try
    End Function

    Public Function Contador() As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim query As New StringBuilder
        query.Append("SELECT  DESCRIPCION AS Reporte, MODULO AS 'Módulo', ISNULL(CONTADOR, 0) AS Contador, ULT_FECHA AS 'Abierto por última vez', ULT_USUARIO AS 'Último usuario' " & _
        " FROM profiles_list ORDER BY 'Módulo', Reporte")

        Dim miComando As New SqlCommand(query.ToString, ActualizarConexion)

        ActualizarConexion.Open()

        Dim AdaptadorDeDatos As New SqlDataAdapter(miComando)
        Dim dt As New DataTable
        AdaptadorDeDatos.Fill(dt)
        ActualizarConexion.Close()
        Return dt
    End Function

    Public Function NumeroEntregador(ByVal USUARIO As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim query As New StringBuilder
        query.Append("SELECT Cod_Entregador ")
        query.Append("FROM dbo.[User] ")
        query.Append("WHERE (UsuarioNick = @USUARIO) ")

        Dim miComando As New SqlCommand(query.ToString, ActualizarConexion)
        miComando.Parameters.AddWithValue("@USUARIO", USUARIO)
        ActualizarConexion.Open()

        Dim AdaptadorDeDatos As New SqlDataAdapter(miComando)
        Dim dt As New DataTable
        AdaptadorDeDatos.Fill(dt)
        ActualizarConexion.Close()
        Return dt
    End Function

    Public Function SuspendeClientes(ByVal USUARIO As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim query As New StringBuilder
        query.Append("SELECT ISNULL(SuspendeClientes,0) ")
        query.Append("FROM dbo.[User] ")
        query.Append("WHERE (UsuarioNick = @USUARIO) ")

        Dim miComando As New SqlCommand(query.ToString, ActualizarConexion)
        miComando.Parameters.AddWithValue("@USUARIO", USUARIO)
        ActualizarConexion.Open()

        Dim AdaptadorDeDatos As New SqlDataAdapter(miComando)
        Dim dt As New DataTable
        AdaptadorDeDatos.Fill(dt)
        ActualizarConexion.Close()
        Return dt
    End Function

    Public Function VerificarPermisoConsignaciones(ByVal USUARIO As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim query As New StringBuilder
        query.Append("SELECT AceptaConsignaciones ")
        query.Append("FROM dbo.[User] ")
        query.Append("WHERE (UsuarioNick = @USUARIO) ")

        Dim miComando As New SqlCommand(query.ToString, ActualizarConexion)
        miComando.Parameters.AddWithValue("@USUARIO", USUARIO)
        ActualizarConexion.Open()

        Dim AdaptadorDeDatos As New SqlDataAdapter(miComando)
        Dim dt As New DataTable
        AdaptadorDeDatos.Fill(dt)
        ActualizarConexion.Close()
        Return dt
    End Function

    Public Function EnviaDevoluciones(ByVal USUARIO As String, ByVal Empresa As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim query As New StringBuilder

        If Empresa = "SAN RAFAEL" Then
            query.Append("SELECT ISNULL(DevolucionesSanRafael,0) ")
        ElseIf Empresa = "DIMOSA" Then
            query.Append("SELECT ISNULL(DevolucionesDimosa,0) ")
        ElseIf Empresa = "SR AGRO" Then
            query.Append("SELECT ISNULL(DevolucionesAgro,0) ")
        End If

        query.Append("FROM dbo.[User] ")
        query.Append("WHERE (UsuarioNick = @USUARIO) ")

        Dim miComando As New SqlCommand(query.ToString, ActualizarConexion)
        miComando.Parameters.AddWithValue("@USUARIO", USUARIO)
        ActualizarConexion.Open()

        Dim AdaptadorDeDatos As New SqlDataAdapter(miComando)
        Dim dt As New DataTable
        AdaptadorDeDatos.Fill(dt)
        ActualizarConexion.Close()
        Return dt
    End Function

End Class
