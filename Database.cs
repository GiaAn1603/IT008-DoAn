using System;
using System.Data.SQLite;
using System.IO;

namespace OHIOCF
{
    public static class Database
    {
        private static readonly string ProjectRoot =
            Path.GetFullPath(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\.."));

        public static readonly string DbPath =
            Path.Combine(ProjectRoot, "Data", "ohiocf.db");

        public static readonly string ConnectionString =
            $"Data Source={DbPath};Version=3;";

        public static void Init()
        {
            var dir = Path.GetDirectoryName(DbPath);
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            using (var conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();

                new SQLiteCommand("PRAGMA foreign_keys = ON;", conn)
                    .ExecuteNonQuery();

                CreateTables(conn);
            }
        }

        private static void CreateTables(SQLiteConnection conn)
        {
            string sql = @"
                -- ROLE
                CREATE TABLE IF NOT EXISTS Role (
                    id TEXT PRIMARY KEY,
                    roleName TEXT
                );

                -- USER
                CREATE TABLE IF NOT EXISTS User (
                    id TEXT PRIMARY KEY,
                    roleId TEXT NOT NULL,
                    username TEXT UNIQUE NOT NULL,
                    password TEXT NOT NULL,
                    fullName TEXT,
                    isActive INTEGER DEFAULT 1,
                    FOREIGN KEY (roleId) REFERENCES Role(id)
                );

                -- AUDIT LOG
                CREATE TABLE IF NOT EXISTS AuditLog (
                    id TEXT PRIMARY KEY,
                    userId TEXT NOT NULL,
                    action TEXT,
                    logTime TEXT DEFAULT CURRENT_TIMESTAMP,
                    details TEXT,
                    FOREIGN KEY (userId) REFERENCES User(id)
                );

                -- PROMOTION
                CREATE TABLE IF NOT EXISTS Promotion (
                    id TEXT PRIMARY KEY,
                    code TEXT UNIQUE,
                    discountValue REAL,
                    discountType INTEGER,
                    startDate TEXT,
                    endDate TEXT
                );

                -- CUSTOMER
                CREATE TABLE IF NOT EXISTS Customer (
                    id TEXT PRIMARY KEY,
                    fullName TEXT,
                    phone TEXT UNIQUE,
                    points INTEGER DEFAULT 0,
                    rank TEXT
                );

                -- CAFE TABLE
                CREATE TABLE IF NOT EXISTS CafeTable (
                    id TEXT PRIMARY KEY,
                    tableName TEXT,
                    status INTEGER,
                    area TEXT
                );

                -- INGREDIENT
                CREATE TABLE IF NOT EXISTS Ingredient (
                    id TEXT PRIMARY KEY,
                    name TEXT,
                    unit TEXT
                );

                -- CATEGORY
                CREATE TABLE IF NOT EXISTS Category (
                    id TEXT PRIMARY KEY,
                    name TEXT
                );

                -- PRODUCT
                CREATE TABLE IF NOT EXISTS Product (
                    id TEXT PRIMARY KEY,
                    categoryId TEXT NOT NULL,
                    name TEXT,
                    basePrice REAL,
                    image TEXT,
                    isAvailable INTEGER DEFAULT 1,
                    FOREIGN KEY (categoryId) REFERENCES Category(id)
                );

                -- PRODUCT SIZE
                CREATE TABLE IF NOT EXISTS ProductSize (
                    id TEXT PRIMARY KEY,
                    productId TEXT NOT NULL,
                    sizeName TEXT,
                    priceAdjustment REAL,
                    FOREIGN KEY (productId) REFERENCES Product(id)
                );

                -- ORDER
                CREATE TABLE IF NOT EXISTS [Order] (
                    id TEXT PRIMARY KEY,
                    tableId TEXT,
                    userId TEXT NOT NULL,
                    customerId TEXT,
                    promotionId TEXT,
                    orderDate TEXT DEFAULT CURRENT_TIMESTAMP,
                    totalAmount REAL,
                    status INTEGER DEFAULT 0,
                    FOREIGN KEY (tableId) REFERENCES CafeTable(id),
                    FOREIGN KEY (userId) REFERENCES User(id),
                    FOREIGN KEY (customerId) REFERENCES Customer(id),
                    FOREIGN KEY (promotionId) REFERENCES Promotion(id)
                );

                -- ORDER DETAIL
                CREATE TABLE IF NOT EXISTS OrderDetail (
                    id TEXT PRIMARY KEY,
                    orderId TEXT NOT NULL,
                    productId TEXT NOT NULL,
                    productSizeId TEXT NOT NULL,
                    quantity INTEGER,
                    priceAtTime REAL,
                    note TEXT,
                    FOREIGN KEY (orderId) REFERENCES [Order](id),
                    FOREIGN KEY (productId) REFERENCES Product(id),
                    FOREIGN KEY (productSizeId) REFERENCES ProductSize(id)
                );

                -- PAYMENT
                CREATE TABLE IF NOT EXISTS Payment (
                    id TEXT PRIMARY KEY,
                    orderId TEXT UNIQUE NOT NULL,
                    paymentMethod TEXT,
                    paymentDate TEXT DEFAULT CURRENT_TIMESTAMP,
                    amountPaid REAL,
                    FOREIGN KEY (orderId) REFERENCES [Order](id)
                );

                -- INVENTORY
                CREATE TABLE IF NOT EXISTS Inventory (
                    id TEXT PRIMARY KEY,
                    ingredientId TEXT NOT NULL,
                    stockQuantity REAL,
                    lastUpdated TEXT,
                    minThreshold REAL,
                    FOREIGN KEY (ingredientId) REFERENCES Ingredient(id)
                );

                -- PRODUCT INGREDIENT
                CREATE TABLE IF NOT EXISTS ProductIngredient (
                    id TEXT PRIMARY KEY,
                    productSizeId TEXT NOT NULL,
                    ingredientId TEXT NOT NULL,
                    requiredQuantity REAL,
                    FOREIGN KEY (productSizeId) REFERENCES ProductSize(id),
                    FOREIGN KEY (ingredientId) REFERENCES Ingredient(id)
                );

                -- SCHEDULE
                CREATE TABLE IF NOT EXISTS Schedule (
                    id TEXT PRIMARY KEY,
                    userId TEXT NOT NULL,
                    startTime TEXT,
                    endTime TEXT,
                    note TEXT,
                    FOREIGN KEY (userId) REFERENCES User(id)
                );

                -- RESERVATION
                CREATE TABLE IF NOT EXISTS Reservation (
                    id TEXT PRIMARY KEY,
                    tableId TEXT NOT NULL,
                    customerName TEXT,
                    customerPhone TEXT,
                    reservationTime TEXT,
                    numberOfPeople INTEGER,
                    status INTEGER,
                    FOREIGN KEY (tableId) REFERENCES CafeTable(id)
                );
                ";
            new SQLiteCommand(sql, conn).ExecuteNonQuery();
        }
    }
}
