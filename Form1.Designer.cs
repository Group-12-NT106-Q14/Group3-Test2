using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Group3_Test2
{
	partial class Form1
	{
		private System.ComponentModel.IContainer components = null;

		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		private void InitializeComponent()
		{
			panelTop = new Panel();
			tableTop = new TableLayoutPanel();
			label1 = new Label();
			tb_Size = new TextBox();
			label2 = new Label();
			dateTimePicker1 = new DateTimePicker();
			label3 = new Label();
			textBox1 = new TextBox();
			button1 = new Button();
			btnSendMail = new Button();
			splitContainerMain = new SplitContainer();
			listView1 = new ListView();
			columnHeader1 = new ColumnHeader();
			richTextBox1 = new RichTextBox();
			panelTop.SuspendLayout();
			tableTop.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)splitContainerMain).BeginInit();
			splitContainerMain.Panel1.SuspendLayout();
			splitContainerMain.Panel2.SuspendLayout();
			splitContainerMain.SuspendLayout();
			SuspendLayout();
			// 
			// panelTop
			// 
			panelTop.BackColor = Color.White;
			panelTop.Controls.Add(tableTop);
			panelTop.Dock = DockStyle.Top;
			panelTop.Location = new Point(0, 0);
			panelTop.Name = "panelTop";
			panelTop.Padding = new Padding(12);
			panelTop.Size = new Size(1466, 84);
			panelTop.TabIndex = 1;
			// 
			// tableTop
			// 
			tableTop.ColumnCount = 8;
			tableTop.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
			tableTop.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
			tableTop.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
			tableTop.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 230F));
			tableTop.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
			tableTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
			tableTop.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 140F));
			tableTop.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 140F));
			tableTop.Controls.Add(label1, 0, 0);
			tableTop.Controls.Add(tb_Size, 1, 0);
			tableTop.Controls.Add(label2, 2, 0);
			tableTop.Controls.Add(dateTimePicker1, 3, 0);
			tableTop.Controls.Add(label3, 4, 0);
			tableTop.Controls.Add(textBox1, 5, 0);
			tableTop.Controls.Add(button1, 6, 0);
			tableTop.Controls.Add(btnSendMail, 7, 0);
			tableTop.Dock = DockStyle.Fill;
			tableTop.Location = new Point(12, 12);
			tableTop.Name = "tableTop";
			tableTop.RowCount = 2;
			tableTop.RowStyles.Add(new RowStyle(SizeType.Percent, 86.6666641F));
			tableTop.RowStyles.Add(new RowStyle(SizeType.Percent, 13.333333F));
			tableTop.Size = new Size(1442, 60);
			tableTop.TabIndex = 0;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Dock = DockStyle.Fill;
			label1.ForeColor = Color.Black;
			label1.Location = new Point(3, 0);
			label1.Name = "label1";
			label1.Size = new Size(64, 52);
			label1.TabIndex = 0;
			label1.Text = "Size";
			label1.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// tb_Size
			// 
			tb_Size.Dock = DockStyle.Fill;
			tb_Size.Location = new Point(73, 6);
			tb_Size.Margin = new Padding(3, 6, 12, 6);
			tb_Size.Name = "tb_Size";
			tb_Size.Size = new Size(105, 39);
			tb_Size.TabIndex = 1;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Dock = DockStyle.Fill;
			label2.ForeColor = Color.Black;
			label2.Location = new Point(193, 0);
			label2.Name = "label2";
			label2.Size = new Size(64, 52);
			label2.TabIndex = 2;
			label2.Text = "Date";
			label2.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// dateTimePicker1
			// 
			dateTimePicker1.Dock = DockStyle.Fill;
			dateTimePicker1.Format = DateTimePickerFormat.Short;
			dateTimePicker1.Location = new Point(263, 6);
			dateTimePicker1.Margin = new Padding(3, 6, 12, 6);
			dateTimePicker1.Name = "dateTimePicker1";
			dateTimePicker1.Size = new Size(215, 39);
			dateTimePicker1.TabIndex = 3;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Dock = DockStyle.Fill;
			label3.ForeColor = Color.Black;
			label3.Location = new Point(493, 0);
			label3.Name = "label3";
			label3.Size = new Size(64, 52);
			label3.TabIndex = 4;
			label3.Text = "Email";
			label3.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// textBox1
			// 
			textBox1.Dock = DockStyle.Fill;
			textBox1.Location = new Point(563, 6);
			textBox1.Margin = new Padding(3, 6, 12, 6);
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(587, 39);
			textBox1.TabIndex = 5;
			// 
			// button1
			// 
			button1.Dock = DockStyle.Fill;
			button1.Location = new Point(1168, 6);
			button1.Margin = new Padding(6, 6, 0, 6);
			button1.Name = "button1";
			button1.Size = new Size(134, 40);
			button1.TabIndex = 6;
			button1.Text = "Tìm kiếm";
			button1.UseVisualStyleBackColor = true;
			// 
			// btnSendMail
			// 
			btnSendMail.Dock = DockStyle.Fill;
			btnSendMail.Location = new Point(1308, 6);
			btnSendMail.Margin = new Padding(6, 6, 0, 6);
			btnSendMail.Name = "btnSendMail";
			btnSendMail.Size = new Size(134, 40);
			btnSendMail.TabIndex = 7;
			btnSendMail.Text = "Gửi Gmail";
			btnSendMail.UseVisualStyleBackColor = true;
			// 
			// splitContainerMain
			// 
			splitContainerMain.Dock = DockStyle.Fill;
			splitContainerMain.Location = new Point(0, 84);
			splitContainerMain.Name = "splitContainerMain";
			// 
			// splitContainerMain.Panel1
			// 
			splitContainerMain.Panel1.Controls.Add(listView1);
			splitContainerMain.Panel1.Padding = new Padding(12, 8, 8, 12);
			// 
			// splitContainerMain.Panel2
			// 
			splitContainerMain.Panel2.Controls.Add(richTextBox1);
			splitContainerMain.Panel2.Padding = new Padding(8, 8, 12, 12);
			splitContainerMain.Size = new Size(1466, 944);
			splitContainerMain.SplitterDistance = 1182;
			splitContainerMain.TabIndex = 0;
			// 
			// listView1
			// 
			listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
			listView1.Dock = DockStyle.Fill;
			listView1.FullRowSelect = true;
			listView1.GridLines = true;
			listView1.Location = new Point(12, 8);
			listView1.MultiSelect = false;
			listView1.Name = "listView1";
			listView1.Size = new Size(1162, 924);
			listView1.TabIndex = 0;
			listView1.UseCompatibleStateImageBehavior = false;
			listView1.View = View.Details;
			// 
			// columnHeader1
			// 
			columnHeader1.Text = "URL";
			columnHeader1.Width = 380;
			// 
			// richTextBox1
			// 
			richTextBox1.BorderStyle = BorderStyle.FixedSingle;
			richTextBox1.Dock = DockStyle.Fill;
			richTextBox1.Location = new Point(8, 8);
			richTextBox1.Name = "richTextBox1";
			richTextBox1.ReadOnly = true;
			richTextBox1.Size = new Size(260, 924);
			richTextBox1.TabIndex = 0;
			richTextBox1.Text = "";
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(13F, 32F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.White;
			ClientSize = new Size(1466, 1028);
			Controls.Add(splitContainerMain);
			Controls.Add(panelTop);
			Font = new System.Drawing.Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			Name = "Form1";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Thị trường chứng khoán";
			panelTop.ResumeLayout(false);
			tableTop.ResumeLayout(false);
			tableTop.PerformLayout();
			splitContainerMain.Panel1.ResumeLayout(false);
			splitContainerMain.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainerMain).EndInit();
			splitContainerMain.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private System.Windows.Forms.Panel panelTop;
		private System.Windows.Forms.TableLayoutPanel tableTop;
		private System.Windows.Forms.SplitContainer splitContainerMain;

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button btnSendMail;

		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tb_Size;
	}
}