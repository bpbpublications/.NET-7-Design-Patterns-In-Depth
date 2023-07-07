public class ESaleTS
{
    public bool Sale(int productId, int productCount, int userId)
    {
        /*
        * Inventory check.
        var product = tblProduct.Find(productId);

        if(product.Stock<productCount){
        	throw new Exception("The product is not available enough.");
        }
        * Check wallet balance.
        var userWallet = tblUserWallet.FirstOrDefault(x=>x.UserId==userId)
        var totalPrice = productCount*product.UnitPrice;

        if(userWallet.Balance < totalPrice){
                throw new Exception("The balance of the wallet is not enough.");
        }

        * Deduct the purchase amount from the wallet balance.
        userWallet.Balance = userWallet.Balance - totalPrice;

        * Subtract the number of requested goods from the total number of available goods.
        product.Stock = product.Stock - productCount;

        * Registration of shipment request.
        DeliveryRequest request = new DeliveryRequest(
                                        item: product, 
                                        count: productCount, 
                                        user: userId);
        tblDeliveryRequest.Add(request);
        Save();
        */
        Console.WriteLine("Sale Done!");
        return true;
    }

}