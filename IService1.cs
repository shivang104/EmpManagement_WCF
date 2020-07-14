using System.ServiceModel;

namespace EmpManagement_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string AddEmployeeRecord(Employee emp);

        [OperationContract]
        Employee GetEmployeeRecords(string id);

        [OperationContract]
        string DeleteRecords(Employee emp);

        [OperationContract]
        string UpdateEmployeeContact(Employee emp);
    }

}
