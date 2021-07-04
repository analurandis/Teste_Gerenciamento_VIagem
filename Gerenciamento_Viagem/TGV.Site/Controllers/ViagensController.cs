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
    public class ViagensController : Controller
    {
        private readonly TGVContext _context;

        public ViagensController(TGVContext context)
        {
            _context = context;
        }

        private void GerarViewBag(string Motorista = "", string Caminhao = "")
        {
            ViewBag.Motorista = new SelectList(_context.Motorista.OrderByDescending(p => p.Nome), "Codigo", "Nome", Motorista).Append(new SelectListItem("", "", true, true)).Reverse(); ;
            ViewBag.Caminhao = new SelectList(_context.Caminhao.OrderByDescending(p => p.Marca), "Codigo", "Marca", Caminhao).Append(new SelectListItem("", "", true, true)).Reverse(); ;

        }
    
        public async Task<IActionResult> Index()
        {
            return View(await _context.Viagem.Include(p => p.Caminhao).Include(p => p.Motoristas).ToListAsync());
        }

        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viagem = await _context.Viagem.Include(p => p.Caminhao).Include(p => p.Motoristas).FirstOrDefaultAsync(m => m.Codigo == id);
            if (viagem == null)
            {
                return NotFound();
            }

            return View(viagem);
        }

       
        public IActionResult Create()
        {
            GerarViewBag();
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Codigo,DataHora,LocalEntrega,LocalSaida,KmPercurso,MOTORISTA_CODIGO,CAMINHAO_CODIGO")] Viagem viagem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(viagem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            GerarViewBag(viagem.MOTORISTA_CODIGO.ToString(), viagem.CAMINHAO_CODIGO.ToString());

            return View(viagem);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viagem = await _context.Viagem.FindAsync(id);
            if (viagem == null)
            {
                return NotFound();
            }
            GerarViewBag(viagem.MOTORISTA_CODIGO.ToString(), viagem.CAMINHAO_CODIGO.ToString());

            return View(viagem);
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Codigo,DataHora,LocalEntrega,LocalSaida,KmPercurso,MOTORISTA_CODIGO,CAMINHAO_CODIGO")] Viagem viagem)
        {
            if (id != viagem.Codigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(viagem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ViagemExists(viagem.Codigo))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            GerarViewBag(viagem.MOTORISTA_CODIGO.ToString(), viagem.CAMINHAO_CODIGO.ToString());

            return View(viagem);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viagem = await _context.Viagem.Include(p=> p.Caminhao).Include(p=>p.Motoristas).FirstOrDefaultAsync(m => m.Codigo == id);
            if (viagem == null)
            {
                return NotFound();
            }

            return View(viagem);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var viagem = await _context.Viagem.FindAsync(id);
            _context.Viagem.Remove(viagem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ViagemExists(int id)
        {
            return _context.Viagem.Any(e => e.Codigo == id);
        }

        public List<Viagem> ViagensPendentes()
        {
            return _context.Viagem.Include(p => p.Caminhao).Include(p => p.Motoristas).Where(p => p.DataHora > DateTime.Now).ToList();
        }

        [HttpPost]
        [Route("/Viagem/Caminhao")]
        public IActionResult Caminhao(int id)
        {
            ViewBag.Caminhao = new SelectList(_context.Caminhao.Where(p=> p.MOTORISTA_CODIGO == id).OrderByDescending(p => p.Marca), "Codigo", "Marca").Append(new SelectListItem("", "", true, true)).Reverse(); ;
            return PartialView("SelectedCaminhoes");

        }

    }
}
