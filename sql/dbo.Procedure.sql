CREATE PROCEDURE [dbo].pocetnost
	@pocetDivizii int out,
	@pocetProjektov int out
AS
BEGIN
	SELECT COUNT(*) INTO pocetDivizii from Tab_Divizie;
	SELECT COUNT(*) INTO pocetProjektov from Tab_Projekty;
END;

