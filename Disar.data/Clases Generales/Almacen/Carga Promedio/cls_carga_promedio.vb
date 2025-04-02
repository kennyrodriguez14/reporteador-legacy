Imports System.Data.SqlClient
Public Class cls_carga_promedio
    Dim Conexion As New clsConexion

    Public Function Insertar_Camion(ByVal dia As Date, ByVal turno As String, ByVal Peso As Double, ByVal cantidad As Integer, ByVal sucursal As Integer)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("INSERT INTO [Usuarios].[dbo].[Carga_Camiones] " & _
                                        "([DIA],[TURNO],[PESO],[CANTIDAD_CARROS],sucursal) " & _
                                        "VALUES (@DIA,@TURNO,@PESO,@CANTIDAD_CARROS,@sucursal) ", ActualizarConexion)

        miComando.Parameters.AddWithValue("@DIA", dia)
        miComando.Parameters.AddWithValue("@TURNO", turno)
        miComando.Parameters.AddWithValue("@PESO", Peso)
        miComando.Parameters.AddWithValue("@CANTIDAD_CARROS", cantidad)
        miComando.Parameters.AddWithValue("@sucursal", sucursal)
        ActualizarConexion.Open()

        miComando.ExecuteNonQuery()
        ActualizarConexion.Close()
        Return True
    End Function

    Public Function select_tipo_reporte()
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT Id, Tipo_Reporte FROM Tipo_Reporte ", ActualizarConexion)
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

    Public Function select_camion()
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT VehiculoId, VehiculoDescripcion FROM Vehiculos_Entregadores ", ActualizarConexion)
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

    Public Function SelectCarga(ByVal dia As Date, ByVal dia2 As Date, ByVal sucursal As Integer)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT DIA AS Dia, TURNO AS Turno, SUM(PESO) AS Peso, SUM(CANTIDAD_CARROS) AS Carros " & _
                                        "FROM dbo.Carga_Camiones " & _
                                        "WHERE (DIA >= @DIA) AND (DIA <= @DIA2) and sucursal = @sucursal " & _
                                        "GROUP BY DIA, TURNO ", ActualizarConexion)
        miComando.Parameters.AddWithValue("@DIA", dia)
        miComando.Parameters.AddWithValue("@DIA2", dia2)
        miComando.Parameters.AddWithValue("@sucursal", sucursal)
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

    Public Function Reporte(ByVal Ini As Date, ByVal Fin As Date, ByVal Dias As Integer, ByVal sucursal As Integer) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("promedio_carga_camiones", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.DateTime)).Value = Ini
        miComando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.DateTime)).Value = Fin
        miComando.Parameters.Add(New SqlParameter("@DIAS", SqlDbType.Int)).Value = Dias
        miComando.Parameters.Add(New SqlParameter("@sucursal", SqlDbType.Int)).Value = sucursal
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