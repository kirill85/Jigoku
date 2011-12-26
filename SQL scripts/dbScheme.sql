create type "ContactType" as enum('ICQ', 'JID', 'MAILTO', 'MSN'); -- 0 - Icq, 1 - JID, 2- MailTo, 3 - MSN

CREATE TABLE users
(
  uid integer NOT NULL DEFAULT nextval('"Users_Uid_seq"'::regclass),
  nickname text NOT NULL,
  "password" text NOT NULL,
  primarymail text NOT NULL,
  userphoto character varying(500),
  CONSTRAINT "Users_pkey" PRIMARY KEY (uid),
  CONSTRAINT "Users_Nickname_key" UNIQUE (nickname)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE users OWNER TO xgb_jigoku;

CREATE TABLE contacts
(
  id integer NOT NULL DEFAULT nextval('"Contacts_Id_seq"'::regclass),
  userid integer NOT NULL,
  CONSTRAINT "Contacts_pkey" PRIMARY KEY (id),
  CONSTRAINT "Contacts_UserId_fkey" FOREIGN KEY (userid)
      REFERENCES users (uid) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION
)
WITH (
  OIDS=FALSE
);
ALTER TABLE contacts OWNER TO xgb_jigoku;
ALTER TABLE contacts ADD COLUMN "Contact_Type" "ContactType";
ALTER TABLE contacts ADD COLUMN "Value" character varying(100);

CREATE TABLE "PrivateMessage"
(
  "Id" serial NOT NULL,
  "IdFrom" integer, -- От кого
  "IdTo" integer, -- Кому
  "Topic" character varying(255), -- Тема сообщения
  "Body" text,
  "Attachment" bytea,
  "DateSend" timestamp with time zone NOT NULL,
  "DateReceive" timestamp with time zone NOT NULL,
  CONSTRAINT "PrivateMessage_pkey" PRIMARY KEY ("Id"),
  CONSTRAINT "PrivateMessage_IdFrom_fkey" FOREIGN KEY ("IdFrom")
      REFERENCES users (uid) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT "PrivateMessage_IdTo_fkey" FOREIGN KEY ("IdTo")
      REFERENCES users (uid) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION
)
WITH (
  OIDS=FALSE
);
ALTER TABLE "PrivateMessage" OWNER TO xgb_jigoku;
COMMENT ON COLUMN "PrivateMessage"."IdFrom" IS 'От кого';
COMMENT ON COLUMN "PrivateMessage"."IdTo" IS 'Кому';
COMMENT ON COLUMN "PrivateMessage"."Topic" IS 'Тема сообщения';


-- Index: "IdxTopic"

-- DROP INDEX "IdxTopic";

CREATE INDEX "IdxTopic"
  ON "PrivateMessage"
  USING btree
  ("Topic", "IdFrom");

CREATE TABLE "Project"
(
  "Id" serial NOT NULL,
  "Name" text NOT NULL,
  "Description" text NOT NULL,
  "SiteUrl" character varying(100),
  "TrackerUrl" character varying(255),
  CONSTRAINT "Project_pkey" PRIMARY KEY ("Id")
)
WITH (
  OIDS=FALSE
);
ALTER TABLE "Project" OWNER TO xgb_jigoku;

CREATE TABLE "User_Project"
(
  "Id" serial NOT NULL,
  "IdUser" integer,
  "IdProject" integer,
  CONSTRAINT "User_Project_pkey" PRIMARY KEY ("Id"),
  CONSTRAINT "User_Project_IdProject_fkey" FOREIGN KEY ("IdProject")
      REFERENCES "Project" ("Id") MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT "User_Project_IdUser_fkey" FOREIGN KEY ("IdUser")
      REFERENCES users (uid) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION
)
WITH (
  OIDS=FALSE
);
ALTER TABLE "User_Project" OWNER TO xgb_jigoku;

CREATE SEQUENCE "Contacts_Id_seq"
  INCREMENT 1
  MINVALUE 1
  MAXVALUE 9223372036854775807
  START 1
  CACHE 1;
ALTER TABLE "Contacts_Id_seq" OWNER TO xgb_jigoku;

CREATE SEQUENCE "Users_Uid_seq"
  INCREMENT 1
  MINVALUE 1
  MAXVALUE 9223372036854775807
  START 1
  CACHE 1;
ALTER TABLE "Users_Uid_seq" OWNER TO xgb_jigoku;

CREATE SEQUENCE "Project_Id_seq"
  INCREMENT 1
  MINVALUE 1
  MAXVALUE 9223372036854775807
  START 1
  CACHE 1;
ALTER TABLE "Project_Id_seq" OWNER TO xgb_jigoku;

CREATE SEQUENCE "User_Project_Id_seq"
  INCREMENT 1
  MINVALUE 1
  MAXVALUE 9223372036854775807
  START 1
  CACHE 1;
ALTER TABLE "User_Project_Id_seq" OWNER TO xgb_jigoku;
