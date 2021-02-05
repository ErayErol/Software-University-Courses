SELECT [ProjectID],
       [StartDate],
       [EndDate],
       dbo.udf_ProjectDurationWeeks([StartDate],[EndDate])
    AS ProjectWeeks
  FROM [SoftUni].[dbo].[Projects]