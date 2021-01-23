SELECT
  CEILING(
    CEILING(
      CAST(Quantity AS float) / BoxCapacity) / PalletCapacity)
    AS [Number of pallets]
  FROM Products