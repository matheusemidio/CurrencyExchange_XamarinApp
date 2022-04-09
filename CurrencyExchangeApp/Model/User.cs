using System;
using SQLite;

namespace CurrencyExchangeApp.Model
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(250)]
        public string FirstName { get; set; }

        [MaxLength(250)]
        public string LastName { get; set; }

        [MaxLength(250)]
        public string Email { get; set; }

        [MaxLength(250)]
        public string Password { get; set; }
    }

}
