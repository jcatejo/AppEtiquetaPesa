Imports Microsoft.Reporting.WinForms

Public Class FormPesoEtiqueta
    Public sumPeso, contador, labelid, first, last, calc, cantidad, contadorEtiqueta As Int32
    Public pesototal, redond As Decimal
    Public pesoStr, desde, hasta, customerRef As String
    Public fechaLabel As Date

    Private Sub FormPesoEtiqueta_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Form1.Show()
    End Sub

    Private Sub FormPesoEtiqueta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim variable = 0
        contadorEtiqueta = 1
        lbla.Text = 1
        cantidad = Form1.txbCantEtiquetas.Text
        CheckForIllegalCrossThreadCalls = False
        If Form1.txbPicking.Text.Substring(0, 2) = "PV" Then
            getCustomerRef()
        Else
            customerRef = ""
        End If

        'Limpia variables
        limpiaVariablesFormPeso()

        'Ejecuta store procedure que devuelve los datos del picking 
        getsp()

        'inicializa contadores 
        Dim cont = 1
        Dim peso = Format(txbPeso.Text, "#,###,###,##0.00")
        Dim resumen As Integer = 1

        'setea datos ingresados por el usuario
        cargaDatosFormPeso()

        'Evalua cantidad de etiquetas

        Me.Button1.Focus()

        'Se rescata peso de balanza


    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Dim result As Decimal
        Dim redond As Decimal
        Format(redond, "##,##0.00")
        redond.ToString("##,##0.00")
        lblb.Text = cantidad

        If IsNumeric(txbPeso.Text) Then
            If txbPeso.Text > 0 Then

                'INSERTA REGISTRO EN AX_MAINDB
                numEtiqueta()
                contador = contador + 1
                contadorEtiqueta = contadorEtiqueta + 1
                lblcont.Text = Convert.ToString(contador).ToString()
                Dim pathExternalLabel As String
                pathExternalLabel = ""

                If Me.lbldat.Text = "DCO" Then
                    pathExternalLabel = "\\serv-bkp1\EtiquetaExterna\DCO\" + Me.lbldct.Text + ".pdf"
                ElseIf Me.lbldat.Text = "CMD" Then
                    pathExternalLabel = "\\serv-bkp1\EtiquetaExterna\CMD\" + Me.lbldct.Text + ".pdf"
                ElseIf Me.lbldat.Text = "CWD" Then
                    pathExternalLabel = "\\serv-bkp1\EtiquetaExterna\CWD\" + Me.lbldct.Text + ".pdf"
                ElseIf Me.lbldat.Text = "SII" Then
                    pathExternalLabel = "\\serv-bkp1\EtiquetaExterna\SII\" + Me.lbldct.Text + ".pdf"
                ElseIf Me.lbldat.Text = "TBD" Then
                    pathExternalLabel = "\\serv-bkp1\EtiquetaExterna\TBD\" + Me.lbldct.Text + ".pdf"
                Else
                    MessageBox.Show("Error, por favor contactarse con el administrador")
                End If

                'Inserta registro en en BD
                InsertLabel(Me.contador, Me.lblpck.Text, Me.lbldct.Text, Me.lblrut.Text, Me.lblcli.Text, Me.lbldir.Text, Me.lblcom.Text, Me.lblciu.Text, Me.lblreg.Text, Me.lblsec.Text, Me.lbltrans.Text, Replace(Me.txbPeso.Text, ",", "."), Me.lblobs.Text, Me.lbldat.Text, Me.contador, Me.lblpos.Text, Me.lblfralm.Text, Me.lbltoalm.Text, Form1.cmbEmpleado.Text, pathExternalLabel)

                'CALCULA PESO TOTAL DE LAS ETIQUETAS EMITIDAS
                result = Convert.ToDecimal(Replace((txbPeso.Text), ",", "."))
                pesototal = pesototal + result
                pesoStr = pesototal.ToString()
                redond = result.ToString("N2") * 1000
                lblred.Text = Convert.ToString(redond).ToString
                sumPeso = sumPeso + redond
                lblCalPeso.Text = Convert.ToString(sumPeso).ToString

                'IMPRIME ETIQUETA
                Dim print As New EtiquetaBulto()
                print.imprimeetiqueta()


                If contadorEtiqueta > cantidad Then
                    limpiaForm1()
                    Me.Hide()
                    Dim opcion As DialogResult
                    opcion = MessageBox.Show("Desea Imprimir etiquetas Externa?", "Etiqueta Carrier", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If (opcion = Windows.Forms.DialogResult.Yes) Then
                        APIenv()
                        imprimeEtiquetaExterna()
                        Form1.txbPicking.Focus()
                        Me.Close()
                        Form1.txbPicking.Focus()
                    Else
                        Me.txbPeso.Focus()
                    End If

                Else
                    lbla.Text = lbla.Text + 1
                    contadorEtiqueta = Convert.ToInt32(lbla.Text)
                    txbPeso.Text = "0.00"
                    txbPeso.Focus()
                End If

            Else
                MessageBox.Show("el peso debe ser mayor a 0")
                txbPeso.Text = "0.00"
            End If

        Else
            MessageBox.Show("Debe ingresar un número")
            txbPeso.Text = "0.00"
        End If

    End Sub

    Private Sub SerialPort1_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        Dim buffer As String
        buffer = SerialPort1.ReadLine
        txbPeso.Text = Mid(buffer, 8, 7)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        capturaPeso()
        Me.btnImprimir.Focus()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ' SerialPort1.Close()
    End Sub

End Class