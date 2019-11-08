USE [sameday01]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 10/9/2019 3:40:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[MiddleName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Address2] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[State] [nvarchar](max) NULL,
	[ZipCode] [nvarchar](max) NULL,
	[BirthDate] [nvarchar](max) NULL,
	[Bio] [nvarchar](max) NULL,
	[IsInContractorMode] [bit] NOT NULL DEFAULT ((0)),
	[IsInCustomerMode] [bit] NOT NULL DEFAULT ((0)),
	[PercentDone] [int] NOT NULL DEFAULT ((0)),
	[Password] [nvarchar](max) NULL,
	[ConfirmPassword] [nvarchar](max) NULL,
	[InfoTabOpen] [nvarchar](max) NULL,
	[JsonProfession] [nvarchar](max) NULL,
	[ProfileImage] [nvarchar](max) NULL,
	[IdImage] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [FirstName], [MiddleName], [LastName], [Address], [Address2], [City], [State], [ZipCode], [BirthDate], [Bio], [IsInContractorMode], [IsInCustomerMode], [PercentDone], [Password], [ConfirmPassword], [InfoTabOpen], [JsonProfession], [ProfileImage], [IdImage]) VALUES (N'2b17cb14-b2e4-4edd-a188-20dfccd390a3', N'CHRISTOPHER.MCCLELLAN@GMAIL.COM', 0, N'AED8pXUxY9JRyWME4LZ7UypMkEGdm5XbaoSRjBnbdLTywJbeZbukhz46z+lZrdU6IQ==', N'9401bfe4-66d1-4f8b-a3bb-c525f779156b', N'5152101215', 0, 0, NULL, 1, 0, N'CHRISTOPHER.MCCLELLAN@GMAIL.COM', N'Christopher', N'M', N'McClellan', NULL, NULL, N'DES MOINES', NULL, N'50320', N'5/5/2019', N'dfg', 1, 0, 20, NULL, NULL, N'1', NULL, NULL, NULL)
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [FirstName], [MiddleName], [LastName], [Address], [Address2], [City], [State], [ZipCode], [BirthDate], [Bio], [IsInContractorMode], [IsInCustomerMode], [PercentDone], [Password], [ConfirmPassword], [InfoTabOpen], [JsonProfession], [ProfileImage], [IdImage]) VALUES (N'bf55fc7e-0f81-4e9c-8f02-ab3ef34e6539', N'jm.millerzconstruction@gmail.com', 0, N'AK2cGzNsL0w4j2lP2IKhUSrH8NDrtxsbeWVpKv+xkDKmzj9pQMJ1NbSNx8vv3dwy0g==', N'03e68540-a653-4e60-849f-adb238301e2b', N'5154479594', 0, 0, NULL, 1, 0, N'jm.millerzconstruction@gmail.com', N'jason', N'wayne', N'miller', N'49 South Street, Box 5', NULL, N'Hartford', N'IA', N'50118', N'05/02/1977', N'owner operator', 0, 0, 20, NULL, NULL, N'1', NULL, NULL, NULL)
GO
