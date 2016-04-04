
USE `laboru`;
DROP procedure IF EXISTS `laboru`.`GetPostForExpert`;

DELIMITER $$
USE `laboru`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetPostForExpert`(pId int)
BEGIN
	SELECT
		  p.ID,
	 	  p.Title,
	 	  p.Description,
	 	  p.SkillPageID,
	 	  p.FromExpertID,
	 	  p.DateCreated
	FROM 
        post p
		JOIN expertallskill es ON p.SkillPageID = es.SkillPageID 
	WHERE
		es.FromExpertID = pId;
END$$

DELIMITER ;
;

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
		FromExpertID = pId
	ORDER BY
		DateCreated DESC;
END$$

DELIMITER ;
