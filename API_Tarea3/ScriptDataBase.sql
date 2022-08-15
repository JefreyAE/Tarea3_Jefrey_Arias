
create database Tare3_db;
CREATE TABLE [Appointments] (
    [Id] int NOT NULL IDENTITY,
    [Appointment_date] datetime2 NOT NULL,
    [Created_at] datetime2 NOT NULL,
    CONSTRAINT [PK_Appointments] PRIMARY KEY ([Id])
);
GO


CREATE TABLE [Users] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [UserId] int NOT NULL,
    [Birthday] datetime2 NOT NULL,
    [Payment_method] nvarchar(max) NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);
GO


CREATE TABLE [Agendas] (
    [Id] int NOT NULL IDENTITY,
    [Hour] int NOT NULL,
    [Specialty] nvarchar(max) NOT NULL,
    [AppointmentId] int NOT NULL,
    [State] nvarchar(max) NULL,
    [UserId] int NOT NULL,
    CONSTRAINT [PK_Agendas] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Agendas_Appointments_AppointmentId] FOREIGN KEY ([AppointmentId]) REFERENCES [Appointments] ([Id]) ON DELETE CASCADE
);
GO


CREATE INDEX [IX_Agendas_AppointmentId] ON [Agendas] ([AppointmentId]);
GO


