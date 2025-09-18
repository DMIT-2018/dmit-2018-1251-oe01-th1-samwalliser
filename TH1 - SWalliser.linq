<Query Kind="Statements">
  <Connection>
    <ID>025dc319-cd9e-450d-83c5-f9fa396590ee</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>SAM\SQLEXPRESS01</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <DeferDatabasePopulation>true</DeferDatabasePopulation>
    <Database>StartTed-2025-Sept</Database>
    <DriverData>
      <LegacyMFA>false</LegacyMFA>
    </DriverData>
  </Connection>
</Query>

//Question 1
ClubActivities
	.Where(x => x.StartDate >= new DateTime(2025, 1, 1))
	.Select(x => new 
	{
	   StartDate = x.StartDate,
	   Location = x.Location,
	   Club = x.Club.ClubName,
	   Activity = x.Description
	})
	.OrderBy(x => x.StartDate)
	.Dump();