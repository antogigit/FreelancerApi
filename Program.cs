using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

// Configure middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

// Models
public class Freelancer
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public bool IsArchived { get; set; } = false;
    public List<Skillset> Skillsets { get; set; }
    public List<Hobby> Hobbies { get; set; }
}

public class Skillset
{
    public int Id { get; set; }
    public string SkillName { get; set; }
    public int FreelancerId { get; set; }
}

public class Hobby
{
    public int Id { get; set; }
    public string HobbyName { get; set; }
    public int FreelancerId { get; set; }
}

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Freelancer> Freelancers { get; set; }
    public DbSet<Skillset> Skillsets { get; set; }
    public DbSet<Hobby> Hobbies { get; set; }
}