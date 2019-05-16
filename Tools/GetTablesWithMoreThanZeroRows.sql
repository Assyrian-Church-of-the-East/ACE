
use ISGSPDI
GO

SELECT TableName = t.NAME, Schema_name(t.schema_id) as SchemaName,(Schema_name(t.schema_id)+ '.' + t.name) as TruncateTableQuery, p.rows as NumberOfRow
FROM sys.tables t
INNER JOIN sys.schemas s ON t.schema_id = s.schema_id
INNER JOIN sys.indexes i ON t.OBJECT_ID = i.object_id
INNER JOIN sys.partitions p ON i.object_id = p.OBJECT_ID AND i.index_id = p.index_id
WHERE t.is_ms_shipped = 0 and t.NAME like '%' and p.rows > 0
GROUP BY Schema_name(t.schema_id), t.NAME, s.Name, p.Rows
ORDER BY p.rows, s.Name, t.Name 