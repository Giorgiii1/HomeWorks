-- 1. Hewlett-Packard-ის პროდუქტები
SELECT Name, Price
FROM Products
WHERE ManufacturerId IN (
    SELECT ManufacturerId 
    FROM Manufacturers 
    WHERE Name = 'Hewlett-Packard'
);

-- 2. პროდუქტები, რომლებიც არ უწარმოებია Fujitsu-ს
SELECT Name, Price
FROM Products
WHERE ManufacturerId NOT IN (
    SELECT ManufacturerId 
    FROM Manufacturers 
    WHERE Name = 'Fujitsu'
);

-- 3. Sony, Fujitsu, IBM ან Intel-ის პროდუქტები
SELECT Name, Price
FROM Products
WHERE ManufacturerId IN (
    SELECT ManufacturerId 
    FROM Manufacturers 
    WHERE Name IN ('Sony', 'Fujitsu', 'IBM', 'Intel')
);

-- 4. კომპანიები, რომლებმაც > 200 ღირებულების პროდუქტი აწარმოეს
SELECT Name
FROM Manufacturers
WHERE ManufacturerId IN (
    SELECT ManufacturerId 
    FROM Products 
    WHERE Price > 200
);

-- 5. პროდუქტები, რომლებსაც არ აწარმოებს Genius და Dell
SELECT Name, Price
FROM Products
WHERE ManufacturerId NOT IN (
    SELECT ManufacturerId 
    FROM Manufacturers 
    WHERE Name IN ('Genius', 'Dell')
);

-- 6. მწარმოებლების რაოდენობა, რომლებიც აწარმოებენ drive-ებს
SELECT COUNT(*) AS ManufacturersCount
FROM Manufacturers
WHERE ManufacturerId IN (
    SELECT ManufacturerId 
    FROM Products 
    WHERE Name LIKE '%drive%'
);

-- 7. Intel-ის პროდუქტების რაოდენობა, რომელთა ფასი აღემატება Intel-ის საშუალო ფასს
SELECT COUNT(*) AS ProductsCount
FROM Products
WHERE ManufacturerId = (
    SELECT ManufacturerId 
    FROM Manufacturers 
    WHERE Name = 'Intel'
) 
AND Price > (
    SELECT AVG(Price) 
    FROM Products 
    WHERE ManufacturerId = (
        SELECT ManufacturerId 
        FROM Manufacturers 
        WHERE Name = 'Intel'
    )
);

