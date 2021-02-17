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
    Public errorMsg As String
    Public uriLabel As String
    Public pesoTotalEnv As Decimal = 5
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

    Sub InsertLabel(ByVal LabelID As Integer, ByVal PickingRouteId As String, ByVal TransrefId As String, ByVal Customer As String, ByVal DeliveryName As String, ByVal DeliveryAddress As String, ByVal AddressCounty As String, ByVal AddressCity As String, ByVal AddressState As String, ByVal Dimension_4 As String, ByVal DriverName As String, ByVal Weight As Double, ByVal Comment As String, ByVal Dataareaid As String, ByVal RecID As String, ByVal Dimension_ As String, ByVal InventLocationId As String, ByVal InventLocationIdTo As String, ByVal Responsible As String)

        Try
            conexion.Close()
            conexion.Open()

            enunciado = New SqlCommand("spu_insertLabel1", conexion)
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
            oOrden.set_PesoTotal(pesoTotalEnv)
            oOrden.set_Precio(1200)
            oOrden.set_VolumenTotal(volumenTotal)
            '' Destino
            oDestino.set_Comuna("SANTIAGO")
            oDestino.set_DireccionCompleta("Alameda 1460, piso 8")
            oDestino.set_EmailReceptor("ivan.jerez@gmail.com")
            oDestino.set_NombreReceptor("Joaquin Jerez Martinez")
            oDestino.set_Informacion("Dejar en concerjería")
            oDestino.set_TelefonoReceptor("223557050")
            ''
            oRequest.set_Carrier("")
            oRequest.set_Destino(oDestino)
            oRequest.set_Orden(oOrden)
            '' Create delivery
            oResponse = oOperations.CrearEnvio(oRequest)
            errorCode = oResponse.get_ErrorCode()

            If (errorCode <> -1) Then
                uriLabel = oResponse.get_EtiquetaPdf()
                MessageBox.Show(uriLabel)
                '' Donwload file
                My.Computer.Network.DownloadFile(URL, "C:\dscpdf\etiqueta.pdf")

                Dim psi As System.Diagnostics.ProcessStartInfo = New System.Diagnostics.ProcessStartInfo()

                psi.UseShellExecute = True
                psi.Verb = "print"
                psi.FileName = "C:\dscpdf\etiqueta.pdf"
                psi.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden
                psi.ErrorDialog = False
                psi.Arguments = "/p"

                Dim p As System.Diagnostics.Process = System.Diagnostics.Process.Start(psi)
                p.WaitForInputIdle()


            Else

                errorMsg = oResponse.get_ErrorDescription()
                MessageBox.Show(errorMsg)
            End If
            ''
            ''MessageBox.Show("Termine")

            '' Eliminamos etiqueta temporal
            ''Dim ArchivoBorrar As String
            ''ArchivoBorrar = "C:\dscpdf\etiqueta.pdf"
            'comprobamos que el archivo existe
            ''If System.IO.File.Exists(ArchivoBorrar) = True Then
            ''System.IO.File.Delete(ArchivoBorrar)
            ''End If
            ''Catch ex As Exception
            ''MessageBox.Show("Error")
            ''End Try
    End Sub





End Module

