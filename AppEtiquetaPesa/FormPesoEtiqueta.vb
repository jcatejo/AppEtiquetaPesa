Imports Microsoft.Reporting.WinForms

Public Class FormPesoEtiqueta
    Public sumPeso As Int32
    Public contador As Int32
    Public pesototal As Decimal
    Public pesoStr As String
    Public labelid As Int32
    Public first As Int32
    Public last As Int32
    Public desde As String
    Public hasta As String
    Public redond As Decimal
    Public calc As Int32
    Public cantidad As Int32
    Public fechaLabel As Date
    Public contadorEtiqueta As Int32
    Public customerRef As String

    Private Sub FormPesoEtiqueta_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Form1.Show()
    End Sub

    Private Sub FormPesoEtiqueta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        ' Busca comentario en PV si es PV

        If Form1.txbPicking.Text.Substring(0, 2) = "PV" Then
            getCustomerRef()
        Else
            customerRef = ""
        End If

        'Limpia variables
        lblbod.Text = ""
        lblciu.Text = ""
        lblcli.Text = ""
        lblcom.Text = ""
        lbldir.Text = ""
        lblloc.Text = ""
        lblobs.Text = ""
        lblreg.Text = ""
        lblrut.Text = ""
        lblsec.Text = ""
        lbltrans.Text = ""
        Dim variable = 0
        lblpos.Text = ""
        lblfralm.Text = ""
        lbltoalm.Text = ""
        'Ejecuta store procedure que devuelve los datos del picking 
        getsp()
        'numEtiqueta()
        'inicializa contadores 
        'contador = contador + 1
        first = first
        Dim cont = 1
        lbla.Text = 1
        lblfec.Text = "2018/12/13"
        Dim peso = Format(txbPeso.Text, "#,###,###,##0.00")
        txbPeso.Text = "0.00"
        Dim resumen As Integer = 1
        'setea datos ingresados por el usuario
        lbldat.Text = Form1.lblDataarea.Text
        lbltrans.Text = Form1.cmbTransporte.Text
        lblb.Text = Form1.txbCantEtiquetas.Text
        cantidad = Form1.txbCantEtiquetas.Text
        lblobs.Text = Form1.txbObservacion.Text + " " + customerRef
        ' lblcont.Text = Convert.ToString(contador).ToString()
        'Se rescata peso de balanza
        Me.Button1.Focus()

    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Dim opcion As DialogResult
        Dim result As Decimal
        'Dim txtp As String
        Dim redond As Decimal
        Format(redond, "##,##0.00")
        redond.ToString("##,##0.00")

        If txbPeso.Text = 0 Then
            MessageBox.Show("Ingrese el peso del bulto")
        Else
            If IsNumeric(txbPeso.Text) Then
                If contadorEtiqueta < cantidad Or contadorEtiqueta = cantidad Then

                    'INSERTA REGISTRO EN AX_MAINDB
                    numEtiqueta()
                    contador = contador + 1
                    lblcont.Text = Convert.ToString(contador).ToString()
                    InsertLabel(Me.contador, Me.lblpck.Text, Me.lbldct.Text, Me.lblrut.Text, Me.lblcli.Text, Me.lbldir.Text, Me.lblcom.Text, Me.lblciu.Text, Me.lblreg.Text, Me.lblsec.Text, Me.lbltrans.Text, Replace(Me.txbPeso.Text, ",", "."), Me.lblobs.Text, Me.lbldat.Text, Me.contador, Me.lblpos.Text, Me.lblfralm.Text, Me.lbltoalm.Text, Form1.cmbEmpleado.Text)

                    'CALCULA PESO TOTAL DE LAS ETIQUETAS EMITIDAS
                    result = Convert.ToDecimal(Replace((txbPeso.Text), ",", ".")) 'CDbl(txbPeso.Text)
                    pesototal = pesototal + result
                    pesoStr = pesototal.ToString()
                    redond = result.ToString("N2") * 1000
                    lblred.Text = Convert.ToString(redond).ToString
                    sumPeso = sumPeso + redond
                    lblCalPeso.Text = Convert.ToString(sumPeso).ToString

                    'IMPRIME ETIQUETA
                    Dim print As New EtiquetaBulto()
                    print.imprimeetiqueta()

                    lbla.Text = lbla.Text + 1
                    contadorEtiqueta = Convert.ToInt32(lbla.Text)
                    txbPeso.Text = "0.00"
                    txbPeso.Focus()
                    'contador = contador + 1
                    'lblcont.Text = Convert.ToString(contador).ToString()

                    'EVALUA SI HAY MAS ETIQUETAS QUE EMITIR
                    If contadorEtiqueta > cantidad Then
                        Form1.txbPicking.Text = String.Empty
                        Form1.txbCantEtiquetas.Text = String.Empty
                        Form1.cmbTransporte.Text = String.Empty
                        Form1.txbObservacion.Text = String.Empty
                        Me.Hide()
                        Form1.txbPicking.Focus()


                        'IMPRIME RESUMEN

                        If cantidad > 1 Then
                            MessageBox.Show("Peso Total: " & pesoStr & " Kg.", "Peso total de los bultos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            opcion = MessageBox.Show("Desea Imprimir resumen de etiquetas?", "Resumen", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                            If (opcion = Windows.Forms.DialogResult.Yes) Then
                                last = first + cantidad - 1
                                Dim print2 As New ResumenBulto()
                                print2.imprimeresumen()
                                Form1.txbPicking.Focus()
                                Me.Close()
                                Form1.txbPicking.Focus()
                            Else
                                Form1.txbPicking.Focus()
                                Me.Close()
                                Form1.txbPicking.Focus()
                            End If

                        Else
                            Form1.txbPicking.Focus()
                            Me.Close()
                            Form1.txbPicking.Focus()
                        End If
                End If
                End If
            Else
                MessageBox.Show("Debe ingresar un número")
                txbPeso.Text = "0.00"
            End If
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