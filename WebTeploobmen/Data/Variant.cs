using System.ComponentModel.DataAnnotations;

namespace WebTeploobmen.Data
{
    public class Variant
    {
        [Key]
        public int Id { get; set; }
        public int? UserId { get; set; }

        public double height { get; set; }

        public double mattemp { get; set; }

        public double gaztemp { get; set; }

        public double haste { get; set; }

        public double gaztepl { get; set; }

        public double rashod { get; set; }

        public double mattepl { get; set; }

        public double koef { get; set; }

        public double diametr { get; set; }
    }
}

