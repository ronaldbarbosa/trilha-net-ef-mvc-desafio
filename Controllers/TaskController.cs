using Microsoft.AspNetCore.Mvc;
using trilha_net_ef_mvc_desafio.Context;

namespace trilha_net_ef_mvc_desafio.Controllers
{
    public class TaskController : Controller
    {
        private readonly ScheduleContext _context;

        public TaskController (ScheduleContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var tasks = _context.Tasks.ToList();
            return View(tasks);
        }

        public IActionResult Details(int id)
        {
            var task = _context.Tasks.Find(id);

            if (task == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(task);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Models.Task task)
        {
            if (ModelState.IsValid)
            {
                _context.Tasks.Add(task);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }

        public IActionResult ChangeStatus(int id)
        {
            var task = _context.Tasks.Find(id);

            if (task == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }

        [HttpPost]
        public IActionResult ChangeStatus(Models.Task task)
        {
            var taskDb = _context.Tasks.Find(task.Id);
            if (taskDb == null)
            {
                return RedirectToAction(nameof(Index));
            }

            taskDb.Status = task.Status;

            _context.Tasks.Update(taskDb);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var task = _context.Tasks.Find(id);

            if (task == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(task);
        }

        [HttpPost]
        public IActionResult Edit(Models.Task task)
        {
            var taskDb = _context.Tasks.Find(task.Id);
            
            if (taskDb == null)
            {
                return RedirectToAction(nameof(Index));
            }

            taskDb.Title = task.Title;
            taskDb.Description = task.Description;
            taskDb.Date = task.Date;
            taskDb.Status = task.Status;

            _context.Tasks.Update(taskDb);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}