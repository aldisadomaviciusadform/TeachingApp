using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace FileAPI.Models
{
    public class ErrorViewModel
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public ErrorViewModel(string message, int statusCode)
        {
            Message = message;
            StatusCode = statusCode;
        }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
