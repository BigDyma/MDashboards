using Entity.Models;
using Microsoft.EntityFrameworkCore;


namespace Entity
{
    interface IApplicationContext
    {
        DbSet<Payment> Payments { get; set; }

    }
}
