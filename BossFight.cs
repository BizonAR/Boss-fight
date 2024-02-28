using System;

namespace BossFight
{
	internal class BossFight
	{
		static void Main(string[] args)
		{
			const int ShadowSpiritSummonSpell = 1;
			const int ShadowSpiritAttackSpell = 2;
			const int InterdimensionalRiftSpell = 3;
			const int MeteoriteFallSpell = 4;

			int playerHP = 1000;
			int bossHP = 1500;
			bool shadowSummonUsed = false;

			int shadowSpiritInitialHP = 200;

			int shadowSpiritHP = shadowSpiritInitialHP;
			int damagePlayerSummoningShadowSpirit = 100;
			int shadowSpiritDamage = 100;
			int interdimensionalRiftHealing = 250;
			int meteoriteFallDamageBoss = 300;
			int meteoriteFallDamagePlayer = 100;
			int bossMinDamage = 50;
			int bossMaxDamage = 200;

			Console.WriteLine("Добро пожаловать в битву с боссом!");
			Console.WriteLine("У вас есть 4 заклинания для нанесения урона боссу.");
			Console.WriteLine("Чтобы победить, вам нужно снизить его здоровье до нуля.");
			Console.WriteLine("Остерегайтесь, босс тоже может вас атаковать!");

			while (playerHP > 0 && bossHP > 0)
			{
				Console.WriteLine("\nВаш ход:");
				Console.WriteLine($"{ShadowSpiritSummonSpell}. Рашамон - призывает теневого духа для нанесения атаки" +
				$"(Отнимает {damagePlayerSummoningShadowSpirit} хп игроку) , также теневой дух принимает весь урон на себя. " +
				$"ХП теневого духа - {shadowSpiritInitialHP}");
				Console.WriteLine($"{ShadowSpiritAttackSpell} - Хуганзакура (Может быть выполнен только после призыва " +
				$"теневого духа), наносит {shadowSpiritDamage} ед. урона");
				Console.WriteLine($"{InterdimensionalRiftSpell}. Межпространственный разлом - позволяет " +
				$"скрыться в разломе и восстановить {interdimensionalRiftHealing} хп. Урон босса по вам не проходит");
				Console.WriteLine($"{MeteoriteFallSpell}. Падение метеоритов - атака наносит {meteoriteFallDamageBoss} урона боссу " +
				$"и {meteoriteFallDamagePlayer} урона игроку");
				Console.Write($"Выберите заклинание ({ShadowSpiritSummonSpell}/{ShadowSpiritAttackSpell}" +
				$"/{InterdimensionalRiftSpell}/{MeteoriteFallSpell}): ");

				int choice = int.Parse(Console.ReadLine());

				switch (choice)
				{
					case ShadowSpiritSummonSpell:
						if (shadowSummonUsed == false)
						{
							Console.WriteLine("Вы призвали Теневого Духа для нанесения атаки.");
							playerHP -= damagePlayerSummoningShadowSpirit;
							shadowSummonUsed = true;
							Console.WriteLine($"Вы потеряли {damagePlayerSummoningShadowSpirit} HP. " +
							$"Ваше текущее здоровье: {playerHP}");
						}
						else
						{
							Console.WriteLine("Теневой дух уже призван.");
							continue;
						}
						break;

					case ShadowSpiritAttackSpell:
						if (shadowSummonUsed)
						{
							Console.WriteLine("Вы использовали Хуганзакура и нанесли урона боссу.");
							bossHP -= shadowSpiritDamage;
							Console.WriteLine($"Босс потерял {shadowSpiritDamage} HP. Его текущее здоровье: {bossHP}");
						}
						else
						{
							Console.WriteLine("Вы не можете использовать Хуганзакура без Рашамона.");
						}
						break;

					case InterdimensionalRiftSpell:
						Console.WriteLine("Вы скрылись в межпространственном разломе и восстановили HP.");
						playerHP += interdimensionalRiftHealing;
						Console.WriteLine($"Вы восстановили {interdimensionalRiftHealing} HP. " +
						$"Ваше текущее здоровье: {playerHP}");
						break;

					case MeteoriteFallSpell:
						Console.WriteLine("Вы вызвали Падение метеоритов и нанесли урона боссу и себе.");
						bossHP -= meteoriteFallDamageBoss;
						playerHP -= meteoriteFallDamagePlayer;
						Console.WriteLine($"Босс потерял {meteoriteFallDamageBoss} HP. Его текущее здоровье: {bossHP}");
						Console.WriteLine($"Вы потеряли {meteoriteFallDamagePlayer} HP. Ваше текущее здоровье: {playerHP}");
						break;

					default:
						Console.WriteLine("Некорректный выбор заклинания. Выберите снова.");
						continue;
				}

				Console.WriteLine("Ход босса:");
				int damage = new Random().Next(bossMinDamage, bossMaxDamage + 1);

				if (shadowSpiritHP > 0)
				{
					Console.WriteLine("Босс атаковал Теневого Духа!");
					shadowSpiritHP -= damage;
					Console.WriteLine($"Теневой Дух потерял {damage} HP. Его текущее здоровье: {shadowSpiritHP}");
				}
				else
				{
					playerHP -= damage;
					Console.WriteLine($"Босс атаковал вас и нанес {damage} урона.");
					Console.WriteLine($"Ваше текущее здоровье: {playerHP}");
				}
			}

			if (playerHP <= 0 && bossHP <= 0)
				Console.WriteLine("Ничья! Оба участника боя погибли.");
			else if (playerHP <= 0)
				Console.WriteLine("Вы проиграли! Босс одолел вас.");
			else if (bossHP <= 0)
				Console.WriteLine("Поздравляю! Вы победили босса!");
		}
	}
}
