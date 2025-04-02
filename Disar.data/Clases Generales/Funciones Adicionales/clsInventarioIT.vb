Imports Disar.data
Imports System.Data.SqlClient
Imports System.Text

Public Class clsInventarioIT

    Dim Conexion As New clsConexion

    Public Function VerCategorias()
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT CategoriaId, CategoriaNombre FROM  It_Cat", ActualizarConexion)


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

    Public Function VerCategoriasBusqueda()
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT 10000 as CategoriaId, 'Todas' as CategoriaNombre UNION ALL select CategoriaId, CategoriaNombre FROM  It_Cat", ActualizarConexion)


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

    Public Function NuevoNumero()
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT Max(NumArticulo) FROM  It_Eq", ActualizarConexion)

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

    Public Function VerTodoEquipo()
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT dbo.It_Eq.NumArticulo AS 'Nº', dbo.It_Eq.Descripcion AS 'Descripción', dbo.It_Eq.CategoriaID AS 'Cat', dbo.It_Cat.CategoriaNombre AS 'Categoría', dbo.It_Eq.Serie," & _
                      " dbo.It_Eq.Modelo, dbo.It_Eq.Marca, dbo.It_Eq.PC_Procesador AS Procesador, dbo.It_Eq.PC_RAM AS RAM, dbo.It_Eq.PC_HD AS 'Disco Duro', " & _
                      " dbo.It_Eq.Fecha_Compra AS 'Fecha de Compra', dbo.It_Eq.Fecha_FinalizaGarantia AS 'Finalización de garantía', dbo.It_Eq.FacturaCompra AS 'Nº de Factura Compra',  " & _
                      " dbo.It_Eq.Proveedor, dbo.It_Eq.Costo, dbo.It_Eq.Estado, dbo.It_Eq.EstadoAsignacion AS Asignado, dbo.It_Eq.Contacto, dbo.It_Eq.Ubicacion, dbo.It_Eq.Numero, dbo.It_Eq.SIM " & _
                      " FROM  dbo.It_Eq INNER JOIN dbo.It_Cat ON dbo.It_Eq.CategoriaID = dbo.It_Cat.CategoriaId", ActualizarConexion)

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

    Public Function VerTodoEquipoPorEstado(ByVal Estado As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT dbo.It_Eq.NumArticulo AS 'Nº', dbo.It_Eq.Descripcion AS 'Descripción', dbo.It_Eq.CategoriaID AS 'Cat', dbo.It_Cat.CategoriaNombre AS 'Categoría', dbo.It_Eq.Serie," & _
                      " dbo.It_Eq.Modelo, dbo.It_Eq.Marca, dbo.It_Eq.PC_Procesador AS Procesador, dbo.It_Eq.PC_RAM AS RAM, dbo.It_Eq.PC_HD AS 'Disco Duro', " & _
                      " dbo.It_Eq.Fecha_Compra AS 'Fecha de Compra', dbo.It_Eq.Fecha_FinalizaGarantia AS 'Finalización de garantía', dbo.It_Eq.FacturaCompra AS 'Nº de Factura Compra',  " & _
                      " dbo.It_Eq.Proveedor, dbo.It_Eq.Costo, dbo.It_Eq.Estado, dbo.It_Eq.EstadoAsignacion AS Asignado, dbo.It_Eq.Contacto, dbo.It_Eq.Ubicacion, dbo.It_Eq.Numero, dbo.It_Eq.SIM " & _
                      " FROM  dbo.It_Eq INNER JOIN dbo.It_Cat ON dbo.It_Eq.CategoriaID = dbo.It_Cat.CategoriaId WHERE dbo.It_Eq.Estado = @Estado", ActualizarConexion)
        miComando.Parameters.AddWithValue("@Estado", Estado)
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

    Public Function VerEquipoDisponible()
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT dbo.It_Eq.NumArticulo AS 'Nº', dbo.It_Eq.Descripcion AS 'Descripción', dbo.It_Eq.CategoriaID AS 'Cat', dbo.It_Cat.CategoriaNombre AS 'Categoría', dbo.It_Eq.Serie," & _
                      " dbo.It_Eq.Modelo, dbo.It_Eq.Marca, dbo.It_Eq.PC_Procesador AS Procesador, dbo.It_Eq.PC_RAM AS RAM, dbo.It_Eq.PC_HD AS 'Disco Duro', " & _
                      " dbo.It_Eq.Fecha_Compra AS 'Fecha de Compra', dbo.It_Eq.Fecha_FinalizaGarantia AS 'Finalización de garantía', dbo.It_Eq.FacturaCompra AS 'Nº de Factura Compra',  " & _
                      " dbo.It_Eq.Proveedor, dbo.It_Eq.Costo, dbo.It_Eq.Estado, dbo.It_Eq.EstadoAsignacion AS Asignado, dbo.It_Eq.Contacto, dbo.It_Eq.Ubicacion, dbo.It_Eq.Numero, dbo.It_Eq.SIM " & _
                      " FROM  dbo.It_Eq INNER JOIN dbo.It_Cat ON dbo.It_Eq.CategoriaID = dbo.It_Cat.CategoriaId WHERE It_Eq.EstadoAsignacion = 'Disponible'", ActualizarConexion)

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

    Public Function VerEquipoDisponiblePorEstado(ByVal Estado As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT dbo.It_Eq.NumArticulo AS 'Nº', dbo.It_Eq.Descripcion AS 'Descripción', dbo.It_Eq.CategoriaID AS 'Cat', dbo.It_Cat.CategoriaNombre AS 'Categoría', dbo.It_Eq.Serie," & _
                      " dbo.It_Eq.Modelo, dbo.It_Eq.Marca, dbo.It_Eq.PC_Procesador AS Procesador, dbo.It_Eq.PC_RAM AS RAM, dbo.It_Eq.PC_HD AS 'Disco Duro', " & _
                      " dbo.It_Eq.Fecha_Compra AS 'Fecha de Compra', dbo.It_Eq.Fecha_FinalizaGarantia AS 'Finalización de garantía', dbo.It_Eq.FacturaCompra AS 'Nº de Factura Compra',  " & _
                      " dbo.It_Eq.Proveedor, dbo.It_Eq.Costo, dbo.It_Eq.Estado, dbo.It_Eq.EstadoAsignacion AS Asignado, dbo.It_Eq.Contacto, dbo.It_Eq.Ubicacion, dbo.It_Eq.Numero, dbo.It_Eq.SIM " & _
                      " FROM  dbo.It_Eq INNER JOIN dbo.It_Cat ON dbo.It_Eq.CategoriaID = dbo.It_Cat.CategoriaId WHERE It_Eq.EstadoAsignacion = 'Disponible' AND It_Eq.Estado = @Estado", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Estado", Estado)
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

    Public Function FiltroEquipoPorEstado(ByVal Estado As String, ByVal Busca As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT dbo.It_Eq.NumArticulo AS 'Nº', dbo.It_Eq.Descripcion AS 'Descripción', dbo.It_Eq.CategoriaID AS 'Cat', dbo.It_Cat.CategoriaNombre AS 'Categoría', dbo.It_Eq.Serie," & _
                      " dbo.It_Eq.Modelo, dbo.It_Eq.Marca, dbo.It_Eq.PC_Procesador AS Procesador, dbo.It_Eq.PC_RAM AS RAM, dbo.It_Eq.PC_HD AS 'Disco Duro', " & _
                      " dbo.It_Eq.Fecha_Compra AS 'Fecha de Compra', dbo.It_Eq.Fecha_FinalizaGarantia AS 'Finalización de garantía', dbo.It_Eq.FacturaCompra AS 'Nº de Factura Compra',  " & _
                      " dbo.It_Eq.Proveedor, dbo.It_Eq.Costo, dbo.It_Eq.Estado, dbo.It_Eq.EstadoAsignacion AS Asignado, dbo.It_Eq.Contacto, dbo.It_Eq.Ubicacion, dbo.It_Eq.Numero, dbo.It_Eq.SIM " & _
                      " FROM  dbo.It_Eq INNER JOIN dbo.It_Cat ON dbo.It_Eq.CategoriaID = dbo.It_Cat.CategoriaId WHERE dbo.It_Eq.Estado = @Estado and dbo.It_Eq.Descripcion LIKE '%" & Busca & "%' OR " & _
                      " dbo.It_Eq.Estado = @Estado and dbo.It_Eq.Serie LIKE '%" & Busca & "%'", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Estado", Estado)

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

    Public Function FiltroEquipo(ByVal Estado As String, ByVal Busca As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT dbo.It_Eq.NumArticulo AS 'Nº', dbo.It_Eq.Descripcion AS 'Descripción', dbo.It_Eq.CategoriaID AS 'Cat', dbo.It_Cat.CategoriaNombre AS 'Categoría', dbo.It_Eq.Serie," & _
                      " dbo.It_Eq.Modelo, dbo.It_Eq.Marca, dbo.It_Eq.PC_Procesador AS Procesador, dbo.It_Eq.PC_RAM AS RAM, dbo.It_Eq.PC_HD AS 'Disco Duro', " & _
                      " dbo.It_Eq.Fecha_Compra AS 'Fecha de Compra', dbo.It_Eq.Fecha_FinalizaGarantia AS 'Finalización de garantía', dbo.It_Eq.FacturaCompra AS 'Nº de Factura Compra',  " & _
                      " dbo.It_Eq.Proveedor, dbo.It_Eq.Costo, dbo.It_Eq.Estado, dbo.It_Eq.EstadoAsignacion AS Asignado, dbo.It_Eq.Contacto, dbo.It_Eq.Ubicacion, dbo.It_Eq.Numero, dbo.It_Eq.SIM " & _
                      " FROM  dbo.It_Eq INNER JOIN dbo.It_Cat ON dbo.It_Eq.CategoriaID = dbo.It_Cat.CategoriaId WHERE dbo.It_Eq.Descripcion LIKE '%" & Busca & "%' OR " & _
                      " dbo.It_Eq.Serie LIKE '%" & Busca & "%'", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Estado", Estado)

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

    Public Function FiltroEquipoDisponiblePorEstado(ByVal Estado As String, ByVal Busca As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT dbo.It_Eq.NumArticulo AS 'Nº', dbo.It_Eq.Descripcion AS 'Descripción', dbo.It_Eq.CategoriaID AS 'Cat', dbo.It_Cat.CategoriaNombre AS 'Categoría', dbo.It_Eq.Serie," & _
                      " dbo.It_Eq.Modelo, dbo.It_Eq.Marca, dbo.It_Eq.PC_Procesador AS Procesador, dbo.It_Eq.PC_RAM AS RAM, dbo.It_Eq.PC_HD AS 'Disco Duro', " & _
                      " dbo.It_Eq.Fecha_Compra AS 'Fecha de Compra', dbo.It_Eq.Fecha_FinalizaGarantia AS 'Finalización de garantía', dbo.It_Eq.FacturaCompra AS 'Nº de Factura Compra',  " & _
                      " dbo.It_Eq.Proveedor, dbo.It_Eq.Costo, dbo.It_Eq.Estado, dbo.It_Eq.EstadoAsignacion AS Asignado, dbo.It_Eq.Contacto, dbo.It_Eq.Ubicacion, dbo.It_Eq.Numero, dbo.It_Eq.SIM " & _
                      " FROM  dbo.It_Eq INNER JOIN dbo.It_Cat ON dbo.It_Eq.CategoriaID = dbo.It_Cat.CategoriaId WHERE dbo.It_Eq.Estado = @Estado and dbo.It_Eq.Descripcion LIKE '%" & Busca & "%' AND dbo.It_Eq.EstadoAsignacion = 'DISPONIBLE 'OR " & _
                      " dbo.It_Eq.Estado = @Estado and dbo.It_Eq.Serie LIKE '%" & Busca & "%' AND dbo.It_Eq.EstadoAsignacion = 'DISPONIBLE'", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Estado", Estado)

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

    Public Function FiltroEquipoDisponible(ByVal Busca As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT dbo.It_Eq.NumArticulo AS 'Nº', dbo.It_Eq.Descripcion AS 'Descripción', dbo.It_Eq.CategoriaID AS 'Cat', dbo.It_Cat.CategoriaNombre AS 'Categoría', dbo.It_Eq.Serie," & _
                      " dbo.It_Eq.Modelo, dbo.It_Eq.Marca, dbo.It_Eq.PC_Procesador AS Procesador, dbo.It_Eq.PC_RAM AS RAM, dbo.It_Eq.PC_HD AS 'Disco Duro', " & _
                      " dbo.It_Eq.Fecha_Compra AS 'Fecha de Compra', dbo.It_Eq.Fecha_FinalizaGarantia AS 'Finalización de garantía', dbo.It_Eq.FacturaCompra AS 'Nº de Factura Compra',  " & _
                      " dbo.It_Eq.Proveedor, dbo.It_Eq.Costo, dbo.It_Eq.Estado, dbo.It_Eq.EstadoAsignacion AS Asignado, dbo.It_Eq.Contacto, dbo.It_Eq.Ubicacion, dbo.It_Eq.Numero, dbo.It_Eq.SIM " & _
                      " FROM  dbo.It_Eq INNER JOIN dbo.It_Cat ON dbo.It_Eq.CategoriaID = dbo.It_Cat.CategoriaId WHERE dbo.It_Eq.Descripcion LIKE '%" & Busca & "%' AND dbo.It_Eq.EstadoAsignacion = 'DISPONIBLE' OR " & _
                      " dbo.It_Eq.Serie LIKE '%" & Busca & "%' AND dbo.It_Eq.EstadoAsignacion = 'DISPONIBLE'", ActualizarConexion)


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

    Public Function VerMarcas()
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT DISTINCT Marca FROM  It_Eq", ActualizarConexion)

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

    Public Function VerProveedor()
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT DISTINCT Proveedor FROM It_Eq", ActualizarConexion)

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

    Public Function VerUbicacion()
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT DISTINCT Ubicacion FROM It_Eq", ActualizarConexion)

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

    Public Function NuevoRegistro(ByVal NumArticulo As Integer, ByVal Descripcion As String, ByVal CategoriaID As Integer, ByVal Serie As String, ByVal Modelo As String, ByVal Marca As String, ByVal PC_Procesador As String, ByVal PC_RAM As String, ByVal PC_HD As String, ByVal Fecha_Compra As Date, ByVal Fecha_FinalizaGarantia As Date, ByVal Costo As Decimal, ByVal Estado As String, ByVal EstadoAsignacion As String, ByVal FacturaCompra As String, ByVal Proveedor As String, ByVal Contacto As String, ByVal Ubicacion As String, ByVal Sim As String, ByVal Numero As String)

        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand
            'Guarda nueva marca

            Dim NumBita As Integer = 0
            Dim DtBita As New DataTable
            Dim QueryBita As String
            QueryBita = "SELECT MAX (NumArticulo) FROM It_Eq"
            Dim CMDQueryBita As New SqlCommand(QueryBita, ActualizarConexion)
            Dim AdaptadorBita As New SqlDataAdapter(CMDQueryBita)
            CMDQueryBita.Transaction = transaccion_sql
            AdaptadorBita.Fill(DtBita)

            If DtBita.Rows.Count > 0 Then
                If Not IsDBNull(DtBita.Rows(0)(0)) Then
                    NumBita = DtBita.Rows(0)(0)
                End If
            End If
            NumBita += 1
            miComando = New SqlCommand("INSERT INTO It_Eq" & _
                                         " (NumArticulo, Descripcion, CategoriaID, Serie, Modelo, Marca, PC_Procesador, PC_RAM, PC_HD, Fecha_Compra, " & _
                                         " Fecha_FinalizaGarantia, Costo, Estado, EstadoAsignacion, FacturaCompra, Proveedor, Contacto, Ubicacion, SIM, Numero) " & _
                                         " VALUES (@NumArticulo, @Descripcion, @CategoriaID, @Serie, @Modelo, @Marca, @PC_Procesador, @PC_RAM, @PC_HD, @Fecha_Compra, " & _
                                         " @Fecha_FinalizaGarantia, @Costo, @Estado, @EstadoAsignacion, @FacturaCompra, @Proveedor, @Contacto, @Ubicacion, @SIM, @Numero)", ActualizarConexion)
            miComando.Parameters.AddWithValue("@NumArticulo", NumBita)
            miComando.Parameters.AddWithValue("@Descripcion", Descripcion)
            miComando.Parameters.AddWithValue("@CategoriaID", CategoriaID)
            miComando.Parameters.AddWithValue("@Serie", Serie)
            miComando.Parameters.AddWithValue("@Modelo", Modelo)
            miComando.Parameters.AddWithValue("@Marca", Marca)
            miComando.Parameters.AddWithValue("@PC_Procesador", PC_Procesador)
            miComando.Parameters.AddWithValue("@PC_RAM", PC_RAM)
            miComando.Parameters.AddWithValue("@PC_HD", PC_HD)
            miComando.Parameters.AddWithValue("@Fecha_Compra", Fecha_Compra.Date)
            miComando.Parameters.AddWithValue("@Fecha_FinalizaGarantia", Fecha_FinalizaGarantia.Date)
            miComando.Parameters.AddWithValue("@Costo", Costo)
            miComando.Parameters.AddWithValue("@Estado", Estado)
            miComando.Parameters.AddWithValue("@EstadoAsignacion", EstadoAsignacion)
            miComando.Parameters.AddWithValue("@FacturaCompra", FacturaCompra)
            miComando.Parameters.AddWithValue("@Proveedor", Proveedor)
            miComando.Parameters.AddWithValue("@Contacto", Contacto)
            miComando.Parameters.AddWithValue("@Ubicacion", Ubicacion)
            miComando.Parameters.AddWithValue("@SIM", Sim)
            miComando.Parameters.AddWithValue("@Numero", Numero)

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
        End Try

    End Function

    Public Function ModificaRegistro(ByVal NumArticulo As Integer, ByVal Descripcion As String, ByVal CategoriaID As Integer, ByVal Serie As String, ByVal Modelo As String, ByVal Marca As String, ByVal PC_Procesador As String, ByVal PC_RAM As String, ByVal PC_HD As String, ByVal Fecha_Compra As Date, ByVal Fecha_FinalizaGarantia As Date, ByVal Costo As Decimal, ByVal Estado As String, ByVal EstadoAsignacion As String, ByVal FacturaCompra As String, ByVal Proveedor As String, ByVal Contacto As String, ByVal Ubicacion As String, ByVal SIM As String, ByVal Num As String)

        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand
            'Guarda nueva marca

            miComando = New SqlCommand("UPDATE It_Eq" & _
                                         " SET Descripcion = @Descripcion, CategoriaID = @CategoriaID, Serie = @Serie, Modelo  = @Modelo, Marca = @Marca, PC_Procesador = @PC_Procesador, PC_RAM = @PC_RAM, PC_HD = @PC_HD, Fecha_Compra = @Fecha_Compra, " & _
                                         " Fecha_FinalizaGarantia = @Fecha_FinalizaGarantia, Costo = @Costo, Estado = @Estado, EstadoAsignacion = @EstadoAsignacion, FacturaCompra = @FacturaCompra, Proveedor = @Proveedor, Contacto = @Contacto, Ubicacion = @Ubicacion, SIM = @SIM, Numero = @Numero " & _
                                         " WHERE NumArticulo = @NumArticulo", ActualizarConexion)
            miComando.Parameters.AddWithValue("@NumArticulo", NumArticulo)
            miComando.Parameters.AddWithValue("@Descripcion", Descripcion)
            miComando.Parameters.AddWithValue("@CategoriaID", CategoriaID)
            miComando.Parameters.AddWithValue("@Serie", Serie)
            miComando.Parameters.AddWithValue("@Modelo", Modelo)
            miComando.Parameters.AddWithValue("@Marca", Marca)
            miComando.Parameters.AddWithValue("@PC_Procesador", PC_Procesador)
            miComando.Parameters.AddWithValue("@PC_RAM", PC_RAM)
            miComando.Parameters.AddWithValue("@PC_HD", PC_HD)
            miComando.Parameters.AddWithValue("@Fecha_Compra", Fecha_Compra.Date)
            miComando.Parameters.AddWithValue("@Fecha_FinalizaGarantia", Fecha_FinalizaGarantia.Date)
            miComando.Parameters.AddWithValue("@Costo", Costo)
            miComando.Parameters.AddWithValue("@Estado", Estado)
            miComando.Parameters.AddWithValue("@EstadoAsignacion", EstadoAsignacion)
            miComando.Parameters.AddWithValue("@FacturaCompra", FacturaCompra)
            miComando.Parameters.AddWithValue("@Proveedor", Proveedor)
            miComando.Parameters.AddWithValue("@Contacto", Contacto)
            miComando.Parameters.AddWithValue("@Ubicacion", Ubicacion)
            miComando.Parameters.AddWithValue("@SIM", SIM)
            miComando.Parameters.AddWithValue("@Numero", Num)

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
        End Try

    End Function

    Public Function VerEmpleados()
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT Holidays.dbo.Empleados.EmpleadoId, Holidays.dbo.Empleados.EmpleadoNombre, Holidays.dbo.Empleados.EmpleadoContacto, Holidays.dbo.Empleados.EmpleadoCargo FROM Holidays.dbo.Empleados WHERE (Holidays.dbo.Empleados.EmpleadoEstado = 'Activo') ", ActualizarConexion)

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

    Public Function BuscarEmpleados(ByVal Empleado As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT Holidays.dbo.Empleados.EmpleadoId, Holidays.dbo.Empleados.EmpleadoNombre, Holidays.dbo.Empleados.EmpleadoContacto, Holidays.dbo.Empleados.EmpleadoCargo FROM Holidays.dbo.Empleados WHERE Holidays.dbo.Empleados.EmpleadoEstado = 'Activo' AND Holidays.dbo.Empleados.EmpleadoNombre LIKE '%" & Empleado & "%'", ActualizarConexion)

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

    Public Function NuevaAsignacion(ByVal Equipo As String, ByVal Colaborador As String, ByVal ColaboradorNombre As String, ByVal Fecha As Date, ByVal ConLimite As String, ByVal FechaLimite As Date, ByVal EstadoAsignac As String, ByVal Accesorios As String, ByVal Observacion As String, ByVal Entregador As String, ByVal DepartamentoRecibe As String)

        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand
            'Guarda nueva marca

            Dim NumBita As Integer = 0
            Dim DtBita As New DataTable
            Dim QueryBita As String
            QueryBita = "SELECT MAX (Asignacion_Num) FROM It_Asignacion"
            Dim CMDQueryBita As New SqlCommand(QueryBita, ActualizarConexion)
            Dim AdaptadorBita As New SqlDataAdapter(CMDQueryBita)
            CMDQueryBita.Transaction = transaccion_sql
            AdaptadorBita.Fill(DtBita)

            If DtBita.Rows.Count > 0 Then
                If Not IsDBNull(DtBita.Rows(0)(0)) Then
                    NumBita = DtBita.Rows(0)(0)
                End If
            End If
            NumBita += 1
            miComando = New SqlCommand("INSERT INTO It_Asignacion" & _
                                         " (Asignacion_Num, Equipo, Colaborador, Fecha, ConLimite, FechaLimite, EstadoAsignac, Accesorios, Observacion, Entregador, DepartamentoRecibe) " & _
                                         " VALUES (@Asignacion_Num, @Equipo, @Colaborador, @Fecha, @ConLimite, @FechaLimite, @EstadoAsignac, @Accesorios, @Observacion, @Entregador, @DepartamentoRecibe)", ActualizarConexion)

            miComando.Parameters.AddWithValue("@Asignacion_Num", NumBita)
            miComando.Parameters.AddWithValue("@Equipo", Equipo)
            miComando.Parameters.AddWithValue("@Colaborador", Colaborador)

            miComando.Parameters.AddWithValue("@Fecha", Fecha)
            miComando.Parameters.AddWithValue("@ConLimite", ConLimite)
            miComando.Parameters.AddWithValue("@FechaLimite", FechaLimite)
            miComando.Parameters.AddWithValue("@EstadoAsignac", EstadoAsignac)
            miComando.Parameters.AddWithValue("@Accesorios", Accesorios)
            miComando.Parameters.AddWithValue("@Observacion", Observacion)

            miComando.Parameters.AddWithValue("@Entregador", Entregador)
            miComando.Parameters.AddWithValue("@DepartamentoRecibe", DepartamentoRecibe)


            miComando.Transaction = transaccion_sql
            miComando.ExecuteNonQuery()

            miComando = New SqlCommand(" UPDATE It_Eq" & _
                                       " SET ESTADOASIGNACION = @Estado WHERE NumArticulo = @NumArticulo ", ActualizarConexion)

            miComando.Parameters.AddWithValue("@NumArticulo", Equipo)
            miComando.Parameters.AddWithValue("@Estado", "Asignado a " & ColaboradorNombre)

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
        End Try

    End Function

    Public Function VerAsignaciones()
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT     dbo.It_Asignacion.Asignacion_Num AS 'Nº', dbo.It_Eq.Descripcion, dbo.It_Eq.Serie, dbo.It_Eq.Marca, dbo.It_Eq.Modelo, " & _
                      " Holidays.dbo.Empleados.EmpleadoNombre AS 'Asignado a', dbo.It_Asignacion.DepartamentoRecibe AS Departamento, dbo.It_Asignacion.Fecha, " & _
                      " CASE WHEN ConLimite = 'S' THEN CONVERT(VARCHAR(12), dbo.It_Asignacion.FechaLimite) ELSE '' END AS 'Límite Fecha', " & _
                      " dbo.It_Asignacion.EstadoAsignac AS 'Actualmente', dbo.It_Asignacion.Accesorios, dbo.It_Asignacion.Observacion, " & _
                      " dbo.It_Asignacion.Entregador AS 'Persona que entregó' FROM         dbo.It_Asignacion INNER JOIN " & _
                      " dbo.It_Eq ON dbo.It_Asignacion.Equipo = dbo.It_Eq.NumArticulo INNER JOIN " & _
                      " Holidays.dbo.Empleados ON dbo.It_Asignacion.Colaborador = Holidays.dbo.Empleados.EmpleadoId", ActualizarConexion)

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

    Public Function BuscarAsignaciones(ByVal Busqueda As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT     dbo.It_Asignacion.Asignacion_Num AS 'Nº', dbo.It_Eq.Descripcion, dbo.It_Eq.Serie, dbo.It_Eq.Marca, dbo.It_Eq.Modelo, " & _
                      " Holidays.dbo.Empleados.EmpleadoNombre AS 'Asignado a', dbo.It_Asignacion.DepartamentoRecibe AS Departamento, dbo.It_Asignacion.Fecha, " & _
                      " CASE WHEN ConLimite = 'S' THEN CONVERT(VARCHAR(12), dbo.It_Asignacion.FechaLimite) ELSE '' END AS 'Límite Fecha', " & _
                      " dbo.It_Asignacion.EstadoAsignac AS 'Actualmente', dbo.It_Asignacion.Accesorios, dbo.It_Asignacion.Observacion, " & _
                      " dbo.It_Asignacion.Entregador AS 'Persona que entregó' FROM         dbo.It_Asignacion INNER JOIN " & _
                      " dbo.It_Eq ON dbo.It_Asignacion.Equipo = dbo.It_Eq.NumArticulo INNER JOIN " & _
                      " Holidays.dbo.Empleados ON dbo.It_Asignacion.Colaborador = Holidays.dbo.Empleados.EmpleadoId WHERE Holidays.dbo.Empleados.EmpleadoNombre LIKE '%" & Busqueda & "%' ", ActualizarConexion)

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

    Public Function FiltrarAsignacionesPorTipo(ByVal Busqueda As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT     dbo.It_Asignacion.Asignacion_Num AS 'Nº', dbo.It_Eq.Descripcion, dbo.It_Eq.Serie, dbo.It_Eq.Marca, dbo.It_Eq.Modelo, " & _
                      " Holidays.dbo.Empleados.EmpleadoNombre AS 'Asignado a', dbo.It_Asignacion.DepartamentoRecibe AS Departamento, dbo.It_Asignacion.Fecha, " & _
                      " CASE WHEN ConLimite = 'S' THEN CONVERT(VARCHAR(12), dbo.It_Asignacion.FechaLimite) ELSE '' END AS 'Límite Fecha', " & _
                      " dbo.It_Asignacion.EstadoAsignac AS 'Actualmente', dbo.It_Asignacion.Accesorios, dbo.It_Asignacion.Observacion, " & _
                      " dbo.It_Asignacion.Entregador AS 'Persona que entregó' FROM         dbo.It_Asignacion INNER JOIN " & _
                      " dbo.It_Eq ON dbo.It_Asignacion.Equipo = dbo.It_Eq.NumArticulo INNER JOIN " & _
                      " Holidays.dbo.Empleados ON dbo.It_Asignacion.Colaborador = Holidays.dbo.Empleados.EmpleadoId WHERE dbo.It_Eq.CategoriaId = @Categoria", ActualizarConexion)
        miComando.Parameters.AddWithValue("@Categoria", Busqueda)

        ActualizarConexion.Open()
        Dim AdaptadorDeDatos As New SqlDataAdapter(miComando)
        Dim dt As New DataTable
        Try
            AdaptadorDeDatos.Fill(dt)
            ActualizarConexion.Close()
        Catch ex As SqlException
            ActualizarConexion.Close()
        End Try
        Return dt
    End Function

    Public Function NuevaDevolAlmacen(ByVal Equipo As String, ByVal Fecha As Date)

        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand
            Dim miComando2 As New SqlCommand
            'Guarda nueva marca

       
            miComando = New SqlCommand("UPDATE It_Asignacion " & _
                                         " SET EstadoAsignac = 'Asignación finalizada' WHERE Equipo = @Equipo ", ActualizarConexion)


            miComando.Parameters.AddWithValue("@Equipo", Equipo)


            miComando.Transaction = transaccion_sql
            miComando.ExecuteNonQuery()

            miComando2 = New SqlCommand(" UPDATE It_Eq " & _
                                       " SET ESTADOASIGNACION = @Estado WHERE NumArticulo = @NumArticulo ", ActualizarConexion)

            miComando2.Parameters.AddWithValue("@NumArticulo", Equipo)
            miComando2.Parameters.AddWithValue("@Estado", "Disponible")

            miComando2.Transaction = transaccion_sql
            miComando2.ExecuteNonQuery()

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
        End Try

    End Function

    Public Function FiltrarAsignacionesPorItem(ByVal Busqueda As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT     dbo.It_Asignacion.Asignacion_Num AS 'Nº', dbo.It_Eq.Descripcion, dbo.It_Eq.Serie, dbo.It_Eq.Marca, dbo.It_Eq.Modelo, " & _
                      " Holidays.dbo.Empleados.EmpleadoNombre AS 'Asignado a', dbo.It_Asignacion.DepartamentoRecibe AS Departamento, dbo.It_Asignacion.Fecha, " & _
                      " CASE WHEN ConLimite = 'S' THEN CONVERT(VARCHAR(12), dbo.It_Asignacion.FechaLimite) ELSE '' END AS 'Límite Fecha', " & _
                      " dbo.It_Asignacion.EstadoAsignac AS 'Actualmente', dbo.It_Asignacion.Accesorios, dbo.It_Asignacion.Observacion, " & _
                      " dbo.It_Asignacion.Entregador AS 'Persona que entregó' FROM         dbo.It_Asignacion INNER JOIN " & _
                      " dbo.It_Eq ON dbo.It_Asignacion.Equipo = dbo.It_Eq.NumArticulo INNER JOIN " & _
                      " Holidays.dbo.Empleados ON dbo.It_Asignacion.Colaborador = Holidays.dbo.Empleados.EmpleadoId WHERE dbo.It_Eq.NumArticulo = @Categoria", ActualizarConexion)
        miComando.Parameters.AddWithValue("@Categoria", Busqueda)

        ActualizarConexion.Open()
        Dim AdaptadorDeDatos As New SqlDataAdapter(miComando)
        Dim dt As New DataTable
        Try
            AdaptadorDeDatos.Fill(dt)
            ActualizarConexion.Close()
        Catch ex As SqlException
            ActualizarConexion.Close()
        End Try
        Return dt
    End Function

    Public Function NuevoNumeroRepuesto()
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT Max(Num) FROM  It_Repuestos", ActualizarConexion)

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

    Public Function NuevoRegistroRepuesto(ByVal NumArticulo As Integer, ByVal Descripcion As String, ByVal CategoriaID As Integer, ByVal Serie As String, ByVal Modelo As String, ByVal Marca As String, ByVal PC_Procesador As String, ByVal PC_RAM As String, ByVal PC_HD As String, ByVal Fecha_Compra As Date, ByVal Fecha_FinalizaGarantia As Date, ByVal Costo As Decimal, ByVal Estado As String, ByVal EstadoAsignacion As String, ByVal FacturaCompra As String, ByVal Proveedor As String, ByVal Contacto As String, ByVal Ubicacion As String)

        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand
            'Guarda nueva marca

            Dim NumBita As Integer = 0
            Dim DtBita As New DataTable
            Dim QueryBita As String
            QueryBita = "SELECT MAX (Num) FROM It_Repuestos"
            Dim CMDQueryBita As New SqlCommand(QueryBita, ActualizarConexion)
            Dim AdaptadorBita As New SqlDataAdapter(CMDQueryBita)
            CMDQueryBita.Transaction = transaccion_sql
            AdaptadorBita.Fill(DtBita)

            If DtBita.Rows.Count > 0 Then
                If Not IsDBNull(DtBita.Rows(0)(0)) Then
                    NumBita = DtBita.Rows(0)(0)
                End If
            End If
            NumBita += 1
            miComando = New SqlCommand("INSERT INTO It_Repuestos " & _
            " (Num, Descripcion, CategoriaID, Serie, Modelo, Marca, PC_Procesador, PC_RAM, PC_HD, Estado) " & _
            " VALUES (@Num, @Descripcion, @CategoriaID, @Serie, @Modelo, @Marca, @PC_Procesador, @PC_RAM, @PC_HD, @Estado)", ActualizarConexion)
            miComando.Parameters.AddWithValue("@Num", NumBita)
            miComando.Parameters.AddWithValue("@Descripcion", Descripcion)
            miComando.Parameters.AddWithValue("@CategoriaID", CategoriaID)
            miComando.Parameters.AddWithValue("@Serie", Serie)
            miComando.Parameters.AddWithValue("@Modelo", Modelo)
            miComando.Parameters.AddWithValue("@Marca", Marca)
            miComando.Parameters.AddWithValue("@PC_Procesador", PC_Procesador)
            miComando.Parameters.AddWithValue("@PC_RAM", PC_RAM)
            miComando.Parameters.AddWithValue("@PC_HD", PC_HD)
            
            miComando.Parameters.AddWithValue("@Estado", Estado)
            
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
        End Try

    End Function

    Public Function VerRepuestos()
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT  dbo.It_Repuestos.Num, dbo.It_Repuestos.Descripcion, dbo.It_Cat.CategoriaNombre as 'Categoría', dbo.It_Repuestos.Serie, dbo.It_Repuestos.Modelo, dbo.It_Repuestos.Marca, " & _
        " dbo.It_Repuestos.PC_Procesador as Procesador, dbo.It_Repuestos.PC_RAM as RAM, dbo.It_Repuestos.PC_HD as 'Disco Duro', dbo.It_Repuestos.Estado " & _
        " FROM dbo.It_Cat INNER JOIN  dbo.It_Repuestos ON dbo.It_Cat.CategoriaId = dbo.It_Repuestos.CategoriaId", ActualizarConexion)

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


