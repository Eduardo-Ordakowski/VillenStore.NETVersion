using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VillenStore._NET_Version.Models
{
    //Criação do modelo de produto;
    public class ProductModel
    {
        public int Id { get; set;}
        public string? ImgUrl  { get; set; }

        [Required(ErrorMessage = "Digite o nome do produto!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Digite o preço do produto!")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Digite o tipo do produto")]
        public string Type { get; set; }

        // Armazenando a imagem do produto;
        [NotMapped]
        [DisplayName("Image")]
        public IFormFile? ImageFile { get; set; }
    }
}
