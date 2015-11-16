USE `laboru`;
DROP procedure IF EXISTS `GetRecommendationsByExpert`;

DELIMITER $$
USE `laboru`$$
CREATE PROCEDURE `GetRecommendationsByExpert` (pExpertID INT, pFromExpertID INT)
BEGIN
	SELECT 
		`SkillPageID` as ID
	FROM 
		`laboru`.`expertskill`
	WHERE 
		ExpertID = pExpertID 
		AND FromExpertID = pFromExpertID;

END$$

DELIMITER ;

USE `laboru`;
DROP procedure IF EXISTS `DeleteRecommendation`;

DELIMITER $$
USE `laboru`$$
CREATE PROCEDURE `DeleteRecommendation` (pSkillID INT, pExpertID INT, pFromExpertID INT)
BEGIN
	
	DELETE 
	FROM `laboru`.`expertskill`
	WHERE 
		SkillID = pSkillID
		AND ExpertID = pExpertID
		AND FromExpertID = pFromExpertID;
		
END$$

DELIMITER ;

USE `laboru`;
DROP procedure IF EXISTS `DeleteRecommendation`;

DELIMITER $$
USE `laboru`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `DeleteRecommendation`(pSkillID INT, pExpertID INT, pFromExpertID INT)
BEGIN
	
	DELETE 
	FROM `laboru`.`expertskill`
	WHERE 
		SkillPageID = pSkillID
		AND ExpertID = pExpertID
		AND FromExpertID = pFromExpertID;
		
END$$

DELIMITER ;

