/**
 * ProductList.cs
 * This class only serves as a REST emulator for the list of products, supposing that every product needs an ID and they need to be found using an ID.
 */

namespace FlowDeStockModApps.Data
{
    internal class ProductList
    {
        // Reference of the last putted ID
        private int LastID = 0;

        // The dictionary is not exactly a list, but it will use an auto-incremental int variable to emulate the constant growth of an ID in a DB
        public Dictionary<int, Product> Products = [];

        // Constructor that initializes the dictionary with values
        public ProductList(List<Product> initialProducts)
        {
            foreach (Product product in initialProducts)
            {
                this.Add(product);
            }
        }

        // Methods

        /// <summary>
        /// Adds a product to the list and returns the auto-incremented ID associated with it.
        /// </summary>
        /// <param name="product">The product entity to store.</param>
        /// <returns>The auto-incremented ID associated with the added product.</returns>
        public int Add(Product product)
        {
            // First the auto-increment happens
            LastID++;

            // Then using the new ID the product is added
            Products.Add(LastID, product);

            // Return the "ID" of the product
            return LastID;
        }

        /// <summary>
        /// Updates a product at a given ID with a new product.
        /// </summary>
        /// <param name="IDProduct">The unique identifier of the product to update.</param>
        /// <param name="newProduct">The new product details to apply.</param>
        /// <exception cref="KeyNotFoundException">Thrown when the product with the specified ID is not found.</exception>
        public void Update(int IDProduct, Product newProduct)
        {
            // Check if the key actually stores a value
            if (!Products.ContainsKey(IDProduct))
            {
                throw new KeyNotFoundException("There's no product associated with the given ID");
            }

            // If no exception was raised, the product at the ID is changed with the new product
            Products[IDProduct] = newProduct;
        }

        // Delete is not defined because it is not necessary in this context

        /// <summary>
        /// Retrieves the product associated with the specified product ID.
        /// </summary>
        /// <param name="IDProduct">The unique identifier of the product to retrieve. Must correspond to an existing product.</param>
        /// <returns>The product that matches the specified product ID.</returns>
        /// <exception cref="KeyNotFoundException">Thrown if no product is associated with the specified <paramref name="IDProduct"/>.</exception>
        public Product Get(int IDProduct)
        {
            // Check if the key actually stores a value
            if (!Products.ContainsKey(IDProduct))
            {
                throw new KeyNotFoundException("There's no product associated with the given ID");
            }

            // If no exception was raised, return the product at the ID.
            return Products[IDProduct];
        }

        // ListProducts is not defined because it is not necessary in this context
    }
}