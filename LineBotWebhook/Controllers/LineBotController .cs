using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using LineBotWebhook.Model;

[ApiController]
[Route("api/linebot")]
public class LineBotController : ControllerBase
{
    private readonly HttpClient _httpClient;
    private readonly string _channelAccessToken = "xxoGva8R8FCDmW6z6uBVmuO7sh/AXWvqL08bgJom7+TLm4ZG5H2elZWbunfwRjC4pifBQmzx7lOBA9MGJ/oeSS+gzE11+Ma1g6GTPOroUQFi1+1tKMDyOr0SOFML0+U2Xu8KLKNGuXoBoMfuKaFLXAdB04t89/1O/w1cDnyilFU="; // 使用你的Channel Access Token

    public LineBotController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] object requestBody)
    {
        Console.WriteLine("收到 LINE Webhook：" + requestBody.ToString());
        return Ok(); // 回傳 200 OK
    }
    
    private async Task ReplyToLineAsync(string replyToken, string message)
    {
        var replyMessage = new
        {
            replyToken,
            messages = new[]
            {
                new
                {
                    type = "text",
                    text = message
                }
            }
        };

        var content = new StringContent(JsonConvert.SerializeObject(replyMessage), Encoding.UTF8, "application/json");

        var request = new HttpRequestMessage(HttpMethod.Post, "https://api.line.me/v2/bot/message/reply")
        {
            Headers =
            {
                { "Authorization", $"Bearer {_channelAccessToken}" }
            },
            Content = content
        };

        // 發送請求到 Line API
        var response = await _httpClient.SendAsync(request);

        if (!response.IsSuccessStatusCode)
        {
            // 錯誤處理
            var error = await response.Content.ReadAsStringAsync();
            // Log error 或處理錯誤
        }
    }
}
