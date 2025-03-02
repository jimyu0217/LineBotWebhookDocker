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
    private readonly string _channelAccessToken = "your own chaneel access token"; // 使用你的Channel Access Token

    public LineBotController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] LineWebhookRequest request)
    {
        // 處理 LINE Webhook 請求，回應訊息
        foreach (var eventData in request.Events)
        {
            if (eventData.Type == "message")
            {
                var replyToken = eventData.ReplyToken;
                var userMessage = eventData.Message.Text;

                // 呼叫 Line API 回應訊息
                await ReplyToLineAsync(replyToken, $"You said : {userMessage}");
            }
        }

        return Ok();
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
