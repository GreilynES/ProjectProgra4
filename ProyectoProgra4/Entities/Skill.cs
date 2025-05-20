using ProyectoProgra4.Entities;
using System.Text.Json.Serialization;

public class Skill
{
    [JsonIgnore]
    public int Id { get; set; }
    public string Name { get; set; }

    [JsonIgnore]
    public List<OfferSkill>? OfferSkills { get; set; } //una skill tiene una lista de ofertas
    [JsonIgnore]
    public List<CandidateSkill>? CandidateSkills { get; set; } //una skill tiene una lista de candidatos
}