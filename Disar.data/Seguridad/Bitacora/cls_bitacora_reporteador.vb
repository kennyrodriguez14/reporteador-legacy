Imports System.Data.SqlClient
Imports System.Text

Public Class cls_bitacora_reporteador
    Dim Conexion As New clsConexion
    
    Public Function RegistraBitacora(ByVal FECHA As DateTime, ByVal USUARIO As String, ByVal OBSERVACION As String, ByVal MODULO As String, _
                                        ByVal ACCION As String) As String
        Try
            Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
            Dim query As New StringBuilder
            ActualizarConexion.Open()

            query.Append("INSERT INTO [Usuarios].[dbo].[tb_ctrl_int] ")
            query.Append(" ([FECHA],[USUARIO],[OBSERVACION],[MODULO],[ACCION]) ")
            query.Append(" VALUES (@FECHA,@USUARIO,@OBSERVACION,@MODULO,@ACCION) ")

            Dim miComando As New SqlCommand(query.ToString, ActualizarConexion)
            miComando.Parameters.AddWithValue("@FECHA", FECHA)
            miComando.Parameters.AddWithValue("@USUARIO", USUARIO)
            miComando.Parameters.AddWithValue("@OBSERVACION", OBSERVACION)
            miComando.Parameters.AddWithValue("@MODULO", MODULO)
            miComando.Parameters.AddWithValue("@ACCION", ACCION)
            miComando.ExecuteNonQuery()
            ActualizarConexion.Close()
            Return "correcto"
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function listar_bitacora(ByVal FECHA_INI As Date, ByVal FECHA_FIN As Date) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim query As New StringBuilder
        ActualizarConexion.Open()

        query.Append("SELECT BITAID, FECHA, USUARIO, OBSERVACION, MODULO, ACCION ")
        query.Append("FROM   tb_ctrl_int ")
        query.Append("WHERE  (CONVERT(DATE,FECHA) >= @FECHA_INI) AND (CONVERT(DATE,FECHA) <= @FECHA_FIN) ")

        Dim miComando As New SqlCommand(query.ToString, ActualizarConexion)
        miComando.Parameters.AddWithValue("@FECHA_INI", FECHA_INI)
        miComando.Parameters.AddWithValue("@FECHA_FIN", FECHA_FIN)
        miComando.CommandTimeout = 2000

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
