namespace VRMS___Management__12_01_21_
{
    partial class PAccount
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PAccount));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Corners = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.pnlBody = new System.Windows.Forms.TableLayoutPanel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.tlpHead = new System.Windows.Forms.TableLayoutPanel();
            this.pnlHead = new System.Windows.Forms.Panel();
            this.header = new System.Windows.Forms.Label();
            this.tlpButtons = new System.Windows.Forms.TableLayoutPanel();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.lblShowID = new System.Windows.Forms.Label();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnRestore = new Guna.UI.WinForms.GunaAdvenceButton();
            this.btnDel = new Guna.UI.WinForms.GunaAdvenceButton();
            this.tlpContents = new System.Windows.Forms.TableLayoutPanel();
            this.dgvPA = new Guna.UI2.WinForms.Guna2DataGridView();
            this.pnlBody.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.tlpHead.SuspendLayout();
            this.pnlHead.SuspendLayout();
            this.tlpButtons.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.tlpContents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPA)).BeginInit();
            this.SuspendLayout();
            // 
            // Corners
            // 
            this.Corners.ElipseRadius = 20;
            this.Corners.TargetControl = this;
            // 
            // pnlBody
            // 
            this.pnlBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBody.ColumnCount = 1;
            this.pnlBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlBody.Controls.Add(this.pnlHeader, 0, 0);
            this.pnlBody.Controls.Add(this.tlpButtons, 0, 2);
            this.pnlBody.Controls.Add(this.tlpContents, 0, 3);
            this.pnlBody.Location = new System.Drawing.Point(0, 0);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.RowCount = 4;
            this.pnlBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.pnlBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pnlBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.pnlBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlBody.Size = new System.Drawing.Size(960, 540);
            this.pnlBody.TabIndex = 17;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.tlpHead);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeader.Location = new System.Drawing.Point(3, 3);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(954, 44);
            this.pnlHeader.TabIndex = 0;
            // 
            // tlpHead
            // 
            this.tlpHead.ColumnCount = 3;
            this.tlpHead.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpHead.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tlpHead.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpHead.Controls.Add(this.pnlHead, 1, 0);
            this.tlpHead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpHead.Location = new System.Drawing.Point(0, 0);
            this.tlpHead.Name = "tlpHead";
            this.tlpHead.RowCount = 1;
            this.tlpHead.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpHead.Size = new System.Drawing.Size(954, 44);
            this.tlpHead.TabIndex = 0;
            // 
            // pnlHead
            // 
            this.pnlHead.Controls.Add(this.header);
            this.pnlHead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHead.Location = new System.Drawing.Point(355, 3);
            this.pnlHead.Name = "pnlHead";
            this.pnlHead.Size = new System.Drawing.Size(244, 38);
            this.pnlHead.TabIndex = 0;
            // 
            // header
            // 
            this.header.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.header.AutoSize = true;
            this.header.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.header.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(53)))), ((int)(((byte)(49)))));
            this.header.Location = new System.Drawing.Point(20, 6);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(206, 24);
            this.header.TabIndex = 13;
            this.header.Text = "ACCOUNT ARCHIVE";
            // 
            // tlpButtons
            // 
            this.tlpButtons.ColumnCount = 1;
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpButtons.Controls.Add(this.pnlSearch, 0, 0);
            this.tlpButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpButtons.Location = new System.Drawing.Point(3, 73);
            this.tlpButtons.Name = "tlpButtons";
            this.tlpButtons.RowCount = 1;
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpButtons.Size = new System.Drawing.Size(954, 44);
            this.tlpButtons.TabIndex = 1;
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.lblShowID);
            this.pnlSearch.Controls.Add(this.txtSearch);
            this.pnlSearch.Controls.Add(this.btnRestore);
            this.pnlSearch.Controls.Add(this.btnDel);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSearch.Location = new System.Drawing.Point(3, 3);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(948, 38);
            this.pnlSearch.TabIndex = 13;
            // 
            // lblShowID
            // 
            this.lblShowID.AutoSize = true;
            this.lblShowID.Location = new System.Drawing.Point(604, 21);
            this.lblShowID.Name = "lblShowID";
            this.lblShowID.Size = new System.Drawing.Size(35, 13);
            this.lblShowID.TabIndex = 25;
            this.lblShowID.Text = "label1";
            this.lblShowID.Visible = false;
            // 
            // txtSearch
            // 
            this.txtSearch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(207)))), ((int)(((byte)(244)))));
            this.txtSearch.BorderRadius = 10;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.DisabledState.Parent = this.txtSearch;
            this.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.FocusedState.Parent = this.txtSearch;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.HoverState.Parent = this.txtSearch;
            this.txtSearch.IconRight = ((System.Drawing.Image)(resources.GetObject("txtSearch.IconRight")));
            this.txtSearch.IconRightSize = new System.Drawing.Size(35, 35);
            this.txtSearch.Location = new System.Drawing.Point(28, 2);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.txtSearch.PlaceholderText = "Search";
            this.txtSearch.SelectedText = "";
            this.txtSearch.ShadowDecoration.Parent = this.txtSearch;
            this.txtSearch.Size = new System.Drawing.Size(420, 33);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnRestore
            // 
            this.btnRestore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestore.AnimationHoverSpeed = 0.07F;
            this.btnRestore.AnimationSpeed = 0.03F;
            this.btnRestore.BackColor = System.Drawing.Color.Transparent;
            this.btnRestore.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(207)))), ((int)(((byte)(244)))));
            this.btnRestore.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(207)))), ((int)(((byte)(244)))));
            this.btnRestore.CheckedBaseColor = System.Drawing.Color.Gray;
            this.btnRestore.CheckedBorderColor = System.Drawing.Color.Black;
            this.btnRestore.CheckedForeColor = System.Drawing.Color.White;
            this.btnRestore.CheckedImage = ((System.Drawing.Image)(resources.GetObject("btnRestore.CheckedImage")));
            this.btnRestore.CheckedLineColor = System.Drawing.Color.DimGray;
            this.btnRestore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestore.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnRestore.FocusedColor = System.Drawing.Color.Empty;
            this.btnRestore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(53)))), ((int)(((byte)(49)))));
            this.btnRestore.Image = null;
            this.btnRestore.ImageSize = new System.Drawing.Size(30, 30);
            this.btnRestore.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.btnRestore.Location = new System.Drawing.Point(806, 3);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnRestore.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnRestore.OnHoverForeColor = System.Drawing.Color.White;
            this.btnRestore.OnHoverImage = null;
            this.btnRestore.OnHoverLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.btnRestore.OnPressedColor = System.Drawing.Color.Black;
            this.btnRestore.Radius = 10;
            this.btnRestore.Size = new System.Drawing.Size(101, 32);
            this.btnRestore.TabIndex = 10;
            this.btnRestore.Text = "RESTORE";
            this.btnRestore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDel.AnimationHoverSpeed = 0.07F;
            this.btnDel.AnimationSpeed = 0.03F;
            this.btnDel.BackColor = System.Drawing.Color.Transparent;
            this.btnDel.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(207)))), ((int)(((byte)(244)))));
            this.btnDel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(207)))), ((int)(((byte)(244)))));
            this.btnDel.CheckedBaseColor = System.Drawing.Color.Gray;
            this.btnDel.CheckedBorderColor = System.Drawing.Color.Black;
            this.btnDel.CheckedForeColor = System.Drawing.Color.White;
            this.btnDel.CheckedImage = ((System.Drawing.Image)(resources.GetObject("btnDel.CheckedImage")));
            this.btnDel.CheckedLineColor = System.Drawing.Color.DimGray;
            this.btnDel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnDel.FocusedColor = System.Drawing.Color.Empty;
            this.btnDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(53)))), ((int)(((byte)(49)))));
            this.btnDel.Image = null;
            this.btnDel.ImageSize = new System.Drawing.Size(30, 30);
            this.btnDel.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.btnDel.Location = new System.Drawing.Point(456, 2);
            this.btnDel.Name = "btnDel";
            this.btnDel.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnDel.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnDel.OnHoverForeColor = System.Drawing.Color.White;
            this.btnDel.OnHoverImage = null;
            this.btnDel.OnHoverLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.btnDel.OnPressedColor = System.Drawing.Color.Black;
            this.btnDel.Radius = 10;
            this.btnDel.Size = new System.Drawing.Size(96, 32);
            this.btnDel.TabIndex = 12;
            this.btnDel.Text = "FIND";
            this.btnDel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tlpContents
            // 
            this.tlpContents.ColumnCount = 3;
            this.tlpContents.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpContents.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpContents.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpContents.Controls.Add(this.dgvPA, 1, 1);
            this.tlpContents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpContents.Location = new System.Drawing.Point(3, 123);
            this.tlpContents.Name = "tlpContents";
            this.tlpContents.RowCount = 3;
            this.tlpContents.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpContents.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpContents.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpContents.Size = new System.Drawing.Size(954, 414);
            this.tlpContents.TabIndex = 2;
            // 
            // dgvPA
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvPA.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPA.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPA.BackgroundColor = System.Drawing.Color.White;
            this.dgvPA.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPA.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvPA.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPA.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPA.ColumnHeadersHeight = 40;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPA.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPA.EnableHeadersVisualStyles = false;
            this.dgvPA.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvPA.Location = new System.Drawing.Point(23, 23);
            this.dgvPA.Name = "dgvPA";
            this.dgvPA.RowHeadersVisible = false;
            this.dgvPA.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPA.Size = new System.Drawing.Size(908, 368);
            this.dgvPA.TabIndex = 0;
            this.dgvPA.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dgvPA.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvPA.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvPA.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvPA.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvPA.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvPA.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvPA.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvPA.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvPA.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvPA.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvPA.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvPA.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvPA.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvPA.ThemeStyle.ReadOnly = false;
            this.dgvPA.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvPA.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvPA.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvPA.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvPA.ThemeStyle.RowsStyle.Height = 22;
            this.dgvPA.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvPA.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvPA.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPA_CellClick);
            // 
            // PAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(960, 540);
            this.Controls.Add(this.pnlBody);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PAccount";
            this.Text = "PAccount";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PAccount_Load);
            this.pnlBody.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.tlpHead.ResumeLayout(false);
            this.pnlHead.ResumeLayout(false);
            this.pnlHead.PerformLayout();
            this.tlpButtons.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.tlpContents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPA)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse Corners;
        private System.Windows.Forms.TableLayoutPanel pnlBody;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.TableLayoutPanel tlpHead;
        private System.Windows.Forms.Panel pnlHead;
        public System.Windows.Forms.Label header;
        private System.Windows.Forms.TableLayoutPanel tlpContents;
        private Guna.UI2.WinForms.Guna2DataGridView dgvPA;
        private System.Windows.Forms.TableLayoutPanel tlpButtons;
        private System.Windows.Forms.Panel pnlSearch;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI.WinForms.GunaAdvenceButton btnRestore;
        private Guna.UI.WinForms.GunaAdvenceButton btnDel;
        private System.Windows.Forms.Label lblShowID;
    }
}