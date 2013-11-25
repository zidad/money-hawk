CREATE TABLE [MoneyHawk].[UserAccounts]
(
	subdomain nvarchar(64) not null, 
	username int not null,
	[password] nvarchar(255) not null
)
