Imports Microsoft.Reporting.WinForms
Public Class FormReImpresion

    Private Sub FormReImpresion_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Form1.Show()
    End Sub

    Private Sub FormReImpresion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Abrir()
        ' Limpia variables
        lblciu.Text = ""
        lblcli.Text = ""
        lblcom.Text = ""
        lblcoment.Text = ""
        lblcond.Text = ""
        lbldate.Text = ""
        lbldir.Text = ""
        lblid.Text = ""
        lblpck.Text = ""
        lblpv.Text = ""
        lblreg.Text = ""
        lbppeso.Text = ""
        lblhora.Text = ""
        ''''''''''''''''''''''''''''

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        getsp1()
        ' Ejecutamos spu para reimpresion
        Try
            If TextBox1.Text = "" Then
                MsgBox("Debe ingresar un numero de etiqueta")
            Else


                Dim print As New EtiquetaBulto()
                print.REimprimeetiqueta()

            End If

        Catch ex As Exception
        End Try

    End Sub

End Class