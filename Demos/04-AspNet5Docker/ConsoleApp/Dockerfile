FROM microsoft/aspnet:1.0.0-beta7-coreclr

ENV RUNTIME_PACKAGES libunwind8, gettext, libssl-dev, libcurl3-dev, zlib1g

COPY . /app

WORKDIR /app

RUN ["dnu", "restore"]

ENTRYPOINT ["dnx", "run"]
