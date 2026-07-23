-- 1. ლონდონელი და მადრიდელი კლიენტების შეკვეთები
SELECT 
    c.contactname, 
    c.city, 
    o.orderdate
FROM Sales.Customers AS c
INNER JOIN Sales.Orders AS o ON c.custid = o.custid
WHERE c.city IN ('London', 'Madrid');

-- 2. პროდუქტები (ფასი 20-40) UPPER რეგისტრში
SELECT 
    UPPER(p.productname) AS ProductName, 
    p.unitprice, 
    c.categoryname
FROM Production.Products AS p
INNER JOIN Production.Categories AS c ON p.categoryid = c.categoryid
WHERE p.unitprice BETWEEN 20 AND 40;

-- 3. Sales Manager-ების შეკვეთები (წონა > 50)
SELECT 
    e.firstname, 
    e.lastname, 
    o.orderid, 
    e.title
FROM HR.Employees AS e
INNER JOIN Sales.Orders AS o ON e.empid = o.empid
WHERE e.title = 'Sales Manager' AND o.freight > 50;

-- 4. ამერიკული კომპანიების 2007 წლის შეკვეთები
SELECT 
    o.orderdate, 
    c.contactname, 
    c.city, 
    c.address
FROM Sales.Orders AS o
INNER JOIN Sales.Customers AS c ON o.custid = c.custid
WHERE YEAR(o.orderdate) = 2007 AND c.country IN ('USA', 'US');

-- 5. ქალაქები, სადაც Cameron-ის შეკვეთები გაიგზავნა 
SELECT DISTINCT o.shipcity
FROM Sales.Orders AS o
INNER JOIN HR.Employees AS e ON o.empid = e.empid
WHERE e.lastname = 'Cameron';

-- 6. გერმანიასა და ავსტრიაში გაგზავნილი შეკვეთები
SELECT 
    o.orderid, 
    o.shipcountry, 
    o.shipcity
FROM Sales.Orders AS o
INNER JOIN Sales.Shippers AS s ON o.shipperid = s.shipperid
WHERE o.shipcountry IN ('Germany', 'Austria');


-- 7. ტოკიოდან მოწოდებული ფასდაკლებიანი პროდუქტები
SELECT DISTINCT 
    p.productid,
    p.productname,
    p.unitprice,
    s.companyname AS SupplierName, 
    s.city AS SupplierCity
FROM Production.Products AS p
INNER JOIN Production.Suppliers AS s ON p.supplierid = s.supplierid
INNER JOIN Sales.OrderDetails AS od ON p.productid = od.productid
WHERE s.city = 'Tokyo' AND od.discount > 0;

-- 8. იაპონური Seafood და Beverages
SELECT 
    p.productname, 
    c.categoryname
FROM Production.Products AS p
INNER JOIN Production.Suppliers AS s ON p.supplierid = s.supplierid
INNER JOIN Production.Categories AS c ON p.categoryid = c.categoryid
WHERE s.country = 'Japan' 
  AND c.categoryname IN ('Seafood', 'Beverages');

  -- 9. Sara Davis და Maria Cameron-ის 2007 წლის შეკვეთები
SELECT DISTINCT 
    e.firstname, 
    e.lastname, 
    s.companyname AS ShipperName
FROM Sales.Orders AS o
INNER JOIN HR.Employees AS e ON o.empid = e.empid
INNER JOIN Sales.Shippers AS s ON o.shipperid = s.shipperid
WHERE YEAR(o.orderdate) = 2007 
  AND ((e.firstname = 'Sara' AND e.lastname = 'Davis') 
    OR (e.firstname = 'Maria' AND e.lastname = 'Cameron'));

    -- 10. ამერიკული პროდუქტები (გარდა Seafood და Beverages)
SELECT 
    p.productname, 
    c.categoryname
FROM Production.Products AS p
INNER JOIN Production.Suppliers AS s ON p.supplierid = s.supplierid
INNER JOIN Production.Categories AS c ON p.categoryid = c.categoryid
WHERE s.country = 'USA' 
  AND c.categoryname NOT IN ('Seafood', 'Beverages');

  -- 11. შეკვეთები, სადაც კლიენტი და თანამშრომელი ერთ ქალაქშია
SELECT 
    o.orderid, 
    e.firstname AS EmpFirstName, 
    e.lastname AS EmpLastName, 
    e.city AS EmpCity, 
    c.contactname AS CustomerName
FROM Sales.Orders AS o
INNER JOIN HR.Employees AS e ON o.empid = e.empid
INNER JOIN Sales.Customers AS c ON o.custid = c.custid
WHERE e.city = c.city;

-- 12. კლიენტები, რომლებმაც შეუკვეთეს Beverages ან Dairy Products
SELECT DISTINCT 
    c.contactname
FROM Sales.Customers AS c
INNER JOIN Sales.Orders AS o ON c.custid = o.custid
INNER JOIN Sales.OrderDetails AS od ON o.orderid = od.orderid
INNER JOIN Production.Products AS p ON od.productid = p.productid
INNER JOIN Production.Categories AS cat ON p.categoryid = cat.categoryid
WHERE cat.categoryname IN ('Beverages', 'Dairy Products');