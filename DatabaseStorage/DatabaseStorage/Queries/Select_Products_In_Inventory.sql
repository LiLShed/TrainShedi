SELECT InventoryID,ProductName, QuantityIn, QuantityOut, TransactionDate 
FROM Inventory
JOIN Products ON Inventory.InventoryID = Products.ProductID
ORDER BY QuantityIn