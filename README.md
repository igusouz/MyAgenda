# 📒 MyAgenda - .NET API with Vue.JS

MyAgenda is a simple and efficient contactlist, where you can save your contacts with their most important information: Name, email and cellphone number.


### 🛠️ Technologies Used
#### Backend — .NET

The backend of MyAgenda was developed using .NET, providing a robust structure for building RESTful APIs. Key features include:

- ASP.NET Core for API development
- Entity Framework Core for database interactions
- Sqlite Database
- Swagger for documentation

#### Frontend — Vue.js

The frontend was built with Vue.js, focusing on clean UI and responsive interactions.
- Axios to communicate with the backend
- Tailwind CSS to improve the design workflow
- Vue Router for better page navigation

#### 🚀 To run it Docker

*Make sure your docker desktop is up and running*

In *_MyAgenda_/*

```md
docker compose build
```
Then:
```md
docker compose up
```
*_MyAgenda\MyAgenda.API_* will be available at http://localhost:8080/swagger/index.html

*_MyAgenda\MyAgenda.Fronted_* will be available at http://localhost/contacts
