Imports Disar.data
Public Class Frm_ListaConsignacionesDimosa

    Dim Conexion As New cls_remisiones
    Dim Conex As New ClsConsignaciones
    Public Almacen As Integer

    Private Sub frm_ListaRemisiones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            cargar_sucursal()
            cargar()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub cargar_sucursal()
        cmb_sucursal.DataSource = Conexion.SucursalesDIMOSA
        cmb_sucursal.ValueMember = "SUCURSAL_ID"
        cmb_sucursal.DisplayMember = "DESCRIPCION"
    End Sub

    Private Sub NuevoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevoToolStripMenuItem.Click
        'Try
        FrmNuevaConsignacionDimosa.Close()
        FrmNuevaConsignacionDimosa.ShowDialog()
        cargar()
        'Catch ex As Exception
        'MessageBox.Show(ex.Message)
        'End Try
    End Sub

    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        cargar()
    End Sub

    Sub cargar()
        Try
            grd_lista_remisiones.DataSource = Conex.remision_encabezado(cmb_sucursal.SelectedValue, cmb_fecha_ini.Value.Date, cmb_fecha_fin.Value.Date)
            grd_lista_remisiones.Columns(6).Visible = False
            grd_lista_remisiones.Columns(7).Visible = False
            grd_lista_remisiones.Columns(8).Visible = False
            grd_lista_remisiones.Columns(9).Visible = False
            grd_lista_remisiones.Columns(10).Visible = False
            grd_lista_remisiones.Columns(11).Visible = False
            grd_lista_remisiones.Columns(12).Visible = False
            grd_lista_remisiones.Columns(13).Visible = False
            grd_lista_remisiones.Columns(14).Visible = False
            grd_lista_remisiones.Columns(15).Visible = False
            grd_lista_remisiones.Columns(16).Visible = False
            grd_lista_remisiones.Columns(17).Visible = False
            grd_lista_remisiones.Columns(18).Visible = False
            grd_lista_remisiones.Columns(19).Visible = False
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try
        Try
            grdRemisionesPendientes.DataSource = Conex.FILTRARPENDIENTES(_Inicio.Almacen, _Inicio.Empresa, Val(_Inicio.lblId.Text))

            grdRemisionesPendientes.Columns(6).Visible = False
            grdRemisionesPendientes.Columns(7).Visible = False
            grdRemisionesPendientes.Columns(8).Visible = False
            grdRemisionesPendientes.Columns(9).Visible = False
            grdRemisionesPendientes.Columns(10).Visible = False
            grdRemisionesPendientes.Columns(11).Visible = False
            grdRemisionesPendientes.Columns(12).Visible = False
            grdRemisionesPendientes.Columns(13).Visible = False
            grdRemisionesPendientes.Columns(14).Visible = False
            grdRemisionesPendientes.Columns(15).Visible = False
            grdRemisionesPendientes.Columns(16).Visible = False
            grdRemisionesPendientes.Columns(17).Visible = False
            grdRemisionesPendientes.Columns(18).Visible = False
            grdRemisionesPendientes.Columns(19).Visible = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grd_lista_remisiones_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grd_lista_remisiones.CellMouseDoubleClick
        Try
            FrmConsignacion.Close()

            FrmConsignacionDimosa.txt_documento.Text = grd_lista_remisiones.CurrentRow.Cells(0).Value
            FrmConsignacionDimosa.txt_remite.Text = grd_lista_remisiones.CurrentRow.Cells(1).Value
            FrmConsignacionDimosa.txt_destino.Text = grd_lista_remisiones.CurrentRow.Cells(2).Value
            FrmConsignacionDimosa.TextClienteClave.Text = grd_lista_remisiones.CurrentRow.Cells("CLAVE").Value

            If Not IsDBNull(grd_lista_remisiones.CurrentRow.Cells(3).Value) Then
                FrmConsignacionDimosa.txt_transportista.Text = grd_lista_remisiones.CurrentRow.Cells(3).Value
            End If
            If Not IsDBNull(grd_lista_remisiones.CurrentRow.Cells(4).Value) Then
                FrmConsignacionDimosa.txt_motivo.Text = grd_lista_remisiones.CurrentRow.Cells(4).Value
            End If
            If Not IsDBNull(grd_lista_remisiones.CurrentRow.Cells(5).Value) Then
                FrmConsignacionDimosa.txt_vehiculo.Text = grd_lista_remisiones.CurrentRow.Cells(5).Value
            End If
            If Not IsDBNull(grd_lista_remisiones.CurrentRow.Cells(6).Value) Then
                FrmConsignacionDimosa.txt_empresa.Text = grd_lista_remisiones.CurrentRow.Cells(6).Value
            End If
            If Not IsDBNull(grd_lista_remisiones.CurrentRow.Cells(7).Value) Then
                FrmConsignacionDimosa.cmb_fecha_inicio.Value = grd_lista_remisiones.CurrentRow.Cells(7).Value
            End If
            If Not IsDBNull(grd_lista_remisiones.CurrentRow.Cells(8).Value) Then
                FrmConsignacionDimosa.cmb_fecha_final.Value = grd_lista_remisiones.CurrentRow.Cells(8).Value
            End If
            If Not IsDBNull(grd_lista_remisiones.CurrentRow.Cells(9).Value) Then
                FrmConsignacionDimosa.txt_cai.Text = grd_lista_remisiones.CurrentRow.Cells(9).Value
            End If
            If Not IsDBNull(grd_lista_remisiones.CurrentRow.Cells(10).Value) Then
                FrmConsignacionDimosa.rtn_remite = grd_lista_remisiones.CurrentRow.Cells(10).Value
            End If
            If Not IsDBNull(grd_lista_remisiones.CurrentRow.Cells(11).Value) Then
                FrmConsignacionDimosa.direccion_remite = grd_lista_remisiones.CurrentRow.Cells(11).Value
            End If
            If Not IsDBNull(grd_lista_remisiones.CurrentRow.Cells(12).Value) Then
                FrmConsignacionDimosa.rtn_destino = grd_lista_remisiones.CurrentRow.Cells(12).Value
            End If
            If Not IsDBNull(grd_lista_remisiones.CurrentRow.Cells(13).Value) Then
                FrmConsignacionDimosa.direccion_destino = grd_lista_remisiones.CurrentRow.Cells(13).Value
            End If
            If Not IsDBNull(grd_lista_remisiones.CurrentRow.Cells(14).Value) Then
                FrmConsignacionDimosa.rtn_transportista = grd_lista_remisiones.CurrentRow.Cells(14).Value
            End If
            If Not IsDBNull(grd_lista_remisiones.CurrentRow.Cells(15).Value) Then
                FrmConsignacionDimosa.marca = grd_lista_remisiones.CurrentRow.Cells(15).Value
            End If
            If Not IsDBNull(grd_lista_remisiones.CurrentRow.Cells(16).Value) Then
                FrmConsignacionDimosa.placa = grd_lista_remisiones.CurrentRow.Cells(16).Value
            End If
            If Not IsDBNull(grd_lista_remisiones.CurrentRow.Cells(17).Value) Then
                FrmConsignacionDimosa.rango = grd_lista_remisiones.CurrentRow.Cells(17).Value
            End If
            If Not IsDBNull(grd_lista_remisiones.CurrentRow.Cells(18).Value) Then
                FrmConsignacionDimosa.fecha_limite = grd_lista_remisiones.CurrentRow.Cells(18).Value
            End If
            If Not IsDBNull(grd_lista_remisiones.CurrentRow.Cells(19).Value) Then
                FrmConsignacionDimosa.txt_peso_total.Text = grd_lista_remisiones.CurrentRow.Cells(19).Value
            End If
            If Not IsDBNull(grd_lista_remisiones.CurrentRow.Cells("ESTADO").Value) Then
                FrmConsignacionDimosa.TxtEstadoRem.Text = grd_lista_remisiones.CurrentRow.Cells("ESTADO").Value
            End If
            If Not IsDBNull(grd_lista_remisiones.CurrentRow.Cells("ALMACÉN").Value) Then
                Almacen = grd_lista_remisiones.CurrentRow.Cells("ALMACÉN").Value
            End If
            FrmConsignacionDimosa.CODREM = grd_lista_remisiones.CurrentRow.Cells("CODREM").Value
            'frm_guia_remision_detalles.CODREM = grdRemisionesPendientes.CurrentRow.Cells("CODREM").Value
            'frm_guia_remision_detalles.CODDEST = grdRemisionesPendientes.CurrentRow.Cells("CODDEST").Value

            FrmConsignacionDimosa.BtnCompletarRemision.Visible = False
            FrmConsignacionDimosa.BtnCancelar.Visible = False
            FrmConsignacionDimosa.TipoRemision = "Revisar"
            FrmConsignacionDimosa.ShowDialog()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub cmb_sucursal_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_sucursal.SelectedIndexChanged
        Try
            cargar()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ReporteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReporteToolStripMenuItem.Click
        frm_reporte_consignaciones_dimosa.Close()
        frm_reporte_consignaciones_dimosa.ShowDialog()
    End Sub

    Private Sub grdRemisionesPendientes_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdRemisionesPendientes.CellDoubleClick
        Try
            FrmConsignacionDimosa.Close()

            FrmConsignacionDimosa.txt_documento.Text = grdRemisionesPendientes.CurrentRow.Cells(0).Value
            FrmConsignacionDimosa.txt_remite.Text = grdRemisionesPendientes.CurrentRow.Cells(1).Value
            FrmConsignacionDimosa.txt_destino.Text = grdRemisionesPendientes.CurrentRow.Cells(2).Value
            FrmConsignacionDimosa.TextClienteClave.Text = grdRemisionesPendientes.CurrentRow.Cells("CLAVE").Value

            If Not IsDBNull(grdRemisionesPendientes.CurrentRow.Cells(3).Value) Then
                FrmConsignacionDimosa.txt_transportista.Text = grdRemisionesPendientes.CurrentRow.Cells(3).Value
            End If
            If Not IsDBNull(grdRemisionesPendientes.CurrentRow.Cells(4).Value) Then
                FrmConsignacionDimosa.txt_motivo.Text = grdRemisionesPendientes.CurrentRow.Cells(4).Value
            End If
            If Not IsDBNull(grdRemisionesPendientes.CurrentRow.Cells(5).Value) Then
                FrmConsignacionDimosa.txt_vehiculo.Text = grdRemisionesPendientes.CurrentRow.Cells(5).Value
            End If
            If Not IsDBNull(grdRemisionesPendientes.CurrentRow.Cells(6).Value) Then
                FrmConsignacionDimosa.txt_empresa.Text = grdRemisionesPendientes.CurrentRow.Cells(6).Value
            End If
            If Not IsDBNull(grdRemisionesPendientes.CurrentRow.Cells(7).Value) Then
                FrmConsignacionDimosa.cmb_fecha_inicio.Value = grdRemisionesPendientes.CurrentRow.Cells(7).Value
            End If
            If Not IsDBNull(grdRemisionesPendientes.CurrentRow.Cells(8).Value) Then
                FrmConsignacionDimosa.cmb_fecha_final.Value = grdRemisionesPendientes.CurrentRow.Cells(8).Value
            End If
            If Not IsDBNull(grdRemisionesPendientes.CurrentRow.Cells(9).Value) Then
                FrmConsignacionDimosa.txt_cai.Text = grdRemisionesPendientes.CurrentRow.Cells(9).Value
            End If
            If Not IsDBNull(grdRemisionesPendientes.CurrentRow.Cells(10).Value) Then
                FrmConsignacionDimosa.rtn_remite = grdRemisionesPendientes.CurrentRow.Cells(10).Value
            End If
            If Not IsDBNull(grdRemisionesPendientes.CurrentRow.Cells(11).Value) Then
                FrmConsignacionDimosa.direccion_remite = grdRemisionesPendientes.CurrentRow.Cells(11).Value
            End If
            If Not IsDBNull(grdRemisionesPendientes.CurrentRow.Cells(12).Value) Then
                FrmConsignacionDimosa.rtn_destino = grdRemisionesPendientes.CurrentRow.Cells(12).Value
            End If
            If Not IsDBNull(grdRemisionesPendientes.CurrentRow.Cells(13).Value) Then
                FrmConsignacionDimosa.direccion_destino = grdRemisionesPendientes.CurrentRow.Cells(13).Value
            End If
            If Not IsDBNull(grdRemisionesPendientes.CurrentRow.Cells(14).Value) Then
                FrmConsignacionDimosa.rtn_transportista = grdRemisionesPendientes.CurrentRow.Cells(14).Value
            End If
            If Not IsDBNull(grdRemisionesPendientes.CurrentRow.Cells(15).Value) Then
                FrmConsignacionDimosa.marca = grdRemisionesPendientes.CurrentRow.Cells(15).Value
            End If
            If Not IsDBNull(grdRemisionesPendientes.CurrentRow.Cells(16).Value) Then
                FrmConsignacionDimosa.placa = grdRemisionesPendientes.CurrentRow.Cells(16).Value
            End If
            If Not IsDBNull(grdRemisionesPendientes.CurrentRow.Cells(17).Value) Then
                FrmConsignacionDimosa.rango = grdRemisionesPendientes.CurrentRow.Cells(17).Value
            End If
            If Not IsDBNull(grdRemisionesPendientes.CurrentRow.Cells(18).Value) Then
                FrmConsignacionDimosa.fecha_limite = grdRemisionesPendientes.CurrentRow.Cells(18).Value
            End If
            If Not IsDBNull(grdRemisionesPendientes.CurrentRow.Cells(19).Value) Then
                FrmConsignacionDimosa.txt_peso_total.Text = grdRemisionesPendientes.CurrentRow.Cells(19).Value
            End If
            If Not IsDBNull(grdRemisionesPendientes.CurrentRow.Cells("ESTADO").Value) Then
                FrmConsignacionDimosa.TxtEstadoRem.Text = grdRemisionesPendientes.CurrentRow.Cells("ESTADO").Value
            End If
            Almacen = grdRemisionesPendientes.CurrentRow.Cells("ALMACÉN").Value
            FrmConsignacionDimosa.CODREM = grdRemisionesPendientes.CurrentRow.Cells("CODREM").Value

            FrmConsignacionDimosa.BtnCompletarRemision.Visible = True
            FrmConsignacionDimosa.BtnCancelar.Visible = True
            FrmConsignacionDimosa.TipoRemision = "Completar"
            FrmConsignacionDimosa.ShowDialog()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


End Class