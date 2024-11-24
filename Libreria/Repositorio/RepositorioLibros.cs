using Libreria.Models;
using Microsoft.EntityFrameworkCore;

namespace Libreria.Repositorio
{
    public class RepositorioLibros : IRepositorioLibros
    {
        private readonly DirectorioContext _context;

        public RepositorioLibros(DirectorioContext context)
        {
            _context = context;
        }

        public async Task<Libro> Add(Libro libro)
        {
            await _context.Libros.AddAsync(libro);
            await _context.SaveChangesAsync();
            return libro;
        }

        public async Task Delete(int id)
        {
            var libro = await _context.Libros.FindAsync(id);
            if (libro != null)
            {
                _context.Libros.Remove(libro);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Libro>> GetAll()
        {
            return await _context.Libros.ToListAsync();
        }

        public async Task<Libro?> Get(int id)
        {
            return await _context.Libros.FindAsync(id);
        }

        public async Task Update(int id, Libro libro)
        {
            var libroActual = await _context.Libros.FindAsync(id);
            if (libroActual != null)
            {
                libroActual.Titulo = libro.Titulo;
                libroActual.Autor = libro.Autor;
                libroActual.Categoria = libro.Categoria;
                libroActual.Precio = libro.Precio;
                libroActual.Stock = libro.Stock;
                libroActual.Nivel_minimo = libro.Nivel_minimo;

                await _context.SaveChangesAsync();
            }
        }
    }
}
