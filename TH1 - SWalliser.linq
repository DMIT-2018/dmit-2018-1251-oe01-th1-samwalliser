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

//Question 3
Students
	.Where(x => x.StudentPayments.Count() == 0 && x.Countries.CountryName != "CANADA")
	.OrderBy(x => x.LastName)
	.Select(x => new 
	{
	    StudentNumber = x.StudentNumber,
		CounrtryName = x.Countries.CountryName,
		FullName = x.FirstName + " " + x.LastName,
		ClubMembershipCount = x.ClubMembers.Count() == 0
		                      ? "None"
							  : x.ClubMembers.Count().ToString()
	})
	.Dump();
	
// Question 4
Employees
	.Where(x => x.Position.Description == "Instructor" 
			&& x.ReleaseDate == null
			&& x.ClassOfferings.Count() > 0)
	.OrderByDescending(x => x.ClassOfferings.Count() > 24 ? 3
						: x.ClassOfferings.Count() > 8 ? 2 : 1)
	.ThenBy(x => x.LastName)
	.Select(x => new
	{
		ProgramName = x.Program.ProgramName,
		FullName = x.FirstName + " " + x.LastName,
		WorkLoad = x.ClassOfferings.Count() > 24 ? "High"
					: x.ClassOfferings.Count() > 8 ? "Med"
					: "Low"
	})
	.Dump();
	
//Question 5












