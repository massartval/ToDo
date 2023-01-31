using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using ToDo.Models;
using ToDo.Tools;
using ToDo_DAL.Interfaces;
using ToDo_DAL.Models;


namespace ToDo.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemRepository _repo;

        public ItemController(IItemRepository repo)
        {
            _repo = repo;
        }

        // Error handling
        private ActionResult HandleException(Exception exception)
        {
            ErrorViewModel error = new ErrorViewModel() { ErrorMessage = exception.Message, RequestId = Activity.Current!.Id };
            TempData["Error"] = JsonConvert.SerializeObject(error);
            return RedirectToAction(nameof(ShowError));
        }
        public IActionResult ShowError()
        {
            if (TempData["Error"] is not null)
            {
                ErrorViewModel error = JsonConvert.DeserializeObject<ErrorViewModel>((string)TempData["Error"]!)!;
                return View(error);
            }
            return View(new ErrorViewModel() { ErrorMessage = "REEEEEEEEEEEEEE!!!!!!!" });
        }

        // GET: ItemController
        public ActionResult Index()
        {
            try
            {
                return View(_repo.GetAll());
            }
            catch (Exception exception)
            {
                return HandleException(exception);
            }
        }

        // GET: ItemController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                return View(_repo.GetById(id));
            }
            catch (Exception exception)
            {
                return HandleException(exception);
            }
        }

        // GET: ItemController/Create
        public ActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception exception)
            {
                return HandleException(exception);
            }
        }

        // POST: ItemController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ItemForm itemForm)
        {
            try
            {
                if (!ModelState.IsValid) 
                    return View(itemForm);

                Item item = itemForm.MapItem();
                _repo.Create(item);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception exception)
            {
                return HandleException(exception);
            }
        }

        // GET: ItemController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                Item item = _repo.GetById(id);
                ItemForm itemForm = item.MapItemForm();
                return View(itemForm);
            }
            catch (Exception exception)
            {
                return HandleException(exception);
            }
        }

        // POST: ItemController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ItemForm itemForm)
        {
            try
            {
                if (!ModelState.IsValid) 
                    return View(itemForm);

                Item item = itemForm.MapItem();
                _repo.Update(item);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception exception)
            {
                return HandleException(exception);
            }
        }

        // POST : ItemController/Toggle/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Toggle(int id, IFormCollection collection)
        {
            try
            {
                Item item = _repo.GetById(id);
                item.IsCompleted = (item.IsCompleted == true) ? item.IsCompleted = false : item.IsCompleted = true;
                _repo.Update(item);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception exception)
            {
                return HandleException(exception);
            }
        }

        // GET: ItemController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                Item item = _repo.GetById(id);
                return View(item);
            }
            catch (Exception exception)
            {
                return HandleException(exception);
            }
        }

        // POST: ItemController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _repo.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception exception)
            {
                return HandleException(exception);
            }
        }
    }
}
