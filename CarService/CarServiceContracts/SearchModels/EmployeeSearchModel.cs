﻿namespace CarServiceContracts.SearchModels
{
    public class EmployeeSearchModel
    {
        public int? Id { get; set; }

        public string MId { get; set; }
        public string Phone { get; set; } = string.Empty;
    }
}