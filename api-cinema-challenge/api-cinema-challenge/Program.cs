using api_cinema_challenge.Data;
using api_cinema_challenge.Endpoints;
using api_cinema_challenge.Mapper;
using api_cinema_challenge.Models;
using api_cinema_challenge.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CinemaContext>();
builder.Services.AddScoped<IRepository<Customer>, Repository<Customer>>();
builder.Services.AddScoped<IRepository<Movie>, Repository<Movie>>();
builder.Services.AddScoped<IRepository<Screening>, Repository<Screening>>();
builder.Services.AddScoped<IRepository<Ticket>, Repository<Ticket>>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureCustomerEndpoints();
app.ConfigureMovieEndpoints();
app.ConfigureScreeningEndpoints();
app.ConfigureTicketEndpoints();

app.UseHttpsRedirection();
app.Run();
