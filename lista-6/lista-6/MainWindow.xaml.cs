using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lista_6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly SqlConnection _con;

        public MainWindow()
        {
            InitializeComponent();

            _con = new SqlConnection("Data Source=DESKTOP-IK2EFPM;Initial Catalog=TestSP_DB;User ID=salman;Password=Power!#2;MultipleActiveResultSets=true;");
            _con.Open();
            GetEmpList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            // get all data from TextBox by x:Name and store in string
            int empid = int.Parse(txtID.Text);
            string name = txtName.Text;
            string city = txtCity.Text;
            float age = float.Parse(txtAge.Text);
            string sex = "";

            if (txtSex.Text == "Male" || txtSex.Text == "Female")
            {
                sex = txtSex.Text;
            }

            string contact = txtContact.Text;

            // convert DateTime txtJoiningDate to sql DateTime format
            DateTime joiningDate = DateTime.Parse(txtJoiningDate.Text);
            string joiningDateSql = joiningDate.ToString("yyyy-MM-dd");


            SqlCommand cmd = new SqlCommand($"exec InsertEmp_SP {empid}, '{name}', '{city}', {age}, '{sex}', '{joiningDateSql}', '{contact}'", _con);
            // execute cmd

            
            cmd.ExecuteNonQuery();

            MessageBox.Show("Stored Procedure Executed");

            GetEmpList();
        }

        void GetEmpList()
        {
            SqlCommand cmd = new SqlCommand("exec ListEmp_SP", _con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            System.Data.DataTable dt = new System.Data.DataTable("Emp");
            adapter.Fill(dt);
            DataGridEmp.ItemsSource = dt.DefaultView;
        }
    }
}
