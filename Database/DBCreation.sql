IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [AccountTypes] (
    [ID] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_AccountTypes] PRIMARY KEY ([ID])
);

GO

CREATE TABLE [Addresses] (
    [ID] int NOT NULL IDENTITY,
    [StreetAddress] nvarchar(max) NOT NULL,
    [City] nvarchar(max) NOT NULL,
    [State] nvarchar(max) NOT NULL,
    [PostalCode] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Addresses] PRIMARY KEY ([ID])
);

GO

CREATE TABLE [Customers] (
    [ID] int NOT NULL IDENTITY,
    [FirstName] nvarchar(max) NOT NULL,
    [LastName] nvarchar(max) NOT NULL,
    [EmailAddress] nvarchar(max) NOT NULL,
    [PhoneNumber] nvarchar(max) NULL,
    CONSTRAINT [PK_Customers] PRIMARY KEY ([ID])
);

GO

CREATE TABLE [PaymentMethods] (
    [ID] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_PaymentMethods] PRIMARY KEY ([ID])
);

GO

CREATE TABLE [Accounts] (
    [ID] int NOT NULL IDENTITY,
    [CustomerID] int NOT NULL,
    [BillingAddressID] int NOT NULL,
    [ServiceAddressID] int NOT NULL,
    [AccountTypeID] int NOT NULL,
    [AddressID] int NULL,
    CONSTRAINT [PK_Accounts] PRIMARY KEY ([ID]),
    CONSTRAINT [FK_Accounts_AccountTypes_AccountTypeID] FOREIGN KEY ([AccountTypeID]) REFERENCES [AccountTypes] ([ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Accounts_Addresses_AddressID] FOREIGN KEY ([AddressID]) REFERENCES [Addresses] ([ID]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Accounts_Addresses_BillingAddressID] FOREIGN KEY ([BillingAddressID]) REFERENCES [Addresses] ([ID]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Accounts_Customers_CustomerID] FOREIGN KEY ([CustomerID]) REFERENCES [Customers] ([ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Accounts_Addresses_ServiceAddressID] FOREIGN KEY ([ServiceAddressID]) REFERENCES [Addresses] ([ID]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Invoices] (
    [ID] int NOT NULL IDENTITY,
    [AccountID] int NOT NULL,
    [InvoiceDate] datetime2 NOT NULL,
    [Amount] decimal(18,2) NOT NULL,
    [IsPaid] bit NOT NULL,
    CONSTRAINT [PK_Invoices] PRIMARY KEY ([ID]),
    CONSTRAINT [FK_Invoices_Accounts_AccountID] FOREIGN KEY ([AccountID]) REFERENCES [Accounts] ([ID]) ON DELETE CASCADE
);

GO

CREATE TABLE [Payments] (
    [ID] int NOT NULL IDENTITY,
    [InvoiceID] int NOT NULL,
    [PaymentMethodID] int NOT NULL,
    [Amount] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_Payments] PRIMARY KEY ([ID]),
    CONSTRAINT [FK_Payments_Invoices_InvoiceID] FOREIGN KEY ([InvoiceID]) REFERENCES [Invoices] ([ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Payments_PaymentMethods_PaymentMethodID] FOREIGN KEY ([PaymentMethodID]) REFERENCES [PaymentMethods] ([ID]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Accounts_AccountTypeID] ON [Accounts] ([AccountTypeID]);

GO

CREATE INDEX [IX_Accounts_AddressID] ON [Accounts] ([AddressID]);

GO

CREATE INDEX [IX_Accounts_BillingAddressID] ON [Accounts] ([BillingAddressID]);

GO

CREATE INDEX [IX_Accounts_CustomerID] ON [Accounts] ([CustomerID]);

GO

CREATE INDEX [IX_Accounts_ServiceAddressID] ON [Accounts] ([ServiceAddressID]);

GO

CREATE INDEX [IX_Invoices_AccountID] ON [Invoices] ([AccountID]);

GO

CREATE INDEX [IX_Payments_InvoiceID] ON [Payments] ([InvoiceID]);

GO

CREATE INDEX [IX_Payments_PaymentMethodID] ON [Payments] ([PaymentMethodID]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200703211549_InitialMigration', N'3.1.5');

GO

ALTER TABLE [Payments] ADD [PaymentDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200703212354_UpdatePayment', N'3.1.5');

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Name') AND [object_id] = OBJECT_ID(N'[AccountTypes]'))
    SET IDENTITY_INSERT [AccountTypes] ON;
INSERT INTO [AccountTypes] ([ID], [Name])
VALUES (1, N'Residential'),
(2, N'Commercial');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Name') AND [object_id] = OBJECT_ID(N'[AccountTypes]'))
    SET IDENTITY_INSERT [AccountTypes] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'City', N'PostalCode', N'State', N'StreetAddress') AND [object_id] = OBJECT_ID(N'[Addresses]'))
    SET IDENTITY_INSERT [Addresses] ON;
INSERT INTO [Addresses] ([ID], [City], [PostalCode], [State], [StreetAddress])
VALUES (1, N'Chicago', N'60606', N'IL', N'201 West Lake Street'),
(2, N'Chicago', N'60606', N'IL', N'333 West Wacker Drive'),
(3, N'Chicago', N'60606', N'IL', N'233 South Wacker Drive');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'City', N'PostalCode', N'State', N'StreetAddress') AND [object_id] = OBJECT_ID(N'[Addresses]'))
    SET IDENTITY_INSERT [Addresses] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'EmailAddress', N'FirstName', N'LastName', N'PhoneNumber') AND [object_id] = OBJECT_ID(N'[Customers]'))
    SET IDENTITY_INSERT [Customers] ON;
INSERT INTO [Customers] ([ID], [EmailAddress], [FirstName], [LastName], [PhoneNumber])
VALUES (1, N'ericgomoll@gmail.com', N'Eric', N'Gomoll', N'(847) 722-9149'),
(2, N'dsoderna@eligoenergy.com', N'David', N'Solderna', NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'EmailAddress', N'FirstName', N'LastName', N'PhoneNumber') AND [object_id] = OBJECT_ID(N'[Customers]'))
    SET IDENTITY_INSERT [Customers] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Name') AND [object_id] = OBJECT_ID(N'[PaymentMethods]'))
    SET IDENTITY_INSERT [PaymentMethods] ON;
INSERT INTO [PaymentMethods] ([ID], [Name])
VALUES (1, N'Credit Card'),
(2, N'Check'),
(3, N'Cash');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Name') AND [object_id] = OBJECT_ID(N'[PaymentMethods]'))
    SET IDENTITY_INSERT [PaymentMethods] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'AccountTypeID', N'AddressID', N'BillingAddressID', N'CustomerID', N'ServiceAddressID') AND [object_id] = OBJECT_ID(N'[Accounts]'))
    SET IDENTITY_INSERT [Accounts] ON;
INSERT INTO [Accounts] ([ID], [AccountTypeID], [AddressID], [BillingAddressID], [CustomerID], [ServiceAddressID])
VALUES (101, 1, NULL, 2, 1, 2);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'AccountTypeID', N'AddressID', N'BillingAddressID', N'CustomerID', N'ServiceAddressID') AND [object_id] = OBJECT_ID(N'[Accounts]'))
    SET IDENTITY_INSERT [Accounts] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'AccountTypeID', N'AddressID', N'BillingAddressID', N'CustomerID', N'ServiceAddressID') AND [object_id] = OBJECT_ID(N'[Accounts]'))
    SET IDENTITY_INSERT [Accounts] ON;
INSERT INTO [Accounts] ([ID], [AccountTypeID], [AddressID], [BillingAddressID], [CustomerID], [ServiceAddressID])
VALUES (102, 1, NULL, 1, 2, 1);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'AccountTypeID', N'AddressID', N'BillingAddressID', N'CustomerID', N'ServiceAddressID') AND [object_id] = OBJECT_ID(N'[Accounts]'))
    SET IDENTITY_INSERT [Accounts] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'AccountTypeID', N'AddressID', N'BillingAddressID', N'CustomerID', N'ServiceAddressID') AND [object_id] = OBJECT_ID(N'[Accounts]'))
    SET IDENTITY_INSERT [Accounts] ON;
INSERT INTO [Accounts] ([ID], [AccountTypeID], [AddressID], [BillingAddressID], [CustomerID], [ServiceAddressID])
VALUES (103, 2, NULL, 1, 2, 3);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'AccountTypeID', N'AddressID', N'BillingAddressID', N'CustomerID', N'ServiceAddressID') AND [object_id] = OBJECT_ID(N'[Accounts]'))
    SET IDENTITY_INSERT [Accounts] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'AccountID', N'Amount', N'InvoiceDate', N'IsPaid') AND [object_id] = OBJECT_ID(N'[Invoices]'))
    SET IDENTITY_INSERT [Invoices] ON;
INSERT INTO [Invoices] ([ID], [AccountID], [Amount], [InvoiceDate], [IsPaid])
VALUES (5544, 101, 124.54, '2020-04-10T00:00:00.0000000', CAST(1 AS bit)),
(6062, 101, 117.01, '2020-05-10T00:00:00.0000000', CAST(1 AS bit)),
(6098, 101, 135.04, '2020-06-10T00:00:00.0000000', CAST(0 AS bit)),
(5334, 102, 79.76, '2020-04-04T00:00:00.0000000', CAST(1 AS bit)),
(6097, 102, 114.54, '2020-05-04T00:00:00.0000000', CAST(1 AS bit)),
(6114, 102, 122.0, '2020-06-04T00:00:00.0000000', CAST(0 AS bit)),
(5495, 103, 145.43, '2020-04-23T00:00:00.0000000', CAST(1 AS bit)),
(6113, 103, 176.04, '2020-05-23T00:00:00.0000000', CAST(1 AS bit)),
(6122, 103, 191.01, '2020-06-23T00:00:00.0000000', CAST(1 AS bit));
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'AccountID', N'Amount', N'InvoiceDate', N'IsPaid') AND [object_id] = OBJECT_ID(N'[Invoices]'))
    SET IDENTITY_INSERT [Invoices] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Amount', N'InvoiceID', N'PaymentDate', N'PaymentMethodID') AND [object_id] = OBJECT_ID(N'[Payments]'))
    SET IDENTITY_INSERT [Payments] ON;
INSERT INTO [Payments] ([ID], [Amount], [InvoiceID], [PaymentDate], [PaymentMethodID])
VALUES (4432, 124.54, 5544, '2020-04-25T00:00:00.0000000', 1),
(4954, 117.01, 6062, '2020-05-30T00:00:00.0000000', 1),
(4345, 79.76, 5334, '2020-04-19T00:00:00.0000000', 1),
(4957, 114.54, 6097, '2020-05-30T00:00:00.0000000', 1),
(4309, 145.43, 5495, '2020-05-09T00:00:00.0000000', 2),
(5005, 176.04, 6113, '2020-06-01T00:00:00.0000000', 2),
(5109, 191.01, 6122, '2020-07-06T00:00:00.0000000', 2);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'Amount', N'InvoiceID', N'PaymentDate', N'PaymentMethodID') AND [object_id] = OBJECT_ID(N'[Payments]'))
    SET IDENTITY_INSERT [Payments] OFF;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200703213924_SeedData', N'3.1.5');

GO

ALTER TABLE [Accounts] DROP CONSTRAINT [FK_Accounts_Addresses_AddressID];

GO

DROP INDEX [IX_Accounts_AddressID] ON [Accounts];

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Accounts]') AND [c].[name] = N'AddressID');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Accounts] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Accounts] DROP COLUMN [AddressID];

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200703214905_UpdateAddressEntity', N'3.1.5');

GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PaymentMethods]') AND [c].[name] = N'Name');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [PaymentMethods] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [PaymentMethods] ALTER COLUMN [Name] nvarchar(max) NOT NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200705200351_DateUpdates', N'3.1.5');

GO

