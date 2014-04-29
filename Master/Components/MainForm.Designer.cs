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
            this.liveCheckBox = new System.Windows.Forms.CheckBox();
            this.updateGraphTimer = new System.Windows.Forms.Timer(this.components);
            this.AutoResizeCheckBox = new System.Windows.Forms.CheckBox();
            this.newDataButton = new System.Windows.Forms.Button();
            this.clearGraphButton = new System.Windows.Forms.Button();
            this.agentOffRadioButton = new System.Windows.Forms.RadioButton();
            this.agentRandomRadioButton = new System.Windows.Forms.RadioButton();
            this.agentOnRadioButton = new System.Windows.Forms.RadioButton();
            this.AgentStateLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.updateCOMTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
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
            this.openButton.Location = new System.Drawing.Point(93, 427);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(75, 23);
            this.openButton.TabIndex = 0;
            this.openButton.Text = "Open";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(174, 427);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // outputTextbox
            // 
            this.outputTextbox.Location = new System.Drawing.Point(13, 12);
            this.outputTextbox.Multiline = true;
            this.outputTextbox.Name = "outputTextbox";
            this.outputTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outputTextbox.Size = new System.Drawing.Size(285, 371);
            this.outputTextbox.TabIndex = 2;
            // 
            // outputLabel
            // 
            this.outputLabel.AutoSize = true;
            this.outputLabel.Location = new System.Drawing.Point(12, 390);
            this.outputLabel.Name = "outputLabel";
            this.outputLabel.Size = new System.Drawing.Size(42, 13);
            this.outputLabel.TabIndex = 3;
            this.outputLabel.Text = "Output:";
            // 
            // showDataRadioButton
            // 
            this.showDataRadioButton.AutoSize = true;
            this.showDataRadioButton.Location = new System.Drawing.Point(129, 390);
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
            this.showConsoleRadioButton.Location = new System.Drawing.Point(60, 390);
            this.showConsoleRadioButton.Name = "showConsoleRadioButton";
            this.showConsoleRadioButton.Size = new System.Drawing.Size(63, 17);
            this.showConsoleRadioButton.TabIndex = 5;
            this.showConsoleRadioButton.Text = "Console";
            this.showConsoleRadioButton.UseVisualStyleBackColor = true;
            this.showConsoleRadioButton.CheckedChanged += new System.EventHandler(this.showConsoleRadioButton_CheckedChanged);
            // 
            // graphControl
            // 
            this.graphControl.IsEnableHEdit = true;
            this.graphControl.IsEnableSelection = true;
            this.graphControl.IsEnableVEdit = true;
            this.graphControl.IsPrintFillPage = false;
            this.graphControl.IsPrintKeepAspectRatio = false;
            this.graphControl.IsPrintScaleAll = false;
            this.graphControl.IsShowHScrollBar = true;
            this.graphControl.IsShowVScrollBar = true;
            this.graphControl.Location = new System.Drawing.Point(305, 12);
            this.graphControl.Name = "graphControl";
            this.graphControl.ScrollGrace = 0D;
            this.graphControl.ScrollMaxX = 0D;
            this.graphControl.ScrollMaxY = 0D;
            this.graphControl.ScrollMaxY2 = 0D;
            this.graphControl.ScrollMinX = 0D;
            this.graphControl.ScrollMinY = 0D;
            this.graphControl.ScrollMinY2 = 0D;
            this.graphControl.Size = new System.Drawing.Size(464, 438);
            this.graphControl.TabIndex = 6;
            // 
            // drawButton
            // 
            this.drawButton.Location = new System.Drawing.Point(775, 247);
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
            this.PacketListBox.Location = new System.Drawing.Point(775, 25);
            this.PacketListBox.Name = "PacketListBox";
            this.PacketListBox.Size = new System.Drawing.Size(95, 30);
            this.PacketListBox.TabIndex = 8;
            this.PacketListBox.SelectedIndexChanged += new System.EventHandler(this.PacketListBox_SelectedIndexChanged);
            // 
            // featureListBox
            // 
            this.featureListBox.FormattingEnabled = true;
            this.featureListBox.Location = new System.Drawing.Point(775, 61);
            this.featureListBox.Name = "featureListBox";
            this.featureListBox.Size = new System.Drawing.Size(95, 134);
            this.featureListBox.TabIndex = 9;
            this.featureListBox.SelectedIndexChanged += new System.EventHandler(this.featureListBox_SelectedIndexChanged);
            // 
            // showNothingRadioButton
            // 
            this.showNothingRadioButton.AutoSize = true;
            this.showNothingRadioButton.Checked = true;
            this.showNothingRadioButton.Location = new System.Drawing.Point(183, 390);
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
            this.displayGraphLabel.Location = new System.Drawing.Point(775, 9);
            this.displayGraphLabel.Name = "displayGraphLabel";
            this.displayGraphLabel.Size = new System.Drawing.Size(44, 13);
            this.displayGraphLabel.TabIndex = 11;
            this.displayGraphLabel.Text = "Display:";
            // 
            // liveCheckBox
            // 
            this.liveCheckBox.AutoSize = true;
            this.liveCheckBox.Checked = true;
            this.liveCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.liveCheckBox.Location = new System.Drawing.Point(775, 224);
            this.liveCheckBox.Name = "liveCheckBox";
            this.liveCheckBox.Size = new System.Drawing.Size(46, 17);
            this.liveCheckBox.TabIndex = 12;
            this.liveCheckBox.Text = "Live";
            this.liveCheckBox.UseVisualStyleBackColor = true;
            this.liveCheckBox.CheckedChanged += new System.EventHandler(this.liveCheckBox_CheckedChanged);
            // 
            // updateGraphTimer
            // 
            this.updateGraphTimer.Enabled = true;
            this.updateGraphTimer.Interval = 1000;
            this.updateGraphTimer.Tick += new System.EventHandler(this.updateGraphTimer_Tick);
            // 
            // AutoResizeCheckBox
            // 
            this.AutoResizeCheckBox.AutoSize = true;
            this.AutoResizeCheckBox.Checked = true;
            this.AutoResizeCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AutoResizeCheckBox.Location = new System.Drawing.Point(775, 201);
            this.AutoResizeCheckBox.Name = "AutoResizeCheckBox";
            this.AutoResizeCheckBox.Size = new System.Drawing.Size(78, 17);
            this.AutoResizeCheckBox.TabIndex = 13;
            this.AutoResizeCheckBox.Text = "Auto resize";
            this.AutoResizeCheckBox.UseVisualStyleBackColor = true;
            this.AutoResizeCheckBox.CheckedChanged += new System.EventHandler(this.AutoResizeCheckBox_CheckedChanged);
            // 
            // newDataButton
            // 
            this.newDataButton.Location = new System.Drawing.Point(12, 427);
            this.newDataButton.Name = "newDataButton";
            this.newDataButton.Size = new System.Drawing.Size(75, 23);
            this.newDataButton.TabIndex = 14;
            this.newDataButton.Text = "New";
            this.newDataButton.UseVisualStyleBackColor = true;
            this.newDataButton.Click += new System.EventHandler(this.newDataButton_Click);
            // 
            // clearGraphButton
            // 
            this.clearGraphButton.Location = new System.Drawing.Point(775, 277);
            this.clearGraphButton.Name = "clearGraphButton";
            this.clearGraphButton.Size = new System.Drawing.Size(95, 23);
            this.clearGraphButton.TabIndex = 15;
            this.clearGraphButton.Text = "Clear";
            this.clearGraphButton.UseVisualStyleBackColor = true;
            this.clearGraphButton.Click += new System.EventHandler(this.clearGraphButton_Click);
            // 
            // agentOffRadioButton
            // 
            this.agentOffRadioButton.AutoSize = true;
            this.agentOffRadioButton.Checked = true;
            this.agentOffRadioButton.Location = new System.Drawing.Point(6, 20);
            this.agentOffRadioButton.Name = "agentOffRadioButton";
            this.agentOffRadioButton.Size = new System.Drawing.Size(39, 17);
            this.agentOffRadioButton.TabIndex = 16;
            this.agentOffRadioButton.TabStop = true;
            this.agentOffRadioButton.Text = "Off";
            this.agentOffRadioButton.UseVisualStyleBackColor = true;
            this.agentOffRadioButton.CheckedChanged += new System.EventHandler(this.agentOffRadioButton_CheckedChanged);
            // 
            // agentRandomRadioButton
            // 
            this.agentRandomRadioButton.AutoSize = true;
            this.agentRandomRadioButton.Location = new System.Drawing.Point(6, 43);
            this.agentRandomRadioButton.Name = "agentRandomRadioButton";
            this.agentRandomRadioButton.Size = new System.Drawing.Size(65, 17);
            this.agentRandomRadioButton.TabIndex = 17;
            this.agentRandomRadioButton.Text = "Random";
            this.agentRandomRadioButton.UseVisualStyleBackColor = true;
            this.agentRandomRadioButton.CheckedChanged += new System.EventHandler(this.agentRandomRadioButton_CheckedChanged);
            // 
            // agentOnRadioButton
            // 
            this.agentOnRadioButton.AutoSize = true;
            this.agentOnRadioButton.Location = new System.Drawing.Point(6, 66);
            this.agentOnRadioButton.Name = "agentOnRadioButton";
            this.agentOnRadioButton.Size = new System.Drawing.Size(39, 17);
            this.agentOnRadioButton.TabIndex = 18;
            this.agentOnRadioButton.Text = "On";
            this.agentOnRadioButton.UseVisualStyleBackColor = true;
            this.agentOnRadioButton.CheckedChanged += new System.EventHandler(this.agentOnRadioButton_CheckedChanged);
            // 
            // AgentStateLabel
            // 
            this.AgentStateLabel.AutoSize = true;
            this.AgentStateLabel.Location = new System.Drawing.Point(3, 4);
            this.AgentStateLabel.Name = "AgentStateLabel";
            this.AgentStateLabel.Size = new System.Drawing.Size(71, 13);
            this.AgentStateLabel.TabIndex = 19;
            this.AgentStateLabel.Text = "Agent\'s state:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.AgentStateLabel);
            this.panel1.Controls.Add(this.agentOffRadioButton);
            this.panel1.Controls.Add(this.agentOnRadioButton);
            this.panel1.Controls.Add(this.agentRandomRadioButton);
            this.panel1.Location = new System.Drawing.Point(775, 361);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(95, 85);
            this.panel1.TabIndex = 20;
            // 
            // updateCOMTimer
            // 
            this.updateCOMTimer.Enabled = true;
            this.updateCOMTimer.Interval = 1000;
            this.updateCOMTimer.Tick += new System.EventHandler(this.updateCOMTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 458);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.clearGraphButton);
            this.Controls.Add(this.newDataButton);
            this.Controls.Add(this.AutoResizeCheckBox);
            this.Controls.Add(this.liveCheckBox);
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
            this.Text = "Master";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.CheckBox liveCheckBox;
        private System.Windows.Forms.Timer updateGraphTimer;
        private System.Windows.Forms.CheckBox AutoResizeCheckBox;
        private System.Windows.Forms.Button newDataButton;
        private System.Windows.Forms.Button clearGraphButton;
        private System.Windows.Forms.RadioButton agentOffRadioButton;
        private System.Windows.Forms.RadioButton agentRandomRadioButton;
        private System.Windows.Forms.RadioButton agentOnRadioButton;
        private System.Windows.Forms.Label AgentStateLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer updateCOMTimer;

    }
}