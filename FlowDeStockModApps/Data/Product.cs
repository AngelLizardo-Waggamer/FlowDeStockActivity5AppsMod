/**
 * Product.cs
 * Model of the product entity.
 */

namespace FlowDeStockModApps.Data
{
    public class Product(string name, string description, int quantity, float price, string category)
    {
        // Attributes
        public string Name { get; set; } = name;
        public string Description { get; set; } = description;
        public int Quantity { get; set; } = quantity;
        public float Price { get; set; } = price;
        public string Category { get; set; } = category;

        // Methods

        // CalculatePriceOfInventory is not defined because it is not necessary in this context

        /// <summary>
        /// Adds the specified number of units to the current product quantity.
        /// <para>
        /// The param <c>units</c> must be a positive integer that is not zero. If that's the case the method does nothing.
        /// </para>
        /// 
        /// </summary>
        public void AddUnitsOfProduct(int units)
        {
            // Negative values will cause unexpected behavior, so it is necessary to throw an exception if it is that.
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(units);

            Quantity += units;
        }

        /// <summary>
        /// Removes a specified number of units from the current product quantity.
        /// 
        /// <para>
        /// The param <c>units</c> must be a positive integer that is not zero and cannot exceed the current quantity.
        /// </para>
        /// </summary>
        /// <param name="units"></param>
        public void RemoveUnitsOfProduct(int units)
        {
            // Negative values will cause unexpected behavior, so they are ignored.
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(units);

            // If the number exceeds the current quantity, throw an Exception.
            ArgumentOutOfRangeException.ThrowIfGreaterThan(units, Quantity);
            
            Quantity -= units;
        }
    }
}
