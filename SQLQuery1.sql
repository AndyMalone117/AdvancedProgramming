USE [Y:\PROJECTS\STUDENTMANAGEMENTSYSTEM\STUDENTMANAGEMENTSYSTEM\MYSTUDENTS.MDF]
GO

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[uspAddStudent]
		@fn = N'',
		@ln = N'',
		@email = N'',
		@phone = N'',
		@address1 = N'',
		@address2 = N'',
		@city = N'',
		@county = N'',
		@level = N'',
		@course = N''

SELECT	@return_value as 'Return Value'

GO
