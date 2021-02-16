Public Class EtiquetaBulto

    Private Sub EtiquetaBulto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.SelectionStart = TextBox1.Text.Length
        TextBox1.SelectionLength = 0

    End Sub

    Public Sub imprimeetiqueta()
        Label16.Focus()
        Dim barrakilo As Integer
        lblprempresa.Text = Form1.cmbEmpresa.Text
        'lblprsec.Text = FormPesoEtiqueta.lblsec.Text
        lblprpck.Text = FormPesoEtiqueta.lblpck.Text
        lblprbarrapck.Text = "*" & FormPesoEtiqueta.lbldct.Text & "*"
        lblpra.Text = FormPesoEtiqueta.lbla.Text
        lblprb.Text = FormPesoEtiqueta.lblb.Text
        lblprfec.Text = Form1.lblFecha.Text
        lblprcli.Text = FormPesoEtiqueta.lblcli.Text
        lblprdir.Text = FormPesoEtiqueta.lbldir.Text
        lblprcom.Text = FormPesoEtiqueta.lblcom.Text
        lblprciu.Text = FormPesoEtiqueta.lblciu.Text
        lblprreg.Text = FormPesoEtiqueta.lblreg.Text
        TextBox1.Text = FormPesoEtiqueta.lblobs.Text
        lblprpeso.Text = FormPesoEtiqueta.txbPeso.Text
        barrakilo = FormPesoEtiqueta.redond
        lblhora.Text = Form1.lblHora.Text
        lblprpv.Text = FormPesoEtiqueta.lbldct.Text
        lblprbarrakilo.Text = "*" & FormPesoEtiqueta.lblred.Text & "*"
        lblprtrans.Text = Form1.cmbTransporte.Text
        lblnumeti.Text = FormPesoEtiqueta.lblcont.Text
        Label1.Text = "*" & Form1.lblDataarea.Text & "-" & FormPesoEtiqueta.lblcont.Text & "*"
        Label16.Focus()
        Me.Show()
        Label16.Focus()
        
        Try
            Label16.Focus()
            Me.PrintForm1.PrinterSettings.DefaultPageSettings.Margins = New System.Drawing.Printing.Margins(0, 0, 10, 0)
            Me.PrintForm1.PrintAction = Printing.PrintAction.PrintToPrinter
            Me.PrintForm1.PrinterSettings.DefaultPageSettings.Landscape = False
            Me.PrintForm1.Print(Me, PowerPacks.Printing.PrintForm.PrintOption.ClientAreaOnly)
            Me.Close()

        Catch ex As Exception

            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Error")

        End Try

    End Sub

    Public Sub REimprimeetiqueta()
        Label16.Focus()
        'Dim barrakilo As Integer
        lblprempresa.Text = Form1.cmbEmpresa.Text
        lblprpck.Text = FormReImpresion.lblpck.Text
        lblprbarrapck.Text = "*" & FormReImpresion.lblpck.Text & "*"
        lblpra.Text = "1"
        lblprb.Text = "1"
        lblprfec.Text = FormReImpresion.lbldate.Text
        lblprcli.Text = FormReImpresion.lblcli.Text
        lblprdir.Text = FormReImpresion.lbldir.Text
        lblprcom.Text = FormReImpresion.lblcom.Text
        lblprciu.Text = FormReImpresion.lblciu.Text
        lblprreg.Text = FormReImpresion.lblreg.Text
        TextBox1.Text = FormReImpresion.lblcoment.Text
        lblprpeso.Text = FormReImpresion.lbppeso.Text
        'barrakilo = FormPesoEtiqueta.redond
        lblhora.Text = FormReImpresion.lblhora.Text
        lblprpv.Text = FormReImpresion.lblpv.Text
        lblprbarrakilo.Text = "*" & FormReImpresion.lbppeso.Text & "*"
        lblprtrans.Text = FormReImpresion.lblcond.Text
        lblnumeti.Text = FormReImpresion.lblid.Text
        Label16.Focus()
        Me.Show()
        Label16.Focus()

        Try
            Label16.Focus()
            Me.PrintForm1.PrinterSettings.DefaultPageSettings.Margins = New System.Drawing.Printing.Margins(0, 0, 10, 0)
            Me.PrintForm1.PrintAction = Printing.PrintAction.PrintToPrinter
            Me.PrintForm1.PrinterSettings.DefaultPageSettings.Landscape = False
            Me.PrintForm1.Print(Me, PowerPacks.Printing.PrintForm.PrintOption.ClientAreaOnly)
            Me.Close()

        Catch ex As Exception

            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Error")

        End Try

    End Sub


End Class