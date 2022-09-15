namespace Exthand.Bitfinex.DTO
{
    public class ExthandTradeRequest
    {
        public int Limit { get; set; }

        public string Start { get; set; }

        public string End { get; set; }

        public int Sort { get; set; }

        public string Symbol { get; set; }
    }
}
