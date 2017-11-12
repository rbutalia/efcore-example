IF OBJECT_ID(N'__EFMigrationsHistory') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Categories] (
    [CategoryID] int NOT NULL IDENTITY,
    [CategoryName] nvarchar(max) NULL,
    [CreatedBy] nvarchar(max) NULL,
    [CreatedDate] datetime2 NOT NULL,
    [Description] nvarchar(max) NULL,
    [ModifiedBy] nvarchar(max) NULL,
    [ModifiedDate] datetime2 NOT NULL,
    [Picture] varbinary(max) NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY ([CategoryID])
);

GO

CREATE TABLE [Companies] (
    [CompanyID] int NOT NULL IDENTITY,
    [CompanyName] nvarchar(max) NULL,
    [ContactPersonName] nvarchar(max) NULL,
    [CreatedBy] nvarchar(max) NULL,
    [CreatedDate] datetime2 NOT NULL,
    [ModifiedBy] nvarchar(max) NULL,
    [ModifiedDate] datetime2 NOT NULL,
    [SalesTax] decimal(18, 2) NOT NULL,
    [TextIdentifier] nvarchar(max) NULL,
    CONSTRAINT [PK_Companies] PRIMARY KEY ([CompanyID])
);

GO

CREATE TABLE [Shippers] (
    [ShipperID] int NOT NULL IDENTITY,
    [CompanyName] nvarchar(max) NULL,
    [Phone] nvarchar(max) NULL,
    CONSTRAINT [PK_Shippers] PRIMARY KEY ([ShipperID])
);

GO

CREATE TABLE [Suppliers] (
    [SupplierID] int NOT NULL IDENTITY,
    [Address] nvarchar(max) NULL,
    [City] nvarchar(max) NULL,
    [CompanyName] nvarchar(max) NULL,
    [ContactName] nvarchar(max) NULL,
    [ContactTitle] nvarchar(max) NULL,
    [Country] nvarchar(max) NULL,
    [Fax] nvarchar(max) NULL,
    [HomePage] nvarchar(max) NULL,
    [Phone] nvarchar(max) NULL,
    [PostalCode] nvarchar(max) NULL,
    [Region] nvarchar(max) NULL,
    CONSTRAINT [PK_Suppliers] PRIMARY KEY ([SupplierID])
);

GO

CREATE TABLE [Customers] (
    [CustomerID] int NOT NULL IDENTITY,
    [City] nvarchar(max) NULL,
    [CompanyID] int NOT NULL,
    [ContactName] nvarchar(max) NULL,
    [ContactTitle] nvarchar(max) NULL,
    [Country] nvarchar(max) NULL,
    [CreatedBy] nvarchar(max) NULL,
    [CreatedDate] datetime2 NOT NULL,
    [Fax] nvarchar(max) NULL,
    [ModifiedBy] nvarchar(max) NULL,
    [ModifiedDate] datetime2 NOT NULL,
    [Phone] nvarchar(max) NULL,
    [PostalCode] nvarchar(max) NULL,
    [Region] nvarchar(max) NULL,
    [StreetAddress_Line1] nvarchar(max) NULL,
    [StreetAddress_Line2] nvarchar(max) NULL,
    CONSTRAINT [PK_Customers] PRIMARY KEY ([CustomerID]),
    CONSTRAINT [FK_Customers_Companies_CompanyID] FOREIGN KEY ([CompanyID]) REFERENCES [Companies] ([CompanyID]) ON DELETE CASCADE
);

GO

CREATE TABLE [Menus] (
    [MenuID] int NOT NULL IDENTITY,
    [CompanyID] int NOT NULL,
    [CreatedBy] nvarchar(max) NULL,
    [CreatedDate] datetime2 NOT NULL,
    [IsActive] bit NOT NULL,
    [MenuName] nvarchar(max) NULL,
    [ModifiedBy] nvarchar(max) NULL,
    [ModifiedDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Menus] PRIMARY KEY ([MenuID]),
    CONSTRAINT [FK_Menus_Companies_CompanyID] FOREIGN KEY ([CompanyID]) REFERENCES [Companies] ([CompanyID]) ON DELETE CASCADE
);

GO

CREATE TABLE [WorkflowSteps] (
    [WorkflowStepID] int NOT NULL IDENTITY,
    [CompanyID] int NOT NULL,
    [CreatedBy] nvarchar(max) NULL,
    [CreatedDate] datetime2 NOT NULL,
    [Description] nvarchar(max) NULL,
    [ModifiedBy] nvarchar(max) NULL,
    [ModifiedDate] datetime2 NOT NULL,
    [RegularExpression] nvarchar(max) NULL,
    [StepName] nvarchar(max) NULL,
    CONSTRAINT [PK_WorkflowSteps] PRIMARY KEY ([WorkflowStepID]),
    CONSTRAINT [FK_WorkflowSteps_Companies_CompanyID] FOREIGN KEY ([CompanyID]) REFERENCES [Companies] ([CompanyID]) ON DELETE CASCADE
);

GO

CREATE TABLE [Orders] (
    [OrderID] int NOT NULL IDENTITY,
    [CompanyID] int NOT NULL,
    [CreatedBy] nvarchar(max) NULL,
    [CreatedDate] datetime2 NOT NULL,
    [Freight] decimal(18, 2) NULL,
    [ModifiedBy] nvarchar(max) NULL,
    [ModifiedDate] datetime2 NOT NULL,
    [OrderDate] datetime2 NOT NULL,
    [RequiredDate] datetime2 NULL,
    [ShipAddress] nvarchar(max) NULL,
    [ShipCity] nvarchar(max) NULL,
    [ShipCountry] nvarchar(max) NULL,
    [ShipName] nvarchar(max) NULL,
    [ShipPostalCode] nvarchar(max) NULL,
    [ShipRegion] nvarchar(max) NULL,
    [ShipVia] int NULL,
    [ShippedDate] datetime2 NULL,
    [ShipperID] int NULL,
    [Status] int NOT NULL,
    [Total] decimal(18, 2) NOT NULL,
    [TotalWithTax] decimal(18, 2) NOT NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY ([OrderID]),
    CONSTRAINT [FK_Orders_Companies_CompanyID] FOREIGN KEY ([CompanyID]) REFERENCES [Companies] ([CompanyID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Orders_Shippers_ShipperID] FOREIGN KEY ([ShipperID]) REFERENCES [Shippers] ([ShipperID]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Products] (
    [ProductID] int NOT NULL IDENTITY,
    [CategoryID] int NOT NULL,
    [Discontinued] bit NOT NULL,
    [ProductName] nvarchar(max) NULL,
    [QuantityPerUnit] nvarchar(max) NULL,
    [ReorderLevel] smallint NULL,
    [SupplierID] int NULL,
    [UnitPrice] decimal(18, 2) NULL,
    [UnitsInStock] smallint NULL,
    [UnitsOnOrder] smallint NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY ([ProductID]),
    CONSTRAINT [FK_Products_Categories_CategoryID] FOREIGN KEY ([CategoryID]) REFERENCES [Categories] ([CategoryID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Products_Suppliers_SupplierID] FOREIGN KEY ([SupplierID]) REFERENCES [Suppliers] ([SupplierID]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Subscribers] (
    [SubscriberID] int NOT NULL IDENTITY,
    [CreatedBy] nvarchar(max) NULL,
    [CreatedDate] datetime2 NOT NULL,
    [CustomerId] int NOT NULL,
    [IsActive] bit NOT NULL,
    [ModifiedBy] nvarchar(max) NULL,
    [ModifiedDate] datetime2 NOT NULL,
    [PhoneNumber] nvarchar(max) NULL,
    [Subscribed] bit NOT NULL,
    CONSTRAINT [PK_Subscribers] PRIMARY KEY ([SubscriberID]),
    CONSTRAINT [FK_Subscribers_Customers_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [Customers] ([CustomerID]) ON DELETE CASCADE
);

GO

CREATE TABLE [MenuItems] (
    [MenuItemID] int NOT NULL IDENTITY,
    [CreatedBy] nvarchar(max) NULL,
    [CreatedDate] datetime2 NOT NULL,
    [IsActive] bit NOT NULL,
    [ItemName] nvarchar(max) NULL,
    [MenuID] int NOT NULL,
    [ModifiedBy] nvarchar(max) NULL,
    [ModifiedDate] datetime2 NOT NULL,
    [Price] decimal(18, 2) NOT NULL,
    CONSTRAINT [PK_MenuItems] PRIMARY KEY ([MenuItemID]),
    CONSTRAINT [FK_MenuItems_Menus_MenuID] FOREIGN KEY ([MenuID]) REFERENCES [Menus] ([MenuID]) ON DELETE CASCADE
);

GO

CREATE TABLE [OrderDetails] (
    [OrderDetailID] int NOT NULL IDENTITY,
    [CreatedBy] nvarchar(max) NULL,
    [CreatedDate] datetime2 NOT NULL,
    [Discount] real NOT NULL,
    [MenuItemID] int NOT NULL,
    [ModifiedBy] nvarchar(max) NULL,
    [ModifiedDate] datetime2 NOT NULL,
    [OrderID] int NOT NULL,
    [Quantity] smallint NOT NULL,
    [UnitPrice] decimal(18, 2) NOT NULL,
    CONSTRAINT [PK_OrderDetails] PRIMARY KEY ([OrderDetailID]),
    CONSTRAINT [FK_OrderDetails_MenuItems_MenuItemID] FOREIGN KEY ([MenuItemID]) REFERENCES [MenuItems] ([MenuItemID]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Customers_CompanyID] ON [Customers] ([CompanyID]);

GO

CREATE INDEX [IX_MenuItems_MenuID] ON [MenuItems] ([MenuID]);

GO

CREATE INDEX [IX_Menus_CompanyID] ON [Menus] ([CompanyID]);

GO

CREATE INDEX [IX_OrderDetails_MenuItemID] ON [OrderDetails] ([MenuItemID]);

GO

CREATE INDEX [IX_Orders_CompanyID] ON [Orders] ([CompanyID]);

GO

CREATE INDEX [IX_Orders_ShipperID] ON [Orders] ([ShipperID]);

GO

CREATE INDEX [IX_Products_CategoryID] ON [Products] ([CategoryID]);

GO

CREATE INDEX [IX_Products_SupplierID] ON [Products] ([SupplierID]);

GO

CREATE INDEX [IX_Subscribers_CustomerId] ON [Subscribers] ([CustomerId]);

GO

CREATE INDEX [IX_WorkflowSteps_CompanyID] ON [WorkflowSteps] ([CompanyID]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20171111074758_init', N'2.0.0-rtm-26452');

GO

