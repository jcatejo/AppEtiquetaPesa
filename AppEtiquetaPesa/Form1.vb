Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox1.Text = 1
        Label3.Text = String.Empty
        FillCombobox(Me.cmbEmpresa)
        buscaPuerto()
        Me.Refresh()

    End Sub

    Private Sub cmbBodega_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmbBodega.Click
        Me.cmbBodega.Text = String.Empty
        Me.cmbBodega.Items.Clear()
        FillBodega(cmbBodega)
    End Sub

    Private Sub cmbTransporte_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmbTransporte.Click
        Me.cmbTransporte.Text = String.Empty
        Me.cmbTransporte.Items.Clear()
        FillTransportista(cmbTransporte)
    End Sub

    Private Sub cmbBodega_SelectedValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbBodega.SelectedValueChanged
        POSVAL()
    End Sub
   
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        lblHora.Text = TimeOfDay
        lblFecha.Text = DateTime.Today
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Label3.Text = String.Empty
        getexiste()
        Try
            If cmbEmpresa.Text = String.Empty Then ' 
                MessageBox.Show("Seleccione empresa")
            ElseIf cmbBodega.Text = String.Empty Then
                MessageBox.Show("Seleccione bodega")
            ElseIf cmbEmpleado.Text = String.Empty Then
                MessageBox.Show("Seleccione un usuario")
            ElseIf txbPicking.Text = String.Empty Then
                MessageBox.Show("Ingrese pedido")
            ElseIf txbCantEtiquetas.Text = String.Empty Then
                MessageBox.Show("Ingrese un numero de etiquetas")
            ElseIf Label3.Text = String.Empty Then
                MessageBox.Show("Pedido sin datos")
            Else
                Me.lblHora.Focus()
                FormPesoEtiqueta.Show()
                Me.Hide()

            End If
        Catch ex As Exception

            MessageBox.Show("Ingrese numero entero para etiquetas")

        End Try
    End Sub

    Private Sub txbPicking_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txbPicking.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            If cmbEmpresa.Text = String.Empty Then
                MsgBox("Debe seleccionar Empresa")
            Else
                Me.Hide()
                FormReImpresion.Show()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub cmbEmpresa_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEmpresa.SelectedIndexChanged
        'lblDataarea.Text = cmbEmpresa.Text
    End Sub
   
    Private Sub cmbBodega_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBodega.SelectedIndexChanged
        Me.txbPicking.Focus()
    End Sub

    Private Sub cmbEmpleado_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbEmpleado.Click
        Me.cmbEmpleado.Text = String.Empty
        Me.cmbEmpleado.Items.Clear()

        Try
            If cmbEmpresa.Text = String.Empty Then ' 
                MessageBox.Show("Seleccione empresa")
            ElseIf cmbBodega.Text = String.Empty Then
                MessageBox.Show("Seleccione bodega")
            ElseIf cmbEmpresa.Text = "TUBEXA INDUSTRIAL" Then
                cmbEmpleado.Items.Add("LEONARDO BAHAMONDEZ")

            Else
                Me.cmbEmpleado.Text = String.Empty
                Me.cmbEmpleado.Items.Clear()
                FillEmpleado(cmbEmpleado)

            End If
        Catch ex As Exception
            MessageBox.Show("Error no registrado")
        End Try

    End Sub

    Private Sub txbCantEtiquetas_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txbCantEtiquetas.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub cmbEmpleado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEmpleado.SelectedIndexChanged
        Me.txbPicking.Focus()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            If cmbEmpresa.Text = String.Empty Then
                MsgBox("Debe seleccionar Empresa")
            Else
                Me.Hide()
                FormCarrierLabel.Show()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

End Class
