Imports Disar.data
Imports System.Reflection
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO
Imports System.Data.OleDb

Public Class FrmPresupuestosSR

    Public CargaDesdeExcel As String

    Private Sub FrmPresupuestosSR_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargaDesdeExcel = "N"
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

            dt = db.CargaVendedores(ComboEmpresa.Text, ComboSucursal.Text)

            Dim dtProveedores As New DataTable
            dtProveedores = db.CargaProveedores(ComboEmpresa.Text)

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
                    dtX = db.CargaMetaInd(ComboEmpresa.Text, DataPresupuestos.Rows(row).Cells(0).Value, DataPresupuestos.Columns(col).Name)

                    Dim Total As Decimal = 0
                    If dtX.Rows.Count > 0 Then
                        If Not IsDBNull(dtX(0)(0)) Then
                            Total = dtX(0)(0)
                        End If
                    End If
                    DataPresupuestos.Rows(row).Cells(col).Value = Total
                Next
            Next
        ElseIf ComboBox1.Text = "VOLUMEN" Then
            DataPresupuestos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            Dim dt As New DataTable
            dt = db.CargaVendedoresGeneral(ComboEmpresa.Text, ComboSucursal.Text)
            DataPresupuestos.DataSource = dt
            Try
                DataPresupuestos.Columns(0).ReadOnly = True
                DataPresupuestos.Columns(1).ReadOnly = True
                DataPresupuestos.Columns(2).ReadOnly = True
            Catch ex As Exception
            End Try
        Else
            DataPresupuestos.DataSource = Nothing
            DataPresupuestos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
            Dim dt As New DataTable

            dt = db.CargaVendedores(ComboEmpresa.Text, ComboSucursal.Text)

            Dim dtProveedores As New DataTable
            dtProveedores = db.CargaProveedoresCaja(ComboEmpresa.Text)

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
                    dtX = db.CargaMetaIndCajas(ComboEmpresa.Text, DataPresupuestos.Rows(row).Cells(0).Value, DataPresupuestos.Columns(col).Name)

                    Dim Total As Decimal = 0
                    If dtX.Rows.Count > 0 Then
                        If Not IsDBNull(dtX(0)(0)) Then
                            Total = dtX(0)(0)
                        End If
                    End If
                    DataPresupuestos.Rows(row).Cells(col).Value = Total
                Next
            Next
        End If
    End Sub

    Private Sub Guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Guardar.Click

        Dim X = MsgBox("¿Está seguro que desea cambiar los PRESUPUESTOS por " & ComboBox1.Text & " de " & ComboEmpresa.Text & "?", MsgBoxStyle.YesNo)
        If CargaDesdeExcel = "N" Then
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
                    Dim s = db.GuardaPresupuestosProveedores(ComboEmpresa.Text, dt, _Inicio.lblUsuario.Text)
                    If s = "s" Then
                        MsgBox("Se actualizaron los presupuestos por proveedor.", MsgBoxStyle.Information, ComboEmpresa.Text)
                    Else
                        MsgBox(s)
                    End If
                ElseIf ComboBox1.Text = "VOLUMEN" Then
                    Dim s = db.GuardaPresupuestosGenerales(ComboEmpresa.Text, dt, _Inicio.lblUsuario.Text)
                    If s = "s" Then
                        MsgBox("Se actualizaron los presupuestos por proveedor.", MsgBoxStyle.Information, ComboEmpresa.Text)
                    Else
                        MsgBox(s)
                    End If
                Else
                    Dim s = db.GuardaPresupuestosCajas(ComboEmpresa.Text, dt, _Inicio.lblUsuario.Text)
                    If s = "s" Then
                        MsgBox("Se actualizaron los presupuestos por proveedor.", MsgBoxStyle.Information, ComboEmpresa.Text)
                    Else
                        MsgBox(s)
                    End If
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
            If DataPresupuestos.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = 0 Then
                DataPresupuestos.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = 1
            End If
        Else
            MsgBox("La cantidad registrada no es válida", MsgBoxStyle.Information)
            DataPresupuestos.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = 1
        End If
    End Sub

    Private Sub BtnCargaExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCargaExcel.Click
        Try
            DataPresupuestos.Columns.Clear()
        Catch ex As Exception
        End Try
        LLENA()
        CargaDesdeExcel = "S"
        Dim openFD As New OpenFileDialog()
        With openFD
            .Title = "Seleccionar archivos"
            .Filter = "Archivos Excel(*.xls;*.xlsx)|*.xls;*xlsx|Todos los archivos(*.*)|*.*"
            .Multiselect = False
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                'DataDatos.Columns.Clear()
                ImportExcellToDataGridView(.FileName, DataPresupuestos)
            End If
        End With
    End Sub

    Public Function ImportExcellToDataGridView(ByRef path As String, ByVal Datagrid As DataGridView)
        Try


            Dim excel As New Microsoft.Office.Interop.Excel.Application
            Dim sheets As New Microsoft.Office.Interop.Excel.Worksheet
            Dim work As New Microsoft.Office.Interop.Excel.Worksheet

            excel.Workbooks.Open(path, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, _
                                 Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing)

            sheets = excel.Sheets.Item(1)
            Dim Hoja As String = sheets.Name
            excel.Quit()
            Dim stConexion As String = ("Provider=Microsoft.ACE.OLEDB.12.0;" & ("Data Source=" & (path & ";Extended Properties=""Excel 12.0;Xml;HDR=YES;IMEX=2"";" & "")))
            Dim cnConex As New OleDbConnection(stConexion)

            Dim Cmd As New OleDbCommand("Select * From [" & Hoja & "$]", cnConex)
            Dim Ds As New DataSet
            Dim Da As New OleDbDataAdapter
            Dim Dt As New DataTable
            cnConex.Open()
            Cmd.Connection = cnConex
            Da.SelectCommand = Cmd
            Da.Fill(Ds)
            Dt = Ds.Tables(0)
            'Dim mconn As New OleDb.OleDbConnection(stConexion)
            'MsgBox("Prueba")
            'Dim ad As New OleDb.OleDbDataAdapter("Select * from [" & Hoja & "$]", mconn)
            'mconn.Open()
            'ad.Fill(Dt)
            'mconn.Close()

            '-Datagrid.Columns.Clear()


            For a As Integer = 0 To Dt.Rows.Count - 1
                For b As Integer = 2 To Dt.Columns.Count - 1

                    For Each gridA As DataGridViewRow In DataPresupuestos.Rows
                        For Each GridB As DataGridViewColumn In DataPresupuestos.Columns
                            If Convert.ToInt16(LTrim(Dt(a)(0))) = Convert.ToInt16(LTrim(gridA.Cells(0).Value)) And Dt.Columns(b).ColumnName.ToUpper = GridB.HeaderText.ToUpper Then
                                gridA.Cells(GridB.Index).Value = Dt(a)(b)
                                'MsgBox("ERGO")
                            End If
                            'MsgBox(Convert.ToInt16(LTrim(Dt(a)(0))) & vbNewLine & Convert.ToInt16(LTrim(gridA.Cells(0).Value)) & vbNewLine & Dt.Columns(b).ColumnName & vbNewLine & GridB.HeaderText)
                        Next
                    Next
                Next
            Next
            'Datagrid.DataSource = Dt
        Catch ex As Exception
            MsgBox("" & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Return True
    End Function



End Class