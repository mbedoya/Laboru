CREATE TABLE `laboru`.`expert` (
  `ID` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(30) NOT NULL COMMENT 'first name',
  `LastName` VARCHAR(30) NOT NULL,
  `Mobile` VARCHAR(12) NOT NULL,
  `Bio` VARCHAR(500) NULL,
  PRIMARY KEY (`ID`));

 ALTER TABLE `laboru`.`expert` 
ADD UNIQUE INDEX `Mobile_UNIQUE` (`Mobile` ASC);
  
 USE laboru;

DROP procedure IF EXISTS `Core_GetAllExpert`;
-- --------------------------------------------------------------------------------
-- Routine DDL
-- Note: comments before and after the routine body will not be stored by the server
-- --------------------------------------------------------------------------------
DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Core_GetAllExpert`()
BEGIN
	SELECT
		  ID,
	 	  Name,
	 	  LastName,
	 	  Mobile,
	 	  Bio
	  	FROM 
        expert;
END$$

DELIMITER ;


 

DROP procedure IF EXISTS `Core_GetExpertById`;
-- --------------------------------------------------------------------------------
-- Routine DDL
-- Note: comments before and after the routine body will not be stored by the server
-- --------------------------------------------------------------------------------
DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Core_GetExpertById`(pId int )
BEGIN
	SELECT
		  ID,
	 	  Name,
	 	  LastName,
	 	  Mobile,
	 	  Bio
	  	FROM 
        expert
	WHERE
		ID = pId;
END$$

DELIMITER ;



 

DROP procedure IF EXISTS `Core_GetExpertByName`;
-- --------------------------------------------------------------------------------
-- Routine DDL
-- Note: comments before and after the routine body will not be stored by the server
-- --------------------------------------------------------------------------------
DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Core_GetExpertByName`(pName varchar(30) )
BEGIN
	SELECT
		  ID,
	 	  Name,
	 	  LastName,
	 	  Mobile,
	 	  Bio
	  	FROM 
        expert
	WHERE
		Name = pName;
END$$

DELIMITER ;



DROP procedure IF EXISTS `Core_UpdateExpert`;
-- --------------------------------------------------------------------------------
-- Routine DDL
-- Note: comments before and after the routine body will not be stored by the server
-- --------------------------------------------------------------------------------
DELIMITER $$

CREATE DEFINER=`root`@`localhost` PROCEDURE `Core_UpdateExpert`(
		  pID int,
	 	  pName varchar(30),
	 	  pLastName varchar(30),
	 	  pMobile varchar(12),
	 	  pBio varchar(500)
	     )
BEGIN

	UPDATE
	    expert
	SET 		
			  ID = pID,
	 	  Name = pName,
	 	  LastName = pLastName,
	 	  Mobile = pMobile,
	 	  Bio = pBio
	  	WHERE ID = pID;

END$$

DELIMITER ;

DROP procedure IF EXISTS `Core_CreateExpert`;
-- --------------------------------------------------------------------------------
-- Routine DDL
-- Note: comments before and after the routine body will not be stored by the server
-- --------------------------------------------------------------------------------
DELIMITER $$

CREATE DEFINER=`root`@`localhost` PROCEDURE `Core_CreateExpert`(
		  pID int,
	 	  pName varchar(30),
	 	  pLastName varchar(30),
	 	  pMobile varchar(12),
	 	  pBio varchar(500)
	     )
BEGIN

	INSERT INTO
	    expert
	(		  Name,
		 		  LastName,
		 		  Mobile,
		 		  Bio
		  )
	VALUES
	(		  pName,
		 		  pLastName,
		 		  pMobile,
		 		  pBio
		  );	
	
   SELECT LAST_INSERT_ID() AS ID;

END$$

DELIMITER ;

 

DROP procedure IF EXISTS `Core_DeleteExpert`;
-- --------------------------------------------------------------------------------
-- Routine DDL
-- Note: comments before and after the routine body will not be stored by the server
-- --------------------------------------------------------------------------------
DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Core_DeleteExpert`(pId int )
BEGIN

	DELETE
	FROM 
        expert
	WHERE
		ID = pId;
END$$

DELIMITER ;

DROP procedure IF EXISTS `Core_GetExpertByMobile`;
-- --------------------------------------------------------------------------------
-- Routine DDL
-- Note: comments before and after the routine body will not be stored by the server
-- --------------------------------------------------------------------------------
DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Core_GetExpertByMobile`(pMobile varchar(30) )
BEGIN
	SELECT
		  ID,
	 	  Name,
	 	  LastName,
	 	  Mobile,
	 	  Bio
	  	FROM 
        expert
	WHERE
		Mobile = pMobile;
END$$

DELIMITER ;

