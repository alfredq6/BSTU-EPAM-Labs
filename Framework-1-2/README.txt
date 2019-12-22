Use special console:
cd "packages\NUnit.ConsoleRunner.3.10.0\tools"

Run nunit console, specify optional params and set path to DLL:
nunit3-console.exe --testparam:browser=Edge;environment=dev "UnitTestProject.dll"