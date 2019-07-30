#!/usr/bin/env bash

### This script should only be run on Improbable's internal build machines.
### If you don't work at Improbable, this may be interesting as a guide to what software versions we use for our
### automation, but not much more than that.

set -e -u -x -o pipefail

if [[ -z "$BUILDKITE" ]]; then
  echo "This script is only to be run on Improbable CI."
  exit 1
fi

cd "$(dirname "$0")/../"

source ci/tools.sh

# Tag a version of the docs.
#
# Environment variables as arguments:
#   DOCS_TYPE: "unity"
#   DOCS_VERSION: "alpha"
#   DOCS_TARGET: "testing", "staging" or "production"

DOCS_HASH="$(buildkite-agent meta-data get "docs-hash")"

if [ "${DOCS_TARGET}" != "production" ]; then
    DOCS_VERSION="preview-${DOCS_HASH}"
fi

if [[ "${BUILDKITE_BRANCH}" != "docs-current" && "${DOCS_TARGET}" == "production" ]]; then
    echo "Docs may only be published to production from docs-current."
    buildkite-agent annotate "Docs may only be published to production from docs-current." --style 'error' --context 'ctx-error'
    exit 1
fi

setup_improbadoc

echo "--- Tagging docs for ${DOCS_TARGET} :pushpin:"

improbadoc list \
    "${DOCS_TYPE}" \
    --target="${DOCS_TARGET}" \
    --oauth2_client_cli_token_directory="${SPATIAL_OAUTH_DIR}"

improbadoc tag \
    "${DOCS_TYPE}" \
    "${DOCS_VERSION}" \
    "${DOCS_HASH}" \
    --target="${DOCS_TARGET}" \
    --oauth2_client_cli_token_directory="${SPATIAL_OAUTH_DIR}" \
    --json | jq '.' | tee "improbadoc.tag.output.json"

improbadoc list \
    "${DOCS_TYPE}" \
    --target="${DOCS_TARGET}" \
    --oauth2_client_cli_token_directory="${SPATIAL_OAUTH_DIR}"

if [ "${DOCS_TARGET}" = "production" ]; then
    buildkite-agent annotate "Production link: https://docs.improbable.io/${DOCS_TYPE}/${DOCS_VERSION}" --style 'success' --context 'ctx-production'
else
    buildkite-agent annotate --append "Preview link for ${DOCS_TARGET}: https://docs-${DOCS_TARGET}.improbable.io/${DOCS_TYPE}/${DOCS_VERSION}<br/>" --style 'info' --context 'ctx-preview'
fi
