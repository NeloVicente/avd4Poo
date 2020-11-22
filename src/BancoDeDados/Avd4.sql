/****** Object:  StoredProcedure [dbo].[uspObterInscricao]    Script Date: 21/11/2020 21:41:35 ******/
DROP PROCEDURE IF EXISTS [dbo].[uspObterInscricao]
GO
/****** Object:  StoredProcedure [dbo].[uspObterDisciplina]    Script Date: 21/11/2020 21:41:35 ******/
DROP PROCEDURE IF EXISTS [dbo].[uspObterDisciplina]
GO
/****** Object:  StoredProcedure [dbo].[uspObterCurso]    Script Date: 21/11/2020 21:41:35 ******/
DROP PROCEDURE IF EXISTS [dbo].[uspObterCurso]
GO
/****** Object:  StoredProcedure [dbo].[uspObterAluno]    Script Date: 21/11/2020 21:41:35 ******/
DROP PROCEDURE IF EXISTS [dbo].[uspObterAluno]
GO
/****** Object:  StoredProcedure [dbo].[uspDeletarCadastroInscricao]    Script Date: 21/11/2020 21:41:35 ******/
DROP PROCEDURE IF EXISTS [dbo].[uspDeletarCadastroInscricao]
GO
/****** Object:  StoredProcedure [dbo].[uspDeletarCadastroDisciplina]    Script Date: 21/11/2020 21:41:35 ******/
DROP PROCEDURE IF EXISTS [dbo].[uspDeletarCadastroDisciplina]
GO
/****** Object:  StoredProcedure [dbo].[uspDeletarCadastroCurso]    Script Date: 21/11/2020 21:41:35 ******/
DROP PROCEDURE IF EXISTS [dbo].[uspDeletarCadastroCurso]
GO
/****** Object:  StoredProcedure [dbo].[uspDeletarCadastroAluno]    Script Date: 21/11/2020 21:41:35 ******/
DROP PROCEDURE IF EXISTS [dbo].[uspDeletarCadastroAluno]
GO
/****** Object:  StoredProcedure [dbo].[uspConsultarCadastroInscricao]    Script Date: 21/11/2020 21:41:35 ******/
DROP PROCEDURE IF EXISTS [dbo].[uspConsultarCadastroInscricao]
GO
/****** Object:  StoredProcedure [dbo].[uspConsultarCadastroDisciplina]    Script Date: 21/11/2020 21:41:35 ******/
DROP PROCEDURE IF EXISTS [dbo].[uspConsultarCadastroDisciplina]
GO
/****** Object:  StoredProcedure [dbo].[uspConsultarCadastroCurso]    Script Date: 21/11/2020 21:41:35 ******/
DROP PROCEDURE IF EXISTS [dbo].[uspConsultarCadastroCurso]
GO
/****** Object:  StoredProcedure [dbo].[uspConsultarCadastroAluno]    Script Date: 21/11/2020 21:41:35 ******/
DROP PROCEDURE IF EXISTS [dbo].[uspConsultarCadastroAluno]
GO
/****** Object:  StoredProcedure [dbo].[uspCadastrarInscricao]    Script Date: 21/11/2020 21:41:35 ******/
DROP PROCEDURE IF EXISTS [dbo].[uspCadastrarInscricao]
GO
/****** Object:  StoredProcedure [dbo].[uspCadastrarDisciplina]    Script Date: 21/11/2020 21:41:35 ******/
DROP PROCEDURE IF EXISTS [dbo].[uspCadastrarDisciplina]
GO
/****** Object:  StoredProcedure [dbo].[uspCadastrarCurso]    Script Date: 21/11/2020 21:41:35 ******/
DROP PROCEDURE IF EXISTS [dbo].[uspCadastrarCurso]
GO
/****** Object:  StoredProcedure [dbo].[uspCadastrarAluno]    Script Date: 21/11/2020 21:41:35 ******/
DROP PROCEDURE IF EXISTS [dbo].[uspCadastrarAluno]
GO
/****** Object:  StoredProcedure [dbo].[uspAlterarOuRelacionarDisciplinaAoCurso]    Script Date: 21/11/2020 21:41:35 ******/
DROP PROCEDURE IF EXISTS [dbo].[uspAlterarOuRelacionarDisciplinaAoCurso]
GO
/****** Object:  StoredProcedure [dbo].[uspAlterarCadastroInscricao]    Script Date: 21/11/2020 21:41:35 ******/
DROP PROCEDURE IF EXISTS [dbo].[uspAlterarCadastroInscricao]
GO
/****** Object:  StoredProcedure [dbo].[uspAlterarCadastroDisciplina]    Script Date: 21/11/2020 21:41:35 ******/
DROP PROCEDURE IF EXISTS [dbo].[uspAlterarCadastroDisciplina]
GO
/****** Object:  StoredProcedure [dbo].[uspAlterarCadastroCurso]    Script Date: 21/11/2020 21:41:35 ******/
DROP PROCEDURE IF EXISTS [dbo].[uspAlterarCadastroCurso]
GO
/****** Object:  StoredProcedure [dbo].[uspAlterarCadastroAluno]    Script Date: 21/11/2020 21:41:35 ******/
DROP PROCEDURE IF EXISTS [dbo].[uspAlterarCadastroAluno]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TbInscricaoAluno]') AND type in (N'U'))
ALTER TABLE [dbo].[TbInscricaoAluno] DROP CONSTRAINT IF EXISTS [fkk_IdInscricao]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TbInscricaoAluno]') AND type in (N'U'))
ALTER TABLE [dbo].[TbInscricaoAluno] DROP CONSTRAINT IF EXISTS [fkk_IdCursos]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TbInscricao]') AND type in (N'U'))
ALTER TABLE [dbo].[TbInscricao] DROP CONSTRAINT IF EXISTS [fkk_IdAlunos]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TbCursoDisciplina]') AND type in (N'U'))
ALTER TABLE [dbo].[TbCursoDisciplina] DROP CONSTRAINT IF EXISTS [fkk_IdDisciplina]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TbCursoDisciplina]') AND type in (N'U'))
ALTER TABLE [dbo].[TbCursoDisciplina] DROP CONSTRAINT IF EXISTS [fkk_IdCurso]
GO
/****** Object:  Table [dbo].[TbInscricaoAluno]    Script Date: 21/11/2020 21:41:35 ******/
DROP TABLE IF EXISTS [dbo].[TbInscricaoAluno]
GO
/****** Object:  Table [dbo].[TbInscricao]    Script Date: 21/11/2020 21:41:35 ******/
DROP TABLE IF EXISTS [dbo].[TbInscricao]
GO
/****** Object:  Table [dbo].[TbDisciplina]    Script Date: 21/11/2020 21:41:35 ******/
DROP TABLE IF EXISTS [dbo].[TbDisciplina]
GO
/****** Object:  Table [dbo].[TbCursoDisciplina]    Script Date: 21/11/2020 21:41:35 ******/
DROP TABLE IF EXISTS [dbo].[TbCursoDisciplina]
GO
/****** Object:  Table [dbo].[TbCurso]    Script Date: 21/11/2020 21:41:35 ******/
DROP TABLE IF EXISTS [dbo].[TbCurso]
GO
/****** Object:  Table [dbo].[TbAluno]    Script Date: 21/11/2020 21:41:35 ******/
DROP TABLE IF EXISTS [dbo].[TbAluno]
GO
/****** Object:  Database [avd4]    Script Date: 21/11/2020 21:41:35 ******/
DROP DATABASE [avd4]
GO
/****** Object:  Database [avd4]    Script Date: 21/11/2020 21:41:35 ******/
CREATE DATABASE [avd4]  (EDITION = 'Basic', SERVICE_OBJECTIVE = 'Basic', MAXSIZE = 2 GB) WITH CATALOG_COLLATION = SQL_Latin1_General_CP1_CI_AS;
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
/****** Object:  Table [dbo].[TbAluno]    Script Date: 21/11/2020 21:41:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
GO
/****** Object:  Table [dbo].[TbCurso]    Script Date: 21/11/2020 21:41:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbCurso](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NULL,
	[Descricao] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TbCursoDisciplina]    Script Date: 21/11/2020 21:41:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbCursoDisciplina](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdDisciplina] [int] NULL,
	[IdCurso] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TbDisciplina]    Script Date: 21/11/2020 21:41:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
GO
/****** Object:  Table [dbo].[TbInscricao]    Script Date: 21/11/2020 21:41:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
GO
/****** Object:  Table [dbo].[TbInscricaoAluno]    Script Date: 21/11/2020 21:41:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbInscricaoAluno](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdInscricao] [int] NULL,
	[IdCurso] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TbCursoDisciplina]  WITH CHECK ADD  CONSTRAINT [fkk_IdCurso] FOREIGN KEY([IdCurso])
REFERENCES [dbo].[TbCurso] ([Id])
GO
ALTER TABLE [dbo].[TbCursoDisciplina] CHECK CONSTRAINT [fkk_IdCurso]
GO
ALTER TABLE [dbo].[TbCursoDisciplina]  WITH CHECK ADD  CONSTRAINT [fkk_IdDisciplina] FOREIGN KEY([IdDisciplina])
REFERENCES [dbo].[TbDisciplina] ([Id])
GO
ALTER TABLE [dbo].[TbCursoDisciplina] CHECK CONSTRAINT [fkk_IdDisciplina]
GO
ALTER TABLE [dbo].[TbInscricao]  WITH CHECK ADD  CONSTRAINT [fkk_IdAlunos] FOREIGN KEY([IdAluno])
REFERENCES [dbo].[TbAluno] ([Id])
GO
ALTER TABLE [dbo].[TbInscricao] CHECK CONSTRAINT [fkk_IdAlunos]
GO
ALTER TABLE [dbo].[TbInscricaoAluno]  WITH CHECK ADD  CONSTRAINT [fkk_IdCursos] FOREIGN KEY([IdCurso])
REFERENCES [dbo].[TbCurso] ([Id])
GO
ALTER TABLE [dbo].[TbInscricaoAluno] CHECK CONSTRAINT [fkk_IdCursos]
GO
ALTER TABLE [dbo].[TbInscricaoAluno]  WITH CHECK ADD  CONSTRAINT [fkk_IdInscricao] FOREIGN KEY([IdInscricao])
REFERENCES [dbo].[TbInscricao] ([Id])
GO
ALTER TABLE [dbo].[TbInscricaoAluno] CHECK CONSTRAINT [fkk_IdInscricao]
GO
/****** Object:  StoredProcedure [dbo].[uspAlterarCadastroAluno]    Script Date: 21/11/2020 21:41:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create   proc [dbo].[uspAlterarCadastroAluno] (
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
/****** Object:  StoredProcedure [dbo].[uspAlterarCadastroCurso]    Script Date: 21/11/2020 21:41:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE   proc [dbo].[uspAlterarCadastroCurso] (
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
/****** Object:  StoredProcedure [dbo].[uspAlterarCadastroDisciplina]    Script Date: 21/11/2020 21:41:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE   proc [dbo].[uspAlterarCadastroDisciplina] (
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
/****** Object:  StoredProcedure [dbo].[uspAlterarCadastroInscricao]    Script Date: 21/11/2020 21:41:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create   proc [dbo].[uspAlterarCadastroInscricao] (
	@Id int,
	@DataInicio datetime,
	@DataConclusao datetime,
	@Status varchar(200)
)
as
begin
	update TbInscricao set
		DataConclusao = @DataConclusao,
		DataInicio = @DataInicio,
		Status = @Status
	where Id = @Id;
end
GO
/****** Object:  StoredProcedure [dbo].[uspAlterarOuRelacionarDisciplinaAoCurso]    Script Date: 21/11/2020 21:41:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create   proc [dbo].[uspAlterarOuRelacionarDisciplinaAoCurso] (
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
/****** Object:  StoredProcedure [dbo].[uspCadastrarAluno]    Script Date: 21/11/2020 21:41:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create   proc [dbo].[uspCadastrarAluno] (
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
/****** Object:  StoredProcedure [dbo].[uspCadastrarCurso]    Script Date: 21/11/2020 21:41:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE   proc [dbo].[uspCadastrarCurso] (
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
/****** Object:  StoredProcedure [dbo].[uspCadastrarDisciplina]    Script Date: 21/11/2020 21:41:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE   proc [dbo].[uspCadastrarDisciplina] (
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
/****** Object:  StoredProcedure [dbo].[uspCadastrarInscricao]    Script Date: 21/11/2020 21:41:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create   proc [dbo].[uspCadastrarInscricao] (
	@DataInicio datetime,
	@DataConclusao datetime,
	@Status varchar(200),
	@IdAluno int
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
end
GO
/****** Object:  StoredProcedure [dbo].[uspConsultarCadastroAluno]    Script Date: 21/11/2020 21:41:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create   proc [dbo].[uspConsultarCadastroAluno]
as
begin
	select * from TbAluno;
end
GO
/****** Object:  StoredProcedure [dbo].[uspConsultarCadastroCurso]    Script Date: 21/11/2020 21:41:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create   proc [dbo].[uspConsultarCadastroCurso]
as
begin
	select * from TbCurso;
end
GO
/****** Object:  StoredProcedure [dbo].[uspConsultarCadastroDisciplina]    Script Date: 21/11/2020 21:41:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create   proc [dbo].[uspConsultarCadastroDisciplina]
as
begin
	select cd.IdCurso, d.* from TbDisciplina d
		join TbCursoDisciplina cd on cd.IdDisciplina = d.Id;
end
GO
/****** Object:  StoredProcedure [dbo].[uspConsultarCadastroInscricao]    Script Date: 21/11/2020 21:41:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create   proc [dbo].[uspConsultarCadastroInscricao]
as
begin
	select * from TbInscricao;
end
GO
/****** Object:  StoredProcedure [dbo].[uspDeletarCadastroAluno]    Script Date: 21/11/2020 21:41:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create   proc [dbo].[uspDeletarCadastroAluno] (
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
/****** Object:  StoredProcedure [dbo].[uspDeletarCadastroCurso]    Script Date: 21/11/2020 21:41:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
  
create   proc [dbo].[uspDeletarCadastroCurso] (  
 @Id int  
)  
as  
begin  
 delete from TbCursoDisciplina where IdCurso = @Id;  
 delete from TbInscricaoAluno where IdCurso = @Id;  
 delete from TbCurso where Id = @Id;  
end  
GO
/****** Object:  StoredProcedure [dbo].[uspDeletarCadastroDisciplina]    Script Date: 21/11/2020 21:41:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create   proc [dbo].[uspDeletarCadastroDisciplina] (
	@Id int
)
as
begin
	delete from TbCursoDisciplina where IdDisciplina = @Id;
	delete from TbDisciplina where Id = @Id;
end
GO
/****** Object:  StoredProcedure [dbo].[uspDeletarCadastroInscricao]    Script Date: 21/11/2020 21:41:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create   proc [dbo].[uspDeletarCadastroInscricao] (
	@Id int
)
as
begin
	delete from TbInscricaoAluno where IdInscricao = @Id;
	delete from TbInscricao where Id = @Id;
end
GO
/****** Object:  StoredProcedure [dbo].[uspObterAluno]    Script Date: 21/11/2020 21:41:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create   proc [dbo].[uspObterAluno] (
	@Id int
)
as
begin
	select * from TbAluno where Id = @Id;
end
GO
/****** Object:  StoredProcedure [dbo].[uspObterCurso]    Script Date: 21/11/2020 21:41:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create   proc [dbo].[uspObterCurso] (
	@Id int
)
as
begin
	select * from TbCurso where Id = @Id;
end
GO
/****** Object:  StoredProcedure [dbo].[uspObterDisciplina]    Script Date: 21/11/2020 21:41:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create   proc [dbo].[uspObterDisciplina] (
	@Id int
)
as
begin
	select cd.IdCurso, d.* from TbDisciplina d
		join TbCursoDisciplina cd on cd.IdDisciplina = d.Id
			where d.Id = @Id;
end
GO
/****** Object:  StoredProcedure [dbo].[uspObterInscricao]    Script Date: 21/11/2020 21:41:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create   proc [dbo].[uspObterInscricao] (
	@Id int
)
as
begin
	select * from TbInscricao where Id = @Id;
end
GO
ALTER DATABASE [avd4] SET  READ_WRITE 
GO
