using Microsoft.AspNetCore.Mvc;
using trilha_net_ef_mvc_desafio.Context;
using trilha_net_ef_mvc_desafio.Models.Enums;

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

        public IActionResult GetById([FromForm] int id)
        {
            var task = _context.Tasks.Find(id);
            if (task == null)
            {
                return RedirectToAction(nameof(NoValueReturned));
            }
            return View(task);
        }

        public IActionResult GetByTitle([FromForm] string title)
        {
            var tasks = _context.Tasks.Where(task => task.Title.Contains(title));
            if (tasks == null || tasks.Count() == 0)
            {
                return RedirectToAction(nameof(NoValueReturned));
            }
            return View(tasks);
        }

        public IActionResult GetByDate([FromForm] DateTime date)
        {
            var tasks = _context.Tasks.Where(task => task.Date.Date == date.Date);
            if (tasks == null || tasks.Count() == 0)
            {
                return RedirectToAction(nameof(NoValueReturned));
            }
            return View(tasks);
        }

        public IActionResult GetByStatus([FromForm] TaskStatusEnum status)
        {
            var tasks = _context.Tasks.Where(task => task.Status == status);
            if (tasks == null || tasks.Count() == 0)
            {
                return RedirectToAction(nameof(NoValueReturned));
            }
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

        [HttpGet("Task/Create")]
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

        public IActionResult Delete(int id)
        {
            var task = _context.Tasks.Find(id);

            if (task == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(task);
        }

        [HttpPost]
        public IActionResult Delete(Models.Task task)
        {
            var taskDb = _context.Tasks.Find(task.Id);

            if (taskDb == null)
            {
                return RedirectToAction(nameof(Index));
            }

            _context.Tasks.Remove(taskDb);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Task/NoValueReturned")]
        public IActionResult NoValueReturned()
        {
            return View();
        }
    }
}