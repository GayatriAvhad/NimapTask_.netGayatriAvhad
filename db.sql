
create database GayatriTaskDb;

use GayatriTaskDb;


/* i am adding trigger here name is  trg_DeleteProductsOnCategoryDelete
 * when a category is deleted, all products associated with that 
 * category should also be deleted automatically*/
CREATE TRIGGER trg_DeleteProductsOnCategoryDelete
ON Categories
AFTER DELETE
AS
BEGIN
    DELETE FROM Products
    WHERE CategoryId IN (SELECT Category_id FROM DELETED);
END;
