create table cadastro(
	id serial primary key,
	nome varchar(250),
  email varchar(250),
  datanasc varchar(250),
  sexo varchar(250),
  rua varchar(250),
	numero int,
	cep int,
	cidade varchar(250),
  estado varchar(250),
	mensagem varchar(250)
);
