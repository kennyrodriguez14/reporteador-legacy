Imports System.Data.SqlClient
Public Class clsIncumplimientos
    Dim Conexion As New clsconexion_consumo
    Dim Conexion2 As New clsConexion

    Public Function CargarProductos(ByVal busqueda As String) As DataView
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        ActualizarConexion.Open()
        Dim AdaptadorDeDatos As New SqlDataAdapter("SELECT CVE_ART AS CODIGO, DESCR AS PRODUCTO FROM dbo.INVE01 WHERE (UPPER(DESCR) LIKE '%" & busqueda & "%')", ActualizarConexion)
        Dim ds As New DataSet
        Dim dv As New DataView
        Try
            AdaptadorDeDatos.Fill(ds, "Inve")
            If ds.Tables("Inve").Rows.Count > 0 Then
                dv = New DataView(ds.Tables("Inve"))
            End If
        Catch ex As SqlException
            MsgBox("Hay problemas de Conexión: " + ex.Message, MsgBoxStyle.Critical)

        End Try
        ActualizarConexion.Close()
        Return dv
    End Function

    Public Function InsertarProducto(ByVal ProductoId As String, ByVal Cantidad As Integer, ByVal Cliente As String, ByVal Fecha As Date) As Boolean
        Dim Fallo As Boolean = False
        Try

            Using CadenaConexion As New SqlConnection(Conexion2.CadenaSQL())
                CadenaConexion.Open()
                Const SQL As String = "INSERT INTO [Usuarios].[dbo].[Incumplimientos] ([ProductoId],[Cantidad],[ClienteId],[Fecha]) " & _
                                      "VALUES (@ProductoId,@Cantidad,@Cliente,@Fecha)"
                Dim AddDatos As New SqlCommand(SQL, CadenaConexion)
                AddDatos.Parameters.AddWithValue("@ProductoId", ProductoId)
                AddDatos.Parameters.AddWithValue("@Cantidad", Cantidad)
                AddDatos.Parameters.AddWithValue("@Cliente", Cliente)
                AddDatos.Parameters.AddWithValue("@Fecha", Fecha)
                CadenaConexion.Open()
                AddDatos.ExecuteNonQuery()
                Fallo = True
                CadenaConexion.Close()
            End Using
            Return Fallo
        Catch SqlEX As SqlException
            MsgBox(SqlEX.Message)
            Return Fallo
        End Try
    End Function

    Public Function Reporte(ByVal Inicio As Date, ByVal Fin As Date, ByVal TIPO As String, ByVal SUCURSAL As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim miComando As New SqlCommand("dsr_incumplimientos", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.Date)).Value = Inicio
        miComando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.Date)).Value = Fin
        miComando.Parameters.Add(New SqlParameter("@TIPO", SqlDbType.VarChar)).Value = TIPO
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

    Public Function Consolidado(ByVal Inicio As Date, ByVal Fin As Date, ByVal TIPO As String, ByVal SUCURSAL As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim miComando As New SqlCommand("dsr_incumplimientos_consolidado", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.Date)).Value = Inicio
        miComando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.Date)).Value = Fin
        miComando.Parameters.Add(New SqlParameter("@TIPO", SqlDbType.VarChar)).Value = TIPO
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
End Class
