USE [PM]
GO
/****** Object:  Table [dbo].[BlackList]    Script Date: 4/25/2019 9:38:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlackList](
	[UserId] [int] NOT NULL,
	[BlockUserId] [int] NOT NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_BlackList] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[BlockUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Cart]    Script Date: 4/25/2019 9:38:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cart](
	[UserId] [int] NOT NULL,
	[CartId] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Cart] PRIMARY KEY CLUSTERED 
(
	[CartId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CartItem]    Script Date: 4/25/2019 9:38:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CartItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CartId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NULL,
 CONSTRAINT [PK_CartDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChatDetail]    Script Date: 4/25/2019 9:38:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ChatDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoomId] [varchar](125) NULL,
	[UserId] [int] NULL,
	[Message] [ntext] NULL,
	[CreateDate] [datetime] NULL,
	[Status] [int] NULL,
	[Type] [int] NULL,
 CONSTRAINT [PK_ChatMessage] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ChatRoom]    Script Date: 4/25/2019 9:38:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ChatRoom](
	[RoomId] [varchar](125) NOT NULL,
	[RoomName] [nvarchar](1000) NULL,
	[UserCreate] [int] NULL,
	[Avatar] [varchar](255) NULL,
	[UserGuest] [int] NULL,
	[Type] [int] NULL,
	[UserCount] [int] NULL,
	[CreateDate] [datetime] NULL,
	[LastMessage] [ntext] NULL,
	[LastDate] [datetime] NULL,
	[LastUser] [int] NULL,
	[LastType] [int] NULL,
 CONSTRAINT [PK_ChatRoom] PRIMARY KEY CLUSTERED 
(
	[RoomId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ChatUser]    Script Date: 4/25/2019 9:38:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ChatUser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[RoomId] [varchar](125) NULL,
	[CreateDate] [datetime] NULL,
	[Status] [int] NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_ChatUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Citys]    Script Date: 4/25/2019 9:38:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Citys](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CityName] [nvarchar](100) NULL,
	[Position] [int] NULL,
	[Type] [int] NULL,
	[IsDeparture] [bit] NULL,
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CMS_Banner]    Script Date: 4/25/2019 9:38:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CMS_Banner](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[BannerName] [nvarchar](128) NULL,
	[BannerType] [int] NULL,
	[Description] [nvarchar](512) NULL,
	[ThumbnailImage] [varchar](256) NULL,
	[LargeImage] [varchar](256) NULL,
	[CoverImage] [varchar](256) NULL,
	[TargetLink] [varchar](20) NULL,
	[LinkRedirect] [varchar](256) NULL,
	[OrderNo] [int] NULL,
	[IsActive] [bit] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_CMS_Banner] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CMS_News]    Script Date: 4/25/2019 9:38:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CMS_News](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[CategoryID] [bigint] NULL,
	[Title] [nvarchar](256) NULL,
	[ImageThumb] [varchar](256) NULL,
	[UrlRewrite] [varchar](256) NULL,
	[ShortDescription] [nvarchar](1024) NULL,
	[BodyContent] [ntext] NULL,
	[MetaKeyword] [ntext] NULL,
	[ViewCounter] [int] NULL,
	[CreateDate] [datetime] NULL,
	[PublishDate] [datetime] NULL,
	[ExpirateDate] [datetime] NULL,
	[PromoStartDate] [datetime] NULL,
	[PromoExpireDate] [datetime] NULL,
	[IsHot] [bit] NULL,
	[Status] [tinyint] NULL,
	[OrderNo] [int] NULL,
	[Tag] [nvarchar](256) NULL,
	[SeoName] [nvarchar](256) NULL,
	[MetaTitle] [nvarchar](256) NULL,
	[MetaDescription] [nvarchar](1000) NULL,
	[CreateUser] [varchar](100) NULL,
	[ShareCount] [bigint] NULL,
 CONSTRAINT [PK_CMS_News] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CMS_NewsCategory]    Script Date: 4/25/2019 9:38:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CMS_NewsCategory](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](200) NULL,
	[ParentID] [bigint] NULL,
	[UrlRewrite] [varchar](256) NULL,
	[IconImg] [varchar](256) NULL,
	[Description] [ntext] NULL,
	[OrderNo] [int] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_CMS_NewsCategory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Comment]    Script Date: 4/25/2019 9:38:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[CommentId] [int] IDENTITY(1,1) NOT NULL,
	[PostId] [int] NULL,
	[UserId] [int] NULL,
	[Message] [nvarchar](4000) NULL,
	[CommentFor] [int] NULL,
	[CreateDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED 
(
	[CommentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Contacts]    Script Date: 4/25/2019 9:38:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contacts](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](100) NULL,
	[Email] [nvarchar](100) NULL,
	[Phone] [nvarchar](50) NULL,
	[Title] [nvarchar](50) NULL,
	[Contents] [ntext] NULL,
	[Status] [tinyint] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Contacts] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Follow]    Script Date: 4/25/2019 9:38:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Follow](
	[UserId] [int] NOT NULL,
	[FollowUserId] [int] NOT NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Follow] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[FollowUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FriendsList]    Script Date: 4/25/2019 9:38:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FriendsList](
	[UserId] [int] NOT NULL,
	[FriendUserId] [int] NOT NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_FriendsList] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[FriendUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Fund]    Script Date: 4/25/2019 9:38:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Fund](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SharingFund] [decimal](18, 0) NULL,
	[SharingMember] [int] NULL,
	[SharingMinInCome] [decimal](18, 0) NULL,
	[TravellingFund] [decimal](18, 0) NULL,
	[TravellingMember] [int] NULL,
	[TravellingMinInCome] [decimal](18, 0) NULL,
	[LuckyFund] [decimal](18, 0) NULL,
	[LyckyMember] [int] NULL,
	[LuckyMinInCome] [decimal](18, 0) NULL,
	[FundSafe] [varchar](500) NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[Status] [int] NULL,
	[SharingBonus] [decimal](18, 0) NULL,
	[TravellingBonus] [decimal](18, 0) NULL,
	[LuckyBonus] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Fund] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Gallery]    Script Date: 4/25/2019 9:38:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Gallery](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[GalleryName] [nvarchar](255) NULL,
	[Image] [varchar](255) NULL,
	[Description] [nvarchar](1000) NULL,
	[OrderNo] [int] NULL,
	[IsActive] [bit] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Gallery] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Gallery_Product_Picture]    Script Date: 4/25/2019 9:38:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gallery_Product_Picture](
	[PictureID] [int] IDENTITY(1,1) NOT NULL,
	[PictureName] [nvarchar](256) NULL,
	[ProductID] [int] NULL,
	[Position] [int] NULL,
	[CreateDate] [datetime] NULL,
	[BImage] [nvarchar](256) NULL,
	[MImage] [nvarchar](256) NULL,
	[SImage] [nvarchar](256) NULL,
 CONSTRAINT [PK_Gallery_Product_Picture] PRIMARY KEY CLUSTERED 
(
	[PictureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Like]    Script Date: 4/25/2019 9:38:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Like](
	[LikeId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[FullName] [nvarchar](255) NULL,
	[PostId] [int] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Like] PRIMARY KEY CLUSTERED 
(
	[LikeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Message]    Script Date: 4/25/2019 9:38:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Message](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[ToUserId] [int] NULL,
	[Title] [nvarchar](128) NULL,
	[Message] [nvarchar](500) NULL,
	[StatusId] [int] NULL,
	[Deleted] [bit] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Message] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NewsTags]    Script Date: 4/25/2019 9:38:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NewsTags](
	[TagID] [bigint] NOT NULL,
	[NewsID] [bigint] NOT NULL,
	[TagName] [nvarchar](200) NULL,
	[NewsTitle] [nvarchar](256) NULL,
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_NewsTags] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NotifyHistory]    Script Date: 4/25/2019 9:38:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[NotifyHistory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[PostId] [int] NULL,
	[Content] [nvarchar](4000) NULL,
	[ImageCount] [int] NULL,
	[NotifyDate] [smalldatetime] NULL,
	[ActionFromId] [int] NULL,
	[Action] [varchar](32) NULL,
	[PostType] [int] NULL
) ON [PRIMARY]
SET ANSI_PADDING ON
ALTER TABLE [dbo].[NotifyHistory] ADD [Link] [varchar](1000) NULL
ALTER TABLE [dbo].[NotifyHistory] ADD [Image] [varchar](1000) NULL
 CONSTRAINT [PK_NotifyHistory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Order]    Script Date: 4/25/2019 9:38:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [int] IDENTITY(1000,1) NOT NULL,
	[UserId] [int] NULL,
	[BillingAddress] [nvarchar](256) NULL,
	[ShippingAddress] [nvarchar](256) NULL,
	[Note] [nvarchar](256) NULL,
	[OrderStatusId] [int] NULL,
	[PaymentStatusId] [int] NULL,
	[PaymentMethod] [int] NULL,
	[CurrentIncome] [decimal](18, 0) NULL,
	[CurrentBalance] [decimal](18, 0) NULL,
	[OrderDiscount] [decimal](18, 0) NULL,
	[OrderTotal] [decimal](18, 0) NULL,
	[CustomerIp] [varchar](50) NULL,
	[CreateDate] [datetime] NULL,
	[Deleted] [bit] NULL,
	[ShippingName] [nvarchar](100) NULL,
	[ShippingGender] [int] NULL,
	[IdentityType] [int] NULL,
	[IdentityNumber] [nvarchar](100) NULL,
	[ShippingPhone] [nvarchar](50) NULL,
	[ShippingEmail] [nvarchar](100) NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OrderItem]    Script Date: 4/25/2019 9:38:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NULL,
	[ProductId] [int] NULL,
	[Quantity] [int] NULL,
	[UnitPrice] [int] NULL,
	[Price] [decimal](18, 0) NULL,
	[DiscountAmount] [decimal](18, 0) NULL,
 CONSTRAINT [PK_OrderItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Post]    Script Date: 4/25/2019 9:38:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Post](
	[PostId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[Title] [ntext] NULL,
	[PostType] [int] NULL,
	[Image] [varchar](255) NULL,
	[WebLink] [varchar](255) NULL,
	[YoutubeLink] [varchar](255) NULL,
	[Content] [ntext] NULL,
	[Comment] [int] NULL,
	[Like] [int] NULL,
	[IsActived] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[UserDeleted] [int] NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[UserCreate] [int] NULL,
	[ShareId] [int] NULL,
	[ShareType] [int] NULL,
	[ShareCount] [bigint] NULL,
 CONSTRAINT [PK_Post] PRIMARY KEY CLUSTERED 
(
	[PostId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PostReport]    Script Date: 4/25/2019 9:38:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PostReport](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PostId] [int] NULL,
	[UserId] [int] NULL,
	[Content] [ntext] NULL,
	[CreateDate] [datetime] NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_PostReport] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PostShare]    Script Date: 4/25/2019 9:38:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PostShare](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PostId] [int] NULL,
	[UserId] [int] NULL,
	[Type] [int] NULL,
 CONSTRAINT [PK_PostShare] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product_Picture]    Script Date: 4/25/2019 9:38:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_Picture](
	[PictureID] [int] IDENTITY(1,1) NOT NULL,
	[PictureName] [nvarchar](256) NULL,
	[ProductID] [int] NULL,
	[BImage] [nvarchar](256) NULL,
	[MImage] [nvarchar](256) NULL,
	[SImage] [nvarchar](256) NULL,
	[Position] [int] NULL,
	[CreateDate] [datetime] NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_Product_Picture] PRIMARY KEY CLUSTERED 
(
	[PictureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductCategory]    Script Date: 4/25/2019 9:38:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProductCategory](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](255) NULL,
	[Url] [varchar](500) NULL,
	[BImage] [varchar](255) NULL,
	[MImage] [varchar](255) NULL,
	[SImage] [varchar](255) NULL,
	[Position] [int] NULL,
	[ParentID] [int] NULL,
	[Description] [nvarchar](500) NULL,
	[MetaTitle] [nvarchar](255) NULL,
	[MetaKeyword] [nvarchar](255) NULL,
	[MetaDescription] [nvarchar](255) NULL,
	[IsDelete] [bit] NULL,
	[CreateDate] [datetime] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_ProductCategory] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProductCategory]    Script Date: 4/25/2019 9:38:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProductUnit](
	[UnitID] [int] IDENTITY(1,1) NOT NULL,
	[UnitName] [nvarchar](255) NULL,
	[Description] [nvarchar](500) NULL,
	[IsDelete] [bit] NULL,
	[CreateDate] [datetime] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_ProductUnit] PRIMARY KEY CLUSTERED 
(
	[UnitID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProductImport]    Script Date: 4/25/2019 9:38:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProductImport](
	[ImportID] [int] IDENTITY(1,1) NOT NULL,
	[ImportFrom] [nvarchar](255) NULL,
	[Price] [decimal](18, 0) NULL,
	[Quantity] [int] NULL,
	[Description] [nvarchar](500) NULL,
	[IsDelete] [bit] NULL,
	[ImportDate] [datetime] NULL,
	[CreateDate] [datetime] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_ProductImport] PRIMARY KEY CLUSTERED 
(
	[ImportID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Products]    Script Date: 4/25/2019 9:38:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Products](
	[ProductID] [bigint] IDENTITY(1,1) NOT NULL,
	[ProductCode] [varchar](50) NULL,
	[ProductName] [nvarchar](255) NULL,
	[SeoName] [nvarchar](255) NULL,
	[CategoryID] [int] NULL,
	[UnitId] [int] NULL,
	[SIMage] [varchar](255) NULL,
	[MImage] [varchar](255) NULL,
	[BImage] [varchar](255) NULL,
	[Price] [decimal](18, 0) NULL,
	[SalePrice] [decimal](18, 0) NULL,
	[Promotion] [nvarchar](255) NULL,
	[ShortDescription] [ntext] NULL,
	[DetailContent] [ntext] NULL,
	[MetaTitle] [nvarchar](255) NULL,
	[MetaKeyword] [nvarchar](255) NULL,
	[MetaDescription] [nvarchar](255) NULL,
	[IsNew] [bit] NULL,
	[IsHot] [bit] NULL,
	[IsDelete] [bit] NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[ViewCount] [int] NULL,
	[Url] [varchar](500) NULL,
	[IsActive] [bit] NULL,
	[BonusPercent] [decimal](18, 0) NULL,
	[Warranty] [int] NULL,
	[PartnerLink] [varchar](500) NULL,
	[IsTarget] [bit] NULL,
	[CreateUser] [varchar](50) NULL,
	[ViewDoping] [int] NULL,
	[ShareCount] [bigint] NULL,
	[TokenPrice] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RequestMoney]    Script Date: 4/25/2019 9:38:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RequestMoney](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[CurrentBalance] [decimal](18, 0) NULL,
	[PaymentMethod] [int] NULL,
	[Amount] [decimal](18, 0) NULL,
	[BankName] [nvarchar](128) NULL,
	[AccountNumber] [nvarchar](128) NULL,
	[BankLocation] [nvarchar](128) NULL,
	[AccountName] [nvarchar](128) NULL,
	[StatusId] [int] NULL,
	[CreateDate] [datetime] NULL,
	[Deleted] [bit] NULL,
	[RequestType] [int] NULL,
 CONSTRAINT [PK_Transfer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Settings]    Script Date: 4/25/2019 9:38:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Settings](
	[SettingId] [int] IDENTITY(1,1) NOT NULL,
	[SettingName] [nvarchar](100) NOT NULL,
	[SettingValue] [nvarchar](1024) NOT NULL,
 CONSTRAINT [PK_Settings] PRIMARY KEY CLUSTERED 
(
	[SettingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Slug]    Script Date: 4/25/2019 9:38:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Slug](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SlugName] [varchar](255) NULL,
	[HashSlug] [varchar](128) NULL,
	[Ref] [int] NULL,
	[Controller] [varchar](50) NULL,
	[ObjectID] [int] NULL,
	[RedirectUrl] [varchar](255) NULL,
	[Status] [int] NULL,
	[UserID] [int] NULL,
	[UserName] [nvarchar](128) NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_tblSlug] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StaticPage]    Script Date: 4/25/2019 9:38:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StaticPage](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](256) NULL,
	[Hotline] [nvarchar](256) NULL,
	[Logo] [nvarchar](256) NULL,
	[Header] [ntext] NULL,
	[Footer] [ntext] NULL,
	[Copyright] [nvarchar](256) NULL,
	[MetaTitle] [nvarchar](256) NULL,
	[MetaKeyWord] [nvarchar](256) NULL,
	[MetaDescription] [nvarchar](256) NULL,
	[Content1] [ntext] NULL,
	[Content2] [ntext] NULL,
	[Content3] [ntext] NULL,
	[Content4] [ntext] NULL,
	[Content5] [ntext] NULL,
	[OnlineCounter] [int] NULL,
	[ViewCounter] [bigint] NULL,
 CONSTRAINT [PK_StaticPage] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tags]    Script Date: 4/25/2019 9:38:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tags](
	[TagID] [bigint] IDENTITY(1,1) NOT NULL,
	[TagName] [nvarchar](200) NULL,
 CONSTRAINT [PK_Tags] PRIMARY KEY CLUSTERED 
(
	[TagID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tour]    Script Date: 4/25/2019 9:38:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tour](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TourName] [nvarchar](128) NULL,
	[Content] [ntext] NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[StatusId] [int] NULL,
	[CreateDate] [datetime] NULL,
	[Deleted] [bit] NULL,
 CONSTRAINT [PK_Tour] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TourMember]    Script Date: 4/25/2019 9:38:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TourMember](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TourId] [int] NULL,
	[UserId] [int] NULL,
	[StatusId] [int] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_TourMember] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Transaction]    Script Date: 4/25/2019 9:38:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Transaction](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[IdRef] [int] NULL,
	[TransactionType] [int] NULL,
	[Status] [int] NULL,
	[LastBalance] [decimal](18, 0) NULL,
	[LastIncome] [decimal](18, 0) NULL,
	[Balance] [decimal](18, 0) NULL,
	[Income] [decimal](18, 0) NULL,
	[TransactionSafe] [varchar](1000) NULL,
	[CreateDate] [datetime] NULL,
	[Amount] [decimal](18, 2) NULL,
	[Note] [ntext] NULL,
 CONSTRAINT [PK_Transaction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Transfer]    Script Date: 4/25/2019 9:38:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Transfer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[CurrentBalanceUserId] [decimal](18, 0) NULL,
	[ToUserId] [int] NULL,
	[CurrentBalanceToUserId] [decimal](18, 0) NULL,
	[Amount] [decimal](18, 0) NULL,
	[StatusId] [int] NULL,
	[CreateDate] [datetime] NULL,
	[UserName] [varchar](128) NULL,
	[ToUserName] [varchar](128) NULL,
 CONSTRAINT [PK_Transfer_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserActivity]    Script Date: 4/25/2019 9:38:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserActivity](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[UserName] [varchar](255) NULL,
	[Avatar] [varchar](255) NULL,
	[PostID] [int] NULL,
	[PostTitle] [nvarchar](255) NULL,
	[PostType] [int] NULL,
	[ActionType] [int] NULL,
	[ActionName] [nvarchar](255) NULL,
	[IP] [varchar](50) NULL,
	[OS] [varchar](50) NULL,
	[Browser] [varchar](50) NULL,
	[UserIDPost] [int] NULL,
	[UserNamePost] [nvarchar](255) NULL,
	[CreateDate] [datetime] NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_UserActivity] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserDevices]    Script Date: 4/25/2019 9:38:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[UserDevices](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[DeviceId] [varchar](256) NOT NULL,
	[Token] [varchar](256) NOT NULL,
 CONSTRAINT [PK_UserDevices] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserLog]    Script Date: 4/25/2019 9:38:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLog](
	[LogID] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[Token] [decimal](18, 0) NULL,
	[Note] [ntext] NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_UserLog] PRIMARY KEY CLUSTERED 
(
	[LogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 4/25/2019 9:38:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1000,1) NOT NULL,
	[UserName] [varchar](255) NULL,
	[Email] [varchar](255) NULL,
	[Password] [varchar](255) NULL,
	[PasswordSalt] [varchar](255) NULL,
	[FullName] [nvarchar](50) NULL,
	[DisplayName] [nvarchar](50) NULL,
	[Mobile] [varchar](20) NULL,
	[CountryId] [int] NULL,
	[Country] [nvarchar](50) NULL,
	[AvatarImage] [varchar](255) NULL,
	[AvatarImageName] [varchar](128) NULL,
	[OrgAvatarImage] [varchar](255) NULL,
	[CoverImage] [varchar](255) NULL,
	[CoverImageName] [varchar](128) NULL,
	[Level] [int] NULL,
	[UserType] [int] NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[IsLock] [bit] NULL,
	[LoginFailNumber] [int] NULL,
	[LastLoginDate] [datetime] NULL,
	[NewFollow] [bit] NULL,
	[NewComment] [bit] NULL,
	[NewMessage] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[IsActived] [bit] NULL,
	[IsHot] [bit] NULL,
	[IsUpdateAvatar] [bit] NULL,
	[Posts] [int] NULL,
	[Views] [int] NULL,
	[Followers] [int] NULL,
	[Following] [int] NULL,
	[PositionCover] [int] NULL,
	[Description] [nvarchar](1000) NULL,
	[InCome] [decimal](18, 0) NULL,
	[AccountBalance] [decimal](18, 0) NULL,
	[AccountPoint] [decimal](18, 0) NULL,
	[UserSafe] [varchar](500) NULL,
	[IdentityNumber] [varchar](50) NULL,
	[FrontSide] [varchar](500) NULL,
	[RearSide] [varchar](500) NULL,
	[IsVip] [bit] NULL,
	[IsVerify] [bit] NULL,
	[PositionCoverMobile] [int] NULL,
	[UserIdRef] [int] NULL,
	[VerifyDate] [datetime] NULL,
	[Address] [nvarchar](120) NULL,
	[BankName] [nvarchar](120) NULL,
	[BankLocation] [nvarchar](120) NULL,
	[BankAccountName] [nvarchar](120) NULL,
	[BankAccountNumber] [nvarchar](120) NULL,
	[MessageDate] [datetime] NULL,
	[IsOnline] [bit] NULL,
	[IsShowCountry] [bit] NULL,
	[IsShowDate] [bit] NULL,
	[PasswordChangedDate] [datetime] NULL,
	[LastPasswordFailureDate] [datetime] NULL,
	[PasswordfailuresSinceLastSuccess] [int] NULL,
	[PasswordVerificationToken] [nvarchar](256) NULL,
	[PasswordVerificationTokenExpirationDate] [datetime] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[WebLinks]    Script Date: 4/25/2019 9:38:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WebLinks](
	[LinkID] [int] IDENTITY(1,1) NOT NULL,
	[LinkName] [nvarchar](255) NULL,
	[Url] [nvarchar](500) NULL,
	[Position] [int] NULL,
 CONSTRAINT [PK_WebLink] PRIMARY KEY CLUSTERED 
(
	[LinkID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[webpages_Membership]    Script Date: 4/25/2019 9:38:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_Membership](
	[UserId] [int] NOT NULL,
	[CreateDate] [datetime] NULL,
	[ConfirmationToken] [nvarchar](128) NULL,
	[IsConfirmed] [bit] NULL,
	[LastPasswordFailureDate] [datetime] NULL,
	[PasswordFailuresSinceLastSuccess] [int] NOT NULL,
	[Password] [nvarchar](128) NOT NULL,
	[PasswordChangedDate] [datetime] NULL,
	[PasswordSalt] [nvarchar](128) NOT NULL,
	[PasswordVerificationToken] [nvarchar](128) NULL,
	[PasswordVerificationTokenExpirationDate] [datetime] NULL,
 CONSTRAINT [PK__webpages__1788CC4C75F77EB0] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[webpages_OAuthMembership]    Script Date: 4/25/2019 9:38:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_OAuthMembership](
	[Provider] [nvarchar](30) NOT NULL,
	[ProviderUserId] [nvarchar](100) NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK__webpages__F53FC0ED7226EDCC] PRIMARY KEY CLUSTERED 
(
	[Provider] ASC,
	[ProviderUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[webpages_Roles]    Script Date: 4/25/2019 9:38:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK__webpages__8AFACE1A7BB05806] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ__webpages__8A2B61607E8CC4B1] UNIQUE NONCLUSTERED 
(
	[RoleName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[webpages_Users]    Script Date: 4/25/2019 9:38:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[webpages_Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](128) NULL,
	[DisplayName] [nvarchar](128) NULL,
	[Country] [nvarchar](50) NULL,
	[FullName] [nvarchar](128) NULL,
	[Phone] [nvarchar](128) NULL,
	[Email] [nvarchar](128) NULL,
	[IsLock] [bit] NULL,
	[LoginFail] [int] NULL,
 CONSTRAINT [PK_webpages_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[webpages_UsersInRoles]    Script Date: 4/25/2019 9:38:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_UsersInRoles](
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK__webpages__AF2760AD025D5595] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[BlackList] ADD  CONSTRAINT [DF_BlackList_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[CMS_News] ADD  CONSTRAINT [DF_CMS_News_ShareCount]  DEFAULT ((0)) FOR [ShareCount]
GO
ALTER TABLE [dbo].[Follow] ADD  CONSTRAINT [DF_Follow_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[FriendsList] ADD  CONSTRAINT [DF_FriendsList_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Order] ADD  CONSTRAINT [DF_Order_OrderDiscount]  DEFAULT ((0)) FOR [OrderDiscount]
GO
ALTER TABLE [dbo].[OrderItem] ADD  CONSTRAINT [DF_OrderItem_UnitPrice]  DEFAULT ((0)) FOR [UnitPrice]
GO
ALTER TABLE [dbo].[OrderItem] ADD  CONSTRAINT [DF_OrderItem_DiscountAmount]  DEFAULT ((0)) FOR [DiscountAmount]
GO
ALTER TABLE [dbo].[Post] ADD  CONSTRAINT [DF_Post_Comment]  DEFAULT ((0)) FOR [Comment]
GO
ALTER TABLE [dbo].[Post] ADD  CONSTRAINT [DF_Post_Like]  DEFAULT ((0)) FOR [Like]
GO
ALTER TABLE [dbo].[Post] ADD  CONSTRAINT [DF_Post_IsActived]  DEFAULT ((1)) FOR [IsActived]
GO
ALTER TABLE [dbo].[Post] ADD  CONSTRAINT [DF_Post_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Post] ADD  CONSTRAINT [DF_Post_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Post] ADD  CONSTRAINT [DF_Post_ShareCount]  DEFAULT ((0)) FOR [ShareCount]
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_ViewDoping]  DEFAULT ((0)) FOR [ViewDoping]
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_ShareCount]  DEFAULT ((0)) FOR [ShareCount]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT ((0)) FOR [TokenPrice]
GO
ALTER TABLE [dbo].[Transaction] ADD  DEFAULT ((0)) FOR [Amount]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_Level]  DEFAULT ((0)) FOR [Level]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_UserType]  DEFAULT ((0)) FOR [UserType]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_IsLock]  DEFAULT ((0)) FOR [IsLock]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_LoginFailNumber]  DEFAULT ((0)) FOR [LoginFailNumber]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_NewFollow]  DEFAULT ((0)) FOR [NewFollow]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_NewComment]  DEFAULT ((1)) FOR [NewComment]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_NewMessage]  DEFAULT ((0)) FOR [NewMessage]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_IsActived]  DEFAULT ((0)) FOR [IsActived]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_IsHot]  DEFAULT ((0)) FOR [IsHot]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_IsUpdateAvatar]  DEFAULT ((0)) FOR [IsUpdateAvatar]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_Posts]  DEFAULT ((0)) FOR [Posts]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_Views]  DEFAULT ((0)) FOR [Views]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_Followers]  DEFAULT ((0)) FOR [Followers]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_Following]  DEFAULT ((0)) FOR [Following]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_InCome]  DEFAULT ((0)) FOR [InCome]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_AccountBalance]  DEFAULT ((0)) FOR [AccountBalance]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_AccountPoint]  DEFAULT ((0)) FOR [AccountPoint]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_IsVip]  DEFAULT ((0)) FOR [IsVip]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_IsVerify]  DEFAULT ((0)) FOR [IsVerify]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_IsOnline]  DEFAULT ((0)) FOR [IsOnline]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_IsShowCountry]  DEFAULT ((1)) FOR [IsShowCountry]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_IsShowDate]  DEFAULT ((1)) FOR [IsShowDate]
GO
ALTER TABLE [dbo].[webpages_Membership] ADD  CONSTRAINT [DF__webpages___IsCon__77DFC722]  DEFAULT ((0)) FOR [IsConfirmed]
GO
ALTER TABLE [dbo].[webpages_Membership] ADD  CONSTRAINT [DF__webpages___Passw__78D3EB5B]  DEFAULT ((0)) FOR [PasswordFailuresSinceLastSuccess]
GO
ALTER TABLE [dbo].[webpages_Users] ADD  CONSTRAINT [DF_webpages_Users_IsLock]  DEFAULT ((0)) FOR [IsLock]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'_blank:Mo tab moi; _self:Redirect trang hien tai' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CMS_Banner', @level2type=N'COLUMN',@level2name=N'TargetLink'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CMS_Banner', @level2type=N'COLUMN',@level2name=N'IsActive'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nội dung tóm tắt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CMS_News', @level2type=N'COLUMN',@level2name=N'ShortDescription'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nội dung chi tiết' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CMS_News', @level2type=N'COLUMN',@level2name=N'BodyContent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Từ khóa SEO' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CMS_News', @level2type=N'COLUMN',@level2name=N'MetaKeyword'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Số lượt xem tin' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CMS_News', @level2type=N'COLUMN',@level2name=N'ViewCounter'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ngày phát hành' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CMS_News', @level2type=N'COLUMN',@level2name=N'PublishDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ngày hết hiệu lực' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CMS_News', @level2type=N'COLUMN',@level2name=N'ExpirateDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ngày bắt đầu khuyến mãi' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CMS_News', @level2type=N'COLUMN',@level2name=N'PromoStartDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ngày hết hiệu lực khuyến mãi' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CMS_News', @level2type=N'COLUMN',@level2name=N'PromoExpireDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0:publish;1:Dang soan thao;2:Cho duyet;' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CMS_News', @level2type=N'COLUMN',@level2name=N'Status'
GO
