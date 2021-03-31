using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using SoftJail.Data.Models;

namespace SoftJail.DataProcessor.ImportDto
{
    public class DepartmentCellInputModel
    {
        // •	Name – text with min length 3 and max length 25 (required)

        [Required]
        [StringLength(25, MinimumLength = 3)]
        public string Name { get; set; }
        public ICollection<CellInputModel> Cells { get; set; }
    }

    public class CellInputModel
    {
        // •	CellNumber – integer in the range [1, 1000] (required)
        // •	HasWindow – bool (required)

        [Required]
        [Range(1, 1000)]
        public int CellNumber { get; set; }

        [Required]
        public bool HasWindow { get; set; }
    }
}


// {
// "Name": "",
// "Cells": [
// {
// "CellNumber": 101,
// "HasWindow": true
// },
// {
// "CellNumber": 102,
// "HasWindow": false
// }
// ]
// },