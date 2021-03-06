/****** Object:  Database [avd4]    Script Date: 22/11/2020 21:09:03 ******/
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'avd4')
BEGIN
CREATE DATABASE [avd4]  (EDITION = 'Basic', SERVICE_OBJECTIVE = 'Basic', MAXSIZE = 2 GB) WITH CATALOG_COLLATION = SQL_Latin1_General_CP1_CI_AS;

END
GO
ALTER DATABASE [avd4] SET COMPATIBILITY_LEVEL = 150
GO
ALTER DATABASE [avd4] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [avd4] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [avd4] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [avd4] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [avd4] SET ARITHABORT OFF 
GO
ALTER DATABASE [avd4] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [avd4] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [avd4] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [avd4] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [avd4] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [avd4] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [avd4] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [avd4] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [avd4] SET ALLOW_SNAPSHOT_ISOLATION ON 
GO
ALTER DATABASE [avd4] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [avd4] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [avd4] SET  MULTI_USER 
GO
ALTER DATABASE [avd4] SET ENCRYPTION ON
GO
ALTER DATABASE [avd4] SET QUERY_STORE = ON
GO
ALTER DATABASE [avd4] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 7), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 10, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
/*** The scripts of database scoped configurations in Azure should be executed inside the target database connection. ***/
GO
-- ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 8;
GO
/****** Object:  Table [dbo].[TbAluno]    Script Date: 22/11/2020 21:09:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TbAluno]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TbAluno](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Matricula] [varchar](100) NULL,
	[Nome] [varchar](100) NULL,
	[Email] [varchar](100) NULL,
	[Endereco] [varchar](100) NULL,
	[Numero] [varchar](100) NULL,
	[Bairro] [varchar](100) NULL,
	[Cidade] [varchar](100) NULL,
	[Estado] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[TbCurso]    Script Date: 22/11/2020 21:09:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TbCurso]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TbCurso](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NULL,
	[Descricao] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[TbCursoDisciplina]    Script Date: 22/11/2020 21:09:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TbCursoDisciplina]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TbCursoDisciplina](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdDisciplina] [int] NULL,
	[IdCurso] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[TbDisciplina]    Script Date: 22/11/2020 21:09:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TbDisciplina]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TbDisciplina](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NULL,
	[CargaHoraria] [int] NULL,
	[Descricao] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[TbInscricao]    Script Date: 22/11/2020 21:09:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TbInscricao]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TbInscricao](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DataInicio] [datetime] NULL,
	[DataConclusao] [datetime] NULL,
	[Status] [varchar](100) NULL,
	[IdAluno] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[TbInscricaoAluno]    Script Date: 22/11/2020 21:09:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TbInscricaoAluno]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TbInscricaoAluno](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdInscricao] [int] NULL,
	[IdCurso] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fkk_IdCurso]') AND parent_object_id = OBJECT_ID(N'[dbo].[TbCursoDisciplina]'))
ALTER TABLE [dbo].[TbCursoDisciplina]  WITH CHECK ADD  CONSTRAINT [fkk_IdCurso] FOREIGN KEY([IdCurso])
REFERENCES [dbo].[TbCurso] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fkk_IdCurso]') AND parent_object_id = OBJECT_ID(N'[dbo].[TbCursoDisciplina]'))
ALTER TABLE [dbo].[TbCursoDisciplina] CHECK CONSTRAINT [fkk_IdCurso]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fkk_IdDisciplina]') AND parent_object_id = OBJECT_ID(N'[dbo].[TbCursoDisciplina]'))
ALTER TABLE [dbo].[TbCursoDisciplina]  WITH CHECK ADD  CONSTRAINT [fkk_IdDisciplina] FOREIGN KEY([IdDisciplina])
REFERENCES [dbo].[TbDisciplina] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fkk_IdDisciplina]') AND parent_object_id = OBJECT_ID(N'[dbo].[TbCursoDisciplina]'))
ALTER TABLE [dbo].[TbCursoDisciplina] CHECK CONSTRAINT [fkk_IdDisciplina]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fkk_IdAlunos]') AND parent_object_id = OBJECT_ID(N'[dbo].[TbInscricao]'))
ALTER TABLE [dbo].[TbInscricao]  WITH CHECK ADD  CONSTRAINT [fkk_IdAlunos] FOREIGN KEY([IdAluno])
REFERENCES [dbo].[TbAluno] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fkk_IdAlunos]') AND parent_object_id = OBJECT_ID(N'[dbo].[TbInscricao]'))
ALTER TABLE [dbo].[TbInscricao] CHECK CONSTRAINT [fkk_IdAlunos]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fkk_IdCursos]') AND parent_object_id = OBJECT_ID(N'[dbo].[TbInscricaoAluno]'))
ALTER TABLE [dbo].[TbInscricaoAluno]  WITH CHECK ADD  CONSTRAINT [fkk_IdCursos] FOREIGN KEY([IdCurso])
REFERENCES [dbo].[TbCurso] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fkk_IdCursos]') AND parent_object_id = OBJECT_ID(N'[dbo].[TbInscricaoAluno]'))
ALTER TABLE [dbo].[TbInscricaoAluno] CHECK CONSTRAINT [fkk_IdCursos]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fkk_IdInscricao]') AND parent_object_id = OBJECT_ID(N'[dbo].[TbInscricaoAluno]'))
ALTER TABLE [dbo].[TbInscricaoAluno]  WITH CHECK ADD  CONSTRAINT [fkk_IdInscricao] FOREIGN KEY([IdInscricao])
REFERENCES [dbo].[TbInscricao] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fkk_IdInscricao]') AND parent_object_id = OBJECT_ID(N'[dbo].[TbInscricaoAluno]'))
ALTER TABLE [dbo].[TbInscricaoAluno] CHECK CONSTRAINT [fkk_IdInscricao]
GO
/****** Object:  StoredProcedure [dbo].[uspAlterarCadastroAluno]    Script Date: 22/11/2020 21:09:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[uspAlterarCadastroAluno]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[uspAlterarCadastroAluno] AS' 
END
GO


ALTER   proc [dbo].[uspAlterarCadastroAluno] (
	@Id int,
	@Nome varchar(200),
	@Email varchar(200),
	@Endereco varchar(200),
	@Numero varchar(200),
	@Bairro varchar(200),
	@Cidade varchar(200),
	@Estado varchar(2),
	@Matricula varchar(200)
)
as
begin
	update TbAluno set
		Nome = @Nome,
		Email = @Email,
		Endereco = @Endereco,
		Numero = @Numero,
		Bairro = @Bairro,
		Cidade = @Cidade,
		Estado = @Estado,
		Matricula = @Matricula
	where Id = @Id;
end
GO
/****** Object:  StoredProcedure [dbo].[uspAlterarCadastroCurso]    Script Date: 22/11/2020 21:09:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[uspAlterarCadastroCurso]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[uspAlterarCadastroCurso] AS' 
END
GO


ALTER   proc [dbo].[uspAlterarCadastroCurso] (
	@Id int,
	@Nome varchar(200),
	@Descricao varchar(200) = null
)
as
begin
	update TbCurso set
		Nome = @Nome,
		Descricao = @Descricao
	where Id = @Id;
end
GO
/****** Object:  StoredProcedure [dbo].[uspAlterarCadastroDisciplina]    Script Date: 22/11/2020 21:09:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[uspAlterarCadastroDisciplina]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[uspAlterarCadastroDisciplina] AS' 
END
GO



ALTER   proc [dbo].[uspAlterarCadastroDisciplina] (
	@Id int,
	@Nome varchar(200),
	@Descricao varchar(200) = null,
	@CargaHoraria int
)
as
begin
	update TbDisciplina set
		Nome = @Nome,
		Descricao = @Descricao,
		CargaHoraria = @CargaHoraria
	where Id = @Id;
end
GO
/****** Object:  StoredProcedure [dbo].[uspAlterarCadastroInscricao]    Script Date: 22/11/2020 21:09:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[uspAlterarCadastroInscricao]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[uspAlterarCadastroInscricao] AS' 
END
GO


ALTER   proc [dbo].[uspAlterarCadastroInscricao] (
	@Id int,
	@DataInicio datetime,
	@DataConclusao datetime,
	@Status varchar(200),
	@IdCurso int
)
as
begin
	update TbInscricao set
		DataConclusao = @DataConclusao,
		DataInicio = @DataInicio,
		Status = @Status
	where Id = @Id;

	update TbInscricaoAluno set
		IdCurso = @IdCurso
	where IdInscricao = @Id;
end
GO
/****** Object:  StoredProcedure [dbo].[uspAlterarOuRelacionarDisciplinaAoCurso]    Script Date: 22/11/2020 21:09:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[uspAlterarOuRelacionarDisciplinaAoCurso]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[uspAlterarOuRelacionarDisciplinaAoCurso] AS' 
END
GO

ALTER   proc [dbo].[uspAlterarOuRelacionarDisciplinaAoCurso] (
	@IdDisciplina int,
	@IdCurso int
)
as
begin
	if not exists(select top 1 Id from TbCursoDisciplina where IdCurso = @IdCurso and IdDisciplina = @IdDisciplina)
	begin
		insert into TbCursoDisciplina (
			IdDisciplina,
			IdCurso
		) values (
			@IdDisciplina,
			@IdCurso
		);
	end
end
GO
/****** Object:  StoredProcedure [dbo].[uspCadastrarAluno]    Script Date: 22/11/2020 21:09:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[uspCadastrarAluno]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[uspCadastrarAluno] AS' 
END
GO


ALTER   proc [dbo].[uspCadastrarAluno] (
	@Nome varchar(200),
	@Email varchar(200),
	@Endereco varchar(200),
	@Numero varchar(200),
	@Bairro varchar(200),
	@Cidade varchar(200),
	@Estado varchar(2),
	@Matricula varchar(200)
)
as
begin
	insert into TbAluno (
		Nome
		,Email
		,Endereco
		,Numero
		,Bairro
		,Cidade
		,Estado
		,Matricula
	) values (
		@Nome
		,@Email
		,@Endereco
		,@Numero
		,@Bairro
		,@Cidade
		,@Estado
		,@Matricula
	);
end
GO
/****** Object:  StoredProcedure [dbo].[uspCadastrarCurso]    Script Date: 22/11/2020 21:09:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[uspCadastrarCurso]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[uspCadastrarCurso] AS' 
END
GO


ALTER   proc [dbo].[uspCadastrarCurso] (
	@Nome varchar(200),
	@Descricao varchar(200) = null
)
as
begin
	insert into TbCurso (
		Nome
		,Descricao
	) values (
		@Nome
		,@Descricao
	);
end
GO
/****** Object:  StoredProcedure [dbo].[uspCadastrarDisciplina]    Script Date: 22/11/2020 21:09:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[uspCadastrarDisciplina]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[uspCadastrarDisciplina] AS' 
END
GO


ALTER   proc [dbo].[uspCadastrarDisciplina] (
	@Nome varchar(200),
	@Descricao varchar(200) = null,
	@CargaHoraria int,
	@IdCurso int
)
as
begin
	insert into TbDisciplina (
		Nome
		,Descricao
		,CargaHoraria
	) values (
		@Nome
		,@Descricao
		,@CargaHoraria
	);

	declare @IdDisciplina int;
	set @IdDisciplina = (select scope_identity());

	exec uspAlterarOuRelacionarDisciplinaAoCurso @IdDisciplina, @IdCurso;
end
GO
/****** Object:  StoredProcedure [dbo].[uspCadastrarInscricao]    Script Date: 22/11/2020 21:09:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[uspCadastrarInscricao]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[uspCadastrarInscricao] AS' 
END
GO


ALTER   proc [dbo].[uspCadastrarInscricao] (
	@DataInicio datetime,
	@DataConclusao datetime,
	@Status varchar(200),
	@IdAluno int,
	@IdCurso int
)
as
begin
	insert into TbInscricao (
		DataInicio
		,DataConclusao
		,Status
		,IdAluno
	) values (
		@DataInicio
		,@DataConclusao
		,@Status
		,@IdAluno
	);

	declare @IdInscricao int;
	set @IdInscricao = (select scope_identity());

	insert into TbInscricaoAluno (
		IdInscricao,
		IdCurso
	) values (
		@IdInscricao,
		@IdCurso
	);
end
GO
/****** Object:  StoredProcedure [dbo].[uspConsultarCadastroAluno]    Script Date: 22/11/2020 21:09:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[uspConsultarCadastroAluno]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[uspConsultarCadastroAluno] AS' 
END
GO


ALTER   proc [dbo].[uspConsultarCadastroAluno]
as
begin
	select * from TbAluno;
end
GO
/****** Object:  StoredProcedure [dbo].[uspConsultarCadastroCurso]    Script Date: 22/11/2020 21:09:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[uspConsultarCadastroCurso]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[uspConsultarCadastroCurso] AS' 
END
GO


ALTER   proc [dbo].[uspConsultarCadastroCurso]
as
begin
	select * from TbCurso;
end
GO
/****** Object:  StoredProcedure [dbo].[uspConsultarCadastroDisciplina]    Script Date: 22/11/2020 21:09:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[uspConsultarCadastroDisciplina]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[uspConsultarCadastroDisciplina] AS' 
END
GO

ALTER   proc [dbo].[uspConsultarCadastroDisciplina]
as
begin
	select cd.IdCurso, d.* from TbDisciplina d
		join TbCursoDisciplina cd on cd.IdDisciplina = d.Id;
end
GO
/****** Object:  StoredProcedure [dbo].[uspConsultarCadastroInscricao]    Script Date: 22/11/2020 21:09:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[uspConsultarCadastroInscricao]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[uspConsultarCadastroInscricao] AS' 
END
GO


ALTER   proc [dbo].[uspConsultarCadastroInscricao]
as
begin
	select i.IdCurso, d.* from TbInscricao d
		join TbInscricaoAluno i on i.IdInscricao = d.Id
end
GO
/****** Object:  StoredProcedure [dbo].[uspDeletarCadastroAluno]    Script Date: 22/11/2020 21:09:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[uspDeletarCadastroAluno]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[uspDeletarCadastroAluno] AS' 
END
GO


ALTER   proc [dbo].[uspDeletarCadastroAluno] (
	@Id int
)
as
begin
	select * into #tempTbInscricao from TbInscricao where IdAluno = @Id;
	
	delete from TbInscricaoAluno where IdInscricao in (select IdInscricao from #tempTbInscricao);
	
	delete from TbInscricao where Id in (select Id from #tempTbInscricao);

	delete from TbAluno where Id = @Id;
end
GO
/****** Object:  StoredProcedure [dbo].[uspDeletarCadastroCurso]    Script Date: 22/11/2020 21:09:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[uspDeletarCadastroCurso]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[uspDeletarCadastroCurso] AS' 
END
GO
  
  
ALTER   proc [dbo].[uspDeletarCadastroCurso] (  
 @Id int  
)  
as  
begin  
 delete from TbCursoDisciplina where IdCurso = @Id;  
 delete from TbInscricaoAluno where IdCurso = @Id;  
 delete from TbCurso where Id = @Id;  
end  
GO
/****** Object:  StoredProcedure [dbo].[uspDeletarCadastroDisciplina]    Script Date: 22/11/2020 21:09:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[uspDeletarCadastroDisciplina]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[uspDeletarCadastroDisciplina] AS' 
END
GO

ALTER   proc [dbo].[uspDeletarCadastroDisciplina] (
	@Id int
)
as
begin
	delete from TbCursoDisciplina where IdDisciplina = @Id;
	delete from TbDisciplina where Id = @Id;
end
GO
/****** Object:  StoredProcedure [dbo].[uspDeletarCadastroInscricao]    Script Date: 22/11/2020 21:09:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[uspDeletarCadastroInscricao]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[uspDeletarCadastroInscricao] AS' 
END
GO


ALTER   proc [dbo].[uspDeletarCadastroInscricao] (
	@Id int
)
as
begin
	delete from TbInscricaoAluno where IdInscricao = @Id;
	delete from TbInscricao where Id = @Id;
end
GO
/****** Object:  StoredProcedure [dbo].[uspObterAluno]    Script Date: 22/11/2020 21:09:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[uspObterAluno]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[uspObterAluno] AS' 
END
GO

ALTER   proc [dbo].[uspObterAluno] (
	@Id int
)
as
begin
	select * from TbAluno where Id = @Id;
end
GO
/****** Object:  StoredProcedure [dbo].[uspObterCurso]    Script Date: 22/11/2020 21:09:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[uspObterCurso]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[uspObterCurso] AS' 
END
GO

ALTER   proc [dbo].[uspObterCurso] (
	@Id int
)
as
begin
	select * from TbCurso where Id = @Id;
end
GO
/****** Object:  StoredProcedure [dbo].[uspObterDisciplina]    Script Date: 22/11/2020 21:09:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[uspObterDisciplina]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[uspObterDisciplina] AS' 
END
GO

ALTER   proc [dbo].[uspObterDisciplina] (
	@Id int
)
as
begin
	select cd.IdCurso, d.* from TbDisciplina d
		join TbCursoDisciplina cd on cd.IdDisciplina = d.Id
			where d.Id = @Id;
end
GO
/****** Object:  StoredProcedure [dbo].[uspObterDisciplinaPorCurso]    Script Date: 22/11/2020 21:09:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[uspObterDisciplinaPorCurso]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[uspObterDisciplinaPorCurso] AS' 
END
GO
  
ALTER    proc [dbo].[uspObterDisciplinaPorCurso] (  
 @IdCurso int  
)  
as  
begin  
 select d.* from TbDisciplina d  
	join TbCursoDisciplina cd on cd.IdDisciplina = d.Id  
		where cd.IdCurso = @IdCurso;  
end  
GO
/****** Object:  StoredProcedure [dbo].[uspObterInscricao]    Script Date: 22/11/2020 21:09:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[uspObterInscricao]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[uspObterInscricao] AS' 
END
GO

ALTER   proc [dbo].[uspObterInscricao] (
	@Id int
)
as
begin
	select i.IdCurso, d.* from TbInscricao d
		join TbInscricaoAluno i on i.IdInscricao = d.Id
			 where d.Id = @Id;
end
GO
ALTER DATABASE [avd4] SET  READ_WRITE 
GO
