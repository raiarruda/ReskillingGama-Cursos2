namespace WebApplication2.Dominio.Interfaces
{
    public interface IRepository<Tipo> where Tipo : class
    {
        List<Tipo> ObterTodos();
        Tipo ObterPorId(int id);
        void CriarNovo(Tipo entidade);
        void Atualiza(Tipo entidade);
        void Deleta(Tipo entidade);
        bool Salvar();
        bool Exists(int id);


    }
}
