CREATE TABLE [dbo].[ChangeStatusPending] (
    [id]            INT  IDENTITY (1, 1) NOT NULL,
    [ProfileId]     INT  NULL,
    [CurrentStatus] INT  NULL,
    [NewStatus]     INT  NULL,
    [CreatedOn]     DATE NULL,
    CONSTRAINT [PK_ChangeStatusPending] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_ChangeStatusPending_Profile] FOREIGN KEY ([ProfileId]) REFERENCES [dbo].[Profile] ([Id]),
    CONSTRAINT [FK_ChangeStatusPending_ProfileType] FOREIGN KEY ([NewStatus]) REFERENCES [dbo].[ProfileType] ([ID])
);

