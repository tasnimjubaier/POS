using Newtonsoft.Json;
using POS.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;

namespace POS.Service
{
    public class ServiceManager
    {
        private static ServiceManager? _instance;

        public string FolderName = "POSData";
        public List<string> JsonFiles = new List<string> { "Purchases.json", "Employees.json", "Customers.json", "Bills.json", "Products.json", "Categories.json" };

        JsonSerializerSettings JsonSerializerSettings;

        public ServiceManager()
        {
            CreateDirectoryAndFiles();
            JsonSerializerSettings = new JsonSerializerSettings();
            JsonSerializerSettings.Formatting = Formatting.Indented;
            JsonSerializerSettings.DateFormatString = "yyyy-MM-ddTHH:mm:ssZ";
        }

        public static ServiceManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ServiceManager();
            }
            return _instance;
        }

        public void CreateDirectoryAndFiles()
        {
            string appDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), FolderName);
            
            if (!Directory.Exists(appDataFolder))
            {
                Directory.CreateDirectory(appDataFolder);
            }

            string filePath = Path.Combine(appDataFolder, JsonFiles[0]);
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, "[]");
            }

            filePath = Path.Combine(appDataFolder, JsonFiles[1]);
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, "[]");
            }

            filePath = Path.Combine(appDataFolder, JsonFiles[2]);
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, "[]");
            }

            filePath = Path.Combine(appDataFolder, JsonFiles[3]);
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, "[]");
            }

            filePath = Path.Combine(appDataFolder, JsonFiles[4]);
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, "[]");
            }

            filePath = Path.Combine(appDataFolder, JsonFiles[5]);
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, "[]");
            }
        }

        public string GetFile(int index)
        {
            string appDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), FolderName);
            string filePath = Path.Combine(appDataFolder, JsonFiles[index]);
            return filePath;
        }

        #region Write Data

        public async Task WritePurchases(ObservableCollection<Purchase> purchases)
        {
            string jsonData = JsonConvert.SerializeObject(purchases, JsonSerializerSettings);
            string filePath = GetFile(0);
            await File.WriteAllTextAsync(filePath, jsonData);
        }

        public async Task WriteEmployees(ObservableCollection<Employee> employees)
        {
            string jsonData = JsonConvert.SerializeObject(employees, JsonSerializerSettings);
            string filePath = GetFile(1);
            await File.WriteAllTextAsync(filePath, jsonData);
        }

        public async Task WriteCustomers(CustomerModel customerModel)
        {
            string jsonData = JsonConvert.SerializeObject(customerModel);
            string filePath = GetFile(2);
            await File.WriteAllTextAsync(filePath, jsonData);
        }

        public async Task WriteBills(BillModel billModel)
        {
            string jsonData = JsonConvert.SerializeObject(billModel);
            string filePath = GetFile(3);
            await File.WriteAllTextAsync(filePath, jsonData);
        }

        public async Task WriteProducts(ProductModel productModel)
        {
            string jsonData = JsonConvert.SerializeObject(productModel);
            string filePath = GetFile(4);
            await File.WriteAllTextAsync(filePath, jsonData);
        }

        public async Task WriteCategories(CategoryModel categoryModel)
        {
            string jsonData = JsonConvert.SerializeObject(categoryModel);
            string filePath = GetFile(5);
            await File.WriteAllTextAsync(filePath, jsonData);
        }

        #endregion

        #region Read Data

        public async Task<ObservableCollection<Purchase>> GetPurchases()
        {
            ObservableCollection<Purchase> purchases = new ObservableCollection<Purchase>();

            string filePath = GetFile(0);

            string jsonData = await File.ReadAllTextAsync(filePath);

            if (!(jsonData == null || jsonData == string.Empty))
            {
                purchases = JsonConvert.DeserializeObject<ObservableCollection<Purchase>>(jsonData);
            }

            return purchases;
        }

        public async Task<ObservableCollection<Employee>> GetEmployees()
        {
            ObservableCollection<Employee> employees = new ObservableCollection<Employee>();

            string filePath = GetFile(1);

            string jsonData = await File.ReadAllTextAsync(filePath);

            if (!(jsonData == null || jsonData == string.Empty))
            {
                employees = JsonConvert.DeserializeObject<ObservableCollection<Employee>>(jsonData);
            }

            return employees;
        }

        public async Task<ObservableCollection<Customer>> GetCustomers()
        {
            ObservableCollection<Customer> customers = new ObservableCollection<Customer>();

            string filePath = GetFile(2);

            string jsonData = await File.ReadAllTextAsync(filePath);

            if (!(jsonData == null || jsonData == string.Empty))
            {
                customers = JsonConvert.DeserializeObject<ObservableCollection<Customer>>(jsonData);
            }

            return customers;
        }

        public async Task<ObservableCollection<Bill>> GetBills()
        {
            ObservableCollection<Bill> bills = new ObservableCollection<Bill>();

            string filePath = GetFile(3);

            string jsonData = await File.ReadAllTextAsync(filePath);

            if (!(jsonData == null || jsonData == string.Empty))
            {
                bills = JsonConvert.DeserializeObject<ObservableCollection<Bill>>(jsonData);
            }

            return bills;
        }

        public async Task<ObservableCollection<Product>> GetProducts()
        {
            ObservableCollection<Product> products = new ObservableCollection<Product>();

            string filePath = GetFile(4);

            string jsonData = await File.ReadAllTextAsync(filePath);

            if (!(jsonData == null || jsonData == string.Empty))
            {
                products = JsonConvert.DeserializeObject<ObservableCollection<Product>>(jsonData);
            }

            return products;
        }

        public async Task<ObservableCollection<string>> GetCategories()
        {
            ObservableCollection<string> categories = new ObservableCollection<string>();

            string filePath = GetFile(5);

            string jsonData = await File.ReadAllTextAsync(filePath);

            if (!(jsonData == null || jsonData == string.Empty))
            {
                categories = JsonConvert.DeserializeObject<ObservableCollection<string>>(jsonData);
            }

            return categories;
        }

        #endregion
    }
}
