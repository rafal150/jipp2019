using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitConversion
{
    public class SqlServiceRepository : IServiceRepository
    {
        public void AddConversionHistory(ConversionHistoryDTO conversionHistory)
        {
            using (ConverterContext db = new ConverterContext())
            {
                ConversionHistory ch = new ConversionHistory()
                {
                    Created = conversionHistory.Created,
                    BaseUnit = conversionHistory.BaseUnit,
                    BaseValue = conversionHistory.BaseValue,
                    ConversionType = conversionHistory.ConversionType,
                    TargetUnit = conversionHistory.TargetUnit,
                    TargetValue = conversionHistory.TargetValue
                };
                db.ConversionHistories.Add(ch);
                db.SaveChanges();
            }
        }

        public void SaveConverter(string converterType, string newConverterType)
        {
            using (ConverterContext db = new ConverterContext())
            {
                Converter c = null;
                if (string.IsNullOrEmpty(converterType))
                {
                    if (db.Converters.FirstOrDefault(x => x.Name == converterType) != null) return;
                    c = new Converter();
                    c.Created = DateTime.Now;
                    db.Converters.Add(c);
                }
                else
                    c = db.Converters.FirstOrDefault(x => x.Name == converterType);

                c.Name = newConverterType;

                //foreach(ConverterUnitDTO cuDTO in converter.Units)
                //{
                //    ConverterUnit cu = new ConverterUnit();
                //    cu.Converter = c;
                //    cu.Name = cuDTO.Name;
                //    cu.ConversionFromBaseValueFormula = cuDTO.ConversionFromBaseValueFormula;
                //    cu.ConversionToBaseValueFormula = cuDTO.ConversionToBaseValueFormula;

                //    db.ConverterUnits.Add(cu);
                //}

                db.SaveChanges();
            }
        }

        public IEnumerable<ConversionHistoryDTO> GetConversionHistory()
        {
            using (ConverterContext db = new ConverterContext())
            {
                return db.ConversionHistories.Select(x => new ConversionHistoryDTO()
                {
                    BaseUnit = x.BaseUnit,
                    BaseValue = x.BaseValue,
                    ConversionType = x.ConversionType,
                    Created = x.Created,
                    TargetUnit = x.TargetUnit,
                    TargetValue = x.TargetValue
                }).ToList();
            }
        }

        public IEnumerable<ConverterDTO> GetConverters()
        {
            using (ConverterContext db = new ConverterContext())
            {
                List<ConverterDTO> converters = new List<ConverterDTO>();
                foreach (Converter x in db.Converters)
                {
                    ConverterDTO cdto = new ConverterDTO();
                    cdto.Name = x.Name;
                    cdto.Created = x.Created;
                    cdto.Units = new List<ConverterUnitDTO>(x.Units.Select(y => new ConverterUnitDTO()
                    {
                        Name = y.Name,
                        ConversionFromBaseValueFormula = y.ConversionFromBaseValueFormula,
                        ConversionToBaseValueFormula = y.ConversionToBaseValueFormula,
                        Converter = cdto
                    }));
                    converters.Add(cdto);

                }
                return converters;
            }
        }

        public void DeleteConverter(string converterType)
        {
            using (ConverterContext db = new ConverterContext())
            {
                Converter converter = db.Converters.FirstOrDefault(x => x.Name == converterType);
                if(converter != null)
                {
                    db.ConverterUnits.RemoveRange(converter.Units);
                    db.Converters.Remove(converter);
                    db.SaveChanges();
                }
            }
        }

        public void SaveConverterUnit(string ConverterType, string ConverterUnitName, string Name, string ConversionToBaseValueFormula, string ConversionFromBaseValueFormula)
        {
            using (ConverterContext db = new ConverterContext())
            {
                Converter converter = db.Converters.FirstOrDefault(x => x.Name == ConverterType);
                ConverterUnit unit = converter.Units.FirstOrDefault(x => x.Name == ConverterUnitName);
                if(unit == null)
                {
                    if (converter.Units.FirstOrDefault(x => x.Name == Name) != null) return;
                    unit = new ConverterUnit();
                    db.ConverterUnits.Add(unit);
                }
                unit.Name = Name;
                unit.ConversionFromBaseValueFormula = ConversionFromBaseValueFormula;
                unit.ConversionToBaseValueFormula = ConversionToBaseValueFormula;
                unit.Converter = converter;
                db.SaveChanges();
            }
        }

        public void DeleteConverterUnit(string ConverterType, string Name)
        {
            using (ConverterContext db = new ConverterContext())
            {
                Converter converter = db.Converters.FirstOrDefault(x => x.Name == ConverterType);
                if (converter != null)
                {
                    ConverterUnit unit = converter.Units.FirstOrDefault(x => x.Name == Name);
                    if (unit != null)
                    {
                        db.ConverterUnits.Remove(unit);
                        db.SaveChanges();
                    }
                }
            }
        }
    }
}
