Imports System.Data.SqlClient
Public Class _clsVendedoresTegucigalpa
    Dim Conexion As New clsconexion_consumo  '_clsTeg
    Public Function Datos() As DataView
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim AdaptadorDeDatos As New SqlDataAdapter("SELECT CVE_VEND AS [Clave del Vendedor], NOMBRE AS [Nombre del Vendedor], CLASIFIC AS Clasificacion FROM dbo.VEND05 WHERE (CLASIFIC <> 'NE')", ActualizarConexion)
        ActualizarConexion.Open()
        Dim ds As New DataSet
        Dim dv As New DataView
        Try
            AdaptadorDeDatos.Fill(ds, "VEND01")
            If ds.Tables("VEND01").Rows.Count > 0 Then
                dv = New DataView(ds.Tables("VEND01"))
            End If
        Catch ex As SqlException
            MsgBox("Hay problemas de Conexión: " + ex.Message, MsgBoxStyle.Critical)
        End Try
        ActualizarConexion.Close()
        Return dv
    End Function
End Class