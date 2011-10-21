CREATE TABLE Contacts
(
	visibleEmail         text NULL,
	JID                  VARCHAR(20) NULL,
	ICQ                  VARCHAR(20) NULL,
	userId               serial NOT NULL,
	MSN                  VARCHAR(20) NULL
);

ALTER TABLE Contacts
ADD PRIMARY KEY (userId);

CREATE TABLE Users
(
	nick                 text NULL,
	email                text NULL,
	passwd             text not NULL,
	photo                bytea NULL,
	userId               serial NOT NULL
);

ALTER TABLE Users
ADD PRIMARY KEY (userId);

ALTER TABLE Contacts
ADD CONSTRAINT Contacts_Users FOREIGN KEY (userId) REFERENCES Users (userId);

