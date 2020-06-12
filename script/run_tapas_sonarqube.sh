#!/bin/bash

key=fe7018b1f11fb624f337f78e7b40ff06ee1c2454
folder=$HOME/ctw/PersonalProjects/RotaDasTapas

cd $folder

#code coverage

./script/code-coverage.sh

cd $folder

#test
dotnet sonarscanner  begin /k:"RotaDasTapas" /d:sonar.host.url="http://localhost:9000" /d:sonar.login=$key /d:sonar.cs.opencover.reportsPaths="./results/coverage.opencover.xml"
dotnet build
dotnet sonarscanner end /d:sonar.login=$key

exit 0