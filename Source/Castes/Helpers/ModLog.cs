using Verse;

namespace GeneticCastes
{
    internal class ModLog
	{
		public static string ModId => "Genetic-Castes";

		/// <summary>
		/// Logs the given message with [SaveStorage.ModId] appended.
		/// </summary>
		public static void Error(string message)
		{
			Log.Error($"[{ModId}] {message}");
		}

		/// <summary>
		/// Logs the given message with [SaveStorage.ModId] appended.
		/// </summary>
		public static void Message(string message)
		{
			Log.Message($"[{ModId}] {message}");
		}

		/// <summary>
		/// Logs the given message with [SaveStorage.ModId] appended.
		/// </summary>
		public static void Warning(string message)
		{
			Log.Warning($"[{ModId}] {message}");
		}

	}
}
