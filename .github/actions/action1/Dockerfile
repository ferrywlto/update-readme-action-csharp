# Container image that runs your code
# FROM alpine:3.10

# # Copies your code file from your action repository to the filesystem path `/` of the container
# COPY entrypoint.sh /entrypoint.sh

# # Code file to execute when the docker container starts up (`entrypoint.sh`)
# ENTRYPOINT ["/entrypoint.sh"]

FROM mcr.microsoft.com/dotnet/sdk:6.0 as builder
WORKDIR /app
COPY . .
RUN dotnet publish -c Release -o /out
COPY entrypoint.sh /out/entrypoint.sh

FROM mcr.microsoft.com/dotnet/runtime:6.0 as base
WORKDIR /app
COPY --from=builder /out .