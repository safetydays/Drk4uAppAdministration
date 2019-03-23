namespace Drk4uAppAdministration.Models {

    using System.ComponentModel.DataAnnotations;

    public enum Skillset {

        [Display(Name = "Führerscheinklasse B")]
        FuehrerscheinklasseB = 1,

        [Display(Name = "Führerscheinklasse C1")]
        FuehrerscheinklasseC1 = 2,

        [Display(Name = "Führerscheinklasse C")]
        FuehrerscheinklasseC = 3,

        [Display(Name = "Erste-Hilfe-Kurs")]
        ErsteHilfeKurs = 4,

        [Display(Name = "Sanitäter(in) (San A/B/C)")]
        Sanitaeterin = 5,

        [Display(Name = "Rettungshelfer(in)")]
        Rettungshelferin = 6,

        [Display(Name = "Rettungssanitäter(in)")]
        Rettungssanitaeterin = 7,

        [Display(Name = "Rettungsassistent(in)")]
        Rettungsassistent = 8,

        [Display(Name = "Notfallsanitäter(in)")]
        Notfallsanitaeterin = 9,

        [Display(Name = "Arzt/Ärztin")]
        Arztin = 10,

        [Display(Name = "Notarzt/Notärztin")]
        Notarztin = 11,

        [Display(Name = "Krankenpfleger(in)")]
        Krankenpflegerin = 12,

        [Display(Name = "Hebamme")]
        Hebamme = 13

    }

}