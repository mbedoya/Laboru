USE `laboru`;
DROP procedure IF EXISTS `RecommendExpert`;

DELIMITER $$
USE `laboru`$$
CREATE PROCEDURE `RecommendExpert` (pFromExpertID INT, pExpertID INT, pSkillID INT)
BEGIN
	
	INSERT INTO `laboru`.`expertskill`
	(`ExpertID`,
	`FromExpertID`,
	`SkillPageID`)
	VALUES
	(pExpertID,
	pFromExpertID,
	pSkillID);

END$$

DELIMITER ;
