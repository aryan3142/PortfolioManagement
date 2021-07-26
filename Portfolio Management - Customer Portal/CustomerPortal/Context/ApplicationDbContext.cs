using CustomerPortal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerPortal.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<PortfolioTransactionDetail> PortfolioDetails { get; set; }
        public DbSet<StockTransactionDetail> StockDetails { get; set; }
        public DbSet<MutualFundTransactionDetail> MutualFundDetails { get; set; }
    }
}
