using System;

namespace Bangazon
{
  class Program
  {
    static void Main(string[] args)
    {
      Terminal UI = new Terminal();
      string mainMenuInput = "";
      while (mainMenuInput != "exit")
      {
        Console.Write(UI.getMainMenu());
        mainMenuInput = Console.ReadLine();
        if (mainMenuInput == "exit")
        {
          return;
        }
        int menuSelection = Convert.ToInt32(mainMenuInput);
        switch (menuSelection)
        {
          case 1: // when case "Add Customer"
            Customer newCustomer = UI.createNewCustomer();
            // need to insert this new object into the DB.
            newCustomer.insertCustomer();
            break;
          case 2: // when case "Add Payment Option"
            PaymentMethod newPaymentMethod = UI.createPaymentMethod();
            newPaymentMethod.insertPaymentMethod();
            break;
          case 3: // when case "Order Product"
            Console.WriteLine(UI.getCustomerOptions());
            string selectedCustomer = Console.ReadLine();
            // Determine which customer is placing the order
            int customerSelection = Convert.ToInt32(selectedCustomer);
            bool displayProducts = true;
            while (displayProducts)
            {
              // Present all products to user
              Console.WriteLine(UI.showProductsToOrder());
              // whichever product the user picks, add to ProductOrder DB with selected customer
              string selectedProduct = Console.ReadLine();
              int productSelection = Convert.ToInt32(selectedProduct);
              // insert order into ProductOrder DB
              if (productSelection == 0)
              {
                break;
              }

              ProductOrder newProductOrder = new ProductOrder()
              {
                ProductId = productSelection,
                CustomerId = customerSelection
              };
              newProductOrder.insertProductOrder();
              // display which product the user selected
              // re-display all products to user
            }
            break;
          case 4: // when case "Checkout"
            Console.Write(UI.getCustomerOptions());
            selectedCustomer = Console.ReadLine();
            // Determine which customer is placing the order
            customerSelection = Convert.ToInt32(selectedCustomer);
            // get records from ProductOrder DB where selected customer
            string customerOrderSummary = UI.getCustomerOrderSummary(customerSelection);
            Console.WriteLine(customerOrderSummary);
            if (customerOrderSummary == "If you don't need to be rescued by anyone, what exactly are you trying to buy?")
            {
              break;
            }
            // confirm that customer wants to checkout
            Console.WriteLine("Would you like to order these heroes now? Yes/No");
            Console.Write("> ");
            string orderConfirmation = Console.ReadLine();
            if (orderConfirmation == "No")
            {
              Console.WriteLine("OK, it's your peril. Hope you don't die.");
              break;
            }
            else
            {
              // select payment type based on customerSelection
              Console.Write(UI.getPaymentOptions(customerSelection));
            }
            string selectedPaymentOption = Console.ReadLine();
            int paymentSelection = Convert.ToInt32(selectedPaymentOption);
            // update ProductOrder DB to complete order
            UI.completeProductOrders(paymentSelection, customerSelection);
            Console.WriteLine("Your heroes are on the way! Press any key to return to main menu.");
            Console.ReadKey();
            break;
          case 5:
            Console.WriteLine(UI.getProductPopularity());
            Console.WriteLine("-> Press any key to return to main menu");
            Console.ReadKey();
            break;
        }
      }
    }
  }
}
