USE [VirtualShop]
GO
/****** Object:  ForeignKey [FK_Producto_Categoria]    Script Date: 06/30/2013 01:58:42 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Producto_Categoria]') AND parent_object_id = OBJECT_ID(N'[dbo].[Producto]'))
ALTER TABLE [dbo].[Producto] DROP CONSTRAINT [FK_Producto_Categoria]
GO
/****** Object:  ForeignKey [FK_Producto_Tienda]    Script Date: 06/30/2013 01:58:42 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Producto_Tienda]') AND parent_object_id = OBJECT_ID(N'[dbo].[Producto]'))
ALTER TABLE [dbo].[Producto] DROP CONSTRAINT [FK_Producto_Tienda]
GO
/****** Object:  ForeignKey [FK_Compra_Tienda]    Script Date: 06/30/2013 01:58:42 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Compra_Tienda]') AND parent_object_id = OBJECT_ID(N'[dbo].[Venta]'))
ALTER TABLE [dbo].[Venta] DROP CONSTRAINT [FK_Compra_Tienda]
GO
/****** Object:  StoredProcedure [dbo].[p_ObtenerProductos]    Script Date: 06/30/2013 01:58:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[p_ObtenerProductos]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[p_ObtenerProductos]
GO
/****** Object:  StoredProcedure [dbo].[p_ObtenerVentas]    Script Date: 06/30/2013 01:58:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[p_ObtenerVentas]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[p_ObtenerVentas]
GO
/****** Object:  StoredProcedure [dbo].[p_CrearProducto]    Script Date: 06/30/2013 01:58:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[p_CrearProducto]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[p_CrearProducto]
GO
/****** Object:  StoredProcedure [dbo].[p_EliminarProducto]    Script Date: 06/30/2013 01:58:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[p_EliminarProducto]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[p_EliminarProducto]
GO
/****** Object:  StoredProcedure [dbo].[p_ModificarProducto]    Script Date: 06/30/2013 01:58:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[p_ModificarProducto]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[p_ModificarProducto]
GO
/****** Object:  StoredProcedure [dbo].[p_ModificarTienda]    Script Date: 06/30/2013 01:58:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[p_ModificarTienda]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[p_ModificarTienda]
GO
/****** Object:  StoredProcedure [dbo].[p_ObtenerCategorias]    Script Date: 06/30/2013 01:58:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[p_ObtenerCategorias]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[p_ObtenerCategorias]
GO
/****** Object:  StoredProcedure [dbo].[p_EliminarTienda]    Script Date: 06/30/2013 01:58:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[p_EliminarTienda]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[p_EliminarTienda]
GO
/****** Object:  StoredProcedure [dbo].[p_Login]    Script Date: 06/30/2013 01:58:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[p_Login]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[p_Login]
GO
/****** Object:  Table [dbo].[Venta]    Script Date: 06/30/2013 01:58:42 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Compra_Tienda]') AND parent_object_id = OBJECT_ID(N'[dbo].[Venta]'))
ALTER TABLE [dbo].[Venta] DROP CONSTRAINT [FK_Compra_Tienda]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Venta]') AND type in (N'U'))
DROP TABLE [dbo].[Venta]
GO
/****** Object:  StoredProcedure [dbo].[p_CrearTienda]    Script Date: 06/30/2013 01:58:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[p_CrearTienda]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[p_CrearTienda]
GO
/****** Object:  StoredProcedure [dbo].[p_BuscarTienda]    Script Date: 06/30/2013 01:58:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[p_BuscarTienda]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[p_BuscarTienda]
GO
/****** Object:  StoredProcedure [dbo].[p_ConfirmarTienda]    Script Date: 06/30/2013 01:58:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[p_ConfirmarTienda]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[p_ConfirmarTienda]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 06/30/2013 01:58:42 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Producto_Categoria]') AND parent_object_id = OBJECT_ID(N'[dbo].[Producto]'))
ALTER TABLE [dbo].[Producto] DROP CONSTRAINT [FK_Producto_Categoria]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Producto_Tienda]') AND parent_object_id = OBJECT_ID(N'[dbo].[Producto]'))
ALTER TABLE [dbo].[Producto] DROP CONSTRAINT [FK_Producto_Tienda]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Producto]') AND type in (N'U'))
DROP TABLE [dbo].[Producto]
GO
/****** Object:  Table [dbo].[Tienda]    Script Date: 06/30/2013 01:58:42 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tienda]') AND type in (N'U'))
DROP TABLE [dbo].[Tienda]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 06/30/2013 01:58:41 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Categoria]') AND type in (N'U'))
DROP TABLE [dbo].[Categoria]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 06/30/2013 01:58:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Categoria]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Categoria](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tienda]    Script Date: 06/30/2013 01:58:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tienda]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Tienda](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[RazonSocial] [varchar](50) NOT NULL,
	[CUIT] [varchar](15) NULL,
	[Password] [varchar](32) NOT NULL,
	[Estado] [varchar](1) NULL,
	[FechaRegistracion] [datetime] NULL,
	[IdRegistracion] [varchar](32) NULL,
 CONSTRAINT [PK_Tienda_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_Tienda] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 06/30/2013 01:58:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Producto]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Producto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdTienda] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
	[Precio] [numeric](9, 2) NOT NULL,
	[Stock] [bigint] NOT NULL,
	[Imagen] [varchar](max) NULL,
	[IdCategoria] [int] NOT NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_Producto] UNIQUE NONCLUSTERED 
(
	[IdTienda] ASC,
	[Nombre] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[p_ConfirmarTienda]    Script Date: 06/30/2013 01:58:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[p_ConfirmarTienda]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Grupo 2>
-- Create date: <16/6/2013>
-- Description:	<Confirma una nueva tienda, modificando banderas>
-- =============================================
CREATE PROCEDURE [dbo].[p_ConfirmarTienda]
	-- Add the parameters for the stored procedure here
	@EMAIL Varchar(100), 
	@UID   Varchar(32)
AS
BEGIN

IF EXISTS (SELECT 1 FROM Tienda WHERE [Email] = @EMAIL
AND   [IdRegistracion] = @UID)
BEGIN 
	UPDATE [VirtualShop].[dbo].[Tienda]
	SET     [Estado]				=  ''A''
           ,[FechaRegistracion]		=  GETDATE()
           ,[IdRegistracion]		=  NULL
WHERE [Email] = @EMAIL
AND   [IdRegistracion] = @UID
AND	  DATEDIFF(MINUTE, [FechaRegistracion], GETDATE()) < 30

IF (@@ROWCOUNT = 0 )
BEGIN
 DELETE [VirtualShop].[dbo].[Tienda]
 WHERE [Email] = @EMAIL
 AND   [IdRegistracion] = @UID
 RAISERROR(''TIENDA SIN CONFIRMAR'',16,1)
END

END
ELSE
 RAISERROR(''TIENDA INEXISTENTE'',16,1)
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[p_BuscarTienda]    Script Date: 06/30/2013 01:58:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[p_BuscarTienda]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[p_BuscarTienda] 
	@EMAIL VARCHAR(100)	
AS
BEGIN

	SELECT * FROM Tienda WHERE Email=@EMAIL
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[p_CrearTienda]    Script Date: 06/30/2013 01:58:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[p_CrearTienda]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Grupo 2>
-- Create date: <15/6/2013>
-- Description:	<Alta nueva tienda>
-- =============================================
CREATE PROCEDURE [dbo].[p_CrearTienda] 
	-- Add the parameters for the stored procedure here
	@EMAIL varchar(80), 
	@RAZONSOCIAL varchar(50),
	@CUIT varchar(15), 
	@PASSWORD varchar(32),
	@UID	varchar(32)
	--@ESTADO	varchar(1) (Se Inserta por defecto el valor B (Baja)

AS
BEGIN

INSERT INTO [VirtualShop].[dbo].[Tienda]
           (-- ID (Es Identity)
            [Email]
           ,[RazonSocial]
           ,[CUIT]
           ,[Password]
           ,[Estado]
           ,[FechaRegistracion]
           ,[IdRegistracion])
     VALUES
           (@EMAIL
           ,@RAZONSOCIAL
           ,@CUIT
           ,@PASSWORD
           ,''P''
           ,GETDATE()
           ,@UID)
END
' 
END
GO
/****** Object:  Table [dbo].[Venta]    Script Date: 06/30/2013 01:58:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Venta]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Venta](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdTienda] [int] NOT NULL,
	[IdProducto] [int] NOT NULL,
	[EmailComprador] [varchar](100) NOT NULL,
	[Cantidad] [bigint] NULL,
	[PrecioUnitario] [numeric](9, 2) NULL,
	[FechaTransaccion] [datetime] NULL,
	[Estado] [varchar](1) NULL,
 CONSTRAINT [PK_Compra] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[p_Login]    Script Date: 06/30/2013 01:58:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[p_Login]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Grupo 2
-- Create date: 16/6/2013
-- Description:	Verifica Login
-- =============================================
CREATE PROCEDURE [dbo].[p_Login] 
	@EMAIL VARCHAR(100),
	@PASSWORD VARCHAR(32)
AS
BEGIN

	SELECT * FROM Tienda WHERE Email = @EMAIL AND Password = @PASSWORD AND Estado <> ''P''

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[p_EliminarTienda]    Script Date: 06/30/2013 01:58:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[p_EliminarTienda]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Grupo 2>
-- Create date: <15/6/2013>
-- Description:	<Modifica tienda>
-- =============================================
CREATE PROCEDURE [dbo].[p_EliminarTienda] 
	@ID INT

AS
BEGIN

DELETE [VirtualShop].[dbo].[Tienda]
WHERE [Id] = @ID
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[p_ObtenerCategorias]    Script Date: 06/30/2013 01:58:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[p_ObtenerCategorias]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'Create procedure [dbo].[p_ObtenerCategorias]
As
Begin

	Select * from Categoria

End' 
END
GO
/****** Object:  StoredProcedure [dbo].[p_ModificarTienda]    Script Date: 06/30/2013 01:58:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[p_ModificarTienda]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Grupo 2>
-- Create date: <15/6/2013>
-- Description:	<Modifica tienda>
-- =============================================
CREATE PROCEDURE [dbo].[p_ModificarTienda] 
	@ID	INT,
	@EMAIL varchar(80), 
	@RAZONSOCIAL varchar(50),
	@CUIT varchar(15), 
	@PASSWORD varchar(32),
	@ESTADO	varchar(1)

AS
BEGIN

UPDATE [VirtualShop].[dbo].[Tienda]
SET         [Email]					=  @EMAIL
		   ,[RazonSocial]			=  @RAZONSOCIAL
           ,[CUIT]					=  @CUIT
           ,[Password]				=  @PASSWORD
           ,[Estado]				=  @ESTADO
           ,[FechaRegistracion]		=  GETDATE()
WHERE [Id] = @ID
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[p_ModificarProducto]    Script Date: 06/30/2013 01:58:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[p_ModificarProducto]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Grupo 2>
-- Create date: <15/6/2013>
-- Description:	<Modifica un producto>
-- =============================================
CREATE PROCEDURE [dbo].[p_ModificarProducto] 
	-- Add the parameters for the stored procedure here
            @ID				INT
           -- ,@IDTIENDA		INT No se debería poder modificar la tienda a la que pertenece
           ,@NOMBRE			VARCHAR(50)
           ,@DESCRIPCION	VARCHAR(100)
           ,@PRECIO			NUMERIC(9,2)
           ,@STOCK			BIGINT
           ,@IMAGEN			VARCHAR(255)
           ,@IDCATEGORIA	INT
AS
BEGIN
        
UPDATE [VirtualShop].[dbo].[Producto]
SET         -- [IdTienda]		= @IDTIENDA,
           [Nombre]		= @NOMBRE
           ,[Descripcion]	= @DESCRIPCION
           ,[Precio]		= @PRECIO
           ,[Stock]			= @STOCK
           ,[Imagen]		= @IMAGEN
           ,[IdCategoria]	= @IDCATEGORIA
WHERE ID = @ID
       
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[p_EliminarProducto]    Script Date: 06/30/2013 01:58:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[p_EliminarProducto]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Grupo 2>
-- Create date: <15/6/2013>
-- Description:	<Modifica tienda>
-- =============================================
CREATE PROCEDURE [dbo].[p_EliminarProducto] 
	@ID INT

AS
BEGIN

DELETE [VirtualShop].[dbo].[Producto]
WHERE [Id] = @ID
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[p_CrearProducto]    Script Date: 06/30/2013 01:58:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[p_CrearProducto]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Grupo 2>
-- Create date: <15/6/2013>
-- Description:	<Alta nuevo producto>
-- =============================================
CREATE PROCEDURE [dbo].[p_CrearProducto] 
	-- Add the parameters for the stored procedure here
            @IDTIENDA		INT
           ,@NOMBRE			VARCHAR(50)
           ,@DESCRIPCION	VARCHAR(100)
           ,@PRECIO			NUMERIC(9,2)
           ,@STOCK			BIGINT
           ,@IMAGEN			VARCHAR(255)
           ,@IDCATEGORIA	INT
AS
BEGIN
        
INSERT INTO [VirtualShop].[dbo].[Producto]
           ([IdTienda]
           ,[Nombre]
           ,[Descripcion]
           ,[Precio]
           ,[Stock]
           ,[Imagen]
           ,[IdCategoria])
     VALUES
		  (@IDTIENDA
           ,@NOMBRE
           ,@DESCRIPCION
           ,@PRECIO
           ,@STOCK
           ,@IMAGEN
           ,@IDCATEGORIA)
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[p_ObtenerVentas]    Script Date: 06/30/2013 01:58:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[p_ObtenerVentas]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Grupo 2
-- Create date: 16/6/2013
-- Description:	Obtiene los producto de una tienda especifica.
-- =============================================
CREATE PROCEDURE [dbo].[p_ObtenerVentas] 
	@IDTIENDA INT
AS
BEGIN

	SELECT *
	FROM Venta
	WHERE IdTienda = @IDTIENDA

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[p_ObtenerProductos]    Script Date: 06/30/2013 01:58:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[p_ObtenerProductos]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Grupo 2
-- Create date: 16/6/2013
-- Description:	Obtiene los producto de una tienda especifica.
-- =============================================
CREATE PROCEDURE [dbo].[p_ObtenerProductos] 
	@IDTIENDA INT
AS
BEGIN

	SELECT Producto.Id, Producto.Nombre,Producto.Descripcion,Producto.Stock,Producto.Precio,Categoria.Nombre Categoria 
	FROM Producto inner Join Categoria On Producto.IdCategoria = Categoria.Id 
	WHERE IdTienda = @IDTIENDA

END
' 
END
GO
/****** Object:  ForeignKey [FK_Producto_Categoria]    Script Date: 06/30/2013 01:58:42 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Producto_Categoria]') AND parent_object_id = OBJECT_ID(N'[dbo].[Producto]'))
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Categoria] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categoria] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Producto_Categoria]') AND parent_object_id = OBJECT_ID(N'[dbo].[Producto]'))
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Categoria]
GO
/****** Object:  ForeignKey [FK_Producto_Tienda]    Script Date: 06/30/2013 01:58:42 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Producto_Tienda]') AND parent_object_id = OBJECT_ID(N'[dbo].[Producto]'))
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Tienda] FOREIGN KEY([IdTienda])
REFERENCES [dbo].[Tienda] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Producto_Tienda]') AND parent_object_id = OBJECT_ID(N'[dbo].[Producto]'))
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Tienda]
GO
/****** Object:  ForeignKey [FK_Compra_Tienda]    Script Date: 06/30/2013 01:58:42 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Compra_Tienda]') AND parent_object_id = OBJECT_ID(N'[dbo].[Venta]'))
ALTER TABLE [dbo].[Venta]  WITH CHECK ADD  CONSTRAINT [FK_Compra_Tienda] FOREIGN KEY([IdTienda])
REFERENCES [dbo].[Tienda] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Compra_Tienda]') AND parent_object_id = OBJECT_ID(N'[dbo].[Venta]'))
ALTER TABLE [dbo].[Venta] CHECK CONSTRAINT [FK_Compra_Tienda]
GO
