-- phpMyAdmin SQL Dump
-- version 5.1.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 12-Out-2021 às 03:04
-- Versão do servidor: 10.4.19-MariaDB
-- versão do PHP: 7.3.28

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `crm_default`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `curso`
--

CREATE TABLE `curso` (
  `id` int(11) NOT NULL,
  `titulo` varchar(250) NOT NULL,
  `data_inicio` datetime NOT NULL,
  `data_termino` datetime NOT NULL,
  `qnt_de_inscricoes` int(11) NOT NULL,
  `categoria` enum('ENEM','CRM4U','Agendado','Tradicional') NOT NULL,
  `periodo_letivo` varchar(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `curso`
--

INSERT INTO `curso` (`id`, `titulo`, `data_inicio`, `data_termino`, `qnt_de_inscricoes`, `categoria`, `periodo_letivo`) VALUES
(15, 'Curso 1', '2021-10-11 13:49:00', '2021-10-28 13:49:00', 3, 'Tradicional', '2021/2'),
(17, 'Curso 2', '2021-10-11 15:33:00', '2021-10-13 15:33:00', 4, 'ENEM', '2021/2'),
(18, 'Curso 3', '2022-01-01 16:38:00', '2022-10-11 16:38:00', 3, 'Agendado', '2022/1');

-- --------------------------------------------------------

--
-- Estrutura da tabela `inscricao`
--

CREATE TABLE `inscricao` (
  `id` int(11) NOT NULL,
  `nome` varchar(250) NOT NULL,
  `data_de_inscricao` datetime NOT NULL,
  `status` enum('Inscrito','Classificado','Convocado','Matriculado') NOT NULL,
  `lead_id` int(11) NOT NULL,
  `curso_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `inscricao`
--

INSERT INTO `inscricao` (`id`, `nome`, `data_de_inscricao`, `status`, `lead_id`, `curso_id`) VALUES
(18, 'Daniel', '2021-10-11 13:51:40', 'Convocado', 22, 15);

-- --------------------------------------------------------

--
-- Estrutura da tabela `lead`
--

CREATE TABLE `lead` (
  `id` int(11) NOT NULL,
  `nome` varchar(250) NOT NULL,
  `email` varchar(250) NOT NULL,
  `telefone` varchar(15) NOT NULL,
  `cpf` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `lead`
--

INSERT INTO `lead` (`id`, `nome`, `email`, `telefone`, `cpf`) VALUES
(22, 'Daniel', 'Daniel@gmail.com', '(12) 12312-4312', '111.111.111-11'),
(24, 'Gabriel', 'Gabriel@gmail.com', '(11) 11111-1111', '123.512.331-23'),
(28, 'Henrique', 'Henrique@gmail.com', '(76) 39761-2793', '128.376.178-62'),
(29, 'Guilherme', 'Guilherme@gmail.com', '(12) 31245-1512', '123.145.125-23');

-- --------------------------------------------------------

--
-- Estrutura da tabela `usuario`
--

CREATE TABLE `usuario` (
  `id` int(11) NOT NULL,
  `login` varchar(250) NOT NULL,
  `senha` varchar(250) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `usuario`
--

INSERT INTO `usuario` (`id`, `login`, `senha`) VALUES
(1, 'bob', '123'),
(3, 'Gui', '123');

--
-- Índices para tabelas despejadas
--

--
-- Índices para tabela `curso`
--
ALTER TABLE `curso`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `titulo` (`titulo`);

--
-- Índices para tabela `inscricao`
--
ALTER TABLE `inscricao`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_inscricao_lead_idx` (`lead_id`),
  ADD KEY `fk_inscricao_curso1_idx` (`curso_id`);

--
-- Índices para tabela `lead`
--
ALTER TABLE `lead`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `email` (`email`);

--
-- Índices para tabela `usuario`
--
ALTER TABLE `usuario`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `login` (`login`);

--
-- AUTO_INCREMENT de tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `curso`
--
ALTER TABLE `curso`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;

--
-- AUTO_INCREMENT de tabela `inscricao`
--
ALTER TABLE `inscricao`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;

--
-- AUTO_INCREMENT de tabela `lead`
--
ALTER TABLE `lead`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=30;

--
-- AUTO_INCREMENT de tabela `usuario`
--
ALTER TABLE `usuario`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Restrições para despejos de tabelas
--

--
-- Limitadores para a tabela `inscricao`
--
ALTER TABLE `inscricao`
  ADD CONSTRAINT `fk_inscricao_curso1` FOREIGN KEY (`curso_id`) REFERENCES `curso` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_inscricao_lead` FOREIGN KEY (`lead_id`) REFERENCES `lead` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
