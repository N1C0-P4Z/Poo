using Clinicamedica;
using ClinicaMedica;

var context = new ClinicaContext();
var clinica = new Clinica(context);

Console.WriteLine("=== SISTEMA DE GESTION DE TURNOS ===\n");

int dni, idEspecialidad, matricula;
string fecha = "", hora = "";
Especialidad espSeleccionada = null!;
Medico medicoSeleccionado = null!;
Paciente? paciente;
 
 // ──────────────────────────────────────────────
 //  PASO 1: Ingresar DNI del paciente
 // ──────────────────────────────────────────────
 
while (true)
{
    Console.Write("Ingrese el DNI del paciente (0 = Salir): ");
    string? input = Console.ReadLine()?.Trim();
    if (input == "0") return;
    if (int.TryParse(input, out dni)) break;
    Console.WriteLine("DNI invalido. Debe ser un numero entero.\n");
}

paciente = clinica.BuscarPaciente(dni);

if (paciente != null)
{
    Console.WriteLine($"\nPaciente: {paciente.Nombre} {paciente.Apellido}");
    Console.WriteLine($"Telefono: {paciente.Telefono ?? "-"} | Email: {paciente.Email ?? "-"}");
    Console.WriteLine($"Fecha de nacimiento: {paciente.FechaNacimiento}");

    var turnos = clinica.VerTurnosReservados(dni);
    if (turnos.Count > 0)
    {
        Console.WriteLine($"\nTurnos reservados ({turnos.Count}):");
        for (int i = 0; i < turnos.Count; i++)
        {
            var t = turnos[i];
            Console.WriteLine($"  {i + 1}. {t.Fecha} {t.Hora} | Dr. {t.Medico.Apellido} ({t.Especialidad.Nombre})");
        }

        Console.Write("\nDesea cancelar algun turno? (s/n): ");
        if (Console.ReadLine()?.Trim().ToLower() == "s")
        {
            Console.Write("Seleccione el numero de turno: ");
            if (int.TryParse(Console.ReadLine(), out int idx) && idx >= 1 && idx <= turnos.Count)
            {
                var t = turnos[idx - 1];
                if (clinica.CancelarTurno(t.Dni, t.Matricula, t.IdEspecialidad))
                    Console.WriteLine("Turno cancelado exitosamente.");
                else
                    Console.WriteLine("No se pudo cancelar el turno (puede que ya no este reservado).");
            }
            else
            {
                Console.WriteLine("Seleccion invalida.");
            }
        }
    }
    else
    {
        Console.WriteLine("\nNo tiene turnos reservados.");
    }
}
else
{
    Console.WriteLine("\nPaciente no encontrado. Registre los datos:");

    string nombre = "", apellido = "";
    while (string.IsNullOrWhiteSpace(nombre))
    {
        Console.Write("Nombre (0 = Salir): ");
        string? input = Console.ReadLine()?.Trim();
        if (input == "0") return;
        nombre = input ?? "";
        if (string.IsNullOrWhiteSpace(nombre))
            Console.WriteLine("El nombre es obligatorio.");
    }

    while (string.IsNullOrWhiteSpace(apellido))
    {
        Console.Write("Apellido (0 = Salir): ");
        string? input = Console.ReadLine()?.Trim();
        if (input == "0") return;
        apellido = input ?? "";
        if (string.IsNullOrWhiteSpace(apellido))
            Console.WriteLine("El apellido es obligatorio.");
    }

    Console.Write("Telefono (opcional): ");
    string? telefono = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(telefono)) telefono = null;

    Console.Write("Email (opcional): ");
    string? email = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(email)) email = null;

    string fechaNac = "";
    while (string.IsNullOrWhiteSpace(fechaNac))
    {
        Console.Write("Fecha de nacimiento (DD/MM/AAAA, 0 = Salir): ");
        string? input = Console.ReadLine()?.Trim();
        if (input == "0") return;
        fechaNac = input ?? "";
        if (string.IsNullOrWhiteSpace(fechaNac))
            Console.WriteLine("La fecha de nacimiento es obligatoria.");
    }

    paciente = clinica.RegistrarPaciente(dni, nombre, apellido, telefono, email, fechaNac);
    Console.WriteLine("Paciente registrado exitosamente.");
}

// ──────────────────────────────────────────────
//  PASO 2: Seleccionar especialidad
// ──────────────────────────────────────────────

PASO2:
while (true)
{
    Console.WriteLine("\n--- ESPECIALIDADES DISPONIBLES ---");
    var especialidades = clinica.ListarEspecialidades();

    if (especialidades.Count == 0)
    {
        Console.WriteLine("No hay especialidades cargadas en el sistema.");
        return;
    }

    foreach (var e in especialidades)
        Console.WriteLine($"  {e.IdEspecialidad}. {e.Nombre} ({e.DuracionTurnoMin} min)");

    Console.Write("\nSeleccione especialidad (0 = Salir): ");
    string? input = Console.ReadLine()?.Trim();
    if (input == "0") return;
    if (int.TryParse(input, out idEspecialidad) &&
        especialidades.Any(e => e.IdEspecialidad == idEspecialidad))
    {
        espSeleccionada = especialidades.First(e => e.IdEspecialidad == idEspecialidad);
        break;
    }

    Console.WriteLine("Especialidad invalida. Intente nuevamente.\n");
}

// ──────────────────────────────────────────────
//  PASO 3: Seleccionar medico
// ──────────────────────────────────────────────

PASO3:
while (true)
{
    Console.WriteLine($"\n--- MEDICOS DISPONIBLES - {espSeleccionada.Nombre.ToUpper()} ---");
    var medicos = clinica.ListarMedicos(idEspecialidad);

    if (medicos.Count == 0)
    {
        Console.WriteLine("No hay medicos disponibles para esta especialidad.");
        Console.WriteLine("Volviendo a la seleccion de especialidad...\n");
        goto PASO2;
    }

    foreach (var m in medicos)
        Console.WriteLine($"  Matricula {m.Matricula}: {m.Nombre} {m.Apellido}");

    Console.Write("\nSeleccione matricula del medico (0 = Salir, 9 = Volver): ");
    string? input = Console.ReadLine()?.Trim();
    if (input == "0") return;
    if (input == "9") goto PASO2;
    if (int.TryParse(input, out matricula) &&
        medicos.Any(m => m.Matricula == matricula))
    {
        medicoSeleccionado = medicos.First(m => m.Matricula == matricula);
        break;
    }

    Console.WriteLine("Medico invalido. Intente nuevamente.\n");
}

// ──────────────────────────────────────────────
//  PASO 4: Mostrar disponibilidad e ingresar fecha/hora
// ──────────────────────────────────────────────

PASO4:
while (true)
{
    Console.WriteLine("\n--- DISPONIBILIDAD DEL MEDICO ---");
    var disponibilidad = clinica.VerDisponibilidad(matricula, idEspecialidad);

    if (disponibilidad.Count == 0)
    {
        Console.WriteLine("No hay horarios disponibles para este medico.");
        Console.WriteLine("Volviendo a la seleccion de medico...\n");
        goto PASO3;
    }

    string[] diasSemana = { "Domingo", "Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sabado" };

    foreach (var d in disponibilidad)
        Console.WriteLine($"  {diasSemana[d.DiaSemana]}: {d.HoraInicio} - {d.HoraFin}");

    // ── Fecha ──
    while (true)
    {
        Console.Write("\nIngrese fecha (DD/MM/AAAA, 0 = Salir, 9 = Volver): ");
        string? input = Console.ReadLine()?.Trim();
        if (input == "0") return;
        if (input == "9") goto PASO3;
        if (!string.IsNullOrWhiteSpace(input) && DateTime.TryParse(input, out _))
        {
            fecha = input;
            break;
        }
        Console.WriteLine("Fecha invalida. Use el formato DD/MM/AAAA.");
    }

    // ── Hora ──
    while (true)
    {
        Console.Write("Ingrese hora (HH:MM, 0 = Salir, 9 = Volver): ");
        string? input = Console.ReadLine()?.Trim();
        if (input == "0") return;
        if (input == "9") goto PASO3;
        if (!string.IsNullOrWhiteSpace(input) && TimeSpan.TryParse(input, out _))
        {
            hora = input;
            break;
        }
        Console.WriteLine("Hora invalida. Use el formato HH:MM.");
    }

    break;
}

// ──────────────────────────────────────────────
//  PASO 5: Confirmar y registrar
// ──────────────────────────────────────────────

Console.WriteLine("\n--- RESUMEN DEL TURNO ---");
Console.WriteLine($"Paciente: {paciente.Nombre} {paciente.Apellido} (DNI: {paciente.Dni})");
Console.WriteLine($"Especialidad: {espSeleccionada.Nombre}");
Console.WriteLine($"Medico: Dr. {medicoSeleccionado.Nombre} {medicoSeleccionado.Apellido}");
Console.WriteLine($"Fecha: {fecha} - {hora}");

Console.Write("\nConfirmar y registrar turno (s = si, 0 = Salir, 9 = Volver): ");
string? opcion = Console.ReadLine()?.Trim().ToLower();
if (opcion == "0") return;
if (opcion == "9") goto PASO4;

if (opcion == "s")
{
    bool ok = clinica.RegistrarTurno(dni, matricula, idEspecialidad, fecha, hora);
    if (ok)
        Console.WriteLine("Turno registrado exitosamente con estado 'reservado'.");
    else
        Console.WriteLine("Error: Ya existe un turno del mismo paciente con este medico y especialidad.");
}
else
{
    Console.WriteLine("Registro cancelado. No se creo ningun turno.");
}
