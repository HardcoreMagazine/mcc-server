# Microcontroller server app (MSA)
Simple microcontroller (MCC) application, 
that unifies MCC, MySql database and remote 
web clients into one package.  

Uses homemade string-based MCC data 
transfer protocol: `variable_A=double_value;`

[Client web application](https://github.com/HardcoreMagazine/mcc-web-client)  

App was fully tested with [Hercules](https://www.hw-group.com/software/hercules-setup-utility) 
utility and MySql v8

## Build requirements:
- MySql.Data [by Oracle]
- Simple-HTTP [by Darko Jurić]

## Quick instruction:
- Fire up MySql database, create new table with fields: 'temperature', 'vibrations',  'rpm' 
- Add user 'user:user' to table access (permissions: select, insert)
- Run MSA
- Configure IPs, ports
- Set CLIENTS listening port and click APPLY 
-- this will start a server for remote connections
- Launch web application & configure `address:port` 
OR work directly from server application window

## Download:
- [Windows x64 .NET-independant version](https://github.com/HardcoreMagazine/mcc-server/releases/download/v1/mcc-server-net-independant.zip) [150 MB]
- [Windows x64 .NET-dependant version](https://github.com/HardcoreMagazine/mcc-server/releases/download/v1/mcc-server-net-dependant.zip) [12 MB]