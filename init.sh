#!/usr/bin/env bash
set -e -u -o pipefail

cd "$(dirname "$0")"

PKG_ROOT="workers/unity/Packages"
SDK_PATH="${PKG_ROOT}/io.improbable.worker.sdk"
SDK_MOBILE_PATH="${PKG_ROOT}/io.improbable.worker.sdk.mobile"
TEST_SDK_PATH="test-project/Packages/io.improbable.worker.sdk.testschema"
PLATFORM_SDK_PATH="${PKG_ROOT}/io.improbable.worker.sdk.platform"

SDK_VERSION="$(cat "${SDK_PATH}"/package.json | jq -r '.version')"

update_package() {
    local type=$1
    local identifier=$2
    local path=$3

    spatial package get $type $identifier $SDK_VERSION "${path}" --unzip --force --json_output

    local files=${4:-""}
    for file in $(echo $files | tr ";" "\n"); do
        rm "${path}/${file}"
    done
}

build_platform_sdk() {
    PROJECT_DIR="$(pwd)"
    TMP_DIR="$(mktemp -d)"
    PLATFORM_SDK_DIR="${TMP_DIR}/platform-sdk"

    mkdir -p "${PLATFORM_SDK_DIR}"
    pushd "${PLATFORM_SDK_DIR}"
        git init
        git remote add origin git@github.com:spatialos/platform-sdk-csharp.git
        git fetch --depth 50 origin master
        git checkout 69970ca2c71049f94b1dadd76bc3616096ab6a8a

        cd apis
        dotnet build -c Release
        cd bin/Release/net451/
        mv Improbable.SpatialOS.Platform* "${PROJECT_DIR}/${PLATFORM_SDK_PATH}/Plugins/Improbable/"
        mv grpc_csharp_ext.*.dll "${PROJECT_DIR}/${PLATFORM_SDK_PATH}/Plugins/Grpc/Windows/"
        mv libgrpc_csharp_ext.*.so "${PROJECT_DIR}/${PLATFORM_SDK_PATH}/Plugins/Grpc/Linux/"
        mv libgrpc_csharp_ext.*.dylib "${PROJECT_DIR}/${PLATFORM_SDK_PATH}/Plugins/Grpc/OSX/"
    popd

    rm -rf ${TMP_DIR}
}

build_platform_sdk

# Update Core SDK
update_package worker_sdk core-dynamic-x86_64-linux "${SDK_PATH}/Plugins/Improbable/Core/Linux/x86_64"
update_package worker_sdk core-bundle-x86_64-macos "${SDK_PATH}/Plugins/Improbable/Core/OSX"
update_package worker_sdk core-dynamic-x86_64-win32 "${SDK_PATH}/Plugins/Improbable/Core/Windows/x86_64" "CoreSdkDll.lib"

update_package worker_sdk csharp-c-interop "${SDK_PATH}/Plugins/Improbable/Sdk/Common" "Improbable.Worker.CInterop.pdb"

update_package schema standard_library "${SDK_PATH}/.schema"
update_package schema test_schema_library "${TEST_SDK_PATH}/.schema" "test_schema/recursion.schema"

update_package tools schema_compiler-x86_64-win32 "${SDK_PATH}/.schema_compiler"
update_package tools schema_compiler-x86_64-macos "${SDK_PATH}/.schema_compiler"

#Update Mobile SDK
update_package worker_sdk core-static-fullylinked-arm-ios "${SDK_MOBILE_PATH}/Plugins/Improbable/Core/iOS/arm" "CoreSdkStatic.lib;libCoreSdkStatic.a.pic"
update_package worker_sdk core-static-fullylinked-x86_64-ios "${SDK_MOBILE_PATH}/Plugins/Improbable/Core/iOS/x86_64" "CoreSdkStatic.lib;libCoreSdkStatic.a.pic"

update_package worker_sdk core-dynamic-arm64v8a-android "${SDK_MOBILE_PATH}/Plugins/Improbable/Core/Android/arm64"
update_package worker_sdk core-dynamic-armv7a-android "${SDK_MOBILE_PATH}/Plugins/Improbable/Core/Android/armv7"
update_package worker_sdk core-dynamic-x86-android "${SDK_MOBILE_PATH}/Plugins/Improbable/Core/Android/x86"

update_package worker_sdk csharp-c-interop-static "${SDK_MOBILE_PATH}/Plugins/Improbable/Sdk/iOS" "Improbable.Worker.CInteropStatic.pdb"
