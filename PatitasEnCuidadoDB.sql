USE [PatitasEnCuidadoDB]
GO
/****** Object:  Table [dbo].[Adoptantes]    Script Date: 26/10/2024 3:16:21 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Adoptantes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NombreAdoptante] [nvarchar](max) NULL,
	[NumeroDocumento] [nvarchar](max) NULL,
	[NumeroContacto] [nvarchar](max) NULL,
	[NumeroEmergencia] [nvarchar](max) NULL,
	[Imagen] [nvarchar](max) NULL,
	[DireccionResidencia] [nvarchar](max) NULL,
 CONSTRAINT [PK_Adoptantes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AnimalAdoptantes]    Script Date: 26/10/2024 3:16:21 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AnimalAdoptantes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdAdoptante] [int] NOT NULL,
	[IdAnimal] [int] NOT NULL,
	[AnimalesAdoptados] [int] NOT NULL,
 CONSTRAINT [PK_AnimalAdoptantes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Animales]    Script Date: 26/10/2024 3:16:21 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Animales](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NombreAnimal] [nvarchar](max) NULL,
	[UrlImagen] [nvarchar](max) NULL,
	[FechaIngreso] [datetime2](7) NOT NULL,
	[EstadoSalud] [nvarchar](max) NULL,
	[Observaciones] [nvarchar](max) NULL,
	[Procedencia] [nvarchar](max) NULL,
	[Edad] [int] NOT NULL,
	[Raza] [nvarchar](max) NULL,
	[IdAdoptante] [int] NOT NULL,
	[IdVacunasId] [int] NOT NULL,
	[IdTipoAnimal] [int] NOT NULL,
	[IdFundacion] [int] NOT NULL,
 CONSTRAINT [PK_Animales] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AnimalFundaciones]    Script Date: 26/10/2024 3:16:21 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AnimalFundaciones](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdFundacion] [int] NOT NULL,
	[IdAnimal] [int] NOT NULL,
 CONSTRAINT [PK_AnimalFundaciones] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fundaciones]    Script Date: 26/10/2024 3:16:21 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fundaciones](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NombreFundacion] [nvarchar](max) NULL,
	[Estado] [bit] NOT NULL,
	[Nit] [nvarchar](max) NULL,
	[Descripcion] [nvarchar](max) NULL,
 CONSTRAINT [PK_Fundaciones] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoAnimales]    Script Date: 26/10/2024 3:16:21 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoAnimales](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NombreTipoAnimal] [nvarchar](max) NULL,
	[Descripcion] [nvarchar](max) NULL,
 CONSTRAINT [PK_TipoAnimales] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vacunas]    Script Date: 26/10/2024 3:16:21 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vacunas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NombreVacuna] [nvarchar](max) NULL,
	[FechaCaducidad] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Vacunas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
