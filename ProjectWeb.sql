USE [ProjectWeb]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 01-Apr-21 04:53:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[UserName] [varchar](50) NOT NULL,
	[PassWord] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 01-Apr-21 04:53:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[order_id] [int] IDENTITY(1,1) NOT NULL,
	[product_id] [varchar](50) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[quantity] [int] NOT NULL,
	[totalPrice] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[order_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order_Detail]    Script Date: 01-Apr-21 04:53:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_Detail](
	[order_id] [int] IDENTITY(1,1) NOT NULL,
	[userName] [varchar](50) NOT NULL,
	[first_name] [varchar](50) NOT NULL,
	[last_name] [varchar](50) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[phone] [varchar](50) NOT NULL,
	[shipCost] [money] NULL,
	[country] [varchar](50) NULL,
	[city] [varchar](50) NULL,
	[homenumber] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[order_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 01-Apr-21 04:53:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[product_id] [varchar](50) NOT NULL,
	[product_name] [varchar](50) NULL,
	[product_price] [money] NULL,
	[product_images] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Account] ([UserName], [PassWord], [Email]) VALUES (N'sa', N'123', N'sonlahe140994@fpt.edu.vn')
INSERT [dbo].[Account] ([UserName], [PassWord], [Email]) VALUES (N'thanhtamle', N'123', N'sonlahe140994@fpt.edu.vn')
INSERT [dbo].[Account] ([UserName], [PassWord], [Email]) VALUES (N'web123', N'123', N'sonlahe140994@fpt.edu.vn')
INSERT [dbo].[Account] ([UserName], [PassWord], [Email]) VALUES (N'web321', N'123', N'sonlahe140994@fpt.edu.vn')
INSERT [dbo].[Account] ([UserName], [PassWord], [Email]) VALUES (N'webProject', N'123', N'sonlahe140994@fpt.edu.vn')
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([order_id], [product_id], [UserName], [quantity], [totalPrice]) VALUES (36, N'DH1', N'sa', 3, 40.0000)
INSERT [dbo].[Order] ([order_id], [product_id], [UserName], [quantity], [totalPrice]) VALUES (37, N'DH1', N'sa', 3, 40.0000)
INSERT [dbo].[Order] ([order_id], [product_id], [UserName], [quantity], [totalPrice]) VALUES (38, N'DH1', N'sa', 3, 40.0000)
INSERT [dbo].[Order] ([order_id], [product_id], [UserName], [quantity], [totalPrice]) VALUES (39, N'DH3', N'sa', 1, 45.7430)
INSERT [dbo].[Order] ([order_id], [product_id], [UserName], [quantity], [totalPrice]) VALUES (40, N'DH6', N'sa', 1, 45.7430)
INSERT [dbo].[Order] ([order_id], [product_id], [UserName], [quantity], [totalPrice]) VALUES (41, N'DH2', N'sa', 1, 45.7430)
INSERT [dbo].[Order] ([order_id], [product_id], [UserName], [quantity], [totalPrice]) VALUES (42, N'DH1', N'sa', 1, 45.7430)
INSERT [dbo].[Order] ([order_id], [product_id], [UserName], [quantity], [totalPrice]) VALUES (43, N'DH2', N'sa', 1, 45.7430)
INSERT [dbo].[Order] ([order_id], [product_id], [UserName], [quantity], [totalPrice]) VALUES (44, N'DH1', N'sa', 1, 45.7430)
INSERT [dbo].[Order] ([order_id], [product_id], [UserName], [quantity], [totalPrice]) VALUES (45, N'DH5', N'sa', 1, 45.7430)
INSERT [dbo].[Order] ([order_id], [product_id], [UserName], [quantity], [totalPrice]) VALUES (46, N'DH8', N'sa', 1, 45.7430)
INSERT [dbo].[Order] ([order_id], [product_id], [UserName], [quantity], [totalPrice]) VALUES (47, N'DH3', N'sa', 1, 45.7430)
INSERT [dbo].[Order] ([order_id], [product_id], [UserName], [quantity], [totalPrice]) VALUES (48, N'DH2', N'sa', 1, 45.7430)
INSERT [dbo].[Order] ([order_id], [product_id], [UserName], [quantity], [totalPrice]) VALUES (49, N'DH2', N'sa', 1, 45.7430)
INSERT [dbo].[Order] ([order_id], [product_id], [UserName], [quantity], [totalPrice]) VALUES (50, N'DH2', N'sa', 1, 45.7430)
INSERT [dbo].[Order] ([order_id], [product_id], [UserName], [quantity], [totalPrice]) VALUES (51, N'DH1', N'sa', 1, 45.7430)
INSERT [dbo].[Order] ([order_id], [product_id], [UserName], [quantity], [totalPrice]) VALUES (52, N'DH2', N'sa', 1, 45.7430)
INSERT [dbo].[Order] ([order_id], [product_id], [UserName], [quantity], [totalPrice]) VALUES (53, N'DH1', N'sa', 5, 228.7150)
INSERT [dbo].[Order] ([order_id], [product_id], [UserName], [quantity], [totalPrice]) VALUES (54, N'DH6', N'sa', 4, 182.9720)
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
SET IDENTITY_INSERT [dbo].[Order_Detail] ON 

INSERT [dbo].[Order_Detail] ([order_id], [userName], [first_name], [last_name], [email], [phone], [shipCost], [country], [city], [homenumber]) VALUES (21, N'sa', N'test', N'test', N'sonlahe140994@fpt.edu.vn', N'1', 30.0000, N'1', N'1', N'1')
INSERT [dbo].[Order_Detail] ([order_id], [userName], [first_name], [last_name], [email], [phone], [shipCost], [country], [city], [homenumber]) VALUES (22, N'sa', N'test', N'test', N'sonlahe140994@fpt.edu.vn', N'1', 30.0000, N'1', N'1', N'1')
INSERT [dbo].[Order_Detail] ([order_id], [userName], [first_name], [last_name], [email], [phone], [shipCost], [country], [city], [homenumber]) VALUES (23, N'web123', N'test', N'test', N'sonlahe140994@fpt.edu.vn', N'1', 30.0000, N'1', N'1', N'1')
INSERT [dbo].[Order_Detail] ([order_id], [userName], [first_name], [last_name], [email], [phone], [shipCost], [country], [city], [homenumber]) VALUES (27, N'sa', N'Le Anh Son', N'SonLA', N'sonlahe140994@fpt.edu.vn', N'0358111470', 30.0000, N'VN', N'VN', N'VN')
INSERT [dbo].[Order_Detail] ([order_id], [userName], [first_name], [last_name], [email], [phone], [shipCost], [country], [city], [homenumber]) VALUES (30, N'web123', N'Le', N'Son', N'sonlahe140994@fpt.edu.vn', N'0358111470', 50.0000, N'Viet Nam', N'Thanh Hoa City', N'Thach That')
INSERT [dbo].[Order_Detail] ([order_id], [userName], [first_name], [last_name], [email], [phone], [shipCost], [country], [city], [homenumber]) VALUES (31, N'sa', N'Le', N'Son', N'sonlahe140994@fpt.edu.vn', N'0358111470', 50.0000, N'Viet Nam', N'Thanh Hoa City', N'Thach That')
INSERT [dbo].[Order_Detail] ([order_id], [userName], [first_name], [last_name], [email], [phone], [shipCost], [country], [city], [homenumber]) VALUES (32, N'sa', N'Le', N'Son', N'sonlahe140994@fpt.edu.vn', N'0321456789', 50.0000, N'USA', N'Thanh Hoa City', N'43/38 ABC')
INSERT [dbo].[Order_Detail] ([order_id], [userName], [first_name], [last_name], [email], [phone], [shipCost], [country], [city], [homenumber]) VALUES (33, N'sa', N'Le', N'Son', N'sonlahe140994@fpt.edu.vn', N'0321456789', 50.0000, N'USA', N'Thanh Hoa City', N'43/38 ABC')
SET IDENTITY_INSERT [dbo].[Order_Detail] OFF
GO
INSERT [dbo].[Product] ([product_id], [product_name], [product_price], [product_images]) VALUES (N'DH1', N'Thermo Ball Etip Gloves', 45.7430, N'DH1.png')
INSERT [dbo].[Product] ([product_id], [product_name], [product_price], [product_images]) VALUES (N'DH10', N'Test', 50.0000, N'DH9.png')
INSERT [dbo].[Product] ([product_id], [product_name], [product_price], [product_images]) VALUES (N'DH11', N'Test', 50.0000, N'DH9.png')
INSERT [dbo].[Product] ([product_id], [product_name], [product_price], [product_images]) VALUES (N'DH12', N'Test', 50.0000, N'DH9.png')
INSERT [dbo].[Product] ([product_id], [product_name], [product_price], [product_images]) VALUES (N'DH13', N'Test', 50.0000, N'DH9.png')
INSERT [dbo].[Product] ([product_id], [product_name], [product_price], [product_images]) VALUES (N'DH2', N'Thermo Ball Etip Gloves 2', 45.7430, N'DH2.png')
INSERT [dbo].[Product] ([product_id], [product_name], [product_price], [product_images]) VALUES (N'DH3', N'Thermo Ball Etip Gloves 3', 45.7430, N'DH3.png')
INSERT [dbo].[Product] ([product_id], [product_name], [product_price], [product_images]) VALUES (N'DH4', N'Thermo Ball Etip Gloves 4', 45.7430, N'DH4.png')
INSERT [dbo].[Product] ([product_id], [product_name], [product_price], [product_images]) VALUES (N'DH5', N'Thermo Ball Etip Gloves 5', 45.7430, N'DH5.png')
INSERT [dbo].[Product] ([product_id], [product_name], [product_price], [product_images]) VALUES (N'DH6', N'Thermo Ball Etip Gloves 6', 45.7430, N'DH6.png')
INSERT [dbo].[Product] ([product_id], [product_name], [product_price], [product_images]) VALUES (N'DH7', N'Thermo Ball Etip Gloves 7', 45.7430, N'DH7.png')
INSERT [dbo].[Product] ([product_id], [product_name], [product_price], [product_images]) VALUES (N'DH8', N'Thermo Ball Etip Gloves 8', 45.7430, N'DH8.png')
INSERT [dbo].[Product] ([product_id], [product_name], [product_price], [product_images]) VALUES (N'DH9', N'Thermo Ball Etip Gloves 9', 45.7430, N'DH9.png')
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [fk_order] FOREIGN KEY([product_id])
REFERENCES [dbo].[Product] ([product_id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [fk_order]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [fk_user] FOREIGN KEY([UserName])
REFERENCES [dbo].[Account] ([UserName])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [fk_user]
GO
ALTER TABLE [dbo].[Order_Detail]  WITH CHECK ADD  CONSTRAINT [fzOrder] FOREIGN KEY([userName])
REFERENCES [dbo].[Account] ([UserName])
GO
ALTER TABLE [dbo].[Order_Detail] CHECK CONSTRAINT [fzOrder]
GO
