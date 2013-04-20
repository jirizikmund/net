drop table "car" cascade constraints PURGE;
drop table "car_model" cascade constraints PURGE;
drop table "gas" cascade constraints PURGE;
drop table "region" cascade constraints PURGE;
drop table "service" cascade constraints PURGE;
drop table "service_type" cascade constraints PURGE;
drop table "users" cascade constraints PURGE;
drop table "other_expense" cascade constraints PURGE;

drop sequence "car_id_seq";
drop sequence "gas_id_seq";
drop sequence "service_id_seq";
drop sequence "users_id_seq";
drop sequence "other_expense_id_seq";