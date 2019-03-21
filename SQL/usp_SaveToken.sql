 IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_SaveToken]') AND type in (N'P', N'PC'))
 DROP PROCEDURE [dbo].[usp_SaveToken]
/****** Object:  StoredProcedure [dbo].[[State_SAVE]]    Script Date: 04/26/2017 21:18:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Zubair GUll>
-- Create date: <10-June-2017,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_SaveToken]
	
	@p_Token nvarchar(1000)
AS
BEGIN
BEGIN

Insert into TokenEntities(Token,StartTime) values (@p_Token,GETDATE())

END

END
