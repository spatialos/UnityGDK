#!/usr/bin/env bash

set -e -u -o pipefail
if [[ -n "${DEBUG-}" ]]; then
  set -x
fi

cd "$(dirname "$0")/../"

spatial auth login

ci/test.sh
ci/build-client.sh
ci/build-gamelogic.sh
