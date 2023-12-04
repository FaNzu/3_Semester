var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


//builder.Services.AddCors(options =>
//{
//	options.AddPolicy(name: test,
//		policy =>
//		{
//			policy.WithOrigins("http://dr.dk");

//			policy.WithMethods("GET")
//			.AllowAnyHeader();

//		});
//}); // her er det kun http://dr.dk/ som kun har lov til at bruge "GET" men alle header
//app.UseCors(); skal bruges til den koden set over

app.UseCors(options =>
{
	options.AllowAnyOrigin();
	options.AllowAnyMethod();
	options.AllowAnyHeader();
}); // dette tillader alle adgang og kan bruge alle metoder

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
