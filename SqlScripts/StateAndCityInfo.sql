USE [sameday01]
GO
/****** Object:  Table [dbo].[StateAndCityInfo]    Script Date: 10/9/2019 2:49:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StateAndCityInfo](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[State] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[County] [nvarchar](max) NULL,
	[ZipCode] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.StateAndCityInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[StateAndCityInfo] ON 

GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (1, N'Iowa', N'Ackworth', N'Warren', N'50001')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (2, N'Iowa', N'Ackley', N'Hardin', N'50601')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (3, N'Iowa', N'Adair', N'Adair', N'50002')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (4, N'Iowa', N'Adel', N'Dallas', N'50003')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (5, N'Iowa', N'Afton', N'Union', N'50830')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (6, N'Iowa', N'Agency', N'Wapello', N'52530')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (7, N'Iowa', N'Ainsworth', N'Washington', N'52201')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (8, N'Iowa', N'Akron', N'Plymouth', N'51001')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (9, N'Iowa', N'Albert City', N'Buena Vista', N'50510')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (10, N'Iowa', N'Albia', N'Monroe', N'52531')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (11, N'Iowa', N'Albion', N'Marshall', N'50005')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (12, N'Iowa', N'Alburnett', N'Linn', N'52202')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (13, N'Iowa', N'Alden', N'Hardin', N'50006')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (14, N'Iowa', N'Alexander', N'Franklin', N'50420')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (15, N'Iowa', N'Algona', N'Kossuth', N'50511')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (16, N'Iowa', N'Alleman', N'Polk', N'50007')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (17, N'Iowa', N'Allerton', N'Wayne', N'50008')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (18, N'Iowa', N'Allison', N'Butler', N'50602')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (19, N'Iowa', N'Alta', N'Buena Vista', N'51002')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (20, N'Iowa', N'Alta Vista', N'Chickasaw', N'50603')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (21, N'Iowa', N'Alton', N'Sioux', N'51003')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (22, N'Iowa', N'Altoona', N'Polk', N'50009')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (23, N'Iowa', N'Alvord', N'Lyon', N'51230')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (24, N'Iowa', N'Amana', N'Iowa', N'52203')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (25, N'Iowa', N'Amana', N'Iowa', N'52204')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (26, N'Iowa', N'Ames', N'Story', N'50010')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (27, N'Iowa', N'Ames', N'Story', N'50011')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (28, N'Iowa', N'Ames', N'Story', N'50012')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (29, N'Iowa', N'Ames', N'Story', N'50013')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (30, N'Iowa', N'Ames', N'Story', N'50014')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (31, N'Iowa', N'Anamosa', N'Jones', N'52205')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (32, N'Iowa', N'Andover', N'Clinton', N'52701')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (33, N'Iowa', N'Andrew', N'Jackson', N'52030')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (34, N'Iowa', N'Anita', N'Cass', N'50020')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (35, N'Iowa', N'Ankeny', N'Polk', N'50021')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (36, N'Iowa', N'Ankeny', N'Polk', N'50023')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (37, N'Iowa', N'Anthon', N'Woodbury', N'51004')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (38, N'Iowa', N'Aplington', N'Butler', N'50604')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (39, N'Iowa', N'Arcadia', N'Carroll', N'51430')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (40, N'Iowa', N'Archer', N'Obrien', N'51231')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (41, N'Iowa', N'Aredale', N'Butler', N'50605')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (42, N'Iowa', N'Argyle', N'Lee', N'52619')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (43, N'Iowa', N'Arion', N'Crawford', N'51520')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (44, N'Iowa', N'Arispe', N'Union', N'50831')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (45, N'Iowa', N'Arlington', N'Fayette', N'50606')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (46, N'Iowa', N'Armstrong', N'Emmet', N'50514')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (47, N'Iowa', N'Arnolds Park', N'Dickinson', N'51331')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (48, N'Iowa', N'Arthur', N'Ida', N'51431')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (49, N'Iowa', N'Ashton', N'Osceola', N'51232')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (50, N'Iowa', N'Aspinwall', N'Crawford', N'51432')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (51, N'Iowa', N'Atalissa', N'Muscatine', N'52720')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (52, N'Iowa', N'Atkins', N'Benton', N'52206')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (53, N'Iowa', N'Atlantic', N'Cass', N'50022')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (54, N'Iowa', N'Auburn', N'Sac', N'51433')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (55, N'Iowa', N'Audubon', N'Audubon', N'50025')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (56, N'Iowa', N'Aurelia', N'Cherokee', N'51005')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (57, N'Iowa', N'Aurora', N'Buchanan', N'50607')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (58, N'Iowa', N'Austinville', N'Butler', N'50608')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (59, N'Iowa', N'Avoca', N'Pottawattamie', N'51521')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (60, N'Iowa', N'Ayrshire', N'Palo Alto', N'50515')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (61, N'Iowa', N'Badger', N'Webster', N'50516')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (62, N'Iowa', N'Bagley', N'Guthrie', N'50026')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (63, N'Iowa', N'Baldwin', N'Jackson', N'52207')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (64, N'Iowa', N'Bancroft', N'Kossuth', N'50517')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (65, N'Iowa', N'Barnes City', N'Mahaska', N'50027')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (66, N'Iowa', N'Barnum', N'Webster', N'50518')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (67, N'Iowa', N'Batavia', N'Jefferson', N'52533')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (68, N'Iowa', N'Battle Creek', N'Ida', N'51006')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (69, N'Iowa', N'Baxter', N'Jasper', N'50028')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (70, N'Iowa', N'Bayard', N'Guthrie', N'50029')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (71, N'Iowa', N'Beacon', N'Mahaska', N'52534')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (72, N'Iowa', N'Beaman', N'Grundy', N'50609')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (73, N'Iowa', N'Beaver', N'Boone', N'50031')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (74, N'Iowa', N'Bedford', N'Taylor', N'50833')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (75, N'Iowa', N'Belle Plaine', N'Benton', N'52208')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (76, N'Iowa', N'Bellevue', N'Jackson', N'52031')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (77, N'Iowa', N'Belmond', N'Wright', N'50421')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (78, N'Iowa', N'Bennett', N'Cedar', N'52721')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (79, N'Iowa', N'Benton', N'Ringgold', N'50835')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (80, N'Iowa', N'Bernard', N'Dubuque', N'52032')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (81, N'Iowa', N'Berwick', N'Polk', N'50032')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (82, N'Iowa', N'Bettendorf', N'Scott', N'52722')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (83, N'Iowa', N'Bevington', N'Madison', N'50033')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (84, N'Iowa', N'Birmingham', N'Van Buren', N'52535')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (85, N'Iowa', N'Blairsburg', N'Hamilton', N'50034')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (86, N'Iowa', N'Blairstown', N'Benton', N'52209')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (87, N'Iowa', N'Blakesburg', N'Wapello', N'52536')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (88, N'Iowa', N'Blanchard', N'Page', N'51630')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (89, N'Iowa', N'Blencoe', N'Monona', N'51523')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (90, N'Iowa', N'Blockton', N'Taylor', N'50836')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (91, N'Iowa', N'Bloomfield', N'Davis', N'52537')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (92, N'Iowa', N'Blue Grass', N'Scott', N'52726')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (93, N'Iowa', N'Bode', N'Humboldt', N'50519')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (94, N'Iowa', N'Bonaparte', N'Van Buren', N'52620')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (95, N'Iowa', N'Bondurant', N'Polk', N'50035')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (96, N'Iowa', N'Boone', N'Boone', N'50036')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (97, N'Iowa', N'Boone', N'Boone', N'50037')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (98, N'Iowa', N'Booneville', N'Dallas', N'50038')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (99, N'Iowa', N'Bouton', N'Dallas', N'50039')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (100, N'Iowa', N'Boxholm', N'Boone', N'50040')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (101, N'Iowa', N'Boyden', N'Sioux', N'51234')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (102, N'Iowa', N'Braddyville', N'Page', N'51631')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (103, N'Iowa', N'Bradford', N'Franklin', N'50041')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (104, N'Iowa', N'Bradgate', N'Humboldt', N'50520')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (105, N'Iowa', N'Brandon', N'Buchanan', N'52210')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (106, N'Iowa', N'Brayton', N'Audubon', N'50042')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (107, N'Iowa', N'Breda', N'Carroll', N'51436')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (108, N'Iowa', N'Bridgewater', N'Adair', N'50837')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (109, N'Iowa', N'Brighton', N'Washington', N'52540')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (110, N'Iowa', N'Bristow', N'Butler', N'50611')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (111, N'Iowa', N'Britt', N'Hancock', N'50423')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (112, N'Iowa', N'Bronson', N'Woodbury', N'51007')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (113, N'Iowa', N'Brooklyn', N'Poweshiek', N'52211')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (114, N'Iowa', N'Brunsville', N'Plymouth', N'51008')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (115, N'Iowa', N'Bryant', N'Clinton', N'52727')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (116, N'Iowa', N'Buckeye', N'Hardin', N'50043')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (117, N'Iowa', N'Buckingham', N'Tama', N'50612')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (118, N'Iowa', N'Buffalo', N'Scott', N'52728')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (119, N'Iowa', N'Buffalo Center', N'Winnebago', N'50424')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (120, N'Iowa', N'Burlington', N'Des Moines', N'52601')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (121, N'Iowa', N'Burnside', N'Webster', N'50521')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (122, N'Iowa', N'Burt', N'Kossuth', N'50522')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (123, N'Iowa', N'Bussey', N'Marion', N'50044')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (124, N'Iowa', N'Calamus', N'Clinton', N'52729')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (125, N'Iowa', N'Callender', N'Webster', N'50523')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (126, N'Iowa', N'Calmar', N'Winneshiek', N'52132')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (127, N'Iowa', N'Calumet', N'Obrien', N'51009')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (128, N'Iowa', N'Camanche', N'Clinton', N'52730')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (129, N'Iowa', N'Cambridge', N'Story', N'50046')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (130, N'Iowa', N'Cantril', N'Van Buren', N'52542')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (131, N'Iowa', N'Carbon', N'Adams', N'50839')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (132, N'Iowa', N'Carlisle', N'Warren', N'50047')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (133, N'Iowa', N'Carpenter', N'Mitchell', N'50426')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (134, N'Iowa', N'Carroll', N'Carroll', N'51401')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (135, N'Iowa', N'Carson', N'Pottawattamie', N'51525')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (136, N'Iowa', N'Carter Lake', N'Pottawattamie', N'51510')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (137, N'Iowa', N'Cascade', N'Dubuque', N'52033')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (138, N'Iowa', N'Casey', N'Guthrie', N'50048')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (139, N'Iowa', N'Castalia', N'Winneshiek', N'52133')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (140, N'Iowa', N'Castana', N'Monona', N'51010')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (141, N'Iowa', N'Cedar', N'Mahaska', N'52543')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (142, N'Iowa', N'Cedar Falls', N'Black Hawk', N'50613')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (143, N'Iowa', N'Cedar Falls', N'Black Hawk', N'50614')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (144, N'Iowa', N'Cedar Rapids', N'Linn', N'52401')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (145, N'Iowa', N'Cedar Rapids', N'Linn', N'52402')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (146, N'Iowa', N'Cedar Rapids', N'Linn', N'52403')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (147, N'Iowa', N'Cedar Rapids', N'Linn', N'52404')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (148, N'Iowa', N'Cedar Rapids', N'Linn', N'52405')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (149, N'Iowa', N'Cedar Rapids', N'Linn', N'52406')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (150, N'Iowa', N'Cedar Rapids', N'Linn', N'52407')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (151, N'Iowa', N'Cedar Rapids', N'Linn', N'52408')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (152, N'Iowa', N'Cedar Rapids', N'Linn', N'52409')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (153, N'Iowa', N'Cedar Rapids', N'Linn', N'52410')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (154, N'Iowa', N'Cedar Rapids', N'Linn', N'52411')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (155, N'Iowa', N'Cedar Rapids', N'Linn', N'52497')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (156, N'Iowa', N'Cedar Rapids', N'Linn', N'52498')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (157, N'Iowa', N'Cedar Rapids', N'Linn', N'52499')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (158, N'Iowa', N'Center Junction', N'Jones', N'52212')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (159, N'Iowa', N'Center Point', N'Linn', N'52213')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (160, N'Iowa', N'Centerville', N'Appanoose', N'52544')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (161, N'Iowa', N'Central City', N'Linn', N'52214')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (162, N'Iowa', N'Chapin', N'Franklin', N'50427')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (163, N'Iowa', N'Chariton', N'Lucas', N'50049')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (164, N'Iowa', N'Charles City', N'Floyd', N'50616')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (165, N'Iowa', N'Charlotte', N'Clinton', N'52731')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (166, N'Iowa', N'Charter Oak', N'Crawford', N'51439')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (167, N'Iowa', N'Chatsworth', N'Sioux', N'51011')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (168, N'Iowa', N'Chelsea', N'Tama', N'52215')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (169, N'Iowa', N'Cherokee', N'Cherokee', N'51012')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (170, N'Iowa', N'Chester', N'Howard', N'52134')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (171, N'Iowa', N'Chillicothe', N'Wapello', N'52548')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (172, N'Iowa', N'Churdan', N'Greene', N'50050')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (173, N'Iowa', N'Cincinnati', N'Appanoose', N'52549')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (174, N'Iowa', N'Clare', N'Webster', N'50524')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (175, N'Iowa', N'Clarence', N'Cedar', N'52216')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (176, N'Iowa', N'Clarinda', N'Page', N'51632')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (177, N'Iowa', N'Clarion', N'Wright', N'50525')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (178, N'Iowa', N'Clarion', N'Wright', N'50526')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (179, N'Iowa', N'Clarksville', N'Butler', N'50619')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (180, N'Iowa', N'Clear Lake', N'Cerro Gordo', N'50428')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (181, N'Iowa', N'Clearfield', N'Taylor', N'50840')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (182, N'Iowa', N'Cleghorn', N'Cherokee', N'51014')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (183, N'Iowa', N'Clemons', N'Marshall', N'50051')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (184, N'Iowa', N'Clermont', N'Fayette', N'52135')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (185, N'Iowa', N'Climbing Hill', N'Woodbury', N'51015')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (186, N'Iowa', N'Clinton', N'Clinton', N'52732')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (187, N'Iowa', N'Clinton', N'Clinton', N'52733')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (188, N'Iowa', N'Clinton', N'Clinton', N'52734')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (189, N'Iowa', N'Clinton', N'Clinton', N'52736')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (190, N'Iowa', N'Clio', N'Wayne', N'50052')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (191, N'Iowa', N'Clive', N'Polk', N'50325')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (192, N'Iowa', N'Clutier', N'Tama', N'52217')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (193, N'Iowa', N'Coggon', N'Linn', N'52218')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (194, N'Iowa', N'Coin', N'Page', N'51636')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (195, N'Iowa', N'Colesburg', N'Delaware', N'52035')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (196, N'Iowa', N'Colfax', N'Jasper', N'50054')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (197, N'Iowa', N'College Springs', N'Page', N'51637')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (198, N'Iowa', N'Collins', N'Story', N'50055')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (199, N'Iowa', N'Colo', N'Story', N'50056')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (200, N'Iowa', N'Columbia', N'Marion', N'50057')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (201, N'Iowa', N'Columbus City', N'Louisa', N'52737')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (202, N'Iowa', N'Columbus Junction', N'Louisa', N'52738')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (203, N'Iowa', N'Colwell', N'Floyd', N'50620')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (204, N'Iowa', N'Conesville', N'Muscatine', N'52739')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (205, N'Iowa', N'Conrad', N'Grundy', N'50621')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (206, N'Iowa', N'Conroy', N'Iowa', N'52220')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (207, N'Iowa', N'Coon Rapids', N'Carroll', N'50058')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (208, N'Iowa', N'Cooper', N'Greene', N'50059')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (209, N'Iowa', N'Coralville', N'Johnson', N'52241')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (210, N'Iowa', N'Corning', N'Adams', N'50841')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (211, N'Iowa', N'Correctionville', N'Woodbury', N'51016')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (212, N'Iowa', N'Corwith', N'Hancock', N'50430')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (213, N'Iowa', N'Corydon', N'Wayne', N'50060')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (214, N'Iowa', N'Coulter', N'Franklin', N'50431')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (215, N'Iowa', N'Council Bluffs', N'Pottawattamie', N'51501')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (216, N'Iowa', N'Council Bluffs', N'Pottawattamie', N'51502')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (217, N'Iowa', N'Council Bluffs', N'Pottawattamie', N'51503')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (218, N'Iowa', N'Crawfordsville', N'Washington', N'52621')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (219, N'Iowa', N'Crescent', N'Pottawattamie', N'51526')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (220, N'Iowa', N'Cresco', N'Howard', N'52136')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (221, N'Iowa', N'Creston', N'Union', N'50801')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (222, N'Iowa', N'Cromwell', N'Union', N'50842')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (223, N'Iowa', N'Crystal Lake', N'Hancock', N'50432')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (224, N'Iowa', N'Cumberland', N'Cass', N'50843')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (225, N'Iowa', N'Cumming', N'Warren', N'50061')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (226, N'Iowa', N'Curlew', N'Palo Alto', N'50527')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (227, N'Iowa', N'Cushing', N'Woodbury', N'51018')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (228, N'Iowa', N'Cylinder', N'Palo Alto', N'50528')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (229, N'Iowa', N'Dakota City', N'Humboldt', N'50529')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (230, N'Iowa', N'Dallas', N'Marion', N'50062')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (231, N'Iowa', N'Dallas Center', N'Dallas', N'50063')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (232, N'Iowa', N'Dana', N'Greene', N'50064')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (233, N'Iowa', N'Danbury', N'Woodbury', N'51019')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (234, N'Iowa', N'Danville', N'Des Moines', N'52623')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (235, N'Iowa', N'Davenport', N'Scott', N'52801')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (236, N'Iowa', N'Davenport', N'Scott', N'52802')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (237, N'Iowa', N'Davenport', N'Scott', N'52803')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (238, N'Iowa', N'Davenport', N'Scott', N'52804')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (239, N'Iowa', N'Davenport', N'Scott', N'52805')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (240, N'Iowa', N'Davenport', N'Scott', N'52806')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (241, N'Iowa', N'Davenport', N'Scott', N'52807')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (242, N'Iowa', N'Davenport', N'Scott', N'52808')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (243, N'Iowa', N'Davenport', N'Scott', N'52809')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (244, N'Iowa', N'Davis City', N'Decatur', N'50065')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (245, N'Iowa', N'Dawson', N'Dallas', N'50066')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (246, N'Iowa', N'Dayton', N'Webster', N'50530')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (247, N'Iowa', N'De Soto', N'Dallas', N'50069')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (248, N'Iowa', N'De Witt', N'Clinton', N'52742')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (249, N'Iowa', N'Decatur', N'Decatur', N'50067')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (250, N'Iowa', N'Decorah', N'Winneshiek', N'52101')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (251, N'Iowa', N'Dedham', N'Carroll', N'51440')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (252, N'Iowa', N'Deep River', N'Poweshiek', N'52222')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (253, N'Iowa', N'Defiance', N'Shelby', N'51527')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (254, N'Iowa', N'Delaware', N'Delaware', N'52036')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (255, N'Iowa', N'Delhi', N'Delaware', N'52223')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (256, N'Iowa', N'Delmar', N'Clinton', N'52037')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (257, N'Iowa', N'Deloit', N'Crawford', N'51441')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (258, N'Iowa', N'Delta', N'Keokuk', N'52550')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (259, N'Iowa', N'Denison', N'Crawford', N'51442')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (260, N'Iowa', N'Denmark', N'Lee', N'52624')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (261, N'Iowa', N'Denver', N'Bremer', N'50622')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (262, N'Iowa', N'Derby', N'Lucas', N'50068')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (263, N'Iowa', N'Des Moines', N'Polk', N'50301')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (264, N'Iowa', N'Des Moines', N'Polk', N'50302')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (265, N'Iowa', N'Des Moines', N'Polk', N'50303')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (266, N'Iowa', N'Des Moines', N'Polk', N'50304')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (267, N'Iowa', N'Des Moines', N'Polk', N'50305')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (268, N'Iowa', N'Des Moines', N'Polk', N'50306')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (269, N'Iowa', N'Des Moines', N'Polk', N'50307')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (270, N'Iowa', N'Des Moines', N'Polk', N'50308')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (271, N'Iowa', N'Des Moines', N'Polk', N'50309')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (272, N'Iowa', N'Des Moines', N'Polk', N'50310')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (273, N'Iowa', N'Des Moines', N'Polk', N'50311')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (274, N'Iowa', N'Des Moines', N'Polk', N'50312')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (275, N'Iowa', N'Des Moines', N'Polk', N'50313')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (276, N'Iowa', N'Des Moines', N'Polk', N'50314')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (277, N'Iowa', N'Des Moines', N'Polk', N'50315')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (278, N'Iowa', N'Des Moines', N'Polk', N'50316')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (279, N'Iowa', N'Des Moines', N'Polk', N'50317')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (280, N'Iowa', N'Des Moines', N'Polk', N'50318')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (281, N'Iowa', N'Des Moines', N'Polk', N'50319')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (282, N'Iowa', N'Des Moines', N'Polk', N'50320')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (283, N'Iowa', N'Des Moines', N'Polk', N'50321')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (284, N'Iowa', N'Des Moines', N'Polk', N'50327')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (285, N'Iowa', N'Des Moines', N'Polk', N'50328')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (286, N'Iowa', N'Des Moines', N'Polk', N'50329')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (287, N'Iowa', N'Des Moines', N'Polk', N'50330')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (288, N'Iowa', N'Des Moines', N'Polk', N'50331')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (289, N'Iowa', N'Des Moines', N'Polk', N'50332')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (290, N'Iowa', N'Des Moines', N'Polk', N'50333')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (291, N'Iowa', N'Des Moines', N'Polk', N'50334')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (292, N'Iowa', N'Des Moines', N'Polk', N'50335')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (293, N'Iowa', N'Des Moines', N'Polk', N'50336')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (294, N'Iowa', N'Des Moines', N'Polk', N'50339')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (295, N'Iowa', N'Des Moines', N'Polk', N'50340')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (296, N'Iowa', N'Des Moines', N'Polk', N'50347')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (297, N'Iowa', N'Des Moines', N'Polk', N'50350')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (298, N'Iowa', N'Des Moines', N'Polk', N'50359')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (299, N'Iowa', N'Des Moines', N'Polk', N'50360')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (300, N'Iowa', N'Des Moines', N'Polk', N'50361')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (301, N'Iowa', N'Des Moines', N'Polk', N'50362')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (302, N'Iowa', N'Des Moines', N'Polk', N'50363')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (303, N'Iowa', N'Des Moines', N'Polk', N'50364')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (304, N'Iowa', N'Des Moines', N'Polk', N'50367')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (305, N'Iowa', N'Des Moines', N'Polk', N'50368')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (306, N'Iowa', N'Des Moines', N'Polk', N'50369')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (307, N'Iowa', N'Des Moines', N'Polk', N'50380')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (308, N'Iowa', N'Des Moines', N'Polk', N'50381')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (309, N'Iowa', N'Des Moines', N'Polk', N'50391')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (310, N'Iowa', N'Des Moines', N'Polk', N'50392')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (311, N'Iowa', N'Des Moines', N'Polk', N'50393')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (312, N'Iowa', N'Des Moines', N'Polk', N'50394')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (313, N'Iowa', N'Des Moines', N'Polk', N'50395')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (314, N'Iowa', N'Des Moines', N'Polk', N'50396')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (315, N'Iowa', N'Des Moines', N'Polk', N'50397')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (316, N'Iowa', N'Des Moines', N'Polk', N'50936')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (317, N'Iowa', N'Des Moines', N'Polk', N'50940')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (318, N'Iowa', N'Des Moines', N'Polk', N'50947')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (319, N'Iowa', N'Des Moines', N'Polk', N'50950')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (320, N'Iowa', N'Des Moines', N'Polk', N'50980')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (321, N'Iowa', N'Des Moines', N'Polk', N'50981')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (322, N'Iowa', N'Dewar', N'Black Hawk', N'50623')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (323, N'Iowa', N'Dexter', N'Dallas', N'50070')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (324, N'Iowa', N'Diagonal', N'Ringgold', N'50845')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (325, N'Iowa', N'Dickens', N'Clay', N'51333')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (326, N'Iowa', N'Dike', N'Grundy', N'50624')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (327, N'Iowa', N'Dixon', N'Scott', N'52745')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (328, N'Iowa', N'Dolliver', N'Emmet', N'50531')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (329, N'Iowa', N'Donahue', N'Scott', N'52746')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (330, N'Iowa', N'Donnellson', N'Lee', N'52625')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (331, N'Iowa', N'Doon', N'Lyon', N'51235')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (332, N'Iowa', N'Dorchester', N'Allamakee', N'52140')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (333, N'Iowa', N'Douds', N'Van Buren', N'52551')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (334, N'Iowa', N'Dougherty', N'Cerro Gordo', N'50433')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (335, N'Iowa', N'Dow City', N'Crawford', N'51528')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (336, N'Iowa', N'Dows', N'Wright', N'50071')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (337, N'Iowa', N'Drakesville', N'Davis', N'52552')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (338, N'Iowa', N'Dubuque', N'Dubuque', N'52001')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (339, N'Iowa', N'Dubuque', N'Dubuque', N'52002')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (340, N'Iowa', N'Dubuque', N'Dubuque', N'52003')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (341, N'Iowa', N'Dubuque', N'Dubuque', N'52004')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (342, N'Iowa', N'Dubuque', N'Dubuque', N'52099')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (343, N'Iowa', N'Dumont', N'Butler', N'50625')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (344, N'Iowa', N'Duncombe', N'Webster', N'50532')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (345, N'Iowa', N'Dundee', N'Delaware', N'52038')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (346, N'Iowa', N'Dunkerton', N'Black Hawk', N'50626')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (347, N'Iowa', N'Dunlap', N'Harrison', N'51529')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (348, N'Iowa', N'Durango', N'Dubuque', N'52039')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (349, N'Iowa', N'Durant', N'Cedar', N'52747')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (350, N'Iowa', N'Dyersville', N'Dubuque', N'52040')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (351, N'Iowa', N'Dysart', N'Tama', N'52224')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (352, N'Iowa', N'Eagle Grove', N'Wright', N'50533')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (353, N'Iowa', N'Earlham', N'Madison', N'50072')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (354, N'Iowa', N'Earling', N'Shelby', N'51530')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (355, N'Iowa', N'Earlville', N'Delaware', N'52041')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (356, N'Iowa', N'Early', N'Sac', N'50535')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (357, N'Iowa', N'Eddyville', N'Wapello', N'52553')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (358, N'Iowa', N'Edgewood', N'Clayton', N'52042')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (359, N'Iowa', N'Elberon', N'Tama', N'52225')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (360, N'Iowa', N'Eldon', N'Wapello', N'52554')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (361, N'Iowa', N'Eldora', N'Hardin', N'50627')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (362, N'Iowa', N'Eldridge', N'Scott', N'52748')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (363, N'Iowa', N'Elgin', N'Fayette', N'52141')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (364, N'Iowa', N'Elk Horn', N'Shelby', N'51531')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (365, N'Iowa', N'Elkader', N'Clayton', N'52043')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (366, N'Iowa', N'Elkhart', N'Polk', N'50073')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (367, N'Iowa', N'Elkport', N'Clayton', N'52044')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (368, N'Iowa', N'Elliott', N'Montgomery', N'51532')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (369, N'Iowa', N'Ellston', N'Ringgold', N'50074')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (370, N'Iowa', N'Ellsworth', N'Hamilton', N'50075')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (371, N'Iowa', N'Elma', N'Howard', N'50628')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (372, N'Iowa', N'Ely', N'Linn', N'52227')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (373, N'Iowa', N'Emerson', N'Mills', N'51533')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (374, N'Iowa', N'Emmetsburg', N'Palo Alto', N'50536')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (375, N'Iowa', N'Epworth', N'Dubuque', N'52045')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (376, N'Iowa', N'Essex', N'Page', N'51638')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (377, N'Iowa', N'Estherville', N'Emmet', N'51334')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (378, N'Iowa', N'Evansdale', N'Black Hawk', N'50707')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (379, N'Iowa', N'Everly', N'Clay', N'51338')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (380, N'Iowa', N'Exira', N'Audubon', N'50076')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (381, N'Iowa', N'Exline', N'Appanoose', N'52555')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (382, N'Iowa', N'Fairbank', N'Buchanan', N'50629')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (383, N'Iowa', N'Fairfax', N'Linn', N'52228')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (384, N'Iowa', N'Fairfield', N'Jefferson', N'52556')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (385, N'Iowa', N'Fairfield', N'Jefferson', N'52557')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (386, N'Iowa', N'Farley', N'Dubuque', N'52046')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (387, N'Iowa', N'Farmersburg', N'Clayton', N'52047')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (388, N'Iowa', N'Farmington', N'Van Buren', N'52626')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (389, N'Iowa', N'Farnhamville', N'Calhoun', N'50538')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (390, N'Iowa', N'Farragut', N'Fremont', N'51639')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (391, N'Iowa', N'Fayette', N'Fayette', N'52142')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (392, N'Iowa', N'Fenton', N'Kossuth', N'50539')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (393, N'Iowa', N'Ferguson', N'Marshall', N'50078')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (394, N'Iowa', N'Fertile', N'Worth', N'50434')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (395, N'Iowa', N'Floris', N'Davis', N'52560')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (396, N'Iowa', N'Floyd', N'Floyd', N'50435')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (397, N'Iowa', N'Fonda', N'Pocahontas', N'50540')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (398, N'Iowa', N'Fontanelle', N'Adair', N'50846')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (399, N'Iowa', N'Forest City', N'Winnebago', N'50436')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (400, N'Iowa', N'Fort Atkinson', N'Winneshiek', N'52144')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (401, N'Iowa', N'Fort Dodge', N'Webster', N'50501')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (402, N'Iowa', N'Fort Madison', N'Lee', N'52627')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (403, N'Iowa', N'Fostoria', N'Clay', N'51340')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (404, N'Iowa', N'Fredericksburg', N'Chickasaw', N'50630')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (405, N'Iowa', N'Frederika', N'Bremer', N'50631')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (406, N'Iowa', N'Fremont', N'Mahaska', N'52561')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (407, N'Iowa', N'Fruitland', N'Muscatine', N'52749')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (408, N'Iowa', N'Galt', N'Wright', N'50101')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (409, N'Iowa', N'Galva', N'Ida', N'51020')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (410, N'Iowa', N'Garber', N'Clayton', N'52048')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (411, N'Iowa', N'Garden City', N'Hardin', N'50102')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (412, N'Iowa', N'Garden Grove', N'Decatur', N'50103')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (413, N'Iowa', N'Garnavillo', N'Clayton', N'52049')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (414, N'Iowa', N'Garner', N'Hancock', N'50438')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (415, N'Iowa', N'Garrison', N'Benton', N'52229')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (416, N'Iowa', N'Garwin', N'Tama', N'50632')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (417, N'Iowa', N'Geneva', N'Franklin', N'50633')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (418, N'Iowa', N'George', N'Lyon', N'51237')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (419, N'Iowa', N'Gibson', N'Keokuk', N'50104')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (420, N'Iowa', N'Gifford', N'Hardin', N'50259')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (421, N'Iowa', N'Gilbert', N'Story', N'50105')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (422, N'Iowa', N'Gilbertville', N'Black Hawk', N'50634')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (423, N'Iowa', N'Gillett Grove', N'Clay', N'51341')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (424, N'Iowa', N'Gilman', N'Marshall', N'50106')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (425, N'Iowa', N'Gilmore City', N'Humboldt', N'50541')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (426, N'Iowa', N'Gladbrook', N'Tama', N'50635')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (427, N'Iowa', N'Glenwood', N'Mills', N'51534')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (428, N'Iowa', N'Glidden', N'Carroll', N'51443')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (429, N'Iowa', N'Goldfield', N'Wright', N'50542')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (430, N'Iowa', N'Goodell', N'Hancock', N'50439')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (431, N'Iowa', N'Goose Lake', N'Clinton', N'52750')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (432, N'Iowa', N'Gowrie', N'Webster', N'50543')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (433, N'Iowa', N'Graettinger', N'Palo Alto', N'51342')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (434, N'Iowa', N'Grafton', N'Worth', N'50440')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (435, N'Iowa', N'Grand Junction', N'Greene', N'50107')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (436, N'Iowa', N'Grand Mound', N'Clinton', N'52751')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (437, N'Iowa', N'Grand River', N'Decatur', N'50108')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (438, N'Iowa', N'Grandview', N'Louisa', N'52752')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (439, N'Iowa', N'Granger', N'Dallas', N'50109')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (440, N'Iowa', N'Grant', N'Montgomery', N'50847')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (441, N'Iowa', N'Granville', N'Sioux', N'51022')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (442, N'Iowa', N'Gravity', N'Taylor', N'50848')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (443, N'Iowa', N'Gray', N'Audubon', N'50110')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (444, N'Iowa', N'Greeley', N'Delaware', N'52050')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (445, N'Iowa', N'Greene', N'Butler', N'50636')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (446, N'Iowa', N'Greenfield', N'Adair', N'50849')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (447, N'Iowa', N'Greenville', N'Clay', N'51343')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (448, N'Iowa', N'Grimes', N'Polk', N'50111')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (449, N'Iowa', N'Grinnell', N'Poweshiek', N'50112')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (450, N'Iowa', N'Griswold', N'Cass', N'51535')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (451, N'Iowa', N'Grundy Center', N'Grundy', N'50638')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (452, N'Iowa', N'Gruver', N'Emmet', N'51344')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (453, N'Iowa', N'Guernsey', N'Poweshiek', N'52221')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (454, N'Iowa', N'Guthrie Center', N'Guthrie', N'50115')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (455, N'Iowa', N'Guttenberg', N'Clayton', N'52052')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (456, N'Iowa', N'Halbur', N'Carroll', N'51444')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (457, N'Iowa', N'Hamburg', N'Fremont', N'51640')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (458, N'Iowa', N'Hamilton', N'Marion', N'50116')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (459, N'Iowa', N'Hamlin', N'Audubon', N'50117')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (460, N'Iowa', N'Hampton', N'Franklin', N'50441')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (461, N'Iowa', N'Hancock', N'Pottawattamie', N'51536')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (462, N'Iowa', N'Hanlontown', N'Worth', N'50444')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (463, N'Iowa', N'Harcourt', N'Webster', N'50544')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (464, N'Iowa', N'Hardy', N'Humboldt', N'50545')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (465, N'Iowa', N'Harlan', N'Shelby', N'51537')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (466, N'Iowa', N'Harlan', N'Shelby', N'51593')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (467, N'Iowa', N'Harper', N'Keokuk', N'52231')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (468, N'Iowa', N'Harpers Ferry', N'Allamakee', N'52146')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (469, N'Iowa', N'Harris', N'Osceola', N'51345')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (470, N'Iowa', N'Hartford', N'Warren', N'50118')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (471, N'Iowa', N'Hartley', N'Obrien', N'51346')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (472, N'Iowa', N'Hartwick', N'Poweshiek', N'52232')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (473, N'Iowa', N'Harvey', N'Marion', N'50119')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (474, N'Iowa', N'Hastings', N'Mills', N'51540')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (475, N'Iowa', N'Havelock', N'Pocahontas', N'50546')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (476, N'Iowa', N'Haverhill', N'Marshall', N'50120')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (477, N'Iowa', N'Hawarden', N'Sioux', N'51023')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (478, N'Iowa', N'Hawkeye', N'Fayette', N'52147')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (479, N'Iowa', N'Hayesville', N'Keokuk', N'52562')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (480, N'Iowa', N'Hazleton', N'Buchanan', N'50641')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (481, N'Iowa', N'Hedrick', N'Keokuk', N'52563')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (482, N'Iowa', N'Henderson', N'Mills', N'51541')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (483, N'Iowa', N'Hiawatha', N'Linn', N'52233')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (484, N'Iowa', N'Highlandville', N'Winneshiek', N'52149')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (485, N'Iowa', N'Hills', N'Johnson', N'52235')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (486, N'Iowa', N'Hillsboro', N'Henry', N'52630')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (487, N'Iowa', N'Hinton', N'Plymouth', N'51024')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (488, N'Iowa', N'Holland', N'Grundy', N'50642')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (489, N'Iowa', N'Holstein', N'Ida', N'51025')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (490, N'Iowa', N'Holy Cross', N'Dubuque', N'52053')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (491, N'Iowa', N'Homestead', N'Iowa', N'52236')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (492, N'Iowa', N'Honey Creek', N'Pottawattamie', N'51542')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (493, N'Iowa', N'Hopkinton', N'Delaware', N'52237')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (494, N'Iowa', N'Hornick', N'Woodbury', N'51026')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (495, N'Iowa', N'Hospers', N'Sioux', N'51238')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (496, N'Iowa', N'Houghton', N'Lee', N'52631')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (497, N'Iowa', N'Hubbard', N'Hardin', N'50122')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (498, N'Iowa', N'Hudson', N'Black Hawk', N'50643')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (499, N'Iowa', N'Hull', N'Sioux', N'51239')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (500, N'Iowa', N'Humboldt', N'Humboldt', N'50548')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (501, N'Iowa', N'Humeston', N'Wayne', N'50123')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (502, N'Iowa', N'Huxley', N'Story', N'50124')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (503, N'Iowa', N'Ida Grove', N'Ida', N'51445')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (504, N'Iowa', N'Imogene', N'Fremont', N'51645')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (505, N'Iowa', N'Independence', N'Buchanan', N'50644')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (506, N'Iowa', N'Indianola', N'Warren', N'50125')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (507, N'Iowa', N'Inwood', N'Lyon', N'51240')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (508, N'Iowa', N'Ionia', N'Chickasaw', N'50645')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (509, N'Iowa', N'Iowa City', N'Johnson', N'52240')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (510, N'Iowa', N'Iowa City', N'Johnson', N'52242')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (511, N'Iowa', N'Iowa City', N'Johnson', N'52243')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (512, N'Iowa', N'Iowa City', N'Johnson', N'52244')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (513, N'Iowa', N'Iowa City', N'Johnson', N'52245')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (514, N'Iowa', N'Iowa City', N'Johnson', N'52246')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (515, N'Iowa', N'Iowa Falls', N'Hardin', N'50126')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (516, N'Iowa', N'Ira', N'Jasper', N'50127')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (517, N'Iowa', N'Ireton', N'Sioux', N'51027')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (518, N'Iowa', N'Irwin', N'Shelby', N'51446')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (519, N'Iowa', N'Jamaica', N'Guthrie', N'50128')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (520, N'Iowa', N'Janesville', N'Bremer', N'50647')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (521, N'Iowa', N'Jefferson', N'Greene', N'50129')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (522, N'Iowa', N'Jesup', N'Buchanan', N'50648')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (523, N'Iowa', N'Jewell', N'Hamilton', N'50130')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (524, N'Iowa', N'Johnston', N'Polk', N'50131')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (525, N'Iowa', N'Joice', N'Worth', N'50446')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (526, N'Iowa', N'Jolley', N'Calhoun', N'50551')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (527, N'Iowa', N'Kalona', N'Washington', N'52247')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (528, N'Iowa', N'Kamrar', N'Hamilton', N'50132')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (529, N'Iowa', N'Kanawha', N'Hancock', N'50447')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (530, N'Iowa', N'Kellerton', N'Ringgold', N'50133')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (531, N'Iowa', N'Kelley', N'Story', N'50134')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (532, N'Iowa', N'Kellogg', N'Jasper', N'50135')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (533, N'Iowa', N'Kensett', N'Worth', N'50448')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (534, N'Iowa', N'Keokuk', N'Lee', N'52632')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (535, N'Iowa', N'Keosauqua', N'Van Buren', N'52565')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (536, N'Iowa', N'Keota', N'Keokuk', N'52248')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (537, N'Iowa', N'Kesley', N'Butler', N'50649')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (538, N'Iowa', N'Keswick', N'Keokuk', N'50136')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (539, N'Iowa', N'Keystone', N'Benton', N'52249')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (540, N'Iowa', N'Killduff', N'Jasper', N'50137')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (541, N'Iowa', N'Kimballton', N'Audubon', N'51543')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (542, N'Iowa', N'Kingsley', N'Plymouth', N'51028')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (543, N'Iowa', N'Kirkman', N'Shelby', N'51447')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (544, N'Iowa', N'Kirkville', N'Wapello', N'52566')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (545, N'Iowa', N'Kiron', N'Crawford', N'51448')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (546, N'Iowa', N'Klemme', N'Hancock', N'50449')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (547, N'Iowa', N'Knierim', N'Calhoun', N'50552')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (548, N'Iowa', N'Knoxville', N'Marion', N'50138')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (549, N'Iowa', N'La Motte', N'Jackson', N'52054')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (550, N'Iowa', N'La Porte City', N'Black Hawk', N'50651')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (551, N'Iowa', N'Lacona', N'Warren', N'50139')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (552, N'Iowa', N'Ladora', N'Iowa', N'52251')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (553, N'Iowa', N'Lake City', N'Calhoun', N'51449')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (554, N'Iowa', N'Lake Mills', N'Winnebago', N'50450')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (555, N'Iowa', N'Lake Park', N'Dickinson', N'51347')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (556, N'Iowa', N'Lake View', N'Sac', N'51450')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (557, N'Iowa', N'Lakota', N'Kossuth', N'50451')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (558, N'Iowa', N'Lamoni', N'Decatur', N'50140')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (559, N'Iowa', N'Lamont', N'Buchanan', N'50650')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (560, N'Iowa', N'Lanesboro', N'Carroll', N'51451')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (561, N'Iowa', N'Langworthy', N'Jones', N'52252')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (562, N'Iowa', N'Lansing', N'Allamakee', N'52151')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (563, N'Iowa', N'Larchwood', N'Lyon', N'51241')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (564, N'Iowa', N'Larrabee', N'Cherokee', N'51029')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (565, N'Iowa', N'Latimer', N'Franklin', N'50452')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (566, N'Iowa', N'Laurel', N'Marshall', N'50141')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (567, N'Iowa', N'Laurens', N'Pocahontas', N'50554')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (568, N'Iowa', N'Lawler', N'Chickasaw', N'52154')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (569, N'Iowa', N'Lawton', N'Woodbury', N'51030')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (570, N'Iowa', N'Le Claire', N'Scott', N'52753')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (571, N'Iowa', N'Le Grand', N'Marshall', N'50142')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (572, N'Iowa', N'Le Mars', N'Plymouth', N'51031')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (573, N'Iowa', N'Ledyard', N'Kossuth', N'50556')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (574, N'Iowa', N'Lehigh', N'Webster', N'50557')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (575, N'Iowa', N'Leighton', N'Mahaska', N'50143')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (576, N'Iowa', N'Leland', N'Winnebago', N'50453')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (577, N'Iowa', N'Lenox', N'Taylor', N'50851')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (578, N'Iowa', N'Leon', N'Decatur', N'50144')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (579, N'Iowa', N'Lester', N'Lyon', N'51242')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (580, N'Iowa', N'Letts', N'Louisa', N'52754')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (581, N'Iowa', N'Lewis', N'Cass', N'51544')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (582, N'Iowa', N'Liberty Center', N'Warren', N'50145')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (583, N'Iowa', N'Libertyville', N'Jefferson', N'52567')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (584, N'Iowa', N'Lidderdale', N'Carroll', N'51452')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (585, N'Iowa', N'Lime Springs', N'Howard', N'52155')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (586, N'Iowa', N'Lincoln', N'Tama', N'50652')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (587, N'Iowa', N'Linden', N'Dallas', N'50146')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (588, N'Iowa', N'Lineville', N'Wayne', N'50147')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (589, N'Iowa', N'Linn Grove', N'Buena Vista', N'51033')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (590, N'Iowa', N'Lisbon', N'Linn', N'52253')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (591, N'Iowa', N'Liscomb', N'Marshall', N'50148')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (592, N'Iowa', N'Little Cedar', N'Mitchell', N'50454')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (593, N'Iowa', N'Little Rock', N'Lyon', N'51243')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (594, N'Iowa', N'Little Sioux', N'Harrison', N'51545')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (595, N'Iowa', N'Livermore', N'Humboldt', N'50558')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (596, N'Iowa', N'Lockridge', N'Jefferson', N'52635')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (597, N'Iowa', N'Logan', N'Harrison', N'51546')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (598, N'Iowa', N'Lohrville', N'Calhoun', N'51453')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (599, N'Iowa', N'Lone Rock', N'Kossuth', N'50559')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (600, N'Iowa', N'Lone Tree', N'Johnson', N'52755')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (601, N'Iowa', N'Long Grove', N'Scott', N'52756')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (602, N'Iowa', N'Lorimor', N'Union', N'50149')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (603, N'Iowa', N'Lost Nation', N'Clinton', N'52254')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (604, N'Iowa', N'Lovilia', N'Monroe', N'50150')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (605, N'Iowa', N'Low Moor', N'Clinton', N'52757')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (606, N'Iowa', N'Lowden', N'Cedar', N'52255')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (607, N'Iowa', N'Lu Verne', N'Kossuth', N'50560')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (608, N'Iowa', N'Luana', N'Clayton', N'52156')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (609, N'Iowa', N'Lucas', N'Lucas', N'50151')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (610, N'Iowa', N'Luther', N'Boone', N'50152')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (611, N'Iowa', N'Luxemburg', N'Dubuque', N'52056')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (612, N'Iowa', N'Luzerne', N'Benton', N'52257')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (613, N'Iowa', N'Lynnville', N'Jasper', N'50153')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (614, N'Iowa', N'Lytton', N'Calhoun', N'50561')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (615, N'Iowa', N'Macedonia', N'Pottawattamie', N'51549')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (616, N'Iowa', N'Macksburg', N'Madison', N'50155')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (617, N'Iowa', N'Madrid', N'Boone', N'50156')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (618, N'Iowa', N'Magnolia', N'Harrison', N'51550')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (619, N'Iowa', N'Malcom', N'Poweshiek', N'50157')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (620, N'Iowa', N'Mallard', N'Palo Alto', N'50562')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (621, N'Iowa', N'Malvern', N'Mills', N'51551')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (622, N'Iowa', N'Manchester', N'Delaware', N'52057')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (623, N'Iowa', N'Manilla', N'Crawford', N'51454')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (624, N'Iowa', N'Manly', N'Worth', N'50456')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (625, N'Iowa', N'Manning', N'Carroll', N'51455')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (626, N'Iowa', N'Manson', N'Calhoun', N'50563')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (627, N'Iowa', N'Mapleton', N'Monona', N'51034')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (628, N'Iowa', N'Maquoketa', N'Jackson', N'52060')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (629, N'Iowa', N'Marathon', N'Buena Vista', N'50565')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (630, N'Iowa', N'Marble Rock', N'Floyd', N'50653')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (631, N'Iowa', N'Marcus', N'Cherokee', N'51035')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (632, N'Iowa', N'Marengo', N'Iowa', N'52301')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (633, N'Iowa', N'Marion', N'Linn', N'52302')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (634, N'Iowa', N'Marne', N'Cass', N'51552')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (635, N'Iowa', N'Marquette', N'Clayton', N'52158')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (636, N'Iowa', N'Marshalltown', N'Marshall', N'50158')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (637, N'Iowa', N'Martelle', N'Jones', N'52305')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (638, N'Iowa', N'Martensdale', N'Warren', N'50160')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (639, N'Iowa', N'Martinsburg', N'Keokuk', N'52568')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (640, N'Iowa', N'Mason City', N'Cerro Gordo', N'50401')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (641, N'Iowa', N'Mason City', N'Cerro Gordo', N'50402')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (642, N'Iowa', N'Masonville', N'Delaware', N'50654')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (643, N'Iowa', N'Massena', N'Cass', N'50853')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (644, N'Iowa', N'Matlock', N'Sioux', N'51244')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (645, N'Iowa', N'Maurice', N'Sioux', N'51036')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (646, N'Iowa', N'Maxwell', N'Story', N'50161')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (647, N'Iowa', N'Maynard', N'Fayette', N'50655')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (648, N'Iowa', N'Mc Callsburg', N'Story', N'50154')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (649, N'Iowa', N'Mc Causland', N'Scott', N'52758')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (650, N'Iowa', N'Mc Clelland', N'Pottawattamie', N'51548')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (651, N'Iowa', N'Mc Gregor', N'Clayton', N'52157')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (652, N'Iowa', N'Mc Intire', N'Mitchell', N'50455')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (653, N'Iowa', N'Mechanicsville', N'Cedar', N'52306')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (654, N'Iowa', N'Mediapolis', N'Des Moines', N'52637')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (655, N'Iowa', N'Melbourne', N'Marshall', N'50162')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (656, N'Iowa', N'Melcher', N'Marion', N'50163')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (657, N'Iowa', N'Melrose', N'Monroe', N'52569')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (658, N'Iowa', N'Melvin', N'Osceola', N'51350')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (659, N'Iowa', N'Menlo', N'Guthrie', N'50164')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (660, N'Iowa', N'Meriden', N'Cherokee', N'51037')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (661, N'Iowa', N'Merrill', N'Plymouth', N'51038')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (662, N'Iowa', N'Meservey', N'Cerro Gordo', N'50457')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (663, N'Iowa', N'Middle Amana', N'Iowa', N'52307')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (664, N'Iowa', N'Middletown', N'Des Moines', N'52638')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (665, N'Iowa', N'Miles', N'Jackson', N'52064')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (666, N'Iowa', N'Milford', N'Dickinson', N'51351')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (667, N'Iowa', N'Millersburg', N'Iowa', N'52308')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (668, N'Iowa', N'Millerton', N'Wayne', N'50165')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (669, N'Iowa', N'Milo', N'Warren', N'50166')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (670, N'Iowa', N'Milton', N'Van Buren', N'52570')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (671, N'Iowa', N'Minburn', N'Dallas', N'50167')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (672, N'Iowa', N'Minden', N'Pottawattamie', N'51553')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (673, N'Iowa', N'Mineola', N'Mills', N'51554')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (674, N'Iowa', N'Mingo', N'Jasper', N'50168')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (675, N'Iowa', N'Missouri Valley', N'Harrison', N'51555')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (676, N'Iowa', N'Mitchellville', N'Polk', N'50169')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (677, N'Iowa', N'Modale', N'Harrison', N'51556')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (678, N'Iowa', N'Mondamin', N'Harrison', N'51557')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (679, N'Iowa', N'Monmouth', N'Jackson', N'52309')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (680, N'Iowa', N'Monona', N'Clayton', N'52159')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (681, N'Iowa', N'Monroe', N'Jasper', N'50170')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (682, N'Iowa', N'Montezuma', N'Poweshiek', N'50171')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (683, N'Iowa', N'Monticello', N'Jones', N'52310')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (684, N'Iowa', N'Montour', N'Tama', N'50173')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (685, N'Iowa', N'Montpelier', N'Muscatine', N'52759')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (686, N'Iowa', N'Montrose', N'Lee', N'52639')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (687, N'Iowa', N'Moorhead', N'Monona', N'51558')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (688, N'Iowa', N'Moorland', N'Webster', N'50566')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (689, N'Iowa', N'Moravia', N'Appanoose', N'52571')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (690, N'Iowa', N'Morley', N'Jones', N'52312')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (691, N'Iowa', N'Morning Sun', N'Louisa', N'52640')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (692, N'Iowa', N'Morrison', N'Grundy', N'50657')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (693, N'Iowa', N'Moscow', N'Muscatine', N'52760')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (694, N'Iowa', N'Moulton', N'Appanoose', N'52572')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (695, N'Iowa', N'Mount Auburn', N'Benton', N'52313')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (696, N'Iowa', N'Mount Ayr', N'Ringgold', N'50854')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (697, N'Iowa', N'Mount Pleasant', N'Henry', N'52641')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (698, N'Iowa', N'Mount Sterling', N'Van Buren', N'52573')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (699, N'Iowa', N'Mount Union', N'Henry', N'52644')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (700, N'Iowa', N'Mount Vernon', N'Linn', N'52314')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (701, N'Iowa', N'Moville', N'Woodbury', N'51039')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (702, N'Iowa', N'Murray', N'Clarke', N'50174')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (703, N'Iowa', N'Muscatine', N'Muscatine', N'52761')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (704, N'Iowa', N'Mystic', N'Appanoose', N'52574')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (705, N'Iowa', N'Nashua', N'Chickasaw', N'50658')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (706, N'Iowa', N'Nemaha', N'Sac', N'50567')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (707, N'Iowa', N'Neola', N'Pottawattamie', N'51559')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (708, N'Iowa', N'Nevada', N'Story', N'50201')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (709, N'Iowa', N'New Albin', N'Allamakee', N'52160')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (710, N'Iowa', N'New Hampton', N'Chickasaw', N'50659')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (711, N'Iowa', N'New Hartford', N'Butler', N'50660')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (712, N'Iowa', N'New Liberty', N'Scott', N'52765')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (713, N'Iowa', N'New London', N'Henry', N'52645')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (714, N'Iowa', N'New Market', N'Taylor', N'51646')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (715, N'Iowa', N'New Providence', N'Hardin', N'50206')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (716, N'Iowa', N'New Sharon', N'Mahaska', N'50207')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (717, N'Iowa', N'New Vienna', N'Dubuque', N'52065')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (718, N'Iowa', N'New Virginia', N'Warren', N'50210')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (719, N'Iowa', N'Newell', N'Buena Vista', N'50568')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (720, N'Iowa', N'Newhall', N'Benton', N'52315')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (721, N'Iowa', N'Newton', N'Jasper', N'50208')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (722, N'Iowa', N'Nichols', N'Muscatine', N'52766')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (723, N'Iowa', N'Nodaway', N'Adams', N'50857')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (724, N'Iowa', N'Nora Springs', N'Floyd', N'50458')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (725, N'Iowa', N'North Buena Vista', N'Clayton', N'52066')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (726, N'Iowa', N'North English', N'Iowa', N'52316')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (727, N'Iowa', N'North Liberty', N'Johnson', N'52317')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (728, N'Iowa', N'North Washington', N'Chickasaw', N'50661')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (729, N'Iowa', N'Northboro', N'Page', N'51647')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (730, N'Iowa', N'Northwood', N'Worth', N'50459')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (731, N'Iowa', N'Norwalk', N'Warren', N'50211')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (732, N'Iowa', N'Norway', N'Benton', N'52318')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (733, N'Iowa', N'Oakdale', N'Johnson', N'52319')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (734, N'Iowa', N'Oakland', N'Pottawattamie', N'51560')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (735, N'Iowa', N'Oakville', N'Louisa', N'52646')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (736, N'Iowa', N'Ocheyedan', N'Osceola', N'51354')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (737, N'Iowa', N'Odebolt', N'Sac', N'51458')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (738, N'Iowa', N'Oelwein', N'Fayette', N'50662')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (739, N'Iowa', N'Ogden', N'Boone', N'50212')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (740, N'Iowa', N'Okoboji', N'Dickinson', N'51355')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (741, N'Iowa', N'Olds', N'Henry', N'52647')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (742, N'Iowa', N'Olin', N'Jones', N'52320')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (743, N'Iowa', N'Ollie', N'Keokuk', N'52576')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (744, N'Iowa', N'Onawa', N'Monona', N'51040')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (745, N'Iowa', N'Onslow', N'Jones', N'52321')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (746, N'Iowa', N'Oran', N'Fayette', N'50664')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (747, N'Iowa', N'Orange City', N'Sioux', N'51041')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (748, N'Iowa', N'Orchard', N'Mitchell', N'50460')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (749, N'Iowa', N'Orient', N'Adair', N'50858')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (750, N'Iowa', N'Osage', N'Mitchell', N'50461')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (751, N'Iowa', N'Osceola', N'Clarke', N'50213')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (752, N'Iowa', N'Oskaloosa', N'Mahaska', N'52577')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (753, N'Iowa', N'Ossian', N'Winneshiek', N'52161')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (754, N'Iowa', N'Otho', N'Webster', N'50569')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (755, N'Iowa', N'Otley', N'Marion', N'50214')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (756, N'Iowa', N'Oto', N'Woodbury', N'51044')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (757, N'Iowa', N'Ottosen', N'Humboldt', N'50570')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (758, N'Iowa', N'Ottumwa', N'Wapello', N'52501')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (759, N'Iowa', N'Oxford', N'Johnson', N'52322')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (760, N'Iowa', N'Oxford Junction', N'Jones', N'52323')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (761, N'Iowa', N'Oyens', N'Plymouth', N'51045')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (762, N'Iowa', N'Pacific Junction', N'Mills', N'51561')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (763, N'Iowa', N'Packwood', N'Jefferson', N'52580')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (764, N'Iowa', N'Palmer', N'Pocahontas', N'50571')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (765, N'Iowa', N'Palo', N'Linn', N'52324')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (766, N'Iowa', N'Panama', N'Shelby', N'51562')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (767, N'Iowa', N'Panora', N'Guthrie', N'50216')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (768, N'Iowa', N'Parkersburg', N'Butler', N'50665')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (769, N'Iowa', N'Parnell', N'Iowa', N'52325')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (770, N'Iowa', N'Paton', N'Greene', N'50217')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (771, N'Iowa', N'Patterson', N'Madison', N'50218')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (772, N'Iowa', N'Paullina', N'Obrien', N'51046')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (773, N'Iowa', N'Pella', N'Marion', N'50219')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (774, N'Iowa', N'Peosta', N'Dubuque', N'52068')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (775, N'Iowa', N'Percival', N'Fremont', N'51648')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (776, N'Iowa', N'Perry', N'Dallas', N'50220')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (777, N'Iowa', N'Persia', N'Harrison', N'51563')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (778, N'Iowa', N'Peru', N'Madison', N'50222')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (779, N'Iowa', N'Peterson', N'Clay', N'51047')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (780, N'Iowa', N'Pierson', N'Woodbury', N'51048')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (781, N'Iowa', N'Pilot Grove', N'Lee', N'52648')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (782, N'Iowa', N'Pilot Mound', N'Boone', N'50223')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (783, N'Iowa', N'Pisgah', N'Harrison', N'51564')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (784, N'Iowa', N'Plainfield', N'Bremer', N'50666')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (785, N'Iowa', N'Plano', N'Appanoose', N'52581')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (786, N'Iowa', N'Pleasant Valley', N'Scott', N'52767')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (787, N'Iowa', N'Pleasantville', N'Marion', N'50225')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (788, N'Iowa', N'Plover', N'Pocahontas', N'50573')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (789, N'Iowa', N'Plymouth', N'Cerro Gordo', N'50464')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (790, N'Iowa', N'Pocahontas', N'Pocahontas', N'50574')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (791, N'Iowa', N'Polk City', N'Polk', N'50226')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (792, N'Iowa', N'Pomeroy', N'Calhoun', N'50575')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (793, N'Iowa', N'Popejoy', N'Franklin', N'50227')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (794, N'Iowa', N'Portsmouth', N'Shelby', N'51565')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (795, N'Iowa', N'Postville', N'Allamakee', N'52162')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (796, N'Iowa', N'Prairie City', N'Jasper', N'50228')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (797, N'Iowa', N'Prairieburg', N'Linn', N'52219')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (798, N'Iowa', N'Prescott', N'Adams', N'50859')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (799, N'Iowa', N'Preston', N'Jackson', N'52069')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (800, N'Iowa', N'Primghar', N'Obrien', N'51245')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (801, N'Iowa', N'Princeton', N'Scott', N'52768')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (802, N'Iowa', N'Prole', N'Warren', N'50229')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (803, N'Iowa', N'Promise City', N'Wayne', N'52583')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (804, N'Iowa', N'Protivin', N'Howard', N'52163')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (805, N'Iowa', N'Pulaski', N'Davis', N'52584')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (806, N'Iowa', N'Quasqueton', N'Buchanan', N'52326')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (807, N'Iowa', N'Quimby', N'Cherokee', N'51049')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (808, N'Iowa', N'Radcliffe', N'Hardin', N'50230')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (809, N'Iowa', N'Rake', N'Winnebago', N'50465')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (810, N'Iowa', N'Ralston', N'Carroll', N'51459')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (811, N'Iowa', N'Randalia', N'Fayette', N'52164')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (812, N'Iowa', N'Randall', N'Hamilton', N'50231')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (813, N'Iowa', N'Randolph', N'Fremont', N'51649')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (814, N'Iowa', N'Raymond', N'Black Hawk', N'50667')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (815, N'Iowa', N'Readlyn', N'Bremer', N'50668')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (816, N'Iowa', N'Reasnor', N'Jasper', N'50232')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (817, N'Iowa', N'Red Oak', N'Montgomery', N'51566')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (818, N'Iowa', N'Red Oak', N'Montgomery', N'51591')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (819, N'Iowa', N'Redding', N'Ringgold', N'50860')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (820, N'Iowa', N'Redfield', N'Dallas', N'50233')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (821, N'Iowa', N'Reinbeck', N'Grundy', N'50669')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (822, N'Iowa', N'Rembrandt', N'Buena Vista', N'50576')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (823, N'Iowa', N'Remsen', N'Plymouth', N'51050')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (824, N'Iowa', N'Renwick', N'Humboldt', N'50577')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (825, N'Iowa', N'Rhodes', N'Marshall', N'50234')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (826, N'Iowa', N'Riceville', N'Howard', N'50466')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (827, N'Iowa', N'Richland', N'Keokuk', N'52585')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (828, N'Iowa', N'Ricketts', N'Crawford', N'51460')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (829, N'Iowa', N'Ridgeway', N'Winneshiek', N'52165')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (830, N'Iowa', N'Ringsted', N'Emmet', N'50578')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (831, N'Iowa', N'Rippey', N'Greene', N'50235')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (832, N'Iowa', N'Riverside', N'Washington', N'52327')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (833, N'Iowa', N'Riverton', N'Fremont', N'51650')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (834, N'Iowa', N'Robins', N'Linn', N'52328')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (835, N'Iowa', N'Rock Falls', N'Cerro Gordo', N'50467')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (836, N'Iowa', N'Rock Rapids', N'Lyon', N'51246')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (837, N'Iowa', N'Rock Valley', N'Sioux', N'51247')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (838, N'Iowa', N'Rockford', N'Floyd', N'50468')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (839, N'Iowa', N'Rockwell', N'Cerro Gordo', N'50469')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (840, N'Iowa', N'Rockwell City', N'Calhoun', N'50579')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (841, N'Iowa', N'Rodney', N'Monona', N'51051')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (842, N'Iowa', N'Roland', N'Story', N'50236')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (843, N'Iowa', N'Rolfe', N'Pocahontas', N'50581')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (844, N'Iowa', N'Rome', N'Henry', N'52642')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (845, N'Iowa', N'Rose Hill', N'Mahaska', N'52586')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (846, N'Iowa', N'Rowan', N'Wright', N'50470')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (847, N'Iowa', N'Rowley', N'Buchanan', N'52329')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (848, N'Iowa', N'Royal', N'Clay', N'51357')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (849, N'Iowa', N'Rudd', N'Floyd', N'50471')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (850, N'Iowa', N'Runnells', N'Polk', N'50237')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (851, N'Iowa', N'Russell', N'Lucas', N'50238')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (852, N'Iowa', N'Ruthven', N'Palo Alto', N'51358')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (853, N'Iowa', N'Rutland', N'Humboldt', N'50582')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (854, N'Iowa', N'Ryan', N'Delaware', N'52330')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (855, N'Iowa', N'Sabula', N'Jackson', N'52070')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (856, N'Iowa', N'Sac City', N'Sac', N'50583')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (857, N'Iowa', N'Saint Ansgar', N'Mitchell', N'50472')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (858, N'Iowa', N'Saint Anthony', N'Marshall', N'50239')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (859, N'Iowa', N'Saint Charles', N'Madison', N'50240')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (860, N'Iowa', N'Saint Donatus', N'Jackson', N'52071')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (861, N'Iowa', N'Saint Lucas', N'Fayette', N'52166')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (862, N'Iowa', N'Saint Marys', N'Warren', N'50241')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (863, N'Iowa', N'Saint Olaf', N'Clayton', N'52072')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (864, N'Iowa', N'Saint Paul', N'Lee', N'52657')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (865, N'Iowa', N'Salem', N'Henry', N'52649')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (866, N'Iowa', N'Salix', N'Woodbury', N'51052')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (867, N'Iowa', N'Sanborn', N'Obrien', N'51248')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (868, N'Iowa', N'Scarville', N'Winnebago', N'50473')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (869, N'Iowa', N'Schaller', N'Sac', N'51053')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (870, N'Iowa', N'Schleswig', N'Crawford', N'51461')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (871, N'Iowa', N'Scranton', N'Greene', N'51462')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (872, N'Iowa', N'Searsboro', N'Poweshiek', N'50242')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (873, N'Iowa', N'Selma', N'Van Buren', N'52588')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (874, N'Iowa', N'Sergeant Bluff', N'Woodbury', N'51054')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (875, N'Iowa', N'Seymour', N'Wayne', N'52590')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (876, N'Iowa', N'Shambaugh', N'Page', N'51651')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (877, N'Iowa', N'Shannon City', N'Union', N'50861')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (878, N'Iowa', N'Sharpsburg', N'Taylor', N'50862')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (879, N'Iowa', N'Sheffield', N'Franklin', N'50475')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (880, N'Iowa', N'Shelby', N'Pottawattamie', N'51570')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (881, N'Iowa', N'Sheldahl', N'Polk', N'50243')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (882, N'Iowa', N'Sheldon', N'Obrien', N'51201')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (883, N'Iowa', N'Shell Rock', N'Butler', N'50670')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (884, N'Iowa', N'Shellsburg', N'Benton', N'52332')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (885, N'Iowa', N'Shenandoah', N'Page', N'51601')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (886, N'Iowa', N'Shenandoah', N'Page', N'51602')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (887, N'Iowa', N'Shenandoah', N'Page', N'51603')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (888, N'Iowa', N'Sherrill', N'Dubuque', N'52073')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (889, N'Iowa', N'Sibley', N'Osceola', N'51249')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (890, N'Iowa', N'Sidney', N'Fremont', N'51652')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (891, N'Iowa', N'Sigourney', N'Keokuk', N'52591')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (892, N'Iowa', N'Silver City', N'Mills', N'51571')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (893, N'Iowa', N'Sioux Center', N'Sioux', N'51250')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (894, N'Iowa', N'Sioux City', N'Woodbury', N'51101')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (895, N'Iowa', N'Sioux City', N'Woodbury', N'51102')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (896, N'Iowa', N'Sioux City', N'Woodbury', N'51103')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (897, N'Iowa', N'Sioux City', N'Woodbury', N'51104')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (898, N'Iowa', N'Sioux City', N'Woodbury', N'51105')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (899, N'Iowa', N'Sioux City', N'Woodbury', N'51106')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (900, N'Iowa', N'Sioux City', N'Woodbury', N'51108')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (901, N'Iowa', N'Sioux City', N'Woodbury', N'51109')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (902, N'Iowa', N'Sioux City', N'Woodbury', N'51111')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (903, N'Iowa', N'Sioux Rapids', N'Buena Vista', N'50585')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (904, N'Iowa', N'Slater', N'Story', N'50244')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (905, N'Iowa', N'Sloan', N'Woodbury', N'51055')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (906, N'Iowa', N'Smithland', N'Woodbury', N'51056')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (907, N'Iowa', N'Soldier', N'Monona', N'51572')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (908, N'Iowa', N'Solon', N'Johnson', N'52333')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (909, N'Iowa', N'Somers', N'Calhoun', N'50586')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (910, N'Iowa', N'South Amana', N'Iowa', N'52334')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (911, N'Iowa', N'South English', N'Keokuk', N'52335')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (912, N'Iowa', N'Spencer', N'Clay', N'51301')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (913, N'Iowa', N'Sperry', N'Des Moines', N'52650')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (914, N'Iowa', N'Spillville', N'Winneshiek', N'52168')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (915, N'Iowa', N'Spirit Lake', N'Dickinson', N'51360')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (916, N'Iowa', N'Spragueville', N'Jackson', N'52074')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (917, N'Iowa', N'Springbrook', N'Jackson', N'52075')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (918, N'Iowa', N'Springville', N'Linn', N'52336')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (919, N'Iowa', N'Stacyville', N'Mitchell', N'50476')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (920, N'Iowa', N'Stanhope', N'Hamilton', N'50246')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (921, N'Iowa', N'Stanley', N'Buchanan', N'50671')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (922, N'Iowa', N'Stanton', N'Montgomery', N'51573')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (923, N'Iowa', N'Stanwood', N'Cedar', N'52337')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (924, N'Iowa', N'State Center', N'Marshall', N'50247')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (925, N'Iowa', N'Steamboat Rock', N'Hardin', N'50672')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (926, N'Iowa', N'Stockport', N'Van Buren', N'52651')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (927, N'Iowa', N'Stockton', N'Muscatine', N'52769')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (928, N'Iowa', N'Storm Lake', N'Buena Vista', N'50588')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (929, N'Iowa', N'Story City', N'Story', N'50248')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (930, N'Iowa', N'Stout', N'Grundy', N'50673')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (931, N'Iowa', N'Stratford', N'Hamilton', N'50249')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (932, N'Iowa', N'Strawberry Point', N'Clayton', N'52076')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (933, N'Iowa', N'Stuart', N'Guthrie', N'50250')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (934, N'Iowa', N'Sully', N'Jasper', N'50251')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (935, N'Iowa', N'Sumner', N'Bremer', N'50674')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (936, N'Iowa', N'Superior', N'Dickinson', N'51363')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (937, N'Iowa', N'Sutherland', N'Obrien', N'51058')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (938, N'Iowa', N'Swaledale', N'Cerro Gordo', N'50477')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (939, N'Iowa', N'Swan', N'Marion', N'50252')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (940, N'Iowa', N'Swea City', N'Kossuth', N'50590')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (941, N'Iowa', N'Swedesburg', N'Henry', N'52652')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (942, N'Iowa', N'Swisher', N'Johnson', N'52338')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (943, N'Iowa', N'Tabor', N'Fremont', N'51653')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (944, N'Iowa', N'Tama', N'Tama', N'52339')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (945, N'Iowa', N'Teeds Grove', N'Clinton', N'52771')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (946, N'Iowa', N'Templeton', N'Carroll', N'51463')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (947, N'Iowa', N'Terril', N'Dickinson', N'51364')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (948, N'Iowa', N'Thayer', N'Union', N'50254')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (949, N'Iowa', N'Thompson', N'Winnebago', N'50478')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (950, N'Iowa', N'Thor', N'Humboldt', N'50591')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (951, N'Iowa', N'Thornburg', N'Keokuk', N'50255')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (952, N'Iowa', N'Thornton', N'Cerro Gordo', N'50479')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (953, N'Iowa', N'Thurman', N'Fremont', N'51654')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (954, N'Iowa', N'Tiffin', N'Johnson', N'52340')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (955, N'Iowa', N'Tingley', N'Ringgold', N'50863')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (956, N'Iowa', N'Tipton', N'Cedar', N'52772')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (957, N'Iowa', N'Titonka', N'Kossuth', N'50480')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (958, N'Iowa', N'Toddville', N'Linn', N'52341')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (959, N'Iowa', N'Toeterville', N'Mitchell', N'50481')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (960, N'Iowa', N'Toledo', N'Tama', N'52342')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (961, N'Iowa', N'Tracy', N'Marion', N'50256')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (962, N'Iowa', N'Traer', N'Tama', N'50675')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (963, N'Iowa', N'Treynor', N'Pottawattamie', N'51575')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (964, N'Iowa', N'Tripoli', N'Bremer', N'50676')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (965, N'Iowa', N'Troy Mills', N'Linn', N'52344')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (966, N'Iowa', N'Truesdale', N'Buena Vista', N'50592')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (967, N'Iowa', N'Truro', N'Madison', N'50257')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (968, N'Iowa', N'Udell', N'Appanoose', N'52593')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (969, N'Iowa', N'Underwood', N'Pottawattamie', N'51576')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (970, N'Iowa', N'Union', N'Hardin', N'50258')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (971, N'Iowa', N'Unionville', N'Appanoose', N'52594')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (972, N'Iowa', N'University Park', N'Mahaska', N'52595')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (973, N'Iowa', N'Urbana', N'Benton', N'52345')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (974, N'Iowa', N'Urbandale', N'Polk', N'50322')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (975, N'Iowa', N'Urbandale', N'Polk', N'50323')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (976, N'Iowa', N'Ute', N'Monona', N'51060')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (977, N'Iowa', N'Vail', N'Crawford', N'51465')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (978, N'Iowa', N'Van Horne', N'Benton', N'52346')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (979, N'Iowa', N'Van Meter', N'Dallas', N'50261')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (980, N'Iowa', N'Van Wert', N'Decatur', N'50262')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (981, N'Iowa', N'Varina', N'Pocahontas', N'50593')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (982, N'Iowa', N'Ventura', N'Cerro Gordo', N'50482')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (983, N'Iowa', N'Victor', N'Iowa', N'52347')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (984, N'Iowa', N'Villisca', N'Montgomery', N'50864')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (985, N'Iowa', N'Vincent', N'Webster', N'50594')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (986, N'Iowa', N'Vining', N'Tama', N'52348')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (987, N'Iowa', N'Vinton', N'Benton', N'52349')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (988, N'Iowa', N'Viola', N'Linn', N'52350')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (989, N'Iowa', N'Volga', N'Clayton', N'52077')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (990, N'Iowa', N'Wadena', N'Fayette', N'52169')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (991, N'Iowa', N'Walcott', N'Scott', N'52773')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (992, N'Iowa', N'Walford', N'Benton', N'52351')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (993, N'Iowa', N'Walker', N'Linn', N'52352')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (994, N'Iowa', N'Wall Lake', N'Sac', N'51466')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (995, N'Iowa', N'Wallingford', N'Emmet', N'51365')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (996, N'Iowa', N'Walnut', N'Pottawattamie', N'51577')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (997, N'Iowa', N'Wapello', N'Louisa', N'52653')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (998, N'Iowa', N'Washington', N'Washington', N'52353')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (999, N'Iowa', N'Washta', N'Cherokee', N'51061')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (1000, N'Iowa', N'Waterloo', N'Black Hawk', N'50701')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (1001, N'Iowa', N'Waterloo', N'Black Hawk', N'50702')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (1002, N'Iowa', N'Waterloo', N'Black Hawk', N'50703')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (1003, N'Iowa', N'Waterloo', N'Black Hawk', N'50704')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (1004, N'Iowa', N'Waterloo', N'Black Hawk', N'50706')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (1005, N'Iowa', N'Waterville', N'Allamakee', N'52170')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (1006, N'Iowa', N'Watkins', N'Benton', N'52354')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (1007, N'Iowa', N'Waucoma', N'Fayette', N'52171')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (1008, N'Iowa', N'Waukee', N'Dallas', N'50263')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (1009, N'Iowa', N'Waukon', N'Allamakee', N'52172')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (1010, N'Iowa', N'Waverly', N'Bremer', N'50677')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (1011, N'Iowa', N'Wayland', N'Henry', N'52654')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (1012, N'Iowa', N'Webb', N'Clay', N'51366')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (1013, N'Iowa', N'Webster', N'Keokuk', N'52355')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (1014, N'Iowa', N'Webster City', N'Hamilton', N'50595')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (1015, N'Iowa', N'Weldon', N'Decatur', N'50264')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (1016, N'Iowa', N'Wellman', N'Washington', N'52356')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (1017, N'Iowa', N'Wellsburg', N'Grundy', N'50680')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (1018, N'Iowa', N'Welton', N'Muscatine', N'52774')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (1019, N'Iowa', N'Wesley', N'Kossuth', N'50483')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (1020, N'Iowa', N'West Bend', N'Palo Alto', N'50597')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (1021, N'Iowa', N'West Branch', N'Cedar', N'52358')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (1022, N'Iowa', N'West Burlington', N'Des Moines', N'52655')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (1023, N'Iowa', N'West Chester', N'Washington', N'52359')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (1024, N'Iowa', N'West Des Moines', N'Polk', N'50265')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (1025, N'Iowa', N'West Des Moines', N'Polk', N'50266')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (1026, N'Iowa', N'West Des Moines', N'Polk', N'50398')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (1027, N'Iowa', N'West Grove', N'Davis', N'52538')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (1028, N'Iowa', N'West Liberty', N'Muscatine', N'52776')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (1029, N'Iowa', N'West Point', N'Lee', N'52656')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (1030, N'Iowa', N'West Union', N'Fayette', N'52175')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (1031, N'Iowa', N'Westfield', N'Plymouth', N'51062')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (1032, N'Iowa', N'Westgate', N'Fayette', N'50681')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (1033, N'Iowa', N'Westphalia', N'Shelby', N'51578')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (1034, N'Iowa', N'Westside', N'Crawford', N'51467')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (1035, N'Iowa', N'Wever', N'Lee', N'52658')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (1036, N'Iowa', N'What Cheer', N'Keokuk', N'50268')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (1037, N'Iowa', N'Wheatland', N'Clinton', N'52777')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (1038, N'Iowa', N'Whiting', N'Monona', N'51063')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (1039, N'Iowa', N'Whittemore', N'Kossuth', N'50598')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (1040, N'Iowa', N'Whitten', N'Hardin', N'50269')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (1041, N'Iowa', N'Williams', N'Hamilton', N'50271')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (1042, N'Iowa', N'Williamsburg', N'Iowa', N'52361')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (1043, N'Iowa', N'Williamson', N'Lucas', N'50272')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (1044, N'Iowa', N'Wilton', N'Muscatine', N'52778')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (1045, N'Iowa', N'Winfield', N'Henry', N'52659')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (1046, N'Iowa', N'Winterset', N'Madison', N'50273')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (1047, N'Iowa', N'Winthrop', N'Buchanan', N'50682')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (1048, N'Iowa', N'Wiota', N'Cass', N'50274')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (1049, N'Iowa', N'Woden', N'Hancock', N'50484')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (1050, N'Iowa', N'Woodbine', N'Harrison', N'51579')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (1051, N'Iowa', N'Woodburn', N'Clarke', N'50275')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (1052, N'Iowa', N'Woodward', N'Dallas', N'50276')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (1053, N'Iowa', N'Woolstock', N'Wright', N'50599')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (1054, N'Iowa', N'Worthington', N'Dubuque', N'52078')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (1055, N'Iowa', N'Wyoming', N'Jones', N'52362')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (1056, N'Iowa', N'Yale', N'Guthrie', N'50277')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (1057, N'Iowa', N'Yarmouth', N'Des Moines', N'52660')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (1058, N'Iowa', N'Yorktown', N'Page', N'51656')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (1059, N'Iowa', N'Zearing', N'Story', N'50278')
GO
INSERT [dbo].[StateAndCityInfo] ([Id], [State], [City], [County], [ZipCode]) VALUES (1060, N'Iowa', N'Zwingle', N'Dubuque', N'52079')
GO
SET IDENTITY_INSERT [dbo].[StateAndCityInfo] OFF
GO
