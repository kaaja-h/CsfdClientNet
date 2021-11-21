dotnet tool install --global dotnet-reportgenerator-globaltool
pushd ..\src\
dotnet clean
dotnet restore
dotnet test -f net5.0 /p:CollectCoverage=true /p:CoverletOutput=../../tests/results/ /p:CoverletOutputFormat=opencover 
popd
reportgenerator -reports:results/coverage.net5.0.opencover.xml -targetdir:coveragereport -reporttypes:Html;HtmlChart -historydir:history