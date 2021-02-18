Imports System.Data.Sql
Imports System.Data.SqlClient
Imports AppEtiquetaPesa
Imports System.Data.OleDb
Imports System.IO.Ports.SerialPort
Imports IntegracionEnviame
Imports Newtonsoft

Module conexion

    Public conexion As SqlConnection
    Public enunciado As SqlCommand
    Public respuesta As SqlDataReader
    Public apiKeyEnviame As String = "7d066821f33647851bffb8802bf81113"
    Public urlEnviame As String = "https://stage.api.enviame.io/api/s2/v2/"
    Public compEnviame As Integer = 620
    Public oOperations, oRequest, oResponse, oOrden, oDestino, oShippingOrigin, oCarrier, oCustomer, oHomeAddress, oDeliveryAddress, oShippingDestination
    Public errorCode As Integer
    Public errorMsg, oComuna, oDireccion, oCliente, oMail, oBodOrigen, oSeccion, oId, oTelefono, oInformacion, dataarea As String
    Public uriLabel As String
    Public pesoTotal As Decimal = 5
    Public volumenTotal As Decimal = 10
    Public URL As String = "https://storage.googleapis.com/dev-carrier-deliveries/202101/1558370/5943-label.pdf"

    Sub Abrir()
        Try
            conexion = New SqlConnection("Data Source=ax-sqlvm;Initial Catalog=AX_MAINDB;Integrated Security=True")
            conexion.Open()
            'MsgBox("conectado")
        Catch ex As Exception
            MsgBox("no conectado" + ex.ToString)
        End Try
    End Sub

    Sub FillCombobox(ByVal cb As ComboBox)

        Try
            Abrir()
            enunciado = New SqlCommand("select ID, CASE WHEN ID = 'CMD' THEN 'DAP DUCASSE DISEÑO' WHEN ID = 'CWD' THEN 'COLOWALL DISEÑO' WHEN ID = 'DCO' THEN 'DUCASSE COMERCIAL' WHEN ID = 'SII' THEN 'STOCK INSUMOS INDUSTRIALES' WHEN ID = 'TBD' THEN 'TUBEXA INDUSTRIAL' END NAME from dataarea where ID not in ('GAB','SPCH','TBX','XE','DAT')", conexion)
            respuesta = enunciado.ExecuteReader

            While respuesta.Read
                cb.Items.Add(respuesta.Item("NAME"))
            End While

            respuesta.Close()

        Catch ex As Exception

        End Try

    End Sub

    Sub FillTransportista(ByVal cb As ComboBox)
        conexion.Close()
        conexion.Open()

        Try
            If Form1.cmbEmpresa.Text = "DUCASSE COMERCIAL" Then
                Form1.lblDataarea.Text = "DCO"
            ElseIf Form1.cmbEmpresa.Text = "DAP DUCASSE DISEÑO" Then
                Form1.lblDataarea.Text = "CMD"
            ElseIf Form1.cmbEmpresa.Text = "COLOWALL DISEÑO" Then
                Form1.lblDataarea.Text = "CWD"
            ElseIf Form1.cmbEmpresa.Text = "STOCK INSUMOS INDUSTRIALES" Then
                Form1.lblDataarea.Text = "SII"
            ElseIf Form1.cmbEmpresa.Text = "TUBEXA INDUSTRIAL" Then
                Form1.lblDataarea.Text = "TBD"
            End If

            enunciado = New SqlCommand("spu_Drivers", conexion)
            enunciado.CommandType = CommandType.StoredProcedure

            enunciado.Parameters.AddWithValue("@DATAAREAID", Form1.lblDataarea.Text)
            enunciado.Parameters.AddWithValue("@DIMENSIONS", Form1.lblPos.Text)

            respuesta = enunciado.ExecuteReader
            While respuesta.Read = True
                Form1.cmbTransporte.Items.Add(respuesta.Item("DRIVERNAME"))
            End While
            conexion.Close()
        Catch ex As Exception
        End Try

    End Sub

    Sub FillEmpleado(ByVal cb As ComboBox)
        conexion.Close()
        conexion.Open()

        Try
            If Form1.cmbEmpresa.Text = "DUCASSE COMERCIAL" Then
                Form1.Lblgab.Text = "GAB"
            ElseIf Form1.cmbEmpresa.Text = "DAP DUCASSE DISEÑO" Then
                Form1.Lblgab.Text = "CMD"
            ElseIf Form1.cmbEmpresa.Text = "COLOWALL DISEÑO" Then
                Form1.Lblgab.Text = "CWD"
            ElseIf Form1.cmbEmpresa.Text = "STOCK INSUMOS INDUSTRIALES" Then
                Form1.Lblgab.Text = "SII"
            ElseIf Form1.cmbEmpresa.Text = "TUBEXA INDUSTRIAL" Then
                Form1.Lblgab.Text = "TBD"
            End If

            enunciado = New SqlCommand("spu_EmisorEtiqueta", conexion)
            enunciado.CommandType = CommandType.StoredProcedure

            ' enunciado.Parameters.AddWithValue("@DATAAREAID", Form1.Lblgab.Text)

            respuesta = enunciado.ExecuteReader
            While respuesta.Read = True
                Form1.cmbEmpleado.Items.Add(respuesta.Item("NAME"))
            End While
            conexion.Close()
        Catch ex As Exception
        End Try

    End Sub

    Sub FillBodega(ByVal cb As ComboBox)
        conexion.Close()
        conexion.Open()

        Try
            If Form1.cmbEmpresa.Text = "DUCASSE COMERCIAL" Then
                Form1.lblDataarea.Text = "DCO"
            ElseIf Form1.cmbEmpresa.Text = "DAP DUCASSE DISEÑO" Then
                Form1.lblDataarea.Text = "CMD"
            ElseIf Form1.cmbEmpresa.Text = "COLOWALL DISEÑO" Then
                Form1.lblDataarea.Text = "CWD"
            ElseIf Form1.cmbEmpresa.Text = "STOCK INSUMOS INDUSTRIALES" Then
                Form1.lblDataarea.Text = "SII"
            ElseIf Form1.cmbEmpresa.Text = "TUBEXA INDUSTRIAL" Then
                Form1.lblDataarea.Text = "TBD"
            End If

            enunciado = New SqlCommand("spu_SelCDD", conexion)
            enunciado.CommandType = CommandType.StoredProcedure
            enunciado.Parameters.AddWithValue("@DATAAREAID", Form1.lblDataarea.Text)
            respuesta = enunciado.ExecuteReader

            While respuesta.Read = True
                Form1.cmbBodega.Items.Add(respuesta.Item("DESCRIPTION"))
            End While
            conexion.Close()
        Catch ex As Exception
        End Try

    End Sub

    Sub POSVAL()
        Try
            Abrir()
            enunciado = New SqlCommand("select num from DIMENSIONS where DIMENSIONCODE = 0 and DATAAREAID ='" & Form1.lblDataarea.Text & "' AND DESCRIPTION = '" & Form1.cmbBodega.Text & "'", conexion)
            respuesta = enunciado.ExecuteReader

            While respuesta.Read()
                Form1.lblPos.Text = respuesta("NUM").ToString()
            End While

            respuesta.Close()
        Catch ex As Exception
        End Try

    End Sub

    Sub getsp()
        Dim r As SqlDataReader
        Dim str_emp = Form1.lblDataarea.Text
        Dim str_docto = Form1.txbPicking.Text

        conexion.Close()
        conexion.Open()

        Try

            If str_emp = "DCO" Then

                Dim cmd As SqlCommand = New SqlCommand("spu_QryEtiqueta_dco", conexion)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@DATAAREAID", str_emp)
                cmd.Parameters.AddWithValue("@DOCTO", str_docto)


                r = cmd.ExecuteReader()
                If r.Read() Then
                    FormPesoEtiqueta.lblpck.Text = r.GetString(0).ToString()
                    FormPesoEtiqueta.lbldct.Text = r.GetString(1).ToString()
                    FormPesoEtiqueta.lblrut.Text = If(r.IsDBNull(2), "", r.GetString(2))
                    FormPesoEtiqueta.lblcli.Text = If(r.IsDBNull(3), "", r.GetString(3))
                    FormPesoEtiqueta.lbldir.Text = If(r.IsDBNull(4), "", r.GetString(4))
                    FormPesoEtiqueta.lblcom.Text = If(r.IsDBNull(5), "", r.GetString(5))
                    FormPesoEtiqueta.lblciu.Text = If(r.IsDBNull(6), "", r.GetString(6))
                    FormPesoEtiqueta.lblreg.Text = If(r.IsDBNull(7), "", r.GetString(7))
                    FormPesoEtiqueta.lblsec.Text = If(r.IsDBNull(8), "", r.GetString(8))
                    FormPesoEtiqueta.lblpos.Text = If(r.IsDBNull(9), "", r.GetString(9))
                    FormPesoEtiqueta.lblfralm.Text = If(r.IsDBNull(10), "", r.GetString(10))
                    FormPesoEtiqueta.lbltoalm.Text = If(r.IsDBNull(11), "", r.GetString(11))
                End If
            Else

                Dim cmd1 As SqlCommand = New SqlCommand("spu_QryEtiqueta_dco", conexion)
                cmd1.CommandType = CommandType.StoredProcedure
                cmd1.Parameters.AddWithValue("@DATAAREAID", str_emp)
                cmd1.Parameters.AddWithValue("@DOCTO", str_docto)


                r = cmd1.ExecuteReader()
                If r.Read() Then
                    FormPesoEtiqueta.lblpck.Text = r.GetString(0).ToString()
                    FormPesoEtiqueta.lbldct.Text = r.GetString(1).ToString()
                    FormPesoEtiqueta.lblrut.Text = If(r.IsDBNull(2), "", r.GetString(2))
                    FormPesoEtiqueta.lblcli.Text = If(r.IsDBNull(3), "", r.GetString(3))
                    FormPesoEtiqueta.lbldir.Text = If(r.IsDBNull(4), "", r.GetString(4))
                    FormPesoEtiqueta.lblcom.Text = If(r.IsDBNull(5), "", r.GetString(5))
                    FormPesoEtiqueta.lblciu.Text = If(r.IsDBNull(6), "", r.GetString(6))
                    FormPesoEtiqueta.lblreg.Text = If(r.IsDBNull(7), "", r.GetString(7))
                    FormPesoEtiqueta.lblsec.Text = If(r.IsDBNull(8), "", r.GetString(8))
                    FormPesoEtiqueta.lblpos.Text = If(r.IsDBNull(9), "", r.GetString(9))
                    FormPesoEtiqueta.lblfralm.Text = If(r.IsDBNull(10), "", r.GetString(10))
                    FormPesoEtiqueta.lbltoalm.Text = If(r.IsDBNull(11), "", r.GetString(11))

                End If

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

        conexion.Close()
    End Sub

    Sub getsp1()
        Dim r As SqlDataReader
        Dim str_emp = Form1.lblDataarea.Text
        Dim str_lbl = FormReImpresion.TextBox1.Text

        conexion.Close()
        conexion.Open()
        'Abrir()

        Try
            If Form1.cmbEmpresa.Text = "DUCASSE COMERCIAL" Then
                Form1.lblDataarea.Text = "DCO"
            ElseIf Form1.cmbEmpresa.Text = "DAP DUCASSE DISEÑO" Then
                Form1.lblDataarea.Text = "CMD"
            ElseIf Form1.cmbEmpresa.Text = "COLOWALL DISEÑO" Then
                Form1.lblDataarea.Text = "CWD"
            ElseIf Form1.cmbEmpresa.Text = "STOCK INSUMOS INDUSTRIALES" Then
                Form1.lblDataarea.Text = "SII"
            ElseIf Form1.cmbEmpresa.Text = "TUBEXA INDUSTRIAL" Then
                Form1.lblDataarea.Text = "TBD"
            End If
            Dim cmd As SqlCommand = New SqlCommand("spu_QryEtiquetaRI", conexion)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@DATAAREAID", str_emp)
            cmd.Parameters.AddWithValue("@LABELID", str_lbl)

            r = cmd.ExecuteReader()
            If r.Read() Then
                FormReImpresion.lblid.Text = r.GetInt32(0).ToString()
                FormReImpresion.lbldate.Text = r.GetString(1).ToString()
                FormReImpresion.lblpck.Text = r.GetString(2).ToString()
                FormReImpresion.lblpv.Text = r.GetString(3).ToString()
                FormReImpresion.lblcli.Text = r.GetString(4).ToString()
                FormReImpresion.lbldir.Text = r.GetString(5).ToString()
                FormReImpresion.lblcom.Text = r.GetString(6).ToString()
                FormReImpresion.lblciu.Text = r.GetString(7).ToString()
                FormReImpresion.lblreg.Text = r.GetString(8).ToString()
                FormReImpresion.lblcoment.Text = r.GetString(9).ToString()
                FormReImpresion.lblcond.Text = r.GetString(10).ToString()
                FormReImpresion.lbppeso.Text = r.GetDecimal(11).ToString()
                FormReImpresion.lblhora.Text = r.GetString(12).ToString()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

        conexion.Close()
    End Sub

    Sub getexiste()
        Dim r As SqlDataReader
        

        conexion.Close()
        conexion.Open()
        Try
            If Form1.cmbEmpresa.Text = "DUCASSE COMERCIAL" Then
                Form1.lblDataarea.Text = "DCO"
            ElseIf Form1.cmbEmpresa.Text = "DAP DUCASSE DISEÑO" Then
                Form1.lblDataarea.Text = "CMD"
            ElseIf Form1.cmbEmpresa.Text = "COLOWALL DISEÑO" Then
                Form1.lblDataarea.Text = "CWD"
            ElseIf Form1.cmbEmpresa.Text = "STOCK INSUMOS INDUSTRIALES" Then
                Form1.lblDataarea.Text = "SII"
            ElseIf Form1.cmbEmpresa.Text = "TUBEXA INDUSTRIAL" Then
                Form1.lblDataarea.Text = "TBD"
            End If

            Dim str_emp = Form1.lblDataarea.Text
            Dim str_docto = Form1.txbPicking.Text


            If str_emp = "DCO" Then
                Dim cmd As SqlCommand = New SqlCommand("spu_QryEtiqueta_dco", conexion)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@DATAAREAID", str_emp)
                cmd.Parameters.AddWithValue("@DOCTO", str_docto)

                r = cmd.ExecuteReader()
                If r.Read() Then
                    Form1.Label3.Text = r.GetString(0).ToString()
                End If
                

            Else
                Dim cmd1 As SqlCommand = New SqlCommand("spu_QryEtiqueta_dco", conexion)
                cmd1.CommandType = CommandType.StoredProcedure
                cmd1.Parameters.AddWithValue("@DATAAREAID", str_emp)
                cmd1.Parameters.AddWithValue("@DOCTO", str_docto)


                r = cmd1.ExecuteReader()
                If r.Read() Then
                    Form1.Label3.Text = r.GetString(0).ToString()

                End If

            End If




        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

        conexion.Close()
    End Sub

    Sub InsertLabel(ByVal LabelID As Integer, ByVal PickingRouteId As String, ByVal TransrefId As String, ByVal Customer As String, ByVal DeliveryName As String, ByVal DeliveryAddress As String, ByVal AddressCounty As String, ByVal AddressCity As String, ByVal AddressState As String, ByVal Dimension_4 As String, ByVal DriverName As String, ByVal Weight As Double, ByVal Comment As String, ByVal Dataareaid As String, ByVal RecID As String, ByVal Dimension_ As String, ByVal InventLocationId As String, ByVal InventLocationIdTo As String, ByVal Responsible As String, ByVal PathExternalLabel As String)

        Try
            conexion.Close()
            conexion.Open()

            enunciado = New SqlCommand("spu_insertLabel2", conexion)
            enunciado.CommandType = CommandType.StoredProcedure

            With enunciado.Parameters
                .AddWithValue("@LabelId", LabelID)
                .AddWithValue("PickingRouteId", PickingRouteId)
                .AddWithValue("TransrefId", TransrefId)
                .AddWithValue("Customer", Customer)
                .AddWithValue("DeliveryName", DeliveryName)
                .AddWithValue("DeliveryAddress", DeliveryAddress)
                .AddWithValue("AddressCounty", AddressCounty)
                .AddWithValue("AddressCity", AddressCity)
                .AddWithValue("AddressState", AddressState)
                .AddWithValue("Dimension_4", Dimension_4)
                .AddWithValue("Drivername", DriverName)
                .AddWithValue("Weight", Weight)
                .AddWithValue("Comment", Comment)
                .AddWithValue("DataAreaId", Dataareaid)
                .AddWithValue("RecId", RecID)
                .AddWithValue("Dimension_", Dimension_)
                .AddWithValue("InventLocationId", InventLocationId)
                .AddWithValue("InventLocationIdTo", InventLocationIdTo)
                .AddWithValue("Responsible", Responsible)
                .AddWithValue("PathExternalLabel", PathExternalLabel)

            End With
            enunciado.ExecuteNonQuery()
            conexion.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)

        End Try

    End Sub

    Sub numEtiqueta()
        Dim r As SqlDataReader
        Dim str_emp = Form1.lblDataarea.Text
        Dim str_docto = Form1.txbPicking.Text
        conexion.Close()
        conexion.Open()

        Try
            Dim cmd As SqlCommand = New SqlCommand("spu_CountLabel", conexion)
            cmd.CommandType = CommandType.StoredProcedure
            r = cmd.ExecuteReader()

            If r.Read() Then
                FormPesoEtiqueta.contador = r.GetInt32(0)
                FormPesoEtiqueta.first = r.GetInt32(0)
            End If
            conexion.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Sub getResLabel()
        Dim r As SqlDataReader
        Dim str_pick = FormPesoEtiqueta.lblpck.Text
        Dim str_dataarea = FormPesoEtiqueta.lbldat.Text
        conexion.Close()
        conexion.Open()

        Try
            Dim cmd As SqlCommand = New SqlCommand("spu_ResumeLabel", conexion)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Picking", str_pick)
            cmd.Parameters.AddWithValue("@Dataareaid", str_dataarea)
            r = cmd.ExecuteReader()
            If r.Read() Then
                FormPesoEtiqueta.first = r.GetInt32(0)
                FormPesoEtiqueta.last = r.GetInt32(1)
                'FormPesoEtiqueta.pesototal = r.GetSqlDecimal(2)
            End If
            conexion.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Sub capturaPeso()
        Try
            With FormPesoEtiqueta.SerialPort1
                .BaudRate = 9600
                .DataBits = 8
                .Parity = IO.Ports.Parity.None
                .StopBits = 1
                .PortName = Form1.ComboBox1.Text
                .Open()
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    Sub buscaPuerto()
        Try
            Form1.ComboBox1.Items.Clear()
            For Each puerto As String In My.Computer.Ports.SerialPortNames
                Form1.ComboBox1.Items.Add(puerto)
            Next

            If Form1.ComboBox1.Items.Count > 0 Then
                Form1.ComboBox1.SelectedIndex = 0
            Else
                MsgBox("Sin puertos disponibles")
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Sub getRILbl()

        Dim re As SqlDataReader
        Dim str_emp = Form1.lblDataarea.Text
        Dim str_lbl = FormReImpresion.TextBox1.Text

        conexion.Close()
        conexion.Open()

        Try
            If Form1.cmbEmpresa.Text = "DUCASSE COMERCIAL" Then
                Form1.lblDataarea.Text = "DCO"
            ElseIf Form1.cmbEmpresa.Text = "DAP DUCASSE DISEÑO" Then
                Form1.lblDataarea.Text = "CMD"
            ElseIf Form1.cmbEmpresa.Text = "COLOWALL DISEÑO" Then
                Form1.lblDataarea.Text = "CWD"
            ElseIf Form1.cmbEmpresa.Text = "STOCK INSUMOS INDUSTRIALES" Then
                Form1.lblDataarea.Text = "SII"
            ElseIf Form1.cmbEmpresa.Text = "TUBEXA INDUSTRIAL" Then
                Form1.lblDataarea.Text = "TBD"
            End If

            Dim cmd As SqlCommand = New SqlCommand("spu_QryEtiquetaRI", conexion)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@DATAAREAID", str_emp)
            cmd.Parameters.AddWithValue("@LABELID", str_lbl)

            re = cmd.ExecuteReader()
            If re.Read() Then
                FormReImpresion.lblid.Text = re.GetString(0).ToString()
                FormReImpresion.lbldate.Text = re.GetString(1).ToString()
                FormReImpresion.lblpck.Text = re.GetString(2).ToString()
                FormReImpresion.lblpv.Text = re.GetString(3).ToString()
                FormReImpresion.lblcli.Text = re.GetString(4).ToString()
                FormReImpresion.lbldir.Text = re.GetString(5).ToString()
                FormReImpresion.lblcom.Text = re.GetString(6).ToString()
                FormReImpresion.lblciu.Text = re.GetString(7).ToString()
                FormReImpresion.lblreg.Text = re.GetString(8).ToString()
                FormReImpresion.lblcoment.Text = re.GetString(9).ToString()
                FormReImpresion.lblcond.Text = re.GetString(10).ToString()
                FormReImpresion.lbppeso.Text = re.GetString(11).ToString()
                FormReImpresion.lblhora.Text = re.GetString(12).ToString()


            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

        conexion.Close()
    End Sub

    Sub getCustomerRef()

        Dim re As SqlDataReader
        Dim str_emp = Form1.lblDataarea.Text
        Dim str_PV = Form1.txbPicking.Text

        conexion.Close()
        conexion.Open()

        Try
            If Form1.cmbEmpresa.Text = "DUCASSE COMERCIAL" Then
                Form1.lblDataarea.Text = "DCO"
            ElseIf Form1.cmbEmpresa.Text = "DAP DUCASSE DISEÑO" Then
                Form1.lblDataarea.Text = "CMD"
            ElseIf Form1.cmbEmpresa.Text = "COLOWALL DISEÑO" Then
                Form1.lblDataarea.Text = "CWD"
            ElseIf Form1.cmbEmpresa.Text = "STOCK INSUMOS INDUSTRIALES" Then
                Form1.lblDataarea.Text = "SII"
            ElseIf Form1.cmbEmpresa.Text = "TUBEXA INDUSTRIAL" Then
                Form1.lblDataarea.Text = "TBD"
            End If

            Dim cmd As SqlCommand = New SqlCommand("spu_findCustomerRef", conexion)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@DATAAREAID", str_emp)
            cmd.Parameters.AddWithValue("@DOCTO", str_PV)

            re = cmd.ExecuteReader()
            If re.Read() Then
                FormPesoEtiqueta.customerRef = If(re.IsDBNull(0), "", re.GetString(0))
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

        conexion.Close()
    End Sub

    Sub APIenv()
        'oComuna, oDireccion, oCliente, oMail, oBodOrigen, oSeccion, oId, oTelefono, oInformacion 
        oComuna = FormPesoEtiqueta.lblcom.Text
        oDireccion = FormPesoEtiqueta.lbldir.Text
        oCliente = FormPesoEtiqueta.lblcli.Text
        oMail = "maildeprueba@ducasse.cl"
        oBodOrigen = Form1.cmbBodega.Text
        oSeccion = FormPesoEtiqueta.lblsec.Text
        oId = FormPesoEtiqueta.lblb.Text
        oTelefono = "223557000"
        oInformacion = Form1.txbObservacion.Text

        oOperations = New IntegracionEnviame.API.Operaciones(apiKeyEnviame, urlEnviame, compEnviame)
        oRequest = New IntegracionEnviame.Schema.Requests.CrearEnvioRequest()
        oOrden = New IntegracionEnviame.Schema.Requests.Orden()
        oDestino = New IntegracionEnviame.Schema.Requests.Destino()
        oShippingOrigin = New IntegracionEnviame.Schema.Request.ShippingOrigin()
        oCarrier = New IntegracionEnviame.Schema.Request.Carrier()
        oCustomer = New IntegracionEnviame.Schema.Request.Customer()
        oHomeAddress = New IntegracionEnviame.Schema.Request.HomeAddress()
        oDeliveryAddress = New IntegracionEnviame.Schema.Request.DeliveryAddress()
        oShippingDestination = New IntegracionEnviame.Schema.Request.ShippingDetination()

        Try
            '' Orden
            oOrden.set_CantidadBultos(5)
            oOrden.set_CodBodegaOrigen("cod_bod123")
            oOrden.set_DescripcionContenido("Quincalleria")
            oOrden.set_IdReferencia("22")
            oOrden.set_PesoTotal(pesoTotal)
            oOrden.set_Precio(1200)
            oOrden.set_VolumenTotal(volumenTotal)
            '' Destino
            oDestino.set_Comuna(oComuna)
            oDestino.set_DireccionCompleta(oDireccion)
            oDestino.set_EmailReceptor(oMail)
            oDestino.set_NombreReceptor(oCliente)
            oDestino.set_Informacion(oInformacion)
            oDestino.set_TelefonoReceptor(oTelefono)
            ''
            oRequest.set_Carrier("")
            oRequest.set_Destino(oDestino)
            oRequest.set_Orden(oOrden)
            '' Create delivery
            oResponse = oOperations.CrearEnvio(oRequest)
            errorCode = oResponse.get_ErrorCode()
            If (errorCode <> -1) Then

                uriLabel = oResponse.get_EtiquetaPdf()
                'MessageBox.Show(uriLabel)
                '' Donwload file

                If FormPesoEtiqueta.lbldat.Text = "DCO" Then
                    My.Computer.Network.DownloadFile(URL, "\\serv-bkp1\EtiquetaExterna\DCO\" + FormPesoEtiqueta.lbldct.Text + ".pdf")
                ElseIf FormPesoEtiqueta.lbldat.Text = "CMD" Then
                    My.Computer.Network.DownloadFile(URL, "\\serv-bkp1\EtiquetaExterna\CMD\" + FormPesoEtiqueta.lbldct.Text + ".pdf")
                ElseIf FormPesoEtiqueta.lbldat.Text = "CWD" Then
                    My.Computer.Network.DownloadFile(URL, "\\serv-bkp1\EtiquetaExterna\CWD\" + FormPesoEtiqueta.lbldct.Text + ".pdf")
                ElseIf FormPesoEtiqueta.lbldat.Text = "SII" Then
                    My.Computer.Network.DownloadFile(URL, "\\serv-bkp1\EtiquetaExterna\SII\" + FormPesoEtiqueta.lbldct.Text + ".pdf")
                ElseIf FormPesoEtiqueta.lbldat.Text = "TBD" Then
                    My.Computer.Network.DownloadFile(URL, "\\serv-bkp1\EtiquetaExterna\TBD\" + FormPesoEtiqueta.lbldct.Text + ".pdf")
                Else
                    MessageBox.Show("Error, por favor contactarse con el administrador")
                End If

            Else
                errorMsg = oResponse.get_ErrorDescription()
                MessageBox.Show(errorMsg)
            End If

        Catch ex As Exception
            MessageBox.Show("Etiqueta ya existe o sin acceso a carpeta de destino")
        End Try
    End Sub

    Sub imprimeResumen()
        'IMPRIME RESUMEN

        '' If cantidad > 1 Then
        ''MessageBox.Show("Peso Total: " & pesoStr & " Kg.", "Peso total de los bultos", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ''opcion = MessageBox.Show("Desea Imprimir resumen de etiquetas?", "Resumen", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        ''If (opcion = Windows.Forms.DialogResult.Yes) Then
        ''last = first + cantidad - 1
        ''Dim print2 As New ResumenBulto()
        ''print2.imprimeresumen()
        ''Form1.txbPicking.Focus()
        ''Me.Close()
        ''Form1.txbPicking.Focus()
        ''Else
        ''  Form1.txbPicking.Focus()
        ''Me.Close()
        ''Form1.txbPicking.Focus()
        ''End If
        ''Else
        ''  Form1.txbPicking.Focus()
        ''Me.Close()
        ''Form1.txbPicking.Focus()
        ''End If

    End Sub

    Sub imprimeEtiquetaExterna()
        Try
            Dim psi As System.Diagnostics.ProcessStartInfo = New System.Diagnostics.ProcessStartInfo()

            psi.UseShellExecute = True
            psi.Verb = "print"

            '' Abre archivo creado por ws externo
            If FormPesoEtiqueta.lbldat.Text = "DCO" Then
                psi.FileName = "\\serv-bkp1\EtiquetaExterna\DCO\" + FormPesoEtiqueta.lbldct.Text + ".pdf"
            ElseIf FormPesoEtiqueta.lbldat.Text = "CMD" Then
                psi.FileName = "\\serv-bkp1\EtiquetaExterna\CMD\" + FormPesoEtiqueta.lbldct.Text + ".pdf"
            ElseIf FormPesoEtiqueta.lbldat.Text = "CWD" Then
                psi.FileName = "\\serv-bkp1\EtiquetaExterna\CWD\" + FormPesoEtiqueta.lbldct.Text + ".pdf"
            ElseIf FormPesoEtiqueta.lbldat.Text = "SII" Then
                psi.FileName = "\\serv-bkp1\EtiquetaExterna\SII\" + FormPesoEtiqueta.lbldct.Text + ".pdf"
            ElseIf FormPesoEtiqueta.lbldat.Text = "TBD" Then
                psi.FileName = "\\serv-bkp1\EtiquetaExterna\TBD\" + FormPesoEtiqueta.lbldct.Text + ".pdf"
            Else
                MessageBox.Show("Error, por favor contactarse con el administrador")
            End If

            'psi.FileName = "\\serv-bkp1\EtiquetaExterna\DCO\" + FormPesoEtiqueta.lbldct.Text + ".pdf"
            psi.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden
            psi.ErrorDialog = False
            psi.Arguments = "/p"
            Dim p As System.Diagnostics.Process = System.Diagnostics.Process.Start(psi)
            p.WaitForInputIdle()

        Catch ex As Exception
            MessageBox.Show("Etiqueta externa no generada")
        End Try
       
    End Sub

    Sub ReimprimeEtiquetaExterna()
        Dim rpsi As System.Diagnostics.ProcessStartInfo = New System.Diagnostics.ProcessStartInfo()

        rpsi.UseShellExecute = True
        rpsi.Verb = "print"
        rpsi.FileName = "C:\dscpdf\" + FormPesoEtiqueta.lblpck.Text + ".pdf"
        rpsi.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden
        rpsi.ErrorDialog = False
        rpsi.Arguments = "/p"

        Dim p As System.Diagnostics.Process = System.Diagnostics.Process.Start(rpsi)
        p.WaitForInputIdle()
    End Sub

    Sub opcionImprimirEtiquetaExterna()
        Dim opcion As DialogResult
        opcion = MessageBox.Show("Desea Imprimir etiquetas Externa?", "Etiqueta Carrier", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If (opcion = Windows.Forms.DialogResult.Yes) Then

            imprimeEtiquetaExterna()
            Form1.txbPicking.Focus()
            FormPesoEtiqueta.Close()
            Form1.txbPicking.Focus()
        Else
            Form1.txbPicking.Focus()
            FormPesoEtiqueta.Close()
            Form1.txbPicking.Focus()
        End If

    End Sub

    Sub limpiaForm1()
        Form1.txbPicking.Text = String.Empty
        Form1.txbCantEtiquetas.Text = String.Empty
        Form1.cmbTransporte.Text = String.Empty
        Form1.txbObservacion.Text = String.Empty
    End Sub

    Sub limpiaVariablesFormPeso()
        FormPesoEtiqueta.lblbod.Text = ""
        FormPesoEtiqueta.lblciu.Text = ""
        FormPesoEtiqueta.lblcli.Text = ""
        FormPesoEtiqueta.lblcom.Text = ""
        FormPesoEtiqueta.lbldir.Text = ""
        FormPesoEtiqueta.lblloc.Text = ""
        FormPesoEtiqueta.lblobs.Text = ""
        FormPesoEtiqueta.lblreg.Text = ""
        FormPesoEtiqueta.lblrut.Text = ""
        FormPesoEtiqueta.lblsec.Text = ""
        FormPesoEtiqueta.lbltrans.Text = ""
        FormPesoEtiqueta.lblpos.Text = ""
        FormPesoEtiqueta.lblfralm.Text = ""
        FormPesoEtiqueta.lbltoalm.Text = ""
    End Sub

    Sub cargaDatosFormPeso()
        FormPesoEtiqueta.lbldat.Text = Form1.lblDataarea.Text
        FormPesoEtiqueta.lbltrans.Text = Form1.cmbTransporte.Text
        FormPesoEtiqueta.lblb.Text = Form1.txbCantEtiquetas.Text
        FormPesoEtiqueta.cantidad = Form1.txbCantEtiquetas.Text
        FormPesoEtiqueta.lblobs.Text = Form1.txbObservacion.Text + " " + FormPesoEtiqueta.customerRef

        FormPesoEtiqueta.lbla.Text = 1
        FormPesoEtiqueta.lblfec.Text = "2018/12/13"
        FormPesoEtiqueta.txbPeso.Text = "0.00"
    End Sub

    Sub generaEtiquetaCarrier()
        'oComuna, oDireccion, oCliente, oMail, oBodOrigen, oSeccion, oId, oTelefono, oInformacion 
        oComuna = FormPesoEtiqueta.lblcom.Text
        oDireccion = FormPesoEtiqueta.lbldir.Text
        oCliente = FormPesoEtiqueta.lblcli.Text
        oMail = "maildeprueba@ducasse.cl"
        oBodOrigen = Form1.cmbBodega.Text
        oSeccion = FormPesoEtiqueta.lblsec.Text
        oId = FormPesoEtiqueta.lblb.Text
        oTelefono = "223557000"
        oInformacion = Form1.txbObservacion.Text

        oOperations = New IntegracionEnviame.API.Operaciones(apiKeyEnviame, urlEnviame, compEnviame)
        oRequest = New IntegracionEnviame.Schema.Requests.CrearEnvioRequest()
        oOrden = New IntegracionEnviame.Schema.Requests.Orden()
        oDestino = New IntegracionEnviame.Schema.Requests.Destino()
        oShippingOrigin = New IntegracionEnviame.Schema.Request.ShippingOrigin()
        oCarrier = New IntegracionEnviame.Schema.Request.Carrier()
        oCustomer = New IntegracionEnviame.Schema.Request.Customer()
        oHomeAddress = New IntegracionEnviame.Schema.Request.HomeAddress()
        oDeliveryAddress = New IntegracionEnviame.Schema.Request.DeliveryAddress()
        oShippingDestination = New IntegracionEnviame.Schema.Request.ShippingDetination()

        Try
            '' Orden
            oOrden.set_CantidadBultos(5)
            oOrden.set_CodBodegaOrigen("cod_bod123")
            oOrden.set_DescripcionContenido("Quincalleria")
            oOrden.set_IdReferencia("22")
            oOrden.set_PesoTotal(pesoTotal)
            oOrden.set_Precio(1200)
            oOrden.set_VolumenTotal(volumenTotal)
            '' Destino
            oDestino.set_Comuna(oComuna)
            oDestino.set_DireccionCompleta(oDireccion)
            oDestino.set_EmailReceptor(oMail)
            oDestino.set_NombreReceptor(oCliente)
            oDestino.set_Informacion(oInformacion)
            oDestino.set_TelefonoReceptor(oTelefono)
            ''
            oRequest.set_Carrier("")
            oRequest.set_Destino(oDestino)
            oRequest.set_Orden(oOrden)
            '' Create delivery
            oResponse = oOperations.CrearEnvio(oRequest)
            errorCode = oResponse.get_ErrorCode()
            If (errorCode <> -1) Then

                uriLabel = oResponse.get_EtiquetaPdf()
                'MessageBox.Show(uriLabel)
                '' Donwload file

                If dataarea = "DCO" Then
                    My.Computer.Network.DownloadFile(URL, "\\serv-bkp1\EtiquetaExterna\DCO\" + FormGenerateCarrierLabel.TextBox1.Text + ".pdf")
                ElseIf dataarea = "CMD" Then
                    My.Computer.Network.DownloadFile(URL, "\\serv-bkp1\EtiquetaExterna\CMD\" + FormGenerateCarrierLabel.TextBox1.Text + ".pdf")
                ElseIf dataarea = "CWD" Then
                    My.Computer.Network.DownloadFile(URL, "\\serv-bkp1\EtiquetaExterna\CWD\" + FormGenerateCarrierLabel.TextBox1.Text + ".pdf")
                ElseIf dataarea = "SII" Then
                    My.Computer.Network.DownloadFile(URL, "\\serv-bkp1\EtiquetaExterna\SII\" + FormGenerateCarrierLabel.TextBox1.Text + ".pdf")
                ElseIf dataarea = "TBD" Then
                    My.Computer.Network.DownloadFile(URL, "\\serv-bkp1\EtiquetaExterna\TBD\" + FormGenerateCarrierLabel.TextBox1.Text + ".pdf")
                Else
                    MessageBox.Show("Error, por favor contactarse con el administrador")
                End If

            Else
                errorMsg = oResponse.get_ErrorDescription()
                MessageBox.Show(errorMsg)
            End If

        Catch ex As Exception
            MessageBox.Show("Etiqueta ya existe o sin acceso a carpeta de destino")
        End Try
    End Sub

    Sub getDataareaid()
        If Form1.cmbEmpresa.Text = "DUCASSE COMERCIAL" Then
            dataarea = "DCO"
        ElseIf Form1.cmbEmpresa.Text = "DAP DUCASSE DISEÑO" Then
            dataarea = "CMD"
        ElseIf Form1.cmbEmpresa.Text = "COLOWALL DISEÑO" Then
            dataarea = "CWD"
        ElseIf Form1.cmbEmpresa.Text = "STOCK INSUMOS INDUSTRIALES" Then
            dataarea = "SII"
        ElseIf Form1.cmbEmpresa.Text = "TUBEXA INDUSTRIAL" Then
            dataarea = "TBD"
        End If
    End Sub


    Sub reImprimeEtiquetaCarrier()
        Try
            Dim psi As System.Diagnostics.ProcessStartInfo = New System.Diagnostics.ProcessStartInfo()

            psi.UseShellExecute = True
            psi.Verb = "print"

            '' Abre archivo creado por ws externo
            If dataarea = "DCO" Then
                psi.FileName = "\\serv-bkp1\EtiquetaExterna\DCO\" + FormPesoEtiqueta.lbldct.Text + ".pdf"
            ElseIf dataarea = "CMD" Then
                psi.FileName = "\\serv-bkp1\EtiquetaExterna\CMD\" + FormPesoEtiqueta.lbldct.Text + ".pdf"
            ElseIf dataarea = "CWD" Then
                psi.FileName = "\\serv-bkp1\EtiquetaExterna\CWD\" + FormPesoEtiqueta.lbldct.Text + ".pdf"
            ElseIf dataarea = "SII" Then
                psi.FileName = "\\serv-bkp1\EtiquetaExterna\SII\" + FormPesoEtiqueta.lbldct.Text + ".pdf"
            ElseIf dataarea = "TBD" Then
                psi.FileName = "\\serv-bkp1\EtiquetaExterna\TBD\" + FormPesoEtiqueta.lbldct.Text + ".pdf"
            Else
                MessageBox.Show("Error, por favor contactarse con el administrador")
            End If

            'psi.FileName = "\\serv-bkp1\EtiquetaExterna\DCO\" + FormPesoEtiqueta.lbldct.Text + ".pdf"
            psi.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden
            psi.ErrorDialog = False
            psi.Arguments = "/p"
            Dim p As System.Diagnostics.Process = System.Diagnostics.Process.Start(psi)
            p.WaitForInputIdle()

        Catch ex As Exception
            MessageBox.Show("Etiqueta externa no generada")
        End Try

    End Sub



End Module

