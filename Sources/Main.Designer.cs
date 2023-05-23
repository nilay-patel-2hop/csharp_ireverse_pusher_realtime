
namespace iReverse_Pusher_Realtime
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_evento = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_eventme = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.richTextBox_write_messages = new System.Windows.Forms.RichTextBox();
            this.button_send = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.richTextBox_messages = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_evento);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox_eventme);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(640, 387);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Private Channel";
            // 
            // textBox_evento
            // 
            this.textBox_evento.Location = new System.Drawing.Point(379, 18);
            this.textBox_evento.Name = "textBox_evento";
            this.textBox_evento.Size = new System.Drawing.Size(249, 20);
            this.textBox_evento.TabIndex = 6;
            this.textBox_evento.Text = "client-User-Web";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(316, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Event To :";
            // 
            // textBox_eventme
            // 
            this.textBox_eventme.Location = new System.Drawing.Point(75, 18);
            this.textBox_eventme.Name = "textBox_eventme";
            this.textBox_eventme.Size = new System.Drawing.Size(235, 20);
            this.textBox_eventme.TabIndex = 6;
            this.textBox_eventme.Text = "client-Winform-App";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Event Me :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.richTextBox_write_messages);
            this.groupBox2.Controls.Add(this.button_send);
            this.groupBox2.Location = new System.Drawing.Point(6, 254);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(628, 127);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Write Messages : ";
            // 
            // richTextBox_write_messages
            // 
            this.richTextBox_write_messages.Location = new System.Drawing.Point(6, 19);
            this.richTextBox_write_messages.Name = "richTextBox_write_messages";
            this.richTextBox_write_messages.Size = new System.Drawing.Size(535, 96);
            this.richTextBox_write_messages.TabIndex = 6;
            this.richTextBox_write_messages.Text = "";
            // 
            // button_send
            // 
            this.button_send.Location = new System.Drawing.Point(547, 48);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(75, 45);
            this.button_send.TabIndex = 5;
            this.button_send.Text = "Send";
            this.button_send.UseVisualStyleBackColor = true;
            this.button_send.Click += new System.EventHandler(this.button_send_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.richTextBox_messages);
            this.groupBox3.Location = new System.Drawing.Point(6, 42);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(634, 206);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Messages :";
            // 
            // richTextBox_messages
            // 
            this.richTextBox_messages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.richTextBox_messages.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox_messages.Location = new System.Drawing.Point(6, 19);
            this.richTextBox_messages.Name = "richTextBox_messages";
            this.richTextBox_messages.ReadOnly = true;
            this.richTextBox_messages.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.richTextBox_messages.Size = new System.Drawing.Size(622, 162);
            this.richTextBox_messages.TabIndex = 0;
            this.richTextBox_messages.Text = "";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 411);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "iReverse Pusher Realtime - @HadiK IT";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_evento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_eventme;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox richTextBox_write_messages;
        private System.Windows.Forms.Button button_send;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox richTextBox_messages;
    }
}

