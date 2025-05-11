using Microsoft.AspNetCore.Mvc;
using PortalMaria.Models;
using PortalMaria.Services.Implementations;
using PortalMaria.Services.Interfaces;

namespace PortalMaria.Controllers
{
    public class HorarioAlunoController : Controller
    {
        private readonly IHorarioAlunoService _horarioAluno;
        public HorarioAlunoController(IHorarioAlunoService horarioAluno)
        {
            _horarioAluno = horarioAluno;
        }
        public async Task<IActionResult> Index(string search)
        {
            var horariosTodosAlunos = await _horarioAluno.ListarHorarioAlunos(search);
            return View(horariosTodosAlunos);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var aluno = await _horarioAluno.GetByIdAsync(id.Value);
            if (aluno == null) return NotFound();

            return View(aluno);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, HorarioAluno alunoHorario)
        {
            if (id != alunoHorario.Id) return NotFound();

            if (ModelState.IsValid)
            {
                await _horarioAluno.UpdateAsync(alunoHorario);
                return RedirectToAction(nameof(Index));
            }
            return View(alunoHorario);
        }
    }
}
