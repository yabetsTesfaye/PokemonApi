# Pokémon API

This project is a **Pokémon API** built with [Node.js/Express.js]. It provides a simple interface for performing CRUD operations on Pokémon data and includes features to fetch items by their `id` and `type`.

---

## Features
- **Create**: Add new Pokémon to the database.
- **Read**: Retrieve Pokémon data.
  - Get all Pokémon.
  - Get a Pokémon by its `id`.
  - Get Pokémon by their `type`.
- **Update**: Modify details of existing Pokémon.
- **Delete**: Remove Pokémon from the database.

---

## Endpoints

### Base URL

### 1. Get All Pokémon
**GET** `/`
- **Description**: Retrieve a list of all Pokémon.
- **Response**: 
  ```json
  [    {      "id": 1,      "name": "Pikachu",      "type": "Electric"    },    {      "id": 2,      "name": "Charmander",      "type": "Fire"    }  ]
{
  "id": 1,
  "name": "Pikachu",
  "type": "Electric"
}
[
  {
    "id": 2,
    "name": "Charmander",
    "type": "Fire"
  }
]
{
  "name": "Bulbasaur",
  "type": "Grass"
}
{
  "message": "Pokémon added successfully",
  "pokemon": {
    "id": 3,
    "name": "Bulbasaur",
    "type": "Grass"
  }
}
{
  "name": "Bulbasaur",
  "type": "Grass/Poison"
}

{
  "message": "Pokémon updated successfully",
  "pokemon": {
    "id": 3,
    "name": "Bulbasaur",
    "type": "Grass/Poison"
  }
}
{
  "message": "Pokémon deleted successfully"
}
git clone https://github.com/yourusername/PokemonApi.git
cd PokemonApi
npm install
npm start

---

You can adjust the details to fit your project. Let me know if you need specific customization or additional functionality!



