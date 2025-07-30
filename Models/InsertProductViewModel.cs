using Microsoft.EntityFrameworkCore.Query.Internal;

namespace VillenStore._NET_Version.Models
{
    public class InsertProductViewModel
    {
        //Propriedade para salvar os produtos como lista;
        public IEnumerable<ProductModel>? ProductList { get; set; }
        // Propriedade para salvar o produto salvo/editado no formulário;
        public ProductModel NewProduct { get; set; }
    }
}
