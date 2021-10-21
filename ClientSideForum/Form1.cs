using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClientSideForum.ServiceReference2;
using Newtonsoft.Json;

namespace ClientSideForum
{
    public partial class Form1 : Form
    {
        ManageEmployeesClient ss = new ManageEmployeesClient();
        public Form1()
        {

            
            InitializeComponent();
            UpdateListBox();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
           
            employee.FirstName = textBox1.Text;
            employee.LastName = textBox2.Text;
            ss.Add(employee);
            UpdateListBox();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null) return;
            string[] id = listBox1.SelectedItem.ToString().Split(' '); 
            textBox6.Text = id[0];
            textBox3.Text = id[0];
            textBox4.Text = id[1];
            textBox5.Text = id[2];



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee() { Id = Convert.ToInt32(textBox3.Text), FirstName = textBox4.Text, LastName = textBox5.Text };
            ss.Update(employee);
            UpdateListBox();
        }
        public void UpdateListBox()
        {
            listBox1.Items.Clear();
            Employee employee = new Employee();
            string jsonString = ss.Read(employee);
            List<Employee> emp = JsonConvert.DeserializeObject<List<Employee>>(jsonString);
            if (emp == null)
            {
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                textBox6.Enabled = false;
                button1.Enabled = false;
                button2.Enabled = false;
                return;
            }
            foreach (Employee e in emp)
            {
                
                listBox1.Items.Add($"{e.Id} .{e.FirstName} {e.LastName}");
               
            }
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee() { Id =Convert.ToInt32(textBox6.Text)};
            ss.Delete(employee);
            textBox6.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            UpdateListBox();


        }
    }
    
}
