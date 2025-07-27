namespace VillenStore._NET_Version.Models
{
    //Criação do modelo de produto;
    public class ProductModel
    {
        public int Id { get; set;}
        public string ImgUrl  { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Type { get; set; }
    }
}
