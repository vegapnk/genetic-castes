using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Verse;

namespace GeneticCastes
{
    public class Thoughtworker_QueenPresent_Mood : ThoughtWorker
    {

        protected override ThoughtState CurrentStateInternal(Pawn p)
        {
            // Error Handling and Check for Pawn being on Map
            if (p == null || !p.Spawned || p.genes == null)
                return (ThoughtState) false;
            // Queens cannot have loyalty thoughts
            if (p.genes.HasActiveGene(GeneDefOf.genetic_castes_queen))
                return (ThoughtState)false;
            // If the pawn is not on Map (e.g. caravan), no mali 
            if (!HiveUtility.PawnIsOnHomeMap(p))
                return (ThoughtState)false;

            if (p.genes.HasActiveGene(GeneDefOf.genetic_castes_zealous_loyalty) && HiveUtility.QueensOnMap() == 1)
            {
                return (ThoughtState)true;
            }

            return (ThoughtState) false;
        }

    }
}
