namespace PararatonGetServiceProvider
{
    partial class Form1
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
            this.url_path_txt = new System.Windows.Forms.TextBox();
            this.parameter_txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.respond_txt = new System.Windows.Forms.TextBox();
            this.login_btn = new System.Windows.Forms.Button();
            this.submit_btn = new System.Windows.Forms.Button();
            this.group_request_gb = new System.Windows.Forms.GroupBox();
            this.get_radio = new System.Windows.Forms.RadioButton();
            this.post_radio = new System.Windows.Forms.RadioButton();
            this.group_user_info_gb = new System.Windows.Forms.GroupBox();
            this.session_id_lbl = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.jsessionid_lbl = new System.Windows.Forms.Label();
            this.awslb_lbl = new System.Windows.Forms.Label();
            this.group_request_gb.SuspendLayout();
            this.group_user_info_gb.SuspendLayout();
            this.SuspendLayout();
            // 
            // url_path_txt
            // 
            this.url_path_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.url_path_txt.Location = new System.Drawing.Point(12, 45);
            this.url_path_txt.Name = "url_path_txt";
            this.url_path_txt.Size = new System.Drawing.Size(508, 26);
            this.url_path_txt.TabIndex = 0;
            // 
            // parameter_txt
            // 
            this.parameter_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.parameter_txt.Location = new System.Drawing.Point(12, 101);
            this.parameter_txt.Multiline = true;
            this.parameter_txt.Name = "parameter_txt";
            this.parameter_txt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.parameter_txt.Size = new System.Drawing.Size(251, 133);
            this.parameter_txt.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "URL Path ( [Controller]/[Action] ) :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Parameter:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(269, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Respond Items:";
            // 
            // respond_txt
            // 
            this.respond_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.respond_txt.Location = new System.Drawing.Point(269, 101);
            this.respond_txt.Multiline = true;
            this.respond_txt.Name = "respond_txt";
            this.respond_txt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.respond_txt.Size = new System.Drawing.Size(251, 133);
            this.respond_txt.TabIndex = 4;
            // 
            // login_btn
            // 
            this.login_btn.Location = new System.Drawing.Point(526, 44);
            this.login_btn.Name = "login_btn";
            this.login_btn.Size = new System.Drawing.Size(86, 30);
            this.login_btn.TabIndex = 6;
            this.login_btn.Text = "Login!";
            this.login_btn.UseVisualStyleBackColor = true;
            this.login_btn.Click += new System.EventHandler(this.login_btn_Click);
            // 
            // submit_btn
            // 
            this.submit_btn.Location = new System.Drawing.Point(5, 65);
            this.submit_btn.Name = "submit_btn";
            this.submit_btn.Size = new System.Drawing.Size(85, 62);
            this.submit_btn.TabIndex = 7;
            this.submit_btn.Text = "Submit";
            this.submit_btn.UseVisualStyleBackColor = true;
            this.submit_btn.Click += new System.EventHandler(this.submit_btn_Click);
            // 
            // group_request_gb
            // 
            this.group_request_gb.Controls.Add(this.get_radio);
            this.group_request_gb.Controls.Add(this.post_radio);
            this.group_request_gb.Controls.Add(this.submit_btn);
            this.group_request_gb.Location = new System.Drawing.Point(526, 95);
            this.group_request_gb.Name = "group_request_gb";
            this.group_request_gb.Size = new System.Drawing.Size(147, 139);
            this.group_request_gb.TabIndex = 8;
            this.group_request_gb.TabStop = false;
            this.group_request_gb.Text = "Submit Request";
            // 
            // get_radio
            // 
            this.get_radio.AutoSize = true;
            this.get_radio.Checked = true;
            this.get_radio.Location = new System.Drawing.Point(6, 19);
            this.get_radio.Name = "get_radio";
            this.get_radio.Size = new System.Drawing.Size(47, 17);
            this.get_radio.TabIndex = 9;
            this.get_radio.TabStop = true;
            this.get_radio.Text = "GET";
            this.get_radio.UseVisualStyleBackColor = true;
            // 
            // post_radio
            // 
            this.post_radio.AutoSize = true;
            this.post_radio.Location = new System.Drawing.Point(6, 42);
            this.post_radio.Name = "post_radio";
            this.post_radio.Size = new System.Drawing.Size(54, 17);
            this.post_radio.TabIndex = 8;
            this.post_radio.TabStop = true;
            this.post_radio.Text = "POST";
            this.post_radio.UseVisualStyleBackColor = true;
            // 
            // group_user_info_gb
            // 
            this.group_user_info_gb.Controls.Add(this.awslb_lbl);
            this.group_user_info_gb.Controls.Add(this.jsessionid_lbl);
            this.group_user_info_gb.Controls.Add(this.label6);
            this.group_user_info_gb.Controls.Add(this.label4);
            this.group_user_info_gb.Controls.Add(this.session_id_lbl);
            this.group_user_info_gb.Controls.Add(this.label5);
            this.group_user_info_gb.Location = new System.Drawing.Point(12, 240);
            this.group_user_info_gb.Name = "group_user_info_gb";
            this.group_user_info_gb.Size = new System.Drawing.Size(661, 206);
            this.group_user_info_gb.TabIndex = 9;
            this.group_user_info_gb.TabStop = false;
            this.group_user_info_gb.Text = "User Information";
            // 
            // session_id_lbl
            // 
            this.session_id_lbl.AutoSize = true;
            this.session_id_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.session_id_lbl.Location = new System.Drawing.Point(91, 38);
            this.session_id_lbl.Name = "session_id_lbl";
            this.session_id_lbl.Size = new System.Drawing.Size(30, 17);
            this.session_id_lbl.TabIndex = 6;
            this.session_id_lbl.Text = "null";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "SessionID :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "JSessionID :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 17);
            this.label6.TabIndex = 8;
            this.label6.Text = "AWSLB :";
            // 
            // jsessionid_lbl
            // 
            this.jsessionid_lbl.AutoSize = true;
            this.jsessionid_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jsessionid_lbl.Location = new System.Drawing.Point(91, 65);
            this.jsessionid_lbl.Name = "jsessionid_lbl";
            this.jsessionid_lbl.Size = new System.Drawing.Size(30, 17);
            this.jsessionid_lbl.TabIndex = 9;
            this.jsessionid_lbl.Text = "null";
            // 
            // awslb_lbl
            // 
            this.awslb_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.awslb_lbl.Location = new System.Drawing.Point(76, 93);
            this.awslb_lbl.Name = "awslb_lbl";
            this.awslb_lbl.Size = new System.Drawing.Size(579, 110);
            this.awslb_lbl.TabIndex = 10;
            this.awslb_lbl.Text = "null";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 458);
            this.Controls.Add(this.group_user_info_gb);
            this.Controls.Add(this.group_request_gb);
            this.Controls.Add(this.login_btn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.respond_txt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.parameter_txt);
            this.Controls.Add(this.url_path_txt);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.group_request_gb.ResumeLayout(false);
            this.group_request_gb.PerformLayout();
            this.group_user_info_gb.ResumeLayout(false);
            this.group_user_info_gb.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox url_path_txt;
        private System.Windows.Forms.TextBox parameter_txt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox respond_txt;
        private System.Windows.Forms.Button login_btn;
        private System.Windows.Forms.Button submit_btn;
        private System.Windows.Forms.GroupBox group_request_gb;
        private System.Windows.Forms.RadioButton get_radio;
        private System.Windows.Forms.RadioButton post_radio;
        private System.Windows.Forms.GroupBox group_user_info_gb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label session_id_lbl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label awslb_lbl;
        private System.Windows.Forms.Label jsessionid_lbl;
    }
}

