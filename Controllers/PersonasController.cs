<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Authorization;
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
>>>>>>> 8beaa19510cdd363cf74b1b20e44112eee93838a
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OzzyWeb1.Models;
<<<<<<< HEAD
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzzyWeb1.Controllers
{
    [Authorize]
=======

namespace OzzyWeb1.Controllers
{
>>>>>>> 8beaa19510cdd363cf74b1b20e44112eee93838a
    public class PersonasController : Controller
    {
        private readonly SabormasterclassContext _context;

        public PersonasController(SabormasterclassContext context)
        {
            _context = context;
        }

        // GET: Personas
        public async Task<IActionResult> Index()
        {
            var sabormasterclassContext = _context.Personas.Include(p => p.IdRolNavigation);
            return View(await sabormasterclassContext.ToListAsync());
        }

        // GET: Personas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persona = await _context.Personas
                .Include(p => p.IdRolNavigation)
                .FirstOrDefaultAsync(m => m.IdPersona == id);
            if (persona == null)
            {
                return NotFound();
            }

            return View(persona);
        }

        // GET: Personas/Create
        public IActionResult Create()
        {
            ViewData["IdRol"] = new SelectList(_context.Rols, "IdRol", "IdRol");
            return View();
        }

        // POST: Personas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPersona,NoDocumento,TipoDocumento,Genero,NombrePersona,EmailPersona,DireccionPersona,TelefonoPersona,IdRol,Contraseña")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                _context.Add(persona);
                int v = await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdRol"] = new SelectList(_context.Rols, "IdRol", "IdRol", persona.IdRol);
            return View(persona);
        }

        // GET: Personas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persona = await _context.Personas.FindAsync(id);
            if (persona == null)
            {
                return NotFound();
            }
            ViewData["IdRol"] = new SelectList(_context.Rols, "IdRol", "IdRol", persona.IdRol);
            return View(persona);
        }

        // POST: Personas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPersona,NoDocumento,TipoDocumento,Genero,NombrePersona,EmailPersona,DireccionPersona,TelefonoPersona,IdRol,Contraseña")] Persona persona)
        {
            if (id != persona.IdPersona)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(persona);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonaExists(persona.IdPersona))
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
            ViewData["IdRol"] = new SelectList(_context.Rols, "IdRol", "IdRol", persona.IdRol);
            return View(persona);
        }

        // GET: Personas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persona = await _context.Personas
                .Include(p => p.IdRolNavigation)
                .FirstOrDefaultAsync(m => m.IdPersona == id);
            if (persona == null)
            {
                return NotFound();
            }

            return View(persona);
        }

        // POST: Personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var persona = await _context.Personas.FindAsync(id);
            if (persona != null)
            {
                _context.Personas.Remove(persona);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonaExists(int id)
        {
            return _context.Personas.Any(e => e.IdPersona == id);
        }
    }
}
