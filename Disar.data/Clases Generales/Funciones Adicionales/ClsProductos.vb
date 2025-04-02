Imports Disar.data
Imports System.Data.SqlClient
Imports System.Text

Public Class ClsProductos

    Dim Conexion As New clsConexion
    Dim ConexionSAE As New clsconexion_consumo

 
    Public Function TodosProductos() As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionSAE.CadenaSQL())

        Dim miComando As New SqlCommand("     SELECT        dbo.INVE05.CVE_ART AS CLAVE, dbo.INVE05.DESCR AS DESCRIPCION, dbo.INVE05.LIN_PROD AS LINEA, dbo.CLIN05.DESC_LIN AS PROVEEDOR " & _
" FROM            dbo.INVE05 INNER JOIN " & _
"                         dbo.CLIN05 ON dbo.INVE05.LIN_PROD = dbo.CLIN05.CVE_LIN " & _
" WHERE        (dbo.INVE05.LIN_PROD <> 'SRV1') AND (dbo.INVE05.LIN_PROD <> 'Z70')", ActualizarConexion)

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

    Public Function FiltraProductos(ByVal Busca As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionSAE.CadenaSQL())

        Dim miComando As New SqlCommand("     SELECT        dbo.INVE05.CVE_ART AS CLAVE, dbo.INVE05.DESCR AS DESCRIPCION, dbo.INVE05.LIN_PROD AS LINEA, dbo.CLIN05.DESC_LIN AS PROVEEDOR " & _
" FROM            dbo.INVE05 INNER JOIN " & _
"                         dbo.CLIN05 ON dbo.INVE05.LIN_PROD = dbo.CLIN05.CVE_LIN " & _
" WHERE        (dbo.INVE05.LIN_PROD <> 'SRV1') AND (dbo.INVE05.LIN_PROD <> 'Z70') AND (CVE_ART LIKE '%" & Busca & "%') OR (dbo.INVE05.LIN_PROD <> 'SRV1') AND (dbo.INVE05.LIN_PROD <> 'Z70') AND (dbo.INVE05.DESCR LIKE '%" & Busca & "%')", ActualizarConexion)

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

    Public Function NuevoRegistro(ByVal CODIGO_PROD As String, ByVal PROD As String, ByVal CODIGO_VEND As String, ByVal PESO As Decimal, ByVal TIPO As String, ByVal Fecha As Date)

        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand

            miComando = New SqlCommand("INSERT INTO Matinal_MetaXProducto" & _
                                         "( CODIGO_PROD, PROD, CODIGO_VEND, PESO, TIPO, ACTIVO, FACT_CONV, FechaDesde) " & _
                                         " VALUES(@CODIGO_PROD, @PROD, @CODIGO_VEND, @PESO, @TIPO, @ACTIVO, @FACT_CONV, @FechaDesde)", ActualizarConexion)

            miComando.Parameters.AddWithValue("@CODIGO_PROD", CODIGO_PROD)
            miComando.Parameters.AddWithValue("@PROD", PROD)
            miComando.Parameters.AddWithValue("@CODIGO_VEND", CODIGO_VEND)
            miComando.Parameters.AddWithValue("@PESO", PESO)
            miComando.Parameters.AddWithValue("@TIPO", TIPO)
            miComando.Parameters.AddWithValue("@ACTIVO", "S")
            miComando.Parameters.AddWithValue("@FACT_CONV", 1)
            miComando.Parameters.AddWithValue("@FechaDesde", Fecha.date)

            miComando.Transaction = transaccion_sql
            miComando.ExecuteNonQuery()

            transaccion_sql.Commit()
            ActualizarConexion.Close()
            Return "s"
        Catch ex As Exception

            transaccion_sql.Rollback()
            ActualizarConexion.Close()
            Dim tamaño As Integer = Convert.ToString(ex.StackTrace).Length
            Dim posicion As Integer = InStrRev(Convert.ToString(ex.StackTrace), "línea") - 1
            Dim inicial As Integer = tamaño - posicion
            Dim linea_error As String = Convert.ToString(ex.StackTrace).Substring(tamaño - inicial, inicial)
            Return "Error: " & ex.Message & " " & linea_error
            MsgBox("Error: " & ex.Message & " " & linea_error)
        End Try

    End Function

    Public Function CargaValidos() As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT        dbo.Matinal_MetaXProducto.ID, dbo.Matinal_MetaXProducto.CODIGO_PROD AS 'CLAVE', dbo.Matinal_MetaXProducto.PROD AS 'PRODUCTO', dbo.Matinal_MetaXProducto.CODIGO_VEND AS 'VENDEDOR', " & _
                         " SAE60Empre05.dbo.VEND05.NOMBRE, dbo.Matinal_MetaXProducto.PESO AS 'META', dbo.Matinal_MetaXProducto.TIPO, FechaDesde as 'CONTAR DESDE' " & _
                         " FROM            dbo.Matinal_MetaXProducto INNER JOIN " & _
                         " SAE60Empre05.dbo.VEND05 ON dbo.Matinal_MetaXProducto.CODIGO_VEND = SAE60Empre05.dbo.VEND05.CVE_VEND COLLATE MODERN_SPANISH_CI_AS " & _
                         " WHERE        (dbo.Matinal_MetaXProducto.ACTIVO = 'S') ", ActualizarConexion)

        miComando.CommandTimeout = 2000

        ActualizarConexion.Open()
        Dim AdaptadorDeDatos As New SqlDataAdapter(miComando)
        Dim dt As New DataTable
        Try
            AdaptadorDeDatos.Fill(dt)
            ActualizarConexion.Close()
        Catch ex As SqlException
            'MsgBox("Hay un problema con la conexión a los datos " & ex.Message, MsgBoxStyle.Critical)
            ActualizarConexion.Close()
        End Try
        Return dt
    End Function

    Public Function CargaInValidos() As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT ID, CODIGO_PROD as 'CLAVE', PROD as PRODUCTO, CODIGO_VEND AS VENDEDOR, PESO AS META, TIPO WHERE Activo <> 'S' ", ActualizarConexion)

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

    Public Function ModificaEstado(ByVal ID As Integer)

        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand

            miComando = New SqlCommand(" UPDATE Matinal_MetaXProducto " & _
                                         " SET ACTIVO = 'N' " & _
                                         " WHERE ID = @ID ", ActualizarConexion)

            miComando.Parameters.AddWithValue("@ID", ID)

            miComando.Transaction = transaccion_sql
            miComando.ExecuteNonQuery()


            transaccion_sql.Commit()
            ActualizarConexion.Close()
            Return "s"
            'MsgBox("HOLA")
        Catch ex As Exception
            transaccion_sql.Rollback()
            ActualizarConexion.Close()
            Dim tamaño As Integer = Convert.ToString(ex.StackTrace).Length
            Dim posicion As Integer = InStrRev(Convert.ToString(ex.StackTrace), "línea") - 1
            Dim inicial As Integer = tamaño - posicion
            Dim linea_error As String = Convert.ToString(ex.StackTrace).Substring(tamaño - inicial, inicial)
            Return "Error: " & ex.Message & " " & linea_error
        End Try

    End Function

    Public Function CargaValidosPorVendedor(ByVal Vendedor As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT        dbo.Matinal_MetaXProducto.ID, dbo.Matinal_MetaXProducto.CODIGO_PROD AS 'CLAVE', dbo.Matinal_MetaXProducto.PROD AS 'PRODUCTO', dbo.Matinal_MetaXProducto.CODIGO_VEND AS 'VENDEDOR', " & _
                         " SAE60Empre05.dbo.VEND05.NOMBRE, dbo.Matinal_MetaXProducto.PESO AS 'META', dbo.Matinal_MetaXProducto.TIPO, FechaDesde as 'CONTAR DESDE'  " & _
                         " FROM            dbo.Matinal_MetaXProducto INNER JOIN " & _
                         " SAE60Empre05.dbo.VEND05 ON dbo.Matinal_MetaXProducto.CODIGO_VEND = SAE60Empre05.dbo.VEND05.CVE_VEND COLLATE MODERN_SPANISH_CI_AS " & _
                         " WHERE        (dbo.Matinal_MetaXProducto.ACTIVO = 'S') AND (CODIGO_VEND LIKE '%" & Vendedor & "%') OR (UPPER(SAE60Empre05.dbo.VEND05.NOMBRE) LIKE '%" & Vendedor.ToUpper & "%') AND (dbo.Matinal_MetaXProducto.ACTIVO = 'S') ", ActualizarConexion)

        miComando.CommandTimeout = 2000

        ActualizarConexion.Open()
        Dim AdaptadorDeDatos As New SqlDataAdapter(miComando)
        Dim dt As New DataTable
        Try
            AdaptadorDeDatos.Fill(dt)
            ActualizarConexion.Close()
        Catch ex As SqlException
            'MsgBox("Hay un problema con la conexión a los datos " & ex.Message, MsgBoxStyle.Critical)
            ActualizarConexion.Close()
        End Try
        Return dt
    End Function

End Class
