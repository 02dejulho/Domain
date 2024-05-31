-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 03-Maio-2023 às 23:21
-- Versão do servidor: 10.4.28-MariaDB
-- versão do PHP: 8.0.28

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `domain`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `agendamentos`
--

CREATE TABLE `agendamentos` (
  `idAg` int(11) NOT NULL,
  `nome` varchar(20) NOT NULL,
  `tel` varchar(11) NOT NULL,
  `data` date NOT NULL,
  `email` varchar(20) NOT NULL,
  `procedimento` varchar(20) NOT NULL,
  `clienteag` char(1) NOT NULL,
  `area` varchar(20) NOT NULL,
  `observacoes` varchar(150) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Extraindo dados da tabela `agendamentos`
--

INSERT INTO `agendamentos` (`idAg`, `nome`, `tel`, `data`, `email`, `procedimento`, `clienteag`, `area`, `observacoes`) VALUES
(1, 'Luciana', '11945454545', '2000-07-02', 'lulu@ciana.com', 'Pedicure', 'S', 'Mãos e Pés', NULL),
(2, 'Ana Morais', '11944557125', '1998-02-10', 'aninha@gmail.com', 'Carboxiterapia', 'N', 'Estética Corporal', NULL),
(3, 'Julia Lisboa', '11988776548', '2005-06-01', 'julinha.ju@hotmail.c', 'Depilação - Laser', 'N', 'Depilação', 'Axilas'),
(4, 'Larissa', '11978562512', '2000-04-08', 'lari@outlook.com', 'Design Sobrancelhas', 'S', 'Estética Facial', NULL),
(5, 'Eliane Soares', '11966554455', '1996-07-04', 'soares@gmail.com', 'Massagem Modeladora', 'S', 'Estética Corporal', 'Nenhuma'),
(6, 'Vanessa Oliveira', '11974752210', '2001-09-20', 'vanoli@yahoo.com', 'Depilação - Linha', 'S', 'Depilação', 'Face'),
(7, 'Daniela mendes', '11975565822', '2000-05-16', 'ddmm@outlook.com', 'Drenagem Linfática', 'N', 'Estética Corporal', NULL);

-- --------------------------------------------------------

--
-- Estrutura da tabela `faleconosco`
--

CREATE TABLE `faleconosco` (
  `idFc` int(11) NOT NULL,
  `nomefc` varchar(20) NOT NULL,
  `telfc` varchar(11) NOT NULL,
  `emailfc` varchar(20) NOT NULL,
  `cliente` char(3) NOT NULL,
  `msg` varchar(150) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Extraindo dados da tabela `faleconosco`
--

INSERT INTO `faleconosco` (`idFc`, `nomefc`, `telfc`, `emailfc`, `cliente`, `msg`) VALUES
(1, 'Adriana Lima', '11965852545', 'drilima@hotmail.com', 'Sim', 'Eu amei o espaço! A esteticista Jéssica me atendeu muito bem! Parabéns!'),
(2, 'Juliana Silva', '11941512516', 'juss32@gmail.com', 'Não', 'Bom dia! Poderiam me informar o valor da Carboxiterapia? Fico no aguardo.'),
(3, 'Erica Santos Rocha', '11974565822', 'eriquinharoc@outlook', 'Não', 'Está tudo muito caro! Não gostei!');

-- --------------------------------------------------------

--
-- Estrutura da tabela `usuario`
--

CREATE TABLE `usuario` (
  `idUser` int(11) NOT NULL,
  `nome` varchar(20) NOT NULL,
  `login` varchar(15) NOT NULL,
  `senha` varchar(15) NOT NULL,
  `dataNascimento` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Extraindo dados da tabela `usuario`
--

INSERT INTO `usuario` (`idUser`, `nome`, `login`, `senha`, `dataNascimento`) VALUES
(1, 'Ana Morais', 'anam', '410', '1979-02-10'),
(2, 'Daniela Araujo', 'danielaaraujo', '0123', '1989-12-14');

--
-- Índices para tabelas despejadas
--

--
-- Índices para tabela `agendamentos`
--
ALTER TABLE `agendamentos`
  ADD PRIMARY KEY (`idAg`);

--
-- Índices para tabela `faleconosco`
--
ALTER TABLE `faleconosco`
  ADD PRIMARY KEY (`idFc`);

--
-- Índices para tabela `usuario`
--
ALTER TABLE `usuario`
  ADD PRIMARY KEY (`idUser`);

--
-- AUTO_INCREMENT de tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `agendamentos`
--
ALTER TABLE `agendamentos`
  MODIFY `idAg` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT de tabela `faleconosco`
--
ALTER TABLE `faleconosco`
  MODIFY `idFc` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de tabela `usuario`
--
ALTER TABLE `usuario`
  MODIFY `idUser` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
