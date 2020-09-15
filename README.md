# TOTAL SCORES VARONIS
### Features

- Written in .net-core 3.1 LTS;
- Uses the built in .net-core dependency injection;
- Modular system: DAL, BL, Services, Client, Model;
- Using Entity Framework (object-relational mapping framework);
- Using Mediatr for the Mediatr pattern (https://github.com/jbogard/MediatR);
- Settings are being loaded from 'appsettings.json';

### Disclaimers
-------------
- The settings shall be encrypted (with DPAPI) or get served by a service or DB;
- More modularity is better but its an exercise there are litteraly endless ways to improve;
- In case of a huge DB requestion data with paging is better.
- Same as for the rest service;

### Configuring the rest service
                
+ Go to https://beeceptor.com/
+ Choose the 'varonis-test' endpoint name
    + Click on 'Mocking rules'
    + Click on 'Create a new rule'
    + Paste this valid json text:
    + `
    {
    "SourceLocations":[
{
        "Id":"2041F072-6F90-4813-81DA-03A2468010D5",
        "LocationOnDisk":"C:\\Temp\\VaronisTest\\Source1"
    },
 {
        "Id":"7E2E0C97-6F2F-48B2-91EE-36312247FD76", 
        "LocationOnDisk":"C:\\Temp\\VaronisTest\\Source6"
    }
]
}`
    + Be sure to have the files in the correct location
