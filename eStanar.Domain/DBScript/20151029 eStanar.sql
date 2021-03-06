USE [eStanar]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 29.10.2015. 10:11:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[IdAccount] [int] IDENTITY(1,1) NOT NULL,
	[IdPerson] [int] NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[IdAccount] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[City]    Script Date: 29.10.2015. 10:11:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[City](
	[IdCity] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[PostalCode] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[IdCity] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Document]    Script Date: 29.10.2015. 10:11:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Document](
	[IdDocument] [int] IDENTITY(1,1) NOT NULL,
	[IdStructure] [int] NOT NULL,
	[IdEntrance] [int] NULL,
	[FileType] [nvarchar](50) NOT NULL,
	[Data] [varbinary](max) NOT NULL,
	[Title] [nvarchar](250) NOT NULL,
	[Description] [nvarchar](250) NULL,
	[IdAuthor] [int] NOT NULL,
	[DateCreated] [Datetime] NOT NULL,
 CONSTRAINT [PK_Document] PRIMARY KEY CLUSTERED 
(
	[IdDocument] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TextIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Entrance]    Script Date: 29.10.2015. 10:11:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Entrance](
	[IdEntrance] [int] IDENTITY(1,1) NOT NULL,
	[IdEntranceType] [int] NOT NULL,
	[IdStructure] [int] NOT NULL,
	[EntranceNumber] [nvarchar](10) NULL,
 CONSTRAINT [PK_Entrance] PRIMARY KEY CLUSTERED 
(
	[IdEntrance] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EntranceType]    Script Date: 29.10.2015. 10:11:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EntranceType](
	[IdEntranceType] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_EntranceType] PRIMARY KEY CLUSTERED 
(
	[IdEntranceType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Meeting]    Script Date: 29.10.2015. 10:11:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Meeting](
	[IdMeeting] [int] IDENTITY(1,1) NOT NULL,
	[IdMeetingType] [int] NOT NULL,
	[DateCreated] [Datetime] NOT NULL,
	[DateOfMeeting] [Datetime] NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](250) NULL,
	[Priority] [numeric](1, 0) NOT NULL,
 CONSTRAINT [PK_Meeting] PRIMARY KEY CLUSTERED 
(
	[IdMeeting] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MeetingType]    Script Date: 29.10.2015. 10:11:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MeetingType](
	[IdMeetingType] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_MeetingType] PRIMARY KEY CLUSTERED 
(
	[IdMeetingType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Notice]    Script Date: 29.10.2015. 10:11:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notice](
	[IdNotice] [int] IDENTITY(1,1) NOT NULL,
	[IdNoticeType] [int] NOT NULL,
	[IdStructure] [int] NOT NULL,
	[Text] [nvarchar](1000) NOT NULL,
	[IdAuthor] [int] NOT NULL,
	[Date] [Date] NOT NULL,
	[IdEntrance] [int] NULL,
	[IdMeeting] [int] NULL,
 CONSTRAINT [PK_Notice] PRIMARY KEY CLUSTERED 
(
	[IdNotice] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NoticeComment]    Script Date: 29.10.2015. 10:11:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NoticeComment](
	[IdNoticeComment] [int] IDENTITY(1,1) NOT NULL,
	[IdNotice] [int] NOT NULL,
	[Text] [nvarchar](1000) NOT NULL,
	[IdAuthor] [int] NOT NULL,
	[Date] [Datetime] NOT NULL,
 CONSTRAINT [PK_NoticeComment] PRIMARY KEY CLUSTERED 
(
	[IdNoticeComment] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NoticeType]    Script Date: 29.10.2015. 10:11:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NoticeType](
	[IdNoticeType] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_NoticeType] PRIMARY KEY CLUSTERED 
(
	[IdNoticeType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Occupant]    Script Date: 29.10.2015. 10:11:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Occupant](
	[IdOccupant] [int] IDENTITY(1,1) NOT NULL,
	[IdStructurePart] [int] NOT NULL,
	[IdPerson] [int] NOT NULL,
 CONSTRAINT [PK_Occupant] PRIMARY KEY CLUSTERED 
(
	[IdOccupant] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Owner]    Script Date: 29.10.2015. 10:11:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Owner](
	[IdOwner] [int] IDENTITY(1,1) NOT NULL,
	[IdStructurePart] [int] NOT NULL,
	[IdPerson] [int] NOT NULL,
 CONSTRAINT [PK_Owner] PRIMARY KEY CLUSTERED 
(
	[IdOwner] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Person]    Script Date: 29.10.2015. 10:11:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[IdPerson] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[LastName] [nvarchar](250) NOT NULL,
	[Telephone] [nvarchar](50) NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[IdPerson] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Poll]    Script Date: 29.10.2015. 10:11:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Poll](
	[IdPoll] [int] IDENTITY(1,1) NOT NULL,
	[IdNotice] [int] NOT NULL,
	[Title] [nvarchar](250) NOT NULL,
	[DateFrom] [Datetime] NOT NULL,
	[DateTo] [Datetime] NULL,
 CONSTRAINT [PK_Poll] PRIMARY KEY CLUSTERED 
(
	[IdPoll] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PollOption]    Script Date: 29.10.2015. 10:11:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PollOption](
	[IdPollOption] [int] IDENTITY(1,1) NOT NULL,
	[IdPoll] [int] NOT NULL,
	[Text] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_PollOption] PRIMARY KEY CLUSTERED 
(
	[IdPollOption] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PollVote]    Script Date: 29.10.2015. 10:11:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PollVote](
	[IdPollVote] [int] IDENTITY(1,1) NOT NULL,
	[IdPollOption] [int] NOT NULL,
	[IdPerson] [int] NOT NULL,
	[Date] [Datetime] NOT NULL,
 CONSTRAINT [PK_PollVote] PRIMARY KEY CLUSTERED 
(
	[IdPollVote] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Representative]    Script Date: 29.10.2015. 10:11:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Representative](
	[IdRepresentative] [int] IDENTITY(1,1) NOT NULL,
	[IdStructure] [int] NOT NULL,
	[IdPerson] [int] NOT NULL,
	[DateFrom] [Date] NOT NULL,
	[DateTo] [Date] NULL,
 CONSTRAINT [PK_Representative] PRIMARY KEY CLUSTERED 
(
	[IdRepresentative] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Structure]    Script Date: 29.10.2015. 10:11:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Structure](
	[IdStructure] [int] IDENTITY(1,1) NOT NULL,
	[IdStructureType] [int] NOT NULL,
	[IdCity] [int] NOT NULL,
	[NumberOfFloors] [numeric](3, 0) NOT NULL,
	[Address] [nvarchar](250) NOT NULL,
	[Description] [nvarchar](250) NULL,
 CONSTRAINT [PK_Structure] PRIMARY KEY CLUSTERED 
(
	[IdStructure] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StructurePart]    Script Date: 29.10.2015. 10:11:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StructurePart](
	[IdStructurePart] [int] IDENTITY(1,1) NOT NULL,
	[IdStructurePartType] [int] NOT NULL,
	[IdEntrance] [int] NOT NULL,
	[AreaInSquareMeters] [decimal](6, 2) NULL,
 CONSTRAINT [PK_StructurePart] PRIMARY KEY CLUSTERED 
(
	[IdStructurePart] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StructurePartType]    Script Date: 29.10.2015. 10:11:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StructurePartType](
	[IdStructurePartType] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_StructurePartType] PRIMARY KEY CLUSTERED 
(
	[IdStructurePartType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StructureType]    Script Date: 29.10.2015. 10:11:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StructureType](
	[IdStructureType] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_StructureType] PRIMARY KEY CLUSTERED 
(
	[IdStructureType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK1_Account] FOREIGN KEY([IdPerson])
REFERENCES [dbo].[Person] ([IdPerson])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK1_Account]
GO
ALTER TABLE [dbo].[Document]  WITH CHECK ADD  CONSTRAINT [FK1_Document] FOREIGN KEY([IdStructure])
REFERENCES [dbo].[Structure] ([IdStructure])
GO
ALTER TABLE [dbo].[Document] CHECK CONSTRAINT [FK1_Document]
GO
ALTER TABLE [dbo].[Document]  WITH CHECK ADD  CONSTRAINT [FK2_Document] FOREIGN KEY([IdEntrance])
REFERENCES [dbo].[Entrance] ([IdEntrance])
GO
ALTER TABLE [dbo].[Document] CHECK CONSTRAINT [FK2_Document]
GO
ALTER TABLE [dbo].[Document]  WITH CHECK ADD  CONSTRAINT [FK3_Document] FOREIGN KEY([IdAuthor])
REFERENCES [dbo].[Person] ([IdPerson])
GO
ALTER TABLE [dbo].[Document] CHECK CONSTRAINT [FK3_Document]
GO
ALTER TABLE [dbo].[Entrance]  WITH CHECK ADD  CONSTRAINT [FK1_Entrance] FOREIGN KEY([IdEntranceType])
REFERENCES [dbo].[EntranceType] ([IdEntranceType])
GO
ALTER TABLE [dbo].[Entrance] CHECK CONSTRAINT [FK1_Entrance]
GO
ALTER TABLE [dbo].[Entrance]  WITH CHECK ADD  CONSTRAINT [FK2_Entrance] FOREIGN KEY([IdStructure])
REFERENCES [dbo].[Structure] ([IdStructure])
GO
ALTER TABLE [dbo].[Entrance] CHECK CONSTRAINT [FK2_Entrance]
GO
ALTER TABLE [dbo].[Meeting]  WITH CHECK ADD  CONSTRAINT [FK1_Meeting] FOREIGN KEY([IdMeetingType])
REFERENCES [dbo].[MeetingType] ([IdMeetingType])
GO
ALTER TABLE [dbo].[Meeting] CHECK CONSTRAINT [FK1_Meeting]
GO
ALTER TABLE [dbo].[Notice]  WITH CHECK ADD  CONSTRAINT [FK1_Notice] FOREIGN KEY([IdNoticeType])
REFERENCES [dbo].[NoticeType] ([IdNoticeType])
GO
ALTER TABLE [dbo].[Notice] CHECK CONSTRAINT [FK1_Notice]
GO
ALTER TABLE [dbo].[Notice]  WITH CHECK ADD  CONSTRAINT [FK2_Notice] FOREIGN KEY([IdStructure])
REFERENCES [dbo].[Structure] ([IdStructure])
GO
ALTER TABLE [dbo].[Notice] CHECK CONSTRAINT [FK2_Notice]
GO
ALTER TABLE [dbo].[Notice]  WITH CHECK ADD  CONSTRAINT [FK3_Notice] FOREIGN KEY([IdAuthor])
REFERENCES [dbo].[Person] ([IdPerson])
GO
ALTER TABLE [dbo].[Notice] CHECK CONSTRAINT [FK3_Notice]
GO
ALTER TABLE [dbo].[Notice]  WITH CHECK ADD  CONSTRAINT [FK4_Notice] FOREIGN KEY([IdEntrance])
REFERENCES [dbo].[Entrance] ([IdEntrance])
GO
ALTER TABLE [dbo].[Notice] CHECK CONSTRAINT [FK4_Notice]
GO
ALTER TABLE [dbo].[Notice]  WITH CHECK ADD  CONSTRAINT [FK5_Notice] FOREIGN KEY([IdMeeting])
REFERENCES [dbo].[Meeting] ([IdMeeting])
GO
ALTER TABLE [dbo].[Notice] CHECK CONSTRAINT [FK5_Notice]
GO
ALTER TABLE [dbo].[NoticeComment]  WITH CHECK ADD  CONSTRAINT [FK1_NoticeComment] FOREIGN KEY([IdNotice])
REFERENCES [dbo].[Notice] ([IdNotice])
GO
ALTER TABLE [dbo].[NoticeComment] CHECK CONSTRAINT [FK1_NoticeComment]
GO
ALTER TABLE [dbo].[NoticeComment]  WITH CHECK ADD  CONSTRAINT [FK2_NoticeComment] FOREIGN KEY([IdAuthor])
REFERENCES [dbo].[Person] ([IdPerson])
GO
ALTER TABLE [dbo].[NoticeComment] CHECK CONSTRAINT [FK2_NoticeComment]
GO
ALTER TABLE [dbo].[Occupant]  WITH CHECK ADD  CONSTRAINT [FK1_Occupant] FOREIGN KEY([IdStructurePart])
REFERENCES [dbo].[StructurePart] ([IdStructurePart])
GO
ALTER TABLE [dbo].[Occupant] CHECK CONSTRAINT [FK1_Occupant]
GO
ALTER TABLE [dbo].[Occupant]  WITH CHECK ADD  CONSTRAINT [FK2_Occupant] FOREIGN KEY([IdPerson])
REFERENCES [dbo].[Person] ([IdPerson])
GO
ALTER TABLE [dbo].[Occupant] CHECK CONSTRAINT [FK2_Occupant]
GO
ALTER TABLE [dbo].[Owner]  WITH CHECK ADD  CONSTRAINT [FK1_Owner] FOREIGN KEY([IdStructurePart])
REFERENCES [dbo].[StructurePart] ([IdStructurePart])
GO
ALTER TABLE [dbo].[Owner] CHECK CONSTRAINT [FK1_Owner]
GO
ALTER TABLE [dbo].[Owner]  WITH CHECK ADD  CONSTRAINT [FK2_Owner] FOREIGN KEY([IdPerson])
REFERENCES [dbo].[Person] ([IdPerson])
GO
ALTER TABLE [dbo].[Owner] CHECK CONSTRAINT [FK2_Owner]
GO
ALTER TABLE [dbo].[Poll]  WITH CHECK ADD  CONSTRAINT [FK1_Poll] FOREIGN KEY([IdNotice])
REFERENCES [dbo].[Notice] ([IdNotice])
GO
ALTER TABLE [dbo].[Poll] CHECK CONSTRAINT [FK1_Poll]
GO
ALTER TABLE [dbo].[PollOption]  WITH CHECK ADD  CONSTRAINT [FK1_PollOption] FOREIGN KEY([IdPoll])
REFERENCES [dbo].[Poll] ([IdPoll])
GO
ALTER TABLE [dbo].[PollOption] CHECK CONSTRAINT [FK1_PollOption]
GO
ALTER TABLE [dbo].[PollVote]  WITH CHECK ADD  CONSTRAINT [FK1_PollVote] FOREIGN KEY([IdPollOption])
REFERENCES [dbo].[PollOption] ([IdPollOption])
GO
ALTER TABLE [dbo].[PollVote] CHECK CONSTRAINT [FK1_PollVote]
GO
ALTER TABLE [dbo].[PollVote]  WITH CHECK ADD  CONSTRAINT [FK2_PollVote] FOREIGN KEY([IdPerson])
REFERENCES [dbo].[Person] ([IdPerson])
GO
ALTER TABLE [dbo].[PollVote] CHECK CONSTRAINT [FK2_PollVote]
GO
ALTER TABLE [dbo].[Representative]  WITH CHECK ADD  CONSTRAINT [FK1_Representative] FOREIGN KEY([IdStructure])
REFERENCES [dbo].[Structure] ([IdStructure])
GO
ALTER TABLE [dbo].[Representative] CHECK CONSTRAINT [FK1_Representative]
GO
ALTER TABLE [dbo].[Representative]  WITH CHECK ADD  CONSTRAINT [FK2_Representative] FOREIGN KEY([IdPerson])
REFERENCES [dbo].[Person] ([IdPerson])
GO
ALTER TABLE [dbo].[Representative] CHECK CONSTRAINT [FK2_Representative]
GO
ALTER TABLE [dbo].[Structure]  WITH CHECK ADD  CONSTRAINT [FK1_Structure] FOREIGN KEY([IdStructureType])
REFERENCES [dbo].[StructureType] ([IdStructureType])
GO
ALTER TABLE [dbo].[Structure] CHECK CONSTRAINT [FK1_Structure]
GO
ALTER TABLE [dbo].[Structure]  WITH CHECK ADD  CONSTRAINT [FK2_Structure] FOREIGN KEY([IdCity])
REFERENCES [dbo].[City] ([IdCity])
GO
ALTER TABLE [dbo].[Structure] CHECK CONSTRAINT [FK2_Structure]
GO
ALTER TABLE [dbo].[StructurePart]  WITH CHECK ADD  CONSTRAINT [FK1_StructurePart] FOREIGN KEY([IdStructurePartType])
REFERENCES [dbo].[StructurePartType] ([IdStructurePartType])
GO
ALTER TABLE [dbo].[StructurePart] CHECK CONSTRAINT [FK1_StructurePart]
GO
ALTER TABLE [dbo].[StructurePart]  WITH CHECK ADD  CONSTRAINT [FK2_StructurePart] FOREIGN KEY([IdEntrance])
REFERENCES [dbo].[Entrance] ([IdEntrance])
GO
ALTER TABLE [dbo].[StructurePart] CHECK CONSTRAINT [FK2_StructurePart]
GO
USE [master]
GO
ALTER DataBASE [eStanar] SET  READ_WRITE 
GO
