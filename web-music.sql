create database WebMusic
go 
USE [WebMusic]
GO
/****** Object:  Table [dbo].[ADMIN]    Script Date: 11/16/2022 12:20:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ADMIN](
	[TenAD] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[UserName] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Pass] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[TrangThai] [bit] NULL,
	[DC] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SDT] [numeric](10, 0) NULL,
	[STK] [numeric](13, 0) NULL,
	[GT] [bit] NULL,
	[NS] [date] NULL,
	[Email] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[URL_img] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[GhiChu] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[MaAD] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaAD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ALbum]    Script Date: 11/16/2022 12:20:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ALbum](
	[TenAlbum] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[MaKH] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[GhiChu] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[MaAl] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaAl] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DS_SP]    Script Date: 11/16/2022 12:20:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DS_SP](
	[MaAL] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[MaSP] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaAL] ASC,
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KHACH_HANG]    Script Date: 11/16/2022 12:20:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KHACH_HANG](
	[TenKH] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[URL_img] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[UserName] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Pass] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DiaChi] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SDT] [numeric](10, 0) NOT NULL,
	[NgaySinh] [date] NULL,
	[TrangThai] [bit] NULL,
	[GT] [bit] NULL,
	[CCCD] [numeric](12, 0) NOT NULL,
	[Email] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[GhiChu] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[MaKH] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NGHE]    Script Date: 11/16/2022 12:20:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NGHE](
	[MaSP] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[MaKH] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ThoiGian] [datetime] NOT NULL,
	[GHiChu] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
PRIMARY KEY CLUSTERED 
(
	[MaSP] ASC,
	[MaKH] ASC,
	[ThoiGian] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NGHE_SI]    Script Date: 11/16/2022 12:20:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NGHE_SI](
	[TenNS] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[NgaySinh] [date] NULL,
	[QueQuan] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[NS_URL] [nvarchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[GT] [bit] NULL,
	[GhiChu] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[TheoDoi] [numeric](15, 0) NULL,
	[NgheDanh] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[URL_img] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[mans] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[mans] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SAN_PHAM]    Script Date: 11/16/2022 12:20:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SAN_PHAM](
	[TenSP] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[SangTac] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SP_URL] [nvarchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Theloai] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[TrangThai] [bit] NULL,
	[LuotNghe] [float] NULL,
	[GhiChu] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[YeuThich] [numeric](15, 0) NULL,
	[KhongYeuThich] [numeric](15, 0) NULL,
	[TGPhatHanh] [datetime] NULL,
	[MaSP] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ThoiGian] [time](7) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[THEO_DOI]    Script Date: 11/16/2022 12:20:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[THEO_DOI](
	[MaKH] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[MaNS] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[TG] [datetime] NULL,
	[GhiChu] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC,
	[MaNS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TIN_MOI]    Script Date: 11/16/2022 12:20:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TIN_MOI](
	[TenTM] [nvarchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ThoiGian] [datetime] NULL,
	[URL_img] [nvarchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[URL_link] [nvarchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[GhiChu] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[LuotTruyCap] [float] NULL,
	[MaTM] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaTM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TRINH_BAY]    Script Date: 11/16/2022 12:20:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TRINH_BAY](
	[MaNS] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[MaSP] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[GhiChu] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNS] ASC,
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TRUY_CAP_TM]    Script Date: 11/16/2022 12:20:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TRUY_CAP_TM](
	[makh] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[maTM] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ThoiGian] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[makh] ASC,
	[maTM] ASC,
	[ThoiGian] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[YEU_THICH]    Script Date: 11/16/2022 12:20:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[YEU_THICH](
	[makh] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[masp] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ThoiGian] [datetime] NULL,
	[YeuThich] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[makh] ASC,
	[masp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ADMIN] ([TenAD], [UserName], [Pass], [TrangThai], [DC], [SDT], [STK], [GT], [NS], [Email], [URL_img], [GhiChu], [MaAD]) VALUES (N'Nguyễn Văn Hoàng Anh', N'Anh', N'e10adc3949ba59abbe56e057f20f883e', 1, NULL, CAST(386494859 AS Numeric(10, 0)), NULL, NULL, NULL, NULL, NULL, NULL, N'AD00000001')
GO
INSERT [dbo].[ALbum] ([TenAlbum], [MaKH], [GhiChu], [MaAl]) VALUES (N'AL', N'KH00000001', NULL, N'AL00000001')
INSERT [dbo].[ALbum] ([TenAlbum], [MaKH], [GhiChu], [MaAl]) VALUES (N'Bum', N'KH00000001', NULL, N'AL00000002')
GO
INSERT [dbo].[DS_SP] ([MaAL], [MaSP]) VALUES (N'AL00000001', N'SP00000001')
INSERT [dbo].[DS_SP] ([MaAL], [MaSP]) VALUES (N'AL00000001', N'SP00000002')
INSERT [dbo].[DS_SP] ([MaAL], [MaSP]) VALUES (N'AL00000001', N'SP00000003')
INSERT [dbo].[DS_SP] ([MaAL], [MaSP]) VALUES (N'AL00000001', N'SP00000004')
INSERT [dbo].[DS_SP] ([MaAL], [MaSP]) VALUES (N'AL00000001', N'SP00000005')
INSERT [dbo].[DS_SP] ([MaAL], [MaSP]) VALUES (N'AL00000002', N'SP00000001')
INSERT [dbo].[DS_SP] ([MaAL], [MaSP]) VALUES (N'AL00000002', N'SP00000002')
INSERT [dbo].[DS_SP] ([MaAL], [MaSP]) VALUES (N'AL00000002', N'SP00000006')
GO
SET IDENTITY_INSERT [dbo].[KHACH_HANG] ON 

INSERT [dbo].[KHACH_HANG] ([TenKH], [URL_img], [UserName], [Pass], [DiaChi], [SDT], [NgaySinh], [TrangThai], [GT], [CCCD], [Email], [GhiChu], [MaKH], [ID]) VALUES (N'Nguyễn Văn Hoàng Anh', N'~\Assets\img\KH\Son_Tung_M-TP.png', N'nhuuu', N'e10adc3949ba59abbe56e057f20f883e', N'Thanh Chương, Nghệ An', CAST(386494859 AS Numeric(10, 0)), CAST(N'2001-04-20' AS Date), 1, 1, CAST(546505250000 AS Numeric(12, 0)), N'nguyenvanhoanganh20042001@gmail.com', NULL, N'KH00000001', 1)
INSERT [dbo].[KHACH_HANG] ([TenKH], [URL_img], [UserName], [Pass], [DiaChi], [SDT], [NgaySinh], [TrangThai], [GT], [CCCD], [Email], [GhiChu], [MaKH], [ID]) VALUES (N'Hà Công Quốc bảo', N'~/Assets/img/KH/add.png', N'bao', N'', NULL, CAST(65616515 AS Numeric(10, 0)), NULL, NULL, NULL, CAST(51265165565 AS Numeric(12, 0)), NULL, NULL, N'KH00000002', 4)
INSERT [dbo].[KHACH_HANG] ([TenKH], [URL_img], [UserName], [Pass], [DiaChi], [SDT], [NgaySinh], [TrangThai], [GT], [CCCD], [Email], [GhiChu], [MaKH], [ID]) VALUES (N'Nguyễn Văn Công', N'~/Assets/img/KH/add.png', N'cong', N'123456', NULL, CAST(8646263263 AS Numeric(10, 0)), NULL, 1, NULL, CAST(4541651610 AS Numeric(12, 0)), NULL, NULL, N'KH00000003', 5)
INSERT [dbo].[KHACH_HANG] ([TenKH], [URL_img], [UserName], [Pass], [DiaChi], [SDT], [NgaySinh], [TrangThai], [GT], [CCCD], [Email], [GhiChu], [MaKH], [ID]) VALUES (N'Nguyễn Văn Công', N'~/Assets/img/KH/add.png', NULL, NULL, NULL, CAST(8646263263 AS Numeric(10, 0)), NULL, 1, NULL, CAST(4541651610 AS Numeric(12, 0)), NULL, NULL, N'KH00000004', 6)
INSERT [dbo].[KHACH_HANG] ([TenKH], [URL_img], [UserName], [Pass], [DiaChi], [SDT], [NgaySinh], [TrangThai], [GT], [CCCD], [Email], [GhiChu], [MaKH], [ID]) VALUES (N'Nguyễn Văn Công', N'~/Assets/img/KH/add.png', N'An', NULL, NULL, CAST(8646263263 AS Numeric(10, 0)), NULL, 1, NULL, CAST(4541651610 AS Numeric(12, 0)), NULL, NULL, N'KH00000005', 7)
INSERT [dbo].[KHACH_HANG] ([TenKH], [URL_img], [UserName], [Pass], [DiaChi], [SDT], [NgaySinh], [TrangThai], [GT], [CCCD], [Email], [GhiChu], [MaKH], [ID]) VALUES (N'Nguyễn Văn Công', N'~/Assets/img/KH/add.png', N'nh', N'123456', NULL, CAST(8646263263 AS Numeric(10, 0)), NULL, 1, NULL, CAST(4541651610 AS Numeric(12, 0)), NULL, NULL, N'KH00000006', 8)
INSERT [dbo].[KHACH_HANG] ([TenKH], [URL_img], [UserName], [Pass], [DiaChi], [SDT], [NgaySinh], [TrangThai], [GT], [CCCD], [Email], [GhiChu], [MaKH], [ID]) VALUES (N'Nguyễn Văn Công', N'~/Assets/img/KH/add.png', NULL, NULL, NULL, CAST(8646263263 AS Numeric(10, 0)), NULL, 1, NULL, CAST(4541651610 AS Numeric(12, 0)), NULL, NULL, N'KH00000007', 9)
INSERT [dbo].[KHACH_HANG] ([TenKH], [URL_img], [UserName], [Pass], [DiaChi], [SDT], [NgaySinh], [TrangThai], [GT], [CCCD], [Email], [GhiChu], [MaKH], [ID]) VALUES (N'Nguyễn Văn Công', N'~/Assets/img/KH/add.png', N'xs', NULL, NULL, CAST(8646263263 AS Numeric(10, 0)), NULL, 1, NULL, CAST(4541651610 AS Numeric(12, 0)), NULL, NULL, N'KH00000008', 10)
SET IDENTITY_INSERT [dbo].[KHACH_HANG] OFF
GO
INSERT [dbo].[NGHE_SI] ([TenNS], [NgaySinh], [QueQuan], [NS_URL], [GT], [GhiChu], [TheoDoi], [NgheDanh], [URL_img], [mans]) VALUES (N'Robyn Rihanna Fenty', CAST(N'1988-02-20' AS Date), N'Saint James, Barbados', N'https://vi.wikipedia.org/wiki/Rihanna'',', 0, NULL, NULL, N'Rihanna', N'~/Assets/img/album/Adele_21.jpg', N'NS00000001')
INSERT [dbo].[NGHE_SI] ([TenNS], [NgaySinh], [QueQuan], [NS_URL], [GT], [GhiChu], [TheoDoi], [NgheDanh], [URL_img], [mans]) VALUES (N'Nguyễn Khoa Tóc Tiên', NULL, NULL, NULL, NULL, NULL, NULL, N'Tóc Tiên', N'~/Assets/img/album/Adele_21.jpg', N'NS00000002')
INSERT [dbo].[NGHE_SI] ([TenNS], [NgaySinh], [QueQuan], [NS_URL], [GT], [GhiChu], [TheoDoi], [NgheDanh], [URL_img], [mans]) VALUES (N'Charles Otto "Charlie" Puth Jr.[', CAST(N'1991-01-12' AS Date), N'Rumson, bang New Jersey, Mỹ', N'https://vi.wikipedia.org/wiki/Charlie_Puth', NULL, NULL, NULL, N'Charlie Puth', N'~/Assets/img/album/Adele_21.jpg', N'NS00000004')
INSERT [dbo].[NGHE_SI] ([TenNS], [NgaySinh], [QueQuan], [NS_URL], [GT], [GhiChu], [TheoDoi], [NgheDanh], [URL_img], [mans]) VALUES (N'Nguyễn Thanh Tùng', NULL, N'Thái Bình, Việt Nam', N'https://vi.wikipedia.org/wiki/S%C6%A1n_T%C3%B9ng_M-TP', NULL, NULL, NULL, N'Sơn Tùng MTP', N'~/Assets/img/album/Adele_21.jpg', N'NS00000005')
INSERT [dbo].[NGHE_SI] ([TenNS], [NgaySinh], [QueQuan], [NS_URL], [GT], [GhiChu], [TheoDoi], [NgheDanh], [URL_img], [mans]) VALUES (N'Nguyễn Khoa Tóc Tiên', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'~/Assets/img/singer/Bao_Anh_(2018).png', N'NS00000006')
GO
INSERT [dbo].[SAN_PHAM] ([TenSP], [SangTac], [SP_URL], [Theloai], [TrangThai], [LuotNghe], [GhiChu], [YeuThich], [KhongYeuThich], [TGPhatHanh], [MaSP], [ThoiGian]) VALUES (N'Vũ Điệu Cồng Chiêng', N'Lưu Thiên Hương', N'assests_mp3_vdcc.mp3', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'SP00000001', CAST(N'00:03:24' AS Time))
INSERT [dbo].[SAN_PHAM] ([TenSP], [SangTac], [SP_URL], [Theloai], [TrangThai], [LuotNghe], [GhiChu], [YeuThich], [KhongYeuThich], [TGPhatHanh], [MaSP], [ThoiGian]) VALUES (N'Ngày Tận Thế', N'Châu Đăng Khoa', N'assests_mp3_ntt.mp3', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'SP00000002', CAST(N'00:03:52' AS Time))
INSERT [dbo].[SAN_PHAM] ([TenSP], [SangTac], [SP_URL], [Theloai], [TrangThai], [LuotNghe], [GhiChu], [YeuThich], [KhongYeuThich], [TGPhatHanh], [MaSP], [ThoiGian]) VALUES (N'Có ai thương em như anh', NULL, N'assests_mp3_catena.mp3', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'SP00000003', CAST(N'00:03:51' AS Time))
INSERT [dbo].[SAN_PHAM] ([TenSP], [SangTac], [SP_URL], [Theloai], [TrangThai], [LuotNghe], [GhiChu], [YeuThich], [KhongYeuThich], [TGPhatHanh], [MaSP], [ThoiGian]) VALUES (N'Em Đã Có Người Mới', NULL, N'assests_mp3_edcnm.mp3', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'SP00000004', CAST(N'00:03:20' AS Time))
INSERT [dbo].[SAN_PHAM] ([TenSP], [SangTac], [SP_URL], [Theloai], [TrangThai], [LuotNghe], [GhiChu], [YeuThich], [KhongYeuThich], [TGPhatHanh], [MaSP], [ThoiGian]) VALUES (N'Sợ Quá Cơ', N'Pháo', N'SoQuaCoNsmallRemix-Phao-6466251.mp3', N'Nhạc trẻ', 1, NULL, NULL, NULL, NULL, NULL, N'SP00000005', CAST(N'00:03:20' AS Time))
INSERT [dbo].[SAN_PHAM] ([TenSP], [SangTac], [SP_URL], [Theloai], [TrangThai], [LuotNghe], [GhiChu], [YeuThich], [KhongYeuThich], [TGPhatHanh], [MaSP], [ThoiGian]) VALUES (N'Waiting For You', N'MONO', N'Waiting For You.mp3', N'Nhạc trẻ', 1, NULL, NULL, NULL, NULL, NULL, N'SP00000006', CAST(N'00:03:20' AS Time))
INSERT [dbo].[SAN_PHAM] ([TenSP], [SangTac], [SP_URL], [Theloai], [TrangThai], [LuotNghe], [GhiChu], [YeuThich], [KhongYeuThich], [TGPhatHanh], [MaSP], [ThoiGian]) VALUES (N'Lạc Trôi', N'Sơn Tùng MTP', N'LacTroi-SonTungMTP-4725907.mp3', N'Nhạc Việt Nam, Nhạc pop, rock...,
', 1, NULL, NULL, NULL, NULL, CAST(N'2017-01-01T00:00:00.000' AS DateTime), N'SP00000007', CAST(N'00:03:53' AS Time))
INSERT [dbo].[SAN_PHAM] ([TenSP], [SangTac], [SP_URL], [Theloai], [TrangThai], [LuotNghe], [GhiChu], [YeuThich], [KhongYeuThich], [TGPhatHanh], [MaSP], [ThoiGian]) VALUES (N'Truth', N'Sơn Tùng MTP', N'Truth - Son Tung M-TP.mp3.crdownload', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'SP00000008', CAST(N'00:03:20' AS Time))
INSERT [dbo].[SAN_PHAM] ([TenSP], [SangTac], [SP_URL], [Theloai], [TrangThai], [LuotNghe], [GhiChu], [YeuThich], [KhongYeuThich], [TGPhatHanh], [MaSP], [ThoiGian]) VALUES (N'Hương Thầm', N'Tân nhàn', N'Huong Tham - Tan Nhan.mp3', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'SP00000009', CAST(N'00:05:50' AS Time))
INSERT [dbo].[SAN_PHAM] ([TenSP], [SangTac], [SP_URL], [Theloai], [TrangThai], [LuotNghe], [GhiChu], [YeuThich], [KhongYeuThich], [TGPhatHanh], [MaSP], [ThoiGian]) VALUES (N'Deatta Koro No Youni', NULL, N'Deatta Koro No Youni Micro Tools Known A.mp3', N'Nhạc Nhật', NULL, NULL, NULL, NULL, NULL, NULL, N'SP00000010', CAST(N'00:04:43' AS Time))
GO
INSERT [dbo].[TIN_MOI] ([TenTM], [ThoiGian], [URL_img], [URL_link], [GhiChu], [LuotTruyCap], [MaTM]) VALUES (N'Chi Pu xin lỗi khán giả, hủy ra album', CAST(N'2022-10-13T00:00:00.000' AS DateTime), N'~\Assets\img\tin mới\CHIPU.jpg', N'https://vnexpress.net/chi-pu-xin-loi-khan-gia-huy-ra-album-4522821.html', NULL, NULL, N'TM00000001')
INSERT [dbo].[TIN_MOI] ([TenTM], [ThoiGian], [URL_img], [URL_link], [GhiChu], [LuotTruyCap], [MaTM]) VALUES (N'Blake Shelton rời The Voice Mỹ', CAST(N'2022-10-12T00:00:00.000' AS DateTime), N'~\Assets\img\tin mới\2.png', N'https://vnexpress.net/blake-shelton-roi-the-voice-my-4522316.html', NULL, NULL, N'TM00000002')
GO
INSERT [dbo].[TRINH_BAY] ([MaNS], [MaSP], [GhiChu]) VALUES (N'NS00000002', N'SP00000001', NULL)
INSERT [dbo].[TRINH_BAY] ([MaNS], [MaSP], [GhiChu]) VALUES (N'NS00000002', N'SP00000002', NULL)
INSERT [dbo].[TRINH_BAY] ([MaNS], [MaSP], [GhiChu]) VALUES (N'NS00000002', N'SP00000003', NULL)
INSERT [dbo].[TRINH_BAY] ([MaNS], [MaSP], [GhiChu]) VALUES (N'NS00000002', N'SP00000004', NULL)
GO
ALTER TABLE [dbo].[ALbum]  WITH CHECK ADD FOREIGN KEY([MaKH])
REFERENCES [dbo].[KHACH_HANG] ([MaKH])
GO
ALTER TABLE [dbo].[DS_SP]  WITH CHECK ADD FOREIGN KEY([MaAL])
REFERENCES [dbo].[ALbum] ([MaAl])
GO
ALTER TABLE [dbo].[DS_SP]  WITH CHECK ADD FOREIGN KEY([MaSP])
REFERENCES [dbo].[SAN_PHAM] ([MaSP])
GO
ALTER TABLE [dbo].[NGHE]  WITH CHECK ADD FOREIGN KEY([MaKH])
REFERENCES [dbo].[KHACH_HANG] ([MaKH])
GO
ALTER TABLE [dbo].[NGHE]  WITH CHECK ADD FOREIGN KEY([MaSP])
REFERENCES [dbo].[SAN_PHAM] ([MaSP])
GO
ALTER TABLE [dbo].[THEO_DOI]  WITH CHECK ADD FOREIGN KEY([MaKH])
REFERENCES [dbo].[KHACH_HANG] ([MaKH])
GO
ALTER TABLE [dbo].[THEO_DOI]  WITH CHECK ADD FOREIGN KEY([MaNS])
REFERENCES [dbo].[NGHE_SI] ([mans])
GO
ALTER TABLE [dbo].[TRINH_BAY]  WITH CHECK ADD FOREIGN KEY([MaNS])
REFERENCES [dbo].[NGHE_SI] ([mans])
GO
ALTER TABLE [dbo].[TRINH_BAY]  WITH CHECK ADD FOREIGN KEY([MaSP])
REFERENCES [dbo].[SAN_PHAM] ([MaSP])
GO
ALTER TABLE [dbo].[TRUY_CAP_TM]  WITH CHECK ADD FOREIGN KEY([makh])
REFERENCES [dbo].[KHACH_HANG] ([MaKH])
GO
ALTER TABLE [dbo].[TRUY_CAP_TM]  WITH CHECK ADD FOREIGN KEY([maTM])
REFERENCES [dbo].[TIN_MOI] ([MaTM])
GO
ALTER TABLE [dbo].[YEU_THICH]  WITH CHECK ADD FOREIGN KEY([makh])
REFERENCES [dbo].[KHACH_HANG] ([MaKH])
GO
ALTER TABLE [dbo].[YEU_THICH]  WITH CHECK ADD FOREIGN KEY([masp])
REFERENCES [dbo].[SAN_PHAM] ([MaSP])
GO
