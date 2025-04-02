Imports System.Data.SqlClient
Public Class clsPresupuestoXdepto
    Dim Conexion As New clsConexion
    Public Function Listar() As DataView
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim AdaptadorDeDatos As New SqlDataAdapter("Select [DeptoId] AS Codigo,[DeptoNombre] AS Departamento, " & _
                "[DeptoPresupuesto] AS Presupuesto,[Cuenta] FROM [Usuarios].[dbo].[PresupuestosXdepto]", ActualizarConexion)
        Dim ds As New DataSet
        Dim dv As New DataView
        ActualizarConexion.Open()
        Try
            AdaptadorDeDatos.Fill(ds, "PresupuestosXdepto")
            If ds.Tables("PresupuestosXdepto").Rows.Count > 0 Then
                dv = New DataView(ds.Tables("PresupuestosXdepto"))
            End If
        Catch ex As SqlException
            MsgBox("Hay problemas de Conexión: " + ex.Message, MsgBoxStyle.Critical)
        End Try
        ActualizarConexion.Close()
        Return dv
    End Function

    Public Function Nuevo(ByVal Nombre As String, ByVal Presupuesto As Double, ByVal Cuenta As String) As Boolean
        Dim Fallo As Boolean = False
        Try
            Using CadenaConexion As New SqlConnection(Conexion.CadenaSQL())
                Const SQL As String = " INSERT INTO [Usuarios].[dbo].[PresupuestosXdepto] ([DeptoNombre],[DeptoPresupuesto],[Cuenta]) " & _
                "VALUES(@DeptoNombre,@DeptoPresupuesto,@Cuenta)"
                Dim AddDatos As New SqlCommand(SQL, CadenaConexion)
                AddDatos.Parameters.AddWithValue("@DeptoNombre", Nombre)
                AddDatos.Parameters.AddWithValue("@DeptoPresupuesto", Presupuesto)
                AddDatos.Parameters.AddWithValue("@Cuenta", Cuenta)
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

    Public Function Modificar(ByVal Id As Integer, ByVal Nombre As String, ByVal Presupuesto As Double, ByVal Cuenta As String) As Boolean
        Dim Fallo As Boolean = False
        Try
            Using CadenaConexion As New SqlConnection(Conexion.CadenaSQL())

                Const SQL As String = " UPDATE [Usuarios].[dbo].[PresupuestosXdepto] SET [DeptoNombre] = @DeptoNombre,[DeptoPresupuesto] = @DeptoPresupuesto,[Cuenta] = @Cuenta " & _
                                      " WHERE DeptoId = @DeptoId"
                Dim AddDatos As New SqlCommand(SQL, CadenaConexion)
                AddDatos.Parameters.AddWithValue("@DeptoId", Id)
                AddDatos.Parameters.AddWithValue("@DeptoNombre", Nombre)
                AddDatos.Parameters.AddWithValue("@DeptoPresupuesto", Presupuesto)
                AddDatos.Parameters.AddWithValue("@Cuenta", Cuenta)
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

    Public Function Eliminar(ByVal Id As Integer)
        Dim Fallo As Boolean = False
        Try
            Using CadenaConexion As New SqlConnection(Conexion.CadenaSQL())

                Const SQL As String = " DELETE FROM [Usuarios].[dbo].[PresupuestosXdepto] " & _
                                      " WHERE DeptoId = @DeptoId"
                Dim AddDatos As New SqlCommand(SQL, CadenaConexion)
                AddDatos.Parameters.AddWithValue("@DeptoId", Id)
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

    Public Function EjecutarPresupuestos(ByVal finicio As Date, ByVal ffin As Date, ByVal cveini As String, ByVal cvefin As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("Presupuestos_Deptos", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.Date)).Value = finicio
        miComando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.Date)).Value = ffin
        miComando.Parameters.Add(New SqlParameter("@CVE_INI", SqlDbType.VarChar)).Value = cveini
        miComando.Parameters.Add(New SqlParameter("@CVE_FIN", SqlDbType.VarChar)).Value = cvefin
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

    Public Function DetallarPresupuesto(ByVal finicio As Date, ByVal ffin As Date, ByVal cveini As String, ByVal cvefin As String, ByVal depto As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("Detalle_PresXDepto", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.Date)).Value = finicio
        miComando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.Date)).Value = ffin
        miComando.Parameters.Add(New SqlParameter("@CVE_INI", SqlDbType.VarChar)).Value = cveini
        miComando.Parameters.Add(New SqlParameter("@CVE_FIN", SqlDbType.VarChar)).Value = cvefin
        miComando.Parameters.Add(New SqlParameter("@DEPTO", SqlDbType.VarChar)).Value = depto
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

