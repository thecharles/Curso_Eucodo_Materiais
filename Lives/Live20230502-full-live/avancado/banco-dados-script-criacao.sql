USE [lanchonete]
GO
/****** Object:  Table [dbo].[Empresas]    Script Date: 25/04/2023 22:00:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empresas](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[RazaoSocial] [varchar](50) NULL,
	[CNPJ] [varchar](50) NULL,
 CONSTRAINT [PK_Empresas] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Funcionarios]    Script Date: 25/04/2023 22:00:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Funcionarios](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nome] [varchar](50) NOT NULL,
	[cpf] [varchar](50) NULL,
	[email] [varchar](200) NULL,
	[perfil] [varchar](50) NULL,
	[login] [varchar](50) NULL,
	[senha] [varchar](50) NULL,
	[dataUltimoAcesso] [datetime] NULL,
	[situacao] [bit] NULL,
	[idEmpresa] [int] NULL,
 CONSTRAINT [PK_Funcionarios] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mesas]    Script Date: 25/04/2023 22:00:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mesas](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idFuncionario] [int] NOT NULL,
	[nome] [varchar](50) NULL,
	[situacao] [varchar](50) NULL,
	[data] [datetime] NULL,
	[idEmpresa] [int] NULL,
 CONSTRAINT [PK_Mesas] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MesasPedidos]    Script Date: 25/04/2023 22:00:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MesasPedidos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idMesa] [int] NOT NULL,
	[idProduto] [int] NOT NULL,
	[quantidade] [int] NOT NULL,
 CONSTRAINT [PK_MesasPedidos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Produtos]    Script Date: 25/04/2023 22:00:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Produtos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nome] [varchar](50) NOT NULL,
	[precoCusto] [decimal](18, 2) NOT NULL,
	[estoqueAtual] [int] NOT NULL,
	[estoqueMinimo] [int] NOT NULL,
	[precoVenda] [decimal](18, 2) NULL,
	[idEmpresa] [int] NULL,
 CONSTRAINT [PK_Produtos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Funcionarios]  WITH CHECK ADD  CONSTRAINT [fk_funcionarios_empresas] FOREIGN KEY([idEmpresa])
REFERENCES [dbo].[Empresas] ([id])
GO
ALTER TABLE [dbo].[Funcionarios] CHECK CONSTRAINT [fk_funcionarios_empresas]
GO
ALTER TABLE [dbo].[Mesas]  WITH CHECK ADD  CONSTRAINT [fk_mesas_empresas] FOREIGN KEY([idEmpresa])
REFERENCES [dbo].[Empresas] ([id])
GO
ALTER TABLE [dbo].[Mesas] CHECK CONSTRAINT [fk_mesas_empresas]
GO
ALTER TABLE [dbo].[Mesas]  WITH CHECK ADD  CONSTRAINT [fk_mesas_funcionarios] FOREIGN KEY([id])
REFERENCES [dbo].[Funcionarios] ([id])
GO
ALTER TABLE [dbo].[Mesas] CHECK CONSTRAINT [fk_mesas_funcionarios]
GO
ALTER TABLE [dbo].[MesasPedidos]  WITH CHECK ADD  CONSTRAINT [fk_mesa_mesapedidos] FOREIGN KEY([idMesa])
REFERENCES [dbo].[Mesas] ([id])
GO
ALTER TABLE [dbo].[MesasPedidos] CHECK CONSTRAINT [fk_mesa_mesapedidos]
GO
ALTER TABLE [dbo].[MesasPedidos]  WITH CHECK ADD  CONSTRAINT [fk_mesapedidos_produtos] FOREIGN KEY([idProduto])
REFERENCES [dbo].[Produtos] ([id])
GO
ALTER TABLE [dbo].[MesasPedidos] CHECK CONSTRAINT [fk_mesapedidos_produtos]
GO
ALTER TABLE [dbo].[Produtos]  WITH CHECK ADD  CONSTRAINT [fk_empresas_produtos] FOREIGN KEY([idEmpresa])
REFERENCES [dbo].[Empresas] ([id])
GO
ALTER TABLE [dbo].[Produtos] CHECK CONSTRAINT [fk_empresas_produtos]
GO
