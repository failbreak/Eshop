using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Service;

namespace TEstOfProduct
{
    public class Test
    {
        #region Product
        [Fact]
        public void AddProdukt()
        {
            //arrange
            var _context = Extension.CreateContext();
            var _productService = new ProductService(_context);

            //act
            var testprod = new Product();
            testprod.Name = "Destiny";
            testprod.Price = 69;
            testprod.ProductId = 1;


            _productService.AddProduct(testprod);

            var product = _context.Products.ToList().First();
            Assert.Equal(testprod.Name, product.Name);
        }
        [Fact]
        public void RemoveProdukt()
        {
            //arrange
            var _context = Extension.CreateContext();
            var _productService = new ProductService(_context);

            //act
            var testprod = new Product();
            testprod.Name = "Smite";
            testprod.Price = 1;
            testprod.ProductId = 1;


            _productService.AddProduct(testprod);
            _productService.RemoveProduct(1);

            var product = _context.Products.ToList().First();
            Assert.Equal(true, product.IsDeleted);
        }
        [Fact]
        public void EditProdukt()
        {
            //arrange
            var _context = Extension.CreateContext();
            var _productService = new ProductService(_context);

            //act
            var testprod = new Product();
            testprod.Name = "lol";
            testprod.Price = 69;


            _productService.AddProduct(testprod);

            testprod.Name = "notlol";
            _productService.EditProduct(testprod);
            var product = _context.Products.ToList().First();
            Assert.Equal(testprod.Name, product.Name);
        }
        //[Fact]
        //public void SaearchProdukt()
        //{
        //    //arrange
        //    var _context = Extension.CreateContext();
        //    var _productService = new ProductService(_context);

        //    //act
        //    var testprod = new Product();
        //    testprod.Name = "lol";
        //    testprod.Price = 69;


        //    _productService.AddProduct(testprod);

        //    var product = _productService.Search("lol").First();
        //    Assert.Equal(testprod.Name, product.Name);
        //}
        #endregion

        #region Customer

        [Fact]
        public void AddCustomer()
        {
            //arrange
            var _context = Extension.CreateContext();
            var _CustService = new CustomerService(_context);

            //act
            var testprod = new Customer();
            testprod.FirstName = "lol";
            testprod.LastName = "slol";
            testprod.Address = "lolstreet";
            testprod.email = "lol@lol.lol";
            testprod.CustomerId = 69;


            _CustService.CreateCustomer(testprod);

            var customer = _context.Customers.ToList().First();
            Assert.Equal(testprod.FirstName, customer.FirstName);
        }
        [Fact]
        public void RemoveCust()
        {
            //arrange
            var _context = Extension.CreateContext();
            var _CustService = new CustomerService(_context);

            //act
            var testprod = new Customer();
            testprod.FirstName = "lol";
            testprod.LastName = "slol";
            testprod.Address = "lolstreet";
            testprod.email = "lol@lol.lol";
            testprod.CustomerId = 69;


            _CustService.CreateCustomer(testprod);
            _CustService.DeleteCustomer(69);

            var customer = _context.Customers.ToList().First();
            Assert.Equal(true, customer.IsDeleted);
        }
        [Fact]
        public void EditCust()
        {
            //arrange
            var _context = Extension.CreateContext();
            var _CustService = new CustomerService(_context);

            //act
            var testprod = new Customer();
            testprod.FirstName = "lol";
            testprod.LastName = "slol";
            testprod.Address = "lolstreet";
            testprod.email = "lol@lol.lol";
            testprod.CustomerId = 69;


            _CustService.CreateCustomer(testprod);

            testprod.FirstName = "notlol";
            _CustService.EditCustomer(testprod);
            var customer = _context.Customers.ToList().First();
            Assert.Equal(testprod.FirstName, customer.FirstName);
        }

        #endregion

        #region order

        [Fact]
        public void Createorder()
        {
            //arrange
            var _context = Extension.CreateContext();
            var _OrderService = new OrderService(_context);
            //act
            var customer = new Customer();
            customer.FirstName = "lol";
            customer.LastName = "slol";
            customer.Address = "lolstreet";
            customer.email = "lol@lol.lol";
            customer.CustomerId = 69;
            var testprod = new Order();
            testprod.OrderId = 1;
            testprod.PurchaseDate = DateTime.UtcNow;
            testprod.Customer = customer;
            _OrderService.CreateOrder(customer);
            var Order = _context.Orders.ToList().First();
            Assert.Equal(testprod.OrderId, Order.OrderId);
        }

        /*         
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀ ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⣠⣶⡾⠏⠉⠙⠳⢦⡀⠀⠀⠀⢠⠞⠉⠙⠲⡀⠀
                ⠀⠀⠀⣴⠿⠏⠀⠀⠀⠀⠀⠀⢳⡀⠀⡏⠀⠀⠀⠀⠀⢷
                ⠀⠀⢠⣟⣋⡀⢀⣀⣀⡀⠀⣀⡀⣧⠀⢸⠀⠀⠀⠀⠀ ⡇
                ⠀⠀⢸⣯⡭⠁⠸⣛⣟⠆⡴⣻⡲⣿⠀⣸⠀⠀no⠀  ⡇
                ⠀⠀⣟⣿⡭⠀⠀⠀⠀⠀⢱⠀⠀⣿⠀⢹ update ⡇
                ⠀⠀⠙⢿⣯⠄⠀⠀⠀⢀⡀⠀⠀⡿⠀⠀⡇order ⡼
                ⠀⠀⠀⠀⠹⣶⠆⠀⠀⠀⠀⠀⡴⠃⠀⠀⠘⠤⣄⣠⠞⠀
                ⠀⠀⠀⠀⠀⢸⣷⡦⢤⡤⢤⣞⣁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⢀⣤⣴⣿⣏⠁⠀⠀⠸⣏⢯⣷⣖⣦⡀⠀⠀⠀⠀⠀⠀
                ⢀⣾⣽⣿⣿⣿⣿⠛⢲⣶⣾⢉⡷⣿⣿⠵⣿⠀⠀⠀⠀⠀⠀
                ⣼⣿⠍⠉⣿⡭⠉⠙⢺⣇⣼⡏⠀⠀⠀⣄⢸⠀⠀⠀⠀⠀⠀
                ⣿⣿⣧⣀⣿………⣀⣰⣏⣘⣆⣀⠀⠀
        */

        [Fact]
        public void GetOrder()
        {
            //arrange
            var _context = Extension.CreateContext();
            var _OrderService = new OrderService(_context);
            //act
            var customer = new Customer();
            customer.FirstName = "lol";
            customer.LastName = "slol";
            customer.Address = "lolstreet";
            customer.email = "lol@lol.lol";
            customer.CustomerId = 69;
            var testprod = new Order();
            testprod.OrderId = 1;
            testprod.PurchaseDate = DateTime.UtcNow;
            testprod.Customer = customer;
            _OrderService.CreateOrder(customer);
            var Order = _OrderService.GetOrders();
            Assert.Equal(testprod.OrderId, Order[0].OrderId);
        }

        #endregion

    }

}