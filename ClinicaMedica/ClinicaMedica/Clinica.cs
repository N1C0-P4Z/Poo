using Clinicamedica;
using Microsoft.EntityFrameworkCore;

namespace ClinicaMedica;

public class Clinica
{
    private readonly ClinicaContext _context;

    public Clinica(ClinicaContext context)
    {
        _context = context;
    }

    // ──────────────────────────────────────────────
    //  Paciente
    // ──────────────────────────────────────────────

    public Paciente? BuscarPaciente(int dni)
    {
        return _context.Pacientes.FirstOrDefault(p => p.Dni == dni);
    }

    public Paciente RegistrarPaciente(int dni, string nombre, string apellido,
        string? telefono, string? email, string fechaNacimiento)
    {
        var paciente = new Paciente
        {
            Dni = dni,
            Nombre = nombre,
            Apellido = apellido,
            Telefono = telefono,
            Email = email,
            FechaNacimiento = fechaNacimiento
        };

        _context.Pacientes.Add(paciente);
        _context.SaveChanges();
        return paciente;
    }

    // ──────────────────────────────────────────────
    //  Especialidad / Médico / Disponibilidad
    // ──────────────────────────────────────────────

    public List<Especialidad> ListarEspecialidades()
    {
        return _context.Especialidades.ToList();
    }

    public List<Medico> ListarMedicos(int idEspecialidad)
    {
        return _context.Medicos
            .Where(m => m.Activo == 1)
            .Where(m => _context.Disponibilidades
                .Any(d => d.Matricula == m.Matricula
                       && d.IdEspecialidad == idEspecialidad))
            .ToList();
    }

    public List<Disponibilidad> VerDisponibilidad(int matricula, int idEspecialidad)
    {
        return _context.Disponibilidades
            .Where(d => d.Matricula == matricula
                     && d.IdEspecialidad == idEspecialidad)
            .Include(d => d.Medico)
            .Include(d => d.Especialidad)
            .ToList();
    }

    // ──────────────────────────────────────────────
    //  Turnos
    // ──────────────────────────────────────────────

    public List<Turno> VerTurnosReservados(int dni)
    {
        int reservadoId = ObtenerIdEstado("reservado");

        return _context.Turnos
            .Where(t => t.Dni == dni && t.IdEstado == reservadoId)
            .Include(t => t.Medico)
            .Include(t => t.Especialidad)
            .Include(t => t.Estado)
            .ToList();
    }

    public bool CancelarTurno(int dni, int matricula, int idEspecialidad)
    {
        var turno = _context.Turnos.Find(dni, matricula, idEspecialidad);
        if (turno == null)
            return false;

        int reservadoId = ObtenerIdEstado("reservado");
        if (turno.IdEstado != reservadoId)
            return false;

        int canceladoId = ObtenerIdEstado("cancelado");
        turno.IdEstado = canceladoId;
        _context.SaveChanges();

        // Desenganchar para que no interfiera si después se crea un turno con la misma key
        _context.Entry(turno).State = EntityState.Detached;
        return true;
    }

    public bool RegistrarTurno(int dni, int matricula, int idEspecialidad,
        string fecha, string hora)
    {
        try
        {
            int reservadoId = ObtenerIdEstado("reservado");

            var turno = new Turno
            {
                Dni = dni,
                Matricula = matricula,
                IdEspecialidad = idEspecialidad,
                Fecha = fecha,
                Hora = hora,
                IdEstado = reservadoId
            };

            _context.Turnos.Add(turno);
            _context.SaveChanges();
            return true;
        }
        catch (DbUpdateException)
        {
            return false;
        }
        catch (InvalidOperationException)
        {
            return false;
        }
    }

    // ──────────────────────────────────────────────
    //  Internos
    // ──────────────────────────────────────────────

    private int ObtenerIdEstado(string descripcion)
    {
        return _context.Estados
            .Where(e => e.Descripcion == descripcion)
            .Select(e => e.IdEstado)
            .FirstOrDefault();
    }
}
