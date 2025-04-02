Imports System.Data.SqlClient

Public Class cls_antiguedad_saldos
    Dim Conexion As New clsconexion_consumo
    Dim ConexionDIMOSA As New cls_conexion_DIMOSA
    Dim ConexionAGRO As New clsconexion_sr_agro

    Public Function Saldos(ByVal F1 As Date, ByVal SUCURSAL As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("rptn_antiguedad_saldos", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@SUCURSAL", SqlDbType.VarChar)).Value = SUCURSAL
        miComando.Parameters.Add(New SqlParameter("@FECHA_CORRIENTE", SqlDbType.DateTime)).Value = F1
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

    Public Function Saldos_detallados(ByVal F1 As Date, ByVal SUCURSAL As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("rptn_antiguedad_saldos_detallado", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@SUCURSAL", SqlDbType.VarChar)).Value = SUCURSAL
        miComando.Parameters.Add(New SqlParameter("@FECHA_CORRIENTE", SqlDbType.DateTime)).Value = F1
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

    Public Function Saldos_detalladosDimosa(ByVal F1 As Date, ByVal SUCURSAL As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionDIMOSA.CadenaSQL())
        Dim miComando As New SqlCommand("rptn_antiguedad_saldos_detallado", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@SUCURSAL", SqlDbType.VarChar)).Value = SUCURSAL
        miComando.Parameters.Add(New SqlParameter("@FECHA_CORRIENTE", SqlDbType.DateTime)).Value = F1
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

    Public Function Saldos_detalladosAGRO(ByVal F1 As Date, ByVal SUCURSAL As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionAGRO.CadenaSQL())
        Dim miComando As New SqlCommand("rptn_antiguedad_saldos_detallado", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@SUCURSAL", SqlDbType.VarChar)).Value = SUCURSAL
        miComando.Parameters.Add(New SqlParameter("@FECHA_CORRIENTE", SqlDbType.DateTime)).Value = F1
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


    Public Function llenar_combo_box(ByVal F1 As Date, ByVal SUCURSAL As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim miComando As New SqlCommand("rptn_antiguedad_saldos_detallado", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@SUCURSAL", SqlDbType.VarChar)).Value = SUCURSAL
        miComando.Parameters.Add(New SqlParameter("@FECHA_CORRIENTE", SqlDbType.DateTime)).Value = F1
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

    Public Function llenar_combo_box_DIMOSA(ByVal F1 As Date, ByVal SUCURSAL As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionDIMOSA.CadenaSQL())
        Dim miComando As New SqlCommand("rptn_antiguedad_saldos_detallado", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@SUCURSAL", SqlDbType.VarChar)).Value = SUCURSAL
        miComando.Parameters.Add(New SqlParameter("@FECHA_CORRIENTE", SqlDbType.DateTime)).Value = F1
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

    Public Function llenar_combo_box_AGRO(ByVal F1 As Date, ByVal SUCURSAL As String) As DataTable
        Dim ActualizarConexion As New SqlConnection(ConexionAGRO.CadenaSQL())
        Dim miComando As New SqlCommand("rptn_antiguedad_saldos_detallado", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@SUCURSAL", SqlDbType.VarChar)).Value = SUCURSAL
        miComando.Parameters.Add(New SqlParameter("@FECHA_CORRIENTE", SqlDbType.DateTime)).Value = F1
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

    Public Function Saldos_desglose(ByVal F1 As Date, ByVal SUCURSAL As String) As DataSet

        Dim ds = New DataSet
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_antiguedad_saldos", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@SUCURSAL", SqlDbType.VarChar)).Value = SUCURSAL
        miComando.Parameters.Add(New SqlParameter("@FECHA_CORRIENTE", SqlDbType.DateTime)).Value = F1
        Dim AdaptadorA As New SqlDataAdapter(miComando)

        Dim miComando2 As New SqlCommand("rptn_antiguedad_saldos_detallado", ActualizarConexion)
        miComando2.CommandType = CommandType.StoredProcedure
        miComando2.Parameters.Add(New SqlParameter("@SUCURSAL", SqlDbType.VarChar)).Value = SUCURSAL + "_DETALLE"
        miComando2.Parameters.Add(New SqlParameter("@FECHA_CORRIENTE", SqlDbType.DateTime)).Value = F1
        miComando2.CommandTimeout = 2000
        Dim AdaptadorB As New SqlDataAdapter(miComando2)

        ActualizarConexion.Open()
        AdaptadorA.Fill(ds, "A")
        AdaptadorB.Fill(ds, "B")
        ActualizarConexion.Close()

        Try
            ds.Relations.Add("Detalle de Facturas", ds.Tables("A").Columns("CCLIE"), ds.Tables("B").Columns("Codigo"))
        Catch ex As Exception

        End Try

        Return ds
    End Function

    Public Function Saldos_desglose_DIMOSA(ByVal F1 As Date, ByVal SUCURSAL As String) As DataSet

        Dim ds = New DataSet
        Dim ActualizarConexion As New SqlConnection(ConexionDIMOSA.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_antiguedad_saldos", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@SUCURSAL", SqlDbType.VarChar)).Value = SUCURSAL
        miComando.Parameters.Add(New SqlParameter("@FECHA_CORRIENTE", SqlDbType.DateTime)).Value = F1
        Dim AdaptadorA As New SqlDataAdapter(miComando)

        Dim miComando2 As New SqlCommand("rptn_antiguedad_saldos_detallado", ActualizarConexion)
        miComando2.CommandType = CommandType.StoredProcedure
        miComando2.Parameters.Add(New SqlParameter("@SUCURSAL", SqlDbType.VarChar)).Value = SUCURSAL + "_DETALLE"
        miComando2.Parameters.Add(New SqlParameter("@FECHA_CORRIENTE", SqlDbType.DateTime)).Value = F1
        miComando2.CommandTimeout = 2000
        Dim AdaptadorB As New SqlDataAdapter(miComando2)

        ActualizarConexion.Open()
        AdaptadorA.Fill(ds, "A")
        AdaptadorB.Fill(ds, "B")
        ActualizarConexion.Close()

        ds.Relations.Add("Detalle de Facturas", ds.Tables("A").Columns("CCLIE"), ds.Tables("B").Columns("Codigo"))
        Return ds
    End Function

    Public Function Saldos_desglose_AGRO(ByVal F1 As Date, ByVal SUCURSAL As String) As DataSet

        Dim ds = New DataSet
        Dim ActualizarConexion As New SqlConnection(ConexionAGRO.CadenaSQL())

        Dim miComando As New SqlCommand("rptn_antiguedad_saldos", ActualizarConexion)
        miComando.CommandType = CommandType.StoredProcedure
        miComando.Parameters.Add(New SqlParameter("@SUCURSAL", SqlDbType.VarChar)).Value = SUCURSAL
        miComando.Parameters.Add(New SqlParameter("@FECHA_CORRIENTE", SqlDbType.DateTime)).Value = F1
        Dim AdaptadorA As New SqlDataAdapter(miComando)

        Dim miComando2 As New SqlCommand("rptn_antiguedad_saldos_detallado", ActualizarConexion)
        miComando2.CommandType = CommandType.StoredProcedure
        miComando2.Parameters.Add(New SqlParameter("@SUCURSAL", SqlDbType.VarChar)).Value = SUCURSAL + "_DETALLE"
        miComando2.Parameters.Add(New SqlParameter("@FECHA_CORRIENTE", SqlDbType.DateTime)).Value = F1
        miComando2.CommandTimeout = 2000
        Dim AdaptadorB As New SqlDataAdapter(miComando2)

        ActualizarConexion.Open()
        AdaptadorA.Fill(ds, "A")
        AdaptadorB.Fill(ds, "B")
        ActualizarConexion.Close()

        ds.Relations.Add("Detalle de Facturas", ds.Tables("A").Columns("CCLIE"), ds.Tables("B").Columns("Codigo"))
        Return ds
    End Function

End Class
