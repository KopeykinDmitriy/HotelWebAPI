using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hotel.Domain;

namespace Hotel.Application.Interfaces
{
    public interface IHotelDbContext
    {
        DbSet<Human> Humans { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
