using System;
using SQLite;

namespace CurrencyExchangeApp.Model
{
    public class Operation
    {
        [PrimaryKey, AutoIncrement]
        public int TransactionId { get; set; }

        [MaxLength(250)]
        public string UserId { get; set; }

        [MaxLength(250)]
        public string FromCurrency { get; set; }

        [MaxLength(250)]
        public string ToCurrency { get; set; }

        [MaxLength(250)]
        public string Amount { get; set; }

        [MaxLength(250)]
        public string Value { get; set; }

        [MaxLength(250)]
        public string Rate { get; set; }
    }
}
