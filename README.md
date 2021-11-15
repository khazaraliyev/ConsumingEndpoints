# Mediapark
## Holidays application


### About project
Application returns list of countries, their holidays and status of given day. It consumes https://kayaposoft.com/enrico/json/ JSON API for first request and 
stores data in database. Once data are added to database for next requests application will request database rather than mentioned JSON API.

### Techonologies
* .NET Core Web API 3.1
* Entity Framweork Core 3.1
* MS SQL Server 2019
* Docker

with Clean/Onion Architecture

### Contents of tables
> Holidays: Stores holidays of country

> Days: Stores status of specific day

> Countries: Keeps supported counrties

### Endpoints
country/countries - returns list of supported countries

holiday/holidays - returns list of holidays for given country in a given year gruoped by a month

holiday/freedays - returns maximum number of holidays in a row for a given country and year

day/daystatus - returns status(type of holiday, workday, freeday) of a day

#### > For detailed information about endpoints and their request bodies see the url /swagger
