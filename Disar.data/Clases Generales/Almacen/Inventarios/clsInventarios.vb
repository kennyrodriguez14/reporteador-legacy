Imports System.Data.SqlClient
Imports System.Text

Public Class clsInventarios
    Dim Conexion As New clsConexion
    Dim Conexion2 As New clsconexion_consumo
    Dim Conexion3 As New cls_conexion_descuentos_tacticos

    Public Function GenerarDatos(ByVal codigo As String, ByVal Nombre As String, ByVal Sucursal As String, ByVal Tipo As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim miComando As New SqlCommand("Consultas_Al_Inventario", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@CODIGO", SqlDbType.VarChar)).Value = codigo
        miComando.Parameters.Add(New SqlParameter("@NOMBRE", SqlDbType.VarChar)).Value = Nombre
        miComando.Parameters.Add(New SqlParameter("@SUCURSAL", SqlDbType.VarChar)).Value = Sucursal
        miComando.Parameters.Add(New SqlParameter("@TIPO", SqlDbType.VarChar)).Value = Tipo
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

    Public Function Dias_Inve(ByVal PROVEEDOR As Integer, ByVal FECHA As Date, ByVal SUCURSAL As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim miComando As New SqlCommand("rptn_dias_inventario", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@PROVEEDOR", SqlDbType.Int)).Value = PROVEEDOR
        miComando.Parameters.Add(New SqlParameter("@FECHA", SqlDbType.Date)).Value = FECHA
        miComando.Parameters.Add(New SqlParameter("@SUCURSAL", SqlDbType.VarChar)).Value = SUCURSAL
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

    Public Function ListaProveedores(ByVal PROVEEDOR As Integer, ByVal FECHA As Date, ByVal SUCURSAL As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim miComando As New SqlCommand("rptn_dias_inventario", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@PROVEEDOR", SqlDbType.Int)).Value = PROVEEDOR
        miComando.Parameters.Add(New SqlParameter("@FECHA", SqlDbType.Date)).Value = FECHA
        miComando.Parameters.Add(New SqlParameter("@SUCURSAL", SqlDbType.VarChar)).Value = SUCURSAL
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

    Public Function Espacio_en_bodega(ByVal SUCURSAL As String, ByVal FECHA As Date) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim miComando As New SqlCommand("rptn_capacidad_bodega", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@ALMACEN", SqlDbType.VarChar)).Value = SUCURSAL
        miComando.Parameters.Add(New SqlParameter("@FECHA", SqlDbType.Date)).Value = FECHA
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

    Public Function utilidad_por_producto(ByVal Empresa) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion3.CadenaSQL())
        Dim miComando As New SqlCommand("margenes_utilidad_producto", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure

        miComando.Parameters.Add(New SqlParameter("@Empresa", SqlDbType.VarChar)).Value = Empresa

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

    'MARGENES AUTORIZADOS POR PRODUCTO
    Public Function listar_productos() As DataTable
        Dim conexion_sql As New SqlConnection(Conexion2.CadenaSQL)

        Dim query As New StringBuilder
        query.Append("SELECT I.CVE_ART AS 'Codigo', I.DESCR AS 'Producto', ")
        query.Append("ISNULL(CONVERT(VARCHAR,P.MARGEN_AUT),'No asignado') AS 'Margen Autorizado' ")
        query.Append("FROM SAE60Empre05.dbo.INVE05 I FULL OUTER JOIN nd_margenes_autorizados P ")
        query.Append("ON P.CVE_ART = I.CVE_ART COLLATE MODERN_SPANISH_CI_AS ")
        query.Append("WHERE I.STATUS <> 'B' AND I.DESCR NOT LIKE 'ZDEV' ")

        conexion_sql.Open()
        Dim micomando As New SqlCommand(query.ToString, conexion_sql)

        Dim dt As New DataTable
        Dim adaptador As New SqlDataAdapter(micomando)
        adaptador.Fill(dt)

        conexion_sql.Close()
        Return dt
    End Function

    Public Function filtros(ByVal BUSCAR As String, ByVal BUSCAR_PROVEEDOR As String) As DataTable
        Dim dt As New DataTable
        Dim sql_con As New SqlConnection(Conexion3.CadenaSQL)
        sql_con.Open()
        Dim query As New StringBuilder

        query.Append("SELECT I.CVE_ART AS 'Codigo', I.DESCR AS 'Producto', ")
        query.Append("ISNULL(CONVERT(VARCHAR,P.MARGEN_AUT),'No asignado') AS 'Margen Autorizado' ")
        query.Append("FROM SAE60Empre05.dbo.INVE05 I FULL OUTER JOIN nd_margenes_autorizados P ")
        query.Append("ON P.CVE_ART = I.CVE_ART COLLATE MODERN_SPANISH_CI_AS ")
        query.Append("FULL OUTER JOIN SAE60Empre05.dbo.PRVPROD05 PP ON PP.CVE_ART = I.CVE_ART ")
        query.Append("WHERE I.STATUS <> 'B' AND I.DESCR NOT LIKE 'ZDEV' ")
        query.Append("AND (I.DESCR LIKE '%'+ UPPER(@BUSCAR) + '%' OR I.CVE_ART LIKE '%'+ @BUSCAR + '%') AND ")
        query.Append("(CVE_PROV = @BUSCAR_PROVEEDOR OR @BUSCAR_PROVEEDOR = '-1')")

        Dim comando As New SqlCommand(query.ToString, sql_con)
        comando.Parameters.AddWithValue("@BUSCAR", BUSCAR)
        comando.Parameters.AddWithValue("@BUSCAR_PROVEEDOR", BUSCAR_PROVEEDOR)
        Dim adaptador As New SqlDataAdapter(comando)
        adaptador.Fill(dt)
        sql_con.Close()
        Return dt
    End Function

    Public Function insertar_precio(ByVal CVE_ART As String, ByVal PRECIO_NEG As Double, ByVal usuarioid As Integer, _
                                    ByVal usuario_nombre As String, ByVal fecha_hora As DateTime, ByVal precio_anterior As String) As String
        Dim mitransaccion As SqlTransaction
        Dim conexion_sql As New SqlConnection(Conexion3.CadenaSQL)
        conexion_sql.Open()
        mitransaccion = conexion_sql.BeginTransaction
        Try
            Dim query As New StringBuilder

            query.Append("INSERT INTO [tactical_discount].[dbo].[nd_margenes_autorizados] ")
            query.Append("([CVE_ART],[MARGEN_AUT]) ")
            query.Append("VALUES(@CVE_ART, @MARGEN_AUT) ")
            Dim micomando As New SqlCommand(query.ToString, conexion_sql)

            micomando.Parameters.AddWithValue("@CVE_ART", CVE_ART)
            micomando.Parameters.AddWithValue("@MARGEN_AUT", PRECIO_NEG)
            micomando.Transaction = mitransaccion
            micomando.ExecuteNonQuery()

            mitransaccion.Commit()
            conexion_sql.Close()
            Return "correcto"
        Catch ex As Exception
            mitransaccion.Rollback()
            conexion_sql.Close()
            Return ex.Message
        End Try
    End Function

    Public Function actualizar_precio(ByVal CVE_ART As String, ByVal PRECIO_NEG As Double, ByVal usuarioid As Integer, _
                                    ByVal usuario_nombre As String, ByVal fecha_hora As DateTime, ByVal precio_anterior As String) As String
        Dim mitransaccion As SqlTransaction
        Dim conexion_sql As New SqlConnection(Conexion3.CadenaSQL)
        conexion_sql.Open()
        mitransaccion = conexion_sql.BeginTransaction
        Try

            Dim query As New StringBuilder
            Dim query_bita As New StringBuilder
            query.Append("UPDATE [tactical_discount].[dbo].[nd_margenes_autorizados] ")
            query.Append("SET [MARGEN_AUT] = @MARGEN_AUT ")
            query.Append("WHERE [CVE_ART] = @CVE_ART")

            Dim micomando As New SqlCommand(query.ToString, conexion_sql)

            micomando.Parameters.AddWithValue("@MARGEN_AUT", PRECIO_NEG)
            micomando.Parameters.AddWithValue("@CVE_ART", CVE_ART)
            micomando.Transaction = mitransaccion
            micomando.ExecuteNonQuery()

            mitransaccion.Commit()
            conexion_sql.Close()
            Return "correcto"

        Catch ex As Exception
            conexion_sql.Close()
            Return ex.Message
        End Try
    End Function

    Public Function cargar_proveedores() As DataTable
        Dim dt As New DataTable
        Dim query As New StringBuilder
        Dim sql_con As New SqlConnection(Conexion2.CadenaSQL)

        query.Append("SELECT '-1' AS CLAVE, 'Sin Filtro' AS NOMBRE ")
        query.Append("UNION ALL ")
        query.Append("SELECT CLAVE, NOMBRE ")
        query.Append("FROM SAE60Empre05.dbo.PROV05 ")
        sql_con.Open()
        Dim comando As New SqlCommand(query.ToString, sql_con)
        Dim adaptador As New SqlDataAdapter(comando)
        adaptador.Fill(dt)
        sql_con.Close()
        Return dt
    End Function

    Public Function select_productos_precio_neg() As DataTable
        Dim conexion_sql As New SqlConnection(Conexion3.CadenaSQL)
        conexion_sql.Open()
        Dim query As New StringBuilder
        query.Append("SELECT TD.[CVE_ART] AS CODIGO,IV.DESCR AS PRODUCTO,")
        query.Append("TD.[MARGEN_AUT] AS 'MARGEN AUTORIZADO' ")
        query.Append("FROM [tactical_discount].[dbo].[nd_margenes_autorizados] TD ")
        query.Append("INNER JOIN SAE60Empre05.dbo.INVE05 IV ")
        query.Append("ON IV.CVE_ART = TD.CVE_ART COLLATE MODERN_SPANISH_CI_AS")
        query.Append("WHERE TD.CVE_ART LIKE '%' + @buscar + '%' OR IV.DESCR LIKE '%' + @buscar + '%' ")

        Dim comando As New SqlCommand(query.ToString)
        Dim dt As New DataTable

        conexion_sql.Close()
        Return dt
    End Function
    'FIN DE MARGENES AUTORIZADOS POR PRODUCTO

    Public Function ListaPaletizado(ByVal Almacen As Integer) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT     dbo.Paletizado_Bodega.Casa_Comercial AS 'Casa Comercial', " & _
                                        " CASE WHEN dbo.Paletizado_Bodega.Casa_Comercial = 'ARC' THEN 'ARCHIVO' WHEN dbo.Paletizado_Bodega.Casa_Comercial = 'TAR' THEN 'TARIMAS' ELSE SAE60Empre05.dbo.CLIN05.DESC_LIN " & _
                                        " END AS 'Descripción', dbo.Paletizado_Bodega.Capacidad, dbo.Paletizado_Bodega.Almacen  FROM dbo.Paletizado_Bodega LEFT OUTER JOIN " & _
                                        " SAE60Empre05.dbo.CLIN05 ON LTRIM(dbo.Paletizado_Bodega.Casa_Comercial) = LTRIM(SAE60Empre05.dbo.CLIN05.CVE_LIN) COLLATE MODERN_SPANISH_CI_AS WHERE dbo.Paletizado_Bodega.Almacen = " & Almacen & " ", ActualizarConexion)
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

    Public Function ModificaPaletizado(ByVal dt As DataTable, ByVal Usuario As String, ByVal Almacen As Integer)
        Dim mitransaccion As SqlTransaction
        Dim conexion_sql As New SqlConnection(Conexion.CadenaSQL)
        conexion_sql.Open()
        mitransaccion = conexion_sql.BeginTransaction

        Try

            For i As Integer = 0 To dt.Rows.Count - 1
                Dim query As New StringBuilder
                Dim query_bita As New StringBuilder
                query.Append("UPDATE [Usuarios].[dbo].[Paletizado_Bodega] ")
                query.Append("SET [Capacidad] = @Capacidad ")
                query.Append("WHERE [Casa_Comercial] = @Casa_Comercial And [Almacen] = @Almacen")

                Dim micomando As New SqlCommand(query.ToString, conexion_sql)
                micomando.Parameters.AddWithValue("@Casa_Comercial", dt(i)(0))
                micomando.Parameters.AddWithValue("@Capacidad", dt(i)(3))
                micomando.Parameters.AddWithValue("@Almacen", Almacen)

                micomando.Transaction = mitransaccion
                micomando.ExecuteNonQuery()

            Next

            Dim conexion_bita As New cls_bitacora_reporteador
            conexion_bita.RegistraBitacora(Now, Usuario, "Hizo Cambio en el paletizado ", "ALMACEN", _
                                      "Fecha: " & DateTime.Now & " Almacén: " & Almacen)

            mitransaccion.Commit()
            conexion_sql.Close()
            Return "correcto"

        Catch ex As Exception
            conexion_sql.Close()
            Return ex.Message
        End Try

    End Function

End Class