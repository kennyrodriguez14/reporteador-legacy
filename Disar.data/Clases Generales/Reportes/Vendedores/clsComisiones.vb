Imports System.Data.SqlClient

Public Class clsComisiones
    Dim Conexion As New clsconexion_consumo
    Dim Conexion2 As New cls_conexion_sip

    Public Function Comisiones(ByVal Inicio As Date, ByVal Fin As Date, ByVal Tipo As String, ByVal SUCURSAL As Integer) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("rptn_comisiones", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@FECHA_INI", SqlDbType.Date)).Value = Inicio
        miComando.Parameters.Add(New SqlParameter("@FECHA_FIN", SqlDbType.Date)).Value = Fin
        miComando.Parameters.Add(New SqlParameter("@TIPO", SqlDbType.VarChar)).Value = Tipo
        miComando.Parameters.Add(New SqlParameter("@SUCURSAL", SqlDbType.Int)).Value = SUCURSAL
        miComando.CommandTimeout = 2000
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

    Public Function Vendedores(ByVal Sucursal As String, ByVal Tabla As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())


        Dim miComando As New SqlCommand("SELECT 0 AS CVE_VEND, 'TODOS' AS NOMBRE UNION ALL SELECT CVE_VEND, NOMBRE FROM  VEND05", ActualizarConexion)
        If Tabla = "N" Then
            If Sucursal <> "TODOS" Then
                miComando = New SqlCommand("SELECT 0 AS CVE_VEND, 'TODOS' AS NOMBRE UNION ALL SELECT CVE_VEND, NOMBRE FROM  VEND05 WHERE CORREOE = @SUCURSAL", ActualizarConexion)
                miComando.Parameters.AddWithValue("@Sucursal", Sucursal)
            End If
        Else
            If Sucursal = "TODOS" Then
                miComando = New SqlCommand("SELECT CVE_VEND, NOMBRE FROM  VEND05 ", ActualizarConexion)
            Else
                miComando = New SqlCommand("SELECT CVE_VEND, NOMBRE FROM  VEND05 WHERE CORREOE = @SUCURSAL", ActualizarConexion)
                miComando.Parameters.AddWithValue("@Sucursal", Sucursal)
            End If
        End If

        miComando.CommandTimeout = 2000
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

    Public Function HorasTrabajadas(ByVal FECHA As Date, ByVal VENDEDOR As String, ByVal Tipo As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim miComando As New SqlCommand("HorasTrabajadas", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.AddWithValue("@FECHA1", FECHA)
        miComando.Parameters.AddWithValue("@VENDEDOR", VENDEDOR)
        miComando.Parameters.AddWithValue("@TIPO", Tipo)

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
