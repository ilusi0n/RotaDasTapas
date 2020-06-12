#! /bin/bash -ex

fn-code-coverage() {
    outputFormat=opencover
    thresholdType=line

    rootDir=$(pwd)

    # remove distribution files from code coverage
    rm -rf test/*/*/coverage*
    rm -rf coverage
    rm -rf src/*/*/bin
    rm -rf test/*/*/bin
    rm -rf report
    rm -rf results/*
    rm -rf .sonarqube

    dotnet clean
    dotnet restore
    dotnet build
    
    #dotnet test /p:CollectCoverage=true /p:CoverletOutput=../CoverageResults/ /p:MergeWith="../CoverageResults/coverage.json" /p:CoverletOutputFormat=\"opencover,json\" -m:1
    ##dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat='json%2copencover' /p:CoverletOutput=../results/coverage /p:#=0 /p:ThresholdType=${thresholdType} /p:MergeWith='../results/coverage.json' /p:CoverletOutputFormat=opencover
    dotnet test RotaDasTapas.Unit.Tests/RotaDasTapas.Unit.Tests.csproj /p:CollectCoverage=true /p:CoverletOutput=../TestResults/
    dotnet test RotaDasTapas.Integration.Tests/RotaDasTapas.Integration.Tests.csproj /p:CollectCoverage=true /p:CoverletOutput=../TestResults/ /p:MergeWith=../TestResults/coverage.json /p:CoverletOutputFormat=opencover

    cd ${rootDir}
 
    exit 0
}

fn-code-coverage "$@"