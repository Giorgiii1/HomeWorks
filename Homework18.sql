-- 1. ევროპაში გამართულ მოვლენების რაოდენობა
SELECT COUNT(*) AS EventsInEuropeCount
FROM Event
WHERE CountryID IN (
    SELECT CountryID 
    FROM Country 
    WHERE ContinentID = (
        SELECT ContinentID 
        FROM Continent 
        WHERE ContinentName = 'Europe'
    )
);

-- 2. აფრიკაში ყველაზე ადრე გამართული მოვლენის თარიღი
SELECT MIN(EventDate) AS EarliestAfricanEventDate
FROM Event
WHERE CountryID IN (
    SELECT CountryID 
    FROM Country 
    WHERE ContinentID = (
        SELECT ContinentID 
        FROM Continent 
        WHERE ContinentName = 'Africa'
    )
);

-- 3. ჩრდილოეთ და სამხრეთ ამერიკაში არსებული ქვეყნების რაოდენობა
SELECT COUNT(*) AS AmericasCountriesCount
FROM Country
WHERE ContinentID IN (
    SELECT ContinentID 
    FROM Continent 
    WHERE ContinentName IN ('North America', 'South America')
);

-- 4. ახალ წელს გამართული ეკონომიკასთან დაკავშირებული მოვლენების რაოდენობა
SELECT COUNT(*) AS NewYearEconomyEventsCount
FROM Event
WHERE MONTH(EventDate) = 1 AND DAY(EventDate) = 1
  AND CategoryID = (
      SELECT CategoryID 
      FROM Category 
      WHERE CategoryName = 'Economy'
  );

  -- 5. ევროპაში ყველაზე გვიან გამართული, სპორტის კატეგორიასთან დაკავშირებული მოვლენის თარიღი
SELECT MAX(EventDate) AS LatestEuropeSportsEventDate
FROM Event
WHERE CategoryID = (
    SELECT CategoryID 
    FROM Category 
    WHERE CategoryName = 'Sports'
)
AND CountryID IN (
    SELECT CountryID 
    FROM Country 
    WHERE ContinentID = (
        SELECT ContinentID 
        FROM Continent 
        WHERE ContinentName = 'Europe'
    )
);