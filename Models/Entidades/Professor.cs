using System.ComponentModel.DataAnnotations;

namespace Cursos.Models.Entidades
{
    public class Professor
    {
        [Key]
        public int Id { get; set; }
        public string nome { get; set; }
        public string titulo { get; set; }
        public string sobre { get; set; }
        public string foto { get; set; }
        public string? urlFacebook { get; set; }
        public string? urlTwitter { get; set; }
        public string? urlInstagram { get; set; }

    }
}
