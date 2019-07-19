USE [kiosko]
GO

/****** Object:  Table [dbo].[ClienteDB]    Script Date: 19/07/2019 01:13:11 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ClienteDB](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Customer] [nvarchar](50) NOT NULL,
	[Account] [bigint] NOT NULL,
	[Debt] [float] NOT NULL,
	[Paid] [float] NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_ClienteDB] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_ClienteDB] UNIQUE NONCLUSTERED 
(
	[Account] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

