using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyAbp.EShop.Stores.Stores;
using EasyAbp.EShop.Stores.Stores.Dtos;
using EasyAbp.EShop.Stores.Web.Pages.EShop.Stores.Stores.Store.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Identity;

namespace EasyAbp.EShop.Stores.Web.Pages.EShop.Stores.Stores.Store
{
    public class CreateModalModel : StoresPageModel
    {
        [BindProperty]
        public CreateEditStoreViewModel Store { get; set; }

        public ICollection<SelectListItem> StoreOwners { get; set; }

        private readonly IStoreAppService _service;
        private readonly IIdentityUserAppService _userAppService;

        public CreateModalModel(IStoreAppService service,
            IIdentityUserAppService userAppService)
        {
            _service = service;
            _userAppService = userAppService;
        }

        public virtual async Task OnGetAsync()
        {
            StoreOwners =
                (await _userAppService.GetListAsync(new GetIdentityUsersInput
                { MaxResultCount = LimitedResultRequestDto.MaxMaxResultCount })).Items
                .Select(dto => new SelectListItem(dto.UserName, dto.Id.ToString())).ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var createDto = ObjectMapper.Map<CreateEditStoreViewModel, CreateUpdateStoreDto>(Store);
            var store = await _service.CreateAsync(createDto);

            return NoContent();
        }
    }
}