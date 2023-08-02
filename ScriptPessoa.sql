create database pessoa;
use pessoa;
create table cadastroPessoa(
	codigo int not null primary key auto_increment,
    nome varchar(120) not null,
    telefone varchar(13) not null,
    cidade varchar(50) not null,
    uf varchar(3) not null
)Engine = InnoDB;

insert into cadastroPessoa(codigo, nome, telefone, cidade, uf)
values('','Allan','119999999','São Paulo','SP');

select * from cadastroPessoa;