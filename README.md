# BreakFastHub REST API ☕️ 🍳

Welcome to BreakFastHub, a RESTful API for managing customized breakfasts. This API allows users to perform CRUD (Create, Read, Update, Delete) operations on breakfast records.

## Getting Started

These instructions will guide you on how to clone the project and interact with the API.

### Prerequisites

To run and test the API, you need the following tools installed:

- [.NET SDK](https://dotnet.microsoft.com/download)
- [Visual Studio Code](https://code.visualstudio.com/) (Optional but recommended)
- [REST Client Extension](https://marketplace.visualstudio.com/items?itemName=humao.rest-client) for VS Code or any API testing tool

### Installation

1. Clone the repository:

    ```bash
    git clone https://github.com/Monsieur-II/restApi-BreakFastHub.git
    cd restApi-BreakFastHub/BreakFastHub
    ```

2. Run the API:

    ```bash
    dotnet run
    ```

    The API will be hosted at `http://localhost:5000`.

3. Open your preferred API testing tool (e.g., VS Code Rest Client) and use the provided `.http` request files in the `requests` directory to interact with the API.
Localhost port could be different.

## API Endpoints

### Create a Breakfast

```http
POST http://localhost:5000/breakfasts
Content-Type: application/json

{
  "name": "Healthy Start",
  "description": "A nutritious breakfast to kickstart your day",
  "startDateTime": "2022-03-01T08:00:00",
  "endDateTime": "2022-03-01T09:00:00",
  "savory": false,
  "sweet": true
}
```

### Get a Breakfast
```http
GET http://localhost:5000/breakfasts/{id}
```

### Update a Breakfast
```http
PUT http://localhost:5000/breakfasts/{id}
Content-Type: application/json

{
  "name": "New Name",
  "description": "Updated description",
  "startDateTime": "2022-03-01T09:30:00",
  "endDateTime": "2022-03-01T10:30:00",
  "savory": true,
  "sweet": false
}

```

### Delete a Breakfast
```http
DELETE http://localhost:5000/breakfasts/{id}

```
