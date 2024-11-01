using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Models
{
    public enum District
    {
        Norte = 0,
        Sur = 1,
        Este = 2,
        Oeste = 3
    }
}
