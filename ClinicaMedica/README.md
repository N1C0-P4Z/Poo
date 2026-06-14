# ClinicaMedica

Sistema de gestión de turnos para una clínica médica. Implementa un flujo de 5 pasos para registrar turnos usando .NET + Entity Framework Core + SQLite.

## Requisitos

- **.NET 8.0 SDK** (descargar de [dotnet.microsoft.com](https://dotnet.microsoft.com/download/dotnet/8.0))
- **SQLite** (incluido en el driver EF Core, no requiere instalación aparte)
- **DBeaver** (opcional, para ver/editar la base de datos directamente)

> ⚠️ **Nota sobre la versión**: El proyecto fue originalmente creado con .NET 10 (versión del profesor), pero se adaptó a .NET 8.0. Si usás .NET 10, actualizá el `TargetFramework` en `ClinicaMedica.csproj` a `net10.0` y los paquetes EF Core a versión 10.x.

## Estructura del proyecto

```
ClinicaMedica/
├── ClinicaMedica.slnx
├── README.md
└── ClinicaMedica/
    ├── ClinicaMedica.csproj
    ├── Program.cs                # Flujo de 5 pasos (entrada del usuario)
    ├── Clinica.cs                # Orquestador con operaciones de negocio
    ├── DBContext.cs              # Contexto de EF Core y mapeo
    ├── Paciente.cs               # Modelos de dominio
    ├── Medico.cs
    ├── Especialidad.cs
    ├── Turno.cs
    ├── Estado.cs
    └── Disponibilidad.cs
```

## Como correrlo

### En Linux

```bash
# Parado en la carpeta del proyecto
cd ClinicaMedica/ClinicaMedica

# Restaurar dependencias (solo la primera vez)
dotnet restore

# Compilar la primera vez
dotnet build

# Ejecutar
dotnet run
```

### En Windows con Visual Studio (el violeta, IDE completo)

1. Abrí `ClinicaMedica.sln` (recomendado) o `ClinicaMedica.slnx` (VS 2022 17.8+) desde Visual Studio.
2. En el **Explorador de soluciones**, hace clic derecho sobre `ClinicaMedica` → **Establecer como proyecto de inicio**.
3. Apretá `F5` o el botón ▶️ **Inicio** para compilar y ejecutar.

> Si el `.slnx` no se abre, usa el `.sln` (formato tradicional compatible con cualquier versión de VS). O abrí directamente la carpeta `ClinicaMedica/` como proyecto.
2. En el **Explorador de soluciones**, hace clic derecho sobre `ClinicaMedica` → **Establecer como proyecto de inicio**.
3. Apretá `F5` o el botón ▶️ **Inicio** para compilar y ejecutar.

Si faltan los paquetes NuGet:

```bash
# En la Terminal de Visual Studio (o Package Manager Console):
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
```

## Base de datos

> La base de datos original (`hospital_turnos.db`) fue creada el 01/06 como actividad para la clase del 08/06. Para esta entrega se utilizó la base de datos proporcionada por el profesor (`ClinicaMedica.db`) que ya incluye datos de prueba.

El sistema usa **SQLite**. La base de datos esta en el proyecto:

```
ClinicaMedica/ClinicaMedica/ClinicaMedica.db
```

La conexion se define en `ClinicaMedica/DBContext.cs` con ruta relativa:

```csharp
options.UseSqlite(@"Data Source=ClinicaMedica.db");
```

Como el `.db` esta en la misma carpeta que el `.csproj`, funciona tanto en Linux como en Windows sin cambios. Si queres usar tu propia base, reemplaza el archivo o cambia la ruta en `DBContext.cs`.

> La base incluye datos de prueba: 5 especialidades, 4 medicos, 5 pacientes y varios turnos en distintos estados (reservado, atendido, cancelado).

### Datos iniciales

Si la base esta vacia, ejecuta estas sentencias en DBeaver o cualquier cliente SQLite para cargar los datos de prueba del profesor:

```sql
-- Estados
INSERT INTO estado (id_estado, descripcion) VALUES 
(1, 'reservado'), (2, 'atendido'), (3, 'cancelado');

-- Especialidades
INSERT INTO especialidad (id_especialidad, nombre, duracion_turno_min) VALUES 
(1, 'Clínica médica', 20), (2, 'Cardiología', 30), (3, 'Psicología', 50),
(4, 'Pediatría', 20), (5, 'Traumatología', 30);

-- Medicos (dia_semana: 1=Lunes, 2=Martes, 3=Miercoles, 4=Jueves, 5=Viernes)
INSERT INTO medico (matricula, nombre, apellido, activo) VALUES 
(1001, 'Laura', 'Sánchez', 1), (1002, 'Carlos', 'Ríos', 1),
(1003, 'Valeria', 'Torres', 1), (1004, 'Marcos', 'Ibáñez', 1);

-- Disponibilidad
INSERT INTO disponibilidad (matricula, id_especialidad, dia_semana, hora_inicio, hora_fin) VALUES 
(1001, 1, 1, '08:00', '12:00'),   -- Laura Sanchez atiende Clinica medica los LUNES
(1001, 2, 3, '14:00', '18:00'),   -- Laura Sanchez atiende Cardiologia los MIERCOLES
(1002, 4, 2, '09:00', '13:00'),   -- Carlos Rios atiende Pediatria los MARTES
(1002, 1, 4, '15:00', '19:00'),   -- Carlos Rios atiende Clinica medica los JUEVES
(1003, 3, 2, '10:00', '16:00'),   -- Valeria Torres atiende Psicologia los MARTES
(1003, 3, 5, '08:00', '12:00'),   -- Valeria Torres atiende Psicologia los VIERNES
(1004, 5, 1, '13:00', '17:00'),   -- Marcos Ibanez atiende Traumatologia los LUNES
(1004, 2, 3, '08:00', '12:00');   -- Marcos Ibanez atiende Cardiologia los MIERCOLES
```

## Flujo de 5 pasos

| Paso | Descripcion |
|------|-------------|
| 1 | Ingresar DNI del paciente. Si existe muestra sus datos + turnos reservados (opcion de cancelar). Si no existe, pide los datos y lo registra. |
| 2 | Lista especialidades disponibles. Seleccionar una. |
| 3 | Lista medicos que atienden esa especialidad. Seleccionar uno. |
| 4 | Muestra los horarios del medico para esa especialidad. Ingresar fecha y hora. |
| 5 | Muestra resumen y pide confirmacion. Guarda el turno como "reservado". |

### Navegacion

| Comando | Que hace |
|---------|----------|
| `0` | Salir del programa en cualquier paso |
| `9` | Volver al paso anterior (en medico, fecha/hora y confirmacion) |
