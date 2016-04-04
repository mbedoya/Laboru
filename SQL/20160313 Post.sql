USE laboru;

CREATE TABLE `laboru`.`post` (
  `ID` INT NOT NULL AUTO_INCREMENT,
  `Title` VARCHAR(80) NOT NULL,
  `Description` VARCHAR(500) NOT NULL,
  `SkillPageID` INT NOT NULL,
  `FromExpertID` INT NOT NULL,
  `DateCreated` DATETIME NOT NULL DEFAULT NOW(),
  PRIMARY KEY (`ID`),
  INDEX `fk_post_skill_idx` (`SkillPageID` ASC),
  INDEX `fk_post_expert_idx` (`FromExpertID` ASC),
  CONSTRAINT `fk_post_skill`
    FOREIGN KEY (`SkillPageID`)
    REFERENCES `laboru`.`page` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_post_expert`
    FOREIGN KEY (`FromExpertID`)
    REFERENCES `laboru`.`expert` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
	
USE laboru;

DROP procedure IF EXISTS `Core_GetAllPost`;
-- --------------------------------------------------------------------------------
-- Routine DDL
-- Note: comments before and after the routine body will not be stored by the server
-- --------------------------------------------------------------------------------
DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Core_GetAllPost`()
BEGIN
	SELECT
		  ID,
	 	  Title,
	 	  Description,
	 	  SkillPageID,
	 	  FromExpertID,
	 	  DateCreated
	  	FROM 
        post;
END$$

DELIMITER ;


 

DROP procedure IF EXISTS `Core_GetPostById`;
-- --------------------------------------------------------------------------------
-- Routine DDL
-- Note: comments before and after the routine body will not be stored by the server
-- --------------------------------------------------------------------------------
DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Core_GetPostById`(pId int )
BEGIN
	SELECT
		  ID,
	 	  Title,
	 	  Description,
	 	  SkillPageID,
	 	  FromExpertID,
	 	  DateCreated
	  	FROM 
        post
	WHERE
		ID = pId;
END$$

DELIMITER ;




		 
DROP procedure IF EXISTS `Core_GetPostByPage`;
-- --------------------------------------------------------------------------------
-- Routine DDL
-- Note: comments before and after the routine body will not be stored by the server
-- --------------------------------------------------------------------------------
DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Core_GetPostByPage`(pId int)
BEGIN
	SELECT
		  ID,
	 	  Title,
	 	  Description,
	 	  SkillPageID,
	 	  FromExpertID,
	 	  DateCreated
	  	FROM 
        post
	WHERE
		SkillPageID = pId;
END$$

DELIMITER ;


		 
DROP procedure IF EXISTS `Core_GetPostByExpert`;
-- --------------------------------------------------------------------------------
-- Routine DDL
-- Note: comments before and after the routine body will not be stored by the server
-- --------------------------------------------------------------------------------
DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Core_GetPostByExpert`(pId int)
BEGIN
	SELECT
		  ID,
	 	  Title,
	 	  Description,
	 	  SkillPageID,
	 	  FromExpertID,
	 	  DateCreated
	  	FROM 
        post
	WHERE
		FromExpertID = pId;
END$$

DELIMITER ;



DROP procedure IF EXISTS `Core_UpdatePost`;
-- --------------------------------------------------------------------------------
-- Routine DDL
-- Note: comments before and after the routine body will not be stored by the server
-- --------------------------------------------------------------------------------
DELIMITER $$

CREATE DEFINER=`root`@`localhost` PROCEDURE `Core_UpdatePost`(
		  pID int,
	 	  pTitle varchar(80),
	 	  pDescription varchar(500),
	 	  pSkillPageID int,
	 	  pFromExpertID int,
	 	  pDateCreated datetime
	     )
BEGIN

	UPDATE
	    post
	SET 		
			  ID = pID,
	 	  Title = pTitle,
	 	  Description = pDescription,
	 	  SkillPageID = pSkillPageID,
	 	  FromExpertID = pFromExpertID,
	 	  DateCreated = pDateCreated
	  	WHERE ID = pID;

END$$

DELIMITER ;

DROP procedure IF EXISTS `Core_CreatePost`;
-- --------------------------------------------------------------------------------
-- Routine DDL
-- Note: comments before and after the routine body will not be stored by the server
-- --------------------------------------------------------------------------------
DELIMITER $$

CREATE DEFINER=`root`@`localhost` PROCEDURE `Core_CreatePost`(
		  pID int,
	 	  pTitle varchar(80),
	 	  pDescription varchar(500),
	 	  pSkillPageID int,
	 	  pFromExpertID int,
	 	  pDateCreated datetime
	     )
BEGIN

	INSERT INTO
	    post
	(		  Title,
		 		  Description,
		 		  SkillPageID,
		 		  FromExpertID,
		 		  DateCreated
		  )
	VALUES
	(		  pTitle,
		 		  pDescription,
		 		  pSkillPageID,
		 		  pFromExpertID,
		 		  pDateCreated
		  );	
	
   SELECT LAST_INSERT_ID() AS ID;

END$$

DELIMITER ;

 

DROP procedure IF EXISTS `Core_DeletePost`;
-- --------------------------------------------------------------------------------
-- Routine DDL
-- Note: comments before and after the routine body will not be stored by the server
-- --------------------------------------------------------------------------------
DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Core_DeletePost`(pId int )
BEGIN

	DELETE
	FROM 
        post
	WHERE
		ID = pId;
END$$

DELIMITER ;


