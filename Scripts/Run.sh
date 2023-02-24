#!/usr/bin/env sh

set -e
set -x

project="e2etest"

cd "$(dirname "$0")/.."

docker-compose -p "$project" build

docker-compose -p "$project" up -d ea_api ea_webapp db selenium-hub node-docker
docker-compose -p "$project" up --no-deps eatest

exit_code=$(docker inspect eatest -f '{{.State.ExitCode}}')

if[ $exit_code -ne 0 ]; then
    exit $exit_code
else
    echo "Test failed"
fi