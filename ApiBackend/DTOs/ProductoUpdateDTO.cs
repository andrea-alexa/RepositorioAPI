namespace ApiBackend.DTOs
{
    public class ProductoUpdateDTO
    {
        public int id { get; set; }

        public string nombre { get; set; }

        public decimal precio { get; set; }

        public int stock { get; set; }
    }
}
