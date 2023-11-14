using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TaxStrategy.Domain.Entities
{
    [Table("TaxStrategyFilho")]
    public class TaxStrategyFilho
    {
        public TaxStrategyFilho(int id, int idTaxStrategyPai, string titulo, string descricao, string estado)
        {
            Id = id;
            IdTaxStrategyPai = idTaxStrategyPai;
            Titulo = titulo;
            Descricao = descricao;
            Estado = estado;
        }

        [Key]
        public int Id { get; set; }
        public int IdTaxStrategyPai { get; set; }
        [ForeignKey("IdTaxStrategyPai")]
        [JsonIgnore]
        public virtual TaxStrategyPai? TaxStrategyPai { get; set; }
        [Column(TypeName = "VARCHAR(50)")]
        public string Titulo { get; set; } = string.Empty;
        [Column(TypeName = "VARCHAR(500)")]
        public string Descricao { get; set; } = string.Empty;
        [Column(TypeName = "VARCHAR(12)")]
        public string Estado { get; set; } = "pendente";
    }
}
