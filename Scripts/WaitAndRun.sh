#!/usr/bin/env sh

set -e
set -x

# Wait for .NET to be up and running
until [ ]; do
    dotnet "$1" && break
    sleep 1
done

# Wait for the selenium hub to be up and running
until [ ]; do
    sleep 30
    curl -f "http://selenium-hub:4444/wd/hub/status" && break
done

# Run the tests
dotnet test --logger "console;verbosity=detailed"
dotnet tool install --global SpecFlow.Plus.LivingDoc.CLI
export PATH="$PATH:/root/.dotnet/tools"
echo "Starting Specflow living doc Report Generation"
livingdoc test-assembly "/src/EATestBDD/bin/Debug/net7.0/EATestBDD.dll" -t "/src/EATestBDD/bin/Debug/net7.0/TestExecution.json"
