Public Class FormPrintCarrierLabel

    Private Sub FormPrintCarrierLabel_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        FormCarrierLabel.Show()
    End Sub

    Private Sub FormPrintCarrierLabel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        getDataareaid()
    End Sub

    Private Sub FormPrintCarrierLabel_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Enter
        ''Try
        ''reImprimeEtiquetaCarrier()
        ''Me.TextBox1.Text = String.Empty
        ''Catch ex As Exception
        ''MessageBox.Show("Etiqueta no encontrada")
        ''End Try
    End Sub

    Private Sub ButtonPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPrint.Click
        Try
            reImprimeEtiquetaCarrier()
            Me.TextBox1.Text = String.Empty
        Catch ex As Exception
            MessageBox.Show("Etiqueta no encontrada")
        End Try
    End Sub
End Class