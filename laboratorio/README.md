# 🚀 Laboratorio Udemy

<p align="center">  
  <img src="https://img.shields.io/badge/.NET-9.0-512BD4?logo=dotnet&logoColor=white" />
  <img src="https://img.shields.io/badge/C%23-Programming-239120?logo=c-sharp&logoColor=white" />
  <img src="https://img.shields.io/badge/ASP.NET-Core-5C2D91?logo=dotnet&logoColor=white" />
  <img src="https://img.shields.io/badge/API-RESTful-0A66C2?logo=fastapi&logoColor=white" />
  <img src="https://img.shields.io/badge/Testing-Postman-F24E1E?logo=postman&logoColor=white" />
  <img src="https://img.shields.io/badge/Data-InMemory-FFCA28?logo=databricks&logoColor=black" />
  <img src="https://img.shields.io/badge/Made%20with-%E2%9D%A4-red" />
</p>

## 📌 Descripción

**Laboratorio Udemy** es una API desarrollada con **ASP.NET Core Web Api**, diseñada para gestionar instructores mediante operaciones CRUD.

El proyecto implementa principios de **arquitectura limpia**, separación de responsabilidades y uso de **inyección de dependencias**, utilizando almacenamiento en memoria como mecanismo de persistencia temporal.

## 🧱 Arquitectura

El proyecto está organizado en capas siguiendo buenas prácticas:

```
LaboratorioUdemy
├── WebApi              → Exposición HTTP (Controllers, configuración)
├── Application         → Lógica de negocio
│   ├── Services
│   ├── DTOs
│   ├── Requests
│   └── Responses
└── Shared              → Utilidades y helpers
    ├── Cache
    └── Helpers
```

## 📌 Endpoints

<div align="center">

| Método | Endpoint                              | Descripción                     | Body | Response |
|--------|--------------------------------------|---------------------------------|------|----------|
| <img src="https://img.shields.io/badge/POST-28A745" />   | `/api/instructors`                   | Crear un nuevo instructor       | ![Required](https://img.shields.io/badge/Required-blue) | ![201](https://img.shields.io/badge/201-Created-success)<br>![400](https://img.shields.io/badge/400-BadRequest-red) |
| <img src="https://img.shields.io/badge/GET-0078D4" />     | `/api/instructors/{id}`              | Obtener instructor por ID       | ![None](https://img.shields.io/badge/None-lightgrey) | ![200](https://img.shields.io/badge/200-OK-success)<br>![404](https://img.shields.io/badge/404-NotFound-red) |
| <img src="https://img.shields.io/badge/GET-0078D4" />     | `/api/instructors?limit=10&offset=0` | Listar instructores (paginado)  | ![None](https://img.shields.io/badge/None-lightgrey) | ![200](https://img.shields.io/badge/200-OK-success) |
| <img src="https://img.shields.io/badge/PUT-FFC107" />   | `/api/instructors/{id}`              | Actualizar un instructor        | ![Required](https://img.shields.io/badge/Required-blue) | ![200](https://img.shields.io/badge/200-OK-success)<br>![404](https://img.shields.io/badge/404-NotFound-red) |
| <img src="https://img.shields.io/badge/DELETE-DC3545" />   | `/api/instructors/{id}`              | Eliminar un instructor          | ![None](https://img.shields.io/badge/None-lightgrey) | ![200](https://img.shields.io/badge/200-OK-success)<br>![404](https://img.shields.io/badge/404-NotFound-red) |

</div>

## 📦 Formato de Respuestas

### ✅ Respuesta estándar

```json
{
  "message": "string",
  "timeStamp": "2025-01-01T00:00:00",
  "data": {}
}
```

### 📄 Respuesta paginada

```json
{
  "message": "string",
  "timeStamp": "2025-01-01T00:00:00",
  "total": 10,
  "limit": 5,
  "offset": 0,
  "data": []
}
```

## 🧪 Pruebas de API (Postman)

> [!NOTE]
> Las imágenes corresponden a pruebas realizadas en entorno local.

A continuación se muestran evidencias de las operaciones CRUD realizadas sobre el recurso **Instructors** utilizando Postman.

### ➕ Crear Instructor

> Se registra un nuevo instructor en el sistema.

![Crear Instructor](./PuebasPostman/create.png)

### 🔍 Obtener Instructor por ID

> Consulta de un instructor específico mediante su identificador único.

![Obtener Instructor por ID](./PuebasPostman/getbyid.png)

### 📋 Listar Instructores

> Obtención de todos los instructores con paginación.

![Listar Instructores](./PuebasPostman/getall.png)

### ✏️ Actualizar Instructor

> Actualización de los datos de un instructor existente.

**Resultado de la actualización:**

![Actualizar Instructor](./PuebasPostman/update.png)

**Verificación posterior:**

![Instructor Actualizado](./PuebasPostman/getall-update.png)

### ❌ Eliminar Instructor

> Eliminación de un instructor del sistema.

**Resultado de la eliminación:**

![Eliminar Instructor](./PuebasPostman/delete.png)

**Verificación posterior:**

![Lista después de eliminar](./PuebasPostman/getall-delete.png)
