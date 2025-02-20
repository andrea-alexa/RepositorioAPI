# ApiBackend

- Entorno de desarrollo:
Visual Studio 2022 o superior
.NET 8 o superior
SQL Server

- Especificaciones de la API:
La API debe manejar una entidad llamada Producto con los siguientes campos:
Id (int, clave primaria, autoincremental)
Nombre (string, obligatorio, máximo 100 caracteres)
Precio (decimal, obligatorio, mayor a 0)
Stock (int, obligatorio, mínimo 0)

# Instalación
Clonar el repositorio: 
git clone https://github.com/andrea-alexa/RepositorioAPI.git

Configurar la base de datos: 
- Asegúrate de que SQL Server esté corriendo.
- Modifica la cadena de conexión en appsettings.json:
"ConnectionStrings": {
  "TiendaApiConnection": "Data Source=LAPTOP-G7ROBOV1;Initial Catalog=TiendaAPI;Integrated Security=True;Encrypt=True;Trust Server Certificate=True"
}

Aplicar migraciones:
En la consola colocamos Add-Migration InitDb y luego update-Database

Ejecutar:
- GET /api/productos -> Obtener todos los productos
- GET /api/productos/{id} -> Obtener un producto por ID
- POST /api/productos ->  Agregar un nuevo producto
- PUT /api/productos/{id} -> Actualizar un producto
- DELETE /api/productos/{id} -> Eliminar un producto

Funcionamiento:
https://docs.google.com/document/d/1SteUK10VZ82TYf7gNWcdPmoY-apsnlbi4B2xzLHYyCo/edit?usp=sharing

Autor: nm0753032023@unab.edu.sv
