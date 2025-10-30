using Microsoft.AspNetCore.Mvc;
using InMemoryTaskManagement.Services;
using TaskModel = InMemoryTaskManagement.Models.Task;

namespace InMemoryTaskManagement.Controllers
{
    public class TasksController : Controller
    {
        private readonly ITaskService taskService;

        public TasksController(ITaskService taskService)
        {
            this.taskService = taskService;
        }

        // GET: /Tasks
        public IActionResult Index()
        {
            var tasks = taskService.GetAll();
            return View(tasks);
        }

        // GET: /Tasks/Details/5
        public IActionResult Details(int id)
        {
            TaskModel? task = taskService.GetById(id);
            if (task == null) return NotFound();
            return View(task);
        }

        // GET: /Tasks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Tasks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TaskModel task)
        {
            if (ModelState.IsValid)
            {
                taskService.Add(task);
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }

        // GET: /Tasks/Edit/5
        public IActionResult Edit(int id)
        {
            TaskModel? task = taskService.GetById(id);
            if (task == null) return NotFound();
            return View(task);
        }

        // POST: /Tasks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TaskModel task)
        {
            if (ModelState.IsValid)
            {
                taskService.Update(task);
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }

        // GET: /Tasks/Delete/5
        public IActionResult Delete(int id)
        {
            TaskModel? task = taskService.GetById(id);
            if (task == null) return NotFound();
            return View(task);
        }

        // POST: /Tasks/Delete/5 Confirmed
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            taskService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
