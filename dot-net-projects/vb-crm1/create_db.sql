USE [master]
GO
/****** Object:  Database [db_wiz_wealth]    Script Date: 14/02/2014 04:10:29 ******/
CREATE DATABASE [db_wiz_wealth]
GO
USE [db_wiz_wealth]
GO
/****** Object:  Table [dbo].[tbl_message]    Script Date: 14/02/2014 04:10:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_message](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[message_content] [text] NOT NULL,
	[created_by] [int] NOT NULL,
	[date_created] [datetime] NOT NULL,
	[thread_id] [int] NOT NULL,
 CONSTRAINT [PK_tbl_message] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_thread]    Script Date: 14/02/2014 04:10:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_thread](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[subject] [nvarchar](100) NOT NULL,
	[created_by] [int] NOT NULL,
	[date_created] [datetime] NOT NULL,
	[owner] [int] NOT NULL,
 CONSTRAINT [PK_tbl_thread] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_user]    Script Date: 14/02/2014 04:10:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_user](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nchar](20) NOT NULL,
	[firstmidname] [nchar](20) NOT NULL,
	[lastname] [nchar](20) NOT NULL,
	[email_address] [nchar](100) NOT NULL,
	[password] [nchar](12) NOT NULL,
	[role] [int] NOT NULL,
 CONSTRAINT [PK_tbl_user] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[tbl_thread] ADD  CONSTRAINT [DF_tbl_thread_owner]  DEFAULT ((-1)) FOR [owner]
GO
ALTER TABLE [dbo].[tbl_user] ADD  CONSTRAINT [DF_tbl_user_role]  DEFAULT ((1)) FOR [role]
GO
ALTER TABLE [dbo].[tbl_message]  WITH CHECK ADD  CONSTRAINT [FK_tbl_message_tbl_thread] FOREIGN KEY([thread_id])
REFERENCES [dbo].[tbl_thread] ([id])
GO
ALTER TABLE [dbo].[tbl_message] CHECK CONSTRAINT [FK_tbl_message_tbl_thread]
GO
ALTER TABLE [dbo].[tbl_message]  WITH CHECK ADD  CONSTRAINT [FK_tbl_message_tbl_user] FOREIGN KEY([created_by])
REFERENCES [dbo].[tbl_user] ([id])
GO
ALTER TABLE [dbo].[tbl_message] CHECK CONSTRAINT [FK_tbl_message_tbl_user]
GO
USE [master]
GO
ALTER DATABASE [db_wiz_wealth] SET  READ_WRITE 
GO

/******************* INSERT USER DATA ****************************************/

USE [db_wiz_wealth]
GO

INSERT INTO [db_wiz_wealth].[dbo].[tbl_user]
           (username,firstmidname,lastname,email_address,password,role)
     VALUES ('worker1','Stephen','Smith','worker1@fake-email.com','123',1)
GO

INSERT INTO [db_wiz_wealth].[dbo].[tbl_user]
           (username,firstmidname,lastname,email_address,password,role)
     VALUES ('client1','Jack','Jones','client1@fake-email.com','123',2)
GO

/******************* CREATE USER DEFINED TRIM FUNCTION ***********************/

CREATE FUNCTION dbo.TRIM(@inputString varchar(MAX))
RETURNS varchar(MAX) 
AS 
-- Returns the trimmed string
BEGIN
    DECLARE @strResult varchar(MAX);
	SET @strResult = rtrim(ltrim(@inputString));
    RETURN @strResult;
END;
GO