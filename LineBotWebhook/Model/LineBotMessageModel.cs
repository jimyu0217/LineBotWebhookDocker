namespace LineBotWebhook.Model
{
    public class LineWebhookRequest
    {
        public string Destination { get; set; }
        public List<LineEvent> Events { get; set; }
    }

    public class LineEvent
    {
        public string Type { get; set; }
        public string ReplyToken { get; set; }
        public LineMessage Message { get; set; }
    }

    public class LineMessage
    {
        public string Type { get; set; }
        public string Text { get; set; }
    }

}
