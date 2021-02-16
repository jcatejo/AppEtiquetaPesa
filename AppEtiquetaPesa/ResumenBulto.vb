Public Class ResumenBulto
    Public pesogramo As Integer

    Private Sub ResumenBulto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txbresobs.SelectionStart = txbresobs.Text.Length
        txbresobs.SelectionLength = 0
    End Sub
    Public Sub imprimeresumen()
        'Dim pesogrstr As String
        'pesogramo = FormPesoEtiqueta.pesototal * 1000
        'pesogrstr = Convert.ToString(pesogramo).ToString
        Label15.Focus()

        lblresEmpr.Text = Form1.cmbEmpresa.Text
        lblresfec.Text = Form1.lblFecha.Text
        lblrespick.Text = FormPesoEtiqueta.lblpck.Text
        lblrespv.Text = FormPesoEtiqueta.lbldct.Text
        lblresbarrpick.Text = "*" & FormPesoEtiqueta.lbldct.Text & "*"
        lblresdesde.Text = FormPesoEtiqueta.first
        lblreshasta.Text = FormPesoEtiqueta.last
        lblrescantbul.Text = FormPesoEtiqueta.lblb.Text
        lblrescli.Text = FormPesoEtiqueta.lblcli.Text
        lblrescom.Text = FormPesoEtiqueta.lblcom.Text
        lblresdir.Text = FormPesoEtiqueta.lbldir.Text
        lblresciu.Text = FormPesoEtiqueta.lblciu.Text
        lblresreg.Text = FormPesoEtiqueta.lblreg.Text
        lblrespeso.Text = Replace(FormPesoEtiqueta.pesoStr, ".", ",")
        lblresbarrpeso.Text = "*" & FormPesoEtiqueta.lblCalPeso.Text & "*"
        lblrestrans.Text = FormPesoEtiqueta.lbltrans.Text
        txbresobs.Text = FormPesoEtiqueta.lblobs.Text
        lblhora.Text = Form1.lblHora.Text
        Label15.Focus()

        Me.Show()

        Try
            Label15.Focus()
            Me.PrintForm2.PrinterSettings.DefaultPageSettings.Margins = New System.Drawing.Printing.Margins(0, 0, 10, 0)
            Me.PrintForm2.PrintAction = Printing.PrintAction.PrintToPrinter
            Me.PrintForm2.PrinterSettings.DefaultPageSettings.Landscape = False
            Me.PrintForm2.Print(Me, PowerPacks.Printing.PrintForm.PrintOption.ClientAreaOnly)
            Me.Close()

        Catch ex As Exception

            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Error")

        End Try

    End Sub
End Class