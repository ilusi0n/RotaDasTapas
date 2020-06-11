#!/bin/bash

key=e2670a96de09067940443bf7724f9ba947603693
folder=$HOME/ctw/PersonalProjects/RotaDasTapas

cd $folder

rm -rf .sonarqube
rm rf report
rm -rf results
rm -rf TestResults
rm -rf test/*/*/coverage*
rm -rf coverage
rm -rf src/*/*/bin
rm -rf test/*/*/bin

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