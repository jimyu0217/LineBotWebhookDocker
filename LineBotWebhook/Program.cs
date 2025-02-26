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

// 註冊 HttpClient 服務
builder.Services.AddHttpClient();  //這行將註冊 HttpClient

// 註冊 Controller 服務
builder.Services.AddControllers();

var app = builder.Build();

// 設置應用監聽 PORT
var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
app.Urls.Add($"http://0.0.0.0:{port}");

app.MapControllers(); // 啟動 Controller 路由
app.Run();



