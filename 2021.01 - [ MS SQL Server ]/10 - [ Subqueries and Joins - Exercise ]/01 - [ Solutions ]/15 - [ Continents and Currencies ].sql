SELECT
	ContinentCode,
	CurrencyCode,
	(SELECT COUNT(CurrencyCode)) AS Total
  FROM Countries
  GROUP BY ContinentCode, CurrencyCode




