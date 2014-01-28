using System.Runtime.Serialization;

namespace MoneyHawk.Core
{
    [DataContract]
    public class ContactWrapper
    {
        [DataMember(Name="contact")]
        public Contact Contact { get; set; }
    }
}