namespace PKStudio.Forms.Editors.Pages.LibraryCategory
{
    partial class FeatureAssociationsPage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FeatureAssociationsPage));
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.HeaderLbl = new System.Windows.Forms.Label();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.AddBtn = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.FAListBox = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.InfoRtb = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.HeaderLbl, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel6, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.splitContainer1, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(561, 556);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // HeaderLbl
            // 
            this.HeaderLbl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.HeaderLbl.AutoSize = true;
            this.HeaderLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HeaderLbl.Location = new System.Drawing.Point(5, 5);
            this.HeaderLbl.Name = "HeaderLbl";
            this.HeaderLbl.Size = new System.Drawing.Size(124, 13);
            this.HeaderLbl.TabIndex = 0;
            this.HeaderLbl.Text = "Feature associations";
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 3;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 79F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 101F));
            this.tableLayoutPanel6.Controls.Add(this.DeleteBtn, 2, 0);
            this.tableLayoutPanel6.Controls.Add(this.AddBtn, 1, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(5, 519);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(551, 32);
            this.tableLayoutPanel6.TabIndex = 1;
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.DeleteBtn.Enabled = false;
            this.DeleteBtn.Location = new System.Drawing.Point(453, 4);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(95, 23);
            this.DeleteBtn.TabIndex = 0;
            this.DeleteBtn.Text = "Delete selected";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // AddBtn
            // 
            this.AddBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.AddBtn.Enabled = false;
            this.AddBtn.Location = new System.Drawing.Point(374, 4);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(73, 23);
            this.AddBtn.TabIndex = 1;
            this.AddBtn.Text = "Add";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(5, 27);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.FAListBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.InfoRtb);
            this.splitContainer1.Size = new System.Drawing.Size(551, 484);
            this.splitContainer1.SplitterDistance = 182;
            this.splitContainer1.TabIndex = 2;
            // 
            // FAListBox
            // 
            this.FAListBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.FAListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FAListBox.FullRowSelect = true;
            this.FAListBox.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.FAListBox.Location = new System.Drawing.Point(0, 0);
            this.FAListBox.MultiSelect = false;
            this.FAListBox.Name = "FAListBox";
            this.FAListBox.ShowGroups = false;
            this.FAListBox.Size = new System.Drawing.Size(182, 484);
            this.FAListBox.SmallImageList = this.imageList1;
            this.FAListBox.TabIndex = 0;
            this.FAListBox.UseCompatibleStateImageBehavior = false;
            this.FAListBox.View = System.Windows.Forms.View.Details;
            this.FAListBox.SelectedIndexChanged += new System.EventHandler(this.FAListBox_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 235;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "folder_closed.png");
            this.imageList1.Images.SetKeyName(1, "folder.png");
            this.imageList1.Images.SetKeyName(2, "folders.png");
            this.imageList1.Images.SetKeyName(3, "component.png");
            this.imageList1.Images.SetKeyName(4, "application.ico");
            this.imageList1.Images.SetKeyName(5, "box.ico");
            this.imageList1.Images.SetKeyName(6, "cpu.ico");
            this.imageList1.Images.SetKeyName(7, "component_green.ico");
            this.imageList1.Images.SetKeyName(8, "component_yellow.ico");
            this.imageList1.Images.SetKeyName(9, "components.ico");
            this.imageList1.Images.SetKeyName(10, "scroll.ico");
            // 
            // InfoRtb
            // 
            this.InfoRtb.BackColor = System.Drawing.SystemColors.Window;
            this.InfoRtb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InfoRtb.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InfoRtb.Location = new System.Drawing.Point(0, 0);
            this.InfoRtb.Name = "InfoRtb";
            this.InfoRtb.ReadOnly = true;
            this.InfoRtb.Size = new System.Drawing.Size(365, 484);
            this.InfoRtb.TabIndex = 7;
            this.InfoRtb.Text = "";
            // 
            // FeatureAssociationsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel4);
            this.Name = "FeatureAssociationsPage";
            this.Size = new System.Drawing.Size(561, 556);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label HeaderLbl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView FAListBox;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.RichTextBox InfoRtb;
        private System.Windows.Forms.ImageList imageList1;
    }
}
