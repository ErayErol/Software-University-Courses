SELECT COUNT(C.CurrencyCode) AS CurrencyUsage, C.CurrencyCode
FROM Countries C
WHERE c.ContinentCode = 'EU'
GROUP BY CurrencyCode
ORDER BY CurrencyUsage DESC