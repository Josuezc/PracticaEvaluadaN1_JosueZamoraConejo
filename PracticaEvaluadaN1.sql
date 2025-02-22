USE [Practica1jz]
GO
/****** Object:  Table [dbo].[Restaurante]    Script Date: 16/2/2025 09:23:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Restaurante](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](255) NOT NULL,
	[Dueno] [nvarchar](255) NOT NULL,
	[Provincia] [nvarchar](100) NOT NULL,
	[Canton] [nvarchar](100) NOT NULL,
	[Distrito] [nvarchar](100) NOT NULL,
	[DireccionExacta] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
