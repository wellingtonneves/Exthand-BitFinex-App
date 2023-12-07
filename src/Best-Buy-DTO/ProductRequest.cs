namespace Best.Buy.DTO
{
    public class ProductRequest : RequestBase
    {
        public int? CategoryId { get; set; }

        public string Name { get; set; }
    }
}
