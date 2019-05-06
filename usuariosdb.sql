
//SQL SERVER
CREATE TABLE [dbo].[usuarios] (
  [id] [int] IDENTITY(1,1) PRIMARY KEY,
  [nome] [varchar](50) NOT NULL,
  [celular] [smallint] NOT NULL,
);

//MySQL

CREATE TABLE IF NOT EXISTS usuarios (
  id int NOT NULL AUTO_INCREMENT,
  nome varchar(220) COLLATE utf8_unicode_ci NOT NULL,
  celular int NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci; 
