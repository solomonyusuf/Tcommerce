# Tcommerce 

This is the backend API for the Tcommerce application, built with ASP.NET Core following a clean architecture approach.

---

## Tech Stack

- ASP.NET Core Web API  
- Entity Framework Core  
- JWT Authentication  
- Clean Architecture (Domain, Application, Persistence, Presentation)

---

## Project Structure

Domain → Core entities and business rules  
Application → Services, DTOs, interfaces  
Persistence → Database, DbContext, repositories  
Presentation → API controllers (entry point)

---

## Authentication

The API uses JWT (JSON Web Token) for securing endpoints.

### Get Token

GET /api/jwt/token

Response:

```json
{
  "token": "your-jwt-token"
}
```

## Frontend

The frontend (React + Bootstrap) is located in:

/frontend/tcommerceclient

It consumes this API using JWT authentication.

# Notes
Token endpoint is for development/testing
In production, replace with proper login system
Ensure CORS is enabled for frontend access

# Architecture

See:

Microservice Architecture.png
