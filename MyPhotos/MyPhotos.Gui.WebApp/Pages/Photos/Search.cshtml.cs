using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyPhotos.Gui.WebApp.Pages.Photos
{
    public class SearchModel : PageModel
    {
        public string Keyword { get; private set; }

        public IEnumerable<FileDto> Files { get; private set; }

        public async Task OnGet()
        {
            var client = new MyPhotosFacadeClient();

            Keyword = Request.Query[nameof(Keyword)];
            Files = string.IsNullOrEmpty(Keyword?.Trim())
                ? await client.GetPhotosAsync()
                : await client.FindByKeywordAsync(Keyword);
        }
    }
}
