#!/bin/bash

key=9c3ba13c5aec5155f145038cb44ff89fab345589
folder=$HOME/ctw/PersonalProjects/RotaDasTapas

cd $folder

rm -rf .sonarqube
rm rf report
rm -rf results

#code coverage

outputFormat=lcov
coverageThreshold=100
thresholdType=line

#code coverage

./script/code-coverage.sh

cd $folder

#test
dotnet sonarscanner begin /d:sonar.login=$key /k:"RotaDasTapas" /d:sonar.cs.opencover.reportsPaths="./results/coverage.opencover.xml"
dotnet build
dotnet sonarscanner end /d:sonar.login=admin /d:sonar.password=admin

exit 0