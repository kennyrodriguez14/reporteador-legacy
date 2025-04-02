Imports Disar.data

Public Class FrmCargaCompraOPL

    Dim Clc As Decimal
    Public Pedido As Integer

    Private Sub TextBuscar_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBuscar.KeyDown
        If e.KeyCode = Keys.Enter Then
            For Each row As DataGridViewRow In DataDatos.Rows
                If CStr(row.Cells(2).Value).ToUpper = TextBuscar.Text Or CStr(row.Cells(3).Value).ToUpper = TextBuscar.Text Or CStr(row.Cells("CodigoProv").Value).ToUpper = TextBuscar.Text Then
                    row.Selected = True
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub DataDatos_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataDatos.CellClick
        If e.ColumnIndex = 6 Then
            If Val(DataDatos.CurrentRow.Cells(0).Value) > 0 Then
                frm_calculadora_totales.Close()
                If frm_calculadora_totales.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Clc = (Val(frm_calculadora_totales.txt_totales.Text))
                    If frm_nueva_compra_nacional_opl.cmb_valores_base.SelectedItem = "Sub Total" Then
                        Dim precio As Double = 0, descuento As Double = 0, isv As Double = 0
                        If (DataDatos.CurrentRow.Cells(1).Value) = "cj" Then
                            precio = Math.Round(Val(frm_calculadora_totales.txt_totales.Text) / Val(DataDatos.CurrentRow.Cells(0).Value) / Val(DataDatos.CurrentRow.Cells(4).Value), 6)
                        ElseIf (DataDatos.CurrentRow.Cells(1).Value) = "pz" Then
                            precio = Math.Round(Val(frm_calculadora_totales.txt_totales.Text) / Val(DataDatos.CurrentRow.Cells(0).Value), 6)
                        Else
                            precio = Math.Round(Val(frm_calculadora_totales.txt_totales.Text) / Val(DataDatos.CurrentRow.Cells(0).Value) / Val(DataDatos.CurrentRow.Cells(4).Value), 6)
                        End If

                        descuento = precio * (Val(DataDatos.CurrentRow.Cells(9).Value) / 100)
                        precio = Math.Round(precio - descuento, 6)
                        DataDatos.CurrentRow.Cells(7).Value = precio
                    ElseIf frm_nueva_compra_nacional_opl.cmb_valores_base.SelectedItem = "Impuesto" Then

                        Dim precio As Double = 0, descuento As Double = 0, isv As Double = 0
                        If (DataDatos.CurrentRow.Cells(1).Value) = "cj" Then
                            precio = Math.Round(Val(frm_calculadora_totales.txt_totales.Text) / Val(DataDatos.CurrentRow.Cells(0).Value) / Val(DataDatos.CurrentRow.Cells(4).Value), 6)
                        ElseIf (DataDatos.CurrentRow.Cells(1).Value) = "pz" Then
                            precio = Math.Round(Val(frm_calculadora_totales.txt_totales.Text) / Val(DataDatos.CurrentRow.Cells(0).Value), 6)
                        Else
                            precio = Math.Round(Val(frm_calculadora_totales.txt_totales.Text) / Val(DataDatos.CurrentRow.Cells(0).Value) / Val(DataDatos.CurrentRow.Cells(4).Value), 6)
                        End If

                        descuento = precio * (Val(DataDatos.CurrentRow.Cells(9).Value) / 100)
                        precio = precio - descuento

                        precio = precio / (1 + (Val(DataDatos.CurrentRow.Cells(10).Value) / 100))

                        isv = Math.Round(precio + (precio * (Val(DataDatos.CurrentRow.Cells(10).Value) / 100)), 6)
                        DataDatos.CurrentRow.Cells(7).Value = precio
                        'btn_agregar.Focus()
                    End If
                End If
            Else
                MessageBox.Show("debe ingresar una cantidad valida", "Cantidad", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                DataDatos.CurrentCell = DataDatos.CurrentRow.Cells(0)
            End If
        End If
        If e.ColumnIndex = 13 Then

            Try
                If DataDatos.CurrentRow.Cells(2).Value = "" Or Val(DataDatos.CurrentRow.Cells(0).Value) <= 0 Or Val(DataDatos.CurrentRow.Cells(7).Value) <= 0 Then
                    MessageBox.Show("Ingrese todos los datos del producto")
                Else


                    Dim subtotal As Double = 0, descuento As Double = 0, isv As Double = 0
                    Dim total As Double = 0, precio_multiplicador As Double = 0
                    Dim cadena_ajuste As String = ""
                    Dim subtotal_mostrador As Double = 0, total_mostrador As Double = 0, descuento_mostrador As Double = 0, isv_mostrador As Double = 0

                    If Math.Round(Val(DataDatos.CurrentRow.Cells(8).Value), 6) = Math.Round(Val(DataDatos.CurrentRow.Cells(7).Value), 6) Then
                        precio_multiplicador = Math.Round(Val(DataDatos.CurrentRow.Cells(8).Value), 6)
                        cadena_ajuste = "N"
                    ElseIf Math.Round(Val(DataDatos.CurrentRow.Cells(8).Value), 6) > Math.Round(Val(DataDatos.CurrentRow.Cells(7).Value), 6) Then
                        precio_multiplicador = Math.Round(Val(DataDatos.CurrentRow.Cells(8).Value), 6) 'Math.Round(Val(DataDatos.CurrentRow.Cells(7).Value), 6)
                        cadena_ajuste = "D"
                    ElseIf Math.Round(Val(DataDatos.CurrentRow.Cells(8).Value), 6) < Math.Round(Val(DataDatos.CurrentRow.Cells(7).Value), 6) Then
                        precio_multiplicador = Math.Round(Val(DataDatos.CurrentRow.Cells(8).Value), 6)
                        cadena_ajuste = "S"
                    End If

                    If DataDatos.CurrentRow.Cells(1).Value = "cj" Then
                        subtotal = Val(DataDatos.CurrentRow.Cells(4).Value) * precio_multiplicador * Val(DataDatos.CurrentRow.Cells(0).Value)

                        descuento_mostrador = ((Val(DataDatos.CurrentRow.Cells(4).Value) * Val(DataDatos.CurrentRow.Cells(7).Value) * Val(DataDatos.CurrentRow.Cells(0).Value)) / (1 - Val(DataDatos.CurrentRow.Cells(9).Value) / 100)) - ((Val(DataDatos.CurrentRow.Cells(4).Value) * Val(DataDatos.CurrentRow.Cells(7).Value) * Val(DataDatos.CurrentRow.Cells(0).Value)))
                        isv_mostrador = ((Val(DataDatos.CurrentRow.Cells(4).Value) * Val(DataDatos.CurrentRow.Cells(7).Value) * Val(DataDatos.CurrentRow.Cells(0).Value)) * (Val(DataDatos.CurrentRow.Cells(10).Value) / 100))
                        subtotal_mostrador = ((Val(DataDatos.CurrentRow.Cells(4).Value) * Val(DataDatos.CurrentRow.Cells(7).Value) * Val(DataDatos.CurrentRow.Cells(0).Value)) / (1 - Val(DataDatos.CurrentRow.Cells(9).Value) / 100))
                        total_mostrador = (Val(DataDatos.CurrentRow.Cells(4).Value) * Val(DataDatos.CurrentRow.Cells(7).Value) * Val(DataDatos.CurrentRow.Cells(0).Value)) + ((Val(DataDatos.CurrentRow.Cells(4).Value) * Val(DataDatos.CurrentRow.Cells(7).Value) * Val(DataDatos.CurrentRow.Cells(0).Value)) * (Val(DataDatos.CurrentRow.Cells(10).Value) / 100))

                    ElseIf DataDatos.CurrentRow.Cells(1).Value = "pz" Then
                        subtotal = precio_multiplicador * Val(DataDatos.CurrentRow.Cells(0).Value)

                        descuento_mostrador = ((Val(DataDatos.CurrentRow.Cells(7).Value) * Val(DataDatos.CurrentRow.Cells(0).Value)) / (1 - Val(DataDatos.CurrentRow.Cells(9).Value) / 100)) - (Val(DataDatos.CurrentRow.Cells(7).Value) * Val(DataDatos.CurrentRow.Cells(0).Value))
                        isv_mostrador = ((Val(DataDatos.CurrentRow.Cells(7).Value) * Val(DataDatos.CurrentRow.Cells(0).Value)) * (Val(DataDatos.CurrentRow.Cells(10).Value) / 100))
                        subtotal_mostrador = ((Val(DataDatos.CurrentRow.Cells(7).Value) * Val(DataDatos.CurrentRow.Cells(0).Value)) / (1 - Val(DataDatos.CurrentRow.Cells(9).Value) / 100))
                        total_mostrador = (Val(DataDatos.CurrentRow.Cells(7).Value) * Val(DataDatos.CurrentRow.Cells(0).Value)) + ((Val(DataDatos.CurrentRow.Cells(7).Value) * Val(DataDatos.CurrentRow.Cells(0).Value)) * (Val(DataDatos.CurrentRow.Cells(10).Value) / 100))
                    Else
                        subtotal = Val(DataDatos.CurrentRow.Cells(4).Value) * precio_multiplicador * Val(DataDatos.CurrentRow.Cells(0).Value)

                        descuento_mostrador = ((Val(DataDatos.CurrentRow.Cells(4).Value) * Val(DataDatos.CurrentRow.Cells(7).Value) * Val(DataDatos.CurrentRow.Cells(0).Value)) / (1 - Val(DataDatos.CurrentRow.Cells(9).Value) / 100)) - ((Val(DataDatos.CurrentRow.Cells(4).Value) * Val(DataDatos.CurrentRow.Cells(7).Value) * Val(DataDatos.CurrentRow.Cells(0).Value)))
                        isv_mostrador = ((Val(DataDatos.CurrentRow.Cells(4).Value) * Val(DataDatos.CurrentRow.Cells(7).Value) * Val(DataDatos.CurrentRow.Cells(0).Value)) * (Val(DataDatos.CurrentRow.Cells(10).Value) / 100))
                        subtotal_mostrador = ((Val(DataDatos.CurrentRow.Cells(4).Value) * Val(DataDatos.CurrentRow.Cells(7).Value) * Val(DataDatos.CurrentRow.Cells(0).Value)) / (1 - Val(DataDatos.CurrentRow.Cells(9).Value) / 100))
                        total_mostrador = (Val(DataDatos.CurrentRow.Cells(4).Value) * Val(DataDatos.CurrentRow.Cells(7).Value) * Val(DataDatos.CurrentRow.Cells(0).Value)) + ((Val(DataDatos.CurrentRow.Cells(4).Value) * Val(DataDatos.CurrentRow.Cells(7).Value) * Val(DataDatos.CurrentRow.Cells(0).Value)) * (Val(DataDatos.CurrentRow.Cells(10).Value) / 100))

                    End If

                    descuento = 0 'subtotal * (Val(DataDatos.CurrentRow.Cells(9).Value) / 100)
                    isv = (subtotal - descuento) * (Val(DataDatos.CurrentRow.Cells(10).Value) / 100)
                    total = subtotal - descuento + isv

                    frm_nueva_compra_nacional_opl.grd_ingreso.Rows.Add(Val(DataDatos.CurrentRow.Cells(0).Value), DataDatos.CurrentRow.Cells(2).Value, DataDatos.CurrentRow.Cells(3).Value, DataDatos.CurrentRow.Cells(4).Value,
                                         "cj", Math.Round(Val(DataDatos.CurrentRow.Cells(8).Value), 6), Math.Round(Val(DataDatos.CurrentRow.Cells(7).Value), 6),
                                         Math.Round(Val(DataDatos.CurrentRow.Cells(9).Value), 6), Val(DataDatos.CurrentRow.Cells(10).Value), Math.Round(subtotal, 6),
                                         Math.Round(descuento, 6), Math.Round(isv, 6), Math.Round(total, 6), Math.Round(precio_multiplicador, 6),
                                         cadena_ajuste, DataDatos.CurrentRow.Cells(5).Value, Math.Round(subtotal_mostrador, 6), Math.Round(total_mostrador, 6),
                                         Math.Round(descuento_mostrador), Math.Round(isv_mostrador), DataDatos.CurrentRow.Cells(11).Value, Clc)
                    frm_nueva_compra_nacional_opl.limpiar()
                    frm_nueva_compra_nacional_opl.sumar_totales()

                    frm_nueva_compra_nacional_opl.grd_ingreso.ClearSelection()
                    frm_nueva_compra_nacional_opl.grd_ingreso.Rows(frm_nueva_compra_nacional_opl.grd_ingreso.RowCount - 1).Selected = True
                    frm_nueva_compra_nacional_opl.grd_ingreso.Refresh()
                    frm_nueva_compra_nacional_opl.cmb_sucursal.Enabled = False

                    Try
                        DataDatos.Rows.RemoveAt(DataDatos.CurrentRow.Index)
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

        End If
    End Sub

    Private Sub FrmCargaCompraOPL_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class