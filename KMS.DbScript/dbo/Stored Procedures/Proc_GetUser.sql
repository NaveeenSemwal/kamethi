-- =============================================
-- Author:		<Kiran>
-- Create date: <28/04/2020>
-- Description:	<To get User List>
--Execute proc Proc_GetUser @PageIndex=1 ,@PageSize=2
-- =============================================
CREATE PROCEDURE  Proc_GetUser
	-- Add the parameters for the stored procedure here
@PageIndex bigint=1,

@PageSize bigint=2
AS
BEGIN
DECLARE @TempTable TABLE (Rownumber int,UserId	int,
UserName	nvarchar(100),
Email	nvarchar(100),
Password	nvarchar(100),
Role	nchar(20),
CreatedDate	datetime,
ModifiedDate	datetime,
IsActive	bit,
DateOfBirth	date,
PrimaryPhone	nvarchar(100),
SecondaryPhone	nvarchar(100),
CurrentState	int,
CurrentCity	int,
CurrentAddress	nvarchar(100),
IsAddressSame	bit,
PermanentState	int,
PermanentCity	int,
PermanentAddress	nvarchar(100),
AadhaarNumber	bigint,
PanCardNumber	nvarchar(100),
UploadAadhaar	nvarchar(max),
UploadPanCard	nvarchar(max))        
        
INSERT INTO @TempTable (        
Rownumber ,UserId	,
UserName	,
Email,
Password,
Role	,
CreatedDate,
ModifiedDate,
IsActive,
DateOfBirth	,
PrimaryPhone	,
SecondaryPhone	,
CurrentState	,
CurrentCity	,
CurrentAddress	,
IsAddressSame,
PermanentState,
PermanentCity,
PermanentAddress,
AadhaarNumber,
PanCardNumber,
UploadAadhaar,
UploadPanCard       
)        
	SELECT  ROW_NUMBER() over(order by UserId) AS RowNumber ,UserId	,
UserName	,
Email,
Password,
Role	,
CreatedDate,
ModifiedDate,
IsActive,
DateOfBirth	,
PrimaryPhone	,
SecondaryPhone	,
CurrentState	,
CurrentCity	,
CurrentAddress	,
IsAddressSame,
PermanentState,
PermanentCity,
PermanentAddress,
AadhaarNumber,
PanCardNumber,
UploadAadhaar,
UploadPanCard      
	 From [User]  



SELECT UserId	,
UserName	,
Email,
Password,
Role	,
CreatedDate,
ModifiedDate,
IsActive,
DateOfBirth	,
PrimaryPhone	,
SecondaryPhone	,
CurrentState	,
CurrentCity	,
CurrentAddress	,
IsAddressSame,
PermanentState,
PermanentCity,
PermanentAddress,
AadhaarNumber,
PanCardNumber,
UploadAadhaar,
UploadPanCard      
	 From @TempTable  where RowNumber BETWEEN ((@PageIndex-1)*(@PageSize)+1)                                           
AND ((((@PageIndex - 1) * @PageSize) + 1) + @PageSize) - 1      
END