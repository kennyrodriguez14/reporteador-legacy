Imports Disar.data
Public Class frm_productos_almacen
    Dim conexion As New cls_listado_productos
    Public Almacen As Integer
    Public Empresa As String
    Public columna1 As String = "", columna2 As String = "", columna3 As String = "", columna4 As String = "", columnastock As Decimal

    Private Sub frm_productos_almacen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            cmb_tipo_filtro.SelectedItem = "Descripcion"
            cmb_flota.SelectedItem = "Consumo"
            If Empresa = "CONSUMO" Or Empresa = "DIMOSA" Then
                cmb_flota.Visible = False 'True
                lbl_empresa.Visible = False 'True
            Else
                cmb_flota.Visible = False
                lbl_empresa.Visible = False
            End If

            If Empresa = "CONSUMO" Or Empresa = "SAN RAFAEL" Then
                grd_productos.DataSource = conexion.buscar_por_desc_consumo(Almacen, txt_busqueda.Text, cmb_flota.SelectedItem)
            ElseIf Empresa = "SR AGRO" Then
                grd_productos.DataSource = conexion.buscar_por_desc_SRAGRO(Almacen, txt_busqueda.Text)
            ElseIf Empresa = "ADMON BIENES Y RECURSOS" Then
                grd_productos.DataSource = conexion.buscar_por_desc_BIENESYRECURSOS(Almacen, txt_busqueda.Text)
            ElseIf Empresa = "DIMOSA" Then
                grd_productos.DataSource = conexion.buscar_por_desc_dimosa(Almacen, txt_busqueda.Text, cmb_flota.SelectedItem)
            ElseIf Empresa = "FLOTA" Then
                grd_productos.DataSource = conexion.buscar_por_desc_flota_nueva(Almacen, txt_busqueda.Text)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        Try
            If cmb_tipo_filtro.SelectedItem = "Codigo" Then
                If Empresa = "CONSUMO" Or Empresa = "SAN RAFAEL" Then
                    grd_productos.DataSource = conexion.buscar_por_clave_consumo(Almacen, txt_busqueda.Text, cmb_flota.SelectedItem)
                ElseIf Empresa = "SR AGRO" Then
                    grd_productos.DataSource = conexion.buscar_por_clave_SRAGRO(Almacen, txt_busqueda.Text)
                ElseIf Empresa = "ADMON BIENES Y RECURSOS" Then
                    grd_productos.DataSource = conexion.buscar_por_clave_BIENESYRECURSOS(Almacen, txt_busqueda.Text)
                ElseIf Empresa = "DIMOSA" Then
                    grd_productos.DataSource = conexion.buscar_por_clave_dimosa(Almacen, txt_busqueda.Text, cmb_flota.SelectedItem)
                ElseIf Empresa = "FLOTA" Then
                    grd_productos.DataSource = conexion.buscar_por_clave_flota_nueva(Almacen, txt_busqueda.Text)
                End If
            End If

            If cmb_tipo_filtro.SelectedItem = "Descripcion" Then

                If Empresa = "CONSUMO" Or Empresa = "SAN RAFAEL" Then
                    grd_productos.DataSource = conexion.buscar_por_desc_consumo(Almacen, txt_busqueda.Text, cmb_flota.SelectedItem)
                ElseIf Empresa = "SR AGRO" Then
                    grd_productos.DataSource = conexion.buscar_por_desc_SRAGRO(Almacen, txt_busqueda.Text)
                ElseIf Empresa = "ADMON BIENES Y RECURSOS" Then
                    grd_productos.DataSource = conexion.buscar_por_desc_BIENESYRECURSOS(Almacen, txt_busqueda.Text)
                ElseIf Empresa = "DIMOSA" Then
                    grd_productos.DataSource = conexion.buscar_por_desc_dimosa(Almacen, txt_busqueda.Text, cmb_flota.SelectedItem)
                ElseIf Empresa = "FLOTA" Then
                    grd_productos.DataSource = conexion.buscar_por_desc_flota_nueva(Almacen, txt_busqueda.Text)
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Grd_productos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grd_productos.CellContentClick

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Cmb_tipo_filtro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_tipo_filtro.SelectedIndexChanged

    End Sub

    Private Sub Cmb_flota_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_flota.SelectedIndexChanged

    End Sub

    Private Sub Lbl_empresa_Click(sender As Object, e As EventArgs) Handles lbl_empresa.Click

    End Sub

    Private Sub txt_busqueda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_busqueda.TextChanged
        Try
            If cmb_tipo_filtro.SelectedItem = "Codigo" Then
                If Empresa = "CONSUMO" Or Empresa = "SAN RAFAEL" Then
                    grd_productos.DataSource = conexion.buscar_por_clave_consumo(Almacen, txt_busqueda.Text, cmb_flota.SelectedItem)
                ElseIf Empresa = "SR AGRO" Then
                    grd_productos.DataSource = conexion.buscar_por_clave_SRAGRO(Almacen, txt_busqueda.Text)
                ElseIf Empresa = "ADMON BIENES Y RECURSOS" Then
                    grd_productos.DataSource = conexion.buscar_por_clave_BIENESYRECURSOS(Almacen, txt_busqueda.Text)
                ElseIf Empresa = "DIMOSA" Then
                    grd_productos.DataSource = conexion.buscar_por_clave_dimosa(Almacen, txt_busqueda.Text, cmb_flota.SelectedItem)
                ElseIf Empresa = "FLOTA" Then
                    grd_productos.DataSource = conexion.buscar_por_clave_flota_nueva(Almacen, txt_busqueda.Text)
                End If
            End If

            If cmb_tipo_filtro.SelectedItem = "Descripcion" Then

                If Empresa = "CONSUMO" Or Empresa = "SAN RAFAEL" Then
                    grd_productos.DataSource = conexion.buscar_por_desc_consumo(Almacen, txt_busqueda.Text, cmb_flota.SelectedItem)
                ElseIf Empresa = "SR AGRO" Then
                    grd_productos.DataSource = conexion.buscar_por_desc_SRAGRO(Almacen, txt_busqueda.Text)
                ElseIf Empresa = "ADMON BIENES Y RECURSOS" Then
                    grd_productos.DataSource = conexion.buscar_por_desc_BIENESYRECURSOS(Almacen, txt_busqueda.Text)
                ElseIf Empresa = "DIMOSA" Then
                    grd_productos.DataSource = conexion.buscar_por_desc_dimosa(Almacen, txt_busqueda.Text, cmb_flota.SelectedItem)
                ElseIf Empresa = "FLOTA" Then
                    grd_productos.DataSource = conexion.buscar_por_desc_flota_nueva(Almacen, txt_busqueda.Text)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub grd_productos_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grd_productos.DoubleClick
        If Empresa = "ADMON BIENES Y RECURSOS" Then
            columna1 = grd_productos.CurrentRow.Cells(0).Value
            columna2 = grd_productos.CurrentRow.Cells(1).Value
            columna3 = grd_productos.CurrentRow.Cells(3).Value
            columna4 = grd_productos.CurrentRow.Cells(4).Value

        Else
            columna1 = grd_productos.CurrentRow.Cells(0).Value
            columna2 = grd_productos.CurrentRow.Cells(1).Value
            columna3 = grd_productos.CurrentRow.Cells(3).Value
            columna4 = grd_productos.CurrentRow.Cells(4).Value
            columnastock = grd_productos.CurrentRow.Cells(2).Value
        End If

        DialogResult = Windows.Forms.DialogResult.OK
    End Sub


    Private Sub btn_sabu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_sabu.Click

        If Empresa = "ADMON BIENES Y RECURSOS" Then
            columna1 = grd_productos.CurrentRow.Cells(0).Value
            columna2 = grd_productos.CurrentRow.Cells(1).Value
            columna3 = grd_productos.CurrentRow.Cells(3).Value
            columna4 = grd_productos.CurrentRow.Cells(4).Value

        Else
            columna1 = grd_productos.CurrentRow.Cells(0).Value
            columna2 = grd_productos.CurrentRow.Cells(1).Value
            columna3 = grd_productos.CurrentRow.Cells(3).Value
            columna4 = grd_productos.CurrentRow.Cells(4).Value
            columnastock = grd_productos.CurrentRow.Cells(2).Value
        End If
        
        DialogResult = Windows.Forms.DialogResult.OK

    End Sub

    Private Sub grd_productos_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grd_productos.CellMouseDoubleClick

        If Empresa = "ADMON BIENES Y RECURSOS" Then
            columna1 = grd_productos.CurrentRow.Cells(0).Value
            columna2 = grd_productos.CurrentRow.Cells(1).Value
            columna3 = grd_productos.CurrentRow.Cells(3).Value
            columna4 = grd_productos.CurrentRow.Cells(4).Value
        Else
            columna1 = grd_productos.CurrentRow.Cells(0).Value
            columna2 = grd_productos.CurrentRow.Cells(1).Value
            columna3 = grd_productos.CurrentRow.Cells(3).Value
            columna4 = grd_productos.CurrentRow.Cells(4).Value
            columnastock = grd_productos.CurrentRow.Cells(2).Value
        End If

        DialogResult = Windows.Forms.DialogResult.OK

    End Sub
End Class






