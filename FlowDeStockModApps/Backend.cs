using FlowDeStockModApps.Data;
using FlowDeStockModApps.Users;

/**
 * Backend.cs
 * Emulates the requests that the users would do to the backend.
 */
namespace FlowDeStockModApps
{

    public enum RequestStatus
    {
        SUCCESS,
        FAILED,
        UNAUTHORIZED,
        NOT_FOUND
    }

    public enum StockChangeOperation
    {
        INCREASE,
        DECREASE
    }

    internal class Backend
    {
        public static RequestStatus MakeRequestToChangeStock(User userMakingTheRequest, StockChangeOperation typeOfOperation, Inventory inventory, int productID, int amount)
        {
            try
            {
                // Simulate making a request to the backend
                Console.WriteLine($"The user {userMakingTheRequest.Name} is trying to modify a product.");

                // Validate users permissions before doing anything. If it is not an admin, reject the request
                if (userMakingTheRequest.Role != Roles.ADMIN)
                {
                    throw new UnauthorizedAccessException("The user does not have permissions to modify the stock.");
                }

                // Fetch the intended product from the inventory
                Product intendedProduct = inventory.GetProduct(productID);

                // Evaluate the type of operation
                if (typeOfOperation == StockChangeOperation.INCREASE)
                {
                    // Increase the stock
                    intendedProduct.AddUnitsOfProduct(amount);

                    // Then update the inventory with the new product state
                    inventory.UpdateProduct(productID, intendedProduct);

                    Console.WriteLine($"The stock for product ID {productID} has been increased by {amount} units.");

                    // Return success
                    return RequestStatus.SUCCESS;
                }
                else
                {
                    // Decrease the stock
                    intendedProduct.RemoveUnitsOfProduct(amount);

                    // Then update the inventory with the new product state
                    inventory.UpdateProduct(productID, intendedProduct);

                    Console.WriteLine($"The stock for product ID {productID} has been decreased by {amount} units.");

                    // Return success
                    return RequestStatus.SUCCESS;
                }

            }
            catch (KeyNotFoundException e)
            {
                Console.WriteLine(e.Message);
                return RequestStatus.NOT_FOUND;
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                return RequestStatus.FAILED;
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
                return RequestStatus.UNAUTHORIZED;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return RequestStatus.FAILED;
            }
        }
    }
}
