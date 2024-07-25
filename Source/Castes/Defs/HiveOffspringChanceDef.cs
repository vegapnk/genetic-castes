using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace GeneticCastes
{
    public class HiveOffspringChanceDef : Def 
    {

        public string queenXenotype;

        // Chance of the below should be 1 when summed up! 
        // Otherwise the roll-logic fails / missbehaves.
        public double queenChance;
        public double droneChance;
        public double workerChance;
    }
}
