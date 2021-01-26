SELECT
	e.FirstName, e.LastName, t.[Name] AS Town, a.AddressText
  FROM Employees AS e
	LEFT JOIN Addresses AS a ON a.AddressID = e.AddressID
	LEFT JOIN Towns AS t ON t.TownID = a.TownID
  ORDER BY e.FirstName, e.LastName