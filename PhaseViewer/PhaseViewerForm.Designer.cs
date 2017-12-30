namespace PhaseViewer
{
	partial class PhaseViewerForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PhaseViewerForm));
			this.buttonShowAllPhases = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.buttonShowPhase = new System.Windows.Forms.Button();
			this.dataGridViewPhases = new System.Windows.Forms.DataGridView();
			this.buttonHidePhase = new System.Windows.Forms.Button();
			this.buttonResetViews = new System.Windows.Forms.Button();
			this.checkBoxMainParts = new System.Windows.Forms.CheckBox();
			this.checkBoxSecondaryParts = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewPhases)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonShowAllPhases
			// 
			this.buttonShowAllPhases.Location = new System.Drawing.Point(482, 134);
			this.buttonShowAllPhases.Name = "buttonShowAllPhases";
			this.buttonShowAllPhases.Size = new System.Drawing.Size(151, 33);
			this.buttonShowAllPhases.TabIndex = 27;
			this.buttonShowAllPhases.Text = "Show All Phases";
			this.buttonShowAllPhases.UseVisualStyleBackColor = true;
			this.buttonShowAllPhases.Click += new System.EventHandler(this.buttonShowAllPhases_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 74);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(55, 17);
			this.label1.TabIndex = 26;
			this.label1.Text = "Phases";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::PhaseViewer.Properties.Resources.Logo;
			this.pictureBox1.Location = new System.Drawing.Point(12, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(160, 41);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 25;
			this.pictureBox1.TabStop = false;
			// 
			// buttonShowPhase
			// 
			this.buttonShowPhase.Location = new System.Drawing.Point(482, 95);
			this.buttonShowPhase.Name = "buttonShowPhase";
			this.buttonShowPhase.Size = new System.Drawing.Size(151, 33);
			this.buttonShowPhase.TabIndex = 35;
			this.buttonShowPhase.Text = "Show Phase";
			this.buttonShowPhase.UseVisualStyleBackColor = true;
			this.buttonShowPhase.Click += new System.EventHandler(this.buttonShowPhase_Click);
			// 
			// dataGridViewPhases
			// 
			this.dataGridViewPhases.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
			this.dataGridViewPhases.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dataGridViewPhases.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewPhases.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.dataGridViewPhases.Location = new System.Drawing.Point(15, 95);
			this.dataGridViewPhases.Name = "dataGridViewPhases";
			this.dataGridViewPhases.RowTemplate.Height = 24;
			this.dataGridViewPhases.Size = new System.Drawing.Size(461, 420);
			this.dataGridViewPhases.TabIndex = 36;
			// 
			// buttonHidePhase
			// 
			this.buttonHidePhase.Location = new System.Drawing.Point(482, 173);
			this.buttonHidePhase.Name = "buttonHidePhase";
			this.buttonHidePhase.Size = new System.Drawing.Size(151, 33);
			this.buttonHidePhase.TabIndex = 37;
			this.buttonHidePhase.Text = "Hide Phase";
			this.buttonHidePhase.UseVisualStyleBackColor = true;
			this.buttonHidePhase.Click += new System.EventHandler(this.buttonHidePhase_Click);
			// 
			// buttonResetViews
			// 
			this.buttonResetViews.Location = new System.Drawing.Point(481, 212);
			this.buttonResetViews.Name = "buttonResetViews";
			this.buttonResetViews.Size = new System.Drawing.Size(151, 33);
			this.buttonResetViews.TabIndex = 38;
			this.buttonResetViews.Text = "Reset Views";
			this.buttonResetViews.UseVisualStyleBackColor = true;
			this.buttonResetViews.Click += new System.EventHandler(this.buttonResetViews_Click);
			// 
			// checkBoxMainParts
			// 
			this.checkBoxMainParts.AutoSize = true;
			this.checkBoxMainParts.Location = new System.Drawing.Point(483, 268);
			this.checkBoxMainParts.Name = "checkBoxMainParts";
			this.checkBoxMainParts.Size = new System.Drawing.Size(97, 21);
			this.checkBoxMainParts.TabIndex = 39;
			this.checkBoxMainParts.Text = "Main Parts";
			this.checkBoxMainParts.UseVisualStyleBackColor = true;
			// 
			// checkBoxSecondaryParts
			// 
			this.checkBoxSecondaryParts.AutoSize = true;
			this.checkBoxSecondaryParts.Location = new System.Drawing.Point(483, 295);
			this.checkBoxSecondaryParts.Name = "checkBoxSecondaryParts";
			this.checkBoxSecondaryParts.Size = new System.Drawing.Size(135, 21);
			this.checkBoxSecondaryParts.TabIndex = 40;
			this.checkBoxSecondaryParts.Text = "Secondary Parts";
			this.checkBoxSecondaryParts.UseVisualStyleBackColor = true;
			// 
			// PhaseViewerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(644, 527);
			this.Controls.Add(this.checkBoxSecondaryParts);
			this.Controls.Add(this.checkBoxMainParts);
			this.Controls.Add(this.buttonResetViews);
			this.Controls.Add(this.buttonHidePhase);
			this.Controls.Add(this.dataGridViewPhases);
			this.Controls.Add(this.buttonShowPhase);
			this.Controls.Add(this.buttonShowAllPhases);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pictureBox1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "PhaseViewerForm";
			this.Text = "Phase Viewer";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.PhaseViewerForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewPhases)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button buttonShowAllPhases;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button buttonShowPhase;
		private System.Windows.Forms.DataGridView dataGridViewPhases;
		private System.Windows.Forms.Button buttonHidePhase;
		private System.Windows.Forms.Button buttonResetViews;
		private System.Windows.Forms.CheckBox checkBoxMainParts;
		private System.Windows.Forms.CheckBox checkBoxSecondaryParts;
	}
}

