Imports Disar.data

Public Class frm_ListaRemisiones

    Dim Conexion As New cls_remisiones
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
        cmb_sucursal.DataSource = Conexion.Sucursales
        cmb_sucursal.ValueMember = "SUCURSAL_ID"
        cmb_sucursal.DisplayMember = "DESCRIPCION"
    End Sub

    Private Sub NuevoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevoToolStripMenuItem.Click
        'Try
        frm_guia_remision.Close()
        frm_guia_remision.ShowDialog()
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
            grd_lista_remisiones.DataSource = Conexion.remision_encabezado(cmb_sucursal.SelectedValue, cmb_fecha_ini.Value.Date, cmb_fecha_fin.Value.Date)
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
            grdRemisionesPendientes.DataSource = Conexion.FILTRARPENDIENTES(_Inicio.Almacen, _Inicio.Empresa, Val(_Inicio.lblId.Text))

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
        Try
            If grdRemisionesPendientes.RowCount > 0 Then
                grdRemisionesPendientes.Visible = True
                Label4.Visible = True
            Else
                grdRemisionesPendientes.Visible = False
                Label4.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grd_lista_remisiones_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grd_lista_remisiones.CellMouseDoubleClick
        Try
            frm_guia_remision.Close()

            frm_guia_remision_detalles.txt_documento.Text = grd_lista_remisiones.CurrentRow.Cells(0).Value
            frm_guia_remision_detalles.txt_remite.Text = grd_lista_remisiones.CurrentRow.Cells(1).Value
            frm_guia_remision_detalles.txt_destino.Text = grd_lista_remisiones.CurrentRow.Cells(2).Value

            If Not IsDBNull(grd_lista_remisiones.CurrentRow.Cells(3).Value) Then
                frm_guia_remision_detalles.txt_transportista.Text = grd_lista_remisiones.CurrentRow.Cells(3).Value
            End If
            If Not IsDBNull(grd_lista_remisiones.CurrentRow.Cells(4).Value) Then
                frm_guia_remision_detalles.txt_motivo.Text = grd_lista_remisiones.CurrentRow.Cells(4).Value
            End If
            If Not IsDBNull(grd_lista_remisiones.CurrentRow.Cells(5).Value) Then
                frm_guia_remision_detalles.txt_vehiculo.Text = grd_lista_remisiones.CurrentRow.Cells(5).Value
            End If
            If Not IsDBNull(grd_lista_remisiones.CurrentRow.Cells(6).Value) Then
                frm_guia_remision_detalles.txt_empresa.Text = grd_lista_remisiones.CurrentRow.Cells(6).Value
            End If
            If Not IsDBNull(grd_lista_remisiones.CurrentRow.Cells(7).Value) Then
                frm_guia_remision_detalles.cmb_fecha_inicio.Value = grd_lista_remisiones.CurrentRow.Cells(7).Value
            End If
            If Not IsDBNull(grd_lista_remisiones.CurrentRow.Cells(8).Value) Then
                frm_guia_remision_detalles.cmb_fecha_final.Value = grd_lista_remisiones.CurrentRow.Cells(8).Value
            End If
            If Not IsDBNull(grd_lista_remisiones.CurrentRow.Cells(9).Value) Then
                frm_guia_remision_detalles.txt_cai.Text = grd_lista_remisiones.CurrentRow.Cells(9).Value
            End If
            If Not IsDBNull(grd_lista_remisiones.CurrentRow.Cells(10).Value) Then
                frm_guia_remision_detalles.rtn_remite = grd_lista_remisiones.CurrentRow.Cells(10).Value
            End If
            If Not IsDBNull(grd_lista_remisiones.CurrentRow.Cells(11).Value) Then
                frm_guia_remision_detalles.direccion_remite = grd_lista_remisiones.CurrentRow.Cells(11).Value
            End If
            If Not IsDBNull(grd_lista_remisiones.CurrentRow.Cells(12).Value) Then
                frm_guia_remision_detalles.rtn_destino = grd_lista_remisiones.CurrentRow.Cells(12).Value
            End If
            If Not IsDBNull(grd_lista_remisiones.CurrentRow.Cells(13).Value) Then
                frm_guia_remision_detalles.direccion_destino = grd_lista_remisiones.CurrentRow.Cells(13).Value
            End If
            If Not IsDBNull(grd_lista_remisiones.CurrentRow.Cells(14).Value) Then
                frm_guia_remision_detalles.rtn_transportista = grd_lista_remisiones.CurrentRow.Cells(14).Value
            End If
            If Not IsDBNull(grd_lista_remisiones.CurrentRow.Cells(15).Value) Then
                frm_guia_remision_detalles.marca = grd_lista_remisiones.CurrentRow.Cells(15).Value
            End If
            If Not IsDBNull(grd_lista_remisiones.CurrentRow.Cells(16).Value) Then
                frm_guia_remision_detalles.placa = grd_lista_remisiones.CurrentRow.Cells(16).Value
            End If
            If Not IsDBNull(grd_lista_remisiones.CurrentRow.Cells(17).Value) Then
                frm_guia_remision_detalles.rango = grd_lista_remisiones.CurrentRow.Cells(17).Value
            End If
            If Not IsDBNull(grd_lista_remisiones.CurrentRow.Cells(18).Value) Then
                frm_guia_remision_detalles.fecha_limite = grd_lista_remisiones.CurrentRow.Cells(18).Value
            End If
            If Not IsDBNull(grd_lista_remisiones.CurrentRow.Cells(19).Value) Then
                frm_guia_remision_detalles.txt_peso_total.Text = grd_lista_remisiones.CurrentRow.Cells(19).Value
            End If
            If Not IsDBNull(grd_lista_remisiones.CurrentRow.Cells("ESTADO").Value) Then
                frm_guia_remision_detalles.TxtEstadoRem.Text = grd_lista_remisiones.CurrentRow.Cells("ESTADO").Value
            End If
            If Not IsDBNull(grd_lista_remisiones.CurrentRow.Cells("ALMACÉN").Value) Then
                Almacen = grd_lista_remisiones.CurrentRow.Cells("ALMACÉN").Value
            End If

            'frm_guia_remision_detalles.CODREM = grdRemisionesPendientes.CurrentRow.Cells("CODREM").Value
            'frm_guia_remision_detalles.CODDEST = grdRemisionesPendientes.CurrentRow.Cells("CODDEST").Value

            frm_guia_remision_detalles.BtnCompletarRemision.Visible = False
            frm_guia_remision_detalles.BtnDevolver.Visible = False
            frm_guia_remision_detalles.TipoRemision = "Revisar"
            frm_guia_remision_detalles.ShowDialog()

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
        frm_reporte_remisiones.Close()
        frm_reporte_remisiones.ShowDialog()
    End Sub

    Private Sub NuevoPapeleriaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevoPapeleriaToolStripMenuItem.Click
        'Try
        frm_guia_remision_papeleria.Close()
        frm_guia_remision_papeleria.ShowDialog()
        cargar()
        'Catch ex As Exception
        'MessageBox.Show(ex.Message)
        'End Try
    End Sub

    Private Sub grdRemisionesPendientes_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdRemisionesPendientes.CellDoubleClick
        Try
            frm_guia_remision.Close()

            frm_guia_remision_detalles.txt_documento.Text = grdRemisionesPendientes.CurrentRow.Cells(0).Value
            frm_guia_remision_detalles.txt_remite.Text = grdRemisionesPendientes.CurrentRow.Cells(1).Value
            frm_guia_remision_detalles.txt_destino.Text = grdRemisionesPendientes.CurrentRow.Cells(2).Value

            If Not IsDBNull(grdRemisionesPendientes.CurrentRow.Cells(3).Value) Then
                frm_guia_remision_detalles.txt_transportista.Text = grdRemisionesPendientes.CurrentRow.Cells(3).Value
            End If
            If Not IsDBNull(grdRemisionesPendientes.CurrentRow.Cells(4).Value) Then
                frm_guia_remision_detalles.txt_motivo.Text = grdRemisionesPendientes.CurrentRow.Cells(4).Value
            End If
            If Not IsDBNull(grdRemisionesPendientes.CurrentRow.Cells(5).Value) Then
                frm_guia_remision_detalles.txt_vehiculo.Text = grdRemisionesPendientes.CurrentRow.Cells(5).Value
            End If
            If Not IsDBNull(grdRemisionesPendientes.CurrentRow.Cells(6).Value) Then
                frm_guia_remision_detalles.txt_empresa.Text = grdRemisionesPendientes.CurrentRow.Cells(6).Value
            End If
            If Not IsDBNull(grdRemisionesPendientes.CurrentRow.Cells(7).Value) Then
                frm_guia_remision_detalles.cmb_fecha_inicio.Value = grdRemisionesPendientes.CurrentRow.Cells(7).Value
            End If
            If Not IsDBNull(grdRemisionesPendientes.CurrentRow.Cells(8).Value) Then
                frm_guia_remision_detalles.cmb_fecha_final.Value = grdRemisionesPendientes.CurrentRow.Cells(8).Value
            End If
            If Not IsDBNull(grdRemisionesPendientes.CurrentRow.Cells(9).Value) Then
                frm_guia_remision_detalles.txt_cai.Text = grdRemisionesPendientes.CurrentRow.Cells(9).Value
            End If
            If Not IsDBNull(grdRemisionesPendientes.CurrentRow.Cells(10).Value) Then
                frm_guia_remision_detalles.rtn_remite = grdRemisionesPendientes.CurrentRow.Cells(10).Value
            End If
            If Not IsDBNull(grdRemisionesPendientes.CurrentRow.Cells(11).Value) Then
                frm_guia_remision_detalles.direccion_remite = grdRemisionesPendientes.CurrentRow.Cells(11).Value
            End If
            If Not IsDBNull(grdRemisionesPendientes.CurrentRow.Cells(12).Value) Then
                frm_guia_remision_detalles.rtn_destino = grdRemisionesPendientes.CurrentRow.Cells(12).Value
            End If
            If Not IsDBNull(grdRemisionesPendientes.CurrentRow.Cells(13).Value) Then
                frm_guia_remision_detalles.direccion_destino = grdRemisionesPendientes.CurrentRow.Cells(13).Value
            End If
            If Not IsDBNull(grdRemisionesPendientes.CurrentRow.Cells(14).Value) Then
                frm_guia_remision_detalles.rtn_transportista = grdRemisionesPendientes.CurrentRow.Cells(14).Value
            End If
            If Not IsDBNull(grdRemisionesPendientes.CurrentRow.Cells(15).Value) Then
                frm_guia_remision_detalles.marca = grdRemisionesPendientes.CurrentRow.Cells(15).Value
            End If
            If Not IsDBNull(grdRemisionesPendientes.CurrentRow.Cells(16).Value) Then
                frm_guia_remision_detalles.placa = grdRemisionesPendientes.CurrentRow.Cells(16).Value
            End If
            If Not IsDBNull(grdRemisionesPendientes.CurrentRow.Cells(17).Value) Then
                frm_guia_remision_detalles.rango = grdRemisionesPendientes.CurrentRow.Cells(17).Value
            End If
            If Not IsDBNull(grdRemisionesPendientes.CurrentRow.Cells(18).Value) Then
                frm_guia_remision_detalles.fecha_limite = grdRemisionesPendientes.CurrentRow.Cells(18).Value
            End If
            If Not IsDBNull(grdRemisionesPendientes.CurrentRow.Cells(19).Value) Then
                frm_guia_remision_detalles.txt_peso_total.Text = grdRemisionesPendientes.CurrentRow.Cells(19).Value
            End If
            If Not IsDBNull(grdRemisionesPendientes.CurrentRow.Cells("ESTADO").Value) Then
                frm_guia_remision_detalles.TxtEstadoRem.Text = grdRemisionesPendientes.CurrentRow.Cells("ESTADO").Value
            End If
            Almacen = grdRemisionesPendientes.CurrentRow.Cells("ALMACÉN").Value
            frm_guia_remision_detalles.CODREM = grdRemisionesPendientes.CurrentRow.Cells("CODREM").Value
            frm_guia_remision_detalles.CODDEST = grdRemisionesPendientes.CurrentRow.Cells("CODDEST").Value

            If _Inicio.AceptaRemisiones = 1 Then
                frm_guia_remision_detalles.BtnCompletarRemision.Visible = True
                frm_guia_remision_detalles.BtnDevolver.Visible = True
                frm_guia_remision_detalles.TipoRemision = "Completar"
            Else
                frm_guia_remision_detalles.BtnCompletarRemision.Visible = False
                frm_guia_remision_detalles.BtnDevolver.Visible = False
                frm_guia_remision_detalles.TipoRemision = "Visualizar"
            End If
            frm_guia_remision_detalles.ShowDialog()



        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    
End Class