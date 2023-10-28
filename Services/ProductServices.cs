namespace first_lesson.Services

{
    using first_lesson.Models;
    public class ProductService : List<ProductModel>
    {
        public ProductService()
        {
            AddRange(new ProductModel[]{
                new ProductModel{Id = 1, Name = "Laptop1", Price = 100},
                new ProductModel{Id = 2, Name = "Laptop2", Price = 200},
                new ProductModel{Id = 3, Name = "Laptop3", Price = 300},
                new ProductModel{Id = 4, Name = "Laptop4", Price = 400},
                new ProductModel{Id = 5, Name = "Laptop5", Price = 500},
            });
        }
    }
}