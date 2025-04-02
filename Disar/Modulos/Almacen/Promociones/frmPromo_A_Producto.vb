Imports Disar.data

Public Class frmPromo_A_Producto

    Dim Stock As Decimal
    Dim CantidadConversion As Integer

    Dim UnidadProductoInicial As String
    Dim UnidadPromocionInicial As String
    Public Tipo As String
    Public Almacen As Integer

    Private Sub BtnBuscaPromo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscaPromo.Click
        frm_productos_almacen.Close()
        frm_productos_almacen.Almacen = Almacen
        frm_productos_almacen.Empresa = Tipo

        If frm_productos_almacen.ShowDialog = Windows.Forms.DialogResult.OK Then

            Dim Codigo As String = frm_productos_almacen.columna1
            Dim Largo As Integer = Codigo.Length - 1
            Dim Nombre As String = frm_productos_almacen.columna2
            Stock = frm_productos_almacen.columnastock

            If Codigo.Chars(Largo) = "P" Or Codigo.Chars(Largo - 1) = "P" Or Nombre.Substring(0, 3) = "PRM" Then
                TxtCodigoPromo.Text = frm_productos_almacen.columna1
                TxtDescripcionPromo.Text = frm_productos_almacen.columna2
                TxtLotePromo.Text = frm_productos_almacen.columna4

                TxtCantidadEntrada.Enabled = True
                BtnAgregar.Enabled = True
                TxtCantidadSalida.Enabled = True

                Dim Pro As New Cls_PromocionesInfo
                Dim dt As New DataTable
                dt = Pro.InformacionProd(TxtCodigoPromo.Text)
                Try
                    TxtUnidadEntrada.Text = dt(0)(3)
                Catch ex As Exception
                End Try


                BtnBuscaProducto.Enabled = True
                LlenarConceptos()

            Else
                MsgBox("No se puede cargar un producto en la sección de promociones.", MsgBoxStyle.Information, "Atención")
            End If

        End If
    End Sub

    Private Sub BtnBuscaProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscaProducto.Click

        CantidadConversion = 0

        frm_productos_almacen.Close()
        frm_productos_almacen.Almacen = Almacen
        frm_productos_almacen.Empresa = Tipo

        If frm_productos_almacen.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim Codigo As String = frm_productos_almacen.columna1
            Dim Nombre As String = frm_productos_almacen.columna2
            Dim Largo As Integer = Codigo.Length - 1

            Dim Pro As New Cls_PromocionesInfo
            Dim dt As New DataTable
            dt = Pro.InformacionProd(TxtCodigoProd.Text)
            Try
                ComboUnidadProducto.Items.Add(dt(0)(3))
            Catch ex As Exception
            End Try

            Try
                ComboUnidadProducto.SelectedItem = dt(0)(1)
            Catch ex As Exception
            End Try

            If Codigo.Chars(Largo) = "P" Or Codigo.Chars(Largo - 1) = "P" Or Nombre.Substring(0, 3) = "PRM" Then
                MsgBox("No se puede cargar una promoción en la sección de producto.", MsgBoxStyle.Information, "Atención")
            Else

                TxtCodigoProd.Text = frm_productos_almacen.columna1
                TxtDescripcion.Text = frm_productos_almacen.columna2
                TxtLoteProducto.Text = frm_productos_almacen.columna4

                Try
                    UnidadProductoInicial = dt(0)(1)
                Catch ex As Exception

                End Try


            End If
        End If
    End Sub

    Sub LlenarConceptos()
        Try
            Dim db As New Cls_PromocionesInfo

            If Tipo = "SAN RAFAEL" Then
                ComboConcepto.DataSource = db.LlenaConceptos
            ElseIf Tipo = "SR AGRO" Then
                ComboConcepto.DataSource = db.LlenaConceptosAgro
            Else
                ComboConcepto.DataSource = db.LlenaConceptosDIMOSA
            End If

            ComboConcepto.ValueMember = "concepto_prov_id"
            ComboConcepto.DisplayMember = "concepto_proveedor"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtCantidadEntrada_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCantidadEntrada.TextChanged

        If Val(TxtCantidadEntrada.Text) > Stock Then
            MsgBox("La cantidad a registrar no puede ser mayor que la cantidad en inventario, se establecerá el stock como cantidad de traspaso.", MsgBoxStyle.Information, "Atención")
            TxtCantidadEntrada.Text = Stock
        Else
            TxtCantidadSalida.Text = TxtCantidadEntrada.Text
        End If

    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        Dim Cantidad As Decimal
        If Cantidad <= Stock Then
            grd_detalles.Rows.Add(TxtDescripcionPromo.Text, TxtCodigoPromo.Text, TxtCantidadEntrada.Text, TxtUnidadEntrada.Text, TxtLotePromo.Text, TxtCodigoProd.Text, TxtCantidadSalida.Text, TxtUnidadEntrada.Text, TxtLoteProducto.Text, ComboConcepto.SelectedValue)
            TxtCodigoProd.Text = ""
            TxtCodigoPromo.Text = ""
            TxtDescripcion.Text = ""
            TxtDescripcionPromo.Text = ""
            TxtCantidadSalida.Text = ""
            TxtCantidadEntrada.Text = ""
            TxtLoteProducto.Text = ""
            TxtLotePromo.Text = ""
            TxtUnidadEntrada.Text = ""
            ComboConcepto.DataSource = Nothing
        Else
            MsgBox("La cantidad ingresada para cargar a la promoción supera a las existencias en inventario.", MsgBoxStyle.Critical, "Error")
        End If

    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click

        Dim dt As New DataTable

        For i As Integer = 0 To grd_detalles.ColumnCount - 1
            dt.Columns.Add(grd_detalles.Columns(i).HeaderText)
        Next
        For j As Integer = 0 To grd_detalles.Rows.Count - 1
            If grd_detalles.Rows(j).Cells(1).Value = "" Then
            Else
                Dim fila_detalle As DataRow = dt.NewRow
                For h As Integer = 0 To grd_detalles.ColumnCount - 1
                    fila_detalle(grd_detalles.Columns(h).HeaderText) = grd_detalles.Rows(j).Cells(h).Value
                Next
                dt.Rows.Add(fila_detalle)
            End If
        Next
        If Tipo = "SAN RAFAEL" Then
            Try
                Dim Pro As New Cls_PromocionesInfo
                Dim Mensaje As String = Pro.GuardarPromocionesAProducto(dt, _Inicio.lblUsuario.Text, "SAN RAFAEL", Almacen)
                If Mensaje = "correcto" Then
                    MsgBox("Los movimientos se han realizado exitosamente.", MsgBoxStyle.Information, "Aviso")
                    frmPromociones_Principal.BtnFiltro.PerformClick()
                    Me.Close()
                Else
                    MsgBox("Se produjo un problema al intentar guardar los movimientos. " & Mensaje, MsgBoxStyle.Information, "Aviso")
                End If
            Catch ex As Exception
                MsgBox("Se produjo un problema al intentar guardar los movimientos.", MsgBoxStyle.Information, "Aviso")
            End Try
        End If
        If Tipo = "DIMOSA" Then
            Try
                Dim Pro As New Cls_PromocionesInfo
                Dim Mensaje As String = Pro.GuardarPromocionesAProductoDIMOSA(dt, _Inicio.lblUsuario.Text, "DIMOSA", Almacen)
                If Mensaje = "correcto" Then
                    MsgBox("Los movimientos se han realizado exitosamente.", MsgBoxStyle.Information, "Aviso")
                    frmPromociones_Principal.BtnFiltro.PerformClick()
                    Me.Close()
                Else
                    MsgBox("Se produjo un problema al intentar guardar los movimientos. " & Mensaje, MsgBoxStyle.Information, "Aviso")
                End If
            Catch ex As Exception
                MsgBox("Se produjo un problema al intentar guardar los movimientos.", MsgBoxStyle.Information, "Aviso")
            End Try
        End If

        If Tipo = "SR AGRO" Then
            Try
                Dim Pro As New Cls_PromocionesInfo
                Dim Mensaje As String = Pro.GuardarPromocionesAProductoAGRO(dt, _Inicio.lblUsuario.Text, "SR AGRO", Almacen)
                If Mensaje = "correcto" Then
                    MsgBox("Los movimientos se han realizado exitosamente.", MsgBoxStyle.Information, "Aviso")
                    frmPromociones_Principal.BtnFiltro.PerformClick()
                    Me.Close()
                Else
                    MsgBox("Se produjo un problema al intentar guardar los movimientos. " & Mensaje, MsgBoxStyle.Information, "Aviso")
                End If
            Catch ex As Exception
                MsgBox("Se produjo un problema al intentar guardar los movimientos.", MsgBoxStyle.Information, "Aviso")
            End Try
        End If
    End Sub

    Private Sub BtnLotes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLotes.Click
        Dim Cadena As String
        Cadena = ""
        If grd_detalles.RowCount > 0 Then
            For Each row As DataGridViewRow In grd_detalles.Rows
                Cadena = Cadena & "'" & row.Cells(1).Value & "'"
                If row.Index < grd_detalles.RowCount - 1 Then
                    Cadena &= ","
                End If
            Next
        End If

        Dim db As New Cls_PromocionesInfo
        If Tipo = "SAN RAFAEL" Then
            FrmLotes.DataDatos.DataSource = db.LlenaLotes(Almacen, Cadena)
        Else
            FrmLotes.DataDatos.DataSource = db.LlenaLotesDIMOSA(Almacen, Cadena)
        End If

        FrmLotes.ShowDialog()
    End Sub

End Class