using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace InventoryController.Models
{
    [DataContract]
    public class Message<T>
    {
        [DataMember(Name = "Succeeded")]
        public bool IsSuccess { get; set; }

        [DataMember(Name = "message")]
        public string ReturnMessage { get; set; }

        [DataMember(Name = "data")]
        public T Data{ get; set; }
    }
}
