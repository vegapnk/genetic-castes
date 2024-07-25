using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace GeneticCastes
{
    public class ThoughtWorker_WorkerDespised_Social : ThoughtWorker
    {
        protected override ThoughtState CurrentSocialStateInternal(Pawn p, Pawn other)
        {
            // p is the pawn `thinking`, and other is the pawn being thought about.
            // here: p = queen, other = potential worker 

            if (!p.RaceProps.Humanlike)
                return (ThoughtState) false;

            if (!other.RaceProps.Humanlike)
                return (ThoughtState) false;

            if (!RelationsUtility.PawnsKnowEachOther(p, other))
                return (ThoughtState) false;

            // Only check if they are spawned 
            if (!p.Spawned || !other.Spawned || p.genes == null || other.genes == null)
                return (ThoughtState)false;

            if (p.genes.HasActiveGene(GeneDefOf.genetic_castes_queen) && other.genes.HasActiveGene(GeneDefOf.genetic_castes_worker))
            {
                return (ThoughtState)true;
            }

            return (ThoughtState)false;
        }
    }
}
