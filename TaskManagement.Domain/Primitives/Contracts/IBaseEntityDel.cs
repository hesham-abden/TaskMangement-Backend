using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMangement.Domain.Entities.Common
{
    public interface IBaseEntityDel
    {
        bool IsDeleted { get; set; }
        long? DeletedBy { get; set; }
        DateTime? DeletedDate { get; set; }
    }
}
