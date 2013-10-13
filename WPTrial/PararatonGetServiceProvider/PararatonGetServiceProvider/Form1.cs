using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PararatonGetServiceProvider
{
    public partial class Form1 : Form
    {
        JSONHandler _jss;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Icon = PararatonGetServiceProvider.Properties.Resources.favicon;
            this.Text = "Pararaton Get Service Provider";

            url_path_txt.ReadOnly = true;
            parameter_txt.ReadOnly = true;
            respond_txt.ReadOnly = true;
            group_request_gb.Enabled = false;
            login_btn.Focus();
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            HttpHandler temp = new HttpHandler();

            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                {"u", "ian_kinch"},
                {"p", "asdasdasd"}
            };

            string respond = temp.Request("user", "login", "post", parameter);

            _jss = new JSONHandler(respond);

            dynamic data = _jss.Deserialize();

            if (data != null)
            {
                if (data["status"].ToString() == "success")
                {
                    login_btn.Visible = false;
                    url_path_txt.ReadOnly = false;
                    parameter_txt.ReadOnly = false;
                    respond_txt.ReadOnly = false;
                    group_request_gb.Enabled = true;

                    session_id_lbl.Text = data["message"];

                    string header = temp.GetResposeHeaderDataString("Set-Cookie");
                    char[] delimiter = { ';', '=' };
                    string[] test = header.Split(delimiter);

                    jsessionid_lbl.Text = test[1];
                    awslb_lbl.Text = test[5];
                }
            }
        }

        private void submit_btn_Click(object sender, EventArgs e)
        {
            string method = "post";
            if (get_radio.Checked)
            {
                method = "get";
            }

            if (!String.IsNullOrEmpty(url_path_txt.Text))
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();

                if (!String.IsNullOrEmpty(parameter_txt.Text))
                {
                    string[] temp;
                    char[] delimiter = { '=' };
                    foreach (string text in parameter_txt.Lines)
                    {
                        temp = text.Split(delimiter);
                        parameters.Add(temp[0], temp[1]);
                    }
                }

                if (parameters.Count > 0)
                {
                    

                }

                HttpHandler requestHandler = new HttpHandler(url_path_txt.Text);

                Dictionary<string, string> cookies = new Dictionary<string, string>() 
                    { 
                        {"JSESSIONID", jsessionid_lbl.Text},
                        {"AWSLB", awslb_lbl.Text}
                    };

                string respond = "";

                try
                {
                    respond = requestHandler.Request(method, parameters, cookies);
                    respond_txt.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error Message!", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }                

                respond = respond.Replace("\n", "");

                respond_txt.Text = respond;
            }
        }
        
    }
}
