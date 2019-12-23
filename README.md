# Belong - Coding Project

<p align="left">
  <a href="https://github.com/olegburov/Belong"><img alt="GitHub Actions status" src="https://github.com/olegburov/Belong/workflows/ASP.NET%20Core%20CI/badge.svg"></a>
</p>

[![Build Status](https://dev.azure.com/olegburov/Belong/_apis/build/status/olegburov.Belong?branchName=master)](https://dev.azure.com/olegburov/Belong/_build/latest?definitionId=11&branchName=master)

Your mission, should you choose to accept it, is to build a sample homeowner lead generation web form and database.

The instructions below encapsulate all the expectations regarding the project. Everything that isn’t explicitly specified is up to you to decide; use your best judgement.

Of course, should you have any questions you may contact your sponsor.

Good luck!

## The flow of the form is as follows:

1. The user enters its name (first and last), email address and phone number.
2. Email and phone are checked for validity. If valid, log in our database, together with the user’s IP.
3. Next, the user enters its home address. Log that in our DB.
4. Using the Zillow API (https://www.zillow.com/howto/api/APIOverview.htm), display the Rent Zestimate valuation range for the home, to give the homeowner an idea of expected monthly rent.
If no Rent Zestimate is available, calculate the annual rent as 5% of the home price Zestimate. Display the monthly range as ±10%.
Log those values in our DB.
5. The user can enter its expected monthly rent, which may differ from the suggested values. Log that in our DB.
6. Finally, we send an email to the user congratulating it for signing up, together with the details that we collected.

## Notes and answers to frequently asked questions:

1. You may code in any language or platform.
2. Our stack is .NET, React and SQL Server.
3. But again, you may code in any language.
4. Feel free to use any resource. The only limitation is that we ask the work be yours, not outsourced.
5. Spend as much or as little time as you see fit.
6. Focus as much or as little as you want on the back end.
7. Focus as much or as little as you want on the front end.
8. Focus as much or as little as you want on the database.
9. Document as much or as little as you think is needed.
10. Bonus points if you deploy the project to a live environment (please don’t use Belong’s name – we’re in Stealth Mode).
11. When you’re done, submit all code and database files (and if deployed live, the URL).
