using System.ComponentModel.DataAnnotations;

namespace Cursos.Models.Entidades
{
    public class Professor
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Nome")]
        public string nome { get; set; }
        [Display(Name = "Cargo")]
        public string titulo { get; set; }
        [Display(Name="Resumo")]
        public string sobre { get; set; }
        [Display(Name ="Url da foto")]
        public string foto { get; set; }
        [Display(Name = "Url do Faceboók")]
        public string? urlFacebook { get; set; }
        [Display(Name = "Url do Twitter")]
        public string? urlTwitter { get; set; }
        [Display(Name = "Url do Instagram")]
        public string? urlInstagram { get; set; }

    }
}
