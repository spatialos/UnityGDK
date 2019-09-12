#!/usr/bin/env bash

set -e -u -o pipefail

if [[ -n "${DEBUG-}" ]]; then
  set -x
fi

cd "$(dirname "$0")/../"

PKG_ROOT="workers/unity/Packages"

if [[ -n "${DRY_RUN-}" ]]; then
    EXTRA_CLOUDSMITH_ARGS="--dry-run"
else
    EXTRA_CLOUDSMITH_ARGS=""
fi

./init.sh

# Re-publish all packages
pushd "${PKG_ROOT}" > /dev/null
    for package_dir in */;
    do
        echo "${package_dir}"
        pushd "${package_dir}" > /dev/null
            # Created package is the last line of output.
            PACKAGE_NAME=$(npm pack | tail -n 1)
            cloudsmith push npm spatialos/gdk-for-unity "${PACKAGE_NAME}" --republish "${EXTRA_CLOUDSMITH_ARGS}"
        popd > /dev/null
    done
popd > /dev/null

