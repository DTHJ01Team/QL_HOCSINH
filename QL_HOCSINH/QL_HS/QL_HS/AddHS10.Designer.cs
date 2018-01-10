namespace QL_HS
{
    partial class AddHS10
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataThem10 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.cbMS10 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.cbLop10 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.txtTen10 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnThem10 = new DevComponents.DotNetBar.ButtonX();
            this.btnSua10 = new DevComponents.DotNetBar.ButtonX();
            this.btnXoa10 = new DevComponents.DotNetBar.ButtonX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.dataThem10)).BeginInit();
            this.SuspendLayout();
            // 
            // dataThem10
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataThem10.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataThem10.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataThem10.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataThem10.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataThem10.EnableHeadersVisualStyles = false;
            this.dataThem10.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataThem10.Location = new System.Drawing.Point(0, 217);
            this.dataThem10.Name = "dataThem10";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataThem10.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataThem10.Size = new System.Drawing.Size(374, 125);
            this.dataThem10.TabIndex = 0;
            this.dataThem10.Click += new System.EventHandler(this.dataThem10_Click);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelX1.Location = new System.Drawing.Point(69, 63);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "Mã học sinh";
            // 
            // cbMS10
            // 
            this.cbMS10.DisplayMember = "Text";
            this.cbMS10.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbMS10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMS10.FormattingEnabled = true;
            this.cbMS10.ItemHeight = 16;
            this.cbMS10.Location = new System.Drawing.Point(148, 64);
            this.cbMS10.Name = "cbMS10";
            this.cbMS10.Size = new System.Drawing.Size(121, 22);
            this.cbMS10.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbMS10.TabIndex = 2;
            this.cbMS10.SelectedIndexChanged += new System.EventHandler(this.cbMS10_SelectedIndexChanged);
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelX2.Location = new System.Drawing.Point(69, 120);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 1;
            this.labelX2.Text = "Lớp";
            // 
            // cbLop10
            // 
            this.cbLop10.DisplayMember = "Text";
            this.cbLop10.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbLop10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLop10.FormattingEnabled = true;
            this.cbLop10.ItemHeight = 16;
            this.cbLop10.Location = new System.Drawing.Point(148, 120);
            this.cbLop10.Name = "cbLop10";
            this.cbLop10.Size = new System.Drawing.Size(121, 22);
            this.cbLop10.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbLop10.TabIndex = 2;
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelX3.Location = new System.Drawing.Point(69, 92);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(75, 23);
            this.labelX3.TabIndex = 1;
            this.labelX3.Text = "Họ Tên";
            // 
            // txtTen10
            // 
            // 
            // 
            // 
            this.txtTen10.Border.Class = "TextBoxBorder";
            this.txtTen10.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTen10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTen10.Location = new System.Drawing.Point(148, 92);
            this.txtTen10.Name = "txtTen10";
            this.txtTen10.ReadOnly = true;
            this.txtTen10.Size = new System.Drawing.Size(121, 22);
            this.txtTen10.TabIndex = 3;
            this.txtTen10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnThem10
            // 
            this.btnThem10.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnThem10.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnThem10.Location = new System.Drawing.Point(36, 167);
            this.btnThem10.Name = "btnThem10";
            this.btnThem10.Size = new System.Drawing.Size(75, 23);
            this.btnThem10.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnThem10.TabIndex = 4;
            this.btnThem10.Text = "Thêm";
            this.btnThem10.Click += new System.EventHandler(this.btnThem10_Click);
            // 
            // btnSua10
            // 
            this.btnSua10.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSua10.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSua10.Location = new System.Drawing.Point(149, 167);
            this.btnSua10.Name = "btnSua10";
            this.btnSua10.Size = new System.Drawing.Size(75, 23);
            this.btnSua10.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSua10.TabIndex = 5;
            this.btnSua10.Text = "Sửa";
            this.btnSua10.Click += new System.EventHandler(this.btnSua10_Click);
            // 
            // btnXoa10
            // 
            this.btnXoa10.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnXoa10.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnXoa10.Location = new System.Drawing.Point(262, 167);
            this.btnXoa10.Name = "btnXoa10";
            this.btnXoa10.Size = new System.Drawing.Size(75, 23);
            this.btnXoa10.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnXoa10.TabIndex = 6;
            this.btnXoa10.Text = "Xóa";
            this.btnXoa10.Click += new System.EventHandler(this.btnXoa10_Click);
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelX4.Location = new System.Drawing.Point(77, 17);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(212, 23);
            this.labelX4.TabIndex = 7;
            this.labelX4.Text = "THÊM HỌC SINH KHỐI 10";
            // 
            // AddHS10
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 342);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.btnXoa10);
            this.Controls.Add(this.btnSua10);
            this.Controls.Add(this.btnThem10);
            this.Controls.Add(this.txtTen10);
            this.Controls.Add(this.cbLop10);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.cbMS10);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.dataThem10);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AddHS10";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm học sinh khối 10";
            this.Load += new System.EventHandler(this.AddHS10_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataThem10)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dataThem10;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbMS10;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbLop10;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTen10;
        private DevComponents.DotNetBar.ButtonX btnThem10;
        private DevComponents.DotNetBar.ButtonX btnSua10;
        private DevComponents.DotNetBar.ButtonX btnXoa10;
        private DevComponents.DotNetBar.LabelX labelX4;
    }
}