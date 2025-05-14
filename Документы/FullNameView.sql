CREATE VIEW NomenclatureWithFullName AS
SELECT 
    n.NomenclatureNumber,
	g.Name,
    n.Designation,
    n.Unit,
    n.Dimensions,
    n.CuttingMaterial,
    n.RegulatoryDoc,
    n.Producer,

    -- ��������� FullName � ��������� ������ �� ������� Groups
    FullName = 
        COALESCE(g.Name + ' ', '') + 
        COALESCE(n.Designation + ' ', '') + 
        COALESCE(n.Dimensions + ' ', '') + 
        COALESCE(n.CuttingMaterial + ' ', '') + 
        COALESCE(n.RegulatoryDoc, ''),
	
	n.UsageFlag,
    n.MinStock
FROM Nomenclature n
LEFT JOIN Groups g 
    ON g.RangeStart = LEFT(n.NomenclatureNumber, 4) -- ������������ ������ 4 �������