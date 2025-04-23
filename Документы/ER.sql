CREATE TABLE ГруппыИнструментов (
    ID_группы INT IDENTITY(1,1) PRIMARY KEY,
    Наименование_группы NVARCHAR(100) NOT NULL,
    Начальный_диапазон_номера CHAR(9) NOT NULL,
    Конечный_диапазон_номера CHAR(9) NOT NULL,
    CONSTRAINT CHK_ГруппыДиапазон CHECK (Начальный_диапазон_номера <= Конечный_диапазон_номера)
);

CREATE TABLE Инструменты (
    Номенклатурный_номер CHAR(9) PRIMARY KEY,
    Наименование NVARCHAR(100) NOT NULL,
    Обозначение NVARCHAR(50),
    Единица_измерения NVARCHAR(10) NOT NULL,
    Типоразмеры NVARCHAR(200),
    Материал_режущей_части NVARCHAR(50),
    Нормативная_документация NVARCHAR(100),
    Производитель NVARCHAR(100),
    Полное_наименование AS (Наименование + ' ' + ISNULL(Обозначение, '') + ' ' + ISNULL(Типоразмеры, '') + ' ' + ISNULL(Материал_режущей_части, '') + ' ' + ISNULL(Нормативная_документация, '')) PERSISTED,
    Признак_использования TINYINT NOT NULL CHECK (Признак_использования IN (0, 1, 2)),
    Неснижаемый_остаток INT NOT NULL DEFAULT 0,
    ID_группы INT NOT NULL FOREIGN KEY REFERENCES ГруппыИнструментов(ID_группы)
);

CREATE TABLE АналогиИнструментов (
    Номенклатурный_номер CHAR(9) NOT NULL FOREIGN KEY REFERENCES Инструменты(Номенклатурный_номер),
    Номенклатурный_номер_аналога CHAR(9) NOT NULL FOREIGN KEY REFERENCES Инструменты(Номенклатурный_номер),
    PRIMARY KEY (Номенклатурный_номер, Номенклатурный_номер_аналога),
    CONSTRAINT CHK_АналогиНеРавны CHECK (Номенклатурный_номер <> Номенклатурный_номер_аналога)
);

CREATE TABLE ЛогКорректировок (
    ID_записи INT IDENTITY(1,1) PRIMARY KEY,
    Номенклатурный_номер CHAR(9) NOT NULL FOREIGN KEY REFERENCES Инструменты(Номенклатурный_номер),
    Поле_изменения NVARCHAR(50) NOT NULL,
    Значение_до NVARCHAR(MAX),
    Значение_после NVARCHAR(MAX),
    Дата_изменения DATETIME2 NOT NULL DEFAULT SYSDATETIME()
);

CREATE TABLE Поставщики (
    ИНН VARCHAR(12) PRIMARY KEY CHECK (ИНН LIKE '[0-9]%'),
    Наименование_поставщика NVARCHAR(100) NOT NULL,
    Юридический_адрес NVARCHAR(200) NOT NULL,
    Контактные_данные NVARCHAR(200),
    Примечание NVARCHAR(MAX)
);

--2 

CREATE TABLE Цеха (
    ID_цеха INT IDENTITY(1,1) PRIMARY KEY,
    Наименование_цеха NVARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE ЗаявкиНаВыдачу (
    ID_заявки INT IDENTITY(1,1) PRIMARY KEY,
    Дата_создания DATE NOT NULL DEFAULT GETDATE(),
    ID_цеха INT NOT NULL FOREIGN KEY REFERENCES Цеха(ID_цеха),
    Тип_заявки NVARCHAR(20) NOT NULL CHECK (Тип_заявки IN ('Плановая', 'Внеплановая')),
    Статус NVARCHAR(50) NOT NULL CHECK (Статус IN ('Новая', 'В обработке', 'Частично выполнена', 'Выполнена', 'Отменена'))
	ID_заявки_приобретения INT NULL FOREIGN KEY REFERENCES ЗаявкиНаПриобретение(ID_заявки), -- Связь с закупками
);

CREATE TABLE СоставЗаявкиНаВыдачу (
    ID_позиции INT IDENTITY(1,1) PRIMARY KEY,
    ID_заявки INT NOT NULL FOREIGN KEY REFERENCES ЗаявкиНаВыдачу(ID_заявки),
    Номенклатурный_номер CHAR(9) NULL FOREIGN KEY REFERENCES Инструменты(Номенклатурный_номер), -- Может быть NULL при первоначальном создании
    Наименование_инструмента NVARCHAR(200) NOT NULL, -- Название на момент создания заявки
    Требуемое_количество INT NOT NULL CHECK (Требуемое_количество > 0),
    Требуемая_дата DATE NULL, 
    Причина NVARCHAR(500) NULL, -- Для внеплановых заявок
);

