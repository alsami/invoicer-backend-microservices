FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app
# Copy necessary files and restore as distinct layer

COPY *.csproj ./Invoicer.Common
RUN echo $(ls)
# Copy everything else and build
# COPY . ./
# RUN dotnet publish -c Release -o out
