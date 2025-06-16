namespace DjurAPI.Models
{
    public class Animal
    {
        public int? Id { get; set; }
        public string? Species { get; set; }
        public double Weight { get; set; }
        public bool IsFlying { get; set; } = false;


    }
}
