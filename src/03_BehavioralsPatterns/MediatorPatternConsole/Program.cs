

Product product1 = new Product { Name = "Product A", Price = 10.0m };
Product product2 = new Product { Name = "Product B", Price = 20.0m };

ShoppingCart cart = new ShoppingCart();
PaymentGateway paymentGateway = new PaymentGateway();

IMediator mediator = new ConcreteMediator(cart, paymentGateway);

cart.AddItemToCart(product1);
cart.AddItemToCart(product2);

cart.Checkout();
