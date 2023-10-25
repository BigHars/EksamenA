using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WoodPelletsLib
{
    public class WoodPelletRepository
    {
        #region instance field
        private int _nextId = 1;
        private readonly List<WoodPellet> _woodPelletList = new();
        #endregion

        #region new list of wood pellets
        public WoodPelletRepository()
        {
            _woodPelletList.Add(new WoodPellet() { Id = _nextId++, Brand = "BioWood", Price = 4995, Quality = 4 });
            _woodPelletList.Add(new WoodPellet() { Id = _nextId++, Brand = "BioWood", Price = 5195, Quality = 4 });
            _woodPelletList.Add(new WoodPellet() { Id = _nextId++, Brand = "BilligePille", Price = 4125, Quality = 1 });
            _woodPelletList.Add(new WoodPellet() { Id = _nextId++, Brand = "GoldenWoodPellet", Price = 5995, Quality = 5 });
            _woodPelletList.Add(new WoodPellet() { Id = _nextId++, Brand = "GoldenWoodPellet", Price = 5795, Quality = 5 });
        }
        #endregion

        #region methods
        public IEnumerable<WoodPellet> GetAll()
        {
            IEnumerable<WoodPellet> _newList = new List<WoodPellet>(_woodPelletList);
            return _newList;
        }

        public WoodPellet? Add(WoodPellet woodPellet)
        {
            try
            {
                woodPellet.Brand = woodPellet.Brand;
                woodPellet.Price = woodPellet.Price;
                woodPellet.Quality = woodPellet.Quality;

                woodPellet.Id = _nextId++;
                _woodPelletList.Add(woodPellet);

                return woodPellet;
            } catch (ArgumentOutOfRangeException)
            {
                return null;
            }
        }

        public WoodPellet? GetById(int id)
        {
            WoodPellet woodPellet = _woodPelletList.FirstOrDefault(w => w.Id == id);

            if (woodPellet == null)
            {
                throw new KeyNotFoundException($"");
            }

            return woodPellet;
        }

        public WoodPellet? Update(int id, WoodPellet woodPellet)
        {
            WoodPellet? existingPellet = GetById(id);
            if (existingPellet == null)
            {
                throw new KeyNotFoundException($"");
            }

            existingPellet.Brand = woodPellet.Brand;
            existingPellet.Price = woodPellet.Price;
            existingPellet.Quality = woodPellet.Quality;
            existingPellet.Id = id;

            return existingPellet;
        }
        #endregion
    }
}
