using System.ComponentModel.DataAnnotations;

namespace InduMovel.Models
{
    public class Movel
    {
        public int MovelId { get; set; }
        [Display(Name = "Nome do móvel")]
        [Required(ErrorMessage = "Informe o nome do móvel")]
        [MinLength(4, ErrorMessage = "Nome deve ter no minimo {1} caracteres")]
        [MaxLength(40, ErrorMessage = "Nome dever ter no maximo {1} caracteres")]
        public string Nome { get; set; }
        [Display(Name = "Descrição do móvel")]
        [Required(ErrorMessage = "Informe a descrição do móvel")]
        [MinLength(20, ErrorMessage = "Descrição deve ter no minimo {1} caracteres")]
        [MaxLength(150, ErrorMessage = "Descrição dever ter no maximo {1} caracteres")]
        public string Descricao { get; set; }
        [Display(Name = "Cor do móvel")]
        [Required(ErrorMessage = "Informe a cor do móvel")]
        [MinLength(4, ErrorMessage = "Cor deve ter no minimo {1} caracteres")]
        [MaxLength(10, ErrorMessage = "Cor dever ter no maximo {1} caracteres")]
        public string Cor { get; set; }
        [Display(Name = "Informe o caminho da Imagem")]
        public string ImagemUrl { get; set; }
        [Display(Name = "Informe o caminho da Imagem Pequena")]
        public string ImagemPequenaUrl { get; set; }
        [Display(Name = "Valor do móvel")]
        [Required(ErrorMessage = "O valor deve ser informado")]
        [Range(1, 20000, ErrorMessage = "O valor deve estar entre {1} e {2}")]
        public double Valor { get; set; }
        [Display(Name = "Em linha de produção")]
        public bool EmProducao { get; set; }
        [Display(Name = "Móvel ativo ")]
        public bool Ativo { get; set; }
        [Display(Name = "Categoria do móvel")]
        [Required(ErrorMessage = "Informe a categoria do móvel")]
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}