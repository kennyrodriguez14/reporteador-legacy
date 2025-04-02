Imports System.Data.SqlClient

Public Class clsRendimientos
    Dim Conexion As New clsFlotaSRC

    Public Function Redimientos(ByVal Inicio As DateTime, ByVal Fin As DateTime, ByVal Sucursal As String, ByVal Concepto As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("rptn_rendimientos_flota", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@Fecha_Ini", SqlDbType.DateTime)).Value = Inicio
        miComando.Parameters.Add(New SqlParameter("@Fecha_Fin", SqlDbType.DateTime)).Value = Fin
        miComando.Parameters.Add(New SqlParameter("@Sucursal", SqlDbType.VarChar)).Value = Sucursal
        miComando.Parameters.Add(New SqlParameter("@Concepto", SqlDbType.VarChar)).Value = Concepto
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
