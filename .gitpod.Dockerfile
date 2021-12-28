FROM gitpod/workspace-postgres

USER gitpod
#.NET installed via .gitpod.yml task until the following issue is fixed: https://github.com/gitpod-io/gitpod/issues/5090
ENV DOTNET_VERSION=5.0
ENV DOTNET_ROOT=/workspace/.dotnet
ENV PATH=$PATH:$DOTNET_ROOT

USER postgres

# RUN /etc/init.d/postgresql start &&\
#     psql --command "ALTER USER postgres WITH ENCRYPTED PASSWORD 'admin';"

# RUN echo "host all  all    0.0.0.0/0  md5" >> /etc/postgresql/12/main/pg_hba.conf

# RUN echo "listen_addresses='*'" >> /etc/postgresql/12/main/postgresql.conf

EXPOSE 5432
