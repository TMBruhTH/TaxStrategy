using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TaxStrategy.Domain.Entities
{
    [Table("TaxStrategyPai")]
    public class TaxStrategyPai
    {
        public TaxStrategyPai(int id, string titulo, string descricao, string estado, DateTime dthCricao, DateTime? dthConclusao)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            Estado = estado;
            DthCricao = dthCricao;
            DthConclusao = dthConclusao;
        }

        [Key]
        public int Id { get; set; }
        [Column(TypeName = "VARCHAR(50)")]
        public string Titulo { get; set; }
        [Column(TypeName = "VARCHAR(500)")]
        public string Descricao { get; set; }
        [Column(TypeName = "VARCHAR(12)")]
        public string Estado { get; set; } = "pendente";
        [Column(TypeName = "DATETIME")]
        public DateTime DthCricao { get; set; }
        [Column(TypeName = "DATETIME")]
        public DateTime? DthConclusao { get; set; }
    }
}
