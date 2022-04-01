using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Licenta.Models
{
    public class Recipie
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name {
            get
            {
                return Name;
            }
            set
            {

            }
        }
        public string Ingredients { get; set; }
        public string Calories { get; set; }
    }
}
