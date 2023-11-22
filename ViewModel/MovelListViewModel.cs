using InduMovel.Models;

namespace InduMovel.ViewModel
{
    public class MovelListViewModel
    {
        public IEnumerable<Movel> Moveis { get; set; }
        public string CategoriaAtual { get; set; }
    }
}