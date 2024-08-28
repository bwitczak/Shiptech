# Shiptech

Shiptech is an application designed to manage ship technical drawings efficiently. It provides a robust platform for adding, managing, and releasing technical drawings for production.

## Features

- Manage technical drawings
- Upload and download technical drawings
- Export technical drawings to Excel
- Release finished drawings for production
- Authentication and authorization

## Technology Stack

### Backend
- Language: C#
- Database: Postgres
- Architecture: Clean Architecture with CQRS pattern

### Frontend
- Framework: Angular (UI/UX design in progress)

## Current Status

The project is under active development. Currently, endpoints for managing technical drawings have been implemented. Other features are in the planning and development stages.

## Getting Started

### Current Development Setup

Currently, the application can be run locally using the following steps:

1. Ensure you have a local Postgres server running, or use the provided `docker-compose.yml` in the root of the project to set up a Postgres container:

   ```
   docker compose up -d
   ```

2. Navigate to the API project directory:

   ```
   cd ./Shiptech.Api
   ```

3. Run the application using the .NET CLI:

   ```
   dotnet run
   ```

### Docker Setup (Planned)

In the future, the entire build application will be containerized and run using Docker with reverse proxy. The setup will be as follows:

#### Prerequisites

- Docker
- Docker Compose

#### Running the Application

1. Clone the repository to your local machine.
2. Navigate to the root directory of the project where the `docker-compose.yml` file is located.
3. Run the following command to start the application:

   ```
   docker compose up -d
   ```

   This command will build and start all the necessary containers in detached mode.

4. Once the containers are up and running, you can access the application through the specified ports (add more details about accessing the frontend and backend if available).

#### Stopping the Application

To stop the application, run the following command in the same directory:

```
docker compose down
```

This will stop and remove the containers, networks, and volumes created by `docker compose up`.

## API Documentation

API documentation will be available in the future through Swagger UI at

```
http://localhost:5290/swagger
```

Currently, Swagger has been temporarily disabled as it's not being used as an HTTP Client. For API testing and exploration, Insomnia is being used due to personal preferences.

