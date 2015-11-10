USE `laboru`;
DROP procedure IF EXISTS `GetRecommendationsBySkillAndExpert`;

DELIMITER $$
USE `laboru`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetRecommendationsBySkillAndExpert`(pSkillID INT, pExpertID INT, pFromExpertID INT)
BEGIN

	SELECT 
		e.ID, e.Name, e.LastName, e.Mobile, e.Bio
	FROM 
		expertskill es
		JOIN (SELECT ExpertID FROM expertcontact WHERE FromExpertID = pFromExpertID) esf ON esf.ExpertID = es.FromExpertID 
		JOIN expert e ON e.ID = es.FromExpertID 
	WHERE
		es.SkillPageID = pSkillID
		AND es.ExpertID = pExpertID
	GROUP BY e.ID, e.Name;
	

END$$

DELIMITER ;


