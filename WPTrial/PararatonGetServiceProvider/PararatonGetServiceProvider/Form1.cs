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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
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

            JSONHandler jss = new JSONHandler(respond);

            dynamic data = jss.Deserialize();

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

            if (String.IsNullOrEmpty(url_path_txt.Text))
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();

                if (String.IsNullOrEmpty(parameter_txt.Text))
                {
                    string[] temp;
                    char[] delimiter = { '=' };
                    foreach (string text in parameter_txt.Lines)
                    {
                        temp = text.Split(delimiter);
                        parameters.Add(temp[0], temp[1]);
                    }
                }
            }
        }
        
    }
}
