-- Delete all rows from the table
DELETE FROM lab_eqpment;

-- Reset the identity seed to 1
DBCC CHECKIDENT ('lab_eqpment', RESEED, 0);
