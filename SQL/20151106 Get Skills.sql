USE `laboru`;
DROP procedure IF EXISTS `GetSkills`;

DELIMITER $$
USE `laboru`$$
CREATE PROCEDURE `GetSkills` ()
BEGIN

	SELECT 
		ch.ID, concat(p.Name,'/',ch.Name) as 'Name'
	FROM 
		laboru.page ch
		JOIN laboru.page p ON ch.ParentPageID = p.ID
	WHERE 
        p.ParentPageID = 1
		AND ch.PageTypeID = p.PageTypeID
		AND p.PageTypeID = (SELECT ID FROM laboru.pagetype WHERE Name = 'Category')
	ORDER BY
		p.Name, ch.Name;

END$$

DELIMITER ;