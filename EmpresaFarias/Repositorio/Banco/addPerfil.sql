OBS: TIRAR OS "//" COM OS NUMEROS

insert into Usuario (Nome,Login,Senha,Status) values ('Administrador do Sistema','admin','admin',1);

insert into Perfil (descricao) values('Inserir');//1
insert into Perfil (descricao) values('Alterar');//2
insert into Perfil (descricao) values('Excluir');//3
insert into Perfil (descricao) values('Adicionar Usuario');//4


insert into Tag (PerfilId,TagId) values (1,101);

insert into Tag (PerfilId,TagId) values (2,201);

insert into Tag (PerfilId,TagId) values (3,301);


insert into Tag (PerfilId,TagId) values (4,001);

insert into Plano(Nome,Descricao,ValorPadrao) values('Golden','',10);
insert into Plano(Nome,Descricao,ValorPadrao) values('Golden Especial','',15);