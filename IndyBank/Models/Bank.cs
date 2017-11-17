using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndyBank.Models
{
    public class Bank
    {
        public string Name { get; set; }
        public List<Account> Accounts { get; set; }
    }
}
