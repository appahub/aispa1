<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class form_report
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtp_startdate = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtp_enddate = New System.Windows.Forms.DateTimePicker()
        Me.label3 = New System.Windows.Forms.Label()
        Me.btn_reportcustomer = New System.Windows.Forms.Button()
        Me.btn_reportemployee = New System.Windows.Forms.Button()
        Me.btn_reportproductleft = New System.Windows.Forms.Button()
        Me.btn_reportproductorder = New System.Windows.Forms.Button()
        Me.btn_reportproductpick = New System.Windows.Forms.Button()
        Me.btn_cus_serv = New System.Windows.Forms.Button()
        Me.btn_emp_serv = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.Location = New System.Drawing.Point(24, 84)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(133, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ช่วงเวลาในการค้นหา"
        '
        'dtp_startdate
        '
        Me.dtp_startdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.dtp_startdate.Location = New System.Drawing.Point(163, 78)
        Me.dtp_startdate.Name = "dtp_startdate"
        Me.dtp_startdate.Size = New System.Drawing.Size(178, 26)
        Me.dtp_startdate.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.Location = New System.Drawing.Point(361, 82)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(25, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "ถึง"
        '
        'dtp_enddate
        '
        Me.dtp_enddate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.dtp_enddate.Location = New System.Drawing.Point(402, 77)
        Me.dtp_enddate.Name = "dtp_enddate"
        Me.dtp_enddate.Size = New System.Drawing.Size(178, 26)
        Me.dtp_enddate.TabIndex = 3
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.label3.Location = New System.Drawing.Point(243, 22)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(143, 31)
        Me.label3.TabIndex = 4
        Me.label3.Text = "ออกรายงาน"
        '
        'btn_reportcustomer
        '
        Me.btn_reportcustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_reportcustomer.Location = New System.Drawing.Point(28, 130)
        Me.btn_reportcustomer.Name = "btn_reportcustomer"
        Me.btn_reportcustomer.Size = New System.Drawing.Size(260, 41)
        Me.btn_reportcustomer.TabIndex = 5
        Me.btn_reportcustomer.Text = "รายงานลูกค้า"
        Me.btn_reportcustomer.UseVisualStyleBackColor = True
        '
        'btn_reportemployee
        '
        Me.btn_reportemployee.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_reportemployee.Location = New System.Drawing.Point(28, 180)
        Me.btn_reportemployee.Name = "btn_reportemployee"
        Me.btn_reportemployee.Size = New System.Drawing.Size(260, 41)
        Me.btn_reportemployee.TabIndex = 6
        Me.btn_reportemployee.Text = "รายงานพนักงาน"
        Me.btn_reportemployee.UseVisualStyleBackColor = True
        '
        'btn_reportproductleft
        '
        Me.btn_reportproductleft.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_reportproductleft.Location = New System.Drawing.Point(28, 230)
        Me.btn_reportproductleft.Name = "btn_reportproductleft"
        Me.btn_reportproductleft.Size = New System.Drawing.Size(260, 41)
        Me.btn_reportproductleft.TabIndex = 7
        Me.btn_reportproductleft.Text = "รายงานผลิตภัณฑ์คงเหลือ"
        Me.btn_reportproductleft.UseVisualStyleBackColor = True
        '
        'btn_reportproductorder
        '
        Me.btn_reportproductorder.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_reportproductorder.Location = New System.Drawing.Point(28, 276)
        Me.btn_reportproductorder.Name = "btn_reportproductorder"
        Me.btn_reportproductorder.Size = New System.Drawing.Size(260, 41)
        Me.btn_reportproductorder.TabIndex = 8
        Me.btn_reportproductorder.Text = "รายงานสั่งซื้อผลิตภัณฑ์"
        Me.btn_reportproductorder.UseVisualStyleBackColor = True
        '
        'btn_reportproductpick
        '
        Me.btn_reportproductpick.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_reportproductpick.Location = New System.Drawing.Point(28, 319)
        Me.btn_reportproductpick.Name = "btn_reportproductpick"
        Me.btn_reportproductpick.Size = New System.Drawing.Size(260, 41)
        Me.btn_reportproductpick.TabIndex = 9
        Me.btn_reportproductpick.Text = "รายงานเบิกผลิตภัณฑ์"
        Me.btn_reportproductpick.UseVisualStyleBackColor = True
        '
        'btn_cus_serv
        '
        Me.btn_cus_serv.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_cus_serv.Location = New System.Drawing.Point(344, 130)
        Me.btn_cus_serv.Name = "btn_cus_serv"
        Me.btn_cus_serv.Size = New System.Drawing.Size(260, 41)
        Me.btn_cus_serv.TabIndex = 10
        Me.btn_cus_serv.Text = "รายงานลูกค้าที่ใช้บริการ"
        Me.btn_cus_serv.UseVisualStyleBackColor = True
        '
        'btn_emp_serv
        '
        Me.btn_emp_serv.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_emp_serv.Location = New System.Drawing.Point(344, 180)
        Me.btn_emp_serv.Name = "btn_emp_serv"
        Me.btn_emp_serv.Size = New System.Drawing.Size(260, 41)
        Me.btn_emp_serv.TabIndex = 11
        Me.btn_emp_serv.Text = "รายงานพนักงานที่ให้บริการ"
        Me.btn_emp_serv.UseVisualStyleBackColor = True
        '
        'form_report
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(634, 376)
        Me.Controls.Add(Me.btn_emp_serv)
        Me.Controls.Add(Me.btn_cus_serv)
        Me.Controls.Add(Me.btn_reportproductpick)
        Me.Controls.Add(Me.btn_reportproductorder)
        Me.Controls.Add(Me.btn_reportproductleft)
        Me.Controls.Add(Me.btn_reportemployee)
        Me.Controls.Add(Me.btn_reportcustomer)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.dtp_enddate)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtp_startdate)
        Me.Controls.Add(Me.Label1)
        Me.Name = "form_report"
        Me.Text = "form_report"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtp_startdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtp_enddate As System.Windows.Forms.DateTimePicker
    Friend WithEvents label3 As System.Windows.Forms.Label
    Friend WithEvents btn_reportcustomer As System.Windows.Forms.Button
    Friend WithEvents btn_reportemployee As System.Windows.Forms.Button
    Friend WithEvents btn_reportproductleft As System.Windows.Forms.Button
    Friend WithEvents btn_reportproductorder As System.Windows.Forms.Button
    Friend WithEvents btn_reportproductpick As System.Windows.Forms.Button
    Friend WithEvents btn_cus_serv As System.Windows.Forms.Button
    Friend WithEvents btn_emp_serv As System.Windows.Forms.Button
End Class
