USE [InfoTrackSEOApp]
GO

CREATE TABLE [dbo].[SearchResults](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SearchEngineName] [varchar](50) NOT NULL,
	[KeywordToSearch] [nvarchar](80) NOT NULL,
	[Url] [nvarchar](600) NOT NULL,
	[Ranks] [nvarchar](200) NOT NULL,
	[SearchDate] [datetime] NOT NULL,
 CONSTRAINT [PK_SearchResults] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[SearchResults] ADD  CONSTRAINT [DF_SearchResults_SearchDate]  DEFAULT (getdate()) FOR [SearchDate]
GO

CREATE PROC [dbo].[AddSearchResults]

@SearchEngineName	varchar(50),
@KeywordToSearch	nvarchar(80),
@Url	nvarchar(600),
@Ranks	nvarchar(200)

AS

INSERT INTO SearchResults(SearchEngineName,KeywordToSearch,Url,Ranks)
VALUES(@SearchEngineName,@KeywordToSearch,@Url,@Ranks)

GO

CREATE PROC [dbo].[GetAllSearchResults]

AS

SELECT SearchEngineName,KeywordToSearch,Url,Ranks,SearchDate 
FROM SearchResults

GO

INSERT INTO [dbo].[SearchResults]
           ([SearchEngineName]
           ,[KeywordToSearch]
           ,[Url]
           ,[Ranks])
     VALUES
           ('Google',
           'land registry searches',
           'www.infotrack.co.uk',
           0)
GO


