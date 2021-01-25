SELECT TownID, Name
    FROM Towns
    WHERE Name LIKE ('[^RBD]%')
    ORDER BY Name