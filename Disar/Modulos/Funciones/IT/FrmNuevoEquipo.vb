Imports Disar.data

Public Class FrmNuevoEquipo

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Dim a = MsgBox("Los datos actuales se perderán.", MsgBoxStyle.YesNo, "Confirmar")
        If a = MsgBoxResult.Yes Then
            Me.Dispose()
        End If
    End Sub

    Private Sub FrmNuevoEquipo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt As New DataTable
        dt.Rows.Clear()
        Dim db As New clsInventarioIT
        dt = db.NuevoNumero
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

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        Dim a = MsgBox("¿Ha finalizado de registrar la información?", MsgBoxStyle.YesNo, "Confirmar")
        If a = MsgBoxResult.Yes Then
            If TextDescripcion.Text = "" Or ComboCat.Text = "" Or TextSerie.Text = "" Then
                MsgBox("La descripción, el número de serie y la categoría son campos obligatorios.", MsgBoxStyle.Information, "Aviso")
            Else
                Dim db As New clsInventarioIT
                Try
                    Dim Num As String = ""
                    Dim SIM As String = ""

                    If ComboCat.Text = "HandHeld" Then
                        Num = TextNumero.Text
                        SIM = TextSim.Text
                    Else
                        Num = ""
                        SIM = ""
                    End If

                    Dim s = db.NuevoRegistro(Numero.Text, TextDescripcion.Text, ComboCat.SelectedValue, TextSerie.Text, TextModelo.Text, ComboMarca.Text, TextProcesador.Text, TextRAM.Text, TextDiscoDuro.Text, DateFechaCompra.Value.Date, DateGarantia.Value.Date, Val(TextCosto.Text), ComboEstado.Text, "Disponible", TextFactura.Text, ComboProveedor.Text, TextContacto.Text, ComboUbicacion.Text, SIM, Num)
                    If s = "s" Then
                        MsgBox("Registro guardado correctamente.", MsgBoxStyle.Information, "Aviso")
                        Try
                            Me.DialogResult = Windows.Forms.DialogResult.OK
                        Catch ex As Exception
                        End Try
                    Else
                        MsgBox("No se pudo guardar el registro: " & s, MsgBoxStyle.Critical, "Aviso")
                    End If
                Catch ex As Exception
                End Try

            End If
        End If
    End Sub

    Private Sub ComboCat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboCat.SelectedIndexChanged
        If ComboCat.Text = "HandHeld" Then
            L1.Visible = True
            L2.Visible = True
            TextSim.Visible = True
            TextNumero.Visible = True
        Else
            L1.Visible = False
            L2.Visible = False
            TextSim.Visible = False
            TextNumero.Visible = False
        End If
    End Sub
End Class