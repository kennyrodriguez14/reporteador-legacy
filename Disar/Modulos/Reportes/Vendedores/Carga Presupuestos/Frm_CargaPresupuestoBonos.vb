Imports Disar.data

Public Class Frm_CargaPresupuestoBonos
    Private Sub FrmPresupuestosSR_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            ComboBox1.SelectedIndex = 0
        Catch ex As Exception
        End Try
        Try
            ComboEmpresa.Items.Clear()
            If _Inicio.SANRAFAEL = 1 Then
                ComboEmpresa.Items.Add("SAN RAFAEL")
            End If
            If _Inicio.DIMOSA = 1 Then
                ComboEmpresa.Items.Add("DIMOSA")
            End If
            ComboEmpresa.SelectedIndex = 0
        Catch ex As Exception
        End Try
    End Sub

    Sub LLENA()
        Dim db As New ClassVendedores

        If ComboBox1.Text = "PROVEEDOR" Then
            DataPresupuestos.DataSource = Nothing
            DataPresupuestos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
            Dim dt As New DataTable

            dt = db.CargaVendedoresBono(ComboEmpresa.Text, ComboSucursal.Text)

            Dim dtProveedores As New DataTable
            dtProveedores = db.CargaProveedoresBono(ComboEmpresa.Text)

            Dim COLRUTA As New DataGridViewTextBoxColumn
            COLRUTA.Name = "RUTA"
            COLRUTA.HeaderText = "RUTA"
            COLRUTA.ReadOnly = True
            COLRUTA.Frozen = True

            Dim COLNOMBRE As New DataGridViewTextBoxColumn
            COLNOMBRE.Name = "NOMBRE"
            COLNOMBRE.HeaderText = "NOMBRE"
            COLNOMBRE.ReadOnly = True
            COLNOMBRE.Frozen = True

            Dim COLSUCURSAL As New DataGridViewTextBoxColumn
            COLSUCURSAL.Name = "SUCURSAL"
            COLSUCURSAL.HeaderText = "SUCURSAL"
            COLSUCURSAL.ReadOnly = True
            COLSUCURSAL.Frozen = True

            DataPresupuestos.Columns.Add(COLRUTA)
            DataPresupuestos.Columns.Add(COLNOMBRE)
            DataPresupuestos.Columns.Add(COLSUCURSAL)

            For A As Integer = 0 To dt.Rows.Count - 1
                DataPresupuestos.Rows.Add(dt(A)(0), dt(A)(1), dt(A)(2))
            Next

            For A As Integer = 0 To dtProveedores.Rows.Count - 1
                Dim COL As New DataGridViewTextBoxColumn
                COL.Name = dtProveedores(A)(0)
                COL.HeaderText = dtProveedores(A)(1)
                DataPresupuestos.Columns.Add(COL)
            Next
            'MsgBox(DataPresupuestos.ColumnCount - 1)
            For row As Integer = 0 To DataPresupuestos.RowCount - 1
                For col As Integer = 3 To DataPresupuestos.ColumnCount - 1
                    Dim dtX As New DataTable
                    dtX = db.CargaMetaIndBono(ComboEmpresa.Text, DataPresupuestos.Rows(row).Cells(0).Value, DataPresupuestos.Columns(col).Name)

                    Dim Total As Decimal = 0
                    If dtX.Rows.Count > 0 Then
                        If Not IsDBNull(dtX(0)(0)) Then
                            Total = dtX(0)(0)
                        End If
                    End If
                    DataPresupuestos.Rows(row).Cells(col).Value = Total
                Next
            Next
        Else
            DataPresupuestos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            Dim dt As New DataTable
            dt = db.CargaVendedoresGeneralBono(ComboEmpresa.Text, ComboSucursal.Text)
            DataPresupuestos.DataSource = dt
            Try
                DataPresupuestos.Columns(0).ReadOnly = True
                DataPresupuestos.Columns(1).ReadOnly = True
                DataPresupuestos.Columns(2).ReadOnly = True
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub Guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Guardar.Click

        Dim X = MsgBox("¿Está seguro que desea cambiar los PRESUPUESTOS por " & ComboBox1.Text & " de " & ComboEmpresa.Text & "?", MsgBoxStyle.YesNo)

        If X = MsgBoxResult.Yes Then
            Dim dt As New DataTable
            For Each COLUMN As DataGridViewColumn In DataPresupuestos.Columns
                dt.Columns.Add(COLUMN.Name)
            Next
            For Each row As DataGridViewRow In DataPresupuestos.Rows
                Dim Fila = dt.NewRow
                For Each column As DataGridViewColumn In DataPresupuestos.Columns
                    Fila(column.Index) = row.Cells(column.Index).Value
                Next
                dt.Rows.Add(Fila)
            Next

            Dim db As New ClassVendedores
            If ComboBox1.Text = "PROVEEDOR" Then
                Dim s = db.GuardaPresupuestosProveedoresBono(ComboEmpresa.Text, dt, _Inicio.lblUsuario.Text)
                If s = "s" Then
                    MsgBox("Se actualizaron los presupuestos por proveedor.", MsgBoxStyle.Information, ComboEmpresa.Text)
                    'Me.Close()
                Else
                    MsgBox(s)
                End If
            Else
                Dim s = db.GuardaPresupuestosGeneralesBono(ComboEmpresa.Text, dt, _Inicio.lblUsuario.Text)
                If s = "s" Then
                    MsgBox("Se actualizaron los presupuestos por proveedor.", MsgBoxStyle.Information, ComboEmpresa.Text)
                    'Me.Close()
                Else
                    MsgBox(s)
                End If
            End If

        End If
    End Sub

    Private Sub Cargar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cargar.Click
        Try
            DataPresupuestos.Columns.Clear()
        Catch ex As Exception
        End Try
        LLENA()
    End Sub

    Private Sub DataPresupuestos_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataPresupuestos.CellEndEdit
        If IsNumeric(DataPresupuestos.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then
        Else
            MsgBox("La cantidad registrada no es válida", MsgBoxStyle.Information)
            DataPresupuestos.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = 0
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim db As New ClassVendedores
        Dim s = db.CargaPresupuestosMatinalBono(ComboEmpresa.Text, _Inicio.lblUsuario.Text)
        If s = "s" Then
            MsgBox("Se cargaron los presupuestos de matinal a bonos.", MsgBoxStyle.Information)
            Cargar.PerformClick()
        End If
    End Sub
End Class