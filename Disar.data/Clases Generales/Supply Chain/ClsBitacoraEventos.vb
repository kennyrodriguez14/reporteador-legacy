Imports Disar.data
Imports System.Data.SqlClient
Imports System.Text

Public Class ClsBitacoraEventos

    Dim Conexion As New clsConexion
    Dim Conexion2 As New clsConexion_Centro_Costos
    Dim Conexion3 As New clsconexion_bienesyrecursos
    Dim ConexionConsumo As New clsconexion_consumo
    Dim ConexionAgro As New clsconexion_sr_agro
    Dim ConexionSIP As New cls_conexion_sip
    Dim ConexionSIPDIMOSA As New cls_conexion_sip_dimosa

#Region "Bitacora de Eventos"

    Public Function MuestraTodosVehiculos()
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT VehiculoId, VehiculoDescripcion FROM Vehiculos_Entregadores UNION ALL SELECT '0' as VehiculoId, ' TODOS' as VehiculoDescripcion ORDER BY VehiculoDescripcion ASC", ActualizarConexion)
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

    Public Function MuestraTodasCategorias()
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT BECat_ID, BECat_Desc FROM BE_Cat UNION ALL SELECT 0 AS BECat_ID, ' TODAS' AS BeCatDesc ORDER BY BECat_Desc", ActualizarConexion)
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

    Public Function Categorias()
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT BECat_ID, BECat_Desc FROM BE_Cat UNION ALL SELECT 0 AS BECat_ID, ' NUEVA CATEGORIA' AS BeCatDesc ORDER BY BECat_Desc", ActualizarConexion)
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

    Public Function Vehiculos()
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT VehiculoId, VehiculoDescripcion FROM Vehiculos_Entregadores ORDER BY VehiculoDescripcion ASC", ActualizarConexion)
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

    Public Function NuevoEvento(ByVal Usuario As String, ByVal Categoria As String, ByVal CategoriaId As Integer, ByVal NuevaCategoria As String, ByVal Vehiculo As Integer, ByVal Obs As String, ByVal Fecha As Date, ByVal Herramientas As String, ByVal Costo As Decimal)

        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand
            'Guarda nueva marca

            If CategoriaId = 0 Then
                Dim OtraCategoria As Integer = 0

                Dim DtMarca As New DataTable
                Dim Query As String
                Query = "SELECT MAX (BECat_ID)  FROM BE_Cat"
                Dim CMDQuery As New SqlCommand(Query, ActualizarConexion)
                Dim Adaptador As New SqlDataAdapter(CMDQuery)
                CMDQuery.Transaction = transaccion_sql
                Adaptador.Fill(DtMarca)

                If DtMarca.Rows.Count > 0 Then
                    If Not IsDBNull(DtMarca.Rows(0)(0)) Then
                        OtraCategoria = DtMarca.Rows(0)(0)
                    End If
                End If
                CategoriaId = OtraCategoria + 1

                miComando = New SqlCommand("INSERT INTO Be_Cat" & _
                                        " (BECat_ID, BECat_Desc) " & _
                                        " VALUES (@BECat_ID, @BECat_Desc)", ActualizarConexion)
                miComando.Parameters.AddWithValue("@BECat_ID", CategoriaId)
                miComando.Parameters.AddWithValue("@BECat_Desc", NuevaCategoria)

                miComando.Transaction = transaccion_sql
                miComando.ExecuteNonQuery()

            End If

            Dim NumBita As Integer = 0
            Dim DtBita As New DataTable
            Dim QueryBita As String
            QueryBita = "SELECT MAX (BE_ID) FROM Be_Reg"
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
            miComando = New SqlCommand("INSERT INTO Be_Reg" & _
                                         " (BE_ID, VehiculoID, BE_CatID, BE_Fecha, BE_Observacion, BE_Usuario, BE_FechaAlmacenado,  HerramientasD, CostoAnomalia) " & _
                                         " VALUES (@BE_ID, @VehiculoID, @BE_CatID, @BE_Fecha, @BE_Observacion, @BE_Usuario, @BE_FechaAlmacenado,  @HerramientasD, @CostoAnomalia)", ActualizarConexion)
            miComando.Parameters.AddWithValue("@Be_ID", NumBita)
            miComando.Parameters.AddWithValue("@VehiculoID", Vehiculo)
            miComando.Parameters.AddWithValue("@BE_CatID", CategoriaId)
            miComando.Parameters.AddWithValue("@BE_Fecha", Fecha.Date)
            miComando.Parameters.AddWithValue("@BE_FechaAlmacenado", DateTime.Now)
            miComando.Parameters.AddWithValue("@BE_Observacion", Obs)
            miComando.Parameters.AddWithValue("@BE_Usuario", Usuario)
            miComando.Parameters.AddWithValue("@HerramientasD", Herramientas)
            miComando.Parameters.AddWithValue("@CostoAnomalia", Costo)

            miComando.Transaction = transaccion_sql
            miComando.ExecuteNonQuery()

            transaccion_sql.Commit()
            ActualizarConexion.Close()
            Return "Se ha guardado el registro con éxito"
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


    Public Function MuestraTodosEventos(ByVal Fecha1 As Date, ByVal Fecha2 As Date)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("  SELECT     TOP (100) PERCENT dbo.BE_Reg.BE_ID as Nº, dbo.BE_Reg.VehiculoID as 'Vehículo ID', dbo.Vehiculos_Entregadores.VehiculoDescripcion as 'Vehículo', dbo.BE_Reg.BE_CatID AS 'Categoría ID', " & _
                                           "   dbo.BE_Cat.BECat_Desc as 'Categoría', dbo.BE_Reg.BE_Fecha as 'Fecha', dbo.BE_Reg.BE_Observacion as 'Evento', HerramientasD as 'Herramientas dañadas', CostoAnomalia as 'Costo de anomalía', dbo.BE_Reg.BE_Usuario as 'Registrado Por'" & _
                                           "   FROM         dbo.Vehiculos_Entregadores INNER JOIN " & _
                                           " dbo.BE_Reg ON dbo.Vehiculos_Entregadores.VehiculoId = dbo.BE_Reg.VehiculoID INNER JOIN " & _
                                           " dbo.BE_Cat ON dbo.BE_Reg.BE_CatID = dbo.BE_Cat.BECat_ID WHERE dbo.BE_Reg.BE_Fecha >= @Fecha1 AND dbo.BE_Reg.BE_Fecha <= @Fecha2" & _
                                           " ORDER BY dbo.BE_Reg.BE_ID", ActualizarConexion)
        miComando.Parameters.AddWithValue("@Fecha1", Fecha1.Date)
        miComando.Parameters.AddWithValue("@Fecha2", Fecha2.Date)

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

    Public Function MuestraEventosCategoria(ByVal Par As Integer, ByVal Fecha1 As Date, ByVal Fecha2 As Date)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("  SELECT     TOP (100) PERCENT dbo.BE_Reg.BE_ID as Nº, dbo.BE_Reg.VehiculoID as 'Vehículo ID', dbo.Vehiculos_Entregadores.VehiculoDescripcion as 'Vehículo', dbo.BE_Reg.BE_CatID AS 'Categoría ID', " & _
                                           "   dbo.BE_Cat.BECat_Desc as 'Categoría', dbo.BE_Reg.BE_Fecha as 'Fecha', dbo.BE_Reg.BE_Observacion as 'Evento', HerramientasD as 'Herramientas dañadas', CostoAnomalia as 'Costo de anomalía', dbo.BE_Reg.BE_Usuario as 'Registrado Por'" & _
                                           "   FROM         dbo.Vehiculos_Entregadores INNER JOIN " & _
                                           " dbo.BE_Reg ON dbo.Vehiculos_Entregadores.VehiculoId = dbo.BE_Reg.VehiculoID INNER JOIN " & _
                                           " dbo.BE_Cat ON dbo.BE_Reg.BE_CatID = dbo.BE_Cat.BECat_ID WHERE dbo.BE_Reg.BE_CatID = @Par AND   dbo.BE_Reg.BE_Fecha >= @Fecha1 AND dbo.BE_Reg.BE_Fecha <= @Fecha2" & _
                                           " ORDER BY dbo.BE_Reg.BE_ID", ActualizarConexion)
        miComando.Parameters.AddWithValue("@Par", Par)
        miComando.Parameters.AddWithValue("@Fecha1", Fecha1.Date)
        miComando.Parameters.AddWithValue("@Fecha2", Fecha2.Date)
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

    Public Function MuestraEventosVehiculo(ByVal Par As Integer, ByVal Fecha1 As Date, ByVal Fecha2 As Date)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("  SELECT     TOP (100) PERCENT dbo.BE_Reg.BE_ID as Nº, dbo.BE_Reg.VehiculoID as 'Vehículo ID', dbo.Vehiculos_Entregadores.VehiculoDescripcion as 'Vehículo', dbo.BE_Reg.BE_CatID AS 'Categoría ID', " & _
                                           "   dbo.BE_Cat.BECat_Desc as 'Categoría', dbo.BE_Reg.BE_Fecha as 'Fecha', dbo.BE_Reg.BE_Observacion as 'Evento', HerramientasD as 'Herramientas dañadas', CostoAnomalia as 'Costo de anomalía', dbo.BE_Reg.BE_Usuario as 'Registrado Por'" & _
                                           "   FROM         dbo.Vehiculos_Entregadores INNER JOIN " & _
                                           " dbo.BE_Reg ON dbo.Vehiculos_Entregadores.VehiculoId = dbo.BE_Reg.VehiculoID INNER JOIN " & _
                                           " dbo.BE_Cat ON dbo.BE_Reg.BE_CatID = dbo.BE_Cat.BECat_ID WHERE dbo.BE_Reg.VehiculoID = @Par AND dbo.BE_Reg.BE_Fecha >= @Fecha1 AND dbo.BE_Reg.BE_Fecha <= @Fecha2" & _
                                           " ORDER BY dbo.BE_Reg.BE_ID", ActualizarConexion)
        miComando.Parameters.AddWithValue("@Par", Par)
        miComando.Parameters.AddWithValue("@Fecha1", Fecha1.Date)
        miComando.Parameters.AddWithValue("@Fecha2", Fecha2.Date)
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

    Public Function MuestraEventosVehiculoCat(ByVal ParV As Integer, ByVal ParC As Integer, ByVal Fecha1 As Date, ByVal Fecha2 As Date)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("  SELECT     TOP (100) PERCENT dbo.BE_Reg.BE_ID as Nº, dbo.BE_Reg.VehiculoID as 'Vehículo ID', dbo.Vehiculos_Entregadores.VehiculoDescripcion as 'Vehículo', dbo.BE_Reg.BE_CatID AS 'Categoría ID', " & _
                                           "   dbo.BE_Cat.BECat_Desc as 'Categoría', dbo.BE_Reg.BE_Fecha as 'Fecha', dbo.BE_Reg.BE_Observacion as 'Evento', HerramientasD as 'Herramientas dañadas', CostoAnomalia as 'Costo de anomalía', dbo.BE_Reg.BE_Usuario as 'Registrado Por'" & _
                                           "   FROM         dbo.Vehiculos_Entregadores INNER JOIN " & _
                                           " dbo.BE_Reg ON dbo.Vehiculos_Entregadores.VehiculoId = dbo.BE_Reg.VehiculoID INNER JOIN " & _
                                           " dbo.BE_Cat ON dbo.BE_Reg.BE_CatID = dbo.BE_Cat.BECat_ID WHERE dbo.BE_Reg.VehiculoID = @ParV AND dbo.BE_Reg.BE_CatID = @ParC AND   dbo.BE_Reg.BE_Fecha >= @Fecha1 AND dbo.BE_Reg.BE_Fecha <= @Fecha2 " & _
                                           " ORDER BY dbo.BE_Reg.BE_ID", ActualizarConexion)
        miComando.Parameters.AddWithValue("@ParV", ParV)
        miComando.Parameters.AddWithValue("@ParC", ParC)
        miComando.Parameters.AddWithValue("@Fecha1", Fecha1.Date)
        miComando.Parameters.AddWithValue("@Fecha2", Fecha2.Date)
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

#End Region

#Region "Centro de Mantenimiento"

    Public Function TodosVehiculosRep()
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT VehiculoId as 'Nº', VehiculoDescripcion as 'DESCRIPCIÓN' FROM Vehiculos_Entregadores WHERE Estado IS NOT NULL UNION ALL SELECT '0' as 'Nº', ' TODOS' as 'DESCRIPCIÓN'  ORDER BY VehiculoDescripcion ASC", ActualizarConexion)
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

    Public Function VehiculosRep()
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT VehiculoId as 'Nº', VehiculoDescripcion as 'DESCRIPCIÓN', Estado AS ESTADO, No_Placa AS PLACA, Marca AS MARCA, Modelo AS MODELO, Sucursal AS SUCURSAL, DisponibilidadM AS 'DISPONIBILIDAD MECÁNICA', DisponibilidadD AS 'DISPONIBILIDAD DISTRIBUCIÓN', VehiculoDef as OBS FROM Vehiculos_Entregadores WHERE Estado IS NOT NULL ORDER BY VehiculoDescripcion ASC", ActualizarConexion)
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

    Public Function VehiculosActivos()
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT VehiculoId as 'Nº', VehiculoDescripcion as 'DESCRIPCIÓN', Estado AS ESTADO, No_Placa AS PLACA, Marca AS MARCA, Modelo AS MODELO, Sucursal AS SUCURSAL, DisponibilidadM AS 'DISPONIBILIDAD MECÁNICA', DisponibilidadD AS 'DISPONIBILIDAD DISTRIBUCIÓN', VehiculoDef as OBS FROM Vehiculos_Entregadores WHERE Estado = 'Activo' ORDER BY VehiculoDescripcion ASC", ActualizarConexion)
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

    Public Function VehiculosActivosYNulos()
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT VehiculoId as 'Nº', VehiculoDescripcion as 'DESCRIPCIÓN', Estado AS ESTADO, No_Placa AS PLACA, Marca AS MARCA, Modelo AS MODELO, Sucursal AS SUCURSAL, DisponibilidadM AS 'DISPONIBILIDAD MECÁNICA', DisponibilidadD AS 'DISPONIBILIDAD DISTRIBUCIÓN', VehiculoDef as OBS FROM Vehiculos_Entregadores WHERE Estado = 'Activo' OR Estado IS NULL ORDER BY VehiculoDescripcion ASC", ActualizarConexion)
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

    Public Function VehiculosDispMecanica()
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT VehiculoId as 'Nº', VehiculoDescripcion as 'DESCRIPCIÓN', Estado AS ESTADO, No_Placa AS PLACA, Marca AS MARCA, Modelo AS MODELO, Sucursal AS SUCURSAL, DisponibilidadM AS 'DISPONIBILIDAD MECÁNICA', DisponibilidadD AS 'DISPONIBILIDAD DISTRIBUCIÓN', VehiculoDef as OBS FROM Vehiculos_Entregadores WHERE Estado IS NOT NULL AND  DisponibilidadM = 'Si' ORDER BY VehiculoDescripcion ASC ", ActualizarConexion)
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

    Public Function VehiculosDispDistrib()
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT VehiculoId as 'Nº', VehiculoDescripcion as 'DESCRIPCIÓN', Estado AS ESTADO, No_Placa AS PLACA, Marca AS MARCA, Modelo AS MODELO, Sucursal AS SUCURSAL, DisponibilidadM AS 'DISPONIBILIDAD MECÁNICA', DisponibilidadD AS 'DISPONIBILIDAD DISTRIBUCIÓN', VehiculoDef as OBS FROM Vehiculos_Entregadores WHERE Estado IS NOT NULL AND DisponibilidadD = 'Si' ORDER BY VehiculoDescripcion ASC  ", ActualizarConexion)
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

    Public Function BuscaVehiculosRep(ByVal VAR As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT VehiculoId as 'Nº', VehiculoDescripcion as 'DESCRIPCIÓN', Estado AS ESTADO, No_Placa AS PLACA, Marca AS MARCA, Modelo AS MODELO, Sucursal AS SUCURSAL, DisponibilidadM AS 'DISPONIBILIDAD MECÁNICA', DisponibilidadD AS 'DISPONIBILIDAD DISTRIBUCIÓN', VehiculoDef as OBS FROM Vehiculos_Entregadores WHERE VehiculoId = @VehiculoID ", ActualizarConexion)
        miComando.Parameters.AddWithValue("@VehiculoId", VAR)
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

    Public Function NuevoEventoProgramado(ByVal Usuario As String, ByVal Categoria As String, ByVal NuevaCategoria As String, ByVal Vehiculo As Integer, ByVal Obs As String, ByVal Fecha As Date, ByVal Duracion As String)

        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand
            'Guarda nueva marca

            If Categoria = "OTRO" Then
                Categoria = NuevaCategoria
            End If

            Dim NumBita As Integer = 0
            Dim DtBita As New DataTable
            Dim QueryBita As String
            QueryBita = "SELECT MAX (IdEvento) FROM VehiculoProgram"
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
            miComando = New SqlCommand("INSERT INTO VehiculoProgram " & _
                                         " (IDEvento, VehiculoID, VehiculoProgramacion, VehiculoFechaProgra, VehiculoFechaRegistro, Usuario, Estado, Tiempo, TipoEvento) " & _
                                         " VALUES (@IDEvento, @VehiculoID, @VehiculoProgramacion, @VehiculoFechaProgra, @VehiculoFechaRegistro, @Usuario, @Estado, @Tiempo, @TipoEvento)", ActualizarConexion)
            miComando.Parameters.AddWithValue("@IDEvento", NumBita)
            miComando.Parameters.AddWithValue("@VehiculoID", Vehiculo)
            miComando.Parameters.AddWithValue("@VehiculoProgramacion", Categoria)
            miComando.Parameters.AddWithValue("@VehiculoFechaProgra", Fecha.Date)
            miComando.Parameters.AddWithValue("@VehiculoFechaRegistro", DateTime.Now)
            miComando.Parameters.AddWithValue("@Usuario", Usuario)
            miComando.Parameters.AddWithValue("@Estado", "Pendiente")
            miComando.Parameters.AddWithValue("@Tiempo", Duracion)
            miComando.Parameters.AddWithValue("@TipoEvento", "Programado")

            miComando.Transaction = transaccion_sql
            miComando.ExecuteNonQuery()

            transaccion_sql.Commit()
            ActualizarConexion.Close()
            Return "Se ha guardado el registro con éxito"
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

    Public Function NuevoEventoProgramadoKilometraje(ByVal Usuario As String, ByVal Categoria As String, ByVal NuevaCategoria As String, ByVal Vehiculo As Integer, ByVal Obs As String, ByVal KM As Decimal, ByVal Duracion As String)

        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand
            'Guarda nueva marca

            If Categoria = "OTRO" Then
                Categoria = NuevaCategoria
            End If

            Dim NumBita As Integer = 0
            Dim DtBita As New DataTable
            Dim QueryBita As String
            QueryBita = "SELECT MAX (IdEvento) FROM VehiculoProgram"
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
            miComando = New SqlCommand("INSERT INTO VehiculoProgram " & _
                                         " (IDEvento, VehiculoID, VehiculoProgramacion, Kilometraje, VehiculoFechaRegistro, Usuario, Estado, Tiempo, TipoEvento) " & _
                                         " VALUES (@IDEvento, @VehiculoID, @VehiculoProgramacion, @Kilometraje, @VehiculoFechaRegistro, @Usuario, @Estado, @Tiempo, @TipoEvento)", ActualizarConexion)
            miComando.Parameters.AddWithValue("@IDEvento", NumBita)
            miComando.Parameters.AddWithValue("@VehiculoID", Vehiculo)
            miComando.Parameters.AddWithValue("@VehiculoProgramacion", Categoria)
            miComando.Parameters.AddWithValue("@Kilometraje", KM)
            miComando.Parameters.AddWithValue("@VehiculoFechaRegistro", DateTime.Now)
            miComando.Parameters.AddWithValue("@Usuario", Usuario)
            miComando.Parameters.AddWithValue("@Estado", "Pendiente")
            miComando.Parameters.AddWithValue("@Tiempo", Duracion)
            miComando.Parameters.AddWithValue("@TipoEvento", "Programado")

            miComando.Transaction = transaccion_sql
            miComando.ExecuteNonQuery()

            transaccion_sql.Commit()
            ActualizarConexion.Close()
            Return "Se ha guardado el registro con éxito"
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

    Public Function NuevoEventoNoProgramado(ByVal Usuario As String, ByVal Categoria As String, ByVal NuevaCategoria As String, ByVal Vehiculo As Integer, ByVal Obs As String, ByVal Fecha As Date, ByVal Duracion As String)

        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand
            'Guarda nueva marca

            If Categoria = "OTRO" Then
                Categoria = NuevaCategoria
            End If

            Dim NumBita As Integer = 0
            Dim DtBita As New DataTable
            Dim QueryBita As String
            QueryBita = "SELECT MAX (IdEvento) FROM VehiculoProgram"
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
            miComando = New SqlCommand("INSERT INTO VehiculoProgram " & _
                                         " (IDEvento, VehiculoID, VehiculoProgramacion, VehiculoFechaProgra, VehiculoFechaRegistro, Usuario, Estado, Tiempo, TipoEvento) " & _
                                         " VALUES (@IDEvento, @VehiculoID, @VehiculoProgramacion, @VehiculoFechaProgra, @VehiculoFechaRegistro, @Usuario, @Estado, @Tiempo, @TipoEvento)", ActualizarConexion)
            miComando.Parameters.AddWithValue("@IDEvento", NumBita)
            miComando.Parameters.AddWithValue("@VehiculoID", Vehiculo)
            miComando.Parameters.AddWithValue("@VehiculoProgramacion", Categoria)
            miComando.Parameters.AddWithValue("@VehiculoFechaProgra", Fecha.Date)
            miComando.Parameters.AddWithValue("@VehiculoFechaRegistro", DateTime.Now)
            miComando.Parameters.AddWithValue("@Usuario", Usuario)
            miComando.Parameters.AddWithValue("@Estado", "Completo")
            miComando.Parameters.AddWithValue("@Tiempo", Duracion)
            miComando.Parameters.AddWithValue("@TipoEvento", "No programado")

            miComando.Transaction = transaccion_sql
            miComando.ExecuteNonQuery()

            transaccion_sql.Commit()
            ActualizarConexion.Close()
            Return "Se ha guardado el registro con éxito"
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

    Public Function Eventos()
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT DISTINCT VehiculoProgramacion FROM VehiculoProgram UNION ALL SELECT 'OTRO' AS VehiculoProgramacion", ActualizarConexion)
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

    Public Function FiltraEventos(ByVal Vehiculo As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT IDEvento, VehiculoID, VehiculoProgramacion, VehiculoFechaProgra, VehiculoFechaRegistro, Usuario, Estado, Tiempo, Kilometraje FROM VehiculoProgram WHERE VehiculoID = @Vehiculo AND Estado = 'Pendiente' OR VehiculoID = @Vehiculo AND Estado = 'Pospuesto'", ActualizarConexion)
        miComando.Parameters.AddWithValue("@Vehiculo", Vehiculo)
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

    Public Function ActualizaEvento(ByVal ID As Integer, ByVal Estado As String)

        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        ActualizarConexion.Open()

        Dim query_inve As New StringBuilder
        query_inve.Append("UPDATE [Usuarios].[dbo].[VehiculoProgram] ")
        query_inve.Append("SET [Estado] = @Estado ")
        query_inve.Append("WHERE [IDEvento] = @IDEvento ")
        Dim comando_inve_salida As New SqlCommand(query_inve.ToString, ActualizarConexion)
        comando_inve_salida.Parameters.AddWithValue("@IDEvento", ID)
        comando_inve_salida.Parameters.AddWithValue("@Estado", Estado)

        Try
            comando_inve_salida.ExecuteNonQuery()
            Return "S"
        Catch ex As Exception
            Return ex.Message
        End Try

    End Function

    Public Function ActualizaVehiculo(ByVal ID As Integer, ByVal Estado As String, ByVal Mecanica As String, ByVal Distribucion As String, ByVal Coment As String)

        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        ActualizarConexion.Open()

        Dim query_inve As New StringBuilder
        query_inve.Append("UPDATE [Usuarios].[dbo].[Vehiculos_Entregadores] ")
        query_inve.Append("SET [Estado] = @Estado, [DisponibilidadM] = @DisponibilidadM, [DisponibilidadD] = @DisponibilidadD , [VehiculoDef] = @VehiculoDef ")
        query_inve.Append("WHERE [VehiculoId] = @VehiculoId ")
        Dim comando_inve_salida As New SqlCommand(query_inve.ToString, ActualizarConexion)
        comando_inve_salida.Parameters.AddWithValue("@VehiculoId", ID)
        comando_inve_salida.Parameters.AddWithValue("@Estado", Estado)

        comando_inve_salida.Parameters.AddWithValue("@DisponibilidadM", Mecanica)
        comando_inve_salida.Parameters.AddWithValue("@DisponibilidadD", Distribucion)
        comando_inve_salida.Parameters.AddWithValue("@VehiculoDef", Coment)

        Try
            comando_inve_salida.ExecuteNonQuery()
            Return "S"
        Catch ex As Exception
            Return ex.Message
        End Try

    End Function

    Public Function InfoVehiculo(ByVal VAR As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT VehiculoId as 'Nº', VehiculoDescripcion as 'DESCRIPCIÓN', Estado AS ESTADO, No_Placa AS PLACA, Marca AS MARCA, Modelo AS MODELO, Sucursal AS SUCURSAL, DisponibilidadM AS 'DISPONIBILIDAD MECÁNICA', DisponibilidadD AS 'DISPONIBILIDAD DISTRIBUCIÓN', VehiculoDef as OBS, VehiculoCapacidad, VehiculoMonto, CapacidadMaxima, Cubicaje, DeptoCC, NChasis, NMotor, NEncargado FROM Vehiculos_Entregadores WHERE VehiculoId = @VehiculoID ", ActualizarConexion)
        miComando.Parameters.AddWithValue("@VehiculoId", VAR)
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

    Public Function NuevasImagenes(ByVal Vehiculo As String, ByVal DESC As String, ByVal ItemGal As DataTable, ByVal Usuario As String)

        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand

            'Selecciona el último número de imagen guardado
            Dim Numero As Integer = 0
            For index As Integer = 0 To ItemGal.Rows.Count - 1
                Dim DtID As New DataTable
                Dim Query As String
                Query = "SELECT MAX (Im_ID) FROM Vehiculo_Det"
                Dim CMDQuery As New SqlCommand(Query, ActualizarConexion)
                Dim Adaptador As New SqlDataAdapter(CMDQuery)
                CMDQuery.Transaction = transaccion_sql
                Adaptador.Fill(DtID)

                If DtID.Rows.Count > 0 Then
                    If Not IsDBNull(DtID.Rows(0)(0)) Then
                        Numero = DtID.Rows(0)(0)
                    End If
                    Numero += 1
                End If

                Dim P As Integer = 0
                If index = 0 Then
                    P = 1
                Else
                    P = 0
                End If

                ' Inserta la imagen nueva
                miComando = New SqlCommand("INSERT INTO Vehiculo_Det" & _
                                           " (Im_ID, VehiculoID, VehiculoDesc, VehiculoDet, Princ)" & _
                                           " VALUES(@Im_ID, @VehiculoID, @VehiculoDesc, @VehiculoDet, @Princ)", ActualizarConexion)
                miComando.Parameters.AddWithValue("@Im_ID", Numero)
                miComando.Parameters.AddWithValue("@VehiculoID", Vehiculo)
                miComando.Parameters.AddWithValue("@VehiculoDesc", ItemGal(index)(1))
                miComando.Parameters.AddWithValue("@VehiculoDet", ItemGal(index)(0))
                
                miComando.Parameters.AddWithValue("@Princ", P)

                miComando.Transaction = transaccion_sql
                miComando.ExecuteNonQuery()
            Next
 
            transaccion_sql.Commit()
            ActualizarConexion.Close()
            Return "Se ha guardado el registro con éxito"

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

    Public Function MuestraGaleria(ByVal Vehiculo As String)

        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim sSQL As String = "SELECT Im_ID, VehiculoID, VehiculoDesc, VehiculoDet, Princ " & _
                      " FROM Vehiculo_Det Where VehiculoID = @VehiculoID"

        Dim Comando As New SqlCommand(sSQL, ActualizarConexion)
        Comando.Parameters.AddWithValue("@VehiculoID", Vehiculo)


        ActualizarConexion.Open()
        Dim AdaptadorDeDatos As New SqlDataAdapter(Comando)
        Dim ds As New DataSet
        Dim dv As New DataView

        Try
            AdaptadorDeDatos.Fill(ds, "Usuario")

            If ds.Tables("Usuario").Rows.Count > 0 Then
                dv = New DataView(ds.Tables("Usuario"))
            Else
            End If
            ActualizarConexion.Close()
        Catch ex As SqlException
            MsgBox("Hay un problema con la conexión a los datos " & ex.Message, MsgBoxStyle.Critical)
        End Try
        Return dv
    End Function

    Public Function ActualizaGaleria(ByVal Vehiculo As String, ByVal ID As Integer)

        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        ActualizarConexion.Open()

        Dim query_inve As New StringBuilder
        query_inve.Append("UPDATE [Usuarios].[dbo].[Vehiculo_Det] ")
        query_inve.Append("SET [Princ] = 0 ")
        query_inve.Append("WHERE [VehiculoID] = @VehiculoID AND Im_ID <> " & ID & "")
        Dim comando_inve_salida As New SqlCommand(query_inve.ToString, ActualizarConexion)
        comando_inve_salida.Parameters.AddWithValue("@IDEvento", ID)
 
        Try
            comando_inve_salida.ExecuteNonQuery()

        Catch ex As Exception
            Return ex.Message
        End Try

        Dim ActualizarConexion2 As New SqlConnection(Conexion.CadenaSQL())
        ActualizarConexion2.Open()

        Dim query_inve2 As New StringBuilder
        query_inve2.Append("UPDATE [Usuarios].[dbo].[Vehiculo_Det] ")
        query_inve2.Append("SET [Princ] = 1 ")
        query_inve2.Append("WHERE [VehiculoID] = @VehiculoID AND Im_ID = " & ID & "")
        Dim comando_inve_salida2 As New SqlCommand(query_inve2.ToString, ActualizarConexion)
        comando_inve_salida2.Parameters.AddWithValue("@IDEvento", ID)

        Try
            comando_inve_salida2.ExecuteNonQuery()
            Return "S"
        Catch ex As Exception
            Return ex.Message
        End Try

    End Function

    Public Function BorraImagen(ByVal ImagenID As Integer)

        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand

            miComando = New SqlCommand("DELETE FROM Vehiculo_Det" & _
                                         " WHERE Im_ID = @Im_ID " & _
                                         " ", ActualizarConexion)
            miComando.Parameters.AddWithValue("@Im_ID", ImagenID)


            miComando.Transaction = transaccion_sql
            miComando.ExecuteNonQuery()

            transaccion_sql.Commit()
            ActualizarConexion.Close()
            Return "S"

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

    Public Function ActualizaDescripcionGaleria(ByVal DESC As String, ByVal ID As Integer)

        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        ActualizarConexion.Open()

        Dim query_inve As New StringBuilder
        query_inve.Append("UPDATE [Usuarios].[dbo].[Vehiculo_Det] ")
        query_inve.Append("SET [VehiculoDesc] = @VehiculoDesc ")
        query_inve.Append("WHERE [Im_ID] = @Im_ID ")
        Dim comando_inve_salida As New SqlCommand(query_inve.ToString, ActualizarConexion)
        comando_inve_salida.Parameters.AddWithValue("@Im_ID", ID)
        comando_inve_salida.Parameters.AddWithValue("@VehiculoDesc", DESC)

        Try
            comando_inve_salida.ExecuteNonQuery()
            Return "S"
        Catch ex As Exception
            Return ex.Message
        End Try

    End Function

    Public Function FiltraTodosEventos(ByVal Vehiculo As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT IDEvento as 'Nº', VehiculoProgramacion as 'Evento', VehiculoFechaProgra as 'Fecha Programada', Tiempo, VehiculoFechaRegistro as 'Fecha Registro', Estado as Estado, Usuario FROM VehiculoProgram WHERE VehiculoID = @Vehiculo", ActualizarConexion)
        miComando.Parameters.AddWithValue("@Vehiculo", Vehiculo)
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

    '
    'Rep
    '

    Public Function ConceptosBusqueda()
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT  CONCEPTOID, CONCEPTODES  FROM CONCEPTOS_FLOTA UNION ALL SELECT '0' as CONCEPTOID, 'Todos' AS CONCEPTODES UNION ALL SELECT '10000' as CONCEPTOID, 'Gastos Caja Chica' as CONCEPTODES ORDER BY CONCEPTOID ASC", ActualizarConexion)

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

    Public Function CARGACOSTOS(ByVal Vehiculo As Integer, ByVal Concepto As Integer, ByVal Fecha1 As Date, ByVal Fecha2 As Date)
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim miComando As New SqlCommand("  SELECT     NUM_MOV AS 'Nº', PRODUCTO AS 'OBS', CANT AS 'CANTIDAD', COSTO_OPERADO AS 'COSTO TOTAL', CVE_CPTO AS 'Nº CONCEPTO', CONCEPTO, FECHA, " & _
                                        "  VEHICULOID AS 'VEHICULO', KMI AS 'KM INICIAL', KMF AS 'KM FINAL' " & _
                                        "  FROM         (SELECT     dbo.REG_MOVIMIENTOS_BIENESYRECURSOS.NUM_MOV, dbo.REG_MOVIMIENTOS_BIENESYRECURSOS.PRODUCTO,  " & _
                                        "  dbo.REG_MOVIMIENTOS_BIENESYRECURSOS.COSTO_OPERADO, SAE60Empre03.dbo.MINVE03.CANT, SAE60Empre03.dbo.MINVE03.COSTO,  " & _
                                        "  dbo.REG_MOVIMIENTOS_BIENESYRECURSOS.CVE_CPTO, dbo.CONCEPTOS_FLOTA.CONCEPTODES AS CONCEPTO, " & _
                                        "  dbo.REG_MOVIMIENTOS_BIENESYRECURSOS.FECHA, dbo.REG_MOVIMIENTOS_BIENESYRECURSOS.VEHICULOID,  " & _
                                        "  dbo.REG_MOVIMIENTOS_BIENESYRECURSOS.KMI, dbo.REG_MOVIMIENTOS_BIENESYRECURSOS.KMF " & _
                                        "  FROM          dbo.REG_MOVIMIENTOS_BIENESYRECURSOS INNER JOIN " & _
                                        "  dbo.CONCEPTOS_FLOTA ON dbo.CONCEPTOS_FLOTA.CONCEPTOID = dbo.REG_MOVIMIENTOS_BIENESYRECURSOS.CVE_CPTO LEFT OUTER JOIN " & _
                                        "  SAE60Empre03.dbo.MINVE03 ON SAE60Empre03.dbo.MINVE03.NUM_MOV = dbo.REG_MOVIMIENTOS_BIENESYRECURSOS.NUM_MOV " & _
                                        "  WHERE dbo.REG_MOVIMIENTOS_BIENESYRECURSOS.VEHICULOID > 0 " & _
                                        "  UNION ALL " & _
                                        "  SELECT     GASTOID AS NUM_MOV, OBSERVACION AS PRODUCTO, SUB_TOTAL + ISV_MONTO AS COSTO_OPERADO, '1' AS CANT, SUB_TOTAL + ISV_MONTO AS COSTO, '10000' AS CVE_CPTO,  " & _
                                        "  'Gastos Caja Chica' AS Expr1, FECHA, VEHICULO AS VEHICULOID, '' AS 'KM INICIAL', '' AS 'KM FINAL' " & _
                                        "  FROM dbo.REG_GASTOS_GENERALES " & _
                                        "  WHERE     VEHICULO > 0) AS A " & _
                                        "  WHERE VEHICULOID = @Vehiculo AND CVE_CPTO = @Concepto AND FECHA >= @Fecha1 AND FECHA <= @Fecha2", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Vehiculo", Vehiculo)
        miComando.Parameters.AddWithValue("@Concepto", Concepto)
        miComando.Parameters.AddWithValue("@Fecha1", Fecha1.Date)
        miComando.Parameters.AddWithValue("@Fecha2", Fecha2.Date)

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

    Public Function CARGACOSTOSTODOSVEHICULOS(ByVal Vehiculo As Integer, ByVal Concepto As Integer, ByVal Fecha1 As Date, ByVal Fecha2 As Date)
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim miComando As New SqlCommand("  SELECT     NUM_MOV AS 'Nº', PRODUCTO AS 'OBS', CANT AS 'CANTIDAD', COSTO_OPERADO AS 'COSTO TOTAL', CVE_CPTO AS 'Nº CONCEPTO', CONCEPTO, FECHA, " & _
                                        "  VEHICULOID AS 'VEHICULO', KMI AS 'KM INICIAL', KMF AS 'KM FINAL' " & _
                                        "  FROM         (SELECT     dbo.REG_MOVIMIENTOS_BIENESYRECURSOS.NUM_MOV, dbo.REG_MOVIMIENTOS_BIENESYRECURSOS.PRODUCTO,  " & _
                                        "  dbo.REG_MOVIMIENTOS_BIENESYRECURSOS.COSTO_OPERADO, SAE60Empre03.dbo.MINVE03.CANT, SAE60Empre03.dbo.MINVE03.COSTO,  " & _
                                        "  dbo.REG_MOVIMIENTOS_BIENESYRECURSOS.CVE_CPTO, dbo.CONCEPTOS_FLOTA.CONCEPTODES AS CONCEPTO, " & _
                                        "  dbo.REG_MOVIMIENTOS_BIENESYRECURSOS.FECHA, dbo.REG_MOVIMIENTOS_BIENESYRECURSOS.VEHICULOID,  " & _
                                        "  dbo.REG_MOVIMIENTOS_BIENESYRECURSOS.KMI, dbo.REG_MOVIMIENTOS_BIENESYRECURSOS.KMF " & _
                                        "  FROM          dbo.REG_MOVIMIENTOS_BIENESYRECURSOS INNER JOIN " & _
                                        "  dbo.CONCEPTOS_FLOTA ON dbo.CONCEPTOS_FLOTA.CONCEPTOID = dbo.REG_MOVIMIENTOS_BIENESYRECURSOS.CVE_CPTO LEFT OUTER JOIN " & _
                                        "  SAE60Empre03.dbo.MINVE03 ON SAE60Empre03.dbo.MINVE03.NUM_MOV = dbo.REG_MOVIMIENTOS_BIENESYRECURSOS.NUM_MOV " & _
                                        "  WHERE dbo.REG_MOVIMIENTOS_BIENESYRECURSOS.VEHICULOID > 0 " & _
                                        "  UNION ALL " & _
                                        "  SELECT     GASTOID AS NUM_MOV, OBSERVACION AS PRODUCTO, SUB_TOTAL + ISV_MONTO AS COSTO_OPERADO, '1' AS CANT, SUB_TOTAL + ISV_MONTO AS COSTO, '10000' AS CVE_CPTO,  " & _
                                        "  'Gastos Caja Chica' AS Expr1, FECHA, VEHICULO AS VEHICULOID, '' AS 'KM INICIAL', '' AS 'KM FINAL' " & _
                                        "  FROM dbo.REG_GASTOS_GENERALES " & _
                                        "  WHERE  VEHICULO > 0) AS A " & _
                                        "  WHERE  CVE_CPTO = @Concepto AND FECHA >= @Fecha1 AND FECHA <= @Fecha2 ORDER BY VEHICULOID, NUM_MOV", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Concepto", Concepto)
        miComando.Parameters.AddWithValue("@Fecha1", Fecha1.Date)
        miComando.Parameters.AddWithValue("@Fecha2", Fecha2.Date)

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

    Public Function CARGATODOSCOSTOS(ByVal Vehiculo As Integer, ByVal Fecha1 As Date, ByVal Fecha2 As Date)
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())

        Dim miComando As New SqlCommand("  SELECT     NUM_MOV AS 'Nº', PRODUCTO AS 'OBS', COSTO AS 'COSTO UNIDAD', CANT AS 'CANTIDAD', COSTO_OPERADO AS 'COSTO TOTAL', CVE_CPTO AS 'Nº CONCEPTO', CONCEPTO, FECHA, " & _
                                        "  VEHICULOID AS 'VEHICULO', KMI AS 'KM INICIAL', KMF AS 'KM FINAL' " & _
                                        "  FROM         (SELECT     dbo.REG_MOVIMIENTOS_BIENESYRECURSOS.NUM_MOV, dbo.REG_MOVIMIENTOS_BIENESYRECURSOS.PRODUCTO,  " & _
                                        "  dbo.REG_MOVIMIENTOS_BIENESYRECURSOS.COSTO_OPERADO, SAE60Empre03.dbo.MINVE03.CANT, SAE60Empre03.dbo.MINVE03.COSTO,  " & _
                                        "  dbo.REG_MOVIMIENTOS_BIENESYRECURSOS.CVE_CPTO, dbo.CONCEPTOS_FLOTA.CONCEPTODES AS CONCEPTO, " & _
                                        "  dbo.REG_MOVIMIENTOS_BIENESYRECURSOS.FECHA, dbo.REG_MOVIMIENTOS_BIENESYRECURSOS.VEHICULOID,  " & _
                                        "  dbo.REG_MOVIMIENTOS_BIENESYRECURSOS.KMI, dbo.REG_MOVIMIENTOS_BIENESYRECURSOS.KMF " & _
                                        "  FROM          dbo.REG_MOVIMIENTOS_BIENESYRECURSOS INNER JOIN " & _
                                        "  dbo.CONCEPTOS_FLOTA ON dbo.CONCEPTOS_FLOTA.CONCEPTOID = dbo.REG_MOVIMIENTOS_BIENESYRECURSOS.CVE_CPTO LEFT OUTER JOIN " & _
                                        "  SAE60Empre03.dbo.MINVE03 ON SAE60Empre03.dbo.MINVE03.NUM_MOV = dbo.REG_MOVIMIENTOS_BIENESYRECURSOS.NUM_MOV " & _
                                        "  WHERE dbo.REG_MOVIMIENTOS_BIENESYRECURSOS.VEHICULOID > 0 " & _
                                        "  UNION ALL " & _
                                        "  SELECT     GASTOID AS NUM_MOV, OBSERVACION AS PRODUCTO, SUB_TOTAL + ISV_MONTO AS COSTO_OPERADO, '1' AS CANT, SUB_TOTAL + ISV_MONTO AS COSTO, '10000' AS CVE_CPTO,  " & _
                                        "  'Gastos Caja Chica' AS Expr1, FECHA, VEHICULO AS VEHICULOID, '' AS 'KM INICIAL', '' AS 'KM FINAL' " & _
                                        "  FROM dbo.REG_GASTOS_GENERALES " & _
                                        "  WHERE  VEHICULO > 0) AS A " & _
                                        "  WHERE  VEHICULOID = @Vehiculo AND FECHA >= @Fecha1 AND FECHA <= @Fecha2", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Vehiculo", Vehiculo)
        miComando.Parameters.AddWithValue("@Fecha1", Fecha1.Date)
        miComando.Parameters.AddWithValue("@Fecha2", Fecha2.Date)


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

    Public Function CARGATODOSCOSTOSTODOSVEHICULOS(ByVal Fecha1 As Date, ByVal Fecha2 As Date)
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())

        Dim miComando As New SqlCommand("  SELECT     NUM_MOV AS 'Nº', PRODUCTO AS 'OBS', COSTO AS 'COSTO UNIDAD', CANT AS 'CANTIDAD', COSTO_OPERADO AS 'COSTO TOTAL', CVE_CPTO AS 'Nº CONCEPTO', CONCEPTO, FECHA, " & _
                                        "  VEHICULOID AS 'VEHICULO', KMI AS 'KM INICIAL', KMF AS 'KM FINAL' " & _
                                        "  FROM         (SELECT     dbo.REG_MOVIMIENTOS_BIENESYRECURSOS.NUM_MOV, dbo.REG_MOVIMIENTOS_BIENESYRECURSOS.PRODUCTO,  " & _
                                        "  dbo.REG_MOVIMIENTOS_BIENESYRECURSOS.COSTO_OPERADO, SAE60Empre03.dbo.MINVE03.CANT, SAE60Empre03.dbo.MINVE03.COSTO,  " & _
                                        "  dbo.REG_MOVIMIENTOS_BIENESYRECURSOS.CVE_CPTO, dbo.CONCEPTOS_FLOTA.CONCEPTODES AS CONCEPTO, " & _
                                        "  dbo.REG_MOVIMIENTOS_BIENESYRECURSOS.FECHA, dbo.REG_MOVIMIENTOS_BIENESYRECURSOS.VEHICULOID,  " & _
                                        "  dbo.REG_MOVIMIENTOS_BIENESYRECURSOS.KMI, dbo.REG_MOVIMIENTOS_BIENESYRECURSOS.KMF " & _
                                        "  FROM          dbo.REG_MOVIMIENTOS_BIENESYRECURSOS INNER JOIN " & _
                                        "  dbo.CONCEPTOS_FLOTA ON dbo.CONCEPTOS_FLOTA.CONCEPTOID = dbo.REG_MOVIMIENTOS_BIENESYRECURSOS.CVE_CPTO LEFT OUTER JOIN " & _
                                        "  SAE60Empre03.dbo.MINVE03 ON SAE60Empre03.dbo.MINVE03.NUM_MOV = dbo.REG_MOVIMIENTOS_BIENESYRECURSOS.NUM_MOV " & _
                                        "  WHERE dbo.REG_MOVIMIENTOS_BIENESYRECURSOS.VEHICULOID > 0 " & _
                                        "  UNION ALL " & _
                                        "  SELECT     GASTOID AS NUM_MOV, OBSERVACION AS PRODUCTO, SUB_TOTAL + ISV_MONTO AS COSTO_OPERADO, '1' AS CANT, SUB_TOTAL + ISV_MONTO AS COSTO, '10000' AS CVE_CPTO,  " & _
                                        "  'Gastos Caja Chica' AS Expr1, FECHA, VEHICULO AS VEHICULOID, '' AS 'KM INICIAL', '' AS 'KM FINAL' " & _
                                        "  FROM dbo.REG_GASTOS_GENERALES " & _
                                        "  WHERE  VEHICULO > 0) AS A " & _
                                        "  WHERE  FECHA >= @Fecha1 AND FECHA <= @Fecha2", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Fecha1", Fecha1.Date)
        miComando.Parameters.AddWithValue("@Fecha2", Fecha2.Date)


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

    Public Function FiltraTodosEventosFecha(ByVal Vehiculo As String, ByVal Fecha1 As Date, ByVal Fecha2 As Date)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT IDEvento as 'Nº', VehiculoProgramacion as 'Evento', VehiculoFechaProgra as 'Fecha Programada', Tiempo, VehiculoFechaRegistro as 'Fecha Registro', Estado as Estado, Usuario, TipoEvento as 'Tipo de Evento'  FROM VehiculoProgram WHERE VehiculoID = @Vehiculo AND " & _
                                        " VehiculoFechaProgra >= @Fecha1 And VehiculoFechaProgra <= @Fecha2", ActualizarConexion)
        miComando.Parameters.AddWithValue("@Vehiculo", Vehiculo)
        miComando.Parameters.AddWithValue("@Fecha1", Fecha1.Date)
        miComando.Parameters.AddWithValue("@Fecha2", Fecha2.Date)
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

    Public Function FiltraTodosEventosNoProgramadosFecha(ByVal Fecha1 As Date, ByVal Fecha2 As Date)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand(" SELECT IDEvento as 'Nº', VehiculoProgramacion as 'Evento', VehiculoFechaProgra as 'Fecha Programada', Tiempo, VehiculoFechaRegistro as 'Fecha Registro', Estado as Estado, Usuario, TipoEvento as 'Tipo de Evento' FROM VehiculoProgram WHERE TipoEvento = 'No Programado' AND " & _
                                        " VehiculoFechaProgra >= @Fecha1 And VehiculoFechaProgra <= @Fecha2", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Fecha1", Fecha1.Date)
        miComando.Parameters.AddWithValue("@Fecha2", Fecha2.Date)
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

    Public Function PUNTOREORDEN(ByVal Fecha1 As Date)
        Dim ActualizarConexion As New SqlConnection(Conexion3.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT CLAVE, REPUESTO, SUM(SALIDAS) AS 'SALIDAS ULTIMO MES', EXISTENCIAS, FCH_ULTCOM AS 'ULTIMA COMPRA' FROM " & _
                                        " (SELECT     dbo.INVE03.CVE_ART AS CLAVE, dbo.INVE03.DESCR AS REPUESTO, 0 AS SALIDAS, dbo.INVE03.EXIST AS EXISTENCIAS, FCH_ULTCOM " & _
                                        " FROM          dbo.INVE03 LEFT OUTER JOIN dbo.MINVE03 ON dbo.INVE03.CVE_ART = dbo.MINVE03.CVE_ART " & _
                                        " WHERE      (dbo.INVE03.CVE_ART > '30-088') AND MINVE03.FECHA_DOCU <= @FECHA1 GROUP BY dbo.INVE03.CVE_ART, dbo.INVE03.DESCR, dbo.INVE03.EXIST, FCH_ULTCOM " & _
                                        " UNION ALL SELECT     dbo.INVE03.CVE_ART AS CLAVE, dbo.INVE03.DESCR AS REPUESTO, SUM(dbo.MINVE03.CANT) AS SALIDAS, dbo.INVE03.EXIST AS EXISTENCIAS, FCH_ULTCOM " & _
                                        " FROM          dbo.INVE03 LEFT OUTER JOIN dbo.MINVE03 ON dbo.INVE03.CVE_ART = dbo.MINVE03.CVE_ART WHERE      (dbo.INVE03.CVE_ART > '30-088' AND FECHA_DOCU >= @FECHA AND MINVE03.FECHA_DOCU <= @Fecha1) " & _
                                        " GROUP BY dbo.INVE03.CVE_ART, dbo.INVE03.DESCR, dbo.INVE03.EXIST, FCH_ULTCOM " & _
                                        " ) AS A  GROUP BY CLAVE, REPUESTO, EXISTENCIAS, FCH_ULTCOM", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Fecha", DateAdd(DateInterval.Month, -1, Fecha1.Date))
        miComando.Parameters.AddWithValue("@Fecha1", Fecha1.Date)

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

    Public Function DisponibilidadDistribucionConsumo(ByVal Fecha As Date, ByVal Vehiculo As String)
        Dim ActualizarConexion As New SqlConnection(ConexionConsumo.CadenaSQL())
        Dim miComando As New SqlCommand(" SELECT DISTINCT FECHA_DOC, 'ENTREGAS CONSUMO' AS 'DESC' FROM FACTF05 " & _
                                        " WHERE (FECHA_ENT = @Fecha) AND (CVE_PEDI = @Vehiculo)", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Vehiculo", Vehiculo)
        miComando.Parameters.AddWithValue("@Fecha", Fecha.Date)

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

    Public Function DisponibilidadDistribucionAgro(ByVal Fecha As Date, ByVal Vehiculo As String)
        Dim ActualizarConexion As New SqlConnection(ConexionAgro.CadenaSQL())
        Dim miComando As New SqlCommand(" SELECT DISTINCT FECHA_DOC, 'ENTREGAS SR AGRO' AS 'DESC' FROM FACTF02 " & _
                                        " WHERE (FECHA_ENT = @Fecha) AND (CVE_PEDI = @Vehiculo)", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Vehiculo", Vehiculo)
        miComando.Parameters.AddWithValue("@Fecha", Fecha.Date)

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

    Public Function DisponibilidadDistribucionRemisiones(ByVal Fecha As Date, ByVal Vehiculo As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand(" SELECT DISTINCT FECHA_INICIO, 'REMISIONES' AS 'DESC' FROM         GUIA_REMISION_ENCABEZADO " & _
                                        " WHERE     (FECHA_INICIO = @Fecha) AND (VEHICULO = @Vehiculo)", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Vehiculo", Vehiculo)
        miComando.Parameters.AddWithValue("@Fecha", Fecha.Date)

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

    Public Function NCARGAKILOMETRAJE(ByVal Vehiculo As Integer)
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim miComando As New SqlCommand(" SELECT TOP (1) VEHICULOID, KMF " & _
                                        " FROM REG_MOVIMIENTOS_BIENESYRECURSOS " & _
                                        " WHERE (KMF IS NOT NULL) AND (KMF > 0) AND VEHICULOID = @Vehiculo " & _
                                        " ORDER BY FECHA DESC ", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Vehiculo", Vehiculo)

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

    ''''
    'Mec
    ''''

    Public Function NuevoEnvioTaller(ByVal Vehiculo As String, ByVal Fecha1 As Date, ByVal Fecha2 As Date, ByVal Continuado As String, ByVal Texto As String)

        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand

            Dim NumBita As Integer = 0
            Dim DtBita As New DataTable
            Dim QueryBita As String
            QueryBita = "SELECT MAX (ID) FROM Vehiculo_DispMecanica"
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
            miComando = New SqlCommand("INSERT INTO Vehiculo_DispMecanica " & _
                                         " (ID, Vehiculo, FechaInicio, FechaFinal, Continuado, Descripcion) " & _
                                         " VALUES (@ID, @Vehiculo, @FechaInicio, @FechaFinal, @Continuado, @Descripcion)", ActualizarConexion)
            miComando.Parameters.AddWithValue("@ID", NumBita)
            miComando.Parameters.AddWithValue("@Vehiculo", Vehiculo)
            miComando.Parameters.AddWithValue("@FechaInicio", Fecha1.Date)
            If Continuado = "S" Then
                miComando.Parameters.AddWithValue("@FechaFinal", DateAdd(DateInterval.Year, 1000, Fecha1.Date))
            Else
                miComando.Parameters.AddWithValue("@FechaFinal", Fecha2.Date)
            End If

            miComando.Parameters.AddWithValue("@Continuado", Continuado)
            miComando.Parameters.AddWithValue("@Descripcion", Texto)

            miComando.Transaction = transaccion_sql
            miComando.ExecuteNonQuery()

            transaccion_sql.Commit()
            ActualizarConexion.Close()
            Return "Se ha guardado el registro con éxito"
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

    Public Function ModificaEnvioTaller(ByVal Fecha2 As Date, ByVal TALL As Integer)

        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand

            miComando = New SqlCommand("UPDATE Vehiculo_DispMecanica " & _
                                         " SET  Continuado = 'N', FechaFinal = @FechaFinal  " & _
                                         " WHERE ID = @ID", ActualizarConexion)

            miComando.Parameters.AddWithValue("@ID", TALL)
            miComando.Parameters.AddWithValue("@FechaFinal", Fecha2.Date)

            miComando.Transaction = transaccion_sql
            miComando.ExecuteNonQuery()

            transaccion_sql.Commit()
            ActualizarConexion.Close()
            Return "Se ha guardado el registro con éxito"
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

    Public Function VerTallerRegistrado(ByVal Vehiculo As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT TOP (1) ID, Vehiculo, FechaInicio, FechaFinal, Continuado, Descripcion FROM " & _
                                         " Vehiculo_DispMecanica WHERE Vehiculo = @Vehiculo AND Continuado = 'S' ORDER BY ID DESC ", ActualizarConexion)
        miComando.Parameters.AddWithValue("@Vehiculo", Vehiculo)


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

    Public Function ReporteMecanica(ByVal Vehiculo As String, ByVal Fecha As Date)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand(" SELECT ID, Vehiculo, FechaInicio, FechaFinal, Continuado, Descripcion FROM " & _
                                         " Vehiculo_DispMecanica WHERE Vehiculo = @Vehiculo AND @Fecha >= FechaInicio AND @Fecha <= FechaFinal ORDER BY ID DESC", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Vehiculo", Vehiculo)
        miComando.Parameters.AddWithValue("@Fecha", Fecha)


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

    Public Function ActualizaDatosVeh(ByVal Vehiculo As String, ByVal Motor As String, ByVal Chasis As String, ByVal Encargado As String, ByVal Usuario As String)

        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        ActualizarConexion.Open()

        Dim query_inve As New StringBuilder
        query_inve.Append("UPDATE [Usuarios].[dbo].[Vehiculos_Entregadores] ")
        query_inve.Append("SET [NChasis] = @NChasis, [NMotor] = @NMotor, [NEncargado] = @NEncargado ")
        query_inve.Append("WHERE [VehiculoId] = @VehiculoId  ")

        Dim comando_inve_salida As New SqlCommand(query_inve.ToString, ActualizarConexion)

        comando_inve_salida.Parameters.AddWithValue("@NChasis", Chasis)
        comando_inve_salida.Parameters.AddWithValue("@NMotor", Motor)
        comando_inve_salida.Parameters.AddWithValue("@NEncargado", Encargado)
        comando_inve_salida.Parameters.AddWithValue("@VehiculoId", Vehiculo)

        Dim conexion_bita As New cls_bitacora_reporteador
        conexion_bita.RegistraBitacora(Now, Usuario, "Actualizó datos de vehículo " & Vehiculo, "Supply Chain", _
                                  " Datos = Encargado:" & Encargado & " Motor:" & Motor & " Chasis:" & Chasis)

        Try
            comando_inve_salida.ExecuteNonQuery()
            Return "S"
        Catch ex As Exception
            Return ex.Message
        End Try

    End Function

#End Region

#Region "Ruta Lógica de Entrega"

    Public Function Entregadores()
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT EntregadorCodigo as Codigo, EntregadorNombre as Nombre FROM Entregadores ORDER BY EntregadorNombre ASC", ActualizarConexion)
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

    Public Function RClientesRuta(ByVal Entregador As String, ByVal Fecha As Date)
        Dim ActualizarConexion As New SqlConnection(ConexionSIP.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT dbo.PEDI02.CVE_CLIE, dbo.LOTES.LOTE_ID, SAE60Empre05.dbo.CLIE05.NOMBRE, SAE60Empre05.dbo.CLIE_CLIB05.CAMPLIB14, " & _
                                        " SAE60Empre05.dbo.CLIE_CLIB05.CAMPLIB15, Lotes.LOTE_ALMACEN AS ALMACEN, CALLE  FROM dbo.PEDI02 INNER JOIN " & _
                                        " dbo.LOTES ON dbo.PEDI02.LOTE = dbo.LOTES.LOTE_ID INNER JOIN  SAE60Empre05.dbo.CLIE05 ON SAE60Empre05.dbo.CLIE05.CLAVE COLLATE MODERN_SPANISH_CI_AS = dbo.PEDI02.CVE_CLIE INNER JOIN " & _
                                        " SAE60Empre05.dbo.CLIE_CLIB05 ON SAE60Empre05.dbo.CLIE_CLIB05.CVE_CLIE = SAE60Empre05.dbo.CLIE05.CLAVE WHERE dbo.LOTES.LOTE_ENTREGADORID = @Entregador AND Lotes.LOTE_FECHA_FACT = @Fecha", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Entregador", Entregador)
        miComando.Parameters.AddWithValue("@Fecha", Fecha.Date)

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

    Public Function RClientesRutaDIMOSA(ByVal Entregador As String, ByVal Fecha As Date)
        Dim ActualizarConexion As New SqlConnection(ConexionSIPDIMOSA.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT dbo.PEDI02.CVE_CLIE, dbo.LOTES.LOTE_ID, SAE60Empre06.dbo.CLIE06.NOMBRE, SAE60Empre06.dbo.CLIE_CLIB06.CAMPLIB14, " & _
                                        " SAE60Empre06.dbo.CLIE_CLIB06.CAMPLIB15, Lotes.LOTE_ALMACEN AS ALMACEN, CALLE  FROM dbo.PEDI02 INNER JOIN " & _
                                        " dbo.LOTES ON dbo.PEDI02.LOTE = dbo.LOTES.LOTE_ID INNER JOIN  SAE60Empre06.dbo.CLIE06 ON SAE60Empre06.dbo.CLIE06.CLAVE COLLATE MODERN_SPANISH_CI_AS = dbo.PEDI02.CVE_CLIE INNER JOIN " & _
                                        " SAE60Empre06.dbo.CLIE_CLIB06 ON SAE60Empre06.dbo.CLIE_CLIB06.CVE_CLIE = SAE60Empre06.dbo.CLIE06.CLAVE WHERE dbo.LOTES.LOTE_ENTREGADORID = @Entregador AND Lotes.LOTE_FECHA_FACT = @Fecha", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Entregador", Entregador)
        miComando.Parameters.AddWithValue("@Fecha", Fecha.Date)

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

    Public Function RClientesDIMOSA(ByVal Entregador As String, ByVal Fecha As Date)
        Dim ActualizarConexion As New SqlConnection(ConexionSIPDIMOSA.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT dbo.PEDI02.CVE_CLIE, dbo.LOTES.LOTE_ID, SAE60Empre06.dbo.CLIE06.NOMBRE, SAE60Empre06.dbo.CLIE_CLIB06.CAMPLIB14, " & _
                                        " SAE60Empre06.dbo.CLIE_CLIB06.CAMPLIB15, Lotes.LOTE_ALMACEN AS ALMACEN, CALLE  FROM dbo.PEDI02 INNER JOIN " & _
                                        " dbo.LOTES ON dbo.PEDI02.LOTE = dbo.LOTES.LOTE_ID INNER JOIN  SAE60Empre06.dbo.CLIE06 ON SAE60Empre06.dbo.CLIE06.CLAVE COLLATE MODERN_SPANISH_CI_AS = dbo.PEDI02.CVE_CLIE INNER JOIN " & _
                                        " SAE60Empre06.dbo.CLIE_CLIB06 ON SAE60Empre06.dbo.CLIE_CLIB06.CVE_CLIE = SAE60Empre06.dbo.CLIE06.CLAVE WHERE dbo.LOTES.LOTE_ENTREGADORID = @Entregador AND Lotes.LOTE_FECHA_FACT = @Fecha", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Entregador", Entregador)
        miComando.Parameters.AddWithValue("@Fecha", Fecha.Date)

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

    Public Function RClientesPorFecha(ByVal Fecha As Date)
        Dim ActualizarConexion As New SqlConnection(ConexionSIP.CadenaSQL())
        Dim miComando As New SqlCommand(" SELECT     dbo.PEDI02.CVE_CLIE, SAE60Empre05.dbo.CLIE05.NOMBRE, SAE60Empre05.dbo.CLIE05.CALLE, SAE60Empre05.dbo.CLIE_CLIB05.CAMPLIB14, " & _
                                        " SAE60Empre05.dbo.CLIE_CLIB05.CAMPLIB15 " & _
                                        " FROM         dbo.PEDI02 INNER JOIN " & _
                                        " SAE60Empre05.dbo.CLIE_CLIB05 ON SAE60Empre05.dbo.CLIE_CLIB05.CVE_CLIE COLLATE MODERN_SPANISH_CI_AS = dbo.PEDI02.CVE_CLIE INNER JOIN " & _
                                        " SAE60Empre05.dbo.CLIE05 ON SAE60Empre05.dbo.CLIE05.CLAVE COLLATE MODERN_SPANISH_CI_AS = dbo.PEDI02.CVE_CLIE " & _
                                        " WHERE (dbo.PEDI02.FECHA = @Fecha)", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Fecha", Fecha.Date)

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

#End Region

#Region "Solicitudes de Manteminiento"

    Public Function sObtieneCorreo(ByVal User As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT Correo FROM [User] WHERE USUARIONICK = @User", ActualizarConexion)

        miComando.Parameters.AddWithValue("@User", User)

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

    Public Function sObtieneCorreosMantenimiento(ByVal Tipo As String, ByVal Almacen As Integer)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT CorreoMantenimiento, CorreoTipo FROM Correos_Mantenimiento WHERE Almacen = @Almacen and Tipo = @Tipo", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Tipo", Tipo)
        miComando.Parameters.AddWithValue("@Almacen", Almacen)

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

    Public Function SMuestraSolicitudes(ByVal Fecha1 As Date, ByVal Fecha2 As Date, ByVal Usuario As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim micomando  

        If Usuario = "Administrador" Or Usuario = "cesar.caballero" Or Usuario = "aron.castillo" Then
            micomando = New SqlCommand("SELECT Solicitud, CASE Vehiculo WHEN 1000 THEN 'General' ELSE Vehiculo END AS 'Vehículo/Tipo',  SolicitudDescripcion as 'Descripción', Fecha, SolicitudUsuario as Usuario, SolicitudEstado as Estado, SolicitudA as 'Enviado a', FechaRevision as 'Fecha de Revisión', FechaVerificacion as 'Fecha de Verificación' FROM SolicitudesMantenimiento WHERE Fecha >= @FechaInicio And Fecha <= @FechaFin ", ActualizarConexion)
        Else
            micomando = New SqlCommand("SELECT Solicitud, CASE Vehiculo WHEN 1000 THEN 'General' ELSE Vehiculo END AS 'Vehículo/Tipo',  SolicitudDescripcion as 'Descripción', Fecha, SolicitudUsuario as Usuario, SolicitudEstado as Estado, SolicitudA as 'Enviado a', FechaRevision as 'Fecha de Revisión', FechaVerificacion as 'Fecha de Verificación' FROM SolicitudesMantenimiento WHERE Fecha >= @FechaInicio And Fecha <= @FechaFin AND SolicitudUsuario = @Usuario OR SolicitudEstado = 'Completa' AND SolicitudUsuario = @Usuario", ActualizarConexion)
        End If

        miComando.Parameters.AddWithValue("@FechaInicio", Fecha1.Date)
        miComando.Parameters.AddWithValue("@FechaFin", Fecha2.Date)
        miComando.Parameters.AddWithValue("@Usuario", Usuario)

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

    Public Function SMuestraSolicitudesUsuarioCompletas(ByVal Usuario As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim micomando


        micomando = New SqlCommand("SELECT Solicitud,  Vehiculo  'Vehículo',  SolicitudDescripcion as 'Descripción', Fecha, SolicitudUsuario as Usuario, SolicitudEstado as Estado, SolicitudA as 'Enviado a', FechaRevision as 'Fecha de Revisión', FechaVerificacion as 'Fecha de Verificación' FROM SolicitudesMantenimiento WHERE SolicitudEstado = 'Completa' AND SolicitudUsuario = @Usuario", ActualizarConexion)

 
        micomando.Parameters.AddWithValue("@Usuario", Usuario)

        ActualizarConexion.Open()
        Dim AdaptadorDeDatos As New SqlDataAdapter(micomando)
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

    Public Function SMuestraImagen(ByVal Solicitud As Integer)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT  Solicitud, Vehiculo, Entregador, Fecha, SolicitudDescripcion, SolicitudImagen, SolicitudUsuario, SolicitudEstado, SolicitudA, FechaRevision, FechaVerificacion FROM SolicitudesMantenimiento WHERE Solicitud = @Solicitud", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Solicitud", Solicitud)

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

    Public Function SNuevoEvento(ByVal Vehiculo As String, ByVal Entregador As Integer, ByVal Fecha As Date, ByVal Descripcion As String, ByVal Imagen As Byte(), ByVal Usuario As String, ByVal Enviado As String)


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
            QueryBita = "SELECT MAX (Solicitud) FROM SolicitudesMantenimiento"
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
            miComando = New SqlCommand("INSERT INTO SolicitudesMantenimiento" & _
                                         " (Solicitud, Vehiculo, Entregador, Fecha, SolicitudDescripcion, SolicitudImagen, SolicitudUsuario, SolicitudEstado, SolicitudA) " & _
                                         " VALUES (@Solicitud, @Vehiculo, @Entregador, @Fecha, @SolicitudDescripcion, @SolicitudImagen, @SolicitudUsuario, @SolicitudEstado, @SolicitudA)", ActualizarConexion)
            miComando.Parameters.AddWithValue("@Solicitud", NumBita)
            miComando.Parameters.AddWithValue("@Vehiculo", Vehiculo)
            miComando.Parameters.AddWithValue("@Entregador", Entregador)
            miComando.Parameters.AddWithValue("@Fecha", Fecha.Date)
            miComando.Parameters.AddWithValue("@SolicitudDescripcion", Descripcion)
            miComando.Parameters.AddWithValue("@SolicitudImagen", Imagen)
            miComando.Parameters.AddWithValue("@SolicitudUsuario", Usuario)
            miComando.Parameters.AddWithValue("@SolicitudEstado", "Pendiente")
            miComando.Parameters.AddWithValue("@SolicitudA", Enviado)

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

    Public Function SNuevoEventoModuloLiquidaciones(ByVal Vehiculo As String, ByVal Entregador As Integer, ByVal Fecha As Date, ByVal Descripcion As String, ByVal Imagen As Byte(), ByVal Usuario As String, ByVal Enviado As String, ByVal Tipo As String)


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
            QueryBita = "SELECT MAX (Solicitud) FROM SolicitudesMantenimiento"
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
            miComando = New SqlCommand("INSERT INTO SolicitudesMantenimiento" & _
                                         " (Solicitud, Vehiculo, Entregador, Fecha, SolicitudDescripcion, SolicitudImagen, SolicitudUsuario, SolicitudEstado, SolicitudA) " & _
                                         " VALUES (@Solicitud, @Vehiculo, @Entregador, @Fecha, @SolicitudDescripcion, @SolicitudImagen, @SolicitudUsuario, @SolicitudEstado, @SolicitudA)", ActualizarConexion)

            miComando.Parameters.AddWithValue("@Solicitud", NumBita)
            miComando.Parameters.AddWithValue("@Vehiculo", Vehiculo)
            miComando.Parameters.AddWithValue("@Entregador", Entregador)
            miComando.Parameters.AddWithValue("@Fecha", Fecha.Date)
            miComando.Parameters.AddWithValue("@SolicitudDescripcion", Descripcion)
            miComando.Parameters.AddWithValue("@SolicitudImagen", Imagen)
            miComando.Parameters.AddWithValue("@SolicitudUsuario", Usuario)
            miComando.Parameters.AddWithValue("@SolicitudA", Enviado)
            miComando.Parameters.AddWithValue("@SolicitudEstado", "Pendiente")



            miComando.Transaction = transaccion_sql
            miComando.ExecuteNonQuery()



            miComando = New SqlCommand("INSERT INTO   Liq_Quejas_Reclamos" & _
                                         " (Descripcion, EnviadoA, Estado, Fecha) " & _
                                         " VALUES (@Descripcion, @Enviado, @Estado, @Fecha)", ActualizarConexion)

            miComando.Parameters.AddWithValue("@Descripcion", Descripcion)
            miComando.Parameters.AddWithValue("@Entregador", Entregador)
            miComando.Parameters.AddWithValue("@Fecha", Fecha.Date)
            miComando.Parameters.AddWithValue("@Enviado", Enviado)
            miComando.Parameters.AddWithValue("@Estado", Tipo)

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

    Public Function SNuevaQuejaModuloLiquidaciones(ByVal Vehiculo As String, ByVal Entregador As Integer, ByVal Fecha As Date, ByVal Descripcion As String, ByVal Imagen As Byte(), ByVal Usuario As String, ByVal Enviado As String, ByVal Tipo As String)


        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand
            'Guarda nueva marca

            miComando = New SqlCommand("INSERT INTO   Liq_Quejas_Reclamos" & _
                                         " (Descripcion, EnviadoA, Estado, Fecha) " & _
                                         " VALUES (@Descripcion, @EnviadoA, @Estado, @Fecha)", ActualizarConexion)

            miComando.Parameters.AddWithValue("@Descripcion", Descripcion)
            miComando.Parameters.AddWithValue("@Entregador", Entregador)
            miComando.Parameters.AddWithValue("@Fecha", Fecha.Date)
            miComando.Parameters.AddWithValue("@EnviadoA", Enviado)
            miComando.Parameters.AddWithValue("@Estado", Tipo)

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

    Public Function SMuestraSolicitudesVehiculo(ByVal Vehiculo As String, ByVal Estado As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT Solicitud, Vehiculo, Entregador, SolicitudDescripcion as 'Descripción', Fecha,  SolicitudUsuario as Usuario, SolicitudEstado as Estado, SolicitudA as 'Enviado a', FechaRevision as 'Fecha de Revisión', FechaVerificacion as 'Fecha de Verificación' FROM SolicitudesMantenimiento WHERE Vehiculo = @Vehiculo And SolicitudEstado <> 'Verificada'", ActualizarConexion)
        miComando.Parameters.AddWithValue("@Vehiculo", Vehiculo)

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

    Public Function SActualizaEv(ByVal Estado As String, ByVal ID As Integer, ByVal FechaRevision As Date, ByVal FechaVerificacion As Date)

        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        ActualizarConexion.Open()

        Dim query_inve As New StringBuilder

        If Estado = "Completa" Then
            query_inve.Append("UPDATE [Usuarios].[dbo].[SolicitudesMantenimiento] ")
            query_inve.Append("SET [SolicitudEstado] = @SolicitudEstado, [FechaRevision] = @FechaRevision  ")
            query_inve.Append("WHERE [Solicitud] = @Solicitud  ")
        Else
            query_inve.Append("UPDATE [Usuarios].[dbo].[SolicitudesMantenimiento] ")
            query_inve.Append("SET [SolicitudEstado] = @SolicitudEstado,  [FechaVerificacion] = @FechaVerificacion ")
            query_inve.Append("WHERE [Solicitud] = @Solicitud  ")
        End If

        Dim comando_inve_salida As New SqlCommand(query_inve.ToString, ActualizarConexion)

        If Estado = "Completa" Then
            comando_inve_salida.Parameters.AddWithValue("@Solicitud", ID)
            comando_inve_salida.Parameters.AddWithValue("@SolicitudEstado", Estado)
            comando_inve_salida.Parameters.AddWithValue("@FechaRevision", FechaRevision.Date)
        Else
            comando_inve_salida.Parameters.AddWithValue("@Solicitud", ID)
            comando_inve_salida.Parameters.AddWithValue("@SolicitudEstado", Estado)
            comando_inve_salida.Parameters.AddWithValue("@FechaVerificacion", FechaVerificacion.Date)
        End If
         
        Try
            comando_inve_salida.ExecuteNonQuery()
            Return "S"
        Catch ex As Exception
            Return ex.Message
        End Try

    End Function

    Public Function SMuestraSolicitudesNoVehiculares()
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT Solicitud, 'General' As 'Tipo', SolicitudDescripcion as 'Descripción', Fecha, SolicitudUsuario as Usuario, SolicitudEstado as Estado, SolicitudA as 'Enviado a', FechaRevision as 'Fecha de Revisión', FechaVerificacion as 'Fecha de Verificación' FROM SolicitudesMantenimiento WHERE Vehiculo = 1000 AND SolicitudEstado <> 'VERIFICADA' ", ActualizarConexion)


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

    Public Function SMuestraSolicitudesNoVehicularesRango(ByVal Fecha1 As Date, ByVal Fecha2 As Date)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT Solicitud, CASE Vehiculo WHEN 1000 THEN 'General' ELSE Vehiculo END AS 'Vehículo/Tipo',  SolicitudDescripcion as 'Descripción', Fecha, SolicitudUsuario as Usuario, SolicitudEstado as Estado, SolicitudA as 'Enviado a', FechaRevision as 'Fecha de Revisión', FechaVerificacion as 'Fecha de Verificación' FROM SolicitudesMantenimiento WHERE Fecha >= @FechaInicio And Fecha <= @FechaFin AND Vehiculo = 1000 OR Vehiculo = 1000 AND SolicitudESTADO = 'Pendiente'", ActualizarConexion)
        miComando.Parameters.AddWithValue("@FechaInicio", Fecha1.Date)
        miComando.Parameters.AddWithValue("@FechaFin", Fecha2.Date)

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

    Public Function SPENDIENTES(ByVal Busca As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT COUNT(Solicitud) AS Cantidad FROM SolicitudesMantenimiento WHERE (SolicitudEstado = @SolicitudEstado) ", ActualizarConexion)

        miComando.Parameters.AddWithValue("@SolicitudEstado", Busca)

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
     
#End Region

#Region "Viajes en Vehículo"

    Public Function VMuestraViajes(ByVal Fecha1 As Date, ByVal Fecha2 As Date, ByVal Usuario As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT Reg_ID as 'Nº', Reg_Fecha as 'Fecha de Registro', FechaUso as 'Fecha en que se uso', Vehiculo, Encargado, Uso As Motivo, Kilometraje, Usuario FROM UsoVehiculos WHERE Reg_Fecha >= @Fecha1 AND Reg_Fecha <= @Fecha2 And Usuario = @Usuario", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Fecha1", Fecha1.Date)
        miComando.Parameters.AddWithValue("@Fecha2", Fecha2.Date)
        miComando.Parameters.AddWithValue("@Usuario", Usuario)

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

    Public Function VNuevoVehiculo(ByVal Reg_Fecha As Date, ByVal FechaUso As Date, ByVal Vehiculo As String, ByVal Encargado As String, ByVal Kilometraje As String, ByVal Usuario As String, ByVal Uso As String)

        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand
            'Guarda nueva marca

            miComando = New SqlCommand("INSERT INTO UsoVehiculos" & _
                                         " (Reg_Fecha, FechaUso, Uso, Vehiculo, Encargado, Kilometraje, Usuario) " & _
                                         " VALUES (@Reg_Fecha,  @FechaUso, @Uso, @Vehiculo, @Encargado, @Kilometraje, @Usuario)", ActualizarConexion)

            miComando.Parameters.AddWithValue("@Reg_Fecha", Reg_Fecha.Date)
            miComando.Parameters.AddWithValue("@FechaUso", FechaUso.Date)
            miComando.Parameters.AddWithValue("@Uso", Uso)
            miComando.Parameters.AddWithValue("@Vehiculo", Vehiculo)
            miComando.Parameters.AddWithValue("@Encargado", Encargado)
            miComando.Parameters.AddWithValue("@Kilometraje", Kilometraje)
            miComando.Parameters.AddWithValue("@Usuario", Usuario)

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

    Public Function VMuestraTodosViajes(ByVal Fecha1 As Date, ByVal Fecha2 As Date, ByVal Vehiculo As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT Reg_ID as 'Nº', Reg_Fecha as 'Fecha de Registro', FechaUso as 'Fecha en que se uso', Vehiculo, Encargado, Uso As Motivo, Kilometraje, Usuario FROM UsoVehiculos WHERE Reg_Fecha >= @Fecha1 AND Reg_Fecha <= @Fecha2 AND Vehiculo = @Vehiculo", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Fecha1", Fecha1.Date)
        miComando.Parameters.AddWithValue("@Fecha2", Fecha2.Date)
        miComando.Parameters.AddWithValue("@Vehiculo", Vehiculo)

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

    Public Function VMuestraTodosViajesCompleto(ByVal Fecha1 As Date, ByVal Fecha2 As Date)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT Reg_ID as 'Nº', Reg_Fecha as 'Fecha de Registro', FechaUso as 'Fecha en que se uso', Vehiculo, Encargado, Uso As Motivo, Kilometraje, Usuario FROM UsoVehiculos WHERE Reg_Fecha >= @Fecha1 AND Reg_Fecha <= @Fecha2 ", ActualizarConexion)

        miComando.Parameters.AddWithValue("@Fecha1", Fecha1.Date)
        miComando.Parameters.AddWithValue("@Fecha2", Fecha2.Date)

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

#End Region

End Class