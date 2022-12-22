\connect sales
	CREATE TABLE directors (
        id integer NOT NULL,
        "BoardID" integer NOT NULL,
        CONSTRAINT "PK_directors" PRIMARY KEY (id)
    );
    insert into directors(id, "BoardID") values( 2, 1);
    insert into directors(id, "BoardID") values( 3, 2);
    insert into directors(id, "BoardID") values( 4, 3);
