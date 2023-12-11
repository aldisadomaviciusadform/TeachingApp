using System.Text.Json;

namespace ShopAPI.Models
{
    public class ErrorViewModel
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }

    
}
