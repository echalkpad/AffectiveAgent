namespace Master
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
            this.components = new System.ComponentModel.Container();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.outputTextbox = new System.Windows.Forms.TextBox();
            this.outputLabel = new System.Windows.Forms.Label();
            this.showDataRadioButton = new System.Windows.Forms.RadioButton();
            this.showConsoleRadioButton = new System.Windows.Forms.RadioButton();
            this.graphControl = new ZedGraph.ZedGraphControl();
            this.drawButton = new System.Windows.Forms.Button();
            this.PacketListBox = new System.Windows.Forms.ListBox();
            this.featureListBox = new System.Windows.Forms.ListBox();
            this.showNothingRadioButton = new System.Windows.Forms.RadioButton();
            this.displayGraphLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog_FileOk);
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(12, 406);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(75, 23);
            this.openButton.TabIndex = 0;
            this.openButton.Text = "Open";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(93, 406);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // outputTextbox
            // 
            this.outputTextbox.Location = new System.Drawing.Point(13, 29);
            this.outputTextbox.Multiline = true;
            this.outputTextbox.Name = "outputTextbox";
            this.outputTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outputTextbox.Size = new System.Drawing.Size(285, 371);
            this.outputTextbox.TabIndex = 2;
            // 
            // outputLabel
            // 
            this.outputLabel.AutoSize = true;
            this.outputLabel.Location = new System.Drawing.Point(12, 11);
            this.outputLabel.Name = "outputLabel";
            this.outputLabel.Size = new System.Drawing.Size(42, 13);
            this.outputLabel.TabIndex = 3;
            this.outputLabel.Text = "Output:";
            // 
            // showDataRadioButton
            // 
            this.showDataRadioButton.AutoSize = true;
            this.showDataRadioButton.Location = new System.Drawing.Point(182, 9);
            this.showDataRadioButton.Name = "showDataRadioButton";
            this.showDataRadioButton.Size = new System.Drawing.Size(48, 17);
            this.showDataRadioButton.TabIndex = 4;
            this.showDataRadioButton.TabStop = true;
            this.showDataRadioButton.Text = "Data";
            this.showDataRadioButton.UseVisualStyleBackColor = true;
            this.showDataRadioButton.CheckedChanged += new System.EventHandler(this.showDataRadioButton_CheckedChanged);
            // 
            // showConsoleRadioButton
            // 
            this.showConsoleRadioButton.AutoSize = true;
            this.showConsoleRadioButton.Checked = true;
            this.showConsoleRadioButton.Location = new System.Drawing.Point(113, 9);
            this.showConsoleRadioButton.Name = "showConsoleRadioButton";
            this.showConsoleRadioButton.Size = new System.Drawing.Size(63, 17);
            this.showConsoleRadioButton.TabIndex = 5;
            this.showConsoleRadioButton.TabStop = true;
            this.showConsoleRadioButton.Text = "Console";
            this.showConsoleRadioButton.UseVisualStyleBackColor = true;
            this.showConsoleRadioButton.CheckedChanged += new System.EventHandler(this.showConsoleRadioButton_CheckedChanged);
            // 
            // graphControl
            // 
            this.graphControl.Location = new System.Drawing.Point(305, 29);
            this.graphControl.Name = "graphControl";
            this.graphControl.ScrollGrace = 0D;
            this.graphControl.ScrollMaxX = 0D;
            this.graphControl.ScrollMaxY = 0D;
            this.graphControl.ScrollMaxY2 = 0D;
            this.graphControl.ScrollMinX = 0D;
            this.graphControl.ScrollMinY = 0D;
            this.graphControl.ScrollMinY2 = 0D;
            this.graphControl.Size = new System.Drawing.Size(464, 371);
            this.graphControl.TabIndex = 6;
            // 
            // drawButton
            // 
            this.drawButton.Location = new System.Drawing.Point(775, 143);
            this.drawButton.Name = "drawButton";
            this.drawButton.Size = new System.Drawing.Size(95, 23);
            this.drawButton.TabIndex = 7;
            this.drawButton.Text = "Draw!";
            this.drawButton.UseVisualStyleBackColor = true;
            this.drawButton.Click += new System.EventHandler(this.drawButton_Click);
            // 
            // PacketListBox
            // 
            this.PacketListBox.FormattingEnabled = true;
            this.PacketListBox.Items.AddRange(new object[] {
            "Audio packets",
            "Video packets"});
            this.PacketListBox.Location = new System.Drawing.Point(775, 45);
            this.PacketListBox.Name = "PacketListBox";
            this.PacketListBox.Size = new System.Drawing.Size(95, 30);
            this.PacketListBox.TabIndex = 8;
            this.PacketListBox.SelectedIndexChanged += new System.EventHandler(this.PacketListBox_SelectedIndexChanged);
            // 
            // featureListBox
            // 
            this.featureListBox.FormattingEnabled = true;
            this.featureListBox.Location = new System.Drawing.Point(775, 81);
            this.featureListBox.Name = "featureListBox";
            this.featureListBox.Size = new System.Drawing.Size(95, 56);
            this.featureListBox.TabIndex = 9;
            // 
            // showNothingRadioButton
            // 
            this.showNothingRadioButton.AutoSize = true;
            this.showNothingRadioButton.Location = new System.Drawing.Point(236, 9);
            this.showNothingRadioButton.Name = "showNothingRadioButton";
            this.showNothingRadioButton.Size = new System.Drawing.Size(62, 17);
            this.showNothingRadioButton.TabIndex = 10;
            this.showNothingRadioButton.TabStop = true;
            this.showNothingRadioButton.Text = "Nothing";
            this.showNothingRadioButton.UseVisualStyleBackColor = true;
            this.showNothingRadioButton.CheckedChanged += new System.EventHandler(this.showNothingRadioButton_CheckedChanged);
            // 
            // displayGraphLabel
            // 
            this.displayGraphLabel.AutoSize = true;
            this.displayGraphLabel.Location = new System.Drawing.Point(775, 29);
            this.displayGraphLabel.Name = "displayGraphLabel";
            this.displayGraphLabel.Size = new System.Drawing.Size(44, 13);
            this.displayGraphLabel.TabIndex = 11;
            this.displayGraphLabel.Text = "Display:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 458);
            this.Controls.Add(this.displayGraphLabel);
            this.Controls.Add(this.showNothingRadioButton);
            this.Controls.Add(this.featureListBox);
            this.Controls.Add(this.PacketListBox);
            this.Controls.Add(this.drawButton);
            this.Controls.Add(this.graphControl);
            this.Controls.Add(this.showConsoleRadioButton);
            this.Controls.Add(this.showDataRadioButton);
            this.Controls.Add(this.outputLabel);
            this.Controls.Add(this.outputTextbox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.openButton);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox outputTextbox;
        private System.Windows.Forms.Label outputLabel;
        private System.Windows.Forms.RadioButton showDataRadioButton;
        private System.Windows.Forms.RadioButton showConsoleRadioButton;
        private ZedGraph.ZedGraphControl graphControl;
        private System.Windows.Forms.Button drawButton;
        private System.Windows.Forms.ListBox PacketListBox;
        private System.Windows.Forms.ListBox featureListBox;
        private System.Windows.Forms.RadioButton showNothingRadioButton;
        private System.Windows.Forms.Label displayGraphLabel;

    }
}