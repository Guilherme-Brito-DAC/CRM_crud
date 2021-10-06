using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace CRM_Crud.Models
{
        [DataContract]
    public class BaseModel
    {
        [DataMember]
        public int id { get; set; }
    }
}
