Imports Disar.data
Imports System.Net

Public Class FrmRegistroAgro

    Dim Fecha As Date
    Dim PermisoRevision As Boolean
    Dim style As Microsoft.Office.Interop.Excel.Style

    Private Sub FrmRegistroAgro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim PermisoRevision As Boolean = False

        LFecha.Text = Today.Date
        Usuario.Text = _Inicio.lblUsuario.Text

        IP.Text = lF_sDireccionIP(My.Computer.Name)

        Dim db As New ClsRegistroAgro
        Try
            Dim dta As New DataTable
            dta.Rows.Clear()
            dta = db.get_Nombre(_Inicio.lblUsuario.Text)
            Nombre.Text = dta(0)(0)
            If dta(0)(1) = 1 Then
                PermisoRevision = True
            Else
                PermisoRevision = False
            End If
        Catch ex As Exception
        End Try

        Dim dtFecha As New DataTable
        Try
            dtFecha.Rows.Clear()
        Catch ex As Exception
        End Try
        dtFecha = db.get_Fecha
        Fecha = dtFecha(0)(0)

        If PermisoRevision = True Then
            ComboEMPLEADO.Visible = True
            DateTimePicker1.Visible = True
            DateTimePicker2.Visible = True
            Label4.Visible = True
            BtnCargar.Visible = True
            BtnRegistro.Enabled = False
            BtnExportar.Visible = True
            ObtenerUsers()
        Else
            ComboEMPLEADO.Visible = False
            DateTimePicker1.Visible = False
            DateTimePicker2.Visible = False
            Label4.Visible = False
            BtnCargar.Visible = False
            BtnExportar.Visible = False
            BtnRegistro.Enabled = True
        End If

        CargaInformación()
    End Sub

    Private Function lF_sDireccionIP(ByVal strNombrePC As String) As String
        Dim valorIp As String
        valorIp = System.Security.Principal.WindowsIdentity.GetCurrent().Name
        Return valorIp
    End Function

    Private Sub ComboMotivo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboMotivo.SelectedIndexChanged
        If ComboMotivo.Text = "OTRO" Then
            TextOtro.Visible = True
        Else
            TextOtro.Visible = False
        End If
    End Sub

    Private Sub BtnRegistro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRegistro.Click

        Dim Hora As TimeSpan
        Dim db As New ClsRegistroAgro
        Dim dtFecha As New DataTable()

        Dim dtHora As New DataTable

        Try
            dtFecha.Rows.Clear()
        Catch ex As Exception
        End Try

        Try
            dtHora.Rows.Clear()
        Catch ex As Exception
        End Try

        dtFecha = db.get_Fecha
        dtHora = db.get_Hora

        LFecha.Text = dtFecha(0)(0)
        Fecha = dtFecha(0)(0)
        Hora = dtHora(0)(0)

        Dim Motivo As String = ComboMotivo.Text

        If Motivo = "OTRO" Then
            Motivo = TextOtro.Text
        End If

        If Motivo = "" Then
            MsgBox("No se puede almacenar un registro sin información de motivo", MsgBoxStyle.Critical, "Registro SR AGRO")
        Else
            Try
                Dim s = db.NuevoEventoProgramado(Fecha, Hora, Motivo, Nombre.Text, IP.Text)
                MsgBox(s)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            TextOtro.Text = ""
        End If

        CargaInformación()

    End Sub

    Sub CargaInformación()
        Try
            Dim db As New ClsRegistroAgro
            DataReg.DataSource = db.ObtieneRegistros(Nombre.Text, Fecha)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnCargar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCargar.Click
        Try
            Dim conexion_bita As New cls_bitacora_reporteador
            conexion_bita.RegistraBitacora(Now, _Inicio.lblUsuario.Text, "Generó reporte de registro SR AGRO", "Almacen", _
                                      "Fecha: " & DateTime.Now)
        Catch ex As Exception
        End Try
        Try
            Dim db As New ClsRegistroAgro
            If ComboEMPLEADO.Text = "TODOS" Then
                DataReg.DataSource = db.ObtieneTodosRegistros(DateTimePicker1.Value, DateTimePicker2.Value)
            Else
                DataReg.DataSource = db.ObtieneTodosRegistrosIndividual(DateTimePicker1.Value, DateTimePicker2.Value, ComboEMPLEADO.Text)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExportar.Click
        Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
        Dim wBook As Microsoft.Office.Interop.Excel.Workbook
        Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
        wBook = excel.Workbooks.Add()
        wSheet = wBook.ActiveSheet()

        style = wSheet.Application.ActiveWorkbook.Styles.Add("Estilo")
        style.Font.Bold = True
        style.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
        style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.SteelBlue)
        style.Font.Size = 11
        style.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
        style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

        wSheet.Cells.Range("A1:F1").Merge()
        wSheet.Cells.Range("A1:F1").Borders.LineStyle = BorderStyle.FixedSingle
        wSheet.Cells.Range("A1:F1").Value = " Reporte de Registro SR Agro "
        wSheet.Cells.Range("A1:F1").Style = "Estilo"

        For c As Integer = 0 To DataReg.Columns.Count - 1
            wSheet.Cells(2, c + 1).value = DataReg.Columns(c).HeaderText
            wSheet.Cells(2, c + 1).Style = "Estilo"
        Next
        For r As Integer = 0 To DataReg.RowCount - 1
            For c As Integer = 0 To DataReg.Columns.Count - 1
                If c = 2 Then
                    wSheet.Cells(r + 3, c + 1).value = FormatDateTime(DataReg.Rows(r).Cells(c).Value.ToString)
                Else
                    wSheet.Cells(r + 3, c + 1).value = (DataReg.Rows(r).Cells(c).Value.ToString)
                End If

                wSheet.Cells(r + 3, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet.Cells(r + 3, c + 1).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            Next
        Next
        wSheet.Columns.AutoFit()
        excel.Visible = True
        excel.Quit()
    End Sub

    Sub ObtenerUsers()
        Dim db As New ClsRegistroAgro
        Try
            ComboEMPLEADO.DataSource = db.ObtenerUsuarios
            ComboEMPLEADO.DisplayMember = "RegUsuario"
            ComboEMPLEADO.ValueMember = "RegUsuario"
        Catch ex As Exception
        End Try
    End Sub

End Class