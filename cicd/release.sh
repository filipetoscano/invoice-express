#!/bin/bash
# ------------------------------------------------------------------------
set -eux

yell() { echo "$0: $*" >&2; }
die() { yell "$*"; exit 111; }
try() { "$@" || die "cannot $*"; }


#
# Run all commands from the repository root!
# (That's the directory above the current one :)
# ------------------------------------------------------------------------
#
SCRIPT_PATH="${BASH_SOURCE[0]}"
if ([ -h "${SCRIPT_PATH}" ]); then
  while([ -h "${SCRIPT_PATH}" ]); do cd "$(dirname "$SCRIPT_PATH")";
  SCRIPT_PATH=$(readlink "${SCRIPT_PATH}"); done
fi
cd "$(dirname ${SCRIPT_PATH})" > /dev/null
cd ..


#
# Ensure env
# ------------------------------------------------------------------------
if [ -z ${GITHUB_REF+x} ];      then die "GITHUB_REF is not set"; fi
if [ -z ${GITHUB_TOKEN+x} ];    then die "GITHUB_TOKEN is not set"; fi
if [ -z ${INVXP_APIKEY+x} ];    then die "INVXP_APIKEY is not set"; fi
if [ -z ${INVXP_ACCOUNT+x} ];   then die "INVXP_ACCOUNT is not set"; fi
if [ -z ${NUGET_APIKEY+x} ];    then die "NUGET_APIKEY is not set"; fi

if [[ ${GITHUB_REF} != refs/tags/v* ]]; then die "Script only works for tags"; fi

export VERSION=${GITHUB_REF##*/v}
echo ${VERSION}


#
# Config
# ------------------------------------------------------------------------
# dotnet nuget add source --username filipetoscano --password ${GITHUB_TOKEN} --store-password-in-clear-text --name github "https://nuget.pkg.github.com/filipetoscano/index.json"


#
# Build
# ------------------------------------------------------------------------

dotnet clean   -c Release
dotnet restore --packages .nuget
dotnet build   -c Release --no-restore -p:Version=${VERSION}
dotnet test    -c Release --no-restore --no-build --verbosity=normal


#
# Publish to nuget.org
# ------------------------------------------------------------------------

mkdir -p nupkg
rm -f nupkg/*.*

dotnet pack    -c Release --no-restore --no-build src/InvoiceXpress -o nupkg -p:Version=${VERSION}
dotnet nuget push "nupkg/*.nupkg" --api-key ${NUGET_APIKEY} --source=https://api.nuget.org/v3/index.json


#
# Build cli tool for multiple platforms
# RID catalog: https://docs.microsoft.com/en-us/dotnet/core/rid-catalog
# ------------------------------------------------------------------------

dotnet publish -c Release --no-restore --no-build --runtime=win-x64   --self-contained tools/InvoiceXpress.Cli/InvoiceXpress.Cli.csproj -p:Version=${VERSION} -o tmp/win-x64
dotnet publish -c Release --no-restore --no-build --runtime=linux-x64 --self-contained tools/InvoiceXpress.Cli/InvoiceXpress.Cli.csproj -p:Version=${VERSION} -o tmp/linux-x64
dotnet publish -c Release --no-restore --no-build --runtime=osx-x64   --self-contained tools/InvoiceXpress.Cli/InvoiceXpress.Cli.csproj -p:Version=${VERSION} -o tmp/osx-x64

mkdir -p artifacts
rm -f artifacts/*.zip

zip -j -r artifacts/invexp-win-x64-${VERSION}.zip   tmp/win-x64/invxp.exe
zip -j -r artifacts/invexp-linux-x64-${VERSION}.zip tmp/linux-x64/invxp
zip -j -r artifacts/invexp-osx-x64-${VERSION}.zip   tmp/osx-x64/invxp


#
# Release
# ------------------------------------------------------------------------

hub release create v${VERSION} --message="Release v${VERSION}" \
   -a artifacts/invexp-win-x64-${VERSION}.zip \
   -a artifacts/invexp-linux-x64-${VERSION}.zip \
   -a artifacts/invexp-osx-x64-${VERSION}.zip

# eof
