namespace NDEFReadWriteTool
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.uiTabControlMenu1 = new Sunny.UI.UITabControlMenu();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.uiGroupBox1 = new Sunny.UI.UIGroupBox();
            this.uiSwitch1 = new Sunny.UI.UISwitch();
            this.uiComboBox3 = new Sunny.UI.UIComboBox();
            this.uiComboBox2 = new Sunny.UI.UIComboBox();
            this.uiComboBox1 = new Sunny.UI.UIComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.uiPanel1 = new Sunny.UI.UIPanel();
            this.uiNavBar1 = new Sunny.UI.UINavBar();
            this.uiPanel2 = new Sunny.UI.UIPanel();
            this.uiSymbolButton1 = new Sunny.UI.UISymbolButton();
            this.uiTabControlMenu1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.uiGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.uiNavBar1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiTabControlMenu1
            // 
            this.uiTabControlMenu1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.uiTabControlMenu1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.uiTabControlMenu1.Controls.Add(this.tabPage1);
            this.uiTabControlMenu1.Controls.Add(this.tabPage2);
            this.uiTabControlMenu1.Controls.Add(this.tabPage3);
            this.uiTabControlMenu1.Controls.Add(this.tabPage4);
            this.uiTabControlMenu1.Controls.Add(this.tabPage5);
            this.uiTabControlMenu1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.uiTabControlMenu1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTabControlMenu1.Location = new System.Drawing.Point(3, 130);
            this.uiTabControlMenu1.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.uiTabControlMenu1.Multiline = true;
            this.uiTabControlMenu1.Name = "uiTabControlMenu1";
            this.uiTabControlMenu1.SelectedIndex = 0;
            this.uiTabControlMenu1.Size = new System.Drawing.Size(812, 396);
            this.uiTabControlMenu1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.uiTabControlMenu1.TabBackColor = System.Drawing.Color.Firebrick;
            this.uiTabControlMenu1.TabIndex = 1;
            this.uiTabControlMenu1.TabSelectedColor = System.Drawing.Color.Red;
            this.uiTabControlMenu1.TabSelectedForeColor = System.Drawing.Color.White;
            this.uiTabControlMenu1.TabSelectedHighColor = System.Drawing.Color.White;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.MistyRose;
            this.tabPage1.Controls.Add(this.uiGroupBox1);
            this.tabPage1.ForeColor = System.Drawing.Color.White;
            this.tabPage1.Location = new System.Drawing.Point(201, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(611, 396);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "读写器配置";
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.uiSymbolButton1);
            this.uiGroupBox1.Controls.Add(this.uiSwitch1);
            this.uiGroupBox1.Controls.Add(this.uiComboBox3);
            this.uiGroupBox1.Controls.Add(this.uiComboBox2);
            this.uiGroupBox1.Controls.Add(this.uiComboBox1);
            this.uiGroupBox1.Controls.Add(this.label3);
            this.uiGroupBox1.Controls.Add(this.label2);
            this.uiGroupBox1.Controls.Add(this.label1);
            this.uiGroupBox1.FillColor = System.Drawing.Color.MistyRose;
            this.uiGroupBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox1.Location = new System.Drawing.Point(15, 10);
            this.uiGroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox1.RectColor = System.Drawing.Color.Red;
            this.uiGroupBox1.Size = new System.Drawing.Size(226, 245);
            this.uiGroupBox1.TabIndex = 0;
            this.uiGroupBox1.Text = "通信配置";
            this.uiGroupBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiSwitch1
            // 
            this.uiSwitch1.ActiveColor = System.Drawing.Color.Red;
            this.uiSwitch1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSwitch1.Location = new System.Drawing.Point(124, 199);
            this.uiSwitch1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSwitch1.Name = "uiSwitch1";
            this.uiSwitch1.Size = new System.Drawing.Size(98, 33);
            this.uiSwitch1.SwitchShape = Sunny.UI.UISwitch.UISwitchShape.Square;
            this.uiSwitch1.TabIndex = 6;
            this.uiSwitch1.Text = "uiSwitch1";
            // 
            // uiComboBox3
            // 
            this.uiComboBox3.DataSource = null;
            this.uiComboBox3.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.uiComboBox3.FillColor = System.Drawing.Color.White;
            this.uiComboBox3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiComboBox3.ItemHoverColor = System.Drawing.Color.Red;
            this.uiComboBox3.ItemRectColor = System.Drawing.Color.Red;
            this.uiComboBox3.Items.AddRange(new object[] {
            "USB",
            "COM",
            "TCP"});
            this.uiComboBox3.ItemSelectBackColor = System.Drawing.Color.Red;
            this.uiComboBox3.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.uiComboBox3.Location = new System.Drawing.Point(100, 139);
            this.uiComboBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiComboBox3.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiComboBox3.Name = "uiComboBox3";
            this.uiComboBox3.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uiComboBox3.RectColor = System.Drawing.Color.Red;
            this.uiComboBox3.Size = new System.Drawing.Size(122, 41);
            this.uiComboBox3.SymbolSize = 24;
            this.uiComboBox3.TabIndex = 5;
            this.uiComboBox3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiComboBox3.Watermark = "";
            // 
            // uiComboBox2
            // 
            this.uiComboBox2.DataSource = null;
            this.uiComboBox2.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.uiComboBox2.FillColor = System.Drawing.Color.White;
            this.uiComboBox2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiComboBox2.ItemHoverColor = System.Drawing.Color.Red;
            this.uiComboBox2.ItemRectColor = System.Drawing.Color.Red;
            this.uiComboBox2.Items.AddRange(new object[] {
            "USB",
            "COM",
            "TCP"});
            this.uiComboBox2.ItemSelectBackColor = System.Drawing.Color.Red;
            this.uiComboBox2.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.uiComboBox2.Location = new System.Drawing.Point(100, 88);
            this.uiComboBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiComboBox2.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiComboBox2.Name = "uiComboBox2";
            this.uiComboBox2.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uiComboBox2.RectColor = System.Drawing.Color.Red;
            this.uiComboBox2.Size = new System.Drawing.Size(122, 41);
            this.uiComboBox2.SymbolSize = 24;
            this.uiComboBox2.TabIndex = 4;
            this.uiComboBox2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiComboBox2.Watermark = "";
            // 
            // uiComboBox1
            // 
            this.uiComboBox1.DataSource = null;
            this.uiComboBox1.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.uiComboBox1.FillColor = System.Drawing.Color.White;
            this.uiComboBox1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiComboBox1.ItemHoverColor = System.Drawing.Color.Red;
            this.uiComboBox1.ItemRectColor = System.Drawing.Color.Red;
            this.uiComboBox1.Items.AddRange(new object[] {
            "USB",
            "COM",
            "TCP"});
            this.uiComboBox1.ItemSelectBackColor = System.Drawing.Color.Red;
            this.uiComboBox1.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.uiComboBox1.Location = new System.Drawing.Point(100, 37);
            this.uiComboBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiComboBox1.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiComboBox1.Name = "uiComboBox1";
            this.uiComboBox1.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uiComboBox1.RectColor = System.Drawing.Color.Red;
            this.uiComboBox1.Size = new System.Drawing.Size(122, 41);
            this.uiComboBox1.SymbolSize = 24;
            this.uiComboBox1.TabIndex = 3;
            this.uiComboBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiComboBox1.Watermark = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "通信方式:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "通信方式:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "通信方式:";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.MistyRose;
            this.tabPage2.Location = new System.Drawing.Point(201, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(611, 396);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "读写URL";
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(201, 0);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(611, 396);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "读写TXT";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(201, 0);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(611, 396);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "读写电子名片";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(201, 0);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(611, 396);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "蓝牙配对";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::NDEFReadWriteTool.Properties.Resources.anyid;
            this.pictureBox1.Location = new System.Drawing.Point(12, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 76);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // uiPanel1
            // 
            this.uiPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiPanel1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPanel1.Location = new System.Drawing.Point(204, 524);
            this.uiPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.uiPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel1.Name = "uiPanel1";
            this.uiPanel1.Radius = 0;
            this.uiPanel1.RectColor = System.Drawing.Color.Firebrick;
            this.uiPanel1.Size = new System.Drawing.Size(614, 36);
            this.uiPanel1.TabIndex = 3;
            this.uiPanel1.Text = "上海普阅信息科技有限公司@https://www.anyid.com.cn";
            this.uiPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiNavBar1
            // 
            this.uiNavBar1.BackColor = System.Drawing.Color.White;
            this.uiNavBar1.Controls.Add(this.pictureBox1);
            this.uiNavBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiNavBar1.DropMenuFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiNavBar1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiNavBar1.Location = new System.Drawing.Point(0, 35);
            this.uiNavBar1.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.uiNavBar1.Name = "uiNavBar1";
            this.uiNavBar1.Size = new System.Drawing.Size(818, 97);
            this.uiNavBar1.TabIndex = 4;
            this.uiNavBar1.Text = "uiNavBar1";
            // 
            // uiPanel2
            // 
            this.uiPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiPanel2.BackColor = System.Drawing.Color.Firebrick;
            this.uiPanel2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPanel2.Location = new System.Drawing.Point(0, 524);
            this.uiPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.uiPanel2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel2.Name = "uiPanel2";
            this.uiPanel2.Radius = 0;
            this.uiPanel2.RectColor = System.Drawing.Color.Firebrick;
            this.uiPanel2.Size = new System.Drawing.Size(206, 36);
            this.uiPanel2.TabIndex = 5;
            this.uiPanel2.Text = "NFCRWTool V1.0.0.0";
            this.uiPanel2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiSymbolButton1
            // 
            this.uiSymbolButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.uiSymbolButton1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.uiSymbolButton1.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.uiSymbolButton1.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.uiSymbolButton1.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.uiSymbolButton1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton1.IsCircle = true;
            this.uiSymbolButton1.LightColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.uiSymbolButton1.Location = new System.Drawing.Point(6, 197);
            this.uiSymbolButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton1.Name = "uiSymbolButton1";
            this.uiSymbolButton1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.uiSymbolButton1.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.uiSymbolButton1.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.uiSymbolButton1.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.uiSymbolButton1.Size = new System.Drawing.Size(100, 35);
            this.uiSymbolButton1.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton1.Symbol = 61453;
            this.uiSymbolButton1.TabIndex = 7;
            this.uiSymbolButton1.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(818, 560);
            this.Controls.Add(this.uiPanel2);
            this.Controls.Add(this.uiNavBar1);
            this.Controls.Add(this.uiTabControlMenu1);
            this.Controls.Add(this.uiPanel1);
            this.Name = "Form1";
            this.RectColor = System.Drawing.Color.White;
            this.Text = "Form1";
            this.TitleColor = System.Drawing.Color.Firebrick;
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 728, 510);
            this.uiTabControlMenu1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.uiGroupBox1.ResumeLayout(false);
            this.uiGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.uiNavBar1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Sunny.UI.UITabControlMenu uiTabControlMenu1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UINavBar uiNavBar1;
        private Sunny.UI.UIPanel uiPanel2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private Sunny.UI.UIGroupBox uiGroupBox1;
        private Sunny.UI.UIComboBox uiComboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Sunny.UI.UISwitch uiSwitch1;
        private Sunny.UI.UIComboBox uiComboBox3;
        private Sunny.UI.UIComboBox uiComboBox2;
        private Sunny.UI.UISymbolButton uiSymbolButton1;
    }
}

