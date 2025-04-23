-- �������� ������ ��� ������ 1 (��� ��������) 
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

CREATE TABLE ���������� (
    ��� VARCHAR(12) PRIMARY KEY CHECK (��� LIKE '[0-9]%'),
    ������������_���������� NVARCHAR(100) NOT NULL,
    �����������_����� NVARCHAR(200) NOT NULL,
    ����������_������ NVARCHAR(200),
    ���������� NVARCHAR(MAX)
);

CREATE TABLE ���������������� (
    �����_�������� NVARCHAR(50) PRIMARY KEY,
    ����_���������� DATE NOT NULL DEFAULT GETDATE(),
    ����_�������� DATE NOT NULL,
    ���_���������� VARCHAR(12) NOT NULL FOREIGN KEY REFERENCES ����������(���),
    CONSTRAINT CHK_������������ CHECK (����_�������� >= ����_����������)
);

CREATE TABLE ���������������� (
    ID_������ INT IDENTITY(1,1) PRIMARY KEY,
    ��������������_����� CHAR(9) NOT NULL FOREIGN KEY REFERENCES �����������(��������������_�����),
    ����_��������� NVARCHAR(50) NOT NULL,
    ��������_�� NVARCHAR(MAX),
    ��������_����� NVARCHAR(MAX),
    ����_��������� DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    ������������_���������� NVARCHAR(100) NOT NULL
);

CREATE TABLE �������������������� (
    ID_������ INT IDENTITY(1,1) PRIMARY KEY,
    ����_������������ DATE NOT NULL DEFAULT GETDATE(),
    ������ NVARCHAR(20) NOT NULL CHECK (������ IN ('��������', '�� ������������', '����������', '���������')),
    ���_���������� VARCHAR(12) NOT NULL FOREIGN KEY REFERENCES ����������(���),
    ��������������_����� CHAR(9) NOT NULL FOREIGN KEY REFERENCES �����������(��������������_�����),
    ����������_������� INT NOT NULL CHECK (����������_������� > 0),
    ����_�������� DATE NOT NULL,
    �����_�������� NVARCHAR(50) FOREIGN KEY REFERENCES ����������������(�����_��������),
    CONSTRAINT CHK_������������ CHECK (����_�������� >= ����_������������)
);

-- �������� ������ ��� ������ 2 (��� ����������)
CREATE TABLE ���� (
    ID_���� INT IDENTITY(1,1) PRIMARY KEY,
    ������������_���� NVARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE ����������������� (
    ID_������ INT IDENTITY(1,1) PRIMARY KEY,
    ����_�������� DATE NOT NULL DEFAULT GETDATE(),
    ���_������ NVARCHAR(20) NOT NULL CHECK (���_������ IN ('��������', '�����������')),
    ID_���� INT NOT NULL FOREIGN KEY REFERENCES ����(ID_����),
    ��������������_����� CHAR(9) FOREIGN KEY REFERENCES �����������(��������������_�����),
    ���������_���������� INT NOT NULL CHECK (���������_���������� > 0),
    �����������_����_����������� DATE,
    ������� NVARCHAR(MAX),
    ������ NVARCHAR(50) NOT NULL CHECK (������ IN ('�����', '� ���������', '�������� ���������', '���������', '��������'))
);

CREATE TABLE ������ (
    ID_������ INT IDENTITY(1,1) PRIMARY KEY,
    ������������_������ NVARCHAR(100) NOT NULL UNIQUE,
    ���_������ NVARCHAR(20) CHECK (���_������ IN ('���', '�������'))
);

CREATE TABLE ����������������� (
    ID_��������� INT IDENTITY(1,1) PRIMARY KEY,
    �����_�������� NVARCHAR(50) NOT NULL FOREIGN KEY REFERENCES ����������������(�����_��������),
    ����_������������ DATE NOT NULL DEFAULT GETDATE(),
    ����_�������� DATE NOT NULL,
    ������ NVARCHAR(20) NOT NULL CHECK (������ IN ('������� ��������', '�������� ����������', '�������� ���������')),
    CONSTRAINT CHK_��������������������� CHECK (����_�������� >= ����_������������)
);

CREATE TABLE ���������������� (
    ID_������� INT IDENTITY(1,1) PRIMARY KEY,
    ID_��������� INT NOT NULL FOREIGN KEY REFERENCES �����������������(ID_���������),
    ��������������_����� CHAR(9) NOT NULL FOREIGN KEY REFERENCES �����������(��������������_�����),
    ���������� INT NOT NULL CHECK (���������� > 0),
    ���� DECIMAL(18,2) NOT NULL CHECK (���� > 0),
    ����� AS (���������� * ����) PERSISTED,
    ID_������_������������ INT FOREIGN KEY REFERENCES ��������������������(ID_������)
);

CREATE TABLE ����������������� (
    �����_��������� NVARCHAR(50) PRIMARY KEY,
    ID_��������� INT NOT NULL FOREIGN KEY REFERENCES �����������������(ID_���������),
    ����_����������� DATE NOT NULL DEFAULT GETDATE(),
    ���������_��� VARCHAR(12) NOT NULL FOREIGN KEY REFERENCES ����������(���),
    ������ NVARCHAR(20) NOT NULL CHECK (������ IN ('������� �������', '�������', '�������� �������', '���������'))
);

--CREATE TABLE ���������������� (
--    ID_������� INT IDENTITY(1,1) PRIMARY KEY,
--    �����_��������� NVARCHAR(50) NOT NULL FOREIGN KEY REFERENCES �����������������(�����_���������),
--    ��������������_����� CHAR(9) NOT NULL FOREIGN KEY REFERENCES �����������(��������������_�����),
--    ����������_��_��������� INT NOT NULL CHECK (����������_��_��������� > 0),
--    ���� DECIMAL(18,2) NOT NULL CHECK (���� > 0),
--    ����������_������� INT NOT NULL CHECK (����������_������� >= 0 AND ����������_������� <= ����������_��_���������),
--    ����� AS (����������_������� * ����) PERSISTED
--);
-- ������������ ������� ����������������
CREATE TABLE ���������������� (
    ID_������� INT IDENTITY(1,1) PRIMARY KEY,
    �����_��������� NVARCHAR(50) NOT NULL FOREIGN KEY REFERENCES �����������������(�����_���������),
    ��������������_����� CHAR(9) NOT NULL FOREIGN KEY REFERENCES �����������(��������������_�����),
    ����������_��_��������� INT NOT NULL CHECK (����������_��_��������� > 0),
    ���� DECIMAL(18,2) NOT NULL CHECK (���� > 0),
    ����������_������� INT NOT NULL DEFAULT 0,
    ����� AS (����������_������� * ����) PERSISTED
);

-- ��������� ��������� ����������� ��� �������� ����������_�������
ALTER TABLE ����������������
ADD CONSTRAINT CHK_����������������� 
CHECK (����������_������� >= 0 AND ����������_������� <= ����������_��_���������);

CREATE TABLE ���������������������� (
    ID_������������� INT IDENTITY(1,1) PRIMARY KEY,
    ID_�������_��������� INT NOT NULL FOREIGN KEY REFERENCES ����������������(ID_�������),
    ID_������_���� INT NOT NULL FOREIGN KEY REFERENCES �����������������(ID_������),
    ���������� INT NOT NULL CHECK (���������� > 0),
    ������_������������� NVARCHAR(20) NOT NULL CHECK (������_������������� IN ('���������������', '�������'))
);

CREATE TABLE ������ (
    �����_������ INT IDENTITY(1,1) PRIMARY KEY,
    �����_��������� NVARCHAR(50) NOT NULL FOREIGN KEY REFERENCES �����������������(�����_���������),
    ����_������� DATE NOT NULL DEFAULT GETDATE(),
    �������_���� DECIMAL(18,2) NOT NULL CHECK (�������_���� > 0)
);

CREATE TABLE �������������������� (
    ID_�������� INT IDENTITY(1,1) PRIMARY KEY,
    ���_�������� NVARCHAR(20) NOT NULL CHECK (���_�������� IN ('������', '�����������', '��������', '������', '�������', '����������')),
    ����_��������� DATE NOT NULL DEFAULT GETDATE(),
    �����_����������� INT FOREIGN KEY REFERENCES ������(ID_������),
    �����_���������� INT NOT NULL FOREIGN KEY REFERENCES ������(ID_������),
    ��������������_����� CHAR(9) NOT NULL FOREIGN KEY REFERENCES �����������(��������������_�����),
    �����_������ INT NOT NULL FOREIGN KEY REFERENCES ������(�����_������),
    ���������� INT NOT NULL CHECK (���������� > 0),
    ����� DECIMAL(18,2) NOT NULL,
    ��������_�������� NVARCHAR(100),
    �������_���������� BIT NOT NULL DEFAULT 0,
    CONSTRAINT CHK_������������� CHECK (�����_����������� <> �����_���������� OR �����_����������� IS NULL)
);

CREATE TABLE ������������������ (
    ID_��������� INT IDENTITY(1,1) PRIMARY KEY,
    ����_�������� DATE NOT NULL DEFAULT GETDATE(),
    ID_���� INT NOT NULL FOREIGN KEY REFERENCES ����(ID_����),
    ��������������_����� CHAR(9) NOT NULL FOREIGN KEY REFERENCES �����������(��������������_�����),
    �����_������ INT NOT NULL FOREIGN KEY REFERENCES ������(�����_������),
    ������� NVARCHAR(20) NOT NULL CHECK (������� IN ('��������', '������')),
    ���������� INT NOT NULL CHECK (���������� > 0)
);

CREATE TABLE ������� (
    ID_������� INT IDENTITY(1,1) PRIMARY KEY,
    ����_�������� DATE NOT NULL DEFAULT GETDATE(),
    ID_������ INT NOT NULL FOREIGN KEY REFERENCES ������(ID_������),
    ��������������_����� CHAR(9) NOT NULL FOREIGN KEY REFERENCES �����������(��������������_�����),
    ���������� INT NOT NULL CHECK (���������� >= 0),
    �������_���� DECIMAL(18,2) NOT NULL CHECK (�������_���� >= 0),
    CONSTRAINT UQ_������� UNIQUE (����_��������, ID_������, ��������������_�����)
);