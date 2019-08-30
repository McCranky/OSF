CREATE PROCEDURE [dbo].pocetnost
	@pDivizie int OUTPUT,
	@pProjekty int OUTPUT,
	@pOddelenia int OUTPUT,
	@pZamestnanci int OUTPUT
AS
	SELECT @pDivizie = COUNT(*) FROM Tab_Divizie;
	SELECT @pProjekty = COUNT(*) FROM Tab_Projekty;
	SELECT @pOddelenia = COUNT(*) FROM Tab_Oddelenie;
	SELECT @pZamestnanci = COUNT(*) FROM Tab_Zamestnanci;
RETURN 0