using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactsLib
{
    public class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ContactNo { get; set; }
        public string ContactName { get; set; }
        public string City { get; set; }
        public string CellNo { get; set; }

    }
}