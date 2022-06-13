using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atividade.Models
{
    [Table("cadastro", Schema = "public")]
    public class DtoCadastro
    {
        [Key]
        public int id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string datanasc { get; set; }
        public string sexo { get; set; }
        public string rua { get; set; }
	    public int numero { get; set; }
	    public int cep { get; set; }
	    public string cidade { get; set; }
        public string estado { get; set; }
	    public string mensagem { get; set; }


    }
}
