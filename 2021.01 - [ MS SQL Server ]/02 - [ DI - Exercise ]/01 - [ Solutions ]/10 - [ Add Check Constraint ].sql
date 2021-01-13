ALTER TABLE Users
ADD CONSTRAINT CH_PasswordIsAtLeast5Symbol
CHECK (LEN([Password]) >= 5);