@echo off
cls

set scripts="C:\Projects\L&D\docker\src\UsersManagement"

REM DEV
set host=localhost:27017

set mongodb=mongodb://

set connectionString= %mongodb%%host%

set parallel=0

IF NOT "%~1" == "" set connectionString= %mongodb%%~1

IF NOT "%~2" == "" set scripts="%~2"

IF "%~3" == "1" set parallel=1

echo Root director: %scripts%
echo connection string: %connectionString%
IF %parallel% == 1 echo parallel mode turn on
IF %parallel% == 0 echo parallel mode turn off


IF %parallel% == 1 for /R %scripts% %%B in (*_initdb.js) do  mongosh %connectionString%  %%B 
IF %parallel% == 0 for /R %scripts% %%B in (*_initdb.js) do   mongosh  %connectionString%  %%B
