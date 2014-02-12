<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class form_home
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Panel_User = New System.Windows.Forms.Panel()
        Me.btn_loadreport_user = New System.Windows.Forms.Button()
        Me.btn_loadbring_user = New System.Windows.Forms.Button()
        Me.btn_loadmain_user = New System.Windows.Forms.Button()
        Me.btn_logout_user = New System.Windows.Forms.Button()
        Me.btn_loadinout_user = New System.Windows.Forms.Button()
        Me.btn_loadservice_user = New System.Windows.Forms.Button()
        Me.btn_loadrecieve_user = New System.Windows.Forms.Button()
        Me.panel_Admin = New System.Windows.Forms.Panel()
        Me.btn_loadreport = New System.Windows.Forms.Button()
        Me.btn_loadbring = New System.Windows.Forms.Button()
        Me.btn_logout = New System.Windows.Forms.Button()
        Me.btn_loadgeneral = New System.Windows.Forms.Button()
        Me.btn_loadmain = New System.Windows.Forms.Button()
        Me.btn_loadinout = New System.Windows.Forms.Button()
        Me.btn_loadservice = New System.Windows.Forms.Button()
        Me.btn_loadrecieve = New System.Windows.Forms.Button()
        Me.btn_loadorder = New System.Windows.Forms.Button()
        Me.lbl_welcome = New System.Windows.Forms.Label()
        Me.grp_product = New System.Windows.Forms.GroupBox()
        Me.grid_alertproduct = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel_User.SuspendLayout()
        Me.panel_Admin.SuspendLayout()
        Me.grp_product.SuspendLayout()
        CType(Me.grid_alertproduct, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.Color.Transparent
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 107)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel_User)
        Me.SplitContainer1.Panel1.Controls.Add(Me.panel_Admin)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lbl_welcome)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.SplitContainer1.Panel2.Controls.Add(Me.grp_product)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel2.Font = New System.Drawing.Font("Angsana New", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.SplitContainer1.Panel2.ForeColor = System.Drawing.Color.Red
        Me.SplitContainer1.Size = New System.Drawing.Size(1008, 555)
        Me.SplitContainer1.SplitterDistance = 353
        Me.SplitContainer1.TabIndex = 0
        '
        'Panel_User
        '
        Me.Panel_User.Controls.Add(Me.btn_loadreport_user)
        Me.Panel_User.Controls.Add(Me.btn_loadbring_user)
        Me.Panel_User.Controls.Add(Me.btn_loadmain_user)
        Me.Panel_User.Controls.Add(Me.btn_logout_user)
        Me.Panel_User.Controls.Add(Me.btn_loadinout_user)
        Me.Panel_User.Controls.Add(Me.btn_loadservice_user)
        Me.Panel_User.Controls.Add(Me.btn_loadrecieve_user)
        Me.Panel_User.Location = New System.Drawing.Point(11, 78)
        Me.Panel_User.Name = "Panel_User"
        Me.Panel_User.Size = New System.Drawing.Size(327, 331)
        Me.Panel_User.TabIndex = 9
        Me.Panel_User.Visible = False
        '
        'btn_loadreport_user
        '
        Me.btn_loadreport_user.Location = New System.Drawing.Point(13, 238)
        Me.btn_loadreport_user.Name = "btn_loadreport_user"
        Me.btn_loadreport_user.Size = New System.Drawing.Size(313, 39)
        Me.btn_loadreport_user.TabIndex = 10
        Me.btn_loadreport_user.Text = "ออกรายงาน"
        Me.btn_loadreport_user.UseVisualStyleBackColor = True
        '
        'btn_loadbring_user
        '
        Me.btn_loadbring_user.Location = New System.Drawing.Point(13, 147)
        Me.btn_loadbring_user.Name = "btn_loadbring_user"
        Me.btn_loadbring_user.Size = New System.Drawing.Size(313, 39)
        Me.btn_loadbring_user.TabIndex = 9
        Me.btn_loadbring_user.Text = "การเบิกผลิตภัณฑ์"
        Me.btn_loadbring_user.UseVisualStyleBackColor = True
        '
        'btn_loadmain_user
        '
        Me.btn_loadmain_user.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btn_loadmain_user.BackgroundImage = Global.aispa.My.Resources.Resources._2
        Me.btn_loadmain_user.Location = New System.Drawing.Point(8, 9)
        Me.btn_loadmain_user.Name = "btn_loadmain_user"
        Me.btn_loadmain_user.Size = New System.Drawing.Size(313, 40)
        Me.btn_loadmain_user.TabIndex = 8
        Me.btn_loadmain_user.UseVisualStyleBackColor = False
        '
        'btn_logout_user
        '
        Me.btn_logout_user.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btn_logout_user.BackgroundImage = Global.aispa.My.Resources.Resources._7
        Me.btn_logout_user.Location = New System.Drawing.Point(11, 284)
        Me.btn_logout_user.Name = "btn_logout_user"
        Me.btn_logout_user.Size = New System.Drawing.Size(313, 40)
        Me.btn_logout_user.TabIndex = 7
        Me.btn_logout_user.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btn_logout_user.UseVisualStyleBackColor = False
        '
        'btn_loadinout_user
        '
        Me.btn_loadinout_user.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btn_loadinout_user.BackgroundImage = Global.aispa.My.Resources.Resources._ุ6
        Me.btn_loadinout_user.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_loadinout_user.Location = New System.Drawing.Point(11, 192)
        Me.btn_loadinout_user.Name = "btn_loadinout_user"
        Me.btn_loadinout_user.Size = New System.Drawing.Size(313, 40)
        Me.btn_loadinout_user.TabIndex = 5
        Me.btn_loadinout_user.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btn_loadinout_user.UseVisualStyleBackColor = False
        '
        'btn_loadservice_user
        '
        Me.btn_loadservice_user.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btn_loadservice_user.BackgroundImage = Global.aispa.My.Resources.Resources._3
        Me.btn_loadservice_user.Location = New System.Drawing.Point(11, 55)
        Me.btn_loadservice_user.Name = "btn_loadservice_user"
        Me.btn_loadservice_user.Size = New System.Drawing.Size(313, 40)
        Me.btn_loadservice_user.TabIndex = 2
        Me.btn_loadservice_user.UseVisualStyleBackColor = False
        '
        'btn_loadrecieve_user
        '
        Me.btn_loadrecieve_user.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btn_loadrecieve_user.BackgroundImage = Global.aispa.My.Resources.Resources._5
        Me.btn_loadrecieve_user.Location = New System.Drawing.Point(11, 101)
        Me.btn_loadrecieve_user.Name = "btn_loadrecieve_user"
        Me.btn_loadrecieve_user.Size = New System.Drawing.Size(313, 40)
        Me.btn_loadrecieve_user.TabIndex = 4
        Me.btn_loadrecieve_user.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btn_loadrecieve_user.UseVisualStyleBackColor = False
        '
        'panel_Admin
        '
        Me.panel_Admin.Controls.Add(Me.btn_loadreport)
        Me.panel_Admin.Controls.Add(Me.btn_loadbring)
        Me.panel_Admin.Controls.Add(Me.btn_logout)
        Me.panel_Admin.Controls.Add(Me.btn_loadgeneral)
        Me.panel_Admin.Controls.Add(Me.btn_loadmain)
        Me.panel_Admin.Controls.Add(Me.btn_loadinout)
        Me.panel_Admin.Controls.Add(Me.btn_loadservice)
        Me.panel_Admin.Controls.Add(Me.btn_loadrecieve)
        Me.panel_Admin.Controls.Add(Me.btn_loadorder)
        Me.panel_Admin.Location = New System.Drawing.Point(11, 88)
        Me.panel_Admin.Name = "panel_Admin"
        Me.panel_Admin.Size = New System.Drawing.Size(327, 423)
        Me.panel_Admin.TabIndex = 8
        Me.panel_Admin.Visible = False
        '
        'btn_loadreport
        '
        Me.btn_loadreport.Location = New System.Drawing.Point(8, 327)
        Me.btn_loadreport.Name = "btn_loadreport"
        Me.btn_loadreport.Size = New System.Drawing.Size(313, 39)
        Me.btn_loadreport.TabIndex = 9
        Me.btn_loadreport.Text = "ออกรายงาน"
        Me.btn_loadreport.UseVisualStyleBackColor = True
        '
        'btn_loadbring
        '
        Me.btn_loadbring.Location = New System.Drawing.Point(8, 146)
        Me.btn_loadbring.Name = "btn_loadbring"
        Me.btn_loadbring.Size = New System.Drawing.Size(313, 39)
        Me.btn_loadbring.TabIndex = 8
        Me.btn_loadbring.Text = "การเบิกผลิตภัณฑ์"
        Me.btn_loadbring.UseVisualStyleBackColor = True
        '
        'btn_logout
        '
        Me.btn_logout.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btn_logout.BackgroundImage = Global.aispa.My.Resources.Resources._7
        Me.btn_logout.Location = New System.Drawing.Point(8, 372)
        Me.btn_logout.Name = "btn_logout"
        Me.btn_logout.Size = New System.Drawing.Size(313, 40)
        Me.btn_logout.TabIndex = 7
        Me.btn_logout.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btn_logout.UseVisualStyleBackColor = False
        '
        'btn_loadgeneral
        '
        Me.btn_loadgeneral.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btn_loadgeneral.BackgroundImage = Global.aispa.My.Resources.Resources._1
        Me.btn_loadgeneral.Location = New System.Drawing.Point(8, 8)
        Me.btn_loadgeneral.Name = "btn_loadgeneral"
        Me.btn_loadgeneral.Size = New System.Drawing.Size(313, 40)
        Me.btn_loadgeneral.TabIndex = 0
        Me.btn_loadgeneral.UseVisualStyleBackColor = False
        '
        'btn_loadmain
        '
        Me.btn_loadmain.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btn_loadmain.BackgroundImage = Global.aispa.My.Resources.Resources._2
        Me.btn_loadmain.Location = New System.Drawing.Point(8, 54)
        Me.btn_loadmain.Name = "btn_loadmain"
        Me.btn_loadmain.Size = New System.Drawing.Size(313, 40)
        Me.btn_loadmain.TabIndex = 1
        Me.btn_loadmain.UseVisualStyleBackColor = False
        '
        'btn_loadinout
        '
        Me.btn_loadinout.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btn_loadinout.BackgroundImage = Global.aispa.My.Resources.Resources._ุ6
        Me.btn_loadinout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_loadinout.Location = New System.Drawing.Point(8, 281)
        Me.btn_loadinout.Name = "btn_loadinout"
        Me.btn_loadinout.Size = New System.Drawing.Size(313, 40)
        Me.btn_loadinout.TabIndex = 5
        Me.btn_loadinout.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btn_loadinout.UseVisualStyleBackColor = False
        '
        'btn_loadservice
        '
        Me.btn_loadservice.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btn_loadservice.BackgroundImage = Global.aispa.My.Resources.Resources._3
        Me.btn_loadservice.Location = New System.Drawing.Point(8, 100)
        Me.btn_loadservice.Name = "btn_loadservice"
        Me.btn_loadservice.Size = New System.Drawing.Size(313, 40)
        Me.btn_loadservice.TabIndex = 2
        Me.btn_loadservice.UseVisualStyleBackColor = False
        '
        'btn_loadrecieve
        '
        Me.btn_loadrecieve.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btn_loadrecieve.BackgroundImage = Global.aispa.My.Resources.Resources._5
        Me.btn_loadrecieve.Location = New System.Drawing.Point(8, 235)
        Me.btn_loadrecieve.Name = "btn_loadrecieve"
        Me.btn_loadrecieve.Size = New System.Drawing.Size(313, 40)
        Me.btn_loadrecieve.TabIndex = 4
        Me.btn_loadrecieve.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btn_loadrecieve.UseVisualStyleBackColor = False
        '
        'btn_loadorder
        '
        Me.btn_loadorder.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btn_loadorder.BackgroundImage = Global.aispa.My.Resources.Resources._4
        Me.btn_loadorder.Location = New System.Drawing.Point(8, 189)
        Me.btn_loadorder.Name = "btn_loadorder"
        Me.btn_loadorder.Size = New System.Drawing.Size(313, 40)
        Me.btn_loadorder.TabIndex = 3
        Me.btn_loadorder.UseVisualStyleBackColor = False
        '
        'lbl_welcome
        '
        Me.lbl_welcome.AutoSize = True
        Me.lbl_welcome.Location = New System.Drawing.Point(11, 20)
        Me.lbl_welcome.Name = "lbl_welcome"
        Me.lbl_welcome.Size = New System.Drawing.Size(0, 29)
        Me.lbl_welcome.TabIndex = 6
        '
        'grp_product
        '
        Me.grp_product.Controls.Add(Me.grid_alertproduct)
        Me.grp_product.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.grp_product.Location = New System.Drawing.Point(43, 67)
        Me.grp_product.Name = "grp_product"
        Me.grp_product.Size = New System.Drawing.Size(572, 206)
        Me.grp_product.TabIndex = 2
        Me.grp_product.TabStop = False
        Me.grp_product.Text = "แจ้งเตือนผลิตภัณฑ์ใกล้หมด"
        Me.grp_product.Visible = False
        '
        'grid_alertproduct
        '
        Me.grid_alertproduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_alertproduct.Location = New System.Drawing.Point(7, 29)
        Me.grid_alertproduct.Name = "grid_alertproduct"
        Me.grid_alertproduct.Size = New System.Drawing.Size(559, 171)
        Me.grid_alertproduct.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Angsana New", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(173, 413)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(465, 132)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "จัดทำโดย" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "นางสาวกนกนันท์   ด้วงทิม" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "นางสาวปวีณา       ประชุมมาก" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "มหาวิทยาลัยเทคโน" & _
            "โลยีพระจอมเกล้าพระนครเหนือวิทยาเขตปราจีนบุรี" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'form_home
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 29.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.aispa.My.Resources.Resources.home3
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1008, 662)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Font = New System.Drawing.Font("Angsana New", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 7, 4, 7)
        Me.Name = "form_home"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "หน้าหลัก"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel_User.ResumeLayout(False)
        Me.panel_Admin.ResumeLayout(False)
        Me.grp_product.ResumeLayout(False)
        CType(Me.grid_alertproduct, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents btn_loadrecieve As System.Windows.Forms.Button
    Friend WithEvents btn_loadorder As System.Windows.Forms.Button
    Friend WithEvents btn_loadservice As System.Windows.Forms.Button
    Friend WithEvents btn_loadgeneral As System.Windows.Forms.Button
    Friend WithEvents btn_loadinout As System.Windows.Forms.Button
    Friend WithEvents lbl_welcome As System.Windows.Forms.Label
    Friend WithEvents btn_logout As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents panel_Admin As System.Windows.Forms.Panel
    Friend WithEvents Panel_User As System.Windows.Forms.Panel
    Friend WithEvents btn_logout_user As System.Windows.Forms.Button
    Friend WithEvents btn_loadinout_user As System.Windows.Forms.Button
    Friend WithEvents btn_loadservice_user As System.Windows.Forms.Button
    Friend WithEvents btn_loadrecieve_user As System.Windows.Forms.Button
    Friend WithEvents btn_loadmain As System.Windows.Forms.Button
    Friend WithEvents btn_loadmain_user As System.Windows.Forms.Button
    Friend WithEvents btn_loadbring As System.Windows.Forms.Button
    Friend WithEvents btn_loadbring_user As System.Windows.Forms.Button
    Friend WithEvents grp_product As System.Windows.Forms.GroupBox
    Friend WithEvents grid_alertproduct As System.Windows.Forms.DataGridView
    Friend WithEvents btn_loadreport_user As System.Windows.Forms.Button
    Friend WithEvents btn_loadreport As System.Windows.Forms.Button
End Class
