using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortalMaria.Models;
using PortalMaria.Services.Interfaces;

namespace PortalMaria.Controllers
{
    public class AlunoController : Controller
    {
        private readonly IAlunoService _alunoService;
        private readonly IHorarioAlunoService _horarioAluno;

        public AlunoController(IAlunoService alunoService, IHorarioAlunoService horarioAluno)
        {
            _alunoService = alunoService;
            _horarioAluno = horarioAluno;
        }

        public async Task<IActionResult> Index(string search)
        {
            var alunos = await _alunoService.GetAllAsync(search);
            return View(alunos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Aluno aluno)
        {
            if (ModelState.IsValid) 
            {
                await _alunoService.CreateAsync(aluno);

                var horario = new HorarioAluno
                {
                    IdAluno = aluno.Id,
                    NomeAluno = aluno.Nome,
                    CriadoEm = DateTime.Now,
                    Status = "Ativo"
                };
                await _horarioAluno.CreateAsync(horario);

                return RedirectToAction(nameof(Index));
            }
            
            return View(aluno);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var aluno = await _alunoService.GetByIdAsync(id.Value);
            if (aluno == null) return NotFound();

            return View(aluno);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Aluno aluno)
        {
            if (id != aluno.Id) return NotFound();

            if (ModelState.IsValid)
            {
                await _alunoService.UpdateAsync(aluno);
                return RedirectToAction(nameof(Index));
            }
            return View(aluno);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var aluno = await _alunoService.GetByIdAsync(id.Value);
            if (aluno == null) return NotFound();

            return View(aluno);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            await _horarioAluno.DeleteAsync(id);
            await _alunoService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
