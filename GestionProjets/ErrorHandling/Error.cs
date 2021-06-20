using System.Text.Json;

namespace GestionProjets.ErrorHandling
{
    public class Error
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
