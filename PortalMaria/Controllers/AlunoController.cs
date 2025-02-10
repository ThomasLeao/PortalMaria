using Microsoft.AspNetCore.Mvc;
using PortalMaria.Data;
using PortalMaria.Models;

namespace PortalMaria.Controllers
{
    public class AlunoController : Controller 
    {
        private readonly ApplicationDbContext _context;
        public AlunoController(
            ApplicationDbContext context
            )
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string search)
        {
            var alunos = from a in _context.Alunos select a;
            if (!string.IsNullOrEmpty(search))
            {
                alunos = alunos.Where(a => a.Nome.Contains(search));
            }
            return View(alunos);
        }

        public IActionResult Create()
        {
            return View();
        }

        // Criar aluno (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aluno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aluno);
        }

        // Editar aluno (GET)
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null) return NotFound();

            return View(aluno);
        }

        // Editar aluno (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Aluno aluno)
        {
            if (id != aluno.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(aluno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aluno);
        }

        // Deletar aluno (GET)
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null) return NotFound();

            return View(aluno);
        }

        // Deletar aluno (POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno != null)
            {
                _context.Alunos.Remove(aluno);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
