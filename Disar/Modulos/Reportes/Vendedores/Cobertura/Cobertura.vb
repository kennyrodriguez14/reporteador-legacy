Imports Disar.data
Public Class Cobertura
    Dim CoberturaSRC As New cls_coberturas_src
    Dim CoberturaSPS As New cls_coberturas_sps
    Dim CoberturaTocoa As New cls_coberturas_tocoa
    Dim CoberturaTegucigalpa As New cls_coberturasTeg
    Dim CoberturaGeneral As New cls_coberturas_general
    Dim ClaseGeneral As New Object
    Dim Tabla As New DataTable
    Dim Lineas As DataRow = Tabla.NewRow()
    Dim ini, fin As Date
    Dim america, global_pack, livsmart, comosa, cargill, zepol, bic, colgate, kc, nestle, colombina, fompac, mayab, Universo, UniversoGeneral, Otros, Carib As Integer
    Dim americag, global_packg, livsmartg, comosag, cargillg, zepolg, bicg, colgateg, kcg, nestleg, colombinag, fompacg, mayabg, otrosg, caribg As Integer

    Dim TrinidadMatch, Dcasa, Farinter, Purina, GrupoAlza As Integer
    Dim TrinidadMatchg, Dcasag, Farinterg, Purinag, GrupoAlzag As Integer

    Dim dacasa As Integer, proveedor_quala As Integer, dacasag As Integer, proveedor_qualag
    Dim style As Microsoft.Office.Interop.Excel.Style
    Dim nombre As String
    Dim activo As Integer = 0
    Private Sub Cobertura_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inicializardate()
        Me.MdiParent = _Inicio
        LlenarEncabezado()
        _cmbSucursal.SelectedItem = "SRC"
    End Sub

    'Boton para generar los datos
    Private Sub _btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnGenerar.Click
        Iniciar_Variables()
        ini = _cmbFechaInicial.Value.Date
        fin = _cmbFechaFinal.Value.Date
        limpiar()
        Try
            activo = 1
            _gridUniverso.DataSource = ClaseGeneral.ListaUniverso()
            If _cmbFechaFinal.Value.Date < _cmbFechaInicial.Value.Date Then
                MessageBox.Show("La Fecha Final no puede ser menor que la Fecha Inicial", "Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                _cmbFechaFinal.Focus()
            Else
                For i As Integer = 0 To _gridUniverso.RowCount - 1
                    Lineas("CLAVE") = _gridUniverso.Rows(i).Cells(0).Value
                    Lineas("VENDEDOR") = _gridUniverso.Rows(i).Cells(1).Value
                    Lineas("UNIVERSO") = _gridUniverso.Rows(i).Cells(2).Value
                    Universo = _gridUniverso.Rows(i).Cells(2).Value

                    _gridVentas.DataSource = ClaseGeneral.VentasXLinea(ini, fin, "28", _gridUniverso.Rows(i).Cells(0).Value)
                    america = _gridVentas.RowCount
                    _gridVentas.DataSource = ClaseGeneral.VentasXLinea(ini, fin, "21", _gridUniverso.Rows(i).Cells(0).Value)
                    global_pack = _gridVentas.RowCount
                    _gridVentas.DataSource = ClaseGeneral.VentasXLinea(ini, fin, "16", _gridUniverso.Rows(i).Cells(0).Value)
                    livsmart = _gridVentas.RowCount
                    _gridVentas.DataSource = ClaseGeneral.VentasXLinea(ini, fin, "01", _gridUniverso.Rows(i).Cells(0).Value)
                    comosa = _gridVentas.RowCount
                    _gridVentas.DataSource = ClaseGeneral.VentasXLinea(ini, fin, "24", _gridUniverso.Rows(i).Cells(0).Value)
                    cargill = _gridVentas.RowCount
                    _gridVentas.DataSource = ClaseGeneral.VentasXLinea(ini, fin, "02", _gridUniverso.Rows(i).Cells(0).Value)
                    zepol = _gridVentas.RowCount
                    _gridVentas.DataSource = ClaseGeneral.VentasXLinea(ini, fin, "17", _gridUniverso.Rows(i).Cells(0).Value)
                    bic = _gridVentas.RowCount
                    _gridVentas.DataSource = ClaseGeneral.VentasXLinea(ini, fin, "20", _gridUniverso.Rows(i).Cells(0).Value)
                    colgate = _gridVentas.RowCount
                    _gridVentas.DataSource = ClaseGeneral.VentasXLinea(ini, fin, "30", _gridUniverso.Rows(i).Cells(0).Value)
                    kc = _gridVentas.RowCount
                    _gridVentas.DataSource = ClaseGeneral.VentasXLinea(ini, fin, "11", _gridUniverso.Rows(i).Cells(0).Value)
                    nestle = _gridVentas.RowCount
                    _gridVentas.DataSource = ClaseGeneral.VentasXLinea(ini, fin, "41", _gridUniverso.Rows(i).Cells(0).Value)
                    colombina = _gridVentas.RowCount
                    _gridVentas.DataSource = ClaseGeneral.VentasXLinea(ini, fin, "18", _gridUniverso.Rows(i).Cells(0).Value)
                    fompac = _gridVentas.RowCount
                    _gridVentas.DataSource = ClaseGeneral.VentasXLinea(ini, fin, "15", _gridUniverso.Rows(i).Cells(0).Value)
                    mayab = _gridVentas.RowCount

                    _gridVentas.DataSource = ClaseGeneral.VentasXLineaOTROS(ini, fin, _gridUniverso.Rows(i).Cells(0).Value)
                    Otros = _gridVentas.RowCount

                    _gridVentas.DataSource = ClaseGeneral.VentasXLinea(ini, fin, "12", _gridUniverso.Rows(i).Cells(0).Value)
                    dacasa = _gridVentas.RowCount

                    _gridVentas.DataSource = ClaseGeneral.VentasXLinea(ini, fin, "27", _gridUniverso.Rows(i).Cells(0).Value)
                    proveedor_quala = _gridVentas.RowCount

                    _gridVentas.DataSource = ClaseGeneral.VentasXLinea(ini, fin, "03", _gridUniverso.Rows(i).Cells(0).Value)
                    TrinidadMatch = _gridVentas.RowCount
                    _gridVentas.DataSource = ClaseGeneral.VentasXLinea(ini, fin, "43", _gridUniverso.Rows(i).Cells(0).Value)
                    Dcasa = _gridVentas.RowCount

                    _gridVentas.DataSource = ClaseGeneral.VentasXLinea(ini, fin, "05", _gridUniverso.Rows(i).Cells(0).Value)
                    Farinter = _gridVentas.RowCount
                    _gridVentas.DataSource = ClaseGeneral.VentasXLinea(ini, fin, "06", _gridUniverso.Rows(i).Cells(0).Value)
                    Purina = _gridVentas.RowCount
                    _gridVentas.DataSource = ClaseGeneral.VentasXLinea(ini, fin, "08", _gridUniverso.Rows(i).Cells(0).Value)
                    GrupoAlza = _gridVentas.RowCount

                    _gridVentas.DataSource = ClaseGeneral.VentasXLinea(ini, fin, "22", _gridUniverso.Rows(i).Cells(0).Value)
                    Carib = _gridVentas.RowCount


                    UniversoGeneral += Universo
                    americag += america
                    global_packg += global_pack
                    livsmartg += livsmart
                    comosag += comosa
                    cargillg += cargill
                    zepolg += zepol
                    bicg += bic
                    colgateg += colgate
                    kcg += kc
                    nestleg += nestle
                    colombinag += colombina
                    fompacg += fompac
                    mayabg += mayab
                    otrosg += Otros
                    dacasag += dacasa
                    proveedor_qualag += proveedor_quala
                    TrinidadMatchg += TrinidadMatch
                    Dcasag += Dcasa

                    Farinterg += Farinter
                    Purinag += Purina
                    GrupoAlzag += GrupoAlza
                    caribg += Carib

                    Lineas("AMERICA FRESH") = america
                    Lineas("GLOBAL PACK") = global_pack
                    Lineas("LIVSMART") = livsmart
                    Lineas("COMOSA") = comosa
                    Lineas("CARGILL") = cargill
                    Lineas("ZEPOL") = zepol
                    Lineas("BIC") = bic
                    Lineas("COLGATE") = colgate
                    Lineas("KC") = kc
                    Lineas("NESTLE") = nestle
                    Lineas("COLOMBINA") = colombina
                    Lineas("FOMPAC") = fompac
                    Lineas("MAYAB") = mayab
                    Lineas("DACASA") = dacasa
                    Lineas("QUALA") = proveedor_quala
                    Lineas("TRINIDAD MATCH") = TrinidadMatch
                    Lineas("DCASA") = Dcasa

                    'Lineas("FARINTER") = Farinter
                    Lineas("PURINA") = Purina
                    Lineas("GRUPO ALZA") = GrupoAlza

                    Lineas("CARIB") = Carib

                    Lineas("DISAR") = Otros

                    Lineas("% AMERICA FRESH") = Math.Round((america / Universo) * 100, 2)
                    Lineas("% GLOBAL PACK") = Math.Round((global_pack / Universo) * 100, 2)
                    Lineas("% LIVSMART") = Math.Round((livsmart / Universo) * 100, 2)
                    Lineas("% COMOSA") = Math.Round((comosa / Universo) * 100, 2)
                    Lineas("% CARGILL") = Math.Round((cargill / Universo) * 100, 2)
                    Lineas("% ZEPOL") = Math.Round((zepol / Universo) * 100, 2)
                    Lineas("% BIC") = Math.Round((bic / Universo) * 100, 2)
                    Lineas("% COLGATE") = Math.Round((colgate / Universo) * 100, 2)
                    Lineas("% KC") = Math.Round((kc / Universo) * 100, 2)
                    Lineas("% NESTLE") = Math.Round((nestle / Universo) * 100, 2)
                    Lineas("% COLOMBINA") = Math.Round((colombina / Universo) * 100, 2)
                    Lineas("% FOMPAC") = Math.Round((fompac / Universo) * 100, 2)
                    Lineas("% MAYAB") = Math.Round((mayab / Universo) * 100, 2)

                    Lineas("% DACASA") = Math.Round((dacasa / Universo) * 100, 2)
                    Lineas("% QUALA") = Math.Round((proveedor_quala / Universo) * 100, 2)

                    Lineas("% TRINIDAD MATCH") = Math.Round((TrinidadMatch / Universo) * 100, 2)
                    Lineas("% DCASA") = Math.Round((Dcasa / Universo) * 100, 2)

                    'Lineas("% FARINTER") = Math.Round((Farinter / Universo) * 100, 2)
                    Lineas("% PURINA") = Math.Round((Purina / Universo) * 100, 2)
                    Lineas("% GRUPO ALZA") = Math.Round((GrupoAlza / Universo) * 100, 2)

                    Lineas("% CARIB") = Math.Round((Carib / Universo) * 100, 2)

                    Lineas("% DISAR") = Math.Round((Otros / Universo) * 100, 2)

                    Tabla.Rows.Add(Lineas)
                    Lineas = Tabla.NewRow()
                Next
                If _cmbSucursal.SelectedItem = "SRC" Then
                    Lineas("CLAVE") = "DISAR SRC"
                    Lineas("VENDEDOR") = "TOTAL"
                    Lineas("UNIVERSO") = UniversoGeneral

                    Lineas("AMERICA FRESH") = americag
                    Lineas("GLOBAL PACK") = global_packg
                    Lineas("LIVSMART") = livsmartg
                    Lineas("COMOSA") = comosag
                    Lineas("CARGILL") = cargillg
                    Lineas("ZEPOL") = zepolg
                    Lineas("BIC") = bicg
                    Lineas("COLGATE") = colgateg
                    Lineas("KC") = kcg
                    Lineas("NESTLE") = nestleg
                    Lineas("COLOMBINA") = colombinag
                    Lineas("FOMPAC") = fompacg
                    Lineas("MAYAB") = mayabg

                    Lineas("DACASA") = dacasag
                    Lineas("QUALA") = proveedor_qualag

                    Lineas("TRINIDAD MATCH") = TrinidadMatchg
                    Lineas("DCASA") = Dcasag

                    'Lineas("FARINTER") = Farinterg
                    Lineas("PURINA") = Purinag
                    Lineas("GRUPO ALZA") = GrupoAlzag

                    Lineas("CARIB") = caribg


                    Lineas("DISAR") = otrosg

                    Lineas("% AMERICA FRESH") = Math.Round((americag / UniversoGeneral) * 100, 2)
                    Lineas("% GLOBAL PACK") = Math.Round((global_packg / UniversoGeneral) * 100, 2)
                    Lineas("% LIVSMART") = Math.Round((livsmartg / UniversoGeneral) * 100, 2)
                    Lineas("% COMOSA") = Math.Round((comosag / UniversoGeneral) * 100, 2)
                    Lineas("% CARGILL") = Math.Round((cargillg / UniversoGeneral) * 100, 2)
                    Lineas("% ZEPOL") = Math.Round((zepolg / UniversoGeneral) * 100, 2)
                    Lineas("% BIC") = Math.Round((bicg / UniversoGeneral) * 100, 2)
                    Lineas("% COLGATE") = Math.Round((colgateg / UniversoGeneral) * 100, 2)
                    Lineas("% KC") = Math.Round((kcg / UniversoGeneral) * 100, 2)
                    Lineas("% NESTLE") = Math.Round((nestleg / UniversoGeneral) * 100, 2)
                    Lineas("% COLOMBINA") = Math.Round((colombinag / UniversoGeneral) * 100, 2)
                    Lineas("% FOMPAC") = Math.Round((fompacg / UniversoGeneral) * 100, 2)
                    Lineas("% MAYAB") = Math.Round((mayabg / UniversoGeneral) * 100, 2)

                    Lineas("% DACASA") = Math.Round((dacasag / UniversoGeneral) * 100, 2)
                    Lineas("% QUALA") = Math.Round((proveedor_qualag / UniversoGeneral) * 100, 2)

                    Lineas("% TRINIDAD MATCH") = Math.Round((TrinidadMatchg / UniversoGeneral) * 100, 2)
                    Lineas("% DCASA") = Math.Round((Dcasag / UniversoGeneral) * 100, 2)

                    'Lineas("% FARINTER") = Math.Round((Farinterg / UniversoGeneral) * 100, 2)
                    Lineas("% PURINA") = Math.Round((Purinag / UniversoGeneral) * 100, 2)
                    Lineas("% GRUPO ALZA") = Math.Round((GrupoAlzag / UniversoGeneral) * 100, 2)
                    Lineas("% CARIB") = Math.Round((caribg / UniversoGeneral) * 100, 2)

                    Lineas("% DISAR") = Math.Round((otrosg / UniversoGeneral) * 100, 2)

                    Tabla.Rows.Add(Lineas)
                ElseIf _cmbSucursal.SelectedItem = "SPS" Then
                    Lineas("CLAVE") = "DISAR SPS"
                    Lineas("VENDEDOR") = "TOTAL"
                    Lineas("UNIVERSO") = UniversoGeneral

                    Lineas("AMERICA FRESH") = americag
                    Lineas("GLOBAL PACK") = global_packg
                    Lineas("LIVSMART") = livsmartg
                    Lineas("COMOSA") = comosag
                    Lineas("CARGILL") = cargillg
                    Lineas("ZEPOL") = zepolg
                    Lineas("BIC") = bicg
                    Lineas("COLGATE") = colgateg
                    Lineas("KC") = kcg
                    Lineas("NESTLE") = nestleg
                    Lineas("COLOMBINA") = colombinag
                    Lineas("FOMPAC") = fompacg
                    Lineas("MAYAB") = mayabg

                    Lineas("DACASA") = dacasa
                    Lineas("QUALA") = proveedor_quala

                    Lineas("TRINIDAD MATCH") = TrinidadMatchg
                    Lineas("DCASA") = Dcasag

                    'Lineas("FARINTER") = Farinterg
                    Lineas("PURINA") = Purinag
                    Lineas("GRUPO ALZA") = GrupoAlzag
                    Lineas("CARIB") = caribg

                    Lineas("DISAR") = otrosg

                    Lineas("% AMERICA FRESH") = Math.Round((americag / UniversoGeneral) * 100, 2)
                    Lineas("% GLOBAL PACK") = Math.Round((global_packg / UniversoGeneral) * 100, 2)
                    Lineas("% LIVSMART") = Math.Round((livsmartg / UniversoGeneral) * 100, 2)
                    Lineas("% COMOSA") = Math.Round((comosag / UniversoGeneral) * 100, 2)
                    Lineas("% CARGILL") = Math.Round((cargillg / UniversoGeneral) * 100, 2)
                    Lineas("% ZEPOL") = Math.Round((zepolg / UniversoGeneral) * 100, 2)
                    Lineas("% BIC") = Math.Round((bicg / UniversoGeneral) * 100, 2)
                    Lineas("% COLGATE") = Math.Round((colgateg / UniversoGeneral) * 100, 2)
                    Lineas("% KC") = Math.Round((kcg / UniversoGeneral) * 100, 2)
                    Lineas("% NESTLE") = Math.Round((nestleg / UniversoGeneral) * 100, 2)
                    Lineas("% COLOMBINA") = Math.Round((colombinag / UniversoGeneral) * 100, 2)
                    Lineas("% FOMPAC") = Math.Round((fompacg / UniversoGeneral) * 100, 2)
                    Lineas("% MAYAB") = Math.Round((mayabg / UniversoGeneral) * 100, 2)

                    Lineas("% DACASA") = Math.Round((dacasag / UniversoGeneral) * 100, 2)
                    Lineas("% QUALA") = Math.Round((proveedor_qualag / UniversoGeneral) * 100, 2)

                    Lineas("% TRINIDAD MATCH") = Math.Round((TrinidadMatchg / UniversoGeneral) * 100, 2)
                    Lineas("% DCASA") = Math.Round((Dcasag / UniversoGeneral) * 100, 2)

                    'Lineas("% FARINTER") = Math.Round((Farinterg / UniversoGeneral) * 100, 2)
                    Lineas("% PURINA") = Math.Round((Purinag / UniversoGeneral) * 100, 2)
                    Lineas("% GRUPO ALZA") = Math.Round((GrupoAlzag / UniversoGeneral) * 100, 2)

                    Lineas("% CARIB") = Math.Round((caribg / UniversoGeneral) * 100, 2)

                    Lineas("% DISAR") = Math.Round((otrosg / UniversoGeneral) * 100, 2)

                    Tabla.Rows.Add(Lineas)
                ElseIf _cmbSucursal.SelectedItem = "Todos" Then
                    Lineas("CLAVE") = "DISAR Total"
                    Lineas("VENDEDOR") = "TOTAL"
                    Lineas("UNIVERSO") = UniversoGeneral

                    Lineas("AMERICA FRESH") = americag
                    Lineas("GLOBAL PACK") = global_packg
                    Lineas("LIVSMART") = livsmartg
                    Lineas("COMOSA") = comosag
                    Lineas("CARGILL") = cargillg
                    Lineas("ZEPOL") = zepolg
                    Lineas("BIC") = bicg
                    Lineas("COLGATE") = colgateg
                    Lineas("KC") = kcg
                    Lineas("NESTLE") = nestleg
                    Lineas("COLOMBINA") = colombinag
                    Lineas("FOMPAC") = fompacg
                    Lineas("MAYAB") = mayabg

                    Lineas("DACASA") = dacasa
                    Lineas("QUALA") = proveedor_quala

                    Lineas("TRINIDAD MATCH") = TrinidadMatchg
                    Lineas("DCASA") = Dcasag

                    'Lineas("FARINTER") = Farinterg
                    Lineas("PURINA") = Purinag
                    Lineas("GRUPO ALZA") = GrupoAlzag

                    Lineas("CARIB") = Carib

                    Lineas("DISAR") = otrosg

                    Lineas("% AMERICA FRESH") = Math.Round((americag / UniversoGeneral) * 100, 2)
                    Lineas("% GLOBAL PACK") = Math.Round((global_packg / UniversoGeneral) * 100, 2)
                    Lineas("% LIVSMART") = Math.Round((livsmartg / UniversoGeneral) * 100, 2)
                    Lineas("% COMOSA") = Math.Round((comosag / UniversoGeneral) * 100, 2)
                    Lineas("% CARGILL") = Math.Round((cargillg / UniversoGeneral) * 100, 2)
                    Lineas("% ZEPOL") = Math.Round((zepolg / UniversoGeneral) * 100, 2)
                    Lineas("% BIC") = Math.Round((bicg / UniversoGeneral) * 100, 2)
                    Lineas("% COLGATE") = Math.Round((colgateg / UniversoGeneral) * 100, 2)
                    Lineas("% KC") = Math.Round((kcg / UniversoGeneral) * 100, 2)
                    Lineas("% NESTLE") = Math.Round((nestleg / UniversoGeneral) * 100, 2)
                    Lineas("% COLOMBINA") = Math.Round((colombinag / UniversoGeneral) * 100, 2)
                    Lineas("% FOMPAC") = Math.Round((fompacg / UniversoGeneral) * 100, 2)
                    Lineas("% MAYAB") = Math.Round((mayabg / UniversoGeneral) * 100, 2)

                    Lineas("% DACASA") = Math.Round((dacasag / UniversoGeneral) * 100, 2)
                    Lineas("% QUALA") = Math.Round((proveedor_qualag / UniversoGeneral) * 100, 2)

                    Lineas("% TRINIDAD MATCH") = Math.Round((TrinidadMatchg / UniversoGeneral) * 100, 2)
                    Lineas("% DCASA") = Math.Round((Dcasag / UniversoGeneral) * 100, 2)

                    'Lineas("% FARINTER") = Math.Round((Farinterg / UniversoGeneral) * 100, 2)
                    Lineas("% PURINA") = Math.Round((Purinag / UniversoGeneral) * 100, 2)
                    Lineas("% GRUPO ALZA") = Math.Round((GrupoAlzag / UniversoGeneral) * 100, 2)

                    Lineas("% CARIB") = Math.Round((caribg / UniversoGeneral) * 100, 2)

                    Lineas("% DISAR") = Math.Round((otrosg / UniversoGeneral) * 100, 2)

                    Tabla.Rows.Add(Lineas)
                End If
                Me._GridCobertura.DataSource = Tabla

            End If
            If _cmbSucursal.Text = "Tegucigalpa" Or _cmbSucursal.Text = "Todos" Then
                '_GridCobertura.Columns("FARINTER").Visible = True
                _GridCobertura.Columns("PURINA").Visible = True
                _GridCobertura.Columns("GRUPO ALZA").Visible = True

                '_GridCobertura.Columns("% FARINTER").Visible = True
                _GridCobertura.Columns("% PURINA").Visible = True
                _GridCobertura.Columns("% GRUPO ALZA").Visible = True
            Else
                '_GridCobertura.Columns("FARINTER").Visible = False
                _GridCobertura.Columns("PURINA").Visible = False
                _GridCobertura.Columns("GRUPO ALZA").Visible = False

                '_GridCobertura.Columns("% FARINTER").Visible = False
                _GridCobertura.Columns("% PURINA").Visible = False
                _GridCobertura.Columns("% GRUPO ALZA").Visible = False
            End If
        Catch ex As Exception
            MessageBox.Show("Error al Generar " + ex.ToString, "Ha ocurrido un Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub Iniciar_Variables()
        UniversoGeneral = 0
        americag = 0
        global_packg = 0
        livsmartg = 0
        comosag = 0
        cargillg = 0
        zepolg = 0
        bicg = 0
        colgateg = 0
        kcg = 0
        nestleg = 0
        colombinag = 0
        fompacg = 0
        mayabg = 0
        otrosg = 0
        proveedor_qualag = 0
        dacasag = 0
        Dcasag = 0
        TrinidadMatchg = 0
        caribg = 0
    End Sub

    'Seleccion de la clase para sucursal
    Private Sub _cmbSucursal_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _cmbSucursal.SelectedIndexChanged
        If _cmbSucursal.SelectedItem = "SRC" Then
            ClaseGeneral = CoberturaSRC
        ElseIf _cmbSucursal.SelectedItem = "SPS" Then
            ClaseGeneral = CoberturaSPS
        ElseIf _cmbSucursal.SelectedItem = "Saba" Then
            ClaseGeneral = CoberturaTocoa
        ElseIf _cmbSucursal.SelectedItem = "Tegucigalpa" Then
            ClaseGeneral = CoberturaTegucigalpa
        ElseIf _cmbSucursal.SelectedItem = "Todos" Then
            ClaseGeneral = CoberturaGeneral
        End If
    End Sub

    'Subrutina para llenar las columnas de la tabla
    Sub LlenarEncabezado()
        Tabla.Columns.Add("CLAVE")
        Tabla.Columns.Add("VENDEDOR")
        Tabla.Columns.Add("UNIVERSO")
        Tabla.Columns.Add("AMERICA FRESH")
        Tabla.Columns.Add("GLOBAL PACK")
        Tabla.Columns.Add("LIVSMART")
        Tabla.Columns.Add("COMOSA")
        Tabla.Columns.Add("CARGILL")
        Tabla.Columns.Add("ZEPOL")
        Tabla.Columns.Add("BIC")
        Tabla.Columns.Add("COLGATE")
        Tabla.Columns.Add("KC")
        Tabla.Columns.Add("NESTLE")
        Tabla.Columns.Add("COLOMBINA")
        Tabla.Columns.Add("FOMPAC")
        Tabla.Columns.Add("MAYAB")

        Tabla.Columns.Add("DACASA")
        Tabla.Columns.Add("QUALA")

        Tabla.Columns.Add("TRINIDAD MATCH")
        Tabla.Columns.Add("DCASA")

        'Tabla.Columns.Add("FARINTER")
        Tabla.Columns.Add("PURINA")
        Tabla.Columns.Add("GRUPO ALZA")

        Tabla.Columns.Add("CARIB")


        Tabla.Columns.Add("DISAR")

        Tabla.Columns.Add("% AMERICA FRESH")
        Tabla.Columns.Add("% GLOBAL PACK")
        Tabla.Columns.Add("% LIVSMART")
        Tabla.Columns.Add("% COMOSA")
        Tabla.Columns.Add("% CARGILL")
        Tabla.Columns.Add("% ZEPOL")
        Tabla.Columns.Add("% BIC")
        Tabla.Columns.Add("% COLGATE")
        Tabla.Columns.Add("% KC")
        Tabla.Columns.Add("% NESTLE")
        Tabla.Columns.Add("% COLOMBINA")
        Tabla.Columns.Add("% FOMPAC")
        Tabla.Columns.Add("% MAYAB")

        Tabla.Columns.Add("% DACASA")
        Tabla.Columns.Add("% QUALA")

        Tabla.Columns.Add("% TRINIDAD MATCH")
        Tabla.Columns.Add("% DCASA")

        'Tabla.Columns.Add("% FARINTER")
        Tabla.Columns.Add("% PURINA")
        Tabla.Columns.Add("% GRUPO ALZA")

        Tabla.Columns.Add("% CARIB")


        Tabla.Columns.Add("% DISAR")
    End Sub

    'Subrutina para limpiar los datos del grid
    Sub limpiar()
        For c = 0 To _GridCobertura.RowCount - 1
            Tabla.Clear()
        Next
    End Sub

    Private Sub CerrarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CerrarToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ExportarAExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportarAExcelToolStripMenuItem.Click
        Exportar()
    End Sub

    Sub Exportar()
        Try
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()
            wSheet.Name = "Hoja"
            style = wSheet.Application.ActiveWorkbook.Styles.Add("Reportes")
            style.Font.Bold = True
            style.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            style.Font.Size = 11
            style.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            wSheet.Cells.Range("A1:AE1").Merge()
            wSheet.Cells.Range("A1:AE1").Borders.LineStyle = BorderStyle.FixedSingle
            wSheet.Cells.Range("A1:AE1").Value = "Reporte de Coberturas del  " + _cmbFechaInicial.Value.Date + "  al  " + _cmbFechaFinal.Value.Date
            wSheet.Cells.Range("A1:AE1").Style = "Reportes"

            For c As Integer = 0 To _GridCobertura.Columns.Count - 1
                wSheet.Cells(2, c + 1).value = _GridCobertura.Columns(c).HeaderText
                wSheet.Cells(2, c + 1).Style = "Reportes"
            Next
            For r As Integer = 0 To _GridCobertura.RowCount - 1
                For c As Integer = 0 To _GridCobertura.Columns.Count - 1
                    wSheet.Cells(r + 3, c + 1).value = _GridCobertura.Item(c, r).Value
                    wSheet.Cells(r + 3, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    wSheet.Cells(r + 3, c + 1).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                    wSheet.Cells(r + 3, c + 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                Next
            Next
            wSheet.Columns.AutoFit()
            excel.Visible = True
            excel.Quit()
        Catch ex As Exception
            MessageBox.Show("Error al Exportar " + ex.ToString, "Problemas", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub EnviarACorreoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If activo = 1 Then
            CorreoAdjunto()
            Correo.DocAdjunto = "C:\Reportes\Coberturas\Reporte de Coberturas.XLSX"
            Correo._txtAsunto.Text = "Reporte de Coberturas de " + nombre
            Correo.Visible = True
        Else
            MsgBox("Aun no se han Generado los Datos", MsgBoxStyle.Information, "Informacion")
        End If

    End Sub

    Sub CorreoAdjunto()
        Try
            nombre = _cmbFechaInicial.Value.Date + " al " + _cmbFechaFinal.Value.Date
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()
            wSheet.Name = "Hoja"

            style = wSheet.Application.ActiveWorkbook.Styles.Add("Reportes")
            style.Font.Bold = True
            style.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            style.Font.Size = 14
            style.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            wSheet.Cells.Range("A1:O1").Merge()
            wSheet.Cells.Range("A1:O1").Borders.LineStyle = BorderStyle.FixedSingle
            wSheet.Cells.Range("A1:O1").Value = "Reporte de Coberturas del  " + _cmbFechaInicial.Value.Date + "  al  " + _cmbFechaFinal.Value.Date
            wSheet.Cells.Range("A1:O1").Style = "Reportes"

            For c As Integer = 0 To _GridCobertura.Columns.Count - 1
                wSheet.Cells(2, c + 1).value = _GridCobertura.Columns(c).HeaderText
                wSheet.Cells(2, c + 1).Style = "Reportes"
            Next
            For r As Integer = 0 To _GridCobertura.RowCount - 1
                For c As Integer = 0 To _GridCobertura.Columns.Count - 1
                    wSheet.Cells(r + 3, c + 1).value = _GridCobertura.Item(c, r).Value
                    wSheet.Cells(r + 3, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    wSheet.Cells(r + 3, c + 1).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                    wSheet.Cells(r + 3, c + 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                Next
            Next
            wSheet.Columns.AutoFit()
            wBook.SaveAs("C:\Reportes\Coberturas\Reporte de Coberturas.XLSX")
            excel.Quit()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub inicializardate()
        _cmbFechaInicial.Value = 1 & "/" & Now.Month & "/" & Now.Year
        If Now.Day = 1 Then
            _cmbFechaFinal.Value = Today
        Else
            _cmbFechaFinal.Value = DateAdd(DateInterval.Day, -1, Now)
        End If
    End Sub
End Class