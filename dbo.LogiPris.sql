CREATE TABLE [dbo].[LogiPris] (
    [LogiPrisID]    INT            IDENTITY (1, 1) NOT NULL,
    [LogiTyp]       NVARCHAR (MAX) NULL,
    [Vecka]         INT            NOT NULL,
    [Dagar]         INT            NOT NULL,
    [Pris]          FLOAT (53)     NOT NULL,
    [LogiID_LogiID] INT            NULL,
    [Period] NCHAR(10) NULL, 
    CONSTRAINT [PK_dbo.LogiPris] PRIMARY KEY CLUSTERED ([LogiPrisID] ASC),
    CONSTRAINT [FK_dbo.LogiPris_dbo.Logi_LogiID_LogiID] FOREIGN KEY ([LogiID_LogiID]) REFERENCES [dbo].[Logi] ([LogiID])
);


GO
CREATE NONCLUSTERED INDEX [IX_LogiID_LogiID]
    ON [dbo].[LogiPris]([LogiID_LogiID] ASC);

