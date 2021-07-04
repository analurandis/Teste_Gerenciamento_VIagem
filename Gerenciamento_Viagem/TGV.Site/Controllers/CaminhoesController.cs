using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TGV.DataAcess.Entity.Context;
using TGV.Model;

namespace TGV.Site.Controllers
{
    public class CaminhoesController : Controller
    {
        private readonly TGVContext _context;

        public CaminhoesController(TGVContext context)
        {
            _context = context;
        }

        public async void gerarViewBag(int id)
        {
            ViewBag.Motorista = await _context.Motorista.FirstOrDefaultAsync(p => p.Codigo == id);
        }

        // GET: Caminhoes
        public async Task<IActionResult> Index(int id)
        {
            gerarViewBag(id);
            return View(await _context.Caminhao.Include(p=> p.Motorista).Where(p=> p.MOTORISTA_CODIGO == id).ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caminhao = await _context.Caminhao.Include(p=> p.Motorista).FirstOrDefaultAsync(m => m.Codigo == id);
            if (caminhao == null)
            {
                return NotFound();
            }

            return PartialView(caminhao);
        }

        // GET: Caminhoes/Create
        public IActionResult Create(int id)
        {
            gerarViewBag(id);
            return PartialView();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Marca,Modelo,Placa,Eixo,Peso,MOTORISTA_CODIGO")] Caminhao caminhao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(caminhao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { id = caminhao.MOTORISTA_CODIGO});
            }
            return View(caminhao);
        }

        // GET: Caminhoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caminhao = await _context.Caminhao.Include(p=> p.Motorista).FirstOrDefaultAsync(p=> p.Codigo == id);
            if (caminhao == null)
            {
                return NotFound();
            }
            return PartialView(caminhao);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Codigo,Marca,Modelo,Placa,Eixo,Peso,MOTORISTA_CODIGO")] Caminhao caminhao)
        {
            if (id != caminhao.Codigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(caminhao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CaminhaoExists(caminhao.Codigo))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { id = caminhao.MOTORISTA_CODIGO });
            }
            return View(caminhao);
        }

        // GET: Caminhoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caminhao = await _context.Caminhao.Include(p => p.Motorista).FirstOrDefaultAsync(p => p.Codigo == id);
            if (caminhao == null)
            {
                return NotFound();
            }

            return PartialView(caminhao);
        }

        // POST: Caminhoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var caminhao = await _context.Caminhao.FindAsync(id);
            _context.Caminhao.Remove(caminhao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { id = caminhao.MOTORISTA_CODIGO });
        }

        private bool CaminhaoExists(int id)
        {
            return _context.Caminhao.Any(e => e.Codigo == id);
        }
    }
}
