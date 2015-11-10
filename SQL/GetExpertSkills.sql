USE `laboru`;
DROP procedure IF EXISTS `GetExpertSkills`;

DELIMITER $$
USE `laboru`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetExpertSkills`(pExpertID INT, pFromExpertID INT)
BEGIN
	
	
	SELECT 
		p.ID, concat(pp.Name,'/',p.Name) as 'Name', COUNT(es.ExpertID) as Recommendations, COUNT(esf.ExpertID) as FriendsRecommendations
	FROM 
		page p
		JOIN page pp ON p.ParentPageID = pp.ID
		JOIN expertskill es ON p.ID = es.SkillPageID
		LEFT JOIN (SELECT ExpertID FROM expertcontact WHERE FromExpertID = pFromExpertID) esf ON esf.ExpertID = es.FromExpertID 
	WHERE
		es.ExpertID = pExpertID
	GROUP BY p.ID, p.Name;

END$$

DELIMITER ;

