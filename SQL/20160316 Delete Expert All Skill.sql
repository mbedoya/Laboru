USE `laboru`;
DROP procedure IF EXISTS `DeleteExpertAllSkill`;

DELIMITER $$
USE `laboru`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `DeleteExpertAllSkill`(pId int )
BEGIN

	DELETE
	FROM 
        expertallskill
	WHERE
		FromExpertID = pId;
END$$

DELIMITER ;

USE `laboru`;
DROP procedure IF EXISTS `GetRecommendationsForExpert`;

DELIMITER $$
USE `laboru`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetRecommendationsForExpert`(pExpertID INT)
BEGIN
	SELECT 
		p.Name, e.Name as 'Expert', es.DateCreated as 'Date'
	FROM 
		`laboru`.`expertskill` es 
		JOIN page p ON es.SkillPageID = p.ID
		JOIN expert e ON es.FromExpertID = e.ID
	WHERE 
		es.ExpertID = pExpertID
	ORDER BY
		es.DateCreated DESC;

END$$

DELIMITER ;

USE `laboru`;
DROP procedure IF EXISTS `Core_GetExpertById`;

DELIMITER $$
USE `laboru`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Core_GetExpertById`(pId int )
BEGIN
	SELECT
		  ID,
	 	  Name,
	 	  LastName,
	 	  Mobile,
	 	  Bio,
		  DateCreated
	  	FROM 
        expert
	WHERE
		ID = pId;
END$$

DELIMITER ;

USE `laboru`;
DROP procedure IF EXISTS `Core_GetExpertByMobile`;

DELIMITER $$
USE `laboru`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Core_GetExpertByMobile`(pMobile varchar(30) )
BEGIN
	SELECT
		  ID,
	 	  Name,
	 	  LastName,
	 	  Mobile,
	 	  Bio,
          DateCreated
	  	FROM 
        expert
	WHERE
		Mobile = pMobile;
END$$

DELIMITER ;


