namespace QL_HS
{
    partial class SLMonHoc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SLMonHoc));
            this.btnSLMSave = new DevComponents.DotNetBar.ButtonX();
            this.txtSLMon = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX32 = new DevComponents.DotNetBar.LabelX();
            this.labelX31 = new DevComponents.DotNetBar.LabelX();
            this.SuspendLayout();
            // 
            // btnSLMSave
            // 
            this.btnSLMSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSLMSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSLMSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSLMSave.Image")));
            this.btnSLMSave.ImageFixedSize = new System.Drawing.Size(35, 35);
            this.btnSLMSave.Location = new System.Drawing.Point(121, 119);
            this.btnSLMSave.Name = "btnSLMSave";
            this.btnSLMSave.Size = new System.Drawing.Size(40, 40);
            this.btnSLMSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSLMSave.TabIndex = 18;
            this.btnSLMSave.Click += new System.EventHandler(this.btnSLMSave_Click);
            // 
            // txtSLMon
            // 
            // 
            // 
            // 
            this.txtSLMon.Border.Class = "TextBoxBorder";
            this.txtSLMon.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSLMon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSLMon.Location = new System.Drawing.Point(140, 68);
            this.txtSLMon.Name = "txtSLMon";
            this.txtSLMon.Size = new System.Drawing.Size(100, 22);
            this.txtSLMon.TabIndex = 17;
            this.txtSLMon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSLMon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSLMon_KeyPress);
            // 
            // labelX32
            // 
            // 
            // 
            // 
            this.labelX32.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX32.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX32.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelX32.Location = new System.Drawing.Point(38, 67);
            this.labelX32.Name = "labelX32";
            this.labelX32.Size = new System.Drawing.Size(75, 23);
            this.labelX32.TabIndex = 16;
            this.labelX32.Text = "Số lượng";
            // 
            // labelX31
            // 
            // 
            // 
            // 
            this.labelX31.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX31.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX31.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelX31.Location = new System.Drawing.Point(24, 16);
            this.labelX31.Name = "labelX31";
            this.labelX31.Size = new System.Drawing.Size(248, 34);
            this.labelX31.TabIndex = 15;
            this.labelX31.Text = "Thay đổi số lượng môn học";
            // 
            // SLMonHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 175);
            this.Controls.Add(this.btnSLMSave);
            this.Controls.Add(this.txtSLMon);
            this.Controls.Add(this.labelX32);
            this.Controls.Add(this.labelX31);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SLMonHoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thay đổi số lượng môn học";
            this.Load += new System.EventHandler(this.SLMonHoc_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnSLMSave;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSLMon;
        private DevComponents.DotNetBar.LabelX labelX32;
        private DevComponents.DotNetBar.LabelX labelX31;
    }
}