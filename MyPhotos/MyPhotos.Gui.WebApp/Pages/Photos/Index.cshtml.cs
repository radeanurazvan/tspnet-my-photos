using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace MyPhotos.Gui.WebApp.Pages.Photos
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IEnumerable<FileAttributeDto> Attributes { get; private set; }

        public async Task OnGet()
        {
            var client = new MyPhotosFacadeClient();
            Attributes = await client.GetAllAttributesValuesAsync();
        }
    }
}
