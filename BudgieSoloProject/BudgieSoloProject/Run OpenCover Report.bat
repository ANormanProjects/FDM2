REM Make a 'reports' directory if it doesnt already exist
mkdir .\reports

REM Run the tests through OpenCover
.\packages\OpenCover.4.6.166\tools\OpenCover.Console.exe^
 -register:user^
 -target:"C:\Program Files (x86)\Microsoft Visual Studio 12.0\Common7\IDE\MSTest.exe"^
 -targetargs:"/testcontainer:\"BudgieUsersRepositoryTests\bin\debug\BudgieUsersRepositoryTests.dll\""^
 -mergebyhash^
 -filter: +[*]* -[*]*.Pages.*
 -filter: +[*]* -[*]*.Properties.*
 -filter: +[*]* -[*]*.MainWindow.*
 -output:.\reports\output.xml

REM Generate the report
.\packages\ReportGenerator.2.4.3.0\tools\ReportGenerator.exe^
 -reports:.\reports\output.xml^
 -targetdir:.\reports

REM Open the report
start .\reports\index.htm