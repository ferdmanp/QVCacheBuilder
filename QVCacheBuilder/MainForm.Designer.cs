/*
 * Created by SharpDevelop.
 * User: ferdman.pavel
 * Date: 06.11.2014
 * Time: 13:04
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace QVCacheBuilder
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.ListBox lbFields;
		private System.Windows.Forms.Button btnAddField;
		private System.Windows.Forms.Button btnRemoveField;
		private System.Windows.Forms.TextBox tbFieldName;
		private System.Windows.Forms.NumericUpDown nudSheetNumber;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.button1 = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.lbFields = new System.Windows.Forms.ListBox();
			this.btnAddField = new System.Windows.Forms.Button();
			this.btnRemoveField = new System.Windows.Forms.Button();
			this.tbFieldName = new System.Windows.Forms.TextBox();
			this.nudSheetNumber = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.nudSheetNumber)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(33, 53);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(114, 56);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(349, 20);
			this.textBox1.TabIndex = 2;
			this.textBox1.Text = "kpi.qvw";
			// 
			// lbFields
			// 
			this.lbFields.FormattingEnabled = true;
			this.lbFields.Location = new System.Drawing.Point(12, 99);
			this.lbFields.Name = "lbFields";
			this.lbFields.Size = new System.Drawing.Size(156, 212);
			this.lbFields.TabIndex = 3;
			// 
			// btnAddField
			// 
			this.btnAddField.Location = new System.Drawing.Point(12, 317);
			this.btnAddField.Name = "btnAddField";
			this.btnAddField.Size = new System.Drawing.Size(35, 21);
			this.btnAddField.TabIndex = 6;
			this.btnAddField.Text = "+";
			this.btnAddField.UseVisualStyleBackColor = true;
			this.btnAddField.Click += new System.EventHandler(this.BtnAddFieldClick);
			// 
			// btnRemoveField
			// 
			this.btnRemoveField.Location = new System.Drawing.Point(133, 317);
			this.btnRemoveField.Name = "btnRemoveField";
			this.btnRemoveField.Size = new System.Drawing.Size(35, 21);
			this.btnRemoveField.TabIndex = 6;
			this.btnRemoveField.Text = "-";
			this.btnRemoveField.UseVisualStyleBackColor = true;
			this.btnRemoveField.Click += new System.EventHandler(this.BtnRemoveFieldClick);
			// 
			// tbFieldName
			// 
			this.tbFieldName.Location = new System.Drawing.Point(8, 344);
			this.tbFieldName.Name = "tbFieldName";
			this.tbFieldName.Size = new System.Drawing.Size(160, 20);
			this.tbFieldName.TabIndex = 8;
			// 
			// nudSheetNumber
			// 
			this.nudSheetNumber.Location = new System.Drawing.Point(469, 57);
			this.nudSheetNumber.Name = "nudSheetNumber";
			this.nudSheetNumber.Size = new System.Drawing.Size(60, 20);
			this.nudSheetNumber.TabIndex = 10;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(555, 429);
			this.Controls.Add(this.nudSheetNumber);
			this.Controls.Add(this.tbFieldName);
			this.Controls.Add(this.btnRemoveField);
			this.Controls.Add(this.btnAddField);
			this.Controls.Add(this.lbFields);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.button1);
			this.Name = "MainForm";
			this.Text = "QVCacheBuilder";
			((System.ComponentModel.ISupportInitialize)(this.nudSheetNumber)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
