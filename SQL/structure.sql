------ USERS -------------------------------------------------

CREATE TABLE "users"
(	"id" NUMBER NOT NULL ENABLE, 
	"login" VARCHAR2(32 CHAR) NOT NULL ENABLE, 
	"email" VARCHAR2(256 CHAR), 
	"password" VARCHAR2(32 CHAR) NOT NULL ENABLE, 
	"region_id" NUMBER NOT NULL ENABLE, 
	"born_year" NUMBER,
	"timestamp" TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
	 CONSTRAINT "users_pk" PRIMARY KEY ("id"),
	 CONSTRAINT "users_login_uk" UNIQUE ("login")
);

CREATE SEQUENCE "users_id_seq" INCREMENT BY 1 START WITH 1 nomaxvalue;

CREATE OR REPLACE TRIGGER "users_id_autoincrement"
BEFORE INSERT ON "users"
FOR EACH ROW
BEGIN
    SELECT "users_id_seq".nextval INTO :new."id" FROM dual;
END;
/
ALTER TRIGGER "users_id_autoincrement" ENABLE;
-----------------------------------------------------------------------------


-------- REGION -------------------------------------------------------

CREATE TABLE "region" 
(	"id" NUMBER NOT NULL ENABLE, 
	"name" VARCHAR2(64 CHAR),
	 CONSTRAINT "region_pk" PRIMARY KEY ("id")
);
-----------------------------------------------------------------------------


-------- CAR ----------------------------------------------------------

CREATE TABLE "car"
(	"id" NUMBER NOT NULL ENABLE, 
	"user_id" NUMBER NOT NULL ENABLE,
	"car_model_id" NUMBER DEFAULT 0 NOT NULL ENABLE,
	"name" VARCHAR2(64 CHAR),
	"cost" NUMBER,
	"bought_year" NUMBER,
	"timestamp" TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
	 CONSTRAINT "car_pk" PRIMARY KEY ("id")
);

CREATE SEQUENCE "car_id_seq" INCREMENT BY 1 START WITH 1 nomaxvalue;

CREATE OR REPLACE TRIGGER "car_id_autoincrement"
BEFORE INSERT ON "car"
FOR EACH ROW
BEGIN
    SELECT "car_id_seq".nextval INTO :new."id" FROM dual;
END;
/
ALTER TRIGGER "car_id_autoincrement" ENABLE;
-----------------------------------------------------------------------------


---------- CAR_MODEL ---------------------------------------------------

CREATE TABLE "car_model"
(	"id" NUMBER NOT NULL ENABLE, 
	"manufacturer" VARCHAR2(64 CHAR),
	"type" VARCHAR2(64 CHAR),
	"engine" VARCHAR2(64 CHAR),
	"year" NUMBER, 
	"mililiters_per_100" NUMBER,
	 CONSTRAINT "car_model_pk" PRIMARY KEY ("id")
);
-----------------------------------------------------------------------------


------------ GAS -----------------------------------------------------------

CREATE TABLE "gas"
(	"id" NUMBER NOT NULL ENABLE,
	"car_id" NUMBER NOT NULL ENABLE,
	"km" NUMBER,
	"mililiters" NUMBER,
	"cost" NUMBER,
	"date" DATE,
	"timestamp" TIMESTAMP DEFAULT CURRENT_TIMESTAMP, 
	 CONSTRAINT "gas_pk" PRIMARY KEY ("id")
);

CREATE SEQUENCE "gas_id_seq" INCREMENT BY 1 START WITH 1 nomaxvalue;

CREATE OR REPLACE TRIGGER "gas_id_autoincrement"
BEFORE INSERT ON "gas"
FOR EACH ROW
BEGIN
    SELECT "gas_id_seq".nextval INTO :new."id" FROM dual;
END;
/
ALTER TRIGGER "gas_id_autoincrement" ENABLE;
-----------------------------------------------------------------------------


------------ SERVICE -----------------------------------------------------------

CREATE TABLE "service"
(	"id" NUMBER NOT NULL ENABLE,
	"car_id" NUMBER NOT NULL ENABLE,
	"service_type_id" NUMBER DEFAULT 0 NOT NULL ENABLE,
	"km" NUMBER,
	"cost" NUMBER,
	"date" DATE,
	"description" VARCHAR2(1024 CHAR),
	"timestamp" TIMESTAMP DEFAULT CURRENT_TIMESTAMP, 
	 CONSTRAINT "service_pk" PRIMARY KEY ("id")
);

CREATE SEQUENCE "service_id_seq" INCREMENT BY 1 START WITH 1 nomaxvalue;

CREATE OR REPLACE TRIGGER "service_id_autoincrement"
BEFORE INSERT ON "service"
FOR EACH ROW
BEGIN
    SELECT "service_id_seq".nextval INTO :new."id" FROM dual;
END;
/
ALTER TRIGGER "gas_id_autoincrement" ENABLE;
-----------------------------------------------------------------------------


-------- SERVICE_TYPE -------------------------------------------------------

CREATE TABLE "service_type" 
(	"id" NUMBER NOT NULL ENABLE, 
	"name" VARCHAR2(50 CHAR),
	 CONSTRAINT "service_type_pk" PRIMARY KEY ("id")
);
-----------------------------------------------------------------------------


------- FOREGIN KEYS -------------
alter table "users" add constraint users_region_fk foreign key("region_id") references "region"("id");
alter table "car" add constraint car_users_fk foreign key("user_id") references "users"("id");
alter table "car" add constraint car_car_model_fk foreign key("car_model_id") references "car_model"("id");
alter table "gas" add constraint gas_car_fk foreign key("car_id") references "car"("id");
alter table "service" add constraint service_car_fk foreign key("car_id") references "car"("id");
alter table "service" add constraint service_service_type_fk foreign key("service_type_id") references "service_type"("id");
------------------------------------------