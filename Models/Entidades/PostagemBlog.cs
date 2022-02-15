using System.ComponentModel.DataAnnotations;

namespace Cursos.Models.Entidades
{
    public class PostagemBlog
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Título")]
        public string tituloPost { get; set; }
        [Display(Name ="Url da Imagem")]
        public string imagemCapa { get; set; }
        [Display(Name = "Conteúdo")]
        public string conteudo { get; set; }
        [Display(Name = "Gostei")]
        public int? gostei { get; set; } = 0;
        [Display(Name = "Não Gostei")]
        public int? naoGostei { get; set; } = 0;
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        [Display(Name = "Data de Publicação")]
        public DateTime? dataPublicacao { get; set; } = DateTime.Now;
        [Display(Name = "Autor")]
        public string autor { get; set; }
    }
}
