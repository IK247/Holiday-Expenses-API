# Holiday Expenses API

A lightweight RESTful API for managing holiday expenses, built with ASP.NET Core. This API allows users to:

- Add, update, delete, and retrieve holiday expenses.
- Search expenses by description or category.

## Features
- **Endpoints**:
  - `POST /api/Expense`: Add a new expense.
  - `GET /api/Expense/all`: Retrieve all expenses.
  - `GET /api/Expense/search`: Search expenses by description.
  - `GET /api/Expense/category`: Search expenses by category.
  - `PUT /api/Expense/{id}`: Update an expense.
  - `DELETE /api/Expense/{id}`: Delete an expense.
- Persistent storage using LiteDB.

## Technologies Used
- ASP.NET Core
- LiteDB (for database integration)
- Swagger (for API documentation)
