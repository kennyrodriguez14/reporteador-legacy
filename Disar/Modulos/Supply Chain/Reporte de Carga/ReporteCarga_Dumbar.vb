Imports Disar.data
Imports System.Net.Mail
Imports System.Net.Security
Imports System.Security.Cryptography.X509Certificates

Public Class ReporteCarga_Dumbar

    Dim Clase As New cls_reporte_carga 'clsRptCarga
    Dim style, style2 As Microsoft.Office.Interop.Excel.Style
    Dim Tabla As New DataTable
    Dim TotalCan, TotalImp, TotaPes As Integer
    Dim Filas As DataRow = Tabla.NewRow
    Dim Activo As Integer = 0
    Dim Sucursal As Integer = 0

    Private Sub _btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnGenerar.Click
        Llena()
        LlenaTotales()
        Try
            DataGridView1.Columns(1).Visible = False
            'DataGridView1.Columns(3).Visible = False
        Catch ex As Exception
        End Try
    End Sub

    Sub Llena()
        Try
            Rangos.Rows.Clear()
            RangosContado.Rows.Clear()
            RangosCredito.Rows.Clear()
        Catch ex As Exception
        End Try

        If cmbEntregador.Text = "" Then
            MsgBox("Campos Vacios", MsgBoxStyle.Information, "Facturas")
        Else
            Try
                Activo = 1
                If ComboSucursal.Text = "SAN RAFAEL" Then
                    grdBodega.DataSource = Clase.RCDumbar(cmbEntregador.SelectedValue, cmbFecha.Value.Date, "N", "GENERAL", cmbFecha2.Value.Date)
                    grdBodega.Columns(6).Visible = False
                    grdContado.DataSource = Clase.RCDumbar(cmbEntregador.SelectedValue, cmbFecha.Value.Date, "Cont", "FILTRO", cmbFecha2.Value.Date)
                    grdCredito.DataSource = Clase.RCDumbar(cmbEntregador.SelectedValue, cmbFecha.Value.Date, "Cred", "FILTRO", cmbFecha2.Value.Date)
                Else
                    grdBodega.DataSource = Clase.RCDumbarDIMOSA(cmbEntregador.SelectedValue, cmbFecha.Value.Date, "N", "GENERAL", cmbFecha2.Value.Date)
                    grdBodega.Columns(6).Visible = False
                    grdContado.DataSource = Clase.RCDumbarDIMOSA(cmbEntregador.SelectedValue, cmbFecha.Value.Date, "Cont", "FILTRO", cmbFecha2.Value.Date)
                    grdCredito.DataSource = Clase.RCDumbarDIMOSA(cmbEntregador.SelectedValue, cmbFecha.Value.Date, "Cred", "FILTRO", cmbFecha2.Value.Date)
                End If
                
                Dim Uni, pes, dine As Double
                For i As Integer = 0 To grdBodega.RowCount - 1
                    'Uni += grdBodega.Rows(i).Cells(2).Value
                    Uni += grdBodega.Rows(i).Cells.Item("CANT").Value

                    'dine += grdBodega.Rows(i).Cells.Item("TOTAL").Value
                    'dine += grdBodega.Rows(i).Cells(4).Value
                    'pes += grdBodega.Rows(i).Cells(6).Value
                    pes += grdBodega.Rows(i).Cells.Item("PESO").Value
                Next

                dinerobodega.Text = Math.Round(dine, 2)
                pesobodega.Text = FormatNumber(pes, 2)
                Unidadesbodega.Text = FormatNumber(Uni, 2)
                dine = 0
                Uni = 0
                pes = 0
                For i As Integer = 0 To grdContado.RowCount - 1

                    'Uni += grdContado.Rows(i).Cells(2).Value
                    Uni += grdContado.Rows(i).Cells.Item("CANT").Value

                    'dine += grdContado.Rows(i).Cells(3).Value
                    dine += grdContado.Rows(i).Cells.Item("TOTAL").Value

                    'pes += grdContado.Rows(i).Cells(4).Value
                    pes += grdContado.Rows(i).Cells.Item("PESO").Value

                Next
                dinerocontado.Text = Math.Round(dine, 2)
                pesocontado.Text = FormatNumber(pes, 2)
                unidadescontado.Text = FormatNumber(Uni, 2)
                dine = 0
                Uni = 0
                pes = 0
                For i As Integer = 0 To grdCredito.RowCount - 1


                    'Uni += grdCredito.Rows(i).Cells(2).Value
                    Uni += grdCredito.Rows(i).Cells.Item("CANT").Value

                    'dine += grdCredito.Rows(i).Cells(3).Value
                    dine += grdCredito.Rows(i).Cells.Item("TOTAL").Value

                    'pes += grdCredito.Rows(i).Cells(4).Value
                    pes += grdCredito.Rows(i).Cells.Item("PESO").Value

                Next
                dinerocredito.Text = Math.Round(dine, 2)
                pesocredito.Text = FormatNumber(pes, 2)
                unidadescredito.Text = FormatNumber(Uni, 2)
                dine = 0
                Uni = 0
                pes = 0

                Dim dta As New DataTable
                dta.Rows.Clear()
                If ComboSucursal.Text = "SAN RAFAEL" Then
                    dta = Clase.RCDumbar(cmbEntregador.SelectedValue, cmbFecha.Value.Date, "A", "DEV", cmbFecha2.Value.Date)
                Else
                    dta = Clase.RCDumbarDIMOSA(cmbEntregador.SelectedValue, cmbFecha.Value.Date, "A", "DEV", cmbFecha2.Value.Date)
                End If

                Dim Dev As Decimal = 0
                Try
                    Dev = dta(0)(0)
                Catch ex As Exception
                End Try


                dinerobodega.Text = Val(dinerocontado.Text) + Val(dinerocredito.Text)
                dinerodevoluciones.Text = Val(Dev)

                TotalDineroMDev.Text = Val(dinerobodega.Text) - Val(dinerodevoluciones.Text)
                TotalDineroMDev.Text = FormatNumber(Val(TotalDineroMDev.Text), 2)
                dinerodevoluciones.Text = FormatNumber(Val(dinerodevoluciones.Text), 2)
                dinerobodega.Text = FormatNumber(Val(dinerobodega.Text), 2)
                dinerocredito.Text = FormatNumber(Val(dinerocredito.Text), 2)
                dinerocontado.Text = FormatNumber(Val(dinerocontado.Text), 2)

                CalculaRangos()

                Dim conexion_bita As New cls_bitacora_reporteador
                conexion_bita.RegistraBitacora(Now, _Inicio.lblUsuario.Text, "Genero Reporte Dunbar", "Supply Chain", _
                                          "Fecha del reporte: " + cmbFecha.Value.Date + " Entregador: " + cmbEntregador.Text + " Fecha " + Today.Date _
                                          + " Entregador:" + cmbEntregador.Text)

            Catch ex As Exception
                MsgBox("Error al Generar Reporte de Carga ")
            End Try
        End If

    End Sub

    Private Sub ReporteCarga_Dumbar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            ComboSucursal.Items.Clear()
        Catch ex As Exception
        End Try
        If _Inicio.SANRAFAEL = 1 Then
            ComboSucursal.Items.Add("SAN RAFAEL")
        End If
        If _Inicio.DIMOSA = 1 Then
            ComboSucursal.Items.Add("DIMOSA")
        End If
        ComboSucursal.SelectedIndex = 0
        Try
            Sucursal = _Inicio.Almacen
        Catch ex As Exception
        End Try
        'MsgBox(Sucursal)
        If Today.DayOfWeek = DayOfWeek.Monday Then
            cmbFecha.Value = DateAdd(DateInterval.Day, -2, Today)
            cmbFecha2.Value = DateAdd(DateInterval.Day, -2, Today)
        Else
            cmbFecha.Value = DateAdd(DateInterval.Day, -1, Today)
            cmbFecha2.Value = DateAdd(DateInterval.Day, -1, Today)
        End If

        LlenaEntregadores()
    End Sub

    Sub LlenaEntregadores()
        Try
            Dim db As New ClsEfectividad
            cmbEntregador.DataSource = db.Entregadores(Sucursal, ComboSucursal.Text)
            cmbEntregador.ValueMember = "EntregadorCodigo"
            cmbEntregador.DisplayMember = "EntregadorNombre"
        Catch ex As Exception
        End Try
    End Sub

    Sub CalculaRangos()
        Dim db As New cls_reporte_carga
        If ComboSucursal.Text = "SAN RAFAEL" Then
            DataGridView1.DataSource = db.RCDumbarFacturas(cmbEntregador.SelectedValue, cmbFecha.Value.Date, cmbFecha2.Value.Date)
            FacturasContado.DataSource = db.RCDumbarFacturasContado(cmbEntregador.SelectedValue, cmbFecha.Value.Date, cmbFecha2.Value.Date)
            FacturasCredito.DataSource = db.RCDumbarFacturasCredito(cmbEntregador.SelectedValue, cmbFecha.Value.Date, cmbFecha2.Value.Date)
        Else
            DataGridView1.DataSource = db.RCDumbarFacturasDimosa(cmbEntregador.SelectedValue, cmbFecha.Value.Date, cmbFecha2.Value.Date)
            FacturasContado.DataSource = db.RCDumbarFacturasContadoDIMOSA(cmbEntregador.SelectedValue, cmbFecha.Value.Date, cmbFecha2.Value.Date)
            FacturasCredito.DataSource = db.RCDumbarFacturasCreditoDIMOSA(cmbEntregador.SelectedValue, cmbFecha.Value.Date, cmbFecha2.Value.Date)
        End If
        

        'Dim counter As Integer = 0
        Try
            Dim Primera As String = DataGridView1.Rows(0).Cells(0).Value
            Dim Segunda As String = DataGridView1.Rows(0).Cells(0).Value
            Dim B As Integer = 0
            For Each row As DataGridViewRow In DataGridView1.Rows
                Dim A As Integer = Val(row.Cells(0).Value.ToString.Substring(10, 8))
                If row.Index = 0 Then
                    B = Val(row.Cells(0).Value.ToString.Substring(10, 8))
                Else
                    B = Val(DataGridView1.Rows(row.Index - 1).Cells(0).Value.ToString.Substring(10, 8))
                    Segunda = DataGridView1.Rows(row.Index - 1).Cells(0).Value
                End If
                Try
                    If A <= B + 1 Then
                    Else
                        Rangos.Rows.Add(Primera, Segunda)
                        Primera = row.Cells(0).Value
                    End If

                    If row.Index = DataGridView1.RowCount - 1 Then
                        Rangos.Rows.Add(Primera, DataGridView1.Rows(row.Index).Cells(0).Value)
                    End If

                Catch ex As Exception
                End Try
            Next
        Catch ex As Exception
            'MsgBox("error" & ex.Message)
        End Try

        'Contado
        'Dim counter As Integer = 0
        Try
            Dim Primera As String = FacturasContado.Rows(0).Cells(0).Value
            Dim Segunda As String = FacturasContado.Rows(0).Cells(0).Value
            Dim B As Integer = 0
            For Each row As DataGridViewRow In FacturasContado.Rows
                Dim A As Integer = Val(row.Cells(0).Value.ToString.Substring(10, 8))
                If row.Index = 0 Then
                    B = Val(row.Cells(0).Value.ToString.Substring(10, 8))
                Else
                    B = Val(FacturasContado.Rows(row.Index - 1).Cells(0).Value.ToString.Substring(10, 8))
                    Segunda = FacturasContado.Rows(row.Index - 1).Cells(0).Value
                End If
                Try
                    If A <= B + 1 Then
                    Else
                        RangosContado.Rows.Add(Primera, Segunda)
                        Primera = row.Cells(0).Value
                    End If

                    If row.Index = FacturasContado.RowCount - 1 Then
                        RangosContado.Rows.Add(Primera, FacturasContado.Rows(row.Index).Cells(0).Value)
                    End If

                Catch ex As Exception
                End Try
            Next
        Catch ex As Exception
            'MsgBox("error" & ex.Message)
        End Try

        'Crédito
        'Dim counter As Integer = 0
        Try
            Dim Primera As String = FacturasCredito.Rows(0).Cells(0).Value
            Dim Segunda As String = FacturasCredito.Rows(0).Cells(0).Value
            Dim B As Integer = 0
            For Each row As DataGridViewRow In FacturasCredito.Rows
                Dim A As Integer = Val(row.Cells(0).Value.ToString.Substring(10, 8))
                If row.Index = 0 Then
                    B = Val(row.Cells(0).Value.ToString.Substring(10, 8))
                Else
                    B = Val(FacturasCredito.Rows(row.Index - 1).Cells(0).Value.ToString.Substring(10, 8))
                    Segunda = FacturasCredito.Rows(row.Index - 1).Cells(0).Value
                End If
                Try
                    If A <= B + 1 Then
                    Else
                        RangosCredito.Rows.Add(Primera, Segunda)
                        Primera = row.Cells(0).Value
                    End If

                    If row.Index = FacturasCredito.RowCount - 1 Then
                        RangosCredito.Rows.Add(Primera, FacturasCredito.Rows(row.Index).Cells(0).Value)
                    End If

                Catch ex As Exception
                End Try
            Next
        Catch ex As Exception
            'MsgBox("error" & ex.Message)
        End Try



        ''Contado
        'Try
        '    Dim Primera As String = ""
        '    Dim Segunda As String = ""

        '    Dim Numero1 As Integer = 0
        '    Dim Numero2 As Integer = 0

        '    Dim primerafila As Integer

        '    For Each row As DataGridViewRow In DataGridView1.Rows
        '        If row.Cells(3).Value <> "" Then
        '            Primera = row.Cells(0).Value
        '            Segunda = row.Cells(0).Value
        '            Numero1 = Val(row.Cells(0).Value.ToString.Substring(10, 8))
        '            Numero2 = Val(row.Cells(0).Value.ToString.Substring(10, 8))
        '            primerafila = row.Index
        '            Exit For
        '        End If
        '    Next

        '    For Each row As DataGridViewRow In DataGridView1.Rows
        '        If row.Index <= primerafila Then
        '        Else
        '            Numero1 = Val(row.Cells(0).Value.ToString.Substring(10, 8))
        '            Numero2 = Val(DataGridView1.Rows(row.Index - 1).Cells(0).Value.ToString.Substring(10, 8))

        '            Try
        '                If DataGridView1.Rows(row.Index - 1).Cells(3).Value <> "" Then

        '                    Segunda = DataGridView1.Rows(row.Index - 1).Cells(0).Value

        '                    If Numero1 = Numero2 + 1 Then
        '                    Else
        '                        RangosContado.Rows.Add(Primera, Segunda)
        '                        If row.Cells(3).Value <> "" Then
        '                            Primera = row.Cells(0).Value
        '                            Segunda = row.Cells(0).Value
        '                        Else
        '                            For x As Integer = row.Index To DataGridView1.RowCount
        '                                If DataGridView1.Rows(x).Cells(3).Value <> "" Then
        '                                    Primera = DataGridView1.Rows(x).Cells(0).Value
        '                                    Segunda = DataGridView1.Rows(x).Cells(0).Value
        '                                    Exit For
        '                                End If
        '                            Next
        '                        End If
        '                    End If

        '                Else
        '                    If DataGridView1.Rows(row.Index - 1).Cells(3).Value <> "" Then
        '                        Try
        '                            If RangosContado.Rows(RangosContado.RowCount - 1).Cells(0).Value <> Primera And RangosCredito.Rows(RangosContado.RowCount - 1).Cells(1).Value <> Segunda Then
        '                                RangosContado.Rows.Add(Primera, Segunda)
        '                            End If
        '                        Catch ex As Exception
        '                            RangosContado.Rows.Add(Primera, Segunda)
        '                        End Try
        '                    End If
        '                    If row.Cells(3).Value <> "" Then
        '                        Primera = row.Cells(0).Value
        '                        Segunda = row.Cells(0).Value
        '                    Else
        '                        For x As Integer = row.Index To DataGridView1.RowCount
        '                            If DataGridView1.Rows(x).Cells(3).Value <> "" Then
        '                                Primera = DataGridView1.Rows(x).Cells(0).Value
        '                                Segunda = DataGridView1.Rows(x).Cells(0).Value
        '                                Exit For
        '                            End If
        '                        Next
        '                    End If
        '                End If
        '            Catch ex As Exception
        '            End Try

        '        End If

        '        If row.Index = DataGridView1.RowCount - 1 And row.Cells(3).Value <> "" Then
        '            RangosContado.Rows.Add(Primera, DataGridView1.Rows(row.Index).Cells(0).Value)
        '        End If
        '    Next

        'Catch ex As Exception
        'End Try

        ''Credito
        'Try
        '    Dim Primera As String = ""
        '    Dim Segunda As String = ""

        '    Dim Numero1 As Integer = 0
        '    Dim Numero2 As Integer = 0

        '    Dim primerafila As Integer



        '    For a As Integer = 0 To DataGridView1.RowCount - 1
        '        If DataGridView1.Rows(a).Cells(3).Value = "" Then
        '            If Primera = "" Then
        '                Primera = DataGridView1.Rows(a).Cells(0).Value
        '            End If
        '            Segunda = DataGridView1.Rows(a).Cells(0).Value
        '            Numero1 = Val(DataGridView1.Rows(a).Cells(0).Value.ToString.Substring(10, 8))
        '            Numero2 = Val(DataGridView1.Rows(a).Cells(0).Value.ToString.Substring(10, 8))
        '            primerafila = DataGridView1.Rows(a).Index
        '        End If

        '    Next
        'Catch ex As Exception
        'End Try
        

    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        _btnGenerar.PerformClick()
        If Sucursal = 1 Then
            enviar()
        End If
        If Sucursal = 4 Then
            enviarTegucigalpa()
        End If
        If Sucursal = 2 Then
            enviarSRC()
        End If

        'EnvioMail()
    End Sub

    Sub enviar()
        Try
            Dim SMTP As String = "ns6499.hostgator.com"
            Dim Usuario As String = "liquidaciones@disarhn.com"
            Dim Contraseña As String = "liquidar100"

            Dim Puerto As Integer = 25
            Dim correo As New System.Net.Mail.MailMessage()
            Dim Servidor As New System.Net.Mail.SmtpClient
            Dim Acceso As New System.Net.Mail.SmtpAccess

            Dim Contenido As String = ""

            If cmbFecha.Value.Date = cmbFecha2.Value.Date Then
                Contenido = "Liquidación de " & cmbEntregador.Text & " con fecha " & cmbFecha.Value.Date

                Contenido = Contenido & vbNewLine & vbNewLine & vbNewLine & "Facturas de Contado: " & vbNewLine
                For Each row As DataGridViewRow In RangosContado.Rows
                    Try
                        Contenido = Contenido & vbNewLine & "Rango: desde " & row.Cells(0).Value & " hasta " & row.Cells(1).Value & vbTab & vbNewLine
                        Contenido = Contenido & vbNewLine & vbTab & "Total Contado: " & vbTab & vbTab & "L " & FormatNumber(row.Cells(2).Value, 2) & vbNewLine
                        Contenido = Contenido & vbNewLine & vbTab & "Devoluciones: " & vbTab & vbTab & "L " & FormatNumber(row.Cells(3).Value, 2)
                        Contenido = Contenido & vbNewLine & "______________________________________________" & vbNewLine
                    Catch ex As Exception
                    End Try
                Next
                Contenido = Contenido & vbNewLine & "______________________________________________"
                Contenido = Contenido & vbNewLine & vbNewLine & vbNewLine & "Facturas de Crédito: " & vbNewLine
                For Each row As DataGridViewRow In RangosCredito.Rows
                    Try
                        Contenido = Contenido & vbNewLine & "Rango: desde " & row.Cells(0).Value & " hasta " & row.Cells(1).Value & vbTab & vbNewLine
                        Contenido = Contenido & vbNewLine & vbTab & "Total Crédito: " & vbTab & vbTab & "L " & FormatNumber(row.Cells(2).Value, 2) & vbNewLine
                        Contenido = Contenido & vbNewLine & vbTab & "Devoluciones: " & vbTab & vbTab & "L " & FormatNumber(row.Cells(3).Value, 2)
                        Contenido = Contenido & vbNewLine & "______________________________________________" & vbNewLine
                    Catch ex As Exception
                    End Try
                Next

                '            " Total contado: " & vbTab & vbTab & dinerocontado.Text & vbNewLine & _
                '            " Total crédito: " & vbTab & vbTab & vbTab & dinerocredito.Text & vbNewLine & _
                '            "________________________________" & vbNewLine & vbNewLine & _
                '            " Total: " & vbTab & vbTab & vbTab & vbTab & dinerobodega.Text & vbNewLine & _
                '            " Devoluciones: " & vbTab & vbTab & vbTab & dinerodevoluciones.Text & vbNewLine
                ''"________________________________" & vbNewLine & vbNewLine & _
                ''" TOTAL: " & vbTab & vbTab & vbTab & TotalDineroMDev.Text
            Else
                Contenido = "Liquidación de " & cmbEntregador.Text & " con fechas " & cmbFecha.Value.Date & " a " & cmbFecha2.Value.Date & vbNewLine & vbNewLine & vbNewLine

                Contenido = Contenido & vbNewLine & vbNewLine & vbNewLine & "Facturas de Contado: " & vbNewLine & vbNewLine
                For Each row As DataGridViewRow In RangosContado.Rows
                    Try
                        Contenido = Contenido & vbNewLine & "Rango: desde " & row.Cells(0).Value & " hasta " & row.Cells(1).Value & vbTab & vbNewLine
                        Contenido = Contenido & vbNewLine & " Total: " & vbTab & vbTab & vbTab & "L " & FormatNumber(row.Cells(2).Value, 2) & vbNewLine
                        Contenido = Contenido & vbNewLine & " Devoluciones: " & vbTab & vbTab & "L " & FormatNumber(row.Cells(3).Value, 2)
                        Contenido = Contenido & vbNewLine & vbNewLine & "___________________________"
                    Catch ex As Exception
                    End Try
                Next
                Contenido = Contenido & vbNewLine & vbNewLine & vbNewLine & "Facturas de Crédito: " & vbNewLine & vbNewLine
                For Each row As DataGridViewRow In RangosCredito.Rows
                    Try
                        Contenido = Contenido & vbNewLine & "Rango: desde " & row.Cells(0).Value & " hasta " & row.Cells(1).Value & vbTab & vbNewLine
                        Contenido = Contenido & vbNewLine & " Total: " & vbTab & vbTab & vbTab & "L " & FormatNumber(row.Cells(2).Value, 2) & vbNewLine
                        Contenido = Contenido & vbNewLine & " Devoluciones: " & vbTab & vbTab & "L " & FormatNumber(row.Cells(3).Value, 2)
                        Contenido = Contenido & vbNewLine & vbNewLine & "___________________________"
                    Catch ex As Exception
                    End Try
                Next
                '           " Total contado: " & vbTab & vbTab & dinerocontado.Text & vbNewLine & _
                '           " Total crédito: " & vbTab & vbTab & vbTab & dinerocredito.Text & vbNewLine & _
                '           "________________________________" & vbNewLine & vbNewLine & _
                '           " Total: " & vbTab & vbTab & vbTab & vbTab & dinerobodega.Text & vbNewLine & _
                '           " Devoluciones: " & vbTab & vbTab & vbTab & dinerodevoluciones.Text & vbNewLine
                ''"________________________________" & vbNewLine & vbNewLine & _
                ''" TOTAL: " & vbTab & vbTab & vbTab & TotalDineroMDev.Text
            End If

            

            Dim Asunto As String = ""
            If cmbFecha.Value.Date = cmbFecha2.Value.Date Then
                Asunto = "Liquidación de " & cmbEntregador.Text & " - " & cmbFecha.Value.Date
            Else
                Asunto = "Liquidación de " & cmbEntregador.Text & " - Fechas: " & cmbFecha.Value.Date & " a " & cmbFecha2.Value.Date
            End If
            'Asunto = Asunto & "[Pruebas de Sistema]"
            'Contenido = "Pruebas de Sistema de liquidaciones DISAR N 4"
            Asunto = Asunto & " " & "[SPS]"

            correo.From = New System.Net.Mail.MailAddress(Usuario)
            correo.Subject = Asunto


            'correo.To.Add("liquidacion.sps@dicenam.com")

            'correo.CC.Add("jefesalas.sap@dicenam.com")

            correo.To.Add("wilian.hernandez@sanrafaelhn.com")
            correo.To.Add("victor.delgado@sanrafael.com")

            correo.CC.Add("mario.amaya@sanrafael.com")
            correo.CC.Add("lizzette.sabillon@sanrafael.com")
            correo.CC.Add("esdras.ardon@sanrafael.com")
            correo.CC.Add("leonel.cruz@sanrafael.com")
            correo.CC.Add("mery.reyes@sanrafael.com")
            correo.CC.Add("carolina.moncada@sanrafael.com")

            'correo.CC.Add("aron.castillo@disarhn.com")
            'correo.CC.Add("kenny.rodriguez@disarhn.com")
            'correo.CC.Add("hector.fajardo@disarhn.com")
            'correo.To.Add("jose.cardenas@disarhn.com")

            correo.Body = Contenido
            Servidor.Host = SMTP
            Servidor.Port = Puerto

            Servidor.EnableSsl = False

            Servidor.Credentials = New System.Net.NetworkCredential(Usuario, Contraseña)

            Servidor.Send(correo)
            MessageBox.Show("El correo se envió exitosamente.", "Envío: " & cmbEntregador.Text & " - " & cmbFecha.Value.Date, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Se envió correo. " + ex.Message, "Correo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub LlenaTotales()
        For Each row As DataGridViewRow In RangosContado.Rows
            Try
                Dim db As New cls_reporte_carga
                Dim dt As New DataTable
                dt.Rows.Clear()
                If ComboSucursal.Text = "SAN RAFAEL" Then
                    dt = db.RCDumbarTotales(cmbEntregador.SelectedValue, row.Cells(0).Value, row.Cells(1).Value)
                Else
                    dt = db.RCDumbarTotalesDIMOSA(cmbEntregador.SelectedValue, row.Cells(0).Value, row.Cells(1).Value)
                End If

                Dim Total As Decimal = 0
                Total = dt(0)(0)
                row.Cells(2).Value = Total

                dt.Rows.Clear()
                If ComboSucursal.Text = "SAN RAFAEL" Then
                    dt = db.RCDumbarDevoluciones(cmbEntregador.SelectedValue, row.Cells(0).Value, row.Cells(1).Value)
                Else
                    dt = db.RCDumbarDevolucionesDIMOSA(cmbEntregador.SelectedValue, row.Cells(0).Value, row.Cells(1).Value)
                End If

                Total = 0
                Try
                    Total = dt(0)(0)
                    row.Cells(3).Value = Total
                Catch ex As Exception
                    row.Cells(3).Value = "0.00"
                End Try
            Catch ex As Exception
            End Try
        Next

        For Each row As DataGridViewRow In RangosCredito.Rows
            Try
                Dim db As New cls_reporte_carga
                Dim dt As New DataTable
                dt.Rows.Clear()
                If ComboSucursal.Text = "SAN RAFAEL" Then
                    dt = db.RCDumbarTotales(cmbEntregador.SelectedValue, row.Cells(0).Value, row.Cells(1).Value)
                Else
                    dt = db.RCDumbarTotalesDIMOSA(cmbEntregador.SelectedValue, row.Cells(0).Value, row.Cells(1).Value)
                End If

                Dim Total As Decimal = 0
                Total = dt(0)(0)
                row.Cells(2).Value = Total

                dt.Rows.Clear()
                If ComboSucursal.Text = "SAN RAFAEL" Then
                    dt = db.RCDumbarDevoluciones(cmbEntregador.SelectedValue, row.Cells(0).Value, row.Cells(1).Value)
                Else
                    dt = db.RCDumbarDevolucionesDIMOSA(cmbEntregador.SelectedValue, row.Cells(0).Value, row.Cells(1).Value)
                End If

                Total = 0
                Try
                    Total = dt(0)(0)
                    row.Cells(3).Value = Total
                Catch ex As Exception
                    row.Cells(3).Value = "0.00"
                End Try
            Catch ex As Exception
            End Try
        Next
    End Sub

    Sub enviarTegucigalpa()
        Try
            Dim SMTP As String = "ns6499.hostgator.com"
            Dim Usuario As String = "liquidaciones@disarhn.com"
            Dim Contraseña As String = "liquidar100"

            Dim Puerto As Integer = 25
            Dim correo As New System.Net.Mail.MailMessage()
            Dim Servidor As New System.Net.Mail.SmtpClient
            Dim Acceso As New System.Net.Mail.SmtpAccess

            Dim Contenido As String = ""

            If cmbFecha.Value.Date = cmbFecha2.Value.Date Then
                Contenido = "Liquidación de " & cmbEntregador.Text & " con fecha " & cmbFecha.Value.Date

                Contenido = Contenido & vbNewLine & vbNewLine & vbNewLine & "Facturas de Contado: " & vbNewLine
                For Each row As DataGridViewRow In RangosContado.Rows
                    Try
                        Contenido = Contenido & vbNewLine & "Rango: desde " & row.Cells(0).Value & " hasta " & row.Cells(1).Value & vbTab & vbNewLine
                        Contenido = Contenido & vbNewLine & vbTab & "Total Contado: " & vbTab & vbTab & "L " & FormatNumber(row.Cells(2).Value, 2) & vbNewLine
                        Contenido = Contenido & vbNewLine & vbTab & "Devoluciones: " & vbTab & vbTab & "L " & FormatNumber(row.Cells(3).Value, 2)
                        Contenido = Contenido & vbNewLine & "______________________________________________" & vbNewLine
                    Catch ex As Exception
                    End Try
                Next
                Contenido = Contenido & vbNewLine & "______________________________________________"
                Contenido = Contenido & vbNewLine & vbNewLine & vbNewLine & "Facturas de Crédito: " & vbNewLine
                For Each row As DataGridViewRow In RangosCredito.Rows
                    Try
                        Contenido = Contenido & vbNewLine & "Rango: desde " & row.Cells(0).Value & " hasta " & row.Cells(1).Value & vbTab & vbNewLine
                        Contenido = Contenido & vbNewLine & vbTab & "Total Crédito: " & vbTab & vbTab & "L " & FormatNumber(row.Cells(2).Value, 2) & vbNewLine
                        Contenido = Contenido & vbNewLine & vbTab & "Devoluciones: " & vbTab & vbTab & "L " & FormatNumber(row.Cells(3).Value, 2)
                        Contenido = Contenido & vbNewLine & "______________________________________________" & vbNewLine
                    Catch ex As Exception
                    End Try
                Next

                '            " Total contado: " & vbTab & vbTab & dinerocontado.Text & vbNewLine & _
                '            " Total crédito: " & vbTab & vbTab & vbTab & dinerocredito.Text & vbNewLine & _
                '            "________________________________" & vbNewLine & vbNewLine & _
                '            " Total: " & vbTab & vbTab & vbTab & vbTab & dinerobodega.Text & vbNewLine & _
                '            " Devoluciones: " & vbTab & vbTab & vbTab & dinerodevoluciones.Text & vbNewLine
                ''"________________________________" & vbNewLine & vbNewLine & _
                ''" TOTAL: " & vbTab & vbTab & vbTab & TotalDineroMDev.Text
            Else
                Contenido = "Liquidación de " & cmbEntregador.Text & " con fechas " & cmbFecha.Value.Date & " a " & cmbFecha2.Value.Date & vbNewLine & vbNewLine & vbNewLine

                Contenido = Contenido & vbNewLine & vbNewLine & vbNewLine & "Facturas de Contado: " & vbNewLine & vbNewLine
                For Each row As DataGridViewRow In RangosContado.Rows
                    Try
                        Contenido = Contenido & vbNewLine & "Rango: desde " & row.Cells(0).Value & " hasta " & row.Cells(1).Value & vbTab & vbNewLine
                        Contenido = Contenido & vbNewLine & " Total: " & vbTab & vbTab & vbTab & "L " & FormatNumber(row.Cells(2).Value, 2) & vbNewLine
                        Contenido = Contenido & vbNewLine & " Devoluciones: " & vbTab & vbTab & "L " & FormatNumber(row.Cells(3).Value, 2)
                        Contenido = Contenido & vbNewLine & vbNewLine & "___________________________"
                    Catch ex As Exception
                    End Try
                Next
                Contenido = Contenido & vbNewLine & vbNewLine & vbNewLine & "Facturas de Crédito: " & vbNewLine & vbNewLine
                For Each row As DataGridViewRow In RangosCredito.Rows
                    Try
                        Contenido = Contenido & vbNewLine & "Rango: desde " & row.Cells(0).Value & " hasta " & row.Cells(1).Value & vbTab & vbNewLine
                        Contenido = Contenido & vbNewLine & " Total: " & vbTab & vbTab & vbTab & "L " & FormatNumber(row.Cells(2).Value, 2) & vbNewLine
                        Contenido = Contenido & vbNewLine & " Devoluciones: " & vbTab & vbTab & "L " & FormatNumber(row.Cells(3).Value, 2)
                        Contenido = Contenido & vbNewLine & vbNewLine & "___________________________"
                    Catch ex As Exception
                    End Try
                Next
                '           " Total contado: " & vbTab & vbTab & dinerocontado.Text & vbNewLine & _
                '           " Total crédito: " & vbTab & vbTab & vbTab & dinerocredito.Text & vbNewLine & _
                '           "________________________________" & vbNewLine & vbNewLine & _
                '           " Total: " & vbTab & vbTab & vbTab & vbTab & dinerobodega.Text & vbNewLine & _
                '           " Devoluciones: " & vbTab & vbTab & vbTab & dinerodevoluciones.Text & vbNewLine
                ''"________________________________" & vbNewLine & vbNewLine & _
                ''" TOTAL: " & vbTab & vbTab & vbTab & TotalDineroMDev.Text
            End If



            Dim Asunto As String = ""
            If cmbFecha.Value.Date = cmbFecha2.Value.Date Then
                Asunto = "Liquidación de " & cmbEntregador.Text & " - " & cmbFecha.Value.Date
            Else
                Asunto = "Liquidación de " & cmbEntregador.Text & " - Fechas: " & cmbFecha.Value.Date & " a " & cmbFecha2.Value.Date
            End If
            'Asunto = Asunto & "[Pruebas de Sistema]"
            'Contenido = "Pruebas de Sistema de liquidaciones DISAR N 4"
            Asunto = Asunto & " " & "[TEG]"

            correo.From = New System.Net.Mail.MailAddress(Usuario)
            correo.Subject = Asunto


            correo.To.Add("rony.argueta@dicenam.com")
            correo.CC.Add("centro.liquidacion@dicenam.com")

            correo.CC.Add("mario.amaya@sanrafael.com")
            correo.CC.Add("lizzette.sabillon@sanrafael.com")
            correo.CC.Add("esdras.ardon@sanrafael.com")
            correo.CC.Add("leonel.cruz@sanrafael.com")
            correo.CC.Add("mery.reyes@sanrafael.com")
            correo.CC.Add("carolina.moncada@sanrafael.com")

            'correo.CC.Add("aron.castillo@disarhn.com")
            'correo.CC.Add("kenny.rodriguez@disarhn.com")
            'correo.CC.Add("hector.fajardo@disarhn.com")
            'correo.To.Add("jose.cardenas@disarhn.com")

            correo.Body = Contenido
            Servidor.Host = SMTP
            Servidor.Port = Puerto

            Servidor.EnableSsl = False

            Servidor.Credentials = New System.Net.NetworkCredential(Usuario, Contraseña)

            Servidor.Send(correo)
            MessageBox.Show("El correo se envió exitosamente.", "Envío: " & cmbEntregador.Text & " - " & cmbFecha.Value.Date, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Se envió correo. " + ex.Message, "Correo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub enviarSRC()
        Try
            Dim SMTP As String = "ns6499.hostgator.com"
            Dim Usuario As String = "liquidaciones@disarhn.com"
            Dim Contraseña As String = "liquidar100"

            Dim Puerto As Integer = 25
            Dim correo As New System.Net.Mail.MailMessage()
            Dim Servidor As New System.Net.Mail.SmtpClient
            Dim Acceso As New System.Net.Mail.SmtpAccess

            Dim Contenido As String = ""

            If cmbFecha.Value.Date = cmbFecha2.Value.Date Then
                Contenido = "Liquidación de " & cmbEntregador.Text & " con fecha " & cmbFecha.Value.Date

                Contenido = Contenido & vbNewLine & vbNewLine & vbNewLine & "Facturas de Contado: " & vbNewLine
                For Each row As DataGridViewRow In RangosContado.Rows
                    Try
                        Contenido = Contenido & vbNewLine & "Rango: desde " & row.Cells(0).Value & " hasta " & row.Cells(1).Value & vbTab & vbNewLine
                        Contenido = Contenido & vbNewLine & vbTab & "Total Contado: " & vbTab & vbTab & "L " & FormatNumber(row.Cells(2).Value, 2) & vbNewLine
                        Contenido = Contenido & vbNewLine & vbTab & "Devoluciones: " & vbTab & vbTab & "L " & FormatNumber(row.Cells(3).Value, 2)
                        Contenido = Contenido & vbNewLine & "______________________________________________" & vbNewLine
                    Catch ex As Exception
                    End Try
                Next
                Contenido = Contenido & vbNewLine & "______________________________________________"
                Contenido = Contenido & vbNewLine & vbNewLine & vbNewLine & "Facturas de Crédito: " & vbNewLine
                For Each row As DataGridViewRow In RangosCredito.Rows
                    Try
                        Contenido = Contenido & vbNewLine & "Rango: desde " & row.Cells(0).Value & " hasta " & row.Cells(1).Value & vbTab & vbNewLine
                        Contenido = Contenido & vbNewLine & vbTab & "Total Crédito: " & vbTab & vbTab & "L " & FormatNumber(row.Cells(2).Value, 2) & vbNewLine
                        Contenido = Contenido & vbNewLine & vbTab & "Devoluciones: " & vbTab & vbTab & "L " & FormatNumber(row.Cells(3).Value, 2)
                        Contenido = Contenido & vbNewLine & "______________________________________________" & vbNewLine
                    Catch ex As Exception
                    End Try
                Next

                '            " Total contado: " & vbTab & vbTab & dinerocontado.Text & vbNewLine & _
                '            " Total crédito: " & vbTab & vbTab & vbTab & dinerocredito.Text & vbNewLine & _
                '            "________________________________" & vbNewLine & vbNewLine & _
                '            " Total: " & vbTab & vbTab & vbTab & vbTab & dinerobodega.Text & vbNewLine & _
                '            " Devoluciones: " & vbTab & vbTab & vbTab & dinerodevoluciones.Text & vbNewLine
                ''"________________________________" & vbNewLine & vbNewLine & _
                ''" TOTAL: " & vbTab & vbTab & vbTab & TotalDineroMDev.Text
            Else
                Contenido = "Liquidación de " & cmbEntregador.Text & " con fechas " & cmbFecha.Value.Date & " a " & cmbFecha2.Value.Date & vbNewLine & vbNewLine & vbNewLine

                Contenido = Contenido & vbNewLine & vbNewLine & vbNewLine & "Facturas de Contado: " & vbNewLine & vbNewLine
                For Each row As DataGridViewRow In RangosContado.Rows
                    Try
                        Contenido = Contenido & vbNewLine & "Rango: desde " & row.Cells(0).Value & " hasta " & row.Cells(1).Value & vbTab & vbNewLine
                        Contenido = Contenido & vbNewLine & " Total: " & vbTab & vbTab & vbTab & "L " & FormatNumber(row.Cells(2).Value, 2) & vbNewLine
                        Contenido = Contenido & vbNewLine & " Devoluciones: " & vbTab & vbTab & "L " & FormatNumber(row.Cells(3).Value, 2)
                        Contenido = Contenido & vbNewLine & vbNewLine & "___________________________"
                    Catch ex As Exception
                    End Try
                Next
                Contenido = Contenido & vbNewLine & vbNewLine & vbNewLine & "Facturas de Crédito: " & vbNewLine & vbNewLine
                For Each row As DataGridViewRow In RangosCredito.Rows
                    Try
                        Contenido = Contenido & vbNewLine & "Rango: desde " & row.Cells(0).Value & " hasta " & row.Cells(1).Value & vbTab & vbNewLine
                        Contenido = Contenido & vbNewLine & " Total: " & vbTab & vbTab & vbTab & "L " & FormatNumber(row.Cells(2).Value, 2) & vbNewLine
                        Contenido = Contenido & vbNewLine & " Devoluciones: " & vbTab & vbTab & "L " & FormatNumber(row.Cells(3).Value, 2)
                        Contenido = Contenido & vbNewLine & vbNewLine & "___________________________"
                    Catch ex As Exception
                    End Try
                Next
                '           " Total contado: " & vbTab & vbTab & dinerocontado.Text & vbNewLine & _
                '           " Total crédito: " & vbTab & vbTab & vbTab & dinerocredito.Text & vbNewLine & _
                '           "________________________________" & vbNewLine & vbNewLine & _
                '           " Total: " & vbTab & vbTab & vbTab & vbTab & dinerobodega.Text & vbNewLine & _
                '           " Devoluciones: " & vbTab & vbTab & vbTab & dinerodevoluciones.Text & vbNewLine
                ''"________________________________" & vbNewLine & vbNewLine & _
                ''" TOTAL: " & vbTab & vbTab & vbTab & TotalDineroMDev.Text
            End If



            Dim Asunto As String = ""
            If cmbFecha.Value.Date = cmbFecha2.Value.Date Then
                Asunto = "Liquidación de " & cmbEntregador.Text & " - " & cmbFecha.Value.Date
            Else
                Asunto = "Liquidación de " & cmbEntregador.Text & " - Fechas: " & cmbFecha.Value.Date & " a " & cmbFecha2.Value.Date
            End If
            'Asunto = Asunto & "[Pruebas de Sistema]"
            'Contenido = "Pruebas de Sistema de liquidaciones DISAR N 4"
            Asunto = Asunto & " " & "[SRC]"

            correo.From = New System.Net.Mail.MailAddress(Usuario)
            correo.Subject = Asunto



            correo.To.Add("mauricio.rodriguez@sanrafael.com")
            correo.To.Add("cesar.vasquez@sanrafael.com")
            correo.To.Add("bryan.miranda@sanrafaelhn.com")
            'correo.CC.Add("centro.liquidacion@dicenam.com")

            correo.CC.Add("osiris.dubon@sanrafael.com")
            'correo.CC.Add("angelica.escalante@disarhn.com")
            correo.CC.Add("yenis.valeriano@sanrafael.com")
            correo.CC.Add("esdras.ardon@sanrafael.com")
            correo.CC.Add("leonel.cruz@sanrafael.com")
            correo.CC.Add("mery.reyes@sanrafael.com")

            'correo.CC.Add("carolina.moncada@disarhn.com")

            'correo.CC.Add("aron.castillo@disarhn.com")
            'correo.CC.Add("kenny.rodriguez@disarhn.com")
            'correo.CC.Add("hector.fajardo@disarhn.com")
            'correo.To.Add("jose.cardenas@disarhn.com")

            correo.Body = Contenido
            Servidor.Host = SMTP
            Servidor.Port = Puerto

            Servidor.EnableSsl = False

            Servidor.Credentials = New System.Net.NetworkCredential(Usuario, Contraseña)

            Servidor.Send(correo)
            MessageBox.Show("El correo se envió exitosamente.", "Envío: " & cmbEntregador.Text & " - " & cmbFecha.Value.Date, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Se envió correo. " + ex.Message, "Correo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    

End Class