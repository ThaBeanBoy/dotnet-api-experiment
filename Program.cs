using Microsoft.OpenApi.Models;
using Products;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
       c.SwaggerDoc("v1", new OpenApiInfo { 
            Title = "Minimal API Experiment", 
            Description = "This is an experiment on using .Net to make a REST API. I used one of the tutorials provided by Microsoft.", 
            Version = "v1" 
            }
        );
   }
);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>{
     c.SwaggerEndpoint("/swagger/v1/swagger.json", "Todo API V1");
   }
);


app.MapGet("/", () => "Hello World!");

// Find a way to filter put the public property
app.MapGet("/products", ()=> ProductsDB.Products);

// Find a way to filter put the public property
app.MapGet("/products/{id}", (int id)=> ProductsDB.GetProduct(id));

// Create product

app.MapPost("/products", (Body ReqBody) => {
    Console.WriteLine(ReqBody.ID);
});

// Update product
// app.MapPut()
app.Run();

public record Body(int ID, string Name, bool Public);
