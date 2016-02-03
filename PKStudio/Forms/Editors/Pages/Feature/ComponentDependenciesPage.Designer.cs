namespace PKStudio.Forms.Editors.Pages.Feature
{
    partial class ComponentDependenciesPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComponentDependenciesPage));
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.HeaderLbl = new System.Windows.Forms.Label();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.DepDeleteBtn = new System.Windows.Forms.Button();
            this.DepAddBtn = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this._treeView = new PKStudio.Tree.InventoryTree();
            this.DepsInfoRTB = new System.Windows.Forms.RichTextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
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
            this.tableLayoutPanel4.Size = new System.Drawing.Size(726, 523);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // HeaderLbl
            // 
            this.HeaderLbl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.HeaderLbl.AutoSize = true;
            this.HeaderLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HeaderLbl.Location = new System.Drawing.Point(3, 3);
            this.HeaderLbl.Name = "HeaderLbl";
            this.HeaderLbl.Size = new System.Drawing.Size(151, 13);
            this.HeaderLbl.TabIndex = 0;
            this.HeaderLbl.Text = "ComponentDependencies";
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 3;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 79F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 101F));
            this.tableLayoutPanel6.Controls.Add(this.DepDeleteBtn, 2, 0);
            this.tableLayoutPanel6.Controls.Add(this.DepAddBtn, 1, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 488);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(720, 32);
            this.tableLayoutPanel6.TabIndex = 1;
            // 
            // DepDeleteBtn
            // 
            this.DepDeleteBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.DepDeleteBtn.Enabled = false;
            this.DepDeleteBtn.Location = new System.Drawing.Point(622, 4);
            this.DepDeleteBtn.Name = "DepDeleteBtn";
            this.DepDeleteBtn.Size = new System.Drawing.Size(95, 23);
            this.DepDeleteBtn.TabIndex = 0;
            this.DepDeleteBtn.Text = "Delete selected";
            this.DepDeleteBtn.UseVisualStyleBackColor = true;
            this.DepDeleteBtn.Click += new System.EventHandler(this.DepDeleteBtn_Click);
            // 
            // DepAddBtn
            // 
            this.DepAddBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.DepAddBtn.Enabled = false;
            this.DepAddBtn.Location = new System.Drawing.Point(543, 4);
            this.DepAddBtn.Name = "DepAddBtn";
            this.DepAddBtn.Size = new System.Drawing.Size(73, 23);
            this.DepAddBtn.TabIndex = 1;
            this.DepAddBtn.Text = "Add";
            this.DepAddBtn.UseVisualStyleBackColor = true;
            this.DepAddBtn.Click += new System.EventHandler(this.DepAddBtn_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 23);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this._treeView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.DepsInfoRTB);
            this.splitContainer1.Size = new System.Drawing.Size(720, 459);
            this.splitContainer1.SplitterDistance = 239;
            this.splitContainer1.TabIndex = 2;
            // 
            // _treeView
            // 
            this._treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._treeView.LoadOnDemand = false;
            this._treeView.Location = new System.Drawing.Point(0, 0);
            this._treeView.Name = "_treeView";
            this._treeView.ShowLines = false;
            this._treeView.ShowPlusMinus = false;
            this._treeView.Size = new System.Drawing.Size(239, 459);
            this._treeView.TabIndex = 1;
            this._treeView.TreeSelectedNode = null;
            this._treeView.SelectionChangedEvent += new System.EventHandler<PKStudio.Forms.BaseForms.ObjectEventArgs>(this._treeView_SelectionChangedEvent);
            // 
            // DepsInfoRTB
            // 
            this.DepsInfoRTB.BackColor = System.Drawing.SystemColors.Window;
            this.DepsInfoRTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DepsInfoRTB.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DepsInfoRTB.Location = new System.Drawing.Point(0, 0);
            this.DepsInfoRTB.Name = "DepsInfoRTB";
            this.DepsInfoRTB.ReadOnly = true;
            this.DepsInfoRTB.Size = new System.Drawing.Size(477, 459);
            this.DepsInfoRTB.TabIndex = 7;
            this.DepsInfoRTB.Text = "";
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
            // ComponentDependenciesPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel4);
            this.Name = "ComponentDependenciesPage";
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
        private System.Windows.Forms.Button DepDeleteBtn;
        private System.Windows.Forms.Button DepAddBtn;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox DepsInfoRTB;
        private System.Windows.Forms.ImageList imageList1;
        private Tree.InventoryTree _treeView;
    }
}
