using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyEdition
{
    public class MedicineService
    {
        private List<Medicine> _medicineList;
        private long _autoIncrementId = 0;
        public void Add(Medicine medicine)
        {
            var medicineIsSame = _medicineList.FirstOrDefault(med => med.Name == medicine.Name);
            if (medicineIsSame == null)
            {
                medicine.Id = ++_autoIncrementId;
                _medicineList.Add(medicine);
            }
            throw new Exception("Bunday turdagi dori oldindan mavjud!");
        }
        public void Update(Medicine medicine)
        {
            var oldmedicine = _medicineList.FirstOrDefault(med => medicine.Id == med.Id);
            oldmedicine.Id = medicine.Id;
            oldmedicine.Name = medicine.Name;
            oldmedicine.Price = medicine.Price;
            oldmedicine.ExpirationDate = medicine.ExpirationDate;
            oldmedicine.LeftCount = medicine.LeftCount;
            oldmedicine.Description = medicine.Description;
            oldmedicine.CreatedAt = medicine.CreatedAt;
            oldmedicine.UpdatedAt = medicine.UpdatedAt;

        }
        public void Delete(long id)
        {
            var removedMedicine = _medicineList.FirstOrDefault(med => med.Id == id);
            _medicineList.Remove(removedMedicine);
        }
        
        public Medicine GetById(long id)
        {
            var findMedicine = _medicineList.FirstOrDefault(med => med.Id == id);
            if (findMedicine != null)
                return findMedicine;
            throw new ArgumentNullException();
                
        }
        public List<Medicine> GetAllMedicine()
        {
            return _medicineList;
        }
        public List<Medicine> GetThemostSoldDrugsInTheLastMonth(DateTime Month)
        {
            var lastMonth =  DateTime.Now.AddMonths(-1);
            _medicineList.Where(med => med.CreatedAt > lastMonth);

            return new List<Medicine>();
        }
    }
}
