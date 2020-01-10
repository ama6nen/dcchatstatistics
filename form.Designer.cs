namespace chtparse
{
    partial class main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if (disposing && (components != null))
            {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.UsersBox = new System.Windows.Forms.RichTextBox();
            this.WordsBox = new System.Windows.Forms.RichTextBox();
            this.BrowseFile = new System.Windows.Forms.Button();
            this.FileToAnalyze = new System.Windows.Forms.TextBox();
            this.FileDialog = new System.Windows.Forms.OpenFileDialog();
            this.AnalyzeButton = new System.Windows.Forms.Button();
            this.AnalysisBar = new System.Windows.Forms.ProgressBar();
            this.paretoLabel = new System.Windows.Forms.Label();
            this.ParetoContent = new System.Windows.Forms.Label();
            this.IgnoreLinks = new System.Windows.Forms.CheckBox();
            this.SkipThreshold = new System.Windows.Forms.NumericUpDown();
            this.SkipThresholdLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.IndividualGroupbox = new System.Windows.Forms.GroupBox();
            this.SearchResult = new System.Windows.Forms.Label();
            this.SearchWordButton = new System.Windows.Forms.Button();
            this.SearchWord = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.SkipThreshold)).BeginInit();
            this.IndividualGroupbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // UsersBox
            // 
            this.UsersBox.Location = new System.Drawing.Point(11, 137);
            this.UsersBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.UsersBox.Name = "UsersBox";
            this.UsersBox.Size = new System.Drawing.Size(203, 227);
            this.UsersBox.TabIndex = 0;
            this.UsersBox.Text = "";
            // 
            // WordsBox
            // 
            this.WordsBox.Location = new System.Drawing.Point(220, 137);
            this.WordsBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.WordsBox.Name = "WordsBox";
            this.WordsBox.Size = new System.Drawing.Size(203, 227);
            this.WordsBox.TabIndex = 1;
            this.WordsBox.Text = "";
            // 
            // BrowseFile
            // 
            this.BrowseFile.Location = new System.Drawing.Point(346, 11);
            this.BrowseFile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BrowseFile.Name = "BrowseFile";
            this.BrowseFile.Size = new System.Drawing.Size(74, 26);
            this.BrowseFile.TabIndex = 3;
            this.BrowseFile.Text = "Browse";
            this.BrowseFile.UseVisualStyleBackColor = true;
            this.BrowseFile.Click += new System.EventHandler(this.BrowseFile_Click);
            // 
            // FileToAnalyze
            // 
            this.FileToAnalyze.AllowDrop = true;
            this.FileToAnalyze.Location = new System.Drawing.Point(14, 13);
            this.FileToAnalyze.Name = "FileToAnalyze";
            this.FileToAnalyze.Size = new System.Drawing.Size(326, 25);
            this.FileToAnalyze.TabIndex = 4;
            this.FileToAnalyze.TextChanged += new System.EventHandler(this.FileToAnalyze_TextChanged);
            this.FileToAnalyze.DragDrop += new System.Windows.Forms.DragEventHandler(this.FileToAnalyze_DragDrop);
            this.FileToAnalyze.DragEnter += new System.Windows.Forms.DragEventHandler(this.FileToAnalyze_DragEnter);
            // 
            // FileDialog
            // 
            this.FileDialog.Filter = "Discord exported chat files|*.txt";
            // 
            // AnalyzeButton
            // 
            this.AnalyzeButton.Location = new System.Drawing.Point(14, 41);
            this.AnalyzeButton.Name = "AnalyzeButton";
            this.AnalyzeButton.Size = new System.Drawing.Size(84, 26);
            this.AnalyzeButton.TabIndex = 5;
            this.AnalyzeButton.Text = "Analyze";
            this.AnalyzeButton.UseVisualStyleBackColor = true;
            this.AnalyzeButton.Click += new System.EventHandler(this.AnalyzeButton_Click);
            // 
            // AnalysisBar
            // 
            this.AnalysisBar.Location = new System.Drawing.Point(104, 41);
            this.AnalysisBar.MarqueeAnimationSpeed = 0;
            this.AnalysisBar.Name = "AnalysisBar";
            this.AnalysisBar.Size = new System.Drawing.Size(316, 26);
            this.AnalysisBar.TabIndex = 6;
            this.AnalysisBar.Visible = false;
            // 
            // paretoLabel
            // 
            this.paretoLabel.AutoSize = true;
            this.paretoLabel.Location = new System.Drawing.Point(12, 70);
            this.paretoLabel.Name = "paretoLabel";
            this.paretoLabel.Size = new System.Drawing.Size(99, 17);
            this.paretoLabel.TabIndex = 7;
            this.paretoLabel.Text = "Pareto Principle";
            // 
            // ParetoContent
            // 
            this.ParetoContent.AutoSize = true;
            this.ParetoContent.Location = new System.Drawing.Point(117, 70);
            this.ParetoContent.Name = "ParetoContent";
            this.ParetoContent.Size = new System.Drawing.Size(53, 17);
            this.ParetoContent.TabIndex = 8;
            this.ParetoContent.Text = "PARETO";
            // 
            // IgnoreLinks
            // 
            this.IgnoreLinks.AutoSize = true;
            this.IgnoreLinks.Checked = true;
            this.IgnoreLinks.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IgnoreLinks.Location = new System.Drawing.Point(104, 41);
            this.IgnoreLinks.Name = "IgnoreLinks";
            this.IgnoreLinks.Size = new System.Drawing.Size(94, 21);
            this.IgnoreLinks.TabIndex = 9;
            this.IgnoreLinks.Text = "Ignore links";
            this.IgnoreLinks.UseVisualStyleBackColor = true;
            // 
            // SkipThreshold
            // 
            this.SkipThreshold.Location = new System.Drawing.Point(204, 40);
            this.SkipThreshold.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.SkipThreshold.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.SkipThreshold.Name = "SkipThreshold";
            this.SkipThreshold.Size = new System.Drawing.Size(59, 25);
            this.SkipThreshold.TabIndex = 10;
            this.SkipThreshold.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // SkipThresholdLabel
            // 
            this.SkipThresholdLabel.AutoSize = true;
            this.SkipThresholdLabel.Location = new System.Drawing.Point(269, 42);
            this.SkipThresholdLabel.Name = "SkipThresholdLabel";
            this.SkipThresholdLabel.Size = new System.Drawing.Size(148, 17);
            this.SkipThresholdLabel.TabIndex = 11;
            this.SkipThresholdLabel.Text = "Skip if less than x words";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Messages sent by users";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(221, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "Words by usage";
            // 
            // IndividualGroupbox
            // 
            this.IndividualGroupbox.Controls.Add(this.SearchResult);
            this.IndividualGroupbox.Controls.Add(this.SearchWordButton);
            this.IndividualGroupbox.Controls.Add(this.SearchWord);
            this.IndividualGroupbox.Location = new System.Drawing.Point(11, 371);
            this.IndividualGroupbox.Name = "IndividualGroupbox";
            this.IndividualGroupbox.Size = new System.Drawing.Size(406, 63);
            this.IndividualGroupbox.TabIndex = 15;
            this.IndividualGroupbox.TabStop = false;
            this.IndividualGroupbox.Text = "Search individual word data";
            // 
            // SearchResult
            // 
            this.SearchResult.AutoSize = true;
            this.SearchResult.Location = new System.Drawing.Point(239, 24);
            this.SearchResult.Name = "SearchResult";
            this.SearchResult.Size = new System.Drawing.Size(63, 17);
            this.SearchResult.TabIndex = 2;
            this.SearchResult.Text = "SEARCHR";
            // 
            // SearchWordButton
            // 
            this.SearchWordButton.Location = new System.Drawing.Point(154, 24);
            this.SearchWordButton.Name = "SearchWordButton";
            this.SearchWordButton.Size = new System.Drawing.Size(79, 26);
            this.SearchWordButton.TabIndex = 1;
            this.SearchWordButton.Text = "Search";
            this.SearchWordButton.UseVisualStyleBackColor = true;
            this.SearchWordButton.Click += new System.EventHandler(this.SearchWordButton_Click);
            // 
            // SearchWord
            // 
            this.SearchWord.Location = new System.Drawing.Point(21, 24);
            this.SearchWord.Name = "SearchWord";
            this.SearchWord.Size = new System.Drawing.Size(127, 25);
            this.SearchWord.TabIndex = 0;
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 439);
            this.Controls.Add(this.IndividualGroupbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SkipThresholdLabel);
            this.Controls.Add(this.SkipThreshold);
            this.Controls.Add(this.IgnoreLinks);
            this.Controls.Add(this.ParetoContent);
            this.Controls.Add(this.paretoLabel);
            this.Controls.Add(this.AnalysisBar);
            this.Controls.Add(this.AnalyzeButton);
            this.Controls.Add(this.FileToAnalyze);
            this.Controls.Add(this.BrowseFile);
            this.Controls.Add(this.WordsBox);
            this.Controls.Add(this.UsersBox);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "main";
            this.ShowIcon = false;
            this.Text = "Discord Chat Statistics Analyzer";
            ((System.ComponentModel.ISupportInitialize)(this.SkipThreshold)).EndInit();
            this.IndividualGroupbox.ResumeLayout(false);
            this.IndividualGroupbox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox UsersBox;
        private System.Windows.Forms.RichTextBox WordsBox;
        private System.Windows.Forms.Button BrowseFile;
        private System.Windows.Forms.TextBox FileToAnalyze;
        private System.Windows.Forms.OpenFileDialog FileDialog;
        private System.Windows.Forms.Button AnalyzeButton;
        private System.Windows.Forms.ProgressBar AnalysisBar;
        private System.Windows.Forms.Label paretoLabel;
        private System.Windows.Forms.Label ParetoContent;
        private System.Windows.Forms.CheckBox IgnoreLinks;
        private System.Windows.Forms.NumericUpDown SkipThreshold;
        private System.Windows.Forms.Label SkipThresholdLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox IndividualGroupbox;
        private System.Windows.Forms.TextBox SearchWord;
        private System.Windows.Forms.Button SearchWordButton;
        private System.Windows.Forms.Label SearchResult;
    }
}

