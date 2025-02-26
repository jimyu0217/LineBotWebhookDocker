//var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    //app.UseSwagger();
    //app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();

var builder = WebApplication.CreateBuilder(args);

// 取得 Render 設定的 PORT（若無則預設為 5000）
var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";

var app = builder.Build();

// 綁定 Kestrel 伺服器到 0.0.0.0 並使用指定的 PORT
app.Urls.Add($"http://0.0.0.0:{port}");

app.MapGet("/", () => "Hello from Line Bot on Render!");

app.Run();

