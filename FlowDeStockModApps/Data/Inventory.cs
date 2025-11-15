using FlowDeStockModApps.Users;

/**
 * Inventory.cs
 * Emulation of an inventory that contains products.
 */
namespace FlowDeStockModApps.Data
{
    internal class Inventory(int idInventory, string name, List<Product> products, Company company)
    {
        // Attributes
        public int IDInventory { get; } = idInventory;
        public string Name { get; set; } = name;
        public ProductList ProductsList { get; } = new(products);
        public int IDCompany { get; } = company.IDCompany;

        // Methods

        // AddProduct is not defined because it is not necessary in this context

        /// <summary>
        /// Updates the product with a specified identifier using the provided new product details.
        /// <para>
        /// Throws an <c>ArgumentException</c> if not found.
        /// </para>
        /// </summary>
        /// <param name="IDProduct">The unique identifier of the product to update.</param>
        /// <param name="newProduct">The new product details to apply.</param>
        public void UpdateProduct(int IDProduct, Product newProduct)
        {
            ProductsList.Update(IDProduct, newProduct);
        }

        // DeleteProduct is not defined because it is not necessary in this context

        /// <summary>
        /// Gets the entity of the product with the specified identifier.
        /// <para>
        /// Throws an <c>ArgumentException</c> if not found.
        /// </para>
        /// </summary>
        /// <param name="IDProduct">The unique identifier of the product to retrieve.</param>
        /// <returns>The product entity with the specified identifier.</returns>
        public Product GetProduct(int IDProduct)
        {
            return ProductsList.Get(IDProduct);
        }

        // GetDescriptiveListOfProducts is not defined because it is not necessary in this context
    }
}
