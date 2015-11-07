USE laboru;

ALTER TABLE `laboru`.`expert` 
CHANGE COLUMN `LastName` `LastName` VARCHAR(30) NULL ;

CREATE TABLE `laboru`.`expertskill` (
  `ExpertID` INT NOT NULL,
  `FromExpertID` INT NOT NULL,
  `SkillPageID` INT NOT NULL,
  INDEX `fk_skill_expert_idx` (`ExpertID` ASC),
  INDEX `fk_skill_fromexpert_idx` (`FromExpertID` ASC),
  INDEX `fk_skill_skillpage_idx` (`SkillPageID` ASC),
  CONSTRAINT `fk_skill_expert`
    FOREIGN KEY (`ExpertID`)
    REFERENCES `laboru`.`expert` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_skill_fromexpert`
    FOREIGN KEY (`FromExpertID`)
    REFERENCES `laboru`.`expert` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_skill_skillpage`
    FOREIGN KEY (`SkillPageID`)
    REFERENCES `laboru`.`page` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);