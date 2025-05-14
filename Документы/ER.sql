CREATE DATABASE TOOLACCOUNTING;
GO
USE TOOLACCOUNTING;
GO
-- 1. Группы инструментов
CREATE TABLE Groups (
    RangeStart CHAR(4) PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL
);


-- 2. Номенклатура инструмента
CREATE TABLE Nomenclature (
    NomenclatureNumber CHAR(9) PRIMARY KEY,
    --GroupRangeStart CHAR(4) NOT NULL FOREIGN KEY REFERENCES Groups(RangeStart),
    Designation NVARCHAR(100),
    Unit NVARCHAR(10) NOT NULL,
    Dimensions NVARCHAR(MAX),
    CuttingMaterial NVARCHAR(100),
    RegulatoryDoc NVARCHAR(100),
    Producer NVARCHAR(100),
    --FullName AS (Designation + ' ' + Dimensions + ' ' + CuttingMaterial + ' ' + RegulatoryDoc) PERSISTED,
    UsageFlag TINYINT NOT NULL CHECK (UsageFlag IN (0, 1, 2)),
    MinStock INT NOT NULL DEFAULT 0
);


-- 3. Аналоги инструментов
CREATE TABLE AnalogTools (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    OriginalNomenclatureNumber CHAR(9) NOT NULL FOREIGN KEY REFERENCES Nomenclature(NomenclatureNumber),
    AnalogNomenclatureNumber CHAR(9) NOT NULL FOREIGN KEY REFERENCES Nomenclature(NomenclatureNumber),
    CHECK (OriginalNomenclatureNumber <> AnalogNomenclatureNumber)
);


-- 4. Логи корректировок
CREATE TABLE NomenclatureLogs (
    LogID INT IDENTITY(1,1) PRIMARY KEY,
    NomenclatureNumber CHAR(9) NOT NULL FOREIGN KEY REFERENCES Nomenclature(NomenclatureNumber),
    FieldName NVARCHAR(255) NOT NULL,
    OldValue NVARCHAR(MAX),
    NewValue NVARCHAR(MAX),
    ChangedDate DATETIME,
    Executor NVARCHAR(255) NOT NULL
    
);

-- 5. Цеха
CREATE TABLE Workshops (
    WorkshopID INT PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL
);

-- 6. Склады
CREATE TABLE Storages (
    StorageID INT PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL,
    WorkshopID INT NOT NULL FOREIGN KEY REFERENCES Workshops(WorkshopID)
);

-- 7. Заявки на получение
CREATE TABLE ReceivingRequests (
    ReceivingRequestID INT IDENTITY(1,1) PRIMARY KEY,
    ReceivingRequestDate DATE NOT NULL,
    WorkshopID INT NOT NULL FOREIGN KEY REFERENCES Workshops(WorkshopID),
    PlannedDate DATE,
    ReceivingRequestType NVARCHAR(50) NOT NULL CHECK (ReceivingRequestType IN ('Плановая', 'Внеплановая')),
    Reason NVARCHAR(MAX),
    Status NVARCHAR(50) NOT NULL CHECK (Status IN ('Не обработана', 'В работе', 'Исполнена частично', 'Исполнена полностью'))
);

-- 8. Состав заявок на получение
CREATE TABLE ReceivingRequestsContent (
    ReceivingContentID INT IDENTITY(1,1) PRIMARY KEY,
    ReceivingRequestID INT NOT NULL FOREIGN KEY REFERENCES ReceivingRequests(ReceivingRequestID),
    NomenclatureNumber CHAR(9) FOREIGN KEY REFERENCES Nomenclature(NomenclatureNumber),
    FullName NVARCHAR(MAX) NOT NULL,
    Quantity INT NOT NULL CHECK (Quantity > 0)
);

-- 9. Фиксация замены аналогом
CREATE TABLE ReplacementFixation (
    ReplacementID INT IDENTITY(1,1) PRIMARY KEY,
    ReceivingRequestID INT NOT NULL FOREIGN KEY REFERENCES ReceivingRequests(ReceivingRequestID),
    AnalogNomenclatureNumber CHAR(9) NOT NULL FOREIGN KEY REFERENCES Nomenclature(NomenclatureNumber),
    Quantity INT NOT NULL CHECK (Quantity > 0)
);

-- 10. Заявки на приобретение
CREATE TABLE PurchaseRequests (
    PurchaseRequestID INT IDENTITY(1,1) PRIMARY KEY,
    PurchaseRequestDate DATE NOT NULL,
    Status NVARCHAR(50) NOT NULL CHECK (Status IN ('Не обработана', 'В работе', 'Исполнена частично', 'Исполнена полностью'))
);


-- 11. Состав заявок на приобретение
CREATE TABLE PurchaseRequestsContent (
    PurchaseContentID INT IDENTITY(1,1) PRIMARY KEY,
    PurchaseRequestID INT NOT NULL FOREIGN KEY REFERENCES PurchaseRequests(PurchaseRequestID),
    ReceivingContentID INT NOT NULL FOREIGN KEY REFERENCES ReceivingRequestsContent(ReceivingContentID),
    IsPurchase BIT NOT NULL,
    DonorWorkshopID INT FOREIGN KEY REFERENCES Workshops(WorkshopID)
);

-- 12. Поставщики
CREATE TABLE Suppliers (
    INN NVARCHAR(12) PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL,
    LegalAddress NVARCHAR(MAX) NOT NULL,
    Contacts NVARCHAR(MAX) NOT NULL,
    Notes NVARCHAR(MAX)
);

-- 13. Ведомости поставки
CREATE TABLE DeliveryLists (
    DeliveryListID INT IDENTITY(1,1) PRIMARY KEY,
    DeliveryListDate DATE NOT NULL,
    SupplierINN NVARCHAR(12) NOT NULL FOREIGN KEY REFERENCES Suppliers(INN)
);


-- 14. Состав ведомости поставки
CREATE TABLE DeliveryListsContent (
    DeliveryContentID INT IDENTITY(1,1) PRIMARY KEY,
    DeliveryListID INT NOT NULL FOREIGN KEY REFERENCES DeliveryLists(DeliveryListID),
    PurchaseContentID INT NOT NULL FOREIGN KEY REFERENCES PurchaseRequestsContent(PurchaseContentID),
    DeliveryContentDate DATE NOT NULL,
    ContractNumber NVARCHAR(100) NOT NULL,
    Quantity INT NOT NULL CHECK (Quantity > 0),
    Price DECIMAL(18,2) NOT NULL,
    Total AS (Quantity * Price) PERSISTED
);


-- 15. Товарная накладная
CREATE TABLE Invoices (
    InvoiceID INT IDENTITY(1,1) PRIMARY KEY,
    InvoiceDate DATE NOT NULL,
    DeliveryListID INT NOT NULL FOREIGN KEY REFERENCES DeliveryLists(DeliveryListID)
);


-- 16. Состав товарной накладной
CREATE TABLE InvoicesContent (
    InvoiceContentID INT IDENTITY(1,1) PRIMARY KEY,
    InvoiceID INT NOT NULL FOREIGN KEY REFERENCES Invoices(InvoiceID),
    DeliveryContentID INT NOT NULL FOREIGN KEY REFERENCES DeliveryListsContent(DeliveryContentID),
    Quantity INT NOT NULL CHECK (Quantity > 0)
);

-- 17. Дефектная ведомость
CREATE TABLE DefectiveLists (
    DefectiveListID INT IDENTITY(1,1) PRIMARY KEY,
    DefectiveListDate DATE NOT NULL,
    NomenclatureNumber CHAR(9) NOT NULL FOREIGN KEY REFERENCES Nomenclature(NomenclatureNumber),
    WorkshopID INT NOT NULL FOREIGN KEY REFERENCES Workshops(WorkshopID),
    BatchNumber NVARCHAR(50) NOT NULL,
    Price DECIMAL(18,2) NOT NULL,
    Quantity INT NOT NULL CHECK (Quantity > 0),
    IsWriteOff BIT NOT NULL
);


-- 18. Остатки
CREATE TABLE Balances (
    BalanceID INT IDENTITY(1,1) PRIMARY KEY,
    NomenclatureNumber CHAR(9) NOT NULL FOREIGN KEY REFERENCES Nomenclature(NomenclatureNumber),
    StorageID INT NOT NULL FOREIGN KEY REFERENCES Storages(StorageID),
    BalanceDate DATE NOT NULL,
    BatchNumber NVARCHAR(50) NOT NULL,
    Price DECIMAL(18,2) NOT NULL,
    Account NVARCHAR(50) NOT NULL
);


-- 19. Виды движений
CREATE TABLE MovementTypes (
    MovementTypeID INT IDENTITY(1,1) PRIMARY KEY,
    Code NVARCHAR(10) NOT NULL UNIQUE,
    Name NVARCHAR(50) NOT NULL
);


-- 20. Движение инструмента
CREATE TABLE ToolMovements (
    MovementID INT IDENTITY(1,1) PRIMARY KEY,
    MovementDate DATE NOT NULL,
    ToStorageID INT NOT NULL FOREIGN KEY REFERENCES Storages(StorageID),
    FromStorageID INT FOREIGN KEY REFERENCES Storages(StorageID),
    MovementTypeID INT NOT NULL FOREIGN KEY REFERENCES MovementTypes(MovementTypeID),
    NomenclatureNumber CHAR(9) NOT NULL FOREIGN KEY REFERENCES Nomenclature(NomenclatureNumber),
    SourceDocumentType NVARCHAR(50),
    SourceDocumentID INT,
    BatchNumber NVARCHAR(50) NOT NULL,
    Price DECIMAL(18,2) NOT NULL,
    Quantity INT NOT NULL CHECK (Quantity > 0),
    Total AS (Quantity * Price) PERSISTED,
    InvoiceType NVARCHAR(50),
    IsPosted BIT NOT NULL DEFAULT 0,
    Executor NVARCHAR(255) NOT NULL,
    LastUpdated DATETIME2 NOT NULL
);