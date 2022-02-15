using Cursos.Models.Entidades;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Cursos.Models.ViewModels
{
    public class PostagemBlogViewModel
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Título da Postagem")]
        public string tituloPost { get; set; }
        [DisplayName("Imagem da Postagem")]
        public string imagemCapa { get; set; }
        [DisplayName("Conteúdo da Postagem")]
        public string conteudo { get; set; }
        public int? gostei { get; set; } = 0;
        public int? naoGostei { get; set; } = 0;
        [DisplayName("Data de Publicação")]
        public DateTime? dataPublicacao { get; set; } = DateTime.Now;
        [DisplayName("Autor da Postagem")]
        public string autor { get; set; }

        
    }
}