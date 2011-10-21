﻿-- create table users(
-- 	userid serial not null,
-- 	nickname text not null,
-- 	passwd text not null,
-- 	email text not null,
-- 	UserPhoto bytea,
-- 	primary key(userid)
-- );

-- insert into users (userid, nickname, passwd, email)
-- 	values (0, 'John', 'Doe', 'john@doe.usr');

-- select nickname from users;

-- create table contacts (
-- 	id serial not null,
-- 	userid integer not null,
-- 	icq text,
-- 	jid text,
-- 	mailto text,
-- 	msn text,
-- 	primary key(id),
-- 	foreign key(userid) references users(userid) on delete cascade
-- );

-- insert into contacts (id, userid, icq, jid, mailto)
-- 	values (0, 0, '111-111-111', 'john@doe.jab', 'mymail@doe.usr');

select jid from contacts, users
	where contacts.userid = users.userid; 