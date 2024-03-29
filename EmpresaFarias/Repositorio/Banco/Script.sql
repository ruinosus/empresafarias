SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Plano]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Plano](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](50) NOT NULL,
	[Descricao] [varchar](5000) NOT NULL,
	[ValorPadrao] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_Plano] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Usuario]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Login] [varchar](8) NOT NULL,
	[Senha] [varchar](8) NOT NULL,
	[Nome] [varchar](50) NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK__Usuario__6477ECF3] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Perfil]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Perfil](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](30) NOT NULL,
 CONSTRAINT [PK__Perfil__628FA481] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Estados]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Estados](
	[Id] [int] NOT NULL,
	[Nome] [varchar](50) NOT NULL,
	[Sigla] [varchar](2) NOT NULL,
 CONSTRAINT [PK_Estado] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Contrato]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Contrato](
	[Id] [int] NOT NULL,
	[DataInicio] [datetime] NOT NULL,
	[Status] [int] NOT NULL,
	[TitularId] [int] NOT NULL,
	[PlanoId] [int] NOT NULL,
 CONSTRAINT [PK_Contrato_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[HistoricoContrato]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[HistoricoContrato](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DataInicio] [datetime] NOT NULL,
	[Status] [int] NOT NULL,
	[TitularId] [int] NOT NULL,
	[PlanoId] [int] NOT NULL,
	[ContratoId] [int] NOT NULL,
	[DataAlteracao] [datetime] NOT NULL,
	[UsuarioId] [int] NOT NULL,
	[Descricao] [varchar](4000) NOT NULL,
 CONSTRAINT [PK_HistoricoContrato_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[HistoricoDependente]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[HistoricoDependente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](50) NOT NULL,
	[Religiao] [varchar](50) NOT NULL,
	[DataNascimento] [datetime] NOT NULL,
	[TitularId] [int] NOT NULL,
	[Parentesco] [varchar](30) NOT NULL,
	[PercentualCobertura] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[DependenteId] [int] NOT NULL,
	[DataAlteracao] [datetime] NOT NULL,
	[UsuarioId] [int] NOT NULL,
	[Descricao] [varchar](4000) NOT NULL,
 CONSTRAINT [PK_HistoricoDependente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UsuarioPerfil]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[UsuarioPerfil](
	[UsuarioId] [int] NOT NULL,
	[PerfilId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UsuarioId] ASC,
	[PerfilId] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[HistoricoParcela]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[HistoricoParcela](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DataPagamento] [datetime] NULL,
	[DataVencimento] [datetime] NOT NULL,
	[Valor] [decimal](18, 0) NOT NULL,
	[NumeroParcela] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[ContratoId] [int] NOT NULL,
	[ParcelaId] [int] NOT NULL,
	[DataAlteracao] [datetime] NOT NULL,
	[UsuarioId] [int] NOT NULL,
	[Descricao] [varchar](4000) NOT NULL,
 CONSTRAINT [PK_HistoricoParcela] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[HistoricoTitular]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[HistoricoTitular](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](50) NOT NULL,
	[Religiao] [varchar](50) NOT NULL,
	[DataNascimento] [datetime] NOT NULL,
	[Sexo] [char](1) NOT NULL,
	[EstadoCivil] [varchar](30) NOT NULL,
	[Cpf] [varchar](11) NULL,
	[Logradouro] [varchar](50) NOT NULL,
	[Numero] [varchar](10) NOT NULL,
	[Complemento] [varchar](50) NOT NULL,
	[Bairro] [varchar](50) NOT NULL,
	[Cep] [varchar](10) NOT NULL,
	[CidadeEnderecoId] [int] NOT NULL,
	[CidadeNaturalidadeId] [int] NOT NULL,
	[TelefoneResidencial] [varchar](15) NULL,
	[TelefoneCelular] [varchar](15) NULL,
	[Rg] [varchar](7) NULL,
	[DataExpedicao] [datetime] NULL,
	[OrgaoExpeditor] [varchar](5) NULL,
	[Status] [int] NOT NULL,
	[TitularId] [int] NOT NULL,
	[DataAlteracao] [datetime] NOT NULL,
	[UsuarioId] [int] NOT NULL,
	[Descricao] [varchar](4000) NOT NULL,
 CONSTRAINT [PK_HistoricoTitular] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tag]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Tag](
	[PerfilId] [int] NOT NULL,
	[TagId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PerfilId] ASC,
	[TagId] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Dependente]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Dependente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](50) NOT NULL,
	[Religiao] [varchar](50) NOT NULL,
	[DataNascimento] [datetime] NOT NULL,
	[TitularId] [int] NOT NULL,
	[Parentesco] [varchar](30) NOT NULL,
	[PercentualCobertura] [int] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Dependente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Parcela]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Parcela](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DataPagamento] [datetime] NULL,
	[DataVencimento] [datetime] NOT NULL,
	[Valor] [decimal](18, 0) NOT NULL,
	[NumeroParcela] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[ContratoId] [int] NOT NULL,
 CONSTRAINT [PK_Parcela] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cidades]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Cidades](
	[Id] [int] NOT NULL,
	[EstadoId] [int] NOT NULL,
	[Nome] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Cidade] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Titular]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Titular](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](50) NOT NULL,
	[Religiao] [varchar](50) NOT NULL,
	[DataNascimento] [datetime] NOT NULL,
	[Sexo] [char](1) NOT NULL,
	[EstadoCivil] [varchar](30) NOT NULL,
	[Cpf] [varchar](11) NULL,
	[Logradouro] [varchar](50) NOT NULL,
	[Numero] [varchar](10) NOT NULL,
	[Complemento] [varchar](50) NOT NULL,
	[Bairro] [varchar](50) NOT NULL,
	[Cep] [varchar](10) NOT NULL,
	[CidadeEnderecoId] [int] NOT NULL,
	[CidadeNaturalidadeId] [int] NOT NULL,
	[TelefoneResidencial] [varchar](15) NULL,
	[TelefoneCelular] [varchar](15) NULL,
	[Rg] [varchar](7) NULL,
	[DataExpedicao] [datetime] NULL,
	[OrgaoExpeditor] [varchar](5) NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Titular] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Contrato_Plano]') AND parent_object_id = OBJECT_ID(N'[dbo].[Contrato]'))
ALTER TABLE [dbo].[Contrato]  WITH CHECK ADD  CONSTRAINT [FK_Contrato_Plano] FOREIGN KEY([PlanoId])
REFERENCES [dbo].[Plano] ([Id])
GO
ALTER TABLE [dbo].[Contrato] CHECK CONSTRAINT [FK_Contrato_Plano]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Contrato_Titular]') AND parent_object_id = OBJECT_ID(N'[dbo].[Contrato]'))
ALTER TABLE [dbo].[Contrato]  WITH CHECK ADD  CONSTRAINT [FK_Contrato_Titular] FOREIGN KEY([TitularId])
REFERENCES [dbo].[Titular] ([Id])
GO
ALTER TABLE [dbo].[Contrato] CHECK CONSTRAINT [FK_Contrato_Titular]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_HistoricoContrato_Contrato]') AND parent_object_id = OBJECT_ID(N'[dbo].[HistoricoContrato]'))
ALTER TABLE [dbo].[HistoricoContrato]  WITH CHECK ADD  CONSTRAINT [FK_HistoricoContrato_Contrato] FOREIGN KEY([ContratoId])
REFERENCES [dbo].[Contrato] ([Id])
GO
ALTER TABLE [dbo].[HistoricoContrato] CHECK CONSTRAINT [FK_HistoricoContrato_Contrato]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_HistoricoContrato_Plano]') AND parent_object_id = OBJECT_ID(N'[dbo].[HistoricoContrato]'))
ALTER TABLE [dbo].[HistoricoContrato]  WITH CHECK ADD  CONSTRAINT [FK_HistoricoContrato_Plano] FOREIGN KEY([PlanoId])
REFERENCES [dbo].[Plano] ([Id])
GO
ALTER TABLE [dbo].[HistoricoContrato] CHECK CONSTRAINT [FK_HistoricoContrato_Plano]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_HistoricoContrato_Titular]') AND parent_object_id = OBJECT_ID(N'[dbo].[HistoricoContrato]'))
ALTER TABLE [dbo].[HistoricoContrato]  WITH CHECK ADD  CONSTRAINT [FK_HistoricoContrato_Titular] FOREIGN KEY([TitularId])
REFERENCES [dbo].[Titular] ([Id])
GO
ALTER TABLE [dbo].[HistoricoContrato] CHECK CONSTRAINT [FK_HistoricoContrato_Titular]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_HistoricoContrato_Usuario]') AND parent_object_id = OBJECT_ID(N'[dbo].[HistoricoContrato]'))
ALTER TABLE [dbo].[HistoricoContrato]  WITH CHECK ADD  CONSTRAINT [FK_HistoricoContrato_Usuario] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[HistoricoContrato] CHECK CONSTRAINT [FK_HistoricoContrato_Usuario]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_HistoricoDependente_Dependente]') AND parent_object_id = OBJECT_ID(N'[dbo].[HistoricoDependente]'))
ALTER TABLE [dbo].[HistoricoDependente]  WITH CHECK ADD  CONSTRAINT [FK_HistoricoDependente_Dependente] FOREIGN KEY([DependenteId])
REFERENCES [dbo].[Dependente] ([Id])
GO
ALTER TABLE [dbo].[HistoricoDependente] CHECK CONSTRAINT [FK_HistoricoDependente_Dependente]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_HistoricoDependente_Titular]') AND parent_object_id = OBJECT_ID(N'[dbo].[HistoricoDependente]'))
ALTER TABLE [dbo].[HistoricoDependente]  WITH CHECK ADD  CONSTRAINT [FK_HistoricoDependente_Titular] FOREIGN KEY([TitularId])
REFERENCES [dbo].[Titular] ([Id])
GO
ALTER TABLE [dbo].[HistoricoDependente] CHECK CONSTRAINT [FK_HistoricoDependente_Titular]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_HistoricoDependente_Usuario]') AND parent_object_id = OBJECT_ID(N'[dbo].[HistoricoDependente]'))
ALTER TABLE [dbo].[HistoricoDependente]  WITH CHECK ADD  CONSTRAINT [FK_HistoricoDependente_Usuario] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[HistoricoDependente] CHECK CONSTRAINT [FK_HistoricoDependente_Usuario]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UsuarioPerfil_Perfil]') AND parent_object_id = OBJECT_ID(N'[dbo].[UsuarioPerfil]'))
ALTER TABLE [dbo].[UsuarioPerfil]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioPerfil_Perfil] FOREIGN KEY([PerfilId])
REFERENCES [dbo].[Perfil] ([Id])
GO
ALTER TABLE [dbo].[UsuarioPerfil] CHECK CONSTRAINT [FK_UsuarioPerfil_Perfil]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UsuarioPerfil_Usuario]') AND parent_object_id = OBJECT_ID(N'[dbo].[UsuarioPerfil]'))
ALTER TABLE [dbo].[UsuarioPerfil]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioPerfil_Usuario] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[UsuarioPerfil] CHECK CONSTRAINT [FK_UsuarioPerfil_Usuario]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_HistoricoParcela_Contrato]') AND parent_object_id = OBJECT_ID(N'[dbo].[HistoricoParcela]'))
ALTER TABLE [dbo].[HistoricoParcela]  WITH CHECK ADD  CONSTRAINT [FK_HistoricoParcela_Contrato] FOREIGN KEY([ContratoId])
REFERENCES [dbo].[Contrato] ([Id])
GO
ALTER TABLE [dbo].[HistoricoParcela] CHECK CONSTRAINT [FK_HistoricoParcela_Contrato]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_HistoricoParcela_Parcela]') AND parent_object_id = OBJECT_ID(N'[dbo].[HistoricoParcela]'))
ALTER TABLE [dbo].[HistoricoParcela]  WITH CHECK ADD  CONSTRAINT [FK_HistoricoParcela_Parcela] FOREIGN KEY([ParcelaId])
REFERENCES [dbo].[Parcela] ([Id])
GO
ALTER TABLE [dbo].[HistoricoParcela] CHECK CONSTRAINT [FK_HistoricoParcela_Parcela]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_HistoricoParcela_Usuario]') AND parent_object_id = OBJECT_ID(N'[dbo].[HistoricoParcela]'))
ALTER TABLE [dbo].[HistoricoParcela]  WITH CHECK ADD  CONSTRAINT [FK_HistoricoParcela_Usuario] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[HistoricoParcela] CHECK CONSTRAINT [FK_HistoricoParcela_Usuario]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_HistoricoTitular_Cidades_Endereco]') AND parent_object_id = OBJECT_ID(N'[dbo].[HistoricoTitular]'))
ALTER TABLE [dbo].[HistoricoTitular]  WITH CHECK ADD  CONSTRAINT [FK_HistoricoTitular_Cidades_Endereco] FOREIGN KEY([CidadeEnderecoId])
REFERENCES [dbo].[Cidades] ([Id])
GO
ALTER TABLE [dbo].[HistoricoTitular] CHECK CONSTRAINT [FK_HistoricoTitular_Cidades_Endereco]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_HistoricoTitular_Cidades_Naturalidade]') AND parent_object_id = OBJECT_ID(N'[dbo].[HistoricoTitular]'))
ALTER TABLE [dbo].[HistoricoTitular]  WITH CHECK ADD  CONSTRAINT [FK_HistoricoTitular_Cidades_Naturalidade] FOREIGN KEY([CidadeNaturalidadeId])
REFERENCES [dbo].[Cidades] ([Id])
GO
ALTER TABLE [dbo].[HistoricoTitular] CHECK CONSTRAINT [FK_HistoricoTitular_Cidades_Naturalidade]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_HistoricoTitular_Titular]') AND parent_object_id = OBJECT_ID(N'[dbo].[HistoricoTitular]'))
ALTER TABLE [dbo].[HistoricoTitular]  WITH CHECK ADD  CONSTRAINT [FK_HistoricoTitular_Titular] FOREIGN KEY([TitularId])
REFERENCES [dbo].[Titular] ([Id])
GO
ALTER TABLE [dbo].[HistoricoTitular] CHECK CONSTRAINT [FK_HistoricoTitular_Titular]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_HistoricoTitular_Usuario]') AND parent_object_id = OBJECT_ID(N'[dbo].[HistoricoTitular]'))
ALTER TABLE [dbo].[HistoricoTitular]  WITH CHECK ADD  CONSTRAINT [FK_HistoricoTitular_Usuario] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[HistoricoTitular] CHECK CONSTRAINT [FK_HistoricoTitular_Usuario]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Tag_Perfil]') AND parent_object_id = OBJECT_ID(N'[dbo].[Tag]'))
ALTER TABLE [dbo].[Tag]  WITH CHECK ADD  CONSTRAINT [FK_Tag_Perfil] FOREIGN KEY([PerfilId])
REFERENCES [dbo].[Perfil] ([Id])
GO
ALTER TABLE [dbo].[Tag] CHECK CONSTRAINT [FK_Tag_Perfil]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Dependente_Titular]') AND parent_object_id = OBJECT_ID(N'[dbo].[Dependente]'))
ALTER TABLE [dbo].[Dependente]  WITH CHECK ADD  CONSTRAINT [FK_Dependente_Titular] FOREIGN KEY([TitularId])
REFERENCES [dbo].[Titular] ([Id])
GO
ALTER TABLE [dbo].[Dependente] CHECK CONSTRAINT [FK_Dependente_Titular]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Parcela_Contrato]') AND parent_object_id = OBJECT_ID(N'[dbo].[Parcela]'))
ALTER TABLE [dbo].[Parcela]  WITH CHECK ADD  CONSTRAINT [FK_Parcela_Contrato] FOREIGN KEY([ContratoId])
REFERENCES [dbo].[Contrato] ([Id])
GO
ALTER TABLE [dbo].[Parcela] CHECK CONSTRAINT [FK_Parcela_Contrato]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cidade_Estado]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cidades]'))
ALTER TABLE [dbo].[Cidades]  WITH CHECK ADD  CONSTRAINT [FK_Cidade_Estado] FOREIGN KEY([EstadoId])
REFERENCES [dbo].[Estados] ([Id])
GO
ALTER TABLE [dbo].[Cidades] CHECK CONSTRAINT [FK_Cidade_Estado]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Titular_Cidades_Endereco]') AND parent_object_id = OBJECT_ID(N'[dbo].[Titular]'))
ALTER TABLE [dbo].[Titular]  WITH CHECK ADD  CONSTRAINT [FK_Titular_Cidades_Endereco] FOREIGN KEY([CidadeEnderecoId])
REFERENCES [dbo].[Cidades] ([Id])
GO
ALTER TABLE [dbo].[Titular] CHECK CONSTRAINT [FK_Titular_Cidades_Endereco]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Titular_Cidades_Naturalidade]') AND parent_object_id = OBJECT_ID(N'[dbo].[Titular]'))
ALTER TABLE [dbo].[Titular]  WITH CHECK ADD  CONSTRAINT [FK_Titular_Cidades_Naturalidade] FOREIGN KEY([CidadeNaturalidadeId])
REFERENCES [dbo].[Cidades] ([Id])
GO
ALTER TABLE [dbo].[Titular] CHECK CONSTRAINT [FK_Titular_Cidades_Naturalidade]
