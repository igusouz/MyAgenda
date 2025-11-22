# 📒 MyAgenda - .NET API with Vue.JS

MyAgenda is a simple and efficient scheduling application designed to help users manage appointments, contacts, and daily tasks.
This project was built with a modern full-stack architecture, using reliable and scalable technologies on both backend and frontend.


### 🛠️ Technologies Used
#### Backend — .NET

The backend of MyAgenda was developed using .NET, providing a robust structure for building RESTful APIs. Key features include:

- ASP.NET Core for API development
- Entity Framework Core for database interactions
- Sqlite Database
- Swagger for documentation

#### Frontend — Vue.js

The frontend was built with Vue.js, focusing on clean UI and responsive interactions.
- Axios to communicate with backend
- Tailwind-css to optimize our design
- Router to better routing through pages

#### Turorials to run it

###### To run it separete:

On *_MyAgenda\MyAgenda.API_*
```md
dotnet run
```
It will be avaliable on http://localhost:5038/swagger/index.html

On *_MyAgenda\MyAgenda.Frontend_*
```md
npm install
```
Then go by
```md
npm run dev
```
It will be avaliable on http://localhost:5173/contacs

###### To run by docker:
On *_MyAgenda_/*
```md
docker compose up --build
```
*_MyAgenda\MyAgenda.API_* will be avaliable on http://localhost:8080/index.html

*_MyAgenda\MyAgenda.Fronted_* will be avaliable on http://localhost:3000
