using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management.Automation;
using System.Collections.ObjectModel;
using System.IO;
using System.Security;
namespace WindowsFormsApplication7
{
    // tao bien Credential luu tai khoan va bien IP luu IP dc chon trong danh sach IP
    public class bientoancuc
    {
        public static PSCredential Credential;
        public static string IP;
    }
   public partial class Form1 : Form
       {
        private string aa;
        private string temp;
        private int count=1;
        public Form1()
        {
            InitializeComponent();
        }
        //chay lenh powershell
        private string RunScript()
        {
            //chạy lệnh pws
            PowerShell pws = PowerShell.Create();
            pws.AddCommand("set-executionpolicy");
            pws.AddParameter("ExecutionPolicy", "Unrestricted");
            pws.Invoke();
            //tạo đối tượng password
            var password = new SecureString();
            Array.ForEach(tbPassword.Text.ToCharArray(), password.AppendChar);
            // Credential
            bientoancuc.Credential = new PSCredential(tbUsername.Text, password);
            // lay IP luu vao bien cuc bo IP
            bientoancuc.IP = cbDSIP.Text;
            //Chay lenh kiem tra
            pws.AddCommand("get-wmiobject").AddParameter("Class", "win32_service").AddParameter("ComputerName", bientoancuc.IP).AddParameter("Credential", bientoancuc.Credential);
            Collection<PSObject> results = pws.Invoke();
            //Nếu không có kết quả trả về return về KO
            if (results == null)
            {
                return "KO";
            }
            else
            {
                return "OK";

            }
        }

        //button login
        private void btLogin_Click(object sender, EventArgs e)
        {
            try
            {

                aa = RunScript();
                if (aa.Equals("OK") == true)
                {
                    MessageBox.Show("Đăng nhập thành công");
                }
            }
            catch
            {
                DialogResult r;
                r = MessageBox.Show("Bạn có muốn nhập lại không? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question,MessageBoxDefaultButton.Button2);
                if (r == DialogResult.No)
                    this.Close();
                else
                {
                    tbPassword.Clear();
                    //temp = cbDSIP.Text;
                    //biencucbo.IP = temp;
                    //MessageBox.Show(biencucbo.IP);
                    if (count >= 3)
                    {
                        MessageBox.Show("Đã nhập sai 3 lần!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        MessageBox.Show("Nếu bạn chắc chắn rằng tài khoản đăng nhập đúng thì có thể bạn chưa cấp quyền cho tài khoản đó hoặc do kết nối bị lỗi","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        this.Close();
                    }
                    count = count + 1;
                }


            }


        }
        //button exit
        private void btExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Lay danh sach IP vao cbbox
        private void Form1_Load(object sender, EventArgs e)
        {

            FileStream fs = new FileStream(@"C:\Users\Thanh\Desktop\LoginForm\WindowsFormsApplication7\dsIP.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs, Encoding.UTF8);
            String line;
            while ((line = sr.ReadLine()) != null)
            {
                cbDSIP.Items.Add(line);
            }
            

        }


    }
}
