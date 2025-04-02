Imports Disar.data

Public Class frmPromociones_Principal

    Private Sub frmPromociones_Principal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtAlmacen.Text = _Inicio.Almacen
        txtEmpresa.Text = _Inicio.Empresa
        Try
            Dim Pro As New Cls_PromocionesInfo
            GrillaPromos.DataSource = Pro.MostrarMovimientos(txtEmpresa.Text, txtAlmacen.Text, Today, Today)
        Catch ex As Exception
        End Try
        Try
            If _Inicio.lblUsuario.Text = "Administrador" Or _Inicio.Almacen = 99 Then
                txtAlmacen.Text = " --- "
                ComboAlmacen.Visible = True
                elabel.Visible = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFiltra.Click
        GrpFiltro.Visible = True
    End Sub

    Private Sub NuevaCargaDePromociónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevaCargaDePromociónToolStripMenuItem.Click
        If frmNuevaPromo.Visible = True Then
            frmNuevaPromo.BringToFront()
        Else
            frmNuevaPromo.MdiParent = _Inicio
            frmNuevaPromo.Show()
        End If
        frmNuevaPromo.Tipo = txtEmpresa.Text
        frmNuevaPromo.Almacen = txtAlmacen.Text
    End Sub

    Private Sub NuevaCargaDeProductoDesdePromociónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevaCargaDeProductoDesdePromociónToolStripMenuItem.Click
        If frmPromo_A_Producto.Visible = True Then
            frmPromo_A_Producto.BringToFront()
        Else
            frmPromo_A_Producto.MdiParent = _Inicio
            frmPromo_A_Producto.Show()
        End If
        frmPromo_A_Producto.Tipo = txtEmpresa.Text
        frmPromo_A_Producto.Almacen = txtAlmacen.Text
    End Sub

    Private Sub BtnFiltro_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFiltro.Click
        Try
            Dim PRO As New Cls_PromocionesInfo
            GrillaPromos.DataSource = PRO.MostrarMovimientos(txtEmpresa.Text, txtAlmacen.Text, DateTimePicker1.Value, DateTimePicker2.Value)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ComboAlmacen_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboAlmacen.SelectedIndexChanged
        txtAlmacen.Text = ComboAlmacen.Text
    End Sub

    Private Sub TrasladoDePromociónAPromociónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrasladoDePromociónAPromociónToolStripMenuItem.Click
        If FormPromoAPromo.Visible = True Then
            FormPromoAPromo.BringToFront()
        Else
            FormPromoAPromo.MdiParent = _Inicio
            FormPromoAPromo.Show()
        End If
        FormPromoAPromo.Tipo = txtEmpresa.Text
        FormPromoAPromo.Almacen = txtAlmacen.Text
    End Sub

    Private Sub ComboEmpresa_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboEmpresa.SelectedIndexChanged
        txtEmpresa.Text = ComboEmpresa.Text
    End Sub
End Class