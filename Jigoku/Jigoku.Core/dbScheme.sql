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
  icq text,
  jid text,
  mailto text,
  msn text,
  CONSTRAINT "Contacts_pkey" PRIMARY KEY (id),
  CONSTRAINT "Contacts_UserId_fkey" FOREIGN KEY (userid)
      REFERENCES users (uid) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION
)
WITH (
  OIDS=FALSE
);
ALTER TABLE contacts OWNER TO xgb_jigoku;

CREATE TABLE commonpm
(
  id serial NOT NULL,
  userid integer,
  body text,
  attachment bytea,
  topic text NOT NULL DEFAULT 'notopic'::text,
  CONSTRAINT commonpm_pkey PRIMARY KEY (id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE commonpm OWNER TO xgb_jigoku;

CREATE TABLE privatemessage
(
  id serial NOT NULL,
  outputmessageid integer,
  inputmessageid integer,
  CONSTRAINT privatemessage_pkey PRIMARY KEY (id),
  CONSTRAINT outputmessageid FOREIGN KEY (outputmessageid)
      REFERENCES privatemessageoutput (id) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT privatemessage_inputmessageid_fkey FOREIGN KEY (inputmessageid)
      REFERENCES privatemessageinput (id) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION
)
WITH (
  OIDS=FALSE
);
ALTER TABLE privatemessage OWNER TO xgb_jigoku;

CREATE TABLE privatemessageinput
(
-- Унаследована from table commonpm:  id integer NOT NULL DEFAULT nextval('commonpm_id_seq'::regclass),
-- Унаследована from table commonpm:  userid integer,
-- Унаследована from table commonpm:  body text,
-- Унаследована from table commonpm:  attachment bytea,
-- Унаследована from table commonpm:  topic text NOT NULL DEFAULT 'notopic'::text,
  datereceivemessage timestamp without time zone NOT NULL,
  CONSTRAINT privatemessageinput_pkey PRIMARY KEY (id),
  CONSTRAINT privatemessageinput_userid_fkey FOREIGN KEY (userid)
      REFERENCES users (uid) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION
)
INHERITS (commonpm)
WITH (
  OIDS=FALSE
);
ALTER TABLE privatemessageinput OWNER TO xgb_jigoku;

CREATE TABLE privatemessageoutput
(
-- Унаследована from table commonpm:  id integer NOT NULL DEFAULT nextval('commonpm_id_seq'::regclass),
-- Унаследована from table commonpm:  userid integer,
-- Унаследована from table commonpm:  body text,
-- Унаследована from table commonpm:  attachment bytea,
-- Унаследована from table commonpm:  topic text NOT NULL DEFAULT 'notopic'::text,
  datesendingmessage timestamp without time zone NOT NULL,
  CONSTRAINT privatemessageoutput_pkey PRIMARY KEY (id),
  CONSTRAINT privatemessageoutput_userid_fkey FOREIGN KEY (userid)
      REFERENCES users (uid) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION
)
INHERITS (commonpm)
WITH (
  OIDS=FALSE
);
ALTER TABLE privatemessageoutput OWNER TO xgb_jigoku;

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

CREATE SEQUENCE commonpm_id_seq
  INCREMENT 1
  MINVALUE 1
  MAXVALUE 9223372036854775807
  START 1
  CACHE 1;
ALTER TABLE commonpm_id_seq OWNER TO xgb_jigoku;

CREATE SEQUENCE privatemessage_id_seq
  INCREMENT 1
  MINVALUE 1
  MAXVALUE 9223372036854775807
  START 1
  CACHE 1;
ALTER TABLE privatemessage_id_seq OWNER TO xgb_jigoku;
