Public Class FormGenerateCarrierLabel

    Private Sub FormGenerateCarrierLabel_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        FormCarrierLabel.Show()
    End Sub

    Private Sub FormGenerateCarrierLabel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TextBox1_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.Enter
        getDataareaid()
        Try
            generaEtiquetaCarrier()
            Me.TextBox1.Text = String.Empty
        Catch ex As Exception
            MessageBox.Show("No generado, La etiqueta ya existe")
        End Try
    End Sub

    Private Sub ButtonGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGenerate.Click
        getDataareaid()
        Try
            generaEtiquetaCarrier()
            Me.TextBox1.Text = String.Empty
        Catch ex As Exception
            MessageBox.Show("No generado, La etiqueta ya existe")
        End Try
    End Sub
End Class