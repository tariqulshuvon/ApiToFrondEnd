using Employee.Shared;
using Employee.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Employee.Model;

public class Country :BaseAuditableEntity,IEntity
{
    /// <summary>
    /// Id
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Country Name
    /// </summary>
    public string? CountryName { get; set; }
    /// <summary>
    /// Currency
    /// </summary>
    public string? Currency { get; set; }


    [JsonIgnore]
    public ICollection<Employees> Employees { get; set; } = new HashSet<Employees>();
    [JsonIgnore]
    public ICollection<State> State { get; set; } = new HashSet<State>();
}
