
GO
SET IDENTITY_INSERT [dbo].[AspNetUsers] ON 

GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [IsSuperUser]) VALUES (1, N'senthil@aveoninfotech.com', 0, N'AKiuw12e9MeRFwAQolV0xy5CLg1aVwPfGcDHdLiJvgNNtk2RVHSb4SX+j7GJGnbRuA==', N'a28f35e0-b696-458e-89fc-310230dc0dad', NULL, 0, 0, NULL, 0, 0, N'admin', 0)
GO
SET IDENTITY_INSERT [dbo].[AspNetUsers] OFF
GO
