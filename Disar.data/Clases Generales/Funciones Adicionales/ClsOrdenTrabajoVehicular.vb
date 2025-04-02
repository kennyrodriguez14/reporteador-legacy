Imports Disar.data
Imports System.Data.SqlClient
Imports System.Text

Public Class ClsOrdenTrabajoVehicular

    Dim Conexion As New clsConexion
    Dim Conexion2 As New clsConexion_Centro_Costos
    Dim Conexion3 As New clsconexion_bienesyrecursos
    Dim ConexionConsumo As New clsconexion_consumo
    Dim ConexionAgro As New clsconexion_sr_agro
    Dim ConexionSIP As New cls_conexion_sip

    Public Function TodasOrdenes()
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT OrdenID AS 'ID', OrdenNombre as 'Detalle Orden', Tipo FROM Vehiculos_OrdenTrabajo", ActualizarConexion)
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

    Public Function TodasOrdenesCombo()
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT 0 as OrdenId, 'Todas' as OrdenNombre UNION ALL SELECT OrdenID, OrdenNombre  FROM Vehiculos_OrdenTrabajo", ActualizarConexion)
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

    Public Function NuevoEvento(ByVal Texto As String, ByVal ID As Integer, ByVal Orden As Integer)

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
            QueryBita = "SELECT * FROM VehiculosTareas WHERE ID = @ID"
            Dim CMDQueryBita As New SqlCommand(QueryBita, ActualizarConexion)
            CMDQueryBita.Parameters.AddWithValue("@ID", ID)
            Dim AdaptadorBita As New SqlDataAdapter(CMDQueryBita)
            CMDQueryBita.Transaction = transaccion_sql
            AdaptadorBita.Fill(DtBita)

            Dim Numero = 0
            Dim Guarda As Boolean = True

            If DtBita.Rows.Count > 0 Then
                If Not IsDBNull(DtBita.Rows(0)(0)) Then
                    Guarda = False
                    Numero = ID
                End If
            End If


            If Guarda = True Then
                Dim DtMarca As New DataTable
                Dim Query As String
                Query = "SELECT MAX (ID)  FROM VehiculosTareas"
                Dim CMDQuery As New SqlCommand(Query, ActualizarConexion)
                Dim Adaptador As New SqlDataAdapter(CMDQuery)
                CMDQuery.Transaction = transaccion_sql
                Adaptador.Fill(DtMarca)

                If DtMarca.Rows.Count > 0 Then
                    If Not IsDBNull(DtMarca.Rows(0)(0)) Then
                        Numero = DtMarca.Rows(0)(0)
                    End If
                End If
                Numero = Numero + 1

                miComando = New SqlCommand("INSERT INTO VehiculosTareas" & _
                                        " (ID, Descr) " & _
                                        " VALUES (@ID, @Descr)", ActualizarConexion)
                miComando.Parameters.AddWithValue("@ID", Numero)
                miComando.Parameters.AddWithValue("@Descr", Texto)

                miComando.Transaction = transaccion_sql
                miComando.ExecuteNonQuery()
            End If

            miComando = New SqlCommand("INSERT INTO VehiculosOrdenAnexo" & _
                                         " (Orden, Tarea) " & _
                                         " VALUES (@Orden, @Tarea)", ActualizarConexion)
            miComando.Parameters.AddWithValue("@Orden", Orden)
            miComando.Parameters.AddWithValue("@Tarea", Numero)


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

    Public Function DetalleOrden(ByVal ID As Integer)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT     dbo.VehiculosTareas.ID as ID, dbo.Vehiculos_OrdenTrabajo.OrdenNombre as Ord, dbo.VehiculosTareas.Descr as Elemento" & _
                      " FROM         dbo.VehiculosOrdenAnexo INNER JOIN " & _
                      " dbo.VehiculosTareas ON dbo.VehiculosOrdenAnexo.Tarea = dbo.VehiculosTareas.ID INNER JOIN " & _
                      " dbo.Vehiculos_OrdenTrabajo ON dbo.VehiculosOrdenAnexo.Orden = dbo.Vehiculos_OrdenTrabajo.OrdenID WHERE dbo.Vehiculos_OrdenTrabajo.OrdenID = @ID", ActualizarConexion)
        miComando.Parameters.AddWithValue("@ID", ID)
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

    Public Function TareasOrdenes()
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT       ID, Descr " & _
        "FROM         VehiculosTareas", ActualizarConexion)

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

    Public Function Repuestos()
        Dim ActualizarConexion As New SqlConnection(Conexion3.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT     CVE_ART AS CLAVE, DESCR AS DESCRIPCION, COSTO_PROM as COSTO, EXIST AS EXISTENCIAS " & _
         "FROM         dbo.INVE03 WHERE     (CVE_ART > '30-088')", ActualizarConexion)
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

    Public Function RepuestosBusca(ByVal Busca As String)
        Dim ActualizarConexion As New SqlConnection(Conexion3.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT     CVE_ART AS CLAVE, DESCR AS DESCRIPCION, COSTO_PROM as COSTO, EXIST AS EXISTENCIAS " & _
         "FROM         dbo.INVE03 WHERE  (CVE_ART > '30-088') AND UPPER(DESCR) LIKE '%" & Busca.ToUpper & "%' OR UPPER(CVE_ART) = UPPER(@Busca)", ActualizarConexion)
        miComando.Parameters.AddWithValue("@Busca", Busca)
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

    Public Function GuardaOrden(ByVal dte As DataTable, ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal Entrada As String, ByVal Salida As String, ByVal Vehiculo As Integer, ByVal Observaciones As String, ByVal TipoOrden As Integer, ByVal Encargado As String, ByVal Usuario As String, ByVal Kilometraje As Decimal, ByVal Tipo As String)

        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand
            'Guarda nueva marca
            Dim NumBita As Integer = 0

            Dim DtMarca As New DataTable
            Dim Query As String
            Query = "SELECT MAX (Numero) FROM VehiculosRegistroOrden"
            Dim CMDQuery As New SqlCommand(Query, ActualizarConexion)
            Dim Adaptador As New SqlDataAdapter(CMDQuery)
            CMDQuery.Transaction = transaccion_sql
            Adaptador.Fill(DtMarca)

            If DtMarca.Rows.Count > 0 Then
                If Not IsDBNull(DtMarca.Rows(0)(0)) Then
                    NumBita = DtMarca.Rows(0)(0)
                End If
            End If
            NumBita = NumBita + 1

            miComando = New SqlCommand("INSERT INTO VehiculosRegistroOrden" & _
                                    " (Numero, OrdenID, Fecha, FechaSalida, HoraEntrada, HoraSalida, Observaciones, AsignadoA, Estado, Vehiculo, Kilometraje, Tipo) " & _
                                    " VALUES (@Numero, @OrdenID, @Fecha, @FechaSalida, @HoraEntrada, @HoraSalida, @Observaciones, @AsignadoA, @Estado, @Vehiculo, @Kilometraje, @Tipo)", ActualizarConexion)

            miComando.Parameters.AddWithValue("@Numero", NumBita)
            miComando.Parameters.AddWithValue("@OrdenID", TipoOrden)
            miComando.Parameters.AddWithValue("@Fecha", FechaInicio.Date)
            miComando.Parameters.AddWithValue("@FechaSalida", FechaFin.Date)
            miComando.Parameters.AddWithValue("@HoraEntrada", Entrada)
            miComando.Parameters.AddWithValue("@HoraSalida", Salida)
            miComando.Parameters.AddWithValue("@Observaciones", Observaciones)
            miComando.Parameters.AddWithValue("@AsignadoA", Encargado)
            miComando.Parameters.AddWithValue("@Estado", "Completo")
            miComando.Parameters.AddWithValue("@Vehiculo", Vehiculo)
            miComando.Parameters.AddWithValue("@Kilometraje", Kilometraje)
            miComando.Parameters.AddWithValue("@Tipo", Tipo)

            miComando.Transaction = transaccion_sql
            miComando.ExecuteNonQuery()

            For ind As Integer = 0 To dte.Rows.Count - 1

                Dim NumBita2 As Integer = 0

                Dim DtMarca2 As New DataTable
                Dim Query2 As String
                Query2 = "SELECT MAX (Numero) FROM VehiculosRegistroTareas"
                Dim CMDQuery2 As New SqlCommand(Query2, ActualizarConexion)
                Dim Adaptador2 As New SqlDataAdapter(CMDQuery2)
                CMDQuery2.Transaction = transaccion_sql
                Adaptador2.Fill(DtMarca2)

                If DtMarca2.Rows.Count > 0 Then
                    If Not IsDBNull(DtMarca2.Rows(0)(0)) Then
                        NumBita2 = DtMarca2.Rows(0)(0)
                    End If
                End If

                NumBita2 = NumBita2 + 1

                miComando = New SqlCommand("  INSERT INTO VehiculosRegistroTareas" & _
                                             " (Numero, Orden, Elemento, Actividad, Tipo, Repuesto, Cantidad, Costo) " & _
                                             " VALUES (@Numero, @Orden, @Elemento, @Actividad, @Tipo, @Repuesto, @Cantidad, @Costo)", ActualizarConexion)

                miComando.Parameters.AddWithValue("@Numero", NumBita2)
                miComando.Parameters.AddWithValue("@Orden", NumBita)
                miComando.Parameters.AddWithValue("@Elemento", dte.Rows(ind).Item(0))
                miComando.Parameters.AddWithValue("@Actividad", dte.Rows(ind).Item(3))
                miComando.Parameters.AddWithValue("@Tipo", dte.Rows(ind).Item(4))
                miComando.Parameters.AddWithValue("@Repuesto", dte.Rows(ind).Item(5))
                miComando.Parameters.AddWithValue("@Cantidad", dte.Rows(ind).Item(6))
                miComando.Parameters.AddWithValue("@Costo", dte.Rows(ind).Item(7))

                miComando.Transaction = transaccion_sql
                miComando.ExecuteNonQuery()
            Next

            Dim conexion_bita As New cls_bitacora_reporteador
            conexion_bita.RegistraBitacora(Now, Usuario, "Guardó Orden de Trabajo", "CENTRO DE MANTENIMIENTO", _
                                      "Fecha: " & Convert.ToString(DateTime.Now) & " Documento: " & NumBita & " Encargado:" & Encargado)

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

    Public Function EliminaOrden(ByVal Numero As Integer, ByVal Usuario As String)

        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand
            'Guarda nueva marca
            Dim NumBita As Integer = 0

            NumBita = Numero

            miComando = New SqlCommand("UPDATE VehiculosRegistroOrden" & _
                                    " SET Estado = 'Eliminado' " & _
                                    " WHERE Numero = @Numero", ActualizarConexion)

            miComando.Parameters.AddWithValue("@Numero", NumBita)

            miComando.Transaction = transaccion_sql
            miComando.ExecuteNonQuery()


            Dim conexion_bita As New cls_bitacora_reporteador
            conexion_bita.RegistraBitacora(Now, Usuario, "Eliminó Orden de Trabajo " & NumBita, "CENTRO DE MANTENIMIENTO", _
                                      "Fecha: " & Convert.ToString(DateTime.Now) & " Documento: " & NumBita)

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

    Public Function MuestraORdenes(ByVal Fecha1 As Date, ByVal Fecha2 As Date)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT     dbo.VehiculosRegistroOrden.Numero, dbo.VehiculosRegistroOrden.Vehiculo, dbo.VehiculosRegistroOrden.Kilometraje, dbo.VehiculosRegistroOrden.OrdenID AS 'Tipo Orden', " & _
                      " dbo.Vehiculos_OrdenTrabajo.OrdenNombre AS 'Orden de Trabajo', dbo.VehiculosRegistroOrden.Fecha AS 'Fecha Ingreso', " & _
                      " dbo.VehiculosRegistroOrden.HoraEntrada AS 'Hora Ingreso', dbo.VehiculosRegistroOrden.FechaSalida AS 'Fecha Salida', " & _
                      " dbo.VehiculosRegistroOrden.HoraSalida AS 'Hora Salida', dbo.VehiculosRegistroOrden.AsignadoA AS 'Encargado' " & _
                      " FROM         dbo.Vehiculos_OrdenTrabajo INNER JOIN " & _
                      " dbo.VehiculosRegistroOrden ON dbo.Vehiculos_OrdenTrabajo.OrdenID = dbo.VehiculosRegistroOrden.OrdenID " & _
                      " WHERE     (dbo.VehiculosRegistroOrden.Fecha >= @Fecha1) AND (dbo.VehiculosRegistroOrden.Fecha <= @Fecha2) AND ESTADO <> 'Eliminado'", ActualizarConexion)
        ActualizarConexion.Open()
        miComando.Parameters.AddWithValue("@Fecha1", Fecha1.Date)
        miComando.Parameters.AddWithValue("@Fecha2", Fecha2.Date)
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
      
    Public Function MuestraTareasPorOrden(ByVal ID As Integer)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT     dbo.VehiculosRegistroTareas.Elemento, dbo.VehiculosTareas.Descr, dbo.VehiculosRegistroTareas.Actividad, dbo.VehiculosRegistroTareas.Tipo, " & _
        " dbo.VehiculosRegistroTareas.Repuesto, dbo.VehiculosRegistroTareas.Cantidad, dbo.VehiculosRegistroTareas.Costo " & _
        " FROM  dbo.VehiculosRegistroOrden INNER JOIN " & _
        " dbo.VehiculosRegistroTareas ON dbo.VehiculosRegistroOrden.Numero = dbo.VehiculosRegistroTareas.Orden INNER JOIN " & _
        " dbo.VehiculosTareas ON dbo.VehiculosRegistroTareas.Elemento = dbo.VehiculosTareas.ID WHERE  dbo.VehiculosRegistroTareas.Orden = @Orden", ActualizarConexion)

        ActualizarConexion.Open()

        miComando.Parameters.AddWithValue("@Orden", ID)
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

    Public Function MuestraObservaciones(ByVal ID As Integer)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT     dbo.VehiculosRegistroOrden.Observaciones  " & _
        " FROM  dbo.VehiculosRegistroOrden  WHERE  dbo.VehiculosRegistroOrden.Numero = @Orden", ActualizarConexion)

        ActualizarConexion.Open()

        miComando.Parameters.AddWithValue("@Orden", ID)
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

    Public Function PreventivoVSCorrectivo(ByVal Fecha1 As Date, ByVal Fecha2 As Date)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT dbo.VehiculosRegistroOrden.Vehiculo, dbo.VehiculosRegistroOrden.Kilometraje, dbo.VehiculosTareas.Descr as Tarea, dbo.Vehiculos_OrdenTrabajo.OrdenNombre as Orden, " & _
        " dbo.VehiculosRegistroTareas.Actividad, dbo.VehiculosRegistroTareas.Tipo " & _
        " FROM dbo.Vehiculos_OrdenTrabajo INNER JOIN " & _
        " dbo.VehiculosRegistroOrden ON dbo.Vehiculos_OrdenTrabajo.OrdenID = dbo.VehiculosRegistroOrden.OrdenID INNER JOIN " & _
        " dbo.VehiculosRegistroTareas ON dbo.VehiculosRegistroOrden.Numero = dbo.VehiculosRegistroTareas.Orden INNER JOIN " & _
        " dbo.VehiculosTareas ON dbo.VehiculosRegistroTareas.Elemento = dbo.VehiculosTareas.ID WHERE dbo.VehiculosRegistroOrden.Fecha >= DATEADD(day,-1,@Fecha1) AND (dbo.VehiculosRegistroOrden.Fecha <= @Fecha2) AND ESTADO <> 'Eliminado' ", ActualizarConexion)

        ActualizarConexion.Open()

        miComando.Parameters.AddWithValue("@Fecha1", Fecha1)
        miComando.Parameters.AddWithValue("@Fecha2", Fecha2)

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

    Public Function PreventivoVSCorrectivoFiltro(ByVal Fecha1 As Date, ByVal Fecha2 As Date, ByVal Vehiculo As Integer)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT dbo.VehiculosRegistroOrden.Vehiculo, dbo.VehiculosRegistroOrden.Kilometraje, dbo.VehiculosTareas.Descr as Tarea, dbo.Vehiculos_OrdenTrabajo.OrdenNombre as Orden, " & _
        " dbo.VehiculosRegistroTareas.Actividad, dbo.VehiculosRegistroTareas.Tipo " & _
        " FROM dbo.Vehiculos_OrdenTrabajo INNER JOIN " & _
        " dbo.VehiculosRegistroOrden ON dbo.Vehiculos_OrdenTrabajo.OrdenID = dbo.VehiculosRegistroOrden.OrdenID INNER JOIN " & _
        " dbo.VehiculosRegistroTareas ON dbo.VehiculosRegistroOrden.Numero = dbo.VehiculosRegistroTareas.Orden INNER JOIN " & _
        " dbo.VehiculosTareas ON dbo.VehiculosRegistroTareas.Elemento = dbo.VehiculosTareas.ID WHERE Fecha >= DATEADD(day,-1,@Fecha1) AND Fecha <= @Fecha2 AND dbo.VehiculosRegistroOrden.Vehiculo = @VE AND ESTADO <> 'Eliminado' ", ActualizarConexion)

        ActualizarConexion.Open()

        miComando.Parameters.AddWithValue("@Fecha1", Fecha1)
        miComando.Parameters.AddWithValue("@Fecha2", Fecha2)
        miComando.Parameters.AddWithValue("@VE", Vehiculo)

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

    Public Function DetallePreventivoVSCorrectivo(ByVal Fecha1 As Date, ByVal Fecha2 As Date)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT        dbo.VehiculosRegistroOrden.Numero, dbo.Vehiculos_OrdenTrabajo.OrdenNombre AS Orden, dbo.Vehiculos_OrdenTrabajo.Tipo AS 'Tipo de Mantenimiento', dbo.VehiculosRegistroOrden.Vehiculo, " & _
                         " dbo.VehiculosRegistroOrden.Fecha AS 'Fecha de Ingreso', dbo.VehiculosRegistroOrden.FechaSalida AS 'Fecha de Salida', dbo.VehiculosRegistroOrden.HoraEntrada AS 'Hora de Ingreso',  " & _
                         " dbo.VehiculosRegistroOrden.HoraSalida AS 'Hora de Salida', dbo.VehiculosRegistroOrden.Observaciones, dbo.VehiculosRegistroOrden.AsignadoA AS 'Trabajado por', dbo.VehiculosRegistroOrden.Kilometraje,  " & _
                         " dbo.VehiculosRegistroOrden.Tipo AS 'Preventivo/Correctivo' FROM            dbo.Vehiculos_OrdenTrabajo INNER JOIN " & _
                         " dbo.VehiculosRegistroOrden ON dbo.Vehiculos_OrdenTrabajo.OrdenID = dbo.VehiculosRegistroOrden.OrdenID WHERE dbo.VehiculosRegistroOrden.Fecha >= DATEADD(day,-1,@Fecha1) AND dbo.VehiculosRegistroOrden.Fecha <= @Fecha2 AND ESTADO <> 'Eliminado' ", ActualizarConexion)

        ActualizarConexion.Open()

        miComando.Parameters.AddWithValue("@Fecha1", Fecha1)
        miComando.Parameters.AddWithValue("@Fecha2", Fecha2)

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

    Public Function DetallePreventivoVSCorrectivoFiltro(ByVal Fecha1 As Date, ByVal Fecha2 As Date, ByVal Vehiculo As Integer)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT        dbo.VehiculosRegistroOrden.Numero, dbo.Vehiculos_OrdenTrabajo.OrdenNombre AS Orden, dbo.Vehiculos_OrdenTrabajo.Tipo AS 'Tipo de Mantenimiento', dbo.VehiculosRegistroOrden.Vehiculo, " & _
                         " dbo.VehiculosRegistroOrden.Fecha AS 'Fecha de Ingreso', dbo.VehiculosRegistroOrden.FechaSalida AS 'Fecha de Salida', dbo.VehiculosRegistroOrden.HoraEntrada AS 'Hora de Ingreso',  " & _
                         " dbo.VehiculosRegistroOrden.HoraSalida AS 'Hora de Salida', dbo.VehiculosRegistroOrden.Observaciones, dbo.VehiculosRegistroOrden.AsignadoA AS 'Trabajado por', dbo.VehiculosRegistroOrden.Kilometraje,  " & _
                         " dbo.VehiculosRegistroOrden.Tipo AS 'Preventivo/Correctivo' FROM            dbo.Vehiculos_OrdenTrabajo INNER JOIN " & _
                         " dbo.VehiculosRegistroOrden ON dbo.Vehiculos_OrdenTrabajo.OrdenID = dbo.VehiculosRegistroOrden.OrdenID WHERE Fecha >= DATEADD(day,-1,@Fecha1) AND Fecha <= @Fecha2 AND dbo.VehiculosRegistroOrden.Vehiculo = @VE AND ESTADO <> 'Eliminado' ", ActualizarConexion)

        ActualizarConexion.Open()

        miComando.Parameters.AddWithValue("@Fecha1", Fecha1)
        miComando.Parameters.AddWithValue("@Fecha2", Fecha2)
        miComando.Parameters.AddWithValue("@VE", Vehiculo)

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
