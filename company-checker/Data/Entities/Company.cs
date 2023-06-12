﻿using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Company
    {
        [Key]
        public Guid Id { get; set; }
        public string? Regon { get; set; }
        public string? Nip { get; set; }
        public DateTime? RestorationDate { get; set; }
        public string? WorkingAddress { get; set; }
        public bool? HasVirtualAccounts { get; set; }
        public string? StatusVat { get; set; }
        public string? Krs { get; set; }
        public string? RestorationBasis { get; set; }
        public virtual ICollection<BankAccount>? AccountNumbers { get; set; }
        public string? RegistrationDenialBasis { get; set; }
        public DateTime? RemovalDate { get; set; }
        public string? Name { get; set; }
        public DateTime? RegistrationLegalDate { get; set; }
        public string? RemovalBasis { get; set; }
        public string? Pesel { get; set; }
        public virtual ICollection<Representative>? Representatives { get; set; }
        public string? ResidenceAddress { get; set; }
        public string? RegistrationDenialDate { get; set; }
        public DateTime? RequestDateTime { get; set; }
        public string? RequestId { get; set; }
    }
}
