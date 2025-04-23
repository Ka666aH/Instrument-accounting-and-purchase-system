-- Создание таблиц для Модуля 1 (АРМ инженера) 
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

CREATE TABLE Поставщики (
    ИНН VARCHAR(12) PRIMARY KEY CHECK (ИНН LIKE '[0-9]%'),
    Наименование_поставщика NVARCHAR(100) NOT NULL,
    Юридический_адрес NVARCHAR(200) NOT NULL,
    Контактные_данные NVARCHAR(200),
    Примечание NVARCHAR(MAX)
);

CREATE TABLE ДоговорыПоставки (
    Номер_договора NVARCHAR(50) PRIMARY KEY,
    Дата_заключения DATE NOT NULL DEFAULT GETDATE(),
    Срок_действия DATE NOT NULL,
    ИНН_поставщика VARCHAR(12) NOT NULL FOREIGN KEY REFERENCES Поставщики(ИНН),
    CONSTRAINT CHK_СрокДоговора CHECK (Срок_действия >= Дата_заключения)
);

CREATE TABLE ЛогКорректировок (
    ID_записи INT IDENTITY(1,1) PRIMARY KEY,
    Номенклатурный_номер CHAR(9) NOT NULL FOREIGN KEY REFERENCES Инструменты(Номенклатурный_номер),
    Поле_изменения NVARCHAR(50) NOT NULL,
    Значение_до NVARCHAR(MAX),
    Значение_после NVARCHAR(MAX),
    Дата_изменения DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    Пользователь_изменивший NVARCHAR(100) NOT NULL
);

CREATE TABLE ЗаявкиНаПриобретение (
    ID_заявки INT IDENTITY(1,1) PRIMARY KEY,
    Дата_формирования DATE NOT NULL DEFAULT GETDATE(),
    Статус NVARCHAR(20) NOT NULL CHECK (Статус IN ('Черновик', 'На согласовании', 'Утверждена', 'Выполнена')),
    ИНН_поставщика VARCHAR(12) NOT NULL FOREIGN KEY REFERENCES Поставщики(ИНН),
    Номенклатурный_номер CHAR(9) NOT NULL FOREIGN KEY REFERENCES Инструменты(Номенклатурный_номер),
    Количество_закупки INT NOT NULL CHECK (Количество_закупки > 0),
    Срок_поставки DATE NOT NULL,
    Номер_договора NVARCHAR(50) FOREIGN KEY REFERENCES ДоговорыПоставки(Номер_договора),
    CONSTRAINT CHK_СрокПоставки CHECK (Срок_поставки >= Дата_формирования)
);

-- Создание таблиц для Модуля 2 (АРМ кладовщика)
CREATE TABLE Цеха (
    ID_цеха INT IDENTITY(1,1) PRIMARY KEY,
    Наименование_цеха NVARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE ЗаявкиНаПолучение (
    ID_заявки INT IDENTITY(1,1) PRIMARY KEY,
    Дата_создания DATE NOT NULL DEFAULT GETDATE(),
    Тип_заявки NVARCHAR(20) NOT NULL CHECK (Тип_заявки IN ('Плановая', 'Внеплановая')),
    ID_цеха INT NOT NULL FOREIGN KEY REFERENCES Цеха(ID_цеха),
    Номенклатурный_номер CHAR(9) FOREIGN KEY REFERENCES Инструменты(Номенклатурный_номер),
    Требуемое_количество INT NOT NULL CHECK (Требуемое_количество > 0),
    Планируемая_дата_поступления DATE,
    Причина NVARCHAR(MAX),
    Статус NVARCHAR(50) NOT NULL CHECK (Статус IN ('Новая', 'В обработке', 'Частично выполнена', 'Выполнена', 'Отменена'))
);

CREATE TABLE Склады (
    ID_склада INT IDENTITY(1,1) PRIMARY KEY,
    Наименование_склада NVARCHAR(100) NOT NULL UNIQUE,
    Тип_склада NVARCHAR(20) CHECK (Тип_склада IN ('ЦИС', 'Цеховой'))
);

CREATE TABLE ВедомостиПоставки (
    ID_ведомости INT IDENTITY(1,1) PRIMARY KEY,
    Номер_договора NVARCHAR(50) NOT NULL FOREIGN KEY REFERENCES ДоговорыПоставки(Номер_договора),
    Дата_формирования DATE NOT NULL DEFAULT GETDATE(),
    Срок_поставки DATE NOT NULL,
    Статус NVARCHAR(20) NOT NULL CHECK (Статус IN ('Ожидает поставки', 'Частично поставлено', 'Поставка завершена')),
    CONSTRAINT CHK_СрокПоставкиВедомости CHECK (Срок_поставки >= Дата_формирования)
);

CREATE TABLE ПозицииВедомости (
    ID_позиции INT IDENTITY(1,1) PRIMARY KEY,
    ID_ведомости INT NOT NULL FOREIGN KEY REFERENCES ВедомостиПоставки(ID_ведомости),
    Номенклатурный_номер CHAR(9) NOT NULL FOREIGN KEY REFERENCES Инструменты(Номенклатурный_номер),
    Количество INT NOT NULL CHECK (Количество > 0),
    Цена DECIMAL(18,2) NOT NULL CHECK (Цена > 0),
    Сумма AS (Количество * Цена) PERSISTED,
    ID_заявки_приобретения INT FOREIGN KEY REFERENCES ЗаявкиНаПриобретение(ID_заявки)
);

CREATE TABLE ТоварныеНакладные (
    Номер_накладной NVARCHAR(50) PRIMARY KEY,
    ID_ведомости INT NOT NULL FOREIGN KEY REFERENCES ВедомостиПоставки(ID_ведомости),
    Дата_поступления DATE NOT NULL DEFAULT GETDATE(),
    Поставщик_ИНН VARCHAR(12) NOT NULL FOREIGN KEY REFERENCES Поставщики(ИНН),
    Статус NVARCHAR(20) NOT NULL CHECK (Статус IN ('Ожидает приемки', 'Принята', 'Частично принята', 'Отклонена'))
);

--CREATE TABLE ПозицииНакладной (
--    ID_позиции INT IDENTITY(1,1) PRIMARY KEY,
--    Номер_накладной NVARCHAR(50) NOT NULL FOREIGN KEY REFERENCES ТоварныеНакладные(Номер_накладной),
--    Номенклатурный_номер CHAR(9) NOT NULL FOREIGN KEY REFERENCES Инструменты(Номенклатурный_номер),
--    Количество_по_накладной INT NOT NULL CHECK (Количество_по_накладной > 0),
--    Цена DECIMAL(18,2) NOT NULL CHECK (Цена > 0),
--    Количество_принято INT NOT NULL CHECK (Количество_принято >= 0 AND Количество_принято <= Количество_по_накладной),
--    Сумма AS (Количество_принято * Цена) PERSISTED
--);
-- Исправленная таблица ПозицииНакладной
CREATE TABLE ПозицииНакладной (
    ID_позиции INT IDENTITY(1,1) PRIMARY KEY,
    Номер_накладной NVARCHAR(50) NOT NULL FOREIGN KEY REFERENCES ТоварныеНакладные(Номер_накладной),
    Номенклатурный_номер CHAR(9) NOT NULL FOREIGN KEY REFERENCES Инструменты(Номенклатурный_номер),
    Количество_по_накладной INT NOT NULL CHECK (Количество_по_накладной > 0),
    Цена DECIMAL(18,2) NOT NULL CHECK (Цена > 0),
    Количество_принято INT NOT NULL DEFAULT 0,
    Сумма AS (Количество_принято * Цена) PERSISTED
);

-- Добавляем отдельное ограничение для проверки Количество_принято
ALTER TABLE ПозицииНакладной
ADD CONSTRAINT CHK_КоличествоПринято 
CHECK (Количество_принято >= 0 AND Количество_принято <= Количество_по_накладной);

CREATE TABLE РаспределениеНакладной (
    ID_распределения INT IDENTITY(1,1) PRIMARY KEY,
    ID_позиции_накладной INT NOT NULL FOREIGN KEY REFERENCES ПозицииНакладной(ID_позиции),
    ID_заявки_цеха INT NOT NULL FOREIGN KEY REFERENCES ЗаявкиНаПолучение(ID_заявки),
    Количество INT NOT NULL CHECK (Количество > 0),
    Способ_распределения NVARCHAR(20) NOT NULL CHECK (Способ_распределения IN ('Пропорционально', 'Вручную'))
);

CREATE TABLE Партии (
    Номер_партии INT IDENTITY(1,1) PRIMARY KEY,
    Номер_накладной NVARCHAR(50) NOT NULL FOREIGN KEY REFERENCES ТоварныеНакладные(Номер_накладной),
    Дата_прихода DATE NOT NULL DEFAULT GETDATE(),
    Учетная_цена DECIMAL(18,2) NOT NULL CHECK (Учетная_цена > 0)
);

CREATE TABLE ДвиженияИнструментов (
    ID_движения INT IDENTITY(1,1) PRIMARY KEY,
    Тип_движения NVARCHAR(20) NOT NULL CHECK (Тип_движения IN ('Приход', 'Перемещение', 'Списание', 'Ремонт', 'Возврат', 'Реализация')),
    Дата_документа DATE NOT NULL DEFAULT GETDATE(),
    Склад_отправитель INT FOREIGN KEY REFERENCES Склады(ID_склада),
    Склад_получатель INT NOT NULL FOREIGN KEY REFERENCES Склады(ID_склада),
    Номенклатурный_номер CHAR(9) NOT NULL FOREIGN KEY REFERENCES Инструменты(Номенклатурный_номер),
    Номер_партии INT NOT NULL FOREIGN KEY REFERENCES Партии(Номер_партии),
    Количество INT NOT NULL CHECK (Количество > 0),
    Сумма DECIMAL(18,2) NOT NULL,
    Документ_источник NVARCHAR(100),
    Признак_проведения BIT NOT NULL DEFAULT 0,
    CONSTRAINT CHK_СкладыНеРавны CHECK (Склад_отправитель <> Склад_получатель OR Склад_отправитель IS NULL)
);

CREATE TABLE ДефектныеВедомости (
    ID_ведомости INT IDENTITY(1,1) PRIMARY KEY,
    Дата_создания DATE NOT NULL DEFAULT GETDATE(),
    ID_цеха INT NOT NULL FOREIGN KEY REFERENCES Цеха(ID_цеха),
    Номенклатурный_номер CHAR(9) NOT NULL FOREIGN KEY REFERENCES Инструменты(Номенклатурный_номер),
    Номер_партии INT NOT NULL FOREIGN KEY REFERENCES Партии(Номер_партии),
    Решение NVARCHAR(20) NOT NULL CHECK (Решение IN ('Списание', 'Ремонт')),
    Количество INT NOT NULL CHECK (Количество > 0)
);

CREATE TABLE Остатки (
    ID_остатка INT IDENTITY(1,1) PRIMARY KEY,
    Дата_фиксации DATE NOT NULL DEFAULT GETDATE(),
    ID_склада INT NOT NULL FOREIGN KEY REFERENCES Склады(ID_склада),
    Номенклатурный_номер CHAR(9) NOT NULL FOREIGN KEY REFERENCES Инструменты(Номенклатурный_номер),
    Количество INT NOT NULL CHECK (Количество >= 0),
    Учетная_цена DECIMAL(18,2) NOT NULL CHECK (Учетная_цена >= 0),
    CONSTRAINT UQ_Остатки UNIQUE (Дата_фиксации, ID_склада, Номенклатурный_номер)
);