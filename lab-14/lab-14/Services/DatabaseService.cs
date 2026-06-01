using lab_14.Entities;
using SQLite;
using System;
using System.Collections.Generic;

namespace lab_14.Services
{
    public class DatabaseService
    {
        private readonly SQLiteConnection _database;

        public DatabaseService(string databasePath)
        {
            _database = new SQLiteConnection(databasePath);

            _database.Execute("PRAGMA foreign_keys = ON;");

            _database.CreateTable<Item>();
            _database.CreateTable<Supplier>();
            _database.CreateTable<Supply>();
        }

        public IEnumerable<Item> GetItems() => _database.Table<Item>().ToList();
        public int DeleteItem(int id) => _database.Delete<Item>(id);
        public int SaveItem(Item item) => item.Id != 0 ? (_database.Update(item) == 1 ? item.Id : 0) : _database.Insert(item);

        public IEnumerable<Supplier> GetSuppliers() => _database.Table<Supplier>().ToList();
        public int DeleteSupplier(int id) => _database.Delete<Supplier>(id);
        public int SaveSupplier(Supplier supplier) => supplier.Id != 0 ? (_database.Update(supplier) == 1 ? supplier.Id : 0) : _database.Insert(supplier);
       
        public IEnumerable<Supply> GetSupplies() => _database.Table<Supply>().ToList();
        public int DeleteSupply(int id) => _database.Delete<Supply>(id);
        public int SaveSupply(Supply supply)
        {
            var supplierExists = _database.Find<Supplier>(supply.SupplierId) != null;
            var itemExists = _database.Find<Item>(supply.ItemId) != null;

            if (!supplierExists || !itemExists)
            {
                throw new Exception("Ошибка внешнего ключа: Указанный поставщик или товар не существует!");
            }

            return supply.Id != 0 ? (_database.Update(supply) == 1 ? supply.Id : 0) : _database.Insert(supply);
        }
    }
}