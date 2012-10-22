namespace AppendPrependInMethod
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
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.cboxMethod = new System.Windows.Forms.CheckedListBox();
            this.txtPrepend = new System.Windows.Forms.TextBox();
            this.txtAppend = new System.Windows.Forms.TextBox();
            this.lblFilePath = new System.Windows.Forms.Label();
            this.lblMethods = new System.Windows.Forms.Label();
            this.lblPrepend = new System.Windows.Forms.Label();
            this.lblAppend = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(60, 13);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(306, 20);
            this.txtFilePath.TabIndex = 0;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(373, 10);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // cboxMethod
            // 
            this.cboxMethod.FormattingEnabled = true;
            this.cboxMethod.Location = new System.Drawing.Point(60, 50);
            this.cboxMethod.Name = "cboxMethod";
            this.cboxMethod.Size = new System.Drawing.Size(388, 94);
            this.cboxMethod.TabIndex = 2;
            // 
            // txtPrepend
            // 
            this.txtPrepend.Location = new System.Drawing.Point(60, 151);
            this.txtPrepend.Multiline = true;
            this.txtPrepend.Name = "txtPrepend";
            this.txtPrepend.Size = new System.Drawing.Size(388, 101);
            this.txtPrepend.TabIndex = 3;
            this.txtPrepend.Text = "try\r\n{";
            // 
            // txtAppend
            // 
            this.txtAppend.Location = new System.Drawing.Point(60, 259);
            this.txtAppend.Multiline = true;
            this.txtAppend.Name = "txtAppend";
            this.txtAppend.Size = new System.Drawing.Size(388, 119);
            this.txtAppend.TabIndex = 4;
            this.txtAppend.Text = "}\r\ncatch\r\n{\r\n\r\n}";
            // 
            // lblFilePath
            // 
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Location = new System.Drawing.Point(4, 13);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(45, 13);
            this.lblFilePath.TabIndex = 5;
            this.lblFilePath.Text = "FilePath";
            // 
            // lblMethods
            // 
            this.lblMethods.AutoSize = true;
            this.lblMethods.Location = new System.Drawing.Point(4, 50);
            this.lblMethods.Name = "lblMethods";
            this.lblMethods.Size = new System.Drawing.Size(48, 13);
            this.lblMethods.TabIndex = 6;
            this.lblMethods.Text = "Methods";
            // 
            // lblPrepend
            // 
            this.lblPrepend.AutoSize = true;
            this.lblPrepend.Location = new System.Drawing.Point(4, 151);
            this.lblPrepend.Name = "lblPrepend";
            this.lblPrepend.Size = new System.Drawing.Size(47, 13);
            this.lblPrepend.TabIndex = 7;
            this.lblPrepend.Text = "Prepend";
            // 
            // lblAppend
            // 
            this.lblAppend.AutoSize = true;
            this.lblAppend.Location = new System.Drawing.Point(4, 259);
            this.lblAppend.Name = "lblAppend";
            this.lblAppend.Size = new System.Drawing.Size(44, 13);
            this.lblAppend.TabIndex = 8;
            this.lblAppend.Text = "Append";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(60, 385);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(388, 30);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "ADD && SAVE";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 418);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblAppend);
            this.Controls.Add(this.lblPrepend);
            this.Controls.Add(this.lblMethods);
            this.Controls.Add(this.lblFilePath);
            this.Controls.Add(this.txtAppend);
            this.Controls.Add(this.txtPrepend);
            this.Controls.Add(this.cboxMethod);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtFilePath);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Append Prepend In Method";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.CheckedListBox cboxMethod;
        private System.Windows.Forms.TextBox txtPrepend;
        private System.Windows.Forms.TextBox txtAppend;
        private System.Windows.Forms.Label lblFilePath;
        private System.Windows.Forms.Label lblMethods;
        private System.Windows.Forms.Label lblPrepend;
        private System.Windows.Forms.Label lblAppend;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

