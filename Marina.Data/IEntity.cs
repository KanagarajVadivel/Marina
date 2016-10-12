using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marina.Data
{
    public interface IEntity
    {
        DateTime CreatedOn { get; set; }
        int CreatedBy { get; set; }
        DateTime UpdatedOn { get; set; }
        int UpdatedBy { get; set; }                
    }
}
