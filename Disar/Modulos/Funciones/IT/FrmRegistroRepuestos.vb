Imports Disar.data

Public Class FrmRegistroRepuestos

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Dispose()
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        Try
            Dim db As New clsInventarioIT
            Dim S = db.NuevoRegistroRepuesto(Numero.Text, TextDescripcion.Text, ComboCat.SelectedValue, TextSerie.Text, TextModelo.Text, ComboMarca.Text, TextProcesador.Text, TextRAM.Text, TextDiscoDuro.Text, Today.Date, Today.Date, 0, ComboEstado.Text, ComboEstado.Text, "", ComboProveedor.Text, TextContacto.Text, ComboUbicacion.Text)
            If S = "s" Then
                MsgBox("Almacenado exitosamente")
                FrmRepuestos.BtnActualizar.PerformClick()
                Me.Dispose()
            Else
                MsgBox(S)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FrmRegistroRepuestos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt As New DataTable
        dt.Rows.Clear()
        Dim db As New clsInventarioIT
        dt = db.NuevoNumeroRepuesto
        Dim Num As Integer
        Try
            Num = dt(0)(0)
        Catch ex As Exception
            Num = 0
        End Try
        Num += 1
        Numero.Text = Num

        Categorias()
        Marcas()
        Ubicaciones()
        Proveedores()
    End Sub
    Sub Categorias()
        Try
            Dim db As New clsInventarioIT
            ComboCat.DataSource = db.VerCategorias
            ComboCat.DisplayMember = "CategoriaNombre"
            ComboCat.ValueMember = "CategoriaID"
            ComboCat.SelectedItem = Nothing
        Catch ex As Exception
        End Try
    End Sub

    Sub Marcas()
        Try
            Dim db As New clsInventarioIT
            ComboMarca.DataSource = db.VerMarcas
            ComboMarca.DisplayMember = "Marca"
            ComboMarca.ValueMember = "Marca"
            ComboMarca.SelectedItem = Nothing
        Catch ex As Exception
        End Try
    End Sub

    Sub Proveedores()
        Try
            Dim db As New clsInventarioIT
            ComboProveedor.DataSource = db.VerProveedor
            ComboProveedor.DisplayMember = "Proveedor"
            ComboProveedor.ValueMember = "Proveedor"
            ComboProveedor.SelectedItem = Nothing
        Catch ex As Exception
        End Try
    End Sub

    Sub Ubicaciones()
        Try
            Dim db As New clsInventarioIT
            ComboUbicacion.DataSource = db.VerUbicacion
            ComboUbicacion.DisplayMember = "Ubicacion"
            ComboUbicacion.ValueMember = "Ubicacion"
            ComboUbicacion.SelectedItem = Nothing
        Catch ex As Exception
        End Try
    End Sub
End Class