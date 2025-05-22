using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMangement.Domain.Entities.Common
{
    public interface IAuditableEntity
    {
        long? CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }
        long? LastModifiedBy { get; set; }
        DateTime? LastModifiedDate { get; set; }
    }
}
