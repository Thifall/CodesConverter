using CodesConverter.Models.Ciphers.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace CodesConverter.Models
{
    public class HomeViewModel : PageModel
    {
        public string TextToChange { get; set; }
        public IEnumerable<ICipher> Ciphers { get; set; }
        public string Result { get; set; }
        public string SelectedCipher { get; set; }
        public string Key { get; set; }
    }
}

