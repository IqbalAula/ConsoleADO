CREATE TRIGGER [Trigger]
	ON [dbo].[TransactionItems]
	FOR INSERT
	AS
	BEGIN
		UPDATE i set i.Stock = i.Stock - t.Quantity
		FROM Items i JOIN inserted t on i.Id = t.Item_Id;
	END
