SELECT FirstName, LastName, 
		LEFT(PaymentNumber, 6) +
			REPLICATE('*', LEN(PaymentNumber)) AS PaymentNumber
FROM Customers