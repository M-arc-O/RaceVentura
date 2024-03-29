﻿CREATE USER RaceVenturaDbUser FOR LOGIN RaceVenturaDbUser;
ALTER ROLE db_datareader ADD MEMBER RaceVenturaDbUser;
ALTER ROLE db_datawriter ADD MEMBER RaceVenturaDbUser;
GRANT UNMASK TO RaceVenturaDbUser;

CREATE TABLE [dbo].[User](
	[Id] [UNIQUEIDENTIFIER] NOT NULL,
	[IdentityProvider] [NVARCHAR](50) NULL,
	[ProviderId] [NVARCHAR](100) NOT NULL,
	[Details] [NVARCHAR](320) NOT NULL
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED
 (
	[Id] ASC
 )
 WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Race](
	[Id] [UNIQUEIDENTIFIER] NOT NULL,
	[UserId] [UNIQUEIDENTIFIER] NOT NULL,
	[Name] [NVARCHAR](100) NOT NULL
 CONSTRAINT [PK_Race] PRIMARY KEY CLUSTERED
 (
	[Id] ASC
 )
 WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Race] ADD CONSTRAINT FK_Race_UserId FOREIGN KEY (UserId) REFERENCES [dbo].[User](Id);
GO
