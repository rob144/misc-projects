CREATE TABLE [dbo].[Course] (
    [CourseID]         INT            NOT NULL,
    [Title]            NVARCHAR (MAX) NULL,
    [Credits]          INT            NOT NULL,
    [CourseIDExternal] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.Course] PRIMARY KEY CLUSTERED ([CourseID] ASC)
);

