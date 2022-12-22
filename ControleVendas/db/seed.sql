#!/usr/bin/env bash
psql "postgres://$POSTGRES_USER:$POSTGRES_PASSWORD@$POSTGRES_HOST/$POSTGRES_DB?sslmode=disable" <<-EOSQL
CREATE TABLE users (
        id integer GENERATED BY DEFAULT AS IDENTITY,
        name text NOT NULL,
        email text NOT NULL,
        password text NOT NULL,
        role text NOT NULL DEFAULT 'seller',
        CONSTRAINT "PK_users" PRIMARY KEY (id)
    );
    
    Insert into users(id, name, email, password, role) values( 1, 'Edson A. do Nascimento', 'pele@magazineaziul.com.br','123mudar', 'NationalDirector');
    Insert into users(id, name, email, password, role) values( 2, 'Vagner Mancini', 'vagner.mancini@magazineaziul.com.br','123mudar', 'Director');
    Insert into users(id, name, email, password, role) values( 3, 'Abel Ferreira', 'abel.ferreira@magazineaziul.com.br','123mudar', 'Director');
    Insert into users(id, name, email, password, role) values( 4, 'Rogerio Ceni', 'rogerio.ceni@magazineaziul.com.br','123mudar', 'Director');
    Insert into users(id, name, email, password, role) values( 5, 'Ronaldinho Gaucho', 'ronaldinho.gaucho@magazineaziul.com.br','123mudar', 'Manager');
    Insert into users(id, name, email, password, role) values( 6, 'Roberto Firmino', 'roberto.firmino@magazineaziul.com.br','123mudar', 'Manager');
    Insert into users(id, name, email, password, role) values( 7, 'Alex de Souza', 'alex.de.souza@magazineaziul.com.br','123mudar', 'Manager');
    Insert into users(id, name, email, password, role) values( 8, 'Françoaldo Souza', 'françoaldo.souza@magazineaziul.com.br','123mudar', 'Manager');
    Insert into users(id, name, email, password, role) values( 9, 'Romário Faria', 'romário.faria@magazineaziul.com.br','123mudar', 'Manager');
    Insert into users(id, name, email, password, role) values( 10, 'Ricardo Goulart', 'ricardo.goulart@magazineaziul.com.br','123mudar', 'Manager');
    Insert into users(id, name, email, password, role) values( 11, 'Dejan Petkovic', 'dejan.petkovic@magazineaziul.com.br','123mudar', 'Manager');
    Insert into users(id, name, email, password, role) values( 12, 'Deyverson Acosta', 'deyverson.acosta@magazineaziul.com.br','123mudar', 'Manager');
    Insert into users(id, name, email, password, role) values( 13, 'Harlei Silva', 'harlei.silva@magazineaziul.com.br','123mudar', 'Manager');
    Insert into users(id, name, email, password, role) values( 14, 'Walter Henrique', 'walter.henrique@magazineaziul.com.br','123mudar', 'Manager');
    Insert into users(id, name, email, password, role) values( 15,'Afonso Afancar','afonso.afancar@magazineaziul.com.br','123mudar', 'Seller');
    Insert into users(id, name, email, password, role) values( 16,'Alceu Andreoli','alceu.andreoli@magazineaziul.com.br','123mudar', 'Seller');
    Insert into users(id, name, email, password, role) values( 17,'Amalia Zago','amalia.zago@magazineaziul.com.br','123mudar', 'Seller');
    Insert into users(id, name, email, password, role) values( 18,'Carlos Eduardo','carlos.eduardo@magazineaziul.com.br','123mudar', 'Seller');
    Insert into users(id, name, email, password, role) values( 19,'Luiz Felipe','luiz.felipe@magazineaziul.com.br','123mudar', 'Seller');
    Insert into users(id, name, email, password, role) values( 20,'Breno','breno@magazineaziul.com.br','123mudar', 'Seller');
    Insert into users(id, name, email, password, role) values( 21,'Emanuel','emanuel@magazineaziul.com.br','123mudar', 'Seller');
    Insert into users(id, name, email, password, role) values( 22,'Ryan','ryan@magazineaziul.com.br','123mudar', 'Seller');
    Insert into users(id, name, email, password, role) values( 23,'Vitor Hugo','vitor.hugo@magazineaziul.com.br','123mudar', 'Seller');
    Insert into users(id, name, email, password, role) values( 24,'Yuri','yuri@magazineaziul.com.br','123mudar', 'Seller');
    Insert into users(id, name, email, password, role) values( 25,'Benjamin','benjamin@magazineaziul.com.br','123mudar', 'Seller');
    Insert into users(id, name, email, password, role) values( 26,'Erick','erick@magazineaziul.com.br','123mudar', 'Seller');
    Insert into users(id, name, email, password, role) values( 27,'Enzo Gabriel','enzo.gabriel@magazineaziul.com.br','123mudar', 'Seller');
    Insert into users(id, name, email, password, role) values( 28,'Fernando','fernando@magazineaziul.com.br','123mudar', 'Seller');
    Insert into users(id, name, email, password, role) values( 29,'Joaquim','joaquim@magazineaziul.com.br','123mudar', 'Seller');
    Insert into users(id, name, email, password, role) values( 30,'André','andré@magazineaziul.com.br','123mudar', 'Seller');
    Insert into users(id, name, email, password, role) values( 31,'Raul','raul@magazineaziul.com.br','123mudar', 'Seller');
    Insert into users(id, name, email, password, role) values( 32,'Marcelo','marcelo@magazineaziul.com.br','123mudar', 'Seller');
    Insert into users(id, name, email, password, role) values( 33,'Julio César','julio.césar@magazineaziul.com.br','123mudar', 'Seller');
    Insert into users(id, name, email, password, role) values( 34,'Cauê','cauê@magazineaziul.com.br','123mudar', 'Seller');
    Insert into users(id, name, email, password, role) values( 35,'Benício','benício@magazineaziul.com.br','123mudar', 'Seller');
    Insert into users(id, name, email, password, role) values( 36,'Vitor Gabriel','vitor.gabriel@magazineaziul.com.br','123mudar', 'Seller');
    Insert into users(id, name, email, password, role) values( 37,'Augusto','augusto@magazineaziul.com.br','123mudar', 'Seller');
    Insert into users(id, name, email, password, role) values( 38,'Pedro Lucas','pedro.lucas@magazineaziul.com.br','123mudar', 'Seller');
    Insert into users(id, name, email, password, role) values( 39,'Luiz Gustavo','luiz.gustavo@magazineaziul.com.br','123mudar', 'Seller');
    Insert into users(id, name, email, password, role) values( 40,'Giovanni','giovanni@magazineaziul.com.br','123mudar', 'Seller');
    Insert into users(id, name, email, password, role) values( 41,'Renato','renato@magazineaziul.com.br','123mudar', 'Seller');
    Insert into users(id, name, email, password, role) values( 42,'Diego','diego@magazineaziul.com.br','123mudar', 'Seller');
    Insert into users(id, name, email, password, role) values( 43,'João Paulo','joão.paulo@magazineaziul.com.br','123mudar', 'Seller');
    Insert into users(id, name, email, password, role) values( 44,'Renan','renan@magazineaziul.com.br','123mudar', 'Seller');
    Insert into users(id, name, email, password, role) values( 45,'Luiz Fernando','luiz.fernando@magazineaziul.com.br','123mudar', 'Seller');
    Insert into users(id, name, email, password, role) values( 46,'Anthony','anthony@magazineaziul.com.br','123mudar', 'Seller');
    Insert into users(id, name, email, password, role) values( 47,'Lucas Gabriel','lucas.gabriel@magazineaziul.com.br','123mudar', 'Seller');
    Insert into users(id, name, email, password, role) values( 48,'Thales','thales@magazineaziul.com.br','123mudar', 'Seller');
    Insert into users(id, name, email, password, role) values( 49,'Luiz Miguel','luiz.miguel@magazineaziul.com.br','123mudar', 'Seller');
    Insert into users(id, name, email, password, role) values( 50,'Henry','henry@magazineaziul.com.br','123mudar', 'Seller');
    Insert into users(id, name, email, password, role) values( 51,'Marcos Vinicius','marcos.vinicius@magazineaziul.com.br','123mudar', 'Seller');
    Insert into users(id, name, email, password, role) values( 52,'Kevin','kevin@magazineaziul.com.br','123mudar', 'Seller');
    Insert into users(id, name, email, password, role) values( 53,'Levi','levi@magazineaziul.com.br','123mudar', 'Seller');
    Insert into users(id, name, email, password, role) values( 54,'Enrico','enrico@magazineaziul.com.br','123mudar', 'Seller');
    Insert into users(id, name, email, password, role) values( 55,'João Lucas','joão.lucas@magazineaziul.com.br','123mudar', 'Seller');
    Insert into users(id, name, email, password, role) values( 56,'Hugo','hugo@magazineaziul.com.br','123mudar', 'Seller');
    Insert into users(id, name, email, password, role) values( 57,'Luiz Guilherme','luiz.guilherme@magazineaziul.com.br','123mudar', 'Seller');
    Insert into users(id, name, email, password, role) values( 58,'Matheus Henrique','matheus.henrique@magazineaziul.com.br','123mudar', 'Seller');
    Insert into users(id, name, email, password, role) values( 59,'Miguel','miguel@magazineaziul.com.br','123mudar', 'Seller');
    Insert into users(id, name, email, password, role) values( 60,'Davi','davi@magazineaziul.com.br','123mudar', 'Seller');
    Insert into users(id, name, email, password, role) values( 61,'Gabriel','gabriel@magazineaziul.com.br','123mudar', 'Seller');
    Insert into users(id, name, email, password, role) values( 62,'Arthur','arthur@magazineaziul.com.br','123mudar', 'Seller');
    Insert into users(id, name, email, password, role) values( 63,'Lucas','lucas@magazineaziul.com.br','123mudar', 'Seller');
    Insert into users(id, name, email, password, role) values( 64,'Matheus','matheus@magazineaziul.com.br','123mudar', 'Seller');
    
    CREATE TABLE nationaldirectors (
        id integer NOT NULL,
        CONSTRAINT "PK_nationaldirectors" PRIMARY KEY (id)
    );

    CREATE TABLE directors (
        id integer NOT NULL,
        "BoardID" integer NOT NULL,
        CONSTRAINT "PK_directors" PRIMARY KEY (id)
    );
    
    CREATE TABLE managers (
        id integer NOT NULL,
        "UnityID" integer NOT NULL,
        CONSTRAINT "PK_managers" PRIMARY KEY (id)
    );
    
    

    CREATE TABLE boards (
        id integer GENERATED BY DEFAULT AS IDENTITY,
        name text NOT NULL,
        "DirectorID" integer NOT NULL,
        CONSTRAINT "PK_boards" PRIMARY KEY (id)
    );

    CREATE TABLE unities (
        id integer GENERATED BY DEFAULT AS IDENTITY,
        name text NOT NULL,
        latitude text NOT NULL,
        longitude text NOT NULL,
        "ManagerID" integer NOT NULL,
        "BoardID" integer NOT NULL,
        CONSTRAINT "PK_unities" PRIMARY KEY (id)
    );

    CREATE TABLE sellers (
        id integer NOT NULL,
        "UnityID" integer NOT NULL,
        CONSTRAINT "PK_sellers" PRIMARY KEY (id)
    );

    CREATE TABLE sales (
        id integer GENERATED BY DEFAULT AS IDENTITY,
        created_at timestamp with time zone NOT NULL,
        roaming_unity_id integer NULL,
        "SellerID" integer NOT NULL,
        "UnityID" integer NOT NULL,
        CONSTRAINT "PK_sales" PRIMARY KEY (id)
    );    
    Insert into nationaldirectors(id) values(1);
        insert into boards(id, name, "DirectorID") values( 1, 'Sul', 2);
        insert into boards(id, name, "DirectorID") values( 2, 'Sudeste', 3);
        insert into boards(id, name, "DirectorID") values( 3, 'Centro-oeste', 4);
        insert into directors(id, "BoardID") values( 2, 1);
        insert into directors(id, "BoardID") values( 3, 2);
        insert into directors(id, "BoardID") values( 4, 3);
        insert into managers(id, "UnityID") values( 5, 1);
        insert into managers(id, "UnityID") values( 6, 2);
        insert into managers(id, "UnityID") values( 7, 3);
        insert into managers(id, "UnityID") values( 8, 4);
        insert into managers(id, "UnityID") values( 9, 5);
        insert into managers(id, "UnityID") values( 10, 6);
        insert into managers(id, "UnityID") values( 11, 7);
        insert into managers(id, "UnityID") values( 12, 8);
        insert into managers(id, "UnityID") values( 13, 9);
        insert into managers(id, "UnityID") values( 14, 10);
        insert into unities(id, name, latitude, longitude, "ManagerID", "BoardID") values( 1, 'Porto Alegre', '-30.048750057541955', '-51.228587422990806', 5, 1);
        insert into unities(id, name, latitude, longitude, "ManagerID", "BoardID") values( 2, 'Florianopolis', '-27.55393525017396', '-48.49841515885026', 6, 1);
        insert into unities(id, name, latitude, longitude, "ManagerID", "BoardID") values( 3, 'Curitiba', '-25.473704465731746', '-49.24787198992874', 7, 1);
        insert into unities(id, name, latitude, longitude, "ManagerID", "BoardID") values( 4, 'Sao Paulo', '-23.544259437612844', '-46.64370714029131', 8, 2);
        insert into unities(id, name, latitude, longitude, "ManagerID", "BoardID") values( 5, 'Rio de Janeiro', '-22.923447510604802', '-43.23208495438858', 9, 2);
        insert into unities(id, name, latitude, longitude, "ManagerID", "BoardID") values( 6, 'Belo Horizonte', '-19.917854829716372', '-43.94089385954766', 10, 2);
        insert into unities(id, name, latitude, longitude, "ManagerID", "BoardID") values( 7, 'Vitória', '-20.340992420772206', '-40.38332271475097', 11, 2);
        insert into unities(id, name, latitude, longitude, "ManagerID", "BoardID") values( 8, 'Campo Grande', '-20.462652006300377', '-54.615658937666645', 12, 3);
        insert into unities(id, name, latitude, longitude, "ManagerID", "BoardID") values( 9, 'Goiania', '-16.673126240814387', '-49.25248826354209', 13, 3);
        insert into unities(id, name, latitude, longitude, "ManagerID", "BoardID") values( 10, 'Cuiaba', '-15.601754458320842', '-56.09832706558089', 14, 3);
        Insert into sellers(id, "UnityID") values( 15,6);
        Insert into sellers(id, "UnityID") values( 16,6);
        Insert into sellers(id, "UnityID") values( 17,6);
        Insert into sellers(id, "UnityID") values( 18,6);
        Insert into sellers(id, "UnityID") values( 19,6);
        Insert into sellers(id, "UnityID") values( 20,6);
        Insert into sellers(id, "UnityID") values( 21,8);
        Insert into sellers(id, "UnityID") values( 22,8);
        Insert into sellers(id, "UnityID") values( 23,8);
        Insert into sellers(id, "UnityID") values( 24,8);
        Insert into sellers(id, "UnityID") values( 25,8);
        Insert into sellers(id, "UnityID") values( 26,10);
        Insert into sellers(id, "UnityID") values( 27,10);
        Insert into sellers(id, "UnityID") values( 28,10);
        Insert into sellers(id, "UnityID") values( 29,10);
        Insert into sellers(id, "UnityID") values( 30,10);
        Insert into sellers(id, "UnityID") values( 31,3);
        Insert into sellers(id, "UnityID") values( 32,3);
        Insert into sellers(id, "UnityID") values( 33,3);
        Insert into sellers(id, "UnityID") values( 34,3);
        Insert into sellers(id, "UnityID") values( 35,3);
        Insert into sellers(id, "UnityID") values( 36,2);
        Insert into sellers(id, "UnityID") values( 37,2);
        Insert into sellers(id, "UnityID") values( 38,2);
        Insert into sellers(id, "UnityID") values( 39,2);
        Insert into sellers(id, "UnityID") values( 40,2);
        Insert into sellers(id, "UnityID") values( 41,9);
        Insert into sellers(id, "UnityID") values( 42,9);
        Insert into sellers(id, "UnityID") values( 43,9);
        Insert into sellers(id, "UnityID") values( 44,9);
        Insert into sellers(id, "UnityID") values( 45,9);
        Insert into sellers(id, "UnityID") values( 46,1);
        Insert into sellers(id, "UnityID") values( 47,1);
        Insert into sellers(id, "UnityID") values( 48,1);
        Insert into sellers(id, "UnityID") values( 49,1);
        Insert into sellers(id, "UnityID") values( 50,1);
        Insert into sellers(id, "UnityID") values( 51,5);
        Insert into sellers(id, "UnityID") values( 52,5);
        Insert into sellers(id, "UnityID") values( 53,5);
        Insert into sellers(id, "UnityID") values( 54,5);
        Insert into sellers(id, "UnityID") values( 55,5);
        Insert into sellers(id, "UnityID") values( 56,4);
        Insert into sellers(id, "UnityID") values( 57,4);
        Insert into sellers(id, "UnityID") values( 58,4);
        Insert into sellers(id, "UnityID") values( 59,4);
        Insert into sellers(id, "UnityID") values( 60,7);
        Insert into sellers(id, "UnityID") values( 61,7);
        Insert into sellers(id, "UnityID") values( 62,7);
        Insert into sellers(id, "UnityID") values( 63,7);
        Insert into sellers(id, "UnityID") values( 64,7);
    ALTER TABLE directors ADD CONSTRAINT "FK_directors_users_id" FOREIGN KEY (id) REFERENCES users (id) ON DELETE CASCADE;
    ALTER TABLE managers ADD CONSTRAINT "FK_managers_users_id" FOREIGN KEY (id) REFERENCES users (id) ON DELETE CASCADE;
    ALTER TABLE nationaldirectors ADD CONSTRAINT "FK_nationaldirectors_users_id" FOREIGN KEY (id) REFERENCES users (id) ON DELETE CASCADE;
    ALTER TABLE boards ADD CONSTRAINT "FK_boards_directors_DirectorID" FOREIGN KEY ("DirectorID") REFERENCES directors (id) ON DELETE CASCADE;
    ALTER TABLE unities ADD CONSTRAINT "FK_unities_boards_BoardID" FOREIGN KEY ("BoardID") REFERENCES boards (id) ON DELETE CASCADE;
    ALTER TABLE unities ADD CONSTRAINT "FK_unities_managers_ManagerID" FOREIGN KEY ("ManagerID") REFERENCES managers (id) ON DELETE CASCADE;
    ALTER TABLE sellers ADD CONSTRAINT "FK_sellers_unities_UnityID" FOREIGN KEY ("UnityID") REFERENCES unities (id) ON DELETE CASCADE;
    ALTER TABLE sellers ADD CONSTRAINT "FK_sellers_users_id" FOREIGN KEY (id) REFERENCES users (id) ON DELETE CASCADE;
    ALTER TABLE sales ADD CONSTRAINT "FK_sales_sellers_SellerID" FOREIGN KEY ("SellerID") REFERENCES sellers (id) ON DELETE CASCADE;
    ALTER TABLE sales ADD CONSTRAINT "FK_sales_unities_UnityID" FOREIGN KEY ("UnityID") REFERENCES unities (id) ON DELETE CASCADE;
    CREATE UNIQUE INDEX "IX_boards_DirectorID" ON boards ("DirectorID");
    CREATE INDEX "IX_sales_SellerID" ON sales ("SellerID");
    CREATE INDEX "IX_sales_UnityID" ON sales ("UnityID");
    CREATE INDEX "IX_sellers_UnityID" ON sellers ("UnityID");
    CREATE INDEX "IX_unities_BoardID" ON unities ("BoardID");
    CREATE UNIQUE INDEX "IX_unities_ManagerID" ON unities ("ManagerID");
EOSQL

