using System;
using System.Collections.Generic;
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
using UI_wcftask.ServiceReference1;

namespace UI_wcftask
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Button_Click(object sender, RoutedEventArgs e) //add
        {
            Employee employee = new Employee();
            employee.empID = empid.Text;
            employee.name = empname.Text;
            employee.email = empemail.Text;
            employee.phone = empphone.Text;
            if (male.IsChecked == true)
            {
                employee.gender = "male";
            }
            else if (male.IsChecked == false)
            {
                employee.gender = "female";
            }
            string reply = client.AddEmployeeRecord(employee);
            commentbox.Text = reply;
        }

        public void Button_Click_1(object sender, RoutedEventArgs e) //search
        {
            Employee emp = new Employee();
            string id = empid.Text;
            emp = client.GetEmployeeRecords(id);
            if (emp.empID == null)
            {
                commentbox.Text = "Record Not Found";
            }
            else
            {
                commentbox.Text = "Record Found";
                empid.Text = emp.empID;
                empname.Text = emp.name;
                empemail.Text = emp.email;
                empphone.Text = emp.phone;
                if (emp.gender == "male")
                {
                    male.IsChecked = true;
                    female.IsChecked = false;
                }
                else if (emp.gender == "female")
                {
                    female.IsChecked = true;
                    male.IsChecked = false;
                }
            }
            
        }

        public void Button_Click_2(object sender, RoutedEventArgs e) //update
        {
            Employee employee = new Employee();
            employee.empID = empid.Text;
            employee.name = empname.Text;
            employee.email = empemail.Text;
            employee.phone = empphone.Text;
            if (male.IsChecked == true && female.IsChecked == false)
            {
                employee.gender = "Male";
            }
            else if (male.IsChecked == false && female.IsChecked == true)
            {
                employee.gender = "Female";
            }
            string reply = client.UpdateEmployeeContact(employee);
            commentbox.Text = reply;
        }

        public void Button_Click_3(object sender, RoutedEventArgs e) //delete
        {
            Employee employee = new Employee();
            employee.empID = empid.Text;
            employee.name = empname.Text;
            employee.email = empemail.Text;
            employee.phone = empphone.Text;
            if (male.IsChecked == true && female.IsChecked == false)
            {
                employee.gender = "Male";
            }
            else if (male.IsChecked == false && female.IsChecked == true)
            {
                employee.gender = "Female";
            }
            string reply = client.DeleteRecords(employee);
            commentbox.Text = reply;
        }

        public void Button_Click_4(object sender, RoutedEventArgs e) //clear
        {
            empid.Text = null;
            empname.Text = null;
            empemail.Text = null;
            empphone.Text = null;
            male.IsChecked = true;
            female.IsChecked = false;
            commentbox.Text = null;
        }

        public void male_Checked(object sender, RoutedEventArgs e)
        {
            if (male.IsChecked == true)
            {
                female.IsChecked = false;
            }
        }

        public void female_Checked(object sender, RoutedEventArgs e)
        {
            if (female.IsChecked == true)
            {
                male.IsChecked = false;
            }
        }
    }
}
