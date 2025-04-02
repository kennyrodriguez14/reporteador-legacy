Imports System.Data.SqlClient

Public Class clsAntSaldos
    Dim Conexion As New clsconexion_coi_consumo
    Public Function Saldos(ByVal F1 As Date, ByVal SUCURSAL As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("Antiguedad_Saldos", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@SUCURSAL", SqlDbType.VarChar)).Value = SUCURSAL
        miComando.Parameters.Add(New SqlParameter("@FECHA_CORRIENTE", SqlDbType.DateTime)).Value = F1
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
