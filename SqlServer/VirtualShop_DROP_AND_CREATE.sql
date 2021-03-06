USE [VirtualShop]
GO
/****** Object:  Table [dbo].[Tienda]    Script Date: 07/15/2013 01:38:30 ******/
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
	[Imagen] [varchar](max) NULL,
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
/****** Object:  Table [dbo].[Categoria]    Script Date: 07/15/2013 01:38:30 ******/
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
SET IDENTITY_INSERT [dbo].[Categoria] ON
INSERT [dbo].[Categoria] ([Id], [Nombre]) VALUES (1, N'Accesorios para vehículos')
INSERT [dbo].[Categoria] ([Id], [Nombre]) VALUES (2, N'Animales y Mascotas')
INSERT [dbo].[Categoria] ([Id], [Nombre]) VALUES (3, N'Antigüedades')
INSERT [dbo].[Categoria] ([Id], [Nombre]) VALUES (4, N'Autos, Motos y Otros')
INSERT [dbo].[Categoria] ([Id], [Nombre]) VALUES (5, N'Bebés')
INSERT [dbo].[Categoria] ([Id], [Nombre]) VALUES (6, N'Cámaras y Accesorios')
INSERT [dbo].[Categoria] ([Id], [Nombre]) VALUES (7, N'Celulares y Teléfonos')
INSERT [dbo].[Categoria] ([Id], [Nombre]) VALUES (8, N'Coleccionables y Hobbies')
INSERT [dbo].[Categoria] ([Id], [Nombre]) VALUES (9, N'Computación')
INSERT [dbo].[Categoria] ([Id], [Nombre]) VALUES (10, N'Consolas y Videojuegos')
INSERT [dbo].[Categoria] ([Id], [Nombre]) VALUES (11, N'Deportes y Fitness')
INSERT [dbo].[Categoria] ([Id], [Nombre]) VALUES (12, N'Electrodomésticos y Aires Ac.')
INSERT [dbo].[Categoria] ([Id], [Nombre]) VALUES (13, N'Electrónica, Audio y Video')
INSERT [dbo].[Categoria] ([Id], [Nombre]) VALUES (14, N'Entradas para Eventos')
INSERT [dbo].[Categoria] ([Id], [Nombre]) VALUES (15, N'Hogar, Muebles y Jardín')
INSERT [dbo].[Categoria] ([Id], [Nombre]) VALUES (16, N'Industrias y Oficinas')
INSERT [dbo].[Categoria] ([Id], [Nombre]) VALUES (17, N'Inmuebles')
INSERT [dbo].[Categoria] ([Id], [Nombre]) VALUES (18, N'Instrumentos Musicales')
INSERT [dbo].[Categoria] ([Id], [Nombre]) VALUES (19, N'Joyas y Relojes')
INSERT [dbo].[Categoria] ([Id], [Nombre]) VALUES (20, N'Juegos y Juguetes')
INSERT [dbo].[Categoria] ([Id], [Nombre]) VALUES (21, N'Libros, Revistas y Comics')
INSERT [dbo].[Categoria] ([Id], [Nombre]) VALUES (22, N'Música, Películas y Series')
INSERT [dbo].[Categoria] ([Id], [Nombre]) VALUES (23, N'Otras categorías')
INSERT [dbo].[Categoria] ([Id], [Nombre]) VALUES (24, N'Ropa y Accesorios')
INSERT [dbo].[Categoria] ([Id], [Nombre]) VALUES (25, N'Salud y Belleza')
INSERT [dbo].[Categoria] ([Id], [Nombre]) VALUES (26, N'Servicios')
SET IDENTITY_INSERT [dbo].[Categoria] OFF
/****** Object:  StoredProcedure [dbo].[p_ConfirmarTienda]    Script Date: 07/15/2013 01:38:27 ******/
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
/****** Object:  StoredProcedure [dbo].[p_BuscarTienda]    Script Date: 07/15/2013 01:38:27 ******/
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
/****** Object:  StoredProcedure [dbo].[p_CrearTienda]    Script Date: 07/15/2013 01:38:27 ******/
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
	@UID	varchar(32),
	@IMAGEN	varchar(Max)
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
           ,[IdRegistracion]
           ,[Imagen])
     VALUES
           (@EMAIL
           ,@RAZONSOCIAL
           ,@CUIT
           ,@PASSWORD
           ,''P''
           ,GETDATE()
           ,@UID
           ,@IMAGEN)
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[p_Login]    Script Date: 07/15/2013 01:38:27 ******/
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
/****** Object:  StoredProcedure [dbo].[p_EliminarTienda]    Script Date: 07/15/2013 01:38:27 ******/
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
/****** Object:  StoredProcedure [dbo].[p_ObtenerCategorias]    Script Date: 07/15/2013 01:38:27 ******/
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
/****** Object:  StoredProcedure [dbo].[p_ModificarTienda]    Script Date: 07/15/2013 01:38:27 ******/
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
	@ESTADO	varchar(1),
	@IMAGEN	varchar(MAX)

AS
BEGIN

UPDATE [VirtualShop].[dbo].[Tienda]
SET         [Email]					=  @EMAIL
		   ,[RazonSocial]			=  @RAZONSOCIAL
           ,[CUIT]					=  @CUIT
           ,[Password]				=  @PASSWORD
           ,[Estado]				=  @ESTADO
           ,[FechaRegistracion]		=  GETDATE()
           ,[Imagen]				=  @IMAGEN
WHERE [Id] = @ID
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[p_ObtenerIdDeCategoria]    Script Date: 07/15/2013 01:38:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[p_ObtenerIdDeCategoria]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[p_ObtenerIdDeCategoria] 
	@NOMBRE varchar(50),
	@ID INT OUTPUT
as
BEGIN

	SET @ID = (SELECT Id From Categoria Where Nombre=@NOMBRE)
	RETURN
END


' 
END
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 07/15/2013 01:38:30 ******/
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
	[Baja] [varchar](1) NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Venta]    Script Date: 07/15/2013 01:38:30 ******/
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
/****** Object:  StoredProcedure [dbo].[p_ObtenerTiendas]    Script Date: 07/15/2013 01:38:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[p_ObtenerTiendas]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Grupo 2
-- Create date: 16/6/2013
-- Description:	Obtiene los producto de una tienda especifica.
-- =============================================
Create PROCEDURE [dbo].[p_ObtenerTiendas] 
AS
BEGIN

	Select Tienda.*
	 From Tienda
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[p_ObtenerProductos]    Script Date: 07/15/2013 01:38:27 ******/
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

	SELECT Producto.Id, Producto.Nombre,Producto.Descripcion,Producto.Stock,Producto.Precio,Categoria.Id Categoria 
	FROM Producto inner Join Categoria On Producto.IdCategoria = Categoria.Id 
	WHERE IdTienda = @IDTIENDA
	 AND Baja IS NULL

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[p_ObtenerIdDeProducto]    Script Date: 07/15/2013 01:38:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[p_ObtenerIdDeProducto]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[p_ObtenerIdDeProducto] 
	@NOMBRE varchar(50),
	@ID INT OUTPUT
as
BEGIN

	SET @ID = (SELECT Id From Producto Where Nombre=@NOMBRE)
	RETURN
END


' 
END
GO
/****** Object:  StoredProcedure [dbo].[p_ProductosPorTiendaCategoria]    Script Date: 07/15/2013 01:38:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[p_ProductosPorTiendaCategoria]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Grupo 2
-- Create date: 16/6/2013
-- Description:	Obtiene los producto de una tienda especifica.
-- =============================================
CREATE PROCEDURE [dbo].[p_ProductosPorTiendaCategoria]
	@IDTIENDA INT,
	@IDCATEGORIA INT
AS
BEGIN

	SELECT *
	FROM Producto
	WHERE IdTienda = @IDTIENDA
	 AND IdCategoria = @IDCATEGORIA
	 AND Baja IS NULL

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[p_Producto]    Script Date: 07/15/2013 01:38:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[p_Producto]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Grupo 2
-- Create date: 16/6/2013
-- Description:	Obtiene los producto de una tienda especifica.
-- =============================================
CREATE PROCEDURE [dbo].[p_Producto]
	@IDPRODUCTO INT
AS
BEGIN

	SELECT *
	FROM Producto
	WHERE Id = @IDPRODUCTO
	 AND Baja IS NULL

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[p_ObtenerVentas]    Script Date: 07/15/2013 01:38:27 ******/
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

	SELECT v.Id, p.Nombre, v.Cantidad, v.EmailComprador, v.FechaTransaccion, v.Estado 
	FROM Venta v INNER JOIN Producto p
		ON v.IdProducto = p.Id
	WHERE p.IdTienda = @IDTIENDA

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[p_ObtenerTiendasPorCategoria]    Script Date: 07/15/2013 01:38:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[p_ObtenerTiendasPorCategoria]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Grupo 2
-- Create date: 16/6/2013
-- Description:	Obtiene los producto de una tienda especifica.
-- =============================================
CREATE PROCEDURE [dbo].[p_ObtenerTiendasPorCategoria] 
	@IDCATEGORIA INT
AS
BEGIN

	Select Tienda.*
	 From Tienda
	Where Exists (Select 1 from Producto
	  Where Producto.IdTienda = Tienda.Id
	  	And Producto.Baja Is Null
		And Producto.IdCategoria = @IDCATEGORIA)

END' 
END
GO
/****** Object:  StoredProcedure [dbo].[p_ObtenerComprasPorFecha]    Script Date: 07/15/2013 01:38:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[p_ObtenerComprasPorFecha]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[p_ObtenerComprasPorFecha] 
	-- Add the parameters for the stored procedure here
	@FECHA DATETIME,
	@IDTIENDA int
	
AS
BEGIN

	SELECT c.Id, p.Nombre,c.Cantidad,c.EmailComprador, c.FechaTransaccion, c.Estado
	FROM Producto p inner join Venta c on  c.IdProducto = p.Id 
	WHERE c.FechaTransaccion = @FECHA and c.IdTienda = @IDTIENDA
	

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[p_ModificarProducto]    Script Date: 07/15/2013 01:38:27 ******/
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
/****** Object:  StoredProcedure [dbo].[p_EliminarProducto]    Script Date: 07/15/2013 01:38:27 ******/
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

UPDATE [VirtualShop].[dbo].[Producto]
SET Baja = ''B''
WHERE [Id] = @ID
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[p_CrearVenta]    Script Date: 07/15/2013 01:38:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[p_CrearVenta]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Grupo 2
-- Create date: 16/6/2013
-- Description:	Obtiene los producto de una tienda especifica.
-- =============================================
CREATE PROCEDURE [dbo].[p_CrearVenta]
		@IDTIENDA		INT,
		@EMAIL			VARCHAR(100),
		@IDPRODUCTO		INT,
		@PRECIOUNITARIO NUMERIC(9,2),
		@CANTIDAD		INT
	
AS
BEGIN

INSERT INTO Venta
(IdTienda,IdProducto,EmailComprador,Cantidad,PrecioUnitario,FechaTransaccion,Estado)
VALUES(@IDTIENDA,@IDPRODUCTO,@EMAIL,@CANTIDAD,@PRECIOUNITARIO,GETDATE(),''P'')

END' 
END
GO
/****** Object:  StoredProcedure [dbo].[p_CrearProducto]    Script Date: 07/15/2013 01:38:27 ******/
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
        
IF NOT EXISTS (SELECT 1 FROM Producto WHERE Nombre = @NOMBRE And Baja is null )
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
END
ELSE
 BEGIN
 RAISERROR(''Ya existe un prodcuto vigente con ese nombre'',16,1)
 END
END' 
END
GO
/****** Object:  ForeignKey [FK_Producto_Categoria]    Script Date: 07/15/2013 01:38:30 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Producto_Categoria]') AND parent_object_id = OBJECT_ID(N'[dbo].[Producto]'))
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Categoria] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categoria] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Producto_Categoria]') AND parent_object_id = OBJECT_ID(N'[dbo].[Producto]'))
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Categoria]
GO
/****** Object:  ForeignKey [FK_Producto_Tienda]    Script Date: 07/15/2013 01:38:30 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Producto_Tienda]') AND parent_object_id = OBJECT_ID(N'[dbo].[Producto]'))
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Tienda] FOREIGN KEY([IdTienda])
REFERENCES [dbo].[Tienda] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Producto_Tienda]') AND parent_object_id = OBJECT_ID(N'[dbo].[Producto]'))
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Tienda]
GO
/****** Object:  ForeignKey [FK_Compra_Tienda]    Script Date: 07/15/2013 01:38:30 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Compra_Tienda]') AND parent_object_id = OBJECT_ID(N'[dbo].[Venta]'))
ALTER TABLE [dbo].[Venta]  WITH CHECK ADD  CONSTRAINT [FK_Compra_Tienda] FOREIGN KEY([IdTienda])
REFERENCES [dbo].[Tienda] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Compra_Tienda]') AND parent_object_id = OBJECT_ID(N'[dbo].[Venta]'))
ALTER TABLE [dbo].[Venta] CHECK CONSTRAINT [FK_Compra_Tienda]
GO
