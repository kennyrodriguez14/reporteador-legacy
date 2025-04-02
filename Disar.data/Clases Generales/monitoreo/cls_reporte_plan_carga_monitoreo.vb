Imports System.Text
Imports Disar.data
Imports System.Data.SqlClient

Public Class cls_reporte_plan_carga_monitoreo
    Dim conexion As New clsconexion_consumo

    Public Function control_monitoreo(ByVal fecha_ini As Date, ByVal fecha_fin As Date) As DataTable
        Dim conexion_sql As New SqlConnection(conexion.CadenaSQL)

        conexion_sql.Open()
        Dim micomando As New SqlCommand("rptn_control_monitoreo", conexion_sql)
        micomando.CommandTimeout = 2000
        micomando.CommandType = CommandType.StoredProcedure
        micomando.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.Date)).Value = fecha_ini
        micomando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.Date)).Value = fecha_fin
        Dim dt As New DataTable
        Dim adaptador As New SqlDataAdapter(micomando)
        adaptador.Fill(dt)
        conexion_sql.Close()

        Return dt
    End Function

End Class