\connect sales
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