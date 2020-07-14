using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace EmpManagement_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple,
                  InstanceContextMode = InstanceContextMode.Single)]
    public class Service1 : IService1
    {
        public List<Employee> empList = new List<Employee>()
        {
            new Employee() { empID = "1", name = "Shivang Mishra", email = "shivang.mishra@gmail.com", phone = "789654132", gender = "male"},
            new Employee() { empID = "2", name = "Mansi Mishra", email = "mansi.mishra@gmail.com", phone = "615673652", gender = "female"},
            new Employee() { empID = "3", name = "Kumar Shanu", email = "kumar.shanu@gmail.com", phone = "78965192", gender = "male"},
            new Employee() { empID = "4", name = "Sandeep Singh", email = "sandeep.singh@gmail.com", phone = "159644132", gender = "male"},
            new Employee() { empID = "5", name = "Ayushi Tiwari", email = "ayuhsi.tiwari@gmail.com", phone = "789685242", gender = "female"}
    };

    public string AddEmployeeRecord(Employee emp)
        {
            string ret;
            if ((from empl in empList where empl.empID == emp.empID select empl).Count() > 0)
            {
                 ret= "Record not saved. Employee already exists.";
            }
            else
            {
                empList.Add(emp);
                ret = "Record saved.";
            }
            return ret;
        }

        public string DeleteRecords(Employee emp)
        {
            string ret;
            string id = emp.empID;
            IEnumerable<Employee> employeetodelete = from empl in empList where empl.empID == id select empl;
            empList = empList.Except(employeetodelete).ToList();
            ret = "Record deleted.";
            return ret;
        }

        public Employee GetEmployeeRecords(string id)
        {
            Employee employee = new Employee();
            if ((from emp in empList where emp.empID == id select emp).Count() == 0)
            {
                employee.empID = null;
                employee.name = null;
                employee.email = null;
                employee.phone = null;
                employee.gender = null;
            }
            else
            {
                IEnumerable<Employee> employeetoupdate = from emp in empList where emp.empID == id select emp;
                employee = employeetoupdate.First();
            }
            return employee;
        }

        public string UpdateEmployeeContact(Employee emp)
        {
            string ret;
            string id = emp.empID;
            IEnumerable<Employee> employeetoupdate = from empll in empList where empll.empID == id select empll;
            Employee empl = employeetoupdate.First();
            empl.name = emp.name;
            empl.email = emp.email;
            empl.phone = emp.phone;
            empl.gender = emp.gender;
            empList.Add(empl);
            ret = "Record updated.";
            return ret;
        }
    }
}
