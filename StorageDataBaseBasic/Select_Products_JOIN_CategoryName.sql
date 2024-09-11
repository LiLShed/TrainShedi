SELECT InventoryID, Products.ProductName, Inventory.ProductID, QuantityIn, QuantityOut, TransactionDate From Inventory 
JOIN Products ON Products.ProductID = Inventory.ProductID
