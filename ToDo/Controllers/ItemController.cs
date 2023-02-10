using Microsoft.AspNetCore.Mvc;
using ToDo.Models;
using ToDo.Tools;
using ToDo_DAL.Interfaces;
using ToDo_DAL.Models;


namespace ToDo.Controllers
{
    [TypeFilter(typeof(ExceptionFilter))]
    public class ItemController : Controller
    {
        private readonly IItemRepository _repo;

        public ItemController(IItemRepository repo)
        {
            _repo = repo;
        }

        // Error handling (NOW DONE BY THE FILTER)
        //private ActionResult HandleException(Exception exception)
        //{
        //    ErrorViewModel error = new ErrorViewModel() { ErrorMessage = exception.Message, RequestId = Activity.Current!.Id };
        //    TempData["Error"] = JsonConvert.SerializeObject(error);
        //    return RedirectToAction(nameof(ShowError));
        //}
        //public IActionResult ShowError()
        //{
        //    if (TempData["Error"] is not null)
        //    {
        //        ErrorViewModel error = JsonConvert.DeserializeObject<ErrorViewModel>((string)TempData["Error"]!)!;
        //        return View(error);
        //    }
        //    return View(new ErrorViewModel() { ErrorMessage = "REEEEEEEEEEEEEE!!!!!!!" });
        //}

        // GET: ItemController
        public ActionResult Index()
        {
            return View(_repo.GetAll());
            //try
            //{
            //    return View(_repo.GetAll());
            //}
            //catch (Exception exception)
            //{
            //    return HandleException(exception);
            //}
        }

        // GET: ItemController/Details/5
        public ActionResult Details(int id)
        {
            Item? item = _repo.GetById(id);
            if (item is not null)
            {
                return View(item);
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: ItemController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ItemController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ItemForm itemForm)
        {
            if (!ModelState.IsValid) 
                return View(itemForm);

            Item item = itemForm.MapItem();
            if (_repo.Create(item) is not null)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError("", "Something went wrong...");
                return View(itemForm);
            }
        }

        // GET: ItemController/Edit/5
        public ActionResult Edit(int id)
        {
            Item? item = _repo.GetById(id);

            if (item is not null)
            {
                ItemForm itemForm = item.MapItemForm();
                return View(itemForm);  
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: ItemController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ItemForm itemForm)
        {
            if (!ModelState.IsValid) 
                return View(itemForm);
            if (id != itemForm.Id)
                return RedirectToAction(nameof(Index));

            Item item = itemForm.MapItem();
            if (_repo.Update(item) is not null)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
            ModelState.AddModelError("", "Something went wrong...");
            return View(itemForm);
            }
        }

        // POST : ItemController/Toggle/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Toggle(int id, IFormCollection collection)
        {
            if (_repo.Toggle(id) is not null)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError("", "Something went wrong...");
                return View();
            }
        }

        // GET: ItemController/Delete/5
        public ActionResult Delete(int id)
        {
            Item? item = _repo.GetById(id);

            if (item is not null)
            {
                return View(item);
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: ItemController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            if (_repo.Delete(id) is not null)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError("", "Something went wrong...");
                return View();
            }
        }
    }
}
