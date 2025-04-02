Imports System.Data.SqlClient

Public Class cls_admon_bienes_recursos
    Dim conexion As New cls_conexion_admon_bienes
    Public Function mostrar_datos(ByVal almacen As Integer, ByVal tipo As String) As DataTable
        Dim open_connection As New SqlConnection(conexion.CadenaSQL())
        Dim micomando As New SqlCommand("inventarios_admon_bienes_recursos", open_connection)
        micomando.CommandType = CommandType.StoredProcedure
        micomando.Parameters.Add(New SqlParameter("@ALMACEN", SqlDbType.Int).Value = almacen)
        micomando.Parameters.Add(New SqlParameter("@TIPO", SqlDbType.VarChar).Value = tipo)
        open_connection.Open()
        Dim data_adapter = New SqlDataAdapter(micomando)
        Dim table_retorna = New DataTable
        Try
            data_adapter.Fill(table_retorna)
            open_connection.Close()
        Catch ex As Exception
            MsgBox("Hay un problema con la conexión a los datos " & ex.Message, MsgBoxStyle.Critical)
        End Try

        Return table_retorna
    End Function
End Class