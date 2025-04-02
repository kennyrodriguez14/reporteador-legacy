Imports Disar.data

Public Class FrmDetallesEquipo

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Dim a = MsgBox("Los datos actuales se perderán.", MsgBoxStyle.YesNo, "Confirmar")
        If a = MsgBoxResult.Yes Then
            Me.Dispose()
        End If
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        Try
            Dim db As New clsInventarioIT
            Dim s = db.ModificaRegistro(Numero.Text, TextDescripcion.Text, ComboCat.SelectedValue, TextSerie.Text, TextModelo.Text, ComboMarca.Text, TextProcesador.Text, TextRAM.Text, TextDiscoDuro.Text, DateFechaCompra.Value.Date, DateGarantia.Value.Date, Val(TextCosto.Text), ComboEstado.Text, TextAsignacion.Text, TextFactura.Text, ComboProveedor.Text, TextContacto.Text, ComboUbicacion.Text, TextSim.Text, TextNum.Text)
            If s = "s" Then
                MsgBox("Se modificó el registro existosamente", MsgBoxStyle.Information, "Aviso")
                FrmInventarioIT.VerEquipos()
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                MsgBox(s)
            End If
        Catch ex As Exception

        End Try
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

    Private Sub FrmDetallesEquipo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextAsignacion.Enabled = False
    End Sub

    Private Sub BtnAsignar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAsignar.Click
        If TextAsignacion.Text = "Disponible" Then
            If Form_AsignacionEquipo.ShowDialog() = Windows.Forms.DialogResult.OK Then
                FrmInventarioIT.BtnGenerar.PerformClick()
                Me.Close()
            End If
        Else
            Dim a = MsgBox("El equipo actual está " & TextAsignacion.Text & ". ¿Desea reasignarlo?", MsgBoxStyle.YesNo, "Reasignar equipo")
            If a = MsgBoxResult.Yes Then
                If Form_AsignacionEquipo.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    FrmInventarioIT.BtnGenerar.PerformClick()
                    Me.Close()
                End If
            End If
        End If

    End Sub

    Private Sub BtnInventario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnInventario.Click
        Try
            Dim db As New clsInventarioIT
            Dim a = MsgBox("¿Está seguro que desea devolver a estado disponible el equipo seleccionado?", MsgBoxStyle.YesNo, "Devolver disponibilidad")
            If a = MsgBoxResult.Yes Then
                Dim s = db.NuevaDevolAlmacen(Numero.Text, Today.Date)
                If s = "s" Then
                    MsgBox("El equipo ha sido devuelto a estado disponible", MsgBoxStyle.Information, "Aviso")
                    TextAsignacion.Text = "Disponible"
                    FrmInventarioIT.BtnGenerar.PerformClick()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class