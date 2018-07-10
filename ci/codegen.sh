#!/usr/bin/env bash
set -e -u -x -o pipefail

cd "$(dirname "$0")/../"

source ci/includes/pinned-tools.sh
source ci/includes/profiling.sh

dotnet run -p code_generator/GdkCodeGenerator/GdkCodeGenerator.csproj -- \
  --schema-path="schema" \
  --schema-path="schema_standard_library" \
  --json-dir="workers/unity/Temp/ImprobableJson" \
  --native-output-dir="workers/unity/Assets/Generated/Source" \
  --network-types-output-dir="workers/unity/Assets/Improbable.Generated.NetworkTypes/Generated"
