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

// 註冊控制器服務
builder.Services.AddControllers(); // ✅ 這行必須加上，註冊 Controllers

var app = builder.Build();

// 取得 Render 環境變數 PORT，若未設定則預設為 5000
var port = Environment.GetEnvironmentVariable("PORT") ?? "4000";
app.Urls.Add($"http://0.0.0.0:{port}");

// 確保註冊 Controller 的路由
app.MapControllers(); // ✅ 讓 Controller 的路由生效

app.Run();


