﻿using System.ComponentModel.DataAnnotations;

namespace API;

public class AppUser
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string UserName { get; set; }
    
}
