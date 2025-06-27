-- init.sql
-- Этот файл автоматически выполняется при первом запуске PostgreSQL

-- Создание таблицы Products
CREATE TABLE IF NOT EXISTS Products (
    Id SERIAL PRIMARY KEY,
    Name VARCHAR(255) NOT NULL UNIQUE,
    Price DECIMAL(10, 2) NOT NULL CHECK (Price > 0),
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Заполнение таблицы Products тестовыми данными
INSERT INTO Products (Name, Price) VALUES 
    ('Laptop Gaming ASUS', 89999.99),
    ('iPhone 15 Pro', 99999.00),
    ('MacBook Air M3', 124999.00),
    ('Наушники Sony WH-1000XM4', 25999.50),
    ('Клавиатура Logitech MX', 8999.00),
    ('Мышь Razer DeathAdder', 4999.00),
    ('Монитор Samsung 27"', 35999.00),
    ('SSD Kingston 1TB', 7999.00),
    ('Оперативная память 16GB', 12999.00),
    ('Веб-камера Logitech C920', 8499.00)
ON CONFLICT (Name) DO NOTHING;


CREATE TABLE IF NOT EXISTS Shops (
    id SERIAL PRIMARY KEY,
    name VARCHAR(200) NOT NULL UNIQUE,
    area DECIMAL(8, 2) NOT NULL CHECK (Area > 0),
    address VARCHAR(500),
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

INSERT INTO Shops (Name, Address, Area) VALUES 
    ('Пивозавр', 'Ленина, 10', 100),
    ('Апельсин', 'Лазо, 62', 127),
    ('Телефон МВ', 'Амурская, 10', 256),
    ('Мертвые души', 'Достоевского, 2', 127),
    ('Спасение', 'Муравьева, 56', 556)
ON CONFLICT (Name) DO NOTHING;

CREATE TABLE IF NOT EXISTS ProductShop (
    Id SERIAL PRIMARY KEY,
    ProductId INTEGER REFERENCES Products(Id),
    ShopId INTEGER REFERENCES Shops(Id),
    Quantity INTEGER DEFAULT 0,
    UNIQUE (ProductId, ShopId)
);

INSERT INTO ProductShop (ProductId, ShopId, Quantity) VALUES 
    (1, 1, 100),
    (2, 1, 60),
    (2, 2, 150),
    (1, 3, 210),
    (2, 3, 300),
    (3, 3, 10)
ON CONFLICT (ProductId, ShopId) DO NOTHING;

-- Вывод информации о созданных данных
SELECT 'Products table created and populated' as Status;
SELECT COUNT(*) as ProductCount FROM Products;