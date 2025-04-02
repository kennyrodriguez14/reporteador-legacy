Imports System.Data.SqlClient
Imports System.Text

Public Class cls_listado_productos
    Dim Conexion As New clsconexion_consumo
    Dim Conexion2 As New clsconexion_sr_agro
    Dim Conexion3 As New clsconexion_bienesyrecursos
    Dim Conexion7 As New ClsConexion_Flota
    Dim ConexionDimosa As New cls_conexion_DIMOSA

    Public Function buscar_por_clave_consumo(ByVal ALMACEN As Integer, ByVal CLAVE As String, ByVal tipo As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim empresa_flota As String
        Dim ALMACEN2 As Integer
        If ALMACEN = 1 Then
            empresa_flota = "04"
            ALMACEN2 = 1
        Else
            empresa_flota = "03"
            ALMACEN2 = 2
        End If

        Dim query As String
        If tipo = "Consumo" Then
            query = "SELECT dbo.INVE05.CVE_ART AS CODIGO, dbo.INVE05.DESCR AS  " & _
                    "DESCRIPCION, dbo.MULT05.EXIST AS EXISTENCIA, dbo.INVE05.PESO,dbo.INVE05.CON_LOTE FROM dbo.INVE05 " & _
                    "INNER JOIN dbo.MULT05 ON dbo.INVE05.CVE_ART = dbo.MULT05.CVE_ART " & _
                    "WHERE MULT05.CVE_ALM =  @ALMACEN AND INVE05.CVE_ART LIKE @CLAVE + '%' "
        Else
            query = "SELECT IV.CVE_ART AS CODIGO, IV.DESCR AS DESCRIPCION, " & _
                    "MU.EXIST AS EXISTENCIA, , IV.PESO,dbo.INVE02.CON_LOTE FROM SAE60Empre03.dbo.MULT03 MU " & _
                    "INNER JOIN SAE60Empre03.dbo.INVE03 IV ON MU.CVE_ART = IV.CVE_ART " & _
                    "WHERE IV.CLAVE LIKE '%' + @CLAVE + '%' AND MU.CVE_ALM = @ALMACEN2 "
        End If

        Dim miComando As New SqlCommand(query, ActualizarConexion)
        miComando.Parameters.AddWithValue("@ALMACEN", ALMACEN)
        miComando.Parameters.AddWithValue("@CLAVE", CLAVE)
        miComando.Parameters.AddWithValue("@ALMACEN2", ALMACEN2)

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

    Public Function buscar_por_clave_dimosa(ByVal ALMACEN As Integer, ByVal CLAVE As String, ByVal tipo As String)
        Dim ActualizarConexion As New SqlConnection(ConexionDimosa.CadenaSQL())
        Dim empresa_flota As String
        Dim ALMACEN2 As Integer
        If ALMACEN = 1 Then
            empresa_flota = "04"
            ALMACEN2 = 1
        Else
            empresa_flota = "03"
            ALMACEN2 = 2
        End If

        Dim query As String
        query = "SELECT dbo.INVE06.CVE_ART AS CODIGO, dbo.INVE06.DESCR AS  " & _
                    "DESCRIPCION, dbo.MULT06.EXIST AS EXISTENCIA, dbo.INVE06.PESO,dbo.INVE06.CON_LOTE FROM dbo.INVE06 " & _
                    "INNER JOIN dbo.MULT06 ON dbo.INVE06.CVE_ART = dbo.MULT06.CVE_ART " & _
                    "WHERE MULT06.CVE_ALM =  @ALMACEN AND INVE06.CVE_ART LIKE @CLAVE + '%' "


        Dim miComando As New SqlCommand(query, ActualizarConexion)
        miComando.Parameters.AddWithValue("@ALMACEN", ALMACEN)
        miComando.Parameters.AddWithValue("@CLAVE", CLAVE)
        miComando.Parameters.AddWithValue("@ALMACEN2", ALMACEN2)

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

    Public Function buscar_por_clave_flota_nueva(ByVal ALMACEN As Integer, ByVal CLAVE As String)
        Dim ActualizarConexion As New SqlConnection(Conexion7.CadenaSQL())

        Dim query As String
        query = "SELECT dbo.INVE07.CVE_ART AS CODIGO, dbo.INVE07.DESCR AS  " & _
                    "DESCRIPCION, dbo.MULT07.EXIST AS EXISTENCIA, dbo.INVE07.PESO,dbo.INVE07.CON_LOTE FROM dbo.INVE07 " & _
                    "INNER JOIN dbo.MULT07 ON dbo.INVE07.CVE_ART = dbo.MULT07.CVE_ART " & _
                    "WHERE MULT07.CVE_ALM =  @ALMACEN AND INVE07.CVE_ART LIKE @CLAVE + '%' "


        Dim miComando As New SqlCommand(query, ActualizarConexion)
        miComando.Parameters.AddWithValue("@ALMACEN", ALMACEN)
        miComando.Parameters.AddWithValue("@CLAVE", CLAVE)


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

    Public Function buscar_por_desc_consumo(ByVal ALMACEN As Integer, ByVal DESCR As String, ByVal tipo As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())
        Dim empresa_flota As String
        Dim ALMACEN2 As Integer
        If ALMACEN = 1 Then
            empresa_flota = "04"
            ALMACEN2 = 1
        Else
            empresa_flota = "03"
            ALMACEN2 = 2
        End If

        Dim query As String
        If tipo = "Consumo" Then
            query = "SELECT dbo.INVE05.CVE_ART AS CODIGO, dbo.INVE05.DESCR " & _
                    "AS DESCRIPCION, dbo.MULT05.EXIST AS EXISTENCIA, dbo.INVE05.PESO,dbo.INVE05.CON_LOTE FROM dbo.INVE05 " & _
                    "INNER JOIN dbo.MULT05 ON dbo.INVE05.CVE_ART = dbo.MULT05.CVE_ART " & _
                    " WHERE MULT05.CVE_ALM = @ALMACEN AND UPPER(INVE05.DESCR) LIKE '%' + @DESCR + '%' "
        Else
            query = "SELECT IV.CVE_ART AS CODIGO, IV.DESCR AS DESCRIPCION, " & _
                    "MU.EXIST AS EXISTENCIA, IV.PESO,dbo.INVE02.CON_LOTE FROM SAE60Empre03.dbo.MULT03 MU " & _
                    "INNER JOIN SAE60Empre03.dbo.INVE03 IV ON MU.CVE_ART = IV.CVE_ART " & _
                    "WHERE IV.DESCR LIKE '%' + @DESCR + '%' AND MU.CVE_ALM = @ALMACEN2 "
        End If

        Dim miComando As New SqlCommand(query, ActualizarConexion)

        miComando.Parameters.AddWithValue("@ALMACEN", ALMACEN)
        miComando.Parameters.AddWithValue("@DESCR", DESCR)
        miComando.Parameters.AddWithValue("@ALMACEN2", ALMACEN2)
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

    Public Function buscar_por_desc_dimosa(ByVal ALMACEN As Integer, ByVal DESCR As String, ByVal tipo As String)
        Dim ActualizarConexion As New SqlConnection(ConexionDimosa.CadenaSQL())
        Dim empresa_flota As String
        Dim ALMACEN2 As Integer
        If ALMACEN = 1 Then
            empresa_flota = "04"
            ALMACEN2 = 1
        Else
            empresa_flota = "03"
            ALMACEN2 = 2
        End If

        Dim query As String


        query = "SELECT dbo.INVE06.CVE_ART AS CODIGO, dbo.INVE06.DESCR " & _
                "AS DESCRIPCION, dbo.MULT06.EXIST AS EXISTENCIA, dbo.INVE06.PESO,dbo.INVE06.CON_LOTE FROM dbo.INVE06 " & _
                "INNER JOIN dbo.MULT06 ON dbo.INVE06.CVE_ART = dbo.MULT06.CVE_ART " & _
                " WHERE MULT06.CVE_ALM = @ALMACEN AND UPPER(INVE06.DESCR) LIKE '%' + @DESCR + '%' "


        Dim miComando As New SqlCommand(query, ActualizarConexion)

        miComando.Parameters.AddWithValue("@ALMACEN", ALMACEN)
        miComando.Parameters.AddWithValue("@DESCR", DESCR)
        miComando.Parameters.AddWithValue("@ALMACEN2", ALMACEN2)
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

    Public Function buscar_por_desc_flota_nueva(ByVal ALMACEN As Integer, ByVal DESCR As String)
        Dim ActualizarConexion As New SqlConnection(Conexion7.CadenaSQL())

        Dim query As String

        query = " SELECT dbo.INVE07.CVE_ART AS CODIGO, dbo.INVE07.DESCR " & _
                " AS DESCRIPCION, dbo.MULT07.EXIST AS EXISTENCIA, dbo.INVE07.PESO, dbo.INVE07.CON_LOTE FROM dbo.INVE07 " & _
                " INNER JOIN dbo.MULT07 ON dbo.INVE07.CVE_ART = dbo.MULT07.CVE_ART " & _
                " WHERE MULT07.CVE_ALM = @ALMACEN AND UPPER(INVE07.DESCR) LIKE '%' + @DESCR + '%' "


        Dim miComando As New SqlCommand(query, ActualizarConexion)

        miComando.Parameters.AddWithValue("@ALMACEN", ALMACEN)
        miComando.Parameters.AddWithValue("@DESCR", DESCR.ToUpper)

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

    Public Function ValidarExistencia_consumo(ByVal ALMACEN As Integer, ByVal CLAVE As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim query_existencia_consumo As New StringBuilder
        query_existencia_consumo.Append("SELECT SUM(CANTIDAD) AS CANTIDAD ")
        query_existencia_consumo.Append("FROM LTPD05 WHERE (STATUS = 'A') AND (CVE_ART = @CLAVE) AND CVE_ALM = @ALMACEN ")
        query_existencia_consumo.Append("AND (CANTIDAD > 0) AND (FCHCADUC > GETDATE() OR FCHCADUC IS NULL OR FCHCADUC = '') ")
        Dim miComando As New SqlCommand(query_existencia_consumo.ToString, ActualizarConexion)
        'Dim miComando As New SqlCommand("SELECT dbo.MULT05.EXIST AS EXISTENCIA " & _
        '                                "FROM dbo.INVE05 INNER JOIN dbo.MULT05 ON dbo.INVE05.CVE_ART = dbo.MULT05.CVE_ART " & _
        '                                "WHERE MULT05.CVE_ALM = @ALMACEN AND INVE05.CVE_ART = @CLAVE ", ActualizarConexion)
        miComando.Parameters.AddWithValue("@ALMACEN", ALMACEN)
        miComando.Parameters.AddWithValue("@CLAVE", CLAVE)
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
        Try
            Return dt.Rows(0).Item(0)
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function ValidarExistencia_dimosa(ByVal ALMACEN As Integer, ByVal CLAVE As String)
        Dim ActualizarConexion As New SqlConnection(ConexionDimosa.CadenaSQL())

        Dim query_existencia_consumo As New StringBuilder
        query_existencia_consumo.Append("SELECT SUM(CANTIDAD) AS CANTIDAD ")
        query_existencia_consumo.Append("FROM LTPD06 WHERE (STATUS = 'A') AND (CVE_ART = @CLAVE) AND CVE_ALM = @ALMACEN ")
        query_existencia_consumo.Append("AND (CANTIDAD > 0) AND (FCHCADUC > GETDATE() OR FCHCADUC IS NULL OR FCHCADUC = '') ")
        Dim miComando As New SqlCommand(query_existencia_consumo.ToString, ActualizarConexion)
        'Dim miComando As New SqlCommand("SELECT dbo.MULT05.EXIST AS EXISTENCIA " & _
        '                                "FROM dbo.INVE05 INNER JOIN dbo.MULT05 ON dbo.INVE05.CVE_ART = dbo.MULT05.CVE_ART " & _
        '                                "WHERE MULT05.CVE_ALM = @ALMACEN AND INVE05.CVE_ART = @CLAVE ", ActualizarConexion)
        miComando.Parameters.AddWithValue("@ALMACEN", ALMACEN)
        miComando.Parameters.AddWithValue("@CLAVE", CLAVE)
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
        Try
            Return dt.Rows(0).Item(0)
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function ValidarExistencia_BIENESYRECURSOS(ByVal ALMACEN As Integer, ByVal CLAVE As String)
        Dim ActualizarConexion As New SqlConnection(Conexion3.CadenaSQL())

        Dim query_existencia_consumo As New StringBuilder
        query_existencia_consumo.Append("SELECT SUM(CANTIDAD) AS CANTIDAD ")
        query_existencia_consumo.Append("FROM LTPD03 WHERE (STATUS = 'A') AND (CVE_ART = @CLAVE) AND CVE_ALM = @ALMACEN ")
        query_existencia_consumo.Append("AND (CANTIDAD > 0) AND (FCHCADUC > GETDATE() OR FCHCADUC IS NULL OR FCHCADUC = '') ")
        Dim miComando As New SqlCommand(query_existencia_consumo.ToString, ActualizarConexion)

        miComando.Parameters.AddWithValue("@ALMACEN", ALMACEN)
        miComando.Parameters.AddWithValue("@CLAVE", CLAVE)
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
        Try
            Return dt.Rows(0).Item(0)
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function ValidarExistencia_consumo_inventario(ByVal ALMACEN As Integer, ByVal CLAVE As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim query_existencia_consumo As New StringBuilder
        query_existencia_consumo.Append("SELECT dbo.MULT05.EXIST AS EXISTENCIA ")
        query_existencia_consumo.Append("FROM dbo.INVE05 INNER JOIN dbo.MULT05 ON dbo.INVE05.CVE_ART = dbo.MULT05.CVE_ART ")
        query_existencia_consumo.Append("WHERE MULT05.CVE_ALM = @ALMACEN AND INVE05.CVE_ART = @CLAVE ")
        Dim miComando As New SqlCommand(query_existencia_consumo.ToString, ActualizarConexion)

        miComando.Parameters.AddWithValue("@ALMACEN", ALMACEN)
        miComando.Parameters.AddWithValue("@CLAVE", CLAVE)
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
        Try
            Return dt.Rows(0).Item(0)
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function ValidarExistencia_consumo_inventario_dimosa(ByVal ALMACEN As Integer, ByVal CLAVE As String)
        Dim ActualizarConexion As New SqlConnection(ConexionDimosa.CadenaSQL())

        Dim query_existencia_consumo As New StringBuilder
        query_existencia_consumo.Append("SELECT dbo.MULT06.EXIST AS EXISTENCIA ")
        query_existencia_consumo.Append("FROM dbo.INVE06 INNER JOIN dbo.MULT06 ON dbo.INVE06.CVE_ART = dbo.MULT06.CVE_ART ")
        query_existencia_consumo.Append("WHERE MULT06.CVE_ALM = @ALMACEN AND INVE06.CVE_ART = @CLAVE ")
        Dim miComando As New SqlCommand(query_existencia_consumo.ToString, ActualizarConexion)

        miComando.Parameters.AddWithValue("@ALMACEN", ALMACEN)
        miComando.Parameters.AddWithValue("@CLAVE", CLAVE)
        ActualizarConexion.Open()
        Dim AdaptadorDeDatos As New SqlDataAdapter(miComando)
        Dim dt As New DataTable
        Try
            AdaptadorDeDatos.Fill(dt)
            ActualizarConexion.Close()
        Catch ex As SqlException
            MsgBox("Hay un problema con la conexión a los datos - validación consumo inventario: " & ex.Message, MsgBoxStyle.Critical)
            ActualizarConexion.Close()
        End Try
        Try
            Return dt.Rows(0).Item(0)
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function ValidarExistencia_consumo_inventario_flota(ByVal ALMACEN As Integer, ByVal CLAVE As String)
        Dim ActualizarConexion As New SqlConnection(Conexion7.CadenaSQL())

        Dim query_existencia_consumo As New StringBuilder
        query_existencia_consumo.Append("SELECT dbo.MULT07.EXIST AS EXISTENCIA ")
        query_existencia_consumo.Append("FROM dbo.INVE07 INNER JOIN dbo.MULT07 ON dbo.INVE07.CVE_ART = dbo.MULT07.CVE_ART ")
        query_existencia_consumo.Append("WHERE MULT07.CVE_ALM = @ALMACEN AND INVE07.CVE_ART = @CLAVE ")
        Dim miComando As New SqlCommand(query_existencia_consumo.ToString, ActualizarConexion)

        miComando.Parameters.AddWithValue("@ALMACEN", ALMACEN)
        miComando.Parameters.AddWithValue("@CLAVE", CLAVE)
        ActualizarConexion.Open()
        Dim AdaptadorDeDatos As New SqlDataAdapter(miComando)
        Dim dt As New DataTable
        Try
            AdaptadorDeDatos.Fill(dt)
            ActualizarConexion.Close()
        Catch ex As SqlException
            MsgBox("Hay un problema con la conexión a los datos - validación consumo inventario: " & ex.Message, MsgBoxStyle.Critical)
            ActualizarConexion.Close()
        End Try
        Try
            Return dt.Rows(0).Item(0)
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function ValidarExistencia_BIENESYRECURSOS_inventario(ByVal ALMACEN As Integer, ByVal CLAVE As String)
        Dim ActualizarConexion As New SqlConnection(Conexion3.CadenaSQL())

        Dim query_existencia_consumo As New StringBuilder
        query_existencia_consumo.Append("SELECT dbo.MULT03.EXIST AS EXISTENCIA ")
        query_existencia_consumo.Append("FROM dbo.INVE03 INNER JOIN dbo.MULT03 ON dbo.INVE03.CVE_ART = dbo.MULT03.CVE_ART ")
        query_existencia_consumo.Append("WHERE MULT03.CVE_ALM = @ALMACEN AND INVE03.CVE_ART = @CLAVE ")
        Dim miComando As New SqlCommand(query_existencia_consumo.ToString, ActualizarConexion)

        miComando.Parameters.AddWithValue("@ALMACEN", ALMACEN)
        miComando.Parameters.AddWithValue("@CLAVE", CLAVE)
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
        Try
            Return dt.Rows(0).Item(0)
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function ValidarExistencia_flota(ByVal ALMACEN2 As Integer, ByVal CLAVE As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())


        Dim miComando As New SqlCommand("SELECT IV.CVE_ART AS CODIGO, IV.DESCR AS DESCRIPCION, " & _
                                        "MU.EXIST AS EXISTENCIA FROM SAE60Empre07.dbo.MULT07 MU " & _
                                        "INNER JOIN SAE60Empre07.dbo.INVE07 IV ON MU.CVE_ART = IV.CVE_ART " & _
                                        "WHERE IV.CVE_ART = @CLAVE AND MU.CVE_ALM = @ALMACEN2 ", ActualizarConexion)


        miComando.Parameters.AddWithValue("@CLAVE", CLAVE)
        miComando.Parameters.AddWithValue("@ALMACEN2", ALMACEN2)
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
        Try
            Return dt.Rows(0).Item(0)
        Catch ex As Exception
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' SR AGRO
    ''' </summary>
    ''' <param name="ALMACEN"></param>
    ''' <param name="CLAVE"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function buscar_por_clave_SRAGRO(ByVal ALMACEN As Integer, ByVal CLAVE As String)

        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT dbo.INVE02.CVE_ART AS CODIGO, dbo.INVE02.DESCR AS DESCRIPCION, dbo.MULT02.EXIST AS EXISTENCIA, dbo.INVE02.PESO,dbo.INVE02.CON_LOTE " & _
                                        "FROM dbo.INVE02 INNER JOIN dbo.MULT02 ON dbo.INVE02.CVE_ART = dbo.MULT02.CVE_ART " & _
                                        "WHERE MULT02.CVE_ALM = @ALMACEN AND INVE02.CVE_ART LIKE @CLAVE + '%' ", ActualizarConexion)

        miComando.Parameters.AddWithValue("@ALMACEN", ALMACEN)
        miComando.Parameters.AddWithValue("@CLAVE", CLAVE)
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

    Public Function buscar_por_clave_BIENESYRECURSOS(ByVal ALMACEN As Integer, ByVal CLAVE As String)

        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim miComando As New SqlCommand("SELECT dbo.INVE03.CVE_ART AS CODIGO, dbo.INVE03.DESCR AS DESCRIPCION, " & _
                                        " dbo.MULT03.EXIST AS EXISTENCIA, dbo.INVE03.PESO,dbo.INVE03.CON_LOTE " & _
                                        "FROM dbo.INVE03 INNER JOIN dbo.MULT03 ON dbo.INVE03.CVE_ART = dbo.MULT03.CVE_ART " & _
                                        "WHERE MULT03.CVE_ALM = @ALMACEN AND INVE03.CVE_ART LIKE @CLAVE + '%' ", ActualizarConexion)

        miComando.Parameters.AddWithValue("@ALMACEN", ALMACEN)
        miComando.Parameters.AddWithValue("@CLAVE", CLAVE)
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

    Public Function buscar_por_desc_SRAGRO(ByVal ALMACEN As Integer, ByVal DESCR As String)
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT dbo.INVE02.CVE_ART AS CODIGO, dbo.INVE02.DESCR AS DESCRIPCION, dbo.MULT02.EXIST AS EXISTENCIA, dbo.INVE02.PESO,dbo.INVE02.CON_LOTE " & _
                                        "FROM dbo.INVE02 INNER JOIN dbo.MULT02 ON dbo.INVE02.CVE_ART = dbo.MULT02.CVE_ART " & _
                                        "WHERE MULT02.CVE_ALM = @ALMACEN AND UPPER(INVE02.DESCR) LIKE '%' + @DESCR + '%' ", ActualizarConexion)

        miComando.Parameters.AddWithValue("@ALMACEN", ALMACEN)
        miComando.Parameters.AddWithValue("@DESCR", DESCR)
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

    Public Function buscar_por_desc_BIENESYRECURSOS(ByVal ALMACEN As Integer, ByVal DESCR As String)
        Dim ActualizarConexion As New SqlConnection(Conexion3.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT dbo.INVE03.CVE_ART AS CODIGO, dbo.INVE03.DESCR AS DESCRIPCION, " & _
                                        "dbo.MULT03.EXIST AS EXISTENCIA, ISNULL(dbo.INVE03.PESO,0),ISNULL(dbo.INVE03.CON_LOTE,'') " & _
                                        "FROM dbo.INVE03 INNER JOIN dbo.MULT03 ON dbo.INVE03.CVE_ART = dbo.MULT03.CVE_ART " & _
                                        "WHERE MULT03.CVE_ALM = @ALMACEN AND UPPER(INVE03.DESCR) LIKE '%' + @DESCR + '%' ", ActualizarConexion)

        miComando.Parameters.AddWithValue("@ALMACEN", ALMACEN)
        miComando.Parameters.AddWithValue("@DESCR", DESCR)
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

    Public Function buscar_por_desc_FLOTA(ByVal ALMACEN As Integer, ByVal DESCR As String)
        Dim ActualizarConexion As New SqlConnection(Conexion3.CadenaSQL())

        Dim miComando As New SqlCommand("SELECT dbo.INVE03.CVE_ART AS CODIGO, dbo.INVE03.DESCR AS DESCRIPCION, " & _
                                        "dbo.MULT03.EXIST AS EXISTENCIA, ISNULL(dbo.INVE03.PESO,0),ISNULL(dbo.INVE03.CON_LOTE,'') " & _
                                        "FROM dbo.INVE03 INNER JOIN dbo.MULT03 ON dbo.INVE03.CVE_ART = dbo.MULT03.CVE_ART " & _
                                        "WHERE MULT03.CVE_ALM = @ALMACEN AND UPPER(INVE03.DESCR) LIKE '%' + @DESCR + '%' ", ActualizarConexion)

        miComando.Parameters.AddWithValue("@ALMACEN", ALMACEN)
        miComando.Parameters.AddWithValue("@DESCR", DESCR)
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

    Public Function ValidarExistencia_sr_agro(ByVal ALMACEN As Integer, ByVal CLAVE As String)
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())

        Dim query_validar_sragro As New StringBuilder

        query_validar_sragro.Append("SELECT ISNULL(SUM(CANTIDAD),0) AS CANTIDAD ")
        query_validar_sragro.Append("FROM LTPD02 WHERE (STATUS = 'A') AND (CVE_ART = @CLAVE) AND CVE_ALM = @ALMACEN ")
        query_validar_sragro.Append("AND (CANTIDAD > 0) AND (FCHCADUC > GETDATE() OR FCHCADUC IS NULL OR FCHCADUC = '')  ")

        Dim miComando As New SqlCommand(query_validar_sragro.ToString, ActualizarConexion)

        'Dim miComando As New SqlCommand("SELECT dbo.MULT02.EXIST AS EXISTENCIA " & _
        '                              "FROM dbo.INVE02 INNER JOIN dbo.MULT02 ON dbo.INVE02.CVE_ART = dbo.MULT02.CVE_ART " & _
        '                              "WHERE MULT02.CVE_ALM = @ALMACEN AND INVE02.CVE_ART = @CLAVE ", ActualizarConexion)


        miComando.Parameters.AddWithValue("@ALMACEN", ALMACEN)
        miComando.Parameters.AddWithValue("@CLAVE", CLAVE)
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

        Try
            Return dt.Rows(0).Item(0)
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function ValidarExistencia_inventarios_sragro(ByVal ALMACEN As Integer, ByVal CLAVE As String)
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())

        Dim query_validar_sragro As New StringBuilder

        query_validar_sragro.Append("SELECT ISNULL(dbo.MULT02.EXIST,0) AS EXISTENCIA ")
        query_validar_sragro.Append("FROM dbo.INVE02 INNER JOIN dbo.MULT02 ON dbo.INVE02.CVE_ART = dbo.MULT02.CVE_ART ")
        query_validar_sragro.Append("WHERE MULT02.CVE_ALM = @ALMACEN AND INVE02.CVE_ART = @CLAVE ")

        Dim miComando As New SqlCommand(query_validar_sragro.ToString, ActualizarConexion)

        miComando.Parameters.AddWithValue("@ALMACEN", ALMACEN)
        miComando.Parameters.AddWithValue("@CLAVE", CLAVE)
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

        Try
            Return dt.Rows(0).Item(0)
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function ValidarSIexiste_prod_CONSUMO(ByVal ALMACEN As Integer, ByVal CLAVE As String)
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim query_existencia_consumo As New StringBuilder
        query_existencia_consumo.Append("SELECT CVE_ART FROM MULT05 WHERE CVE_ALM = @ALMACEN AND CVE_ART = @CLAVE ")
        Dim miComando As New SqlCommand(query_existencia_consumo.ToString, ActualizarConexion)
        'Dim miComando As New SqlCommand("SELECT dbo.MULT05.EXIST AS EXISTENCIA " & _
        '                                "FROM dbo.INVE05 INNER JOIN dbo.MULT05 ON dbo.INVE05.CVE_ART = dbo.MULT05.CVE_ART " & _
        '                                "WHERE MULT05.CVE_ALM = @ALMACEN AND INVE05.CVE_ART = @CLAVE ", ActualizarConexion)
        miComando.Parameters.AddWithValue("@ALMACEN", ALMACEN)
        miComando.Parameters.AddWithValue("@CLAVE", CLAVE)
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

        If dt.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function ValidarSIexiste_prod_CONSUMO_dimosa(ByVal ALMACEN As Integer, ByVal CLAVE As String)
        Dim ActualizarConexion As New SqlConnection(ConexionDimosa.CadenaSQL())

        Dim query_existencia_consumo As New StringBuilder
        query_existencia_consumo.Append("SELECT CVE_ART FROM MULT06 WHERE CVE_ALM = @ALMACEN AND CVE_ART = @CLAVE ")
        Dim miComando As New SqlCommand(query_existencia_consumo.ToString, ActualizarConexion)
        'Dim miComando As New SqlCommand("SELECT dbo.MULT05.EXIST AS EXISTENCIA " & _
        '                                "FROM dbo.INVE05 INNER JOIN dbo.MULT05 ON dbo.INVE05.CVE_ART = dbo.MULT05.CVE_ART " & _
        '                                "WHERE MULT05.CVE_ALM = @ALMACEN AND INVE05.CVE_ART = @CLAVE ", ActualizarConexion)
        miComando.Parameters.AddWithValue("@ALMACEN", ALMACEN)
        miComando.Parameters.AddWithValue("@CLAVE", CLAVE)
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

        If dt.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function ValidarSIexiste_prod_CONSUMO_FLOTA(ByVal ALMACEN As Integer, ByVal CLAVE As String)
        Dim ActualizarConexion As New SqlConnection(Conexion7.CadenaSQL())

        Dim query_existencia_consumo As New StringBuilder
        query_existencia_consumo.Append("SELECT CVE_ART FROM MULT07 WHERE CVE_ALM = @ALMACEN AND CVE_ART = @CLAVE ")
        Dim miComando As New SqlCommand(query_existencia_consumo.ToString, ActualizarConexion)
        'Dim miComando As New SqlCommand("SELECT dbo.MULT05.EXIST AS EXISTENCIA " & _
        '                                "FROM dbo.INVE05 INNER JOIN dbo.MULT05 ON dbo.INVE05.CVE_ART = dbo.MULT05.CVE_ART " & _
        '                                "WHERE MULT05.CVE_ALM = @ALMACEN AND INVE05.CVE_ART = @CLAVE ", ActualizarConexion)
        miComando.Parameters.AddWithValue("@ALMACEN", ALMACEN)
        miComando.Parameters.AddWithValue("@CLAVE", CLAVE)
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

        If dt.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function ValidarSIexiste_prod_BIENESYRECURSOS(ByVal ALMACEN As Integer, ByVal CLAVE As String)
        Dim ActualizarConexion As New SqlConnection(Conexion3.CadenaSQL())

        Dim query_existencia_consumo As New StringBuilder
        query_existencia_consumo.Append("SELECT CVE_ART FROM MULT03 WHERE CVE_ALM = @ALMACEN AND CVE_ART = @CLAVE ")
        Dim miComando As New SqlCommand(query_existencia_consumo.ToString, ActualizarConexion)
        'Dim miComando As New SqlCommand("SELECT dbo.MULT05.EXIST AS EXISTENCIA " & _
        '                                "FROM dbo.INVE05 INNER JOIN dbo.MULT05 ON dbo.INVE05.CVE_ART = dbo.MULT05.CVE_ART " & _
        '                                "WHERE MULT05.CVE_ALM = @ALMACEN AND INVE05.CVE_ART = @CLAVE ", ActualizarConexion)
        miComando.Parameters.AddWithValue("@ALMACEN", ALMACEN)
        miComando.Parameters.AddWithValue("@CLAVE", CLAVE)
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

        If dt.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function ValidarSIexiste_prod_SRAGRO(ByVal ALMACEN As Integer, ByVal CLAVE As String)
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())

        Dim query_existencia_consumo As New StringBuilder
        query_existencia_consumo.Append("SELECT CVE_ART FROM MULT02 WHERE CVE_ALM = @ALMACEN AND CVE_ART = @CLAVE ")
        Dim miComando As New SqlCommand(query_existencia_consumo.ToString, ActualizarConexion)

        miComando.Parameters.AddWithValue("@ALMACEN", ALMACEN)
        miComando.Parameters.AddWithValue("@CLAVE", CLAVE)
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

        If dt.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function


End Class

