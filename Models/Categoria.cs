namespace InduMovel.Models
{
    public class Categoria
    {
        public int CategoriaId {get; set;}
        public string Nome {get; set;}
        public List<Movel> Moveis {get; set;}
    }
}