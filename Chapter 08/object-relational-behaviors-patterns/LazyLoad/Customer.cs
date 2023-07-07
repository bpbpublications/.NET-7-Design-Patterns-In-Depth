namespace LazyLoad
{
    public class CustomerDbSet
    {
        public static List<Customer> Customers = new()
        {
            new Customer { Id = 1, Name = "Vahid" },
            new Customer { Id = 2, Name = "Reza" },
            new Customer { Id = 3, Name = "Narges" },
            new Customer { Id = 4, Name = "Saman" },
            new Customer { Id = 5, Name = "Mehrad" },
            new Customer { Id = 6, Name = "Daniel" }
        };
    }
    public class OrderDbSet
    {
        public static List<Order> Orders = new()
        {
            new Order { Id = 100, Price = 1000, CustId = 1 },
            new Order { Id = 200, Price = 2500, CustId = 2 },
            new Order { Id = 300, Price = 1800, CustId = 1 },
            new Order { Id = 400, Price = 950, CustId = 3 },
            new Order { Id = 500, Price = 2200, CustId = 5 },
            new Order { Id = 600, Price = 1300, CustId = 6 },
            new Order { Id = 600, Price = 1300, CustId = 3 },
            new Order { Id = 600, Price = 1300, CustId = 2 },
            new Order { Id = 600, Price = 1300, CustId = 1 }
        };
    }
    public class Order
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public int CustId { get; set; }
    }
    /*Lazy Initialization*/
    public class Customer
    {
        private List<Order> orders;
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Order> Orders
        {
            get
            {
                if (orders == null)
                {
                    Console.WriteLine($"Loading orders for customer: {Name}");
                    orders = OrderDbSet.Orders.Where(x => x.CustId == Id).ToList();
                }
                return orders;
            }
        }
    }

    /*Lazy Initialization using Lazy class*/
    //public class Customer
    //{
    //    private Lazy<List<Order>> _orders;
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public Customer()
    //    {
    //        _orders = new Lazy<List<Order>>(() =>
    //        {
    //            return OrderDbSet.Orders.Where(x => x.CustId == this.Id).ToList();
    //        });
    //    }
    //    public List<Order> Orders => _orders.Value;
    //}

    /*Ghost*/
    //public class Customer
    //{
    //    private string _name;
    //    private List<Order> _orders;
    //    private bool _isOrdersLoaded;
    //    private bool _isloaded;
    //    public int Id { get; set; }

    //    public string Name
    //    {
    //        get
    //        {
    //            if (!_isloaded)
    //                Load();
    //            return _name;
    //        }
    //        set => _name = value;
    //    }
    //    public List<Order> Orders
    //    {
    //        get
    //        {
    //            if (!_isOrdersLoaded)
    //                LoadOrders();
    //            return _orders;
    //        }
    //    }
    //    private void Load()
    //    {
    //        var customer = CustomerDbSet.Customers.FirstOrDefault(x => x.Id == this.Id);
    //        this._name = customer.Name;
    //        _isloaded = true;
    //    }
    //    private void LoadOrders()
    //    {
    //        _orders = OrderDbSet.Orders.Where(x => x.CustId == this.Id).ToList();
    //        _isOrdersLoaded = true;
    //    }
    //}

    /*Value Holder*/
    //public class Customer
    //{
    //    private ValueHolder _valueHolder;
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public Customer() => _valueHolder = new ValueHolder(this.Id);
    //    public List<Order> Orders => _valueHolder.GetOrders();
    //    class ValueHolder
    //    {
    //        private List<Order> _orders;
    //        private readonly int _id;
    //        public ValueHolder(int id) => _id = id;
    //        public List<Order> GetOrders()
    //        {
    //            if (_orders == null)
    //                _orders = OrderDbSet.Orders.Where(x => x.CustId == _id).ToList();
    //            return _orders;
    //        }
    //    }
    //}

    /*Virtual Proxy*/
    //public interface IService
    //{
    //    public List<Order> Orders { get; }
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
    //public class Customer : IService
    //{
    //    private List<Order> _orders;
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public Customer() => _orders = OrderDbSet.Orders.Where(x => x.CustId == this.Id).ToList();
    //    public List<Order> Orders => _orders;
    //}
    //public class CustomerProxy : IService
    //{
    //    private IService _service;
    //    private void InitIfNeeded()
    //    {
    //        if (_service == null)
    //            _service = new Customer();
    //    }
    //    public List<Order> Orders
    //    {
    //        get
    //        {
    //            InitIfNeeded();
    //            return _service.Orders;
    //        }
    //    }

    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}
