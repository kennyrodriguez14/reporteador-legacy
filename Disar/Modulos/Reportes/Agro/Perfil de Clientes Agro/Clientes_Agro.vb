Imports Disar.data

Public Class Clientes_Agro
    Dim Cli As New ClsFunciones
    Public ID As String

    Private Sub BtnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGenerar.Click
        ComboVendedor.DataSource = Nothing
        ComboVendedor.Text = ""
        ComboDíaVisita.Items.Clear()
        TextBusca.Text = ""
        Actualizarclientes()
    End Sub

    Sub Actualizarclientes()
        Try
            DataClientes.DataSource = Cli.MuestraClientes
            DataClientes.Columns(0).Width = 47%
            DataClientes.Columns(1).Width = 225%
            DataClientes.Columns(2).Visible = False
            DataClientes.Columns(3).Width = 120%
            DataClientes.Columns(4).Width = 100%
            DataClientes.Columns(5).Width = 57%
            DataClientes.Columns(8).Visible = False
            DataClientes.Columns(18).Visible = False
            DataClientes.Columns(19).Visible = False
        Catch ex As Exception
            MsgBox("Error al cargar los registros: " & ex.Message, MsgBoxStyle.Critical, "Atención")
        End Try
    End Sub

    Sub Buscaclientes()
        Try
            DataClientes.DataSource = Cli.BuscaClientes(TextBusca.Text)
            If DataClientes.RowCount > 0 Then
                DataClientes.Columns(0).Width = 47%
                DataClientes.Columns(1).Width = 225%
                DataClientes.Columns(2).Visible = False
                DataClientes.Columns(3).Width = 120%
                DataClientes.Columns(4).Width = 100%
                DataClientes.Columns(5).Width = 57%
                DataClientes.Columns(8).Visible = False
                DataClientes.Columns(18).Visible = False
                DataClientes.Columns(19).Visible = False
            End If
        Catch ex As Exception
            MsgBox("Error al cargar los registros: " & ex.Message, MsgBoxStyle.Critical, "Atención")
        End Try
    End Sub

    Private Sub TextBusca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBusca.TextChanged
        Buscaclientes()
    End Sub

    Private Sub Clientes_Agro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Actualizarclientes()
        DataClientes.ColumnHeadersDefaultCellStyle.Font = New Font("Microsoft Sans Serif", 7)
        DataClientes.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 7)
        Actualizarclientes()
    End Sub

    Private Sub DataClientes_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataClientes.CellDoubleClick
        Seleccion.Show()
        Seleccion.BringToFront()
        ID = DataClientes.CurrentRow.Cells(0).Value
    End Sub

    Private Sub Key(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DataClientes.KeyPress
        Try
            If DataClientes.RowCount > 1 Then
                DataClientes.CurrentCell = DataClientes(0, DataClientes.CurrentRow.Index - 1)
            End If

            If e.KeyChar = Chr(13) Then
                Seleccion.Show()
                Seleccion.BringToFront()
                ID = DataClientes.CurrentRow.Cells(0).Value
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ComboVendedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboVendedor.SelectedIndexChanged
        ComboDíaVisita.SelectedText = ""
        ComboDíaVisita.Items.Clear()
        TextBusca.Text = ""
        Try
            DataClientes.DataSource = Cli.MuestraClientesVENDEDOR(ComboVendedor.Text)
            DataClientes.Columns(0).Width = 47%
            DataClientes.Columns(1).Width = 225%
            DataClientes.Columns(2).Visible = False
            DataClientes.Columns(3).Width = 120%
            DataClientes.Columns(4).Width = 100%
            DataClientes.Columns(5).Width = 57%
            DataClientes.Columns(8).Visible = False
            DataClientes.Columns(18).Visible = False
            DataClientes.Columns(19).Visible = False
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ComboDíaVisita_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboDíaVisita.SelectedIndexChanged
        TextBusca.Text = ""
        Try
            ComboVendedor.DataSource = Nothing
            ComboVendedor.Text = ""
            DataClientes.DataSource = Cli.MuestraClientesDIA(ComboDíaVisita.Text)
            DataClientes.Columns(0).Width = 47%
            DataClientes.Columns(1).Width = 225%
            DataClientes.Columns(2).Visible = False
            DataClientes.Columns(3).Width = 120%
            DataClientes.Columns(4).Width = 100%
            DataClientes.Columns(5).Width = 57%
            DataClientes.Columns(8).Visible = False
            DataClientes.Columns(18).Visible = False
            DataClientes.Columns(19).Visible = False

        Catch ex As Exception

        End Try

    End Sub

    Sub ActualizarVendedores()
        Try
            ComboVendedor.DataSource = Cli.MuestraVendedores
            ComboVendedor.ValueMember = "CVE_VEND"
            ComboVendedor.DisplayMember = "NOMBRE"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ComboVendedor_CK(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboVendedor.Enter
        ActualizarVendedores()
    End Sub

    Private Sub ComboDíaVisita_CK(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboDíaVisita.Enter
        ComboVendedor.DataSource = Nothing
        ComboDíaVisita.Items.Add("LUNES")
        ComboDíaVisita.Items.Add("MARTES")
        ComboDíaVisita.Items.Add("MIERCOLES")
        ComboDíaVisita.Items.Add("JUEVES")
        ComboDíaVisita.Items.Add("VIERNES")
        ComboDíaVisita.Items.Add("SABADO")
    End Sub

    Private Sub TextBusca_CK(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBusca.Enter
        ComboVendedor.DataSource = Nothing
        ComboDíaVisita.Items.Clear()
    End Sub

End Class
