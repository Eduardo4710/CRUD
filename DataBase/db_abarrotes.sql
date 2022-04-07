-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Versión del servidor:         10.4.22-MariaDB - mariadb.org binary distribution
-- SO del servidor:              Win64
-- HeidiSQL Versión:             11.3.0.6295
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Volcando estructura de base de datos para db_abarrotes
CREATE DATABASE IF NOT EXISTS `db_abarrotes` /*!40100 DEFAULT CHARACTER SET utf8mb4 */;
USE `db_abarrotes`;

-- Volcando estructura para procedimiento db_abarrotes.sp_ActualizarrProducto
DELIMITER //
CREATE PROCEDURE `sp_ActualizarrProducto`(
	IN `$id` INT,
	IN `$nombre` VARCHAR(30),
	IN `$precio` DECIMAL(10,2),
	IN `$categoria` INT,
	IN `$numExistencia` INT,
	IN `$marca_Id` INT,
	IN `$descripcion` VARCHAR(100)
)
BEGIN
UPDATE tbl_productos SET nombre=$nombre, precio=$precio, catego_Id=$categoria, 
numExistencia=$numExistencia, marca_Id=$marca_Id,descripcion=$descripcion
WHERE Producto_Id=$id;
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_abarrotes.sp_AgregarProducto
DELIMITER //
CREATE PROCEDURE `sp_AgregarProducto`(
	IN `$nombre` VARCHAR(30),
	IN `$precio` DECIMAL(10,2),
	IN `$categoria` INT,
	IN `$numExistencia` INT,
	IN `$Marca_Id` INT,
	IN `$descripcion` VARCHAR(100)
)
BEGIN
INSERT INTO tbl_productos (nombre,precio,catego_Id,numExistencia,Marca_Id,descripcion) 
VALUES ($nombre,$precio,$categoria,$numExistencia,$Marca_Id,$descripcion);
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_abarrotes.sp_buscarProductos
DELIMITER //
CREATE PROCEDURE `sp_buscarProductos`(
	IN `buscar_nom` VARCHAR(30)
)
BEGIN
Select Producto_Id AS ID ,nombre AS Nombre ,precio AS Precio , nomb_categoria 
as Categoria, numExistencia AS Existencia,Marc_nombre AS Marca ,descripcion AS Descripcion
from  tbl_productos 
INNER JOIN tbl_categorias ON tbl_categorias.categoria_Id= tbl_productos.catego_Id
INNER JOIN tbl_marcas ON tbl_marcas.Marca_Id= tbl_productos.marca_Id
WHERE nombre LIKE  CONCAT('%',buscar_nom,'%')  ORDER BY Producto_Id;
END//
DELIMITER ;

-- Volcando estructura para procedimiento db_abarrotes.sp_EliminarProducto
DELIMITER //
CREATE PROCEDURE `sp_EliminarProducto`(
	IN `$id` INT
)
BEGIN
DELETE FROM  tbl_productos WHERE Producto_Id= $id;

END//
DELIMITER ;

-- Volcando estructura para procedimiento db_abarrotes.sp_showData
DELIMITER //
CREATE PROCEDURE `sp_showData`()
BEGIN
select Producto_Id AS ID ,nombre AS Nombre ,precio AS Precio , nomb_categoria 
as Categoria, numExistencia AS Existencia,Marc_nombre AS Marca ,descripcion AS Descripcion
from  tbl_productos 
INNER JOIN tbl_marcas ON tbl_marcas.Marca_Id= tbl_productos.marca_Id
INNER JOIN tbl_categorias ON tbl_categorias.categoria_Id= tbl_productos.catego_Id  ORDER BY Producto_Id ;
END//
DELIMITER ;

-- Volcando estructura para tabla db_abarrotes.tbl_categorias
CREATE TABLE IF NOT EXISTS `tbl_categorias` (
  `categoria_Id` int(11) NOT NULL AUTO_INCREMENT,
  `nomb_categoria` varchar(30) NOT NULL,
  PRIMARY KEY (`categoria_Id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4;

-- Volcando datos para la tabla db_abarrotes.tbl_categorias: ~8 rows (aproximadamente)
DELETE FROM `tbl_categorias`;
/*!40000 ALTER TABLE `tbl_categorias` DISABLE KEYS */;
INSERT INTO `tbl_categorias` (`categoria_Id`, `nomb_categoria`) VALUES
	(1, 'Productos enlatados'),
	(2, 'Lácteos'),
	(3, 'Botanas'),
	(4, 'Harinas y pan'),
	(5, 'Bebidas'),
	(6, 'Confitería/dulcería'),
	(7, 'Automedicación'),
	(8, 'Limpieza'),
	(9, 'Cocina');
/*!40000 ALTER TABLE `tbl_categorias` ENABLE KEYS */;

-- Volcando estructura para tabla db_abarrotes.tbl_marcas
CREATE TABLE IF NOT EXISTS `tbl_marcas` (
  `Marca_Id` int(11) NOT NULL AUTO_INCREMENT,
  `Marc_nombre` varchar(30) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Marca_Id`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb4;

-- Volcando datos para la tabla db_abarrotes.tbl_marcas: ~15 rows (aproximadamente)
DELETE FROM `tbl_marcas`;
/*!40000 ALTER TABLE `tbl_marcas` DISABLE KEYS */;
INSERT INTO `tbl_marcas` (`Marca_Id`, `Marc_nombre`) VALUES
	(1, 'Coca-Cola'),
	(2, 'Lala'),
	(3, 'Bimbo'),
	(4, 'Pepsi'),
	(5, 'Sabritas'),
	(6, 'La costeña'),
	(7, 'Nutrioli'),
	(8, 'Fabuloso'),
	(9, 'Suavitel'),
	(10, 'Cloralex'),
	(11, 'Jumex'),
	(12, 'Bonafont'),
	(13, 'Ciel'),
	(14, 'E-Pura'),
	(15, 'Gamesa'),
	(16, 'Marinela'),
	(17, 'Barcel');
/*!40000 ALTER TABLE `tbl_marcas` ENABLE KEYS */;

-- Volcando estructura para tabla db_abarrotes.tbl_productos
CREATE TABLE IF NOT EXISTS `tbl_productos` (
  `Producto_Id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(30) NOT NULL,
  `precio` decimal(10,2) NOT NULL,
  `catego_Id` int(11) NOT NULL DEFAULT 0,
  `numExistencia` int(11) NOT NULL,
  `marca_Id` int(11) DEFAULT NULL,
  `descripcion` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`Producto_Id`) USING BTREE,
  KEY `Marca_Id` (`marca_Id`) USING BTREE,
  KEY `FK_tbl_productos_tbl_categorias` (`catego_Id`),
  CONSTRAINT `FK_tbl_productos_tbl_categorias` FOREIGN KEY (`catego_Id`) REFERENCES `tbl_categorias` (`categoria_Id`),
  CONSTRAINT `tbl_productos_ibfk_1` FOREIGN KEY (`Marca_Id`) REFERENCES `tbl_marcas` (`Marca_Id`)
) ENGINE=InnoDB AUTO_INCREMENT=30 DEFAULT CHARSET=utf8mb4;

-- Volcando datos para la tabla db_abarrotes.tbl_productos: ~24 rows (aproximadamente)
DELETE FROM `tbl_productos`;
/*!40000 ALTER TABLE `tbl_productos` DISABLE KEYS */;
INSERT INTO `tbl_productos` (`Producto_Id`, `nombre`, `precio`, `catego_Id`, `numExistencia`, `marca_Id`, `descripcion`) VALUES
	(2, 'Leche', 18.00, 2, 10, 2, 'Leche de un litro'),
	(3, 'Coca cola ', 32.00, 5, 24, 1, 'Coca retornable'),
	(4, 'tttttttt', 11.00, 4, 12, 17, 'Takis fuego'),
	(5, 'Yogur ', 10.00, 2, 1000, 2, 'Yogor sabor fresa '),
	(6, 'Pan bimbo', 20.00, 4, 23, 3, 'Bimbo con pan integrado'),
	(7, 'Papas', 13.00, 3, 6, 5, 'Papas originales'),
	(8, 'Jumex', 18.00, 8, 65, 11, 'Jumex de manzana de medio litro'),
	(9, 'E-Pura', 18.00, 5, 20, 14, 'Agua de un litro'),
	(11, 'Doritos', 13.00, 3, 40, 5, 'Doritos nachos'),
	(12, 'Ciel', 15.00, 5, 40, 13, 'Agua de un litro'),
	(13, 'Fabuloso', 15.00, 8, 20, 8, 'Fabuloso para limpiar pisos'),
	(14, 'Chokis', 12.50, 8, 40, 5, 'Galletas gamesa'),
	(15, 'Galletas', 20.40, 4, 40, 16, 'Galletas Marinela'),
	(16, 'Chile minabre', 13.00, 1, 50, 6, 'Chile minabre enteros'),
	(17, 'Frijoles', 30.00, 1, 20, 6, 'Frijoles bayos refritos '),
	(18, 'Chema ', 19.50, 2, 30, 2, 'Chemas Lala original'),
	(19, 'Fanta', 14.00, 1, 30, 1, 'Fanta sabor  mararina de medio litro'),
	(20, 'Crackets', 20.40, 1, 40, 15, 'Crackets original'),
	(21, 'Luxe', 18.00, 4, 70, 16, 'Panqué sabor cholante'),
	(22, 'Crackets', 20.40, 1, 40, 16, 'Crackets original'),
	(23, 'Aceite', 20.40, 9, 40, 7, 'Crackets original'),
	(25, 'jkjk', 89.00, 3, 9, 9, 'jkjkjk'),
	(27, 'Galletas', 20.40, 4, 40, 16, 'Galletas Marinela'),
	(28, 'Atun', 15.00, 1, 40, 6, 'Atun de agua'),
	(29, 'opopopopopopo', 20.40, 4, 40, 16, 'Galletas Marinela');
/*!40000 ALTER TABLE `tbl_productos` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
