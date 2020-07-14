using System.Runtime.Serialization;

namespace EmpManagement_WCF
{
    [DataContract]
    public class Employee
    {
        [DataMember]
        public string empID;
        [DataMember]
        public string name;
        [DataMember]
        public string email;
        [DataMember]
        public string phone;
        [DataMember]
        public string gender;

    }
}