using System.Data;
using Discount.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Discount.Context;

public class DapperContext : DbContext
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;

    public DapperContext(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString = _configuration.GetConnectionString("DefaultConnection");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost; Database=ECommerce-Discount; User Id=sa; Password=eyupfurkantuylu123");
    }
    
    public DbSet<Coupon> Coupons { get; set; }

    public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
}