

using Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Data.Contexts;

public class DataContext(DbContextOptions<DataContext> options) : IdentityDbContext<MemberEntity>(options)
{
    public virtual DbSet<MemberAddressEntity> MemberAddreses { get; set; }
    public virtual DbSet<ProjectEntity> Projects { get; set; }
}
