--Cadastrando o usuario Padrão do Sistema
insert into Usuario (Nome,Login,Senha,Status) values ('Administrador do Sistema','admin','admin',1);

--Cadastrando os Perfis
insert into Perfil (descricao) values('Inserir');--Id  = 1
insert into Perfil (descricao) values('Alterar');--Id  = 2
insert into Perfil (descricao) values('Excluir');--Id  = 3
insert into Perfil (descricao) values('Visualizar tela Usuario');--Id  = 4
insert into Perfil (descricao) values('Visualizar tela Titular');--Id  = 5

--Cadastrando Tags de Acesso
insert into Tag (PerfilId,TagId) values (1,101);-- Tag = 101 (Todos os Botoes de Novo)
insert into Tag (PerfilId,TagId) values (2,201);-- Tag = 201 (Todos os Botoes de Alterar)
insert into Tag (PerfilId,TagId) values (3,301);-- Tag = 301 (Todos os Botoes de Excluir)
insert into Tag (PerfilId,TagId) values (4,001);-- Tag = 001 (Tela de Cadastrar Usuario)
insert into Tag (PerfilId,TagId) values (5,002);-- Tag = 002 (Tela de Cadastrar Titular)

--Cadastrando todos os Planos
insert into Plano(Nome,Descricao,ValorPadrao) values('Golden','',10);
insert into Plano(Nome,Descricao,ValorPadrao) values('Golden Especial','',15);

--Adicionando todos os Perfis para o Administrador
insert into UsuarioPerfil(UsuarioId,PerfilId) values (1,1);
insert into UsuarioPerfil(UsuarioId,PerfilId) values (1,2);
insert into UsuarioPerfil(UsuarioId,PerfilId) values (1,3);
insert into UsuarioPerfil(UsuarioId,PerfilId) values (1,4);
insert into UsuarioPerfil(UsuarioId,PerfilId) values (1,5);