CREATE TABLE [dbo].[Profile] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [Firstname]       VARCHAR (50)   NOT NULL,
    [Secondname]      VARCHAR (50)   NULL,
    [Thirdname]       VARCHAR (50)   NULL,
    [Lastname]        VARCHAR (50)   NOT NULL,
    [PhoneNo]         VARCHAR (10)   NULL,
    [Email]           NVARCHAR (100) NOT NULL,
    [CreatedOn]       DATE           NOT NULL,
    [CreatedBy]       NVARCHAR (50)  NOT NULL,
    [SecurityID]      NVARCHAR (128) NOT NULL,
    [ProfileTypeID]   INT            NOT NULL,
    [ProfileStatusID] INT            NOT NULL,
    CONSTRAINT [PK_Profile] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Profile_AspNetUsers] FOREIGN KEY ([SecurityID]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK_Profile_ProfileStatus] FOREIGN KEY ([ProfileStatusID]) REFERENCES [dbo].[ProfileStatus] ([Id]),
    CONSTRAINT [FK_Profile_ProfileType] FOREIGN KEY ([ProfileTypeID]) REFERENCES [dbo].[ProfileType] ([ID])
);

