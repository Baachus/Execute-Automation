#!/usr/bin/env sh

set -e
set -x

project="e2etest"

cd "$(dirname "$0")/.."

docker-compose -p "$project" build


mkdir -m 777 -p Reports

docker-compose -p "$project" up -d ea_api ea_webapp db selenium-hub firefox chrome edge
docker-compose -p "$project" up --no-deps ea_test

docker cp ea_test:/src/EATestBDD/LivingDoc.html ./Reports
echo "Specflow living document report is copied to ./Reports"
ls -l ./Reports

exit_code=$(docker inspect ea_test -f '{{.State.ExitCode}}')

if [ $exit_code -eq 0 ]; then
    exit $exit_code
else
    echo "Test failed"
fi