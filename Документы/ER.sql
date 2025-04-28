CREATE DATABASE TOOLACCOUNTING;
GO

USE TOOLACCOUNTING;
GO

-- 1. Группы инструментов
CREATE TABLE ToolGroups (
    GroupID INT IDENTITY(1,1) PRIMARY KEY,
    GroupName NVARCHAR(255) NOT NULL,
    StartRange VARCHAR(9) NOT NULL,
    EndRange VARCHAR(9) NOT NULL,
    --CONSTRAINT CHK_Range CHECK (StartRange < EndRange)
);
GO

-- 2. Номенклатура инструмента
CREATE TABLE Nomenclature (
    NomenclatureNumber VARCHAR(9) PRIMARY KEY,
    GroupID INT NOT NULL,
    Name NVARCHAR(255) NOT NULL,
    Designation NVARCHAR(100),
    UnitOfMeasure NVARCHAR(50),
    TypeSize NVARCHAR(255),
    CuttingMaterial NVARCHAR(100),
    NormativeDoc NVARCHAR(255),
    Manufacturer NVARCHAR(255),
    UsageFlag TINYINT NOT NULL CHECK (UsageFlag IN (0, 1, 2)),
    MinStockLevel INT,
    FullName AS (Name + ' ' + Designation + ' ' + TypeSize + ' ' + CuttingMaterial + ' ' + NormativeDoc),
    FOREIGN KEY (GroupID) REFERENCES ToolGroups(GroupID)
);
GO

-- 3. Аналоги инструментов
CREATE TABLE ToolAnalogues (
    OriginalNumber VARCHAR(9) NOT NULL,
    AnalogueNumber VARCHAR(9) NOT NULL,
    PRIMARY KEY (OriginalNumber, AnalogueNumber),
    FOREIGN KEY (OriginalNumber) REFERENCES Nomenclature(NomenclatureNumber),
    FOREIGN KEY (AnalogueNumber) REFERENCES Nomenclature(NomenclatureNumber)
);
GO

-- 4. Логи корректировок
CREATE TABLE NomenclatureLogs (
    LogID INT IDENTITY(1,1) PRIMARY KEY,
    NomenclatureNumber VARCHAR(9) NOT NULL,
    ChangedDate DATETIME DEFAULT GETDATE(),
    ChangedBy NVARCHAR(255) NOT NULL,
    FieldName NVARCHAR(255) NOT NULL,
    OldValue NVARCHAR(MAX),
    NewValue NVARCHAR(MAX),
    FOREIGN KEY (NomenclatureNumber) REFERENCES Nomenclature(NomenclatureNumber)
);
GO

-- 5. Поставщики
CREATE TABLE Suppliers (
    INN VARCHAR(12) PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL,
    LegalAddress NVARCHAR(500),
    ContactInfo NVARCHAR(500),
    Notes NVARCHAR(MAX)
);
GO

-- 6. Ведомости поставки
CREATE TABLE DeliveryStatements (
    StatementID INT IDENTITY(1,1) PRIMARY KEY,
    SupplierINN VARCHAR(12) NOT NULL,
    StatementDate DATE NOT NULL,
    ContractNumber NVARCHAR(100),
    FOREIGN KEY (SupplierINN) REFERENCES Suppliers(INN)
);
GO

-- 7. Состав ведомости поставки
CREATE TABLE DeliveryStatementDetails (
    DetailID INT IDENTITY(1,1) PRIMARY KEY,
    StatementID INT NOT NULL,
    NomenclatureNumber VARCHAR(9) NOT NULL,
    Quantity INT NOT NULL CHECK (Quantity > 0),
    Price DECIMAL(18,2) NOT NULL CHECK (Price > 0),
    Deadline DATE,
    FOREIGN KEY (StatementID) REFERENCES DeliveryStatements(StatementID),
    FOREIGN KEY (NomenclatureNumber) REFERENCES Nomenclature(NomenclatureNumber)
);
GO

-- 8. Товарная накладная
CREATE TABLE Invoices (
    InvoiceID INT IDENTITY(1,1) PRIMARY KEY,
    InvoiceNumber NVARCHAR(50) NOT NULL UNIQUE,
    InvoiceDate DATE NOT NULL,
    SupplierINN VARCHAR(12) NOT NULL,
    TotalAmount DECIMAL(18,2),
    FOREIGN KEY (SupplierINN) REFERENCES Suppliers(INN)
);
GO

-- 9. Состав товарной накладной
CREATE TABLE InvoiceDetails (
    InvoiceDetailID INT IDENTITY(1,1) PRIMARY KEY,
    InvoiceID INT NOT NULL,
    NomenclatureNumber VARCHAR(9) NOT NULL,
    Quantity INT NOT NULL CHECK (Quantity > 0),
    Price DECIMAL(18,2) NOT NULL CHECK (Price > 0),
    FOREIGN KEY (InvoiceID) REFERENCES Invoices(InvoiceID),
    FOREIGN KEY (NomenclatureNumber) REFERENCES Nomenclature(NomenclatureNumber)
);
GO

-- 10. Накладные-Ведомости (связь M:N)
CREATE TABLE InvoiceStatementLinks (
    LinkID INT IDENTITY(1,1) PRIMARY KEY,
    InvoiceID INT NOT NULL,
    StatementID INT NOT NULL,
    FOREIGN KEY (InvoiceID) REFERENCES Invoices(InvoiceID),
    FOREIGN KEY (StatementID) REFERENCES DeliveryStatements(StatementID)
);
GO

-- 11. Цеха
CREATE TABLE Workshops (
    WorkshopID INT IDENTITY(1,1) PRIMARY KEY,
    WorkshopNumber NVARCHAR(50) NOT NULL UNIQUE,
    Name NVARCHAR(255) NOT NULL
);
GO

-- 12. Заявки на получение
CREATE TABLE AcquisitionRequests (
    RequestID INT IDENTITY(1,1) PRIMARY KEY,
    RequestNumber NVARCHAR(50) NOT NULL UNIQUE,
    RequestDate DATE NOT NULL,
    WorkshopID INT NOT NULL,
    Status NVARCHAR(50) DEFAULT 'Новая',
    FOREIGN KEY (WorkshopID) REFERENCES Workshops(WorkshopID)
);
GO

-- 13. Состав заявок на получение
CREATE TABLE AcquisitionRequestDetails (
    RequestDetailID INT IDENTITY(1,1) PRIMARY KEY,
    RequestID INT NOT NULL,
    NomenclatureNumber VARCHAR(9),
    FullName NVARCHAR(MAX),
    Quantity INT NOT NULL CHECK (Quantity > 0),
    PlannedDate DATE,
    Reason NVARCHAR(500),
    FOREIGN KEY (RequestID) REFERENCES AcquisitionRequests(RequestID),
    FOREIGN KEY (NomenclatureNumber) REFERENCES Nomenclature(NomenclatureNumber)
);
GO

-- 14. Склады
CREATE TABLE Warehouses (
    WarehouseID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL,
    Location NVARCHAR(500)
);
GO

-- 15. Заявки на приобретение
CREATE TABLE PurchaseRequests (
    PurchaseRequestID INT IDENTITY(1,1) PRIMARY KEY,
    RequestNumber NVARCHAR(50) NOT NULL UNIQUE,
    CreationDate DATE DEFAULT GETDATE(),
    Status NVARCHAR(50) DEFAULT 'В обработке'
);
GO

-- 16. Состав заявок на приобретение
CREATE TABLE PurchaseRequestDetails (
    PurchaseDetailID INT IDENTITY(1,1) PRIMARY KEY,
    PurchaseRequestID INT NOT NULL,
    NomenclatureNumber VARCHAR(9) NOT NULL,
    Quantity INT NOT NULL CHECK (Quantity > 0),
    FOREIGN KEY (PurchaseRequestID) REFERENCES PurchaseRequests(PurchaseRequestID),
    FOREIGN KEY (NomenclatureNumber) REFERENCES Nomenclature(NomenclatureNumber)
);
GO

-- 17. Остатки
CREATE TABLE StockBalances (
    BalanceID INT IDENTITY(1,1) PRIMARY KEY,
    WarehouseID INT NOT NULL,
    NomenclatureNumber VARCHAR(9) NOT NULL,
    BalanceDate DATE NOT NULL,
    Quantity INT NOT NULL CHECK (Quantity >= 0),
    FOREIGN KEY (WarehouseID) REFERENCES Warehouses(WarehouseID),
    FOREIGN KEY (NomenclatureNumber) REFERENCES Nomenclature(NomenclatureNumber)
);
GO

-- 18. Дефектная ведомость
CREATE TABLE DefectActs (
    ActID INT IDENTITY(1,1) PRIMARY KEY,
    ActNumber NVARCHAR(50) NOT NULL UNIQUE,
    ActDate DATE NOT NULL,
    WorkshopID INT NOT NULL,
    NomenclatureNumber VARCHAR(9) NOT NULL,
    Quantity INT NOT NULL CHECK (Quantity > 0),
    Decision NVARCHAR(50) CHECK (Decision IN ('Списание', 'Ремонт')),
    FOREIGN KEY (WorkshopID) REFERENCES Workshops(WorkshopID),
    FOREIGN KEY (NomenclatureNumber) REFERENCES Nomenclature(NomenclatureNumber)
);
GO

-- 19. Виды движений
CREATE TABLE MovementTypes (
    MovementTypeID INT IDENTITY(1,1) PRIMARY KEY,
    TypeName NVARCHAR(50) NOT NULL UNIQUE,
    Description NVARCHAR(500)
);
GO

-- 20. Движение инструмента
CREATE TABLE ToolMovements (
    MovementID INT IDENTITY(1,1) PRIMARY KEY,
    DocumentNumber NVARCHAR(50) NOT NULL,
    MovementDate DATE NOT NULL,
    MovementTypeID INT NOT NULL,
    FromWarehouseID INT,
    ToWarehouseID INT NOT NULL,
    NomenclatureNumber VARCHAR(9) NOT NULL,
    Quantity INT NOT NULL CHECK (Quantity > 0),
    FOREIGN KEY (MovementTypeID) REFERENCES MovementTypes(MovementTypeID),
    FOREIGN KEY (FromWarehouseID) REFERENCES Warehouses(WarehouseID),
    FOREIGN KEY (ToWarehouseID) REFERENCES Warehouses(WarehouseID),
    FOREIGN KEY (NomenclatureNumber) REFERENCES Nomenclature(NomenclatureNumber)
);
GO

