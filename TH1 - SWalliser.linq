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
	.Where(x => x.StartDate >= new DateTime(2025, 01, 01))
	.Select(x => new 
	{
	   StartDate = x.StartDate,
	   Location = x.CampusVenue.Location,
	   Club = x.Club.ClubName,
	   Activity = x.Name
	})
	.OrderBy(x => x.StartDate)
	.Dump();
	
//Question 2
Programs
	.Where(x => x.ProgramCourses.Count(x => x.Required) >= 22)
	.Select(x => new
	{
		School = x.SchoolCode == "SAMIT"
					? "School of Advance Media and IT"
					: x.SchoolCode == "SEET"
						? "School of Electrical Engineering Technology"
						: "Unknown",
		Program = x.ProgramName,
		RequiredCourseCount = x.ProgramCourses.Count(x => x.Required),
		OptionalCourseCount = x.ProgramCourses.Count(x => !x.Required)
	})
	.OrderBy(x => x.Program)
	.Dump();