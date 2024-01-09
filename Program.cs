using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

/* Add services to container */

// Session config
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Swagger config
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Controller and Service config
builder.Services.AddControllers();
builder.Services.AddRepositories();
builder.Services.AddDomainServices();

// EF Core DbContext config
builder.Services.AddDbContext<Data.AppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

/* - - - - - - - - - - - - - */

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
else 
{
    app.UseSwagger();
    app.UseSwaggerUI();
}




/* App config section */

app.UseHttpsRedirection();
app.UseSession();           // Adds the session to our application
app.UseRouting();
app.UseAuthorization();
app.MapControllers();       // Adds the controllers to our application

app.Run();
