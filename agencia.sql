/*
SQLyog Ultimate v11.11 (64 bit)
MySQL - 5.7.9-log : Database - agencia_viajes
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`agencia_viajes` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `agencia_viajes`;

/*Table structure for table `tblagencia_viajes` */

DROP TABLE IF EXISTS `tblagencia_viajes`;

CREATE TABLE `tblagencia_viajes` (
  `intIdAgencia` int(5) NOT NULL AUTO_INCREMENT,
  `vchNombre` varchar(40) NOT NULL,
  `vchEmail` varchar(30) NOT NULL,
  PRIMARY KEY (`intIdAgencia`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

/*Data for the table `tblagencia_viajes` */

insert  into `tblagencia_viajes`(`intIdAgencia`,`vchNombre`,`vchEmail`) values (1,'Agencia Viajes','agenciaviajes@hotmail.com');

/*Table structure for table `tblclientes` */

DROP TABLE IF EXISTS `tblclientes`;

CREATE TABLE `tblclientes` (
  `intIdCliente` int(5) NOT NULL AUTO_INCREMENT,
  `vchNombre` varchar(30) NOT NULL,
  `vchApellidos` varchar(60) NOT NULL,
  `vchDireccion` varchar(60) NOT NULL,
  `vchTelefono` varchar(14) NOT NULL,
  `vchEmail` varchar(30) DEFAULT NULL,
  `intIdSucursal` int(5) NOT NULL,
  PRIMARY KEY (`intIdCliente`),
  KEY `relacioncliente_socursal` (`intIdSucursal`),
  CONSTRAINT `relacioncliente_socursal` FOREIGN KEY (`intIdSucursal`) REFERENCES `tblsucursales` (`intIdSucursal`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

/*Data for the table `tblclientes` */

insert  into `tblclientes`(`intIdCliente`,`vchNombre`,`vchApellidos`,`vchDireccion`,`vchTelefono`,`vchEmail`,`intIdSucursal`) values (2,'pedro','santiago','huejutla','7712345643','jorge@hotmail.com',1);

/*Table structure for table `tbldescuento` */

DROP TABLE IF EXISTS `tbldescuento`;

CREATE TABLE `tbldescuento` (
  `intIdDescuento` int(5) NOT NULL AUTO_INCREMENT,
  `intDescuento` decimal(10,0) NOT NULL,
  `vchDescripcion` varchar(40) DEFAULT NULL,
  PRIMARY KEY (`intIdDescuento`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `tbldescuento` */

/*Table structure for table `tblempleados` */

DROP TABLE IF EXISTS `tblempleados`;

CREATE TABLE `tblempleados` (
  `intIdEmpleado` int(5) NOT NULL AUTO_INCREMENT,
  `vchNombre` varchar(20) NOT NULL,
  `vchApellidos` varchar(30) NOT NULL,
  `vchDireccion` varchar(50) NOT NULL,
  `vchTelefono` varchar(13) NOT NULL,
  `intIdSucursal` int(5) NOT NULL,
  PRIMARY KEY (`intIdEmpleado`),
  KEY `tblEmpleado_tblSocursal` (`intIdSucursal`),
  CONSTRAINT `tblEmpleado_tblSocursal` FOREIGN KEY (`intIdSucursal`) REFERENCES `tblsucursales` (`intIdSucursal`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

/*Data for the table `tblempleados` */

insert  into `tblempleados`(`intIdEmpleado`,`vchNombre`,`vchApellidos`,`vchDireccion`,`vchTelefono`,`intIdSucursal`) values (1,'Sergio','Hernández Vite','Huextetitla','2345678',1),(2,'fabian','santiago hernandez','acuatempa','7713468210',1),(3,'sergio','herrera','huejutla','7713468210',1);

/*Table structure for table `tbleventos` */

DROP TABLE IF EXISTS `tbleventos`;

CREATE TABLE `tbleventos` (
  `intIdEvento` int(5) NOT NULL AUTO_INCREMENT,
  `vchNombre` varchar(20) DEFAULT NULL,
  `vchDescripcion` varchar(240) DEFAULT NULL,
  `vchDireccion` varchar(40) DEFAULT NULL,
  `vchFecha` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`intIdEvento`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

/*Data for the table `tbleventos` */

insert  into `tbleventos`(`intIdEvento`,`vchNombre`,`vchDescripcion`,`vchDireccion`,`vchFecha`) values (1,'xantolo','je','je','sábado, 28 de octubre de 2017'),(2,'Xantolo','Tradición','Huejutla de Reyes','miércoles, 18 de octubre de 2017');

/*Table structure for table `tblhotel` */

DROP TABLE IF EXISTS `tblhotel`;

CREATE TABLE `tblhotel` (
  `intIdHotel` int(5) NOT NULL AUTO_INCREMENT,
  `vchNombre` varchar(20) NOT NULL,
  `vchCategoria` varchar(20) NOT NULL,
  `vchTelefono` varchar(13) NOT NULL,
  `vchCorreo` varchar(30) NOT NULL,
  `vchDireccion` varchar(50) NOT NULL,
  `vchLogoNombre` varchar(50) DEFAULT NULL,
  `vchLogoRuta` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`intIdHotel`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

/*Data for the table `tblhotel` */

insert  into `tblhotel`(`intIdHotel`,`vchNombre`,`vchCategoria`,`vchTelefono`,`vchCorreo`,`vchDireccion`,`vchLogoNombre`,`vchLogoRuta`) values (1,'Luna de miel','3 Estrellas','77124312387','lunademiel@gmail.com','huejutla de reyes','g',NULL),(2,'Estrellita','2 Estrellas','7713453219','@','tehuetla',NULL,NULL),(3,'cielo','1 Estrella','345678','cielo@hotmail.com','huejutla','logo',NULL),(4,'las palmas','2 Estrellas','7712342312','las palmas','huejutla','logo',NULL);

/*Table structure for table `tbllugares` */

DROP TABLE IF EXISTS `tbllugares`;

CREATE TABLE `tbllugares` (
  `intIdLugar` int(5) NOT NULL AUTO_INCREMENT,
  `vchNombre` varchar(40) DEFAULT NULL,
  `vchDireccion` varchar(40) NOT NULL,
  `vchDescripcion` varchar(240) NOT NULL,
  PRIMARY KEY (`intIdLugar`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

/*Data for the table `tbllugares` */

insert  into `tbllugares`(`intIdLugar`,`vchNombre`,`vchDireccion`,`vchDescripcion`) values (1,'Parque turistico','Huejutla de Reyes Hidalgo','Un lugar bonito');

/*Table structure for table `tblnivel` */

DROP TABLE IF EXISTS `tblnivel`;

CREATE TABLE `tblnivel` (
  `intIdNivel` int(5) NOT NULL AUTO_INCREMENT,
  `vchNombreNivel` varchar(30) NOT NULL,
  PRIMARY KEY (`intIdNivel`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

/*Data for the table `tblnivel` */

insert  into `tblnivel`(`intIdNivel`,`vchNombreNivel`) values (1,'Administrador');

/*Table structure for table `tblpaquetes` */

DROP TABLE IF EXISTS `tblpaquetes`;

CREATE TABLE `tblpaquetes` (
  `intIdPaquete` int(5) NOT NULL AUTO_INCREMENT,
  `vchNombre` varchar(30) NOT NULL,
  `dcmlIva` decimal(10,0) NOT NULL,
  `intCantidadDias` int(11) NOT NULL,
  `intCantidadNoches` int(11) NOT NULL,
  `dcmlprecio` decimal(10,0) NOT NULL,
  `intIdEvento` int(5) NOT NULL,
  `intIdLugar` int(5) NOT NULL,
  `intIdDescuento` int(5) NOT NULL,
  PRIMARY KEY (`intIdPaquete`),
  KEY `relacionpaquete_eventos` (`intIdEvento`),
  KEY `relacionpaquete_lugar` (`intIdLugar`),
  KEY `relacionpaquete_promocion` (`intIdDescuento`),
  CONSTRAINT `relacionpaquete_eventos` FOREIGN KEY (`intIdEvento`) REFERENCES `tbleventos` (`intIdEvento`),
  CONSTRAINT `relacionpaquete_lugar` FOREIGN KEY (`intIdLugar`) REFERENCES `tbllugares` (`intIdLugar`),
  CONSTRAINT `relacionpaquete_promocion` FOREIGN KEY (`intIdDescuento`) REFERENCES `tbldescuento` (`intIdDescuento`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `tblpaquetes` */

/*Table structure for table `tblreservahospedaje` */

DROP TABLE IF EXISTS `tblreservahospedaje`;

CREATE TABLE `tblreservahospedaje` (
  `intIdReservaHospedaje` int(5) NOT NULL AUTO_INCREMENT,
  `dteFechaInicial` datetime DEFAULT NULL,
  `dteFechaFinal` datetime DEFAULT NULL,
  `intNumHabDouble` int(5) NOT NULL,
  `intNumHabIndiv` int(5) NOT NULL,
  `fltPrecio` float DEFAULT NULL,
  `intIdHotel` int(5) NOT NULL,
  PRIMARY KEY (`intIdReservaHospedaje`),
  KEY `relacionreservahospedaje_hotel` (`intIdHotel`),
  CONSTRAINT `relacionreservahospedaje_hotel` FOREIGN KEY (`intIdHotel`) REFERENCES `tblhotel` (`intIdHotel`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `tblreservahospedaje` */

/*Table structure for table `tblreservatransporte` */

DROP TABLE IF EXISTS `tblreservatransporte`;

CREATE TABLE `tblreservatransporte` (
  `intIdReservaTransporte` int(5) NOT NULL AUTO_INCREMENT,
  `vchOrigen` varchar(60) NOT NULL,
  `vchDestino` varchar(60) NOT NULL,
  `dteFechaSalida` datetime DEFAULT NULL,
  `fltPrecio` float DEFAULT NULL,
  `intIdTipo` int(5) NOT NULL,
  PRIMARY KEY (`intIdReservaTransporte`),
  KEY `relacioncliente_tipotransporte` (`intIdTipo`),
  CONSTRAINT `relacioncliente_tipotransporte` FOREIGN KEY (`intIdTipo`) REFERENCES `tbltipotransporte` (`intIdTipo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `tblreservatransporte` */

/*Table structure for table `tblsucursales` */

DROP TABLE IF EXISTS `tblsucursales`;

CREATE TABLE `tblsucursales` (
  `intIdSucursal` int(5) NOT NULL AUTO_INCREMENT,
  `vchNombre` varchar(40) NOT NULL,
  `vchEncargado` varchar(40) NOT NULL,
  `vchDireccion` varchar(50) NOT NULL,
  `vchTelefono` varchar(13) NOT NULL,
  `intIdAgencia` int(5) NOT NULL,
  PRIMARY KEY (`intIdSucursal`),
  KEY `tblSucursales_tblAgencia` (`intIdAgencia`),
  CONSTRAINT `tblSucursales_tblAgencia` FOREIGN KEY (`intIdAgencia`) REFERENCES `tblagencia_viajes` (`intIdAgencia`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

/*Data for the table `tblsucursales` */

insert  into `tblsucursales`(`intIdSucursal`,`vchNombre`,`vchEncargado`,`vchDireccion`,`vchTelefono`,`intIdAgencia`) values (1,'Huejutla','Fabian Santiago Hernández','Acuatempa','9839574633',1),(2,'Agencia Huitzi','Sergio Hernández Vite','Huitzisilingo','8819382981',1),(4,'Super Chihiko','Sergio Hernández Vite','Tu corazon','0101010102',1);

/*Table structure for table `tbltipotransporte` */

DROP TABLE IF EXISTS `tbltipotransporte`;

CREATE TABLE `tbltipotransporte` (
  `intIdTipo` int(5) NOT NULL AUTO_INCREMENT,
  `vchNombreTipo` varchar(30) NOT NULL,
  PRIMARY KEY (`intIdTipo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `tbltipotransporte` */

/*Table structure for table `tblusuario` */

DROP TABLE IF EXISTS `tblusuario`;

CREATE TABLE `tblusuario` (
  `intIdUsuario` int(5) NOT NULL AUTO_INCREMENT,
  `vchUsuario` varchar(20) NOT NULL,
  `vchPassword` varchar(20) NOT NULL,
  `intIdNivel` int(5) NOT NULL,
  PRIMARY KEY (`intIdUsuario`),
  KEY `RelacionUsuarioNivel` (`intIdNivel`),
  CONSTRAINT `RelacionUsuarioNivel` FOREIGN KEY (`intIdNivel`) REFERENCES `tblnivel` (`intIdNivel`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

/*Data for the table `tblusuario` */

insert  into `tblusuario`(`intIdUsuario`,`vchUsuario`,`vchPassword`,`intIdNivel`) values (1,'admin','admin',1);

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
