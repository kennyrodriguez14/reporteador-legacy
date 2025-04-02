
Imports Disar.data
Imports System.Data.SqlClient
Imports System.Text

Public Class cls_libro_ventas
    Dim conexion As New clsconexion_consumo

    Public Function listar_ventas(ByVal EMPRESA As String, ByVal TIPO As String, ByVal FECHA_INI As Date, ByVal FECHA_FIN As Date, ByVal ALMACEN As Integer) As DataTable
        Dim miconexion As New SqlConnection(conexion.CadenaSQL)
        miconexion.Open()
        Dim micomando As New SqlCommand("rptn_libro_diario_ventas", miconexion)
        micomando.CommandType = CommandType.StoredProcedure
        micomando.Parameters.Add(New SqlParameter("@EMPRESA", SqlDbType.VarChar)).Value = EMPRESA
        micomando.Parameters.Add(New SqlParameter("@TIPO", SqlDbType.VarChar)).Value = TIPO
        micomando.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.DateTime)).Value = FECHA_INI
        micomando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.DateTime)).Value = FECHA_FIN
        micomando.Parameters.Add(New SqlParameter("@ALMACEN", SqlDbType.Int)).Value = ALMACEN

        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        miconexion.Close()
        Return dt
    End Function

    Public Function Kardex(ByVal SaldoInicio As Date, ByVal SaldoFin As Date, ByVal Empresa As String) As DataTable
        Dim miconexion As New SqlConnection(conexion.CadenaSQL)
        miconexion.Open()
        Dim micomando As New SqlCommand("rptn_kardex", miconexion)
        micomando.CommandType = CommandType.StoredProcedure
        micomando.CommandTimeout = 2000
        Dim FechaMedia As Date = DateAdd(DateInterval.Day, 1, SaldoInicio)
        micomando.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.DateTime)).Value = SaldoInicio
        micomando.Parameters.Add(New SqlParameter("@FECHA_MEDIA", SqlDbType.DateTime)).Value = FechaMedia
        micomando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.DateTime)).Value = SaldoFin
        micomando.Parameters.Add(New SqlParameter("@EMPRESA", SqlDbType.VarChar)).Value = Empresa

        Dim adaptador As New SqlDataAdapter(micomando)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        miconexion.Close()
        Return dt
    End Function
End Class
