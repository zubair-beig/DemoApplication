 IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_ValidateUser]') AND type in (N'P', N'PC'))
 DROP PROCEDURE [dbo].[usp_ValidateUser]
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
CREATE PROCEDURE [dbo].[usp_ValidateUser]
	
	@p_UserName nvarchar(50),
	@p_Password nvarchar(50)
AS
BEGIN
BEGIN

Select Convert(bit,count(*)) from ut_User where UserName= @p_UserName and Password =@p_Password

END

END
