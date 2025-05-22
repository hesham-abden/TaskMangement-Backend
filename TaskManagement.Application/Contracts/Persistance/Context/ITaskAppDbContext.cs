using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Contracts.Persistance.Context
{
    public interface ITaskAppDbContext
    {
        #region Methods
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        #endregion
        #region DbSets
        //DbSet<Governorate> Governorates { get; set; }
        #endregion
    }
}
