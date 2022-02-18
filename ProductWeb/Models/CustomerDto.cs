using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductWeb.Models
{
    public class CustomerDto
    {
        /// <summary>
        /// Customer id
        /// </summary>
        /// <example>1</example>
        public int CustomerId { get; set; }
        /// <summary>
        /// Product id
        /// </summary>
        /// <example>12</example>
        [Required]
        [Range(1, 100)]
        public int ProductId { get; set; }
        /// <summary>
        /// Employer id
        /// </summary>
        /// <example>0116474998</example>
        [Required]
        [StringLength(10)]
        public string EmployerId { get; set; }
        /// <summary>
        /// Customer name
        /// </summary>
        /// <example>Edenred México, S.A. de C.V.</example>
        [Required]
        [StringLength(34)]
        public string Name { get; set; }
        /// <summary>
        /// RFC
        /// </summary>
        /// <example>SAC900418EN9</example>
        [Required]
        [StringLength(13)]
        public string RFC { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        /// <example>angel.javier@edenred.com</example>
        [Required]
        [StringLength(70)]
        [EmailAddress]
        public string Email { get; set; }
    }
}
