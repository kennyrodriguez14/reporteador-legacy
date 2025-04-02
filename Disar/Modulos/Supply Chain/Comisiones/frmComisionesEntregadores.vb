Imports Disar.data

Public Class frmComisionesEntregadores

    Dim actual As String
    Public Empres As Integer = 0

    Private Sub BtnDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDetalle.Click
        If actual = "comisiones" Then
            Detalle.BringToFront()
            actual = "det"
            BtnDetalle.Text = "Detalle"
        Else
            Comisiones.BringToFront()
            actual = "comisiones"
            BtnDetalle.Text = "Comisiones"
        End If
    End Sub

    Private Sub frmComisionesEntregadores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Empres = _Inicio.Almacen
        Catch ex As Exception
        End Try
        actual = "det"
        Try
            Dim db As New ClsEfectividad
            ComboEntregador.DataSource = db.Entregadores(Empres, "SAN RAFAEL")
            ComboEntregador.ValueMember = "EntregadorCodigo"
            ComboEntregador.DisplayMember = "EntregadorNombre"
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnComisiones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnComisiones.Click
        Dim db As New ClsEfectividad
        Dim dt As New DataTable
        Dim ComEntregasTot As Decimal = 0
        Dim ComEntregasParciales As Decimal = 0
        Dim ComPeso As Decimal = 0
        Dim ComPesoMay As Decimal = 0
        Try
            dt.Rows.Clear()
        Catch ex As Exception
        End Try
        'Dim Tipo As Integer = 2

        'Tipo 1: Formato de cálculo actual: Afectado sólamente por los porcentajes ingresados
        If TextBox1.Text = 1 Then
            Dim almacen As Integer = 0
            dt = db.Almacen(ComboEntregador.SelectedValue)
            If dt(0)(0) = "SRC" Then
                almacen = 2
                ComEntregasTot = 3.1
                ComEntregasParciales = 1.55
                ComPeso = 1.7
            ElseIf dt(0)(0) = "SPS" Then
                almacen = 1
                ComEntregasTot = 3.1
                ComEntregasParciales = 1.55
                ComPeso = 1.7
            ElseIf dt(0)(0) = 3 Then
                almacen = 3
                ComEntregasTot = 3.1
                ComEntregasParciales = 1.55
                ComPeso = 1.7
            Else
                almacen = 4
                ComEntregasTot = 3.1
                ComEntregasParciales = 1.55
                ComPeso = 1.7
            End If

            Detalle.DataSource = db.ComisionesEntregador(Desde.Value.Date, Hasta.Value.Date, "Detalle", ComboEntregador.SelectedValue)
            Comisiones.DataSource = db.ComisionesEntregador(Desde.Value.Date, Hasta.Value.Date, "GENERAL", ComboEntregador.SelectedValue)

            If ComboEntregador.SelectedValue = 77 And Desde.Value <= "15/02/2018" And Hasta.Value >= "15/02/2018" Then
                'TextTotalPeso.Text = Val(Replace(TextTotalPeso.Text, ",", "")) + 8825
                Comisiones.Rows(0).Cells(3).Value = Comisiones.Rows(0).Cells(3).Value + 8825
                Comisiones.Rows(0).Cells(5).Value = Comisiones.Rows(0).Cells(5).Value + 8825
                Comisiones.Rows(0).Cells(6).Value = Comisiones.Rows(0).Cells(6).Value + 1
            End If

            Try
                TextTotalPeso.Text = FormatNumber(Comisiones.Rows(0).Cells(3).Value, 2)
            Catch ex As Exception
                TextTotalPeso.Text = ""
            End Try



            Try
                TextTotalPesoDevoluciones.Text = FormatNumber(Val(Comisiones.Rows(0).Cells(4).Value) * -1, 2)
            Catch ex As Exception
                TextTotalPesoDevoluciones.Text = ""
            End Try

            Try
                TextComisionesPeso.Text = FormatNumber(Val(Comisiones.Rows(0).Cells(5).Value) / 100, 2)
                If almacen = 4 Then
                    TextComisionesPeso.Text = FormatNumber((Val(Comisiones.Rows(0).Cells(5).Value) / 100) * ComPeso, 2)
                Else
                    TextComisionesPeso.Text = FormatNumber((Val(Comisiones.Rows(0).Cells(5).Value) / 100) * ComPeso, 2)
                End If
                'If almacen = 1 Then
                '    Dim PesoTot As Decimal = Val(Comisiones.Rows(0).Cells(3).Value)
                '    Dim PesoTotDev As Decimal = Val(Comisiones.Rows(0).Cells(4).Value)
                '    Dim PesoMay As Decimal = Val(Comisiones.Rows(0).Cells(8).Value)
                '    Dim PesoMayDev As Decimal = Val(Comisiones.Rows(0).Cells(9).Value)
                '    Dim PesoRest As Decimal = PesoTot - PesoMay
                '    Dim PesoRestDev As Decimal = PesoTotDev - PesoMayDev

                '    Dim ComisionesGral As Decimal = ((PesoRest - PesoRestDev) / 100)
                '    Dim ComisionesMay As Decimal = ((PesoMay - PesoMayDev) / 100) * 1.5

                '    TextComisionesPeso.Text = FormatNumber((ComisionesGral + ComisionesMay), 2)
                'End If
            Catch ex As Exception
                TextComisionesPeso.Text = ""
            End Try

            Try
                TextComisionesEntregasTotales.Text = FormatNumber((Val(Comisiones.Rows(0).Cells(6).Value) + Val(Comisiones.Rows(0).Cells(2).Value)) * ComEntregasTot, 2)
            Catch ex As Exception
                TextComisionesEntregasTotales.Text = ""
            End Try

            Try
                TextComisionesEntregasParciales.Text = FormatNumber(Val(Comisiones.Rows(0).Cells(7).Value) * ComEntregasParciales, 2)
            Catch ex As Exception
                TextComisionesEntregasParciales.Text = ""
            End Try

            Try
                TextTotalComisiones.Text = FormatNumber(Val(TextComisionesPeso.Text.Replace(",", "")) + Val(TextComisionesEntregasTotales.Text.Replace(",", "")) + Val(TextComisionesEntregasParciales.Text.Replace(",", "")), 2)
            Catch ex As Exception
                TextTotalComisiones.Text = ""
            End Try


            Try
                TextComisionesPeso.Text = "L. " & TextComisionesPeso.Text
                TextComisionesEntregasTotales.Text = "L. " & TextComisionesEntregasTotales.Text
                TextComisionesEntregasParciales.Text = "L. " & TextComisionesEntregasParciales.Text

                TextTotalComisiones.Text = "L. " & TextTotalComisiones.Text
            Catch ex As Exception
            End Try


            'Tipo 2: (Afecta pesos según si es Mayoreo o Detalle)
        ElseIf TextBox1.Text = 2 Then
            Dim almacen As Integer = 0
            dt = db.Almacen(ComboEntregador.SelectedValue)
            If dt(0)(0) = "SRC" Then
                almacen = 2
                ComEntregasTot = 3.1
                ComEntregasParciales = 1.55
                ComPeso = 1.35
                ComPesoMay = 1.5
            ElseIf dt(0)(0) = "SPS" Then
                almacen = 1
                ComEntregasTot = 3.1
                ComEntregasParciales = 1.55
                ComPeso = 1.35
                ComPesoMay = 1.7
            ElseIf dt(0)(0) = 3 Then
                almacen = 3
                ComEntregasTot = 3.1
                ComEntregasParciales = 1.55
                ComPeso = 1.35
                ComPesoMay = 1.5
            Else
                almacen = 4
                ComEntregasTot = 3.25
                ComEntregasParciales = 1.63
                ComPeso = 1.1
                ComPesoMay = 1.5
            End If

            Detalle.DataSource = db.ComisionesEntregador(Desde.Value.Date, Hasta.Value.Date, "Detalle", ComboEntregador.SelectedValue)
            Comisiones.DataSource = db.ComisionesEntregador(Desde.Value.Date, Hasta.Value.Date, "GENERAL", ComboEntregador.SelectedValue)

            If ComboEntregador.SelectedValue = 77 And Desde.Value <= "15/02/2018" And Hasta.Value >= "15/02/2018" Then
                'TextTotalPeso.Text = Val(Replace(TextTotalPeso.Text, ",", "")) + 8825
                Comisiones.Rows(0).Cells(3).Value = Comisiones.Rows(0).Cells(3).Value + 8825
                Comisiones.Rows(0).Cells(5).Value = Comisiones.Rows(0).Cells(5).Value + 8825
                Comisiones.Rows(0).Cells(6).Value = Comisiones.Rows(0).Cells(6).Value + 1
            End If

            Try
                TextTotalPeso.Text = FormatNumber(Comisiones.Rows(0).Cells(3).Value, 2)
            Catch ex As Exception
                TextTotalPeso.Text = ""
            End Try



            Try
                TextTotalPesoDevoluciones.Text = FormatNumber(Val(Comisiones.Rows(0).Cells(4).Value) * -1, 2)
            Catch ex As Exception
                TextTotalPesoDevoluciones.Text = ""
            End Try

            Try
                TextComisionesPeso.Text = FormatNumber(Val(Comisiones.Rows(0).Cells(5).Value) / 100, 2)
                If almacen = 4 Then
                    TextComisionesPeso.Text = FormatNumber((Val(Comisiones.Rows(0).Cells(5).Value) / 100) * 1.1, 2)
                Else
                    TextComisionesPeso.Text = FormatNumber((Val(Comisiones.Rows(0).Cells(5).Value) / 100) * 1.35, 2)
                End If

                Dim PesoTot As Decimal = Val(Comisiones.Rows(0).Cells(3).Value)
                Dim PesoTotDev As Decimal = Val(Comisiones.Rows(0).Cells(4).Value)
                Dim PesoMay As Decimal = Val(Comisiones.Rows(0).Cells(8).Value)
                Dim PesoMayDev As Decimal = Val(Comisiones.Rows(0).Cells(9).Value)
                Dim PesoRest As Decimal = PesoTot - PesoMay
                Dim PesoRestDev As Decimal = PesoTotDev - PesoMayDev

                Dim ComisionesGral As Decimal = ((PesoRest - PesoRestDev) / 100) * ComPeso
                Dim ComisionesMay As Decimal = ((PesoMay - PesoMayDev) / 100) * ComPesoMay

                TextComisionesPeso.Text = FormatNumber((ComisionesGral + ComisionesMay), 2)

            Catch ex As Exception
                TextComisionesPeso.Text = ""
            End Try

            Try
                TextComisionesEntregasTotales.Text = FormatNumber((Val(Comisiones.Rows(0).Cells(6).Value) + Val(Comisiones.Rows(0).Cells(2).Value)) * ComEntregasTot, 2)
            Catch ex As Exception
                TextComisionesEntregasTotales.Text = ""
            End Try

            Try
                TextComisionesEntregasParciales.Text = FormatNumber(Val(Comisiones.Rows(0).Cells(7).Value) * ComEntregasParciales, 2)
            Catch ex As Exception
                TextComisionesEntregasParciales.Text = ""
            End Try

            Try
                TextTotalComisiones.Text = FormatNumber(Val(TextComisionesPeso.Text.Replace(",", "")) + Val(TextComisionesEntregasTotales.Text.Replace(",", "")) + Val(TextComisionesEntregasParciales.Text.Replace(",", "")), 2)
            Catch ex As Exception
                TextTotalComisiones.Text = ""
            End Try


            Try
                TextComisionesPeso.Text = "L. " & TextComisionesPeso.Text
                TextComisionesEntregasTotales.Text = "L. " & TextComisionesEntregasTotales.Text
                TextComisionesEntregasParciales.Text = "L. " & TextComisionesEntregasParciales.Text

                TextTotalComisiones.Text = "L. " & TextTotalComisiones.Text
            Catch ex As Exception
            End Try


        ElseIf TextBox1.Text = 3 Then
            Dim almacen As Integer = 0
            dt = db.Almacen(ComboEntregador.SelectedValue)
            If dt(0)(0) = "SRC" Then
                almacen = 2
                ComEntregasTot = 3.1
                ComEntregasParciales = 1.55
                ComPeso = 1.35
                ComPesoMay = 1.5
            ElseIf dt(0)(0) = "SPS" Then
                almacen = 1
                ComEntregasTot = 3.1
                ComEntregasParciales = 1.55
                ComPeso = 1.35
                ComPesoMay = 1.6
            ElseIf dt(0)(0) = 3 Then
                almacen = 3
                ComEntregasTot = 3.1
                ComEntregasParciales = 1.55
                ComPeso = 1.35
                ComPesoMay = 1.5
            Else
                almacen = 4
                ComEntregasTot = 3.25
                ComEntregasParciales = 1.63
                ComPeso = 1.1
                ComPesoMay = 1.5
            End If

            Detalle.DataSource = db.ComisionesEntregador(Desde.Value.Date, Hasta.Value.Date, "Detalle", ComboEntregador.SelectedValue)
            Comisiones.DataSource = db.ComisionesEntregador(Desde.Value.Date, Hasta.Value.Date, "GENERAL3", ComboEntregador.SelectedValue)

            If ComboEntregador.SelectedValue = 77 And Desde.Value <= "15/02/2018" And Hasta.Value >= "15/02/2018" Then
                'TextTotalPeso.Text = Val(Replace(TextTotalPeso.Text, ",", "")) + 8825
                Comisiones.Rows(0).Cells(3).Value = Comisiones.Rows(0).Cells(3).Value + 8825
                Comisiones.Rows(0).Cells(5).Value = Comisiones.Rows(0).Cells(5).Value + 8825
                Comisiones.Rows(0).Cells(6).Value = Comisiones.Rows(0).Cells(6).Value + 1
            End If

            Try
                TextTotalPeso.Text = FormatNumber(Comisiones.Rows(0).Cells(3).Value, 2)
            Catch ex As Exception
                TextTotalPeso.Text = ""
            End Try



            Try
                TextTotalPesoDevoluciones.Text = FormatNumber(Val(Comisiones.Rows(0).Cells(4).Value) * -1, 2)
            Catch ex As Exception
                TextTotalPesoDevoluciones.Text = ""
            End Try

            Try
                TextComisionesPeso.Text = FormatNumber(Val(Comisiones.Rows(0).Cells(5).Value) / 100, 2)
                If almacen = 4 Then
                    TextComisionesPeso.Text = FormatNumber((Val(Comisiones.Rows(0).Cells(5).Value) / 100) * 1.1, 2)
                Else
                    TextComisionesPeso.Text = FormatNumber((Val(Comisiones.Rows(0).Cells(5).Value) / 100) * 1.35, 2)
                End If

            Catch ex As Exception
                TextComisionesPeso.Text = ""
            End Try

            Try
                TextComisionesEntregasTotales.Text = FormatNumber((Val(Comisiones.Rows(0).Cells(6).Value) + Val(Comisiones.Rows(0).Cells(2).Value)) * ComEntregasTot, 2)
            Catch ex As Exception
                TextComisionesEntregasTotales.Text = ""
            End Try

            Try
                TextComisionesEntregasParciales.Text = FormatNumber(Val(Comisiones.Rows(0).Cells(7).Value) * ComEntregasParciales, 2)
            Catch ex As Exception
                TextComisionesEntregasParciales.Text = ""
            End Try

            If almacen = 4 Then

                Dim ForaneasCompletas As Integer = 0
                Dim ForaneasParciales As Integer = 0
                Try
                    ForaneasCompletas = Val(Comisiones.Rows(0).Cells(10).Value)
                Catch ex As Exception
                End Try
                Try
                    ForaneasParciales = Val(Comisiones.Rows(0).Cells(11).Value)
                Catch ex As Exception
                End Try


                Dim TotalesRestantes As Integer = Val(Comisiones.Rows(0).Cells(6).Value) - ForaneasCompletas
                Dim ParcialesRestantes As Integer = Val(Comisiones.Rows(0).Cells(7).Value) - ForaneasCompletas

                Dim ComisionesForaneasCompletas As Decimal = ForaneasCompletas * 3.6
                Dim ComisionesForaneasParciales As Decimal = ForaneasParciales * 1.8
                Dim ComisionesInternasCompletas As Decimal = (Comisiones.Rows(0).Cells(6).Value + Comisiones.Rows(0).Cells(2).Value - ForaneasCompletas) * ComEntregasTot
                Dim ComisionesInternasParciales As Decimal = (Comisiones.Rows(0).Cells(7).Value - ForaneasParciales) * ComEntregasParciales

                TextComisionesEntregasTotales.Text = FormatNumber(ComisionesForaneasCompletas + ComisionesInternasCompletas, 2)
                TextComisionesEntregasParciales.Text = FormatNumber(ComisionesForaneasParciales + ComisionesInternasParciales, 2)

            End If

            'Dim PesoTot As Decimal = Val(Comisiones.Rows(0).Cells(3).Value)
            'Dim PesoTotDev As Decimal = Val(Comisiones.Rows(0).Cells(4).Value)
            'Dim PesoMay As Decimal = Val(Comisiones.Rows(0).Cells(8).Value)
            'Dim PesoMayDev As Decimal = Val(Comisiones.Rows(0).Cells(9).Value)
            'Dim PesoRest As Decimal = PesoTot - PesoMay
            'Dim PesoRestDev As Decimal = PesoTotDev - PesoMayDev

            'Dim ComisionesGral As Decimal = ((PesoRest - PesoRestDev) / 100) * ComPeso
            'Dim ComisionesMay As Decimal = ((PesoMay - PesoMayDev) / 100) * ComPesoMay

            'TextComisionesPeso.Text = FormatNumber((ComisionesGral + ComisionesMay), 2)

            Try
                TextTotalComisiones.Text = FormatNumber(Val(TextComisionesPeso.Text.Replace(",", "")) + Val(TextComisionesEntregasTotales.Text.Replace(",", "")) + Val(TextComisionesEntregasParciales.Text.Replace(",", "")), 2)
            Catch ex As Exception
                TextTotalComisiones.Text = ""
            End Try

            Try
                TextComisionesPeso.Text = "L. " & TextComisionesPeso.Text
                TextComisionesEntregasTotales.Text = "L. " & TextComisionesEntregasTotales.Text
                TextComisionesEntregasParciales.Text = "L. " & TextComisionesEntregasParciales.Text

                TextTotalComisiones.Text = "L. " & TextTotalComisiones.Text
            Catch ex As Exception
            End Try

        ElseIf TextBox1.Text = 4 Then
            Dim almacen As Integer = 0
            dt = db.Almacen(ComboEntregador.SelectedValue)
            If dt(0)(0) = "SRC" Then
                almacen = 2
                ComEntregasTot = 3.1
                ComEntregasParciales = 1.55
                ComPeso = 1.35
            ElseIf dt(0)(0) = "SPS" Then
                almacen = 1
                ComEntregasTot = 3.7
                ComEntregasParciales = 1.85
                ComPeso = 1.35
            ElseIf dt(0)(0) = 3 Then
                almacen = 3
                ComEntregasTot = 3.1
                ComEntregasParciales = 1.55
                ComPeso = 1.35
            Else
                almacen = 4
                ComEntregasTot = 3.25
                ComEntregasParciales = 1.63
                ComPeso = 1.1
            End If

            Detalle.DataSource = db.ComisionesEntregador(Desde.Value.Date, Hasta.Value.Date, "Detalle", ComboEntregador.SelectedValue)
            Comisiones.DataSource = db.ComisionesEntregador(Desde.Value.Date, Hasta.Value.Date, "GENERAL", ComboEntregador.SelectedValue)

            If ComboEntregador.SelectedValue = 77 And Desde.Value <= "15/02/2018" And Hasta.Value >= "15/02/2018" Then
                'TextTotalPeso.Text = Val(Replace(TextTotalPeso.Text, ",", "")) + 8825
                Comisiones.Rows(0).Cells(3).Value = Comisiones.Rows(0).Cells(3).Value + 8825
                Comisiones.Rows(0).Cells(5).Value = Comisiones.Rows(0).Cells(5).Value + 8825
                Comisiones.Rows(0).Cells(6).Value = Comisiones.Rows(0).Cells(6).Value + 1
            End If

            Try
                TextTotalPeso.Text = FormatNumber(Comisiones.Rows(0).Cells(3).Value, 2)
            Catch ex As Exception
                TextTotalPeso.Text = ""
            End Try



            Try
                TextTotalPesoDevoluciones.Text = FormatNumber(Val(Comisiones.Rows(0).Cells(4).Value) * -1, 2)
            Catch ex As Exception
                TextTotalPesoDevoluciones.Text = ""
            End Try

            Try
                TextComisionesPeso.Text = FormatNumber(Val(Comisiones.Rows(0).Cells(5).Value) / 100, 2)
                If almacen = 4 Then
                    TextComisionesPeso.Text = FormatNumber((Val(Comisiones.Rows(0).Cells(5).Value) / 100) * 1.1, 2)
                Else
                    TextComisionesPeso.Text = FormatNumber((Val(Comisiones.Rows(0).Cells(5).Value) / 100) * 1.35, 2)
                End If
                'If almacen = 1 Then
                '    Dim PesoTot As Decimal = Val(Comisiones.Rows(0).Cells(3).Value)
                '    Dim PesoTotDev As Decimal = Val(Comisiones.Rows(0).Cells(4).Value)
                '    Dim PesoMay As Decimal = Val(Comisiones.Rows(0).Cells(8).Value)
                '    Dim PesoMayDev As Decimal = Val(Comisiones.Rows(0).Cells(9).Value)
                '    Dim PesoRest As Decimal = PesoTot - PesoMay
                '    Dim PesoRestDev As Decimal = PesoTotDev - PesoMayDev

                '    Dim ComisionesGral As Decimal = ((PesoRest - PesoRestDev) / 100)
                '    Dim ComisionesMay As Decimal = ((PesoMay - PesoMayDev) / 100) * 1.5

                '    TextComisionesPeso.Text = FormatNumber((ComisionesGral + ComisionesMay), 2)
                'End If
            Catch ex As Exception
                TextComisionesPeso.Text = ""
            End Try

            Try
                TextComisionesEntregasTotales.Text = FormatNumber((Val(Comisiones.Rows(0).Cells(6).Value) + Val(Comisiones.Rows(0).Cells(2).Value)) * ComEntregasTot, 2)
            Catch ex As Exception
                TextComisionesEntregasTotales.Text = ""
            End Try

            Try
                TextComisionesEntregasParciales.Text = FormatNumber(Val(Comisiones.Rows(0).Cells(7).Value) * ComEntregasParciales, 2)
            Catch ex As Exception
                TextComisionesEntregasParciales.Text = ""
            End Try

            Try
                TextTotalComisiones.Text = FormatNumber(Val(TextComisionesPeso.Text.Replace(",", "")) + Val(TextComisionesEntregasTotales.Text.Replace(",", "")) + Val(TextComisionesEntregasParciales.Text.Replace(",", "")), 2)
            Catch ex As Exception
                TextTotalComisiones.Text = ""
            End Try


            Try
                TextComisionesPeso.Text = "L. " & TextComisionesPeso.Text
                TextComisionesEntregasTotales.Text = "L. " & TextComisionesEntregasTotales.Text
                TextComisionesEntregasParciales.Text = "L. " & TextComisionesEntregasParciales.Text

                TextTotalComisiones.Text = "L. " & TextTotalComisiones.Text
            Catch ex As Exception
            End Try


        End If

    End Sub
End Class