namespace Project_SIM.Views.Manager
{
    partial class Users
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.objListUsers = new BrightIdeasSoftware.ObjectListView();
            this.no = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.username = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.fullName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.accessLevel = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.accountState = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.view = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.activate = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.deactivate = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.chckBoxShowGroups = new System.Windows.Forms.CheckBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSearchWord = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objListUsers)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.objListUsers);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(6, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1430, 798);
            this.panel3.TabIndex = 20;
            // 
            // objListUsers
            // 
            this.objListUsers.AllColumns.Add(this.no);
            this.objListUsers.AllColumns.Add(this.username);
            this.objListUsers.AllColumns.Add(this.fullName);
            this.objListUsers.AllColumns.Add(this.accessLevel);
            this.objListUsers.AllColumns.Add(this.accountState);
            this.objListUsers.AllColumns.Add(this.view);
            this.objListUsers.AllColumns.Add(this.activate);
            this.objListUsers.AllColumns.Add(this.deactivate);
            this.objListUsers.CellEditUseWholeCell = false;
            this.objListUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.no,
            this.username,
            this.fullName,
            this.accessLevel,
            this.accountState,
            this.view,
            this.activate,
            this.deactivate});
            this.objListUsers.Cursor = System.Windows.Forms.Cursors.Default;
            this.objListUsers.Dock = System.Windows.Forms.DockStyle.Top;
            this.objListUsers.FullRowSelect = true;
            this.objListUsers.HideSelection = false;
            this.objListUsers.Location = new System.Drawing.Point(0, 92);
            this.objListUsers.Name = "objListUsers";
            this.objListUsers.SelectAllOnControlA = false;
            this.objListUsers.SelectColumnsMenuStaysOpen = false;
            this.objListUsers.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.Submenu;
            this.objListUsers.SelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.objListUsers.SelectedForeColor = System.Drawing.Color.Black;
            this.objListUsers.ShowCommandMenuOnRightClick = true;
            this.objListUsers.ShowItemCountOnGroups = true;
            this.objListUsers.Size = new System.Drawing.Size(1430, 706);
            this.objListUsers.TabIndex = 0;
            this.objListUsers.UseCompatibleStateImageBehavior = false;
            this.objListUsers.View = System.Windows.Forms.View.Details;
            this.objListUsers.ButtonClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.objListUsers_ButtonClick);
            // 
            // no
            // 
            this.no.Groupable = false;
            this.no.IsEditable = false;
            this.no.Text = "#";
            this.no.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // username
            // 
            this.username.FillsFreeSpace = true;
            this.username.Groupable = false;
            this.username.IsEditable = false;
            this.username.Text = "Username";
            // 
            // fullName
            // 
            this.fullName.FillsFreeSpace = true;
            this.fullName.Groupable = false;
            this.fullName.IsEditable = false;
            this.fullName.Text = "Full Name";
            // 
            // accessLevel
            // 
            this.accessLevel.FillsFreeSpace = true;
            this.accessLevel.IsEditable = false;
            this.accessLevel.Text = "Access Level";
            this.accessLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // accountState
            // 
            this.accountState.FillsFreeSpace = true;
            this.accountState.Text = "State";
            // 
            // view
            // 
            this.view.FillsFreeSpace = true;
            this.view.Groupable = false;
            this.view.IsButton = true;
            this.view.Sortable = false;
            this.view.Text = "View";
            this.view.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // activate
            // 
            this.activate.FillsFreeSpace = true;
            this.activate.Groupable = false;
            this.activate.IsButton = true;
            this.activate.Sortable = false;
            this.activate.Text = "Activate";
            this.activate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // deactivate
            // 
            this.deactivate.FillsFreeSpace = true;
            this.deactivate.Groupable = false;
            this.deactivate.IsButton = true;
            this.deactivate.Sortable = false;
            this.deactivate.Text = "Deactivate";
            this.deactivate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnAddUser);
            this.panel2.Controls.Add(this.chckBoxShowGroups);
            this.panel2.Controls.Add(this.btnRefresh);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtSearchWord);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1430, 92);
            this.panel2.TabIndex = 22;
            // 
            // btnAddUser
            // 
            this.btnAddUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddUser.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddUser.Image = global::Project_SIM.Properties.Resources.add_user;
            this.btnAddUser.Location = new System.Drawing.Point(1287, 45);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(140, 44);
            this.btnAddUser.TabIndex = 18;
            this.btnAddUser.Text = "   New User";
            this.btnAddUser.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnAddUser.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // chckBoxShowGroups
            // 
            this.chckBoxShowGroups.AutoSize = true;
            this.chckBoxShowGroups.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chckBoxShowGroups.Location = new System.Drawing.Point(775, 57);
            this.chckBoxShowGroups.Margin = new System.Windows.Forms.Padding(0);
            this.chckBoxShowGroups.Name = "chckBoxShowGroups";
            this.chckBoxShowGroups.Padding = new System.Windows.Forms.Padding(5);
            this.chckBoxShowGroups.Size = new System.Drawing.Size(25, 24);
            this.chckBoxShowGroups.TabIndex = 1;
            this.chckBoxShowGroups.UseVisualStyleBackColor = true;
            this.chckBoxShowGroups.CheckedChanged += new System.EventHandler(this.chckBoxShowGroups_CheckedChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Image = global::Project_SIM.Properties.Resources.rotation;
            this.btnRefresh.Location = new System.Drawing.Point(1147, 45);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(124, 44);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(657, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 28);
            this.label3.TabIndex = 0;
            this.label3.Text = "Show Groups";
            // 
            // txtSearchWord
            // 
            this.txtSearchWord.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchWord.Location = new System.Drawing.Point(269, 52);
            this.txtSearchWord.Name = "txtSearchWord";
            this.txtSearchWord.Size = new System.Drawing.Size(382, 31);
            this.txtSearchWord.TabIndex = 1;
            this.txtSearchWord.TextChanged += new System.EventHandler(this.txtSearchWord_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Poppins Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(14, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(164, 34);
            this.label9.TabIndex = 17;
            this.label9.Text = "Manage Users";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Find User (Name / Username)";
            // 
            // Users
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1442, 804);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.StatusAndActionBar_None;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Users";
            this.Padding = new System.Windows.Forms.Padding(6, 0, 6, 6);
            this.Text = "Products";
            this.Load += new System.EventHandler(this.Users_Load);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.objListUsers)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        private BrightIdeasSoftware.ObjectListView objListUsers;
        private BrightIdeasSoftware.OLVColumn no;
        private BrightIdeasSoftware.OLVColumn username;
        private BrightIdeasSoftware.OLVColumn fullName;
        private BrightIdeasSoftware.OLVColumn accessLevel;
        private BrightIdeasSoftware.OLVColumn accountState;
        private BrightIdeasSoftware.OLVColumn activate;
        private BrightIdeasSoftware.OLVColumn deactivate;
        private System.Windows.Forms.CheckBox chckBoxShowGroups;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.TextBox txtSearchWord;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private BrightIdeasSoftware.OLVColumn view;
        private System.Windows.Forms.Button btnRefresh;
    }
}