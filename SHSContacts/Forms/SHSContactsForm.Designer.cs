namespace SHSContacts.Forms
{
    partial class SHSContactsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.lnkReset = new System.Windows.Forms.LinkLabel();
            this.lnkDesc = new System.Windows.Forms.LinkLabel();
            this.lnkUpload = new System.Windows.Forms.LinkLabel();
            this.lnkDownload = new System.Windows.Forms.LinkLabel();
            this.btnPrint = new DevComponents.DotNetBar.ButtonX();
            this.btnExit = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.radiobtnOtherAddress = new System.Windows.Forms.RadioButton();
            this.radiobtnMailingAddress = new System.Windows.Forms.RadioButton();
            this.radiobtnPermanentAddress = new System.Windows.Forms.RadioButton();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.radiobtnMotherName = new System.Windows.Forms.RadioButton();
            this.radiobtnFatherName = new System.Windows.Forms.RadioButton();
            this.radiobtnCustodianName = new System.Windows.Forms.RadioButton();
            this.groupPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.groupPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupPanel1
            // 
            this.groupPanel1.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.lnkReset);
            this.groupPanel1.Controls.Add(this.lnkDesc);
            this.groupPanel1.Controls.Add(this.lnkUpload);
            this.groupPanel1.Controls.Add(this.lnkDownload);
            this.groupPanel1.Location = new System.Drawing.Point(12, 12);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(245, 107);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.Class = "";
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.Class = "";
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.Class = "";
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 3;
            this.groupPanel1.Text = "樣板";
            // 
            // lnkReset
            // 
            this.lnkReset.AutoSize = true;
            this.lnkReset.Location = new System.Drawing.Point(162, 50);
            this.lnkReset.Name = "lnkReset";
            this.lnkReset.Size = new System.Drawing.Size(60, 17);
            this.lnkReset.TabIndex = 3;
            this.lnkReset.TabStop = true;
            this.lnkReset.Text = "復原預設";
            this.lnkReset.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkReset_LinkClicked);
            // 
            // lnkDesc
            // 
            this.lnkDesc.AutoSize = true;
            this.lnkDesc.Location = new System.Drawing.Point(21, 50);
            this.lnkDesc.Name = "lnkDesc";
            this.lnkDesc.Size = new System.Drawing.Size(138, 17);
            this.lnkDesc.TabIndex = 2;
            this.lnkDesc.TabStop = true;
            this.lnkDesc.Text = "樣板可用合併欄位說明";
            this.lnkDesc.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDesc_LinkClicked);
            // 
            // lnkUpload
            // 
            this.lnkUpload.AutoSize = true;
            this.lnkUpload.Location = new System.Drawing.Point(136, 17);
            this.lnkUpload.Name = "lnkUpload";
            this.lnkUpload.Size = new System.Drawing.Size(86, 17);
            this.lnkUpload.TabIndex = 1;
            this.lnkUpload.TabStop = true;
            this.lnkUpload.Text = "上傳自訂樣版";
            this.lnkUpload.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkUpload_LinkClicked);
            // 
            // lnkDownload
            // 
            this.lnkDownload.AutoSize = true;
            this.lnkDownload.Location = new System.Drawing.Point(21, 17);
            this.lnkDownload.Name = "lnkDownload";
            this.lnkDownload.Size = new System.Drawing.Size(86, 17);
            this.lnkDownload.TabIndex = 0;
            this.lnkDownload.TabStop = true;
            this.lnkDownload.Text = "下載目前樣版";
            this.lnkDownload.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDownload_LinkClicked);
            // 
            // btnPrint
            // 
            this.btnPrint.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPrint.BackColor = System.Drawing.Color.Transparent;
            this.btnPrint.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnPrint.Location = new System.Drawing.Point(61, 248);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 25);
            this.btnPrint.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "列印";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnExit
            // 
            this.btnExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExit.Location = new System.Drawing.Point(142, 248);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 25);
            this.btnExit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "離開";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // groupPanel2
            // 
            this.groupPanel2.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.radiobtnOtherAddress);
            this.groupPanel2.Controls.Add(this.radiobtnMailingAddress);
            this.groupPanel2.Controls.Add(this.radiobtnPermanentAddress);
            this.groupPanel2.Location = new System.Drawing.Point(12, 125);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(124, 117);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.Class = "";
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseDown.Class = "";
            this.groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseOver.Class = "";
            this.groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel2.TabIndex = 6;
            this.groupPanel2.Text = "郵寄地址";
            // 
            // radiobtnOtherAddress
            // 
            this.radiobtnOtherAddress.AutoSize = true;
            this.radiobtnOtherAddress.Location = new System.Drawing.Point(10, 59);
            this.radiobtnOtherAddress.Name = "radiobtnOtherAddress";
            this.radiobtnOtherAddress.Size = new System.Drawing.Size(78, 21);
            this.radiobtnOtherAddress.TabIndex = 2;
            this.radiobtnOtherAddress.TabStop = true;
            this.radiobtnOtherAddress.Text = "其它地址";
            this.radiobtnOtherAddress.UseVisualStyleBackColor = true;
            // 
            // radiobtnMailingAddress
            // 
            this.radiobtnMailingAddress.AutoSize = true;
            this.radiobtnMailingAddress.Location = new System.Drawing.Point(10, 31);
            this.radiobtnMailingAddress.Name = "radiobtnMailingAddress";
            this.radiobtnMailingAddress.Size = new System.Drawing.Size(78, 21);
            this.radiobtnMailingAddress.TabIndex = 1;
            this.radiobtnMailingAddress.TabStop = true;
            this.radiobtnMailingAddress.Text = "聯絡地址";
            this.radiobtnMailingAddress.UseVisualStyleBackColor = true;
            // 
            // radiobtnPermanentAddress
            // 
            this.radiobtnPermanentAddress.AutoSize = true;
            this.radiobtnPermanentAddress.Location = new System.Drawing.Point(10, 3);
            this.radiobtnPermanentAddress.Name = "radiobtnPermanentAddress";
            this.radiobtnPermanentAddress.Size = new System.Drawing.Size(78, 21);
            this.radiobtnPermanentAddress.TabIndex = 0;
            this.radiobtnPermanentAddress.TabStop = true;
            this.radiobtnPermanentAddress.Text = "戶籍地址";
            this.radiobtnPermanentAddress.UseVisualStyleBackColor = true;
            // 
            // groupPanel3
            // 
            this.groupPanel3.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.radiobtnMotherName);
            this.groupPanel3.Controls.Add(this.radiobtnFatherName);
            this.groupPanel3.Controls.Add(this.radiobtnCustodianName);
            this.groupPanel3.Location = new System.Drawing.Point(142, 125);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(115, 117);
            // 
            // 
            // 
            this.groupPanel3.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel3.Style.BackColorGradientAngle = 90;
            this.groupPanel3.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderBottomWidth = 1;
            this.groupPanel3.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderLeftWidth = 1;
            this.groupPanel3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderRightWidth = 1;
            this.groupPanel3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderTopWidth = 1;
            this.groupPanel3.Style.Class = "";
            this.groupPanel3.Style.CornerDiameter = 4;
            this.groupPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel3.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel3.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseDown.Class = "";
            this.groupPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseOver.Class = "";
            this.groupPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel3.TabIndex = 7;
            this.groupPanel3.Text = "家長";
            // 
            // radiobtnMotherName
            // 
            this.radiobtnMotherName.AutoSize = true;
            this.radiobtnMotherName.Location = new System.Drawing.Point(7, 58);
            this.radiobtnMotherName.Name = "radiobtnMotherName";
            this.radiobtnMotherName.Size = new System.Drawing.Size(52, 21);
            this.radiobtnMotherName.TabIndex = 2;
            this.radiobtnMotherName.TabStop = true;
            this.radiobtnMotherName.Text = "母親";
            this.radiobtnMotherName.UseVisualStyleBackColor = true;
            // 
            // radiobtnFatherName
            // 
            this.radiobtnFatherName.AutoSize = true;
            this.radiobtnFatherName.Location = new System.Drawing.Point(7, 30);
            this.radiobtnFatherName.Name = "radiobtnFatherName";
            this.radiobtnFatherName.Size = new System.Drawing.Size(52, 21);
            this.radiobtnFatherName.TabIndex = 1;
            this.radiobtnFatherName.TabStop = true;
            this.radiobtnFatherName.Text = "父親";
            this.radiobtnFatherName.UseVisualStyleBackColor = true;
            // 
            // radiobtnCustodianName
            // 
            this.radiobtnCustodianName.AutoSize = true;
            this.radiobtnCustodianName.Location = new System.Drawing.Point(7, 3);
            this.radiobtnCustodianName.Name = "radiobtnCustodianName";
            this.radiobtnCustodianName.Size = new System.Drawing.Size(65, 21);
            this.radiobtnCustodianName.TabIndex = 0;
            this.radiobtnCustodianName.TabStop = true;
            this.radiobtnCustodianName.Text = "監護人";
            this.radiobtnCustodianName.UseVisualStyleBackColor = true;
            // 
            // SHSContactsForm
            // 
            this.ClientSize = new System.Drawing.Size(270, 278);
            this.Controls.Add(this.groupPanel3);
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnExit);
            this.DoubleBuffered = true;
            this.Name = "SHSContactsForm";
            this.Text = "通訊錄郵寄格式";
            this.Load += new System.EventHandler(this.SHSContactsForm_Load);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel2.PerformLayout();
            this.groupPanel3.ResumeLayout(false);
            this.groupPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        private void radiobtnPermanentAddress_CheckedChanged(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private System.Windows.Forms.LinkLabel lnkUpload;
        private System.Windows.Forms.LinkLabel lnkDownload;
        private DevComponents.DotNetBar.ButtonX btnPrint;
        private DevComponents.DotNetBar.ButtonX btnExit;
        private System.Windows.Forms.LinkLabel lnkDesc;
        private System.Windows.Forms.LinkLabel lnkReset;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private System.Windows.Forms.RadioButton radiobtnOtherAddress;
        private System.Windows.Forms.RadioButton radiobtnMailingAddress;
        private System.Windows.Forms.RadioButton radiobtnPermanentAddress;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private System.Windows.Forms.RadioButton radiobtnMotherName;
        private System.Windows.Forms.RadioButton radiobtnFatherName;
        private System.Windows.Forms.RadioButton radiobtnCustodianName;
    }
}