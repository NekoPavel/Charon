
namespace Charon
{
    partial class Charon
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
            this.progressBar = new SmoothProgressBar.SmoothProgressBar();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.runButton = new System.Windows.Forms.Button();
            this.inputTextbox = new System.Windows.Forms.TextBox();
            this.openFileButton = new System.Windows.Forms.Button();
            this.showMoreCheckbox = new System.Windows.Forms.CheckBox();
            this.outputTextbox1 = new System.Windows.Forms.TextBox();
            this.defaultSafeprintComboBox = new System.Windows.Forms.ComboBox();
            this.safeprintSelectionLabel = new System.Windows.Forms.Label();
            this.defaultSafeprintLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.safeprintListBox = new System.Windows.Forms.CheckedListBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.outputTextbox2 = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.progressBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.progressBar.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.progressBar.Location = new System.Drawing.Point(12, 49);
            this.progressBar.Maximum = 100;
            this.progressBar.Minimum = 0;
            this.progressBar.Name = "progressBar";
            this.progressBar.ProgressBarColor = System.Drawing.Color.Blue;
            this.progressBar.Size = new System.Drawing.Size(767, 23);
            this.progressBar.TabIndex = 0;
            this.progressBar.UseWaitCursor = true;
            this.progressBar.Value = 0;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Excel Sheet|*.xlsx";
            // 
            // runButton
            // 
            this.runButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.runButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.runButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.runButton.Location = new System.Drawing.Point(785, 12);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(94, 31);
            this.runButton.TabIndex = 3;
            this.runButton.Text = "Starta";
            this.runButton.UseVisualStyleBackColor = false;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // inputTextbox
            // 
            this.inputTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.inputTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inputTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.inputTextbox.Location = new System.Drawing.Point(12, 12);
            this.inputTextbox.Name = "inputTextbox";
            this.inputTextbox.ReadOnly = true;
            this.inputTextbox.Size = new System.Drawing.Size(728, 31);
            this.inputTextbox.TabIndex = 1;
            // 
            // openFileButton
            // 
            this.openFileButton.BackgroundImage = global::Charon.Properties.Resources.icon;
            this.openFileButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.openFileButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.openFileButton.FlatAppearance.BorderSize = 0;
            this.openFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openFileButton.Location = new System.Drawing.Point(746, 12);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(33, 33);
            this.openFileButton.TabIndex = 2;
            this.openFileButton.UseVisualStyleBackColor = false;
            this.openFileButton.Click += new System.EventHandler(this.openFileButton_Click);
            // 
            // showMoreCheckbox
            // 
            this.showMoreCheckbox.Appearance = System.Windows.Forms.Appearance.Button;
            this.showMoreCheckbox.AutoSize = true;
            this.showMoreCheckbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.showMoreCheckbox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.showMoreCheckbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showMoreCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showMoreCheckbox.Location = new System.Drawing.Point(797, 49);
            this.showMoreCheckbox.Name = "showMoreCheckbox";
            this.showMoreCheckbox.Size = new System.Drawing.Size(82, 23);
            this.showMoreCheckbox.TabIndex = 4;
            this.showMoreCheckbox.Text = "▼ Visa Mer ▼";
            this.showMoreCheckbox.UseVisualStyleBackColor = false;
            this.showMoreCheckbox.CheckedChanged += new System.EventHandler(this.showMoreCheckbox_CheckedChanged);
            // 
            // outputTextbox1
            // 
            this.outputTextbox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.outputTextbox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.outputTextbox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputTextbox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.outputTextbox1.Location = new System.Drawing.Point(3, 3);
            this.outputTextbox1.Multiline = true;
            this.outputTextbox1.Name = "outputTextbox1";
            this.outputTextbox1.ReadOnly = true;
            this.outputTextbox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outputTextbox1.Size = new System.Drawing.Size(426, 338);
            this.outputTextbox1.TabIndex = 5;
            this.outputTextbox1.Visible = false;
            // 
            // defaultSafeprintComboBox
            // 
            this.defaultSafeprintComboBox.Enabled = false;
            this.defaultSafeprintComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.defaultSafeprintComboBox.FormattingEnabled = true;
            this.defaultSafeprintComboBox.Location = new System.Drawing.Point(652, 3);
            this.defaultSafeprintComboBox.Name = "defaultSafeprintComboBox";
            this.defaultSafeprintComboBox.Size = new System.Drawing.Size(212, 21);
            this.defaultSafeprintComboBox.TabIndex = 6;
            this.defaultSafeprintComboBox.Text = "Välj en:";
            // 
            // safeprintSelectionLabel
            // 
            this.safeprintSelectionLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.safeprintSelectionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.safeprintSelectionLabel.Location = new System.Drawing.Point(3, 0);
            this.safeprintSelectionLabel.Name = "safeprintSelectionLabel";
            this.safeprintSelectionLabel.Size = new System.Drawing.Size(188, 95);
            this.safeprintSelectionLabel.TabIndex = 8;
            this.safeprintSelectionLabel.Text = "Safeprint-skrivare att lägga till:";
            this.safeprintSelectionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // defaultSafeprintLabel
            // 
            this.defaultSafeprintLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.defaultSafeprintLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.defaultSafeprintLabel.Location = new System.Drawing.Point(435, 0);
            this.defaultSafeprintLabel.Name = "defaultSafeprintLabel";
            this.defaultSafeprintLabel.Size = new System.Drawing.Size(211, 93);
            this.defaultSafeprintLabel.TabIndex = 9;
            this.defaultSafeprintLabel.Text = "Safeprint-skrivare att sätta som standard om annat saknas:";
            this.defaultSafeprintLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.37601F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.45098F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.defaultSafeprintLabel, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.defaultSafeprintComboBox, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.safeprintSelectionLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.safeprintListBox, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 78);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(867, 97);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // safeprintListBox
            // 
            this.safeprintListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.safeprintListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.safeprintListBox.CheckOnClick = true;
            this.safeprintListBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.safeprintListBox.FormattingEnabled = true;
            this.safeprintListBox.Items.AddRange(new object[] {
            "NKS_Safeprint_01",
            "SäkerUtskrift_SV_Enkelsidig",
            "SäkerUtskrift_SV_Dubbelsidig",
            "SOS_SU_MFP_SV_D_01",
            "DAN_SU_MFP_SV_D_01",
            "KAR_SU_MFP_SV_D_01"});
            this.safeprintListBox.Location = new System.Drawing.Point(197, 3);
            this.safeprintListBox.Name = "safeprintListBox";
            this.safeprintListBox.Size = new System.Drawing.Size(169, 90);
            this.safeprintListBox.TabIndex = 11;
            this.safeprintListBox.SelectedIndexChanged += new System.EventHandler(this.safeprintListBox_SelectedIndexChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.outputTextbox2, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.outputTextbox1, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 181);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(864, 344);
            this.tableLayoutPanel2.TabIndex = 11;
            // 
            // outputTextbox2
            // 
            this.outputTextbox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.outputTextbox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.outputTextbox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputTextbox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.outputTextbox2.Location = new System.Drawing.Point(435, 3);
            this.outputTextbox2.Multiline = true;
            this.outputTextbox2.Name = "outputTextbox2";
            this.outputTextbox2.ReadOnly = true;
            this.outputTextbox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outputTextbox2.Size = new System.Drawing.Size(426, 338);
            this.outputTextbox2.TabIndex = 6;
            this.outputTextbox2.Visible = false;
            // 
            // Charon
            // 
            this.AcceptButton = this.runButton;
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.ClientSize = new System.Drawing.Size(884, 181);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.showMoreCheckbox);
            this.Controls.Add(this.openFileButton);
            this.Controls.Add(this.inputTextbox);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.progressBar);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Charon";
            this.ShowIcon = false;
            this.Text = "Charon";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.SFFS_DragDrop);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.SFFS_DragOver);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SmoothProgressBar.SmoothProgressBar progressBar;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.TextBox inputTextbox;
        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.CheckBox showMoreCheckbox;
        private System.Windows.Forms.TextBox outputTextbox1;
        private System.Windows.Forms.ComboBox defaultSafeprintComboBox;
        private System.Windows.Forms.Label safeprintSelectionLabel;
        private System.Windows.Forms.Label defaultSafeprintLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckedListBox safeprintListBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox outputTextbox2;
    }
}

