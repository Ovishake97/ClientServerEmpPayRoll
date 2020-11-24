using System.Runtime.Serialization;

namespace Common.Contracts
{
    [DataContract]
    public class EmployeeContract
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Salary { get; set; }

        [DataMember]
        public string Email { get; set; }
    }
}
