# Tcommerce Backend

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
