NimapInfotechTask_GayatriAvhad
create database on sql server :- 
database name = GayatriTaskDb 

also check your sql server name and modify in appsetting.json file
Model class

1. Product
2. Category
3. Pagination
Database connection : ApplicationDBContext class

after creating this open tool -> 
go to NuGet Pakage Manager -> open Package Manager Console and 
run following commands 
add-migration initial-tables 
update-database

also i am adding trigger here name is trg_DeleteProductsOnCategoryDelete 
when a category is deleted, all products associated with that category should also be deleted automatically.

CREATE TRIGGER trg_DeleteProductsOnCategoryDelete
ON Categories 
AFTER DELETE 
AS BEGIN DELETE FROM Products 
WHERE CategoryId IN (SELECT Category_id FROM DELETED); 
END;

also check db.sql file and run the project.
