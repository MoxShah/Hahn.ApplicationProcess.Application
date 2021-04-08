Restore nuget packages, build and run solution.
By default it should run https://localhost:44323/swagger

All APIs are available in Swagger with example.

docker compose files are available on root.

For CORS settings:
As of now I have enabled localhost:8080, so kindly run UI app on same port for integrated testing.

For logging:
I have implemented serilog, using middleware. Rolling sink name can be changed through applicationsettings.json

EF:
Entity framework is in memory.

Validation:
All the validations has been implemented using FluentValidation.

Status Code:
For new record, api will return status code 201.
For Update/Get/Delete, api will return status code 200.
For invalid data, api will return 400 bad request.
