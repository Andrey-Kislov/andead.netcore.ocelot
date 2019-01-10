#!/bin/bash
set -ev

echo "dotnet andead.netcore.ocelot.dll --issuer=$ISSUER --audience=$AUDIENCE --signing-key=$SIGNING_KEY" >> ./publish/entrypoint.sh

docker build -t andead/netcore.ocelot:latest publish/.

docker login -u $DOCKER_USERNAME -p $DOCKER_PASSWORD
docker push andead/netcore.ocelot:latest
