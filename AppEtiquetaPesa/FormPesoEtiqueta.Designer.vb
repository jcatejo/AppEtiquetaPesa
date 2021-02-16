<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPesoEtiqueta
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPesoEtiqueta))
        Me.Label1 = New System.Windows.Forms.Label
        Me.lbla = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblb = New System.Windows.Forms.Label
        Me.lblPeso = New System.Windows.Forms.Label
        Me.txbPeso = New System.Windows.Forms.TextBox
        Me.btnImprimir = New System.Windows.Forms.Button
        Me.lblpck = New System.Windows.Forms.Label
        Me.lbldct = New System.Windows.Forms.Label
        Me.lblrut = New System.Windows.Forms.Label
        Me.lblcli = New System.Windows.Forms.Label
        Me.lbldir = New System.Windows.Forms.Label
        Me.lblcom = New System.Windows.Forms.Label
        Me.lblciu = New System.Windows.Forms.Label
        Me.lblreg = New System.Windows.Forms.Label
        Me.lblloc = New System.Windows.Forms.Label
        Me.lblsec = New System.Windows.Forms.Label
        Me.lbldat = New System.Windows.Forms.Label
        Me.lbltrans = New System.Windows.Forms.Label
        Me.lblcateti = New System.Windows.Forms.Label
        Me.lblbod = New System.Windows.Forms.Label
        Me.lblfec = New System.Windows.Forms.Label
        Me.lblobs = New System.Windows.Forms.Label
        Me.lblCalPeso = New System.Windows.Forms.Label
        Me.lblcont = New System.Windows.Forms.Label
        Me.lblcantbul = New System.Windows.Forms.Label
        Me.lblfirst = New System.Windows.Forms.Label
        Me.lbllast = New System.Windows.Forms.Label
        Me.lblred = New System.Windows.Forms.Label
        Me.lblfeclbl = New System.Windows.Forms.Label
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.lblfralm = New System.Windows.Forms.Label
        Me.lbltoalm = New System.Windows.Forms.Label
        Me.lblpos = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(74, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 31)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Bulto"
        '
        'lbla
        '
        Me.lbla.AutoSize = True
        Me.lbla.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbla.Location = New System.Drawing.Point(171, 46)
        Me.lbla.Name = "lbla"
        Me.lbla.Size = New System.Drawing.Size(29, 31)
        Me.lbla.TabIndex = 1
        Me.lbla.Text = "a"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(206, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 31)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "de"
        '
        'lblb
        '
        Me.lblb.AutoSize = True
        Me.lblb.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblb.Location = New System.Drawing.Point(256, 46)
        Me.lblb.Name = "lblb"
        Me.lblb.Size = New System.Drawing.Size(29, 31)
        Me.lblb.TabIndex = 3
        Me.lblb.Text = "b"
        '
        'lblPeso
        '
        Me.lblPeso.AutoSize = True
        Me.lblPeso.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPeso.Location = New System.Drawing.Point(74, 169)
        Me.lblPeso.Name = "lblPeso"
        Me.lblPeso.Size = New System.Drawing.Size(76, 31)
        Me.lblPeso.TabIndex = 4
        Me.lblPeso.Text = "Peso"
        '
        'txbPeso
        '
        Me.txbPeso.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txbPeso.Location = New System.Drawing.Point(177, 166)
        Me.txbPeso.Name = "txbPeso"
        Me.txbPeso.Size = New System.Drawing.Size(100, 38)
        Me.txbPeso.TabIndex = 5
        '
        'btnImprimir
        '
        Me.btnImprimir.BackColor = System.Drawing.Color.LightBlue
        Me.btnImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimir.Location = New System.Drawing.Point(80, 265)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(205, 59)
        Me.btnImprimir.TabIndex = 7
        Me.btnImprimir.Text = "Imprimir Etiqueta"
        Me.btnImprimir.UseVisualStyleBackColor = False
        '
        'lblpck
        '
        Me.lblpck.AutoSize = True
        Me.lblpck.Location = New System.Drawing.Point(12, 225)
        Me.lblpck.Name = "lblpck"
        Me.lblpck.Size = New System.Drawing.Size(35, 13)
        Me.lblpck.TabIndex = 8
        Me.lblpck.Text = "lblpck"
        Me.lblpck.Visible = False
        '
        'lbldct
        '
        Me.lbldct.AutoSize = True
        Me.lbldct.Location = New System.Drawing.Point(53, 213)
        Me.lbldct.Name = "lbldct"
        Me.lbldct.Size = New System.Drawing.Size(32, 13)
        Me.lbldct.TabIndex = 9
        Me.lbldct.Text = "lbldct"
        Me.lbldct.Visible = False
        '
        'lblrut
        '
        Me.lblrut.AutoSize = True
        Me.lblrut.Location = New System.Drawing.Point(91, 213)
        Me.lblrut.Name = "lblrut"
        Me.lblrut.Size = New System.Drawing.Size(29, 13)
        Me.lblrut.TabIndex = 10
        Me.lblrut.Text = "lblrut"
        Me.lblrut.Visible = False
        '
        'lblcli
        '
        Me.lblcli.AutoSize = True
        Me.lblcli.Location = New System.Drawing.Point(126, 213)
        Me.lblcli.Name = "lblcli"
        Me.lblcli.Size = New System.Drawing.Size(27, 13)
        Me.lblcli.TabIndex = 11
        Me.lblcli.Text = "lblcli"
        Me.lblcli.Visible = False
        '
        'lbldir
        '
        Me.lbldir.AutoSize = True
        Me.lbldir.Location = New System.Drawing.Point(159, 213)
        Me.lbldir.Name = "lbldir"
        Me.lbldir.Size = New System.Drawing.Size(28, 13)
        Me.lbldir.TabIndex = 12
        Me.lbldir.Text = "lbldir"
        Me.lbldir.Visible = False
        '
        'lblcom
        '
        Me.lblcom.AutoSize = True
        Me.lblcom.Location = New System.Drawing.Point(193, 213)
        Me.lblcom.Name = "lblcom"
        Me.lblcom.Size = New System.Drawing.Size(37, 13)
        Me.lblcom.TabIndex = 13
        Me.lblcom.Text = "lblcom"
        Me.lblcom.Visible = False
        '
        'lblciu
        '
        Me.lblciu.AutoSize = True
        Me.lblciu.Location = New System.Drawing.Point(236, 213)
        Me.lblciu.Name = "lblciu"
        Me.lblciu.Size = New System.Drawing.Size(31, 13)
        Me.lblciu.TabIndex = 14
        Me.lblciu.Text = "lblciu"
        Me.lblciu.Visible = False
        '
        'lblreg
        '
        Me.lblreg.AutoSize = True
        Me.lblreg.Location = New System.Drawing.Point(273, 213)
        Me.lblreg.Name = "lblreg"
        Me.lblreg.Size = New System.Drawing.Size(32, 13)
        Me.lblreg.TabIndex = 15
        Me.lblreg.Text = "lblreg"
        Me.lblreg.Visible = False
        '
        'lblloc
        '
        Me.lblloc.AutoSize = True
        Me.lblloc.Location = New System.Drawing.Point(311, 213)
        Me.lblloc.Name = "lblloc"
        Me.lblloc.Size = New System.Drawing.Size(31, 13)
        Me.lblloc.TabIndex = 16
        Me.lblloc.Text = "lblloc"
        Me.lblloc.Visible = False
        '
        'lblsec
        '
        Me.lblsec.AutoSize = True
        Me.lblsec.Location = New System.Drawing.Point(12, 254)
        Me.lblsec.Name = "lblsec"
        Me.lblsec.Size = New System.Drawing.Size(34, 13)
        Me.lblsec.TabIndex = 17
        Me.lblsec.Text = "lblsec"
        Me.lblsec.Visible = False
        '
        'lbldat
        '
        Me.lbldat.AutoSize = True
        Me.lbldat.Location = New System.Drawing.Point(53, 242)
        Me.lbldat.Name = "lbldat"
        Me.lbldat.Size = New System.Drawing.Size(32, 13)
        Me.lbldat.TabIndex = 18
        Me.lbldat.Text = "lbldat"
        Me.lbldat.Visible = False
        '
        'lbltrans
        '
        Me.lbltrans.AutoSize = True
        Me.lbltrans.Location = New System.Drawing.Point(91, 242)
        Me.lbltrans.Name = "lbltrans"
        Me.lbltrans.Size = New System.Drawing.Size(40, 13)
        Me.lbltrans.TabIndex = 19
        Me.lbltrans.Text = "lbltrans"
        Me.lbltrans.Visible = False
        '
        'lblcateti
        '
        Me.lblcateti.AutoSize = True
        Me.lblcateti.Location = New System.Drawing.Point(142, 242)
        Me.lblcateti.Name = "lblcateti"
        Me.lblcateti.Size = New System.Drawing.Size(43, 13)
        Me.lblcateti.TabIndex = 20
        Me.lblcateti.Text = "lblcateti"
        Me.lblcateti.Visible = False
        '
        'lblbod
        '
        Me.lblbod.AutoSize = True
        Me.lblbod.Location = New System.Drawing.Point(191, 242)
        Me.lblbod.Name = "lblbod"
        Me.lblbod.Size = New System.Drawing.Size(35, 13)
        Me.lblbod.TabIndex = 21
        Me.lblbod.Text = "lblbod"
        Me.lblbod.Visible = False
        '
        'lblfec
        '
        Me.lblfec.AutoSize = True
        Me.lblfec.Location = New System.Drawing.Point(232, 242)
        Me.lblfec.Name = "lblfec"
        Me.lblfec.Size = New System.Drawing.Size(32, 13)
        Me.lblfec.TabIndex = 22
        Me.lblfec.Text = "lblfec"
        Me.lblfec.Visible = False
        '
        'lblobs
        '
        Me.lblobs.AutoSize = True
        Me.lblobs.Location = New System.Drawing.Point(270, 242)
        Me.lblobs.Name = "lblobs"
        Me.lblobs.Size = New System.Drawing.Size(34, 13)
        Me.lblobs.TabIndex = 23
        Me.lblobs.Text = "lblobs"
        Me.lblobs.Visible = False
        '
        'lblCalPeso
        '
        Me.lblCalPeso.AutoSize = True
        Me.lblCalPeso.Location = New System.Drawing.Point(314, 242)
        Me.lblCalPeso.Name = "lblCalPeso"
        Me.lblCalPeso.Size = New System.Drawing.Size(56, 13)
        Me.lblCalPeso.TabIndex = 24
        Me.lblCalPeso.Text = "lblCalPeso"
        Me.lblCalPeso.Visible = False
        '
        'lblcont
        '
        Me.lblcont.AutoSize = True
        Me.lblcont.Location = New System.Drawing.Point(12, 277)
        Me.lblcont.Name = "lblcont"
        Me.lblcont.Size = New System.Drawing.Size(38, 13)
        Me.lblcont.TabIndex = 25
        Me.lblcont.Text = "lblcont"
        Me.lblcont.Visible = False
        '
        'lblcantbul
        '
        Me.lblcantbul.AutoSize = True
        Me.lblcantbul.Location = New System.Drawing.Point(9, 320)
        Me.lblcantbul.Name = "lblcantbul"
        Me.lblcantbul.Size = New System.Drawing.Size(52, 13)
        Me.lblcantbul.TabIndex = 26
        Me.lblcantbul.Text = "lblcantbul"
        Me.lblcantbul.Visible = False
        '
        'lblfirst
        '
        Me.lblfirst.AutoSize = True
        Me.lblfirst.Location = New System.Drawing.Point(12, 298)
        Me.lblfirst.Name = "lblfirst"
        Me.lblfirst.Size = New System.Drawing.Size(33, 13)
        Me.lblfirst.TabIndex = 27
        Me.lblfirst.Text = "lblfirst"
        Me.lblfirst.Visible = False
        '
        'lbllast
        '
        Me.lbllast.AutoSize = True
        Me.lbllast.Location = New System.Drawing.Point(291, 265)
        Me.lbllast.Name = "lbllast"
        Me.lbllast.Size = New System.Drawing.Size(33, 13)
        Me.lbllast.TabIndex = 28
        Me.lbllast.Text = "lbllast"
        Me.lbllast.Visible = False
        '
        'lblred
        '
        Me.lblred.AutoSize = True
        Me.lblred.Location = New System.Drawing.Point(314, 303)
        Me.lblred.Name = "lblred"
        Me.lblred.Size = New System.Drawing.Size(32, 13)
        Me.lblred.TabIndex = 29
        Me.lblred.Text = "lblred"
        Me.lblred.Visible = False
        '
        'lblfeclbl
        '
        Me.lblfeclbl.AutoSize = True
        Me.lblfeclbl.Location = New System.Drawing.Point(306, 290)
        Me.lblfeclbl.Name = "lblfeclbl"
        Me.lblfeclbl.Size = New System.Drawing.Size(36, 13)
        Me.lblfeclbl.TabIndex = 30
        Me.lblfeclbl.Text = "fecLbl"
        Me.lblfeclbl.Visible = False
        '
        'SerialPort1
        '
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(15, 375)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(135, 37)
        Me.Button1.TabIndex = 31
        Me.Button1.Text = "Conectar pesa"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(208, 375)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(155, 37)
        Me.Button2.TabIndex = 32
        Me.Button2.Text = "Desconectar Pesa"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'lblfralm
        '
        Me.lblfralm.AutoSize = True
        Me.lblfralm.Location = New System.Drawing.Point(12, 342)
        Me.lblfralm.Name = "lblfralm"
        Me.lblfralm.Size = New System.Drawing.Size(39, 13)
        Me.lblfralm.TabIndex = 33
        Me.lblfralm.Text = "lblfralm"
        Me.lblfralm.Visible = False
        '
        'lbltoalm
        '
        Me.lbltoalm.AutoSize = True
        Me.lbltoalm.Location = New System.Drawing.Point(67, 330)
        Me.lbltoalm.Name = "lbltoalm"
        Me.lbltoalm.Size = New System.Drawing.Size(42, 13)
        Me.lbltoalm.TabIndex = 34
        Me.lbltoalm.Text = "lbltoalm"
        Me.lbltoalm.Visible = False
        '
        'lblpos
        '
        Me.lblpos.AutoSize = True
        Me.lblpos.Location = New System.Drawing.Point(126, 330)
        Me.lblpos.Name = "lblpos"
        Me.lblpos.Size = New System.Drawing.Size(34, 13)
        Me.lblpos.TabIndex = 35
        Me.lblpos.Text = "lblpos"
        Me.lblpos.Visible = False
        '
        'FormPesoEtiqueta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.NavajoWhite
        Me.ClientSize = New System.Drawing.Size(375, 420)
        Me.Controls.Add(Me.lblpos)
        Me.Controls.Add(Me.lbltoalm)
        Me.Controls.Add(Me.lblfralm)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lblfeclbl)
        Me.Controls.Add(Me.lblred)
        Me.Controls.Add(Me.lbllast)
        Me.Controls.Add(Me.lblfirst)
        Me.Controls.Add(Me.lblcantbul)
        Me.Controls.Add(Me.lblcont)
        Me.Controls.Add(Me.lblCalPeso)
        Me.Controls.Add(Me.lblobs)
        Me.Controls.Add(Me.lblfec)
        Me.Controls.Add(Me.lblbod)
        Me.Controls.Add(Me.lblcateti)
        Me.Controls.Add(Me.lbltrans)
        Me.Controls.Add(Me.lbldat)
        Me.Controls.Add(Me.lblsec)
        Me.Controls.Add(Me.lblloc)
        Me.Controls.Add(Me.lblreg)
        Me.Controls.Add(Me.lblciu)
        Me.Controls.Add(Me.lblcom)
        Me.Controls.Add(Me.lbldir)
        Me.Controls.Add(Me.lblcli)
        Me.Controls.Add(Me.lblrut)
        Me.Controls.Add(Me.lbldct)
        Me.Controls.Add(Me.lblpck)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.txbPeso)
        Me.Controls.Add(Me.lblPeso)
        Me.Controls.Add(Me.lblb)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lbla)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormPesoEtiqueta"
        Me.Text = "Captura de peso"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbla As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblb As System.Windows.Forms.Label
    Friend WithEvents lblPeso As System.Windows.Forms.Label
    Friend WithEvents txbPeso As System.Windows.Forms.TextBox
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents lblpck As System.Windows.Forms.Label
    Friend WithEvents lbldct As System.Windows.Forms.Label
    Friend WithEvents lblrut As System.Windows.Forms.Label
    Friend WithEvents lblcli As System.Windows.Forms.Label
    Friend WithEvents lbldir As System.Windows.Forms.Label
    Friend WithEvents lblcom As System.Windows.Forms.Label
    Friend WithEvents lblciu As System.Windows.Forms.Label
    Friend WithEvents lblreg As System.Windows.Forms.Label
    Friend WithEvents lblloc As System.Windows.Forms.Label
    Friend WithEvents lblsec As System.Windows.Forms.Label
    Friend WithEvents lbldat As System.Windows.Forms.Label
    Friend WithEvents lbltrans As System.Windows.Forms.Label
    Friend WithEvents lblcateti As System.Windows.Forms.Label
    Friend WithEvents lblbod As System.Windows.Forms.Label
    Friend WithEvents lblfec As System.Windows.Forms.Label
    Friend WithEvents lblobs As System.Windows.Forms.Label
    Friend WithEvents lblCalPeso As System.Windows.Forms.Label
    Friend WithEvents lblcont As System.Windows.Forms.Label
    Friend WithEvents lblcantbul As System.Windows.Forms.Label
    Friend WithEvents lblfirst As System.Windows.Forms.Label
    Friend WithEvents lbllast As System.Windows.Forms.Label
    Friend WithEvents lblred As System.Windows.Forms.Label
    Friend WithEvents lblfeclbl As System.Windows.Forms.Label
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents lblfralm As System.Windows.Forms.Label
    Friend WithEvents lbltoalm As System.Windows.Forms.Label
    Friend WithEvents lblpos As System.Windows.Forms.Label
End Class
