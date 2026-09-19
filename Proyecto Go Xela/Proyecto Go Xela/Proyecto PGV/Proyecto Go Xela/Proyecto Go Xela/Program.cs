using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace Proyecto_Go_Xela
{
    internal static class Program
    {
        /// <summary>
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            InMemoryStore.Load();

            Application.ApplicationExit += (s, e) => InMemoryStore.Save();

            Application.Run(new Inicio());
        }
    }

    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public bool EsPreferente { get; set; }
        public string CorreoElectronico { get; set; }
        public Address Direccion { get; set; }
        public int CantidadSolicitudes { get; set; }
    }

    public class Repartidor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public bool Disponible { get; set; }
        public List<string> Licencias { get; set; }
        public string NumeroLicencia { get; set; }
        public int CantidadEntregasRealizadas { get; set; }
        public double CalificacionPromedio { get; set; }
    }

    public class Paquete
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public double PesoKg { get; set; }
        public string Dimensiones { get; set; }
        public PackageType Tipo { get; set; }
        public string DireccionOrigen { get; set; }
        public string DireccionDestino { get; set; }
        public double ValorDeclarado { get; set; }
        public string Estado { get; set; }
    }

    public enum PackageType
    {
        Normal,
        Fragil,
        Refrigerado,
        Sobredimensionado
    }

    public class Vehiculo
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public VehicleType Tipo { get; set; }
        public double CapacidadKg { get; set; }
        public bool Disponible { get; set; }
        public string LicenciaRequerida { get; set; }
        public double CostoOperativo { get; set; }
    }

    public enum VehicleType
    {
        Moto,
        Carro,
        Bicicleta,
        Furgon
    }

    public class Entrega
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public Repartidor Repartidor { get; set; }
        public Paquete Paquete { get; set; }
        public string Vehiculo { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public double DistanciaKm { get; set; }
        public double TarifaBase { get; set; }
        public double Recargos { get; set; }
        public double Descuentos { get; set; }
        public double Total { get; set; }
        public DateTime FechaSolicitud { get; set; }

        public DateTime Fecha { get; set; }

        public ServiceType TipoServicio { get; set; }

        public DeliveryStatus Estado { get; set; }

        public List<Incidencia> Incidencias { get; set; }
        public List<StateChangeRecord> EstadoHistorial { get; set; }

        public int? Calificacion { get; set; }
    }

    public enum IncidenciaTipo
    {
        ClienteAusente,
        DireccionIncorrecta,
        PaqueteDaniado,
        VehiculoAveriado,
        Retraso,
        ProblemasClimaticos,
        RechazoRecepcion
    }

    public enum IncidenciaEstado
    {
        Abierta,
        EnProceso,
        Cerrada
    }

    public class Incidencia
    {
        public string Codigo { get; set; }
        public IncidenciaTipo Tipo { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public IncidenciaEstado Estado { get; set; }
        public string AccionTomada { get; set; }
    }

    public enum ServiceType
    {
        Normal,
        Prioritario,
        Urgente
    }

    public class StateChangeRecord
    {
        public DeliveryStatus From { get; set; }
        public DeliveryStatus To { get; set; }
        public string User { get; set; }
        public DateTime Timestamp { get; set; }
        public string Note { get; set; }
    }

    public enum DeliveryStatus
    {
        Solicitada,
        Asignada,
        Recogida,
        EnRuta,
        Entregada,
        Cancelada,
        Reprogramada,
        ConIncidencia
    }

    public static class DeliveryWorkflow
    {
        public static List<DeliveryStatus> GetAllowedTransitions(DeliveryStatus from)
        {
            var list = new List<DeliveryStatus>();
            switch (from)
            {
                case DeliveryStatus.Solicitada:
                    list.Add(DeliveryStatus.Asignada);
                    list.Add(DeliveryStatus.Cancelada);
                    list.Add(DeliveryStatus.Reprogramada);
                    list.Add(DeliveryStatus.ConIncidencia);
                    break;
                case DeliveryStatus.Asignada:
                    list.Add(DeliveryStatus.Recogida);
                    list.Add(DeliveryStatus.Cancelada);
                    list.Add(DeliveryStatus.Reprogramada);
                    list.Add(DeliveryStatus.ConIncidencia);
                    break;
                case DeliveryStatus.Recogida:
                    list.Add(DeliveryStatus.EnRuta);
                    list.Add(DeliveryStatus.Cancelada);
                    list.Add(DeliveryStatus.ConIncidencia);
                    break;
                case DeliveryStatus.EnRuta:
                    list.Add(DeliveryStatus.Entregada);
                    list.Add(DeliveryStatus.ConIncidencia);
                    list.Add(DeliveryStatus.Reprogramada);
                    break;
                case DeliveryStatus.Reprogramada:
                    list.Add(DeliveryStatus.Asignada);
                    list.Add(DeliveryStatus.Cancelada);
                    list.Add(DeliveryStatus.ConIncidencia);
                    break;
                case DeliveryStatus.ConIncidencia:
                    list.Add(DeliveryStatus.Asignada);
                    list.Add(DeliveryStatus.Cancelada);
                    break;
                case DeliveryStatus.Entregada:
                case DeliveryStatus.Cancelada:
                default:
                    break;
            }
            return list;
        }

        public static bool IsValidTransition(DeliveryStatus from, DeliveryStatus to)
        {
            if (from == to) return true; 
            var allowed = GetAllowedTransitions(from);
            return allowed.Contains(to);
        }
    }

    public static class InMemoryStore
    {
        private static int _clienteId = 1;
        private static int _repartidorId = 1;
        private static int _paqueteId = 1;
        private static int _entregaId = 1;

        private static readonly List<Cliente> Clientes = new List<Cliente>();
        private static readonly List<Repartidor> Repartidores = new List<Repartidor>();
        private static readonly List<Paquete> Paquetes = new List<Paquete>();
        private static readonly List<Vehiculo> Vehiculos = new List<Vehiculo>();
        private static readonly List<Entrega> Entregas = new List<Entrega>();
        private static int _vehiculoId = 1;

        private static readonly string PersistFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ProyectoGoXela");
        private static readonly string PersistFile = Path.Combine(PersistFolder, "store.json");

        private class PersistedData
        {
            public List<Cliente> Clientes { get; set; }
            public List<Repartidor> Repartidores { get; set; }
            public List<Paquete> Paquetes { get; set; }
            public List<Vehiculo> Vehiculos { get; set; }
            public List<Entrega> Entregas { get; set; }
        }

        public static Cliente AddCliente(Cliente c)
        {
            // validaciones
            if (c == null) throw new ValidationException("Cliente nulo");
            if (string.IsNullOrWhiteSpace(c.Nombre)) throw new ValidationException("Nombre de cliente obligatorio");
            if (Clientes.Any(x => string.Equals(x.Nombre, c.Nombre, StringComparison.OrdinalIgnoreCase))) throw new DuplicateCodeException("Ya existe un cliente con el mismo nombre");
            c.Id = _clienteId++;
            Clientes.Add(c);
            return c;
        }

        public static List<Cliente> GetClientes() => Clientes.ToList();

        public static Repartidor AddRepartidor(Repartidor r)
        {
            if (r == null) throw new ValidationException("Repartidor nulo");
            if (string.IsNullOrWhiteSpace(r.Nombre)) throw new ValidationException("Nombre de repartidor obligatorio");
            if (Repartidores.Any(x => string.Equals(x.Nombre, r.Nombre, StringComparison.OrdinalIgnoreCase))) throw new DuplicateCodeException("Ya existe un repartidor con el mismo nombre");
            r.Id = _repartidorId++;
            Repartidores.Add(r);
            return r;
        }

        public static List<Repartidor> GetRepartidores() => Repartidores.ToList();

        public static Paquete AddPaquete(Paquete p)
        {
            if (p == null) throw new ValidationException("Paquete nulo");
            if (string.IsNullOrWhiteSpace(p.Descripcion)) throw new ValidationException("Descripción de paquete obligatoria");
            if (p.PesoKg < 0) throw new ValidationException("Peso no puede ser negativo");
            if (Paquetes.Any(x => string.Equals(x.Descripcion, p.Descripcion, StringComparison.OrdinalIgnoreCase))) throw new DuplicateCodeException("Ya existe un paquete con la misma descripción");
            p.Id = _paqueteId++;
            Paquetes.Add(p);
            return p;
        }

        public static Vehiculo AddVehiculo(Vehiculo v)
        {
            if (v == null) throw new ValidationException("Vehículo nulo");
            if (string.IsNullOrWhiteSpace(v.Placa) && string.IsNullOrWhiteSpace(v.Modelo)) throw new ValidationException("Placa o modelo obligatorio");
            if (v.CapacidadKg < 0) throw new ValidationException("Capacidad no puede ser negativa");
            if (Vehiculos.Any(x => !string.IsNullOrWhiteSpace(v.Placa) && string.Equals(x.Placa, v.Placa, StringComparison.OrdinalIgnoreCase))) throw new DuplicateCodeException("Ya existe un vehículo con la misma placa");
            v.Id = _vehiculoId++;
            Vehiculos.Add(v);
            return v;
        }

        public static List<Vehiculo> GetVehiculos() => Vehiculos.ToList();

        public static List<Paquete> GetPaquetes() => Paquetes.ToList();

        public static Entrega AddEntrega(Entrega e)
        {
            if (e == null) throw new ValidationException("Entrega nula");
            if (e.Cliente == null) throw new ValidationException("Entrega debe tener un cliente");
            if (e.Paquete == null) throw new ValidationException("Entrega debe tener un paquete");
            if (e.DistanciaKm < 0) throw new ValidationException("Distancia no puede ser negativa");

            e.Id = _entregaId++;
            e.Fecha = DateTime.Now;
            if (e.FechaSolicitud == default(DateTime)) e.FechaSolicitud = DateTime.Now;

            e.Cliente.CantidadSolicitudes++;

            if (e.Incidencias == null) e.Incidencias = new List<Incidencia>();
            e.Estado = DeliveryStatus.Solicitada;

            if (e.DistanciaKm <= 0)
            {
                e.DistanciaKm = CostCalculator.EstimateDistanceKm(e.Origen, e.Destino);
            }

            CostCalculator.ApplyCosts(e);

            Entregas.Add(e);
            return e;
        }

        public static List<Entrega> GetEntregas() => Entregas.ToList();

        public static string GenerateReportCsv()
        {
            try
            {
                if (!Directory.Exists(PersistFolder)) Directory.CreateDirectory(PersistFolder);
                var file = Path.Combine(PersistFolder, $"report_entregas_{DateTime.Now:yyyyMMdd_HHmmss}.csv");
                using (var sw = new StreamWriter(file))
                {
                    sw.WriteLine("Id,Cliente,Repartidor,Vehiculo,TipoServicio,Estado,Total,FechaSolicitud");
                    foreach (var item in Entregas)
                    {
                        var line = string.Format("{0},\"{1}\",\"{2}\",\"{3}\",{4},{5},{6},{7}",
                            item.Id,
                            item.Cliente?.Nombre ?? "",
                            item.Repartidor?.Nombre ?? "",
                            item.Vehiculo ?? "",
                            item.TipoServicio,
                            item.Estado,
                            item.Total.ToString("F2"),
                            item.FechaSolicitud.ToString("o")
                        );
                        sw.WriteLine(line);
                    }
                }
                return file;
            }
            catch
            {
                return null;
            }
        }

        public static bool TryChangeEntregaState(int entregaId, DeliveryStatus newState, string user, out string message)
        {
            var e = Entregas.FirstOrDefault(x => x.Id == entregaId);
            if (e == null)
            {
                message = "Entrega no encontrada.";
                return false;
            }

            if (!DeliveryWorkflow.IsValidTransition(e.Estado, newState))
            {
                message = $"Transición inválida de {e.Estado} a {newState}.";
                return false;
            }

            var previous = e.Estado;
            e.Estado = newState;

            if (newState == DeliveryStatus.Reprogramada)
            {
                e.FechaSolicitud = DateTime.Now;
            }


            if (newState == DeliveryStatus.Entregada || newState == DeliveryStatus.Cancelada)
            {
                if (e.Repartidor != null) e.Repartidor.Disponible = true;

                var vehiculoAsignado = Vehiculos.FirstOrDefault(v =>
                        !string.IsNullOrWhiteSpace(v.Placa) && string.Equals(v.Placa, e.Vehiculo, StringComparison.OrdinalIgnoreCase))
                    ?? Vehiculos.FirstOrDefault(v => string.Equals(v.Tipo.ToString(), e.Vehiculo, StringComparison.OrdinalIgnoreCase));
                if (vehiculoAsignado != null) vehiculoAsignado.Disponible = true;
            }

            if (newState == DeliveryStatus.Entregada && e.Repartidor != null)
            {
                e.Repartidor.CantidadEntregasRealizadas++;
            }

            if (e.EstadoHistorial == null) e.EstadoHistorial = new List<StateChangeRecord>();

            var usr = string.IsNullOrEmpty(user) ? Environment.UserName : user;
            e.EstadoHistorial.Add(new StateChangeRecord
            {
                From = previous,
                To = newState,
                User = usr,
                Timestamp = DateTime.Now,
                Note = null
            });

            try { Save(); } catch { }
            message = null;
            return true;
        }

        public static List<DeliveryStatus> GetAllowedTransitions(DeliveryStatus from)
        {
            return DeliveryWorkflow.GetAllowedTransitions(from);
        }

        public static bool CalificarEntrega(int entregaId, int calificacion, out string message)
        {
            var e = Entregas.FirstOrDefault(x => x.Id == entregaId);
            if (e == null)
            {
                message = "Entrega no encontrada.";
                return false;
            }

            if (e.Estado != DeliveryStatus.Entregada)
            {
                message = "No se puede calificar una entrega que todavía no ha finalizado.";
                return false;
            }

            if (calificacion < 1 || calificacion > 5)
            {
                message = "La calificación debe estar entre 1 y 5.";
                return false;
            }

            e.Calificacion = calificacion;

            if (e.Repartidor != null)
            {
                var calificaciones = Entregas
                    .Where(x => x.Repartidor != null && x.Repartidor.Id == e.Repartidor.Id && x.Calificacion.HasValue)
                    .Select(x => x.Calificacion.Value)
                    .ToList();

                e.Repartidor.CalificacionPromedio = calificaciones.Any() ? Math.Round(calificaciones.Average(), 2) : 0;
            }

            try { Save(); } catch { }
            message = null;
            return true;
        }

        public static void Save()
        {
            try
            {
                if (!Directory.Exists(PersistFolder)) Directory.CreateDirectory(PersistFolder);
                var data = new PersistedData
                {
                    Clientes = Clientes.ToList(),
                    Repartidores = Repartidores.ToList(),
                    Paquetes = Paquetes.ToList(),
                    Vehiculos = Vehiculos.ToList(),
                    Entregas = Entregas.ToList()
                };

                var dllPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Newtonsoft.Json.dll");
                if (!File.Exists(dllPath)) dllPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "lib", "Newtonsoft.Json.dll");
                if (File.Exists(dllPath))
                {
                    var asm = Assembly.LoadFrom(dllPath);
                    var jsonConvertType = asm.GetType("Newtonsoft.Json.JsonConvert");
                    var formattingType = asm.GetType("Newtonsoft.Json.Formatting");
                    var indented = formattingType.GetField("Indented").GetValue(null);
                    var serializeMethod = jsonConvertType.GetMethod("SerializeObject", new Type[] { typeof(object), formattingType });
                    var json = (string)serializeMethod.Invoke(null, new object[] { data, indented });
                    File.WriteAllText(PersistFile, json);
                }
                else
                {
                }
            }
            catch
            {
            }
        }

        public static void Load()
        {
            try
            {
                if (!File.Exists(PersistFile)) return;

                var dllPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Newtonsoft.Json.dll");
                if (!File.Exists(dllPath)) dllPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "lib", "Newtonsoft.Json.dll");
                if (!File.Exists(dllPath)) return;

                var json = File.ReadAllText(PersistFile);
                var asm = Assembly.LoadFrom(dllPath);
                var jsonConvertType = asm.GetType("Newtonsoft.Json.JsonConvert");
                var deserializeMethod = jsonConvertType.GetMethod("DeserializeObject", new Type[] { typeof(string), typeof(Type) });
                var obj = deserializeMethod.Invoke(null, new object[] { json, typeof(PersistedData) }) as PersistedData;
                if (obj == null) return;

                Clientes.Clear();
                Repartidores.Clear();
                Paquetes.Clear();
                Entregas.Clear();

                if (obj.Clientes != null) Clientes.AddRange(obj.Clientes);
                if (obj.Repartidores != null) Repartidores.AddRange(obj.Repartidores);
                if (obj.Paquetes != null) Paquetes.AddRange(obj.Paquetes);
                if (obj.Vehiculos != null) Vehiculos.AddRange(obj.Vehiculos);
                if (obj.Entregas != null) Entregas.AddRange(obj.Entregas);

                _clienteId = Clientes.Any() ? Clientes.Max(x => x.Id) + 1 : 1;
                _repartidorId = Repartidores.Any() ? Repartidores.Max(x => x.Id) + 1 : 1;
                _paqueteId = Paquetes.Any() ? Paquetes.Max(x => x.Id) + 1 : 1;
                _vehiculoId = Vehiculos.Any() ? Vehiculos.Max(x => x.Id) + 1 : 1;
                _entregaId = Entregas.Any() ? Entregas.Max(x => x.Id) + 1 : 1;
            }
            catch
            {

            }
        }

        public static void ResetData()
        {
            try
            {
                Clientes.Clear();
                Repartidores.Clear();
                Paquetes.Clear();
                Entregas.Clear();

                _clienteId = 1;
                _repartidorId = 1;
                _paqueteId = 1;
                _entregaId = 1;

                if (File.Exists(PersistFile))
                {
                    try { File.Delete(PersistFile); } catch { }
                }
            }
            catch
            {
            }
        }
    }

    public static class CostCalculator
    {
        private const double TarifaPorKm = 1.2; // moneda por km
        private const double RecargoUrgenteFactor = 0.20; // 20% si es urgente
        private const double RecargoPrioritarioFactor = 0.10; // 10% si es prioritario
        private const double RecargoPesoThreshold = 10.0; // kg
        private const double RecargoPesoFactor = 0.10; // 10% si peso > threshold
        private const double DescuentoPreferente = 0.10; // 10% si cliente preferente

        public static double EstimateDistanceKm(string origen, string destino)
        {
            if (string.IsNullOrWhiteSpace(origen) || string.IsNullOrWhiteSpace(destino))
                return 5.0;
            return 8.0; 
        }

        public static void ApplyCosts(Entrega e)
        {
            e.TarifaBase = Math.Round(TarifaPorKm * e.DistanciaKm, 2);

            double recargos = 0.0;
            double descuentos = 0.0;

            if (e.TipoServicio == ServiceType.Urgente)
            {
                recargos += e.TarifaBase * RecargoUrgenteFactor;
            }
            else if (e.TipoServicio == ServiceType.Prioritario)
            {
                recargos += e.TarifaBase * RecargoPrioritarioFactor;
            }

            if (e.Paquete != null && e.Paquete.PesoKg > RecargoPesoThreshold)
            {
                recargos += e.TarifaBase * RecargoPesoFactor;
            }

            if (e.Cliente != null && e.Cliente.EsPreferente)
            {
                descuentos += e.TarifaBase * DescuentoPreferente;
            }

            e.Recargos = Math.Round(recargos, 2);
            e.Descuentos = Math.Round(descuentos, 2);
            e.Total = Math.Round(e.TarifaBase + e.Recargos - e.Descuentos, 2);
        }
    }
}