namespace CodeFirstApp
{
    partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.houseTypeComboBox = new System.Windows.Forms.ComboBox();
            this.housesDataGridView = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.areaTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.countTextBox = new System.Windows.Forms.TextBox();
            this.acquireButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.housesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome Owner";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "House Type:";
            // 
            // houseTypeComboBox
            // 
            this.houseTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.houseTypeComboBox.FormattingEnabled = true;
            this.houseTypeComboBox.Items.AddRange(new object[] {
            "Apartment",
            "Bungalow"});
            this.houseTypeComboBox.Location = new System.Drawing.Point(110, 56);
            this.houseTypeComboBox.Name = "houseTypeComboBox";
            this.houseTypeComboBox.Size = new System.Drawing.Size(218, 21);
            this.houseTypeComboBox.TabIndex = 2;
            this.houseTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.houseTypeComboBox_SelectedIndexChanged);
            // 
            // housesDataGridView
            // 
            this.housesDataGridView.AllowUserToAddRows = false;
            this.housesDataGridView.AllowUserToDeleteRows = false;
            this.housesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.housesDataGridView.Location = new System.Drawing.Point(16, 83);
            this.housesDataGridView.Name = "housesDataGridView";
            this.housesDataGridView.ReadOnly = true;
            this.housesDataGridView.RowHeadersVisible = false;
            this.housesDataGridView.Size = new System.Drawing.Size(312, 123);
            this.housesDataGridView.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 227);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Area:";
            // 
            // areaTextBox
            // 
            this.areaTextBox.Location = new System.Drawing.Point(110, 224);
            this.areaTextBox.Name = "areaTextBox";
            this.areaTextBox.Size = new System.Drawing.Size(218, 20);
            this.areaTextBox.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 253);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Floor(s):";
            // 
            // countTextBox
            // 
            this.countTextBox.Location = new System.Drawing.Point(110, 250);
            this.countTextBox.Name = "countTextBox";
            this.countTextBox.Size = new System.Drawing.Size(147, 20);
            this.countTextBox.TabIndex = 7;
            // 
            // acquireButton
            // 
            this.acquireButton.Location = new System.Drawing.Point(264, 248);
            this.acquireButton.Name = "acquireButton";
            this.acquireButton.Size = new System.Drawing.Size(64, 23);
            this.acquireButton.TabIndex = 8;
            this.acquireButton.Text = "Acquire";
            this.acquireButton.UseVisualStyleBackColor = true;
            this.acquireButton.Click += new System.EventHandler(this.acquireButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 294);
            this.Controls.Add(this.acquireButton);
            this.Controls.Add(this.countTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.areaTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.housesDataGridView);
            this.Controls.Add(this.houseTypeComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CodeFirstApp";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.housesDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox houseTypeComboBox;
        private System.Windows.Forms.DataGridView housesDataGridView;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox areaTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox countTextBox;
        private System.Windows.Forms.Button acquireButton;
    }
}

