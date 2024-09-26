using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GameZone.Controllers
{
    public class GamesController : Controller
    {
        private readonly ICategoriesService _categoriesService;
        private readonly IDevicesService _devicesService;
        private readonly IGamesService _gamesService;
        private readonly IMapper _mapper;
		public GamesController(ICategoriesService categoriesService, IDevicesService devicesService, IGamesService gamesService , IMapper mapper)
		{
			_categoriesService = categoriesService;
			_devicesService = devicesService;
			_gamesService = gamesService;
            _mapper = mapper;
		}

        public IActionResult Index()
        {
            IEnumerable<Game> games = _gamesService.GetAll();
            return View(games);
        }

        public IActionResult Details(int id)
        {
            var game = _gamesService.GetById(id);
            if (game is null) return NotFound();
            return View(game);
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateGameFormViewModel viewModel = new CreateGameFormViewModel()
            {
                Categories = _categoriesService.GetCategoriesList(),
                Devices =_devicesService.GetDevicesList(),
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(CreateGameFormViewModel model)
        {
            if(ModelState.IsValid)
            {
                await _gamesService.Save(model);
				return RedirectToAction(nameof(Index));
			}
            model.Categories = _categoriesService.GetCategoriesList();
            model.Devices = _devicesService.GetDevicesList();
			return View(nameof(Create), model);
        }

        public IActionResult Update(int id)
        {
            var game = _gamesService.GetById(id);
            if (game is null) return NotFound();

            GameUpdateFormViewModel viewModel = _mapper.Map<GameUpdateFormViewModel>(game);
            viewModel.Categories = _categoriesService.GetCategoriesList();
            viewModel.Devices = _devicesService.GetDevicesList();
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveUpdate(GameUpdateFormViewModel model)
        {
            if(ModelState.IsValid)
            {
                var game = await _gamesService.SaveUpdate(model);
                if (game is null) return BadRequest();
                return RedirectToAction(nameof(Index));
            }
            model.Categories = _categoriesService.GetCategoriesList();
            model.Devices = _devicesService.GetDevicesList();
            return View(nameof(Update),model);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
           var isDeleted =  _gamesService.Delete(id);
            return isDeleted ? RedirectToAction(nameof(Index)) : BadRequest();
        }
    }
}
