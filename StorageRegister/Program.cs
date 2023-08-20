using StorageRegister.Models;

// Generate pallets
var pallets = GeneratePallets();

// sort pallets
var palletGroups = pallets.GroupBy(p => p.ExpirationDate).OrderBy(pg => pg.Key).ToList();
palletGroups.ForEach(pg => pg.OrderBy(p => p.NetWeight));

// print sorted pallets
printPalletGroups(palletGroups);

// take 3 pallets with furthest expiry date
var bestPallets = pallets.OrderByDescending(p => p.ExpirationDate).Take(3).OrderBy(p => p.Volume);
Console.WriteLine($"\n3 pallets with furthest expiry date");

// print taken pallets
foreach (var pallet in bestPallets)
{
	Console.WriteLine($"\tId: {pallet.Id}, Expiration date: {pallet.ExpirationDate}, Volume: {pallet.Volume}");
}

void printPalletGroups(List<IGrouping<DateOnly?, Pallet>> palletGroups)
{
	foreach (var palletGroup in palletGroups)
	{
		Console.WriteLine($"Pallet group: {palletGroup.Key}:");
		foreach (var pallet in palletGroup)
		{
			Console.WriteLine($"\tId: {pallet.Id}, Expiration date: {pallet.ExpirationDate}, Weight: {pallet.NetWeight}, Volume: {pallet.Volume}");
		}
	}
}

List<Pallet> GeneratePallets()
{
	Random random = new Random();
	var pallets = new List<Pallet>();
	for (int i = 0; i < 15; i++)
	{
		Pallet pallet = new Pallet(i, 30f, new Dimensions { Width = 3f, Depth = 4f, Height = 0.1f });
		for (int j = 0; j < random.Next() % 9 + 1; j++)
		{
			pallet.AddChild(
				new Box(
					(float)random.NextDouble() * 10,
					new Dimensions
					{
						Width = (float)random.NextDouble() * 2,
						Depth = (float)random.NextDouble() * 2,
						Height = (float)random.NextDouble() * 1
					},
					DateOnly.FromDateTime(DateTime.Now).AddDays(random.Next() % 30 - 10))
				);
		}
		pallets.Add(pallet);
	}
	return pallets;
}