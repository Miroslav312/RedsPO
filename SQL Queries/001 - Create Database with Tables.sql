CREATE DATABASE IF NOT EXISTS redspo;
USE redspo;
CREATE TABLE IF NOT EXISTS `User` (
    `UserId` INT AUTO_INCREMENT NOT NULL ,
    `UserName` VARCHAR(255)  NOT NULL ,
    `PasswordHash` VARCHAR(64)  NOT NULL ,
    `FirstName` VARCHAR(255)  NOT NULL ,
    `LastName` VARCHAR(255)  NOT NULL ,
    PRIMARY KEY (
        `UserId`
    ),
    CONSTRAINT `uc_User_UserName` UNIQUE (
        `UserName`
    )
);

CREATE TABLE IF NOT EXISTS `Event` (
    `EventId` INT AUTO_INCREMENT NOT NULL ,
    `Title` VARCHAR(255)  NOT NULL ,
    `DueTime` DATETIME  NOT NULL ,
    `IsDone` BOOL  NOT NULL ,
    `Importance` VARCHAR(10)  NOT NULL ,
    `UserId` INT  NOT NULL ,
    PRIMARY KEY (
        `EventId`
    )
);

ALTER TABLE `Event` ADD CONSTRAINT `fk_Event_UserId` FOREIGN KEY(`UserId`)
REFERENCES `User` (`UserId`);

