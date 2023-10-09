

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using System.Net.NetworkInformation;

namespace hospitalVm
{

    public class RoleViewModel
    {
        
            public string? roleId { get; set; }
            public string? roleName { get; set; }
            public bool useRole { get; set; }
        
    }
}