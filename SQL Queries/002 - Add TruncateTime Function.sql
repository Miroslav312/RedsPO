SET GLOBAL log_bin_trust_function_creators = 1;
USE redspodb;
CREATE FUNCTION TruncateTime(dateValue DATETIME)
RETURNS DATE
RETURN DATE(dateValue);
