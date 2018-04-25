
if exists (select * from sysdatabases where name='Dealership')
		drop database Dealership
go

Create database Dealership