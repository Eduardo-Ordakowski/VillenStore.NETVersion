using Microsoft.EntityFrameworkCore.Query.Internal;

namespace VillenStore._NET_Version.Models
{
    public class InsertProductViewModel
    {
        //Propriedade para salvar os produtos como lista;
        public IEnumerable<ProductModel>? ProductList { get; set; }
        public ProductModel NewProduct { get; set; }
    }
}
