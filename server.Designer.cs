namespace Group3_Test2
{
    partial class server
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
            lstBclient = new ListBox();
            txtEvent = new TextBox();
            txtMessage = new TextBox();
            Message = new Button();
            SuspendLayout();
            // 
            // lstBclient
            // 
            lstBclient.FormattingEnabled = true;
            lstBclient.Location = new Point(12, 81);
            lstBclient.Name = "lstBclient";
            lstBclient.Size = new Size(217, 324);
            lstBclient.TabIndex = 1;
            // 
            // txtEvent
            // 
            txtEvent.Location = new Point(235, 81);
            txtEvent.Multiline = true;
            txtEvent.Name = "txtEvent";
            txtEvent.ReadOnly = true;
            txtEvent.Size = new Size(553, 324);
            txtEvent.TabIndex = 2;
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(12, 32);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(587, 27);
            txtMessage.TabIndex = 3;
            // 
            // Message
            // 
            Message.Location = new Point(630, 32);
            Message.Name = "Message";
            Message.Size = new Size(120, 27);
            Message.TabIndex = 4;
            Message.Text = "Message ";
            Message.UseVisualStyleBackColor = true;
            Message.Click += Message_Click;
            // 
            // server
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Message);
            Controls.Add(txtMessage);
            Controls.Add(txtEvent);
            Controls.Add(lstBclient);
            Name = "server";
            Text = "server";
            Load += server_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstBclient;
        private TextBox txtEvent;
        private TextBox txtMessage;
        private Button Message;
    }
}