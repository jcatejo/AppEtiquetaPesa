Public Class EtiquetaSinPeso

    Private Sub EtiquetaSinPeso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txbbspobservacion.SelectionStart = txbbspobservacion.Text.Length
        txbbspobservacion.SelectionLength = 0
    End Sub

    Public Sub imprimeetiquetaSP()

        lblbspempresa.Text = Form1.cmbEmpresa.Text
        lblbsppicking.Text = FormPesoEtiqueta.lblpck.Text
        lblbsppickbarra.Text = "*" & FormPesoEtiqueta.lbldct.Text & "*"
        lblbspa.Text = FormPesoEtiqueta.lbla.Text
        lblbspb.Text = FormPesoEtiqueta.lblb.Text
        lblbspfecha.Text = Form1.lblFecha.Text
        lblbspcliente.Text = FormPesoEtiqueta.lblcli.Text
        lblbspdireccion.Text = FormPesoEtiqueta.lbldir.Text
        lblbspcomuna.Text = FormPesoEtiqueta.lblcom.Text
        lblbspciudad.Text = FormPesoEtiqueta.lblciu.Text
        lblbspregion.Text = FormPesoEtiqueta.lblreg.Text
        txbbspobservacion.Text = FormPesoEtiqueta.lblobs.Text
        lblbsphora.Text = Form1.lblHora.Text
        lblbsppv.Text = FormPesoEtiqueta.lbldct.Text
        lblbsptransporte.Text = Form1.cmbTransporte.Text
        lblbsncantidad.Text = FormPesoEtiqueta.lblcont.Text
        Me.Show()
        'PrintForm1.PrintAction = Printing.PrintAction.PrintToPreview

        'PrintForm1.Print()
        'Me.Close()

        Try

            Me.PrintForm3.PrinterSettings.DefaultPageSettings.Margins = New System.Drawing.Printing.Margins(0, 0, 10, 0)
            Me.PrintForm3.PrintAction = Printing.PrintAction.PrintToPrinter
            Me.PrintForm3.PrinterSettings.DefaultPageSettings.Landscape = False
            Me.PrintForm3.Print(Me, PowerPacks.Printing.PrintForm.PrintOption.ClientAreaOnly)
            'Me.PrintForm1.PrinterSettings.
            Me.Close()

        Catch ex As Exception

            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Error")

        End Try

    End Sub

End Class