<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Lblgab = New System.Windows.Forms.Label
        Me.cmbEmpleado = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblPos = New System.Windows.Forms.Label
        Me.lblDataarea = New System.Windows.Forms.Label
        Me.lblFecha = New System.Windows.Forms.Label
        Me.lblHora = New System.Windows.Forms.Label
        Me.cmbBodega = New System.Windows.Forms.ComboBox
        Me.cmbEmpresa = New System.Windows.Forms.ComboBox
        Me.lblbodega = New System.Windows.Forms.Label
        Me.lblEmpresa = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label3 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.txbCantEtiquetas = New System.Windows.Forms.TextBox
        Me.lblCantEtiq = New System.Windows.Forms.Label
        Me.cmbTransporte = New System.Windows.Forms.ComboBox
        Me.txbObservacion = New System.Windows.Forms.TextBox
        Me.txbPicking = New System.Windows.Forms.TextBox
        Me.lblOvservacion = New System.Windows.Forms.Label
        Me.lblTransportista = New System.Windows.Forms.Label
        Me.lblPicking = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Button3 = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.NavajoWhite
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.Lblgab)
        Me.Panel1.Controls.Add(Me.cmbEmpleado)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.ComboBox1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.lblPos)
        Me.Panel1.Controls.Add(Me.lblDataarea)
        Me.Panel1.Controls.Add(Me.lblFecha)
        Me.Panel1.Controls.Add(Me.lblHora)
        Me.Panel1.Controls.Add(Me.cmbBodega)
        Me.Panel1.Controls.Add(Me.cmbEmpresa)
        Me.Panel1.Controls.Add(Me.lblbodega)
        Me.Panel1.Controls.Add(Me.lblEmpresa)
        Me.Panel1.Location = New System.Drawing.Point(0, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(705, 175)
        Me.Panel1.TabIndex = 0
        '
        'Lblgab
        '
        Me.Lblgab.AutoSize = True
        Me.Lblgab.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblgab.Location = New System.Drawing.Point(367, 14)
        Me.Lblgab.Name = "Lblgab"
        Me.Lblgab.Size = New System.Drawing.Size(28, 15)
        Me.Lblgab.TabIndex = 13
        Me.Lblgab.Text = "gab"
        Me.Lblgab.Visible = False
        '
        'cmbEmpleado
        '
        Me.cmbEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEmpleado.FormattingEnabled = True
        Me.cmbEmpleado.Location = New System.Drawing.Point(116, 141)
        Me.cmbEmpleado.Name = "cmbEmpleado"
        Me.cmbEmpleado.Size = New System.Drawing.Size(230, 24)
        Me.cmbEmpleado.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 141)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 20)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Usuario"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(438, 46)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(254, 37)
        Me.Button2.TabIndex = 10
        Me.Button2.Text = "Re-Impresión Etiqueta"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(118, 5)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(118, 24)
        Me.ComboBox1.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 17)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "PuertoComm"
        '
        'lblPos
        '
        Me.lblPos.AutoSize = True
        Me.lblPos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPos.Location = New System.Drawing.Point(367, 106)
        Me.lblPos.Name = "lblPos"
        Me.lblPos.Size = New System.Drawing.Size(28, 15)
        Me.lblPos.TabIndex = 7
        Me.lblPos.Text = "Pos"
        Me.lblPos.Visible = False
        '
        'lblDataarea
        '
        Me.lblDataarea.AutoSize = True
        Me.lblDataarea.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDataarea.Location = New System.Drawing.Point(367, 56)
        Me.lblDataarea.Name = "lblDataarea"
        Me.lblDataarea.Size = New System.Drawing.Size(56, 15)
        Me.lblDataarea.TabIndex = 6
        Me.lblDataarea.Text = "dataarea"
        Me.lblDataarea.Visible = False
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecha.Location = New System.Drawing.Point(593, 8)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(52, 17)
        Me.lblFecha.TabIndex = 5
        Me.lblFecha.Text = "Fecha"
        '
        'lblHora
        '
        Me.lblHora.AutoSize = True
        Me.lblHora.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHora.Location = New System.Drawing.Point(512, 8)
        Me.lblHora.Name = "lblHora"
        Me.lblHora.Size = New System.Drawing.Size(43, 17)
        Me.lblHora.TabIndex = 4
        Me.lblHora.Text = "Hora"
        '
        'cmbBodega
        '
        Me.cmbBodega.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBodega.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBodega.FormattingEnabled = True
        Me.cmbBodega.Location = New System.Drawing.Point(116, 98)
        Me.cmbBodega.Name = "cmbBodega"
        Me.cmbBodega.Size = New System.Drawing.Size(230, 24)
        Me.cmbBodega.TabIndex = 3
        '
        'cmbEmpresa
        '
        Me.cmbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEmpresa.FormattingEnabled = True
        Me.cmbEmpresa.Location = New System.Drawing.Point(116, 50)
        Me.cmbEmpresa.Name = "cmbEmpresa"
        Me.cmbEmpresa.Size = New System.Drawing.Size(230, 24)
        Me.cmbEmpresa.TabIndex = 2
        '
        'lblbodega
        '
        Me.lblbodega.AutoSize = True
        Me.lblbodega.Location = New System.Drawing.Point(14, 102)
        Me.lblbodega.Name = "lblbodega"
        Me.lblbodega.Size = New System.Drawing.Size(71, 20)
        Me.lblbodega.TabIndex = 1
        Me.lblbodega.Text = "Bodega"
        '
        'lblEmpresa
        '
        Me.lblEmpresa.AutoSize = True
        Me.lblEmpresa.Location = New System.Drawing.Point(14, 54)
        Me.lblEmpresa.Name = "lblEmpresa"
        Me.lblEmpresa.Size = New System.Drawing.Size(80, 20)
        Me.lblEmpresa.TabIndex = 0
        Me.lblEmpresa.Text = "Empresa"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.OldLace
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.txbCantEtiquetas)
        Me.Panel2.Controls.Add(Me.lblCantEtiq)
        Me.Panel2.Controls.Add(Me.cmbTransporte)
        Me.Panel2.Controls.Add(Me.txbObservacion)
        Me.Panel2.Controls.Add(Me.txbPicking)
        Me.Panel2.Controls.Add(Me.lblOvservacion)
        Me.Panel2.Controls.Add(Me.lblTransportista)
        Me.Panel2.Controls.Add(Me.lblPicking)
        Me.Panel2.Location = New System.Drawing.Point(0, 172)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(704, 384)
        Me.Panel2.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 392)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(121, 20)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "pickingrouteid"
        Me.Label3.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(232, 285)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(232, 62)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "IMPRIMIR ETIQUETA"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txbCantEtiquetas
        '
        Me.txbCantEtiquetas.Location = New System.Drawing.Point(573, 42)
        Me.txbCantEtiquetas.Name = "txbCantEtiquetas"
        Me.txbCantEtiquetas.Size = New System.Drawing.Size(72, 26)
        Me.txbCantEtiquetas.TabIndex = 5
        '
        'lblCantEtiq
        '
        Me.lblCantEtiq.AutoSize = True
        Me.lblCantEtiq.Location = New System.Drawing.Point(434, 45)
        Me.lblCantEtiq.Name = "lblCantEtiq"
        Me.lblCantEtiq.Size = New System.Drawing.Size(109, 20)
        Me.lblCantEtiq.TabIndex = 7
        Me.lblCantEtiq.Text = "N° Etqiuetas"
        '
        'cmbTransporte
        '
        Me.cmbTransporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTransporte.FormattingEnabled = True
        Me.cmbTransporte.Location = New System.Drawing.Point(140, 111)
        Me.cmbTransporte.Name = "cmbTransporte"
        Me.cmbTransporte.Size = New System.Drawing.Size(213, 24)
        Me.cmbTransporte.TabIndex = 6
        '
        'txbObservacion
        '
        Me.txbObservacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txbObservacion.Location = New System.Drawing.Point(140, 186)
        Me.txbObservacion.MaxLength = 100
        Me.txbObservacion.Multiline = True
        Me.txbObservacion.Name = "txbObservacion"
        Me.txbObservacion.Size = New System.Drawing.Size(389, 50)
        Me.txbObservacion.TabIndex = 7
        '
        'txbPicking
        '
        Me.txbPicking.Location = New System.Drawing.Point(140, 39)
        Me.txbPicking.Name = "txbPicking"
        Me.txbPicking.Size = New System.Drawing.Size(213, 26)
        Me.txbPicking.TabIndex = 4
        '
        'lblOvservacion
        '
        Me.lblOvservacion.AutoSize = True
        Me.lblOvservacion.Location = New System.Drawing.Point(19, 192)
        Me.lblOvservacion.Name = "lblOvservacion"
        Me.lblOvservacion.Size = New System.Drawing.Size(108, 20)
        Me.lblOvservacion.TabIndex = 3
        Me.lblOvservacion.Text = "Observacion"
        '
        'lblTransportista
        '
        Me.lblTransportista.AutoSize = True
        Me.lblTransportista.Location = New System.Drawing.Point(19, 119)
        Me.lblTransportista.Name = "lblTransportista"
        Me.lblTransportista.Size = New System.Drawing.Size(115, 20)
        Me.lblTransportista.TabIndex = 2
        Me.lblTransportista.Text = "Transportista"
        '
        'lblPicking
        '
        Me.lblPicking.AutoSize = True
        Me.lblPicking.Location = New System.Drawing.Point(19, 42)
        Me.lblPicking.Name = "lblPicking"
        Me.lblPicking.Size = New System.Drawing.Size(66, 20)
        Me.lblPicking.TabIndex = 1
        Me.lblPicking.Text = "Picking"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(438, 115)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(254, 33)
        Me.Button3.TabIndex = 14
        Me.Button3.Text = "Etiqueta Carrier Ext."
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(704, 555)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "Form1"
        Me.Text = "  EMISOR ETIQUETAS"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblHora As System.Windows.Forms.Label
    Friend WithEvents cmbBodega As System.Windows.Forms.ComboBox
    Friend WithEvents cmbEmpresa As System.Windows.Forms.ComboBox
    Friend WithEvents lblbodega As System.Windows.Forms.Label
    Friend WithEvents lblEmpresa As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents cmbTransporte As System.Windows.Forms.ComboBox
    Friend WithEvents txbObservacion As System.Windows.Forms.TextBox
    Friend WithEvents txbPicking As System.Windows.Forms.TextBox
    Friend WithEvents lblOvservacion As System.Windows.Forms.Label
    Friend WithEvents lblTransportista As System.Windows.Forms.Label
    Friend WithEvents lblPicking As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txbCantEtiquetas As System.Windows.Forms.TextBox
    Friend WithEvents lblCantEtiq As System.Windows.Forms.Label
    Friend WithEvents lblPos As System.Windows.Forms.Label
    Friend WithEvents lblDataarea As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents cmbEmpleado As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Lblgab As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button

End Class
