INSERT INTO "region" ("id", "name") values (1,'St�edo�esk� kraj');
INSERT INTO "region" ("id", "name") values (2,'Plze�ks� kraj');
INSERT INTO "region" ("id", "name") values (3,'�steck� kraj');
INSERT INTO "region" ("id", "name") values (4,'Karlovarsk� kraj');
INSERT INTO "region" ("id", "name") values (5,'Jiho�esk� kraj');
INSERT INTO "region" ("id", "name") values (6,'Moravsk� kraj');

INSERT INTO "car_model" ("id", "manufacturer", "type", "engine", "year","mililiters_per_100")
  values (1,'Ford','Focus','1.6 MPI',2005,8000);
INSERT INTO "car_model" ("id", "manufacturer", "type", "engine", "year","mililiters_per_100")
  values (2,'Ford','Mondeo','1.9 TDI',2009,6300);
INSERT INTO "car_model" ("id", "manufacturer", "type", "engine", "year","mililiters_per_100")
  values (3,'�koda','Octavia','1.4 TDI',2011,5400);
INSERT INTO "car_model" ("id", "manufacturer", "type", "engine", "year","mililiters_per_100")
  values (4,'�koda','Superb','2.0 TDI',200,6700);

INSERT INTO "service_type" ("id", "name") values (0,'Other');
INSERT INTO "service_type" ("id", "name") values (1,'V�m�na oleje');
INSERT INTO "service_type" ("id", "name") values (2,'V�m�na fitr�');
INSERT INTO "service_type" ("id", "name") values (3,'Oprava tlumi��');
INSERT INTO "service_type" ("id", "name") values (4,'Se��zen� p�evodovky');
INSERT INTO "service_type" ("id", "name") values (5,'Dopln�n� vzduchu v pneu');