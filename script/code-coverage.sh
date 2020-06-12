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
        
    dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat='json%2copencover' /p:CoverletOutput=../results/coverage /p:Threshold=0 /p:ThresholdType=${thresholdType} /p:MergeWith='../results/coverage.json' /p:CoverletOutputFormat=opencover

    #cd ./RotaDasTapas.Integration.Tests
    #dotnet reportgenerator "-reports:../results/*.xml" "-targetdir:${rootDir}/report"
    
    cd ${rootDir}
 
    exit 0
}

fn-code-coverage "$@"