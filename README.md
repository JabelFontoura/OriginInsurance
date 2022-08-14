# Origin Insurance
Description for **[Origin Backend Take-Home Assignment](https://github.com/OriginFinancial/origin-backend-take-home-assignment)**

## How to run

For all options application should be avalible at: **[http://localhost:5000/](http://localhost:5000/)**

Swagger can be used to test application at: **[http://localhost:5000/swagger/index.html](http://localhost:5000/swagger/index.html)**

---
### Option 1 - Docker
#### Requirements
* **[Docker](https://docs.docker.com/desktop/)**

Execute in root folder

`docker build -t origin/insurance -f OriginInsurance.WebApi\Dockerfile .`

`docker run -it -p 5000:5000 --rm origin/insurance`

---

### Option 2 - .NET CLI
#### Requirements
* **[.NET SDK 6.0](https://dotnet.microsoft.com/download/dotnet/6.0)**
  
Execute in root folder

`dotnet restore`

`dotnet run --project OriginInsurance.WebApi` 

---

### Option 3 - Visual Studio
#### Requirements
* **[Visual Studio 22](https://c2rsetup.officeapps.live.com/c2r/downloadVS.aspx?sku=community&channel=Release&version=VS2022&source=VSLandingPage&includeRecommended=true&cid=2030)**

Locate in root folder and execute `OriginInsurance.sln` file.

Select `OriginInsurance.WebApi` executing profile and run.

---

## Technical Comments

As suggested in the document, I tried to create and extensible and flexible caculation engine. To do that I created a concept of:
1. `InsuranceRules` that are classes representing the business logic. (e.g., user has income, user has a house, ...).
2. `InsuranceTypes` that are classes representing each insurance type (e.g., auto, life, disability, home).
3. Each `InsuranceType` contain a set of `InsuranceRules` that will be used to calculate the insurance score.
4. Each `InsuranceRule` can be reused by any `InsuranceType`.
5. If any `InsuranceType` calculation logic need to be change in the future we just need to add, remove or change it's `InsuranceRules` to represent the new requirements.

Also I believe this solution could be improved to have this `InsuranceRules` and `InsuranceTypes` in a database to create a configurable solution for the user without the need to change the code to change it's rules. For this assignment I decided to stick with the first option to keep it a bit simpler.
