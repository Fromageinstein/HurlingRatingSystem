namespace HurlingRating {
	partial class Form1 {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.RunButton = new System.Windows.Forms.Button();
			this.OutputText = new System.Windows.Forms.TextBox();
			this.KValue = new System.Windows.Forms.TextBox();
			this.KValueLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// RunButton
			// 
			this.RunButton.Location = new System.Drawing.Point(262, 11);
			this.RunButton.Name = "RunButton";
			this.RunButton.Size = new System.Drawing.Size(75, 23);
			this.RunButton.TabIndex = 0;
			this.RunButton.Text = "Run";
			this.RunButton.UseVisualStyleBackColor = true;
			this.RunButton.Click += new System.EventHandler(this.run);
			// 
			// OutputText
			// 
			this.OutputText.Location = new System.Drawing.Point(12, 41);
			this.OutputText.Multiline = true;
			this.OutputText.Name = "OutputText";
			this.OutputText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.OutputText.Size = new System.Drawing.Size(758, 700);
			this.OutputText.TabIndex = 1;
			// 
			// KValue
			// 
			this.KValue.Location = new System.Drawing.Point(86, 12);
			this.KValue.MaxLength = 3;
			this.KValue.Name = "KValue";
			this.KValue.Size = new System.Drawing.Size(100, 22);
			this.KValue.TabIndex = 2;
			this.KValue.Text = "0";
			this.KValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KValue_KeyPress);
			// 
			// KValueLabel
			// 
			this.KValueLabel.AutoSize = true;
			this.KValueLabel.Location = new System.Drawing.Point(23, 17);
			this.KValueLabel.Name = "KValueLabel";
			this.KValueLabel.Size = new System.Drawing.Size(57, 17);
			this.KValueLabel.TabIndex = 3;
			this.KValueLabel.Text = "K Value";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(782, 753);
			this.Controls.Add(this.KValueLabel);
			this.Controls.Add(this.KValue);
			this.Controls.Add(this.OutputText);
			this.Controls.Add(this.RunButton);
			this.Name = "Form1";
			this.Text = "Hurling Rater";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button RunButton;
		private System.Windows.Forms.TextBox OutputText;
		private System.Windows.Forms.TextBox KValue;
		private System.Windows.Forms.Label KValueLabel;
	}
}

