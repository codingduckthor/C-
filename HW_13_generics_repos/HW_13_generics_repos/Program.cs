using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_13_generics_repos
{
   // Создать класс Product со следующими полями:

   //- int Id
   //- string Name
   //- double Price
   //- int Quantity
    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        private double price;
        public double Price
        {
            get => price;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Price cannot be negative");
                price = value;
            }
        }

        private int quantity;
        public int Quantity
        {
            get => quantity;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Quantity cannot be negative");
                quantity = value;
            }
        }

        public bool IsAvailable => Quantity > 0;

        public Product(int id, string name, double price, int quantity)
        {
            Id = id;
            Name = name;
            Price = price;
            Quantity = quantity;
        }
        //Переопределить метод ToString(), чтобы красиво выводить информацию о товаре
        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Price: {Price}, Qty: {Quantity}, Available: {IsAvailable}";
        }
    }

   // Создать обобщённый класс Repository<T>, который содержит:

   //- void Add(T item)
   //- void Remove(T item)
   //- List<T> GetAll()
   //- T Find(Predicate<T> predicate)
    class Repository<T>
    {
        //Внутри обязательно использовать List<T>.
        private List<T> items = new List<T>();

        public void Add(T item)
        {
            items.Add(item);
        }

        public void Remove(T item)
        {
            items.Remove(item);
        }

        public List<T> GetAll()
        {
            return items;
        }

        public T Find(Predicate<T> predicate)
        {
            return items.Find(predicate);
        }
    }

   // Создать класс ProductService, который:

   //- хранит товары через Repository<Product>
   //- автоматически генерирует Id для каждого товара
   //- позволяет добавлять, выводить и искать товары
    class ProductService
    {
        private Repository<Product> repo = new Repository<Product>();
        private int currentId = 1;

        public void AddProduct(string name, double price, int quantity)
        {
            var product = new Product(currentId++, name, price, quantity);
            repo.Add(product);
        }

        public void ShowAllProducts()
        {
            var products = repo.GetAll();

            if (products.Count == 0)
            {
                Console.WriteLine("No products.");
                return;
            }

            foreach (var p in products)
            {
                Console.WriteLine(p);
            }
        }

        public Product FindProductById(int id)
        {
            return repo.Find(p => p.Id == id);
        }

        public void RemoveProduct(int id)
        {
            var product = FindProductById(id);
            if (product != null)
            {
                repo.Remove(product);
            }
        }
        public List<Product> FindByName(string name)
        {
            return repo.GetAll()
                       .Where(p => p.Name.ToLower().Contains(name.ToLower()))
                       .ToList();
        }

        public void UpdatePrice(int id, double newPrice)
        {
            var product = FindProductById(id);
            if (product != null)
            {
                product.Price = newPrice;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ProductService service = new ProductService();
           // Создать консольное меню в Program.cs:

           //1.Добавить товар
           //2.Показать все товары
           //3.Найти товар по Id
           //4.Удалить товар
           //0.Выход

            while (true)
            {
                Console.WriteLine("\n1. Add product");
                Console.WriteLine("2. Show all");
                Console.WriteLine("3. Find by ID");
                Console.WriteLine("4. Remove product");
                Console.WriteLine("0. Exit");

                Console.Write("Choose: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Name: ");
                        string name = Console.ReadLine();

                        Console.Write("Price: ");
                        double price = double.Parse(Console.ReadLine());

                        Console.Write("Quantity: ");
                        int qty = int.Parse(Console.ReadLine());

                        service.AddProduct(name, price, qty);
                        break;

                    case "2":
                        service.ShowAllProducts();
                        break;

                    case "3":
                        Console.Write("Enter ID: ");
                        int id = int.Parse(Console.ReadLine());

                        var product = service.FindProductById(id);
                        Console.WriteLine(product != null ? product.ToString() : "Not found");
                        break;

                    case "4":
                        Console.Write("Enter ID: ");
                        int removeId = int.Parse(Console.ReadLine());

                        service.RemoveProduct(removeId);
                        break;

                    case "0":
                        return;
                }
            }
        }
    }
}
