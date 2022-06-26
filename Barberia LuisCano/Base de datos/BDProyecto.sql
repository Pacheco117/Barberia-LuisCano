-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 24-06-2022 a las 01:51:15
-- Versión del servidor: 10.4.24-MariaDB
-- Versión de PHP: 8.1.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `barberiaproyectofinal`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `agendar`
--

CREATE TABLE `agendar` (
  `N_cita` int(20) NOT NULL,
  `Telefono` bigint(30) NOT NULL,
  `Nservicio` int(20) NOT NULL,
  `ID_Hora` int(20) NOT NULL,
  `Fecha` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `agendar`
--

INSERT INTO `agendar` (`N_cita`, `Telefono`, `Nservicio`, `ID_Hora`, `Fecha`) VALUES
(31, 993218328, 3, 3, 'lunes, 20 de junio de 2022'),
(33, 99984812, 2, 3, 'lunes, 20 de junio de 2022'),
(34, 92818382, 3, 3, 'lunes, 20 de junio de 2022'),
(35, 99218382, 2, 2, 'miércoles, 22 de junio de 2022'),
(36, 0, 1, 3, 'miércoles, 22 de junio de 2022'),
(37, 99988821, 2, 2, 'miércoles, 22 de junio de 2022'),
(38, 99838212, 1, 4, 'miércoles, 22 de junio de 2022'),
(39, 99218812, 2, 2, 'jueves, 23 de junio de 2022'),
(41, 99983282, 1, 2, 'jueves, 23 de junio de 2022'),
(43, 2147483647, 3, 2, 'jueves, 23 de junio de 2022'),
(44, 21392138, 2, 2, 'miércoles, 22 de junio de 2022'),
(47, 6666666666, 1, 6, 'viernes, 24 de junio de 2022');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `clientes`
--

CREATE TABLE `clientes` (
  `Telefono` bigint(30) NOT NULL,
  `Nombre` varchar(50) NOT NULL,
  `ApellidoP` varchar(50) NOT NULL,
  `ApellidoM` varchar(50) NOT NULL,
  `ID_Sexo` int(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `clientes`
--

INSERT INTO `clientes` (`Telefono`, `Nombre`, `ApellidoP`, `ApellidoM`, `ID_Sexo`) VALUES
(1389212, 'Manuel', 'Serralta', 'Leon', 1),
(9353815, 'Alejandro', 'Sagundo', 'Duarte', 1),
(21392138, 'Teemo', 'Pamtheon', 'Garen', 1),
(21412567, 'Gerardo', 'Rogelio', 'Nayarat', 1),
(92818382, 'Gustabo', 'Abduzkan', 'Tercero', 1),
(99218382, 'Fiona', 'Rosales', 'Cuarta', 2),
(99218812, 'Cristiano', 'SIUUUUU', 'CR7', 2),
(99983282, 'Yasuo', 'Jose', 'Perez', 1),
(99984815, 'Rosaa', 'Paredes', 'Gonzales', 2),
(99988281, 'Messi', 'Elbicho', 'Misie', 1),
(99988821, 'mares', 'REyes', 'Pereez', 1),
(212146757, 'Gerardo', 'Rogelio', 'Facundo', 1),
(992618770, 'Mateoo', 'Hojaa', 'Tortillaa', 2),
(993218328, 'mares', 'REyes', '212146757', 1),
(2147483647, 'Alejandro', 'Sagundo', 'Duarte', 1),
(9992000000, 'Alejandro', 'Sagundo', 'Duarte', 1),
(9996087626, 'Trundle', 'Perez', 'Pech', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `hora`.
--

CREATE TABLE `hora` (
  `ID_Hora` int(20) NOT NULL,
  `Hora` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `hora`
--

INSERT INTO `hora` (`ID_Hora`, `Hora`) VALUES
(1, '2:00 PM'),
(2, '3:00 PM'),
(3, '4:00 PM'),
(4, '5:00 PM'),
(5, '6:00 PM'),
(6, '7:00 PM');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `servicios`
--

CREATE TABLE `servicios` (
  `Nservicio` int(20) NOT NULL,
  `Servicio` varchar(50) NOT NULL,
  `Precio` int(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `servicios`
--

INSERT INTO `servicios` (`Nservicio`, `Servicio`, `Precio`) VALUES
(1, 'Corte Adulto', 70),
(2, 'Corte niño', 50),
(3, 'Black mask', 80),
(4, 'Corte ceja', 30),
(5, 'Corte y barba', 130);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sexo`
--

CREATE TABLE `sexo` (
  `ID_Sexo` int(20) NOT NULL,
  `Sexo` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `sexo`
--

INSERT INTO `sexo` (`ID_Sexo`, `Sexo`) VALUES
(1, 'Hombre'),
(2, 'Mujer');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `agendar`
--
ALTER TABLE `agendar`
  ADD PRIMARY KEY (`N_cita`),
  ADD KEY `Nservicio` (`Nservicio`,`ID_Hora`),
  ADD KEY `ID_Hora` (`ID_Hora`),
  ADD KEY `Telefono` (`Telefono`) USING BTREE;

--
-- Indices de la tabla `clientes`
--
ALTER TABLE `clientes`
  ADD PRIMARY KEY (`Telefono`) USING BTREE,
  ADD KEY `ID_Sexo` (`ID_Sexo`);

--
-- Indices de la tabla `hora`
--
ALTER TABLE `hora`
  ADD PRIMARY KEY (`ID_Hora`);

--
-- Indices de la tabla `servicios`
--
ALTER TABLE `servicios`
  ADD PRIMARY KEY (`Nservicio`);

--
-- Indices de la tabla `sexo`
--
ALTER TABLE `sexo`
  ADD PRIMARY KEY (`ID_Sexo`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `agendar`
--
ALTER TABLE `agendar`
  MODIFY `N_cita` int(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=48;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `agendar`
--
ALTER TABLE `agendar`
  ADD CONSTRAINT `agendar_ibfk_1` FOREIGN KEY (`Nservicio`) REFERENCES `servicios` (`Nservicio`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `agendar_ibfk_3` FOREIGN KEY (`ID_Hora`) REFERENCES `hora` (`ID_Hora`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `clientes`
--
ALTER TABLE `clientes`
  ADD CONSTRAINT `clientes_ibfk_2` FOREIGN KEY (`ID_Sexo`) REFERENCES `sexo` (`ID_Sexo`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
