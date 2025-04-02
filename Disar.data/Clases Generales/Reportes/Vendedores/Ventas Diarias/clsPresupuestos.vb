Imports System.Data.SqlClient

Public Class clsPresupuestos

    Dim Conexion As New clsConexion

    Public Function ListarPresupuestos(ByVal SUCURSAL As String) As DataTable
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

    Public Function Nuevo(ByVal id As String, ByVal nom As String, ByVal pre As String, ByVal sucu As String) As Boolean
        Dim Fallo As Boolean = False
        Try

            Using CadenaConexion As New SqlConnection(Conexion.CadenaSQL())
                Const SQL As String = "INSERT INTO [Usuarios].[dbo].[Presupuestos] ([VendedorId] ,[VendedorNombre], [VendedorPresupuesto],[VendedorSucursal]) " & _
                                      "VALUES (@id,@nom,@pre,@sucu)"

                Dim AddDatos As New SqlCommand(SQL, CadenaConexion)
                AddDatos.Parameters.AddWithValue("@id", id)
                AddDatos.Parameters.AddWithValue("@nom", nom)
                AddDatos.Parameters.AddWithValue("@pre", pre)
                AddDatos.Parameters.AddWithValue("@sucu", sucu)
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

    Public Function Modificar(ByVal id As String, ByVal nom As String, ByVal pre As String, ByVal sucu As String) As Boolean
        Dim Fallo As Boolean = False
        Try
            Using CadenaConexion As New SqlConnection(Conexion.CadenaSQL())
                Const SQL As String = "UPDATE [Usuarios].[dbo].[Presupuestos] SET [VendedorId] = @id,[VendedorNombre] = @nom,[VendedorPresupuesto] = @pre,[VendedorSucursal] = @sucu" & _
                                      " WHERE (VendedorId = @id)"

                Dim AddDatos As New SqlCommand(SQL, CadenaConexion)
                AddDatos.Parameters.AddWithValue("@id", id)
                AddDatos.Parameters.AddWithValue("@nom", nom)
                AddDatos.Parameters.AddWithValue("@pre", pre)
                AddDatos.Parameters.AddWithValue("@sucu", sucu)
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

    Public Function ListarFeriadosMes(ByVal Mes As Integer, ByVal Año As Integer) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT FERIADO_FECHA FROM Feriados WHERE (MONTH(FERIADO_FECHA) = @MES) AND (YEAR(FERIADO_FECHA) = @AÑO)", ActualizarConexion)

        miComando.Parameters.AddWithValue("@MES", Mes)
        miComando.Parameters.AddWithValue("@AÑO", Año)

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
