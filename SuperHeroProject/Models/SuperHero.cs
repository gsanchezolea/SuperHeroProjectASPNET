﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHeroProject.Models
{
    public class SuperHero
    {
        [Key]
        public int Id { get; set; }
        public  string Name { get; set; }
        public string AlterEgo { get; set; }
        public string PrimaryAbility { get; set; }
        public string SecondaryHeroProperty { get; set; }
        public string  CatchPhrase { get; set; }

    }
}
