using MeasurementsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasurementsLibTests
{
    public class MeasurementsRepository
    {
        private int _nextId = 4;
        private List<Measurements> _measurements = new()
        {
            new Measurements {id = 1, ppm = 570},
            new Measurements {id = 2, ppm = 470},
            new Measurements {id = 3, ppm = 320}
        };

        public IEnumerable<Measurements> GetMeasurements(int? ppm = null, int? idSort = null, string? orderBy = null)
        {
            // Create a copy of the measurements list to perform operations on
            IEnumerable<Measurements> result = new List<Measurements>(_measurements);

            // Filtering
            if (ppm != null)
            {
                // Filter the measurements where ppm is greater than the provided value
                result = result.Where(m => m.ppm > ppm);
            }

            // Sorting by id
            if (idSort != null)
            {
                if (orderBy == "asc")
                {
                    // Sort measurements in ascending order based on id
                    result = result.OrderBy(m => m.id);
                }
                else if (orderBy == "desc")
                {
                    // Sort measurements in descending order based on id
                    result = result.OrderByDescending(m => m.id);
                }
                else
                {
                    // If no specific order is provided, default to ascending order
                    result = result.OrderBy(m => m.id);
                }
            }

            // Return the filtered and sorted measurements
            return result;
        }
        public Measurements? GetById(int id)
        {
            return _measurements.Find(measurements => measurements.id == id);
        }

        public Measurements Add(Measurements measurements)
        {
            measurements.Validate(); //vaildates the measurements object
            measurements.id = _nextId++;
            _measurements.Add(measurements);
            return measurements;
        }

        public Measurements? Remove(int id)
        {
            Measurements? measurements = GetById(id);
            if (measurements == null)
            {
                return null;
            }
            _measurements.Remove(measurements);
            return measurements;
        }
    }
}