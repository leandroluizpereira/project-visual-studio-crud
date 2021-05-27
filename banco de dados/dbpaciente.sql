-- phpMyAdmin SQL Dump
-- version 5.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 26-Maio-2021 às 22:26
-- Versão do servidor: 10.4.11-MariaDB
-- versão do PHP: 7.4.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `dbpaciente`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `tbfuncionario`
--

CREATE TABLE `tbfuncionario` (
  `matricula` int(255) NOT NULL,
  `nome` varchar(255) NOT NULL,
  `cargo` varchar(255) NOT NULL,
  `status` varchar(255) NOT NULL,
  `email` varchar(255) NOT NULL,
  `senha` int(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `tbfuncionario`
--

INSERT INTO `tbfuncionario` (`matricula`, `nome`, `cargo`, `status`, `email`, `senha`) VALUES
(1, 'Leandro', 'Gerente', '', 'adm@empresa.com', 123),
(3, 'paulo', 'Supervisor(a)', 'Ativo', 'paulo@empresa', 123);

-- --------------------------------------------------------

--
-- Estrutura da tabela `tbpaciente`
--

CREATE TABLE `tbpaciente` (
  `id` int(11) NOT NULL,
  `nome` varchar(255) NOT NULL,
  `Senha` int(255) NOT NULL,
  `email` varchar(255) NOT NULL,
  `celular` int(255) NOT NULL,
  `rua` varchar(255) NOT NULL,
  `numero` int(255) NOT NULL,
  `bairro` varchar(255) NOT NULL,
  `cpf` int(255) NOT NULL,
  `unidades` varchar(100) NOT NULL,
  `exames` varchar(100) NOT NULL,
  `data` varchar(100) NOT NULL,
  `horario` varchar(255) NOT NULL,
  `valor` varchar(255) NOT NULL,
  `pagamento` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `tbpaciente`
--

INSERT INTO `tbpaciente` (`id`, `nome`, `Senha`, `email`, `celular`, `rua`, `numero`, `bairro`, `cpf`, `unidades`, `exames`, `data`, `horario`, `valor`, `pagamento`) VALUES
(1, 'Leandro Luiz Pereira ', 0, 'leandro@gmail.com', 99, 'rua ', 999, 'bairro', 2147483647, 'Labóratorio Av. Paulista', 'Analises clinicas', '25/05/2021', '14:00', 'R$:148,00', 'Cartão de crédito'),
(2, 'ciclano da silva ', 0, 'ciclano@gmail.com', 99, 'rua', 999, 'bairro', 2147483647, 'Labóratorio Av. Santo Amaro', 'Eletrocardiograma', '25/05/2021', '14:30', 'R$:200,00', 'Cartão de crédito'),
(3, 'Paciente da silva ', 0, 'paciente@gmail.com', 2147483647, 'rua', 999, 'bairro', 2147483647, 'Labóratorio Av. Santo Amaro', 'Analises clinicas', '21/05/2021', '14:00', 'R$:148,00', 'Dinheiro'),
(4, 'maria ', 0, 'maria@gmail.com', 9999999, 'rua ', 999, 'bairro', 2147483647, 'Labóratorio Av. Moema', 'Ultrassonografia', '24/06/2021', '15:00', 'R$:100,00', 'Cartão de crédito');

--
-- Índices para tabelas despejadas
--

--
-- Índices para tabela `tbfuncionario`
--
ALTER TABLE `tbfuncionario`
  ADD PRIMARY KEY (`matricula`);

--
-- Índices para tabela `tbpaciente`
--
ALTER TABLE `tbpaciente`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT de tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `tbfuncionario`
--
ALTER TABLE `tbfuncionario`
  MODIFY `matricula` int(255) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de tabela `tbpaciente`
--
ALTER TABLE `tbpaciente`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
