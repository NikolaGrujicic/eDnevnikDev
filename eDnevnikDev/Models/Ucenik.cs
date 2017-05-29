﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eDnevnikDev.Models
{
    /// <summary>
    /// This is the Ucenik class
    /// </summary>
    public class Ucenik
    {
        /// <summary>
        /// Gets or sets the ucenik identifier
        /// Primary key u bazi.
        /// </summary>
        /// <value>
        /// The ucenik identifier.
        /// </value>
        public int UcenikID { get; set; }

        /// <summary>
        /// Gets or sets the IME.
        /// Sluzi za cuvanje imena ucenika.
        /// </summary>
        /// <value>
        /// The IME.
        /// </value>
        [Required(AllowEmptyStrings =false, ErrorMessage ="Polje za ime je obavezno")]
        [RegularExpression(@"^([A-ZŠĐČĆŽ]{1}[a-zšđčćž]+ ?)+$", ErrorMessage ="Polje za ime može da sadrži samo slova i mora da počinje velikim slovom")]
        public string Ime { get; set; }

        /// <summary>
        /// Gets or sets the prezime.
        /// Sluzi za cuvanje prezime ucenika.
        /// </summary>
        /// <value>
        /// The prezime.
        /// </value>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Polje za prezime je obavezno")]
        [RegularExpression(@"^([A-ZŠĐČĆŽ]{1}[a-zšđčćž]+ ?)+$", ErrorMessage = "Polje za prezime može da sadrži samo slova i mora da počinje velikim slovom")]
        public string Prezime { get; set; }
        /// <summary>
        /// Gets or sets the JMBG.
        /// Sluzi za cuvanje JMBG ucenika.
        /// </summary>
        /// <value>
        /// The JMBG.
        /// </value>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Polje za JMBG je obavezno")]
        [RegularExpression("(0[1-9]|[12][0-9]|3[01])(0[1-9]|1[012])[0|9][0-9]{2}[0-9]{6}", ErrorMessage = "JMBG nije ispravan")]
        public string JMBG { get; set; }

        /// <summary>
        /// Gets or sets the adresa.
        /// Sluzi za cuvanje adrese ucenika.
        /// </summary>
        /// <value>
        /// The adresa.
        /// </value>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Polje za adresu je obavezno")]
        [RegularExpression(@"^[A-Za-z0-9'\.\-\s\,]+$",ErrorMessage ="Nisu dozoljeni specijalni karakteri")]
        public string Adresa { get; set; }

        /// <summary>
        /// Gets or sets the roditelj staratelj.
        /// Sluzi za cuvanje ime Roditelja ili Staratelja ucenika.
        /// </summary>
        /// <value>
        /// The roditelj staratelj.
        /// </value>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Polje za roditelja/staratelja je obavezno")]
        [RegularExpression(@"^([A-ZŠĐČĆŽ]{1}[a-zšđčćž]+ ?)+$", ErrorMessage = "Ime roditelja nije ispravno (Prvo slovo mora biti veliko)")]
        public string RoditeljStaratelj { get; set; }

    }
}