SET GLOBAL log_bin_trust_function_creators = 1;

CREATE FUNCTION TruncateTime(dateValue DATETIME)
RETURNS DATE
RETURN DATE(dateValue);
