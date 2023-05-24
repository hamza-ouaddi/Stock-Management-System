create database gestion

create table Users(
id_users integer,
login_users varchar(30),
password_users varchar(30),
nom_users varchar(30),
prenom_users varchar(30),
tele_users varchar(15),
note varchar(200),
constraint pk_users primary key (id_users)
);

create table Produits(
id_prod integer,
libelle varchar(30),
pu_prod float,
type_prod varchar(30),
prix_vente float,
note_prod varchar(200),
code_barre varchar(30),

constraint pk_produits primary key (id_prod)
);

create table Fournisseurs(
id_fourn integer,
nom_fourn varchar(30),
adresse_fourn varchar(30),
tele_fourn varchar(15),
note_fourn varchar(200),

constraint pk_fournisseurs primary key (id_fourn)
);

create table Achat(
id_achat integer,
date_achat varchar(30),
qte_achat integer,
id_prod integer,
id_fourn integer,
note_achat varchar(200),

constraint pk_achat primary key (id_achat),
constraint fk_achat_produits foreign key (id_prod) references Produits(id_prod),
constraint fk_achat_fournisseurs foreign key (id_fourn) references Fournisseurs(id_fourn),
);


create table Client(
id_client integer,
nom_client varchar(30),
adresse_client varchar(30),
tele_client varchar(15),
note_client varchar(200),

constraint pk_client primary key (id_client)
);

create table Vente(
id_vente integer,
date_vente varchar(30),
qte_vente integer,
pu_achat float,
pu_vente float,
id_prod integer,
id_client integer,
note_vente varchar(200),

constraint pk_vente primary key (id_vente),
constraint fk_vente_produits foreign key (id_prod) references Produits(id_prod),
constraint fk_vente_client foreign key (id_client) references Client(id_client)
);

select*from USERS
select*from PRODUITS
select*from FOURNISSEURS
select*from ACHAT
select*from CLIENT
select*from VENTE

drop database gestion

drop table Users
drop table Produits
drop table Fournisseurs
drop table Achat
drop table Client
drop table Vente

