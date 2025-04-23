CREATE TABLE ������������������ (
    ID_������ INT IDENTITY(1,1) PRIMARY KEY,
    ������������_������ NVARCHAR(100) NOT NULL,
    ���������_��������_������ CHAR(9) NOT NULL,
    ��������_��������_������ CHAR(9) NOT NULL,
    CONSTRAINT CHK_�������������� CHECK (���������_��������_������ <= ��������_��������_������)
);

CREATE TABLE ����������� (
    ��������������_����� CHAR(9) PRIMARY KEY,
    ������������ NVARCHAR(100) NOT NULL,
    ����������� NVARCHAR(50),
    �������_��������� NVARCHAR(10) NOT NULL,
    ����������� NVARCHAR(200),
    ��������_�������_����� NVARCHAR(50),
    �����������_������������ NVARCHAR(100),
    ������������� NVARCHAR(100),
    ������_������������ AS (������������ + ' ' + ISNULL(�����������, '') + ' ' + ISNULL(�����������, '') + ' ' + ISNULL(��������_�������_�����, '') + ' ' + ISNULL(�����������_������������, '')) PERSISTED,
    �������_������������� TINYINT NOT NULL CHECK (�������_������������� IN (0, 1, 2)),
    �����������_������� INT NOT NULL DEFAULT 0,
    ID_������ INT NOT NULL FOREIGN KEY REFERENCES ������������������(ID_������)
);

CREATE TABLE ������������������� (
    ��������������_����� CHAR(9) NOT NULL FOREIGN KEY REFERENCES �����������(��������������_�����),
    ��������������_�����_������� CHAR(9) NOT NULL FOREIGN KEY REFERENCES �����������(��������������_�����),
    PRIMARY KEY (��������������_�����, ��������������_�����_�������),
    CONSTRAINT CHK_�������������� CHECK (��������������_����� <> ��������������_�����_�������)
);

CREATE TABLE ���������������� (
    ID_������ INT IDENTITY(1,1) PRIMARY KEY,
    ��������������_����� CHAR(9) NOT NULL FOREIGN KEY REFERENCES �����������(��������������_�����),
    ����_��������� NVARCHAR(50) NOT NULL,
    ��������_�� NVARCHAR(MAX),
    ��������_����� NVARCHAR(MAX),
    ����_��������� DATETIME2 NOT NULL DEFAULT SYSDATETIME()
);

CREATE TABLE ���������� (
    ��� VARCHAR(12) PRIMARY KEY CHECK (��� LIKE '[0-9]%'),
    ������������_���������� NVARCHAR(100) NOT NULL,
    �����������_����� NVARCHAR(200) NOT NULL,
    ����������_������ NVARCHAR(200),
    ���������� NVARCHAR(MAX)
);

--2 

CREATE TABLE ���� (
    ID_���� INT IDENTITY(1,1) PRIMARY KEY,
    ������������_���� NVARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE �������������� (
    ID_������ INT IDENTITY(1,1) PRIMARY KEY,
    ����_�������� DATE NOT NULL DEFAULT GETDATE(),
    ID_���� INT NOT NULL FOREIGN KEY REFERENCES ����(ID_����),
    ���_������ NVARCHAR(20) NOT NULL CHECK (���_������ IN ('��������', '�����������')),
    ������ NVARCHAR(50) NOT NULL CHECK (������ IN ('�����', '� ���������', '�������� ���������', '���������', '��������'))
	ID_������_������������ INT NULL FOREIGN KEY REFERENCES ��������������������(ID_������), -- ����� � ���������
);

CREATE TABLE �������������������� (
    ID_������� INT IDENTITY(1,1) PRIMARY KEY,
    ID_������ INT NOT NULL FOREIGN KEY REFERENCES ��������������(ID_������),
    ��������������_����� CHAR(9) NULL FOREIGN KEY REFERENCES �����������(��������������_�����), -- ����� ���� NULL ��� �������������� ��������
    ������������_����������� NVARCHAR(200) NOT NULL, -- �������� �� ������ �������� ������
    ���������_���������� INT NOT NULL CHECK (���������_���������� > 0),
    ���������_���� DATE NULL, 
    ������� NVARCHAR(500) NULL, -- ��� ����������� ������
);

