CREATE DATABASE redspodb;
USE redspodb;
CREATE TABLE IF NOT EXISTS `Users` (
    `UserId` INT AUTO_INCREMENT NOT NULL ,
    `UserName` VARCHAR(255)  NOT NULL UNIQUE,
    `PasswordHash` VARCHAR(64)  NOT NULL ,
    `FirstName` VARCHAR(255)  NOT NULL ,
    `LastName` VARCHAR(255)  NOT NULL ,
    PRIMARY KEY (
        `UserId`
    )
);

CREATE TABLE IF NOT EXISTS `Events` (
    `EventId` INT AUTO_INCREMENT NOT NULL ,
    `Name` VARCHAR(255)  NOT NULL ,
    `DueTime` DATETIME  NOT NULL ,
    `UserId` INT  NOT NULL ,
    PRIMARY KEY (
        `EventId`
    )
);

CREATE TABLE IF NOT EXISTS `Tasks` (
    `TaskId` INT AUTO_INCREMENT NOT NULL ,
    `Title` VARCHAR(255)  NOT NULL ,
    `Date` DATE  NOT NULL ,
    `IsDone` BOOL  NOT NULL ,
    `UserId` INT  NOT NULL ,
    PRIMARY KEY (
        `TaskId`
    )
);

CREATE TABLE IF NOT EXISTS `Reminders` (
    `ReminderId` INT AUTO_INCREMENT NOT NULL ,
    `Title` VARCHAR(255)  NOT NULL ,
    `DueTime` DATETIME  NOT NULL ,
    `UserId` INT  NOT NULL ,
    PRIMARY KEY (
        `ReminderId`
    )
);

ALTER TABLE `Events` ADD CONSTRAINT `fk_Event_UserId` FOREIGN KEY(`UserId`)
REFERENCES `Users` (`UserId`);

ALTER TABLE `Tasks` ADD CONSTRAINT `fk_Task_UserId` FOREIGN KEY(`UserId`)
REFERENCES `Users` (`UserId`);

ALTER TABLE `Reminders` ADD CONSTRAINT `fk_Reminder_UserId` FOREIGN KEY(`UserId`)
REFERENCES `Users` (`UserId`);

