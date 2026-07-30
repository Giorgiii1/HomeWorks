--students

-- 1. 1990 წლის შემდეგ დაბადებულები
SELECT * FROM Students WHERE YEAR(DoB) > 1990;

-- 2. არიან საქართველოდან და ლიბიადან
SELECT FirstName, LastName, DATEDIFF(YEAR, DoB, GETDATE()) AS Age
FROM Students 
WHERE Country IN (N'Georgia', N'Libya', N'საქართველო', N'ლიბია');

-- 3. ახალი სტუდენტი
INSERT INTO Students (FirstName, LastName, DoB, Country, MiddleTest, FinalTest)
VALUES (N'Giorgi', N'Gongladze', '2001-05-15', N'Georgia', 40, 50);

-- 4. TOP 5 შუალედურის მიხედვით
SELECT TOP 5 WITH TIES FirstName, MiddleTest
FROM Students
ORDER BY MiddleTest DESC;

-- 5. წაშლა სადაც FinalTest = 19
DELETE FROM Students
OUTPUT DELETED.*
WHERE FinalTest = 19;

-- 6. განახლება MiddleTest = 1 -> FinalTest = 0
UPDATE Students
SET FinalTest = 0
WHERE MiddleTest = 1;


--Persons

-- 1. PrivateId იწყება 163-ით
SELECT * FROM Persons WHERE PrivateId LIKE '163%';

-- 2. გვარი ემთხვევა ქალაქს
SELECT * FROM Persons WHERE LastName = Country;

-- 3. ცხოვრობენ კანადაში ან მონაკოში
SELECT * FROM Persons WHERE Country IN (N'Canada', N'Monaco');

-- 4. იმეილის გარეშე
SELECT FirstName, LastName, PrivateId FROM Persons WHERE Email IS NULL OR Email = '';

-- 5. ცხოვრობენ ესპანეთი/თურქეთი და ხელფასი 1000-3000
SELECT * FROM Persons 
WHERE Country IN (N'Spain', N'Turkey') AND Salary BETWEEN 1000 AND 3000;

-- 6. შეიცავს LLC, PC, LLP კომპანიები
SELECT WorkPlace FROM Persons 
WHERE WorkPlace LIKE '%LLC%' OR WorkPlace LIKE '%PC%' OR WorkPlace LIKE '%LLP%';

-- 7. წერტილების რაოდენობა მეილში
SELECT Email,
       CASE 
           WHEN (LEN(Email) - LEN(REPLACE(Email, '.', ''))) > 2 THEN 'more than 2 dots'
           ELSE 'less than 2 dots'
       END AS MAILINFO
FROM Persons;

-- 8. პინ კოდი მთავრდება 51-ით
SELECT * FROM Persons WHERE PinCode LIKE '%51';

-- 9. საშუალო ხელფასი ქვეყნების მიხედვით
SELECT Country, AVG(Salary) AS AverageSalary 
FROM Persons 
GROUP BY Country;