using Newtonsoft.Json;
using POS.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace POS.Service
{
    public class ServiceManager
    {
        private static ServiceManager? _instance;

        public string FolderName = "POSData";
        public List<string> JsonFiles = new List<string> { "Purchases.json", "Employees.json", "Customers.json", "Bills.json", "Products.json", "Categories.json" };
        public ServiceManager()
        {
            CreateDirectoryAndFiles();
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
            if (File.Exists(filePath))
            {
                File.WriteAllText(filePath, "[]");
            }

            filePath = Path.Combine(appDataFolder, JsonFiles[1]);
            if (File.Exists(filePath))
            {
                File.WriteAllText(filePath, "[]");
            }

            filePath = Path.Combine(appDataFolder, JsonFiles[2]);
            if (File.Exists(filePath))
            {
                File.WriteAllText(filePath, "[]");
            }

            filePath = Path.Combine(appDataFolder, JsonFiles[3]);
            if (File.Exists(filePath))
            {
                File.WriteAllText(filePath, "[]");
            }

            filePath = Path.Combine(appDataFolder, JsonFiles[4]);
            if (File.Exists(filePath))
            {
                File.WriteAllText(filePath, "[]");
            }

            filePath = Path.Combine(appDataFolder, JsonFiles[5]);
            if (File.Exists(filePath))
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

        public async void WritePurchases(PurchaseModel purchaseModel)
        {
            string jsonData = JsonConvert.SerializeObject(purchaseModel);
            string filePath = GetFile(0);
            await File.WriteAllTextAsync(filePath, jsonData);
        }

        public async void WriteEmployees(EmployeeModel employeeModel)
        {
            string jsonData = JsonConvert.SerializeObject(employeeModel);
            string filePath = GetFile(1);
            await File.WriteAllTextAsync(filePath, jsonData);
        }

        public async void WriteCustomers(CustomerModel customerModel)
        {
            string jsonData = JsonConvert.SerializeObject(customerModel);
            string filePath = GetFile(2);
            await File.WriteAllTextAsync(filePath, jsonData);
        }

        public async void WriteBills(BillModel billModel)
        {
            string jsonData = JsonConvert.SerializeObject(billModel);
            string filePath = GetFile(3);
            await File.WriteAllTextAsync(filePath, jsonData);
        }

        public async void WriteProducts(ProductModel productModel)
        {
            string jsonData = JsonConvert.SerializeObject(productModel);
            string filePath = GetFile(4);
            await File.WriteAllTextAsync(filePath, jsonData);
        }

        public async void WriteCategories(CategoryModel categoryModel)
        {
            string jsonData = JsonConvert.SerializeObject(categoryModel);
            string filePath = GetFile(5);
            await File.WriteAllTextAsync(filePath, jsonData);
        }

        #endregion

        #region Read Data

        public async Task<PurchaseModel> GetPurchases()
        {
            PurchaseModel purchases = new PurchaseModel();

            string filePath = GetFile(0);

            string jsonData = await File.ReadAllTextAsync(filePath);

            if (!(jsonData == null || jsonData == string.Empty))
            {
                purchases = JsonConvert.DeserializeObject<PurchaseModel>(jsonData);
            }

            return purchases;
        }

        public async Task<EmployeeModel> GetEmployees()
        {
            EmployeeModel employees = new EmployeeModel();

            string filePath = GetFile(1);

            string jsonData = await File.ReadAllTextAsync(filePath);

            if (!(jsonData == null || jsonData == string.Empty))
            {
                employees = JsonConvert.DeserializeObject<EmployeeModel>(jsonData);
            }

            return employees;
        }

        public async Task<CustomerModel> GetCustomers()
        {
            CustomerModel customers = new CustomerModel();

            string filePath = GetFile(2);

            string jsonData = await File.ReadAllTextAsync(filePath);

            if (!(jsonData == null || jsonData == string.Empty))
            {
                customers = JsonConvert.DeserializeObject<CustomerModel>(jsonData);
            }

            return customers;
        }

        public async Task<BillModel> GetBills()
        {
            BillModel bills = new BillModel();

            string filePath = GetFile(3);

            string jsonData = await File.ReadAllTextAsync(filePath);

            if (!(jsonData == null || jsonData == string.Empty))
            {
                bills = JsonConvert.DeserializeObject<BillModel>(jsonData);
            }

            return bills;
        }

        public async Task<ProductModel> GetProducts()
        {
            ProductModel products = new ProductModel();

            string filePath = GetFile(4);

            string jsonData = await File.ReadAllTextAsync(filePath);

            if (!(jsonData == null || jsonData == string.Empty))
            {
                products = JsonConvert.DeserializeObject<ProductModel>(jsonData);
            }

            return products;
        }

        public async Task<CategoryModel> GetCategories()
        {
            CategoryModel categories = new CategoryModel();

            string filePath = GetFile(5);

            string jsonData = await File.ReadAllTextAsync(filePath);

            if (!(jsonData == null || jsonData == string.Empty))
            {
                categories = JsonConvert.DeserializeObject<CategoryModel>(jsonData);
            }

            return categories;
        }

        #endregion
    }
}
