INSERT INTO "region" ("id", "name") values (1,'Støedoèeský kraj');
INSERT INTO "region" ("id", "name") values (2,'Plzeòksý kraj');
INSERT INTO "region" ("id", "name") values (3,'Ústecký kraj');
INSERT INTO "region" ("id", "name") values (4,'Karlovarský kraj');
INSERT INTO "region" ("id", "name") values (5,'Jihoèeský kraj');
INSERT INTO "region" ("id", "name") values (6,'Moravský kraj');

INSERT INTO "car_model" ("id", "manufacturer", "type", "engine", "year","mililiters_per_100")
  values (1,'Ford','Focus','1.6 MPI',2005,8000);
INSERT INTO "car_model" ("id", "manufacturer", "type", "engine", "year","mililiters_per_100")
  values (2,'Ford','Mondeo','1.9 TDI',2009,6300);
INSERT INTO "car_model" ("id", "manufacturer", "type", "engine", "year","mililiters_per_100")
  values (3,'Škoda','Octavia','1.4 TDI',2011,5400);
INSERT INTO "car_model" ("id", "manufacturer", "type", "engine", "year","mililiters_per_100")
  values (4,'Škoda','Superb','2.0 TDI',200,6700);

INSERT INTO "service_type" ("id", "name") values (0,'Other');
INSERT INTO "service_type" ("id", "name") values (1,'Výmìna oleje');
INSERT INTO "service_type" ("id", "name") values (2,'Výmìna fitrù');
INSERT INTO "service_type" ("id", "name") values (3,'Oprava tlumièù');
INSERT INTO "service_type" ("id", "name") values (4,'Seøízení pøevodovky');
INSERT INTO "service_type" ("id", "name") values (5,'Doplnìní vzduchu v pneu');